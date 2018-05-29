using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;

namespace Idream_Attendance
{
    public partial class AttenReportFrom : DevExpress.XtraEditors.XtraForm
    {
        public AttenReportFrom(DataTable pEmployeeDt,IDbOperator pDbOp)
        {
            InitializeComponent();
            IntialControl();
            m_EmployeeDt = pEmployeeDt;
            m_mainDbOp = pDbOp;
        }
        private Dictionary<int, string> m_dicMothn = new Dictionary<int, string>() {
            { 1,"一月"},
            { 2,"二月"},
            { 3,"三月"},
            { 4,"四月"},
            { 5,"五月"},
            { 6,"六月"},
            { 7,"七月"},
            { 8,"八月"},
            { 9,"九月"},
            { 10,"十月"},
            { 11,"十一月"},
            { 12,"十二月"}
        };
        /// <summary>
        /// 员工表
        /// </summary>
        private DataTable m_EmployeeDt = null;
        /// <summary>
        /// 数据操作
        /// </summary>
        private IDbOperator m_mainDbOp = null;
        /// <summary>
        /// 考勤日期表
        /// </summary>
        private DataTable m_AttenDateDt = null;
        /// <summary>
        /// 考勤报表
        /// </summary>
        private DataTable m_AttenReportDt = null;
        private void IntialControl()
        {
            foreach (string values in m_dicMothn.Values)
            {
                cbMonth.Properties.Items.Add(values);
            }
            cbMonth.SelectedIndex = -1;
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttenReportFrom_Load(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            int iYear = dateTime.Date.Year;
            int iMonth = dateTime.Date.Month;
            if (iMonth == 1)
            {
                seYear.EditValue = iYear - 1;
                cbMonth.SelectedIndex = 11;
            }
            else
            {
                seYear.EditValue = iYear;
                cbMonth.SelectedIndex = iMonth - 2;
            }
        }
        /// <summary>
        /// 获取月份
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        private int GetMonthByValues(string values)
        {
            foreach (int key in m_dicMothn.Keys)
            {
                if (values == m_dicMothn[key]) return key;
            }
            return 1;
        }
        /// <summary>
        /// 获取考勤日期
        /// </summary>
        /// <param name="minDt">最小考勤日期</param>
        /// <param name="maxDt">最大考勤日期</param>
        /// <returns></returns>
        private bool GetAttenDateDt(DateTime minDt, DateTime maxDt)
        {
            bool flag = false;
            m_AttenDateDt = m_mainDbOp.GetDataTable(Common.Table_AttenDate, string.Format("{0} between #{1}# and #{2}# order by {0} asc",
                 Common.Column_AttendanceDate, minDt.ToString("yyyy-MM-dd"), maxDt.ToString("yyyy-MM-dd"), Common.Column_AttendanceDate));
            if (m_AttenDateDt == null || m_AttenDateDt.Rows.Count == 0)
            {
                XtraMessageBox.Show("考勤日期未配置，请先生成","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                AttenDateForm attenDateForm = new AttenDateForm(m_mainDbOp);
                if (attenDateForm.ShowDialog() != DialogResult.OK)
                {
                    return flag;
                }
                else
                {
                    m_AttenDateDt = m_mainDbOp.GetDataTable(Common.Table_AttenDate, string.Format("{0} between #{1}# and #{2}# order by {0} asc",
                        Common.Column_AttendanceDate, minDt.ToString("yyyy-MM-dd"), maxDt.ToString("yyyy-MM-dd"), Common.Column_AttendanceDate));
                    if (m_AttenDateDt == null || m_AttenDateDt.Rows.Count == 0) return flag;
                    else { flag=true; }
                }
            }
            return flag;
        }
        /// <summary>
        /// 生成考勤报表表结构
        /// </summary>
        /// <returns></returns>
        private bool GetAttenReportDt()
        {
            if (m_AttenDateDt == null || m_AttenDateDt.Rows.Count == 0) return false;
            if (m_EmployeeDt == null || m_EmployeeDt.Rows.Count == 0) return false;
            m_AttenReportDt = new DataTable(Common.Table_AttenReport);
            DataColumn col = new DataColumn(Common.Column_EmployeCode, Type.GetType("System.String"));
            m_AttenReportDt.Columns.Add(col);
            col = new DataColumn(Common.Column_EmployeName, Type.GetType("System.String"));
            m_AttenReportDt.Columns.Add(col);
            for (int i = 0; i < m_AttenDateDt.Rows.Count; i++)
            {
                DataRow pRow = m_AttenDateDt.Rows[i];
                col = new DataColumn();
                DateTime dt = Convert.ToDateTime(pRow[Common.Column_AttendanceDate]);
                col.ColumnName = dt.ToString("dd");
                col.Caption = dt.ToString("dd");
                col.DataType = Type.GetType("System.String");
                m_AttenReportDt.Columns.Add(col);
            }
            //先实现单个日期的计算
            return true;
        }
        /// <summary>
        /// 生成考勤报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetAttenDate_Click(object sender, EventArgs e)
        {
            int SelectYear = int.Parse(seYear.EditValue.ToString());
            int SelectMonth = GetMonthByValues(cbMonth.SelectedItem.ToString());
            DateTime dtMin = new DateTime(SelectYear, SelectMonth, 1, 0, 0, 0);
            DateTime TempDt = dtMin.AddMonths(1);
            TempDt = TempDt.AddDays(0 - TempDt.Day);
            DateTime dtMax = new DateTime(SelectYear, SelectMonth, TempDt.Day, 23, 59, 59);
            if (!GetAttenDateDt(dtMin, dtMax))
            {
                XtraMessageBox.Show("考勤日期未配置正确，请重新配置!","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (!GetAttenReportDt())
            {
                XtraMessageBox.Show("生成报表表头失败！","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            //开始计算考勤
            foreach (DataRow pRow in m_EmployeeDt.Rows)
            {
                Employee employee = new Employee(pRow, m_mainDbOp);
                DataRow pNewRow = m_AttenReportDt.NewRow();
                pNewRow[Common.Column_EmployeCode] = employee.Employee_Code;
                pNewRow[Common.Column_EmployeName] = employee.Employee_Name;
                foreach (DataRow pAttenDateRow in m_AttenDateDt.Rows)
                {
                    DateTime attenDt = Convert.ToDateTime(pAttenDateRow[Common.Column_AttendanceDate]);
                    int tempInt = 0;
                    if (!int.TryParse(pAttenDateRow[Common.Column_AttenType].ToString(), out tempInt))
                    {
                        continue;
                    }
                    pNewRow[attenDt.ToString("dd")] = employee.GetAttenDateStatu(attenDt, (AttendanceType)tempInt);
                }
                m_AttenReportDt.Rows.Add(pNewRow);
            }
            mainGridControl.DataSource = m_AttenReportDt;
            mainGridControl.RefreshDataSource();

        }
        /// <summary>
        /// 表格控件数据源改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainGridControl_DataSourceChanged(object sender, EventArgs e)
        {
            mainView.Columns.Clear();
            if (mainGridControl.DataSource is DataTable)
            {
                DataTable dt = mainGridControl.DataSource as DataTable;
                foreach (DataColumn col in dt.Columns)
                {
                    GridColumn gridCol = new GridColumn();
                    gridCol.FieldName = gridCol.Name = col.ColumnName;
                    gridCol.Caption = col.Caption;
                    mainView.Columns.Add(gridCol);
                }
            }
        }
    }
}
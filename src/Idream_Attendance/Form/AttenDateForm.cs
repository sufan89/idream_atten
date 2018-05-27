using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Idream_Attendance
{
    public partial class AttenDateForm : XtraForm
    {
        public AttenDateForm(IDbOperator dbOperator)
        {
            InitializeComponent();
            InitialControl();
            InitialSourceDt();
            m_dbOperator = dbOperator;
        }
        private void InitialControl()
        {
            InitialAttenTypeDdb();
            InitialcbMonth();
        }
        private Dictionary<string, AttendanceType> m_dicAttenType = new Dictionary<string, AttendanceType>()
        {
            {"上午不考勤",AttendanceType.NoAmAtten },
            {"不考勤",AttendanceType.NoAtten},
            {"下午不考勤" ,AttendanceType.NoPmAtten},
            {"正常考勤",AttendanceType.NormalAtten}
        };
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
        private DataTable m_AttenTable = null;
        private DataTable m_gvTable = new DataTable(Common.Column_AttendanceDate);
        private int Click_rowIndex = 0;
        private string Click_colName = string.Empty;
        private IDbOperator m_dbOperator = null;
        /// <summary>
        /// 初始化考勤类型下拉框
        /// </summary>
        private void InitialAttenTypeDdb()
        {
            foreach (string key in m_dicAttenType.Keys)
            {
                cbAttenType.Properties.Items.Add(key);
            }
            cbAttenType.SelectedIndex = -1;
        }
        private void InitialcbMonth()
        {
            foreach (string values in m_dicMothn.Values)
            {
                cbMonth.Properties.Items.Add(values);
            }
            cbMonth.SelectedIndex = -1;
        }
        /// <summary>
        /// 添加表列
        /// </summary>
        private void InitialSourceDt()
        {
            m_gvTable.Columns.Clear();
            DataColumn col = new DataColumn();
            col.ColumnName = "colmonday";
            col.DataType = Type.GetType("System.String");
            m_gvTable.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "coltuesday";
            col.DataType = Type.GetType("System.String");
            m_gvTable.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "colwednesday";
            col.DataType = Type.GetType("System.String");
            m_gvTable.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "colthursday";
            col.DataType = Type.GetType("System.String");
            m_gvTable.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "colfriday";
            col.DataType = Type.GetType("System.String");
            m_gvTable.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "colsaturday";
            col.DataType = Type.GetType("System.String");
            m_gvTable.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "colsunday";
            col.DataType = Type.GetType("System.String");
            m_gvTable.Columns.Add(col);
            gridAttenDate.DataSource = m_gvTable;
        }
        private void GetExistAttenDate(int gYear,int gMonth)
        {
            DateTime minDt = new DateTime(gYear, gMonth, 1);
            DateTime maxDt = minDt.AddMonths(1);
            maxDt = maxDt.AddDays(0 - maxDt.Day);
            m_AttenTable = m_dbOperator.GetDataTable(Common.Table_AttenDate,
                string.Format("{0} between #{1}# and #{2}# order by {0} asc",
                Common.Column_AttendanceDate, minDt.ToString("yyyy-MM-dd"), maxDt.ToString("yyyy-MM-dd")));
            if (m_AttenTable != null && m_AttenTable.Rows.Count > 0)
            {
                if (m_AttenTable.Columns.Contains("ID"))
                {
                    m_AttenTable.Columns.Remove("ID");
                }
                m_gvTable.Rows.Clear();
                gridAttenDate.RefreshDataSource();
                DataRow pNewRow = null;
                int rowCount = m_AttenTable.Rows.Count;
                for (int i=0;i<rowCount; i++)
                {
                    DataRow pRow = m_AttenTable.Rows[i];
                    DateTime pTime = Convert.ToDateTime(pRow[Common.Column_AttendanceDate]);
                    if (i == 0|| pTime.DayOfWeek==DayOfWeek.Monday)
                    {
                        pNewRow = m_gvTable.NewRow();
                    }
                    switch (pTime.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            pNewRow["colmonday"] = string.Format("{0}-{1}", pTime.ToString("dd"), GetAttenTypeStr(pRow[Common.Column_AttenType]));
                            break;
                        case DayOfWeek.Saturday:
                            pNewRow["colsaturday"] = string.Format("{0}-{1}", pTime.ToString("dd"), GetAttenTypeStr(pRow[Common.Column_AttenType]));
                            break;
                        case DayOfWeek.Sunday:
                            pNewRow["colsunday"] = string.Format("{0}-{1}", pTime.ToString("dd"), GetAttenTypeStr(pRow[Common.Column_AttenType]));
                            break;
                        case DayOfWeek.Thursday:
                            pNewRow["colthursday"] = string.Format("{0}-{1}", pTime.ToString("dd"), GetAttenTypeStr(pRow[Common.Column_AttenType]));
                            break;
                        case DayOfWeek.Tuesday:
                            pNewRow["coltuesday"] = string.Format("{0}-{1}", pTime.ToString("dd"), GetAttenTypeStr(pRow[Common.Column_AttenType]));
                            break;
                        case DayOfWeek.Wednesday:
                            pNewRow["colwednesday"] = string.Format("{0}-{1}", pTime.ToString("dd"), GetAttenTypeStr(pRow[Common.Column_AttenType]));
                            break;
                        case DayOfWeek.Friday:
                            pNewRow["colfriday"] = string.Format("{0}-{1}", pTime.ToString("dd"), GetAttenTypeStr(pRow[Common.Column_AttenType]));
                            break;
                    }
                    if (pTime.DayOfWeek == DayOfWeek.Sunday)
                    {
                        m_gvTable.Rows.Add(pNewRow);
                        if (i == 0)
                        {
                            pNewRow = m_gvTable.NewRow();
                        }
                    }
                    if (i == rowCount-1 && pTime.DayOfWeek != DayOfWeek.Sunday)
                    {
                        m_gvTable.Rows.Add(pNewRow);
                    }
                }
                gridAttenDate.RefreshDataSource();
            }
        }
        private void AddDateToDt(DateTime dt)
        {
            m_gvTable.Rows.Clear();
            gridAttenDate.RefreshDataSource();
            dt = dt.AddMonths(1);
            dt = dt.AddDays(0 - dt.Day);
            int lastDay = dt.Day;
            DataRow pRow = null;
            for (int i = 1; i <= lastDay; i++)
            {
                DateTime newDt = new DateTime(dt.Year, dt.Month,i);
                if (i==1||newDt.DayOfWeek == DayOfWeek.Monday)
                {
                    pRow = m_gvTable.NewRow();
                }
                switch (newDt.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        pRow["colmonday"] = string.Format("{0}-正常考勤", newDt.ToString("dd"));
                        break;
                    case DayOfWeek.Saturday:
                        pRow["colsaturday"] = string.Format("{0}-不考勤", newDt.ToString("dd"));
                        break;
                    case DayOfWeek.Sunday:
                        pRow["colsunday"] = string.Format("{0}-不考勤", newDt.ToString("dd"));
                        break;
                    case DayOfWeek.Thursday:
                        pRow["colthursday"] = string.Format("{0}-正常考勤", newDt.ToString("dd"));
                        break;
                    case DayOfWeek.Tuesday:
                        pRow["coltuesday"] = string.Format("{0}-正常考勤", newDt.ToString("dd"));
                        break;
                    case DayOfWeek.Wednesday:
                        pRow["colwednesday"] = string.Format("{0}-正常考勤", newDt.ToString("dd"));
                        break;
                    case DayOfWeek.Friday:
                        pRow["colfriday"] = string.Format("{0}-正常考勤", newDt.ToString("dd"));
                        break;
                }
                if (newDt.DayOfWeek == DayOfWeek.Sunday)
                {
                    m_gvTable.Rows.Add(pRow);
                    if (i == 1)
                    {
                        pRow = m_gvTable.NewRow();
                    }
                }
                if (i == lastDay && newDt.DayOfWeek != DayOfWeek.Sunday)
                {
                    m_gvTable.Rows.Add(pRow);
                }
            }
            gridAttenDate.RefreshDataSource();
        }
        private string GetAttenTypeStr(object typeValue)
        {
            if (typeValue == DBNull.Value) return string.Empty;
            int AttenType = 0;
            if (!int.TryParse(typeValue.ToString(), out AttenType)) return string.Empty;
            AttendanceType attendanceType = (AttendanceType)AttenType;
            foreach (string key in m_dicAttenType.Keys)
            {
                if (m_dicAttenType[key] == attendanceType) return key;
            }
            return string.Empty;
        }
        /// <summary>
        /// 获取考勤列表并保存到数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (m_gvTable.Rows.Count == 0)
            {
                XtraMessageBox.Show("提示", "先生成考勤日期", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (m_AttenTable == null)
            {
                m_AttenTable = new DataTable(Common.Column_AttendanceDate);
                DataColumn col = new DataColumn();
                col.ColumnName = Common.Column_AttendanceDate;
                col.DataType = Type.GetType("System.DateTime");
                m_AttenTable.Columns.Add(col);
                col = new DataColumn();
                col.ColumnName = Common.Column_AttenType;
                col.DataType = Type.GetType("System.String");
                m_AttenTable.Columns.Add(col);
            }
            else
            {
                m_AttenTable.Rows.Clear();
            }
            int selectYear = int.Parse(seYear.EditValue.ToString());
            int selectMonth = 0;
            foreach (int key in m_dicMothn.Keys)
            {
                if (m_dicMothn[key] == cbMonth.SelectedItem.ToString())
                {
                    selectMonth = key;
                    break;
                }
            }
            foreach (DataRow pRow in m_gvTable.Rows)
            {
                foreach (DataColumn col in m_gvTable.Columns)
                {
                    if (pRow[col] != DBNull.Value)
                    {
                        string[] rowValue = pRow[col].ToString().Split('-');
                        DataRow pNewRow = m_AttenTable.NewRow();
                        DateTime dt = new DateTime(selectYear, selectMonth, int.Parse(rowValue[0]));
                        pNewRow[Common.Column_AttendanceDate] = dt;
                        pNewRow[Common.Column_AttenType] = (int)m_dicAttenType[rowValue[1]];
                        m_AttenTable.Rows.Add(pNewRow);
                    }
                }
            }
            //先删后加
            DateTime minDt = new DateTime(selectYear, selectMonth, 1);
            DateTime maxDt = minDt.AddMonths(1);
            maxDt = maxDt.AddDays(0 - maxDt.Day);

            if (!m_dbOperator.DelData(Common.Table_AttenDate,
                string.Format("{0} between #{1}# and #{2}#",
                Common.Column_AttendanceDate, minDt.ToString("yyyy-MM-dd"), maxDt.ToString("yyyy-MM-dd"))))
            {
                XtraMessageBox.Show("删除数据出错","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            if (m_dbOperator.ImportDataTable(m_AttenTable))
            {
                XtraMessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("保存失败","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttenDateForm_Load(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            int iYear= dateTime.Date.Year;
            int iMonth= dateTime.Date.Month;
            if (iMonth == 1)
            {
                seYear.EditValue = iYear - 1;
                cbMonth.SelectedIndex = 11;
                GetExistAttenDate(iYear - 1,12);
            }
            else
            {
                seYear.EditValue = iYear;
                cbMonth.SelectedIndex = iMonth-2;
                GetExistAttenDate(iYear, iMonth-1);
            }
           
        }
        /// <summary>
        /// 生成考勤日期表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetAttenDate_Click(object sender, EventArgs e)
        {
            int selectYear = 0;
            if (!int.TryParse(seYear.EditValue.ToString(), out selectYear)||selectYear<=2000||selectYear>3000)
            {
                XtraMessageBox.Show("提示", "选择的年份不正确！请重新编辑后再试。",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            string selectItem = cbMonth.SelectedItem.ToString();
            int selectmonth = 0;
            foreach (int key in m_dicMothn.Keys)
            {
                if (m_dicMothn[key] == selectItem)
                {
                    selectmonth = key;
                    break;
                }
            }
            DateTime AttenDate = new DateTime(selectYear,selectmonth,2);
            AddDateToDt(AttenDate);
        }
        /// <summary>
        /// 点击时可以修改状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvAttenDate_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.CellValue == DBNull.Value)
            {
                Click_rowIndex = -1;
                Click_colName = string.Empty;
                cbAttenType.SelectedIndex = -1;
                return;
            }
            string clickValue = e.CellValue.ToString();
            Click_rowIndex = e.RowHandle;
            Click_colName = e.Column.FieldName;
            string[] splitValue = clickValue.Split('-');
            cbAttenType.SelectedItem = splitValue[1];
        }

        private void cbAttenType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_gvTable.Rows.Count == 0) return;
            if (string.IsNullOrEmpty(Click_colName)) return;
            string selectType = cbAttenType.SelectedItem.ToString();
            string oldValue=m_gvTable.Rows[Click_rowIndex][Click_colName].ToString();
            string[] splitValue = oldValue.Split('-');
            m_gvTable.Rows[Click_rowIndex][Click_colName] = string.Format("{0}-{1}", splitValue[0], selectType);
            gridAttenDate.RefreshDataSource();

        }
    }
}
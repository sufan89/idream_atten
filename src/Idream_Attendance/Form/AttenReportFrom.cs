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
        private DataTable m_EmployeeDt = null;
        private IDbOperator m_mainDbOp = null;
        private DataTable m_AttenDateDt = null;
        private void IntialControl()
        {
            foreach (string values in m_dicMothn.Values)
            {
                cbMonth.Properties.Items.Add(values);
            }
            cbMonth.SelectedIndex = -1;
        }
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
        private int GetMonthByValues(string values)
        {
            foreach (int key in m_dicMothn.Keys)
            {
                if (values == m_dicMothn[key]) return key;
            }
            return 1;
        }
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

        }

    }
}
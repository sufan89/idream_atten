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
        public AttenDateForm()
        {
            InitializeComponent();
            InitialControl();
        }
        private void InitialControl()
        {
            InitialAttenTypeDdb();
            InitialcbMonth();
        }
        Dictionary<string, AttendanceType> m_dicAttenType = new Dictionary<string, AttendanceType>()
        {
            {"上午不考勤",AttendanceType.NoAmAtten },
            {"不考勤",AttendanceType.NoAtten},
            {"下午不考勤" ,AttendanceType.NoPmAtten},
            {"正常考勤",AttendanceType.NormalAtten}
        };
        Dictionary<int, string> m_dicMothn = new Dictionary<int, string>() {
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
        /// 获取考勤列表并保存到数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {

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
            }
            else
            {
                seYear.EditValue = iYear;
                cbMonth.SelectedIndex = iMonth-2;
            }
        }
    }
}
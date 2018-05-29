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
    public partial class VacationForm : DevExpress.XtraEditors.XtraForm
    {
        public VacationForm(Employee employee)
        {
            InitializeComponent();
            m_VaEmployee = employee;
            InitialControl();
        }
        private Employee m_VaEmployee = null;
        private Dictionary<VacationType, string> m_VacationType = new Dictionary<VacationType, string>() {
             {VacationType.Goout,"外出" },
            {VacationType.DaysOff,"调休" },
            {VacationType.AnnualLeave,"年假" },
            {VacationType.PersonalLeave,"事假"},
            {VacationType.SickLeave,"病假" },
            { VacationType.MaternityLeave,"产假"},
            { VacationType.PaternityLeave,"陪产假"},
            { VacationType.MarriageLeave,"婚假"},
            { VacationType.BreastfeedingLeave,"哺乳假"},
            { VacationType.FuneralLeave,"丧假"}
        };
        private void InitialControl()
        {
            cbVatype.Properties.Items.Clear();
            foreach (VacationType key in m_VacationType.Keys)
            {
                cbVatype.Properties.Items.Add(m_VacationType[key]);
            }
            txtEmployeName.Text = m_VaEmployee.Employee_Name;
        }
        private VacationType GetTypeByValue(string svalue)
        {
            foreach (VacationType key in m_VacationType.Keys)
            {
                if (m_VacationType[key] == svalue) return key;
            }
            return VacationType.PersonalLeave;
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime startTime = deStartTime.DateTime;
            DateTime endTime = deEndTime.DateTime;
            if (startTime > endTime)
            {
                XtraMessageBox.Show("选择的时间区间不正确","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cbVatype.SelectedItem.ToString()))
            {
                XtraMessageBox.Show("请选择请假类型","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            double Duran =double.Parse(seVacationDura.EditValue.ToString());
            VacationType vacationType = GetTypeByValue(cbVatype.SelectedItem.ToString());
            if (m_VaEmployee.EmployeVacation(startTime, endTime, Duran, vacationType))
            {
                XtraMessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("保存失败","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }
    }
}
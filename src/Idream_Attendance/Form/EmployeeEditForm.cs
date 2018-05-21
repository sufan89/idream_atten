using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Idream_Attendance
{
    public partial class EmployeeEditForm : DevExpress.XtraEditors.XtraForm
    {
        public EmployeeEditForm()
        {
            InitializeComponent();
        }
        public EmployeeEditForm(string strCaption,IDbOperator pDbOperator,Employee pEmployee=null ) : this()
        {
            this.Text = strCaption;
            if (pEmployee == null)
            {
                //新增
                m_IsEdit = false;
                dtEntryDate.DateTime = DateTime.Now;
                deLeaveDate.DateTime = new DateTime(9999, 12, 31);
            }
            else
            {
                //编辑
                m_IsEdit = true;
                txtCode.Text = pEmployee.Employee_Code;
                txtAttenCode.Text = pEmployee.Employee_AttenCode;
                txtName.Text = pEmployee.Employee_Name;
                txtPhoneNum.Text = pEmployee.Employee_PhoneNum;
                dtEntryDate.DateTime = pEmployee.Employ_EntryDate;
                deLeaveDate.DateTime = pEmployee.Employ_LeaveDate;
                txtAttenCode.ReadOnly = true;
                txtCode.ReadOnly = true;
                m_Employee = pEmployee;
            }
            m_dbOperator = pDbOperator;
           
        }
        private IDbOperator m_dbOperator = null;
        private bool m_IsEdit = false;//True 为编辑、Flase为新增
        private Employee m_Employee = null;
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!JudgeInput()) return;
            if (!m_IsEdit)
            {
                m_Employee = new Employee(m_dbOperator)
                {
                    Employee_AttenCode = txtAttenCode.Text,
                    Employee_Code=txtCode.Text,
                    Employee_Name=txtName.Text,
                    Employee_PhoneNum=txtPhoneNum.Text,
                    Employ_EntryDate=dtEntryDate.DateTime,
                    Employ_LeaveDate=deLeaveDate.DateTime
                };
                if (m_Employee.AddEmploye())
                {
                    XtraMessageBox.Show("成功添加员工", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("添加新员工失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                m_Employee.Employee_Name = txtName.Text;
                m_Employee.Employee_PhoneNum = txtPhoneNum.Text;
                m_Employee.Employ_EntryDate = dtEntryDate.DateTime;
                m_Employee.Employ_LeaveDate = deLeaveDate.DateTime;
                if (m_Employee.UpdateEmploye())
                {
                    XtraMessageBox.Show("成功修改员工信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("修改员工信息失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private bool JudgeInput()
        {
            if (m_IsEdit)
            {
                if (string.IsNullOrEmpty(txtCode.Text))
                {
                    XtraMessageBox.Show("员工编码必填", "提示", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtCode.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtAttenCode.Text))
                {
                    XtraMessageBox.Show("员工考勤编码必填", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAttenCode.Focus();
                    return false;
                }
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                XtraMessageBox.Show("员工名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPhoneNum.Text) || txtPhoneNum.Text.Length != 11)
            {
                XtraMessageBox.Show("员工联系方式不正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhoneNum.Focus();
                return false;
            }
            return true;
        }
    }
}

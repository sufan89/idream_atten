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
    public partial class FromEmOverTime : DevExpress.XtraEditors.XtraForm
    {
        public FromEmOverTime(Employee employee)
        {
            InitializeComponent();
            m_Employe = employee;
            InitailControl();
        }
        private Employee m_Employe = null;
        private void InitailControl()
        {
            if (m_Employe != null)
            {
                txtEmployeeName.Text = m_Employe.Employee_Name;
            }
            deStartTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            deEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DateTime starTime = deStartTime.DateTime;
            DateTime endTime = deEndTime.DateTime;
            double duration = 0.0;
            duration=double.Parse( seOverTimeDuration.EditValue.ToString());
            if (m_Employe.OverTime(starTime, endTime, duration))
            {
                XtraMessageBox.Show("添加成功", "提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show("添加失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
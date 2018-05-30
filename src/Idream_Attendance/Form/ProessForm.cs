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
    public partial class ProessForm : DevExpress.XtraEditors.XtraForm
    {
        public ProessForm(int barMax,int barMin,string lblValue)
        {
            InitializeComponent();
            mainProgressBar.Maximum = barMax;
            mainProgressBar.Minimum = barMin;
            lblInfo.Text = lblValue;
        }
        public void SetBarValue(int value)
        {
            mainProgressBar.Value = value;
        }
        public void SetLabelValue(string lblValue)
        {
            lblInfo.Text = lblValue;
        }
        public void SetBarAndLabel(int value, string lblValue)
        {
            mainProgressBar.Value = value;
            lblInfo.Text = lblValue;
            lblInfo.Refresh();
        }
    }
}
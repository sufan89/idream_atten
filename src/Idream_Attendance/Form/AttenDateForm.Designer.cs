namespace Idream_Attendance.Form
{
    partial class AttenDateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.calendarControl1 = new DevExpress.XtraEditors.Controls.CalendarControl();
            this.lblYear = new DevExpress.XtraEditors.LabelControl();
            this.seYear = new DevExpress.XtraEditors.SpinEdit();
            this.lblMonth = new DevExpress.XtraEditors.LabelControl();
            this.ddbSelectMonth = new DevExpress.XtraEditors.DropDownButton();
            this.lblAttenType = new DevExpress.XtraEditors.LabelControl();
            this.ddbAttenType = new DevExpress.XtraEditors.DropDownButton();
            this.btnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.calendarControl1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seYear.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // calendarControl1
            // 
            this.calendarControl1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calendarControl1.Location = new System.Drawing.Point(14, 42);
            this.calendarControl1.Name = "calendarControl1";
            this.calendarControl1.Size = new System.Drawing.Size(288, 237);
            this.calendarControl1.TabIndex = 0;
            // 
            // lblYear
            // 
            this.lblYear.Location = new System.Drawing.Point(308, 42);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(52, 14);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "年    份：";
            // 
            // seYear
            // 
            this.seYear.EditValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.seYear.Location = new System.Drawing.Point(308, 62);
            this.seYear.Name = "seYear";
            this.seYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seYear.Properties.IsFloatValue = false;
            this.seYear.Properties.Mask.EditMask = "N00";
            this.seYear.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.seYear.Properties.MinValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.seYear.Size = new System.Drawing.Size(100, 20);
            this.seYear.TabIndex = 2;
            // 
            // lblMonth
            // 
            this.lblMonth.Location = new System.Drawing.Point(308, 88);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(52, 14);
            this.lblMonth.TabIndex = 3;
            this.lblMonth.Text = "月    份：";
            // 
            // ddbSelectMonth
            // 
            this.ddbSelectMonth.Location = new System.Drawing.Point(308, 108);
            this.ddbSelectMonth.Name = "ddbSelectMonth";
            this.ddbSelectMonth.Size = new System.Drawing.Size(135, 23);
            this.ddbSelectMonth.TabIndex = 4;
            // 
            // lblAttenType
            // 
            this.lblAttenType.Location = new System.Drawing.Point(14, 285);
            this.lblAttenType.Name = "lblAttenType";
            this.lblAttenType.Size = new System.Drawing.Size(60, 14);
            this.lblAttenType.TabIndex = 5;
            this.lblAttenType.Text = "考勤状态：";
            // 
            // ddbAttenType
            // 
            this.ddbAttenType.Location = new System.Drawing.Point(14, 305);
            this.ddbAttenType.Name = "ddbAttenType";
            this.ddbAttenType.Size = new System.Drawing.Size(135, 23);
            this.ddbAttenType.TabIndex = 6;
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(455, 362);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 7;
            this.btnCancle.Text = "取    消";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(368, 362);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "确    定";
            // 
            // AttenDateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 397);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.ddbAttenType);
            this.Controls.Add(this.lblAttenType);
            this.Controls.Add(this.ddbSelectMonth);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.seYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.calendarControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AttenDateForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "设置考勤日期";
            ((System.ComponentModel.ISupportInitialize)(this.calendarControl1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seYear.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.Controls.CalendarControl calendarControl1;
        private DevExpress.XtraEditors.LabelControl lblYear;
        private DevExpress.XtraEditors.SpinEdit seYear;
        private DevExpress.XtraEditors.LabelControl lblMonth;
        private DevExpress.XtraEditors.DropDownButton ddbSelectMonth;
        private DevExpress.XtraEditors.LabelControl lblAttenType;
        private DevExpress.XtraEditors.DropDownButton ddbAttenType;
        private DevExpress.XtraEditors.SimpleButton btnCancle;
        private DevExpress.XtraEditors.SimpleButton btnOk;
    }
}
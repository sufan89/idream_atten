namespace Idream_Attendance
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
            this.lblYear = new DevExpress.XtraEditors.LabelControl();
            this.seYear = new DevExpress.XtraEditors.SpinEdit();
            this.lblMonth = new DevExpress.XtraEditors.LabelControl();
            this.lblAttenType = new DevExpress.XtraEditors.LabelControl();
            this.btnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.cbMonth = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbAttenType = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.seYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAttenType.Properties)).BeginInit();
            this.SuspendLayout();
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
            // lblAttenType
            // 
            this.lblAttenType.Location = new System.Drawing.Point(14, 285);
            this.lblAttenType.Name = "lblAttenType";
            this.lblAttenType.Size = new System.Drawing.Size(60, 14);
            this.lblAttenType.TabIndex = 5;
            this.lblAttenType.Text = "考勤状态：";
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(455, 362);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 7;
            this.btnCancle.Text = "取    消";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(368, 362);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "确    定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cbMonth
            // 
            this.cbMonth.Location = new System.Drawing.Point(308, 108);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbMonth.Size = new System.Drawing.Size(100, 20);
            this.cbMonth.TabIndex = 9;
            // 
            // cbAttenType
            // 
            this.cbAttenType.Location = new System.Drawing.Point(14, 305);
            this.cbAttenType.Name = "cbAttenType";
            this.cbAttenType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbAttenType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbAttenType.Size = new System.Drawing.Size(100, 20);
            this.cbAttenType.TabIndex = 10;
            // 
            // AttenDateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 397);
            this.Controls.Add(this.cbAttenType);
            this.Controls.Add(this.cbMonth);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.lblAttenType);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.seYear);
            this.Controls.Add(this.lblYear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AttenDateForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "设置考勤日期";
            this.Load += new System.EventHandler(this.AttenDateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.seYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAttenType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl lblYear;
        private DevExpress.XtraEditors.SpinEdit seYear;
        private DevExpress.XtraEditors.LabelControl lblMonth;
        private DevExpress.XtraEditors.LabelControl lblAttenType;
        private DevExpress.XtraEditors.SimpleButton btnCancle;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.ComboBoxEdit cbMonth;
        private DevExpress.XtraEditors.ComboBoxEdit cbAttenType;
    }
}
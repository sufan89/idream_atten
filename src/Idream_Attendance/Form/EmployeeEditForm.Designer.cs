namespace Idream_Attendance
{
    partial class EmployeeEditForm
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
            this.lblCode = new DevExpress.XtraEditors.LabelControl();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.txtAttenCode = new DevExpress.XtraEditors.TextEdit();
            this.lblAttenCode = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.lblName = new DevExpress.XtraEditors.LabelControl();
            this.txtPhoneNum = new DevExpress.XtraEditors.TextEdit();
            this.lblPhoneNum = new DevExpress.XtraEditors.LabelControl();
            this.lblEntryDate = new DevExpress.XtraEditors.LabelControl();
            this.dtEntryDate = new DevExpress.XtraEditors.DateEdit();
            this.deLeaveDate = new DevExpress.XtraEditors.DateEdit();
            this.lblLeaveDate = new DevExpress.XtraEditors.LabelControl();
            this.btnCancle = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAttenCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEntryDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEntryDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deLeaveDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deLeaveDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(12, 29);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(52, 13);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "员工编码:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(70, 26);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(162, 20);
            this.txtCode.TabIndex = 1;
            // 
            // txtAttenCode
            // 
            this.txtAttenCode.Location = new System.Drawing.Point(313, 26);
            this.txtAttenCode.Name = "txtAttenCode";
            this.txtAttenCode.Size = new System.Drawing.Size(162, 20);
            this.txtAttenCode.TabIndex = 3;
            // 
            // lblAttenCode
            // 
            this.lblAttenCode.Location = new System.Drawing.Point(255, 29);
            this.lblAttenCode.Name = "lblAttenCode";
            this.lblAttenCode.Size = new System.Drawing.Size(52, 13);
            this.lblAttenCode.TabIndex = 2;
            this.lblAttenCode.Text = "考勤代码:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(70, 66);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(162, 20);
            this.txtName.TabIndex = 5;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(12, 69);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "员工姓名:";
            // 
            // txtPhoneNum
            // 
            this.txtPhoneNum.Location = new System.Drawing.Point(313, 66);
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.Size = new System.Drawing.Size(162, 20);
            this.txtPhoneNum.TabIndex = 7;
            // 
            // lblPhoneNum
            // 
            this.lblPhoneNum.Location = new System.Drawing.Point(255, 69);
            this.lblPhoneNum.Name = "lblPhoneNum";
            this.lblPhoneNum.Size = new System.Drawing.Size(52, 13);
            this.lblPhoneNum.TabIndex = 6;
            this.lblPhoneNum.Text = "员工电话:";
            // 
            // lblEntryDate
            // 
            this.lblEntryDate.Location = new System.Drawing.Point(12, 103);
            this.lblEntryDate.Name = "lblEntryDate";
            this.lblEntryDate.Size = new System.Drawing.Size(52, 13);
            this.lblEntryDate.TabIndex = 8;
            this.lblEntryDate.Text = "入职日期:";
            // 
            // dtEntryDate
            // 
            this.dtEntryDate.EditValue = null;
            this.dtEntryDate.Location = new System.Drawing.Point(70, 100);
            this.dtEntryDate.Name = "dtEntryDate";
            this.dtEntryDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEntryDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEntryDate.Size = new System.Drawing.Size(162, 20);
            this.dtEntryDate.TabIndex = 10;
            // 
            // deLeaveDate
            // 
            this.deLeaveDate.EditValue = null;
            this.deLeaveDate.Location = new System.Drawing.Point(313, 100);
            this.deLeaveDate.Name = "deLeaveDate";
            this.deLeaveDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deLeaveDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deLeaveDate.Size = new System.Drawing.Size(162, 20);
            this.deLeaveDate.TabIndex = 12;
            // 
            // lblLeaveDate
            // 
            this.lblLeaveDate.Location = new System.Drawing.Point(255, 103);
            this.lblLeaveDate.Name = "lblLeaveDate";
            this.lblLeaveDate.Size = new System.Drawing.Size(52, 13);
            this.lblLeaveDate.TabIndex = 11;
            this.lblLeaveDate.Text = "离职日期:";
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(400, 132);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 13;
            this.btnCancle.Text = "取    消";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(313, 132);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "确    定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // EmployeeEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 167);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.deLeaveDate);
            this.Controls.Add(this.lblLeaveDate);
            this.Controls.Add(this.dtEntryDate);
            this.Controls.Add(this.lblEntryDate);
            this.Controls.Add(this.txtPhoneNum);
            this.Controls.Add(this.lblPhoneNum);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtAttenCode);
            this.Controls.Add(this.lblAttenCode);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblCode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeEditForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAttenCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEntryDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEntryDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deLeaveDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deLeaveDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblCode;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.TextEdit txtAttenCode;
        private DevExpress.XtraEditors.LabelControl lblAttenCode;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl lblName;
        private DevExpress.XtraEditors.TextEdit txtPhoneNum;
        private DevExpress.XtraEditors.LabelControl lblPhoneNum;
        private DevExpress.XtraEditors.LabelControl lblEntryDate;
        private DevExpress.XtraEditors.DateEdit dtEntryDate;
        private DevExpress.XtraEditors.DateEdit deLeaveDate;
        private DevExpress.XtraEditors.LabelControl lblLeaveDate;
        private DevExpress.XtraEditors.SimpleButton btnCancle;
        private DevExpress.XtraEditors.SimpleButton btnOk;
    }
}
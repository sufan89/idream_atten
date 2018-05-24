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
            this.gridAttenDate = new DevExpress.XtraGrid.GridControl();
            this.gvAttenDate = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colmonday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltuesday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colwednesday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colthursday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfriday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsaturday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsunday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnGetAttenDate = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.seYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAttenType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttenDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttenDate)).BeginInit();
            this.SuspendLayout();
            // 
            // lblYear
            // 
            this.lblYear.Location = new System.Drawing.Point(12, 21);
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
            this.seYear.Location = new System.Drawing.Point(70, 18);
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
            this.lblMonth.Location = new System.Drawing.Point(188, 21);
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
            this.btnCancle.Location = new System.Drawing.Point(745, 439);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 7;
            this.btnCancle.Text = "关    闭";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(658, 439);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "保    存";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cbMonth
            // 
            this.cbMonth.Location = new System.Drawing.Point(246, 18);
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
            this.cbAttenType.SelectedIndexChanged += new System.EventHandler(this.cbAttenType_SelectedIndexChanged);
            // 
            // gridAttenDate
            // 
            this.gridAttenDate.Location = new System.Drawing.Point(12, 44);
            this.gridAttenDate.MainView = this.gvAttenDate;
            this.gridAttenDate.Name = "gridAttenDate";
            this.gridAttenDate.Size = new System.Drawing.Size(803, 235);
            this.gridAttenDate.TabIndex = 11;
            this.gridAttenDate.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAttenDate});
            // 
            // gvAttenDate
            // 
            this.gvAttenDate.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colmonday,
            this.coltuesday,
            this.colwednesday,
            this.colthursday,
            this.colfriday,
            this.colsaturday,
            this.colsunday});
            this.gvAttenDate.GridControl = this.gridAttenDate;
            this.gvAttenDate.Name = "gvAttenDate";
            this.gvAttenDate.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvAttenDate.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvAttenDate.OptionsBehavior.Editable = false;
            this.gvAttenDate.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gvAttenDate.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvAttenDate_RowCellClick);
            // 
            // colmonday
            // 
            this.colmonday.Caption = "星期一";
            this.colmonday.FieldName = "colmonday";
            this.colmonday.Name = "colmonday";
            this.colmonday.Visible = true;
            this.colmonday.VisibleIndex = 0;
            // 
            // coltuesday
            // 
            this.coltuesday.Caption = "星期二";
            this.coltuesday.FieldName = "coltuesday";
            this.coltuesday.Name = "coltuesday";
            this.coltuesday.Visible = true;
            this.coltuesday.VisibleIndex = 1;
            // 
            // colwednesday
            // 
            this.colwednesday.Caption = "星期三";
            this.colwednesday.FieldName = "colwednesday";
            this.colwednesday.Name = "colwednesday";
            this.colwednesday.Visible = true;
            this.colwednesday.VisibleIndex = 2;
            // 
            // colthursday
            // 
            this.colthursday.Caption = "星期四";
            this.colthursday.FieldName = "colthursday";
            this.colthursday.Name = "colthursday";
            this.colthursday.Visible = true;
            this.colthursday.VisibleIndex = 3;
            // 
            // colfriday
            // 
            this.colfriday.Caption = "星期五";
            this.colfriday.FieldName = "colfriday";
            this.colfriday.Name = "colfriday";
            this.colfriday.Visible = true;
            this.colfriday.VisibleIndex = 4;
            // 
            // colsaturday
            // 
            this.colsaturday.Caption = "星期六";
            this.colsaturday.FieldName = "colsaturday";
            this.colsaturday.Name = "colsaturday";
            this.colsaturday.Visible = true;
            this.colsaturday.VisibleIndex = 5;
            // 
            // colsunday
            // 
            this.colsunday.Caption = "星期日";
            this.colsunday.FieldName = "colsunday";
            this.colsunday.Name = "colsunday";
            this.colsunday.Visible = true;
            this.colsunday.VisibleIndex = 6;
            // 
            // btnGetAttenDate
            // 
            this.btnGetAttenDate.Location = new System.Drawing.Point(368, 17);
            this.btnGetAttenDate.Name = "btnGetAttenDate";
            this.btnGetAttenDate.Size = new System.Drawing.Size(92, 23);
            this.btnGetAttenDate.TabIndex = 12;
            this.btnGetAttenDate.Text = "生成考勤日期";
            this.btnGetAttenDate.Click += new System.EventHandler(this.btnGetAttenDate_Click);
            // 
            // AttenDateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 474);
            this.Controls.Add(this.btnGetAttenDate);
            this.Controls.Add(this.gridAttenDate);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridAttenDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttenDate)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gridAttenDate;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAttenDate;
        private DevExpress.XtraGrid.Columns.GridColumn colmonday;
        private DevExpress.XtraGrid.Columns.GridColumn coltuesday;
        private DevExpress.XtraGrid.Columns.GridColumn colwednesday;
        private DevExpress.XtraGrid.Columns.GridColumn colthursday;
        private DevExpress.XtraGrid.Columns.GridColumn colfriday;
        private DevExpress.XtraGrid.Columns.GridColumn colsaturday;
        private DevExpress.XtraGrid.Columns.GridColumn colsunday;
        private DevExpress.XtraEditors.SimpleButton btnGetAttenDate;
    }
}
namespace Idream_Attendance
{
    partial class MainForm
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnEmpolyeeEntry = new DevExpress.XtraBars.BarButtonItem();
            this.btnEmployeeDimission = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportAtten = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportAtten = new DevExpress.XtraBars.BarButtonItem();
            this.btnSetAttenDate = new DevExpress.XtraBars.BarButtonItem();
            this.btnImportEmployee = new DevExpress.XtraBars.BarButtonItem();
            this.btnOverTime = new DevExpress.XtraBars.BarButtonItem();
            this.btnLeaft = new DevExpress.XtraBars.BarButtonItem();
            this.ribEmployeeManager = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgEmpolyComm = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgBatch = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribAttenManage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgDailyManage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgRuleSet = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgOverTime = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.mainGridControl = new DevExpress.XtraGrid.GridControl();
            this.mainGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnEmpolyeeEntry,
            this.btnEmployeeDimission,
            this.btnImportAtten,
            this.btnExportAtten,
            this.btnSetAttenDate,
            this.btnImportEmployee,
            this.btnOverTime,
            this.btnLeaft});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 9;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribEmployeeManager,
            this.ribAttenManage});
            this.ribbon.Size = new System.Drawing.Size(1158, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnEmpolyeeEntry
            // 
            this.btnEmpolyeeEntry.Caption = "新员工入职";
            this.btnEmpolyeeEntry.Id = 1;
            this.btnEmpolyeeEntry.Name = "btnEmpolyeeEntry";
            this.btnEmpolyeeEntry.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmpolyeeEntry_ItemClick);
            // 
            // btnEmployeeDimission
            // 
            this.btnEmployeeDimission.Caption = "员工信息修改";
            this.btnEmployeeDimission.Id = 2;
            this.btnEmployeeDimission.Name = "btnEmployeeDimission";
            this.btnEmployeeDimission.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmployeeDimission_ItemClick);
            // 
            // btnImportAtten
            // 
            this.btnImportAtten.Caption = "导入打卡记录";
            this.btnImportAtten.Id = 3;
            this.btnImportAtten.Name = "btnImportAtten";
            this.btnImportAtten.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportAtten_ItemClick);
            // 
            // btnExportAtten
            // 
            this.btnExportAtten.Caption = "考勤报表";
            this.btnExportAtten.Id = 4;
            this.btnExportAtten.Name = "btnExportAtten";
            this.btnExportAtten.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportAtten_ItemClick);
            // 
            // btnSetAttenDate
            // 
            this.btnSetAttenDate.Caption = "设定考勤日期";
            this.btnSetAttenDate.Id = 5;
            this.btnSetAttenDate.Name = "btnSetAttenDate";
            this.btnSetAttenDate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSetAttenDate_ItemClick);
            // 
            // btnImportEmployee
            // 
            this.btnImportEmployee.Caption = "员工数据导入";
            this.btnImportEmployee.Id = 6;
            this.btnImportEmployee.Name = "btnImportEmployee";
            this.btnImportEmployee.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportEmployee_ItemClick);
            // 
            // btnOverTime
            // 
            this.btnOverTime.Caption = "加班";
            this.btnOverTime.Id = 7;
            this.btnOverTime.Name = "btnOverTime";
            this.btnOverTime.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOverTime_ItemClick);
            // 
            // btnLeaft
            // 
            this.btnLeaft.Caption = "请假";
            this.btnLeaft.Id = 8;
            this.btnLeaft.Name = "btnLeaft";
            this.btnLeaft.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLeaft_ItemClick);
            // 
            // ribEmployeeManager
            // 
            this.ribEmployeeManager.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgEmpolyComm,
            this.rpgBatch});
            this.ribEmployeeManager.Name = "ribEmployeeManager";
            this.ribEmployeeManager.Text = "员工管理";
            // 
            // rpgEmpolyComm
            // 
            this.rpgEmpolyComm.ItemLinks.Add(this.btnEmpolyeeEntry);
            this.rpgEmpolyComm.ItemLinks.Add(this.btnEmployeeDimission);
            this.rpgEmpolyComm.Name = "rpgEmpolyComm";
            this.rpgEmpolyComm.Text = "员工入职离职管理";
            // 
            // rpgBatch
            // 
            this.rpgBatch.ItemLinks.Add(this.btnImportEmployee);
            this.rpgBatch.Name = "rpgBatch";
            this.rpgBatch.Text = "批量操作";
            // 
            // ribAttenManage
            // 
            this.ribAttenManage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgDailyManage,
            this.rpgRuleSet,
            this.rpgOverTime});
            this.ribAttenManage.Name = "ribAttenManage";
            this.ribAttenManage.Text = "员工考勤";
            // 
            // rpgDailyManage
            // 
            this.rpgDailyManage.ItemLinks.Add(this.btnImportAtten);
            this.rpgDailyManage.ItemLinks.Add(this.btnExportAtten);
            this.rpgDailyManage.Name = "rpgDailyManage";
            this.rpgDailyManage.Text = "日常考勤";
            // 
            // rpgRuleSet
            // 
            this.rpgRuleSet.ItemLinks.Add(this.btnSetAttenDate);
            this.rpgRuleSet.Name = "rpgRuleSet";
            this.rpgRuleSet.Text = "考勤规则设置";
            // 
            // rpgOverTime
            // 
            this.rpgOverTime.ItemLinks.Add(this.btnOverTime);
            this.rpgOverTime.ItemLinks.Add(this.btnLeaft);
            this.rpgOverTime.Name = "rpgOverTime";
            this.rpgOverTime.Text = "加班请假";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 650);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1158, 31);
            // 
            // mainGridControl
            // 
            this.mainGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGridControl.Location = new System.Drawing.Point(0, 143);
            this.mainGridControl.MainView = this.mainGridView;
            this.mainGridControl.MenuManager = this.ribbon;
            this.mainGridControl.Name = "mainGridControl";
            this.mainGridControl.Size = new System.Drawing.Size(1158, 507);
            this.mainGridControl.TabIndex = 2;
            this.mainGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.mainGridView});
            this.mainGridControl.DataSourceChanged += new System.EventHandler(this.mainGridControl_DataSourceChanged);
            // 
            // mainGridView
            // 
            this.mainGridView.GridControl = this.mainGridControl;
            this.mainGridView.Name = "mainGridView";
            this.mainGridView.OptionsBehavior.Editable = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 681);
            this.Controls.Add(this.mainGridControl);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "MainForm";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "员工考勤";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribEmployeeManager;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribAttenManage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgDailyManage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgEmpolyComm;
        private DevExpress.XtraBars.BarButtonItem btnEmpolyeeEntry;
        private DevExpress.XtraBars.BarButtonItem btnEmployeeDimission;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgRuleSet;
        private DevExpress.XtraBars.BarButtonItem btnImportAtten;
        private DevExpress.XtraBars.BarButtonItem btnExportAtten;
        private DevExpress.XtraBars.BarButtonItem btnSetAttenDate;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgBatch;
        private DevExpress.XtraBars.BarButtonItem btnImportEmployee;
        private DevExpress.XtraGrid.GridControl mainGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView mainGridView;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgOverTime;
        private DevExpress.XtraBars.BarButtonItem btnOverTime;
        private DevExpress.XtraBars.BarButtonItem btnLeaft;
    }
}
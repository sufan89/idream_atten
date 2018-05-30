using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;

namespace Idream_Attendance
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private DataBaseConfig m_MainDbConfig = Common.DefaultDbConfig();
        private IDbOperator m_MianDbOp=null;
        /// <summary>
        /// 导入员工表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportEmployee_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.xls|*.xls|*.xlsx|*.xlsx";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            string selectFileName = openFileDialog.FileName;
            DataTable pExcleDt = ExcelHelper.GetTableFromFile(selectFileName);
            if (pExcleDt == null)
            {
                XtraMessageBox.Show("读取Excel数据出错！","提示",MessageBoxButtons.OK ,MessageBoxIcon.Error);
                return;
            }
            pExcleDt.TableName = Common.Table_Employe;
            if (m_MianDbOp.ImportDataTable(pExcleDt))
            {
                XtraMessageBox.Show("成功导入员工数据","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            DataTable pEmployeeDt = m_MianDbOp.GetDataTable(Common.Table_Employe);
            Common.CoverTableCaption(pEmployeeDt);
            mainGridControl.DataSource = pEmployeeDt;
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            DbOperatorFactory dbFc = new DbOperatorFactory(m_MainDbConfig);
            m_MianDbOp = dbFc.GetDbOperator();
            if (m_MianDbOp == null)
            {
                XtraMessageBox.Show("获取数据库连接出错！","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Application.Exit();
            }
            Common.T_MetaTable = m_MianDbOp.GetDataTable(Common.Table_ColumnInfo);
            //加载员工表
            DataTable pEmployeDt = m_MianDbOp.GetDataTable(Common.Table_Employe);
            mainGridControl.DataSource = pEmployeDt;
        }

        private void mainGridControl_DataSourceChanged(object sender, EventArgs e)
        {
            GridControl grid = sender as GridControl;
            object ds = grid.DataSource;
            if (ds is DataTable)
            {
                Common.CoverTableCaption(ds as DataTable);
                Common.CoverGridviewCaption(mainGridView, ds as DataTable);
            }
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmpolyeeEntry_ItemClick(object sender, ItemClickEventArgs e)
        {
            EmployeeEditForm editForm = new EmployeeEditForm("新员工入职", m_MianDbOp);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                DataTable pEmployeDt = m_MianDbOp.GetDataTable(Common.Table_Employe);
                Common.CoverTableCaption(pEmployeDt);
                mainGridControl.DataSource = pEmployeDt;
            }
        }
        /// <summary>
        /// 员工信息修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmployeeDimission_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataRow pRow = mainGridView.GetFocusedDataRow();
            if (pRow == null)
            {
                XtraMessageBox.Show("请选择需要修改的员工", "提示", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            Employee UpdateEm = new Employee(pRow, m_MianDbOp);
            EmployeeEditForm editForm = new EmployeeEditForm("员工信息修改", m_MianDbOp, UpdateEm);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                DataTable pEmployeDt = m_MianDbOp.GetDataTable(Common.Table_Employe);
                Common.CoverTableCaption(pEmployeDt);
                mainGridControl.DataSource = pEmployeDt;
            }
        }
        /// <summary>
        /// 导入考勤信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportAtten_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.xls|*.xls|*.xlsx|*.xlsx";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            string selectFileName = openFileDialog.FileName;
            DataTable pExcleDt = ExcelHelper.GetTableFromFile(selectFileName);
            if (pExcleDt == null)
            {
                XtraMessageBox.Show("读取Excel数据出错！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            pExcleDt.TableName = Common.Table_Atten;
            if (m_MianDbOp.ImportDataTable(pExcleDt))
            {
                XtraMessageBox.Show("成功导入考勤数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //DataTable pEmployeeDt = m_MianDbOp.GetDataTable(Common.Table_Atten);
            //mainGridControl.DataSource = pEmployeeDt;
        }
        /// <summary>
        /// 生成考勤日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetAttenDate_ItemClick(object sender, ItemClickEventArgs e)
        {
            AttenDateForm SetAttenDate = new AttenDateForm(m_MianDbOp);
            if (SetAttenDate.ShowDialog() != DialogResult.OK) return;
        }
        /// <summary>
        /// 加班
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOverTime_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataRow pRow = mainGridView.GetFocusedDataRow();
            if (pRow == null)
            {
                XtraMessageBox.Show("请选择需要加班的员工", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Employee SelectEmp = new Employee(pRow, m_MianDbOp);
            FromEmOverTime fromOverT = new FromEmOverTime(SelectEmp);
            if (fromOverT.ShowDialog() != DialogResult.OK) return;
        }
        /// <summary>
        /// 请假
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeaft_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataRow pRow = mainGridView.GetFocusedDataRow();
            if (pRow == null)
            {
                XtraMessageBox.Show("请选择需要请假的员工", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Employee SelectEmp = new Employee(pRow, m_MianDbOp);
            VacationForm vacationForm = new VacationForm(SelectEmp);
            vacationForm.ShowDialog();
        }
        /// <summary>
        /// 生成考勤报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportAtten_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataTable EmployeeDt = null;
            if (mainGridControl.DataSource is DataTable)
            {
                EmployeeDt = mainGridControl.DataSource as DataTable;
            }
            if (EmployeeDt == null || EmployeeDt.Rows.Count == 0)
            {
                XtraMessageBox.Show("员工数据不存在，请先导入员工数据","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            AttenReportFrom attenReportFrom = new AttenReportFrom(EmployeeDt, m_MianDbOp);
            attenReportFrom.ShowDialog();
        }
    }
}
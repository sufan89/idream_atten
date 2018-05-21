using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;


namespace Idream_Attendance
{
    public partial class attendanceForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public attendanceForm()
        {
            InitializeComponent();
        }

    //    private void button2_Click(object sender, EventArgs e)
    //    {
    //        string fileName = "";
    //        fileName = this.textBox2.Text;
    //        if (this.textBox2.Text != "")
    //        {
    //            try
    //            {


    //                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileName + ";" + "Extended Properties=Excel 8.0;";
    //                OleDbConnection conn = new OleDbConnection(strConn);
    //                conn.Open();
    //                string strExcel = "";
    //                OleDbDataAdapter myCommand = null;
    //                System.Data.DataTable schemaTable = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
    //                string tableName = schemaTable.Rows[0][2].ToString().Trim();
    //                strExcel = "select * from ["+ tableName+"]";
    //                strExcel = strExcel.Replace("'", "");
    //                DataSet ds = null; 
    //                myCommand = new OleDbDataAdapter(strExcel, strConn);
    //                ds = new DataSet();
    //                myCommand.Fill(ds);

    //                string sql2 = "delete from Attendance";
    //                DBHelper.ExecuteNonQuery(sql2);
    //                System.Data.DataTable NDT = new System.Data.DataTable();
    //                NDT.Columns.Add("ID");
    //                NDT.Columns.Add("T_Time");
    //                NDT.Columns.Add("S_ID");

    //                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //                {
    //                    DataRow row = NDT.NewRow();
    //                    row[0] = ds.Tables[0].Rows[i][0];
    //                    row[1] = ds.Tables[0].Rows[i][1];
    //                    row[2] = ds.Tables[0].Rows[i][0];
    //                    NDT.Rows.Add(row);
    //                }

    //                bool result= new DBHelper().AddDataTableToDB(NDT);
    //                Get();

    //            }
    //            catch(Exception ex)
    //            {
    //                MessageBox.Show("请选择要导入的EXCEL");

    //            }



    //        }
    //        else
    //        {
    //            MessageBox.Show("请选择Excel文件");
    //        }

    //    }

    //    private void button1_Click(object sender, EventArgs e)
    //    {
    //        OpenFileDialog fileDialog = new OpenFileDialog();
    //        fileDialog.Multiselect = true;
    //        fileDialog.Title = "请选择文件";
    //        fileDialog.Filter = "所有文件(*xls*)|*.xls*"; //设置要选择的文件的类型
    //        if (fileDialog.ShowDialog() == DialogResult.OK)
    //        {
    //            string file = fileDialog.FileName;//返回文件的完整路径  
    //            textBox2.Text = file;
    //        }
    //    }


    //    public void Get() {
    //        string sql = @"
    //       select  ROW_NUMBER()over(order by a.S_ID)　序号,a.S_ID　工号,c.StaffName　姓名,a.M_L　上班异常,b.N_L　下班异常 from (
    //        select count(S_ID)M_L,S_ID from (

    //        select  Min (T_Time)Stime,MAX (T_Time) ETime,S_ID,count(T_Time)Click_Num from  Attendance group by S_ID,convert(varchar(10),T_Time,120) 
    //        )b where Stime>convert(varchar(10),Stime,120)+' 09:01:00'  group by S_ID

    //        )a left join(
    //        select count(ETime)N_L,S_ID from (

    //        select  Min (T_Time)Stime,MAX (T_Time) ETime,S_ID,count(T_Time)Click_Num from  Attendance group by S_ID,convert(varchar(10),T_Time,120) 
    //        )b where etime<convert(varchar(10),etime,120)+' 18:30:00'  group by S_ID 
    //        )b on a.S_ID=b.S_ID
    //        left join staff c on a.S_ID=c.StaffID";

    //        System.Data.DataTable dt = DBHelper.GetDataTable(sql);
    //        dataGridView1.DataSource = dt;
    //    }

    //    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    //    {
    //        //currentcell当前活动单元格 columnindex 当前活动单元格的索引

    //        try
    //        {
    //            int.Parse(dataGridView1.CurrentCell.Value.ToString());

    //            int S_ID = int.Parse(dataGridView1.CurrentCell.Value.ToString());

    //            string sql = @"
    //              select a.StaffName 姓名,convert(varchar(10),b.Stime,120)　日期,
			 //   case when(convert(varchar(17),Stime,120)=convert(varchar(17),eTime,120) and Stime>(convert(varchar(10),Stime,120)+' 18:01:00')) then null else Stime end 上班卡
			 //   ,case when(convert(varchar(17),Stime,120)=convert(varchar(17),eTime,120) and etime<(convert(varchar(10),etime,120)+' 18:01:00')) then null else etime end 下班卡
			 //   ,b.Click_Num　今日打卡次数,case when 
				//Stime>convert(varchar(10),Stime,120)+' 09:01:00' or ETime<convert(varchar(10),etime,120)+' 18:30:00' then '异常'else '正常'end 是否异常
				// from 
				//staff a
    //             left join 
    //            (select  Min (T_Time)Stime,MAX (T_Time) ETime,S_ID,count(S_ID)Click_Num from  Attendance group by S_ID,convert(varchar(10),T_Time,120) )b
    //            on a.StaffID=b.S_ID where id=" + S_ID;

    //            System.Data.DataTable dt = DBHelper.GetDataTable(sql);
    //            dataGridView2.DataSource = dt;
    //        }
    //        catch {
    //            //MessageBox.Show("请点击工号");
    //        }
           
    //    }
    }
}

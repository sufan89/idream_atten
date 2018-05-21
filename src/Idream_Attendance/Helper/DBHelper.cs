using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms; 

namespace Idream_Attendance
{
    public class DBHelper
    {
        //public static string connstr = "server=.;database=SuperKTV;uid=sa;pwd=123456";

        public static string connstr = "server=sufan-pc;database=AttendanceDB;uid=sa;pwd=sufan2008300379";
        //数据库链接对象
        private static SqlConnection Conn = null;

        //初始化数据库链接
        private static void InitConnection()
        {
            //如果连接对象不存在，创建连接
            if (Conn == null)
                Conn = new SqlConnection(connstr);
            //如果连接对象关闭，打开连接
            if (Conn.State == ConnectionState.Closed)
                Conn.Open();
            //如果连接中断，重启连接
            if (Conn.State == ConnectionState.Broken)
            {
                Conn.Close();
                Conn.Open();
            }
        }

        //查询，获取DataReader
        public static SqlDataReader GetDataReader(string sqlStr)
        {
            InitConnection();
            SqlCommand cmd = new SqlCommand(sqlStr, Conn);
            //CommandBehavior.CloseConnection 命令行为：当DataReader对象被关闭时，自动关闭占用的连接对象
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        //查询，获取DataTable
        public static System.Data.DataTable GetDataTable(string sqlStr)
        {
            InitConnection();
            System.Data.DataTable table = new System.Data.DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(sqlStr, Conn);
            dap.Fill(table);
            Conn.Close();
            return table;
        }

        //查询，获取DataSet
        public static DataSet GetDataSet(string sqlStr)
        {
            InitConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(sqlStr, Conn);
            dap.Fill(ds);
            Conn.Close();
            return ds;
        }

        //增改删
        public static bool ExecuteNonQuery(string sqlStr)
        {
            InitConnection();
            SqlCommand cmd = new SqlCommand(sqlStr, Conn);
            int result = cmd.ExecuteNonQuery();
            Conn.Close();
            return result > 0;
        }

        //执行集合函数
        public static object ExecuteScalar(string sqlStr)
        {
            InitConnection();
            SqlCommand cmd = new SqlCommand(sqlStr, Conn);
            object result = cmd.ExecuteScalar();
            Conn.Close();
            return result;
        }

        /// <summary>  
        /// 一次性把DataTable中的数据插入数据库  
        /// <para/>Author : AnDequan  
        /// <para/>Date   : 2011-3-14  
        /// </summary>  
        /// <param name="source">DataTable数据源</param>  
        /// <returns>true - 成功，false - 失败</returns>  
        public bool AddDataTableToDB(DataTable source)
        { 
            SqlTransaction tran = null;//声明一个事务对象  
            try
            {
                using (SqlConnection conn = new SqlConnection(connstr))
                {
                    conn.Open();//打开链接  
                    using (tran = conn.BeginTransaction())
                    {
                        using (SqlBulkCopy copy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran))
                        {
                            copy.DestinationTableName = "AttendanceDB.dbo.[Attendance]";  //指定服务器上目标表的名称  
                            copy.WriteToServer(source);                      //执行把DataTable中的数据写入DB  
                            tran.Commit();                                      //提交事务  
                            return true;                                        //返回True 执行成功！  
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (null != tran)
                    tran.Rollback();
                //LogHelper.Add(ex);  
                return false;//返回False 执行失败！  
            }
        }

    }
}
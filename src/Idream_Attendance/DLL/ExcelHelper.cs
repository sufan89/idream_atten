using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
/*
 * Excel数据处理类
 */
namespace Idream_Attendance
{
   public static class ExcelHelper
    {
   
        /// <summary>
        /// 从文件中获取数据表
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="StrSheetName">表名</param>
        /// <returns></returns>
        public static DataTable GetTableFromFile(string fileName,string StrSheetName="")
        {
            if (!File.Exists(fileName))
            {
                return null;
            }
            try
            {
                string fileType= System.IO.Path.GetExtension(fileName);
                string strConn=string.Format("Provider=Microsoft.Jet.OLEDB.{0}.0;" +
                       "Extended Properties=\"Excel {1}.0;IMEX=1;\";" +
                       "data source={2};",
                       (fileType == ".xls" ? 4 : 12), (fileType == ".xls" ? 8 : 12), fileName);
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                string strExcel = "";
                OleDbDataAdapter myCommand = null;
                DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string tableName = string.Empty;
                if (string.IsNullOrEmpty(StrSheetName))
                {
                    tableName = schemaTable.Rows[0][2].ToString().Trim();
                }
                else
                {
                    foreach (DataRow pRow in schemaTable.Rows)
                    {
                        if (pRow[2].ToString().Trim().ToUpper() == tableName.Trim().ToUpper())
                        {
                            tableName = pRow[2].ToString().Trim();
                        }
                    }
                }
                strExcel = "select * from [" + tableName + "]";
                strExcel = strExcel.Replace("'", "");
                DataSet ds = null;
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                ds = new DataSet();
                myCommand.Fill(ds);
                if (ds.Tables.Count == 0)
                    return null;
                else return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

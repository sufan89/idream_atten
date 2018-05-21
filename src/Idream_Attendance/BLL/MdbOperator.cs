using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace Idream_Attendance
{
    public class MdbOperator : IDbOperator
    {
        public MdbOperator(string ConnectStr)
        {
            m_Connect = new OleDbConnection(ConnectStr);
        }
        private OleDbConnection m_Connect = null;
        public DataTable GetDataTable(string TableName, string StrWhereCase="")
        {
            DataTable pDt = null;
            OleDbCommand command = m_Connect.CreateCommand();
            if (string.IsNullOrEmpty(StrWhereCase))
            {
                command.CommandText = string.Format("select * from {0}", TableName);
            }
            else
            {
                command.CommandText = string.Format("select * from {0} where {1}", TableName, StrWhereCase);
            }
            try
            {
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(command);
                da.Fill(ds);
                if (ds.Tables.Count == 0) return null;
                pDt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
            return pDt;
        }
        public bool ImportDataTable(DataTable importDt)
        {
            string strTbName = importDt.TableName;
            string strCol = string.Empty;
            string strRow = string.Empty;
            IList<string> listColumn = new List<string>();
            foreach (DataColumn co in importDt.Columns)
            {
                if (string.IsNullOrEmpty(strCol)) strCol = string.Format("{0}", co.ColumnName);
                else strCol = string.Format("{0},{1}", strCol, co.ColumnName);
                listColumn.Add(co.ColumnName);
            }
            OleDbCommand cmd = m_Connect.CreateCommand();
            OleDbTransaction trans = null;
            int rowCount = 0;
            try
            {
                if (m_Connect.State != ConnectionState.Open) m_Connect.Open();
                trans = m_Connect.BeginTransaction();
                cmd.Transaction = trans;
                foreach (DataRow pRow in importDt.Rows)
                {
                    foreach (DataColumn co in importDt.Columns)
                    {
                        if (string.IsNullOrEmpty(strRow))
                        {
                            if (co.DataType.ToString() == "System.String" || co.DataType.ToString() == "System.DateTime") strRow = string.Format("'{0}'", pRow[co]);
                            else strRow = string.Format("{0}", pRow[co]);
                        }
                        else
                        {
                            if (co.DataType.ToString() == "System.String" || co.DataType.ToString() == "System.DateTime") strRow = string.Format("{0},'{1}'", strRow, pRow[co]);
                            else strRow = string.Format("{0},{1}", strRow, pRow[co]);
                        }
                    }
                    rowCount++;
                    cmd.CommandText = string.Format("insert into {0} ({1}) values ({2});", strTbName, strCol, strRow);
                    cmd.ExecuteNonQuery();
                    strRow = string.Empty;
                    if (rowCount == 100)
                    {
                        trans.Commit();
                        trans = m_Connect.BeginTransaction();
                        cmd.Transaction = trans;
                        rowCount = 0;
                    }
                }
                if(rowCount!=0)
                trans.Commit();
            }
            catch (Exception ex)
            {
                if(trans!=null)
                trans.Rollback();
            }
            finally
            {
                if (m_Connect.State != ConnectionState.Closed)
                {
                    m_Connect.Close();
                }
            }
            return true;
        }
        public bool IsConnect()
        {
            bool flag = false;
            if (m_Connect == null) return flag;
            try
            {
                m_Connect.Open();
                m_Connect.Close();
                flag = true;
                return flag;
            }
            catch (Exception ex)
            {
                return flag;
            }
        }
        public bool InsertRows(string strTableName, IList<string> ColumnName, IList<object> listRows)
        {
            string strCommand = string.Empty;
            string strCol = string.Empty;
            string strRows = string.Empty;
            for (int i = 0; i < ColumnName.Count; i++)
            {
                if (string.IsNullOrEmpty(strCol)) strCol = ColumnName[i];
                else strCol = string.Format("{0},{1}",strCol,ColumnName[i]);
            }
            for (int j = 0; j < listRows.Count; j++)
            {
                object o = listRows[j];
                string strTemp = string.Empty;
                if (o.GetType().ToString() == "System.String"|| o.GetType().ToString()=="System.DateTime")
                    strTemp = string.Format("'{0}'", o.ToString());
                else strTemp = o.ToString();
                if (string.IsNullOrEmpty(strRows)) strRows = strTemp;
                else strRows = string.Format("{0},{1}", strRows, strTemp);
            }
            OleDbCommand command = m_Connect.CreateCommand();
            command.CommandText = string.Format("insert into {0} ({1}) values ({2})", strTableName, strCol, strRows);
            try
            {
                if (m_Connect.State != ConnectionState.Open) m_Connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (m_Connect.State != ConnectionState.Closed)
                {
                    m_Connect.Close();
                }
            }
            return true;
        }
        public bool IsTableExist(string strTableName)
        {
            DataTable sysDt = GetDataTable("msysobjects", "type=1 and flags=0");
            if (sysDt == null || sysDt.Rows.Count == 0) return false;
            DataRow[] pRows = sysDt.Select(string.Format("Name='{0}'",strTableName));
            if (pRows.Length == 0) return false;
            return true;
        }
        public bool UpDateRows(string strTableName, string idColumn, object idValue, Dictionary<string, object> dicUpdateValues)
        {
            string strCommand = string.Empty;
            string strUpdate = string.Empty;
            foreach (string key in dicUpdateValues.Keys)
            {
                if (string.IsNullOrEmpty(strUpdate))
                {
                    if (dicUpdateValues[key].GetType().ToString() == "System.String" || dicUpdateValues[key].GetType().ToString() == "System.DateTime")
                    {
                        strUpdate = string.Format("{0}='{1}'",key, dicUpdateValues[key]);
                    }
                    else
                    {
                        strUpdate = string.Format("{0}={1}",key, dicUpdateValues[key]);
                    }
                }
                else
                {
                    if (dicUpdateValues[key].GetType().ToString() == "System.String" || dicUpdateValues[key].GetType().ToString() == "System.DateTime")
                    {
                        strUpdate = string.Format("{0},{1}='{2}'", strUpdate,key, dicUpdateValues[key]);
                    }
                    else
                    {
                        strUpdate = string.Format("{0},{1}='{2}'", strUpdate,key, dicUpdateValues[key]);
                    }
                }
            }
            OleDbCommand command = m_Connect.CreateCommand();
            if (idValue.GetType().ToString() == "System.String" || idValue.GetType().ToString() == "System.DateTime")
            {
                command.CommandText = string.Format("update  {0} set {1} where {2}='{3}'", strTableName, strUpdate, idColumn, idValue);
            }
            else
            {
                command.CommandText = string.Format("update  {0} set {1} where {2}={3}", strTableName, strUpdate, idColumn, idValue);
            }
            try
            {
                if (m_Connect.State != ConnectionState.Open) m_Connect.Open();
                command.ExecuteNonQuery();
                m_Connect.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (m_Connect.State != ConnectionState.Closed)
                {
                    m_Connect.Close();
                }
            }
            return true;
        }
    }
}

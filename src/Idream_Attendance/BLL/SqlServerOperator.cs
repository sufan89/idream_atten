using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Idream_Attendance
{
    public class SqlServerOperator : IDbOperator
    {
        public SqlServerOperator(string connectStr)
        {

        }
        public DataTable GetDataTable(string TableName, string StrWhereCase="")
        {
            throw new NotImplementedException();
        }

        public bool ImportDataTable(DataTable importDt)
        {
            throw new NotImplementedException();
        }

        public bool IsConnect()
        {
            throw new NotImplementedException();
        }
        public bool InsertRows(string strTableName, IList<string> ColumnName, IList<object> listRows)
        {
            return false;
        }
        public bool IsTableExist(string strTableName)
        {
            return false;
        }
        public bool UpDateRows(string strTableName, string idColumn, object idValue, Dictionary<string, object> dicUpdateValues)
        {
            return false;
        }
    }
}

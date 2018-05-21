using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Idream_Attendance
{
   public class DbOperatorFactory
    {
        public DbOperatorFactory(DataBaseConfig dbConfig)
        {
            m_MainConfig = dbConfig;
        }
        private DataBaseConfig m_MainConfig = null;
        public IDbOperator GetDbOperator()
        {
            IDbOperator dbOperator = null;
            if (m_MainConfig == null) return null;
            switch (m_MainConfig.m_DbType)
            {
                case DataBaseType.AccessDataBase:
                    dbOperator = new MdbOperator(m_MainConfig.m_DbConnectStr);
                    break;
                case DataBaseType.SqlServer:
                    dbOperator = new SqlServerOperator(m_MainConfig.m_DbConnectStr);
                    break;
            }
            return dbOperator;
        }
    }
}

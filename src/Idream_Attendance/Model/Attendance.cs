using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
/*
 * 考勤类，主要技术员工考勤信息
 * 主要记录分析员工第一次打卡时间与最后一次打卡时间
 */
namespace Idream_Attendance
{
   public class Attendance
    {
        public Attendance(IDbOperator dbOperator)
        {
            m_DbOperator = dbOperator;
        }
        public Attendance(Employee employee, DateTime dt, IDbOperator dbOperator) :this(dbOperator)
        {
            m_Employee = employee;
            m_AttenDate = dt;
            DateTime dtMin = new DateTime(dt.Year, dt.Month, dt.Day,0,0,0);
            DateTime dtMax = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
            DataTable m_attenDt = m_DbOperator.GetDataTable(Common.Table_Atten, string.Format("{0}='{1}'and {2} between #{3}# and #{4}# order by {2} asc",
                Common.Column_AttenCode,employee.Employee_AttenCode,
                Common.Column_AttenDate,dtMin,dtMax,Common.Column_AttenDate));
            if (m_attenDt != null && m_attenDt.Rows.Count != 0)
            {
                int rowCount = m_attenDt.Rows.Count;
                _firstAtten = Convert.ToDateTime(m_attenDt.Rows[0][Common.Column_AttenDate]);
                _lastAtten = Convert.ToDateTime(m_attenDt.Rows[rowCount-1][Common.Column_AttenDate]);
            }
        }
        private IDbOperator m_DbOperator = null;
        private Employee m_Employee = null;
        private DateTime m_AttenDate = DateTime.Now;
        private DateTime _firstAtten = Common.m_NullDate;
        /// <summary>
        /// 员工第一次打卡时间
        /// </summary>
        public DateTime m_FirstAtten
        {
            get { return _firstAtten; }
        }
        private DateTime _lastAtten = Common.m_NullDate;
        /// <summary>
        /// 最后一次打卡时间
        /// </summary>
        public DateTime m_LasteAtten
        {
            get { return _lastAtten; }
        }
        
    }
}

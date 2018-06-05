using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
/*
 * 加班类
 */
namespace Idream_Attendance
{
   public class OverTime
    {
        public OverTime(IDbOperator dbOperator)
        {
            m_Dboperator = dbOperator;
        }
        public OverTime(Employee employee,IDbOperator dbOperator):this(dbOperator)
        {
            m_Employee = employee;
        }
        private IDbOperator m_Dboperator = null;
        private Employee m_Employee =null;
        private DateTime _OTStartTime = Common.m_NullDate;
        /// <summary>
        /// 加班开始时间
        /// </summary>
        public DateTime m_OTStartTime
        {
            get { return _OTStartTime; }
        }
        private DateTime _OTEndtime = Common.m_NullDate;
        /// <summary>
        /// 加班结束时间
        /// </summary>
        public DateTime m_OTEndTime
        {
            get { return _OTEndtime; }
        }
        private double _OTDuration = 0.0;
        /// <summary>
        /// 加班时常
        /// </summary>
        public double m_OTDuration
        {
            get { return _OTDuration; }
        }
        /// <summary>
        /// 是否在加班
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool IsOverTime(DateTime dt)
        {
            bool flag = false;
            DataTable overtimeDt = m_Dboperator.GetDataTable(Common.Table_OverTime, string.Format("{0}<#{1}# and {2}>#{1}# and {3}='{4}'",
                    Common.Column_OverTimeBegin, dt, Common.Column_OverTimeEnd, dt, Common.Column_EmployeCode, m_Employee.Employee_Code));
            if (overtimeDt == null || overtimeDt.Rows.Count == 0) return flag;
            else flag = true;
            _OTStartTime = Convert.ToDateTime(overtimeDt.Rows[0][Common.Column_OverTimeBegin]);
            _OTEndtime = Convert.ToDateTime(overtimeDt.Rows[0][Common.Column_OverTimeEnd]);
            double.TryParse(overtimeDt.Rows[0][Common.Column_VacaDura].ToString(), out _OTDuration);
            return flag;
        }

    }
}

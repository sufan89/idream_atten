using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
/*
 * 假期类
 */
namespace Idream_Attendance
{
    public class Vacation
    {
        public Vacation(IDbOperator dbOperator)
        {
            m_DbOperator = dbOperator;
        }
        public Vacation(Employee employee,IDbOperator dbOperator):this(dbOperator)
        {
            m_Employee = employee;
        }
        private Employee m_Employee = null;
        private IDbOperator m_DbOperator = null;
        private DateTime _VacationStart = Common.m_NullDate;
        /// <summary>
        /// 休假开始时间
        /// </summary>
        public DateTime m_VacationStart
        {
            get { return _VacationStart; }
        }
        private DateTime _VacationEnd = Common.m_NullDate;
        /// <summary>
        /// 休假结束时间
        /// </summary>
        public DateTime m_VacationEnd
        {
            get { return _VacationEnd; }
        }
        private double _VacationDura = 0.0;
        /// <summary>
        /// 休假时长
        /// </summary>
        public double m_VacationDura
        {
            get { return _VacationDura; }
        }
        private VacationType _EmployeeVacationType = VacationType.Goout;
        public VacationType m_EmployeeVacationType
        {
            get { return _EmployeeVacationType; }
        }
        /// <summary>
        /// 判断当前日期员工是否在休假
        /// </summary>
        /// <param name="Dt"></param>
        /// <returns>True:在休假；Flase：不在休假</returns>
        public bool IsVacioning(DateTime Dt)
        {
            bool flag = false;
            DataTable VacationDt = m_DbOperator.GetDataTable(Common.Table_Vacation, string.Format("{0}<#{1}# and {2}>#{1}# and {3}='{4}'",
                Common.Column_VacaBegin, Dt, Common.Column_VacaEnd, Dt,Common.Column_EmployeCode,m_Employee.Employee_Code));
            if (VacationDt == null || VacationDt.Rows.Count == 0) return false;
            else flag = true;
            _VacationStart = Convert.ToDateTime(VacationDt.Rows[0][Common.Column_VacaBegin]);
            _VacationEnd = Convert.ToDateTime(VacationDt.Rows[0][Common.Column_VacaEnd]);
            double.TryParse(VacationDt.Rows[0][Common.Column_VacaDura].ToString(),out _VacationDura);
            int tempInt = 0;
            if (int.TryParse(VacationDt.Rows[0][Common.Column_VacaType].ToString(), out tempInt))
            {
                _EmployeeVacationType = (VacationType)tempInt;
            }
            return flag;
        }
    }
    /// <summary>
    /// 请假类型
    /// </summary>
    public enum VacationType
    {
        /// <summary>
        /// 外出
        /// </summary>
        Goout=0,
        /// <summary>
        /// 调休
        /// </summary>
        DaysOff = 1,
        /// <summary>
        /// 年假
        /// </summary>
        AnnualLeave = 2,
        /// <summary>
        /// 事假
        /// </summary>
        PersonalLeave = 3,
        /// <summary>
        /// 病假
        /// </summary>
        SickLeave = 4,
        /// <summary>
        /// 产假
        /// </summary>
        MaternityLeave = 5,
        /// <summary>
        /// 陪产假
        /// </summary>
        PaternityLeave = 6,
        /// <summary>
        /// 婚假
        /// </summary>
        MarriageLeave = 7,
        /// <summary>
        /// 哺乳假
        /// </summary>
        BreastfeedingLeave = 8,
        /// <summary>
        /// 丧假
        /// </summary>
        FuneralLeave = 9,
    }
}

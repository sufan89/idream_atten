using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Idream_Attendance
{
    public class Employee
    {
        public Employee(DataRow pEmployeRow, IDbOperator pOberator) :this(pOberator)
        {
            if (pEmployeRow != null)
            {
                _Name = pEmployeRow[Common.Column_EmployeName].ToString();
                _PhoneNum = pEmployeRow[Common.Column_PhoneNum].ToString();
                _Code = pEmployeRow[Common.Column_EmployeCode].ToString();
                _AttenCode = pEmployeRow[Common.Column_AttenCode].ToString();
                _EntryDate = Convert.ToDateTime(pEmployeRow[Common.Column_EntryDate]);
                _LeaveDate = Convert.ToDateTime(pEmployeRow[Common.Column_LeaveDate]);
            }
        }
        public Employee(IDbOperator pOberator)
        {
            m_DbOperator = pOberator;
        }

        private IDbOperator m_DbOperator = null;
        #region 员工属性
        private string _Name = string.Empty;
        /// <summary>
        /// 员工名称
        /// </summary>
        public string Employee_Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _PhoneNum = string.Empty;
        /// <summary>
        /// 员工电话
        /// </summary>
        public string Employee_PhoneNum
        {
            get { return _PhoneNum; }
            set { _PhoneNum = value; }
        }
        private string _Code = string.Empty;
        /// <summary>
        /// 员工代码
        /// </summary>
        public string Employee_Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
        private string _AttenCode = string.Empty;
        /// <summary>
        /// 考勤编码
        /// </summary>
        public string Employee_AttenCode
        {
            get { return _AttenCode; }
            set { _AttenCode = value; }
        }
        private DateTime _EntryDate = new DateTime(2018,1,1);
        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime Employ_EntryDate
        {
            get { return _EntryDate; }
            set { _EntryDate = value; }
        }
        private DateTime _LeaveDate = new DateTime(9999,1,1);
        /// <summary>
        /// 离职日期
        /// </summary>
        public DateTime Employ_LeaveDate
        {
            get { return _LeaveDate; }
            set { _LeaveDate = value; }
        }
        #endregion
        #region 成员函数
        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public bool AddEmploye()
        {
            if (m_DbOperator == null) return false;
            IList<string> colList = new List<string>() {
                Common.Column_EmployeCode,
                Common.Column_AttenCode,
                Common.Column_EmployeName,
                Common.Column_PhoneNum,
                Common.Column_EntryDate,
                Common.Column_LeaveDate
            };
            IList<object> rowList = new List<object>()
            {
                _Code,
                _AttenCode,
                _Name,
                _PhoneNum,
                _EntryDate,
                _LeaveDate
            };
            return m_DbOperator.InsertRows(Common.Table_Employe, colList, rowList);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        public bool UpdateEmploye()
        {
            Dictionary<string, object> dicUpdate = new Dictionary<string, object>()
            {
                { Common.Column_AttenCode,_AttenCode },
                { Common.Column_EmployeName,_Name},
                { Common.Column_PhoneNum,_PhoneNum},
                { Common.Column_EntryDate,_EntryDate},
                { Common.Column_LeaveDate,_LeaveDate}
            };
            return m_DbOperator.UpDateRows(Common.Table_Employe, Common.Column_EmployeCode, _Code, dicUpdate);
        }
        /// <summary>
        /// 员工加班
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="duration">时长</param>
        /// <returns></returns>
        public bool OverTime(DateTime startTime, DateTime endTime, double duration)
        {
            bool flag = false;
            if (startTime > endTime)
            {
                return flag;
            }
            return m_DbOperator.InsertRows(Common.Table_OverTime, new List<string>()
            { Common.Column_EmployeCode,Common.Column_OverTimeBegin,Common.Column_OverTimeEnd,Common.Column_OverTimeDura },new List<object>() {
            Employee_Code,startTime,endTime,duration});
        }
        /// <summary>
        /// 员工请假
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="duration"></param>
        /// <param name="vacationType"></param>
        /// <returns></returns>
        public bool EmployeVacation(DateTime startTime, DateTime endTime, double duration, VacationType vacationType)
        {
            bool flag = false;
            if (startTime > endTime)
            {
                return flag;
            }
            return m_DbOperator.InsertRows(Common.Table_Vacation, new List<string>()
            { Common.Column_EmployeCode,Common.Column_VacaBegin,Common.Column_VacaEnd,Common.Column_VacaDura,Common.Column_VacaType }, 
            new List<object>() {Employee_Code,startTime,endTime,duration,(int)vacationType});
        }
        /// <summary>
        /// 员工考勤状态
        /// </summary>
        /// <param name="attenDt">考勤日期</param>
        /// <param name="attendanceType">考勤类型</param>
        /// <returns></returns>
        public string GetAttenDateStatu(DateTime attenDt,AttendanceType attendanceType)
        {
            string StrOnJob = IsOnTheJob(attenDt);
            if (StrOnJob == "已离职" || StrOnJob == "未入职") return string.Empty;
            if (!string.IsNullOrEmpty(StrOnJob)) return StrOnJob;
            Attendance EmployeAtten = new Attendance(this, attenDt, m_DbOperator);
            switch (attendanceType)
            {
                case AttendanceType.NoAmAtten:
                    return GetNoAmAttenString(EmployeAtten, attenDt);
                case AttendanceType.NoAtten:
                    return GetOverTime(EmployeAtten, attenDt);
                case AttendanceType.NoPmAtten:
                    return GetNoPmAttenString(EmployeAtten, attenDt);
                case AttendanceType.NormalAtten:
                    return GetNormalAttrn(EmployeAtten, attenDt);
            }
            return string.Empty;
        }
        /// <summary>
        /// 获取上午不考勤信息,则只计算下午考勤信息
        /// </summary>
        /// <param name="Attendance"></param>
        /// <returns></returns>
        private string GetNoAmAttenString(Attendance Attendance, DateTime attenDt)
        {
            DateTime dt = new DateTime(attenDt.Year, attenDt.Month, attenDt.Day, 18, 30, 0);
            DateTime dtNoon = new DateTime(attenDt.Year, attenDt.Month, attenDt.Day, 13, 30, 0);
            if (Attendance.m_LasteAtten == Common.m_NullDate)//下午没有考勤记录，则判断是否请假或者外出
            {
                Vacation EmployeVaca = new Vacation(this,m_DbOperator);
                if (EmployeVaca.IsVacioning(dt))
                {
                    return EmployeVaca.GetVacationTypeString();
                }
                else
                {
                    return "下午未打卡";
                }
            }
            if (Attendance.m_LasteAtten < dt && Attendance.m_LasteAtten > dtNoon)
            {
                return "早退";
            }
            else if (Attendance.m_LasteAtten >= dt)
            {
                return string.Empty;
            }
            else
            {
                return "下午未打卡";
            }
        }
        /// <summary>
        /// 获取下午不考勤信息，只计算上午考勤状态
        /// </summary>
        /// <param name="Attendance">考勤类</param>
        /// <param name="attenDt">考勤日期</param>
        /// <returns></returns>
        private string GetNoPmAttenString(Attendance attendance, DateTime attenDt)
        {
            DateTime dtAm = new DateTime(attenDt.Year, attenDt.Month, attenDt.Day, 9, 0, 0);
            DateTime dtPm = new DateTime(attenDt.Year, attenDt.Month, attenDt.Day, 18, 30, 0);
            DateTime dtNoon = new DateTime(attenDt.Year, attenDt.Month, attenDt.Day, 12, 00, 0);
            if (attendance.m_FirstAtten == Common.m_NullDate)//上午没有考勤记录，则判断是否请假或者外出
            {
                Vacation EmployeVaca = new Vacation(this, m_DbOperator);
                if (EmployeVaca.IsVacioning(dtAm))
                {
                    return EmployeVaca.GetVacationTypeString();
                }
                else
                {
                    return "上午未打卡";
                }
            }
            else if (attendance.m_FirstAtten > dtNoon)//第一次打卡时间在12：00之后，则是未打卡
            {
                return "上午未打卡";
            }
            else if (attendance.m_FirstAtten > dtAm && attendance.m_FirstAtten < dtNoon)//打卡时间晚于9：00，则判断前一天最后打卡时间是否是22：00以后
            {
                DateTime dtLastDt = Common.GetLastDateTime(attenDt);
                Attendance lastAtten = new Attendance(this, dtLastDt, m_DbOperator);
                if (lastAtten.m_LasteAtten != Common.m_NullDate)
                {
                    DateTime dtTemp = new DateTime(lastAtten.m_LasteAtten.Year, lastAtten.m_LasteAtten.Month, lastAtten.m_LasteAtten.Day, 22, 0, 0);
                    if (lastAtten.m_LasteAtten >= dtTemp)//前一点的最后一次打卡是22：00以后
                    {
                        return string.Empty;
                    }
                    else
                    {
                        TimeSpan lateTs = attendance.m_FirstAtten.Subtract(dtAm);
                        if (lateTs.Hours != 0)
                        {
                            return string.Format("迟到{0}分", (lateTs.Hours*60)+ lateTs.Minutes);
                        }
                        else
                        {
                            return string.Format("迟到{0}分", lateTs.Minutes);
                        }
                    }
                }
                else //前一天无最后一次打卡记录，则直接判定迟到并计算迟到的分钟数
                {
                    TimeSpan lateTs = attendance.m_FirstAtten.Subtract(dtAm);
                    if (lateTs.Hours != 0)
                    {
                        return string.Format("迟到{0}分", (lateTs.Hours * 60) + lateTs.Minutes);
                    }
                    else
                    {
                        return string.Format("迟到{0}分", lateTs.Minutes);
                    }
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// 正常考勤流程
        /// </summary>
        /// <param name="attendance"></param>
        /// <param name="attenDt"></param>
        /// <returns></returns>
        private string GetNormalAttrn(Attendance attendance, DateTime attenDt)
        {
            //计算上午考勤状态
            string tempAm = GetNoPmAttenString(attendance, attenDt);
            //计算下午考勤状态
            string tempPm = GetNoAmAttenString(attendance, attenDt);
            if (tempAm == tempPm&&!string.IsNullOrEmpty(tempAm)) return tempAm;
            if (string.IsNullOrEmpty(tempAm) && string.IsNullOrEmpty(tempPm)) return string.Empty;
            if (!string.IsNullOrEmpty(tempAm) && !string.IsNullOrEmpty(tempPm))
            {
                if(tempAm== "上午未打卡"&& tempPm == "下午未打卡")return "矿工";
                if (tempAm == tempPm)
                {
                    return string.Format("{0}H", tempAm);
                }
                return string.Format("{0}+{1}", tempAm, tempPm);
            }
            else if (string.IsNullOrEmpty(tempAm) && !string.IsNullOrEmpty(tempPm)) return tempPm;
            else if(!string.IsNullOrEmpty(tempAm) && string.IsNullOrEmpty(tempPm))return tempAm;
            return string.Empty;
        }
        /// <summary>
        /// 是否在职
        /// </summary>
        /// <param name="AttenDt"></param>
        /// <returns></returns>
        private string IsOnTheJob(DateTime AttenDt)
        {
            
            DateTime tempDate = new DateTime(AttenDt.Year, AttenDt.Month, AttenDt.Day, 0, 0, 0);
            DateTime tempEntryDate = new DateTime(_EntryDate.Year, _EntryDate.Month, _EntryDate.Day, 0, 0, 0);
            DateTime tempLeaveDate = new DateTime(_LeaveDate.Year, _LeaveDate.Month, _LeaveDate.Day, 0, 0, 0);
            if (tempDate == tempEntryDate) return string.Format("{0}入职",tempDate.ToShortDateString());
            if (tempDate == tempLeaveDate) return string.Format("{0}离职", tempDate.ToShortDateString());
            if (tempDate > tempLeaveDate) return "已离职";
            if (tempDate < tempEntryDate) return "未入职";
            return string.Empty;
        }
        /// <summary>
        /// 是否加班,主要用于非工作日
        /// </summary>
        /// <param name="attenDt">考勤日期</param>
        /// <param name="attendance">考勤对象</param>
        /// <returns>这里只返回计算的加班时长，有异常的情况均不处理。即如果出现未打卡的情况，则返回空串</returns>
        private string GetOverTime(Attendance attendance, DateTime attenDt)
        {
            OverTime ovt = new OverTime(this, m_DbOperator);
            if (ovt.IsOverTime(attenDt))//有加班申请，则计算加班时长
            {
                //没有打卡时间
                if (attendance.m_FirstAtten == Common.m_NullDate || attendance.m_LasteAtten == Common.m_NullDate) return string.Empty;
                DateTime AmDt = new DateTime(attenDt.Year, attenDt.Month, attenDt.Day, 9, 0, 0);
                DateTime NoonDt = new DateTime(attenDt.Year, attenDt.Month, attenDt.Day, 12, 0, 0);
                DateTime AfNoonDt= new DateTime(attenDt.Year, attenDt.Month, attenDt.Day, 13, 30, 0);
                int OtDuran = 0;
                //计算上午加班时间
                if (attendance.m_FirstAtten <= NoonDt)
                {
                    TimeSpan ts = NoonDt.Subtract(attendance.m_FirstAtten);
                    OtDuran += ts.Hours;
                }
                //计算下午加班时间
                if (attendance.m_FirstAtten >= AfNoonDt)
                {
                    TimeSpan ts = attendance.m_LasteAtten.Subtract(AfNoonDt);
                    OtDuran += ts.Hours;
                }
                if (OtDuran != 0)
                {
                    if (OtDuran >= 8)
                    {
                        return string.Format("加班8H");
                    }
                    else
                    {
                        return string.Format("加班{0}H", OtDuran);
                    }
                    
                }
                else
                {
                    return string.Empty;
                }

            }
            else
            {
                return string.Empty;
            }
        }
        #endregion
    }

}

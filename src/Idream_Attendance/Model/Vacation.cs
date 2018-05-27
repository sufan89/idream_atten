using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * 假期类
 */
namespace Idream_Attendance
{
    public class Vacation
    {
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

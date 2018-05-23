﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * 考勤日期类，记录哪些日期是正常考勤，哪些日期是不需要考勤，哪些日期是上午不考勤，哪些日期是下午不考勤
*/
namespace Idream_Attendance
{
    public class AttendanceDate
    {
        public AttendanceDate()
        {

        }
    }
    /// <summary>
    /// 考勤类型
    /// </summary>
    public enum AttendanceType
    {
        NormalAtten=0,//正常考勤
        NoAtten=1,//不考勤
        NoAmAtten=2,//上午不考勤
        NoPmAtten=3//下午不考勤
    }
}

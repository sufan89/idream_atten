using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Idream_Attendance
{
    public class Entity
    {

    }

    public class Attendance
    {
        private int iD;
        private DateTime t_Time;
        private int s_ID;

        public int ID { get => iD; set => iD = value; }
        public DateTime T_Time { get => t_Time; set => t_Time = value; }
        public int S_ID { get => s_ID; set => s_ID = value; }
    }

    public class Staff
    {
        private int iD;

        private int staffID;
        private string staffName;

        public int ID { get => iD; set => iD = value; }
        public int StaffID { get => staffID; set => staffID = value; }
        public string StaffName { get => staffName; set => staffName = value; }
    }
}

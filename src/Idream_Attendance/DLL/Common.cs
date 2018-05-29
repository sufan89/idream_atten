using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;

namespace Idream_Attendance
{
   public static class Common
    {
        public static DataBaseConfig DefaultDbConfig()
        {
            return new DataBaseConfig(DataBaseType.AccessDataBase, string.Format("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = {0}//DbFile//idream.mdb", Application.StartupPath));
        }
        #region TableName
        /// <summary>
        /// 员工表
        /// </summary>
        public const string Table_Employe = "t_employe";
        /// <summary>
        /// 考勤表
        /// </summary>
        public const string Table_Atten = "t_attendance";
        /// <summary>
        /// 元数据表
        /// </summary>
        public const string Table_ColumnInfo = "t_columninfo";
        /// <summary>
        /// 考勤日期表
        /// </summary>
        public const string Table_AttenDate= "t_attendancedate";
        /// <summary>
        /// 加班日期表
        /// </summary>
        public const string Table_OverTime= "t_overtime";
        /// <summary>
        /// 请假表
        /// </summary>
        public const string Table_Vacation= "t_vacation";
        /// <summary>
        /// 考勤报表
        /// </summary>
        public const string Table_AttenReport = "t_attenreport";
        #endregion
        #region ColumnName
        public const string Column_EmployeCode = "code";
        public const string Column_AttenCode = "attencode";
        public const string Column_PhoneNum = "phonenum";
        public const string Column_EmployeName = "name";
        public const string Column_AttenDate = "attendate";
        public const string Column_Key = "key";
        public const string Column_Value = "value";
        public const string Column_EntryDate = "entrydate";
        public const string Column_LeaveDate = "leavedate";
        public const string Column_AttendanceDate= "attendancedate";
        public const string Column_AttenType= "attendancetype";
        public const string Column_OverTimeBegin= "overtimebegin";
        public const string Column_OverTimeEnd = "overtimeend";
        public const string Column_OverTimeDura = "overtimeduration";
        public const string Column_VacaBegin = "vacationbegin";
        public const string Column_VacaEnd = "vacationend";
        public const string Column_VacaDura = "vacationduration";
        public const string Column_VacaType = "durationtype";
        #endregion
        #region View
        public const string View_EmployeeAtten = "v_empatten";
        #endregion
        /// <summary>
        /// a jok
        /// </summary>
        public static DateTime m_NullDate = new DateTime(1989, 01, 06, 12, 54, 59);
        public static DataTable T_MetaTable = null;
        /// <summary> 
        /// 改变表列标题 
        /// </summary>
        /// <param name="dt"></param>
        public static void CoverTableCaption(DataTable dt)
        {
            if (dt == null) return;
            if (T_MetaTable == null || T_MetaTable.Rows.Count == 0) return;
            foreach (DataColumn dc in dt.Columns)
            {
                string colName = dc.ColumnName;
                DataRow[] pRows = T_MetaTable.Select(string.Format("{0}='{1}'", Column_Key, colName));
                if (pRows.Length > 0)
                {
                    dc.Caption = pRows[0][Column_Value].ToString();
                }
            }
        }
        /// <summary>
        /// 根据表生成视图列
        /// </summary>
        /// <param name="dv"></param>
        /// <param name="dt"></param>
        public static void CoverGridviewCaption(GridView dv,DataTable dt)
        {
            if (dv == null) return;
            if (dt == null) return;
            if (dv.Columns.Count >= 0) dv.Columns.Clear();
            foreach (DataColumn col in dt.Columns)
            {
                GridColumn gc = new GridColumn();
                gc.Name = col.ColumnName;
                gc.Caption = col.Caption;
                gc.FieldName = col.ColumnName;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    gc.DisplayFormat.FormatString = "F";
                    gc.DisplayFormat.FormatType = FormatType.DateTime;
                }
                if (col.ColumnName.ToLower() == "id")
                {
                    gc.Visible = false;
                }
                else
                {
                    gc.Visible = true;
                }
                dv.Columns.Add(gc);
            }
        }
        /// <summary>
        /// 获取指定日期的前一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetLastDateTime(DateTime date)
        {
            int dMonth = date.Month;
            int dDay = date.Day;
            //如果是元旦，则返回去年的12月31日
            if (dMonth == 1 && dDay == 1)
            {
                return new DateTime(date.Year - 1, 12, 31);
            }
            
        }
    }
    public class DataBaseConfig
    {
        public DataBaseConfig(DataBaseType dataBaseType, string ConnectStr)
        {
            _DbType = dataBaseType;
            _DbConnectStr = ConnectStr;
        }
       
        private DataBaseType _DbType = DataBaseType.AccessDataBase;
        public DataBaseType m_DbType
        {
            get { return _DbType; }
        }
        private string _DbConnectStr = string.Empty;
        public string m_DbConnectStr
        {
            get { return _DbConnectStr; }
        }
    }
    public enum DataBaseType
    {
        AccessDataBase=1,
        SqlServer=2
    }
}

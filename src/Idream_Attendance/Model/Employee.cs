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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
/*
 * 数据库操作接口
 */
namespace Idream_Attendance
{
    public interface IDbOperator
    {
        /// <summary>
        /// 导入表
        /// </summary>
        /// <param name="importDt"></param>
        /// <returns></returns>
        bool ImportDataTable(DataTable importDt);
        /// <summary>
        /// 获取表
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="StrWhereCase"></param>
        /// <returns></returns>
        DataTable GetDataTable(string TableName,string StrWhereCase="");
        /// <summary>
        /// 判断是否连接
        /// </summary>
        /// <returns></returns>
        bool IsConnect();
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="pRow"></param>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        bool InsertRows(string strTableName,IList<string>ColumnName,IList<object> listRows);
        /// <summary>
        /// 判断表是否存在
        /// </summary>
        /// <param name="strTableName"></param>
        /// <returns></returns>
        bool IsTableExist(string strTableName);
        /// <summary>
        /// 数据更新
        /// </summary>
        /// <param name="strTableName"></param>
        /// <param name="idColumn"></param>
        /// <param name="idValue"></param>
        /// <param name="dicUpdateValues"></param>
        /// <returns></returns>
        bool UpDateRows(string strTableName, string idColumn, object idValue, Dictionary<string,object> dicUpdateValues);
        /// <summary>
        /// 数据删除
        /// </summary>
        /// <param name="strTableName"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        bool DelData(string strTableName, string strWhere = "");
    }
}

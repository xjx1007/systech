using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Static_logs。
    /// </summary>
    public class KNet_Static_logs
    {
        public KNet_Static_logs()
        { }
        #region  成员方法
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Static_logs model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@StaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@logIP", SqlDbType.NVarChar,30),
					new SqlParameter("@logContent", SqlDbType.NVarChar,250)};
           
            parameters[0].Value = model.StaffNo;
            parameters[1].Value = model.logIP;
            parameters[2].Value = model.logContent;

            DbHelperSQL.RunProcedure("Proc_KNet_Static_logs_ADD", parameters, out rowsAffected);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,StaffNo,Logtime,logIP,logContent ");
            strSql.Append(" FROM KNet_Static_logs ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by  Logtime desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  成员方法
    }
}


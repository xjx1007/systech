using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sys_CheckMethod。
    /// </summary>
    public class KNet_Sys_CheckMethod
    {
        public KNet_Sys_CheckMethod()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CheckName)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@CheckName", SqlDbType.NVarChar,50)};
            parameters[0].Value = CheckName;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sys_CheckMethod_Exists", parameters, out rowsAffected);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sys_CheckMethod model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@CheckNo", SqlDbType.NVarChar,50),
					new SqlParameter("@CheckName", SqlDbType.NVarChar,50),
					new SqlParameter("@CheckPai", SqlDbType.Int,4)};
            parameters[0].Value = model.CheckNo;
            parameters[1].Value = model.CheckName;
            parameters[2].Value = model.CheckPai;

            DbHelperSQL.RunProcedure("Proc_KNet_Sys_CheckMethod_ADD", parameters, out rowsAffected);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sys_CheckMethod model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@CheckName", SqlDbType.NVarChar,50),
					new SqlParameter("@CheckPai", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.CheckName;
            parameters[2].Value = model.CheckPai;

            DbHelperSQL.RunProcedure("Proc_KNet_Sys_CheckMethod_Update", parameters, out rowsAffected);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,CheckNo,CheckName,CheckPai ");
            strSql.Append(" FROM KNet_Sys_CheckMethod ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by CheckPai desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  成员方法
    }
}


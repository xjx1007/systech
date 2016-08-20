using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sys_ProcureType。
    /// </summary>
    public class KNet_Sys_ProcureType
    {
        public KNet_Sys_ProcureType()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ProcureTypeName)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ProcureTypeName", SqlDbType.NVarChar,50)};
            parameters[0].Value = ProcureTypeName;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sys_ProcureType_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.KNet_Sys_ProcureType model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ProcureTypeValue", SqlDbType.NVarChar,50),
					new SqlParameter("@ProcureTypeName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProcureTypePai", SqlDbType.Int,4)};
     
            parameters[0].Value = model.ProcureTypeValue;
            parameters[1].Value = model.ProcureTypeName;
            parameters[2].Value = model.ProcureTypePai;

            DbHelperSQL.RunProcedure("Proc_KNet_Sys_ProcureType_ADD", parameters, out rowsAffected);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sys_ProcureType model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),

					new SqlParameter("@ProcureTypeName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProcureTypePai", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
   
            parameters[1].Value = model.ProcureTypeName;
            parameters[2].Value = model.ProcureTypePai;

            DbHelperSQL.RunProcedure("Proc_KNet_Sys_ProcureType_Update", parameters, out rowsAffected);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            DbHelperSQL.RunProcedure("Proc_KNet_Sys_ProcureType_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ProcureTypeValue,ProcureTypeName,ProcureTypePai ");
            strSql.Append(" FROM KNet_Sys_ProcureType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by  ProcureTypePai desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sys_ProcurePack。
    /// </summary>
    public class KNet_Sys_ProcurePack
    {
        public KNet_Sys_ProcurePack()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PackName)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@PackName", SqlDbType.NVarChar,50)};
            parameters[0].Value = PackName;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sys_ProcurePack_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.KNet_Sys_ProcurePack model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					
					new SqlParameter("@PackValue", SqlDbType.NVarChar,50),
					new SqlParameter("@PackName", SqlDbType.NVarChar,50),
					new SqlParameter("@PackPai", SqlDbType.Int,4)};
           
            parameters[0].Value = model.PackValue;
            parameters[1].Value = model.PackName;
            parameters[2].Value = model.PackPai;

            DbHelperSQL.RunProcedure("Proc_KNet_Sys_ProcurePack_ADD", parameters, out rowsAffected);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sys_ProcurePack model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					
					new SqlParameter("@PackName", SqlDbType.NVarChar,50),
					new SqlParameter("@PackPai", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
           
            parameters[1].Value = model.PackName;
            parameters[2].Value = model.PackPai;

            DbHelperSQL.RunProcedure("Proc_KNet_Sys_ProcurePack_Update", parameters, out rowsAffected);
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

            DbHelperSQL.RunProcedure("Proc_KNet_Sys_ProcurePack_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,PackValue,PackName,PackPai ");
            strSql.Append(" FROM KNet_Sys_ProcurePack ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by PackPai desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  成员方法
    }
}


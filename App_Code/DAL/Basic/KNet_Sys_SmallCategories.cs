using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sys_SmallCategories。
    /// </summary>
    public class KNet_Sys_SmallCategories
    {
        public KNet_Sys_SmallCategories()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CateName, string BigNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
                    new SqlParameter("@CateName", SqlDbType.NVarChar,50),
					new SqlParameter("@BigNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = CateName;
            parameters[1].Value = BigNo;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sys_SmallCategories_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.KNet_Sys_SmallCategories model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@SmallNo", SqlDbType.NVarChar,50),
					new SqlParameter("@BigNo", SqlDbType.NVarChar,50),
					new SqlParameter("@CateName", SqlDbType.NVarChar,50),
					new SqlParameter("@CatePai", SqlDbType.Int,4)};
            parameters[0].Value = model.SmallNo;
            parameters[1].Value = model.BigNo;
            parameters[2].Value = model.CateName;
            parameters[3].Value = model.CatePai;

            DbHelperSQL.RunProcedure("Proc_KNet_Sys_SmallCategories_ADD", parameters, out rowsAffected);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sys_SmallCategories model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@BigNo", SqlDbType.NVarChar,50),
					new SqlParameter("@CateName", SqlDbType.NVarChar,50),
					new SqlParameter("@CatePai", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BigNo;
            parameters[2].Value = model.CateName;
            parameters[3].Value = model.CatePai;

            DbHelperSQL.RunProcedure("Proc_KNet_Sys_SmallCategories_Update", parameters, out rowsAffected);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,SmallNo,BigNo,CateName,CatePai ");
            strSql.Append(" FROM KNet_Sys_SmallCategories ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by CatePai desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  成员方法
    }
}


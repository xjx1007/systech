using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sys_AuthorityUserGroup。
    /// </summary>
    public class KNet_Sys_AuthorityUserGroup
    {
        public KNet_Sys_AuthorityUserGroup()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string GroupName)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@GroupName", SqlDbType.NVarChar,50)};
            parameters[0].Value = GroupName;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sys_AuthorityUserGroup_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.KNet_Sys_AuthorityUserGroup model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					
					new SqlParameter("@GroupValue", SqlDbType.NVarChar,50),
					new SqlParameter("@GroupName", SqlDbType.NVarChar,50),
					new SqlParameter("@GroupPai", SqlDbType.Int,4)};
           
            parameters[0].Value = model.GroupValue;
            parameters[1].Value = model.GroupName;
            parameters[2].Value = model.GroupPai;

            DbHelperSQL.RunProcedure("Proc_KNet_Sys_AuthorityUserGroup_ADD", parameters, out rowsAffected);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sys_AuthorityUserGroup model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@GroupValue", SqlDbType.NVarChar,50),
					
					new SqlParameter("@GroupName", SqlDbType.NVarChar,50),
					new SqlParameter("@GroupPai", SqlDbType.Int,4)};
            parameters[0].Value = model.GroupValue;
            
            parameters[1].Value = model.GroupName;
            parameters[2].Value = model.GroupPai;

            DbHelperSQL.RunProcedure("Proc_KNet_Sys_AuthorityUserGroup_Update", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sys_AuthorityUserGroup GetModel(string GroupValue)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@GroupValue", SqlDbType.NVarChar,50)};
            parameters[0].Value = GroupValue;

            KNet.Model.KNet_Sys_AuthorityUserGroup model = new KNet.Model.KNet_Sys_AuthorityUserGroup();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_Sys_AuthorityUserGroup_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.GroupValue = ds.Tables[0].Rows[0]["GroupValue"].ToString();
                model.GroupName = ds.Tables[0].Rows[0]["GroupName"].ToString();
                if (ds.Tables[0].Rows[0]["GroupPai"].ToString() != "")
                {
                    model.GroupPai = int.Parse(ds.Tables[0].Rows[0]["GroupPai"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,GroupValue,GroupName,GroupPai ");
            strSql.Append(" FROM KNet_Sys_AuthorityUserGroup ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,GroupValue,GroupName,GroupPai ");
            strSql.Append(" FROM KNet_Sys_AuthorityUserGroup ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  成员方法
    }
}


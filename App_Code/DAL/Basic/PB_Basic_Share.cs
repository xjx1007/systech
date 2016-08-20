using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:PB_Basic_Share
    /// </summary>
    public partial class PB_Basic_Share
    {
        public PB_Basic_Share()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBS_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PB_Basic_Share");
            strSql.Append(" where PBS_ID=@PBS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBS_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBS_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在客户ID和用户ID
        /// </summary>
        public bool deleteOld(KNet.Model.PB_Basic_Share model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete from PB_Basic_Share");
            strSql.Append(" where PBS_FromID=@PBS_FromID and PBS_FromPersonID=@PBS_FromPersonID and PBS_ToPersonID=@PBS_ToPersonID and PBS_Type=@PBS_Type ");

            SqlParameter[] parameters = {
					new SqlParameter("@PBS_FromID", SqlDbType.VarChar,50),
					new SqlParameter("@PBS_FromPersonID", SqlDbType.VarChar,50),
					new SqlParameter("@PBS_ToPersonID", SqlDbType.VarChar,50),
					new SqlParameter("@PBS_Type", SqlDbType.Int,4)};
            parameters[0].Value = model.PBS_FromID;
            parameters[1].Value = model.PBS_FromPersonID;
            parameters[2].Value = model.PBS_ToPersonID;
            parameters[3].Value = model.PBS_Type;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在客户ID和用户ID
        /// </summary>
        public bool deleteOldNoToID(KNet.Model.PB_Basic_Share model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete from PB_Basic_Share");
            strSql.Append(" where PBS_FromID=@PBS_FromID and PBS_FromPersonID=@PBS_FromPersonID  and PBS_Type=@PBS_Type ");

            SqlParameter[] parameters = {
					new SqlParameter("@PBS_FromID", SqlDbType.VarChar,50),
					new SqlParameter("@PBS_FromPersonID", SqlDbType.VarChar,50),
					new SqlParameter("@PBS_Type", SqlDbType.Int,4)};
            parameters[0].Value = model.PBS_FromID;
            parameters[1].Value = model.PBS_FromPersonID;
            parameters[2].Value = model.PBS_Type;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Basic_Share model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PB_Basic_Share(");
            strSql.Append("PBS_ID,PBS_FromID,PBS_FromPersonID,PBS_ToPersonID,PBS_Type,PBS_CTime)");
            strSql.Append(" values (");
            strSql.Append("dbo.GetID(),@PBS_FromID,@PBS_FromPersonID,@PBS_ToPersonID,@PBS_Type,@PBS_CTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@PBS_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PBS_FromID", SqlDbType.VarChar,50),
					new SqlParameter("@PBS_FromPersonID", SqlDbType.VarChar,50),
					new SqlParameter("@PBS_ToPersonID", SqlDbType.VarChar,50),
					new SqlParameter("@PBS_Type", SqlDbType.Int,4),
					new SqlParameter("@PBS_CTime", SqlDbType.DateTime)};
            parameters[0].Value = model.PBS_ID;
            parameters[1].Value = model.PBS_FromID;
            parameters[2].Value = model.PBS_FromPersonID;
            parameters[3].Value = model.PBS_ToPersonID;
            parameters[4].Value = model.PBS_Type;
            parameters[5].Value = model.PBS_CTime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Basic_Share model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PB_Basic_Share set ");
            strSql.Append("PBS_FromID=@PBS_FromID,");
            strSql.Append("PBS_FromPersonID=@PBS_FromPersonID,");
            strSql.Append("PBS_ToPersonID=@PBS_ToPersonID,");
            strSql.Append("PBS_Type=@PBS_Type,");
            strSql.Append("PBS_CTime=@PBS_CTime");
            strSql.Append(" where PBS_ID=@PBS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBS_FromID", SqlDbType.VarChar,50),
					new SqlParameter("@PBS_FromPersonID", SqlDbType.VarChar,50),
					new SqlParameter("@PBS_ToPersonID", SqlDbType.VarChar,50),
					new SqlParameter("@PBS_Type", SqlDbType.Int,4),
					new SqlParameter("@PBS_CTime", SqlDbType.DateTime),
					new SqlParameter("@PBS_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PBS_FromID;
            parameters[1].Value = model.PBS_FromPersonID;
            parameters[2].Value = model.PBS_ToPersonID;
            parameters[3].Value = model.PBS_Type;
            parameters[4].Value = model.PBS_CTime;
            parameters[5].Value = model.PBS_ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PBS_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_Share ");
            strSql.Append(" where PBS_ID=@PBS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBS_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBS_ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string PBS_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_Share ");
            strSql.Append(" where PBS_ID in (" + PBS_IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.PB_Basic_Share GetModel(string PBS_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from PB_Basic_Share ");
            strSql.Append(" where PBS_ID=@PBS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBS_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBS_ID;

            KNet.Model.PB_Basic_Share model = new KNet.Model.PB_Basic_Share();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PBS_ID"] != null && ds.Tables[0].Rows[0]["PBS_ID"].ToString() != "")
                {
                    model.PBS_ID = ds.Tables[0].Rows[0]["PBS_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBS_FromID"] != null && ds.Tables[0].Rows[0]["PBS_FromID"].ToString() != "")
                {
                    model.PBS_FromID = ds.Tables[0].Rows[0]["PBS_FromID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBS_FromPersonID"] != null && ds.Tables[0].Rows[0]["PBS_FromPersonID"].ToString() != "")
                {
                    model.PBS_FromPersonID = ds.Tables[0].Rows[0]["PBS_FromPersonID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBS_ToPersonID"] != null && ds.Tables[0].Rows[0]["PBS_ToPersonID"].ToString() != "")
                {
                    model.PBS_ToPersonID = ds.Tables[0].Rows[0]["PBS_ToPersonID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBS_Type"] != null && ds.Tables[0].Rows[0]["PBS_Type"].ToString() != "")
                {
                    model.PBS_Type = int.Parse(ds.Tables[0].Rows[0]["PBS_Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBS_CTime"] != null && ds.Tables[0].Rows[0]["PBS_CTime"].ToString() != "")
                {
                    model.PBS_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["PBS_CTime"].ToString());
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
            strSql.Append("select * ");
            strSql.Append(" FROM PB_Basic_Share ");
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
            strSql.Append(" * ");
            strSql.Append(" FROM PB_Basic_Share ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}


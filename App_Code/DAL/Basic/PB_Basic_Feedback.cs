using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:PB_Basic_Feedback
    /// </summary>
    public partial class PB_Basic_Feedback
    {
        public PB_Basic_Feedback()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBF_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PB_Basic_Feedback");
            strSql.Append(" where PBF_ID=@PBF_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBF_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBF_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Basic_Feedback model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PB_Basic_Feedback(");
            strSql.Append("PBF_ID,PBF_Code,PBF_ContentPerson,PBF_Type,PBF_Details,PBF_State,PBF_Creator,PBF_CTime,PBF_Mender,PBF_MTime)");
            strSql.Append(" values (");
            strSql.Append("@PBF_ID,@PBF_Code,@PBF_ContentPerson,@PBF_Type,@PBF_Details,@PBF_State,@PBF_Creator,@PBF_CTime,@PBF_Mender,@PBF_MTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@PBF_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PBF_Code", SqlDbType.VarChar,50),
					new SqlParameter("@PBF_ContentPerson", SqlDbType.VarChar,50),
					new SqlParameter("@PBF_Type", SqlDbType.VarChar,50),
					new SqlParameter("@PBF_Details", SqlDbType.VarChar,1000),
					new SqlParameter("@PBF_State", SqlDbType.Int,4),
					new SqlParameter("@PBF_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@PBF_CTime", SqlDbType.DateTime),
					new SqlParameter("@PBF_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@PBF_MTime", SqlDbType.DateTime)};
            parameters[0].Value = model.PBF_ID;
            parameters[1].Value = model.PBF_Code;
            parameters[2].Value = model.PBF_ContentPerson;
            parameters[3].Value = model.PBF_Type;
            parameters[4].Value = model.PBF_Details;
            parameters[5].Value = model.PBF_State;
            parameters[6].Value = model.PBF_Creator;
            parameters[7].Value = model.PBF_CTime;
            parameters[8].Value = model.PBF_Mender;
            parameters[9].Value = model.PBF_MTime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Basic_Feedback model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PB_Basic_Feedback set ");
            strSql.Append("PBF_Code=@PBF_Code,");
            strSql.Append("PBF_ContentPerson=@PBF_ContentPerson,");
            strSql.Append("PBF_Type=@PBF_Type,");
            strSql.Append("PBF_Details=@PBF_Details,");
            strSql.Append("PBF_State=@PBF_State,");
            strSql.Append("PBF_Creator=@PBF_Creator,");
            strSql.Append("PBF_CTime=@PBF_CTime,");
            strSql.Append("PBF_Mender=@PBF_Mender,");
            strSql.Append("PBF_MTime=@PBF_MTime");
            strSql.Append(" where PBF_ID=@PBF_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBF_Code", SqlDbType.VarChar,50),
					new SqlParameter("@PBF_ContentPerson", SqlDbType.VarChar,50),
					new SqlParameter("@PBF_Type", SqlDbType.VarChar,50),
					new SqlParameter("@PBF_Details", SqlDbType.VarChar,1000),
					new SqlParameter("@PBF_State", SqlDbType.Int,4),
					new SqlParameter("@PBF_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@PBF_CTime", SqlDbType.DateTime),
					new SqlParameter("@PBF_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@PBF_MTime", SqlDbType.DateTime),
					new SqlParameter("@PBF_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PBF_Code;
            parameters[1].Value = model.PBF_ContentPerson;
            parameters[2].Value = model.PBF_Type;
            parameters[3].Value = model.PBF_Details;
            parameters[4].Value = model.PBF_State;
            parameters[5].Value = model.PBF_Creator;
            parameters[6].Value = model.PBF_CTime;
            parameters[7].Value = model.PBF_Mender;
            parameters[8].Value = model.PBF_MTime;
            parameters[9].Value = model.PBF_ID;

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
        public bool Delete(string PBF_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_Feedback ");
            strSql.Append(" where PBF_ID=@PBF_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBF_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBF_ID;

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
        public bool DeleteList(string PBF_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_Feedback ");
            strSql.Append(" where PBF_ID in (" + PBF_IDlist + ")  ");
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
        public KNet.Model.PB_Basic_Feedback GetModel(string PBF_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PBF_ID,PBF_Code,PBF_ContentPerson,PBF_Type,PBF_Details,PBF_State,PBF_Creator,PBF_CTime,PBF_Mender,PBF_MTime from PB_Basic_Feedback ");
            strSql.Append(" where PBF_ID=@PBF_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBF_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBF_ID;

            KNet.Model.PB_Basic_Feedback model = new KNet.Model.PB_Basic_Feedback();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PBF_ID"] != null && ds.Tables[0].Rows[0]["PBF_ID"].ToString() != "")
                {
                    model.PBF_ID = ds.Tables[0].Rows[0]["PBF_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBF_Code"] != null && ds.Tables[0].Rows[0]["PBF_Code"].ToString() != "")
                {
                    model.PBF_Code = ds.Tables[0].Rows[0]["PBF_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBF_ContentPerson"] != null && ds.Tables[0].Rows[0]["PBF_ContentPerson"].ToString() != "")
                {
                    model.PBF_ContentPerson = ds.Tables[0].Rows[0]["PBF_ContentPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBF_Type"] != null && ds.Tables[0].Rows[0]["PBF_Type"].ToString() != "")
                {
                    model.PBF_Type = ds.Tables[0].Rows[0]["PBF_Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBF_Details"] != null && ds.Tables[0].Rows[0]["PBF_Details"].ToString() != "")
                {
                    model.PBF_Details = ds.Tables[0].Rows[0]["PBF_Details"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBF_State"] != null && ds.Tables[0].Rows[0]["PBF_State"].ToString() != "")
                {
                    model.PBF_State = int.Parse(ds.Tables[0].Rows[0]["PBF_State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBF_Creator"] != null && ds.Tables[0].Rows[0]["PBF_Creator"].ToString() != "")
                {
                    model.PBF_Creator = ds.Tables[0].Rows[0]["PBF_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBF_CTime"] != null && ds.Tables[0].Rows[0]["PBF_CTime"].ToString() != "")
                {
                    model.PBF_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["PBF_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBF_Mender"] != null && ds.Tables[0].Rows[0]["PBF_Mender"].ToString() != "")
                {
                    model.PBF_Mender = ds.Tables[0].Rows[0]["PBF_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBF_MTime"] != null && ds.Tables[0].Rows[0]["PBF_MTime"].ToString() != "")
                {
                    model.PBF_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["PBF_MTime"].ToString());
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
            strSql.Append("select PBF_ID,PBF_Code,PBF_ContentPerson,PBF_Type,PBF_Details,PBF_State,PBF_Creator,PBF_CTime,PBF_Mender,PBF_MTime ");
            strSql.Append(" FROM PB_Basic_Feedback ");
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
            strSql.Append(" PBF_ID,PBF_Code,PBF_ContentPerson,PBF_Type,PBF_Details,PBF_State,PBF_Creator,PBF_CTime,PBF_Mender,PBF_MTime ");
            strSql.Append(" FROM PB_Basic_Feedback ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "PB_Basic_Feedback";
            parameters[1].Value = "PBF_ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}


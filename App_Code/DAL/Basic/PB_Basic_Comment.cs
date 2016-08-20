using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:PB_Basic_Comment
    /// </summary>
    public partial class PB_Basic_Comment
    {
        public PB_Basic_Comment()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBC_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PB_Basic_Comment");
            strSql.Append(" where PBC_ID=@PBC_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBC_ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = PBC_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.PB_Basic_Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PB_Basic_Comment(");
            strSql.Append("PBC_ID,PBC_FID,PBC_FromPerson,PBC_PresetCode,PBC_Description,PBC_CTime,PBC_Type)");
            strSql.Append(" values (");
            strSql.Append("dbo.GetID(),@PBC_FID,@PBC_FromPerson,@PBC_PresetCode,@PBC_Description,@PBC_CTime,@PBC_Type)");
            SqlParameter[] parameters = {
					new SqlParameter("@PBC_FID", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_FromPerson", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_PresetCode", SqlDbType.Int,4),
					new SqlParameter("@PBC_Description", SqlDbType.VarChar,300),
					new SqlParameter("@PBC_CTime", SqlDbType.DateTime),
					new SqlParameter("@PBC_Type", SqlDbType.Int,4)};
            parameters[0].Value = model.PBC_FID;
            parameters[1].Value = model.PBC_FromPerson;
            parameters[2].Value = model.PBC_PresetCode;
            parameters[3].Value = model.PBC_Description;
            parameters[4].Value = model.PBC_CTime;
            parameters[5].Value = model.PBC_Type;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Basic_Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PB_Basic_Comment set ");
            strSql.Append("PBC_FID=@PBC_FID,");
            strSql.Append("PBC_FromPerson=@PBC_FromPerson,");
            strSql.Append("PBC_PresetCode=@PBC_PresetCode,");
            strSql.Append("PBC_Description=@PBC_Description,");
            strSql.Append("PBC_CTime=@PBC_CTime,");
            strSql.Append("PBC_Type=@PBC_Type");
            strSql.Append(" where PBC_ID=@PBC_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBC_FID", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_FromPerson", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_PresetCode", SqlDbType.Int,4),
					new SqlParameter("@PBC_Description", SqlDbType.VarChar,300),
					new SqlParameter("@PBC_CTime", SqlDbType.DateTime),
					new SqlParameter("@PBC_Type", SqlDbType.Int,4),
					new SqlParameter("@PBC_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PBC_FID;
            parameters[1].Value = model.PBC_FromPerson;
            parameters[2].Value = model.PBC_PresetCode;
            parameters[3].Value = model.PBC_Description;
            parameters[4].Value = model.PBC_CTime;
            parameters[5].Value = model.PBC_Type;
            parameters[6].Value = model.PBC_ID;

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
        public bool Delete(string PBC_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_Comment ");
            strSql.Append(" where PBC_ID=@PBC_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBC_ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = PBC_ID;

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
        public bool DeleteList(string PBC_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_Comment ");
            strSql.Append(" where PBC_ID in (" + PBC_IDlist + ")  ");
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
        public KNet.Model.PB_Basic_Comment GetModel(string PBC_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PBC_ID,PBC_FID,PBC_FromPerson,PBC_PresetCode,PBC_Description,PBC_CTime,PBC_Type from PB_Basic_Comment ");
            strSql.Append(" where PBC_ID=@PBC_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBC_ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = PBC_ID;

            KNet.Model.PB_Basic_Comment model = new KNet.Model.PB_Basic_Comment();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PBC_ID"] != null && ds.Tables[0].Rows[0]["PBC_ID"].ToString() != "")
                {
                    model.PBC_ID = ds.Tables[0].Rows[0]["PBC_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBC_FID"] != null && ds.Tables[0].Rows[0]["PBC_FID"].ToString() != "")
                {
                    model.PBC_FID = ds.Tables[0].Rows[0]["PBC_FID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBC_FromPerson"] != null && ds.Tables[0].Rows[0]["PBC_FromPerson"].ToString() != "")
                {
                    model.PBC_FromPerson = ds.Tables[0].Rows[0]["PBC_FromPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBC_PresetCode"] != null && ds.Tables[0].Rows[0]["PBC_PresetCode"].ToString() != "")
                {
                    model.PBC_PresetCode = int.Parse(ds.Tables[0].Rows[0]["PBC_PresetCode"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBC_Description"] != null && ds.Tables[0].Rows[0]["PBC_Description"].ToString() != "")
                {
                    model.PBC_Description = ds.Tables[0].Rows[0]["PBC_Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBC_CTime"] != null && ds.Tables[0].Rows[0]["PBC_CTime"].ToString() != "")
                {
                    model.PBC_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["PBC_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBC_Type"] != null && ds.Tables[0].Rows[0]["PBC_Type"].ToString() != "")
                {
                    model.PBC_Type = int.Parse(ds.Tables[0].Rows[0]["PBC_Type"].ToString());
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
            strSql.Append("select PBC_ID,PBC_FID,PBC_FromPerson,PBC_PresetCode,PBC_Description,PBC_CTime,PBC_Type ");
            strSql.Append(" FROM PB_Basic_Comment ");
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
            strSql.Append(" PBC_ID,PBC_FID,PBC_FromPerson,PBC_PresetCode,PBC_Description,PBC_CTime,PBC_Type ");
            strSql.Append(" FROM PB_Basic_Comment ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM PB_Basic_Comment ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.PBC_ID desc");
            }
            strSql.Append(")AS Row, T.*  from PB_Basic_Comment T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
            parameters[0].Value = "PB_Basic_Comment";
            parameters[1].Value = "PBC_ID";
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


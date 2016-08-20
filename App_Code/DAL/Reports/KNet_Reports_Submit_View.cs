using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:KNet_Reports_Submit_View
    /// </summary>
    public partial class KNet_Reports_Submit_View
    {
        public KNet_Reports_Submit_View()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KRV_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KNet_Reports_Submit_View");
            strSql.Append(" where KRV_ID=@KRV_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KRV_ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = KRV_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.KNet_Reports_Submit_View model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Reports_Submit_View(");
            strSql.Append("KRV_ID,KRV_SubmitID,KRV_FatherID,KRV_Remarks,KRV_Person,KRV_CTime,KRV_Creator,KRV_Del)");
            strSql.Append(" values (");
            strSql.Append("@KRV_ID,@KRV_SubmitID,@KRV_FatherID,@KRV_Remarks,@KRV_Person,@KRV_CTime,@KRV_Creator,@KRV_Del)");
            SqlParameter[] parameters = {
					new SqlParameter("@KRV_ID", SqlDbType.VarChar,50),
					new SqlParameter("@KRV_SubmitID", SqlDbType.VarChar,50),
					new SqlParameter("@KRV_FatherID", SqlDbType.VarChar,50),
					new SqlParameter("@KRV_Remarks", SqlDbType.VarChar,250),
					new SqlParameter("@KRV_Person", SqlDbType.VarChar,50),
					new SqlParameter("@KRV_CTime", SqlDbType.DateTime),
					new SqlParameter("@KRV_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@KRV_Del", SqlDbType.Int,4)};
            parameters[0].Value = model.KRV_ID;
            parameters[1].Value = model.KRV_SubmitID;
            parameters[2].Value = model.KRV_FatherID;
            parameters[3].Value = model.KRV_Remarks;
            parameters[4].Value = model.KRV_Person;
            parameters[5].Value = model.KRV_CTime;
            parameters[6].Value = model.KRV_Creator;
            parameters[7].Value = model.KRV_Del;

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
        public bool Update(KNet.Model.KNet_Reports_Submit_View model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Reports_Submit_View set ");
            strSql.Append("KRV_SubmitID=@KRV_SubmitID,");
            strSql.Append("KRV_FatherID=@KRV_FatherID,");
            strSql.Append("KRV_Remarks=@KRV_Remarks,");
            strSql.Append("KRV_Person=@KRV_Person,");
            strSql.Append("KRV_CTime=@KRV_CTime,");
            strSql.Append("KRV_Creator=@KRV_Creator,");
            strSql.Append("KRV_Del=@KRV_Del");
            strSql.Append(" where KRV_ID=@KRV_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KRV_SubmitID", SqlDbType.VarChar,50),
					new SqlParameter("@KRV_FatherID", SqlDbType.VarChar,50),
					new SqlParameter("@KRV_Remarks", SqlDbType.VarChar,250),
					new SqlParameter("@KRV_Person", SqlDbType.VarChar,50),
					new SqlParameter("@KRV_CTime", SqlDbType.DateTime),
					new SqlParameter("@KRV_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@KRV_Del", SqlDbType.Int,4),
					new SqlParameter("@KRV_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KRV_SubmitID;
            parameters[1].Value = model.KRV_FatherID;
            parameters[2].Value = model.KRV_Remarks;
            parameters[3].Value = model.KRV_Person;
            parameters[4].Value = model.KRV_CTime;
            parameters[5].Value = model.KRV_Creator;
            parameters[6].Value = model.KRV_Del;
            parameters[7].Value = model.KRV_ID;

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
        public bool Delete(string KRV_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_Reports_Submit_View ");
            strSql.Append(" where KRV_ID=@KRV_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KRV_ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = KRV_ID;

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
        public bool DeleteList(string KRV_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_Reports_Submit_View ");
            strSql.Append(" where KRV_ID in (" + KRV_IDlist + ")  ");
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
        public KNet.Model.KNet_Reports_Submit_View GetModel(string KRV_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 KRV_ID,KRV_SubmitID,KRV_FatherID,KRV_Remarks,KRV_Person,KRV_CTime,KRV_Creator,KRV_Del from KNet_Reports_Submit_View ");
            strSql.Append(" where KRV_ID=@KRV_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KRV_ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = KRV_ID;

            KNet.Model.KNet_Reports_Submit_View model = new KNet.Model.KNet_Reports_Submit_View();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["KRV_ID"] != null && ds.Tables[0].Rows[0]["KRV_ID"].ToString() != "")
                {
                    model.KRV_ID = ds.Tables[0].Rows[0]["KRV_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRV_SubmitID"] != null && ds.Tables[0].Rows[0]["KRV_SubmitID"].ToString() != "")
                {
                    model.KRV_SubmitID = ds.Tables[0].Rows[0]["KRV_SubmitID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRV_FatherID"] != null && ds.Tables[0].Rows[0]["KRV_FatherID"].ToString() != "")
                {
                    model.KRV_FatherID = ds.Tables[0].Rows[0]["KRV_FatherID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRV_Remarks"] != null && ds.Tables[0].Rows[0]["KRV_Remarks"].ToString() != "")
                {
                    model.KRV_Remarks = ds.Tables[0].Rows[0]["KRV_Remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRV_Person"] != null && ds.Tables[0].Rows[0]["KRV_Person"].ToString() != "")
                {
                    model.KRV_Person = ds.Tables[0].Rows[0]["KRV_Person"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRV_CTime"] != null && ds.Tables[0].Rows[0]["KRV_CTime"].ToString() != "")
                {
                    model.KRV_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["KRV_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KRV_Creator"] != null && ds.Tables[0].Rows[0]["KRV_Creator"].ToString() != "")
                {
                    model.KRV_Creator = ds.Tables[0].Rows[0]["KRV_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRV_Del"] != null && ds.Tables[0].Rows[0]["KRV_Del"].ToString() != "")
                {
                    model.KRV_Del = int.Parse(ds.Tables[0].Rows[0]["KRV_Del"].ToString());
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
            strSql.Append(" FROM KNet_Reports_Submit_View ");
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
            strSql.Append(" KRV_ID,KRV_SubmitID,KRV_FatherID,KRV_Remarks,KRV_Person,KRV_CTime,KRV_Creator,KRV_Del ");
            strSql.Append(" FROM KNet_Reports_Submit_View ");
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
            strSql.Append("select count(1) FROM KNet_Reports_Submit_View ");
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
                strSql.Append("order by T.KRV_ID desc");
            }
            strSql.Append(")AS Row, T.*  from KNet_Reports_Submit_View T ");
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
            parameters[0].Value = "KNet_Reports_Submit_View";
            parameters[1].Value = "KRV_ID";
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


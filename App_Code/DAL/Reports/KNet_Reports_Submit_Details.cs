using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:KNet_Reports_Submit_Details
    /// </summary>
    public partial class KNet_Reports_Submit_Details
    {
        public KNet_Reports_Submit_Details()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KRD_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KNet_Reports_Submit_Details");
            strSql.Append(" where KRD_ID=@KRD_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KRD_ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = KRD_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.KNet_Reports_Submit_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Reports_Submit_Details(");
            strSql.Append("KRD_ID,KRD_SubmitID,KPD_Type,KRD_URL,KRD_Name)");
            strSql.Append(" values (");
            strSql.Append("@KRD_ID,@KRD_SubmitID,@KPD_Type,@KRD_URL,@KRD_Name)");
            SqlParameter[] parameters = {
					new SqlParameter("@KRD_ID", SqlDbType.VarChar,50),
					new SqlParameter("@KRD_SubmitID", SqlDbType.VarChar,50),
					new SqlParameter("@KPD_Type", SqlDbType.VarChar,50),
					new SqlParameter("@KRD_URL", SqlDbType.VarChar,250),
					new SqlParameter("@KRD_Name", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KRD_ID;
            parameters[1].Value = model.KRD_SubmitID;
            parameters[2].Value = model.KPD_Type;
            parameters[3].Value = model.KRD_URL;
            parameters[4].Value = model.KRD_Name;

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
        public bool Update(KNet.Model.KNet_Reports_Submit_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Reports_Submit_Details set ");
            strSql.Append("KRD_SubmitID=@KRD_SubmitID,");
            strSql.Append("KPD_Type=@KPD_Type,");
            strSql.Append("KRD_URL=@KRD_URL,");
            strSql.Append("KRD_Name=@KRD_Name");
            strSql.Append(" where KRD_ID=@KRD_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KRD_SubmitID", SqlDbType.VarChar,50),
					new SqlParameter("@KPD_Type", SqlDbType.VarChar,50),
					new SqlParameter("@KRD_URL", SqlDbType.VarChar,250),
					new SqlParameter("@KRD_Name", SqlDbType.VarChar,50),
					new SqlParameter("@KRD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KRD_SubmitID;
            parameters[1].Value = model.KPD_Type;
            parameters[2].Value = model.KRD_URL;
            parameters[3].Value = model.KRD_Name;
            parameters[4].Value = model.KRD_ID;

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
        public bool Delete(string KRD_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_Reports_Submit_Details ");
            strSql.Append(" where KRD_ID=@KRD_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KRD_ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = KRD_ID;

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
        public bool DeleteBySubmitID(string KRD_SubmitID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_Reports_Submit_Details ");
            strSql.Append(" where KRD_SubmitID=@KRD_SubmitID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KRD_SubmitID", SqlDbType.VarChar,50)			};
            parameters[0].Value = KRD_SubmitID;

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
        public bool DeleteList(string KRD_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_Reports_Submit_Details ");
            strSql.Append(" where KRD_ID in (" + KRD_IDlist + ")  ");
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
        public KNet.Model.KNet_Reports_Submit_Details GetModel(string KRD_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 KRD_ID,KRD_SubmitID,KPD_Type,KRD_URL,KRD_Name from KNet_Reports_Submit_Details ");
            strSql.Append(" where KRD_ID=@KRD_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KRD_ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = KRD_ID;

            KNet.Model.KNet_Reports_Submit_Details model = new KNet.Model.KNet_Reports_Submit_Details();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["KRD_ID"] != null && ds.Tables[0].Rows[0]["KRD_ID"].ToString() != "")
                {
                    model.KRD_ID = ds.Tables[0].Rows[0]["KRD_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRD_SubmitID"] != null && ds.Tables[0].Rows[0]["KRD_SubmitID"].ToString() != "")
                {
                    model.KRD_SubmitID = ds.Tables[0].Rows[0]["KRD_SubmitID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPD_Type"] != null && ds.Tables[0].Rows[0]["KPD_Type"].ToString() != "")
                {
                    model.KPD_Type = ds.Tables[0].Rows[0]["KPD_Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRD_URL"] != null && ds.Tables[0].Rows[0]["KRD_URL"].ToString() != "")
                {
                    model.KRD_URL = ds.Tables[0].Rows[0]["KRD_URL"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRD_Name"] != null && ds.Tables[0].Rows[0]["KRD_Name"].ToString() != "")
                {
                    model.KRD_Name = ds.Tables[0].Rows[0]["KRD_Name"].ToString();
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
            strSql.Append("select KRD_ID,KRD_SubmitID,KPD_Type,KRD_URL,KRD_Name ");
            strSql.Append(" FROM KNet_Reports_Submit_Details ");
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
            strSql.Append(" KRD_ID,KRD_SubmitID,KPD_Type,KRD_URL,KRD_Name ");
            strSql.Append(" FROM KNet_Reports_Submit_Details ");
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
            strSql.Append("select count(1) FROM KNet_Reports_Submit_Details ");
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
                strSql.Append("order by T.KRD_ID desc");
            }
            strSql.Append(")AS Row, T.*  from KNet_Reports_Submit_Details T ");
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
            parameters[0].Value = "KNet_Reports_Submit_Details";
            parameters[1].Value = "KRD_ID";
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


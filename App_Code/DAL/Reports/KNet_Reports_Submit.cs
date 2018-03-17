using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:KNet_Reports_Submit
    /// </summary>
    public partial class KNet_Reports_Submit
    {
        public KNet_Reports_Submit()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KRS_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KNet_Reports_Submit");
            strSql.Append(" where KRS_ID=@KRS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KRS_ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = KRS_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.KNet_Reports_Submit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Reports_Submit(");
            strSql.Append("KRS_ID,KRS_Code,KRS_DutyPerson,KRS_Type,KRS_Remarks,KRS_CTime,KRS_Creator,KRS_MTime,KRS_Mender,KRS_Del,KRS_Stime,KRS_State,KRS_Topic,KRS_NoticeID)");
            strSql.Append(" values (");
            strSql.Append("@KRS_ID,@KRS_Code,@KRS_DutyPerson,@KRS_Type,@KRS_Remarks,@KRS_CTime,@KRS_Creator,@KRS_MTime,@KRS_Mender,@KRS_Del,@KRS_Stime,@KRS_State,@KRS_Topic,@KRS_NoticeID)");
            SqlParameter[] parameters = {
					new SqlParameter("@KRS_ID", SqlDbType.VarChar,50),
					new SqlParameter("@KRS_Code", SqlDbType.VarChar,50),
					new SqlParameter("@KRS_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@KRS_Type", SqlDbType.VarChar,50),
					new SqlParameter("@KRS_Remarks", SqlDbType.VarChar,500),
					new SqlParameter("@KRS_CTime", SqlDbType.DateTime),
					new SqlParameter("@KRS_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@KRS_MTime", SqlDbType.DateTime),
					new SqlParameter("@KRS_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@KRS_Del", SqlDbType.Int,4),
					new SqlParameter("@KRS_Stime", SqlDbType.DateTime),
					new SqlParameter("@KRS_State", SqlDbType.Int,4),
					new SqlParameter("@KRS_Topic", SqlDbType.VarChar,50),
					new SqlParameter("@KRS_NoticeID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KRS_ID;
            parameters[1].Value = model.KRS_Code;
            parameters[2].Value = model.KRS_DutyPerson;
            parameters[3].Value = model.KRS_Type;
            parameters[4].Value = model.KRS_Remarks;
            parameters[5].Value = model.KRS_CTime;
            parameters[6].Value = model.KRS_Creator;
            parameters[7].Value = model.KRS_MTime;
            parameters[8].Value = model.KRS_Mender;
            parameters[9].Value = model.KRS_Del;
            parameters[10].Value = model.KRS_Stime;
            parameters[11].Value = model.KRS_State;
            parameters[12].Value = model.KRS_Topic;
            parameters[13].Value = model.KRS_NoticeID;

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
        public bool Update(KNet.Model.KNet_Reports_Submit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Reports_Submit set ");
            strSql.Append("KRS_Code=@KRS_Code,");
            strSql.Append("KRS_DutyPerson=@KRS_DutyPerson,");
            strSql.Append("KRS_Type=@KRS_Type,");
            strSql.Append("KRS_Remarks=@KRS_Remarks,");
            strSql.Append("KRS_CTime=@KRS_CTime,");
            strSql.Append("KRS_Creator=@KRS_Creator,");
            strSql.Append("KRS_MTime=@KRS_MTime,");
            strSql.Append("KRS_Mender=@KRS_Mender,");
            strSql.Append("KRS_Del=@KRS_Del,");
            strSql.Append("KRS_State=@KRS_State,");
            strSql.Append("KRS_Topic=@KRS_Topic,");
            strSql.Append("KRS_NoticeID=@KRS_NoticeID,");
            
            strSql.Append("KRS_Stime=@KRS_Stime");
            strSql.Append(" where KRS_ID=@KRS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KRS_Code", SqlDbType.VarChar,50),
					new SqlParameter("@KRS_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@KRS_Type", SqlDbType.VarChar,50),
					new SqlParameter("@KRS_Remarks", SqlDbType.VarChar,500),
					new SqlParameter("@KRS_CTime", SqlDbType.DateTime),
					new SqlParameter("@KRS_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@KRS_MTime", SqlDbType.DateTime),
					new SqlParameter("@KRS_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@KRS_Del", SqlDbType.Int,4),
					new SqlParameter("@KRS_State", SqlDbType.Int,4),
					new SqlParameter("@KRS_Topic", SqlDbType.VarChar,50),
					new SqlParameter("@KRS_NoticeID", SqlDbType.VarChar,50),
					new SqlParameter("@KRS_Stime", SqlDbType.DateTime),
					new SqlParameter("@KRS_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KRS_Code;
            parameters[1].Value = model.KRS_DutyPerson;
            parameters[2].Value = model.KRS_Type;
            parameters[3].Value = model.KRS_Remarks;
            parameters[4].Value = model.KRS_CTime;
            parameters[5].Value = model.KRS_Creator;
            parameters[6].Value = model.KRS_MTime;
            parameters[7].Value = model.KRS_Mender;
            parameters[8].Value = model.KRS_Del;
            parameters[9].Value = model.KRS_State;
            parameters[10].Value = model.KRS_Topic;
            parameters[11].Value = model.KRS_NoticeID;
            parameters[12].Value = model.KRS_Stime;
            parameters[13].Value = model.KRS_ID;

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
        public bool UpdateState(KNet.Model.KNet_Reports_Submit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Reports_Submit set ");
            strSql.Append("KRS_State=@KRS_State");
            strSql.Append(" where KRS_ID=@KRS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KRS_State", SqlDbType.Int,4),
					new SqlParameter("@KRS_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KRS_State;
            parameters[1].Value = model.KRS_ID;
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
        public bool Delete(string KRS_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_Reports_Submit ");
            strSql.Append(" where KRS_ID=@KRS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KRS_ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = KRS_ID;

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
        public bool DeleteList(string KRS_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_Reports_Submit ");
            strSql.Append(" where KRS_ID in (" + KRS_IDlist + ")  ");
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
        public KNet.Model.KNet_Reports_Submit GetModel(string KRS_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from KNet_Reports_Submit ");
            strSql.Append(" where KRS_ID=@KRS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KRS_ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = KRS_ID;

            KNet.Model.KNet_Reports_Submit model = new KNet.Model.KNet_Reports_Submit();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["KRS_ID"] != null && ds.Tables[0].Rows[0]["KRS_ID"].ToString() != "")
                {
                    model.KRS_ID = ds.Tables[0].Rows[0]["KRS_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRS_Code"] != null && ds.Tables[0].Rows[0]["KRS_Code"].ToString() != "")
                {
                    model.KRS_Code = ds.Tables[0].Rows[0]["KRS_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRS_DutyPerson"] != null && ds.Tables[0].Rows[0]["KRS_DutyPerson"].ToString() != "")
                {
                    model.KRS_DutyPerson = ds.Tables[0].Rows[0]["KRS_DutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRS_Type"] != null && ds.Tables[0].Rows[0]["KRS_Type"].ToString() != "")
                {
                    model.KRS_Type = ds.Tables[0].Rows[0]["KRS_Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRS_Remarks"] != null && ds.Tables[0].Rows[0]["KRS_Remarks"].ToString() != "")
                {
                    model.KRS_Remarks = ds.Tables[0].Rows[0]["KRS_Remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRS_CTime"] != null && ds.Tables[0].Rows[0]["KRS_CTime"].ToString() != "")
                {
                    model.KRS_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["KRS_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KRS_Creator"] != null && ds.Tables[0].Rows[0]["KRS_Creator"].ToString() != "")
                {
                    model.KRS_Creator = ds.Tables[0].Rows[0]["KRS_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRS_MTime"] != null && ds.Tables[0].Rows[0]["KRS_MTime"].ToString() != "")
                {
                    model.KRS_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["KRS_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KRS_Mender"] != null && ds.Tables[0].Rows[0]["KRS_Mender"].ToString() != "")
                {
                    model.KRS_Mender = ds.Tables[0].Rows[0]["KRS_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRS_Del"] != null && ds.Tables[0].Rows[0]["KRS_Del"].ToString() != "")
                {
                    model.KRS_Del = int.Parse(ds.Tables[0].Rows[0]["KRS_Del"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KRS_State"] != null && ds.Tables[0].Rows[0]["KRS_State"].ToString() != "")
                {
                    model.KRS_State = int.Parse(ds.Tables[0].Rows[0]["KRS_State"].ToString());
                }
                else
                {
                    model.KRS_State = 0;
                }
                if (ds.Tables[0].Rows[0]["KRS_Topic"] != null && ds.Tables[0].Rows[0]["KRS_Topic"].ToString() != "")
                {
                    model.KRS_Topic = ds.Tables[0].Rows[0]["KRS_Topic"].ToString();
                }
                
                if (ds.Tables[0].Rows[0]["KRS_Stime"] != null && ds.Tables[0].Rows[0]["KRS_Stime"].ToString() != "")
                {
                    model.KRS_Stime = DateTime.Parse(ds.Tables[0].Rows[0]["KRS_Stime"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KRS_NoticeID"] != null && ds.Tables[0].Rows[0]["KRS_NoticeID"].ToString() != "")
                {
                    model.KRS_NoticeID = ds.Tables[0].Rows[0]["KRS_NoticeID"].ToString();
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
            strSql.Append(" FROM KNet_Reports_Submit ");
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
            strSql.Append(" *");
            strSql.Append(" FROM KNet_Reports_Submit ");
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
            strSql.Append("select count(1) FROM KNet_Reports_Submit ");
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
                strSql.Append("order by T.KRS_ID desc");
            }
            strSql.Append(")AS Row, T.*  from KNet_Reports_Submit T ");
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
            parameters[0].Value = "KNet_Reports_Submit";
            parameters[1].Value = "KRS_ID";
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


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:System_PhoneMessage_Manage
    /// </summary>
    public partial class System_PhoneMessage_Manage
    {
        public System_PhoneMessage_Manage()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SPM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from System_PhoneMessage_Manage");
            strSql.Append(" where SPM_ID=@SPM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SPM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SPM_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.System_PhoneMessage_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into System_PhoneMessage_Manage(");
            strSql.Append("SPM_ID,SPM_ReceiveID,SPM_ReceivePhone,SPM_ReceiveName,SPM_SenderID,SPM_State,SPM_Detail,SPM_SendTime,SPM_Sender,SPM_Type,SPM_Del,SPM_FID)");
            strSql.Append(" values (");
            strSql.Append("@SPM_ID,@SPM_ReceiveID,@SPM_ReceivePhone,@SPM_ReceiveName,@SPM_SenderID,@SPM_State,@SPM_Detail,@SPM_SendTime,@SPM_Sender,@SPM_Type,@SPM_Del,@SPM_FID)");
            SqlParameter[] parameters = {
					new SqlParameter("@SPM_ID", SqlDbType.VarChar,50),
					new SqlParameter("@SPM_ReceiveID", SqlDbType.VarChar,3000),
					new SqlParameter("@SPM_ReceivePhone", SqlDbType.VarChar,3000),
					new SqlParameter("@SPM_ReceiveName", SqlDbType.VarChar,3000),
					new SqlParameter("@SPM_SenderID", SqlDbType.VarChar,3000),
					new SqlParameter("@SPM_State", SqlDbType.Int,4),
					new SqlParameter("@SPM_Detail", SqlDbType.VarChar,3000),
					new SqlParameter("@SPM_SendTime", SqlDbType.DateTime),
					new SqlParameter("@SPM_Sender", SqlDbType.VarChar,50),
					new SqlParameter("@SPM_Type", SqlDbType.Int,4),
					new SqlParameter("@SPM_Del", SqlDbType.Int,4),
					new SqlParameter("@SPM_FID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SPM_ID;
            parameters[1].Value = model.SPM_ReceiveID;
            parameters[2].Value = model.SPM_ReceivePhone;
            parameters[3].Value = model.SPM_ReceiveName;
            parameters[4].Value = model.SPM_SenderID;
            parameters[5].Value = model.SPM_State;
            parameters[6].Value = model.SPM_Detail;
            parameters[7].Value = model.SPM_SendTime;
            parameters[8].Value = model.SPM_Sender;
            parameters[9].Value = model.SPM_Type;
            parameters[10].Value = model.SPM_Del;
            parameters[11].Value = model.SPM_FID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.System_PhoneMessage_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update System_PhoneMessage_Manage set ");
            strSql.Append("SPM_ReceiveID=@SPM_ReceiveID,");
            strSql.Append("SPM_ReceivePhone=@SPM_ReceivePhone,");
            strSql.Append("SPM_ReceiveName=@SPM_ReceiveName,");
            strSql.Append("SPM_SenderID=@SPM_SenderID,");
            strSql.Append("SPM_State=@SPM_State,");
            strSql.Append("SPM_Detail=@SPM_Detail,");
            strSql.Append("SPM_SendTime=@SPM_SendTime,");
            strSql.Append("SPM_Sender=@SPM_Sender,");
            strSql.Append("SPM_Type=@SPM_Type,");
            strSql.Append("SPM_Del=@SPM_Del");
            strSql.Append(" where SPM_ID=@SPM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SPM_ReceiveID", SqlDbType.VarChar,3000),
					new SqlParameter("@SPM_ReceivePhone", SqlDbType.VarChar,3000),
					new SqlParameter("@SPM_ReceiveName", SqlDbType.VarChar,3000),
					new SqlParameter("@SPM_SenderID", SqlDbType.VarChar,3000),
					new SqlParameter("@SPM_State", SqlDbType.Int,4),
					new SqlParameter("@SPM_Detail", SqlDbType.VarChar,3000),
					new SqlParameter("@SPM_SendTime", SqlDbType.DateTime),
					new SqlParameter("@SPM_Sender", SqlDbType.VarChar,50),
					new SqlParameter("@SPM_Type", SqlDbType.Int,4),
					new SqlParameter("@SPM_Del", SqlDbType.Int,4),
					new SqlParameter("@SPM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SPM_ReceiveID;
            parameters[1].Value = model.SPM_ReceivePhone;
            parameters[2].Value = model.SPM_ReceiveName;
            parameters[3].Value = model.SPM_SenderID;
            parameters[4].Value = model.SPM_State;
            parameters[5].Value = model.SPM_Detail;
            parameters[6].Value = model.SPM_SendTime;
            parameters[7].Value = model.SPM_Sender;
            parameters[8].Value = model.SPM_Type;
            parameters[9].Value = model.SPM_Del;
            parameters[10].Value = model.SPM_ID;

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
        public bool Delete(string SPM_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from System_PhoneMessage_Manage ");
            strSql.Append(" where SPM_ID=@SPM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SPM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SPM_ID;

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
        public bool DeleteList(string SPM_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from System_PhoneMessage_Manage ");
            strSql.Append(" where SPM_ID in (" + SPM_IDlist + ")  ");
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
        public KNet.Model.System_PhoneMessage_Manage GetModel(string SPM_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from System_PhoneMessage_Manage ");
            strSql.Append(" where SPM_ID=@SPM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SPM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SPM_ID;

            KNet.Model.System_PhoneMessage_Manage model = new KNet.Model.System_PhoneMessage_Manage();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SPM_ID"] != null && ds.Tables[0].Rows[0]["SPM_ID"].ToString() != "")
                {
                    model.SPM_ID = ds.Tables[0].Rows[0]["SPM_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SPM_ReceiveID"] != null && ds.Tables[0].Rows[0]["SPM_ReceiveID"].ToString() != "")
                {
                    model.SPM_ReceiveID = ds.Tables[0].Rows[0]["SPM_ReceiveID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SPM_ReceivePhone"] != null && ds.Tables[0].Rows[0]["SPM_ReceivePhone"].ToString() != "")
                {
                    model.SPM_ReceivePhone = ds.Tables[0].Rows[0]["SPM_ReceivePhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SPM_ReceiveName"] != null && ds.Tables[0].Rows[0]["SPM_ReceiveName"].ToString() != "")
                {
                    model.SPM_ReceiveName = ds.Tables[0].Rows[0]["SPM_ReceiveName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SPM_SenderID"] != null && ds.Tables[0].Rows[0]["SPM_SenderID"].ToString() != "")
                {
                    model.SPM_SenderID = ds.Tables[0].Rows[0]["SPM_SenderID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SPM_State"] != null && ds.Tables[0].Rows[0]["SPM_State"].ToString() != "")
                {
                    model.SPM_State = int.Parse(ds.Tables[0].Rows[0]["SPM_State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SPM_Detail"] != null && ds.Tables[0].Rows[0]["SPM_Detail"].ToString() != "")
                {
                    model.SPM_Detail = ds.Tables[0].Rows[0]["SPM_Detail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SPM_SendTime"] != null && ds.Tables[0].Rows[0]["SPM_SendTime"].ToString() != "")
                {
                    model.SPM_SendTime = DateTime.Parse(ds.Tables[0].Rows[0]["SPM_SendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SPM_Sender"] != null && ds.Tables[0].Rows[0]["SPM_Sender"].ToString() != "")
                {
                    model.SPM_Sender = ds.Tables[0].Rows[0]["SPM_Sender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SPM_Type"] != null && ds.Tables[0].Rows[0]["SPM_Type"].ToString() != "")
                {
                    model.SPM_Type = int.Parse(ds.Tables[0].Rows[0]["SPM_Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SPM_Del"] != null && ds.Tables[0].Rows[0]["SPM_Del"].ToString() != "")
                {
                    model.SPM_Del = int.Parse(ds.Tables[0].Rows[0]["SPM_Del"].ToString());
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
            strSql.Append(" FROM System_PhoneMessage_Manage ");
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
            strSql.Append(" FROM System_PhoneMessage_Manage ");
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
            parameters[0].Value = "System_PhoneMessage_Manage";
            parameters[1].Value = "SPM_ID";
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


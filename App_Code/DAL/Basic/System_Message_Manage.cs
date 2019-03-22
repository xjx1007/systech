using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using KNet.DBUtility;


namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_WareHouse_WareCheckList_Printer_Setup。
    /// </summary>
    /// <summary>
    /// 数据访问类:System_Message_Manage
    /// </summary>
    public partial class System_Message_Manage
    {
        public System_Message_Manage()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(KNet.Model.System_Message_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from System_Message_Manage");
            strSql.Append(" where SMM_ReceiveID=@SMM_ReceiveID and SMM_Del=@SMM_Del and SMM_UnRead=@SMM_UnRead ");
            SqlParameter[] parameters = {
					new SqlParameter("@SMM_ReceiveID", SqlDbType.VarChar,50),
					new SqlParameter("@SMM_Del", SqlDbType.Int),
					new SqlParameter("@SMM_UnRead", SqlDbType.Int)
            };
            parameters[0].Value = model.SMM_ReceiveID;
            parameters[1].Value = model.SMM_Del;
            parameters[2].Value = model.SMM_UnRead;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.System_Message_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into System_Message_Manage(");
            strSql.Append("SMM_SenderID,SMM_ReceiveID,SMM_State,SMM_Detail,SMM_Del,SMM_Title,SMM_SendTime,SMM_LookTime,Back_ID,SMM_Type,SMM_ID)");
            strSql.Append(" values (");
            strSql.Append("@SMM_SenderID,@SMM_ReceiveID,@SMM_State,@SMM_Detail,@SMM_Del,@SMM_Title,@SMM_SendTime,@SMM_LookTime,@Back_ID,@SMM_Type,@SMM_ID)");
            SqlParameter[] parameters = {
					new SqlParameter("@SMM_SenderID", SqlDbType.VarChar,50),
					new SqlParameter("@SMM_ReceiveID", SqlDbType.VarChar,50),
					new SqlParameter("@SMM_State", SqlDbType.Int,4),
					new SqlParameter("@SMM_Detail", SqlDbType.VarChar,3000),
					new SqlParameter("@SMM_Del", SqlDbType.Int,4),
					new SqlParameter("@SMM_Title", SqlDbType.VarChar,500),
					new SqlParameter("@SMM_SendTime", SqlDbType.DateTime),
					new SqlParameter("@SMM_LookTime", SqlDbType.DateTime),
					new SqlParameter("@Back_ID", SqlDbType.VarChar,50),
					new SqlParameter("@SMM_Type", SqlDbType.VarChar,50),
					new SqlParameter("@SMM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SMM_SenderID;
            parameters[1].Value = model.SMM_ReceiveID;
            parameters[2].Value = model.SMM_State;
            parameters[3].Value = model.SMM_Detail;
            parameters[4].Value = model.SMM_Del;
            parameters[5].Value = model.SMM_Title;
            parameters[6].Value = model.SMM_SendTime;
            parameters[7].Value = model.SMM_LookTime;
            parameters[8].Value = model.Back_ID;
            parameters[9].Value = model.SMM_Type;
            if ((model.SMM_ID==null)||(model.SMM_ID == ""))
            {
                BasePage Page = new BasePage();
                parameters[10].Value = Page.GetNewID("System_Message_Manage", 1);
            }
            else
            {
                parameters[10].Value = model.SMM_ID;
 
            }

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.System_Message_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update System_Message_Manage set ");
            strSql.Append("SMM_SenderID=@SMM_SenderID,");
            strSql.Append("SMM_ReceiveID=@SMM_ReceiveID,");
            strSql.Append("SMM_State=@SMM_State,");
            strSql.Append("SMM_Detail=@SMM_Detail,");
            strSql.Append("SMM_Del=@SMM_Del,");
            strSql.Append("SMM_Title=@SMM_Title,");
            strSql.Append("SMM_SendTime=@SMM_SendTime,");
            strSql.Append("SMM_LookTime=@SMM_LookTime");
            strSql.Append(" where SMM_ID=@SMM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SMM_SenderID", SqlDbType.VarChar,50),
					new SqlParameter("@SMM_ReceiveID", SqlDbType.VarChar,50),
					new SqlParameter("@SMM_State", SqlDbType.Int,4),
					new SqlParameter("@SMM_Detail", SqlDbType.VarChar,2000),
					new SqlParameter("@SMM_Del", SqlDbType.Int,4),
					new SqlParameter("@SMM_Title", SqlDbType.VarChar,500),
					new SqlParameter("@SMM_SendTime", SqlDbType.DateTime),
					new SqlParameter("@SMM_LookTime", SqlDbType.DateTime),
					new SqlParameter("@SMM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SMM_SenderID;
            parameters[1].Value = model.SMM_ReceiveID;
            parameters[2].Value = model.SMM_State;
            parameters[3].Value = model.SMM_Detail;
            parameters[4].Value = model.SMM_Del;
            parameters[5].Value = model.SMM_Title;
            parameters[6].Value = model.SMM_SendTime;
            parameters[7].Value = model.SMM_LookTime;
            parameters[8].Value = model.SMM_ID;

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
        public bool UpdateState(KNet.Model.System_Message_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update System_Message_Manage set ");
            strSql.Append("SMM_State=@SMM_State,");
            strSql.Append("SMM_LookTime=@SMM_LookTime");
            strSql.Append(" where SMM_ID=@SMM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SMM_SenderID", SqlDbType.VarChar,50),
					new SqlParameter("@SMM_ReceiveID", SqlDbType.VarChar,50),
					new SqlParameter("@SMM_State", SqlDbType.Int,4),
					new SqlParameter("@SMM_Detail", SqlDbType.VarChar,2000),
					new SqlParameter("@SMM_Del", SqlDbType.Int,4),
					new SqlParameter("@SMM_Title", SqlDbType.VarChar,500),
					new SqlParameter("@SMM_SendTime", SqlDbType.DateTime),
					new SqlParameter("@SMM_LookTime", SqlDbType.DateTime),
					new SqlParameter("@SMM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SMM_SenderID;
            parameters[1].Value = model.SMM_ReceiveID;
            parameters[2].Value = model.SMM_State;
            parameters[3].Value = model.SMM_Detail;
            parameters[4].Value = model.SMM_Del;
            parameters[5].Value = model.SMM_Title;
            parameters[6].Value = model.SMM_SendTime;
            parameters[7].Value = model.SMM_LookTime;
            parameters[8].Value = model.SMM_ID;

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
        public bool UpdateUnRead(KNet.Model.System_Message_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update System_Message_Manage set ");
            strSql.Append("SMM_UnRead=@SMM_UnRead,");
            strSql.Append("SMM_LookTime=@SMM_LookTime");
            strSql.Append(" where SMM_ID=@SMM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SMM_UnRead", SqlDbType.Int,4),
					new SqlParameter("@SMM_LookTime", SqlDbType.DateTime),
					new SqlParameter("@SMM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SMM_UnRead;
            parameters[1].Value = model.SMM_LookTime;
            parameters[2].Value = model.SMM_ID;

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
        public bool Delete(string SMM_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from System_Message_Manage ");
            strSql.Append(" where SMM_ID=@SMM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SMM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SMM_ID;

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
        public bool DeleteList(string SMM_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from System_Message_Manage ");
            strSql.Append(" where SMM_ID in (" + SMM_IDlist + ")  ");
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
        public KNet.Model.System_Message_Manage GetModel(string SMM_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SMM_ID,SMM_SenderID,SMM_ReceiveID,SMM_State,SMM_Detail,SMM_Del,SMM_Title,SMM_SendTime,SMM_LookTime from System_Message_Manage ");
            strSql.Append(" where SMM_ID=@SMM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SMM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SMM_ID;

            KNet.Model.System_Message_Manage model = new KNet.Model.System_Message_Manage();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SMM_ID"] != null && ds.Tables[0].Rows[0]["SMM_ID"].ToString() != "")
                {
                    model.SMM_ID = ds.Tables[0].Rows[0]["SMM_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SMM_SenderID"] != null && ds.Tables[0].Rows[0]["SMM_SenderID"].ToString() != "")
                {
                    model.SMM_SenderID = ds.Tables[0].Rows[0]["SMM_SenderID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SMM_ReceiveID"] != null && ds.Tables[0].Rows[0]["SMM_ReceiveID"].ToString() != "")
                {
                    model.SMM_ReceiveID = ds.Tables[0].Rows[0]["SMM_ReceiveID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SMM_State"] != null && ds.Tables[0].Rows[0]["SMM_State"].ToString() != "")
                {
                    model.SMM_State = int.Parse(ds.Tables[0].Rows[0]["SMM_State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SMM_Detail"] != null && ds.Tables[0].Rows[0]["SMM_Detail"].ToString() != "")
                {
                    model.SMM_Detail = ds.Tables[0].Rows[0]["SMM_Detail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SMM_Del"] != null && ds.Tables[0].Rows[0]["SMM_Del"].ToString() != "")
                {
                    model.SMM_Del = int.Parse(ds.Tables[0].Rows[0]["SMM_Del"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SMM_Title"] != null && ds.Tables[0].Rows[0]["SMM_Title"].ToString() != "")
                {
                    model.SMM_Title = ds.Tables[0].Rows[0]["SMM_Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SMM_SendTime"] != null && ds.Tables[0].Rows[0]["SMM_SendTime"].ToString() != "")
                {
                    model.SMM_SendTime = DateTime.Parse(ds.Tables[0].Rows[0]["SMM_SendTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SMM_LookTime"] != null && ds.Tables[0].Rows[0]["SMM_LookTime"].ToString() != "")
                {
                    model.SMM_LookTime = DateTime.Parse(ds.Tables[0].Rows[0]["SMM_LookTime"].ToString());
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
        public DataSet GetList1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM System_Message_Manage ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM System_Message_Manage ");
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
            strSql.Append(" SMM_ID,SMM_SenderID,SMM_ReceiveID,SMM_State,SMM_Detail,SMM_Del,SMM_Title,SMM_SendTime,SMM_LookTime ");
            strSql.Append(" FROM System_Message_Manage ");
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
            parameters[0].Value = "System_Message_Manage";
            parameters[1].Value = "SMM_ID";
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



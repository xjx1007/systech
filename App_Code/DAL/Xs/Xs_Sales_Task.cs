using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Xs_Sales_Task
    /// </summary>
    public partial class Xs_Sales_Task
    {
        public Xs_Sales_Task()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XST_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Xs_Sales_Task");
            strSql.Append(" where XST_ID=@XST_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XST_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XST_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Sales_Task model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Xs_Sales_Task(");
            strSql.Append("XST_ID,XST_Topic,XST_State,XST_Claim,XST_ISModiy,XST_BeginTime,XST_EndTime,XST_DutyPerson,XST_Executor,XST_Remarks,XST_Creator,XST_CTime)");
            strSql.Append(" values (");
            strSql.Append("@XST_ID,@XST_Topic,@XST_State,@XST_Claim,@XST_ISModiy,@XST_BeginTime,@XST_EndTime,@XST_DutyPerson,@XST_Executor,@XST_Remarks,@XST_Creator,@XST_CTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@XST_ID", SqlDbType.VarChar,50),
					new SqlParameter("@XST_Topic", SqlDbType.VarChar,250),
					new SqlParameter("@XST_State", SqlDbType.VarChar,50),
					new SqlParameter("@XST_Claim", SqlDbType.VarChar,50),
					new SqlParameter("@XST_ISModiy", SqlDbType.Int,4),
					new SqlParameter("@XST_BeginTime", SqlDbType.DateTime),
					new SqlParameter("@XST_EndTime", SqlDbType.DateTime),
					new SqlParameter("@XST_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@XST_Executor", SqlDbType.VarChar,350),
					new SqlParameter("@XST_Remarks", SqlDbType.VarChar,300),
					new SqlParameter("@XST_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@XST_CTime", SqlDbType.DateTime)};
            parameters[0].Value = model.XST_ID;
            parameters[1].Value = model.XST_Topic;
            parameters[2].Value = model.XST_State;
            parameters[3].Value = model.XST_Claim;
            parameters[4].Value = model.XST_ISModiy;
            parameters[5].Value = model.XST_BeginTime;
            parameters[6].Value = model.XST_EndTime;
            parameters[7].Value = model.XST_DutyPerson;
            parameters[8].Value = model.XST_Executor;
            parameters[9].Value = model.XST_Remarks;
            parameters[10].Value = model.XST_Creator;
            parameters[11].Value = model.XST_CTime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Sales_Task model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Xs_Sales_Task set ");
            strSql.Append("XST_Topic=@XST_Topic,");
            strSql.Append("XST_State=@XST_State,");
            strSql.Append("XST_Claim=@XST_Claim,");
            strSql.Append("XST_ISModiy=@XST_ISModiy,");
            strSql.Append("XST_BeginTime=@XST_BeginTime,");
            strSql.Append("XST_EndTime=@XST_EndTime,");
            strSql.Append("XST_DutyPerson=@XST_DutyPerson,");
            strSql.Append("XST_Executor=@XST_Executor,");
            strSql.Append("XST_Remarks=@XST_Remarks,");
            strSql.Append("XST_Mender=@XST_Mender,");
            strSql.Append("XST_MTime=@XST_MTime,");
            strSql.Append(" where XST_ID=@XST_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XST_Topic", SqlDbType.VarChar,250),
					new SqlParameter("@XST_State", SqlDbType.VarChar,50),
					new SqlParameter("@XST_Claim", SqlDbType.VarChar,50),
					new SqlParameter("@XST_ISModiy", SqlDbType.Int,4),
					new SqlParameter("@XST_BeginTime", SqlDbType.DateTime),
					new SqlParameter("@XST_EndTime", SqlDbType.DateTime),
					new SqlParameter("@XST_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@XST_Executor", SqlDbType.VarChar,350),
					new SqlParameter("@XST_Remarks", SqlDbType.VarChar,300),
					new SqlParameter("@XST_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@XST_MTime", SqlDbType.DateTime),
					new SqlParameter("@XST_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.XST_Topic;
            parameters[1].Value = model.XST_State;
            parameters[2].Value = model.XST_Claim;
            parameters[3].Value = model.XST_ISModiy;
            parameters[4].Value = model.XST_BeginTime;
            parameters[5].Value = model.XST_EndTime;
            parameters[6].Value = model.XST_DutyPerson;
            parameters[7].Value = model.XST_Executor;
            parameters[8].Value = model.XST_Remarks;
            parameters[9].Value = model.XST_Mender;
            parameters[10].Value = model.XST_MTime;
            parameters[11].Value = model.XST_ID;

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
        public bool Delete(string XST_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Sales_Task ");
            strSql.Append(" where XST_ID=@XST_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XST_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XST_ID;

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
        public bool DeleteList(string XST_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Sales_Task ");
            strSql.Append(" where XST_ID in (" + XST_IDlist + ")  ");
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
        public KNet.Model.Xs_Sales_Task GetModel(string XST_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Xs_Sales_Task ");
            strSql.Append(" where XST_ID=@XST_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XST_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XST_ID;

            KNet.Model.Xs_Sales_Task model = new KNet.Model.Xs_Sales_Task();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["XST_ID"] != null && ds.Tables[0].Rows[0]["XST_ID"].ToString() != "")
                {
                    model.XST_ID = ds.Tables[0].Rows[0]["XST_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XST_Topic"] != null && ds.Tables[0].Rows[0]["XST_Topic"].ToString() != "")
                {
                    model.XST_Topic = ds.Tables[0].Rows[0]["XST_Topic"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XST_State"] != null && ds.Tables[0].Rows[0]["XST_State"].ToString() != "")
                {
                    model.XST_State = ds.Tables[0].Rows[0]["XST_State"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XST_Claim"] != null && ds.Tables[0].Rows[0]["XST_Claim"].ToString() != "")
                {
                    model.XST_Claim = ds.Tables[0].Rows[0]["XST_Claim"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XST_ISModiy"] != null && ds.Tables[0].Rows[0]["XST_ISModiy"].ToString() != "")
                {
                    model.XST_ISModiy = int.Parse(ds.Tables[0].Rows[0]["XST_ISModiy"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XST_BeginTime"] != null && ds.Tables[0].Rows[0]["XST_BeginTime"].ToString() != "")
                {
                    model.XST_BeginTime = DateTime.Parse(ds.Tables[0].Rows[0]["XST_BeginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XST_EndTime"] != null && ds.Tables[0].Rows[0]["XST_EndTime"].ToString() != "")
                {
                    model.XST_EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["XST_EndTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XST_DutyPerson"] != null && ds.Tables[0].Rows[0]["XST_DutyPerson"].ToString() != "")
                {
                    model.XST_DutyPerson = ds.Tables[0].Rows[0]["XST_DutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XST_Executor"] != null && ds.Tables[0].Rows[0]["XST_Executor"].ToString() != "")
                {
                    model.XST_Executor = ds.Tables[0].Rows[0]["XST_Executor"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XST_Remarks"] != null && ds.Tables[0].Rows[0]["XST_Remarks"].ToString() != "")
                {
                    model.XST_Remarks = ds.Tables[0].Rows[0]["XST_Remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XST_Creator"] != null && ds.Tables[0].Rows[0]["XST_Creator"].ToString() != "")
                {
                    model.XST_Creator = ds.Tables[0].Rows[0]["XST_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XST_CTime"] != null && ds.Tables[0].Rows[0]["XST_CTime"].ToString() != "")
                {
                    model.XST_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["XST_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XST_Mender"] != null && ds.Tables[0].Rows[0]["XST_Mender"].ToString() != "")
                {
                    model.XST_Mender = ds.Tables[0].Rows[0]["XST_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XST_MTime"] != null && ds.Tables[0].Rows[0]["XST_MTime"].ToString() != "")
                {
                    model.XST_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["XST_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XST_Del"] != null && ds.Tables[0].Rows[0]["XST_Del"].ToString() != "")
                {
                    model.XST_Del = int.Parse(ds.Tables[0].Rows[0]["XST_Del"].ToString());
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
            strSql.Append("select XST_ID,XST_Topic,XST_State,XST_Claim,XST_ISModiy,XST_BeginTime,XST_EndTime,XST_DutyPerson,XST_Executor,XST_Remarks,XST_Creator,XST_CTime,XST_Mender,XST_MTime,XST_Del ");
            strSql.Append(" FROM Xs_Sales_Task ");
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
            strSql.Append(" XST_ID,XST_Topic,XST_State,XST_Claim,XST_ISModiy,XST_BeginTime,XST_EndTime,XST_DutyPerson,XST_Executor,XST_Remarks,XST_Creator,XST_CTime,XST_Mender,XST_MTime,XST_Del ");
            strSql.Append(" FROM Xs_Sales_Task ");
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
            parameters[0].Value = "Xs_Sales_Task";
            parameters[1].Value = "XST_ID";
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


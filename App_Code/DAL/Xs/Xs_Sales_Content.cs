using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Xs_Sales_Content
    /// </summary>
    public partial class Xs_Sales_Content
    {
        public Xs_Sales_Content()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XSC_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Xs_Sales_Content");
            strSql.Append(" where XSC_ID=@XSC_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XSC_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XSC_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Sales_Content model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Xs_Sales_Content(");
            strSql.Append("XSC_ID,XSC_CustomerValue,XSC_LinkMan,XSC_Topic,XSC_Stime,XSC_DutyPerson,XSC_Types,XSC_Steps,XSC_State,XSC_NextAskTime,XSC_SalesChance,XSC_Remarks,XSC_Creator,XSC_CTime,XSC_Mender,XSC_MTime,XSC_Type)");
            strSql.Append(" values (");
            strSql.Append("@XSC_ID,@XSC_CustomerValue,@XSC_LinkMan,@XSC_Topic,@XSC_Stime,@XSC_DutyPerson,@XSC_Types,@XSC_Steps,@XSC_State,@XSC_NextAskTime,@XSC_SalesChance,@XSC_Remarks,@XSC_Creator,@XSC_CTime,@XSC_Mender,@XSC_MTime,@XSC_Type)");
            SqlParameter[] parameters = {
					new SqlParameter("@XSC_ID", SqlDbType.VarChar,50),
					new SqlParameter("@XSC_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@XSC_LinkMan", SqlDbType.VarChar,50),
					new SqlParameter("@XSC_Topic", SqlDbType.VarChar,50),
					new SqlParameter("@XSC_Stime", SqlDbType.DateTime),
					new SqlParameter("@XSC_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@XSC_Types", SqlDbType.VarChar,3),
					new SqlParameter("@XSC_Steps", SqlDbType.VarChar,50),
					new SqlParameter("@XSC_State", SqlDbType.VarChar,50),
					new SqlParameter("@XSC_NextAskTime", SqlDbType.DateTime),
					new SqlParameter("@XSC_SalesChance", SqlDbType.VarChar,50),
					new SqlParameter("@XSC_Remarks", SqlDbType.VarChar,3000),
					new SqlParameter("@XSC_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@XSC_CTime", SqlDbType.DateTime),
					new SqlParameter("@XSC_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@XSC_MTime", SqlDbType.DateTime),
					new SqlParameter("@XSC_Type", SqlDbType.Int)};
            parameters[0].Value = model.XSC_ID;
            parameters[1].Value = model.XSC_CustomerValue;
            parameters[2].Value = model.XSC_LinkMan;
            parameters[3].Value = model.XSC_Topic;
            parameters[4].Value = model.XSC_Stime;
            parameters[5].Value = model.XSC_DutyPerson;
            parameters[6].Value = model.XSC_Types;
            parameters[7].Value = model.XSC_Steps;
            parameters[8].Value = model.XSC_State;
            parameters[9].Value = model.XSC_NextAskTime;
            parameters[10].Value = model.XSC_SalesChance;
            parameters[11].Value = model.XSC_Remarks;
            parameters[12].Value = model.XSC_Creator;
            parameters[13].Value = model.XSC_CTime;
            parameters[14].Value = model.XSC_Mender;
            parameters[15].Value = model.XSC_MTime;
            parameters[16].Value = model.XSC_Type;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Sales_Content model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Xs_Sales_Content set ");
            strSql.Append("XSC_CustomerValue=@XSC_CustomerValue,");
            strSql.Append("XSC_LinkMan=@XSC_LinkMan,");
            strSql.Append("XSC_Topic=@XSC_Topic,");
            strSql.Append("XSC_Stime=@XSC_Stime,");
            strSql.Append("XSC_DutyPerson=@XSC_DutyPerson,");
            strSql.Append("XSC_Types=@XSC_Types,");
            strSql.Append("XSC_Steps=@XSC_Steps,");
            strSql.Append("XSC_State=@XSC_State,");
            strSql.Append("XSC_NextAskTime=@XSC_NextAskTime,");
            strSql.Append("XSC_SalesChance=@XSC_SalesChance,");
            strSql.Append("XSC_Remarks=@XSC_Remarks,");
            strSql.Append("XSC_Mender=@XSC_Mender,");
            strSql.Append("XSC_MTime=@XSC_MTime,");
            strSql.Append("XSC_Type=@XSC_Type");
            strSql.Append(" where XSC_ID=@XSC_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XSC_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@XSC_LinkMan", SqlDbType.VarChar,50),
					new SqlParameter("@XSC_Topic", SqlDbType.VarChar,50),
					new SqlParameter("@XSC_Stime", SqlDbType.DateTime),
					new SqlParameter("@XSC_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@XSC_Types", SqlDbType.VarChar,3),
					new SqlParameter("@XSC_Steps", SqlDbType.VarChar,50),
					new SqlParameter("@XSC_State", SqlDbType.VarChar,50),
					new SqlParameter("@XSC_NextAskTime", SqlDbType.DateTime),
					new SqlParameter("@XSC_SalesChance", SqlDbType.VarChar,50),
					new SqlParameter("@XSC_Remarks", SqlDbType.VarChar,3000),
					new SqlParameter("@XSC_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@XSC_MTime", SqlDbType.DateTime),
					new SqlParameter("@XSC_Type", SqlDbType.Int),
					new SqlParameter("@XSC_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.XSC_CustomerValue;
            parameters[1].Value = model.XSC_LinkMan;
            parameters[2].Value = model.XSC_Topic;
            parameters[3].Value = model.XSC_Stime;
            parameters[4].Value = model.XSC_DutyPerson;
            parameters[5].Value = model.XSC_Types;
            parameters[6].Value = model.XSC_Steps;
            parameters[7].Value = model.XSC_State;
            parameters[8].Value = model.XSC_NextAskTime;
            parameters[9].Value = model.XSC_SalesChance;
            parameters[10].Value = model.XSC_Remarks;
            parameters[11].Value = model.XSC_Mender;
            parameters[12].Value = model.XSC_MTime;
            parameters[13].Value = model.XSC_Type;
            parameters[14].Value = model.XSC_ID;

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
        public bool Delete(string XSC_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Sales_Content ");
            strSql.Append(" where XSC_ID=@XSC_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XSC_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XSC_ID;

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
        public bool DeleteList(string XSC_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Sales_Content ");
            strSql.Append(" where XSC_ID in (" + XSC_IDlist + ")  ");
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
        public KNet.Model.Xs_Sales_Content GetModel(string XSC_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Xs_Sales_Content ");
            strSql.Append(" where XSC_ID=@XSC_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XSC_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XSC_ID;

            KNet.Model.Xs_Sales_Content model = new KNet.Model.Xs_Sales_Content();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["XSC_ID"] != null && ds.Tables[0].Rows[0]["XSC_ID"].ToString() != "")
                {
                    model.XSC_ID = ds.Tables[0].Rows[0]["XSC_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSC_CustomerValue"] != null && ds.Tables[0].Rows[0]["XSC_CustomerValue"].ToString() != "")
                {
                    model.XSC_CustomerValue = ds.Tables[0].Rows[0]["XSC_CustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSC_LinkMan"] != null && ds.Tables[0].Rows[0]["XSC_LinkMan"].ToString() != "")
                {
                    model.XSC_LinkMan = ds.Tables[0].Rows[0]["XSC_LinkMan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSC_Topic"] != null && ds.Tables[0].Rows[0]["XSC_Topic"].ToString() != "")
                {
                    model.XSC_Topic = ds.Tables[0].Rows[0]["XSC_Topic"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSC_Stime"] != null && ds.Tables[0].Rows[0]["XSC_Stime"].ToString() != "")
                {
                    model.XSC_Stime = DateTime.Parse(ds.Tables[0].Rows[0]["XSC_Stime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XSC_DutyPerson"] != null && ds.Tables[0].Rows[0]["XSC_DutyPerson"].ToString() != "")
                {
                    model.XSC_DutyPerson = ds.Tables[0].Rows[0]["XSC_DutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSC_Types"] != null && ds.Tables[0].Rows[0]["XSC_Types"].ToString() != "")
                {
                    model.XSC_Types = ds.Tables[0].Rows[0]["XSC_Types"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSC_Steps"] != null && ds.Tables[0].Rows[0]["XSC_Steps"].ToString() != "")
                {
                    model.XSC_Steps = ds.Tables[0].Rows[0]["XSC_Steps"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSC_State"] != null && ds.Tables[0].Rows[0]["XSC_State"].ToString() != "")
                {
                    model.XSC_State = ds.Tables[0].Rows[0]["XSC_State"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSC_NextAskTime"] != null && ds.Tables[0].Rows[0]["XSC_NextAskTime"].ToString() != "")
                {
                    model.XSC_NextAskTime = DateTime.Parse(ds.Tables[0].Rows[0]["XSC_NextAskTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XSC_SalesChance"] != null && ds.Tables[0].Rows[0]["XSC_SalesChance"].ToString() != "")
                {
                    model.XSC_SalesChance = ds.Tables[0].Rows[0]["XSC_SalesChance"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSC_Remarks"] != null && ds.Tables[0].Rows[0]["XSC_Remarks"].ToString() != "")
                {
                    model.XSC_Remarks = ds.Tables[0].Rows[0]["XSC_Remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSC_Creator"] != null && ds.Tables[0].Rows[0]["XSC_Creator"].ToString() != "")
                {
                    model.XSC_Creator = ds.Tables[0].Rows[0]["XSC_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSC_CTime"] != null && ds.Tables[0].Rows[0]["XSC_CTime"].ToString() != "")
                {
                    model.XSC_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["XSC_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XSC_Mender"] != null && ds.Tables[0].Rows[0]["XSC_Mender"].ToString() != "")
                {
                    model.XSC_Mender = ds.Tables[0].Rows[0]["XSC_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSC_MTime"] != null && ds.Tables[0].Rows[0]["XSC_MTime"].ToString() != "")
                {
                    model.XSC_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["XSC_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XSC_Del"] != null && ds.Tables[0].Rows[0]["XSC_Del"].ToString() != "")
                {
                    model.XSC_Del = int.Parse(ds.Tables[0].Rows[0]["XSC_Del"].ToString());
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
            strSql.Append(" FROM Xs_Sales_Content  left join Xs_Sales_Opp on XSC_SalesChance=XSO_ID and XSO_Del=0");
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
            strSql.Append(" XSC_ID,XSC_CustomerValue,XSC_LinkMan,XSC_Topic,XSC_Stime,XSC_DutyPerson,XSC_Types,XSC_Steps,XSC_State,XSC_NextAskTime,XSC_SalesChance,XSC_Remarks,XSC_Creator,XSC_CTime,XSC_Mender,XSC_MTime,XSC_Del ");
            strSql.Append(" FROM Xs_Sales_Content ");
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
            parameters[0].Value = "Xs_Sales_Content";
            parameters[1].Value = "XSC_ID";
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


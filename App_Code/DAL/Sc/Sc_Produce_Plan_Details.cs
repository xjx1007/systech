using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Sc_Produce_Plan_Details
    /// </summary>
    public partial class Sc_Produce_Plan_Details
    {
        public Sc_Produce_Plan_Details()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SPD_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sc_Produce_Plan_Details");
            strSql.Append(" where SPD_ID=@SPD_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SPD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SPD_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Sc_Produce_Plan_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sc_Produce_Plan_Details(");
            strSql.Append("SPD_ID,SPD_BeginTime,SPD_EndTime,SPD_OrderNo,SPD_Remarks,SPD_Type,SPD_FaterID,SPD_FBeginTime,SPD_FEndTime,SPD_Days,SPD_Number,SPD_IsWl,SCP_Order)");
            strSql.Append(" values (");
            strSql.Append("@SPD_ID,@SPD_BeginTime,@SPD_EndTime,@SPD_OrderNo,@SPD_Remarks,@SPD_Type,@SPD_FaterID,@SPD_FBeginTime,@SPD_FEndTime,@SPD_Days,@SPD_Number,@SPD_IsWl,@SCP_Order)");
            SqlParameter[] parameters = {
					new SqlParameter("@SPD_ID", SqlDbType.VarChar,50),
					new SqlParameter("@SPD_BeginTime", SqlDbType.DateTime),
					new SqlParameter("@SPD_EndTime", SqlDbType.DateTime),
					new SqlParameter("@SPD_OrderNo", SqlDbType.VarChar,50),
					new SqlParameter("@SPD_Remarks", SqlDbType.VarChar,500),
					new SqlParameter("@SPD_Type", SqlDbType.Int,4),
					new SqlParameter("@SPD_FaterID", SqlDbType.VarChar,50),
					new SqlParameter("@SPD_FBeginTime", SqlDbType.DateTime),
					new SqlParameter("@SPD_FEndTime", SqlDbType.DateTime),
					new SqlParameter("@SPD_Days", SqlDbType.Int,4),
					new SqlParameter("@SPD_Number", SqlDbType.Int,4),
					new SqlParameter("@SPD_IsWl", SqlDbType.Int,4),
					new SqlParameter("@SCP_Order", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.SPD_ID;
            parameters[1].Value = model.SPD_BeginTime;
            parameters[2].Value = model.SPD_EndTime;
            parameters[3].Value = model.SPD_OrderNo;
            parameters[4].Value = model.SPD_Remarks;
            parameters[5].Value = model.SPD_Type;
            parameters[6].Value = model.SPD_FaterID;
            parameters[7].Value = model.SPD_FBeginTime;
            parameters[8].Value = model.SPD_FEndTime;
            parameters[9].Value = model.SPD_Days;
            parameters[10].Value = model.SPD_Number;
            parameters[11].Value = model.SPD_IsWl;
            parameters[12].Value = model.SCP_Order;
            

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }	/// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Sc_Produce_Plan_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sc_Produce_Plan_Details set ");
            strSql.Append("SPD_BeginTime=@SPD_BeginTime,");
            strSql.Append("SPD_EndTime=@SPD_EndTime,");
            strSql.Append("SPD_OrderNo=@SPD_OrderNo,");
            strSql.Append("SPD_Remarks=@SPD_Remarks,");
            strSql.Append("SPD_Type=@SPD_Type,");
            strSql.Append("SPD_FaterID=@SPD_FaterID,");
            strSql.Append("SPD_FBeginTime=@SPD_FBeginTime,");
            strSql.Append("SPD_FEndTime=@SPD_FEndTime,");
            strSql.Append("SPD_Days=@SPD_Days,");
            strSql.Append("SPD_Number=@SPD_Number");
            strSql.Append(" where SPD_ID=@SPD_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SPD_BeginTime", SqlDbType.DateTime),
					new SqlParameter("@SPD_EndTime", SqlDbType.DateTime),
					new SqlParameter("@SPD_OrderNo", SqlDbType.VarChar,50),
					new SqlParameter("@SPD_Remarks", SqlDbType.VarChar,500),
					new SqlParameter("@SPD_Type", SqlDbType.Int,4),
					new SqlParameter("@SPD_FaterID", SqlDbType.VarChar,50),
					new SqlParameter("@SPD_FBeginTime", SqlDbType.DateTime),
					new SqlParameter("@SPD_FEndTime", SqlDbType.DateTime),
					new SqlParameter("@SPD_Days", SqlDbType.Int,4),
					new SqlParameter("@SPD_Number", SqlDbType.Int,4),
					new SqlParameter("@SPD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SPD_BeginTime;
            parameters[1].Value = model.SPD_EndTime;
            parameters[2].Value = model.SPD_OrderNo;
            parameters[3].Value = model.SPD_Remarks;
            parameters[4].Value = model.SPD_Type;
            parameters[5].Value = model.SPD_FaterID;
            parameters[6].Value = model.SPD_FBeginTime;
            parameters[7].Value = model.SPD_FEndTime;
            parameters[8].Value = model.SPD_Days;
            parameters[9].Value = model.SPD_Number;
            parameters[10].Value = model.SPD_ID;

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


        public bool UpdateOrder(KNet.Model.Sc_Produce_Plan_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sc_Produce_Plan_Details set ");
            strSql.Append("SCP_Order=@SCP_Order");
            strSql.Append(" where SPD_ID=@SPD_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SCP_Order", SqlDbType.Int,4),
					new SqlParameter("@SPD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SCP_Order;
            parameters[1].Value = model.SPD_ID;

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
        public bool Delete(string SPD_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sc_Produce_Plan_Details ");
            strSql.Append(" where SPD_ID=@SPD_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SPD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SPD_ID;

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
        public bool DeleteList(string SPD_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sc_Produce_Plan_Details ");
            strSql.Append(" where SPD_ID in (" + SPD_IDlist + ")  ");
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
        public KNet.Model.Sc_Produce_Plan_Details GetModel(string SPD_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Sc_Produce_Plan_Details ");
            strSql.Append(" where SPD_ID=@SPD_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SPD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SPD_ID;

            KNet.Model.Sc_Produce_Plan_Details model = new KNet.Model.Sc_Produce_Plan_Details();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SPD_ID"] != null && ds.Tables[0].Rows[0]["SPD_ID"].ToString() != "")
                {
                    model.SPD_ID = ds.Tables[0].Rows[0]["SPD_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SPD_BeginTime"] != null && ds.Tables[0].Rows[0]["SPD_BeginTime"].ToString() != "")
                {
                    model.SPD_BeginTime = DateTime.Parse(ds.Tables[0].Rows[0]["SPD_BeginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SPD_EndTime"] != null && ds.Tables[0].Rows[0]["SPD_EndTime"].ToString() != "")
                {
                    model.SPD_EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["SPD_EndTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SPD_OrderNo"] != null && ds.Tables[0].Rows[0]["SPD_OrderNo"].ToString() != "")
                {
                    model.SPD_OrderNo = ds.Tables[0].Rows[0]["SPD_OrderNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SPD_Remarks"] != null && ds.Tables[0].Rows[0]["SPD_Remarks"].ToString() != "")
                {
                    model.SPD_Remarks = ds.Tables[0].Rows[0]["SPD_Remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SPD_Type"] != null && ds.Tables[0].Rows[0]["SPD_Type"].ToString() != "")
                {
                    model.SPD_Type = int.Parse(ds.Tables[0].Rows[0]["SPD_Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SPD_FaterID"] != null && ds.Tables[0].Rows[0]["SPD_FaterID"].ToString() != "")
                {
                    model.SPD_FaterID = ds.Tables[0].Rows[0]["SPD_FaterID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SPD_FBeginTime"] != null && ds.Tables[0].Rows[0]["SPD_FBeginTime"].ToString() != "")
                {
                    model.SPD_FBeginTime = DateTime.Parse(ds.Tables[0].Rows[0]["SPD_FBeginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SPD_FEndTime"] != null && ds.Tables[0].Rows[0]["SPD_FEndTime"].ToString() != "")
                {
                    model.SPD_FEndTime = DateTime.Parse(ds.Tables[0].Rows[0]["SPD_FEndTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SPD_Days"] != null && ds.Tables[0].Rows[0]["SPD_Days"].ToString() != "")
                {
                    model.SPD_Days = int.Parse(ds.Tables[0].Rows[0]["SPD_Days"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SPD_Number"] != null && ds.Tables[0].Rows[0]["SPD_Number"].ToString() != "")
                {
                    model.SPD_Number = int.Parse(ds.Tables[0].Rows[0]["SPD_Number"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SCP_Order"] != null && ds.Tables[0].Rows[0]["SCP_Order"].ToString() != "")
                {
                    model.SCP_Order = int.Parse(ds.Tables[0].Rows[0]["SCP_Order"].ToString());
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
            strSql.Append(" FROM Sc_Produce_Plan_Details ");
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
            strSql.Append(" FROM Sc_Produce_Plan_Details ");
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
            parameters[0].Value = "Sc_Produce_Plan_Details";
            parameters[1].Value = "SPD_ID";
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


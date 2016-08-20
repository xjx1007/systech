using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Cw_Accounting_Init_Details
    /// </summary>
    public partial class Cw_Accounting_Init_Details
    {
        public Cw_Accounting_Init_Details()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CAID_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cw_Accounting_Init_Details");
            strSql.Append(" where CAID_ID=@CAID_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAID_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAID_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cw_Accounting_Init_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cw_Accounting_Init_Details(");
            strSql.Append("CAID_ID,CAID_FID,CAID_OutTime,CAID_Number,CAID_Remarks)");
            strSql.Append(" values (");
            strSql.Append("@CAID_ID,@CAID_FID,@CAID_OutTime,@CAID_Number,@CAID_Remarks)");
            SqlParameter[] parameters = {
					new SqlParameter("@CAID_ID", SqlDbType.VarChar,50),
					new SqlParameter("@CAID_FID", SqlDbType.VarChar,50),
					new SqlParameter("@CAID_OutTime", SqlDbType.DateTime),
					new SqlParameter("@CAID_Number", SqlDbType.Decimal,9),
					new SqlParameter("@CAID_Remarks", SqlDbType.VarChar,250)};
            parameters[0].Value = model.CAID_ID;
            parameters[1].Value = model.CAID_FID;
            parameters[2].Value = model.CAID_OutTime;
            parameters[3].Value = model.CAID_Number;
            parameters[4].Value = model.CAID_Remarks;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cw_Accounting_Init_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cw_Accounting_Init_Details set ");
            strSql.Append("CAID_FID=@CAID_FID,");
            strSql.Append("CAID_OutTime=@CAID_OutTime,");
            strSql.Append("CAID_Number=@CAID_Number,");
            strSql.Append("CAID_Remarks=@CAID_Remarks");
            strSql.Append(" where CAID_ID=@CAID_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAID_FID", SqlDbType.VarChar,50),
					new SqlParameter("@CAID_OutTime", SqlDbType.DateTime),
					new SqlParameter("@CAID_Number", SqlDbType.Decimal,9),
					new SqlParameter("@CAID_Remarks", SqlDbType.VarChar,250),
					new SqlParameter("@CAID_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CAID_FID;
            parameters[1].Value = model.CAID_OutTime;
            parameters[2].Value = model.CAID_Number;
            parameters[3].Value = model.CAID_Remarks;
            parameters[4].Value = model.CAID_ID;

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
        public bool Delete(string CAID_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cw_Accounting_Init_Details ");
            strSql.Append(" where CAID_ID=@CAID_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAID_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAID_ID;

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
        public bool DeleteByFID(string CAID_FID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cw_Accounting_Init_Details ");
            strSql.Append(" where CAID_FID=@CAID_FID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAID_FID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAID_FID;

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
        public bool DeleteList(string CAID_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cw_Accounting_Init_Details ");
            strSql.Append(" where CAID_ID in (" + CAID_IDlist + ")  ");
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
        public KNet.Model.Cw_Accounting_Init_Details GetModel(string CAID_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CAID_ID,CAID_FID,CAID_OutTime,CAID_Number,CAID_Remarks from Cw_Accounting_Init_Details ");
            strSql.Append(" where CAID_ID=@CAID_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAID_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAID_ID;

            KNet.Model.Cw_Accounting_Init_Details model = new KNet.Model.Cw_Accounting_Init_Details();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CAID_ID"] != null && ds.Tables[0].Rows[0]["CAID_ID"].ToString() != "")
                {
                    model.CAID_ID = ds.Tables[0].Rows[0]["CAID_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAID_FID"] != null && ds.Tables[0].Rows[0]["CAID_FID"].ToString() != "")
                {
                    model.CAID_FID = ds.Tables[0].Rows[0]["CAID_FID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAID_OutTime"] != null && ds.Tables[0].Rows[0]["CAID_OutTime"].ToString() != "")
                {
                    model.CAID_OutTime = DateTime.Parse(ds.Tables[0].Rows[0]["CAID_OutTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAID_Number"] != null && ds.Tables[0].Rows[0]["CAID_Number"].ToString() != "")
                {
                    model.CAID_Number = decimal.Parse(ds.Tables[0].Rows[0]["CAID_Number"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAID_Remarks"] != null && ds.Tables[0].Rows[0]["CAID_Remarks"].ToString() != "")
                {
                    model.CAID_Remarks = ds.Tables[0].Rows[0]["CAID_Remarks"].ToString();
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
            strSql.Append("select CAID_ID,CAID_FID,CAID_OutTime,CAID_Number,CAID_Remarks ");
            strSql.Append(" FROM Cw_Accounting_Init_Details ");
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
            strSql.Append(" CAID_ID,CAID_FID,CAID_OutTime,CAID_Number,CAID_Remarks ");
            strSql.Append(" FROM Cw_Accounting_Init_Details ");
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
            parameters[0].Value = "Cw_Accounting_Init_Details";
            parameters[1].Value = "CAID_ID";
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


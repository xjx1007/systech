using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Cw_Accounting_PaymentDetails
    /// </summary>
    public partial class Cw_Accounting_PaymentDetails
    {
        public Cw_Accounting_PaymentDetails()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CAPD_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cw_Accounting_PaymentDetails");
            strSql.Append(" where CAPD_ID=@CAPD_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAPD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAPD_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cw_Accounting_PaymentDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cw_Accounting_PaymentDetails(");
            strSql.Append("CAPD_ID,CAPD_CARID,CAPD_yTime,CAPD_Order,CAPD_State,CAPD_Money,CAPD_Details,CAPD_FID,CAPD_Number,CAPD_Price)");
            strSql.Append(" values (");
            strSql.Append("@CAPD_ID,@CAPD_CARID,@CAPD_yTime,@CAPD_Order,@CAPD_State,@CAPD_Money,@CAPD_Details,@CAPD_FID,@CAPD_Number,@CAPD_Price)");
            SqlParameter[] parameters = {
					new SqlParameter("@CAPD_ID", SqlDbType.VarChar,50),
					new SqlParameter("@CAPD_CARID", SqlDbType.VarChar,50),
					new SqlParameter("@CAPD_yTime", SqlDbType.DateTime),
					new SqlParameter("@CAPD_Order", SqlDbType.Int,4),
					new SqlParameter("@CAPD_State", SqlDbType.Int,4),
					new SqlParameter("@CAPD_Money", SqlDbType.Decimal,9),
					new SqlParameter("@CAPD_Details", SqlDbType.VarChar,50),
					new SqlParameter("@CAPD_FID", SqlDbType.VarChar,50),
					new SqlParameter("@CAPD_Number", SqlDbType.Decimal,9),
					new SqlParameter("@CAPD_Price", SqlDbType.Decimal,9)};
            parameters[0].Value = model.CAPD_ID;
            parameters[1].Value = model.CAPD_CARID;
            parameters[2].Value = model.CAPD_yTime;
            parameters[3].Value = model.CAPD_Order;
            parameters[4].Value = model.CAPD_State;
            parameters[5].Value = model.CAPD_Money;
            parameters[6].Value = model.CAPD_Details;
            parameters[7].Value = model.CAPD_FID;
            parameters[8].Value = model.CAPD_Number;
            parameters[9].Value = model.CAPD_Price;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cw_Accounting_PaymentDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cw_Accounting_PaymentDetails set ");
            strSql.Append("CAPD_CARID=@CAPD_CARID,");
            strSql.Append("CAPD_yTime=@CAPD_yTime,");
            strSql.Append("CAPD_Order=@CAPD_Order,");
            strSql.Append("CAPD_State=@CAPD_State,");
            strSql.Append("CAPD_Money=@CAPD_Money,");
            strSql.Append("CAPD_Details=@CAPD_Details,");
            strSql.Append("CAPD_FID=@CAPD_FID,");
            strSql.Append("CAPD_Number=@CAPD_Number,");
            strSql.Append("CAPD_Price=@CAPD_Price");
            strSql.Append(" where CAPD_ID=@CAPD_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAPD_CARID", SqlDbType.VarChar,50),
					new SqlParameter("@CAPD_yTime", SqlDbType.DateTime),
					new SqlParameter("@CAPD_Order", SqlDbType.Int,4),
					new SqlParameter("@CAPD_State", SqlDbType.Int,4),
					new SqlParameter("@CAPD_Money", SqlDbType.Decimal,9),
					new SqlParameter("@CAPD_Details", SqlDbType.VarChar,50),
					new SqlParameter("@CAPD_FID", SqlDbType.VarChar,50),
					new SqlParameter("@CAPD_Number", SqlDbType.Decimal,9),
					new SqlParameter("@CAPD_Price", SqlDbType.Decimal,9),
					new SqlParameter("@CAPD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CAPD_CARID;
            parameters[1].Value = model.CAPD_yTime;
            parameters[2].Value = model.CAPD_Order;
            parameters[3].Value = model.CAPD_State;
            parameters[4].Value = model.CAPD_Money;
            parameters[5].Value = model.CAPD_Details;
            parameters[6].Value = model.CAPD_FID;
            parameters[7].Value = model.CAPD_Number;
            parameters[8].Value = model.CAPD_Price;
            parameters[9].Value = model.CAPD_ID;

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
        public bool Delete(string CAPD_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cw_Accounting_PaymentDetails ");
            strSql.Append(" where CAPD_ID=@CAPD_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAPD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAPD_ID;

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
        public bool DeleteyCARID(string CAPD_CARID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cw_Accounting_PaymentDetails ");
            strSql.Append(" where CAPD_CARID=@CAPD_CARID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAPD_CARID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAPD_CARID;

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
        public bool DeleteList(string CAPD_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cw_Accounting_PaymentDetails ");
            strSql.Append(" where CAPD_ID in (" + CAPD_IDlist + ")  ");
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
        public KNet.Model.Cw_Accounting_PaymentDetails GetModel(string CAPD_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CAPD_ID,CAPD_CARID,CAPD_yTime,CAPD_Order,CAPD_State,CAPD_Money,CAPD_Details from Cw_Accounting_PaymentDetails ");
            strSql.Append(" where CAPD_ID=@CAPD_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAPD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAPD_ID;

            KNet.Model.Cw_Accounting_PaymentDetails model = new KNet.Model.Cw_Accounting_PaymentDetails();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CAPD_ID"] != null && ds.Tables[0].Rows[0]["CAPD_ID"].ToString() != "")
                {
                    model.CAPD_ID = ds.Tables[0].Rows[0]["CAPD_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAPD_CARID"] != null && ds.Tables[0].Rows[0]["CAPD_CARID"].ToString() != "")
                {
                    model.CAPD_CARID = ds.Tables[0].Rows[0]["CAPD_CARID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAPD_yTime"] != null && ds.Tables[0].Rows[0]["CAPD_yTime"].ToString() != "")
                {
                    model.CAPD_yTime = DateTime.Parse(ds.Tables[0].Rows[0]["CAPD_yTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAPD_Order"] != null && ds.Tables[0].Rows[0]["CAPD_Order"].ToString() != "")
                {
                    model.CAPD_Order = int.Parse(ds.Tables[0].Rows[0]["CAPD_Order"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAPD_State"] != null && ds.Tables[0].Rows[0]["CAPD_State"].ToString() != "")
                {
                    model.CAPD_State = int.Parse(ds.Tables[0].Rows[0]["CAPD_State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAPD_Money"] != null && ds.Tables[0].Rows[0]["CAPD_Money"].ToString() != "")
                {
                    model.CAPD_Money = decimal.Parse(ds.Tables[0].Rows[0]["CAPD_Money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAPD_Details"] != null && ds.Tables[0].Rows[0]["CAPD_Details"].ToString() != "")
                {
                    model.CAPD_Details = ds.Tables[0].Rows[0]["CAPD_Details"].ToString();
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
            strSql.Append(" FROM Cw_Accounting_PaymentDetails  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByLeft(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 LeftMoney as CAPD_Money,LeftMoney/a.CAPD_Price as CAPD_Number,* ");
            strSql.Append(" FROM Cw_Accounting_PaymentDetails a join Cw_Payment_BillSum b  on a.CAPD_ID=b.V_ID  and  b.v_State<>'2'");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("and CAPD_Details in ('调整','') order by CAPD_Details desc");
            
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
            strSql.Append(" CAPD_ID,CAPD_CARID,CAPD_yTime,CAPD_Order,CAPD_State,CAPD_Money,CAPD_Details ");
            strSql.Append(" FROM Cw_Accounting_PaymentDetails ");
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
            parameters[0].Value = "Cw_Accounting_PaymentDetails";
            parameters[1].Value = "CAPD_ID";
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


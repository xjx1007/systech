using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Cw_Accounting_Pay_Details
    /// </summary>
    public partial class Cw_Accounting_Pay_Details
    {
        public Cw_Accounting_Pay_Details()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CAY_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cw_Accounting_Pay_Details");
            strSql.Append(" where CAY_ID=@CAY_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAY_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAY_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cw_Accounting_Pay_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cw_Accounting_Pay_Details(");
            strSql.Append("CAY_ID,CAY_CAAID,CAY_CAPID,CAY_PayMoney,CAY_Order)");
            strSql.Append(" values (");
            strSql.Append("dbo.GetID(),@CAY_CAAID,@CAY_CAPID,@CAY_PayMoney,@CAY_Order)");
            SqlParameter[] parameters = {
					new SqlParameter("@CAY_CAAID", SqlDbType.VarChar,50),
					new SqlParameter("@CAY_CAPID", SqlDbType.VarChar,50),
					new SqlParameter("@CAY_PayMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CAY_Order", SqlDbType.Int,4)};
            parameters[0].Value = model.CAY_CAAID;
            parameters[1].Value = model.CAY_CAPID;
            parameters[2].Value = model.CAY_PayMoney;
            parameters[3].Value = model.CAY_Order;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cw_Accounting_Pay_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cw_Accounting_Pay_Details set ");
            strSql.Append("CAY_ID=@CAY_ID,");
            strSql.Append("CAY_CAAID=@CAY_CAAID,");
            strSql.Append("CAY_CAPID=@CAY_CAPID,");
            strSql.Append("CAY_PayMoney=@CAY_PayMoney,");
            strSql.Append("CAY_Order=@CAY_Order");
            strSql.Append(" where CAY_ID=@CAY_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAY_ID", SqlDbType.VarChar,50),
					new SqlParameter("@CAY_CAAID", SqlDbType.VarChar,50),
					new SqlParameter("@CAY_CAPID", SqlDbType.VarChar,50),
					new SqlParameter("@CAY_PayMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CAY_Order", SqlDbType.Int,4)};
            parameters[0].Value = model.CAY_ID;
            parameters[1].Value = model.CAY_CAAID;
            parameters[2].Value = model.CAY_CAPID;
            parameters[3].Value = model.CAY_PayMoney;
            parameters[4].Value = model.CAY_Order;

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
        public bool Delete(string CAY_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cw_Accounting_Pay_Details ");
            strSql.Append(" where CAY_ID=@CAY_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAY_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAY_ID;

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
        public bool DeleteByCAAID(string CAY_CAAID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cw_Accounting_Pay_Details ");
            strSql.Append(" where CAY_CAAID=@CAY_CAAID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAY_CAAID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAY_CAAID;

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
        public bool DeleteList(string CAY_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cw_Accounting_Pay_Details ");
            strSql.Append(" where CAY_ID in (" + CAY_IDlist + ")  ");
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
        public KNet.Model.Cw_Accounting_Pay_Details GetModel(string CAY_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CAY_ID,CAY_CAAID,CAY_CAPID,CAY_PayMoney,CAY_Order from Cw_Accounting_Pay_Details ");
            strSql.Append(" where CAY_ID=@CAY_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAY_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAY_ID;

            KNet.Model.Cw_Accounting_Pay_Details model = new KNet.Model.Cw_Accounting_Pay_Details();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CAY_ID"] != null && ds.Tables[0].Rows[0]["CAY_ID"].ToString() != "")
                {
                    model.CAY_ID = ds.Tables[0].Rows[0]["CAY_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAY_CAAID"] != null && ds.Tables[0].Rows[0]["CAY_CAAID"].ToString() != "")
                {
                    model.CAY_CAAID = ds.Tables[0].Rows[0]["CAY_CAAID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAY_CAPID"] != null && ds.Tables[0].Rows[0]["CAY_CAPID"].ToString() != "")
                {
                    model.CAY_CAPID = ds.Tables[0].Rows[0]["CAY_CAPID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAY_PayMoney"] != null && ds.Tables[0].Rows[0]["CAY_PayMoney"].ToString() != "")
                {
                    model.CAY_PayMoney = decimal.Parse(ds.Tables[0].Rows[0]["CAY_PayMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAY_Order"] != null && ds.Tables[0].Rows[0]["CAY_Order"].ToString() != "")
                {
                    model.CAY_Order = int.Parse(ds.Tables[0].Rows[0]["CAY_Order"].ToString());
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
            strSql.Append("select CAY_ID,CAY_CAAID,CAY_CAPID,CAY_PayMoney,CAY_Order ");
            strSql.Append(" FROM Cw_Accounting_Pay_Details ");
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
            strSql.Append(" CAY_ID,CAY_CAAID,CAY_CAPID,CAY_PayMoney,CAY_Order ");
            strSql.Append(" FROM Cw_Accounting_Pay_Details ");
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
            parameters[0].Value = "Cw_Accounting_Pay_Details";
            parameters[1].Value = "CAY_ID";
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


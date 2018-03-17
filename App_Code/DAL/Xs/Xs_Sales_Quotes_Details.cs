using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Xs_Sales_Quotes_Details
    /// </summary>
    public partial class Xs_Sales_Quotes_Details
    {
        public Xs_Sales_Quotes_Details()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SQD_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Xs_Sales_Quotes_Details");
            strSql.Append(" where SQD_ID=@SQD_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SQD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SQD_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Sales_Quotes_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Xs_Sales_Quotes_Details(");
            strSql.Append("SQD_ID,SQD_FID,SQD_ProductsBarCode,SQD_Number,SQD_Price,SQD_Money,SQD_Percent,SQD_PercentedMoney,SQD_Remarks)");
            strSql.Append(" values (");
            strSql.Append("@SQD_ID,@SQD_FID,@SQD_ProductsBarCode,@SQD_Number,@SQD_Price,@SQD_Money,@SQD_Percent,@SQD_PercentedMoney,@SQD_Remarks)");
            SqlParameter[] parameters = {
					new SqlParameter("@SQD_ID", SqlDbType.VarChar,50),
					new SqlParameter("@SQD_FID", SqlDbType.VarChar,50),
					new SqlParameter("@SQD_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@SQD_Number", SqlDbType.Decimal,9),
					new SqlParameter("@SQD_Price", SqlDbType.Decimal,9),
					new SqlParameter("@SQD_Money", SqlDbType.Decimal,9),
					new SqlParameter("@SQD_Percent", SqlDbType.Decimal,9),
					new SqlParameter("@SQD_PercentedMoney", SqlDbType.Decimal,9),
					new SqlParameter("@SQD_Remarks", SqlDbType.VarChar,100)};
            parameters[0].Value = model.SQD_ID;
            parameters[1].Value = model.SQD_FID;
            parameters[2].Value = model.SQD_ProductsBarCode;
            parameters[3].Value = model.SQD_Number;
            parameters[4].Value = model.SQD_Price;
            parameters[5].Value = model.SQD_Money;
            parameters[6].Value = model.SQD_Percent;
            parameters[7].Value = model.SQD_PercentedMoney;
            parameters[8].Value = model.SQD_Remarks;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Sales_Quotes_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Xs_Sales_Quotes_Details set ");
            strSql.Append("SQD_FID=@SQD_FID,");
            strSql.Append("SQD_ProductsBarCode=@SQD_ProductsBarCode,");
            strSql.Append("SQD_Number=@SQD_Number,");
            strSql.Append("SQD_Price=@SQD_Price,");
            strSql.Append("SQD_Money=@SQD_Money,");
            strSql.Append("SQD_Percent=@SQD_Percent,");
            strSql.Append("SQD_PercentedMoney=@SQD_PercentedMoney,");
            strSql.Append("SQD_Remarks=@SQD_Remarks");
            strSql.Append(" where SQD_ID=@SQD_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SQD_FID", SqlDbType.VarChar,50),
					new SqlParameter("@SQD_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@SQD_Number", SqlDbType.Decimal,9),
					new SqlParameter("@SQD_Price", SqlDbType.Decimal,9),
					new SqlParameter("@SQD_Money", SqlDbType.Decimal,9),
					new SqlParameter("@SQD_Percent", SqlDbType.Decimal,9),
					new SqlParameter("@SQD_PercentedMoney", SqlDbType.Decimal,9),
					new SqlParameter("@SQD_Remarks", SqlDbType.VarChar,100),
					new SqlParameter("@SQD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SQD_FID;
            parameters[1].Value = model.SQD_ProductsBarCode;
            parameters[2].Value = model.SQD_Number;
            parameters[3].Value = model.SQD_Price;
            parameters[4].Value = model.SQD_Money;
            parameters[5].Value = model.SQD_Percent;
            parameters[6].Value = model.SQD_PercentedMoney;
            parameters[7].Value = model.SQD_Remarks;
            parameters[8].Value = model.SQD_ID;

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
        public bool Delete(string SQD_FID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Sales_Quotes_Details ");
            strSql.Append(" where SQD_FID=@SQD_FID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SQD_FID", SqlDbType.VarChar,50)};
            parameters[0].Value = SQD_FID;

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
        public bool DeleteList(string SQD_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Sales_Quotes_Details ");
            strSql.Append(" where SQD_ID in (" + SQD_IDlist + ")  ");
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
        public KNet.Model.Xs_Sales_Quotes_Details GetModel(string SQD_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Xs_Sales_Quotes_Details ");
            strSql.Append(" where SQD_ID=@SQD_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SQD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SQD_ID;

            KNet.Model.Xs_Sales_Quotes_Details model = new KNet.Model.Xs_Sales_Quotes_Details();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SQD_ID"] != null && ds.Tables[0].Rows[0]["SQD_ID"].ToString() != "")
                {
                    model.SQD_ID = ds.Tables[0].Rows[0]["SQD_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SQD_FID"] != null && ds.Tables[0].Rows[0]["SQD_FID"].ToString() != "")
                {
                    model.SQD_FID = ds.Tables[0].Rows[0]["SQD_FID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SQD_ProductsBarCode"] != null && ds.Tables[0].Rows[0]["SQD_ProductsBarCode"].ToString() != "")
                {
                    model.SQD_ProductsBarCode = ds.Tables[0].Rows[0]["SQD_ProductsBarCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SQD_Number"] != null && ds.Tables[0].Rows[0]["SQD_Number"].ToString() != "")
                {
                    model.SQD_Number = decimal.Parse(ds.Tables[0].Rows[0]["SQD_Number"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SQD_Price"] != null && ds.Tables[0].Rows[0]["SQD_Price"].ToString() != "")
                {
                    model.SQD_Price = decimal.Parse(ds.Tables[0].Rows[0]["SQD_Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SQD_Money"] != null && ds.Tables[0].Rows[0]["SQD_Money"].ToString() != "")
                {
                    model.SQD_Money = decimal.Parse(ds.Tables[0].Rows[0]["SQD_Money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SQD_Percent"] != null && ds.Tables[0].Rows[0]["SQD_Percent"].ToString() != "")
                {
                    model.SQD_Percent = decimal.Parse(ds.Tables[0].Rows[0]["SQD_Percent"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SQD_PercentedMoney"] != null && ds.Tables[0].Rows[0]["SQD_PercentedMoney"].ToString() != "")
                {
                    model.SQD_PercentedMoney = decimal.Parse(ds.Tables[0].Rows[0]["SQD_PercentedMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SQD_Remarks"] != null && ds.Tables[0].Rows[0]["SQD_Remarks"].ToString() != "")
                {
                    model.SQD_Remarks = ds.Tables[0].Rows[0]["SQD_Remarks"].ToString();
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
            strSql.Append(" FROM Xs_Sales_Quotes_Details ");
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
            strSql.Append(" FROM Xs_Sales_Quotes_Details ");
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
            parameters[0].Value = "Xs_Sales_Quotes_Details";
            parameters[1].Value = "SQD_ID";
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


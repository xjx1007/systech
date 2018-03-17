using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Sc_Expend_Manage_RCDetails
    /// </summary>
    public partial class Sc_Expend_Manage_RCDetails
    {
        public Sc_Expend_Manage_RCDetails()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SER_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sc_Expend_Manage_RCDetails");
            strSql.Append(" where SER_ID=@SER_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SER_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SER_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Sc_Expend_Manage_RCDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sc_Expend_Manage_RCDetails(");
            strSql.Append("SER_ID,SER_SEMID,SER_OrderDetailID,SER_ProductsBarCode,SER_ScNumber,SER_ScPrice,SER_ScMoney,SER_HouseNo,SER_ScHandPrice,SER_ScHandMoney)");
            strSql.Append(" values (");
            strSql.Append("@SER_ID,@SER_SEMID,@SER_OrderDetailID,@SER_ProductsBarCode,@SER_ScNumber,@SER_ScPrice,@SER_ScMoney,@SER_HouseNo,@SER_ScHandPrice,@SER_ScHandMoney)");
            SqlParameter[] parameters = {
					new SqlParameter("@SER_ID", SqlDbType.VarChar,50),
					new SqlParameter("@SER_SEMID", SqlDbType.VarChar,50),
					new SqlParameter("@SER_OrderDetailID", SqlDbType.VarChar,50),
					new SqlParameter("@SER_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@SER_ScNumber", SqlDbType.Int,4),
					new SqlParameter("@SER_ScPrice", SqlDbType.Decimal,9),
					new SqlParameter("@SER_ScMoney", SqlDbType.Decimal,9),
					new SqlParameter("@SER_HouseNo", SqlDbType.VarChar,50),
					new SqlParameter("@SER_ScHandPrice", SqlDbType.Decimal,9),
					new SqlParameter("@SER_ScHandMoney", SqlDbType.Decimal,9)};
            parameters[0].Value = model.SER_ID;
            parameters[1].Value = model.SER_SEMID;
            parameters[2].Value = model.SER_OrderDetailID;
            parameters[3].Value = model.SER_ProductsBarCode;
            parameters[4].Value = model.SER_ScNumber;
            parameters[5].Value = model.SER_ScPrice;
            parameters[6].Value = model.SER_ScMoney;
            parameters[7].Value = model.SER_HouseNo;
            parameters[8].Value = model.SER_ScHandPrice;
            parameters[9].Value = model.SER_ScHandMoney;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Sc_Expend_Manage_RCDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sc_Expend_Manage_RCDetails set ");
            strSql.Append("SER_SEMID=@SER_SEMID,");
            strSql.Append("SER_OrderDetailID=@SER_OrderDetailID,");
            strSql.Append("SER_ProductsBarCode=@SER_ProductsBarCode,");
            strSql.Append("SER_ScNumber=@SER_ScNumber,");
            strSql.Append("SER_ScPrice=@SER_ScPrice,");
            strSql.Append("SER_ScMoney=@SER_ScMoney");
            strSql.Append(" where SER_ID=@SER_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SER_SEMID", SqlDbType.VarChar,50),
					new SqlParameter("@SER_OrderDetailID", SqlDbType.VarChar,50),
					new SqlParameter("@SER_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@SER_ScNumber", SqlDbType.Int,4),
					new SqlParameter("@SER_ScPrice", SqlDbType.Decimal,9),
					new SqlParameter("@SER_ScMoney", SqlDbType.Decimal,9),
					new SqlParameter("@SER_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SER_SEMID;
            parameters[1].Value = model.SER_OrderDetailID;
            parameters[2].Value = model.SER_ProductsBarCode;
            parameters[3].Value = model.SER_ScNumber;
            parameters[4].Value = model.SER_ScPrice;
            parameters[5].Value = model.SER_ScMoney;
            parameters[6].Value = model.SER_ID;

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
        public bool Delete(string SER_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sc_Expend_Manage_RCDetails ");
            strSql.Append(" where SER_ID=@SER_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SER_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SER_ID;

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
        public bool DeleteList(string SER_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sc_Expend_Manage_RCDetails ");
            strSql.Append(" where SER_ID in (" + SER_IDlist + ")  ");
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
        public KNet.Model.Sc_Expend_Manage_RCDetails GetModel(string SER_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SER_ID,SER_SEMID,SER_OrderDetailID,SER_ProductsBarCode,SER_ScNumber,SER_ScPrice,SER_ScMoney from Sc_Expend_Manage_RCDetails ");
            strSql.Append(" where SER_ID=@SER_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SER_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SER_ID;

            KNet.Model.Sc_Expend_Manage_RCDetails model = new KNet.Model.Sc_Expend_Manage_RCDetails();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SER_ID"] != null && ds.Tables[0].Rows[0]["SER_ID"].ToString() != "")
                {
                    model.SER_ID = ds.Tables[0].Rows[0]["SER_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SER_SEMID"] != null && ds.Tables[0].Rows[0]["SER_SEMID"].ToString() != "")
                {
                    model.SER_SEMID = ds.Tables[0].Rows[0]["SER_SEMID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SER_OrderDetailID"] != null && ds.Tables[0].Rows[0]["SER_OrderDetailID"].ToString() != "")
                {
                    model.SER_OrderDetailID = ds.Tables[0].Rows[0]["SER_OrderDetailID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SER_ProductsBarCode"] != null && ds.Tables[0].Rows[0]["SER_ProductsBarCode"].ToString() != "")
                {
                    model.SER_ProductsBarCode = ds.Tables[0].Rows[0]["SER_ProductsBarCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SER_ScNumber"] != null && ds.Tables[0].Rows[0]["SER_ScNumber"].ToString() != "")
                {
                    model.SER_ScNumber = int.Parse(ds.Tables[0].Rows[0]["SER_ScNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SER_ScPrice"] != null && ds.Tables[0].Rows[0]["SER_ScPrice"].ToString() != "")
                {
                    model.SER_ScPrice = decimal.Parse(ds.Tables[0].Rows[0]["SER_ScPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SER_ScMoney"] != null && ds.Tables[0].Rows[0]["SER_ScMoney"].ToString() != "")
                {
                    model.SER_ScMoney = decimal.Parse(ds.Tables[0].Rows[0]["SER_ScMoney"].ToString());
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
            strSql.Append("select *");
            strSql.Append(" FROM Sc_Expend_Manage_RCDetails ");
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
            strSql.Append(" SER_ID,SER_SEMID,SER_OrderDetailID,SER_ProductsBarCode,SER_ScNumber,SER_ScPrice,SER_ScMoney ");
            strSql.Append(" FROM Sc_Expend_Manage_RCDetails ");
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
            parameters[0].Value = "Sc_Expend_Manage_RCDetails";
            parameters[1].Value = "SER_ID";
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


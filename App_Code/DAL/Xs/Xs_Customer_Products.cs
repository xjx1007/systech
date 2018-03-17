using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Xs_Customer_Products
    /// </summary>
    public partial class Xs_Customer_Products
    {
        public Xs_Customer_Products()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XCP_ID, string XCP_CustomerID, string XCP_ProductsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Xs_Customer_Products");
            strSql.Append(" where XCP_ID=@XCP_ID and XCP_CustomerID=@XCP_CustomerID and XCP_ProductsID=@XCP_ProductsID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCP_ID", SqlDbType.VarChar,50),
					new SqlParameter("@XCP_CustomerID", SqlDbType.VarChar,50),
					new SqlParameter("@XCP_ProductsID", SqlDbType.VarChar,50)};
            parameters[0].Value = XCP_ID;
            parameters[1].Value = XCP_CustomerID;
            parameters[2].Value = XCP_ProductsID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Customer_Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Xs_Customer_Products(");
            strSql.Append("XCP_ID,XCP_CustomerID,XCP_ProductsID)");
            strSql.Append(" values (");
            strSql.Append("@XCP_ID,@XCP_CustomerID,@XCP_ProductsID)");
            SqlParameter[] parameters = {
					new SqlParameter("@XCP_ID", SqlDbType.VarChar,50),
					new SqlParameter("@XCP_CustomerID", SqlDbType.VarChar,50),
					new SqlParameter("@XCP_ProductsID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.XCP_ID;
            parameters[1].Value = model.XCP_CustomerID;
            parameters[2].Value = model.XCP_ProductsID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Customer_Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Xs_Customer_Products set ");
            strSql.Append("XCP_ID=@XCP_ID,");
            strSql.Append("XCP_CustomerID=@XCP_CustomerID,");
            strSql.Append("XCP_ProductsID=@XCP_ProductsID");
            strSql.Append(" where XCP_ID=@XCP_ID and XCP_CustomerID=@XCP_CustomerID and XCP_ProductsID=@XCP_ProductsID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCP_ID", SqlDbType.VarChar,50),
					new SqlParameter("@XCP_CustomerID", SqlDbType.VarChar,50),
					new SqlParameter("@XCP_ProductsID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.XCP_ID;
            parameters[1].Value = model.XCP_CustomerID;
            parameters[2].Value = model.XCP_ProductsID;

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
        public bool Delete(string XCP_ProductsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Customer_Products ");
            strSql.Append(" where XCP_ProductsID=@XCP_ProductsID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCP_ProductsID", SqlDbType.VarChar,50)};
            parameters[0].Value = XCP_ProductsID;

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
        public bool DeleteByCustomer(string XCP_CustomerID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Customer_Products ");
            strSql.Append(" where XCP_CustomerID=@XCP_CustomerID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCP_CustomerID", SqlDbType.VarChar,50)};
            parameters[0].Value = XCP_CustomerID;

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
        public bool DeleteByCustomerAndProducts(string XCP_CustomerID, string s_ProductsBarCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Customer_Products ");
            strSql.Append(" where XCP_CustomerID=@XCP_CustomerID and XCP_ProductsID=@XCP_ProductsID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCP_CustomerID", SqlDbType.VarChar,50),
					new SqlParameter("@XCP_ProductsID", SqlDbType.VarChar,50)};
            parameters[0].Value = XCP_CustomerID;
            parameters[1].Value = s_ProductsBarCode;

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
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Xs_Customer_Products GetModel(string XCP_ID, string XCP_CustomerID, string XCP_ProductsID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 XCP_ID,XCP_CustomerID,XCP_ProductsID from Xs_Customer_Products ");
            strSql.Append(" where XCP_ID=@XCP_ID and XCP_CustomerID=@XCP_CustomerID and XCP_ProductsID=@XCP_ProductsID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCP_ID", SqlDbType.VarChar,50),
					new SqlParameter("@XCP_CustomerID", SqlDbType.VarChar,50),
					new SqlParameter("@XCP_ProductsID", SqlDbType.VarChar,50)};
            parameters[0].Value = XCP_ID;
            parameters[1].Value = XCP_CustomerID;
            parameters[2].Value = XCP_ProductsID;

            KNet.Model.Xs_Customer_Products model = new KNet.Model.Xs_Customer_Products();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["XCP_ID"] != null && ds.Tables[0].Rows[0]["XCP_ID"].ToString() != "")
                {
                    model.XCP_ID = ds.Tables[0].Rows[0]["XCP_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XCP_CustomerID"] != null && ds.Tables[0].Rows[0]["XCP_CustomerID"].ToString() != "")
                {
                    model.XCP_CustomerID = ds.Tables[0].Rows[0]["XCP_CustomerID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XCP_ProductsID"] != null && ds.Tables[0].Rows[0]["XCP_ProductsID"].ToString() != "")
                {
                    model.XCP_ProductsID = ds.Tables[0].Rows[0]["XCP_ProductsID"].ToString();
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
            strSql.Append("select XCP_ID,XCP_CustomerID,XCP_ProductsID ");
            strSql.Append(" FROM Xs_Customer_Products ");
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
            strSql.Append(" XCP_ID,XCP_CustomerID,XCP_ProductsID ");
            strSql.Append(" FROM Xs_Customer_Products ");
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
            parameters[0].Value = "Xs_Customer_Products";
            parameters[1].Value = "XCP_ProductsID";
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


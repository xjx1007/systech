using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Xs_Products_Prodocts
    /// </summary>
    public partial class Xs_Products_Prodocts
    {
        public Xs_Products_Prodocts()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XPP_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Xs_Products_Prodocts");
            strSql.Append(" where XPP_ID=@XPP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XPP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XPP_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Products_Prodocts model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Xs_Products_Prodocts(");
            strSql.Append("XPP_ID,XPP_ProductsBarCode,XPP_SuppNo,XPP_Price,XPP_Number,XPP_FaterBarCode,XPP_IsOrder,XPP_Address,XPP_CgID)");
            strSql.Append(" values (");
            strSql.Append("@XPP_ID,@XPP_ProductsBarCode,@XPP_SuppNo,@XPP_Price,@XPP_Number,@XPP_FaterBarCode,@XPP_IsOrder,@XPP_Address,@XPP_CgID)");
            SqlParameter[] parameters = {
					new SqlParameter("@XPP_ID", SqlDbType.VarChar,50),
					new SqlParameter("@XPP_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@XPP_SuppNo", SqlDbType.VarChar,50),
					new SqlParameter("@XPP_Price", SqlDbType.Decimal,9),
					new SqlParameter("@XPP_Number", SqlDbType.Decimal,9),
					new SqlParameter("@XPP_FaterBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@XPP_IsOrder", SqlDbType.VarChar,50),
					new SqlParameter("@XPP_Address", SqlDbType.VarChar,50),
					new SqlParameter("@XPP_CgID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.XPP_ID;
            parameters[1].Value = model.XPP_ProductsBarCode;
            parameters[2].Value = model.XPP_SuppNo;
            parameters[3].Value = model.XPP_Price;
            parameters[4].Value = model.XPP_Number;
            parameters[5].Value = model.XPP_FaterBarCode;
            parameters[6].Value = model.XPP_IsOrder;
            parameters[7].Value = model.XPP_Address;
            parameters[8].Value = model.XPP_CgID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Products_Prodocts model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Xs_Products_Prodocts set ");
            strSql.Append("XPP_ProductsBarCode=@XPP_ProductsBarCode,");
            strSql.Append("XPP_SuppNo=@XPP_SuppNo,");
            strSql.Append("XPP_Price=@XPP_Price,");
            strSql.Append("XPP_Number=@XPP_Number");
            strSql.Append(" where XPP_ID=@XPP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XPP_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@XPP_SuppNo", SqlDbType.VarChar,50),
					new SqlParameter("@XPP_Price", SqlDbType.Decimal,9),
					new SqlParameter("@XPP_Number", SqlDbType.Decimal,9),
					new SqlParameter("@XPP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.XPP_ProductsBarCode;
            parameters[1].Value = model.XPP_SuppNo;
            parameters[2].Value = model.XPP_Price;
            parameters[3].Value = model.XPP_Number;
            parameters[4].Value = model.XPP_ID;

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
        public bool Delete(string XPP_FaterBarCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Products_Prodocts ");
            strSql.Append(" where XPP_FaterBarCode=@XPP_FaterBarCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@XPP_FaterBarCode", SqlDbType.VarChar,50)};
            parameters[0].Value = XPP_FaterBarCode;

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
        public bool DeleteList(string XPP_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Products_Prodocts ");
            strSql.Append(" where XPP_ID in (" + XPP_IDlist + ")  ");
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
        public KNet.Model.Xs_Products_Prodocts GetModel(string XPP_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 XPP_ID,XPP_ProductsBarCode,XPP_SuppNo,XPP_Price,XPP_Number from Xs_Products_Prodocts ");
            strSql.Append(" where XPP_ID=@XPP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XPP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XPP_ID;

            KNet.Model.Xs_Products_Prodocts model = new KNet.Model.Xs_Products_Prodocts();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["XPP_ID"] != null && ds.Tables[0].Rows[0]["XPP_ID"].ToString() != "")
                {
                    model.XPP_ID = ds.Tables[0].Rows[0]["XPP_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XPP_ProductsBarCode"] != null && ds.Tables[0].Rows[0]["XPP_ProductsBarCode"].ToString() != "")
                {
                    model.XPP_ProductsBarCode = ds.Tables[0].Rows[0]["XPP_ProductsBarCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XPP_SuppNo"] != null && ds.Tables[0].Rows[0]["XPP_SuppNo"].ToString() != "")
                {
                    model.XPP_SuppNo = ds.Tables[0].Rows[0]["XPP_SuppNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XPP_Price"] != null && ds.Tables[0].Rows[0]["XPP_Price"].ToString() != "")
                {
                    model.XPP_Price = decimal.Parse(ds.Tables[0].Rows[0]["XPP_Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XPP_Number"] != null && ds.Tables[0].Rows[0]["XPP_Number"].ToString() != "")
                {
                    model.XPP_Number = decimal.Parse(ds.Tables[0].Rows[0]["XPP_Number"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Xs_Products_Prodocts GetModelByProducts(string XPP_ProductsBarCode, string XPP_FaterBarCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Xs_Products_Prodocts ");
            strSql.Append(" where XPP_ProductsBarCode=@XPP_ProductsBarCode and XPP_FaterBarCode=@XPP_FaterBarCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@XPP_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@XPP_FaterBarCode", SqlDbType.VarChar,50)};
            parameters[0].Value = XPP_ProductsBarCode;
            parameters[1].Value = XPP_FaterBarCode;

            KNet.Model.Xs_Products_Prodocts model = new KNet.Model.Xs_Products_Prodocts();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["XPP_ID"] != null && ds.Tables[0].Rows[0]["XPP_ID"].ToString() != "")
                {
                    model.XPP_ID = ds.Tables[0].Rows[0]["XPP_ID"].ToString();
                }
                else
                {
                    model.XPP_ID = "";
                }
                if (ds.Tables[0].Rows[0]["XPP_ProductsBarCode"] != null && ds.Tables[0].Rows[0]["XPP_ProductsBarCode"].ToString() != "")
                {
                    model.XPP_ProductsBarCode = ds.Tables[0].Rows[0]["XPP_ProductsBarCode"].ToString();
                }
                else
                {
                    model.XPP_ProductsBarCode = "";
                }
                if (ds.Tables[0].Rows[0]["XPP_SuppNo"] != null && ds.Tables[0].Rows[0]["XPP_SuppNo"].ToString() != "")
                {
                    model.XPP_SuppNo = ds.Tables[0].Rows[0]["XPP_SuppNo"].ToString();
                }
                else
                {
                    model.XPP_SuppNo = "";
                }
                if (ds.Tables[0].Rows[0]["XPP_Price"] != null && ds.Tables[0].Rows[0]["XPP_Price"].ToString() != "")
                {
                    model.XPP_Price = decimal.Parse(ds.Tables[0].Rows[0]["XPP_Price"].ToString());
                }
                else
                {
                    model.XPP_Price = 0;
                }
                if (ds.Tables[0].Rows[0]["XPP_Number"] != null && ds.Tables[0].Rows[0]["XPP_Number"].ToString() != "")
                {
                    model.XPP_Number = decimal.Parse(ds.Tables[0].Rows[0]["XPP_Number"].ToString());
                }
                else
                {
                    model.XPP_Number = 0;
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
            strSql.Append(" FROM Xs_Products_Prodocts a join KNet_Sys_Products b on a.XPP_ProductsBarCode=b.ProductsBarCode ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// 获得数据列表
        /// </summary>
        public DataSet GetListWithType(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM PB_Basic_ProductsClass c  left join (Select * from KNet_Sys_Products b join  Xs_Products_Prodocts a on a.XPP_ProductsBarCode=b.ProductsBarCode  " + strWhere + ") bb on bb.ProductsType=c.PBP_ID  ");

            KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
            string s_SonID = Bll_ProductsDetails.GetSonIDs("M160818111423567");
            
            //s_SonID = s_SonID.Replace("M160818111423567,", "");
            s_SonID = s_SonID.Replace(",", "','");
            string s_sql = "  PBP_ID in ('" + s_SonID + "') ";
            strSql.Append(" where " + s_sql + "  Order by cast(PBP_Order as int)");
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
            strSql.Append(" XPP_ID,XPP_ProductsBarCode,XPP_SuppNo,XPP_Price,XPP_Number ");
            strSql.Append(" FROM Xs_Products_Prodocts ");
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
            parameters[0].Value = "Xs_Products_Prodocts";
            parameters[1].Value = "XPP_ID";
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


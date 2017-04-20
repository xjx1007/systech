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
    /// 数据访问类:Xs_Products_Prodocts_Demo
    /// </summary>
    public partial class Xs_Products_Prodocts_Demo
    {
        public Xs_Products_Prodocts_Demo()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XPD_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Xs_Products_Prodocts_Demo");
            strSql.Append(" where XPD_ID=@XPD_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XPD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XPD_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Products_Prodocts_Demo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Xs_Products_Prodocts_Demo(");
            strSql.Append("XPD_ID,XPD_ProductsBarCode,XPD_SuppNo,XPD_Price,XPD_Number,XPD_FaterBarCode,XPD_IsOrder,XPD_Address,XPD_ReplaceProductsBarCode,XPD_Order,XPD_Only,XPD_Place,XPD_Del)");
            strSql.Append(" values (");
            strSql.Append("@XPD_ID,@XPD_ProductsBarCode,@XPD_SuppNo,@XPD_Price,@XPD_Number,@XPD_FaterBarCode,@XPD_IsOrder,@XPD_Address,@XPD_ReplaceProductsBarCode,@XPD_Order,@XPD_Only,@XPD_Place,@XPD_Del)");
            SqlParameter[] parameters = {
					new SqlParameter("@XPD_ID", SqlDbType.VarChar,50),
					new SqlParameter("@XPD_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@XPD_SuppNo", SqlDbType.VarChar,50),
					new SqlParameter("@XPD_Price", SqlDbType.Decimal,9),
					new SqlParameter("@XPD_Number", SqlDbType.Decimal,9),
					new SqlParameter("@XPD_FaterBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@XPD_IsOrder", SqlDbType.VarChar,50),
					new SqlParameter("@XPD_Address", SqlDbType.VarChar,50),
					new SqlParameter("@XPD_ReplaceProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@XPD_Order", SqlDbType.Int),
					new SqlParameter("@XPD_Only", SqlDbType.Int),
					new SqlParameter("@XPD_Place", SqlDbType.VarChar,550),
					new SqlParameter("@XPD_Del", SqlDbType.Int)
                    
                                        };
            parameters[0].Value = model.XPD_ID;
            parameters[1].Value = model.XPD_ProductsBarCode;
            parameters[2].Value = model.XPD_SuppNo;
            parameters[3].Value = model.XPD_Price;
            parameters[4].Value = model.XPD_Number;
            parameters[5].Value = model.XPD_FaterBarCode;
            parameters[6].Value = model.XPD_IsOrder;
            parameters[7].Value = model.XPD_Address;
            parameters[8].Value = model.XPD_ReplaceProductsBarCode;
            parameters[9].Value = model.XPD_Order;
            parameters[10].Value = model.XPD_Only;
            parameters[11].Value = model.XPD_Place;
            parameters[12].Value = model.XPD_Del;
            
            
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Products_Prodocts_Demo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Xs_Products_Prodocts_Demo set ");
            strSql.Append("XPD_ProductsBarCode=@XPD_ProductsBarCode,");
            strSql.Append("XPD_SuppNo=@XPD_SuppNo,");
            strSql.Append("XPD_Price=@XPD_Price,");
            strSql.Append("XPD_Number=@XPD_Number");
            strSql.Append(" where XPD_ID=@XPD_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XPD_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@XPD_SuppNo", SqlDbType.VarChar,50),
					new SqlParameter("@XPD_Price", SqlDbType.Decimal,9),
					new SqlParameter("@XPD_Number", SqlDbType.Decimal,9),
					new SqlParameter("@XPD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.XPD_ProductsBarCode;
            parameters[1].Value = model.XPD_SuppNo;
            parameters[2].Value = model.XPD_Price;
            parameters[3].Value = model.XPD_Number;
            parameters[4].Value = model.XPD_ID;

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
        /// 更新一条数据
        /// </summary>
        public bool UpdateDel(string[] s_IDs,string s_ProductsBarCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Xs_Products_Prodocts_Demo set ");
            strSql.Append(" XPD_Del=1 ");
            strSql.Append(" where XPD_FaterBarCode='" + s_ProductsBarCode + "' and  XPD_ID not in (");
            for (int i = 0; i < s_IDs.Length; i++)
            {
                strSql.Append("'"+s_IDs[i]+"',");
            }

            strSql.Append("'')");
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string XPD_FaterBarCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Products_Prodocts_Demo ");
            strSql.Append(" where XPD_FaterBarCode=@XPD_FaterBarCode ");

            SqlParameter[] parameters = {
					new SqlParameter("@XPD_FaterBarCode", SqlDbType.VarChar,50)};
            parameters[0].Value = XPD_FaterBarCode;

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
        public bool DeleteByIDs(string[] s_IDs, string XPD_FaterBarCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Products_Prodocts_Demo ");
            strSql.Append(" where XPD_FaterBarCode=@XPD_FaterBarCode and  XPD_ID not in (");
            for (int i = 0; i < s_IDs.Length; i++)
            {
                strSql.Append("'"+s_IDs[i]+"',");
            }
            strSql.Append("'')");
            SqlParameter[] parameters = {
					new SqlParameter("@XPD_FaterBarCode", SqlDbType.VarChar,50)};
            parameters[0].Value = XPD_FaterBarCode;

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
        public bool DeleteList(string XPD_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Products_Prodocts_Demo ");
            strSql.Append(" where XPD_ID in (" + XPD_IDlist + ")  ");
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
        public KNet.Model.Xs_Products_Prodocts_Demo GetModel(string XPD_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Xs_Products_Prodocts_Demo ");
            strSql.Append(" where XPD_ID=@XPD_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XPD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XPD_ID;

            KNet.Model.Xs_Products_Prodocts_Demo model = new KNet.Model.Xs_Products_Prodocts_Demo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["XPD_ID"] != null && ds.Tables[0].Rows[0]["XPD_ID"].ToString() != "")
                {
                    model.XPD_ID = ds.Tables[0].Rows[0]["XPD_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XPD_ProductsBarCode"] != null && ds.Tables[0].Rows[0]["XPD_ProductsBarCode"].ToString() != "")
                {
                    model.XPD_ProductsBarCode = ds.Tables[0].Rows[0]["XPD_ProductsBarCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XPD_SuppNo"] != null && ds.Tables[0].Rows[0]["XPD_SuppNo"].ToString() != "")
                {
                    model.XPD_SuppNo = ds.Tables[0].Rows[0]["XPD_SuppNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XPD_Price"] != null && ds.Tables[0].Rows[0]["XPD_Price"].ToString() != "")
                {
                    model.XPD_Price = decimal.Parse(ds.Tables[0].Rows[0]["XPD_Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XPD_Number"] != null && ds.Tables[0].Rows[0]["XPD_Number"].ToString() != "")
                {
                    model.XPD_Number = decimal.Parse(ds.Tables[0].Rows[0]["XPD_Number"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XPD_ReplaceProductsBarCode"] != null && ds.Tables[0].Rows[0]["XPD_ReplaceProductsBarCode"].ToString() != "")
                {
                    model.XPD_ReplaceProductsBarCode = ds.Tables[0].Rows[0]["XPD_ReplaceProductsBarCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XPD_Order"] != null && ds.Tables[0].Rows[0]["XPD_Order"].ToString() != "")
                {
                    model.XPD_Order = int.Parse(ds.Tables[0].Rows[0]["XPD_Order"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XPD_Only"] != null && ds.Tables[0].Rows[0]["XPD_Only"].ToString() != "")
                {
                    model.XPD_Only = int.Parse(ds.Tables[0].Rows[0]["XPD_Only"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XPD_AddDateTime"] != null && ds.Tables[0].Rows[0]["XPD_AddDateTime"].ToString() != "")
                {
                    model.XPD_AddDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["XPD_AddDateTime"].ToString());
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
        public KNet.Model.Xs_Products_Prodocts_Demo GetModelByProducts(string XPP_ProductsBarCode, string XPP_FaterBarCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Xs_Products_Prodocts_Demo ");
            strSql.Append(" where XPD_ProductsBarCode=@XPP_ProductsBarCode and XPD_FaterBarCode=@XPP_FaterBarCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@XPP_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@XPP_FaterBarCode", SqlDbType.VarChar,50)};
            parameters[0].Value = XPP_ProductsBarCode;
            parameters[1].Value = XPP_FaterBarCode;

            KNet.Model.Xs_Products_Prodocts_Demo model = new KNet.Model.Xs_Products_Prodocts_Demo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["XPD_ID"] != null && ds.Tables[0].Rows[0]["XPD_ID"].ToString() != "")
                {
                    model.XPD_ID = ds.Tables[0].Rows[0]["XPD_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XPD_ProductsBarCode"] != null && ds.Tables[0].Rows[0]["XPD_ProductsBarCode"].ToString() != "")
                {
                    model.XPD_ProductsBarCode = ds.Tables[0].Rows[0]["XPD_ProductsBarCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XPD_SuppNo"] != null && ds.Tables[0].Rows[0]["XPD_SuppNo"].ToString() != "")
                {
                    model.XPD_SuppNo = ds.Tables[0].Rows[0]["XPD_SuppNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XPD_Price"] != null && ds.Tables[0].Rows[0]["XPD_Price"].ToString() != "")
                {
                    model.XPD_Price = decimal.Parse(ds.Tables[0].Rows[0]["XPD_Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XPD_Number"] != null && ds.Tables[0].Rows[0]["XPD_Number"].ToString() != "")
                {
                    model.XPD_Number = decimal.Parse(ds.Tables[0].Rows[0]["XPD_Number"].ToString());
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
            strSql.Append(" FROM Xs_Products_Prodocts_Demo a join KNet_Sys_Products b on XPD_ProductsBarCode=b.ProductsBarCode ");
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
            strSql.Append(" FROM PB_Basic_ProductsClass c  left join (Select * from KNet_Sys_Products b join  Xs_Products_Prodocts_Demo a on a.XPD_ProductsBarCode=b.ProductsBarCode  " + strWhere + " ) bb on bb.ProductsType=c.PBP_ID  ");

            KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
            string s_SonID = Bll_ProductsDetails.GetSonIDs("M160901092354544");
            s_SonID += "," + Bll_ProductsDetails.GetSonIDs("M160818111423567");
            s_SonID = s_SonID.Replace(",M160818111423567", "");
            s_SonID = s_SonID.Replace(",", "','");
            string s_sql = "  PBP_ID in ('" + s_SonID + "') ";
            strSql.Append(" where " + s_sql + "    Order by PBP_Code,cast(PBP_Order as int)");
            return DbHelperSQL.Query(strSql.ToString());
        }




        /// 获得数据列表
        /// </summary>
        public DataSet GetListWithType1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM PB_Basic_ProductsClass c  left join (Select * from KNet_Sys_Products b join  Xs_Products_Prodocts_Demo a on a.XPD_ProductsBarCode=b.ProductsBarCode  " + strWhere + " ) bb on bb.ProductsType=c.PBP_ID  ");

            KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
            string s_SonID = Bll_ProductsDetails.GetSonIDs("M130703044937286");
            s_SonID = s_SonID.Replace("M130703044937286,", "");
            s_SonID = s_SonID.Replace(",", "','");
            string s_sql = "  PBP_ID in ('" + s_SonID + "','M130704023830654') ";
            strSql.Append(" where " + s_sql + " and bb.KSP_Del=0   Order by cast(PBP_Order as int)");
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
            strSql.Append(" XPD_ID,XPD_ProductsBarCode,XPD_SuppNo,XPD_Price,XPD_Number ");
            strSql.Append(" FROM Xs_Products_Prodocts_Demo ");
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
            parameters[0].Value = "Xs_Products_Prodocts_Demo";
            parameters[1].Value = "XPD_ID";
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


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
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Xs_Products_Spce
    /// </summary>
    public partial class Xs_Products_Spce
    {
        public Xs_Products_Spce()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XPS_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Xs_Products_Spce");
            strSql.Append(" where XPS_ID=@XPS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XPS_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XPS_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Products_Spce model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Xs_Products_Spce(");
            strSql.Append("XPS_ID,XPS_ProductsBarCode,XPS_SpceCode,XPS_SpceName,XPS_Details,XPS_Creator,XPS_CTime,XPS_Mender,XPS_MTime)");
            strSql.Append(" values (");
            strSql.Append("@XPS_ID,@XPS_ProductsBarCode,@XPS_SpceCode,@XPS_SpceName,@XPS_Details,@XPS_Creator,@XPS_CTime,@XPS_Mender,@XPS_MTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@XPS_ID", SqlDbType.VarChar,50),
					new SqlParameter("@XPS_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@XPS_SpceCode", SqlDbType.VarChar,50),
					new SqlParameter("@XPS_SpceName", SqlDbType.VarChar,50),
					new SqlParameter("@XPS_Details", SqlDbType.VarChar,2000),
					new SqlParameter("@XPS_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@XPS_CTime", SqlDbType.DateTime),
					new SqlParameter("@XPS_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@XPS_MTime", SqlDbType.DateTime)};
            parameters[0].Value = model.XPS_ID;
            parameters[1].Value = model.XPS_ProductsBarCode;
            parameters[2].Value = model.XPS_SpceCode;
            parameters[3].Value = model.XPS_SpceName;
            parameters[4].Value = model.XPS_Details;
            parameters[5].Value = model.XPS_Creator;
            parameters[6].Value = model.XPS_CTime;
            parameters[7].Value = model.XPS_Mender;
            parameters[8].Value = model.XPS_MTime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Products_Spce model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Xs_Products_Spce set ");
            strSql.Append("XPS_ProductsBarCode=@XPS_ProductsBarCode,");
            strSql.Append("XPS_SpceCode=@XPS_SpceCode,");
            strSql.Append("XPS_SpceName=@XPS_SpceName,");
            strSql.Append("XPS_Details=@XPS_Details,");
            strSql.Append("XPS_Mender=@XPS_Mender,");
            strSql.Append("XPS_MTime=@XPS_MTime");
            strSql.Append(" where XPS_ID=@XPS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XPS_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@XPS_SpceCode", SqlDbType.VarChar,50),
					new SqlParameter("@XPS_SpceName", SqlDbType.VarChar,50),
					new SqlParameter("@XPS_Details", SqlDbType.VarChar,2000),
					new SqlParameter("@XPS_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@XPS_MTime", SqlDbType.DateTime),
					new SqlParameter("@XPS_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.XPS_ProductsBarCode;
            parameters[1].Value = model.XPS_SpceCode;
            parameters[2].Value = model.XPS_SpceName;
            parameters[3].Value = model.XPS_Details;
            parameters[4].Value = model.XPS_Mender;
            parameters[5].Value = model.XPS_MTime;
            parameters[6].Value = model.XPS_ID;

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
        public bool Delete(string XPS_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Products_Spce ");
            strSql.Append(" where XPS_ID=@XPS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XPS_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XPS_ID;

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
        public bool DeleteList(string XPS_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Products_Spce ");
            strSql.Append(" where XPS_ID in (" + XPS_IDlist + ")  ");
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
        public KNet.Model.Xs_Products_Spce GetModel(string XPS_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 XPS_ID,XPS_ProductsBarCode,XPS_SpceCode,XPS_SpceName,XPS_Details,XPS_Creator,XPS_CTime,XPS_Mender,XPS_MTime from Xs_Products_Spce ");
            strSql.Append(" where XPS_ID=@XPS_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XPS_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XPS_ID;

            KNet.Model.Xs_Products_Spce model = new KNet.Model.Xs_Products_Spce();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["XPS_ID"] != null && ds.Tables[0].Rows[0]["XPS_ID"].ToString() != "")
                {
                    model.XPS_ID = ds.Tables[0].Rows[0]["XPS_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XPS_ProductsBarCode"] != null && ds.Tables[0].Rows[0]["XPS_ProductsBarCode"].ToString() != "")
                {
                    model.XPS_ProductsBarCode = ds.Tables[0].Rows[0]["XPS_ProductsBarCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XPS_SpceCode"] != null && ds.Tables[0].Rows[0]["XPS_SpceCode"].ToString() != "")
                {
                    model.XPS_SpceCode = ds.Tables[0].Rows[0]["XPS_SpceCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XPS_SpceName"] != null && ds.Tables[0].Rows[0]["XPS_SpceName"].ToString() != "")
                {
                    model.XPS_SpceName = ds.Tables[0].Rows[0]["XPS_SpceName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XPS_Details"] != null && ds.Tables[0].Rows[0]["XPS_Details"].ToString() != "")
                {
                    model.XPS_Details = ds.Tables[0].Rows[0]["XPS_Details"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XPS_Creator"] != null && ds.Tables[0].Rows[0]["XPS_Creator"].ToString() != "")
                {
                    model.XPS_Creator = ds.Tables[0].Rows[0]["XPS_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XPS_CTime"] != null && ds.Tables[0].Rows[0]["XPS_CTime"].ToString() != "")
                {
                    model.XPS_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["XPS_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XPS_Mender"] != null && ds.Tables[0].Rows[0]["XPS_Mender"].ToString() != "")
                {
                    model.XPS_Mender = ds.Tables[0].Rows[0]["XPS_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XPS_MTime"] != null && ds.Tables[0].Rows[0]["XPS_MTime"].ToString() != "")
                {
                    model.XPS_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["XPS_MTime"].ToString());
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
            strSql.Append("select a.*,b.* ");
            strSql.Append(" FROM Xs_Products_Spce  a join KNet_Sys_Products b on a.XPS_ProductsBarCode=b.ProductsBarCode ");
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
            strSql.Append(" XPS_ID,XPS_ProductsBarCode,XPS_SpceCode,XPS_SpceName,XPS_Details,XPS_Creator,XPS_CTime,XPS_Mender,XPS_MTime ");
            strSql.Append(" FROM Xs_Products_Spce ");
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
            parameters[0].Value = "Xs_Products_Spce";
            parameters[1].Value = "XPS_ID";
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


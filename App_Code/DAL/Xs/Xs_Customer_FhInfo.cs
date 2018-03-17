using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Xs_Customer_FhInfo
    /// </summary>
    public partial class Xs_Customer_FhInfo
    {
        public Xs_Customer_FhInfo()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XCF_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Xs_Customer_FhInfo");
            strSql.Append(" where XCF_ID=@XCF_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCF_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XCF_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Customer_FhInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Xs_Customer_FhInfo(");
            strSql.Append("XCF_ID,XCF_CustomerValue,XCF_Name,XCF_Details)");
            strSql.Append(" values (");
            strSql.Append("@XCF_ID,@XCF_CustomerValue,@XCF_Name,@XCF_Details)");
            SqlParameter[] parameters = {
					new SqlParameter("@XCF_ID", SqlDbType.VarChar,50),
					new SqlParameter("@XCF_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@XCF_Name", SqlDbType.VarChar,150),
					new SqlParameter("@XCF_Details", SqlDbType.VarChar,500)};
            parameters[0].Value = model.XCF_ID;
            parameters[1].Value = model.XCF_CustomerValue;
            parameters[2].Value = model.XCF_Name;
            parameters[3].Value = model.XCF_Details;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Customer_FhInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Xs_Customer_FhInfo set ");
            strSql.Append("XCF_CustomerValue=@XCF_CustomerValue,");
            strSql.Append("XCF_Name=@XCF_Name,");
            strSql.Append("XCF_Details=@XCF_Details");
            strSql.Append(" where XCF_ID=@XCF_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCF_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@XCF_Name", SqlDbType.VarChar,150),
					new SqlParameter("@XCF_Details", SqlDbType.VarChar,500),
					new SqlParameter("@XCF_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.XCF_CustomerValue;
            parameters[1].Value = model.XCF_Name;
            parameters[2].Value = model.XCF_Details;
            parameters[3].Value = model.XCF_ID;

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
        public bool Delete(string XCF_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Customer_FhInfo ");
            strSql.Append(" where XCF_ID=@XCF_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCF_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XCF_ID;

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
        public bool DeleteByCustomerValue(string XCF_CustomerValue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Customer_FhInfo ");
            strSql.Append(" where XCF_CustomerValue=@XCF_CustomerValue ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCF_CustomerValue", SqlDbType.VarChar,50)};
            parameters[0].Value = XCF_CustomerValue;

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
        public bool DeleteList(string XCF_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Customer_FhInfo ");
            strSql.Append(" where XCF_ID in (" + XCF_IDlist + ")  ");
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
        public KNet.Model.Xs_Customer_FhInfo GetModel(string XCF_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 XCF_ID,XCF_CustomerValue,XCF_Name,XCF_Details from Xs_Customer_FhInfo ");
            strSql.Append(" where XCF_ID=@XCF_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCF_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XCF_ID;

            KNet.Model.Xs_Customer_FhInfo model = new KNet.Model.Xs_Customer_FhInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["XCF_ID"] != null && ds.Tables[0].Rows[0]["XCF_ID"].ToString() != "")
                {
                    model.XCF_ID = ds.Tables[0].Rows[0]["XCF_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XCF_CustomerValue"] != null && ds.Tables[0].Rows[0]["XCF_CustomerValue"].ToString() != "")
                {
                    model.XCF_CustomerValue = ds.Tables[0].Rows[0]["XCF_CustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XCF_Name"] != null && ds.Tables[0].Rows[0]["XCF_Name"].ToString() != "")
                {
                    model.XCF_Name = ds.Tables[0].Rows[0]["XCF_Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XCF_Details"] != null && ds.Tables[0].Rows[0]["XCF_Details"].ToString() != "")
                {
                    model.XCF_Details = ds.Tables[0].Rows[0]["XCF_Details"].ToString();
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
            strSql.Append("select XCF_ID,XCF_CustomerValue,XCF_Name,XCF_Details ");
            strSql.Append(" FROM Xs_Customer_FhInfo ");
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
            strSql.Append(" XCF_ID,XCF_CustomerValue,XCF_Name,XCF_Details ");
            strSql.Append(" FROM Xs_Customer_FhInfo ");
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
            parameters[0].Value = "Xs_Customer_FhInfo";
            parameters[1].Value = "XCF_ID";
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


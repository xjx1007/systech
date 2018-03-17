using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class Products_Replace_List
    {
        public Products_Replace_List()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PRL_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Products_Replace_List");
            strSql.Append(" where PRL_ID=@PRL_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@PRL_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = PRL_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.Products_Replace_List model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Products_Replace_List(");
            strSql.Append("PRL_ID,PRL_ProductsCode,PRL_ReplaceProductsBarCode,PRL_AlternativePriority,PRL_AlternativeOlny ");
            strSql.Append(") values (");
            strSql.Append("@PRL_ID,@PRL_ProductsCode,@PRL_ReplaceProductsBarCode,@PRL_AlternativePriority,@PRL_AlternativeOlny)");
            SqlParameter[] parameters = {
 new SqlParameter("@PRL_ID", SqlDbType.VarChar,50),
 new SqlParameter("@PRL_ProductsCode", SqlDbType.VarChar,50),
 new SqlParameter("@PRL_ReplaceProductsBarCode", SqlDbType.VarChar,50),
 new SqlParameter("@PRL_AlternativePriority", SqlDbType.Int,4),
 new SqlParameter("@PRL_AlternativeOlny", SqlDbType.Int,4)};
            parameters[0].Value = model.PRL_ID;
            parameters[1].Value = model.PRL_ProductsCode;
            parameters[2].Value = model.PRL_ReplaceProductsBarCode;
            parameters[3].Value = model.PRL_AlternativePriority;
            parameters[4].Value = model.PRL_AlternativeOlny;
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
        /// 修改
        /// </summary>
        public bool Update(KNet.Model.Products_Replace_List model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update Products_Replace_List set ");
            strSql.Append("PRL_ProductsCode=@PRL_ProductsCode,");
            strSql.Append("PRL_ReplaceProductsBarCode=@PRL_ReplaceProductsBarCode,");
            strSql.Append("PRL_AlternativePriority=@PRL_AlternativePriority,");
            strSql.Append("PRL_AlternativeOlny=@PRL_AlternativeOlny");
            strSql.Append(" where PRL_ID=@PRL_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@PRL_ProductsCode", SqlDbType.VarChar,50),
 new SqlParameter("@PRL_ReplaceProductsBarCode", SqlDbType.VarChar,50),
 new SqlParameter("@PRL_AlternativePriority", SqlDbType.Int,4),
 new SqlParameter("@PRL_AlternativeOlny", SqlDbType.Int,4),
new SqlParameter("@PRL_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PRL_ProductsCode;
            parameters[1].Value = model.PRL_ReplaceProductsBarCode;
            parameters[2].Value = model.PRL_AlternativePriority;
            parameters[3].Value = model.PRL_AlternativeOlny;
            parameters[4].Value = model.PRL_ID;

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
        /// Delete
        /// </summary>
        public bool Delete(string s_PRL_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  Products_Replace_List  ");
            strSql.Append(" where PRL_ID=@PRL_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@PRL_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = s_PRL_ID;
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
        /// Delete
        /// </summary>
        public bool UpdateDel(KNet.Model.Products_Replace_List model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update   Products_Replace_List  Set ");
            strSql.Append(" where PRL_ID=@PRL_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@PRL_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PRL_ID;

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
        /// Delete
        /// </summary>
        public bool DeleteList(string s_PRL_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From   Products_Replace_List  ");
            strSql.Append(" where PRL_ID in ('" + s_PRL_ID + "')");

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
        /// QueryByFID
        /// </summary>
        public DataSet QueryByFID(string s_FID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from  Products_Replace_List  ");
            strSql.Append(" where PRL_ProductsCode=@PRL_ProductsCode ");
            SqlParameter[] parameters = {
new SqlParameter("@PRL_ProductsBarCode", SqlDbType.VarChar,50)};

            parameters[0].Value = s_FID;
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// DeleteByFID
        /// </summary>
        public bool DeleteByFID(string s_FID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  Products_Replace_List  ");
            strSql.Append(" where PRL_ProductsCode=@PRL_ProductsCode ");
            SqlParameter[] parameters = {
new SqlParameter("@PRL_ProductsCode", SqlDbType.VarChar,50)};
            parameters[0].Value = s_FID;
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
        /// 得到数据
        /// </summary>
        public KNet.Model.Products_Replace_List GetModel(string PRL_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from Products_Replace_List  ");
            strSql.Append("where PRL_ID=@PRL_ID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@PRL_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = PRL_ID;
            KNet.Model.Products_Replace_List model = new KNet.Model.Products_Replace_List();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Products_Replace_List DataRowToModel(DataRow row)
        {
            KNet.Model.Products_Replace_List model = new KNet.Model.Products_Replace_List();
            if (row != null)
            {
                if (row["PRL_ID"] != null)
                {
                    model.PRL_ID = row["PRL_ID"].ToString();
                }
                else
                {
                    model.PRL_ID = "";
                }
                if (row["PRL_ProductsCode"] != null)
                {
                    model.PRL_ProductsCode = row["PRL_ProductsCode"].ToString();
                }
                else
                {
                    model.PRL_ProductsCode = "";
                }
                if (row["PRL_ReplaceProductsBarCode"] != null)
                {
                    model.PRL_ReplaceProductsBarCode = row["PRL_ReplaceProductsBarCode"].ToString();
                }
                else
                {
                    model.PRL_ReplaceProductsBarCode = "";
                }
                if (row["PRL_AlternativePriority"] != null)
                {
                    model.PRL_AlternativePriority = int.Parse(row["PRL_AlternativePriority"].ToString());
                }
                else
                {
                    model.PRL_AlternativePriority = 0;
                }
                if (row["PRL_AlternativeOlny"] != null)
                {
                    model.PRL_AlternativeOlny = int.Parse(row["PRL_AlternativeOlny"].ToString());
                }
                else
                {
                    model.PRL_AlternativeOlny = 0;
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Products_Replace_List ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

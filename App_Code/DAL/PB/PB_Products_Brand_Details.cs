using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class PB_Products_Brand_Details
    {
        public PB_Products_Brand_Details()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PPBD_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PB_Products_Brand_Details");
            strSql.Append(" where PPBD_ID=@PPBD_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@PPBD_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = PPBD_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.PB_Products_Brand_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PB_Products_Brand_Details(");
            strSql.Append("PPBD_ID,PPBD_FID,PPBD_ProductsBarCode,PPBD_BrandName,PPBD_IsMainBrand,PPBD_BZNumber ");
            strSql.Append(") values (");
            strSql.Append("@PPBD_ID,@PPBD_FID,@PPBD_ProductsBarCode,@PPBD_BrandName,@PPBD_IsMainBrand,@PPBD_BZNumber)");
            SqlParameter[] parameters = {
 new SqlParameter("@PPBD_ID", SqlDbType.VarChar,50),
 new SqlParameter("@PPBD_FID", SqlDbType.VarChar,50),
 new SqlParameter("@PPBD_ProductsBarCode", SqlDbType.VarChar,50),
 new SqlParameter("@PPBD_BrandName", SqlDbType.VarChar,150),
 new SqlParameter("@PPBD_IsMainBrand", SqlDbType.Int,4),
 new SqlParameter("@PPBD_BZNumber", SqlDbType.Int,4)};
            parameters[0].Value = model.PPBD_ID;
            parameters[1].Value = model.PPBD_FID;
            parameters[2].Value = model.PPBD_ProductsBarCode;
            parameters[3].Value = model.PPBD_BrandName;
            parameters[4].Value = model.PPBD_IsMainBrand;
            parameters[5].Value = model.PPBD_BZNumber;
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
        public bool Update(KNet.Model.PB_Products_Brand_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update PB_Products_Brand_Details set ");
            strSql.Append("PPBD_FID=@PPBD_FID,");
            strSql.Append("PPBD_ProductsBarCode=@PPBD_ProductsBarCode,");
            strSql.Append("PPBD_BrandName=@PPBD_BrandName,");
            strSql.Append("PPBD_IsMainBrand=@PPBD_IsMainBrand,");
            strSql.Append("PPBD_BZNumber=@PPBD_BZNumber");
            strSql.Append(" where PPBD_ID=@PPBD_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@PPBD_FID", SqlDbType.VarChar,50),
 new SqlParameter("@PPBD_ProductsBarCode", SqlDbType.VarChar,50),
 new SqlParameter("@PPBD_BrandName", SqlDbType.VarChar,150),
 new SqlParameter("@PPBD_IsMainBrand", SqlDbType.Int,4),
 new SqlParameter("@PPBD_BZNumber", SqlDbType.Int,4),
new SqlParameter("@PPBD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PPBD_FID;
            parameters[1].Value = model.PPBD_ProductsBarCode;
            parameters[2].Value = model.PPBD_BrandName;
            parameters[3].Value = model.PPBD_IsMainBrand;
            parameters[4].Value = model.PPBD_BZNumber;
            parameters[5].Value = model.PPBD_ID;

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
        public bool Delete(string s_PPBD_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  PB_Products_Brand_Details  ");
            strSql.Append(" where PPBD_ID=@PPBD_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@PPBD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = s_PPBD_ID;
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
        public bool UpdateDel(KNet.Model.PB_Products_Brand_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update   PB_Products_Brand_Details  Set ");
            strSql.Append(" where PPBD_ID=@PPBD_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@PPBD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PPBD_ID;

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
        public bool DeleteList(string s_PPBD_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From   PB_Products_Brand_Details  ");
            strSql.Append(" where PPBD_ID in ('" + s_PPBD_ID + "')");

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
            strSql.Append("Select * from  PB_Products_Brand_Details  ");
            strSql.Append(" Where  PPBD_FID=@PPBD_FID ");
            SqlParameter[] parameters = {
 new SqlParameter("@PPBD_FID", SqlDbType.VarChar,50),
};
            parameters[0].Value = s_FID;

            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// DeleteByFID
        /// </summary>
        public bool DeleteByFID(string s_FID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  PB_Products_Brand_Details  ");
            strSql.Append(" Where  PPBD_FID=@PPBD_FID ");
            SqlParameter[] parameters = {
 new SqlParameter("@PPBD_FID", SqlDbType.VarChar,50),
};
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
        public KNet.Model.PB_Products_Brand_Details GetModel(string PPBD_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from PB_Products_Brand_Details  ");
            strSql.Append("where PPBD_ID=@PPBD_ID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@PPBD_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = PPBD_ID;
            KNet.Model.PB_Products_Brand_Details model = new KNet.Model.PB_Products_Brand_Details();
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
        public KNet.Model.PB_Products_Brand_Details DataRowToModel(DataRow row)
        {
            KNet.Model.PB_Products_Brand_Details model = new KNet.Model.PB_Products_Brand_Details();
            if (row != null)
            {
                if (row["PPBD_ID"] != null)
                {
                    model.PPBD_ID = row["PPBD_ID"].ToString();
                }
                else
                {
                    model.PPBD_ID = "";
                }
                if (row["PPBD_FID"] != null)
                {
                    model.PPBD_FID = row["PPBD_FID"].ToString();
                }
                else
                {
                    model.PPBD_FID = "";
                }
                if (row["PPBD_ProductsBarCode"] != null)
                {
                    model.PPBD_ProductsBarCode = row["PPBD_ProductsBarCode"].ToString();
                }
                else
                {
                    model.PPBD_ProductsBarCode = "";
                }
                if (row["PPBD_BrandName"] != null)
                {
                    model.PPBD_BrandName = row["PPBD_BrandName"].ToString();
                }
                else
                {
                    model.PPBD_BrandName = "";
                }
                if (row["PPBD_IsMainBrand"] != null)
                {
                    model.PPBD_IsMainBrand = int.Parse(row["PPBD_IsMainBrand"].ToString());
                }
                else
                {
                    model.PPBD_IsMainBrand = 0;
                }
                if (row["PPBD_BZNumber"] != null)
                {
                    model.PPBD_BZNumber = int.Parse(row["PPBD_BZNumber"].ToString());
                }
                else
                {
                    model.PPBD_BZNumber = 0;
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
            strSql.Append(" FROM PB_Products_Brand_Details ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

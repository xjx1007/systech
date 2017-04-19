using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class PB_Products_Brand
    {
        public PB_Products_Brand()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PPB_BrandName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PB_Products_Brand");
            strSql.Append(" where PPB_BrandName=@PPB_BrandName ");
            SqlParameter[] parameters = {
new SqlParameter("@PPB_BrandName", SqlDbType.VarChar,50)
};
            parameters[0].Value = PPB_BrandName;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.PB_Products_Brand model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PB_Products_Brand(");
            strSql.Append("PPB_ID,PPB_BrandName,PPB_IsMainBrand,PPB_Remarks,PPB_CTime,PPB_Creator,PPB_MTime,PPB_Mender,PPB_Del ");
            strSql.Append(") values (");
            strSql.Append("@PPB_ID,@PPB_BrandName,@PPB_IsMainBrand,@PPB_Remarks,@PPB_CTime,@PPB_Creator,@PPB_MTime,@PPB_Mender,@PPB_Del)");
            SqlParameter[] parameters = {
 new SqlParameter("@PPB_ID", SqlDbType.VarChar,50),
 new SqlParameter("@PPB_BrandName", SqlDbType.VarChar,150),
 new SqlParameter("@PPB_IsMainBrand", SqlDbType.Int,4),
 new SqlParameter("@PPB_Remarks", SqlDbType.VarChar,150),
 new SqlParameter("@PPB_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@PPB_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@PPB_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@PPB_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@PPB_Del", SqlDbType.Int,4)};
            parameters[0].Value = model.PPB_ID;
            parameters[1].Value = model.PPB_BrandName;
            parameters[2].Value = model.PPB_IsMainBrand;
            parameters[3].Value = model.PPB_Remarks;
            parameters[4].Value = model.PPB_CTime;
            parameters[5].Value = model.PPB_Creator;
            parameters[6].Value = model.PPB_MTime;
            parameters[7].Value = model.PPB_Mender;
            parameters[8].Value = model.PPB_Del;
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
        public bool Update(KNet.Model.PB_Products_Brand model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update PB_Products_Brand set ");
            strSql.Append("PPB_BrandName=@PPB_BrandName,");
            strSql.Append("PPB_IsMainBrand=@PPB_IsMainBrand,");
            strSql.Append("PPB_Remarks=@PPB_Remarks,");
            strSql.Append("PPB_MTime=@PPB_MTime,");
            strSql.Append("PPB_Mender=@PPB_Mender,");
            strSql.Append("PPB_Del=@PPB_Del");
            strSql.Append(" where PPB_ID=@PPB_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@PPB_BrandName", SqlDbType.VarChar,150),
 new SqlParameter("@PPB_IsMainBrand", SqlDbType.Int,4),
 new SqlParameter("@PPB_Remarks", SqlDbType.VarChar,150),
 new SqlParameter("@PPB_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@PPB_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@PPB_Del", SqlDbType.Int,4),
new SqlParameter("@PPB_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PPB_BrandName;
            parameters[1].Value = model.PPB_IsMainBrand;
            parameters[2].Value = model.PPB_Remarks;
            parameters[3].Value = model.PPB_MTime;
            parameters[4].Value = model.PPB_Mender;
            parameters[5].Value = model.PPB_Del;
            parameters[6].Value = model.PPB_ID;

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
        public bool Delete(string s_PPB_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  PB_Products_Brand  ");
            strSql.Append(" where PPB_ID=@PPB_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@PPB_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = s_PPB_ID;
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
        public bool UpdateDel(KNet.Model.PB_Products_Brand model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update   PB_Products_Brand  Set ");
            strSql.Append("  PPB_Del=@PPB_Del ");
            strSql.Append(" where PPB_ID=@PPB_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@PPB_Del", SqlDbType.Int,4),
new SqlParameter("@PPB_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PPB_Del;
            parameters[1].Value = model.PPB_ID;

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
        public bool DeleteList(string s_PPB_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From   PB_Products_Brand  ");
            strSql.Append(" where PPB_ID in ('" + s_PPB_ID + "')");

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
            strSql.Append("Select * from  PB_Products_Brand  ");
            SqlParameter[] parameters = {
};

            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// DeleteByFID
        /// </summary>
        public bool DeleteByFID(string s_FID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  PB_Products_Brand  ");
            SqlParameter[] parameters = {
};

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
        public KNet.Model.PB_Products_Brand GetModel(string PPB_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from PB_Products_Brand  ");
            strSql.Append("where PPB_ID=@PPB_ID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@PPB_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = PPB_ID;
            KNet.Model.PB_Products_Brand model = new KNet.Model.PB_Products_Brand();
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
        public KNet.Model.PB_Products_Brand DataRowToModel(DataRow row)
        {
            KNet.Model.PB_Products_Brand model = new KNet.Model.PB_Products_Brand();
            if (row != null)
            {
                if (row["PPB_ID"] != null)
                {
                    model.PPB_ID = row["PPB_ID"].ToString();
                }
                else
                {
                    model.PPB_ID = "";
                }
                if (row["PPB_BrandName"] != null)
                {
                    model.PPB_BrandName = row["PPB_BrandName"].ToString();
                }
                else
                {
                    model.PPB_BrandName = "";
                }
                if (row["PPB_IsMainBrand"] != null)
                {
                    model.PPB_IsMainBrand = int.Parse(row["PPB_IsMainBrand"].ToString());
                }
                else
                {
                    model.PPB_IsMainBrand = 0;
                }
                if (row["PPB_Remarks"] != null)
                {
                    model.PPB_Remarks = row["PPB_Remarks"].ToString();
                }
                else
                {
                    model.PPB_Remarks = "";
                }
                if (row["PPB_CTime"] != null)
                {
                    model.PPB_CTime = DateTime.Parse(row["PPB_CTime"].ToString());
                }
                if (row["PPB_Creator"] != null)
                {
                    model.PPB_Creator = row["PPB_Creator"].ToString();
                }
                else
                {
                    model.PPB_Creator = "";
                }
                if (row["PPB_MTime"] != null)
                {
                    model.PPB_MTime = DateTime.Parse(row["PPB_MTime"].ToString());
                }
                if (row["PPB_Mender"] != null)
                {
                    model.PPB_Mender = row["PPB_Mender"].ToString();
                }
                else
                {
                    model.PPB_Mender = "";
                }
                if (row["PPB_Del"] != null)
                {
                    model.PPB_Del = int.Parse(row["PPB_Del"].ToString());
                }
                else
                {
                    model.PPB_Del = 0;
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
            strSql.Append(" FROM PB_Products_Brand ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

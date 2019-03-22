using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class KNet_Product_Gauge
    {
        public KNet_Product_Gauge()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KPG_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KNet_Product_Gauge");
            strSql.Append(" where KPG_ID=@KPG_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@KPG_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = KPG_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.KNet_Product_Gauge model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Product_Gauge(");
            strSql.Append("KPG_KID,KPG_Name,KPG_Type,KPG_Number,KPG_UploadUrl,KPG_UploadName,KPG_ProductCode,KPG_Time,KPG_Person,KPG_SuppNo,KPG_Text ");
            strSql.Append(") values (");
            strSql.Append("@KPG_KID,@KPG_Name,@KPG_Type,@KPG_Number,@KPG_UploadUrl,@KPG_UploadName,@KPG_ProductCode,@KPG_Time,@KPG_Person,@KPG_SuppNo,@KPG_Text)");
            SqlParameter[] parameters = {
 
 new SqlParameter("@KPG_KID", SqlDbType.VarChar,50),
 new SqlParameter("@KPG_Name", SqlDbType.VarChar,200),
 new SqlParameter("@KPG_Type", SqlDbType.Int,4),
 new SqlParameter("@KPG_Number", SqlDbType.Int,4),
 new SqlParameter("@KPG_UploadUrl", SqlDbType.VarChar,200),
 new SqlParameter("@KPG_UploadName", SqlDbType.VarChar,200),
 new SqlParameter("@KPG_ProductCode", SqlDbType.VarChar,500),
 new SqlParameter("@KPG_Time", SqlDbType.DateTime,8),
 new SqlParameter("@KPG_Person", SqlDbType.VarChar,50),
             new SqlParameter("@KPG_SuppNo", SqlDbType.VarChar,50),
            new SqlParameter("@KPG_Text", SqlDbType.Text)};
            
            parameters[0].Value = model.KPG_KID;
            parameters[1].Value = model.KPG_Name;
            parameters[2].Value = model.KPG_Type;
            parameters[3].Value = model.KPG_Number;
            parameters[4].Value = model.KPG_UploadUrl;
            parameters[5].Value = model.KPG_UploadName;
            parameters[6].Value = model.KPG_ProductCode;
            parameters[7].Value = model.KPG_Time;
            parameters[8].Value = model.KPG_Person;
            parameters[9].Value = model.KPG_SuppNo;
            parameters[10].Value = model.KPG_Text;
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
        public bool Update(KNet.Model.KNet_Product_Gauge model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update KNet_Product_Gauge set ");
            strSql.Append("KPG_KID=@KPG_KID,");
            strSql.Append("KPG_Name=@KPG_Name,");
            strSql.Append("KPG_Type=@KPG_Type,");
            strSql.Append("KPG_Number=@KPG_Number,");
            strSql.Append("KPG_UploadUrl=@KPG_UploadUrl,");
            strSql.Append("KPG_UploadName=@KPG_UploadName,");
            strSql.Append("KPG_ProductCode=@KPG_ProductCode,");
            strSql.Append("KPG_Time=@KPG_Time,");
            strSql.Append("KPG_Person=@KPG_Person,");
            strSql.Append("KPG_SuppNo=@KPG_SuppNo,");
            strSql.Append("KPG_Text=@KPG_Text");
            strSql.Append(" where KPG_ID=@KPG_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@KPG_KID", SqlDbType.VarChar,50),
 new SqlParameter("@KPG_Name", SqlDbType.VarChar,200),
 new SqlParameter("@KPG_Type", SqlDbType.Int,4),
 new SqlParameter("@KPG_Number", SqlDbType.Int,4),
 new SqlParameter("@KPG_UploadUrl", SqlDbType.VarChar,200),
 new SqlParameter("@KPG_UploadName", SqlDbType.VarChar,200),
 new SqlParameter("@KPG_ProductCode", SqlDbType.VarChar,500),
 new SqlParameter("@KPG_Time", SqlDbType.DateTime,8),
 new SqlParameter("@KPG_Person", SqlDbType.VarChar,50),
 new SqlParameter("@KPG_SuppNo", SqlDbType.VarChar,50),
 new SqlParameter("@KPG_Text", SqlDbType.Text),
new SqlParameter("@KPG_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KPG_KID;
            parameters[1].Value = model.KPG_Name;
            parameters[2].Value = model.KPG_Type;
            parameters[3].Value = model.KPG_Number;
            parameters[4].Value = model.KPG_UploadUrl;
            parameters[5].Value = model.KPG_UploadName;
            parameters[6].Value = model.KPG_ProductCode;
            parameters[7].Value = model.KPG_Time;
            parameters[8].Value = model.KPG_Person;
            parameters[9].Value = model.KPG_SuppNo;
            parameters[10].Value = model.KPG_Text;
            parameters[11].Value = model.KPG_ID;

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
        public bool Delete(string s_KPG_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  KNet_Product_Gauge  ");
            strSql.Append(" where KPG_ID=@KPG_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@KPG_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = s_KPG_ID;
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
        public bool UpdateDel(KNet.Model.KNet_Product_Gauge model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update   KNet_Product_Gauge  Set ");
            strSql.Append(" where KPG_ID=@KPG_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@KPG_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KPG_ID;

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
        public bool DeleteList(string s_KPG_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From   KNet_Product_Gauge  ");
            strSql.Append(" where KPG_ID in ('" + s_KPG_ID + "')");

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
            strSql.Append("Select * from  KNet_Product_Gauge  ");
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
            strSql.Append("delete from  KNet_Product_Gauge  ");
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
        public KNet.Model.KNet_Product_Gauge GetModel(string KPG_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from KNet_Product_Gauge  ");
            strSql.Append("where KPG_ID=@KPG_ID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@KPG_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = KPG_ID;
            KNet.Model.KNet_Product_Gauge model = new KNet.Model.KNet_Product_Gauge();
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
        public KNet.Model.KNet_Product_Gauge DataRowToModel(DataRow row)
        {
            KNet.Model.KNet_Product_Gauge model = new KNet.Model.KNet_Product_Gauge();
            if (row != null)
            {
                if (row["KPG_ID"] != null)
                {
                    model.KPG_ID = row["KPG_ID"].ToString();
                }
                else
                {
                    model.KPG_ID = "";
                }
                if (row["KPG_KID"] != null)
                {
                    model.KPG_KID = row["KPG_KID"].ToString();
                }
                else
                {
                    model.KPG_KID = "";
                }
                if (row["KPG_Name"] != null)
                {
                    model.KPG_Name = row["KPG_Name"].ToString();
                }
                else
                {
                    model.KPG_Name = "";
                }
                if (row["KPG_Type"] != null)
                {
                    model.KPG_Type = int.Parse(row["KPG_Type"].ToString());
                }
                else
                {
                    model.KPG_Type = 0;
                }
                if (row["KPG_Number"] != null)
                {
                    model.KPG_Number = int.Parse(row["KPG_Number"].ToString());
                }
                else
                {
                    model.KPG_Number = 0;
                }
                if (row["KPG_UploadUrl"] != null)
                {
                    model.KPG_UploadUrl = row["KPG_UploadUrl"].ToString();
                }
                else
                {
                    model.KPG_UploadUrl = "";
                }
                if (row["KPG_UploadName"] != null)
                {
                    model.KPG_UploadName = row["KPG_UploadName"].ToString();
                }
                else
                {
                    model.KPG_UploadName = "";
                }
                if (row["KPG_ProductCode"] != null)
                {
                    model.KPG_ProductCode = row["KPG_ProductCode"].ToString();
                }
                else
                {
                    model.KPG_ProductCode = "";
                }
                if (row["KPG_Time"] != null)
                {
                    model.KPG_Time = DateTime.Parse(row["KPG_Time"].ToString());
                }
                if (row["KPG_Person"] != null)
                {
                    model.KPG_Person = row["KPG_Person"].ToString();
                }
                else
                {
                    model.KPG_Person = "";
                }
                if (row["KPG_SuppNo"] != null)
                {
                    model.KPG_SuppNo = row["KPG_SuppNo"].ToString();
                }
                else
                {
                    model.KPG_SuppNo = "";
                }
                if (row["KPG_Text"] != null)
                {
                    model.KPG_Text = row["KPG_Text"].ToString();
                }
                else
                {
                    model.KPG_Text = "";
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
            strSql.Append(" FROM KNet_Product_Gauge ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetList1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select * ");
            strSql.Append(" select distinct(a.KPI_Code),a.KPI_UserIn as KPG_SuppNo,b.KPG_ID,b.KPG_KID,b.KPG_Name,b.KPG_UploadUrl,b.KPG_UploadName,b.KPG_ProductCode,b.KPG_Time,b.KPG_Person from KNet_Product_Gauge_InOut a join KNet_Product_Gauge b on a.KPI_Code=b.KPG_KID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

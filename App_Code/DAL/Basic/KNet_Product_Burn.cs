using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class KNet_Product_Burn
    {
        public KNet_Product_Burn()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KSB_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KNet_Product_Burn");
            strSql.Append(" where KSB_ID=@KSB_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@KSB_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = KSB_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.KNet_Product_Burn model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Product_Burn(");
            strSql.Append("KSB_OrderNo,KSB_Time,KSB_State,KSB_Person,KSB_Sperson,KSB_ProductCode,KSB_FileUrl ");
            strSql.Append(") values (");
            strSql.Append("@KSB_OrderNo,@KSB_Time,@KSB_State,@KSB_Person,@KSB_Sperson,@KSB_ProductCode,@KSB_FileUrl)");
            SqlParameter[] parameters = {
 
 new SqlParameter("@KSB_OrderNo", SqlDbType.VarChar,50),
 new SqlParameter("@KSB_Time", SqlDbType.DateTime,8),
 new SqlParameter("@KSB_State", SqlDbType.Int,4),
 new SqlParameter("@KSB_Person", SqlDbType.VarChar,50),
 new SqlParameter("@KSB_Sperson", SqlDbType.VarChar,50),
           new SqlParameter("@KSB_ProductCode", SqlDbType.VarChar,200),
            new SqlParameter("@KSB_FileUrl", SqlDbType.Text)};
           
            parameters[0].Value = model.KSB_OrderNo;
            parameters[1].Value = model.KSB_Time;
            parameters[2].Value = model.KSB_State;
            parameters[3].Value = model.KSB_Person;
            parameters[4].Value = model.KSB_Sperson;
            parameters[5].Value = model.KSB_ProductCode;
            parameters[6].Value = model.KSB_FileUrl;
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
        public bool Update(KNet.Model.KNet_Product_Burn model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update KNet_Product_Burn set ");
            strSql.Append("KSB_OrderNo=@KSB_OrderNo,");
            strSql.Append("KSB_Time=@KSB_Time,");
            strSql.Append("KSB_State=@KSB_State,");
            strSql.Append("KSB_Person=@KSB_Person,");
            strSql.Append("KSB_Sperson=@KSB_Sperson");
            strSql.Append("KSB_ProductCode=@KSB_ProductCode");
            strSql.Append("KSB_FileUrl=@KSB_FileUrl");
            strSql.Append(" where KSB_ID=@KSB_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@KSB_OrderNo", SqlDbType.VarChar,50),
 new SqlParameter("@KSB_Time", SqlDbType.DateTime,8),
 new SqlParameter("@KSB_State", SqlDbType.Int,4),
 new SqlParameter("@KSB_Person", SqlDbType.VarChar,50),
 new SqlParameter("@KSB_Sperson", SqlDbType.VarChar,50),
 new SqlParameter("@KSB_ProductCode", SqlDbType.VarChar,200),
 new SqlParameter("@KSB_FileUrl", SqlDbType.Text),
new SqlParameter("@KSB_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KSB_OrderNo;
            parameters[1].Value = model.KSB_Time;
            parameters[2].Value = model.KSB_State;
            parameters[3].Value = model.KSB_Person;
            parameters[4].Value = model.KSB_Sperson;
            parameters[5].Value = model.KSB_ProductCode;
            parameters[6].Value = model.KSB_FileUrl;
            parameters[7].Value = model.KSB_ID;

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
        public bool Delete(string s_KSB_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  KNet_Product_Burn  ");
            strSql.Append(" where KSB_ID=@KSB_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@KSB_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = s_KSB_ID;
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
        public bool UpdateDel(KNet.Model.KNet_Product_Burn model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update   KNet_Product_Burn  Set ");
            strSql.Append(" where KSB_ID=@KSB_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@KSB_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KSB_ID;

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
        public bool DeleteList(string s_KSB_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From   KNet_Product_Burn  ");
            strSql.Append(" where KSB_ID in ('" + s_KSB_ID + "')");

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
            strSql.Append("Select * from  KNet_Product_Burn  ");
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
            strSql.Append("delete from  KNet_Product_Burn  ");
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
        public KNet.Model.KNet_Product_Burn GetModel(string KSB_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from KNet_Product_Burn  ");
            strSql.Append("where KSB_ID=@KSB_ID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@KSB_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = KSB_ID;
            KNet.Model.KNet_Product_Burn model = new KNet.Model.KNet_Product_Burn();
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
        public KNet.Model.KNet_Product_Burn DataRowToModel(DataRow row)
        {
            KNet.Model.KNet_Product_Burn model = new KNet.Model.KNet_Product_Burn();
            if (row != null)
            {
                if (row["KSB_ID"] != null)
                {
                    model.KSB_ID = row["KSB_ID"].ToString();
                }
                else
                {
                    model.KSB_ID = "";
                }
                if (row["KSB_OrderNo"] != null)
                {
                    model.KSB_OrderNo = row["KSB_OrderNo"].ToString();
                }
                else
                {
                    model.KSB_OrderNo = "";
                }
                if (row["KSB_Time"] != null)
                {
                    model.KSB_Time = DateTime.Parse(row["KSB_Time"].ToString());
                }
                if (row["KSB_State"] != null)
                {
                    model.KSB_State = int.Parse(row["KSB_State"].ToString());
                }
                else
                {
                    model.KSB_State = 0;
                }
                if (row["KSB_Person"] != null)
                {
                    model.KSB_Person = row["KSB_Person"].ToString();
                }
                else
                {
                    model.KSB_Person = "";
                }
                if (row["KSB_Sperson"] != null)
                {
                    model.KSB_Sperson = row["KSB_Sperson"].ToString();
                }
                else
                {
                    model.KSB_Sperson = "";
                }
                if (row["KSB_ProductCode"] != null)
                {
                    model.KSB_ProductCode = row["KSB_ProductCode"].ToString();
                }
                else
                {
                    model.KSB_ProductCode = "";
                }
                if (row["KSB_FileUrl"] != null)
                {
                    model.KSB_FileUrl = row["KSB_FileUrl"].ToString();
                }
                else
                {
                    model.KSB_FileUrl = "";
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
            strSql.Append(" FROM KNet_Product_Burn ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

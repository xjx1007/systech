using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class Knet_Sales_Retrun_Maintain_Details
    {
        public Knet_Sales_Retrun_Maintain_Details()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KSD_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Knet_Sales_Retrun_Maintain_Details");
            strSql.Append(" where KSD_ID=@KSD_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@KSD_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = KSD_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.Knet_Sales_Retrun_Maintain_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Knet_Sales_Retrun_Maintain_Details(");
            strSql.Append("KSD_ID,KSD_ProductCode,KSD_Number,KSD_BadNumber,KSD_GoodNumber,KSD_STime,KSD_Result,KSD_Text ");
            strSql.Append(") values (");
            strSql.Append("@KSD_ID,@KSD_ProductCode,@KSD_Number,@KSD_BadNumber,@KSD_GoodNumber,@KSD_STime,@KSD_Result,@KSD_Text)");
            SqlParameter[] parameters = {
 new SqlParameter("@KSD_ID", SqlDbType.VarChar,50),
 new SqlParameter("@KSD_ProductCode", SqlDbType.VarChar,50),
 new SqlParameter("@KSD_Number", SqlDbType.Int,4),
 new SqlParameter("@KSD_BadNumber", SqlDbType.Int,4),
 new SqlParameter("@KSD_GoodNumber", SqlDbType.Int,4),
 new SqlParameter("@KSD_STime", SqlDbType.Int,4),
 new SqlParameter("@KSD_Result", SqlDbType.Int,4),
 new SqlParameter("@KSD_Text", SqlDbType.VarChar,16)};
            parameters[0].Value = model.KSD_ID;
            parameters[1].Value = model.KSD_ProductCode;
            parameters[2].Value = model.KSD_Number;
            parameters[3].Value = model.KSD_BadNumber;
            parameters[4].Value = model.KSD_GoodNumber;
            parameters[5].Value = model.KSD_STime;
            parameters[6].Value = model.KSD_Result;
            parameters[7].Value = model.KSD_Text;
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
        public bool Update(KNet.Model.Knet_Sales_Retrun_Maintain_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update Knet_Sales_Retrun_Maintain_Details set ");
            strSql.Append("KSD_ProductCode=@KSD_ProductCode,");
            strSql.Append("KSD_Number=@KSD_Number,");
            strSql.Append("KSD_BadNumber=@KSD_BadNumber,");
            strSql.Append("KSD_GoodNumber=@KSD_GoodNumber,");
            strSql.Append("KSD_STime=@KSD_STime,");
            strSql.Append("KSD_Result=@KSD_Result,");
            strSql.Append("KSD_Text=@KSD_Text");
            strSql.Append(" where KSD_ID=@KSD_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@KSD_ProductCode", SqlDbType.VarChar,50),
 new SqlParameter("@KSD_Number", SqlDbType.Int,4),
 new SqlParameter("@KSD_BadNumber", SqlDbType.Int,4),
 new SqlParameter("@KSD_GoodNumber", SqlDbType.Int,4),
 new SqlParameter("@KSD_STime", SqlDbType.Int,4),
 new SqlParameter("@KSD_Result", SqlDbType.Int,4),
 new SqlParameter("@KSD_Text", SqlDbType.VarChar,16),
new SqlParameter("@KSD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KSD_ProductCode;
            parameters[1].Value = model.KSD_Number;
            parameters[2].Value = model.KSD_BadNumber;
            parameters[3].Value = model.KSD_GoodNumber;
            parameters[4].Value = model.KSD_STime;
            parameters[5].Value = model.KSD_Result;
            parameters[6].Value = model.KSD_Text;
            parameters[7].Value = model.KSD_ID;

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
        public bool Delete(string s_KSD_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  Knet_Sales_Retrun_Maintain_Details  ");
            strSql.Append(" where KSD_ID=@KSD_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@KSD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = s_KSD_ID;
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
        public bool UpdateDel(KNet.Model.Knet_Sales_Retrun_Maintain_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update   Knet_Sales_Retrun_Maintain_Details  Set ");
            strSql.Append(" where KSD_ID=@KSD_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@KSD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KSD_ID;

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
        public bool DeleteList(string s_KSD_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From   Knet_Sales_Retrun_Maintain_Details  ");
            strSql.Append(" where KSD_ID in ('" + s_KSD_ID + "')");

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
            strSql.Append("Select * from  Knet_Sales_Retrun_Maintain_Details  ");
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
            strSql.Append("delete from  Knet_Sales_Retrun_Maintain_Details  ");
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
        public KNet.Model.Knet_Sales_Retrun_Maintain_Details GetModel(string KSD_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from Knet_Sales_Retrun_Maintain_Details  ");
            strSql.Append("where KSD_ID=@KSD_ID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@KSD_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = KSD_ID;
            KNet.Model.Knet_Sales_Retrun_Maintain_Details model = new KNet.Model.Knet_Sales_Retrun_Maintain_Details();
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
        public KNet.Model.Knet_Sales_Retrun_Maintain_Details DataRowToModel(DataRow row)
        {
            KNet.Model.Knet_Sales_Retrun_Maintain_Details model = new KNet.Model.Knet_Sales_Retrun_Maintain_Details();
            if (row != null)
            {
                if (row["KSD_ID"] != null)
                {
                    model.KSD_ID = row["KSD_ID"].ToString();
                }
                else
                {
                    model.KSD_ID = "";
                }
                if (row["KSD_ProductCode"] != null)
                {
                    model.KSD_ProductCode = row["KSD_ProductCode"].ToString();
                }
                else
                {
                    model.KSD_ProductCode = "";
                }
                if (row["KSD_Number"] != null)
                {
                    model.KSD_Number = int.Parse(row["KSD_Number"].ToString());
                }
                else
                {
                    model.KSD_Number = 0;
                }
                if (row["KSD_BadNumber"] != null)
                {
                    model.KSD_BadNumber = int.Parse(row["KSD_BadNumber"].ToString());
                }
                else
                {
                    model.KSD_BadNumber = 0;
                }
                if (row["KSD_GoodNumber"] != null)
                {
                    model.KSD_GoodNumber = int.Parse(row["KSD_GoodNumber"].ToString());
                }
                else
                {
                    model.KSD_GoodNumber = 0;
                }
                if (row["KSD_STime"] != null)
                {
                    model.KSD_STime = int.Parse(row["KSD_STime"].ToString());
                }
                else
                {
                    model.KSD_STime = 0;
                }
                if (row["KSD_Result"] != null)
                {
                    model.KSD_Result = int.Parse(row["KSD_Result"].ToString());
                }
                else
                {
                    model.KSD_Result = 0;
                }
                if (row["KSD_Text"] != null)
                {
                    model.KSD_Text = row["KSD_Text"].ToString();
                }
                else
                {
                    model.KSD_Text = "";
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
            strSql.Append(" FROM Knet_Sales_Retrun_Maintain_Details ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

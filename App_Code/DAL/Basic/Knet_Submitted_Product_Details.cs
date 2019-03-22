using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class Knet_Submitted_Product_Details
    {
        public Knet_Submitted_Product_Details()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KPD_SID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Knet_Submitted_Product_Details");
            strSql.Append(" where KPD_SID=@KPD_SID ");
            SqlParameter[] parameters = {
new SqlParameter("@KPD_SID", SqlDbType.VarChar,50)
};
            parameters[0].Value = KPD_SID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.Knet_Submitted_Product_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Knet_Submitted_Product_Details(");
            strSql.Append("KPD_SID,KPD_OrderNo,KPD_Code,KPD_Number,KPD_CheckNumber,KPD_BadNumber,KPD_YNTState,KPD_UploadUrl,KPD_Prant,KPD_Brand,KPD_RejectRatio,KPD_Remark,KPD_Proposer,KPD_PTime,KPD_KDNumber ");
            strSql.Append(") values (");
            strSql.Append("@KPD_SID,@KPD_OrderNo,@KPD_Code,@KPD_Number,@KPD_CheckNumber,@KPD_BadNumber,@KPD_YNTState,@KPD_UploadUrl,@KPD_Prant,@KPD_Brand,@KPD_RejectRatio,@KPD_Remark,@KPD_Proposer,@KPD_PTime,@KPD_KDNumber)");
            SqlParameter[] parameters = {
 new SqlParameter("@KPD_SID", SqlDbType.VarChar,200),
 new SqlParameter("@KPD_OrderNo", SqlDbType.VarChar,100),
 new SqlParameter("@KPD_Code", SqlDbType.VarChar,100),
 new SqlParameter("@KPD_Number", SqlDbType.Int,4),
 new SqlParameter("@KPD_CheckNumber", SqlDbType.Int,4),
 new SqlParameter("@KPD_BadNumber", SqlDbType.Int,4),
 new SqlParameter("@KPD_YNTState", SqlDbType.Int,4),
 new SqlParameter("@KPD_UploadUrl", SqlDbType.VarChar,400),
 new SqlParameter("@KPD_Prant", SqlDbType.Int,4),
 new SqlParameter("@KPD_Brand", SqlDbType.VarChar,100),
  new SqlParameter("@KPD_RejectRatio", SqlDbType.Decimal),
 new SqlParameter("@KPD_Remark", SqlDbType.Text),
 new SqlParameter("@KPD_Proposer", SqlDbType.VarChar,100),
 new SqlParameter("@KPD_PTime", SqlDbType.DateTime,8),
             new SqlParameter("@KPD_KDNumber", SqlDbType.Int)};
            parameters[0].Value = model.KPD_SID;
            parameters[1].Value = model.KPD_OrderNo;
            parameters[2].Value = model.KPD_Code;
            parameters[3].Value = model.KPD_Number;
            parameters[4].Value = model.KPD_CheckNumber;
            parameters[5].Value = model.KPD_BadNumber;
            parameters[6].Value = model.KPD_YNTState;
            parameters[7].Value = model.KPD_UploadUrl;
            parameters[8].Value = model.KPD_Prant;
            parameters[9].Value = model.KPD_Brand;
            parameters[10].Value = model.KPD_RejectRatio;
            parameters[11].Value = model.KPD_Remark;
            parameters[12].Value = model.KPD_Proposer;
            parameters[13].Value = model.KPD_PTime;
            parameters[14].Value = model.KPD_KDNumber;
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
        public bool Update(KNet.Model.Knet_Submitted_Product_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update Knet_Submitted_Product_Details set ");
            strSql.Append("KPD_SID=@KPD_SID,");
            strSql.Append("KPD_OrderNo=@KPD_OrderNo,");
            strSql.Append("KPD_Code=@KPD_Code,");
            strSql.Append("KPD_Number=@KPD_Number,");
            strSql.Append("KPD_CheckNumber=@KPD_CheckNumber,");
            strSql.Append("KPD_BadNumber=@KPD_BadNumber,");
            strSql.Append("KPD_YNTState=@KPD_YNTState,");
            strSql.Append("KPD_UploadUrl=@KPD_UploadUrl,");
            strSql.Append("KPD_Prant=@KPD_Prant,");
            strSql.Append("KPD_Brand=@KPD_Brand,");
            strSql.Append("KPD_RejectRatio=@KPD_RejectRatio,");
            strSql.Append("KPD_Remark=@KPD_Remark,");
            strSql.Append("KPD_Proposer=@KPD_Proposer,");
            strSql.Append("KPD_PTime=@KPD_PTime");
            strSql.Append("KPD_KDNumber=@KPD_KDNumber");
            strSql.Append(" where KPD_SID=@KPD_SID ");
            SqlParameter[] parameters = {
 new SqlParameter("@KPD_SID", SqlDbType.VarChar,200),
 new SqlParameter("@KPD_OrderNo", SqlDbType.VarChar,100),
 new SqlParameter("@KPD_Code", SqlDbType.VarChar,100),
 new SqlParameter("@KPD_Number", SqlDbType.Int,4),
 new SqlParameter("@KPD_CheckNumber", SqlDbType.Int,4),
 new SqlParameter("@KPD_BadNumber", SqlDbType.Int,4),
 new SqlParameter("@KPD_YNTState", SqlDbType.Int,4),
 new SqlParameter("@KPD_UploadUrl", SqlDbType.VarChar,400),
 new SqlParameter("@KPD_Prant", SqlDbType.Int,4),
  new SqlParameter("@KPD_Brand", SqlDbType.VarChar,100),
  new SqlParameter("@KPD_RejectRatio", SqlDbType.Decimal),
 new SqlParameter("@KPD_Remark", SqlDbType.Text),
 new SqlParameter("@KPD_Proposer", SqlDbType.VarChar,100),
 new SqlParameter("@KPD_PTime", SqlDbType.DateTime,8),
  new SqlParameter("@KPD_KDNumber", SqlDbType.Int),
new SqlParameter("@KPD_SID", SqlDbType.VarChar,200)};
            parameters[0].Value = model.KPD_SID;
            parameters[1].Value = model.KPD_OrderNo;
            parameters[2].Value = model.KPD_Code;
            parameters[3].Value = model.KPD_Number;
            parameters[4].Value = model.KPD_CheckNumber;
            parameters[5].Value = model.KPD_BadNumber;
            parameters[6].Value = model.KPD_YNTState;
            parameters[7].Value = model.KPD_UploadUrl;
            parameters[8].Value = model.KPD_Prant;
            parameters[9].Value = model.KPD_Brand;
            parameters[10].Value = model.KPD_RejectRatio;
            parameters[11].Value = model.KPD_Remark;
            parameters[12].Value = model.KPD_Proposer;
            parameters[13].Value = model.KPD_PTime;
            parameters[14].Value = model.KPD_KDNumber;
            parameters[15].Value = model.KPD_SID;

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
        public bool Delete(string s_KPD_SID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  Knet_Submitted_Product_Details  ");
            strSql.Append(" where KPD_SID=@KPD_SID ");
            SqlParameter[] parameters = {
new SqlParameter("@KPD_SID", SqlDbType.VarChar,200)};
            parameters[0].Value = s_KPD_SID;
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
        public bool UpdateDel(KNet.Model.Knet_Submitted_Product_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update   Knet_Submitted_Product_Details  Set ");
            strSql.Append(" where KPD_SID=@KPD_SID ");
            SqlParameter[] parameters = {
new SqlParameter("@KPD_SID", SqlDbType.VarChar,200)};
            parameters[0].Value = model.KPD_SID;

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
        public bool DeleteList(string s_KPD_SID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From   Knet_Submitted_Product_Details  ");
            strSql.Append(" where KPD_SID in ('" + s_KPD_SID + "')");

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
            strSql.Append("Select * from  Knet_Submitted_Product_Details  ");
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
            strSql.Append("delete from  Knet_Submitted_Product_Details  ");
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
        public KNet.Model.Knet_Submitted_Product_Details GetModel(string KPD_SID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from Knet_Submitted_Product_Details  ");
            strSql.Append("where KPD_SID=@KPD_SID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@KPD_SID", SqlDbType.VarChar,200)
};
            parameters[0].Value = KPD_SID;
            KNet.Model.Knet_Submitted_Product_Details model = new KNet.Model.Knet_Submitted_Product_Details();
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
        public KNet.Model.Knet_Submitted_Product_Details DataRowToModel(DataRow row)
        {
            KNet.Model.Knet_Submitted_Product_Details model = new KNet.Model.Knet_Submitted_Product_Details();
            if (row != null)
            {
                if (row["KPD_SID"] != null)
                {
                    model.KPD_SID = row["KPD_SID"].ToString();
                }
                else
                {
                    model.KPD_SID = "";
                }
              
                if (row["KPD_OrderNo"] != null)
                {
                    model.KPD_OrderNo = row["KPD_OrderNo"].ToString();
                }
                else
                {
                    model.KPD_OrderNo = "";
                }
               
                if (row["KPD_Code"] != null)
                {
                    model.KPD_Code = row["KPD_Code"].ToString();
                }
                else
                {
                    model.KPD_Code = "";
                }
               
                if (row["KPD_Number"] != null)
                {
                    model.KPD_Number = int.Parse(row["KPD_Number"].ToString());
                }
                else
                {
                    model.KPD_Number = 0;
                }
                if (row["KPD_CheckNumber"] != null)
                {
                    model.KPD_CheckNumber = int.Parse(row["KPD_CheckNumber"].ToString());
                }
                else
                {
                    model.KPD_CheckNumber = 0;
                }
                if (row["KPD_BadNumber"] != null)
                {
                    model.KPD_BadNumber = int.Parse(row["KPD_BadNumber"].ToString());
                }
                else
                {
                    model.KPD_BadNumber = 0;
                }
                if (row["KPD_YNTState"] != null)
                {
                    model.KPD_YNTState = int.Parse(row["KPD_YNTState"].ToString());
                }
                else
                {
                    model.KPD_YNTState = 0;
                }
                if (row["KPD_UploadUrl"] != null)
                {
                    model.KPD_UploadUrl = row["KPD_UploadUrl"].ToString();
                }
                else
                {
                    model.KPD_UploadUrl = "";
                }
               
                if (row["KPD_Prant"] != null)
                {
                    model.KPD_Prant = int.Parse(row["KPD_Prant"].ToString());
                }
                else
                {
                    model.KPD_Prant = 0;
                }
                if (row["KPD_Brand"] != null)
                {
                    model.KPD_Brand = row["KPD_Brand"].ToString();
                }
                else
                {
                    model.KPD_Brand = "";
                }
                if (row["KPD_RejectRatio"] != null)
                {
                    model.KPD_RejectRatio =decimal.Parse(row["KPD_RejectRatio"].ToString());
                }
                else
                {
                    model.KPD_RejectRatio = 0;
                }
                if (row["KPD_Remark"] != null)
                {
                    model.KPD_Remark = row["KPD_Remark"].ToString();
                }
                else
                {
                    model.KPD_Remark = "";
                }
                if (row["KPD_Proposer"] != null)
                {
                    model.KPD_Proposer = row["KPD_Proposer"].ToString();
                }
                else
                {
                    model.KPD_Proposer = "";
                }
                if (row["KPD_KDNumber"] != null)
                {
                    model.KPD_KDNumber =int.Parse(row["KPD_KDNumber"].ToString());
                }
                else
                {
                    model.KPD_KDNumber = 0;
                }

                if (row["KPD_PTime"] != null)
                {
                    model.KPD_PTime = DateTime.Parse(row["KPD_PTime"].ToString());
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
            strSql.Append(" FROM Knet_Submitted_Product_Details ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

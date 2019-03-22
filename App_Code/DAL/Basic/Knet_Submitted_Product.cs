using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class Knet_Submitted_Product
    {
        public Knet_Submitted_Product()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KSP_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Knet_Submitted_Product");
            strSql.Append(" where KSP_SID=@KSP_SID ");
            SqlParameter[] parameters = {
new SqlParameter("@KSP_SID", SqlDbType.VarChar,50)
};
            parameters[0].Value = KSP_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.Knet_Submitted_Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Knet_Submitted_Product(");
            strSql.Append("KSP_SID,KSP_OrderNo,KSP_SuppNo,KSP_HouseNo,KSP_Stime,KSP_Time,KSP_Rank,KSP_Proposer,KSP_State,KSP_Boss,KSP_Prant,KSP_UploadUrl,KSP_UploadName,KSP_AnomalyUrl,KSP_AnomalyName,KSP_BackUrl,KSP_BackName,KSP_Remark,KSP_Type,KSP_Sproposer ");
            strSql.Append(") values (");
            strSql.Append("@KSP_SID,@KSP_OrderNo,@KSP_SuppNo,@KSP_HouseNo,@KSP_Stime,@KSP_Time,@KSP_Rank,@KSP_Proposer,@KSP_State,@KSP_Boss,@KSP_Prant,@KSP_UploadUrl,@KSP_UploadName,@KSP_AnomalyUrl,@KSP_AnomalyName,@KSP_BackUrl,@KSP_BackName,@KSP_Remark,@KSP_Type,@KSP_Sproposer)");
            SqlParameter[] parameters = {
 new SqlParameter("@KSP_SID", SqlDbType.VarChar,200),
 new SqlParameter("@KSP_OrderNo", SqlDbType.VarChar,100),
 new SqlParameter("@KSP_SuppNo", SqlDbType.VarChar,200),
 new SqlParameter("@KSP_HouseNo", SqlDbType.VarChar,200),
 new SqlParameter("@KSP_Stime", SqlDbType.DateTime,8),
 new SqlParameter("@KSP_Time", SqlDbType.DateTime,8),
 new SqlParameter("@KSP_Rank", SqlDbType.Int,4),
 new SqlParameter("@KSP_Proposer", SqlDbType.VarChar,100),
 new SqlParameter("@KSP_State", SqlDbType.Int,4),
 new SqlParameter("@KSP_Boss", SqlDbType.Int,4),
            new SqlParameter("@KSP_Prant", SqlDbType.Int,4),
            new SqlParameter("@KSP_UploadUrl", SqlDbType.VarChar,200),
            new SqlParameter("@KSP_UploadName", SqlDbType.VarChar,200),
             new SqlParameter("@KSP_AnomalyUrl", SqlDbType.VarChar,200),
            new SqlParameter("@KSP_AnomalyName", SqlDbType.VarChar,200),
             new SqlParameter("@KSP_BackUrl", SqlDbType.VarChar,200),
            new SqlParameter("@KSP_BackName", SqlDbType.VarChar,200),
            new SqlParameter("@KSP_Remark", SqlDbType.Text),
            new SqlParameter("@KSP_Type", SqlDbType.Int),
            new SqlParameter("@KSP_Sproposer", SqlDbType.VarChar,50)};
            //parameters[0].Value = model.KSP_ID;
            parameters[0].Value = model.KSP_SID;
            parameters[1].Value = model.KSP_OrderNo;
            parameters[2].Value = model.KSP_SuppNo;
            parameters[3].Value = model.KSP_HouseNo;
            parameters[4].Value = model.KSP_Stime;
            parameters[5].Value = model.KSP_Time;
            parameters[6].Value = model.KSP_Rank;
            parameters[7].Value = model.KSP_Proposer;
            parameters[8].Value = model.KSP_State;
            parameters[9].Value = model.KSP_Boss;
            parameters[10].Value = model.KSP_Prant;
            parameters[11].Value = model.KSP_UploadUrl;
            parameters[12].Value = model.KSP_UploadName;
            parameters[13].Value = model.KSP_AnomalyUrl;
            parameters[14].Value = model.KSP_AnomalyName;
            parameters[15].Value = model.KSP_BackUrl;
            parameters[16].Value = model.KSP_BackName;
            parameters[17].Value = model.KSP_Remark;
            parameters[18].Value = model.KSP_Type;
            parameters[19].Value = model.KSP_Sproposer;
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
        public bool Update(KNet.Model.Knet_Submitted_Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update Knet_Submitted_Product set ");
            //strSql.Append("KSP_ID=@KSP_ID,");
            strSql.Append("KSP_SID=@KSP_SID,");   
            strSql.Append("KSP_OrderNo=@KSP_OrderNo,");
            strSql.Append("KSP_SuppNo=@KSP_SuppNo,");
            strSql.Append("KSP_HouseNo=@KSP_HouseNo,");
            strSql.Append("KSP_Stime=@KSP_Stime,");
            strSql.Append("KSP_Time=@KSP_Time,");
            strSql.Append("KSP_Rank=@KSP_Rank,");
            //strSql.Append("KSP_Sproposer=@KSP_Sproposer,");
            strSql.Append("KSP_State=@KSP_State,");
            strSql.Append("KSP_Boss=@KSP_Boss,");
            strSql.Append("KSP_Prant=@KSP_Prant,");
            strSql.Append("KSP_UploadUrl=@KSP_UploadUrl,");
            strSql.Append("KSP_UploadName=@KSP_UploadName,");
            strSql.Append("KSP_AnomalyUrl=@KSP_AnomalyUrl,");
            strSql.Append("KSP_AnomalyName=@KSP_AnomalyName,");
            strSql.Append("KSP_BackUrl=@KSP_BackUrl,");
            strSql.Append("KSP_BackName=@KSP_BackName,");
            strSql.Append("KSP_Remark=@KSP_Remark,");
                strSql.Append("KSP_Type=@KSP_Type");
            strSql.Append(" where KSP_ID=@KSP_ID ");
            SqlParameter[] parameters = {
 //new SqlParameter("@KSP_ID", SqlDbType.VarChar,200),
 new SqlParameter("@KSP_SID", SqlDbType.VarChar,200),
 new SqlParameter("@KSP_OrderNo", SqlDbType.VarChar,100),
 new SqlParameter("@KSP_SuppNo", SqlDbType.VarChar,200),
 new SqlParameter("@KSP_HouseNo", SqlDbType.VarChar,200),
 new SqlParameter("@KSP_Stime", SqlDbType.DateTime,8),
 new SqlParameter("@KSP_Time", SqlDbType.DateTime,8),
 new SqlParameter("@KSP_Rank", SqlDbType.Int,4),
 //new SqlParameter("@KSP_Sproposer", SqlDbType.VarChar,100),
 new SqlParameter("@KSP_State", SqlDbType.Int,4),
 new SqlParameter("@KSP_Boss", SqlDbType.Int,4),
  new SqlParameter("@KSP_Prant", SqlDbType.Int,4),
            new SqlParameter("@KSP_UploadUrl", SqlDbType.VarChar,200),
            new SqlParameter("@KSP_UploadName", SqlDbType.VarChar,200),
             new SqlParameter("@KSP_AnomalyUrl", SqlDbType.VarChar,200),
            new SqlParameter("@KSP_AnomalyName", SqlDbType.VarChar,200),
             new SqlParameter("@KSP_BackUrl", SqlDbType.VarChar,200),
            new SqlParameter("@KSP_BackName", SqlDbType.VarChar,200),
            new SqlParameter("@KSP_Remark", SqlDbType.Text),
            new SqlParameter("@KSP_Type", SqlDbType.Int),
new SqlParameter("@KSP_ID", SqlDbType.VarChar,200)
            };
            //parameters[0].Value = model.KSP_ID;
            parameters[0].Value = model.KSP_SID;
            parameters[1].Value = model.KSP_OrderNo;
            parameters[2].Value = model.KSP_SuppNo;
            parameters[3].Value = model.KSP_HouseNo;
            parameters[4].Value = model.KSP_Stime;
            parameters[5].Value = model.KSP_Time;
            parameters[6].Value = model.KSP_Rank;
            //parameters[7].Value = model.KSP_Sproposer;
            parameters[7].Value = model.KSP_State;
            parameters[8].Value = model.KSP_Boss;
            parameters[9].Value = model.KSP_Prant;
            parameters[10].Value = model.KSP_UploadUrl;
            parameters[11].Value = model.KSP_UploadName;
            parameters[12].Value = model.KSP_AnomalyUrl;
            parameters[13].Value = model.KSP_AnomalyName;
            parameters[14].Value = model.KSP_BackUrl;
            parameters[15].Value = model.KSP_BackName;
            parameters[16].Value = model.KSP_Remark;
            parameters[17].Value = model.KSP_Type;
            parameters[18].Value = model.KSP_ID;

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
        public bool Delete(string s_KSP_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  Knet_Submitted_Product  ");
            strSql.Append(" where KSP_SID=@KSP_SID ");
            SqlParameter[] parameters = {
new SqlParameter("@KSP_SID", SqlDbType.VarChar,200)};
            parameters[0].Value = s_KSP_ID;
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

        public string GetLastCode()
        {
            string s_Return = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 KSP_SID from Knet_Submitted_Product");
            strSql.Append("  where datediff(year,KSP_Stime,GetDate())=0  order by KSP_SID desc");

            DataSet Dts_Table = DbHelperSQL.Query(strSql.ToString());
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                s_Return = Dts_Table.Tables[0].Rows[0][0].ToString();
            }
            return s_Return;
        }
        /// <summary>
        /// Delete
        /// </summary>
        public bool UpdateDel(KNet.Model.Knet_Submitted_Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update   Knet_Submitted_Product  Set ");
            strSql.Append(" where KSP_ID=@KSP_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@KSP_ID", SqlDbType.VarChar,200)};
            parameters[0].Value = model.KSP_ID;

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
        public bool DeleteList(string s_KSP_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From   Knet_Submitted_Product  ");
            strSql.Append(" where KSP_ID in ('" + s_KSP_ID + "')");

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
            strSql.Append("Select * from  Knet_Submitted_Product  ");
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
            strSql.Append("delete from  Knet_Submitted_Product  ");
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
        public KNet.Model.Knet_Submitted_Product GetModel(string KSP_SID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from Knet_Submitted_Product  ");
            strSql.Append("where KSP_SID=@KSP_SID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@KSP_SID", SqlDbType.VarChar,200)
};
            parameters[0].Value = KSP_SID;
            KNet.Model.Knet_Submitted_Product model = new KNet.Model.Knet_Submitted_Product();
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
        public KNet.Model.Knet_Submitted_Product DataRowToModel(DataRow row)
        {
            KNet.Model.Knet_Submitted_Product model = new KNet.Model.Knet_Submitted_Product();
            if (row != null)
            {
                if (row["KSP_ID"] != null)
                {
                    model.KSP_ID = row["KSP_ID"].ToString();
                }
                else
                {
                    model.KSP_ID = "";
                }
               
                if (row["KSP_SID"] != null)
                {
                    model.KSP_SID = row["KSP_SID"].ToString();
                }
                else
                {
                    model.KSP_SID = "";
                }
               
                if (row["KSP_OrderNo"] != null)
                {
                    model.KSP_OrderNo = row["KSP_OrderNo"].ToString();
                }
                else
                {
                    model.KSP_OrderNo = "";
                }               
                if (row["KSP_SuppNo"] != null)
                {
                    model.KSP_SuppNo = row["KSP_SuppNo"].ToString();
                }
                else
                {
                    model.KSP_SuppNo = "";
                }                             
                if (row["KSP_HouseNo"] != null)
                {
                    model.KSP_HouseNo = row["KSP_HouseNo"].ToString();
                }
                else
                {
                    model.KSP_HouseNo = "";
                }
                if (row["KSP_Stime"] != null)
                {
                    model.KSP_Stime = DateTime.Parse(row["KSP_Stime"].ToString());
                }
                if (row["KSP_Time"] != null)
                {
                    model.KSP_Time = DateTime.Parse(row["KSP_Time"].ToString());
                }
                if (row["KSP_Rank"] != null)
                {
                    model.KSP_Rank = int.Parse(row["KSP_Rank"].ToString());
                }
                else
                {
                    model.KSP_Rank = 0;
                }
                if (row["KSP_Proposer"] != null)
                {
                    model.KSP_Proposer = row["KSP_Proposer"].ToString();
                }
                else
                {
                    model.KSP_Proposer = "";
                }
               
                if (row["KSP_State"] != null)
                {
                    model.KSP_State = int.Parse(row["KSP_State"].ToString());
                }
                else
                {
                    model.KSP_State = 0;
                }
                if (row["KSP_Boss"] != null)
                {
                    model.KSP_Boss = int.Parse(row["KSP_Boss"].ToString());
                }
                else
                {
                    model.KSP_Boss = 0;
                }
                if (row["KSP_Prant"] != null)
                {
                    model.KSP_Prant = int.Parse(row["KSP_Prant"].ToString());
                }
                else
                {
                    model.KSP_Prant = 0;
                }
                if (row["KSP_UploadUrl"] != null)
                {
                    model.KSP_UploadUrl =row["KSP_UploadUrl"].ToString();
                }
                else
                {
                    model.KSP_UploadUrl = "";
                }
                if (row["KSP_UploadName"] != null)
                {
                    model.KSP_UploadName = row["KSP_UploadName"].ToString();
                }
                else
                {
                    model.KSP_UploadName = "";
                }
                if (row["KSP_AnomalyUrl"] != null)
                {
                    model.KSP_AnomalyUrl = row["KSP_AnomalyUrl"].ToString();
                }
                else
                {
                    model.KSP_AnomalyUrl = "";
                }
                if (row["KSP_AnomalyName"] != null)
                {
                    model.KSP_AnomalyName = row["KSP_AnomalyName"].ToString();
                }
                else
                {
                    model.KSP_AnomalyName = "";
                }
                if (row["KSP_BackUrl"] != null)
                {
                    model.KSP_BackUrl = row["KSP_BackUrl"].ToString();
                }
                else
                {
                    model.KSP_BackUrl = "";
                }
                if (row["KSP_BackName"] != null)
                {
                    model.KSP_BackName = row["KSP_BackName"].ToString();
                }
                else
                {
                    model.KSP_BackName = "";
                }
                if (row["KSP_Remark"] != null)
                {
                    model.KSP_Remark = row["KSP_Remark"].ToString();
                }
                else
                {
                    model.KSP_Remark = "";
                }
                if (row["KSP_Type"] != null)
                {
                    model.KSP_Type =int.Parse(row["KSP_Type"].ToString()) ;
                }
                else
                {
                    model.KSP_Type =0;
                }
                if (row["KSP_Sproposer"] != null)
                {
                    model.KSP_Sproposer = row["KSP_Sproposer"].ToString();
                }
                else
                {
                    model.KSP_Sproposer = "";
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
            strSql.Append(" from Knet_Submitted_Product");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

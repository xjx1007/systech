using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class Knet_Sales_Retrun_Maintain
    {
        public Knet_Sales_Retrun_Maintain()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KSM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Knet_Sales_Retrun_Maintain");
            strSql.Append(" where KSM_ID=@KSM_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@KSM_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = KSM_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.Knet_Sales_Retrun_Maintain model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Knet_Sales_Retrun_Maintain(");
            strSql.Append("KSM_MID,KSM_Time,KSM_Type,KSM_Urgency,KSM_OrderNo,KSM_SpTime,KSM_SuppNo,KSM_LinkMan,KSM_Product,KSM_DutyMan,KSM_FindTime,KSM_Number,KSM_Text,KSM_WUploadName,KSM_WUploadUrl,KSM_WTime,KSM_WText,KSM_WResult,KSM_KUploadName,KSM_KUploadUrl,KSM_KTime,KSM_KText,KSM_K8DUploadName,KSM_K8DUploadUrl,KSM_State,KSM_ProductName,KSM_DState ");
            strSql.Append(") values (");
            strSql.Append("@KSM_MID,@KSM_Time,@KSM_Type,@KSM_Urgency,@KSM_OrderNo,@KSM_SpTime,@KSM_SuppNo,@KSM_LinkMan,@KSM_Product,@KSM_DutyMan,@KSM_FindTime,@KSM_Number,@KSM_Text,@KSM_WUploadName,@KSM_WUploadUrl,@KSM_WTime,@KSM_WText,@KSM_WResult,@KSM_KUploadName,@KSM_KUploadUrl,@KSM_KTime,@KSM_KText,@KSM_K8DUploadName,@KSM_K8DUploadUrl,@KSM_State,@KSM_ProductName,@KSM_DState)");
            SqlParameter[] parameters = {

 new SqlParameter("@KSM_MID", SqlDbType.VarChar,100),
 new SqlParameter("@KSM_Time", SqlDbType.DateTime,8),
 new SqlParameter("@KSM_Type", SqlDbType.Int,4),
 new SqlParameter("@KSM_Urgency", SqlDbType.Int,4),
 new SqlParameter("@KSM_OrderNo", SqlDbType.VarChar,50),
 new SqlParameter("@KSM_SpTime", SqlDbType.Int),
 new SqlParameter("@KSM_SuppNo", SqlDbType.VarChar,50),
 new SqlParameter("@KSM_LinkMan", SqlDbType.VarChar,50),
 new SqlParameter("@KSM_Product", SqlDbType.VarChar,50),
 new SqlParameter("@KSM_DutyMan", SqlDbType.VarChar,50),
 new SqlParameter("@KSM_FindTime", SqlDbType.DateTime,8),
 new SqlParameter("@KSM_Number", SqlDbType.Int,4),
 new SqlParameter("@KSM_Text", SqlDbType.VarChar,16),
 new SqlParameter("@KSM_WUploadName", SqlDbType.VarChar,200),
 new SqlParameter("@KSM_WUploadUrl", SqlDbType.VarChar,200),
 new SqlParameter("@KSM_WTime", SqlDbType.DateTime,8),
 new SqlParameter("@KSM_WText", SqlDbType.VarChar,16),
 new SqlParameter("@KSM_WResult", SqlDbType.Int,4),
 new SqlParameter("@KSM_KUploadName", SqlDbType.VarChar,200),
 new SqlParameter("@KSM_KUploadUrl", SqlDbType.VarChar,200),
 new SqlParameter("@KSM_KTime", SqlDbType.DateTime,8),
 new SqlParameter("@KSM_KText", SqlDbType.VarChar,16),
 new SqlParameter("@KSM_K8DUploadName", SqlDbType.VarChar,200),
 new SqlParameter("@KSM_K8DUploadUrl", SqlDbType.VarChar,200),
 new SqlParameter("@KSM_State", SqlDbType.Int,4),
 new SqlParameter("@KSM_ProductName", SqlDbType.VarChar,200),
 new SqlParameter("@KSM_DState", SqlDbType.Int,4)};
            
            parameters[0].Value = model.KSM_MID;
            parameters[1].Value = model.KSM_Time;
            parameters[2].Value = model.KSM_Type;
            parameters[3].Value = model.KSM_Urgency;
            parameters[4].Value = model.KSM_OrderNo;
            parameters[5].Value = model.KSM_SpTime;
            parameters[6].Value = model.KSM_SuppNo;
            parameters[7].Value = model.KSM_LinkMan;
            parameters[8].Value = model.KSM_Product;
            parameters[9].Value = model.KSM_DutyMan;
            parameters[10].Value = model.KSM_FindTime;
            parameters[11].Value = model.KSM_Number;
            parameters[12].Value = model.KSM_Text;
            parameters[13].Value = model.KSM_WUploadName;
            parameters[14].Value = model.KSM_WUploadUrl;
            parameters[15].Value = model.KSM_WTime;
            parameters[16].Value = model.KSM_WText;
            parameters[17].Value = model.KSM_WResult;
            parameters[18].Value = model.KSM_KUploadName;
            parameters[19].Value = model.KSM_KUploadUrl;
            parameters[20].Value = model.KSM_KTime;
            parameters[21].Value = model.KSM_KText;
            parameters[22].Value = model.KSM_K8DUploadName;
            parameters[23].Value = model.KSM_K8DUploadUrl;
            parameters[24].Value = model.KSM_State;
            parameters[25].Value = model.KSM_ProductName;
            parameters[26].Value = model.KSM_DState;
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
        public bool Update(KNet.Model.Knet_Sales_Retrun_Maintain model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update Knet_Sales_Retrun_Maintain set ");
            strSql.Append("KSM_MID=@KSM_MID,");
            strSql.Append("KSM_Time=@KSM_Time,");
            strSql.Append("KSM_Type=@KSM_Type,");
            strSql.Append("KSM_Urgency=@KSM_Urgency,");
            strSql.Append("KSM_OrderNo=@KSM_OrderNo,");
            strSql.Append("KSM_SpTime=@KSM_SpTime,");
            strSql.Append("KSM_SuppNo=@KSM_SuppNo,");
            strSql.Append("KSM_LinkMan=@KSM_LinkMan,");
            strSql.Append("KSM_Product=@KSM_Product,");
            strSql.Append("KSM_DutyMan=@KSM_DutyMan,");
            strSql.Append("KSM_FindTime=@KSM_FindTime,");
            strSql.Append("KSM_Number=@KSM_Number,");
            strSql.Append("KSM_Text=@KSM_Text,");
            strSql.Append("KSM_WUploadName=@KSM_WUploadName,");
            strSql.Append("KSM_WUploadUrl=@KSM_WUploadUrl,");
            strSql.Append("KSM_WTime=@KSM_WTime,");
            strSql.Append("KSM_WText=@KSM_WText,");
            strSql.Append("KSM_WResult=@KSM_WResult,");
            strSql.Append("KSM_KUploadName=@KSM_KUploadName,");
            strSql.Append("KSM_KUploadUrl=@KSM_KUploadUrl,");
            strSql.Append("KSM_KTime=@KSM_KTime,");
            strSql.Append("KSM_KText=@KSM_KText,");
            strSql.Append("KSM_K8DUploadName=@KSM_K8DUploadName,");
            strSql.Append("KSM_K8DUploadUrl=@KSM_K8DUploadUrl,");
            strSql.Append("KSM_State=@KSM_State,");
            strSql.Append("KSM_ProductName=@KSM_ProductName,");
            strSql.Append("KSM_DState=@KSM_DState");
            strSql.Append(" where KSM_ID=@KSM_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@KSM_MID", SqlDbType.VarChar,100),
 new SqlParameter("@KSM_Time", SqlDbType.DateTime,8),
 new SqlParameter("@KSM_Type", SqlDbType.Int,4),
 new SqlParameter("@KSM_Urgency", SqlDbType.Int,4),
 new SqlParameter("@KSM_OrderNo", SqlDbType.VarChar,50),
 new SqlParameter("@KSM_SpTime", SqlDbType.Int,8),
 new SqlParameter("@KSM_SuppNo", SqlDbType.VarChar,50),
 new SqlParameter("@KSM_LinkMan", SqlDbType.VarChar,50),
 new SqlParameter("@KSM_Product", SqlDbType.VarChar,50),
 new SqlParameter("@KSM_DutyMan", SqlDbType.VarChar,50),
 new SqlParameter("@KSM_FindTime", SqlDbType.DateTime,8),
 new SqlParameter("@KSM_Number", SqlDbType.Int,4),
 new SqlParameter("@KSM_Text", SqlDbType.VarChar,16),
 new SqlParameter("@KSM_WUploadName", SqlDbType.VarChar,200),
 new SqlParameter("@KSM_WUploadUrl", SqlDbType.VarChar,200),
 new SqlParameter("@KSM_WTime", SqlDbType.DateTime,8),
 new SqlParameter("@KSM_WText", SqlDbType.VarChar,16),
 new SqlParameter("@KSM_WResult", SqlDbType.Int,4),
 new SqlParameter("@KSM_KUploadName", SqlDbType.VarChar,200),
 new SqlParameter("@KSM_KUploadUrl", SqlDbType.VarChar,200),
 new SqlParameter("@KSM_KTime", SqlDbType.DateTime,8),
 new SqlParameter("@KSM_KText", SqlDbType.VarChar,16),
 new SqlParameter("@KSM_K8DUploadName", SqlDbType.VarChar,200),
 new SqlParameter("@KSM_K8DUploadUrl", SqlDbType.VarChar,200),
 new SqlParameter("@KSM_State", SqlDbType.Int,4),
 new SqlParameter("@KSM_ProductName", SqlDbType.VarChar,200),
 new SqlParameter("@KSM_DState", SqlDbType.Int,4),
new SqlParameter("@KSM_ID", SqlDbType.VarChar,100)};
            parameters[0].Value = model.KSM_MID;
            parameters[1].Value = model.KSM_Time;
            parameters[2].Value = model.KSM_Type;
            parameters[3].Value = model.KSM_Urgency;
            parameters[4].Value = model.KSM_OrderNo;
            parameters[5].Value = model.KSM_SpTime;
            parameters[6].Value = model.KSM_SuppNo;
            parameters[7].Value = model.KSM_LinkMan;
            parameters[8].Value = model.KSM_Product;
            parameters[9].Value = model.KSM_DutyMan;
            parameters[10].Value = model.KSM_FindTime;
            parameters[11].Value = model.KSM_Number;
            parameters[12].Value = model.KSM_Text;
            parameters[13].Value = model.KSM_WUploadName;
            parameters[14].Value = model.KSM_WUploadUrl;
            parameters[15].Value = model.KSM_WTime;
            parameters[16].Value = model.KSM_WText;
            parameters[17].Value = model.KSM_WResult;
            parameters[18].Value = model.KSM_KUploadName;
            parameters[19].Value = model.KSM_KUploadUrl;
            parameters[20].Value = model.KSM_KTime;
            parameters[21].Value = model.KSM_KText;
            parameters[22].Value = model.KSM_K8DUploadName;
            parameters[23].Value = model.KSM_K8DUploadUrl;
            parameters[24].Value = model.KSM_State;
            parameters[25].Value = model.KSM_ProductName;
            parameters[26].Value = model.KSM_DState;
            parameters[27].Value = model.KSM_ID;

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
            strSql.Append("select top 1 KSM_MID from Knet_Sales_Retrun_Maintain");
            strSql.Append("  where datediff(year,KSM_Time,GetDate())=0  order by KSM_MID desc");

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
        public bool Delete(string s_KSM_MID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  Knet_Sales_Retrun_Maintain  ");
            strSql.Append(" where KSM_MID=@KSM_MID ");
            SqlParameter[] parameters = {
new SqlParameter("@KSM_MID", SqlDbType.VarChar,100)};
            parameters[0].Value = s_KSM_MID;
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
        public bool UpdateDel(KNet.Model.Knet_Sales_Retrun_Maintain model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update   Knet_Sales_Retrun_Maintain  Set ");
            strSql.Append(" where KSM_ID=@KSM_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@KSM_ID", SqlDbType.VarChar,100)};
            parameters[0].Value = model.KSM_ID;

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
        public bool DeleteList(string s_KSM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From   Knet_Sales_Retrun_Maintain  ");
            strSql.Append(" where KSM_ID in ('" + s_KSM_ID + "')");

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
            strSql.Append("Select * from  Knet_Sales_Retrun_Maintain  ");
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
            strSql.Append("delete from  Knet_Sales_Retrun_Maintain  ");
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
        public KNet.Model.Knet_Sales_Retrun_Maintain GetModel(string KSM_MID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from Knet_Sales_Retrun_Maintain  ");
            strSql.Append("where KSM_MID=@KSM_MID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@KSM_MID", SqlDbType.VarChar,100)
};
            parameters[0].Value = KSM_MID;
            KNet.Model.Knet_Sales_Retrun_Maintain model = new KNet.Model.Knet_Sales_Retrun_Maintain();
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
        public KNet.Model.Knet_Sales_Retrun_Maintain DataRowToModel(DataRow row)
        {
            KNet.Model.Knet_Sales_Retrun_Maintain model = new KNet.Model.Knet_Sales_Retrun_Maintain();
            if (row != null)
            {
                if (row["KSM_ID"] != null)
                {
                    model.KSM_ID = row["KSM_ID"].ToString();
                }
                else
                {
                    model.KSM_ID = "";
                }
                if (row["KSM_MID"] != null)
                {
                    model.KSM_MID = row["KSM_MID"].ToString();
                }
                else
                {
                    model.KSM_MID = "";
                }
                if (row["KSM_Time"] != null)
                {
                    model.KSM_Time = DateTime.Parse(row["KSM_Time"].ToString());
                }
                if (row["KSM_Type"] != null)
                {
                    model.KSM_Type = int.Parse(row["KSM_Type"].ToString());
                }
                else
                {
                    model.KSM_Type = 0;
                }
                if (row["KSM_Urgency"] != null)
                {
                    model.KSM_Urgency = int.Parse(row["KSM_Urgency"].ToString());
                }
                else
                {
                    model.KSM_Urgency = 0;
                }
                if (row["KSM_OrderNo"] != null)
                {
                    model.KSM_OrderNo = row["KSM_OrderNo"].ToString();
                }
                else
                {
                    model.KSM_OrderNo = "";
                }
                if (row["KSM_SpTime"] != null)
                {
                    model.KSM_SpTime = int.Parse(row["KSM_SpTime"].ToString());
                }
                if (row["KSM_SuppNo"] != null)
                {
                    model.KSM_SuppNo = row["KSM_SuppNo"].ToString();
                }
                else
                {
                    model.KSM_SuppNo = "";
                }
                if (row["KSM_LinkMan"] != null)
                {
                    model.KSM_LinkMan = row["KSM_LinkMan"].ToString();
                }
                else
                {
                    model.KSM_LinkMan = "";
                }
                if (row["KSM_ProductName"] != null)
                {
                    model.KSM_ProductName = row["KSM_ProductName"].ToString();
                }
                else
                {
                    model.KSM_ProductName = "";
                }
                if (row["KSM_Product"] != null)
                {
                    model.KSM_Product = row["KSM_Product"].ToString();
                }
                else
                {
                    model.KSM_Product = "";
                }
                if (row["KSM_DutyMan"] != null)
                {
                    model.KSM_DutyMan = row["KSM_DutyMan"].ToString();
                }
                else
                {
                    model.KSM_DutyMan = "";
                }
                if (row["KSM_FindTime"] != null)
                {
                    model.KSM_FindTime = DateTime.Parse(row["KSM_FindTime"].ToString());
                }
                if (row["KSM_Number"] != null)
                {
                    model.KSM_Number = int.Parse(row["KSM_Number"].ToString());
                }
                else
                {
                    model.KSM_Number = 0;
                }
                if (row["KSM_Text"] != null)
                {
                    model.KSM_Text = row["KSM_Text"].ToString();
                }
                else
                {
                    model.KSM_Text = "";
                }
                if (row["KSM_WUploadName"] != null)
                {
                    model.KSM_WUploadName = row["KSM_WUploadName"].ToString();
                }
                else
                {
                    model.KSM_WUploadName = "";
                }
                if (row["KSM_WUploadUrl"] != null)
                {
                    model.KSM_WUploadUrl = row["KSM_WUploadUrl"].ToString();
                }
                else
                {
                    model.KSM_WUploadUrl = "";
                }
                if (row["KSM_WTime"] != null)
                {
                    model.KSM_WTime = DateTime.Parse(row["KSM_WTime"].ToString());
                }
                if (row["KSM_WText"] != null)
                {
                    model.KSM_WText = row["KSM_WText"].ToString();
                }
                else
                {
                    model.KSM_WText = "";
                }
                if (row["KSM_WResult"] != null)
                {
                    model.KSM_WResult = int.Parse(row["KSM_WResult"].ToString());
                }
                else
                {
                    model.KSM_WResult = 0;
                }
                if (row["KSM_KUploadName"] != null)
                {
                    model.KSM_KUploadName = row["KSM_KUploadName"].ToString();
                }
                else
                {
                    model.KSM_KUploadName = "";
                }
                if (row["KSM_KUploadUrl"] != null)
                {
                    model.KSM_KUploadUrl = row["KSM_KUploadUrl"].ToString();
                }
                else
                {
                    model.KSM_KUploadUrl = "";
                }
                if (row["KSM_KTime"] != null)
                {
                    model.KSM_KTime = DateTime.Parse(row["KSM_KTime"].ToString());
                }
                if (row["KSM_KText"] != null)
                {
                    model.KSM_KText = row["KSM_KText"].ToString();
                }
                else
                {
                    model.KSM_KText = "";
                }
                if (row["KSM_K8DUploadName"] != null)
                {
                    model.KSM_K8DUploadName = row["KSM_K8DUploadName"].ToString();
                }
                else
                {
                    model.KSM_K8DUploadName = "";
                }
                if (row["KSM_K8DUploadUrl"] != null)
                {
                    model.KSM_K8DUploadUrl = row["KSM_K8DUploadUrl"].ToString();
                }
                else
                {
                    model.KSM_K8DUploadUrl = "";
                }
                if (row["KSM_State"] != null)
                {
                    model.KSM_State = int.Parse(row["KSM_State"].ToString());
                }
                else
                {
                    model.KSM_State = 0;
                }
                if (row["KSM_DState"] != null)
                {
                    model.KSM_DState = int.Parse(row["KSM_DState"].ToString());
                }
                else
                {
                    model.KSM_DState = 0;
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
            strSql.Append(" FROM Knet_Sales_Retrun_Maintain ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class PB_Basic_Mail
    {
        public PB_Basic_Mail()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PB_Basic_Mail");
            strSql.Append(" where PBM_ID=@PBM_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@PBM_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = PBM_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.PB_Basic_Mail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PB_Basic_Mail(");
            strSql.Append("PBM_ID,PBM_Code,PBM_SendEmail,PBM_ReceiveEmail,PBM_Text,PBM_File,PBM_Title,PBM_State,PBM_Del,PBM_Creator,PBM_CTime,PBM_Mender,PBM_MTime,PBM_FID,PBM_Type,PBM_Cc,PBM_Ms,PBM_Minute,PBM_SendType,PBM_SendSettingID ");
            strSql.Append(") values (");
            strSql.Append("@PBM_ID,@PBM_Code,@PBM_SendEmail,@PBM_ReceiveEmail,@PBM_Text,@PBM_File,@PBM_Title,@PBM_State,@PBM_Del,@PBM_Creator,@PBM_CTime,@PBM_Mender,@PBM_MTime,@PBM_FID,@PBM_Type,@PBM_Cc,@PBM_Ms,@PBM_Minute,@PBM_SendType,@PBM_SendSettingID)");
            SqlParameter[] parameters = {
 new SqlParameter("@PBM_ID", SqlDbType.VarChar,50),
 new SqlParameter("@PBM_Code", SqlDbType.VarChar,50),
 new SqlParameter("@PBM_SendEmail", SqlDbType.VarChar,350),
 new SqlParameter("@PBM_ReceiveEmail", SqlDbType.VarChar,2000),
 new SqlParameter("@PBM_Text", SqlDbType.Text),
 new SqlParameter("@PBM_File", SqlDbType.Text),
 new SqlParameter("@PBM_Title", SqlDbType.VarChar,1000),
 new SqlParameter("@PBM_State", SqlDbType.Int,4),
 new SqlParameter("@PBM_Del", SqlDbType.Int,4),
 new SqlParameter("@PBM_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@PBM_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@PBM_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@PBM_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@PBM_FID", SqlDbType.VarChar,50),
 new SqlParameter("@PBM_Type", SqlDbType.Int,4),
 new SqlParameter("@PBM_Cc", SqlDbType.VarChar,500),
 new SqlParameter("@PBM_Ms", SqlDbType.VarChar,500),
 new SqlParameter("@PBM_Minute", SqlDbType.Decimal,16),
 new SqlParameter("@PBM_SendType", SqlDbType.Int,4),
 new SqlParameter("@PBM_SendSettingID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PBM_ID;
            parameters[1].Value = model.PBM_Code;
            parameters[2].Value = model.PBM_SendEmail;
            parameters[3].Value = model.PBM_ReceiveEmail;
            parameters[4].Value = model.PBM_Text;
            parameters[5].Value = model.PBM_File;
            parameters[6].Value = model.PBM_Title;
            parameters[7].Value = model.PBM_State;
            parameters[8].Value = model.PBM_Del;
            parameters[9].Value = model.PBM_Creator;
            parameters[10].Value = model.PBM_CTime;
            parameters[11].Value = model.PBM_Mender;
            parameters[12].Value = model.PBM_MTime;
            parameters[13].Value = model.PBM_FID;
            parameters[14].Value = model.PBM_Type;
            parameters[15].Value = model.PBM_Cc;
            parameters[16].Value = model.PBM_Ms;
            parameters[17].Value = model.PBM_Minute;
            parameters[18].Value = model.PBM_SendType;
            parameters[19].Value = model.PBM_SendSettingID;

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
        public bool Update(KNet.Model.PB_Basic_Mail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update PB_Basic_Mail set ");
            strSql.Append("PBM_Code=@PBM_Code,");
            strSql.Append("PBM_SendEmail=@PBM_SendEmail,");
            strSql.Append("PBM_ReceiveEmail=@PBM_ReceiveEmail,");
            strSql.Append("PBM_Text=@PBM_Text,");
            strSql.Append("PBM_File=@PBM_File,");
            strSql.Append("PBM_Title=@PBM_Title,");
            strSql.Append("PBM_State=@PBM_State,");
            strSql.Append("PBM_Del=@PBM_Del,");
            strSql.Append("PBM_Mender=@PBM_Mender,");
            strSql.Append("PBM_MTime=@PBM_MTime,");
            strSql.Append("PBM_FID=@PBM_FID,");
            strSql.Append("PBM_Type=@PBM_Type,");
            strSql.Append("PBM_Cc=@PBM_Cc,");
            strSql.Append("PBM_Ms=@PBM_Ms");
            strSql.Append(" where PBM_ID=@PBM_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@PBM_Code", SqlDbType.VarChar,50),
 new SqlParameter("@PBM_SendEmail", SqlDbType.VarChar,350),
 new SqlParameter("@PBM_ReceiveEmail", SqlDbType.VarChar,2000),
 new SqlParameter("@PBM_Text", SqlDbType.Text),
 new SqlParameter("@PBM_File", SqlDbType.Text),
 new SqlParameter("@PBM_Title", SqlDbType.VarChar,1000),
 new SqlParameter("@PBM_State", SqlDbType.Int,4),
 new SqlParameter("@PBM_Del", SqlDbType.Int,4),
 new SqlParameter("@PBM_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@PBM_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@PBM_FID", SqlDbType.VarChar,50),
 new SqlParameter("@PBM_Type", SqlDbType.Int,4),
 new SqlParameter("@PBM_Cc", SqlDbType.VarChar,500),
 new SqlParameter("@PBM_Ms", SqlDbType.VarChar,500),
new SqlParameter("@PBM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PBM_Code;
            parameters[1].Value = model.PBM_SendEmail;
            parameters[2].Value = model.PBM_ReceiveEmail;
            parameters[3].Value = model.PBM_Text;
            parameters[4].Value = model.PBM_File;
            parameters[5].Value = model.PBM_Title;
            parameters[6].Value = model.PBM_State;
            parameters[7].Value = model.PBM_Del;
            parameters[8].Value = model.PBM_Mender;
            parameters[9].Value = model.PBM_MTime;
            parameters[10].Value = model.PBM_FID;
            parameters[11].Value = model.PBM_Type;
            parameters[12].Value = model.PBM_Cc;
            parameters[13].Value = model.PBM_Ms;
            parameters[14].Value = model.PBM_ID;

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
        public bool Delete(string s_PBM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  PB_Basic_Mail  ");
            strSql.Append(" where PBM_ID=@PBM_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@PBM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = s_PBM_ID;
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


        public bool DeleteByOrderNo(string s_PBM_FID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  PB_Basic_Mail  ");
            strSql.Append(" where PBM_FID=@PBM_FID ");
            SqlParameter[] parameters = {
new SqlParameter("@PBM_FID", SqlDbType.VarChar,50)};
            parameters[0].Value = s_PBM_FID;
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
        public bool DeleteByFID(string s_PBM_FID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  PB_Basic_Mail  ");
            strSql.Append(" where PBM_FID=@PBM_FID ");
            SqlParameter[] parameters = {
new SqlParameter("@PBM_FID", SqlDbType.VarChar,50)};
            parameters[0].Value = s_PBM_FID;
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
        public bool UpdateDel(KNet.Model.PB_Basic_Mail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update   PB_Basic_Mail  Set ");
            strSql.Append("  PBM_Del=@PBM_Del ");
            strSql.Append(" where PBM_ID=@PBM_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@PBM_Del", SqlDbType.Int,4),
new SqlParameter("@PBM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PBM_Del;
            parameters[1].Value = model.PBM_ID;

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
        public bool DeleteList(string s_PBM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From   PB_Basic_Mail  ");
            strSql.Append(" where PBM_ID in ('" + s_PBM_ID + "')");

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
        /// 得到数据
        /// </summary>
        public KNet.Model.PB_Basic_Mail GetModel(string PBM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from PB_Basic_Mail  ");
            strSql.Append("where PBM_ID=@PBM_ID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@PBM_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = PBM_ID;
            KNet.Model.PB_Basic_Mail model = new KNet.Model.PB_Basic_Mail();
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
        public KNet.Model.PB_Basic_Mail DataRowToModel(DataRow row)
        {
            KNet.Model.PB_Basic_Mail model = new KNet.Model.PB_Basic_Mail();
            if (row != null)
            {
                if (row["PBM_ID"] != null)
                {
                    model.PBM_ID = row["PBM_ID"].ToString();
                }
                else
                {
                    model.PBM_ID = "";
                }
                if (row["PBM_Code"] != null)
                {
                    model.PBM_Code = row["PBM_Code"].ToString();
                }
                else
                {
                    model.PBM_Code = "";
                }
                if (row["PBM_SendEmail"] != null)
                {
                    model.PBM_SendEmail = row["PBM_SendEmail"].ToString();
                }
                else
                {
                    model.PBM_SendEmail = "";
                }
                if (row["PBM_ReceiveEmail"] != null)
                {
                    model.PBM_ReceiveEmail = row["PBM_ReceiveEmail"].ToString();
                }
                else
                {
                    model.PBM_ReceiveEmail = "";
                }
                if (row["PBM_Text"] != null)
                {
                    model.PBM_Text = row["PBM_Text"].ToString();
                }
                else
                {
                    model.PBM_Text = "";
                }
                if (row["PBM_File"] != null)
                {
                    model.PBM_File = row["PBM_File"].ToString();
                }
                else
                {
                    model.PBM_File = "";
                }
                if (row["PBM_Title"] != null)
                {
                    model.PBM_Title = row["PBM_Title"].ToString();
                }
                else
                {
                    model.PBM_Title = "";
                }
                if (row["PBM_State"] != null)
                {
                    model.PBM_State = int.Parse(row["PBM_State"].ToString());
                }
                else
                {
                    model.PBM_State = 0;
                }
                if (row["PBM_Del"] != null)
                {
                    model.PBM_Del = int.Parse(row["PBM_Del"].ToString());
                }
                else
                {
                    model.PBM_Del = 0;
                }
                if (row["PBM_Creator"] != null)
                {
                    model.PBM_Creator = row["PBM_Creator"].ToString();
                }
                else
                {
                    model.PBM_Creator = "";
                }
                if (row["PBM_CTime"] != null)
                {
                    model.PBM_CTime = DateTime.Parse(row["PBM_CTime"].ToString());
                }
                if (row["PBM_Mender"] != null)
                {
                    model.PBM_Mender = row["PBM_Mender"].ToString();
                }
                else
                {
                    model.PBM_Mender = "";
                }
                if (row["PBM_MTime"] != null)
                {
                    model.PBM_MTime = DateTime.Parse(row["PBM_MTime"].ToString());
                }
                if (row["PBM_FID"] != null)
                {
                    model.PBM_FID = row["PBM_FID"].ToString();
                }
                else
                {
                    model.PBM_FID = "";
                }
                if (row["PBM_Type"] != null)
                {
                    model.PBM_Type = int.Parse(row["PBM_Type"].ToString());
                }
                else
                {
                    model.PBM_Type = 0;
                }
                if (row["PBM_Cc"] != null)
                {
                    model.PBM_Cc = row["PBM_Cc"].ToString();
                }
                else
                {
                    model.PBM_Cc = "";
                }
                if (row["PBM_Ms"] != null)
                {
                    model.PBM_Ms = row["PBM_Ms"].ToString();
                }
                else
                {
                    model.PBM_Ms = "";
                }

                if (row["PBM_Minute"] != null)
                {
                    model.PBM_Minute = decimal.Parse(row["PBM_Minute"].ToString());
                }
                else
                {
                    model.PBM_Minute = 0;
                }


                if (row["PBM_SendType"] != null)
                {
                    model.PBM_SendType = int.Parse(row["PBM_SendType"].ToString());
                }
                else
                {
                    model.PBM_SendType = 0;
                }
                if (row["PBM_SendSettingID"] != null)
                {
                    model.PBM_SendSettingID = row["PBM_SendSettingID"].ToString();
                }
                else
                {
                    model.PBM_SendSettingID = "";
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
            strSql.Append("select PBM_ID,PBM_Code,PBM_SendEmail,PBM_ReceiveEmail,PBM_Title,PBM_State,PBM_Creator,PBM_CTime,PBM_Mender,PBM_MTime,PBM_FID,PBM_Type,PBM_Cc,PBM_Ms,PBM_Minute,PBM_SendType,PBM_SendSettingID,PBM_Times,PBM_Del ");
            strSql.Append(" FROM PB_Basic_Mail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

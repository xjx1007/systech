using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;


namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sys_Config。
    /// </summary>
    public class KNet_Sys_Config
    {
        public KNet_Sys_Config()
        { }
        #region  成员方法
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sys_Config model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Sys_Config set ");
            strSql.Append("Sys_CompanyName=@Sys_CompanyName,");
            strSql.Append("Sys_NoticeYN=@Sys_NoticeYN,");
            strSql.Append("Sys_NoticeContent=@Sys_NoticeContent,");
            strSql.Append("Sys_LogsYN=@Sys_LogsYN,");
            strSql.Append("Sys_OutWarning=@Sys_OutWarning,");
            strSql.Append("Sys_Key=@Sys_Key,");
            strSql.Append("Sys_UserNo=@Sys_UserNo");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Sys_CompanyName", SqlDbType.NVarChar,100),
					new SqlParameter("@Sys_NoticeYN", SqlDbType.Bit,1),
					new SqlParameter("@Sys_NoticeContent", SqlDbType.NText),
					new SqlParameter("@Sys_LogsYN", SqlDbType.Bit,1),
					new SqlParameter("@Sys_OutWarning", SqlDbType.Bit,1),
					new SqlParameter("@Sys_Key", SqlDbType.NVarChar,50),
					new SqlParameter("@Sys_UserNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Sys_CompanyName;
            parameters[2].Value = model.Sys_NoticeYN;
            parameters[3].Value = model.Sys_NoticeContent;
            parameters[4].Value = model.Sys_LogsYN;
            parameters[5].Value = model.Sys_OutWarning;
            parameters[6].Value = model.Sys_Key;
            parameters[7].Value = model.Sys_UserNo;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sys_Config GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Sys_CompanyName,Sys_NoticeYN,Sys_NoticeContent,Sys_LogsYN,Sys_OutWarning,Sys_Key,Sys_UserNo from KNet_Sys_Config ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            KNet.Model.KNet_Sys_Config model = new KNet.Model.KNet_Sys_Config();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.Sys_CompanyName = ds.Tables[0].Rows[0]["Sys_CompanyName"].ToString();
                if (ds.Tables[0].Rows[0]["Sys_NoticeYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Sys_NoticeYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["Sys_NoticeYN"].ToString().ToLower() == "true"))
                    {
                        model.Sys_NoticeYN = true;
                    }
                    else
                    {
                        model.Sys_NoticeYN = false;
                    }
                }
                model.Sys_NoticeContent = ds.Tables[0].Rows[0]["Sys_NoticeContent"].ToString();
                if (ds.Tables[0].Rows[0]["Sys_LogsYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Sys_LogsYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["Sys_LogsYN"].ToString().ToLower() == "true"))
                    {
                        model.Sys_LogsYN = true;
                    }
                    else
                    {
                        model.Sys_LogsYN = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Sys_OutWarning"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Sys_OutWarning"].ToString() == "1") || (ds.Tables[0].Rows[0]["Sys_OutWarning"].ToString().ToLower() == "true"))
                    {
                        model.Sys_OutWarning = true;
                    }
                    else
                    {
                        model.Sys_OutWarning = false;
                    }
                }
                model.Sys_Key = ds.Tables[0].Rows[0]["Sys_Key"].ToString();
                model.Sys_UserNo = ds.Tables[0].Rows[0]["Sys_UserNo"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion  成员方法
    }
}


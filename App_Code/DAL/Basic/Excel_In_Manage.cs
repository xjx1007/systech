using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class Excel_In_Manage
    {
        public Excel_In_Manage()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string EIM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Excel_In_Manage");
            strSql.Append(" where EIM_ID=@EIM_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@EIM_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = EIM_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.Excel_In_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Excel_In_Manage(");
            strSql.Append("EIM_ID,EIM_FID,EIM_Type,EIM_Name,EIM_Details1,EIM_Details2,EIM_Details3,EIM_Details4,EIM_Details5,EIM_Details6,EIM_Details7 ");
            strSql.Append(") values (");
            strSql.Append("@EIM_ID,@EIM_FID,@EIM_Type,@EIM_Name,@EIM_Details1,@EIM_Details2,@EIM_Details3,@EIM_Details4,@EIM_Details5,@EIM_Details6,@EIM_Details7)");
            SqlParameter[] parameters = {
 new SqlParameter("@EIM_ID", SqlDbType.VarChar,50),
 new SqlParameter("@EIM_FID", SqlDbType.VarChar,50),
 new SqlParameter("@EIM_Type", SqlDbType.VarChar,50),
 new SqlParameter("@EIM_Name", SqlDbType.VarChar,300),
 new SqlParameter("@EIM_Details1", SqlDbType.VarChar,500),
 new SqlParameter("@EIM_Details2", SqlDbType.VarChar,500),
 new SqlParameter("@EIM_Details3", SqlDbType.VarChar,500),
 new SqlParameter("@EIM_Details4", SqlDbType.VarChar,500),
 new SqlParameter("@EIM_Details5", SqlDbType.VarChar,500),
 new SqlParameter("@EIM_Details6", SqlDbType.VarChar,500),
 new SqlParameter("@EIM_Details7", SqlDbType.VarChar,500)};
            parameters[0].Value = model.EIM_ID;
            parameters[1].Value = model.EIM_FID;
            parameters[2].Value = model.EIM_Type;
            parameters[3].Value = model.EIM_Name;
            parameters[4].Value = model.EIM_Details1;
            parameters[5].Value = model.EIM_Details2;
            parameters[6].Value = model.EIM_Details3;
            parameters[7].Value = model.EIM_Details4;
            parameters[8].Value = model.EIM_Details5;
            parameters[9].Value = model.EIM_Details6;
            parameters[10].Value = model.EIM_Details7;
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
        public bool Update(KNet.Model.Excel_In_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update Excel_In_Manage set ");
            strSql.Append("EIM_FID=@EIM_FID,");
            strSql.Append("EIM_Type=@EIM_Type,");
            strSql.Append("EIM_Name=@EIM_Name,");
            strSql.Append("EIM_Details1=@EIM_Details1,");
            strSql.Append("EIM_Details2=@EIM_Details2,");
            strSql.Append("EIM_Details3=@EIM_Details3,");
            strSql.Append("EIM_Details4=@EIM_Details4,");
            strSql.Append("EIM_Details5=@EIM_Details5,");
            strSql.Append("EIM_Details6=@EIM_Details6,");
            strSql.Append("EIM_Details7=@EIM_Details7");
            strSql.Append(" where EIM_ID=@EIM_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@EIM_FID", SqlDbType.VarChar,50),
 new SqlParameter("@EIM_Type", SqlDbType.VarChar,50),
 new SqlParameter("@EIM_Name", SqlDbType.VarChar,300),
 new SqlParameter("@EIM_Details1", SqlDbType.VarChar,500),
 new SqlParameter("@EIM_Details2", SqlDbType.VarChar,500),
 new SqlParameter("@EIM_Details3", SqlDbType.VarChar,500),
 new SqlParameter("@EIM_Details4", SqlDbType.VarChar,500),
 new SqlParameter("@EIM_Details5", SqlDbType.VarChar,500),
 new SqlParameter("@EIM_Details6", SqlDbType.VarChar,500),
 new SqlParameter("@EIM_Details7", SqlDbType.VarChar,500),
new SqlParameter("@EIM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.EIM_FID;
            parameters[1].Value = model.EIM_Type;
            parameters[2].Value = model.EIM_Name;
            parameters[3].Value = model.EIM_Details1;
            parameters[4].Value = model.EIM_Details2;
            parameters[5].Value = model.EIM_Details3;
            parameters[6].Value = model.EIM_Details4;
            parameters[7].Value = model.EIM_Details5;
            parameters[8].Value = model.EIM_Details6;
            parameters[9].Value = model.EIM_Details7;
            parameters[10].Value = model.EIM_ID;

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
        /// DeleteByFID
        /// </summary>
        public bool DeleteByFID(string s_FID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  Excel_In_Manage  ");
            strSql.Append(" Where  EIM_FID=@EIM_FID ");
            SqlParameter[] parameters = {
 new SqlParameter("@EIM_FID", SqlDbType.VarChar,50),
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
        public KNet.Model.Excel_In_Manage GetModel(string EIM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from Excel_In_Manage  ");
            strSql.Append("where EIM_ID=@EIM_ID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@EIM_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = EIM_ID;
            KNet.Model.Excel_In_Manage model = new KNet.Model.Excel_In_Manage();
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
        public KNet.Model.Excel_In_Manage DataRowToModel(DataRow row)
        {
            KNet.Model.Excel_In_Manage model = new KNet.Model.Excel_In_Manage();
            if (row != null)
            {
                if (row["EIM_ID"] != null)
                {
                    model.EIM_ID = row["EIM_ID"].ToString();
                }
                else
                {
                    model.EIM_ID = "";
                }
                if (row["EIM_FID"] != null)
                {
                    model.EIM_FID = row["EIM_FID"].ToString();
                }
                else
                {
                    model.EIM_FID = "";
                }
                if (row["EIM_Type"] != null)
                {
                    model.EIM_Type = row["EIM_Type"].ToString();
                }
                else
                {
                    model.EIM_Type = "";
                }
                if (row["EIM_Name"] != null)
                {
                    model.EIM_Name = row["EIM_Name"].ToString();
                }
                else
                {
                    model.EIM_Name = "";
                }
                if (row["EIM_Details1"] != null)
                {
                    model.EIM_Details1 = row["EIM_Details1"].ToString();
                }
                else
                {
                    model.EIM_Details1 = "";
                }
                if (row["EIM_Details2"] != null)
                {
                    model.EIM_Details2 = row["EIM_Details2"].ToString();
                }
                else
                {
                    model.EIM_Details2 = "";
                }
                if (row["EIM_Details3"] != null)
                {
                    model.EIM_Details3 = row["EIM_Details3"].ToString();
                }
                else
                {
                    model.EIM_Details3 = "";
                }
                if (row["EIM_Details4"] != null)
                {
                    model.EIM_Details4 = row["EIM_Details4"].ToString();
                }
                else
                {
                    model.EIM_Details4 = "";
                }
                if (row["EIM_Details5"] != null)
                {
                    model.EIM_Details5 = row["EIM_Details5"].ToString();
                }
                else
                {
                    model.EIM_Details5 = "";
                }
                if (row["EIM_Details6"] != null)
                {
                    model.EIM_Details6 = row["EIM_Details6"].ToString();
                }
                else
                {
                    model.EIM_Details6 = "";
                }
                if (row["EIM_Details7"] != null)
                {
                    model.EIM_Details7 = row["EIM_Details7"].ToString();
                }
                else
                {
                    model.EIM_Details7 = "";
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
            strSql.Append(" FROM Excel_In_Manage ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class Excel_In_Details
    {
        public Excel_In_Details()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string EID_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Excel_In_Details");
            strSql.Append(" where EID_ID=@EID_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@EID_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = EID_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.Excel_In_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Excel_In_Details(");
            strSql.Append("EID_ID,EID_FID,EID_YLine,EID_Name,EID_ColName ");
            strSql.Append(") values (");
            strSql.Append("@EID_ID,@EID_FID,@EID_YLine,@EID_Name,@EID_ColName)");
            SqlParameter[] parameters = {
 new SqlParameter("@EID_ID", SqlDbType.VarChar,50),
 new SqlParameter("@EID_FID", SqlDbType.VarChar,50),
 new SqlParameter("@EID_YLine", SqlDbType.Int,4),
 new SqlParameter("@EID_Name", SqlDbType.VarChar,500),
 new SqlParameter("@EID_ColName", SqlDbType.VarChar,500)};
            parameters[0].Value = model.EID_ID;
            parameters[1].Value = model.EID_FID;
            parameters[2].Value = model.EID_YLine;
            parameters[3].Value = model.EID_Name;
            parameters[4].Value = model.EID_ColName;
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
        public bool Update(KNet.Model.Excel_In_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update Excel_In_Details set ");
            strSql.Append("EID_FID=@EID_FID,");
            strSql.Append("EID_YLine=@EID_YLine,");
            strSql.Append("EID_Name=@EID_Name,");
            strSql.Append("EID_ColName=@EID_ColName");
            strSql.Append(" where EID_ID=@EID_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@EID_FID", SqlDbType.VarChar,50),
 new SqlParameter("@EID_YLine", SqlDbType.Int,4),
 new SqlParameter("@EID_Name", SqlDbType.VarChar,500),
 new SqlParameter("@EID_ColName", SqlDbType.VarChar,500),
new SqlParameter("@EID_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.EID_FID;
            parameters[1].Value = model.EID_YLine;
            parameters[2].Value = model.EID_Name;
            parameters[3].Value = model.EID_ColName;
            parameters[4].Value = model.EID_ID;

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
            strSql.Append("delete from  Excel_In_Details  ");
            strSql.Append(" Where  EID_FID=@EID_FID ");
            SqlParameter[] parameters = {
 new SqlParameter("@EID_FID", SqlDbType.VarChar,50),
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
        public KNet.Model.Excel_In_Details GetModel(string EID_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from Excel_In_Details  ");
            strSql.Append("where EID_ID=@EID_ID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@EID_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = EID_ID;
            KNet.Model.Excel_In_Details model = new KNet.Model.Excel_In_Details();
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
        public KNet.Model.Excel_In_Details DataRowToModel(DataRow row)
        {
            KNet.Model.Excel_In_Details model = new KNet.Model.Excel_In_Details();
            if (row != null)
            {
                if (row["EID_ID"] != null)
                {
                    model.EID_ID = row["EID_ID"].ToString();
                }
                else
                {
                    model.EID_ID = "";
                }
                if (row["EID_FID"] != null)
                {
                    model.EID_FID = row["EID_FID"].ToString();
                }
                else
                {
                    model.EID_FID = "";
                }
                if (row["EID_YLine"] != null)
                {
                    model.EID_YLine = int.Parse(row["EID_YLine"].ToString());
                }
                else
                {
                    model.EID_YLine = 0;
                }
                if (row["EID_Name"] != null)
                {
                    model.EID_Name = row["EID_Name"].ToString();
                }
                else
                {
                    model.EID_Name = "";
                }
                if (row["EID_ColName"] != null)
                {
                    model.EID_ColName = row["EID_ColName"].ToString();
                }
                else
                {
                    model.EID_ColName = "";
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
            strSql.Append(" FROM Excel_In_Details ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

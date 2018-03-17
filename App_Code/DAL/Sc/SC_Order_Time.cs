using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class SC_Order_Time
    {
        public SC_Order_Time()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SOT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SC_Order_Time");
            strSql.Append(" where SOT_ID=@SOT_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@SOT_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = SOT_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.SC_Order_Time model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SC_Order_Time(");
            strSql.Append("SOT_ID,SOT_FID,SOT_Number,SOT_OldTime,SOT_NewTime,SOT_State,SOT_Details,SOT_CTime,SOT_Creator ");
            strSql.Append(") values (");
            strSql.Append("@SOT_ID,@SOT_FID,@SOT_Number,@SOT_OldTime,@SOT_NewTime,@SOT_State,@SOT_Details,@SOT_CTime,@SOT_Creator)");
            SqlParameter[] parameters = {
 new SqlParameter("@SOT_ID", SqlDbType.VarChar,50),
 new SqlParameter("@SOT_FID", SqlDbType.VarChar,50),
 new SqlParameter("@SOT_Number", SqlDbType.Int,4),
 new SqlParameter("@SOT_OldTime", SqlDbType.DateTime,8),
 new SqlParameter("@SOT_NewTime", SqlDbType.DateTime,8),
 new SqlParameter("@SOT_State", SqlDbType.Int,4),
 new SqlParameter("@SOT_Details", SqlDbType.VarChar,500),
 new SqlParameter("@SOT_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@SOT_Creator", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SOT_ID;
            parameters[1].Value = model.SOT_FID;
            parameters[2].Value = model.SOT_Number;
            parameters[3].Value = model.SOT_OldTime;
            parameters[4].Value = model.SOT_NewTime;
            parameters[5].Value = model.SOT_State;
            parameters[6].Value = model.SOT_Details;
            parameters[7].Value = model.SOT_CTime;
            parameters[8].Value = model.SOT_Creator;
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
        public bool Update(KNet.Model.SC_Order_Time model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update SC_Order_Time set ");
            strSql.Append("SOT_FID=@SOT_FID,");
            strSql.Append("SOT_Number=@SOT_Number,");
            strSql.Append("SOT_OldTime=@SOT_OldTime,");
            strSql.Append("SOT_NewTime=@SOT_NewTime,");
            strSql.Append("SOT_State=@SOT_State,");
            strSql.Append("SOT_Details=@SOT_Details");
            strSql.Append(" where SOT_ID=@SOT_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@SOT_FID", SqlDbType.VarChar,50),
 new SqlParameter("@SOT_Number", SqlDbType.Int,4),
 new SqlParameter("@SOT_OldTime", SqlDbType.DateTime,8),
 new SqlParameter("@SOT_NewTime", SqlDbType.DateTime,8),
 new SqlParameter("@SOT_State", SqlDbType.Int,4),
 new SqlParameter("@SOT_Details", SqlDbType.VarChar,500),
new SqlParameter("@SOT_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SOT_FID;
            parameters[1].Value = model.SOT_Number;
            parameters[2].Value = model.SOT_OldTime;
            parameters[3].Value = model.SOT_NewTime;
            parameters[4].Value = model.SOT_State;
            parameters[5].Value = model.SOT_Details;
            parameters[6].Value = model.SOT_ID;

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
        public bool Delete(string s_SOT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  SC_Order_Time  ");
            strSql.Append(" where SOT_ID=@SOT_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@SOT_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = s_SOT_ID;
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
        public bool UpdateDel(KNet.Model.SC_Order_Time model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update   SC_Order_Time  Set ");
            strSql.Append(" where SOT_ID=@SOT_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@SOT_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SOT_ID;

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
        public bool DeleteList(string s_SOT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From   SC_Order_Time  ");
            strSql.Append(" where SOT_ID in ('" + s_SOT_ID + "')");

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
            strSql.Append("Select * from  SC_Order_Time  ");
            strSql.Append(" Where  SOT_FID=@SOT_FID ");
            SqlParameter[] parameters = {
 new SqlParameter("@SOT_FID", SqlDbType.VarChar,50),
};
            parameters[0].Value = s_FID;

            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// DeleteByFID
        /// </summary>
        public bool DeleteByFID(string s_FID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  SC_Order_Time  ");
            strSql.Append(" Where  SOT_FID=@SOT_FID ");
            SqlParameter[] parameters = {
 new SqlParameter("@SOT_FID", SqlDbType.VarChar,50),
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
        public KNet.Model.SC_Order_Time GetModel(string SOT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from SC_Order_Time  ");
            strSql.Append("where SOT_ID=@SOT_ID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@SOT_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = SOT_ID;
            KNet.Model.SC_Order_Time model = new KNet.Model.SC_Order_Time();
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
        public KNet.Model.SC_Order_Time DataRowToModel(DataRow row)
        {
            KNet.Model.SC_Order_Time model = new KNet.Model.SC_Order_Time();
            if (row != null)
            {
                if (row["SOT_ID"] != null)
                {
                    model.SOT_ID = row["SOT_ID"].ToString();
                }
                else
                {
                    model.SOT_ID = "";
                }
                if (row["SOT_FID"] != null)
                {
                    model.SOT_FID = row["SOT_FID"].ToString();
                }
                else
                {
                    model.SOT_FID = "";
                }
                if (row["SOT_Number"] != null)
                {
                    model.SOT_Number = int.Parse(row["SOT_Number"].ToString());
                }
                else
                {
                    model.SOT_Number = 0;
                }
                if (row["SOT_OldTime"] != null)
                {
                    model.SOT_OldTime = DateTime.Parse(row["SOT_OldTime"].ToString());
                }
                if (row["SOT_NewTime"] != null)
                {
                    model.SOT_NewTime = DateTime.Parse(row["SOT_NewTime"].ToString());
                }
                if (row["SOT_State"] != null)
                {
                    model.SOT_State = int.Parse(row["SOT_State"].ToString());
                }
                else
                {
                    model.SOT_State = 0;
                }
                if (row["SOT_Details"] != null)
                {
                    model.SOT_Details = row["SOT_Details"].ToString();
                }
                else
                {
                    model.SOT_Details = "";
                }
                if (row["SOT_CTime"] != null)
                {
                    model.SOT_CTime = DateTime.Parse(row["SOT_CTime"].ToString());
                }
                if (row["SOT_Creator"] != null)
                {
                    model.SOT_Creator = row["SOT_Creator"].ToString();
                }
                else
                {
                    model.SOT_Creator = "";
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
            strSql.Append(" FROM SC_Order_Time ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

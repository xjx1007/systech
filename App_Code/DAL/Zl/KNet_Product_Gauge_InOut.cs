using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class KNet_Product_Gauge_InOut
    {
        public KNet_Product_Gauge_InOut()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KNet_Product_Gauge_InOut");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
new SqlParameter("@ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.KNet_Product_Gauge_InOut model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Product_Gauge_InOut(");
            strSql.Append("KPI_SID,KPI_Code,KPI_Number,KPI_UseFrom,KPI_UserIn,KPI_InOut,KPI_Person,KPI_Type,KPI_Time,KPI_Text,KPI_State,KPI_BadNumber ");
            strSql.Append(") values (");
            strSql.Append("@KPI_SID,@KPI_Code,@KPI_Number,@KPI_UseFrom,@KPI_UserIn,@KPI_InOut,@KPI_Person,@KPI_Type,@KPI_Time,@KPI_Text,@KPI_State,@KPI_BadNumber)");
            SqlParameter[] parameters = {
 
 new SqlParameter("@KPI_SID", SqlDbType.VarChar,50),
 new SqlParameter("@KPI_Code", SqlDbType.VarChar,50),
 new SqlParameter("@KPI_Number", SqlDbType.Int,4),
 new SqlParameter("@KPI_UseFrom", SqlDbType.VarChar,50),
 new SqlParameter("@KPI_UserIn", SqlDbType.VarChar,50),
 new SqlParameter("@KPI_InOut", SqlDbType.Int,4),
 new SqlParameter("@KPI_Person", SqlDbType.VarChar,50),
 new SqlParameter("@KPI_Type", SqlDbType.Int,4),
 new SqlParameter("@KPI_Time", SqlDbType.DateTime,8),
 new SqlParameter("@KPI_Text", SqlDbType.Text),
            new SqlParameter("@KPI_State", SqlDbType.Int),
            new SqlParameter("@KPI_BadNumber", SqlDbType.Int)};
            
            parameters[0].Value = model.KPI_SID;
            parameters[1].Value = model.KPI_Code;
            parameters[2].Value = model.KPI_Number;
            parameters[3].Value = model.KPI_UseFrom;
            parameters[4].Value = model.KPI_UserIn;
            parameters[5].Value = model.KPI_InOut;
            parameters[6].Value = model.KPI_Person;
            parameters[7].Value = model.KPI_Type;
            parameters[8].Value = model.KPI_Time;
            parameters[9].Value = model.KPI_Text;
            parameters[10].Value = model.KPI_State;
            parameters[11].Value = model.KPI_BadNumber;
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
        public bool Update(KNet.Model.KNet_Product_Gauge_InOut model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update KNet_Product_Gauge_InOut set ");
            strSql.Append("KPI_SID=@KPI_SID,");
            strSql.Append("KPI_Code=@KPI_Code,");
            strSql.Append("KPI_Number=@KPI_Number,");
            strSql.Append("KPI_UseFrom=@KPI_UseFrom,");
            strSql.Append("KPI_UserIn=@KPI_UserIn,");
            strSql.Append("KPI_InOut=@KPI_InOut,");
            strSql.Append("KPI_Person=@KPI_Person,");
            strSql.Append("KPI_Type=@KPI_Type,");
            strSql.Append("KPI_Time=@KPI_Time,");
            strSql.Append("KPI_Text=@KPI_Text,");
            strSql.Append("KPI_State=@KPI_State,");
            strSql.Append("KPI_BadNamber=@KPI_BadNumber");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@KPI_SID", SqlDbType.VarChar,50),
 new SqlParameter("@KPI_Code", SqlDbType.VarChar,50),
 new SqlParameter("@KPI_Number", SqlDbType.Int,4),
 new SqlParameter("@KPI_UseFrom", SqlDbType.VarChar,50),
 new SqlParameter("@KPI_UserIn", SqlDbType.VarChar,50),
 new SqlParameter("@KPI_InOut", SqlDbType.Int,4),
 new SqlParameter("@KPI_Person", SqlDbType.VarChar,50),
 new SqlParameter("@KPI_Type", SqlDbType.Int,4),
 new SqlParameter("@KPI_Time", SqlDbType.DateTime,8),
 new SqlParameter("@KPI_Text", SqlDbType.Text),
 new SqlParameter("@KPI_State", SqlDbType.Int),
 new SqlParameter("@KPI_BadNumber", SqlDbType.Int),
new SqlParameter("@ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KPI_SID;
            parameters[1].Value = model.KPI_Code;
            parameters[2].Value = model.KPI_Number;
            parameters[3].Value = model.KPI_UseFrom;
            parameters[4].Value = model.KPI_UserIn;
            parameters[5].Value = model.KPI_InOut;
            parameters[6].Value = model.KPI_Person;
            parameters[7].Value = model.KPI_Type;
            parameters[8].Value = model.KPI_Time;
            parameters[9].Value = model.KPI_Text;
            parameters[10].Value = model.KPI_State;
            parameters[11].Value = model.KPI_BadNumber;
            parameters[12].Value = model.ID;

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
        public bool Delete(string s_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  KNet_Product_Gauge_InOut  ");
            strSql.Append(" where KPI_SID=@KPI_SID ");
            SqlParameter[] parameters = {
new SqlParameter("@KPI_SID", SqlDbType.VarChar,50)};
            parameters[0].Value = s_ID;
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
        public bool UpdateDel(KNet.Model.KNet_Product_Gauge_InOut model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update   KNet_Product_Gauge_InOut  Set ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
new SqlParameter("@ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ID;

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
        public bool DeleteList(string s_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From   KNet_Product_Gauge_InOut  ");
            strSql.Append(" where ID in ('" + s_ID + "')");

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
            strSql.Append("Select * from  KNet_Product_Gauge_InOut  ");
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
            strSql.Append("delete from  KNet_Product_Gauge_InOut  ");
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
        public KNet.Model.KNet_Product_Gauge_InOut GetModel(string KPI_SID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select top 1 * from KNet_Product_Gauge_InOut  ");
            strSql.Append("where KPI_SID=@KPI_SID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@KPI_SID", SqlDbType.VarChar,50)
};
            parameters[0].Value = KPI_SID;
            KNet.Model.KNet_Product_Gauge_InOut model = new KNet.Model.KNet_Product_Gauge_InOut();
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
        public KNet.Model.KNet_Product_Gauge_InOut GetModel1(string KPI_SID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select  * from KNet_Product_Gauge_InOut  ");
            strSql.Append("where KPI_SID=@KPI_SID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@KPI_SID", SqlDbType.VarChar,50)
};
            parameters[0].Value = KPI_SID;
            KNet.Model.KNet_Product_Gauge_InOut model = new KNet.Model.KNet_Product_Gauge_InOut();
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
        public KNet.Model.KNet_Product_Gauge_InOut DataRowToModel(DataRow row)
        {
            KNet.Model.KNet_Product_Gauge_InOut model = new KNet.Model.KNet_Product_Gauge_InOut();
            if (row != null)
            {
              
                if (row["KPI_SID"] != null)
                {
                    model.KPI_SID = row["KPI_SID"].ToString();
                }
                else
                {
                    model.KPI_SID = "";
                }
                if (row["KPI_Code"] != null)
                {
                    model.KPI_Code = row["KPI_Code"].ToString();
                }
                else
                {
                    model.KPI_Code = "";
                }
                if (row["KPI_Number"] != null)
                {
                    model.KPI_Number = int.Parse(row["KPI_Number"].ToString());
                }
                else
                {
                    model.KPI_Number = 0;
                }
                if (row["KPI_UseFrom"] != null)
                {
                    model.KPI_UseFrom = row["KPI_UseFrom"].ToString();
                }
                else
                {
                    model.KPI_UseFrom = "";
                }
                if (row["KPI_UserIn"] != null)
                {
                    model.KPI_UserIn = row["KPI_UserIn"].ToString();
                }
                else
                {
                    model.KPI_UserIn = "";
                }
                if (row["KPI_InOut"] != null)
                {
                    model.KPI_InOut = int.Parse(row["KPI_InOut"].ToString());
                }
                else
                {
                    model.KPI_InOut = 0;
                }
                if (row["KPI_Person"] != null)
                {
                    model.KPI_Person = row["KPI_Person"].ToString();
                }
                else
                {
                    model.KPI_Person = "";
                }
                if (row["KPI_Type"] != null)
                {
                    model.KPI_Type = int.Parse(row["KPI_Type"].ToString());
                }
                else
                {
                    model.KPI_Type = 0;
                }
                if (row["KPI_Time"] != null)
                {
                    model.KPI_Time = DateTime.Parse(row["KPI_Time"].ToString());
                }
                if (row["KPI_Text"] != null)
                {
                    model.KPI_Text = row["KPI_Text"].ToString();
                }
                else
                {
                    model.KPI_Text = "";
                }
                if (row["KPI_State"] != null)
                {
                    model.KPI_State =int.Parse(row["KPI_State"].ToString()) ;
                }
                else
                {
                    model.KPI_State = 0;
                }
                if (row["KPI_BadNumber"] != null)
                {
                    model.KPI_BadNumber = int.Parse(row["KPI_BadNumber"].ToString());
                }
                else
                {
                    model.KPI_BadNumber = 0;
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
            strSql.Append(" FROM KNet_Product_Gauge_InOut ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetList1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct KPI_SID ");
            strSql.Append(" FROM KNet_Product_Gauge_InOut ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

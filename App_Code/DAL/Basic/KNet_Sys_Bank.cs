using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class KNet_Sys_Bank
    {
        public KNet_Sys_Bank()
        { }

        public bool Exists(string BankName, string BankCount)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
                    new SqlParameter("@BankName", SqlDbType.NVarChar,50),
					new SqlParameter("@BankCount", SqlDbType.NVarChar,50)};
            parameters[0].Value = BankName;
            parameters[1].Value = BankCount;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sys_Bank_Exists", parameters, out rowsAffected);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.KNet_Sys_Bank model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Sys_Bank(");
            strSql.Append("ID,BankNo,BankName,BankCount,BankAmount,BankPai,InitialAmount,KSB_STime ");
            strSql.Append(") values (");
            strSql.Append("@ID,@BankNo,@BankName,@BankCount,@BankAmount,@BankPai,@InitialAmount,@KSB_STime)");
            SqlParameter[] parameters = {
 new SqlParameter("@ID", SqlDbType.VarChar,100),
 new SqlParameter("@BankNo", SqlDbType.VarChar,100),
 new SqlParameter("@BankName", SqlDbType.VarChar,100),
 new SqlParameter("@BankCount", SqlDbType.VarChar,100),
 new SqlParameter("@BankAmount", SqlDbType.Decimal,9),
 new SqlParameter("@BankPai", SqlDbType.Int,4),
 new SqlParameter("@InitialAmount", SqlDbType.Decimal,9),
 new SqlParameter("@KSB_STime", SqlDbType.DateTime,8)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BankNo;
            parameters[2].Value = model.BankName;
            parameters[3].Value = model.BankCount;
            parameters[4].Value = model.BankAmount;
            parameters[5].Value = model.BankPai;
            parameters[6].Value = model.InitialAmount;
            parameters[7].Value = model.KSB_STime;
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
        public bool Update(KNet.Model.KNet_Sys_Bank model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update KNet_Sys_Bank set ");
            strSql.Append("BankName=@BankName,");
            strSql.Append("BankCount=@BankCount,");
            strSql.Append("BankAmount=@BankAmount,");
            strSql.Append("BankPai=@BankPai,");
            strSql.Append("InitialAmount=@InitialAmount,");
            strSql.Append("KSB_STime=@KSB_STime");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@BankName", SqlDbType.VarChar,100),
 new SqlParameter("@BankCount", SqlDbType.VarChar,100),
 new SqlParameter("@BankAmount", SqlDbType.Decimal,9),
 new SqlParameter("@BankPai", SqlDbType.Int,4),
 new SqlParameter("@InitialAmount", SqlDbType.Decimal,9),
 new SqlParameter("@KSB_STime", SqlDbType.DateTime,8),
new SqlParameter("@ID", SqlDbType.VarChar,100)};
            parameters[0].Value = model.BankName;
            parameters[1].Value = model.BankCount;
            parameters[2].Value = model.BankAmount;
            parameters[3].Value = model.BankPai;
            parameters[4].Value = model.InitialAmount;
            parameters[5].Value = model.KSB_STime;
            parameters[6].Value = model.ID;

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
            strSql.Append("delete from  KNet_Sys_Bank  ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
new SqlParameter("@ID", SqlDbType.VarChar,100)};
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
        public bool UpdateDel(KNet.Model.KNet_Sys_Bank model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update   KNet_Sys_Bank  Set ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
new SqlParameter("@ID", SqlDbType.VarChar,100)};
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
            strSql.Append("Delete From   KNet_Sys_Bank  ");
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
            strSql.Append("Select * from  KNet_Sys_Bank  ");
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
            strSql.Append("delete from  KNet_Sys_Bank  ");
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
        public KNet.Model.KNet_Sys_Bank GetModel(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from KNet_Sys_Bank  ");
            strSql.Append("where BankNo=@BankNo  ");
            SqlParameter[] parameters = {
 new SqlParameter("@BankNo", SqlDbType.VarChar,100)
};
            parameters[0].Value = ID;
            KNet.Model.KNet_Sys_Bank model = new KNet.Model.KNet_Sys_Bank();
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
        public KNet.Model.KNet_Sys_Bank DataRowToModel(DataRow row)
        {
            KNet.Model.KNet_Sys_Bank model = new KNet.Model.KNet_Sys_Bank();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                else
                {
                    model.ID = "";
                }
                if (row["BankNo"] != null)
                {
                    model.BankNo = row["BankNo"].ToString();
                }
                else
                {
                    model.BankNo = "";
                }
                if (row["BankName"] != null)
                {
                    model.BankName = row["BankName"].ToString();
                }
                else
                {
                    model.BankName = "";
                }
                if (row["BankCount"] != null)
                {
                    model.BankCount = row["BankCount"].ToString();
                }
                else
                {
                    model.BankCount = "";
                }
                if (row["BankAmount"] != null)
                {
                    model.BankAmount = Decimal.Parse(row["BankAmount"].ToString());
                }
                else
                {
                    model.BankAmount = 0;
                }
                if (row["BankPai"] != null)
                {
                    model.BankPai = int.Parse(row["BankPai"].ToString());
                }
                else
                {
                    model.BankPai = 0;
                }
                if (row["InitialAmount"] != null)
                {
                    model.InitialAmount = Decimal.Parse(row["InitialAmount"].ToString());
                }
                else
                {
                    model.InitialAmount = 0;
                }
                if (row["KSB_STime"] != null)
                {
                    model.KSB_STime = DateTime.Parse(row["KSB_STime"].ToString());
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
            strSql.Append("select *,BankName+'('+BankNo+')' as AA ");
            strSql.Append(" FROM KNet_Sys_Bank ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

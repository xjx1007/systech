using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class CG_Account_Bill
    {
        public CG_Account_Bill()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CAB_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CG_Account_Bill");
            strSql.Append(" where CAB_ID=@CAB_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@CAB_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = CAB_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.CG_Account_Bill model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CG_Account_Bill(");
            strSql.Append("CAB_ID,CAB_Code,CAB_SuppNo,CAB_Stime,CAB_FpCode,CAB_BillType,CAB_PayMent,CAB_Money,CAB_Remarks,CAB_DutyPerson,CAB_Brokerage,CAB_State,CAB_Del,CAB_CTime,CAB_Creator,CAB_MTime,CAB_Mender,CAB_CheckNo ");
            strSql.Append(") values (");
            strSql.Append("@CAB_ID,@CAB_Code,@CAB_SuppNo,@CAB_Stime,@CAB_FpCode,@CAB_BillType,@CAB_PayMent,@CAB_Money,@CAB_Remarks,@CAB_DutyPerson,@CAB_Brokerage,@CAB_State,@CAB_Del,@CAB_CTime,@CAB_Creator,@CAB_MTime,@CAB_Mender,@CAB_CheckNo)");
            SqlParameter[] parameters = {
 new SqlParameter("@CAB_ID", SqlDbType.VarChar,50),
 new SqlParameter("@CAB_Code", SqlDbType.VarChar,50),
 new SqlParameter("@CAB_SuppNo", SqlDbType.VarChar,50),
 new SqlParameter("@CAB_Stime", SqlDbType.DateTime,8),
 new SqlParameter("@CAB_FpCode", SqlDbType.VarChar,500),
 new SqlParameter("@CAB_BillType", SqlDbType.VarChar,50),
 new SqlParameter("@CAB_PayMent", SqlDbType.VarChar,50),
 new SqlParameter("@CAB_Money", SqlDbType.Decimal,9),
 new SqlParameter("@CAB_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@CAB_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@CAB_Brokerage", SqlDbType.VarChar,50),
 new SqlParameter("@CAB_State", SqlDbType.Int,4),
 new SqlParameter("@CAB_Del", SqlDbType.Int,4),
 new SqlParameter("@CAB_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@CAB_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@CAB_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@CAB_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@CAB_CheckNo", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CAB_ID;
            parameters[1].Value = model.CAB_Code;
            parameters[2].Value = model.CAB_SuppNo;
            parameters[3].Value = model.CAB_Stime;
            parameters[4].Value = model.CAB_FpCode;
            parameters[5].Value = model.CAB_BillType;
            parameters[6].Value = model.CAB_PayMent;
            parameters[7].Value = model.CAB_Money;
            parameters[8].Value = model.CAB_Remarks;
            parameters[9].Value = model.CAB_DutyPerson;
            parameters[10].Value = model.CAB_Brokerage;
            parameters[11].Value = model.CAB_State;
            parameters[12].Value = model.CAB_Del;
            parameters[13].Value = model.CAB_CTime;
            parameters[14].Value = model.CAB_Creator;
            parameters[15].Value = model.CAB_MTime;
            parameters[16].Value = model.CAB_Mender;
            parameters[17].Value = model.CAB_CheckNo;
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
        public bool Update(KNet.Model.CG_Account_Bill model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update CG_Account_Bill set ");
            strSql.Append("CAB_Code=@CAB_Code,");
            strSql.Append("CAB_SuppNo=@CAB_SuppNo,");
            strSql.Append("CAB_Stime=@CAB_Stime,");
            strSql.Append("CAB_FpCode=@CAB_FpCode,");
            strSql.Append("CAB_BillType=@CAB_BillType,");
            strSql.Append("CAB_PayMent=@CAB_PayMent,");
            strSql.Append("CAB_Money=@CAB_Money,");
            strSql.Append("CAB_Remarks=@CAB_Remarks,");
            strSql.Append("CAB_DutyPerson=@CAB_DutyPerson,");
            strSql.Append("CAB_Brokerage=@CAB_Brokerage,");
            strSql.Append("CAB_State=@CAB_State,");
            strSql.Append("CAB_Del=@CAB_Del,");
            strSql.Append("CAB_MTime=@CAB_MTime,");
            strSql.Append("CAB_Mender=@CAB_Mender");
            strSql.Append(" where CAB_ID=@CAB_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@CAB_Code", SqlDbType.VarChar,50),
 new SqlParameter("@CAB_SuppNo", SqlDbType.VarChar,50),
 new SqlParameter("@CAB_Stime", SqlDbType.DateTime,8),
 new SqlParameter("@CAB_FpCode", SqlDbType.VarChar,500),
 new SqlParameter("@CAB_BillType", SqlDbType.VarChar,50),
 new SqlParameter("@CAB_PayMent", SqlDbType.VarChar,50),
 new SqlParameter("@CAB_Money", SqlDbType.Decimal,9),
 new SqlParameter("@CAB_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@CAB_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@CAB_Brokerage", SqlDbType.VarChar,50),
 new SqlParameter("@CAB_State", SqlDbType.Int,4),
 new SqlParameter("@CAB_Del", SqlDbType.Int,4),
 new SqlParameter("@CAB_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@CAB_Mender", SqlDbType.VarChar,50),
new SqlParameter("@CAB_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CAB_Code;
            parameters[1].Value = model.CAB_SuppNo;
            parameters[2].Value = model.CAB_Stime;
            parameters[3].Value = model.CAB_FpCode;
            parameters[4].Value = model.CAB_BillType;
            parameters[5].Value = model.CAB_PayMent;
            parameters[6].Value = model.CAB_Money;
            parameters[7].Value = model.CAB_Remarks;
            parameters[8].Value = model.CAB_DutyPerson;
            parameters[9].Value = model.CAB_Brokerage;
            parameters[10].Value = model.CAB_State;
            parameters[11].Value = model.CAB_Del;
            parameters[12].Value = model.CAB_MTime;
            parameters[13].Value = model.CAB_Mender;
            parameters[14].Value = model.CAB_ID;

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
        public bool Delete(string s_CAB_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  CG_Account_Bill  ");
            strSql.Append(" where CAB_ID=@CAB_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@CAB_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = s_CAB_ID;
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
        public bool UpdateDel(KNet.Model.CG_Account_Bill model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update   CG_Account_Bill  Set ");
            strSql.Append("  CAB_Del=@CAB_Del ");
            strSql.Append(" where CAB_ID=@CAB_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@CAB_Del", SqlDbType.Int,4),
new SqlParameter("@CAB_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CAB_Del;
            parameters[1].Value = model.CAB_ID;

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
        public bool DeleteList(string s_CAB_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From   CG_Account_Bill  ");
            strSql.Append(" where CAB_ID in ('" + s_CAB_ID + "')");

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
        /// DeleteByFID
        /// </summary>
        public bool DeleteByFID(string s_FID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  CG_Account_Bill  ");
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
        public KNet.Model.CG_Account_Bill GetModel(string CAB_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from CG_Account_Bill  ");
            strSql.Append("where CAB_ID=@CAB_ID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@CAB_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = CAB_ID;
            KNet.Model.CG_Account_Bill model = new KNet.Model.CG_Account_Bill();
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
        public KNet.Model.CG_Account_Bill DataRowToModel(DataRow row)
        {
            KNet.Model.CG_Account_Bill model = new KNet.Model.CG_Account_Bill();
            if (row != null)
            {
                if (row["CAB_ID"] != null)
                {
                    model.CAB_ID = row["CAB_ID"].ToString();
                }
                else
                {
                    model.CAB_ID = "";
                }
                if (row["CAB_Code"] != null)
                {
                    model.CAB_Code = row["CAB_Code"].ToString();
                }
                else
                {
                    model.CAB_Code = "";
                }
                if (row["CAB_SuppNo"] != null)
                {
                    model.CAB_SuppNo = row["CAB_SuppNo"].ToString();
                }
                else
                {
                    model.CAB_SuppNo = "";
                }
                if (row["CAB_Stime"] != null)
                {
                    model.CAB_Stime = DateTime.Parse(row["CAB_Stime"].ToString());
                }
                if (row["CAB_FpCode"] != null)
                {
                    model.CAB_FpCode = row["CAB_FpCode"].ToString();
                }
                else
                {
                    model.CAB_FpCode = "";
                }
                if (row["CAB_BillType"] != null)
                {
                    model.CAB_BillType = row["CAB_BillType"].ToString();
                }
                else
                {
                    model.CAB_BillType = "";
                }
                if (row["CAB_PayMent"] != null)
                {
                    model.CAB_PayMent = row["CAB_PayMent"].ToString();
                }
                else
                {
                    model.CAB_PayMent = "";
                }
                if (row["CAB_Money"] != null)
                {
                    model.CAB_Money = Decimal.Parse(row["CAB_Money"].ToString());
                }
                else
                {
                    model.CAB_Money = 0;
                }
                if (row["CAB_Remarks"] != null)
                {
                    model.CAB_Remarks = row["CAB_Remarks"].ToString();
                }
                else
                {
                    model.CAB_Remarks = "";
                }
                if (row["CAB_DutyPerson"] != null)
                {
                    model.CAB_DutyPerson = row["CAB_DutyPerson"].ToString();
                }
                else
                {
                    model.CAB_DutyPerson = "";
                }
                if (row["CAB_Brokerage"] != null)
                {
                    model.CAB_Brokerage = row["CAB_Brokerage"].ToString();
                }
                else
                {
                    model.CAB_Brokerage = "";
                }
                if (row["CAB_State"] != null)
                {
                    model.CAB_State = int.Parse(row["CAB_State"].ToString());
                }
                else
                {
                    model.CAB_State = 0;
                }
                if (row["CAB_Del"] != null)
                {
                    model.CAB_Del = int.Parse(row["CAB_Del"].ToString());
                }
                else
                {
                    model.CAB_Del = 0;
                }
                if (row["CAB_CTime"] != null)
                {
                    model.CAB_CTime = DateTime.Parse(row["CAB_CTime"].ToString());
                }
                if (row["CAB_Creator"] != null)
                {
                    model.CAB_Creator = row["CAB_Creator"].ToString();
                }
                else
                {
                    model.CAB_Creator = "";
                }
                if (row["CAB_MTime"] != null)
                {
                    model.CAB_MTime = DateTime.Parse(row["CAB_MTime"].ToString());
                }
                if (row["CAB_Mender"] != null)
                {
                    model.CAB_Mender = row["CAB_Mender"].ToString();
                }
                else
                {
                    model.CAB_Mender = "";
                }

                if (row["CAB_CheckNo"] != null)
                {
                    model.CAB_CheckNo = row["CAB_CheckNo"].ToString();
                }
                else
                {
                    model.CAB_CheckNo = "";
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
            strSql.Append(" FROM CG_Account_Bill ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

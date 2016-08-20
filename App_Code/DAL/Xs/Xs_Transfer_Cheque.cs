using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Xs_Transfer_Cheque
    /// </summary>
    public partial class Xs_Transfer_Cheque
    {
        public Xs_Transfer_Cheque()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XTC_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Xs_Transfer_Cheque");
            strSql.Append(" where XTC_ID=@XTC_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XTC_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XTC_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.Xs_Transfer_Cheque model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Xs_Transfer_Cheque(");
            strSql.Append("XTC_ID,XTC_Stime,XTC_Type,XTC_PayeeValue,XTC_PayeeName,XTC_UseName,XTC_Money,XTC_ChineseMoney,XTC_Account,XTC_Remarks,XTC_DutyPerson,XTC_ShPerson,XTC_Del,XTC_CTime,XTC_Creator,XTC_MTime,XTC_Mender,XTC_BankName,XTC_BankAccount,XTC_BillType,XTC_BillNumber,XTC_Shen,XTC_Shi)");
            strSql.Append(" values (");
            strSql.Append("@XTC_ID,@XTC_Stime,@XTC_Type,@XTC_PayeeValue,@XTC_PayeeName,@XTC_UseName,@XTC_Money,@XTC_ChineseMoney,@XTC_Account,@XTC_Remarks,@XTC_DutyPerson,@XTC_ShPerson,@XTC_Del,@XTC_CTime,@XTC_Creator,@XTC_MTime,@XTC_Mender,@XTC_BankName,@XTC_BankAccount,@XTC_BillType,@XTC_BillNumber,@XTC_Shen,@XTC_Shi)");
            SqlParameter[] parameters = {
					new SqlParameter("@XTC_ID", SqlDbType.VarChar,50),
					new SqlParameter("@XTC_Stime", SqlDbType.DateTime),
					new SqlParameter("@XTC_Type", SqlDbType.VarChar,50),
					new SqlParameter("@XTC_PayeeValue", SqlDbType.VarChar,50),
					new SqlParameter("@XTC_PayeeName", SqlDbType.VarChar,350),
					new SqlParameter("@XTC_UseName", SqlDbType.VarChar,350),
					new SqlParameter("@XTC_Money", SqlDbType.Decimal,9),
					new SqlParameter("@XTC_ChineseMoney", SqlDbType.VarChar,350),
					new SqlParameter("@XTC_Account", SqlDbType.VarChar,350),
					new SqlParameter("@XTC_Remarks", SqlDbType.VarChar,100),
					new SqlParameter("@XTC_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@XTC_ShPerson", SqlDbType.VarChar,50),
					new SqlParameter("@XTC_Del", SqlDbType.Int,4),
					new SqlParameter("@XTC_CTime", SqlDbType.DateTime),
					new SqlParameter("@XTC_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@XTC_MTime", SqlDbType.DateTime),
					new SqlParameter("@XTC_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@XTC_BankName", SqlDbType.VarChar,350),
					new SqlParameter("@XTC_BankAccount", SqlDbType.VarChar,350),
					new SqlParameter("@XTC_BillType", SqlDbType.VarChar,100),
					new SqlParameter("@XTC_BillNumber", SqlDbType.VarChar,100),
					new SqlParameter("@XTC_Shen", SqlDbType.VarChar,100),
					new SqlParameter("@XTC_Shi", SqlDbType.VarChar,100)};
            parameters[0].Value = model.XTC_ID;
            parameters[1].Value = model.XTC_Stime;
            parameters[2].Value = model.XTC_Type;
            parameters[3].Value = model.XTC_PayeeValue;
            parameters[4].Value = model.XTC_PayeeName;
            parameters[5].Value = model.XTC_UseName;
            parameters[6].Value = model.XTC_Money;
            parameters[7].Value = model.XTC_ChineseMoney;
            parameters[8].Value = model.XTC_Account;
            parameters[9].Value = model.XTC_Remarks;
            parameters[10].Value = model.XTC_DutyPerson;
            parameters[11].Value = model.XTC_ShPerson;
            parameters[12].Value = model.XTC_Del;
            parameters[13].Value = model.XTC_CTime;
            parameters[14].Value = model.XTC_Creator;
            parameters[15].Value = model.XTC_MTime;
            parameters[16].Value = model.XTC_Mender;
            parameters[17].Value = model.XTC_BankName;
            parameters[18].Value = model.XTC_BankAccount;
            parameters[19].Value = model.XTC_BillType;
            parameters[20].Value = model.XTC_BillNumber;
            parameters[21].Value = model.XTC_Shen;
            parameters[22].Value = model.XTC_Shi;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Transfer_Cheque model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Xs_Transfer_Cheque set ");
            strSql.Append("XTC_Stime=@XTC_Stime,");
            strSql.Append("XTC_Type=@XTC_Type,");
            strSql.Append("XTC_PayeeValue=@XTC_PayeeValue,");
            strSql.Append("XTC_PayeeName=@XTC_PayeeName,");
            strSql.Append("XTC_UseName=@XTC_UseName,");
            strSql.Append("XTC_Money=@XTC_Money,");
            strSql.Append("XTC_ChineseMoney=@XTC_ChineseMoney,");
            strSql.Append("XTC_Account=@XTC_Account,");
            strSql.Append("XTC_Remarks=@XTC_Remarks,");
            strSql.Append("XTC_DutyPerson=@XTC_DutyPerson,");
            strSql.Append("XTC_ShPerson=@XTC_ShPerson,");
            strSql.Append("XTC_MTime=@XTC_MTime,");
            strSql.Append("XTC_Mender=@XTC_Mender,");
            strSql.Append("XTC_BankName=@XTC_BankName,");
            strSql.Append("XTC_BankAccount=@XTC_BankAccount,");
            strSql.Append("XTC_BillType=@XTC_BillType,");
            strSql.Append("XTC_BillNumber=@XTC_BillNumber,");
            strSql.Append("XTC_Shen=@XTC_Shen,");
            strSql.Append("XTC_Shi=@XTC_Shi");
            strSql.Append(" where XTC_ID=@XTC_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XTC_Stime", SqlDbType.DateTime),
					new SqlParameter("@XTC_Type", SqlDbType.VarChar,50),
					new SqlParameter("@XTC_PayeeValue", SqlDbType.VarChar,50),
					new SqlParameter("@XTC_PayeeName", SqlDbType.VarChar,50),
					new SqlParameter("@XTC_UseName", SqlDbType.VarChar,50),
					new SqlParameter("@XTC_Money", SqlDbType.Decimal,9),
					new SqlParameter("@XTC_ChineseMoney", SqlDbType.VarChar,350),
					new SqlParameter("@XTC_Account", SqlDbType.VarChar,350),
					new SqlParameter("@XTC_Remarks", SqlDbType.VarChar,100),
					new SqlParameter("@XTC_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@XTC_ShPerson", SqlDbType.VarChar,50),
					new SqlParameter("@XTC_MTime", SqlDbType.DateTime),
					new SqlParameter("@XTC_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@XTC_BankName", SqlDbType.VarChar,350),
					new SqlParameter("@XTC_BankAccount", SqlDbType.VarChar,350),
					new SqlParameter("@XTC_BillType", SqlDbType.VarChar,100),
					new SqlParameter("@XTC_BillNumber", SqlDbType.VarChar,100),
					new SqlParameter("@XTC_Shen", SqlDbType.VarChar,100),
					new SqlParameter("@XTC_Shi", SqlDbType.VarChar,100),
					new SqlParameter("@XTC_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.XTC_Stime;
            parameters[1].Value = model.XTC_Type;
            parameters[2].Value = model.XTC_PayeeValue;
            parameters[3].Value = model.XTC_PayeeName;
            parameters[4].Value = model.XTC_UseName;
            parameters[5].Value = model.XTC_Money;
            parameters[6].Value = model.XTC_ChineseMoney;
            parameters[7].Value = model.XTC_Account;
            parameters[8].Value = model.XTC_Remarks;
            parameters[9].Value = model.XTC_DutyPerson;
            parameters[10].Value = model.XTC_ShPerson;
            parameters[11].Value = model.XTC_MTime;
            parameters[12].Value = model.XTC_Mender;
            parameters[13].Value = model.XTC_BankName;
            parameters[14].Value = model.XTC_BankAccount;
            parameters[15].Value = model.XTC_BillType;
            parameters[16].Value = model.XTC_BillNumber;
            parameters[17].Value = model.XTC_Shen;
            parameters[18].Value = model.XTC_Shi;
            parameters[19].Value = model.XTC_ID;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string XTC_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Transfer_Cheque ");
            strSql.Append(" where XTC_ID=@XTC_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XTC_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XTC_ID;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string XTC_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Transfer_Cheque ");
            strSql.Append(" where XTC_ID in (" + XTC_IDlist + ")  ");
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
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Xs_Transfer_Cheque GetModel(string XTC_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Xs_Transfer_Cheque ");
            strSql.Append(" where XTC_ID=@XTC_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XTC_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XTC_ID;

            KNet.Model.Xs_Transfer_Cheque model = new KNet.Model.Xs_Transfer_Cheque();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["XTC_ID"] != null && ds.Tables[0].Rows[0]["XTC_ID"].ToString() != "")
                {
                    model.XTC_ID = ds.Tables[0].Rows[0]["XTC_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XTC_Stime"] != null && ds.Tables[0].Rows[0]["XTC_Stime"].ToString() != "")
                {
                    model.XTC_Stime = DateTime.Parse(ds.Tables[0].Rows[0]["XTC_Stime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XTC_Type"] != null && ds.Tables[0].Rows[0]["XTC_Type"].ToString() != "")
                {
                    model.XTC_Type = ds.Tables[0].Rows[0]["XTC_Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XTC_PayeeValue"] != null && ds.Tables[0].Rows[0]["XTC_PayeeValue"].ToString() != "")
                {
                    model.XTC_PayeeValue = ds.Tables[0].Rows[0]["XTC_PayeeValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XTC_PayeeName"] != null && ds.Tables[0].Rows[0]["XTC_PayeeName"].ToString() != "")
                {
                    model.XTC_PayeeName = ds.Tables[0].Rows[0]["XTC_PayeeName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XTC_UseName"] != null && ds.Tables[0].Rows[0]["XTC_UseName"].ToString() != "")
                {
                    model.XTC_UseName = ds.Tables[0].Rows[0]["XTC_UseName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XTC_Money"] != null && ds.Tables[0].Rows[0]["XTC_Money"].ToString() != "")
                {
                    model.XTC_Money = decimal.Parse(ds.Tables[0].Rows[0]["XTC_Money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XTC_Account"] != null && ds.Tables[0].Rows[0]["XTC_Account"].ToString() != "")
                {
                    model.XTC_Account = ds.Tables[0].Rows[0]["XTC_Account"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XTC_Remarks"] != null && ds.Tables[0].Rows[0]["XTC_Remarks"].ToString() != "")
                {
                    model.XTC_Remarks = ds.Tables[0].Rows[0]["XTC_Remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XTC_DutyPerson"] != null && ds.Tables[0].Rows[0]["XTC_DutyPerson"].ToString() != "")
                {
                    model.XTC_DutyPerson = ds.Tables[0].Rows[0]["XTC_DutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XTC_ShPerson"] != null && ds.Tables[0].Rows[0]["XTC_ShPerson"].ToString() != "")
                {
                    model.XTC_ShPerson = ds.Tables[0].Rows[0]["XTC_ShPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XTC_Del"] != null && ds.Tables[0].Rows[0]["XTC_Del"].ToString() != "")
                {
                    model.XTC_Del = int.Parse(ds.Tables[0].Rows[0]["XTC_Del"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XTC_CTime"] != null && ds.Tables[0].Rows[0]["XTC_CTime"].ToString() != "")
                {
                    model.XTC_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["XTC_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XTC_Creator"] != null && ds.Tables[0].Rows[0]["XTC_Creator"].ToString() != "")
                {
                    model.XTC_Creator = ds.Tables[0].Rows[0]["XTC_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XTC_MTime"] != null && ds.Tables[0].Rows[0]["XTC_MTime"].ToString() != "")
                {
                    model.XTC_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["XTC_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XTC_Mender"] != null && ds.Tables[0].Rows[0]["XTC_Mender"].ToString() != "")
                {
                    model.XTC_Mender = ds.Tables[0].Rows[0]["XTC_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XTC_ChineseMoney"] != null && ds.Tables[0].Rows[0]["XTC_ChineseMoney"].ToString() != "")
                {
                    model.XTC_ChineseMoney = ds.Tables[0].Rows[0]["XTC_ChineseMoney"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XTC_BankName"] != null && ds.Tables[0].Rows[0]["XTC_BankName"].ToString() != "")
                {
                    model.XTC_BankName = ds.Tables[0].Rows[0]["XTC_BankName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XTC_BankAccount"] != null && ds.Tables[0].Rows[0]["XTC_BankAccount"].ToString() != "")
                {
                    model.XTC_BankAccount = ds.Tables[0].Rows[0]["XTC_BankAccount"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XTC_BillType"] != null && ds.Tables[0].Rows[0]["XTC_BillType"].ToString() != "")
                {
                    model.XTC_BillType = ds.Tables[0].Rows[0]["XTC_BillType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XTC_BillNumber"] != null && ds.Tables[0].Rows[0]["XTC_BillNumber"].ToString() != "")
                {
                    model.XTC_BillNumber = ds.Tables[0].Rows[0]["XTC_BillNumber"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XTC_Shen"] != null && ds.Tables[0].Rows[0]["XTC_Shen"].ToString() != "")
                {
                    model.XTC_Shen = ds.Tables[0].Rows[0]["XTC_Shen"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XTC_Shi"] != null && ds.Tables[0].Rows[0]["XTC_Shi"].ToString() != "")
                {
                    model.XTC_Shi = ds.Tables[0].Rows[0]["XTC_Shi"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Xs_Transfer_Cheque ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM Xs_Transfer_Cheque ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  Method
    }
}


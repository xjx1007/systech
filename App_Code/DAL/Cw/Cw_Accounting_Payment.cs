using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Cw_Accounting_Payment
    /// </summary>
    public partial class Cw_Accounting_Payment
    {
        public Cw_Accounting_Payment()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CAP_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cw_Accounting_Payment");
            strSql.Append(" where CAP_ID=@CAP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAP_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cw_Accounting_Payment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cw_Accounting_Payment(");
            strSql.Append("CAP_ID,CAP_FID,CAP_Code,CAP_Title,CAP_STime,CAP_DutyPerson,CAP_CustomerValue,CAP_Type,CAP_State,CAP_ReceiveMoney,CAP_Bank,CAP_IsFP,CAP_Details,CAP_Del,CAP_Creator,CAP_CTime,CAP_Mender,CAP_MTime,CAP_IsPay,CAP_FpType,CAP_Order,CAP_KCustomerValue,CAP_Payment)");
            strSql.Append(" values (");
            strSql.Append("@CAP_ID,@CAP_FID,@CAP_Code,@CAP_Title,@CAP_STime,@CAP_DutyPerson,@CAP_CustomerValue,@CAP_Type,@CAP_State,@CAP_ReceiveMoney,@CAP_Bank,@CAP_IsFP,@CAP_Details,@CAP_Del,@CAP_Creator,@CAP_CTime,@CAP_Mender,@CAP_MTime,@CAP_IsPay,@CAP_FpType,@CAP_Order,@CAP_KCustomerValue,@CAP_Payment)");
            SqlParameter[] parameters = {
					new SqlParameter("@CAP_ID", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_FID", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_Code", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_Title", SqlDbType.VarChar,150),
					new SqlParameter("@CAP_STime", SqlDbType.DateTime),
					new SqlParameter("@CAP_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_Type", SqlDbType.Int,4),
					new SqlParameter("@CAP_State", SqlDbType.Int,4),
					new SqlParameter("@CAP_ReceiveMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CAP_Bank", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_IsFP", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_Details", SqlDbType.VarChar,200),
					new SqlParameter("@CAP_Del", SqlDbType.Int,4),
					new SqlParameter("@CAP_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_CTime", SqlDbType.DateTime),
					new SqlParameter("@CAP_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_MTime", SqlDbType.DateTime),
					new SqlParameter("@CAP_IsPay", SqlDbType.Int,4),
					new SqlParameter("@CAP_FpType", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_Order", SqlDbType.Int,4),
					new SqlParameter("@CAP_KCustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_Payment", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = model.CAP_ID;
            parameters[1].Value = model.CAP_FID;
            parameters[2].Value = model.CAP_Code;
            parameters[3].Value = model.CAP_Title;
            parameters[4].Value = model.CAP_STime;
            parameters[5].Value = model.CAP_DutyPerson;
            parameters[6].Value = model.CAP_CustomerValue;
            parameters[7].Value = model.CAP_Type;
            parameters[8].Value = model.CAP_State;
            parameters[9].Value = model.CAP_ReceiveMoney;
            parameters[10].Value = model.CAP_Bank;
            parameters[11].Value = model.CAP_IsFP;
            parameters[12].Value = model.CAP_Details;
            parameters[13].Value = model.CAP_Del;
            parameters[14].Value = model.CAP_Creator;
            parameters[15].Value = model.CAP_CTime;
            parameters[16].Value = model.CAP_Mender;
            parameters[17].Value = model.CAP_MTime;
            parameters[18].Value = model.CAP_IsPay;
            parameters[19].Value = model.CAP_FpType;
            parameters[20].Value = model.CAP_Order;
            parameters[21].Value = model.CAP_KCustomerValue;
            parameters[22].Value = model.CAP_Payment;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cw_Accounting_Payment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cw_Accounting_Payment set ");
            strSql.Append("CAP_FID=@CAP_FID,");
            strSql.Append("CAP_Code=@CAP_Code,");
            strSql.Append("CAP_Title=@CAP_Title,");
            strSql.Append("CAP_STime=@CAP_STime,");
            strSql.Append("CAP_DutyPerson=@CAP_DutyPerson,");
            strSql.Append("CAP_CustomerValue=@CAP_CustomerValue,");
            strSql.Append("CAP_Type=@CAP_Type,");
            strSql.Append("CAP_State=@CAP_State,");
            strSql.Append("CAP_ReceiveMoney=@CAP_ReceiveMoney,");
            strSql.Append("CAP_Bank=@CAP_Bank,");
            strSql.Append("CAP_IsFP=@CAP_IsFP,");
            strSql.Append("CAP_Details=@CAP_Details,");
            strSql.Append("CAP_Del=@CAP_Del,");
            strSql.Append("CAP_FpType=@CAP_FpType,");
            strSql.Append("CAP_Order=@CAP_Order,");
            strSql.Append("CAP_Mender=@CAP_Mender,");
            strSql.Append("CAP_MTime=@CAP_MTime,");
            strSql.Append("CAP_KCustomerValue=@CAP_KCustomerValue,");
            strSql.Append("CAP_Payment=@CAP_Payment");
            
            strSql.Append(" where CAP_ID=@CAP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAP_FID", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_Code", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_Title", SqlDbType.VarChar,150),
					new SqlParameter("@CAP_STime", SqlDbType.DateTime),
					new SqlParameter("@CAP_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_Type", SqlDbType.Int,4),
					new SqlParameter("@CAP_State", SqlDbType.Int,4),
					new SqlParameter("@CAP_ReceiveMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CAP_Bank", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_IsFP", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_Details", SqlDbType.VarChar,200),
					new SqlParameter("@CAP_Del", SqlDbType.Int,4),
					new SqlParameter("@CAP_FpType", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_Order", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_MTime", SqlDbType.DateTime),
					new SqlParameter("@CAP_KCustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_Payment", SqlDbType.VarChar,50),
					new SqlParameter("@CAP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CAP_FID;
            parameters[1].Value = model.CAP_Code;
            parameters[2].Value = model.CAP_Title;
            parameters[3].Value = model.CAP_STime;
            parameters[4].Value = model.CAP_DutyPerson;
            parameters[5].Value = model.CAP_CustomerValue;
            parameters[6].Value = model.CAP_Type;
            parameters[7].Value = model.CAP_State;
            parameters[8].Value = model.CAP_ReceiveMoney;
            parameters[9].Value = model.CAP_Bank;
            parameters[10].Value = model.CAP_IsFP;
            parameters[11].Value = model.CAP_Details;
            parameters[12].Value = model.CAP_Del;
            parameters[13].Value = model.CAP_FpType;
            parameters[14].Value = model.CAP_Order;
            parameters[15].Value = model.CAP_Mender;
            parameters[16].Value = model.CAP_MTime;
            parameters[17].Value = model.CAP_KCustomerValue;
            parameters[18].Value = model.CAP_Payment;
            
            parameters[19].Value = model.CAP_ID;

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
        public bool Delete(string CAP_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cw_Accounting_Payment ");
            strSql.Append(" where CAP_ID=@CAP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAP_ID;

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
        public bool DeleteList(string CAP_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cw_Accounting_Payment ");
            strSql.Append(" where CAP_ID in (" + CAP_IDlist + ")  ");
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
        public KNet.Model.Cw_Accounting_Payment GetModel(string CAP_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 a.*,b.CAP_PayMoney,a.CAP_ReceiveMoney-b.CAP_PayMoney as leftMoney,b.CAP_PayState,c.leftMoney as CAP_KpLeftMoney,c.*  from Cw_Accounting_Payment a join v_Pay_Sum b on b.CAP_ID=a.CAP_ID join Cw_Payment_BillSum_Total c on c.v_ID=a.CAP_ID ");
            strSql.Append(" where a.CAP_ID=@CAP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAP_ID;

            KNet.Model.Cw_Accounting_Payment model = new KNet.Model.Cw_Accounting_Payment();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CAP_ID"] != null && ds.Tables[0].Rows[0]["CAP_ID"].ToString() != "")
                {
                    model.CAP_ID = ds.Tables[0].Rows[0]["CAP_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAP_FID"] != null && ds.Tables[0].Rows[0]["CAP_FID"].ToString() != "")
                {
                    model.CAP_FID = ds.Tables[0].Rows[0]["CAP_FID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAP_Code"] != null && ds.Tables[0].Rows[0]["CAP_Code"].ToString() != "")
                {
                    model.CAP_Code = ds.Tables[0].Rows[0]["CAP_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAP_Title"] != null && ds.Tables[0].Rows[0]["CAP_Title"].ToString() != "")
                {
                    model.CAP_Title = ds.Tables[0].Rows[0]["CAP_Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAP_STime"] != null && ds.Tables[0].Rows[0]["CAP_STime"].ToString() != "")
                {
                    model.CAP_STime = DateTime.Parse(ds.Tables[0].Rows[0]["CAP_STime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAP_DutyPerson"] != null && ds.Tables[0].Rows[0]["CAP_DutyPerson"].ToString() != "")
                {
                    model.CAP_DutyPerson = ds.Tables[0].Rows[0]["CAP_DutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAP_CustomerValue"] != null && ds.Tables[0].Rows[0]["CAP_CustomerValue"].ToString() != "")
                {
                    model.CAP_CustomerValue = ds.Tables[0].Rows[0]["CAP_CustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAP_Type"] != null && ds.Tables[0].Rows[0]["CAP_Type"].ToString() != "")
                {
                    model.CAP_Type = int.Parse(ds.Tables[0].Rows[0]["CAP_Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAP_State"] != null && ds.Tables[0].Rows[0]["CAP_State"].ToString() != "")
                {
                    model.CAP_State = int.Parse(ds.Tables[0].Rows[0]["CAP_State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAP_ReceiveMoney"] != null && ds.Tables[0].Rows[0]["CAP_ReceiveMoney"].ToString() != "")
                {
                    model.CAP_ReceiveMoney = decimal.Parse(ds.Tables[0].Rows[0]["CAP_ReceiveMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAP_Bank"] != null && ds.Tables[0].Rows[0]["CAP_Bank"].ToString() != "")
                {
                    model.CAP_Bank = ds.Tables[0].Rows[0]["CAP_Bank"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAP_IsFP"] != null && ds.Tables[0].Rows[0]["CAP_IsFP"].ToString() != "")
                {
                    model.CAP_IsFP = ds.Tables[0].Rows[0]["CAP_IsFP"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAP_Details"] != null && ds.Tables[0].Rows[0]["CAP_Details"].ToString() != "")
                {
                    model.CAP_Details = ds.Tables[0].Rows[0]["CAP_Details"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAP_Del"] != null && ds.Tables[0].Rows[0]["CAP_Del"].ToString() != "")
                {
                    model.CAP_Del = int.Parse(ds.Tables[0].Rows[0]["CAP_Del"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAP_Creator"] != null && ds.Tables[0].Rows[0]["CAP_Creator"].ToString() != "")
                {
                    model.CAP_Creator = ds.Tables[0].Rows[0]["CAP_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAP_CTime"] != null && ds.Tables[0].Rows[0]["CAP_CTime"].ToString() != "")
                {
                    model.CAP_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["CAP_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAP_Mender"] != null && ds.Tables[0].Rows[0]["CAP_Mender"].ToString() != "")
                {
                    model.CAP_Mender = ds.Tables[0].Rows[0]["CAP_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAP_MTime"] != null && ds.Tables[0].Rows[0]["CAP_MTime"].ToString() != "")
                {
                    model.CAP_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["CAP_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAP_PayMoney"] != null && ds.Tables[0].Rows[0]["CAP_PayMoney"].ToString() != "")
                {
                    model.cap_Paymoney = decimal.Parse(ds.Tables[0].Rows[0]["CAP_PayMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAP_MTime"] != null && ds.Tables[0].Rows[0]["CAP_PayMoney"].ToString() != "")
                {
                    model.cap_Leftmoney = decimal.Parse(ds.Tables[0].Rows[0]["LeftMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAP_IsPay"] != null && ds.Tables[0].Rows[0]["CAP_IsPay"].ToString() != "")
                {
                    model.CAP_IsPay = int.Parse(ds.Tables[0].Rows[0]["CAP_IsPay"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAP_FpType"] != null && ds.Tables[0].Rows[0]["CAP_FpType"].ToString() != "")
                {
                    model.CAP_FpType = ds.Tables[0].Rows[0]["CAP_FpType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAP_Order"] != null && ds.Tables[0].Rows[0]["CAP_Order"].ToString() != "")
                {
                    model.CAP_Order = int.Parse(ds.Tables[0].Rows[0]["CAP_Order"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAP_PayState"] != null && ds.Tables[0].Rows[0]["CAP_PayState"].ToString() != "")
                {
                    model.CAP_SKState = int.Parse(ds.Tables[0].Rows[0]["CAP_PayState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["v_State"] != null && ds.Tables[0].Rows[0]["v_State"].ToString() != "")
                {
                    model.CAP_KpState = int.Parse(ds.Tables[0].Rows[0]["v_State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAP_KpLeftMoney"] != null && ds.Tables[0].Rows[0]["CAP_KpLeftMoney"].ToString() != "")
                {
                    model.cap_wKpmoney = decimal.Parse(ds.Tables[0].Rows[0]["CAP_KpLeftMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAP_KCustomerValue"] != null && ds.Tables[0].Rows[0]["CAP_KCustomerValue"].ToString() != "")
                {
                    model.CAP_KCustomerValue = ds.Tables[0].Rows[0]["CAP_KCustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAP_CheckYN"] != null && ds.Tables[0].Rows[0]["CAP_CheckYN"].ToString() != "")
                {
                    model.CAP_CheckYN = int.Parse(ds.Tables[0].Rows[0]["CAP_CheckYN"].ToString());
                }
                else
                {
                    model.CAP_CheckYN = 0;
                }
                if (ds.Tables[0].Rows[0]["CAP_Payment"] != null && ds.Tables[0].Rows[0]["CAP_Payment"].ToString() != "")
                {
                    model.CAP_Payment = ds.Tables[0].Rows[0]["CAP_Payment"].ToString();
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
            strSql.Append("select a.*,b.CAP_PayMoney,b.CAP_leftMoney,b.CAP_PayState,c.v_State,c.v_HaveMoney ");
            strSql.Append(" FROM Cw_Accounting_Payment a left join v_Pay_Sum b on b.CAP_ID=a.CAP_ID left join Cw_Payment_BillSum_Total c on c.v_ID=a.CAP_ID ");
     
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
            strSql.Append(" CAP_ID,CAP_FID,CAP_Code,CAP_Title,CAP_STime,CAP_DutyPerson,CAP_CustomerValue,CAP_Type,CAP_State,CAP_ReceiveMoney,CAP_Bank,CAP_IsFP,CAP_Details,CAP_Del,CAP_Creator,CAP_CTime,CAP_Mender,CAP_MTime ");
            strSql.Append(" FROM Cw_Accounting_Payment ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Cw_Accounting_Payment";
            parameters[1].Value = "CAP_ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Cw_Accounting_Pay
    /// </summary>
    public partial class Cw_Accounting_Pay
    {
        public Cw_Accounting_Pay()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CAA_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cw_Accounting_Pay");
            strSql.Append(" where CAA_ID=@CAA_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAA_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAA_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cw_Accounting_Pay model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cw_Accounting_Pay(");
            strSql.Append("CAA_ID,CAA_DutyPerson,CAA_CustomerValue,CAA_Account,CAA_PayTime,CAA_PayMoney,CAA_Details,CAA_CTime,CAA_Creator,CAA_MTime,CAA_Mender,CAA_Code,CAA_Type,CAA_FID,CAA_StartDateTime,CAA_EndDateTime,CAA_BillCode,CAP_Type,CAP_YFBillCode,CAP_YFOutDate,CAA_leftMoney,CAA_FCAAID)");
            strSql.Append(" values (");
            strSql.Append("'" + model.CAA_ID + "',@CAA_DutyPerson,@CAA_CustomerValue,@CAA_Account,@CAA_PayTime,@CAA_PayMoney,@CAA_Details,@CAA_CTime,@CAA_Creator,@CAA_MTime,@CAA_Mender,@CAA_Code,@CAA_Type,@CAA_FID,@CAA_StartDateTime,@CAA_EndDateTime,@CAA_BillCode,@CAP_Type,@CAP_YFBillCode,@CAP_YFOutDate,@CAA_leftMoney,@CAA_FCAAID)");
            SqlParameter[] parameters = {
					new SqlParameter("@CAA_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@CAA_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@CAA_Account", SqlDbType.VarChar,50),
					new SqlParameter("@CAA_PayTime", SqlDbType.DateTime),
					new SqlParameter("@CAA_PayMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CAA_Details", SqlDbType.VarChar,500),
					new SqlParameter("@CAA_CTime", SqlDbType.DateTime),
					new SqlParameter("@CAA_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@CAA_MTime", SqlDbType.DateTime),
					new SqlParameter("@CAA_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@CAA_Code", SqlDbType.VarChar,50),
					new SqlParameter("@CAA_Type", SqlDbType.Int,4),
					new SqlParameter("@CAA_FID", SqlDbType.VarChar,50),
					new SqlParameter("@CAA_StartDateTime", SqlDbType.DateTime),
					new SqlParameter("@CAA_EndDateTime", SqlDbType.DateTime),
					new SqlParameter("@CAA_BillCode", SqlDbType.VarChar,350),
					new SqlParameter("@CAP_Type", SqlDbType.Int,4),
					new SqlParameter("@CAP_YFBillCode", SqlDbType.VarChar,350),
					new SqlParameter("@CAP_YFOutDate", SqlDbType.DateTime),
					new SqlParameter("@CAA_leftMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CAA_FCAAID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CAA_DutyPerson;
            parameters[1].Value = model.CAA_CustomerValue;
            parameters[2].Value = model.CAA_Account;
            parameters[3].Value = model.CAA_PayTime;
            parameters[4].Value = model.CAA_PayMoney;
            parameters[5].Value = model.CAA_Details;
            parameters[6].Value = model.CAA_CTime;
            parameters[7].Value = model.CAA_Creator;
            parameters[8].Value = model.CAA_MTime;
            parameters[9].Value = model.CAA_Mender;
            parameters[10].Value = model.CAA_Code;
            parameters[11].Value = model.CAA_Type;
            parameters[12].Value = model.CAA_FID;
            parameters[13].Value = model.CAA_StartDateTime;
            parameters[14].Value = model.CAA_EndDateTime;
            parameters[15].Value = model.CAA_BillCode;
            parameters[16].Value = model.CAP_Type;
            parameters[17].Value = model.CAP_YFBillCode;
            parameters[18].Value = model.CAP_YFOutDate;

            parameters[19].Value = model.CAA_PayMoney;
            parameters[20].Value = model.CAA_FCAAID;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cw_Accounting_Pay model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cw_Accounting_Pay set ");
            strSql.Append("CAA_DutyPerson=@CAA_DutyPerson,");
            strSql.Append("CAA_CustomerValue=@CAA_CustomerValue,");
            strSql.Append("CAA_Account=@CAA_Account,");
            strSql.Append("CAA_PayTime=@CAA_PayTime,");
            strSql.Append("CAA_PayMoney=@CAA_PayMoney,");
            strSql.Append("CAA_Details=@CAA_Details,");
            strSql.Append("CAA_MTime=@CAA_MTime,");
            strSql.Append("CAA_Mender=@CAA_Mender,");
            strSql.Append("CAA_FID=@CAA_FID,");
            strSql.Append("CAA_Code=@CAA_Code,");
            strSql.Append("CAA_StartDateTime=@CAA_StartDateTime,");
            strSql.Append("CAA_EndDateTime=@CAA_EndDateTime,");
            strSql.Append("CAA_BillCode=@CAA_BillCode,");
            strSql.Append("CAP_YFBillCode=@CAP_YFBillCode,");
            strSql.Append("CAP_YFOutDate=@CAP_YFOutDate,");
            strSql.Append("CAA_DetailsTotalMoney=@CAA_DetailsTotalMoney,");
            strSql.Append("CAA_leftMoney=@CAA_leftMoney,");
            strSql.Append("CAP_Type=@CAP_Type,");
            strSql.Append("CAA_FCAAID=@CAA_FCAAID");
            
            strSql.Append(" where CAA_ID=@CAA_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAA_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@CAA_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@CAA_Account", SqlDbType.VarChar,50),
					new SqlParameter("@CAA_PayTime", SqlDbType.DateTime),
					new SqlParameter("@CAA_PayMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CAA_Details", SqlDbType.VarChar,500),
					new SqlParameter("@CAA_MTime", SqlDbType.DateTime),
					new SqlParameter("@CAA_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@CAA_FID", SqlDbType.VarChar,50),
					new SqlParameter("@CAA_Code", SqlDbType.VarChar,50),
					new SqlParameter("@CAA_StartDateTime", SqlDbType.DateTime),
					new SqlParameter("@CAA_EndDateTime", SqlDbType.DateTime),
					new SqlParameter("@CAA_BillCode", SqlDbType.VarChar,350),
					new SqlParameter("@CAP_YFBillCode", SqlDbType.VarChar,350),
					new SqlParameter("@CAP_YFOutDate", SqlDbType.DateTime),
					new SqlParameter("@CAA_DetailsTotalMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CAA_leftMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CAP_Type", SqlDbType.Int),
					new SqlParameter("@CAA_FCAAID", SqlDbType.VarChar,50),
                    
					new SqlParameter("@CAA_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CAA_DutyPerson;
            parameters[1].Value = model.CAA_CustomerValue;
            parameters[2].Value = model.CAA_Account;
            parameters[3].Value = model.CAA_PayTime;
            parameters[4].Value = model.CAA_PayMoney;
            parameters[5].Value = model.CAA_Details;
            parameters[6].Value = model.CAA_MTime;
            parameters[7].Value = model.CAA_Mender;
            parameters[8].Value = model.CAA_FID;
            parameters[9].Value = model.CAA_Code;
            parameters[10].Value = model.CAA_StartDateTime;
            parameters[11].Value = model.CAA_EndDateTime;
            parameters[12].Value = model.CAA_BillCode;
            parameters[13].Value = model.CAP_YFBillCode;
            parameters[14].Value = model.CAP_YFOutDate;


            parameters[15].Value = model.CAA_DetailsTotalMoney;
            parameters[16].Value = model.CAA_leftMoney;

            parameters[17].Value = model.CAP_Type;
            parameters[18].Value = model.CAA_FCAAID;
            
            parameters[19].Value = model.CAA_ID;

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
        public bool Delete(string CAA_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cw_Accounting_Pay ");
            strSql.Append(" where CAA_ID=@CAA_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAA_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAA_ID;

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
        public bool DeleteList(string CAA_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cw_Accounting_Pay ");
            strSql.Append(" where CAA_ID in (" + CAA_IDlist + ")  ");
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
        public KNet.Model.Cw_Accounting_Pay GetModel(string CAA_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Cw_Accounting_Pay ");
            strSql.Append(" where CAA_ID=@CAA_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAA_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAA_ID;

            KNet.Model.Cw_Accounting_Pay model = new KNet.Model.Cw_Accounting_Pay();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CAA_ID"] != null && ds.Tables[0].Rows[0]["CAA_ID"].ToString() != "")
                {
                    model.CAA_ID = ds.Tables[0].Rows[0]["CAA_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAA_Code"] != null && ds.Tables[0].Rows[0]["CAA_Code"].ToString() != "")
                {
                    model.CAA_Code = ds.Tables[0].Rows[0]["CAA_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAA_DutyPerson"] != null && ds.Tables[0].Rows[0]["CAA_DutyPerson"].ToString() != "")
                {
                    model.CAA_DutyPerson = ds.Tables[0].Rows[0]["CAA_DutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAA_CustomerValue"] != null && ds.Tables[0].Rows[0]["CAA_CustomerValue"].ToString() != "")
                {
                    model.CAA_CustomerValue = ds.Tables[0].Rows[0]["CAA_CustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAA_Account"] != null && ds.Tables[0].Rows[0]["CAA_Account"].ToString() != "")
                {
                    model.CAA_Account = ds.Tables[0].Rows[0]["CAA_Account"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAA_PayTime"] != null && ds.Tables[0].Rows[0]["CAA_PayTime"].ToString() != "")
                {
                    model.CAA_PayTime = DateTime.Parse(ds.Tables[0].Rows[0]["CAA_PayTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAA_PayMoney"] != null && ds.Tables[0].Rows[0]["CAA_PayMoney"].ToString() != "")
                {
                    model.CAA_PayMoney = decimal.Parse(ds.Tables[0].Rows[0]["CAA_PayMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAA_Details"] != null && ds.Tables[0].Rows[0]["CAA_Details"].ToString() != "")
                {
                    model.CAA_Details = ds.Tables[0].Rows[0]["CAA_Details"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAA_CTime"] != null && ds.Tables[0].Rows[0]["CAA_CTime"].ToString() != "")
                {
                    model.CAA_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["CAA_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAA_Creator"] != null && ds.Tables[0].Rows[0]["CAA_Creator"].ToString() != "")
                {
                    model.CAA_Creator = ds.Tables[0].Rows[0]["CAA_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAA_MTime"] != null && ds.Tables[0].Rows[0]["CAA_MTime"].ToString() != "")
                {
                    model.CAA_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["CAA_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAA_Mender"] != null && ds.Tables[0].Rows[0]["CAA_Mender"].ToString() != "")
                {
                    model.CAA_Mender = ds.Tables[0].Rows[0]["CAA_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAA_Details"] != null && ds.Tables[0].Rows[0]["CAA_Details"].ToString() != "")
                {
                    model.CAA_Details = ds.Tables[0].Rows[0]["CAA_Details"].ToString();
                }
                else
                {
                    model.CAA_Details = "";
                }

                if (ds.Tables[0].Rows[0]["CAA_FID"] != null && ds.Tables[0].Rows[0]["CAA_FID"].ToString() != "")
                {
                    model.CAA_FID = ds.Tables[0].Rows[0]["CAA_FID"].ToString();
                }
                else
                {
                    model.CAA_FID = "";
                }


                if (ds.Tables[0].Rows[0]["CAA_FCAAID"] != null && ds.Tables[0].Rows[0]["CAA_FCAAID"].ToString() != "")
                {
                    model.CAA_FCAAID = ds.Tables[0].Rows[0]["CAA_FCAAID"].ToString();
                }
                else
                {
                    model.CAA_FCAAID = "";
                }
                
                if (ds.Tables[0].Rows[0]["CAA_StartDateTime"] != null && ds.Tables[0].Rows[0]["CAA_StartDateTime"].ToString() != "")
                {
                    model.CAA_StartDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CAA_StartDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAA_EndDateTime"] != null && ds.Tables[0].Rows[0]["CAA_EndDateTime"].ToString() != "")
                {
                    model.CAA_EndDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CAA_EndDateTime"].ToString());
                }


                if (ds.Tables[0].Rows[0]["CAA_BillCode"] != null && ds.Tables[0].Rows[0]["CAA_BillCode"].ToString() != "")
                {
                    model.CAA_BillCode = ds.Tables[0].Rows[0]["CAA_BillCode"].ToString();
                }
                else
                {
                    model.CAA_BillCode = "";
                }
                if (ds.Tables[0].Rows[0]["CAP_Type"] != null && ds.Tables[0].Rows[0]["CAP_Type"].ToString() != "")
                {
                    model.CAP_Type = int.Parse(ds.Tables[0].Rows[0]["CAP_Type"].ToString());
                }


                if (ds.Tables[0].Rows[0]["CAP_YFOutDate"] != null && ds.Tables[0].Rows[0]["CAP_YFOutDate"].ToString() != "")
                {
                    model.CAP_YFOutDate = DateTime.Parse(ds.Tables[0].Rows[0]["CAP_YFOutDate"].ToString());
                }


                if (ds.Tables[0].Rows[0]["CAP_YFBillCode"] != null && ds.Tables[0].Rows[0]["CAP_YFBillCode"].ToString() != "")
                {
                    model.CAP_YFBillCode = ds.Tables[0].Rows[0]["CAP_YFBillCode"].ToString();
                }
                else
                {
                    model.CAP_YFBillCode = "";
                }

                if (ds.Tables[0].Rows[0]["CAA_DetailsTotalMoney"] != null && ds.Tables[0].Rows[0]["CAA_DetailsTotalMoney"].ToString() != "")
                {
                    model.CAA_DetailsTotalMoney = decimal.Parse(ds.Tables[0].Rows[0]["CAA_DetailsTotalMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAA_leftMoney"] != null && ds.Tables[0].Rows[0]["CAA_leftMoney"].ToString() != "")
                {
                    model.CAA_leftMoney = decimal.Parse(ds.Tables[0].Rows[0]["CAA_leftMoney"].ToString());
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
            strSql.Append(" FROM Cw_Accounting_Pay a left join Cw_Accounting_Pay_Details b on CAA_ID=CAY_CAAID ");
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
            strSql.Append(" FROM Cw_Accounting_Pay ");
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
            parameters[0].Value = "Cw_Accounting_Pay";
            parameters[1].Value = "CAA_ID";
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


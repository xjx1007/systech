using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Cw_Account_Bill
    /// </summary>
    public partial class Cw_Account_Bill
    {
        public Cw_Account_Bill()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CAB_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cw_Account_Bill");
            strSql.Append(" where CAB_ID=@CAB_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAB_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAB_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cw_Account_Bill model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cw_Account_Bill(");
            strSql.Append("CAB_ID,CAB_Code,CAB_Content,CAB_DutyPerson,CAB_CustomerValue,CAB_ContractNo,CAB_BillType,CAB_Money,CAB_BillNumber,CAB_Stime,CAB_Brokerage,CAB_Remarks,CAB_Ctime,CAB_Creator,CAB_Mtime,CAB_Mender,CAB_Del,CAB_CAPID,CAB_Day,CAB_OutTime,CAB_PayMent,CAB_ReceiveID)");
            strSql.Append(" values (");
            strSql.Append("@CAB_ID,@CAB_Code,@CAB_Content,@CAB_DutyPerson,@CAB_CustomerValue,@CAB_ContractNo,@CAB_BillType,@CAB_Money,@CAB_BillNumber,@CAB_Stime,@CAB_Brokerage,@CAB_Remarks,@CAB_Ctime,@CAB_Creator,@CAB_Mtime,@CAB_Mender,@CAB_Del,@CAB_CAPID,@CAB_Day,@CAB_OutTime,@CAB_PayMent,@CAB_ReceiveID)");
            SqlParameter[] parameters = {
					new SqlParameter("@CAB_ID", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_Code", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_Content", SqlDbType.VarChar,150),
					new SqlParameter("@CAB_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_ContractNo", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_BillType", SqlDbType.Int,4),
					new SqlParameter("@CAB_Money", SqlDbType.Decimal,9),
					new SqlParameter("@CAB_BillNumber", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_Stime", SqlDbType.DateTime),
					new SqlParameter("@CAB_Brokerage", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_Remarks", SqlDbType.VarChar,150),
					new SqlParameter("@CAB_Ctime", SqlDbType.DateTime),
					new SqlParameter("@CAB_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_Mtime", SqlDbType.DateTime),
					new SqlParameter("@CAB_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_Del", SqlDbType.Int,4),
					new SqlParameter("@CAB_CAPID", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_Day", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_OutTime", SqlDbType.DateTime),
					new SqlParameter("@CAB_PayMent", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_ReceiveID", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = model.CAB_ID;
            parameters[1].Value = model.CAB_Code;
            parameters[2].Value = model.CAB_Content;
            parameters[3].Value = model.CAB_DutyPerson;
            parameters[4].Value = model.CAB_CustomerValue;
            parameters[5].Value = model.CAB_ContractNo;
            parameters[6].Value = model.CAB_BillType;
            parameters[7].Value = model.CAB_Money;
            parameters[8].Value = model.CAB_BillNumber;
            parameters[9].Value = model.CAB_Stime;
            parameters[10].Value = model.CAB_Brokerage;
            parameters[11].Value = model.CAB_Remarks;
            parameters[12].Value = model.CAB_Ctime;
            parameters[13].Value = model.CAB_Creator;
            parameters[14].Value = model.CAB_Mtime;
            parameters[15].Value = model.CAB_Mender;
            parameters[16].Value = model.CAB_Del;
            parameters[17].Value = model.CAB_CAPID;
            parameters[18].Value = model.CAB_Day;
            parameters[19].Value = model.CAB_OutTime;
            parameters[20].Value = model.CAB_PayMent;
            parameters[21].Value = model.CAB_ReceiveID;
            
            
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cw_Account_Bill model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cw_Account_Bill set ");
            strSql.Append("CAB_Code=@CAB_Code,");
            strSql.Append("CAB_Content=@CAB_Content,");
            strSql.Append("CAB_DutyPerson=@CAB_DutyPerson,");
            strSql.Append("CAB_CustomerValue=@CAB_CustomerValue,");
            strSql.Append("CAB_ContractNo=@CAB_ContractNo,");
            strSql.Append("CAB_BillType=@CAB_BillType,");
            strSql.Append("CAB_Money=@CAB_Money,");
            strSql.Append("CAB_BillNumber=@CAB_BillNumber,");
            strSql.Append("CAB_Stime=@CAB_Stime,");
            strSql.Append("CAB_Brokerage=@CAB_Brokerage,");
            strSql.Append("CAB_Remarks=@CAB_Remarks,");
            strSql.Append("CAB_Mtime=@CAB_Mtime,");
            strSql.Append("CAB_Mender=@CAB_Mender,");
            strSql.Append("CAB_CAPID=@CAB_CAPID,");
            strSql.Append("CAB_Del=@CAB_Del,");
            strSql.Append("CAB_Day=@CAB_Day,");
            strSql.Append("CAB_OutTime=@CAB_OutTime,");
            strSql.Append("CAB_PayMent=@CAB_PayMent, ");
            strSql.Append("CAB_ReceiveID=@CAB_ReceiveID ");
            strSql.Append(" where CAB_ID=@CAB_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAB_Code", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_Content", SqlDbType.VarChar,150),
					new SqlParameter("@CAB_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_ContractNo", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_BillType", SqlDbType.Int,4),
					new SqlParameter("@CAB_Money", SqlDbType.Decimal,9),
					new SqlParameter("@CAB_BillNumber", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_Stime", SqlDbType.DateTime),
					new SqlParameter("@CAB_Brokerage", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_Remarks", SqlDbType.VarChar,150),
					new SqlParameter("@CAB_Mtime", SqlDbType.DateTime),
					new SqlParameter("@CAB_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_CAPID", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_Del", SqlDbType.Int,4),
					new SqlParameter("@CAB_Day", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_OutTime", SqlDbType.DateTime),
					new SqlParameter("@CAB_PayMent", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_ReceiveID", SqlDbType.VarChar,50),
					new SqlParameter("@CAB_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CAB_Code;
            parameters[1].Value = model.CAB_Content;
            parameters[2].Value = model.CAB_DutyPerson;
            parameters[3].Value = model.CAB_CustomerValue;
            parameters[4].Value = model.CAB_ContractNo;
            parameters[5].Value = model.CAB_BillType;
            parameters[6].Value = model.CAB_Money;
            parameters[7].Value = model.CAB_BillNumber;
            parameters[8].Value = model.CAB_Stime;
            parameters[9].Value = model.CAB_Brokerage;
            parameters[10].Value = model.CAB_Remarks;
            parameters[11].Value = model.CAB_Mtime;
            parameters[12].Value = model.CAB_Mender;
            parameters[13].Value = model.CAB_CAPID;
            parameters[14].Value = model.CAB_Del;
            parameters[15].Value = model.CAB_Day;
            parameters[16].Value = model.CAB_OutTime;
            parameters[17].Value = model.CAB_PayMent;
            parameters[18].Value = model.CAB_ReceiveID;
            parameters[19].Value = model.CAB_ID;

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
        public bool Delete(string CAB_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cw_Account_Bill ");
            strSql.Append(" where CAB_ID=@CAB_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAB_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAB_ID;

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
        public bool DeleteList(string CAB_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cw_Account_Bill ");
            strSql.Append(" where CAB_ID in (" + CAB_IDlist + ")  ");
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
        public KNet.Model.Cw_Account_Bill GetModel(string CAB_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 *  from Cw_Account_Bill ");
            strSql.Append(" where CAB_ID=@CAB_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAB_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAB_ID;

            KNet.Model.Cw_Account_Bill model = new KNet.Model.Cw_Account_Bill();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CAB_ID"] != null && ds.Tables[0].Rows[0]["CAB_ID"].ToString() != "")
                {
                    model.CAB_ID = ds.Tables[0].Rows[0]["CAB_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAB_Code"] != null && ds.Tables[0].Rows[0]["CAB_Code"].ToString() != "")
                {
                    model.CAB_Code = ds.Tables[0].Rows[0]["CAB_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAB_Content"] != null && ds.Tables[0].Rows[0]["CAB_Content"].ToString() != "")
                {
                    model.CAB_Content = ds.Tables[0].Rows[0]["CAB_Content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAB_DutyPerson"] != null && ds.Tables[0].Rows[0]["CAB_DutyPerson"].ToString() != "")
                {
                    model.CAB_DutyPerson = ds.Tables[0].Rows[0]["CAB_DutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAB_CustomerValue"] != null && ds.Tables[0].Rows[0]["CAB_CustomerValue"].ToString() != "")
                {
                    model.CAB_CustomerValue = ds.Tables[0].Rows[0]["CAB_CustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAB_ContractNo"] != null && ds.Tables[0].Rows[0]["CAB_ContractNo"].ToString() != "")
                {
                    model.CAB_ContractNo = ds.Tables[0].Rows[0]["CAB_ContractNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAB_BillType"] != null && ds.Tables[0].Rows[0]["CAB_BillType"].ToString() != "")
                {
                    model.CAB_BillType = int.Parse(ds.Tables[0].Rows[0]["CAB_BillType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAB_Money"] != null && ds.Tables[0].Rows[0]["CAB_Money"].ToString() != "")
                {
                    model.CAB_Money = decimal.Parse(ds.Tables[0].Rows[0]["CAB_Money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAB_BillNumber"] != null && ds.Tables[0].Rows[0]["CAB_BillNumber"].ToString() != "")
                {
                    model.CAB_BillNumber = ds.Tables[0].Rows[0]["CAB_BillNumber"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAB_Stime"] != null && ds.Tables[0].Rows[0]["CAB_Stime"].ToString() != "")
                {
                    model.CAB_Stime = DateTime.Parse(ds.Tables[0].Rows[0]["CAB_Stime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAB_Brokerage"] != null && ds.Tables[0].Rows[0]["CAB_Brokerage"].ToString() != "")
                {
                    model.CAB_Brokerage = ds.Tables[0].Rows[0]["CAB_Brokerage"].ToString();
                }
                else
                {
                    model.CAB_Brokerage = "";
                }
                if (ds.Tables[0].Rows[0]["CAB_Remarks"] != null && ds.Tables[0].Rows[0]["CAB_Remarks"].ToString() != "")
                {
                    model.CAB_Remarks = ds.Tables[0].Rows[0]["CAB_Remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAB_Ctime"] != null && ds.Tables[0].Rows[0]["CAB_Ctime"].ToString() != "")
                {
                    model.CAB_Ctime = DateTime.Parse(ds.Tables[0].Rows[0]["CAB_Ctime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAB_Creator"] != null && ds.Tables[0].Rows[0]["CAB_Creator"].ToString() != "")
                {
                    model.CAB_Creator = ds.Tables[0].Rows[0]["CAB_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAB_Mtime"] != null && ds.Tables[0].Rows[0]["CAB_Mtime"].ToString() != "")
                {
                    model.CAB_Mtime = DateTime.Parse(ds.Tables[0].Rows[0]["CAB_Mtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAB_Mender"] != null && ds.Tables[0].Rows[0]["CAB_Mender"].ToString() != "")
                {
                    model.CAB_Mender = ds.Tables[0].Rows[0]["CAB_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAB_Del"] != null && ds.Tables[0].Rows[0]["CAB_Del"].ToString() != "")
                {
                    model.CAB_Del = int.Parse(ds.Tables[0].Rows[0]["CAB_Del"].ToString());
                }

                if (ds.Tables[0].Rows[0]["CAB_ChchekYN"] != null && ds.Tables[0].Rows[0]["CAB_ChchekYN"].ToString() != "")
                {
                    model.CAB_ChchekYN = int.Parse(ds.Tables[0].Rows[0]["CAB_ChchekYN"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAB_CAPID"] != null && ds.Tables[0].Rows[0]["CAB_CAPID"].ToString() != "")
                {
                    model.CAB_CAPID = ds.Tables[0].Rows[0]["CAB_CAPID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAB_Day"] != null && ds.Tables[0].Rows[0]["CAB_Day"].ToString() != "")
                {
                    model.CAB_Day = ds.Tables[0].Rows[0]["CAB_Day"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAB_OutTime"] != null && ds.Tables[0].Rows[0]["CAB_OutTime"].ToString() != "")
                {
                    model.CAB_OutTime = DateTime.Parse(ds.Tables[0].Rows[0]["CAB_OutTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAB_PayMent"] != null && ds.Tables[0].Rows[0]["CAB_PayMent"].ToString() != "")
                {
                    model.CAB_PayMent =ds.Tables[0].Rows[0]["CAB_PayMent"].ToString();
                }

                if (ds.Tables[0].Rows[0]["CAB_ReceiveID"] != null && ds.Tables[0].Rows[0]["CAB_ReceiveID"].ToString() != "")
                {
                    model.CAB_ReceiveID = ds.Tables[0].Rows[0]["CAB_ReceiveID"].ToString();
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
            strSql.Append(" FROM Cw_Account_Bill ");
            strSql.Append(" left join Cw_Accounting_Payment on CAB_CAPID=CAP_ID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" Order by CAB_MTime desc ");

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
            strSql.Append(" FROM Cw_Account_Bill ");
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
            parameters[0].Value = "Cw_Account_Bill";
            parameters[1].Value = "CAB_ID";
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


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class CG_Payment_For
    {
        public CG_Payment_For()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CPF_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CG_Payment_For");
            strSql.Append(" where CPF_ID=@CPF_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@CPF_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = CPF_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.CG_Payment_For model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CG_Payment_For(");
            strSql.Append("CPF_ID,CPF_Code,CPF_STime,CPF_Used,CPF_UseType,CPF_Currency,CPF_Capital,CPF_Lowercase,CPF_DutyPerson,CPF_ContractNo,CPF_FID,CPF_YTime,CPF_DutyDepart,CPF_ResPerson,CPF_ResDateTime,CPF_Account,CPF_Bank,CPF_SuppNo,CPF_SuppNoName,CPF_Remarks,CPF_State,CPF_CwPerson,CPF_CwDateTime,CPF_ZPerson,CPF_ZDateTime,CPF_SpState,CPF_Shen,CPF_Shi,CPF_Del,CPF_Creator,CPF_CTime,CPF_Mender,CPF_MTime,CPF_Image,CPF_BigImage,CPF_Details,CPF_MainFID,CPF_WuliuID,CPF_OutDateTime,CPF_ProductsType,CPF_ProjectName,CPF_RepayMoney,CPF_DDutyPerson");
            strSql.Append(") values (");
            strSql.Append("@CPF_ID,@CPF_Code,@CPF_STime,@CPF_Used,@CPF_UseType,@CPF_Currency,@CPF_Capital,@CPF_Lowercase,@CPF_DutyPerson,@CPF_ContractNo,@CPF_FID,@CPF_YTime,@CPF_DutyDepart,@CPF_ResPerson,@CPF_ResDateTime,@CPF_Account,@CPF_Bank,@CPF_SuppNo,@CPF_SuppNoName,@CPF_Remarks,@CPF_State,@CPF_CwPerson,@CPF_CwDateTime,@CPF_ZPerson,@CPF_ZDateTime,@CPF_SpState,@CPF_Shen,@CPF_Shi,@CPF_Del,@CPF_Creator,@CPF_CTime,@CPF_Mender,@CPF_MTime,@CPF_Image,@CPF_BigImage,@CPF_Details,@CPF_MainFID,@CPF_WuliuID,@CPF_OutDateTime,@CPF_ProductsType,@CPF_ProjectName,@CPF_RepayMoney,@CPF_DDutyPerson)");
            SqlParameter[] parameters = {
 new SqlParameter("@CPF_ID", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_Code", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_STime", SqlDbType.DateTime,8),
 new SqlParameter("@CPF_Used", SqlDbType.VarChar,300),
 new SqlParameter("@CPF_UseType", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_Currency", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_Capital", SqlDbType.VarChar,550),
 new SqlParameter("@CPF_Lowercase", SqlDbType.Decimal,9),
 new SqlParameter("@CPF_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_ContractNo", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_FID", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_YTime", SqlDbType.DateTime,8),
 new SqlParameter("@CPF_DutyDepart", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_ResPerson", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_ResDateTime", SqlDbType.DateTime,8),
 new SqlParameter("@CPF_Account", SqlDbType.VarChar,500),
 new SqlParameter("@CPF_Bank", SqlDbType.VarChar,500),
 new SqlParameter("@CPF_SuppNo", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_SuppNoName", SqlDbType.VarChar,500),
 new SqlParameter("@CPF_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@CPF_State", SqlDbType.Int,4),
 new SqlParameter("@CPF_CwPerson", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_CwDateTime", SqlDbType.DateTime,8),
 new SqlParameter("@CPF_ZPerson", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_ZDateTime", SqlDbType.DateTime,8),
 new SqlParameter("@CPF_SpState", SqlDbType.Int,4),
 new SqlParameter("@CPF_Shen", SqlDbType.VarChar,300),
 new SqlParameter("@CPF_Shi", SqlDbType.VarChar,300),
 new SqlParameter("@CPF_Del", SqlDbType.Int,4),
 new SqlParameter("@CPF_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@CPF_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@CPF_Image", SqlDbType.VarChar,300),
 new SqlParameter("@CPF_BigImage", SqlDbType.VarChar,300),
 new SqlParameter("@CPF_Details", SqlDbType.VarChar,300),
 new SqlParameter("@CPF_MainFID", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_WuliuID", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_OutDateTime", SqlDbType.DateTime,8),
 new SqlParameter("@CPF_ProductsType", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_ProjectName", SqlDbType.VarChar,350),
 new SqlParameter("@CPF_RepayMoney", SqlDbType.VarChar,150),
 new SqlParameter("@CPF_DDutyPerson", SqlDbType.VarChar,50),
 
                            };
            parameters[0].Value = model.CPF_ID;
            parameters[1].Value = model.CPF_Code;
            parameters[2].Value = model.CPF_STime;
            parameters[3].Value = model.CPF_Used;
            parameters[4].Value = model.CPF_UseType;
            parameters[5].Value = model.CPF_Currency;
            parameters[6].Value = model.CPF_Capital;
            parameters[7].Value = model.CPF_Lowercase;
            parameters[8].Value = model.CPF_DutyPerson;
            parameters[9].Value = model.CPF_ContractNo;
            parameters[10].Value = model.CPF_FID;
            parameters[11].Value = model.CPF_YTime;
            parameters[12].Value = model.CPF_DutyDepart;
            parameters[13].Value = model.CPF_ResPerson;
            parameters[14].Value = model.CPF_ResDateTime;
            parameters[15].Value = model.CPF_Account;
            parameters[16].Value = model.CPF_Bank;
            parameters[17].Value = model.CPF_SuppNo;
            parameters[18].Value = model.CPF_SuppNoName;
            parameters[19].Value = model.CPF_Remarks;
            parameters[20].Value = model.CPF_State;
            parameters[21].Value = model.CPF_CwPerson;
            parameters[22].Value = model.CPF_CwDateTime;
            parameters[23].Value = model.CPF_ZPerson;
            parameters[24].Value = model.CPF_ZDateTime;
            parameters[25].Value = model.CPF_SpState;
            parameters[26].Value = model.CPF_Shen;
            parameters[27].Value = model.CPF_Shi;
            parameters[28].Value = model.CPF_Del;
            parameters[29].Value = model.CPF_Creator;
            parameters[30].Value = model.CPF_CTime;
            parameters[31].Value = model.CPF_Mender;
            parameters[32].Value = model.CPF_MTime;
            parameters[33].Value = model.CPF_Image;
            parameters[34].Value = model.CPF_BigImage;
            parameters[35].Value = model.CPF_Details;
            parameters[36].Value = model.CPF_MainFID;
            parameters[37].Value = model.CPF_WuliuID;
            parameters[38].Value = model.CPF_OutDateTime;

            parameters[39].Value = model.CPF_ProductsType;
            parameters[40].Value = model.CPF_ProjectName;
            parameters[41].Value = model.CPF_RepayMoney;
            parameters[42].Value = model.CPF_DDutyPerson;

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
        public bool Update(KNet.Model.CG_Payment_For model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update CG_Payment_For set ");
            strSql.Append("CPF_Code=@CPF_Code,");
            strSql.Append("CPF_STime=@CPF_STime,");
            strSql.Append("CPF_Used=@CPF_Used,");
            strSql.Append("CPF_UseType=@CPF_UseType,");
            strSql.Append("CPF_Currency=@CPF_Currency,");
            strSql.Append("CPF_Capital=@CPF_Capital,");
            strSql.Append("CPF_Lowercase=@CPF_Lowercase,");
            strSql.Append("CPF_DutyPerson=@CPF_DutyPerson,");
            strSql.Append("CPF_ContractNo=@CPF_ContractNo,");
            strSql.Append("CPF_FID=@CPF_FID,");
            strSql.Append("CPF_YTime=@CPF_YTime,");
            strSql.Append("CPF_DutyDepart=@CPF_DutyDepart,");
            strSql.Append("CPF_ResPerson=@CPF_ResPerson,");
            strSql.Append("CPF_ResDateTime=@CPF_ResDateTime,");
            strSql.Append("CPF_Account=@CPF_Account,");
            strSql.Append("CPF_Bank=@CPF_Bank,");
            strSql.Append("CPF_SuppNo=@CPF_SuppNo,");
            strSql.Append("CPF_SuppNoName=@CPF_SuppNoName,");
            strSql.Append("CPF_Remarks=@CPF_Remarks,");
            strSql.Append("CPF_State=@CPF_State,");
            strSql.Append("CPF_CwPerson=@CPF_CwPerson,");
            strSql.Append("CPF_CwDateTime=@CPF_CwDateTime,");
            strSql.Append("CPF_ZPerson=@CPF_ZPerson,");
            strSql.Append("CPF_ZDateTime=@CPF_ZDateTime,");
            strSql.Append("CPF_SpState=@CPF_SpState,");
            strSql.Append("CPF_Shen=@CPF_Shen,");
            strSql.Append("CPF_Shi=@CPF_Shi,");
            strSql.Append("CPF_Del=@CPF_Del,");
            strSql.Append("CPF_Mender=@CPF_Mender,");
            strSql.Append("CPF_MTime=@CPF_MTime,");
            strSql.Append("CPF_Image=@CPF_Image,");
            strSql.Append("CPF_BigImage=@CPF_BigImage,");
            strSql.Append("CPF_MainFID=@CPF_MainFID,");
            strSql.Append("CPF_Details=@CPF_Details, ");

            strSql.Append("CPF_ProductsType=@CPF_ProductsType, ");
            strSql.Append("CPF_ProjectName=@CPF_ProjectName, ");
            strSql.Append("CPF_RepayMoney=@CPF_RepayMoney, ");
            strSql.Append("CPF_DDutyPerson=@CPF_DDutyPerson, ");

            strSql.Append("CPF_OutDateTime=@CPF_OutDateTime ");

            strSql.Append(" where CPF_ID=@CPF_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@CPF_Code", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_STime", SqlDbType.DateTime,8),
 new SqlParameter("@CPF_Used", SqlDbType.VarChar,300),
 new SqlParameter("@CPF_UseType", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_Currency", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_Capital", SqlDbType.VarChar,550),
 new SqlParameter("@CPF_Lowercase", SqlDbType.Decimal,9),
 new SqlParameter("@CPF_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_ContractNo", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_FID", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_YTime", SqlDbType.DateTime,8),
 new SqlParameter("@CPF_DutyDepart", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_ResPerson", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_ResDateTime", SqlDbType.DateTime,8),
 new SqlParameter("@CPF_Account", SqlDbType.VarChar,500),
 new SqlParameter("@CPF_Bank", SqlDbType.VarChar,500),
 new SqlParameter("@CPF_SuppNo", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_SuppNoName", SqlDbType.VarChar,500),
 new SqlParameter("@CPF_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@CPF_State", SqlDbType.Int,4),
 new SqlParameter("@CPF_CwPerson", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_CwDateTime", SqlDbType.DateTime,8),
 new SqlParameter("@CPF_ZPerson", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_ZDateTime", SqlDbType.DateTime,8),
 new SqlParameter("@CPF_SpState", SqlDbType.Int,4),
 new SqlParameter("@CPF_Shen", SqlDbType.VarChar,300),
 new SqlParameter("@CPF_Shi", SqlDbType.VarChar,300),
 new SqlParameter("@CPF_Del", SqlDbType.Int,4),
 new SqlParameter("@CPF_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@CPF_Image", SqlDbType.VarChar,300),
 new SqlParameter("@CPF_BigImage", SqlDbType.VarChar,300),
 new SqlParameter("@CPF_MainFID", SqlDbType.VarChar,50),
 
 new SqlParameter("@CPF_Details", SqlDbType.VarChar,300),
 
 new SqlParameter("@CPF_ProductsType", SqlDbType.VarChar,50),
 new SqlParameter("@CPF_ProjectName", SqlDbType.VarChar,350),
 new SqlParameter("@CPF_RepayMoney", SqlDbType.VarChar,150),
 new SqlParameter("@CPF_DDutyPerson", SqlDbType.VarChar,50),

 new SqlParameter("@CPF_OutDateTime", SqlDbType.DateTime,8),
 
new SqlParameter("@CPF_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CPF_Code;
            parameters[1].Value = model.CPF_STime;
            parameters[2].Value = model.CPF_Used;
            parameters[3].Value = model.CPF_UseType;
            parameters[4].Value = model.CPF_Currency;
            parameters[5].Value = model.CPF_Capital;
            parameters[6].Value = model.CPF_Lowercase;
            parameters[7].Value = model.CPF_DutyPerson;
            parameters[8].Value = model.CPF_ContractNo;
            parameters[9].Value = model.CPF_FID;
            parameters[10].Value = model.CPF_YTime;
            parameters[11].Value = model.CPF_DutyDepart;
            parameters[12].Value = model.CPF_ResPerson;
            parameters[13].Value = model.CPF_ResDateTime;
            parameters[14].Value = model.CPF_Account;
            parameters[15].Value = model.CPF_Bank;
            parameters[16].Value = model.CPF_SuppNo;
            parameters[17].Value = model.CPF_SuppNoName;
            parameters[18].Value = model.CPF_Remarks;
            parameters[19].Value = model.CPF_State;
            parameters[20].Value = model.CPF_CwPerson;
            parameters[21].Value = model.CPF_CwDateTime;
            parameters[22].Value = model.CPF_ZPerson;
            parameters[23].Value = model.CPF_ZDateTime;
            parameters[24].Value = model.CPF_SpState;
            parameters[25].Value = model.CPF_Shen;
            parameters[26].Value = model.CPF_Shi;
            parameters[27].Value = model.CPF_Del;
            parameters[28].Value = model.CPF_Mender;
            parameters[29].Value = model.CPF_MTime;
            parameters[30].Value = model.CPF_Image;
            parameters[31].Value = model.CPF_BigImage;
            parameters[32].Value = model.CPF_MainFID;

            parameters[33].Value = model.CPF_Details;

            parameters[34].Value = model.CPF_ProductsType;
            parameters[35].Value = model.CPF_ProjectName;
            parameters[36].Value = model.CPF_RepayMoney;
            parameters[37].Value = model.CPF_DDutyPerson;

            parameters[38].Value = model.CPF_OutDateTime;
            parameters[39].Value = model.CPF_ID;

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
        public bool Delete(string s_CPF_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  CG_Payment_For  ");
            strSql.Append(" where CPF_ID=@CPF_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@CPF_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = s_CPF_ID;
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
        public bool UpdateDel(KNet.Model.CG_Payment_For model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update   CG_Payment_For  Set ");
            strSql.Append("  CPF_Del=@CPF_Del ");
            strSql.Append(" where CPF_ID=@CPF_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@CPF_Del", SqlDbType.Int,4),
new SqlParameter("@CPF_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CPF_Del;
            parameters[1].Value = model.CPF_ID;

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
        public bool DeleteList(string s_CPF_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From   CG_Payment_For  ");
            strSql.Append(" where CPF_ID in ('" + s_CPF_ID + "')");

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
            strSql.Append("delete from  CG_Payment_For  ");
            strSql.Append(" Where  CPF_FID=@CPF_FID ");
            SqlParameter[] parameters = {
 new SqlParameter("@CPF_FID", SqlDbType.VarChar,50),
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
        public KNet.Model.CG_Payment_For GetModel(string CPF_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from CG_Payment_For  ");
            strSql.Append("where CPF_ID=@CPF_ID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@CPF_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = CPF_ID;
            KNet.Model.CG_Payment_For model = new KNet.Model.CG_Payment_For();
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
        public KNet.Model.CG_Payment_For DataRowToModel(DataRow row)
        {
            KNet.Model.CG_Payment_For model = new KNet.Model.CG_Payment_For();
            if (row != null)
            {

                try
                {
                    if (row["CPF_OutDateTime"] != null)
                    {
                        model.CPF_OutDateTime = DateTime.Parse(row["CPF_OutDateTime"].ToString());
                    }
                }
                catch
                {
                    model.CPF_OutDateTime = DateTime.Parse("1900-01-01");
                }

                if (row["CPF_ID"] != null)
                {
                    model.CPF_ID = row["CPF_ID"].ToString();
                }
                else
                {
                    model.CPF_ID = "";
                }
                if (row["CPF_Code"] != null)
                {
                    model.CPF_Code = row["CPF_Code"].ToString();
                }
                else
                {
                    model.CPF_Code = "";
                }
                if (row["CPF_STime"] != null)
                {
                    model.CPF_STime = DateTime.Parse(row["CPF_STime"].ToString());
                }
                if (row["CPF_Used"] != null)
                {
                    model.CPF_Used = row["CPF_Used"].ToString();
                }
                else
                {
                    model.CPF_Used = "";
                }
                if (row["CPF_UseType"] != null)
                {
                    model.CPF_UseType = row["CPF_UseType"].ToString();
                }
                else
                {
                    model.CPF_UseType = "";
                }
                if (row["CPF_Currency"] != null)
                {
                    model.CPF_Currency = row["CPF_Currency"].ToString();
                }
                else
                {
                    model.CPF_Currency = "";
                }
                if (row["CPF_Capital"] != null)
                {
                    model.CPF_Capital = row["CPF_Capital"].ToString();
                }
                else
                {
                    model.CPF_Capital = "";
                }
                if (row["CPF_Lowercase"] != null)
                {
                    model.CPF_Lowercase = Decimal.Parse(row["CPF_Lowercase"].ToString());
                }
                else
                {
                    model.CPF_Lowercase = 0;
                }
                if (row["CPF_DutyPerson"] != null)
                {
                    model.CPF_DutyPerson = row["CPF_DutyPerson"].ToString();
                }
                else
                {
                    model.CPF_DutyPerson = "";
                }
                if (row["CPF_ContractNo"] != null)
                {
                    model.CPF_ContractNo = row["CPF_ContractNo"].ToString();
                }
                else
                {
                    model.CPF_ContractNo = "";
                }
                if (row["CPF_FID"] != null)
                {
                    model.CPF_FID = row["CPF_FID"].ToString();
                }
                else
                {
                    model.CPF_FID = "";
                }
                if (row["CPF_YTime"] != null)
                {
                    model.CPF_YTime = DateTime.Parse(row["CPF_YTime"].ToString());
                }
                if (row["CPF_DutyDepart"] != null)
                {
                    model.CPF_DutyDepart = row["CPF_DutyDepart"].ToString();
                }
                else
                {
                    model.CPF_DutyDepart = "";
                }
                if (row["CPF_ResPerson"] != null)
                {
                    model.CPF_ResPerson = row["CPF_ResPerson"].ToString();
                }
                else
                {
                    model.CPF_ResPerson = "";
                }
                if (row["CPF_ResDateTime"] != null)
                {
                    model.CPF_ResDateTime = DateTime.Parse(row["CPF_ResDateTime"].ToString());
                }


                if (row["CPF_Account"] != null)
                {
                    model.CPF_Account = row["CPF_Account"].ToString();
                }
                else
                {
                    model.CPF_Account = "";
                }
                if (row["CPF_Bank"] != null)
                {
                    model.CPF_Bank = row["CPF_Bank"].ToString();
                }
                else
                {
                    model.CPF_Bank = "";
                }
                if (row["CPF_SuppNo"] != null)
                {
                    model.CPF_SuppNo = row["CPF_SuppNo"].ToString();
                }
                else
                {
                    model.CPF_SuppNo = "";
                }
                if (row["CPF_SuppNoName"] != null)
                {
                    model.CPF_SuppNoName = row["CPF_SuppNoName"].ToString();
                }
                else
                {
                    model.CPF_SuppNoName = "";
                }
                if (row["CPF_Remarks"] != null)
                {
                    model.CPF_Remarks = row["CPF_Remarks"].ToString();
                }
                else
                {
                    model.CPF_Remarks = "";
                }
                if (row["CPF_State"] != null)
                {
                    model.CPF_State = int.Parse(row["CPF_State"].ToString());
                }
                else
                {
                    model.CPF_State = 0;
                }
                if (row["CPF_CwPerson"] != null)
                {
                    model.CPF_CwPerson = row["CPF_CwPerson"].ToString();
                }
                else
                {
                    model.CPF_CwPerson = "";
                }
                if (row["CPF_CwDateTime"] != null)
                {
                    model.CPF_CwDateTime = DateTime.Parse(row["CPF_CwDateTime"].ToString());
                }
                if (row["CPF_ZPerson"] != null)
                {
                    model.CPF_ZPerson = row["CPF_ZPerson"].ToString();
                }
                else
                {
                    model.CPF_ZPerson = "";
                }
                if (row["CPF_ZDateTime"] != null)
                {
                    model.CPF_ZDateTime = DateTime.Parse(row["CPF_ZDateTime"].ToString());
                }
                if (row["CPF_SpState"] != null)
                {
                    model.CPF_SpState = int.Parse(row["CPF_SpState"].ToString());
                }
                else
                {
                    model.CPF_SpState = 0;
                }
                if (row["CPF_Shen"] != null)
                {
                    model.CPF_Shen = row["CPF_Shen"].ToString();
                }
                else
                {
                    model.CPF_Shen = "";
                }
                if (row["CPF_Shi"] != null)
                {
                    model.CPF_Shi = row["CPF_Shi"].ToString();
                }
                else
                {
                    model.CPF_Shi = "";
                }
                if (row["CPF_Del"] != null)
                {
                    model.CPF_Del = int.Parse(row["CPF_Del"].ToString());
                }
                else
                {
                    model.CPF_Del = 0;
                }
                if (row["CPF_Creator"] != null)
                {
                    model.CPF_Creator = row["CPF_Creator"].ToString();
                }
                else
                {
                    model.CPF_Creator = "";
                }
                if (row["CPF_CTime"] != null)
                {
                    model.CPF_CTime = DateTime.Parse(row["CPF_CTime"].ToString());
                }
                if (row["CPF_Details"] != null)
                {
                    model.CPF_Details = row["CPF_Details"].ToString();
                }
                else
                {
                    model.CPF_Details = "";
                }
                if (row["CPF_Mender"] != null)
                {
                    model.CPF_Mender = row["CPF_Mender"].ToString();
                }
                else
                {
                    model.CPF_Mender = "";
                }
                if (row["CPF_MTime"] != null)
                {
                    model.CPF_MTime = DateTime.Parse(row["CPF_MTime"].ToString());
                }

                if (row["CPF_Image"] != null)
                {
                    model.CPF_Image = row["CPF_Image"].ToString();
                }
                else
                {
                    model.CPF_Image = "";
                }
                if (row["CPF_BigImage"] != null)
                {
                    model.CPF_BigImage = row["CPF_BigImage"].ToString();
                }
                else
                {
                    model.CPF_BigImage = "";
                }


                if (row["CPF_MainFID"] != null)
                {
                    model.CPF_MainFID = row["CPF_MainFID"].ToString();
                }
                else
                {
                    model.CPF_MainFID = "";
                }
                if (row["CPF_WuliuID"] != null)
                {
                    model.CPF_WuliuID = row["CPF_WuliuID"].ToString();
                }
                else
                {
                    model.CPF_WuliuID = "";
                }

                if (row["CPF_ProductsType"] != null)
                {
                    model.CPF_ProductsType = row["CPF_ProductsType"].ToString();
                }
                else
                {
                    model.CPF_ProductsType = "";
                }


                if (row["CPF_ProjectName"] != null)
                {
                    model.CPF_ProjectName = row["CPF_ProjectName"].ToString();
                }
                else
                {
                    model.CPF_ProjectName = "";
                }


                if (row["CPF_RepayMoney"] != null)
                {
                    model.CPF_RepayMoney = row["CPF_RepayMoney"].ToString();
                }
                else
                {
                    model.CPF_RepayMoney = "";
                }

                if (row["CPF_DDutyPerson"] != null)
                {
                    model.CPF_DDutyPerson = row["CPF_DDutyPerson"].ToString();
                }
                else
                {
                    model.CPF_DDutyPerson = "";
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
            strSql.Append(" FROM CG_Payment_For ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

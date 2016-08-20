using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sales_ClientList。
    /// </summary>
    public class KNet_Sales_ClientList
    {
        public KNet_Sales_ClientList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在 LoginID  记录
        /// </summary>
        public bool Exists_LoginID(string LoginID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@LoginID", SqlDbType.NVarChar,50)};
            parameters[0].Value = LoginID;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sales_ClientList_Exists_LoginID", parameters, out rowsAffected);
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
        /// 是否存在 CustomerValue  记录
        /// </summary>
        public bool Exists_CustomerValue(string CustomerValue)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@CustomerValue", SqlDbType.NVarChar,50)};
            parameters[0].Value = CustomerValue;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sales_ClientList_Exists_CustomerValue", parameters, out rowsAffected);
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
        /// 是否存在同城的 CustomerName  记录
        /// </summary>
        public bool Exists_CustomerName(string CustomerName, string CustomerProvinces, string CustomerCity)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@CustomerName", SqlDbType.NVarChar,50),
                    new SqlParameter("@CustomerProvinces", SqlDbType.NVarChar,50),
                    new SqlParameter("@CustomerCity", SqlDbType.NVarChar,50)};
            parameters[0].Value = CustomerName;
            parameters[1].Value = CustomerProvinces;
            parameters[2].Value = CustomerCity;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sales_ClientList_Exists_CustomerName", parameters, out rowsAffected);
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
        ///  增加一条数据
        /// </summary>
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sales_ClientList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Sales_ClientList(");
            strSql.Append("RegisterYN,LoginID,LoginPassword,CustomerName,CustomerValue,CustomerClass,CustomerTypes,CustomerProvinces,CustomerCity,CustomerTrade,CustomerSource,CustomerContact,CustomerContactSex,CustomerTel,CustomerMobile,CustomerWebsite,CustomerEmail,CustomerAddress,CustomerZipCode,CustomerQQ,CustomerMsn,CustomerProtect,CustomerIntroduction,CustomerAddtime,CustomerIntegral,CustomerIntegralUsed,CustomerMoney,CustomerMoneyUsed,PlayCycleMoney,PlayCycleTime,PlayCycleYN,CustomerFax,LinkManID,CustomerCode,FaterCode,OpeningBank,BankAccount,RegistrationNum,KSC_Level,KSC_State,KSC_Type,KSC_DutyPerson,KSC_Creator,KSC_SampleName,KSC_Auxiliary,KSC_Auxiliary1,KSC_DutyPerson1,KSC_PayMent,KSC_KPType,KSC_DlPrice)");
            strSql.Append(" values (");
            strSql.Append("@RegisterYN,@LoginID,@LoginPassword,@CustomerName,@CustomerValue,@CustomerClass,@CustomerTypes,@CustomerProvinces,@CustomerCity,@CustomerTrade,@CustomerSource,@CustomerContact,@CustomerContactSex,@CustomerTel,@CustomerMobile,@CustomerWebsite,@CustomerEmail,@CustomerAddress,@CustomerZipCode,@CustomerQQ,@CustomerMsn,@CustomerProtect,@CustomerIntroduction,@CustomerAddtime,@CustomerIntegral,@CustomerIntegralUsed,@CustomerMoney,@CustomerMoneyUsed,@PlayCycleMoney,@PlayCycleTime,@PlayCycleYN,@CustomerFax,@LinkManID,@CustomerCode,@FaterCode,@OpeningBank,@BankAccount,@RegistrationNum,@KSC_Level,@KSC_State,@KSC_Type,@KSC_DutyPerson,@KSC_Creator,@KSC_SampleName,@KSC_Auxiliary,@KSC_Auxiliary1,@KSC_DutyPerson1,@KSC_PayMent,@KSC_KPType,@KSC_DlPrice)");
            SqlParameter[] parameters = {
					new SqlParameter("@RegisterYN", SqlDbType.Bit,1),
					new SqlParameter("@LoginID", SqlDbType.NVarChar,50),
					new SqlParameter("@LoginPassword", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerName", SqlDbType.NVarChar,70),
					new SqlParameter("@CustomerValue", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerClass", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerTypes", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerProvinces", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerCity", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerTrade", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerSource", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerContact", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerContactSex", SqlDbType.NVarChar,10),
					new SqlParameter("@CustomerTel", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerMobile", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerWebsite", SqlDbType.NVarChar,100),
					new SqlParameter("@CustomerEmail", SqlDbType.NVarChar,60),
					new SqlParameter("@CustomerAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@CustomerZipCode", SqlDbType.NVarChar,10),
					new SqlParameter("@CustomerQQ", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerMsn", SqlDbType.NVarChar,60),
					new SqlParameter("@CustomerProtect", SqlDbType.Bit,1),
					new SqlParameter("@CustomerIntroduction", SqlDbType.NText),
					new SqlParameter("@CustomerAddtime", SqlDbType.DateTime),
					new SqlParameter("@CustomerIntegral", SqlDbType.Int,4),
					new SqlParameter("@CustomerIntegralUsed", SqlDbType.Int,4),
					new SqlParameter("@CustomerMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CustomerMoneyUsed", SqlDbType.Decimal,9),
					new SqlParameter("@PlayCycleMoney", SqlDbType.Decimal,9),
					new SqlParameter("@PlayCycleTime", SqlDbType.Int,4),
					new SqlParameter("@PlayCycleYN", SqlDbType.Bit,1),
					new SqlParameter("@CustomerFax", SqlDbType.VarChar,50),
					new SqlParameter("@LinkManID", SqlDbType.VarChar,50),
					new SqlParameter("@CustomerCode", SqlDbType.VarChar,50),
					new SqlParameter("@FaterCode", SqlDbType.VarChar,50),

					new SqlParameter("@OpeningBank", SqlDbType.VarChar,50),
					new SqlParameter("@BankAccount", SqlDbType.VarChar,50),
					new SqlParameter("@RegistrationNum", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_Level", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_State", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_Type", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_SampleName", SqlDbType.VarChar,500),
					new SqlParameter("@KSC_Auxiliary", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_Auxiliary1", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_DutyPerson1", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_PayMent", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_KPType", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_DlPrice", SqlDbType.Decimal,9)
                    
                    
                                        };
            parameters[0].Value = model.RegisterYN;
            parameters[1].Value = model.LoginID;
            parameters[2].Value = model.LoginPassword;
            parameters[3].Value = model.CustomerName;
            parameters[4].Value = model.CustomerValue;
            parameters[5].Value = model.CustomerClass;
            parameters[6].Value = model.CustomerTypes;
            parameters[7].Value = model.CustomerProvinces;
            parameters[8].Value = model.CustomerCity;
            parameters[9].Value = model.CustomerTrade;
            parameters[10].Value = model.CustomerSource;
            parameters[11].Value = model.CustomerContact;
            parameters[12].Value = model.CustomerContactSex;
            parameters[13].Value = model.CustomerTel;
            parameters[14].Value = model.CustomerMobile;
            parameters[15].Value = model.CustomerWebsite;
            parameters[16].Value = model.CustomerEmail;
            parameters[17].Value = model.CustomerAddress;
            parameters[18].Value = model.CustomerZipCode;
            parameters[19].Value = model.CustomerQQ;
            parameters[20].Value = model.CustomerMsn;
            parameters[21].Value = model.CustomerProtect;
            parameters[22].Value = model.CustomerIntroduction;
            parameters[23].Value = model.CustomerAddtime;
            parameters[24].Value = model.CustomerIntegral;
            parameters[25].Value = model.CustomerIntegralUsed;
            parameters[26].Value = model.CustomerMoney;
            parameters[27].Value = model.CustomerMoneyUsed;
            parameters[28].Value = model.PlayCycleMoney;
            parameters[29].Value = model.PlayCycleTime;
            parameters[30].Value = model.PlayCycleYN;
            parameters[31].Value = model.CustomerFax;
            parameters[32].Value = model.LinkManID;
            parameters[33].Value = model.CustomerCode;
            parameters[34].Value = model.FaterCode;

            parameters[35].Value = model.OpeningBank;
            parameters[36].Value = model.BankAccount;
            parameters[37].Value = model.RegistrationNum;
            parameters[38].Value = model.KSC_Level;
            parameters[39].Value = model.KSC_State;
            parameters[40].Value = model.KSC_Type;
            parameters[41].Value = model.KSC_DutyPerson;
            parameters[42].Value = model.KSC_Creator;
            parameters[43].Value = model.KSC_SampleName;

            parameters[44].Value = model.KSC_Auxiliary;
            parameters[45].Value = model.KSC_Auxiliary1;
            parameters[46].Value = model.KSC_DutyPerson1;
            parameters[47].Value = model.KSC_PayMent;
            parameters[48].Value = model.KSC_KPType;
            parameters[49].Value = model.KSC_DlPrice;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(KNet.Model.KNet_Sales_ClientList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Sales_ClientList set ");
            strSql.Append("CustomerName=@CustomerName,");
            strSql.Append("CustomerClass=@CustomerClass,");
            strSql.Append("CustomerTypes=@CustomerTypes,");
            strSql.Append("CustomerProvinces=@CustomerProvinces,");
            strSql.Append("CustomerCity=@CustomerCity,");
            strSql.Append("CustomerTrade=@CustomerTrade,");
            strSql.Append("CustomerSource=@CustomerSource,");
            strSql.Append("CustomerContact=@CustomerContact,");
            strSql.Append("CustomerContactSex=@CustomerContactSex,");
            strSql.Append("CustomerTel=@CustomerTel,");
            strSql.Append("CustomerMobile=@CustomerMobile,");
            strSql.Append("CustomerWebsite=@CustomerWebsite,");
            strSql.Append("CustomerEmail=@CustomerEmail,");
            strSql.Append("CustomerAddress=@CustomerAddress,");
            strSql.Append("CustomerZipCode=@CustomerZipCode,");
            strSql.Append("CustomerQQ=@CustomerQQ,");
            strSql.Append("CustomerMsn=@CustomerMsn,");
            strSql.Append("CustomerProtect=@CustomerProtect,");
            strSql.Append("CustomerIntroduction=@CustomerIntroduction,");
            strSql.Append("PlayCycleMoney=@PlayCycleMoney,");
            strSql.Append("PlayCycleTime=@PlayCycleTime,");
            strSql.Append("PlayCycleYN=@PlayCycleYN,");
            strSql.Append("CustomerFax=@CustomerFax,");
            strSql.Append("CustomerCode=@CustomerCode,");
            strSql.Append("FaterCode=@FaterCode,");
            strSql.Append("OpeningBank=@OpeningBank,");
            strSql.Append("BankAccount=@BankAccount,");
            strSql.Append("RegistrationNum=@RegistrationNum,");
            strSql.Append("Mender=@Mender,");
            strSql.Append("KSC_Level=@KSC_Level,");
            strSql.Append("KSC_State=@KSC_State,");
            strSql.Append("KSC_Type=@KSC_Type,");
            strSql.Append("KSC_DutyPerson=@KSC_DutyPerson,");
            strSql.Append("KSC_Auxiliary=@KSC_Auxiliary,");
            strSql.Append("KSC_SampleName=@KSC_SampleName,");
            strSql.Append("KSC_Auxiliary1=@KSC_Auxiliary1,");
            strSql.Append("KSC_DutyPerson1=@KSC_DutyPerson1,");
            strSql.Append("KSC_PayMent=@KSC_PayMent,");
            strSql.Append("KSC_KPType=@KSC_KPType,");
            strSql.Append("KSC_DlPrice=@KSC_DlPrice,");
            
            strSql.Append("MTime=@MTime");

            strSql.Append(" where CustomerValue=@CustomerValue");
            SqlParameter[] parameters = {
					new SqlParameter("@CustomerName", SqlDbType.NVarChar,70),
					new SqlParameter("@CustomerClass", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerTypes", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerProvinces", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerCity", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerTrade", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerSource", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerContact", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerContactSex", SqlDbType.NVarChar,10),
					new SqlParameter("@CustomerTel", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerMobile", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerWebsite", SqlDbType.NVarChar,100),
					new SqlParameter("@CustomerEmail", SqlDbType.NVarChar,60),
					new SqlParameter("@CustomerAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@CustomerZipCode", SqlDbType.NVarChar,10),
					new SqlParameter("@CustomerQQ", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerMsn", SqlDbType.NVarChar,60),
					new SqlParameter("@CustomerProtect", SqlDbType.Bit,1),
					new SqlParameter("@CustomerIntroduction", SqlDbType.NText),
					new SqlParameter("@PlayCycleMoney", SqlDbType.Decimal,9),
					new SqlParameter("@PlayCycleTime", SqlDbType.Int,4),
					new SqlParameter("@PlayCycleYN", SqlDbType.Bit,1),
					new SqlParameter("@CustomerFax", SqlDbType.VarChar,50),
					new SqlParameter("@CustomerCode", SqlDbType.VarChar,50),
					new SqlParameter("@FaterCode", SqlDbType.VarChar,50),
					new SqlParameter("@OpeningBank", SqlDbType.VarChar,50),
					new SqlParameter("@BankAccount", SqlDbType.VarChar,50),
					new SqlParameter("@RegistrationNum", SqlDbType.VarChar,50),
					new SqlParameter("@Mender", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_Level", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_State", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_Type", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_Auxiliary", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_SampleName", SqlDbType.VarChar,500),
					new SqlParameter("@KSC_Auxiliary1", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_DutyPerson1", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_PayMent", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_KPType", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_DlPrice", SqlDbType.Decimal,9),
                    

					new SqlParameter("@MTime", SqlDbType.DateTime),
					new SqlParameter("@CustomerValue", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CustomerName;
            parameters[1].Value = model.CustomerClass;
            parameters[2].Value = model.CustomerTypes;
            parameters[3].Value = model.CustomerProvinces;
            parameters[4].Value = model.CustomerCity;
            parameters[5].Value = model.CustomerTrade;
            parameters[6].Value = model.CustomerSource;
            parameters[7].Value = model.CustomerContact;
            parameters[8].Value = model.CustomerContactSex;
            parameters[9].Value = model.CustomerTel;
            parameters[10].Value = model.CustomerMobile;
            parameters[11].Value = model.CustomerWebsite;
            parameters[12].Value = model.CustomerEmail;
            parameters[13].Value = model.CustomerAddress;
            parameters[14].Value = model.CustomerZipCode;
            parameters[15].Value = model.CustomerQQ;
            parameters[16].Value = model.CustomerMsn;
            parameters[17].Value = model.CustomerProtect;
            parameters[18].Value = model.CustomerIntroduction;
            parameters[19].Value = model.PlayCycleMoney;
            parameters[20].Value = model.PlayCycleTime;
            parameters[21].Value = model.PlayCycleYN;
            parameters[22].Value = model.CustomerFax;
            parameters[23].Value = model.CustomerCode;
            parameters[24].Value = model.FaterCode;
            parameters[25].Value = model.OpeningBank;
            parameters[26].Value = model.BankAccount;
            parameters[27].Value = model.RegistrationNum;
            parameters[28].Value = model.Mender;
            parameters[29].Value = model.KSC_Level;
            parameters[30].Value = model.KSC_State;
            parameters[31].Value = model.KSC_Type;
            parameters[32].Value = model.KSC_DutyPerson;
            parameters[33].Value = model.KSC_Auxiliary;
            parameters[34].Value = model.KSC_SampleName;

            parameters[35].Value = model.KSC_Auxiliary1;
            parameters[36].Value = model.KSC_DutyPerson1;
            parameters[37].Value = model.KSC_PayMent;
            parameters[38].Value = model.KSC_KPType;
            parameters[39].Value = model.KSC_DlPrice;
            
            parameters[40].Value = model.MTime;
            parameters[41].Value = model.CustomerValue;


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
        public void Delete(string ID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            DbHelperSQL.RunProcedure("Proc_KNet_Sales_ClientList_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_ClientList GetModel(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_Sales_ClientList model = new KNet.Model.KNet_Sales_ClientList();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_Sales_ClientList_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                if (ds.Tables[0].Rows[0]["RegisterYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["RegisterYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["RegisterYN"].ToString().ToLower() == "true"))
                    {
                        model.RegisterYN = true;
                    }
                    else
                    {
                        model.RegisterYN = false;
                    }
                }
                model.LoginID = ds.Tables[0].Rows[0]["LoginID"].ToString();
                model.LoginPassword = ds.Tables[0].Rows[0]["LoginPassword"].ToString();
                model.CustomerName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                model.CustomerValue = ds.Tables[0].Rows[0]["CustomerValue"].ToString();
                model.CustomerClass = ds.Tables[0].Rows[0]["CustomerClass"].ToString();
                model.CustomerTypes = ds.Tables[0].Rows[0]["CustomerTypes"].ToString();
                model.CustomerProvinces = ds.Tables[0].Rows[0]["CustomerProvinces"].ToString();
                model.CustomerCity = ds.Tables[0].Rows[0]["CustomerCity"].ToString();
                model.CustomerTrade = ds.Tables[0].Rows[0]["CustomerTrade"].ToString();
                model.CustomerSource = ds.Tables[0].Rows[0]["CustomerSource"].ToString();
                model.CustomerContact = ds.Tables[0].Rows[0]["CustomerContact"].ToString();
                model.CustomerContactSex = ds.Tables[0].Rows[0]["CustomerContactSex"].ToString();
                model.CustomerTel = ds.Tables[0].Rows[0]["CustomerTel"].ToString();
                model.CustomerMobile = ds.Tables[0].Rows[0]["CustomerMobile"].ToString();
                model.CustomerWebsite = ds.Tables[0].Rows[0]["CustomerWebsite"].ToString();
                model.CustomerEmail = ds.Tables[0].Rows[0]["CustomerEmail"].ToString();
                model.CustomerAddress = ds.Tables[0].Rows[0]["CustomerAddress"].ToString();
                model.CustomerZipCode = ds.Tables[0].Rows[0]["CustomerZipCode"].ToString();
                model.CustomerQQ = ds.Tables[0].Rows[0]["CustomerQQ"].ToString();
                model.CustomerMsn = ds.Tables[0].Rows[0]["CustomerMsn"].ToString();
                if (ds.Tables[0].Rows[0]["CustomerProtect"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["CustomerProtect"].ToString() == "1") || (ds.Tables[0].Rows[0]["CustomerProtect"].ToString().ToLower() == "true"))
                    {
                        model.CustomerProtect = true;
                    }
                    else
                    {
                        model.CustomerProtect = false;
                    }
                }
                model.CustomerIntroduction = ds.Tables[0].Rows[0]["CustomerIntroduction"].ToString();
                if (ds.Tables[0].Rows[0]["CustomerAddtime"].ToString() != "")
                {
                    model.CustomerAddtime = DateTime.Parse(ds.Tables[0].Rows[0]["CustomerAddtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerIntegral"].ToString() != "")
                {
                    model.CustomerIntegral = int.Parse(ds.Tables[0].Rows[0]["CustomerIntegral"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerIntegralUsed"].ToString() != "")
                {
                    model.CustomerIntegralUsed = int.Parse(ds.Tables[0].Rows[0]["CustomerIntegralUsed"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerMoney"].ToString() != "")
                {
                    model.CustomerMoney = decimal.Parse(ds.Tables[0].Rows[0]["CustomerMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerMoneyUsed"].ToString() != "")
                {
                    model.CustomerMoneyUsed = decimal.Parse(ds.Tables[0].Rows[0]["CustomerMoneyUsed"].ToString());
                }


                if (ds.Tables[0].Rows[0]["PlayCycleMoney"].ToString() != "")
                {
                    model.PlayCycleMoney = decimal.Parse(ds.Tables[0].Rows[0]["PlayCycleMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PlayCycleTime"].ToString() != "")
                {
                    model.PlayCycleTime = int.Parse(ds.Tables[0].Rows[0]["PlayCycleTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PlayCycleYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PlayCycleYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["PlayCycleYN"].ToString().ToLower() == "true"))
                    {
                        model.PlayCycleYN = true;
                    }
                    else
                    {
                        model.PlayCycleYN = false;
                    }
                }


                if (ds.Tables[0].Rows[0]["KSC_Auxiliary1"] != null && ds.Tables[0].Rows[0]["KSC_Auxiliary1"].ToString() != "")
                {
                    model.KSC_Auxiliary1 = ds.Tables[0].Rows[0]["KSC_Auxiliary1"].ToString();
                }
                else
                {
                    model.KSC_Auxiliary1 = "";
                }

                if (ds.Tables[0].Rows[0]["KSC_DutyPerson1"] != null && ds.Tables[0].Rows[0]["KSC_DutyPerson1"].ToString() != "")
                {
                    model.KSC_DutyPerson1 = ds.Tables[0].Rows[0]["KSC_DutyPerson1"].ToString();
                }
                else
                {
                    model.KSC_DutyPerson1 = "";
                }
                



                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_ClientList GetModelB(string CustomerValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from KNet_Sales_ClientList ");
            strSql.Append(" where CustomerValue=@CustomerValue ");
            SqlParameter[] parameters = {
					new SqlParameter("@CustomerValue", SqlDbType.NVarChar,50)};
            parameters[0].Value = CustomerValue;

            KNet.Model.KNet_Sales_ClientList model = new KNet.Model.KNet_Sales_ClientList();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RegisterYN"] != null && ds.Tables[0].Rows[0]["RegisterYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["RegisterYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["RegisterYN"].ToString().ToLower() == "true"))
                    {
                        model.RegisterYN = true;
                    }
                    else
                    {
                        model.RegisterYN = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["LoginID"] != null && ds.Tables[0].Rows[0]["LoginID"].ToString() != "")
                {
                    model.LoginID = ds.Tables[0].Rows[0]["LoginID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LoginPassword"] != null && ds.Tables[0].Rows[0]["LoginPassword"].ToString() != "")
                {
                    model.LoginPassword = ds.Tables[0].Rows[0]["LoginPassword"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerName"] != null && ds.Tables[0].Rows[0]["CustomerName"].ToString() != "")
                {
                    model.CustomerName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerValue"] != null && ds.Tables[0].Rows[0]["CustomerValue"].ToString() != "")
                {
                    model.CustomerValue = ds.Tables[0].Rows[0]["CustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerClass"] != null && ds.Tables[0].Rows[0]["CustomerClass"].ToString() != "")
                {
                    model.CustomerClass = ds.Tables[0].Rows[0]["CustomerClass"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerTypes"] != null && ds.Tables[0].Rows[0]["CustomerTypes"].ToString() != "")
                {
                    model.CustomerTypes = ds.Tables[0].Rows[0]["CustomerTypes"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerProvinces"] != null && ds.Tables[0].Rows[0]["CustomerProvinces"].ToString() != "")
                {
                    model.CustomerProvinces = ds.Tables[0].Rows[0]["CustomerProvinces"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerCity"] != null && ds.Tables[0].Rows[0]["CustomerCity"].ToString() != "")
                {
                    model.CustomerCity = ds.Tables[0].Rows[0]["CustomerCity"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerTrade"] != null && ds.Tables[0].Rows[0]["CustomerTrade"].ToString() != "")
                {
                    model.CustomerTrade = ds.Tables[0].Rows[0]["CustomerTrade"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerSource"] != null && ds.Tables[0].Rows[0]["CustomerSource"].ToString() != "")
                {
                    model.CustomerSource = ds.Tables[0].Rows[0]["CustomerSource"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerContact"] != null && ds.Tables[0].Rows[0]["CustomerContact"].ToString() != "")
                {
                    model.CustomerContact = ds.Tables[0].Rows[0]["CustomerContact"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerContactSex"] != null && ds.Tables[0].Rows[0]["CustomerContactSex"].ToString() != "")
                {
                    model.CustomerContactSex = ds.Tables[0].Rows[0]["CustomerContactSex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerTel"] != null && ds.Tables[0].Rows[0]["CustomerTel"].ToString() != "")
                {
                    model.CustomerTel = ds.Tables[0].Rows[0]["CustomerTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerMobile"] != null && ds.Tables[0].Rows[0]["CustomerMobile"].ToString() != "")
                {
                    model.CustomerMobile = ds.Tables[0].Rows[0]["CustomerMobile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerWebsite"] != null && ds.Tables[0].Rows[0]["CustomerWebsite"].ToString() != "")
                {
                    model.CustomerWebsite = ds.Tables[0].Rows[0]["CustomerWebsite"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerEmail"] != null && ds.Tables[0].Rows[0]["CustomerEmail"].ToString() != "")
                {
                    model.CustomerEmail = ds.Tables[0].Rows[0]["CustomerEmail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerAddress"] != null && ds.Tables[0].Rows[0]["CustomerAddress"].ToString() != "")
                {
                    model.CustomerAddress = ds.Tables[0].Rows[0]["CustomerAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerZipCode"] != null && ds.Tables[0].Rows[0]["CustomerZipCode"].ToString() != "")
                {
                    model.CustomerZipCode = ds.Tables[0].Rows[0]["CustomerZipCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerQQ"] != null && ds.Tables[0].Rows[0]["CustomerQQ"].ToString() != "")
                {
                    model.CustomerQQ = ds.Tables[0].Rows[0]["CustomerQQ"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerMsn"] != null && ds.Tables[0].Rows[0]["CustomerMsn"].ToString() != "")
                {
                    model.CustomerMsn = ds.Tables[0].Rows[0]["CustomerMsn"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerProtect"] != null && ds.Tables[0].Rows[0]["CustomerProtect"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["CustomerProtect"].ToString() == "1") || (ds.Tables[0].Rows[0]["CustomerProtect"].ToString().ToLower() == "true"))
                    {
                        model.CustomerProtect = true;
                    }
                    else
                    {
                        model.CustomerProtect = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["CustomerIntroduction"] != null && ds.Tables[0].Rows[0]["CustomerIntroduction"].ToString() != "")
                {
                    model.CustomerIntroduction = ds.Tables[0].Rows[0]["CustomerIntroduction"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerAddtime"] != null && ds.Tables[0].Rows[0]["CustomerAddtime"].ToString() != "")
                {
                    model.CustomerAddtime = DateTime.Parse(ds.Tables[0].Rows[0]["CustomerAddtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerIntegral"] != null && ds.Tables[0].Rows[0]["CustomerIntegral"].ToString() != "")
                {
                    model.CustomerIntegral = int.Parse(ds.Tables[0].Rows[0]["CustomerIntegral"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerIntegralUsed"] != null && ds.Tables[0].Rows[0]["CustomerIntegralUsed"].ToString() != "")
                {
                    model.CustomerIntegralUsed = int.Parse(ds.Tables[0].Rows[0]["CustomerIntegralUsed"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerMoney"] != null && ds.Tables[0].Rows[0]["CustomerMoney"].ToString() != "")
                {
                    model.CustomerMoney = decimal.Parse(ds.Tables[0].Rows[0]["CustomerMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerMoneyUsed"] != null && ds.Tables[0].Rows[0]["CustomerMoneyUsed"].ToString() != "")
                {
                    model.CustomerMoneyUsed = decimal.Parse(ds.Tables[0].Rows[0]["CustomerMoneyUsed"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PlayCycleMoney"] != null && ds.Tables[0].Rows[0]["PlayCycleMoney"].ToString() != "")
                {
                    model.PlayCycleMoney = decimal.Parse(ds.Tables[0].Rows[0]["PlayCycleMoney"].ToString());
                }



                if (ds.Tables[0].Rows[0]["PlayCycleTime"] != null && ds.Tables[0].Rows[0]["PlayCycleTime"].ToString() != "")
                {
                    model.PlayCycleTime = int.Parse(ds.Tables[0].Rows[0]["PlayCycleTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PlayCycleYN"] != null && ds.Tables[0].Rows[0]["PlayCycleYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PlayCycleYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["PlayCycleYN"].ToString().ToLower() == "true"))
                    {
                        model.PlayCycleYN = true;
                    }
                    else
                    {
                        model.PlayCycleYN = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["CustomerFax"] != null && ds.Tables[0].Rows[0]["CustomerFax"].ToString() != "")
                {
                    model.CustomerFax = ds.Tables[0].Rows[0]["CustomerFax"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LinkManID"] != null && ds.Tables[0].Rows[0]["LinkManID"].ToString() != "")
                {
                    model.LinkManID = ds.Tables[0].Rows[0]["LinkManID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FaterCode"] != null && ds.Tables[0].Rows[0]["FaterCode"].ToString() != "")
                {
                    model.FaterCode = ds.Tables[0].Rows[0]["FaterCode"].ToString();
                }

                if (ds.Tables[0].Rows[0]["CustomerCode"] != null && ds.Tables[0].Rows[0]["CustomerCode"].ToString() != "")
                {
                    model.CustomerCode = ds.Tables[0].Rows[0]["CustomerCode"].ToString();
                }

                if (ds.Tables[0].Rows[0]["OpeningBank"] != null && ds.Tables[0].Rows[0]["OpeningBank"].ToString() != "")
                {
                    model.OpeningBank = ds.Tables[0].Rows[0]["OpeningBank"].ToString();
                }
                else
                {
                    model.OpeningBank = "";
                }
                if (ds.Tables[0].Rows[0]["BankAccount"] != null && ds.Tables[0].Rows[0]["BankAccount"].ToString() != "")
                {
                    model.BankAccount = ds.Tables[0].Rows[0]["BankAccount"].ToString();
                }
                else 
                {
                    model.BankAccount = "";

                }
                if (ds.Tables[0].Rows[0]["RegistrationNum"] != null && ds.Tables[0].Rows[0]["RegistrationNum"].ToString() != "")
                {
                    model.RegistrationNum = ds.Tables[0].Rows[0]["RegistrationNum"].ToString();
                }
                else
                {
                    model.RegistrationNum = "";
                }

                if (ds.Tables[0].Rows[0]["KSC_Level"] != null && ds.Tables[0].Rows[0]["KSC_Level"].ToString() != "")
                {
                    model.KSC_Level = ds.Tables[0].Rows[0]["KSC_Level"].ToString();
                }
                else
                {
                    model.KSC_Level = "";
                }

                if (ds.Tables[0].Rows[0]["KSC_State"] != null && ds.Tables[0].Rows[0]["KSC_State"].ToString() != "")
                {
                    model.KSC_State = ds.Tables[0].Rows[0]["KSC_State"].ToString();
                }
                else
                {
                    model.KSC_State = "";
                }

                if (ds.Tables[0].Rows[0]["KSC_Type"] != null && ds.Tables[0].Rows[0]["KSC_Type"].ToString() != "")
                {
                    model.KSC_Type = ds.Tables[0].Rows[0]["KSC_Type"].ToString();
                }
                else
                {
                    model.KSC_Type = "";
                }

                if (ds.Tables[0].Rows[0]["KSC_DutyPerson"] != null && ds.Tables[0].Rows[0]["KSC_DutyPerson"].ToString() != "")
                {
                    model.KSC_DutyPerson = ds.Tables[0].Rows[0]["KSC_DutyPerson"].ToString();
                }
                else
                {
                    model.KSC_DutyPerson = "";
                }
                
                if (ds.Tables[0].Rows[0]["KSC_Creator"] != null && ds.Tables[0].Rows[0]["KSC_Creator"].ToString() != "")
                {
                    model.KSC_Creator = ds.Tables[0].Rows[0]["KSC_Creator"].ToString();
                }
                else
                {
                    model.KSC_Creator = "";
                }
                if (ds.Tables[0].Rows[0]["KSC_Auxiliary"] != null && ds.Tables[0].Rows[0]["KSC_Auxiliary"].ToString() != "")
                {
                    model.KSC_Auxiliary = ds.Tables[0].Rows[0]["KSC_Auxiliary"].ToString();
                }
                else
                {
                    model.KSC_Auxiliary = "";
                }

                if (ds.Tables[0].Rows[0]["KSC_SampleName"] != null && ds.Tables[0].Rows[0]["KSC_SampleName"].ToString() != "")
                {
                    model.KSC_SampleName = ds.Tables[0].Rows[0]["KSC_SampleName"].ToString();
                }
                else
                {
                    model.KSC_Auxiliary = "";
                }

                if (ds.Tables[0].Rows[0]["KSC_Auxiliary1"] != null && ds.Tables[0].Rows[0]["KSC_Auxiliary1"].ToString() != "")
                {
                    model.KSC_Auxiliary1 = ds.Tables[0].Rows[0]["KSC_Auxiliary1"].ToString();
                }
                else
                {
                    model.KSC_Auxiliary1 = "";
                }

                if (ds.Tables[0].Rows[0]["KSC_DutyPerson1"] != null && ds.Tables[0].Rows[0]["KSC_DutyPerson1"].ToString() != "")
                {
                    model.KSC_DutyPerson1 = ds.Tables[0].Rows[0]["KSC_DutyPerson1"].ToString();
                }
                else
                {
                    model.KSC_DutyPerson1 = "";
                }


                if (ds.Tables[0].Rows[0]["KSC_PayMent"] != null && ds.Tables[0].Rows[0]["KSC_PayMent"].ToString() != "")
                {
                    model.KSC_PayMent = ds.Tables[0].Rows[0]["KSC_PayMent"].ToString();
                }
                else
                {
                    model.KSC_PayMent = "";
                }

                if (ds.Tables[0].Rows[0]["KSC_KPType"] != null && ds.Tables[0].Rows[0]["KSC_KPType"].ToString() != "")
                {
                    model.KSC_KPType = ds.Tables[0].Rows[0]["KSC_KPType"].ToString();
                }
                else
                {
                    model.KSC_KPType = "";
                }

                if (ds.Tables[0].Rows[0]["KSC_DlPrice"] != null && ds.Tables[0].Rows[0]["KSC_DlPrice"].ToString() != "")
                {
                    model.KSC_DlPrice = decimal.Parse(ds.Tables[0].Rows[0]["KSC_DlPrice"].ToString());
                }
                
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_ClientList GetModelC(string LoginID, string LoginPassword)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,RegisterYN,LoginID,LoginPassword,CustomerName,CustomerValue,CustomerClass,CustomerTypes,CustomerProvinces,CustomerCity,CustomerTrade,CustomerSource,CustomerContact,CustomerContactSex,CustomerTel,CustomerMobile,CustomerWebsite,CustomerEmail,CustomerAddress,CustomerZipCode,CustomerQQ,CustomerMsn,CustomerProtect,CustomerIntroduction,CustomerAddtime,CustomerIntegral,CustomerIntegralUsed,CustomerMoney,CustomerMoneyUsed,PlayCycleMoney,PlayCycleTime,PlayCycleYN  from KNet_Sales_ClientList ");
            strSql.Append(" where LoginID=@LoginID and LoginPassword=@LoginPassword and RegisterYN=1 ");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginID", SqlDbType.NVarChar,50),
                    new SqlParameter("@LoginPassword", SqlDbType.NVarChar,50)};
            parameters[0].Value = LoginID;
            parameters[1].Value = LoginPassword;

            KNet.Model.KNet_Sales_ClientList model = new KNet.Model.KNet_Sales_ClientList();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                if (ds.Tables[0].Rows[0]["RegisterYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["RegisterYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["RegisterYN"].ToString().ToLower() == "true"))
                    {
                        model.RegisterYN = true;
                    }
                    else
                    {
                        model.RegisterYN = false;
                    }
                }
                model.LoginID = ds.Tables[0].Rows[0]["LoginID"].ToString();
                model.LoginPassword = ds.Tables[0].Rows[0]["LoginPassword"].ToString();
                model.CustomerName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                model.CustomerValue = ds.Tables[0].Rows[0]["CustomerValue"].ToString();
                model.CustomerClass = ds.Tables[0].Rows[0]["CustomerClass"].ToString();
                model.CustomerTypes = ds.Tables[0].Rows[0]["CustomerTypes"].ToString();
                model.CustomerProvinces = ds.Tables[0].Rows[0]["CustomerProvinces"].ToString();
                model.CustomerCity = ds.Tables[0].Rows[0]["CustomerCity"].ToString();
                model.CustomerTrade = ds.Tables[0].Rows[0]["CustomerTrade"].ToString();
                model.CustomerSource = ds.Tables[0].Rows[0]["CustomerSource"].ToString();
                model.CustomerContact = ds.Tables[0].Rows[0]["CustomerContact"].ToString();
                model.CustomerContactSex = ds.Tables[0].Rows[0]["CustomerContactSex"].ToString();
                model.CustomerTel = ds.Tables[0].Rows[0]["CustomerTel"].ToString();
                model.CustomerMobile = ds.Tables[0].Rows[0]["CustomerMobile"].ToString();
                model.CustomerWebsite = ds.Tables[0].Rows[0]["CustomerWebsite"].ToString();
                model.CustomerEmail = ds.Tables[0].Rows[0]["CustomerEmail"].ToString();
                model.CustomerAddress = ds.Tables[0].Rows[0]["CustomerAddress"].ToString();
                model.CustomerZipCode = ds.Tables[0].Rows[0]["CustomerZipCode"].ToString();
                model.CustomerQQ = ds.Tables[0].Rows[0]["CustomerQQ"].ToString();
                model.CustomerMsn = ds.Tables[0].Rows[0]["CustomerMsn"].ToString();
                if (ds.Tables[0].Rows[0]["CustomerProtect"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["CustomerProtect"].ToString() == "1") || (ds.Tables[0].Rows[0]["CustomerProtect"].ToString().ToLower() == "true"))
                    {
                        model.CustomerProtect = true;
                    }
                    else
                    {
                        model.CustomerProtect = false;
                    }
                }
                model.CustomerIntroduction = ds.Tables[0].Rows[0]["CustomerIntroduction"].ToString();
                if (ds.Tables[0].Rows[0]["CustomerAddtime"].ToString() != "")
                {
                    model.CustomerAddtime = DateTime.Parse(ds.Tables[0].Rows[0]["CustomerAddtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerIntegral"].ToString() != "")
                {
                    model.CustomerIntegral = int.Parse(ds.Tables[0].Rows[0]["CustomerIntegral"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerIntegralUsed"].ToString() != "")
                {
                    model.CustomerIntegralUsed = int.Parse(ds.Tables[0].Rows[0]["CustomerIntegralUsed"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerMoney"].ToString() != "")
                {
                    model.CustomerMoney = decimal.Parse(ds.Tables[0].Rows[0]["CustomerMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CustomerMoneyUsed"].ToString() != "")
                {
                    model.CustomerMoneyUsed = decimal.Parse(ds.Tables[0].Rows[0]["CustomerMoneyUsed"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PlayCycleMoney"].ToString() != "")
                {
                    model.PlayCycleMoney = decimal.Parse(ds.Tables[0].Rows[0]["PlayCycleMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PlayCycleTime"].ToString() != "")
                {
                    model.PlayCycleTime = int.Parse(ds.Tables[0].Rows[0]["PlayCycleTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PlayCycleYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PlayCycleYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["PlayCycleYN"].ToString().ToLower() == "true"))
                    {
                        model.PlayCycleYN = true;
                    }
                    else
                    {
                        model.PlayCycleYN = false;
                    }
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
            strSql.Append("select *,isnull((Select Sum(Money) from v_Receive_Real a where a.customervalue=KNet_Sales_ClientList.customervalue),0) as receivemoney");
            strSql.Append(" FROM KNet_Sales_ClientList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  成员方法
    }
}


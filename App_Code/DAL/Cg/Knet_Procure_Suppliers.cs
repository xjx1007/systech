using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类Knet_Procure_Suppliers。
    /// </summary>
    public class Knet_Procure_Suppliers
    {
        public Knet_Procure_Suppliers()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SuppName, string SuppProvince)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
                    new SqlParameter("@SuppName", SqlDbType.NVarChar,50),
                    new SqlParameter("@SuppProvince", SqlDbType.NVarChar,50)};
            parameters[0].Value = SuppName;
            parameters[1].Value = SuppProvince;

            int result = DbHelperSQL.RunProcedure("Proc_Knet_Procure_Suppliers_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.Knet_Procure_Suppliers model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Knet_Procure_Suppliers(");
            strSql.Append("SuppNo,SuppName,SuppPeople,SuppMobiTel,SuppFax,SuppPhone,SuppWeb,SuppEmail,SuppProvince,SuppCity,SuppAddress,SuppZipCode,SuppBankName,SuppBankAccount,SuppProducts,Remarks,SuppCode,KPS_DutyPerson,KPS_Level,KPS_Type,KPS_CTime,KPS_Creator,KPS_LinkManID,KPS_Sname,KPS_Code,KPS_Days,KPS_KDCode,KPS_ScNumber,KPS_KPMaxMoney,KPS_MaxRow,KPS_GiveDays,KPS_Nature,KPS_BusinessUrl,KPS_Business,KPS_InvoiceUrl,KPS_Invoice,KPS_ContractUrl,KPS_Contract,KPS_FiveUrl,KPS_FiveName,KSP_SQEUrl,KPS_SQEName,KPS_Production,KPS_ProductionPho,KPS_WareHouse,KPS_WareHousePho,KPS_CdBankName,KPS_CdBankNum,KPS_Check,KPS_Del)");
            strSql.Append(" values (");
            strSql.Append("@SuppNo,@SuppName,@SuppPeople,@SuppMobiTel,@SuppFax,@SuppPhone,@SuppWeb,@SuppEmail,@SuppProvince,@SuppCity,@SuppAddress,@SuppZipCode,@SuppBankName,@SuppBankAccount,@SuppProducts,@Remarks,@SuppCode,@KPS_DutyPerson,@KPS_Level,@KPS_Type,@KPS_CTime,@KPS_Creator,@KPS_LinkManID,@KPS_Sname,@KPS_Code,@KPS_Days,@KPS_KDCode,@KPS_ScNumber,@KPS_KPMaxMoney,@KPS_MaxRow,@KPS_GiveDays,@KPS_Nature,@KPS_BusinessUrl,@KPS_Business,@KPS_InvoiceUrl,@KPS_Invoice,@KPS_ContractUrl,@KPS_Contract,@KPS_FiveUrl,@KPS_FiveName,@KSP_SQEUrl,@KPS_SQEName,@KPS_Production,@KPS_ProductionPho,@KPS_WareHouse,@KPS_WareHousePho,@KPS_CdBankName,@KPS_CdBankNum,@KPS_Check,@KPS_Del)");
            SqlParameter[] parameters = {
                    new SqlParameter("@SuppNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@SuppName", SqlDbType.NVarChar,60),
                    new SqlParameter("@SuppPeople", SqlDbType.NVarChar,50),
                    new SqlParameter("@SuppMobiTel", SqlDbType.NVarChar,30),
                    new SqlParameter("@SuppFax", SqlDbType.NVarChar,30),
                    new SqlParameter("@SuppPhone", SqlDbType.NVarChar,30),
                    new SqlParameter("@SuppWeb", SqlDbType.NVarChar,100),
                    new SqlParameter("@SuppEmail", SqlDbType.NVarChar,60),
                    new SqlParameter("@SuppProvince", SqlDbType.NVarChar,20),
                    new SqlParameter("@SuppCity", SqlDbType.NVarChar,20),
                    new SqlParameter("@SuppAddress", SqlDbType.NVarChar,100),
                    new SqlParameter("@SuppZipCode", SqlDbType.NVarChar,10),
                    new SqlParameter("@SuppBankName", SqlDbType.NVarChar,50),
                    new SqlParameter("@SuppBankAccount", SqlDbType.NVarChar,50),
                    new SqlParameter("@SuppProducts", SqlDbType.NVarChar,500),
                    new SqlParameter("@Remarks", SqlDbType.NText),
                    new SqlParameter("@SuppCode", SqlDbType.VarChar,50),
                    new SqlParameter("@KPS_DutyPerson", SqlDbType.VarChar,50),
                    new SqlParameter("@KPS_Level", SqlDbType.VarChar,50),
                    new SqlParameter("@KPS_Type", SqlDbType.VarChar,50),
                    new SqlParameter("@KPS_CTime", SqlDbType.DateTime),
                    new SqlParameter("@KPS_Creator", SqlDbType.VarChar,50),
                    new SqlParameter("@KPS_LinkManID", SqlDbType.VarChar,50),
                    new SqlParameter("@KPS_Sname", SqlDbType.VarChar,50),
                    new SqlParameter("@KPS_Code", SqlDbType.VarChar,50),
                    new SqlParameter("@KPS_Days", SqlDbType.Int,4),
                    new SqlParameter("@KPS_KDCode", SqlDbType.VarChar,50),
                    new SqlParameter("@KPS_ScNumber", SqlDbType.Int,4),
                    new SqlParameter("@KPS_KPMaxMoney", SqlDbType.Decimal,18),
                    new SqlParameter("@KPS_MaxRow", SqlDbType.Int,4),
                    new SqlParameter("@KPS_GiveDays", SqlDbType.Int,4),
                    new SqlParameter("@KPS_Nature", SqlDbType.Int,4),
                     new SqlParameter("@KPS_BusinessUrl", SqlDbType.VarChar,200),
                     new SqlParameter("@KPS_Business", SqlDbType.VarChar,200),
                     new SqlParameter("@KPS_InvoiceUrl", SqlDbType.VarChar,200),
                     new SqlParameter("@KPS_Invoice", SqlDbType.VarChar,200),
                     new SqlParameter("@KPS_ContractUrl", SqlDbType.VarChar,200),
                     new SqlParameter("@KPS_Contract", SqlDbType.VarChar,200),
                      new SqlParameter("@KPS_FiveUrl", SqlDbType.VarChar,200),
                     new SqlParameter("@KPS_FiveName", SqlDbType.VarChar,200),
                      new SqlParameter("@KSP_SQEUrl", SqlDbType.VarChar,200),
                     new SqlParameter("@KPS_SQEName", SqlDbType.VarChar,200),
                     new SqlParameter("@KPS_Production", SqlDbType.VarChar,50),
                     new SqlParameter("@KPS_ProductionPho", SqlDbType.VarChar,50),
                     new SqlParameter("@KPS_WareHouse", SqlDbType.VarChar,50),
                     new SqlParameter("@KPS_WareHousePho", SqlDbType.VarChar,50),
                      new SqlParameter("@KPS_CdBankName", SqlDbType.VarChar,100),
                     new SqlParameter("@KPS_CdBankNum", SqlDbType.VarChar,200),
                      new SqlParameter("@KPS_Check", SqlDbType.VarChar,10),
                       new SqlParameter("@KPS_Del", SqlDbType.Int)

        };
            parameters[0].Value = model.SuppNo;
            parameters[1].Value = model.SuppName;
            parameters[2].Value = model.SuppPeople;
            parameters[3].Value = model.SuppMobiTel;
            parameters[4].Value = model.SuppFax;
            parameters[5].Value = model.SuppPhone;
            parameters[6].Value = model.SuppWeb;
            parameters[7].Value = model.SuppEmail;
            parameters[8].Value = model.SuppProvince;
            parameters[9].Value = model.SuppCity;
            parameters[10].Value = model.SuppAddress;
            parameters[11].Value = model.SuppZipCode;
            parameters[12].Value = model.SuppBankName;
            parameters[13].Value = model.SuppBankAccount;
            parameters[14].Value = model.SuppProducts;
            parameters[15].Value = model.Remarks;
            parameters[16].Value = model.SuppCode;
            parameters[17].Value = model.KPS_DutyPerson;
            parameters[18].Value = model.KPS_Level;
            parameters[19].Value = model.KPS_Type;
            parameters[20].Value = model.KPS_CTime;
            parameters[21].Value = model.KPS_Creator;
            parameters[22].Value = model.KPS_LinkManID;
            parameters[23].Value = model.KPS_Sname;
            parameters[24].Value = model.KPS_Code;
            parameters[25].Value = model.KPS_Days;
            parameters[26].Value = model.KPS_KDCode;
            parameters[27].Value = model.KPS_ScNumber;
            parameters[28].Value = model.KPS_KPMaxMoney;
            parameters[29].Value = model.KPS_MaxRow;
            parameters[30].Value = model.KPS_GiveDays;
            parameters[31].Value = model.KPS_Nature;
            parameters[32].Value = model.KPS_BusinessUrl;
            parameters[33].Value = model.KPS_Business;
            parameters[34].Value = model.KPS_InvoiceUrl;
            parameters[35].Value = model.KPS_Invoice;
            parameters[36].Value = model.KPS_ContractUrl;
            parameters[37].Value = model.KPS_Contract;

            parameters[38].Value = model.KPS_FiveUrl;
            parameters[39].Value = model.KPS_FiveName;
            parameters[40].Value = model.KSP_SQEUrl;
            parameters[41].Value = model.KPS_SQEName;

            parameters[42].Value = model.KPS_Production;
            parameters[43].Value = model.KPS_ProductionPho;
            parameters[44].Value = model.KPS_WareHouse;
            parameters[45].Value = model.KPS_WareHousePho;
            parameters[46].Value = model.KPS_CdBankName;
            parameters[47].Value = model.KPS_CdBankNum;
            parameters[48].Value = model.KPS_Check;
            parameters[49].Value = model.KPS_Del;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.Knet_Procure_Suppliers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Knet_Procure_Suppliers set ");
            strSql.Append("SuppNo=@SuppNo,");
            strSql.Append("SuppName=@SuppName,");
            strSql.Append("SuppPeople=@SuppPeople,");
            strSql.Append("SuppMobiTel=@SuppMobiTel,");
            strSql.Append("SuppFax=@SuppFax,");
            strSql.Append("SuppPhone=@SuppPhone,");
            strSql.Append("SuppWeb=@SuppWeb,");
            strSql.Append("SuppEmail=@SuppEmail,");
            strSql.Append("SuppProvince=@SuppProvince,");
            strSql.Append("SuppCity=@SuppCity,");
            strSql.Append("SuppAddress=@SuppAddress,");
            strSql.Append("SuppZipCode=@SuppZipCode,");
            strSql.Append("SuppBankName=@SuppBankName,");
            strSql.Append("SuppBankAccount=@SuppBankAccount,");
            strSql.Append("SuppProducts=@SuppProducts,");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("SuppCode=@SuppCode,");
            strSql.Append("KPS_DutyPerson=@KPS_DutyPerson,");
            strSql.Append("KPS_Level=@KPS_Level,");
            strSql.Append("KPS_Type=@KPS_Type,");
            strSql.Append("KPS_MTime=@KPS_MTime,");
            strSql.Append("KPS_Mender=@KPS_Mender, ");
            strSql.Append("KPS_LinkManID=@KPS_LinkManID, ");
            strSql.Append("KPS_Sname=@KPS_Sname,");
            strSql.Append("KPS_Code=@KPS_Code, ");
            strSql.Append("KPS_Days=@KPS_Days, ");
            strSql.Append("KPS_KDCode=@KPS_KDCode, ");
            strSql.Append("KPS_ScNumber=@KPS_ScNumber, ");
            strSql.Append("KPS_KPMaxMoney=@KPS_KPMaxMoney,");
            strSql.Append("KPS_MaxRow=@KPS_MaxRow, ");
            strSql.Append("KPS_GiveDays=@KPS_GiveDays, ");
            strSql.Append("KPS_Nature=@KPS_Nature, ");
            strSql.Append("KPS_BusinessUrl=@KPS_BusinessUrl,");
            strSql.Append("KPS_Business=@KPS_Business,");
            strSql.Append("KPS_InvoiceUrl=@KPS_InvoiceUrl,");
            strSql.Append("KPS_Invoice=@KPS_Invoice,");
            strSql.Append("KPS_ContractUrl=@KPS_ContractUrl,");
            strSql.Append("KPS_Contract=@KPS_Contract,");

            strSql.Append("KPS_FiveUrl=@KPS_FiveUrl,");
            strSql.Append("KPS_FiveName=@KPS_FiveName,");
            strSql.Append("KSP_SQEUrl=@KSP_SQEUrl,");
            strSql.Append("KPS_SQEName=@KPS_SQEName,");

            strSql.Append("KPS_Production=@KPS_Production,");
            strSql.Append("KPS_ProductionPho=@KPS_ProductionPho,");
            strSql.Append("KPS_WareHouse=@KPS_WareHouse,");
            strSql.Append("KPS_WareHousePho=@KPS_WareHousePho,");
            strSql.Append("KPS_CdBankName=@KPS_CdBankName,");
            strSql.Append("KPS_CdBankNum=@KPS_CdBankNum,");
            strSql.Append("KPS_Del=@KPS_Del,");
            strSql.Append("KPS_Check=@KPS_Check");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@SuppNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@SuppName", SqlDbType.NVarChar,60),
                    new SqlParameter("@SuppPeople", SqlDbType.NVarChar,50),
                    new SqlParameter("@SuppMobiTel", SqlDbType.NVarChar,30),
                    new SqlParameter("@SuppFax", SqlDbType.NVarChar,30),
                    new SqlParameter("@SuppPhone", SqlDbType.NVarChar,30),
                    new SqlParameter("@SuppWeb", SqlDbType.NVarChar,100),
                    new SqlParameter("@SuppEmail", SqlDbType.NVarChar,60),
                    new SqlParameter("@SuppProvince", SqlDbType.NVarChar,20),
                    new SqlParameter("@SuppCity", SqlDbType.NVarChar,20),
                    new SqlParameter("@SuppAddress", SqlDbType.NVarChar,100),
                    new SqlParameter("@SuppZipCode", SqlDbType.NVarChar,10),
                    new SqlParameter("@SuppBankName", SqlDbType.NVarChar,50),
                    new SqlParameter("@SuppBankAccount", SqlDbType.NVarChar,50),
                    new SqlParameter("@SuppProducts", SqlDbType.NVarChar,500),
                    new SqlParameter("@Remarks", SqlDbType.NText),
                    new SqlParameter("@SuppCode", SqlDbType.VarChar,50),
                    new SqlParameter("@KPS_DutyPerson", SqlDbType.VarChar,50),
                    new SqlParameter("@KPS_Level", SqlDbType.VarChar,50),
                    new SqlParameter("@KPS_Type", SqlDbType.VarChar,50),
                    new SqlParameter("@KPS_MTime", SqlDbType.DateTime),
                    new SqlParameter("@KPS_Mender", SqlDbType.VarChar,50),
                    new SqlParameter("@KPS_LinkManID", SqlDbType.VarChar,50),
                    new SqlParameter("@KPS_Sname", SqlDbType.VarChar,50),
                    new SqlParameter("@KPS_Code", SqlDbType.VarChar,50),
                    new SqlParameter("@KPS_Days", SqlDbType.Int,4),
                    new SqlParameter("@KPS_KDCode", SqlDbType.VarChar,50),
                    new SqlParameter("@KPS_ScNumber", SqlDbType.Int,4),
                    new SqlParameter("@KPS_KPMaxMoney", SqlDbType.Decimal,18),
                    new SqlParameter("@KPS_MaxRow", SqlDbType.Int,4),
                    new SqlParameter("@KPS_GiveDays", SqlDbType.Int,4),

                    new SqlParameter("@KPS_Nature", SqlDbType.Int,4),

                     new SqlParameter("@KPS_BusinessUrl", SqlDbType.VarChar,200),
                     new SqlParameter("@KPS_Business", SqlDbType.VarChar,100),
                     new SqlParameter("@KPS_InvoiceUrl", SqlDbType.VarChar,200),
                     new SqlParameter("@KPS_Invoice", SqlDbType.VarChar,100),
                     new SqlParameter("@KPS_ContractUrl", SqlDbType.VarChar,200),
                     new SqlParameter("@KPS_Contract", SqlDbType.VarChar,100),

                       new SqlParameter("@KPS_FiveUrl", SqlDbType.VarChar,200),
                     new SqlParameter("@KPS_FiveName", SqlDbType.VarChar,100),
                       new SqlParameter("@KSP_SQEUrl", SqlDbType.VarChar,200),
                     new SqlParameter("@KPS_SQEName", SqlDbType.VarChar,100),

                     new SqlParameter("@KPS_Production", SqlDbType.VarChar,50),
                     new SqlParameter("@KPS_ProductionPho", SqlDbType.VarChar,50),
                     new SqlParameter("@KPS_WareHouse", SqlDbType.VarChar,50),
                     new SqlParameter("@KPS_WareHousePho", SqlDbType.VarChar,50),
                     new SqlParameter("@KPS_CdBankName", SqlDbType.VarChar,50),
                     new SqlParameter("@KPS_CdBankNum", SqlDbType.VarChar,50),
                      new SqlParameter("@KPS_Del", SqlDbType.Int),
                     new SqlParameter("@KPS_Check", SqlDbType.VarChar,10),

                    new SqlParameter("@ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SuppNo;
            parameters[1].Value = model.SuppName;
            parameters[2].Value = model.SuppPeople;
            parameters[3].Value = model.SuppMobiTel;
            parameters[4].Value = model.SuppFax;
            parameters[5].Value = model.SuppPhone;
            parameters[6].Value = model.SuppWeb;
            parameters[7].Value = model.SuppEmail;
            parameters[8].Value = model.SuppProvince;
            parameters[9].Value = model.SuppCity;
            parameters[10].Value = model.SuppAddress;
            parameters[11].Value = model.SuppZipCode;
            parameters[12].Value = model.SuppBankName;
            parameters[13].Value = model.SuppBankAccount;
            parameters[14].Value = model.SuppProducts;
            parameters[15].Value = model.Remarks;
            parameters[16].Value = model.SuppCode;
            parameters[17].Value = model.KPS_DutyPerson;
            parameters[18].Value = model.KPS_Level;
            parameters[19].Value = model.KPS_Type;
            parameters[20].Value = model.KPS_MTime;
            parameters[21].Value = model.KPS_Mender;
            parameters[22].Value = model.KPS_LinkManID;
            parameters[23].Value = model.KPS_Sname;
            parameters[24].Value = model.KPS_Code;
            parameters[25].Value = model.KPS_Days;
            parameters[26].Value = model.KPS_KDCode;
            parameters[27].Value = model.KPS_ScNumber;

            parameters[28].Value = model.KPS_KPMaxMoney;

            parameters[29].Value = model.KPS_MaxRow;
            parameters[30].Value = model.KPS_GiveDays;

            parameters[31].Value = model.KPS_Nature;


            parameters[32].Value = model.KPS_BusinessUrl;
            parameters[33].Value = model.KPS_Business;
            parameters[34].Value = model.KPS_InvoiceUrl;
            parameters[35].Value = model.KPS_Invoice;
            parameters[36].Value = model.KPS_ContractUrl;
            parameters[37].Value = model.KPS_Contract;

            parameters[38].Value = model.KPS_FiveUrl;
            parameters[39].Value = model.KPS_FiveName;
            parameters[40].Value = model.KSP_SQEUrl;
            parameters[41].Value = model.KPS_SQEName;

            parameters[42].Value = model.KPS_Production;
            parameters[43].Value = model.KPS_ProductionPho;
            parameters[44].Value = model.KPS_WareHouse;
            parameters[45].Value = model.KPS_WareHousePho;
            parameters[46].Value = model.KPS_CdBankName;
            parameters[47].Value = model.KPS_CdBankNum;
            parameters[48].Value = model.KPS_Check;
            parameters[49].Value = 1;
            parameters[50].Value = model.ID;
            //strSql;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// </summary>
        public void UpdateDel(KNet.Model.Knet_Procure_Suppliers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Knet_Procure_Suppliers set ");
            strSql.Append("KPS_Del=@KPS_Del ");

            strSql.Append(" where SuppNo=@SuppNo ");
            SqlParameter[] parameters = {
                    new SqlParameter("@KPS_Del", SqlDbType.Int,4),
                    new SqlParameter("@SuppNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.KPS_Del;
            parameters[1].Value = model.SuppNo;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string SuppNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
                    new SqlParameter("@SuppNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = SuppNo;

            DbHelperSQL.RunProcedure("Proc_Knet_Procure_Suppliers_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_Suppliers GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Knet_Procure_Suppliers ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.Knet_Procure_Suppliers model = new KNet.Model.Knet_Procure_Suppliers();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppNo"] != null && ds.Tables[0].Rows[0]["SuppNo"].ToString() != "")
                {
                    model.SuppNo = ds.Tables[0].Rows[0]["SuppNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppName"] != null && ds.Tables[0].Rows[0]["SuppName"].ToString() != "")
                {
                    model.SuppName = ds.Tables[0].Rows[0]["SuppName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppPeople"] != null && ds.Tables[0].Rows[0]["SuppPeople"].ToString() != "")
                {
                    model.SuppPeople = ds.Tables[0].Rows[0]["SuppPeople"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppMobiTel"] != null && ds.Tables[0].Rows[0]["SuppMobiTel"].ToString() != "")
                {
                    model.SuppMobiTel = ds.Tables[0].Rows[0]["SuppMobiTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppFax"] != null && ds.Tables[0].Rows[0]["SuppFax"].ToString() != "")
                {
                    model.SuppFax = ds.Tables[0].Rows[0]["SuppFax"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppPhone"] != null && ds.Tables[0].Rows[0]["SuppPhone"].ToString() != "")
                {
                    model.SuppPhone = ds.Tables[0].Rows[0]["SuppPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppWeb"] != null && ds.Tables[0].Rows[0]["SuppWeb"].ToString() != "")
                {
                    model.SuppWeb = ds.Tables[0].Rows[0]["SuppWeb"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppEmail"] != null && ds.Tables[0].Rows[0]["SuppEmail"].ToString() != "")
                {
                    model.SuppEmail = ds.Tables[0].Rows[0]["SuppEmail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppProvince"] != null && ds.Tables[0].Rows[0]["SuppProvince"].ToString() != "")
                {
                    model.SuppProvince = ds.Tables[0].Rows[0]["SuppProvince"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppCity"] != null && ds.Tables[0].Rows[0]["SuppCity"].ToString() != "")
                {
                    model.SuppCity = ds.Tables[0].Rows[0]["SuppCity"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppAddress"] != null && ds.Tables[0].Rows[0]["SuppAddress"].ToString() != "")
                {
                    model.SuppAddress = ds.Tables[0].Rows[0]["SuppAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppZipCode"] != null && ds.Tables[0].Rows[0]["SuppZipCode"].ToString() != "")
                {
                    model.SuppZipCode = ds.Tables[0].Rows[0]["SuppZipCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppBankName"] != null && ds.Tables[0].Rows[0]["SuppBankName"].ToString() != "")
                {
                    model.SuppBankName = ds.Tables[0].Rows[0]["SuppBankName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppBankAccount"] != null && ds.Tables[0].Rows[0]["SuppBankAccount"].ToString() != "")
                {
                    model.SuppBankAccount = ds.Tables[0].Rows[0]["SuppBankAccount"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppProducts"] != null && ds.Tables[0].Rows[0]["SuppProducts"].ToString() != "")
                {
                    model.SuppProducts = ds.Tables[0].Rows[0]["SuppProducts"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remarks"] != null && ds.Tables[0].Rows[0]["Remarks"].ToString() != "")
                {
                    model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppCode"] != null && ds.Tables[0].Rows[0]["SuppCode"].ToString() != "")
                {
                    model.SuppCode = ds.Tables[0].Rows[0]["SuppCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_DutyPerson"] != null && ds.Tables[0].Rows[0]["KPS_DutyPerson"].ToString() != "")
                {
                    model.KPS_DutyPerson = ds.Tables[0].Rows[0]["KPS_DutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_Level"] != null && ds.Tables[0].Rows[0]["KPS_Level"].ToString() != "")
                {
                    model.KPS_Level = ds.Tables[0].Rows[0]["KPS_Level"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_Type"] != null && ds.Tables[0].Rows[0]["KPS_Type"].ToString() != "")
                {
                    model.KPS_Type = ds.Tables[0].Rows[0]["KPS_Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_CTime"] != null && ds.Tables[0].Rows[0]["KPS_CTime"].ToString() != "")
                {
                    model.KPS_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["KPS_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KPS_Creator"] != null && ds.Tables[0].Rows[0]["KPS_Creator"].ToString() != "")
                {
                    model.KPS_Creator = ds.Tables[0].Rows[0]["KPS_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_MTime"] != null && ds.Tables[0].Rows[0]["KPS_MTime"].ToString() != "")
                {
                    model.KPS_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["KPS_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KPS_Mender"] != null && ds.Tables[0].Rows[0]["KPS_Mender"].ToString() != "")
                {
                    model.KPS_Mender = ds.Tables[0].Rows[0]["KPS_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_Del"] != null && ds.Tables[0].Rows[0]["KPS_Del"].ToString() != "")
                {
                    model.KPS_Del = int.Parse(ds.Tables[0].Rows[0]["KPS_Del"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KPS_LinkManID"] != null && ds.Tables[0].Rows[0]["KPS_LinkManID"].ToString() != "")
                {
                    model.KPS_LinkManID = ds.Tables[0].Rows[0]["KPS_LinkManID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_Sname"] != null && ds.Tables[0].Rows[0]["KPS_Sname"].ToString() != "")
                {
                    model.KPS_Sname = ds.Tables[0].Rows[0]["KPS_Sname"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_Code"] != null && ds.Tables[0].Rows[0]["KPS_Code"].ToString() != "")
                {
                    model.KPS_Code = ds.Tables[0].Rows[0]["KPS_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_Days"] != null && ds.Tables[0].Rows[0]["KPS_Days"].ToString() != "")
                {
                    model.KPS_Days = int.Parse(ds.Tables[0].Rows[0]["KPS_Days"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KPS_KDCode"] != null && ds.Tables[0].Rows[0]["KPS_KDCode"].ToString() != "")
                {
                    model.KPS_KDCode = ds.Tables[0].Rows[0]["KPS_KDCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_ScNumber"] != null && ds.Tables[0].Rows[0]["KPS_ScNumber"].ToString() != "")
                {
                    model.KPS_ScNumber = int.Parse(ds.Tables[0].Rows[0]["KPS_ScNumber"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KPS_KPMaxMoney"] != null && ds.Tables[0].Rows[0]["KPS_KPMaxMoney"].ToString() != "")
                {
                    model.KPS_KPMaxMoney = decimal.Parse(ds.Tables[0].Rows[0]["KPS_KPMaxMoney"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KPS_MaxRow"] != null && ds.Tables[0].Rows[0]["KPS_MaxRow"].ToString() != "")
                {
                    model.KPS_MaxRow = int.Parse(ds.Tables[0].Rows[0]["KPS_MaxRow"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KPS_GiveDays"] != null && ds.Tables[0].Rows[0]["KPS_GiveDays"].ToString() != "")
                {
                    model.KPS_GiveDays = int.Parse(ds.Tables[0].Rows[0]["KPS_GiveDays"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KPS_Nature"] != null && ds.Tables[0].Rows[0]["KPS_Nature"].ToString() != "")
                {
                    model.KPS_Nature = int.Parse(ds.Tables[0].Rows[0]["KPS_Nature"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KPS_BusinessUrl"] != null && ds.Tables[0].Rows[0]["KPS_BusinessUrl"].ToString() != "")
                {
                    model.KPS_BusinessUrl = ds.Tables[0].Rows[0]["KPS_BusinessUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_Business"] != null && ds.Tables[0].Rows[0]["KPS_Business"].ToString() != "")
                {
                    model.KPS_Business = ds.Tables[0].Rows[0]["KPS_Business"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_InvoiceUrl"] != null && ds.Tables[0].Rows[0]["KPS_InvoiceUrl"].ToString() != "")
                {
                    model.KPS_InvoiceUrl = ds.Tables[0].Rows[0]["KPS_InvoiceUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_Invoice"] != null && ds.Tables[0].Rows[0]["KPS_Invoice"].ToString() != "")
                {
                    model.KPS_Invoice = ds.Tables[0].Rows[0]["KPS_Invoice"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_ContractUrl"] != null && ds.Tables[0].Rows[0]["KPS_ContractUrl"].ToString() != "")
                {
                    model.KPS_ContractUrl = ds.Tables[0].Rows[0]["KPS_ContractUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_Contract"] != null && ds.Tables[0].Rows[0]["KPS_Contract"].ToString() != "")
                {
                    model.KPS_Contract = ds.Tables[0].Rows[0]["KPS_Contract"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KPS_FiveUrl"] != null && ds.Tables[0].Rows[0]["KPS_FiveUrl"].ToString() != "")
                {
                    model.KPS_FiveUrl = ds.Tables[0].Rows[0]["KPS_FiveUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_FiveName"] != null && ds.Tables[0].Rows[0]["KPS_FiveName"].ToString() != "")
                {
                    model.KPS_FiveName = ds.Tables[0].Rows[0]["KPS_FiveName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSP_SQEUrl"] != null && ds.Tables[0].Rows[0]["KSP_SQEUrl"].ToString() != "")
                {
                    model.KSP_SQEUrl = ds.Tables[0].Rows[0]["KSP_SQEUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_SQEName"] != null && ds.Tables[0].Rows[0]["KPS_SQEName"].ToString() != "")
                {
                    model.KPS_SQEName = ds.Tables[0].Rows[0]["KPS_SQEName"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KPS_Production"] != null && ds.Tables[0].Rows[0]["KPS_Production"].ToString() != "")
                {
                    model.KPS_Production = ds.Tables[0].Rows[0]["KPS_Production"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_ProductionPho"] != null && ds.Tables[0].Rows[0]["KPS_ProductionPho"].ToString() != "")
                {
                    model.KPS_ProductionPho = ds.Tables[0].Rows[0]["KPS_ProductionPho"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_WareHouse"] != null && ds.Tables[0].Rows[0]["KPS_WareHouse"].ToString() != "")
                {
                    model.KPS_WareHouse = ds.Tables[0].Rows[0]["KPS_WareHouse"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_WareHousePho"] != null && ds.Tables[0].Rows[0]["KPS_WareHousePho"].ToString() != "")
                {
                    model.KPS_WareHousePho = ds.Tables[0].Rows[0]["KPS_WareHousePho"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_CdBankName"] != null && ds.Tables[0].Rows[0]["KPS_CdBankName"].ToString() != "")
                {
                    model.KPS_CdBankName = ds.Tables[0].Rows[0]["KPS_CdBankName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_CdBankNum"] != null && ds.Tables[0].Rows[0]["KPS_CdBankNum"].ToString() != "")
                {
                    model.KPS_CdBankNum = ds.Tables[0].Rows[0]["KPS_CdBankNum"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_Check"] != null && ds.Tables[0].Rows[0]["KPS_Check"].ToString() != "")
                {
                    model.KPS_Check = ds.Tables[0].Rows[0]["KPS_Check"].ToString();
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
        public KNet.Model.Knet_Procure_Suppliers GetModelB(string SuppNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Knet_Procure_Suppliers ");
            strSql.Append(" where SuppNo=@SuppNo ");
            SqlParameter[] parameters = {
                    new SqlParameter("@SuppNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = SuppNo;

            KNet.Model.Knet_Procure_Suppliers model = new KNet.Model.Knet_Procure_Suppliers();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppNo"] != null && ds.Tables[0].Rows[0]["SuppNo"].ToString() != "")
                {
                    model.SuppNo = ds.Tables[0].Rows[0]["SuppNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppName"] != null && ds.Tables[0].Rows[0]["SuppName"].ToString() != "")
                {
                    model.SuppName = ds.Tables[0].Rows[0]["SuppName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppPeople"] != null && ds.Tables[0].Rows[0]["SuppPeople"].ToString() != "")
                {
                    model.SuppPeople = ds.Tables[0].Rows[0]["SuppPeople"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppMobiTel"] != null && ds.Tables[0].Rows[0]["SuppMobiTel"].ToString() != "")
                {
                    model.SuppMobiTel = ds.Tables[0].Rows[0]["SuppMobiTel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppFax"] != null && ds.Tables[0].Rows[0]["SuppFax"].ToString() != "")
                {
                    model.SuppFax = ds.Tables[0].Rows[0]["SuppFax"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppPhone"] != null && ds.Tables[0].Rows[0]["SuppPhone"].ToString() != "")
                {
                    model.SuppPhone = ds.Tables[0].Rows[0]["SuppPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppWeb"] != null && ds.Tables[0].Rows[0]["SuppWeb"].ToString() != "")
                {
                    model.SuppWeb = ds.Tables[0].Rows[0]["SuppWeb"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppEmail"] != null && ds.Tables[0].Rows[0]["SuppEmail"].ToString() != "")
                {
                    model.SuppEmail = ds.Tables[0].Rows[0]["SuppEmail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppProvince"] != null && ds.Tables[0].Rows[0]["SuppProvince"].ToString() != "")
                {
                    model.SuppProvince = ds.Tables[0].Rows[0]["SuppProvince"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppCity"] != null && ds.Tables[0].Rows[0]["SuppCity"].ToString() != "")
                {
                    model.SuppCity = ds.Tables[0].Rows[0]["SuppCity"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppAddress"] != null && ds.Tables[0].Rows[0]["SuppAddress"].ToString() != "")
                {
                    model.SuppAddress = ds.Tables[0].Rows[0]["SuppAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppZipCode"] != null && ds.Tables[0].Rows[0]["SuppZipCode"].ToString() != "")
                {
                    model.SuppZipCode = ds.Tables[0].Rows[0]["SuppZipCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppBankName"] != null && ds.Tables[0].Rows[0]["SuppBankName"].ToString() != "")
                {
                    model.SuppBankName = ds.Tables[0].Rows[0]["SuppBankName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppBankAccount"] != null && ds.Tables[0].Rows[0]["SuppBankAccount"].ToString() != "")
                {
                    model.SuppBankAccount = ds.Tables[0].Rows[0]["SuppBankAccount"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppProducts"] != null && ds.Tables[0].Rows[0]["SuppProducts"].ToString() != "")
                {
                    model.SuppProducts = ds.Tables[0].Rows[0]["SuppProducts"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remarks"] != null && ds.Tables[0].Rows[0]["Remarks"].ToString() != "")
                {
                    model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppCode"] != null && ds.Tables[0].Rows[0]["SuppCode"].ToString() != "")
                {
                    model.SuppCode = ds.Tables[0].Rows[0]["SuppCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_DutyPerson"] != null && ds.Tables[0].Rows[0]["KPS_DutyPerson"].ToString() != "")
                {
                    model.KPS_DutyPerson = ds.Tables[0].Rows[0]["KPS_DutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_Level"] != null && ds.Tables[0].Rows[0]["KPS_Level"].ToString() != "")
                {
                    model.KPS_Level = ds.Tables[0].Rows[0]["KPS_Level"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_Type"] != null && ds.Tables[0].Rows[0]["KPS_Type"].ToString() != "")
                {
                    model.KPS_Type = ds.Tables[0].Rows[0]["KPS_Type"].ToString();
                }
                else
                {
                    model.KPS_Type = "";
                }
                if (ds.Tables[0].Rows[0]["KPS_CTime"] != null && ds.Tables[0].Rows[0]["KPS_CTime"].ToString() != "")
                {
                    model.KPS_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["KPS_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KPS_Creator"] != null && ds.Tables[0].Rows[0]["KPS_Creator"].ToString() != "")
                {
                    model.KPS_Creator = ds.Tables[0].Rows[0]["KPS_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_MTime"] != null && ds.Tables[0].Rows[0]["KPS_MTime"].ToString() != "")
                {
                    model.KPS_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["KPS_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KPS_Mender"] != null && ds.Tables[0].Rows[0]["KPS_Mender"].ToString() != "")
                {
                    model.KPS_Mender = ds.Tables[0].Rows[0]["KPS_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_Del"] != null && ds.Tables[0].Rows[0]["KPS_Del"].ToString() != "")
                {
                    model.KPS_Del = int.Parse(ds.Tables[0].Rows[0]["KPS_Del"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KPS_LinkManID"] != null && ds.Tables[0].Rows[0]["KPS_LinkManID"].ToString() != "")
                {
                    model.KPS_LinkManID = ds.Tables[0].Rows[0]["KPS_LinkManID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_Sname"] != null && ds.Tables[0].Rows[0]["KPS_Sname"].ToString() != "")
                {
                    model.KPS_Sname = ds.Tables[0].Rows[0]["KPS_Sname"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_Code"] != null && ds.Tables[0].Rows[0]["KPS_Code"].ToString() != "")
                {
                    model.KPS_Code = ds.Tables[0].Rows[0]["KPS_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_KDCode"] != null && ds.Tables[0].Rows[0]["KPS_KDCode"].ToString() != "")
                {
                    model.KPS_KDCode = ds.Tables[0].Rows[0]["KPS_KDCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_Days"] != null && ds.Tables[0].Rows[0]["KPS_Days"].ToString() != "")
                {
                    model.KPS_Days = int.Parse(ds.Tables[0].Rows[0]["KPS_Days"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KPS_ScNumber"] != null && ds.Tables[0].Rows[0]["KPS_ScNumber"].ToString() != "")
                {
                    model.KPS_ScNumber = int.Parse(ds.Tables[0].Rows[0]["KPS_ScNumber"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KPS_GiveDays"] != null && ds.Tables[0].Rows[0]["KPS_GiveDays"].ToString() != "")
                {
                    model.KPS_GiveDays = int.Parse(ds.Tables[0].Rows[0]["KPS_GiveDays"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KPS_Nature"] != null && ds.Tables[0].Rows[0]["KPS_Nature"].ToString() != "")
                {
                    model.KPS_Nature = int.Parse(ds.Tables[0].Rows[0]["KPS_Nature"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KPS_BusinessUrl"] != null && ds.Tables[0].Rows[0]["KPS_BusinessUrl"].ToString() != "")
                {
                    model.KPS_BusinessUrl = ds.Tables[0].Rows[0]["KPS_BusinessUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_Business"] != null && ds.Tables[0].Rows[0]["KPS_Business"].ToString() != "")
                {
                    model.KPS_Business = ds.Tables[0].Rows[0]["KPS_Business"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_InvoiceUrl"] != null && ds.Tables[0].Rows[0]["KPS_InvoiceUrl"].ToString() != "")
                {
                    model.KPS_InvoiceUrl = ds.Tables[0].Rows[0]["KPS_InvoiceUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_Invoice"] != null && ds.Tables[0].Rows[0]["KPS_Invoice"].ToString() != "")
                {
                    model.KPS_Invoice = ds.Tables[0].Rows[0]["KPS_Invoice"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_ContractUrl"] != null && ds.Tables[0].Rows[0]["KPS_ContractUrl"].ToString() != "")
                {
                    model.KPS_ContractUrl = ds.Tables[0].Rows[0]["KPS_ContractUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_Contract"] != null && ds.Tables[0].Rows[0]["KPS_Contract"].ToString() != "")
                {
                    model.KPS_Contract = ds.Tables[0].Rows[0]["KPS_Contract"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KPS_FiveUrl"] != null && ds.Tables[0].Rows[0]["KPS_FiveUrl"].ToString() != "")
                {
                    model.KPS_FiveUrl = ds.Tables[0].Rows[0]["KPS_FiveUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_FiveName"] != null && ds.Tables[0].Rows[0]["KPS_FiveName"].ToString() != "")
                {
                    model.KPS_FiveName = ds.Tables[0].Rows[0]["KPS_FiveName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSP_SQEUrl"] != null && ds.Tables[0].Rows[0]["KSP_SQEUrl"].ToString() != "")
                {
                    model.KSP_SQEUrl = ds.Tables[0].Rows[0]["KSP_SQEUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_SQEName"] != null && ds.Tables[0].Rows[0]["KPS_SQEName"].ToString() != "")
                {
                    model.KPS_SQEName = ds.Tables[0].Rows[0]["KPS_SQEName"].ToString();
                }


                if (ds.Tables[0].Rows[0]["KPS_Production"] != null && ds.Tables[0].Rows[0]["KPS_Production"].ToString() != "")
                {
                    model.KPS_Production = ds.Tables[0].Rows[0]["KPS_Production"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_ProductionPho"] != null && ds.Tables[0].Rows[0]["KPS_ProductionPho"].ToString() != "")
                {
                    model.KPS_ProductionPho = ds.Tables[0].Rows[0]["KPS_ProductionPho"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_WareHouse"] != null && ds.Tables[0].Rows[0]["KPS_WareHouse"].ToString() != "")
                {
                    model.KPS_WareHouse = ds.Tables[0].Rows[0]["KPS_WareHouse"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_WareHousePho"] != null && ds.Tables[0].Rows[0]["KPS_WareHousePho"].ToString() != "")
                {
                    model.KPS_WareHousePho = ds.Tables[0].Rows[0]["KPS_WareHousePho"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_CdBankName"] != null && ds.Tables[0].Rows[0]["KPS_CdBankName"].ToString() != "")
                {
                    model.KPS_CdBankName = ds.Tables[0].Rows[0]["KPS_CdBankName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_CdBankNum"] != null && ds.Tables[0].Rows[0]["KPS_CdBankNum"].ToString() != "")
                {
                    model.KPS_CdBankNum = ds.Tables[0].Rows[0]["KPS_CdBankNum"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPS_Check"] != null && ds.Tables[0].Rows[0]["KPS_Check"].ToString() != "")
                {
                    model.KPS_Check = ds.Tables[0].Rows[0]["KPS_Check"].ToString();
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
            strSql.Append(" FROM Knet_Procure_Suppliers ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}


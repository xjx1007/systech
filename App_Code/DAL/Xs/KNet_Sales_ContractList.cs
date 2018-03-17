using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;


namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sales_ContractList。
    /// </summary>
    public class KNet_Sales_ContractList
    {
        public KNet_Sales_ContractList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ContractNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = ContractNo;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sales_ContractList_Exists", parameters, out rowsAffected);
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
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sales_ContractList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Sales_ContractList(");
            strSql.Append("ContractNo,ContractTopic,CustomerValue,ContractDateTime,ContractStarDateTime,ContractEndtDateTime,ContractOursDelegate,ContractSideDelegate,ContractClass,ContractTranShare,ContractDeliveMethods,ContractToAddress,ContractToDeliDate,ContractToPayment,HouseNo,BaoPriceNo,ContractStaffBranch,ContractStaffDepart,ContractStaffNo,ContractCheckStaffNo,ContractRemarks,ContractState,ContractCheckYN,SystemDatetimes,RoutineTransport,WorryTransport,TechnicalRequire,ProductPackaging,QualityRequire,WarrantyPeriod,DeliveryRequire,Payment,ContentPerson,Telephone,ProductsBigPicture,ProductsSmallPicture,ContractShip,ProductsPic,DutyPerson,KSC_OrderNO,KSC_OrderName,KSC_OrderURL,KSC_MaterNumber,KSC_PlanNo,KSC_ShipType,KSC_CustomerOrderNo,KSC_FaterId,KSC_Creator,KSC_CTime,KSC_Mender,KSC_MTime,KSC_KpType)");
            strSql.Append(" values (");
            strSql.Append("@ContractNo,@ContractTopic,@CustomerValue,@ContractDateTime,@ContractStarDateTime,@ContractEndtDateTime,@ContractOursDelegate,@ContractSideDelegate,@ContractClass,@ContractTranShare,@ContractDeliveMethods,@ContractToAddress,@ContractToDeliDate,@ContractToPayment,@HouseNo,@BaoPriceNo,@ContractStaffBranch,@ContractStaffDepart,@ContractStaffNo,@ContractCheckStaffNo,@ContractRemarks,@ContractState,@ContractCheckYN,@SystemDatetimes,@RoutineTransport,@WorryTransport,@TechnicalRequire,@ProductPackaging,@QualityRequire,@WarrantyPeriod,@DeliveryRequire,@Payment,@ContentPerson,@Telephone,@ProductsBigPicture,@ProductsSmallPicture,@ContractShip,@ProductsPic,@DutyPerson,@KSC_OrderNO,@KSC_OrderName,@KSC_OrderURL,@KSC_MaterNumber,@KSC_PlanNo,@KSC_ShipType,@KSC_CustomerOrderNo,@KSC_FaterId,@KSC_Creator,@KSC_CTime,@KSC_Mender,@KSC_MTime,@KSC_KpType)");
            SqlParameter[] parameters = {
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractTopic", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerValue", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractDateTime", SqlDbType.DateTime),
					new SqlParameter("@ContractStarDateTime", SqlDbType.DateTime),
					new SqlParameter("@ContractEndtDateTime", SqlDbType.DateTime),
					new SqlParameter("@ContractOursDelegate", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractSideDelegate", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractClass", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractTranShare", SqlDbType.Decimal,9),
					new SqlParameter("@ContractDeliveMethods", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractToAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractToDeliDate", SqlDbType.DateTime),
					new SqlParameter("@ContractToPayment", SqlDbType.NVarChar,50),
					new SqlParameter("@HouseNo", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPriceNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractCheckStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractRemarks", SqlDbType.NVarChar,1000),
					new SqlParameter("@ContractState", SqlDbType.Int,4),
					new SqlParameter("@ContractCheckYN", SqlDbType.Bit,1),
					new SqlParameter("@SystemDatetimes", SqlDbType.DateTime),
					new SqlParameter("@RoutineTransport", SqlDbType.VarChar,50),
					new SqlParameter("@WorryTransport", SqlDbType.VarChar,50),
					new SqlParameter("@TechnicalRequire", SqlDbType.VarChar,1000),
					new SqlParameter("@ProductPackaging", SqlDbType.VarChar,1000),
					new SqlParameter("@QualityRequire", SqlDbType.VarChar,1000),
					new SqlParameter("@WarrantyPeriod", SqlDbType.VarChar,1000),
					new SqlParameter("@DeliveryRequire", SqlDbType.VarChar,1000),
					new SqlParameter("@Payment", SqlDbType.VarChar,50),
					new SqlParameter("@ContentPerson", SqlDbType.VarChar,50),
					new SqlParameter("@Telephone", SqlDbType.VarChar,50),
					new SqlParameter("@ProductsBigPicture", SqlDbType.VarChar,100),
					new SqlParameter("@ProductsSmallPicture", SqlDbType.VarChar,100),
					new SqlParameter("@ContractShip", SqlDbType.VarChar,1000),
					new SqlParameter("@ProductsPic", SqlDbType.Int),
					new SqlParameter("@DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_OrderNO", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_OrderName", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_OrderURL", SqlDbType.VarChar,350),
					new SqlParameter("@KSC_MaterNumber", SqlDbType.VarChar,300),
					new SqlParameter("@KSC_PlanNo", SqlDbType.VarChar,300),
					new SqlParameter("@KSC_ShipType", SqlDbType.VarChar,300),
					new SqlParameter("@KSC_CustomerOrderNo", SqlDbType.VarChar,30),
					new SqlParameter("@KSC_FaterId", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_CTime", SqlDbType.DateTime),
					new SqlParameter("@KSC_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_MTime", SqlDbType.DateTime),
					new SqlParameter("@KSC_KpType", SqlDbType.VarChar,50)
                    
            };
            parameters[0].Value = model.ContractNo;
            parameters[1].Value = model.ContractTopic;
            parameters[2].Value = model.CustomerValue;
            parameters[3].Value = model.ContractDateTime;
            parameters[4].Value = model.ContractStarDateTime;
            parameters[5].Value = model.ContractEndtDateTime;
            parameters[6].Value = model.ContractOursDelegate;
            parameters[7].Value = model.ContractSideDelegate;
            parameters[8].Value = model.ContractClass;
            parameters[9].Value = model.ContractTranShare;
            parameters[10].Value = model.ContractDeliveMethods;
            parameters[11].Value = model.ContractToAddress;
            parameters[12].Value = model.ContractToDeliDate;
            parameters[13].Value = model.ContractToPayment;
            parameters[14].Value = model.HouseNo;
            parameters[15].Value = model.BaoPriceNo;
            parameters[16].Value = model.ContractStaffBranch;
            parameters[17].Value = model.ContractStaffDepart;
            parameters[18].Value = model.ContractStaffNo;
            parameters[19].Value = model.ContractCheckStaffNo;
            parameters[20].Value = model.ContractRemarks;
            parameters[21].Value = model.ContractState;
            parameters[22].Value = model.ContractCheckYN;
            parameters[23].Value = model.SystemDatetimes;
            parameters[24].Value = model.RoutineTransport;
            parameters[25].Value = model.WorryTransport;
            parameters[26].Value = model.TechnicalRequire;
            parameters[27].Value = model.ProductPackaging;
            parameters[28].Value = model.QualityRequire;
            parameters[29].Value = model.WarrantyPeriod;
            parameters[30].Value = model.DeliveryRequire;
            parameters[31].Value = model.Payment;
            parameters[32].Value = model.ContentPerson;
            parameters[33].Value = model.Telephone;
            parameters[34].Value = model.ProductsBigPicture;
            parameters[35].Value = model.ProductsSmallPicture;
            parameters[36].Value = model.ContractShip;
            parameters[37].Value = model.ProductsPic;
            parameters[38].Value = model.DutyPerson;
            parameters[39].Value = model.KSC_OrderNO;
            parameters[40].Value = model.KSC_OrderName;
            parameters[41].Value = model.KSC_OrderURL;
            parameters[42].Value = model.KSC_MaterNumber;
            parameters[43].Value = model.KSC_PlanNo;
            parameters[44].Value = model.KSC_ShipType;
            parameters[45].Value = model.KSC_CustomerOrderNo;
            parameters[46].Value = model.KSC_FaterId;
            parameters[47].Value = model.KSC_Creator;
            parameters[48].Value = model.KSC_CTime;
            parameters[49].Value = model.KSC_Mender;
            parameters[50].Value = model.KSC_MTime;
            parameters[51].Value = model.KSC_KpType;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.KNet_Sales_ContractList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Sales_ContractList set ");
            strSql.Append("HouseNo=@HouseNo,");
            strSql.Append("ContractTopic=@ContractTopic,");
            strSql.Append("CustomerValue=@CustomerValue,");
            strSql.Append("ContractDateTime=@ContractDateTime,");
            strSql.Append("ContractStarDateTime=@ContractStarDateTime,");
            strSql.Append("ContractEndtDateTime=@ContractEndtDateTime,");
            strSql.Append("ContractOursDelegate=@ContractOursDelegate,");
            strSql.Append("ContractSideDelegate=@ContractSideDelegate,");
            strSql.Append("ContractClass=@ContractClass,");
            strSql.Append("ContractTranShare=@ContractTranShare,");
            strSql.Append("ContractDeliveMethods=@ContractDeliveMethods,");
            strSql.Append("ContractToAddress=@ContractToAddress,");
            strSql.Append("ContractToDeliDate=@ContractToDeliDate,");
            strSql.Append("ContractToPayment=@ContractToPayment,");
            strSql.Append("BaoPriceNo=@BaoPriceNo,");
            strSql.Append("ContractStaffBranch=@ContractStaffBranch,");
            strSql.Append("ContractStaffDepart=@ContractStaffDepart,");
            strSql.Append("ContractCheckStaffNo=@ContractCheckStaffNo,");
            strSql.Append("ContractRemarks=@ContractRemarks,");
            strSql.Append("ContractState=@ContractState,");
            strSql.Append("ContractCheckYN=@ContractCheckYN,");
            strSql.Append("SystemDatetimes=@SystemDatetimes,");
            strSql.Append("RoutineTransport=@RoutineTransport,");
            strSql.Append("WorryTransport=@WorryTransport,");
            strSql.Append("TechnicalRequire=@TechnicalRequire,");
            strSql.Append("ProductPackaging=@ProductPackaging,");
            strSql.Append("QualityRequire=@QualityRequire,");
            strSql.Append("WarrantyPeriod=@WarrantyPeriod,");
            strSql.Append("DeliveryRequire=@DeliveryRequire,");
            strSql.Append("Payment=@Payment,");
            strSql.Append("ContentPerson=@ContentPerson,");
            strSql.Append("Telephone=@Telephone,");
            strSql.Append("ProductsBigPicture=@ProductsBigPicture,");
            strSql.Append("ProductsSmallPicture=@ProductsSmallPicture,");
            strSql.Append("ContractShip=@ContractShip,");
            strSql.Append("ProductsPic=@ProductsPic,"); ;
            strSql.Append("DutyPerson=@DutyPerson,");
            strSql.Append("KSC_OrderNO=@KSC_OrderNO,");
            strSql.Append("KSC_OrderName=@KSC_OrderName,");
            strSql.Append("KSC_OrderURL=@KSC_OrderURL,");

            strSql.Append("KSC_MaterNumber=@KSC_MaterNumber,");
            strSql.Append("KSC_PlanNo=@KSC_PlanNo,");
            strSql.Append("KSC_ShipType=@KSC_ShipType,");
            strSql.Append("KSC_CustomerOrderNo=@KSC_CustomerOrderNo,");
            strSql.Append("KSC_FaterId=@KSC_FaterId,");
            strSql.Append("KSC_Mender=@KSC_Mender,");
            strSql.Append("KSC_MTime=@KSC_MTime,");
            strSql.Append("KSC_KpType=@KSC_KpType");
            

            strSql.Append(" where ContractNo=@ContractNo");
            SqlParameter[] parameters = {
					new SqlParameter("@HouseNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractTopic", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerValue", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractDateTime", SqlDbType.DateTime),
					new SqlParameter("@ContractStarDateTime", SqlDbType.DateTime),
					new SqlParameter("@ContractEndtDateTime", SqlDbType.DateTime),
					new SqlParameter("@ContractOursDelegate", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractSideDelegate", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractClass", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractTranShare", SqlDbType.Decimal,9),
					new SqlParameter("@ContractDeliveMethods", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractToAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractToDeliDate", SqlDbType.DateTime),
					new SqlParameter("@ContractToPayment", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPriceNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractCheckStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractRemarks", SqlDbType.NVarChar,1000),
					new SqlParameter("@ContractState", SqlDbType.Int,4),
					new SqlParameter("@ContractCheckYN", SqlDbType.Bit,1),
					new SqlParameter("@SystemDatetimes", SqlDbType.DateTime),
					new SqlParameter("@RoutineTransport", SqlDbType.VarChar,50),
					new SqlParameter("@WorryTransport", SqlDbType.VarChar,50),
					new SqlParameter("@TechnicalRequire", SqlDbType.VarChar,1000),
					new SqlParameter("@ProductPackaging", SqlDbType.VarChar,1000),
					new SqlParameter("@QualityRequire", SqlDbType.VarChar,1000),
					new SqlParameter("@WarrantyPeriod", SqlDbType.VarChar,1000),
					new SqlParameter("@DeliveryRequire", SqlDbType.VarChar,1000),
					new SqlParameter("@Payment", SqlDbType.VarChar,50),
					new SqlParameter("@ContentPerson", SqlDbType.VarChar,50),
					new SqlParameter("@Telephone", SqlDbType.VarChar,50),
					new SqlParameter("@ProductsBigPicture", SqlDbType.VarChar,100),
					new SqlParameter("@ProductsSmallPicture", SqlDbType.VarChar,100),
					new SqlParameter("@ContractShip", SqlDbType.VarChar,1000),
					new SqlParameter("@ProductsPic", SqlDbType.Int),
					new SqlParameter("@DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_OrderNO", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_OrderName", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_OrderURL", SqlDbType.VarChar,350),

					new SqlParameter("@KSC_MaterNumber", SqlDbType.VarChar,300),
					new SqlParameter("@KSC_PlanNo", SqlDbType.VarChar,300),
					new SqlParameter("@KSC_ShipType", SqlDbType.VarChar,300),
					new SqlParameter("@KSC_CustomerOrderNo", SqlDbType.VarChar,300),
					new SqlParameter("@KSC_FaterId", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@KSC_MTime", SqlDbType.DateTime),
					new SqlParameter("@KSC_KpType", SqlDbType.VarChar,50),
                    
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50)};

            parameters[0].Value = model.HouseNo;
            parameters[1].Value = model.ContractTopic;
            parameters[2].Value = model.CustomerValue;
            parameters[3].Value = model.ContractDateTime;
            parameters[4].Value = model.ContractStarDateTime;
            parameters[5].Value = model.ContractEndtDateTime;
            parameters[6].Value = model.ContractOursDelegate;
            parameters[7].Value = model.ContractSideDelegate;
            parameters[8].Value = model.ContractClass;
            parameters[9].Value = model.ContractTranShare;
            parameters[10].Value = model.ContractDeliveMethods;
            parameters[11].Value = model.ContractToAddress;
            parameters[12].Value = model.ContractToDeliDate;
            parameters[13].Value = model.ContractToPayment;
            parameters[14].Value = model.BaoPriceNo;
            parameters[15].Value = model.ContractStaffBranch;
            parameters[16].Value = model.ContractStaffDepart;
            parameters[17].Value = model.ContractCheckStaffNo;
            parameters[18].Value = model.ContractRemarks;
            parameters[19].Value = model.ContractState;
            parameters[20].Value = model.ContractCheckYN;
            parameters[21].Value = model.SystemDatetimes;
            parameters[22].Value = model.RoutineTransport;
            parameters[23].Value = model.WorryTransport;
            parameters[24].Value = model.TechnicalRequire;
            parameters[25].Value = model.ProductPackaging;
            parameters[26].Value = model.QualityRequire;
            parameters[27].Value = model.WarrantyPeriod;
            parameters[28].Value = model.DeliveryRequire;
            parameters[29].Value = model.Payment;
            parameters[30].Value = model.ContentPerson;
            parameters[31].Value = model.Telephone;
            parameters[32].Value = model.ProductsBigPicture;
            parameters[33].Value = model.ProductsSmallPicture;
            parameters[34].Value = model.ContractShip;
            parameters[35].Value = model.ProductsPic;
            parameters[36].Value = model.DutyPerson;
            parameters[37].Value = model.KSC_OrderNO;
            parameters[38].Value = model.KSC_OrderName;
            parameters[39].Value = model.KSC_OrderURL;

            parameters[40].Value = model.KSC_MaterNumber;
            parameters[41].Value = model.KSC_PlanNo;
            parameters[42].Value = model.KSC_ShipType;
            parameters[43].Value = model.KSC_CustomerOrderNo;
            parameters[44].Value = model.KSC_FaterId;
            parameters[45].Value = model.KSC_Mender;
            parameters[46].Value = model.KSC_MTime;
            parameters[47].Value = model.KSC_KpType;
            
            parameters[48].Value = model.ContractNo;

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
        public bool UpdateDate(KNet.Model.KNet_Sales_ContractList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Sales_ContractList set ");
            strSql.Append("KFC_ReDate=@KFC_ReDate");
            strSql.Append(" where ContractNo=@ContractNo");
            SqlParameter[] parameters = {
					new SqlParameter("@KFC_ReDate", SqlDbType.DateTime),
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50)};

            parameters[0].Value = model.KFC_ReDate;
            parameters[1].Value = model.ContractNo;

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
        public bool UpdateShipDate(KNet.Model.KNet_Sales_ContractList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Sales_ContractList set ");
            strSql.Append("ContractToDeliDate=@ContractToDeliDate");
            strSql.Append(" where ContractNo=@ContractNo");
            SqlParameter[] parameters = {
					new SqlParameter("@ContractToDeliDate", SqlDbType.DateTime),
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50)};

            parameters[0].Value = model.ContractToDeliDate;
            parameters[1].Value = model.ContractNo;

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
        public void Delete(string ContractNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = ContractNo;

            DbHelperSQL.RunProcedure("Proc_KNet_Sales_ContractList_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_ContractList GetModel(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_Sales_ContractList model = new KNet.Model.KNet_Sales_ContractList();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_Sales_ContractList_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.ContractNo = ds.Tables[0].Rows[0]["ContractNo"].ToString();
                model.ContractTopic = ds.Tables[0].Rows[0]["ContractTopic"].ToString();
                model.CustomerValue = ds.Tables[0].Rows[0]["CustomerValue"].ToString();
                if (ds.Tables[0].Rows[0]["ContractDateTime"].ToString() != "")
                {
                    model.ContractDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["ContractDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContractStarDateTime"].ToString() != "")
                {
                    model.ContractStarDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["ContractStarDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContractEndtDateTime"].ToString() != "")
                {
                    model.ContractEndtDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["ContractEndtDateTime"].ToString());
                }
                model.ContractOursDelegate = ds.Tables[0].Rows[0]["ContractOursDelegate"].ToString();
                model.ContractSideDelegate = ds.Tables[0].Rows[0]["ContractSideDelegate"].ToString();
                model.ContractClass = ds.Tables[0].Rows[0]["ContractClass"].ToString();
                if (ds.Tables[0].Rows[0]["ContractTranShare"].ToString() != "")
                {
                    model.ContractTranShare = decimal.Parse(ds.Tables[0].Rows[0]["ContractTranShare"].ToString());
                }
                model.ContractDeliveMethods = ds.Tables[0].Rows[0]["ContractDeliveMethods"].ToString();
                model.ContractToAddress = ds.Tables[0].Rows[0]["ContractToAddress"].ToString();
                if (ds.Tables[0].Rows[0]["ContractToDeliDate"].ToString() != "")
                {
                    model.ContractToDeliDate = DateTime.Parse(ds.Tables[0].Rows[0]["ContractToDeliDate"].ToString());
                }
                model.ContractToPayment = ds.Tables[0].Rows[0]["ContractToPayment"].ToString();
                model.HouseNo = ds.Tables[0].Rows[0]["HouseNo"].ToString();
                model.BaoPriceNo = ds.Tables[0].Rows[0]["BaoPriceNo"].ToString();
                model.ContractStaffBranch = ds.Tables[0].Rows[0]["ContractStaffBranch"].ToString();
                model.ContractStaffDepart = ds.Tables[0].Rows[0]["ContractStaffDepart"].ToString();
                model.ContractStaffNo = ds.Tables[0].Rows[0]["ContractStaffNo"].ToString();
                model.ContractCheckStaffNo = ds.Tables[0].Rows[0]["ContractCheckStaffNo"].ToString();
                model.ContractRemarks = ds.Tables[0].Rows[0]["ContractRemarks"].ToString();
                if (ds.Tables[0].Rows[0]["ContractState"].ToString() != "")
                {
                    model.ContractState = int.Parse(ds.Tables[0].Rows[0]["ContractState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContractCheckYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ContractCheckYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["ContractCheckYN"].ToString().ToLower() == "true"))
                    {
                        model.ContractCheckYN = true;
                    }
                    else
                    {
                        model.ContractCheckYN = false;
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
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_ContractList GetModelB(string ContractNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from KNet_Sales_ContractList ");
            strSql.Append(" where ContractNo=@ContractNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = ContractNo;

            KNet.Model.KNet_Sales_ContractList model = new KNet.Model.KNet_Sales_ContractList();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractNo"] != null && ds.Tables[0].Rows[0]["ContractNo"].ToString() != "")
                {
                    model.ContractNo = ds.Tables[0].Rows[0]["ContractNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractTopic"] != null && ds.Tables[0].Rows[0]["ContractTopic"].ToString() != "")
                {
                    model.ContractTopic = ds.Tables[0].Rows[0]["ContractTopic"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerValue"] != null && ds.Tables[0].Rows[0]["CustomerValue"].ToString() != "")
                {
                    model.CustomerValue = ds.Tables[0].Rows[0]["CustomerValue"].ToString();
                }

                if (ds.Tables[0].Rows[0]["ContractDateTime"] != null && ds.Tables[0].Rows[0]["ContractDateTime"].ToString() != "")
                {
                    model.ContractDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["ContractDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContractStarDateTime"] != null && ds.Tables[0].Rows[0]["ContractStarDateTime"].ToString() != "")
                {
                    model.ContractStarDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["ContractStarDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContractEndtDateTime"] != null && ds.Tables[0].Rows[0]["ContractEndtDateTime"].ToString() != "")
                {
                    model.ContractEndtDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["ContractEndtDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContractOursDelegate"] != null && ds.Tables[0].Rows[0]["ContractOursDelegate"].ToString() != "")
                {
                    model.ContractOursDelegate = ds.Tables[0].Rows[0]["ContractOursDelegate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractSideDelegate"] != null && ds.Tables[0].Rows[0]["ContractSideDelegate"].ToString() != "")
                {
                    model.ContractSideDelegate = ds.Tables[0].Rows[0]["ContractSideDelegate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractClass"] != null && ds.Tables[0].Rows[0]["ContractClass"].ToString() != "")
                {
                    model.ContractClass = ds.Tables[0].Rows[0]["ContractClass"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractTranShare"] != null && ds.Tables[0].Rows[0]["ContractTranShare"].ToString() != "")
                {
                    model.ContractTranShare = decimal.Parse(ds.Tables[0].Rows[0]["ContractTranShare"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContractDeliveMethods"] != null && ds.Tables[0].Rows[0]["ContractDeliveMethods"].ToString() != "")
                {
                    model.ContractDeliveMethods = ds.Tables[0].Rows[0]["ContractDeliveMethods"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractToAddress"] != null && ds.Tables[0].Rows[0]["ContractToAddress"].ToString() != "")
                {
                    model.ContractToAddress = ds.Tables[0].Rows[0]["ContractToAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractToDeliDate"] != null && ds.Tables[0].Rows[0]["ContractToDeliDate"].ToString() != "")
                {
                    model.ContractToDeliDate = DateTime.Parse(ds.Tables[0].Rows[0]["ContractToDeliDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContractToPayment"] != null && ds.Tables[0].Rows[0]["ContractToPayment"].ToString() != "")
                {
                    model.ContractToPayment = ds.Tables[0].Rows[0]["ContractToPayment"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HouseNo"] != null && ds.Tables[0].Rows[0]["HouseNo"].ToString() != "")
                {
                    model.HouseNo = ds.Tables[0].Rows[0]["HouseNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BaoPriceNo"] != null && ds.Tables[0].Rows[0]["BaoPriceNo"].ToString() != "")
                {
                    model.BaoPriceNo = ds.Tables[0].Rows[0]["BaoPriceNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractStaffBranch"] != null && ds.Tables[0].Rows[0]["ContractStaffBranch"].ToString() != "")
                {
                    model.ContractStaffBranch = ds.Tables[0].Rows[0]["ContractStaffBranch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractStaffDepart"] != null && ds.Tables[0].Rows[0]["ContractStaffDepart"].ToString() != "")
                {
                    model.ContractStaffDepart = ds.Tables[0].Rows[0]["ContractStaffDepart"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractStaffNo"] != null && ds.Tables[0].Rows[0]["ContractStaffNo"].ToString() != "")
                {
                    model.ContractStaffNo = ds.Tables[0].Rows[0]["ContractStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractCheckStaffNo"] != null && ds.Tables[0].Rows[0]["ContractCheckStaffNo"].ToString() != "")
                {
                    model.ContractCheckStaffNo = ds.Tables[0].Rows[0]["ContractCheckStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractRemarks"] != null && ds.Tables[0].Rows[0]["ContractRemarks"].ToString() != "")
                {
                    model.ContractRemarks = ds.Tables[0].Rows[0]["ContractRemarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractState"] != null && ds.Tables[0].Rows[0]["ContractState"].ToString() != "")
                {
                    model.ContractState = int.Parse(ds.Tables[0].Rows[0]["ContractState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContractCheckYN"] != null && ds.Tables[0].Rows[0]["ContractCheckYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ContractCheckYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["ContractCheckYN"].ToString().ToLower() == "true"))
                    {
                        model.ContractCheckYN = true;
                    }
                    else
                    {
                        model.ContractCheckYN = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["SystemDatetimes"] != null && ds.Tables[0].Rows[0]["SystemDatetimes"].ToString() != "")
                {
                    model.SystemDatetimes = DateTime.Parse(ds.Tables[0].Rows[0]["SystemDatetimes"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoutineTransport"] != null && ds.Tables[0].Rows[0]["RoutineTransport"].ToString() != "")
                {
                    model.RoutineTransport = ds.Tables[0].Rows[0]["RoutineTransport"].ToString();
                }
                if (ds.Tables[0].Rows[0]["WorryTransport"] != null && ds.Tables[0].Rows[0]["WorryTransport"].ToString() != "")
                {
                    model.WorryTransport = ds.Tables[0].Rows[0]["WorryTransport"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TechnicalRequire"] != null && ds.Tables[0].Rows[0]["TechnicalRequire"].ToString() != "")
                {
                    model.TechnicalRequire = ds.Tables[0].Rows[0]["TechnicalRequire"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductPackaging"] != null && ds.Tables[0].Rows[0]["ProductPackaging"].ToString() != "")
                {
                    model.ProductPackaging = ds.Tables[0].Rows[0]["ProductPackaging"].ToString();
                }
                if (ds.Tables[0].Rows[0]["QualityRequire"] != null && ds.Tables[0].Rows[0]["QualityRequire"].ToString() != "")
                {
                    model.QualityRequire = ds.Tables[0].Rows[0]["QualityRequire"].ToString();
                }
                if (ds.Tables[0].Rows[0]["WarrantyPeriod"] != null && ds.Tables[0].Rows[0]["WarrantyPeriod"].ToString() != "")
                {
                    model.WarrantyPeriod = ds.Tables[0].Rows[0]["WarrantyPeriod"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DeliveryRequire"] != null && ds.Tables[0].Rows[0]["DeliveryRequire"].ToString() != "")
                {
                    model.DeliveryRequire = ds.Tables[0].Rows[0]["DeliveryRequire"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Payment"] != null && ds.Tables[0].Rows[0]["Payment"].ToString() != "")
                {
                    model.Payment = ds.Tables[0].Rows[0]["Payment"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContentPerson"] != null && ds.Tables[0].Rows[0]["ContentPerson"].ToString() != "")
                {
                    model.ContentPerson = ds.Tables[0].Rows[0]["ContentPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Telephone"] != null && ds.Tables[0].Rows[0]["Telephone"].ToString() != "")
                {
                    model.Telephone = ds.Tables[0].Rows[0]["Telephone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsBigPicture"] != null && ds.Tables[0].Rows[0]["ProductsBigPicture"].ToString() != "")
                {
                    model.ProductsBigPicture = ds.Tables[0].Rows[0]["ProductsBigPicture"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsSmallPicture"] != null && ds.Tables[0].Rows[0]["ProductsSmallPicture"].ToString() != "")
                {
                    model.ProductsSmallPicture = ds.Tables[0].Rows[0]["ProductsSmallPicture"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractShip"] != null && ds.Tables[0].Rows[0]["ContractShip"].ToString() != "")
                {
                    model.ContractShip = ds.Tables[0].Rows[0]["ContractShip"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsPic"] != null && ds.Tables[0].Rows[0]["ProductsPic"].ToString() != "")
                {
                    model.ProductsPic = int.Parse(ds.Tables[0].Rows[0]["ProductsPic"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DutyPerson"] != null && ds.Tables[0].Rows[0]["DutyPerson"].ToString() != "")
                {
                    model.DutyPerson =ds.Tables[0].Rows[0]["DutyPerson"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KSC_OrderNO"] != null && ds.Tables[0].Rows[0]["KSC_OrderNO"].ToString() != "")
                {
                    model.KSC_OrderNO = ds.Tables[0].Rows[0]["KSC_OrderNO"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSC_OrderName"] != null && ds.Tables[0].Rows[0]["KSC_OrderName"].ToString() != "")
                {
                    model.KSC_OrderName = ds.Tables[0].Rows[0]["KSC_OrderName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSC_OrderURL"] != null && ds.Tables[0].Rows[0]["KSC_OrderURL"].ToString() != "")
                {
                    model.KSC_OrderURL =ds.Tables[0].Rows[0]["KSC_OrderURL"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KFC_ReDate"] != null && ds.Tables[0].Rows[0]["KFC_ReDate"].ToString() != "")
                {
                    model.KFC_ReDate = DateTime.Parse(ds.Tables[0].Rows[0]["KFC_ReDate"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KSC_MaterNumber"] != null && ds.Tables[0].Rows[0]["KSC_MaterNumber"].ToString() != "")
                {
                    model.KSC_MaterNumber = ds.Tables[0].Rows[0]["KSC_MaterNumber"].ToString();
                }
                else
                {
                    model.KSC_MaterNumber = ",";
                }
                if (ds.Tables[0].Rows[0]["KSC_PlanNo"] != null && ds.Tables[0].Rows[0]["KSC_PlanNo"].ToString() != "")
                {
                    model.KSC_PlanNo = ds.Tables[0].Rows[0]["KSC_PlanNo"].ToString();
                }
                else
                {
                    model.KSC_PlanNo = "";
                }
                if (ds.Tables[0].Rows[0]["KSC_ShipType"] != null && ds.Tables[0].Rows[0]["KSC_ShipType"].ToString() != "")
                {
                    model.KSC_ShipType = ds.Tables[0].Rows[0]["KSC_ShipType"].ToString();
                }
                else
                {
                    model.KSC_ShipType = "";
                }
                if (ds.Tables[0].Rows[0]["KSC_CustomerOrderNo"] != null && ds.Tables[0].Rows[0]["KSC_CustomerOrderNo"].ToString() != "")
                {
                    model.KSC_CustomerOrderNo = ds.Tables[0].Rows[0]["KSC_CustomerOrderNo"].ToString();
                }
                else
                {
                    model.KSC_CustomerOrderNo = ",";
                }
                if (ds.Tables[0].Rows[0]["isOrder"] != null && ds.Tables[0].Rows[0]["isOrder"].ToString() != "")
                {
                    model.isOrder = int.Parse(ds.Tables[0].Rows[0]["isOrder"].ToString());
                }
                else
                {
                    model.KSC_CustomerOrderNo = ",";
                }
                if (ds.Tables[0].Rows[0]["KSC_FaterId"] != null && ds.Tables[0].Rows[0]["KSC_FaterId"].ToString() != "")
                {
                    model.KSC_FaterId = ds.Tables[0].Rows[0]["KSC_FaterId"].ToString();
                }
                else
                {
                    model.KSC_FaterId = ",";
                }

                if (ds.Tables[0].Rows[0]["KSC_Creator"] != null && ds.Tables[0].Rows[0]["KSC_Creator"].ToString() != "")
                {
                    model.KSC_Creator = ds.Tables[0].Rows[0]["KSC_Creator"].ToString();
                }
                else
                {
                    model.KSC_Creator = "";
                }

                if (ds.Tables[0].Rows[0]["KSC_CTime"] != null && ds.Tables[0].Rows[0]["KSC_CTime"].ToString() != "")
                {
                    model.KSC_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["KSC_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KSC_Mender"] != null && ds.Tables[0].Rows[0]["KSC_Mender"].ToString() != "")
                {
                    model.KSC_Mender = ds.Tables[0].Rows[0]["KSC_Mender"].ToString();
                }
                else
                {
                    model.KSC_Mender = "";
                }

                if (ds.Tables[0].Rows[0]["KSC_MTime"] != null && ds.Tables[0].Rows[0]["KSC_MTime"].ToString() != "")
                {
                    model.KSC_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["KSC_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KSC_KpType"] != null && ds.Tables[0].Rows[0]["KSC_KpType"].ToString() != "")
                {
                    model.KSC_KpType = ds.Tables[0].Rows[0]["KSC_KpType"].ToString();
                }
                else
                {
                    model.KSC_KpType = "";
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
        public DataSet GetDetailsList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,b.ProductsBarCode,b.ContractAmount ");
            strSql.Append(" FROM KNet_Sales_ContractList a  join KNet_Sales_ContractList_Details b on a.ContractNo=b.ContractNo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ContractNo,CustomerValue,DutyPerson,ContractStaffNo,ContractClass,KSC_KpType,SystemDateTimes,ContractCheckYN,v_OutWareAmount,v_DirectOutAmount,v_KxNumber,ContractDateTime,ContractToDeliDate,v_ContractNotBatteryAmount,v_ContractBatteryAmount,isorder,V_ContractAmount,V_ContractBAmount,DirectOutState ");
            strSql.Append(" FROM KNet_Sales_ContractList left join v_Contract_OutWare_DirectOut_State on v_ContractNO=ContractNO  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetTotalList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.CustomerValue,b.ProductsBarCode,Sum(c.ContractAmount) V_ContractAmount,Sum(c.OutWareAmount+c.OutWareBAmount) v_OutWareAmount,Sum(c.DirectOutAmount+c.DirectOutBAmount) v_DirectOutAmount,Sum(c.ContractBAmount) V_ContractBAmount,sum(c.ContractBAmount+c.ContractAmount-c.OutWareAmount+c.OutWareBAmount) v_LeftAmount ");
            strSql.Append(" FROM KNet_Sales_ContractList a  join KNet_Sales_ContractList_Details b on a.ContractNo=b.ContractNo left join v_Contract_OutWare_DirectOut_Total c on v_ContractNO=a.ContractNO and b.ProductsBarCode=v_ProductsBarCode ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where ContractCheckYN='1' and " + strWhere);
            }
            strSql.Append(" Group by  a.CustomerValue,b.ProductsBarCode having  sum(c.ContractBAmount+c.ContractAmount-c.OutWareAmount+c.OutWareBAmount)>0");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetCkList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,c.WareHouseNo,c.WareHouseDateTime,(Select Sum(WareHouseAmount) from Knet_Procure_WareHouseList_Details Where WareHouseNo=c.WareHouseNo) as WareHouseAmount,(Select Sum(ContractAmount) from KNet_Sales_ContractList_Details Where ContractNo=a.ContractNo) as ContractAmount  ");
            strSql.Append(" FROM KNet_Sales_ContractList a join Knet_Procure_OrdersList b on b.ContractNo=a.ContractNo join Knet_Procure_WareHouseList c on b.OrderNo=c.OrderNo ");
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
            strSql.Append(" ID,ContractNo,ContractTopic,CustomerValue,ContractDateTime,ContractStarDateTime,ContractEndtDateTime,ContractOursDelegate,ContractSideDelegate,ContractClass,ContractTranShare,ContractDeliveMethods,ContractToAddress,ContractToDeliDate,ContractToPayment,HouseNo,BaoPriceNo,ContractStaffBranch,ContractStaffDepart,ContractStaffNo,ContractCheckStaffNo,ContractRemarks,ContractState,ContractCheckYN,DutyPerson ");
            strSql.Append(" FROM KNet_Sales_ContractList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        
        /// 得到一个对象实体
        /// </summary>
        public int GetTotalNumber(string ContractNo)
        {

            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select  isnull(SUM(ContractAmount+KSC_BNumber),0) from KNet_Sales_ContractList_Details  a join KNET_Sys_Products e on a.ProductsBarCode=e.ProductsBarCode");
                strSql.Append(" where ContractNo=@ContractNo ");

                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs("01");
                s_SonID = s_SonID.Replace(",", "','");
                strSql.Append(" and ProductsType in ('" + s_SonID + "') ");
                SqlParameter[] parameters = {
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50)};
                parameters[0].Value = ContractNo;

                KNet.Model.KNet_Sales_ContractList model = new KNet.Model.KNet_Sales_ContractList();
                DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return int.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception ex)
            { return 0; }
        }


        #endregion  成员方法
    }
}


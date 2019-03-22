using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_WareHouse_DirectOutList。
    /// </summary>
    public class KNet_WareHouse_DirectOutList
    {
        public KNet_WareHouse_DirectOutList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string DirectOutNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@DirectOutNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = DirectOutNo;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_DirectOutList_Exists", parameters, out rowsAffected);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetPrice(string DirectOutNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update KNet_WareHouse_DirectOutList_Details  set ");
            strSql.Append(" KWD_WwPrice=cgprice,KWD_WwMoney=cgprice*DirectOutAmount,DirectOutUnitPrice=cgprice,DirectOutTotalNet=cgprice*DirectOutAmount");
            strSql.Append(" from KNet_WareHouse_DirectOutList_Details a,");
            strSql.Append(" ( select a.ID,");
            strSql.Append(" (select Top 1 ProcureUnitPrice from Knet_Procure_SuppliersPrice b");
            strSql.Append(" where b.ProductsBarCode=a.ProductsBarCode and b.KPP_State=1 and b.KPP_Del=0) cgprice");
            strSql.Append(" from KNet_WareHouse_DirectOutList_Details a ) bb");
            strSql.Append("  where a.ID=bb.id  and a.DirectOutNo=@DirectOutNo");
            SqlParameter[] parameters = {
					new SqlParameter("@DirectOutNo", SqlDbType.NVarChar,50)
                                         };

            parameters[0].Value = DirectOutNo;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_WareHouse_DirectOutList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_WareHouse_DirectOutList(");
            strSql.Append("DirectOutNo,DirectOutTopic,DirectOutDateTime,HouseNo,DirectOutStaffBranch,DirectOutStaffDepart,DirectOutStaffNo,DirectOutCheckStaffNo,DirectOutRemarks,DirectOutCheckYN,SystemDatetimes,KWD_ShipNo,KWD_Custmoer,KWD_Address,KWD_ContentPerson,KWD_Type,KWD_Del,isShip,KWD_Telphone,KWD_WuliuName,KWD_WuliuNameCode,KWD_WuliuCode,KWD_State,KWD_CwCode,KWD_CWOutTime,KWD_RkHouseNo,KWD_ReceTime,KWD_SCustomerValue,KWD_ContractDeliveMethods,KWD_ShipType,KWD_PayMent,KWD_KpType,KWD_MainProductsBarCode,KWD_MainProductsNumber,KWD_IsSupp,KWD_Project,KWD_SuppNo,KWD_LyType,KWD_Order,KWD_UploadUrl,KWD_UploadName)");
            strSql.Append(" values (");
            strSql.Append("@DirectOutNo,@DirectOutTopic,@DirectOutDateTime,@HouseNo,@DirectOutStaffBranch,@DirectOutStaffDepart,@DirectOutStaffNo,@DirectOutCheckStaffNo,@DirectOutRemarks,@DirectOutCheckYN,@SystemDatetimes,@KWD_ShipNo,@KWD_Custmoer,@KWD_Address,@KWD_ContentPerson,@KWD_Type,@KWD_Del,@isShip,@KWD_Telphone,@KWD_WuliuName,@KWD_WuliuNameCode,@KWD_WuliuCode,@KWD_State,@KWD_CwCode,@KWD_CWOutTime,@KWD_RkHouseNo,@KWD_ReceTime,@KWD_SCustomerValue,@KWD_ContractDeliveMethods,@KWD_ShipType,@KWD_PayMent,@KWD_KpType,@KWD_MainProductsBarCode,@KWD_MainProductsNumber,@KWD_IsSupp,@KWD_Project,@KWD_SuppNo,@KWD_LyType,@KWD_Order,@KWD_UploadUrl,@KWD_UploadName)");
            SqlParameter[] parameters = {
					new SqlParameter("@DirectOutNo", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectOutTopic", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectOutDateTime", SqlDbType.DateTime),
					new SqlParameter("@HouseNo", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectOutStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectOutStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectOutStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectOutCheckStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectOutRemarks", SqlDbType.NVarChar,1000),
					new SqlParameter("@DirectOutCheckYN", SqlDbType.Int),
					new SqlParameter("@SystemDatetimes", SqlDbType.DateTime),
					new SqlParameter("@KWD_ShipNo", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_Custmoer", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_Address", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_ContentPerson", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_Type", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_Del", SqlDbType.VarChar,50),
					new SqlParameter("@isShip", SqlDbType.Int),
					new SqlParameter("@KWD_Telphone", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_WuliuName", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_WuliuNameCode", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_WuliuCode", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_State", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_CwCode", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_CWOutTime", SqlDbType.DateTime),
					new SqlParameter("@KWD_RkHouseNo", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_ReceTime", SqlDbType.DateTime),
					new SqlParameter("@KWD_SCustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_ContractDeliveMethods", SqlDbType.VarChar,50),
                    
					new SqlParameter("@KWD_ShipType", SqlDbType.NVarChar,50),
					new SqlParameter("@KWD_PayMent", SqlDbType.NVarChar,50),
					new SqlParameter("@KWD_KpType", SqlDbType.NVarChar,50),
					new SqlParameter("@KWD_MainProductsBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@KWD_MainProductsNumber", SqlDbType.Int),
					new SqlParameter("@KWD_IsSupp", SqlDbType.Int),
					new SqlParameter("@KWD_Project", SqlDbType.NVarChar,50),
					new SqlParameter("@KWD_SuppNo", SqlDbType.NVarChar,50),
					new SqlParameter("@KWD_LyType", SqlDbType.NVarChar,50),
                    new SqlParameter("@KWD_Order", SqlDbType.NVarChar,50),
                     new SqlParameter("@KWD_UploadUrl", SqlDbType.NVarChar,300),
                      new SqlParameter("@KWD_UploadName", SqlDbType.NVarChar,200)
                                        };
            parameters[0].Value = model.DirectOutNo;
            parameters[1].Value = model.DirectOutTopic;
            parameters[2].Value = model.DirectOutDateTime;
            parameters[3].Value = model.HouseNo;
            parameters[4].Value = model.DirectOutStaffBranch;
            parameters[5].Value = model.DirectOutStaffDepart;
            parameters[6].Value = model.DirectOutStaffNo;
            parameters[7].Value = model.DirectOutCheckStaffNo;
            parameters[8].Value = model.DirectOutRemarks;
            parameters[9].Value = model.DirectOutCheckYN;
            parameters[10].Value = model.SystemDatetimes;
            parameters[11].Value = model.KWD_ShipNo;
            parameters[12].Value = model.KWD_Custmoer;
            parameters[13].Value = model.KWD_Address;
            parameters[14].Value = model.KWD_ContentPerson;
            parameters[15].Value = model.KWD_Type;
            parameters[16].Value = model.KWD_Del;
            parameters[17].Value = model.isShip;
            parameters[18].Value = model.KWD_Telphone;
            parameters[19].Value = model.KWD_WuliuName;
            parameters[20].Value = model.KWD_WuliuNameCode;
            parameters[21].Value = model.KWD_WuliuCode;
            parameters[22].Value = model.KWD_State;
            parameters[23].Value = model.KWD_CwCode;
            parameters[24].Value = model.KWD_CWOutTime;
            parameters[25].Value = model.KWD_RkHouseNo;
            parameters[26].Value = model.KWD_ReceTime;
            parameters[27].Value = model.KWD_SCustomerValue;
            parameters[28].Value = model.KWD_ContractDeliveMethods;
            parameters[29].Value = model.KWD_ShipType;
            parameters[30].Value = model.KWD_PayMent;
            parameters[31].Value = model.KWD_KpType;
            parameters[32].Value = model.KWD_MainProductsBarCode;
            parameters[33].Value = model.KWD_MainProductsNumber;
            parameters[34].Value = model.KWD_IsSupp;
            parameters[35].Value = model.KWD_Project;
            parameters[36].Value = model.KWD_SuppNo;
            parameters[37].Value = model.KWD_LyType;
            parameters[38].Value = model.KWD_Order;
            parameters[39].Value = model.KWD_UploadUrl;
            parameters[40].Value = model.KWD_UploadName;


            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.KNet_WareHouse_DirectOutList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_WareHouse_DirectOutList set ");
            strSql.Append("DirectOutTopic=@DirectOutTopic,");
            strSql.Append("DirectOutDateTime=@DirectOutDateTime,");
            strSql.Append("HouseNo=@HouseNo,");
            strSql.Append("DirectOutStaffBranch=@DirectOutStaffBranch,");
            strSql.Append("DirectOutStaffDepart=@DirectOutStaffDepart,");
            strSql.Append("DirectOutStaffNo=@DirectOutStaffNo,");
            strSql.Append("DirectOutCheckStaffNo=@DirectOutCheckStaffNo,");
            strSql.Append("DirectOutRemarks=@DirectOutRemarks,");
            strSql.Append("DirectOutCheckYN=@DirectOutCheckYN,");
            strSql.Append("SystemDatetimes=@SystemDatetimes,");
            strSql.Append("KWD_ShipNo=@KWD_ShipNo,");
            strSql.Append("KWD_Custmoer=@KWD_Custmoer,");
            strSql.Append("KWD_Address=@KWD_Address,");
            strSql.Append("KWD_ContentPerson=@KWD_ContentPerson,");
            strSql.Append("KWD_Type=@KWD_Type,");
            strSql.Append("KWD_Del=@KWD_Del,isShip=@isShip,");
            strSql.Append("KWD_Telphone=@KWD_Telphone,");
            strSql.Append("KWD_WuliuName=@KWD_WuliuName,");
            strSql.Append("KWD_WuliuNameCode=@KWD_WuliuNameCode,");
            strSql.Append("KWD_WuliuCode=@KWD_WuliuCode,");
            strSql.Append("KWD_State=@KWD_State,");
            strSql.Append("KWD_CWOutTime=@KWD_CWOutTime,");
            strSql.Append("KWD_RkHouseNo=@KWD_RkHouseNo,");
            strSql.Append("KWD_SCustomerValue=@KWD_SCustomerValue,");
            strSql.Append("KWD_ReceTime=@KWD_ReceTime,");
            strSql.Append("KWD_ContractDeliveMethods=@KWD_ContractDeliveMethods,");
            strSql.Append("KWD_ShipType=@KWD_ShipType,");
            strSql.Append("KWD_PayMent=@KWD_PayMent, ");
            strSql.Append("KWD_KpType=@KWD_KpType, ");
            strSql.Append("KWD_MainProductsBarCode=@KWD_MainProductsBarCode, ");
            strSql.Append("KWD_MainProductsNumber=@KWD_MainProductsNumber,  ");
            strSql.Append("KWD_IsSupp=@KWD_IsSupp,  ");
            strSql.Append("KWD_Project=@KWD_Project, ");
            strSql.Append("KWD_SuppNo=@KWD_SuppNo, ");
            strSql.Append("KWD_LyType=@KWD_LyType,");
            strSql.Append("KWD_Order=@KWD_Order, ");

            strSql.Append("KWD_UploadUrl=@KWD_UploadUrl,");
            strSql.Append("KWD_UploadName=@KWD_UploadName ");

            strSql.Append(" where DirectOutNo=@DirectOutNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@DirectOutTopic", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectOutDateTime", SqlDbType.DateTime),
					new SqlParameter("@HouseNo", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectOutStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectOutStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectOutStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectOutCheckStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectOutRemarks", SqlDbType.NVarChar,1000),
					new SqlParameter("@DirectOutCheckYN", SqlDbType.Int),
					new SqlParameter("@SystemDatetimes", SqlDbType.DateTime),
					new SqlParameter("@KWD_ShipNo", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_Custmoer", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_Address", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_ContentPerson", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_Type", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_Del", SqlDbType.VarChar,50),
					new SqlParameter("@isShip", SqlDbType.Int),
					new SqlParameter("@KWD_Telphone", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_WuliuName", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_WuliuNameCode", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_WuliuCode", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_State", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_CWOutTime", SqlDbType.DateTime),
					new SqlParameter("@KWD_RkHouseNo", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_SCustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_ReceTime", SqlDbType.DateTime),
					new SqlParameter("@KWD_ContractDeliveMethods", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_ShipType", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_PayMent", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_KpType", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_MainProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_MainProductsNumber", SqlDbType.Int),
					new SqlParameter("@KWD_IsSupp", SqlDbType.Int),
					new SqlParameter("@KWD_Project", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_SuppNo", SqlDbType.VarChar,50),
					new SqlParameter("@KWD_LyType", SqlDbType.VarChar,50),
                    new SqlParameter("@KWD_Order", SqlDbType.VarChar,50),
                    new SqlParameter("@KWD_UploadUrl", SqlDbType.VarChar,300),
                    new SqlParameter("@KWD_UploadName", SqlDbType.VarChar,200),

                    new SqlParameter("@DirectOutNo", SqlDbType.VarChar,50)};
            parameters[0].Value = model.DirectOutTopic;
            parameters[1].Value = model.DirectOutDateTime;
            parameters[2].Value = model.HouseNo;
            parameters[3].Value = model.DirectOutStaffBranch;
            parameters[4].Value = model.DirectOutStaffDepart;
            parameters[5].Value = model.DirectOutStaffNo;
            parameters[6].Value = model.DirectOutCheckStaffNo;
            parameters[7].Value = model.DirectOutRemarks;
            parameters[8].Value = model.DirectOutCheckYN;
            parameters[9].Value = model.SystemDatetimes;
            parameters[10].Value = model.KWD_ShipNo;
            parameters[11].Value = model.KWD_Custmoer;
            parameters[12].Value = model.KWD_Address;
            parameters[13].Value = model.KWD_ContentPerson;
            parameters[14].Value = model.KWD_Type;
            parameters[15].Value = model.KWD_Del;
            parameters[16].Value = model.isShip;
            parameters[17].Value = model.KWD_Telphone;
            parameters[18].Value = model.KWD_WuliuName;
            parameters[19].Value = model.KWD_WuliuNameCode;
            parameters[20].Value = model.KWD_WuliuCode;
            parameters[21].Value = model.KWD_State;
            parameters[22].Value = model.KWD_CWOutTime;
            parameters[23].Value = model.KWD_RkHouseNo;
            parameters[24].Value = model.KWD_SCustomerValue;
            parameters[25].Value = model.KWD_ReceTime;
            parameters[26].Value = model.KWD_ContractDeliveMethods;
            parameters[27].Value = model.KWD_ShipType;
            parameters[28].Value = model.KWD_PayMent;
            parameters[29].Value = model.KWD_KpType;

            parameters[30].Value = model.KWD_MainProductsBarCode;
            parameters[31].Value = model.KWD_MainProductsNumber;
            parameters[32].Value = model.KWD_IsSupp;
            parameters[33].Value = model.KWD_Project;

            parameters[34].Value = model.KWD_SuppNo;
            parameters[35].Value = model.KWD_LyType;
            parameters[36].Value = model.KWD_Order;
            parameters[37].Value = model.KWD_UploadUrl;
            parameters[38].Value = model.KWD_UploadName;
            parameters[39].Value = model.DirectOutNo;

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


        public bool UpdateByKpType(KNet.Model.KNet_WareHouse_DirectOutList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_WareHouse_DirectOutList set ");
            strSql.Append("KWD_KpType=@KWD_KpType ");
            strSql.Append(" where DirectOutNo=@DirectOutNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@KWD_KpType", SqlDbType.VarChar,50),
					new SqlParameter("@DirectOutNo", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KWD_KpType;
            parameters[1].Value = model.DirectOutNo;

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
        public bool UpDataSate(KNet.Model.KNet_WareHouse_DirectOutList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_WareHouse_DirectOutList set ");
            strSql.Append("KWD_State=@KWD_State");
            strSql.Append(" where DirectOutNo=@DirectOutNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@KWD_State", SqlDbType.VarChar,50),
					new SqlParameter("@DirectOutNo", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KWD_State;
            parameters[1].Value = model.DirectOutNo;

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
        public void Delete(string DirectOutNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@DirectOutNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = DirectOutNo;

            DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_DirectOutList_Delete", parameters, out rowsAffected);
        }
        /// <summary>
        /// 删除
        /// </summary>
        public bool DeleteByTopic(string s_DirectTopic)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_WareHouse_DirectOutList_Details where DirectOutNo in ");
            strSql.Append(" (Select DirectOutNo from KNet_WareHouse_DirectOutList Where DirectOutTopic=@DirectTopic) ");
            strSql.Append(" delete from KNet_WareHouse_DirectOutList Where DirectOutTopic=@DirectTopic1 ");
            SqlParameter[] parameters = {
					new SqlParameter("@DirectTopic", SqlDbType.VarChar,50),
					new SqlParameter("@DirectTopic1", SqlDbType.VarChar,50)};
            parameters[0].Value = s_DirectTopic;
            parameters[1].Value = s_DirectTopic;

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
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_DirectOutList GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from KNet_WareHouse_DirectOutList ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_WareHouse_DirectOutList model = new KNet.Model.KNet_WareHouse_DirectOutList();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["DirectOutNo"] != null && ds.Tables[0].Rows[0]["DirectOutNo"].ToString() != "")
                {
                    model.DirectOutNo = ds.Tables[0].Rows[0]["DirectOutNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DirectOutTopic"] != null && ds.Tables[0].Rows[0]["DirectOutTopic"].ToString() != "")
                {
                    model.DirectOutTopic = ds.Tables[0].Rows[0]["DirectOutTopic"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DirectOutDateTime"] != null && ds.Tables[0].Rows[0]["DirectOutDateTime"].ToString() != "")
                {
                    model.DirectOutDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["DirectOutDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HouseNo"] != null && ds.Tables[0].Rows[0]["HouseNo"].ToString() != "")
                {
                    model.HouseNo = ds.Tables[0].Rows[0]["HouseNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DirectOutStaffBranch"] != null && ds.Tables[0].Rows[0]["DirectOutStaffBranch"].ToString() != "")
                {
                    model.DirectOutStaffBranch = ds.Tables[0].Rows[0]["DirectOutStaffBranch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DirectOutStaffDepart"] != null && ds.Tables[0].Rows[0]["DirectOutStaffDepart"].ToString() != "")
                {
                    model.DirectOutStaffDepart = ds.Tables[0].Rows[0]["DirectOutStaffDepart"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DirectOutStaffNo"] != null && ds.Tables[0].Rows[0]["DirectOutStaffNo"].ToString() != "")
                {
                    model.DirectOutStaffNo = ds.Tables[0].Rows[0]["DirectOutStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DirectOutCheckStaffNo"] != null && ds.Tables[0].Rows[0]["DirectOutCheckStaffNo"].ToString() != "")
                {
                    model.DirectOutCheckStaffNo = ds.Tables[0].Rows[0]["DirectOutCheckStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DirectOutRemarks"] != null && ds.Tables[0].Rows[0]["DirectOutRemarks"].ToString() != "")
                {
                    model.DirectOutRemarks = ds.Tables[0].Rows[0]["DirectOutRemarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DirectOutCheckYN"] != null && ds.Tables[0].Rows[0]["DirectOutCheckYN"].ToString() != "")
                {
                    model.DirectOutCheckYN = int.Parse(ds.Tables[0].Rows[0]["DirectOutCheckYN"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SystemDatetimes"] != null && ds.Tables[0].Rows[0]["SystemDatetimes"].ToString() != "")
                {
                    model.SystemDatetimes = DateTime.Parse(ds.Tables[0].Rows[0]["SystemDatetimes"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KWD_ShipNo"] != null && ds.Tables[0].Rows[0]["KWD_ShipNo"].ToString() != "")
                {
                    model.KWD_ShipNo = ds.Tables[0].Rows[0]["KWD_ShipNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_Custmoer"] != null && ds.Tables[0].Rows[0]["KWD_Custmoer"].ToString() != "")
                {
                    model.KWD_Custmoer = ds.Tables[0].Rows[0]["KWD_Custmoer"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_Address"] != null && ds.Tables[0].Rows[0]["KWD_Address"].ToString() != "")
                {
                    model.KWD_Address = ds.Tables[0].Rows[0]["KWD_Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_ContentPerson"] != null && ds.Tables[0].Rows[0]["KWD_ContentPerson"].ToString() != "")
                {
                    model.KWD_ContentPerson = ds.Tables[0].Rows[0]["KWD_ContentPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_Type"] != null && ds.Tables[0].Rows[0]["KWD_Type"].ToString() != "")
                {
                    model.KWD_Type = ds.Tables[0].Rows[0]["KWD_Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_ReceTime"] != null && ds.Tables[0].Rows[0]["KWD_ReceTime"].ToString() != "")
                {
                    model.KWD_ReceTime = DateTime.Parse(ds.Tables[0].Rows[0]["KWD_ReceTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KWD_SCustomerValue"] != null && ds.Tables[0].Rows[0]["KWD_SCustomerValue"].ToString() != "")
                {
                    model.KWD_SCustomerValue = ds.Tables[0].Rows[0]["KWD_SCustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_RkHouseNo"] != null && ds.Tables[0].Rows[0]["KWD_RkHouseNo"].ToString() != "")
                {
                    model.KWD_RkHouseNo = ds.Tables[0].Rows[0]["KWD_RkHouseNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_Del"] != null && ds.Tables[0].Rows[0]["KWD_Del"].ToString() != "")
                {
                    model.KWD_Del = ds.Tables[0].Rows[0]["KWD_Del"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_ShipType"] != null && ds.Tables[0].Rows[0]["KWD_ShipType"].ToString() != "")
                {
                    model.KWD_ShipType = ds.Tables[0].Rows[0]["KWD_ShipType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_PayMent"] != null && ds.Tables[0].Rows[0]["KWD_PayMent"].ToString() != "")
                {
                    model.KWD_PayMent = ds.Tables[0].Rows[0]["KWD_PayMent"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KWD_MainProductsBarCode"] != null && ds.Tables[0].Rows[0]["KWD_MainProductsBarCode"].ToString() != "")
                {
                    model.KWD_MainProductsBarCode = ds.Tables[0].Rows[0]["KWD_MainProductsBarCode"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KWD_MainProductsNumber"] != null && ds.Tables[0].Rows[0]["KWD_MainProductsNumber"].ToString() != "")
                {
                    model.KWD_MainProductsNumber = int.Parse(ds.Tables[0].Rows[0]["KWD_MainProductsNumber"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KWD_Project"] != null && ds.Tables[0].Rows[0]["KWD_Project"].ToString() != "")
                {
                    model.KWD_Project = ds.Tables[0].Rows[0]["KWD_Project"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KWD_IsSupp"] != null && ds.Tables[0].Rows[0]["KWD_IsSupp"].ToString() != "")
                {
                    model.KWD_IsSupp = int.Parse(ds.Tables[0].Rows[0]["KWD_IsSupp"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KWD_SuppNo"] != null && ds.Tables[0].Rows[0]["KWD_SuppNo"].ToString() != "")
                {
                    model.KWD_SuppNo = ds.Tables[0].Rows[0]["KWD_SuppNo"].ToString();
                }
                
                if (ds.Tables[0].Rows[0]["KWD_LyType"] != null && ds.Tables[0].Rows[0]["KWD_LyType"].ToString() != "")
                {
                    model.KWD_LyType = ds.Tables[0].Rows[0]["KWD_LyType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_Order"] != null && ds.Tables[0].Rows[0]["KWD_Order"].ToString() != "")
                {
                    model.KWD_Order = ds.Tables[0].Rows[0]["KWD_Order"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_UploadUrl"] != null && ds.Tables[0].Rows[0]["KWD_UploadUrl"].ToString() != "")
                {
                    model.KWD_UploadUrl = ds.Tables[0].Rows[0]["KWD_UploadUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_UploadName"] != null && ds.Tables[0].Rows[0]["KWD_UploadName"].ToString() != "")
                {
                    model.KWD_UploadName = ds.Tables[0].Rows[0]["KWD_UploadName"].ToString();
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
        public KNet.Model.KNet_WareHouse_DirectOutList GetModelB(string DirectOutNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from KNet_WareHouse_DirectOutList ");
            strSql.Append(" where DirectOutNo=@DirectOutNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@DirectOutNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = DirectOutNo;

            KNet.Model.KNet_WareHouse_DirectOutList model = new KNet.Model.KNet_WareHouse_DirectOutList();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DirectOutNo"] != null && ds.Tables[0].Rows[0]["DirectOutNo"].ToString() != "")
                {
                    model.DirectOutNo = ds.Tables[0].Rows[0]["DirectOutNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DirectOutTopic"] != null && ds.Tables[0].Rows[0]["DirectOutTopic"].ToString() != "")
                {
                    model.DirectOutTopic = ds.Tables[0].Rows[0]["DirectOutTopic"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DirectOutDateTime"] != null && ds.Tables[0].Rows[0]["DirectOutDateTime"].ToString() != "")
                {
                    model.DirectOutDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["DirectOutDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HouseNo"] != null && ds.Tables[0].Rows[0]["HouseNo"].ToString() != "")
                {
                    model.HouseNo = ds.Tables[0].Rows[0]["HouseNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DirectOutStaffBranch"] != null && ds.Tables[0].Rows[0]["DirectOutStaffBranch"].ToString() != "")
                {
                    model.DirectOutStaffBranch = ds.Tables[0].Rows[0]["DirectOutStaffBranch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DirectOutStaffDepart"] != null && ds.Tables[0].Rows[0]["DirectOutStaffDepart"].ToString() != "")
                {
                    model.DirectOutStaffDepart = ds.Tables[0].Rows[0]["DirectOutStaffDepart"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DirectOutStaffNo"] != null && ds.Tables[0].Rows[0]["DirectOutStaffNo"].ToString() != "")
                {
                    model.DirectOutStaffNo = ds.Tables[0].Rows[0]["DirectOutStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DirectOutCheckStaffNo"] != null && ds.Tables[0].Rows[0]["DirectOutCheckStaffNo"].ToString() != "")
                {
                    model.DirectOutCheckStaffNo = ds.Tables[0].Rows[0]["DirectOutCheckStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DirectOutRemarks"] != null && ds.Tables[0].Rows[0]["DirectOutRemarks"].ToString() != "")
                {
                    model.DirectOutRemarks = ds.Tables[0].Rows[0]["DirectOutRemarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DirectOutCheckYN"] != null && ds.Tables[0].Rows[0]["DirectOutCheckYN"].ToString() != "")
                {
                    model.DirectOutCheckYN = int.Parse(ds.Tables[0].Rows[0]["DirectOutCheckYN"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SystemDatetimes"] != null && ds.Tables[0].Rows[0]["SystemDatetimes"].ToString() != "")
                {
                    model.SystemDatetimes = DateTime.Parse(ds.Tables[0].Rows[0]["SystemDatetimes"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KWD_ShipNo"] != null && ds.Tables[0].Rows[0]["KWD_ShipNo"].ToString() != "")
                {
                    model.KWD_ShipNo = ds.Tables[0].Rows[0]["KWD_ShipNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_Custmoer"] != null && ds.Tables[0].Rows[0]["KWD_Custmoer"].ToString() != "")
                {
                    model.KWD_Custmoer = ds.Tables[0].Rows[0]["KWD_Custmoer"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_Address"] != null && ds.Tables[0].Rows[0]["KWD_Address"].ToString() != "")
                {
                    model.KWD_Address = ds.Tables[0].Rows[0]["KWD_Address"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KWD_Project"] != null && ds.Tables[0].Rows[0]["KWD_Project"].ToString() != "")
                {
                    model.KWD_Project = ds.Tables[0].Rows[0]["KWD_Project"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KWD_IsSupp"] != null && ds.Tables[0].Rows[0]["KWD_IsSupp"].ToString() != "")
                {
                    model.KWD_IsSupp = int.Parse(ds.Tables[0].Rows[0]["KWD_IsSupp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KWD_ContentPerson"] != null && ds.Tables[0].Rows[0]["KWD_ContentPerson"].ToString() != "")
                {
                    model.KWD_ContentPerson = ds.Tables[0].Rows[0]["KWD_ContentPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_Type"] != null && ds.Tables[0].Rows[0]["KWD_Type"].ToString() != "")
                {
                    model.KWD_Type = ds.Tables[0].Rows[0]["KWD_Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_Del"] != null && ds.Tables[0].Rows[0]["KWD_Del"].ToString() != "")
                {
                    model.KWD_Del = ds.Tables[0].Rows[0]["KWD_Del"].ToString();
                }
                if (ds.Tables[0].Rows[0]["isShip"] != null && ds.Tables[0].Rows[0]["isShip"].ToString() != "")
                {
                    model.isShip = int.Parse(ds.Tables[0].Rows[0]["isShip"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KWD_CwCode"] != null && ds.Tables[0].Rows[0]["KWD_CwCode"].ToString() != "")
                {
                    model.KWD_CwCode = ds.Tables[0].Rows[0]["KWD_CwCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_Telphone"] != null && ds.Tables[0].Rows[0]["KWD_Telphone"].ToString() != "")
                {
                    model.KWD_Telphone = ds.Tables[0].Rows[0]["KWD_Telphone"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KWD_WuliuName"] != null && ds.Tables[0].Rows[0]["KWD_WuliuName"].ToString() != "")
                {
                    model.KWD_WuliuName = ds.Tables[0].Rows[0]["KWD_WuliuName"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KWD_WuliuNameCode"] != null && ds.Tables[0].Rows[0]["KWD_WuliuNameCode"].ToString() != "")
                {
                    model.KWD_WuliuNameCode = ds.Tables[0].Rows[0]["KWD_WuliuNameCode"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KWD_WuliuCode"] != null && ds.Tables[0].Rows[0]["KWD_WuliuCode"].ToString() != "")
                {
                    model.KWD_WuliuCode = ds.Tables[0].Rows[0]["KWD_WuliuCode"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KWD_State"] != null && ds.Tables[0].Rows[0]["KWD_State"].ToString() != "")
                {
                    model.KWD_State = ds.Tables[0].Rows[0]["KWD_State"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_CWOutTime"] != null && ds.Tables[0].Rows[0]["KWD_CWOutTime"].ToString() != "")
                {
                    model.KWD_CWOutTime = DateTime.Parse(ds.Tables[0].Rows[0]["KWD_CWOutTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KWD_ReceTime"] != null && ds.Tables[0].Rows[0]["KWD_ReceTime"].ToString() != "")
                {
                    model.KWD_ReceTime = DateTime.Parse(ds.Tables[0].Rows[0]["KWD_ReceTime"].ToString());
                }
                else
                {
                    model.KWD_ReceTime = DateTime.Parse(ds.Tables[0].Rows[0]["DirectOutDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KWD_ContractDeliveMethods"] != null && ds.Tables[0].Rows[0]["KWD_ContractDeliveMethods"].ToString() != "")
                {
                    model.KWD_ContractDeliveMethods = ds.Tables[0].Rows[0]["KWD_ContractDeliveMethods"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_SCustomerValue"] != null && ds.Tables[0].Rows[0]["KWD_SCustomerValue"].ToString() != "")
                {
                    model.KWD_SCustomerValue = ds.Tables[0].Rows[0]["KWD_SCustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_RkHouseNo"] != null && ds.Tables[0].Rows[0]["KWD_RkHouseNo"].ToString() != "")
                {
                    model.KWD_RkHouseNo = ds.Tables[0].Rows[0]["KWD_RkHouseNo"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KWD_LlState"] != null && ds.Tables[0].Rows[0]["KWD_LlState"].ToString() != "")
                {
                    model.KWD_LlState = int.Parse(ds.Tables[0].Rows[0]["KWD_LlState"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KWD_HQState"] != null && ds.Tables[0].Rows[0]["KWD_HQState"].ToString() != "")
                {
                    model.KWD_HQState = int.Parse(ds.Tables[0].Rows[0]["KWD_HQState"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KWD_HQPerson"] != null && ds.Tables[0].Rows[0]["KWD_HQPerson"].ToString() != "")
                {
                    model.KWD_HQPerson = ds.Tables[0].Rows[0]["KWD_HQPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_KpType"] != null && ds.Tables[0].Rows[0]["KWD_KpType"].ToString() != "")
                {
                    model.KWD_KpType = ds.Tables[0].Rows[0]["KWD_KpType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_PayMent"] != null && ds.Tables[0].Rows[0]["KWD_PayMent"].ToString() != "")
                {
                    model.KWD_PayMent = ds.Tables[0].Rows[0]["KWD_PayMent"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_MainProductsBarCode"] != null && ds.Tables[0].Rows[0]["KWD_MainProductsBarCode"].ToString() != "")
                {
                    model.KWD_MainProductsBarCode = ds.Tables[0].Rows[0]["KWD_MainProductsBarCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_MainProductsNumber"] != null && ds.Tables[0].Rows[0]["KWD_MainProductsNumber"].ToString() != "")
                {
                    model.KWD_MainProductsNumber = int.Parse(ds.Tables[0].Rows[0]["KWD_MainProductsNumber"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KWD_SuppNo"] != null && ds.Tables[0].Rows[0]["KWD_SuppNo"].ToString() != "")
                {
                    model.KWD_SuppNo = ds.Tables[0].Rows[0]["KWD_SuppNo"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KWD_LyType"] != null && ds.Tables[0].Rows[0]["KWD_LyType"].ToString() != "")
                {
                    model.KWD_LyType = ds.Tables[0].Rows[0]["KWD_LyType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_Order"] != null && ds.Tables[0].Rows[0]["KWD_Order"].ToString() != "")
                {
                    model.KWD_Order = ds.Tables[0].Rows[0]["KWD_Order"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_UploadUrl"] != null && ds.Tables[0].Rows[0]["KWD_UploadUrl"].ToString() != "")
                {
                    model.KWD_UploadUrl = ds.Tables[0].Rows[0]["KWD_UploadUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KWD_UploadName"] != null && ds.Tables[0].Rows[0]["KWD_UploadName"].ToString() != "")
                {
                    model.KWD_UploadName = ds.Tables[0].Rows[0]["KWD_UploadName"].ToString();
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
            strSql.Append(" FROM KNet_WareHouse_DirectOutList left join v_DirectOut_ReceiveState  on v_DirectOutNo= DirectOutNo  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 查询车间库报废领用数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select * ");
            strSql.Append(" select* from KNet_WareHouse_DirectOutList_Details a join KNet_WareHouse_DirectOutList b on a.DirectOutNo=b.DirectOutNo  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListJoinSalesShip(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM KNet_WareHouse_DirectOutList a left join KNet_Sales_OutWareList b on a.KWD_ShipNo=b.OutWareNo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  成员方法
    }
}


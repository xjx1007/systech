using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sales_OutWareList。
    /// </summary>
    public class KNet_Sales_OutWareList
    {
        public KNet_Sales_OutWareList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string OutWareNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@OutWareNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = OutWareNo;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sales_OutWareList_Exists", parameters, out rowsAffected);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }	/// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.KNet_Sales_OutWareList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Sales_OutWareList(");
            strSql.Append("OutWareNo,OutWareTopic,OutWareDateTime,ContractNo,CustomerValue,ContractTranShare,OutWareOursContact,OutWareSideContact,ContractToAddress,ContractDeliveMethods,OutWareStaffBranch,OutWareStaffDepart,OutWareStaffNo,OutWareCheckStaffNo,OutWareRemarks,OutWareCheckYN,KSO_TelPhone,KSO_PlanOutWareDateTime,KSO_MDate,KSO_Mreator,KSO_ShRemark,KSO_SuppNoRemarks,DutyPerson,KSO_ContentPersonName,KSO_WareHouseNo,KSO_ShipType,KSO_MaterNumber,KSO_OrderNo,KSO_PlanNo,KSO_Type,KSO_SCustomerValue,KSO_FhDetails,KSO_PayMent,KSO_ContentPersonID,KSO_KpType)");
            strSql.Append(" values (");
            strSql.Append("@OutWareNo,@OutWareTopic,@OutWareDateTime,@ContractNo,@CustomerValue,@ContractTranShare,@OutWareOursContact,@OutWareSideContact,@ContractToAddress,@ContractDeliveMethods,@OutWareStaffBranch,@OutWareStaffDepart,@OutWareStaffNo,@OutWareCheckStaffNo,@OutWareRemarks,@OutWareCheckYN,@KSO_TelPhone,@KSO_PlanOutWareDateTime,@KSO_MDate,@KSO_Mreator,@KSO_ShRemark,@KSO_SuppNoRemarks,@DutyPerson,@KSO_ContentPersonName,@KSO_WareHouseNo,@KSO_ShipType,@KSO_MaterNumber,@KSO_OrderNo,@KSO_PlanNo,@KSO_Type,@KSO_SCustomerValue,@KSO_FhDetails,@KSO_PayMent,@KSO_ContentPersonID,@KSO_KpType)");
            SqlParameter[] parameters = {
					new SqlParameter("@OutWareNo", SqlDbType.NVarChar,50),
					new SqlParameter("@OutWareTopic", SqlDbType.NVarChar,50),
					new SqlParameter("@OutWareDateTime", SqlDbType.DateTime),
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,350),
					new SqlParameter("@CustomerValue", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractTranShare", SqlDbType.Decimal,9),
					new SqlParameter("@OutWareOursContact", SqlDbType.NVarChar,50),
					new SqlParameter("@OutWareSideContact", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractToAddress", SqlDbType.NVarChar,250),
					new SqlParameter("@ContractDeliveMethods", SqlDbType.NVarChar,50),
					new SqlParameter("@OutWareStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@OutWareStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@OutWareStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@OutWareCheckStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@OutWareRemarks", SqlDbType.NVarChar,1000),
					new SqlParameter("@OutWareCheckYN", SqlDbType.Bit,1),
					new SqlParameter("@KSO_TelPhone", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_PlanOutWareDateTime", SqlDbType.DateTime),
					new SqlParameter("@KSO_MDate", SqlDbType.DateTime),
					new SqlParameter("@KSO_Mreator", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_ShRemark", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_SuppNoRemarks", SqlDbType.VarChar,200),
					new SqlParameter("@DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_ContentPersonName", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_WareHouseNo", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_ShipType", SqlDbType.VarChar,250),
					new SqlParameter("@KSO_MaterNumber", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_OrderNo", SqlDbType.VarChar,250),
					new SqlParameter("@KSO_PlanNo", SqlDbType.VarChar,250),
					new SqlParameter("@KSO_Type", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_SCustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_FhDetails", SqlDbType.VarChar,5000),
					new SqlParameter("@KSO_PayMent", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_ContentPersonID", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_KpType", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = model.OutWareNo;
            parameters[1].Value = model.OutWareTopic;
            parameters[2].Value = model.OutWareDateTime;
            parameters[3].Value = model.ContractNo;
            parameters[4].Value = model.CustomerValue;
            parameters[5].Value = model.ContractTranShare;
            parameters[6].Value = model.OutWareOursContact;
            parameters[7].Value = model.OutWareSideContact;
            parameters[8].Value = model.ContractToAddress;
            parameters[9].Value = model.ContractDeliveMethods;
            parameters[10].Value = model.OutWareStaffBranch;
            parameters[11].Value = model.OutWareStaffDepart;
            parameters[12].Value = model.OutWareStaffNo;
            parameters[13].Value = model.OutWareCheckStaffNo;
            parameters[14].Value = model.OutWareRemarks;
            parameters[15].Value = model.OutWareCheckYN;
            parameters[16].Value = model.KSO_TelPhone;
            parameters[17].Value = model.KSO_PlanOutWareDateTime;
            parameters[18].Value = model.KSO_MDate;
            parameters[19].Value = model.KSO_Mreator;
            parameters[20].Value = model.KSO_ShRemark;
            parameters[21].Value = model.KSO_SuppNoRemarks;
            parameters[22].Value = model.DutyPerson;
            parameters[23].Value = model.KSO_ContentPersonName;
            parameters[24].Value = model.KSO_WareHouseNo;
            parameters[25].Value = model.KSO_ShipType;
            parameters[26].Value = model.KSO_MaterNumber;
            parameters[27].Value = model.KSO_OrderNo;
            parameters[28].Value = model.KSO_PlanNo;
            parameters[29].Value = model.KSO_Type;
            parameters[30].Value = model.KSO_SCustomerValue;
            parameters[31].Value = model.KSO_FhDetails;
            parameters[32].Value = model.KSO_PayMent;
            parameters[33].Value = model.KSO_ContentPersonID;
            parameters[34].Value = model.KSO_KpType;
            
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
        public bool Update(KNet.Model.KNet_Sales_OutWareList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Sales_OutWareList set ");
            strSql.Append("OutWareTopic=@OutWareTopic,");
            strSql.Append("OutWareDateTime=@OutWareDateTime,");
            strSql.Append("ContractNo=@ContractNo,");
            strSql.Append("CustomerValue=@CustomerValue,");
            strSql.Append("ContractTranShare=@ContractTranShare,");
            strSql.Append("OutWareOursContact=@OutWareOursContact,");
            strSql.Append("OutWareSideContact=@OutWareSideContact,");
            strSql.Append("ContractToAddress=@ContractToAddress,");
            strSql.Append("ContractDeliveMethods=@ContractDeliveMethods,");
            strSql.Append("OutWareStaffBranch=@OutWareStaffBranch,");
            strSql.Append("OutWareStaffDepart=@OutWareStaffDepart,");
            strSql.Append("OutWareStaffNo=@OutWareStaffNo,");
            strSql.Append("OutWareCheckStaffNo=@OutWareCheckStaffNo,");
            strSql.Append("OutWareRemarks=@OutWareRemarks,");
            strSql.Append("OutWareCheckYN=@OutWareCheckYN,");
            strSql.Append("KSO_TelPhone=@KSO_TelPhone,");
            strSql.Append("KSO_PlanOutWareDateTime=@KSO_PlanOutWareDateTime,");
            strSql.Append("KSO_MDate=@KSO_MDate,");
            strSql.Append("KSO_Mreator=@KSO_Mreator,");
            strSql.Append("KSO_ShRemark=@KSO_ShRemark,");
            strSql.Append("KSO_SuppNoRemarks=@KSO_SuppNoRemarks,");
            strSql.Append("DutyPerson=@DutyPerson,");
            strSql.Append("KSO_ContentPersonName=@KSO_ContentPersonName,");
            strSql.Append("KSO_WareHouseNo=@KSO_WareHouseNo,");
            strSql.Append("KSO_ShipType=@KSO_ShipType,");
            strSql.Append("KSO_MaterNumber=@KSO_MaterNumber,");
            strSql.Append("KSO_OrderNo=@KSO_OrderNo,");
            strSql.Append("KSO_PlanNo=@KSO_PlanNo,");
            strSql.Append("KSO_Type=@KSO_Type,");
            strSql.Append("KSO_SCustomerValue=@KSO_SCustomerValue,");
            strSql.Append("KSO_FhDetails=@KSO_FhDetails,");
            strSql.Append("KSO_PayMent=@KSO_PayMent, ");
            strSql.Append("KSO_ContentPersonID=@KSO_ContentPersonID,");
            strSql.Append("KSO_KpType=@KSO_KpType ");
            
            strSql.Append(" where OutWareNo=@OutWareNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@OutWareTopic", SqlDbType.NVarChar,50),
					new SqlParameter("@OutWareDateTime", SqlDbType.DateTime),
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,350),
					new SqlParameter("@CustomerValue", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractTranShare", SqlDbType.Decimal,9),
					new SqlParameter("@OutWareOursContact", SqlDbType.NVarChar,50),
					new SqlParameter("@OutWareSideContact", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractToAddress", SqlDbType.NVarChar,250),
					new SqlParameter("@ContractDeliveMethods", SqlDbType.NVarChar,50),
					new SqlParameter("@OutWareStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@OutWareStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@OutWareStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@OutWareCheckStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@OutWareRemarks", SqlDbType.NVarChar,1000),
					new SqlParameter("@OutWareCheckYN", SqlDbType.Bit,1),
					new SqlParameter("@KSO_TelPhone", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_PlanOutWareDateTime", SqlDbType.DateTime),
					new SqlParameter("@KSO_MDate", SqlDbType.DateTime),
					new SqlParameter("@KSO_Mreator", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_ShRemark", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_SuppNoRemarks", SqlDbType.VarChar,200),
					new SqlParameter("@DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_ContentPersonName", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_WareHouseNo", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_ShipType", SqlDbType.VarChar,250),
					new SqlParameter("@KSO_MaterNumber", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_OrderNo", SqlDbType.VarChar,250),
					new SqlParameter("@KSO_PlanNo", SqlDbType.VarChar,250),
					new SqlParameter("@KSO_Type", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_SCustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_FhDetails", SqlDbType.VarChar,500),
					new SqlParameter("@KSO_PayMent", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_ContentPersonID", SqlDbType.VarChar,50),
					new SqlParameter("@KSO_KpType", SqlDbType.VarChar,50),
                    
					new SqlParameter("@OutWareNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.OutWareTopic;
            parameters[1].Value = model.OutWareDateTime;
            parameters[2].Value = model.ContractNo;
            parameters[3].Value = model.CustomerValue;
            parameters[4].Value = model.ContractTranShare;
            parameters[5].Value = model.OutWareOursContact;
            parameters[6].Value = model.OutWareSideContact;
            parameters[7].Value = model.ContractToAddress;
            parameters[8].Value = model.ContractDeliveMethods;
            parameters[9].Value = model.OutWareStaffBranch;
            parameters[10].Value = model.OutWareStaffDepart;
            parameters[11].Value = model.OutWareStaffNo;
            parameters[12].Value = model.OutWareCheckStaffNo;
            parameters[13].Value = model.OutWareRemarks;
            parameters[14].Value = model.OutWareCheckYN;
            parameters[15].Value = model.KSO_TelPhone;
            parameters[16].Value = model.KSO_PlanOutWareDateTime;
            parameters[17].Value = model.KSO_MDate;
            parameters[18].Value = model.KSO_Mreator;
            parameters[19].Value = model.KSO_ShRemark;
            parameters[20].Value = model.KSO_SuppNoRemarks;
            parameters[21].Value = model.DutyPerson;
            parameters[22].Value = model.KSO_ContentPersonName;
            parameters[23].Value = model.KSO_WareHouseNo;
            parameters[24].Value = model.KSO_ShipType;
            parameters[25].Value = model.KSO_MaterNumber;
            parameters[26].Value = model.KSO_OrderNo;
            parameters[27].Value = model.KSO_PlanNo;
            parameters[28].Value = model.KSO_Type;
            parameters[29].Value = model.KSO_SCustomerValue;
            parameters[30].Value = model.KSO_FhDetails;
            parameters[31].Value = model.KSO_PayMent;
            parameters[32].Value = model.KSO_ContentPersonID;
            parameters[33].Value = model.KSO_KpType;
            
            parameters[34].Value = model.OutWareNo;

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
        public void Delete(string OutWareNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@OutWareNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = OutWareNo;

            DbHelperSQL.RunProcedure("Proc_KNet_Sales_OutWareList_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_OutWareList GetModel(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_Sales_OutWareList model = new KNet.Model.KNet_Sales_OutWareList();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_Sales_OutWareList_GetModelByID", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.OutWareNo = ds.Tables[0].Rows[0]["OutWareNo"].ToString();
                model.OutWareTopic = ds.Tables[0].Rows[0]["OutWareTopic"].ToString();
                if (ds.Tables[0].Rows[0]["OutWareDateTime"].ToString() != "")
                {
                    model.OutWareDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["OutWareDateTime"].ToString());
                }
                model.ContractNo = ds.Tables[0].Rows[0]["ContractNo"].ToString();
                model.CustomerValue = ds.Tables[0].Rows[0]["CustomerValue"].ToString();
                if (ds.Tables[0].Rows[0]["ContractTranShare"].ToString() != "")
                {
                    model.ContractTranShare = decimal.Parse(ds.Tables[0].Rows[0]["ContractTranShare"].ToString());
                }
                model.OutWareOursContact = ds.Tables[0].Rows[0]["OutWareOursContact"].ToString();
                model.OutWareSideContact = ds.Tables[0].Rows[0]["OutWareSideContact"].ToString();
                model.ContractToAddress = ds.Tables[0].Rows[0]["ContractToAddress"].ToString();
                model.ContractDeliveMethods = ds.Tables[0].Rows[0]["ContractDeliveMethods"].ToString();
                model.OutWareStaffBranch = ds.Tables[0].Rows[0]["OutWareStaffBranch"].ToString();
                model.OutWareStaffDepart = ds.Tables[0].Rows[0]["OutWareStaffDepart"].ToString();
                model.OutWareStaffNo = ds.Tables[0].Rows[0]["OutWareStaffNo"].ToString();
                model.OutWareCheckStaffNo = ds.Tables[0].Rows[0]["OutWareCheckStaffNo"].ToString();
                model.OutWareRemarks = ds.Tables[0].Rows[0]["OutWareRemarks"].ToString();
                if (ds.Tables[0].Rows[0]["OutWareCheckYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["OutWareCheckYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["OutWareCheckYN"].ToString().ToLower() == "true"))
                    {
                        model.OutWareCheckYN = true;
                    }
                    else
                    {
                        model.OutWareCheckYN = false;
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
        public KNet.Model.KNet_Sales_OutWareList GetModelB(string OutWareNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from KNet_Sales_OutWareList ");
            strSql.Append(" where OutWareNo=@OutWareNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@OutWareNo", SqlDbType.NVarChar,50)			};
            parameters[0].Value = OutWareNo;

            KNet.Model.KNet_Sales_OutWareList model = new KNet.Model.KNet_Sales_OutWareList();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["OutWareNo"] != null && ds.Tables[0].Rows[0]["OutWareNo"].ToString() != "")
                {
                    model.OutWareNo = ds.Tables[0].Rows[0]["OutWareNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OutWareTopic"] != null && ds.Tables[0].Rows[0]["OutWareTopic"].ToString() != "")
                {
                    model.OutWareTopic = ds.Tables[0].Rows[0]["OutWareTopic"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OutWareDateTime"] != null && ds.Tables[0].Rows[0]["OutWareDateTime"].ToString() != "")
                {
                    model.OutWareDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["OutWareDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContractNo"] != null && ds.Tables[0].Rows[0]["ContractNo"].ToString() != "")
                {
                    model.ContractNo = ds.Tables[0].Rows[0]["ContractNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerValue"] != null && ds.Tables[0].Rows[0]["CustomerValue"].ToString() != "")
                {
                    model.CustomerValue = ds.Tables[0].Rows[0]["CustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractTranShare"] != null && ds.Tables[0].Rows[0]["ContractTranShare"].ToString() != "")
                {
                    model.ContractTranShare = decimal.Parse(ds.Tables[0].Rows[0]["ContractTranShare"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutWareOursContact"] != null && ds.Tables[0].Rows[0]["OutWareOursContact"].ToString() != "")
                {
                    model.OutWareOursContact = ds.Tables[0].Rows[0]["OutWareOursContact"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OutWareSideContact"] != null && ds.Tables[0].Rows[0]["OutWareSideContact"].ToString() != "")
                {
                    model.OutWareSideContact = ds.Tables[0].Rows[0]["OutWareSideContact"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractToAddress"] != null && ds.Tables[0].Rows[0]["ContractToAddress"].ToString() != "")
                {
                    model.ContractToAddress = ds.Tables[0].Rows[0]["ContractToAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractDeliveMethods"] != null && ds.Tables[0].Rows[0]["ContractDeliveMethods"].ToString() != "")
                {
                    model.ContractDeliveMethods = ds.Tables[0].Rows[0]["ContractDeliveMethods"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OutWareStaffBranch"] != null && ds.Tables[0].Rows[0]["OutWareStaffBranch"].ToString() != "")
                {
                    model.OutWareStaffBranch = ds.Tables[0].Rows[0]["OutWareStaffBranch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OutWareStaffDepart"] != null && ds.Tables[0].Rows[0]["OutWareStaffDepart"].ToString() != "")
                {
                    model.OutWareStaffDepart = ds.Tables[0].Rows[0]["OutWareStaffDepart"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OutWareStaffNo"] != null && ds.Tables[0].Rows[0]["OutWareStaffNo"].ToString() != "")
                {
                    model.OutWareStaffNo = ds.Tables[0].Rows[0]["OutWareStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OutWareCheckStaffNo"] != null && ds.Tables[0].Rows[0]["OutWareCheckStaffNo"].ToString() != "")
                {
                    model.OutWareCheckStaffNo = ds.Tables[0].Rows[0]["OutWareCheckStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OutWareRemarks"] != null && ds.Tables[0].Rows[0]["OutWareRemarks"].ToString() != "")
                {
                    model.OutWareRemarks = ds.Tables[0].Rows[0]["OutWareRemarks"].ToString();
                }
                else
                {
                    model.OutWareRemarks = "";
                }
                if (ds.Tables[0].Rows[0]["OutWareCheckYN"] != null && ds.Tables[0].Rows[0]["OutWareCheckYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["OutWareCheckYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["OutWareCheckYN"].ToString().ToLower() == "true"))
                    {
                        model.OutWareCheckYN = true;
                    }
                    else
                    {
                        model.OutWareCheckYN = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["KSO_TelPhone"] != null && ds.Tables[0].Rows[0]["KSO_TelPhone"].ToString() != "")
                {
                    model.KSO_TelPhone = ds.Tables[0].Rows[0]["KSO_TelPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSO_PlanOutWareDateTime"] != null && ds.Tables[0].Rows[0]["KSO_PlanOutWareDateTime"].ToString() != "")
                {
                    model.KSO_PlanOutWareDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["KSO_PlanOutWareDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KSO_MDate"] != null && ds.Tables[0].Rows[0]["KSO_MDate"].ToString() != "")
                {
                    model.KSO_MDate = DateTime.Parse(ds.Tables[0].Rows[0]["KSO_MDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KSO_Mreator"] != null && ds.Tables[0].Rows[0]["KSO_Mreator"].ToString() != "")
                {
                    model.KSO_Mreator = ds.Tables[0].Rows[0]["KSO_Mreator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSO_ShRemark"] != null && ds.Tables[0].Rows[0]["KSO_ShRemark"].ToString() != "")
                {
                    model.KSO_ShRemark = ds.Tables[0].Rows[0]["KSO_ShRemark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSO_SuppNoRemarks"] != null && ds.Tables[0].Rows[0]["KSO_SuppNoRemarks"].ToString() != "")
                {
                    model.KSO_SuppNoRemarks = ds.Tables[0].Rows[0]["KSO_SuppNoRemarks"].ToString();
                }
                else
                {
                    model.KSO_SuppNoRemarks = "";
                }
                if (ds.Tables[0].Rows[0]["DutyPerson"] != null && ds.Tables[0].Rows[0]["DutyPerson"].ToString() != "")
                {
                    model.DutyPerson = ds.Tables[0].Rows[0]["DutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSO_ContentPersonName"] != null && ds.Tables[0].Rows[0]["KSO_ContentPersonName"].ToString() != "")
                {
                    model.KSO_ContentPersonName = ds.Tables[0].Rows[0]["KSO_ContentPersonName"].ToString();
                }
                else
                {
                    model.KSO_ContentPersonName = "";
                }
                if (ds.Tables[0].Rows[0]["KSO_ShipType"] != null && ds.Tables[0].Rows[0]["KSO_ShipType"].ToString() != "")
                {
                    model.KSO_ShipType = ds.Tables[0].Rows[0]["KSO_ShipType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSO_MaterNumber"] != null && ds.Tables[0].Rows[0]["KSO_MaterNumber"].ToString() != "")
                {
                    model.KSO_MaterNumber = ds.Tables[0].Rows[0]["KSO_MaterNumber"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSO_OrderNo"] != null && ds.Tables[0].Rows[0]["KSO_OrderNo"].ToString() != "")
                {
                    model.KSO_OrderNo = ds.Tables[0].Rows[0]["KSO_OrderNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSO_PlanNo"] != null && ds.Tables[0].Rows[0]["KSO_PlanNo"].ToString() != "")
                {
                    model.KSO_PlanNo = ds.Tables[0].Rows[0]["KSO_PlanNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSO_SCustomerValue"] != null && ds.Tables[0].Rows[0]["KSO_SCustomerValue"].ToString() != "")
                {
                    model.KSO_SCustomerValue = ds.Tables[0].Rows[0]["KSO_SCustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSO_Type"] != null && ds.Tables[0].Rows[0]["KSO_Type"].ToString() != "")
                {
                    model.KSO_Type = ds.Tables[0].Rows[0]["KSO_Type"].ToString();
                }
                else
                {
                    model.KSO_Type = "0";
                }
                if (ds.Tables[0].Rows[0]["KSO_FhDetails"] != null && ds.Tables[0].Rows[0]["KSO_FhDetails"].ToString() != "")
                {
                    model.KSO_FhDetails = ds.Tables[0].Rows[0]["KSO_FhDetails"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSO_PayMent"] != null && ds.Tables[0].Rows[0]["KSO_PayMent"].ToString() != "")
                {
                    model.KSO_PayMent = ds.Tables[0].Rows[0]["KSO_PayMent"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSO_ContentPersonID"] != null && ds.Tables[0].Rows[0]["KSO_ContentPersonID"].ToString() != "")
                {
                    model.KSO_ContentPersonID = ds.Tables[0].Rows[0]["KSO_ContentPersonID"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KSO_KpType"] != null && ds.Tables[0].Rows[0]["KSO_KpType"].ToString() != "")
                {
                    model.KSO_KpType = ds.Tables[0].Rows[0]["KSO_KpType"].ToString();
                }
                
                return model;
            }
            else
            {
                return null;
            }
        }

        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_OutWareList GetLaseModel(string s_CustomerValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from KNet_Sales_OutWareList ");
            strSql.Append(" where CustomerValue=@CustomerValue Order by SystemDateTimes desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@CustomerValue", SqlDbType.NVarChar,50)			};
            parameters[0].Value = s_CustomerValue;

            KNet.Model.KNet_Sales_OutWareList model = new KNet.Model.KNet_Sales_OutWareList();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["OutWareNo"] != null && ds.Tables[0].Rows[0]["OutWareNo"].ToString() != "")
                {
                    model.OutWareNo = ds.Tables[0].Rows[0]["OutWareNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OutWareTopic"] != null && ds.Tables[0].Rows[0]["OutWareTopic"].ToString() != "")
                {
                    model.OutWareTopic = ds.Tables[0].Rows[0]["OutWareTopic"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OutWareDateTime"] != null && ds.Tables[0].Rows[0]["OutWareDateTime"].ToString() != "")
                {
                    model.OutWareDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["OutWareDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContractNo"] != null && ds.Tables[0].Rows[0]["ContractNo"].ToString() != "")
                {
                    model.ContractNo = ds.Tables[0].Rows[0]["ContractNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerValue"] != null && ds.Tables[0].Rows[0]["CustomerValue"].ToString() != "")
                {
                    model.CustomerValue = ds.Tables[0].Rows[0]["CustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractTranShare"] != null && ds.Tables[0].Rows[0]["ContractTranShare"].ToString() != "")
                {
                    model.ContractTranShare = decimal.Parse(ds.Tables[0].Rows[0]["ContractTranShare"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutWareOursContact"] != null && ds.Tables[0].Rows[0]["OutWareOursContact"].ToString() != "")
                {
                    model.OutWareOursContact = ds.Tables[0].Rows[0]["OutWareOursContact"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OutWareSideContact"] != null && ds.Tables[0].Rows[0]["OutWareSideContact"].ToString() != "")
                {
                    model.OutWareSideContact = ds.Tables[0].Rows[0]["OutWareSideContact"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractToAddress"] != null && ds.Tables[0].Rows[0]["ContractToAddress"].ToString() != "")
                {
                    model.ContractToAddress = ds.Tables[0].Rows[0]["ContractToAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ContractDeliveMethods"] != null && ds.Tables[0].Rows[0]["ContractDeliveMethods"].ToString() != "")
                {
                    model.ContractDeliveMethods = ds.Tables[0].Rows[0]["ContractDeliveMethods"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OutWareStaffBranch"] != null && ds.Tables[0].Rows[0]["OutWareStaffBranch"].ToString() != "")
                {
                    model.OutWareStaffBranch = ds.Tables[0].Rows[0]["OutWareStaffBranch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OutWareStaffDepart"] != null && ds.Tables[0].Rows[0]["OutWareStaffDepart"].ToString() != "")
                {
                    model.OutWareStaffDepart = ds.Tables[0].Rows[0]["OutWareStaffDepart"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OutWareStaffNo"] != null && ds.Tables[0].Rows[0]["OutWareStaffNo"].ToString() != "")
                {
                    model.OutWareStaffNo = ds.Tables[0].Rows[0]["OutWareStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OutWareCheckStaffNo"] != null && ds.Tables[0].Rows[0]["OutWareCheckStaffNo"].ToString() != "")
                {
                    model.OutWareCheckStaffNo = ds.Tables[0].Rows[0]["OutWareCheckStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OutWareRemarks"] != null && ds.Tables[0].Rows[0]["OutWareRemarks"].ToString() != "")
                {
                    model.OutWareRemarks = ds.Tables[0].Rows[0]["OutWareRemarks"].ToString();
                }
                else
                {
                    model.OutWareRemarks = "";
                }
                if (ds.Tables[0].Rows[0]["OutWareCheckYN"] != null && ds.Tables[0].Rows[0]["OutWareCheckYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["OutWareCheckYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["OutWareCheckYN"].ToString().ToLower() == "true"))
                    {
                        model.OutWareCheckYN = true;
                    }
                    else
                    {
                        model.OutWareCheckYN = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["KSO_TelPhone"] != null && ds.Tables[0].Rows[0]["KSO_TelPhone"].ToString() != "")
                {
                    model.KSO_TelPhone = ds.Tables[0].Rows[0]["KSO_TelPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSO_PlanOutWareDateTime"] != null && ds.Tables[0].Rows[0]["KSO_PlanOutWareDateTime"].ToString() != "")
                {
                    model.KSO_PlanOutWareDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["KSO_PlanOutWareDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KSO_MDate"] != null && ds.Tables[0].Rows[0]["KSO_MDate"].ToString() != "")
                {
                    model.KSO_MDate = DateTime.Parse(ds.Tables[0].Rows[0]["KSO_MDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KSO_Mreator"] != null && ds.Tables[0].Rows[0]["KSO_Mreator"].ToString() != "")
                {
                    model.KSO_Mreator = ds.Tables[0].Rows[0]["KSO_Mreator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSO_ShRemark"] != null && ds.Tables[0].Rows[0]["KSO_ShRemark"].ToString() != "")
                {
                    model.KSO_ShRemark = ds.Tables[0].Rows[0]["KSO_ShRemark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSO_SuppNoRemarks"] != null && ds.Tables[0].Rows[0]["KSO_SuppNoRemarks"].ToString() != "")
                {
                    model.KSO_SuppNoRemarks = ds.Tables[0].Rows[0]["KSO_SuppNoRemarks"].ToString();
                }
                else
                {
                    model.KSO_SuppNoRemarks = "";
                }
                if (ds.Tables[0].Rows[0]["DutyPerson"] != null && ds.Tables[0].Rows[0]["DutyPerson"].ToString() != "")
                {
                    model.DutyPerson = ds.Tables[0].Rows[0]["DutyPerson"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KSO_ContentPersonName"] != null && ds.Tables[0].Rows[0]["KSO_ContentPersonName"].ToString() != "")
                {
                    model.KSO_ContentPersonName = ds.Tables[0].Rows[0]["KSO_ContentPersonName"].ToString();
                }
                else
                {
                    model.KSO_ContentPersonName = "";
                }
                if (ds.Tables[0].Rows[0]["KSO_ShipType"] != null && ds.Tables[0].Rows[0]["KSO_ShipType"].ToString() != "")
                {
                    model.KSO_ShipType = ds.Tables[0].Rows[0]["KSO_ShipType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSO_Type"] != null && ds.Tables[0].Rows[0]["KSO_Type"].ToString() != "")
                {
                    model.KSO_Type = ds.Tables[0].Rows[0]["KSO_Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSO_MaterNumber"] != null && ds.Tables[0].Rows[0]["KSO_MaterNumber"].ToString() != "")
                {
                    model.KSO_MaterNumber = ds.Tables[0].Rows[0]["KSO_MaterNumber"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSO_OrderNo"] != null && ds.Tables[0].Rows[0]["KSO_OrderNo"].ToString() != "")
                {
                    model.KSO_OrderNo = ds.Tables[0].Rows[0]["KSO_OrderNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSO_PlanNo"] != null && ds.Tables[0].Rows[0]["KSO_PlanNo"].ToString() != "")
                {
                    model.KSO_PlanNo = ds.Tables[0].Rows[0]["KSO_PlanNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSO_SCustomerValue"] != null && ds.Tables[0].Rows[0]["KSO_SCustomerValue"].ToString() != "")
                {
                    model.KSO_SCustomerValue = ds.Tables[0].Rows[0]["KSO_SCustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSO_KpType"] != null && ds.Tables[0].Rows[0]["KSO_KpType"].ToString() != "")
                {
                    model.KSO_KpType = ds.Tables[0].Rows[0]["KSO_KpType"].ToString();
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
            strSql.Append(" FROM KNet_Sales_OutWareList left join v_OutWare_ReceiveState  on v_KWD_ShipNo = OutWareNo ");
            strSql.Append(" left join v_Saleship_OutState  on VO_OutWareNo= OutWareNo ");
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
            strSql.Append(" ID,OutWareNo,OutWareTopic,OutWareDateTime,ContractNo,CustomerValue,ContractTranShare,OutWareOursContact,OutWareSideContact,ContractToAddress,ContractDeliveMethods,OutWareStaffBranch,OutWareStaffDepart,OutWareStaffNo,OutWareCheckStaffNo,OutWareRemarks,OutWareCheckYN ");
            strSql.Append(" FROM KNet_Sales_OutWareList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类Knet_Procure_OrdersList 采购单列表
    /// </summary>
    public class Knet_Procure_OrdersList
    {
        public Knet_Procure_OrdersList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string OrderNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = OrderNo;

            int result = DbHelperSQL.RunProcedure("Proc_Knet_Procure_OrdersList_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.Knet_Procure_OrdersList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Knet_Procure_OrdersList(");
            strSql.Append("OrderTopic,OrderNo,OrderDateTime,OrderPreToDate,SuppNo,OrderPaymentNotes,OrderStaffBranch,OrderStaffDepart,OrderStaffNo,OrderCheckStaffNo,OrderTransShare,OrderType,OrderRemarks,AdvancesPrice,paykings,ContractNo,ContractAddress,InvoRate,ReceiveSuppNo,Chk_IsChip,Chk_Battery,ParentOrderNo,ContractNos,KPO_CTime,KPO_Creator,KPO_MTime,KPO_Mender,ID,ArrivalDate,KPO_ScDetails,OrderCheckYN,KPO_PriceState,KPO_PreHouseNo)");
            strSql.Append(" values (");
            strSql.Append("@OrderTopic,@OrderNo,@OrderDateTime,@OrderPreToDate,@SuppNo,@OrderPaymentNotes,@OrderStaffBranch,@OrderStaffDepart,@OrderStaffNo,@OrderCheckStaffNo,@OrderTransShare,@OrderType,@OrderRemarks,@AdvancesPrice,@paykings,@ContractNo,@ContractAddress,@InvoRate,@ReceiveSuppNo,@Chk_IsChip,@Chk_Battery,@ParentOrderNo,@ContractNos,@KPO_CTime,@KPO_Creator,@KPO_MTime,@KPO_Mender,@ID,@ArrivalDate,@KPO_ScDetails,@OrderCheckYN,@KPO_PriceState,@KPO_PreHouseNo)");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderTopic", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderDateTime", SqlDbType.DateTime),
					new SqlParameter("@OrderPreToDate", SqlDbType.DateTime),
					new SqlParameter("@SuppNo", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderPaymentNotes", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderCheckStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderTransShare", SqlDbType.Decimal,9),
					new SqlParameter("@OrderType", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderRemarks", SqlDbType.NVarChar,1000),
					new SqlParameter("@AdvancesPrice", SqlDbType.Decimal,9),
					new SqlParameter("@paykings", SqlDbType.Int,4),
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractAddress", SqlDbType.VarChar,1000),
					new SqlParameter("@InvoRate", SqlDbType.Decimal,9),
					new SqlParameter("@ReceiveSuppNo", SqlDbType.VarChar,50),
					new SqlParameter("@Chk_IsChip", SqlDbType.VarChar,50),
					new SqlParameter("@Chk_Battery", SqlDbType.VarChar,50),
					new SqlParameter("@ParentOrderNo", SqlDbType.VarChar,50),
					new SqlParameter("@ContractNos", SqlDbType.VarChar,1000),
                    new SqlParameter("@KPO_CTime", SqlDbType.DateTime,8),
                     new SqlParameter("@KPO_Creator", SqlDbType.VarChar,50),
                     new SqlParameter("@KPO_MTime", SqlDbType.DateTime,8),
                     new SqlParameter("@KPO_Mender", SqlDbType.VarChar,50),
                     new SqlParameter("@ID", SqlDbType.VarChar,50),
                     new SqlParameter("@ArrivalDate", SqlDbType.DateTime),
                     new SqlParameter("@KPO_ScDetails", SqlDbType.Text),
                     new SqlParameter("@OrderCheckYN", SqlDbType.Bit),
                     new SqlParameter("@KPO_PriceState", SqlDbType.Int),
                     new SqlParameter("@KPO_PreHouseNo", SqlDbType.VarChar,50)
                     
                                        };
            parameters[0].Value = model.OrderTopic;
            parameters[1].Value = model.OrderNo;
            parameters[2].Value = model.OrderDateTime;
            parameters[3].Value = model.OrderPreToDate;
            parameters[4].Value = model.SuppNo;
            parameters[5].Value = model.OrderPaymentNotes;
            parameters[6].Value = model.OrderStaffBranch;
            parameters[7].Value = model.OrderStaffDepart;
            parameters[8].Value = model.OrderStaffNo;
            parameters[9].Value = model.OrderCheckStaffNo;
            parameters[10].Value = model.OrderTransShare;
            parameters[11].Value = model.OrderType;
            parameters[12].Value = model.OrderRemarks;
            parameters[13].Value = model.AdvancesPrice;
            parameters[14].Value = model.paykings;
            parameters[15].Value = model.ContractNo;
            parameters[16].Value = model.ContractAddress;
            parameters[17].Value = model.InvoRate;
            parameters[18].Value = model.ReceiveSuppNo;
            parameters[19].Value = model.Chk_IsChip;
            parameters[20].Value = model.Chk_Battery;
            parameters[21].Value = model.ParentOrderNo;
            parameters[22].Value = model.ContractNos; 
            parameters[23].Value = model.KPO_CTime;
            parameters[24].Value = model.KPO_Creator;
            parameters[25].Value = model.KPO_MTime;
            parameters[26].Value = model.KPO_Mender;
            parameters[27].Value = model.ID;
            parameters[28].Value = model.ArrivalDate;
            parameters[29].Value = model.KPO_ScDetails;
            parameters[30].Value = model.OrderCheckYN;
            parameters[31].Value = model.KPO_PriceState;
            parameters[32].Value = model.KPO_PreHouseNo;
            
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Knet_Procure_OrdersList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Knet_Procure_OrdersList set ");
            strSql.Append("OrderTopic=@OrderTopic,");
            strSql.Append("OrderDateTime=@OrderDateTime,");
            strSql.Append("OrderPreToDate=@OrderPreToDate,");
            strSql.Append("SuppNo=@SuppNo,");
            strSql.Append("OrderPaymentNotes=@OrderPaymentNotes,");
            strSql.Append("OrderStaffBranch=@OrderStaffBranch,");
            strSql.Append("OrderStaffDepart=@OrderStaffDepart,");
            strSql.Append("OrderStaffNo=@OrderStaffNo,");
            strSql.Append("OrderCheckStaffNo=@OrderCheckStaffNo,");
            strSql.Append("OrderTransShare=@OrderTransShare,");
            strSql.Append("OrderType=@OrderType,");
            strSql.Append("OrderRemarks=@OrderRemarks,");
            strSql.Append("AdvancesPrice=@AdvancesPrice,");
            strSql.Append("paykings=@paykings,");
            strSql.Append("ContractNo=@ContractNo,");
            strSql.Append("ContractAddress=@ContractAddress,");
            strSql.Append("InvoRate=@InvoRate,");
            strSql.Append("ReceiveSuppNo=@ReceiveSuppNo,");
            strSql.Append("Chk_IsChip=@Chk_IsChip,");
            strSql.Append("Chk_Battery=@Chk_Battery,");
            strSql.Append("OrderNo=@OrderNo, ");
            strSql.Append("ContractNos=@ContractNos, ");
            strSql.Append("KPO_MTime=@KPO_MTime, ");
            strSql.Append("KPO_Mender=@KPO_Mender,");
            strSql.Append("ArrivalDate=@ArrivalDate,");
            strSql.Append("KPO_ScDetails=@KPO_ScDetails, ");
            strSql.Append("ParentOrderNo=@ParentOrderNo,");
            strSql.Append("KPO_PriceState=@KPO_PriceState, ");
            strSql.Append("KPO_PreHouseNo=@KPO_PreHouseNo ");
            
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderTopic", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderDateTime", SqlDbType.DateTime),
					new SqlParameter("@OrderPreToDate", SqlDbType.DateTime),
					new SqlParameter("@SuppNo", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderPaymentNotes", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderCheckStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderTransShare", SqlDbType.Decimal,9),
					new SqlParameter("@OrderType", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderRemarks", SqlDbType.NVarChar,1000),
					new SqlParameter("@AdvancesPrice", SqlDbType.Decimal,9),
					new SqlParameter("@paykings", SqlDbType.Int,4),
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractAddress", SqlDbType.VarChar,1000),
					new SqlParameter("@InvoRate", SqlDbType.Decimal,9),
					new SqlParameter("@ReceiveSuppNo", SqlDbType.VarChar,50),
					new SqlParameter("@Chk_IsChip", SqlDbType.VarChar,50),
					new SqlParameter("@Chk_Battery", SqlDbType.VarChar,50),
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractNos", SqlDbType.NVarChar,1000),
                     new SqlParameter("@KPO_MTime", SqlDbType.DateTime,8),
                     new SqlParameter("@KPO_Mender", SqlDbType.VarChar,50),
                     new SqlParameter("@ArrivalDate", SqlDbType.DateTime,8),
					new SqlParameter("@KPO_ScDetails", SqlDbType.Text),
                     new SqlParameter("@ParentOrderNo", SqlDbType.VarChar,50),
                     new SqlParameter("@KPO_PriceState", SqlDbType.Int,4),
                     new SqlParameter("@KPO_PreHouseNo", SqlDbType.VarChar,50),
                     
					new SqlParameter("@ID", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = model.OrderTopic;
            parameters[1].Value = model.OrderDateTime;
            parameters[2].Value = model.OrderPreToDate;
            parameters[3].Value = model.SuppNo;
            parameters[4].Value = model.OrderPaymentNotes;
            parameters[5].Value = model.OrderStaffBranch;
            parameters[6].Value = model.OrderStaffDepart;
            parameters[7].Value = model.OrderStaffNo;
            parameters[8].Value = model.OrderCheckStaffNo;
            parameters[9].Value = model.OrderTransShare;
            parameters[10].Value = model.OrderType;
            parameters[11].Value = model.OrderRemarks;
            parameters[12].Value = model.AdvancesPrice;
            parameters[13].Value = model.paykings;
            parameters[14].Value = model.ContractNo;
            parameters[15].Value = model.ContractAddress;
            parameters[16].Value = model.InvoRate;
            parameters[17].Value = model.ReceiveSuppNo;
            parameters[18].Value = model.Chk_IsChip;
            parameters[19].Value = model.Chk_Battery;
            parameters[20].Value = model.OrderNo;
            parameters[21].Value = model.ContractNos;
            parameters[22].Value = model.KPO_MTime;
            parameters[23].Value = model.KPO_Mender;
            parameters[24].Value = model.ArrivalDate;
            parameters[25].Value = model.KPO_ScDetails;
            parameters[26].Value = model.ParentOrderNo;
            parameters[27].Value = model.KPO_PriceState;
            parameters[28].Value = model.KPO_PreHouseNo;
            
            parameters[29].Value = model.ID;

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
        public bool UpdateIsSend(KNet.Model.Knet_Procure_OrdersList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Knet_Procure_OrdersList set ");
            strSql.Append("KPO_IsSend=@KPO_IsSend");
            strSql.Append(" where OrderNo=@OrderNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@KPO_IsSend", SqlDbType.Int,4),
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.KPO_IsSend;
            parameters[1].Value = model.OrderNo;

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
        public bool UpdateRKState(KNet.Model.Knet_Procure_OrdersList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Knet_Procure_OrdersList set ");
            strSql.Append("KPO_RkState=@KPO_RkState");
            strSql.Append(" where OrderNo=@OrderNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@KPO_RkState", SqlDbType.Int,4),
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.KPO_RkState;
            parameters[1].Value = model.OrderNo;

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
        public bool UpdateRkState(KNet.Model.Knet_Procure_OrdersList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Knet_Procure_OrdersList set ");
            strSql.Append("KPO_RkState=@KPO_RkState ");
            strSql.Append(" where OrderNo=@OrderNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@KPO_RkState", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.KPO_RkState;
            parameters[1].Value = model.OrderNo;

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


        public bool IsDetails(string s_OrderNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select  count(1)  from  Knet_Procure_OrdersList_Details ");
            strSql.Append(" where OrderNo=@OrderNo having Sum(OrderAmount-OrderHaveReceiving)<=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = s_OrderNo;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string OrderNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Knet_Procure_OrdersList ");
            strSql.Append(" where OrderNo=@OrderNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = OrderNo;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_OrdersList GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Knet_Procure_OrdersList a  join v_OrderRKWithNoDel b on a.OrderNO=b.V_OrderNo  ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.Knet_Procure_OrdersList model = new KNet.Model.Knet_Procure_OrdersList();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderTopic"] != null && ds.Tables[0].Rows[0]["OrderTopic"].ToString() != "")
                {
                    model.OrderTopic = ds.Tables[0].Rows[0]["OrderTopic"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderNo"] != null && ds.Tables[0].Rows[0]["OrderNo"].ToString() != "")
                {
                    model.OrderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderDateTime"] != null && ds.Tables[0].Rows[0]["OrderDateTime"].ToString() != "")
                {
                    model.OrderDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["OrderDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderPreToDate"] != null && ds.Tables[0].Rows[0]["OrderPreToDate"].ToString() != "")
                {
                    model.OrderPreToDate = DateTime.Parse(ds.Tables[0].Rows[0]["OrderPreToDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SuppNo"] != null && ds.Tables[0].Rows[0]["SuppNo"].ToString() != "")
                {
                    model.SuppNo = ds.Tables[0].Rows[0]["SuppNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderPaymentNotes"] != null && ds.Tables[0].Rows[0]["OrderPaymentNotes"].ToString() != "")
                {
                    model.OrderPaymentNotes = ds.Tables[0].Rows[0]["OrderPaymentNotes"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderStaffBranch"] != null && ds.Tables[0].Rows[0]["OrderStaffBranch"].ToString() != "")
                {
                    model.OrderStaffBranch = ds.Tables[0].Rows[0]["OrderStaffBranch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderStaffDepart"] != null && ds.Tables[0].Rows[0]["OrderStaffDepart"].ToString() != "")
                {
                    model.OrderStaffDepart = ds.Tables[0].Rows[0]["OrderStaffDepart"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderStaffNo"] != null && ds.Tables[0].Rows[0]["OrderStaffNo"].ToString() != "")
                {
                    model.OrderStaffNo = ds.Tables[0].Rows[0]["OrderStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderCheckStaffNo"] != null && ds.Tables[0].Rows[0]["OrderCheckStaffNo"].ToString() != "")
                {
                    model.OrderCheckStaffNo = ds.Tables[0].Rows[0]["OrderCheckStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderTransShare"] != null && ds.Tables[0].Rows[0]["OrderTransShare"].ToString() != "")
                {
                    model.OrderTransShare = decimal.Parse(ds.Tables[0].Rows[0]["OrderTransShare"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderType"] != null && ds.Tables[0].Rows[0]["OrderType"].ToString() != "")
                {
                    model.OrderType = ds.Tables[0].Rows[0]["OrderType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderRemarks"] != null && ds.Tables[0].Rows[0]["OrderRemarks"].ToString() != "")
                {
                    model.OrderRemarks = ds.Tables[0].Rows[0]["OrderRemarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderState"] != null && ds.Tables[0].Rows[0]["OrderState"].ToString() != "")
                {
                    model.OrderState = int.Parse(ds.Tables[0].Rows[0]["OrderState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderCheckYN"] != null && ds.Tables[0].Rows[0]["OrderCheckYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["OrderCheckYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["OrderCheckYN"].ToString().ToLower() == "true"))
                    {
                        model.OrderCheckYN = true;
                    }
                    else
                    {
                        model.OrderCheckYN = false;
                    }
                }
                else
                {
                    model.OrderCheckYN = false;
                }
                if (ds.Tables[0].Rows[0]["KPO_IsSend"] != null && ds.Tables[0].Rows[0]["KPO_IsSend"].ToString() != "")
                {
                    model.KPO_IsSend = int.Parse(ds.Tables[0].Rows[0]["KPO_IsSend"].ToString());
                }
                else
                {
                    model.KPO_IsSend = 0;

                }

                if (ds.Tables[0].Rows[0]["AdvancesPrice"] != null && ds.Tables[0].Rows[0]["AdvancesPrice"].ToString() != "")
                {
                    model.AdvancesPrice = decimal.Parse(ds.Tables[0].Rows[0]["AdvancesPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["paykings"] != null && ds.Tables[0].Rows[0]["paykings"].ToString() != "")
                {
                    model.paykings = int.Parse(ds.Tables[0].Rows[0]["paykings"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SystemDatetimes"] != null && ds.Tables[0].Rows[0]["SystemDatetimes"].ToString() != "")
                {
                    model.SystemDatetimes = DateTime.Parse(ds.Tables[0].Rows[0]["SystemDatetimes"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContractNo"] != null && ds.Tables[0].Rows[0]["ContractNo"].ToString() != "")
                {
                    model.ContractNo = ds.Tables[0].Rows[0]["ContractNo"].ToString();
                }
                else
                {
                    model.ContractNo = "";
                }
                if (ds.Tables[0].Rows[0]["ContractAddress"] != null && ds.Tables[0].Rows[0]["ContractAddress"].ToString() != "")
                {
                    model.ContractAddress = ds.Tables[0].Rows[0]["ContractAddress"].ToString();
                }
                else
                {
                    model.ContractAddress = "";
                }
                if (ds.Tables[0].Rows[0]["InvoRate"] != null && ds.Tables[0].Rows[0]["InvoRate"].ToString() != "")
                {
                    model.InvoRate = decimal.Parse(ds.Tables[0].Rows[0]["InvoRate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReceiveSuppNo"] != null && ds.Tables[0].Rows[0]["ReceiveSuppNo"].ToString() != "")
                {
                    model.ReceiveSuppNo = ds.Tables[0].Rows[0]["ReceiveSuppNo"].ToString();
                }

                if (ds.Tables[0].Rows[0]["Chk_IsChip"] != null && ds.Tables[0].Rows[0]["Chk_IsChip"].ToString() != "")
                {
                    model.Chk_IsChip = ds.Tables[0].Rows[0]["Chk_IsChip"].ToString();
                }

                if (ds.Tables[0].Rows[0]["Chk_Battery"] != null && ds.Tables[0].Rows[0]["Chk_Battery"].ToString() != "")
                {
                    model.Chk_Battery = ds.Tables[0].Rows[0]["Chk_Battery"].ToString();
                }

                if (ds.Tables[0].Rows[0]["ParentOrderNo"] != null && ds.Tables[0].Rows[0]["ParentOrderNo"].ToString() != "")
                {
                    model.ParentOrderNo = ds.Tables[0].Rows[0]["ParentOrderNo"].ToString();
                }
                else
                {
                    model.ParentOrderNo = "";
                }
                if (ds.Tables[0].Rows[0]["KPO_RkState"] != null && ds.Tables[0].Rows[0]["KPO_RkState"].ToString() != "")
                {
                    model.KPO_RkState = ds.Tables[0].Rows[0]["KPO_RkState"].ToString();
                }
                else
                {
                    model.KPO_RkState = "0";
                }

                if (ds.Tables[0].Rows[0]["KPO_PayState"] != null && ds.Tables[0].Rows[0]["KPO_PayState"].ToString() != "")
                {
                    model.KPO_PayState = ds.Tables[0].Rows[0]["KPO_PayState"].ToString();
                }
                else
                {

                    model.KPO_PayState = "0";
                }
                if (ds.Tables[0].Rows[0]["rkState"] != null && ds.Tables[0].Rows[0]["rkState"].ToString() != "")
                {
                    model.rkState = ds.Tables[0].Rows[0]["rkState"].ToString();
                }
                else
                {

                    model.rkState = "0";
                }
                if (ds.Tables[0].Rows[0]["ContractNos"] != null && ds.Tables[0].Rows[0]["ContractNos"].ToString() != "")
                {
                    model.ContractNos = ds.Tables[0].Rows[0]["ContractNos"].ToString();
                }
                else
                {
                    model.ContractNos = "";
                }
                if (ds.Tables[0].Rows[0]["KPO_CTime"] != null && ds.Tables[0].Rows[0]["KPO_CTime"].ToString() != "")
                {
                    model.KPO_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["KPO_CTime"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KPO_Creator"] != null && ds.Tables[0].Rows[0]["KPO_Creator"].ToString() != "")
                {
                    model.KPO_Creator = ds.Tables[0].Rows[0]["KPO_Creator"].ToString();
                }
                else
                {
                    model.KPO_Creator = "";
                }

                if (ds.Tables[0].Rows[0]["KPO_MTime"] != null && ds.Tables[0].Rows[0]["KPO_MTime"].ToString() != "")
                {
                    model.KPO_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["KPO_MTime"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KPO_Mender"] != null && ds.Tables[0].Rows[0]["KPO_Mender"].ToString() != "")
                {
                    model.KPO_Mender = ds.Tables[0].Rows[0]["KPO_Mender"].ToString();
                }
                else
                {
                    model.KPO_Mender = "";
                }

                if (ds.Tables[0].Rows[0]["KPO_Print"] != null && ds.Tables[0].Rows[0]["KPO_Print"].ToString() != "")
                {
                    model.KPO_Print = int.Parse(ds.Tables[0].Rows[0]["KPO_Print"].ToString());
                }
                else
                {
                    model.KPO_Print = 0;
                }
                if (ds.Tables[0].Rows[0]["KPO_Del"] != null && ds.Tables[0].Rows[0]["KPO_Del"].ToString() != "")
                {
                    model.KPO_Del = int.Parse(ds.Tables[0].Rows[0]["KPO_Del"].ToString());
                }
                else
                {
                    model.KPO_Del = 0;
                }
                if (ds.Tables[0].Rows[0]["ArrivalDate"] != null && ds.Tables[0].Rows[0]["ArrivalDate"].ToString() != "")
                {
                    model.ArrivalDate = DateTime.Parse(ds.Tables[0].Rows[0]["ArrivalDate"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KPO_ScDetails"] != null && ds.Tables[0].Rows[0]["KPO_ScDetails"].ToString() != "")
                {
                    model.KPO_ScDetails = ds.Tables[0].Rows[0]["KPO_ScDetails"].ToString();
                }


                if (ds.Tables[0].Rows[0]["KPO_PriceState"] != null && ds.Tables[0].Rows[0]["KPO_PriceState"].ToString() != "")
                {
                    model.KPO_PriceState = int.Parse(ds.Tables[0].Rows[0]["KPO_PriceState"].ToString());
                }


                if (ds.Tables[0].Rows[0]["KPO_PreHouseNo"] != null && ds.Tables[0].Rows[0]["KPO_PreHouseNo"].ToString() != "")
                {
                    model.KPO_PreHouseNo = ds.Tables[0].Rows[0]["KPO_PreHouseNo"].ToString();
                }
                else
                {
                    model.KPO_PreHouseNo = "";
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
        public KNet.Model.Knet_Procure_OrdersList GetModelB(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Knet_Procure_OrdersList a  join v_OrderRKWithNoDel b on a.OrderNO=b.V_OrderNo  ");
            strSql.Append(" where OrderNo=@OrderNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.Knet_Procure_OrdersList model = new KNet.Model.Knet_Procure_OrdersList();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderTopic"] != null && ds.Tables[0].Rows[0]["OrderTopic"].ToString() != "")
                {
                    model.OrderTopic = ds.Tables[0].Rows[0]["OrderTopic"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderNo"] != null && ds.Tables[0].Rows[0]["OrderNo"].ToString() != "")
                {
                    model.OrderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderDateTime"] != null && ds.Tables[0].Rows[0]["OrderDateTime"].ToString() != "")
                {
                    model.OrderDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["OrderDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderPreToDate"] != null && ds.Tables[0].Rows[0]["OrderPreToDate"].ToString() != "")
                {
                    model.OrderPreToDate = DateTime.Parse(ds.Tables[0].Rows[0]["OrderPreToDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SuppNo"] != null && ds.Tables[0].Rows[0]["SuppNo"].ToString() != "")
                {
                    model.SuppNo = ds.Tables[0].Rows[0]["SuppNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderPaymentNotes"] != null && ds.Tables[0].Rows[0]["OrderPaymentNotes"].ToString() != "")
                {
                    model.OrderPaymentNotes = ds.Tables[0].Rows[0]["OrderPaymentNotes"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderStaffBranch"] != null && ds.Tables[0].Rows[0]["OrderStaffBranch"].ToString() != "")
                {
                    model.OrderStaffBranch = ds.Tables[0].Rows[0]["OrderStaffBranch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderStaffDepart"] != null && ds.Tables[0].Rows[0]["OrderStaffDepart"].ToString() != "")
                {
                    model.OrderStaffDepart = ds.Tables[0].Rows[0]["OrderStaffDepart"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderStaffNo"] != null && ds.Tables[0].Rows[0]["OrderStaffNo"].ToString() != "")
                {
                    model.OrderStaffNo = ds.Tables[0].Rows[0]["OrderStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderCheckStaffNo"] != null && ds.Tables[0].Rows[0]["OrderCheckStaffNo"].ToString() != "")
                {
                    model.OrderCheckStaffNo = ds.Tables[0].Rows[0]["OrderCheckStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderTransShare"] != null && ds.Tables[0].Rows[0]["OrderTransShare"].ToString() != "")
                {
                    model.OrderTransShare = decimal.Parse(ds.Tables[0].Rows[0]["OrderTransShare"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderType"] != null && ds.Tables[0].Rows[0]["OrderType"].ToString() != "")
                {
                    model.OrderType = ds.Tables[0].Rows[0]["OrderType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderRemarks"] != null && ds.Tables[0].Rows[0]["OrderRemarks"].ToString() != "")
                {
                    model.OrderRemarks = ds.Tables[0].Rows[0]["OrderRemarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrderState"] != null && ds.Tables[0].Rows[0]["OrderState"].ToString() != "")
                {
                    model.OrderState = int.Parse(ds.Tables[0].Rows[0]["OrderState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderCheckYN"] != null && ds.Tables[0].Rows[0]["OrderCheckYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["OrderCheckYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["OrderCheckYN"].ToString().ToLower() == "true"))
                    {
                        model.OrderCheckYN = true;
                    }
                    else
                    {
                        model.OrderCheckYN = false;
                    }
                }
                else
                {
                    model.OrderCheckYN = false;
                }
                if (ds.Tables[0].Rows[0]["KPO_IsSend"] != null && ds.Tables[0].Rows[0]["KPO_IsSend"].ToString() != "")
                {
                    model.KPO_IsSend = int.Parse(ds.Tables[0].Rows[0]["KPO_IsSend"].ToString());
                }
                else
                {
                    model.KPO_IsSend = 0;
 
                }
                
                if (ds.Tables[0].Rows[0]["AdvancesPrice"] != null && ds.Tables[0].Rows[0]["AdvancesPrice"].ToString() != "")
                {
                    model.AdvancesPrice = decimal.Parse(ds.Tables[0].Rows[0]["AdvancesPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["paykings"] != null && ds.Tables[0].Rows[0]["paykings"].ToString() != "")
                {
                    model.paykings = int.Parse(ds.Tables[0].Rows[0]["paykings"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SystemDatetimes"] != null && ds.Tables[0].Rows[0]["SystemDatetimes"].ToString() != "")
                {
                    model.SystemDatetimes = DateTime.Parse(ds.Tables[0].Rows[0]["SystemDatetimes"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContractNo"] != null && ds.Tables[0].Rows[0]["ContractNo"].ToString() != "")
                {
                    model.ContractNo = ds.Tables[0].Rows[0]["ContractNo"].ToString();
                }
                else
                {
                    model.ContractNo = "";
                }
                if (ds.Tables[0].Rows[0]["ContractAddress"] != null && ds.Tables[0].Rows[0]["ContractAddress"].ToString() != "")
                {
                    model.ContractAddress = ds.Tables[0].Rows[0]["ContractAddress"].ToString();
                }
                else
                {
                    model.ContractAddress = "";
                }
                if (ds.Tables[0].Rows[0]["InvoRate"] != null && ds.Tables[0].Rows[0]["InvoRate"].ToString() != "")
                {
                    model.InvoRate = decimal.Parse(ds.Tables[0].Rows[0]["InvoRate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReceiveSuppNo"] != null && ds.Tables[0].Rows[0]["ReceiveSuppNo"].ToString() != "")
                {
                    model.ReceiveSuppNo = ds.Tables[0].Rows[0]["ReceiveSuppNo"].ToString();
                }

                if (ds.Tables[0].Rows[0]["Chk_IsChip"] != null && ds.Tables[0].Rows[0]["Chk_IsChip"].ToString() != "")
                {
                    model.Chk_IsChip = ds.Tables[0].Rows[0]["Chk_IsChip"].ToString();
                }

                if (ds.Tables[0].Rows[0]["Chk_Battery"] != null && ds.Tables[0].Rows[0]["Chk_Battery"].ToString() != "")
                {
                    model.Chk_Battery = ds.Tables[0].Rows[0]["Chk_Battery"].ToString();
                }

                if (ds.Tables[0].Rows[0]["ParentOrderNo"] != null && ds.Tables[0].Rows[0]["ParentOrderNo"].ToString() != "")
                {
                    model.ParentOrderNo = ds.Tables[0].Rows[0]["ParentOrderNo"].ToString();
                }
                else
                {
                    model.ParentOrderNo = "";
                }
                if (ds.Tables[0].Rows[0]["KPO_RkState"] != null && ds.Tables[0].Rows[0]["KPO_RkState"].ToString() != "")
                {
                    model.KPO_RkState = ds.Tables[0].Rows[0]["KPO_RkState"].ToString();
                }
                else
                {
                    model.KPO_RkState = "0";
                }

                if (ds.Tables[0].Rows[0]["KPO_PayState"] != null && ds.Tables[0].Rows[0]["KPO_PayState"].ToString() != "")
                {
                    model.KPO_PayState = ds.Tables[0].Rows[0]["KPO_PayState"].ToString();
                }
                else
                {

                    model.KPO_PayState = "0";
                }
                if (ds.Tables[0].Rows[0]["rkState"] != null && ds.Tables[0].Rows[0]["rkState"].ToString() != "")
                {
                    model.rkState = ds.Tables[0].Rows[0]["rkState"].ToString();
                }
                else
                {

                    model.rkState = "0";
                }
                if (ds.Tables[0].Rows[0]["ContractNos"] != null && ds.Tables[0].Rows[0]["ContractNos"].ToString() != "")
                {
                    model.ContractNos = ds.Tables[0].Rows[0]["ContractNos"].ToString();
                }
                else
                {
                    model.ContractNos = "";
                }
                if (ds.Tables[0].Rows[0]["KPO_CTime"] != null && ds.Tables[0].Rows[0]["KPO_CTime"].ToString() != "")
                {
                    model.KPO_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["KPO_CTime"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KPO_Creator"] != null && ds.Tables[0].Rows[0]["KPO_Creator"].ToString() != "")
                {
                    model.KPO_Creator = ds.Tables[0].Rows[0]["KPO_Creator"].ToString();
                }
                else
                {
                    model.KPO_Creator = "";
                }

                if (ds.Tables[0].Rows[0]["KPO_MTime"] != null && ds.Tables[0].Rows[0]["KPO_MTime"].ToString() != "")
                {
                    model.KPO_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["KPO_MTime"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KPO_Mender"] != null && ds.Tables[0].Rows[0]["KPO_Mender"].ToString() != "")
                {
                    model.KPO_Mender = ds.Tables[0].Rows[0]["KPO_Mender"].ToString();
                }
                else
                {
                    model.KPO_Mender = "";
                }

                if (ds.Tables[0].Rows[0]["KPO_Print"] != null && ds.Tables[0].Rows[0]["KPO_Print"].ToString() != "")
                {
                    model.KPO_Print = int.Parse(ds.Tables[0].Rows[0]["KPO_Print"].ToString());
                }
                else
                {
                    model.KPO_Print = 0;
                }
                if (ds.Tables[0].Rows[0]["KPO_Del"] != null && ds.Tables[0].Rows[0]["KPO_Del"].ToString() != "")
                {
                    model.KPO_Del = int.Parse(ds.Tables[0].Rows[0]["KPO_Del"].ToString());
                }
                else
                {
                    model.KPO_Del = 0;
                }

                if (ds.Tables[0].Rows[0]["KPO_ScDetails"] != null && ds.Tables[0].Rows[0]["KPO_ScDetails"].ToString() != "")
                {
                    model.KPO_ScDetails = ds.Tables[0].Rows[0]["KPO_ScDetails"].ToString();
                }
                else
                {
                    model.KPO_ScDetails = "";
                }

                if (ds.Tables[0].Rows[0]["KPO_IsStopProduce"] != null && ds.Tables[0].Rows[0]["KPO_IsStopProduce"].ToString() != "")
                {
                    model.KPO_IsStopProduce = int.Parse(ds.Tables[0].Rows[0]["KPO_IsStopProduce"].ToString());
                }
                else
                {
                    model.KPO_IsStopProduce = 0;
                }

                if (ds.Tables[0].Rows[0]["KPO_PriceState"] != null && ds.Tables[0].Rows[0]["KPO_PriceState"].ToString() != "")
                {
                    model.KPO_PriceState = int.Parse(ds.Tables[0].Rows[0]["KPO_PriceState"].ToString());
                }


                if (ds.Tables[0].Rows[0]["KPO_IsChange"] != null && ds.Tables[0].Rows[0]["KPO_IsChange"].ToString() != "")
                {
                    model.KPO_IsChange = int.Parse(ds.Tables[0].Rows[0]["KPO_IsChange"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KPO_PreHouseNo"] != null && ds.Tables[0].Rows[0]["KPO_PreHouseNo"].ToString() != "")
                {
                    model.KPO_PreHouseNo = ds.Tables[0].Rows[0]["KPO_PreHouseNo"].ToString();
                }
                else
                {
                    model.KPO_PreHouseNo = "";
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
            strSql.Append("select *,a.ParentOrderNo,case when RKState<>1 then cast (DATEDIFF(day,getdate(),OrderpretoDate) as varchar(100)) else '' end as DiffDay  ");
            strSql.Append(" FROM Knet_Procure_OrdersList a  join v_OrderRKWithNoDel b on a.OrderNO=b.V_OrderNo  ");
            strSql.Append(" join KNet_Sys_ProcureType c on a.OrderType=c.ProcureTypeValue  ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}


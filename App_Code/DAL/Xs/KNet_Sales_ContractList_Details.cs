using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sales_ContractList_Details。
    /// </summary>
    public class KNet_Sales_ContractList_Details
    {
        public KNet_Sales_ContractList_Details()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ContractNo, string ProductsBarCode, string OwnallPID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@OwnallPID", SqlDbType.NVarChar,50)};

            parameters[0].Value = ContractNo;
            parameters[1].Value = ProductsBarCode;
            parameters[2].Value = OwnallPID;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sales_ContractList_Details_Exists", parameters, out rowsAffected);
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
        ///  增加一条数据 （选择从仓库添加）
        /// </summary>
        public void Add(KNet.Model.KNet_Sales_ContractList_Details model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Sales_ContractList_Details(");
            strSql.Append("ContractNo,ProductsName,ProductsBarCode,ProductsPattern,ProductsUnits,ContractAmount,ContractUnitPrice,ContractDiscount,ContractTotalNet,Contract_SalesUnitPrice,Contract_SalesDiscount,Contract_SalesTotalNet,ContractRemarks,OwnallPID,KSD_OrderNumber,KSD_MaterNumber,KSC_BNumber,KSC_OrderBNumber,KSD_IsFollow,KSD_PlanNumber,KSD_MaterPattern,ID,KSD_XCMDID)");
            strSql.Append(" values (");
            strSql.Append("@ContractNo,@ProductsName,@ProductsBarCode,@ProductsPattern,@ProductsUnits,@ContractAmount,@ContractUnitPrice,@ContractDiscount,@ContractTotalNet,@Contract_SalesUnitPrice,@Contract_SalesDiscount,@Contract_SalesTotalNet,@ContractRemarks,@OwnallPID,@KSD_OrderNumber,@KSD_MaterNumber,@KSC_BNumber,@KSC_OrderBNumber,@KSD_IsFollow,@KSD_PlanNumber,@KSD_MaterPattern,@ID,@KSD_XCMDID)");
            SqlParameter[] parameters = {
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsPattern", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsUnits", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractAmount", SqlDbType.Int,4),
					new SqlParameter("@ContractUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ContractDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@ContractTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@Contract_SalesUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Contract_SalesDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@Contract_SalesTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@ContractRemarks", SqlDbType.NVarChar,300),
					new SqlParameter("@OwnallPID", SqlDbType.NVarChar,50),
					new SqlParameter("@KSD_OrderNumber", SqlDbType.NVarChar,500),
					new SqlParameter("@KSD_MaterNumber", SqlDbType.NVarChar,500),
					new SqlParameter("@KSC_BNumber", SqlDbType.Int,4),
					new SqlParameter("@KSC_OrderBNumber", SqlDbType.Int,4),
					new SqlParameter("@KSD_IsFollow", SqlDbType.NVarChar,50),
					new SqlParameter("@KSD_PlanNumber", SqlDbType.NVarChar,500),
					new SqlParameter("@KSD_MaterPattern", SqlDbType.NVarChar,500),
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@KSD_XCMDID", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = model.ContractNo;
            parameters[1].Value = model.ProductsName;
            parameters[2].Value = model.ProductsBarCode;
            parameters[3].Value = model.ProductsPattern;
            parameters[4].Value = model.ProductsUnits;
            parameters[5].Value = model.ContractAmount;
            parameters[6].Value = model.ContractUnitPrice;
            parameters[7].Value = model.ContractDiscount;
            parameters[8].Value = model.ContractTotalNet;
            parameters[9].Value = model.Contract_SalesUnitPrice;
            parameters[10].Value = model.Contract_SalesDiscount;
            parameters[11].Value = model.Contract_SalesTotalNet;
            parameters[12].Value = model.ContractRemarks;
            parameters[13].Value = model.OwnallPID;
            parameters[14].Value = model.KSD_OrderNumber;
            parameters[15].Value = model.KSD_MaterNumber;
            parameters[16].Value = model.KSC_BNumber;
            parameters[17].Value = model.KSC_OrderBNumber;
            parameters[18].Value = model.KSD_IsFollow;
            parameters[19].Value = model.KSD_PlanNumber;
            parameters[20].Value = model.KSD_MaterPattern;
            parameters[21].Value = model.ID;
            parameters[22].Value = model.KSD_XCMDID;
            
            
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }

        /// <summary>
        ///  更新一条数据 （在明细表里直接修改）
        /// </summary>
        public void Update(KNet.Model.KNet_Sales_ContractList_Details model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Sales_ContractList_Details set ");
            strSql.Append("ContractAmount=@ContractAmount,");
            strSql.Append("Contract_SalesUnitPrice=@Contract_SalesUnitPrice,");
            strSql.Append("ContractDiscount=@ContractDiscount,");
            strSql.Append("Contract_SalesTotalNet=@Contract_SalesTotalNet,");
            strSql.Append("ContractRemarks=@ContractRemarks,");
            strSql.Append("KSC_BNumber=@KSC_BNumber");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ContractAmount", SqlDbType.Int,4),
					new SqlParameter("@Contract_SalesUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ContractDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@Contract_SalesTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@ContractRemarks", SqlDbType.NVarChar,300),
					new SqlParameter("@KSC_BNumber", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ContractAmount;
            parameters[1].Value = model.Contract_SalesUnitPrice;
            parameters[2].Value = model.ContractDiscount;
            parameters[3].Value = model.Contract_SalesTotalNet;
            parameters[4].Value = model.ContractRemarks;
            parameters[5].Value = model.KSC_BNumber;
            parameters[6].Value = model.ID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        ///  更新一条数据 （选择性追加记录 修改）
        /// </summary>
        public void UpdateB(KNet.Model.KNet_Sales_ContractList_Details model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Sales_ContractList_Details set ");
            strSql.Append("ContractNo=@ContractNo,");
            strSql.Append("ProductsBarCode=@ProductsBarCode,");
            strSql.Append("ContractAmount=@ContractAmount,");
            strSql.Append("Contract_SalesUnitPrice=@Contract_SalesUnitPrice,");
            strSql.Append("ContractDiscount=@ContractDiscount,");
            strSql.Append("ContractTotalNet=@ContractTotalNet,");
            strSql.Append("Contract_SalesTotalNet=@Contract_SalesTotalNet,");
            strSql.Append("KSC_BNumber=@KSC_BNumber");
            strSql.Append("OwnallPID=@OwnallPID,");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),

					new SqlParameter("@ContractAmount", SqlDbType.Int,4),

					new SqlParameter("@ContractUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ContractDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@ContractTotalNet", SqlDbType.Decimal,9),

					new SqlParameter("@Contract_SalesTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@KSC_BNumber", SqlDbType.Int,4),
                    new SqlParameter("@OwnallPID", SqlDbType.NVarChar,50)
            };

            parameters[0].Value = model.ContractNo;
            parameters[1].Value = model.ProductsBarCode;

            parameters[2].Value = model.ContractAmount;

            parameters[3].Value = model.ContractUnitPrice;
            parameters[4].Value = model.ContractDiscount;
            parameters[5].Value = model.ContractTotalNet;
            parameters[6].Value = model.Contract_SalesTotalNet;
            parameters[7].Value = model.KSC_BNumber;
            parameters[8].Value = model.OwnallPID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
    

            DbHelperSQL.RunProcedure("Proc_KNet_Sales_ContractList_Details_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByContractNo(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_Sales_ContractList_Details ");
            strSql.Append(" where ContractNo=@ContractNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

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
        public KNet.Model.KNet_Sales_ContractList_Details GetModel(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_Sales_ContractList_Details model = new KNet.Model.KNet_Sales_ContractList_Details();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_Sales_ContractList_Details_GetModelByID", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.OwnallPID = ds.Tables[0].Rows[0]["OwnallPID"].ToString();

                model.ContractNo = ds.Tables[0].Rows[0]["ContractNo"].ToString();
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                if (ds.Tables[0].Rows[0]["ContractAmount"].ToString() != "")
                {
                    model.ContractAmount = int.Parse(ds.Tables[0].Rows[0]["ContractAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContractUnitPrice"].ToString() != "")
                {
                    model.ContractUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["ContractUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContractDiscount"].ToString() != "")
                {
                    model.ContractDiscount = decimal.Parse(ds.Tables[0].Rows[0]["ContractDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContractTotalNet"].ToString() != "")
                {
                    model.ContractTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["ContractTotalNet"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Contract_SalesUnitPrice"].ToString() != "")
                {
                    model.Contract_SalesUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["Contract_SalesUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Contract_SalesDiscount"].ToString() != "")
                {
                    model.Contract_SalesDiscount = decimal.Parse(ds.Tables[0].Rows[0]["Contract_SalesDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Contract_SalesTotalNet"].ToString() != "")
                {
                    model.Contract_SalesTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["Contract_SalesTotalNet"].ToString());
                }
                model.ContractRemarks = ds.Tables[0].Rows[0]["ContractRemarks"].ToString();
                if (ds.Tables[0].Rows[0]["ContractReceiving"].ToString() != "")
                {
                    model.ContractReceiving = int.Parse(ds.Tables[0].Rows[0]["ContractReceiving"].ToString());
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
        public KNet.Model.KNet_Sales_ContractList_Details GetModelB(string ContractNo, string ProductsBarCode, string OwnallPID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@OwnallPID", SqlDbType.NVarChar,50)};

            parameters[0].Value = ContractNo;
            parameters[1].Value = ProductsBarCode;
            parameters[2].Value = OwnallPID;

            KNet.Model.KNet_Sales_ContractList_Details model = new KNet.Model.KNet_Sales_ContractList_Details();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_Sales_ContractList_Details_GetModelByNo", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.OwnallPID = ds.Tables[0].Rows[0]["OwnallPID"].ToString();
                model.ContractNo = ds.Tables[0].Rows[0]["ContractNo"].ToString();
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                if (ds.Tables[0].Rows[0]["ContractAmount"].ToString() != "")
                {
                    model.ContractAmount = int.Parse(ds.Tables[0].Rows[0]["ContractAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContractUnitPrice"].ToString() != "")
                {
                    model.ContractUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["ContractUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContractDiscount"].ToString() != "")
                {
                    model.ContractDiscount = decimal.Parse(ds.Tables[0].Rows[0]["ContractDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContractTotalNet"].ToString() != "")
                {
                    model.ContractTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["ContractTotalNet"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Contract_SalesUnitPrice"].ToString() != "")
                {
                    model.Contract_SalesUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["Contract_SalesUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Contract_SalesDiscount"].ToString() != "")
                {
                    model.Contract_SalesDiscount = decimal.Parse(ds.Tables[0].Rows[0]["Contract_SalesDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Contract_SalesTotalNet"].ToString() != "")
                {
                    model.Contract_SalesTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["Contract_SalesTotalNet"].ToString());
                }
                model.ContractRemarks = ds.Tables[0].Rows[0]["ContractRemarks"].ToString();
                if (ds.Tables[0].Rows[0]["ContractReceiving"].ToString() != "")
                {
                    model.ContractReceiving = int.Parse(ds.Tables[0].Rows[0]["ContractReceiving"].ToString());
                }


                if (ds.Tables[0].Rows[0]["KSD_XCMDID"].ToString() != "")
                {
                    model.KSD_XCMDID = ds.Tables[0].Rows[0]["KSD_XCMDID"].ToString();
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
            strSql.Append("select *,(ContractAmount-ContractReceiving) as thisNowAmount,(Select isnull(Sum(WareHouseAmount),0) from Knet_Procure_WareHouseList_Details a join Knet_Procure_WareHouseList b on a.WareHouseNo=b.WareHouseNo join Knet_Procure_OrdersList c on c.OrderNo=b.OrderNo where c.ContractNo=KNet_Sales_ContractList_Details.ContractNo and a.ProductsBarCode=KNet_Sales_ContractList_Details.ProductsBarCode) as WareHouseAmount,KSC_OrderBNumber ");
            strSql.Append(" FROM KNet_Sales_ContractList_Details  ");
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
            strSql.Append("select sum(Vs_leftNumber) as LeftNumber,ProductsBarCode,Sum(ContractAmount-ContractReceiving) as thisNowAmount,Sum(Contract_SalesTotalNet) Contract_SalesTotalNet,Sum(ContractAmount) ContractAmount ");

            strSql.Append(",Contract_SalesUnitPrice,Sum(KSC_BNumber) KSC_BNumber,KSD_PlanNumber,KSD_OrderNumber,KSD_MaterNumber,KSD_MaterPattern,KSD_IsFollow,KSD_PlanNumber ");
            strSql.Append(" FROM KNet_Sales_ContractList_Details  ");
            strSql.Append(" left join v_Contract_OutWare_Details_Sum on vs_ID=ID   ");
            
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" Group by ProductsBarCode,Contract_SalesUnitPrice,KSD_PlanNumber,KSD_OrderNumber,KSD_MaterNumber,KSD_MaterPattern,KSD_IsFollow,KSD_PlanNumber  ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetTotalListDetails(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.ContractNo,b.CustomerValue,Vs_leftNumber as LeftNumber,ProductsBarCode,ContractAmount-ContractReceiving as thisNowAmount,Contract_SalesTotalNet Contract_SalesTotalNet,ContractAmount  ");

            strSql.Append(",Contract_SalesUnitPrice,KSC_BNumber ,KSD_PlanNumber,KSD_OrderNumber,KSD_MaterNumber,KSD_MaterPattern,KSD_IsFollow,KSD_PlanNumber ");
            strSql.Append(",ContractStaffNo,ContractClass,b.DutyPerson,a.ID,Vs_SalesShipNumber,VS_Leftnumber ");

            strSql.Append(" FROM KNet_Sales_ContractList_Details  a ");
            strSql.Append(" join v_Contract_OutWare_Details_Sum on vs_ID=ID   ");
            strSql.Append("  join KNet_Sales_ContractList b on a.ContractNo=b.ContractNo  ");
            
            
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListJoinProducts(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select b.*,a.*,(ContractAmount-ContractReceiving) as thisNowAmount ");
            strSql.Append(" FROM KNet_Sales_ContractList_Details a ");
            strSql.Append("join KNet_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByView(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM V_Sales_ContractList_details ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select b.ProductsUnits,a.*,(a.ContractAmount-a.ContractReceiving) as thisNowAmount, b.ProductsEdition,d.PBC_Name as Manual,c.ProductsPattern as Battery,KSC_BNumber,b.* ,e.*");
            strSql.Append(" FROM KNet_Sales_ContractList_Details a join KNet_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode left join KNet_Sys_Products c On c.ProductsBarCode=a.KSD_OrderNumber left join Pb_Basic_Code d on d.PBC_Code=a.KSD_MaterNumber and d.PBC_ID='134' left join v_Contract_OutWare_Details_Sum e on e.vs_ID=a.ID ");
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
            strSql.Append(" ID,ContractNo,ProductsName,ProductsBarCode,ProductsPattern,ProductsUnits,ContractAmount,ContractUnitPrice,ContractDiscount,ContractTotalNet,Contract_SalesUnitPrice,Contract_SalesDiscount,Sum(Contract_SalesTotalNet),ContractRemarks,ContractReceiving,OwnallPID ");
            strSql.Append(" FROM KNet_Sales_ContractList_Details ");
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


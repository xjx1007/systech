using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类Knet_Procure_OrdersList_Details。
    /// </summary>
    public class Knet_Procure_OrdersList_Details
    {
        public Knet_Procure_OrdersList_Details()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string OrderNo, string ProductsBarCode)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = OrderNo;
            parameters[1].Value = ProductsBarCode;

            int result = DbHelperSQL.RunProcedure("Proc_Knet_Procure_OrdersList_Details_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.Knet_Procure_OrdersList_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Knet_Procure_OrdersList_Details(");
            strSql.Append("OrderNo,ProductsName,ProductsBarCode,ProductsPattern,ProductsUnits,OrderAmount,OrderUnitPrice,OrderDiscount,OrderTotalNet,OrderRemarks,HandPrice,HandTotal,ID,KPO_FaterBarCode,KPOD_CPBZNumber,KPOD_BZNumber,KPOD_BrandName)");
            strSql.Append(" values (");
            strSql.Append("@OrderNo,@ProductsName,@ProductsBarCode,@ProductsPattern,@ProductsUnits,@OrderAmount,@OrderUnitPrice,@OrderDiscount,@OrderTotalNet,@OrderRemarks,@HandPrice,@HandTotal,@ID,@KPO_FaterBarCode,@KPOD_CPBZNumber,@KPOD_BZNumber,@KPOD_BrandName)");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsPattern", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsUnits", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderAmount", SqlDbType.Int,4),
					new SqlParameter("@OrderUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@OrderDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@OrderTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@OrderRemarks", SqlDbType.NVarChar,300),
					new SqlParameter("@HandPrice", SqlDbType.Decimal,9),
					new SqlParameter("@HandTotal", SqlDbType.Decimal,9),
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@KPO_FaterBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@KPOD_CPBZNumber", SqlDbType.Int,4),
					new SqlParameter("@KPOD_BZNumber", SqlDbType.Int,4),
					new SqlParameter("@KPOD_BrandName", SqlDbType.NVarChar,150)
                    
                                        };
            parameters[0].Value = model.OrderNo;
            parameters[1].Value = model.ProductsName;
            parameters[2].Value = model.ProductsBarCode;
            parameters[3].Value = model.ProductsPattern;
            parameters[4].Value = model.ProductsUnits;
            parameters[5].Value = model.OrderAmount;
            parameters[6].Value = model.OrderUnitPrice;
            parameters[7].Value = model.OrderDiscount;
            parameters[8].Value = model.OrderTotalNet;
            parameters[9].Value = model.OrderRemarks;
            parameters[10].Value = model.HandPrice;
            parameters[11].Value = model.HandTotal;
            parameters[12].Value = model.ID;
            parameters[13].Value = model.KPO_FaterBarCode;
            parameters[14].Value = model.KPOD_CPBZNumber;
            parameters[15].Value = model.KPOD_BZNumber;
            parameters[16].Value = model.KPOD_BrandName;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.Knet_Procure_OrdersList_Details model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderAmount", SqlDbType.Int,4),
					new SqlParameter("@OrderUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@OrderDiscount", SqlDbType.Decimal,9),
                    new SqlParameter("@OrderTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@OrderRemarks", SqlDbType.NVarChar,300)};

            parameters[0].Value = model.ID;
            parameters[1].Value = model.OrderAmount;
            parameters[2].Value = model.OrderUnitPrice;
            parameters[3].Value = model.OrderDiscount;
            parameters[4].Value = model.OrderTotalNet;
            parameters[5].Value = model.OrderRemarks;

            DbHelperSQL.RunProcedure("Proc_Knet_Procure_OrdersList_Details_Update", parameters, out rowsAffected);
        }


        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void UpdateOrderHaveReceive(KNet.Model.Knet_Procure_OrdersList_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Knet_Procure_OrdersList_Details set ");
            strSql.Append("OrderHaveReceiving=OrderHaveReceiving+@OrderHaveReceiving ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderHaveReceiving", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.OrderHaveReceiving;
            parameters[1].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void UpdateB(KNet.Model.Knet_Procure_OrdersList_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Knet_Procure_OrdersList_Details set ");
            strSql.Append("ProductsUnits=@ProductsUnits,");
            strSql.Append("OrderAmount=@OrderAmount,");
            strSql.Append("HandPrice=@HandPrice,");
            strSql.Append("HandTotal=@HandTotal");
            strSql.Append(" where OrderNo=@OrderNo and ProductsBarCode=@ProductsBarCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsUnits", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderAmount", SqlDbType.Int,4),
					new SqlParameter("@HandPrice", SqlDbType.Decimal,9),
					new SqlParameter("@HandTotal", SqlDbType.Decimal,9)};
            parameters[0].Value = model.ProductsUnits;
            parameters[1].Value = model.OrderAmount;
            parameters[2].Value = model.HandPrice;
            parameters[3].Value = model.HandTotal;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string OrderNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Knet_Procure_OrdersList_Details ");
            strSql.Append(" where OrderNo=@OrderNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderNo", SqlDbType.VarChar,50)};
            parameters[0].Value = OrderNo;

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
        public KNet.Model.Knet_Procure_OrdersList_Details GetModel(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.Knet_Procure_OrdersList_Details model = new KNet.Model.Knet_Procure_OrdersList_Details();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_Knet_Procure_OrdersList_Details_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.OrderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                if (ds.Tables[0].Rows[0]["OrderAmount"].ToString() != "")
                {
                    model.OrderAmount = int.Parse(ds.Tables[0].Rows[0]["OrderAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderUnitPrice"].ToString() != "")
                {
                    model.OrderUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["OrderUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderDiscount"].ToString() != "")
                {
                    model.OrderDiscount = decimal.Parse(ds.Tables[0].Rows[0]["OrderDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderTotalNet"].ToString() != "")
                {
                    model.OrderTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["OrderTotalNet"].ToString());
                }

                if (ds.Tables[0].Rows[0]["OrderHaveReceiving"].ToString() != "")
                {
                    model.OrderHaveReceiving = int.Parse(ds.Tables[0].Rows[0]["OrderHaveReceiving"].ToString());
                }

                if (ds.Tables[0].Rows[0]["OrderHasReturned"].ToString() != "")
                {
                    model.OrderHasReturned = int.Parse(ds.Tables[0].Rows[0]["OrderHasReturned"].ToString());
                }
                model.OrderRemarks = ds.Tables[0].Rows[0]["OrderRemarks"].ToString();
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
        public KNet.Model.Knet_Procure_OrdersList_Details GetModelB(string OrderNo, string ProductsBarCode)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = OrderNo;
            parameters[1].Value = ProductsBarCode;

            KNet.Model.Knet_Procure_OrdersList_Details model = new KNet.Model.Knet_Procure_OrdersList_Details();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_Knet_Procure_OrdersList_Details_GetModelB", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.OrderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                if (ds.Tables[0].Rows[0]["OrderAmount"].ToString() != "")
                {
                    model.OrderAmount = int.Parse(ds.Tables[0].Rows[0]["OrderAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderUnitPrice"].ToString() != "")
                {
                    model.OrderUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["OrderUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderDiscount"].ToString() != "")
                {
                    model.OrderDiscount = decimal.Parse(ds.Tables[0].Rows[0]["OrderDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderTotalNet"].ToString() != "")
                {
                    model.OrderTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["OrderTotalNet"].ToString());
                }

                if (ds.Tables[0].Rows[0]["OrderHaveReceiving"].ToString() != "")
                {
                    model.OrderHaveReceiving = int.Parse(ds.Tables[0].Rows[0]["OrderHaveReceiving"].ToString());
                }

                if (ds.Tables[0].Rows[0]["OrderHasReturned"].ToString() != "")
                {
                    model.OrderHasReturned = int.Parse(ds.Tables[0].Rows[0]["OrderHasReturned"].ToString());
                }
                model.OrderRemarks = ds.Tables[0].Rows[0]["OrderRemarks"].ToString();
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
            strSql.Append("select isnull(e.XPD_Order,0) XPD_Order,a.*,b.OrderDateTime,b.OrderPreToDate,b.OrderType,b.SuppNo,b.KPO_RkState,b.OrderCheckStaffNo,b.SystemDateTimes,b.OrderStaffNo,c.WrkNumber as thisNowAmount,c.WrkNumber*OrderUnitPrice as thistotalNet,c.RkNumber,c.WrkNumber,KPOD_CPBZNumber,KPOD_BZNumber,f.KSP_BZNumber");
            strSql.Append(" FROM Knet_Procure_OrdersList_Details a join KNet_Procure_OrdersList b on a.OrderNo=b.OrderNo left join v_OrderRkDetails c on c.KPO_ID=a.ID left join Xs_Products_Prodocts_Demo e on e.XPD_ProductsBarCode=a.ProductsBarCode and e.XPD_FaterBarCode=a.KPO_FaterBarCode join KNET_Sys_Products f on f.ProductsBarCode=a.ProductsBarCode ");
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
            strSql.Append("select a.*,b.ProductsEdition,c.orderPreToDate ");
            strSql.Append(" FROM Knet_Procure_OrdersList_Details a join KNet_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode join Knet_Procure_OrdersList c on c.OrderNo=a.OrderNo  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_WareHouse_Ownall。
    /// </summary>
    public class KNet_WareHouse_Ownall
    {
        public KNet_WareHouse_Ownall()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string HouseNo,string ProductsBarCode)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@HouseNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = HouseNo;
            parameters[1].Value = ProductsBarCode;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_Ownall_Exists", parameters, out rowsAffected);
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
        ///  增加一条数据 （Y）
        /// </summary>
        public void Add(KNet.Model.KNet_WareHouse_Ownall model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {

					new SqlParameter("@HouseNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsPattern", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsUnits", SqlDbType.NVarChar,50),
					new SqlParameter("@WareHouseAmount", SqlDbType.Int,4),
					new SqlParameter("@WareHouseTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@WareHouseDiscount", SqlDbType.Decimal,9),

                	new SqlParameter("@OrderNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@SingleStorage", SqlDbType.NVarChar,50),
					new SqlParameter("@StorageTime", SqlDbType.DateTime),
					new SqlParameter("@StorageVolume", SqlDbType.Int,4),
					new SqlParameter("@ShippedQuantity", SqlDbType.Int,4)};
        
            parameters[0].Value = model.HouseNo;
            parameters[1].Value = model.ProductsName;
            parameters[2].Value = model.ProductsBarCode;
            parameters[3].Value = model.ProductsPattern;
            parameters[4].Value = model.ProductsUnits;
            parameters[5].Value = model.WareHouseAmount;
            parameters[6].Value = model.WareHouseTotalNet;
            parameters[7].Value = model.WareHouseDiscount;

            parameters[8].Value = model.OrderNumber;
            parameters[9].Value = model.SingleStorage;
            parameters[10].Value = model.StorageTime;
            parameters[11].Value = model.StorageVolume;
            parameters[12].Value = model.ShippedQuantity;

            DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_Ownall_ADD", parameters, out rowsAffected);
        }

        /// <summary>
        ///  更新一条数据 （未查）
        /// </summary>
        public void Update(KNet.Model.KNet_WareHouse_Ownall model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
				
					new SqlParameter("@HouseNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
		

					new SqlParameter("@WareHouseAmount", SqlDbType.Int,4),
					new SqlParameter("@WareHouseTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@WareHouseDiscount", SqlDbType.Decimal,9)};
          
            parameters[0].Value = model.HouseNo;
            parameters[1].Value = model.ProductsBarCode;
          
         
            parameters[2].Value = model.WareHouseAmount;
            parameters[3].Value = model.WareHouseTotalNet;
            parameters[4].Value = model.WareHouseDiscount;

            DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_Ownall_Update", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体（Y）
        /// </summary>
        public KNet.Model.KNet_WareHouse_Ownall GetModel(string HouseNo, string ProductsBarCode)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@HouseNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = HouseNo;
            parameters[1].Value = ProductsBarCode;

            KNet.Model.KNet_WareHouse_Ownall model = new KNet.Model.KNet_WareHouse_Ownall();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_Ownall_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.HouseNo = ds.Tables[0].Rows[0]["HouseNo"].ToString();
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                if (ds.Tables[0].Rows[0]["WareHouseAmount"].ToString() != "")
                {
                    model.WareHouseAmount = int.Parse(ds.Tables[0].Rows[0]["WareHouseAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WareHouseTotalNet"].ToString() != "")
                {
                    model.WareHouseTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["WareHouseTotalNet"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WareHouseDiscount"].ToString() != "")
                {
                    model.WareHouseDiscount = decimal.Parse(ds.Tables[0].Rows[0]["WareHouseDiscount"].ToString());
                }
                model.OrderNumber = ds.Tables[0].Rows[0]["OrderNumber"].ToString();
                model.SingleStorage = ds.Tables[0].Rows[0]["SingleStorage"].ToString();
                if (ds.Tables[0].Rows[0]["StorageTime"].ToString() != "")
                {
                    model.StorageTime = DateTime.Parse(ds.Tables[0].Rows[0]["StorageTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StorageVolume"].ToString() != "")
                {
                    model.StorageVolume = int.Parse(ds.Tables[0].Rows[0]["StorageVolume"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ShippedQuantity"].ToString() != "")
                {
                    model.ShippedQuantity = int.Parse(ds.Tables[0].Rows[0]["ShippedQuantity"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体（Y）
        /// </summary>
        public KNet.Model.KNet_WareHouse_Ownall GetModelB(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;
          

            KNet.Model.KNet_WareHouse_Ownall model = new KNet.Model.KNet_WareHouse_Ownall();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_Ownall_GetModelByID", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.HouseNo = ds.Tables[0].Rows[0]["HouseNo"].ToString();
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                if (ds.Tables[0].Rows[0]["WareHouseAmount"].ToString() != "")
                {
                    model.WareHouseAmount = int.Parse(ds.Tables[0].Rows[0]["WareHouseAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WareHouseTotalNet"].ToString() != "")
                {
                    model.WareHouseTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["WareHouseTotalNet"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WareHouseDiscount"].ToString() != "")
                {
                    model.WareHouseDiscount = decimal.Parse(ds.Tables[0].Rows[0]["WareHouseDiscount"].ToString());
                }

                model.OrderNumber = ds.Tables[0].Rows[0]["OrderNumber"].ToString();
                model.SingleStorage = ds.Tables[0].Rows[0]["SingleStorage"].ToString();
                if (ds.Tables[0].Rows[0]["StorageTime"].ToString() != "")
                {
                    model.StorageTime = DateTime.Parse(ds.Tables[0].Rows[0]["StorageTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StorageVolume"].ToString() != "")
                {
                    model.StorageVolume = int.Parse(ds.Tables[0].Rows[0]["StorageVolume"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ShippedQuantity"].ToString() != "")
                {
                    model.ShippedQuantity = int.Parse(ds.Tables[0].Rows[0]["ShippedQuantity"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得数据列表 （Y）
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,HouseNo,ProductsName,ProductsBarCode,ProductsPattern,ProductsUnits,WareHouseAmount,WareHouseTotalNet,WareHouseDiscount,OrderNumber,SingleStorage,StorageTime,StorageVolume,ShippedQuantity  ");
            strSql.Append(" FROM KNet_WareHouse_Ownall ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  成员方法
    }
}


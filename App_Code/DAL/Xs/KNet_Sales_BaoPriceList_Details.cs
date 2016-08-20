using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;


namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sales_BaoPriceList_Details。
    /// </summary>
    public class KNet_Sales_BaoPriceList_Details
    {
        public KNet_Sales_BaoPriceList_Details()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string BaoPriceNo, string ProductsBarCode)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@BaoPriceNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50)};
                
            parameters[0].Value = BaoPriceNo;
            parameters[1].Value = ProductsBarCode;
          


            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sales_BaoPriceList_Details_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.KNet_Sales_BaoPriceList_Details model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
		
					new SqlParameter("@BaoPriceNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsPattern", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsUnits", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPriceAmount", SqlDbType.Int,4),
					new SqlParameter("@BaoPriceUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@BaoPriceDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@BaoPriceTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@BaoPriceRemarks", SqlDbType.NVarChar,300)};

        
            parameters[0].Value = model.BaoPriceNo;
            parameters[1].Value = model.ProductsName;
            parameters[2].Value = model.ProductsBarCode;
            parameters[3].Value = model.ProductsPattern;
            parameters[4].Value = model.ProductsUnits;
            parameters[5].Value = model.BaoPriceAmount;
            parameters[6].Value = model.BaoPriceUnitPrice;
            parameters[7].Value = model.BaoPriceDiscount;
            parameters[8].Value = model.BaoPriceTotalNet;
            parameters[9].Value = model.BaoPriceRemarks;
            

            DbHelperSQL.RunProcedure("Proc_KNet_Sales_BaoPriceList_Details_ADD", parameters, out rowsAffected);
        }

        /// <summary>
        ///  更新一条数据 （直接更新的）
        /// </summary>
        public void Update(KNet.Model.KNet_Sales_BaoPriceList_Details model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),

					new SqlParameter("@BaoPriceAmount", SqlDbType.Int,4),
				    new SqlParameter("@BaoPriceUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@BaoPriceDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@BaoPriceTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@BaoPriceRemarks", SqlDbType.NVarChar,300)};

            parameters[0].Value = model.ID;

            parameters[1].Value = model.BaoPriceAmount;
            parameters[2].Value = model.BaoPriceUnitPrice;
            parameters[3].Value = model.BaoPriceDiscount;
            parameters[4].Value = model.BaoPriceTotalNet;
            parameters[5].Value = model.BaoPriceRemarks;


            DbHelperSQL.RunProcedure("Proc_KNet_Sales_BaoPriceList_Details_UpdateByID", parameters, out rowsAffected);
        }
        /// <summary>
        ///  更新一条数据 (追加更新）
        /// </summary>
        public void UpdateB(KNet.Model.KNet_Sales_BaoPriceList_Details model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@BaoPriceNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
                    
					new SqlParameter("@BaoPriceAmount", SqlDbType.Int,4),
					new SqlParameter("@BaoPriceDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@BaoPriceTotalNet", SqlDbType.Decimal,9)};

           
            parameters[0].Value = model.BaoPriceNo;  
            parameters[1].Value = model.ProductsBarCode;

            parameters[2].Value = model.BaoPriceAmount;
            parameters[3].Value = model.BaoPriceDiscount;
            parameters[4].Value = model.BaoPriceTotalNet;
          

            DbHelperSQL.RunProcedure("Proc_KNet_Sales_BaoPriceList_Details_UpdateByNo", parameters, out rowsAffected);
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

            DbHelperSQL.RunProcedure("Proc_KNet_Sales_BaoPriceList_Details_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_BaoPriceList_Details GetModel(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_Sales_BaoPriceList_Details model = new KNet.Model.KNet_Sales_BaoPriceList_Details();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_Sales_BaoPriceList_Details_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
               
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.BaoPriceNo = ds.Tables[0].Rows[0]["BaoPriceNo"].ToString();
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                if (ds.Tables[0].Rows[0]["BaoPriceAmount"].ToString() != "")
                {
                    model.BaoPriceAmount = int.Parse(ds.Tables[0].Rows[0]["BaoPriceAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BaoPriceUnitPrice"].ToString() != "")
                {
                    model.BaoPriceUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["BaoPriceUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BaoPriceDiscount"].ToString() != "")
                {
                    model.BaoPriceDiscount = decimal.Parse(ds.Tables[0].Rows[0]["BaoPriceDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BaoPriceTotalNet"].ToString() != "")
                {
                    model.BaoPriceTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["BaoPriceTotalNet"].ToString());
                }
                model.BaoPriceRemarks = ds.Tables[0].Rows[0]["BaoPriceRemarks"].ToString();
                if (ds.Tables[0].Rows[0]["BaoPriceReceiving"].ToString() != "")
                {
                    model.BaoPriceReceiving = int.Parse(ds.Tables[0].Rows[0]["BaoPriceReceiving"].ToString());
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
        public KNet.Model.KNet_Sales_BaoPriceList_Details GetModelB(string BaoPriceNo, string ProductsBarCode)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@BaoPriceNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50)};


            parameters[0].Value = BaoPriceNo;
            parameters[1].Value = ProductsBarCode;
            

            KNet.Model.KNet_Sales_BaoPriceList_Details model = new KNet.Model.KNet_Sales_BaoPriceList_Details();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_Sales_BaoPriceList_Details_GetModelByNo", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
               
                model.BaoPriceNo = ds.Tables[0].Rows[0]["BaoPriceNo"].ToString();
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                if (ds.Tables[0].Rows[0]["BaoPriceAmount"].ToString() != "")
                {
                    model.BaoPriceAmount = int.Parse(ds.Tables[0].Rows[0]["BaoPriceAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BaoPriceUnitPrice"].ToString() != "")
                {
                    model.BaoPriceUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["BaoPriceUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BaoPriceDiscount"].ToString() != "")
                {
                    model.BaoPriceDiscount = decimal.Parse(ds.Tables[0].Rows[0]["BaoPriceDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BaoPriceTotalNet"].ToString() != "")
                {
                    model.BaoPriceTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["BaoPriceTotalNet"].ToString());
                }
                model.BaoPriceRemarks = ds.Tables[0].Rows[0]["BaoPriceRemarks"].ToString();
                if (ds.Tables[0].Rows[0]["BaoPriceReceiving"].ToString() != "")
                {
                    model.BaoPriceReceiving = int.Parse(ds.Tables[0].Rows[0]["BaoPriceReceiving"].ToString());
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
            strSql.Append("select ID,BaoPriceNo,ProductsName,ProductsBarCode,ProductsPattern,ProductsUnits,BaoPriceAmount,BaoPriceUnitPrice,BaoPriceDiscount,BaoPriceTotalNet,BaoPriceRemarks,BaoPriceReceiving ");
            strSql.Append(" FROM KNet_Sales_BaoPriceList_Details ");
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
            strSql.Append(" ID,BaoPriceNo,ProductsName,ProductsBarCode,ProductsPattern,ProductsUnits,BaoPriceAmount,BaoPriceUnitPrice,BaoPriceDiscount,BaoPriceTotalNet,BaoPriceRemarks,BaoPriceReceiving");
            strSql.Append(" FROM KNet_Sales_BaoPriceList_Details ");
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


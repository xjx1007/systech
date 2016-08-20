using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类Knet_Procure_WareHouseList_Details。
    /// </summary>
    public class Knet_Procure_WareHouseList_Details
    {
        public Knet_Procure_WareHouseList_Details()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string WareHouseNo, string ProductsBarCode)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@WareHouseNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = WareHouseNo;
            parameters[1].Value = ProductsBarCode;

            int result = DbHelperSQL.RunProcedure("Proc_Knet_Procure_WareHouseList_Details_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.Knet_Procure_WareHouseList_Details model)
        {


            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Knet_Procure_WareHouseList_Details(");
            strSql.Append("WareHouseNo,ProductsName,ProductsBarCode,ProductsPattern,ProductsUnits,WareHousePack,WareHouseAmount,WareHouseUnitPrice,WareHouseDiscount,WareHouseTotalNet,WareHouseRemarks,WareHouseBAmount,ID,KWP_NoTaxMoney)");
            strSql.Append(" values (");
            strSql.Append("@WareHouseNo,@ProductsName,@ProductsBarCode,@ProductsPattern,@ProductsUnits,@WareHousePack,@WareHouseAmount,@WareHouseUnitPrice,@WareHouseDiscount,@WareHouseTotalNet,@WareHouseRemarks,@WareHouseBAmount,@ID,@KWP_NoTaxMoney)");
            SqlParameter[] parameters = {
					new SqlParameter("@WareHouseNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsPattern", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsUnits", SqlDbType.NVarChar,50),
					new SqlParameter("@WareHousePack", SqlDbType.NVarChar,50),
					new SqlParameter("@WareHouseAmount", SqlDbType.Int,4),
					new SqlParameter("@WareHouseUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@WareHouseDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@WareHouseTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@WareHouseRemarks", SqlDbType.NVarChar,300),
					new SqlParameter("@WareHouseBAmount",SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@KWP_NoTaxMoney", SqlDbType.Decimal,9)
                                        };
            parameters[0].Value = model.WareHouseNo;
            parameters[1].Value = model.ProductsName;
            parameters[2].Value = model.ProductsBarCode;
            parameters[3].Value = model.ProductsPattern;
            parameters[4].Value = model.ProductsUnits;
            parameters[5].Value = model.WareHousePack;
            parameters[6].Value = model.WareHouseAmount;
            parameters[7].Value = model.WareHouseUnitPrice;
            parameters[8].Value = model.WareHouseDiscount;
            parameters[9].Value = model.WareHouseTotalNet;
            parameters[10].Value = model.WareHouseRemarks;
            parameters[11].Value = model.WareHouseBAmount;
            parameters[12].Value = model.ID;
            parameters[13].Value = model.KWP_NoTaxMoney;
            

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// 修改
        /// </summary>
        public bool Update(KNet.Model.Knet_Procure_WareHouseList_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update Knet_Procure_WareHouseList_Details set ");
            strSql.Append("WareHouseNo=@WareHouseNo,");
            strSql.Append("ProductsName=@ProductsName,");
            strSql.Append("ProductsBarCode=@ProductsBarCode,");
            strSql.Append("ProductsPattern=@ProductsPattern,");
            strSql.Append("ProductsUnits=@ProductsUnits,");
            strSql.Append("WareHousePack=@WareHousePack,");
            strSql.Append("WareHouseAmount=@WareHouseAmount,");
            strSql.Append("WareHouseUnitPrice=@WareHouseUnitPrice,");
            strSql.Append("WareHouseTotalNet=@WareHouseTotalNet,");
            strSql.Append("KWP_NoTaxMoney=@KWP_NoTaxMoney,");
            
            strSql.Append("WareHouseRemarks=@WareHouseRemarks");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@WareHouseNo", SqlDbType.VarChar,100),
 new SqlParameter("@ProductsName", SqlDbType.VarChar,100),
 new SqlParameter("@ProductsBarCode", SqlDbType.VarChar,100),
 new SqlParameter("@ProductsPattern", SqlDbType.VarChar,100),
 new SqlParameter("@ProductsUnits", SqlDbType.VarChar,100),
 new SqlParameter("@WareHousePack", SqlDbType.VarChar,100),
 new SqlParameter("@WareHouseAmount", SqlDbType.Int,4),
 new SqlParameter("@WareHouseUnitPrice", SqlDbType.Decimal,9),
 new SqlParameter("@WareHouseTotalNet", SqlDbType.Decimal,9),
new SqlParameter("@KWP_NoTaxMoney", SqlDbType.Decimal,9),
 new SqlParameter("@WareHouseRemarks", SqlDbType.VarChar,600),
new SqlParameter("@ID", SqlDbType.VarChar,100)};
            parameters[0].Value = model.WareHouseNo;
            parameters[1].Value = model.ProductsName;
            parameters[2].Value = model.ProductsBarCode;
            parameters[3].Value = model.ProductsPattern;
            parameters[4].Value = model.ProductsUnits;
            parameters[5].Value = model.WareHousePack;
            parameters[6].Value = model.WareHouseAmount;
            parameters[7].Value = model.WareHouseUnitPrice;
            parameters[8].Value = model.WareHouseTotalNet;
            parameters[9].Value = model.KWP_NoTaxMoney;
            parameters[10].Value = model.WareHouseRemarks;
            parameters[11].Value = model.ID;

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
        /// 得到数据
        /// </summary>

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool UpdateTaxMoney(KNet.Model.Knet_Procure_WareHouseList_Details model)
        {
StringBuilder strSql=new StringBuilder();
strSql.Append("Update Knet_Procure_WareHouseList_Details set ");
strSql.Append("KWP_NoTaxMoney=@KWP_NoTaxMoney,");
strSql.Append("KWP_NoTaxLag=@KWP_NoTaxLag");
strSql.Append(" where ID=@ID ");
SqlParameter[] parameters = {
 new SqlParameter("@KWP_NoTaxMoney", SqlDbType.Decimal,9),
 new SqlParameter("@KWP_NoTaxLag", SqlDbType.Int,4),
new SqlParameter("@ID", SqlDbType.VarChar,100)};
parameters[0].Value = model.KWP_NoTaxMoney;
parameters[1].Value = model.KWP_NoTaxLag;
parameters[2].Value = model.ID;

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
        ///  更新一条数据
        /// </summary>
        public void UpdateByWareHouseNo(string s_WareHouseNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Knet_Procure_WareHouseList_Details set ");
            strSql.Append("ProductsPattern=1 ");
            strSql.Append(" where WareHouseNo=@WareHouseNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@WareHouseNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = s_WareHouseNo;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ID, string ReceivNo, string ProductsBarCode)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
                    new SqlParameter("@ReceivNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;
            parameters[1].Value = ReceivNo;
            parameters[2].Value = ProductsBarCode;

            DbHelperSQL.RunProcedure("Proc_Knet_Procure_WareHouseList_Details_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteByWareHouseNo(string WareHouseNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Knet_Procure_WareHouseList_Details ");
            strSql.Append(" where WareHouseNo=@WareHouseNo  ");
            SqlParameter[] parameters = {
					new SqlParameter("@WareHouseNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = WareHouseNo;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

         /// <summary>
  /// 得到数据
 /// </summary>
public KNet.Model.Knet_Procure_WareHouseList_Details GetModel(string ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from Knet_Procure_WareHouseList_Details  ");
strSql.Append("where ID=@ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@ID", SqlDbType.VarChar,100)
};
parameters[0].Value = ID;
 KNet.Model.Knet_Procure_WareHouseList_Details model = new KNet.Model.Knet_Procure_WareHouseList_Details();
DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
if (ds.Tables[0].Rows.Count > 0)
{
    return DataRowToModel(ds.Tables[0].Rows[0]);
 }
 else
 {
     return null;
 }
   }
  /// <summary>
  /// 得到一个对象实体
 /// </summary>
public KNet.Model.Knet_Procure_WareHouseList_Details DataRowToModel(DataRow row)
{
    KNet.Model.Knet_Procure_WareHouseList_Details model = new KNet.Model.Knet_Procure_WareHouseList_Details();
    if (row != null)
    {
        if (row["ID"] != null)
        {
            model.ID = row["ID"].ToString();
        }
        else
        {
            model.ID = "";
        }
        if (row["WareHouseNo"] != null)
        {
            model.WareHouseNo = row["WareHouseNo"].ToString();
        }
        else
        {
            model.WareHouseNo = "";
        }
        if (row["WareHouseNo"] != null)
        {
            model.WareHouseNo = row["WareHouseNo"].ToString();
        }
        else
        {
            model.WareHouseNo = "";
        }
        if (row["ProductsName"] != null)
        {
            model.ProductsName = row["ProductsName"].ToString();
        }
        else
        {
            model.ProductsName = "";
        }
        if (row["ProductsName"] != null)
        {
            model.ProductsName = row["ProductsName"].ToString();
        }
        else
        {
            model.ProductsName = "";
        }
        if (row["ProductsBarCode"] != null)
        {
            model.ProductsBarCode = row["ProductsBarCode"].ToString();
        }
        else
        {
            model.ProductsBarCode = "";
        }
        if (row["ProductsBarCode"] != null)
        {
            model.ProductsBarCode = row["ProductsBarCode"].ToString();
        }
        else
        {
            model.ProductsBarCode = "";
        }
        if (row["ProductsPattern"] != null)
        {
            model.ProductsPattern = row["ProductsPattern"].ToString();
        }
        else
        {
            model.ProductsPattern = "";
        }
        if (row["ProductsPattern"] != null)
        {
            model.ProductsPattern = row["ProductsPattern"].ToString();
        }
        else
        {
            model.ProductsPattern = "";
        }
        if (row["ProductsUnits"] != null)
        {
            model.ProductsUnits = row["ProductsUnits"].ToString();
        }
        else
        {
            model.ProductsUnits = "";
        }
        if (row["ProductsUnits"] != null)
        {
            model.ProductsUnits = row["ProductsUnits"].ToString();
        }
        else
        {
            model.ProductsUnits = "";
        }
        if (row["WareHousePack"] != null)
        {
            model.WareHousePack = row["WareHousePack"].ToString();
        }
        else
        {
            model.WareHousePack = "";
        }
        if (row["WareHousePack"] != null)
        {
            model.WareHousePack = row["WareHousePack"].ToString();
        }
        else
        {
            model.WareHousePack = "";
        }
        if (row["WareHouseAmount"] != null)
        {
            model.WareHouseAmount = int.Parse(row["WareHouseAmount"].ToString());
        }
        else
        {
            model.WareHouseAmount = 0;
        }
        if (row["WareHouseUnitPrice"] != null)
        {
            model.WareHouseUnitPrice = Decimal.Parse(row["WareHouseUnitPrice"].ToString());
        }
        else
        {
            model.WareHouseUnitPrice = 0;
        }
        if ((row["WareHouseDiscount"] != null)&(row["WareHouseDiscount"].ToString()!=""))
        {
            model.WareHouseDiscount = Decimal.Parse(row["WareHouseDiscount"].ToString());
        }
        else
        {
            model.WareHouseDiscount = 0;
        }
        if ((row["WareHouseTotalNet"] != null) & (row["WareHouseTotalNet"].ToString() != ""))
        {
            model.WareHouseTotalNet = Decimal.Parse(row["WareHouseTotalNet"].ToString());
        }
        else
        {
            model.WareHouseTotalNet = 0;
        }
        if (row["WareHouseRemarks"] != null)
        {
            model.WareHouseRemarks = row["WareHouseRemarks"].ToString();
        }
        else
        {
            model.WareHouseRemarks = "";
        }
        if (row["WareHouseRemarks"] != null)
        {
            model.WareHouseRemarks = row["WareHouseRemarks"].ToString();
        }
        else
        {
            model.WareHouseRemarks = "";
        }
        if (row["WareHouseBAmount"] != null)
        {
            model.WareHouseBAmount = int.Parse(row["WareHouseBAmount"].ToString());
        }
        else
        {
            model.WareHouseBAmount = 0;
        }
        if ((row["KWP_NoTaxMoney"] != null) & (row["KWP_NoTaxMoney"].ToString() != ""))
        {
            model.KWP_NoTaxMoney = Decimal.Parse(row["KWP_NoTaxMoney"].ToString());
        }
        else
        {
            model.KWP_NoTaxMoney = 0;
        }
        if ((row["KWP_NoTaxLag"] != null) & (row["KWP_NoTaxLag"].ToString() != ""))
        {
            model.KWP_NoTaxLag = int.Parse(row["KWP_NoTaxLag"].ToString());
        }
        else
        {
            model.KWP_NoTaxLag = 0;
        }
    }
    return model;
}


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_WareHouseList_Details GetModelByProductsUnits(string ID, string s_OrderNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  *  from Knet_Procure_WareHouseList_Details ");
            strSql.Append(" where ProductsUnits=@ProductsUnits and WareHouseNo=@WareHouseNo ");

            SqlParameter[] parameters = {
					new SqlParameter("@ProductsUnits", SqlDbType.NVarChar,50),
                    new SqlParameter("@WareHouseNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;
            parameters[1].Value = s_OrderNo;

            KNet.Model.Knet_Procure_WareHouseList_Details model = new KNet.Model.Knet_Procure_WareHouseList_Details();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["WareHouseNo"] != null && ds.Tables[0].Rows[0]["WareHouseNo"].ToString() != "")
                {
                    model.WareHouseNo = ds.Tables[0].Rows[0]["WareHouseNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsName"] != null && ds.Tables[0].Rows[0]["ProductsName"].ToString() != "")
                {
                    model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsBarCode"] != null && ds.Tables[0].Rows[0]["ProductsBarCode"].ToString() != "")
                {
                    model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsPattern"] != null && ds.Tables[0].Rows[0]["ProductsPattern"].ToString() != "")
                {
                    model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsUnits"] != null && ds.Tables[0].Rows[0]["ProductsUnits"].ToString() != "")
                {
                    model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                }
                if (ds.Tables[0].Rows[0]["WareHousePack"] != null && ds.Tables[0].Rows[0]["WareHousePack"].ToString() != "")
                {
                    model.WareHousePack = ds.Tables[0].Rows[0]["WareHousePack"].ToString();
                }
                if (ds.Tables[0].Rows[0]["WareHouseAmount"] != null && ds.Tables[0].Rows[0]["WareHouseAmount"].ToString() != "")
                {
                    model.WareHouseAmount = int.Parse(ds.Tables[0].Rows[0]["WareHouseAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WareHouseUnitPrice"] != null && ds.Tables[0].Rows[0]["WareHouseUnitPrice"].ToString() != "")
                {
                    model.WareHouseUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["WareHouseUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WareHouseDiscount"] != null && ds.Tables[0].Rows[0]["WareHouseDiscount"].ToString() != "")
                {
                    model.WareHouseDiscount = decimal.Parse(ds.Tables[0].Rows[0]["WareHouseDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WareHouseTotalNet"] != null && ds.Tables[0].Rows[0]["WareHouseTotalNet"].ToString() != "")
                {
                    model.WareHouseTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["WareHouseTotalNet"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WareHouseRemarks"] != null && ds.Tables[0].Rows[0]["WareHouseRemarks"].ToString() != "")
                {
                    model.WareHouseRemarks = ds.Tables[0].Rows[0]["WareHouseRemarks"].ToString();
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
            strSql.Append(" FROM Knet_Procure_WareHouseList_Details  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  成员方法
    }
}


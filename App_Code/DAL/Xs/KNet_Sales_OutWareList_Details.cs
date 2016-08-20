using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sales_OutWareList_Details。
    /// </summary>
    public class KNet_Sales_OutWareList_Details
    {
        public KNet_Sales_OutWareList_Details()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string OutWareNo, string ProductsBarCode)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@OutWareNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = OutWareNo;
            parameters[1].Value = ProductsBarCode;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sales_OutWareList_Details_Exists", parameters, out rowsAffected);
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
        ///  增加一条数据 （全新添加）
        /// </summary>
        public void Add(KNet.Model.KNet_Sales_OutWareList_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Sales_OutWareList_Details(");
            strSql.Append("OutWareNo,ProductsName,ProductsBarCode,ProductsPattern,ProductsUnits,OutWareAmount,OutWareUnitPrice,OutWareDiscount,OutWareTotalNet,OutWare_SalesUnitPrice,OutWare_SalesDiscount,OutWare_SalesTotalNet,OutWareRemarks,KSO_Battery,KSO_Manual,KSD_BNumber,KSO_ContractDetailsID,RCOrderNo,RCMNo,KSO_IsFollow,KSD_ContractNO,MaterOrderNo,MaterMNo)");
            strSql.Append(" values (");
            strSql.Append("@OutWareNo,@ProductsName,@ProductsBarCode,@ProductsPattern,@ProductsUnits,@OutWareAmount,@OutWareUnitPrice,@OutWareDiscount,@OutWareTotalNet,@OutWare_SalesUnitPrice,@OutWare_SalesDiscount,@OutWare_SalesTotalNet,@OutWareRemarks,@KSO_Battery,@KSO_Manual,@KSD_BNumber,@KSO_ContractDetailsID,@RCOrderNo,@RCMNo,@KSO_IsFollow,@KSD_ContractNO,@MaterOrderNo,@MaterMNo)");
            SqlParameter[] parameters = {
					new SqlParameter("@OutWareNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsPattern", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsUnits", SqlDbType.NVarChar,50),
					new SqlParameter("@OutWareAmount", SqlDbType.Int,4),
					new SqlParameter("@OutWareUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@OutWareDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@OutWareTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@OutWare_SalesUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@OutWare_SalesDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@OutWare_SalesTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@OutWareRemarks", SqlDbType.NVarChar,300),
					new SqlParameter("@KSO_Battery", SqlDbType.NVarChar,50),
					new SqlParameter("@KSO_Manual", SqlDbType.NVarChar,50),
					new SqlParameter("@KSD_BNumber", SqlDbType.Int),
					new SqlParameter("@KSO_ContractDetailsID", SqlDbType.NVarChar,50),
					new SqlParameter("@RCOrderNo", SqlDbType.VarChar,500),
					new SqlParameter("@RCMNo", SqlDbType.VarChar,500),
					new SqlParameter("@KSO_IsFollow", SqlDbType.VarChar,50),
					new SqlParameter("@KSD_ContractNO", SqlDbType.VarChar,50),
					new SqlParameter("@MaterOrderNo", SqlDbType.VarChar,500),
					new SqlParameter("@MaterMNo", SqlDbType.VarChar,500)
                                        };
            parameters[0].Value = model.OutWareNo;
            parameters[1].Value = model.ProductsName;
            parameters[2].Value = model.ProductsBarCode;
            parameters[3].Value = model.ProductsPattern;
            parameters[4].Value = model.ProductsUnits;
            parameters[5].Value = model.OutWareAmount;
            parameters[6].Value = model.OutWareUnitPrice; 
            parameters[7].Value = model.OutWareDiscount;
            parameters[8].Value = model.OutWareTotalNet;
            parameters[9].Value = model.OutWare_SalesUnitPrice;
            parameters[10].Value = model.OutWare_SalesDiscount;
            parameters[11].Value = model.OutWare_SalesTotalNet;
            parameters[12].Value = model.OutWareRemarks;
            parameters[13].Value = model.KSO_Battery;
            parameters[14].Value = model.KSO_Manual;
            parameters[15].Value = model.KSD_BNumber;
            parameters[16].Value = model.KSO_ContractDetailsID;
            parameters[17].Value = model.RCOrderNo;
            parameters[18].Value = model.RCMNo;
            parameters[19].Value = model.KSO_IsFollow;
            parameters[20].Value = model.KSD_ContractNO;
            parameters[21].Value = model.MaterOrderNo;
            parameters[22].Value = model.MaterMNo;
            
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByOutWareNo(string OutWareNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_Sales_OutWareList_Details ");
            strSql.Append(" where OutWareNo=@OutWareNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@OutWareNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = OutWareNo;

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
        ///  更新一条数据 （在明细里修改，只能修改备注信息）
        /// </summary>
        public void Update(KNet.Model.KNet_Sales_OutWareList_Details model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@OutWareRemarks", SqlDbType.NVarChar,300)};

            parameters[0].Value = model.ID;
            parameters[1].Value = model.OutWareRemarks;


            DbHelperSQL.RunProcedure("Proc_KNet_Sales_OutWareList_Details_UpdateByID", parameters, out rowsAffected);
        }
        /// <summary>
        ///  更新一条数据 （追加记录时更新）
        /// </summary>
        public void UpdateB(KNet.Model.KNet_Sales_OutWareList_Details model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					
					new SqlParameter("@OutWareNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),

	
					new SqlParameter("@OutWareAmount", SqlDbType.Int,4),

					new SqlParameter("@OutWareDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@OutWareTotalNet", SqlDbType.Decimal,9),

					new SqlParameter("@OutWare_SalesDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@OutWare_SalesTotalNet", SqlDbType.Decimal,9)};

     
            parameters[0].Value = model.OutWareNo;
            parameters[1].Value = model.ProductsBarCode;

           
            parameters[2].Value = model.OutWareAmount;

           
            parameters[3].Value = model.OutWareDiscount;
            parameters[4].Value = model.OutWareTotalNet;
            
            parameters[5].Value = model.OutWare_SalesDiscount;
            parameters[6].Value = model.OutWare_SalesTotalNet;


            DbHelperSQL.RunProcedure("Proc_KNet_Sales_OutWareList_Details_UpdateByNo", parameters, out rowsAffected);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ID, string ContractNo, string ProductsBarCode)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContractNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;
            parameters[1].Value = ContractNo;
            parameters[2].Value = ProductsBarCode;

            DbHelperSQL.RunProcedure("Proc_KNet_Sales_OutWareList_Details_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_OutWareList_Details GetModel(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_Sales_OutWareList_Details model = new KNet.Model.KNet_Sales_OutWareList_Details();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_Sales_OutWareList_Details_GetModelByID", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.OutWareNo = ds.Tables[0].Rows[0]["OutWareNo"].ToString();
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                if (ds.Tables[0].Rows[0]["OutWareAmount"].ToString() != "")
                {
                    model.OutWareAmount = int.Parse(ds.Tables[0].Rows[0]["OutWareAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutWareUnitPrice"].ToString() != "")
                {
                    model.OutWareUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["OutWareUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutWareDiscount"].ToString() != "")
                {
                    model.OutWareDiscount = decimal.Parse(ds.Tables[0].Rows[0]["OutWareDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutWareTotalNet"].ToString() != "")
                {
                    model.OutWareTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["OutWareTotalNet"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutWare_SalesUnitPrice"].ToString() != "")
                {
                    model.OutWare_SalesUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["OutWare_SalesUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutWare_SalesDiscount"].ToString() != "")
                {
                    model.OutWare_SalesDiscount = decimal.Parse(ds.Tables[0].Rows[0]["OutWare_SalesDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutWare_SalesTotalNet"].ToString() != "")
                {
                    model.OutWare_SalesTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["OutWare_SalesTotalNet"].ToString());
                }
                model.OutWareRemarks = ds.Tables[0].Rows[0]["OutWareRemarks"].ToString();
                if (ds.Tables[0].Rows[0]["OutWareReceiving"].ToString() != "")
                {
                    model.OutWareReceiving = int.Parse(ds.Tables[0].Rows[0]["OutWareReceiving"].ToString());
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
        public KNet.Model.KNet_Sales_OutWareList_Details GetModelB(string OutWareNo, string ProductsBarCode)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@OutWareNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = OutWareNo;
            parameters[1].Value = ProductsBarCode;

            KNet.Model.KNet_Sales_OutWareList_Details model = new KNet.Model.KNet_Sales_OutWareList_Details();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_Sales_OutWareList_Details_GetModelByNo", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.OutWareNo = ds.Tables[0].Rows[0]["OutWareNo"].ToString();
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                if (ds.Tables[0].Rows[0]["OutWareAmount"].ToString() != "")
                {
                    model.OutWareAmount = int.Parse(ds.Tables[0].Rows[0]["OutWareAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutWareUnitPrice"].ToString() != "")
                {
                    model.OutWareUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["OutWareUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutWareDiscount"].ToString() != "")
                {
                    model.OutWareDiscount = decimal.Parse(ds.Tables[0].Rows[0]["OutWareDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutWareTotalNet"].ToString() != "")
                {
                    model.OutWareTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["OutWareTotalNet"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutWare_SalesUnitPrice"].ToString() != "")
                {
                    model.OutWare_SalesUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["OutWare_SalesUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutWare_SalesDiscount"].ToString() != "")
                {
                    model.OutWare_SalesDiscount = decimal.Parse(ds.Tables[0].Rows[0]["OutWare_SalesDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutWare_SalesTotalNet"].ToString() != "")
                {
                    model.OutWare_SalesTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["OutWare_SalesTotalNet"].ToString());
                }
                model.OutWareRemarks = ds.Tables[0].Rows[0]["OutWareRemarks"].ToString();
                if (ds.Tables[0].Rows[0]["OutWareReceiving"].ToString() != "")
                {
                    model.OutWareReceiving = int.Parse(ds.Tables[0].Rows[0]["OutWareReceiving"].ToString());
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
            strSql.Append(" FROM KNet_Sales_OutWareList_Details  ");
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
            strSql.Append(" * ");
            strSql.Append(" FROM KNet_Sales_OutWareList_Details ");
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


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类Knet_Procure_ReturnList_Details。
    /// </summary>
    public class Knet_Procure_ReturnList_Details
    {
        public Knet_Procure_ReturnList_Details()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ReturnNo, string ProductsBarCode)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					 new SqlParameter("@ReturnNo", SqlDbType.NVarChar,50),
                     new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = ReturnNo;
            parameters[1].Value = ProductsBarCode;

            int result = DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReturnList_Details_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.Knet_Procure_ReturnList_Details model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {

					new SqlParameter("@ReturnNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsPattern", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsUnits", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnAmount", SqlDbType.Int,4),
					new SqlParameter("@ReturnUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ReturnDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@ReturnTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@ReturnRemarks", SqlDbType.NVarChar,300)};
        
            parameters[0].Value = model.ReturnNo;
            parameters[1].Value = model.ProductsName;
            parameters[2].Value = model.ProductsBarCode;
            parameters[3].Value = model.ProductsPattern;
            parameters[4].Value = model.ProductsUnits;
            parameters[5].Value = model.ReturnAmount;
            parameters[6].Value = model.ReturnUnitPrice;
            parameters[7].Value = model.ReturnDiscount;
            parameters[8].Value = model.ReturnTotalNet;
            parameters[9].Value = model.ReturnRemarks;

            DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReturnList_Details_ADD", parameters, out rowsAffected);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.Knet_Procure_ReturnList_Details model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnRemarks", SqlDbType.NVarChar,300)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ReturnRemarks;

            DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReturnList_Details_Update", parameters, out rowsAffected);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ID, string OrderNo, string ProductsBarCode)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
                    new SqlParameter("@OrderNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;
            parameters[1].Value = OrderNo;
            parameters[2].Value = ProductsBarCode;

            DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReturnList_Details_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_ReturnList_Details GetModel(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.Knet_Procure_ReturnList_Details model = new KNet.Model.Knet_Procure_ReturnList_Details();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReturnList_Details_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.ReturnNo = ds.Tables[0].Rows[0]["ReturnNo"].ToString();
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                if (ds.Tables[0].Rows[0]["ReturnAmount"].ToString() != "")
                {
                    model.ReturnAmount = int.Parse(ds.Tables[0].Rows[0]["ReturnAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReturnUnitPrice"].ToString() != "")
                {
                    model.ReturnUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["ReturnUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReturnDiscount"].ToString() != "")
                {
                    model.ReturnDiscount = decimal.Parse(ds.Tables[0].Rows[0]["ReturnDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReturnTotalNet"].ToString() != "")
                {
                    model.ReturnTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["ReturnTotalNet"].ToString());
                }
                model.ReturnRemarks = ds.Tables[0].Rows[0]["ReturnRemarks"].ToString();
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
            strSql.Append("select ID,ReturnNo,ProductsName,ProductsBarCode,ProductsPattern,ProductsUnits,ReturnAmount,ReturnUnitPrice,ReturnDiscount,ReturnTotalNet,ReturnRemarks ");
            strSql.Append(" FROM Knet_Procure_ReturnList_Details ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  成员方法
    }
}


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sales_ReturnList_Details。
    /// </summary>
    public class KNet_Sales_ReturnList_Details
    {
        public KNet_Sales_ReturnList_Details()
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

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sales_ReturnList_Details_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.KNet_Sales_ReturnList_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Sales_ReturnList_Details(");
            strSql.Append("ReturnNo,ProductsBarCode,ReturnAmount,Return_SalesUnitPrice,Return_SalesTotalNet,ReturnRemarks)");
            strSql.Append(" values (");
            strSql.Append("@ReturnNo,@ProductsBarCode,@ReturnAmount,@Return_SalesUnitPrice,@Return_SalesTotalNet,@ReturnRemarks)");
            SqlParameter[] parameters = {
					new SqlParameter("@ReturnNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnAmount", SqlDbType.Int,4),
					new SqlParameter("@Return_SalesUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Return_SalesTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@ReturnRemarks", SqlDbType.NVarChar,300)};
            parameters[0].Value = model.ReturnNo;
            parameters[1].Value = model.ProductsBarCode;
            parameters[2].Value = model.ReturnAmount;
            parameters[3].Value = model.Return_SalesUnitPrice;
            parameters[4].Value = model.Return_SalesTotalNet;
            parameters[5].Value = model.ReturnRemarks;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        ///  更新一条数据 （在明细里修改）
        /// </summary>
        public void Update(KNet.Model.KNet_Sales_ReturnList_Details model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnRemarks", SqlDbType.NVarChar,300)};

            parameters[0].Value = model.ID;
            parameters[1].Value = model.ReturnRemarks;

            DbHelperSQL.RunProcedure("Proc_KNet_Sales_ReturnList_Details_UpdateByID", parameters, out rowsAffected);
        }
        /// <summary>
        ///  更新一条数据 （添加时追加记录）
        /// </summary>
        public void UpdateB(KNet.Model.KNet_Sales_ReturnList_Details model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					
					new SqlParameter("@ReturnNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),

		
					new SqlParameter("@ReturnAmount", SqlDbType.Int,4),

					new SqlParameter("@ReturnUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ReturnDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@ReturnTotalNet", SqlDbType.Decimal,9),

					new SqlParameter("@Return_SalesUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Return_SalesDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@Return_SalesTotalNet", SqlDbType.Decimal,9)};

         
            parameters[0].Value = model.ReturnNo;
            parameters[1].Value = model.ProductsBarCode;
      
            parameters[2].Value = model.ReturnAmount;

            parameters[3].Value = model.ReturnUnitPrice;
            parameters[4].Value = model.ReturnDiscount;
            parameters[5].Value = model.ReturnTotalNet;

            parameters[6].Value = model.Return_SalesUnitPrice;
            parameters[7].Value = model.Return_SalesDiscount;
            parameters[8].Value = model.Return_SalesTotalNet;



            DbHelperSQL.RunProcedure("Proc_KNet_Sales_ReturnList_Details_UpdateByNo", parameters, out rowsAffected);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ID, string OutWareNo, string ProductsBarCode)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
                    new SqlParameter("@OutWareNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;
            parameters[1].Value = OutWareNo;
            parameters[2].Value = ProductsBarCode;

            DbHelperSQL.RunProcedure("Proc_KNet_Sales_ReturnList_Details_Delete", parameters, out rowsAffected);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByReturnNo(string ReturnNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_Sales_ReturnList_Details ");
            strSql.Append(" where ReturnNo=@ReturnNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@ReturnNo", SqlDbType.VarChar,50)};
            parameters[0].Value = ReturnNo;

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
        public KNet.Model.KNet_Sales_ReturnList_Details GetModel(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_Sales_ReturnList_Details model = new KNet.Model.KNet_Sales_ReturnList_Details();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_Sales_ReturnList_Details_GetModelByID", parameters, "ds");
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
                if (ds.Tables[0].Rows[0]["Return_SalesUnitPrice"].ToString() != "")
                {
                    model.Return_SalesUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["Return_SalesUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Return_SalesDiscount"].ToString() != "")
                {
                    model.Return_SalesDiscount = decimal.Parse(ds.Tables[0].Rows[0]["Return_SalesDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Return_SalesTotalNet"].ToString() != "")
                {
                    model.Return_SalesTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["Return_SalesTotalNet"].ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_ReturnList_Details GetModelB(string ReturnNo, string ProductsBarCode)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ReturnNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = ReturnNo;
            parameters[1].Value = ProductsBarCode;


            KNet.Model.KNet_Sales_ReturnList_Details model = new KNet.Model.KNet_Sales_ReturnList_Details();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_Sales_ReturnList_Details_GetModelByNo", parameters, "ds");
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
                if (ds.Tables[0].Rows[0]["Return_SalesUnitPrice"].ToString() != "")
                {
                    model.Return_SalesUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["Return_SalesUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Return_SalesDiscount"].ToString() != "")
                {
                    model.Return_SalesDiscount = decimal.Parse(ds.Tables[0].Rows[0]["Return_SalesDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Return_SalesTotalNet"].ToString() != "")
                {
                    model.Return_SalesTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["Return_SalesTotalNet"].ToString());
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
            strSql.Append("select ID,ReturnNo,ProductsName,ProductsBarCode,ProductsPattern,ProductsUnits,ReturnAmount,ReturnUnitPrice,ReturnDiscount,ReturnTotalNet,Return_SalesUnitPrice,Return_SalesDiscount,Return_SalesTotalNet,ReturnRemarks ");
            strSql.Append(" FROM KNet_Sales_ReturnList_Details ");
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
            strSql.Append(" ID,ReturnNo,ProductsName,ProductsBarCode,ProductsPattern,ProductsUnits,ReturnAmount,ReturnUnitPrice,ReturnDiscount,ReturnTotalNet,Return_SalesUnitPrice,Return_SalesDiscount,Return_SalesTotalNet,ReturnRemarks ");
            strSql.Append(" FROM KNet_Sales_ReturnList_Details ");
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


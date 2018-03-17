using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_WareHouse_DirectInto_Details。
    /// </summary>
    public class KNet_WareHouse_DirectInto_Details
    {
        public KNet_WareHouse_DirectInto_Details()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string DirectInNo, string ProductsBarCode)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@DirectInNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = DirectInNo;
            parameters[1].Value = ProductsBarCode;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_DirectInto_Details_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.KNet_WareHouse_DirectInto_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_WareHouse_DirectInto_Details(");
            strSql.Append("DirectInNo,ProductsName,ProductsBarCode,ProductsPattern,ProductsUnits,DirectInAmount,DirectInUnitPrice,DirectInDiscount,DirectInTotalNet,DirectInRemarks)");
            strSql.Append(" values (");
            strSql.Append("@DirectInNo,@ProductsName,@ProductsBarCode,@ProductsPattern,@ProductsUnits,@DirectInAmount,@DirectInUnitPrice,@DirectInDiscount,@DirectInTotalNet,@DirectInRemarks)");
            SqlParameter[] parameters = {
					new SqlParameter("@DirectInNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsPattern", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsUnits", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectInAmount", SqlDbType.Int,4),
					new SqlParameter("@DirectInUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@DirectInDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@DirectInTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@DirectInRemarks", SqlDbType.NVarChar,300)};
            parameters[0].Value = model.DirectInNo;
            parameters[1].Value = model.ProductsName;
            parameters[2].Value = model.ProductsBarCode;
            parameters[3].Value = model.ProductsPattern;
            parameters[4].Value = model.ProductsUnits;
            parameters[5].Value = model.DirectInAmount;
            parameters[6].Value = model.DirectInUnitPrice;
            parameters[7].Value = model.DirectInDiscount;
            parameters[8].Value = model.DirectInTotalNet;
            parameters[9].Value = model.DirectInRemarks;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_WareHouse_DirectInto_Details model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					
			       
					new SqlParameter("@DirectInAmount", SqlDbType.Int,4),
					new SqlParameter("@DirectInUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@DirectInDiscount", SqlDbType.Decimal,9),
				    new SqlParameter("@DirectInTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@DirectInRemarks", SqlDbType.NVarChar,300)};
            parameters[0].Value = model.ID;
           
            parameters[1].Value = model.DirectInAmount;
            parameters[2].Value = model.DirectInUnitPrice;
            parameters[3].Value = model.DirectInDiscount;
            parameters[4].Value = model.DirectInTotalNet;
            parameters[5].Value = model.DirectInRemarks;

            DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_DirectInto_Details_UpdateA", parameters, out rowsAffected);
        }
        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void UpdateB(KNet.Model.KNet_WareHouse_DirectInto_Details model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@DirectInNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
			       
					new SqlParameter("@DirectInAmount", SqlDbType.Int,4),
					new SqlParameter("@DirectInUnitPrice", SqlDbType.Decimal,9)};

            parameters[0].Value = model.DirectInNo;
            parameters[1].Value = model.ProductsBarCode;

            parameters[2].Value = model.DirectInAmount;
            parameters[3].Value = model.DirectInUnitPrice;


            DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_DirectInto_Details_UpdateB", parameters, out rowsAffected);
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

            DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_DirectInto_Details_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteByFID(string FID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_WareHouse_DirectInto_Details ");
            strSql.Append(" where DirectInNo=@DirectInNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@DirectInNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = FID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_DirectInto_Details GetModel(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_WareHouse_DirectInto_Details model = new KNet.Model.KNet_WareHouse_DirectInto_Details();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_DirectInto_Details_GetModelByID", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.DirectInNo = ds.Tables[0].Rows[0]["DirectInNo"].ToString();
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                if (ds.Tables[0].Rows[0]["DirectInAmount"].ToString() != "")
                {
                    model.DirectInAmount = int.Parse(ds.Tables[0].Rows[0]["DirectInAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DirectInUnitPrice"].ToString() != "")
                {
                    model.DirectInUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["DirectInUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DirectInDiscount"].ToString() != "")
                {
                    model.DirectInDiscount = decimal.Parse(ds.Tables[0].Rows[0]["DirectInDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DirectInTotalNet"].ToString() != "")
                {
                    model.DirectInTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["DirectInTotalNet"].ToString());
                }
                model.DirectInRemarks = ds.Tables[0].Rows[0]["DirectInRemarks"].ToString();
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
        public KNet.Model.KNet_WareHouse_DirectInto_Details GetModelB(string DirectInNo, string ProductsBarCode)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@DirectInNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = DirectInNo;
            parameters[1].Value = ProductsBarCode;

            KNet.Model.KNet_WareHouse_DirectInto_Details model = new KNet.Model.KNet_WareHouse_DirectInto_Details();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_DirectInto_Details_GetModelByDirectInNo", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.DirectInNo = ds.Tables[0].Rows[0]["DirectInNo"].ToString();
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                if (ds.Tables[0].Rows[0]["DirectInAmount"].ToString() != "")
                {
                    model.DirectInAmount = int.Parse(ds.Tables[0].Rows[0]["DirectInAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DirectInUnitPrice"].ToString() != "")
                {
                    model.DirectInUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["DirectInUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DirectInDiscount"].ToString() != "")
                {
                    model.DirectInDiscount = decimal.Parse(ds.Tables[0].Rows[0]["DirectInDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DirectInTotalNet"].ToString() != "")
                {
                    model.DirectInTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["DirectInTotalNet"].ToString());
                }
                model.DirectInRemarks = ds.Tables[0].Rows[0]["DirectInRemarks"].ToString();
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
            strSql.Append("select ID,DirectInNo,ProductsName,ProductsBarCode,ProductsPattern,ProductsUnits,DirectInAmount,DirectInUnitPrice,DirectInDiscount,DirectInTotalNet,DirectInRemarks ");
            strSql.Append(" FROM KNet_WareHouse_DirectInto_Details ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  成员方法
    }
}


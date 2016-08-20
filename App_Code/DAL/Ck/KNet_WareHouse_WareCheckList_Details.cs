using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_WareHouse_WareCheckList_Details。
    /// </summary>
    public class KNet_WareHouse_WareCheckList_Details
    {
        public KNet_WareHouse_WareCheckList_Details()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string WareCheckNo, string ProductsBarCode, string OwnallPID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@WareCheckNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@OwnallPID", SqlDbType.NVarChar,50)};


            parameters[0].Value = WareCheckNo;
            parameters[1].Value = ProductsBarCode;
            parameters[2].Value = OwnallPID;


            int result = DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_WareCheckList_Details_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.KNet_WareHouse_WareCheckList_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_WareHouse_WareCheckList_Details(");
            strSql.Append("WareCheckNo,ProductsName,ProductsBarCode,ProductsPattern,ProductsUnits,WareCheckLossUp,WareCheckAmount,WareCheckUnitPrice,WareCheckDiscount,WareCheckTotalNet,WareCheckRemarks,OwnallPID)");
            strSql.Append(" values (");
            strSql.Append("@WareCheckNo,@ProductsName,@ProductsBarCode,@ProductsPattern,@ProductsUnits,@WareCheckLossUp,@WareCheckAmount,@WareCheckUnitPrice,@WareCheckDiscount,@WareCheckTotalNet,@WareCheckRemarks,@OwnallPID)");
            SqlParameter[] parameters = {
					new SqlParameter("@WareCheckNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsPattern", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsUnits", SqlDbType.NVarChar,50),
					new SqlParameter("@WareCheckLossUp", SqlDbType.Int,4),
					new SqlParameter("@WareCheckAmount", SqlDbType.Int,4),
					new SqlParameter("@WareCheckUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@WareCheckDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@WareCheckTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@WareCheckRemarks", SqlDbType.NVarChar,300),
					new SqlParameter("@OwnallPID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.WareCheckNo;
            parameters[1].Value = model.ProductsName;
            parameters[2].Value = model.ProductsBarCode;
            parameters[3].Value = model.ProductsPattern;
            parameters[4].Value = model.ProductsUnits;
            parameters[5].Value = model.WareCheckLossUp;
            parameters[6].Value = model.WareCheckAmount;
            parameters[7].Value = model.WareCheckUnitPrice;
            parameters[8].Value = model.WareCheckDiscount;
            parameters[9].Value = model.WareCheckTotalNet;
            parameters[10].Value = model.WareCheckRemarks;
            parameters[11].Value = model.OwnallPID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        ///  更新一条数据 
        /// </summary>
        public void Update(KNet.Model.KNet_WareHouse_WareCheckList_Details model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
                    new SqlParameter("@WareCheckAmount", SqlDbType.Int,4),
                    new SqlParameter("@WareCheckLossUp", SqlDbType.Int,4),
                    new SqlParameter("@WareCheckDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@WareCheckTotalNet", SqlDbType.Decimal,9),

					new SqlParameter("@WareCheckRemarks", SqlDbType.NVarChar,300),
                    new SqlParameter("@OwnallPID", SqlDbType.NVarChar,50)};

            parameters[0].Value = model.ID;
            parameters[1].Value = model.WareCheckAmount;
            parameters[2].Value = model.WareCheckLossUp;
            parameters[3].Value = model.WareCheckDiscount;
            parameters[4].Value = model.WareCheckTotalNet;
            parameters[5].Value = model.WareCheckRemarks;
            parameters[6].Value = model.OwnallPID;


            DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_WareCheckList_Details_Update", parameters, out rowsAffected);
        }
        /// <summary>
        ///  更新一条数据 
        /// </summary>
        public void UpdateB(KNet.Model.KNet_WareHouse_WareCheckList_Details model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@WareCheckNo", SqlDbType.NVarChar,50),
                	new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),

                    new SqlParameter("@WareCheckAmount", SqlDbType.Int,4),
                    new SqlParameter("@WareCheckLossUp", SqlDbType.Int,4),
                    new SqlParameter("@WareCheckDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@WareCheckTotalNet", SqlDbType.Decimal,9),
                    new SqlParameter("@OwnallPID", SqlDbType.NVarChar,50)};

            parameters[0].Value = model.WareCheckNo;
            parameters[1].Value = model.ProductsBarCode;

            parameters[2].Value = model.WareCheckAmount;
            parameters[3].Value = model.WareCheckLossUp;
            parameters[4].Value = model.WareCheckDiscount;
            parameters[5].Value = model.WareCheckTotalNet;
            parameters[6].Value = model.OwnallPID;

            DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_WareCheckList_Details_UpdateB", parameters, out rowsAffected);
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

            DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_WareCheckList_Details_Delete", parameters, out rowsAffected);
        }

        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteByFID(string WareCheckNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_WareHouse_WareCheckList_Details ");
            strSql.Append(" where WareCheckNo=@WareCheckNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@WareCheckNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = WareCheckNo;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }

        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_WareCheckList_Details GetModel(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_WareHouse_WareCheckList_Details model = new KNet.Model.KNet_WareHouse_WareCheckList_Details();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_WareCheckList_Details_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.OwnallPID = ds.Tables[0].Rows[0]["OwnallPID"].ToString();

                model.WareCheckNo = ds.Tables[0].Rows[0]["WareCheckNo"].ToString();
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();

                if (ds.Tables[0].Rows[0]["WareCheckAmount"].ToString() != "")
                {
                    model.WareCheckAmount = int.Parse(ds.Tables[0].Rows[0]["WareCheckAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WareCheckLossUp"].ToString() != "")
                {
                    model.WareCheckLossUp = int.Parse(ds.Tables[0].Rows[0]["WareCheckLossUp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WareCheckUnitPrice"].ToString() != "")
                {
                    model.WareCheckUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["WareCheckUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WareCheckDiscount"].ToString() != "")
                {
                    model.WareCheckDiscount = decimal.Parse(ds.Tables[0].Rows[0]["WareCheckDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WareCheckTotalNet"].ToString() != "")
                {
                    model.WareCheckTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["WareCheckTotalNet"].ToString());
                }
                model.WareCheckRemarks = ds.Tables[0].Rows[0]["WareCheckRemarks"].ToString();
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
        public KNet.Model.KNet_WareHouse_WareCheckList_Details GetModelB(string WareCheckNo, string ProductsBarCode, string OwnallPID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@WareCheckNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@OwnallPID", SqlDbType.NVarChar,50)};

            parameters[0].Value = WareCheckNo;
            parameters[1].Value = ProductsBarCode;
            parameters[2].Value = OwnallPID;

            KNet.Model.KNet_WareHouse_WareCheckList_Details model = new KNet.Model.KNet_WareHouse_WareCheckList_Details();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_WareCheckList_Details_GetModelB", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.OwnallPID = ds.Tables[0].Rows[0]["OwnallPID"].ToString();

                model.WareCheckNo = ds.Tables[0].Rows[0]["WareCheckNo"].ToString();
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                if (ds.Tables[0].Rows[0]["WareCheckAmount"].ToString() != "")
                {
                    model.WareCheckAmount = int.Parse(ds.Tables[0].Rows[0]["WareCheckAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WareCheckLossUp"].ToString() != "")
                {
                    model.WareCheckLossUp = int.Parse(ds.Tables[0].Rows[0]["WareCheckLossUp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WareCheckUnitPrice"].ToString() != "")
                {
                    model.WareCheckUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["WareCheckUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WareCheckDiscount"].ToString() != "")
                {
                    model.WareCheckDiscount = decimal.Parse(ds.Tables[0].Rows[0]["WareCheckDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WareCheckTotalNet"].ToString() != "")
                {
                    model.WareCheckTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["WareCheckTotalNet"].ToString());
                }
                model.WareCheckRemarks = ds.Tables[0].Rows[0]["WareCheckRemarks"].ToString();
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
            strSql.Append("select a.*,e.KSP_Code ");
            strSql.Append(" FROM KNet_WareHouse_WareCheckList_Details  a join KNET_Sys_Products e on a.ProductsBarCode=e.ProductsBarCode ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  成员方法
    }
}


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_WareHouse_Ownall_Water。
    /// </summary>
    public class KNet_WareHouse_Ownall_Water
    {
        public KNet_WareHouse_Ownall_Water()
        { }
        #region  成员方法
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_WareHouse_Ownall_Water model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					
					new SqlParameter("@HouseNo", SqlDbType.NVarChar,50),
					new SqlParameter("@WaterType", SqlDbType.Int,4),
					new SqlParameter("@WaterDateTime", SqlDbType.DateTime),
					new SqlParameter("@ProductsName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsPattern", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsUnits", SqlDbType.NVarChar,50),
					new SqlParameter("@WaterHousePack", SqlDbType.NVarChar,50),
					new SqlParameter("@WaterHouseAmount", SqlDbType.Int,4),
					new SqlParameter("@WaterHouseUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@WaterHouseDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@WaterHouseTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@WaterSupperUnitsName", SqlDbType.NVarChar,50),
					new SqlParameter("@WaterUnionOrderNo", SqlDbType.NVarChar,50),
					new SqlParameter("@WaterDoStaffNo", SqlDbType.NVarChar,50)};
        
            parameters[0].Value = model.HouseNo;
            parameters[1].Value = model.WaterType;
            parameters[2].Value = model.WaterDateTime;
            parameters[3].Value = model.ProductsName;
            parameters[4].Value = model.ProductsBarCode;
            parameters[5].Value = model.ProductsPattern;
            parameters[6].Value = model.ProductsUnits;
            parameters[7].Value = model.WaterHousePack;
            parameters[8].Value = model.WaterHouseAmount;
            parameters[9].Value = model.WaterHouseUnitPrice;
            parameters[10].Value = model.WaterHouseDiscount;
            parameters[11].Value = model.WaterHouseTotalNet;
            parameters[12].Value = model.WaterSupperUnitsName;
            parameters[13].Value = model.WaterUnionOrderNo;
            parameters[14].Value = model.WaterDoStaffNo;

            DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_Ownall_Water_ADD", parameters, out rowsAffected);
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

            DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_Ownall_Water_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_Ownall_Water GetModel(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_WareHouse_Ownall_Water model = new KNet.Model.KNet_WareHouse_Ownall_Water();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_Ownall_Water_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.HouseNo = ds.Tables[0].Rows[0]["HouseNo"].ToString();
                if (ds.Tables[0].Rows[0]["WaterType"].ToString() != "")
                {
                    model.WaterType = int.Parse(ds.Tables[0].Rows[0]["WaterType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WaterDateTime"].ToString() != "")
                {
                    model.WaterDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["WaterDateTime"].ToString());
                }
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                model.WaterHousePack = ds.Tables[0].Rows[0]["WaterHousePack"].ToString();
                if (ds.Tables[0].Rows[0]["WaterHouseAmount"].ToString() != "")
                {
                    model.WaterHouseAmount = int.Parse(ds.Tables[0].Rows[0]["WaterHouseAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WaterHouseUnitPrice"].ToString() != "")
                {
                    model.WaterHouseUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["WaterHouseUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WaterHouseDiscount"].ToString() != "")
                {
                    model.WaterHouseDiscount = decimal.Parse(ds.Tables[0].Rows[0]["WaterHouseDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WaterHouseTotalNet"].ToString() != "")
                {
                    model.WaterHouseTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["WaterHouseTotalNet"].ToString());
                }
                model.WaterSupperUnitsName = ds.Tables[0].Rows[0]["WaterSupperUnitsName"].ToString();
                model.WaterUnionOrderNo = ds.Tables[0].Rows[0]["WaterUnionOrderNo"].ToString();
                model.WaterDoStaffNo = ds.Tables[0].Rows[0]["WaterDoStaffNo"].ToString();
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
            strSql.Append("select ID,HouseNo,WaterType,WaterDateTime,ProductsName,ProductsBarCode,ProductsPattern,ProductsUnits,WaterHousePack,WaterHouseAmount,WaterHouseUnitPrice,WaterHouseDiscount,WaterHouseTotalNet,WaterSupperUnitsName,WaterUnionOrderNo,WaterDoStaffNo ");
            strSql.Append(" FROM KNet_WareHouse_Ownall_Water ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  成员方法
    }
}


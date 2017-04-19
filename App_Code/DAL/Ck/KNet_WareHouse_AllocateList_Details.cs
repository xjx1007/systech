using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_WareHouse_AllocateList_Details。
    /// </summary>
    public class KNet_WareHouse_AllocateList_Details
    {
        public KNet_WareHouse_AllocateList_Details()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string AllocateNo, string ProductsBarCode, string OwnallPID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@AllocateNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@OwnallPID", SqlDbType.NVarChar,50)};

            parameters[0].Value = AllocateNo;
            parameters[1].Value = ProductsBarCode;
            parameters[2].Value = OwnallPID;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_AllocateList_Details_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.KNet_WareHouse_AllocateList_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_WareHouse_AllocateList_Details(");
            strSql.Append("AllocateNo,ProductsName,ProductsBarCode,ProductsPattern,ProductsUnits,AllocateAmount,AllocateUnitPrice,AllocateDiscount,AllocateTotalNet,AllocateRemarks,OwnallPID,KWAD_FaterBarCode,KWAD_CPBZNumber,KWAD_BZNumber)");
            strSql.Append(" values (");
            strSql.Append("@AllocateNo,@ProductsName,@ProductsBarCode,@ProductsPattern,@ProductsUnits,@AllocateAmount,@AllocateUnitPrice,@AllocateDiscount,@AllocateTotalNet,@AllocateRemarks,@OwnallPID,@KWAD_FaterBarCode,@KWAD_CPBZNumber,@KWAD_BZNumber)");
            SqlParameter[] parameters = {
					new SqlParameter("@AllocateNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsPattern", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsUnits", SqlDbType.NVarChar,50),
					new SqlParameter("@AllocateAmount", SqlDbType.Int,4),
					new SqlParameter("@AllocateUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@AllocateDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@AllocateTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@AllocateRemarks", SqlDbType.NVarChar,300),
					new SqlParameter("@OwnallPID", SqlDbType.NVarChar,50),
					new SqlParameter("@KWAD_FaterBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@KWAD_CPBZNumber", SqlDbType.Int,4),
					new SqlParameter("@KWAD_BZNumber", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.AllocateNo;
            parameters[1].Value = model.ProductsName;
            parameters[2].Value = model.ProductsBarCode;
            parameters[3].Value = model.ProductsPattern;
            parameters[4].Value = model.ProductsUnits;
            parameters[5].Value = model.AllocateAmount;
            parameters[6].Value = model.AllocateUnitPrice;
            parameters[7].Value = model.AllocateDiscount;
            parameters[8].Value = model.AllocateTotalNet;
            parameters[9].Value = model.AllocateRemarks;
            parameters[10].Value = model.OwnallPID;
            parameters[11].Value = model.KWAD_FaterBarCode;
            parameters[12].Value = model.KWAD_CPBZNumber;
            parameters[13].Value = model.KWAD_BZNumber;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        ///  更新一条数据 如果存在记录时更新数据
        /// </summary>
        public void Update(KNet.Model.KNet_WareHouse_AllocateList_Details model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_WareHouse_AllocateList_Details set ");
            strSql.Append("ProductsBarCode=@ProductsBarCode,");
            strSql.Append("AllocateAmount=@AllocateAmount,");
            strSql.Append("AllocateUnitPrice=@AllocateUnitPrice,");
            strSql.Append("AllocateTotalNet=@AllocateTotalNet,");
            strSql.Append("KWAD_FaterBarCode=@KWAD_FaterBarCode");
            
            strSql.Append(" where AllocateNo=@AllocateNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@AllocateAmount", SqlDbType.Int,4),
					new SqlParameter("@AllocateUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@AllocateTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@KWAD_FaterBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@AllocateNo", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = model.ProductsBarCode;
            parameters[1].Value = model.AllocateAmount;
            parameters[2].Value = model.AllocateUnitPrice;
            parameters[3].Value = model.AllocateTotalNet;
            parameters[4].Value = model.KWAD_FaterBarCode;
            parameters[5].Value = model.AllocateNo;


            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateWwPrice(KNet.Model.KNet_WareHouse_AllocateList_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_WareHouse_AllocateList_Details set ");
            strSql.Append("Allocate_WwPrice=@Allocate_WwPrice,");
            strSql.Append("Allocate_WwMoney=@Allocate_WwMoney");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Allocate_WwPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Allocate_WwMoney", SqlDbType.Decimal,9),
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.Allocate_WwPrice;
            parameters[1].Value = model.Allocate_WwMoney;
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
        ///  更新一条数据 如果存在记录时更新数据
        /// </summary>
        public void UpdateB(KNet.Model.KNet_WareHouse_AllocateList_Details model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_WareHouse_AllocateList_Details set ");
            strSql.Append("AllocateNo=@AllocateNo,");
            strSql.Append("ProductsBarCode=@ProductsBarCode,");
            strSql.Append("AllocateAmount=@AllocateAmount,");
            strSql.Append("AllocateTotalNet=@AllocateTotalNet,");
            strSql.Append("OwnallPID=@OwnallPID");
            strSql.Append(" where AllocateNo=@AllocateNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@AllocateNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@AllocateAmount", SqlDbType.Int,4),
					new SqlParameter("@AllocateTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@OwnallPID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.AllocateNo;
            parameters[1].Value = model.ProductsBarCode;
            parameters[2].Value = model.AllocateAmount;
            parameters[3].Value = model.AllocateTotalNet;
            parameters[4].Value = model.OwnallPID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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


            DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_AllocateList_Details_Delete", parameters, out rowsAffected);
        }
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteByAllocateNo(string AllocateNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_WareHouse_AllocateList_Details ");
            strSql.Append(" where AllocateNo=@AllocateNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@AllocateNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = AllocateNo;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }
        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_AllocateList_Details GetModel(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_WareHouse_AllocateList_Details model = new KNet.Model.KNet_WareHouse_AllocateList_Details();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_AllocateList_Details_GetModelByID", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.AllocateNo = ds.Tables[0].Rows[0]["AllocateNo"].ToString();
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                model.OwnallPID = ds.Tables[0].Rows[0]["OwnallPID"].ToString();


                if (ds.Tables[0].Rows[0]["AllocateAmount"].ToString() != "")
                {
                    model.AllocateAmount = int.Parse(ds.Tables[0].Rows[0]["AllocateAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AllocateUnitPrice"].ToString() != "")
                {
                    model.AllocateUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["AllocateUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AllocateDiscount"].ToString() != "")
                {
                    model.AllocateDiscount = decimal.Parse(ds.Tables[0].Rows[0]["AllocateDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AllocateTotalNet"].ToString() != "")
                {
                    model.AllocateTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["AllocateTotalNet"].ToString());
                }
                model.AllocateRemarks = ds.Tables[0].Rows[0]["AllocateRemarks"].ToString();
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
        public KNet.Model.KNet_WareHouse_AllocateList_Details GetModelB(string AllocateNo, string ProductsBarCode, string OwnallPID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@AllocateNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@OwnallPID", SqlDbType.NVarChar,50)};

            parameters[0].Value = AllocateNo;
            parameters[1].Value = ProductsBarCode;
            parameters[2].Value = OwnallPID;


            KNet.Model.KNet_WareHouse_AllocateList_Details model = new KNet.Model.KNet_WareHouse_AllocateList_Details();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_AllocateList_Details_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.AllocateNo = ds.Tables[0].Rows[0]["AllocateNo"].ToString();
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                model.OwnallPID = ds.Tables[0].Rows[0]["OwnallPID"].ToString();

                if (ds.Tables[0].Rows[0]["AllocateAmount"].ToString() != "")
                {
                    model.AllocateAmount = int.Parse(ds.Tables[0].Rows[0]["AllocateAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AllocateUnitPrice"].ToString() != "")
                {
                    model.AllocateUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["AllocateUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AllocateDiscount"].ToString() != "")
                {
                    model.AllocateDiscount = decimal.Parse(ds.Tables[0].Rows[0]["AllocateDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AllocateTotalNet"].ToString() != "")
                {
                    model.AllocateTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["AllocateTotalNet"].ToString());
                }
                model.AllocateRemarks = ds.Tables[0].Rows[0]["AllocateRemarks"].ToString();
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
            strSql.Append(" FROM KNet_WareHouse_AllocateList_Details  a  join KNet_WareHouse_AllocateList b on a.AllocateNo=b.AllocateNo  left join v_Order_ProductsDemo_Details e on e.XPD_ProductsBarCode=a.ProductsBarCode  and e.FaterBarCode=a.KWAD_FaterBarCode  and KWA_OrderNo=OrderNo ");
            strSql.Append(" join knet_sys_products c on a.productsBarCode=c.productsBarCode ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  成员方法
    }
}


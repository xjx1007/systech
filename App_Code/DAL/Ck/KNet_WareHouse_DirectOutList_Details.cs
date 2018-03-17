using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_WareHouse_DirectOutList_Details。
    /// </summary>
    public class KNet_WareHouse_DirectOutList_Details
    {
        public KNet_WareHouse_DirectOutList_Details()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string DirectOutNo, string ProductsBarCode, string OwnallPID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@DirectOutNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
                   
                    new SqlParameter("@OwnallPID", SqlDbType.NVarChar,50)};

            parameters[0].Value = DirectOutNo;
            parameters[1].Value = ProductsBarCode;
            parameters[2].Value = OwnallPID;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_DirectOutList_Details_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.KNet_WareHouse_DirectOutList_Details model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_WareHouse_DirectOutList_Details(");
            strSql.Append("DirectOutNo,ProductsName,ProductsBarCode,ProductsPattern,ProductsUnits,DirectOutAmount,DirectOutUnitPrice,DirectOutDiscount,DirectOutTotalNet,DirectOutRemarks,OwnallPID,KWD_SalesUnitPrice,KWD_SalesTotalNet,KWD_BNumber,KWD_OutWareID,CustomerProductsName,PlanNo,OrderNo,MaterNo,KWD_IsFollow)");
            strSql.Append(" values (");
            strSql.Append("@DirectOutNo,@ProductsName,@ProductsBarCode,@ProductsPattern,@ProductsUnits,@DirectOutAmount,@DirectOutUnitPrice,@DirectOutDiscount,@DirectOutTotalNet,@DirectOutRemarks,@OwnallPID,@KWD_SalesUnitPrice,@KWD_SalesTotalNet,@KWD_BNumber,@KWD_OutWareID,@CustomerProductsName,@PlanNo,@OrderNo,@MaterNo,@KWD_IsFollow)");
            SqlParameter[] parameters = {
					new SqlParameter("@DirectOutNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsPattern", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsUnits", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectOutAmount", SqlDbType.Int,4),
					new SqlParameter("@DirectOutUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@DirectOutDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@DirectOutTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@DirectOutRemarks", SqlDbType.NVarChar,300),
					new SqlParameter("@OwnallPID", SqlDbType.NVarChar,50),
					new SqlParameter("@KWD_SalesUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@KWD_SalesTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@KWD_BNumber", SqlDbType.Int,4),
					new SqlParameter("@KWD_OutWareID", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerProductsName", SqlDbType.NVarChar,100),
					new SqlParameter("@PlanNo", SqlDbType.NVarChar,100),
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,350),
					new SqlParameter("@MaterNo", SqlDbType.NVarChar,350),
					new SqlParameter("@KWD_IsFollow", SqlDbType.NVarChar,350)
                    
                                        };
            parameters[0].Value = model.DirectOutNo;
            parameters[1].Value = model.ProductsName;
            parameters[2].Value = model.ProductsBarCode;
            parameters[3].Value = model.ProductsPattern;
            parameters[4].Value = model.ProductsUnits;
            parameters[5].Value = model.DirectOutAmount;
            parameters[6].Value = model.DirectOutUnitPrice;
            parameters[7].Value = model.DirectOutDiscount;
            parameters[8].Value = model.DirectOutTotalNet;
            parameters[9].Value = model.DirectOutRemarks;
            parameters[10].Value = model.OwnallPID;
            parameters[11].Value = model.KWD_SalesUnitPrice;
            parameters[12].Value = model.KWD_SalesTotalNet;
            parameters[13].Value = model.KWD_BNumber;
            parameters[14].Value = model.KWD_OutWareID;

            parameters[15].Value = model.CustomerProductsName;
            parameters[16].Value = model.PlanNo;
            parameters[17].Value = model.OrderNo;
            parameters[18].Value = model.MaterNo;
            parameters[19].Value = model.KWD_IsFollow;
            
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }
        
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public void AddWithID(KNet.Model.KNet_WareHouse_DirectOutList_Details model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_WareHouse_DirectOutList_Details(");
            strSql.Append("DirectOutNo,ProductsName,ProductsBarCode,ProductsPattern,ProductsUnits,DirectOutAmount,DirectOutUnitPrice,DirectOutDiscount,DirectOutTotalNet,DirectOutRemarks,OwnallPID,KWD_SalesUnitPrice,KWD_SalesTotalNet,KWD_BNumber,ID)");
            strSql.Append(" values (");
            strSql.Append("@DirectOutNo,@ProductsName,@ProductsBarCode,@ProductsPattern,@ProductsUnits,@DirectOutAmount,@DirectOutUnitPrice,@DirectOutDiscount,@DirectOutTotalNet,@DirectOutRemarks,@OwnallPID,@KWD_SalesUnitPrice,@KWD_SalesTotalNet,@KWD_BNumber,@ID)");
            SqlParameter[] parameters = {
					new SqlParameter("@DirectOutNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsPattern", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsUnits", SqlDbType.NVarChar,50),
					new SqlParameter("@DirectOutAmount", SqlDbType.Int,4),
					new SqlParameter("@DirectOutUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@DirectOutDiscount", SqlDbType.Decimal,9),
					new SqlParameter("@DirectOutTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@DirectOutRemarks", SqlDbType.NVarChar,300),
					new SqlParameter("@OwnallPID", SqlDbType.NVarChar,50),
					new SqlParameter("@KWD_SalesUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@KWD_SalesTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@KWD_BNumber", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.DirectOutNo;
            parameters[1].Value = model.ProductsName;
            parameters[2].Value = model.ProductsBarCode;
            parameters[3].Value = model.ProductsPattern;
            parameters[4].Value = model.ProductsUnits;
            parameters[5].Value = model.DirectOutAmount;
            parameters[6].Value = model.DirectOutUnitPrice;
            parameters[7].Value = model.DirectOutDiscount;
            parameters[8].Value = model.DirectOutTotalNet;
            parameters[9].Value = model.DirectOutRemarks;
            parameters[10].Value = model.OwnallPID;
            parameters[11].Value = model.KWD_SalesUnitPrice;
            parameters[12].Value = model.KWD_SalesTotalNet;
            parameters[13].Value = model.KWD_BNumber;
            parameters[14].Value = model.ID;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.KNet_WareHouse_DirectOutList_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_WareHouse_DirectOutList_Details set ");
            strSql.Append("DirectOutAmount=@DirectOutAmount,");
            strSql.Append("DirectOutUnitPrice=@DirectOutUnitPrice,");
            strSql.Append("DirectOutTotalNet=@DirectOutTotalNet,");
            strSql.Append("DirectOutRemarks=@DirectOutRemarks,");
            strSql.Append("DZnumber=@DZnumber,");
            strSql.Append("KWD_SalesUnitPrice=@KWD_SalesUnitPrice,");
            strSql.Append("KWD_SalesTotalNet=@KWD_SalesTotalNet,");
            strSql.Append("KWD_BNumber=@KWD_BNumber");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DirectOutAmount", SqlDbType.Int,4),
					new SqlParameter("@DirectOutUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@DirectOutTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@DirectOutRemarks", SqlDbType.NVarChar,300),
					new SqlParameter("@DZnumber", SqlDbType.Decimal,9),
					new SqlParameter("@KWD_SalesUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@KWD_SalesTotalNet", SqlDbType.Decimal,9),
					new SqlParameter("@KWD_BNumber", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.DirectOutAmount;
            parameters[1].Value = model.DirectOutUnitPrice;
            parameters[2].Value = model.DirectOutTotalNet;
            parameters[3].Value = model.DirectOutRemarks;
            parameters[4].Value = model.DZnumber == null ? 0 : model.DZnumber;
            parameters[5].Value = model.KWD_SalesUnitPrice;
            parameters[6].Value = model.KWD_SalesTotalNet;
            parameters[7].Value = model.KWD_BNumber;
            parameters[8].Value = model.ID;

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
        /// 
        /// </summary>
        public void UpdateDzNumber(KNet.Model.KNet_WareHouse_DirectOutList_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_WareHouse_DirectOutList_Details set ");
            strSql.Append("DZNumber=@DZNumber");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@DZNumber", SqlDbType.Decimal,9),
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.DZnumber;
            parameters[1].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        ///  更新一条数据 （重新添加如果已有记录里更新记录的）
        /// </summary>
        public void UpdateB(KNet.Model.KNet_WareHouse_DirectOutList_Details model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@DirectOutNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@OwnallPID", SqlDbType.NVarChar,50),

					new SqlParameter("@DirectOutAmount", SqlDbType.Int,4)};

            parameters[0].Value = model.ProductsBarCode;
            parameters[1].Value = model.DirectOutNo;
            parameters[2].Value = model.OwnallPID;
            parameters[3].Value = model.DirectOutAmount;
           

            DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_DirectOutList_Details_UpdateB", parameters, out rowsAffected);
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
     

            DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_DirectOutList_Details_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteByDirectOutNO(string DirectOutNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_WareHouse_DirectOutList_Details ");
            strSql.Append(" where DirectOutNo=@DirectOutNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@DirectOutNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = DirectOutNo;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_DirectOutList_Details GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from KNet_WareHouse_DirectOutList_Details ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_WareHouse_DirectOutList_Details model = new KNet.Model.KNet_WareHouse_DirectOutList_Details();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DirectOutNo"] != null && ds.Tables[0].Rows[0]["DirectOutNo"].ToString() != "")
                {
                    model.DirectOutNo = ds.Tables[0].Rows[0]["DirectOutNo"].ToString();
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
                if (ds.Tables[0].Rows[0]["DirectOutAmount"] != null && ds.Tables[0].Rows[0]["DirectOutAmount"].ToString() != "")
                {
                    model.DirectOutAmount = int.Parse(ds.Tables[0].Rows[0]["DirectOutAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DirectOutUnitPrice"] != null && ds.Tables[0].Rows[0]["DirectOutUnitPrice"].ToString() != "")
                {
                    model.DirectOutUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["DirectOutUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DirectOutDiscount"] != null && ds.Tables[0].Rows[0]["DirectOutDiscount"].ToString() != "")
                {
                    model.DirectOutDiscount = decimal.Parse(ds.Tables[0].Rows[0]["DirectOutDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DirectOutTotalNet"] != null && ds.Tables[0].Rows[0]["DirectOutTotalNet"].ToString() != "")
                {
                    model.DirectOutTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["DirectOutTotalNet"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DirectOutRemarks"] != null && ds.Tables[0].Rows[0]["DirectOutRemarks"].ToString() != "")
                {
                    model.DirectOutRemarks = ds.Tables[0].Rows[0]["DirectOutRemarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OwnallPID"] != null && ds.Tables[0].Rows[0]["OwnallPID"].ToString() != "")
                {
                    model.OwnallPID = ds.Tables[0].Rows[0]["OwnallPID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DZnumber"] != null && ds.Tables[0].Rows[0]["DZnumber"].ToString() != "")
                {
                    model.DZnumber = decimal.Parse(ds.Tables[0].Rows[0]["DZnumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KWD_SalesUnitPrice"] != null && ds.Tables[0].Rows[0]["KWD_SalesUnitPrice"].ToString() != "")
                {
                    model.KWD_SalesUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["KWD_SalesUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KWD_SalesTotalNet"] != null && ds.Tables[0].Rows[0]["KWD_SalesTotalNet"].ToString() != "")
                {
                    model.KWD_SalesTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["KWD_SalesTotalNet"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KWD_BNumber"] != null && ds.Tables[0].Rows[0]["KWD_BNumber"].ToString() != "")
                {
                    model.KWD_BNumber = int.Parse(ds.Tables[0].Rows[0]["KWD_BNumber"].ToString());
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
        public KNet.Model.KNet_WareHouse_DirectOutList_Details GetModelB(string ProductsBarCode, string DirectOutNo, string OwnallPID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@DirectOutNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@OwnallPID", SqlDbType.NVarChar,50)};

            parameters[0].Value = ProductsBarCode;
            parameters[1].Value = DirectOutNo;
            parameters[2].Value = OwnallPID;

            KNet.Model.KNet_WareHouse_DirectOutList_Details model = new KNet.Model.KNet_WareHouse_DirectOutList_Details();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_DirectOutList_Details_GetModelB", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.DirectOutNo = ds.Tables[0].Rows[0]["DirectOutNo"].ToString();
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                model.OwnallPID = ds.Tables[0].Rows[0]["OwnallPID"].ToString();

                if (ds.Tables[0].Rows[0]["DirectOutAmount"].ToString() != "")
                {
                    model.DirectOutAmount = int.Parse(ds.Tables[0].Rows[0]["DirectOutAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DirectOutUnitPrice"].ToString() != "")
                {
                    model.DirectOutUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["DirectOutUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DirectOutDiscount"].ToString() != "")
                {
                    model.DirectOutDiscount = decimal.Parse(ds.Tables[0].Rows[0]["DirectOutDiscount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DirectOutTotalNet"].ToString() != "")
                {
                    model.DirectOutTotalNet = decimal.Parse(ds.Tables[0].Rows[0]["DirectOutTotalNet"].ToString());
                }
                model.DirectOutRemarks = ds.Tables[0].Rows[0]["DirectOutRemarks"].ToString();
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
            strSql.Append("select *,DirectOutAmount+Isnull(KWD_BNumber,0) as TotalNumber ");
            strSql.Append(" FROM KNet_WareHouse_DirectOutList_Details  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  成员方法
    }
}


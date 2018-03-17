using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类Knet_Procure_SuppliersPrice。
    /// </summary>
    public class Knet_Procure_SuppliersPrice
    {
        public Knet_Procure_SuppliersPrice()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SuppNo, string ProductsBarCode)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@SuppNo", SqlDbType.NVarChar,50),
                    new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = SuppNo;
            parameters[1].Value = ProductsBarCode;
            int result = DbHelperSQL.RunProcedure("Proc_Knet_Procure_SuppliersPrice_Exists", parameters, out rowsAffected);
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
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Knet_Procure_SuppliersPrice model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Knet_Procure_SuppliersPrice(");
            strSql.Append("SuppNo,ProductsName,ProductsBarCode,ProductsPattern,ProductsMainCategory,ProductsSmallCategory,ProductsUnits,ProcureMinShu,ProcureUnitPrice,ProcureState,ProcureUpdateDateTime,Salesprice,HandPrice,KPP_Remarks,KPP_CgID,KPP_IsOrder,KPP_Address,KPP_Number,KPP_Creator,KPP_Code,KPP_ShPerson,KPP_ShTime,KPP_AllRemarks,KPP_Brand)");
            strSql.Append(" values (");
            strSql.Append("@SuppNo,@ProductsName,@ProductsBarCode,@ProductsPattern,@ProductsMainCategory,@ProductsSmallCategory,@ProductsUnits,@ProcureMinShu,@ProcureUnitPrice,@ProcureState,@ProcureUpdateDateTime,@Salesprice,@HandPrice,@KPP_Remarks,@KPP_CgID,@KPP_IsOrder,@KPP_Address,@KPP_Number,@KPP_Creator,@KPP_Code,@KPP_ShPerson,@KPP_ShTime,@KPP_AllRemarks,@KPP_Brand)");
            SqlParameter[] parameters = {
					new SqlParameter("@SuppNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsPattern", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsMainCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsSmallCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsUnits", SqlDbType.NVarChar,50),
					new SqlParameter("@ProcureMinShu", SqlDbType.Int,4),
					new SqlParameter("@ProcureUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ProcureState", SqlDbType.Int,4),
					new SqlParameter("@ProcureUpdateDateTime", SqlDbType.DateTime),
					new SqlParameter("@Salesprice", SqlDbType.Decimal,9),
					new SqlParameter("@HandPrice", SqlDbType.Decimal,9),
					new SqlParameter("@KPP_Remarks", SqlDbType.NVarChar,250),
					new SqlParameter("@KPP_CgID", SqlDbType.NVarChar,50),
					new SqlParameter("@KPP_IsOrder", SqlDbType.NVarChar,50),
					new SqlParameter("@KPP_Address", SqlDbType.NVarChar,50),
					new SqlParameter("@KPP_Number", SqlDbType.Int,4),
					new SqlParameter("@KPP_Creator", SqlDbType.NVarChar,50),
					new SqlParameter("@KPP_Code", SqlDbType.NVarChar,50),
					new SqlParameter("@KPP_ShPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@KPP_ShTime", SqlDbType.DateTime),
					new SqlParameter("@KPP_AllRemarks", SqlDbType.Text),
					new SqlParameter("@KPP_Brand", SqlDbType.NVarChar,50)
                    
                                        };
            parameters[0].Value = model.SuppNo;
            parameters[1].Value = model.ProductsName;
            parameters[2].Value = model.ProductsBarCode;
            parameters[3].Value = model.ProductsPattern;
            parameters[4].Value = model.ProductsMainCategory;
            parameters[5].Value = model.ProductsSmallCategory;
            parameters[6].Value = model.ProductsUnits;
            parameters[7].Value = model.ProcureMinShu;
            parameters[8].Value = model.ProcureUnitPrice;
            parameters[9].Value = model.ProcureState;
            parameters[10].Value = model.ProcureUpdateDateTime;
            parameters[11].Value = model.Salesprice;
            parameters[12].Value = model.HandPrice;
            parameters[13].Value = model.KPP_Remarks;
            parameters[14].Value = model.KPP_CgID;
            parameters[15].Value = model.KPP_IsOrder;
            parameters[16].Value = model.KPP_Address;
            parameters[17].Value = model.KPP_Number;
            

            parameters[18].Value = model.KPP_Creator;
            parameters[19].Value = model.KPP_Code;
            parameters[20].Value = model.KPP_ShPerson;
            parameters[21].Value = model.KPP_ShTime;
            parameters[22].Value = model.KPP_AllRemarks;
            parameters[23].Value = model.KPP_Brand;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.Knet_Procure_SuppliersPrice model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),

					new SqlParameter("@ProcureMinShu", SqlDbType.Int,4),
					new SqlParameter("@ProcureUnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ProcureState", SqlDbType.Int,4),
					new SqlParameter("@ProcureUpdateDateTime", SqlDbType.DateTime),
                    new SqlParameter("@Salesprice", SqlDbType.Decimal,9)};

            parameters[0].Value = model.ID;
          
            parameters[1].Value = model.ProcureMinShu;
            parameters[2].Value = model.ProcureUnitPrice;
            parameters[3].Value = model.ProcureState;
            parameters[4].Value = model.ProcureUpdateDateTime;
            parameters[5].Value = model.Salesprice;

            DbHelperSQL.RunProcedure("Proc_Knet_Procure_SuppliersPrice_Update", parameters, out rowsAffected);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void UpdateState(KNet.Model.Knet_Procure_SuppliersPrice model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update Knet_Procure_SuppliersPrice Set KPP_State=@KPP_State,  ");
            strSql.Append(" KPP_ShTime=@KPP_ShTime,  ");
            strSql.Append(" KPP_ShPerson=@KPP_ShPerson  ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@KPP_State", SqlDbType.Int),
					new SqlParameter("@KPP_ShTime", SqlDbType.DateTime),
					new SqlParameter("@KPP_ShPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = model.KPP_State;
            parameters[1].Value = model.KPP_ShTime;
            parameters[2].Value = model.KPP_ShPerson;
            parameters[3].Value = model.ID;

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

            DbHelperSQL.RunProcedure("Proc_Knet_Procure_SuppliersPrice_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteBYModel(KNet.Model.Knet_Procure_SuppliersPrice model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update Knet_Procure_SuppliersPrice Set KPP_Del='1'  ");
            strSql.Append(" where SuppNo=@SuppNo  and ProductsBarCode=@ProductsBarCode and KPP_Brand=@KPP_Brand and KPP_Del='0' ");
            SqlParameter[] parameters = {
					new SqlParameter("@SuppNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@KPP_Brand", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = model.SuppNo;
            parameters[1].Value = model.ProductsBarCode;
            parameters[2].Value = model.KPP_Brand;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_SuppliersPrice GetModel(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Knet_Procure_SuppliersPrice ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.Knet_Procure_SuppliersPrice model = new KNet.Model.Knet_Procure_SuppliersPrice();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppNo"] != null && ds.Tables[0].Rows[0]["SuppNo"].ToString() != "")
                {
                    model.SuppNo = ds.Tables[0].Rows[0]["SuppNo"].ToString();
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
                if (ds.Tables[0].Rows[0]["ProductsMainCategory"] != null && ds.Tables[0].Rows[0]["ProductsMainCategory"].ToString() != "")
                {
                    model.ProductsMainCategory = ds.Tables[0].Rows[0]["ProductsMainCategory"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsSmallCategory"] != null && ds.Tables[0].Rows[0]["ProductsSmallCategory"].ToString() != "")
                {
                    model.ProductsSmallCategory = ds.Tables[0].Rows[0]["ProductsSmallCategory"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsUnits"] != null && ds.Tables[0].Rows[0]["ProductsUnits"].ToString() != "")
                {
                    model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProcureMinShu"] != null && ds.Tables[0].Rows[0]["ProcureMinShu"].ToString() != "")
                {
                    model.ProcureMinShu = int.Parse(ds.Tables[0].Rows[0]["ProcureMinShu"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProcureUnitPrice"] != null && ds.Tables[0].Rows[0]["ProcureUnitPrice"].ToString() != "")
                {
                    model.ProcureUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["ProcureUnitPrice"].ToString());
                }
                else
                {
                    model.ProcureUnitPrice = 0; 
                }
                if (ds.Tables[0].Rows[0]["ProcureState"] != null && ds.Tables[0].Rows[0]["ProcureState"].ToString() != "")
                {
                    model.ProcureState = int.Parse(ds.Tables[0].Rows[0]["ProcureState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProcureUpdateDateTime"] != null && ds.Tables[0].Rows[0]["ProcureUpdateDateTime"].ToString() != "")
                {
                    model.ProcureUpdateDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["ProcureUpdateDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Salesprice"] != null && ds.Tables[0].Rows[0]["Salesprice"].ToString() != "")
                {
                    model.Salesprice = decimal.Parse(ds.Tables[0].Rows[0]["Salesprice"].ToString());
                }
                else
                {
                    model.Salesprice = 0;
                }
                if (ds.Tables[0].Rows[0]["HandPrice"] != null && ds.Tables[0].Rows[0]["HandPrice"].ToString() != "")
                {
                    model.HandPrice = decimal.Parse(ds.Tables[0].Rows[0]["HandPrice"].ToString());
                }
                else
                {
                    model.HandPrice = 0;
                }

                if (ds.Tables[0].Rows[0]["KPP_State"] != null && ds.Tables[0].Rows[0]["KPP_State"].ToString() != "")
                {
                    model.KPP_State = int.Parse(ds.Tables[0].Rows[0]["KPP_State"].ToString());
                }
                else
                {
                    model.KPP_State = 0;
                }

                if (ds.Tables[0].Rows[0]["KPP_Creator"] != null && ds.Tables[0].Rows[0]["KPP_Creator"].ToString() != "")
                {
                    model.KPP_Creator = ds.Tables[0].Rows[0]["KPP_Creator"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KPP_Code"] != null && ds.Tables[0].Rows[0]["KPP_Code"].ToString() != "")
                {
                    model.KPP_Code = ds.Tables[0].Rows[0]["KPP_Code"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KPP_ShPerson"] != null && ds.Tables[0].Rows[0]["KPP_ShPerson"].ToString() != "")
                {
                    model.KPP_ShPerson = ds.Tables[0].Rows[0]["KPP_ShPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPP_ShTime"] != null && ds.Tables[0].Rows[0]["KPP_ShTime"].ToString() != "")
                {
                    model.KPP_ShTime = DateTime.Parse(ds.Tables[0].Rows[0]["KPP_ShTime"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KPP_Del"] != null && ds.Tables[0].Rows[0]["KPP_Del"].ToString() != "")
                {
                    model.KPP_Del = int.Parse(ds.Tables[0].Rows[0]["KPP_Del"].ToString());
                }
                else
                {
                    model.KPP_Del = 0;
                }


                if (ds.Tables[0].Rows[0]["KPP_AllRemarks"] != null && ds.Tables[0].Rows[0]["KPP_AllRemarks"].ToString() != "")
                {
                    model.KPP_AllRemarks = ds.Tables[0].Rows[0]["KPP_AllRemarks"].ToString();
                }
                else
                {
                    model.KPP_AllRemarks = "";
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
        public KNet.Model.Knet_Procure_SuppliersPrice GetModelByProductsBarCode(string ProductsBarCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Knet_Procure_SuppliersPrice ");
            strSql.Append(" where ProductsBarCode=@ProductsBarCode Order BY ProcureUpdateDateTime desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = ProductsBarCode;

            KNet.Model.Knet_Procure_SuppliersPrice model = new KNet.Model.Knet_Procure_SuppliersPrice();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SuppNo"] != null && ds.Tables[0].Rows[0]["SuppNo"].ToString() != "")
                {
                    model.SuppNo = ds.Tables[0].Rows[0]["SuppNo"].ToString();
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
                if (ds.Tables[0].Rows[0]["ProductsMainCategory"] != null && ds.Tables[0].Rows[0]["ProductsMainCategory"].ToString() != "")
                {
                    model.ProductsMainCategory = ds.Tables[0].Rows[0]["ProductsMainCategory"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsSmallCategory"] != null && ds.Tables[0].Rows[0]["ProductsSmallCategory"].ToString() != "")
                {
                    model.ProductsSmallCategory = ds.Tables[0].Rows[0]["ProductsSmallCategory"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsUnits"] != null && ds.Tables[0].Rows[0]["ProductsUnits"].ToString() != "")
                {
                    model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProcureMinShu"] != null && ds.Tables[0].Rows[0]["ProcureMinShu"].ToString() != "")
                {
                    model.ProcureMinShu = int.Parse(ds.Tables[0].Rows[0]["ProcureMinShu"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProcureUnitPrice"] != null && ds.Tables[0].Rows[0]["ProcureUnitPrice"].ToString() != "")
                {
                    model.ProcureUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["ProcureUnitPrice"].ToString());
                }
                else
                {
                    model.ProcureUnitPrice = 0;
                }
                if (ds.Tables[0].Rows[0]["ProcureState"] != null && ds.Tables[0].Rows[0]["ProcureState"].ToString() != "")
                {
                    model.ProcureState = int.Parse(ds.Tables[0].Rows[0]["ProcureState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProcureUpdateDateTime"] != null && ds.Tables[0].Rows[0]["ProcureUpdateDateTime"].ToString() != "")
                {
                    model.ProcureUpdateDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["ProcureUpdateDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Salesprice"] != null && ds.Tables[0].Rows[0]["Salesprice"].ToString() != "")
                {
                    model.Salesprice = decimal.Parse(ds.Tables[0].Rows[0]["Salesprice"].ToString());
                }
                else
                {
                    model.Salesprice = 0;
                }
                if (ds.Tables[0].Rows[0]["HandPrice"] != null && ds.Tables[0].Rows[0]["HandPrice"].ToString() != "")
                {
                    model.HandPrice = decimal.Parse(ds.Tables[0].Rows[0]["HandPrice"].ToString());
                }
                else
                {
                    model.HandPrice = 0;
                }

                if (ds.Tables[0].Rows[0]["KPP_Creator"] != null && ds.Tables[0].Rows[0]["KPP_Creator"].ToString() != "")
                {
                    model.KPP_Creator = ds.Tables[0].Rows[0]["KPP_Creator"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KPP_Code"] != null && ds.Tables[0].Rows[0]["KPP_Code"].ToString() != "")
                {
                    model.KPP_Code = ds.Tables[0].Rows[0]["KPP_Code"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KPP_ShPerson"] != null && ds.Tables[0].Rows[0]["KPP_ShPerson"].ToString() != "")
                {
                    model.KPP_ShPerson = ds.Tables[0].Rows[0]["KPP_ShPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KPP_ShTime"] != null && ds.Tables[0].Rows[0]["KPP_ShTime"].ToString() != "")
                {
                    model.KPP_ShTime = DateTime.Parse(ds.Tables[0].Rows[0]["KPP_ShTime"].ToString());
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
        public KNet.Model.Knet_Procure_SuppliersPrice GetModelB(string SuppNo, string ProductsBarCode)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@SuppNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = SuppNo;
            parameters[1].Value = ProductsBarCode;

            KNet.Model.Knet_Procure_SuppliersPrice model = new KNet.Model.Knet_Procure_SuppliersPrice();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_Knet_Procure_SuppliersPrice_GetModelB", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.SuppNo = ds.Tables[0].Rows[0]["SuppNo"].ToString();
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                model.ProductsMainCategory = ds.Tables[0].Rows[0]["ProductsMainCategory"].ToString();
                model.ProductsSmallCategory = ds.Tables[0].Rows[0]["ProductsSmallCategory"].ToString();
                model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                if (ds.Tables[0].Rows[0]["ProcureMinShu"].ToString() != "")
                {
                    model.ProcureMinShu = int.Parse(ds.Tables[0].Rows[0]["ProcureMinShu"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProcureUnitPrice"].ToString() != "")
                {
                    model.ProcureUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["ProcureUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProcureState"].ToString() != "")
                {
                    model.ProcureState = int.Parse(ds.Tables[0].Rows[0]["ProcureState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProcureUpdateDateTime"].ToString() != "")
                {
                    model.ProcureUpdateDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["ProcureUpdateDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Salesprice"].ToString() != "")
                {
                    model.Salesprice = decimal.Parse(ds.Tables[0].Rows[0]["Salesprice"].ToString());
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
            strSql.Append("select isnull(KPP_Number,1) as KPP_Number, *,isnull(PPB_BrandName,'') as BrandName ");
            strSql.Append(" FROM Knet_Procure_SuppliersPrice a join v_ProductsList b on a.ProductsBarCode=b.v_ProductsBarCode left  join PB_Products_Brand c on c.PPB_ID=a.KPP_Brand ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetTop(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 isnull(KPP_Number,1) as KPP_Number, * ");
            strSql.Append(" FROM Knet_Procure_SuppliersPrice ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where KPP_Del=0 and " + strWhere);
            }
            strSql.Append(" order by procureUpdateDateTime desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}
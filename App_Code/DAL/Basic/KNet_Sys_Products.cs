using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sys_Products。
    /// </summary>
    public class KNet_Sys_Products
    {
        public KNet_Sys_Products()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(KNet.Model.KNet_Sys_Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KNet_Sys_Products");
            strSql.Append(" where ProductsName=@ProductsName and ProductsEdition=@ProductsEdition ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsEdition", SqlDbType.VarChar,200)};
            parameters[0].Value = model.ProductsName;
            parameters[1].Value = model.ProductsEdition;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool ExistsProductsEdition(string ProductsName, string s_ProductsEdition)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KNet_Sys_Products");
            strSql.Append(" where ProductsName=@ProductsName and ProductsEdition=@ProductsEdition ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsEdition", SqlDbType.VarChar,200)};
            parameters[0].Value = ProductsName;
            parameters[1].Value = s_ProductsEdition;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        public bool ExistsProductsPattern(string ProductsName, string s_ProductsPattern)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KNet_Sys_Products");
            strSql.Append(" where ProductsName=@ProductsName and ProductsPattern=@ProductsPattern ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsPattern", SqlDbType.VarChar,200)};
            parameters[0].Value = ProductsName;
            parameters[1].Value = s_ProductsPattern;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateSampleID(KNet.Model.KNet_Sys_Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Sys_Products set ");
            strSql.Append("KSP_SampleId=@KSP_SampleId ");
            strSql.Append(" where ProductsBarCode=@ProductsBarCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@KSP_SampleId", SqlDbType.VarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KSP_SampleId;
            parameters[1].Value = model.ProductsBarCode;

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
        /// 更新一条数据
        /// </summary>
        public bool UpdateBySampleID(string s_KSP_SampleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Sys_Products set ");
            strSql.Append("KSP_SampleId='' ");
            strSql.Append(" where KSP_SampleId=@KSP_SampleId ");
            SqlParameter[] parameters = {
					new SqlParameter("@KSP_SampleId", SqlDbType.VarChar,50)};
            parameters[0].Value = s_KSP_SampleId;

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
        /// 更新一条数据
        /// </summary>
        public bool UpdateDel(KNet.Model.KNet_Sys_Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Sys_Products set ");
            strSql.Append("KSP_Del=@KSP_Del, ");
            strSql.Append("KSP_DelRemarks=@KSP_DelRemarks ");
            strSql.Append(" where ProductsBarCode=@ProductsBarCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@KSP_Del", SqlDbType.Int,4),
					new SqlParameter("@KSP_DelRemarks", SqlDbType.VarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.VarChar,50)};
            parameters[0].Value =model.KSP_Del ;
            parameters[1].Value = model.KSP_DelRemarks;
            parameters[2].Value = model.ProductsBarCode;

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
        /// 更新一条数据
        /// </summary>
        public bool UpdateisModiy(KNet.Model.KNet_Sys_Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Sys_Products set ");
            strSql.Append("KSP_isModiy=@KSP_isModiy ");
            strSql.Append(" where ProductsBarCode=@ProductsBarCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@KSP_isModiy", SqlDbType.Int,4),
					new SqlParameter("@ProductsBarCode", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KSP_isModiy;
            parameters[1].Value = model.ProductsBarCode;

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
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sys_Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Sys_Products(");
            strSql.Append("ProductsName,ProductsBarCode,ProductsPattern,ProductsMainCategory,ProductsSmallCategory,ProductsUnits,ProductsSellingPrice,ProductsCostPrice,ProductsStockAlert,ProductsPic,ProductsBigPicture,ProductsSmallPicture,ProductsDescription,ProductsDetailDescription,ProductsAddTime,ProductsAddMan,ProductsType,HandPrice,ProductsEdition,KSP_SampleId,KSP_Mould,KSP_Creator,KSP_CTime,KSP_MTime,KSP_Mender,KSP_Code,KSP_isModiy,KSP_GProductsBarCode,KSP_Weight,KSP_Volume,KSP_IsAdd,KSP_IsReplace,KSP_IsDelete,KSP_CustomerProductsName,KSP_CustomerProductsCode,KSP_CustomerProductsEdition,KSP_CgType,KSP_RDPerson,KSP_BZNumber,KSP_UseType,KSP_LossType)");
            strSql.Append(" values (");
            strSql.Append("@ProductsName,@ProductsBarCode,@ProductsPattern,@ProductsMainCategory,@ProductsSmallCategory,@ProductsUnits,@ProductsSellingPrice,@ProductsCostPrice,@ProductsStockAlert,@ProductsPic,@ProductsBigPicture,@ProductsSmallPicture,@ProductsDescription,@ProductsDetailDescription,@ProductsAddTime,@ProductsAddMan,@ProductsType,@HandPrice,@ProductsEdition,@KSP_SampleId,@KSP_Mould,@KSP_Creator,@KSP_CTime,@KSP_MTime,@KSP_Mender,@KSP_Code,@KSP_isModiy,@KSP_GProductsBarCode,@KSP_Weight,@KSP_Volume,@KSP_IsAdd,@KSP_IsReplace,@KSP_IsDelete,@KSP_CustomerProductsName,@KSP_CustomerProductsCode,@KSP_CustomerProductsEdition,@KSP_CgType,@KSP_RDPerson,@KSP_BZNumber,@KSP_UseType,@KSP_LossType)");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsPattern", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsMainCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsSmallCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsUnits", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsSellingPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ProductsCostPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ProductsStockAlert", SqlDbType.Int,4),
					new SqlParameter("@ProductsPic", SqlDbType.Bit,1),
					new SqlParameter("@ProductsBigPicture", SqlDbType.NVarChar,60),
					new SqlParameter("@ProductsSmallPicture", SqlDbType.NVarChar,60),
					new SqlParameter("@ProductsDescription", SqlDbType.NVarChar,1000),
					new SqlParameter("@ProductsDetailDescription", SqlDbType.NText),
					new SqlParameter("@ProductsAddTime", SqlDbType.DateTime),
					new SqlParameter("@ProductsAddMan", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsType", SqlDbType.VarChar,50),
					new SqlParameter("@HandPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ProductsEdition", SqlDbType.VarChar,200),
					new SqlParameter("@KSP_SampleId", SqlDbType.VarChar,50),
					new SqlParameter("@KSP_Mould", SqlDbType.VarChar,50),
					new SqlParameter("@KSP_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@KSP_CTime", SqlDbType.DateTime),
					new SqlParameter("@KSP_MTime", SqlDbType.DateTime),
					new SqlParameter("@KSP_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@KSP_Code", SqlDbType.VarChar,50),
					new SqlParameter("@KSP_isModiy", SqlDbType.Int,4),
					new SqlParameter("@KSP_GProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@KSP_Weight", SqlDbType.Decimal,9),
					new SqlParameter("@KSP_Volume", SqlDbType.Decimal,9),
					new SqlParameter("@KSP_IsAdd", SqlDbType.Int,4),
					new SqlParameter("@KSP_IsReplace", SqlDbType.Int,4),
					new SqlParameter("@KSP_IsDelete", SqlDbType.Int,4),
                                        
					new SqlParameter("@KSP_CustomerProductsName", SqlDbType.VarChar,50),
					new SqlParameter("@KSP_CustomerProductsCode", SqlDbType.VarChar,50),
					new SqlParameter("@KSP_CustomerProductsEdition", SqlDbType.VarChar,100),
					new SqlParameter("@KSP_CgType", SqlDbType.Int,4),
					new SqlParameter("@KSP_RDPerson", SqlDbType.VarChar,50),
					new SqlParameter("@KSP_BZNumber", SqlDbType.Int,4),
					new SqlParameter("@KSP_UseType", SqlDbType.VarChar,50),
                    
					new SqlParameter("@KSP_LossType", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.ProductsName;
            parameters[1].Value = model.ProductsBarCode;
            parameters[2].Value = model.ProductsPattern;
            parameters[3].Value = model.ProductsMainCategory;
            parameters[4].Value = model.ProductsSmallCategory;
            parameters[5].Value = model.ProductsUnits;
            parameters[6].Value = model.ProductsSellingPrice;
            parameters[7].Value = model.ProductsCostPrice;
            parameters[8].Value = model.ProductsStockAlert;
            parameters[9].Value = model.ProductsPic;
            parameters[10].Value = model.ProductsBigPicture;
            parameters[11].Value = model.ProductsSmallPicture;
            parameters[12].Value = model.ProductsDescription;
            parameters[13].Value = model.ProductsDetailDescription;
            parameters[14].Value = model.ProductsAddTime;
            parameters[15].Value = model.ProductsAddMan;
            parameters[16].Value = model.ProductsType;
            parameters[17].Value = model.HandPrice;
            parameters[18].Value = model.ProductsEdition;
            parameters[19].Value = model.KSP_SampleId;
            parameters[20].Value = model.KSP_Mould;
            parameters[21].Value = model.KSP_Creator;
            parameters[22].Value = model.KSP_CTime;
            parameters[23].Value = model.KSP_MTime;
            parameters[24].Value = model.KSP_Mender;
            parameters[25].Value = model.KSP_Code;
            parameters[26].Value = model.KSP_isModiy;
            parameters[27].Value = model.KSP_GProductsBarCode;
            parameters[28].Value = model.KSP_Weight;
            parameters[29].Value = model.KSP_Volume;
            parameters[30].Value = model.KSP_IsAdd;
            parameters[31].Value = model.KSP_IsReplace;
            parameters[32].Value = model.KSP_IsDelete;

            parameters[33].Value = model.KSP_CustomerProductsName;
            parameters[34].Value = model.KSP_CustomerProductsCode;
            parameters[35].Value = model.KSP_CustomerProductsEdition;
            parameters[36].Value = model.KSP_CgType;
            parameters[37].Value = model.KSP_RDPerson;
            parameters[38].Value = model.KSP_BZNumber;
            parameters[39].Value = model.KSP_UseType;
            parameters[40].Value = model.KSP_LossType;
            
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.KNet_Sys_Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Sys_Products set ");
            strSql.Append("ProductsName=@ProductsName,");
            strSql.Append("ProductsPattern=@ProductsPattern,");
            strSql.Append("ProductsMainCategory=@ProductsMainCategory,");
            strSql.Append("ProductsSmallCategory=@ProductsSmallCategory,");
            strSql.Append("ProductsUnits=@ProductsUnits,");
            strSql.Append("ProductsSellingPrice=@ProductsSellingPrice,");
            strSql.Append("ProductsCostPrice=@ProductsCostPrice,");
            strSql.Append("ProductsStockAlert=@ProductsStockAlert,");
            strSql.Append("ProductsPic=@ProductsPic,");
            strSql.Append("ProductsBigPicture=@ProductsBigPicture,");
            strSql.Append("ProductsSmallPicture=@ProductsSmallPicture,");
            strSql.Append("ProductsDescription=@ProductsDescription,");
            strSql.Append("ProductsDetailDescription=@ProductsDetailDescription,");
            strSql.Append("ProductsAddTime=@ProductsAddTime,");
            strSql.Append("ProductsAddMan=@ProductsAddMan,");
            strSql.Append("ProductsType=@ProductsType,");
            strSql.Append("HandPrice=@HandPrice,");
            strSql.Append("ProductsEdition=@ProductsEdition,");
            strSql.Append("KSP_SampleId=@KSP_SampleId,");
            strSql.Append("KSP_Mould=@KSP_Mould,");
            strSql.Append("KSP_MTime=@KSP_MTime,");
            strSql.Append("KSP_Mender=@KSP_Mender,");
            strSql.Append("KSP_Code=@KSP_Code,");

            strSql.Append("KSP_isModiy=@KSP_isModiy,");
            strSql.Append("KSP_GProductsBarCode=@KSP_GProductsBarCode,");
            strSql.Append("KSP_Weight=@KSP_Weight,");
            strSql.Append("KSP_IsAdd=@KSP_IsAdd,");
            strSql.Append("KSP_IsReplace=@KSP_IsReplace,");
            strSql.Append("KSP_IsDelete=@KSP_IsDelete,");
            strSql.Append("KSP_Volume=@KSP_Volume,");

            strSql.Append("KSP_CustomerProductsName=@KSP_CustomerProductsName,");
            strSql.Append("KSP_CustomerProductsCode=@KSP_CustomerProductsCode,");
            strSql.Append("KSP_CustomerProductsEdition=@KSP_CustomerProductsEdition,");
            strSql.Append("KSP_CgType=@KSP_CgType,");
            strSql.Append("KSP_RDPerson=@KSP_RDPerson,");
            strSql.Append("KSP_BZNumber=@KSP_BZNumber,");
            strSql.Append("KSP_UseType=@KSP_UseType,");
            strSql.Append("KSP_LossType=@KSP_LossType");
            
            
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsName", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsPattern", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsMainCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsSmallCategory", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsUnits", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsSellingPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ProductsCostPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ProductsStockAlert", SqlDbType.Int,4),
					new SqlParameter("@ProductsPic", SqlDbType.Bit,1),
					new SqlParameter("@ProductsBigPicture", SqlDbType.NVarChar,60),
					new SqlParameter("@ProductsSmallPicture", SqlDbType.NVarChar,60),
					new SqlParameter("@ProductsDescription", SqlDbType.NVarChar,1000),
					new SqlParameter("@ProductsDetailDescription", SqlDbType.NText),
					new SqlParameter("@ProductsAddTime", SqlDbType.DateTime),
					new SqlParameter("@ProductsAddMan", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductsType", SqlDbType.VarChar,50),
					new SqlParameter("@HandPrice", SqlDbType.Decimal,9),
					new SqlParameter("@ProductsEdition", SqlDbType.VarChar,200),
					new SqlParameter("@KSP_SampleId", SqlDbType.VarChar,50),
					new SqlParameter("@KSP_Mould", SqlDbType.VarChar,50),
					new SqlParameter("@KSP_MTime", SqlDbType.DateTime),
					new SqlParameter("@KSP_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@KSP_Code", SqlDbType.VarChar,50),
					new SqlParameter("@KSP_isModiy", SqlDbType.Int,4),
					new SqlParameter("@KSP_GProductsBarCode", SqlDbType.VarChar,50),

					new SqlParameter("@KSP_Weight", SqlDbType.Decimal,9),
					new SqlParameter("@KSP_IsAdd", SqlDbType.Int,4),
					new SqlParameter("@KSP_IsReplace", SqlDbType.Int,4),
					new SqlParameter("@KSP_IsDelete", SqlDbType.Int,4),
					new SqlParameter("@KSP_Volume", SqlDbType.Decimal,9),
                    
					new SqlParameter("@KSP_CustomerProductsName", SqlDbType.VarChar,50),
					new SqlParameter("@KSP_CustomerProductsCode", SqlDbType.VarChar,50),
					new SqlParameter("@KSP_CustomerProductsEdition", SqlDbType.VarChar,100),
					new SqlParameter("@KSP_CgType", SqlDbType.Int,4),
					new SqlParameter("@KSP_RDPerson", SqlDbType.VarChar,50),
					new SqlParameter("@KSP_BZNumber", SqlDbType.Int,4),
					new SqlParameter("@KSP_UseType", SqlDbType.NVarChar,50),
					new SqlParameter("@KSP_LossType", SqlDbType.Int,4),
                    
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ProductsName;
            parameters[1].Value = model.ProductsPattern;
            parameters[2].Value = model.ProductsMainCategory;
            parameters[3].Value = model.ProductsSmallCategory;
            parameters[4].Value = model.ProductsUnits;
            parameters[5].Value = model.ProductsSellingPrice;
            parameters[6].Value = model.ProductsCostPrice;
            parameters[7].Value = model.ProductsStockAlert;
            parameters[8].Value = model.ProductsPic;
            parameters[9].Value = model.ProductsBigPicture;
            parameters[10].Value = model.ProductsSmallPicture;
            parameters[11].Value = model.ProductsDescription;
            parameters[12].Value = model.ProductsDetailDescription;
            parameters[13].Value = model.ProductsAddTime;
            parameters[14].Value = model.ProductsAddMan;
            parameters[15].Value = model.ProductsType;
            parameters[16].Value = model.HandPrice;
            parameters[17].Value = model.ProductsEdition;
            parameters[18].Value = model.KSP_SampleId;
            parameters[19].Value = model.KSP_Mould;
            parameters[20].Value = model.KSP_MTime;
            parameters[21].Value = model.KSP_Mender;
            parameters[22].Value = model.KSP_Code;
            parameters[23].Value = model.KSP_isModiy;
            parameters[24].Value = model.KSP_GProductsBarCode;
            parameters[25].Value = model.KSP_Weight;

            parameters[26].Value = model.KSP_IsAdd;
            parameters[27].Value = model.KSP_IsReplace;
            parameters[28].Value = model.KSP_IsDelete;
            parameters[29].Value = model.KSP_Volume;

            parameters[30].Value = model.KSP_CustomerProductsName;
            parameters[31].Value = model.KSP_CustomerProductsCode;
            parameters[32].Value = model.KSP_CustomerProductsEdition;

            parameters[33].Value = model.KSP_CgType;
            parameters[34].Value = model.KSP_RDPerson;
            parameters[35].Value = model.KSP_BZNumber;
            parameters[36].Value = model.KSP_UseType;
            parameters[37].Value = model.KSP_LossType;
            
            parameters[38].Value = model.ID;

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
        /// 删除一条数据
        /// </summary>
        public void Delete(string ID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            DbHelperSQL.RunProcedure("Proc_KNet_Sys_Products_Delete", parameters, out rowsAffected);
        }
        /// <summary>
        /// 更新工时
        /// </summary>
        /// <param name="time"></param>
        public bool UpdateTime(KNet.Model.KNet_Sys_Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Sys_Products set ");
            strSql.Append("KSP_WorkTime=@KSP_WorkTime");
            strSql.Append(" where ProductsBarCode=@ProductsBarCode ");
            SqlParameter[] parameters = {
                    new SqlParameter("@KSP_WorkTime", SqlDbType.Decimal),
                    new SqlParameter("@ProductsBarCode", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KSP_WorkTime;
            parameters[1].Value = model.ProductsBarCode;

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
        public KNet.Model.KNet_Sys_Products GetModel(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from KNet_Sys_Products ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_Sys_Products model = new KNet.Model.KNet_Sys_Products();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
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
                if (ds.Tables[0].Rows[0]["ProductsSellingPrice"] != null && ds.Tables[0].Rows[0]["ProductsSellingPrice"].ToString() != "")
                {
                    model.ProductsSellingPrice = decimal.Parse(ds.Tables[0].Rows[0]["ProductsSellingPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsCostPrice"] != null && ds.Tables[0].Rows[0]["ProductsCostPrice"].ToString() != "")
                {
                    model.ProductsCostPrice = decimal.Parse(ds.Tables[0].Rows[0]["ProductsCostPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsStockAlert"] != null && ds.Tables[0].Rows[0]["ProductsStockAlert"].ToString() != "")
                {
                    model.ProductsStockAlert = int.Parse(ds.Tables[0].Rows[0]["ProductsStockAlert"].ToString());
                }


                if (ds.Tables[0].Rows[0]["KSP_BZNumber"] != null && ds.Tables[0].Rows[0]["KSP_BZNumber"].ToString() != "")
                {
                    model.KSP_BZNumber = int.Parse(ds.Tables[0].Rows[0]["KSP_BZNumber"].ToString());
                }
                
                if (ds.Tables[0].Rows[0]["ProductsPic"] != null && ds.Tables[0].Rows[0]["ProductsPic"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ProductsPic"].ToString() == "1") || (ds.Tables[0].Rows[0]["ProductsPic"].ToString().ToLower() == "true"))
                    {
                        model.ProductsPic = true;
                    }
                    else
                    {
                        model.ProductsPic = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["ProductsBigPicture"] != null && ds.Tables[0].Rows[0]["ProductsBigPicture"].ToString() != "")
                {
                    model.ProductsBigPicture = ds.Tables[0].Rows[0]["ProductsBigPicture"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsSmallPicture"] != null && ds.Tables[0].Rows[0]["ProductsSmallPicture"].ToString() != "")
                {
                    model.ProductsSmallPicture = ds.Tables[0].Rows[0]["ProductsSmallPicture"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsDescription"] != null && ds.Tables[0].Rows[0]["ProductsDescription"].ToString() != "")
                {
                    model.ProductsDescription = ds.Tables[0].Rows[0]["ProductsDescription"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsDetailDescription"] != null && ds.Tables[0].Rows[0]["ProductsDetailDescription"].ToString() != "")
                {
                    model.ProductsDetailDescription = ds.Tables[0].Rows[0]["ProductsDetailDescription"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsAddTime"] != null && ds.Tables[0].Rows[0]["ProductsAddTime"].ToString() != "")
                {
                    model.ProductsAddTime = DateTime.Parse(ds.Tables[0].Rows[0]["ProductsAddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsAddMan"] != null && ds.Tables[0].Rows[0]["ProductsAddMan"].ToString() != "")
                {
                    model.ProductsAddMan = ds.Tables[0].Rows[0]["ProductsAddMan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsType"] != null && ds.Tables[0].Rows[0]["ProductsType"].ToString() != "")
                {
                    model.ProductsType = ds.Tables[0].Rows[0]["ProductsType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HandPrice"] != null && ds.Tables[0].Rows[0]["HandPrice"].ToString() != "")
                {
                    model.HandPrice = decimal.Parse(ds.Tables[0].Rows[0]["HandPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsEdition"] != null && ds.Tables[0].Rows[0]["ProductsEdition"].ToString() != "")
                {
                    model.ProductsEdition = ds.Tables[0].Rows[0]["ProductsEdition"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSP_SampleId"] != null && ds.Tables[0].Rows[0]["KSP_SampleId"].ToString() != "")
                {
                    model.KSP_SampleId = ds.Tables[0].Rows[0]["KSP_SampleId"].ToString();
                }
                else
                {
                    model.KSP_SampleId = "";
                }
                if (ds.Tables[0].Rows[0]["KSP_Mould"] != null && ds.Tables[0].Rows[0]["KSP_Mould"].ToString() != "")
                {
                    model.KSP_Mould = ds.Tables[0].Rows[0]["KSP_Mould"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSP_Creator"] != null && ds.Tables[0].Rows[0]["KSP_Creator"].ToString() != "")
                {
                    model.KSP_Creator = ds.Tables[0].Rows[0]["KSP_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSP_CTime"] != null && ds.Tables[0].Rows[0]["KSP_CTime"].ToString() != "")
                {
                    model.KSP_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["KSP_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KSP_MTime"] != null && ds.Tables[0].Rows[0]["KSP_MTime"].ToString() != "")
                {
                    model.KSP_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["KSP_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KSP_Mender"] != null && ds.Tables[0].Rows[0]["KSP_Mender"].ToString() != "")
                {
                    model.KSP_Mender = ds.Tables[0].Rows[0]["KSP_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSP_Code"] != null && ds.Tables[0].Rows[0]["KSP_Code"].ToString() != "")
                {
                    model.KSP_Code = ds.Tables[0].Rows[0]["KSP_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSP_GProductsBarCode"] != null && ds.Tables[0].Rows[0]["KSP_GProductsBarCode"].ToString() != "")
                {
                    model.KSP_GProductsBarCode = ds.Tables[0].Rows[0]["KSP_GProductsBarCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSP_UseType"] != null && ds.Tables[0].Rows[0]["KSP_UseType"].ToString() != "")
                {
                    model.KSP_UseType = ds.Tables[0].Rows[0]["KSP_UseType"].ToString();
                }
                
                if (ds.Tables[0].Rows[0]["KSP_Weight"] != null && ds.Tables[0].Rows[0]["KSP_Weight"].ToString() != "")
                {
                    model.KSP_Weight = decimal.Parse(ds.Tables[0].Rows[0]["KSP_Weight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KSP_Volume"] != null && ds.Tables[0].Rows[0]["KSP_Volume"].ToString() != "")
                {
                    model.KSP_Volume = decimal.Parse(ds.Tables[0].Rows[0]["KSP_Volume"].ToString());
                }


                if (ds.Tables[0].Rows[0]["KSP_IsAdd"] != null && ds.Tables[0].Rows[0]["KSP_IsAdd"].ToString() != "")
                {
                    model.KSP_IsAdd = int.Parse(ds.Tables[0].Rows[0]["KSP_IsAdd"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KSP_IsReplace"] != null && ds.Tables[0].Rows[0]["KSP_IsReplace"].ToString() != "")
                {
                    model.KSP_IsReplace = int.Parse(ds.Tables[0].Rows[0]["KSP_IsReplace"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KSP_IsDelete"] != null && ds.Tables[0].Rows[0]["KSP_IsDelete"].ToString() != "")
                {
                    model.KSP_IsDelete = int.Parse(ds.Tables[0].Rows[0]["KSP_IsDelete"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KSP_LossType"] != null && ds.Tables[0].Rows[0]["KSP_LossType"].ToString() != "")
                {
                    model.KSP_LossType = int.Parse(ds.Tables[0].Rows[0]["KSP_LossType"].ToString());
                }
                
                if (ds.Tables[0].Rows[0]["KSP_CustomerProductsName"] != null)
                {
                    model.KSP_CustomerProductsName = ds.Tables[0].Rows[0]["KSP_CustomerProductsName"].ToString();
                }
                else
                {
                    model.KSP_CustomerProductsName = "";
                }

                if (ds.Tables[0].Rows[0]["KSP_CustomerProductsCode"] != null)
                {
                    model.KSP_CustomerProductsCode = ds.Tables[0].Rows[0]["KSP_CustomerProductsCode"].ToString();
                }
                else
                {
                    model.KSP_CustomerProductsCode = "";
                }

                if (ds.Tables[0].Rows[0]["KSP_CustomerProductsEdition"] != null)
                {
                    model.KSP_CustomerProductsEdition = ds.Tables[0].Rows[0]["KSP_CustomerProductsEdition"].ToString();
                }
                else
                {
                    model.KSP_CustomerProductsEdition = "";
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
        public KNet.Model.KNet_Sys_Products GetModelB(string ProductsBarCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from KNet_Sys_Products ");
            strSql.Append(" where ProductsBarCode=@ProductsBarCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductsBarCode", SqlDbType.NVarChar,50)};
            parameters[0].Value = ProductsBarCode;

            KNet.Model.KNet_Sys_Products model = new KNet.Model.KNet_Sys_Products();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.ProductsName = ds.Tables[0].Rows[0]["ProductsName"].ToString();
                model.ProductsBarCode = ds.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                model.ProductsPattern = ds.Tables[0].Rows[0]["ProductsPattern"].ToString();
                model.ProductsMainCategory = ds.Tables[0].Rows[0]["ProductsMainCategory"].ToString();
                model.ProductsSmallCategory = ds.Tables[0].Rows[0]["ProductsSmallCategory"].ToString();
                model.ProductsUnits = ds.Tables[0].Rows[0]["ProductsUnits"].ToString();
                if (ds.Tables[0].Rows[0]["ProductsSellingPrice"].ToString() != "")
                {
                    model.ProductsSellingPrice = decimal.Parse(ds.Tables[0].Rows[0]["ProductsSellingPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsCostPrice"].ToString() != "")
                {
                    model.ProductsCostPrice = decimal.Parse(ds.Tables[0].Rows[0]["ProductsCostPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsStockAlert"].ToString() != "")
                {
                    model.ProductsStockAlert = int.Parse(ds.Tables[0].Rows[0]["ProductsStockAlert"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsPic"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ProductsPic"].ToString() == "1") || (ds.Tables[0].Rows[0]["ProductsPic"].ToString().ToLower() == "true"))
                    {
                        model.ProductsPic = true;
                    }
                    else
                    {
                        model.ProductsPic = false;
                    }
                }
                try
                {
                    if (ds.Tables[0].Rows[0]["KSP_UseType"] != null && ds.Tables[0].Rows[0]["KSP_UseType"].ToString() != "")
                    {
                        model.KSP_UseType = ds.Tables[0].Rows[0]["KSP_UseType"].ToString();
                    }
                }
                catch
                { }
                
                model.ProductsBigPicture = ds.Tables[0].Rows[0]["ProductsBigPicture"].ToString();
                model.ProductsSmallPicture = ds.Tables[0].Rows[0]["ProductsSmallPicture"].ToString();
                model.ProductsDescription = ds.Tables[0].Rows[0]["ProductsDescription"].ToString();
                model.ProductsDetailDescription = ds.Tables[0].Rows[0]["ProductsDetailDescription"].ToString();
                if (ds.Tables[0].Rows[0]["ProductsAddTime"].ToString() != "")
                {
                    model.ProductsAddTime = DateTime.Parse(ds.Tables[0].Rows[0]["ProductsAddTime"].ToString());
                }
                model.ProductsAddMan = ds.Tables[0].Rows[0]["ProductsAddMan"].ToString();
                if (ds.Tables[0].Rows[0]["ProductsType"] != null && ds.Tables[0].Rows[0]["ProductsType"].ToString() != "")
                {
                    model.ProductsType = ds.Tables[0].Rows[0]["ProductsType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HandPrice"] != null && ds.Tables[0].Rows[0]["HandPrice"].ToString() != "")
                {
                    model.HandPrice = decimal.Parse(ds.Tables[0].Rows[0]["HandPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsEdition"] != null && ds.Tables[0].Rows[0]["ProductsEdition"].ToString() != "")
                {
                    model.ProductsEdition = ds.Tables[0].Rows[0]["ProductsEdition"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSP_SampleId"] != null && ds.Tables[0].Rows[0]["KSP_SampleId"].ToString() != "")
                {
                    model.KSP_SampleId = ds.Tables[0].Rows[0]["KSP_SampleId"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSP_Del"] != null && ds.Tables[0].Rows[0]["KSP_Del"].ToString() != "")
                {
                    model.KSP_Del = int.Parse(ds.Tables[0].Rows[0]["KSP_Del"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KSP_isModiy"] != null && ds.Tables[0].Rows[0]["KSP_isModiy"].ToString() != "")
                {
                    model.KSP_isModiy = int.Parse(ds.Tables[0].Rows[0]["KSP_isModiy"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KSP_Mould"] != null && ds.Tables[0].Rows[0]["KSP_Mould"].ToString() != "")
                {
                    model.KSP_Mould = ds.Tables[0].Rows[0]["KSP_Mould"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSP_Creator"] != null && ds.Tables[0].Rows[0]["KSP_Creator"].ToString() != "")
                {
                    model.KSP_Creator = ds.Tables[0].Rows[0]["KSP_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSP_CTime"] != null && ds.Tables[0].Rows[0]["KSP_CTime"].ToString() != "")
                {
                    model.KSP_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["KSP_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KSP_MTime"] != null && ds.Tables[0].Rows[0]["KSP_MTime"].ToString() != "")
                {
                    model.KSP_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["KSP_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KSP_Mender"] != null && ds.Tables[0].Rows[0]["KSP_Mender"].ToString() != "")
                {
                    model.KSP_Mender = ds.Tables[0].Rows[0]["KSP_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSP_Code"] != null && ds.Tables[0].Rows[0]["KSP_Code"].ToString() != "")
                {
                    model.KSP_Code = ds.Tables[0].Rows[0]["KSP_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSP_GProductsBarCode"] != null && ds.Tables[0].Rows[0]["KSP_GProductsBarCode"].ToString() != "")
                {
                    model.KSP_GProductsBarCode = ds.Tables[0].Rows[0]["KSP_GProductsBarCode"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KSP_Weight"] != null && ds.Tables[0].Rows[0]["KSP_Weight"].ToString() != "")
                {
                    model.KSP_Weight = decimal.Parse(ds.Tables[0].Rows[0]["KSP_Weight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KSP_Volume"] != null && ds.Tables[0].Rows[0]["KSP_Volume"].ToString() != "")
                {
                    model.KSP_Volume = decimal.Parse(ds.Tables[0].Rows[0]["KSP_Volume"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KSP_IsAdd"] != null && ds.Tables[0].Rows[0]["KSP_IsAdd"].ToString() != "")
                {
                    model.KSP_IsAdd = int.Parse(ds.Tables[0].Rows[0]["KSP_IsAdd"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KSP_IsReplace"] != null && ds.Tables[0].Rows[0]["KSP_IsReplace"].ToString() != "")
                {
                    model.KSP_IsReplace = int.Parse(ds.Tables[0].Rows[0]["KSP_IsReplace"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KSP_IsDelete"] != null && ds.Tables[0].Rows[0]["KSP_IsDelete"].ToString() != "")
                {
                    model.KSP_IsDelete = int.Parse(ds.Tables[0].Rows[0]["KSP_IsDelete"].ToString());
                }


                if (ds.Tables[0].Rows[0]["KSP_CgType"] != null && ds.Tables[0].Rows[0]["KSP_CgType"].ToString() != "")
                {
                    model.KSP_CgType = int.Parse(ds.Tables[0].Rows[0]["KSP_CgType"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KSP_DelRemarks"] != null && ds.Tables[0].Rows[0]["KSP_DelRemarks"].ToString() != "")
                {
                    model.KSP_DelRemarks = ds.Tables[0].Rows[0]["KSP_DelRemarks"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KSP_CustomerProductsName"] != null)
                {
                    model.KSP_CustomerProductsName = ds.Tables[0].Rows[0]["KSP_CustomerProductsName"].ToString();
                }
                else
                {
                    model.KSP_CustomerProductsName = "";
                }

                if (ds.Tables[0].Rows[0]["KSP_CustomerProductsCode"] != null)
                {
                    model.KSP_CustomerProductsCode = ds.Tables[0].Rows[0]["KSP_CustomerProductsCode"].ToString();
                }
                else
                {
                    model.KSP_CustomerProductsCode = "";
                }

                if (ds.Tables[0].Rows[0]["KSP_CustomerProductsEdition"] != null)
                {
                    model.KSP_CustomerProductsEdition = ds.Tables[0].Rows[0]["KSP_CustomerProductsEdition"].ToString();
                }
                else
                {
                    model.KSP_CustomerProductsEdition = "";
                }

                if (ds.Tables[0].Rows[0]["KSP_RDPerson"] != null && ds.Tables[0].Rows[0]["KSP_RDPerson"].ToString() != "")
                {
                    model.KSP_RDPerson = ds.Tables[0].Rows[0]["KSP_RDPerson"].ToString();
                }


                if (ds.Tables[0].Rows[0]["KSP_ShPerson"] != null && ds.Tables[0].Rows[0]["KSP_ShPerson"].ToString() != "")
                {
                    model.KSP_ShPerson = ds.Tables[0].Rows[0]["KSP_ShPerson"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KSP_BZNumber"] != null && ds.Tables[0].Rows[0]["KSP_BZNumber"].ToString() != "")
                {
                    model.KSP_BZNumber = int.Parse(ds.Tables[0].Rows[0]["KSP_BZNumber"].ToString());
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
        public KNet.Model.KNet_Sys_Products GetModelBySampleID(string KSC_SampleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from KNet_Sys_Products ");
            strSql.Append(" where KSP_SampleID=@KSP_SampleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KSP_SampleID", SqlDbType.NVarChar,50)};
            parameters[0].Value = KSC_SampleID;

            KNet.Model.KNet_Sys_Products model = new KNet.Model.KNet_Sys_Products();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
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
                if (ds.Tables[0].Rows[0]["ProductsSellingPrice"] != null && ds.Tables[0].Rows[0]["ProductsSellingPrice"].ToString() != "")
                {
                    model.ProductsSellingPrice = decimal.Parse(ds.Tables[0].Rows[0]["ProductsSellingPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsCostPrice"] != null && ds.Tables[0].Rows[0]["ProductsCostPrice"].ToString() != "")
                {
                    model.ProductsCostPrice = decimal.Parse(ds.Tables[0].Rows[0]["ProductsCostPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsStockAlert"] != null && ds.Tables[0].Rows[0]["ProductsStockAlert"].ToString() != "")
                {
                    model.ProductsStockAlert = int.Parse(ds.Tables[0].Rows[0]["ProductsStockAlert"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsPic"] != null && ds.Tables[0].Rows[0]["ProductsPic"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ProductsPic"].ToString() == "1") || (ds.Tables[0].Rows[0]["ProductsPic"].ToString().ToLower() == "true"))
                    {
                        model.ProductsPic = true;
                    }
                    else
                    {
                        model.ProductsPic = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["KSP_UseType"] != null && ds.Tables[0].Rows[0]["KSP_UseType"].ToString() != "")
                {
                    model.KSP_UseType = ds.Tables[0].Rows[0]["KSP_UseType"].ToString();
                }
                
                if (ds.Tables[0].Rows[0]["ProductsBigPicture"] != null && ds.Tables[0].Rows[0]["ProductsBigPicture"].ToString() != "")
                {
                    model.ProductsBigPicture = ds.Tables[0].Rows[0]["ProductsBigPicture"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsSmallPicture"] != null && ds.Tables[0].Rows[0]["ProductsSmallPicture"].ToString() != "")
                {
                    model.ProductsSmallPicture = ds.Tables[0].Rows[0]["ProductsSmallPicture"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsDescription"] != null && ds.Tables[0].Rows[0]["ProductsDescription"].ToString() != "")
                {
                    model.ProductsDescription = ds.Tables[0].Rows[0]["ProductsDescription"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsDetailDescription"] != null && ds.Tables[0].Rows[0]["ProductsDetailDescription"].ToString() != "")
                {
                    model.ProductsDetailDescription = ds.Tables[0].Rows[0]["ProductsDetailDescription"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsAddTime"] != null && ds.Tables[0].Rows[0]["ProductsAddTime"].ToString() != "")
                {
                    model.ProductsAddTime = DateTime.Parse(ds.Tables[0].Rows[0]["ProductsAddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsAddMan"] != null && ds.Tables[0].Rows[0]["ProductsAddMan"].ToString() != "")
                {
                    model.ProductsAddMan = ds.Tables[0].Rows[0]["ProductsAddMan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductsType"] != null && ds.Tables[0].Rows[0]["ProductsType"].ToString() != "")
                {
                    model.ProductsType = ds.Tables[0].Rows[0]["ProductsType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HandPrice"] != null && ds.Tables[0].Rows[0]["HandPrice"].ToString() != "")
                {
                    model.HandPrice = decimal.Parse(ds.Tables[0].Rows[0]["HandPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductsEdition"] != null && ds.Tables[0].Rows[0]["ProductsEdition"].ToString() != "")
                {
                    model.ProductsEdition = ds.Tables[0].Rows[0]["ProductsEdition"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSP_SampleId"] != null && ds.Tables[0].Rows[0]["KSP_SampleId"].ToString() != "")
                {
                    model.KSP_SampleId = ds.Tables[0].Rows[0]["KSP_SampleId"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSP_Mould"] != null && ds.Tables[0].Rows[0]["KSP_Mould"].ToString() != "")
                {
                    model.KSP_Mould = ds.Tables[0].Rows[0]["KSP_Mould"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSP_Creator"] != null && ds.Tables[0].Rows[0]["KSP_Creator"].ToString() != "")
                {
                    model.KSP_Creator = ds.Tables[0].Rows[0]["KSP_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSP_CTime"] != null && ds.Tables[0].Rows[0]["KSP_CTime"].ToString() != "")
                {
                    model.KSP_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["KSP_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KSP_MTime"] != null && ds.Tables[0].Rows[0]["KSP_MTime"].ToString() != "")
                {
                    model.KSP_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["KSP_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KSP_Mender"] != null && ds.Tables[0].Rows[0]["KSP_Mender"].ToString() != "")
                {
                    model.KSP_Mender = ds.Tables[0].Rows[0]["KSP_Mender"].ToString();
                }

                if (ds.Tables[0].Rows[0]["KSP_Weight"] != null && ds.Tables[0].Rows[0]["KSP_Weight"].ToString() != "")
                {
                    model.KSP_Weight = decimal.Parse(ds.Tables[0].Rows[0]["KSP_Weight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KSP_Volume"] != null && ds.Tables[0].Rows[0]["KSP_Volume"].ToString() != "")
                {
                    model.KSP_Volume = decimal.Parse(ds.Tables[0].Rows[0]["KSP_Volume"].ToString());
                }

                if (ds.Tables[0].Rows[0]["KSP_CustomerProductsName"] != null)
                {
                    model.KSP_CustomerProductsName = ds.Tables[0].Rows[0]["KSP_CustomerProductsName"].ToString();
                }
                else
                {
                    model.KSP_CustomerProductsName = "";
                }

                if (ds.Tables[0].Rows[0]["KSP_CustomerProductsCode"] != null)
                {
                    model.KSP_CustomerProductsCode = ds.Tables[0].Rows[0]["KSP_CustomerProductsCode"].ToString();
                }
                else
                {
                    model.KSP_CustomerProductsCode = "";
                }

                if (ds.Tables[0].Rows[0]["KSP_CustomerProductsEdition"] != null)
                {
                    model.KSP_CustomerProductsEdition = ds.Tables[0].Rows[0]["KSP_CustomerProductsEdition"].ToString();
                }
                else
                {
                    model.KSP_CustomerProductsEdition = "";
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
            strSql.Append(" FROM KNet_Sys_Products ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by KSP_MTime desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByOrder(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM KNet_Sys_Products ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByCustomer(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select c.ID,a.*,c.Contract_SalesUnitPrice as Price,d.OutWareAmount,b.v_LeftOutWareTotalNumber as LeftNumber,c.ContractNo,b.ContractAmount ");
            strSql.Append(" FROM KNet_Sys_Products a left join v_Contract_OutWare_DirectOut_Total b on a.ProductsBarCode=b.v_ProductsBarCode left join KNet_Sales_ContractList_Details c on c.ContractNO=b.v_ContractNo  left join KNET_Sales_OutWareList_Details d on d.KSO_ContractDetailsID=c.ID left join KNET_Sales_OutWareList f on f.OutwareNo=d.OutWareNo");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by a.ProductsType,a.KSP_MTime desc ");


            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}


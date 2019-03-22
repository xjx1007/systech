using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Cg_Order_Checklist_Details
    /// </summary>
    public partial class Cg_Order_Checklist_Details
    {
        public Cg_Order_Checklist_Details()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string COD_Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cg_Order_Checklist_Details");
            strSql.Append(" where COD_Code=@COD_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@COD_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = COD_Code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cg_Order_Checklist_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cg_Order_Checklist_Details(");
            strSql.Append("COD_Code,COD_DirectOutID,COD_CustomerValue,COD_GetPerson,COD_Wuliu,COD_ProductsBarCode,COD_ProductsEdition,COD_CkNumber,COD_DZNumber,COD_Price,COD_HandPrice,COD_Money,COD_Details,COD_IC,COD_ICNumber,COD_CheckNo,COD_BNumber,COD_NoTaxMoney,COD_NoTaxLag,COD_RealMoney,COD_BFNumber,COD_BFPrice,COD_RKNumber,COD_EWMoney,COD_EWFMoney)");
            strSql.Append(" values (");
            strSql.Append("@COD_Code,@COD_DirectOutID,@COD_CustomerValue,@COD_GetPerson,@COD_Wuliu,@COD_ProductsBarCode,@COD_ProductsEdition,@COD_CkNumber,@COD_DZNumber,@COD_Price,@COD_HandPrice,@COD_Money,@COD_Details,@COD_IC,@COD_ICNumber,@COD_CheckNo,@COD_BNumber,@COD_NoTaxMoney,@COD_NoTaxLag,@COD_RealMoney,@COD_BFNumber,@COD_BFPrice,@COD_RKNumber,@COD_EWMoney,@COD_EWFMoney)");
            SqlParameter[] parameters = {
					new SqlParameter("@COD_Code", SqlDbType.VarChar,50),
					new SqlParameter("@COD_DirectOutID", SqlDbType.VarChar,50),
					new SqlParameter("@COD_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@COD_GetPerson", SqlDbType.VarChar,50),
					new SqlParameter("@COD_Wuliu", SqlDbType.VarChar,50),
					new SqlParameter("@COD_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@COD_ProductsEdition", SqlDbType.VarChar,100),
					new SqlParameter("@COD_CkNumber", SqlDbType.Decimal,9),
					new SqlParameter("@COD_DZNumber", SqlDbType.Decimal,9),
					new SqlParameter("@COD_Price", SqlDbType.Decimal,9),
					new SqlParameter("@COD_HandPrice", SqlDbType.Decimal,9),
					new SqlParameter("@COD_Money", SqlDbType.Decimal,9),
					new SqlParameter("@COD_Details", SqlDbType.VarChar,50),
					new SqlParameter("@COD_IC", SqlDbType.VarChar,50),
					new SqlParameter("@COD_ICNumber", SqlDbType.Decimal,9),
					new SqlParameter("@COD_CheckNo", SqlDbType.VarChar,50),
					new SqlParameter("@COD_BNumber", SqlDbType.Decimal,9),
					new SqlParameter("@COD_NoTaxMoney", SqlDbType.Decimal,9),
					new SqlParameter("@COD_NoTaxLag", SqlDbType.Decimal,9),
					new SqlParameter("@COD_RealMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@COD_BFNumber", SqlDbType.Int),
                    new SqlParameter("@COD_BFPrice", SqlDbType.Decimal,9),
                     new SqlParameter("@COD_RKNumber", SqlDbType.Int),
                      new SqlParameter("@COD_EWMoney", SqlDbType.Decimal,9),
                      new SqlParameter("@COD_EWFMoney", SqlDbType.Decimal,9)

            };
            parameters[0].Value = model.COD_Code;
            parameters[1].Value = model.COD_DirectOutID;
            parameters[2].Value = model.COD_CustomerValue;
            parameters[3].Value = model.COD_GetPerson;
            parameters[4].Value = model.COD_Wuliu;
            parameters[5].Value = model.COD_ProductsBarCode;
            parameters[6].Value = model.COD_ProductsEdition;
            parameters[7].Value = model.COD_CkNumber;
            parameters[8].Value = model.COD_DZNumber;
            parameters[9].Value = model.COD_Price;
            parameters[10].Value = model.COD_HandPrice;
            parameters[11].Value = model.COD_Money;
            parameters[12].Value = model.COD_Details;
            parameters[13].Value = model.Cod_IC;
            parameters[14].Value = model.COD_ICNumber;
            parameters[15].Value = model.COD_CheckNo;
            parameters[16].Value = model.COD_BNumber;
            parameters[17].Value = model.COD_NoTaxMoney;
            parameters[18].Value = model.COD_NoTaxLag;
            parameters[19].Value = model.COD_RealMoney;
            parameters[20].Value = model.COD_BFNumber;
            parameters[21].Value = model.COD_BFPrice;
            parameters[22].Value = model.COD_RKNumber;
            parameters[23].Value = model.COD_EWMoney;
            parameters[24].Value = model.COD_EWFMoney;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cg_Order_Checklist_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cg_Order_Checklist_Details set ");
            strSql.Append("COD_DirectOutID=@COD_DirectOutID,");
            strSql.Append("COD_CustomerValue=@COD_CustomerValue,");
            strSql.Append("COD_GetPerson=@COD_GetPerson,");
            strSql.Append("COD_Wuliu=@COD_Wuliu,");
            strSql.Append("COD_ProductsBarCode=@COD_ProductsBarCode,");
            strSql.Append("COD_ProductsEdition=@COD_ProductsEdition,");
            strSql.Append("COD_CkNumber=@COD_CkNumber,");
            strSql.Append("COD_DZNumber=@COD_DZNumber,");
            strSql.Append("COD_Price=@COD_Price,");
            strSql.Append("COD_HandPrice=@COD_HandPrice,");
            strSql.Append("COD_Money=@COD_Money,");
            strSql.Append("COD_Details=@COD_Details");
            strSql.Append(" where COD_Code=@COD_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@COD_DirectOutID", SqlDbType.VarChar,50),
					new SqlParameter("@COD_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@COD_GetPerson", SqlDbType.VarChar,50),
					new SqlParameter("@COD_Wuliu", SqlDbType.VarChar,50),
					new SqlParameter("@COD_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@COD_ProductsEdition", SqlDbType.VarChar,50),
					new SqlParameter("@COD_CkNumber", SqlDbType.Decimal,9),
					new SqlParameter("@COD_DZNumber", SqlDbType.Decimal,9),
					new SqlParameter("@COD_Price", SqlDbType.Decimal,9),
					new SqlParameter("@COD_HandPrice", SqlDbType.Decimal,9),
					new SqlParameter("@COD_Money", SqlDbType.Decimal,9),
					new SqlParameter("@COD_Details", SqlDbType.VarChar,50),
					new SqlParameter("@COD_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = model.COD_DirectOutID;
            parameters[1].Value = model.COD_CustomerValue;
            parameters[2].Value = model.COD_GetPerson;
            parameters[3].Value = model.COD_Wuliu;
            parameters[4].Value = model.COD_ProductsBarCode;
            parameters[5].Value = model.COD_ProductsEdition;
            parameters[6].Value = model.COD_CkNumber;
            parameters[7].Value = model.COD_DZNumber;
            parameters[8].Value = model.COD_Price;
            parameters[9].Value = model.COD_HandPrice;
            parameters[10].Value = model.COD_Money;
            parameters[11].Value = model.COD_Details;
            parameters[12].Value = model.COD_Code;

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
        public bool UpdateTaxMoney(KNet.Model.Cg_Order_Checklist_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cg_Order_Checklist_Details set ");
            strSql.Append("COD_NoTaxMoney=@COD_NoTaxMoney,");
            strSql.Append("COD_NoTaxLag=@COD_NoTaxLag");
            strSql.Append(" where COD_Code=@COD_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@COD_NoTaxMoney", SqlDbType.Decimal,9),
					new SqlParameter("@COD_NoTaxLag", SqlDbType.Int,4),
					new SqlParameter("@COD_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = model.COD_NoTaxMoney;
            parameters[1].Value = model.COD_NoTaxLag;
            parameters[2].Value = model.COD_Code;

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
        public bool UpdateWwPrice(KNet.Model.Cg_Order_Checklist_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cg_Order_Checklist_Details set ");
            strSql.Append("COD_WwPrice=@COD_WwPrice,");
            strSql.Append("COD_WwMoney=@COD_WwMoney");
            strSql.Append(" where COD_Code=@COD_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@COD_WwPrice", SqlDbType.Decimal,9),
					new SqlParameter("@COD_WwMoney", SqlDbType.Decimal,9),
					new SqlParameter("@COD_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = model.COD_WwPrice;
            parameters[1].Value = model.COD_WwMoney;
            parameters[2].Value = model.COD_Code;
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
        public bool Delete(string COD_Code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cg_Order_Checklist_Details ");
            strSql.Append(" where COD_Code=@COD_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@COD_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = COD_Code;

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
        public bool DeleteByCheckNo(string COD_CheckNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cg_Order_Checklist_Details ");
            strSql.Append(" where COD_CheckNo=@COD_CheckNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@COD_CheckNo", SqlDbType.VarChar,50)};
            parameters[0].Value = COD_CheckNo;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string COD_Codelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cg_Order_Checklist_Details ");
            strSql.Append(" where COD_Code in (" + COD_Codelist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public KNet.Model.Cg_Order_Checklist_Details GetModel(string COD_Code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Cg_Order_Checklist_Details ");
            strSql.Append(" where COD_Code=@COD_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@COD_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = COD_Code;

            KNet.Model.Cg_Order_Checklist_Details model = new KNet.Model.Cg_Order_Checklist_Details();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["COD_Code"] != null && ds.Tables[0].Rows[0]["COD_Code"].ToString() != "")
                {
                    model.COD_Code = ds.Tables[0].Rows[0]["COD_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["COD_CheckNo"] != null && ds.Tables[0].Rows[0]["COD_CheckNo"].ToString() != "")
                {
                    model.COD_CheckNo = ds.Tables[0].Rows[0]["COD_CheckNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["COD_DirectOutID"] != null && ds.Tables[0].Rows[0]["COD_DirectOutID"].ToString() != "")
                {
                    model.COD_DirectOutID = ds.Tables[0].Rows[0]["COD_DirectOutID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["COD_CustomerValue"] != null && ds.Tables[0].Rows[0]["COD_CustomerValue"].ToString() != "")
                {
                    model.COD_CustomerValue = ds.Tables[0].Rows[0]["COD_CustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["COD_GetPerson"] != null && ds.Tables[0].Rows[0]["COD_GetPerson"].ToString() != "")
                {
                    model.COD_GetPerson = ds.Tables[0].Rows[0]["COD_GetPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["COD_Wuliu"] != null && ds.Tables[0].Rows[0]["COD_Wuliu"].ToString() != "")
                {
                    model.COD_Wuliu = ds.Tables[0].Rows[0]["COD_Wuliu"].ToString();
                }
                if (ds.Tables[0].Rows[0]["COD_ProductsBarCode"] != null && ds.Tables[0].Rows[0]["COD_ProductsBarCode"].ToString() != "")
                {
                    model.COD_ProductsBarCode = ds.Tables[0].Rows[0]["COD_ProductsBarCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["COD_ProductsEdition"] != null && ds.Tables[0].Rows[0]["COD_ProductsEdition"].ToString() != "")
                {
                    model.COD_ProductsEdition = ds.Tables[0].Rows[0]["COD_ProductsEdition"].ToString();
                }
                if (ds.Tables[0].Rows[0]["COD_CkNumber"] != null && ds.Tables[0].Rows[0]["COD_CkNumber"].ToString() != "")
                {
                    model.COD_CkNumber = decimal.Parse(ds.Tables[0].Rows[0]["COD_CkNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["COD_DZNumber"] != null && ds.Tables[0].Rows[0]["COD_DZNumber"].ToString() != "")
                {
                    model.COD_DZNumber = decimal.Parse(ds.Tables[0].Rows[0]["COD_DZNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["COD_Price"] != null && ds.Tables[0].Rows[0]["COD_Price"].ToString() != "")
                {
                    model.COD_Price = decimal.Parse(ds.Tables[0].Rows[0]["COD_Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["COD_HandPrice"] != null && ds.Tables[0].Rows[0]["COD_HandPrice"].ToString() != "")
                {
                    model.COD_HandPrice = decimal.Parse(ds.Tables[0].Rows[0]["COD_HandPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["COD_Money"] != null && ds.Tables[0].Rows[0]["COD_Money"].ToString() != "")
                {
                    model.COD_Money = decimal.Parse(ds.Tables[0].Rows[0]["COD_Money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["COD_Details"] != null && ds.Tables[0].Rows[0]["COD_Details"].ToString() != "")
                {
                    model.COD_Details = ds.Tables[0].Rows[0]["COD_Details"].ToString();
                }
                if (ds.Tables[0].Rows[0]["COD_NoTaxMoney"] != null && ds.Tables[0].Rows[0]["COD_NoTaxMoney"].ToString() != "")
                {
                    model.COD_NoTaxMoney = decimal.Parse(ds.Tables[0].Rows[0]["COD_NoTaxMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["COD_NoTaxLag"] != null && ds.Tables[0].Rows[0]["COD_NoTaxLag"].ToString() != "")
                {
                    model.COD_NoTaxLag = int.Parse(ds.Tables[0].Rows[0]["COD_NoTaxLag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["COD_BFNumber"] != null && ds.Tables[0].Rows[0]["COD_BFNumber"].ToString() != "")
                {
                    model.COD_BFNumber = int.Parse(ds.Tables[0].Rows[0]["COD_BFNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["COD_BFPrice"] != null && ds.Tables[0].Rows[0]["COD_BFPrice"].ToString() != "")
                {
                    model.COD_BFPrice = int.Parse(ds.Tables[0].Rows[0]["COD_BFPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["COD_RKNumber"] != null && ds.Tables[0].Rows[0]["COD_RKNumber"].ToString() != "")
                {
                    model.COD_RKNumber = int.Parse(ds.Tables[0].Rows[0]["COD_RKNumber"].ToString());
                }
                if (ds.Tables[0].Rows[0]["COD_EWMoney"] != null && ds.Tables[0].Rows[0]["COD_EWMoney"].ToString() != "")
                {
                    model.COD_EWMoney = int.Parse(ds.Tables[0].Rows[0]["COD_EWMoney"].ToString());
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
        public string GetTotalNet(string COD_Code)
        {
            string s_return = "0";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  isNull(Sum(COD_Money),0) as TotalNet from Cg_Order_Checklist_Details ");
            strSql.Append(" where COD_CheckNo=@COD_CheckNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@COD_CheckNo", SqlDbType.VarChar,50)};
            parameters[0].Value = COD_Code;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["TotalNet"] != null && ds.Tables[0].Rows[0]["TotalNet"].ToString() != "")
                {
                    s_return = ds.Tables[0].Rows[0]["TotalNet"].ToString();
                }
            }
            else
            {
            }
            return s_return;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Cg_Order_Checklist_Details  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetList1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Cg_Order_Checklist_Details a join Cg_Order_Checklist b on a.COD_Code=b.COC_Code  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListJoinCGFP(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *,case when Isnull(CABD_ID,'')=''  then 0 else 1 end as State ");
            strSql.Append(" FROM Cg_Order_Checklist_Details  a left join CG_Account_Bill_Details b on a.COD_Code=b.CABD_CheckDetailsID ");
            strSql.Append(" left join Knet_Procure_WareHouseList_Details c on a.COD_DirectOutID=c.ID ");
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
            strSql.Append(" COD_Code,COD_DirectOutID,COD_CustomerValue,COD_GetPerson,COD_Wuliu,COD_ProductsBarCode,COD_ProductsEdition,COD_CkNumber,COD_DZNumber,COD_Price,COD_HandPrice,COD_Money,COD_Details ");
            strSql.Append(" FROM Cg_Order_Checklist_Details ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Cg_Order_Checklist_Details";
            parameters[1].Value = "COD_Code";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}


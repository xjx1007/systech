using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sales_BaoPriceList。
    /// </summary>
    public class KNet_Sales_BaoPriceList
    {
        public KNet_Sales_BaoPriceList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string BaoPriceNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@BaoPriceNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = BaoPriceNo;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sales_BaoPriceList_Exists", parameters, out rowsAffected);
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
        public bool Add(KNet.Model.KNet_Sales_BaoPriceList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Sales_BaoPriceList(");
            strSql.Append("BaoPriceNo,BaoPriceTopic,CustomerValue,BaoPricePaymentNotes,BaoPriceDateTime,BaoEndtoDateTime,BaoPriceTransShare,BaoPriceWarranty,BaoPriceToAddress,BaoPriceDeliveMethods,BaoPriceStaffBranch,BaoPriceStaffDepart,BaoPriceStaffNo,BaoPriceCheckStaffNo,BaoPriceRemarks,Clause,PriceTerms)");
            strSql.Append(" values (");
            strSql.Append("@BaoPriceNo,@BaoPriceTopic,@CustomerValue,@BaoPricePaymentNotes,@BaoPriceDateTime,@BaoEndtoDateTime,@BaoPriceTransShare,@BaoPriceWarranty,@BaoPriceToAddress,@BaoPriceDeliveMethods,@BaoPriceStaffBranch,@BaoPriceStaffDepart,@BaoPriceStaffNo,@BaoPriceCheckStaffNo,@BaoPriceRemarks,@Clause,@PriceTerms)");
            SqlParameter[] parameters = {
					new SqlParameter("@BaoPriceNo", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPriceTopic", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerValue", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPricePaymentNotes", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPriceDateTime", SqlDbType.DateTime),
					new SqlParameter("@BaoEndtoDateTime", SqlDbType.DateTime),
					new SqlParameter("@BaoPriceTransShare", SqlDbType.Decimal,9),
					new SqlParameter("@BaoPriceWarranty", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPriceToAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPriceDeliveMethods", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPriceStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPriceStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPriceStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPriceCheckStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPriceRemarks", SqlDbType.NVarChar,1000),
					new SqlParameter("@Clause", SqlDbType.VarChar,300),
					new SqlParameter("@PriceTerms", SqlDbType.VarChar,300)};
            parameters[0].Value = model.BaoPriceNo;
            parameters[1].Value = model.BaoPriceTopic;
            parameters[2].Value = model.CustomerValue;
            parameters[3].Value = model.BaoPricePaymentNotes;
            parameters[4].Value = model.BaoPriceDateTime;
            parameters[5].Value = model.BaoEndtoDateTime;
            parameters[6].Value = model.BaoPriceTransShare;
            parameters[7].Value = model.BaoPriceWarranty;
            parameters[8].Value = model.BaoPriceToAddress;
            parameters[9].Value = model.BaoPriceDeliveMethods;
            parameters[10].Value = model.BaoPriceStaffBranch;
            parameters[11].Value = model.BaoPriceStaffDepart;
            parameters[12].Value = model.BaoPriceStaffNo;
            parameters[13].Value = model.BaoPriceCheckStaffNo;
            parameters[14].Value = model.BaoPriceRemarks;
            parameters[15].Value = model.Clause;
            parameters[16].Value = model.PriceTerms;

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
        ///  更新一条数据
        /// </summary>
        public bool Update(KNet.Model.KNet_Sales_BaoPriceList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Sales_BaoPriceList set ");
            strSql.Append("CustomerValue=@CustomerValue,");
            strSql.Append("BaoPricePaymentNotes=@BaoPricePaymentNotes,");
            strSql.Append("BaoPriceDateTime=@BaoPriceDateTime,");
            strSql.Append("BaoEndtoDateTime=@BaoEndtoDateTime,");
            strSql.Append("BaoPriceTransShare=@BaoPriceTransShare,");
            strSql.Append("BaoPriceWarranty=@BaoPriceWarranty,");
            strSql.Append("BaoPriceToAddress=@BaoPriceToAddress,");
            strSql.Append("BaoPriceDeliveMethods=@BaoPriceDeliveMethods,");
            strSql.Append("BaoPriceStaffBranch=@BaoPriceStaffBranch,");
            strSql.Append("BaoPriceStaffDepart=@BaoPriceStaffDepart,");
            strSql.Append("BaoPriceStaffNo=@BaoPriceStaffNo,");
            strSql.Append("BaoPriceCheckStaffNo=@BaoPriceCheckStaffNo,");
            strSql.Append("BaoPriceRemarks=@BaoPriceRemarks,");
            strSql.Append("Clause=@Clause,");
            strSql.Append("PriceTerms=@PriceTerms");
            strSql.Append(" where BaoPriceNo=@BaoPriceNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@CustomerValue", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPricePaymentNotes", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPriceDateTime", SqlDbType.DateTime),
					new SqlParameter("@BaoEndtoDateTime", SqlDbType.DateTime),
					new SqlParameter("@BaoPriceTransShare", SqlDbType.Decimal,9),
					new SqlParameter("@BaoPriceWarranty", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPriceToAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPriceDeliveMethods", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPriceStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPriceStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPriceStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPriceCheckStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPriceRemarks", SqlDbType.NVarChar,1000),
					new SqlParameter("@Clause", SqlDbType.VarChar,300),
					new SqlParameter("@PriceTerms", SqlDbType.VarChar,300),
					new SqlParameter("@BaoPriceNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.CustomerValue;
            parameters[1].Value = model.BaoPricePaymentNotes;
            parameters[2].Value = model.BaoPriceDateTime;
            parameters[3].Value = model.BaoEndtoDateTime;
            parameters[4].Value = model.BaoPriceTransShare;
            parameters[5].Value = model.BaoPriceWarranty;
            parameters[6].Value = model.BaoPriceToAddress;
            parameters[7].Value = model.BaoPriceDeliveMethods;
            parameters[8].Value = model.BaoPriceStaffBranch;
            parameters[9].Value = model.BaoPriceStaffDepart;
            parameters[10].Value = model.BaoPriceStaffNo;
            parameters[11].Value = model.BaoPriceCheckStaffNo;
            parameters[12].Value = model.BaoPriceRemarks;
            parameters[13].Value = model.Clause;
            parameters[14].Value = model.PriceTerms;
            parameters[15].Value = model.BaoPriceNo;

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
        public void Delete(string BaoPriceNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@BaoPriceNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = BaoPriceNo;

            DbHelperSQL.RunProcedure("Proc_KNet_Sales_BaoPriceList_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_BaoPriceList GetModel(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_Sales_BaoPriceList model = new KNet.Model.KNet_Sales_BaoPriceList();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_Sales_BaoPriceList_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.BaoPriceNo = ds.Tables[0].Rows[0]["BaoPriceNo"].ToString();
                model.BaoPriceTopic = ds.Tables[0].Rows[0]["BaoPriceTopic"].ToString();
                model.CustomerValue = ds.Tables[0].Rows[0]["CustomerValue"].ToString();
                model.BaoPricePaymentNotes = ds.Tables[0].Rows[0]["BaoPricePaymentNotes"].ToString();
                if (ds.Tables[0].Rows[0]["BaoPriceDateTime"].ToString() != "")
                {
                    model.BaoPriceDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["BaoPriceDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BaoEndtoDateTime"].ToString() != "")
                {
                    model.BaoEndtoDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["BaoEndtoDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BaoPriceTransShare"].ToString() != "")
                {
                    model.BaoPriceTransShare = decimal.Parse(ds.Tables[0].Rows[0]["BaoPriceTransShare"].ToString());
                }
                model.BaoPriceWarranty = ds.Tables[0].Rows[0]["BaoPriceWarranty"].ToString();
                model.BaoPriceToAddress = ds.Tables[0].Rows[0]["BaoPriceToAddress"].ToString();
                model.BaoPriceDeliveMethods = ds.Tables[0].Rows[0]["BaoPriceDeliveMethods"].ToString();
                model.BaoPriceStaffBranch = ds.Tables[0].Rows[0]["BaoPriceStaffBranch"].ToString();
                model.BaoPriceStaffDepart = ds.Tables[0].Rows[0]["BaoPriceStaffDepart"].ToString();
                model.BaoPriceStaffNo = ds.Tables[0].Rows[0]["BaoPriceStaffNo"].ToString();
                model.BaoPriceCheckStaffNo = ds.Tables[0].Rows[0]["BaoPriceCheckStaffNo"].ToString();
                model.BaoPriceRemarks = ds.Tables[0].Rows[0]["BaoPriceRemarks"].ToString();
                if (ds.Tables[0].Rows[0]["BaoPriceCheckYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["BaoPriceCheckYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["BaoPriceCheckYN"].ToString().ToLower() == "true"))
                    {
                        model.BaoPriceCheckYN = true;
                    }
                    else
                    {
                        model.BaoPriceCheckYN = false;
                    }
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
        public KNet.Model.KNet_Sales_BaoPriceList GetModelB(string BaoPriceNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,BaoPriceNo,BaoPriceTopic,CustomerValue,BaoPricePaymentNotes,BaoPriceDateTime,BaoEndtoDateTime,BaoPriceTransShare,BaoPriceWarranty,BaoPriceToAddress,BaoPriceDeliveMethods,BaoPriceStaffBranch,BaoPriceStaffDepart,BaoPriceStaffNo,BaoPriceCheckStaffNo,BaoPriceRemarks,BaoPriceCheckYN,SystemDatetimes,Clause,PriceTerms from KNet_Sales_BaoPriceList ");
            strSql.Append(" where BaoPriceNo=@BaoPriceNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@BaoPriceNo", SqlDbType.NVarChar,50)			};
            parameters[0].Value = BaoPriceNo;

            KNet.Model.KNet_Sales_BaoPriceList model = new KNet.Model.KNet_Sales_BaoPriceList();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BaoPriceNo"] != null && ds.Tables[0].Rows[0]["BaoPriceNo"].ToString() != "")
                {
                    model.BaoPriceNo = ds.Tables[0].Rows[0]["BaoPriceNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BaoPriceTopic"] != null && ds.Tables[0].Rows[0]["BaoPriceTopic"].ToString() != "")
                {
                    model.BaoPriceTopic = ds.Tables[0].Rows[0]["BaoPriceTopic"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerValue"] != null && ds.Tables[0].Rows[0]["CustomerValue"].ToString() != "")
                {
                    model.CustomerValue = ds.Tables[0].Rows[0]["CustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BaoPricePaymentNotes"] != null && ds.Tables[0].Rows[0]["BaoPricePaymentNotes"].ToString() != "")
                {
                    model.BaoPricePaymentNotes = ds.Tables[0].Rows[0]["BaoPricePaymentNotes"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BaoPriceDateTime"] != null && ds.Tables[0].Rows[0]["BaoPriceDateTime"].ToString() != "")
                {
                    model.BaoPriceDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["BaoPriceDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BaoEndtoDateTime"] != null && ds.Tables[0].Rows[0]["BaoEndtoDateTime"].ToString() != "")
                {
                    model.BaoEndtoDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["BaoEndtoDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BaoPriceTransShare"] != null && ds.Tables[0].Rows[0]["BaoPriceTransShare"].ToString() != "")
                {
                    model.BaoPriceTransShare = decimal.Parse(ds.Tables[0].Rows[0]["BaoPriceTransShare"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BaoPriceWarranty"] != null && ds.Tables[0].Rows[0]["BaoPriceWarranty"].ToString() != "")
                {
                    model.BaoPriceWarranty = ds.Tables[0].Rows[0]["BaoPriceWarranty"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BaoPriceToAddress"] != null && ds.Tables[0].Rows[0]["BaoPriceToAddress"].ToString() != "")
                {
                    model.BaoPriceToAddress = ds.Tables[0].Rows[0]["BaoPriceToAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BaoPriceDeliveMethods"] != null && ds.Tables[0].Rows[0]["BaoPriceDeliveMethods"].ToString() != "")
                {
                    model.BaoPriceDeliveMethods = ds.Tables[0].Rows[0]["BaoPriceDeliveMethods"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BaoPriceStaffBranch"] != null && ds.Tables[0].Rows[0]["BaoPriceStaffBranch"].ToString() != "")
                {
                    model.BaoPriceStaffBranch = ds.Tables[0].Rows[0]["BaoPriceStaffBranch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BaoPriceStaffDepart"] != null && ds.Tables[0].Rows[0]["BaoPriceStaffDepart"].ToString() != "")
                {
                    model.BaoPriceStaffDepart = ds.Tables[0].Rows[0]["BaoPriceStaffDepart"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BaoPriceStaffNo"] != null && ds.Tables[0].Rows[0]["BaoPriceStaffNo"].ToString() != "")
                {
                    model.BaoPriceStaffNo = ds.Tables[0].Rows[0]["BaoPriceStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BaoPriceCheckStaffNo"] != null && ds.Tables[0].Rows[0]["BaoPriceCheckStaffNo"].ToString() != "")
                {
                    model.BaoPriceCheckStaffNo = ds.Tables[0].Rows[0]["BaoPriceCheckStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BaoPriceRemarks"] != null && ds.Tables[0].Rows[0]["BaoPriceRemarks"].ToString() != "")
                {
                    model.BaoPriceRemarks = ds.Tables[0].Rows[0]["BaoPriceRemarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BaoPriceCheckYN"] != null && ds.Tables[0].Rows[0]["BaoPriceCheckYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["BaoPriceCheckYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["BaoPriceCheckYN"].ToString().ToLower() == "true"))
                    {
                        model.BaoPriceCheckYN = true;
                    }
                    else
                    {
                        model.BaoPriceCheckYN = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Clause"] != null && ds.Tables[0].Rows[0]["Clause"].ToString() != "")
                {
                    model.Clause = ds.Tables[0].Rows[0]["Clause"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PriceTerms"] != null && ds.Tables[0].Rows[0]["PriceTerms"].ToString() != "")
                {
                    model.PriceTerms = ds.Tables[0].Rows[0]["PriceTerms"].ToString();
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
            strSql.Append("select ID,BaoPriceNo,BaoPriceTopic,CustomerValue,BaoPricePaymentNotes,BaoPriceDateTime,BaoEndtoDateTime,BaoPriceTransShare,BaoPriceWarranty,BaoPriceToAddress,BaoPriceDeliveMethods,BaoPriceStaffBranch,BaoPriceStaffDepart,BaoPriceStaffNo,BaoPriceCheckStaffNo,BaoPriceRemarks,BaoPriceCheckYN ");
            strSql.Append(" FROM KNet_Sales_BaoPriceList ");
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
            strSql.Append(" ID,BaoPriceNo,BaoPriceTopic,CustomerValue,BaoPricePaymentNotes,BaoPriceDateTime,BaoEndtoDateTime,BaoPriceTransShare,BaoPriceWarranty,BaoPriceToAddress,BaoPriceDeliveMethods,BaoPriceStaffBranch,BaoPriceStaffDepart,BaoPriceStaffNo,BaoPriceCheckStaffNo,BaoPriceRemarks,BaoPriceCheckYN ");
            strSql.Append(" FROM KNet_Sales_BaoPriceList ");
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


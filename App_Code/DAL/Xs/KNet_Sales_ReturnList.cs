using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sales_ReturnList。
    /// </summary>
    public class KNet_Sales_ReturnList
    {
        public KNet_Sales_ReturnList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ReturnNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ReturnNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = ReturnNo;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sales_ReturnList_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.KNet_Sales_ReturnList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Sales_ReturnList(");
            strSql.Append("ReturnNo,ReturnDateTime,ContractNo,CustomerValue,ReturnTranShare,OutWareNo,ReturnPorPay,ReturnClass,ReturnToAddress,ReturnDeliveMethods,ReturnStaffBranch,ReturnStaffDepart,ReturnStaffNo,ReturnCheckStaffNo,ReturnRemarks,ReturnState,ReturnCheckYN,ContentPerson,Telphone,ReturnType)");
            strSql.Append(" values (");
            strSql.Append("@ReturnNo,@ReturnDateTime,@ContractNo,@CustomerValue,@ReturnTranShare,@OutWareNo,@ReturnPorPay,@ReturnClass,@ReturnToAddress,@ReturnDeliveMethods,@ReturnStaffBranch,@ReturnStaffDepart,@ReturnStaffNo,@ReturnCheckStaffNo,@ReturnRemarks,@ReturnState,@ReturnCheckYN,@ContentPerson,@Telphone,@ReturnType)");
            SqlParameter[] parameters = {
					new SqlParameter("@ReturnNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnDateTime", SqlDbType.DateTime),
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerValue", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnTranShare", SqlDbType.Decimal,9),
					new SqlParameter("@OutWareNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnPorPay", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnClass", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnToAddress", SqlDbType.NVarChar,120),
					new SqlParameter("@ReturnDeliveMethods", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnCheckStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnRemarks", SqlDbType.NVarChar,1000),
					new SqlParameter("@ReturnState", SqlDbType.Int,4),
					new SqlParameter("@ReturnCheckYN", SqlDbType.Bit,1),
					new SqlParameter("@ContentPerson", SqlDbType.VarChar,50),
					new SqlParameter("@Telphone", SqlDbType.VarChar,50),
					new SqlParameter("@ReturnType", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ReturnNo;
            parameters[1].Value = model.ReturnDateTime;
            parameters[2].Value = model.ContractNo;
            parameters[3].Value = model.CustomerValue;
            parameters[4].Value = model.ReturnTranShare;
            parameters[5].Value = model.OutWareNo;
            parameters[6].Value = model.ReturnPorPay;
            parameters[7].Value = model.ReturnClass;
            parameters[8].Value = model.ReturnToAddress;
            parameters[9].Value = model.ReturnDeliveMethods;
            parameters[10].Value = model.ReturnStaffBranch;
            parameters[11].Value = model.ReturnStaffDepart;
            parameters[12].Value = model.ReturnStaffNo;
            parameters[13].Value = model.ReturnCheckStaffNo;
            parameters[14].Value = model.ReturnRemarks;
            parameters[15].Value = model.ReturnState;
            parameters[16].Value = model.ReturnCheckYN;
            parameters[17].Value = model.ContentPerson;
            parameters[18].Value = model.Telphone;
            parameters[19].Value = model.ReturnType;
            

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sales_ReturnList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Sales_ReturnList set ");
            strSql.Append("ReturnTopic=@ReturnTopic,");
            strSql.Append("ReturnDateTime=@ReturnDateTime,");
            strSql.Append("ContractNo=@ContractNo,");
            strSql.Append("CustomerValue=@CustomerValue,");
            strSql.Append("ReturnTranShare=@ReturnTranShare,");
            strSql.Append("OutWareNo=@OutWareNo,");
            strSql.Append("ReturnPorPay=@ReturnPorPay,");
            strSql.Append("ReturnClass=@ReturnClass,");
            strSql.Append("ReturnToAddress=@ReturnToAddress,");
            strSql.Append("ReturnDeliveMethods=@ReturnDeliveMethods,");
            strSql.Append("ReturnStaffBranch=@ReturnStaffBranch,");
            strSql.Append("ReturnStaffDepart=@ReturnStaffDepart,");
            strSql.Append("ReturnStaffNo=@ReturnStaffNo,");
            strSql.Append("ReturnCheckStaffNo=@ReturnCheckStaffNo,");
            strSql.Append("ReturnRemarks=@ReturnRemarks,");
            strSql.Append("ReturnState=@ReturnState,");
            strSql.Append("ReturnCheckYN=@ReturnCheckYN,");
            strSql.Append("ContentPerson=@ContentPerson,");
            strSql.Append("Telphone=@Telphone,");
            strSql.Append("ReturnType=@ReturnType");
            strSql.Append(" where ReturnNo=@ReturnNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@ReturnTopic", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnDateTime", SqlDbType.DateTime),
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerValue", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnTranShare", SqlDbType.Decimal,9),
					new SqlParameter("@OutWareNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnPorPay", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnClass", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnToAddress", SqlDbType.NVarChar,120),
					new SqlParameter("@ReturnDeliveMethods", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnCheckStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ReturnRemarks", SqlDbType.NVarChar,1000),
					new SqlParameter("@ReturnState", SqlDbType.Int,4),
					new SqlParameter("@ReturnCheckYN", SqlDbType.Bit,1),
					new SqlParameter("@ContentPerson", SqlDbType.VarChar,50),
					new SqlParameter("@Telphone", SqlDbType.VarChar,50),
					new SqlParameter("@ReturnType", SqlDbType.VarChar,50),
					new SqlParameter("@ReturnNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ReturnTopic;
            parameters[1].Value = model.ReturnDateTime;
            parameters[2].Value = model.ContractNo;
            parameters[3].Value = model.CustomerValue;
            parameters[4].Value = model.ReturnTranShare;
            parameters[5].Value = model.OutWareNo;
            parameters[6].Value = model.ReturnPorPay;
            parameters[7].Value = model.ReturnClass;
            parameters[8].Value = model.ReturnToAddress;
            parameters[9].Value = model.ReturnDeliveMethods;
            parameters[10].Value = model.ReturnStaffBranch;
            parameters[11].Value = model.ReturnStaffDepart;
            parameters[12].Value = model.ReturnStaffNo;
            parameters[13].Value = model.ReturnCheckStaffNo;
            parameters[14].Value = model.ReturnRemarks;
            parameters[15].Value = model.ReturnState;
            parameters[16].Value = model.ReturnCheckYN;
            parameters[17].Value = model.ContentPerson;
            parameters[18].Value = model.Telphone;
            parameters[19].Value = model.ReturnType;
            parameters[20].Value = model.ReturnNo;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
 
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ReturnNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ReturnNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = ReturnNo;

            DbHelperSQL.RunProcedure("Proc_KNet_Sales_ReturnList_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_ReturnList GetModel(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_Sales_ReturnList model = new KNet.Model.KNet_Sales_ReturnList();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_Sales_ReturnList_GetModelByID", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.ReturnNo = ds.Tables[0].Rows[0]["ReturnNo"].ToString();
                model.ReturnTopic = ds.Tables[0].Rows[0]["ReturnTopic"].ToString();
                if (ds.Tables[0].Rows[0]["ReturnDateTime"].ToString() != "")
                {
                    model.ReturnDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["ReturnDateTime"].ToString());
                }
                model.ContractNo = ds.Tables[0].Rows[0]["ContractNo"].ToString();
                model.CustomerValue = ds.Tables[0].Rows[0]["CustomerValue"].ToString();
                if (ds.Tables[0].Rows[0]["ReturnTranShare"].ToString() != "")
                {
                    model.ReturnTranShare = decimal.Parse(ds.Tables[0].Rows[0]["ReturnTranShare"].ToString());
                }
                model.OutWareNo = ds.Tables[0].Rows[0]["OutWareNo"].ToString();
                model.ReturnPorPay = ds.Tables[0].Rows[0]["ReturnPorPay"].ToString();
                model.ReturnClass = ds.Tables[0].Rows[0]["ReturnClass"].ToString();
                model.ReturnToAddress = ds.Tables[0].Rows[0]["ReturnToAddress"].ToString();
                model.ReturnDeliveMethods = ds.Tables[0].Rows[0]["ReturnDeliveMethods"].ToString();
                model.ReturnStaffBranch = ds.Tables[0].Rows[0]["ReturnStaffBranch"].ToString();
                model.ReturnStaffDepart = ds.Tables[0].Rows[0]["ReturnStaffDepart"].ToString();
                model.ReturnStaffNo = ds.Tables[0].Rows[0]["ReturnStaffNo"].ToString();
                model.ReturnCheckStaffNo = ds.Tables[0].Rows[0]["ReturnCheckStaffNo"].ToString();
                model.ReturnRemarks = ds.Tables[0].Rows[0]["ReturnRemarks"].ToString();
                if (ds.Tables[0].Rows[0]["ReturnState"].ToString() != "")
                {
                    model.ReturnState = int.Parse(ds.Tables[0].Rows[0]["ReturnState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReturnCheckYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ReturnCheckYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["ReturnCheckYN"].ToString().ToLower() == "true"))
                    {
                        model.ReturnCheckYN = true;
                    }
                    else
                    {
                        model.ReturnCheckYN = false;
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
        public KNet.Model.KNet_Sales_ReturnList GetModelB(string ReturnNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ReturnNo,ReturnTopic,ReturnDateTime,ContractNo,CustomerValue,ReturnTranShare,OutWareNo,ReturnPorPay,ReturnClass,ReturnToAddress,ReturnDeliveMethods,ReturnStaffBranch,ReturnStaffDepart,ReturnStaffNo,ReturnCheckStaffNo,ReturnRemarks,ReturnState,ReturnCheckYN,SystemDatetimes,ContentPerson,Telphone,ReturnType from KNet_Sales_ReturnList ");
            strSql.Append(" where ReturnNo=@ReturnNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@ReturnNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = ReturnNo;

            KNet.Model.KNet_Sales_ReturnList model = new KNet.Model.KNet_Sales_ReturnList();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReturnNo"] != null && ds.Tables[0].Rows[0]["ReturnNo"].ToString() != "")
                {
                    model.ReturnNo = ds.Tables[0].Rows[0]["ReturnNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReturnTopic"] != null && ds.Tables[0].Rows[0]["ReturnTopic"].ToString() != "")
                {
                    model.ReturnTopic = ds.Tables[0].Rows[0]["ReturnTopic"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReturnDateTime"] != null && ds.Tables[0].Rows[0]["ReturnDateTime"].ToString() != "")
                {
                    model.ReturnDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["ReturnDateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContractNo"] != null && ds.Tables[0].Rows[0]["ContractNo"].ToString() != "")
                {
                    model.ContractNo = ds.Tables[0].Rows[0]["ContractNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerValue"] != null && ds.Tables[0].Rows[0]["CustomerValue"].ToString() != "")
                {
                    model.CustomerValue = ds.Tables[0].Rows[0]["CustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReturnTranShare"] != null && ds.Tables[0].Rows[0]["ReturnTranShare"].ToString() != "")
                {
                    model.ReturnTranShare = decimal.Parse(ds.Tables[0].Rows[0]["ReturnTranShare"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OutWareNo"] != null && ds.Tables[0].Rows[0]["OutWareNo"].ToString() != "")
                {
                    model.OutWareNo = ds.Tables[0].Rows[0]["OutWareNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReturnPorPay"] != null && ds.Tables[0].Rows[0]["ReturnPorPay"].ToString() != "")
                {
                    model.ReturnPorPay = ds.Tables[0].Rows[0]["ReturnPorPay"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReturnClass"] != null && ds.Tables[0].Rows[0]["ReturnClass"].ToString() != "")
                {
                    model.ReturnClass = ds.Tables[0].Rows[0]["ReturnClass"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReturnToAddress"] != null && ds.Tables[0].Rows[0]["ReturnToAddress"].ToString() != "")
                {
                    model.ReturnToAddress = ds.Tables[0].Rows[0]["ReturnToAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReturnDeliveMethods"] != null && ds.Tables[0].Rows[0]["ReturnDeliveMethods"].ToString() != "")
                {
                    model.ReturnDeliveMethods = ds.Tables[0].Rows[0]["ReturnDeliveMethods"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReturnStaffBranch"] != null && ds.Tables[0].Rows[0]["ReturnStaffBranch"].ToString() != "")
                {
                    model.ReturnStaffBranch = ds.Tables[0].Rows[0]["ReturnStaffBranch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReturnStaffDepart"] != null && ds.Tables[0].Rows[0]["ReturnStaffDepart"].ToString() != "")
                {
                    model.ReturnStaffDepart = ds.Tables[0].Rows[0]["ReturnStaffDepart"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReturnStaffNo"] != null && ds.Tables[0].Rows[0]["ReturnStaffNo"].ToString() != "")
                {
                    model.ReturnStaffNo = ds.Tables[0].Rows[0]["ReturnStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReturnCheckStaffNo"] != null && ds.Tables[0].Rows[0]["ReturnCheckStaffNo"].ToString() != "")
                {
                    model.ReturnCheckStaffNo = ds.Tables[0].Rows[0]["ReturnCheckStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReturnRemarks"] != null && ds.Tables[0].Rows[0]["ReturnRemarks"].ToString() != "")
                {
                    model.ReturnRemarks = ds.Tables[0].Rows[0]["ReturnRemarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReturnState"] != null && ds.Tables[0].Rows[0]["ReturnState"].ToString() != "")
                {
                    model.ReturnState = int.Parse(ds.Tables[0].Rows[0]["ReturnState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReturnCheckYN"] != null && ds.Tables[0].Rows[0]["ReturnCheckYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ReturnCheckYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["ReturnCheckYN"].ToString().ToLower() == "true"))
                    {
                        model.ReturnCheckYN = true;
                    }
                    else
                    {
                        model.ReturnCheckYN = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["ContentPerson"] != null && ds.Tables[0].Rows[0]["ContentPerson"].ToString() != "")
                {
                    model.ContentPerson = ds.Tables[0].Rows[0]["ContentPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Telphone"] != null && ds.Tables[0].Rows[0]["Telphone"].ToString() != "")
                {
                    model.Telphone = ds.Tables[0].Rows[0]["Telphone"].ToString();
                }

                if (ds.Tables[0].Rows[0]["ReturnType"] != null && ds.Tables[0].Rows[0]["ReturnType"].ToString() != "")
                {
                    model.ReturnType = ds.Tables[0].Rows[0]["ReturnType"].ToString();
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
            strSql.Append(" FROM KNet_Sales_ReturnList ");
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
            strSql.Append(" ID,ReturnNo,ReturnTopic,ReturnDateTime,ContractNo,CustomerValue,ReturnTranShare,OutWareNo,ReturnPorPay,ReturnClass,ReturnToAddress,ReturnDeliveMethods,ReturnStaffBranch,ReturnStaffDepart,ReturnStaffNo,ReturnCheckStaffNo,ReturnRemarks,ReturnState,ReturnCheckYN ");
            strSql.Append(" FROM KNet_Sales_ReturnList ");
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


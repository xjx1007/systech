using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类A_Deliveryfa。
    /// </summary>
    public class A_Deliveryfa
    {
        public A_Deliveryfa()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string InvoiceOrderNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from A_Deliveryfa");
            strSql.Append(" where InvoiceOrderNumber=@InvoiceOrderNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@InvoiceOrderNumber", SqlDbType.NVarChar,50)};
            parameters[0].Value = InvoiceOrderNumber;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.A_Deliveryfa model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into A_Deliveryfa(");
            strSql.Append("ContractOrderNumber,InvoiceOrderNumber,CustomerName,CustomerValue,DeliveryDate,LoanAmount,ExpirationDate,SettlementStatus,ShippingWarehouse,Thedateofconstruction)");
            strSql.Append(" values (");
            strSql.Append("@ContractOrderNumber,@InvoiceOrderNumber,@CustomerName,@CustomerValue,@DeliveryDate,@LoanAmount,@ExpirationDate,@SettlementStatus,@ShippingWarehouse,@Thedateofconstruction)");
            SqlParameter[] parameters = {
					
					new SqlParameter("@ContractOrderNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@InvoiceOrderNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerName", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomerValue", SqlDbType.NVarChar,50),
					new SqlParameter("@DeliveryDate", SqlDbType.DateTime),
					new SqlParameter("@LoanAmount", SqlDbType.Decimal,9),
					new SqlParameter("@ExpirationDate", SqlDbType.DateTime),
					new SqlParameter("@SettlementStatus", SqlDbType.Int,4),
					new SqlParameter("@ShippingWarehouse", SqlDbType.NVarChar,50),
					new SqlParameter("@Thedateofconstruction", SqlDbType.DateTime)};

            
            parameters[0].Value = model.ContractOrderNumber;
            parameters[1].Value = model.InvoiceOrderNumber;
            parameters[2].Value = model.CustomerName;
            parameters[3].Value = model.CustomerValue;
            parameters[4].Value = model.DeliveryDate;
            parameters[5].Value = model.LoanAmount;
            parameters[6].Value = model.ExpirationDate;
            parameters[7].Value = model.SettlementStatus;
            parameters[8].Value = model.ShippingWarehouse;
            parameters[9].Value = model.Thedateofconstruction;
            

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.A_Deliveryfa GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ContractOrderNumber,InvoiceOrderNumber,CustomerName,CustomerValue,DeliveryDate,LoanAmount,ExpirationDate,SettlementStatus,ShippingWarehouse,Thedateofconstruction,SettlementDate from A_Deliveryfa ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.A_Deliveryfa model = new KNet.Model.A_Deliveryfa();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.ContractOrderNumber = ds.Tables[0].Rows[0]["ContractOrderNumber"].ToString();
                model.InvoiceOrderNumber = ds.Tables[0].Rows[0]["InvoiceOrderNumber"].ToString();
                model.CustomerName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                model.CustomerValue = ds.Tables[0].Rows[0]["CustomerValue"].ToString();
                if (ds.Tables[0].Rows[0]["DeliveryDate"].ToString() != "")
                {
                    model.DeliveryDate = DateTime.Parse(ds.Tables[0].Rows[0]["DeliveryDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LoanAmount"].ToString() != "")
                {
                    model.LoanAmount = decimal.Parse(ds.Tables[0].Rows[0]["LoanAmount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ExpirationDate"].ToString() != "")
                {
                    model.ExpirationDate = DateTime.Parse(ds.Tables[0].Rows[0]["ExpirationDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SettlementStatus"].ToString() != "")
                {
                    model.SettlementStatus = int.Parse(ds.Tables[0].Rows[0]["SettlementStatus"].ToString());
                }
                model.ShippingWarehouse = ds.Tables[0].Rows[0]["ShippingWarehouse"].ToString();
                if (ds.Tables[0].Rows[0]["Thedateofconstruction"].ToString() != "")
                {
                    model.Thedateofconstruction = DateTime.Parse(ds.Tables[0].Rows[0]["Thedateofconstruction"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SettlementDate"].ToString() != "")
                {
                    model.SettlementDate = DateTime.Parse(ds.Tables[0].Rows[0]["SettlementDate"].ToString());
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
            strSql.Append("select ID,ContractOrderNumber,InvoiceOrderNumber,CustomerName,CustomerValue,DeliveryDate,LoanAmount,ExpirationDate,SettlementStatus,ShippingWarehouse,Thedateofconstruction,SettlementDate ");
            strSql.Append(" FROM A_Deliveryfa ");
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
            strSql.Append(" ID,ContractOrderNumber,InvoiceOrderNumber,CustomerName,CustomerValue,DeliveryDate,LoanAmount,ExpirationDate,SettlementStatus,ShippingWarehouse,Thedateofconstruction,SettlementDate ");
            strSql.Append(" FROM A_Deliveryfa ");
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


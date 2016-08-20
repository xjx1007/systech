using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类A_AdvancesPriceDB。
    /// </summary>
    public class A_AdvancesPriceDB
    {
        public A_AdvancesPriceDB()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string OrderNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from A_AdvancesPriceDB");
            strSql.Append(" where OrderNo=@OrderNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = OrderNo;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.A_AdvancesPriceDB model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into A_AdvancesPriceDB(");
            strSql.Append("OrderNo,OrderTopic,SuppNo,PayAmounts,PayState,StaffBranch,StaffDepart,ReceivStaffNo,PayAddTime)");
            strSql.Append(" values (");
            strSql.Append("@OrderNo,@OrderTopic,@SuppNo,@PayAmounts,@PayState,@StaffBranch,@StaffDepart,@ReceivStaffNo,@PayAddTime)");
            SqlParameter[] parameters = {
					
					new SqlParameter("@OrderNo", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderTopic", SqlDbType.NVarChar,80),
					new SqlParameter("@SuppNo", SqlDbType.NVarChar,50),
					new SqlParameter("@PayAmounts", SqlDbType.Decimal,9),
					new SqlParameter("@PayState", SqlDbType.Int,4),
					new SqlParameter("@StaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@StaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@ReceivStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@PayAddTime", SqlDbType.DateTime)};
          
            parameters[0].Value = model.OrderNo;
            parameters[1].Value = model.OrderTopic;
            parameters[2].Value = model.SuppNo;
            parameters[3].Value = model.PayAmounts;
            parameters[4].Value = model.PayState;
            parameters[5].Value = model.StaffBranch;
            parameters[6].Value = model.StaffDepart;
            parameters[7].Value = model.ReceivStaffNo;
            parameters[8].Value = model.PayAddTime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from A_AdvancesPriceDB ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.A_AdvancesPriceDB GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,OrderNo,OrderTopic,SuppNo,PayAmounts,PayState,StaffBranch,StaffDepart,ReceivStaffNo,PayAddTime,PayAmountsStay from A_AdvancesPriceDB ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.A_AdvancesPriceDB model = new KNet.Model.A_AdvancesPriceDB();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.OrderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                model.OrderTopic = ds.Tables[0].Rows[0]["OrderTopic"].ToString();
                model.SuppNo = ds.Tables[0].Rows[0]["SuppNo"].ToString();
                if (ds.Tables[0].Rows[0]["PayAmounts"].ToString() != "")
                {
                    model.PayAmounts = decimal.Parse(ds.Tables[0].Rows[0]["PayAmounts"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PayAmountsStay"].ToString() != "")
                {
                    model.PayAmountsStay = decimal.Parse(ds.Tables[0].Rows[0]["PayAmountsStay"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PayState"].ToString() != "")
                {
                    model.PayState = int.Parse(ds.Tables[0].Rows[0]["PayState"].ToString());
                }
                model.StaffBranch = ds.Tables[0].Rows[0]["StaffBranch"].ToString();
                model.StaffDepart = ds.Tables[0].Rows[0]["StaffDepart"].ToString();
                model.ReceivStaffNo = ds.Tables[0].Rows[0]["ReceivStaffNo"].ToString();
                if (ds.Tables[0].Rows[0]["PayAddTime"].ToString() != "")
                {
                    model.PayAddTime = DateTime.Parse(ds.Tables[0].Rows[0]["PayAddTime"].ToString());
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
            strSql.Append("select ID,OrderNo,OrderTopic,SuppNo,PayAmounts,PayState,StaffBranch,StaffDepart,ReceivStaffNo,PayAddTime,PayAmountsStay ");
            strSql.Append(" FROM A_AdvancesPriceDB ");
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
            strSql.Append(" ID,OrderNo,OrderTopic,SuppNo,PayAmounts,PayState,StaffBranch,StaffDepart,ReceivStaffNo,PayAddTime,PayAmountsStay ");
            strSql.Append(" FROM A_AdvancesPriceDB ");
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


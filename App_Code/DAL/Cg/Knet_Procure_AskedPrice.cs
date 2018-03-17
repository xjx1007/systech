using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类Knet_Procure_AskedPrice。
    /// </summary>
    public class Knet_Procure_AskedPrice
    {
        public Knet_Procure_AskedPrice()
        { }
        #region  成员方法
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public void Add(KNet.Model.Knet_Procure_AskedPrice model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					
					new SqlParameter("@AskedPriceTopic", SqlDbType.NVarChar,50),
					new SqlParameter("@AskedPriceNo", SqlDbType.NVarChar,50),
					new SqlParameter("@AskedPriceDateTime", SqlDbType.DateTime),
					new SqlParameter("@SuppNo", SqlDbType.NVarChar,50),
					new SqlParameter("@AskedPriceStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@AskedPriceStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@AskedPriceStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@AskedPriceState", SqlDbType.Int,4),
					new SqlParameter("@AskedPriceContent", SqlDbType.NText)};
            
            parameters[0].Value = model.AskedPriceTopic;
            parameters[1].Value = model.AskedPriceNo;
            parameters[2].Value = model.AskedPriceDateTime;
            parameters[3].Value = model.SuppNo;
            parameters[4].Value = model.AskedPriceStaffBranch;
            parameters[5].Value = model.AskedPriceStaffDepart;
            parameters[6].Value = model.AskedPriceStaffNo;
            parameters[7].Value = model.AskedPriceState;
            parameters[8].Value = model.AskedPriceContent;

            DbHelperSQL.RunProcedure("Proc_Knet_Procure_AskedPrice_ADD", parameters, out rowsAffected);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.Knet_Procure_AskedPrice model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@AskedPriceTopic", SqlDbType.NVarChar,50),
					
					new SqlParameter("@AskedPriceDateTime", SqlDbType.DateTime),
					new SqlParameter("@SuppNo", SqlDbType.NVarChar,50),
					new SqlParameter("@AskedPriceStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@AskedPriceStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@AskedPriceStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@AskedPriceState", SqlDbType.Int,4),
					new SqlParameter("@AskedPriceContent", SqlDbType.NText)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.AskedPriceTopic;
        
            parameters[2].Value = model.AskedPriceDateTime;
            parameters[3].Value = model.SuppNo;
            parameters[4].Value = model.AskedPriceStaffBranch;
            parameters[5].Value = model.AskedPriceStaffDepart;
            parameters[6].Value = model.AskedPriceStaffNo;
            parameters[7].Value = model.AskedPriceState;
            parameters[8].Value = model.AskedPriceContent;

            DbHelperSQL.RunProcedure("Proc_Knet_Procure_AskedPrice_Update", parameters, out rowsAffected);
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

            DbHelperSQL.RunProcedure("Proc_Knet_Procure_AskedPrice_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_AskedPrice GetModel(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.Knet_Procure_AskedPrice model = new KNet.Model.Knet_Procure_AskedPrice();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_Knet_Procure_AskedPrice_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.AskedPriceTopic = ds.Tables[0].Rows[0]["AskedPriceTopic"].ToString();
                model.AskedPriceNo = ds.Tables[0].Rows[0]["AskedPriceNo"].ToString();
                if (ds.Tables[0].Rows[0]["AskedPriceDateTime"].ToString() != "")
                {
                    model.AskedPriceDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["AskedPriceDateTime"].ToString());
                }
                model.SuppNo = ds.Tables[0].Rows[0]["SuppNo"].ToString();
                model.AskedPriceStaffBranch = ds.Tables[0].Rows[0]["AskedPriceStaffBranch"].ToString();
                model.AskedPriceStaffDepart = ds.Tables[0].Rows[0]["AskedPriceStaffDepart"].ToString();
                model.AskedPriceStaffNo = ds.Tables[0].Rows[0]["AskedPriceStaffNo"].ToString();
                if (ds.Tables[0].Rows[0]["AskedPriceState"].ToString() != "")
                {
                    model.AskedPriceState = int.Parse(ds.Tables[0].Rows[0]["AskedPriceState"].ToString());
                }
                model.AskedPriceContent = ds.Tables[0].Rows[0]["AskedPriceContent"].ToString();
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
            strSql.Append("select ID,AskedPriceTopic,AskedPriceNo,AskedPriceDateTime,SuppNo,AskedPriceStaffBranch,AskedPriceStaffDepart,AskedPriceStaffNo,AskedPriceState,AskedPriceContent ");
            strSql.Append(" FROM Knet_Procure_AskedPrice ");
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
            strSql.Append(" ID,AskedPriceTopic,AskedPriceNo,AskedPriceDateTime,SuppNo,AskedPriceStaffBranch,AskedPriceStaffDepart,AskedPriceStaffNo,AskedPriceState,AskedPriceContent ");
            strSql.Append(" FROM Knet_Procure_AskedPrice ");
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


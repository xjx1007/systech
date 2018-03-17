using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sales_BaoPriceList_fuplist。
    /// </summary>
    public class KNet_Sales_BaoPriceList_fuplist
    {
        public KNet_Sales_BaoPriceList_fuplist()
        { }
        #region  成员方法
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sales_BaoPriceList_fuplist model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@followupNo", SqlDbType.NVarChar,50),
					new SqlParameter("@BaoPriceNo", SqlDbType.NVarChar,50),
					new SqlParameter("@followupDateTime", SqlDbType.DateTime),
					new SqlParameter("@followupStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@followupText", SqlDbType.NVarChar,2000)};
            parameters[0].Value = model.followupNo;
            parameters[1].Value = model.BaoPriceNo;
            parameters[2].Value = model.followupDateTime;
            parameters[3].Value = model.followupStaffNo;
            parameters[4].Value = model.followupText;

            DbHelperSQL.RunProcedure("Proc_KNet_Sales_BaoPriceList_fuplist_ADD", parameters, out rowsAffected);
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

            DbHelperSQL.RunProcedure("Proc_KNet_Sales_BaoPriceList_fuplist_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,followupNo,BaoPriceNo,followupDateTime,followupStaffNo,followupText ");
            strSql.Append(" FROM KNet_Sales_BaoPriceList_fuplist ");
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
            strSql.Append(" ID,followupNo,BaoPriceNo,followupDateTime,followupStaffNo,followupText ");
            strSql.Append(" FROM KNet_Sales_BaoPriceList_fuplist ");
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


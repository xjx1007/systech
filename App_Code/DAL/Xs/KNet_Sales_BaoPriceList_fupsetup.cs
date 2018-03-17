using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sales_BaoPriceList_fupsetup。
    /// </summary>
    public class KNet_Sales_BaoPriceList_fupsetup
    {
        public KNet_Sales_BaoPriceList_fupsetup()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string TalkCom, string StaffNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@TalkCom", SqlDbType.NVarChar,300),
                    new SqlParameter("@StaffNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = TalkCom;
            parameters[1].Value = StaffNo;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sales_BaoPriceList_fupsetup_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.KNet_Sales_BaoPriceList_fupsetup model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
	
					new SqlParameter("@TalkCom", SqlDbType.NVarChar,300),
					new SqlParameter("@StaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@TalkPai", SqlDbType.Int,4)};
           
            parameters[0].Value = model.TalkCom;
            parameters[1].Value = model.StaffNo;
            parameters[2].Value = model.TalkPai;

            DbHelperSQL.RunProcedure("Proc_KNet_Sales_BaoPriceList_fupsetup_ADD", parameters, out rowsAffected);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sales_BaoPriceList_fupsetup model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@TalkCom", SqlDbType.NVarChar,300),

					new SqlParameter("@TalkPai", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.TalkCom;
            parameters[2].Value = model.TalkPai;

            DbHelperSQL.RunProcedure("Proc_KNet_Sales_BaoPriceList_fupsetup_Update", parameters, out rowsAffected);
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

            DbHelperSQL.RunProcedure("Proc_KNet_Sales_BaoPriceList_fupsetup_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_BaoPriceList_fupsetup GetModel(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_Sales_BaoPriceList_fupsetup model = new KNet.Model.KNet_Sales_BaoPriceList_fupsetup();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_Sales_BaoPriceList_fupsetup_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.TalkCom = ds.Tables[0].Rows[0]["TalkCom"].ToString();
                model.StaffNo = ds.Tables[0].Rows[0]["StaffNo"].ToString();
                if (ds.Tables[0].Rows[0]["TalkPai"].ToString() != "")
                {
                    model.TalkPai = int.Parse(ds.Tables[0].Rows[0]["TalkPai"].ToString());
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
            strSql.Append("select ID,TalkCom,StaffNo,TalkPai ");
            strSql.Append(" FROM KNet_Sales_BaoPriceList_fupsetup ");
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
            strSql.Append(" ID,TalkCom,StaffNo,TalkPai ");
            strSql.Append(" FROM KNet_Sales_BaoPriceList_fupsetup ");
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


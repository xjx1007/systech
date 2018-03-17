using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:PB_Products_CgDays
    /// </summary>
    public partial class PB_Products_CgDays
    {
        public PB_Products_CgDays()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PPC_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PB_Products_CgDays");
            strSql.Append(" where PPC_ID=@PPC_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPC_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PPC_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Products_CgDays model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PB_Products_CgDays(");
            strSql.Append("PPC_ID,PPC_ProductsBarCode,PPC_Min,PPC_Max,PPC_Days)");
            strSql.Append(" values (");
            strSql.Append("@PPC_ID,@PPC_ProductsBarCode,@PPC_Min,@PPC_Max,@PPC_Days)");
            SqlParameter[] parameters = {
					new SqlParameter("@PPC_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PPC_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@PPC_Min", SqlDbType.Decimal,9),
					new SqlParameter("@PPC_Max", SqlDbType.Decimal,9),
					new SqlParameter("@PPC_Days", SqlDbType.Int,4)};
            parameters[0].Value = model.PPC_ID;
            parameters[1].Value = model.PPC_ProductsBarCode;
            parameters[2].Value = model.PPC_Min;
            parameters[3].Value = model.PPC_Max;
            parameters[4].Value = model.PPC_Days;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Products_CgDays model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PB_Products_CgDays set ");
            strSql.Append("PPC_ProductsBarCode=@PPC_ProductsBarCode,");
            strSql.Append("PPC_Min=@PPC_Min,");
            strSql.Append("PPC_Max=@PPC_Max,");
            strSql.Append("PPC_Days=@PPC_Days");
            strSql.Append(" where PPC_ID=@PPC_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPC_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@PPC_Min", SqlDbType.Decimal,9),
					new SqlParameter("@PPC_Max", SqlDbType.Decimal,9),
					new SqlParameter("@PPC_Days", SqlDbType.Int,4),
					new SqlParameter("@PPC_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PPC_ProductsBarCode;
            parameters[1].Value = model.PPC_Min;
            parameters[2].Value = model.PPC_Max;
            parameters[3].Value = model.PPC_Days;
            parameters[4].Value = model.PPC_ID;

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
        public bool Delete(string PPC_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Products_CgDays ");
            strSql.Append(" where PPC_ID=@PPC_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPC_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PPC_ID;

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
        public bool DeleteByProductsBarCode(string ProductsBarCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Products_CgDays ");
            strSql.Append(" where PPC_ProductsBarCode=@PPC_ProductsBarCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPC_ProductsBarCode", SqlDbType.VarChar,50)};
            parameters[0].Value = ProductsBarCode;

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
        public bool DeleteList(string PPC_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Products_CgDays ");
            strSql.Append(" where PPC_ID in (" + PPC_IDlist + ")  ");
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
        public KNet.Model.PB_Products_CgDays GetModel(string PPC_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PPC_ID,PPC_ProductsBarCode,PPC_Min,PPC_Max,PPC_Days from PB_Products_CgDays ");
            strSql.Append(" where PPC_ID=@PPC_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPC_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PPC_ID;

            KNet.Model.PB_Products_CgDays model = new KNet.Model.PB_Products_CgDays();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PPC_ID"] != null && ds.Tables[0].Rows[0]["PPC_ID"].ToString() != "")
                {
                    model.PPC_ID = ds.Tables[0].Rows[0]["PPC_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPC_ProductsBarCode"] != null && ds.Tables[0].Rows[0]["PPC_ProductsBarCode"].ToString() != "")
                {
                    model.PPC_ProductsBarCode = ds.Tables[0].Rows[0]["PPC_ProductsBarCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPC_Min"] != null && ds.Tables[0].Rows[0]["PPC_Min"].ToString() != "")
                {
                    model.PPC_Min = decimal.Parse(ds.Tables[0].Rows[0]["PPC_Min"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PPC_Max"] != null && ds.Tables[0].Rows[0]["PPC_Max"].ToString() != "")
                {
                    model.PPC_Max = decimal.Parse(ds.Tables[0].Rows[0]["PPC_Max"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PPC_Days"] != null && ds.Tables[0].Rows[0]["PPC_Days"].ToString() != "")
                {
                    model.PPC_Days = int.Parse(ds.Tables[0].Rows[0]["PPC_Days"].ToString());
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
            strSql.Append("select PPC_ID,PPC_ProductsBarCode,PPC_Min,PPC_Max,PPC_Days ");
            strSql.Append(" FROM PB_Products_CgDays ");
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
            strSql.Append(" PPC_ID,PPC_ProductsBarCode,PPC_Min,PPC_Max,PPC_Days ");
            strSql.Append(" FROM PB_Products_CgDays ");
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
            parameters[0].Value = "PB_Products_CgDays";
            parameters[1].Value = "PPC_ID";
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


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:PB_Code_Sequence
    /// </summary>
    public partial class PB_Code_Sequence
    {
        public PB_Code_Sequence()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PCS_Table, string PCS_Type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PB_Code_Sequence");
            strSql.Append(" where PCS_Table=@PCS_Table and PCS_Type=@PCS_Type ");
            SqlParameter[] parameters = {
					new SqlParameter("@PCS_Table", SqlDbType.VarChar,64),
					new SqlParameter("@PCS_Type", SqlDbType.VarChar,3)};
            parameters[0].Value = PCS_Table;
            parameters[1].Value = PCS_Type;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Code_Sequence model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PB_Code_Sequence(");
            strSql.Append("PCS_Table,PCS_Date,PCS_Type,PCS_Identity,PCS_Default)");
            strSql.Append(" values (");
            strSql.Append("@PCS_Table,@PCS_Date,@PCS_Type,@PCS_Identity,@PCS_Default)");
            SqlParameter[] parameters = {
					new SqlParameter("@PCS_Table", SqlDbType.VarChar,64),
					new SqlParameter("@PCS_Date", SqlDbType.DateTime),
					new SqlParameter("@PCS_Type", SqlDbType.VarChar,3),
					new SqlParameter("@PCS_Identity", SqlDbType.Decimal,9),
					new SqlParameter("@PCS_Default", SqlDbType.Decimal,9)};
            parameters[0].Value = model.PCS_Table;
            parameters[1].Value = model.PCS_Date;
            parameters[2].Value = model.PCS_Type;
            parameters[3].Value = model.PCS_Identity;
            parameters[4].Value = model.PCS_Default;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Code_Sequence model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PB_Code_Sequence set ");
            strSql.Append("PCS_Date=@PCS_Date,");
            strSql.Append("PCS_Identity=@PCS_Identity,");
            strSql.Append("PCS_Default=@PCS_Default");
            strSql.Append(" where PCS_Table=@PCS_Table and PCS_Type=@PCS_Type ");
            SqlParameter[] parameters = {
					new SqlParameter("@PCS_Date", SqlDbType.DateTime),
					new SqlParameter("@PCS_Identity", SqlDbType.Decimal,9),
					new SqlParameter("@PCS_Default", SqlDbType.Decimal,9),
					new SqlParameter("@PCS_Table", SqlDbType.VarChar,64),
					new SqlParameter("@PCS_Type", SqlDbType.VarChar,3)};
            parameters[0].Value = model.PCS_Date;
            parameters[1].Value = model.PCS_Identity;
            parameters[2].Value = model.PCS_Default;
            parameters[3].Value = model.PCS_Table;
            parameters[4].Value = model.PCS_Type;

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
        public bool Delete(string PCS_Table, string PCS_Type)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Code_Sequence ");
            strSql.Append(" where PCS_Table=@PCS_Table and PCS_Type=@PCS_Type ");
            SqlParameter[] parameters = {
					new SqlParameter("@PCS_Table", SqlDbType.VarChar,64),
					new SqlParameter("@PCS_Type", SqlDbType.VarChar,3)};
            parameters[0].Value = PCS_Table;
            parameters[1].Value = PCS_Type;

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
        public KNet.Model.PB_Code_Sequence GetModel(string PCS_Table, string PCS_Type)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PCS_Table,PCS_Date,PCS_Type,PCS_Identity,PCS_Default from PB_Code_Sequence ");
            strSql.Append(" where PCS_Table=@PCS_Table and PCS_Type=@PCS_Type ");
            SqlParameter[] parameters = {
					new SqlParameter("@PCS_Table", SqlDbType.VarChar,64),
					new SqlParameter("@PCS_Type", SqlDbType.VarChar,3)};
            parameters[0].Value = PCS_Table;
            parameters[1].Value = PCS_Type;

            KNet.Model.PB_Code_Sequence model = new KNet.Model.PB_Code_Sequence();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PCS_Table"] != null && ds.Tables[0].Rows[0]["PCS_Table"].ToString() != "")
                {
                    model.PCS_Table = ds.Tables[0].Rows[0]["PCS_Table"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PCS_Date"] != null && ds.Tables[0].Rows[0]["PCS_Date"].ToString() != "")
                {
                    model.PCS_Date = DateTime.Parse(ds.Tables[0].Rows[0]["PCS_Date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PCS_Type"] != null && ds.Tables[0].Rows[0]["PCS_Type"].ToString() != "")
                {
                    model.PCS_Type = ds.Tables[0].Rows[0]["PCS_Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PCS_Identity"] != null && ds.Tables[0].Rows[0]["PCS_Identity"].ToString() != "")
                {
                    model.PCS_Identity = decimal.Parse(ds.Tables[0].Rows[0]["PCS_Identity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PCS_Default"] != null && ds.Tables[0].Rows[0]["PCS_Default"].ToString() != "")
                {
                    model.PCS_Default = decimal.Parse(ds.Tables[0].Rows[0]["PCS_Default"].ToString());
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
            strSql.Append("select PCS_Table,PCS_Date,PCS_Type,PCS_Identity,PCS_Default ");
            strSql.Append(" FROM PB_Code_Sequence ");
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
            strSql.Append(" PCS_Table,PCS_Date,PCS_Type,PCS_Identity,PCS_Default ");
            strSql.Append(" FROM PB_Code_Sequence ");
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
            parameters[0].Value = "PB_Code_Sequence";
            parameters[1].Value = "PCS_Type";
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


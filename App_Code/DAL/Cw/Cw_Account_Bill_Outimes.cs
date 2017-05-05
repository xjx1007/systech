using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Cw_Account_Bill_Outimes
    /// </summary>
    public partial class Cw_Account_Bill_Outimes
    {
        public Cw_Account_Bill_Outimes()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CAO_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cw_Account_Bill_Outimes");
            strSql.Append(" where CAO_ID=@CAO_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAO_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAO_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cw_Account_Bill_Outimes model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cw_Account_Bill_Outimes(");
            strSql.Append("CAO_ID,CAO_CADID,CAO_Money,CAO_OutDays,CAO_OutTime,CAO_Remarks,CAOC_DirectOutID)");
            strSql.Append(" values (");
            strSql.Append("@CAO_ID,@CAO_CADID,@CAO_Money,@CAO_OutDays,@CAO_OutTime,@CAO_Remarks,@CAOC_DirectOutID)");
            SqlParameter[] parameters = {
					new SqlParameter("@CAO_ID", SqlDbType.VarChar,50),
					new SqlParameter("@CAO_CADID", SqlDbType.VarChar,50),
					new SqlParameter("@CAO_Money", SqlDbType.Decimal,9),
					new SqlParameter("@CAO_OutDays", SqlDbType.Int,4),
					new SqlParameter("@CAO_OutTime", SqlDbType.DateTime),
					new SqlParameter("@CAO_Remarks", SqlDbType.VarChar,50),
					new SqlParameter("@CAOC_DirectOutID", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = model.CAO_ID;
            parameters[1].Value = model.CAO_CADID;
            parameters[2].Value = model.CAO_Money;
            parameters[3].Value = model.CAO_OutDays;
            parameters[4].Value = model.CAO_OutTime;
            parameters[5].Value = model.CAO_Remarks;
            parameters[6].Value = model.CAOC_DirectOutID;
            
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cw_Account_Bill_Outimes model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cw_Account_Bill_Outimes set ");
            strSql.Append("CAO_CADID=@CAO_CADID,");
            strSql.Append("CAO_Money=@CAO_Money,");
            strSql.Append("CAO_OutDays=@CAO_OutDays,");
            strSql.Append("CAO_OutTime=@CAO_OutTime,");
            strSql.Append("CAO_Remarks=@CAO_Remarks");
            strSql.Append(" where CAO_ID=@CAO_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAO_CADID", SqlDbType.VarChar,50),
					new SqlParameter("@CAO_Money", SqlDbType.Decimal,9),
					new SqlParameter("@CAO_OutDays", SqlDbType.Int,4),
					new SqlParameter("@CAO_OutTime", SqlDbType.DateTime),
					new SqlParameter("@CAO_Remarks", SqlDbType.VarChar,50),
					new SqlParameter("@CAO_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CAO_CADID;
            parameters[1].Value = model.CAO_Money;
            parameters[2].Value = model.CAO_OutDays;
            parameters[3].Value = model.CAO_OutTime;
            parameters[4].Value = model.CAO_Remarks;
            parameters[5].Value = model.CAO_ID;

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
        public bool Delete(string CAO_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cw_Account_Bill_Outimes ");
            strSql.Append(" where CAO_ID=@CAO_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAO_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAO_ID;

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
        public bool DeleteByFID(string CAO_CADID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cw_Account_Bill_Outimes ");
            strSql.Append(" where CAO_CADID=@CAO_CADID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAO_CADID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAO_CADID;

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
        public bool DeleteList(string CAO_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cw_Account_Bill_Outimes ");
            strSql.Append(" where CAO_ID in (" + CAO_IDlist + ")  ");
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
        public KNet.Model.Cw_Account_Bill_Outimes GetModel(string CAO_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CAO_ID,CAO_CADID,CAO_Money,CAO_OutDays,CAO_OutTime,CAO_Remarks from Cw_Account_Bill_Outimes ");
            strSql.Append(" where CAO_ID=@CAO_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAO_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAO_ID;

            KNet.Model.Cw_Account_Bill_Outimes model = new KNet.Model.Cw_Account_Bill_Outimes();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CAO_ID"] != null && ds.Tables[0].Rows[0]["CAO_ID"].ToString() != "")
                {
                    model.CAO_ID = ds.Tables[0].Rows[0]["CAO_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAO_CADID"] != null && ds.Tables[0].Rows[0]["CAO_CADID"].ToString() != "")
                {
                    model.CAO_CADID = ds.Tables[0].Rows[0]["CAO_CADID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAO_Money"] != null && ds.Tables[0].Rows[0]["CAO_Money"].ToString() != "")
                {
                    model.CAO_Money = decimal.Parse(ds.Tables[0].Rows[0]["CAO_Money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAO_OutDays"] != null && ds.Tables[0].Rows[0]["CAO_OutDays"].ToString() != "")
                {
                    model.CAO_OutDays = int.Parse(ds.Tables[0].Rows[0]["CAO_OutDays"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAO_OutTime"] != null && ds.Tables[0].Rows[0]["CAO_OutTime"].ToString() != "")
                {
                    model.CAO_OutTime = DateTime.Parse(ds.Tables[0].Rows[0]["CAO_OutTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAO_Remarks"] != null && ds.Tables[0].Rows[0]["CAO_Remarks"].ToString() != "")
                {
                    model.CAO_Remarks = ds.Tables[0].Rows[0]["CAO_Remarks"].ToString();
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
            strSql.Append("select CAO_ID,CAO_CADID,CAO_Money,CAO_OutDays,CAO_OutTime,CAO_Remarks ");
            strSql.Append(" FROM Cw_Account_Bill_Outimes ");
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
            strSql.Append(" CAO_ID,CAO_CADID,CAO_Money,CAO_OutDays,CAO_OutTime,CAO_Remarks ");
            strSql.Append(" FROM Cw_Account_Bill_Outimes ");
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
            parameters[0].Value = "Cw_Account_Bill_Outimes";
            parameters[1].Value = "CAO_ID";
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


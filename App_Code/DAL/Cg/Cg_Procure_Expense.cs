using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Cg_Procure_Expense
    /// </summary>
    public partial class Cg_Procure_Expense
    {
        public Cg_Procure_Expense()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CPE_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cg_Procure_Expense");
            strSql.Append(" where CPE_ID=@CPE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CPE_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CPE_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cg_Procure_Expense model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cg_Procure_Expense(");
            strSql.Append("CPE_ID,CPE_Code,CPE_DirectOutNo,CPE_Stime,CPE_Cuse,CPE_Number,CPE_Price,CPE_Money,CPE_Percent,CPE_SuppMoney,CPE_PayMoney,CPE_Details,CPE_Del,CPE_CTime,CPE_Creator,CPE_MTime,CPE_Mender)");
            strSql.Append(" values (");
            strSql.Append("@CPE_ID,@CPE_Code,@CPE_DirectOutNo,@CPE_Stime,@CPE_Cuse,@CPE_Number,@CPE_Price,@CPE_Money,@CPE_Percent,@CPE_SuppMoney,@CPE_PayMoney,@CPE_Details,@CPE_Del,@CPE_CTime,@CPE_Creator,@CPE_MTime,@CPE_Mender)");
            SqlParameter[] parameters = {
					new SqlParameter("@CPE_ID", SqlDbType.VarChar,50),
					new SqlParameter("@CPE_Code", SqlDbType.VarChar,50),
					new SqlParameter("@CPE_DirectOutNo", SqlDbType.VarChar,50),
					new SqlParameter("@CPE_Stime", SqlDbType.DateTime),
					new SqlParameter("@CPE_Cuse", SqlDbType.VarChar,500),
					new SqlParameter("@CPE_Number", SqlDbType.Int,4),
					new SqlParameter("@CPE_Price", SqlDbType.Decimal,9),
					new SqlParameter("@CPE_Money", SqlDbType.Decimal,9),
					new SqlParameter("@CPE_Percent", SqlDbType.Decimal,9),
					new SqlParameter("@CPE_SuppMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CPE_PayMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CPE_Details", SqlDbType.VarChar,500),
					new SqlParameter("@CPE_Del", SqlDbType.Int,4),
					new SqlParameter("@CPE_CTime", SqlDbType.DateTime),
					new SqlParameter("@CPE_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@CPE_MTime", SqlDbType.DateTime),
					new SqlParameter("@CPE_Mender", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CPE_ID;
            parameters[1].Value = model.CPE_Code;
            parameters[2].Value = model.CPE_DirectOutNo;
            parameters[3].Value = model.CPE_Stime;
            parameters[4].Value = model.CPE_Cuse;
            parameters[5].Value = model.CPE_Number;
            parameters[6].Value = model.CPE_Price;
            parameters[7].Value = model.CPE_Money;
            parameters[8].Value = model.CPE_Percent;
            parameters[9].Value = model.CPE_SuppMoney;
            parameters[10].Value = model.CPE_PayMoney;
            parameters[11].Value = model.CPE_Details;
            parameters[12].Value = model.CPE_Del;
            parameters[13].Value = model.CPE_CTime;
            parameters[14].Value = model.CPE_Creator;
            parameters[15].Value = model.CPE_MTime;
            parameters[16].Value = model.CPE_Mender;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cg_Procure_Expense model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cg_Procure_Expense set ");
            strSql.Append("CPE_Code=@CPE_Code,");
            strSql.Append("CPE_DirectOutNo=@CPE_DirectOutNo,");
            strSql.Append("CPE_Stime=@CPE_Stime,");
            strSql.Append("CPE_Cuse=@CPE_Cuse,");
            strSql.Append("CPE_Number=@CPE_Number,");
            strSql.Append("CPE_Price=@CPE_Price,");
            strSql.Append("CPE_Money=@CPE_Money,");
            strSql.Append("CPE_Percent=@CPE_Percent,");
            strSql.Append("CPE_SuppMoney=@CPE_SuppMoney,");
            strSql.Append("CPE_PayMoney=@CPE_PayMoney,");
            strSql.Append("CPE_Details=@CPE_Details,");
            strSql.Append("CPE_Del=@CPE_Del,");
            strSql.Append("CPE_CTime=@CPE_CTime,");
            strSql.Append("CPE_Creator=@CPE_Creator,");
            strSql.Append("CPE_MTime=@CPE_MTime,");
            strSql.Append("CPE_Mender=@CPE_Mender");
            strSql.Append(" where CPE_ID=@CPE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CPE_Code", SqlDbType.VarChar,50),
					new SqlParameter("@CPE_DirectOutNo", SqlDbType.VarChar,50),
					new SqlParameter("@CPE_Stime", SqlDbType.DateTime),
					new SqlParameter("@CPE_Cuse", SqlDbType.VarChar,500),
					new SqlParameter("@CPE_Number", SqlDbType.Int,4),
					new SqlParameter("@CPE_Price", SqlDbType.Decimal,9),
					new SqlParameter("@CPE_Money", SqlDbType.Decimal,9),
					new SqlParameter("@CPE_Percent", SqlDbType.Decimal,9),
					new SqlParameter("@CPE_SuppMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CPE_PayMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CPE_Details", SqlDbType.VarChar,500),
					new SqlParameter("@CPE_Del", SqlDbType.Int,4),
					new SqlParameter("@CPE_CTime", SqlDbType.DateTime),
					new SqlParameter("@CPE_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@CPE_MTime", SqlDbType.DateTime),
					new SqlParameter("@CPE_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@CPE_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CPE_Code;
            parameters[1].Value = model.CPE_DirectOutNo;
            parameters[2].Value = model.CPE_Stime;
            parameters[3].Value = model.CPE_Cuse;
            parameters[4].Value = model.CPE_Number;
            parameters[5].Value = model.CPE_Price;
            parameters[6].Value = model.CPE_Money;
            parameters[7].Value = model.CPE_Percent;
            parameters[8].Value = model.CPE_SuppMoney;
            parameters[9].Value = model.CPE_PayMoney;
            parameters[10].Value = model.CPE_Details;
            parameters[11].Value = model.CPE_Del;
            parameters[12].Value = model.CPE_CTime;
            parameters[13].Value = model.CPE_Creator;
            parameters[14].Value = model.CPE_MTime;
            parameters[15].Value = model.CPE_Mender;
            parameters[16].Value = model.CPE_ID;

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
        public bool Delete(string CPE_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cg_Procure_Expense ");
            strSql.Append(" where CPE_ID=@CPE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CPE_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CPE_ID;

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
        public bool DeleteList(string CPE_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cg_Procure_Expense ");
            strSql.Append(" where CPE_ID in (" + CPE_IDlist + ")  ");
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
        public KNet.Model.Cg_Procure_Expense GetModel(string CPE_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CPE_ID,CPE_Code,CPE_DirectOutNo,CPE_Stime,CPE_Cuse,CPE_Number,CPE_Price,CPE_Money,CPE_Percent,CPE_SuppMoney,CPE_PayMoney,CPE_Details,CPE_Del,CPE_CTime,CPE_Creator,CPE_MTime,CPE_Mender from Cg_Procure_Expense ");
            strSql.Append(" where CPE_ID=@CPE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CPE_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CPE_ID;

            KNet.Model.Cg_Procure_Expense model = new KNet.Model.Cg_Procure_Expense();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CPE_ID"] != null && ds.Tables[0].Rows[0]["CPE_ID"].ToString() != "")
                {
                    model.CPE_ID = ds.Tables[0].Rows[0]["CPE_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CPE_Code"] != null && ds.Tables[0].Rows[0]["CPE_Code"].ToString() != "")
                {
                    model.CPE_Code = ds.Tables[0].Rows[0]["CPE_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CPE_DirectOutNo"] != null && ds.Tables[0].Rows[0]["CPE_DirectOutNo"].ToString() != "")
                {
                    model.CPE_DirectOutNo = ds.Tables[0].Rows[0]["CPE_DirectOutNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CPE_Stime"] != null && ds.Tables[0].Rows[0]["CPE_Stime"].ToString() != "")
                {
                    model.CPE_Stime = DateTime.Parse(ds.Tables[0].Rows[0]["CPE_Stime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CPE_Cuse"] != null && ds.Tables[0].Rows[0]["CPE_Cuse"].ToString() != "")
                {
                    model.CPE_Cuse = ds.Tables[0].Rows[0]["CPE_Cuse"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CPE_Number"] != null && ds.Tables[0].Rows[0]["CPE_Number"].ToString() != "")
                {
                    model.CPE_Number = int.Parse(ds.Tables[0].Rows[0]["CPE_Number"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CPE_Price"] != null && ds.Tables[0].Rows[0]["CPE_Price"].ToString() != "")
                {
                    model.CPE_Price = decimal.Parse(ds.Tables[0].Rows[0]["CPE_Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CPE_Money"] != null && ds.Tables[0].Rows[0]["CPE_Money"].ToString() != "")
                {
                    model.CPE_Money = decimal.Parse(ds.Tables[0].Rows[0]["CPE_Money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CPE_Percent"] != null && ds.Tables[0].Rows[0]["CPE_Percent"].ToString() != "")
                {
                    model.CPE_Percent = decimal.Parse(ds.Tables[0].Rows[0]["CPE_Percent"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CPE_SuppMoney"] != null && ds.Tables[0].Rows[0]["CPE_SuppMoney"].ToString() != "")
                {
                    model.CPE_SuppMoney = decimal.Parse(ds.Tables[0].Rows[0]["CPE_SuppMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CPE_PayMoney"] != null && ds.Tables[0].Rows[0]["CPE_PayMoney"].ToString() != "")
                {
                    model.CPE_PayMoney = decimal.Parse(ds.Tables[0].Rows[0]["CPE_PayMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CPE_Details"] != null && ds.Tables[0].Rows[0]["CPE_Details"].ToString() != "")
                {
                    model.CPE_Details = ds.Tables[0].Rows[0]["CPE_Details"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CPE_Del"] != null && ds.Tables[0].Rows[0]["CPE_Del"].ToString() != "")
                {
                    model.CPE_Del = int.Parse(ds.Tables[0].Rows[0]["CPE_Del"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CPE_CTime"] != null && ds.Tables[0].Rows[0]["CPE_CTime"].ToString() != "")
                {
                    model.CPE_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["CPE_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CPE_Creator"] != null && ds.Tables[0].Rows[0]["CPE_Creator"].ToString() != "")
                {
                    model.CPE_Creator = ds.Tables[0].Rows[0]["CPE_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CPE_MTime"] != null && ds.Tables[0].Rows[0]["CPE_MTime"].ToString() != "")
                {
                    model.CPE_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["CPE_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CPE_Mender"] != null && ds.Tables[0].Rows[0]["CPE_Mender"].ToString() != "")
                {
                    model.CPE_Mender = ds.Tables[0].Rows[0]["CPE_Mender"].ToString();
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
            strSql.Append("select CPE_ID,CPE_Code,CPE_DirectOutNo,CPE_Stime,CPE_Cuse,CPE_Number,CPE_Price,CPE_Money,CPE_Percent,CPE_SuppMoney,CPE_PayMoney,CPE_Details,CPE_Del,CPE_CTime,CPE_Creator,CPE_MTime,CPE_Mender ");
            strSql.Append(" FROM Cg_Procure_Expense ");
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
            strSql.Append(" CPE_ID,CPE_Code,CPE_DirectOutNo,CPE_Stime,CPE_Cuse,CPE_Number,CPE_Price,CPE_Money,CPE_Percent,CPE_SuppMoney,CPE_PayMoney,CPE_Details,CPE_Del,CPE_CTime,CPE_Creator,CPE_MTime,CPE_Mender ");
            strSql.Append(" FROM Cg_Procure_Expense ");
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
            parameters[0].Value = "Cg_Procure_Expense";
            parameters[1].Value = "CPE_ID";
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


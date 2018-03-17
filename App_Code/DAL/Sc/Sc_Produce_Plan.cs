using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Sc_Produce_Plan
    /// </summary>
    public partial class Sc_Produce_Plan
    {
        public Sc_Produce_Plan()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SPP_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sc_Produce_Plan");
            strSql.Append(" where SPP_ID=@SPP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SPP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SPP_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Sc_Produce_Plan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sc_Produce_Plan(");
            strSql.Append("SPP_ID,SPP_STime,SPP_Remarks,SPP_Creator,SPP_Ctime,SPP_Del,SPP_SuppNo)");
            strSql.Append(" values (");
            strSql.Append("@SPP_ID,@SPP_STime,@SPP_Remarks,@SPP_Creator,@SPP_Ctime,@SPP_Del,@SPP_SuppNo)");
            SqlParameter[] parameters = {
					new SqlParameter("@SPP_ID", SqlDbType.VarChar,50),
					new SqlParameter("@SPP_STime", SqlDbType.DateTime),
					new SqlParameter("@SPP_Remarks", SqlDbType.VarChar,50),
					new SqlParameter("@SPP_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@SPP_Ctime", SqlDbType.DateTime),
					new SqlParameter("@SPP_Del", SqlDbType.Int,4),
					new SqlParameter("@SPP_SuppNo", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = model.SPP_ID;
            parameters[1].Value = model.SPP_STime;
            parameters[2].Value = model.SPP_Remarks;
            parameters[3].Value = model.SPP_Creator;
            parameters[4].Value = model.SPP_Ctime;
            parameters[5].Value = model.SPP_Del;
            parameters[6].Value = model.SPP_SuppNo;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Sc_Produce_Plan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sc_Produce_Plan set ");
            strSql.Append("SPP_STime=@SPP_STime,");
            strSql.Append("SPP_Remarks=@SPP_Remarks,");
            strSql.Append("SPP_SuppNo=@SPP_SuppNo,");
            strSql.Append("SPP_Creator=@SPP_Creator,");
            strSql.Append("SPP_Ctime=@SPP_Ctime,");
            strSql.Append("SPP_Del=@SPP_Del");
            strSql.Append(" where SPP_ID=@SPP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SPP_STime", SqlDbType.DateTime),
					new SqlParameter("@SPP_Remarks", SqlDbType.VarChar,50),
					new SqlParameter("@SPP_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@SPP_Ctime", SqlDbType.DateTime),
					new SqlParameter("@SPP_Del", SqlDbType.Int,4),
					new SqlParameter("@SPP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SPP_STime;
            parameters[1].Value = model.SPP_Remarks;
            parameters[2].Value = model.SPP_SuppNo;
            parameters[3].Value = model.SPP_Creator;
            parameters[4].Value = model.SPP_Ctime;
            parameters[5].Value = model.SPP_Del;
            parameters[6].Value = model.SPP_ID;

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
        public bool Delete(string SPP_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sc_Produce_Plan ");
            strSql.Append(" where SPP_ID=@SPP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SPP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SPP_ID;

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
        public bool DeleteList(string SPP_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sc_Produce_Plan ");
            strSql.Append(" where SPP_ID in (" + SPP_IDlist + ")  ");
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
        public KNet.Model.Sc_Produce_Plan GetModel(string SPP_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Sc_Produce_Plan ");
            strSql.Append(" where SPP_ID=@SPP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SPP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SPP_ID;

            KNet.Model.Sc_Produce_Plan model = new KNet.Model.Sc_Produce_Plan();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SPP_ID"] != null && ds.Tables[0].Rows[0]["SPP_ID"].ToString() != "")
                {
                    model.SPP_ID = ds.Tables[0].Rows[0]["SPP_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SPP_STime"] != null && ds.Tables[0].Rows[0]["SPP_STime"].ToString() != "")
                {
                    model.SPP_STime = DateTime.Parse(ds.Tables[0].Rows[0]["SPP_STime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SPP_SuppNo"] != null && ds.Tables[0].Rows[0]["SPP_SuppNo"].ToString() != "")
                {
                    model.SPP_SuppNo = ds.Tables[0].Rows[0]["SPP_SuppNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SPP_Remarks"] != null && ds.Tables[0].Rows[0]["SPP_Remarks"].ToString() != "")
                {
                    model.SPP_Remarks = ds.Tables[0].Rows[0]["SPP_Remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SPP_Creator"] != null && ds.Tables[0].Rows[0]["SPP_Creator"].ToString() != "")
                {
                    model.SPP_Creator = ds.Tables[0].Rows[0]["SPP_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SPP_Ctime"] != null && ds.Tables[0].Rows[0]["SPP_Ctime"].ToString() != "")
                {
                    model.SPP_Ctime = DateTime.Parse(ds.Tables[0].Rows[0]["SPP_Ctime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SPP_Del"] != null && ds.Tables[0].Rows[0]["SPP_Del"].ToString() != "")
                {
                    model.SPP_Del = int.Parse(ds.Tables[0].Rows[0]["SPP_Del"].ToString());
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
            strSql.Append(" FROM Sc_Produce_Plan ");
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
            strSql.Append(" SPP_ID,SPP_STime,SPP_Remarks,SPP_Creator,SPP_Ctime,SPP_Del ");
            strSql.Append(" FROM Sc_Produce_Plan ");
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
            parameters[0].Value = "Sc_Produce_Plan";
            parameters[1].Value = "SPP_ID";
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


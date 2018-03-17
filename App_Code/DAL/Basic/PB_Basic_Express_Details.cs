using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:PB_Basic_Express_Details
    /// </summary>
    public partial class PB_Basic_Express_Details
    {
        public PB_Basic_Express_Details()
        { }
        #region  Method


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBED_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PB_Basic_Express_Details");
            strSql.Append(" where PBED_ID='" + PBED_ID + "' ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.PB_Basic_Express_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.PBED_ID != null)
            {
                strSql1.Append("PBED_ID,");
                strSql2.Append("'" + model.PBED_ID + "',");
            }
            if (model.PBED_FID != null)
            {
                strSql1.Append("PBED_FID,");
                strSql2.Append("'" + model.PBED_FID + "',");
            }
            if (model.PBED_Time != null)
            {
                strSql1.Append("PBED_Time,");
                strSql2.Append("'" + model.PBED_Time + "',");
            }
            if (model.PBED_Place != null)
            {
                strSql1.Append("PBED_Place,");
                strSql2.Append("'" + model.PBED_Place + "',");
            }
            if (model.PBED_Details != null)
            {
                strSql1.Append("PBED_Details,");
                strSql2.Append("'" + model.PBED_Details + "',");
            }
            if (model.PBED_State != null)
            {
                strSql1.Append("PBED_State,");
                strSql2.Append("'" + model.PBED_State + "',");
            }
            strSql.Append("insert into PB_Basic_Express_Details(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
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
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Basic_Express_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PB_Basic_Express_Details set ");
            if (model.PBED_FID != null)
            {
                strSql.Append("PBED_FID='" + model.PBED_FID + "',");
            }
            else
            {
                strSql.Append("PBED_FID= null ,");
            }
            if (model.PBED_Time != null)
            {
                strSql.Append("PBED_Time='" + model.PBED_Time + "',");
            }
            else
            {
                strSql.Append("PBED_Time= null ,");
            }
            if (model.PBED_Place != null)
            {
                strSql.Append("PBED_Place='" + model.PBED_Place + "',");
            }
            else
            {
                strSql.Append("PBED_Place= null ,");
            }
            if (model.PBED_Details != null)
            {
                strSql.Append("PBED_Details='" + model.PBED_Details + "',");
            }
            else
            {
                strSql.Append("PBED_Details= null ,");
            }
            if (model.PBED_State != null)
            {
                strSql.Append("PBED_State='" + model.PBED_State + "',");
            }
            else
            {
                strSql.Append("PBED_State= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where PBED_ID='" + model.PBED_ID + "' ");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
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
        public bool Delete(string PBED_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_Express_Details ");
            strSql.Append(" where PBED_ID='" + PBED_ID + "' ");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }		/// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string PBED_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_Express_Details ");
            strSql.Append(" where PBED_ID in (" + PBED_IDlist + ")  ");
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
        public KNet.Model.PB_Basic_Express_Details GetModel(string PBED_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" PBED_ID,PBED_FID,PBED_Time,PBED_Place,PBED_Details,PBED_State ");
            strSql.Append(" from PB_Basic_Express_Details ");
            strSql.Append(" where PBED_ID='" + PBED_ID + "' ");
            KNet.Model.PB_Basic_Express_Details model = new KNet.Model.PB_Basic_Express_Details();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.PB_Basic_Express_Details DataRowToModel(DataRow row)
        {
            KNet.Model.PB_Basic_Express_Details model = new KNet.Model.PB_Basic_Express_Details();
            if (row != null)
            {
                if (row["PBED_ID"] != null)
                {
                    model.PBED_ID = row["PBED_ID"].ToString();
                }
                if (row["PBED_FID"] != null)
                {
                    model.PBED_FID = row["PBED_FID"].ToString();
                }
                if (row["PBED_Time"] != null)
                {
                    model.PBED_Time = row["PBED_Time"].ToString();
                }
                if (row["PBED_Place"] != null)
                {
                    model.PBED_Place = row["PBED_Place"].ToString();
                }
                if (row["PBED_Details"] != null)
                {
                    model.PBED_Details = row["PBED_Details"].ToString();
                }
                if (row["PBED_State"] != null)
                {
                    model.PBED_State = row["PBED_State"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PBED_ID,PBED_FID,PBED_Time,PBED_Place,PBED_Details,PBED_State ");
            strSql.Append(" FROM PB_Basic_Express_Details ");
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
            strSql.Append(" PBED_ID,PBED_FID,PBED_Time,PBED_Place,PBED_Details,PBED_State ");
            strSql.Append(" FROM PB_Basic_Express_Details ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM PB_Basic_Express_Details ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.PBED_ID desc");
            }
            strSql.Append(")AS Row, T.*  from PB_Basic_Express_Details T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        */

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}


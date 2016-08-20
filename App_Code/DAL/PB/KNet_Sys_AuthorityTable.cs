using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:KNet_Sys_AuthorityTable
    /// </summary>
    public partial class KNet_Sys_AuthorityTable
    {
        public KNet_Sys_AuthorityTable()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KNet_Sys_AuthorityTable");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(KNet.Model.KNet_Sys_AuthorityTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Sys_AuthorityTable(");
            strSql.Append("AuthorityName,AuthorityValue,AuthorityGroup,AuthorityFaterID,AuthorityFunction)");
            strSql.Append(" values (");
            strSql.Append("@AuthorityName,@AuthorityValue,@AuthorityGroup,@AuthorityFaterID,@AuthorityFunction)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@AuthorityName", SqlDbType.NVarChar,50),
					new SqlParameter("@AuthorityValue", SqlDbType.Int,4),
					new SqlParameter("@AuthorityGroup", SqlDbType.Int,4),
					new SqlParameter("@AuthorityFaterID", SqlDbType.VarChar,50),
					new SqlParameter("@AuthorityFunction", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = model.AuthorityName;
            parameters[1].Value = model.AuthorityValue;
            parameters[2].Value = model.AuthorityGroup;
            parameters[3].Value = model.AuthorityFaterID;
            parameters[4].Value = model.AuthorityFunction;
            

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.KNet_Sys_AuthorityTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Sys_AuthorityTable set ");
            strSql.Append("AuthorityName=@AuthorityName,");
            strSql.Append("AuthorityValue=@AuthorityValue,");
            strSql.Append("AuthorityGroup=@AuthorityGroup,");
            strSql.Append("AuthorityFaterID=@AuthorityFaterID,");
            strSql.Append("AuthorityFunction=@AuthorityFunction");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@AuthorityName", SqlDbType.NVarChar,50),
					new SqlParameter("@AuthorityValue", SqlDbType.Int,4),
					new SqlParameter("@AuthorityGroup", SqlDbType.Int,4),
					new SqlParameter("@AuthorityFaterID", SqlDbType.VarChar,50),
					new SqlParameter("@AuthorityFunction", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.AuthorityName;
            parameters[1].Value = model.AuthorityValue;
            parameters[2].Value = model.AuthorityGroup;
            parameters[3].Value = model.AuthorityFaterID;
            parameters[4].Value = model.AuthorityFunction;
            parameters[5].Value = model.ID;

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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_Sys_AuthorityTable ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_Sys_AuthorityTable ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public KNet.Model.KNet_Sys_AuthorityTable GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from KNet_Sys_AuthorityTable ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            KNet.Model.KNet_Sys_AuthorityTable model = new KNet.Model.KNet_Sys_AuthorityTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
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
        public KNet.Model.KNet_Sys_AuthorityTable DataRowToModel(DataRow row)
        {
            KNet.Model.KNet_Sys_AuthorityTable model = new KNet.Model.KNet_Sys_AuthorityTable();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["AuthorityName"] != null)
                {
                    model.AuthorityName = row["AuthorityName"].ToString();
                }
                if (row["AuthorityValue"] != null && row["AuthorityValue"].ToString() != "")
                {
                    model.AuthorityValue = int.Parse(row["AuthorityValue"].ToString());
                }
                if (row["AuthorityGroup"] != null && row["AuthorityGroup"].ToString() != "")
                {
                    model.AuthorityGroup = int.Parse(row["AuthorityGroup"].ToString());
                }
                if (row["AuthorityFaterID"] != null)
                {
                    model.AuthorityFaterID = row["AuthorityFaterID"].ToString();
                }
                if (row["AuthorityFunction"] != null)
                {
                    model.AuthorityFunction = row["AuthorityFunction"].ToString();
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
            strSql.Append("select * ");
            strSql.Append(" FROM KNet_Sys_AuthorityTable ");
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
            strSql.Append(" ID,AuthorityName,AuthorityValue,AuthorityGroup,AuthorityFaterID ");
            strSql.Append(" FROM KNet_Sys_AuthorityTable ");
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
            strSql.Append("select count(1) FROM KNet_Sys_AuthorityTable ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from KNet_Sys_AuthorityTable T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
            parameters[0].Value = "KNet_Sys_AuthorityTable";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:PB_Knowledge_Manage
    /// </summary>
    public partial class PB_Knowledge_Manage
    {
        public PB_Knowledge_Manage()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PKM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PB_Knowledge_Manage");
            strSql.Append(" where PKM_ID=@PKM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PKM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PKM_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Knowledge_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PB_Knowledge_Manage(");
            strSql.Append("PKM_ID,PKM_Code,PKM_Title,PKM_ProductsBarCode,PKM_CustomerValue,PKM_Type,PKM_State,PKM_Problem,PKM_Solution,PKM_Del,PKM_Creator,PKM_CTime,PKM_Mender,PKM_MTime)");
            strSql.Append(" values (");
            strSql.Append("@PKM_ID,@PKM_Code,@PKM_Title,@PKM_ProductsBarCode,@PKM_CustomerValue,@PKM_Type,@PKM_State,@PKM_Problem,@PKM_Solution,@PKM_Del,@PKM_Creator,@PKM_CTime,@PKM_Mender,@PKM_MTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@PKM_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PKM_Code", SqlDbType.VarChar,50),
					new SqlParameter("@PKM_Title", SqlDbType.VarChar,250),
					new SqlParameter("@PKM_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@PKM_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@PKM_Type", SqlDbType.VarChar,50),
					new SqlParameter("@PKM_State", SqlDbType.VarChar,50),
					new SqlParameter("@PKM_Problem", SqlDbType.VarChar,1000),
					new SqlParameter("@PKM_Solution", SqlDbType.VarChar,2000),
					new SqlParameter("@PKM_Del", SqlDbType.Int,4),
					new SqlParameter("@PKM_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@PKM_CTime", SqlDbType.DateTime),
					new SqlParameter("@PKM_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@PKM_MTime", SqlDbType.DateTime)};
            parameters[0].Value = model.PKM_ID;
            parameters[1].Value = model.PKM_Code;
            parameters[2].Value = model.PKM_Title;
            parameters[3].Value = model.PKM_ProductsBarCode;
            parameters[4].Value = model.PKM_CustomerValue;
            parameters[5].Value = model.PKM_Type;
            parameters[6].Value = model.PKM_State;
            parameters[7].Value = model.PKM_Problem;
            parameters[8].Value = model.PKM_Solution;
            parameters[9].Value = model.PKM_Del;
            parameters[10].Value = model.PKM_Creator;
            parameters[11].Value = model.PKM_CTime;
            parameters[12].Value = model.PKM_Mender;
            parameters[13].Value = model.PKM_MTime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Knowledge_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PB_Knowledge_Manage set ");
            strSql.Append("PKM_Code=@PKM_Code,");
            strSql.Append("PKM_Title=@PKM_Title,");
            strSql.Append("PKM_ProductsBarCode=@PKM_ProductsBarCode,");
            strSql.Append("PKM_CustomerValue=@PKM_CustomerValue,");
            strSql.Append("PKM_Type=@PKM_Type,");
            strSql.Append("PKM_State=@PKM_State,");
            strSql.Append("PKM_Problem=@PKM_Problem,");
            strSql.Append("PKM_Solution=@PKM_Solution,");
            strSql.Append("PKM_Del=@PKM_Del,");
            strSql.Append("PKM_Creator=@PKM_Creator,");
            strSql.Append("PKM_CTime=@PKM_CTime,");
            strSql.Append("PKM_Mender=@PKM_Mender,");
            strSql.Append("PKM_MTime=@PKM_MTime");
            strSql.Append(" where PKM_ID=@PKM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PKM_Code", SqlDbType.VarChar,50),
					new SqlParameter("@PKM_Title", SqlDbType.VarChar,250),
					new SqlParameter("@PKM_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@PKM_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@PKM_Type", SqlDbType.VarChar,50),
					new SqlParameter("@PKM_State", SqlDbType.VarChar,50),
					new SqlParameter("@PKM_Problem", SqlDbType.VarChar,1000),
					new SqlParameter("@PKM_Solution", SqlDbType.VarChar,2000),
					new SqlParameter("@PKM_Del", SqlDbType.Int,4),
					new SqlParameter("@PKM_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@PKM_CTime", SqlDbType.DateTime),
					new SqlParameter("@PKM_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@PKM_MTime", SqlDbType.DateTime),
					new SqlParameter("@PKM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PKM_Code;
            parameters[1].Value = model.PKM_Title;
            parameters[2].Value = model.PKM_ProductsBarCode;
            parameters[3].Value = model.PKM_CustomerValue;
            parameters[4].Value = model.PKM_Type;
            parameters[5].Value = model.PKM_State;
            parameters[6].Value = model.PKM_Problem;
            parameters[7].Value = model.PKM_Solution;
            parameters[8].Value = model.PKM_Del;
            parameters[9].Value = model.PKM_Creator;
            parameters[10].Value = model.PKM_CTime;
            parameters[11].Value = model.PKM_Mender;
            parameters[12].Value = model.PKM_MTime;
            parameters[13].Value = model.PKM_ID;

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
        public bool Delete(string PKM_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Knowledge_Manage ");
            strSql.Append(" where PKM_ID=@PKM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PKM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PKM_ID;

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
        public bool DeleteList(string PKM_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Knowledge_Manage ");
            strSql.Append(" where PKM_ID in (" + PKM_IDlist + ")  ");
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
        public KNet.Model.PB_Knowledge_Manage GetModel(string PKM_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PKM_ID,PKM_Code,PKM_Title,PKM_ProductsBarCode,PKM_CustomerValue,PKM_Type,PKM_State,PKM_Problem,PKM_Solution,PKM_Del,PKM_Creator,PKM_CTime,PKM_Mender,PKM_MTime from PB_Knowledge_Manage ");
            strSql.Append(" where PKM_ID=@PKM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PKM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PKM_ID;

            KNet.Model.PB_Knowledge_Manage model = new KNet.Model.PB_Knowledge_Manage();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PKM_ID"] != null && ds.Tables[0].Rows[0]["PKM_ID"].ToString() != "")
                {
                    model.PKM_ID = ds.Tables[0].Rows[0]["PKM_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PKM_Code"] != null && ds.Tables[0].Rows[0]["PKM_Code"].ToString() != "")
                {
                    model.PKM_Code = ds.Tables[0].Rows[0]["PKM_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PKM_Title"] != null && ds.Tables[0].Rows[0]["PKM_Title"].ToString() != "")
                {
                    model.PKM_Title = ds.Tables[0].Rows[0]["PKM_Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PKM_ProductsBarCode"] != null && ds.Tables[0].Rows[0]["PKM_ProductsBarCode"].ToString() != "")
                {
                    model.PKM_ProductsBarCode = ds.Tables[0].Rows[0]["PKM_ProductsBarCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PKM_CustomerValue"] != null && ds.Tables[0].Rows[0]["PKM_CustomerValue"].ToString() != "")
                {
                    model.PKM_CustomerValue = ds.Tables[0].Rows[0]["PKM_CustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PKM_Type"] != null && ds.Tables[0].Rows[0]["PKM_Type"].ToString() != "")
                {
                    model.PKM_Type = ds.Tables[0].Rows[0]["PKM_Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PKM_State"] != null && ds.Tables[0].Rows[0]["PKM_State"].ToString() != "")
                {
                    model.PKM_State = ds.Tables[0].Rows[0]["PKM_State"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PKM_Problem"] != null && ds.Tables[0].Rows[0]["PKM_Problem"].ToString() != "")
                {
                    model.PKM_Problem = ds.Tables[0].Rows[0]["PKM_Problem"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PKM_Solution"] != null && ds.Tables[0].Rows[0]["PKM_Solution"].ToString() != "")
                {
                    model.PKM_Solution = ds.Tables[0].Rows[0]["PKM_Solution"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PKM_Del"] != null && ds.Tables[0].Rows[0]["PKM_Del"].ToString() != "")
                {
                    model.PKM_Del = int.Parse(ds.Tables[0].Rows[0]["PKM_Del"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PKM_Creator"] != null && ds.Tables[0].Rows[0]["PKM_Creator"].ToString() != "")
                {
                    model.PKM_Creator = ds.Tables[0].Rows[0]["PKM_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PKM_CTime"] != null && ds.Tables[0].Rows[0]["PKM_CTime"].ToString() != "")
                {
                    model.PKM_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["PKM_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PKM_Mender"] != null && ds.Tables[0].Rows[0]["PKM_Mender"].ToString() != "")
                {
                    model.PKM_Mender = ds.Tables[0].Rows[0]["PKM_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PKM_MTime"] != null && ds.Tables[0].Rows[0]["PKM_MTime"].ToString() != "")
                {
                    model.PKM_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["PKM_MTime"].ToString());
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
            strSql.Append("select PKM_ID,PKM_Code,PKM_Title,PKM_ProductsBarCode,PKM_CustomerValue,PKM_Type,PKM_State,PKM_Problem,PKM_Solution,PKM_Del,PKM_Creator,PKM_CTime,PKM_Mender,PKM_MTime ");
            strSql.Append(" FROM PB_Knowledge_Manage ");
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
            strSql.Append(" PKM_ID,PKM_Code,PKM_Title,PKM_ProductsBarCode,PKM_CustomerValue,PKM_Type,PKM_State,PKM_Problem,PKM_Solution,PKM_Del,PKM_Creator,PKM_CTime,PKM_Mender,PKM_MTime ");
            strSql.Append(" FROM PB_Knowledge_Manage ");
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
            parameters[0].Value = "PB_Knowledge_Manage";
            parameters[1].Value = "PKM_ID";
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


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Cg_Suppliers_Price
    /// </summary>
    public partial class Cg_Suppliers_Price
    {
        public Cg_Suppliers_Price()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CSP_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cg_Suppliers_Price");
            strSql.Append(" where CSP_ID=@CSP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CSP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CSP_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cg_Suppliers_Price model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cg_Suppliers_Price(");
            strSql.Append("CSP_ID,CSP_ProductsBarCode,CSP_IsStop,CSP_ProductsMainType,CSP_SerchKey,CSP_State,CSP_ShPerson,CSP_Del,CSP_Creator,CSP_CTime,CSP_Mender,CSP_MTime)");
            strSql.Append(" values (");
            strSql.Append("@CSP_ID,@CSP_ProductsBarCode,@CSP_IsStop,@CSP_ProductsMainType,@CSP_SerchKey,@CSP_State,@CSP_ShPerson,@CSP_Del,@CSP_Creator,@CSP_CTime,@CSP_Mender,@CSP_MTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@CSP_ID", SqlDbType.VarChar,50),
					new SqlParameter("@CSP_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@CSP_IsStop", SqlDbType.Int,4),
					new SqlParameter("@CSP_ProductsMainType", SqlDbType.VarChar,50),
					new SqlParameter("@CSP_SerchKey", SqlDbType.VarChar,100),
					new SqlParameter("@CSP_State", SqlDbType.Int,4),
					new SqlParameter("@CSP_ShPerson", SqlDbType.VarChar,50),
					new SqlParameter("@CSP_Del", SqlDbType.Int,4),
					new SqlParameter("@CSP_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@CSP_CTime", SqlDbType.DateTime),
					new SqlParameter("@CSP_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@CSP_MTime", SqlDbType.DateTime)};
            parameters[0].Value = model.CSP_ID;
            parameters[1].Value = model.CSP_ProductsBarCode;
            parameters[2].Value = model.CSP_IsStop;
            parameters[3].Value = model.CSP_ProductsMainType;
            parameters[4].Value = model.CSP_SerchKey;
            parameters[5].Value = model.CSP_State;
            parameters[6].Value = model.CSP_ShPerson;
            parameters[7].Value = model.CSP_Del;
            parameters[8].Value = model.CSP_Creator;
            parameters[9].Value = model.CSP_CTime;
            parameters[10].Value = model.CSP_Mender;
            parameters[11].Value = model.CSP_MTime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cg_Suppliers_Price model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cg_Suppliers_Price set ");
            strSql.Append("CSP_ProductsBarCode=@CSP_ProductsBarCode,");
            strSql.Append("CSP_IsStop=@CSP_IsStop,");
            strSql.Append("CSP_ProductsMainType=@CSP_ProductsMainType,");
            strSql.Append("CSP_SerchKey=@CSP_SerchKey,");
            strSql.Append("CSP_State=@CSP_State,");
            strSql.Append("CSP_ShPerson=@CSP_ShPerson,");
            strSql.Append("CSP_Del=@CSP_Del,");
            strSql.Append("CSP_Creator=@CSP_Creator,");
            strSql.Append("CSP_CTime=@CSP_CTime,");
            strSql.Append("CSP_Mender=@CSP_Mender,");
            strSql.Append("CSP_MTime=@CSP_MTime");
            strSql.Append(" where CSP_ID=@CSP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CSP_ProductsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@CSP_IsStop", SqlDbType.Int,4),
					new SqlParameter("@CSP_ProductsMainType", SqlDbType.VarChar,50),
					new SqlParameter("@CSP_SerchKey", SqlDbType.VarChar,100),
					new SqlParameter("@CSP_State", SqlDbType.Int,4),
					new SqlParameter("@CSP_ShPerson", SqlDbType.VarChar,50),
					new SqlParameter("@CSP_Del", SqlDbType.Int,4),
					new SqlParameter("@CSP_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@CSP_CTime", SqlDbType.DateTime),
					new SqlParameter("@CSP_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@CSP_MTime", SqlDbType.DateTime),
					new SqlParameter("@CSP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CSP_ProductsBarCode;
            parameters[1].Value = model.CSP_IsStop;
            parameters[2].Value = model.CSP_ProductsMainType;
            parameters[3].Value = model.CSP_SerchKey;
            parameters[4].Value = model.CSP_State;
            parameters[5].Value = model.CSP_ShPerson;
            parameters[6].Value = model.CSP_Del;
            parameters[7].Value = model.CSP_Creator;
            parameters[8].Value = model.CSP_CTime;
            parameters[9].Value = model.CSP_Mender;
            parameters[10].Value = model.CSP_MTime;
            parameters[11].Value = model.CSP_ID;

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
        public bool Delete(string CSP_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cg_Suppliers_Price ");
            strSql.Append(" where CSP_ID=@CSP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CSP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CSP_ID;

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
        public bool DeleteList(string CSP_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cg_Suppliers_Price ");
            strSql.Append(" where CSP_ID in (" + CSP_IDlist + ")  ");
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
        public KNet.Model.Cg_Suppliers_Price GetModel(string CSP_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CSP_ID,CSP_ProductsBarCode,CSP_IsStop,CSP_ProductsMainType,CSP_SerchKey,CSP_State,CSP_ShPerson,CSP_Del,CSP_Creator,CSP_CTime,CSP_Mender,CSP_MTime from Cg_Suppliers_Price ");
            strSql.Append(" where CSP_ID=@CSP_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CSP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CSP_ID;

            KNet.Model.Cg_Suppliers_Price model = new KNet.Model.Cg_Suppliers_Price();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CSP_ID"] != null && ds.Tables[0].Rows[0]["CSP_ID"].ToString() != "")
                {
                    model.CSP_ID = ds.Tables[0].Rows[0]["CSP_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CSP_ProductsBarCode"] != null && ds.Tables[0].Rows[0]["CSP_ProductsBarCode"].ToString() != "")
                {
                    model.CSP_ProductsBarCode = ds.Tables[0].Rows[0]["CSP_ProductsBarCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CSP_IsStop"] != null && ds.Tables[0].Rows[0]["CSP_IsStop"].ToString() != "")
                {
                    model.CSP_IsStop = int.Parse(ds.Tables[0].Rows[0]["CSP_IsStop"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CSP_ProductsMainType"] != null && ds.Tables[0].Rows[0]["CSP_ProductsMainType"].ToString() != "")
                {
                    model.CSP_ProductsMainType = ds.Tables[0].Rows[0]["CSP_ProductsMainType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CSP_SerchKey"] != null && ds.Tables[0].Rows[0]["CSP_SerchKey"].ToString() != "")
                {
                    model.CSP_SerchKey = ds.Tables[0].Rows[0]["CSP_SerchKey"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CSP_State"] != null && ds.Tables[0].Rows[0]["CSP_State"].ToString() != "")
                {
                    model.CSP_State = int.Parse(ds.Tables[0].Rows[0]["CSP_State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CSP_ShPerson"] != null && ds.Tables[0].Rows[0]["CSP_ShPerson"].ToString() != "")
                {
                    model.CSP_ShPerson = ds.Tables[0].Rows[0]["CSP_ShPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CSP_Del"] != null && ds.Tables[0].Rows[0]["CSP_Del"].ToString() != "")
                {
                    model.CSP_Del = int.Parse(ds.Tables[0].Rows[0]["CSP_Del"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CSP_Creator"] != null && ds.Tables[0].Rows[0]["CSP_Creator"].ToString() != "")
                {
                    model.CSP_Creator = ds.Tables[0].Rows[0]["CSP_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CSP_CTime"] != null && ds.Tables[0].Rows[0]["CSP_CTime"].ToString() != "")
                {
                    model.CSP_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["CSP_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CSP_Mender"] != null && ds.Tables[0].Rows[0]["CSP_Mender"].ToString() != "")
                {
                    model.CSP_Mender = ds.Tables[0].Rows[0]["CSP_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CSP_MTime"] != null && ds.Tables[0].Rows[0]["CSP_MTime"].ToString() != "")
                {
                    model.CSP_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["CSP_MTime"].ToString());
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
            strSql.Append(" FROM Cg_Suppliers_Price a join v_TotalRCPirce b on a.CSP_ID=b.KPP_CgID ");
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
            strSql.Append(" CSP_ID,CSP_ProductsBarCode,CSP_IsStop,CSP_ProductsMainType,CSP_SerchKey,CSP_State,CSP_ShPerson,CSP_Del,CSP_Creator,CSP_CTime,CSP_Mender,CSP_MTime ");
            strSql.Append(" FROM Cg_Suppliers_Price ");
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
            parameters[0].Value = "Cg_Suppliers_Price";
            parameters[1].Value = "CSP_ID";
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


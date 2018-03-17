using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:KNet_Sales_Flow
    /// </summary>
    public partial class KNet_Sales_Flow
    {
        public KNet_Sales_Flow()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(KNet.Model.KNet_Sales_Flow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KNet_Sales_Flow");
            strSql.Append(" where KSF_ContractNo=@KSF_ContractNo and KSF_ShPerson=@KSF_ShPerson and KSF_Del='0' and KSF_State<>'4' ");
            SqlParameter[] parameters = {
					new SqlParameter("@KSF_ContractNo", SqlDbType.VarChar,50),
					new SqlParameter("@KSF_ShPerson", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KSF_ContractNo;
            parameters[1].Value = model.KSF_ShPerson;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sales_Flow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Sales_Flow(");
            strSql.Append("KSF_Detail,KSF_Date,KSF_ShPerson,KSF_State,KSF_ContractNo,KFS_Type,KFS_NextPerson,KFS_IsNextPerson,KFS_ReDate)");
            strSql.Append(" values (");
            strSql.Append("@KSF_Detail,@KSF_Date,@KSF_ShPerson,@KSF_State,@KSF_ContractNo,@KFS_Type,@KFS_NextPerson,@KFS_IsNextPerson,@KFS_ReDate)");
            SqlParameter[] parameters = {
					new SqlParameter("@KSF_Detail", SqlDbType.VarChar,2000),
					new SqlParameter("@KSF_Date", SqlDbType.DateTime),
					new SqlParameter("@KSF_ShPerson", SqlDbType.VarChar,50),
					new SqlParameter("@KSF_State", SqlDbType.Int,4),
					new SqlParameter("@KSF_ContractNo", SqlDbType.VarChar,50),
					new SqlParameter("@KFS_Type", SqlDbType.Int,4),
					new SqlParameter("@KFS_NextPerson", SqlDbType.VarChar,50),
					new SqlParameter("@KFS_IsNextPerson", SqlDbType.VarChar,1),
					new SqlParameter("@KFS_ReDate", SqlDbType.DateTime)};
            parameters[0].Value = model.KSF_Detail;
            parameters[1].Value = model.KSF_Date;
            parameters[2].Value = model.KSF_ShPerson;
            parameters[3].Value = model.KSF_State;
            parameters[4].Value = model.KSF_ContractNo;
            parameters[5].Value = model.KFS_Type;
            parameters[6].Value = model.KFS_NextPerson;
            parameters[7].Value = model.KFS_IsNextPerson;
            parameters[8].Value = model.KFS_ReDate;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.KNet_Sales_Flow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Sales_Flow set ");
            strSql.Append("KSF_Detail=@KSF_Detail,");
            strSql.Append("KSF_Date=@KSF_Date,");
            strSql.Append("KSF_ShPerson=@KSF_ShPerson,");
            strSql.Append("KSF_State=@KSF_State,");
            strSql.Append("KSF_ContractNo=@KSF_ContractNo,");
            strSql.Append("KFS_ReDate=@KFS_ReDate,");
            strSql.Append("KFS_Type=@KFS_Type");
            strSql.Append(" where KSF_ID=@KSF_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KSF_Detail", SqlDbType.VarChar,2000),
					new SqlParameter("@KSF_Date", SqlDbType.DateTime),
					new SqlParameter("@KSF_ShPerson", SqlDbType.VarChar,50),
					new SqlParameter("@KSF_State", SqlDbType.Int,4),
					new SqlParameter("@KSF_ContractNo", SqlDbType.VarChar,50),
					new SqlParameter("@KFS_ReDate", SqlDbType.DateTime),
					new SqlParameter("@KFS_Type", SqlDbType.Int,4),
					new SqlParameter("@KSF_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KSF_Detail;
            parameters[1].Value = model.KSF_Date;
            parameters[2].Value = model.KSF_ShPerson;
            parameters[3].Value = model.KSF_State;
            parameters[4].Value = model.KSF_ContractNo;
            parameters[5].Value = model.KFS_ReDate;
            parameters[6].Value = model.KFS_Type;
            parameters[7].Value = model.KSF_ID;

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
        public bool Delete(string KSF_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_Sales_Flow ");
            strSql.Append(" where KSF_ID=@KSF_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KSF_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = KSF_ID;

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
        public bool DeleteList(string KSF_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_Sales_Flow ");
            strSql.Append(" where KSF_ID in (" + KSF_IDlist + ")  ");
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
        public KNet.Model.KNet_Sales_Flow GetModel(string KSF_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 KSF_ID,KSF_Detail,KSF_Date,KSF_ShPerson,KSF_State,KSF_ContractNo,KFS_Type from KNet_Sales_Flow ");
            strSql.Append(" where KSF_ID=@KSF_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KSF_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = KSF_ID;

            KNet.Model.KNet_Sales_Flow model = new KNet.Model.KNet_Sales_Flow();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["KSF_ID"] != null && ds.Tables[0].Rows[0]["KSF_ID"].ToString() != "")
                {
                    model.KSF_ID = ds.Tables[0].Rows[0]["KSF_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSF_Detail"] != null && ds.Tables[0].Rows[0]["KSF_Detail"].ToString() != "")
                {
                    model.KSF_Detail = ds.Tables[0].Rows[0]["KSF_Detail"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSF_Date"] != null && ds.Tables[0].Rows[0]["KSF_Date"].ToString() != "")
                {
                    model.KSF_Date = DateTime.Parse(ds.Tables[0].Rows[0]["KSF_Date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KSF_ShPerson"] != null && ds.Tables[0].Rows[0]["KSF_ShPerson"].ToString() != "")
                {
                    model.KSF_ShPerson = ds.Tables[0].Rows[0]["KSF_ShPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KSF_State"] != null && ds.Tables[0].Rows[0]["KSF_State"].ToString() != "")
                {
                    model.KSF_State = int.Parse(ds.Tables[0].Rows[0]["KSF_State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KSF_ContractNo"] != null && ds.Tables[0].Rows[0]["KSF_ContractNo"].ToString() != "")
                {
                    model.KSF_ContractNo = ds.Tables[0].Rows[0]["KSF_ContractNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KFS_Type"] != null && ds.Tables[0].Rows[0]["KFS_Type"].ToString() != "")
                {
                    model.KFS_Type = int.Parse(ds.Tables[0].Rows[0]["KFS_Type"].ToString());
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
            strSql.Append(" FROM KNet_Sales_Flow join Knet_Resource_Staff on  StaffNo=KSF_SHPerson");
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
            strSql.Append(" KSF_ID,KSF_Detail,KSF_Date,KSF_ShPerson,KSF_State,KSF_ContractNo,KFS_Type ");
            strSql.Append(" FROM KNet_Sales_Flow ");
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
            parameters[0].Value = "KNet_Sales_Flow";
            parameters[1].Value = "KSF_ID";
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


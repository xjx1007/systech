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
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Xs_Contract_ViewPerson
    /// </summary>
    public partial class Xs_Contract_ViewPerson
    {
        public Xs_Contract_ViewPerson()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XCV_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Xs_Contract_ViewPerson");
            strSql.Append(" where XCV_ID=@XCV_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCV_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XCV_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Contract_ViewPerson model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Xs_Contract_ViewPerson(");
            strSql.Append("XCV_ID,XCV_ContractNo,XCV_Person,XCV_Time,XCV_State)");
            strSql.Append(" values (");
            strSql.Append("@XCV_ID,@XCV_ContractNo,@XCV_Person,@XCV_Time,@XCV_State)");
            SqlParameter[] parameters = {
					new SqlParameter("@XCV_ID", SqlDbType.VarChar,50),
					new SqlParameter("@XCV_ContractNo", SqlDbType.VarChar,50),
					new SqlParameter("@XCV_Person", SqlDbType.VarChar,50),
					new SqlParameter("@XCV_Time", SqlDbType.DateTime),
					new SqlParameter("@XCV_State", SqlDbType.VarChar,50)};
            parameters[0].Value = model.XCV_ID;
            parameters[1].Value = model.XCV_ContractNo;
            parameters[2].Value = model.XCV_Person;
            parameters[3].Value = model.XCV_Time;
            parameters[4].Value = model.XCV_State;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Contract_ViewPerson model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Xs_Contract_ViewPerson set ");
            strSql.Append("XCV_ContractNo=@XCV_ContractNo,");
            strSql.Append("XCV_Person=@XCV_Person,");
            strSql.Append("XCV_Time=@XCV_Time,");
            strSql.Append("XCV_State=@XCV_State");
            strSql.Append(" where XCV_ID=@XCV_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCV_ContractNo", SqlDbType.VarChar,50),
					new SqlParameter("@XCV_Person", SqlDbType.VarChar,50),
					new SqlParameter("@XCV_Time", SqlDbType.VarChar,50),
					new SqlParameter("@XCV_State", SqlDbType.VarChar,50),
					new SqlParameter("@XCV_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.XCV_ContractNo;
            parameters[1].Value = model.XCV_Person;
            parameters[2].Value = model.XCV_Time;
            parameters[3].Value = model.XCV_State;
            parameters[4].Value = model.XCV_ID;

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
        /// 更新一条数据
        /// </summary>
        public void UpdateDel(KNet.Model.Xs_Contract_ViewPerson model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Xs_Contract_ViewPerson set ");
            strSql.Append("XCV_Del=@XCV_Del");
            strSql.Append(" where XCV_ContractNo=@XCV_ContractNo and XCV_Person=@XCV_Person ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCV_Del", SqlDbType.Int),
					new SqlParameter("@XCV_ContractNo", SqlDbType.VarChar,50),
					new SqlParameter("@XCV_Person", SqlDbType.VarChar,50)};
            parameters[0].Value = model.XCV_Del;
            parameters[1].Value = model.XCV_ContractNo;
            parameters[2].Value = model.XCV_Person;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string XCV_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Contract_ViewPerson ");
            strSql.Append(" where XCV_ID=@XCV_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCV_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XCV_ID;

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
        public bool DeleteList(string XCV_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Contract_ViewPerson ");
            strSql.Append(" where XCV_ID in (" + XCV_IDlist + ")  ");
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
        public KNet.Model.Xs_Contract_ViewPerson GetModel(string XCV_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 XCV_ID,XCV_ContractNo,XCV_Person,XCV_Time,XCV_State from Xs_Contract_ViewPerson ");
            strSql.Append(" where XCV_ID=@XCV_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCV_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XCV_ID;

            KNet.Model.Xs_Contract_ViewPerson model = new KNet.Model.Xs_Contract_ViewPerson();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["XCV_ID"] != null && ds.Tables[0].Rows[0]["XCV_ID"].ToString() != "")
                {
                    model.XCV_ID = ds.Tables[0].Rows[0]["XCV_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XCV_ContractNo"] != null && ds.Tables[0].Rows[0]["XCV_ContractNo"].ToString() != "")
                {
                    model.XCV_ContractNo = ds.Tables[0].Rows[0]["XCV_ContractNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XCV_Person"] != null && ds.Tables[0].Rows[0]["XCV_Person"].ToString() != "")
                {
                    model.XCV_Person = ds.Tables[0].Rows[0]["XCV_Person"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XCV_Time"] != null && ds.Tables[0].Rows[0]["XCV_Time"].ToString() != "")
                {
                    model.XCV_Time = DateTime.Parse(ds.Tables[0].Rows[0]["XCV_Time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XCV_State"] != null && ds.Tables[0].Rows[0]["XCV_State"].ToString() != "")
                {
                    model.XCV_State = ds.Tables[0].Rows[0]["XCV_State"].ToString();
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
            strSql.Append("select XCV_ID,XCV_ContractNo,XCV_Person,XCV_Time,XCV_State ");
            strSql.Append(" FROM Xs_Contract_ViewPerson ");
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
            strSql.Append(" XCV_ID,XCV_ContractNo,XCV_Person,XCV_Time,XCV_State ");
            strSql.Append(" FROM Xs_Contract_ViewPerson ");
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
            parameters[0].Value = "Xs_Contract_ViewPerson";
            parameters[1].Value = "XCV_ID";
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


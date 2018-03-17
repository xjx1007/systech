using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using KNet.DBUtility;
using System.Text;
using System.Data.SqlClient;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:KNet_ContractDate
    /// </summary>
    public partial class KNet_ContractDate
    {
        public KNet_ContractDate()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int KC_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KNet_ContractDate");
            strSql.Append(" where KC_ID=@KC_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@KC_ID", SqlDbType.Int,4)
};
            parameters[0].Value = KC_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(KNet.Model.KNet_ContractDate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_ContractDate(");
            strSql.Append("KC_ContractNo,KC_OldDate,KC_Date,KC_Type,KC_AddDate,KC_AddPerson)");
            strSql.Append(" values (");
            strSql.Append("@KC_ContractNo,@KC_OldDate,@KC_Date,@KC_Type,@KC_AddDate,@KC_AddPerson)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@KC_ContractNo", SqlDbType.VarChar,50),
					new SqlParameter("@KC_OldDate", SqlDbType.DateTime),
					new SqlParameter("@KC_Date", SqlDbType.DateTime),
					new SqlParameter("@KC_Type", SqlDbType.Int,4),
					new SqlParameter("@KC_AddDate", SqlDbType.DateTime),
					new SqlParameter("@KC_AddPerson", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KC_ContractNo;
            parameters[1].Value = model.KC_OldDate;
            parameters[2].Value = model.KC_Date;
            parameters[3].Value = model.KC_Type;
            parameters[4].Value = model.KC_AddDate;
            parameters[5].Value = model.KC_AddPerson;

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
        public bool Update(KNet.Model.KNet_ContractDate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_ContractDate set ");
            strSql.Append("KC_ContractNo=@KC_ContractNo,");
            strSql.Append("KC_Date=@KC_Date,");
            strSql.Append("KC_Type=@KC_Type,");
            strSql.Append("KC_AddDate=@KC_AddDate,");
            strSql.Append("KC_AddPerson=@KC_AddPerson");
            strSql.Append(" where KC_ID=@KC_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@KC_ContractNo", SqlDbType.VarChar,50),
					new SqlParameter("@KC_Date", SqlDbType.DateTime),
					new SqlParameter("@KC_Type", SqlDbType.Int,4),
					new SqlParameter("@KC_AddDate", SqlDbType.DateTime),
					new SqlParameter("@KC_AddPerson", SqlDbType.VarChar,50),
					new SqlParameter("@KC_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.KC_ContractNo;
            parameters[1].Value = model.KC_Date;
            parameters[2].Value = model.KC_Type;
            parameters[3].Value = model.KC_AddDate;
            parameters[4].Value = model.KC_AddPerson;
            parameters[5].Value = model.KC_ID;

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
        public bool Delete(int KC_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_ContractDate ");
            strSql.Append(" where KC_ID=@KC_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@KC_ID", SqlDbType.Int,4)
};
            parameters[0].Value = KC_ID;

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
        public bool DeleteList(string KC_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_ContractDate ");
            strSql.Append(" where KC_ID in (" + KC_IDlist + ")  ");
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
        /// 得到原交货日期
        /// </summary>
        public string GetOldDate(string s_ContractNo,int i_Type)
        {
            string s_Return = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select top 1 KC_OldDate from KNet_ContractDate ");
            strSql.Append(" where KC_ContractNo =@KC_ContractNo and KC_Type =@KC_Type Order by KC_AddDate ");
            SqlParameter[] parameters = {
                
					new SqlParameter("@KC_Type", SqlDbType.Int,1),
					new SqlParameter("@KC_ContractNo", SqlDbType.VarChar,50)
};
            parameters[0].Value = i_Type;
            parameters[1].Value = s_ContractNo;

            KNet.Model.KNet_ContractDate model = new KNet.Model.KNet_ContractDate();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                s_Return = ds.Tables[0].Rows[0][0].ToString();
            }
            return s_Return;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_ContractDate GetModel(int KC_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 KC_ID,KC_ContractNo,KC_Date,KC_Type,KC_AddDate,KC_AddPerson from KNet_ContractDate ");
            strSql.Append(" where KC_ID=@KC_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@KC_ID", SqlDbType.Int,4)
};
            parameters[0].Value = KC_ID;

            KNet.Model.KNet_ContractDate model = new KNet.Model.KNet_ContractDate();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["KC_ID"] != null && ds.Tables[0].Rows[0]["KC_ID"].ToString() != "")
                {
                    model.KC_ID = int.Parse(ds.Tables[0].Rows[0]["KC_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KC_ContractNo"] != null && ds.Tables[0].Rows[0]["KC_ContractNo"].ToString() != "")
                {
                    model.KC_ContractNo = ds.Tables[0].Rows[0]["KC_ContractNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KC_Date"] != null && ds.Tables[0].Rows[0]["KC_Date"].ToString() != "")
                {
                    model.KC_Date = DateTime.Parse(ds.Tables[0].Rows[0]["KC_Date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KC_Type"] != null && ds.Tables[0].Rows[0]["KC_Type"].ToString() != "")
                {
                    model.KC_Type = int.Parse(ds.Tables[0].Rows[0]["KC_Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KC_AddDate"] != null && ds.Tables[0].Rows[0]["KC_AddDate"].ToString() != "")
                {
                    model.KC_AddDate = DateTime.Parse(ds.Tables[0].Rows[0]["KC_AddDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KC_AddPerson"] != null && ds.Tables[0].Rows[0]["KC_AddPerson"].ToString() != "")
                {
                    model.KC_AddPerson = ds.Tables[0].Rows[0]["KC_AddPerson"].ToString();
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
            strSql.Append("select KC_ID,KC_ContractNo,KC_Date,KC_Type,KC_AddDate,KC_AddPerson ");
            strSql.Append(" FROM KNet_ContractDate ");
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
            strSql.Append(" KC_ID,KC_ContractNo,KC_Date,KC_Type,KC_AddDate,KC_AddPerson ");
            strSql.Append(" FROM KNet_ContractDate ");
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
            parameters[0].Value = "KNet_ContractDate";
            parameters[1].Value = "KC_ID";
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
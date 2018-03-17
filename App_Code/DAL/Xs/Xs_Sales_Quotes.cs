using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Xs_Sales_Quotes
    /// </summary>
    public partial class Xs_Sales_Quotes
    {
        public Xs_Sales_Quotes()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XSQ_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Xs_Sales_Quotes");
            strSql.Append(" where XSQ_ID=@XSQ_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XSQ_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XSQ_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string GetLastCode()
        {
            string s_Return = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 XSQ_Code from Xs_Sales_Quotes");
            strSql.Append(" where XSQ_Del='0'  order by XSQ_Code desc");

            DataSet Dts_Table = DbHelperSQL.Query(strSql.ToString());
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                s_Return = Dts_Table.Tables[0].Rows[0][0].ToString();
            }
            return s_Return;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Sales_Quotes model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Xs_Sales_Quotes(");
            strSql.Append("XSQ_ID,XSQ_Code,XSQ_SalesChance,XSQ_Name,XSQ_Step,XSQ_STime,XSQ_CustomerValue,XSQ_LinkMan,XSQ_DutyPerson,XSQ_Payment,XSQ_Remarks,XSQ_CTime,XSQ_Creator)");
            strSql.Append(" values (");
            strSql.Append("@XSQ_ID,@XSQ_Code,@XSQ_SalesChance,@XSQ_Name,@XSQ_Step,@XSQ_STime,@XSQ_CustomerValue,@XSQ_LinkMan,@XSQ_DutyPerson,@XSQ_Payment,@XSQ_Remarks,@XSQ_CTime,@XSQ_Creator)");
            SqlParameter[] parameters = {
					new SqlParameter("@XSQ_ID", SqlDbType.VarChar,50),
					new SqlParameter("@XSQ_Code", SqlDbType.VarChar,50),
					new SqlParameter("@XSQ_SalesChance", SqlDbType.VarChar,50),
					new SqlParameter("@XSQ_Name", SqlDbType.VarChar,50),
					new SqlParameter("@XSQ_Step", SqlDbType.VarChar,50),
					new SqlParameter("@XSQ_STime", SqlDbType.DateTime),
					new SqlParameter("@XSQ_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@XSQ_LinkMan", SqlDbType.VarChar,50),
					new SqlParameter("@XSQ_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@XSQ_Payment", SqlDbType.VarChar,500),
					new SqlParameter("@XSQ_Remarks", SqlDbType.VarChar,500),
					new SqlParameter("@XSQ_CTime", SqlDbType.DateTime),
					new SqlParameter("@XSQ_Creator", SqlDbType.VarChar,50),};
            parameters[0].Value = model.XSQ_ID;
            parameters[1].Value = model.XSQ_Code;
            parameters[2].Value = model.XSQ_SalesChance;
            parameters[3].Value = model.XSQ_Name;
            parameters[4].Value = model.XSQ_Step;
            parameters[5].Value = model.XSQ_STime;
            parameters[6].Value = model.XSQ_CustomerValue;
            parameters[7].Value = model.XSQ_LinkMan;
            parameters[8].Value = model.XSQ_DutyPerson;
            parameters[9].Value = model.XSQ_Payment;
            parameters[10].Value = model.XSQ_Remarks;
            parameters[11].Value = model.XSQ_CTime;
            parameters[12].Value = model.XSQ_Creator;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Sales_Quotes model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Xs_Sales_Quotes set ");
            strSql.Append("XSQ_Code=@XSQ_Code,");
            strSql.Append("XSQ_SalesChance=@XSQ_SalesChance,");
            strSql.Append("XSQ_Name=@XSQ_Name,");
            strSql.Append("XSQ_Step=@XSQ_Step,");
            strSql.Append("XSQ_STime=@XSQ_STime,");
            strSql.Append("XSQ_CustomerValue=@XSQ_CustomerValue,");
            strSql.Append("XSQ_LinkMan=@XSQ_LinkMan,");
            strSql.Append("XSQ_DutyPerson=@XSQ_DutyPerson,");
            strSql.Append("XSQ_Payment=@XSQ_Payment,");
            strSql.Append("XSQ_Remarks=@XSQ_Remarks,");
            strSql.Append("XSQ_Mender=@XSQ_Mender,");
            strSql.Append("XSQ_MTime=@XSQ_MTime");
            strSql.Append(" where XSQ_ID=@XSQ_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XSQ_Code", SqlDbType.VarChar,50),
					new SqlParameter("@XSQ_SalesChance", SqlDbType.VarChar,50),
					new SqlParameter("@XSQ_Name", SqlDbType.VarChar,50),
					new SqlParameter("@XSQ_Step", SqlDbType.VarChar,50),
					new SqlParameter("@XSQ_STime", SqlDbType.DateTime),
					new SqlParameter("@XSQ_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@XSQ_LinkMan", SqlDbType.VarChar,50),
					new SqlParameter("@XSQ_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@XSQ_Payment", SqlDbType.VarChar,500),
					new SqlParameter("@XSQ_Remarks", SqlDbType.VarChar,500),
					new SqlParameter("@XSQ_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@XSQ_MTime", SqlDbType.VarChar,50),
					new SqlParameter("@XSQ_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.XSQ_Code;
            parameters[1].Value = model.XSQ_SalesChance;
            parameters[2].Value = model.XSQ_Name;
            parameters[3].Value = model.XSQ_Step;
            parameters[4].Value = model.XSQ_STime;
            parameters[5].Value = model.XSQ_CustomerValue;
            parameters[6].Value = model.XSQ_LinkMan;
            parameters[7].Value = model.XSQ_DutyPerson;
            parameters[8].Value = model.XSQ_Payment;
            parameters[9].Value = model.XSQ_Remarks;
            parameters[10].Value = model.XSQ_Mender;
            parameters[11].Value = model.XSQ_MTime;
            parameters[12].Value = model.XSQ_ID;

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
        public bool Delete(string XSQ_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Sales_Quotes ");
            strSql.Append(" where XSQ_ID=@XSQ_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XSQ_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XSQ_ID;

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
        public bool DeleteList(string XSQ_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Sales_Quotes ");
            strSql.Append(" where XSQ_ID in (" + XSQ_IDlist + ")  ");
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
        public KNet.Model.Xs_Sales_Quotes GetModel(string XSQ_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Xs_Sales_Quotes ");
            strSql.Append(" where XSQ_ID=@XSQ_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@XSQ_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = XSQ_ID;

            KNet.Model.Xs_Sales_Quotes model = new KNet.Model.Xs_Sales_Quotes();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["XSQ_ID"] != null && ds.Tables[0].Rows[0]["XSQ_ID"].ToString() != "")
                {
                    model.XSQ_ID = ds.Tables[0].Rows[0]["XSQ_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSQ_Code"] != null && ds.Tables[0].Rows[0]["XSQ_Code"].ToString() != "")
                {
                    model.XSQ_Code = ds.Tables[0].Rows[0]["XSQ_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSQ_SalesChance"] != null && ds.Tables[0].Rows[0]["XSQ_SalesChance"].ToString() != "")
                {
                    model.XSQ_SalesChance = ds.Tables[0].Rows[0]["XSQ_SalesChance"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSQ_Name"] != null && ds.Tables[0].Rows[0]["XSQ_Name"].ToString() != "")
                {
                    model.XSQ_Name = ds.Tables[0].Rows[0]["XSQ_Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSQ_Step"] != null && ds.Tables[0].Rows[0]["XSQ_Step"].ToString() != "")
                {
                    model.XSQ_Step = ds.Tables[0].Rows[0]["XSQ_Step"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSQ_STime"] != null && ds.Tables[0].Rows[0]["XSQ_STime"].ToString() != "")
                {
                    model.XSQ_STime = DateTime.Parse(ds.Tables[0].Rows[0]["XSQ_STime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XSQ_CustomerValue"] != null && ds.Tables[0].Rows[0]["XSQ_CustomerValue"].ToString() != "")
                {
                    model.XSQ_CustomerValue = ds.Tables[0].Rows[0]["XSQ_CustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSQ_LinkMan"] != null && ds.Tables[0].Rows[0]["XSQ_LinkMan"].ToString() != "")
                {
                    model.XSQ_LinkMan = ds.Tables[0].Rows[0]["XSQ_LinkMan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSQ_DutyPerson"] != null && ds.Tables[0].Rows[0]["XSQ_DutyPerson"].ToString() != "")
                {
                    model.XSQ_DutyPerson = ds.Tables[0].Rows[0]["XSQ_DutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSQ_Payment"] != null && ds.Tables[0].Rows[0]["XSQ_Payment"].ToString() != "")
                {
                    model.XSQ_Payment = ds.Tables[0].Rows[0]["XSQ_Payment"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSQ_Remarks"] != null && ds.Tables[0].Rows[0]["XSQ_Remarks"].ToString() != "")
                {
                    model.XSQ_Remarks = ds.Tables[0].Rows[0]["XSQ_Remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSQ_CTime"] != null && ds.Tables[0].Rows[0]["XSQ_CTime"].ToString() != "")
                {
                    model.XSQ_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["XSQ_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XSQ_Creator"] != null && ds.Tables[0].Rows[0]["XSQ_Creator"].ToString() != "")
                {
                    model.XSQ_Creator = ds.Tables[0].Rows[0]["XSQ_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSQ_Mender"] != null && ds.Tables[0].Rows[0]["XSQ_Mender"].ToString() != "")
                {
                    model.XSQ_Mender = ds.Tables[0].Rows[0]["XSQ_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSQ_MTime"] != null && ds.Tables[0].Rows[0]["XSQ_MTime"].ToString() != "")
                {
                    model.XSQ_MTime = ds.Tables[0].Rows[0]["XSQ_MTime"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XSQ_Del"] != null && ds.Tables[0].Rows[0]["XSQ_Del"].ToString() != "")
                {
                    model.XSQ_Del = int.Parse(ds.Tables[0].Rows[0]["XSQ_Del"].ToString());
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
            strSql.Append(" FROM Xs_Sales_Quotes ");
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
            strSql.Append(" * ");
            strSql.Append(" FROM Xs_Sales_Quotes ");
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
            parameters[0].Value = "Xs_Sales_Quotes";
            parameters[1].Value = "XSQ_ID";
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


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Xs_Customer_Cares
    /// </summary>
    public partial class Xs_Customer_Cares
    {
        public Xs_Customer_Cares()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XCC_Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Xs_Customer_Cares");
            strSql.Append(" where XCC_Code=@XCC_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCC_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = XCC_Code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Customer_Cares model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Xs_Customer_Cares(");
            strSql.Append("XCC_Code,XCC_Topic,XCC_Stime,XCC_CustomerValue,XCC_LinkMan,XCC_DutyPerson,XCC_CareTypes,XCC_CareDetails,XCC_CustomerDetails,XCC_Remarks,XCC_Creator,XCC_CTime,XCC_Mender,XCC_MTime)");
            strSql.Append(" values (");
            strSql.Append("@XCC_Code,@XCC_Topic,@XCC_Stime,@XCC_CustomerValue,@XCC_LinkMan,@XCC_DutyPerson,@XCC_CareTypes,@XCC_CareDetails,@XCC_CustomerDetails,@XCC_Remarks,@XCC_Creator,@XCC_CTime,@XCC_Mender,@XCC_MTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@XCC_Code", SqlDbType.VarChar,50),
					new SqlParameter("@XCC_Topic", SqlDbType.VarChar,100),
					new SqlParameter("@XCC_Stime", SqlDbType.DateTime),
					new SqlParameter("@XCC_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@XCC_LinkMan", SqlDbType.VarChar,50),
					new SqlParameter("@XCC_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@XCC_CareTypes", SqlDbType.VarChar,3),
					new SqlParameter("@XCC_CareDetails", SqlDbType.VarChar,300),
					new SqlParameter("@XCC_CustomerDetails", SqlDbType.VarChar,300),
					new SqlParameter("@XCC_Remarks", SqlDbType.VarChar,300),
					new SqlParameter("@XCC_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@XCC_CTime", SqlDbType.DateTime),
					new SqlParameter("@XCC_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@XCC_MTime", SqlDbType.DateTime)};
            parameters[0].Value = model.XCC_Code;
            parameters[1].Value = model.XCC_Topic;
            parameters[2].Value = model.XCC_Stime;
            parameters[3].Value = model.XCC_CustomerValue;
            parameters[4].Value = model.XCC_LinkMan;
            parameters[5].Value = model.XCC_DutyPerson;
            parameters[6].Value = model.XCC_CareTypes;
            parameters[7].Value = model.XCC_CareDetails;
            parameters[8].Value = model.XCC_CustomerDetails;
            parameters[9].Value = model.XCC_Remarks;
            parameters[10].Value = model.XCC_Creator;
            parameters[11].Value = model.XCC_CTime;
            parameters[12].Value = model.XCC_Mender;
            parameters[13].Value = model.XCC_MTime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Customer_Cares model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Xs_Customer_Cares set ");
            strSql.Append("XCC_Topic=@XCC_Topic,");
            strSql.Append("XCC_Stime=@XCC_Stime,");
            strSql.Append("XCC_CustomerValue=@XCC_CustomerValue,");
            strSql.Append("XCC_LinkMan=@XCC_LinkMan,");
            strSql.Append("XCC_DutyPerson=@XCC_DutyPerson,");
            strSql.Append("XCC_CareTypes=@XCC_CareTypes,");
            strSql.Append("XCC_CareDetails=@XCC_CareDetails,");
            strSql.Append("XCC_CustomerDetails=@XCC_CustomerDetails,");
            strSql.Append("XCC_Remarks=@XCC_Remarks,");
            strSql.Append("XCC_Mender=@XCC_Mender,");
            strSql.Append("XCC_MTime=@XCC_MTime");
            strSql.Append(" where XCC_Code=@XCC_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCC_Topic", SqlDbType.VarChar,100),
					new SqlParameter("@XCC_Stime", SqlDbType.DateTime),
					new SqlParameter("@XCC_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@XCC_LinkMan", SqlDbType.VarChar,50),
					new SqlParameter("@XCC_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@XCC_CareTypes", SqlDbType.VarChar,3),
					new SqlParameter("@XCC_CareDetails", SqlDbType.VarChar,300),
					new SqlParameter("@XCC_CustomerDetails", SqlDbType.VarChar,300),
					new SqlParameter("@XCC_Remarks", SqlDbType.VarChar,300),
					new SqlParameter("@XCC_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@XCC_MTime", SqlDbType.DateTime),
					new SqlParameter("@XCC_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = model.XCC_Topic;
            parameters[1].Value = model.XCC_Stime;
            parameters[2].Value = model.XCC_CustomerValue;
            parameters[3].Value = model.XCC_LinkMan;
            parameters[4].Value = model.XCC_DutyPerson;
            parameters[5].Value = model.XCC_CareTypes;
            parameters[6].Value = model.XCC_CareDetails;
            parameters[7].Value = model.XCC_CustomerDetails;
            parameters[8].Value = model.XCC_Remarks;
            parameters[9].Value = model.XCC_Mender;
            parameters[10].Value = model.XCC_MTime;
            parameters[11].Value = model.XCC_Code;

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
        public bool Delete(string XCC_Code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Customer_Cares ");
            strSql.Append(" where XCC_Code=@XCC_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCC_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = XCC_Code;

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
        public bool DeleteList(string XCC_Codelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Xs_Customer_Cares ");
            strSql.Append(" where XCC_Code in (" + XCC_Codelist + ")  ");
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
        public KNet.Model.Xs_Customer_Cares GetModel(string XCC_Code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Xs_Customer_Cares ");
            strSql.Append(" where XCC_Code=@XCC_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@XCC_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = XCC_Code;

            KNet.Model.Xs_Customer_Cares model = new KNet.Model.Xs_Customer_Cares();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["XCC_Code"] != null && ds.Tables[0].Rows[0]["XCC_Code"].ToString() != "")
                {
                    model.XCC_Code = ds.Tables[0].Rows[0]["XCC_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XCC_Topic"] != null && ds.Tables[0].Rows[0]["XCC_Topic"].ToString() != "")
                {
                    model.XCC_Topic = ds.Tables[0].Rows[0]["XCC_Topic"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XCC_Stime"] != null && ds.Tables[0].Rows[0]["XCC_Stime"].ToString() != "")
                {
                    model.XCC_Stime = DateTime.Parse(ds.Tables[0].Rows[0]["XCC_Stime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XCC_CustomerValue"] != null && ds.Tables[0].Rows[0]["XCC_CustomerValue"].ToString() != "")
                {
                    model.XCC_CustomerValue = ds.Tables[0].Rows[0]["XCC_CustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XCC_LinkMan"] != null && ds.Tables[0].Rows[0]["XCC_LinkMan"].ToString() != "")
                {
                    model.XCC_LinkMan = ds.Tables[0].Rows[0]["XCC_LinkMan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XCC_DutyPerson"] != null && ds.Tables[0].Rows[0]["XCC_DutyPerson"].ToString() != "")
                {
                    model.XCC_DutyPerson = ds.Tables[0].Rows[0]["XCC_DutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XCC_CareTypes"] != null && ds.Tables[0].Rows[0]["XCC_CareTypes"].ToString() != "")
                {
                    model.XCC_CareTypes = ds.Tables[0].Rows[0]["XCC_CareTypes"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XCC_CareDetails"] != null && ds.Tables[0].Rows[0]["XCC_CareDetails"].ToString() != "")
                {
                    model.XCC_CareDetails = ds.Tables[0].Rows[0]["XCC_CareDetails"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XCC_CustomerDetails"] != null && ds.Tables[0].Rows[0]["XCC_CustomerDetails"].ToString() != "")
                {
                    model.XCC_CustomerDetails = ds.Tables[0].Rows[0]["XCC_CustomerDetails"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XCC_Remarks"] != null && ds.Tables[0].Rows[0]["XCC_Remarks"].ToString() != "")
                {
                    model.XCC_Remarks = ds.Tables[0].Rows[0]["XCC_Remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XCC_Creator"] != null && ds.Tables[0].Rows[0]["XCC_Creator"].ToString() != "")
                {
                    model.XCC_Creator = ds.Tables[0].Rows[0]["XCC_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XCC_CTime"] != null && ds.Tables[0].Rows[0]["XCC_CTime"].ToString() != "")
                {
                    model.XCC_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["XCC_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XCC_Mender"] != null && ds.Tables[0].Rows[0]["XCC_Mender"].ToString() != "")
                {
                    model.XCC_Mender = ds.Tables[0].Rows[0]["XCC_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["XCC_MTime"] != null && ds.Tables[0].Rows[0]["XCC_MTime"].ToString() != "")
                {
                    model.XCC_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["XCC_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["XCC_Del"] != null && ds.Tables[0].Rows[0]["XCC_Del"].ToString() != "")
                {
                    model.XCC_Del = int.Parse(ds.Tables[0].Rows[0]["XCC_Del"].ToString());
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
            strSql.Append("select XCC_Code,XCC_Topic,XCC_Stime,XCC_CustomerValue,XCC_LinkMan,XCC_DutyPerson,XCC_CareTypes,XCC_CareDetails,XCC_CustomerDetails,XCC_Remarks,XCC_Creator,XCC_CTime,XCC_Mender,XCC_MTime,XCC_Del ");
            strSql.Append(" FROM Xs_Customer_Cares ");
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
            strSql.Append(" XCC_Code,XCC_Topic,XCC_Stime,XCC_CustomerValue,XCC_LinkMan,XCC_DutyPerson,XCC_CareTypes,XCC_CareDetails,XCC_CustomerDetails,XCC_Remarks,XCC_Creator,XCC_CTime,XCC_Mender,XCC_MTime,XCC_Del ");
            strSql.Append(" FROM Xs_Customer_Cares ");
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
            parameters[0].Value = "Xs_Customer_Cares";
            parameters[1].Value = "XCC_Code";
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


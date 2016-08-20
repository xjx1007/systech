using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Cw_Accounting_Init
    /// </summary>
    public partial class Cw_Accounting_Init
    {
        public Cw_Accounting_Init()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CAI_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cw_Accounting_Init");
            strSql.Append(" where CAI_ID=@CAI_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAI_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAI_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cw_Accounting_Init model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cw_Accounting_Init(");
            strSql.Append("CAI_ID,CAI_Code,CAI_Title,CAI_STime,CAI_DutyPerson,CAI_CustomerValue,CAI_SuppNo,CAI_Type,CAI_InitMoney,CAI_Details,CAI_Del,CAI_Creator,CAI_CTime,CAI_Mender,CAI_MTime)");
            strSql.Append(" values (");
            strSql.Append("@CAI_ID,@CAI_Code,@CAI_Title,@CAI_STime,@CAI_DutyPerson,@CAI_CustomerValue,@CAI_SuppNo,@CAI_Type,@CAI_InitMoney,@CAI_Details,@CAI_Del,@CAI_Creator,@CAI_CTime,@CAI_Mender,@CAI_MTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@CAI_ID", SqlDbType.VarChar,50),
					new SqlParameter("@CAI_Code", SqlDbType.VarChar,50),
					new SqlParameter("@CAI_Title", SqlDbType.VarChar,150),
					new SqlParameter("@CAI_STime", SqlDbType.DateTime),
					new SqlParameter("@CAI_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@CAI_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@CAI_SuppNo", SqlDbType.VarChar,50),
					new SqlParameter("@CAI_Type", SqlDbType.Int,4),
					new SqlParameter("@CAI_InitMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CAI_Details", SqlDbType.VarChar,200),
					new SqlParameter("@CAI_Del", SqlDbType.Int,4),
					new SqlParameter("@CAI_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@CAI_CTime", SqlDbType.DateTime),
					new SqlParameter("@CAI_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@CAI_MTime", SqlDbType.DateTime)};
            parameters[0].Value = model.CAI_ID;
            parameters[1].Value = model.CAI_Code;
            parameters[2].Value = model.CAI_Title;
            parameters[3].Value = model.CAI_STime;
            parameters[4].Value = model.CAI_DutyPerson;
            parameters[5].Value = model.CAI_CustomerValue;
            parameters[6].Value = model.CAI_SuppNo;
            parameters[7].Value = model.CAI_Type;
            parameters[8].Value = model.CAI_InitMoney;
            parameters[9].Value = model.CAI_Details;
            parameters[10].Value = model.CAI_Del;
            parameters[11].Value = model.CAI_Creator;
            parameters[12].Value = model.CAI_CTime;
            parameters[13].Value = model.CAI_Mender;
            parameters[14].Value = model.CAI_MTime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cw_Accounting_Init model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cw_Accounting_Init set ");
            strSql.Append("CAI_Code=@CAI_Code,");
            strSql.Append("CAI_Title=@CAI_Title,");
            strSql.Append("CAI_STime=@CAI_STime,");
            strSql.Append("CAI_DutyPerson=@CAI_DutyPerson,");
            strSql.Append("CAI_CustomerValue=@CAI_CustomerValue,");
            strSql.Append("CAI_SuppNo=@CAI_SuppNo,");
            strSql.Append("CAI_Type=@CAI_Type,");
            strSql.Append("CAI_InitMoney=@CAI_InitMoney,");
            strSql.Append("CAI_Details=@CAI_Details,");
            strSql.Append("CAI_Del=@CAI_Del,");
            strSql.Append("CAI_Creator=@CAI_Creator,");
            strSql.Append("CAI_CTime=@CAI_CTime,");
            strSql.Append("CAI_Mender=@CAI_Mender,");
            strSql.Append("CAI_MTime=@CAI_MTime");
            strSql.Append(" where CAI_ID=@CAI_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAI_Code", SqlDbType.VarChar,50),
					new SqlParameter("@CAI_Title", SqlDbType.VarChar,150),
					new SqlParameter("@CAI_STime", SqlDbType.DateTime),
					new SqlParameter("@CAI_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@CAI_CustomerValue", SqlDbType.VarChar,50),
					new SqlParameter("@CAI_SuppNo", SqlDbType.VarChar,50),
					new SqlParameter("@CAI_Type", SqlDbType.Int,4),
					new SqlParameter("@CAI_InitMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CAI_Details", SqlDbType.VarChar,200),
					new SqlParameter("@CAI_Del", SqlDbType.Int,4),
					new SqlParameter("@CAI_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@CAI_CTime", SqlDbType.DateTime),
					new SqlParameter("@CAI_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@CAI_MTime", SqlDbType.DateTime),
					new SqlParameter("@CAI_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CAI_Code;
            parameters[1].Value = model.CAI_Title;
            parameters[2].Value = model.CAI_STime;
            parameters[3].Value = model.CAI_DutyPerson;
            parameters[4].Value = model.CAI_CustomerValue;
            parameters[5].Value = model.CAI_SuppNo;
            parameters[6].Value = model.CAI_Type;
            parameters[7].Value = model.CAI_InitMoney;
            parameters[8].Value = model.CAI_Details;
            parameters[9].Value = model.CAI_Del;
            parameters[10].Value = model.CAI_Creator;
            parameters[11].Value = model.CAI_CTime;
            parameters[12].Value = model.CAI_Mender;
            parameters[13].Value = model.CAI_MTime;
            parameters[14].Value = model.CAI_ID;

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
        public bool Delete(string CAI_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cw_Accounting_Init ");
            strSql.Append(" where CAI_ID=@CAI_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAI_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAI_ID;

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
        public bool DeleteList(string CAI_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cw_Accounting_Init ");
            strSql.Append(" where CAI_ID in (" + CAI_IDlist + ")  ");
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
        public KNet.Model.Cw_Accounting_Init GetModel(string CAI_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CAI_ID,CAI_Code,CAI_Title,CAI_STime,CAI_DutyPerson,CAI_CustomerValue,CAI_SuppNo,CAI_Type,CAI_InitMoney,CAI_Details,CAI_Del,CAI_Creator,CAI_CTime,CAI_Mender,CAI_MTime from Cw_Accounting_Init ");
            strSql.Append(" where CAI_ID=@CAI_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CAI_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CAI_ID;

            KNet.Model.Cw_Accounting_Init model = new KNet.Model.Cw_Accounting_Init();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CAI_ID"] != null && ds.Tables[0].Rows[0]["CAI_ID"].ToString() != "")
                {
                    model.CAI_ID = ds.Tables[0].Rows[0]["CAI_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAI_Code"] != null && ds.Tables[0].Rows[0]["CAI_Code"].ToString() != "")
                {
                    model.CAI_Code = ds.Tables[0].Rows[0]["CAI_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAI_Title"] != null && ds.Tables[0].Rows[0]["CAI_Title"].ToString() != "")
                {
                    model.CAI_Title = ds.Tables[0].Rows[0]["CAI_Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAI_STime"] != null && ds.Tables[0].Rows[0]["CAI_STime"].ToString() != "")
                {
                    model.CAI_STime = DateTime.Parse(ds.Tables[0].Rows[0]["CAI_STime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAI_DutyPerson"] != null && ds.Tables[0].Rows[0]["CAI_DutyPerson"].ToString() != "")
                {
                    model.CAI_DutyPerson = ds.Tables[0].Rows[0]["CAI_DutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAI_CustomerValue"] != null && ds.Tables[0].Rows[0]["CAI_CustomerValue"].ToString() != "")
                {
                    model.CAI_CustomerValue = ds.Tables[0].Rows[0]["CAI_CustomerValue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAI_SuppNo"] != null && ds.Tables[0].Rows[0]["CAI_SuppNo"].ToString() != "")
                {
                    model.CAI_SuppNo = ds.Tables[0].Rows[0]["CAI_SuppNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAI_Type"] != null && ds.Tables[0].Rows[0]["CAI_Type"].ToString() != "")
                {
                    model.CAI_Type = int.Parse(ds.Tables[0].Rows[0]["CAI_Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAI_InitMoney"] != null && ds.Tables[0].Rows[0]["CAI_InitMoney"].ToString() != "")
                {
                    model.CAI_InitMoney = decimal.Parse(ds.Tables[0].Rows[0]["CAI_InitMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAI_Details"] != null && ds.Tables[0].Rows[0]["CAI_Details"].ToString() != "")
                {
                    model.CAI_Details = ds.Tables[0].Rows[0]["CAI_Details"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAI_Del"] != null && ds.Tables[0].Rows[0]["CAI_Del"].ToString() != "")
                {
                    model.CAI_Del = int.Parse(ds.Tables[0].Rows[0]["CAI_Del"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAI_Creator"] != null && ds.Tables[0].Rows[0]["CAI_Creator"].ToString() != "")
                {
                    model.CAI_Creator = ds.Tables[0].Rows[0]["CAI_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAI_CTime"] != null && ds.Tables[0].Rows[0]["CAI_CTime"].ToString() != "")
                {
                    model.CAI_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["CAI_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CAI_Mender"] != null && ds.Tables[0].Rows[0]["CAI_Mender"].ToString() != "")
                {
                    model.CAI_Mender = ds.Tables[0].Rows[0]["CAI_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CAI_MTime"] != null && ds.Tables[0].Rows[0]["CAI_MTime"].ToString() != "")
                {
                    model.CAI_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["CAI_MTime"].ToString());
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
            strSql.Append(" FROM Cw_Accounting_Init ");
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
            strSql.Append(" CAI_ID,CAI_Code,CAI_Title,CAI_STime,CAI_DutyPerson,CAI_CustomerValue,CAI_SuppNo,CAI_Type,CAI_InitMoney,CAI_Details,CAI_Del,CAI_Creator,CAI_CTime,CAI_Mender,CAI_MTime ");
            strSql.Append(" FROM Cw_Accounting_Init ");
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
            parameters[0].Value = "Cw_Accounting_Init";
            parameters[1].Value = "CAI_ID";
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


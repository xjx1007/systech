using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Pb_Products_SampleAsk
    /// </summary>
    public partial class Pb_Products_SampleAsk
    {
        public Pb_Products_SampleAsk()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PPA_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Pb_Products_SampleAsk");
            strSql.Append(" where PPA_ID=@PPA_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPA_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PPA_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Pb_Products_SampleAsk model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Pb_Products_SampleAsk(");
            strSql.Append("PPA_ID,PPA_ProdutsBarCode,PPA_Stime,PPA_Number,PPA_Use,PPA_DutyPerson,PPA_Type,PPA_IsBack,PPA_Remarks,PPA_CTime,PPA_Creator,PPA_SampleID)");
            strSql.Append(" values (");
            strSql.Append("@PPA_ID,@PPA_ProdutsBarCode,@PPA_Stime,@PPA_Number,@PPA_Use,@PPA_DutyPerson,@PPA_Type,@PPA_IsBack,@PPA_Remarks,@PPA_CTime,@PPA_Creator,@PPA_SampleID)");
            SqlParameter[] parameters = {
					new SqlParameter("@PPA_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PPA_ProdutsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@PPA_Stime", SqlDbType.DateTime),
					new SqlParameter("@PPA_Number", SqlDbType.Int,4),
					new SqlParameter("@PPA_Use", SqlDbType.VarChar,150),
					new SqlParameter("@PPA_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@PPA_Type", SqlDbType.Int,4),
					new SqlParameter("@PPA_IsBack", SqlDbType.Int,4),
					new SqlParameter("@PPA_Remarks", SqlDbType.VarChar,250),
					new SqlParameter("@PPA_CTime", SqlDbType.DateTime),
					new SqlParameter("@PPA_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@PPA_SampleID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PPA_ID;
            parameters[1].Value = model.PPA_ProdutsBarCode;
            parameters[2].Value = model.PPA_Stime;
            parameters[3].Value = model.PPA_Number;
            parameters[4].Value = model.PPA_Use;
            parameters[5].Value = model.PPA_DutyPerson;
            parameters[6].Value = model.PPA_Type;
            parameters[7].Value = model.PPA_IsBack;
            parameters[8].Value = model.PPA_Remarks;
            parameters[9].Value = model.PPA_CTime;
            parameters[10].Value = model.PPA_Creator;
            parameters[11].Value = model.PPA_SampleID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Pb_Products_SampleAsk model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Pb_Products_SampleAsk set ");
            strSql.Append("PPA_ProdutsBarCode=@PPA_ProdutsBarCode,");
            strSql.Append("PPA_Stime=@PPA_Stime,");
            strSql.Append("PPA_Number=@PPA_Number,");
            strSql.Append("PPA_Use=@PPA_Use,");
            strSql.Append("PPA_DutyPerson=@PPA_DutyPerson,");
            strSql.Append("PPA_Type=@PPA_Type,");
            strSql.Append("PPA_IsBack=@PPA_IsBack,");
            strSql.Append("PPA_Remarks=@PPA_Remarks,");
            strSql.Append("PPA_MTime=@PPA_MTime,");
            strSql.Append("PPA_Mender=@PPA_Mender");
            strSql.Append(" where PPA_ID=@PPA_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPA_ProdutsBarCode", SqlDbType.VarChar,50),
					new SqlParameter("@PPA_Stime", SqlDbType.DateTime),
					new SqlParameter("@PPA_Number", SqlDbType.Int,4),
					new SqlParameter("@PPA_Use", SqlDbType.VarChar,150),
					new SqlParameter("@PPA_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@PPA_Type", SqlDbType.Int,4),
					new SqlParameter("@PPA_IsBack", SqlDbType.Int,4),
					new SqlParameter("@PPA_Remarks", SqlDbType.VarChar,250),
					new SqlParameter("@PPA_MTime", SqlDbType.DateTime),
					new SqlParameter("@PPA_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@PPA_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PPA_ProdutsBarCode;
            parameters[1].Value = model.PPA_Stime;
            parameters[2].Value = model.PPA_Number;
            parameters[3].Value = model.PPA_Use;
            parameters[4].Value = model.PPA_DutyPerson;
            parameters[5].Value = model.PPA_Type;
            parameters[6].Value = model.PPA_IsBack;
            parameters[7].Value = model.PPA_Remarks;
            parameters[8].Value = model.PPA_MTime;
            parameters[9].Value = model.PPA_Mender;
            parameters[10].Value = model.PPA_ID;

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
        public bool Delete(string PPA_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Pb_Products_SampleAsk ");
            strSql.Append(" where PPA_ID=@PPA_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPA_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PPA_ID;

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
        public bool DeleteList(string PPA_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Pb_Products_SampleAsk ");
            strSql.Append(" where PPA_ID in (" + PPA_IDlist + ")  ");
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
        public KNet.Model.Pb_Products_SampleAsk GetModel(string PPA_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Pb_Products_SampleAsk ");
            strSql.Append(" where PPA_ID=@PPA_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPA_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PPA_ID;

            KNet.Model.Pb_Products_SampleAsk model = new KNet.Model.Pb_Products_SampleAsk();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PPA_ID"] != null && ds.Tables[0].Rows[0]["PPA_ID"].ToString() != "")
                {
                    model.PPA_ID = ds.Tables[0].Rows[0]["PPA_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPA_ProdutsBarCode"] != null && ds.Tables[0].Rows[0]["PPA_ProdutsBarCode"].ToString() != "")
                {
                    model.PPA_ProdutsBarCode = ds.Tables[0].Rows[0]["PPA_ProdutsBarCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPA_Stime"] != null && ds.Tables[0].Rows[0]["PPA_Stime"].ToString() != "")
                {
                    model.PPA_Stime = DateTime.Parse(ds.Tables[0].Rows[0]["PPA_Stime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PPA_Number"] != null && ds.Tables[0].Rows[0]["PPA_Number"].ToString() != "")
                {
                    model.PPA_Number = int.Parse(ds.Tables[0].Rows[0]["PPA_Number"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PPA_Use"] != null && ds.Tables[0].Rows[0]["PPA_Use"].ToString() != "")
                {
                    model.PPA_Use = ds.Tables[0].Rows[0]["PPA_Use"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPA_DutyPerson"] != null && ds.Tables[0].Rows[0]["PPA_DutyPerson"].ToString() != "")
                {
                    model.PPA_DutyPerson = ds.Tables[0].Rows[0]["PPA_DutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPA_Type"] != null && ds.Tables[0].Rows[0]["PPA_Type"].ToString() != "")
                {
                    model.PPA_Type = int.Parse(ds.Tables[0].Rows[0]["PPA_Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PPA_IsBack"] != null && ds.Tables[0].Rows[0]["PPA_IsBack"].ToString() != "")
                {
                    model.PPA_IsBack = int.Parse(ds.Tables[0].Rows[0]["PPA_IsBack"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PPA_Remarks"] != null && ds.Tables[0].Rows[0]["PPA_Remarks"].ToString() != "")
                {
                    model.PPA_Remarks = ds.Tables[0].Rows[0]["PPA_Remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPA_CTime"] != null && ds.Tables[0].Rows[0]["PPA_CTime"].ToString() != "")
                {
                    model.PPA_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["PPA_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PPA_Creator"] != null && ds.Tables[0].Rows[0]["PPA_Creator"].ToString() != "")
                {
                    model.PPA_Creator = ds.Tables[0].Rows[0]["PPA_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPA_MTime"] != null && ds.Tables[0].Rows[0]["PPA_MTime"].ToString() != "")
                {
                    model.PPA_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["PPA_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PPA_Mender"] != null && ds.Tables[0].Rows[0]["PPA_Mender"].ToString() != "")
                {
                    model.PPA_Mender = ds.Tables[0].Rows[0]["PPA_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPA_Del"] != null && ds.Tables[0].Rows[0]["PPA_Del"].ToString() != "")
                {
                    model.PPA_Del = int.Parse(ds.Tables[0].Rows[0]["PPA_Del"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Pb_Products_SampleAsk GetModelBySampleID(string PPA_SampleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Pb_Products_SampleAsk ");
            strSql.Append(" where PPA_SampleID=@PPA_SampleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPA_SampleID", SqlDbType.VarChar,50)};
            parameters[0].Value = PPA_SampleID;

            KNet.Model.Pb_Products_SampleAsk model = new KNet.Model.Pb_Products_SampleAsk();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PPA_ID"] != null && ds.Tables[0].Rows[0]["PPA_ID"].ToString() != "")
                {
                    model.PPA_ID = ds.Tables[0].Rows[0]["PPA_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPA_ProdutsBarCode"] != null && ds.Tables[0].Rows[0]["PPA_ProdutsBarCode"].ToString() != "")
                {
                    model.PPA_ProdutsBarCode = ds.Tables[0].Rows[0]["PPA_ProdutsBarCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPA_Stime"] != null && ds.Tables[0].Rows[0]["PPA_Stime"].ToString() != "")
                {
                    model.PPA_Stime = DateTime.Parse(ds.Tables[0].Rows[0]["PPA_Stime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PPA_Number"] != null && ds.Tables[0].Rows[0]["PPA_Number"].ToString() != "")
                {
                    model.PPA_Number = int.Parse(ds.Tables[0].Rows[0]["PPA_Number"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PPA_Use"] != null && ds.Tables[0].Rows[0]["PPA_Use"].ToString() != "")
                {
                    model.PPA_Use = ds.Tables[0].Rows[0]["PPA_Use"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPA_DutyPerson"] != null && ds.Tables[0].Rows[0]["PPA_DutyPerson"].ToString() != "")
                {
                    model.PPA_DutyPerson = ds.Tables[0].Rows[0]["PPA_DutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPA_Type"] != null && ds.Tables[0].Rows[0]["PPA_Type"].ToString() != "")
                {
                    model.PPA_Type = int.Parse(ds.Tables[0].Rows[0]["PPA_Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PPA_IsBack"] != null && ds.Tables[0].Rows[0]["PPA_IsBack"].ToString() != "")
                {
                    model.PPA_IsBack = int.Parse(ds.Tables[0].Rows[0]["PPA_IsBack"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PPA_Remarks"] != null && ds.Tables[0].Rows[0]["PPA_Remarks"].ToString() != "")
                {
                    model.PPA_Remarks = ds.Tables[0].Rows[0]["PPA_Remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPA_CTime"] != null && ds.Tables[0].Rows[0]["PPA_CTime"].ToString() != "")
                {
                    model.PPA_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["PPA_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PPA_Creator"] != null && ds.Tables[0].Rows[0]["PPA_Creator"].ToString() != "")
                {
                    model.PPA_Creator = ds.Tables[0].Rows[0]["PPA_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPA_MTime"] != null && ds.Tables[0].Rows[0]["PPA_MTime"].ToString() != "")
                {
                    model.PPA_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["PPA_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PPA_Mender"] != null && ds.Tables[0].Rows[0]["PPA_Mender"].ToString() != "")
                {
                    model.PPA_Mender = ds.Tables[0].Rows[0]["PPA_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPA_Del"] != null && ds.Tables[0].Rows[0]["PPA_Del"].ToString() != "")
                {
                    model.PPA_Del = int.Parse(ds.Tables[0].Rows[0]["PPA_Del"].ToString());
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
            strSql.Append(" FROM Pb_Products_SampleAsk ");
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
            strSql.Append(" FROM Pb_Products_SampleAsk ");
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
            parameters[0].Value = "Pb_Products_SampleAsk";
            parameters[1].Value = "PPA_ID";
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


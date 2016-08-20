using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Pb_Products_Sample_Confim
    /// </summary>
    public partial class Pb_Products_Sample_Confim
    {
        public Pb_Products_Sample_Confim()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBC_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Pb_Products_Sample_Confim");
            strSql.Append(" where PBC_ID=@PBC_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBC_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBC_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Pb_Products_Sample_Confim model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Pb_Products_Sample_Confim(");
            strSql.Append("PBC_ID,PBC_Type,PBC_Stime,PBC_Person,PBC_Remarks,PBC_CTime,PBC_Creator,PBC_SampleID)");
            strSql.Append(" values (");
            strSql.Append("@PBC_ID,@PBC_Type,@PBC_Stime,@PBC_Person,@PBC_Remarks,@PBC_CTime,@PBC_Creator,@PBC_SampleID)");
            SqlParameter[] parameters = {
					new SqlParameter("@PBC_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_Type", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_Stime", SqlDbType.DateTime),
					new SqlParameter("@PBC_Person", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_Remarks", SqlDbType.VarChar,500),
					new SqlParameter("@PBC_CTime", SqlDbType.DateTime),
					new SqlParameter("@PBC_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_SampleID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PBC_ID;
            parameters[1].Value = model.PBC_Type;
            parameters[2].Value = model.PBC_Stime;
            parameters[3].Value = model.PBC_Person;
            parameters[4].Value = model.PBC_Remarks;
            parameters[5].Value = model.PBC_CTime;
            parameters[6].Value = model.PBC_Creator;
            parameters[7].Value = model.PBC_SampleID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Pb_Products_Sample_Confim model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Pb_Products_Sample_Confim set ");
            strSql.Append("PBC_Type=@PBC_Type,");
            strSql.Append("PBC_Stime=@PBC_Stime,");
            strSql.Append("PBC_Person=@PBC_Person,");
            strSql.Append("PBC_Remarks=@PBC_Remarks,");
            strSql.Append("PBC_MTime=@PBC_MTime,");
            strSql.Append("PBC_Mender=@PBC_Mender,");
            strSql.Append("PBC_Del=@PBC_Del");
            strSql.Append(" where PBC_ID=@PBC_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBC_Type", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_Stime", SqlDbType.DateTime),
					new SqlParameter("@PBC_Person", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_Remarks", SqlDbType.VarChar,500),
					new SqlParameter("@PBC_CTime", SqlDbType.DateTime),
					new SqlParameter("@PBC_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_MTime", SqlDbType.DateTime),
					new SqlParameter("@PBC_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_Del", SqlDbType.Int,4)};
            parameters[0].Value = model.PBC_Type;
            parameters[1].Value = model.PBC_Stime;
            parameters[2].Value = model.PBC_Person;
            parameters[3].Value = model.PBC_Remarks;
            parameters[4].Value = model.PBC_MTime;
            parameters[5].Value = model.PBC_Mender;
            parameters[6].Value = model.PBC_ID;

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
        public bool Delete(string PBC_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Pb_Products_Sample_Confim ");
            strSql.Append(" where PBC_ID=@PBC_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBC_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBC_ID;

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
        public bool DeleteList(string PBC_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Pb_Products_Sample_Confim ");
            strSql.Append(" where PBC_ID in (" + PBC_IDlist + ")  ");
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
        public KNet.Model.Pb_Products_Sample_Confim GetModel(string PBC_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PBC_ID,PBC_Type,PBC_Stime,PBC_Person,PBC_Remarks,PBC_CTime,PBC_Creator,PBC_MTime,PBC_Mender,PBC_Del from Pb_Products_Sample_Confim ");
            strSql.Append(" where PBC_ID=@PBC_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBC_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBC_ID;

            KNet.Model.Pb_Products_Sample_Confim model = new KNet.Model.Pb_Products_Sample_Confim();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PBC_ID"] != null && ds.Tables[0].Rows[0]["PBC_ID"].ToString() != "")
                {
                    model.PBC_ID = ds.Tables[0].Rows[0]["PBC_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBC_Type"] != null && ds.Tables[0].Rows[0]["PBC_Type"].ToString() != "")
                {
                    model.PBC_Type = ds.Tables[0].Rows[0]["PBC_Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBC_Stime"] != null && ds.Tables[0].Rows[0]["PBC_Stime"].ToString() != "")
                {
                    model.PBC_Stime = DateTime.Parse(ds.Tables[0].Rows[0]["PBC_Stime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBC_Person"] != null && ds.Tables[0].Rows[0]["PBC_Person"].ToString() != "")
                {
                    model.PBC_Person = ds.Tables[0].Rows[0]["PBC_Person"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBC_Remarks"] != null && ds.Tables[0].Rows[0]["PBC_Remarks"].ToString() != "")
                {
                    model.PBC_Remarks = ds.Tables[0].Rows[0]["PBC_Remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBC_CTime"] != null && ds.Tables[0].Rows[0]["PBC_CTime"].ToString() != "")
                {
                    model.PBC_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["PBC_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBC_Creator"] != null && ds.Tables[0].Rows[0]["PBC_Creator"].ToString() != "")
                {
                    model.PBC_Creator = ds.Tables[0].Rows[0]["PBC_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBC_MTime"] != null && ds.Tables[0].Rows[0]["PBC_MTime"].ToString() != "")
                {
                    model.PBC_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["PBC_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBC_Mender"] != null && ds.Tables[0].Rows[0]["PBC_Mender"].ToString() != "")
                {
                    model.PBC_Mender = ds.Tables[0].Rows[0]["PBC_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBC_Del"] != null && ds.Tables[0].Rows[0]["PBC_Del"].ToString() != "")
                {
                    model.PBC_Del = int.Parse(ds.Tables[0].Rows[0]["PBC_Del"].ToString());
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
            strSql.Append("select PBC_ID,PBC_Type,PBC_Stime,PBC_Person,PBC_Remarks,PBC_CTime,PBC_Creator,PBC_MTime,PBC_Mender,PBC_Del ");
            strSql.Append(" FROM Pb_Products_Sample_Confim ");
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
            strSql.Append(" PBC_ID,PBC_Type,PBC_Stime,PBC_Person,PBC_Remarks,PBC_CTime,PBC_Creator,PBC_MTime,PBC_Mender,PBC_Del ");
            strSql.Append(" FROM Pb_Products_Sample_Confim ");
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
            parameters[0].Value = "Pb_Products_Sample_Confim";
            parameters[1].Value = "PBC_ID";
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


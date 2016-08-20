using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Pb_Basic_Notice
    /// </summary>
    public partial class Pb_Basic_Notice
    {
        public Pb_Basic_Notice()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBN_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Pb_Basic_Notice");
            strSql.Append(" where PBN_ID=@PBN_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBN_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBN_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Pb_Basic_Notice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Pb_Basic_Notice(");
            strSql.Append("PBN_ID,PBN_Title,PBN_Type,PBN_BeginTime,PBN_EndTime,PBN_ReceiveID,PBN_Details,PBN_CTime,PBN_Creator,PBN_MTime,PBN_Mender,PBN_Del)");
            strSql.Append(" values (");
            strSql.Append("@PBN_ID,@PBN_Title,@PBN_Type,@PBN_BeginTime,@PBN_EndTime,@PBN_ReceiveID,@PBN_Details,@PBN_CTime,@PBN_Creator,@PBN_MTime,@PBN_Mender,@PBN_Del)");
            SqlParameter[] parameters = {
					new SqlParameter("@PBN_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PBN_Title", SqlDbType.VarChar,300),
					new SqlParameter("@PBN_Type", SqlDbType.VarChar,50),
					new SqlParameter("@PBN_BeginTime", SqlDbType.DateTime),
					new SqlParameter("@PBN_EndTime", SqlDbType.DateTime),
					new SqlParameter("@PBN_ReceiveID", SqlDbType.VarChar,500),
					new SqlParameter("@PBN_Details", SqlDbType.VarChar,2000),
					new SqlParameter("@PBN_CTime", SqlDbType.DateTime),
					new SqlParameter("@PBN_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@PBN_MTime", SqlDbType.DateTime),
					new SqlParameter("@PBN_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@PBN_Del", SqlDbType.Int,4)};
            parameters[0].Value = model.PBN_ID;
            parameters[1].Value = model.PBN_Title;
            parameters[2].Value = model.PBN_Type;
            parameters[3].Value = model.PBN_BeginTime;
            parameters[4].Value = model.PBN_EndTime;
            parameters[5].Value = model.PBN_ReceiveID;
            parameters[6].Value = model.PBN_Details;
            parameters[7].Value = model.PBN_CTime;
            parameters[8].Value = model.PBN_Creator;
            parameters[9].Value = model.PBN_MTime;
            parameters[10].Value = model.PBN_Mender;
            parameters[11].Value = model.PBN_Del;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Pb_Basic_Notice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Pb_Basic_Notice set ");
            strSql.Append("PBN_Title=@PBN_Title,");
            strSql.Append("PBN_Type=@PBN_Type,");
            strSql.Append("PBN_BeginTime=@PBN_BeginTime,");
            strSql.Append("PBN_EndTime=@PBN_EndTime,");
            strSql.Append("PBN_ReceiveID=@PBN_ReceiveID,");
            strSql.Append("PBN_Details=@PBN_Details,");
            strSql.Append("PBN_CTime=@PBN_CTime,");
            strSql.Append("PBN_Creator=@PBN_Creator,");
            strSql.Append("PBN_MTime=@PBN_MTime,");
            strSql.Append("PBN_Mender=@PBN_Mender,");
            strSql.Append("PBN_Del=@PBN_Del");
            strSql.Append(" where PBN_ID=@PBN_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBN_Title", SqlDbType.VarChar,300),
					new SqlParameter("@PBN_Type", SqlDbType.VarChar,50),
					new SqlParameter("@PBN_BeginTime", SqlDbType.DateTime),
					new SqlParameter("@PBN_EndTime", SqlDbType.DateTime),
					new SqlParameter("@PBN_ReceiveID", SqlDbType.VarChar,500),
					new SqlParameter("@PBN_Details", SqlDbType.VarChar,2000),
					new SqlParameter("@PBN_CTime", SqlDbType.DateTime),
					new SqlParameter("@PBN_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@PBN_MTime", SqlDbType.DateTime),
					new SqlParameter("@PBN_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@PBN_Del", SqlDbType.Int,4),
					new SqlParameter("@PBN_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PBN_Title;
            parameters[1].Value = model.PBN_Type;
            parameters[2].Value = model.PBN_BeginTime;
            parameters[3].Value = model.PBN_EndTime;
            parameters[4].Value = model.PBN_ReceiveID;
            parameters[5].Value = model.PBN_Details;
            parameters[6].Value = model.PBN_CTime;
            parameters[7].Value = model.PBN_Creator;
            parameters[8].Value = model.PBN_MTime;
            parameters[9].Value = model.PBN_Mender;
            parameters[10].Value = model.PBN_Del;
            parameters[11].Value = model.PBN_ID;

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
        public bool Delete(string PBN_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Pb_Basic_Notice ");
            strSql.Append(" where PBN_ID=@PBN_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBN_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBN_ID;

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
        public bool DeleteList(string PBN_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Pb_Basic_Notice ");
            strSql.Append(" where PBN_ID in (" + PBN_IDlist + ")  ");
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
        public KNet.Model.Pb_Basic_Notice GetModel(string PBN_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PBN_ID,PBN_Title,PBN_Type,PBN_BeginTime,PBN_EndTime,PBN_ReceiveID,PBN_Details,PBN_CTime,PBN_Creator,PBN_MTime,PBN_Mender,PBN_Del from Pb_Basic_Notice ");
            strSql.Append(" where PBN_ID=@PBN_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBN_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBN_ID;

            KNet.Model.Pb_Basic_Notice model = new KNet.Model.Pb_Basic_Notice();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PBN_ID"] != null && ds.Tables[0].Rows[0]["PBN_ID"].ToString() != "")
                {
                    model.PBN_ID = ds.Tables[0].Rows[0]["PBN_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBN_Title"] != null && ds.Tables[0].Rows[0]["PBN_Title"].ToString() != "")
                {
                    model.PBN_Title = ds.Tables[0].Rows[0]["PBN_Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBN_Type"] != null && ds.Tables[0].Rows[0]["PBN_Type"].ToString() != "")
                {
                    model.PBN_Type = ds.Tables[0].Rows[0]["PBN_Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBN_BeginTime"] != null && ds.Tables[0].Rows[0]["PBN_BeginTime"].ToString() != "")
                {
                    model.PBN_BeginTime = DateTime.Parse(ds.Tables[0].Rows[0]["PBN_BeginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBN_EndTime"] != null && ds.Tables[0].Rows[0]["PBN_EndTime"].ToString() != "")
                {
                    model.PBN_EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["PBN_EndTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBN_ReceiveID"] != null && ds.Tables[0].Rows[0]["PBN_ReceiveID"].ToString() != "")
                {
                    model.PBN_ReceiveID = ds.Tables[0].Rows[0]["PBN_ReceiveID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBN_Details"] != null && ds.Tables[0].Rows[0]["PBN_Details"].ToString() != "")
                {
                    model.PBN_Details = ds.Tables[0].Rows[0]["PBN_Details"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBN_CTime"] != null && ds.Tables[0].Rows[0]["PBN_CTime"].ToString() != "")
                {
                    model.PBN_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["PBN_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBN_Creator"] != null && ds.Tables[0].Rows[0]["PBN_Creator"].ToString() != "")
                {
                    model.PBN_Creator = ds.Tables[0].Rows[0]["PBN_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBN_MTime"] != null && ds.Tables[0].Rows[0]["PBN_MTime"].ToString() != "")
                {
                    model.PBN_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["PBN_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBN_Mender"] != null && ds.Tables[0].Rows[0]["PBN_Mender"].ToString() != "")
                {
                    model.PBN_Mender = ds.Tables[0].Rows[0]["PBN_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBN_Del"] != null && ds.Tables[0].Rows[0]["PBN_Del"].ToString() != "")
                {
                    model.PBN_Del = int.Parse(ds.Tables[0].Rows[0]["PBN_Del"].ToString());
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
            strSql.Append("select PBN_ID,PBN_Title,PBN_Type,PBN_BeginTime,PBN_EndTime,PBN_ReceiveID,PBN_Details,PBN_CTime,PBN_Creator,PBN_MTime,PBN_Mender,PBN_Del ");
            strSql.Append(" FROM Pb_Basic_Notice ");
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
            strSql.Append(" PBN_ID,PBN_Title,PBN_Type,PBN_BeginTime,PBN_EndTime,PBN_ReceiveID,PBN_Details,PBN_CTime,PBN_Creator,PBN_MTime,PBN_Mender,PBN_Del ");
            strSql.Append(" FROM Pb_Basic_Notice ");
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
            parameters[0].Value = "Pb_Basic_Notice";
            parameters[1].Value = "PBN_ID";
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


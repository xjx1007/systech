using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Pb_Products_Sample_Images
    /// </summary>
    public partial class Pb_Products_Sample_Images
    {
        public Pb_Products_Sample_Images()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PPI_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Pb_Products_Sample_Images");
            strSql.Append(" where PPI_ID=@PPI_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPI_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PPI_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Pb_Products_Sample_Images model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Pb_Products_Sample_Images(");
            strSql.Append("PPI_ID,PPI_SmapleID,PPI_URL,PPI_Name,PPI_URLName,PBI_Type,PPI_CTime,PPI_Creator)");
            strSql.Append(" values (");
            strSql.Append("@PPI_ID,@PPI_SmapleID,@PPI_URL,@PPI_Name,@PPI_URLName,@PBI_Type,@PPI_CTime,@PPI_Creator)");
            SqlParameter[] parameters = {
					new SqlParameter("@PPI_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PPI_SmapleID", SqlDbType.VarChar,50),
					new SqlParameter("@PPI_URL", SqlDbType.VarChar,200),
					new SqlParameter("@PPI_Name", SqlDbType.VarChar,50),
					new SqlParameter("@PPI_URLName", SqlDbType.VarChar,200),
					new SqlParameter("@PBI_Type", SqlDbType.VarChar,50),
					new SqlParameter("@PPI_CTime", SqlDbType.DateTime),
					new SqlParameter("@PPI_Creator", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PPI_ID;
            parameters[1].Value = model.PPI_SmapleID;
            parameters[2].Value = model.PPI_URL;
            parameters[3].Value = model.PPI_Name;
            parameters[4].Value = model.PPI_URLName;
            parameters[5].Value = model.PBI_Type;
            parameters[6].Value = model.PPI_CTime;
            parameters[7].Value = model.PPI_Creator;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Pb_Products_Sample_Images model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Pb_Products_Sample_Images set ");
            strSql.Append("PPI_SmapleID=@PPI_SmapleID,");
            strSql.Append("PPI_URL=@PPI_URL,");
            strSql.Append("PPI_Name=@PPI_Name,");
            strSql.Append("PPI_URLName=@PPI_URLName,");
            strSql.Append("PBI_Type=@PBI_Type");
            strSql.Append(" where PPI_ID=@PPI_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPI_SmapleID", SqlDbType.VarChar,50),
					new SqlParameter("@PPI_URL", SqlDbType.VarChar,200),
					new SqlParameter("@PPI_Name", SqlDbType.VarChar,50),
					new SqlParameter("@PPI_URLName", SqlDbType.VarChar,200),
					new SqlParameter("@PBI_Type", SqlDbType.VarChar,50),
					new SqlParameter("@PPI_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PPI_SmapleID;
            parameters[1].Value = model.PPI_URL;
            parameters[2].Value = model.PPI_Name;
            parameters[3].Value = model.PPI_URLName;
            parameters[4].Value = model.PBI_Type;
            parameters[5].Value = model.PPI_ID;

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
        public bool Delete(string PPI_SmapleID, string PPI_Type)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Pb_Products_Sample_Images ");
            strSql.Append(" where PPI_SmapleID=@PPI_SmapleID and PBI_Type=@PBI_Type ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPI_SmapleID", SqlDbType.VarChar,50),
                                        new SqlParameter("@PBI_Type", SqlDbType.VarChar,50)};
            parameters[0].Value = PPI_SmapleID;
            parameters[1].Value = PPI_Type;

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
        public bool DeleteList(string PPI_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Pb_Products_Sample_Images ");
            strSql.Append(" where PPI_ID in (" + PPI_IDlist + ")  ");
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
        public KNet.Model.Pb_Products_Sample_Images GetModel(string PPI_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Pb_Products_Sample_Images ");
            strSql.Append(" where PPI_ID=@PPI_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PPI_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PPI_ID;

            KNet.Model.Pb_Products_Sample_Images model = new KNet.Model.Pb_Products_Sample_Images();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PPI_ID"] != null && ds.Tables[0].Rows[0]["PPI_ID"].ToString() != "")
                {
                    model.PPI_ID = ds.Tables[0].Rows[0]["PPI_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPI_SmapleID"] != null && ds.Tables[0].Rows[0]["PPI_SmapleID"].ToString() != "")
                {
                    model.PPI_SmapleID = ds.Tables[0].Rows[0]["PPI_SmapleID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPI_URL"] != null && ds.Tables[0].Rows[0]["PPI_URL"].ToString() != "")
                {
                    model.PPI_URL = ds.Tables[0].Rows[0]["PPI_URL"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPI_Name"] != null && ds.Tables[0].Rows[0]["PPI_Name"].ToString() != "")
                {
                    model.PPI_Name = ds.Tables[0].Rows[0]["PPI_Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PPI_URLName"] != null && ds.Tables[0].Rows[0]["PPI_URLName"].ToString() != "")
                {
                    model.PPI_URLName = ds.Tables[0].Rows[0]["PPI_URLName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBI_Type"] != null && ds.Tables[0].Rows[0]["PBI_Type"].ToString() != "")
                {
                    model.PBI_Type = ds.Tables[0].Rows[0]["PBI_Type"].ToString();
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
            strSql.Append("select PPI_ID,PPI_SmapleID,PPI_URL,PPI_Name,PPI_URLName ");
            strSql.Append(" FROM Pb_Products_Sample_Images ");
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
            strSql.Append(" FROM Pb_Products_Sample_Images ");
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
            parameters[0].Value = "Pb_Products_Sample_Images";
            parameters[1].Value = "PPI_ID";
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


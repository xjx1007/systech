using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:PB_Basic_Code
    /// </summary>
    public partial class PB_Basic_Code
    {
        public PB_Basic_Code()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBC_ID, string PBC_Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PB_Basic_Code");
            strSql.Append(" where PBC_ID=@PBC_ID and PBC_Code=@PBC_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBC_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = PBC_ID;
            parameters[1].Value = PBC_Code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Basic_Code model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PB_Basic_Code(");
            strSql.Append("PBC_ID,PBC_Code,PBC_Name,PBC_Order,PBC_Del,PBC_Details,PBC_CName,PBC_FID,PBC_FCode)");
            strSql.Append(" values (");
            strSql.Append("@PBC_ID,@PBC_Code,@PBC_Name,@PBC_Order,@PBC_Del,@PBC_Details,@PBC_CName,@PBC_FID,@PBC_FCode)");
            SqlParameter[] parameters = {
					new SqlParameter("@PBC_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_Code", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_Name", SqlDbType.VarChar,150),
					new SqlParameter("@PBC_Order", SqlDbType.Int,4),
					new SqlParameter("@PBC_Del", SqlDbType.Int,4),
					new SqlParameter("@PBC_Details", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_CName", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_FID", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_FCode", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PBC_ID;
            parameters[1].Value = model.PBC_Code;
            parameters[2].Value = model.PBC_Name;
            parameters[3].Value = model.PBC_Order;
            parameters[4].Value = model.PBC_Del;
            parameters[5].Value = model.PBC_Details;
            parameters[6].Value = model.PBC_CName;
            parameters[7].Value = model.PBC_FID;
            parameters[8].Value = model.PBC_FCode;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Basic_Code model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PB_Basic_Code set ");
            strSql.Append("PBC_ID=@PBC_ID,");
            strSql.Append("PBC_Code=@PBC_Code,");
            strSql.Append("PBC_Name=@PBC_Name,");
            strSql.Append("PBC_Order=@PBC_Order,");
            strSql.Append("PBC_Del=@PBC_Del,");
            strSql.Append("PBC_Details=@PBC_Details,");
            strSql.Append("PBC_FID=@PBC_FID,");
            strSql.Append("PBC_FCode=@PBC_FCode,");
            strSql.Append("PBC_CName=@PBC_CName");
            strSql.Append(" where PBC_ID=@PBC_ID and PBC_Code=@PBC_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBC_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_Code", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_Name", SqlDbType.VarChar,150),
					new SqlParameter("@PBC_Order", SqlDbType.Int,4),
					new SqlParameter("@PBC_Del", SqlDbType.Int,4),
					new SqlParameter("@PBC_Details", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_FID", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_FCode", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_CName", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PBC_ID;
            parameters[1].Value = model.PBC_Code;
            parameters[2].Value = model.PBC_Name;
            parameters[3].Value = model.PBC_Order;
            parameters[4].Value = model.PBC_Del;
            parameters[5].Value = model.PBC_Details;
            parameters[6].Value = model.PBC_FID;
            parameters[7].Value = model.PBC_FCode;
            parameters[8].Value = model.PBC_CName;

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
        public bool Delete(string PBC_ID, string PBC_Code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_Code ");
            strSql.Append(" where PBC_ID=@PBC_ID and PBC_Code=@PBC_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBC_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = PBC_ID;
            parameters[1].Value = PBC_Code;

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
        /// 得到一个最大编码值
        /// </summary>
        public string GetMaxCodeByID(string PBC_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from PB_Basic_Code ");
            strSql.Append(" where PBC_ID=@PBC_ID Order by cast(PBC_Code as int) desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBC_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBC_ID;

            KNet.Model.PB_Basic_Code model = new KNet.Model.PB_Basic_Code();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["PBC_Code"] == null ? "0" : ds.Tables[0].Rows[0]["PBC_Code"].ToString();
            }
            else
            {
                return "0";
            }
        }


        /// <summary>
        /// 得到一个最大编码值
        /// </summary>
        public string GetMaxID()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from PB_Basic_Code ");
            strSql.Append(" Order by cast(PBC_ID as int) desc ");

            KNet.Model.PB_Basic_Code model = new KNet.Model.PB_Basic_Code();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {

                return ds.Tables[0].Rows[0]["PBC_ID"] == null ? "0" : ds.Tables[0].Rows[0]["PBC_ID"].ToString();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.PB_Basic_Code GetModel(string PBC_ID, string PBC_Code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from PB_Basic_Code ");
            strSql.Append(" where PBC_ID=@PBC_ID and PBC_Code=@PBC_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBC_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PBC_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = PBC_ID;
            parameters[1].Value = PBC_Code;

            KNet.Model.PB_Basic_Code model = new KNet.Model.PB_Basic_Code();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PBC_ID"] != null && ds.Tables[0].Rows[0]["PBC_ID"].ToString() != "")
                {
                    model.PBC_ID = ds.Tables[0].Rows[0]["PBC_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBC_Code"] != null && ds.Tables[0].Rows[0]["PBC_Code"].ToString() != "")
                {
                    model.PBC_Code = ds.Tables[0].Rows[0]["PBC_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBC_Name"] != null && ds.Tables[0].Rows[0]["PBC_Name"].ToString() != "")
                {
                    model.PBC_Name = ds.Tables[0].Rows[0]["PBC_Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBC_Order"] != null && ds.Tables[0].Rows[0]["PBC_Order"].ToString() != "")
                {
                    model.PBC_Order = int.Parse(ds.Tables[0].Rows[0]["PBC_Order"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBC_Del"] != null && ds.Tables[0].Rows[0]["PBC_Del"].ToString() != "")
                {
                    model.PBC_Del = int.Parse(ds.Tables[0].Rows[0]["PBC_Del"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBC_Details"] != null && ds.Tables[0].Rows[0]["PBC_Details"].ToString() != "")
                {
                    model.PBC_Details = ds.Tables[0].Rows[0]["PBC_Details"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBC_CName"] != null && ds.Tables[0].Rows[0]["PBC_CName"].ToString() != "")
                {
                    model.PBC_CName = ds.Tables[0].Rows[0]["PBC_CName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBC_FID"] != null && ds.Tables[0].Rows[0]["PBC_FID"].ToString() != "")
                {
                    model.PBC_FID = ds.Tables[0].Rows[0]["PBC_FID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBC_FCode"] != null && ds.Tables[0].Rows[0]["PBC_FCode"].ToString() != "")
                {
                    model.PBC_FCode = ds.Tables[0].Rows[0]["PBC_FCode"].ToString();
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
            strSql.Append(" FROM PB_Basic_Code ");
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
            strSql.Append(" PBC_ID,PBC_Code,PBC_Name,PBC_Order,PBC_Del,PBC_Details,PBC_CName ");
            strSql.Append(" FROM PB_Basic_Code ");
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
            parameters[0].Value = "PB_Basic_Code";
            parameters[1].Value = "PBC_Code";
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


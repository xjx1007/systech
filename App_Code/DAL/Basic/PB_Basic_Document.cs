using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:PB_Basic_Document
    /// </summary>
    public partial class PB_Basic_Document
    {
        public PB_Basic_Document()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBM_Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PB_Basic_Document");
            strSql.Append(" where PBM_Name=@PBM_Name and PBM_Del='0' ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBM_Name", SqlDbType.VarChar,50)};
            parameters[0].Value = PBM_Name;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Basic_Document model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PB_Basic_Document(");
            strSql.Append("PBM_Code,PBM_Name,PBM_Type,PBM_DutyPerson,PBM_Details,PBM_Del,PBM_CTime,PBM_Creator,PBM_Mtime,PBM_Mender,PBM_DocName,PBM_Visio,PBM_FatherID)");
            strSql.Append(" values (");
            strSql.Append("@PBM_Code,@PBM_Name,@PBM_Type,@PBM_DutyPerson,@PBM_Details,@PBM_Del,@PBM_CTime,@PBM_Creator,@PBM_Mtime,@PBM_Mender,@PBM_DocName,@PBM_Visio,@PBM_FatherID)");
            SqlParameter[] parameters = {
					new SqlParameter("@PBM_Code", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_Name", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_Type", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_Details", SqlDbType.VarChar,3000),
					new SqlParameter("@PBM_Del", SqlDbType.VarChar,1),
					new SqlParameter("@PBM_CTime", SqlDbType.DateTime),
					new SqlParameter("@PBM_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_Mtime", SqlDbType.DateTime),
					new SqlParameter("@PBM_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_DocName", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_Visio", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_FatherID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PBM_Code;
            parameters[1].Value = model.PBM_Name;
            parameters[2].Value = model.PBM_Type;
            parameters[3].Value = model.PBM_DutyPerson;
            parameters[4].Value = model.PBM_Details;
            parameters[5].Value = model.PBM_Del;
            parameters[6].Value = model.PBM_CTime;
            parameters[7].Value = model.PBM_Creator;
            parameters[8].Value = model.PBM_Mtime;
            parameters[9].Value = model.PBM_Mender;
            parameters[10].Value = model.PBM_DocName;
            parameters[11].Value = model.PBM_Visio;
            parameters[12].Value = model.PBM_FatherID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Basic_Document model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PB_Basic_Document set ");
            strSql.Append("PBM_Name=@PBM_Name,");
            strSql.Append("PBM_Type=@PBM_Type,");
            strSql.Append("PBM_DutyPerson=@PBM_DutyPerson,");
            strSql.Append("PBM_Details=@PBM_Details,");
            strSql.Append("PBM_DocName=@PBM_DocName,");
            strSql.Append("PBM_Visio=@PBM_Visio,");
            strSql.Append("PBM_FatherID=@PBM_FatherID,");
            strSql.Append("PBM_Mtime=@PBM_Mtime,");
            strSql.Append("PBM_Mender=@PBM_Mender");
            strSql.Append(" where PBM_Code=@PBM_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBM_Name", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_Type", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_Details", SqlDbType.VarChar,3000),
					new SqlParameter("@PBM_DocName", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_Visio", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_FatherID", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_Mtime", SqlDbType.DateTime),
					new SqlParameter("@PBM_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = model.PBM_Name;
            parameters[1].Value = model.PBM_Type;
            parameters[2].Value = model.PBM_DutyPerson;
            parameters[3].Value = model.PBM_Details;
            parameters[4].Value = model.PBM_DocName;
            parameters[5].Value = model.PBM_Visio;
            parameters[6].Value = model.PBM_FatherID;
            parameters[7].Value = model.PBM_Mtime;
            parameters[8].Value = model.PBM_Mender;
            parameters[9].Value = model.PBM_Code;

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
        public bool Delete(string PBM_Code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_Document ");
            strSql.Append(" where PBM_Code=@PBM_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBM_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = PBM_Code;

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
        public bool DeleteList(string PBM_Codelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_Document ");
            strSql.Append(" where PBM_Code in (" + PBM_Codelist + ")  ");
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
        public KNet.Model.PB_Basic_Document GetModel(string PBM_Code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from PB_Basic_Document ");
            strSql.Append(" where PBM_Code=@PBM_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBM_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = PBM_Code;

            KNet.Model.PB_Basic_Document model = new KNet.Model.PB_Basic_Document();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PBM_Code"] != null && ds.Tables[0].Rows[0]["PBM_Code"].ToString() != "")
                {
                    model.PBM_Code = ds.Tables[0].Rows[0]["PBM_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_Name"] != null && ds.Tables[0].Rows[0]["PBM_Name"].ToString() != "")
                {
                    model.PBM_Name = ds.Tables[0].Rows[0]["PBM_Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_Type"] != null && ds.Tables[0].Rows[0]["PBM_Type"].ToString() != "")
                {
                    model.PBM_Type = ds.Tables[0].Rows[0]["PBM_Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_DutyPerson"] != null && ds.Tables[0].Rows[0]["PBM_DutyPerson"].ToString() != "")
                {
                    model.PBM_DutyPerson = ds.Tables[0].Rows[0]["PBM_DutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_Details"] != null && ds.Tables[0].Rows[0]["PBM_Details"].ToString() != "")
                {
                    model.PBM_Details = ds.Tables[0].Rows[0]["PBM_Details"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_Del"] != null && ds.Tables[0].Rows[0]["PBM_Del"].ToString() != "")
                {
                    model.PBM_Del = ds.Tables[0].Rows[0]["PBM_Del"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_CTime"] != null && ds.Tables[0].Rows[0]["PBM_CTime"].ToString() != "")
                {
                    model.PBM_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["PBM_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBM_Creator"] != null && ds.Tables[0].Rows[0]["PBM_Creator"].ToString() != "")
                {
                    model.PBM_Creator = ds.Tables[0].Rows[0]["PBM_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_Mtime"] != null && ds.Tables[0].Rows[0]["PBM_Mtime"].ToString() != "")
                {
                    model.PBM_Mtime = DateTime.Parse(ds.Tables[0].Rows[0]["PBM_Mtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBM_Mender"] != null && ds.Tables[0].Rows[0]["PBM_Mender"].ToString() != "")
                {
                    model.PBM_Mender = ds.Tables[0].Rows[0]["PBM_Mender"].ToString();
                }

                if (ds.Tables[0].Rows[0]["PBM_DocName"] != null && ds.Tables[0].Rows[0]["PBM_DocName"].ToString() != "")
                {
                    model.PBM_DocName = ds.Tables[0].Rows[0]["PBM_DocName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_Visio"] != null && ds.Tables[0].Rows[0]["PBM_Visio"].ToString() != "")
                {
                    model.PBM_Visio = ds.Tables[0].Rows[0]["PBM_Visio"].ToString();
                }
                else
                {
                    model.PBM_Visio = "";
                }
                if (ds.Tables[0].Rows[0]["PBM_FatherID"] != null && ds.Tables[0].Rows[0]["PBM_FatherID"].ToString() != "")
                {
                    model.PBM_FatherID = ds.Tables[0].Rows[0]["PBM_FatherID"].ToString();
                }
                else
                {
                    model.PBM_FatherID = "";
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
        public string GetDocumentName(string PBM_Code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from PB_Basic_Document ");
            strSql.Append(" where PBM_Code=@PBM_Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBM_Code", SqlDbType.VarChar,50)};
            parameters[0].Value = PBM_Code;
            string s_Retrun = "";

            KNet.Model.PB_Basic_Document model = new KNet.Model.PB_Basic_Document();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PBM_DocName"] != null && ds.Tables[0].Rows[0]["PBM_DocName"].ToString() != "")
                {
                    s_Retrun = ds.Tables[0].Rows[0]["PBM_DocName"].ToString();
                }

            }
            else
            {
                s_Retrun = "";
            }
            return s_Retrun;
        }
         
        /// <summary>
        /// 得到一个上一个名字相同的
        /// </summary>
        public KNet.Model.PB_Basic_Document GetLastModel(string PBM_Name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from PB_Basic_Document ");
            strSql.Append(" where PBM_Name=@PBM_Name  order by PBM_Visio Desc");
            SqlParameter[] parameters = {
					new SqlParameter("@PBM_Name", SqlDbType.VarChar,50)};
            parameters[0].Value = PBM_Name;

            KNet.Model.PB_Basic_Document model = new KNet.Model.PB_Basic_Document();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PBM_Code"] != null && ds.Tables[0].Rows[0]["PBM_Code"].ToString() != "")
                {
                    model.PBM_Code = ds.Tables[0].Rows[0]["PBM_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_Name"] != null && ds.Tables[0].Rows[0]["PBM_Name"].ToString() != "")
                {
                    model.PBM_Name = ds.Tables[0].Rows[0]["PBM_Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_Type"] != null && ds.Tables[0].Rows[0]["PBM_Type"].ToString() != "")
                {
                    model.PBM_Type = ds.Tables[0].Rows[0]["PBM_Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_DutyPerson"] != null && ds.Tables[0].Rows[0]["PBM_DutyPerson"].ToString() != "")
                {
                    model.PBM_DutyPerson = ds.Tables[0].Rows[0]["PBM_DutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_Details"] != null && ds.Tables[0].Rows[0]["PBM_Details"].ToString() != "")
                {
                    model.PBM_Details = ds.Tables[0].Rows[0]["PBM_Details"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_Del"] != null && ds.Tables[0].Rows[0]["PBM_Del"].ToString() != "")
                {
                    model.PBM_Del = ds.Tables[0].Rows[0]["PBM_Del"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_CTime"] != null && ds.Tables[0].Rows[0]["PBM_CTime"].ToString() != "")
                {
                    model.PBM_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["PBM_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBM_Creator"] != null && ds.Tables[0].Rows[0]["PBM_Creator"].ToString() != "")
                {
                    model.PBM_Creator = ds.Tables[0].Rows[0]["PBM_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_Mtime"] != null && ds.Tables[0].Rows[0]["PBM_Mtime"].ToString() != "")
                {
                    model.PBM_Mtime = DateTime.Parse(ds.Tables[0].Rows[0]["PBM_Mtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBM_Mender"] != null && ds.Tables[0].Rows[0]["PBM_Mender"].ToString() != "")
                {
                    model.PBM_Mender = ds.Tables[0].Rows[0]["PBM_Mender"].ToString();
                }

                if (ds.Tables[0].Rows[0]["PBM_DocName"] != null && ds.Tables[0].Rows[0]["PBM_DocName"].ToString() != "")
                {
                    model.PBM_DocName = ds.Tables[0].Rows[0]["PBM_DocName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_Visio"] != null && ds.Tables[0].Rows[0]["PBM_Visio"].ToString() != "")
                {
                    model.PBM_Visio = ds.Tables[0].Rows[0]["PBM_Visio"].ToString();
                }
                else
                {
                    model.PBM_Visio = "";
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
            strSql.Append(" FROM PB_Basic_Document ");
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
            strSql.Append(" PBM_Code,PBM_Name,PBM_Type,PBM_DutyPerson,PBM_Details,PBM_Del,PBM_CTime,PBM_Creator,PBM_Mtime,PBM_Mender ");
            strSql.Append(" FROM PB_Basic_Document ");
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
            parameters[0].Value = "PB_Basic_Document";
            parameters[1].Value = "PBM_Code";
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


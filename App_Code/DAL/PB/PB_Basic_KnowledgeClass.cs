using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:PB_Basic_KnowledgeClass
    /// </summary>
    public partial class PB_Basic_KnowledgeClass
    {
        public PB_Basic_KnowledgeClass()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBK_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PB_Basic_KnowledgeClass");
            strSql.Append(" where PBK_ID=@PBK_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBK_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBK_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Basic_KnowledgeClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PB_Basic_KnowledgeClass(");
            strSql.Append("PBK_ID,PBK_Code,PBK_Name,PBK_FaterID,PBK_Order,PBK_Creator,PBK_CTime,PBK_MTime,PBK_Mender,PBK_Days)");
            strSql.Append(" values (");
            strSql.Append("@PBK_ID,@PBK_Code,@PBK_Name,@PBK_FaterID,@PBK_Order,@PBK_Creator,@PBK_CTime,@PBK_MTime,@PBK_Mender,@PBK_Days)");
            SqlParameter[] parameters = {
					new SqlParameter("@PBK_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PBK_Code", SqlDbType.VarChar,50),
					new SqlParameter("@PBK_Name", SqlDbType.VarChar,50),
					new SqlParameter("@PBK_FaterID", SqlDbType.VarChar,50),
					new SqlParameter("@PBK_Order", SqlDbType.VarChar,50),
					new SqlParameter("@PBK_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@PBK_CTime", SqlDbType.DateTime),
					new SqlParameter("@PBK_MTime", SqlDbType.DateTime),
					new SqlParameter("@PBK_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@PBK_Days", SqlDbType.Int,4)};
            parameters[0].Value = model.PBK_ID;
            parameters[1].Value = model.PBK_Code;
            parameters[2].Value = model.PBK_Name;
            parameters[3].Value = model.PBK_FaterID;
            parameters[4].Value = model.PBK_Order;
            parameters[5].Value = model.PBK_Creator;
            parameters[6].Value = model.PBK_CTime;
            parameters[7].Value = model.PBK_MTime;
            parameters[8].Value = model.PBK_Mender;
            parameters[9].Value = model.PBK_Days;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsFaterID(string PBK_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PB_Basic_KnowledgeClass");
            strSql.Append(" where PBK_FaterID=@PBK_FaterID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBK_FaterID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBK_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string GetSonID(string PBK_ID, int i_Type)
        {
            string s_ID = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   * from PB_Basic_KnowledgeClass ");
            strSql.Append(" where PBK_FaterID=@PBK_FaterID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBK_FaterID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBK_ID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    if (ds.Tables[0].Rows[i]["PBK_ID"] != null && ds.Tables[0].Rows[i]["PBK_ID"].ToString() != "")
                    {
                        if (i_Type == 0)
                        {
                            s_ID += "H" + ds.Tables[0].Rows[i]["PBK_ID"].ToString() + ",";
                        }
                        else if (i_Type == 2)
                        {
                            s_ID += ds.Tables[0].Rows[i]["PBK_ID"].ToString() + ",";
                        }
                        else
                        {
                            s_ID += "img_H" + ds.Tables[0].Rows[i]["PBK_ID"].ToString() + ",";
                        }
                    }
                    else
                    {
                        s_ID += "";
                    }
                }
                s_ID = s_ID.Substring(0, s_ID.Length - 1);

                return s_ID;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string GetSonIDs(string PBK_ID)
        {
            string s_ID = PBK_ID + ",";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   * from PB_Basic_KnowledgeClass ");
            strSql.Append(" where PBK_FaterID=@PBK_FaterID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBK_FaterID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBK_ID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    if (ds.Tables[0].Rows[i]["PBK_ID"] != null && ds.Tables[0].Rows[i]["PBK_ID"].ToString() != "")
                    {
                        //s_ID += ds.Tables[0].Rows[i]["PBK_ID"].ToString() + ",";
                        s_ID += GetSonIDs(ds.Tables[0].Rows[i]["PBK_ID"].ToString()) + ",";
                    }
                    else
                    {
                        s_ID += "";
                    }
                }
                s_ID = s_ID.Substring(0, s_ID.Length - 1);

                return s_ID;
            }
            else
            {
                return PBK_ID;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Basic_KnowledgeClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PB_Basic_KnowledgeClass set ");
            strSql.Append("PBK_ID=@PBK_ID,");
            strSql.Append("PBK_Code=@PBK_Code,");
            strSql.Append("PBK_Name=@PBK_Name,");
            strSql.Append("PBK_FaterID=@PBK_FaterID,");
            strSql.Append("PBK_Order=@PBK_Order,");
            strSql.Append("PBK_Creator=@PBK_Creator,");
            strSql.Append("PBK_CTime=@PBK_CTime,");
            strSql.Append("PBK_MTime=@PBK_MTime,");
            strSql.Append("PBK_Mender=@PBK_Mender,");
            strSql.Append("PBK_Days=@PBK_Days");
            strSql.Append(" where PBK_ID=@PBK_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBK_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PBK_Code", SqlDbType.VarChar,50),
					new SqlParameter("@PBK_Name", SqlDbType.VarChar,50),
					new SqlParameter("@PBK_FaterID", SqlDbType.VarChar,50),
					new SqlParameter("@PBK_Order", SqlDbType.VarChar,50),
					new SqlParameter("@PBK_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@PBK_CTime", SqlDbType.DateTime),
					new SqlParameter("@PBK_MTime", SqlDbType.DateTime),
					new SqlParameter("@PBK_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@PBK_Days", SqlDbType.Int,4)};
            parameters[0].Value = model.PBK_ID;
            parameters[1].Value = model.PBK_Code;
            parameters[2].Value = model.PBK_Name;
            parameters[3].Value = model.PBK_FaterID;
            parameters[4].Value = model.PBK_Order;
            parameters[5].Value = model.PBK_Creator;
            parameters[6].Value = model.PBK_CTime;
            parameters[7].Value = model.PBK_MTime;
            parameters[8].Value = model.PBK_Mender;
            parameters[9].Value = model.PBK_Days;

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
        public bool Delete(string PBK_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_KnowledgeClass ");
            strSql.Append(" where PBK_ID=@PBK_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBK_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBK_ID;

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
        public bool DeleteList(string PBK_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_KnowledgeClass ");
            strSql.Append(" where PBK_ID in (" + PBK_IDlist + ")  ");
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
        public KNet.Model.PB_Basic_KnowledgeClass GetModel(string PBK_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PBK_ID,PBK_Code,PBK_Name,PBK_FaterID,PBK_Order,PBK_Creator,PBK_CTime,PBK_MTime,PBK_Mender,PBK_Days from PB_Basic_KnowledgeClass ");
            strSql.Append(" where PBK_ID=@PBK_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBK_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBK_ID;

            KNet.Model.PB_Basic_KnowledgeClass model = new KNet.Model.PB_Basic_KnowledgeClass();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PBK_ID"] != null && ds.Tables[0].Rows[0]["PBK_ID"].ToString() != "")
                {
                    model.PBK_ID = ds.Tables[0].Rows[0]["PBK_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBK_Code"] != null && ds.Tables[0].Rows[0]["PBK_Code"].ToString() != "")
                {
                    model.PBK_Code = ds.Tables[0].Rows[0]["PBK_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBK_Name"] != null && ds.Tables[0].Rows[0]["PBK_Name"].ToString() != "")
                {
                    model.PBK_Name = ds.Tables[0].Rows[0]["PBK_Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBK_FaterID"] != null && ds.Tables[0].Rows[0]["PBK_FaterID"].ToString() != "")
                {
                    model.PBK_FaterID = ds.Tables[0].Rows[0]["PBK_FaterID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBK_Order"] != null && ds.Tables[0].Rows[0]["PBK_Order"].ToString() != "")
                {
                    model.PBK_Order = ds.Tables[0].Rows[0]["PBK_Order"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBK_Creator"] != null && ds.Tables[0].Rows[0]["PBK_Creator"].ToString() != "")
                {
                    model.PBK_Creator = ds.Tables[0].Rows[0]["PBK_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBK_CTime"] != null && ds.Tables[0].Rows[0]["PBK_CTime"].ToString() != "")
                {
                    model.PBK_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["PBK_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBK_MTime"] != null && ds.Tables[0].Rows[0]["PBK_MTime"].ToString() != "")
                {
                    model.PBK_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["PBK_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBK_Mender"] != null && ds.Tables[0].Rows[0]["PBK_Mender"].ToString() != "")
                {
                    model.PBK_Mender = ds.Tables[0].Rows[0]["PBK_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBK_Days"] != null && ds.Tables[0].Rows[0]["PBK_Days"].ToString() != "")
                {
                    model.PBK_Days = int.Parse(ds.Tables[0].Rows[0]["PBK_Days"].ToString());
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
            strSql.Append("select PBK_ID,PBK_Code,PBK_Name,PBK_FaterID,PBK_Order,PBK_Creator,PBK_CTime,PBK_MTime,PBK_Mender,PBK_Days ");
            strSql.Append(" FROM PB_Basic_KnowledgeClass ");
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
            strSql.Append(" PBK_ID,PBK_Code,PBK_Name,PBK_FaterID,PBK_Order,PBK_Creator,PBK_CTime,PBK_MTime,PBK_Mender,PBK_Days ");
            strSql.Append(" FROM PB_Basic_KnowledgeClass ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string GetMaxCode(string PBK_ID)
        {

            StringBuilder strSql = new StringBuilder();
            KNet.Model.PB_Basic_KnowledgeClass model = new KNet.Model.PB_Basic_KnowledgeClass();
            strSql.Append("select  Max(cast('1'+PBK_Code as int)) as PBK_Code  from PB_Basic_KnowledgeClass ");
            strSql.Append(" where PBK_ID=@PBK_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBK_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBK_ID;

            string s_ParentCode = "", s_MaxCode = "";
            DataSet ds1 = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds1.Tables[0].Rows[0]["PBK_Code"] != null && ds1.Tables[0].Rows[0]["PBK_Code"].ToString() != "")
                {
                    s_ParentCode = ds1.Tables[0].Rows[0]["PBK_Code"].ToString();
                }
            }
            strSql.Clear();
            strSql.Append("select  Max(cast('1'+PBK_Code as int)) PBK_Code  from PB_Basic_KnowledgeClass ");
            strSql.Append(" where PBK_FaterID=@PBK_FaterID ");
            SqlParameter[] parameters1 = {
					new SqlParameter("@PBK_FaterID", SqlDbType.VarChar,50)};
            parameters1[0].Value = PBK_ID;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PBK_Code"] != null && ds.Tables[0].Rows[0]["PBK_Code"].ToString() != "")
                {
                    s_MaxCode = Convert.ToString(int.Parse(ds.Tables[0].Rows[0]["PBK_Code"].ToString()) + 1);
                }
                else
                {
                    s_MaxCode = s_ParentCode + "01";
                }

                return s_MaxCode.Substring(1, s_MaxCode.Length - 1);
            }
            else
            {
                return "01";
            }
        }

        public string GetTypeName(string PBK_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from PB_Basic_KnowledgeClass ");
            strSql.Append(" where PBK_ID=@PBK_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBK_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBK_ID;

            KNet.Model.PB_Basic_KnowledgeClass model = new KNet.Model.PB_Basic_KnowledgeClass();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PBK_Name"] != null && ds.Tables[0].Rows[0]["PBK_Name"].ToString() != "")
                {
                    model.PBK_Name = ds.Tables[0].Rows[0]["PBK_Name"].ToString();
                }
                else
                {
                    model.PBK_Name = "";
                }

                return model.PBK_Name;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string GetMaxOrder(string PBK_ID)
        {
            string s_MaxCode = "";
            StringBuilder strSql = new StringBuilder();
            KNet.Model.PB_Basic_KnowledgeClass model = new KNet.Model.PB_Basic_KnowledgeClass();
            strSql.Append("select  Max(cast(PBK_Order as int)) PBK_Code  from PB_Basic_KnowledgeClass ");
            strSql.Append(" where PBK_FaterID=@PBK_FaterID ");
            SqlParameter[] parameters1 = {
					new SqlParameter("@PBK_FaterID", SqlDbType.VarChar,50)};
            parameters1[0].Value = PBK_ID;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PBK_Code"] != null && ds.Tables[0].Rows[0]["PBK_Code"].ToString() != "")
                {
                    s_MaxCode = Convert.ToString(int.Parse(ds.Tables[0].Rows[0]["PBK_Code"].ToString()) + 1);
                }
                else
                {
                    s_MaxCode = "0";
                }

                return s_MaxCode;
            }
            else
            {
                return "0";
            }
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
            parameters[0].Value = "PB_Basic_KnowledgeClass";
            parameters[1].Value = "PBK_ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/
        public string GetKnowledgeName(string PBK_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from PB_Basic_KnowledgeClass ");
            strSql.Append(" where PBK_ID=@PBK_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBK_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBK_ID;

            KNet.Model.PB_Basic_KnowledgeClass model = new KNet.Model.PB_Basic_KnowledgeClass();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PBK_Name"] != null && ds.Tables[0].Rows[0]["PBK_Name"].ToString() != "")
                {
                    model.PBK_Name = ds.Tables[0].Rows[0]["PBK_Name"].ToString();
                }
                else
                {
                    model.PBK_Name = "";
                }

                return model.PBK_Name;
            }
            else
            {
                return "";
            }
        #endregion  Method
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
    }
}


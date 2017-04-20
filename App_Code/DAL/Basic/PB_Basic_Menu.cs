using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:PB_Basic_Menu
    /// </summary>
    public partial class PB_Basic_Menu
    {
        public PB_Basic_Menu()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PB_Basic_Menu");
            strSql.Append(" where PBM_ID=@PBM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBM_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Basic_Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PB_Basic_Menu(");
            strSql.Append("PBM_ID,PBM_FatherID,PBM_Name,PBM_Module,PBM_Parenttab,PBM_URL,PBM_Del, PBM_Order,PBM_CTime,PBM_MTime, PBM_Creator, PBM_Mender, PBM_ColSpan, PBM_RowSpan, PBM_Level, PBM_IsChild, PBM_Icon)");
            strSql.Append(" values (");
            strSql.Append("@PBM_ID,@PBM_FatherID,@PBM_Name,@PBM_Module,@PBM_Parenttab,@PBM_URL,@PBM_Del,@PBM_Order,@PBM_CTime,@PBM_MTime, @PBM_Creator, @PBM_Mender, @PBM_ColSpan, @PBM_RowSpan, @PBM_Level, @PBM_IsChild, @PBM_Icon)");
            SqlParameter[] parameters = {
					new SqlParameter("@PBM_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_FatherID", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_Name", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_Module", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_Parenttab", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_URL", SqlDbType.VarChar,200),
					new SqlParameter("@PBM_Del", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_Order", SqlDbType.Int),
					new SqlParameter("@PBM_CTime", SqlDbType.DateTime),
					new SqlParameter("@PBM_MTime", SqlDbType.DateTime),
					new SqlParameter("@PBM_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_ColSpan", SqlDbType.Int),
					new SqlParameter("@PBM_RowSpan", SqlDbType.Int),
					new SqlParameter("@PBM_Level", SqlDbType.Int),
					new SqlParameter("@PBM_IsChild", SqlDbType.Int),
					new SqlParameter("@PBM_Icon", SqlDbType.VarChar,150)};
            parameters[0].Value = model.PBM_ID;
            parameters[1].Value = model.PBM_FatherID;
            parameters[2].Value = model.PBM_Name;
            parameters[3].Value = model.PBM_Module;
            parameters[4].Value = model.PBM_Parenttab;
            parameters[5].Value = model.PBM_URL;
            parameters[6].Value = model.PBM_Del;
            parameters[7].Value = model.PBM_Order;
            parameters[8].Value = model.PBM_CTime;
            parameters[9].Value = model.PBM_MTime;
            parameters[10].Value = model.PBM_Creator;
            parameters[11].Value = model.PBM_Mender;
            parameters[12].Value = model.PBM_ColSpan;
            parameters[13].Value = model.PBM_RowSpan;
            parameters[14].Value = model.PBM_Level;
            parameters[15].Value = model.PBM_IsChild;
            parameters[16].Value = model.PBM_Icon;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Basic_Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PB_Basic_Menu set ");
            strSql.Append("PBM_FatherID=@PBM_FatherID,");
            strSql.Append("PBM_Name=@PBM_Name,");
            strSql.Append("PBM_Module=@PBM_Module,");
            strSql.Append("PBM_Parenttab=@PBM_Parenttab,");
            strSql.Append("PBM_URL=@PBM_URL,");
            strSql.Append("PBM_Del=@PBM_Del,");
            strSql.Append("PBM_Order=@PBM_Order,");
            strSql.Append("PBM_CTime=@PBM_CTime,");
            strSql.Append("PBM_MTime=@PBM_MTime,");
            strSql.Append("PBM_Creator=@PBM_Creator,");
            strSql.Append("PBM_Mender=@PBM_Mender,");
            strSql.Append("PBM_ColSpan=@PBM_ColSpan,");
            strSql.Append("PBM_RowSpan=@PBM_RowSpan,");
            strSql.Append("PBM_Level=@PBM_Level,");
            strSql.Append("PBM_IsChild=@PBM_IsChild,");
            strSql.Append("PBM_Icon=@PBM_Icon");
            strSql.Append(" where PBM_ID=@PBM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBM_FatherID", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_Name", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_Module", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_Parenttab", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_URL", SqlDbType.VarChar,200),
					new SqlParameter("@PBM_Del", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_ID", SqlDbType.VarChar,50),
                    new SqlParameter("@PBM_Order", SqlDbType.Int),
					new SqlParameter("@PBM_CTime", SqlDbType.DateTime),
					new SqlParameter("@PBM_MTime", SqlDbType.DateTime),
					new SqlParameter("@PBM_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@PBM_ColSpan", SqlDbType.Int),
					new SqlParameter("@PBM_RowSpan", SqlDbType.Int),
					new SqlParameter("@PBM_Level", SqlDbType.Int),
					new SqlParameter("@PBM_IsChild", SqlDbType.Int),
					new SqlParameter("@PBM_Icon", SqlDbType.VarChar,150)                           };
            parameters[0].Value = model.PBM_FatherID;
            parameters[1].Value = model.PBM_Name;
            parameters[2].Value = model.PBM_Module;
            parameters[3].Value = model.PBM_Parenttab;
            parameters[4].Value = model.PBM_URL;
            parameters[5].Value = model.PBM_Del;
            parameters[6].Value = model.PBM_ID;
            parameters[7].Value = model.PBM_Order;
            parameters[8].Value = model.PBM_CTime;
            parameters[9].Value = model.PBM_MTime;
            parameters[10].Value = model.PBM_Creator;
            parameters[11].Value = model.PBM_Mender;
            parameters[12].Value = model.PBM_ColSpan;
            parameters[13].Value = model.PBM_RowSpan;
            parameters[14].Value = model.PBM_Level;
            parameters[15].Value = model.PBM_IsChild;
            parameters[16].Value = model.PBM_Icon;

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
        public bool Delete(string PBM_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_Menu ");
            strSql.Append(" where PBM_ID=@PBM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBM_ID;

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
        public bool DeleteList(string PBM_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Basic_Menu ");
            strSql.Append(" where PBM_ID in (" + PBM_IDlist + ")  ");
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
        public KNet.Model.PB_Basic_Menu GetModel(string PBM_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PBM_ID,PBM_FatherID,PBM_Name,PBM_Module,PBM_Parenttab,PBM_URL,PBM_Del from PB_Basic_Menu ");
            strSql.Append(" where PBM_ID=@PBM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = PBM_ID;

            KNet.Model.PB_Basic_Menu model = new KNet.Model.PB_Basic_Menu();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PBM_ID"] != null && ds.Tables[0].Rows[0]["PBM_ID"].ToString() != "")
                {
                    model.PBM_ID = ds.Tables[0].Rows[0]["PBM_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_FatherID"] != null && ds.Tables[0].Rows[0]["PBM_FatherID"].ToString() != "")
                {
                    model.PBM_FatherID = ds.Tables[0].Rows[0]["PBM_FatherID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_Name"] != null && ds.Tables[0].Rows[0]["PBM_Name"].ToString() != "")
                {
                    model.PBM_Name = ds.Tables[0].Rows[0]["PBM_Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_Module"] != null && ds.Tables[0].Rows[0]["PBM_Module"].ToString() != "")
                {
                    model.PBM_Module = ds.Tables[0].Rows[0]["PBM_Module"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_Parenttab"] != null && ds.Tables[0].Rows[0]["PBM_Parenttab"].ToString() != "")
                {
                    model.PBM_Parenttab = ds.Tables[0].Rows[0]["PBM_Parenttab"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_URL"] != null && ds.Tables[0].Rows[0]["PBM_URL"].ToString() != "")
                {
                    model.PBM_URL = ds.Tables[0].Rows[0]["PBM_URL"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_Del"] != null && ds.Tables[0].Rows[0]["PBM_Del"].ToString() != "")
                {
                    model.PBM_Del = ds.Tables[0].Rows[0]["PBM_Del"].ToString();
                }

                if (ds.Tables[0].Rows[0]["PBM_Order"] != null && ds.Tables[0].Rows[0]["PBM_Order"].ToString() != "")
                {
                    model.PBM_Order = Convert.ToInt32(ds.Tables[0].Rows[0]["PBM_Order"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBM_CTime"] != null && ds.Tables[0].Rows[0]["PBM_CTime"].ToString() != "")
                {
                    model.PBM_CTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["PBM_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBM_MTime"] != null && ds.Tables[0].Rows[0]["PBM_MTime"].ToString() != "")
                {
                    model.PBM_MTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["PBM_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBM_Creator"] != null && ds.Tables[0].Rows[0]["PBM_Creator"].ToString() != "")
                {
                    model.PBM_Creator = ds.Tables[0].Rows[0]["PBM_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_Mender"] != null && ds.Tables[0].Rows[0]["PBM_Mender"].ToString() != "")
                {
                    model.PBM_Mender = ds.Tables[0].Rows[0]["PBM_Mender"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PBM_ColSpan"] != null && ds.Tables[0].Rows[0]["PBM_ColSpan"].ToString() != "")
                {
                    model.PBM_ColSpan = Convert.ToInt32(ds.Tables[0].Rows[0]["PBM_ColSpan"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBM_RowSpan"] != null && ds.Tables[0].Rows[0]["PBM_RowSpan"].ToString() != "")
                {
                    model.PBM_RowSpan = Convert.ToInt32(ds.Tables[0].Rows[0]["PBM_RowSpan"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBM_Level"] != null && ds.Tables[0].Rows[0]["PBM_Level"].ToString() != "")
                {
                    model.PBM_Level = Convert.ToInt32(ds.Tables[0].Rows[0]["PBM_Level"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBM_IsChild"] != null && ds.Tables[0].Rows[0]["PBM_IsChild"].ToString() != "")
                {
                    model.PBM_IsChild = Convert.ToInt32(ds.Tables[0].Rows[0]["PBM_IsChild"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBM_Icon"] != null && ds.Tables[0].Rows[0]["PBM_Icon"].ToString() != "")
                {
                    model.PBM_Icon = ds.Tables[0].Rows[0]["PBM_Icon"].ToString();
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
            strSql.Append(" FROM PB_Basic_Menu ");
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
            strSql.Append(" PBM_ID,PBM_FatherID,PBM_Name,PBM_Module,PBM_Parenttab,PBM_URL,PBM_Del ");
            strSql.Append(" FROM PB_Basic_Menu ");
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
            parameters[0].Value = "PB_Basic_Menu";
            parameters[1].Value = "PBM_ID";
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


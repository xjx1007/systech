using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:PB_Code_Ident
    /// </summary>
    public partial class PB_Code_Ident
    {
        public PB_Code_Ident()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PCI_Table)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PB_Code_Ident");
            strSql.Append(" where PCI_Table=@PCI_Table ");
            SqlParameter[] parameters = {
					new SqlParameter("@PCI_Table", SqlDbType.VarChar,64)};
            parameters[0].Value = PCI_Table;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Code_Ident model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PB_Code_Ident(");
            strSql.Append("PCI_Table,PCI_Type,PCI_Length,PCI_Head,PCI_Fill,PCI_Date,PCI_Default,PCI_Identity)");
            strSql.Append(" values (");
            strSql.Append("@PCI_Table,@PCI_Type,@PCI_Length,@PCI_Head,@PCI_Fill,@PCI_Date,@PCI_Default,@PCI_Identity)");
            SqlParameter[] parameters = {
					new SqlParameter("@PCI_Table", SqlDbType.VarChar,64),
					new SqlParameter("@PCI_Type", SqlDbType.VarChar,64),
					new SqlParameter("@PCI_Length", SqlDbType.Int,4),
					new SqlParameter("@PCI_Head", SqlDbType.VarChar,8),
					new SqlParameter("@PCI_Fill", SqlDbType.VarChar,64),
					new SqlParameter("@PCI_Date", SqlDbType.DateTime),
					new SqlParameter("@PCI_Default", SqlDbType.Decimal,9),
					new SqlParameter("@PCI_Identity", SqlDbType.Decimal,9)};
            parameters[0].Value = model.PCI_Table;
            parameters[1].Value = model.PCI_Type;
            parameters[2].Value = model.PCI_Length;
            parameters[3].Value = model.PCI_Head;
            parameters[4].Value = model.PCI_Fill;
            parameters[5].Value = model.PCI_Date;
            parameters[6].Value = model.PCI_Default;
            parameters[7].Value = model.PCI_Identity;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Code_Ident model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PB_Code_Ident set ");
            strSql.Append("PCI_Type=@PCI_Type,");
            strSql.Append("PCI_Length=@PCI_Length,");
            strSql.Append("PCI_Head=@PCI_Head,");
            strSql.Append("PCI_Fill=@PCI_Fill,");
            strSql.Append("PCI_Date=@PCI_Date,");
            strSql.Append("PCI_Default=@PCI_Default,");
            strSql.Append("PCI_Identity=@PCI_Identity");
            strSql.Append(" where PCI_Table=@PCI_Table ");
            SqlParameter[] parameters = {
					new SqlParameter("@PCI_Type", SqlDbType.VarChar,64),
					new SqlParameter("@PCI_Length", SqlDbType.Int,4),
					new SqlParameter("@PCI_Head", SqlDbType.VarChar,8),
					new SqlParameter("@PCI_Fill", SqlDbType.VarChar,64),
					new SqlParameter("@PCI_Date", SqlDbType.DateTime),
					new SqlParameter("@PCI_Default", SqlDbType.Decimal,9),
					new SqlParameter("@PCI_Identity", SqlDbType.Decimal,9),
					new SqlParameter("@PCI_Table", SqlDbType.VarChar,64)};
            parameters[0].Value = model.PCI_Type;
            parameters[1].Value = model.PCI_Length;
            parameters[2].Value = model.PCI_Head;
            parameters[3].Value = model.PCI_Fill;
            parameters[4].Value = model.PCI_Date;
            parameters[5].Value = model.PCI_Default;
            parameters[6].Value = model.PCI_Identity;
            parameters[7].Value = model.PCI_Table;

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
        public bool Delete(string PCI_Table)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Code_Ident ");
            strSql.Append(" where PCI_Table=@PCI_Table ");
            SqlParameter[] parameters = {
					new SqlParameter("@PCI_Table", SqlDbType.VarChar,64)};
            parameters[0].Value = PCI_Table;

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
        public bool DeleteList(string PCI_Tablelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PB_Code_Ident ");
            strSql.Append(" where PCI_Table in (" + PCI_Tablelist + ")  ");
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
        public KNet.Model.PB_Code_Ident GetModel(string PCI_Table)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PCI_Table,PCI_Type,PCI_Length,PCI_Head,PCI_Fill,PCI_Date,PCI_Default,PCI_Identity from PB_Code_Ident ");
            strSql.Append(" where PCI_Table=@PCI_Table ");
            SqlParameter[] parameters = {
					new SqlParameter("@PCI_Table", SqlDbType.VarChar,64)};
            parameters[0].Value = PCI_Table;

            KNet.Model.PB_Code_Ident model = new KNet.Model.PB_Code_Ident();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PCI_Table"] != null && ds.Tables[0].Rows[0]["PCI_Table"].ToString() != "")
                {
                    model.PCI_Table = ds.Tables[0].Rows[0]["PCI_Table"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PCI_Type"] != null && ds.Tables[0].Rows[0]["PCI_Type"].ToString() != "")
                {
                    model.PCI_Type = ds.Tables[0].Rows[0]["PCI_Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PCI_Length"] != null && ds.Tables[0].Rows[0]["PCI_Length"].ToString() != "")
                {
                    model.PCI_Length = int.Parse(ds.Tables[0].Rows[0]["PCI_Length"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PCI_Head"] != null && ds.Tables[0].Rows[0]["PCI_Head"].ToString() != "")
                {
                    model.PCI_Head = ds.Tables[0].Rows[0]["PCI_Head"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PCI_Fill"] != null && ds.Tables[0].Rows[0]["PCI_Fill"].ToString() != "")
                {
                    model.PCI_Fill = ds.Tables[0].Rows[0]["PCI_Fill"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PCI_Date"] != null && ds.Tables[0].Rows[0]["PCI_Date"].ToString() != "")
                {
                    model.PCI_Date = DateTime.Parse(ds.Tables[0].Rows[0]["PCI_Date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PCI_Default"] != null && ds.Tables[0].Rows[0]["PCI_Default"].ToString() != "")
                {
                    model.PCI_Default = decimal.Parse(ds.Tables[0].Rows[0]["PCI_Default"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PCI_Identity"] != null && ds.Tables[0].Rows[0]["PCI_Identity"].ToString() != "")
                {
                    model.PCI_Identity = decimal.Parse(ds.Tables[0].Rows[0]["PCI_Identity"].ToString());
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
            strSql.Append("select PCI_Table,PCI_Type,PCI_Length,PCI_Head,PCI_Fill,PCI_Date,PCI_Default,PCI_Identity ");
            strSql.Append(" FROM PB_Code_Ident ");
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
            strSql.Append(" PCI_Table,PCI_Type,PCI_Length,PCI_Head,PCI_Fill,PCI_Date,PCI_Default,PCI_Identity ");
            strSql.Append(" FROM PB_Code_Ident ");
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
            parameters[0].Value = "PB_Code_Ident";
            parameters[1].Value = "PCI_Table";
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


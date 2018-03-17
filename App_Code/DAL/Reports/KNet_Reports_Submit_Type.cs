using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:KNet_Reports_Submit_Type
    /// </summary>
    public partial class KNet_Reports_Submit_Type
    {
        public KNet_Reports_Submit_Type()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KRT_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KNet_Reports_Submit_Type");
            strSql.Append(" where KRT_ID=@KRT_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KRT_ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = KRT_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.KNet_Reports_Submit_Type model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Reports_Submit_Type(");
            strSql.Append("KRT_ID,KRT_Code,KRT_Depart,KRT_Person,KRT_TypeName,KRT_Type,KRT_TypeTime,KRT_Del,KRT_Creator,KRT_CTime,KRT_MTime,KRT_Mender)");
            strSql.Append(" values (");
            strSql.Append("@KRT_ID,@KRT_Code,@KRT_Depart,@KRT_Person,@KRT_TypeName,@KRT_Type,@KRT_TypeTime,@KRT_Del,@KRT_Creator,@KRT_CTime,@KRT_MTime,@KRT_Mender)");
            SqlParameter[] parameters = {
					new SqlParameter("@KRT_ID", SqlDbType.VarChar,50),
					new SqlParameter("@KRT_Code", SqlDbType.VarChar,50),
					new SqlParameter("@KRT_Depart", SqlDbType.VarChar,50),
					new SqlParameter("@KRT_Person", SqlDbType.VarChar,50),
					new SqlParameter("@KRT_TypeName", SqlDbType.VarChar,50),
					new SqlParameter("@KRT_Type", SqlDbType.Int,4),
					new SqlParameter("@KRT_TypeTime", SqlDbType.Int,4),
					new SqlParameter("@KRT_Del", SqlDbType.Int,4),
					new SqlParameter("@KRT_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@KRT_CTime", SqlDbType.DateTime),
					new SqlParameter("@KRT_MTime", SqlDbType.DateTime),
					new SqlParameter("@KRT_Mender", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KRT_ID;
            parameters[1].Value = model.KRT_Code;
            parameters[2].Value = model.KRT_Depart;
            parameters[3].Value = model.KRT_Person;
            parameters[4].Value = model.KRT_TypeName;
            parameters[5].Value = model.KRT_Type;
            parameters[6].Value = model.KRT_TypeTime;
            parameters[7].Value = model.KRT_Del;
            parameters[8].Value = model.KRT_Creator;
            parameters[9].Value = model.KRT_CTime;
            parameters[10].Value = model.KRT_MTime;
            parameters[11].Value = model.KRT_Mender;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.KNet_Reports_Submit_Type model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_Reports_Submit_Type set ");
            strSql.Append("KRT_Code=@KRT_Code,");
            strSql.Append("KRT_Depart=@KRT_Depart,");
            strSql.Append("KRT_Person=@KRT_Person,");
            strSql.Append("KRT_TypeName=@KRT_TypeName,");
            strSql.Append("KRT_Type=@KRT_Type,");
            strSql.Append("KRT_TypeTime=@KRT_TypeTime,");
            strSql.Append("KRT_Del=@KRT_Del,");
            strSql.Append("KRT_Creator=@KRT_Creator,");
            strSql.Append("KRT_CTime=@KRT_CTime,");
            strSql.Append("KRT_MTime=@KRT_MTime,");
            strSql.Append("KRT_Mender=@KRT_Mender");
            strSql.Append(" where KRT_ID=@KRT_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KRT_Code", SqlDbType.VarChar,50),
					new SqlParameter("@KRT_Depart", SqlDbType.VarChar,50),
					new SqlParameter("@KRT_Person", SqlDbType.VarChar,50),
					new SqlParameter("@KRT_TypeName", SqlDbType.VarChar,50),
					new SqlParameter("@KRT_Type", SqlDbType.Int,4),
					new SqlParameter("@KRT_TypeTime", SqlDbType.Int,4),
					new SqlParameter("@KRT_Del", SqlDbType.Int,4),
					new SqlParameter("@KRT_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@KRT_CTime", SqlDbType.DateTime),
					new SqlParameter("@KRT_MTime", SqlDbType.DateTime),
					new SqlParameter("@KRT_Mender", SqlDbType.VarChar,50),
					new SqlParameter("@KRT_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KRT_Code;
            parameters[1].Value = model.KRT_Depart;
            parameters[2].Value = model.KRT_Person;
            parameters[3].Value = model.KRT_TypeName;
            parameters[4].Value = model.KRT_Type;
            parameters[5].Value = model.KRT_TypeTime;
            parameters[6].Value = model.KRT_Del;
            parameters[7].Value = model.KRT_Creator;
            parameters[8].Value = model.KRT_CTime;
            parameters[9].Value = model.KRT_MTime;
            parameters[10].Value = model.KRT_Mender;
            parameters[11].Value = model.KRT_ID;

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
        /// 更新一条数据
        /// </summary>
        public string GetCode(KNet.Model.KNet_Reports_Submit_Type model)
        {
            string s_Rturn = "001";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  isnull(max(KRT_Code),'000') KRT_Code from KNet_Reports_Submit_Type ");
            strSql.Append(" where KRT_Type=@KRT_Type   ");
            if (model.KRT_Depart != "")
            {
                strSql.Append(" and KRT_Depart='" + model.KRT_Depart + "'");
            }
            if (model.KRT_Person != "")
            {
                strSql.Append(" and KRT_Person='" + model.KRT_Person + "'");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@KRT_Type", SqlDbType.VarChar,50),			};
            parameters[0].Value = model.KRT_Type;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["KRT_Code"] != null && ds.Tables[0].Rows[0]["KRT_Code"].ToString() != "")
                {
                    s_Rturn = "1" + ds.Tables[0].Rows[0]["KRT_Code"].ToString();
                }
                s_Rturn = Convert.ToString(int.Parse(s_Rturn) + 1);
            }
            return s_Rturn.Substring(1, s_Rturn.Length - 1);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string KRT_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_Reports_Submit_Type ");
            strSql.Append(" where KRT_ID=@KRT_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KRT_ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = KRT_ID;

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
        public bool DeleteList(string KRT_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from KNet_Reports_Submit_Type ");
            strSql.Append(" where KRT_ID in (" + KRT_IDlist + ")  ");
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
        public KNet.Model.KNet_Reports_Submit_Type GetModel(string KRT_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 KRT_ID,KRT_Code,KRT_Depart,KRT_Person,KRT_TypeName,KRT_Type,KRT_TypeTime,KRT_Del,KRT_Creator,KRT_CTime,KRT_MTime,KRT_Mender from KNet_Reports_Submit_Type ");
            strSql.Append(" where KRT_ID=@KRT_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@KRT_ID", SqlDbType.VarChar,50)			};
            parameters[0].Value = KRT_ID;

            KNet.Model.KNet_Reports_Submit_Type model = new KNet.Model.KNet_Reports_Submit_Type();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["KRT_ID"] != null && ds.Tables[0].Rows[0]["KRT_ID"].ToString() != "")
                {
                    model.KRT_ID = ds.Tables[0].Rows[0]["KRT_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRT_Code"] != null && ds.Tables[0].Rows[0]["KRT_Code"].ToString() != "")
                {
                    model.KRT_Code = ds.Tables[0].Rows[0]["KRT_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRT_Depart"] != null && ds.Tables[0].Rows[0]["KRT_Depart"].ToString() != "")
                {
                    model.KRT_Depart = ds.Tables[0].Rows[0]["KRT_Depart"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRT_Person"] != null && ds.Tables[0].Rows[0]["KRT_Person"].ToString() != "")
                {
                    model.KRT_Person = ds.Tables[0].Rows[0]["KRT_Person"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRT_TypeName"] != null && ds.Tables[0].Rows[0]["KRT_TypeName"].ToString() != "")
                {
                    model.KRT_TypeName = ds.Tables[0].Rows[0]["KRT_TypeName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRT_Type"] != null && ds.Tables[0].Rows[0]["KRT_Type"].ToString() != "")
                {
                    model.KRT_Type = int.Parse(ds.Tables[0].Rows[0]["KRT_Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KRT_TypeTime"] != null && ds.Tables[0].Rows[0]["KRT_TypeTime"].ToString() != "")
                {
                    model.KRT_TypeTime = int.Parse(ds.Tables[0].Rows[0]["KRT_TypeTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KRT_Del"] != null && ds.Tables[0].Rows[0]["KRT_Del"].ToString() != "")
                {
                    model.KRT_Del = int.Parse(ds.Tables[0].Rows[0]["KRT_Del"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KRT_Creator"] != null && ds.Tables[0].Rows[0]["KRT_Creator"].ToString() != "")
                {
                    model.KRT_Creator = ds.Tables[0].Rows[0]["KRT_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRT_CTime"] != null && ds.Tables[0].Rows[0]["KRT_CTime"].ToString() != "")
                {
                    model.KRT_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["KRT_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KRT_MTime"] != null && ds.Tables[0].Rows[0]["KRT_MTime"].ToString() != "")
                {
                    model.KRT_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["KRT_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KRT_Mender"] != null && ds.Tables[0].Rows[0]["KRT_Mender"].ToString() != "")
                {
                    model.KRT_Mender = ds.Tables[0].Rows[0]["KRT_Mender"].ToString();
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
            strSql.Append("select KRT_ID,KRT_Code,KRT_Depart,KRT_Person,KRT_TypeName,KRT_Type,KRT_TypeTime,KRT_Del,KRT_Creator,KRT_CTime,KRT_MTime,KRT_Mender ");
            strSql.Append(" FROM KNet_Reports_Submit_Type ");
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
            strSql.Append(" KRT_ID,KRT_Code,KRT_Depart,KRT_Person,KRT_TypeName,KRT_Type,KRT_TypeTime,KRT_Del,KRT_Creator,KRT_CTime,KRT_MTime,KRT_Mender ");
            strSql.Append(" FROM KNet_Reports_Submit_Type ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM KNet_Reports_Submit_Type ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.KRT_ID desc");
            }
            strSql.Append(")AS Row, T.*  from KNet_Reports_Submit_Type T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
            parameters[0].Value = "KNet_Reports_Submit_Type";
            parameters[1].Value = "KRT_ID";
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


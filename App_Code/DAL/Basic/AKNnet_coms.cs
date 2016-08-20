using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类AKNnet_coms。
    /// </summary>
    public class AKNnet_coms
    {
        public AKNnet_coms()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Titles)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from AKNnet_coms");
            strSql.Append(" where Titles=@Titles ");
            SqlParameter[] parameters = {
					new SqlParameter("@Titles", SqlDbType.NVarChar,50)};
            parameters[0].Value = Titles;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.AKNnet_coms model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AKNnet_coms(");
            strSql.Append("Titles,Coms,YN,Kings)");
            strSql.Append(" values (");
            strSql.Append("@Titles,@Coms,@YN,@Kings)");
            SqlParameter[] parameters = {
					
					new SqlParameter("@Titles", SqlDbType.NVarChar,50),
					new SqlParameter("@Coms", SqlDbType.NText),
					new SqlParameter("@YN", SqlDbType.Bit,1),
					new SqlParameter("@Kings", SqlDbType.NVarChar,50)};
           
            parameters[0].Value = model.Titles;
            parameters[1].Value = model.Coms;
            parameters[2].Value = model.YN;
            parameters[3].Value = model.Kings;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.AKNnet_coms GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Titles,Coms,YN,Kings from AKNnet_coms ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.AKNnet_coms model = new KNet.Model.AKNnet_coms();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.Titles = ds.Tables[0].Rows[0]["Titles"].ToString();
                model.Coms = ds.Tables[0].Rows[0]["Coms"].ToString();
                if (ds.Tables[0].Rows[0]["YN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["YN"].ToString() == "1") || (ds.Tables[0].Rows[0]["YN"].ToString().ToLower() == "true"))
                    {
                        model.YN = true;
                    }
                    else
                    {
                        model.YN = false;
                    }
                }
                model.Kings = ds.Tables[0].Rows[0]["Kings"].ToString();
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
            strSql.Append("select ID,Titles,Coms,YN,Kings ");
            strSql.Append(" FROM AKNnet_coms ");
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
            strSql.Append(" ID,Titles,Coms,YN,Kings ");
            strSql.Append(" FROM AKNnet_coms ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  成员方法
    }
}


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类AKNet_helps。
    /// </summary>
    public class AKNet_helps
    {
        public AKNet_helps()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Titles)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from AKNet_helps");
            strSql.Append(" where Titles=@Titles ");
            SqlParameter[] parameters = {
					new SqlParameter("@Titles", SqlDbType.NVarChar,50)};
            parameters[0].Value = Titles;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.AKNet_helps model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AKNet_helps(");
            strSql.Append("Titles,coms,kig,kings,YN,Addtimes)");
            strSql.Append(" values (");
            strSql.Append("@Titles,@coms,@kig,@kings,@YN,@Addtimes)");
            SqlParameter[] parameters = {
					
					new SqlParameter("@Titles", SqlDbType.NVarChar,100),
					new SqlParameter("@coms", SqlDbType.NText),
					new SqlParameter("@kig", SqlDbType.Int,4),
					new SqlParameter("@kings", SqlDbType.Int,4),
					new SqlParameter("@YN", SqlDbType.Bit,1),
					new SqlParameter("@Addtimes", SqlDbType.DateTime)};
            
            parameters[0].Value = model.Titles;
            parameters[1].Value = model.coms;
            parameters[2].Value = model.kig;
            parameters[3].Value = model.kings;
            parameters[4].Value = model.YN;
            parameters[5].Value = model.Addtimes;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.AKNet_helps GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Titles,coms,kig,kings,YN,Addtimes from AKNet_helps ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.AKNet_helps model = new KNet.Model.AKNet_helps();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.Titles = ds.Tables[0].Rows[0]["Titles"].ToString();
                model.coms = ds.Tables[0].Rows[0]["coms"].ToString();
                if (ds.Tables[0].Rows[0]["kig"].ToString() != "")
                {
                    model.kig = int.Parse(ds.Tables[0].Rows[0]["kig"].ToString());
                }
                if (ds.Tables[0].Rows[0]["kings"].ToString() != "")
                {
                    model.kings = int.Parse(ds.Tables[0].Rows[0]["kings"].ToString());
                }
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
                if (ds.Tables[0].Rows[0]["Addtimes"].ToString() != "")
                {
                    model.Addtimes = DateTime.Parse(ds.Tables[0].Rows[0]["Addtimes"].ToString());
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
            strSql.Append("select ID,Titles,coms,kig,kings,YN,Addtimes ");
            strSql.Append(" FROM AKNet_helps ");
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
            strSql.Append(" ID,Titles,coms,kig,kings,YN,Addtimes ");
            strSql.Append(" FROM AKNet_helps ");
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


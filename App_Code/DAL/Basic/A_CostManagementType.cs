using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类A_CostManagementType。
    /// </summary>
    public class A_CostManagementType
    {
        public A_CostManagementType()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string TypeName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from A_CostManagementType");
            strSql.Append(" where TypeName=@TypeName ");
            SqlParameter[] parameters = {
					new SqlParameter("@TypeName", SqlDbType.NVarChar,50)};
            parameters[0].Value = TypeName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.A_CostManagementType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into A_CostManagementType(");
            strSql.Append("TypeName,TypeValue,UnitsKings)");
            strSql.Append(" values (");
            strSql.Append("@TypeName,@TypeValue,@UnitsKings)");
            SqlParameter[] parameters = {
					
					new SqlParameter("@TypeName", SqlDbType.NVarChar,50),
					new SqlParameter("@TypeValue", SqlDbType.NVarChar,50),
                    new SqlParameter("@UnitsKings", SqlDbType.Int,4)};
          
            parameters[0].Value = model.TypeName;
            parameters[1].Value = model.TypeValue;
            parameters[2].Value = model.UnitsKings;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.A_CostManagementType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update A_CostManagementType set ");
            strSql.Append("TypeName=@TypeName ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@TypeName", SqlDbType.NVarChar,50)};

            parameters[0].Value = model.ID;
            parameters[1].Value = model.TypeName;
         

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.A_CostManagementType GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,TypeName,TypeValue,UnitsKings from A_CostManagementType ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.A_CostManagementType model = new KNet.Model.A_CostManagementType();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.TypeName = ds.Tables[0].Rows[0]["TypeName"].ToString();
                model.TypeValue = ds.Tables[0].Rows[0]["TypeValue"].ToString();

                if (ds.Tables[0].Rows[0]["UnitsKings"].ToString() != "")
                {
                    model.UnitsKings = int.Parse(ds.Tables[0].Rows[0]["UnitsKings"].ToString());
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
            strSql.Append("select ID,TypeName,TypeValue,UnitsKings ");
            strSql.Append(" FROM A_CostManagementType ");
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
            strSql.Append(" ID,TypeName,TypeValue,UnitsKings ");
            strSql.Append(" FROM A_CostManagementType ");
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


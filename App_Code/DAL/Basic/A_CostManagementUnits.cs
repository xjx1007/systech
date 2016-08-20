using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类A_CostManagementUnits。
    /// </summary>
    public class A_CostManagementUnits
    {
        public A_CostManagementUnits()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UnitsName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from A_CostManagementUnits");
            strSql.Append(" where UnitsName=@UnitsName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UnitsName", SqlDbType.NVarChar,50)};
            parameters[0].Value = UnitsName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.A_CostManagementUnits model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into A_CostManagementUnits(");
            strSql.Append("UnitsValue,UnitsName,YNshow,UnitsKings)");
            strSql.Append(" values (");
            strSql.Append("@UnitsValue,@UnitsName,@YNshow,@UnitsKings)");
            SqlParameter[] parameters = {
					
					new SqlParameter("@UnitsValue", SqlDbType.NVarChar,50),
					new SqlParameter("@UnitsName", SqlDbType.NVarChar,50),
					new SqlParameter("@YNshow", SqlDbType.Bit,1),
					new SqlParameter("@UnitsKings", SqlDbType.Int,4)};
           
            parameters[0].Value = model.UnitsValue;
            parameters[1].Value = model.UnitsName;
            parameters[2].Value = model.YNshow;
            parameters[3].Value = model.UnitsKings;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.A_CostManagementUnits model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update A_CostManagementUnits set ");
           
            strSql.Append("UnitsName=@UnitsName,");
            strSql.Append("YNshow=@YNshow ");
         
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					
					new SqlParameter("@UnitsName", SqlDbType.NVarChar,50),
					new SqlParameter("@YNshow", SqlDbType.Bit,1)};


            parameters[0].Value = model.ID;
           
            parameters[1].Value = model.UnitsName;
            parameters[2].Value = model.YNshow;
            

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.A_CostManagementUnits GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UnitsValue,UnitsName,YNshow,UnitsKings from A_CostManagementUnits ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.A_CostManagementUnits model = new KNet.Model.A_CostManagementUnits();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.UnitsValue = ds.Tables[0].Rows[0]["UnitsValue"].ToString();
                model.UnitsName = ds.Tables[0].Rows[0]["UnitsName"].ToString();
                if (ds.Tables[0].Rows[0]["YNshow"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["YNshow"].ToString() == "1") || (ds.Tables[0].Rows[0]["YNshow"].ToString().ToLower() == "true"))
                    {
                        model.YNshow = true;
                    }
                    else
                    {
                        model.YNshow = false;
                    }
                }
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
            strSql.Append("select ID,UnitsValue,UnitsName,YNshow,UnitsKings ");
            strSql.Append(" FROM A_CostManagementUnits ");
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
            strSql.Append(" ID,UnitsValue,UnitsName,YNshow,UnitsKings ");
            strSql.Append(" FROM A_CostManagementUnits ");
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


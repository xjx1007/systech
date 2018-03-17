using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;


namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类A_CostManagementDB。
    /// </summary>
    public class A_CostManagementDB
    {
        public A_CostManagementDB()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from A_CostManagementDB");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.A_CostManagementDB model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into A_CostManagementDB(");
            strSql.Append("ThemeTitle,OddNumbers,UnitsValue,TypeValue,AmountSum,StateId,StaffNoId,UnitsKings)");
            strSql.Append(" values (");
            strSql.Append("@ThemeTitle,@OddNumbers,@UnitsValue,@TypeValue,@AmountSum,@StateId,@StaffNoId,@UnitsKings)");
            SqlParameter[] parameters = {
					
					new SqlParameter("@ThemeTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@OddNumbers", SqlDbType.NVarChar,50),
					new SqlParameter("@UnitsValue", SqlDbType.NVarChar,50),
					new SqlParameter("@TypeValue", SqlDbType.NVarChar,50),
					new SqlParameter("@AmountSum", SqlDbType.Decimal,9),
					new SqlParameter("@StateId", SqlDbType.Int,4),
					new SqlParameter("@StaffNoId", SqlDbType.NVarChar,50),
                    new SqlParameter("@UnitsKings", SqlDbType.Int,4)};

           
            parameters[0].Value = model.ThemeTitle;
            parameters[1].Value = model.OddNumbers;
            parameters[2].Value = model.UnitsValue;
            parameters[3].Value = model.TypeValue;
            parameters[4].Value = model.AmountSum;
            parameters[5].Value = model.StateId;
            parameters[6].Value = model.StaffNoId;
            parameters[7].Value = model.UnitsKings;
         
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.A_CostManagementDB model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update A_CostManagementDB set ");
            strSql.Append("ThemeTitle=@ThemeTitle,");
            strSql.Append("OddNumbers=@OddNumbers,");
            strSql.Append("UnitsValue=@UnitsValue,");
            strSql.Append("TypeValue=@TypeValue,");
            strSql.Append("AmountSum=@AmountSum,");
            strSql.Append("StateId=@StateId,");
            strSql.Append("StaffNoId=@StaffNoId");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@ThemeTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@OddNumbers", SqlDbType.NVarChar,50),
					new SqlParameter("@UnitsValue", SqlDbType.NVarChar,50),
					new SqlParameter("@TypeValue", SqlDbType.NVarChar,50),
					new SqlParameter("@AmountSum", SqlDbType.Decimal,9),
					new SqlParameter("@StateId", SqlDbType.Int,4),
					new SqlParameter("@StaffNoId", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ThemeTitle;
            parameters[2].Value = model.OddNumbers;
            parameters[3].Value = model.UnitsValue;
            parameters[4].Value = model.TypeValue;
            parameters[5].Value = model.AmountSum;
            parameters[6].Value = model.StateId;
            parameters[7].Value = model.StaffNoId;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.A_CostManagementDB GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ThemeTitle,OddNumbers,UnitsValue,TypeValue,AmountSum,StateId,StaffNoId,Datetimes,UnitsKings from A_CostManagementDB ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.A_CostManagementDB model = new KNet.Model.A_CostManagementDB();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.ThemeTitle = ds.Tables[0].Rows[0]["ThemeTitle"].ToString();
                model.OddNumbers = ds.Tables[0].Rows[0]["OddNumbers"].ToString();
                model.UnitsValue = ds.Tables[0].Rows[0]["UnitsValue"].ToString();
                model.TypeValue = ds.Tables[0].Rows[0]["TypeValue"].ToString();
                if (ds.Tables[0].Rows[0]["AmountSum"].ToString() != "")
                {
                    model.AmountSum = decimal.Parse(ds.Tables[0].Rows[0]["AmountSum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StateId"].ToString() != "")
                {
                    model.StateId = int.Parse(ds.Tables[0].Rows[0]["StateId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Datetimes"].ToString() != "")
                {
                    model.Datetimes = DateTime.Parse(ds.Tables[0].Rows[0]["Datetimes"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UnitsKings"].ToString() != "")
                {
                    model.UnitsKings = int.Parse(ds.Tables[0].Rows[0]["UnitsKings"].ToString());
                }
                model.StaffNoId = ds.Tables[0].Rows[0]["StaffNoId"].ToString();
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
            strSql.Append("select ID,ThemeTitle,OddNumbers,UnitsValue,TypeValue,AmountSum,StateId,StaffNoId,Datetimes,UnitsKings ");
            strSql.Append(" FROM A_CostManagementDB ");
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
            strSql.Append(" ID,ThemeTitle,OddNumbers,UnitsValue,TypeValue,AmountSum,StateId,StaffNoId,Datetimes,UnitsKings ");
            strSql.Append(" FROM A_CostManagementDB ");
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


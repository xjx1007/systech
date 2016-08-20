using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sys_Units。
    /// </summary>
    public class KNet_Sys_Units
    {
        public KNet_Sys_Units()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UnitsName)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@UnitsName", SqlDbType.NVarChar,50)};
            parameters[0].Value = UnitsName;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sys_Units_Exists", parameters, out rowsAffected);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sys_Units model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@UnitsNo", SqlDbType.NVarChar,50),
					new SqlParameter("@UnitsName", SqlDbType.NVarChar,60),
					new SqlParameter("@UnitsPai", SqlDbType.Int,4)};
            parameters[0].Value = model.UnitsNo;
            parameters[1].Value = model.UnitsName;
            parameters[2].Value = model.UnitsPai;

            DbHelperSQL.RunProcedure("Proc_KNet_Sys_Units_ADD", parameters, out rowsAffected);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sys_Units model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@UnitsName", SqlDbType.NVarChar,60),
					new SqlParameter("@UnitsPai", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UnitsName;
            parameters[2].Value = model.UnitsPai;

            DbHelperSQL.RunProcedure("Proc_KNet_Sys_Units_Update", parameters, out rowsAffected);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UnitsNo,UnitsName,UnitsPai ");
            strSql.Append(" FROM KNet_Sys_Units ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by  UnitsPai desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  成员方法
    }
}


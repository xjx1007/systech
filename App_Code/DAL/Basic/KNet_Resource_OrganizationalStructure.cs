using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;


namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Resource_OrganizationalStructure。
    /// </summary>
    public class KNet_Resource_OrganizationalStructure
    {
        public KNet_Resource_OrganizationalStructure()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string StrucName, string StrucPID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@StrucName", SqlDbType.NVarChar,50),
                    new SqlParameter("@StrucPID", SqlDbType.NVarChar,50)};
            parameters[0].Value = StrucName;
            parameters[1].Value = StrucPID;


            int result = DbHelperSQL.RunProcedure("Proc_KNet_Resource_OrganizationalStructure_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.KNet_Resource_OrganizationalStructure model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					
					new SqlParameter("@StrucValue", SqlDbType.NVarChar,50),
					new SqlParameter("@StrucName", SqlDbType.NVarChar,50),
					new SqlParameter("@StrucPID", SqlDbType.NVarChar,50),
					new SqlParameter("@StrucPai", SqlDbType.Int,4)};
            parameters[0].Value = model.StrucValue;
            parameters[1].Value = model.StrucName;
            parameters[2].Value = model.StrucPID;
            parameters[3].Value = model.StrucPai;
           

            DbHelperSQL.RunProcedure("Proc_KNet_Resource_OrganizationalStructure_ADD", parameters, out rowsAffected);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Resource_OrganizationalStructure model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					
					new SqlParameter("@StrucName", SqlDbType.NVarChar,50),
					new SqlParameter("@StrucPID", SqlDbType.NVarChar,50),
					new SqlParameter("@StrucPai", SqlDbType.Int,4)};

            parameters[0].Value = model.ID;
            parameters[1].Value = model.StrucName;
            parameters[2].Value = model.StrucPID;
            parameters[3].Value = model.StrucPai;

            DbHelperSQL.RunProcedure("Proc_KNet_Resource_OrganizationalStructure_Update", parameters, out rowsAffected);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            DbHelperSQL.RunProcedure("Proc_KNet_Resource_OrganizationalStructure_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,StrucValue,StrucName,StrucPID,StrucPai");
            strSql.Append(" FROM KNet_Resource_OrganizationalStructure ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by  StrucPai desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  成员方法
    }
}


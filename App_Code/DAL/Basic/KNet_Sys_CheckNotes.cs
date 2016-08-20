using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Sys_CheckNotes。
    /// </summary>
    public class KNet_Sys_CheckNotes
    {
        public KNet_Sys_CheckNotes()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string NotesName)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@NotesName", SqlDbType.NVarChar,50)};
            parameters[0].Value = NotesName;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_Sys_CheckNotes_Exists", parameters, out rowsAffected);
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
        public void Add(KNet.Model.KNet_Sys_CheckNotes model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@NotesNo", SqlDbType.NVarChar,50),
					new SqlParameter("@NotesName", SqlDbType.NVarChar,50),
					new SqlParameter("@NotesPai", SqlDbType.Int,4)};
            parameters[0].Value = model.NotesNo;
            parameters[1].Value = model.NotesName;
            parameters[2].Value = model.NotesPai;

            DbHelperSQL.RunProcedure("Proc_KNet_Sys_CheckNotes_ADD", parameters, out rowsAffected);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sys_CheckNotes model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					new SqlParameter("@NotesName", SqlDbType.NVarChar,50),
					new SqlParameter("@NotesPai", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.NotesName;
            parameters[2].Value = model.NotesPai;

            DbHelperSQL.RunProcedure("Proc_KNet_Sys_CheckNotes_Update", parameters, out rowsAffected);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,NotesNo,NotesName,NotesPai ");
            strSql.Append(" FROM KNet_Sys_CheckNotes ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by  NotesPai desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  成员方法
    }
}


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;//Please add references
namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类:Sc_Expend_Manage
    /// </summary>
    public partial class Sc_Expend_Manage
    {
        public Sc_Expend_Manage()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SEM_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sc_Expend_Manage");
            strSql.Append(" where SEM_ID=@SEM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SEM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SEM_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Sc_Expend_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sc_Expend_Manage(");
            strSql.Append("SEM_ID,SEM_Stime,SEM_SuppNo,SEM_CustomerName,SEM_DutyPerson,SEM_ProductsEdition,SEM_RkTime,SEM_WwTime,SEM_RkPerson,SEM_WwPerson,SEM_Remarks,SEM_Del,SEM_Creator,SEM_CTime,SEM_Mendor,SEM_MTime,SEM_Type,SEM_DirectOutNO,SEM_RKCode,SEM_RCRKCode)");
            strSql.Append(" values (");
            strSql.Append("@SEM_ID,@SEM_Stime,@SEM_SuppNo,@SEM_CustomerName,@SEM_DutyPerson,@SEM_ProductsEdition,@SEM_RkTime,@SEM_WwTime,@SEM_RkPerson,@SEM_WwPerson,@SEM_Remarks,@SEM_Del,@SEM_Creator,@SEM_CTime,@SEM_Mendor,@SEM_MTime,@SEM_Type,@SEM_DirectOutNO,@SEM_RKCode,@SEM_RCRKCode)");
            SqlParameter[] parameters = {
					new SqlParameter("@SEM_ID", SqlDbType.VarChar,50),
					new SqlParameter("@SEM_Stime", SqlDbType.DateTime),
					new SqlParameter("@SEM_SuppNo", SqlDbType.VarChar,50),
					new SqlParameter("@SEM_CustomerName", SqlDbType.VarChar,50),
					new SqlParameter("@SEM_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@SEM_ProductsEdition", SqlDbType.VarChar,50),
					new SqlParameter("@SEM_RkTime", SqlDbType.DateTime),
					new SqlParameter("@SEM_WwTime", SqlDbType.DateTime),
					new SqlParameter("@SEM_RkPerson", SqlDbType.VarChar,50),
					new SqlParameter("@SEM_WwPerson", SqlDbType.VarChar,50),
					new SqlParameter("@SEM_Remarks", SqlDbType.VarChar,250),
					new SqlParameter("@SEM_Del", SqlDbType.Int,4),
					new SqlParameter("@SEM_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@SEM_CTime", SqlDbType.DateTime),
					new SqlParameter("@SEM_Mendor", SqlDbType.VarChar,50),
					new SqlParameter("@SEM_MTime", SqlDbType.DateTime),
					new SqlParameter("@SEM_Type", SqlDbType.Int,4),
					new SqlParameter("@SEM_DirectOutNO", SqlDbType.VarChar,50),
					new SqlParameter("@SEM_RKCode", SqlDbType.VarChar,50),
					new SqlParameter("@SEM_RCRKCode", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SEM_ID;
            parameters[1].Value = model.SEM_Stime;
            parameters[2].Value = model.SEM_SuppNo;
            parameters[3].Value = model.SEM_CustomerName;
            parameters[4].Value = model.SEM_DutyPerson;
            parameters[5].Value = model.SEM_ProductsEdition;
            parameters[6].Value = model.SEM_RkTime;
            parameters[7].Value = model.SEM_WwTime;
            parameters[8].Value = model.SEM_RkPerson;
            parameters[9].Value = model.SEM_WwPerson;
            parameters[10].Value = model.SEM_Remarks;
            parameters[11].Value = model.SEM_Del;
            parameters[12].Value = model.SEM_Creator;
            parameters[13].Value = model.SEM_CTime;
            parameters[14].Value = model.SEM_Mendor;
            parameters[15].Value = model.SEM_MTime;
            parameters[16].Value = model.SEM_Type;
            parameters[17].Value = model.SEM_DirectOutNO;
            parameters[18].Value = model.SEM_RKCode;
            parameters[19].Value = model.SEM_RCRKCode;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Sc_Expend_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sc_Expend_Manage set ");
            strSql.Append("SEM_Stime=@SEM_Stime,");
            strSql.Append("SEM_SuppNo=@SEM_SuppNo,");
            strSql.Append("SEM_CustomerName=@SEM_CustomerName,");
            strSql.Append("SEM_DutyPerson=@SEM_DutyPerson,");
            strSql.Append("SEM_ProductsEdition=@SEM_ProductsEdition,");
            strSql.Append("SEM_RkTime=@SEM_RkTime,");
            strSql.Append("SEM_WwTime=@SEM_WwTime,");
            strSql.Append("SEM_RkPerson=@SEM_RkPerson,");
            strSql.Append("SEM_WwPerson=@SEM_WwPerson,");
            strSql.Append("SEM_Remarks=@SEM_Remarks,");
            strSql.Append("SEM_Del=@SEM_Del,");
            strSql.Append("SEM_Creator=@SEM_Creator,");
            strSql.Append("SEM_CTime=@SEM_CTime,");
            strSql.Append("SEM_Mendor=@SEM_Mendor,");
            strSql.Append("SEM_MTime=@SEM_MTime");
            strSql.Append(" where SEM_ID=@SEM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SEM_Stime", SqlDbType.DateTime),
					new SqlParameter("@SEM_SuppNo", SqlDbType.VarChar,50),
					new SqlParameter("@SEM_CustomerName", SqlDbType.VarChar,50),
					new SqlParameter("@SEM_DutyPerson", SqlDbType.VarChar,50),
					new SqlParameter("@SEM_ProductsEdition", SqlDbType.VarChar,50),
					new SqlParameter("@SEM_RkTime", SqlDbType.DateTime),
					new SqlParameter("@SEM_WwTime", SqlDbType.DateTime),
					new SqlParameter("@SEM_RkPerson", SqlDbType.VarChar,50),
					new SqlParameter("@SEM_WwPerson", SqlDbType.VarChar,50),
					new SqlParameter("@SEM_Remarks", SqlDbType.VarChar,250),
					new SqlParameter("@SEM_Del", SqlDbType.Int,4),
					new SqlParameter("@SEM_Creator", SqlDbType.VarChar,50),
					new SqlParameter("@SEM_CTime", SqlDbType.DateTime),
					new SqlParameter("@SEM_Mendor", SqlDbType.VarChar,50),
					new SqlParameter("@SEM_MTime", SqlDbType.DateTime),
					new SqlParameter("@SEM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SEM_Stime;
            parameters[1].Value = model.SEM_SuppNo;
            parameters[2].Value = model.SEM_CustomerName;
            parameters[3].Value = model.SEM_DutyPerson;
            parameters[4].Value = model.SEM_ProductsEdition;
            parameters[5].Value = model.SEM_RkTime;
            parameters[6].Value = model.SEM_WwTime;
            parameters[7].Value = model.SEM_RkPerson;
            parameters[8].Value = model.SEM_WwPerson;
            parameters[9].Value = model.SEM_Remarks;
            parameters[10].Value = model.SEM_Del;
            parameters[11].Value = model.SEM_Creator;
            parameters[12].Value = model.SEM_CTime;
            parameters[13].Value = model.SEM_Mendor;
            parameters[14].Value = model.SEM_MTime;
            parameters[15].Value = model.SEM_ID;

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
        public bool Delete(string SEM_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sc_Expend_Manage ");
            strSql.Append(" where SEM_ID=@SEM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SEM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SEM_ID;

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
        public bool DeleteList(string SEM_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sc_Expend_Manage ");
            strSql.Append(" where SEM_ID in (" + SEM_IDlist + ")  ");
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
        /// 更新一条数据
        /// </summary>
        public bool UpdateRCPrintState(KNet.Model.Sc_Expend_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sc_Expend_Manage set ");
            strSql.Append("SEM_RCPrintNums=@SEM_RCPrintNums");
            strSql.Append(" where SEM_ID=@SEM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SEM_RCPrintNums", SqlDbType.Int,4),
					new SqlParameter("@SEM_ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.SEM_RCPrintNums;
            parameters[1].Value = model.SEM_ID;

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
        public bool UpdateMaterPrintState(KNet.Model.Sc_Expend_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sc_Expend_Manage set ");
            strSql.Append("SEM_MaterPrintNums=@SEM_MaterPrintNums");
            strSql.Append(" where SEM_ID=@SEM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SEM_MaterPrintNums", SqlDbType.Int,4),
					new SqlParameter("@SEM_ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.SEM_MaterPrintNums;
            parameters[1].Value = model.SEM_ID;

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
        public bool UpdateMaterPrintState1(KNet.Model.Sc_Expend_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sc_Expend_Manage set ");
            strSql.Append("SEM_MaterPrintNums1=@SEM_MaterPrintNums1");
            strSql.Append(" where SEM_ID=@SEM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SEM_MaterPrintNums1", SqlDbType.Int,4),
					new SqlParameter("@SEM_ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.SEM_MaterPrintNums1;
            parameters[1].Value = model.SEM_ID;

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
        public bool UpdateMaterPrintState2(KNet.Model.Sc_Expend_Manage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sc_Expend_Manage set ");
            strSql.Append("SEM_MaterPrintNums2=@SEM_MaterPrintNums2");
            strSql.Append(" where SEM_ID=@SEM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SEM_MaterPrintNums2", SqlDbType.Int,4),
					new SqlParameter("@SEM_ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.SEM_MaterPrintNums2;
            parameters[1].Value = model.SEM_ID;

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
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Sc_Expend_Manage GetModel(string SEM_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Sc_Expend_Manage ");
            strSql.Append(" where SEM_ID=@SEM_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SEM_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = SEM_ID;

            KNet.Model.Sc_Expend_Manage model = new KNet.Model.Sc_Expend_Manage();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SEM_ID"] != null && ds.Tables[0].Rows[0]["SEM_ID"].ToString() != "")
                {
                    model.SEM_ID = ds.Tables[0].Rows[0]["SEM_ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SEM_Stime"] != null && ds.Tables[0].Rows[0]["SEM_Stime"].ToString() != "")
                {
                    model.SEM_Stime = DateTime.Parse(ds.Tables[0].Rows[0]["SEM_Stime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SEM_SuppNo"] != null && ds.Tables[0].Rows[0]["SEM_SuppNo"].ToString() != "")
                {
                    model.SEM_SuppNo = ds.Tables[0].Rows[0]["SEM_SuppNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SEM_CustomerName"] != null && ds.Tables[0].Rows[0]["SEM_CustomerName"].ToString() != "")
                {
                    model.SEM_CustomerName = ds.Tables[0].Rows[0]["SEM_CustomerName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SEM_DutyPerson"] != null && ds.Tables[0].Rows[0]["SEM_DutyPerson"].ToString() != "")
                {
                    model.SEM_DutyPerson = ds.Tables[0].Rows[0]["SEM_DutyPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SEM_ProductsEdition"] != null && ds.Tables[0].Rows[0]["SEM_ProductsEdition"].ToString() != "")
                {
                    model.SEM_ProductsEdition = ds.Tables[0].Rows[0]["SEM_ProductsEdition"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SEM_RkTime"] != null && ds.Tables[0].Rows[0]["SEM_RkTime"].ToString() != "")
                {
                    model.SEM_RkTime = DateTime.Parse(ds.Tables[0].Rows[0]["SEM_RkTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SEM_WwTime"] != null && ds.Tables[0].Rows[0]["SEM_WwTime"].ToString() != "")
                {
                    model.SEM_WwTime = DateTime.Parse(ds.Tables[0].Rows[0]["SEM_WwTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SEM_RkPerson"] != null && ds.Tables[0].Rows[0]["SEM_RkPerson"].ToString() != "")
                {
                    model.SEM_RkPerson = ds.Tables[0].Rows[0]["SEM_RkPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SEM_WwPerson"] != null && ds.Tables[0].Rows[0]["SEM_WwPerson"].ToString() != "")
                {
                    model.SEM_WwPerson = ds.Tables[0].Rows[0]["SEM_WwPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SEM_Remarks"] != null && ds.Tables[0].Rows[0]["SEM_Remarks"].ToString() != "")
                {
                    model.SEM_Remarks = ds.Tables[0].Rows[0]["SEM_Remarks"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SEM_Del"] != null && ds.Tables[0].Rows[0]["SEM_Del"].ToString() != "")
                {
                    model.SEM_Del = int.Parse(ds.Tables[0].Rows[0]["SEM_Del"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SEM_Creator"] != null && ds.Tables[0].Rows[0]["SEM_Creator"].ToString() != "")
                {
                    model.SEM_Creator = ds.Tables[0].Rows[0]["SEM_Creator"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SEM_CTime"] != null && ds.Tables[0].Rows[0]["SEM_CTime"].ToString() != "")
                {
                    model.SEM_CTime = DateTime.Parse(ds.Tables[0].Rows[0]["SEM_CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SEM_Mendor"] != null && ds.Tables[0].Rows[0]["SEM_Mendor"].ToString() != "")
                {
                    model.SEM_Mendor = ds.Tables[0].Rows[0]["SEM_Mendor"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SEM_MTime"] != null && ds.Tables[0].Rows[0]["SEM_MTime"].ToString() != "")
                {
                    model.SEM_MTime = DateTime.Parse(ds.Tables[0].Rows[0]["SEM_MTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SEM_CheckYN"] != null && ds.Tables[0].Rows[0]["SEM_CheckYN"].ToString() != "")
                {
                    model.SEM_CheckYN = int.Parse(ds.Tables[0].Rows[0]["SEM_CheckYN"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SEM_CheckStaffNo"] != null && ds.Tables[0].Rows[0]["SEM_CheckStaffNo"].ToString() != "")
                {
                    model.SEM_CheckStaffNo = ds.Tables[0].Rows[0]["SEM_CheckStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SEM_CheckTime"] != null && ds.Tables[0].Rows[0]["SEM_CheckTime"].ToString() != "")
                {
                    model.SEM_CheckTime = DateTime.Parse(ds.Tables[0].Rows[0]["SEM_CheckTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SEM_RCPrintNums"] != null && ds.Tables[0].Rows[0]["SEM_RCPrintNums"].ToString() != "")
                {
                    model.SEM_RCPrintNums = int.Parse(ds.Tables[0].Rows[0]["SEM_RCPrintNums"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SEM_MaterPrintNums"] != null && ds.Tables[0].Rows[0]["SEM_MaterPrintNums"].ToString() != "")
                {
                    model.SEM_MaterPrintNums = int.Parse(ds.Tables[0].Rows[0]["SEM_MaterPrintNums"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SEM_MaterPrintNums1"] != null && ds.Tables[0].Rows[0]["SEM_MaterPrintNums1"].ToString() != "")
                {
                    model.SEM_MaterPrintNums1 = int.Parse(ds.Tables[0].Rows[0]["SEM_MaterPrintNums1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SEM_MaterPrintNums2"] != null && ds.Tables[0].Rows[0]["SEM_MaterPrintNums2"].ToString() != "")
                {
                    model.SEM_MaterPrintNums2 = int.Parse(ds.Tables[0].Rows[0]["SEM_MaterPrintNums2"].ToString());
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
            strSql.Append("select * ");
            strSql.Append(" FROM Sc_Expend_Manage a join Sc_Expend_Manage_RCDetails b on a.SEM_ID=b.SER_SEMID ");
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
            strSql.Append(" SEM_ID,SEM_Stime,SEM_SuppNo,SEM_CustomerName,SEM_DutyPerson,SEM_ProductsEdition,SEM_RkTime,SEM_WwTime,SEM_RkPerson,SEM_WwPerson,SEM_Remarks,SEM_Del,SEM_Creator,SEM_CTime,SEM_Mendor,SEM_MTime ");
            strSql.Append(" FROM Sc_Expend_Manage ");
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
            parameters[0].Value = "Sc_Expend_Manage";
            parameters[1].Value = "SEM_ID";
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


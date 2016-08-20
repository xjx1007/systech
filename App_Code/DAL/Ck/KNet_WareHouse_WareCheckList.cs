using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_WareHouse_WareCheckList。
    /// </summary>
    public class KNet_WareHouse_WareCheckList
    {
        public KNet_WareHouse_WareCheckList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string WareCheckNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@WareCheckNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = WareCheckNo;

            int result = DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_WareCheckList_Exists", parameters, out rowsAffected);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string GetLastCode()
        {
            string s_Return = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 WareCheckNo from KNet_WareHouse_WareCheckList");
            strSql.Append(" where isnull(KWW_Del,'0')='0'  order by WareCheckNo desc");

            DataSet Dts_Table = DbHelperSQL.Query(strSql.ToString());
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                s_Return = Dts_Table.Tables[0].Rows[0][0].ToString();
            }
            return s_Return;
        }
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_WareHouse_WareCheckList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_WareHouse_WareCheckList(");
            strSql.Append("WareCheckNo,WareCheckTopic,WareCheckDateTime,HouseNo,WareCheckStaffBranch,WareCheckStaffDepart,WareCheckStaffNo,WareCheckCheckStaffNo,WareCheckRemarks)");
            strSql.Append(" values (");
            strSql.Append("@WareCheckNo,@WareCheckTopic,@WareCheckDateTime,@HouseNo,@WareCheckStaffBranch,@WareCheckStaffDepart,@WareCheckStaffNo,@WareCheckCheckStaffNo,@WareCheckRemarks)");
            SqlParameter[] parameters = {
					new SqlParameter("@WareCheckNo", SqlDbType.NVarChar,50),
					new SqlParameter("@WareCheckTopic", SqlDbType.NVarChar,50),
					new SqlParameter("@WareCheckDateTime", SqlDbType.DateTime),
					new SqlParameter("@HouseNo", SqlDbType.NVarChar,50),
					new SqlParameter("@WareCheckStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@WareCheckStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@WareCheckStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@WareCheckCheckStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@WareCheckRemarks", SqlDbType.NVarChar,1000)};
            parameters[0].Value = model.WareCheckNo;
            parameters[1].Value = model.WareCheckTopic;
            parameters[2].Value = model.WareCheckDateTime;
            parameters[3].Value = model.HouseNo;
            parameters[4].Value = model.WareCheckStaffBranch;
            parameters[5].Value = model.WareCheckStaffDepart;
            parameters[6].Value = model.WareCheckStaffNo;
            parameters[7].Value = model.WareCheckCheckStaffNo;
            parameters[8].Value = model.WareCheckRemarks;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_WareHouse_WareCheckList model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update KNet_WareHouse_WareCheckList set ");
            strSql.Append("WareCheckTopic=@WareCheckTopic,");
            strSql.Append("WareCheckDateTime=@WareCheckDateTime,");
            strSql.Append("HouseNo=@HouseNo,");
            strSql.Append("WareCheckStaffBranch=@WareCheckStaffBranch,");
            strSql.Append("WareCheckStaffDepart=@WareCheckStaffDepart,");
            strSql.Append("WareCheckStaffNo=@WareCheckStaffNo,");
            strSql.Append("WareCheckCheckStaffNo=@WareCheckCheckStaffNo,");
            strSql.Append("WareCheckRemarks=@WareCheckRemarks");
            strSql.Append(" where WareCheckNo=@WareCheckNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@WareCheckTopic", SqlDbType.NVarChar,50),
					new SqlParameter("@WareCheckDateTime", SqlDbType.DateTime),
					new SqlParameter("@HouseNo", SqlDbType.NVarChar,50),
					new SqlParameter("@WareCheckStaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@WareCheckStaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@WareCheckStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@WareCheckCheckStaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@WareCheckRemarks", SqlDbType.NVarChar,1000),
					new SqlParameter("@WareCheckNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.WareCheckTopic;
            parameters[1].Value = model.WareCheckDateTime;
            parameters[2].Value = model.HouseNo;
            parameters[3].Value = model.WareCheckStaffBranch;
            parameters[4].Value = model.WareCheckStaffDepart;
            parameters[5].Value = model.WareCheckStaffNo;
            parameters[6].Value = model.WareCheckCheckStaffNo;
            parameters[7].Value = model.WareCheckRemarks;
            parameters[8].Value = model.WareCheckNo;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string WareCheckNo)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@WareCheckNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = WareCheckNo;

            DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_WareCheckList_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_WareCheckList GetModel(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_WareHouse_WareCheckList model = new KNet.Model.KNet_WareHouse_WareCheckList();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_WareCheckList_GetModelByID", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.WareCheckNo = ds.Tables[0].Rows[0]["WareCheckNo"].ToString();
                model.WareCheckTopic = ds.Tables[0].Rows[0]["WareCheckTopic"].ToString();
                if (ds.Tables[0].Rows[0]["WareCheckDateTime"].ToString() != "")
                {
                    model.WareCheckDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["WareCheckDateTime"].ToString());
                }
                model.HouseNo = ds.Tables[0].Rows[0]["HouseNo"].ToString();
                model.WareCheckStaffBranch = ds.Tables[0].Rows[0]["WareCheckStaffBranch"].ToString();
                model.WareCheckStaffDepart = ds.Tables[0].Rows[0]["WareCheckStaffDepart"].ToString();
                model.WareCheckStaffNo = ds.Tables[0].Rows[0]["WareCheckStaffNo"].ToString();
                model.WareCheckCheckStaffNo = ds.Tables[0].Rows[0]["WareCheckCheckStaffNo"].ToString();
                model.WareCheckRemarks = ds.Tables[0].Rows[0]["WareCheckRemarks"].ToString();
                if (ds.Tables[0].Rows[0]["WareCheckCheckYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["WareCheckCheckYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["WareCheckCheckYN"].ToString().ToLower() == "true"))
                    {
                        model.WareCheckCheckYN = true;
                    }
                    else
                    {
                        model.WareCheckCheckYN = false;
                    }
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_WareCheckList GetModelB(string WareCheckNo)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@WareCheckNo", SqlDbType.NVarChar,50)};
            parameters[0].Value = WareCheckNo;

            KNet.Model.KNet_WareHouse_WareCheckList model = new KNet.Model.KNet_WareHouse_WareCheckList();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_WareCheckList_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.WareCheckNo = ds.Tables[0].Rows[0]["WareCheckNo"].ToString();
                model.WareCheckTopic = ds.Tables[0].Rows[0]["WareCheckTopic"].ToString();
                if (ds.Tables[0].Rows[0]["WareCheckDateTime"].ToString() != "")
                {
                    model.WareCheckDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["WareCheckDateTime"].ToString());
                }
                model.HouseNo = ds.Tables[0].Rows[0]["HouseNo"].ToString();
                model.WareCheckStaffBranch = ds.Tables[0].Rows[0]["WareCheckStaffBranch"].ToString();
                model.WareCheckStaffDepart = ds.Tables[0].Rows[0]["WareCheckStaffDepart"].ToString();
                model.WareCheckStaffNo = ds.Tables[0].Rows[0]["WareCheckStaffNo"].ToString();
                model.WareCheckCheckStaffNo = ds.Tables[0].Rows[0]["WareCheckCheckStaffNo"].ToString();
                model.WareCheckRemarks = ds.Tables[0].Rows[0]["WareCheckRemarks"].ToString();
                if (ds.Tables[0].Rows[0]["WareCheckCheckYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["WareCheckCheckYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["WareCheckCheckYN"].ToString().ToLower() == "true"))
                    {
                        model.WareCheckCheckYN = true;
                    }
                    else
                    {
                        model.WareCheckCheckYN = false;
                    }
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
            strSql.Append(" FROM KNet_WareHouse_WareCheckList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  成员方法
    }
}


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类KNet_Resource_OutManage。
    /// </summary>
    public class KNet_Resource_OutManage
    {
        public KNet_Resource_OutManage()
        { }
        #region  成员方法

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Resource_OutManage model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Resource_OutManage(");
            strSql.Append("StaffNo,StaffBranch,StaffDepart,StartDateTime,EndDatetime,OutJustificate,AddDatetime,ThisState,ThisKings,thisExtendA,thisExtendB,KRO_Traffic,KRO_Type,ID)");
            strSql.Append(" values (");
            strSql.Append("@StaffNo,@StaffBranch,@StaffDepart,@StartDateTime,@EndDatetime,@OutJustificate,@AddDatetime,@ThisState,@ThisKings,@thisExtendA,@thisExtendB,@KRO_Traffic,@KRO_Type,@ID)");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffNo", SqlDbType.NVarChar,50),
					new SqlParameter("@StaffBranch", SqlDbType.NVarChar,50),
					new SqlParameter("@StaffDepart", SqlDbType.NVarChar,50),
					new SqlParameter("@StartDateTime", SqlDbType.NVarChar,50),
					new SqlParameter("@EndDatetime", SqlDbType.NVarChar,50),
					new SqlParameter("@OutJustificate", SqlDbType.NVarChar,1000),
					new SqlParameter("@AddDatetime", SqlDbType.DateTime),
					new SqlParameter("@ThisState", SqlDbType.Int,4),
					new SqlParameter("@ThisKings", SqlDbType.Int,4),
					new SqlParameter("@thisExtendA", SqlDbType.NVarChar,50),
					new SqlParameter("@thisExtendB", SqlDbType.NVarChar,50),
					new SqlParameter("@KRO_Traffic", SqlDbType.VarChar,50),
					new SqlParameter("@KRO_Type", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.StaffNo;
            parameters[1].Value = model.StaffBranch;
            parameters[2].Value = model.StaffDepart;
            parameters[3].Value = model.StartDateTime;
            parameters[4].Value = model.EndDatetime;
            parameters[5].Value = model.OutJustificate;
            parameters[6].Value = model.AddDatetime;
            parameters[7].Value = model.ThisState;
            parameters[8].Value = model.ThisKings;
            parameters[9].Value = model.thisExtendA;
            parameters[10].Value = model.thisExtendB;
            parameters[11].Value = model.KRO_Traffic;
            parameters[12].Value = model.KRO_Type;
            parameters[13].Value = model.ID;
            

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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

            DbHelperSQL.RunProcedure("Proc_KNet_Resource_OutManage_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Resource_OutManage GetModel(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from KNet_Resource_OutManage ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.KNet_Resource_OutManage model = new KNet.Model.KNet_Resource_OutManage();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StaffNo"] != null && ds.Tables[0].Rows[0]["StaffNo"].ToString() != "")
                {
                    model.StaffNo = ds.Tables[0].Rows[0]["StaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffBranch"] != null && ds.Tables[0].Rows[0]["StaffBranch"].ToString() != "")
                {
                    model.StaffBranch = ds.Tables[0].Rows[0]["StaffBranch"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffDepart"] != null && ds.Tables[0].Rows[0]["StaffDepart"].ToString() != "")
                {
                    model.StaffDepart = ds.Tables[0].Rows[0]["StaffDepart"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StartDateTime"] != null && ds.Tables[0].Rows[0]["StartDateTime"].ToString() != "")
                {
                    model.StartDateTime = ds.Tables[0].Rows[0]["StartDateTime"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EndDatetime"] != null && ds.Tables[0].Rows[0]["EndDatetime"].ToString() != "")
                {
                    model.EndDatetime = ds.Tables[0].Rows[0]["EndDatetime"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OutJustificate"] != null && ds.Tables[0].Rows[0]["OutJustificate"].ToString() != "")
                {
                    model.OutJustificate = ds.Tables[0].Rows[0]["OutJustificate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AddDatetime"] != null && ds.Tables[0].Rows[0]["AddDatetime"].ToString() != "")
                {
                    model.AddDatetime = DateTime.Parse(ds.Tables[0].Rows[0]["AddDatetime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ThisState"] != null && ds.Tables[0].Rows[0]["ThisState"].ToString() != "")
                {
                    model.ThisState = int.Parse(ds.Tables[0].Rows[0]["ThisState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ThisKings"] != null && ds.Tables[0].Rows[0]["ThisKings"].ToString() != "")
                {
                    model.ThisKings = int.Parse(ds.Tables[0].Rows[0]["ThisKings"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ApprovalStaffNo"] != null && ds.Tables[0].Rows[0]["ApprovalStaffNo"].ToString() != "")
                {
                    model.ApprovalStaffNo = ds.Tables[0].Rows[0]["ApprovalStaffNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ApprovalDatetime"] != null && ds.Tables[0].Rows[0]["ApprovalDatetime"].ToString() != "")
                {
                    model.ApprovalDatetime = DateTime.Parse(ds.Tables[0].Rows[0]["ApprovalDatetime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["thisExtendA"] != null && ds.Tables[0].Rows[0]["thisExtendA"].ToString() != "")
                {
                    model.thisExtendA = ds.Tables[0].Rows[0]["thisExtendA"].ToString();
                }
                if (ds.Tables[0].Rows[0]["thisExtendB"] != null && ds.Tables[0].Rows[0]["thisExtendB"].ToString() != "")
                {
                    model.thisExtendB = ds.Tables[0].Rows[0]["thisExtendB"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRO_Traffic"] != null && ds.Tables[0].Rows[0]["KRO_Traffic"].ToString() != "")
                {
                    model.KRO_Traffic = ds.Tables[0].Rows[0]["KRO_Traffic"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRO_Type"] != null && ds.Tables[0].Rows[0]["KRO_Type"].ToString() != "")
                {
                    model.KRO_Type = ds.Tables[0].Rows[0]["KRO_Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["KRO_IsCheck"] != null && ds.Tables[0].Rows[0]["KRO_IsCheck"].ToString() != "")
                {
                    model.KRO_IsCheck = int.Parse(ds.Tables[0].Rows[0]["KRO_IsCheck"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KRO_Remarks"] != null && ds.Tables[0].Rows[0]["KRO_Remarks"].ToString() != "")
                {
                    model.KRO_Remarks = ds.Tables[0].Rows[0]["KRO_Remarks"].ToString();
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
            strSql.Append(" FROM KNet_Resource_OutManage ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by  AddDatetime desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class IM_Project_Manage_Details
    {
        public IM_Project_Manage_Details()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string IPMD_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from IM_Project_Manage_Details");
            strSql.Append(" where IPMD_ID=@IPMD_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@IPMD_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = IPMD_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// 
        public bool Add(KNet.Model.IM_Project_Manage_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into IM_Project_Manage_Details(");
            strSql.Append("IPMD_ID,IPMD_IPMID,IPMD_FID,IPMD_Type,IPMD_Name,IPMD_Days,IPMD_FloatingDays,IPMD_PreTask,IPMD_EarlyBeginTime,IPMD_EarlyEndTime,IPMD_AtLatestBeginTime,IPMD_AtLatestEndTime,IPMD_DutyPerson,IPMD_Executor,IPMD_Remarks,IPMD_Creator,IPMD_CTime,IPMD_Del,IPMD_Mender,IPMD_MTime,IPMD_FTaskID,IPMD_Level,IPMD_WorkType,IPMD_State,IPMD_ProjectType,IPMD_Import,IPMD_Precent,IPMD_Persons,IPMD_DaysType,IPMD_HolidayType,IPMD_UseDays,IPMD_LeftDays ");
            strSql.Append(") values (");
            strSql.Append("@IPMD_ID,@IPMD_IPMID,@IPMD_FID,@IPMD_Type,@IPMD_Name,@IPMD_Days,@IPMD_FloatingDays,@IPMD_PreTask,@IPMD_EarlyBeginTime,@IPMD_EarlyEndTime,@IPMD_AtLatestBeginTime,@IPMD_AtLatestEndTime,@IPMD_DutyPerson,@IPMD_Executor,@IPMD_Remarks,@IPMD_Creator,@IPMD_CTime,@IPMD_Del,@IPMD_Mender,@IPMD_MTime,@IPMD_FTaskID,@IPMD_Level,@IPMD_WorkType,@IPMD_State,@IPMD_ProjectType,@IPMD_Import,@IPMD_Precent,@IPMD_Persons,@IPMD_DaysType,@IPMD_HolidayType,@IPMD_UseDays,@IPMD_LeftDays)");
            SqlParameter[] parameters = {
 new SqlParameter("@IPMD_ID", SqlDbType.VarChar,50),
 new SqlParameter("@IPMD_IPMID", SqlDbType.VarChar,50),
 new SqlParameter("@IPMD_FID", SqlDbType.VarChar,50),
 new SqlParameter("@IPMD_Type", SqlDbType.Int,4),
 new SqlParameter("@IPMD_Name", SqlDbType.VarChar,150),
 new SqlParameter("@IPMD_Days", SqlDbType.Int,4),
 new SqlParameter("@IPMD_FloatingDays", SqlDbType.Int,4),
 new SqlParameter("@IPMD_PreTask", SqlDbType.VarChar,500),
 new SqlParameter("@IPMD_EarlyBeginTime", SqlDbType.DateTime,8),
 new SqlParameter("@IPMD_EarlyEndTime", SqlDbType.DateTime,8),
 new SqlParameter("@IPMD_AtLatestBeginTime", SqlDbType.DateTime,8),
 new SqlParameter("@IPMD_AtLatestEndTime", SqlDbType.DateTime,8),
 new SqlParameter("@IPMD_DutyPerson", SqlDbType.VarChar,750),
 new SqlParameter("@IPMD_Executor", SqlDbType.VarChar,750),
 new SqlParameter("@IPMD_Remarks", SqlDbType.VarChar,16),
 new SqlParameter("@IPMD_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@IPMD_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@IPMD_Del", SqlDbType.Int,4),
 new SqlParameter("@IPMD_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@IPMD_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@IPMD_FTaskID", SqlDbType.VarChar,50),
 new SqlParameter("@IPMD_Level", SqlDbType.Int,4),
 new SqlParameter("@IPMD_WorkType", SqlDbType.Int,4),
 new SqlParameter("@IPMD_State", SqlDbType.Int,4),
 new SqlParameter("@IPMD_ProjectType", SqlDbType.Int,4),
 new SqlParameter("@IPMD_Import", SqlDbType.Int,4),
 new SqlParameter("@IPMD_Precent", SqlDbType.Decimal,9),
 new SqlParameter("@IPMD_Persons", SqlDbType.VarChar,50),
 new SqlParameter("@IPMD_DaysType", SqlDbType.Int,4),
 new SqlParameter("@IPMD_HolidayType", SqlDbType.Int,4),
 new SqlParameter("@IPMD_UseDays", SqlDbType.Int,4),
 new SqlParameter("@IPMD_LeftDays", SqlDbType.Int,4)};
            parameters[0].Value = model.IPMD_ID;
            parameters[1].Value = model.IPMD_IPMID;
            parameters[2].Value = model.IPMD_FID;
            parameters[3].Value = model.IPMD_Type;
            parameters[4].Value = model.IPMD_Name;
            parameters[5].Value = model.IPMD_Days;
            parameters[6].Value = model.IPMD_FloatingDays;
            parameters[7].Value = model.IPMD_PreTask;
            parameters[8].Value = model.IPMD_EarlyBeginTime;
            parameters[9].Value = model.IPMD_EarlyEndTime;
            parameters[10].Value = model.IPMD_AtLatestBeginTime;
            parameters[11].Value = model.IPMD_AtLatestEndTime;
            parameters[12].Value = model.IPMD_DutyPerson;
            parameters[13].Value = model.IPMD_Executor;
            parameters[14].Value = model.IPMD_Remarks;
            parameters[15].Value = model.IPMD_Creator;
            parameters[16].Value = model.IPMD_CTime;
            parameters[17].Value = model.IPMD_Del;
            parameters[18].Value = model.IPMD_Mender;
            parameters[19].Value = model.IPMD_MTime;
            parameters[20].Value = model.IPMD_FTaskID;
            parameters[21].Value = model.IPMD_Level;
            parameters[22].Value = model.IPMD_WorkType;
            parameters[23].Value = model.IPMD_State;
            parameters[24].Value = model.IPMD_ProjectType;
            parameters[25].Value = model.IPMD_Import;
            parameters[26].Value = model.IPMD_Precent;
            parameters[27].Value = model.IPMD_Persons;
            parameters[28].Value = model.IPMD_DaysType;
            parameters[29].Value = model.IPMD_HolidayType;
            parameters[30].Value = model.IPMD_UseDays;
            parameters[31].Value = model.IPMD_LeftDays;
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
        /// 修改
        /// </summary>
        public bool Update(KNet.Model.IM_Project_Manage_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update IM_Project_Manage_Details set ");
            strSql.Append("IPMD_IPMID=@IPMD_IPMID,");
            strSql.Append("IPMD_FID=@IPMD_FID,");
            strSql.Append("IPMD_Type=@IPMD_Type,");
            strSql.Append("IPMD_Name=@IPMD_Name,");
            strSql.Append("IPMD_Days=@IPMD_Days,");
            strSql.Append("IPMD_FloatingDays=@IPMD_FloatingDays,");
            strSql.Append("IPMD_PreTask=@IPMD_PreTask,");
            strSql.Append("IPMD_EarlyBeginTime=@IPMD_EarlyBeginTime,");
            strSql.Append("IPMD_EarlyEndTime=@IPMD_EarlyEndTime,");
            strSql.Append("IPMD_AtLatestBeginTime=@IPMD_AtLatestBeginTime,");
            strSql.Append("IPMD_AtLatestEndTime=@IPMD_AtLatestEndTime,");
            strSql.Append("IPMD_DutyPerson=@IPMD_DutyPerson,");
            strSql.Append("IPMD_Executor=@IPMD_Executor,");
            strSql.Append("IPMD_Remarks=@IPMD_Remarks,");
            strSql.Append("IPMD_Del=@IPMD_Del,");
            strSql.Append("IPMD_Mender=@IPMD_Mender,");
            strSql.Append("IPMD_MTime=@IPMD_MTime,");
            strSql.Append("IPMD_FTaskID=@IPMD_FTaskID,");
            strSql.Append("IPMD_Level=@IPMD_Level,");
            strSql.Append("IPMD_WorkType=@IPMD_WorkType,");
            strSql.Append("IPMD_State=@IPMD_State,");
            strSql.Append("IPMD_ProjectType=@IPMD_ProjectType,");
            strSql.Append("IPMD_Import=@IPMD_Import,");
            strSql.Append("IPMD_Precent=@IPMD_Precent,");
            strSql.Append("IPMD_Persons=@IPMD_Persons,");
            strSql.Append("IPMD_DaysType=@IPMD_DaysType,");
            strSql.Append("IPMD_HolidayType=@IPMD_HolidayType,");
            strSql.Append("IPMD_UseDays=@IPMD_UseDays,");
            strSql.Append("IPMD_LeftDays=@IPMD_LeftDays");
            strSql.Append(" where IPMD_ID=@IPMD_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@IPMD_IPMID", SqlDbType.VarChar,50),
 new SqlParameter("@IPMD_FID", SqlDbType.VarChar,50),
 new SqlParameter("@IPMD_Type", SqlDbType.Int,4),
 new SqlParameter("@IPMD_Name", SqlDbType.VarChar,150),
 new SqlParameter("@IPMD_Days", SqlDbType.Int,4),
 new SqlParameter("@IPMD_FloatingDays", SqlDbType.Int,4),
 new SqlParameter("@IPMD_PreTask", SqlDbType.VarChar,500),
 new SqlParameter("@IPMD_EarlyBeginTime", SqlDbType.DateTime,8),
 new SqlParameter("@IPMD_EarlyEndTime", SqlDbType.DateTime,8),
 new SqlParameter("@IPMD_AtLatestBeginTime", SqlDbType.DateTime,8),
 new SqlParameter("@IPMD_AtLatestEndTime", SqlDbType.DateTime,8),
 new SqlParameter("@IPMD_DutyPerson", SqlDbType.VarChar,750),
 new SqlParameter("@IPMD_Executor", SqlDbType.VarChar,750),
 new SqlParameter("@IPMD_Remarks", SqlDbType.VarChar,16),
 new SqlParameter("@IPMD_Del", SqlDbType.Int,4),
 new SqlParameter("@IPMD_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@IPMD_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@IPMD_FTaskID", SqlDbType.VarChar,50),
 new SqlParameter("@IPMD_Level", SqlDbType.Int,4),
 new SqlParameter("@IPMD_WorkType", SqlDbType.Int,4),
 new SqlParameter("@IPMD_State", SqlDbType.Int,4),
 new SqlParameter("@IPMD_ProjectType", SqlDbType.Int,4),
 new SqlParameter("@IPMD_Import", SqlDbType.Int,4),
 new SqlParameter("@IPMD_Precent", SqlDbType.Decimal,9),
 new SqlParameter("@IPMD_Persons", SqlDbType.VarChar,50),
 new SqlParameter("@IPMD_DaysType", SqlDbType.Int,4),
 new SqlParameter("@IPMD_HolidayType", SqlDbType.Int,4),
 new SqlParameter("@IPMD_UseDays", SqlDbType.Int,4),
 new SqlParameter("@IPMD_LeftDays", SqlDbType.Int,4),
new SqlParameter("@IPMD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.IPMD_IPMID;
            parameters[1].Value = model.IPMD_FID;
            parameters[2].Value = model.IPMD_Type;
            parameters[3].Value = model.IPMD_Name;
            parameters[4].Value = model.IPMD_Days;
            parameters[5].Value = model.IPMD_FloatingDays;
            parameters[6].Value = model.IPMD_PreTask;
            parameters[7].Value = model.IPMD_EarlyBeginTime;
            parameters[8].Value = model.IPMD_EarlyEndTime;
            parameters[9].Value = model.IPMD_AtLatestBeginTime;
            parameters[10].Value = model.IPMD_AtLatestEndTime;
            parameters[11].Value = model.IPMD_DutyPerson;
            parameters[12].Value = model.IPMD_Executor;
            parameters[13].Value = model.IPMD_Remarks;
            parameters[14].Value = model.IPMD_Del;
            parameters[15].Value = model.IPMD_Mender;
            parameters[16].Value = model.IPMD_MTime;
            parameters[17].Value = model.IPMD_FTaskID;
            parameters[18].Value = model.IPMD_Level;
            parameters[19].Value = model.IPMD_WorkType;
            parameters[20].Value = model.IPMD_State;
            parameters[21].Value = model.IPMD_ProjectType;
            parameters[22].Value = model.IPMD_Import;
            parameters[23].Value = model.IPMD_Precent;
            parameters[24].Value = model.IPMD_Persons;
            parameters[25].Value = model.IPMD_DaysType;
            parameters[26].Value = model.IPMD_HolidayType;
            parameters[27].Value = model.IPMD_UseDays;
            parameters[28].Value = model.IPMD_LeftDays;
            parameters[29].Value = model.IPMD_ID;

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

        public bool Load(string s_TID, string s_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into IM_Project_Manage_Details(");
            strSql.Append("IPMD_ID,IPMD_IPMID,IPMD_FID,IPMD_Type,IPMD_Name,IPMD_Days,IPMD_FloatingDays,IPMD_PreTask,IPMD_DutyPerson,IPMD_Executor,IPMD_Remarks,IPMD_Creator,IPMD_CTime,IPMD_Del,IPMD_Mender,IPMD_MTime,IPMD_FTaskID,IPMD_Level ");
            strSql.Append(") select IPMD_ID+'" + s_ID + "','" + s_ID + "',case when IPMD_FID='' then '' else IPMD_FID+'" + s_ID + "' end ,IPMD_Type");
            strSql.Append(",IPMD_Name,IPMD_Days,IPMD_FloatingDays,IPMD_PreTask,IPMD_DutyPerson,IPMD_Executor,IPMD_Remarks,IPMD_Creator,IPMD_CTime,IPMD_Del,IPMD_Mender,IPMD_MTime,IPMD_FTaskID,IPMD_Level  ");
            strSql.Append(" From IM_Project_Manage_Details ");
            strSql.Append(" where IPMD_IPMID='" + s_TID + "' ");

            if (DbHelperSQL.ExecuteSql(strSql.ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Delete
        /// </summary>
        public bool Delete(string s_IPMD_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  IM_Project_Manage_Details  ");
            strSql.Append(" where IPMD_ID=@IPMD_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@IPMD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = s_IPMD_ID;
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
        /// Delete
        /// </summary>
        public bool UpdateDel(KNet.Model.IM_Project_Manage_Details model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update   IM_Project_Manage_Details  Set ");
            strSql.Append("  IPMD_Del=@IPMD_Del ");
            strSql.Append(" where IPMD_ID=@IPMD_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@IPMD_Del", SqlDbType.Int,4),
new SqlParameter("@IPMD_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.IPMD_Del;
            parameters[1].Value = model.IPMD_ID;

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
        /// Delete
        /// </summary>
        public bool DeleteList(string s_IPMD_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From   IM_Project_Manage_Details  ");
            strSql.Append(" where IPMD_ID in ('" + s_IPMD_ID + "')");

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
        /// DeleteByFID
        /// </summary>
        public bool DeleteByFID(string s_FID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  IM_Project_Manage_Details  ");
            strSql.Append(" Where  IPMD_IPMID=@IPMD_IPMID ");
            SqlParameter[] parameters = {
 new SqlParameter("@IPMD_IPMID", SqlDbType.VarChar,50),
};
            parameters[0].Value = s_FID;

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
        /// 得到数据
        /// </summary>
        public KNet.Model.IM_Project_Manage_Details GetModel(string IPMD_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from IM_Project_Manage_Details  ");
            strSql.Append("where IPMD_ID=@IPMD_ID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@IPMD_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = IPMD_ID;
            KNet.Model.IM_Project_Manage_Details model = new KNet.Model.IM_Project_Manage_Details();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public KNet.Model.IM_Project_Manage_Details DataRowToModel(DataRow row)
        {
            KNet.Model.IM_Project_Manage_Details model = new KNet.Model.IM_Project_Manage_Details();
            if (row != null)
            {
                if (row["IPMD_ID"] != null)
                {
                    model.IPMD_ID = row["IPMD_ID"].ToString();
                }
                else
                {
                    model.IPMD_ID = "";
                }
                if (row["IPMD_IPMID"] != null)
                {
                    model.IPMD_IPMID = row["IPMD_IPMID"].ToString();
                }
                else
                {
                    model.IPMD_IPMID = "";
                }
                if (row["IPMD_FID"] != null)
                {
                    model.IPMD_FID = row["IPMD_FID"].ToString();
                }
                else
                {
                    model.IPMD_FID = "";
                }
                if (row["IPMD_Type"] != null)
                {
                    model.IPMD_Type = int.Parse(row["IPMD_Type"].ToString());
                }
                else
                {
                    model.IPMD_Type = 0;
                }
                if (row["IPMD_Name"] != null)
                {
                    model.IPMD_Name = row["IPMD_Name"].ToString();
                }
                else
                {
                    model.IPMD_Name = "";
                }
                if (row["IPMD_Days"] != null)
                {
                    model.IPMD_Days = int.Parse(row["IPMD_Days"].ToString());
                }
                else
                {
                    model.IPMD_Days = 0;
                }
                if (row["IPMD_FloatingDays"] != null)
                {
                    model.IPMD_FloatingDays = int.Parse(row["IPMD_FloatingDays"].ToString());
                }
                else
                {
                    model.IPMD_FloatingDays = 0;
                }
                if (row["IPMD_PreTask"] != null)
                {
                    model.IPMD_PreTask = row["IPMD_PreTask"].ToString();
                }
                else
                {
                    model.IPMD_PreTask = "";
                }
                if (row["IPMD_EarlyBeginTime"] != null)
                {
                    model.IPMD_EarlyBeginTime = DateTime.Parse(row["IPMD_EarlyBeginTime"].ToString());
                }
                if (row["IPMD_EarlyEndTime"] != null)
                {
                    model.IPMD_EarlyEndTime = DateTime.Parse(row["IPMD_EarlyEndTime"].ToString());
                }
                if (row["IPMD_AtLatestBeginTime"] != null)
                {
                    model.IPMD_AtLatestBeginTime = DateTime.Parse(row["IPMD_AtLatestBeginTime"].ToString());
                }
                if (row["IPMD_AtLatestEndTime"] != null)
                {
                    model.IPMD_AtLatestEndTime = DateTime.Parse(row["IPMD_AtLatestEndTime"].ToString());
                }
                if (row["IPMD_DutyPerson"] != null)
                {
                    model.IPMD_DutyPerson = row["IPMD_DutyPerson"].ToString();
                }
                else
                {
                    model.IPMD_DutyPerson = "";
                }
                if (row["IPMD_Executor"] != null)
                {
                    model.IPMD_Executor = row["IPMD_Executor"].ToString();
                }
                else
                {
                    model.IPMD_Executor = "";
                }
                if (row["IPMD_Remarks"] != null)
                {
                    model.IPMD_Remarks = row["IPMD_Remarks"].ToString();
                }
                else
                {
                    model.IPMD_Remarks = "";
                }
                if (row["IPMD_Creator"] != null)
                {
                    model.IPMD_Creator = row["IPMD_Creator"].ToString();
                }
                else
                {
                    model.IPMD_Creator = "";
                }
                if (row["IPMD_CTime"] != null)
                {
                    model.IPMD_CTime = DateTime.Parse(row["IPMD_CTime"].ToString());
                }
                if (row["IPMD_Del"] != null)
                {
                    model.IPMD_Del = int.Parse(row["IPMD_Del"].ToString());
                }
                else
                {
                    model.IPMD_Del = 0;
                }
                if (row["IPMD_Mender"] != null)
                {
                    model.IPMD_Mender = row["IPMD_Mender"].ToString();
                }
                else
                {
                    model.IPMD_Mender = "";
                }
                if (row["IPMD_MTime"] != null)
                {
                    model.IPMD_MTime = DateTime.Parse(row["IPMD_MTime"].ToString());
                }
                if (row["IPMD_FTaskID"] != null)
                {
                    model.IPMD_FTaskID = row["IPMD_FTaskID"].ToString();
                }
                else
                {
                    model.IPMD_FTaskID = "";
                }
                if (row["IPMD_Level"] != null)
                {
                    model.IPMD_Level = int.Parse(row["IPMD_Level"].ToString());
                }
                else
                {
                    model.IPMD_Level = 0;
                }
                if (row["IPMD_WorkType"] != null)
                {
                    model.IPMD_WorkType = int.Parse(row["IPMD_WorkType"].ToString());
                }
                else
                {
                    model.IPMD_WorkType = 0;
                }
                if (row["IPMD_State"] != null)
                {
                    model.IPMD_State = int.Parse(row["IPMD_State"].ToString());
                }
                else
                {
                    model.IPMD_State = 0;
                }
                if (row["IPMD_ProjectType"] != null)
                {
                    model.IPMD_ProjectType = int.Parse(row["IPMD_ProjectType"].ToString());
                }
                else
                {
                    model.IPMD_ProjectType = 0;
                }
                if (row["IPMD_Import"] != null)
                {
                    model.IPMD_Import = int.Parse(row["IPMD_Import"].ToString());
                }
                else
                {
                    model.IPMD_Import = 0;
                }
                if (row["IPMD_Precent"] != null)
                {
                    model.IPMD_Precent = Decimal.Parse(row["IPMD_Precent"].ToString());
                }
                else
                {
                    model.IPMD_Precent = 0;
                }
                if (row["IPMD_Persons"] != null)
                {
                    model.IPMD_Persons = row["IPMD_Persons"].ToString();
                }
                else
                {
                    model.IPMD_Persons = "";
                }
                if (row["IPMD_DaysType"] != null)
                {
                    model.IPMD_DaysType = int.Parse(row["IPMD_DaysType"].ToString());
                }
                else
                {
                    model.IPMD_DaysType = 0;
                }
                if (row["IPMD_HolidayType"] != null)
                {
                    model.IPMD_HolidayType = int.Parse(row["IPMD_HolidayType"].ToString());
                }
                else
                {
                    model.IPMD_HolidayType = 0;
                }
                if (row["IPMD_UseDays"] != null)
                {
                    model.IPMD_UseDays = int.Parse(row["IPMD_UseDays"].ToString());
                }
                else
                {
                    model.IPMD_UseDays = 0;
                }
                if (row["IPMD_LeftDays"] != null)
                {
                    model.IPMD_LeftDays = int.Parse(row["IPMD_LeftDays"].ToString());
                }
                else
                {
                    model.IPMD_LeftDays = 0;
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * ");
            strSql.Append(" FROM IM_Project_Manage_Details ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

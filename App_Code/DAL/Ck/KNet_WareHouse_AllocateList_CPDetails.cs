using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class KNet_WareHouse_AllocateList_CPDetails
    {
        public KNet_WareHouse_AllocateList_CPDetails()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KWAC_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KNet_WareHouse_AllocateList_CPDetails");
            strSql.Append(" where KWAC_ID=@KWAC_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@KWAC_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = KWAC_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.KNet_WareHouse_AllocateList_CPDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_WareHouse_AllocateList_CPDetails(");
            strSql.Append("KWAC_ID,KWAC_AllocateNo,KWAC_OrderNoID,KWAC_Number,KWAC_Creator,KWAC_CTime ");
            strSql.Append(") values (");
            strSql.Append("@KWAC_ID,@KWAC_AllocateNo,@KWAC_OrderNoID,@KWAC_Number,@KWAC_Creator,@KWAC_CTime)");
            SqlParameter[] parameters = {
 new SqlParameter("@KWAC_ID", SqlDbType.VarChar,50),
 new SqlParameter("@KWAC_AllocateNo", SqlDbType.VarChar,50),
 new SqlParameter("@KWAC_OrderNoID", SqlDbType.VarChar,50),
 new SqlParameter("@KWAC_Number", SqlDbType.Int,4),
 new SqlParameter("@KWAC_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@KWAC_CTime", SqlDbType.DateTime,8)};
            parameters[0].Value = model.KWAC_ID;
            parameters[1].Value = model.KWAC_AllocateNo;
            parameters[2].Value = model.KWAC_OrderNoID;
            parameters[3].Value = model.KWAC_Number;
            parameters[4].Value = model.KWAC_Creator;
            parameters[5].Value = model.KWAC_CTime;
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
        public bool Update(KNet.Model.KNet_WareHouse_AllocateList_CPDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update KNet_WareHouse_AllocateList_CPDetails set ");
            strSql.Append("KWAC_AllocateNo=@KWAC_AllocateNo,");
            strSql.Append("KWAC_OrderNoID=@KWAC_OrderNoID,");
            strSql.Append("KWAC_Number=@KWAC_Number");
            strSql.Append(" where KWAC_ID=@KWAC_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@KWAC_AllocateNo", SqlDbType.VarChar,50),
 new SqlParameter("@KWAC_OrderNoID", SqlDbType.VarChar,50),
 new SqlParameter("@KWAC_Number", SqlDbType.Int,4),
new SqlParameter("@KWAC_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KWAC_AllocateNo;
            parameters[1].Value = model.KWAC_OrderNoID;
            parameters[2].Value = model.KWAC_Number;
            parameters[3].Value = model.KWAC_ID;

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
        public bool Delete(string s_KWAC_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  KNet_WareHouse_AllocateList_CPDetails  ");
            strSql.Append(" where KWAC_ID=@KWAC_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@KWAC_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = s_KWAC_ID;
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
        public bool UpdateDel(KNet.Model.KNet_WareHouse_AllocateList_CPDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update   KNet_WareHouse_AllocateList_CPDetails  Set ");
            strSql.Append(" where KWAC_ID=@KWAC_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@KWAC_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.KWAC_ID;

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
        public bool DeleteList(string s_KWAC_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From   KNet_WareHouse_AllocateList_CPDetails  ");
            strSql.Append(" where KWAC_ID in ('" + s_KWAC_ID + "')");

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
        public bool DeleteByAllocateNo(string s_FID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  KNet_WareHouse_AllocateList_CPDetails  ");
            strSql.Append(" where KWAC_AllocateNo=@KWAC_AllocateNo ");
            SqlParameter[] parameters = {
new SqlParameter("@KWAC_AllocateNo", SqlDbType.VarChar,50)};
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
        public KNet.Model.KNet_WareHouse_AllocateList_CPDetails GetModel(string KWAC_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from KNet_WareHouse_AllocateList_CPDetails  ");
            strSql.Append("where KWAC_ID=@KWAC_ID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@KWAC_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = KWAC_ID;
            KNet.Model.KNet_WareHouse_AllocateList_CPDetails model = new KNet.Model.KNet_WareHouse_AllocateList_CPDetails();
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
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_AllocateList_CPDetails DataRowToModel(DataRow row)
        {
            KNet.Model.KNet_WareHouse_AllocateList_CPDetails model = new KNet.Model.KNet_WareHouse_AllocateList_CPDetails();
            if (row != null)
            {
                if (row["KWAC_ID"] != null)
                {
                    model.KWAC_ID = row["KWAC_ID"].ToString();
                }
                else
                {
                    model.KWAC_ID = "";
                }
                if (row["KWAC_AllocateNo"] != null)
                {
                    model.KWAC_AllocateNo = row["KWAC_AllocateNo"].ToString();
                }
                else
                {
                    model.KWAC_AllocateNo = "";
                }
                if (row["KWAC_OrderNoID"] != null)
                {
                    model.KWAC_OrderNoID = row["KWAC_OrderNoID"].ToString();
                }
                else
                {
                    model.KWAC_OrderNoID = "";
                }
                if (row["KWAC_Number"] != null)
                {
                    model.KWAC_Number = int.Parse(row["KWAC_Number"].ToString());
                }
                else
                {
                    model.KWAC_Number = 0;
                }
                if (row["KWAC_Creator"] != null)
                {
                    model.KWAC_Creator = row["KWAC_Creator"].ToString();
                }
                else
                {
                    model.KWAC_Creator = "";
                }
                if (row["KWAC_CTime"] != null)
                {
                    model.KWAC_CTime = DateTime.Parse(row["KWAC_CTime"].ToString());
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
            strSql.Append("select * ");
            strSql.Append(" FROM KNet_WareHouse_AllocateList_CPDetails ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

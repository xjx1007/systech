using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class Cw_Bill_DirectOut_PayDetails
    {
        public Cw_Bill_DirectOut_PayDetails()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CBDP_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cw_Bill_DirectOut_PayDetails");
            strSql.Append(" where CBDP_ID=@CBDP_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@CBDP_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = CBDP_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.Cw_Bill_DirectOut_PayDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cw_Bill_DirectOut_PayDetails(");
            strSql.Append("CBDP_ID,CBDP_Code,CBDP_PayMentID,CBDP_DetailsID,CBDP_Money,CBDP_Del,CBDP_CTime,CBDP_Creator,CBDP_MTime,CBDP_Mender,CBDP_FPOutID ");
            strSql.Append(") values (");
            strSql.Append("@CBDP_ID,@CBDP_Code,@CBDP_PayMentID,@CBDP_DetailsID,@CBDP_Money,@CBDP_Del,@CBDP_CTime,@CBDP_Creator,@CBDP_MTime,@CBDP_Mender,@CBDP_FPOutID)");
            SqlParameter[] parameters = {
 new SqlParameter("@CBDP_ID", SqlDbType.VarChar,50),
 new SqlParameter("@CBDP_Code", SqlDbType.VarChar,50),
 new SqlParameter("@CBDP_PayMentID", SqlDbType.VarChar,50),
 new SqlParameter("@CBDP_DetailsID", SqlDbType.VarChar,50),
 new SqlParameter("@CBDP_Money", SqlDbType.Decimal,9),
 new SqlParameter("@CBDP_Del", SqlDbType.Int,4),
 new SqlParameter("@CBDP_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@CBDP_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@CBDP_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@CBDP_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@CBDP_FPOutID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CBDP_ID;
            parameters[1].Value = model.CBDP_Code;
            parameters[2].Value = model.CBDP_PayMentID;
            parameters[3].Value = model.CBDP_DetailsID;
            parameters[4].Value = model.CBDP_Money;
            parameters[5].Value = model.CBDP_Del;
            parameters[6].Value = model.CBDP_CTime;
            parameters[7].Value = model.CBDP_Creator;
            parameters[8].Value = model.CBDP_MTime;
            parameters[9].Value = model.CBDP_Mender;
            parameters[10].Value = model.CBDP_FPOutID;
            
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
        public bool Update(KNet.Model.Cw_Bill_DirectOut_PayDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update Cw_Bill_DirectOut_PayDetails set ");
            strSql.Append("CBDP_Code=@CBDP_Code,");
            strSql.Append("CBDP_PayMentID=@CBDP_PayMentID,");
            strSql.Append("CBDP_DetailsID=@CBDP_DetailsID,");
            strSql.Append("CBDP_Money=@CBDP_Money,");
            strSql.Append("CBDP_Del=@CBDP_Del,");
            strSql.Append("CBDP_MTime=@CBDP_MTime,");
            strSql.Append("CBDP_Mender=@CBDP_Mender,");
            strSql.Append("CBDP_FPOutID=@CBDP_FPOutID");
            
            strSql.Append(" where CBDP_ID=@CBDP_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@CBDP_Code", SqlDbType.VarChar,50),
 new SqlParameter("@CBDP_PayMentID", SqlDbType.VarChar,50),
 new SqlParameter("@CBDP_DetailsID", SqlDbType.VarChar,50),
 new SqlParameter("@CBDP_Money", SqlDbType.Decimal,9),
 new SqlParameter("@CBDP_Del", SqlDbType.Int,4),
 new SqlParameter("@CBDP_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@CBDP_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@CBDP_FPOutID", SqlDbType.VarChar,50),
new SqlParameter("@CBDP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CBDP_Code;
            parameters[1].Value = model.CBDP_PayMentID;
            parameters[2].Value = model.CBDP_DetailsID;
            parameters[3].Value = model.CBDP_Money;
            parameters[4].Value = model.CBDP_Del;
            parameters[5].Value = model.CBDP_MTime;
            parameters[6].Value = model.CBDP_Mender;
            parameters[7].Value = model.CBDP_FPOutID;
            
            parameters[8].Value = model.CBDP_ID;

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
        public bool Delete(string s_CBDP_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  Cw_Bill_DirectOut_PayDetails  ");
            strSql.Append(" where CBDP_ID=@CBDP_ID ");
            SqlParameter[] parameters = {
new SqlParameter("@CBDP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = s_CBDP_ID;
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
        public bool UpdateDel(KNet.Model.Cw_Bill_DirectOut_PayDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update   Cw_Bill_DirectOut_PayDetails  Set ");
            strSql.Append("  CBDP_Del=@CBDP_Del ");
            strSql.Append(" where CBDP_ID=@CBDP_ID ");
            SqlParameter[] parameters = {
 new SqlParameter("@CBDP_Del", SqlDbType.Int,4),
new SqlParameter("@CBDP_ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CBDP_Del;
            parameters[1].Value = model.CBDP_ID;

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
        public bool DeleteList(string s_CBDP_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From   Cw_Bill_DirectOut_PayDetails  ");
            strSql.Append(" where CBDP_ID in ('" + s_CBDP_ID + "')");

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
        /// QueryByFID
        /// </summary>
        public DataSet QueryByFID(string s_FID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from  Cw_Bill_DirectOut_PayDetails  ");
            SqlParameter[] parameters = {
};

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// Delete
        /// </summary>
        public bool DeleteByFID(string s_FID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  Cw_Bill_DirectOut_PayDetails  ");
            strSql.Append(" where CBDP_PayMentID=@CBDP_PayMentID ");
            SqlParameter[] parameters = {
new SqlParameter("@CBDP_PayMentID", SqlDbType.VarChar,50)};
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
        public KNet.Model.Cw_Bill_DirectOut_PayDetails GetModel(string CBDP_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from Cw_Bill_DirectOut_PayDetails  ");
            strSql.Append("where CBDP_ID=@CBDP_ID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@CBDP_ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = CBDP_ID;
            KNet.Model.Cw_Bill_DirectOut_PayDetails model = new KNet.Model.Cw_Bill_DirectOut_PayDetails();
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
        public KNet.Model.Cw_Bill_DirectOut_PayDetails DataRowToModel(DataRow row)
        {
            KNet.Model.Cw_Bill_DirectOut_PayDetails model = new KNet.Model.Cw_Bill_DirectOut_PayDetails();
            if (row != null)
            {
                if (row["CBDP_ID"] != null)
                {
                    model.CBDP_ID = row["CBDP_ID"].ToString();
                }
                else
                {
                    model.CBDP_ID = "";
                }
                if (row["CBDP_Code"] != null)
                {
                    model.CBDP_Code = row["CBDP_Code"].ToString();
                }
                else
                {
                    model.CBDP_Code = "";
                }
                if (row["CBDP_PayMentID"] != null)
                {
                    model.CBDP_PayMentID = row["CBDP_PayMentID"].ToString();
                }
                else
                {
                    model.CBDP_PayMentID = "";
                }
                if (row["CBDP_DetailsID"] != null)
                {
                    model.CBDP_DetailsID = row["CBDP_DetailsID"].ToString();
                }
                else
                {
                    model.CBDP_DetailsID = "";
                }
                if (row["CBDP_Money"] != null)
                {
                    model.CBDP_Money = Decimal.Parse(row["CBDP_Money"].ToString());
                }
                else
                {
                    model.CBDP_Money = 0;
                }
                if (row["CBDP_Del"] != null)
                {
                    model.CBDP_Del = int.Parse(row["CBDP_Del"].ToString());
                }
                else
                {
                    model.CBDP_Del = 0;
                }
                if (row["CBDP_CTime"] != null)
                {
                    model.CBDP_CTime = DateTime.Parse(row["CBDP_CTime"].ToString());
                }
                if (row["CBDP_Creator"] != null)
                {
                    model.CBDP_Creator = row["CBDP_Creator"].ToString();
                }
                else
                {
                    model.CBDP_Creator = "";
                }
                if (row["CBDP_MTime"] != null)
                {
                    model.CBDP_MTime = DateTime.Parse(row["CBDP_MTime"].ToString());
                }
                if (row["CBDP_Mender"] != null)
                {
                    model.CBDP_Mender = row["CBDP_Mender"].ToString();
                }
                else
                {
                    model.CBDP_Mender = "";
                }
                if (row["CBDP_FPOutID"] != null)
                {
                    model.CBDP_Mender = row["CBDP_FPOutID"].ToString();
                }
                else
                {
                    model.CBDP_Mender = "";
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
            strSql.Append(" FROM Cw_Bill_DirectOut_PayDetails ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

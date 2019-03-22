using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class KNet_Sampling_List
    {
        public KNet_Sampling_List()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from KNet_Sampling_List");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
new SqlParameter("@ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加
        /// </summary>
        public bool Add(KNet.Model.KNet_Sampling_List model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into KNet_Sampling_List(");
            strSql.Append("ID,ReID,SampleName,Number,ProjectGroup,Packaging,UploadFile,Price,BuyRank,HouseClass,STime,EndTime,Proposer,Remark,InState,BuyState,AuditState ");
            strSql.Append(") values (");
            strSql.Append("@ID,@ReID,@SampleName,@Number,@ProjectGroup,@Packaging,@UploadFile,@Price,@BuyRank,@HouseClass,@STime,@EndTime,@Proposer,@Remark,@InState,@BuyState,@AuditState)");
            SqlParameter[] parameters = {
 new SqlParameter("@ID", SqlDbType.VarChar,50),
 new SqlParameter("@ReID", SqlDbType.VarChar,50),
 new SqlParameter("@SampleName", SqlDbType.VarChar,100),
 new SqlParameter("@Number", SqlDbType.Int,4),
 new SqlParameter("@ProjectGroup", SqlDbType.VarChar,100),
 new SqlParameter("@Packaging", SqlDbType.VarChar,100),
 new SqlParameter("@UploadFile", SqlDbType.VarChar,100),
 new SqlParameter("@Price", SqlDbType.Decimal,9),
 new SqlParameter("@BuyRank", SqlDbType.VarChar,10),
  new SqlParameter("@HouseClass", SqlDbType.VarChar,10),
 new SqlParameter("@STime", SqlDbType.DateTime,8),
 new SqlParameter("@EndTime", SqlDbType.DateTime,8),
 new SqlParameter("@Proposer", SqlDbType.VarChar,50),
 new SqlParameter("@Remark", SqlDbType.VarChar,16),
 new SqlParameter("@InState", SqlDbType.VarChar,50),
 new SqlParameter("@BuyState", SqlDbType.VarChar,50),
 new SqlParameter("@AuditState", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ReID;
            parameters[2].Value = model.SampleName;
            parameters[3].Value = model.Number;
            parameters[4].Value = model.ProjectGroup;
            parameters[5].Value = model.Packaging;
            parameters[6].Value = model.UploadFile;
            parameters[7].Value = model.Price;
            parameters[8].Value = model.BuyRank;
            parameters[9].Value = model.HouseClass;
            parameters[10].Value = model.STime;
            parameters[11].Value = model.EndTime;
            parameters[12].Value = model.Proposer;
            parameters[13].Value = model.Remark;
            parameters[14].Value = model.InState;
            parameters[15].Value = model.BuyState;
            parameters[16].Value = model.AuditState;
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
        public bool Update(KNet.Model.KNet_Sampling_List model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update KNet_Sampling_List set ");

            strSql.Append("ID=@ID, ");
            strSql.Append("SampleName=@SampleName,");
            strSql.Append("Number=@Number,");
            strSql.Append("ProjectGroup=@ProjectGroup,");
            strSql.Append("Packaging=@Packaging,");
            strSql.Append("UploadFile=@UploadFile,");
            strSql.Append("Price=@Price,");
            strSql.Append("BuyRank=@BuyRank,");
            strSql.Append("HouseClass=@HouseClass,");
            strSql.Append("STime=@STime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("Proposer=@Proposer,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("InState=@InState,");
            strSql.Append("BuyState=@BuyState,");
            strSql.Append("AuditState=@AuditState ");
           
            strSql.Append(" where ReID=@ReID");
            SqlParameter[] parameters = {
 new SqlParameter("@ID", SqlDbType.VarChar,50),
 new SqlParameter("@SampleName", SqlDbType.VarChar,100),
 new SqlParameter("@Number", SqlDbType.Int,4),
 new SqlParameter("@ProjectGroup", SqlDbType.VarChar,100),
 new SqlParameter("@Packaging", SqlDbType.VarChar,100),
 new SqlParameter("@UploadFile", SqlDbType.VarChar,100),
 new SqlParameter("@Price", SqlDbType.Decimal,9),
 new SqlParameter("@BuyRank", SqlDbType.VarChar,10),
 new SqlParameter("@HouseClass", SqlDbType.VarChar,50),
 new SqlParameter("@STime", SqlDbType.DateTime,8),
 new SqlParameter("@EndTime", SqlDbType.DateTime,8),
 new SqlParameter("@Proposer", SqlDbType.VarChar,50),
 new SqlParameter("@Remark", SqlDbType.VarChar,16),
 new SqlParameter("@InState", SqlDbType.VarChar,50),
 new SqlParameter("@BuyState", SqlDbType.VarChar,50),
 new SqlParameter("@AuditState", SqlDbType.VarChar,50),

            new SqlParameter("@ReID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SampleName;
            parameters[2].Value = model.Number;
            parameters[3].Value = model.ProjectGroup;
            parameters[4].Value = model.Packaging;
            parameters[5].Value = model.UploadFile;
            parameters[6].Value = model.Price;
            parameters[7].Value = model.BuyRank;
            parameters[8].Value = model.HouseClass;
            parameters[9].Value = model.STime;
            parameters[10].Value = model.EndTime;
            parameters[11].Value = model.Proposer;
            parameters[12].Value = model.Remark;
            parameters[13].Value = model.InState;
            parameters[14].Value = model.BuyState;
            parameters[15].Value = model.AuditState;
            parameters[16].Value = model.ReID;

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
        public bool Delete(string s_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  KNet_Sampling_List  ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
new SqlParameter("@ID", SqlDbType.VarChar,50)};
            parameters[0].Value = s_ID;
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
        public bool Delete1(string s_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  KNet_Sampling_List  ");
            strSql.Append(" where ReID=@ReID ");
            SqlParameter[] parameters = {
new SqlParameter("@ReID", SqlDbType.VarChar,50)};
            parameters[0].Value = s_ID;
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
        public bool UpdateDel(KNet.Model.KNet_Sampling_List model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update   KNet_Sampling_List  Set ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
new SqlParameter("@ID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ID;

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
        public bool DeleteList(string s_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Delete From   KNet_Sampling_List  ");
            strSql.Append(" where ID in ('" + s_ID + "')");

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
            strSql.Append("Select * from  KNet_Sampling_List  ");
            SqlParameter[] parameters = {
};

            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// DeleteByFID
        /// </summary>
        public bool DeleteByFID(string s_FID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  KNet_Sampling_List  ");
            SqlParameter[] parameters = {
};

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
        /// 根据请购单得到数据
        /// </summary>
        public KNet.Model.KNet_Sampling_List GetModel(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from KNet_Sampling_List  ");
            strSql.Append("where ID=@ID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@ID", SqlDbType.VarChar,50)
};
            parameters[0].Value = ID;
            KNet.Model.KNet_Sampling_List model = new KNet.Model.KNet_Sampling_List();
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
        /// 根据请购单得到数据
        /// </summary>
        public KNet.Model.KNet_Sampling_List GetModelByReID(string ReID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from KNet_Sampling_List  ");
            strSql.Append("where ReID=@ReID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@ReID", SqlDbType.VarChar,50)
};
            parameters[0].Value = ReID;
            KNet.Model.KNet_Sampling_List model = new KNet.Model.KNet_Sampling_List();
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
        public KNet.Model.KNet_Sampling_List DataRowToModel(DataRow row)
        {
            KNet.Model.KNet_Sampling_List model = new KNet.Model.KNet_Sampling_List();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                else
                {
                    model.ID = "";
                }
                if (row["ReID"] != null)
                {
                    model.ReID = row["ReID"].ToString();
                }
                else
                {
                    model.ReID = "";
                }
                if (row["SampleName"] != null)
                {
                    model.SampleName = row["SampleName"].ToString();
                }
                else
                {
                    model.SampleName = "";
                }
                if (row["Number"] != null)
                {
                    model.Number = int.Parse(row["Number"].ToString());
                }
                else
                {
                    model.Number = 0;
                }
                if (row["ProjectGroup"] != null)
                {
                    model.ProjectGroup = row["ProjectGroup"].ToString();
                }
                else
                {
                    model.ProjectGroup = "";
                }
                if (row["Packaging"] != null)
                {
                    model.Packaging = row["Packaging"].ToString();
                }
                else
                {
                    model.Packaging = "";
                }
                if (row["UploadFile"] != null)
                {
                    model.UploadFile = row["UploadFile"].ToString();
                }
                else
                {
                    model.UploadFile = "";
                }
                if (row["Price"] != null)
                {
                    model.Price = Decimal.Parse(row["Price"].ToString());
                }
                else
                {
                    model.Price = 0;
                }
              
                if (row["BuyRank"] != null)
                {
                    model.BuyRank = row["BuyRank"].ToString();
                }
                else
                {
                    model.BuyRank = "";
                }
                if (row["HouseClass"] != null)
                {
                    model.HouseClass = row["HouseClass"].ToString();
                }
                else
                {
                    model.HouseClass = "";
                }
                if (row["STime"] != null)
                {
                    model.STime = DateTime.Parse(row["STime"].ToString());
                }
                if (row["EndTime"] != null)
                {
                    model.EndTime = DateTime.Parse(row["EndTime"].ToString());
                }
                if (row["Proposer"] != null)
                {
                    model.Proposer = row["Proposer"].ToString();
                }
                else
                {
                    model.Proposer = "";
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                else
                {
                    model.Remark = "";
                }
                if (row["InState"] != null)
                {
                    model.InState = row["InState"].ToString();
                }
                else
                {
                    model.InState = "";
                }
                if (row["BuyState"] != null)
                {
                    model.BuyState = row["BuyState"].ToString();
                }
                else
                {
                    model.BuyState = "";
                }
                if (row["AuditState"] != null)
                {
                    model.AuditState = row["AuditState"].ToString();
                }
                else
                {
                    model.AuditState = "";
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
            strSql.Append("select distinct ID ");
            strSql.Append(" FROM KNet_Sampling_List ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetList1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM KNet_Sampling_List ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
    public partial class Knet_Sampling_OpenBilling
    {
        public Knet_Sampling_OpenBilling()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Knet_Sampling_OpenBilling");
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
        public bool Add(KNet.Model.Knet_Sampling_OpenBilling model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Knet_Sampling_OpenBilling(");
            strSql.Append("ID,YID,ReID,SamplingName,Number,Department,Price,Supplier,HouseNo,STime,Proposer,Remark,RState,ProjectGroup ");
            strSql.Append(") values (");
            strSql.Append("@ID,@YID,@ReID,@SamplingName,@Number,@Department,@Price,@Supplier,@HouseNo,@STime,@Proposer,@Remark,@RState,@ProjectGroup)");
            SqlParameter[] parameters = {
 
 new SqlParameter("@ID", SqlDbType.VarChar,100),
 
 new SqlParameter("@YID", SqlDbType.VarChar,100),

 new SqlParameter("@ReID", SqlDbType.VarChar,100),
 
 new SqlParameter("@SamplingName", SqlDbType.VarChar,400),
 new SqlParameter("@Number", SqlDbType.Int,4),

 new SqlParameter("@Department", SqlDbType.VarChar,100),
 new SqlParameter("@Price", SqlDbType.Decimal,9),

 new SqlParameter("@Supplier", SqlDbType.VarChar,200),
 new SqlParameter("@HouseNo", SqlDbType.VarChar,200),
 new SqlParameter("@STime", SqlDbType.DateTime,8),

 new SqlParameter("@Proposer", SqlDbType.VarChar,100),
 new SqlParameter("@Remark", SqlDbType.VarChar,50),
             new SqlParameter("@RState", SqlDbType.VarChar,50),
            new SqlParameter("@ProjectGroup", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ID;

            parameters[1].Value = model.YID;

            parameters[2].Value = model.ReID;

            parameters[3].Value = model.SamplingName;

            parameters[4].Value = model.Number;
            parameters[5].Value = model.Department;
  
            parameters[6].Value = model.Price;
            parameters[7].Value = model.Supplier;
            parameters[8].Value = model.HouseNo;
            parameters[9].Value = model.STime;
            parameters[10].Value = model.Proposer;
           
            parameters[11].Value = model.Remark;
            parameters[12].Value = model.RState;
            parameters[13].Value = model.ProjectGroup;
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
        public bool Update(KNet.Model.Knet_Sampling_OpenBilling model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update Knet_Sampling_OpenBilling set ");
           
            
            strSql.Append("SamplingName=@SamplingName,");
            strSql.Append("Number=@Number,");
           
            strSql.Append("Department=@Department,");
            strSql.Append("Price=@Price,");

            strSql.Append("Proposer=@Proposer,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where ReID=@ReID ");
            SqlParameter[] parameters = {
 

 new SqlParameter("@SamplingName", SqlDbType.VarChar,400),

 new SqlParameter("@Number", SqlDbType.Int,4),
 new SqlParameter("@Department", SqlDbType.VarChar,100),

 new SqlParameter("@Price", SqlDbType.Decimal,9),

 new SqlParameter("@Proposer", SqlDbType.VarChar,100),
 new SqlParameter("@Remark", SqlDbType.VarChar,200),
new SqlParameter("@ReID", SqlDbType.VarChar,100)};
         

            parameters[0].Value = model.SamplingName;
            parameters[1].Value = model.Number;

            parameters[2].Value = model.Department;
            parameters[3].Value = model.Price;
            parameters[4].Value = model.Proposer;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.ReID;

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
            strSql.Append("delete from  Knet_Sampling_OpenBilling  ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
new SqlParameter("@ID", SqlDbType.VarChar,100)};
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
        public bool UpdateDel(KNet.Model.Knet_Sampling_OpenBilling model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update   Knet_Sampling_OpenBilling  Set ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
new SqlParameter("@ID", SqlDbType.VarChar,100)};
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
            strSql.Append("Delete From   Knet_Sampling_OpenBilling  ");
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
            strSql.Append("Select * from  Knet_Sampling_OpenBilling  ");
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
            strSql.Append("delete from  Knet_Sampling_OpenBilling  ");
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
        /// 得到数据
        /// </summary>
        public KNet.Model.Knet_Sampling_OpenBilling GetModel(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from Knet_Sampling_OpenBilling  ");
            strSql.Append("where ID=@ID  ");
            SqlParameter[] parameters = {
 new SqlParameter("@ID", SqlDbType.VarChar,100)
};
            parameters[0].Value = ID;
            KNet.Model.Knet_Sampling_OpenBilling model = new KNet.Model.Knet_Sampling_OpenBilling();
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
        public KNet.Model.Knet_Sampling_OpenBilling DataRowToModel(DataRow row)
        {
            KNet.Model.Knet_Sampling_OpenBilling model = new KNet.Model.Knet_Sampling_OpenBilling();
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
             
             
                if (row["YID"] != null)
                {
                    model.YID = row["YID"].ToString();
                }
                else
                {
                    model.YID = "";
                }
               
                if (row["ReID"] != null)
                {
                    model.ReID = row["ReID"].ToString();
                }
                else
                {
                    model.ReID = "";
                }
              
                if (row["SamplingName"] != null)
                {
                    model.SamplingName = row["SamplingName"].ToString();
                }
                else
                {
                    model.SamplingName = "";
                }
                if (row["Number"] != null)
                {
                    model.Number = int.Parse(row["Number"].ToString());
                }
                else
                {
                    model.Number = 0;
                }
              
                if (row["Department"] != null)
                {
                    model.Department = row["Department"].ToString();
                }
                else
                {
                    model.Department = "";
                }
                if (row["Price"] != null)
                {
                    model.Price = Decimal.Parse(row["Price"].ToString());
                }
                else
                {
                    model.Price = 0;
                }
               
                if (row["Supplier"] != null)
                {
                    model.Supplier = row["Supplier"].ToString();
                }
                else
                {
                    model.Supplier = "";
                }
                if (row["HouseNo"] != null)
                {
                    model.HouseNo = row["HouseNo"].ToString();
                }
                else
                {
                    model.Supplier = "";
                }
                if (row["STime"] != null)
                {
                    model.STime = DateTime.Parse(row["STime"].ToString());
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
            strSql.Append(" FROM Knet_Sampling_OpenBilling ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

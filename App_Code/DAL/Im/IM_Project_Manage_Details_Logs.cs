 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class IM_Project_Manage_Details_Logs
   {
   public IM_Project_Manage_Details_Logs()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string IPML_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from IM_Project_Manage_Details_Logs");
strSql.Append(" where IPML_ID=@IPML_ID ");
SqlParameter[] parameters = {
new SqlParameter("@IPML_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = IPML_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.IM_Project_Manage_Details_Logs model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into IM_Project_Manage_Details_Logs(");
strSql.Append("IPML_ID,IPML_FID,IPML_ThisUseDays,IPML_Precent,IPML_Details,IPML_OldDetails,IPML_Del,IPML_Creator,IPML_CTime,IPML_Mender,IPML_MTime ");
strSql.Append(") values (");
strSql.Append("@IPML_ID,@IPML_FID,@IPML_ThisUseDays,@IPML_Precent,@IPML_Details,@IPML_OldDetails,@IPML_Del,@IPML_Creator,@IPML_CTime,@IPML_Mender,@IPML_MTime)");
SqlParameter[] parameters = {
 new SqlParameter("@IPML_ID", SqlDbType.VarChar,50),
 new SqlParameter("@IPML_FID", SqlDbType.VarChar,50),
 new SqlParameter("@IPML_ThisUseDays", SqlDbType.Int,4),
 new SqlParameter("@IPML_Precent", SqlDbType.Int,4),
 new SqlParameter("@IPML_Details", SqlDbType.VarChar,16),
 new SqlParameter("@IPML_OldDetails", SqlDbType.VarChar,300),
 new SqlParameter("@IPML_Del", SqlDbType.Int,4),
 new SqlParameter("@IPML_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@IPML_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@IPML_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@IPML_MTime", SqlDbType.DateTime,8)};
parameters[0].Value = model.IPML_ID;
parameters[1].Value = model.IPML_FID;
parameters[2].Value = model.IPML_ThisUseDays;
parameters[3].Value = model.IPML_Precent;
parameters[4].Value = model.IPML_Details;
parameters[5].Value = model.IPML_OldDetails;
parameters[6].Value = model.IPML_Del;
parameters[7].Value = model.IPML_Creator;
parameters[8].Value = model.IPML_CTime;
parameters[9].Value = model.IPML_Mender;
parameters[10].Value = model.IPML_MTime;
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
public bool Update(KNet.Model.IM_Project_Manage_Details_Logs model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update IM_Project_Manage_Details_Logs set ");
strSql.Append("IPML_FID=@IPML_FID,");
strSql.Append("IPML_ThisUseDays=@IPML_ThisUseDays,");
strSql.Append("IPML_Precent=@IPML_Precent,");
strSql.Append("IPML_Details=@IPML_Details,");
strSql.Append("IPML_OldDetails=@IPML_OldDetails,");
strSql.Append("IPML_Del=@IPML_Del,");
strSql.Append("IPML_Mender=@IPML_Mender,");
strSql.Append("IPML_MTime=@IPML_MTime");
strSql.Append(" where IPML_ID=@IPML_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@IPML_FID", SqlDbType.VarChar,50),
 new SqlParameter("@IPML_ThisUseDays", SqlDbType.Int,4),
 new SqlParameter("@IPML_Precent", SqlDbType.Int,4),
 new SqlParameter("@IPML_Details", SqlDbType.VarChar,16),
 new SqlParameter("@IPML_OldDetails", SqlDbType.VarChar,300),
 new SqlParameter("@IPML_Del", SqlDbType.Int,4),
 new SqlParameter("@IPML_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@IPML_MTime", SqlDbType.DateTime,8),
new SqlParameter("@IPML_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.IPML_FID;
parameters[1].Value = model.IPML_ThisUseDays;
parameters[2].Value = model.IPML_Precent;
parameters[3].Value = model.IPML_Details;
parameters[4].Value = model.IPML_OldDetails;
parameters[5].Value = model.IPML_Del;
parameters[6].Value = model.IPML_Mender;
parameters[7].Value = model.IPML_MTime;
parameters[8].Value = model.IPML_ID;

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
public bool Delete(string s_IPML_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  IM_Project_Manage_Details_Logs  ");
strSql.Append(" where IPML_ID=@IPML_ID ");
SqlParameter[] parameters = {
new SqlParameter("@IPML_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_IPML_ID;
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
public bool UpdateDel(KNet.Model.IM_Project_Manage_Details_Logs model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   IM_Project_Manage_Details_Logs  Set ");
strSql.Append("  IPML_Del=@IPML_Del ");
strSql.Append(" where IPML_ID=@IPML_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@IPML_Del", SqlDbType.Int,4),
new SqlParameter("@IPML_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.IPML_Del;
parameters[1].Value =  model.IPML_ID;

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
public bool DeleteList(string s_IPML_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   IM_Project_Manage_Details_Logs  ");
strSql.Append(" where IPML_ID in ('"+s_IPML_ID+"')");

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
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  IM_Project_Manage_Details_Logs  ");
strSql.Append(" Where  IPML_FID=@IPML_FID ");
SqlParameter[] parameters = {
 new SqlParameter("@IPML_FID", SqlDbType.VarChar,50),
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
public KNet.Model.IM_Project_Manage_Details_Logs GetModel(string IPML_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from IM_Project_Manage_Details_Logs  ");
strSql.Append("where IPML_ID=@IPML_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@IPML_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = IPML_ID;
 KNet.Model.IM_Project_Manage_Details_Logs model = new KNet.Model.IM_Project_Manage_Details_Logs();
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
public KNet.Model.IM_Project_Manage_Details_Logs DataRowToModel(DataRow row)
{
KNet.Model.IM_Project_Manage_Details_Logs model=new KNet.Model.IM_Project_Manage_Details_Logs();
if (row != null)
{
 if (row["IPML_ID"] != null)
{
 model.IPML_ID = row["IPML_ID"].ToString();
}
 else
{
 model.IPML_ID = "";
}
 if (row["IPML_FID"] != null)
{
 model.IPML_FID = row["IPML_FID"].ToString();
}
 else
{
 model.IPML_FID = "";
}
 if (row["IPML_ThisUseDays"] != null)
{
 model.IPML_ThisUseDays = int.Parse(row["IPML_ThisUseDays"].ToString());
}
 else
{
 model.IPML_ThisUseDays = 0;
}
 if (row["IPML_Precent"] != null)
{
 model.IPML_Precent = int.Parse(row["IPML_Precent"].ToString());
}
 else
{
 model.IPML_Precent = 0;
}
 if (row["IPML_Details"] != null)
{
 model.IPML_Details = row["IPML_Details"].ToString();
}
 else
{
 model.IPML_Details = "";
}
 if (row["IPML_OldDetails"] != null)
{
 model.IPML_OldDetails = row["IPML_OldDetails"].ToString();
}
 else
{
 model.IPML_OldDetails = "";
}
 if (row["IPML_Del"] != null)
{
 model.IPML_Del = int.Parse(row["IPML_Del"].ToString());
}
 else
{
 model.IPML_Del = 0;
}
 if (row["IPML_Creator"] != null)
{
 model.IPML_Creator = row["IPML_Creator"].ToString();
}
 else
{
 model.IPML_Creator = "";
}
 if (row["IPML_CTime"] != null)
{
 model.IPML_CTime = DateTime.Parse(row["IPML_CTime"].ToString());
}
 if (row["IPML_Mender"] != null)
{
 model.IPML_Mender = row["IPML_Mender"].ToString();
}
 else
{
 model.IPML_Mender = "";
}
 if (row["IPML_MTime"] != null)
{
 model.IPML_MTime = DateTime.Parse(row["IPML_MTime"].ToString());
}
}
return model;
}
/// <summary>
/// 获得数据列表
/// </summary>
public DataSet GetList(string strWhere)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select * ");
strSql.Append(" FROM IM_Project_Manage_Details_Logs ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

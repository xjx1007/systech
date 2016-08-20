 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class OA_Person_Report
   {
   public OA_Person_Report()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string OPR_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from OA_Person_Report");
strSql.Append(" where OPR_ID=@OPR_ID ");
SqlParameter[] parameters = {
new SqlParameter("@OPR_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = OPR_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.OA_Person_Report model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into OA_Person_Report(");
strSql.Append("OPR_ID,OPR_Code,OPR_STime,OPR_DutyPerson,OPR_ThisReport,OPR_NextReport,OPR_SubmitTime,OPR_Type,OPR_State,OPR_CTime,OPR_Creator,OPR_MTime,OPR_Mender,OPR_Del ");
strSql.Append(") values (");
strSql.Append("@OPR_ID,@OPR_Code,@OPR_STime,@OPR_DutyPerson,@OPR_ThisReport,@OPR_NextReport,@OPR_SubmitTime,@OPR_Type,@OPR_State,@OPR_CTime,@OPR_Creator,@OPR_MTime,@OPR_Mender,@OPR_Del)");
SqlParameter[] parameters = {
 new SqlParameter("@OPR_ID", SqlDbType.VarChar,50),
 new SqlParameter("@OPR_Code", SqlDbType.VarChar,50),
 new SqlParameter("@OPR_STime", SqlDbType.DateTime,8),
 new SqlParameter("@OPR_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@OPR_ThisReport", SqlDbType.Text),
 new SqlParameter("@OPR_NextReport", SqlDbType.Text),
 new SqlParameter("@OPR_SubmitTime", SqlDbType.DateTime,8),
 new SqlParameter("@OPR_Type", SqlDbType.Int,4),
 new SqlParameter("@OPR_State", SqlDbType.Int,4),
 new SqlParameter("@OPR_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@OPR_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@OPR_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@OPR_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@OPR_Del", SqlDbType.Int,4)};
parameters[0].Value = model.OPR_ID;
parameters[1].Value = model.OPR_Code;
parameters[2].Value = model.OPR_STime;
parameters[3].Value = model.OPR_DutyPerson;
parameters[4].Value = model.OPR_ThisReport;
parameters[5].Value = model.OPR_NextReport;
parameters[6].Value = model.OPR_SubmitTime;
parameters[7].Value = model.OPR_Type;
parameters[8].Value = model.OPR_State;
parameters[9].Value = model.OPR_CTime;
parameters[10].Value = model.OPR_Creator;
parameters[11].Value = model.OPR_MTime;
parameters[12].Value = model.OPR_Mender;
parameters[13].Value = model.OPR_Del;
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
public bool Update(KNet.Model.OA_Person_Report model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update OA_Person_Report set ");
strSql.Append("OPR_Code=@OPR_Code,");
strSql.Append("OPR_STime=@OPR_STime,");
strSql.Append("OPR_DutyPerson=@OPR_DutyPerson,");
strSql.Append("OPR_ThisReport=@OPR_ThisReport,");
strSql.Append("OPR_NextReport=@OPR_NextReport,");
strSql.Append("OPR_SubmitTime=@OPR_SubmitTime,");
strSql.Append("OPR_Type=@OPR_Type,");
strSql.Append("OPR_State=@OPR_State,");
strSql.Append("OPR_MTime=@OPR_MTime,");
strSql.Append("OPR_Mender=@OPR_Mender,");
strSql.Append("OPR_Del=@OPR_Del");
strSql.Append(" where OPR_ID=@OPR_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@OPR_Code", SqlDbType.VarChar,50),
 new SqlParameter("@OPR_STime", SqlDbType.DateTime,8),
 new SqlParameter("@OPR_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@OPR_ThisReport", SqlDbType.Text),
 new SqlParameter("@OPR_NextReport", SqlDbType.Text),
 new SqlParameter("@OPR_SubmitTime", SqlDbType.DateTime,8),
 new SqlParameter("@OPR_Type", SqlDbType.Int,4),
 new SqlParameter("@OPR_State", SqlDbType.Int,4),
 new SqlParameter("@OPR_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@OPR_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@OPR_Del", SqlDbType.Int,4),
new SqlParameter("@OPR_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.OPR_Code;
parameters[1].Value = model.OPR_STime;
parameters[2].Value = model.OPR_DutyPerson;
parameters[3].Value = model.OPR_ThisReport;
parameters[4].Value = model.OPR_NextReport;
parameters[5].Value = model.OPR_SubmitTime;
parameters[6].Value = model.OPR_Type;
parameters[7].Value = model.OPR_State;
parameters[8].Value = model.OPR_MTime;
parameters[9].Value = model.OPR_Mender;
parameters[10].Value = model.OPR_Del;
parameters[11].Value = model.OPR_ID;

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
public bool Delete(string s_OPR_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  OA_Person_Report  ");
strSql.Append(" where OPR_ID=@OPR_ID ");
SqlParameter[] parameters = {
new SqlParameter("@OPR_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_OPR_ID;
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
public bool UpdateDel(KNet.Model.OA_Person_Report model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   OA_Person_Report  Set ");
strSql.Append("  OPR_Del=@OPR_Del ");
strSql.Append(" where OPR_ID=@OPR_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@OPR_Del", SqlDbType.Int,4),
new SqlParameter("@OPR_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.OPR_Del;
parameters[1].Value =  model.OPR_ID;

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
public bool DeleteList(string s_OPR_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   OA_Person_Report  ");
strSql.Append(" where OPR_ID in ('"+s_OPR_ID+"')");

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
  /// 得到数据
 /// </summary>
public KNet.Model.OA_Person_Report GetModel(string OPR_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from OA_Person_Report  ");
strSql.Append("where OPR_ID=@OPR_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@OPR_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = OPR_ID;
 KNet.Model.OA_Person_Report model = new KNet.Model.OA_Person_Report();
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
public KNet.Model.OA_Person_Report DataRowToModel(DataRow row)
{
KNet.Model.OA_Person_Report model=new KNet.Model.OA_Person_Report();
if (row != null)
{
 if (row["OPR_ID"] != null)
{
 model.OPR_ID = row["OPR_ID"].ToString();
}
 else
{
 model.OPR_ID = "";
}
 if (row["OPR_Code"] != null)
{
 model.OPR_Code = row["OPR_Code"].ToString();
}
 else
{
 model.OPR_Code = "";
}
 if (row["OPR_STime"] != null)
{
 model.OPR_STime = DateTime.Parse(row["OPR_STime"].ToString());
}
 if (row["OPR_DutyPerson"] != null)
{
 model.OPR_DutyPerson = row["OPR_DutyPerson"].ToString();
}
 else
{
 model.OPR_DutyPerson = "";
}
 if (row["OPR_ThisReport"] != null)
{
 model.OPR_ThisReport = row["OPR_ThisReport"].ToString();
}
 else
{
 model.OPR_ThisReport = "";
}
 if (row["OPR_NextReport"] != null)
{
 model.OPR_NextReport = row["OPR_NextReport"].ToString();
}
 else
{
 model.OPR_NextReport = "";
}
 if (row["OPR_SubmitTime"] != null)
{
 model.OPR_SubmitTime = DateTime.Parse(row["OPR_SubmitTime"].ToString());
}
 if (row["OPR_Type"] != null)
{
 model.OPR_Type = int.Parse(row["OPR_Type"].ToString());
}
 else
{
 model.OPR_Type = 0;
}
 if (row["OPR_State"] != null)
{
 model.OPR_State = int.Parse(row["OPR_State"].ToString());
}
 else
{
 model.OPR_State = 0;
}
 if (row["OPR_CTime"] != null)
{
 model.OPR_CTime = DateTime.Parse(row["OPR_CTime"].ToString());
}
 if (row["OPR_Creator"] != null)
{
 model.OPR_Creator = row["OPR_Creator"].ToString();
}
 else
{
 model.OPR_Creator = "";
}
 if (row["OPR_MTime"] != null)
{
 model.OPR_MTime = DateTime.Parse(row["OPR_MTime"].ToString());
}
 if (row["OPR_Mender"] != null)
{
 model.OPR_Mender = row["OPR_Mender"].ToString();
}
 else
{
 model.OPR_Mender = "";
}
 if (row["OPR_Del"] != null)
{
 model.OPR_Del = int.Parse(row["OPR_Del"].ToString());
}
 else
{
 model.OPR_Del = 0;
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
strSql.Append(" FROM OA_Person_Report ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

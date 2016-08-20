 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class PB_Mail_Setting
   {
   public PB_Mail_Setting()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string PMS_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from PB_Mail_Setting");
strSql.Append(" where PMS_ID=@PMS_ID ");
SqlParameter[] parameters = {
new SqlParameter("@PMS_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = PMS_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.PB_Mail_Setting model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into PB_Mail_Setting(");
strSql.Append("PMS_ID,PMS_Sever,PMS_Port,PMS_Email,PMS_Password,PMS_Verification,PMS_SendEmail,PMS_SendPerson,PMS_Seconds,PMS_Del,PMS_Creator,PMS_CTime,PMS_Mender,PMS_MTime ");
strSql.Append(") values (");
strSql.Append("@PMS_ID,@PMS_Sever,@PMS_Port,@PMS_Email,@PMS_Password,@PMS_Verification,@PMS_SendEmail,@PMS_SendPerson,@PMS_Seconds,@PMS_Del,@PMS_Creator,@PMS_CTime,@PMS_Mender,@PMS_MTime)");
SqlParameter[] parameters = {
 new SqlParameter("@PMS_ID", SqlDbType.VarChar,50),
 new SqlParameter("@PMS_Sever", SqlDbType.VarChar,350),
 new SqlParameter("@PMS_Port", SqlDbType.VarChar,150),
 new SqlParameter("@PMS_Email", SqlDbType.VarChar,250),
 new SqlParameter("@PMS_Password", SqlDbType.VarChar,350),
 new SqlParameter("@PMS_Verification", SqlDbType.Int,4),
 new SqlParameter("@PMS_SendEmail", SqlDbType.VarChar,250),
 new SqlParameter("@PMS_SendPerson", SqlDbType.VarChar,250),
 new SqlParameter("@PMS_Seconds", SqlDbType.Int,4),
 new SqlParameter("@PMS_Del", SqlDbType.Int,4),
 new SqlParameter("@PMS_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@PMS_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@PMS_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@PMS_MTime", SqlDbType.DateTime,8)};
parameters[0].Value = model.PMS_ID;
parameters[1].Value = model.PMS_Sever;
parameters[2].Value = model.PMS_Port;
parameters[3].Value = model.PMS_Email;
parameters[4].Value = model.PMS_Password;
parameters[5].Value = model.PMS_Verification;
parameters[6].Value = model.PMS_SendEmail;
parameters[7].Value = model.PMS_SendPerson;
parameters[8].Value = model.PMS_Seconds;
parameters[9].Value = model.PMS_Del;
parameters[10].Value = model.PMS_Creator;
parameters[11].Value = model.PMS_CTime;
parameters[12].Value = model.PMS_Mender;
parameters[13].Value = model.PMS_MTime;
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
public bool Update(KNet.Model.PB_Mail_Setting model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update PB_Mail_Setting set ");
strSql.Append("PMS_Sever=@PMS_Sever,");
strSql.Append("PMS_Port=@PMS_Port,");
strSql.Append("PMS_Email=@PMS_Email,");
strSql.Append("PMS_Password=@PMS_Password,");
strSql.Append("PMS_Verification=@PMS_Verification,");
strSql.Append("PMS_SendEmail=@PMS_SendEmail,");
strSql.Append("PMS_SendPerson=@PMS_SendPerson,");
strSql.Append("PMS_Seconds=@PMS_Seconds,");
strSql.Append("PMS_Del=@PMS_Del,");
strSql.Append("PMS_Mender=@PMS_Mender,");
strSql.Append("PMS_MTime=@PMS_MTime");
strSql.Append(" where PMS_ID=@PMS_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@PMS_Sever", SqlDbType.VarChar,350),
 new SqlParameter("@PMS_Port", SqlDbType.VarChar,150),
 new SqlParameter("@PMS_Email", SqlDbType.VarChar,250),
 new SqlParameter("@PMS_Password", SqlDbType.VarChar,350),
 new SqlParameter("@PMS_Verification", SqlDbType.Int,4),
 new SqlParameter("@PMS_SendEmail", SqlDbType.VarChar,250),
 new SqlParameter("@PMS_SendPerson", SqlDbType.VarChar,250),
 new SqlParameter("@PMS_Seconds", SqlDbType.Int,4),
 new SqlParameter("@PMS_Del", SqlDbType.Int,4),
 new SqlParameter("@PMS_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@PMS_MTime", SqlDbType.DateTime,8),
new SqlParameter("@PMS_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.PMS_Sever;
parameters[1].Value = model.PMS_Port;
parameters[2].Value = model.PMS_Email;
parameters[3].Value = model.PMS_Password;
parameters[4].Value = model.PMS_Verification;
parameters[5].Value = model.PMS_SendEmail;
parameters[6].Value = model.PMS_SendPerson;
parameters[7].Value = model.PMS_Seconds;
parameters[8].Value = model.PMS_Del;
parameters[9].Value = model.PMS_Mender;
parameters[10].Value = model.PMS_MTime;
parameters[11].Value = model.PMS_ID;

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
public bool Delete(string s_PMS_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  PB_Mail_Setting  ");
strSql.Append(" where PMS_ID=@PMS_ID ");
SqlParameter[] parameters = {
new SqlParameter("@PMS_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_PMS_ID;
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
public bool UpdateDel(KNet.Model.PB_Mail_Setting model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   PB_Mail_Setting  Set ");
strSql.Append("  PMS_Del=@PMS_Del ");
strSql.Append(" where PMS_ID=@PMS_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@PMS_Del", SqlDbType.Int,4),
new SqlParameter("@PMS_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.PMS_Del;
parameters[1].Value =  model.PMS_ID;

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
public bool DeleteList(string s_PMS_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   PB_Mail_Setting  ");
strSql.Append(" where PMS_ID in ('"+s_PMS_ID+"')");

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
public KNet.Model.PB_Mail_Setting GetModel(string PMS_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from PB_Mail_Setting  ");
strSql.Append("where PMS_ID=@PMS_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@PMS_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = PMS_ID;
 KNet.Model.PB_Mail_Setting model = new KNet.Model.PB_Mail_Setting();
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
public KNet.Model.PB_Mail_Setting DataRowToModel(DataRow row)
{
KNet.Model.PB_Mail_Setting model=new KNet.Model.PB_Mail_Setting();
if (row != null)
{
 if (row["PMS_ID"] != null)
{
 model.PMS_ID = row["PMS_ID"].ToString();
}
 else
{
 model.PMS_ID = "";
}
 if (row["PMS_Sever"] != null)
{
 model.PMS_Sever = row["PMS_Sever"].ToString();
}
 else
{
 model.PMS_Sever = "";
}
 if (row["PMS_Port"] != null)
{
 model.PMS_Port = row["PMS_Port"].ToString();
}
 else
{
 model.PMS_Port = "";
}
 if (row["PMS_Email"] != null)
{
 model.PMS_Email = row["PMS_Email"].ToString();
}
 else
{
 model.PMS_Email = "";
}
 if (row["PMS_Password"] != null)
{
 model.PMS_Password = row["PMS_Password"].ToString();
}
 else
{
 model.PMS_Password = "";
}
 if (row["PMS_Verification"] != null)
{
 model.PMS_Verification = int.Parse(row["PMS_Verification"].ToString());
}
 else
{
 model.PMS_Verification = 0;
}
 if (row["PMS_SendEmail"] != null)
{
 model.PMS_SendEmail = row["PMS_SendEmail"].ToString();
}
 else
{
 model.PMS_SendEmail = "";
}
 if (row["PMS_SendPerson"] != null)
{
 model.PMS_SendPerson = row["PMS_SendPerson"].ToString();
}
 else
{
 model.PMS_SendPerson = "";
}
 if (row["PMS_Seconds"] != null)
{
 model.PMS_Seconds = int.Parse(row["PMS_Seconds"].ToString());
}
 else
{
 model.PMS_Seconds = 0;
}
 if (row["PMS_Del"] != null)
{
 model.PMS_Del = int.Parse(row["PMS_Del"].ToString());
}
 else
{
 model.PMS_Del = 0;
}
 if (row["PMS_Creator"] != null)
{
 model.PMS_Creator = row["PMS_Creator"].ToString();
}
 else
{
 model.PMS_Creator = "";
}
 if (row["PMS_CTime"] != null)
{
 model.PMS_CTime = DateTime.Parse(row["PMS_CTime"].ToString());
}
 if (row["PMS_Mender"] != null)
{
 model.PMS_Mender = row["PMS_Mender"].ToString();
}
 else
{
 model.PMS_Mender = "";
}
 if (row["PMS_MTime"] != null)
{
 model.PMS_MTime = DateTime.Parse(row["PMS_MTime"].ToString());
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
strSql.Append(" FROM PB_Mail_Setting ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

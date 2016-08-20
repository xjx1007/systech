 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class Cw_Bill_Expense
   {
   public Cw_Bill_Expense()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string CBE_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from Cw_Bill_Expense");
strSql.Append(" where CBE_ID=@CBE_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CBE_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = CBE_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.Cw_Bill_Expense model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into Cw_Bill_Expense(");
strSql.Append("CBE_ID,CBE_Code,CBE_CustomerValue,CBE_LinkMan,CBE_OPPID,CBE_State,CBE_Content,CBE_Stime,CBE_DutyPerson,CBE_Remarks,CBE_CTime,CBE_Creator,CBE_MTime,CBE_Mender,CBE_Del ");
strSql.Append(") values (");
strSql.Append("@CBE_ID,@CBE_Code,@CBE_CustomerValue,@CBE_LinkMan,@CBE_OPPID,@CBE_State,@CBE_Content,@CBE_Stime,@CBE_DutyPerson,@CBE_Remarks,@CBE_CTime,@CBE_Creator,@CBE_MTime,@CBE_Mender,@CBE_Del)");
SqlParameter[] parameters = {
 new SqlParameter("@CBE_ID", SqlDbType.VarChar,50),
 new SqlParameter("@CBE_Code", SqlDbType.VarChar,50),
 new SqlParameter("@CBE_CustomerValue", SqlDbType.VarChar,50),
 new SqlParameter("@CBE_LinkMan", SqlDbType.VarChar,50),
 new SqlParameter("@CBE_OPPID", SqlDbType.VarChar,50),
 new SqlParameter("@CBE_State", SqlDbType.Int,4),
 new SqlParameter("@CBE_Content", SqlDbType.VarChar,50),
 new SqlParameter("@CBE_Stime", SqlDbType.DateTime,8),
 new SqlParameter("@CBE_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@CBE_Remarks", SqlDbType.VarChar,300),
 new SqlParameter("@CBE_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@CBE_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@CBE_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@CBE_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@CBE_Del", SqlDbType.Int,4)};
parameters[0].Value = model.CBE_ID;
parameters[1].Value = model.CBE_Code;
parameters[2].Value = model.CBE_CustomerValue;
parameters[3].Value = model.CBE_LinkMan;
parameters[4].Value = model.CBE_OPPID;
parameters[5].Value = model.CBE_State;
parameters[6].Value = model.CBE_Content;
parameters[7].Value = model.CBE_Stime;
parameters[8].Value = model.CBE_DutyPerson;
parameters[9].Value = model.CBE_Remarks;
parameters[10].Value = model.CBE_CTime;
parameters[11].Value = model.CBE_Creator;
parameters[12].Value = model.CBE_MTime;
parameters[13].Value = model.CBE_Mender;
parameters[14].Value = model.CBE_Del;
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
public bool Update(KNet.Model.Cw_Bill_Expense model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update Cw_Bill_Expense set ");
strSql.Append("CBE_Code=@CBE_Code,");
strSql.Append("CBE_CustomerValue=@CBE_CustomerValue,");
strSql.Append("CBE_LinkMan=@CBE_LinkMan,");
strSql.Append("CBE_OPPID=@CBE_OPPID,");
strSql.Append("CBE_State=@CBE_State,");
strSql.Append("CBE_Content=@CBE_Content,");
strSql.Append("CBE_Stime=@CBE_Stime,");
strSql.Append("CBE_DutyPerson=@CBE_DutyPerson,");
strSql.Append("CBE_Remarks=@CBE_Remarks,");
strSql.Append("CBE_MTime=@CBE_MTime,");
strSql.Append("CBE_Mender=@CBE_Mender,");
strSql.Append("CBE_Del=@CBE_Del");
strSql.Append(" where CBE_ID=@CBE_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@CBE_Code", SqlDbType.VarChar,50),
 new SqlParameter("@CBE_CustomerValue", SqlDbType.VarChar,50),
 new SqlParameter("@CBE_LinkMan", SqlDbType.VarChar,50),
 new SqlParameter("@CBE_OPPID", SqlDbType.VarChar,50),
 new SqlParameter("@CBE_State", SqlDbType.Int,4),
 new SqlParameter("@CBE_Content", SqlDbType.VarChar,50),
 new SqlParameter("@CBE_Stime", SqlDbType.DateTime,8),
 new SqlParameter("@CBE_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@CBE_Remarks", SqlDbType.VarChar,300),
 new SqlParameter("@CBE_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@CBE_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@CBE_Del", SqlDbType.Int,4),
new SqlParameter("@CBE_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.CBE_Code;
parameters[1].Value = model.CBE_CustomerValue;
parameters[2].Value = model.CBE_LinkMan;
parameters[3].Value = model.CBE_OPPID;
parameters[4].Value = model.CBE_State;
parameters[5].Value = model.CBE_Content;
parameters[6].Value = model.CBE_Stime;
parameters[7].Value = model.CBE_DutyPerson;
parameters[8].Value = model.CBE_Remarks;
parameters[9].Value = model.CBE_MTime;
parameters[10].Value = model.CBE_Mender;
parameters[11].Value = model.CBE_Del;
parameters[12].Value = model.CBE_ID;

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
public bool Delete(string s_CBE_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  Cw_Bill_Expense  ");
strSql.Append(" where CBE_ID=@CBE_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CBE_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_CBE_ID;
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
public bool UpdateDel(KNet.Model.Cw_Bill_Expense model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   Cw_Bill_Expense  Set ");
strSql.Append("  CBE_Del=@CBE_Del ");
strSql.Append(" where CBE_ID=@CBE_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@CBE_Del", SqlDbType.Int,4),
new SqlParameter("@CBE_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.CBE_Del;
parameters[1].Value =  model.CBE_ID;

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
public bool DeleteList(string s_CBE_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   Cw_Bill_Expense  ");
strSql.Append(" where CBE_ID in ('"+s_CBE_ID+"')");

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
public KNet.Model.Cw_Bill_Expense GetModel(string CBE_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from Cw_Bill_Expense  ");
strSql.Append("where CBE_ID=@CBE_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@CBE_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = CBE_ID;
 KNet.Model.Cw_Bill_Expense model = new KNet.Model.Cw_Bill_Expense();
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
public KNet.Model.Cw_Bill_Expense DataRowToModel(DataRow row)
{
KNet.Model.Cw_Bill_Expense model=new KNet.Model.Cw_Bill_Expense();
if (row != null)
{
 if (row["CBE_ID"] != null)
{
 model.CBE_ID = row["CBE_ID"].ToString();
}
 else
{
 model.CBE_ID = "";
}
 if (row["CBE_Code"] != null)
{
 model.CBE_Code = row["CBE_Code"].ToString();
}
 else
{
 model.CBE_Code = "";
}
 if (row["CBE_CustomerValue"] != null)
{
 model.CBE_CustomerValue = row["CBE_CustomerValue"].ToString();
}
 else
{
 model.CBE_CustomerValue = "";
}
 if (row["CBE_LinkMan"] != null)
{
 model.CBE_LinkMan = row["CBE_LinkMan"].ToString();
}
 else
{
 model.CBE_LinkMan = "";
}
 if (row["CBE_OPPID"] != null)
{
 model.CBE_OPPID = row["CBE_OPPID"].ToString();
}
 else
{
 model.CBE_OPPID = "";
}
 if (row["CBE_State"] != null)
{
 model.CBE_State = int.Parse(row["CBE_State"].ToString());
}
 else
{
 model.CBE_State = 0;
}
 if (row["CBE_Content"] != null)
{
 model.CBE_Content = row["CBE_Content"].ToString();
}
 else
{
 model.CBE_Content = "";
}
 if (row["CBE_Stime"] != null)
{
 model.CBE_Stime = DateTime.Parse(row["CBE_Stime"].ToString());
}
 if (row["CBE_DutyPerson"] != null)
{
 model.CBE_DutyPerson = row["CBE_DutyPerson"].ToString();
}
 else
{
 model.CBE_DutyPerson = "";
}
 if (row["CBE_Remarks"] != null)
{
 model.CBE_Remarks = row["CBE_Remarks"].ToString();
}
 else
{
 model.CBE_Remarks = "";
}
 if (row["CBE_CTime"] != null)
{
 model.CBE_CTime = DateTime.Parse(row["CBE_CTime"].ToString());
}
 if (row["CBE_Creator"] != null)
{
 model.CBE_Creator = row["CBE_Creator"].ToString();
}
 else
{
 model.CBE_Creator = "";
}
 if (row["CBE_MTime"] != null)
{
 model.CBE_MTime = DateTime.Parse(row["CBE_MTime"].ToString());
}
 if (row["CBE_Mender"] != null)
{
 model.CBE_Mender = row["CBE_Mender"].ToString();
}
 else
{
 model.CBE_Mender = "";
}
 if (row["CBE_Del"] != null)
{
 model.CBE_Del = int.Parse(row["CBE_Del"].ToString());
}
 else
{
 model.CBE_Del = 0;
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
strSql.Append(" FROM Cw_Bill_Expense ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

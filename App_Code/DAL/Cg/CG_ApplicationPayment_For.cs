 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class CG_ApplicationPayment_For
   {
   public CG_ApplicationPayment_For()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string CAF_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from CG_ApplicationPayment_For");
strSql.Append(" where CAF_ID=@CAF_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CAF_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = CAF_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.CG_ApplicationPayment_For model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into CG_ApplicationPayment_For(");
strSql.Append("CAF_ID,CAF_Code,CAF_Title,CAF_STime,CAF_DutyPerson,CAF_TotalMoney,CAF_State,CAF_Remarks,CAF_Del,CAF_Creator,CAF_CTime,CAF_Mender,CAF_MTime ");
strSql.Append(") values (");
strSql.Append("@CAF_ID,@CAF_Code,@CAF_Title,@CAF_STime,@CAF_DutyPerson,@CAF_TotalMoney,@CAF_State,@CAF_Remarks,@CAF_Del,@CAF_Creator,@CAF_CTime,@CAF_Mender,@CAF_MTime)");
SqlParameter[] parameters = {
 new SqlParameter("@CAF_ID", SqlDbType.VarChar,50),
 new SqlParameter("@CAF_Code", SqlDbType.VarChar,50),
 new SqlParameter("@CAF_Title", SqlDbType.VarChar,500),
 new SqlParameter("@CAF_STime", SqlDbType.DateTime,8),
 new SqlParameter("@CAF_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@CAF_TotalMoney", SqlDbType.Decimal,9),
 new SqlParameter("@CAF_State", SqlDbType.Int,4),
 new SqlParameter("@CAF_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@CAF_Del", SqlDbType.Int,4),
 new SqlParameter("@CAF_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@CAF_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@CAF_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@CAF_MTime", SqlDbType.DateTime,8)};
parameters[0].Value = model.CAF_ID;
parameters[1].Value = model.CAF_Code;
parameters[2].Value = model.CAF_Title;
parameters[3].Value = model.CAF_STime;
parameters[4].Value = model.CAF_DutyPerson;
parameters[5].Value = model.CAF_TotalMoney;
parameters[6].Value = model.CAF_State;
parameters[7].Value = model.CAF_Remarks;
parameters[8].Value = model.CAF_Del;
parameters[9].Value = model.CAF_Creator;
parameters[10].Value = model.CAF_CTime;
parameters[11].Value = model.CAF_Mender;
parameters[12].Value = model.CAF_MTime;
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
public bool Update(KNet.Model.CG_ApplicationPayment_For model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update CG_ApplicationPayment_For set ");
strSql.Append("CAF_Code=@CAF_Code,");
strSql.Append("CAF_Title=@CAF_Title,");
strSql.Append("CAF_STime=@CAF_STime,");
strSql.Append("CAF_DutyPerson=@CAF_DutyPerson,");
strSql.Append("CAF_TotalMoney=@CAF_TotalMoney,");
strSql.Append("CAF_State=@CAF_State,");
strSql.Append("CAF_Remarks=@CAF_Remarks,");
strSql.Append("CAF_Del=@CAF_Del,");
strSql.Append("CAF_Mender=@CAF_Mender,");
strSql.Append("CAF_MTime=@CAF_MTime");
strSql.Append(" where CAF_ID=@CAF_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@CAF_Code", SqlDbType.VarChar,50),
 new SqlParameter("@CAF_Title", SqlDbType.VarChar,500),
 new SqlParameter("@CAF_STime", SqlDbType.DateTime,8),
 new SqlParameter("@CAF_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@CAF_TotalMoney", SqlDbType.Decimal,9),
 new SqlParameter("@CAF_State", SqlDbType.Int,4),
 new SqlParameter("@CAF_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@CAF_Del", SqlDbType.Int,4),
 new SqlParameter("@CAF_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@CAF_MTime", SqlDbType.DateTime,8),
new SqlParameter("@CAF_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.CAF_Code;
parameters[1].Value = model.CAF_Title;
parameters[2].Value = model.CAF_STime;
parameters[3].Value = model.CAF_DutyPerson;
parameters[4].Value = model.CAF_TotalMoney;
parameters[5].Value = model.CAF_State;
parameters[6].Value = model.CAF_Remarks;
parameters[7].Value = model.CAF_Del;
parameters[8].Value = model.CAF_Mender;
parameters[9].Value = model.CAF_MTime;
parameters[10].Value = model.CAF_ID;

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
public bool Delete(string s_CAF_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  CG_ApplicationPayment_For  ");
strSql.Append(" where CAF_ID=@CAF_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CAF_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_CAF_ID;
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
public bool UpdateDel(KNet.Model.CG_ApplicationPayment_For model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   CG_ApplicationPayment_For  Set ");
strSql.Append("  CAF_Del=@CAF_Del ");
strSql.Append(" where CAF_ID=@CAF_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@CAF_Del", SqlDbType.Int,4),
new SqlParameter("@CAF_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.CAF_Del;
parameters[1].Value =  model.CAF_ID;

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
public bool DeleteList(string s_CAF_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   CG_ApplicationPayment_For  ");
strSql.Append(" where CAF_ID in ('"+s_CAF_ID+"')");

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
strSql.Append("delete from  CG_ApplicationPayment_For  ");
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
public KNet.Model.CG_ApplicationPayment_For GetModel(string CAF_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from CG_ApplicationPayment_For  ");
strSql.Append("where CAF_ID=@CAF_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@CAF_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = CAF_ID;
 KNet.Model.CG_ApplicationPayment_For model = new KNet.Model.CG_ApplicationPayment_For();
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
public KNet.Model.CG_ApplicationPayment_For DataRowToModel(DataRow row)
{
KNet.Model.CG_ApplicationPayment_For model=new KNet.Model.CG_ApplicationPayment_For();
if (row != null)
{
 if (row["CAF_ID"] != null)
{
 model.CAF_ID = row["CAF_ID"].ToString();
}
 else
{
 model.CAF_ID = "";
}
 if (row["CAF_Code"] != null)
{
 model.CAF_Code = row["CAF_Code"].ToString();
}
 else
{
 model.CAF_Code = "";
}
 if (row["CAF_Title"] != null)
{
 model.CAF_Title = row["CAF_Title"].ToString();
}
 else
{
 model.CAF_Title = "";
}
 if (row["CAF_STime"] != null)
{
 model.CAF_STime = DateTime.Parse(row["CAF_STime"].ToString());
}
 if (row["CAF_DutyPerson"] != null)
{
 model.CAF_DutyPerson = row["CAF_DutyPerson"].ToString();
}
 else
{
 model.CAF_DutyPerson = "";
}
 if (row["CAF_TotalMoney"] != null)
{
 model.CAF_TotalMoney = Decimal.Parse(row["CAF_TotalMoney"].ToString());
}
 else
{
 model.CAF_TotalMoney = 0;
}
 if (row["CAF_State"] != null)
{
 model.CAF_State = int.Parse(row["CAF_State"].ToString());
}
 else
{
 model.CAF_State = 0;
}
 if (row["CAF_Remarks"] != null)
{
 model.CAF_Remarks = row["CAF_Remarks"].ToString();
}
 else
{
 model.CAF_Remarks = "";
}
 if (row["CAF_Del"] != null)
{
 model.CAF_Del = int.Parse(row["CAF_Del"].ToString());
}
 else
{
 model.CAF_Del = 0;
}
 if (row["CAF_Creator"] != null)
{
 model.CAF_Creator = row["CAF_Creator"].ToString();
}
 else
{
 model.CAF_Creator = "";
}
 if (row["CAF_CTime"] != null)
{
 model.CAF_CTime = DateTime.Parse(row["CAF_CTime"].ToString());
}
 if (row["CAF_Mender"] != null)
{
 model.CAF_Mender = row["CAF_Mender"].ToString();
}
 else
{
 model.CAF_Mender = "";
}
 if (row["CAF_MTime"] != null)
{
 model.CAF_MTime = DateTime.Parse(row["CAF_MTime"].ToString());
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
strSql.Append(" FROM CG_ApplicationPayment_For ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

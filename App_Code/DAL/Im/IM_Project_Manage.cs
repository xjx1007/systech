 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class IM_Project_Manage
   {
   public IM_Project_Manage()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string IPM_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from IM_Project_Manage");
strSql.Append(" where IPM_ID=@IPM_ID ");
SqlParameter[] parameters = {
new SqlParameter("@IPM_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = IPM_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.IM_Project_Manage model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into IM_Project_Manage(");
strSql.Append("IPM_ID,IPM_Code,IPM_Name,IPM_DutyPerson,IPM_Import,IPM_Persons,IPM_Type,IPM_Class,IPM_STime,IPM_EndTime,IPM_Days,IPM_DaysType,IPM_State,IPM_CustomerValue,IPM_Money,IPM_IsDetailsMoney,IPM_Remarks,IPM_Creator,IPM_CTime,IPM_Del,IPM_Mender,IPM_MTime ");
strSql.Append(") values (");
strSql.Append("@IPM_ID,@IPM_Code,@IPM_Name,@IPM_DutyPerson,@IPM_Import,@IPM_Persons,@IPM_Type,@IPM_Class,@IPM_STime,@IPM_EndTime,@IPM_Days,@IPM_DaysType,@IPM_State,@IPM_CustomerValue,@IPM_Money,@IPM_IsDetailsMoney,@IPM_Remarks,@IPM_Creator,@IPM_CTime,@IPM_Del,@IPM_Mender,@IPM_MTime)");
SqlParameter[] parameters = {
 new SqlParameter("@IPM_ID", SqlDbType.VarChar,50),
 new SqlParameter("@IPM_Code", SqlDbType.VarChar,50),
 new SqlParameter("@IPM_Name", SqlDbType.VarChar,150),
 new SqlParameter("@IPM_DutyPerson", SqlDbType.VarChar,150),
 new SqlParameter("@IPM_Import", SqlDbType.VarChar,50),
 new SqlParameter("@IPM_Persons", SqlDbType.VarChar,500),
 new SqlParameter("@IPM_Type", SqlDbType.VarChar,50),
 new SqlParameter("@IPM_Class", SqlDbType.VarChar,50),
 new SqlParameter("@IPM_STime", SqlDbType.DateTime,8),
 new SqlParameter("@IPM_EndTime", SqlDbType.DateTime,8),
 new SqlParameter("@IPM_Days", SqlDbType.Int,4),
 new SqlParameter("@IPM_DaysType", SqlDbType.VarChar,50),
 new SqlParameter("@IPM_State", SqlDbType.VarChar,50),
 new SqlParameter("@IPM_CustomerValue", SqlDbType.VarChar,50),
 new SqlParameter("@IPM_Money", SqlDbType.Decimal,9),
 new SqlParameter("@IPM_IsDetailsMoney", SqlDbType.Int,4),
 new SqlParameter("@IPM_Remarks", SqlDbType.VarChar,16),
 new SqlParameter("@IPM_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@IPM_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@IPM_Del", SqlDbType.Int,4),
 new SqlParameter("@IPM_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@IPM_MTime", SqlDbType.DateTime,8)};
parameters[0].Value = model.IPM_ID;
parameters[1].Value = model.IPM_Code;
parameters[2].Value = model.IPM_Name;
parameters[3].Value = model.IPM_DutyPerson;
parameters[4].Value = model.IPM_Import;
parameters[5].Value = model.IPM_Persons;
parameters[6].Value = model.IPM_Type;
parameters[7].Value = model.IPM_Class;
parameters[8].Value = model.IPM_STime;
parameters[9].Value = model.IPM_EndTime;
parameters[10].Value = model.IPM_Days;
parameters[11].Value = model.IPM_DaysType;
parameters[12].Value = model.IPM_State;
parameters[13].Value = model.IPM_CustomerValue;
parameters[14].Value = model.IPM_Money;
parameters[15].Value = model.IPM_IsDetailsMoney;
parameters[16].Value = model.IPM_Remarks;
parameters[17].Value = model.IPM_Creator;
parameters[18].Value = model.IPM_CTime;
parameters[19].Value = model.IPM_Del;
parameters[20].Value = model.IPM_Mender;
parameters[21].Value = model.IPM_MTime;
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
public bool Update(KNet.Model.IM_Project_Manage model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update IM_Project_Manage set ");
strSql.Append("IPM_Code=@IPM_Code,");
strSql.Append("IPM_Name=@IPM_Name,");
strSql.Append("IPM_DutyPerson=@IPM_DutyPerson,");
strSql.Append("IPM_Import=@IPM_Import,");
strSql.Append("IPM_Persons=@IPM_Persons,");
strSql.Append("IPM_Type=@IPM_Type,");
strSql.Append("IPM_Class=@IPM_Class,");
strSql.Append("IPM_STime=@IPM_STime,");
strSql.Append("IPM_EndTime=@IPM_EndTime,");
strSql.Append("IPM_Days=@IPM_Days,");
strSql.Append("IPM_DaysType=@IPM_DaysType,");
strSql.Append("IPM_State=@IPM_State,");
strSql.Append("IPM_CustomerValue=@IPM_CustomerValue,");
strSql.Append("IPM_Money=@IPM_Money,");
strSql.Append("IPM_IsDetailsMoney=@IPM_IsDetailsMoney,");
strSql.Append("IPM_Remarks=@IPM_Remarks,");
strSql.Append("IPM_Del=@IPM_Del,");
strSql.Append("IPM_Mender=@IPM_Mender,");
strSql.Append("IPM_MTime=@IPM_MTime");
strSql.Append(" where IPM_ID=@IPM_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@IPM_Code", SqlDbType.VarChar,50),
 new SqlParameter("@IPM_Name", SqlDbType.VarChar,150),
 new SqlParameter("@IPM_DutyPerson", SqlDbType.VarChar,150),
 new SqlParameter("@IPM_Import", SqlDbType.VarChar,50),
 new SqlParameter("@IPM_Persons", SqlDbType.VarChar,500),
 new SqlParameter("@IPM_Type", SqlDbType.VarChar,50),
 new SqlParameter("@IPM_Class", SqlDbType.VarChar,50),
 new SqlParameter("@IPM_STime", SqlDbType.DateTime,8),
 new SqlParameter("@IPM_EndTime", SqlDbType.DateTime,8),
 new SqlParameter("@IPM_Days", SqlDbType.Int,4),
 new SqlParameter("@IPM_DaysType", SqlDbType.VarChar,50),
 new SqlParameter("@IPM_State", SqlDbType.VarChar,50),
 new SqlParameter("@IPM_CustomerValue", SqlDbType.VarChar,50),
 new SqlParameter("@IPM_Money", SqlDbType.Decimal,9),
 new SqlParameter("@IPM_IsDetailsMoney", SqlDbType.Int,4),
 new SqlParameter("@IPM_Remarks", SqlDbType.VarChar,16),
 new SqlParameter("@IPM_Del", SqlDbType.Int,4),
 new SqlParameter("@IPM_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@IPM_MTime", SqlDbType.DateTime,8),
new SqlParameter("@IPM_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.IPM_Code;
parameters[1].Value = model.IPM_Name;
parameters[2].Value = model.IPM_DutyPerson;
parameters[3].Value = model.IPM_Import;
parameters[4].Value = model.IPM_Persons;
parameters[5].Value = model.IPM_Type;
parameters[6].Value = model.IPM_Class;
parameters[7].Value = model.IPM_STime;
parameters[8].Value = model.IPM_EndTime;
parameters[9].Value = model.IPM_Days;
parameters[10].Value = model.IPM_DaysType;
parameters[11].Value = model.IPM_State;
parameters[12].Value = model.IPM_CustomerValue;
parameters[13].Value = model.IPM_Money;
parameters[14].Value = model.IPM_IsDetailsMoney;
parameters[15].Value = model.IPM_Remarks;
parameters[16].Value = model.IPM_Del;
parameters[17].Value = model.IPM_Mender;
parameters[18].Value = model.IPM_MTime;
parameters[19].Value = model.IPM_ID;

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
public bool Delete(string s_IPM_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  IM_Project_Manage  ");
strSql.Append(" where IPM_ID=@IPM_ID ");
SqlParameter[] parameters = {
new SqlParameter("@IPM_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_IPM_ID;
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
public bool UpdateDel(KNet.Model.IM_Project_Manage model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   IM_Project_Manage  Set ");
strSql.Append("  IPM_Del=@IPM_Del ");
strSql.Append(" where IPM_ID=@IPM_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@IPM_Del", SqlDbType.Int,4),
new SqlParameter("@IPM_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.IPM_Del;
parameters[1].Value =  model.IPM_ID;

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
public bool DeleteList(string s_IPM_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   IM_Project_Manage  ");
strSql.Append(" where IPM_ID in ('"+s_IPM_ID+"')");

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
public KNet.Model.IM_Project_Manage GetModel(string IPM_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from IM_Project_Manage  ");
strSql.Append("where IPM_ID=@IPM_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@IPM_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = IPM_ID;
 KNet.Model.IM_Project_Manage model = new KNet.Model.IM_Project_Manage();
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
public KNet.Model.IM_Project_Manage DataRowToModel(DataRow row)
{
KNet.Model.IM_Project_Manage model=new KNet.Model.IM_Project_Manage();
if (row != null)
{
 if (row["IPM_ID"] != null)
{
 model.IPM_ID = row["IPM_ID"].ToString();
}
 else
{
 model.IPM_ID = "";
}
 if (row["IPM_Code"] != null)
{
 model.IPM_Code = row["IPM_Code"].ToString();
}
 else
{
 model.IPM_Code = "";
}
 if (row["IPM_Name"] != null)
{
 model.IPM_Name = row["IPM_Name"].ToString();
}
 else
{
 model.IPM_Name = "";
}
 if (row["IPM_DutyPerson"] != null)
{
 model.IPM_DutyPerson = row["IPM_DutyPerson"].ToString();
}
 else
{
 model.IPM_DutyPerson = "";
}
 if (row["IPM_Import"] != null)
{
 model.IPM_Import = row["IPM_Import"].ToString();
}
 else
{
 model.IPM_Import = "";
}
 if (row["IPM_Persons"] != null)
{
 model.IPM_Persons = row["IPM_Persons"].ToString();
}
 else
{
 model.IPM_Persons = "";
}
 if (row["IPM_Type"] != null)
{
 model.IPM_Type = row["IPM_Type"].ToString();
}
 else
{
 model.IPM_Type = "";
}
 if (row["IPM_Class"] != null)
{
 model.IPM_Class = row["IPM_Class"].ToString();
}
 else
{
 model.IPM_Class = "";
}
 if (row["IPM_STime"] != null)
{
 model.IPM_STime = DateTime.Parse(row["IPM_STime"].ToString());
}
 if (row["IPM_EndTime"] != null)
{
 model.IPM_EndTime = DateTime.Parse(row["IPM_EndTime"].ToString());
}
 if (row["IPM_Days"] != null)
{
 model.IPM_Days = int.Parse(row["IPM_Days"].ToString());
}
 else
{
 model.IPM_Days = 0;
}
 if (row["IPM_DaysType"] != null)
{
 model.IPM_DaysType = row["IPM_DaysType"].ToString();
}
 else
{
 model.IPM_DaysType = "";
}
 if (row["IPM_State"] != null)
{
 model.IPM_State = row["IPM_State"].ToString();
}
 else
{
 model.IPM_State = "";
}
 if (row["IPM_CustomerValue"] != null)
{
 model.IPM_CustomerValue = row["IPM_CustomerValue"].ToString();
}
 else
{
 model.IPM_CustomerValue = "";
}
 if (row["IPM_Money"] != null)
{
 model.IPM_Money = Decimal.Parse(row["IPM_Money"].ToString());
}
 else
{
 model.IPM_Money = 0;
}
 if (row["IPM_IsDetailsMoney"] != null)
{
 model.IPM_IsDetailsMoney = int.Parse(row["IPM_IsDetailsMoney"].ToString());
}
 else
{
 model.IPM_IsDetailsMoney = 0;
}
 if (row["IPM_Remarks"] != null)
{
 model.IPM_Remarks = row["IPM_Remarks"].ToString();
}
 else
{
 model.IPM_Remarks = "";
}
 if (row["IPM_Creator"] != null)
{
 model.IPM_Creator = row["IPM_Creator"].ToString();
}
 else
{
 model.IPM_Creator = "";
}
 if (row["IPM_CTime"] != null)
{
 model.IPM_CTime = DateTime.Parse(row["IPM_CTime"].ToString());
}
 if (row["IPM_Del"] != null)
{
 model.IPM_Del = int.Parse(row["IPM_Del"].ToString());
}
 else
{
 model.IPM_Del = 0;
}
 if (row["IPM_Mender"] != null)
{
 model.IPM_Mender = row["IPM_Mender"].ToString();
}
 else
{
 model.IPM_Mender = "";
}
 if (row["IPM_MTime"] != null)
{
 model.IPM_MTime = DateTime.Parse(row["IPM_MTime"].ToString());
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
strSql.Append(" FROM IM_Project_Manage ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

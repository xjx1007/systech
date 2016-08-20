 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class Zl_Produce_Problem
   {
   public Zl_Produce_Problem()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string ZPP_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from Zl_Produce_Problem");
strSql.Append(" where ZPP_ID=@ZPP_ID ");
SqlParameter[] parameters = {
new SqlParameter("@ZPP_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = ZPP_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.Zl_Produce_Problem model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into Zl_Produce_Problem(");
strSql.Append("ZPP_ID,ZPP_Code,ZPP_ProdutsBarCode,ZPP_ScStage,ZPP_Title,ZPP_Type,ZPP_Text,ZPP_STime,ZPP_DutyPerson,ZPP_DutyDepart,ZPP_HopeDate,ZPP_State,ZPP_Cause,ZPP_Temporary,ZPP_DoneTime,ZPP_ClosedState,ZPP_Result,ZPP_ClosedType,ZPP_Del,ZPP_Creator,ZPP_CTime,ZPP_Mender,ZPP_MTime,ZPP_Flow,ZPP_FlowStep ");
strSql.Append(") values (");
strSql.Append("@ZPP_ID,@ZPP_Code,@ZPP_ProdutsBarCode,@ZPP_ScStage,@ZPP_Title,@ZPP_Type,@ZPP_Text,@ZPP_STime,@ZPP_DutyPerson,@ZPP_DutyDepart,@ZPP_HopeDate,@ZPP_State,@ZPP_Cause,@ZPP_Temporary,@ZPP_DoneTime,@ZPP_ClosedState,@ZPP_Result,@ZPP_ClosedType,@ZPP_Del,@ZPP_Creator,@ZPP_CTime,@ZPP_Mender,@ZPP_MTime,@ZPP_Flow,@ZPP_FlowStep)");
SqlParameter[] parameters = {
 new SqlParameter("@ZPP_ID", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_Code", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_ProdutsBarCode", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_ScStage", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_Title", SqlDbType.VarChar,350),
 new SqlParameter("@ZPP_Type", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_Text", SqlDbType.VarChar,16),
 new SqlParameter("@ZPP_STime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPP_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_DutyDepart", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_HopeDate", SqlDbType.DateTime,8),
 new SqlParameter("@ZPP_State", SqlDbType.Int,4),
 new SqlParameter("@ZPP_Cause", SqlDbType.VarChar,1000),
 new SqlParameter("@ZPP_Temporary", SqlDbType.VarChar,1000),
 new SqlParameter("@ZPP_DoneTime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPP_ClosedState", SqlDbType.Int,4),
 new SqlParameter("@ZPP_Result", SqlDbType.VarChar,1000),
 new SqlParameter("@ZPP_ClosedType", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_Del", SqlDbType.Int,4),
 new SqlParameter("@ZPP_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPP_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPP_Flow", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_FlowStep", SqlDbType.VarChar,50)};
parameters[0].Value = model.ZPP_ID;
parameters[1].Value = model.ZPP_Code;
parameters[2].Value = model.ZPP_ProdutsBarCode;
parameters[3].Value = model.ZPP_ScStage;
parameters[4].Value = model.ZPP_Title;
parameters[5].Value = model.ZPP_Type;
parameters[6].Value = model.ZPP_Text;
parameters[7].Value = model.ZPP_STime;
parameters[8].Value = model.ZPP_DutyPerson;
parameters[9].Value = model.ZPP_DutyDepart;
parameters[10].Value = model.ZPP_HopeDate;
parameters[11].Value = model.ZPP_State;
parameters[12].Value = model.ZPP_Cause;
parameters[13].Value = model.ZPP_Temporary;
parameters[14].Value = model.ZPP_DoneTime;
parameters[15].Value = model.ZPP_ClosedState;
parameters[16].Value = model.ZPP_Result;
parameters[17].Value = model.ZPP_ClosedType;
parameters[18].Value = model.ZPP_Del;
parameters[19].Value = model.ZPP_Creator;
parameters[20].Value = model.ZPP_CTime;
parameters[21].Value = model.ZPP_Mender;
parameters[22].Value = model.ZPP_MTime;
parameters[23].Value = model.ZPP_Flow;
parameters[24].Value = model.ZPP_FlowStep;
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
public bool Update(KNet.Model.Zl_Produce_Problem model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update Zl_Produce_Problem set ");
strSql.Append("ZPP_Code=@ZPP_Code,");
strSql.Append("ZPP_ProdutsBarCode=@ZPP_ProdutsBarCode,");
strSql.Append("ZPP_ScStage=@ZPP_ScStage,");
strSql.Append("ZPP_Title=@ZPP_Title,");
strSql.Append("ZPP_Type=@ZPP_Type,");
strSql.Append("ZPP_Text=@ZPP_Text,");
strSql.Append("ZPP_STime=@ZPP_STime,");
strSql.Append("ZPP_DutyPerson=@ZPP_DutyPerson,");
strSql.Append("ZPP_DutyDepart=@ZPP_DutyDepart,");
strSql.Append("ZPP_HopeDate=@ZPP_HopeDate,");
strSql.Append("ZPP_State=@ZPP_State,");
strSql.Append("ZPP_Cause=@ZPP_Cause,");
strSql.Append("ZPP_Temporary=@ZPP_Temporary,");
strSql.Append("ZPP_DoneTime=@ZPP_DoneTime,");
strSql.Append("ZPP_ClosedState=@ZPP_ClosedState,");
strSql.Append("ZPP_Result=@ZPP_Result,");
strSql.Append("ZPP_ClosedType=@ZPP_ClosedType,");
strSql.Append("ZPP_Del=@ZPP_Del,");
strSql.Append("ZPP_Mender=@ZPP_Mender,");
strSql.Append("ZPP_MTime=@ZPP_MTime,");
strSql.Append("ZPP_Flow=@ZPP_Flow,");
strSql.Append("ZPP_FlowStep=@ZPP_FlowStep");
strSql.Append(" where ZPP_ID=@ZPP_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@ZPP_Code", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_ProdutsBarCode", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_ScStage", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_Title", SqlDbType.VarChar,350),
 new SqlParameter("@ZPP_Type", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_Text", SqlDbType.VarChar,16),
 new SqlParameter("@ZPP_STime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPP_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_DutyDepart", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_HopeDate", SqlDbType.DateTime,8),
 new SqlParameter("@ZPP_State", SqlDbType.Int,4),
 new SqlParameter("@ZPP_Cause", SqlDbType.VarChar,1000),
 new SqlParameter("@ZPP_Temporary", SqlDbType.VarChar,1000),
 new SqlParameter("@ZPP_DoneTime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPP_ClosedState", SqlDbType.Int,4),
 new SqlParameter("@ZPP_Result", SqlDbType.VarChar,1000),
 new SqlParameter("@ZPP_ClosedType", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_Del", SqlDbType.Int,4),
 new SqlParameter("@ZPP_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPP_Flow", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_FlowStep", SqlDbType.VarChar,50),
new SqlParameter("@ZPP_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.ZPP_Code;
parameters[1].Value = model.ZPP_ProdutsBarCode;
parameters[2].Value = model.ZPP_ScStage;
parameters[3].Value = model.ZPP_Title;
parameters[4].Value = model.ZPP_Type;
parameters[5].Value = model.ZPP_Text;
parameters[6].Value = model.ZPP_STime;
parameters[7].Value = model.ZPP_DutyPerson;
parameters[8].Value = model.ZPP_DutyDepart;
parameters[9].Value = model.ZPP_HopeDate;
parameters[10].Value = model.ZPP_State;
parameters[11].Value = model.ZPP_Cause;
parameters[12].Value = model.ZPP_Temporary;
parameters[13].Value = model.ZPP_DoneTime;
parameters[14].Value = model.ZPP_ClosedState;
parameters[15].Value = model.ZPP_Result;
parameters[16].Value = model.ZPP_ClosedType;
parameters[17].Value = model.ZPP_Del;
parameters[18].Value = model.ZPP_Mender;
parameters[19].Value = model.ZPP_MTime;
parameters[20].Value = model.ZPP_Flow;
parameters[21].Value = model.ZPP_FlowStep;
parameters[22].Value = model.ZPP_ID;

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
public bool Delete(string s_ZPP_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  Zl_Produce_Problem  ");
strSql.Append(" where ZPP_ID=@ZPP_ID ");
SqlParameter[] parameters = {
new SqlParameter("@ZPP_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_ZPP_ID;
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
public bool UpdateDel(KNet.Model.Zl_Produce_Problem model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   Zl_Produce_Problem  Set ");
strSql.Append("  ZPP_Del=@ZPP_Del ");
strSql.Append(" where ZPP_ID=@ZPP_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@ZPP_Del", SqlDbType.Int,4),
new SqlParameter("@ZPP_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.ZPP_Del;
parameters[1].Value =  model.ZPP_ID;

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
public bool DeleteList(string s_ZPP_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   Zl_Produce_Problem  ");
strSql.Append(" where ZPP_ID in ('"+s_ZPP_ID+"')");

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
public KNet.Model.Zl_Produce_Problem GetModel(string ZPP_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from Zl_Produce_Problem  ");
strSql.Append("where ZPP_ID=@ZPP_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@ZPP_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = ZPP_ID;
 KNet.Model.Zl_Produce_Problem model = new KNet.Model.Zl_Produce_Problem();
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
public KNet.Model.Zl_Produce_Problem DataRowToModel(DataRow row)
{
KNet.Model.Zl_Produce_Problem model=new KNet.Model.Zl_Produce_Problem();
if (row != null)
{
 if (row["ZPP_ID"] != null)
{
 model.ZPP_ID = row["ZPP_ID"].ToString();
}
 else
{
 model.ZPP_ID = "";
}
 if (row["ZPP_Code"] != null)
{
 model.ZPP_Code = row["ZPP_Code"].ToString();
}
 else
{
 model.ZPP_Code = "";
}
 if (row["ZPP_ProdutsBarCode"] != null)
{
 model.ZPP_ProdutsBarCode = row["ZPP_ProdutsBarCode"].ToString();
}
 else
{
 model.ZPP_ProdutsBarCode = "";
}
 if (row["ZPP_ScStage"] != null)
{
 model.ZPP_ScStage = row["ZPP_ScStage"].ToString();
}
 else
{
 model.ZPP_ScStage = "";
}
 if (row["ZPP_Title"] != null)
{
 model.ZPP_Title = row["ZPP_Title"].ToString();
}
 else
{
 model.ZPP_Title = "";
}
 if (row["ZPP_Type"] != null)
{
 model.ZPP_Type = row["ZPP_Type"].ToString();
}
 else
{
 model.ZPP_Type = "";
}
 if (row["ZPP_Text"] != null)
{
 model.ZPP_Text = row["ZPP_Text"].ToString();
}
 else
{
 model.ZPP_Text = "";
}
 if (row["ZPP_STime"] != null)
{
 model.ZPP_STime = DateTime.Parse(row["ZPP_STime"].ToString());
}
 if (row["ZPP_DutyPerson"] != null)
{
 model.ZPP_DutyPerson = row["ZPP_DutyPerson"].ToString();
}
 else
{
 model.ZPP_DutyPerson = "";
}
 if (row["ZPP_DutyDepart"] != null)
{
 model.ZPP_DutyDepart = row["ZPP_DutyDepart"].ToString();
}
 else
{
 model.ZPP_DutyDepart = "";
}
 if (row["ZPP_HopeDate"] != null)
{
 model.ZPP_HopeDate = DateTime.Parse(row["ZPP_HopeDate"].ToString());
}
 if (row["ZPP_State"] != null)
{
 model.ZPP_State = int.Parse(row["ZPP_State"].ToString());
}
 else
{
 model.ZPP_State = 0;
}
 if (row["ZPP_Cause"] != null)
{
 model.ZPP_Cause = row["ZPP_Cause"].ToString();
}
 else
{
 model.ZPP_Cause = "";
}
 if (row["ZPP_Temporary"] != null)
{
 model.ZPP_Temporary = row["ZPP_Temporary"].ToString();
}
 else
{
 model.ZPP_Temporary = "";
}
 if (row["ZPP_DoneTime"] != null)
{
 model.ZPP_DoneTime = DateTime.Parse(row["ZPP_DoneTime"].ToString());
}
 if (row["ZPP_ClosedState"] != null)
{
 model.ZPP_ClosedState = int.Parse(row["ZPP_ClosedState"].ToString());
}
 else
{
 model.ZPP_ClosedState = 0;
}
 if (row["ZPP_Result"] != null)
{
 model.ZPP_Result = row["ZPP_Result"].ToString();
}
 else
{
 model.ZPP_Result = "";
}
 if (row["ZPP_ClosedType"] != null)
{
 model.ZPP_ClosedType = row["ZPP_ClosedType"].ToString();
}
 else
{
 model.ZPP_ClosedType = "";
}
 if (row["ZPP_Del"] != null)
{
 model.ZPP_Del = int.Parse(row["ZPP_Del"].ToString());
}
 else
{
 model.ZPP_Del = 0;
}
 if (row["ZPP_Creator"] != null)
{
 model.ZPP_Creator = row["ZPP_Creator"].ToString();
}
 else
{
 model.ZPP_Creator = "";
}
 if (row["ZPP_CTime"] != null)
{
 model.ZPP_CTime = DateTime.Parse(row["ZPP_CTime"].ToString());
}
 if (row["ZPP_Mender"] != null)
{
 model.ZPP_Mender = row["ZPP_Mender"].ToString();
}
 else
{
 model.ZPP_Mender = "";
}
 if (row["ZPP_MTime"] != null)
{
 model.ZPP_MTime = DateTime.Parse(row["ZPP_MTime"].ToString());
}
 if (row["ZPP_Flow"] != null)
{
 model.ZPP_Flow = row["ZPP_Flow"].ToString();
}
 else
{
 model.ZPP_Flow = "";
}
 if (row["ZPP_FlowStep"] != null)
{
 model.ZPP_FlowStep = row["ZPP_FlowStep"].ToString();
}
 else
{
 model.ZPP_FlowStep = "";
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
strSql.Append(" FROM Zl_Produce_Problem ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

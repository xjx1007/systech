 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class ZL_Task_Instruction
   {
   public ZL_Task_Instruction()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string ZTI_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from ZL_Task_Instruction");
strSql.Append(" where ZTI_ID=@ZTI_ID ");
SqlParameter[] parameters = {
new SqlParameter("@ZTI_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = ZTI_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.ZL_Task_Instruction model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into ZL_Task_Instruction(");
strSql.Append("ZTI_ID,ZTI_Code,ZTI_ProductsBarCode,ZTI_Name,ZTI_Stime,ZTI_DutyPerson,ZTI_Flow,ZTI_FlowStep,ZTI_Remarks,ZTI_State,ZTI_Del,ZTI_CTime,ZTI_Creator,ZTI_MTime,ZTI_Mender ");
strSql.Append(") values (");
strSql.Append("@ZTI_ID,@ZTI_Code,@ZTI_ProductsBarCode,@ZTI_Name,@ZTI_Stime,@ZTI_DutyPerson,@ZTI_Flow,@ZTI_FlowStep,@ZTI_Remarks,@ZTI_State,@ZTI_Del,@ZTI_CTime,@ZTI_Creator,@ZTI_MTime,@ZTI_Mender)");
SqlParameter[] parameters = {
 new SqlParameter("@ZTI_ID", SqlDbType.VarChar,50),
 new SqlParameter("@ZTI_Code", SqlDbType.VarChar,50),
 new SqlParameter("@ZTI_ProductsBarCode", SqlDbType.VarChar,50),
 new SqlParameter("@ZTI_Name", SqlDbType.VarChar,550),
 new SqlParameter("@ZTI_Stime", SqlDbType.DateTime,8),
 new SqlParameter("@ZTI_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@ZTI_Flow", SqlDbType.VarChar,50),
 new SqlParameter("@ZTI_FlowStep", SqlDbType.VarChar,50),
 new SqlParameter("@ZTI_Remarks", SqlDbType.VarChar,550),
 new SqlParameter("@ZTI_State", SqlDbType.Int,4),
 new SqlParameter("@ZTI_Del", SqlDbType.Int,4),
 new SqlParameter("@ZTI_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@ZTI_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@ZTI_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@ZTI_Mender", SqlDbType.VarChar,50)};
parameters[0].Value = model.ZTI_ID;
parameters[1].Value = model.ZTI_Code;
parameters[2].Value = model.ZTI_ProductsBarCode;
parameters[3].Value = model.ZTI_Name;
parameters[4].Value = model.ZTI_Stime;
parameters[5].Value = model.ZTI_DutyPerson;
parameters[6].Value = model.ZTI_Flow;
parameters[7].Value = model.ZTI_FlowStep;
parameters[8].Value = model.ZTI_Remarks;
parameters[9].Value = model.ZTI_State;
parameters[10].Value = model.ZTI_Del;
parameters[11].Value = model.ZTI_CTime;
parameters[12].Value = model.ZTI_Creator;
parameters[13].Value = model.ZTI_MTime;
parameters[14].Value = model.ZTI_Mender;
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
public bool Update(KNet.Model.ZL_Task_Instruction model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update ZL_Task_Instruction set ");
strSql.Append("ZTI_Code=@ZTI_Code,");
strSql.Append("ZTI_ProductsBarCode=@ZTI_ProductsBarCode,");
strSql.Append("ZTI_Name=@ZTI_Name,");
strSql.Append("ZTI_Stime=@ZTI_Stime,");
strSql.Append("ZTI_DutyPerson=@ZTI_DutyPerson,");
strSql.Append("ZTI_Flow=@ZTI_Flow,");
strSql.Append("ZTI_FlowStep=@ZTI_FlowStep,");
strSql.Append("ZTI_Remarks=@ZTI_Remarks,");
strSql.Append("ZTI_State=@ZTI_State,");
strSql.Append("ZTI_Del=@ZTI_Del,");
strSql.Append("ZTI_MTime=@ZTI_MTime,");
strSql.Append("ZTI_Mender=@ZTI_Mender");
strSql.Append(" where ZTI_ID=@ZTI_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@ZTI_Code", SqlDbType.VarChar,50),
 new SqlParameter("@ZTI_ProductsBarCode", SqlDbType.VarChar,50),
 new SqlParameter("@ZTI_Name", SqlDbType.VarChar,550),
 new SqlParameter("@ZTI_Stime", SqlDbType.DateTime,8),
 new SqlParameter("@ZTI_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@ZTI_Flow", SqlDbType.VarChar,50),
 new SqlParameter("@ZTI_FlowStep", SqlDbType.VarChar,50),
 new SqlParameter("@ZTI_Remarks", SqlDbType.VarChar,550),
 new SqlParameter("@ZTI_State", SqlDbType.Int,4),
 new SqlParameter("@ZTI_Del", SqlDbType.Int,4),
 new SqlParameter("@ZTI_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@ZTI_Mender", SqlDbType.VarChar,50),
new SqlParameter("@ZTI_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.ZTI_Code;
parameters[1].Value = model.ZTI_ProductsBarCode;
parameters[2].Value = model.ZTI_Name;
parameters[3].Value = model.ZTI_Stime;
parameters[4].Value = model.ZTI_DutyPerson;
parameters[5].Value = model.ZTI_Flow;
parameters[6].Value = model.ZTI_FlowStep;
parameters[7].Value = model.ZTI_Remarks;
parameters[8].Value = model.ZTI_State;
parameters[9].Value = model.ZTI_Del;
parameters[10].Value = model.ZTI_MTime;
parameters[11].Value = model.ZTI_Mender;
parameters[12].Value = model.ZTI_ID;

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
public bool Delete(string s_ZTI_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  ZL_Task_Instruction  ");
strSql.Append(" where ZTI_ID=@ZTI_ID ");
SqlParameter[] parameters = {
new SqlParameter("@ZTI_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_ZTI_ID;
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
public bool UpdateDel(KNet.Model.ZL_Task_Instruction model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   ZL_Task_Instruction  Set ");
strSql.Append("  ZTI_Del=@ZTI_Del ");
strSql.Append(" where ZTI_ID=@ZTI_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@ZTI_Del", SqlDbType.Int,4),
new SqlParameter("@ZTI_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.ZTI_Del;
parameters[1].Value =  model.ZTI_ID;

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
public bool DeleteList(string s_ZTI_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   ZL_Task_Instruction  ");
strSql.Append(" where ZTI_ID in ('"+s_ZTI_ID+"')");

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
public KNet.Model.ZL_Task_Instruction GetModel(string ZTI_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from ZL_Task_Instruction  ");
strSql.Append("where ZTI_ID=@ZTI_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@ZTI_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = ZTI_ID;
 KNet.Model.ZL_Task_Instruction model = new KNet.Model.ZL_Task_Instruction();
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
public KNet.Model.ZL_Task_Instruction DataRowToModel(DataRow row)
{
KNet.Model.ZL_Task_Instruction model=new KNet.Model.ZL_Task_Instruction();
if (row != null)
{
 if (row["ZTI_ID"] != null)
{
 model.ZTI_ID = row["ZTI_ID"].ToString();
}
 else
{
 model.ZTI_ID = "";
}
 if (row["ZTI_Code"] != null)
{
 model.ZTI_Code = row["ZTI_Code"].ToString();
}
 else
{
 model.ZTI_Code = "";
}
 if (row["ZTI_ProductsBarCode"] != null)
{
 model.ZTI_ProductsBarCode = row["ZTI_ProductsBarCode"].ToString();
}
 else
{
 model.ZTI_ProductsBarCode = "";
}
 if (row["ZTI_Name"] != null)
{
 model.ZTI_Name = row["ZTI_Name"].ToString();
}
 else
{
 model.ZTI_Name = "";
}
 if (row["ZTI_Stime"] != null)
{
 model.ZTI_Stime = DateTime.Parse(row["ZTI_Stime"].ToString());
}
 if (row["ZTI_DutyPerson"] != null)
{
 model.ZTI_DutyPerson = row["ZTI_DutyPerson"].ToString();
}
 else
{
 model.ZTI_DutyPerson = "";
}
 if (row["ZTI_Flow"] != null)
{
 model.ZTI_Flow = row["ZTI_Flow"].ToString();
}
 else
{
 model.ZTI_Flow = "";
}
 if (row["ZTI_FlowStep"] != null)
{
 model.ZTI_FlowStep = row["ZTI_FlowStep"].ToString();
}
 else
{
 model.ZTI_FlowStep = "";
}
 if (row["ZTI_Remarks"] != null)
{
 model.ZTI_Remarks = row["ZTI_Remarks"].ToString();
}
 else
{
 model.ZTI_Remarks = "";
}
 if (row["ZTI_State"] != null)
{
 model.ZTI_State = int.Parse(row["ZTI_State"].ToString());
}
 else
{
 model.ZTI_State = 0;
}
 if (row["ZTI_Del"] != null)
{
 model.ZTI_Del = int.Parse(row["ZTI_Del"].ToString());
}
 else
{
 model.ZTI_Del = 0;
}
 if (row["ZTI_CTime"] != null)
{
 model.ZTI_CTime = DateTime.Parse(row["ZTI_CTime"].ToString());
}
 if (row["ZTI_Creator"] != null)
{
 model.ZTI_Creator = row["ZTI_Creator"].ToString();
}
 else
{
 model.ZTI_Creator = "";
}
 if (row["ZTI_MTime"] != null)
{
 model.ZTI_MTime = DateTime.Parse(row["ZTI_MTime"].ToString());
}
 if (row["ZTI_Mender"] != null)
{
 model.ZTI_Mender = row["ZTI_Mender"].ToString();
}
 else
{
 model.ZTI_Mender = "";
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
strSql.Append(" FROM ZL_Task_Instruction ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

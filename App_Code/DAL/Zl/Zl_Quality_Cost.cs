 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class Zl_Quality_Cost
   {
   public Zl_Quality_Cost()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string ZQC_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from Zl_Quality_Cost");
strSql.Append(" where ZQC_ID=@ZQC_ID ");
SqlParameter[] parameters = {
new SqlParameter("@ZQC_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = ZQC_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.Zl_Quality_Cost model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into Zl_Quality_Cost(");
strSql.Append("ZQC_ID,ZQC_Code,ZQC_ProjectType,ZQC_ContentType,ZQC_STime,ZQC_Money,ZQC_Remarks,ZQC_Del,ZQC_Creator,ZQC_CTime,ZQC_Mender,ZQC_MTime,ZQC_Flow,ZQC_FlowStep,ZQC_State ");
strSql.Append(") values (");
strSql.Append("@ZQC_ID,@ZQC_Code,@ZQC_ProjectType,@ZQC_ContentType,@ZQC_STime,@ZQC_Money,@ZQC_Remarks,@ZQC_Del,@ZQC_Creator,@ZQC_CTime,@ZQC_Mender,@ZQC_MTime,@ZQC_Flow,@ZQC_FlowStep,@ZQC_State)");
SqlParameter[] parameters = {
 new SqlParameter("@ZQC_ID", SqlDbType.VarChar,50),
 new SqlParameter("@ZQC_Code", SqlDbType.VarChar,50),
 new SqlParameter("@ZQC_ProjectType", SqlDbType.VarChar,50),
 new SqlParameter("@ZQC_ContentType", SqlDbType.VarChar,50),
 new SqlParameter("@ZQC_STime", SqlDbType.DateTime,8),
 new SqlParameter("@ZQC_Money", SqlDbType.Decimal,9),
 new SqlParameter("@ZQC_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@ZQC_Del", SqlDbType.Int,4),
 new SqlParameter("@ZQC_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@ZQC_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@ZQC_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@ZQC_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@ZQC_Flow", SqlDbType.VarChar,50),
 new SqlParameter("@ZQC_FlowStep", SqlDbType.VarChar,50),
 new SqlParameter("@ZQC_State", SqlDbType.Int,4)};
parameters[0].Value = model.ZQC_ID;
parameters[1].Value = model.ZQC_Code;
parameters[2].Value = model.ZQC_ProjectType;
parameters[3].Value = model.ZQC_ContentType;
parameters[4].Value = model.ZQC_STime;
parameters[5].Value = model.ZQC_Money;
parameters[6].Value = model.ZQC_Remarks;
parameters[7].Value = model.ZQC_Del;
parameters[8].Value = model.ZQC_Creator;
parameters[9].Value = model.ZQC_CTime;
parameters[10].Value = model.ZQC_Mender;
parameters[11].Value = model.ZQC_MTime;
parameters[12].Value = model.ZQC_Flow;
parameters[13].Value = model.ZQC_FlowStep;
parameters[14].Value = model.ZQC_State;
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
public bool Update(KNet.Model.Zl_Quality_Cost model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update Zl_Quality_Cost set ");
strSql.Append("ZQC_Code=@ZQC_Code,");
strSql.Append("ZQC_ProjectType=@ZQC_ProjectType,");
strSql.Append("ZQC_ContentType=@ZQC_ContentType,");
strSql.Append("ZQC_STime=@ZQC_STime,");
strSql.Append("ZQC_Money=@ZQC_Money,");
strSql.Append("ZQC_Remarks=@ZQC_Remarks,");
strSql.Append("ZQC_Del=@ZQC_Del,");
strSql.Append("ZQC_Mender=@ZQC_Mender,");
strSql.Append("ZQC_MTime=@ZQC_MTime,");
strSql.Append("ZQC_Flow=@ZQC_Flow,");
strSql.Append("ZQC_FlowStep=@ZQC_FlowStep,");
strSql.Append("ZQC_State=@ZQC_State");
strSql.Append(" where ZQC_ID=@ZQC_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@ZQC_Code", SqlDbType.VarChar,50),
 new SqlParameter("@ZQC_ProjectType", SqlDbType.VarChar,50),
 new SqlParameter("@ZQC_ContentType", SqlDbType.VarChar,50),
 new SqlParameter("@ZQC_STime", SqlDbType.DateTime,8),
 new SqlParameter("@ZQC_Money", SqlDbType.Decimal,9),
 new SqlParameter("@ZQC_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@ZQC_Del", SqlDbType.Int,4),
 new SqlParameter("@ZQC_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@ZQC_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@ZQC_Flow", SqlDbType.VarChar,50),
 new SqlParameter("@ZQC_FlowStep", SqlDbType.VarChar,50),
 new SqlParameter("@ZQC_State", SqlDbType.Int,4),
new SqlParameter("@ZQC_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.ZQC_Code;
parameters[1].Value = model.ZQC_ProjectType;
parameters[2].Value = model.ZQC_ContentType;
parameters[3].Value = model.ZQC_STime;
parameters[4].Value = model.ZQC_Money;
parameters[5].Value = model.ZQC_Remarks;
parameters[6].Value = model.ZQC_Del;
parameters[7].Value = model.ZQC_Mender;
parameters[8].Value = model.ZQC_MTime;
parameters[9].Value = model.ZQC_Flow;
parameters[10].Value = model.ZQC_FlowStep;
parameters[11].Value = model.ZQC_State;
parameters[12].Value = model.ZQC_ID;

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
public bool Delete(string s_ZQC_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  Zl_Quality_Cost  ");
strSql.Append(" where ZQC_ID=@ZQC_ID ");
SqlParameter[] parameters = {
new SqlParameter("@ZQC_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_ZQC_ID;
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
public bool UpdateDel(KNet.Model.Zl_Quality_Cost model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   Zl_Quality_Cost  Set ");
strSql.Append("  ZQC_Del=@ZQC_Del ");
strSql.Append(" where ZQC_ID=@ZQC_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@ZQC_Del", SqlDbType.Int,4),
new SqlParameter("@ZQC_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.ZQC_Del;
parameters[1].Value =  model.ZQC_ID;

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
public bool DeleteList(string s_ZQC_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   Zl_Quality_Cost  ");
strSql.Append(" where ZQC_ID in ('"+s_ZQC_ID+"')");

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
public KNet.Model.Zl_Quality_Cost GetModel(string ZQC_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from Zl_Quality_Cost  ");
strSql.Append("where ZQC_ID=@ZQC_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@ZQC_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = ZQC_ID;
 KNet.Model.Zl_Quality_Cost model = new KNet.Model.Zl_Quality_Cost();
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
public KNet.Model.Zl_Quality_Cost DataRowToModel(DataRow row)
{
KNet.Model.Zl_Quality_Cost model=new KNet.Model.Zl_Quality_Cost();
if (row != null)
{
 if (row["ZQC_ID"] != null)
{
 model.ZQC_ID = row["ZQC_ID"].ToString();
}
 else
{
 model.ZQC_ID = "";
}
 if (row["ZQC_Code"] != null)
{
 model.ZQC_Code = row["ZQC_Code"].ToString();
}
 else
{
 model.ZQC_Code = "";
}
 if (row["ZQC_ProjectType"] != null)
{
 model.ZQC_ProjectType = row["ZQC_ProjectType"].ToString();
}
 else
{
 model.ZQC_ProjectType = "";
}
 if (row["ZQC_ContentType"] != null)
{
 model.ZQC_ContentType = row["ZQC_ContentType"].ToString();
}
 else
{
 model.ZQC_ContentType = "";
}
 if (row["ZQC_STime"] != null)
{
 model.ZQC_STime = DateTime.Parse(row["ZQC_STime"].ToString());
}
 if (row["ZQC_Money"] != null)
{
 model.ZQC_Money = Decimal.Parse(row["ZQC_Money"].ToString());
}
 else
{
 model.ZQC_Money = 0;
}
 if (row["ZQC_Remarks"] != null)
{
 model.ZQC_Remarks = row["ZQC_Remarks"].ToString();
}
 else
{
 model.ZQC_Remarks = "";
}
 if (row["ZQC_Del"] != null)
{
 model.ZQC_Del = int.Parse(row["ZQC_Del"].ToString());
}
 else
{
 model.ZQC_Del = 0;
}
 if (row["ZQC_Creator"] != null)
{
 model.ZQC_Creator = row["ZQC_Creator"].ToString();
}
 else
{
 model.ZQC_Creator = "";
}
 if (row["ZQC_CTime"] != null)
{
 model.ZQC_CTime = DateTime.Parse(row["ZQC_CTime"].ToString());
}
 if (row["ZQC_Mender"] != null)
{
 model.ZQC_Mender = row["ZQC_Mender"].ToString();
}
 else
{
 model.ZQC_Mender = "";
}
 if (row["ZQC_MTime"] != null)
{
 model.ZQC_MTime = DateTime.Parse(row["ZQC_MTime"].ToString());
}
 if (row["ZQC_Flow"] != null)
{
 model.ZQC_Flow = row["ZQC_Flow"].ToString();
}
 else
{
 model.ZQC_Flow = "";
}
 if (row["ZQC_FlowStep"] != null)
{
 model.ZQC_FlowStep = row["ZQC_FlowStep"].ToString();
}
 else
{
 model.ZQC_FlowStep = "";
}
 if (row["ZQC_State"] != null)
{
 model.ZQC_State = int.Parse(row["ZQC_State"].ToString());
}
 else
{
 model.ZQC_State = 0;
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
strSql.Append(" FROM Zl_Quality_Cost ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

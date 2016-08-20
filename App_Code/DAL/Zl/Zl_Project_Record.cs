 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class Zl_Project_Record
   {
   public Zl_Project_Record()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string ZPR_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from Zl_Project_Record");
strSql.Append(" where ZPR_ID=@ZPR_ID ");
SqlParameter[] parameters = {
new SqlParameter("@ZPR_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = ZPR_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.Zl_Project_Record model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into Zl_Project_Record(");
strSql.Append("ZPR_ID,ZPR_Code,ZPR_Title,ZPR_STime,ZPR_Flow,ZPR_State,ZPR_Remarks,ZPR_Del,ZPR_CTime,ZPR_Creator,ZPR_MTime,ZPR_Mender,ZPR_SampleID,ZPR_SampleName,ZPR_Type ");
strSql.Append(") values (");
strSql.Append("@ZPR_ID,@ZPR_Code,@ZPR_Title,@ZPR_STime,@ZPR_Flow,@ZPR_State,@ZPR_Remarks,@ZPR_Del,@ZPR_CTime,@ZPR_Creator,@ZPR_MTime,@ZPR_Mender,@ZPR_SampleID,@ZPR_SampleName,@ZPR_Type)");
SqlParameter[] parameters = {
 new SqlParameter("@ZPR_ID", SqlDbType.VarChar,50),
 new SqlParameter("@ZPR_Code", SqlDbType.VarChar,50),
 new SqlParameter("@ZPR_Title", SqlDbType.VarChar,500),
 new SqlParameter("@ZPR_STime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPR_Flow", SqlDbType.VarChar,50),
 new SqlParameter("@ZPR_State", SqlDbType.Int,4),
 new SqlParameter("@ZPR_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@ZPR_Del", SqlDbType.Int,4),
 new SqlParameter("@ZPR_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPR_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@ZPR_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPR_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@ZPR_SampleID", SqlDbType.VarChar,50),
 new SqlParameter("@ZPR_SampleName", SqlDbType.VarChar,350),
 new SqlParameter("@ZPR_Type", SqlDbType.Int,4)};
parameters[0].Value = model.ZPR_ID;
parameters[1].Value = model.ZPR_Code;
parameters[2].Value = model.ZPR_Title;
parameters[3].Value = model.ZPR_STime;
parameters[4].Value = model.ZPR_Flow;
parameters[5].Value = model.ZPR_State;
parameters[6].Value = model.ZPR_Remarks;
parameters[7].Value = model.ZPR_Del;
parameters[8].Value = model.ZPR_CTime;
parameters[9].Value = model.ZPR_Creator;
parameters[10].Value = model.ZPR_MTime;
parameters[11].Value = model.ZPR_Mender;
parameters[12].Value = model.ZPR_SampleID;
parameters[13].Value = model.ZPR_SampleName;
parameters[14].Value = model.ZPR_Type;
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
public bool Update(KNet.Model.Zl_Project_Record model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update Zl_Project_Record set ");
strSql.Append("ZPR_Code=@ZPR_Code,");
strSql.Append("ZPR_Title=@ZPR_Title,");
strSql.Append("ZPR_STime=@ZPR_STime,");
strSql.Append("ZPR_Flow=@ZPR_Flow,");
strSql.Append("ZPR_State=@ZPR_State,");
strSql.Append("ZPR_Remarks=@ZPR_Remarks,");
strSql.Append("ZPR_Del=@ZPR_Del,");
strSql.Append("ZPR_MTime=@ZPR_MTime,");
strSql.Append("ZPR_Mender=@ZPR_Mender,");
strSql.Append("ZPR_SampleID=@ZPR_SampleID,");
strSql.Append("ZPR_SampleName=@ZPR_SampleName,");
strSql.Append("ZPR_Type=@ZPR_Type");
strSql.Append(" where ZPR_ID=@ZPR_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@ZPR_Code", SqlDbType.VarChar,50),
 new SqlParameter("@ZPR_Title", SqlDbType.VarChar,500),
 new SqlParameter("@ZPR_STime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPR_Flow", SqlDbType.VarChar,50),
 new SqlParameter("@ZPR_State", SqlDbType.Int,4),
 new SqlParameter("@ZPR_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@ZPR_Del", SqlDbType.Int,4),
 new SqlParameter("@ZPR_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPR_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@ZPR_SampleID", SqlDbType.VarChar,50),
 new SqlParameter("@ZPR_SampleName", SqlDbType.VarChar,350),
 new SqlParameter("@ZPR_Type", SqlDbType.Int,4),
new SqlParameter("@ZPR_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.ZPR_Code;
parameters[1].Value = model.ZPR_Title;
parameters[2].Value = model.ZPR_STime;
parameters[3].Value = model.ZPR_Flow;
parameters[4].Value = model.ZPR_State;
parameters[5].Value = model.ZPR_Remarks;
parameters[6].Value = model.ZPR_Del;
parameters[7].Value = model.ZPR_MTime;
parameters[8].Value = model.ZPR_Mender;
parameters[9].Value = model.ZPR_SampleID;
parameters[10].Value = model.ZPR_SampleName;
parameters[11].Value = model.ZPR_Type;
parameters[12].Value = model.ZPR_ID;

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
public bool Delete(string s_ZPR_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  Zl_Project_Record  ");
strSql.Append(" where ZPR_ID=@ZPR_ID ");
SqlParameter[] parameters = {
new SqlParameter("@ZPR_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_ZPR_ID;
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
public bool UpdateDel(KNet.Model.Zl_Project_Record model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   Zl_Project_Record  Set ");
strSql.Append("  ZPR_Del=@ZPR_Del ");
strSql.Append(" where ZPR_ID=@ZPR_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@ZPR_Del", SqlDbType.Int,4),
new SqlParameter("@ZPR_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.ZPR_Del;
parameters[1].Value =  model.ZPR_ID;

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
public bool DeleteList(string s_ZPR_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   Zl_Project_Record  ");
strSql.Append(" where ZPR_ID in ('"+s_ZPR_ID+"')");

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
public KNet.Model.Zl_Project_Record GetModel(string ZPR_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from Zl_Project_Record  ");
strSql.Append("where ZPR_ID=@ZPR_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@ZPR_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = ZPR_ID;
 KNet.Model.Zl_Project_Record model = new KNet.Model.Zl_Project_Record();
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
public KNet.Model.Zl_Project_Record DataRowToModel(DataRow row)
{
KNet.Model.Zl_Project_Record model=new KNet.Model.Zl_Project_Record();
if (row != null)
{
 if (row["ZPR_ID"] != null)
{
 model.ZPR_ID = row["ZPR_ID"].ToString();
}
 else
{
 model.ZPR_ID = "";
}
 if (row["ZPR_Code"] != null)
{
 model.ZPR_Code = row["ZPR_Code"].ToString();
}
 else
{
 model.ZPR_Code = "";
}
 if (row["ZPR_Title"] != null)
{
 model.ZPR_Title = row["ZPR_Title"].ToString();
}
 else
{
 model.ZPR_Title = "";
}
 if (row["ZPR_STime"] != null)
{
 model.ZPR_STime = DateTime.Parse(row["ZPR_STime"].ToString());
}
 if (row["ZPR_Flow"] != null)
{
 model.ZPR_Flow = row["ZPR_Flow"].ToString();
}
 else
{
 model.ZPR_Flow = "";
}
 if (row["ZPR_State"] != null)
{
 model.ZPR_State = int.Parse(row["ZPR_State"].ToString());
}
 else
{
 model.ZPR_State = 0;
}
 if (row["ZPR_Remarks"] != null)
{
 model.ZPR_Remarks = row["ZPR_Remarks"].ToString();
}
 else
{
 model.ZPR_Remarks = "";
}
 if (row["ZPR_Del"] != null)
{
 model.ZPR_Del = int.Parse(row["ZPR_Del"].ToString());
}
 else
{
 model.ZPR_Del = 0;
}
 if (row["ZPR_CTime"] != null)
{
 model.ZPR_CTime = DateTime.Parse(row["ZPR_CTime"].ToString());
}
 if (row["ZPR_Creator"] != null)
{
 model.ZPR_Creator = row["ZPR_Creator"].ToString();
}
 else
{
 model.ZPR_Creator = "";
}
 if (row["ZPR_MTime"] != null)
{
 model.ZPR_MTime = DateTime.Parse(row["ZPR_MTime"].ToString());
}
 if (row["ZPR_Mender"] != null)
{
 model.ZPR_Mender = row["ZPR_Mender"].ToString();
}
 else
{
 model.ZPR_Mender = "";
}
 if (row["ZPR_SampleID"] != null)
{
 model.ZPR_SampleID = row["ZPR_SampleID"].ToString();
}
 else
{
 model.ZPR_SampleID = "";
}
 if (row["ZPR_SampleName"] != null)
{
 model.ZPR_SampleName = row["ZPR_SampleName"].ToString();
}
 else
{
 model.ZPR_SampleName = "";
}
 if (row["ZPR_Type"] != null)
{
 model.ZPR_Type = int.Parse(row["ZPR_Type"].ToString());
}
 else
{
 model.ZPR_Type = 0;
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
strSql.Append(" FROM Zl_Project_Record ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

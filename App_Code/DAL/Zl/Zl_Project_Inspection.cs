 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class Zl_Project_Inspection
   {
   public Zl_Project_Inspection()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string ZPI_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from Zl_Project_Inspection");
strSql.Append(" where ZPI_ID=@ZPI_ID ");
SqlParameter[] parameters = {
new SqlParameter("@ZPI_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = ZPI_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.Zl_Project_Inspection model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into Zl_Project_Inspection(");
strSql.Append("ZPI_ID,ZPI_Code,ZPI_Title,ZPI_STime,ZPI_Flow,ZPI_State,ZPI_Remarks,ZPI_Del,ZPI_CTime,ZPI_Creator,ZPI_MTime,ZPI_Mender,ZPI_SampleID,ZPI_SampleName,ZPI_Type ");
strSql.Append(") values (");
strSql.Append("@ZPI_ID,@ZPI_Code,@ZPI_Title,@ZPI_STime,@ZPI_Flow,@ZPI_State,@ZPI_Remarks,@ZPI_Del,@ZPI_CTime,@ZPI_Creator,@ZPI_MTime,@ZPI_Mender,@ZPI_SampleID,@ZPI_SampleName,@ZPI_Type)");
SqlParameter[] parameters = {
 new SqlParameter("@ZPI_ID", SqlDbType.VarChar,50),
 new SqlParameter("@ZPI_Code", SqlDbType.VarChar,50),
 new SqlParameter("@ZPI_Title", SqlDbType.VarChar,500),
 new SqlParameter("@ZPI_STime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPI_Flow", SqlDbType.VarChar,50),
 new SqlParameter("@ZPI_State", SqlDbType.Int,4),
 new SqlParameter("@ZPI_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@ZPI_Del", SqlDbType.Int,4),
 new SqlParameter("@ZPI_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPI_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@ZPI_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPI_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@ZPI_SampleID", SqlDbType.VarChar,50),
 new SqlParameter("@ZPI_SampleName", SqlDbType.VarChar,350),
 new SqlParameter("@ZPI_Type", SqlDbType.Int,4)};
parameters[0].Value = model.ZPI_ID;
parameters[1].Value = model.ZPI_Code;
parameters[2].Value = model.ZPI_Title;
parameters[3].Value = model.ZPI_STime;
parameters[4].Value = model.ZPI_Flow;
parameters[5].Value = model.ZPI_State;
parameters[6].Value = model.ZPI_Remarks;
parameters[7].Value = model.ZPI_Del;
parameters[8].Value = model.ZPI_CTime;
parameters[9].Value = model.ZPI_Creator;
parameters[10].Value = model.ZPI_MTime;
parameters[11].Value = model.ZPI_Mender;
parameters[12].Value = model.ZPI_SampleID;
parameters[13].Value = model.ZPI_SampleName;
parameters[14].Value = model.ZPI_Type;
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
public bool Update(KNet.Model.Zl_Project_Inspection model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update Zl_Project_Inspection set ");
strSql.Append("ZPI_Code=@ZPI_Code,");
strSql.Append("ZPI_Title=@ZPI_Title,");
strSql.Append("ZPI_STime=@ZPI_STime,");
strSql.Append("ZPI_Flow=@ZPI_Flow,");
strSql.Append("ZPI_State=@ZPI_State,");
strSql.Append("ZPI_Remarks=@ZPI_Remarks,");
strSql.Append("ZPI_Del=@ZPI_Del,");
strSql.Append("ZPI_MTime=@ZPI_MTime,");
strSql.Append("ZPI_Mender=@ZPI_Mender,");
strSql.Append("ZPI_SampleID=@ZPI_SampleID,");
strSql.Append("ZPI_SampleName=@ZPI_SampleName,");
strSql.Append("ZPI_Type=@ZPI_Type");
strSql.Append(" where ZPI_ID=@ZPI_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@ZPI_Code", SqlDbType.VarChar,50),
 new SqlParameter("@ZPI_Title", SqlDbType.VarChar,500),
 new SqlParameter("@ZPI_STime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPI_Flow", SqlDbType.VarChar,50),
 new SqlParameter("@ZPI_State", SqlDbType.Int,4),
 new SqlParameter("@ZPI_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@ZPI_Del", SqlDbType.Int,4),
 new SqlParameter("@ZPI_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPI_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@ZPI_SampleID", SqlDbType.VarChar,50),
 new SqlParameter("@ZPI_SampleName", SqlDbType.VarChar,350),
 new SqlParameter("@ZPI_Type", SqlDbType.Int,4),
new SqlParameter("@ZPI_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.ZPI_Code;
parameters[1].Value = model.ZPI_Title;
parameters[2].Value = model.ZPI_STime;
parameters[3].Value = model.ZPI_Flow;
parameters[4].Value = model.ZPI_State;
parameters[5].Value = model.ZPI_Remarks;
parameters[6].Value = model.ZPI_Del;
parameters[7].Value = model.ZPI_MTime;
parameters[8].Value = model.ZPI_Mender;
parameters[9].Value = model.ZPI_SampleID;
parameters[10].Value = model.ZPI_SampleName;
parameters[11].Value = model.ZPI_Type;
parameters[12].Value = model.ZPI_ID;

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
public bool Delete(string s_ZPI_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  Zl_Project_Inspection  ");
strSql.Append(" where ZPI_ID=@ZPI_ID ");
SqlParameter[] parameters = {
new SqlParameter("@ZPI_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_ZPI_ID;
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
public bool UpdateDel(KNet.Model.Zl_Project_Inspection model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   Zl_Project_Inspection  Set ");
strSql.Append("  ZPI_Del=@ZPI_Del ");
strSql.Append(" where ZPI_ID=@ZPI_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@ZPI_Del", SqlDbType.Int,4),
new SqlParameter("@ZPI_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.ZPI_Del;
parameters[1].Value =  model.ZPI_ID;

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
public bool DeleteList(string s_ZPI_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   Zl_Project_Inspection  ");
strSql.Append(" where ZPI_ID in ('"+s_ZPI_ID+"')");

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
  /// QueryByFID
 /// </summary>
public DataSet QueryByFID(string s_FID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from  Zl_Project_Inspection  ");
SqlParameter[] parameters = {
};

return DbHelperSQL.Query(strSql.ToString());
   }
  /// <summary>
  /// DeleteByFID
 /// </summary>
public bool DeleteByFID(string s_FID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  Zl_Project_Inspection  ");
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
public KNet.Model.Zl_Project_Inspection GetModel(string ZPI_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from Zl_Project_Inspection  ");
strSql.Append("where ZPI_ID=@ZPI_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@ZPI_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = ZPI_ID;
 KNet.Model.Zl_Project_Inspection model = new KNet.Model.Zl_Project_Inspection();
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
public KNet.Model.Zl_Project_Inspection DataRowToModel(DataRow row)
{
KNet.Model.Zl_Project_Inspection model=new KNet.Model.Zl_Project_Inspection();
if (row != null)
{
 if (row["ZPI_ID"] != null)
{
 model.ZPI_ID = row["ZPI_ID"].ToString();
}
 else
{
 model.ZPI_ID = "";
}
 if (row["ZPI_Code"] != null)
{
 model.ZPI_Code = row["ZPI_Code"].ToString();
}
 else
{
 model.ZPI_Code = "";
}
 if (row["ZPI_Title"] != null)
{
 model.ZPI_Title = row["ZPI_Title"].ToString();
}
 else
{
 model.ZPI_Title = "";
}
 if (row["ZPI_STime"] != null)
{
 model.ZPI_STime = DateTime.Parse(row["ZPI_STime"].ToString());
}
 if (row["ZPI_Flow"] != null)
{
 model.ZPI_Flow = row["ZPI_Flow"].ToString();
}
 else
{
 model.ZPI_Flow = "";
}
 if (row["ZPI_State"] != null)
{
 model.ZPI_State = int.Parse(row["ZPI_State"].ToString());
}
 else
{
 model.ZPI_State = 0;
}
 if (row["ZPI_Remarks"] != null)
{
 model.ZPI_Remarks = row["ZPI_Remarks"].ToString();
}
 else
{
 model.ZPI_Remarks = "";
}
 if (row["ZPI_Del"] != null)
{
 model.ZPI_Del = int.Parse(row["ZPI_Del"].ToString());
}
 else
{
 model.ZPI_Del = 0;
}
 if (row["ZPI_CTime"] != null)
{
 model.ZPI_CTime = DateTime.Parse(row["ZPI_CTime"].ToString());
}
 if (row["ZPI_Creator"] != null)
{
 model.ZPI_Creator = row["ZPI_Creator"].ToString();
}
 else
{
 model.ZPI_Creator = "";
}
 if (row["ZPI_MTime"] != null)
{
 model.ZPI_MTime = DateTime.Parse(row["ZPI_MTime"].ToString());
}
 if (row["ZPI_Mender"] != null)
{
 model.ZPI_Mender = row["ZPI_Mender"].ToString();
}
 else
{
 model.ZPI_Mender = "";
}
 if (row["ZPI_SampleID"] != null)
{
 model.ZPI_SampleID = row["ZPI_SampleID"].ToString();
}
 else
{
 model.ZPI_SampleID = "";
}
 if (row["ZPI_SampleName"] != null)
{
 model.ZPI_SampleName = row["ZPI_SampleName"].ToString();
}
 else
{
 model.ZPI_SampleName = "";
}
 if (row["ZPI_Type"] != null)
{
 model.ZPI_Type = int.Parse(row["ZPI_Type"].ToString());
}
 else
{
 model.ZPI_Type = 0;
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
strSql.Append(" FROM Zl_Project_Inspection ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

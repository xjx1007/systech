 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class Zl_Project_ProductsTry
   {
   public Zl_Project_ProductsTry()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string ZPP_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from Zl_Project_ProductsTry");
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
public bool Add(KNet.Model.Zl_Project_ProductsTry model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into Zl_Project_ProductsTry(");
strSql.Append("ZPP_ID,ZPP_Code,ZPP_Title,ZPP_STime,ZPP_Flow,ZPP_State,ZPP_Remarks,ZPP_Del,ZPP_CTime,ZPP_Creator,ZPP_MTime,ZPP_Mender,ZPP_SampleID,ZPP_SampleName,ZPP_Type ");
strSql.Append(") values (");
strSql.Append("@ZPP_ID,@ZPP_Code,@ZPP_Title,@ZPP_STime,@ZPP_Flow,@ZPP_State,@ZPP_Remarks,@ZPP_Del,@ZPP_CTime,@ZPP_Creator,@ZPP_MTime,@ZPP_Mender,@ZPP_SampleID,@ZPP_SampleName,@ZPP_Type)");
SqlParameter[] parameters = {
 new SqlParameter("@ZPP_ID", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_Code", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_Title", SqlDbType.VarChar,500),
 new SqlParameter("@ZPP_STime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPP_Flow", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_State", SqlDbType.Int,4),
 new SqlParameter("@ZPP_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@ZPP_Del", SqlDbType.Int,4),
 new SqlParameter("@ZPP_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPP_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPP_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_SampleID", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_SampleName", SqlDbType.VarChar,350),
 new SqlParameter("@ZPP_Type", SqlDbType.Int,4)};
parameters[0].Value = model.ZPP_ID;
parameters[1].Value = model.ZPP_Code;
parameters[2].Value = model.ZPP_Title;
parameters[3].Value = model.ZPP_STime;
parameters[4].Value = model.ZPP_Flow;
parameters[5].Value = model.ZPP_State;
parameters[6].Value = model.ZPP_Remarks;
parameters[7].Value = model.ZPP_Del;
parameters[8].Value = model.ZPP_CTime;
parameters[9].Value = model.ZPP_Creator;
parameters[10].Value = model.ZPP_MTime;
parameters[11].Value = model.ZPP_Mender;
parameters[12].Value = model.ZPP_SampleID;
parameters[13].Value = model.ZPP_SampleName;
parameters[14].Value = model.ZPP_Type;
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
public bool Update(KNet.Model.Zl_Project_ProductsTry model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update Zl_Project_ProductsTry set ");
strSql.Append("ZPP_Code=@ZPP_Code,");
strSql.Append("ZPP_Title=@ZPP_Title,");
strSql.Append("ZPP_STime=@ZPP_STime,");
strSql.Append("ZPP_Flow=@ZPP_Flow,");
strSql.Append("ZPP_State=@ZPP_State,");
strSql.Append("ZPP_Remarks=@ZPP_Remarks,");
strSql.Append("ZPP_Del=@ZPP_Del,");
strSql.Append("ZPP_MTime=@ZPP_MTime,");
strSql.Append("ZPP_Mender=@ZPP_Mender,");
strSql.Append("ZPP_SampleID=@ZPP_SampleID,");
strSql.Append("ZPP_SampleName=@ZPP_SampleName,");
strSql.Append("ZPP_Type=@ZPP_Type");
strSql.Append(" where ZPP_ID=@ZPP_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@ZPP_Code", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_Title", SqlDbType.VarChar,500),
 new SqlParameter("@ZPP_STime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPP_Flow", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_State", SqlDbType.Int,4),
 new SqlParameter("@ZPP_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@ZPP_Del", SqlDbType.Int,4),
 new SqlParameter("@ZPP_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@ZPP_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_SampleID", SqlDbType.VarChar,50),
 new SqlParameter("@ZPP_SampleName", SqlDbType.VarChar,350),
 new SqlParameter("@ZPP_Type", SqlDbType.Int,4),
new SqlParameter("@ZPP_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.ZPP_Code;
parameters[1].Value = model.ZPP_Title;
parameters[2].Value = model.ZPP_STime;
parameters[3].Value = model.ZPP_Flow;
parameters[4].Value = model.ZPP_State;
parameters[5].Value = model.ZPP_Remarks;
parameters[6].Value = model.ZPP_Del;
parameters[7].Value = model.ZPP_MTime;
parameters[8].Value = model.ZPP_Mender;
parameters[9].Value = model.ZPP_SampleID;
parameters[10].Value = model.ZPP_SampleName;
parameters[11].Value = model.ZPP_Type;
parameters[12].Value = model.ZPP_ID;

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
strSql.Append("delete from  Zl_Project_ProductsTry  ");
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
public bool UpdateDel(KNet.Model.Zl_Project_ProductsTry model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   Zl_Project_ProductsTry  Set ");
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
strSql.Append("Delete From   Zl_Project_ProductsTry  ");
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
public KNet.Model.Zl_Project_ProductsTry GetModel(string ZPP_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from Zl_Project_ProductsTry  ");
strSql.Append("where ZPP_ID=@ZPP_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@ZPP_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = ZPP_ID;
 KNet.Model.Zl_Project_ProductsTry model = new KNet.Model.Zl_Project_ProductsTry();
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
public KNet.Model.Zl_Project_ProductsTry DataRowToModel(DataRow row)
{
KNet.Model.Zl_Project_ProductsTry model=new KNet.Model.Zl_Project_ProductsTry();
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
 if (row["ZPP_Title"] != null)
{
 model.ZPP_Title = row["ZPP_Title"].ToString();
}
 else
{
 model.ZPP_Title = "";
}
 if (row["ZPP_STime"] != null)
{
 model.ZPP_STime = DateTime.Parse(row["ZPP_STime"].ToString());
}
 if (row["ZPP_Flow"] != null)
{
 model.ZPP_Flow = row["ZPP_Flow"].ToString();
}
 else
{
 model.ZPP_Flow = "";
}
 if (row["ZPP_State"] != null)
{
 model.ZPP_State = int.Parse(row["ZPP_State"].ToString());
}
 else
{
 model.ZPP_State = 0;
}
 if (row["ZPP_Remarks"] != null)
{
 model.ZPP_Remarks = row["ZPP_Remarks"].ToString();
}
 else
{
 model.ZPP_Remarks = "";
}
 if (row["ZPP_Del"] != null)
{
 model.ZPP_Del = int.Parse(row["ZPP_Del"].ToString());
}
 else
{
 model.ZPP_Del = 0;
}
 if (row["ZPP_CTime"] != null)
{
 model.ZPP_CTime = DateTime.Parse(row["ZPP_CTime"].ToString());
}
 if (row["ZPP_Creator"] != null)
{
 model.ZPP_Creator = row["ZPP_Creator"].ToString();
}
 else
{
 model.ZPP_Creator = "";
}
 if (row["ZPP_MTime"] != null)
{
 model.ZPP_MTime = DateTime.Parse(row["ZPP_MTime"].ToString());
}
 if (row["ZPP_Mender"] != null)
{
 model.ZPP_Mender = row["ZPP_Mender"].ToString();
}
 else
{
 model.ZPP_Mender = "";
}
 if (row["ZPP_SampleID"] != null)
{
 model.ZPP_SampleID = row["ZPP_SampleID"].ToString();
}
 else
{
 model.ZPP_SampleID = "";
}
 if (row["ZPP_SampleName"] != null)
{
 model.ZPP_SampleName = row["ZPP_SampleName"].ToString();
}
 else
{
 model.ZPP_SampleName = "";
}
 if (row["ZPP_Type"] != null)
{
 model.ZPP_Type = int.Parse(row["ZPP_Type"].ToString());
}
 else
{
 model.ZPP_Type = 0;
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
strSql.Append(" FROM Zl_Project_ProductsTry ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

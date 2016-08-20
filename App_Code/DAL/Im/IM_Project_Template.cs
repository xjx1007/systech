 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class IM_Project_Template
   {
   public IM_Project_Template()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string IPT_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from IM_Project_Template");
strSql.Append(" where IPT_ID=@IPT_ID ");
SqlParameter[] parameters = {
new SqlParameter("@IPT_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = IPT_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.IM_Project_Template model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into IM_Project_Template(");
strSql.Append("IPT_ID,IPT_Code,IPT_Name,IPT_Details,IPT_Creator,IPT_CTime,IPT_Mender,IPT_MTime,IPT_Del ");
strSql.Append(") values (");
strSql.Append("@IPT_ID,@IPT_Code,@IPT_Name,@IPT_Details,@IPT_Creator,@IPT_CTime,@IPT_Mender,@IPT_MTime,@IPT_Del)");
SqlParameter[] parameters = {
 new SqlParameter("@IPT_ID", SqlDbType.VarChar,50),
 new SqlParameter("@IPT_Code", SqlDbType.VarChar,50),
 new SqlParameter("@IPT_Name", SqlDbType.VarChar,250),
 new SqlParameter("@IPT_Details", SqlDbType.VarChar,350),
 new SqlParameter("@IPT_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@IPT_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@IPT_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@IPT_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@IPT_Del", SqlDbType.Int,4)};
parameters[0].Value = model.IPT_ID;
parameters[1].Value = model.IPT_Code;
parameters[2].Value = model.IPT_Name;
parameters[3].Value = model.IPT_Details;
parameters[4].Value = model.IPT_Creator;
parameters[5].Value = model.IPT_CTime;
parameters[6].Value = model.IPT_Mender;
parameters[7].Value = model.IPT_MTime;
parameters[8].Value = model.IPT_Del;
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
public bool Update(KNet.Model.IM_Project_Template model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update IM_Project_Template set ");
strSql.Append("IPT_Code=@IPT_Code,");
strSql.Append("IPT_Name=@IPT_Name,");
strSql.Append("IPT_Details=@IPT_Details,");
strSql.Append("IPT_Mender=@IPT_Mender,");
strSql.Append("IPT_MTime=@IPT_MTime,");
strSql.Append("IPT_Del=@IPT_Del");
strSql.Append(" where IPT_ID=@IPT_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@IPT_Code", SqlDbType.VarChar,50),
 new SqlParameter("@IPT_Name", SqlDbType.VarChar,250),
 new SqlParameter("@IPT_Details", SqlDbType.VarChar,350),
 new SqlParameter("@IPT_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@IPT_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@IPT_Del", SqlDbType.Int,4),
new SqlParameter("@IPT_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.IPT_Code;
parameters[1].Value = model.IPT_Name;
parameters[2].Value = model.IPT_Details;
parameters[3].Value = model.IPT_Mender;
parameters[4].Value = model.IPT_MTime;
parameters[5].Value = model.IPT_Del;
parameters[6].Value = model.IPT_ID;

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
public bool Delete(string s_IPT_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  IM_Project_Template  ");
strSql.Append(" where IPT_ID=@IPT_ID ");
SqlParameter[] parameters = {
new SqlParameter("@IPT_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_IPT_ID;
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
public bool UpdateDel(KNet.Model.IM_Project_Template model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   IM_Project_Template  Set ");
strSql.Append("  IPT_Del=@IPT_Del ");
strSql.Append(" where IPT_ID=@IPT_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@IPT_Del", SqlDbType.Int,4),
new SqlParameter("@IPT_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.IPT_Del;
parameters[1].Value =  model.IPT_ID;

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
public bool DeleteList(string s_IPT_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   IM_Project_Template  ");
strSql.Append(" where IPT_ID in ('"+s_IPT_ID+"')");

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
public KNet.Model.IM_Project_Template GetModel(string IPT_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from IM_Project_Template  ");
strSql.Append("where IPT_ID=@IPT_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@IPT_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = IPT_ID;
 KNet.Model.IM_Project_Template model = new KNet.Model.IM_Project_Template();
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
public KNet.Model.IM_Project_Template DataRowToModel(DataRow row)
{
KNet.Model.IM_Project_Template model=new KNet.Model.IM_Project_Template();
if (row != null)
{
 if (row["IPT_ID"] != null)
{
 model.IPT_ID = row["IPT_ID"].ToString();
}
 else
{
 model.IPT_ID = "";
}
 if (row["IPT_Code"] != null)
{
 model.IPT_Code = row["IPT_Code"].ToString();
}
 else
{
 model.IPT_Code = "";
}
 if (row["IPT_Name"] != null)
{
 model.IPT_Name = row["IPT_Name"].ToString();
}
 else
{
 model.IPT_Name = "";
}
 if (row["IPT_Details"] != null)
{
 model.IPT_Details = row["IPT_Details"].ToString();
}
 else
{
 model.IPT_Details = "";
}
 if (row["IPT_Creator"] != null)
{
 model.IPT_Creator = row["IPT_Creator"].ToString();
}
 else
{
 model.IPT_Creator = "";
}
 if (row["IPT_CTime"] != null)
{
 model.IPT_CTime = DateTime.Parse(row["IPT_CTime"].ToString());
}
 if (row["IPT_Mender"] != null)
{
 model.IPT_Mender = row["IPT_Mender"].ToString();
}
 else
{
 model.IPT_Mender = "";
}
 if (row["IPT_MTime"] != null)
{
 model.IPT_MTime = DateTime.Parse(row["IPT_MTime"].ToString());
}
 if (row["IPT_Del"] != null)
{
 model.IPT_Del = int.Parse(row["IPT_Del"].ToString());
}
 else
{
 model.IPT_Del = 0;
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
strSql.Append(" FROM IM_Project_Template ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

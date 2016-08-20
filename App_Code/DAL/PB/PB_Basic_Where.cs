 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class PB_Basic_Where
   {
   public PB_Basic_Where()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string PBW_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from PB_Basic_Where");
strSql.Append(" where PBW_ID=@PBW_ID ");
SqlParameter[] parameters = {
new SqlParameter("@PBW_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = PBW_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.PB_Basic_Where model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into PB_Basic_Where(");
strSql.Append("PBW_ID,PBW_Name,PBW_Table,PBW_Sql,PBW_Type,PBW_Del,PBW_Order,PBW_Cloumn,PBW_FromTable,PBW_FromValue,PBW_FromName,PBW_InputType,PBW_FromWhere,PBW_CTime,PBW_Creator,PBW_MTime,PBW_Mender ");
strSql.Append(") values (");
strSql.Append("@PBW_ID,@PBW_Name,@PBW_Table,@PBW_Sql,@PBW_Type,@PBW_Del,@PBW_Order,@PBW_Cloumn,@PBW_FromTable,@PBW_FromValue,@PBW_FromName,@PBW_InputType,@PBW_FromWhere,@PBW_CTime,@PBW_Creator,@PBW_MTime,@PBW_Mender)");
SqlParameter[] parameters = {
 new SqlParameter("@PBW_ID", SqlDbType.VarChar,50),
 new SqlParameter("@PBW_Name", SqlDbType.VarChar,50),
 new SqlParameter("@PBW_Table", SqlDbType.VarChar,50),
 new SqlParameter("@PBW_Sql", SqlDbType.VarChar,550),
 new SqlParameter("@PBW_Type", SqlDbType.VarChar,50),
 new SqlParameter("@PBW_Del", SqlDbType.Int,4),
 new SqlParameter("@PBW_Order", SqlDbType.Int,4),
 new SqlParameter("@PBW_Cloumn", SqlDbType.VarChar,150),
 new SqlParameter("@PBW_FromTable", SqlDbType.VarChar,150),
 new SqlParameter("@PBW_FromValue", SqlDbType.VarChar,150),
 new SqlParameter("@PBW_FromName", SqlDbType.VarChar,150),
 new SqlParameter("@PBW_InputType", SqlDbType.VarChar,150),
 new SqlParameter("@PBW_FromWhere", SqlDbType.VarChar,150),
 new SqlParameter("@PBW_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@PBW_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@PBW_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@PBW_Mender", SqlDbType.VarChar,50)};
parameters[0].Value = model.PBW_ID;
parameters[1].Value = model.PBW_Name;
parameters[2].Value = model.PBW_Table;
parameters[3].Value = model.PBW_Sql;
parameters[4].Value = model.PBW_Type;
parameters[5].Value = model.PBW_Del;
parameters[6].Value = model.PBW_Order;
parameters[7].Value = model.PBW_Cloumn;
parameters[8].Value = model.PBW_FromTable;
parameters[9].Value = model.PBW_FromValue;
parameters[10].Value = model.PBW_FromName;
parameters[11].Value = model.PBW_InputType;
parameters[12].Value = model.PBW_FromWhere;
parameters[13].Value = model.PBW_CTime;
parameters[14].Value = model.PBW_Creator;
parameters[15].Value = model.PBW_MTime;
parameters[16].Value = model.PBW_Mender;
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
public bool Update(KNet.Model.PB_Basic_Where model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update PB_Basic_Where set ");
strSql.Append("PBW_Name=@PBW_Name,");
strSql.Append("PBW_Table=@PBW_Table,");
strSql.Append("PBW_Sql=@PBW_Sql,");
strSql.Append("PBW_Type=@PBW_Type,");
strSql.Append("PBW_Del=@PBW_Del,");
strSql.Append("PBW_Order=@PBW_Order,");
strSql.Append("PBW_Cloumn=@PBW_Cloumn,");
strSql.Append("PBW_FromTable=@PBW_FromTable,");
strSql.Append("PBW_FromValue=@PBW_FromValue,");
strSql.Append("PBW_FromName=@PBW_FromName,");
strSql.Append("PBW_InputType=@PBW_InputType,");
strSql.Append("PBW_FromWhere=@PBW_FromWhere,");
strSql.Append("PBW_MTime=@PBW_MTime,");
strSql.Append("PBW_Mender=@PBW_Mender");
strSql.Append(" where PBW_ID=@PBW_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@PBW_Name", SqlDbType.VarChar,50),
 new SqlParameter("@PBW_Table", SqlDbType.VarChar,50),
 new SqlParameter("@PBW_Sql", SqlDbType.VarChar,550),
 new SqlParameter("@PBW_Type", SqlDbType.VarChar,50),
 new SqlParameter("@PBW_Del", SqlDbType.Int,4),
 new SqlParameter("@PBW_Order", SqlDbType.Int,4),
 new SqlParameter("@PBW_Cloumn", SqlDbType.VarChar,150),
 new SqlParameter("@PBW_FromTable", SqlDbType.VarChar,150),
 new SqlParameter("@PBW_FromValue", SqlDbType.VarChar,150),
 new SqlParameter("@PBW_FromName", SqlDbType.VarChar,150),
 new SqlParameter("@PBW_InputType", SqlDbType.VarChar,150),
 new SqlParameter("@PBW_FromWhere", SqlDbType.VarChar,150),
 new SqlParameter("@PBW_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@PBW_Mender", SqlDbType.VarChar,50),
new SqlParameter("@PBW_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.PBW_Name;
parameters[1].Value = model.PBW_Table;
parameters[2].Value = model.PBW_Sql;
parameters[3].Value = model.PBW_Type;
parameters[4].Value = model.PBW_Del;
parameters[5].Value = model.PBW_Order;
parameters[6].Value = model.PBW_Cloumn;
parameters[7].Value = model.PBW_FromTable;
parameters[8].Value = model.PBW_FromValue;
parameters[9].Value = model.PBW_FromName;
parameters[10].Value = model.PBW_InputType;
parameters[11].Value = model.PBW_FromWhere;
parameters[12].Value = model.PBW_MTime;
parameters[13].Value = model.PBW_Mender;
parameters[14].Value = model.PBW_ID;

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
public bool Delete(string s_PBW_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  PB_Basic_Where  ");
strSql.Append(" where PBW_ID=@PBW_ID ");
SqlParameter[] parameters = {
new SqlParameter("@PBW_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_PBW_ID;
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
public bool UpdateDel(KNet.Model.PB_Basic_Where model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   PB_Basic_Where  Set ");
strSql.Append("  PBW_Del=@PBW_Del ");
strSql.Append(" where PBW_ID=@PBW_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@PBW_Del", SqlDbType.Int,4),
new SqlParameter("@PBW_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.PBW_Del;
parameters[1].Value =  model.PBW_ID;

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
public bool DeleteList(string s_PBW_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   PB_Basic_Where  ");
strSql.Append(" where PBW_ID in ('"+s_PBW_ID+"')");

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
public KNet.Model.PB_Basic_Where GetModel(string PBW_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from PB_Basic_Where  ");
strSql.Append("where PBW_ID=@PBW_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@PBW_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = PBW_ID;
 KNet.Model.PB_Basic_Where model = new KNet.Model.PB_Basic_Where();
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
public KNet.Model.PB_Basic_Where DataRowToModel(DataRow row)
{
KNet.Model.PB_Basic_Where model=new KNet.Model.PB_Basic_Where();
if (row != null)
{
 if (row["PBW_ID"] != null)
{
 model.PBW_ID = row["PBW_ID"].ToString();
}
 else
{
 model.PBW_ID = "";
}
 if (row["PBW_Name"] != null)
{
 model.PBW_Name = row["PBW_Name"].ToString();
}
 else
{
 model.PBW_Name = "";
}
 if (row["PBW_Table"] != null)
{
 model.PBW_Table = row["PBW_Table"].ToString();
}
 else
{
 model.PBW_Table = "";
}
 if (row["PBW_Sql"] != null)
{
 model.PBW_Sql = row["PBW_Sql"].ToString();
}
 else
{
 model.PBW_Sql = "";
}
 if (row["PBW_Type"] != null)
{
 model.PBW_Type = row["PBW_Type"].ToString();
}
 else
{
 model.PBW_Type = "";
}
 if (row["PBW_Del"] != null)
{
 model.PBW_Del = int.Parse(row["PBW_Del"].ToString());
}
 else
{
 model.PBW_Del = 0;
}
 if (row["PBW_Order"] != null)
{
 model.PBW_Order = int.Parse(row["PBW_Order"].ToString());
}
 else
{
 model.PBW_Order = 0;
}
 if (row["PBW_Cloumn"] != null)
{
 model.PBW_Cloumn = row["PBW_Cloumn"].ToString();
}
 else
{
 model.PBW_Cloumn = "";
}
 if (row["PBW_FromTable"] != null)
{
 model.PBW_FromTable = row["PBW_FromTable"].ToString();
}
 else
{
 model.PBW_FromTable = "";
}
 if (row["PBW_FromValue"] != null)
{
 model.PBW_FromValue = row["PBW_FromValue"].ToString();
}
 else
{
 model.PBW_FromValue = "";
}
 if (row["PBW_FromName"] != null)
{
 model.PBW_FromName = row["PBW_FromName"].ToString();
}
 else
{
 model.PBW_FromName = "";
}
 if (row["PBW_InputType"] != null)
{
 model.PBW_InputType = row["PBW_InputType"].ToString();
}
 else
{
 model.PBW_InputType = "";
}
 if (row["PBW_FromWhere"] != null)
{
 model.PBW_FromWhere = row["PBW_FromWhere"].ToString();
}
 else
{
 model.PBW_FromWhere = "";
}
 if (row["PBW_CTime"] != null)
{
 model.PBW_CTime = DateTime.Parse(row["PBW_CTime"].ToString());
}
 if (row["PBW_Creator"] != null)
{
 model.PBW_Creator = row["PBW_Creator"].ToString();
}
 else
{
 model.PBW_Creator = "";
}
 if (row["PBW_MTime"] != null)
{
 model.PBW_MTime = DateTime.Parse(row["PBW_MTime"].ToString());
}
 if (row["PBW_Mender"] != null)
{
 model.PBW_Mender = row["PBW_Mender"].ToString();
}
 else
{
 model.PBW_Mender = "";
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
strSql.Append(" FROM PB_Basic_Where ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class Cw_Bill_Details
   {
   public Cw_Bill_Details()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string CBD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from Cw_Bill_Details");
strSql.Append(" where CBD_ID=@CBD_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CBD_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = CBD_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.Cw_Bill_Details model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into Cw_Bill_Details(");
strSql.Append("CBD_ID,CBD_FID,CBD_ReCeID,CBD_BeginTime,CBD_EndTime,CBD_Money,CBD_BillCode,CBD_Details,CBD_From,CBD_CTime,CBD_Creator,CBD_Type ");
strSql.Append(") values (");
strSql.Append("@CBD_ID,@CBD_FID,@CBD_ReCeID,@CBD_BeginTime,@CBD_EndTime,@CBD_Money,@CBD_BillCode,@CBD_Details,@CBD_From,@CBD_CTime,@CBD_Creator,@CBD_Type)");
SqlParameter[] parameters = {
 new SqlParameter("@CBD_ID", SqlDbType.VarChar,50),
 new SqlParameter("@CBD_FID", SqlDbType.VarChar,50),
 new SqlParameter("@CBD_ReCeID", SqlDbType.VarChar,50),
 new SqlParameter("@CBD_BeginTime", SqlDbType.DateTime,8),
 new SqlParameter("@CBD_EndTime", SqlDbType.DateTime,8),
 new SqlParameter("@CBD_Money", SqlDbType.Decimal,9),
 new SqlParameter("@CBD_BillCode", SqlDbType.VarChar,350),
 new SqlParameter("@CBD_Details", SqlDbType.VarChar,500),
 new SqlParameter("@CBD_From", SqlDbType.VarChar,500),
 new SqlParameter("@CBD_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@CBD_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@CBD_Type", SqlDbType.Int,4)};
parameters[0].Value = model.CBD_ID;
parameters[1].Value = model.CBD_FID;
parameters[2].Value = model.CBD_ReCeID;
parameters[3].Value = model.CBD_BeginTime;
parameters[4].Value = model.CBD_EndTime;
parameters[5].Value = model.CBD_Money;
parameters[6].Value = model.CBD_BillCode;
parameters[7].Value = model.CBD_Details;
parameters[8].Value = model.CBD_From;
parameters[9].Value = model.CBD_CTime;
parameters[10].Value = model.CBD_Creator;
parameters[11].Value = model.CBD_Type;
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
public bool Update(KNet.Model.Cw_Bill_Details model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update Cw_Bill_Details set ");
strSql.Append("CBD_FID=@CBD_FID,");
strSql.Append("CBD_ReCeID=@CBD_ReCeID,");
strSql.Append("CBD_BeginTime=@CBD_BeginTime,");
strSql.Append("CBD_EndTime=@CBD_EndTime,");
strSql.Append("CBD_Money=@CBD_Money,");
strSql.Append("CBD_BillCode=@CBD_BillCode,");
strSql.Append("CBD_Details=@CBD_Details,");
strSql.Append("CBD_From=@CBD_From,");
strSql.Append("CBD_Type=@CBD_Type");
strSql.Append(" where CBD_ID=@CBD_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@CBD_FID", SqlDbType.VarChar,50),
 new SqlParameter("@CBD_ReCeID", SqlDbType.VarChar,50),
 new SqlParameter("@CBD_BeginTime", SqlDbType.DateTime,8),
 new SqlParameter("@CBD_EndTime", SqlDbType.DateTime,8),
 new SqlParameter("@CBD_Money", SqlDbType.Decimal,9),
 new SqlParameter("@CBD_BillCode", SqlDbType.VarChar,350),
 new SqlParameter("@CBD_Details", SqlDbType.VarChar,500),
 new SqlParameter("@CBD_From", SqlDbType.VarChar,500),
 new SqlParameter("@CBD_Type", SqlDbType.Int,4),
new SqlParameter("@CBD_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.CBD_FID;
parameters[1].Value = model.CBD_ReCeID;
parameters[2].Value = model.CBD_BeginTime;
parameters[3].Value = model.CBD_EndTime;
parameters[4].Value = model.CBD_Money;
parameters[5].Value = model.CBD_BillCode;
parameters[6].Value = model.CBD_Details;
parameters[7].Value = model.CBD_From;
parameters[8].Value = model.CBD_Type;
parameters[9].Value = model.CBD_ID;

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
public bool Delete(string s_CBD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  Cw_Bill_Details  ");
strSql.Append(" where CBD_ID=@CBD_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CBD_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_CBD_ID;
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
public bool UpdateDel(KNet.Model.Cw_Bill_Details model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   Cw_Bill_Details  Set ");
strSql.Append(" where CBD_ID=@CBD_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CBD_ID", SqlDbType.VarChar,50)};
parameters[0].Value =  model.CBD_ID;

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
public bool DeleteList(string s_CBD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   Cw_Bill_Details  ");
strSql.Append(" where CBD_ID in ('"+s_CBD_ID+"')");

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
strSql.Append("delete from  Cw_Bill_Details  ");
strSql.Append(" Where  CBD_FID=@CBD_FID ");
SqlParameter[] parameters = {
 new SqlParameter("@CBD_FID", SqlDbType.VarChar,50),
};
parameters[0].Value = s_FID;

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
public KNet.Model.Cw_Bill_Details GetModel(string CBD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from Cw_Bill_Details  ");
strSql.Append("where CBD_ID=@CBD_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@CBD_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = CBD_ID;
 KNet.Model.Cw_Bill_Details model = new KNet.Model.Cw_Bill_Details();
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
public KNet.Model.Cw_Bill_Details DataRowToModel(DataRow row)
{
KNet.Model.Cw_Bill_Details model=new KNet.Model.Cw_Bill_Details();
if (row != null)
{
 if (row["CBD_ID"] != null)
{
 model.CBD_ID = row["CBD_ID"].ToString();
}
 else
{
 model.CBD_ID = "";
}
 if (row["CBD_FID"] != null)
{
 model.CBD_FID = row["CBD_FID"].ToString();
}
 else
{
 model.CBD_FID = "";
}
 if (row["CBD_ReCeID"] != null)
{
 model.CBD_ReCeID = row["CBD_ReCeID"].ToString();
}
 else
{
 model.CBD_ReCeID = "";
}
 if (row["CBD_BeginTime"] != null)
{
 model.CBD_BeginTime = DateTime.Parse(row["CBD_BeginTime"].ToString());
}
 if (row["CBD_EndTime"] != null)
{
 model.CBD_EndTime = DateTime.Parse(row["CBD_EndTime"].ToString());
}
 if (row["CBD_Money"] != null)
{
 model.CBD_Money = Decimal.Parse(row["CBD_Money"].ToString());
}
 else
{
 model.CBD_Money = 0;
}
 if (row["CBD_BillCode"] != null)
{
 model.CBD_BillCode = row["CBD_BillCode"].ToString();
}
 else
{
 model.CBD_BillCode = "";
}
 if (row["CBD_Details"] != null)
{
 model.CBD_Details = row["CBD_Details"].ToString();
}
 else
{
 model.CBD_Details = "";
}
 if (row["CBD_From"] != null)
{
 model.CBD_From = row["CBD_From"].ToString();
}
 else
{
 model.CBD_From = "";
}
 if (row["CBD_CTime"] != null)
{
 model.CBD_CTime = DateTime.Parse(row["CBD_CTime"].ToString());
}
 if (row["CBD_Creator"] != null)
{
 model.CBD_Creator = row["CBD_Creator"].ToString();
}
 else
{
 model.CBD_Creator = "";
}
 if (row["CBD_Type"] != null)
{
 model.CBD_Type = int.Parse(row["CBD_Type"].ToString());
}
 else
{
 model.CBD_Type = 0;
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
strSql.Append(" FROM Cw_Bill_Details ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

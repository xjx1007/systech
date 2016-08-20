 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class Cw_Bill_Expense_Details
   {
   public Cw_Bill_Expense_Details()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string CBED_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from Cw_Bill_Expense_Details");
strSql.Append(" where CBED_ID=@CBED_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CBED_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = CBED_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.Cw_Bill_Expense_Details model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into Cw_Bill_Expense_Details(");
strSql.Append("CBED_ID,CBED_FID,CBED_Used,CBED_Place,CBED_StartTime,CBED_EndTime,CBED_Money,CBED_Type,CBED_Remarks ");
strSql.Append(") values (");
strSql.Append("@CBED_ID,@CBED_FID,@CBED_Used,@CBED_Place,@CBED_StartTime,@CBED_EndTime,@CBED_Money,@CBED_Type,@CBED_Remarks)");
SqlParameter[] parameters = {
 new SqlParameter("@CBED_ID", SqlDbType.VarChar,50),
 new SqlParameter("@CBED_FID", SqlDbType.VarChar,50),
 new SqlParameter("@CBED_Used", SqlDbType.VarChar,150),
 new SqlParameter("@CBED_Place", SqlDbType.VarChar,50),
 new SqlParameter("@CBED_StartTime", SqlDbType.DateTime,8),
 new SqlParameter("@CBED_EndTime", SqlDbType.DateTime,8),
 new SqlParameter("@CBED_Money", SqlDbType.Decimal,9),
 new SqlParameter("@CBED_Type", SqlDbType.VarChar,16),
 new SqlParameter("@CBED_Remarks", SqlDbType.VarChar,50)};
parameters[0].Value = model.CBED_ID;
parameters[1].Value = model.CBED_FID;
parameters[2].Value = model.CBED_Used;
parameters[3].Value = model.CBED_Place;
parameters[4].Value = model.CBED_StartTime;
parameters[5].Value = model.CBED_EndTime;
parameters[6].Value = model.CBED_Money;
parameters[7].Value = model.CBED_Type;
parameters[8].Value = model.CBED_Remarks;
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
public bool Update(KNet.Model.Cw_Bill_Expense_Details model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update Cw_Bill_Expense_Details set ");
strSql.Append("CBED_FID=@CBED_FID,");
strSql.Append("CBED_Used=@CBED_Used,");
strSql.Append("CBED_Place=@CBED_Place,");
strSql.Append("CBED_StartTime=@CBED_StartTime,");
strSql.Append("CBED_EndTime=@CBED_EndTime,");
strSql.Append("CBED_Money=@CBED_Money,");
strSql.Append("CBED_Type=@CBED_Type,");
strSql.Append("CBED_Remarks=@CBED_Remarks");
strSql.Append(" where CBED_ID=@CBED_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@CBED_FID", SqlDbType.VarChar,50),
 new SqlParameter("@CBED_Used", SqlDbType.VarChar,150),
 new SqlParameter("@CBED_Place", SqlDbType.VarChar,50),
 new SqlParameter("@CBED_StartTime", SqlDbType.DateTime,8),
 new SqlParameter("@CBED_EndTime", SqlDbType.DateTime,8),
 new SqlParameter("@CBED_Money", SqlDbType.Decimal,9),
 new SqlParameter("@CBED_Type", SqlDbType.VarChar,16),
 new SqlParameter("@CBED_Remarks", SqlDbType.VarChar,50),
new SqlParameter("@CBED_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.CBED_FID;
parameters[1].Value = model.CBED_Used;
parameters[2].Value = model.CBED_Place;
parameters[3].Value = model.CBED_StartTime;
parameters[4].Value = model.CBED_EndTime;
parameters[5].Value = model.CBED_Money;
parameters[6].Value = model.CBED_Type;
parameters[7].Value = model.CBED_Remarks;
parameters[8].Value = model.CBED_ID;

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
public bool Delete(string s_CBED_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  Cw_Bill_Expense_Details  ");
strSql.Append(" where CBED_ID=@CBED_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CBED_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_CBED_ID;
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
public bool UpdateDel(KNet.Model.Cw_Bill_Expense_Details model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   Cw_Bill_Expense_Details  Set ");
strSql.Append(" where CBED_ID=@CBED_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CBED_ID", SqlDbType.VarChar,50)};
parameters[0].Value =  model.CBED_ID;

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
public bool DeleteList(string s_CBED_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   Cw_Bill_Expense_Details  ");
strSql.Append(" where CBED_ID in ('"+s_CBED_ID+"')");

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
strSql.Append("Select * from  Cw_Bill_Expense_Details  ");
strSql.Append(" Where  CBED_FID=@CBED_FID ");
SqlParameter[] parameters = {
 new SqlParameter("@CBED_FID", SqlDbType.VarChar,50),
};
parameters[0].Value = s_FID;

return DbHelperSQL.Query(strSql.ToString());
   }
  /// <summary>
  /// DeleteByFID
 /// </summary>
public bool DeleteByFID(string s_FID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  Cw_Bill_Expense_Details  ");
strSql.Append(" Where  CBED_FID=@CBED_FID ");
SqlParameter[] parameters = {
 new SqlParameter("@CBED_FID", SqlDbType.VarChar,50),
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
public KNet.Model.Cw_Bill_Expense_Details GetModel(string CBED_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from Cw_Bill_Expense_Details  ");
strSql.Append("where CBED_ID=@CBED_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@CBED_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = CBED_ID;
 KNet.Model.Cw_Bill_Expense_Details model = new KNet.Model.Cw_Bill_Expense_Details();
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
public KNet.Model.Cw_Bill_Expense_Details DataRowToModel(DataRow row)
{
KNet.Model.Cw_Bill_Expense_Details model=new KNet.Model.Cw_Bill_Expense_Details();
if (row != null)
{
 if (row["CBED_ID"] != null)
{
 model.CBED_ID = row["CBED_ID"].ToString();
}
 else
{
 model.CBED_ID = "";
}
 if (row["CBED_FID"] != null)
{
 model.CBED_FID = row["CBED_FID"].ToString();
}
 else
{
 model.CBED_FID = "";
}
 if (row["CBED_Used"] != null)
{
 model.CBED_Used = row["CBED_Used"].ToString();
}
 else
{
 model.CBED_Used = "";
}
 if (row["CBED_Place"] != null)
{
 model.CBED_Place = row["CBED_Place"].ToString();
}
 else
{
 model.CBED_Place = "";
}
 if (row["CBED_StartTime"] != null)
{
 model.CBED_StartTime = DateTime.Parse(row["CBED_StartTime"].ToString());
}
 if (row["CBED_EndTime"] != null)
{
 model.CBED_EndTime = DateTime.Parse(row["CBED_EndTime"].ToString());
}
 if (row["CBED_Money"] != null)
{
 model.CBED_Money = Decimal.Parse(row["CBED_Money"].ToString());
}
 else
{
 model.CBED_Money = 0;
}
 if (row["CBED_Type"] != null)
{
 model.CBED_Type = row["CBED_Type"].ToString();
}
 else
{
 model.CBED_Type = "";
}
 if (row["CBED_Remarks"] != null)
{
 model.CBED_Remarks = row["CBED_Remarks"].ToString();
}
 else
{
 model.CBED_Remarks = "";
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
strSql.Append(" FROM Cw_Bill_Expense_Details ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

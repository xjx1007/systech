 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class Wl_Customer_Price
   {
   public Wl_Customer_Price()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string WCP_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from Wl_Customer_Price");
strSql.Append(" where WCP_ID=@WCP_ID ");
SqlParameter[] parameters = {
new SqlParameter("@WCP_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = WCP_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.Wl_Customer_Price model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into Wl_Customer_Price(");
strSql.Append("WCP_ID,WCP_Code,WCP_SuppNo,WCP_WuliuSuppNo,WCP_STime,WCP_CustomerValue,WCP_LinkMan,WCP_Address,WCP_DutyPerson,WCP_Remarks,WCP_CheckYN,WCP_Del,WCP_CTime,WCP_Creator,WCP_MTime,WCP_Mender,WCP_Days ");
strSql.Append(") values (");
strSql.Append("@WCP_ID,@WCP_Code,@WCP_SuppNo,@WCP_WuliuSuppNo,@WCP_STime,@WCP_CustomerValue,@WCP_LinkMan,@WCP_Address,@WCP_DutyPerson,@WCP_Remarks,@WCP_CheckYN,@WCP_Del,@WCP_CTime,@WCP_Creator,@WCP_MTime,@WCP_Mender,@WCP_Days)");
SqlParameter[] parameters = {
 new SqlParameter("@WCP_ID", SqlDbType.VarChar,50),
 new SqlParameter("@WCP_Code", SqlDbType.VarChar,50),
 new SqlParameter("@WCP_SuppNo", SqlDbType.VarChar,50),
 new SqlParameter("@WCP_WuliuSuppNo", SqlDbType.VarChar,50),
 new SqlParameter("@WCP_STime", SqlDbType.DateTime,8),
 new SqlParameter("@WCP_CustomerValue", SqlDbType.VarChar,50),
 new SqlParameter("@WCP_LinkMan", SqlDbType.VarChar,50),
 new SqlParameter("@WCP_Address", SqlDbType.VarChar,500),
 new SqlParameter("@WCP_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@WCP_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@WCP_CheckYN", SqlDbType.Int,4),
 new SqlParameter("@WCP_Del", SqlDbType.Int,4),
 new SqlParameter("@WCP_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@WCP_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@WCP_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@WCP_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@WCP_Days", SqlDbType.Decimal,18)
                            };
parameters[0].Value = model.WCP_ID;
parameters[1].Value = model.WCP_Code;
parameters[2].Value = model.WCP_SuppNo;
parameters[3].Value = model.WCP_WuliuSuppNo;
parameters[4].Value = model.WCP_STime;
parameters[5].Value = model.WCP_CustomerValue;
parameters[6].Value = model.WCP_LinkMan;
parameters[7].Value = model.WCP_Address;
parameters[8].Value = model.WCP_DutyPerson;
parameters[9].Value = model.WCP_Remarks;
parameters[10].Value = model.WCP_CheckYN;
parameters[11].Value = model.WCP_Del;
parameters[12].Value = model.WCP_CTime;
parameters[13].Value = model.WCP_Creator;
parameters[14].Value = model.WCP_MTime;
parameters[15].Value = model.WCP_Mender;
parameters[16].Value = model.WCP_Days;
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
public bool Update(KNet.Model.Wl_Customer_Price model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update Wl_Customer_Price set ");
strSql.Append("WCP_Code=@WCP_Code,");
strSql.Append("WCP_SuppNo=@WCP_SuppNo,");
strSql.Append("WCP_WuliuSuppNo=@WCP_WuliuSuppNo,");
strSql.Append("WCP_STime=@WCP_STime,");
strSql.Append("WCP_CustomerValue=@WCP_CustomerValue,");
strSql.Append("WCP_LinkMan=@WCP_LinkMan,");
strSql.Append("WCP_Address=@WCP_Address,");
strSql.Append("WCP_DutyPerson=@WCP_DutyPerson,");
strSql.Append("WCP_Remarks=@WCP_Remarks,");
strSql.Append("WCP_CheckYN=@WCP_CheckYN,");
strSql.Append("WCP_Del=@WCP_Del,");
strSql.Append("WCP_MTime=@WCP_MTime,");
strSql.Append("WCP_Mender=@WCP_Mender,");
strSql.Append("WCP_Days=@WCP_Days");
strSql.Append(" where WCP_ID=@WCP_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@WCP_Code", SqlDbType.VarChar,50),
 new SqlParameter("@WCP_SuppNo", SqlDbType.VarChar,50),
 new SqlParameter("@WCP_WuliuSuppNo", SqlDbType.VarChar,50),
 new SqlParameter("@WCP_STime", SqlDbType.DateTime,8),
 new SqlParameter("@WCP_CustomerValue", SqlDbType.VarChar,50),
 new SqlParameter("@WCP_LinkMan", SqlDbType.VarChar,50),
 new SqlParameter("@WCP_Address", SqlDbType.VarChar,500),
 new SqlParameter("@WCP_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@WCP_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@WCP_CheckYN", SqlDbType.Int,4),
 new SqlParameter("@WCP_Del", SqlDbType.Int,4),
 new SqlParameter("@WCP_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@WCP_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@WCP_Days", SqlDbType.Decimal,18),
 
new SqlParameter("@WCP_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.WCP_Code;
parameters[1].Value = model.WCP_SuppNo;
parameters[2].Value = model.WCP_WuliuSuppNo;
parameters[3].Value = model.WCP_STime;
parameters[4].Value = model.WCP_CustomerValue;
parameters[5].Value = model.WCP_LinkMan;
parameters[6].Value = model.WCP_Address;
parameters[7].Value = model.WCP_DutyPerson;
parameters[8].Value = model.WCP_Remarks;
parameters[9].Value = model.WCP_CheckYN;
parameters[10].Value = model.WCP_Del;
parameters[11].Value = model.WCP_MTime;
parameters[12].Value = model.WCP_Mender;
parameters[13].Value = model.WCP_Days;
parameters[14].Value = model.WCP_ID;

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
public bool Delete(string s_WCP_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  Wl_Customer_Price  ");
strSql.Append(" where WCP_ID=@WCP_ID ");
SqlParameter[] parameters = {
new SqlParameter("@WCP_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_WCP_ID;
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
public bool UpdateDel(KNet.Model.Wl_Customer_Price model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   Wl_Customer_Price  Set ");
strSql.Append("  WCP_Del=@WCP_Del ");
strSql.Append(" where WCP_ID=@WCP_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@WCP_Del", SqlDbType.Int,4),
new SqlParameter("@WCP_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.WCP_Del;
parameters[1].Value =  model.WCP_ID;

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
public bool DeleteList(string s_WCP_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   Wl_Customer_Price  ");
strSql.Append(" where WCP_ID in ('"+s_WCP_ID+"')");

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
public KNet.Model.Wl_Customer_Price GetModel(string WCP_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from Wl_Customer_Price  ");
strSql.Append("where WCP_ID=@WCP_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@WCP_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = WCP_ID;
 KNet.Model.Wl_Customer_Price model = new KNet.Model.Wl_Customer_Price();
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
public KNet.Model.Wl_Customer_Price DataRowToModel(DataRow row)
{
KNet.Model.Wl_Customer_Price model=new KNet.Model.Wl_Customer_Price();
if (row != null)
{
 if (row["WCP_ID"] != null)
{
 model.WCP_ID = row["WCP_ID"].ToString();
}
 else
{
 model.WCP_ID = "";
}
 if (row["WCP_Code"] != null)
{
 model.WCP_Code = row["WCP_Code"].ToString();
}
 else
{
 model.WCP_Code = "";
}
 if (row["WCP_SuppNo"] != null)
{
 model.WCP_SuppNo = row["WCP_SuppNo"].ToString();
}
 else
{
 model.WCP_SuppNo = "";
}
 if (row["WCP_WuliuSuppNo"] != null)
{
 model.WCP_WuliuSuppNo = row["WCP_WuliuSuppNo"].ToString();
}
 else
{
 model.WCP_WuliuSuppNo = "";
}
 if (row["WCP_STime"] != null)
{
 model.WCP_STime = DateTime.Parse(row["WCP_STime"].ToString());
}
 if (row["WCP_CustomerValue"] != null)
{
 model.WCP_CustomerValue = row["WCP_CustomerValue"].ToString();
}
 else
{
 model.WCP_CustomerValue = "";
}
 if (row["WCP_LinkMan"] != null)
{
 model.WCP_LinkMan = row["WCP_LinkMan"].ToString();
}
 else
{
 model.WCP_LinkMan = "";
}
 if (row["WCP_Address"] != null)
{
 model.WCP_Address = row["WCP_Address"].ToString();
}
 else
{
 model.WCP_Address = "";
}
 if (row["WCP_DutyPerson"] != null)
{
 model.WCP_DutyPerson = row["WCP_DutyPerson"].ToString();
}
 else
{
 model.WCP_DutyPerson = "";
}
 if (row["WCP_Remarks"] != null)
{
 model.WCP_Remarks = row["WCP_Remarks"].ToString();
}
 else
{
 model.WCP_Remarks = "";
}
 if (row["WCP_CheckYN"] != null)
{
 model.WCP_CheckYN = int.Parse(row["WCP_CheckYN"].ToString());
}
 else
{
 model.WCP_CheckYN = 0;
}
 if (row["WCP_Del"] != null)
{
 model.WCP_Del = int.Parse(row["WCP_Del"].ToString());
}
 else
{
 model.WCP_Del = 0;
}
 if (row["WCP_CTime"] != null)
{
 model.WCP_CTime = DateTime.Parse(row["WCP_CTime"].ToString());
}
 if (row["WCP_Creator"] != null)
{
 model.WCP_Creator = row["WCP_Creator"].ToString();
}
 else
{
 model.WCP_Creator = "";
}
 if (row["WCP_MTime"] != null)
{
 model.WCP_MTime = DateTime.Parse(row["WCP_MTime"].ToString());
}
 if (row["WCP_Mender"] != null)
{
 model.WCP_Mender = row["WCP_Mender"].ToString();
}
 else
{
 model.WCP_Mender = "";
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
strSql.Append(" FROM Wl_Customer_Price ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

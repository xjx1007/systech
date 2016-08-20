 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class CG_Account_Bill_Outimes
   {
   public CG_Account_Bill_Outimes()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string CABO_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from CG_Account_Bill_Outimes");
strSql.Append(" where CABO_ID=@CABO_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CABO_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = CABO_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.CG_Account_Bill_Outimes model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into CG_Account_Bill_Outimes(");
strSql.Append("CABO_ID,CABO_FID,CABO_OutTime,CABO_Days,CABO_Money,CABO_Remarks ");
strSql.Append(") values (");
strSql.Append("@CABO_ID,@CABO_FID,@CABO_OutTime,@CABO_Days,@CABO_Money,@CABO_Remarks)");
SqlParameter[] parameters = {
 new SqlParameter("@CABO_ID", SqlDbType.VarChar,50),
 new SqlParameter("@CABO_FID", SqlDbType.VarChar,50),
 new SqlParameter("@CABO_OutTime", SqlDbType.DateTime,8),
 new SqlParameter("@CABO_Days", SqlDbType.Int,4),
 new SqlParameter("@CABO_Money", SqlDbType.Decimal,9),
 new SqlParameter("@CABO_Remarks", SqlDbType.VarChar,50)};
parameters[0].Value = model.CABO_ID;
parameters[1].Value = model.CABO_FID;
parameters[2].Value = model.CABO_OutTime;
parameters[3].Value = model.CABO_Days;
parameters[4].Value = model.CABO_Money;
parameters[5].Value = model.CABO_Remarks;
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
public bool Update(KNet.Model.CG_Account_Bill_Outimes model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update CG_Account_Bill_Outimes set ");
strSql.Append("CABO_FID=@CABO_FID,");
strSql.Append("CABO_OutTime=@CABO_OutTime,");
strSql.Append("CABO_Days=@CABO_Days,");
strSql.Append("CABO_Money=@CABO_Money,");
strSql.Append("CABO_Remarks=@CABO_Remarks");
strSql.Append(" where CABO_ID=@CABO_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@CABO_FID", SqlDbType.VarChar,50),
 new SqlParameter("@CABO_OutTime", SqlDbType.DateTime,8),
 new SqlParameter("@CABO_Days", SqlDbType.Int,4),
 new SqlParameter("@CABO_Money", SqlDbType.Decimal,9),
 new SqlParameter("@CABO_Remarks", SqlDbType.VarChar,50),
new SqlParameter("@CABO_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.CABO_FID;
parameters[1].Value = model.CABO_OutTime;
parameters[2].Value = model.CABO_Days;
parameters[3].Value = model.CABO_Money;
parameters[4].Value = model.CABO_Remarks;
parameters[5].Value = model.CABO_ID;

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
public bool Delete(string s_CABO_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  CG_Account_Bill_Outimes  ");
strSql.Append(" where CABO_ID=@CABO_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CABO_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_CABO_ID;
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
public bool UpdateDel(KNet.Model.CG_Account_Bill_Outimes model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   CG_Account_Bill_Outimes  Set ");
strSql.Append(" where CABO_ID=@CABO_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CABO_ID", SqlDbType.VarChar,50)};
parameters[0].Value =  model.CABO_ID;

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
public bool DeleteList(string s_CABO_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   CG_Account_Bill_Outimes  ");
strSql.Append(" where CABO_ID in ('"+s_CABO_ID+"')");

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
strSql.Append("delete from  CG_Account_Bill_Outimes  ");
strSql.Append(" Where  CABO_FID=@CABO_FID ");
SqlParameter[] parameters = {
 new SqlParameter("@CABO_FID", SqlDbType.VarChar,50),
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
public KNet.Model.CG_Account_Bill_Outimes GetModel(string CABO_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from CG_Account_Bill_Outimes  ");
strSql.Append("where CABO_ID=@CABO_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@CABO_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = CABO_ID;
 KNet.Model.CG_Account_Bill_Outimes model = new KNet.Model.CG_Account_Bill_Outimes();
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
public KNet.Model.CG_Account_Bill_Outimes DataRowToModel(DataRow row)
{
KNet.Model.CG_Account_Bill_Outimes model=new KNet.Model.CG_Account_Bill_Outimes();
if (row != null)
{
 if (row["CABO_ID"] != null)
{
 model.CABO_ID = row["CABO_ID"].ToString();
}
 else
{
 model.CABO_ID = "";
}
 if (row["CABO_FID"] != null)
{
 model.CABO_FID = row["CABO_FID"].ToString();
}
 else
{
 model.CABO_FID = "";
}
 if (row["CABO_OutTime"] != null)
{
 model.CABO_OutTime = DateTime.Parse(row["CABO_OutTime"].ToString());
}
 if (row["CABO_Days"] != null)
{
 model.CABO_Days = int.Parse(row["CABO_Days"].ToString());
}
 else
{
 model.CABO_Days = 0;
}
 if (row["CABO_Money"] != null)
{
 model.CABO_Money = Decimal.Parse(row["CABO_Money"].ToString());
}
 else
{
 model.CABO_Money = 0;
}
 if (row["CABO_Remarks"] != null)
{
 model.CABO_Remarks = row["CABO_Remarks"].ToString();
}
 else
{
 model.CABO_Remarks = "";
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
strSql.Append(" FROM CG_Account_Bill_Outimes ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

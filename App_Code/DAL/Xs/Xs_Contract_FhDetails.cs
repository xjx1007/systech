 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class Xs_Contract_FhDetails
   {
   public Xs_Contract_FhDetails()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string XCF_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from Xs_Contract_FhDetails");
strSql.Append(" where XCF_ID=@XCF_ID ");
SqlParameter[] parameters = {
new SqlParameter("@XCF_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = XCF_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.Xs_Contract_FhDetails model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into Xs_Contract_FhDetails(");
strSql.Append("XCF_ID,XCF_FID,XCF_Name,XCF_Details ");
strSql.Append(") values (");
strSql.Append("@XCF_ID,@XCF_FID,@XCF_Name,@XCF_Details)");
SqlParameter[] parameters = {
 new SqlParameter("@XCF_ID", SqlDbType.VarChar,50),
 new SqlParameter("@XCF_FID", SqlDbType.VarChar,50),
 new SqlParameter("@XCF_Name", SqlDbType.Text),
 new SqlParameter("@XCF_Details", SqlDbType.Text)};
parameters[0].Value = model.XCF_ID;
parameters[1].Value = model.XCF_FID;
parameters[2].Value = model.XCF_Name;
parameters[3].Value = model.XCF_Details;
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
public bool Update(KNet.Model.Xs_Contract_FhDetails model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update Xs_Contract_FhDetails set ");
strSql.Append("XCF_FID=@XCF_FID,");
strSql.Append("XCF_Name=@XCF_Name,");
strSql.Append("XCF_Details=@XCF_Details");
strSql.Append(" where XCF_ID=@XCF_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@XCF_FID", SqlDbType.VarChar,50),
 new SqlParameter("@XCF_Name", SqlDbType.Text),
 new SqlParameter("@XCF_Details", SqlDbType.Text),
new SqlParameter("@XCF_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.XCF_FID;
parameters[1].Value = model.XCF_Name;
parameters[2].Value = model.XCF_Details;
parameters[3].Value = model.XCF_ID;

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
  /// DeleteByFID
 /// </summary>
public bool DeleteByFID(string s_FID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  Xs_Contract_FhDetails  ");
strSql.Append(" Where  XCF_FID=@XCF_FID ");
SqlParameter[] parameters = {
 new SqlParameter("@XCF_FID", SqlDbType.VarChar,50),
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
public KNet.Model.Xs_Contract_FhDetails GetModel(string XCF_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from Xs_Contract_FhDetails  ");
strSql.Append("where XCF_ID=@XCF_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@XCF_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = XCF_ID;
 KNet.Model.Xs_Contract_FhDetails model = new KNet.Model.Xs_Contract_FhDetails();
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
public KNet.Model.Xs_Contract_FhDetails DataRowToModel(DataRow row)
{
KNet.Model.Xs_Contract_FhDetails model=new KNet.Model.Xs_Contract_FhDetails();
if (row != null)
{
 if (row["XCF_ID"] != null)
{
 model.XCF_ID = row["XCF_ID"].ToString();
}
 else
{
 model.XCF_ID = "";
}
 if (row["XCF_FID"] != null)
{
 model.XCF_FID = row["XCF_FID"].ToString();
}
 else
{
 model.XCF_FID = "";
}
 if (row["XCF_Name"] != null)
{
 model.XCF_Name = row["XCF_Name"].ToString();
}
 else
{
 model.XCF_Name = "";
}
 if (row["XCF_Details"] != null)
{
 model.XCF_Details = row["XCF_Details"].ToString();
}
 else
{
 model.XCF_Details = "";
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
strSql.Append(" FROM Xs_Contract_FhDetails ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

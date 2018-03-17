 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class OA_Person_Report_Project
   {
   public OA_Person_Report_Project()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string OPRP_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from OA_Person_Report_Project");
strSql.Append(" where OPRP_ID=@OPRP_ID ");
SqlParameter[] parameters = {
new SqlParameter("@OPRP_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = OPRP_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.OA_Person_Report_Project model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into OA_Person_Report_Project(");
strSql.Append("OPRP_ID,OPRP_FID,OPRP_ProjectNum,OPRP_Project,OPRP_CTime,OPRP_Creator,OPRP_Type");
strSql.Append(") values (");
strSql.Append("@OPRP_ID,@OPRP_FID,@OPRP_ProjectNum,@OPRP_Project,@OPRP_CTime,@OPRP_Creator,@OPRP_Type)");
SqlParameter[] parameters = {
 new SqlParameter("@OPRP_ID", SqlDbType.VarChar,50),
 new SqlParameter("@OPRP_FID", SqlDbType.VarChar,50),
 new SqlParameter("@OPRP_ProjectNum", SqlDbType.Int,4),
 new SqlParameter("@OPRP_Project", SqlDbType.VarChar,16),
 new SqlParameter("@OPRP_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@OPRP_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@OPRP_Type", SqlDbType.Int,4)};
parameters[0].Value = model.OPRP_ID;
parameters[1].Value = model.OPRP_FID;
parameters[2].Value = model.OPRP_ProjectNum;
parameters[3].Value = model.OPRP_Project;
parameters[4].Value = model.OPRP_CTime;
parameters[5].Value = model.OPRP_Creator;
parameters[6].Value = model.OPRP_Type;
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
public bool Update(KNet.Model.OA_Person_Report_Project model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update OA_Person_Report_Project set ");
strSql.Append("OPRP_FID=@OPRP_FID,");
strSql.Append("OPRP_ProjectNum=@OPRP_ProjectNum,");
strSql.Append("OPRP_Project=@OPRP_Project");
strSql.Append(" where OPRP_ID=@OPRP_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@OPRP_FID", SqlDbType.VarChar,50),
 new SqlParameter("@OPRP_ProjectNum", SqlDbType.Int,4),
 new SqlParameter("@OPRP_Project", SqlDbType.VarChar,16),
new SqlParameter("@OPRP_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.OPRP_FID;
parameters[1].Value = model.OPRP_ProjectNum;
parameters[2].Value = model.OPRP_Project;
parameters[3].Value = model.OPRP_ID;

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
    StringBuilder strSql = new StringBuilder();
    strSql.Append("delete from  OA_Person_Report_Project  ");
    strSql.Append(" Where OPRP_FID=@OPRP_FID ");
    SqlParameter[] parameters = {
 new SqlParameter("@OPRP_FID", SqlDbType.VarChar,50)
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
public KNet.Model.OA_Person_Report_Project GetModel(string OPRP_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from OA_Person_Report_Project  ");
strSql.Append("where OPRP_ID=@OPRP_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@OPRP_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = OPRP_ID;
 KNet.Model.OA_Person_Report_Project model = new KNet.Model.OA_Person_Report_Project();
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
public KNet.Model.OA_Person_Report_Project DataRowToModel(DataRow row)
{
KNet.Model.OA_Person_Report_Project model=new KNet.Model.OA_Person_Report_Project();
if (row != null)
{
 if (row["OPRP_ID"] != null)
{
 model.OPRP_ID = row["OPRP_ID"].ToString();
}
 else
{
 model.OPRP_ID = "";
}
 if (row["OPRP_FID"] != null)
{
 model.OPRP_FID = row["OPRP_FID"].ToString();
}
 else
{
 model.OPRP_FID = "";
}
 if (row["OPRP_ProjectNum"] != null)
{
 model.OPRP_ProjectNum = int.Parse(row["OPRP_ProjectNum"].ToString());
}
 else
{
 model.OPRP_ProjectNum = 0;
}
 if (row["OPRP_Project"] != null)
{
 model.OPRP_Project = row["OPRP_Project"].ToString();
}
 else
{
 model.OPRP_Project = "";
}
 if (row["OPRP_CTime"] != null)
{
 model.OPRP_CTime = DateTime.Parse(row["OPRP_CTime"].ToString());
}
 if (row["OPRP_Creator"] != null)
{
 model.OPRP_Creator = row["OPRP_Creator"].ToString();
}
 else
{
 model.OPRP_Creator = "";
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
strSql.Append(" FROM OA_Person_Report_Project ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

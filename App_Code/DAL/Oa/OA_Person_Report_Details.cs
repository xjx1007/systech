 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class OA_Person_Report_Details
   {
   public OA_Person_Report_Details()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string OPRD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from OA_Person_Report_Details");
strSql.Append(" where OPRD_ID=@OPRD_ID ");
SqlParameter[] parameters = {
new SqlParameter("@OPRD_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = OPRD_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}

/// <summary>
/// 增加
/// </summary>
public bool Add(KNet.Model.OA_Person_Report_Details model)
{
    StringBuilder strSql = new StringBuilder();
    strSql.Append("insert into OA_Person_Report_Details(");
    strSql.Append("OPRD_ID,OPRD_FID,OPRD_ProjectNum,OPRD_DetailsNum,OPRD_Project,OPRD_ProjectDetails,OPRD_Person,OPRD_Time,OPRD_CTime,OPRD_Creator,OPRD_FFID,OPRD_Type ");
    strSql.Append(") values (");
    strSql.Append("@OPRD_ID,@OPRD_FID,@OPRD_ProjectNum,@OPRD_DetailsNum,@OPRD_Project,@OPRD_ProjectDetails,@OPRD_Person,@OPRD_Time,@OPRD_CTime,@OPRD_Creator,@OPRD_FFID,@OPRD_Type)");
    SqlParameter[] parameters = {
 new SqlParameter("@OPRD_ID", SqlDbType.VarChar,50),
 new SqlParameter("@OPRD_FID", SqlDbType.VarChar,50),
 new SqlParameter("@OPRD_ProjectNum", SqlDbType.Int,4),
 new SqlParameter("@OPRD_DetailsNum", SqlDbType.Int,4),
 new SqlParameter("@OPRD_Project", SqlDbType.VarChar,16),
 new SqlParameter("@OPRD_ProjectDetails", SqlDbType.VarChar,16),
 new SqlParameter("@OPRD_Person", SqlDbType.VarChar,1000),
 new SqlParameter("@OPRD_Time", SqlDbType.VarChar,50),
 new SqlParameter("@OPRD_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@OPRD_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@OPRD_FFID", SqlDbType.VarChar,50),
 new SqlParameter("@OPRD_Type", SqlDbType.Int,4)
 
                                };
    parameters[0].Value = model.OPRD_ID;
    parameters[1].Value = model.OPRD_FID;
    parameters[2].Value = model.OPRD_ProjectNum;
    parameters[3].Value = model.OPRD_DetailsNum;
    parameters[4].Value = model.OPRD_Project;
    parameters[5].Value = model.OPRD_ProjectDetails;
    parameters[6].Value = model.OPRD_Person;
    parameters[7].Value = model.OPRD_Time;
    parameters[8].Value = model.OPRD_CTime;
    parameters[9].Value = model.OPRD_Creator;
    parameters[10].Value = model.OPRD_FFID;
    parameters[11].Value = model.OPRD_Type;
    
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
public bool Update(KNet.Model.OA_Person_Report_Details model)
{
    StringBuilder strSql = new StringBuilder();
    strSql.Append("Update OA_Person_Report_Details set ");
    strSql.Append("OPRD_FID=@OPRD_FID,");
    strSql.Append("OPRD_ProjectNum=@OPRD_ProjectNum,");
    strSql.Append("OPRD_DetailsNum=@OPRD_DetailsNum,");
    strSql.Append("OPRD_Project=@OPRD_Project,");
    strSql.Append("OPRD_ProjectDetails=@OPRD_ProjectDetails,");
    strSql.Append("OPRD_Person=@OPRD_Person,");
    strSql.Append("OPRD_Time=@OPRD_Time");
    strSql.Append(" where OPRD_ID=@OPRD_ID ");
    SqlParameter[] parameters = {
 new SqlParameter("@OPRD_FID", SqlDbType.VarChar,50),
 new SqlParameter("@OPRD_ProjectNum", SqlDbType.Int,4),
 new SqlParameter("@OPRD_DetailsNum", SqlDbType.Int,4),
 new SqlParameter("@OPRD_Project", SqlDbType.VarChar,16),
 new SqlParameter("@OPRD_ProjectDetails", SqlDbType.VarChar,16),
 new SqlParameter("@OPRD_Person", SqlDbType.VarChar,1000),
 new SqlParameter("@OPRD_Time", SqlDbType.VarChar,50),
new SqlParameter("@OPRD_ID", SqlDbType.VarChar,50)};
    parameters[0].Value = model.OPRD_FID;
    parameters[1].Value = model.OPRD_ProjectNum;
    parameters[2].Value = model.OPRD_DetailsNum;
    parameters[3].Value = model.OPRD_Project;
    parameters[4].Value = model.OPRD_ProjectDetails;
    parameters[5].Value = model.OPRD_Person;
    parameters[6].Value = model.OPRD_Time;
    parameters[7].Value = model.OPRD_ID;

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
strSql.Append("delete from  OA_Person_Report_Details  ");
strSql.Append(" Where  OPRD_FFID=@OPRD_FFID ");
SqlParameter[] parameters = {
 new SqlParameter("@OPRD_FFID", SqlDbType.VarChar,50),
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
/// DeleteList
/// </summary>
public bool Delete(string s_ID)
{
    StringBuilder strSql = new StringBuilder();
    strSql.Append("delete from  OA_Person_Report_Details  ");
    strSql.Append(" Where  OPRD_ID=@OPRD_ID ");
    SqlParameter[] parameters = {
 new SqlParameter("@OPRD_ID", SqlDbType.VarChar,50),
};
    parameters[0].Value = s_ID;

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
public KNet.Model.OA_Person_Report_Details GetModel(string OPRD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from OA_Person_Report_Details  ");
strSql.Append("where OPRD_ID=@OPRD_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@OPRD_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = OPRD_ID;
 KNet.Model.OA_Person_Report_Details model = new KNet.Model.OA_Person_Report_Details();
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
public KNet.Model.OA_Person_Report_Details DataRowToModel(DataRow row)
{
    KNet.Model.OA_Person_Report_Details model = new KNet.Model.OA_Person_Report_Details();
    if (row != null)
    {
        if (row["OPRD_ID"] != null)
        {
            model.OPRD_ID = row["OPRD_ID"].ToString();
        }
        else
        {
            model.OPRD_ID = "";
        }
        if (row["OPRD_FID"] != null)
        {
            model.OPRD_FID = row["OPRD_FID"].ToString();
        }
        else
        {
            model.OPRD_FID = "";
        }
        if (row["OPRD_ProjectNum"] != null)
        {
            model.OPRD_ProjectNum = int.Parse(row["OPRD_ProjectNum"].ToString());
        }
        else
        {
            model.OPRD_ProjectNum = 0;
        }
        if (row["OPRD_DetailsNum"] != null)
        {
            model.OPRD_DetailsNum = int.Parse(row["OPRD_DetailsNum"].ToString());
        }
        else
        {
            model.OPRD_DetailsNum = 0;
        }
        if (row["OPRD_Project"] != null)
        {
            model.OPRD_Project = row["OPRD_Project"].ToString();
        }
        else
        {
            model.OPRD_Project = "";
        }
        if (row["OPRD_ProjectDetails"] != null)
        {
            model.OPRD_ProjectDetails = row["OPRD_ProjectDetails"].ToString();
        }
        else
        {
            model.OPRD_ProjectDetails = "";
        }
        if (row["OPRD_Person"] != null)
        {
            model.OPRD_Person = row["OPRD_Person"].ToString();
        }
        else
        {
            model.OPRD_Person = "";
        }
        if (row["OPRD_Time"] != null)
        {
            model.OPRD_Time = row["OPRD_Time"].ToString();
        }
        else
        {
            model.OPRD_Time = "";
        }
        if (row["OPRD_CTime"] != null)
        {
            model.OPRD_CTime = DateTime.Parse(row["OPRD_CTime"].ToString());
        }
        if (row["OPRD_Creator"] != null)
        {
            model.OPRD_Creator = row["OPRD_Creator"].ToString();
        }
        else
        {
            model.OPRD_Creator = "";
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
strSql.Append(" FROM OA_Person_Report_Details ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

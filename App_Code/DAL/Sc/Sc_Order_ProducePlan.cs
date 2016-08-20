 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class Sc_Order_ProducePlan
   {
   public Sc_Order_ProducePlan()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string SOP_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from Sc_Order_ProducePlan");
strSql.Append(" where SOP_ID=@SOP_ID ");
SqlParameter[] parameters = {
new SqlParameter("@SOP_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = SOP_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.Sc_Order_ProducePlan model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into Sc_Order_ProducePlan(");
strSql.Append("SOP_ID,SOP_FID,SOP_PlanID,SOP_SuppNo,SOP_STime,SOP_BeginTime,SOP_EndTime,SOP_ScNumber,SOP_LeftNumber,SOP_DayScNumber,SOP_Creator,SOP_CTime,SOP_Del ");
strSql.Append(") values (");
strSql.Append("@SOP_ID,@SOP_FID,@SOP_PlanID,@SOP_SuppNo,@SOP_STime,@SOP_BeginTime,@SOP_EndTime,@SOP_ScNumber,@SOP_LeftNumber,@SOP_DayScNumber,@SOP_Creator,@SOP_CTime,@SOP_Del)");
SqlParameter[] parameters = {
 new SqlParameter("@SOP_ID", SqlDbType.VarChar,50),
 new SqlParameter("@SOP_FID", SqlDbType.VarChar,50),
 new SqlParameter("@SOP_PlanID", SqlDbType.VarChar,50),
 new SqlParameter("@SOP_SuppNo", SqlDbType.VarChar,50),
 new SqlParameter("@SOP_STime", SqlDbType.DateTime,8),
 new SqlParameter("@SOP_BeginTime", SqlDbType.DateTime,8),
 new SqlParameter("@SOP_EndTime", SqlDbType.DateTime,8),
 new SqlParameter("@SOP_ScNumber", SqlDbType.Int,4),
 new SqlParameter("@SOP_LeftNumber", SqlDbType.Int,4),
 new SqlParameter("@SOP_DayScNumber", SqlDbType.Int,4),
 new SqlParameter("@SOP_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@SOP_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@SOP_Del", SqlDbType.Int,4)};
parameters[0].Value = model.SOP_ID;
parameters[1].Value = model.SOP_FID;
parameters[2].Value = model.SOP_PlanID;
parameters[3].Value = model.SOP_SuppNo;
parameters[4].Value = model.SOP_STime;
parameters[5].Value = model.SOP_BeginTime;
parameters[6].Value = model.SOP_EndTime;
parameters[7].Value = model.SOP_ScNumber;
parameters[8].Value = model.SOP_LeftNumber;
parameters[9].Value = model.SOP_DayScNumber;
parameters[10].Value = model.SOP_Creator;
parameters[11].Value = model.SOP_CTime;
parameters[12].Value = model.SOP_Del;
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
public bool Update(KNet.Model.Sc_Order_ProducePlan model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update Sc_Order_ProducePlan set ");
strSql.Append("SOP_FID=@SOP_FID,");
strSql.Append("SOP_PlanID=@SOP_PlanID,");
strSql.Append("SOP_SuppNo=@SOP_SuppNo,");
strSql.Append("SOP_STime=@SOP_STime,");
strSql.Append("SOP_BeginTime=@SOP_BeginTime,");
strSql.Append("SOP_EndTime=@SOP_EndTime,");
strSql.Append("SOP_ScNumber=@SOP_ScNumber,");
strSql.Append("SOP_LeftNumber=@SOP_LeftNumber,");
strSql.Append("SOP_DayScNumber=@SOP_DayScNumber,");
strSql.Append("SOP_Del=@SOP_Del");
strSql.Append(" where SOP_ID=@SOP_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@SOP_FID", SqlDbType.VarChar,50),
 new SqlParameter("@SOP_PlanID", SqlDbType.VarChar,50),
 new SqlParameter("@SOP_SuppNo", SqlDbType.VarChar,50),
 new SqlParameter("@SOP_STime", SqlDbType.DateTime,8),
 new SqlParameter("@SOP_BeginTime", SqlDbType.DateTime,8),
 new SqlParameter("@SOP_EndTime", SqlDbType.DateTime,8),
 new SqlParameter("@SOP_ScNumber", SqlDbType.Int,4),
 new SqlParameter("@SOP_LeftNumber", SqlDbType.Int,4),
 new SqlParameter("@SOP_DayScNumber", SqlDbType.Int,4),
 new SqlParameter("@SOP_Del", SqlDbType.Int,4),
new SqlParameter("@SOP_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.SOP_FID;
parameters[1].Value = model.SOP_PlanID;
parameters[2].Value = model.SOP_SuppNo;
parameters[3].Value = model.SOP_STime;
parameters[4].Value = model.SOP_BeginTime;
parameters[5].Value = model.SOP_EndTime;
parameters[6].Value = model.SOP_ScNumber;
parameters[7].Value = model.SOP_LeftNumber;
parameters[8].Value = model.SOP_DayScNumber;
parameters[9].Value = model.SOP_Del;
parameters[10].Value = model.SOP_ID;

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
public bool Delete(string s_SOP_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  Sc_Order_ProducePlan  ");
strSql.Append(" where SOP_ID=@SOP_ID ");
SqlParameter[] parameters = {
new SqlParameter("@SOP_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_SOP_ID;
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
public bool UpdateDel(KNet.Model.Sc_Order_ProducePlan model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   Sc_Order_ProducePlan  Set ");
strSql.Append("  SOP_Del=@SOP_Del ");
strSql.Append(" where SOP_ID=@SOP_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@SOP_Del", SqlDbType.Int,4),
new SqlParameter("@SOP_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.SOP_Del;
parameters[1].Value =  model.SOP_ID;

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
public bool UpdateDelBySuppNo(string s_SuppNo)
{
    StringBuilder strSql = new StringBuilder();
    strSql.Append("Update   Sc_Order_ProducePlan  Set ");
    strSql.Append("  SOP_Del=1 ");
    strSql.Append(" where SOP_SuppNo=@SOP_SuppNo ");
    SqlParameter[] parameters = {
new SqlParameter("@SOP_SuppNo", SqlDbType.VarChar,50)};
    parameters[0].Value = s_SuppNo;

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
public bool DeleteList(string s_SOP_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   Sc_Order_ProducePlan  ");
strSql.Append(" where SOP_ID in ('"+s_SOP_ID+"')");

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
public KNet.Model.Sc_Order_ProducePlan GetModel(string SOP_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from Sc_Order_ProducePlan  ");
strSql.Append("where SOP_ID=@SOP_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@SOP_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = SOP_ID;
 KNet.Model.Sc_Order_ProducePlan model = new KNet.Model.Sc_Order_ProducePlan();
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
public KNet.Model.Sc_Order_ProducePlan DataRowToModel(DataRow row)
{
KNet.Model.Sc_Order_ProducePlan model=new KNet.Model.Sc_Order_ProducePlan();
if (row != null)
{
 if (row["SOP_ID"] != null)
{
 model.SOP_ID = row["SOP_ID"].ToString();
}
 else
{
 model.SOP_ID = "";
}
 if (row["SOP_FID"] != null)
{
 model.SOP_FID = row["SOP_FID"].ToString();
}
 else
{
 model.SOP_FID = "";
}
 if (row["SOP_PlanID"] != null)
{
 model.SOP_PlanID = row["SOP_PlanID"].ToString();
}
 else
{
 model.SOP_PlanID = "";
}
 if (row["SOP_SuppNo"] != null)
{
 model.SOP_SuppNo = row["SOP_SuppNo"].ToString();
}
 else
{
 model.SOP_SuppNo = "";
}
 if (row["SOP_STime"] != null)
{
 model.SOP_STime = DateTime.Parse(row["SOP_STime"].ToString());
}
 if (row["SOP_BeginTime"] != null)
{
 model.SOP_BeginTime = DateTime.Parse(row["SOP_BeginTime"].ToString());
}
 if (row["SOP_EndTime"] != null)
{
 model.SOP_EndTime = DateTime.Parse(row["SOP_EndTime"].ToString());
}
 if (row["SOP_ScNumber"] != null)
{
 model.SOP_ScNumber = int.Parse(row["SOP_ScNumber"].ToString());
}
 else
{
 model.SOP_ScNumber = 0;
}
 if (row["SOP_LeftNumber"] != null)
{
 model.SOP_LeftNumber = int.Parse(row["SOP_LeftNumber"].ToString());
}
 else
{
 model.SOP_LeftNumber = 0;
}
 if (row["SOP_DayScNumber"] != null)
{
 model.SOP_DayScNumber = int.Parse(row["SOP_DayScNumber"].ToString());
}
 else
{
 model.SOP_DayScNumber = 0;
}
 if (row["SOP_Creator"] != null)
{
 model.SOP_Creator = row["SOP_Creator"].ToString();
}
 else
{
 model.SOP_Creator = "";
}
 if (row["SOP_CTime"] != null)
{
 model.SOP_CTime = DateTime.Parse(row["SOP_CTime"].ToString());
}
 if (row["SOP_Del"] != null)
{
 model.SOP_Del = int.Parse(row["SOP_Del"].ToString());
}
 else
{
 model.SOP_Del = 0;
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
strSql.Append(" FROM Sc_Order_ProducePlan ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

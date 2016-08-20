 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class Zl_Produce_Problem_Details
   {
   public Zl_Produce_Problem_Details()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string ZPPD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from Zl_Produce_Problem_Details");
strSql.Append(" where ZPPD_ID=@ZPPD_ID ");
SqlParameter[] parameters = {
new SqlParameter("@ZPPD_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = ZPPD_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.Zl_Produce_Problem_Details model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into Zl_Produce_Problem_Details(");
strSql.Append("ZPPD_ID,ZPPD_FID,ZPPD_OrderNo,ZPPD_Remarks,ZPP_Type,ZPP_Details ");
strSql.Append(") values (");
strSql.Append("@ZPPD_ID,@ZPPD_FID,@ZPPD_OrderNo,@ZPPD_Remarks,@ZPP_Type,@ZPP_Details)");
SqlParameter[] parameters = {
 new SqlParameter("@ZPPD_ID", SqlDbType.VarChar,50),
 new SqlParameter("@ZPPD_FID", SqlDbType.VarChar,50),
 new SqlParameter("@ZPPD_OrderNo", SqlDbType.VarChar,50),
 new SqlParameter("@ZPPD_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@ZPP_Type", SqlDbType.Int,4),
 new SqlParameter("@ZPP_Details", SqlDbType.VarChar,500)};
parameters[0].Value = model.ZPPD_ID;
parameters[1].Value = model.ZPPD_FID;
parameters[2].Value = model.ZPPD_OrderNo;
parameters[3].Value = model.ZPPD_Remarks;
parameters[4].Value = model.ZPP_Type;
parameters[5].Value = model.ZPP_Details;
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
public bool Update(KNet.Model.Zl_Produce_Problem_Details model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update Zl_Produce_Problem_Details set ");
strSql.Append("ZPPD_FID=@ZPPD_FID,");
strSql.Append("ZPPD_OrderNo=@ZPPD_OrderNo,");
strSql.Append("ZPPD_Remarks=@ZPPD_Remarks,");
strSql.Append("ZPP_Type=@ZPP_Type,");
strSql.Append("ZPP_Details=@ZPP_Details");
strSql.Append(" where ZPPD_ID=@ZPPD_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@ZPPD_FID", SqlDbType.VarChar,50),
 new SqlParameter("@ZPPD_OrderNo", SqlDbType.VarChar,50),
 new SqlParameter("@ZPPD_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@ZPP_Type", SqlDbType.Int,4),
 new SqlParameter("@ZPP_Details", SqlDbType.VarChar,500),
new SqlParameter("@ZPPD_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.ZPPD_FID;
parameters[1].Value = model.ZPPD_OrderNo;
parameters[2].Value = model.ZPPD_Remarks;
parameters[3].Value = model.ZPP_Type;
parameters[4].Value = model.ZPP_Details;
parameters[5].Value = model.ZPPD_ID;

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
public bool Delete(string s_ZPPD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  Zl_Produce_Problem_Details  ");
strSql.Append(" where ZPPD_ID=@ZPPD_ID ");
SqlParameter[] parameters = {
new SqlParameter("@ZPPD_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_ZPPD_ID;
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
public bool UpdateDel(KNet.Model.Zl_Produce_Problem_Details model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   Zl_Produce_Problem_Details  Set ");
strSql.Append(" where ZPPD_ID=@ZPPD_ID ");
SqlParameter[] parameters = {
new SqlParameter("@ZPPD_ID", SqlDbType.VarChar,50)};
parameters[0].Value =  model.ZPPD_ID;

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
public bool DeleteList(string s_ZPPD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   Zl_Produce_Problem_Details  ");
strSql.Append(" where ZPPD_ID in ('"+s_ZPPD_ID+"')");

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
strSql.Append("Select * from  Zl_Produce_Problem_Details  ");
strSql.Append(" Where  ZPPD_FID=@ZPPD_FID ");
SqlParameter[] parameters = {
 new SqlParameter("@ZPPD_FID", SqlDbType.VarChar,50),
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
strSql.Append("delete from  Zl_Produce_Problem_Details  ");
strSql.Append(" Where  ZPPD_FID=@ZPPD_FID ");
SqlParameter[] parameters = {
 new SqlParameter("@ZPPD_FID", SqlDbType.VarChar,50),
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
public KNet.Model.Zl_Produce_Problem_Details GetModel(string ZPPD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from Zl_Produce_Problem_Details  ");
strSql.Append("where ZPPD_ID=@ZPPD_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@ZPPD_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = ZPPD_ID;
 KNet.Model.Zl_Produce_Problem_Details model = new KNet.Model.Zl_Produce_Problem_Details();
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
public KNet.Model.Zl_Produce_Problem_Details DataRowToModel(DataRow row)
{
KNet.Model.Zl_Produce_Problem_Details model=new KNet.Model.Zl_Produce_Problem_Details();
if (row != null)
{
 if (row["ZPPD_ID"] != null)
{
 model.ZPPD_ID = row["ZPPD_ID"].ToString();
}
 else
{
 model.ZPPD_ID = "";
}
 if (row["ZPPD_FID"] != null)
{
 model.ZPPD_FID = row["ZPPD_FID"].ToString();
}
 else
{
 model.ZPPD_FID = "";
}
 if (row["ZPPD_OrderNo"] != null)
{
 model.ZPPD_OrderNo = row["ZPPD_OrderNo"].ToString();
}
 else
{
 model.ZPPD_OrderNo = "";
}
 if (row["ZPPD_Remarks"] != null)
{
 model.ZPPD_Remarks = row["ZPPD_Remarks"].ToString();
}
 else
{
 model.ZPPD_Remarks = "";
}
 if (row["ZPP_Type"] != null)
{
 model.ZPP_Type = int.Parse(row["ZPP_Type"].ToString());
}
 else
{
 model.ZPP_Type = 0;
}
 if (row["ZPP_Details"] != null)
{
 model.ZPP_Details = row["ZPP_Details"].ToString();
}
 else
{
 model.ZPP_Details = "";
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
strSql.Append(" FROM Zl_Produce_Problem_Details ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

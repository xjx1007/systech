 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class Cg_Contract_Manage
   {
   public Cg_Contract_Manage()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string CCM_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from Cg_Contract_Manage");
strSql.Append(" where CCM_ID=@CCM_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CCM_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = CCM_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.Cg_Contract_Manage model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into Cg_Contract_Manage(");
strSql.Append("CCM_ID,CCM_Code,CCM_Type,CCM_Title,CCM_CustomerValue,CCM_DutyPerson,CCM_STime,CCM_Flow,CCM_Remarks,CCM_Del,CCM_Creator,CCM_CTime,CCM_Mender,CCM_MTime,CCM_OrderNo,CCM_CheckYN,CCM_PayMent,CCM_BillType,CCM_TechnicalRequire,CCM_ProductPackaging,CCM_QualityRequire,CCM_WarrantyPeriod,CCM_DeliveryReqyire,CCM_FhDetails ");
strSql.Append(") values (");
strSql.Append("@CCM_ID,@CCM_Code,@CCM_Type,@CCM_Title,@CCM_CustomerValue,@CCM_DutyPerson,@CCM_STime,@CCM_Flow,@CCM_Remarks,@CCM_Del,@CCM_Creator,@CCM_CTime,@CCM_Mender,@CCM_MTime,@CCM_OrderNo,@CCM_CheckYN,@CCM_PayMent,@CCM_BillType,@CCM_TechnicalRequire,@CCM_ProductPackaging,@CCM_QualityRequire,@CCM_WarrantyPeriod,@CCM_DeliveryReqyire,@CCM_FhDetails)");
SqlParameter[] parameters = {
 new SqlParameter("@CCM_ID", SqlDbType.VarChar,50),
 new SqlParameter("@CCM_Code", SqlDbType.VarChar,50),
 new SqlParameter("@CCM_Type", SqlDbType.VarChar,50),
 new SqlParameter("@CCM_Title", SqlDbType.VarChar,250),
 new SqlParameter("@CCM_CustomerValue", SqlDbType.VarChar,50),
 new SqlParameter("@CCM_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@CCM_STime", SqlDbType.DateTime,8),
 new SqlParameter("@CCM_Flow", SqlDbType.VarChar,50),
 new SqlParameter("@CCM_Remarks", SqlDbType.VarChar,16),
 new SqlParameter("@CCM_Del", SqlDbType.Int,4),
 new SqlParameter("@CCM_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@CCM_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@CCM_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@CCM_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@CCM_OrderNo", SqlDbType.Int,4),
 new SqlParameter("@CCM_CheckYN", SqlDbType.Int,4),
 new SqlParameter("@CCM_PayMent", SqlDbType.VarChar,50),
 new SqlParameter("@CCM_BillType", SqlDbType.VarChar,50),
 new SqlParameter("@CCM_TechnicalRequire", SqlDbType.VarChar,450),
 new SqlParameter("@CCM_ProductPackaging", SqlDbType.VarChar,450),
 new SqlParameter("@CCM_QualityRequire", SqlDbType.VarChar,450),
 new SqlParameter("@CCM_WarrantyPeriod", SqlDbType.VarChar,450),
 new SqlParameter("@CCM_DeliveryReqyire", SqlDbType.VarChar,450),
 new SqlParameter("@CCM_FhDetails", SqlDbType.VarChar,1000)};
parameters[0].Value = model.CCM_ID;
parameters[1].Value = model.CCM_Code;
parameters[2].Value = model.CCM_Type;
parameters[3].Value = model.CCM_Title;
parameters[4].Value = model.CCM_CustomerValue;
parameters[5].Value = model.CCM_DutyPerson;
parameters[6].Value = model.CCM_STime;
parameters[7].Value = model.CCM_Flow;
parameters[8].Value = model.CCM_Remarks;
parameters[9].Value = model.CCM_Del;
parameters[10].Value = model.CCM_Creator;
parameters[11].Value = model.CCM_CTime;
parameters[12].Value = model.CCM_Mender;
parameters[13].Value = model.CCM_MTime;
parameters[14].Value = model.CCM_OrderNo;
parameters[15].Value = model.CCM_CheckYN;
parameters[16].Value = model.CCM_PayMent;
parameters[17].Value = model.CCM_BillType;
parameters[18].Value = model.CCM_TechnicalRequire;
parameters[19].Value = model.CCM_ProductPackaging;
parameters[20].Value = model.CCM_QualityRequire;
parameters[21].Value = model.CCM_WarrantyPeriod;
parameters[22].Value = model.CCM_DeliveryReqyire;
parameters[23].Value = model.CCM_FhDetails;
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
public bool Update(KNet.Model.Cg_Contract_Manage model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update Cg_Contract_Manage set ");
strSql.Append("CCM_Code=@CCM_Code,");
strSql.Append("CCM_Type=@CCM_Type,");
strSql.Append("CCM_Title=@CCM_Title,");
strSql.Append("CCM_CustomerValue=@CCM_CustomerValue,");
strSql.Append("CCM_DutyPerson=@CCM_DutyPerson,");
strSql.Append("CCM_STime=@CCM_STime,");
strSql.Append("CCM_Flow=@CCM_Flow,");
strSql.Append("CCM_Remarks=@CCM_Remarks,");
strSql.Append("CCM_Del=@CCM_Del,");
strSql.Append("CCM_Mender=@CCM_Mender,");
strSql.Append("CCM_MTime=@CCM_MTime,");
strSql.Append("CCM_OrderNo=@CCM_OrderNo,");
strSql.Append("CCM_CheckYN=@CCM_CheckYN,");
strSql.Append("CCM_PayMent=@CCM_PayMent,");
strSql.Append("CCM_BillType=@CCM_BillType,");
strSql.Append("CCM_TechnicalRequire=@CCM_TechnicalRequire,");
strSql.Append("CCM_ProductPackaging=@CCM_ProductPackaging,");
strSql.Append("CCM_QualityRequire=@CCM_QualityRequire,");
strSql.Append("CCM_WarrantyPeriod=@CCM_WarrantyPeriod,");
strSql.Append("CCM_DeliveryReqyire=@CCM_DeliveryReqyire,");
strSql.Append("CCM_FhDetails=@CCM_FhDetails");
strSql.Append(" where CCM_ID=@CCM_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@CCM_Code", SqlDbType.VarChar,50),
 new SqlParameter("@CCM_Type", SqlDbType.VarChar,50),
 new SqlParameter("@CCM_Title", SqlDbType.VarChar,250),
 new SqlParameter("@CCM_CustomerValue", SqlDbType.VarChar,50),
 new SqlParameter("@CCM_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@CCM_STime", SqlDbType.DateTime,8),
 new SqlParameter("@CCM_Flow", SqlDbType.VarChar,50),
 new SqlParameter("@CCM_Remarks", SqlDbType.VarChar,16),
 new SqlParameter("@CCM_Del", SqlDbType.Int,4),
 new SqlParameter("@CCM_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@CCM_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@CCM_OrderNo", SqlDbType.Int,4),
 new SqlParameter("@CCM_CheckYN", SqlDbType.Int,4),
 new SqlParameter("@CCM_PayMent", SqlDbType.VarChar,50),
 new SqlParameter("@CCM_BillType", SqlDbType.VarChar,50),
 new SqlParameter("@CCM_TechnicalRequire", SqlDbType.VarChar,450),
 new SqlParameter("@CCM_ProductPackaging", SqlDbType.VarChar,450),
 new SqlParameter("@CCM_QualityRequire", SqlDbType.VarChar,450),
 new SqlParameter("@CCM_WarrantyPeriod", SqlDbType.VarChar,450),
 new SqlParameter("@CCM_DeliveryReqyire", SqlDbType.VarChar,450),
 new SqlParameter("@CCM_FhDetails", SqlDbType.VarChar,1000),
new SqlParameter("@CCM_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.CCM_Code;
parameters[1].Value = model.CCM_Type;
parameters[2].Value = model.CCM_Title;
parameters[3].Value = model.CCM_CustomerValue;
parameters[4].Value = model.CCM_DutyPerson;
parameters[5].Value = model.CCM_STime;
parameters[6].Value = model.CCM_Flow;
parameters[7].Value = model.CCM_Remarks;
parameters[8].Value = model.CCM_Del;
parameters[9].Value = model.CCM_Mender;
parameters[10].Value = model.CCM_MTime;
parameters[11].Value = model.CCM_OrderNo;
parameters[12].Value = model.CCM_CheckYN;
parameters[13].Value = model.CCM_PayMent;
parameters[14].Value = model.CCM_BillType;
parameters[15].Value = model.CCM_TechnicalRequire;
parameters[16].Value = model.CCM_ProductPackaging;
parameters[17].Value = model.CCM_QualityRequire;
parameters[18].Value = model.CCM_WarrantyPeriod;
parameters[19].Value = model.CCM_DeliveryReqyire;
parameters[20].Value = model.CCM_FhDetails;
parameters[21].Value = model.CCM_ID;

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
public bool Delete(string s_CCM_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  Cg_Contract_Manage  ");
strSql.Append(" where CCM_ID=@CCM_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CCM_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_CCM_ID;
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
public bool UpdateDel(KNet.Model.Cg_Contract_Manage model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   Cg_Contract_Manage  Set ");
strSql.Append("  CCM_Del=@CCM_Del ");
strSql.Append("  CCM_DeliveryReqyire=@CCM_DeliveryReqyire ");
strSql.Append(" where CCM_ID=@CCM_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@CCM_Del", SqlDbType.Int,4),
 new SqlParameter("@CCM_DeliveryReqyire", SqlDbType.VarChar,450),
new SqlParameter("@CCM_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.CCM_Del;
parameters[1].Value = model.CCM_DeliveryReqyire;
parameters[2].Value =  model.CCM_ID;

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
public bool DeleteList(string s_CCM_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   Cg_Contract_Manage  ");
strSql.Append(" where CCM_ID in ('"+s_CCM_ID+"')");

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
strSql.Append("Select * from  Cg_Contract_Manage  ");
SqlParameter[] parameters = {
};

return DbHelperSQL.Query(strSql.ToString());
   }
  /// <summary>
  /// DeleteByFID
 /// </summary>
public bool DeleteByFID(string s_FID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  Cg_Contract_Manage  ");
SqlParameter[] parameters = {
};

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
public KNet.Model.Cg_Contract_Manage GetModel(string CCM_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from Cg_Contract_Manage  ");
strSql.Append("where CCM_ID=@CCM_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@CCM_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = CCM_ID;
 KNet.Model.Cg_Contract_Manage model = new KNet.Model.Cg_Contract_Manage();
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
public KNet.Model.Cg_Contract_Manage DataRowToModel(DataRow row)
{
KNet.Model.Cg_Contract_Manage model=new KNet.Model.Cg_Contract_Manage();
if (row != null)
{
 if (row["CCM_ID"] != null)
{
 model.CCM_ID = row["CCM_ID"].ToString();
}
 else
{
 model.CCM_ID = "";
}
 if (row["CCM_Code"] != null)
{
 model.CCM_Code = row["CCM_Code"].ToString();
}
 else
{
 model.CCM_Code = "";
}
 if (row["CCM_Type"] != null)
{
 model.CCM_Type = row["CCM_Type"].ToString();
}
 else
{
 model.CCM_Type = "";
}
 if (row["CCM_Title"] != null)
{
 model.CCM_Title = row["CCM_Title"].ToString();
}
 else
{
 model.CCM_Title = "";
}
 if (row["CCM_CustomerValue"] != null)
{
 model.CCM_CustomerValue = row["CCM_CustomerValue"].ToString();
}
 else
{
 model.CCM_CustomerValue = "";
}
 if (row["CCM_DutyPerson"] != null)
{
 model.CCM_DutyPerson = row["CCM_DutyPerson"].ToString();
}
 else
{
 model.CCM_DutyPerson = "";
}
 if (row["CCM_STime"] != null)
{
 model.CCM_STime = DateTime.Parse(row["CCM_STime"].ToString());
}
 if (row["CCM_Flow"] != null)
{
 model.CCM_Flow = row["CCM_Flow"].ToString();
}
 else
{
 model.CCM_Flow = "";
}
 if (row["CCM_Remarks"] != null)
{
 model.CCM_Remarks = row["CCM_Remarks"].ToString();
}
 else
{
 model.CCM_Remarks = "";
}
 if (row["CCM_Del"] != null)
{
 model.CCM_Del = int.Parse(row["CCM_Del"].ToString());
}
 else
{
 model.CCM_Del = 0;
}
 if (row["CCM_Creator"] != null)
{
 model.CCM_Creator = row["CCM_Creator"].ToString();
}
 else
{
 model.CCM_Creator = "";
}
 if (row["CCM_CTime"] != null)
{
 model.CCM_CTime = DateTime.Parse(row["CCM_CTime"].ToString());
}
 if (row["CCM_Mender"] != null)
{
 model.CCM_Mender = row["CCM_Mender"].ToString();
}
 else
{
 model.CCM_Mender = "";
}
 if (row["CCM_MTime"] != null)
{
 model.CCM_MTime = DateTime.Parse(row["CCM_MTime"].ToString());
}
 if (row["CCM_OrderNo"] != null)
{
 model.CCM_OrderNo = int.Parse(row["CCM_OrderNo"].ToString());
}
 else
{
 model.CCM_OrderNo = 0;
}
 if (row["CCM_CheckYN"] != null)
{
 model.CCM_CheckYN = int.Parse(row["CCM_CheckYN"].ToString());
}
 else
{
 model.CCM_CheckYN = 0;
}
 if (row["CCM_PayMent"] != null)
{
 model.CCM_PayMent = row["CCM_PayMent"].ToString();
}
 else
{
 model.CCM_PayMent = "";
}
 if (row["CCM_BillType"] != null)
{
 model.CCM_BillType = row["CCM_BillType"].ToString();
}
 else
{
 model.CCM_BillType = "";
}
 if (row["CCM_TechnicalRequire"] != null)
{
 model.CCM_TechnicalRequire = row["CCM_TechnicalRequire"].ToString();
}
 else
{
 model.CCM_TechnicalRequire = "";
}
 if (row["CCM_ProductPackaging"] != null)
{
 model.CCM_ProductPackaging = row["CCM_ProductPackaging"].ToString();
}
 else
{
 model.CCM_ProductPackaging = "";
}
 if (row["CCM_QualityRequire"] != null)
{
 model.CCM_QualityRequire = row["CCM_QualityRequire"].ToString();
}
 else
{
 model.CCM_QualityRequire = "";
}
 if (row["CCM_WarrantyPeriod"] != null)
{
 model.CCM_WarrantyPeriod = row["CCM_WarrantyPeriod"].ToString();
}
 else
{
 model.CCM_WarrantyPeriod = "";
}
 if (row["CCM_DeliveryReqyire"] != null)
{
 model.CCM_DeliveryReqyire = row["CCM_DeliveryReqyire"].ToString();
}
 else
{
 model.CCM_DeliveryReqyire = "";
}
 if (row["CCM_FhDetails"] != null)
{
 model.CCM_FhDetails = row["CCM_FhDetails"].ToString();
}
 else
{
 model.CCM_FhDetails = "";
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
strSql.Append(" FROM Cg_Contract_Manage ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

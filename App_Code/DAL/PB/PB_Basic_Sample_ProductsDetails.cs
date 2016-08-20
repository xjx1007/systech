 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class PB_Basic_Sample_ProductsDetails
   {
   public PB_Basic_Sample_ProductsDetails()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string PBSP_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from PB_Basic_Sample_ProductsDetails");
strSql.Append(" where PBSP_ID=@PBSP_ID ");
SqlParameter[] parameters = {
new SqlParameter("@PBSP_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = PBSP_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.PB_Basic_Sample_ProductsDetails model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into PB_Basic_Sample_ProductsDetails(");
strSql.Append("PBSP_ID,PBSP_FID,PBSP_ProductsType,PBSP_ProductsTypeName,PBSP_SuppNo,PBSP_SuppName,PBSP_ProductsEdition,PBSP_Number,PBSP_Price,PBSP_Remarks,PBSP_ProductsBarCode,PBSP_FProductsBarCode ");
strSql.Append(") values (");
strSql.Append("@PBSP_ID,@PBSP_FID,@PBSP_ProductsType,@PBSP_ProductsTypeName,@PBSP_SuppNo,@PBSP_SuppName,@PBSP_ProductsEdition,@PBSP_Number,@PBSP_Price,@PBSP_Remarks,@PBSP_ProductsBarCode,@PBSP_FProductsBarCode)");
SqlParameter[] parameters = {
 new SqlParameter("@PBSP_ID", SqlDbType.VarChar,50),
 new SqlParameter("@PBSP_FID", SqlDbType.VarChar,50),
 new SqlParameter("@PBSP_ProductsType", SqlDbType.VarChar,50),
 new SqlParameter("@PBSP_ProductsTypeName", SqlDbType.VarChar,50),
 new SqlParameter("@PBSP_SuppNo", SqlDbType.VarChar,50),
 new SqlParameter("@PBSP_SuppName", SqlDbType.VarChar,50),
 new SqlParameter("@PBSP_ProductsEdition", SqlDbType.VarChar,500),
 new SqlParameter("@PBSP_Number", SqlDbType.Int,4),
 new SqlParameter("@PBSP_Price", SqlDbType.Decimal,9),
 new SqlParameter("@PBSP_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@PBSP_ProductsBarCode", SqlDbType.VarChar,50),
 new SqlParameter("@PBSP_FProductsBarCode", SqlDbType.VarChar,50)};
parameters[0].Value = model.PBSP_ID;
parameters[1].Value = model.PBSP_FID;
parameters[2].Value = model.PBSP_ProductsType;
parameters[3].Value = model.PBSP_ProductsTypeName;
parameters[4].Value = model.PBSP_SuppNo;
parameters[5].Value = model.PBSP_SuppName;
parameters[6].Value = model.PBSP_ProductsEdition;
parameters[7].Value = model.PBSP_Number;
parameters[8].Value = model.PBSP_Price;
parameters[9].Value = model.PBSP_Remarks;
parameters[10].Value = model.PBSP_ProductsBarCode;
parameters[11].Value = model.PBSP_FProductsBarCode;
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
public bool Update(KNet.Model.PB_Basic_Sample_ProductsDetails model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update PB_Basic_Sample_ProductsDetails set ");
strSql.Append("PBSP_FID=@PBSP_FID,");
strSql.Append("PBSP_ProductsType=@PBSP_ProductsType,");
strSql.Append("PBSP_ProductsTypeName=@PBSP_ProductsTypeName,");
strSql.Append("PBSP_SuppNo=@PBSP_SuppNo,");
strSql.Append("PBSP_SuppName=@PBSP_SuppName,");
strSql.Append("PBSP_ProductsEdition=@PBSP_ProductsEdition,");
strSql.Append("PBSP_Number=@PBSP_Number,");
strSql.Append("PBSP_Price=@PBSP_Price,");
strSql.Append("PBSP_Remarks=@PBSP_Remarks,");
strSql.Append("PBSP_ProductsBarCode=@PBSP_ProductsBarCode,");
strSql.Append("PBSP_FProductsBarCode=@PBSP_FProductsBarCode");
strSql.Append(" where PBSP_ID=@PBSP_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@PBSP_FID", SqlDbType.VarChar,50),
 new SqlParameter("@PBSP_ProductsType", SqlDbType.VarChar,50),
 new SqlParameter("@PBSP_ProductsTypeName", SqlDbType.VarChar,50),
 new SqlParameter("@PBSP_SuppNo", SqlDbType.VarChar,50),
 new SqlParameter("@PBSP_SuppName", SqlDbType.VarChar,50),
 new SqlParameter("@PBSP_ProductsEdition", SqlDbType.VarChar,500),
 new SqlParameter("@PBSP_Number", SqlDbType.Int,4),
 new SqlParameter("@PBSP_Price", SqlDbType.Decimal,9),
 new SqlParameter("@PBSP_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@PBSP_ProductsBarCode", SqlDbType.VarChar,50),
 new SqlParameter("@PBSP_FProductsBarCode", SqlDbType.VarChar,50),
new SqlParameter("@PBSP_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.PBSP_FID;
parameters[1].Value = model.PBSP_ProductsType;
parameters[2].Value = model.PBSP_ProductsTypeName;
parameters[3].Value = model.PBSP_SuppNo;
parameters[4].Value = model.PBSP_SuppName;
parameters[5].Value = model.PBSP_ProductsEdition;
parameters[6].Value = model.PBSP_Number;
parameters[7].Value = model.PBSP_Price;
parameters[8].Value = model.PBSP_Remarks;
parameters[9].Value = model.PBSP_ProductsBarCode;
parameters[10].Value = model.PBSP_FProductsBarCode;
parameters[11].Value = model.PBSP_ID;

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
public bool Delete(string s_PBSP_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  PB_Basic_Sample_ProductsDetails  ");
strSql.Append(" where PBSP_ID=@PBSP_ID ");
SqlParameter[] parameters = {
new SqlParameter("@PBSP_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_PBSP_ID;
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
public bool UpdateDel(KNet.Model.PB_Basic_Sample_ProductsDetails model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   PB_Basic_Sample_ProductsDetails  Set ");
strSql.Append(" where PBSP_ID=@PBSP_ID ");
SqlParameter[] parameters = {
new SqlParameter("@PBSP_ID", SqlDbType.VarChar,50)};
parameters[0].Value =  model.PBSP_ID;

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
public bool DeleteList(string s_PBSP_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   PB_Basic_Sample_ProductsDetails  ");
strSql.Append(" where PBSP_ID in ('"+s_PBSP_ID+"')");

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
strSql.Append("Select * from  PB_Basic_Sample_ProductsDetails  ");
strSql.Append(" Where  PBSP_FID=@PBSP_FID ");
SqlParameter[] parameters = {
 new SqlParameter("@PBSP_FID", SqlDbType.VarChar,50),
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
strSql.Append("delete from  PB_Basic_Sample_ProductsDetails  ");
strSql.Append(" Where  PBSP_FID=@PBSP_FID ");
SqlParameter[] parameters = {
 new SqlParameter("@PBSP_FID", SqlDbType.VarChar,50),
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
public KNet.Model.PB_Basic_Sample_ProductsDetails GetModel(string PBSP_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from PB_Basic_Sample_ProductsDetails  ");
strSql.Append("where PBSP_ID=@PBSP_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@PBSP_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = PBSP_ID;
 KNet.Model.PB_Basic_Sample_ProductsDetails model = new KNet.Model.PB_Basic_Sample_ProductsDetails();
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
public KNet.Model.PB_Basic_Sample_ProductsDetails DataRowToModel(DataRow row)
{
KNet.Model.PB_Basic_Sample_ProductsDetails model=new KNet.Model.PB_Basic_Sample_ProductsDetails();
if (row != null)
{
 if (row["PBSP_ID"] != null)
{
 model.PBSP_ID = row["PBSP_ID"].ToString();
}
 else
{
 model.PBSP_ID = "";
}
 if (row["PBSP_FID"] != null)
{
 model.PBSP_FID = row["PBSP_FID"].ToString();
}
 else
{
 model.PBSP_FID = "";
}
 if (row["PBSP_ProductsType"] != null)
{
 model.PBSP_ProductsType = row["PBSP_ProductsType"].ToString();
}
 else
{
 model.PBSP_ProductsType = "";
}
 if (row["PBSP_ProductsTypeName"] != null)
{
 model.PBSP_ProductsTypeName = row["PBSP_ProductsTypeName"].ToString();
}
 else
{
 model.PBSP_ProductsTypeName = "";
}
 if (row["PBSP_SuppNo"] != null)
{
 model.PBSP_SuppNo = row["PBSP_SuppNo"].ToString();
}
 else
{
 model.PBSP_SuppNo = "";
}
 if (row["PBSP_SuppName"] != null)
{
 model.PBSP_SuppName = row["PBSP_SuppName"].ToString();
}
 else
{
 model.PBSP_SuppName = "";
}
 if (row["PBSP_ProductsEdition"] != null)
{
 model.PBSP_ProductsEdition = row["PBSP_ProductsEdition"].ToString();
}
 else
{
 model.PBSP_ProductsEdition = "";
}
 if (row["PBSP_Number"] != null)
{
 model.PBSP_Number = int.Parse(row["PBSP_Number"].ToString());
}
 else
{
 model.PBSP_Number = 0;
}
 if (row["PBSP_Price"] != null)
{
 model.PBSP_Price = Decimal.Parse(row["PBSP_Price"].ToString());
}
 else
{
 model.PBSP_Price = 0;
}
 if (row["PBSP_Remarks"] != null)
{
 model.PBSP_Remarks = row["PBSP_Remarks"].ToString();
}
 else
{
 model.PBSP_Remarks = "";
}
 if (row["PBSP_ProductsBarCode"] != null)
{
 model.PBSP_ProductsBarCode = row["PBSP_ProductsBarCode"].ToString();
}
 else
{
 model.PBSP_ProductsBarCode = "";
}
 if (row["PBSP_FProductsBarCode"] != null)
{
 model.PBSP_FProductsBarCode = row["PBSP_FProductsBarCode"].ToString();
}
 else
{
 model.PBSP_FProductsBarCode = "";
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
strSql.Append(" FROM PB_Basic_Sample_ProductsDetails ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

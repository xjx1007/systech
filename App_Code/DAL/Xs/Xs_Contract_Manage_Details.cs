 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class Xs_Contract_Manage_Details
   {
   public Xs_Contract_Manage_Details()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string XCMD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from Xs_Contract_Manage_Details");
strSql.Append(" where XCMD_ID=@XCMD_ID ");
SqlParameter[] parameters = {
new SqlParameter("@XCMD_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = XCMD_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.Xs_Contract_Manage_Details model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into Xs_Contract_Manage_Details(");
strSql.Append("XCMD_ID,XCMD_ContractNo,XCMD_ProductsName,XCMD_ProductsBarCode,XCMD_ProductsPattern,XCMD_ProductsUnits,XCMD_ContractAmount,XCMD_ContractUnitPrice,XCMD_ContractDiscount,XCMD_ContractTotalNet,XCMD_Contract_SalesUnitPrice,XCMD_Contract_SalesDiscount,XCMD_Contract_SalesTotalNet,XCMD_ContractRemarks,XCMD_ContractReceiving,XCMD_DateTime,XCMD_OwnallPID,XCMD_Battery,XCMD_Manual,XCMD_BNumber,XCMD_OrderBNumber,XCMD_OrderNumber,XCMD_MaterNumber,XCMD_IsFollow,XCMD_PlanNumber,XCMD_MaterPattern ");
strSql.Append(") values (");
strSql.Append("@XCMD_ID,@XCMD_ContractNo,@XCMD_ProductsName,@XCMD_ProductsBarCode,@XCMD_ProductsPattern,@XCMD_ProductsUnits,@XCMD_ContractAmount,@XCMD_ContractUnitPrice,@XCMD_ContractDiscount,@XCMD_ContractTotalNet,@XCMD_Contract_SalesUnitPrice,@XCMD_Contract_SalesDiscount,@XCMD_Contract_SalesTotalNet,@XCMD_ContractRemarks,@XCMD_ContractReceiving,@XCMD_DateTime,@XCMD_OwnallPID,@XCMD_Battery,@XCMD_Manual,@XCMD_BNumber,@XCMD_OrderBNumber,@XCMD_OrderNumber,@XCMD_MaterNumber,@XCMD_IsFollow,@XCMD_PlanNumber,@XCMD_MaterPattern)");
SqlParameter[] parameters = {
 new SqlParameter("@XCMD_ID", SqlDbType.VarChar,100),
 new SqlParameter("@XCMD_ContractNo", SqlDbType.VarChar,100),
 new SqlParameter("@XCMD_ProductsName", SqlDbType.VarChar,100),
 new SqlParameter("@XCMD_ProductsBarCode", SqlDbType.VarChar,100),
 new SqlParameter("@XCMD_ProductsPattern", SqlDbType.VarChar,100),
 new SqlParameter("@XCMD_ProductsUnits", SqlDbType.VarChar,100),

 new SqlParameter("@XCMD_ContractAmount", SqlDbType.Int,4),
 new SqlParameter("@XCMD_ContractUnitPrice", SqlDbType.Decimal,9),
 new SqlParameter("@XCMD_ContractDiscount", SqlDbType.Decimal,9),
 new SqlParameter("@XCMD_ContractTotalNet", SqlDbType.Decimal,9),
 new SqlParameter("@XCMD_Contract_SalesUnitPrice", SqlDbType.Decimal,9),
 new SqlParameter("@XCMD_Contract_SalesDiscount", SqlDbType.Decimal,9),
 new SqlParameter("@XCMD_Contract_SalesTotalNet", SqlDbType.Decimal,9),
 new SqlParameter("@XCMD_ContractRemarks", SqlDbType.VarChar,600),
 new SqlParameter("@XCMD_ContractReceiving", SqlDbType.Int,4),
 new SqlParameter("@XCMD_DateTime", SqlDbType.DateTime,8),
 new SqlParameter("@XCMD_OwnallPID", SqlDbType.VarChar,100),
 new SqlParameter("@XCMD_Battery", SqlDbType.VarChar,50),
 new SqlParameter("@XCMD_Manual", SqlDbType.VarChar,50),
 new SqlParameter("@XCMD_BNumber", SqlDbType.Int,4),
 new SqlParameter("@XCMD_OrderBNumber", SqlDbType.Int,4),
 new SqlParameter("@XCMD_OrderNumber", SqlDbType.VarChar,500),
 new SqlParameter("@XCMD_MaterNumber", SqlDbType.VarChar,500),
 new SqlParameter("@XCMD_IsFollow", SqlDbType.VarChar,50),
 new SqlParameter("@XCMD_PlanNumber", SqlDbType.VarChar,500),
 new SqlParameter("@XCMD_MaterPattern", SqlDbType.VarChar,500)};
parameters[0].Value = model.XCMD_ID;
parameters[1].Value = model.XCMD_ContractNo;
parameters[2].Value = model.XCMD_ProductsName;
parameters[3].Value = model.XCMD_ProductsBarCode;
parameters[4].Value = model.XCMD_ProductsPattern;
parameters[5].Value = model.XCMD_ProductsUnits;

parameters[6].Value = model.XCMD_ContractAmount;
parameters[7].Value = model.XCMD_ContractUnitPrice;
parameters[8].Value = model.XCMD_ContractDiscount;
parameters[9].Value = model.XCMD_ContractTotalNet;
parameters[10].Value = model.XCMD_Contract_SalesUnitPrice;
parameters[11].Value = model.XCMD_Contract_SalesDiscount;
parameters[12].Value = model.XCMD_Contract_SalesTotalNet;
parameters[13].Value = model.XCMD_ContractRemarks;
parameters[14].Value = model.XCMD_ContractReceiving;
parameters[15].Value = model.XCMD_DateTime;
parameters[16].Value = model.XCMD_OwnallPID;
parameters[17].Value = model.XCMD_Battery;
parameters[18].Value = model.XCMD_Manual;
parameters[19].Value = model.XCMD_BNumber;
parameters[20].Value = model.XCMD_OrderBNumber;
parameters[21].Value = model.XCMD_OrderNumber;
parameters[22].Value = model.XCMD_MaterNumber;
parameters[23].Value = model.XCMD_IsFollow;
parameters[24].Value = model.XCMD_PlanNumber;
parameters[25].Value = model.XCMD_MaterPattern;
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
public bool Update(KNet.Model.Xs_Contract_Manage_Details model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update Xs_Contract_Manage_Details set ");
strSql.Append("XCMD_ContractNo=@XCMD_ContractNo,");
strSql.Append("XCMD_ProductsName=@XCMD_ProductsName,");
strSql.Append("XCMD_ProductsBarCode=@XCMD_ProductsBarCode,");
strSql.Append("XCMD_ProductsPattern=@XCMD_ProductsPattern,");
strSql.Append("XCMD_ProductsUnits=@XCMD_ProductsUnits,");
strSql.Append("XCMD_ContractAmount=@XCMD_ContractAmount,");
strSql.Append("XCMD_ContractUnitPrice=@XCMD_ContractUnitPrice,");
strSql.Append("XCMD_ContractDiscount=@XCMD_ContractDiscount,");
strSql.Append("XCMD_ContractTotalNet=@XCMD_ContractTotalNet,");
strSql.Append("XCMD_Contract_SalesUnitPrice=@XCMD_Contract_SalesUnitPrice,");
strSql.Append("XCMD_Contract_SalesDiscount=@XCMD_Contract_SalesDiscount,");
strSql.Append("XCMD_Contract_SalesTotalNet=@XCMD_Contract_SalesTotalNet,");
strSql.Append("XCMD_ContractRemarks=@XCMD_ContractRemarks,");
strSql.Append("XCMD_ContractReceiving=@XCMD_ContractReceiving,");
strSql.Append("XCMD_DateTime=@XCMD_DateTime,");
strSql.Append("XCMD_OwnallPID=@XCMD_OwnallPID,");
strSql.Append("XCMD_Battery=@XCMD_Battery,");
strSql.Append("XCMD_Manual=@XCMD_Manual,");
strSql.Append("XCMD_BNumber=@XCMD_BNumber,");
strSql.Append("XCMD_OrderBNumber=@XCMD_OrderBNumber,");
strSql.Append("XCMD_OrderNumber=@XCMD_OrderNumber,");
strSql.Append("XCMD_MaterNumber=@XCMD_MaterNumber,");
strSql.Append("XCMD_IsFollow=@XCMD_IsFollow,");
strSql.Append("XCMD_PlanNumber=@XCMD_PlanNumber,");
strSql.Append("XCMD_MaterPattern=@XCMD_MaterPattern");
strSql.Append(" where XCMD_ID=@XCMD_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@XCMD_ID", SqlDbType.VarChar,100),
 new SqlParameter("@XCMD_ContractNo", SqlDbType.VarChar,100),
 new SqlParameter("@XCMD_ProductsName", SqlDbType.VarChar,100),
 new SqlParameter("@XCMD_ProductsBarCode", SqlDbType.VarChar,100),
 new SqlParameter("@XCMD_ProductsPattern", SqlDbType.VarChar,100),
 new SqlParameter("@XCMD_ProductsUnits", SqlDbType.VarChar,100),
 new SqlParameter("@XCMD_ContractAmount", SqlDbType.Int,4),
 new SqlParameter("@XCMD_ContractUnitPrice", SqlDbType.Decimal,9),
 new SqlParameter("@XCMD_ContractDiscount", SqlDbType.Decimal,9),
 new SqlParameter("@XCMD_ContractTotalNet", SqlDbType.Decimal,9),
 new SqlParameter("@XCMD_Contract_SalesUnitPrice", SqlDbType.Decimal,9),
 new SqlParameter("@XCMD_Contract_SalesDiscount", SqlDbType.Decimal,9),
 new SqlParameter("@XCMD_Contract_SalesTotalNet", SqlDbType.Decimal,9),
 new SqlParameter("@XCMD_ContractRemarks", SqlDbType.VarChar,600),
 new SqlParameter("@XCMD_ContractReceiving", SqlDbType.Int,4),
 new SqlParameter("@XCMD_DateTime", SqlDbType.DateTime,8),
 new SqlParameter("@XCMD_OwnallPID", SqlDbType.VarChar,100),
 new SqlParameter("@XCMD_Battery", SqlDbType.VarChar,50),
 new SqlParameter("@XCMD_Manual", SqlDbType.VarChar,50),
 new SqlParameter("@XCMD_BNumber", SqlDbType.Int,4),
 new SqlParameter("@XCMD_OrderBNumber", SqlDbType.Int,4),
 new SqlParameter("@XCMD_OrderNumber", SqlDbType.VarChar,500),
 new SqlParameter("@XCMD_MaterNumber", SqlDbType.VarChar,500),
 new SqlParameter("@XCMD_IsFollow", SqlDbType.VarChar,50),
 new SqlParameter("@XCMD_PlanNumber", SqlDbType.VarChar,500),
 new SqlParameter("@XCMD_MaterPattern", SqlDbType.VarChar,500),
new SqlParameter("@XCMD_ID", SqlDbType.VarChar,100)};
parameters[0].Value = model.XCMD_ID;
parameters[1].Value = model.XCMD_ContractNo;
parameters[2].Value = model.XCMD_ProductsName;
parameters[3].Value = model.XCMD_ProductsBarCode;
parameters[4].Value = model.XCMD_ProductsPattern;
parameters[5].Value = model.XCMD_ProductsUnits;
parameters[6].Value = model.XCMD_ContractAmount;
parameters[7].Value = model.XCMD_ContractUnitPrice;
parameters[8].Value = model.XCMD_ContractDiscount;
parameters[9].Value = model.XCMD_ContractTotalNet;
parameters[10].Value = model.XCMD_Contract_SalesUnitPrice;
parameters[11].Value = model.XCMD_Contract_SalesDiscount;
parameters[12].Value = model.XCMD_Contract_SalesTotalNet;
parameters[13].Value = model.XCMD_ContractRemarks;
parameters[14].Value = model.XCMD_ContractReceiving;
parameters[15].Value = model.XCMD_DateTime;
parameters[16].Value = model.XCMD_OwnallPID;
parameters[17].Value = model.XCMD_Battery;
parameters[18].Value = model.XCMD_Manual;
parameters[19].Value = model.XCMD_BNumber;
parameters[20].Value = model.XCMD_OrderBNumber;
parameters[21].Value = model.XCMD_OrderNumber;
parameters[22].Value = model.XCMD_MaterNumber;
parameters[23].Value = model.XCMD_IsFollow;
parameters[24].Value = model.XCMD_PlanNumber;
parameters[25].Value = model.XCMD_MaterPattern;
parameters[26].Value = model.XCMD_ID;

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
public bool Delete(string s_XCMD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  Xs_Contract_Manage_Details  ");
strSql.Append(" where XCMD_ID=@XCMD_ID ");
SqlParameter[] parameters = {
new SqlParameter("@XCMD_ID", SqlDbType.VarChar,100)};
parameters[0].Value = s_XCMD_ID;
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
public bool UpdateDel(KNet.Model.Xs_Contract_Manage_Details model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   Xs_Contract_Manage_Details  Set ");
strSql.Append(" where XCMD_ID=@XCMD_ID ");
SqlParameter[] parameters = {
new SqlParameter("@XCMD_ID", SqlDbType.VarChar,100)};
parameters[0].Value =  model.XCMD_ID;

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
public bool DeleteList(string s_XCMD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   Xs_Contract_Manage_Details  ");
strSql.Append(" where XCMD_ID in ('"+s_XCMD_ID+"')");

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
strSql.Append("Select * from  Xs_Contract_Manage_Details  ");
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
strSql.Append("delete from  Xs_Contract_Manage_Details  ");
strSql.Append(" where XCMD_ContractNo=@XCMD_ContractNo ");
SqlParameter[] parameters = {
					new SqlParameter("@XCMD_ContractNo", SqlDbType.VarChar,50)};
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
public KNet.Model.Xs_Contract_Manage_Details GetModel(string XCMD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from Xs_Contract_Manage_Details  ");
strSql.Append("where XCMD_ID=@XCMD_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@XCMD_ID", SqlDbType.VarChar,100)
};
parameters[0].Value = XCMD_ID;
 KNet.Model.Xs_Contract_Manage_Details model = new KNet.Model.Xs_Contract_Manage_Details();
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
public KNet.Model.Xs_Contract_Manage_Details DataRowToModel(DataRow row)
{
KNet.Model.Xs_Contract_Manage_Details model=new KNet.Model.Xs_Contract_Manage_Details();
if (row != null)
{
 if (row["XCMD_ID"] != null)
{
 model.XCMD_ID = row["XCMD_ID"].ToString();
}
 else
{
 model.XCMD_ID = "";
}
 if (row["XCMD_ContractNo"] != null)
{
 model.XCMD_ContractNo = row["XCMD_ContractNo"].ToString();
}
 else
{
 model.XCMD_ContractNo = "";
}
 if (row["XCMD_ProductsName"] != null)
{
 model.XCMD_ProductsName = row["XCMD_ProductsName"].ToString();
}
 else
{
 model.XCMD_ProductsName = "";
}
 if (row["XCMD_ProductsBarCode"] != null)
{
 model.XCMD_ProductsBarCode = row["XCMD_ProductsBarCode"].ToString();
}
 else
{
 model.XCMD_ProductsBarCode = "";
}
 if (row["XCMD_ProductsPattern"] != null)
{
 model.XCMD_ProductsPattern = row["XCMD_ProductsPattern"].ToString();
}
 else
{
 model.XCMD_ProductsPattern = "";
}
 if (row["XCMD_ProductsUnits"] != null)
{
 model.XCMD_ProductsUnits = row["XCMD_ProductsUnits"].ToString();
}
 else
{
 model.XCMD_ProductsUnits = "";
}
 if (row["XCMD_ContractAmount"] != null)
{
 model.XCMD_ContractAmount = int.Parse(row["XCMD_ContractAmount"].ToString());
}
 else
{
 model.XCMD_ContractAmount = 0;
}
 if (row["XCMD_ContractUnitPrice"] != null)
{
 model.XCMD_ContractUnitPrice = Decimal.Parse(row["XCMD_ContractUnitPrice"].ToString());
}
 else
{
 model.XCMD_ContractUnitPrice = 0;
}
 if (row["XCMD_ContractDiscount"] != null)
{
 model.XCMD_ContractDiscount = Decimal.Parse(row["XCMD_ContractDiscount"].ToString());
}
 else
{
 model.XCMD_ContractDiscount = 0;
}
 if (row["XCMD_ContractTotalNet"] != null)
{
 model.XCMD_ContractTotalNet = Decimal.Parse(row["XCMD_ContractTotalNet"].ToString());
}
 else
{
 model.XCMD_ContractTotalNet = 0;
}
 if (row["XCMD_Contract_SalesUnitPrice"] != null)
{
 model.XCMD_Contract_SalesUnitPrice = Decimal.Parse(row["XCMD_Contract_SalesUnitPrice"].ToString());
}
 else
{
 model.XCMD_Contract_SalesUnitPrice = 0;
}
 if (row["XCMD_Contract_SalesDiscount"] != null)
{
 model.XCMD_Contract_SalesDiscount = Decimal.Parse(row["XCMD_Contract_SalesDiscount"].ToString());
}
 else
{
 model.XCMD_Contract_SalesDiscount = 0;
}
 if (row["XCMD_Contract_SalesTotalNet"] != null)
{
 model.XCMD_Contract_SalesTotalNet = Decimal.Parse(row["XCMD_Contract_SalesTotalNet"].ToString());
}
 else
{
 model.XCMD_Contract_SalesTotalNet = 0;
}
 if (row["XCMD_ContractRemarks"] != null)
{
 model.XCMD_ContractRemarks = row["XCMD_ContractRemarks"].ToString();
}
 else
{
 model.XCMD_ContractRemarks = "";
}
 if (row["XCMD_ContractReceiving"] != null)
{
 model.XCMD_ContractReceiving = int.Parse(row["XCMD_ContractReceiving"].ToString());
}
 else
{
 model.XCMD_ContractReceiving = 0;
}
 if (row["XCMD_DateTime"] != null)
{
 model.XCMD_DateTime = DateTime.Parse(row["XCMD_DateTime"].ToString());
}
 if (row["XCMD_OwnallPID"] != null)
{
 model.XCMD_OwnallPID = row["XCMD_OwnallPID"].ToString();
}
 else
{
 model.XCMD_OwnallPID = "";
}
 if (row["XCMD_Battery"] != null)
{
 model.XCMD_Battery = row["XCMD_Battery"].ToString();
}
 else
{
 model.XCMD_Battery = "";
}
 if (row["XCMD_Manual"] != null)
{
 model.XCMD_Manual = row["XCMD_Manual"].ToString();
}
 else
{
 model.XCMD_Manual = "";
}
 if (row["XCMD_BNumber"] != null)
{
 model.XCMD_BNumber = int.Parse(row["XCMD_BNumber"].ToString());
}
 else
{
 model.XCMD_BNumber = 0;
}
 if (row["XCMD_OrderBNumber"] != null)
{
 model.XCMD_OrderBNumber = int.Parse(row["XCMD_OrderBNumber"].ToString());
}
 else
{
 model.XCMD_OrderBNumber = 0;
}
 if (row["XCMD_OrderNumber"] != null)
{
 model.XCMD_OrderNumber = row["XCMD_OrderNumber"].ToString();
}
 else
{
 model.XCMD_OrderNumber = "";
}
 if (row["XCMD_MaterNumber"] != null)
{
 model.XCMD_MaterNumber = row["XCMD_MaterNumber"].ToString();
}
 else
{
 model.XCMD_MaterNumber = "";
}
 if (row["XCMD_IsFollow"] != null)
{
 model.XCMD_IsFollow = row["XCMD_IsFollow"].ToString();
}
 else
{
 model.XCMD_IsFollow = "";
}
 if (row["XCMD_PlanNumber"] != null)
{
 model.XCMD_PlanNumber = row["XCMD_PlanNumber"].ToString();
}
 else
{
 model.XCMD_PlanNumber = "";
}
 if (row["XCMD_MaterPattern"] != null)
{
 model.XCMD_MaterPattern = row["XCMD_MaterPattern"].ToString();
}
 else
{
 model.XCMD_MaterPattern = "";
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
strSql.Append(" FROM Xs_Contract_Manage_Details ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

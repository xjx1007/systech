 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class Wl_Customer_Price_Details
   {
   public Wl_Customer_Price_Details()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string WCPD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from Wl_Customer_Price_Details");
strSql.Append(" where WCPD_ID=@WCPD_ID ");
SqlParameter[] parameters = {
new SqlParameter("@WCPD_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = WCPD_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.Wl_Customer_Price_Details model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into Wl_Customer_Price_Details(");
strSql.Append("WCPD_ID,WCPD_FID,WCPD_Provice,WCPD_City,WCPD_MinTime,WCPD_MaxTime,WCPD_MinMoney,WCPD_Price,WCPD_DeliveryFee,WCPD_UpstairsCost,WCPD_WarehouseEntry150Low,WCPD_WarehouseEntry150Up,WCPD_Insured,WCPD_SignBill,WCPD_BigLateTime,WCPD_Del,WCPD_Type,WCPD_PickUpCost,WCPD_DeliveryFeePrice ");
strSql.Append(") values (");
strSql.Append("@WCPD_ID,@WCPD_FID,@WCPD_Provice,@WCPD_City,@WCPD_MinTime,@WCPD_MaxTime,@WCPD_MinMoney,@WCPD_Price,@WCPD_DeliveryFee,@WCPD_UpstairsCost,@WCPD_WarehouseEntry150Low,@WCPD_WarehouseEntry150Up,@WCPD_Insured,@WCPD_SignBill,@WCPD_BigLateTime,@WCPD_Del,@WCPD_Type,@WCPD_PickUpCost,@WCPD_DeliveryFeePrice)");
SqlParameter[] parameters = {
 new SqlParameter("@WCPD_ID", SqlDbType.VarChar,50),
 new SqlParameter("@WCPD_FID", SqlDbType.VarChar,50),
 new SqlParameter("@WCPD_Provice", SqlDbType.VarChar,150),
 new SqlParameter("@WCPD_City", SqlDbType.VarChar,150),
 new SqlParameter("@WCPD_MinTime", SqlDbType.VarChar,150),
 new SqlParameter("@WCPD_MaxTime", SqlDbType.VarChar,150),
 new SqlParameter("@WCPD_MinMoney", SqlDbType.Decimal,9),
 new SqlParameter("@WCPD_Price", SqlDbType.Decimal,9),
 new SqlParameter("@WCPD_DeliveryFee", SqlDbType.Decimal,9),
 new SqlParameter("@WCPD_UpstairsCost", SqlDbType.Decimal,9),
 new SqlParameter("@WCPD_WarehouseEntry150Low", SqlDbType.Decimal,9),
 new SqlParameter("@WCPD_WarehouseEntry150Up", SqlDbType.Decimal,9),
 new SqlParameter("@WCPD_Insured", SqlDbType.Decimal,9),
 new SqlParameter("@WCPD_SignBill", SqlDbType.Decimal,9),
 new SqlParameter("@WCPD_BigLateTime", SqlDbType.VarChar,500),
 new SqlParameter("@WCPD_Del", SqlDbType.Int,4),
 new SqlParameter("@WCPD_Type", SqlDbType.VarChar,150),
 new SqlParameter("@WCPD_PickUpCost", SqlDbType.Decimal,9),
 new SqlParameter("@WCPD_DeliveryFeePrice", SqlDbType.Decimal,9)};
parameters[0].Value = model.WCPD_ID;
parameters[1].Value = model.WCPD_FID;
parameters[2].Value = model.WCPD_Provice;
parameters[3].Value = model.WCPD_City;
parameters[4].Value = model.WCPD_MinTime;
parameters[5].Value = model.WCPD_MaxTime;
parameters[6].Value = model.WCPD_MinMoney;
parameters[7].Value = model.WCPD_Price;
parameters[8].Value = model.WCPD_DeliveryFee;
parameters[9].Value = model.WCPD_UpstairsCost;
parameters[10].Value = model.WCPD_WarehouseEntry150Low;
parameters[11].Value = model.WCPD_WarehouseEntry150Up;
parameters[12].Value = model.WCPD_Insured;
parameters[13].Value = model.WCPD_SignBill;
parameters[14].Value = model.WCPD_BigLateTime;
parameters[15].Value = model.WCPD_Del;
parameters[16].Value = model.WCPD_Type;
parameters[17].Value = model.WCPD_PickUpCost;
parameters[18].Value = model.WCPD_DeliveryFeePrice;
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
public bool Update(KNet.Model.Wl_Customer_Price_Details model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update Wl_Customer_Price_Details set ");
strSql.Append("WCPD_FID=@WCPD_FID,");
strSql.Append("WCPD_Provice=@WCPD_Provice,");
strSql.Append("WCPD_City=@WCPD_City,");
strSql.Append("WCPD_MinTime=@WCPD_MinTime,");
strSql.Append("WCPD_MaxTime=@WCPD_MaxTime,");
strSql.Append("WCPD_MinMoney=@WCPD_MinMoney,");
strSql.Append("WCPD_Price=@WCPD_Price,");
strSql.Append("WCPD_DeliveryFee=@WCPD_DeliveryFee,");
strSql.Append("WCPD_UpstairsCost=@WCPD_UpstairsCost,");
strSql.Append("WCPD_WarehouseEntry150Low=@WCPD_WarehouseEntry150Low,");
strSql.Append("WCPD_WarehouseEntry150Up=@WCPD_WarehouseEntry150Up,");
strSql.Append("WCPD_Insured=@WCPD_Insured,");
strSql.Append("WCPD_SignBill=@WCPD_SignBill,");
strSql.Append("WCPD_BigLateTime=@WCPD_BigLateTime,");
strSql.Append("WCPD_Del=@WCPD_Del,");
strSql.Append("WCPD_Type=@WCPD_Type,");
strSql.Append("WCPD_PickUpCost=@WCPD_PickUpCost,");
strSql.Append("WCPD_DeliveryFeePrice=@WCPD_DeliveryFeePrice");
strSql.Append(" where WCPD_ID=@WCPD_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@WCPD_FID", SqlDbType.VarChar,50),
 new SqlParameter("@WCPD_Provice", SqlDbType.VarChar,150),
 new SqlParameter("@WCPD_City", SqlDbType.VarChar,150),
 new SqlParameter("@WCPD_MinTime", SqlDbType.VarChar,150),
 new SqlParameter("@WCPD_MaxTime", SqlDbType.VarChar,150),
 new SqlParameter("@WCPD_MinMoney", SqlDbType.Decimal,9),
 new SqlParameter("@WCPD_Price", SqlDbType.Decimal,9),
 new SqlParameter("@WCPD_DeliveryFee", SqlDbType.Decimal,9),
 new SqlParameter("@WCPD_UpstairsCost", SqlDbType.Decimal,9),
 new SqlParameter("@WCPD_WarehouseEntry150Low", SqlDbType.Decimal,9),
 new SqlParameter("@WCPD_WarehouseEntry150Up", SqlDbType.Decimal,9),
 new SqlParameter("@WCPD_Insured", SqlDbType.Decimal,9),
 new SqlParameter("@WCPD_SignBill", SqlDbType.Decimal,9),
 new SqlParameter("@WCPD_BigLateTime", SqlDbType.VarChar,500),
 new SqlParameter("@WCPD_Del", SqlDbType.Int,4),
 new SqlParameter("@WCPD_Type", SqlDbType.VarChar,150),
 new SqlParameter("@WCPD_PickUpCost", SqlDbType.Decimal,9),
 new SqlParameter("@WCPD_DeliveryFeePrice", SqlDbType.Decimal,9),
new SqlParameter("@WCPD_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.WCPD_FID;
parameters[1].Value = model.WCPD_Provice;
parameters[2].Value = model.WCPD_City;
parameters[3].Value = model.WCPD_MinTime;
parameters[4].Value = model.WCPD_MaxTime;
parameters[5].Value = model.WCPD_MinMoney;
parameters[6].Value = model.WCPD_Price;
parameters[7].Value = model.WCPD_DeliveryFee;
parameters[8].Value = model.WCPD_UpstairsCost;
parameters[9].Value = model.WCPD_WarehouseEntry150Low;
parameters[10].Value = model.WCPD_WarehouseEntry150Up;
parameters[11].Value = model.WCPD_Insured;
parameters[12].Value = model.WCPD_SignBill;
parameters[13].Value = model.WCPD_BigLateTime;
parameters[14].Value = model.WCPD_Del;
parameters[15].Value = model.WCPD_Type;
parameters[16].Value = model.WCPD_PickUpCost;
parameters[17].Value = model.WCPD_DeliveryFeePrice;
parameters[18].Value = model.WCPD_ID;

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
public bool Delete(string s_WCPD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  Wl_Customer_Price_Details  ");
strSql.Append(" where WCPD_ID=@WCPD_ID ");
SqlParameter[] parameters = {
new SqlParameter("@WCPD_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_WCPD_ID;
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
public bool UpdateDel(KNet.Model.Wl_Customer_Price_Details model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   Wl_Customer_Price_Details  Set ");
strSql.Append("  WCPD_DeliveryFee=@WCPD_DeliveryFee ");
strSql.Append("  WCPD_Del=@WCPD_Del ");
strSql.Append("  WCPD_DeliveryFeePrice=@WCPD_DeliveryFeePrice ");
strSql.Append(" where WCPD_ID=@WCPD_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@WCPD_DeliveryFee", SqlDbType.Decimal,9),
 new SqlParameter("@WCPD_Del", SqlDbType.Int,4),
 new SqlParameter("@WCPD_DeliveryFeePrice", SqlDbType.Decimal,9),
new SqlParameter("@WCPD_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.WCPD_DeliveryFee;
parameters[1].Value = model.WCPD_Del;
parameters[2].Value = model.WCPD_DeliveryFeePrice;
parameters[3].Value =  model.WCPD_ID;

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
public bool DeleteList(string s_WCPD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   Wl_Customer_Price_Details  ");
strSql.Append(" where WCPD_ID in ('"+s_WCPD_ID+"')");

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
strSql.Append("delete from  Wl_Customer_Price_Details  ");
strSql.Append(" Where  WCPD_FID=@WCPD_FID ");
SqlParameter[] parameters = {
 new SqlParameter("@WCPD_FID", SqlDbType.VarChar,50),
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
public KNet.Model.Wl_Customer_Price_Details GetModel(string WCPD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from Wl_Customer_Price_Details  ");
strSql.Append("where WCPD_ID=@WCPD_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@WCPD_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = WCPD_ID;
 KNet.Model.Wl_Customer_Price_Details model = new KNet.Model.Wl_Customer_Price_Details();
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
public KNet.Model.Wl_Customer_Price_Details DataRowToModel(DataRow row)
{
KNet.Model.Wl_Customer_Price_Details model=new KNet.Model.Wl_Customer_Price_Details();
if (row != null)
{
 if (row["WCPD_ID"] != null)
{
 model.WCPD_ID = row["WCPD_ID"].ToString();
}
 else
{
 model.WCPD_ID = "";
}
 if (row["WCPD_FID"] != null)
{
 model.WCPD_FID = row["WCPD_FID"].ToString();
}
 else
{
 model.WCPD_FID = "";
}
 if (row["WCPD_Provice"] != null)
{
 model.WCPD_Provice = row["WCPD_Provice"].ToString();
}
 else
{
 model.WCPD_Provice = "";
}
 if (row["WCPD_City"] != null)
{
 model.WCPD_City = row["WCPD_City"].ToString();
}
 else
{
 model.WCPD_City = "";
}
 if (row["WCPD_MinTime"] != null)
{
 model.WCPD_MinTime = row["WCPD_MinTime"].ToString();
}
 else
{
 model.WCPD_MinTime = "";
}
 if (row["WCPD_MaxTime"] != null)
{
 model.WCPD_MaxTime = row["WCPD_MaxTime"].ToString();
}
 else
{
 model.WCPD_MaxTime = "";
}
 if (row["WCPD_MinMoney"] != null)
{
 model.WCPD_MinMoney = Decimal.Parse(row["WCPD_MinMoney"].ToString());
}
 else
{
 model.WCPD_MinMoney = 0;
}
 if (row["WCPD_Price"] != null)
{
 model.WCPD_Price = Decimal.Parse(row["WCPD_Price"].ToString());
}
 else
{
 model.WCPD_Price = 0;
}
 if (row["WCPD_DeliveryFee"] != null)
{
 model.WCPD_DeliveryFee = Decimal.Parse(row["WCPD_DeliveryFee"].ToString());
}
 else
{
 model.WCPD_DeliveryFee = 0;
}
 if (row["WCPD_UpstairsCost"] != null)
{
 model.WCPD_UpstairsCost = Decimal.Parse(row["WCPD_UpstairsCost"].ToString());
}
 else
{
 model.WCPD_UpstairsCost = 0;
}
 if (row["WCPD_WarehouseEntry150Low"] != null)
{
 model.WCPD_WarehouseEntry150Low = Decimal.Parse(row["WCPD_WarehouseEntry150Low"].ToString());
}
 else
{
 model.WCPD_WarehouseEntry150Low = 0;
}
 if (row["WCPD_WarehouseEntry150Up"] != null)
{
 model.WCPD_WarehouseEntry150Up = Decimal.Parse(row["WCPD_WarehouseEntry150Up"].ToString());
}
 else
{
 model.WCPD_WarehouseEntry150Up = 0;
}
 if (row["WCPD_Insured"] != null)
{
 model.WCPD_Insured = Decimal.Parse(row["WCPD_Insured"].ToString());
}
 else
{
 model.WCPD_Insured = 0;
}
 if (row["WCPD_SignBill"] != null)
{
 model.WCPD_SignBill = Decimal.Parse(row["WCPD_SignBill"].ToString());
}
 else
{
 model.WCPD_SignBill = 0;
}
 if (row["WCPD_BigLateTime"] != null)
{
 model.WCPD_BigLateTime = row["WCPD_BigLateTime"].ToString();
}
 else
{
 model.WCPD_BigLateTime = "";
}
 if (row["WCPD_Del"] != null)
{
 model.WCPD_Del = int.Parse(row["WCPD_Del"].ToString());
}
 else
{
 model.WCPD_Del = 0;
}
 if (row["WCPD_Type"] != null)
{
 model.WCPD_Type = row["WCPD_Type"].ToString();
}
 else
{
 model.WCPD_Type = "";
}
 if (row["WCPD_PickUpCost"] != null)
{
 model.WCPD_PickUpCost = Decimal.Parse(row["WCPD_PickUpCost"].ToString());
}
 else
{
 model.WCPD_PickUpCost = 0;
}
 if (row["WCPD_DeliveryFeePrice"] != null)
{
 model.WCPD_DeliveryFeePrice = Decimal.Parse(row["WCPD_DeliveryFeePrice"].ToString());
}
 else
{
 model.WCPD_DeliveryFeePrice = 0;
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
strSql.Append(" FROM Wl_Customer_Price_Details ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

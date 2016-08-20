 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class Xs_Sales_Freight
   {
   public Xs_Sales_Freight()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string XSF_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from Xs_Sales_Freight");
strSql.Append(" where XSF_ID=@XSF_ID ");
SqlParameter[] parameters = {
new SqlParameter("@XSF_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = XSF_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
public bool ExistsFID(string XSF_FID)
{
    StringBuilder strSql = new StringBuilder();
    strSql.Append("select count(1) from Xs_Sales_Freight");
    strSql.Append(" where XSF_FID=@XSF_FID ");
    SqlParameter[] parameters = {
new SqlParameter("@XSF_FID", SqlDbType.VarChar,50)
};
    parameters[0].Value = XSF_FID;
    return DbHelperSQL.Exists(strSql.ToString(), parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.Xs_Sales_Freight model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into Xs_Sales_Freight(");
strSql.Append("XSF_ID,XSF_Code,XSF_FID,XSF_Stime,XSF_Description,XSF_Type,XSF_CustomerValue,XSF_CustomerName,XSF_FPercent,XSF_FMoney,XSF_Percent,XSF_Money,XSF_TotalMoney,XSF_TotalNumber,XSF_Price,XSF_Remarks,XSF_CheckYN,XSF_Flow,XSF_Del,XSF_CTime,XSF_Creator,XSF_MTime,XSF_Mender,XSF_KDNameCode,XSF_KDName,XSF_KDCode,XSF_State,XSF_FSuppNo,XSF_Address,XSF_DutyPerson,XSF_WuliuType,XSF_WuliuPrice,XSF_WuliuMoney,XSF_TimeDays,XSF_MinMoney,XSF_PickUpCost,XSF_DeliveryFee,XSF_UpstairsCost,XSF_UpstairsCostMoney,XSF_WareHouseEntry150Low,XSF_Insured,XSF_InsuredMoney,XSF_SignBill,XSF_BigLateTime,XSF_Weight,XSF_WeightDetails,XSF_Volume,XSF_VolumeDetails,XSF_TotalMoneyDetails,XSF_WuliuID,XSF_Province,XSF_City ");
strSql.Append(") values (");
strSql.Append("@XSF_ID,@XSF_Code,@XSF_FID,@XSF_Stime,@XSF_Description,@XSF_Type,@XSF_CustomerValue,@XSF_CustomerName,@XSF_FPercent,@XSF_FMoney,@XSF_Percent,@XSF_Money,@XSF_TotalMoney,@XSF_TotalNumber,@XSF_Price,@XSF_Remarks,@XSF_CheckYN,@XSF_Flow,@XSF_Del,@XSF_CTime,@XSF_Creator,@XSF_MTime,@XSF_Mender,@XSF_KDNameCode,@XSF_KDName,@XSF_KDCode,@XSF_State,@XSF_FSuppNo,@XSF_Address,@XSF_DutyPerson,@XSF_WuliuType,@XSF_WuliuPrice,@XSF_WuliuMoney,@XSF_TimeDays,@XSF_MinMoney,@XSF_PickUpCost,@XSF_DeliveryFee,@XSF_UpstairsCost,@XSF_UpstairsCostMoney,@XSF_WareHouseEntry150Low,@XSF_Insured,@XSF_InsuredMoney,@XSF_SignBill,@XSF_BigLateTime,@XSF_Weight,@XSF_WeightDetails,@XSF_Volume,@XSF_VolumeDetails,@XSF_TotalMoneyDetails,@XSF_WuliuID,@XSF_Province,@XSF_City)");
SqlParameter[] parameters = {
 new SqlParameter("@XSF_ID", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_Code", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_FID", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_Stime", SqlDbType.DateTime,8),
 new SqlParameter("@XSF_Description", SqlDbType.VarChar,250),
 new SqlParameter("@XSF_Type", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_CustomerValue", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_CustomerName", SqlDbType.VarChar,150),
 new SqlParameter("@XSF_FPercent", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_FMoney", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_Percent", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_Money", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_TotalMoney", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_TotalNumber", SqlDbType.Int,4),
 new SqlParameter("@XSF_Price", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@XSF_CheckYN", SqlDbType.Int,4),
 new SqlParameter("@XSF_Flow", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_Del", SqlDbType.Int,4),
 new SqlParameter("@XSF_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@XSF_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@XSF_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_KDNameCode", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_KDName", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_KDCode", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_State", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_FSuppNo", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_Address", SqlDbType.VarChar,850),
 new SqlParameter("@XSF_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_WuliuType", SqlDbType.VarChar,150),
 new SqlParameter("@XSF_WuliuPrice", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_WuliuMoney", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_TimeDays", SqlDbType.Int,4),
 new SqlParameter("@XSF_MinMoney", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_PickUpCost", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_DeliveryFee", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_UpstairsCost", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_UpstairsCostMoney", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_WareHouseEntry150Low", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_Insured", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_InsuredMoney", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_SignBill", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_BigLateTime", SqlDbType.VarChar,150),
 new SqlParameter("@XSF_Weight", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_WeightDetails", SqlDbType.VarChar,300),
 new SqlParameter("@XSF_Volume", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_VolumeDetails", SqlDbType.VarChar,300),
 new SqlParameter("@XSF_TotalMoneyDetails", SqlDbType.VarChar,300),
 new SqlParameter("@XSF_WuliuID", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_Province", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_City", SqlDbType.VarChar,50)};
parameters[0].Value = model.XSF_ID;
parameters[1].Value = model.XSF_Code;
parameters[2].Value = model.XSF_FID;
parameters[3].Value = model.XSF_Stime;
parameters[4].Value = model.XSF_Description;
parameters[5].Value = model.XSF_Type;
parameters[6].Value = model.XSF_CustomerValue;
parameters[7].Value = model.XSF_CustomerName;
parameters[8].Value = model.XSF_FPercent;
parameters[9].Value = model.XSF_FMoney;
parameters[10].Value = model.XSF_Percent;
parameters[11].Value = model.XSF_Money;
parameters[12].Value = model.XSF_TotalMoney;
parameters[13].Value = model.XSF_TotalNumber;
parameters[14].Value = model.XSF_Price;
parameters[15].Value = model.XSF_Remarks;
parameters[16].Value = model.XSF_CheckYN;
parameters[17].Value = model.XSF_Flow;
parameters[18].Value = model.XSF_Del;
parameters[19].Value = model.XSF_CTime;
parameters[20].Value = model.XSF_Creator;
parameters[21].Value = model.XSF_MTime;
parameters[22].Value = model.XSF_Mender;
parameters[23].Value = model.XSF_KDNameCode;
parameters[24].Value = model.XSF_KDName;
parameters[25].Value = model.XSF_KDCode;
parameters[26].Value = model.XSF_State;
parameters[27].Value = model.XSF_FSuppNo;
parameters[28].Value = model.XSF_Address;
parameters[29].Value = model.XSF_DutyPerson;
parameters[30].Value = model.XSF_WuliuType;
parameters[31].Value = model.XSF_WuliuPrice;
parameters[32].Value = model.XSF_WuliuMoney;
parameters[33].Value = model.XSF_TimeDays;
parameters[34].Value = model.XSF_MinMoney;
parameters[35].Value = model.XSF_PickUpCost;
parameters[36].Value = model.XSF_DeliveryFee;
parameters[37].Value = model.XSF_UpstairsCost;
parameters[38].Value = model.XSF_UpstairsCostMoney;
parameters[39].Value = model.XSF_WareHouseEntry150Low;
parameters[40].Value = model.XSF_Insured;
parameters[41].Value = model.XSF_InsuredMoney;
parameters[42].Value = model.XSF_SignBill;
parameters[43].Value = model.XSF_BigLateTime;
parameters[44].Value = model.XSF_Weight;
parameters[45].Value = model.XSF_WeightDetails;
parameters[46].Value = model.XSF_Volume;
parameters[47].Value = model.XSF_VolumeDetails;
parameters[48].Value = model.XSF_TotalMoneyDetails;
parameters[49].Value = model.XSF_WuliuID;
parameters[50].Value = model.XSF_Province;
parameters[51].Value = model.XSF_City;
    
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
public bool Update(KNet.Model.Xs_Sales_Freight model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update Xs_Sales_Freight set ");
strSql.Append("XSF_Code=@XSF_Code,");
strSql.Append("XSF_FID=@XSF_FID,");
strSql.Append("XSF_Stime=@XSF_Stime,");
strSql.Append("XSF_Description=@XSF_Description,");
strSql.Append("XSF_Type=@XSF_Type,");
strSql.Append("XSF_CustomerValue=@XSF_CustomerValue,");
strSql.Append("XSF_CustomerName=@XSF_CustomerName,");
strSql.Append("XSF_FPercent=@XSF_FPercent,");
strSql.Append("XSF_FMoney=@XSF_FMoney,");
strSql.Append("XSF_Percent=@XSF_Percent,");
strSql.Append("XSF_Money=@XSF_Money,");
strSql.Append("XSF_TotalMoney=@XSF_TotalMoney,");
strSql.Append("XSF_TotalNumber=@XSF_TotalNumber,");
strSql.Append("XSF_Price=@XSF_Price,");
strSql.Append("XSF_Remarks=@XSF_Remarks,");
strSql.Append("XSF_CheckYN=@XSF_CheckYN,");
strSql.Append("XSF_Flow=@XSF_Flow,");
strSql.Append("XSF_Del=@XSF_Del,");
strSql.Append("XSF_MTime=@XSF_MTime,");
strSql.Append("XSF_Mender=@XSF_Mender,");
strSql.Append("XSF_KDNameCode=@XSF_KDNameCode,");
strSql.Append("XSF_KDName=@XSF_KDName,");
strSql.Append("XSF_KDCode=@XSF_KDCode,");
strSql.Append("XSF_State=@XSF_State,");
strSql.Append("XSF_FSuppNo=@XSF_FSuppNo,");
strSql.Append("XSF_Address=@XSF_Address,");
strSql.Append("XSF_DutyPerson=@XSF_DutyPerson,");
strSql.Append("XSF_WuliuType=@XSF_WuliuType,");
strSql.Append("XSF_WuliuPrice=@XSF_WuliuPrice,");
strSql.Append("XSF_WuliuMoney=@XSF_WuliuMoney,");
strSql.Append("XSF_TimeDays=@XSF_TimeDays,");
strSql.Append("XSF_MinMoney=@XSF_MinMoney,");
strSql.Append("XSF_PickUpCost=@XSF_PickUpCost,");
strSql.Append("XSF_DeliveryFee=@XSF_DeliveryFee,");
strSql.Append("XSF_UpstairsCost=@XSF_UpstairsCost,");
strSql.Append("XSF_UpstairsCostMoney=@XSF_UpstairsCostMoney,");
strSql.Append("XSF_WareHouseEntry150Low=@XSF_WareHouseEntry150Low,");
strSql.Append("XSF_Insured=@XSF_Insured,");
strSql.Append("XSF_InsuredMoney=@XSF_InsuredMoney,");
strSql.Append("XSF_SignBill=@XSF_SignBill,");
strSql.Append("XSF_BigLateTime=@XSF_BigLateTime,");
strSql.Append("XSF_Weight=@XSF_Weight,");
strSql.Append("XSF_WeightDetails=@XSF_WeightDetails,");
strSql.Append("XSF_Volume=@XSF_Volume,");
strSql.Append("XSF_VolumeDetails=@XSF_VolumeDetails,");
strSql.Append("XSF_WuliuID=@XSF_WuliuID,");
strSql.Append("XSF_Province=@XSF_Province,");
strSql.Append("XSF_City=@XSF_City,");
    
strSql.Append("XSF_TotalMoneyDetails=@XSF_TotalMoneyDetails");
strSql.Append(" where XSF_ID=@XSF_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@XSF_Code", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_FID", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_Stime", SqlDbType.DateTime,8),
 new SqlParameter("@XSF_Description", SqlDbType.VarChar,250),
 new SqlParameter("@XSF_Type", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_CustomerValue", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_CustomerName", SqlDbType.VarChar,150),
 new SqlParameter("@XSF_FPercent", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_FMoney", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_Percent", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_Money", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_TotalMoney", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_TotalNumber", SqlDbType.Int,4),
 new SqlParameter("@XSF_Price", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_Remarks", SqlDbType.VarChar,500),
 new SqlParameter("@XSF_CheckYN", SqlDbType.Int,4),
 new SqlParameter("@XSF_Flow", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_Del", SqlDbType.Int,4),
 new SqlParameter("@XSF_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@XSF_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_KDNameCode", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_KDName", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_KDCode", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_State", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_FSuppNo", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_Address", SqlDbType.VarChar,850),
 new SqlParameter("@XSF_DutyPerson", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_WuliuType", SqlDbType.VarChar,150),
 new SqlParameter("@XSF_WuliuPrice", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_WuliuMoney", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_TimeDays", SqlDbType.Int,4),
 new SqlParameter("@XSF_MinMoney", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_PickUpCost", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_DeliveryFee", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_UpstairsCost", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_UpstairsCostMoney", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_WareHouseEntry150Low", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_Insured", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_InsuredMoney", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_SignBill", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_BigLateTime", SqlDbType.VarChar,150),
 new SqlParameter("@XSF_Weight", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_WeightDetails", SqlDbType.VarChar,300),
 new SqlParameter("@XSF_Volume", SqlDbType.Decimal,9),
 new SqlParameter("@XSF_VolumeDetails", SqlDbType.VarChar,300),
 new SqlParameter("@XSF_WuliuID", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_Province", SqlDbType.VarChar,50),
 new SqlParameter("@XSF_City", SqlDbType.VarChar,50),
 
 new SqlParameter("@XSF_TotalMoneyDetails", SqlDbType.VarChar,300),
new SqlParameter("@XSF_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.XSF_Code;
parameters[1].Value = model.XSF_FID;
parameters[2].Value = model.XSF_Stime;
parameters[3].Value = model.XSF_Description;
parameters[4].Value = model.XSF_Type;
parameters[5].Value = model.XSF_CustomerValue;
parameters[6].Value = model.XSF_CustomerName;
parameters[7].Value = model.XSF_FPercent;
parameters[8].Value = model.XSF_FMoney;
parameters[9].Value = model.XSF_Percent;
parameters[10].Value = model.XSF_Money;
parameters[11].Value = model.XSF_TotalMoney;
parameters[12].Value = model.XSF_TotalNumber;
parameters[13].Value = model.XSF_Price;
parameters[14].Value = model.XSF_Remarks;
parameters[15].Value = model.XSF_CheckYN;
parameters[16].Value = model.XSF_Flow;
parameters[17].Value = model.XSF_Del;
parameters[18].Value = model.XSF_MTime;
parameters[19].Value = model.XSF_Mender;
parameters[20].Value = model.XSF_KDNameCode;
parameters[21].Value = model.XSF_KDName;
parameters[22].Value = model.XSF_KDCode;
parameters[23].Value = model.XSF_State;
parameters[24].Value = model.XSF_FSuppNo;
parameters[25].Value = model.XSF_Address;
parameters[26].Value = model.XSF_DutyPerson;
parameters[27].Value = model.XSF_WuliuType;
parameters[28].Value = model.XSF_WuliuPrice;
parameters[29].Value = model.XSF_WuliuMoney;
parameters[30].Value = model.XSF_TimeDays;
parameters[31].Value = model.XSF_MinMoney;
parameters[32].Value = model.XSF_PickUpCost;
parameters[33].Value = model.XSF_DeliveryFee;
parameters[34].Value = model.XSF_UpstairsCost;
parameters[35].Value = model.XSF_UpstairsCostMoney;
parameters[36].Value = model.XSF_WareHouseEntry150Low;
parameters[37].Value = model.XSF_Insured;
parameters[38].Value = model.XSF_InsuredMoney;
parameters[39].Value = model.XSF_SignBill;
parameters[40].Value = model.XSF_BigLateTime;
parameters[41].Value = model.XSF_Weight;
parameters[42].Value = model.XSF_WeightDetails;
parameters[43].Value = model.XSF_Volume;
parameters[44].Value = model.XSF_VolumeDetails;
parameters[45].Value = model.XSF_WuliuID;
parameters[46].Value = model.XSF_Province;
parameters[47].Value = model.XSF_City;
parameters[48].Value = model.XSF_TotalMoneyDetails;
parameters[49].Value = model.XSF_ID;

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
public bool Delete(string s_XSF_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  Xs_Sales_Freight  ");
strSql.Append(" where XSF_ID=@XSF_ID ");
SqlParameter[] parameters = {
new SqlParameter("@XSF_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_XSF_ID;
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
public bool UpdateDel(KNet.Model.Xs_Sales_Freight model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   Xs_Sales_Freight  Set ");
strSql.Append("  XSF_Del=@XSF_Del ");
strSql.Append("  XSF_DeliveryFee=@XSF_DeliveryFee ");
strSql.Append(" where XSF_ID=@XSF_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@XSF_Del", SqlDbType.Int,4),
 new SqlParameter("@XSF_DeliveryFee", SqlDbType.Decimal,9),
new SqlParameter("@XSF_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.XSF_Del;
parameters[1].Value = model.XSF_DeliveryFee;
parameters[2].Value =  model.XSF_ID;

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
public bool DeleteList(string s_XSF_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   Xs_Sales_Freight  ");
strSql.Append(" where XSF_ID in ('"+s_XSF_ID+"')");

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
strSql.Append("delete from  Xs_Sales_Freight  ");
strSql.Append(" Where  XSF_FID=@XSF_FID ");
SqlParameter[] parameters = {
 new SqlParameter("@XSF_FID", SqlDbType.VarChar,50),
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
public KNet.Model.Xs_Sales_Freight GetModel(string XSF_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from Xs_Sales_Freight  ");
strSql.Append("where XSF_ID=@XSF_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@XSF_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = XSF_ID;
 KNet.Model.Xs_Sales_Freight model = new KNet.Model.Xs_Sales_Freight();
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
/// 得到数据
/// </summary>
public KNet.Model.Xs_Sales_Freight GetModelByFID(string XSF_FID)
{
    StringBuilder strSql = new StringBuilder();
    strSql.Append("Select * from Xs_Sales_Freight  ");
    strSql.Append("where XSF_FID=@XSF_FID  ");
    SqlParameter[] parameters = {
 new SqlParameter("@XSF_FID", SqlDbType.VarChar,50)
};
    parameters[0].Value = XSF_FID;
    KNet.Model.Xs_Sales_Freight model = new KNet.Model.Xs_Sales_Freight();
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
public KNet.Model.Xs_Sales_Freight DataRowToModel(DataRow row)
{
    KNet.Model.Xs_Sales_Freight model = new KNet.Model.Xs_Sales_Freight();

    try {

        if (row != null)
        {
            if (row["XSF_ID"] != null)
            {
                model.XSF_ID = row["XSF_ID"].ToString();
            }
            else
            {
                model.XSF_ID = "";
            }
            if (row["XSF_Code"] != null)
            {
                model.XSF_Code = row["XSF_Code"].ToString();
            }
            else
            {
                model.XSF_Code = "";
            }
            if (row["XSF_FID"] != null)
            {
                model.XSF_FID = row["XSF_FID"].ToString();
            }
            else
            {
                model.XSF_FID = "";
            }
            if (row["XSF_Stime"] != null)
            {
                model.XSF_Stime = DateTime.Parse(row["XSF_Stime"].ToString());
            }
            if (row["XSF_Description"] != null)
            {
                model.XSF_Description = row["XSF_Description"].ToString();
            }
            else
            {
                model.XSF_Description = "";
            }
            if (row["XSF_Type"] != null)
            {
                model.XSF_Type = row["XSF_Type"].ToString();
            }
            else
            {
                model.XSF_Type = "";
            }
            if (row["XSF_CustomerValue"] != null)
            {
                model.XSF_CustomerValue = row["XSF_CustomerValue"].ToString();
            }
            else
            {
                model.XSF_CustomerValue = "";
            }
            if (row["XSF_CustomerName"] != null)
            {
                model.XSF_CustomerName = row["XSF_CustomerName"].ToString();
            }
            else
            {
                model.XSF_CustomerName = "";
            }
            if (row["XSF_FPercent"] != null)
            {
                model.XSF_FPercent = Decimal.Parse(row["XSF_FPercent"].ToString());
            }
            else
            {
                model.XSF_FPercent = 0;
            }
            if (row["XSF_FMoney"] != null)
            {
                model.XSF_FMoney = Decimal.Parse(row["XSF_FMoney"].ToString());
            }
            else
            {
                model.XSF_FMoney = 0;
            }
            if (row["XSF_Percent"] != null)
            {
                model.XSF_Percent = Decimal.Parse(row["XSF_Percent"].ToString());
            }
            else
            {
                model.XSF_Percent = 0;
            }
            if (row["XSF_Money"] != null)
            {
                model.XSF_Money = Decimal.Parse(row["XSF_Money"].ToString());
            }
            else
            {
                model.XSF_Money = 0;
            }
            if (row["XSF_TotalMoney"] != null)
            {
                model.XSF_TotalMoney = Decimal.Parse(row["XSF_TotalMoney"].ToString());
            }
            else
            {
                model.XSF_TotalMoney = 0;
            }
            if (row["XSF_TotalNumber"] != null)
            {
                model.XSF_TotalNumber = int.Parse(row["XSF_TotalNumber"].ToString());
            }
            else
            {
                model.XSF_TotalNumber = 0;
            }
            if (row["XSF_Price"] != null)
            {
                model.XSF_Price = Decimal.Parse(row["XSF_Price"].ToString());
            }
            else
            {
                model.XSF_Price = 0;
            }
            if (row["XSF_Remarks"] != null)
            {
                model.XSF_Remarks = row["XSF_Remarks"].ToString();
            }
            else
            {
                model.XSF_Remarks = "";
            }
            if (row["XSF_CheckYN"] != null)
            {
                model.XSF_CheckYN = int.Parse(row["XSF_CheckYN"].ToString());
            }
            else
            {
                model.XSF_CheckYN = 0;
            }
            if (row["XSF_Flow"] != null)
            {
                model.XSF_Flow = row["XSF_Flow"].ToString();
            }
            else
            {
                model.XSF_Flow = "";
            }
            if (row["XSF_Del"] != null)
            {
                model.XSF_Del = int.Parse(row["XSF_Del"].ToString());
            }
            else
            {
                model.XSF_Del = 0;
            }
            if (row["XSF_CTime"] != null)
            {
                model.XSF_CTime = DateTime.Parse(row["XSF_CTime"].ToString());
            }
            if (row["XSF_Creator"] != null)
            {
                model.XSF_Creator = row["XSF_Creator"].ToString();
            }
            else
            {
                model.XSF_Creator = "";
            }
            if (row["XSF_MTime"] != null)
            {
                model.XSF_MTime = DateTime.Parse(row["XSF_MTime"].ToString());
            }
            if (row["XSF_Mender"] != null)
            {
                model.XSF_Mender = row["XSF_Mender"].ToString();
            }
            else
            {
                model.XSF_Mender = "";
            }
            if (row["XSF_KDNameCode"] != null)
            {
                model.XSF_KDNameCode = row["XSF_KDNameCode"].ToString();
            }
            else
            {
                model.XSF_KDNameCode = "";
            }
            if (row["XSF_KDName"] != null)
            {
                model.XSF_KDName = row["XSF_KDName"].ToString();
            }
            else
            {
                model.XSF_KDName = "";
            }
            if (row["XSF_KDCode"] != null)
            {
                model.XSF_KDCode = row["XSF_KDCode"].ToString();
            }
            else
            {
                model.XSF_KDCode = "";
            }
            if (row["XSF_State"] != null)
            {
                model.XSF_State = row["XSF_State"].ToString();
            }
            else
            {
                model.XSF_State = "";
            }
            if (row["XSF_FSuppNo"] != null)
            {
                model.XSF_FSuppNo = row["XSF_FSuppNo"].ToString();
            }
            else
            {
                model.XSF_FSuppNo = "";
            }
            if (row["XSF_Address"] != null)
            {
                model.XSF_Address = row["XSF_Address"].ToString();
            }
            else
            {
                model.XSF_Address = "";
            }
            if (row["XSF_DutyPerson"] != null)
            {
                model.XSF_DutyPerson = row["XSF_DutyPerson"].ToString();
            }
            else
            {
                model.XSF_DutyPerson = "";
            }
            if (row["XSF_WuliuType"] != null)
            {
                model.XSF_WuliuType = row["XSF_WuliuType"].ToString();
            }
            else
            {
                model.XSF_WuliuType = "";
            }
            if (row["XSF_WuliuPrice"] != null)
            {
                model.XSF_WuliuPrice = Decimal.Parse(row["XSF_WuliuPrice"].ToString());
            }
            else
            {
                model.XSF_WuliuPrice = 0;
            }
            if (row["XSF_WuliuMoney"] != null)
            {
                model.XSF_WuliuMoney = Decimal.Parse(row["XSF_WuliuMoney"].ToString());
            }
            else
            {
                model.XSF_WuliuMoney = 0;
            }
            if (row["XSF_TimeDays"] != null)
            {
                model.XSF_TimeDays = int.Parse(row["XSF_TimeDays"].ToString());
            }
            else
            {
                model.XSF_TimeDays = 0;
            }
            if (row["XSF_MinMoney"] != null)
            {
                model.XSF_MinMoney = Decimal.Parse(row["XSF_MinMoney"].ToString());
            }
            else
            {
                model.XSF_MinMoney = 0;
            }
            if (row["XSF_PickUpCost"] != null)
            {
                model.XSF_PickUpCost = Decimal.Parse(row["XSF_PickUpCost"].ToString());
            }
            else
            {
                model.XSF_PickUpCost = 0;
            }
            if (row["XSF_DeliveryFee"] != null)
            {
                model.XSF_DeliveryFee = Decimal.Parse(row["XSF_DeliveryFee"].ToString());
            }
            else
            {
                model.XSF_DeliveryFee = 0;
            }
            if (row["XSF_UpstairsCost"] != null)
            {
                model.XSF_UpstairsCost = Decimal.Parse(row["XSF_UpstairsCost"].ToString());
            }
            else
            {
                model.XSF_UpstairsCost = 0;
            }
            if (row["XSF_UpstairsCostMoney"] != null)
            {
                model.XSF_UpstairsCostMoney = Decimal.Parse(row["XSF_UpstairsCostMoney"].ToString());
            }
            else
            {
                model.XSF_UpstairsCostMoney = 0;
            }
            if (row["XSF_WareHouseEntry150Low"] != null)
            {
                model.XSF_WareHouseEntry150Low = Decimal.Parse(row["XSF_WareHouseEntry150Low"].ToString());
            }
            else
            {
                model.XSF_WareHouseEntry150Low = 0;
            }
            if (row["XSF_Insured"] != null)
            {
                model.XSF_Insured = Decimal.Parse(row["XSF_Insured"].ToString());
            }
            else
            {
                model.XSF_Insured = 0;
            }
            if (row["XSF_InsuredMoney"] != null)
            {
                model.XSF_InsuredMoney = Decimal.Parse(row["XSF_InsuredMoney"].ToString());
            }
            else
            {
                model.XSF_InsuredMoney = 0;
            }
            if (row["XSF_SignBill"] != null)
            {
                model.XSF_SignBill = Decimal.Parse(row["XSF_SignBill"].ToString());
            }
            else
            {
                model.XSF_SignBill = 0;
            }
            if (row["XSF_BigLateTime"] != null)
            {
                model.XSF_BigLateTime = row["XSF_BigLateTime"].ToString();
            }
            else
            {
                model.XSF_BigLateTime = "";
            }
            if (row["XSF_Weight"] != null)
            {
                model.XSF_Weight = Decimal.Parse(row["XSF_Weight"].ToString());
            }
            else
            {
                model.XSF_Weight = 0;
            }
            if (row["XSF_WeightDetails"] != null)
            {
                model.XSF_WeightDetails = row["XSF_WeightDetails"].ToString();
            }
            else
            {
                model.XSF_WeightDetails = "";
            }
            if (row["XSF_Volume"] != null)
            {
                model.XSF_Volume = Decimal.Parse(row["XSF_Volume"].ToString());
            }
            else
            {
                model.XSF_Volume = 0;
            }
            if (row["XSF_VolumeDetails"] != null)
            {
                model.XSF_VolumeDetails = row["XSF_VolumeDetails"].ToString();
            }
            else
            {
                model.XSF_VolumeDetails = "";
            }
            if (row["XSF_TotalMoneyDetails"] != null)
            {
                model.XSF_TotalMoneyDetails = row["XSF_TotalMoneyDetails"].ToString();
            }
            else
            {
                model.XSF_TotalMoneyDetails = "";
            }
            if (row["XSF_WuliuID"] != null)
            {
                model.XSF_WuliuID = row["XSF_WuliuID"].ToString();
            }
            else
            {
                model.XSF_WuliuID = "";
            }

            if (row["XSF_Province"] != null)
            {
                model.XSF_Province = row["XSF_Province"].ToString();
            }
            else
            {
                model.XSF_Province = "";
            }
            if (row["XSF_City"] != null)
            {
                model.XSF_City = row["XSF_City"].ToString();
            }
            else
            {
                model.XSF_City = "";
            }
        }
    }
    catch
    { }
    return model;
}
/// <summary>
/// 获得数据列表
/// </summary>
public DataSet GetList(string strWhere)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select * ");
strSql.Append(" FROM Xs_Sales_Freight ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

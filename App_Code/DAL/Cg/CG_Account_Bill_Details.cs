 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class CG_Account_Bill_Details
   {
   public CG_Account_Bill_Details()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string CABD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from CG_Account_Bill_Details");
strSql.Append(" where CABD_ID=@CABD_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CABD_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = CABD_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.CG_Account_Bill_Details model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into CG_Account_Bill_Details(");
strSql.Append("CABD_ID,CABD_FID,CABD_CheckDetailsID,CABD_WareHouseDetailsID,CABD_ProductsBarCode,CABD_KpNumber,CABD_KPPrice,CABD_KpMoney,CABD_FPCode,CABD_FPCode1 ");
strSql.Append(") values (");
strSql.Append("@CABD_ID,@CABD_FID,@CABD_CheckDetailsID,@CABD_WareHouseDetailsID,@CABD_ProductsBarCode,@CABD_KpNumber,@CABD_KPPrice,@CABD_KpMoney,@CABD_FPCode,@CABD_FPCode1)");
SqlParameter[] parameters = {
 new SqlParameter("@CABD_ID", SqlDbType.VarChar,50),
 new SqlParameter("@CABD_FID", SqlDbType.VarChar,50),
 new SqlParameter("@CABD_CheckDetailsID", SqlDbType.VarChar,50),
 new SqlParameter("@CABD_WareHouseDetailsID", SqlDbType.VarChar,50),
 new SqlParameter("@CABD_ProductsBarCode", SqlDbType.VarChar,50),
 new SqlParameter("@CABD_KpNumber", SqlDbType.Decimal,9),
 new SqlParameter("@CABD_KPPrice", SqlDbType.Decimal,9),
 new SqlParameter("@CABD_KpMoney", SqlDbType.Decimal,9),
 new SqlParameter("@CABD_FPCode", SqlDbType.VarChar,50),
 new SqlParameter("@CABD_FPCode1", SqlDbType.VarChar,50)
                            };
parameters[0].Value = model.CABD_ID;
parameters[1].Value = model.CABD_FID;
parameters[2].Value = model.CABD_CheckDetailsID;
parameters[3].Value = model.CABD_WareHouseDetailsID;
parameters[4].Value = model.CABD_ProductsBarCode;
parameters[5].Value = model.CABD_KpNumber;
parameters[6].Value = model.CABD_KPPrice;
parameters[7].Value = model.CABD_KpMoney;
parameters[8].Value = model.CABD_FPCode;
parameters[9].Value = model.CABD_FPCode1;
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
public bool Update(KNet.Model.CG_Account_Bill_Details model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update CG_Account_Bill_Details set ");
strSql.Append("CABD_FID=@CABD_FID,");
strSql.Append("CABD_CheckDetailsID=@CABD_CheckDetailsID,");
strSql.Append("CABD_WareHouseDetailsID=@CABD_WareHouseDetailsID,");
strSql.Append("CABD_ProductsBarCode=@CABD_ProductsBarCode,");
strSql.Append("CABD_KpNumber=@CABD_KpNumber,");
strSql.Append("CABD_KPPrice=@CABD_KPPrice,");
strSql.Append("CABD_KpMoney=@CABD_KpMoney,");
strSql.Append("CABD_FPCode=@CABD_FPCode,");
strSql.Append("CABD_FPCode1=@CABD_FPCode1");
    
strSql.Append(" where CABD_ID=@CABD_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@CABD_CheckDetailsID", SqlDbType.VarChar,50),
 new SqlParameter("@CABD_WareHouseDetailsID", SqlDbType.VarChar,50),
 new SqlParameter("@CABD_ProductsBarCode", SqlDbType.VarChar,50),
 new SqlParameter("@CABD_KpNumber", SqlDbType.Decimal,9),
 new SqlParameter("@CABD_KPPrice", SqlDbType.Decimal,9),
 new SqlParameter("@CABD_KpMoney", SqlDbType.Decimal,9),
new SqlParameter("@CABD_ID", SqlDbType.VarChar,50),
new SqlParameter("@CABD_FPCode", SqlDbType.VarChar,50),
new SqlParameter("@CABD_FPCode1", SqlDbType.VarChar,500),
 new SqlParameter("@CABD_FID", SqlDbType.VarChar,50)
                            };
parameters[0].Value = model.CABD_CheckDetailsID;
parameters[1].Value = model.CABD_WareHouseDetailsID;
parameters[2].Value = model.CABD_ProductsBarCode;
parameters[3].Value = model.CABD_KpNumber;
parameters[4].Value = model.CABD_KPPrice;
parameters[5].Value = model.CABD_KpMoney;
parameters[6].Value = model.CABD_FPCode;
parameters[7].Value = model.CABD_FPCode1;
parameters[8].Value = model.CABD_ID;

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
public bool Delete(string s_CABD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  CG_Account_Bill_Details  ");
strSql.Append(" where CABD_ID=@CABD_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CABD_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_CABD_ID;
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
public bool UpdateDel(KNet.Model.CG_Account_Bill_Details model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   CG_Account_Bill_Details  Set ");
strSql.Append(" where CABD_ID=@CABD_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CABD_ID", SqlDbType.VarChar,50)};
parameters[0].Value =  model.CABD_ID;

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
public bool DeleteList(string s_CABD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   CG_Account_Bill_Details  ");
strSql.Append(" where CABD_ID in ('"+s_CABD_ID+"')");

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
strSql.Append("delete from  CG_Account_Bill_Details  ");
strSql.Append(" Where  CABD_FID=@CABD_FID ");
SqlParameter[] parameters = {
 new SqlParameter("@CABD_FID", SqlDbType.VarChar,50),
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
public KNet.Model.CG_Account_Bill_Details GetModel(string CABD_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from CG_Account_Bill_Details  ");
strSql.Append("where CABD_ID=@CABD_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@CABD_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = CABD_ID;
 KNet.Model.CG_Account_Bill_Details model = new KNet.Model.CG_Account_Bill_Details();
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
public KNet.Model.CG_Account_Bill_Details DataRowToModel(DataRow row)
{
KNet.Model.CG_Account_Bill_Details model=new KNet.Model.CG_Account_Bill_Details();
if (row != null)
{
 if (row["CABD_ID"] != null)
{
 model.CABD_ID = row["CABD_ID"].ToString();
}
 else
{
 model.CABD_ID = "";
}
 if (row["CABD_FID"] != null)
{
 model.CABD_FID = row["CABD_FID"].ToString();
}
 else
{
 model.CABD_FID = "";
}
 if (row["CABD_CheckDetailsID"] != null)
{
 model.CABD_CheckDetailsID = row["CABD_CheckDetailsID"].ToString();
}
 else
{
 model.CABD_CheckDetailsID = "";
}
 if (row["CABD_WareHouseDetailsID"] != null)
{
 model.CABD_WareHouseDetailsID = row["CABD_WareHouseDetailsID"].ToString();
}
 else
{
 model.CABD_WareHouseDetailsID = "";
}
 if (row["CABD_ProductsBarCode"] != null)
{
 model.CABD_ProductsBarCode = row["CABD_ProductsBarCode"].ToString();
}
 else
{
 model.CABD_ProductsBarCode = "";
}
 if (row["CABD_FPCode"] != null)
 {
     model.CABD_FPCode = row["CABD_FPCode"].ToString();
 }
 else
 {
     model.CABD_FPCode = "";
 }

 if (row["CABD_FPCode1"] != null)
 {
     model.CABD_FPCode1 = row["CABD_FPCode1"].ToString();
 }
 else
 {
     model.CABD_FPCode1 = "";
 }
 if (row["CABD_KpNumber"] != null)
{
 model.CABD_KpNumber = Decimal.Parse(row["CABD_KpNumber"].ToString());
}
 else
{
 model.CABD_KpNumber = 0;
}
 if (row["CABD_KPPrice"] != null)
{
 model.CABD_KPPrice = Decimal.Parse(row["CABD_KPPrice"].ToString());
}
 else
{
 model.CABD_KPPrice = 0;
}
 if (row["CABD_KpMoney"] != null)
{
 model.CABD_KpMoney = Decimal.Parse(row["CABD_KpMoney"].ToString());
}
 else
{
 model.CABD_KpMoney = 0;
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
strSql.Append(" FROM CG_Account_Bill_Details ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

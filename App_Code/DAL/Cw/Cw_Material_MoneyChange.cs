 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class Cw_Material_MoneyChange
   {
   public Cw_Material_MoneyChange()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string CMM_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from Cw_Material_MoneyChange");
strSql.Append(" where CMM_ID=@CMM_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CMM_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = CMM_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.Cw_Material_MoneyChange model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into Cw_Material_MoneyChange(");
strSql.Append("CMM_ID,CMM_Code,CMM_FID,CMM_STime,CMM_Type,CMM_Money,CMM_Remarks,CMM_Del,CMM_CTime,CMM_Creator,CMM_MTime,CMM_Mender ");
strSql.Append(") values (");
strSql.Append("@CMM_ID,@CMM_Code,@CMM_FID,@CMM_STime,@CMM_Type,@CMM_Money,@CMM_Remarks,@CMM_Del,@CMM_CTime,@CMM_Creator,@CMM_MTime,@CMM_Mender)");
SqlParameter[] parameters = {
 new SqlParameter("@CMM_ID", SqlDbType.VarChar,50),
 new SqlParameter("@CMM_Code", SqlDbType.VarChar,50),
 new SqlParameter("@CMM_FID", SqlDbType.VarChar,50),
 new SqlParameter("@CMM_STime", SqlDbType.DateTime,8),
 new SqlParameter("@CMM_Type", SqlDbType.Int,4),
 new SqlParameter("@CMM_Money", SqlDbType.Decimal,9),
 new SqlParameter("@CMM_Remarks", SqlDbType.VarChar,300),
 new SqlParameter("@CMM_Del", SqlDbType.Int,4),
 new SqlParameter("@CMM_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@CMM_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@CMM_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@CMM_Mender", SqlDbType.VarChar,50)};
parameters[0].Value = model.CMM_ID;
parameters[1].Value = model.CMM_Code;
parameters[2].Value = model.CMM_FID;
parameters[3].Value = model.CMM_STime;
parameters[4].Value = model.CMM_Type;
parameters[5].Value = model.CMM_Money;
parameters[6].Value = model.CMM_Remarks;
parameters[7].Value = model.CMM_Del;
parameters[8].Value = model.CMM_CTime;
parameters[9].Value = model.CMM_Creator;
parameters[10].Value = model.CMM_MTime;
parameters[11].Value = model.CMM_Mender;
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
public bool Update(KNet.Model.Cw_Material_MoneyChange model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update Cw_Material_MoneyChange set ");
strSql.Append("CMM_Code=@CMM_Code,");
strSql.Append("CMM_FID=@CMM_FID,");
strSql.Append("CMM_STime=@CMM_STime,");
strSql.Append("CMM_Type=@CMM_Type,");
strSql.Append("CMM_Money=@CMM_Money,");
strSql.Append("CMM_Remarks=@CMM_Remarks,");
strSql.Append("CMM_Del=@CMM_Del,");
strSql.Append("CMM_MTime=@CMM_MTime,");
strSql.Append("CMM_Mender=@CMM_Mender");
strSql.Append(" where CMM_ID=@CMM_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@CMM_Code", SqlDbType.VarChar,50),
 new SqlParameter("@CMM_FID", SqlDbType.VarChar,50),
 new SqlParameter("@CMM_STime", SqlDbType.DateTime,8),
 new SqlParameter("@CMM_Type", SqlDbType.Int,4),
 new SqlParameter("@CMM_Money", SqlDbType.Decimal,9),
 new SqlParameter("@CMM_Remarks", SqlDbType.VarChar,300),
 new SqlParameter("@CMM_Del", SqlDbType.Int,4),
 new SqlParameter("@CMM_MTime", SqlDbType.DateTime,8),
 new SqlParameter("@CMM_Mender", SqlDbType.VarChar,50),
new SqlParameter("@CMM_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.CMM_Code;
parameters[1].Value = model.CMM_FID;
parameters[2].Value = model.CMM_STime;
parameters[3].Value = model.CMM_Type;
parameters[4].Value = model.CMM_Money;
parameters[5].Value = model.CMM_Remarks;
parameters[6].Value = model.CMM_Del;
parameters[7].Value = model.CMM_MTime;
parameters[8].Value = model.CMM_Mender;
parameters[9].Value = model.CMM_ID;

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
public bool Delete(string s_CMM_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  Cw_Material_MoneyChange  ");
strSql.Append(" where CMM_ID=@CMM_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CMM_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_CMM_ID;
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
public bool UpdateDel(KNet.Model.Cw_Material_MoneyChange model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   Cw_Material_MoneyChange  Set ");
strSql.Append("  CMM_Del=@CMM_Del ");
strSql.Append(" where CMM_ID=@CMM_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@CMM_Del", SqlDbType.Int,4),
new SqlParameter("@CMM_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.CMM_Del;
parameters[1].Value =  model.CMM_ID;

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
public bool DeleteList(string s_CMM_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   Cw_Material_MoneyChange  ");
strSql.Append(" where CMM_ID in ('"+s_CMM_ID+"')");

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
strSql.Append("Select * from  Cw_Material_MoneyChange  ");
strSql.Append(" Where  CMM_FID=@CMM_FID ");
SqlParameter[] parameters = {
 new SqlParameter("@CMM_FID", SqlDbType.VarChar,50),
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
strSql.Append("delete from  Cw_Material_MoneyChange  ");
strSql.Append(" Where  CMM_FID=@CMM_FID ");
SqlParameter[] parameters = {
 new SqlParameter("@CMM_FID", SqlDbType.VarChar,50),
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
public KNet.Model.Cw_Material_MoneyChange GetModel(string CMM_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from Cw_Material_MoneyChange  ");
strSql.Append("where CMM_ID=@CMM_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@CMM_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = CMM_ID;
 KNet.Model.Cw_Material_MoneyChange model = new KNet.Model.Cw_Material_MoneyChange();
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
public KNet.Model.Cw_Material_MoneyChange DataRowToModel(DataRow row)
{
KNet.Model.Cw_Material_MoneyChange model=new KNet.Model.Cw_Material_MoneyChange();
if (row != null)
{
 if (row["CMM_ID"] != null)
{
 model.CMM_ID = row["CMM_ID"].ToString();
}
 else
{
 model.CMM_ID = "";
}
 if (row["CMM_Code"] != null)
{
 model.CMM_Code = row["CMM_Code"].ToString();
}
 else
{
 model.CMM_Code = "";
}
 if (row["CMM_FID"] != null)
{
 model.CMM_FID = row["CMM_FID"].ToString();
}
 else
{
 model.CMM_FID = "";
}
 if (row["CMM_STime"] != null)
{
 model.CMM_STime = DateTime.Parse(row["CMM_STime"].ToString());
}
 if (row["CMM_Type"] != null)
{
 model.CMM_Type = int.Parse(row["CMM_Type"].ToString());
}
 else
{
 model.CMM_Type = 0;
}
 if (row["CMM_Money"] != null)
{
 model.CMM_Money = Decimal.Parse(row["CMM_Money"].ToString());
}
 else
{
 model.CMM_Money = 0;
}
 if (row["CMM_Remarks"] != null)
{
 model.CMM_Remarks = row["CMM_Remarks"].ToString();
}
 else
{
 model.CMM_Remarks = "";
}
 if (row["CMM_Del"] != null)
{
 model.CMM_Del = int.Parse(row["CMM_Del"].ToString());
}
 else
{
 model.CMM_Del = 0;
}
 if (row["CMM_CTime"] != null)
{
 model.CMM_CTime = DateTime.Parse(row["CMM_CTime"].ToString());
}
 if (row["CMM_Creator"] != null)
{
 model.CMM_Creator = row["CMM_Creator"].ToString();
}
 else
{
 model.CMM_Creator = "";
}
 if (row["CMM_MTime"] != null)
{
 model.CMM_MTime = DateTime.Parse(row["CMM_MTime"].ToString());
}
 if (row["CMM_Mender"] != null)
{
 model.CMM_Mender = row["CMM_Mender"].ToString();
}
 else
{
 model.CMM_Mender = "";
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
strSql.Append(" FROM Cw_Material_MoneyChange ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

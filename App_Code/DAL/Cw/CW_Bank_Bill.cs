 using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
namespace KNet.DAL
{
   public partial class CW_Bank_Bill
   {
   public CW_Bank_Bill()
   {}
  /// <summary>
  /// 是否存在该记录
 /// </summary>
public bool Exists(string CBB_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("select count(1) from CW_Bank_Bill");
strSql.Append(" where CBB_ID=@CBB_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CBB_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = CBB_ID;
return DbHelperSQL.Exists(strSql.ToString(),parameters);
}
  /// <summary>
  /// 增加
 /// </summary>
public bool Add(KNet.Model.CW_Bank_Bill model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("insert into CW_Bank_Bill(");
strSql.Append("CBB_ID,CBB_Code,CBB_OutBankNo,CBB_InBankNo,CBB_STime,CBB_Money,CBB_Detail,CBB_Del,CBB_Creator,CBB_CTime,CBB_Mender,CBB_MTime ");
strSql.Append(") values (");
strSql.Append("@CBB_ID,@CBB_Code,@CBB_OutBankNo,@CBB_InBankNo,@CBB_STime,@CBB_Money,@CBB_Detail,@CBB_Del,@CBB_Creator,@CBB_CTime,@CBB_Mender,@CBB_MTime)");
SqlParameter[] parameters = {
 new SqlParameter("@CBB_ID", SqlDbType.VarChar,50),
 new SqlParameter("@CBB_Code", SqlDbType.VarChar,50),
 new SqlParameter("@CBB_OutBankNo", SqlDbType.VarChar,50),
 new SqlParameter("@CBB_InBankNo", SqlDbType.VarChar,50),
 new SqlParameter("@CBB_STime", SqlDbType.DateTime,8),
 new SqlParameter("@CBB_Money", SqlDbType.Decimal,9),
 new SqlParameter("@CBB_Detail", SqlDbType.VarChar,50),
 new SqlParameter("@CBB_Del", SqlDbType.Int,4),
 new SqlParameter("@CBB_Creator", SqlDbType.VarChar,50),
 new SqlParameter("@CBB_CTime", SqlDbType.DateTime,8),
 new SqlParameter("@CBB_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@CBB_MTime", SqlDbType.DateTime,8)};
parameters[0].Value = model.CBB_ID;
parameters[1].Value = model.CBB_Code;
parameters[2].Value = model.CBB_OutBankNo;
parameters[3].Value = model.CBB_InBankNo;
parameters[4].Value = model.CBB_STime;
parameters[5].Value = model.CBB_Money;
parameters[6].Value = model.CBB_Detail;
parameters[7].Value = model.CBB_Del;
parameters[8].Value = model.CBB_Creator;
parameters[9].Value = model.CBB_CTime;
parameters[10].Value = model.CBB_Mender;
parameters[11].Value = model.CBB_MTime;
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
public bool Update(KNet.Model.CW_Bank_Bill model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update CW_Bank_Bill set ");
strSql.Append("CBB_Code=@CBB_Code,");
strSql.Append("CBB_OutBankNo=@CBB_OutBankNo,");
strSql.Append("CBB_InBankNo=@CBB_InBankNo,");
strSql.Append("CBB_STime=@CBB_STime,");
strSql.Append("CBB_Money=@CBB_Money,");
strSql.Append("CBB_Detail=@CBB_Detail,");
strSql.Append("CBB_Del=@CBB_Del,");
strSql.Append("CBB_Mender=@CBB_Mender,");
strSql.Append("CBB_MTime=@CBB_MTime");
strSql.Append(" where CBB_ID=@CBB_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@CBB_Code", SqlDbType.VarChar,50),
 new SqlParameter("@CBB_OutBankNo", SqlDbType.VarChar,50),
 new SqlParameter("@CBB_InBankNo", SqlDbType.VarChar,50),
 new SqlParameter("@CBB_STime", SqlDbType.DateTime,8),
 new SqlParameter("@CBB_Money", SqlDbType.Decimal,9),
 new SqlParameter("@CBB_Detail", SqlDbType.VarChar,50),
 new SqlParameter("@CBB_Del", SqlDbType.Int,4),
 new SqlParameter("@CBB_Mender", SqlDbType.VarChar,50),
 new SqlParameter("@CBB_MTime", SqlDbType.DateTime,8),
new SqlParameter("@CBB_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.CBB_Code;
parameters[1].Value = model.CBB_OutBankNo;
parameters[2].Value = model.CBB_InBankNo;
parameters[3].Value = model.CBB_STime;
parameters[4].Value = model.CBB_Money;
parameters[5].Value = model.CBB_Detail;
parameters[6].Value = model.CBB_Del;
parameters[7].Value = model.CBB_Mender;
parameters[8].Value = model.CBB_MTime;
parameters[9].Value = model.CBB_ID;

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
public bool Delete(string s_CBB_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("delete from  CW_Bank_Bill  ");
strSql.Append(" where CBB_ID=@CBB_ID ");
SqlParameter[] parameters = {
new SqlParameter("@CBB_ID", SqlDbType.VarChar,50)};
parameters[0].Value = s_CBB_ID;
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
public bool UpdateDel(KNet.Model.CW_Bank_Bill model)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Update   CW_Bank_Bill  Set ");
strSql.Append("  CBB_Del=@CBB_Del ");
strSql.Append(" where CBB_ID=@CBB_ID ");
SqlParameter[] parameters = {
 new SqlParameter("@CBB_Del", SqlDbType.Int,4),
new SqlParameter("@CBB_ID", SqlDbType.VarChar,50)};
parameters[0].Value = model.CBB_Del;
parameters[1].Value =  model.CBB_ID;

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
public bool DeleteList(string s_CBB_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Delete From   CW_Bank_Bill  ");
strSql.Append(" where CBB_ID in ('"+s_CBB_ID+"')");

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
public KNet.Model.CW_Bank_Bill GetModel(string CBB_ID)
{
StringBuilder strSql=new StringBuilder();
strSql.Append("Select * from CW_Bank_Bill  ");
strSql.Append("where CBB_ID=@CBB_ID  ");
SqlParameter[] parameters = {
 new SqlParameter("@CBB_ID", SqlDbType.VarChar,50)
};
parameters[0].Value = CBB_ID;
 KNet.Model.CW_Bank_Bill model = new KNet.Model.CW_Bank_Bill();
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
public KNet.Model.CW_Bank_Bill DataRowToModel(DataRow row)
{
KNet.Model.CW_Bank_Bill model=new KNet.Model.CW_Bank_Bill();
if (row != null)
{
 if (row["CBB_ID"] != null)
{
 model.CBB_ID = row["CBB_ID"].ToString();
}
 else
{
 model.CBB_ID = "";
}
 if (row["CBB_Code"] != null)
{
 model.CBB_Code = row["CBB_Code"].ToString();
}
 else
{
 model.CBB_Code = "";
}
 if (row["CBB_OutBankNo"] != null)
{
 model.CBB_OutBankNo = row["CBB_OutBankNo"].ToString();
}
 else
{
 model.CBB_OutBankNo = "";
}
 if (row["CBB_InBankNo"] != null)
{
 model.CBB_InBankNo = row["CBB_InBankNo"].ToString();
}
 else
{
 model.CBB_InBankNo = "";
}
 if (row["CBB_STime"] != null)
{
 model.CBB_STime = DateTime.Parse(row["CBB_STime"].ToString());
}
 if (row["CBB_Money"] != null)
{
 model.CBB_Money = Decimal.Parse(row["CBB_Money"].ToString());
}
 else
{
 model.CBB_Money = 0;
}
 if (row["CBB_Detail"] != null)
{
 model.CBB_Detail = row["CBB_Detail"].ToString();
}
 else
{
 model.CBB_Detail = "";
}
 if (row["CBB_Del"] != null)
{
 model.CBB_Del = int.Parse(row["CBB_Del"].ToString());
}
 else
{
 model.CBB_Del = 0;
}
 if (row["CBB_Creator"] != null)
{
 model.CBB_Creator = row["CBB_Creator"].ToString();
}
 else
{
 model.CBB_Creator = "";
}
 if (row["CBB_CTime"] != null)
{
 model.CBB_CTime = DateTime.Parse(row["CBB_CTime"].ToString());
}
 if (row["CBB_Mender"] != null)
{
 model.CBB_Mender = row["CBB_Mender"].ToString();
}
 else
{
 model.CBB_Mender = "";
}
 if (row["CBB_MTime"] != null)
{
 model.CBB_MTime = DateTime.Parse(row["CBB_MTime"].ToString());
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
strSql.Append(" FROM CW_Bank_Bill ");
if(strWhere.Trim()!="")
{
strSql.Append(" where "+strWhere);
}
return DbHelperSQL.Query(strSql.ToString());
}
}
  }

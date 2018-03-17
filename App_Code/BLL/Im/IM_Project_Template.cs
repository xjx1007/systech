 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// IM_Project_Template
/// </summary>
   public partial class IM_Project_Template
   {
   private readonly KNet.DAL.IM_Project_Template dal=new KNet.DAL.IM_Project_Template();
   public IM_Project_Template()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string IPT_ID)
{
	return dal.Exists(IPT_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.IM_Project_Template model)
{
    StringBuilder strSql = new StringBuilder();
    strSql.Append("insert into IM_Project_Manage_Details(");
    strSql.Append("IPMD_ID,IPMD_IPMID,IPMD_FID,IPMD_Type,IPMD_Name,IPMD_Days,IPMD_FloatingDays,IPMD_PreTask,IPMD_DutyPerson,IPMD_Executor,IPMD_Remarks,IPMD_Creator,IPMD_CTime,IPMD_Del,IPMD_Mender,IPMD_MTime,IPMD_FTaskID,IPMD_Level ");
    strSql.Append(") select IPMD_ID+'" + model.IPT_ID + "','" + model.IPT_ID + "',case when IPMD_FID='' then '' else  IPMD_FID+'" + model.IPT_ID + "' end,IPMD_Type");
    strSql.Append(",IPMD_Name,IPMD_Days,IPMD_FloatingDays,IPMD_PreTask,IPMD_DutyPerson,IPMD_Executor,IPMD_Remarks,IPMD_Creator,IPMD_CTime,IPMD_Del,IPMD_Mender,IPMD_MTime,IPMD_FTaskID,IPMD_Level  ");
    strSql.Append(" From IM_Project_Manage_Details ");
    strSql.Append(" where IPMD_IPMID='"+model.IPT_Code+"' ");

    if (DbHelperSQL.ExecuteSql(strSql.ToString()) > 0)
    {
        return dal.Add(model);
    }
    else
    {
        return false;
    }
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.IM_Project_Template model)
{
	return dal.Update( model);
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string IPT_ID)
{
	return dal.Delete(IPT_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.IM_Project_Template model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string IPT_ID)
{
	return dal.DeleteList(IPT_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public KNet.Model.IM_Project_Template GetModel(string IPT_ID)
{
	return dal.GetModel(IPT_ID);
}
  	/// <summary>
 ///获得数据列表
 /// </summary>
public DataSet GetList(string strWhere)
{
	return dal.GetList(strWhere);
}
}
}

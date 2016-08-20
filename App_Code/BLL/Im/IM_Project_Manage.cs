 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// IM_Project_Manage
/// </summary>
   public partial class IM_Project_Manage
   {
   private readonly KNet.DAL.IM_Project_Manage dal=new KNet.DAL.IM_Project_Manage();
   public IM_Project_Manage()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string IPM_ID)
{
	return dal.Exists(IPM_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.IM_Project_Manage model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.IM_Project_Manage model)
{
	return dal.Update( model);
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string IPM_ID)
{
	return dal.Delete(IPM_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.IM_Project_Manage model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string IPM_ID)
{
	return dal.DeleteList(IPM_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public KNet.Model.IM_Project_Manage GetModel(string IPM_ID)
{
	return dal.GetModel(IPM_ID);
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

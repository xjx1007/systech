 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// Xs_Contract_Manage_Details
/// </summary>
   public partial class Xs_Contract_Manage_Details
   {
   private readonly KNet.DAL.Xs_Contract_Manage_Details dal=new KNet.DAL.Xs_Contract_Manage_Details();
   public Xs_Contract_Manage_Details()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string XCMD_ID)
{
	return dal.Exists(XCMD_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.Xs_Contract_Manage_Details model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.Xs_Contract_Manage_Details model)
{
	return dal.Update( model);
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string XCMD_ID)
{
	return dal.Delete(XCMD_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.Xs_Contract_Manage_Details model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string XCMD_ID)
{
	return dal.DeleteList(XCMD_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public bool DeleteByFID(string XCMD_ID)
{
	return dal.DeleteByFID(XCMD_ID);
}
  	/// <summary>
 ///获取类
 /// </summary>
public KNet.Model.Xs_Contract_Manage_Details GetModel(string XCMD_ID)
{
	return dal.GetModel(XCMD_ID);
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

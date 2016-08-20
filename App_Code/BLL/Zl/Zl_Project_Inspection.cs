 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// Zl_Project_Inspection
/// </summary>
   public partial class Zl_Project_Inspection
   {
   private readonly KNet.DAL.Zl_Project_Inspection dal=new KNet.DAL.Zl_Project_Inspection();
   public Zl_Project_Inspection()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string ZPI_ID)
{
	return dal.Exists(ZPI_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.Zl_Project_Inspection model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.Zl_Project_Inspection model)
{
	return dal.Update( model);
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string ZPI_ID)
{
	return dal.Delete(ZPI_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.Zl_Project_Inspection model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string ZPI_ID)
{
	return dal.DeleteList(ZPI_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public bool DeleteByFID(string ZPI_ID)
{
	return dal.DeleteByFID(ZPI_ID);
}
  	/// <summary>
 ///获取类
 /// </summary>
public KNet.Model.Zl_Project_Inspection GetModel(string ZPI_ID)
{
	return dal.GetModel(ZPI_ID);
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

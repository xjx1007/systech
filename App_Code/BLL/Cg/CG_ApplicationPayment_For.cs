 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// CG_ApplicationPayment_For
/// </summary>
   public partial class CG_ApplicationPayment_For
   {
   private readonly KNet.DAL.CG_ApplicationPayment_For dal=new KNet.DAL.CG_ApplicationPayment_For();
   public CG_ApplicationPayment_For()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string CAF_ID)
{
	return dal.Exists(CAF_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.CG_ApplicationPayment_For model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.CG_ApplicationPayment_For model)
{
	return dal.Update( model);
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string CAF_ID)
{
	return dal.Delete(CAF_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.CG_ApplicationPayment_For model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string CAF_ID)
{
	return dal.DeleteList(CAF_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public bool DeleteByFID(string CAF_ID)
{
	return dal.DeleteByFID(CAF_ID);
}
  	/// <summary>
 ///获取类
 /// </summary>
public KNet.Model.CG_ApplicationPayment_For GetModel(string CAF_ID)
{
	return dal.GetModel(CAF_ID);
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

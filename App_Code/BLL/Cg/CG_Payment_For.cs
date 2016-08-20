 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// CG_Payment_For
/// </summary>
   public partial class CG_Payment_For
   {
   private readonly KNet.DAL.CG_Payment_For dal=new KNet.DAL.CG_Payment_For();
   public CG_Payment_For()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string CPF_ID)
{
	return dal.Exists(CPF_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.CG_Payment_For model)
{
	return dal.Add(model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.CG_Payment_For model)
{
	return dal.Update( model);
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string CPF_ID)
{
	return dal.Delete(CPF_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.CG_Payment_For model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string CPF_ID)
{
	return dal.DeleteList(CPF_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public bool DeleteByFID(string CPF_ID)
{
	return dal.DeleteByFID(CPF_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public KNet.Model.CG_Payment_For GetModel(string CPF_ID)
{
	return dal.GetModel(CPF_ID);
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

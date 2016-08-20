 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// Cw_Bill_Expense_Details
/// </summary>
   public partial class Cw_Bill_Expense_Details
   {
   private readonly KNet.DAL.Cw_Bill_Expense_Details dal=new KNet.DAL.Cw_Bill_Expense_Details();
   public Cw_Bill_Expense_Details()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string CBED_ID)
{
	return dal.Exists(CBED_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.Cw_Bill_Expense_Details model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.Cw_Bill_Expense_Details model)
{
	return dal.Update( model);
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string CBED_ID)
{
	return dal.Delete(CBED_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.Cw_Bill_Expense_Details model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string CBED_ID)
{
	return dal.DeleteList(CBED_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public bool DeleteByFID(string CBED_ID)
{
	return dal.DeleteByFID(CBED_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public DataSet QueryByFID(string CBED_ID)
{
	return dal.QueryByFID(CBED_ID);
}
  	/// <summary>
 ///获取类
 /// </summary>
public KNet.Model.Cw_Bill_Expense_Details GetModel(string CBED_ID)
{
	return dal.GetModel(CBED_ID);
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

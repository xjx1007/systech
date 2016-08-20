 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// CG_Account_Bill_Details
/// </summary>
   public partial class CG_Account_Bill_Details
   {
   private readonly KNet.DAL.CG_Account_Bill_Details dal=new KNet.DAL.CG_Account_Bill_Details();
   public CG_Account_Bill_Details()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string CABD_ID)
{
	return dal.Exists(CABD_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.CG_Account_Bill_Details model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.CG_Account_Bill_Details model)
{
	return dal.Update( model);
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string CABD_ID)
{
	return dal.Delete(CABD_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.CG_Account_Bill_Details model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string CABD_ID)
{
	return dal.DeleteList(CABD_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public bool DeleteByFID(string CABD_ID)
{
	return dal.DeleteByFID(CABD_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public KNet.Model.CG_Account_Bill_Details GetModel(string CABD_ID)
{
	return dal.GetModel(CABD_ID);
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

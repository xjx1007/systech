 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// PB_Basic_Sample_ProductsDetails
/// </summary>
   public partial class PB_Basic_Sample_ProductsDetails
   {
   private readonly KNet.DAL.PB_Basic_Sample_ProductsDetails dal=new KNet.DAL.PB_Basic_Sample_ProductsDetails();
   public PB_Basic_Sample_ProductsDetails()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string PBSP_ID)
{
	return dal.Exists(PBSP_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.PB_Basic_Sample_ProductsDetails model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.PB_Basic_Sample_ProductsDetails model)
{
	return dal.Update( model);
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string PBSP_ID)
{
	return dal.Delete(PBSP_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.PB_Basic_Sample_ProductsDetails model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string PBSP_ID)
{
	return dal.DeleteList(PBSP_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public bool DeleteByFID(string PBSP_ID)
{
	return dal.DeleteByFID(PBSP_ID);
}
  	/// <summary>
 ///获取类
 /// </summary>
public KNet.Model.PB_Basic_Sample_ProductsDetails GetModel(string PBSP_ID)
{
	return dal.GetModel(PBSP_ID);
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

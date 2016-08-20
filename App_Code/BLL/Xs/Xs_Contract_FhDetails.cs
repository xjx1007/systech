 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// Xs_Contract_FhDetails
/// </summary>
   public partial class Xs_Contract_FhDetails
   {
   private readonly KNet.DAL.Xs_Contract_FhDetails dal=new KNet.DAL.Xs_Contract_FhDetails();
   public Xs_Contract_FhDetails()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string XCF_ID)
{
	return dal.Exists(XCF_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.Xs_Contract_FhDetails model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.Xs_Contract_FhDetails model)
{
	return dal.Update( model);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public bool DeleteByFID(string XCF_ID)
{
	return dal.DeleteByFID(XCF_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public KNet.Model.Xs_Contract_FhDetails GetModel(string XCF_ID)
{
	return dal.GetModel(XCF_ID);
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

 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// Wl_Customer_Price_Details
/// </summary>
   public partial class Wl_Customer_Price_Details
   {
   private readonly KNet.DAL.Wl_Customer_Price_Details dal=new KNet.DAL.Wl_Customer_Price_Details();
   public Wl_Customer_Price_Details()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string WCPD_ID)
{
	return dal.Exists(WCPD_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.Wl_Customer_Price_Details model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.Wl_Customer_Price_Details model)
{
	return dal.Update( model);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public bool DeleteByFID(string WCPD_ID)
{
	return dal.DeleteByFID(WCPD_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public KNet.Model.Wl_Customer_Price_Details GetModel(string WCPD_ID)
{
	return dal.GetModel(WCPD_ID);
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

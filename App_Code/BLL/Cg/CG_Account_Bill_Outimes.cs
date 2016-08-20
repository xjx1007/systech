 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// CG_Account_Bill_Outimes
/// </summary>
   public partial class CG_Account_Bill_Outimes
   {
   private readonly KNet.DAL.CG_Account_Bill_Outimes dal=new KNet.DAL.CG_Account_Bill_Outimes();
   public CG_Account_Bill_Outimes()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string CABO_ID)
{
	return dal.Exists(CABO_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.CG_Account_Bill_Outimes model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.CG_Account_Bill_Outimes model)
{
	return dal.Update( model);
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string CABO_ID)
{
	return dal.Delete(CABO_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.CG_Account_Bill_Outimes model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string CABO_ID)
{
	return dal.DeleteList(CABO_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public bool DeleteByFID(string CABO_ID)
{
	return dal.DeleteByFID(CABO_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public KNet.Model.CG_Account_Bill_Outimes GetModel(string CABO_ID)
{
	return dal.GetModel(CABO_ID);
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

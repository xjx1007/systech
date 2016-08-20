 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// Cw_Material_MoneyChange
/// </summary>
   public partial class Cw_Material_MoneyChange
   {
   private readonly KNet.DAL.Cw_Material_MoneyChange dal=new KNet.DAL.Cw_Material_MoneyChange();
   public Cw_Material_MoneyChange()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string CMM_ID)
{
	return dal.Exists(CMM_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.Cw_Material_MoneyChange model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.Cw_Material_MoneyChange model)
{
	return dal.Update( model);
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string CMM_ID)
{
	return dal.Delete(CMM_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.Cw_Material_MoneyChange model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string CMM_ID)
{
	return dal.DeleteList(CMM_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public bool DeleteByFID(string CMM_ID)
{
	return dal.DeleteByFID(CMM_ID);
}
  	/// <summary>
 ///获取类
 /// </summary>
public KNet.Model.Cw_Material_MoneyChange GetModel(string CMM_ID)
{
	return dal.GetModel(CMM_ID);
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

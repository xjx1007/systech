 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// Sc_Order_ProducePlan
/// </summary>
   public partial class Sc_Order_ProducePlan
   {
   private readonly KNet.DAL.Sc_Order_ProducePlan dal=new KNet.DAL.Sc_Order_ProducePlan();
   public Sc_Order_ProducePlan()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string SOP_ID)
{
	return dal.Exists(SOP_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.Sc_Order_ProducePlan model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.Sc_Order_ProducePlan model)
{
	return dal.Update( model);
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string SOP_ID)
{
	return dal.Delete(SOP_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.Sc_Order_ProducePlan model)
{
	return dal.UpdateDel(model);

}
/// <summary>
/// 删除数据
/// </summary>
public bool UpdateDelBySuppNo(string s_SuppNo)
{
    return dal.UpdateDelBySuppNo(s_SuppNo);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string SOP_ID)
{
	return dal.DeleteList(SOP_ID);
}
  	/// <summary>
 ///获取类
 /// </summary>
public KNet.Model.Sc_Order_ProducePlan GetModel(string SOP_ID)
{
	return dal.GetModel(SOP_ID);
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

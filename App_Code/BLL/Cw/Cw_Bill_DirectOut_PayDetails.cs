 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// Cw_Bill_DirectOut_PayDetails
/// </summary>
   public partial class Cw_Bill_DirectOut_PayDetails
   {
   private readonly KNet.DAL.Cw_Bill_DirectOut_PayDetails dal=new KNet.DAL.Cw_Bill_DirectOut_PayDetails();
   public Cw_Bill_DirectOut_PayDetails()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string CBDP_ID)
{
	return dal.Exists(CBDP_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.Cw_Bill_DirectOut_PayDetails model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.Cw_Bill_DirectOut_PayDetails model)
{
	return dal.Update( model);
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string CBDP_ID)
{
	return dal.Delete(CBDP_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.Cw_Bill_DirectOut_PayDetails model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string CBDP_ID)
{
	return dal.DeleteList(CBDP_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public bool DeleteByFID(string CBDP_ID)
{
	return dal.DeleteByFID(CBDP_ID);
}
  	/// <summary>
 ///获取类
 /// </summary>
public KNet.Model.Cw_Bill_DirectOut_PayDetails GetModel(string CBDP_ID)
{
	return dal.GetModel(CBDP_ID);
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

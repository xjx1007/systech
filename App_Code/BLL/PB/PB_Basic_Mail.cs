 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// PB_Basic_Mail
/// </summary>
   public partial class PB_Basic_Mail
   {
   private readonly KNet.DAL.PB_Basic_Mail dal=new KNet.DAL.PB_Basic_Mail();
   public PB_Basic_Mail()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string PBM_ID)
{
	return dal.Exists(PBM_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.PB_Basic_Mail model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.PB_Basic_Mail model)
{
	return dal.Update( model);
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string PBM_ID)
{
	return dal.Delete(PBM_ID);
}
/// <summary>
/// 删除一条数据
/// </summary>
public bool DeleteByOrderNo(string PBM_FID)
{
    return dal.DeleteByOrderNo(PBM_FID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.PB_Basic_Mail model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string PBM_ID)
{
	return dal.DeleteList(PBM_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public bool DeleteByFID(string PBM_ID)
{
	return dal.DeleteByFID(PBM_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public KNet.Model.PB_Basic_Mail GetModel(string PBM_ID)
{
	return dal.GetModel(PBM_ID);
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

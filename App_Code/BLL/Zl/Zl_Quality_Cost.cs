 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// Zl_Quality_Cost
/// </summary>
   public partial class Zl_Quality_Cost
   {
   private readonly KNet.DAL.Zl_Quality_Cost dal=new KNet.DAL.Zl_Quality_Cost();
   public Zl_Quality_Cost()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string ZQC_ID)
{
	return dal.Exists(ZQC_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.Zl_Quality_Cost model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.Zl_Quality_Cost model)
{
	return dal.Update( model);
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string ZQC_ID)
{
	return dal.Delete(ZQC_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.Zl_Quality_Cost model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string ZQC_ID)
{
	return dal.DeleteList(ZQC_ID);
}
  	/// <summary>
 ///获取类
 /// </summary>
public KNet.Model.Zl_Quality_Cost GetModel(string ZQC_ID)
{
	return dal.GetModel(ZQC_ID);
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

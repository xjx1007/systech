 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// PB_Mail_Setting
/// </summary>
   public partial class PB_Mail_Setting
   {
   private readonly KNet.DAL.PB_Mail_Setting dal=new KNet.DAL.PB_Mail_Setting();
   public PB_Mail_Setting()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string PMS_ID)
{
	return dal.Exists(PMS_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.PB_Mail_Setting model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.PB_Mail_Setting model)
{
	return dal.Update( model);
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string PMS_ID)
{
	return dal.Delete(PMS_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.PB_Mail_Setting model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string PMS_ID)
{
	return dal.DeleteList(PMS_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public KNet.Model.PB_Mail_Setting GetModel(string PMS_ID)
{
	return dal.GetModel(PMS_ID);
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

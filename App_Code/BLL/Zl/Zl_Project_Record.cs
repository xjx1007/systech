 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// Zl_Project_Record
/// </summary>
   public partial class Zl_Project_Record
   {
   private readonly KNet.DAL.Zl_Project_Record dal=new KNet.DAL.Zl_Project_Record();
   public Zl_Project_Record()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string ZPR_ID)
{
	return dal.Exists(ZPR_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.Zl_Project_Record model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.Zl_Project_Record model)
{
	return dal.Update( model);
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string ZPR_ID)
{
	return dal.Delete(ZPR_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.Zl_Project_Record model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string ZPR_ID)
{
	return dal.DeleteList(ZPR_ID);
}
  	/// <summary>
 ///获取类
 /// </summary>
public KNet.Model.Zl_Project_Record GetModel(string ZPR_ID)
{
	return dal.GetModel(ZPR_ID);
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

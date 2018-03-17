 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// SC_Order_Time
/// </summary>
   public partial class SC_Order_Time
   {
   private readonly KNet.DAL.SC_Order_Time dal=new KNet.DAL.SC_Order_Time();
   public SC_Order_Time()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string SOT_ID)
{
	return dal.Exists(SOT_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.SC_Order_Time model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.SC_Order_Time model)
{
	return dal.Update( model);
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string SOT_ID)
{
	return dal.Delete(SOT_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.SC_Order_Time model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string SOT_ID)
{
	return dal.DeleteList(SOT_ID);
}
  	/// <summary>
 ///获取类
 /// </summary>
public KNet.Model.SC_Order_Time GetModel(string SOT_ID)
{
	return dal.GetModel(SOT_ID);
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

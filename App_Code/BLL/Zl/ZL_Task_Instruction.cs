 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// ZL_Task_Instruction
/// </summary>
   public partial class ZL_Task_Instruction
   {
   private readonly KNet.DAL.ZL_Task_Instruction dal=new KNet.DAL.ZL_Task_Instruction();
   public ZL_Task_Instruction()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string ZTI_ID)
{
	return dal.Exists(ZTI_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.ZL_Task_Instruction model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.ZL_Task_Instruction model)
{
	return dal.Update( model);
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string ZTI_ID)
{
	return dal.Delete(ZTI_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.ZL_Task_Instruction model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string ZTI_ID)
{
	return dal.DeleteList(ZTI_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public KNet.Model.ZL_Task_Instruction GetModel(string ZTI_ID)
{
	return dal.GetModel(ZTI_ID);
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

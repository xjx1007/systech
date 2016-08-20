 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// CW_Bank_Bill
/// </summary>
   public partial class CW_Bank_Bill
   {
   private readonly KNet.DAL.CW_Bank_Bill dal=new KNet.DAL.CW_Bank_Bill();
   public CW_Bank_Bill()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string CBB_ID)
{
	return dal.Exists(CBB_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.CW_Bank_Bill model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.CW_Bank_Bill model)
{
	return dal.Update( model);
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string CBB_ID)
{
	return dal.Delete(CBB_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.CW_Bank_Bill model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string CBB_ID)
{
	return dal.DeleteList(CBB_ID);
}
  	/// <summary>
 ///获取类
 /// </summary>
public KNet.Model.CW_Bank_Bill GetModel(string CBB_ID)
{
	return dal.GetModel(CBB_ID);
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

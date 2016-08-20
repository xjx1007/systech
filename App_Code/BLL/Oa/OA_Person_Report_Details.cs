 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// OA_Person_Report_Details
/// </summary>
   public partial class OA_Person_Report_Details
   {
   private readonly KNet.DAL.OA_Person_Report_Details dal=new KNet.DAL.OA_Person_Report_Details();
   public OA_Person_Report_Details()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string OPRD_ID)
{
	return dal.Exists(OPRD_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.OA_Person_Report_Details model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.OA_Person_Report_Details model)
{
	return dal.Update( model);
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string OPRD_ID)
{
	return dal.Delete(OPRD_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public bool DeleteByFID(string OPRD_ID)
{
	return dal.DeleteByFID(OPRD_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public KNet.Model.OA_Person_Report_Details GetModel(string OPRD_ID)
{
	return dal.GetModel(OPRD_ID);
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

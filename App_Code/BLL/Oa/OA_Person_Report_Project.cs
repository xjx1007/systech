 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// OA_Person_Report_Project
/// </summary>
   public partial class OA_Person_Report_Project
   {
   private readonly KNet.DAL.OA_Person_Report_Project dal=new KNet.DAL.OA_Person_Report_Project();
   public OA_Person_Report_Project()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string OPRP_ID)
{
	return dal.Exists(OPRP_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.OA_Person_Report_Project model)
{
	return dal.Add( model);
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.OA_Person_Report_Project model)
{
	return dal.Update( model);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public bool DeleteByFID(string OPRP_ID)
{
	return dal.DeleteByFID(OPRP_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public KNet.Model.OA_Person_Report_Project GetModel(string OPRP_ID)
{
	return dal.GetModel(OPRP_ID);
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

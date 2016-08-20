 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// Cw_Bill_Expense
/// </summary>
   public partial class Cw_Bill_Expense
   {
   private readonly KNet.DAL.Cw_Bill_Expense dal=new KNet.DAL.Cw_Bill_Expense();
   public Cw_Bill_Expense()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string CBE_ID)
{
	return dal.Exists(CBE_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.Cw_Bill_Expense model)
{
 if(dal.Add(model))
 {
      KNet.BLL.Cw_Bill_Expense_Details BLL_Details=new KNet.BLL.Cw_Bill_Expense_Details();   
      if(model.Arr_Detail.Count>0)
       { 
       for(int i=0;i<model.Arr_Detail.Count;i++) 
           { 
               KNet.Model.Cw_Bill_Expense_Details Model_Details=(KNet.Model.Cw_Bill_Expense_Details)model.Arr_Detail[i] ;
               BLL_Details.Add(Model_Details);
           }
       }
       return true;
 }
 else{
       return false;
 }
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.Cw_Bill_Expense model)
{
 if(dal.Update(model))
 {
      KNet.BLL.Cw_Bill_Expense_Details BLL_Details=new KNet.BLL.Cw_Bill_Expense_Details();
      BLL_Details.DeleteByFID(model.CBE_ID);
      if(model.Arr_Detail.Count>0)
       { 
       for(int i=0;i<model.Arr_Detail.Count;i++) 
           { 
               KNet.Model.Cw_Bill_Expense_Details Model_Details=(KNet.Model.Cw_Bill_Expense_Details)model.Arr_Detail[i] ;
               BLL_Details.Add(Model_Details) ;
           }
       }
       return true;
 }
 else{
       return false;
 }
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string CBE_ID)
{
	return dal.Delete(CBE_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.Cw_Bill_Expense model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string CBE_ID)
{
	return dal.DeleteList(CBE_ID);
}
  	/// <summary>
 ///获取类
 /// </summary>
public KNet.Model.Cw_Bill_Expense GetModel(string CBE_ID)
{
	return dal.GetModel(CBE_ID);
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

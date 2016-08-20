 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// Zl_Produce_Problem
/// </summary>
   public partial class Zl_Produce_Problem
   {
   private readonly KNet.DAL.Zl_Produce_Problem dal=new KNet.DAL.Zl_Produce_Problem();
   public Zl_Produce_Problem()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string ZPP_ID)
{
	return dal.Exists(ZPP_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.Zl_Produce_Problem model)
{
    if (dal.Add(model))
    {
        KNet.BLL.Zl_Produce_Problem_Details Bll_Details = new KNet.BLL.Zl_Produce_Problem_Details();
        if (model.Arr_Detail.Count > 0)
        {
            for (int i = 0; i < model.Arr_Detail.Count; i++)
            {
                KNet.Model.Zl_Produce_Problem_Details Model_Details = (KNet.Model.Zl_Produce_Problem_Details)model.Arr_Detail[i];
                Bll_Details.Add(Model_Details);
            }
        }
        return true; ;
    }
    else
    {
        return false;
    }
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.Zl_Produce_Problem model)
{

    if (dal.Update(model))
    {
        KNet.BLL.Zl_Produce_Problem_Details Bll_Details = new KNet.BLL.Zl_Produce_Problem_Details();
        if (model.Arr_Detail.Count > 0)
        {
            Bll_Details.DeleteByFID(model.ZPP_ID);
            for (int i = 0; i < model.Arr_Detail.Count; i++)
            {
                KNet.Model.Zl_Produce_Problem_Details Model_Details = (KNet.Model.Zl_Produce_Problem_Details)model.Arr_Detail[i];
                Bll_Details.Add(Model_Details);
            }
        }
        return true; ;
    }
    else
    {
        return false;
    }
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string ZPP_ID)
{
	return dal.Delete(ZPP_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.Zl_Produce_Problem model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string ZPP_ID)
{
	return dal.DeleteList(ZPP_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public KNet.Model.Zl_Produce_Problem GetModel(string ZPP_ID)
{
	return dal.GetModel(ZPP_ID);
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

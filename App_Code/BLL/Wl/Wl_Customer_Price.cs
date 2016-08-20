 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// Wl_Customer_Price
/// </summary>
   public partial class Wl_Customer_Price
   {
   private readonly KNet.DAL.Wl_Customer_Price dal=new KNet.DAL.Wl_Customer_Price();
   public Wl_Customer_Price()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string WCP_ID)
{
	return dal.Exists(WCP_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.Wl_Customer_Price model)
{
    if (dal.Add(model))
    {
        if (model.Arr_Detail.Count > 0)
        {
            for (int i = 0; i < model.Arr_Detail.Count; i++)
            {
                KNet.Model.Wl_Customer_Price_Details Model_Details = (KNet.Model.Wl_Customer_Price_Details)model.Arr_Detail[i];
                KNet.BLL.Wl_Customer_Price_Details BLL_Details = new KNet.BLL.Wl_Customer_Price_Details();
                BLL_Details.Add(Model_Details);
            }
        }
        return true;
    }
    else
    {
        return false;
    }
}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.Wl_Customer_Price model)
{

    if (dal.Update(model))
    {
        KNet.BLL.Wl_Customer_Price_Details BLL_Details = new KNet.BLL.Wl_Customer_Price_Details();
        BLL_Details.DeleteByFID(model.WCP_ID);
        if (model.Arr_Detail.Count > 0)
        {
            for (int i = 0; i < model.Arr_Detail.Count; i++)
            {
                KNet.Model.Wl_Customer_Price_Details Model_Details = (KNet.Model.Wl_Customer_Price_Details)model.Arr_Detail[i];
                BLL_Details.Add(Model_Details);
            }
        }
        return true;
    }
    else
    {
        return false;
    }
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string WCP_ID)
{
	return dal.Delete(WCP_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.Wl_Customer_Price model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string WCP_ID)
{
	return dal.DeleteList(WCP_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public KNet.Model.Wl_Customer_Price GetModel(string WCP_ID)
{
	return dal.GetModel(WCP_ID);
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

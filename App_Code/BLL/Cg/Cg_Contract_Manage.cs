 using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
/// <summary>
/// Cg_Contract_Manage
/// </summary>
   public partial class Cg_Contract_Manage
   {
   private readonly KNet.DAL.Cg_Contract_Manage dal=new KNet.DAL.Cg_Contract_Manage();
   public Cg_Contract_Manage()
   {}
  	/// <summary>
 /// 是否存在该记录
 /// </summary>
public bool Exists(string CCM_ID)
{
	return dal.Exists(CCM_ID);
}
  	/// <summary>
 /// 增加一条数据
 /// </summary>
public bool Add(KNet.Model.Cg_Contract_Manage model)
{
    try{
    
    dal.Add( model);
    if (model.Arr_Details != null)
    {
        for (int i = 0; i < model.Arr_Details.Count; i++)
        {
            KNet.BLL.PB_Basic_Attachment bll_Att = new PB_Basic_Attachment();
            KNet.Model.PB_Basic_Attachment Model_Att = (KNet.Model.PB_Basic_Attachment)model.Arr_Details[i];
            bll_Att.Add(Model_Att);
        }
    }
    return true;
    }
    catch
    {
        return false;
    }

}
  	/// <summary>
 /// 修改一条数据
 /// </summary>
public bool Update(KNet.Model.Cg_Contract_Manage model)
{
    KNet.BLL.PB_Basic_Attachment bll_Att = new PB_Basic_Attachment();
    bll_Att.DeleteByFID(model.CCM_ID);
    if (model.Arr_Details != null)
    {
        for (int i = 0; i < model.Arr_Details.Count; i++)
        {
            KNet.Model.PB_Basic_Attachment Model_Att = (KNet.Model.PB_Basic_Attachment)model.Arr_Details[i];
            bll_Att.Add(Model_Att);
        }
    }
    return dal.Update(model);
}

public string GetMaxOrder()
{
    string s_Code = "100001";
    DataSet Dts_Table = dal.GetList(" 1=1  Order by CCM_OrderNo desc");
    if (Dts_Table.Tables[0].Rows.Count > 0)
    {
        s_Code = Convert.ToString(int.Parse(Dts_Table.Tables[0].Rows[0]["CCM_OrderNo"].ToString()) + 1);
    }
    return s_Code;
}
  	/// <summary>
 /// 删除一条数据
 /// </summary>
public bool Delete(string CCM_ID)
{
	return dal.Delete(CCM_ID);
}
  	/// <summary>
 /// 删除数据
 /// </summary>
public bool UpdateDel(KNet.Model.Cg_Contract_Manage model)
{
	return dal.UpdateDel(model);
}
  	/// <summary>
 /// 批量删除一条数据
 /// </summary>
public bool DeleteList(string CCM_ID)
{
	return dal.DeleteList(CCM_ID);
}
  	/// <summary>
 ///删除父节点数据
 /// </summary>
public bool DeleteByFID(string CCM_ID)
{
	return dal.DeleteByFID(CCM_ID);
}
  	/// <summary>
 ///获取类
 /// </summary>
public KNet.Model.Cg_Contract_Manage GetModel(string CCM_ID)
{
	return dal.GetModel(CCM_ID);
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

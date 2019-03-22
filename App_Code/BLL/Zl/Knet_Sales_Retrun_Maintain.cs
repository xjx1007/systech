using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Knet_Sales_Retrun_Maintain
    /// </summary>
    public partial class Knet_Sales_Retrun_Maintain
    {
        private readonly KNet.DAL.Knet_Sales_Retrun_Maintain dal = new KNet.DAL.Knet_Sales_Retrun_Maintain();
        public Knet_Sales_Retrun_Maintain()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KSM_ID)
        {
            return dal.Exists(KSM_ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Knet_Sales_Retrun_Maintain model)
        {
            if (model.Arr_Products != null)
            {
                KNet.BLL.Knet_Sales_Retrun_Maintain_Details Bll_Details = new Knet_Sales_Retrun_Maintain_Details();
                Bll_Details.Delete(model.KSM_MID);
                for (int i = 0; i < model.Arr_Products.Count; i++)
                {
                    KNet.Model.Knet_Sales_Retrun_Maintain_Details model_Details = (KNet.Model.Knet_Sales_Retrun_Maintain_Details)model.Arr_Products[i];
                    Bll_Details.Add(model_Details);
                }
            }
            dal.Delete(model.KSM_MID);
            dal.Add(model);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public bool Update(KNet.Model.Knet_Sales_Retrun_Maintain model)
        {
            return dal.Update(model);
        }
        public string GetLastCode()
        {
            return dal.GetLastCode();
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string KSM_ID)
        {
            return dal.Delete(KSM_ID);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public bool UpdateDel(KNet.Model.Knet_Sales_Retrun_Maintain model)
        {
            return dal.UpdateDel(model);
        }
        /// <summary>
        /// 批量删除一条数据
        /// </summary>
        public bool DeleteList(string KSM_ID)
        {
            return dal.DeleteList(KSM_ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public bool DeleteByFID(string KSM_ID)
        {
            return dal.DeleteByFID(KSM_ID);
        }
      
        /// <summary>
        ///获取类
        /// </summary>
        public KNet.Model.Knet_Sales_Retrun_Maintain GetModel(string KSM_ID)
        {
            return dal.GetModel(KSM_ID);
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

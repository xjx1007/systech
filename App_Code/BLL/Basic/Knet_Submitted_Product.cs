using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
using System.Net.Mail;

namespace KNet.BLL
{
    /// <summary>
    /// Knet_Submitted_Product
    /// </summary>
    public partial class Knet_Submitted_Product
    {
        private readonly KNet.DAL.Knet_Submitted_Product dal = new KNet.DAL.Knet_Submitted_Product();
        public Knet_Submitted_Product()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KSP_ID)
        {
            return dal.Exists(KSP_ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Knet_Submitted_Product model)
        {
            if (model.Arr_Products != null)
            {
                for (int i = 0; i < model.Arr_Products.Count; i++)
                {

                    KNet.Model.Knet_Submitted_Product_Details Model_Details = (KNet.Model.Knet_Submitted_Product_Details)model.Arr_Products[i];
                    KNet.BLL.Knet_Submitted_Product_Details Bll_Details = new Knet_Submitted_Product_Details();
                    
                    Bll_Details.Add(Model_Details);
                }
               
            }
            if (model.Arr_Products != null)
            {
                dal.Add(model);

            }
        }
 
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public void Update(KNet.Model.Knet_Submitted_Product model)
        {
            if (model.Arr_Products != null)
            {
                KNet.BLL.Knet_Submitted_Product_Details Bll_Details = new Knet_Submitted_Product_Details();
                Bll_Details.Delete(model.KSP_SID);
                for (int i = 0; i < model.Arr_Products.Count; i++)
                {
                    KNet.Model.Knet_Submitted_Product_Details model_Details = (KNet.Model.Knet_Submitted_Product_Details)model.Arr_Products[i];
                    Bll_Details.Add(model_Details);
                }
            }          
            dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string KSP_SID)
        {
          
            return dal.Delete(KSP_SID);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public bool UpdateDel(KNet.Model.Knet_Submitted_Product model)
        {
            return dal.UpdateDel(model);
        }

        public string GetLastCode()
        {
            return dal.GetLastCode();
        }

        /// <summary>
        /// 批量删除一条数据
        /// </summary>
        public bool DeleteList(string KSP_ID)
        {
            return dal.DeleteList(KSP_ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public bool DeleteByFID(string KSP_ID)
        {
            return dal.DeleteByFID(KSP_ID);
        }
       
        /// <summary>
        ///获取类
        /// </summary>
        public KNet.Model.Knet_Submitted_Product GetModel(string KSP_SID)
        {
            return dal.GetModel(KSP_SID);
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

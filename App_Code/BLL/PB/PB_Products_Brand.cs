using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// PB_Products_Brand
    /// </summary>
    public partial class PB_Products_Brand
    {
        private readonly KNet.DAL.PB_Products_Brand dal = new KNet.DAL.PB_Products_Brand();
        public PB_Products_Brand()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PPB_Name)
        {
            return dal.Exists(PPB_Name);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.PB_Products_Brand model)
        {
            //
            if (model.Arr_Detail != null)
            {
                KNet.BLL.PB_Products_Brand_Details Bll_Details = new PB_Products_Brand_Details();
                for (int i = 0; i < model.Arr_Detail.Count; i++)
                {
                    //
                    KNet.Model.PB_Products_Brand_Details ModelDetails = (KNet.Model.PB_Products_Brand_Details)model.Arr_Detail[i];
                    Bll_Details.Add(ModelDetails);
                }
            }
            return dal.Add(model);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Products_Brand model)
        {
            if (model.Arr_Detail != null)
            {
                KNet.BLL.PB_Products_Brand_Details Bll_Details = new PB_Products_Brand_Details();
                Bll_Details.DeleteByFID(model.PPB_ID);
                for (int i = 0; i < model.Arr_Detail.Count; i++)
                {
                    //
                    KNet.Model.PB_Products_Brand_Details ModelDetails = (KNet.Model.PB_Products_Brand_Details)model.Arr_Detail[i];
                    Bll_Details.Add(ModelDetails);
                }
            }
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PPB_ID)
        {
            return dal.Delete(PPB_ID);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public bool UpdateDel(KNet.Model.PB_Products_Brand model)
        {
            return dal.UpdateDel(model);
        }
        /// <summary>
        /// 批量删除一条数据
        /// </summary>
        public bool DeleteList(string PPB_ID)
        {
            return dal.DeleteList(PPB_ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public bool DeleteByFID(string PPB_ID)
        {
            return dal.DeleteByFID(PPB_ID);
        }   
        /// <summary>
        ///获取类
        /// </summary>
        public KNet.Model.PB_Products_Brand GetModel(string PPB_ID)
        {
            return dal.GetModel(PPB_ID);
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

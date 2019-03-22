using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Knet_Sales_Retrun_Maintain_Details
    /// </summary>
    public partial class Knet_Sales_Retrun_Maintain_Details
    {
        private readonly KNet.DAL.Knet_Sales_Retrun_Maintain_Details dal = new KNet.DAL.Knet_Sales_Retrun_Maintain_Details();
        public Knet_Sales_Retrun_Maintain_Details()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KSD_ID)
        {
            return dal.Exists(KSD_ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.Knet_Sales_Retrun_Maintain_Details model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public bool Update(KNet.Model.Knet_Sales_Retrun_Maintain_Details model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string KSD_ID)
        {
            return dal.Delete(KSD_ID);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public bool UpdateDel(KNet.Model.Knet_Sales_Retrun_Maintain_Details model)
        {
            return dal.UpdateDel(model);
        }
        /// <summary>
        /// 批量删除一条数据
        /// </summary>
        public bool DeleteList(string KSD_ID)
        {
            return dal.DeleteList(KSD_ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public bool DeleteByFID(string KSD_ID)
        {
            return dal.DeleteByFID(KSD_ID);
        }
  
        /// <summary>
        ///获取类
        /// </summary>
        public KNet.Model.Knet_Sales_Retrun_Maintain_Details GetModel(string KSD_ID)
        {
            return dal.GetModel(KSD_ID);
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

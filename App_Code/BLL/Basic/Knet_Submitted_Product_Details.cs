using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Knet_Submitted_Product_Details
    /// </summary>
    public partial class Knet_Submitted_Product_Details
    {
        private readonly KNet.DAL.Knet_Submitted_Product_Details dal = new KNet.DAL.Knet_Submitted_Product_Details();
        public Knet_Submitted_Product_Details()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KPD_SID)
        {
            return dal.Exists(KPD_SID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.Knet_Submitted_Product_Details model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public bool Update(KNet.Model.Knet_Submitted_Product_Details model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string KPD_SID)
        {
            return dal.Delete(KPD_SID);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public bool UpdateDel(KNet.Model.Knet_Submitted_Product_Details model)
        {
            return dal.UpdateDel(model);
        }
        /// <summary>
        /// 批量删除一条数据
        /// </summary>
        public bool DeleteList(string KPD_SID)
        {
            return dal.DeleteList(KPD_SID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public bool DeleteByFID(string KPD_SID)
        {
            return dal.DeleteByFID(KPD_SID);
        }
      
        /// <summary>
        ///获取类
        /// </summary>
        public KNet.Model.Knet_Submitted_Product_Details GetModel(string KPD_SID)
        {
            return dal.GetModel(KPD_SID);
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

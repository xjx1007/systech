using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// KNet_Product_Gauge
    /// </summary>
    public partial class KNet_Product_Gauge
    {
        private readonly KNet.DAL.KNet_Product_Gauge dal = new KNet.DAL.KNet_Product_Gauge();
        public KNet_Product_Gauge()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KPG_ID)
        {
            return dal.Exists(KPG_ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.KNet_Product_Gauge model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public bool Update(KNet.Model.KNet_Product_Gauge model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string KPG_ID)
        {
            return dal.Delete(KPG_ID);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public bool UpdateDel(KNet.Model.KNet_Product_Gauge model)
        {
            return dal.UpdateDel(model);
        }
        /// <summary>
        /// 批量删除一条数据
        /// </summary>
        public bool DeleteList(string KPG_ID)
        {
            return dal.DeleteList(KPG_ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public bool DeleteByFID(string KPG_ID)
        {
            return dal.DeleteByFID(KPG_ID);
        }
      
        /// <summary>
        ///获取类
        /// </summary>
        public KNet.Model.KNet_Product_Gauge GetModel(string KPG_ID)
        {
            return dal.GetModel(KPG_ID);
        }
        /// <summary>
        ///获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        public DataSet GetList1(string strWhere)
        {
            return dal.GetList1(strWhere);
        }
    }
}

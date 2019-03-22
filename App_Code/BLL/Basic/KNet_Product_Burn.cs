using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// KNet_Product_Burn
    /// </summary>
    public partial class KNet_Product_Burn
    {
        private readonly KNet.DAL.KNet_Product_Burn dal = new KNet.DAL.KNet_Product_Burn();
        public KNet_Product_Burn()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KSB_ID)
        {
            return dal.Exists(KSB_ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.KNet_Product_Burn model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public bool Update(KNet.Model.KNet_Product_Burn model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string KSB_ID)
        {
            return dal.Delete(KSB_ID);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public bool UpdateDel(KNet.Model.KNet_Product_Burn model)
        {
            return dal.UpdateDel(model);
        }
        /// <summary>
        /// 批量删除一条数据
        /// </summary>
        public bool DeleteList(string KSB_ID)
        {
            return dal.DeleteList(KSB_ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public bool DeleteByFID(string KSB_ID)
        {
            return dal.DeleteByFID(KSB_ID);
        }
      
        /// <summary>
        ///获取类
        /// </summary>
        public KNet.Model.KNet_Product_Burn GetModel(string KSB_ID)
        {
            return dal.GetModel(KSB_ID);
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

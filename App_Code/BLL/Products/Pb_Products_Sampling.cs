using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// KNet_Sampling_List
    /// </summary>
    public partial class KNet_Sampling_List
    {
        private readonly KNet.DAL.KNet_Sampling_List dal = new KNet.DAL.KNet_Sampling_List();
        public KNet_Sampling_List()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            return dal.Exists(ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.KNet_Sampling_List model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public bool Update(KNet.Model.KNet_Sampling_List model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ID)
        {
            return dal.Delete(ID);
        }
        public bool Delete1(string ID)
        {
            return dal.Delete1(ID);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public bool UpdateDel(KNet.Model.KNet_Sampling_List model)
        {
            return dal.UpdateDel(model);
        }
        /// <summary>
        /// 批量删除一条数据
        /// </summary>
        public bool DeleteList(string ID)
        {
            return dal.DeleteList(ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public bool DeleteByFID(string ID)
        {
            return dal.DeleteByFID(ID);
        }
      
     
        /// <summary>
        ///获取类
        /// </summary>
        public KNet.Model.KNet_Sampling_List GetModel(string ID)
        {
            return dal.GetModel(ID);
        }
        /// <summary>
        /// 根据物品编号
        /// </summary>
        /// <param name="ReID"></param>
        /// <returns></returns>
        public KNet.Model.KNet_Sampling_List GetModelByReID(string ReID)
        {
            return dal.GetModelByReID(ReID);
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

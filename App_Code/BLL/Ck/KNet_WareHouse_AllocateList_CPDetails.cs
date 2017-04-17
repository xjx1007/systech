using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using KNet.DBUtility;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// KNet_WareHouse_AllocateList_CPDetails
    /// </summary>
    public partial class KNet_WareHouse_AllocateList_CPDetails
    {
        private readonly KNet.DAL.KNet_WareHouse_AllocateList_CPDetails dal = new KNet.DAL.KNet_WareHouse_AllocateList_CPDetails();
        public KNet_WareHouse_AllocateList_CPDetails()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KWAC_ID)
        {
            return dal.Exists(KWAC_ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.KNet_WareHouse_AllocateList_CPDetails model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public bool Update(KNet.Model.KNet_WareHouse_AllocateList_CPDetails model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string KWAC_ID)
        {
            return dal.Delete(KWAC_ID);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public bool UpdateDel(KNet.Model.KNet_WareHouse_AllocateList_CPDetails model)
        {
            return dal.UpdateDel(model);
        }
        /// <summary>
        /// 批量删除一条数据
        /// </summary>
        public bool DeleteList(string KWAC_ID)
        {
            return dal.DeleteList(KWAC_ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public bool DeleteByAllocateNo(string KWAC_ID)
        {
            return dal.DeleteByAllocateNo(KWAC_ID);
        }

        /// <summary>
        ///获取类
        /// </summary>
        public KNet.Model.KNet_WareHouse_AllocateList_CPDetails GetModel(string KWAC_ID)
        {
            return dal.GetModel(KWAC_ID);
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

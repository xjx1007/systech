using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_Sales_OutWareList_FlowList
    /// </summary>
    public class KNet_Sales_OutWareList_FlowList
    {
        private readonly KNet.DAL.KNet_Sales_OutWareList_FlowList dal = new KNet.DAL.KNet_Sales_OutWareList_FlowList();
        public KNet_Sales_OutWareList_FlowList()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sales_OutWareList_FlowList model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ID)
        {

            dal.Delete(ID);
        }

        /// <summary>
        /// UpDate
        /// </summary>
        public void UpDataSate(KNet.Model.KNet_Sales_OutWareList_FlowList model)
        {

            dal.UpDataSate(model);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }



        #endregion  成员方法
    }
}


using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类Knet_Procure_ReceivingList_Details
    /// </summary>
    public class Knet_Procure_ReceivingList_Details
    {
        private readonly KNet.DAL.Knet_Procure_ReceivingList_Details dal = new KNet.DAL.Knet_Procure_ReceivingList_Details();
        public Knet_Procure_ReceivingList_Details()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ReceivNo, string ProductsBarCode)
        {
            return dal.Exists(ReceivNo, ProductsBarCode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Knet_Procure_ReceivingList_Details model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.Knet_Procure_ReceivingList_Details model)
        {
            dal.Update(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateB(KNet.Model.Knet_Procure_ReceivingList_Details model)
        {
            dal.UpdateB(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ID, string OrderNo, string ProductsBarCode)
        {

            dal.Delete(ID, OrderNo, ProductsBarCode);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_ReceivingList_Details GetModel(string ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
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


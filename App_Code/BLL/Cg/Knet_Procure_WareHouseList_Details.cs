using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类Knet_Procure_WareHouseList_Details 
    /// </summary>
    public class Knet_Procure_WareHouseList_Details
    {
        private readonly KNet.DAL.Knet_Procure_WareHouseList_Details dal = new KNet.DAL.Knet_Procure_WareHouseList_Details();
        public Knet_Procure_WareHouseList_Details()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string WareHouseNo, string ProductsBarCode)
        {
            return dal.Exists(WareHouseNo, ProductsBarCode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Knet_Procure_WareHouseList_Details model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.Knet_Procure_WareHouseList_Details model)
        {
            dal.Update(model);
        }

        public bool UpdateTaxMoney(KNet.Model.Knet_Procure_WareHouseList_Details model)
        {
            return   dal.UpdateTaxMoney(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateByWareHouseNo(string s_WareHouseNo)
        {
            dal.UpdateByWareHouseNo(s_WareHouseNo);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ID, string ReceivNo, string ProductsBarCode)
        {

            dal.Delete(ID, ReceivNo, ProductsBarCode);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteByWareHouseNo(string WareHouseNo)
        {

            dal.DeleteByWareHouseNo(WareHouseNo);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_WareHouseList_Details GetModel(string ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个按订单对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_WareHouseList_Details GetModelByProductsUnits(string ID, string s_OrderNo)
        {

            return dal.GetModelByProductsUnits(ID,s_OrderNo);
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


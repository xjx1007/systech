using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类Knet_Procure_SuppliersPrice
    /// </summary>
    public class Knet_Procure_SuppliersPrice
    {
        private readonly KNet.DAL.Knet_Procure_SuppliersPrice dal = new KNet.DAL.Knet_Procure_SuppliersPrice();
        public Knet_Procure_SuppliersPrice()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SuppNo, string ProductsBarCode)
        {
            return dal.Exists(SuppNo, ProductsBarCode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Knet_Procure_SuppliersPrice model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.Knet_Procure_SuppliersPrice model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateState(KNet.Model.Knet_Procure_SuppliersPrice model)
        {
            dal.UpdateState(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ID)
        {

            dal.Delete(ID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteBYModel(KNet.Model.Knet_Procure_SuppliersPrice model)
        {

            dal.DeleteBYModel(model);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_SuppliersPrice GetModel(string ID)
        {

            return dal.GetModel(ID);
        }
        /// 得到一个最近报价单
        /// </summary>
        public KNet.Model.Knet_Procure_SuppliersPrice GetModelByProductsBarCode(string ProductsBarCode)
        {
            return dal.GetModelByProductsBarCode(ProductsBarCode);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_SuppliersPrice GetModelB(string SuppNo, string ProductsBarCode)
        {

            return dal.GetModelB(SuppNo, ProductsBarCode);
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
        public DataSet GetTop(string strWhere)
        {
            return dal.GetTop(strWhere);
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


using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_Sales_BaoPriceList
    /// </summary>
    public class KNet_Sales_BaoPriceList
    {
        private readonly KNet.DAL.KNet_Sales_BaoPriceList dal = new KNet.DAL.KNet_Sales_BaoPriceList();
        public KNet_Sales_BaoPriceList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string BaoPriceNo)
        {
            return dal.Exists(BaoPriceNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sales_BaoPriceList model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sales_BaoPriceList model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string BaoPriceNo)
        {

            dal.Delete(BaoPriceNo);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_BaoPriceList GetModel(string ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_BaoPriceList GetModelB(string BaoPriceNo)
        {

            return dal.GetModelB(BaoPriceNo);
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


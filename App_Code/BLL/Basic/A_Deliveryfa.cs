using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类A_Deliveryfa 的摘要说明。
    /// </summary>
    public class A_Deliveryfa
    {
        private readonly KNet.DAL.A_Deliveryfa dal = new KNet.DAL.A_Deliveryfa();
        public A_Deliveryfa()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string InvoiceOrderNumber)
        {
            return dal.Exists(InvoiceOrderNumber);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.A_Deliveryfa model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.A_Deliveryfa GetModel(string ID)
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


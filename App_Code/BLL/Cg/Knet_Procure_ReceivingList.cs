using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类Knet_Procure_ReceivingList
    /// </summary>
    public class Knet_Procure_ReceivingList
    {
        private readonly KNet.DAL.Knet_Procure_ReceivingList dal = new KNet.DAL.Knet_Procure_ReceivingList();
        public Knet_Procure_ReceivingList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ReceivNo)
        {
            return dal.Exists(ReceivNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Knet_Procure_ReceivingList model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.Knet_Procure_ReceivingList model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ReceivNo)
        {

            dal.Delete(ReceivNo);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_ReceivingList GetModel(string ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_ReceivingList GetModelB(string ReceivNo)
        {

            return dal.GetModelB(ReceivNo);
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


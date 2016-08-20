using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_Sales_ClientAppseting 
    /// </summary>
    public class KNet_Sales_ClientAppseting
    {
        private readonly KNet.DAL.KNet_Sales_ClientAppseting dal = new KNet.DAL.KNet_Sales_ClientAppseting();
        public KNet_Sales_ClientAppseting()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Client_Name, int ClientKings)
        {
            return dal.Exists(Client_Name, ClientKings);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sales_ClientAppseting model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_ClientAppseting GetModel(string ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sales_ClientAppseting model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ID)
        {
            dal.Delete(ID);
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


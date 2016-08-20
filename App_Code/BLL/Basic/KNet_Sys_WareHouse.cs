using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_Sys_WareHouse 的摘要说明。
    /// </summary>
    public class KNet_Sys_WareHouse
    {
        private readonly KNet.DAL.KNet_Sys_WareHouse dal = new KNet.DAL.KNet_Sys_WareHouse();
        public KNet_Sys_WareHouse()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string HouseName)
        {
            return dal.Exists(HouseName);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsForHouseNo(string HouseNo)
        {
            return dal.ExistsForHouseNo(HouseNo);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sys_WareHouse model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sys_WareHouse model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string HouseNo)
        {

            dal.Delete(HouseNo);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sys_WareHouse GetModel(string HouseNo)
        {
            return dal.GetModel(HouseNo);
        }
        /// <summary>
        /// 得到一个根据供应商
        /// </summary>
        public KNet.Model.KNet_Sys_WareHouse GetModelBySuppNo(string SuppNo)
        {
            return dal.GetModelBySuppNo(SuppNo);
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


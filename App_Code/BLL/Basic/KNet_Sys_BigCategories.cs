using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_Sys_BigCategories
    /// </summary>
    public class KNet_Sys_BigCategories
    {
        private readonly KNet.DAL.KNet_Sys_BigCategories dal = new KNet.DAL.KNet_Sys_BigCategories();
        public KNet_Sys_BigCategories()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CateName)
        {
            return dal.Exists(CateName);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsForBigNo(string BigNo)
        {
            return dal.ExistsForBigNo(BigNo);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sys_BigCategories model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sys_BigCategories model)
        {
            dal.Update(model);
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


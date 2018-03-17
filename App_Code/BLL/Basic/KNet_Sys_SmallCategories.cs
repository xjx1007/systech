using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_Sys_SmallCategories
    /// </summary>
    public class KNet_Sys_SmallCategories
    {
        private readonly KNet.DAL.KNet_Sys_SmallCategories dal = new KNet.DAL.KNet_Sys_SmallCategories();
        public KNet_Sys_SmallCategories()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CateName, string BigNo)
        {
            return dal.Exists(CateName, BigNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sys_SmallCategories model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sys_SmallCategories model)
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


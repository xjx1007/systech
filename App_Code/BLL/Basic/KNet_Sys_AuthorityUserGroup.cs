using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_Sys_AuthorityUserGroup
    /// </summary>
    public class KNet_Sys_AuthorityUserGroup
    {
        private readonly KNet.DAL.KNet_Sys_AuthorityUserGroup dal = new KNet.DAL.KNet_Sys_AuthorityUserGroup();
        public KNet_Sys_AuthorityUserGroup()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string GroupName)
        {
            return dal.Exists(GroupName);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sys_AuthorityUserGroup model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sys_AuthorityUserGroup model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sys_AuthorityUserGroup GetModel(string GroupValue)
        {

            return dal.GetModel(GroupValue);
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


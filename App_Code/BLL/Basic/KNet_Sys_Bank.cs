using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_Sys_Bank 的摘要说明。
    /// </summary>
    public class KNet_Sys_Bank
    {
        private readonly KNet.DAL.KNet_Sys_Bank dal = new KNet.DAL.KNet_Sys_Bank();
        public KNet_Sys_Bank()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string BankName, string BankCount)
        {
            return dal.Exists(BankName, BankCount);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sys_Bank model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sys_Bank GetModel(string BankNo)
        {

            return dal.GetModel(BankNo);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sys_Bank model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string BankNo)
        {

            dal.Delete(BankNo);
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


using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_Sys_Config
    /// </summary>
    public class KNet_Sys_Config
    {
        private readonly KNet.DAL.KNet_Sys_Config dal = new KNet.DAL.KNet_Sys_Config();
        public KNet_Sys_Config()
        { }
        #region  成员方法
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sys_Config model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sys_Config GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        #endregion  成员方法
    }
}


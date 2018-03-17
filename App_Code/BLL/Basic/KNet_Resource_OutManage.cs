using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_Resource_OutManage
    /// </summary>
    public class KNet_Resource_OutManage
    {
        private readonly KNet.DAL.KNet_Resource_OutManage dal = new KNet.DAL.KNet_Resource_OutManage();
        public KNet_Resource_OutManage()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Resource_OutManage model)
        {
            if (model.Arr_Customer != null)
            {
                KNet.BLL.Xs_Customer_Products BLL_Customer_Products = new KNet.BLL.Xs_Customer_Products();
                for (int i = 0; i < model.Arr_Customer.Count; i++)
                {
                    KNet.Model.Xs_Customer_Products Model_Customer_Products = (KNet.Model.Xs_Customer_Products)model.Arr_Customer[i];
                    BLL_Customer_Products.Add(Model_Customer_Products);
                }
            }
            dal.Add(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ID)
        {

            dal.Delete(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Resource_OutManage GetModel(string ID)
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }


        #endregion  成员方法
    }
}


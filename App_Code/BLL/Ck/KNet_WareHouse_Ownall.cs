using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_WareHouse_Ownall 
    /// </summary>
    public class KNet_WareHouse_Ownall
    {
        private readonly KNet.DAL.KNet_WareHouse_Ownall dal = new KNet.DAL.KNet_WareHouse_Ownall();
        public KNet_WareHouse_Ownall()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string HouseNo, string ProductsBarCode)
        {
            return dal.Exists(HouseNo, ProductsBarCode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_WareHouse_Ownall model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_WareHouse_Ownall model)
        {
            dal.Update(model);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_Ownall GetModel(string HouseNo, string ProductsBarCode)
        {

            return dal.GetModel(HouseNo, ProductsBarCode);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_Ownall GetModelB(string ID)
        {

            return dal.GetModelB(ID);
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


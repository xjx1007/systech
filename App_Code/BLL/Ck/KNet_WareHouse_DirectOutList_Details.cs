using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_WareHouse_DirectOutList_Details
    /// </summary>
    public class KNet_WareHouse_DirectOutList_Details
    {
        private readonly KNet.DAL.KNet_WareHouse_DirectOutList_Details dal = new KNet.DAL.KNet_WareHouse_DirectOutList_Details();
        public KNet_WareHouse_DirectOutList_Details()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string DirectOutNo, string ProductsBarCode, string OwnallPID)
        {
            return dal.Exists(DirectOutNo, ProductsBarCode, OwnallPID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_WareHouse_DirectOutList_Details model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void AddWithID(KNet.Model.KNet_WareHouse_DirectOutList_Details model)
        {
            dal.AddWithID(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_WareHouse_DirectOutList_Details model)
        {
            dal.Update(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateDzNumber(KNet.Model.KNet_WareHouse_DirectOutList_Details model)
        {
            dal.UpdateDzNumber(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateB(KNet.Model.KNet_WareHouse_DirectOutList_Details model)
        {
            dal.UpdateB(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ID)
        {

            dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteByDirectOutNO(string DirectOutNO)
        {

            dal.DeleteByDirectOutNO(DirectOutNO);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_DirectOutList_Details GetModel(string ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_DirectOutList_Details GetModelB(string ProductsBarCode, string DirectOutNo, string OwnallPID)
        {

            return dal.GetModelB(ProductsBarCode, DirectOutNo, OwnallPID);
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


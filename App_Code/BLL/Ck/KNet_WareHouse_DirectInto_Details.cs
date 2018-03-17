using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_WareHouse_DirectInto_Details
    /// </summary>
    public class KNet_WareHouse_DirectInto_Details
    {
        private readonly KNet.DAL.KNet_WareHouse_DirectInto_Details dal = new KNet.DAL.KNet_WareHouse_DirectInto_Details();
        public KNet_WareHouse_DirectInto_Details()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string DirectInNo, string ProductsBarCode)
        {
            return dal.Exists(DirectInNo, ProductsBarCode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_WareHouse_DirectInto_Details model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据（由ID更新）
        /// </summary>
        public void Update(KNet.Model.KNet_WareHouse_DirectInto_Details model)
        {
            dal.Update(model);
        }
        /// <summary>
        /// 更新一条数据（由DirectInNo,ProductsBarCode更新）
        /// </summary>
        public void UpdateB(KNet.Model.KNet_WareHouse_DirectInto_Details model)
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
        public void DeleteByFID(string FID)
        {
            dal.DeleteByFID(FID);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_DirectInto_Details GetModel(string ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_DirectInto_Details GetModelB(string DirectInNo, string ProductsBarCode)
        {

            return dal.GetModelB(DirectInNo, ProductsBarCode);
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


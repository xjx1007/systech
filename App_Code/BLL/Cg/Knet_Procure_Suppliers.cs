using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类Knet_Procure_Suppliers
    /// </summary>
    public class Knet_Procure_Suppliers
    {
        private readonly KNet.DAL.Knet_Procure_Suppliers dal = new KNet.DAL.Knet_Procure_Suppliers();
        public Knet_Procure_Suppliers()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SuppName, string SuppProvince)
        {
            return dal.Exists(SuppName, SuppProvince);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Knet_Procure_Suppliers model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.Knet_Procure_Suppliers model)
        {
            model.KPS_Del = 1;
            dal.Update(model);
        }
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateDel(KNet.Model.Knet_Procure_Suppliers model)
        {
            dal.UpdateDel(model);
        }
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string SuppNo)
        {
            dal.Delete(SuppNo);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_Suppliers GetModel(string SuppNo)
        {

            return dal.GetModel(SuppNo);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_Suppliers GetModelB(string SuppNo)
        {

            return dal.GetModelB(SuppNo);
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


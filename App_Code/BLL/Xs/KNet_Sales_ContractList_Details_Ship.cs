using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_Sales_ContractList_Details_Ship
    /// </summary>
    public class KNet_Sales_ContractList_Details_Ship
    {
        private readonly KNet.DAL.KNet_Sales_ContractList_Details_Ship dal = new KNet.DAL.KNet_Sales_ContractList_Details_Ship();
        public KNet_Sales_ContractList_Details_Ship()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ContractNo, string ProductsBarCode, string OwnallPID)
        {
            return dal.Exists(ContractNo, ProductsBarCode, OwnallPID);
        }

        /// <summary>
        /// 增加一条数据 （选择从仓库添加）
        /// </summary>
        public void Add(KNet.Model.KNet_Sales_ContractList_Details_Ship model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据 （在明细表里直接修改）
        /// </summary>
        public void Update(KNet.Model.KNet_Sales_ContractList_Details_Ship model)
        {
            dal.Update(model);
        }
        /// <summary>
        /// 更新一条数据 （选择性追加记录 修改）
        /// </summary>
        public void UpdateB(KNet.Model.KNet_Sales_ContractList_Details_Ship model)
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
        public void DeleteByContractNo(string ID)
        {

            dal.DeleteByContractNo(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_ContractList_Details_Ship GetModel(string ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_ContractList_Details_Ship GetModelB(string ContractNo, string ProductsBarCode, string OwnallPID)
        {

            return dal.GetModelB(ContractNo, ProductsBarCode, OwnallPID);
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
        public DataSet GetTotalList(string strWhere)
        {
            return dal.GetTotalList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetTotalListDetails(string strWhere)
        {
            return dal.GetTotalListDetails(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListJoinProducts(string strWhere)
        {
            return dal.GetListJoinProducts(strWhere);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByView(string strWhere)
        {
            return dal.GetListByView(strWhere);
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


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList1(string strWhere)
        {
            return dal.GetList1(strWhere);
        }

        #endregion  成员方法
    }
}


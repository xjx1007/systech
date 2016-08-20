using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_Sales_ContractList
    /// </summary>
    public class KNet_Sales_ContractList
    {
        private readonly KNet.DAL.KNet_Sales_ContractList dal = new KNet.DAL.KNet_Sales_ContractList();
        public KNet_Sales_ContractList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ContractNo)
        {
            return dal.Exists(ContractNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sales_ContractList model)
        {
            KNet.BLL.KNet_Sales_ContractList_Details Bll = new KNet_Sales_ContractList_Details();
            KNet.BLL.Xs_Contract_FhDetails Bll_FhDetails = new Xs_Contract_FhDetails();
            KNet.BLL.KNet_Sales_ContractList_Details_Ship Bll_Ship = new KNet_Sales_ContractList_Details_Ship();
            if (model.arr_Details != null)
            {
                for (int i = 0; i < model.arr_Details.Count; i++)
                {
                    KNet.Model.KNet_Sales_ContractList_Details Model = (KNet.Model.KNet_Sales_ContractList_Details)model.arr_Details[i];
                    Bll.Add(Model);
                }
            }
            if (model.arr_FhDetails != null)
            {
                for (int i = 0; i < model.arr_FhDetails.Count; i++)
                {
                    KNet.Model.Xs_Contract_FhDetails Model_FhDetails = (KNet.Model.Xs_Contract_FhDetails)model.arr_FhDetails[i];
                    Bll_FhDetails.Add(Model_FhDetails);
                }
            }
            if (model.arr_Ship != null)
            {
                for (int i = 0; i < model.arr_Ship.Count; i++)
                {
                    KNet.Model.KNet_Sales_ContractList_Details_Ship Model_Ship = (KNet.Model.KNet_Sales_ContractList_Details_Ship)model.arr_Ship[i];
                    Bll_Ship.Add(Model_Ship);
                }
            }
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sales_ContractList model)
        {
            KNet.BLL.KNet_Sales_ContractList_Details Bll = new KNet_Sales_ContractList_Details();
            KNet.BLL.Xs_Contract_FhDetails Bll_FhDetails = new Xs_Contract_FhDetails();
            Bll.DeleteByContractNo(model.ContractNo);
            if (model.arr_Details != null)
            {
                for (int i = 0; i < model.arr_Details.Count; i++)
                {
                    KNet.Model.KNet_Sales_ContractList_Details Model = (KNet.Model.KNet_Sales_ContractList_Details)model.arr_Details[i];
                    Bll.Add(Model);
                }
            }
            Bll_FhDetails.DeleteByFID(model.ContractNo);
            if (model.arr_FhDetails != null)
            {
                for (int i = 0; i < model.arr_FhDetails.Count; i++)
                {
                    KNet.Model.Xs_Contract_FhDetails Model_FhDetails = (KNet.Model.Xs_Contract_FhDetails)model.arr_FhDetails[i];
                    Bll_FhDetails.Add(Model_FhDetails);
                }
            }
            dal.Update(model);
        }

        /// <summary>
        /// 更新回复时间
        /// </summary>
        public void UpdateDate(KNet.Model.KNet_Sales_ContractList model)
        {
            dal.UpdateDate(model);
        }


        /// <summary>
        /// 更新要求时间
        /// </summary>
        public void UpdateShipDate(KNet.Model.KNet_Sales_ContractList model)
        {
            dal.UpdateShipDate(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ContractNo)
        {
            dal.Delete(ContractNo);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_ContractList GetModel(string ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_ContractList GetModelB(string ContractNo)
        {
            return dal.GetModelB(ContractNo);
        }

        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }


        /// <summary>
        /// 未执行订单汇总
        /// </summary>
        public DataSet GetTotalList(string strWhere)
        {
            return dal.GetTotalList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetCkList(string strWhere)
        {
            return dal.GetCkList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDetailsList(string strWhere)
        {
            return dal.GetDetailsList(strWhere);
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

        public int GetTotalNumber(string s_ContractNo)
        {

            return dal.GetTotalNumber(s_ContractNo);
 
        }

        #endregion  成员方法
    }
}


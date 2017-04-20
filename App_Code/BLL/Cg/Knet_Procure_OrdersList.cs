using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类Knet_Procure_OrdersList
    /// </summary>
    public class Knet_Procure_OrdersList
    {
        private readonly KNet.DAL.Knet_Procure_OrdersList dal = new KNet.DAL.Knet_Procure_OrdersList();
        public Knet_Procure_OrdersList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string OrderNo)
        {
            return dal.Exists(OrderNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Knet_Procure_OrdersList model)
        {
            if (model.ContractNos.ToString() != "")
            {
                string s_ContractNo = model.ContractNos.ToString();
                //更新采购单为 “已完成”
                string DoSqlOrder = " update KNet_Sales_ContractList set  isOrder='1' where ContractNo in ('" + s_ContractNo.Replace(",", "','") + "')";
                DbHelperSQL.ExecuteSql(DoSqlOrder);
            }
            dal.Add(model);
            KNet.BLL.Knet_Procure_OrdersList_Details BLL_Details = new KNet.BLL.Knet_Procure_OrdersList_Details();
            if (model.Arr_ProductsList != null)
            {
                for (int i = 0; i < model.Arr_ProductsList.Count; i++)
                {
                    KNet.Model.Knet_Procure_OrdersList_Details Model_Details = (KNet.Model.Knet_Procure_OrdersList_Details)model.Arr_ProductsList[i];
                    Model_Details.OrderNo = model.OrderNo;
                    BLL_Details.Add(Model_Details);
                }
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.Knet_Procure_OrdersList model)
        {
            KNet.BLL.Knet_Procure_OrdersList BLL_Procure_OrdersList = new Knet_Procure_OrdersList();
            KNet.Model.Knet_Procure_OrdersList Model_Procure_OrdersList = BLL_Procure_OrdersList.GetModelB(model.OrderNo);
            if (Model_Procure_OrdersList != null)
            {
                if (Model_Procure_OrdersList.ContractNo.ToString() != "")
                {
                    //更新采购单为 “已完成”
                    string DoSqlOrder = " update KNet_Sales_ContractList set isOrder='0' where ContractNo='" + Model_Procure_OrdersList.ContractNo.ToString() + "'";
                    DbHelperSQL.ExecuteSql(DoSqlOrder);
                }
                if (model.ContractNo.ToString() != "")
                {
                    //更新采购单为 “已完成”
                    string DoSqlOrder = " update KNet_Sales_ContractList set isOrder='1' where ContractNo='" + model.ContractNo.ToString() + "'";
                    DbHelperSQL.ExecuteSql(DoSqlOrder);
                }
            }

            dal.Update(model);

            KNet.BLL.Knet_Procure_OrdersList_Details BLL_Details = new KNet.BLL.Knet_Procure_OrdersList_Details();
            BLL_Details.Delete(model.OrderNo);
            if (model.Arr_ProductsList != null)
            {
                for (int i = 0; i < model.Arr_ProductsList.Count; i++)
                {
                    KNet.Model.Knet_Procure_OrdersList_Details Model_Details = (KNet.Model.Knet_Procure_OrdersList_Details)model.Arr_ProductsList[i];
                    Model_Details.OrderNo = model.OrderNo;
                    BLL_Details.Add(Model_Details);
                }
            }
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateIsSend(KNet.Model.Knet_Procure_OrdersList model)
        {
            dal.UpdateIsSend(model);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateRKState(KNet.Model.Knet_Procure_OrdersList model)
        {
            dal.UpdateRKState(model);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateRkState(KNet.Model.Knet_Procure_OrdersList model)
        {
            dal.UpdateRkState(model);
        }

        public bool IsDetails(string s_OrderNo)
        {
            return dal.IsDetails(s_OrderNo);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string OrderNo)
        {
            KNet.BLL.Knet_Procure_OrdersList_Details BLL_Details = new Knet_Procure_OrdersList_Details();
            BLL_Details.Delete(OrderNo);
            dal.Delete(OrderNo);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteByOrderNo(string OrderNo)
        {
            KNet.BLL.Knet_Procure_OrdersList_Details BLL_Details = new Knet_Procure_OrdersList_Details();
            dal.Delete(OrderNo);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_OrdersList GetModel(string ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_OrdersList GetModelB(string OrderNo)
        {
            return dal.GetModelB(OrderNo);
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


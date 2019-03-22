using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类Knet_Procure_WareHouseList 
    /// </summary>
    public class Knet_Procure_WareHouseList
    {
        private readonly KNet.DAL.Knet_Procure_WareHouseList dal = new KNet.DAL.Knet_Procure_WareHouseList();
        public Knet_Procure_WareHouseList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string WareHouseNo)
        {
            return dal.Exists(WareHouseNo);
        }

        public string GetLastCode()
        {
            return dal.GetLastCode();
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Knet_Procure_WareHouseList model)
        {
            if (model.Arr_Products != null)
            {
                for (int i = 0; i < model.Arr_Products.Count; i++)
                {

                    KNet.Model.Knet_Procure_WareHouseList_Details Model_Details = (KNet.Model.Knet_Procure_WareHouseList_Details)model.Arr_Products[i];
                    KNet.BLL.Knet_Procure_WareHouseList_Details Bll_Details = new Knet_Procure_WareHouseList_Details();
                    //string[] str = Model_Details.ProductsBarCode.ToString().Split('+');
                    //string DoSqlOrder = " update KNet_Sampling_List set  InState='1', AuditState='1' where ID in ('" + Model_Details.ProductsBarCode + "')";
                    //DbHelperSQL.ExecuteSql(DoSqlOrder);


                    ////改变订单收货数
                    //KNet.BLL.Knet_Procure_OrdersList_Details BLL_Order = new KNet.BLL.Knet_Procure_OrdersList_Details();
                    //KNet.Model.Knet_Procure_OrdersList_Details Model_Order = new KNet.Model.Knet_Procure_OrdersList_Details();
                    //Model_Order.ID=Model_Details.ProductsUnits;
                    //Model_Order.OrderHaveReceiving=Model_Details.WareHouseAmount;
                    //BLL_Order.UpdateOrderHaveReceive(Model_Order);
                    ////改变主单状态
                    //KNet.BLL.Knet_Procure_OrdersList BLL_Order1 = new KNet.BLL.Knet_Procure_OrdersList();
                    //KNet.Model.Knet_Procure_OrdersList Model_Order1 = new KNet.Model.Knet_Procure_OrdersList();
                    //if (BLL_Order1.IsDetails(model.OrderNo))
                    //{
                    //    Model_Order1.OrderNo = model.OrderNo;
                    //    Model_Order1.KPO_RkState = "1";
                    //    BLL_Order1.UpdateRkState(Model_Order1);
                    //}
                    //else
                    //{
                    //    Model_Order1.OrderNo = model.OrderNo;
                    //    Model_Order1.KPO_RkState = "0";
                    //    BLL_Order1.UpdateRkState(Model_Order1);
                    //}
                    Bll_Details.Add(Model_Details);
                }
                dal.Add(model);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.Knet_Procure_WareHouseList model)
        {
            dal.Update(model);
            KNet.BLL.Knet_Procure_WareHouseList_Details Bll_Details = new Knet_Procure_WareHouseList_Details();
            Bll_Details.UpdateByWareHouseNo(model.WareHouseNo);
            if (model.Arr_Products != null)
            {
                //删除原来的
                Bll_Details.DeleteByWareHouseNo(model.WareHouseNo);
                for (int i = 0; i < model.Arr_Products.Count; i++)
                {
                    KNet.Model.Knet_Procure_WareHouseList_Details Model_Details = (KNet.Model.Knet_Procure_WareHouseList_Details)model.Arr_Products[i];
                    
                    Bll_Details.Add(Model_Details);
                }
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateShip(String WareHouseNo,string s_Ship)
        {
            dal.UpdateShip(WareHouseNo, s_Ship);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string WareHouseNo)
        {

            dal.Delete(WareHouseNo);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateQRState(KNet.Model.Knet_Procure_WareHouseList model)
        {
            dal.UpdateQRState(model);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdatePrintState(KNet.Model.Knet_Procure_WareHouseList model)
        {
            dal.UpdatePrintState(model);

        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_WareHouseList GetModel(string ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_WareHouseList GetModelB(string WareHouseNo)
        {

            return dal.GetModelB(WareHouseNo);
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
        public DataSet GetListByDetails(string strWhere)
        {
            return dal.GetListByDetails(strWhere);
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


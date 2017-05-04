using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_WareHouse_DirectOutList
    /// </summary>
    public class KNet_WareHouse_DirectOutList
    {
        private readonly KNet.DAL.KNet_WareHouse_DirectOutList dal = new KNet.DAL.KNet_WareHouse_DirectOutList();
        public KNet_WareHouse_DirectOutList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string DirectOutNo)
        {
            return dal.Exists(DirectOutNo);
        }
        public void SetPrice(string DirectOutNo)
        {
            dal.SetPrice(DirectOutNo);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_WareHouse_DirectOutList model)
        {

            KNet.BLL.KNet_WareHouse_DirectOutList_Details Bll = new KNet_WareHouse_DirectOutList_Details();
            if (model.Arr_Details != null)
            {
                for (int i = 0; i < model.Arr_Details.Count; i++)
                {
                    KNet.Model.KNet_WareHouse_DirectOutList_Details Model = (KNet.Model.KNet_WareHouse_DirectOutList_Details)model.Arr_Details[i];
                    Model.DirectOutNo = model.DirectOutNo;
                    Bll.Add(Model);
                }
            }
            if (model.Arr_Feight != null)
            {

                KNet.BLL.Xs_Sales_Freight Bll_Freight = new Xs_Sales_Freight();
                for (int i = 0; i < model.Arr_Feight.Count; i++)
                {
                    KNet.Model.Xs_Sales_Freight Model = (KNet.Model.Xs_Sales_Freight)model.Arr_Feight[i];
                    Bll_Freight.Add(Model);
                }
            }
            dal.Add(model);
            if (model.KWD_IsSupp == 1)
            {
                SetPrice(model.DirectOutNo);
            }

        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void AddWithID(KNet.Model.KNet_WareHouse_DirectOutList model)
        {

            try
            {
                KNet.BLL.KNet_WareHouse_DirectOutList_Details Bll = new KNet_WareHouse_DirectOutList_Details();
                if (model.Arr_Details != null)
                {
                    for (int i = 0; i < model.Arr_Details.Count; i++)
                    {
                        KNet.Model.KNet_WareHouse_DirectOutList_Details Model = (KNet.Model.KNet_WareHouse_DirectOutList_Details)model.Arr_Details[i];
                        Model.DirectOutNo = model.DirectOutNo;
                        Bll.AddWithID(Model);
                    }
                }
                dal.Add(model);
                if (model.KWD_IsSupp == 1)
                {
                    SetPrice(model.DirectOutNo);
                }

            }
            catch(Exception ex) { }
        }

        public void UpdateByKpType(KNet.Model.KNet_WareHouse_DirectOutList model)
        {
            dal.UpdateByKpType(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_WareHouse_DirectOutList model)
        {
            dal.Update(model);

            KNet.BLL.KNet_WareHouse_DirectOutList_Details Bll = new KNet_WareHouse_DirectOutList_Details();
            Bll.DeleteByDirectOutNO(model.DirectOutNo);
            if (model.Arr_Details != null)
            {
                for (int i = 0; i < model.Arr_Details.Count; i++)
                {
                    KNet.Model.KNet_WareHouse_DirectOutList_Details Model = (KNet.Model.KNet_WareHouse_DirectOutList_Details)model.Arr_Details[i];
                    Model.DirectOutNo = model.DirectOutNo;
                    Bll.Add(Model);
                }
            }
                if (model.Arr_Feight != null)
                {

                    KNet.BLL.Xs_Sales_Freight Bll_Freight = new Xs_Sales_Freight();
                    for (int i = 0; i < model.Arr_Feight.Count; i++)
                    {
                        KNet.Model.Xs_Sales_Freight Model = (KNet.Model.Xs_Sales_Freight)model.Arr_Feight[i];
                        Bll_Freight.Update(Model);
                    }
                }

                if (model.KWD_IsSupp == 1)
                {
                    SetPrice(model.DirectOutNo);
                }

        }

        /// <summary>
        /// 更新明细
        /// </summary>
        public void UpdateDetails(KNet.Model.KNet_WareHouse_DirectOutList model)
        {
            KNet.BLL.KNet_WareHouse_DirectOutList_Details Bll = new KNet_WareHouse_DirectOutList_Details();
            if (model.Arr_Details != null)
            {
                for (int i = 0; i < model.Arr_Details.Count; i++)
                {
                    KNet.Model.KNet_WareHouse_DirectOutList_Details Model = (KNet.Model.KNet_WareHouse_DirectOutList_Details)model.Arr_Details[i];
                    Model.DirectOutNo = model.DirectOutNo;
                    Bll.Update(Model);
                }
            }
            dal.Update(model);  
            
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpDataSate(KNet.Model.KNet_WareHouse_DirectOutList model)
        {
            dal.UpDataSate(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string DirectOutNo)
        {

            dal.Delete(DirectOutNo);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteByTopic(string Topic)
        {
            dal.DeleteByTopic(Topic);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_DirectOutList GetModel(string ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_DirectOutList GetModelB(string DirectOutNo)
        {
            return dal.GetModelB(DirectOutNo);
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
        public DataSet GetListJoinSalesShip(string strWhere)
        {
            return dal.GetListJoinSalesShip(strWhere);
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


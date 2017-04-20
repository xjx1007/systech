using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_WareHouse_AllocateList 的摘要说明。
    /// </summary>
    public class KNet_WareHouse_AllocateList
    {
        private readonly KNet.DAL.KNet_WareHouse_AllocateList dal = new KNet.DAL.KNet_WareHouse_AllocateList();
        public KNet_WareHouse_AllocateList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string AllocateNo)
        {
            return dal.Exists(AllocateNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_WareHouse_AllocateList model)
        {
            if (model.Arr_List != null)
            {
                KNet.BLL.KNet_WareHouse_AllocateList_Details Bll_Details = new KNet_WareHouse_AllocateList_Details();
                for (int i = 0; i < model.Arr_List.Count; i++)
                {
                    KNet.Model.KNet_WareHouse_AllocateList_Details model_Details = (KNet.Model.KNet_WareHouse_AllocateList_Details)model.Arr_List[i];
                    Bll_Details.Add(model_Details);
                }
            }

            if (model.Arr_List1 != null)
            {
                KNet.BLL.KNet_WareHouse_AllocateList_CPDetails Bll_Details = new KNet_WareHouse_AllocateList_CPDetails();
                for (int i = 0; i < model.Arr_List1.Count; i++)
                {
                    KNet.Model.KNet_WareHouse_AllocateList_CPDetails model_Details = (KNet.Model.KNet_WareHouse_AllocateList_CPDetails)model.Arr_List1[i];
                    Bll_Details.Add(model_Details);
                }
            }
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_WareHouse_AllocateList model)
        {
            if (model.Arr_List != null)
            {
                KNet.BLL.KNet_WareHouse_AllocateList_Details Bll_Details = new KNet_WareHouse_AllocateList_Details();
                Bll_Details.DeleteByAllocateNo(model.AllocateNo);
                for (int i = 0; i < model.Arr_List.Count; i++)
                {
                    KNet.Model.KNet_WareHouse_AllocateList_Details model_Details = (KNet.Model.KNet_WareHouse_AllocateList_Details)model.Arr_List[i];
                    Bll_Details.Add(model_Details);
                }
            }

            if (model.Arr_List1 != null)
            {
                KNet.BLL.KNet_WareHouse_AllocateList_CPDetails Bll_Details = new KNet_WareHouse_AllocateList_CPDetails();
                Bll_Details.DeleteByAllocateNo(model.AllocateNo);
                for (int i = 0; i < model.Arr_List1.Count; i++)
                {
                    KNet.Model.KNet_WareHouse_AllocateList_CPDetails model_Details = (KNet.Model.KNet_WareHouse_AllocateList_CPDetails)model.Arr_List1[i];
                    Bll_Details.Add(model_Details);
                }
            }
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string AllocateNo)
        {

            dal.Delete(AllocateNo);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_AllocateList GetModel(string ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_AllocateList GetModelB(string AllocateNo)
        {

            return dal.GetModelB(AllocateNo);
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
        public DataSet GetDetailsList(string strWhere)
        {
            return dal.GetDetailsList(strWhere);
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


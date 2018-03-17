using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_WareHouse_WareCheckList 
    /// </summary>
    public class KNet_WareHouse_WareCheckList
    {
        private readonly KNet.DAL.KNet_WareHouse_WareCheckList dal = new KNet.DAL.KNet_WareHouse_WareCheckList();
        public KNet_WareHouse_WareCheckList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string WareCheckNo)
        {
            return dal.Exists(WareCheckNo);
        }

        public string GetLastCode()
        {
            return dal.GetLastCode();
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_WareHouse_WareCheckList model)
        {
            dal.Add(model);
            if (model.arr_Details != null)
            {
                for(int i=0;i<model.arr_Details.Count;i++)
                {
                    KNet.BLL.KNet_WareHouse_WareCheckList_Details Bll_Details = new KNet_WareHouse_WareCheckList_Details();
                    KNet.Model.KNet_WareHouse_WareCheckList_Details Model_Details = (KNet.Model.KNet_WareHouse_WareCheckList_Details)model.arr_Details[i];
                    Bll_Details.Add(Model_Details);
                }

 
            }

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_WareHouse_WareCheckList model)
        {
            dal.Update(model);

            if (model.arr_Details != null)
            {
                KNet.BLL.KNet_WareHouse_WareCheckList_Details Bll_Details = new KNet_WareHouse_WareCheckList_Details();
                Bll_Details.DeleteByFID(model.WareCheckNo);
                for (int i = 0; i < model.arr_Details.Count; i++)
                {
                    KNet.Model.KNet_WareHouse_WareCheckList_Details Model_Details = (KNet.Model.KNet_WareHouse_WareCheckList_Details)model.arr_Details[i];
                    Bll_Details.Add(Model_Details);
                }


            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string WareCheckNo)
        {

            dal.Delete(WareCheckNo);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_WareCheckList GetModel(string ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_WareHouse_WareCheckList GetModelB(string WareCheckNo)
        {

            return dal.GetModelB(WareCheckNo);
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


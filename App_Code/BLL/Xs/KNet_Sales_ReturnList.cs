using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_Sales_ReturnList 
    /// </summary>
    public class KNet_Sales_ReturnList
    {
        private readonly KNet.DAL.KNet_Sales_ReturnList dal = new KNet.DAL.KNet_Sales_ReturnList();
        public KNet_Sales_ReturnList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ReturnNo)
        {
            return dal.Exists(ReturnNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sales_ReturnList model)
        {
            KNet.BLL.KNet_Sales_ReturnList_Details Bll_Details = new KNet_Sales_ReturnList_Details();
            if (model.Arr_Details != null)
            {
                for (int i = 0; i < model.Arr_Details.Count; i++)
                {
                    KNet.Model.KNet_Sales_ReturnList_Details Model = (KNet.Model.KNet_Sales_ReturnList_Details)model.Arr_Details[i];
                    Bll_Details.Add(Model);
                }
            }
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sales_ReturnList model)
        {
            dal.Update(model);
            KNet.BLL.KNet_Sales_ReturnList_Details Bll_Details = new KNet_Sales_ReturnList_Details();
            Bll_Details.DeleteByReturnNo(model.ReturnNo);
            if (model.Arr_Details != null)
            {
                for (int i = 0; i < model.Arr_Details.Count; i++)
                {
                    KNet.Model.KNet_Sales_ReturnList_Details Model = (KNet.Model.KNet_Sales_ReturnList_Details)model.Arr_Details[i];
                    Bll_Details.Add(Model);
                }
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ReturnNo)
        {

            dal.Delete(ReturnNo);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_ReturnList GetModel(string ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_ReturnList GetModelB(string ReturnNo)
        {

            return dal.GetModelB(ReturnNo);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
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



        #endregion  成员方法
    }
}


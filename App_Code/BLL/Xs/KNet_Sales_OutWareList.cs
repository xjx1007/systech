using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_Sales_OutWareList
    /// </summary>
    public class KNet_Sales_OutWareList
    {
        private readonly KNet.DAL.KNet_Sales_OutWareList dal = new KNet.DAL.KNet_Sales_OutWareList();
        public KNet_Sales_OutWareList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string OutWareNo)
        {
            return dal.Exists(OutWareNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sales_OutWareList model)
        {
            KNet.BLL.KNet_Sales_OutWareList_Details Bll = new KNet_Sales_OutWareList_Details();
            if (model.Arr_Details != null)
            {
                for (int i = 0; i < model.Arr_Details.Count; i++)
                {
                    KNet.Model.KNet_Sales_OutWareList_Details Model = (KNet.Model.KNet_Sales_OutWareList_Details)model.Arr_Details[i];
                    Bll.Add(Model);
                }
            }
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sales_OutWareList model)
        {
            dal.Update(model);
            KNet.BLL.KNet_Sales_OutWareList_Details Bll = new KNet_Sales_OutWareList_Details();
            Bll.DeleteByOutWareNo(model.OutWareNo);

            if (model.Arr_Details != null)
            {
                for (int i = 0; i < model.Arr_Details.Count; i++)
                {
                    KNet.Model.KNet_Sales_OutWareList_Details Model = (KNet.Model.KNet_Sales_OutWareList_Details)model.Arr_Details[i];
                    Bll.Add(Model);
                }
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string OutWareNo)
        {

            dal.Delete(OutWareNo);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_OutWareList GetModel(string ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个上次
        /// </summary>
        public KNet.Model.KNet_Sales_OutWareList GetLaseModel(string s_CustomerValue)
        {
            return dal.GetLaseModel(s_CustomerValue);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_OutWareList GetModelB(string OutWareNo)
        {

            return dal.GetModelB(OutWareNo);
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


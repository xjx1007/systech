using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_Sales_ClientList 
    /// </summary>
    public class KNet_Sales_ClientList
    {
        private readonly KNet.DAL.KNet_Sales_ClientList dal = new KNet.DAL.KNet_Sales_ClientList();
        public KNet_Sales_ClientList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在 LoginID  记录
        /// </summary>
        public bool Exists_LoginID(string LoginID)
        {
            return dal.Exists_LoginID(LoginID);
        }
        /// <summary>
        /// 是否存在 CustomerValue  记录
        /// </summary>
        public bool Exists_CustomerValue(string CustomerValue)
        {
            return dal.Exists_CustomerValue(CustomerValue);
        }
        /// <summary>
        /// 是否存在同城的 CustomerName  记录
        /// </summary>
        public bool Exists_CustomerName(string CustomerName, string CustomerProvinces, string CustomerCity)
        {
            return dal.Exists_CustomerName(CustomerName, CustomerProvinces, CustomerCity);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sales_ClientList model)
        {
            if (model.Arr_Products != null)
            {
                KNet.BLL.Xs_Customer_Products BLL_Customer_Products = new KNet.BLL.Xs_Customer_Products();
                for (int i = 0; i < model.Arr_Products.Count; i++)
                {
                    KNet.Model.Xs_Customer_Products Model_Customer_Products = (KNet.Model.Xs_Customer_Products)model.Arr_Products[i];
                    BLL_Customer_Products.Add(Model_Customer_Products);
                }
            }
            if (model.Arr_FhDetails != null)
            {
                KNet.BLL.Xs_Customer_FhInfo BLL_FhInfo = new KNet.BLL.Xs_Customer_FhInfo();
                for (int i = 0; i < model.Arr_FhDetails.Count; i++)
                {
                    KNet.Model.Xs_Customer_FhInfo Model_FhInfo = (KNet.Model.Xs_Customer_FhInfo)model.Arr_FhDetails[i];
                    BLL_FhInfo.Add(Model_FhInfo);
                }
            }
            if (model.Arr_LinkMan.Count > 0)
            {
                KNet.Model.XS_Compy_LinkMan Model_Compy_LinkMan = (KNet.Model.XS_Compy_LinkMan)model.Arr_LinkMan[0];
                KNet.BLL.XS_Compy_LinkMan Bll_Compy_LinkMan=new KNet.BLL.XS_Compy_LinkMan();
                Bll_Compy_LinkMan.Add(Model_Compy_LinkMan);
                
            }
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sales_ClientList model)
        {
            KNet.BLL.Xs_Customer_Products BLL_Customer_Products = new KNet.BLL.Xs_Customer_Products();
            BLL_Customer_Products.DeleteByCustomer(model.CustomerValue);
            if (model.Arr_Products != null)
            {
                for (int i = 0; i < model.Arr_Products.Count; i++)
                {
                    KNet.Model.Xs_Customer_Products Model_Customer_Products = (KNet.Model.Xs_Customer_Products)model.Arr_Products[i];
                    BLL_Customer_Products.Add(Model_Customer_Products);
                }
            }
                KNet.BLL.Xs_Customer_FhInfo BLL_FhInfo = new KNet.BLL.Xs_Customer_FhInfo();
                BLL_FhInfo.DeleteByCustomerValue(model.CustomerValue);
            if (model.Arr_FhDetails != null)
            {
                for (int i = 0; i < model.Arr_FhDetails.Count; i++)
                {
                    KNet.Model.Xs_Customer_FhInfo Model_FhInfo = (KNet.Model.Xs_Customer_FhInfo)model.Arr_FhDetails[i];
                    BLL_FhInfo.Add(Model_FhInfo);
                }
            }
            if (model.Arr_LinkMan.Count > 0)
            {
                KNet.Model.XS_Compy_LinkMan Model_Compy_LinkMan = (KNet.Model.XS_Compy_LinkMan)model.Arr_LinkMan[0];
                KNet.BLL.XS_Compy_LinkMan Bll_Compy_LinkMan = new KNet.BLL.XS_Compy_LinkMan();
                Bll_Compy_LinkMan.UpdateB(Model_Compy_LinkMan);

            }
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ID)
        {

            dal.Delete(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_ClientList GetModel(string ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_ClientList GetModelB(string CustomerValue)
        {

            return dal.GetModelB(CustomerValue);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_ClientList GetModelC(string LoginID, string LoginPassword)
        {

            return dal.GetModelC(LoginID, LoginPassword);
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


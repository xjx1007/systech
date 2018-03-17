using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Cw_Accounting_Pay
    /// </summary>
    public partial class Cw_Accounting_Pay
    {
        private readonly KNet.DAL.Cw_Accounting_Pay dal = new KNet.DAL.Cw_Accounting_Pay();
        public Cw_Accounting_Pay()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CAA_ID)
        {
            return dal.Exists(CAA_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cw_Accounting_Pay model)
        {
            KNet.BLL.Cw_Accounting_Pay_Details Bll_Details = new Cw_Accounting_Pay_Details();
            dal.Add(model);


            KNet.BLL.Cw_Bill_DirectOut_PayDetails Bll_Direct = new Cw_Bill_DirectOut_PayDetails();

            if (model.arr_Details != null)
            {
                for (int i = 0; i < model.arr_Details.Count; i++)
                {
                    KNet.Model.Cw_Accounting_Pay_Details Model_Details = (KNet.Model.Cw_Accounting_Pay_Details)model.arr_Details[i];
                    Model_Details.CAY_CAAID = model.CAA_ID;
                    Bll_Details.Add(Model_Details);
                }
            }
            KNet.BLL.Cw_Bill_Details Bll_BillDetails = new Cw_Bill_Details();
            if (model.arr_BillDetails != null)
            {
                for (int i = 0; i < model.arr_BillDetails.Count; i++)
                {
                    KNet.Model.Cw_Bill_Details Model_Details = (KNet.Model.Cw_Bill_Details)model.arr_BillDetails[i];
                    Model_Details.CBD_FID = model.CAA_ID;
                    Bll_BillDetails.Add(Model_Details);
                }
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cw_Accounting_Pay model)
        {
            try
            {

                KNet.BLL.Cw_Accounting_Pay_Details Bll_Details = new Cw_Accounting_Pay_Details();
                if (dal.Update(model))
                {


                    KNet.BLL.Cw_Bill_DirectOut_PayDetails Bll_Direct = new Cw_Bill_DirectOut_PayDetails();
                    Bll_Direct.DeleteByFID(model.CAA_ID);
                    if (model.arr_FpDetails != null)
                    {
                        for (int i = 0; i < model.arr_FpDetails.Count; i++)
                        {
                            KNet.Model.Cw_Bill_DirectOut_PayDetails Model_FpDetails = (KNet.Model.Cw_Bill_DirectOut_PayDetails)model.arr_FpDetails[i];
                            Model_FpDetails.CBDP_PayMentID = model.CAA_ID;
                            Bll_Direct.Add(Model_FpDetails);
                        }
                    }

                    if (Bll_Details.DeleteByCAAID(model.CAA_ID))
                    {
                        if (model.arr_Details != null)
                        {
                            for (int i = 0; i < model.arr_Details.Count; i++)
                            {
                                KNet.Model.Cw_Accounting_Pay_Details Model_Details = (KNet.Model.Cw_Accounting_Pay_Details)model.arr_Details[i];
                                Model_Details.CAY_CAAID = model.CAA_ID;
                                Bll_Details.Add(Model_Details);
                            }
                        }
                    }

                    KNet.BLL.Cw_Bill_Details Bll_BillDetails = new Cw_Bill_Details();
                    Bll_BillDetails.DeleteByFID(model.CAA_ID);
                    if (model.arr_BillDetails != null)
                    {
                        for (int i = 0; i < model.arr_BillDetails.Count; i++)
                        {
                            KNet.Model.Cw_Bill_Details Model_Details = (KNet.Model.Cw_Bill_Details)model.arr_BillDetails[i];
                            Model_Details.CBD_FID = model.CAA_ID;

                            Bll_BillDetails.Add(Model_Details);
                        }
                    }

                }
                return true;
            }
            catch (Exception ex) { return false; }

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string CAA_ID)
        {

            return dal.Delete(CAA_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string CAA_IDlist)
        {
            return dal.DeleteList(CAA_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Cw_Accounting_Pay GetModel(string CAA_ID)
        {

            return dal.GetModel(CAA_ID);
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

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}


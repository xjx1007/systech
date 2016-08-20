using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Cw_Accounting_Payment
    /// </summary>
    public partial class Cw_Accounting_Payment
    {
        private readonly KNet.DAL.Cw_Accounting_Payment dal = new KNet.DAL.Cw_Accounting_Payment();
        public Cw_Accounting_Payment()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CAP_ID)
        {
            return dal.Exists(CAP_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cw_Accounting_Payment model)
        {
            try
            {
                dal.Add(model);
                if (model.arr_Details != null)
                {
                    KNet.BLL.Cw_Accounting_PaymentDetails Bll_Details = new Cw_Accounting_PaymentDetails();
                    for (int i = 0; i < model.arr_Details.Count; i++)
                    {
                        KNet.Model.Cw_Accounting_PaymentDetails Model_Details = (KNet.Model.Cw_Accounting_PaymentDetails)model.arr_Details[i];
                        Bll_Details.Add(Model_Details);
                    }
                }
                //出库单
                if (model.arr_DirectOut != null)
                {
                    KNet.BLL.KNet_WareHouse_DirectOutList Bll_DirectDetails = new KNet_WareHouse_DirectOutList();
                    for (int i = 0; i < model.arr_DirectOut.Count; i++)
                    {
                        KNet.Model.KNet_WareHouse_DirectOutList Model_DirectOutDetails = (KNet.Model.KNet_WareHouse_DirectOutList)model.arr_DirectOut[i];

                        if (Model_DirectOutDetails.isChange == 1)
                        {
                            Bll_DirectDetails.AddWithID(Model_DirectOutDetails);
                        }
                        else if (Model_DirectOutDetails.isChange == 0)
                        {
                            //本月
                            Bll_DirectDetails.UpdateDetails(Model_DirectOutDetails);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
               
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ArrayList arr_Details)
        {
            try
            {
                if (arr_Details.Count > 0)
                {
                    for (int i = 0; i < arr_Details.Count; i++)
                    {
                        KNet.Model.Cw_Accounting_Payment model = (KNet.Model.Cw_Accounting_Payment)arr_Details[i];
                        dal.Add(model);
                    }
                }
                return true;
            }
            catch { return false; }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cw_Accounting_Payment model)
        {
            if (dal.Update(model))
            {
                KNet.BLL.Cw_Accounting_PaymentDetails Bll_Details = new Cw_Accounting_PaymentDetails();
                Bll_Details.DeleteByCARID(model.CAP_ID);
                if (model.arr_Details != null)
                {
                    for (int i = 0; i < model.arr_Details.Count; i++)
                    {
                        KNet.Model.Cw_Accounting_PaymentDetails Model_Details = (KNet.Model.Cw_Accounting_PaymentDetails)model.arr_Details[i];
                        Bll_Details.Add(Model_Details);
                    }
                }
                KNet.BLL.KNet_WareHouse_DirectOutList Bll_DirectDetails = new KNet_WareHouse_DirectOutList();
                if (model.arr_DirectOut.Count != null)
                {
                    Bll_DirectDetails.DeleteByTopic(model.CAP_ID);
                    for (int i = 0; i < model.arr_DirectOut.Count; i++)
                    {
                        KNet.Model.KNet_WareHouse_DirectOutList Model_DirectOutDetails = (KNet.Model.KNet_WareHouse_DirectOutList)model.arr_DirectOut[i];
                        if (Model_DirectOutDetails.isChange == 1)
                        {
                            Bll_DirectDetails.AddWithID(Model_DirectOutDetails);
                        }
                        else if (Model_DirectOutDetails.isChange == 0)
                        {
                            Bll_DirectDetails.UpdateDetails(Model_DirectOutDetails);
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string CAP_ID)
        {

            return dal.Delete(CAP_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string CAP_IDlist)
        {
            return dal.DeleteList(CAP_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Cw_Accounting_Payment GetModel(string CAP_ID)
        {

            return dal.GetModel(CAP_ID);
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
        public List<KNet.Model.Cw_Accounting_Payment> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Cw_Accounting_Payment> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Cw_Accounting_Payment> modelList = new List<KNet.Model.Cw_Accounting_Payment>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Cw_Accounting_Payment model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Cw_Accounting_Payment();
                    if (dt.Rows[n]["CAP_ID"] != null && dt.Rows[n]["CAP_ID"].ToString() != "")
                    {
                        model.CAP_ID = dt.Rows[n]["CAP_ID"].ToString();
                    }
                    if (dt.Rows[n]["CAP_FID"] != null && dt.Rows[n]["CAP_FID"].ToString() != "")
                    {
                        model.CAP_FID = dt.Rows[n]["CAP_FID"].ToString();
                    }
                    if (dt.Rows[n]["CAP_Code"] != null && dt.Rows[n]["CAP_Code"].ToString() != "")
                    {
                        model.CAP_Code = dt.Rows[n]["CAP_Code"].ToString();
                    }
                    if (dt.Rows[n]["CAP_Title"] != null && dt.Rows[n]["CAP_Title"].ToString() != "")
                    {
                        model.CAP_Title = dt.Rows[n]["CAP_Title"].ToString();
                    }
                    if (dt.Rows[n]["CAP_STime"] != null && dt.Rows[n]["CAP_STime"].ToString() != "")
                    {
                        model.CAP_STime = DateTime.Parse(dt.Rows[n]["CAP_STime"].ToString());
                    }
                    if (dt.Rows[n]["CAP_DutyPerson"] != null && dt.Rows[n]["CAP_DutyPerson"].ToString() != "")
                    {
                        model.CAP_DutyPerson = dt.Rows[n]["CAP_DutyPerson"].ToString();
                    }
                    if (dt.Rows[n]["CAP_CustomerValue"] != null && dt.Rows[n]["CAP_CustomerValue"].ToString() != "")
                    {
                        model.CAP_CustomerValue = dt.Rows[n]["CAP_CustomerValue"].ToString();
                    }
                    if (dt.Rows[n]["CAP_Type"] != null && dt.Rows[n]["CAP_Type"].ToString() != "")
                    {
                        model.CAP_Type = int.Parse(dt.Rows[n]["CAP_Type"].ToString());
                    }
                    if (dt.Rows[n]["CAP_State"] != null && dt.Rows[n]["CAP_State"].ToString() != "")
                    {
                        model.CAP_State = int.Parse(dt.Rows[n]["CAP_State"].ToString());
                    }
                    if (dt.Rows[n]["CAP_ReceiveMoney"] != null && dt.Rows[n]["CAP_ReceiveMoney"].ToString() != "")
                    {
                        model.CAP_ReceiveMoney = decimal.Parse(dt.Rows[n]["CAP_ReceiveMoney"].ToString());
                    }
                    if (dt.Rows[n]["CAP_Bank"] != null && dt.Rows[n]["CAP_Bank"].ToString() != "")
                    {
                        model.CAP_Bank = dt.Rows[n]["CAP_Bank"].ToString();
                    }
                    if (dt.Rows[n]["CAP_IsFP"] != null && dt.Rows[n]["CAP_IsFP"].ToString() != "")
                    {
                        model.CAP_IsFP = dt.Rows[n]["CAP_IsFP"].ToString();
                    }
                    if (dt.Rows[n]["CAP_Details"] != null && dt.Rows[n]["CAP_Details"].ToString() != "")
                    {
                        model.CAP_Details = dt.Rows[n]["CAP_Details"].ToString();
                    }
                    if (dt.Rows[n]["CAP_Del"] != null && dt.Rows[n]["CAP_Del"].ToString() != "")
                    {
                        model.CAP_Del = int.Parse(dt.Rows[n]["CAP_Del"].ToString());
                    }
                    if (dt.Rows[n]["CAP_Creator"] != null && dt.Rows[n]["CAP_Creator"].ToString() != "")
                    {
                        model.CAP_Creator = dt.Rows[n]["CAP_Creator"].ToString();
                    }
                    if (dt.Rows[n]["CAP_CTime"] != null && dt.Rows[n]["CAP_CTime"].ToString() != "")
                    {
                        model.CAP_CTime = DateTime.Parse(dt.Rows[n]["CAP_CTime"].ToString());
                    }
                    if (dt.Rows[n]["CAP_Mender"] != null && dt.Rows[n]["CAP_Mender"].ToString() != "")
                    {
                        model.CAP_Mender = dt.Rows[n]["CAP_Mender"].ToString();
                    }
                    if (dt.Rows[n]["CAP_MTime"] != null && dt.Rows[n]["CAP_MTime"].ToString() != "")
                    {
                        model.CAP_MTime = DateTime.Parse(dt.Rows[n]["CAP_MTime"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
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


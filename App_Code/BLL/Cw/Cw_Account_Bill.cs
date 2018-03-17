using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Cw_Account_Bill
    /// </summary>
    public partial class Cw_Account_Bill
    {
        private readonly KNet.DAL.Cw_Account_Bill dal = new KNet.DAL.Cw_Account_Bill();
        public Cw_Account_Bill()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CAB_ID)
        {
            return dal.Exists(CAB_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cw_Account_Bill model)
        {
            dal.Add(model);
            KNet.BLL.Cw_Account_Bill_Details Bll_Details = new Cw_Account_Bill_Details();
            if (model.arr_Details != null)
            {
                for (int i = 0; i < model.arr_Details.Count; i++)
                {
                    KNet.Model.Cw_Account_Bill_Details Model_Details = (KNet.Model.Cw_Account_Bill_Details)model.arr_Details[i];
                    Bll_Details.Add(Model_Details);
                }
            }
            KNet.BLL.Cw_Account_Bill_Outimes Bll_Outimes = new Cw_Account_Bill_Outimes();
            if (model.arr_OutTimes != null)
            {
                for (int i = 0; i < model.arr_OutTimes.Count; i++)
                {
                    KNet.Model.Cw_Account_Bill_Outimes Model_Details = (KNet.Model.Cw_Account_Bill_Outimes)model.arr_OutTimes[i];
                    Bll_Outimes.Add(Model_Details);
                }
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cw_Account_Bill model)
        {
            if (dal.Update(model))
            {
                KNet.BLL.Cw_Account_Bill_Details Bll_Details = new Cw_Account_Bill_Details();
                Bll_Details.DeleteByCAAID(model.CAB_ID);
                if (model.arr_Details != null)
                {
                    for (int i = 0; i < model.arr_Details.Count; i++)
                    {
                        KNet.Model.Cw_Account_Bill_Details Model_Details = (KNet.Model.Cw_Account_Bill_Details)model.arr_Details[i];
                        Bll_Details.Add(Model_Details);
                    }
                }
                KNet.BLL.Cw_Account_Bill_Outimes Bll_Outimes = new Cw_Account_Bill_Outimes();
                Bll_Outimes.DeleteByFID(model.CAB_ID);
                if (model.arr_OutTimes != null)
                {
                    for (int i = 0; i < model.arr_OutTimes.Count; i++)
                    {
                        KNet.Model.Cw_Account_Bill_Outimes Model_Details = (KNet.Model.Cw_Account_Bill_Outimes)model.arr_OutTimes[i];
                        Bll_Outimes.Add(Model_Details);
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
        public bool Delete(string CAB_ID)
        {

            return dal.Delete(CAB_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string CAB_IDlist)
        {
            return dal.DeleteList(CAB_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Cw_Account_Bill GetModel(string CAB_ID)
        {

            return dal.GetModel(CAB_ID);
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
        public List<KNet.Model.Cw_Account_Bill> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Cw_Account_Bill> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Cw_Account_Bill> modelList = new List<KNet.Model.Cw_Account_Bill>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Cw_Account_Bill model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Cw_Account_Bill();
                    if (dt.Rows[n]["CAB_ID"] != null && dt.Rows[n]["CAB_ID"].ToString() != "")
                    {
                        model.CAB_ID = dt.Rows[n]["CAB_ID"].ToString();
                    }
                    if (dt.Rows[n]["CAB_Code"] != null && dt.Rows[n]["CAB_Code"].ToString() != "")
                    {
                        model.CAB_Code = dt.Rows[n]["CAB_Code"].ToString();
                    }
                    if (dt.Rows[n]["CAB_Content"] != null && dt.Rows[n]["CAB_Content"].ToString() != "")
                    {
                        model.CAB_Content = dt.Rows[n]["CAB_Content"].ToString();
                    }
                    if (dt.Rows[n]["CAB_DutyPerson"] != null && dt.Rows[n]["CAB_DutyPerson"].ToString() != "")
                    {
                        model.CAB_DutyPerson = dt.Rows[n]["CAB_DutyPerson"].ToString();
                    }
                    if (dt.Rows[n]["CAB_CustomerValue"] != null && dt.Rows[n]["CAB_CustomerValue"].ToString() != "")
                    {
                        model.CAB_CustomerValue = dt.Rows[n]["CAB_CustomerValue"].ToString();
                    }
                    if (dt.Rows[n]["CAB_ContractNo"] != null && dt.Rows[n]["CAB_ContractNo"].ToString() != "")
                    {
                        model.CAB_ContractNo = dt.Rows[n]["CAB_ContractNo"].ToString();
                    }
                    if (dt.Rows[n]["CAB_BillType"] != null && dt.Rows[n]["CAB_BillType"].ToString() != "")
                    {
                        model.CAB_BillType = int.Parse(dt.Rows[n]["CAB_BillType"].ToString());
                    }
                    if (dt.Rows[n]["CAB_Money"] != null && dt.Rows[n]["CAB_Money"].ToString() != "")
                    {
                        model.CAB_Money = decimal.Parse(dt.Rows[n]["CAB_Money"].ToString());
                    }
                    if (dt.Rows[n]["CAB_BillNumber"] != null && dt.Rows[n]["CAB_BillNumber"].ToString() != "")
                    {
                        model.CAB_BillNumber = dt.Rows[n]["CAB_BillNumber"].ToString();
                    }
                    if (dt.Rows[n]["CAB_Stime"] != null && dt.Rows[n]["CAB_Stime"].ToString() != "")
                    {
                        model.CAB_Stime = DateTime.Parse(dt.Rows[n]["CAB_Stime"].ToString());
                    }
                    if (dt.Rows[n]["CAB_Brokerage"] != null && dt.Rows[n]["CAB_Brokerage"].ToString() != "")
                    {
                        model.CAB_Brokerage = dt.Rows[n]["CAB_Brokerage"].ToString();
                    }
                    if (dt.Rows[n]["CAB_Remarks"] != null && dt.Rows[n]["CAB_Remarks"].ToString() != "")
                    {
                        model.CAB_Remarks = dt.Rows[n]["CAB_Remarks"].ToString();
                    }
                    if (dt.Rows[n]["CAB_Ctime"] != null && dt.Rows[n]["CAB_Ctime"].ToString() != "")
                    {
                        model.CAB_Ctime = DateTime.Parse(dt.Rows[n]["CAB_Ctime"].ToString());
                    }
                    if (dt.Rows[n]["CAB_Creator"] != null && dt.Rows[n]["CAB_Creator"].ToString() != "")
                    {
                        model.CAB_Creator = dt.Rows[n]["CAB_Creator"].ToString();
                    }
                    if (dt.Rows[n]["CAB_Mtime"] != null && dt.Rows[n]["CAB_Mtime"].ToString() != "")
                    {
                        model.CAB_Mtime = DateTime.Parse(dt.Rows[n]["CAB_Mtime"].ToString());
                    }
                    if (dt.Rows[n]["CAB_Mender"] != null && dt.Rows[n]["CAB_Mender"].ToString() != "")
                    {
                        model.CAB_Mender = dt.Rows[n]["CAB_Mender"].ToString();
                    }
                    if (dt.Rows[n]["CAB_Del"] != null && dt.Rows[n]["CAB_Del"].ToString() != "")
                    {
                        model.CAB_Del = int.Parse(dt.Rows[n]["CAB_Del"].ToString());
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


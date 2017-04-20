using System;
using System.Data;
using System.Collections.Generic;
using KNet.Common;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Xs_Sales_Quotes
    /// </summary>
    public partial class Xs_Sales_Quotes
    {
        private readonly KNet.DAL.Xs_Sales_Quotes dal = new KNet.DAL.Xs_Sales_Quotes();
        public Xs_Sales_Quotes()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XSQ_ID)
        {
            return dal.Exists(XSQ_ID);
        }

        public string  GetLastCode()
        {
            return dal.GetLastCode();
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Sales_Quotes model)
        {
            dal.Add(model);
            KNet.BLL.Xs_Sales_Quotes_Details BLL_Details = new KNet.BLL.Xs_Sales_Quotes_Details();
            if (model.Arr_ProductsList != null)
            {
                for (int i = 0; i < model.Arr_ProductsList.Count; i++)
                {
                    KNet.Model.Xs_Sales_Quotes_Details Model_Details = (KNet.Model.Xs_Sales_Quotes_Details)model.Arr_ProductsList[i];
                    Model_Details.SQD_FID = model.XSQ_ID;
                    BLL_Details.Add(Model_Details);
                }
            }

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Sales_Quotes model)
        {
            KNet.BLL.Xs_Sales_Quotes_Details BLL_Details = new KNet.BLL.Xs_Sales_Quotes_Details();
            if (BLL_Details.Delete(model.XSQ_ID))
            {
                if (model.Arr_ProductsList != null)
                {
                    for (int i = 0; i < model.Arr_ProductsList.Count; i++)
                    {
                        KNet.Model.Xs_Sales_Quotes_Details Model_Details = (KNet.Model.Xs_Sales_Quotes_Details)model.Arr_ProductsList[i];
                        Model_Details.SQD_FID = model.XSQ_ID;
                        BLL_Details.Add(Model_Details);
                    }
                }
            }
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string XSQ_ID)
        {

            return dal.Delete(XSQ_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string XSQ_IDlist)
        {
            return dal.DeleteList(XSQ_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Xs_Sales_Quotes GetModel(string XSQ_ID)
        {

            return dal.GetModel(XSQ_ID);
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
        public List<KNet.Model.Xs_Sales_Quotes> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Xs_Sales_Quotes> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Xs_Sales_Quotes> modelList = new List<KNet.Model.Xs_Sales_Quotes>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Xs_Sales_Quotes model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Xs_Sales_Quotes();
                    if (dt.Rows[n]["XSQ_ID"] != null && dt.Rows[n]["XSQ_ID"].ToString() != "")
                    {
                        model.XSQ_ID = dt.Rows[n]["XSQ_ID"].ToString();
                    }
                    if (dt.Rows[n]["XSQ_Code"] != null && dt.Rows[n]["XSQ_Code"].ToString() != "")
                    {
                        model.XSQ_Code = dt.Rows[n]["XSQ_Code"].ToString();
                    }
                    if (dt.Rows[n]["XSQ_SalesChance"] != null && dt.Rows[n]["XSQ_SalesChance"].ToString() != "")
                    {
                        model.XSQ_SalesChance = dt.Rows[n]["XSQ_SalesChance"].ToString();
                    }
                    if (dt.Rows[n]["XSQ_Name"] != null && dt.Rows[n]["XSQ_Name"].ToString() != "")
                    {
                        model.XSQ_Name = dt.Rows[n]["XSQ_Name"].ToString();
                    }
                    if (dt.Rows[n]["XSQ_Step"] != null && dt.Rows[n]["XSQ_Step"].ToString() != "")
                    {
                        model.XSQ_Step = dt.Rows[n]["XSQ_Step"].ToString();
                    }
                    if (dt.Rows[n]["XSQ_STime"] != null && dt.Rows[n]["XSQ_STime"].ToString() != "")
                    {
                        model.XSQ_STime = DateTime.Parse(dt.Rows[n]["XSQ_STime"].ToString());
                    }
                    if (dt.Rows[n]["XSQ_CustomerValue"] != null && dt.Rows[n]["XSQ_CustomerValue"].ToString() != "")
                    {
                        model.XSQ_CustomerValue = dt.Rows[n]["XSQ_CustomerValue"].ToString();
                    }
                    if (dt.Rows[n]["XSQ_LinkMan"] != null && dt.Rows[n]["XSQ_LinkMan"].ToString() != "")
                    {
                        model.XSQ_LinkMan = dt.Rows[n]["XSQ_LinkMan"].ToString();
                    }
                    if (dt.Rows[n]["XSQ_DutyPerson"] != null && dt.Rows[n]["XSQ_DutyPerson"].ToString() != "")
                    {
                        model.XSQ_DutyPerson = dt.Rows[n]["XSQ_DutyPerson"].ToString();
                    }
                    if (dt.Rows[n]["XSQ_Payment"] != null && dt.Rows[n]["XSQ_Payment"].ToString() != "")
                    {
                        model.XSQ_Payment = dt.Rows[n]["XSQ_Payment"].ToString();
                    }
                    if (dt.Rows[n]["XSQ_Remarks"] != null && dt.Rows[n]["XSQ_Remarks"].ToString() != "")
                    {
                        model.XSQ_Remarks = dt.Rows[n]["XSQ_Remarks"].ToString();
                    }
                    if (dt.Rows[n]["XSQ_CTime"] != null && dt.Rows[n]["XSQ_CTime"].ToString() != "")
                    {
                        model.XSQ_CTime = DateTime.Parse(dt.Rows[n]["XSQ_CTime"].ToString());
                    }
                    if (dt.Rows[n]["XSQ_Creator"] != null && dt.Rows[n]["XSQ_Creator"].ToString() != "")
                    {
                        model.XSQ_Creator = dt.Rows[n]["XSQ_Creator"].ToString();
                    }
                    if (dt.Rows[n]["XSQ_Mender"] != null && dt.Rows[n]["XSQ_Mender"].ToString() != "")
                    {
                        model.XSQ_Mender = dt.Rows[n]["XSQ_Mender"].ToString();
                    }
                    if (dt.Rows[n]["XSQ_MTime"] != null && dt.Rows[n]["XSQ_MTime"].ToString() != "")
                    {
                        model.XSQ_MTime = dt.Rows[n]["XSQ_MTime"].ToString();
                    }
                    if (dt.Rows[n]["XSQ_Del"] != null && dt.Rows[n]["XSQ_Del"].ToString() != "")
                    {
                        model.XSQ_Del = int.Parse(dt.Rows[n]["XSQ_Del"].ToString());
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


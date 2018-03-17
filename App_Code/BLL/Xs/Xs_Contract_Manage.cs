using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Xs_Contract_Manage
    /// </summary>
    public partial class Xs_Contract_Manage
    {
        private readonly KNet.DAL.Xs_Contract_Manage dal = new KNet.DAL.Xs_Contract_Manage();
        public Xs_Contract_Manage()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XCM_ID)
        {
            return dal.Exists(XCM_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Contract_Manage model)
        {
            dal.Add(model);

            if (model.Arr_Details != null)
            {
                for (int i = 0; i < model.Arr_Details.Count; i++)
                {
                    KNet.BLL.PB_Basic_Attachment bll_Att = new PB_Basic_Attachment();
                    KNet.Model.PB_Basic_Attachment Model_Att = (KNet.Model.PB_Basic_Attachment)model.Arr_Details[i];
                    bll_Att.Add(Model_Att);
                }
            }
            KNet.BLL.Xs_Contract_FhDetails Bll_FhDetails = new Xs_Contract_FhDetails();

            if (model.arr_FhDetails != null)
            {
                for (int i = 0; i < model.arr_FhDetails.Count; i++)
                {
                    KNet.Model.Xs_Contract_FhDetails Model_FhDetails = (KNet.Model.Xs_Contract_FhDetails)model.arr_FhDetails[i];
                    Bll_FhDetails.Add(Model_FhDetails);
                }
            }
            if (model.Arr_Details1 != null)
            {
                for (int i = 0; i < model.Arr_Details1.Count; i++)
                {
                    KNet.BLL.Xs_Contract_Manage_Details bll_Details = new Xs_Contract_Manage_Details();
                    KNet.Model.Xs_Contract_Manage_Details Model_Details = (KNet.Model.Xs_Contract_Manage_Details)model.Arr_Details1[i];
                    bll_Details.Add(Model_Details);
                }
            }
            
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Contract_Manage model)
        {

            KNet.BLL.PB_Basic_Attachment bll_Att = new PB_Basic_Attachment();
            KNet.BLL.Xs_Contract_Manage_Details bll_Details = new Xs_Contract_Manage_Details();
            bll_Att.DeleteByFID(model.XCM_ID);
            if (model.Arr_Details != null)
            {
                for (int i = 0; i < model.Arr_Details.Count; i++)
                {
                    KNet.Model.PB_Basic_Attachment Model_Att = (KNet.Model.PB_Basic_Attachment)model.Arr_Details[i];
                    bll_Att.Add(Model_Att);
                }
            }
            bll_Details.DeleteByFID(model.XCM_Code);
            if (model.Arr_Details1 != null)
            {
                for (int i = 0; i < model.Arr_Details1.Count; i++)
                {
                    KNet.Model.Xs_Contract_Manage_Details Model_Details = (KNet.Model.Xs_Contract_Manage_Details)model.Arr_Details1[i];
                    bll_Details.Add(Model_Details);
                }
            }
            KNet.BLL.Xs_Contract_FhDetails Bll_FhDetails = new Xs_Contract_FhDetails();

            Bll_FhDetails.DeleteByFID(model.XCM_ID);
            if (model.arr_FhDetails != null)
            {
                for (int i = 0; i < model.arr_FhDetails.Count; i++)
                {
                    KNet.Model.Xs_Contract_FhDetails Model_FhDetails = (KNet.Model.Xs_Contract_FhDetails)model.arr_FhDetails[i];
                    Bll_FhDetails.Add(Model_FhDetails);
                }
            }
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string XCM_ID)
        {

            return dal.Delete(XCM_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string XCM_IDlist)
        {
            return dal.DeleteList(XCM_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Xs_Contract_Manage GetModel(string XCM_ID)
        {

            return dal.GetModel(XCM_ID);
        }
        public string GetMaxOrder()
        {
            string s_Code = "100001";
            DataSet Dts_Table = dal.GetList(" 1=1  Order by XCM_OrderNo desc");
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                s_Code = Convert.ToString(int.Parse(Dts_Table.Tables[0].Rows[0]["XCM_OrderNo"].ToString()) + 1);
            }
            return s_Code;
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
        public List<KNet.Model.Xs_Contract_Manage> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Xs_Contract_Manage> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Xs_Contract_Manage> modelList = new List<KNet.Model.Xs_Contract_Manage>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Xs_Contract_Manage model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Xs_Contract_Manage();
                    if (dt.Rows[n]["XCM_ID"] != null && dt.Rows[n]["XCM_ID"].ToString() != "")
                    {
                        model.XCM_ID = dt.Rows[n]["XCM_ID"].ToString();
                    }
                    if (dt.Rows[n]["XCM_Code"] != null && dt.Rows[n]["XCM_Code"].ToString() != "")
                    {
                        model.XCM_Code = dt.Rows[n]["XCM_Code"].ToString();
                    }
                    if (dt.Rows[n]["XCM_Type"] != null && dt.Rows[n]["XCM_Type"].ToString() != "")
                    {
                        model.XCM_Type = dt.Rows[n]["XCM_Type"].ToString();
                    }
                    if (dt.Rows[n]["XCM_CustomerValue"] != null && dt.Rows[n]["XCM_CustomerValue"].ToString() != "")
                    {
                        model.XCM_CustomerValue = dt.Rows[n]["XCM_CustomerValue"].ToString();
                    }
                    if (dt.Rows[n]["XCM_STime"] != null && dt.Rows[n]["XCM_STime"].ToString() != "")
                    {
                        model.XCM_STime = DateTime.Parse(dt.Rows[n]["XCM_STime"].ToString());
                    }
                    if (dt.Rows[n]["XCM_Flow"] != null && dt.Rows[n]["XCM_Flow"].ToString() != "")
                    {
                        model.XCM_Flow = dt.Rows[n]["XCM_Flow"].ToString();
                    }
                    if (dt.Rows[n]["XCM_Remarks"] != null && dt.Rows[n]["XCM_Remarks"].ToString() != "")
                    {
                        model.XCM_Remarks = dt.Rows[n]["XCM_Remarks"].ToString();
                    }
                    if (dt.Rows[n]["XCM_Del"] != null && dt.Rows[n]["XCM_Del"].ToString() != "")
                    {
                        model.XCM_Del = int.Parse(dt.Rows[n]["XCM_Del"].ToString());
                    }
                    if (dt.Rows[n]["XCM_Creator"] != null && dt.Rows[n]["XCM_Creator"].ToString() != "")
                    {
                        model.XCM_Creator = dt.Rows[n]["XCM_Creator"].ToString();
                    }
                    if (dt.Rows[n]["XCM_CTime"] != null && dt.Rows[n]["XCM_CTime"].ToString() != "")
                    {
                        model.XCM_CTime = DateTime.Parse(dt.Rows[n]["XCM_CTime"].ToString());
                    }
                    if (dt.Rows[n]["XCM_Mender"] != null && dt.Rows[n]["XCM_Mender"].ToString() != "")
                    {
                        model.XCM_Mender = dt.Rows[n]["XCM_Mender"].ToString();
                    }
                    if (dt.Rows[n]["XCM_MTime"] != null && dt.Rows[n]["XCM_MTime"].ToString() != "")
                    {
                        model.XCM_MTime = DateTime.Parse(dt.Rows[n]["XCM_MTime"].ToString());
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


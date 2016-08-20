using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Cw_Accounting_Init
    /// </summary>
    public partial class Cw_Accounting_Init
    {
        private readonly KNet.DAL.Cw_Accounting_Init dal = new KNet.DAL.Cw_Accounting_Init();
        public Cw_Accounting_Init()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CAI_ID)
        {
            return dal.Exists(CAI_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cw_Accounting_Init model)
        {
            dal.Add(model);
            KNet.BLL.Cw_Accounting_Init_Details Bll_Details = new Cw_Accounting_Init_Details();
            if (model.Arr_Details.Count > 0)
            {
                for(int i=0;i<model.Arr_Details.Count;i++)
                {
                    KNet.Model.Cw_Accounting_Init_Details Model_Details = (KNet.Model.Cw_Accounting_Init_Details)model.Arr_Details[i];
                    Bll_Details.Add(Model_Details);
                }
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cw_Accounting_Init model)
        {
            KNet.BLL.Cw_Accounting_Init_Details Bll_Details = new Cw_Accounting_Init_Details();
            Bll_Details.DeleteByFID(model.CAI_ID);
            if (model.Arr_Details.Count > 0)
            {
                for (int i = 0; i < model.Arr_Details.Count; i++)
                {
                    KNet.Model.Cw_Accounting_Init_Details Model_Details = (KNet.Model.Cw_Accounting_Init_Details)model.Arr_Details[i];
                    Bll_Details.Add(Model_Details);  
                }
            }
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string CAI_ID)
        {

            return dal.Delete(CAI_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string CAI_IDlist)
        {
            return dal.DeleteList(CAI_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Cw_Accounting_Init GetModel(string CAI_ID)
        {

            return dal.GetModel(CAI_ID);
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
        public List<KNet.Model.Cw_Accounting_Init> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Cw_Accounting_Init> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Cw_Accounting_Init> modelList = new List<KNet.Model.Cw_Accounting_Init>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Cw_Accounting_Init model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Cw_Accounting_Init();
                    if (dt.Rows[n]["CAI_ID"] != null && dt.Rows[n]["CAI_ID"].ToString() != "")
                    {
                        model.CAI_ID = dt.Rows[n]["CAI_ID"].ToString();
                    }
                    if (dt.Rows[n]["CAI_Code"] != null && dt.Rows[n]["CAI_Code"].ToString() != "")
                    {
                        model.CAI_Code = dt.Rows[n]["CAI_Code"].ToString();
                    }
                    if (dt.Rows[n]["CAI_Title"] != null && dt.Rows[n]["CAI_Title"].ToString() != "")
                    {
                        model.CAI_Title = dt.Rows[n]["CAI_Title"].ToString();
                    }
                    if (dt.Rows[n]["CAI_STime"] != null && dt.Rows[n]["CAI_STime"].ToString() != "")
                    {
                        model.CAI_STime = DateTime.Parse(dt.Rows[n]["CAI_STime"].ToString());
                    }
                    if (dt.Rows[n]["CAI_DutyPerson"] != null && dt.Rows[n]["CAI_DutyPerson"].ToString() != "")
                    {
                        model.CAI_DutyPerson = dt.Rows[n]["CAI_DutyPerson"].ToString();
                    }
                    if (dt.Rows[n]["CAI_CustomerValue"] != null && dt.Rows[n]["CAI_CustomerValue"].ToString() != "")
                    {
                        model.CAI_CustomerValue = dt.Rows[n]["CAI_CustomerValue"].ToString();
                    }
                    if (dt.Rows[n]["CAI_SuppNo"] != null && dt.Rows[n]["CAI_SuppNo"].ToString() != "")
                    {
                        model.CAI_SuppNo = dt.Rows[n]["CAI_SuppNo"].ToString();
                    }
                    if (dt.Rows[n]["CAI_Type"] != null && dt.Rows[n]["CAI_Type"].ToString() != "")
                    {
                        model.CAI_Type = int.Parse(dt.Rows[n]["CAI_Type"].ToString());
                    }
                    if (dt.Rows[n]["CAI_InitMoney"] != null && dt.Rows[n]["CAI_InitMoney"].ToString() != "")
                    {
                        model.CAI_InitMoney = decimal.Parse(dt.Rows[n]["CAI_InitMoney"].ToString());
                    }
                    if (dt.Rows[n]["CAI_Details"] != null && dt.Rows[n]["CAI_Details"].ToString() != "")
                    {
                        model.CAI_Details = dt.Rows[n]["CAI_Details"].ToString();
                    }
                    if (dt.Rows[n]["CAI_Del"] != null && dt.Rows[n]["CAI_Del"].ToString() != "")
                    {
                        model.CAI_Del = int.Parse(dt.Rows[n]["CAI_Del"].ToString());
                    }
                    if (dt.Rows[n]["CAI_Creator"] != null && dt.Rows[n]["CAI_Creator"].ToString() != "")
                    {
                        model.CAI_Creator = dt.Rows[n]["CAI_Creator"].ToString();
                    }
                    if (dt.Rows[n]["CAI_CTime"] != null && dt.Rows[n]["CAI_CTime"].ToString() != "")
                    {
                        model.CAI_CTime = DateTime.Parse(dt.Rows[n]["CAI_CTime"].ToString());
                    }
                    if (dt.Rows[n]["CAI_Mender"] != null && dt.Rows[n]["CAI_Mender"].ToString() != "")
                    {
                        model.CAI_Mender = dt.Rows[n]["CAI_Mender"].ToString();
                    }
                    if (dt.Rows[n]["CAI_MTime"] != null && dt.Rows[n]["CAI_MTime"].ToString() != "")
                    {
                        model.CAI_MTime = DateTime.Parse(dt.Rows[n]["CAI_MTime"].ToString());
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


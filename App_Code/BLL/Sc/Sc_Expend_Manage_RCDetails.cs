using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Sc_Expend_Manage_RCDetails
    /// </summary>
    public partial class Sc_Expend_Manage_RCDetails
    {
        private readonly KNet.DAL.Sc_Expend_Manage_RCDetails dal = new KNet.DAL.Sc_Expend_Manage_RCDetails();
        public Sc_Expend_Manage_RCDetails()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SER_ID)
        {
            return dal.Exists(SER_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Sc_Expend_Manage_RCDetails model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Sc_Expend_Manage_RCDetails model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string SER_ID)
        {

            return dal.Delete(SER_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SER_IDlist)
        {
            return dal.DeleteList(SER_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Sc_Expend_Manage_RCDetails GetModel(string SER_ID)
        {

            return dal.GetModel(SER_ID);
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
        public List<KNet.Model.Sc_Expend_Manage_RCDetails> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Sc_Expend_Manage_RCDetails> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Sc_Expend_Manage_RCDetails> modelList = new List<KNet.Model.Sc_Expend_Manage_RCDetails>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Sc_Expend_Manage_RCDetails model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Sc_Expend_Manage_RCDetails();
                    if (dt.Rows[n]["SER_ID"] != null && dt.Rows[n]["SER_ID"].ToString() != "")
                    {
                        model.SER_ID = dt.Rows[n]["SER_ID"].ToString();
                    }
                    if (dt.Rows[n]["SER_SEMID"] != null && dt.Rows[n]["SER_SEMID"].ToString() != "")
                    {
                        model.SER_SEMID = dt.Rows[n]["SER_SEMID"].ToString();
                    }
                    if (dt.Rows[n]["SER_OrderDetailID"] != null && dt.Rows[n]["SER_OrderDetailID"].ToString() != "")
                    {
                        model.SER_OrderDetailID = dt.Rows[n]["SER_OrderDetailID"].ToString();
                    }
                    if (dt.Rows[n]["SER_ProductsBarCode"] != null && dt.Rows[n]["SER_ProductsBarCode"].ToString() != "")
                    {
                        model.SER_ProductsBarCode = dt.Rows[n]["SER_ProductsBarCode"].ToString();
                    }
                    if (dt.Rows[n]["SER_ScNumber"] != null && dt.Rows[n]["SER_ScNumber"].ToString() != "")
                    {
                        model.SER_ScNumber = int.Parse(dt.Rows[n]["SER_ScNumber"].ToString());
                    }
                    if (dt.Rows[n]["SER_ScPrice"] != null && dt.Rows[n]["SER_ScPrice"].ToString() != "")
                    {
                        model.SER_ScPrice = decimal.Parse(dt.Rows[n]["SER_ScPrice"].ToString());
                    }
                    if (dt.Rows[n]["SER_ScMoney"] != null && dt.Rows[n]["SER_ScMoney"].ToString() != "")
                    {
                        model.SER_ScMoney = decimal.Parse(dt.Rows[n]["SER_ScMoney"].ToString());
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


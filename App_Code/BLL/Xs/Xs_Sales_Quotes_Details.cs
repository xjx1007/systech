using System;
using System.Data;
using System.Collections.Generic;
using KNet.Common;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Xs_Sales_Quotes_Details
    /// </summary>
    public partial class Xs_Sales_Quotes_Details
    {
        private readonly KNet.DAL.Xs_Sales_Quotes_Details dal = new KNet.DAL.Xs_Sales_Quotes_Details();
        public Xs_Sales_Quotes_Details()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SQD_ID)
        {
            return dal.Exists(SQD_ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Sales_Quotes_Details model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Sales_Quotes_Details model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string SQD_FID)
        {

            return dal.Delete(SQD_FID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SQD_IDlist)
        {
            return dal.DeleteList(SQD_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Xs_Sales_Quotes_Details GetModel(string SQD_ID)
        {

            return dal.GetModel(SQD_ID);
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
        public List<KNet.Model.Xs_Sales_Quotes_Details> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Xs_Sales_Quotes_Details> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Xs_Sales_Quotes_Details> modelList = new List<KNet.Model.Xs_Sales_Quotes_Details>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Xs_Sales_Quotes_Details model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Xs_Sales_Quotes_Details();
                    if (dt.Rows[n]["SQD_ID"] != null && dt.Rows[n]["SQD_ID"].ToString() != "")
                    {
                        model.SQD_ID = dt.Rows[n]["SQD_ID"].ToString();
                    }
                    if (dt.Rows[n]["SQD_FID"] != null && dt.Rows[n]["SQD_FID"].ToString() != "")
                    {
                        model.SQD_FID = dt.Rows[n]["SQD_FID"].ToString();
                    }
                    if (dt.Rows[n]["SQD_ProductsBarCode"] != null && dt.Rows[n]["SQD_ProductsBarCode"].ToString() != "")
                    {
                        model.SQD_ProductsBarCode = dt.Rows[n]["SQD_ProductsBarCode"].ToString();
                    }
                    if (dt.Rows[n]["SQD_Number"] != null && dt.Rows[n]["SQD_Number"].ToString() != "")
                    {
                        model.SQD_Number = decimal.Parse(dt.Rows[n]["SQD_Number"].ToString());
                    }
                    if (dt.Rows[n]["SQD_Price"] != null && dt.Rows[n]["SQD_Price"].ToString() != "")
                    {
                        model.SQD_Price = decimal.Parse(dt.Rows[n]["SQD_Price"].ToString());
                    }
                    if (dt.Rows[n]["SQD_Money"] != null && dt.Rows[n]["SQD_Money"].ToString() != "")
                    {
                        model.SQD_Money = decimal.Parse(dt.Rows[n]["SQD_Money"].ToString());
                    }
                    if (dt.Rows[n]["SQD_Percent"] != null && dt.Rows[n]["SQD_Percent"].ToString() != "")
                    {
                        model.SQD_Percent = decimal.Parse(dt.Rows[n]["SQD_Percent"].ToString());
                    }
                    if (dt.Rows[n]["SQD_PercentedMoney"] != null && dt.Rows[n]["SQD_PercentedMoney"].ToString() != "")
                    {
                        model.SQD_PercentedMoney = decimal.Parse(dt.Rows[n]["SQD_PercentedMoney"].ToString());
                    }
                    if (dt.Rows[n]["SQD_Remarks"] != null && dt.Rows[n]["SQD_Remarks"].ToString() != "")
                    {
                        model.SQD_Remarks = dt.Rows[n]["SQD_Remarks"].ToString();
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


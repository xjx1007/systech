using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Cw_Account_Bill_Details
    /// </summary>
    public partial class Cw_Account_Bill_Details
    {
        private readonly KNet.DAL.Cw_Account_Bill_Details dal = new KNet.DAL.Cw_Account_Bill_Details();
        public Cw_Account_Bill_Details()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CAD_ID)
        {
            return dal.Exists(CAD_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cw_Account_Bill_Details model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cw_Account_Bill_Details model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string CAD_ID)
        {

            return dal.Delete(CAD_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByCAAID(string CAD_CAAID)
        {

            return dal.DeleteByCAAID(CAD_CAAID);
        }
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string CAD_IDlist)
        {
            return dal.DeleteList(CAD_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Cw_Account_Bill_Details GetModel(string CAD_ID)
        {

            return dal.GetModel(CAD_ID);
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
        public List<KNet.Model.Cw_Account_Bill_Details> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Cw_Account_Bill_Details> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Cw_Account_Bill_Details> modelList = new List<KNet.Model.Cw_Account_Bill_Details>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Cw_Account_Bill_Details model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Cw_Account_Bill_Details();
                    if (dt.Rows[n]["CAD_ID"] != null && dt.Rows[n]["CAD_ID"].ToString() != "")
                    {
                        model.CAD_ID = dt.Rows[n]["CAD_ID"].ToString();
                    }
                    if (dt.Rows[n]["CAD_CAAID"] != null && dt.Rows[n]["CAD_CAAID"].ToString() != "")
                    {
                        model.CAD_CAAID = dt.Rows[n]["CAD_CAAID"].ToString();
                    }
                    if (dt.Rows[n]["CAD_ProductsBarCode"] != null && dt.Rows[n]["CAD_ProductsBarCode"].ToString() != "")
                    {
                        model.CAD_ProductsBarCode = dt.Rows[n]["CAD_ProductsBarCode"].ToString();
                    }
                    if (dt.Rows[n]["CAD_Number"] != null && dt.Rows[n]["CAD_Number"].ToString() != "")
                    {
                        model.CAD_Number = int.Parse(dt.Rows[n]["CAD_Number"].ToString());
                    }
                    if (dt.Rows[n]["CAD_Price"] != null && dt.Rows[n]["CAD_Price"].ToString() != "")
                    {
                        model.CAD_Price = decimal.Parse(dt.Rows[n]["CAD_Price"].ToString());
                    }
                    if (dt.Rows[n]["CAD_Money"] != null && dt.Rows[n]["CAD_Money"].ToString() != "")
                    {
                        model.CAD_Money = decimal.Parse(dt.Rows[n]["CAD_Money"].ToString());
                    }
                    if (dt.Rows[n]["CAD_Remarks"] != null && dt.Rows[n]["CAD_Remarks"].ToString() != "")
                    {
                        model.CAD_Remarks = dt.Rows[n]["CAD_Remarks"].ToString();
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


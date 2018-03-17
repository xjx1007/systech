using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Xs_Customer_Products
    /// </summary>
    public partial class Xs_Customer_Products
    {
        private readonly KNet.DAL.Xs_Customer_Products dal = new KNet.DAL.Xs_Customer_Products();
        public Xs_Customer_Products()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XCP_ID, string XCP_CustomerID, string XCP_ProductsID)
        {
            return dal.Exists(XCP_ID, XCP_CustomerID, XCP_ProductsID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Customer_Products model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Customer_Products model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string XCP_ProductsID)
        {

            return dal.Delete(XCP_ProductsID);
        }

        /// <summary>
        /// 删除By客户名称
        /// </summary>
        public bool DeleteByCustomer(string XCP_CustomerID)
        {

            return dal.DeleteByCustomer(XCP_CustomerID);
        }
        /// <summary>
        /// 删除By客户名称和产品
        /// </summary>
        public bool DeleteByCustomerAndProducts(string XCP_CustomerID,string s_ProductsBarCode)
        {

            return dal.DeleteByCustomerAndProducts(XCP_CustomerID, s_ProductsBarCode);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Xs_Customer_Products GetModel(string XCP_ID, string XCP_CustomerID, string XCP_ProductsID)
        {

            return dal.GetModel(XCP_ID, XCP_CustomerID, XCP_ProductsID);
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
        public List<KNet.Model.Xs_Customer_Products> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Xs_Customer_Products> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Xs_Customer_Products> modelList = new List<KNet.Model.Xs_Customer_Products>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Xs_Customer_Products model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Xs_Customer_Products();
                    if (dt.Rows[n]["XCP_ID"] != null && dt.Rows[n]["XCP_ID"].ToString() != "")
                    {
                        model.XCP_ID = dt.Rows[n]["XCP_ID"].ToString();
                    }
                    if (dt.Rows[n]["XCP_CustomerID"] != null && dt.Rows[n]["XCP_CustomerID"].ToString() != "")
                    {
                        model.XCP_CustomerID = dt.Rows[n]["XCP_CustomerID"].ToString();
                    }
                    if (dt.Rows[n]["XCP_ProductsID"] != null && dt.Rows[n]["XCP_ProductsID"].ToString() != "")
                    {
                        model.XCP_ProductsID = dt.Rows[n]["XCP_ProductsID"].ToString();
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


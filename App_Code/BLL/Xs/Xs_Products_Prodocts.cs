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
    /// Xs_Products_Prodocts
    /// </summary>
    public partial class Xs_Products_Prodocts
    {
        private readonly KNet.DAL.Xs_Products_Prodocts dal = new KNet.DAL.Xs_Products_Prodocts();
        public Xs_Products_Prodocts()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XPP_ID)
        {
            return dal.Exists(XPP_ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Products_Prodocts model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Products_Prodocts model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string XPP_FaterBarCode)
        {

            return dal.Delete(XPP_FaterBarCode);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string XPP_IDlist)
        {
            return dal.DeleteList(XPP_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Xs_Products_Prodocts GetModel(string XPP_ID)
        {

            return dal.GetModel(XPP_ID);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Xs_Products_Prodocts GetModelByProducts(string XPP_ProductsBarCode, string XPP_FaterBarCode)
        {

            return dal.GetModelByProducts(XPP_ProductsBarCode,XPP_FaterBarCode);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListWithType(string strWhere)
        {
            return dal.GetListWithType(strWhere);
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
        public List<KNet.Model.Xs_Products_Prodocts> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Xs_Products_Prodocts> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Xs_Products_Prodocts> modelList = new List<KNet.Model.Xs_Products_Prodocts>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Xs_Products_Prodocts model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Xs_Products_Prodocts();
                    if (dt.Rows[n]["XPP_ID"] != null && dt.Rows[n]["XPP_ID"].ToString() != "")
                    {
                        model.XPP_ID = dt.Rows[n]["XPP_ID"].ToString();
                    }
                    if (dt.Rows[n]["XPP_ProductsBarCode"] != null && dt.Rows[n]["XPP_ProductsBarCode"].ToString() != "")
                    {
                        model.XPP_ProductsBarCode = dt.Rows[n]["XPP_ProductsBarCode"].ToString();
                    }
                    if (dt.Rows[n]["XPP_SuppNo"] != null && dt.Rows[n]["XPP_SuppNo"].ToString() != "")
                    {
                        model.XPP_SuppNo = dt.Rows[n]["XPP_SuppNo"].ToString();
                    }
                    if (dt.Rows[n]["XPP_Price"] != null && dt.Rows[n]["XPP_Price"].ToString() != "")
                    {
                        model.XPP_Price = decimal.Parse(dt.Rows[n]["XPP_Price"].ToString());
                    }
                    if (dt.Rows[n]["XPP_Number"] != null && dt.Rows[n]["XPP_Number"].ToString() != "")
                    {
                        model.XPP_Number = decimal.Parse(dt.Rows[n]["XPP_Number"].ToString());
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



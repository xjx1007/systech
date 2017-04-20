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
    /// Xs_Products_Prodocts_Demo
    /// </summary>
    public partial class Xs_Products_Prodocts_Demo
    {
        private readonly KNet.DAL.Xs_Products_Prodocts_Demo dal = new KNet.DAL.Xs_Products_Prodocts_Demo();
        public Xs_Products_Prodocts_Demo()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XPD_ID)
        {
            return dal.Exists(XPD_ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Products_Prodocts_Demo model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Products_Prodocts_Demo model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateDel(string[] s_IDs,string s_ProductsBarCode)
        {
            return dal.UpdateDel(s_IDs, s_ProductsBarCode);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string XPD_FaterBarCode)
        {

            return dal.Delete(XPD_FaterBarCode);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByIDs(string[] s_IDs, string XPD_FaterBarCode)
        {

            return dal.DeleteByIDs(s_IDs, XPD_FaterBarCode);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string XPD_IDlist)
        {
            return dal.DeleteList(XPD_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Xs_Products_Prodocts_Demo GetModel(string XPD_ID)
        {

            return dal.GetModel(XPD_ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Xs_Products_Prodocts_Demo GetModelByProducts(string XPP_ProductsBarCode, string XPP_FaterBarCode)
        {

            return dal.GetModelByProducts(XPP_ProductsBarCode, XPP_FaterBarCode);
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetListWithType1(string strWhere)
        {
            return dal.GetListWithType1(strWhere);
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
        public List<KNet.Model.Xs_Products_Prodocts_Demo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Xs_Products_Prodocts_Demo> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Xs_Products_Prodocts_Demo> modelList = new List<KNet.Model.Xs_Products_Prodocts_Demo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Xs_Products_Prodocts_Demo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Xs_Products_Prodocts_Demo();
                    if (dt.Rows[n]["XPD_ID"] != null && dt.Rows[n]["XPD_ID"].ToString() != "")
                    {
                        model.XPD_ID = dt.Rows[n]["XPD_ID"].ToString();
                    }
                    if (dt.Rows[n]["XPD_ProductsBarCode"] != null && dt.Rows[n]["XPD_ProductsBarCode"].ToString() != "")
                    {
                        model.XPD_ProductsBarCode = dt.Rows[n]["XPD_ProductsBarCode"].ToString();
                    }
                    if (dt.Rows[n]["XPD_SuppNo"] != null && dt.Rows[n]["XPD_SuppNo"].ToString() != "")
                    {
                        model.XPD_SuppNo = dt.Rows[n]["XPD_SuppNo"].ToString();
                    }
                    if (dt.Rows[n]["XPD_Price"] != null && dt.Rows[n]["XPD_Price"].ToString() != "")
                    {
                        model.XPD_Price = decimal.Parse(dt.Rows[n]["XPD_Price"].ToString());
                    }
                    if (dt.Rows[n]["XPD_Number"] != null && dt.Rows[n]["XPD_Number"].ToString() != "")
                    {
                        model.XPD_Number = decimal.Parse(dt.Rows[n]["XPD_Number"].ToString());
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



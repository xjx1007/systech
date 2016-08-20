using System;
using System.Data;
using System.Collections.Generic;
using KNet.Common;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Xs_Products_Spce
    /// </summary>
    public partial class Xs_Products_Spce
    {
        private readonly KNet.DAL.Xs_Products_Spce dal = new KNet.DAL.Xs_Products_Spce();
        public Xs_Products_Spce()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XPS_ID)
        {
            return dal.Exists(XPS_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Products_Spce model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Products_Spce model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string XPS_ID)
        {

            return dal.Delete(XPS_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string XPS_IDlist)
        {
            return dal.DeleteList(XPS_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Xs_Products_Spce GetModel(string XPS_ID)
        {

            return dal.GetModel(XPS_ID);
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
        public List<KNet.Model.Xs_Products_Spce> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Xs_Products_Spce> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Xs_Products_Spce> modelList = new List<KNet.Model.Xs_Products_Spce>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Xs_Products_Spce model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Xs_Products_Spce();
                    if (dt.Rows[n]["XPS_ID"] != null && dt.Rows[n]["XPS_ID"].ToString() != "")
                    {
                        model.XPS_ID = dt.Rows[n]["XPS_ID"].ToString();
                    }
                    if (dt.Rows[n]["XPS_ProductsBarCode"] != null && dt.Rows[n]["XPS_ProductsBarCode"].ToString() != "")
                    {
                        model.XPS_ProductsBarCode = dt.Rows[n]["XPS_ProductsBarCode"].ToString();
                    }
                    if (dt.Rows[n]["XPS_SpceCode"] != null && dt.Rows[n]["XPS_SpceCode"].ToString() != "")
                    {
                        model.XPS_SpceCode = dt.Rows[n]["XPS_SpceCode"].ToString();
                    }
                    if (dt.Rows[n]["XPS_SpceName"] != null && dt.Rows[n]["XPS_SpceName"].ToString() != "")
                    {
                        model.XPS_SpceName = dt.Rows[n]["XPS_SpceName"].ToString();
                    }
                    if (dt.Rows[n]["XPS_Details"] != null && dt.Rows[n]["XPS_Details"].ToString() != "")
                    {
                        model.XPS_Details = dt.Rows[n]["XPS_Details"].ToString();
                    }
                    if (dt.Rows[n]["XPS_Creator"] != null && dt.Rows[n]["XPS_Creator"].ToString() != "")
                    {
                        model.XPS_Creator = dt.Rows[n]["XPS_Creator"].ToString();
                    }
                    if (dt.Rows[n]["XPS_CTime"] != null && dt.Rows[n]["XPS_CTime"].ToString() != "")
                    {
                        model.XPS_CTime = DateTime.Parse(dt.Rows[n]["XPS_CTime"].ToString());
                    }
                    if (dt.Rows[n]["XPS_Mender"] != null && dt.Rows[n]["XPS_Mender"].ToString() != "")
                    {
                        model.XPS_Mender = dt.Rows[n]["XPS_Mender"].ToString();
                    }
                    if (dt.Rows[n]["XPS_MTime"] != null && dt.Rows[n]["XPS_MTime"].ToString() != "")
                    {
                        model.XPS_MTime = DateTime.Parse(dt.Rows[n]["XPS_MTime"].ToString());
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


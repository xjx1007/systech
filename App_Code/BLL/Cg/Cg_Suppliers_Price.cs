using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Cg_Suppliers_Price
    /// </summary>
    public partial class Cg_Suppliers_Price
    {
        private readonly KNet.DAL.Cg_Suppliers_Price dal = new KNet.DAL.Cg_Suppliers_Price();
        public Cg_Suppliers_Price()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CSP_ID)
        {
            return dal.Exists(CSP_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cg_Suppliers_Price model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cg_Suppliers_Price model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string CSP_ID)
        {

            return dal.Delete(CSP_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string CSP_IDlist)
        {
            return dal.DeleteList(CSP_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Cg_Suppliers_Price GetModel(string CSP_ID)
        {

            return dal.GetModel(CSP_ID);
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
        public List<KNet.Model.Cg_Suppliers_Price> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Cg_Suppliers_Price> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Cg_Suppliers_Price> modelList = new List<KNet.Model.Cg_Suppliers_Price>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Cg_Suppliers_Price model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Cg_Suppliers_Price();
                    if (dt.Rows[n]["CSP_ID"] != null && dt.Rows[n]["CSP_ID"].ToString() != "")
                    {
                        model.CSP_ID = dt.Rows[n]["CSP_ID"].ToString();
                    }
                    if (dt.Rows[n]["CSP_ProductsBarCode"] != null && dt.Rows[n]["CSP_ProductsBarCode"].ToString() != "")
                    {
                        model.CSP_ProductsBarCode = dt.Rows[n]["CSP_ProductsBarCode"].ToString();
                    }
                    if (dt.Rows[n]["CSP_IsStop"] != null && dt.Rows[n]["CSP_IsStop"].ToString() != "")
                    {
                        model.CSP_IsStop = int.Parse(dt.Rows[n]["CSP_IsStop"].ToString());
                    }
                    if (dt.Rows[n]["CSP_ProductsMainType"] != null && dt.Rows[n]["CSP_ProductsMainType"].ToString() != "")
                    {
                        model.CSP_ProductsMainType = dt.Rows[n]["CSP_ProductsMainType"].ToString();
                    }
                    if (dt.Rows[n]["CSP_SerchKey"] != null && dt.Rows[n]["CSP_SerchKey"].ToString() != "")
                    {
                        model.CSP_SerchKey = dt.Rows[n]["CSP_SerchKey"].ToString();
                    }
                    if (dt.Rows[n]["CSP_State"] != null && dt.Rows[n]["CSP_State"].ToString() != "")
                    {
                        model.CSP_State = int.Parse(dt.Rows[n]["CSP_State"].ToString());
                    }
                    if (dt.Rows[n]["CSP_ShPerson"] != null && dt.Rows[n]["CSP_ShPerson"].ToString() != "")
                    {
                        model.CSP_ShPerson = dt.Rows[n]["CSP_ShPerson"].ToString();
                    }
                    if (dt.Rows[n]["CSP_Del"] != null && dt.Rows[n]["CSP_Del"].ToString() != "")
                    {
                        model.CSP_Del = int.Parse(dt.Rows[n]["CSP_Del"].ToString());
                    }
                    if (dt.Rows[n]["CSP_Creator"] != null && dt.Rows[n]["CSP_Creator"].ToString() != "")
                    {
                        model.CSP_Creator = dt.Rows[n]["CSP_Creator"].ToString();
                    }
                    if (dt.Rows[n]["CSP_CTime"] != null && dt.Rows[n]["CSP_CTime"].ToString() != "")
                    {
                        model.CSP_CTime = DateTime.Parse(dt.Rows[n]["CSP_CTime"].ToString());
                    }
                    if (dt.Rows[n]["CSP_Mender"] != null && dt.Rows[n]["CSP_Mender"].ToString() != "")
                    {
                        model.CSP_Mender = dt.Rows[n]["CSP_Mender"].ToString();
                    }
                    if (dt.Rows[n]["CSP_MTime"] != null && dt.Rows[n]["CSP_MTime"].ToString() != "")
                    {
                        model.CSP_MTime = DateTime.Parse(dt.Rows[n]["CSP_MTime"].ToString());
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


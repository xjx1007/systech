using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Xs_Customer_FhInfo
    /// </summary>
    public partial class Xs_Customer_FhInfo
    {
        private readonly KNet.DAL.Xs_Customer_FhInfo dal = new KNet.DAL.Xs_Customer_FhInfo();
        public Xs_Customer_FhInfo()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XCF_ID)
        {
            return dal.Exists(XCF_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Customer_FhInfo model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Customer_FhInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string XCF_ID)
        {

            return dal.Delete(XCF_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByCustomerValue(string XCF_CustomerValue)
        {

            return dal.DeleteByCustomerValue(XCF_CustomerValue);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string XCF_IDlist)
        {
            return dal.DeleteList(XCF_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Xs_Customer_FhInfo GetModel(string XCF_ID)
        {

            return dal.GetModel(XCF_ID);
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
        public List<KNet.Model.Xs_Customer_FhInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Xs_Customer_FhInfo> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Xs_Customer_FhInfo> modelList = new List<KNet.Model.Xs_Customer_FhInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Xs_Customer_FhInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Xs_Customer_FhInfo();
                    if (dt.Rows[n]["XCF_ID"] != null && dt.Rows[n]["XCF_ID"].ToString() != "")
                    {
                        model.XCF_ID = dt.Rows[n]["XCF_ID"].ToString();
                    }
                    if (dt.Rows[n]["XCF_CustomerValue"] != null && dt.Rows[n]["XCF_CustomerValue"].ToString() != "")
                    {
                        model.XCF_CustomerValue = dt.Rows[n]["XCF_CustomerValue"].ToString();
                    }
                    if (dt.Rows[n]["XCF_Name"] != null && dt.Rows[n]["XCF_Name"].ToString() != "")
                    {
                        model.XCF_Name = dt.Rows[n]["XCF_Name"].ToString();
                    }
                    if (dt.Rows[n]["XCF_Details"] != null && dt.Rows[n]["XCF_Details"].ToString() != "")
                    {
                        model.XCF_Details = dt.Rows[n]["XCF_Details"].ToString();
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


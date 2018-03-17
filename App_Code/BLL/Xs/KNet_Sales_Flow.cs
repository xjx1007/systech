using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections.Generic;
using KNet.Common;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// KNet_Sales_Flow
    /// </summary>
    public partial class KNet_Sales_Flow
    {
        private readonly KNet.DAL.KNet_Sales_Flow dal = new KNet.DAL.KNet_Sales_Flow();
        public KNet_Sales_Flow()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(KNet.Model.KNet_Sales_Flow model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sales_Flow model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.KNet_Sales_Flow model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string KSF_ID)
        {

            return dal.Delete(KSF_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string KSF_IDlist)
        {
            return dal.DeleteList(KSF_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sales_Flow GetModel(string KSF_ID)
        {

            return dal.GetModel(KSF_ID);
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
        public List<KNet.Model.KNet_Sales_Flow> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.KNet_Sales_Flow> DataTableToList(DataTable dt)
        {
            List<KNet.Model.KNet_Sales_Flow> modelList = new List<KNet.Model.KNet_Sales_Flow>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.KNet_Sales_Flow model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.KNet_Sales_Flow();
                    if (dt.Rows[n]["KSF_ID"] != null && dt.Rows[n]["KSF_ID"].ToString() != "")
                    {
                        model.KSF_ID = dt.Rows[n]["KSF_ID"].ToString();
                    }
                    if (dt.Rows[n]["KSF_Detail"] != null && dt.Rows[n]["KSF_Detail"].ToString() != "")
                    {
                        model.KSF_Detail = dt.Rows[n]["KSF_Detail"].ToString();
                    }
                    if (dt.Rows[n]["KSF_Date"] != null && dt.Rows[n]["KSF_Date"].ToString() != "")
                    {
                        model.KSF_Date = DateTime.Parse(dt.Rows[n]["KSF_Date"].ToString());
                    }
                    if (dt.Rows[n]["KSF_ShPerson"] != null && dt.Rows[n]["KSF_ShPerson"].ToString() != "")
                    {
                        model.KSF_ShPerson = dt.Rows[n]["KSF_ShPerson"].ToString();
                    }
                    if (dt.Rows[n]["KSF_State"] != null && dt.Rows[n]["KSF_State"].ToString() != "")
                    {
                        model.KSF_State = int.Parse(dt.Rows[n]["KSF_State"].ToString());
                    }
                    if (dt.Rows[n]["KSF_ContractNo"] != null && dt.Rows[n]["KSF_ContractNo"].ToString() != "")
                    {
                        model.KSF_ContractNo = dt.Rows[n]["KSF_ContractNo"].ToString();
                    }
                    if (dt.Rows[n]["KFS_Type"] != null && dt.Rows[n]["KFS_Type"].ToString() != "")
                    {
                        model.KFS_Type = int.Parse(dt.Rows[n]["KFS_Type"].ToString());
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


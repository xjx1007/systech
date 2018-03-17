using System;
using System.Data;
using System.Collections.Generic;
using KNet.Common;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Xs_Sales_Task
    /// </summary>
    public partial class Xs_Sales_Task
    {
        private readonly KNet.DAL.Xs_Sales_Task dal = new KNet.DAL.Xs_Sales_Task();
        public Xs_Sales_Task()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XST_ID)
        {
            return dal.Exists(XST_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Sales_Task model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Sales_Task model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string XST_ID)
        {

            return dal.Delete(XST_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string XST_IDlist)
        {
            return dal.DeleteList(XST_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Xs_Sales_Task GetModel(string XST_ID)
        {

            return dal.GetModel(XST_ID);
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
        public List<KNet.Model.Xs_Sales_Task> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Xs_Sales_Task> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Xs_Sales_Task> modelList = new List<KNet.Model.Xs_Sales_Task>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Xs_Sales_Task model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Xs_Sales_Task();
                    if (dt.Rows[n]["XST_ID"] != null && dt.Rows[n]["XST_ID"].ToString() != "")
                    {
                        model.XST_ID = dt.Rows[n]["XST_ID"].ToString();
                    }
                    if (dt.Rows[n]["XST_Topic"] != null && dt.Rows[n]["XST_Topic"].ToString() != "")
                    {
                        model.XST_Topic = dt.Rows[n]["XST_Topic"].ToString();
                    }
                    if (dt.Rows[n]["XST_State"] != null && dt.Rows[n]["XST_State"].ToString() != "")
                    {
                        model.XST_State = dt.Rows[n]["XST_State"].ToString();
                    }
                    if (dt.Rows[n]["XST_Claim"] != null && dt.Rows[n]["XST_Claim"].ToString() != "")
                    {
                        model.XST_Claim = dt.Rows[n]["XST_Claim"].ToString();
                    }
                    if (dt.Rows[n]["XST_ISModiy"] != null && dt.Rows[n]["XST_ISModiy"].ToString() != "")
                    {
                        model.XST_ISModiy = int.Parse(dt.Rows[n]["XST_ISModiy"].ToString());
                    }
                    if (dt.Rows[n]["XST_BeginTime"] != null && dt.Rows[n]["XST_BeginTime"].ToString() != "")
                    {
                        model.XST_BeginTime = DateTime.Parse(dt.Rows[n]["XST_BeginTime"].ToString());
                    }
                    if (dt.Rows[n]["XST_EndTime"] != null && dt.Rows[n]["XST_EndTime"].ToString() != "")
                    {
                        model.XST_EndTime = DateTime.Parse(dt.Rows[n]["XST_EndTime"].ToString());
                    }
                    if (dt.Rows[n]["XST_DutyPerson"] != null && dt.Rows[n]["XST_DutyPerson"].ToString() != "")
                    {
                        model.XST_DutyPerson = dt.Rows[n]["XST_DutyPerson"].ToString();
                    }
                    if (dt.Rows[n]["XST_Executor"] != null && dt.Rows[n]["XST_Executor"].ToString() != "")
                    {
                        model.XST_Executor = dt.Rows[n]["XST_Executor"].ToString();
                    }
                    if (dt.Rows[n]["XST_Remarks"] != null && dt.Rows[n]["XST_Remarks"].ToString() != "")
                    {
                        model.XST_Remarks = dt.Rows[n]["XST_Remarks"].ToString();
                    }
                    if (dt.Rows[n]["XST_Creator"] != null && dt.Rows[n]["XST_Creator"].ToString() != "")
                    {
                        model.XST_Creator = dt.Rows[n]["XST_Creator"].ToString();
                    }
                    if (dt.Rows[n]["XST_CTime"] != null && dt.Rows[n]["XST_CTime"].ToString() != "")
                    {
                        model.XST_CTime = DateTime.Parse(dt.Rows[n]["XST_CTime"].ToString());
                    }
                    if (dt.Rows[n]["XST_Mender"] != null && dt.Rows[n]["XST_Mender"].ToString() != "")
                    {
                        model.XST_Mender = dt.Rows[n]["XST_Mender"].ToString();
                    }
                    if (dt.Rows[n]["XST_MTime"] != null && dt.Rows[n]["XST_MTime"].ToString() != "")
                    {
                        model.XST_MTime = DateTime.Parse(dt.Rows[n]["XST_MTime"].ToString());
                    }
                    if (dt.Rows[n]["XST_Del"] != null && dt.Rows[n]["XST_Del"].ToString() != "")
                    {
                        model.XST_Del = int.Parse(dt.Rows[n]["XST_Del"].ToString());
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


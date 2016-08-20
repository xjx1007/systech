﻿using System;
using System.Data;
using System.Collections.Generic;
using KNet.Common;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// KNet_Reports_Submit_Details
    /// </summary>
    public partial class KNet_Reports_Submit_Details
    {
        private readonly KNet.DAL.KNet_Reports_Submit_Details dal = new KNet.DAL.KNet_Reports_Submit_Details();
        public KNet_Reports_Submit_Details()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KRD_ID)
        {
            return dal.Exists(KRD_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.KNet_Reports_Submit_Details model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.KNet_Reports_Submit_Details model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string KRD_ID)
        {

            return dal.Delete(KRD_ID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteBySubmitID(string KRD_SubmitID)
        {

            return dal.DeleteBySubmitID(KRD_SubmitID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string KRD_IDlist)
        {
            return dal.DeleteList(KRD_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Reports_Submit_Details GetModel(string KRD_ID)
        {
            return dal.GetModel(KRD_ID);
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
        public List<KNet.Model.KNet_Reports_Submit_Details> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.KNet_Reports_Submit_Details> DataTableToList(DataTable dt)
        {
            List<KNet.Model.KNet_Reports_Submit_Details> modelList = new List<KNet.Model.KNet_Reports_Submit_Details>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.KNet_Reports_Submit_Details model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.KNet_Reports_Submit_Details();
                    if (dt.Rows[n]["KRD_ID"] != null && dt.Rows[n]["KRD_ID"].ToString() != "")
                    {
                        model.KRD_ID = dt.Rows[n]["KRD_ID"].ToString();
                    }
                    if (dt.Rows[n]["KRD_SubmitID"] != null && dt.Rows[n]["KRD_SubmitID"].ToString() != "")
                    {
                        model.KRD_SubmitID = dt.Rows[n]["KRD_SubmitID"].ToString();
                    }
                    if (dt.Rows[n]["KPD_Type"] != null && dt.Rows[n]["KPD_Type"].ToString() != "")
                    {
                        model.KPD_Type = dt.Rows[n]["KPD_Type"].ToString();
                    }
                    if (dt.Rows[n]["KRD_URL"] != null && dt.Rows[n]["KRD_URL"].ToString() != "")
                    {
                        model.KRD_URL = dt.Rows[n]["KRD_URL"].ToString();
                    }
                    if (dt.Rows[n]["KRD_Name"] != null && dt.Rows[n]["KRD_Name"].ToString() != "")
                    {
                        model.KRD_Name = dt.Rows[n]["KRD_Name"].ToString();
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
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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


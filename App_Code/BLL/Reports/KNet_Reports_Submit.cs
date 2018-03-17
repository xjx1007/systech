using System;
using System.Data;
using System.Collections.Generic;
using KNet.Common;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// KNet_Reports_Submit
    /// </summary>
    public partial class KNet_Reports_Submit
    {
        private readonly KNet.DAL.KNet_Reports_Submit dal = new KNet.DAL.KNet_Reports_Submit();
        public KNet_Reports_Submit()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KRS_ID)
        {
            return dal.Exists(KRS_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.KNet_Reports_Submit model)
        {
            if (model.arr_details != null)
            {
                KNet.BLL.KNet_Reports_Submit_Details bll_Details = new KNet.BLL.KNet_Reports_Submit_Details();
                for(int i=0;i<model.arr_details.Count;i++)
                {
                    KNet.Model.KNet_Reports_Submit_Details model_Details = (KNet.Model.KNet_Reports_Submit_Details)model.arr_details[i];
                    model_Details.KRD_SubmitID=model.KRS_ID;
                    bll_Details.Add(model_Details);
                }
            }
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.KNet_Reports_Submit model)
        {

            KNet.BLL.KNet_Reports_Submit_Details bll_Details = new KNet.BLL.KNet_Reports_Submit_Details();
            bll_Details.DeleteBySubmitID(model.KRS_ID);
            if (model.arr_details != null)
            {
                for (int i = 0; i < model.arr_details.Count; i++)
                {
                    KNet.Model.KNet_Reports_Submit_Details model_Details = (KNet.Model.KNet_Reports_Submit_Details)model.arr_details[i];
                    model_Details.KRD_SubmitID = model.KRS_ID;
                    bll_Details.Add(model_Details);
                }
            }
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateState(KNet.Model.KNet_Reports_Submit model)
        {
            return dal.UpdateState(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string KRS_ID)
        {

            return dal.Delete(KRS_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string KRS_IDlist)
        {
            return dal.DeleteList(KRS_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Reports_Submit GetModel(string KRS_ID)
        {

            return dal.GetModel(KRS_ID);
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
        public List<KNet.Model.KNet_Reports_Submit> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.KNet_Reports_Submit> DataTableToList(DataTable dt)
        {
            List<KNet.Model.KNet_Reports_Submit> modelList = new List<KNet.Model.KNet_Reports_Submit>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.KNet_Reports_Submit model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.KNet_Reports_Submit();
                    if (dt.Rows[n]["KRS_ID"] != null && dt.Rows[n]["KRS_ID"].ToString() != "")
                    {
                        model.KRS_ID = dt.Rows[n]["KRS_ID"].ToString();
                    }
                    if (dt.Rows[n]["KRS_Code"] != null && dt.Rows[n]["KRS_Code"].ToString() != "")
                    {
                        model.KRS_Code = dt.Rows[n]["KRS_Code"].ToString();
                    }
                    if (dt.Rows[n]["KRS_DutyPerson"] != null && dt.Rows[n]["KRS_DutyPerson"].ToString() != "")
                    {
                        model.KRS_DutyPerson = dt.Rows[n]["KRS_DutyPerson"].ToString();
                    }
                    if (dt.Rows[n]["KRS_Type"] != null && dt.Rows[n]["KRS_Type"].ToString() != "")
                    {
                        model.KRS_Type = dt.Rows[n]["KRS_Type"].ToString();
                    }
                    if (dt.Rows[n]["KRS_Remarks"] != null && dt.Rows[n]["KRS_Remarks"].ToString() != "")
                    {
                        model.KRS_Remarks = dt.Rows[n]["KRS_Remarks"].ToString();
                    }
                    if (dt.Rows[n]["KRS_CTime"] != null && dt.Rows[n]["KRS_CTime"].ToString() != "")
                    {
                        model.KRS_CTime = DateTime.Parse(dt.Rows[n]["KRS_CTime"].ToString());
                    }
                    if (dt.Rows[n]["KRS_Creator"] != null && dt.Rows[n]["KRS_Creator"].ToString() != "")
                    {
                        model.KRS_Creator = dt.Rows[n]["KRS_Creator"].ToString();
                    }
                    if (dt.Rows[n]["KRS_MTime"] != null && dt.Rows[n]["KRS_MTime"].ToString() != "")
                    {
                        model.KRS_MTime = DateTime.Parse(dt.Rows[n]["KRS_MTime"].ToString());
                    }
                    if (dt.Rows[n]["KRS_Mender"] != null && dt.Rows[n]["KRS_Mender"].ToString() != "")
                    {
                        model.KRS_Mender = dt.Rows[n]["KRS_Mender"].ToString();
                    }
                    if (dt.Rows[n]["KRS_Del"] != null && dt.Rows[n]["KRS_Del"].ToString() != "")
                    {
                        model.KRS_Del = int.Parse(dt.Rows[n]["KRS_Del"].ToString());
                    }
                    if (dt.Rows[n]["KRS_Stime"] != null && dt.Rows[n]["KRS_Stime"].ToString() != "")
                    {
                        model.KRS_Stime = DateTime.Parse(dt.Rows[n]["KRS_Stime"].ToString());
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


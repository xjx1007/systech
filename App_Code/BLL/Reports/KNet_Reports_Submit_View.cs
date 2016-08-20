using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// KNet_Reports_Submit_View
    /// </summary>
    public partial class KNet_Reports_Submit_View
    {
        private readonly KNet.DAL.KNet_Reports_Submit_View dal = new KNet.DAL.KNet_Reports_Submit_View();
        public KNet_Reports_Submit_View()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string KRV_ID)
        {
            return dal.Exists(KRV_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.KNet_Reports_Submit_View model)
        {
            KNet.BLL.KNet_Reports_Submit Bll_Main = new KNet.BLL.KNet_Reports_Submit();
            KNet.Model.KNet_Reports_Submit Model_Main = new KNet.Model.KNet_Reports_Submit();
            Model_Main.KRS_State=3;
            Model_Main.KRS_ID=model.KRV_SubmitID;
            Bll_Main.UpdateState(Model_Main);
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.KNet_Reports_Submit_View model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string KRV_ID)
        {

            return dal.Delete(KRV_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string KRV_IDlist)
        {
            return dal.DeleteList(KRV_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Reports_Submit_View GetModel(string KRV_ID)
        {

            return dal.GetModel(KRV_ID);
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
        public List<KNet.Model.KNet_Reports_Submit_View> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.KNet_Reports_Submit_View> DataTableToList(DataTable dt)
        {
            List<KNet.Model.KNet_Reports_Submit_View> modelList = new List<KNet.Model.KNet_Reports_Submit_View>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.KNet_Reports_Submit_View model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.KNet_Reports_Submit_View();
                    if (dt.Rows[n]["KRV_ID"] != null && dt.Rows[n]["KRV_ID"].ToString() != "")
                    {
                        model.KRV_ID = dt.Rows[n]["KRV_ID"].ToString();
                    }
                    if (dt.Rows[n]["KRV_SubmitID"] != null && dt.Rows[n]["KRV_SubmitID"].ToString() != "")
                    {
                        model.KRV_SubmitID = dt.Rows[n]["KRV_SubmitID"].ToString();
                    }
                    if (dt.Rows[n]["KRV_FatherID"] != null && dt.Rows[n]["KRV_FatherID"].ToString() != "")
                    {
                        model.KRV_FatherID = dt.Rows[n]["KRV_FatherID"].ToString();
                    }
                    if (dt.Rows[n]["KRV_Remarks"] != null && dt.Rows[n]["KRV_Remarks"].ToString() != "")
                    {
                        model.KRV_Remarks = dt.Rows[n]["KRV_Remarks"].ToString();
                    }
                    if (dt.Rows[n]["KRV_Person"] != null && dt.Rows[n]["KRV_Person"].ToString() != "")
                    {
                        model.KRV_Person = dt.Rows[n]["KRV_Person"].ToString();
                    }
                    if (dt.Rows[n]["KRV_CTime"] != null && dt.Rows[n]["KRV_CTime"].ToString() != "")
                    {
                        model.KRV_CTime = DateTime.Parse(dt.Rows[n]["KRV_CTime"].ToString());
                    }
                    if (dt.Rows[n]["KRV_Creator"] != null && dt.Rows[n]["KRV_Creator"].ToString() != "")
                    {
                        model.KRV_Creator = dt.Rows[n]["KRV_Creator"].ToString();
                    }
                    if (dt.Rows[n]["KRV_Del"] != null && dt.Rows[n]["KRV_Del"].ToString() != "")
                    {
                        model.KRV_Del = int.Parse(dt.Rows[n]["KRV_Del"].ToString());
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


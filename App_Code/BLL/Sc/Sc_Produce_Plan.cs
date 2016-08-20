using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Sc_Produce_Plan
    /// </summary>
    public partial class Sc_Produce_Plan
    {
        private readonly KNet.DAL.Sc_Produce_Plan dal = new KNet.DAL.Sc_Produce_Plan();
        public Sc_Produce_Plan()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SPP_ID)
        {
            return dal.Exists(SPP_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Sc_Produce_Plan model)
        {
            dal.Add(model);
            if (model.arr_Details != null)
            {
                for (int i = 0; i < model.arr_Details.Count; i++)
                {
                    KNet.BLL.Sc_Produce_Plan_Details Bll_Details = new KNet.BLL.Sc_Produce_Plan_Details();
                    KNet.Model.Sc_Produce_Plan_Details Model_Details = (KNet.Model.Sc_Produce_Plan_Details)model.arr_Details[i];
                    Bll_Details.Add(Model_Details);
                }
 
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Sc_Produce_Plan model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string SPP_ID)
        {

            return dal.Delete(SPP_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SPP_IDlist)
        {
            return dal.DeleteList(SPP_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Sc_Produce_Plan GetModel(string SPP_ID)
        {

            return dal.GetModel(SPP_ID);
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
        public List<KNet.Model.Sc_Produce_Plan> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Sc_Produce_Plan> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Sc_Produce_Plan> modelList = new List<KNet.Model.Sc_Produce_Plan>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Sc_Produce_Plan model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Sc_Produce_Plan();
                    if (dt.Rows[n]["SPP_ID"] != null && dt.Rows[n]["SPP_ID"].ToString() != "")
                    {
                        model.SPP_ID = dt.Rows[n]["SPP_ID"].ToString();
                    }
                    if (dt.Rows[n]["SPP_STime"] != null && dt.Rows[n]["SPP_STime"].ToString() != "")
                    {
                        model.SPP_STime = DateTime.Parse(dt.Rows[n]["SPP_STime"].ToString());
                    }
                    if (dt.Rows[n]["SPP_Remarks"] != null && dt.Rows[n]["SPP_Remarks"].ToString() != "")
                    {
                        model.SPP_Remarks = dt.Rows[n]["SPP_Remarks"].ToString();
                    }
                    if (dt.Rows[n]["SPP_Creator"] != null && dt.Rows[n]["SPP_Creator"].ToString() != "")
                    {
                        model.SPP_Creator = dt.Rows[n]["SPP_Creator"].ToString();
                    }
                    if (dt.Rows[n]["SPP_Ctime"] != null && dt.Rows[n]["SPP_Ctime"].ToString() != "")
                    {
                        model.SPP_Ctime = DateTime.Parse(dt.Rows[n]["SPP_Ctime"].ToString());
                    }
                    if (dt.Rows[n]["SPP_Del"] != null && dt.Rows[n]["SPP_Del"].ToString() != "")
                    {
                        model.SPP_Del = int.Parse(dt.Rows[n]["SPP_Del"].ToString());
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


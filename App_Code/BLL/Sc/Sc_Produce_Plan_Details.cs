using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Sc_Produce_Plan_Details
    /// </summary>
    public partial class Sc_Produce_Plan_Details
    {
        private readonly KNet.DAL.Sc_Produce_Plan_Details dal = new KNet.DAL.Sc_Produce_Plan_Details();
        public Sc_Produce_Plan_Details()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SPD_ID)
        {
            return dal.Exists(SPD_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Sc_Produce_Plan_Details model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Sc_Produce_Plan_Details model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateOrder(KNet.Model.Sc_Produce_Plan_Details model)
        {
            return dal.UpdateOrder(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string SPD_ID)
        {

            return dal.Delete(SPD_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SPD_IDlist)
        {
            return dal.DeleteList(SPD_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Sc_Produce_Plan_Details GetModel(string SPD_ID)
        {

            return dal.GetModel(SPD_ID);
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
        public List<KNet.Model.Sc_Produce_Plan_Details> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Sc_Produce_Plan_Details> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Sc_Produce_Plan_Details> modelList = new List<KNet.Model.Sc_Produce_Plan_Details>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Sc_Produce_Plan_Details model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Sc_Produce_Plan_Details();
                    if (dt.Rows[n]["SPD_ID"] != null && dt.Rows[n]["SPD_ID"].ToString() != "")
                    {
                        model.SPD_ID = dt.Rows[n]["SPD_ID"].ToString();
                    }
                    if (dt.Rows[n]["SPD_BeginTime"] != null && dt.Rows[n]["SPD_BeginTime"].ToString() != "")
                    {
                        model.SPD_BeginTime = DateTime.Parse(dt.Rows[n]["SPD_BeginTime"].ToString());
                    }
                    if (dt.Rows[n]["SPD_EndTime"] != null && dt.Rows[n]["SPD_EndTime"].ToString() != "")
                    {
                        model.SPD_EndTime = DateTime.Parse(dt.Rows[n]["SPD_EndTime"].ToString());
                    }
                    if (dt.Rows[n]["SPD_OrderNo"] != null && dt.Rows[n]["SPD_OrderNo"].ToString() != "")
                    {
                        model.SPD_OrderNo = dt.Rows[n]["SPD_OrderNo"].ToString();
                    }
                    if (dt.Rows[n]["SPD_Remarks"] != null && dt.Rows[n]["SPD_Remarks"].ToString() != "")
                    {
                        model.SPD_Remarks = dt.Rows[n]["SPD_Remarks"].ToString();
                    }
                    if (dt.Rows[n]["SPD_Type"] != null && dt.Rows[n]["SPD_Type"].ToString() != "")
                    {
                        model.SPD_Type = int.Parse(dt.Rows[n]["SPD_Type"].ToString());
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


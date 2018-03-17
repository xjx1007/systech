using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Cw_Accounting_Init_Details
    /// </summary>
    public partial class Cw_Accounting_Init_Details
    {
        private readonly KNet.DAL.Cw_Accounting_Init_Details dal = new KNet.DAL.Cw_Accounting_Init_Details();
        public Cw_Accounting_Init_Details()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CAID_ID)
        {
            return dal.Exists(CAID_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cw_Accounting_Init_Details model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cw_Accounting_Init_Details model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string CAID_ID)
        {

            return dal.Delete(CAID_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByFID(string CAID_FID)
        {

            return dal.DeleteByFID(CAID_FID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string CAID_IDlist)
        {
            return dal.DeleteList(CAID_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Cw_Accounting_Init_Details GetModel(string CAID_ID)
        {

            return dal.GetModel(CAID_ID);
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
        public List<KNet.Model.Cw_Accounting_Init_Details> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Cw_Accounting_Init_Details> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Cw_Accounting_Init_Details> modelList = new List<KNet.Model.Cw_Accounting_Init_Details>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Cw_Accounting_Init_Details model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Cw_Accounting_Init_Details();
                    if (dt.Rows[n]["CAID_ID"] != null && dt.Rows[n]["CAID_ID"].ToString() != "")
                    {
                        model.CAID_ID = dt.Rows[n]["CAID_ID"].ToString();
                    }
                    if (dt.Rows[n]["CAID_FID"] != null && dt.Rows[n]["CAID_FID"].ToString() != "")
                    {
                        model.CAID_FID = dt.Rows[n]["CAID_FID"].ToString();
                    }
                    if (dt.Rows[n]["CAID_OutTime"] != null && dt.Rows[n]["CAID_OutTime"].ToString() != "")
                    {
                        model.CAID_OutTime = DateTime.Parse(dt.Rows[n]["CAID_OutTime"].ToString());
                    }
                    if (dt.Rows[n]["CAID_Number"] != null && dt.Rows[n]["CAID_Number"].ToString() != "")
                    {
                        model.CAID_Number = decimal.Parse(dt.Rows[n]["CAID_Number"].ToString());
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


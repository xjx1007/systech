using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Cw_Account_Bill_Outimes
    /// </summary>
    public partial class Cw_Account_Bill_Outimes
    {
        private readonly KNet.DAL.Cw_Account_Bill_Outimes dal = new KNet.DAL.Cw_Account_Bill_Outimes();
        public Cw_Account_Bill_Outimes()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CAO_ID)
        {
            return dal.Exists(CAO_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cw_Account_Bill_Outimes model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cw_Account_Bill_Outimes model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string CAO_ID)
        {

            return dal.Delete(CAO_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByFID(string CAO_CADID)
        {

            return dal.DeleteByFID(CAO_CADID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string CAO_IDlist)
        {
            return dal.DeleteList(CAO_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Cw_Account_Bill_Outimes GetModel(string CAO_ID)
        {

            return dal.GetModel(CAO_ID);
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
        public List<KNet.Model.Cw_Account_Bill_Outimes> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Cw_Account_Bill_Outimes> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Cw_Account_Bill_Outimes> modelList = new List<KNet.Model.Cw_Account_Bill_Outimes>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Cw_Account_Bill_Outimes model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Cw_Account_Bill_Outimes();
                    if (dt.Rows[n]["CAO_ID"] != null && dt.Rows[n]["CAO_ID"].ToString() != "")
                    {
                        model.CAO_ID = dt.Rows[n]["CAO_ID"].ToString();
                    }
                    if (dt.Rows[n]["CAO_CADID"] != null && dt.Rows[n]["CAO_CADID"].ToString() != "")
                    {
                        model.CAO_CADID = dt.Rows[n]["CAO_CADID"].ToString();
                    }
                    if (dt.Rows[n]["CAO_Money"] != null && dt.Rows[n]["CAO_Money"].ToString() != "")
                    {
                        model.CAO_Money = decimal.Parse(dt.Rows[n]["CAO_Money"].ToString());
                    }
                    if (dt.Rows[n]["CAO_OutDays"] != null && dt.Rows[n]["CAO_OutDays"].ToString() != "")
                    {
                        model.CAO_OutDays = int.Parse(dt.Rows[n]["CAO_OutDays"].ToString());
                    }
                    if (dt.Rows[n]["CAO_OutTime"] != null && dt.Rows[n]["CAO_OutTime"].ToString() != "")
                    {
                        model.CAO_OutTime = DateTime.Parse(dt.Rows[n]["CAO_OutTime"].ToString());
                    }
                    if (dt.Rows[n]["CAO_Remarks"] != null && dt.Rows[n]["CAO_Remarks"].ToString() != "")
                    {
                        model.CAO_Remarks = dt.Rows[n]["CAO_Remarks"].ToString();
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


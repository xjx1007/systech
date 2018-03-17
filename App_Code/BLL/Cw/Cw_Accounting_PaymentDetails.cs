using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Cw_Accounting_PaymentDetails
    /// </summary>
    public partial class Cw_Accounting_PaymentDetails
    {
        private readonly KNet.DAL.Cw_Accounting_PaymentDetails dal = new KNet.DAL.Cw_Accounting_PaymentDetails();
        public Cw_Accounting_PaymentDetails()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CAPD_ID)
        {
            return dal.Exists(CAPD_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cw_Accounting_PaymentDetails model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cw_Accounting_PaymentDetails model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string CAPD_ID)
        {

            return dal.Delete(CAPD_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByCARID(string CAPD_CARID)
        {

            return dal.DeleteyCARID(CAPD_CARID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string CAPD_IDlist)
        {
            return dal.DeleteList(CAPD_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Cw_Accounting_PaymentDetails GetModel(string CAPD_ID)
        {

            return dal.GetModel(CAPD_ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByLeft(string strWhere)
        {
            return dal.GetListByLeft(strWhere);
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
        public List<KNet.Model.Cw_Accounting_PaymentDetails> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Cw_Accounting_PaymentDetails> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Cw_Accounting_PaymentDetails> modelList = new List<KNet.Model.Cw_Accounting_PaymentDetails>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Cw_Accounting_PaymentDetails model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Cw_Accounting_PaymentDetails();
                    if (dt.Rows[n]["CAPD_ID"] != null && dt.Rows[n]["CAPD_ID"].ToString() != "")
                    {
                        model.CAPD_ID = dt.Rows[n]["CAPD_ID"].ToString();
                    }
                    if (dt.Rows[n]["CAPD_CARID"] != null && dt.Rows[n]["CAPD_CARID"].ToString() != "")
                    {
                        model.CAPD_CARID = dt.Rows[n]["CAPD_CARID"].ToString();
                    }
                    if (dt.Rows[n]["CAPD_yTime"] != null && dt.Rows[n]["CAPD_yTime"].ToString() != "")
                    {
                        model.CAPD_yTime = DateTime.Parse(dt.Rows[n]["CAPD_yTime"].ToString());
                    }
                    if (dt.Rows[n]["CAPD_Order"] != null && dt.Rows[n]["CAPD_Order"].ToString() != "")
                    {
                        model.CAPD_Order = int.Parse(dt.Rows[n]["CAPD_Order"].ToString());
                    }
                    if (dt.Rows[n]["CAPD_State"] != null && dt.Rows[n]["CAPD_State"].ToString() != "")
                    {
                        model.CAPD_State = int.Parse(dt.Rows[n]["CAPD_State"].ToString());
                    }
                    if (dt.Rows[n]["CAPD_Money"] != null && dt.Rows[n]["CAPD_Money"].ToString() != "")
                    {
                        model.CAPD_Money = decimal.Parse(dt.Rows[n]["CAPD_Money"].ToString());
                    }
                    if (dt.Rows[n]["CAPD_Details"] != null && dt.Rows[n]["CAPD_Details"].ToString() != "")
                    {
                        model.CAPD_Details = dt.Rows[n]["CAPD_Details"].ToString();
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


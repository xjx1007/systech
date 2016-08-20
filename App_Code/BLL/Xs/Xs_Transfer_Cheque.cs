using System;
using System.Data;
using System.Collections.Generic;
using KNet.Common;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Xs_Transfer_Cheque
    /// </summary>
    public partial class Xs_Transfer_Cheque
    {
        private readonly KNet.DAL.Xs_Transfer_Cheque dal = new KNet.DAL.Xs_Transfer_Cheque();
        public Xs_Transfer_Cheque()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XTC_ID)
        {
            return dal.Exists(XTC_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Xs_Transfer_Cheque model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Xs_Transfer_Cheque model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string XTC_ID)
        {

            return dal.Delete(XTC_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string XTC_IDlist)
        {
            return dal.DeleteList(XTC_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Xs_Transfer_Cheque GetModel(string XTC_ID)
        {

            return dal.GetModel(XTC_ID);
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
        public List<KNet.Model.Xs_Transfer_Cheque> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Xs_Transfer_Cheque> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Xs_Transfer_Cheque> modelList = new List<KNet.Model.Xs_Transfer_Cheque>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Xs_Transfer_Cheque model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Xs_Transfer_Cheque();
                    if (dt.Rows[n]["XTC_ID"] != null && dt.Rows[n]["XTC_ID"].ToString() != "")
                    {
                        model.XTC_ID = dt.Rows[n]["XTC_ID"].ToString();
                    }
                    if (dt.Rows[n]["XTC_Stime"] != null && dt.Rows[n]["XTC_Stime"].ToString() != "")
                    {
                        model.XTC_Stime = DateTime.Parse(dt.Rows[n]["XTC_Stime"].ToString());
                    }
                    if (dt.Rows[n]["XTC_Type"] != null && dt.Rows[n]["XTC_Type"].ToString() != "")
                    {
                        model.XTC_Type = dt.Rows[n]["XTC_Type"].ToString();
                    }
                    if (dt.Rows[n]["XTC_PayeeValue"] != null && dt.Rows[n]["XTC_PayeeValue"].ToString() != "")
                    {
                        model.XTC_PayeeValue = dt.Rows[n]["XTC_PayeeValue"].ToString();
                    }
                    if (dt.Rows[n]["XTC_PayeeName"] != null && dt.Rows[n]["XTC_PayeeName"].ToString() != "")
                    {
                        model.XTC_PayeeName = dt.Rows[n]["XTC_PayeeName"].ToString();
                    }
                    if (dt.Rows[n]["XTC_UseName"] != null && dt.Rows[n]["XTC_UseName"].ToString() != "")
                    {
                        model.XTC_UseName = dt.Rows[n]["XTC_UseName"].ToString();
                    }
                    if (dt.Rows[n]["XTC_Money"] != null && dt.Rows[n]["XTC_Money"].ToString() != "")
                    {
                        model.XTC_Money = int.Parse(dt.Rows[n]["XTC_Money"].ToString());
                    }
                    if (dt.Rows[n]["XTC_Account"] != null && dt.Rows[n]["XTC_Account"].ToString() != "")
                    {
                        model.XTC_Account = dt.Rows[n]["XTC_Account"].ToString();
                    }
                    if (dt.Rows[n]["XTC_Remarks"] != null && dt.Rows[n]["XTC_Remarks"].ToString() != "")
                    {
                        model.XTC_Remarks = dt.Rows[n]["XTC_Remarks"].ToString();
                    }
                    if (dt.Rows[n]["XTC_DutyPerson"] != null && dt.Rows[n]["XTC_DutyPerson"].ToString() != "")
                    {
                        model.XTC_DutyPerson = dt.Rows[n]["XTC_DutyPerson"].ToString();
                    }
                    if (dt.Rows[n]["XTC_ShPerson"] != null && dt.Rows[n]["XTC_ShPerson"].ToString() != "")
                    {
                        model.XTC_ShPerson = dt.Rows[n]["XTC_ShPerson"].ToString();
                    }
                    if (dt.Rows[n]["XTC_Del"] != null && dt.Rows[n]["XTC_Del"].ToString() != "")
                    {
                        model.XTC_Del = int.Parse(dt.Rows[n]["XTC_Del"].ToString());
                    }
                    if (dt.Rows[n]["XTC_CTime"] != null && dt.Rows[n]["XTC_CTime"].ToString() != "")
                    {
                        model.XTC_CTime = DateTime.Parse(dt.Rows[n]["XTC_CTime"].ToString());
                    }
                    if (dt.Rows[n]["XTC_Creator"] != null && dt.Rows[n]["XTC_Creator"].ToString() != "")
                    {
                        model.XTC_Creator = dt.Rows[n]["XTC_Creator"].ToString();
                    }
                    if (dt.Rows[n]["XTC_MTime"] != null && dt.Rows[n]["XTC_MTime"].ToString() != "")
                    {
                        model.XTC_MTime = DateTime.Parse(dt.Rows[n]["XTC_MTime"].ToString());
                    }
                    if (dt.Rows[n]["XTC_Mender"] != null && dt.Rows[n]["XTC_Mender"].ToString() != "")
                    {
                        model.XTC_Mender = dt.Rows[n]["XTC_Mender"].ToString();
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


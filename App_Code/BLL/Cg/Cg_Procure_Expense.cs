using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Cg_Procure_Expense
    /// </summary>
    public partial class Cg_Procure_Expense
    {
        private readonly KNet.DAL.Cg_Procure_Expense dal = new KNet.DAL.Cg_Procure_Expense();
        public Cg_Procure_Expense()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CPE_ID)
        {
            return dal.Exists(CPE_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cg_Procure_Expense model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cg_Procure_Expense model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string CPE_ID)
        {

            return dal.Delete(CPE_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string CPE_IDlist)
        {
            return dal.DeleteList(CPE_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Cg_Procure_Expense GetModel(string CPE_ID)
        {

            return dal.GetModel(CPE_ID);
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
        public List<KNet.Model.Cg_Procure_Expense> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Cg_Procure_Expense> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Cg_Procure_Expense> modelList = new List<KNet.Model.Cg_Procure_Expense>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Cg_Procure_Expense model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Cg_Procure_Expense();
                    if (dt.Rows[n]["CPE_ID"] != null && dt.Rows[n]["CPE_ID"].ToString() != "")
                    {
                        model.CPE_ID = dt.Rows[n]["CPE_ID"].ToString();
                    }
                    if (dt.Rows[n]["CPE_Code"] != null && dt.Rows[n]["CPE_Code"].ToString() != "")
                    {
                        model.CPE_Code = dt.Rows[n]["CPE_Code"].ToString();
                    }
                    if (dt.Rows[n]["CPE_DirectOutNo"] != null && dt.Rows[n]["CPE_DirectOutNo"].ToString() != "")
                    {
                        model.CPE_DirectOutNo = dt.Rows[n]["CPE_DirectOutNo"].ToString();
                    }
                    if (dt.Rows[n]["CPE_Stime"] != null && dt.Rows[n]["CPE_Stime"].ToString() != "")
                    {
                        model.CPE_Stime = DateTime.Parse(dt.Rows[n]["CPE_Stime"].ToString());
                    }
                    if (dt.Rows[n]["CPE_Cuse"] != null && dt.Rows[n]["CPE_Cuse"].ToString() != "")
                    {
                        model.CPE_Cuse = dt.Rows[n]["CPE_Cuse"].ToString();
                    }
                    if (dt.Rows[n]["CPE_Number"] != null && dt.Rows[n]["CPE_Number"].ToString() != "")
                    {
                        model.CPE_Number = int.Parse(dt.Rows[n]["CPE_Number"].ToString());
                    }
                    if (dt.Rows[n]["CPE_Price"] != null && dt.Rows[n]["CPE_Price"].ToString() != "")
                    {
                        model.CPE_Price = decimal.Parse(dt.Rows[n]["CPE_Price"].ToString());
                    }
                    if (dt.Rows[n]["CPE_Money"] != null && dt.Rows[n]["CPE_Money"].ToString() != "")
                    {
                        model.CPE_Money = decimal.Parse(dt.Rows[n]["CPE_Money"].ToString());
                    }
                    if (dt.Rows[n]["CPE_Percent"] != null && dt.Rows[n]["CPE_Percent"].ToString() != "")
                    {
                        model.CPE_Percent = decimal.Parse(dt.Rows[n]["CPE_Percent"].ToString());
                    }
                    if (dt.Rows[n]["CPE_SuppMoney"] != null && dt.Rows[n]["CPE_SuppMoney"].ToString() != "")
                    {
                        model.CPE_SuppMoney = decimal.Parse(dt.Rows[n]["CPE_SuppMoney"].ToString());
                    }
                    if (dt.Rows[n]["CPE_PayMoney"] != null && dt.Rows[n]["CPE_PayMoney"].ToString() != "")
                    {
                        model.CPE_PayMoney = decimal.Parse(dt.Rows[n]["CPE_PayMoney"].ToString());
                    }
                    if (dt.Rows[n]["CPE_Details"] != null && dt.Rows[n]["CPE_Details"].ToString() != "")
                    {
                        model.CPE_Details = dt.Rows[n]["CPE_Details"].ToString();
                    }
                    if (dt.Rows[n]["CPE_Del"] != null && dt.Rows[n]["CPE_Del"].ToString() != "")
                    {
                        model.CPE_Del = int.Parse(dt.Rows[n]["CPE_Del"].ToString());
                    }
                    if (dt.Rows[n]["CPE_CTime"] != null && dt.Rows[n]["CPE_CTime"].ToString() != "")
                    {
                        model.CPE_CTime = DateTime.Parse(dt.Rows[n]["CPE_CTime"].ToString());
                    }
                    if (dt.Rows[n]["CPE_Creator"] != null && dt.Rows[n]["CPE_Creator"].ToString() != "")
                    {
                        model.CPE_Creator = dt.Rows[n]["CPE_Creator"].ToString();
                    }
                    if (dt.Rows[n]["CPE_MTime"] != null && dt.Rows[n]["CPE_MTime"].ToString() != "")
                    {
                        model.CPE_MTime = DateTime.Parse(dt.Rows[n]["CPE_MTime"].ToString());
                    }
                    if (dt.Rows[n]["CPE_Mender"] != null && dt.Rows[n]["CPE_Mender"].ToString() != "")
                    {
                        model.CPE_Mender = dt.Rows[n]["CPE_Mender"].ToString();
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


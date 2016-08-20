using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// PB_Knowledge_Manage
    /// </summary>
    public partial class PB_Knowledge_Manage
    {
        private readonly KNet.DAL.PB_Knowledge_Manage dal = new KNet.DAL.PB_Knowledge_Manage();
        public PB_Knowledge_Manage()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PKM_ID)
        {
            return dal.Exists(PKM_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Knowledge_Manage model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Knowledge_Manage model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PKM_ID)
        {

            return dal.Delete(PKM_ID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PKM_IDlist)
        {
            return dal.DeleteList(PKM_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.PB_Knowledge_Manage GetModel(string PKM_ID)
        {

            return dal.GetModel(PKM_ID);
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
        public List<KNet.Model.PB_Knowledge_Manage> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.PB_Knowledge_Manage> DataTableToList(DataTable dt)
        {
            List<KNet.Model.PB_Knowledge_Manage> modelList = new List<KNet.Model.PB_Knowledge_Manage>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.PB_Knowledge_Manage model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.PB_Knowledge_Manage();
                    if (dt.Rows[n]["PKM_ID"] != null && dt.Rows[n]["PKM_ID"].ToString() != "")
                    {
                        model.PKM_ID = dt.Rows[n]["PKM_ID"].ToString();
                    }
                    if (dt.Rows[n]["PKM_Code"] != null && dt.Rows[n]["PKM_Code"].ToString() != "")
                    {
                        model.PKM_Code = dt.Rows[n]["PKM_Code"].ToString();
                    }
                    if (dt.Rows[n]["PKM_Title"] != null && dt.Rows[n]["PKM_Title"].ToString() != "")
                    {
                        model.PKM_Title = dt.Rows[n]["PKM_Title"].ToString();
                    }
                    if (dt.Rows[n]["PKM_ProductsBarCode"] != null && dt.Rows[n]["PKM_ProductsBarCode"].ToString() != "")
                    {
                        model.PKM_ProductsBarCode = dt.Rows[n]["PKM_ProductsBarCode"].ToString();
                    }
                    if (dt.Rows[n]["PKM_CustomerValue"] != null && dt.Rows[n]["PKM_CustomerValue"].ToString() != "")
                    {
                        model.PKM_CustomerValue = dt.Rows[n]["PKM_CustomerValue"].ToString();
                    }
                    if (dt.Rows[n]["PKM_Type"] != null && dt.Rows[n]["PKM_Type"].ToString() != "")
                    {
                        model.PKM_Type = dt.Rows[n]["PKM_Type"].ToString();
                    }
                    if (dt.Rows[n]["PKM_State"] != null && dt.Rows[n]["PKM_State"].ToString() != "")
                    {
                        model.PKM_State = dt.Rows[n]["PKM_State"].ToString();
                    }
                    if (dt.Rows[n]["PKM_Problem"] != null && dt.Rows[n]["PKM_Problem"].ToString() != "")
                    {
                        model.PKM_Problem = dt.Rows[n]["PKM_Problem"].ToString();
                    }
                    if (dt.Rows[n]["PKM_Solution"] != null && dt.Rows[n]["PKM_Solution"].ToString() != "")
                    {
                        model.PKM_Solution = dt.Rows[n]["PKM_Solution"].ToString();
                    }
                    if (dt.Rows[n]["PKM_Del"] != null && dt.Rows[n]["PKM_Del"].ToString() != "")
                    {
                        model.PKM_Del = int.Parse(dt.Rows[n]["PKM_Del"].ToString());
                    }
                    if (dt.Rows[n]["PKM_Creator"] != null && dt.Rows[n]["PKM_Creator"].ToString() != "")
                    {
                        model.PKM_Creator = dt.Rows[n]["PKM_Creator"].ToString();
                    }
                    if (dt.Rows[n]["PKM_CTime"] != null && dt.Rows[n]["PKM_CTime"].ToString() != "")
                    {
                        model.PKM_CTime = DateTime.Parse(dt.Rows[n]["PKM_CTime"].ToString());
                    }
                    if (dt.Rows[n]["PKM_Mender"] != null && dt.Rows[n]["PKM_Mender"].ToString() != "")
                    {
                        model.PKM_Mender = dt.Rows[n]["PKM_Mender"].ToString();
                    }
                    if (dt.Rows[n]["PKM_MTime"] != null && dt.Rows[n]["PKM_MTime"].ToString() != "")
                    {
                        model.PKM_MTime = DateTime.Parse(dt.Rows[n]["PKM_MTime"].ToString());
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


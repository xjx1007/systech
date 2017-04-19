using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Sc_Expend_Manage
    /// </summary>
    public partial class Sc_Expend_Manage:BasePage
    {
        private readonly KNet.DAL.Sc_Expend_Manage dal = new KNet.DAL.Sc_Expend_Manage();
        public Sc_Expend_Manage()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SEM_ID)
        {
            return dal.Exists(SEM_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Sc_Expend_Manage model)
        {
            dal.Add(model);
            //成品生产
            if (model.arr_Details != null)
            {
                KNet.BLL.Sc_Expend_Manage_RCDetails Bll_RC = new Sc_Expend_Manage_RCDetails();
                for (int i = 0; i < model.arr_Details.Count; i++)
                {
                    KNet.Model.Sc_Expend_Manage_RCDetails Model_Rc = (KNet.Model.Sc_Expend_Manage_RCDetails)model.arr_Details[i];
                    Bll_RC.Add(Model_Rc);
                }
            }
            //配件入库，委外，消耗
            if (model.arr_MaterDetails != null)
            {
                KNet.BLL.Sc_Expend_Manage_MaterDetails Bll_Mater = new Sc_Expend_Manage_MaterDetails();
                for (int i = 0; i < model.arr_MaterDetails.Count; i++)
                {
                    KNet.Model.Sc_Expend_Manage_MaterDetails Model_Mater= (KNet.Model.Sc_Expend_Manage_MaterDetails)model.arr_MaterDetails[i];

                    Model_Mater.SED_ID = base.GetNewID("Sc_Expend_Manage_MaterDetails", 1);
                    Bll_Mater.Add(Model_Mater);
                }
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Sc_Expend_Manage model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string SEM_ID)
        {

            return dal.Delete(SEM_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SEM_IDlist)
        {
            return dal.DeleteList(SEM_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Sc_Expend_Manage GetModel(string SEM_ID)
        {

            return dal.GetModel(SEM_ID);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateRCPrintState(KNet.Model.Sc_Expend_Manage model)
        {
            dal.UpdateRCPrintState(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateMaterPrintState(KNet.Model.Sc_Expend_Manage model)
        {
            dal.UpdateMaterPrintState(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateMaterPrintState1(KNet.Model.Sc_Expend_Manage model)
        {
            dal.UpdateMaterPrintState1(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateMaterPrintState2(KNet.Model.Sc_Expend_Manage model)
        {
            dal.UpdateMaterPrintState2(model);
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
        public List<KNet.Model.Sc_Expend_Manage> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Sc_Expend_Manage> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Sc_Expend_Manage> modelList = new List<KNet.Model.Sc_Expend_Manage>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Sc_Expend_Manage model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Sc_Expend_Manage();
                    if (dt.Rows[n]["SEM_ID"] != null && dt.Rows[n]["SEM_ID"].ToString() != "")
                    {
                        model.SEM_ID = dt.Rows[n]["SEM_ID"].ToString();
                    }
                    if (dt.Rows[n]["SEM_Stime"] != null && dt.Rows[n]["SEM_Stime"].ToString() != "")
                    {
                        model.SEM_Stime = DateTime.Parse(dt.Rows[n]["SEM_Stime"].ToString());
                    }
                    if (dt.Rows[n]["SEM_SuppNo"] != null && dt.Rows[n]["SEM_SuppNo"].ToString() != "")
                    {
                        model.SEM_SuppNo = dt.Rows[n]["SEM_SuppNo"].ToString();
                    }
                    if (dt.Rows[n]["SEM_CustomerName"] != null && dt.Rows[n]["SEM_CustomerName"].ToString() != "")
                    {
                        model.SEM_CustomerName = dt.Rows[n]["SEM_CustomerName"].ToString();
                    }
                    if (dt.Rows[n]["SEM_DutyPerson"] != null && dt.Rows[n]["SEM_DutyPerson"].ToString() != "")
                    {
                        model.SEM_DutyPerson = dt.Rows[n]["SEM_DutyPerson"].ToString();
                    }
                    if (dt.Rows[n]["SEM_ProductsEdition"] != null && dt.Rows[n]["SEM_ProductsEdition"].ToString() != "")
                    {
                        model.SEM_ProductsEdition = dt.Rows[n]["SEM_ProductsEdition"].ToString();
                    }
                    if (dt.Rows[n]["SEM_RkTime"] != null && dt.Rows[n]["SEM_RkTime"].ToString() != "")
                    {
                        model.SEM_RkTime = DateTime.Parse(dt.Rows[n]["SEM_RkTime"].ToString());
                    }
                    if (dt.Rows[n]["SEM_WwTime"] != null && dt.Rows[n]["SEM_WwTime"].ToString() != "")
                    {
                        model.SEM_WwTime = DateTime.Parse(dt.Rows[n]["SEM_WwTime"].ToString());
                    }
                    if (dt.Rows[n]["SEM_RkPerson"] != null && dt.Rows[n]["SEM_RkPerson"].ToString() != "")
                    {
                        model.SEM_RkPerson = dt.Rows[n]["SEM_RkPerson"].ToString();
                    }
                    if (dt.Rows[n]["SEM_WwPerson"] != null && dt.Rows[n]["SEM_WwPerson"].ToString() != "")
                    {
                        model.SEM_WwPerson = dt.Rows[n]["SEM_WwPerson"].ToString();
                    }
                    if (dt.Rows[n]["SEM_Remarks"] != null && dt.Rows[n]["SEM_Remarks"].ToString() != "")
                    {
                        model.SEM_Remarks = dt.Rows[n]["SEM_Remarks"].ToString();
                    }
                    if (dt.Rows[n]["SEM_Del"] != null && dt.Rows[n]["SEM_Del"].ToString() != "")
                    {
                        model.SEM_Del = int.Parse(dt.Rows[n]["SEM_Del"].ToString());
                    }
                    if (dt.Rows[n]["SEM_Creator"] != null && dt.Rows[n]["SEM_Creator"].ToString() != "")
                    {
                        model.SEM_Creator = dt.Rows[n]["SEM_Creator"].ToString();
                    }
                    if (dt.Rows[n]["SEM_CTime"] != null && dt.Rows[n]["SEM_CTime"].ToString() != "")
                    {
                        model.SEM_CTime = DateTime.Parse(dt.Rows[n]["SEM_CTime"].ToString());
                    }
                    if (dt.Rows[n]["SEM_Mendor"] != null && dt.Rows[n]["SEM_Mendor"].ToString() != "")
                    {
                        model.SEM_Mendor = dt.Rows[n]["SEM_Mendor"].ToString();
                    }
                    if (dt.Rows[n]["SEM_MTime"] != null && dt.Rows[n]["SEM_MTime"].ToString() != "")
                    {
                        model.SEM_MTime = DateTime.Parse(dt.Rows[n]["SEM_MTime"].ToString());
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


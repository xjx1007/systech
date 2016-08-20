using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Sc_Expend_Manage_MaterDetails
    /// </summary>
    public partial class Sc_Expend_Manage_MaterDetails
    {
        private readonly KNet.DAL.Sc_Expend_Manage_MaterDetails dal = new KNet.DAL.Sc_Expend_Manage_MaterDetails();
        public Sc_Expend_Manage_MaterDetails()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SED_ID)
        {
            return dal.Exists(SED_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Sc_Expend_Manage_MaterDetails model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Sc_Expend_Manage_MaterDetails model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateWwPrice(KNet.Model.Sc_Expend_Manage_MaterDetails model)
        {
            return dal.UpdateWwPrice(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string SED_ID)
        {

            return dal.Delete(SED_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SED_IDlist)
        {
            return dal.DeleteList(SED_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Sc_Expend_Manage_MaterDetails GetModel(string SED_ID)
        {

            return dal.GetModel(SED_ID);
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
        public List<KNet.Model.Sc_Expend_Manage_MaterDetails> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Sc_Expend_Manage_MaterDetails> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Sc_Expend_Manage_MaterDetails> modelList = new List<KNet.Model.Sc_Expend_Manage_MaterDetails>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Sc_Expend_Manage_MaterDetails model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Sc_Expend_Manage_MaterDetails();
                    if (dt.Rows[n]["SED_ID"] != null && dt.Rows[n]["SED_ID"].ToString() != "")
                    {
                        model.SED_ID = dt.Rows[n]["SED_ID"].ToString();
                    }
                    if (dt.Rows[n]["SED_SEMID"] != null && dt.Rows[n]["SED_SEMID"].ToString() != "")
                    {
                        model.SED_SEMID = dt.Rows[n]["SED_SEMID"].ToString();
                    }
                    if (dt.Rows[n]["SED_ProductsBarCode"] != null && dt.Rows[n]["SED_ProductsBarCode"].ToString() != "")
                    {
                        model.SED_ProductsBarCode = dt.Rows[n]["SED_ProductsBarCode"].ToString();
                    }
                    if (dt.Rows[n]["SED_HouseNo"] != null && dt.Rows[n]["SED_HouseNo"].ToString() != "")
                    {
                        model.SED_HouseNo = dt.Rows[n]["SED_HouseNo"].ToString();
                    }
                    if (dt.Rows[n]["SED_RkNumber"] != null && dt.Rows[n]["SED_RkNumber"].ToString() != "")
                    {
                        model.SED_RkNumber = int.Parse(dt.Rows[n]["SED_RkNumber"].ToString());
                    }
                    if (dt.Rows[n]["SED_RkPrice"] != null && dt.Rows[n]["SED_RkPrice"].ToString() != "")
                    {
                        model.SED_RkPrice = decimal.Parse(dt.Rows[n]["SED_RkPrice"].ToString());
                    }
                    if (dt.Rows[n]["SED_RkMoney"] != null && dt.Rows[n]["SED_RkMoney"].ToString() != "")
                    {
                        model.SED_RkMoney = decimal.Parse(dt.Rows[n]["SED_RkMoney"].ToString());
                    }
                    if (dt.Rows[n]["SED_RkTime"] != null && dt.Rows[n]["SED_RkTime"].ToString() != "")
                    {
                        model.SED_RkTime = DateTime.Parse(dt.Rows[n]["SED_RkTime"].ToString());
                    }
                    if (dt.Rows[n]["SED_RkPerson"] != null && dt.Rows[n]["SED_RkPerson"].ToString() != "")
                    {
                        model.SED_RkPerson = dt.Rows[n]["SED_RkPerson"].ToString();
                    }
                    if (dt.Rows[n]["SED_Type"] != null && dt.Rows[n]["SED_Type"].ToString() != "")
                    {
                        model.SED_Type = int.Parse(dt.Rows[n]["SED_Type"].ToString());
                    }
                    if (dt.Rows[n]["SED_Remarks"] != null && dt.Rows[n]["SED_Remarks"].ToString() != "")
                    {
                        model.SED_Remarks = dt.Rows[n]["SED_Remarks"].ToString();
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


using System;
using System.Data;
using System.Collections.Generic;
using KNet.Common;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Cg_Order_Checklist_Details
    /// </summary>
    public partial class Cg_Order_Checklist_Details
    {
        private readonly KNet.DAL.Cg_Order_Checklist_Details dal = new KNet.DAL.Cg_Order_Checklist_Details();
        public Cg_Order_Checklist_Details()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string COD_Code)
        {
            return dal.Exists(COD_Code);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cg_Order_Checklist_Details model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cg_Order_Checklist_Details model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateTaxMoney(KNet.Model.Cg_Order_Checklist_Details model)
        {
            return dal.UpdateTaxMoney(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateWwPrice(KNet.Model.Cg_Order_Checklist_Details model)
        {
            return dal.UpdateWwPrice(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string COD_Code)
        {

            return dal.Delete(COD_Code);
        }
        public bool DeleteByCheckNo(string COD_CheckNo)
        {

            return dal.DeleteByCheckNo(COD_CheckNo);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string COD_Codelist)
        {
            return dal.DeleteList(COD_Codelist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Cg_Order_Checklist_Details GetModel(string COD_Code)
        {
            return dal.GetModel(COD_Code);
        }

        /// <summary>
        /// 得到一个总金额
        /// </summary>
        public string GetTotalNet(string COD_Code)
        {

            return dal.GetTotalNet(COD_Code);
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
        public DataSet GetListJoinCGFP(string strWhere)
        {
            return dal.GetListJoinCGFP(strWhere);
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
        public List<KNet.Model.Cg_Order_Checklist_Details> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Cg_Order_Checklist_Details> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Cg_Order_Checklist_Details> modelList = new List<KNet.Model.Cg_Order_Checklist_Details>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Cg_Order_Checklist_Details model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Cg_Order_Checklist_Details();
                    if (dt.Rows[n]["COD_Code"] != null && dt.Rows[n]["COD_Code"].ToString() != "")
                    {
                        model.COD_Code = dt.Rows[n]["COD_Code"].ToString();
                    }
                    if (dt.Rows[n]["COD_DirectOutID"] != null && dt.Rows[n]["COD_DirectOutID"].ToString() != "")
                    {
                        model.COD_DirectOutID = dt.Rows[n]["COD_DirectOutID"].ToString();
                    }
                    if (dt.Rows[n]["COD_CustomerValue"] != null && dt.Rows[n]["COD_CustomerValue"].ToString() != "")
                    {
                        model.COD_CustomerValue = dt.Rows[n]["COD_CustomerValue"].ToString();
                    }
                    if (dt.Rows[n]["COD_GetPerson"] != null && dt.Rows[n]["COD_GetPerson"].ToString() != "")
                    {
                        model.COD_GetPerson = dt.Rows[n]["COD_GetPerson"].ToString();
                    }
                    if (dt.Rows[n]["COD_Wuliu"] != null && dt.Rows[n]["COD_Wuliu"].ToString() != "")
                    {
                        model.COD_Wuliu = dt.Rows[n]["COD_Wuliu"].ToString();
                    }
                    if (dt.Rows[n]["COD_ProductsBarCode"] != null && dt.Rows[n]["COD_ProductsBarCode"].ToString() != "")
                    {
                        model.COD_ProductsBarCode = dt.Rows[n]["COD_ProductsBarCode"].ToString();
                    }
                    if (dt.Rows[n]["COD_ProductsEdition"] != null && dt.Rows[n]["COD_ProductsEdition"].ToString() != "")
                    {
                        model.COD_ProductsEdition = dt.Rows[n]["COD_ProductsEdition"].ToString();
                    }
                    if (dt.Rows[n]["COD_CkNumber"] != null && dt.Rows[n]["COD_CkNumber"].ToString() != "")
                    {
                        model.COD_CkNumber = decimal.Parse(dt.Rows[n]["COD_CkNumber"].ToString());
                    }
                    if (dt.Rows[n]["COD_DZNumber"] != null && dt.Rows[n]["COD_DZNumber"].ToString() != "")
                    {
                        model.COD_DZNumber = decimal.Parse(dt.Rows[n]["COD_DZNumber"].ToString());
                    }
                    if (dt.Rows[n]["COD_Price"] != null && dt.Rows[n]["COD_Price"].ToString() != "")
                    {
                        model.COD_Price = decimal.Parse(dt.Rows[n]["COD_Price"].ToString());
                    }
                    if (dt.Rows[n]["COD_HandPrice"] != null && dt.Rows[n]["COD_HandPrice"].ToString() != "")
                    {
                        model.COD_HandPrice = decimal.Parse(dt.Rows[n]["COD_HandPrice"].ToString());
                    }
                    if (dt.Rows[n]["COD_Money"] != null && dt.Rows[n]["COD_Money"].ToString() != "")
                    {
                        model.COD_Money = decimal.Parse(dt.Rows[n]["COD_Money"].ToString());
                    }
                    if (dt.Rows[n]["COD_Details"] != null && dt.Rows[n]["COD_Details"].ToString() != "")
                    {
                        model.COD_Details = dt.Rows[n]["COD_Details"].ToString();
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


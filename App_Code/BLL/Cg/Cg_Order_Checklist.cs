using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using KNet.Common;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Cg_Order_Checklist
    /// </summary>
    public partial class Cg_Order_Checklist
    {
        private readonly KNet.DAL.Cg_Order_Checklist dal = new KNet.DAL.Cg_Order_Checklist();
        public Cg_Order_Checklist()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string COC_Code)
        {
            return dal.Exists(COC_Code);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Cg_Order_Checklist model)
        {
            dal.Add(model);
            ArrayList arr_Details = model.arr_Details;
            if (arr_Details != null)
            {
                for(int i=0;i<arr_Details.Count;i++)
                {
                    KNet.Model.Cg_Order_Checklist_Details Model_Details = (KNet.Model.Cg_Order_Checklist_Details)arr_Details[i];
                    KNet.BLL.Cg_Order_Checklist_Details BLL_Details = new Cg_Order_Checklist_Details();
                    BLL_Details.Add(Model_Details);
                    /*
                    if (model.COC_Type == "1")
                    {

                        KNet.BLL.Knet_Procure_WareHouseList_Details Bll_WareHouse = new Knet_Procure_WareHouseList_Details();
                        KNet.Model.Knet_Procure_WareHouseList_Details Model_WareHouse = Bll_WareHouse.GetModel(Model_Details.COD_DirectOutID);
                        if (Model_WareHouse != null)
                        {
                            if (Model_WareHouse.WareHouseUnitPrice != Model_Details.COD_Price)
                            {
                                Model_WareHouse.WareHouseUnitPrice = Model_Details.COD_Price;
                                Model_WareHouse.WareHouseTotalNet = Model_Details.COD_Price * Model_WareHouse.WareHouseAmount;
                                BasePage Base = new BasePage();
                                Model_WareHouse.KWP_NoTaxMoney = decimal.Parse(Base.FormatNumber1(Convert.ToString(Model_WareHouse.WareHouseTotalNet / Decimal.Parse("1.17")), 2)); 
                                Bll_WareHouse.Update(Model_WareHouse);
                            }
                        }
                    }*/
                }
            }
            
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Cg_Order_Checklist model)
        {
            if (dal.Update(model))
            {
                KNet.BLL.Cg_Order_Checklist_Details BLL_Details = new Cg_Order_Checklist_Details();
                BLL_Details.DeleteByCheckNo(model.COC_Code);
                ArrayList arr_Details = model.arr_Details;
                if (arr_Details != null)
                {
                    for (int i = 0; i < arr_Details.Count; i++)
                    {
                        KNet.Model.Cg_Order_Checklist_Details Model_Details = (KNet.Model.Cg_Order_Checklist_Details)arr_Details[i];
                        BLL_Details.Add(Model_Details);
                        /*
                        if (model.COC_Type == "1")
                        {

                            KNet.BLL.Knet_Procure_WareHouseList_Details Bll_WareHouse = new Knet_Procure_WareHouseList_Details();
                            KNet.Model.Knet_Procure_WareHouseList_Details Model_WareHouse = Bll_WareHouse.GetModel(Model_Details.COD_DirectOutID);
                            if (Model_WareHouse != null)
                            {
                                if (Model_WareHouse.WareHouseUnitPrice != Model_Details.COD_Price)
                                {
                                    Model_WareHouse.WareHouseUnitPrice = Model_Details.COD_Price;
                                    Model_WareHouse.WareHouseTotalNet = Model_Details.COD_Price * Model_WareHouse.WareHouseAmount;
                                    BasePage Base = new BasePage();
                                    Model_WareHouse.KWP_NoTaxMoney = decimal.Parse(Base.FormatNumber1(Convert.ToString(Model_WareHouse.WareHouseTotalNet / Decimal.Parse("1.17")), 2)); 
                                    Bll_WareHouse.Update(Model_WareHouse);
                                }
                            }
                        }*/
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateIsPayMent(KNet.Model.Cg_Order_Checklist model)
        {
            return dal.UpdateIsPayMent(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string COC_Code)
        {

            return dal.Delete(COC_Code);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string COC_Codelist)
        {
            return dal.DeleteList(COC_Codelist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Cg_Order_Checklist GetModel(string COC_Code)
        {

            return dal.GetModel(COC_Code);
        }

        /// <summary>
   

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
        public DataSet GetDetailsList(string strWhere)
        {
            return dal.GetDetailsList(strWhere);
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
        public List<KNet.Model.Cg_Order_Checklist> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Cg_Order_Checklist> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Cg_Order_Checklist> modelList = new List<KNet.Model.Cg_Order_Checklist>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Cg_Order_Checklist model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Cg_Order_Checklist();
                    if (dt.Rows[n]["COC_Code"] != null && dt.Rows[n]["COC_Code"].ToString() != "")
                    {
                        model.COC_Code = dt.Rows[n]["COC_Code"].ToString();
                    }
                    if (dt.Rows[n]["COC_HouseNo"] != null && dt.Rows[n]["COC_HouseNo"].ToString() != "")
                    {
                        model.COC_HouseNo = dt.Rows[n]["COC_HouseNo"].ToString();
                    }
                    if (dt.Rows[n]["COC_Stime"] != null && dt.Rows[n]["COC_Stime"].ToString() != "")
                    {
                        model.COC_Stime = DateTime.Parse(dt.Rows[n]["COC_Stime"].ToString());
                    }
                    if (dt.Rows[n]["COC_BeginDate"] != null && dt.Rows[n]["COC_BeginDate"].ToString() != "")
                    {
                        model.COC_BeginDate = DateTime.Parse(dt.Rows[n]["COC_BeginDate"].ToString());
                    }
                    if (dt.Rows[n]["COC_EndDate"] != null && dt.Rows[n]["COC_EndDate"].ToString() != "")
                    {
                        model.COC_EndDate = DateTime.Parse(dt.Rows[n]["COC_EndDate"].ToString());
                    }
                    if (dt.Rows[n]["COC_Details"] != null && dt.Rows[n]["COC_Details"].ToString() != "")
                    {
                        model.COC_Details = dt.Rows[n]["COC_Details"].ToString();
                    }
                    if (dt.Rows[n]["COC_CTime"] != null && dt.Rows[n]["COC_CTime"].ToString() != "")
                    {
                        model.COC_CTime = DateTime.Parse(dt.Rows[n]["COC_CTime"].ToString());
                    }
                    if (dt.Rows[n]["COC_Creator"] != null && dt.Rows[n]["COC_Creator"].ToString() != "")
                    {
                        model.COC_Creator = dt.Rows[n]["COC_Creator"].ToString();
                    }
                    if (dt.Rows[n]["COC_MTime"] != null && dt.Rows[n]["COC_MTime"].ToString() != "")
                    {
                        model.COC_MTime = DateTime.Parse(dt.Rows[n]["COC_MTime"].ToString());
                    }
                    if (dt.Rows[n]["COC_Mender"] != null && dt.Rows[n]["COC_Mender"].ToString() != "")
                    {
                        model.COC_Mender = dt.Rows[n]["COC_Mender"].ToString();
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


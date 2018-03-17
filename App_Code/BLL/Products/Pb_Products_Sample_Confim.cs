using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Pb_Products_Sample_Confim
    /// </summary>
    public partial class Pb_Products_Sample_Confim
    {
        private readonly KNet.DAL.Pb_Products_Sample_Confim dal = new KNet.DAL.Pb_Products_Sample_Confim();
        public Pb_Products_Sample_Confim()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBC_ID)
        {
            return dal.Exists(PBC_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Pb_Products_Sample_Confim model)
        {
            KNet.BLL.Pb_Products_Sample_Images Bll_Details = new KNet.BLL.Pb_Products_Sample_Images();
            KNet.BLL.Pb_Products_Sample BLL_Sample = new KNet.BLL.Pb_Products_Sample();
            KNet.Model.Pb_Products_Sample Model_Sample = BLL_Sample.GetModel(model.PBC_SampleID);
            Model_Sample.PPS_Dept = model.s_Type;
            Model_Sample.PPS_ID = model.PBC_SampleID;
            BLL_Sample.UpdateDept(Model_Sample);
            dal.Add(model);
            //更新产品对应的样品编号
            KNet.BLL.KNet_Sys_Products BLL_Products = new KNet.BLL.KNet_Sys_Products();
            KNet.Model.KNet_Sys_Products Model_Products = new KNet.Model.KNet_Sys_Products();
            BLL_Products.UpdateBySampleID(model.PBC_SampleID);

            //修改该客户的对应销售产品
            try
            {
                string s_Customer = Model_Sample.PPS_CustomerValue == null ? "" : Model_Sample.PPS_CustomerValue;
                if (s_Customer != "")
                {
                    KNet.BLL.KNet_Sys_Products Bll_Pro = new KNet.BLL.KNet_Sys_Products();
                    KNet.Model.KNet_Sys_Products Model_Pro = Bll_Pro.GetModelBySampleID(model.PBC_SampleID);
                    KNet.BLL.Xs_Customer_Products Bll_Custom = new KNet.BLL.Xs_Customer_Products();
                    KNet.Model.Xs_Customer_Products Model_Custom = new KNet.Model.Xs_Customer_Products();
                    if (Model_Pro != null)
                    {
                        Bll_Custom.DeleteByCustomerAndProducts(s_Customer, Model_Pro.ProductsBarCode);
                    }
                    Bll_Custom.DeleteByCustomerAndProducts(s_Customer, model.s_ProductsBarCode);
                    //增加新的
                    Model_Custom.XCP_CustomerID = s_Customer;
                    Model_Custom.XCP_ProductsID = model.s_ProductsBarCode;
                    Bll_Custom.Add(Model_Custom);
                }
            }
            catch (Exception ex)
            { }
            Model_Products.ProductsBarCode = model.s_ProductsBarCode;
            Model_Products.KSP_SampleId = model.PBC_SampleID;
            BLL_Products.UpdateSampleID(Model_Products);
            
            //如果打样结束
            try
            {
                if (Model_Sample.PPS_Type == "13")
                {
                    //打样结束 
                    Model_Products.KSP_isModiy = 0;
                    BLL_Products.UpdateisModiy(Model_Products);
                }
            }
            catch
            { }
            if (model.arr_Details != null)
            {
                for (int i = 0; i < model.arr_Details.Count; i++)
                {
                    KNet.Model.Pb_Products_Sample_Images Model_details = (KNet.Model.Pb_Products_Sample_Images)model.arr_Details[i];
                    Bll_Details.Add(Model_details);
                }
            }

            KNet.BLL.PB_Basic_Sample_ProductsDetails BL_ProductsDetails = new KNet.BLL.PB_Basic_Sample_ProductsDetails();
            if (model.arr_Details1 != null)
            {
                BL_ProductsDetails.DeleteByFID(model.PBC_SampleID);
                for (int i = 0; i < model.arr_Details1.Count; i++)
                {
                    KNet.Model.PB_Basic_Sample_ProductsDetails Model_ProductsDetails = (KNet.Model.PB_Basic_Sample_ProductsDetails)model.arr_Details1[i];
                    BL_ProductsDetails.Add(Model_ProductsDetails);
                }
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Pb_Products_Sample_Confim model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PBC_ID)
        {

            return dal.Delete(PBC_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PBC_IDlist)
        {
            return dal.DeleteList(PBC_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Pb_Products_Sample_Confim GetModel(string PBC_ID)
        {

            return dal.GetModel(PBC_ID);
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
        public List<KNet.Model.Pb_Products_Sample_Confim> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Pb_Products_Sample_Confim> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Pb_Products_Sample_Confim> modelList = new List<KNet.Model.Pb_Products_Sample_Confim>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Pb_Products_Sample_Confim model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Pb_Products_Sample_Confim();
                    if (dt.Rows[n]["PBC_ID"] != null && dt.Rows[n]["PBC_ID"].ToString() != "")
                    {
                        model.PBC_ID = dt.Rows[n]["PBC_ID"].ToString();
                    }
                    if (dt.Rows[n]["PBC_Type"] != null && dt.Rows[n]["PBC_Type"].ToString() != "")
                    {
                        model.PBC_Type = dt.Rows[n]["PBC_Type"].ToString();
                    }
                    if (dt.Rows[n]["PBC_Stime"] != null && dt.Rows[n]["PBC_Stime"].ToString() != "")
                    {
                        model.PBC_Stime = DateTime.Parse(dt.Rows[n]["PBC_Stime"].ToString());
                    }
                    if (dt.Rows[n]["PBC_Person"] != null && dt.Rows[n]["PBC_Person"].ToString() != "")
                    {
                        model.PBC_Person = dt.Rows[n]["PBC_Person"].ToString();
                    }
                    if (dt.Rows[n]["PBC_Remarks"] != null && dt.Rows[n]["PBC_Remarks"].ToString() != "")
                    {
                        model.PBC_Remarks = dt.Rows[n]["PBC_Remarks"].ToString();
                    }
                    if (dt.Rows[n]["PBC_CTime"] != null && dt.Rows[n]["PBC_CTime"].ToString() != "")
                    {
                        model.PBC_CTime = DateTime.Parse(dt.Rows[n]["PBC_CTime"].ToString());
                    }
                    if (dt.Rows[n]["PBC_Creator"] != null && dt.Rows[n]["PBC_Creator"].ToString() != "")
                    {
                        model.PBC_Creator = dt.Rows[n]["PBC_Creator"].ToString();
                    }
                    if (dt.Rows[n]["PBC_MTime"] != null && dt.Rows[n]["PBC_MTime"].ToString() != "")
                    {
                        model.PBC_MTime = DateTime.Parse(dt.Rows[n]["PBC_MTime"].ToString());
                    }
                    if (dt.Rows[n]["PBC_Mender"] != null && dt.Rows[n]["PBC_Mender"].ToString() != "")
                    {
                        model.PBC_Mender = dt.Rows[n]["PBC_Mender"].ToString();
                    }
                    if (dt.Rows[n]["PBC_Del"] != null && dt.Rows[n]["PBC_Del"].ToString() != "")
                    {
                        model.PBC_Del = int.Parse(dt.Rows[n]["PBC_Del"].ToString());
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


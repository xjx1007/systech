using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类KNet_Sys_Products
    /// </summary>
    public class KNet_Sys_Products
    {
        private readonly KNet.DAL.KNet_Sys_Products dal = new KNet.DAL.KNet_Sys_Products();
        public KNet_Sys_Products()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(KNet.Model.KNet_Sys_Products model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateSampleID(KNet.Model.KNet_Sys_Products model)
        {
            return dal.UpdateSampleID(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateBySampleID(string s_KSP_SampleId)
        {
            return dal.UpdateBySampleID(s_KSP_SampleId);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateDel(KNet.Model.KNet_Sys_Products model)
        {
            return dal.UpdateDel(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateisModiy(KNet.Model.KNet_Sys_Products model)
        {
            return dal.UpdateisModiy(model);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.KNet_Sys_Products model)
        {
            try
            {
                //如果有产品更新
                if (model.KSP_GProductsBarCode != "")
                {
                    //插入有老产品的BOM
                }
                //如果是成品
                /*
                if ((model.ProductsMainCategory == "129678733470295462") && (model.KSP_SampleId != ""))
                {
                    KNet.BLL.KNet_Sys_Products BLL_Products = new KNet.BLL.KNet_Sys_Products();
                    BLL_Products.UpdateBySampleID(model.KSP_SampleId);
                }
                */
                if (model.CustomerList != null)
                {
                    KNet.BLL.Xs_Customer_Products BLL_Customer_Products = new KNet.BLL.Xs_Customer_Products();
                    for (int i = 0; i < model.CustomerList.Count; i++)
                    {
                        KNet.Model.Xs_Customer_Products Model_Customer_Products = (KNet.Model.Xs_Customer_Products)model.CustomerList[i];
                        BLL_Customer_Products.Add(Model_Customer_Products);
                    }
                }
                if (model.DemoProductsList != null)
                {
                    KNet.BLL.Xs_Products_Prodocts_Demo BLL_DemoProducts_Prodocts = new KNet.BLL.Xs_Products_Prodocts_Demo();
                    for (int i = 0; i < model.DemoProductsList.Count; i++)
                    {
                        KNet.Model.Xs_Products_Prodocts_Demo Model_DemoProducts_Prodocts = (KNet.Model.Xs_Products_Prodocts_Demo)model.DemoProductsList[i];
                        BLL_DemoProducts_Prodocts.Add(Model_DemoProducts_Prodocts);
                    }
                }
                //采购周期
                if (model.arr_CgDayDetails != null)
                {

                    KNet.BLL.PB_Products_CgDays BLLs_CgDays = new KNet.BLL.PB_Products_CgDays();
                    for (int i = 0; i < model.arr_CgDayDetails.Count; i++)
                    {
                        KNet.Model.PB_Products_CgDays Model_CgDays = (KNet.Model.PB_Products_CgDays)model.arr_CgDayDetails[i];
                        BLLs_CgDays.Add(Model_CgDays);
                    }
                }
                //产品附件
                if (model.arr_Details != null)
                {
                    KNet.BLL.Pb_Products_Sample_Images Bll_Details = new KNet.BLL.Pb_Products_Sample_Images();
                    for (int i = 0; i < model.arr_Details.Count; i++)
                    {
                        KNet.Model.Pb_Products_Sample_Images Model_details = (KNet.Model.Pb_Products_Sample_Images)model.arr_Details[i];
                        Bll_Details.Add(Model_details);
                    }
                }
                //可替代物料
                if (model.arr_Alternative != null)
                {
                    KNet.BLL.Products_Replace_List Bll_ReplaceList = new KNet.BLL.Products_Replace_List();
                    for (int i = 0; i < model.arr_Alternative.Count; i++)
                    {
                        KNet.Model.Products_Replace_List Model_details = (KNet.Model.Products_Replace_List)model.arr_Alternative[i];
                        Bll_ReplaceList.Add(Model_details);
                    }
                }

                if (model.Type == 2)//升级
                {
                    bool b_Stop = true;
                    #region 新产品升级
                    try
                    {
                        //
                        if (model.arr_RCDetails != null)
                        {
                            KNet.BLL.Xs_Products_Prodocts_Demo Bll_Demo = new KNet.BLL.Xs_Products_Prodocts_Demo();
                            for (int i = 0; i < model.arr_RCDetails.Count; i++)
                            {
                                KNet.Model.Xs_Products_Prodocts_Demo Model_details = (KNet.Model.Xs_Products_Prodocts_Demo)model.arr_RCDetails[i];
                                //如果是替换
                                if (Model_details.XPD_IsModiy == 1)
                                {
                                    //插入
                                    string s_Dosql = "insert into Xs_Products_Prodocts_Demo(";
                                    s_Dosql += "XPD_ID,XPD_ProductsBarCode,XPD_SuppNo,XPD_Price,XPD_Number,XPD_FaterBarCode,XPD_IsOrder,XPD_Address)";
                                    s_Dosql += " select ";
                                    s_Dosql += "dbo.GetID(),'" + model.ProductsBarCode + "',XPD_SuppNo,XPD_Price,XPD_Number,XPD_FaterBarCode,XPD_IsOrder,XPD_Address from ";
                                    s_Dosql += " Xs_Products_Prodocts_Demo  where XPD_ID='" + Model_details.XPD_ID + "'";


                                    //停用原来的产品
                                    s_Dosql += "Update Xs_Products_Prodocts_Demo set XPD_Del=1 ";
                                    s_Dosql += "  where XPD_ID='" + Model_details.XPD_ID + "'";
                                    DbHelperSQL.ExecuteSql(s_Dosql);
                                }
                                else if (Model_details.XPD_IsModiy == 2)//不替换
                                {

                                    //停用原来的产品
                                    b_Stop = false;
                                    /*
                                    string s_Dosql = "Update Xs_Products_Prodocts_Demo set XPD_Del=1 ";
                                    s_Dosql += "  where XPD_ID='" + Model_details.XPD_ID + "'";
                                    DbHelperSQL.ExecuteSql(s_Dosql);
                                     * */
                                }
                                else if (Model_details.XPD_IsModiy == 3)//共存
                                {

                                    b_Stop = false;
                                    //插入
                                    string s_Dosql = "insert into Xs_Products_Prodocts_Demo(";
                                    s_Dosql += "XPD_ID,XPD_ProductsBarCode,XPD_SuppNo,XPD_Price,XPD_Number,XPD_FaterBarCode,XPD_IsOrder,XPD_Address)";
                                    s_Dosql += " select ";
                                    s_Dosql += "dbo.GetID(),'" + model.ProductsBarCode + "',XPD_SuppNo,XPD_Price,XPD_Number,XPD_FaterBarCode,XPD_IsOrder,XPD_Address from ";
                                    s_Dosql += " Xs_Products_Prodocts_Demo  where XPD_ID='" + Model_details.XPD_ID + "'";
                                    DbHelperSQL.ExecuteSql(s_Dosql);

                                }
                            }
                        }

                    }
                    catch
                    { }
                    #endregion
                    if (b_Stop)
                    {

                        //停用原来的BOM产品
                        string s_Dosql = " Update KNET_Sys_Products set KSP_Del=1 ";
                        s_Dosql += " where ProductsBarCode='" + model.KSP_GProductsBarCode + "'";
                        DbHelperSQL.ExecuteSql(s_Dosql);
                    }
                }
                #region 产品升级
                //产品升级操作
                try
                {
                    if (model.KSP_IsAdd == 1)
                    {
                        //替换产品BOM

                        string s_Sql = "select * from Xs_Products_Prodocts_Demo where XPD_ProductsBarCode='" + model.ProductsBarCode + "'";
                        BasePage Base = new BasePage();
                        Base.BeginQuery(s_Sql);
                        DataTable Dtb_TableBom = (DataTable)Base.QueryForDataTable();
                        if (Dtb_TableBom.Rows.Count <= 0)
                        {
                            //插入
                            string s_Dosql = "insert into Xs_Products_Prodocts_Demo(";
                            s_Dosql += "XPD_ID,XPD_ProductsBarCode,XPD_SuppNo,XPD_Price,XPD_Number,XPD_FaterBarCode,XPD_IsOrder,XPD_Address)";
                            s_Dosql += " select ";
                            s_Dosql += "dbo.GetID(),'" + model.ProductsBarCode + "',XPD_SuppNo,XPD_Price,XPD_Number,XPD_FaterBarCode,XPD_IsOrder,XPD_Address from ";
                            s_Dosql += " Xs_Products_Prodocts_Demo  where XPD_ProductsBarCode='" + model.KSP_GProductsBarCode + "'";

                            //更新原来的替换物料为新产品
                            s_Dosql += " Update Xs_Products_Prodocts_Demo set XPD_ReplaceProductsBarCode='" + model.ProductsBarCode + "'";
                            s_Dosql += " where XPD_ProductsBarCode='" + model.KSP_GProductsBarCode + "'";
                            DbHelperSQL.ExecuteSql(s_Dosql);
                        }
                    }
                    if (model.KSP_IsReplace == 1)
                    {
                        //替换停用并删除
                        string s_Dosql = "insert into Xs_Products_Prodocts_Demo(";
                        s_Dosql += "XPD_ID,XPD_ProductsBarCode,XPD_SuppNo,XPD_Price,XPD_Number,XPD_FaterBarCode,XPD_IsOrder,XPD_Address)";
                        s_Dosql += " select ";
                        s_Dosql += "dbo.GetID(),'" + model.ProductsBarCode + "',XPD_SuppNo,XPD_Price,XPD_Number,XPD_FaterBarCode,XPD_IsOrder,XPD_Address from ";
                        s_Dosql += " Xs_Products_Prodocts_Demo  where XPD_ProductsBarCode='" + model.KSP_GProductsBarCode + "'";

                        //停用原来的BOM产品
                        s_Dosql += " Update KNET_Sys_Products set KSP_Del=1 ";
                        s_Dosql += " where ProductsBarCode='" + model.KSP_GProductsBarCode + "'";

                        //更新原来的替换物料为新产品
                        s_Dosql += " Update Xs_Products_Prodocts_Demo set XPD_ReplaceProductsBarCode='" + model.ProductsBarCode + "'";
                        s_Dosql += " where XPD_ProductsBarCode='" + model.KSP_GProductsBarCode + "'";

                        DbHelperSQL.ExecuteSql(s_Dosql);
                    }
                    if (model.KSP_IsDelete == 1)
                    {
                        //插入
                        string s_Dosql = "";
                        //删除
                        s_Dosql += " delete from Xs_Products_Prodocts_Demo";
                        s_Dosql += " where XPD_ProductsBarCode='" + model.KSP_GProductsBarCode + "'";
                        DbHelperSQL.ExecuteSql(s_Dosql);
                    }
                }
                catch
                { }
                #endregion
                dal.Add(model);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.KNet_Sys_Products model)
        {

            KNet.BLL.Xs_Customer_Products BLL_Customer_Products = new KNet.BLL.Xs_Customer_Products();
            BLL_Customer_Products.Delete(model.ProductsBarCode);
            if (model.CustomerList != null)
            {

                for (int i = 0; i < model.CustomerList.Count; i++)
                {
                    KNet.Model.Xs_Customer_Products Model_Customer_Products = (KNet.Model.Xs_Customer_Products)model.CustomerList[i];
                    BLL_Customer_Products.Add(Model_Customer_Products);
                }
            }
            KNet.BLL.Xs_Products_Prodocts_Demo BLL_DemoProducts_Prodocts = new KNet.BLL.Xs_Products_Prodocts_Demo();
            if (model.s_BomIDs != null)
            {
                BLL_DemoProducts_Prodocts.UpdateDel(model.s_BomIDs, model.ProductsBarCode);
                BLL_DemoProducts_Prodocts.DeleteByIDs(model.s_BomIDs, model.ProductsBarCode);
            }
            if (model.DemoProductsList != null)
            {
                for (int i = 0; i < model.DemoProductsList.Count; i++)
                {
                    KNet.Model.Xs_Products_Prodocts_Demo Model_DemoProducts_Prodocts = (KNet.Model.Xs_Products_Prodocts_Demo)model.DemoProductsList[i];
                    BLL_DemoProducts_Prodocts.Add(Model_DemoProducts_Prodocts);
                }
            }

            KNet.BLL.PB_Products_CgDays BLLs_CgDays = new KNet.BLL.PB_Products_CgDays();
            BLLs_CgDays.DeleteByProductsBarCode(model.ProductsBarCode);
            //采购周期
            if (model.arr_CgDayDetails != null)
            {
                for (int i = 0; i < model.arr_CgDayDetails.Count; i++)
                {
                    KNet.Model.PB_Products_CgDays Model_CgDays = (KNet.Model.PB_Products_CgDays)model.arr_CgDayDetails[i];
                    BLLs_CgDays.Add(Model_CgDays);
                }
            }
            KNet.BLL.Pb_Products_Sample_Images Bll_Details = new KNet.BLL.Pb_Products_Sample_Images();
            Bll_Details.Delete(model.ProductsBarCode, "2");
            if (model.arr_Details != null)
            {
                for (int i = 0; i < model.arr_Details.Count; i++)
                {
                    KNet.Model.Pb_Products_Sample_Images Model_details = (KNet.Model.Pb_Products_Sample_Images)model.arr_Details[i];
                    Bll_Details.Add(Model_details);
                }
            }
            KNet.BLL.Products_Replace_List Bll_ReplaceList = new KNet.BLL.Products_Replace_List();
            Bll_ReplaceList.DeleteByFID(model.ProductsBarCode);
            //可替代物料
            if (model.arr_Alternative != null)
            {
                for (int i = 0; i < model.arr_Alternative.Count; i++)
                {
                    KNet.Model.Products_Replace_List Model_details = (KNet.Model.Products_Replace_List)model.arr_Alternative[i];
                    Bll_ReplaceList.Add(Model_details);
                }
            }


            //产品升级操作
            try
            {
                if (model.KSP_IsAdd == 1)
                {
                    //替换产品BOM


                    string s_Sql = "select * from Xs_Products_Prodocts_Demo where XPD_ProductsBarCode='" + model.ProductsBarCode + "'";
                    BasePage Base = new BasePage();
                    Base.BeginQuery(s_Sql);
                    DataTable Dtb_TableBom = (DataTable)Base.QueryForDataTable();
                    if (Dtb_TableBom.Rows.Count <= 0)
                    {
                        //插入

                        string s_Dosql = "";
                        //更新原来的替换物料为新产品
                        s_Dosql += " delete from Xs_Products_Prodocts_Demo ";
                        s_Dosql += " where XPD_ProductsBarCode='" + model.ProductsBarCode + "'";

                        s_Dosql = "insert into Xs_Products_Prodocts_Demo(";
                        s_Dosql += "XPD_ID,XPD_ProductsBarCode,XPD_SuppNo,XPD_Price,XPD_Number,XPD_FaterBarCode,XPD_IsOrder,XPD_Address)";
                        s_Dosql += " select ";
                        s_Dosql += "dbo.GetID(),'" + model.ProductsBarCode + "',XPD_SuppNo,XPD_Price,XPD_Number,XPD_FaterBarCode,XPD_IsOrder,XPD_Address from ";
                        s_Dosql += " Xs_Products_Prodocts_Demo  where XPD_ProductsBarCode='" + model.KSP_GProductsBarCode + "'";

                        //更新原来的替换物料为新产品
                        s_Dosql += " Update Xs_Products_Prodocts_Demo set XPD_ReplaceProductsBarCode='" + model.ProductsBarCode + "'";
                        s_Dosql += " where XPD_ProductsBarCode='" + model.KSP_GProductsBarCode + "'";
                        DbHelperSQL.ExecuteSql(s_Dosql);
                    }
                }
                if (model.KSP_IsReplace == 1)
                {

                    //先删除已有的
                    string s_Dosql = "";
                    //更新原来的替换物料为新产品
                    s_Dosql += " delete from Xs_Products_Prodocts_Demo ";
                    s_Dosql += " where XPD_ProductsBarCode='" + model.ProductsBarCode + "'";
                    //替换停用并删除
                    s_Dosql += "insert into Xs_Products_Prodocts_Demo(";
                    s_Dosql += "XPD_ID,XPD_ProductsBarCode,XPD_SuppNo,XPD_Price,XPD_Number,XPD_FaterBarCode,XPD_IsOrder,XPD_Address)";
                    s_Dosql += " select ";
                    s_Dosql += "dbo.GetID(),'" + model.ProductsBarCode + "',XPD_SuppNo,XPD_Price,XPD_Number,XPD_FaterBarCode,XPD_IsOrder,XPD_Address from ";
                    s_Dosql += " Xs_Products_Prodocts_Demo  where XPD_ProductsBarCode='" + model.KSP_GProductsBarCode + "'";

                    //停用原来的BOM产品
                    s_Dosql += " Update KNET_Sys_Products set KSP_Del=1 ";
                    s_Dosql += " where ProductsBarCode='" + model.KSP_GProductsBarCode + "'";
                    //启用现有的
                    s_Dosql += " Update KNET_Sys_Products set KSP_Del=0 ";
                    s_Dosql += " where ProductsBarCode='" + model.ProductsBarCode + "'";

                    //更新原来的替换物料为新产品
                    s_Dosql += " Update Xs_Products_Prodocts_Demo set XPD_ReplaceProductsBarCode='" + model.ProductsBarCode + "'";
                    s_Dosql += " where XPD_ProductsBarCode='" + model.KSP_GProductsBarCode + "'";

                    DbHelperSQL.ExecuteSql(s_Dosql);
                }
                if (model.KSP_IsDelete == 1)
                {
                    //插入
                    string s_Dosql = "";
                    //删除
                    s_Dosql += " delete from Xs_Products_Prodocts_Demo";
                    s_Dosql += " where XPD_ProductsBarCode='" + model.ProductsBarCode + "'";
                    DbHelperSQL.ExecuteSql(s_Dosql);
                }
            }
            catch
            { }
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ID)
        {
            dal.Delete(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sys_Products GetModel(string ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sys_Products GetModelB(string ProductsBarCode)
        {

            return dal.GetModelB(ProductsBarCode);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.KNet_Sys_Products GetModelBySampleID(string KSP_SampleID)
        {

            return dal.GetModelBySampleID(KSP_SampleID);
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
        public DataSet GetListByOrder(string strWhere)
        {
            return dal.GetListByOrder(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListByCustomer(string strWhere)
        {
            return dal.GetListByCustomer(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }


        #endregion  成员方法
    }
}


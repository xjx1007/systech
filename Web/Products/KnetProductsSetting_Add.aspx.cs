using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Data.SqlClient;

using KNet.DBUtility;
using KNet.Common;


/// <summary>
/// 仓库管理
/// </summary>
public partial class Knet_Web_System_KnetProductsSetting_Add : BasePage
{
    public string s_MyTable_Detail = "", s_ProductsTable_Detail = "", s_ProductsTable_BomDetail = "", s_Cgdays = "", s_ProductsRC = "", s_AlternativeDetail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Knet_Web_System_KnetProductsSetting_Add));
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            this.DataBindProductsUnits();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            this.Tbx_Type.Text = s_Type;
            string s_SampleId = Request.QueryString["KSP_SampleId"] == null ? "" : Request.QueryString["KSP_SampleId"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_SampleID.Text = s_SampleId;
            this.Tbx_ID.Text = s_ID;
            base.Base_DropDutyPerson(this.Ddl_RDPerson, " and staffDepart='129652783965723459' ");
            base.Base_DropBasicCodeBind(this.Ddl_UseType,"1134");
            if (s_ID == "")
            {

                this.Pan_Update.Visible = false;
            }
            else
            {
                this.Pan_Update.Visible = true;
            }

            this.BeginQuery("Select * From PB_Basic_Code where PBC_ID='772' Order by PBC_Order,PBC_Code");
            this.QueryForDataSet();
            Chk_CgType.DataSource = Dts_Result;
            Chk_CgType.DataTextField = "PBC_Name";
            Chk_CgType.DataValueField = "PBC_Code";
            Chk_CgType.DataBind();
            Chk_CgType.SelectedValue = "0";
            if (AM.KNet_StaffDepart == "129652783965723459")//研发中心
            {

                this.Button4.Visible = true;//Bom
                this.Pan_De.Enabled = true;
                this.Ddl_RDPerson.SelectedValue = AM.KNet_StaffNo;
            }
            else
            {
                this.Button4.Visible = false;
                this.Pan_De.Enabled = true;
                this.Chk_isModiy.Checked = false;
            }
            if (s_Type == "1")
            {
                this.Lbl_Title.Text = "复制产品";
                this.ShowInfo(s_ID);
                this.lblID.Text = "";
                this.ProductsBarCode.Text = KNetPage.GetOrderId("D");
                this.Tbx_Code.Text = base.Base_GetNewProductsCode(this.Tbx_ProductsTypeNo.Text);
                this.Tbx_SampleID.Text = "";
                this.Tbx_GProductsBarCode.Value = "";
                this.Tbx_GProductsEdition.Text = "";
                this.Chk_add.Checked = false;
                this.Chk_Delete.Checked = false;
                this.Chk_IsReplace.Checked = false;
            }
            else if (s_Type == "2")
            {
                this.Lbl_Title.Text = "升级产品";
                this.ShowInfo(s_ID);
                this.Tbx_GProductsBarCode.Value = s_ID;
                this.Tbx_GProductsEdition.Text = base.Base_GetProductsEdition(s_ID);
                this.lblID.Text = "";
                this.ProductsBarCode.Text = KNetPage.GetOrderId("D");
                this.Tbx_Code.Text = base.Base_GetNewProductsCode(this.Tbx_ProductsTypeNo.Text);
                this.Tbx_SampleID.Text = "";
                this.Lbl_Detail.Text = base.Base_GetProductsEdition_Link(s_ID) + " 库存：" + base.Base_GetHouseAndNumber(s_ID);
                //   this.pan_Bom.Visible = false;
                if (base.Base_GetProductsCode(s_ID).IndexOf("01") == 0)//成品
                {
                    Div3.Style["display"] = "block";
                }
                else
                {
                    Div3.Style["display"] = "none";
                }
            }
            else
            {
                if (this.Tbx_ID.Text != "")
                {
                    this.Lbl_Title.Text = "修改产品";
                    this.ShowInfo(this.Tbx_ID.Text);
                }
                else
                {
                    this.Lbl_Title.Text = "新增产品";
                    this.ProductsBarCode.Text = KNetPage.GetOrderId("D");
                }
            }

            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }

            this.ProductsAddTime.Text = DateTime.Now.ToShortDateString();

            this.ProductsAddMan.Text = AM.KNet_StaffName;
            this.ProductsAddMantxt.Text = AM.KNet_StaffNo;
            this.Image1.ImageUrl = "../images/Nopic.jpg";
            this.Image1Big.Text = "../images/Nopic.jpg";

        }

        this.CommentList2.CommentFID = this.ProductsBarCode.Text;
        this.CommentList2.CommentType = "Products";
    }


    #region 图片上传操作
    /// <summary>
    /// 上传图片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void button_ServerClick(object sender, EventArgs e)
    {
        if (!(uploadFile.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
            if (FileType == "image/gif" || FileType == "image/pjpeg")
            {
                GetThumbnailImage();
            }
            else
            {
                Response.Write("<script language=javascript>alert('文件类型服务器不接受！类型:" + FileType + " ');history.back(-1);</script>");
                Response.End();
            }
        }
    }

    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage()
    {
        string UploadPath = "../UpLoadPic/ProductsBigPic/";  //上传路径

        string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "");
        string fileExt = Path.GetExtension(uploadFile.PostedFile.FileName); //获扩展名
        string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型

        string filePath = UploadPath + AutoPath + fileExt; //大文件名
        string filePathsmall = UploadPath + AutoPath + "_small" + fileExt; //小文件名

        string newfile = filePath + ".jpg"; //略图文件名

        if (FileType == "image/gif" || FileType == "image/pjpeg")
        {
            uploadFile.PostedFile.SaveAs(Server.MapPath(filePath)); //上传

            Up_Loadcs UL = new Up_Loadcs();

            UL.MakeZoomImage(Server.MapPath("../UpLoadPic/ProductsBigPic/") + AutoPath + fileExt, Server.MapPath("~/Web/UpLoadPic/ProductsSmallPic/") + AutoPath + "_small" + fileExt, 95, 75, "HW");

            this.Image1.ImageUrl = "../UpLoadPic/ProductsSmallPic/" + AutoPath + "_small" + fileExt;
            this.Image1Big.Text = filePath;
        }
        else
        {
            Response.Write("<script language=javascript>alert('文件类型服务器不接受！类型:" + FileType + " ');history.back(-1);</script>");
            Response.End();
        }
    }

    #endregion


    /// <summary>
    /// 单位绑定
    /// </summary>
    protected void DataBindProductsUnits()
    {
        KNet.BLL.KNet_Sys_Units bll = new KNet.BLL.KNet_Sys_Units();
        DataSet ds = bll.GetAllList();
        this.ProductsUnits.DataSource = ds;
        this.ProductsUnits.DataTextField = "UnitsName";
        this.ProductsUnits.DataValueField = "UnitsNo";
        this.ProductsUnits.DataBind();
        ListItem item = new ListItem("请选择单位", ""); //默认值
        this.ProductsUnits.Items.Insert(0, item);
    }



    /// <summary>
    /// 打开上传图片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ProductsPic_CheckedChanged(object sender, EventArgs e)
    {
        if (this.ProductsPic.Checked == true)
        {
            this.AddPic.Visible = true;
        }
        else
        {
            this.AddPic.Visible = false;
        }
    }

    /// <summary>
    /// 确定添加产品字典
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string ProductsName = KNetPage.KHtmlEncode(this.ProductsName.Text.Trim());
        string ProductsBarCode = KNetPage.KHtmlEncode(this.ProductsBarCode.Text.Trim());
        string ProductsPattern = KNetPage.KHtmlEncode(this.ProductsPattern.Text.Trim());
        string ProductsMainCategory = "";
        string ProductsSmallCategory = "";

        decimal ProductsSellingPrice = decimal.Parse(this.ProductsSellingPrice.Text.Trim());
        decimal ProductsCostPrice = decimal.Parse(this.ProductsCostPrice.Text.Trim());

        string ProductsUnits = KNetPage.KHtmlEncode(this.ProductsUnits.SelectedValue.Trim());

        ArrayList Arr_Customer = new ArrayList();
        ArrayList Arr_Products = new ArrayList();
        ArrayList Arr_DemoProducts = new ArrayList();
        ArrayList Arr_RCProducts = new ArrayList();
        int ProductsStockAlert = int.Parse(this.ProductsStockAlert.Text.Trim());


        bool ProductsPic = this.ProductsPic.Checked;
        string ProductsBigPicture = this.Image1Big.Text.Trim();
        string ProductsSmallPicture = this.Image1.ImageUrl.ToString();
        string ProductsDescription = KNetPage.KHtmlEncode(this.ProductsDescription.Text.Trim());
        string ProductsDetailDescription = KNetPage.KHtmlEncode(this.ProductsDetailDescription.Text.Trim());

        DateTime ProductsAddTime = DateTime.Parse(this.ProductsAddTime.Text.Trim());
        string ProductsAddMan = this.ProductsAddMantxt.Text.Trim();
        string s_ProductsType = this.Tbx_ProductsTypeNo.Text;


        KNet.BLL.KNet_Sys_Products BLL = new KNet.BLL.KNet_Sys_Products();
        KNet.Model.KNet_Sys_Products model = new KNet.Model.KNet_Sys_Products();

        KNet.BLL.Xs_Customer_Products BLL_Customer_Products = new KNet.BLL.Xs_Customer_Products();

        KNet.BLL.Xs_Products_Prodocts BLL_Products_Prodocts = new KNet.BLL.Xs_Products_Prodocts();

        string ID = this.lblID.Text;

        model.ProductsName = ProductsName;
        model.ProductsBarCode = ProductsBarCode;
        model.ProductsPattern = ProductsPattern;
        model.ProductsMainCategory = ProductsMainCategory;
        model.ProductsSmallCategory = ProductsSmallCategory;
        model.ProductsSellingPrice = ProductsSellingPrice;
        model.ProductsCostPrice = ProductsCostPrice;
        model.ProductsUnits = ProductsUnits;
        model.ProductsStockAlert = ProductsStockAlert;
        model.ProductsPic = ProductsPic;
        model.ProductsBigPicture = ProductsBigPicture;
        model.ProductsSmallPicture = ProductsSmallPicture;
        model.ProductsDescription = ProductsDescription;
        model.ProductsDetailDescription = ProductsDetailDescription;
        model.ProductsAddTime = ProductsAddTime;
        model.ProductsAddMan = ProductsAddMan;
        model.ProductsType = s_ProductsType;
        model.ProductsEdition = this.Tbx_Edition.Text;
        model.ID = ID;
        model.HandPrice = decimal.Parse(this.Tbx_HandPrice.Text);
        model.KSP_SampleId = this.Tbx_SampleID.Text;
        model.KSP_Mould = this.Tbx_MouldNo.Text;
        model.KSP_Creator = AM.KNet_StaffNo;
        model.KSP_Mender = AM.KNet_StaffNo;
        model.KSP_CTime = DateTime.Now;
        model.KSP_MTime = DateTime.Now;
        model.KSP_Code = this.Tbx_Code.Text;
        model.KSP_GProductsBarCode = this.Tbx_GProductsBarCode.Value;
        model.KSP_UseType = this.Ddl_UseType.SelectedValue;
        try
        {
            model.Type = int.Parse(this.Tbx_Type.Text);
        }
        catch
        { model.Type = 0; }

        if (this.Chk_add.Checked)
        {
            model.KSP_IsAdd = 1;
        }
        else
        {
            model.KSP_IsAdd = 0;
        }

        if (this.Chk_Delete.Checked)
        {

            model.KSP_IsDelete = 1;
        }
        else
        {
            model.KSP_IsDelete = 0;
        }
        if (this.Chk_IsReplace.Checked)
        {
            model.KSP_IsReplace = 1;
        }
        else
        {
            model.KSP_IsReplace = 0;
        }
        try
        {
            model.KSP_Weight = decimal.Parse(this.Tbx_Weight.Text);
        }
        catch
        { }
        try
        {
            model.KSP_Volume = decimal.Parse(this.Tbx_Volume.Text);
        }
        catch
        { }
        if (Chk_isModiy.Checked)
        {
            model.KSP_isModiy = 1;
        }
        else
        {
            model.KSP_isModiy = 0;
        }


        try
        {
            model.KSP_CgType = int.Parse(this.Chk_CgType.SelectedValue);
        }
        catch { }
        model.KSP_RDPerson = this.Ddl_RDPerson.SelectedValue;

        model.KSP_CustomerProductsName = this.Tbx_CustomerProductsName.Text;
        model.KSP_CustomerProductsEdition = this.Tbx_CustomerProductsEdition.Text;
        model.KSP_CustomerProductsCode = this.Tbx_CustomerProductsCode.Text;
        try
        {
            model.KSP_BZNumber = int.Parse(this.Tbx_BZNumber.Text);
        }
        catch
        {
            model.KSP_BZNumber = 0;
        }
        if (Request["CustomerValue"] != null)
        {
            string[] s_CustomerValue = Request.Form["CustomerValue"].Split(',');
            for (int i = 0; i < s_CustomerValue.Length; i++)
            {
                KNet.Model.Xs_Customer_Products Model_Customer_Products = new KNet.Model.Xs_Customer_Products();
                Model_Customer_Products.XCP_CustomerID = s_CustomerValue[i];
                Model_Customer_Products.XCP_ProductsID = ProductsBarCode;
                Model_Customer_Products.XCP_ID = GetNewID("Xs_Customer_Products", 1);
                Arr_Customer.Add(Model_Customer_Products);
            }
            model.CustomerList = Arr_Customer;
        }
        if (Request["ProdoctsBarCode"] != null)
        {
            string[] s_ProdoctsBarCode = Request.Form["ProdoctsBarCode"].Split(',');
            string[] s_SuppNo = Request.Form["SuppNo"].Split(',');
            string[] s_Price = Request.Form["Price"].Split(',');
            string[] s_Number = Request.Form["Number"].Split(',');
            string[] s_IsOrder = Request.Form["IsOrder"].Split(',');
            string[] s_Address = Request.Form["Address"].Split(',');
            for (int i = 0; i < s_ProdoctsBarCode.Length; i++)
            {
                KNet.Model.Xs_Products_Prodocts Model_Products_Prodocts = new KNet.Model.Xs_Products_Prodocts();
                Model_Products_Prodocts.XPP_ID = GetNewID("Xs_Products_Prodocts", 1);
                Model_Products_Prodocts.XPP_ProductsBarCode = s_ProdoctsBarCode[i];
                Model_Products_Prodocts.XPP_SuppNo = s_SuppNo[i];
                Model_Products_Prodocts.XPP_Price = decimal.Parse(s_Price[i]);
                Model_Products_Prodocts.XPP_Number = decimal.Parse(s_Number[i]);
                Model_Products_Prodocts.XPP_FaterBarCode = ProductsBarCode;
                Model_Products_Prodocts.XPP_IsOrder = s_IsOrder[i];
                Model_Products_Prodocts.XPP_Address = s_Address[i];
                Arr_Products.Add(Model_Products_Prodocts);
            }
            model.ProductsList = Arr_Products;
        }

        if (this.Products_BomNum.Text != "0")
        {
            KNet.BLL.Xs_Products_Prodocts_Demo BLL_DemoProducts_Prodocts = new KNet.BLL.Xs_Products_Prodocts_Demo();

            for (int i = 0; i < int.Parse(this.Products_BomNum.Text) + 1; i++)
            {
                string s_DemoRepacleProdoctsBarCode = Request.Form["DemoRepacleProdoctsBarCode_" + i.ToString() + ""] == null ? "" : Request.Form["DemoRepacleProdoctsBarCode_" + i.ToString() + ""].ToString();

                string s_ProdoctsBarCode = Request.Form["DemoProdoctsBarCode_" + i.ToString() + ""] == null ? "" : Request.Form["DemoProdoctsBarCode_" + i.ToString() + ""].ToString();

                string s_DemoNumber = Request.Form["DemoNumber_" + i.ToString() + ""] == null ? "0" : Request.Form["DemoNumber_" + i.ToString() + ""].ToString();
                string s_XPD_Order = Request.Form["DemoOrder_" + i.ToString() + ""] == null ? "0" : Request.Form["DemoOrder_" + i.ToString() + ""].ToString();
                string s_XPD_Only = Request.Form["DemoOnly_" + i.ToString() + ""] == null ? "0" : Request.Form["DemoOnly_" + i.ToString() + ""].ToString();
                string s_XPD_Place = Request.Form["Place_" + i.ToString() + ""] == null ? "" : Request.Form["Place_" + i.ToString() + ""].ToString();

                string s_XPD_Del = Request.Form["DemoDel_" + i.ToString() + ""] == null ? "0" : Request.Form["DemoDel_" + i.ToString() + ""].ToString();
                string s_DemoID = Request.Form["DemoID_" + i.ToString() + ""] == null ? "" : Request.Form["DemoID_" + i.ToString() + ""].ToString();

                string s_DemoDID = "";
                if (s_ProdoctsBarCode != "")
                {
                    KNet.Model.Xs_Products_Prodocts_Demo Model_DemoProducts_Prodocts = new KNet.Model.Xs_Products_Prodocts_Demo();
                    if ((s_DemoID != "") && (s_DemoID != "0"))
                    {
                        Model_DemoProducts_Prodocts = BLL_DemoProducts_Prodocts.GetModel(s_DemoID);
                    }
                    string s_DIDs = GetNewID("Xs_Products_Prodocts_Demo", 1);
                    Model_DemoProducts_Prodocts.XPD_ID = s_DIDs;
                    Model_DemoProducts_Prodocts.XPD_ProductsBarCode = s_ProdoctsBarCode;
                    try
                    {
                        Model_DemoProducts_Prodocts.XPD_Number = decimal.Parse(s_DemoNumber);
                    }
                    catch
                    {
                        Model_DemoProducts_Prodocts.XPD_Number = 1;
                    }
                    Model_DemoProducts_Prodocts.XPD_Order = int.Parse(s_XPD_Order);

                    if (s_XPD_Only == "on")
                    {
                        Model_DemoProducts_Prodocts.XPD_Only = 1;
                    }
                    else
                    {

                        Model_DemoProducts_Prodocts.XPD_Only = 0;
                    }

                    if (s_XPD_Del == "on")
                    {
                        Model_DemoProducts_Prodocts.XPD_Del = 1;
                    }
                    else
                    {

                        Model_DemoProducts_Prodocts.XPD_Del = 0;
                    }

                    Model_DemoProducts_Prodocts.XPD_FaterBarCode = ProductsBarCode;
                    Model_DemoProducts_Prodocts.XPD_ReplaceProductsBarCode = s_DemoRepacleProdoctsBarCode;
                    Model_DemoProducts_Prodocts.XPD_Place = s_XPD_Place;
                    Arr_DemoProducts.Add(Model_DemoProducts_Prodocts);
                    if (s_DemoID == "")
                    {
                        Model_DemoProducts_Prodocts.XPD_AddDateTime = DateTime.Now;

                    }
                    model.DemoProductsList = Arr_DemoProducts;
                    s_DemoDID += Model_DemoProducts_Prodocts.XPD_ID + ",";
                }
                model.s_BomIDs = s_DemoID.Split(',');
            }
        }
        if (this.Tbx_RCNum.Text != "0")
        {
            KNet.BLL.Xs_Products_Prodocts_Demo BLL_Demo = new KNet.BLL.Xs_Products_Prodocts_Demo();

            for (int i = 0; i < int.Parse(this.Tbx_RCNum.Text) + 1; i++)
            {

                string s_RCID = Request.Form["RCID_" + i.ToString() + ""] == null ? "" : Request.Form["RCID_" + i.ToString() + ""].ToString();
                string s_ProdoctsBarCode = Request.Form["FaterBarCode_" + i.ToString() + ""] == null ? "" : Request.Form["FaterBarCode_" + i.ToString() + ""].ToString();
                string s_IsModiy = Request.Form["groupname_" + i.ToString() + ""] == null ? "0" : Request.Form["groupname_" + i.ToString() + ""].ToString();
                if (s_RCID != "")
                {

                    KNet.Model.Xs_Products_Prodocts_Demo Model_Demo = BLL_Demo.GetModel(s_RCID);
                    Model_Demo.XPD_IsModiy = int.Parse(s_IsModiy);
                    Arr_RCProducts.Add(Model_Demo);
                    // Arr_RCProducts
                }
            }
            model.arr_RCDetails = Arr_RCProducts;
        }
        ArrayList Arr_CgDayDetails = new ArrayList();
        if (this.Tbx_NumCgDay.Text != "0")
        {
            for (int i = 0; i < int.Parse(this.Tbx_NumCgDay.Text); i++)
            {
                string s_Max = Request.Form["Max_" + i.ToString() + ""] == null ? "" : Request.Form["Max_" + i.ToString() + ""].ToString();
                string s_Min = Request.Form["Min_" + i.ToString() + ""] == null ? "" : Request.Form["Min_" + i.ToString() + ""].ToString();
                string s_Days = Request.Form["day_" + i.ToString() + ""] == null ? "" : Request.Form["day_" + i.ToString() + ""].ToString();
                if (s_Max != "")
                {
                    KNet.Model.PB_Products_CgDays Model_CgDays = new KNet.Model.PB_Products_CgDays();
                    Model_CgDays.PPC_ID = base.GetMainID();
                    Model_CgDays.PPC_ProductsBarCode = model.ProductsBarCode;
                    Model_CgDays.PPC_Max = decimal.Parse(s_Max);
                    Model_CgDays.PPC_Min = decimal.Parse(s_Min);
                    Model_CgDays.PPC_Days = int.Parse(s_Days);
                    Arr_CgDayDetails.Add(Model_CgDays);
                    model.arr_CgDayDetails = Arr_CgDayDetails;
                }
            }


        }
        ArrayList arr_Details = new ArrayList();

        model.arr_Details = arr_Details;



        ArrayList arr_Alternative = new ArrayList();
        if (this.Products_AlternativeNum.Text != "0")
        {
            int i_Num = int.Parse(this.Products_AlternativeNum.Text);
            for (int i = 0; i < i_Num; i++)
            {
                string s_ProdoctsBarCode = Request.Form["AlternativeProdoctsBarCode_" + i.ToString() + ""] == null ? "" : Request.Form["AlternativeProdoctsBarCode_" + i.ToString() + ""];
                string s_AlternativePriority = Request.Form["AlternativePriority_" + i.ToString() + ""] == null ? "" : Request.Form["AlternativePriority_" + i.ToString() + ""];
                string s_AlternativeOlny = Request.Form["AlternativeOlny_" + i.ToString() + ""] == null ? "" : Request.Form["AlternativeOlny_" + i.ToString() + ""];

                if (s_ProdoctsBarCode != "")
                {
                    KNet.Model.Products_Replace_List Model_Details = new KNet.Model.Products_Replace_List();
                    Model_Details.PRL_ID = base.GetMainID(i);
                    Model_Details.PRL_ProductsCode = model.ProductsBarCode;
                    Model_Details.PRL_ReplaceProductsBarCode = s_ProdoctsBarCode;
                    try
                    {
                        Model_Details.PRL_AlternativePriority = int.Parse(s_AlternativePriority);
                    }
                    catch
                    {
                        Model_Details.PRL_AlternativePriority = 0;
                    }
                    if (s_AlternativeOlny == "on")
                    {
                        Model_Details.PRL_AlternativeOlny = 1;
                    }
                    else
                    {

                        Model_Details.PRL_AlternativeOlny = 0;
                    }
                    arr_Alternative.Add(Model_Details);
                }
            }
        }
        model.arr_Alternative = arr_Alternative;

        try
        {

            bool b_Isadd = true;
            if (model.KSP_Code.IndexOf("02") == 0)
            {
                //
                b_Isadd = false;
            }
            if ((AM.KNet_StaffName == "项洲") || (AM.KNet_StaffName == "姚丽春") || (AM.KNet_StaffDepart == "129652784259578018"))
            {
                b_Isadd = true;
            }
            if (b_Isadd == false)
            {
                //
                AlertAndGoBack("原材料只能由采购添加！");
                return;
            }
            else
            {

                if (ID != "")
                {

                    BLL.Update(model);
                    AdminloginMess LogAM = new AdminloginMess();
                    LogAM.Add_Logs("系统设置--->产品字典--->产品字典 修改 操作成功！编码：" + ProductsBarCode);
                    if (model.KSP_Code.IndexOf("01") == 0)
                    {
                        //产品修改
                        //销售、采购、生产、仓库、品质
                        base.Base_SendMessage("130449499957844456", KNetPage.KHtmlEncode("有 产品修改 <a href='Web/CG/Order/Knet_Procure_OpenBilling_Manage.aspx?ProductsBarCode=" + ProductsBarCode + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.ProductsEdition + "</a> 相关的采购单进行，敬请关注！"));
 
                    }

                    AlertAndRedirect("产品字典 修改 成功！", "KnetProductsSetting.aspx");
                }
                else
                {
                    if (BLL.Exists(model) == false)
                    {
                        BLL.Add(model);
                        AdminloginMess LogAM = new AdminloginMess();
                        LogAM.Add_Logs("系统设置--->产品字典--->产品字典 添加 操作成功！编码：" + ProductsBarCode);
                        if (this.Tbx_SampleID.Text != "")
                        {
                            Response.Write("<script>alert('产品字典 添加 成功！');location.href='../ProductsSample/Pb_Products_Sample_Approval.aspx?ID=" + this.Tbx_SampleID.Text + "';</script>");
                            Response.End();
                        }
                        else
                        {
                            Response.Write("<script>alert('产品字典 添加 成功！');location.href='KnetProductsSetting.aspx';</script>");
                            Response.End();

                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('该产品已存在 添加失败1！');history.back(-1);</script>");
                        Response.End();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('产品字典 添加失败1！');history.back(-1);</script>");
            Response.End();
        }
    }

    /// <summary>
    /// 显示产品
    /// </summary>
    /// <param name="ID"></param>
    protected void ShowInfo(string ID)
    {
        KNet.BLL.KNet_Sys_Products bll = new KNet.BLL.KNet_Sys_Products();
        KNet.Model.KNet_Sys_Products model = bll.GetModel(ID);
        if (model == null)
        {
            model = bll.GetModelB(ID);
        }
        this.lblID.Text = model.ID;
        try
        {
            this.Chk_CgType.SelectedValue = model.KSP_CgType.ToString();
        }
        catch { }
        this.Ddl_RDPerson.SelectedValue = model.KSP_RDPerson;
        this.ProductsName.Text = model.ProductsName;
        this.ProductsBarCode.Text = model.ProductsBarCode;
        this.ProductsPattern.Text = model.ProductsPattern;
        this.Tbx_Edition.Text = model.ProductsEdition;
        this.Tbx_SampleID.Text = model.KSP_SampleId;
        this.Tbx_Code.Text = model.KSP_Code;
        this.Tbx_GProductsBarCode.Value = model.KSP_GProductsBarCode;
        this.Tbx_Volume.Text = model.KSP_Volume.ToString();
        this.Tbx_Weight.Text = model.KSP_Weight.ToString();

        this.Ddl_UseType.SelectedValue= model.KSP_UseType ;
        this.Tbx_GProductsEdition.Text = base.Base_GetProductsEdition(model.KSP_GProductsBarCode);
        try
        {
            KNet.BLL.PB_Basic_ProductsClass Bll_Class = new KNet.BLL.PB_Basic_ProductsClass();
            this.Tbx_ProductsTypeNo.Text = model.ProductsType;
            this.Tbx_ProductsTypeName.Text = Bll_Class.GetProductsName(model.ProductsType);
        }
        catch { }

        try
        {
            this.ProductsUnits.SelectedValue = model.ProductsUnits;

            this.Tbx_MouldNo.Text = model.KSP_Mould;
            this.Tbx_MouldName.Text = base.Base_GetProdutsName(model.KSP_Mould);
            this.Tbx_MouldCode.Text = base.Base_GetProductsPattern(model.KSP_Mould);


            if (model.KSP_IsAdd == 1)
            {
                this.Chk_add.Checked = true;
            }
            else
            {
                this.Chk_add.Checked = false;
            }

            if (model.KSP_IsDelete == 1)
            {

                this.Chk_Delete.Checked = true;
            }
            else
            {
                this.Chk_Delete.Checked = false;
            }
            if (model.KSP_IsReplace == 1)
            {
                this.Chk_IsReplace.Checked = true;
            }
            else
            {
                this.Chk_IsReplace.Checked = false;
            }
        }
        catch { }




        this.Tbx_CustomerProductsName.Text = model.KSP_CustomerProductsName;
        this.Tbx_CustomerProductsEdition.Text = model.KSP_CustomerProductsEdition;
        this.Tbx_CustomerProductsCode.Text = model.KSP_CustomerProductsCode;
        this.Tbx_BZNumber.Text = model.KSP_BZNumber.ToString();


        this.ProductsSellingPrice.Text = model.ProductsSellingPrice.ToString();
        this.ProductsCostPrice.Text = model.ProductsCostPrice.ToString();
        this.Tbx_HandPrice.Text = model.HandPrice.ToString();
        this.Tbx_Weight.Text = model.KSP_Weight.ToString();
        this.Tbx_Volume.Text = model.KSP_Volume.ToString();
        if (model.ProductsPic == true)
        {
            this.ProductsPic.Checked = true;
            this.AddPic.Visible = true;
            this.Image1Big.Text = model.ProductsBigPicture;
            this.Image1.ImageUrl = model.ProductsSmallPicture;
        }
        else
        {
            this.ProductsPic.Checked = false;
            this.AddPic.Visible = false;

            this.Image1.ImageUrl = "/images/Nopic.jpg";
            this.Image1Big.Text = "/images/Nopic.jpg";
        }

        //适用成品1
        KNet.BLL.Xs_Products_Prodocts_Demo BLL_RCProducts = new KNet.BLL.Xs_Products_Prodocts_Demo();
        DataSet Dts_RCProducts = BLL_RCProducts.GetList(" XPD_ProductsBarCode='" + model.ProductsBarCode + "' ");
        DataTable Dtb_RCProducts = Dts_RCProducts.Tables[0];
        if (Dtb_RCProducts.Rows.Count > 0)
        {

            for (int i = 0; i < Dtb_RCProducts.Rows.Count; i++)
            {
                s_ProductsRC += "<tr>";
                s_ProductsRC += "<td class=\"ListHeadDetails\">";
                if (this.Tbx_Type.Text == "2")
                {
                    s_ProductsRC += "<input type=\"hidden\"  Name=\"RCID_" + i.ToString() + "\" value='" + Dtb_RCProducts.Rows[i]["XPD_ID"].ToString() + "'><input type=\"hidden\"  Name=\"FaterBarCode_" + i.ToString() + "\" value='" + Dtb_RCProducts.Rows[i]["XPD_FaterBarCode"].ToString() + "'><input type=\"radio\" ID=\"Chk_IsReplace_" + i.ToString() + "\" name=\"groupname_" + i.ToString() + "\" value=1  checked>替换<br/>";
                    s_ProductsRC += "<input type=\"radio\" ID=\"Chk_IsDelete_" + i.ToString() + "\"  name=\"groupname_" + i.ToString() + "\" value=2>不替换<br/>";
                    s_ProductsRC += "<input type=\"radio\" ID=\"Chk_isModiy_" + i.ToString() + "\" name=\"groupname_" + i.ToString() + "\" value=3>共存";
                }
                else
                {
                    s_ProductsRC += "&nbsp;";
                }
                s_ProductsRC += "</td>";

                s_ProductsRC += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName_Link(Dtb_RCProducts.Rows[i]["XPD_FaterBarCode"].ToString()) + "</td>";
                s_ProductsRC += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dtb_RCProducts.Rows[i]["XPD_FaterBarCode"].ToString()) + "</td>";
                s_ProductsRC += "<td class=\"ListHeadDetails\">" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dtb_RCProducts.Rows[i]["XPD_FaterBarCode"].ToString())) + "</td>";
                string s_Price = base.FormatNumber1(Dtb_RCProducts.Rows[i]["XPD_Price"].ToString(), 3);
                if (i > 0)
                {
                    if (s_Price != base.FormatNumber1(Dtb_RCProducts.Rows[i - 1]["XPD_Price"].ToString(), 3))
                    {
                        s_Price = "<font color=red>" + s_Price + "</font>";
                    }
                }
                s_ProductsRC += "<td class=\"ListHeadDetails\">" + s_Price + "</td>";
                s_ProductsRC += "<td class=\"ListHeadDetails\">" + base.FormatNumber1(Dtb_RCProducts.Rows[i]["XPD_Number"].ToString(), 3) + "</td>";
                string s_order = Dtb_RCProducts.Rows[i]["XPD_IsOrder"] == null ? "否" : Dtb_RCProducts.Rows[i]["XPD_IsOrder"].ToString();
                s_ProductsRC += "<td class=\"ListHeadDetails\">" + s_order + "</td>";

                s_ProductsRC += "</tr>";
            }
            this.Tbx_RCNum.Text = Dtb_RCProducts.Rows.Count.ToString();
        }
        Lbl_ProductsRC.Text = s_ProductsRC;
        string s_CustomerValue = "", s_ProductsID = "";
        this.ProductsStockAlert.Text = model.ProductsStockAlert.ToString();
        this.ProductsDescription.Text = KNetPage.KHtmlDiscode(model.ProductsDescription);
        this.ProductsDetailDescription.Text = KNetPage.KHtmlDiscode(model.ProductsDetailDescription);
        KNet.BLL.Xs_Customer_Products BLL_Customer_Products = new KNet.BLL.Xs_Customer_Products();
        DataSet Dts_Customer_Products = BLL_Customer_Products.GetList(" XCP_ProductsID='" + model.ProductsBarCode + "'");
        if (Dts_Customer_Products.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Customer_Products.Tables[0].Rows.Count; i++)
            {
                s_CustomerValue += Dts_Customer_Products.Tables[0].Rows[i]["XCP_CustomerID"].ToString() + ",";

                s_MyTable_Detail += "<tr>";
                if (Button4.Visible)
                {
                    s_MyTable_Detail += "<td class='ListHeadDetails'><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                }
                else
                {
                    s_MyTable_Detail += "<td class='ListHeadDetails'>&nbsp;</td>";
                }
                s_MyTable_Detail += "<td class='ListHeadDetails'><input type=\"hidden\" input Name=\"CustomerValue\" value='" + Dts_Customer_Products.Tables[0].Rows[i]["XCP_CustomerID"].ToString() + "'>" + Dts_Customer_Products.Tables[0].Rows[i]["XCP_CustomerID"].ToString() + "</td>";
                s_MyTable_Detail += "<td class='ListHeadDetails'><input type=\"hidden\" input Name=\"CustomerName\" value='" + base.Base_GetCustomerName(Dts_Customer_Products.Tables[0].Rows[i]["XCP_CustomerID"].ToString()) + "'>" + base.Base_GetCustomerName(Dts_Customer_Products.Tables[0].Rows[i]["XCP_CustomerID"].ToString()) + "</td>";
                s_MyTable_Detail += "</tr>";
            }

        }
        this.Xs_ClientID.Text = s_CustomerValue;

        //可替代物料
        KNet.BLL.Products_Replace_List BLL_Replace = new KNet.BLL.Products_Replace_List();
        DataSet Dts_Replace = BLL_Replace.GetList(" PRL_ProductsCode='" + model.ProductsBarCode + "'");
        DataTable Dtb_Replace = Dts_Replace.Tables[0];
        if (Dtb_Replace.Rows.Count > 0)
        {
            s_ProductsID = "";
            for (int i = 0; i < Dtb_Replace.Rows.Count; i++)
            {
                s_ProductsID += Dtb_Replace.Rows[i]["PRL_ProductsCode"].ToString() + ",";
                s_AlternativeDetail += "<tr><td class='ListHeadDetails'><A onclick=\"deleteAlternativeRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td><td class='ListHeadDetails'><input type=\"hidden\" input Name=\"AlternativeProdoctsBarCode_" + i.ToString() + "\" value='" + Dtb_Replace.Rows[i]["PRL_ProductsCode"].ToString() + "'>" + base.Base_GetProdutsName(Dtb_Replace.Rows[i]["PRL_ProductsCode"].ToString()) + "</td>";
                s_AlternativeDetail += "<td class='ListHeadDetails'>" + base.Base_GetProductsEdition_Link(Dtb_Replace.Rows[i]["PRL_ReplaceProductsBarCode"].ToString()) + "</td>";
                s_AlternativeDetail += "<td class='ListHeadDetails'><input type=\"input\"  Name=\"AlternativePriority_" + i.ToString() + "\" value='" + Dtb_Replace.Rows[i]["PRL_AlternativePriority"].ToString() + "'></td>";

                string s_Check = "";
                if (Dtb_Replace.Rows[i]["PRL_AlternativeOlny"].ToString() == "1")
                {
                    s_Check = "Checked";
                }

                s_AlternativeDetail += "<td class='ListHeadDetails'><input type=\"checkbox\"  Name=\"AlternativeOlny_" + i.ToString() + "\"  " + s_Check + "></td>";
                s_AlternativeDetail += "</tr>";
            }
        }
        this.Products_AlternativeID.Text = s_ProductsID;
        this.Products_AlternativeNum.Text = Dtb_Replace.Rows.Count.ToString();

        //Bom 如果是01
        if ((model.KSP_Code.IndexOf("01") == 0) || (model.KSP_Code.IndexOf("03") == 0))
        {
            KNet.BLL.Xs_Products_Prodocts BLL_Products_Products = new KNet.BLL.Xs_Products_Prodocts();
            KNet.BLL.PB_Basic_ProductsClass BLL_Basic_ProductsClass = new KNet.BLL.PB_Basic_ProductsClass();
            string s_DemoProductsID = "";
            AdminloginMess AM = new AdminloginMess();
            string s_Where1 = " and XPD_FaterBarCode='" + model.ProductsBarCode + "' ";
            if ((AM.KNet_StaffDepart == "129652784259578018") || (AM.KNet_StaffName == "项洲"))//如果是
            {
                s_Where1 += " and  b.KSP_Del=0 ";
            }
            string s_Sql = "Select * from Xs_Products_Prodocts_Demo a join KNET_Sys_Products b on a.XPD_ProductsBarCode=b.ProductsBarCode";
            s_Sql += " join PB_Basic_ProductsClass c on b.ProductsType=c.PBP_ID where 1=1 ";
            this.BeginQuery(s_Sql + s_Where1 + "  order by c.PBP_Name,ProductsEdition");

            DataSet Dts_DemoProducts = (DataSet)this.QueryForDataSet();
            DataTable Dtb_DemoProducts = Dts_DemoProducts.Tables[0];
            if (Dtb_DemoProducts.Rows.Count > 0)
            {

                for (int i = 0; i < Dtb_DemoProducts.Rows.Count; i++)
                {
                    s_DemoProductsID += Dtb_DemoProducts.Rows[i]["XPD_ProductsBarCode"].ToString() + ",";
                    s_ProductsTable_BomDetail += "<tr>\n";
                    s_ProductsTable_BomDetail += "<td class='ListHeadDetails'><input type=\"hidden\" class=\"detailedViewTextBox\"  Name=\"DemoID_" + i.ToString() + "\" value=" + Dtb_DemoProducts.Rows[i]["XPD_ID"].ToString() + "><input type=\"input\" class=\"detailedViewTextBox\"  Name=\"DemoOrder_" + i.ToString() + "\" stlye=\"width:50px\" value='" + Convert.ToString(i + 1) + "' style=\"width:30px\" ></td>\n";
                    s_ProductsTable_BomDetail += "<td class='ListHeadDetails'>" + BLL_Basic_ProductsClass.GetProductsName(Dtb_DemoProducts.Rows[i]["PBP_ID"].ToString()) + "";
                    s_ProductsTable_BomDetail += "</td>\n";
                    s_ProductsTable_BomDetail += "<td class='ListHeadDetails'>";
                    s_ProductsTable_BomDetail += "<A onclick=\"deleteRow2(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>\n";
                    s_ProductsTable_BomDetail += "<td class='ListHeadDetails' width=\"100px\"><input type=\"hidden\"  Name=\"DemoRepacleProdoctsBarCode_" + i.ToString() + "\" value='" + Dtb_DemoProducts.Rows[i]["XPD_ReplaceProductsBarCode"].ToString() + "'><input type=\"hidden\"  Name=\"DemoProdoctsBarCode_" + i.ToString() + "\" value='" + Dtb_DemoProducts.Rows[i]["XPD_ProductsBarCode"].ToString() + "'><input type=\"input\"  readonly=\"true\"  Name=\"ProductsName_" + i.ToString() + "\" value='" + base.Base_GetProdutsName(Dtb_DemoProducts.Rows[i]["XPD_ProductsBarCode"].ToString()) + "'></td>\n";
                    s_ProductsTable_BomDetail += "<td class='ListHeadDetails'><input type=\"input\"  readonly=\"true\" style=\"width:300px\"  Name=\"ProductsEdition_" + i.ToString() + "\" value='" + base.Base_GetProductsEdition(Dtb_DemoProducts.Rows[i]["XPD_ProductsBarCode"].ToString()) + "'></td>\n";

                    s_ProductsTable_BomDetail += "<td class='ListHeadDetails'><input type=\"input\" class=\"detailedViewTextBox\" Name=\"Place_" + i.ToString() + "\"  style=\"width:350px\"  value='" + Dtb_DemoProducts.Rows[i]["XPD_Place"].ToString() + "'></td>\n";

                    s_ProductsTable_BomDetail += "<td class='ListHeadDetails'><input type=\"input\" class=\"detailedViewTextBox\" Name=\"DemoNumber_" + i.ToString() + "\" value='" + Dtb_DemoProducts.Rows[i]["XPD_Number"].ToString() + "'></td>\n";

                    string s_Check1 = "";
                    if (Dtb_DemoProducts.Rows[i]["XPD_Del"].ToString() == "1")
                    {
                        s_Check1 = "Checked";
                    }
                    //onclick=\"ChangeOnly('" + i.ToString() + "')
                    s_ProductsTable_BomDetail += "<td class='ListHeadDetails'><input type=\"checkbox\"  Name=\"DemoDel_" + i.ToString() + "\"   " + s_Check1 + "></td>\n";

                    string s_Check = "";
                    if (Dtb_DemoProducts.Rows[i]["XPD_Only"].ToString() == "1")
                    {
                        s_Check = "Checked";
                    }
                    //onclick=\"ChangeOnly('" + i.ToString() + "')
                    s_ProductsTable_BomDetail += "<td class='ListHeadDetails'><input type=\"checkbox\"  Name=\"DemoOnly_" + i.ToString() + "\"   " + s_Check + "></td>\n";

                    s_ProductsTable_BomDetail += "</tr>\n";
                }
            }
            this.Lbl_Bom.Text = s_ProductsTable_BomDetail;
            this.Products_BomID.Text = s_DemoProductsID;
            this.Products_BomNum.Text = Dtb_DemoProducts.Rows.Count.ToString();

        }

        KNet.BLL.PB_Products_CgDays BLL_CgDays = new KNet.BLL.PB_Products_CgDays();
        DataSet Dts_CgDays = BLL_CgDays.GetList(" PPC_ProductsBarCode='" + model.ProductsBarCode + "' ");
        DataTable Dtb_CgDays = Dts_CgDays.Tables[0];
        if (Dtb_CgDays.Rows.Count > 0)
        {

            for (int i = 0; i < Dtb_CgDays.Rows.Count; i++)
            {
                s_Cgdays += "<tr><td class='ListHeadDetails'><A onclick=\"deleteRowCgDay(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                s_Cgdays += "<td class='ListHeadDetails'><input  type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style=\"width:70px;\"  Name=\"Min_" + i.ToString() + "\"  Value=" + Dtb_CgDays.Rows[i]["PPC_Min"].ToString() + " /></td>";
                s_Cgdays += "<td class='ListHeadDetails'><input  type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style=\"width:70px;\"  Name=\"Max_" + i.ToString() + "\"  Value=" + Dtb_CgDays.Rows[i]["PPC_Max"].ToString() + " /></td>";
                s_Cgdays += "<td class='ListHeadDetails'><input  type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style=\"width:70px;\"  Name=\"day_" + i.ToString() + "\"  Value=" + Dtb_CgDays.Rows[i]["PPC_Days"].ToString() + " /></td>";
                s_Cgdays += "</tr>";
            }
        }
        this.Tbx_NumCgDay.Text = Dtb_CgDays.Rows.Count.ToString();

    }




    [Ajax.AjaxMethod()]
    public string GetRepalceProducts(string s_ProductsBarCode)
    {
        string s_Return = "";
        string s_Sql = "Select b.ProductsType,b.ProductsBarCode,PRL_ReplaceProductsBarCode,b.ProductsName,b.ProductsEdition from Products_Replace_List a ";
        s_Sql += " join KNET_Sys_Products b on a.PRL_ProductsCode=b.ProductsBarCode ";
        s_Sql += " where PRL_ProductsCode ='" + s_ProductsBarCode + "'";
        s_Sql += " union all Select b.ProductsType,b.ProductsBarCode,PRL_ProductsCode,b.ProductsName,b.ProductsEdition from Products_Replace_List a ";
        s_Sql += " join KNET_Sys_Products b on a.PRL_ReplaceProductsBarCode=b.ProductsBarCode ";
        s_Sql += " where PRL_ReplaceProductsBarCode ='" + s_ProductsBarCode + "'";


        KNet.BLL.PB_Basic_ProductsClass BLL_Basic_ProductsClass = new KNet.BLL.PB_Basic_ProductsClass();
        this.BeginQuery(s_Sql);
        DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
        for (int i = 0; i < Dtb_Table.Rows.Count; i++)
        {
            s_Return += Dtb_Table.Rows[i]["ProductsType"].ToString();
            s_Return += "," + BLL_Basic_ProductsClass.GetProductsName(Dtb_Table.Rows[i]["ProductsType"].ToString());
            s_Return += "," + Dtb_Table.Rows[i]["ProductsBarCode"].ToString();
            s_Return += "," + Dtb_Table.Rows[i]["PRL_ReplaceProductsBarCode"].ToString();
            s_Return += "," + base.Base_GetProdutsName(Dtb_Table.Rows[i]["PRL_ReplaceProductsBarCode"].ToString());
            s_Return += "," + base.Base_GetProductsEdition(Dtb_Table.Rows[i]["PRL_ReplaceProductsBarCode"].ToString()) + "|";
        }
        return s_Return;
    }
    [Ajax.AjaxMethod()]
    public string GetProductsPattern(string s_ProductsPattern, string s_ProductsType)
    {
        string s_Return = "";
        try
        {
            this.BeginQuery("Select Max(ProductsPattern) as ProductsPattern from KNet_Sys_Products where ProductsPattern like '%" + s_ProductsPattern + "%' and ProductsType='" + s_ProductsType + "' ");
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                s_Return = Dtb_Result.Rows[0][0].ToString();
                if (s_Return == "")
                {
                    s_Return = s_ProductsPattern + "01";
                }
                else
                {
                    string s_Code = "1" + s_Return.Substring(s_Return.Length - 2, 2);
                    s_Code = Convert.ToString(int.Parse(s_Code) + 1);
                    s_Return = s_Return.Substring(0, s_Return.Length - 2);
                    s_Return += s_Code.Substring(1, s_Code.Length - 1);
                }
            }
            else
            {
                s_Return = s_ProductsPattern + "01";
            }
            return s_Return;
        }
        catch
        {
            return s_Return;
        }
    }
}

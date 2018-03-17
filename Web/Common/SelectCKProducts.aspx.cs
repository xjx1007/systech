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
using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;


public partial class Web_Common_SelectCKProducts : BasePage
{
    public string s_House = "";
    protected void Page_PreInit(object sender, EventArgs e)
    {
        KNet.DBUtility.AdminloginMess AMLanguage = new KNet.DBUtility.AdminloginMess();
        if (AMLanguage.KNet_Soft_StaffLanguage == 2)
        {
            // 1、默认为简体转繁体，编码为utf-8
            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter);
        }
        else if (AMLanguage.KNet_Soft_StaffLanguage == 1)
        {
            // 2、繁体简体转，编码为utf-8
            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter, LU.Web.ChineseConvertor.CCDirection.T2S);
        }
        else
        { }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = KNet.Common.KNet_Static_BigClass.GetBigInfo();
            string BigNo, CateName;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                BigNo = ds.Tables[0].Rows[i]["BigNo"].ToString();
                CateName = ds.Tables[0].Rows[i]["CateName"].ToString();
                this.BigClass.Items.Add(new ListItem(CateName, BigNo));
            }
            this.BigClass.Value = "129678733470295462";
            this.SmallClass.Disabled = true;
            DataShows();
        }

    }
    private void DataShows()
    {

        string s_Sql = "";
        s_Sql = "Select *";
        s_Sql += " from KNet_Sys_Products a";
        s_Sql += " Where 1=1 ";
        string SqlWhere = "";
        if (this.BigClass.Value != "0")
        {
            SqlWhere = SqlWhere + " and  a.ProductsMainCategory = '" + this.BigClass.Value + "' ";
        }
        if (this.SmallClass.Value != "0")
        {
            SqlWhere = SqlWhere + " and  a.ProductsSmallCategory = '" + this.SmallClass.Value + "' ";
        }

        if (this.SeachKey.Text != "")
        {
            SqlWhere = SqlWhere + " and ( a.ProductsName like '%" + this.SeachKey.Text + "%' or a.ProductsBarCode  like '%" + this.SeachKey.Text + "%' or a.ProductsPattern  like '%" + this.SeachKey.Text + "%' )";
        }
        this.BeginQuery(s_Sql + SqlWhere);
        this.QueryForDataTable();
        this.GridView1.DataSource = this.Dtb_Result;
        this.GridView1.DataKeyNames = new string[] { "ID" };
        this.GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        KNet.BLL.KNet_Sales_OutWareList_Details BLL = new KNet.BLL.KNet_Sales_OutWareList_Details();
  
            string cal = "";
    
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                    TextBox obj2 = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Number");
                    TextBox Price = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Price");
                    TextBox Remarks = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Remarks");
                    TextBox txt_ProductsBarCode = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_ProductsBarCode");
                    KNet.BLL.KNet_Sys_Products BLL_Products = new KNet.BLL.KNet_Sys_Products();
                    KNet.Model.KNet_Sys_Products Model_Products = BLL_Products.GetModelB(txt_ProductsBarCode.Text);
                    if (cb.Checked == true)
                    {
                        KNet.Model.KNet_Sales_OutWareList_Details model = BLL.GetModel(GridView1.DataKeys[i].Value.ToString());
                        if (obj2.Text == "")
                        {
                            Alert("出货数量有问题");
                            return;
                        }
                        if (Price.Text == "")
                        {
                            Alert("出货单价有问题");
                            return;
                        }
                        int ThisWareHouseAmount = int.Parse(obj2.Text.ToString()); //本次出货数量
                        decimal d_Price = decimal.Parse(Price.Text.ToString()); //本次出货数量
                        string s_Remarks = Remarks.Text;
                        if (Request.QueryString["OutWareNo"] != null && Request.QueryString["OutWareNo"] != "")
                        {
                            string OutWareNo = Request.QueryString["OutWareNo"].ToString();
                            //添加发货明细 记录
                            this.AddToKNet_Sales_BaoPriceList_Details(OutWareNo, Model_Products.ProductsName, Model_Products.ProductsBarCode, Model_Products.ProductsPattern, Model_Products.ProductsUnits, ThisWareHouseAmount, 0, 0, 0, decimal.Parse(Price.Text), 0, decimal.Parse(Price.Text) * ThisWareHouseAmount, s_Remarks);

                        }
                        else if (Request.QueryString["ReturnNo"] != null && Request.QueryString["ReturnNo"] != "")
                        {
                            string ReturnNo = Request.QueryString["ReturnNo"].ToString();
                            this.AddToKNet_Return(ReturnNo, Model_Products.ProductsName, Model_Products.ProductsBarCode, Model_Products.ProductsPattern, Model_Products.ProductsUnits, ThisWareHouseAmount, decimal.Parse(Price.Text), 0, decimal.Parse(Price.Text) * ThisWareHouseAmount, decimal.Parse(Price.Text), 0, decimal.Parse(Price.Text) * ThisWareHouseAmount, "");
                        }
                            cal += GridView1.DataKeys[i].Value.ToString();
                    }
                }
                if (cal == "")
                {
                    Alert("您没有选择要操作的记录!");
                }
                else
                {
                    AdminloginMess LogAM = new AdminloginMess();

                    LogAM.Add_Logs("销售管理--->发货通知--->添加明细记录 操作成功！");

                    StringBuilder s = new StringBuilder();
                    s.Append("<script language=javascript>" + "\n");
                    s.Append("window.opener.refresh();" + "\n");
                    s.Append("window.focus();" + "\n");
                    s.Append("window.opener=null;" + "\n");
                    s.Append("window.close();" + "\n");
                    s.Append("</script>");
                    Type cstype = this.GetType();
                    ClientScriptManager cs = Page.ClientScript;
                    string csname = "ltype";
                    if (!cs.IsStartupScriptRegistered(cstype, csname))
                        cs.RegisterStartupScript(cstype, csname, s.ToString());
                }
    }
     /// <summary>
    /// 添加到明细记录 （Y）暂不用到
    /// </summary>
    /// <param name="ContractNo"></param>
    /// <param name="ProductsName"></param>
    /// <param name="ProductsBarCode"></param>
    /// <param name="ProductsPattern"></param>
    /// <param name="ProductsUnits"></param>
    /// <param name="ContractAmount"></param>
    /// <param name="ContractUnitPrice"></param>
    /// <param name="ContractDiscount"></param>
    /// <param name="ContractTotalNet"></param>
    /// <param name="Contract_SalesUnitPrice"></param>
    /// <param name="Contract_SalesDiscount"></param>
    /// <param name="Contract_SalesTotalNet"></param>
    /// <param name="ContractRemarks"></param>
    protected void AddToKNet_Sales_BaoPriceList_Details(string OutWareNo, string ProductsName, string ProductsBarCode, string ProductsPattern, string ProductsUnits, int OutWareAmount, decimal OutWareUnitPrice, decimal OutWareDiscount, decimal OutWareTotalNet, decimal OutWare_SalesUnitPrice, decimal OutWare_SalesDiscount, decimal OutWare_SalesTotalNet, string OutWareRemarks)
    {
        KNet.BLL.KNet_Sales_OutWareList_Details BLL = new KNet.BLL.KNet_Sales_OutWareList_Details();
        KNet.Model.KNet_Sales_OutWareList_Details model = new KNet.Model.KNet_Sales_OutWareList_Details();

        model.OutWareNo = OutWareNo;
        model.ProductsName = ProductsName;
        model.ProductsBarCode = ProductsBarCode;
        model.ProductsPattern = ProductsPattern;
        model.ProductsUnits = ProductsUnits;

        model.OutWareAmount = OutWareAmount;

        //成本区
        model.OutWareUnitPrice = OutWareUnitPrice;
        model.OutWareDiscount = OutWareDiscount;
        model.OutWareTotalNet = OutWareTotalNet;

        //销售区
        model.OutWare_SalesUnitPrice = OutWare_SalesUnitPrice;
        model.OutWare_SalesDiscount = OutWare_SalesDiscount;
        model.OutWare_SalesTotalNet = OutWare_SalesTotalNet;

        model.OutWareRemarks = OutWareRemarks;

        try
        {
            if (BLL.Exists(OutWareNo, ProductsBarCode) == false)
            {
                BLL.Add(model);
           
            }
            else
            {
                BLL.UpdateB(model);

            }
        }
        catch { throw; }
    }
    //// <summary>
    //// 出库后更新仓库总账信息
    //// </summary>
    //// <param name="thisWareHouseAmount">出库数量</param>
    //// <param name="thisWareHouseTotalNet"></param>
    //// <param name="thisWareHouseDiscount"></param>
    //// <param name="HouseNo"></param>
    //// <param name="ProductsBarCode"></param>
    ////protected void UpdateKNet_WareHouse_Ownall(int thisWareHouseAmount, decimal thisWareHouseTotalNet, decimal thisWareHouseDiscount, string s_House,string s_ProductsBarCode)
    ////{
    ////    try
    ////    {
    ////        string Dosql = "update KNet_WareHouse_Ownall set WareHouseAmount=WareHouseAmount-" + thisWareHouseAmount + ",ShippedQuantity=ShippedQuantity+" + thisWareHouseAmount + ",WareHouseTotalNet=WareHouseTotalNet-" + thisWareHouseTotalNet + ",WareHouseDiscount=WareHouseDiscount-" + thisWareHouseDiscount + " where  HouseNo='" + s_House + "' and ProductsBarCode='" + s_ProductsBarCode + "' ";
    ////        DbHelperSQL.ExecuteSql(Dosql);
    ////    }
    ////    catch { }
    ////}

    protected void Button1_Click1(object sender, EventArgs e)
    {
        this.DataShows();
    }
    protected void AddToKNet_Return(string ReturnNo, string ProductsName, string ProductsBarCode, string ProductsPattern, string ProductsUnits, int ReturnAmount, decimal ReturnUnitPrice, decimal ReturnDiscount, decimal ReturnTotalNet, decimal Return_SalesUnitPrice, decimal Return_SalesDiscount, decimal Return_SalesTotalNet, string ReturnRemarks)
    {
        KNet.BLL.KNet_Sales_ReturnList_Details BLL = new KNet.BLL.KNet_Sales_ReturnList_Details();
        KNet.Model.KNet_Sales_ReturnList_Details model = new KNet.Model.KNet_Sales_ReturnList_Details();

        model.ReturnNo = ReturnNo;
        model.ProductsName = ProductsName;
        model.ProductsBarCode = ProductsBarCode;
        model.ProductsPattern = ProductsPattern;
        model.ProductsUnits = ProductsUnits;

        model.ReturnAmount = ReturnAmount;

        //成本区
        model.ReturnUnitPrice = ReturnUnitPrice;
        model.ReturnDiscount = ReturnDiscount;
        model.ReturnTotalNet = ReturnTotalNet;

        //销售区
        model.Return_SalesUnitPrice = Return_SalesUnitPrice;
        model.Return_SalesDiscount = Return_SalesDiscount;
        model.Return_SalesTotalNet = Return_SalesTotalNet;

        model.ReturnRemarks = ReturnRemarks;

        try
        {
            if (BLL.Exists(ReturnNo, ProductsBarCode) == false)
            {
                BLL.Add(model);
            }
            else
            {
                BLL.UpdateB(model);
            }
        }
        catch { throw; }
    }
}

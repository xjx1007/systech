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


public partial class Web_Common_SelectReturnDetails : BasePage
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
            s_House = Request.QueryString["House"].ToString();
            if (Request.QueryString["ReturnNo"] != null)
            {
                string s_Sql = "";
                s_Sql = "Select a.ReturnNo,b.ID,b.ProductsName,b.ProductsPattern,b.ProductsUnits,b.ReturnAmount,b.ProductsBarCode,a.ReturnDateTime,a.OutWareNo";
                s_Sql += " from KNet_Sales_ReturnList a join KNet_Sales_ReturnList_Details b on a.ReturnNo=b.ReturnNo";
                s_Sql += " Where a.ReturnNo='" + Request.QueryString["ReturnNo"].ToString() + "'";
                this.BeginQuery(s_Sql);
                this.QueryForDataTable();
                this.GridView1.DataSource = this.Dtb_Result;
                this.GridView1.DataKeyNames = new string[] { "ID" };
                this.GridView1.DataBind();
            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        KNet.BLL.KNet_Sales_ReturnList_Details BLL = new KNet.BLL.KNet_Sales_ReturnList_Details();
        if (Request.QueryString["House"] != null && Request.QueryString["House"] != "")
        {
            string cal = "";
            string MyHouseNo = Request.QueryString["House"].Trim();
            if (Request.QueryString["DirectInNo"] != null && Request.QueryString["DirectInNo"] != "")
            {
                string DirectInNo = Request.QueryString["DirectInNo"].Trim();


                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                    TextBox obj2 = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Number");


                    if (cb.Checked == true)
                    {
                        KNet.Model.KNet_Sales_ReturnList_Details model = BLL.GetModel(GridView1.DataKeys[i].Value.ToString());
                        if (obj2.Text == "")
                        {
                            Alert("出货数量有问题");
                            return;
                        }
                        int ThisWareHouseAmount = int.Parse(obj2.Text.ToString()); //本次出货数量

                        if (model != null && int.Parse(model.ReturnAmount.ToString()) >= 1)
                        {
                            //添加到明细 记录
                            this.AddToKnet_Procure_OrdersList_Details(DirectInNo, model.ProductsName, model.ProductsBarCode, model.ProductsPattern, model.ProductsUnits, ThisWareHouseAmount, decimal.Parse(model.Return_SalesUnitPrice.ToString()), 0, ThisWareHouseAmount * decimal.Parse(model.Return_SalesUnitPrice.ToString()), "", model.ID);

                     
                            cal += GridView1.DataKeys[i].Value.ToString();
                        }
                    }
                }
                if (cal == "")
                {
                    Alert("您没有选择要操作的记录!");
                }
                else
                {
                    AdminloginMess LogAM = new AdminloginMess();

                    LogAM.Add_Logs("销售管理--->退货入库--->添加明细记录 操作成功！");

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
        }
        else
        {
            Response.Write("<script language=javascript>alert('非法参数请求!');this.window.close();</script>");
            Response.End();
        }
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

    /// <summary>
    /// 添加到直接出库  明细记录 
    /// </summary>
    /// <param name="DirectInNo"></param>
    /// <param name="ProductsName"></param>
    /// <param name="ProductsBarCode"></param>
    /// <param name="ProductsPattern"></param>
    /// <param name="ProductsUnits"></param>
    /// <param name="DirectInAmount"></param>
    /// <param name="DirectInUnitPrice"></param>
    /// <param name="DirectInDiscount"></param>
    /// <param name="DirectInTotalNet"></param>
    /// <param name="DirectInRemarks"></param>
    protected void AddToKnet_Procure_OrdersList_Details(string DirectInNo, string ProductsName, string ProductsBarCode, string ProductsPattern, string ProductsUnits, int DirectInAmount, decimal DirectInUnitPrice, decimal DirectInDiscount, decimal DirectInTotalNet, string DirectInRemarks, string OwnallPID)
    {
        KNet.BLL.KNet_WareHouse_DirectInto_Details BLL = new KNet.BLL.KNet_WareHouse_DirectInto_Details();
        KNet.Model.KNet_WareHouse_DirectInto_Details model = new KNet.Model.KNet_WareHouse_DirectInto_Details();

        model.DirectInNo = DirectInNo;
        model.ProductsName = ProductsName;
        model.ProductsBarCode = ProductsBarCode;
        model.ProductsPattern = ProductsPattern;
        model.ProductsUnits = ProductsUnits;

        model.DirectInAmount = DirectInAmount;
        model.DirectInUnitPrice = DirectInUnitPrice;
        model.DirectInDiscount = DirectInDiscount;
        model.DirectInTotalNet = DirectInTotalNet;
        model.DirectInRemarks = DirectInRemarks;

        try
        {
            if (BLL.Exists(DirectInNo, ProductsBarCode) == false)
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

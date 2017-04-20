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

using KNet.DBUtility;
using KNet.Common;
using System.Data.SqlClient;
using System.Text;

public partial class PB_Products_Brand_View : BasePage
{
    public string  s_OrderStyle = "", s_DetailsStyle = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Lbl_Title.Text = "查看产品品牌";
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            try
            {
                ShowInfo(s_ID);
            }
            catch
            { }
        }

    }

    private void ShowInfo(string s_ID)
    {

        KNet.BLL.PB_Products_Brand bll = new KNet.BLL.PB_Products_Brand();
        KNet.Model.PB_Products_Brand model = bll.GetModel(s_ID);
        if (model != null)
        {
            this.Tbx_Name.Text = model.PPB_BrandName;
            this.Tbx_Remarks.Text = model.PPB_Remarks;
            StringBuilder Sb_Details = new StringBuilder();
            KNet.BLL.PB_Products_Brand_Details BLL_BrandDetails = new KNet.BLL.PB_Products_Brand_Details();
            DataSet Dts_BrandDetails = BLL_BrandDetails.GetList(" PPBD_FID='" + model.PPB_ID + "' ");
            DataTable Dtb_BrandDetails = Dts_BrandDetails.Tables[0];
            if (Dtb_BrandDetails.Rows.Count > 0)
            {

                for (int i = 0; i < Dtb_BrandDetails.Rows.Count; i++)
                {
                    Sb_Details.Append("<tr>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dtb_BrandDetails.Rows[i]["PPBD_ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName_Link(Dtb_BrandDetails.Rows[i]["PPBD_ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dtb_BrandDetails.Rows[i]["PPBD_ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + Dtb_BrandDetails.Rows[i]["PPBD_BrandName"].ToString() + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + Dtb_BrandDetails.Rows[i]["PPBD_BZNumber"].ToString() + "</td>");

                    Sb_Details.Append("</tr>");
                }
                this.Lbl_Details.Text = Sb_Details.ToString();
                this.Products_BomNum.Text = Dtb_BrandDetails.Rows.Count.ToString();
            }
        }
    }

}

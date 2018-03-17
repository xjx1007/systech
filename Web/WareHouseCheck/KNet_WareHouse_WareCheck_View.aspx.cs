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


public partial class Web_KNet_WareHouse_WareCheck_View : BasePage
{
    public string s_CustomerValue = "";
    public string s_LinkMan = "";
    public string s_OppID = "";
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看盘点";
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
        }
       
    }

    private void ShowInfo(string s_ID)
    {
     
        try
        {
            KNet.BLL.KNet_WareHouse_WareCheckList bll = new KNet.BLL.KNet_WareHouse_WareCheckList();
            KNet.Model.KNet_WareHouse_WareCheckList model = bll.GetModelB(s_ID);
            this.Tbx_ID.Text = s_ID;
            this.Lbl_Code.Text = model.WareCheckNo;
            this.Lbl_Stime.Text = DateTime.Parse(model.WareCheckDateTime.ToString()).ToShortDateString();
            this.Lbl_Dept.Text = base.Base_GetHouseName(model.HouseNo);
            this.Lbl_Remarks.Text = model.WareCheckRemarks;
            KNet.BLL.KNet_WareHouse_WareCheckList_Details BLL_Details = new KNet.BLL.KNet_WareHouse_WareCheckList_Details();
            DataSet Dts_Details = BLL_Details.GetList(" WareCheckNo='" + model.WareCheckNo + "'");
            if (Dts_Details.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    s_MyTable_Detail += "<tr>";
                    this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WareCheckAmount"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsKCNumberBySql(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString(), " and HouseNo='"+model.HouseNo+"' and DirectInDateTime<'" + model.WareCheckDateTime.ToString() + "'") + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsKCNumberBySql(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString(), " and HouseNo='" + model.HouseNo + "' and DirectInDateTime<='" + model.WareCheckDateTime.ToString() + "'") + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WareCheckTotalNet"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WareCheckRemarks"].ToString() + "&nbsp;</td>";
                    s_MyTable_Detail += "</tr>";
                }

            }

        }
        catch
        {}
    }

}

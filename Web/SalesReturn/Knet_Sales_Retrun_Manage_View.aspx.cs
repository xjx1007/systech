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


public partial class Web_Knet_Sales_Retrun_Manage_View : BasePage
{
    public string s_MyTable_Detail = "", s_OrderStyle = "", s_DetailsStyle = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看退货单信息";
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            if (s_Type == "1")
            {
                s_OrderStyle = "class=\"dvtUnSelectedCell\"";
                s_DetailsStyle = "class=\"dvtSelectedCell\"";
                Pan_Order.Visible = false;
                Pan_Detail.Visible = true;
                Table_Btn.Visible = false;
            }
            else
            {
                s_DetailsStyle = "class=\"dvtUnSelectedCell\"";
                s_OrderStyle = "class=\"dvtSelectedCell\"";
                Pan_Order.Visible = true;
                Pan_Detail.Visible = false;
                Table_Btn.Visible = true;
            }
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
        }
    }

    private void ShowInfo(string s_ID)
    {

        KNet.BLL.KNet_Sales_ReturnList BLL = new KNet.BLL.KNet_Sales_ReturnList();
        KNet.Model.KNet_Sales_ReturnList Model = BLL.GetModelB(s_ID);

        if (s_ID != "")
        {
            this.ReturnNo.Text = Model.ReturnNo;
            try
            {
                this.ReturnDateTime.Text = DateTime.Parse(Model.ReturnDateTime.ToString()).ToShortDateString();
            }
            catch
            { }
            this.CustomerName.Text = base.Base_GetCustomerName_Link(Model.CustomerValue);

            this.Ddl_ReturnType.Text = base.Base_GetBasicCodeName("110", Model.ReturnType);
            KNet.BLL.KNet_Sales_ReturnList_Details BLL_Details = new KNet.BLL.KNet_Sales_ReturnList_Details();
            DataSet Dts_Details = BLL_Details.GetList(" ReturnNo='" + Model.ReturnNo + "'");
            this.Ddl_DutyPerson.Text=base.Base_GetLinMan_Link(Model.ContentPerson);
            this.BeginQuery("select CheckName from KNet_Sys_CheckMethod where CheckNo='" + Model.ReturnPorPay + "'");
           this.ReturnPorPay.Text=this.QueryForReturn();
           ReturnRemarks.Text = Model.ReturnRemarks;


           this.BeginQuery("select Client_Name from KNet_Sales_ClientAppseting where ClientKings='7' and ClientValue='" + Model.ReturnClass + "'");
            this.ReturnClass.Text = this.QueryForReturn();
            if (Dts_Details.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    s_MyTable_Detail += "<tr>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["ReturnAmount"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["ReturnRemarks"].ToString() + "&nbsp;</td>";
                    s_MyTable_Detail += "</tr>";
                }
            }

        }
        else
        {
            Response.Write("<script language=javascript>alert('非法参数！');window.close();</script>");
            Response.End();
        }
    }


}

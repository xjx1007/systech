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

    protected void btn_Chcek_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (btn_Chcek.Text == "审批")
        {


            string DoSql = "update KNet_Sales_ReturnList  set ReturnCheckYN=1,ReturnCheckStaffNo ='" + AM.KNet_StaffNo + "' ,ReturnState=1  where  ReturnNo='" + this.ReturnNo.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "反审批";
            AM.Add_Logs("退货单审核成功，审批成功" + this.ReturnNo.Text);
            AlertAndRedirect("审批成功！", "Knet_Sales_Retrun_Manage_View.aspx?ID=" + this.ReturnNo.Text + "");

            // this.Panel_SCDetails.Visible = true;
        }
        else if (btn_Chcek.Text == "反审批")
        {


            string DoSql = "update KNet_Sales_ReturnList  set ReturnCheckYN=0,ReturnCheckStaffNo ='" + AM.KNet_StaffNo + "' ,ReturnState=0  where  ReturnNo='" + this.ReturnNo.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "反审批";
            AM.Add_Logs("退货单反审核成功，审批成功" + this.ReturnNo.Text);
            AlertAndRedirect("审批成功！", "Knet_Sales_Retrun_Manage_View.aspx?ID=" + this.ReturnNo.Text + "");

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
            this.Ddl_DutyPerson.Text = base.Base_GetLinMan_Link(Model.ContentPerson);
            this.CustomerName.Text = base.Base_GetCustomerName(Model.CustomerValue);
            this.ReturnRemarks.Text = Model.ReturnRemarks;
            this.ReturnPorPay.Text = Base_GetCheckMethod(Model.ReturnPorPay);
            this.Ddl_ReturnType.Text = base.Base_GetBasicCodeName("110", Model.ReturnType);
            if (Model.ReturnCheckYN)
            {
                btn_Chcek.Text = "反审批";
            }
            else
            {

                btn_Chcek.Text = "审批";
            }
            this.Lbl_OutWareNo.Text = "<a href=\"Knet_Sales_Retrun_Manage_View.aspx?ID=" + Model.OutWareNo + "\" target=\"_blank\">" + Model.OutWareNo + "</a>";
            KNet.BLL.KNet_Sales_ReturnList_Details BLL_Details = new KNet.BLL.KNet_Sales_ReturnList_Details();
            DataSet Dts_Details = BLL_Details.GetList(" ReturnNo='" + Model.ReturnNo + "'");
            if (Dts_Details.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    s_MyTable_Detail += "<tr>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName_Link(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["ReturnAmount"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["Return_SalesUnitPrice"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["Return_SalesTotalNet"].ToString() + "</td>";
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

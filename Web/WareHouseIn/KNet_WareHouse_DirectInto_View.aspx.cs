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


public partial class Web_KNet_WareHouse_DirectInto_View : BasePage
{
    public string s_MyTable_Detail = "", s_OrderStyle = "", s_DetailsStyle = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看入库单信息";
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("查看直接入库") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = s_ID;
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

        KNet.BLL.KNet_WareHouse_DirectInto BLL = new KNet.BLL.KNet_WareHouse_DirectInto();
        KNet.Model.KNet_WareHouse_DirectInto Model = BLL.GetModelB(s_ID);

        if (s_ID != "")
        {
            this.ReturnNo.Text=Model.DirectInNo;
            try
            {

                Drop_KD.Text = Model.KWD_KDName;
                this.Tbx_Code.Text = Model.KWD_KDCode;
                this.Tbx_Person.Text = Model.KWD_PersonName;
                this.Tbx_TelPhone.Text = Model.KWD_Telphone;
                this.Tbx_Phone.Text = Model.KWD_Phone;
                this.Tbx_Address.Text = Model.KWD_Address;

                this.ReturnDateTime.Text = DateTime.Parse(Model.DirectInDateTime.ToString()).ToShortDateString();
                this.DirectInSource.Text = Model.DirectInSource;
                this.SuppNoSelectValue.Text = base.Base_GetCustomerName_Link(Model.SuppNo);
                this.HouseNo.Text = base.Base_GetHouseName(Model.HouseNo);
                this.ReturnRemarks.Text = Model.DirectInRemarks;
            }
            catch
            { }

            if (Model.DirectInCheckYN == 1)
            {
                btn_Chcek.Text = "反审批";

            }
            else
            {
                btn_Chcek.Text = "审批";
            }
            KNet.BLL.KNet_WareHouse_DirectInto_Details BLL_Details = new KNet.BLL.KNet_WareHouse_DirectInto_Details();
            DataSet Dts_Details = BLL_Details.GetList(" DirectInNo='" + Model.DirectInNo + "'");
            if (Dts_Details.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    s_MyTable_Detail += "<tr>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName_Link(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["DirectInAmount"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["DirectInunitPrice"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["DirectInTotalNet"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["DirectInRemarks"].ToString() + "&nbsp;</td>";
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

    protected void btn_Chcek_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {

            if (btn_Chcek.Text == "审批")
            {
                string DoSql = "update KNet_WareHouse_DirectInto  set DirectInCheckYN=1  where  DirectInNo='" + this.Tbx_ID.Text + "' ";
                DbHelperSQL.ExecuteSql(DoSql);
                btn_Chcek.Text = "反审批";
                AM.Add_Logs("审批成功" + this.Tbx_ID.Text);
                AlertAndRedirect("审批成功！", "KNet_WareHouse_DirectInto_View.aspx?ID=" + this.Tbx_ID.Text + "");
            }
            else if (btn_Chcek.Text == "反审批")
            {
                string DoSql = "update KNet_WareHouse_DirectInto  set DirectInCheckYN=0  where DirectInNo='" + this.Tbx_ID.Text + "' ";
                DbHelperSQL.ExecuteSql(DoSql);
                btn_Chcek.Text = "审批";
                AM.Add_Logs("反审批成功" + this.Tbx_ID.Text);
                AlertAndRedirect("反审批成功！", "KNet_WareHouse_DirectInto_View.aspx?ID=" + this.Tbx_ID.Text + "");
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }
   
}

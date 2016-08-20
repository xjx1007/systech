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


public partial class Web_KNet_WareHouse_DirectOut_View : BasePage
{
    public string s_CustomerValue = "";
    public string s_LinkMan = "";
    public string s_OppID = "";
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看出库单";
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
            AdminloginMess AM=new AdminloginMess();
            KNet.BLL.KNet_WareHouse_DirectOutList bll = new KNet.BLL.KNet_WareHouse_DirectOutList();
            KNet.Model.KNet_WareHouse_DirectOutList model = bll.GetModelB(s_ID);
            this.Tbx_ID.Text = s_ID;
            this.Lbl_Code.Text = model.DirectOutNo;
            this.Lbl_Stime.Text = DateTime.Parse(model.DirectOutDateTime.ToString()).ToShortDateString();
            this.Lbl_House.Text = base.Base_GetHouseName(model.HouseNo);
            this.Lbl_Customer.Text = base.Base_GetCustomerName_Link(model.KWD_Custmoer);
            this.Lbl_ContentPerson.Text = base.Base_GetLinkManValue(model.KWD_ContentPerson, "XOL_Name") + "（电话：" + base.Base_GetLinkManValue(model.KWD_ContentPerson, "XOL_Phone") + "地址：" + base.Base_GetLinkManValue(model.KWD_ContentPerson, "XOL_Address") + "）";
            this.Lbl_Remarks.Text = model.DirectOutRemarks;
            if (model.DirectOutCheckYN == 3)
            {

                btn_Chcek.Text = "反财务审批";
            }
            else
            {
                if (model.DirectOutCheckYN == 0)
                {

                    btn_Chcek.Text = "审批";
                }
                else
                {
                    btn_Chcek.Text = "反审批";

                    if (AM.YNAuthority("单据财务审批"))
                    {
                        this.btn_Chcek.Text = "财务审批";
                    }
                }
 
            }
            KNet.BLL.KNet_WareHouse_DirectOutList_Details BLL_Details = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
            DataSet Dts_Details = BLL_Details.GetList(" DirectOutNo='" + model.DirectOutNo + "'");
            if (Dts_Details.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    s_MyTable_Detail += "<tr>";
                    this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["DirectOutAmount"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["DirectOutUnitPrice"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["DirectOutTotalNet"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["DirectOutRemarks"].ToString() + "&nbsp;</td>";

                    s_MyTable_Detail += "</tr>";
                }
            }
        }
        catch
        {}
    }

    protected void btn_Chcek_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (btn_Chcek.Text == "财务审批")
        {
            string DoSql = "update KNet_WareHouse_DirectOutList  set DirectOutCheckYN=3,DirectOutCheckStaffNo='"+AM.KNet_StaffNo+"'  where  DirectOutNo='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "反财务审批";
            AM.Add_Logs("审批领料单号：" + this.Tbx_ID.Text);
        }

        else if (btn_Chcek.Text == "反财务审批")
        {
            string DoSql = "update KNet_WareHouse_DirectOutList  set DirectOutCheckYN=1,DirectOutCheckStaffNo='' where  DirectOutNo='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "财务审批";
            AM.Add_Logs("反审批领料单号：" + this.Tbx_ID.Text);
        }
        else if (btn_Chcek.Text == "审批")
        {
            string DoSql = "update KNet_WareHouse_DirectOutList  set DirectOutCheckYN=1,DirectOutCheckStaffNo='" + AM.KNet_StaffNo + "' where  DirectOutNo='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "反审批";
            AM.Add_Logs("反审批领料单号：" + this.Tbx_ID.Text);
        }
        else if (btn_Chcek.Text == "反审批")
        {
            string DoSql = "update KNet_WareHouse_DirectOutList  set DirectOutCheckYN=0,DirectOutCheckStaffNo='' where  DirectOutNo='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "审批";
            AM.Add_Logs("反审批领料单号：" + this.Tbx_ID.Text);
        }
        Alert("审批成功！");
    }
}

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
/// 采购管理-----供应商报价管理---添加
/// </summary>
public partial class Knet_Web_Procure_Knet_Procure_Suppliers_Price_Add : BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                if (s_ID != "")
                {
                    ShowDetails(s_ID);
                    //供应链平台经理
                    if (((AM.KNet_StaffDepart == "129652784259578018") && (AM.KNet_Position == "102")) || (AM.KNet_StaffName == "项洲") || (AM.YNAuthority("采购价格审批") == true))
                    {
                        Btn_Sp.Visible = true;
                        Btn_Sp1.Visible = true;
                    }
                    else
                    {
                        Btn_Sp.Visible = false;
                        Btn_Sp1.Visible = false;
                    }
                }

            }
        }
    }
    private void ShowDetails(string s_ID)
    {
        try
        {
            KNet.BLL.Knet_Procure_SuppliersPrice Bll = new KNet.BLL.Knet_Procure_SuppliersPrice();
            KNet.Model.Knet_Procure_SuppliersPrice Model = Bll.GetModel(s_ID);
            this.Tbx_ID.Text = s_ID;
            this.Tbx_Code.Text = Model.KPP_Code;
            this.Tbx_ProductsEdition.Text = base.Base_GetProductsEdition_Link(Model.ProductsBarCode);
            this.Lbl_SuppName.Text = base.Base_GetSupplierName_Link(Model.SuppNo);
            this.Lbl_MinCg.Text = Model.ProcureMinShu.ToString();
            this.Lbl_UnitPrice.Text = Model.ProcureUnitPrice.ToString();
            this.Lbl_HandPrice.Text = Model.HandPrice.ToString();
            this.Lbl_Creator.Text = base.Base_GetUserName(Model.KPP_Creator);
            this.Lbl_CTime.Text = Model.ProcureUpdateDateTime.ToString();
            this.Lbl_State.Text = base.Base_GetBasicCodeName("131", Model.KPP_Del.ToString());
            this.Lbl_ShState.Text = base.Base_GetBasicCodeName("132", Model.KPP_State.ToString());
            this.Lbl_Shperson.Text = base.Base_GetUserName(Model.KPP_ShPerson);
            this.Lbl_ShTime.Text = Model.KPP_ShTime.ToString();
            this.Lbl_Remarks.Text = KNetPage.KHtmlDiscode(Model.KPP_AllRemarks.ToString());
        }
        catch
        { }
    }


    protected void Btn_SpSave(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        //批量审批
        KNet.BLL.Knet_Procure_SuppliersPrice Bll = new KNet.BLL.Knet_Procure_SuppliersPrice();
        try
        {
            string s_Logs = "";
            string s_ID = this.Tbx_ID.Text;
            KNet.Model.Knet_Procure_SuppliersPrice Model = new KNet.Model.Knet_Procure_SuppliersPrice();
            Model.ID = s_ID;
            Model.KPP_State = 1;
            Model.KPP_ShPerson = AM.KNet_StaffNo;
            Model.KPP_ShTime = DateTime.Now;
            Bll.UpdateState(Model);
            s_Logs = s_ID + ",";
            AM.Add_Logs("审批价格：" + s_Logs + "");
            AlertAndRedirect("审批成功！", "Knet_Procure_Suppliers_Price.aspx?WhereID=M160707014101612");
        }
        catch { }
    }


    protected void Btn_SpSave1(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        //批量审批
        KNet.BLL.Knet_Procure_SuppliersPrice Bll = new KNet.BLL.Knet_Procure_SuppliersPrice();
        try
        {
            string s_Logs = "";
            string s_ID = this.Tbx_ID.Text;
            KNet.Model.Knet_Procure_SuppliersPrice Model = new KNet.Model.Knet_Procure_SuppliersPrice();
            Model.ID = s_ID;
            Model.KPP_State = 2;
            Model.KPP_ShPerson = AM.KNet_StaffNo;
            Model.KPP_ShTime = DateTime.Now;
            Bll.UpdateState(Model);
            s_Logs = s_ID + ",";
            AM.Add_Logs("审批价格：" + s_Logs + "");
            AlertAndRedirect("审批成功！", "Knet_Procure_Suppliers_Price.aspx?WhereID=M160707014101612");
        }
        catch { }
    }
}

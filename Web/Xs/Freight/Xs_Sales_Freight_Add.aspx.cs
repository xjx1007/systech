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
using System.Runtime.Serialization.Json;

using KNet.DBUtility;
using KNet.Common;
using System.Net;

public partial class Xs_Sales_Freight_Add : BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(Xs_Sales_Freight_Add));
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = s_ID;
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            this.Tbx_Type.Text = s_Type;
            string s_FID = Request.QueryString["FID"] == null ? "" : Request.QueryString["FID"].ToString();
            string s_Model = Request.QueryString["Model"] == null ? "" : Request.QueryString["Model"].ToString();
            this.BeginQuery("Select * from PB_Basic_Wl ");
            this.QueryForDataTable();
            this.Drop_KD.DataSource = this.Dtb_Result;
            this.Drop_KD.DataTextField = "PBW_Name";
            this.Drop_KD.DataValueField = "PBW_Code";
            this.Drop_KD.DataBind();
            ListItem item = new ListItem("--请选择--", "-1"); //默认值
            Drop_KD.Items.Insert(0, item);
            this.BeginQuery("select * from Knet_Procure_Suppliers where KPS_Type='128860697896406251'");
            this.QueryForDataTable();
            this.Ddl_FSupp.DataSource = this.Dtb_Result;
            this.Ddl_FSupp.DataTextField = "SuppName";
            this.Ddl_FSupp.DataValueField = "SuppNo";
            this.Ddl_FSupp.DataBind();
            ListItem item1 = new ListItem("--请选择--", ""); //默认值
            Ddl_FSupp.Items.Insert(0, item);
            if (s_Model == "1")
            {
                if (s_FID != "")
                {
                    this.Tbx_FID.Text = s_FID;
                    KNet.BLL.Xs_Sales_Freight Bll_Freight = new KNet.BLL.Xs_Sales_Freight();
                    if (Bll_Freight.ExistsFID(s_FID))
                    {
                        AlertAndGoBack("已有相关运费，请勿重复添加！");
                    }
                    else{
                          KNet.BLL.KNet_WareHouse_DirectOutList Bll = new KNet.BLL.KNet_WareHouse_DirectOutList();
                    KNet.Model.KNet_WareHouse_DirectOutList Model = Bll.GetModelB(s_FID);
                    if (Model != null)
                    {
                        string s_TotalMoney=base.Base_GetShipDetailNumbers(s_FID);
                        KNet.BLL.KNet_Sys_WareHouse Bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                        KNet.Model.KNet_Sys_WareHouse Model_WareHouse = Bll_WareHouse.GetModel(Model.HouseNo);
                        if(Model_WareHouse!=null)
                        {
                            this.Tbx_CustomerValue.Text = Model_WareHouse.SuppNo;
                            this.Tbx_CustomerName.Text = base.Base_GetSupplierName(Model_WareHouse.SuppNo);
                        }
                        this.Tbx_TotalNumber.Text = s_TotalMoney;
                        this.Tbx_FMoney.Text = Convert.ToString(float.Parse(s_TotalMoney) * 0.15);
                        this.Tbx_Address.Text = Model.KWD_Address;
                    }

                    }
                  
                }
            }
            base.Base_DropBasicCodeBind(this.Ddl_Type, "755");
            base.Base_DropBindFlow(this.Ddl_Flow, "107");
            this.Tbx_Stime.Text = DateTime.Now.ToShortDateString();
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制运费承担";
                }
                else
                {
                    this.Lbl_Title.Text = "修改运费承担";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增运费承担";
                this.Tbx_Code.Text = base.GetNewID("Xs_Sales_Freight", 0);
            }
            //this.Lbl_Title.Text
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
        }

    }
    /// <summary>
    /// 修改显示
    /// </summary>
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Xs_Sales_Freight bll = new KNet.BLL.Xs_Sales_Freight();
        KNet.Model.Xs_Sales_Freight model = bll.GetModel(s_ID);
        this.Tbx_ID.Text = model.XSF_ID;
        this.Tbx_Code.Text = model.XSF_Code;
        this.Tbx_FID.Text = model.XSF_FID;
        this.Tbx_Stime.Text = DateTime.Parse(model.XSF_Stime.ToString()).ToShortDateString();
        this.Tbx_Description.Text = model.XSF_Description;
        this.Ddl_Type.SelectedValue = model.XSF_Type;
        this.Tbx_CustomerValue.Text = model.XSF_CustomerValue;
        this.Tbx_CustomerName.Text = model.XSF_CustomerName;
        this.Tbx_FPercent.Text = model.XSF_FPercent.ToString();
        this.Tbx_FMoney.Text = model.XSF_FMoney.ToString();
        this.Tbx_Percent.Text = model.XSF_Percent.ToString();
        this.Tbx_Money.Text = model.XSF_Money.ToString();
        this.Tbx_TotalMoney.Text = model.XSF_TotalMoney.ToString();
        this.Tbx_TotalNumber.Text = model.XSF_TotalNumber.ToString();
        this.Tbx_Price.Text = model.XSF_Price.ToString();
        this.Tbx_Remarks.Text = model.XSF_Remarks;
        this.Ddl_Flow.SelectedValue = model.XSF_Flow;
        this.Tbx_Address.Text = model.XSF_Address;

        this.Drop_KD.SelectedValue = model.XSF_KDNameCode;
        this.Tbx_KDCode.Text = model.XSF_KDCode;
        this.Tbx_Address.Text = model.XSF_Address;
        try
        {

            Ddl_FSupp.ClearSelection();
            if (model.XSF_FSuppNo != "-1")
            {
                this.Ddl_FSupp.SelectedValue = model.XSF_FSuppNo;
            }
        }
        catch
        { }
    }

    /// <summary>
    /// 赋值
    /// </summary>
    private bool SetValue(KNet.Model.Xs_Sales_Freight model)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.XSF_ID = GetMainID();
            }
            else
            {
                model.XSF_ID = this.Tbx_ID.Text;
            }
            if (this.Tbx_ID.Text == "")
            {
                model.XSF_Code = base.GetNewID("XSF_Code", 1);
            }
            else
            {
                model.XSF_Code = this.Tbx_Code.Text;
            }
            model.XSF_FID = this.Tbx_FID.Text.ToString();
            try
            {
                model.XSF_Stime = DateTime.Parse(this.Tbx_Stime.Text);
            }
            catch { }
            model.XSF_Description = this.Tbx_Description.Text.ToString();
            model.XSF_Type = this.Ddl_Type.SelectedValue.ToString();
            model.XSF_CustomerValue = this.Tbx_CustomerValue.Text.ToString();
            model.XSF_CustomerName = this.Tbx_CustomerName.Text.ToString();
            try
            {
                model.XSF_FPercent = decimal.Parse(Request["Tbx_FPercent"].ToString());
              }
            catch { }
            try
            {
                model.XSF_FMoney = decimal.Parse(Request["Tbx_FMoney"].ToString());
            }
            catch { }
            try
            {
                model.XSF_Percent = decimal.Parse(Request["Tbx_Percent"].ToString());
            }
            catch { }
            try
            {
                model.XSF_Money = decimal.Parse(Request["Tbx_Money"].ToString());
            }
            catch { }
            try
            {
                model.XSF_TotalMoney = decimal.Parse(Request["Tbx_TotalMoney"].ToString());
            }
            catch { }
            try
            {
                model.XSF_TotalNumber = int.Parse(Request["Tbx_TotalNumber"].ToString());
            }
            catch { }

            try
            {
                model.XSF_Price = decimal.Parse(Request["Tbx_Price"].ToString());
            }
            catch { }
            model.XSF_Remarks = this.Tbx_Remarks.Text.ToString();
            model.XSF_Flow = this.Ddl_Flow.SelectedValue.ToString();
            model.XSF_Del = 0;
            model.XSF_CTime = DateTime.Now;
            model.XSF_Creator = AM.KNet_StaffNo;
            model.XSF_MTime = DateTime.Now;
            model.XSF_Mender = AM.KNet_StaffNo;
            model.XSF_KDCode = this.Tbx_KDCode.Text;
            model.XSF_KDName = this.Drop_KD.SelectedItem.Text;
            model.XSF_KDNameCode = this.Drop_KD.SelectedValue;
            model.XSF_Address = this.Tbx_Address.Text;
            model.XSF_FSuppNo = this.Ddl_FSupp.SelectedValue;
            return true;
        }
        catch
        {
            return false;
        }
    }
    /// <summary>
    /// 保存
    /// </summary>
    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.Xs_Sales_Freight model = new KNet.Model.Xs_Sales_Freight();
        KNet.BLL.Xs_Sales_Freight bll = new KNet.BLL.Xs_Sales_Freight();
        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (this.Tbx_ID.Text != "")//修改
        {
            try
            {
                if (bll.Update(model))
                {
                    AM.Add_Logs("运费承担修改" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改成功！", "Xs_Sales_Freight_List.aspx");
                }
                else
                {
                    AM.Add_Logs("运费承担修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "Xs_Sales_Freight_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            catch { }
        }
        else
        {
            try
            {
                if (bll.Add(model))
                {
                    AM.Add_Logs("运费承担增加" + model.XSF_ID);
                    base.Base_SendMessage(base.Base_GetDeptPerson("研发中心", 1), KNetPage.KHtmlEncode("有 运费承担 <a href='Web/Freight/Xs_Sales_Freight_View.aspx?ID=" + model.XSF_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + this.Tbx_Code.Text + "</a> 需要您作为负责人选择审批流程，敬请关注！"));
                    AlertAndRedirect("新增成功！", "Xs_Sales_Freight_List.aspx");
                }
                else
                {
                    this.Tbx_ID.Text = "";
                    AM.Add_Logs("运费承担新增失败" + model.XSF_ID);
                    AlertAndRedirect("新增失败！", "Xs_Sales_Freight_List.aspx");
                }
            }
            catch(Exception ex) { }
        }
    }
    [Ajax.AjaxMethod()]
    public string GetKDCode(string s_SuppNo)
    {
        string s_Return = "";
        try
        {
            this.BeginQuery("Select KPS_KDCode from Knet_Procure_Suppliers where SuppNo='" + s_SuppNo + "'");
            s_Return = this.QueryForReturn();
        }
        catch { }
        return s_Return;
    }


}

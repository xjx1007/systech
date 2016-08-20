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


public partial class Cw_Material_MoneyChange_Add : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Cw_Material_MoneyChange_Add));
        AdminloginMess AM = new AdminloginMess();
        if (!Page.IsPostBack)
        {
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_CheckNo = Request.QueryString["CheckNo"] == null ? "" : Request.QueryString["CheckNo"].ToString();
            this.Tbx_FID.Text = s_CheckNo;
            this.Tbx_STime.Text = DateTime.Now.ToShortDateString();
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";

                    this.Tbx_Code.Text = base.GetNewID("Cw_Material_MoneyChange", 0);
                    this.Lbl_Title.Text = "复制原材料调整单";
                }
                else
                {
                    this.Lbl_Title.Text = "修改原材料调整单";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增原材料调整单";
                this.Tbx_Code.Text = base.GetNewID("Cw_Material_MoneyChange", 0);
            }
        }
    }




    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Cw_Material_MoneyChange bll = new KNet.BLL.Cw_Material_MoneyChange();
        KNet.Model.Cw_Material_MoneyChange model = bll.GetModel(s_ID);
        try
        {
            this.Tbx_ID.Text = s_ID;
            this.Tbx_Code.Text = model.CMM_Code;
            this.Tbx_FID.Text = model.CMM_FID;
            try
            {
                this.Tbx_STime.Text = DateTime.Parse(model.CMM_STime.ToString()).ToShortDateString();
            }
            catch
            { }
            this.Tbx_Money.Text = model.CMM_Money.ToString();
            this.Tbx_Remarks.Text = model.CMM_Remarks;

        }
        catch (Exception ex)
        { }
    }
    private bool SetValue(KNet.Model.Cw_Material_MoneyChange model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.CMM_ID = GetMainID();
                model.CMM_Code = base.GetNewID("Cw_Material_MoneyChange", 1);
            }
            else
            {
                model.CMM_ID = this.Tbx_ID.Text;
                model.CMM_Code = this.Tbx_Code.Text;
            }
            try
            {
                model.CMM_STime = DateTime.Parse(this.Tbx_STime.Text);
            }
            catch
            {
                model.CMM_STime = DateTime.Now;
            }
            model.CMM_FID = this.Tbx_FID.Text;
            model.CMM_Money = decimal.Parse(this.Tbx_Money.Text);
            model.CMM_Remarks = this.Tbx_Remarks.Text;
            model.CMM_CTime = DateTime.Now;
            model.CMM_Creator = AM.KNet_StaffNo;
            model.CMM_MTime = DateTime.Now;
            model.CMM_Mender = AM.KNet_StaffNo;

            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_ID = this.Tbx_ID.Text;

        KNet.Model.Cw_Material_MoneyChange model = new KNet.Model.Cw_Material_MoneyChange();
        KNet.BLL.Cw_Material_MoneyChange bll = new KNet.BLL.Cw_Material_MoneyChange();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (s_ID == "")//新增
        {
            try
            {
                bll.Add(model);
                AM.Add_Logs("原材料调整单增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "Cw_Material_MoneyChange_List.aspx");
            }
            catch { }
        }
        else
        {

            try
            {
                bll.Update(model);
                AM.Add_Logs("原材料调整单修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "Cw_Material_MoneyChange_List.aspx");
            }
            catch(Exception ex) { }
        }
    }
}

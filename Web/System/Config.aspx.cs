using System;
using System.Data;
using System.Data.SqlClient;
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

/// <summary>
/// 基本设置
/// </summary>
public partial class Knet_Web_System_Config : System.Web.UI.Page
{
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

    SoftReg SR = new SoftReg();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            //系统参数设置
            if (AM.YNAuthority("系统参数设置") == false)
            {
                this.Button1.Enabled = false;
            }

          

            this.ShowInfo(1);

            if (AM.BsysGo() == true)
            {
                this.ImageCodeNo.ImageUrl = "../../images/VV1.gif";
                this.ImageCodeKey.ImageUrl = "../../images/MM2.gif";
            }
            else
            {
                this.ImageCodeNo.ImageUrl = "../../images/VV2.gif";
                this.ImageCodeKey.ImageUrl = "../../images/MM1.gif";
            }
            this.RegToSystem.Text = SR.GetCpuInfo().ToUpper(); //CPU系列号
        }
    }
    /// <summary>
    /// 确认基本配置 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {

        //演示控制代码
        AdminloginMess LogAM = new AdminloginMess();

        string Sys_CompanyName = KNetPage.KHtmlEncode(this.CompanyName1.Text.ToString());
        string Sys_NoticeContent = this.NoticeContent1.Text.Trim();


        string Sys_UserNo = this.Sys_UserNo.Text.Trim();
        string Sys_Key = this.CodeKey1.Text.Trim();

        bool Sys_LogsYN = true;

        if (int.Parse(this.LogsYN1.SelectedValue.ToString()) == 1)
        {
            Sys_LogsYN = true;
        }
        else
        {
            Sys_LogsYN = false;
        }


        bool Sys_NoticeYN = true;
        if (int.Parse(this.NoticeYN1.SelectedValue.ToString()) == 1)
        {
            Sys_NoticeYN = true;
        }
        else
        {
            Sys_NoticeYN = false;
        }

        bool Sys_OutWarning = true;
        if (int.Parse(this.OutYN1.SelectedValue.ToString()) == 1)
        {
            Sys_OutWarning = true;
        }
        else
        {
            Sys_OutWarning = false;
        }

        KNet.Model.KNet_Sys_Config model = new KNet.Model.KNet_Sys_Config();

        model.Sys_CompanyName = Sys_CompanyName;
        model.Sys_NoticeYN = Sys_NoticeYN;
        model.Sys_NoticeContent = Sys_NoticeContent;
        model.Sys_LogsYN = Sys_LogsYN;
        model.Sys_Key = Sys_Key;
        model.Sys_UserNo = Sys_UserNo;

        model.Sys_OutWarning = Sys_OutWarning;
        model.ID = 1;

        KNet.BLL.KNet_Sys_Config bll = new KNet.BLL.KNet_Sys_Config();
        try
        {
            bll.Update(model);
            LogAM.Add_Logs("系统管理--->系统设置更新 操作成功！");

            Response.Write("<script>alert('基本配置 更新 成功！');location.href='" + Request.Url.ToString() + "';</script>");
            Response.End();
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 绑定数据
    /// </summary>
    /// <param name="ID"></param>
    protected void ShowInfo(int ID)
    {
        KNet.BLL.KNet_Sys_Config bll = new KNet.BLL.KNet_Sys_Config();
        KNet.Model.KNet_Sys_Config model = bll.GetModel(ID);

        this.CompanyName1.Text = model.Sys_CompanyName;
        this.NoticeContent1.Text = model.Sys_NoticeContent;

  

        this.Sys_UserNo.Text = model.Sys_UserNo;
        this.CodeKey1.Text = model.Sys_Key;

        if (model.Sys_LogsYN == true)
        {
            this.LogsYN1.Items[0].Selected = true;

        }
        else
        {
            this.LogsYN1.Items[1].Selected = true;
        }

        if (model.Sys_NoticeYN == true)
        {
            this.NoticeYN1.Items[0].Selected = true;

        }
        else
        {
            this.NoticeYN1.Items[1].Selected = true;
        }

        if (model.Sys_OutWarning == true)
        {
            this.OutYN1.Items[0].Selected = true;

        }
        else
        {
            this.OutYN1.Items[1].Selected = true;
        }
    }
}

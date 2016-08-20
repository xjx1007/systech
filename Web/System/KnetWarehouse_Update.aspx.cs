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
/// 仓库管理
/// </summary>
public partial class Knet_Web_System_KnetWarehouse_Update : System.Web.UI.Page
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("修改仓库设置") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }

            KNet.BLL.KNet_Sys_WareHouse BLL = new KNet.BLL.KNet_Sys_WareHouse();

            if (Request.QueryString["HouseNo"] != null && Request.QueryString["HouseNo"] != "")
            {
                string HouseNo =Request.QueryString["HouseNo"].Trim();
               
                this.ShowInfo(HouseNo);
            }
            else
            {
                Response.Write("<script>alert('非法参数！');history.back(-1);</script>");
                Response.End();
            }
        }

    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string HouseNo = KNetPage.KHtmlEncode(this.HouseNotxt.Text.Trim());
        string HouseName = KNetPage.KHtmlEncode(this.HouseName1.Text.Trim());
        string HouseTel = KNetPage.KHtmlEncode(this.HouseTel1.Text.Trim());
        string HouseMan = KNetPage.KHtmlEncode(this.HouseMan1.Text.Trim());
        string HouseAddress = KNetPage.KHtmlEncode(this.HouseAddress1.Text.Trim());
        string HouseRemark = KNetPage.KHtmlEncode(this.Remarks1.Text.Trim());

        DateTime HouseDate = DateTime.Now;

        if (KNetPage.IsDate(this.HouseDate1.Text.Trim()) == true)
        {
            HouseDate = DateTime.Parse(KNetPage.KHtmlEncode(this.HouseDate1.Text.Trim()));
        }

        bool HouseYN = this.HouseYN1.Checked;

        KNet.BLL.KNet_Sys_WareHouse BLL = new KNet.BLL.KNet_Sys_WareHouse();
        KNet.Model.KNet_Sys_WareHouse model = new KNet.Model.KNet_Sys_WareHouse();

        model.HouseNo = HouseNo;
        model.HouseName = HouseName;
        model.HouseTel = HouseTel;
        model.HouseMan = HouseMan;
        model.HouseAddress = HouseAddress;
        model.HouseRemark = HouseRemark;
        model.HouseDate = HouseDate;
        model.HouseYN = HouseYN;

        try
        {
            BLL.Update(model);

            AdminloginMess LogAM = new AdminloginMess();
            LogAM.Add_Logs("系统管理--->仓库管理--->仓库  修改 操作成功！名称：" + HouseName);

            Response.Write("<script>alert('仓库 修改 成功！');location.href='KnetWarehouse.aspx';</script>");
            Response.End();

        }
        catch
        {
            // throw;
            Response.Write("<script>alert('仓库 修改 失败！');history.back(-1);</script>");
            Response.End();
        }
    }
    /// <summary>
    /// 获取数据
    /// </summary>
    /// <param name="HouseNo"></param>
    private void ShowInfo(string HouseNo)
    {
        KNet.BLL.KNet_Sys_WareHouse bll = new KNet.BLL.KNet_Sys_WareHouse();
        KNet.Model.KNet_Sys_WareHouse model = bll.GetModel(HouseNo);

        this.HouseNotxt.Text = model.HouseNo;

        this.HouseName1.Text = model.HouseName;
        this.HouseTel1.Text = model.HouseTel;
        this.HouseMan1.Text = model.HouseMan;
        this.HouseAddress1.Text = model.HouseAddress;
        this.Remarks1.Text = model.HouseRemark;

        this.HouseDate1.Text =DateTime.Parse(model.HouseDate.ToString()).ToShortDateString();

        this.HouseYN1.Checked = model.HouseYN;

    }



  }

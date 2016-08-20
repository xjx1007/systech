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
public partial class Knet_Web_System_KnetWarehouse_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            base.Base_DropBasicCodeBind(this.Ddl_Type, "218");
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制仓库设置";
                }
                else
                {
                    this.Lbl_Title.Text = "修改仓库设置";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增仓库设置";
            }

            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }

            this.HouseDate1.Text = DateTime.Now.ToShortDateString();

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

        this.Tbx_ID.Text = model.HouseNo;

        this.HouseName1.Text = model.HouseName;
        this.HouseTel1.Text = model.HouseTel;
        this.HouseMan1.Text = model.HouseMan;
        this.HouseAddress1.Text = model.HouseAddress;
        this.Remarks1.Text = model.HouseRemark;
        this.SuppNoSelectValue.Value = model.SuppNo;
        this.SuppNo.Text = base.Base_GetSupplierName(model.SuppNo);
        this.HouseDate1.Text = DateTime.Parse(model.HouseDate.ToString()).ToShortDateString();
        this.Ddl_Type.SelectedValue = model.KSW_Type.ToString();
        this.HouseYN1.Checked = model.HouseYN;

    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string HouseNo = DateTime.Now.ToFileTimeUtc().ToString();
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
        model.SuppNo=this.SuppNoSelectValue.Value;
        if (this.Ddl_Type.SelectedValue != "")
        {
            model.KSW_Type = int.Parse(this.Ddl_Type.SelectedValue);
        }

        try
        {
            if (this.Tbx_ID.Text != "")
            {
                model.HouseNo = this.Tbx_ID.Text;
                BLL.Update(model);
                AdminloginMess LogAM = new AdminloginMess();
                LogAM.Add_Logs("系统管理--->仓库管理--->仓库  修改 操作成功！名称：" + HouseName);
                Response.Write("<script>alert('仓库 修改 成功！');location.href='KnetWarehouse.aspx';</script>");
                Response.End();
            }
            else
            {
                if (BLL.Exists(HouseName) == false)
                {
                    BLL.Add(model);
                    AdminloginMess LogAM = new AdminloginMess();
                    LogAM.Add_Logs("系统管理--->仓库管理--->仓库  添加 操作成功！名称：" + HouseName);
                    Response.Write("<script>alert('仓库 添加 成功！');location.href='KnetWarehouse.aspx';</script>");
                    Response.End();
                }
                else
                {
                    Response.Write("<script>alert('仓库 添加 失败（名称已存在）！');history.back(-1);</script>");
                    Response.End();
                }

            }
        }
        catch(Exception ex)
        {
            // throw;
            Response.Write("<script>alert('仓库 添加 失败！');history.back(-1);</script>");
            Response.End();
        }
    }
}

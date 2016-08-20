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
using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 
/// </summary>
public partial class Knet_Web_WareHouse_KNet_WareHouse_WareCheck_Manage_PrinterList_Add : System.Web.UI.Page
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
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
        }
    }


    /// <summary>
    /// 确定设置
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click1(object sender, EventArgs e)
    {
        //总单设置
        string Tex_ID = DateTime.Now.ToFileTimeUtc().ToString();

        string PrinterTitle = this.PrinterTitle.Text.Trim();
        bool PrinterYN = this.PrinterYN.Checked;
        DateTime PrinterDatetime = DateTime.Now;
        string TopComtont = this.txtTopComtont.Text.Trim();
        string BotComtont = this.txtBotComtont.Text.Trim();
        bool PrintStatShow = this.PrintStatShow.Checked;
        bool PrintAmount_Recodor = this.PrintAmount_Recodor.Checked;
        bool PrintAmount_Sum = this.PrintAmount_Sum.Checked;
        bool PrintDiscount_Sum = this.PrintDiscount_Sum.Checked;
        bool PrintTotalNet_Sum = this.PrintTotalNet_Sum.Checked;
    

        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected == true)
            {
                this.AndOpenBillingPrinter_Value(CheckBoxList1.Items[i].Value, CheckBoxList1.Items[i].Text, CheckBoxList1.Items.Count - i, Tex_ID);
            }
        }

        KNet.BLL.KNet_WareHouse_WareCheckList_Printer_Setup BLL = new KNet.BLL.KNet_WareHouse_WareCheckList_Printer_Setup();
        KNet.Model.KNet_WareHouse_WareCheckList_Printer_Setup model = new KNet.Model.KNet_WareHouse_WareCheckList_Printer_Setup();

        model.Tex_ID = Tex_ID;
        model.PrinterTitle = PrinterTitle;
        model.PrinterYN = PrinterYN;
        model.PrinterDatetime = PrinterDatetime;
        model.TopComtont = TopComtont;
        model.BotComtont = BotComtont;
        model.PrintStatShow = PrintStatShow;
        model.PrintAmount_Recodor = PrintAmount_Recodor;
        model.PrintAmount_Sum = PrintAmount_Sum;
        model.PrintDiscount_Sum = PrintDiscount_Sum;
        model.PrintTotalNet_Sum = PrintTotalNet_Sum;

        try
        {
            BLL.Add(model);

            //明细设置
            AdminloginMess AMlog = new AdminloginMess();
            AMlog.Add_Logs("库存盘点单打印模板添加成功.");

            Response.Write("<script>alert('库存盘点单打印模板添加成功！');this.location.href = 'KNet_WareHouse_WareCheck_Manage_PrinterListSetting.aspx?Css5=Div22';</script>");
            Response.End();
        }
        catch { }
    }

    /// <summary>
    /// 明细打印设置
    /// </summary>
    protected void AndOpenBillingPrinter_Value(string Tex_Value, string Tex_Texte, int Tex_pai, string Tex_ID)
    {
        string DoSql = "INSERT INTO KNet_WareHouse_WareCheckList_Printer_Value(Tex_Value,Tex_Texte,Tex_pai,Tex_ID) VALUES ('" + Tex_Value + "','" + Tex_Texte + "'," + Tex_pai + ",'" + Tex_ID + "')";
        DbHelperSQL.ExecuteSql(DoSql);
    }

    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button4_Click(object sender, EventArgs e)
    {
        string LogtimeA = StartDate.Text.ToString().Trim();
        string LogtimeB = EndDate.Text.ToString().Trim();
        string SeachKeyContent = KNetPage.KHtmlEncode(SeachKey.Text.ToString());
        if ((LogtimeA == "" && LogtimeB != "") || (LogtimeA != "" && LogtimeB == ""))
        {
            Response.Write("<script language=javascript>alert('您所选择的日期一定要有 开始日期 和 结束日期!');history.back(-1);</script>");
            Response.End();
        }
        Response.Redirect("KNet_WareHouse_WareCheck_Manage_PrinterListSetting.aspx?LogtimeA=" + LogtimeA + "&LogtimeB=" + LogtimeB + "&SeachKey=" + SeachKeyContent + "&Css5=Div22");
        Response.End();
    }
}

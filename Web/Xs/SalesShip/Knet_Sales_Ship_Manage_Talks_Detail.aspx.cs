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
using System.Net;
using System.IO;
using System.Text;

/// <summary>
/// 发货 跟踪信息 添加
/// </summary>
public partial class Knet_Sales_Ship_Manage_Talks_Detail : BasePage
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
        this.Page.Title = "快递信息";

        if (!IsPostBack)
        {

            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                string s_com = Request.QueryString["com"] == null ? "" : Request.QueryString["com"].ToString();
                string s_Code = Request.QueryString["Code"] == null ? "" : Request.QueryString["Code"].ToString();
                string s_Name = Request.QueryString["Name"] == null ? "" : Request.QueryString["Name"].ToString();
                String url = "http://api.ickd.cn/?com=" + s_com + "&nu=" + s_Code + "&id=F358C662FEC3E1CAA2C8C20DD2F9A448&type=Html";

                this.BeginQuery("Select * from PB_Basic_Wl where PBW_Name='" + s_Name + "'");
                this.QueryForDataTable();
                if (this.Dtb_Result.Rows.Count > 0)
                {
                    if (this.Dtb_Result.Rows[0]["PBW_Code"].ToString().IndexOf("10") >= 0)
                    {
                        WebPage webInfo = new WebPage(this.Dtb_Result.Rows[0]["PBW_Url"].ToString() + s_Code);
                        if (this.Dtb_Result.Rows[0]["PBW_Code"].ToString() == "102")
                        {
                           // this.Tbx_Return.Text = "单号：" + s_Code;
                            Response.Redirect(this.Dtb_Result.Rows[0]["PBW_Url"].ToString() + s_Code);
                        }
                        else
                        {

                            // webInfo.Context;//不包含html标签的所有内容  
                            this.Tbx_Return.Text = webInfo.M_html.Replace("请输入运单编号", "");
                            this.Tbx_Return.Text = this.Tbx_Return.Text.Replace("<textarea name=\"ID\" rows=\"5\" id=\"ID\"></textarea>", "");
                            this.Tbx_Return.Text = this.Tbx_Return.Text.Replace("<input type=\"submit\" name=\"Submit\" value=\"提交\">", "");
                            this.Tbx_Return.Text = this.Tbx_Return.Text.Replace("<input type=\"reset\" name=\"Submit2\" value=\"重置\">", "");
                        }
                        
                       

                    }
                    else
                    {
                        this.Tbx_Return.Text = getPageInfo(url);

                    }
                }
                else
                {
                    this.Tbx_Return.Text = getPageInfo(url);

                }

            }

        }
    }

    public static string getPageInfo(String url)
    {
        WebResponse wr_result = null;
        StringBuilder txthtml = new StringBuilder();
        try
        {
            WebRequest wr_req = WebRequest.Create(url);
            wr_req.Timeout = 10000;
            wr_result = wr_req.GetResponse();
            Stream ReceiveStream = wr_result.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("gb2312");
            StreamReader sr = new StreamReader(ReceiveStream, encode);
            if (true)
            {
                Char[] read = new Char[256];
                int count = sr.Read(read, 0, 256);
                while (count > 0)
                {
                    String str = new String(read, 0, count);
                    txthtml.Append(str);
                    count = sr.Read(read, 0, 256);
                }
            }
        }
        catch (Exception)
        {
            txthtml.Append("err");
        }
        finally
        {
            if (wr_result != null)
            {
                wr_result.Close();
            }
        }
        return txthtml.ToString();
    } 



}

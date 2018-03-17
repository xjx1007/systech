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
    public string s_apiurl = "";
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
                this.Btn_Save.Visible = false;
                this.Chk_Check.Visible = false;
                string s_com = Request.QueryString["com"] == null ? "" : Request.QueryString["com"].ToString();
                string s_Code = Request.QueryString["Code"] == null ? "" : Request.QueryString["Code"].ToString();
                string s_Name = Request.QueryString["Name"] == null ? "" : Request.QueryString["Name"].ToString();
                string s_DirectOutNo = Request.QueryString["DirectOutNo"] == null ? "" : Request.QueryString["DirectOutNo"].ToString();
                this.Tbx_DirectOutNo.Text = s_DirectOutNo;

                s_Name = base.GetKDName(s_Name);
                s_Code = s_Code.Replace("KYE", "");
                s_apiurl = "http://api.kuaidi100.com/api?id=3619cd2e53fcf3d0&com=" + s_Name + "&nu=" + s_Code + "&show=2&muti=1&order=asc";

                FrameMail.Attributes["src"] = s_apiurl;
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



    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        if (Chk_Check.Checked)
        {
            this.BeginQuery("Select top 1 * from KNet_Sales_OutWareList_FlowList where OutWareNo='" + this.Tbx_DirectOutNo.Text + "' and KDCodeName<>'' order by FollowDateTime desc  ");
            DataTable Dtb_Table = this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {

                KNet.BLL.KNet_Sales_OutWareList_FlowList BLL_Flow = new KNet.BLL.KNet_Sales_OutWareList_FlowList();
                KNet.Model.KNet_Sales_OutWareList_FlowList Model_Flow = new KNet.Model.KNet_Sales_OutWareList_FlowList();
                Model_Flow.ID = Dtb_Table.Rows[0]["ID"].ToString();
                Model_Flow.State = "<Font Color=red>已签收</Font>";
                BLL_Flow.UpDataSate(Model_Flow);
            }
            AlertAndClose("更新成功！");
        }
    }
}

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
/// 销售管理-----客户管理---客户添加
/// </summary>
public partial class Knet_Web_feedback_View : BasePage
{
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
            string s_ID=Request.QueryString["ID"]==null?"":Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                KNet.BLL.PB_Basic_Feedback Bll = new KNet.BLL.PB_Basic_Feedback();
                KNet.Model.PB_Basic_Feedback Model = Bll.GetModel(s_ID);
                Lbl_Person.Text = base.Base_GetUserName(Model.PBF_ContentPerson);
                Lbl_Type.Text = base.Base_GetBasicCodeName("148", Model.PBF_Type);
                Lbl_Detail.Text = KNetPage.KHtmlDiscode(Model.PBF_Details);
                KNet.BLL.PB_Basic_Attachment Bll_Att = new KNet.BLL.PB_Basic_Attachment();
                DataSet Dts_Table = Bll_Att.GetList(" PBA_FID='" + Model.PBF_ID + "'");
                if (Dts_Table.Tables[0].Rows.Count > 0)
                {
                    Lbl_Details.Text += "<table id=\"myTableDetails\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">";
                    for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                    {
                        string s_FileName = Dts_Table.Tables[0].Rows[i]["PBA_Name"].ToString();
                        string s_filePath = Dts_Table.Tables[0].Rows[i]["PBA_Url"].ToString();
                        Lbl_Details.Text += "<tr><td valign=\"top\" class=\"lvtCol\" align=\"left\" nowrap><a onclick=\"deleteRow3(this)\" href=\"#\">";
                        Lbl_Details.Text += "<img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=\"0\"></a></td>";

                        Lbl_Details.Text += "<td class=\"lvtCol\" align=\"left\" nowrap><input type=\"hidden\"  Name=\"Tbx_PName_" + i.ToString() + "\" value=" + s_FileName + ">" + s_FileName + "</td>";
                        Lbl_Details.Text += "<td class=\"lvtCol\" align=\"left\" nowrap><input Name=\"Image1Big_" + i.ToString() + "\"  type=\"hidden\"  value=" + s_filePath + "><a href=\"" + s_filePath + "\" >" + s_FileName + "</a></td></tr>";

                    }
                    this.Lbl_Details.Text += "</Table>";

                }
            }
        }
    }

}

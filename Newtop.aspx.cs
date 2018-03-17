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
using KNet.DBUtility;

public partial class top_Newtop : System.Web.UI.Page
{
    public string s_SenMenu = "";   
    protected void Page_Load(object sender, EventArgs e)
    {
        string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
        string s_module = Request.QueryString["Module"] == null ? "" : Request.QueryString["Module"].ToString();
        string s_parenttab = Request.QueryString["Parenttab"] == null ? "" : Request.QueryString["Parenttab"].ToString();
        KNet.Model.PB_Basic_Menu Model_Menu = new KNet.Model.PB_Basic_Menu();
        KNet.BLL.PB_Basic_Menu BLL_Menu = new KNet.BLL.PB_Basic_Menu();
        
        string s_Sql = "";
        if (s_ID != "")
        {
            s_Sql = "PBM_FatherID='" + s_ID+ "'";
        }
        else
        {
            s_Sql = "PBM_FatherID='1010'";
        }
        s_SenMenu += "<TABLE border=0 cellspacing=0 cellpadding=2 width=100% class=\"level2Bg\" >\n<tr><td ><table border=0 cellspacing=0 cellpadding=0><tr>";
        DataSet Ds_SeMenu = BLL_Menu.GetList(s_Sql);
        if (Ds_SeMenu.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Ds_SeMenu.Tables[0].Rows.Count; i++)
            {
                s_SenMenu += "<td class=";
                if ((s_module == Ds_SeMenu.Tables[0].Rows[i]["PBM_Module"].ToString()) && (s_module == Ds_SeMenu.Tables[0].Rows[i]["PBM_Module"].ToString()))
                {
                    s_SenMenu += "\"level2SelTab\"";

                }
                else
                {
                    s_SenMenu += "\"level2UnSelTab\"";

                }
                s_SenMenu += " nowrap> <a href=\"newTop.aspx?ID=" + Ds_SeMenu.Tables[0].Rows[i]["PBM_FatherID"].ToString() + "&module=" + Ds_SeMenu.Tables[0].Rows[i]["PBM_Module"].ToString() + "&parenttab=" + Ds_SeMenu.Tables[0].Rows[i]["PBM_Parenttab"].ToString() + "\" onclick=\"parent.main.location.href='" + Ds_SeMenu.Tables[0].Rows[i]["PBM_Url"].ToString() + "';\" >" + Ds_SeMenu.Tables[0].Rows[i]["PBM_Name"].ToString() + "</a> </td>";

            }
        }
        s_SenMenu += "</tr></table></td></tr></TABLE>";
    }

}



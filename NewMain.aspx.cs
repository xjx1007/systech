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
using KNet.Common;
using System.Data.SqlClient;


public partial class Knetwork_Admin_NewMain : BasePage
{
    public string s_FirstMenu = "";
    public string s_SenMenu = "";
    public string s_DropMenu = "";
    public string s_Person = "", loginUser = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Knetwork_Admin_NewMain));
        try
        {
            AdminloginMess AM = new AdminloginMess();
            loginUser = "{uid:\"" + AM.KNet_StaffNo + "\", user_id:\"" + AM.KNet_StaffNo + "\", user_name:\"" + AM.KNet_StaffName + "\"}";
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_module = Request.QueryString["Module"] == null ? "" : Request.QueryString["Module"].ToString();
            string s_parenttab = Request.QueryString["Parenttab"] == null ? "" : Request.QueryString["Parenttab"].ToString();
            KNet.Model.PB_Basic_Menu Model_Menu = new KNet.Model.PB_Basic_Menu();
            KNet.BLL.PB_Basic_Menu BLL_Menu = new KNet.BLL.PB_Basic_Menu();
            string s_SqlWhere = "";
            s_SqlWhere = " PBM_Level in ('1','0')  order by PBM_Level,isnull(PBM_Order,6),PBM_ID";
            DataSet Ds_Menu = BLL_Menu.GetList(s_SqlWhere);
            s_FirstMenu += "<table border=0 cellspacing=0 cellpadding=0>\n";
            if (Ds_Menu.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Ds_Menu.Tables[0].Rows.Count; i++)
                {
                    string s_Name = Ds_Menu.Tables[0].Rows[i]["PBM_Name"].ToString();
                    if ((s_Name == "市场") || (i == 0))
                    {
                        s_FirstMenu += "<tr>\n";
                    }
                    string s_RowSpan = Ds_Menu.Tables[0].Rows[i]["PBM_RowSpan"].ToString();
                    string s_ColSpan = Ds_Menu.Tables[0].Rows[i]["PBM_ColSpan"].ToString();
                    string s_Level = Ds_Menu.Tables[0].Rows[i]["PBM_Level"].ToString();
                    if (s_Level == "0")
                    {
                        s_FirstMenu += "<td class=\"tabSeperator\" ";
                        s_FirstMenu += " rowspan=\"2\" ";
                        s_FirstMenu += ">\n";
                        s_FirstMenu += "<img src=\"themes/softed/images/spacer.gif\" width=2px height=38px>";
                        s_FirstMenu += "</td>\n";
                    }
                    s_FirstMenu += "<td class=";
                    if (s_parenttab == Ds_Menu.Tables[0].Rows[i]["PBM_Parenttab"].ToString())
                    {
                        s_FirstMenu += "\"tabSelected\"";
                    }
                    else
                    {
                        s_FirstMenu += "\"tabUnSelected\"";
                    }
                    if (s_RowSpan != "1")
                    {
                        s_FirstMenu += " rowspan=\"" + s_RowSpan + "\" ";
                    }
                    if (s_ColSpan != "1")
                    {
                        s_FirstMenu += " colspan=\"" + s_ColSpan + "\" ";
                    }
                    if ((s_RowSpan != "1") || (s_ColSpan == "1"))
                    {
                        if (s_RowSpan == "1")
                        {
                            s_FirstMenu += "onmouseover=\"fnDropDown1(this,'" + Ds_Menu.Tables[0].Rows[i]["PBM_ID"].ToString() + "_sub');\" onMouseOut=\"fnHideDrop('" + Ds_Menu.Tables[0].Rows[i]["PBM_ID"].ToString() + "_sub');\" align=\"center\" nowrap";
                        }
                        else
                        {
                            s_FirstMenu += "onmouseover=\"fnDropDown(this,'" + Ds_Menu.Tables[0].Rows[i]["PBM_ID"].ToString() + "_sub');\" onMouseOut=\"fnHideDrop('" + Ds_Menu.Tables[0].Rows[i]["PBM_ID"].ToString() + "_sub');\" align=\"center\" nowrap";
                        }

                    }
                    else
                    {
                        s_FirstMenu += "align=\"center\" ";
                    }
                    s_FirstMenu += ">";

                    s_FirstMenu += "<a href=\"newTop.aspx?ID=";
                    s_FirstMenu += Ds_Menu.Tables[0].Rows[i]["PBM_ID"].ToString();
                    s_FirstMenu += "&module=" + Ds_Menu.Tables[0].Rows[i]["PBM_Module"].ToString() + "&parenttab=" + Ds_Menu.Tables[0].Rows[i]["PBM_Parenttab"].ToString() + "\"  target=\"top\">";
                    if ((s_RowSpan == "1") & (s_ColSpan != "1"))
                    {
                        s_FirstMenu += "<p style=\"font-size:80%\"><em>" + Ds_Menu.Tables[0].Rows[i]["PBM_Name"].ToString() + "</em></p>";
                    }
                    else
                    {
                        s_FirstMenu += Ds_Menu.Tables[0].Rows[i]["PBM_Name"].ToString();
                    }
                    s_FirstMenu += "</a>";
                    if ((s_RowSpan != "1") || (s_ColSpan == "1"))
                    {
                        s_FirstMenu += "<img src=\"themes/softed/images/menuDnArrow.gif\" border=0 style=\"padding-left:5px\">";
                    }
                    s_FirstMenu += "</td>";
                    //第三层
                    s_SqlWhere = " PBM_FatherID='" + Ds_Menu.Tables[0].Rows[i]["PBM_ID"].ToString() + "' ";
                    DataSet Ds_DropMenu = BLL_Menu.GetList(s_SqlWhere);
                    if (Ds_DropMenu.Tables[0].Rows.Count > 0)
                    {
                        s_DropMenu += "<div class=\"drop_mnu\" id=\"" + Ds_DropMenu.Tables[0].Rows[0]["PBM_FatherID"].ToString() + "_sub\" onMouseOut=\"fnHideDrop('" + Ds_DropMenu.Tables[0].Rows[0]["PBM_FatherID"].ToString() + "_sub')\" onMouseOver=\"fnShowDrop('" + Ds_DropMenu.Tables[0].Rows[0]["PBM_FatherID"].ToString() + "_sub')\">\n";
                        s_DropMenu += "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">\n";
                        for (int j = 0; j < Ds_DropMenu.Tables[0].Rows.Count; j++)
                        {
                            string s_ID1 =  Ds_DropMenu.Tables[0].Rows[j]["PBM_ID"].ToString();
                            string s_IsChild = Ds_DropMenu.Tables[0].Rows[j]["PBM_IsChild"].ToString();
                            s_DropMenu += "<tr><td";
                            if (s_IsChild == "1")
                            {
                                s_DropMenu += " onmouseover=\"fnDropDown4(this,'" + s_ID1 + "_sub');\" onMouseOut=\"fnHideDrop('" + s_ID1 + "_sub');\" ";
                            }
                            s_DropMenu += "><table  border=\"0\" cellspacing=\"0\" cellpadding=\"0\"     width=\"100%\" >";
                            s_DropMenu += "<tr><td width=\"87%\" ><a href='" + Ds_DropMenu.Tables[0].Rows[j]["PBM_URL"].ToString() + "' target=\"main\"   onclick=\"top.location.href='newTop.aspx?ID=" + Ds_DropMenu.Tables[0].Rows[j]["PBM_FatherID"].ToString() + "&module=" + Ds_DropMenu.Tables[0].Rows[j]["PBM_Module"].ToString() + "&parenttab=" + Ds_DropMenu.Tables[0].Rows[j]["PBM_Parenttab"].ToString() + "'\" class=\"drop_down\">";
                            s_DropMenu += " " + Ds_DropMenu.Tables[0].Rows[j]["PBM_Name"].ToString() + "</a></td>";

                            if (s_IsChild == "1")
                            {
                                s_DropMenu += "<td width=\"13%\" align=\"right\" class=\"drop_mnu2\"><img src=\"themes/softed/images/ar.png\" border=0 ></td>";
                            }
                            else
                            {
                                s_DropMenu += "<td width=\"13%\" align=\"right\" class=\"drop_mnu\">&nbsp;</td>";
                            }
                            s_DropMenu += "</tr></table></td></tr>\n";
                        }
                        s_DropMenu += "</table>\n</div>\n";

                        string s_FourDorpMenu = "";
                        //第4层
                        for (int j = 0; j < Ds_DropMenu.Tables[0].Rows.Count; j++)
                        {
                            string s_Sql = " PBM_FatherID='" + Ds_DropMenu.Tables[0].Rows[j]["PBM_ID"].ToString() + "'";
                            DataSet Ds_ForDropMenu = BLL_Menu.GetList(s_Sql);
                            if (Ds_ForDropMenu.Tables[0].Rows.Count > 0)
                            {
                                string s_IDs =  Ds_ForDropMenu.Tables[0].Rows[0]["PBM_FatherID"].ToString();
                                this.BeginQuery("Select PBM_FatherID,PBM_IsChild from PB_Basic_Menu where PBM_ID='" + Ds_ForDropMenu.Tables[0].Rows[0]["PBM_FatherID"].ToString() + "'");
                                DataTable Dtb_Table1 = (DataTable)this.QueryForDataTable();
                                string s_IsChild = Dtb_Table1.Rows[0]["PBM_IsChild"].ToString();
                                string s_FaterFaterID = Dtb_Table1.Rows[0]["PBM_FatherID"].ToString();
                                if (s_IsChild == "1")
                                {
                                    s_FourDorpMenu += "<div class=\"drop_mnu\" id=\"" + s_IDs + "_sub\" onMouseOut=\"fnHideDrop('" + s_IDs + "_sub');fnHideDrop('" + s_FaterFaterID + "_sub')\" onMouseOver=\"fnShowDrop('" + s_IDs + "_sub');fnShowDrop('" + s_FaterFaterID + "_sub')\">\n";
                                }
                                else
                                {
                                    s_FourDorpMenu += "<div class=\"drop_mnu\" id=\"" + s_IDs + "_sub\" onMouseOut=\"fnHideDrop('" + s_IDs + "_sub');\" onMouseOver=\"fnShowDrop('" + s_IDs + "_sub');\">\n";
                                }
                                s_FourDorpMenu += "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">\n";
                                for (int k = 0; k < Ds_ForDropMenu.Tables[0].Rows.Count; k++)
                                {
                                    s_FourDorpMenu += "<tr><td ><a onclick=\"top.location.href='newTop.aspx?ID=" + Ds_ForDropMenu.Tables[0].Rows[k]["PBM_FatherID"].ToString() + "&module=" + Ds_ForDropMenu.Tables[0].Rows[k]["PBM_Module"].ToString() + "&parenttab=" + Ds_ForDropMenu.Tables[0].Rows[k]["PBM_Parenttab"].ToString() + "'\" href='" + Ds_ForDropMenu.Tables[0].Rows[k]["PBM_URL"].ToString() + "' target=\"main\" class=\"drop_down\">";
                                    s_FourDorpMenu += "<div>" + Ds_ForDropMenu.Tables[0].Rows[k]["PBM_Name"].ToString() + "</div>";
                                    s_FourDorpMenu += "</a>";
                                    s_FourDorpMenu += "</td></tr>\n";
                                }
                                s_FourDorpMenu += "</table>\n</div>\n";
                            }
                        }

                        s_DropMenu += s_FourDorpMenu;
                    }
                    if (s_Name == "综合报表")
                    {
                        s_FirstMenu += "</tr>\n";
                    }
                }

            }
            s_FirstMenu += "</table>\n";
            this.Lbl_UserCount.Text = AM.GetOnlineCount();
            s_Person = AM.KNet_StaffName;
            this.Tbx_UserID.Text = AM.KNet_StaffNo;
            this.Tbx_CompanyName.Text = AM.KNet_Sys_CompanyName;
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }
    protected void LogOut_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        AM.Logout();
        AlertAndRedirect("退出成功！", "signin.aspx");
    }
}

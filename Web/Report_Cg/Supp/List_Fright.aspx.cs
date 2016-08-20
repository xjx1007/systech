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

using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

public partial class Web_List_OrderIn : BasePage
{
    public string s_Time = "";
    public string s_HouseName = "";
    public string s_Details = "";
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
            string s_SuppNo = Request.QueryString["SuppNo"] == null ? "" : Request.QueryString["SuppNo"].ToString();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();


            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_DutyPerson = Request.QueryString["DutyPerson"] == null ? "" : Request.QueryString["DutyPerson"].ToString();
            string s_Sql = "select *,(Select COUNT(*) from XS_Compy_LinkMan where XOL_Compy=a.SuppNo and XOL_Name<>'' ) as LinkCount from Knet_Procure_Suppliers a  ";
            s_Sql += " left Join KNet_Sys_ProcureType b on a.KPS_Type=b.ProcureTypeValue ";
            s_Sql += " where 1=1 ";

            if (s_SuppNo != "")
            {
                s_Sql += " and   a.SuppNo='" + s_SuppNo + "'";
            }
            if (s_Type != "")
            {
                s_Sql += " and  a.KPS_Type='" + s_Type + "' ";
            }
            s_Sql += " Order by a.SuppName ";
            string s_House = "", s_Style = "";
            string s_Head = "";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        s_Style = "class='gg'";
                    }
                    else
                    {
                        s_Style = "class='rr'";
                    }
                    s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                    string s_Row = Dtb_Table.Rows[i]["LinkCount"].ToString();
                    s_Details += "<td class='thstyleLeftDetails'align=center noWrap>" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left rowspan=" + s_Row + "  noWrap>&nbsp;" + Dtb_Table.Rows[i]["KPS_SName"].ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left rowspan=" + s_Row + "  noWrap>&nbsp;" + Dtb_Table.Rows[i]["SuppName"].ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left rowspan=" + s_Row + "  noWrap>&nbsp;" + Dtb_Table.Rows[i]["SuppCode"].ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left rowspan=" + s_Row + "  noWrap>&nbsp;" + Dtb_Table.Rows[i]["ProcureTypeName"].ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left rowspan=" + s_Row + "  noWrap>&nbsp;" + base.Base_GetBasicCodeName("112", Dtb_Table.Rows[i]["KPS_Level"].ToString()) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left rowspan=" + s_Row + "  noWrap>&nbsp;" + base.Base_GetBasicCodeName("300", Dtb_Table.Rows[i]["KPS_Days"].ToString()) + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left rowspan=" + s_Row + "  noWrap>&nbsp;" + Dtb_Table.Rows[i]["KPS_GiveDays"].ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left rowspan=" + s_Row + "  noWrap>&nbsp;" + Dtb_Table.Rows[i]["SuppAddress"].ToString() + "</td>\n";
                    
                    string s_SuppNo1 = Dtb_Table.Rows[i]["SuppNo"].ToString();
                    try
                    {

                        string s_Sql1 = " Select* from XS_Compy_LinkMan where XOL_Compy=" + s_SuppNo1 + " and XOL_Name<>'' ";
                        this.BeginQuery(s_Sql1);
                        DataTable Dtb_LinkMan = (DataTable)this.QueryForDataTable();
                        if (Dtb_LinkMan.Rows.Count > 0)
                        {
                            for (int j = 0; j < Dtb_LinkMan.Rows.Count; j++)
                            {
                                if (j > 0)
                                {
                                    s_Details += " <tr>";
                                }

                                s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_LinkMan.Rows[j]["XOL_Name"].ToString() + "</td>\n";

                                s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_LinkMan.Rows[j]["XOL_Responsible"].ToString() + "</td>\n";
                                s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_LinkMan.Rows[j]["XOL_phone"].ToString() + "</td>\n";
                                s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_LinkMan.Rows[j]["XOL_Officephone"].ToString() + "</td>\n";
                                s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_LinkMan.Rows[j]["XOL_QQ"].ToString() + "</td>\n";
                                s_Details += "<td  class='thstyleLeftDetails' align=left  noWrap>&nbsp;" + Dtb_LinkMan.Rows[j]["XOL_Mail"].ToString() + "</td>\n";
                                if (j > 0)
                                {
                                    s_Details += " </tr>";
                                }
                            }
                        }
                        else
                        {

                            s_Details += "<td  class='thstyleLeftDetails' align=left rowspan=" + s_Row + " noWrap>&nbsp;</td>\n";
                            s_Details += "<td  class='thstyleLeftDetails' align=left rowspan=" + s_Row + " noWrap>&nbsp;</td>\n";
                            s_Details += "<td  class='thstyleLeftDetails' align=left rowspan=" + s_Row + " noWrap>&nbsp;</td>\n";
                            s_Details += "<td  class='thstyleLeftDetails' align=left rowspan=" + s_Row + " noWrap>&nbsp;</td>\n";
                            s_Details += "<td  class='thstyleLeftDetails' align=left rowspan=" + s_Row + " noWrap>&nbsp;</td>\n";
                            s_Details += "<td  class='thstyleLeftDetails' align=left rowspan=" + s_Row + " noWrap>&nbsp;</td>\n";

                        }
                        s_Details += "<td  class='thstyleLeftDetails' align=left rowspan=" + s_Row + " noWrap>&nbsp;" + Dtb_Table.Rows[i]["AddDateTime"].ToString() + "</td>\n";

                        s_Details += " </tr>";
                    }
                    catch
                    { }

                }
            }
            s_Details += "</tbody></table></td></tr>";
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=\"17\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>合格供应商名录</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"7\" class=\"thstyleleft\"  ></th><th colspan=\"10\" class=\"thstyleRight\" >" + s_Time + "</th></tr>\n";
            s_Head += "<th class=\"thstyle\" >项次</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>公司简称</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>公司名称</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>编码</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>类别</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>级别</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>付款周期</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>交货周期</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>地址</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>联系人</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>职位</th>\n";
            s_Head += "<th class=\"thstyle\">手机</th>\n";
            s_Head += "<th class=\"thstyle\">电话</th>\n";
            s_Head += "<th class=\"thstyle\">QQ</th>\n";
            s_Head += "<th class=\"thstyle\">EMail</th>\n";
            s_Head += "<th class=\"thstyle\" align=center>创建日期</th>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";
            this.Lbl_Details.Text = s_Head + s_Details;
        }
    }
    public string GetFp(string s_ID)
    {
        string s_Return = "";
        try
        {
            this.BeginQuery("select * from PB_Basic_Comment where PBC_FID='" + s_ID + "'");
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                {
                    s_Return += Dtb_Result.Rows[i]["PBC_Description"].ToString() + "<br/>";
                }
                s_Return = s_Return.Substring(0, s_Return.Length - 5);
            }
        }
        catch
        { }
        return s_Return;
    }
}

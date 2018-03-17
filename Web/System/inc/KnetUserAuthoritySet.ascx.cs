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

public partial class KNet_Web_System_inc_KnetUserAuthoritySet : System.Web.UI.UserControl
{
    public string s_ArrDetails = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

                string GroupValue = Request.QueryString["GroupValue"];

                int King = 1;
                string CSS = "Div22";
                if (Request.QueryString["King"] != null)
                {
                    King = int.Parse(Request.QueryString["King"].ToString());
                }
                if (Request.QueryString["CSS"] != null)
                {
                    CSS = Request.QueryString["CSS"].ToString();
                }
                KNet.BLL.PB_Basic_Code Bll=new KNet.BLL.PB_Basic_Code();
                DataSet Dts_Table = Bll.GetList(" PBC_ID='152' ");
               if (Dts_Table.Tables[0].Rows.Count > 0)
               {
                   for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                   {
                       s_ArrDetails += "<tr><td width=\"50\" height=\"30px\" align=\"center\">";
                       s_ArrDetails += "<a id=\"ProcureBillingSetting1_HyperLink" + i.ToString() + "\" class=\"Div22\"";
                       s_ArrDetails += " href=\"KnetUserAuthoritySetA.aspx?GroupValue=" + GroupValue + "&King=" + Dts_Table.Tables[0].Rows[i]["PBC_Code"].ToString() + "&CSS=" + CSS + "&Fonts=MintCream\" style=\"display:inline-block;color:MintCream;font-size:13px;font-weight:bold;height:21px;width:90px;\">" + Dts_Table.Tables[0].Rows[i]["PBC_Name"].ToString() + "</a></td>";
                       s_ArrDetails += "<td width=\"3\" align=\"center\"></td></tr>";
                   }
               }
        }
    }
}

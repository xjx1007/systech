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

public partial class KNet_Help_HowToUser_Setting : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            this.HyperLink1.NavigateUrl = "/Help/Documentation.aspx?kings=1&Css1=Div22";
            if (Request["Css1"] != "" && Request["Css1"] != null)
            {
                this.HyperLink1.CssClass = "Div22";
                this.HyperLink1.ForeColor = System.Drawing.Color.MintCream;
                this.HyperLink1.Font.Bold = true;
            }

            this.HyperLink2.NavigateUrl = "/Help/Documentation.aspx?kings=2&Css2=Div22";
            if (Request["Css2"] != "" && Request["Css2"] != null)
            {
                this.HyperLink2.CssClass = "Div22";
                this.HyperLink2.ForeColor = System.Drawing.Color.MintCream;
                this.HyperLink2.Font.Bold = true;
            }

            this.HyperLink3.NavigateUrl = "/Help/Documentation.aspx?kings=3&Css3=Div22";
            if (Request["Css3"] != "" && Request["Css3"] != null)
            {
                this.HyperLink3.CssClass = "Div22";
                this.HyperLink3.ForeColor = System.Drawing.Color.MintCream;
                this.HyperLink3.Font.Bold = true;
            }

            this.HyperLink4.NavigateUrl = "/Help/Documentation.aspx?kings=4&Css4=Div22";
            if (Request["Css4"] != "" && Request["Css4"] != null)
            {
                this.HyperLink4.CssClass = "Div22";
                this.HyperLink4.ForeColor = System.Drawing.Color.MintCream;
                this.HyperLink4.Font.Bold = true;
            }
            this.HyperLink5.NavigateUrl = "/Help/Documentation.aspx?kings=5&Css5=Div22";
            if (Request["Css5"] != "" && Request["Css5"] != null)
            {
                this.HyperLink5.CssClass = "Div22";
                this.HyperLink5.ForeColor = System.Drawing.Color.MintCream;
                this.HyperLink5.Font.Bold = true;
            }
            this.HyperLink6.NavigateUrl = "/Help/Documentation.aspx?kings=6&Css6=Div22";
            if (Request["Css6"] != "" && Request["Css6"] != null)
            {
                this.HyperLink6.CssClass = "Div22";
                this.HyperLink6.ForeColor = System.Drawing.Color.MintCream;
                this.HyperLink6.Font.Bold = true;
            }
            this.HyperLink7.NavigateUrl = "/Help/Documentation.aspx?kings=7&Css7=Div22";
            if (Request["Css7"] != "" && Request["Css7"] != null)
            {
                this.HyperLink7.CssClass = "Div22";
                this.HyperLink7.ForeColor = System.Drawing.Color.MintCream;
                this.HyperLink7.Font.Bold = true;
            }
            this.HyperLink8.NavigateUrl = "/Help/Documentation.aspx?kings=&Css8=Div22";
            if (Request["Css8"] != "" && Request["Css8"] != null)
            {
                this.HyperLink8.CssClass = "Div22";
                this.HyperLink8.ForeColor = System.Drawing.Color.MintCream;
                this.HyperLink8.Font.Bold = true;
            }
        }

    }
}

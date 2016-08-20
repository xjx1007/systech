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

public partial class Web_HR_inc_AttenDanceMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string KCss = Request.QueryString["KCss"];

        if (KCss == "AA")
        {
            this.HyperLink1.CssClass = "Div22";
            this.HyperLink1.Font.Bold = true;
            this.HyperLink1.ForeColor = System.Drawing.Color.MintCream;

            this.HyperLink2.CssClass = "Div11";
            this.HyperLink2.Font.Bold = false;
            this.HyperLink2.ForeColor = System.Drawing.Color.Empty;

            this.HyperLink3.CssClass = "Div11";
            this.HyperLink3.Font.Bold = false;
            this.HyperLink3.ForeColor = System.Drawing.Color.Empty;

            this.HyperLink4.CssClass = "Div11";
            this.HyperLink4.Font.Bold = false;
            this.HyperLink4.ForeColor = System.Drawing.Color.Empty;

            this.HyperLink5.CssClass = "Div11";
            this.HyperLink5.Font.Bold = false;
            this.HyperLink5.ForeColor = System.Drawing.Color.Empty;
        }
        if (KCss == "BB")
        {
            this.HyperLink1.CssClass = "Div11";
            this.HyperLink1.Font.Bold = false;
            this.HyperLink1.ForeColor = System.Drawing.Color.Empty;

            this.HyperLink2.CssClass = "Div22";
            this.HyperLink2.Font.Bold = true;
            this.HyperLink2.ForeColor = System.Drawing.Color.MintCream;

            this.HyperLink3.CssClass = "Div11";
            this.HyperLink3.Font.Bold = false;
            this.HyperLink3.ForeColor = System.Drawing.Color.Empty;

            this.HyperLink4.CssClass = "Div11";
            this.HyperLink4.Font.Bold = false;
            this.HyperLink4.ForeColor = System.Drawing.Color.Empty;

            this.HyperLink5.CssClass = "Div11";
            this.HyperLink5.Font.Bold = false;
            this.HyperLink5.ForeColor = System.Drawing.Color.Empty;
        }
        if (KCss == "CC")
        {
            this.HyperLink1.CssClass = "Div11";
            this.HyperLink1.Font.Bold = false;
            this.HyperLink1.ForeColor = System.Drawing.Color.Empty;

            this.HyperLink2.CssClass = "Div11";
            this.HyperLink2.Font.Bold = false;
            this.HyperLink2.ForeColor = System.Drawing.Color.Empty;

            this.HyperLink3.CssClass = "Div22";
            this.HyperLink3.Font.Bold = true;
            this.HyperLink3.ForeColor = System.Drawing.Color.MintCream;

            this.HyperLink4.CssClass = "Div11";
            this.HyperLink4.Font.Bold = false;
            this.HyperLink4.ForeColor = System.Drawing.Color.Empty;

            this.HyperLink5.CssClass = "Div11";
            this.HyperLink5.Font.Bold = false;
            this.HyperLink5.ForeColor = System.Drawing.Color.Empty;
        }
        if (KCss == "DD")
        {
            this.HyperLink1.CssClass = "Div11";
            this.HyperLink1.Font.Bold = false;
            this.HyperLink1.ForeColor = System.Drawing.Color.Empty;

            this.HyperLink2.CssClass = "Div11";
            this.HyperLink2.Font.Bold = false;
            this.HyperLink2.ForeColor = System.Drawing.Color.Empty;

            this.HyperLink3.CssClass = "Div11";
            this.HyperLink3.Font.Bold = false;
            this.HyperLink3.ForeColor = System.Drawing.Color.Empty;

            this.HyperLink4.CssClass = "Div22";
            this.HyperLink4.Font.Bold = true;
            this.HyperLink4.ForeColor = System.Drawing.Color.MintCream;

            this.HyperLink5.CssClass = "Div11";
            this.HyperLink5.Font.Bold = false;
            this.HyperLink5.ForeColor = System.Drawing.Color.Empty;
        }
        if (KCss == "EE")
        {
            this.HyperLink1.CssClass = "Div11";
            this.HyperLink1.Font.Bold = false;
            this.HyperLink1.ForeColor = System.Drawing.Color.Empty;

            this.HyperLink2.CssClass = "Div11";
            this.HyperLink2.Font.Bold = false;
            this.HyperLink2.ForeColor = System.Drawing.Color.Empty;

            this.HyperLink3.CssClass = "Div11";
            this.HyperLink3.Font.Bold = false;
            this.HyperLink3.ForeColor = System.Drawing.Color.Empty;

            this.HyperLink4.CssClass = "Div11";
            this.HyperLink4.Font.Bold = false;
            this.HyperLink4.ForeColor = System.Drawing.Color.Empty;

            this.HyperLink5.CssClass = "Div22";
            this.HyperLink5.Font.Bold = true;
            this.HyperLink5.ForeColor = System.Drawing.Color.MintCream;
        }




    }
}

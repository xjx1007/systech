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

public partial class Web_HR_inc_Structermenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string StrKnet = Request.QueryString["KNetStrA"];

            if (StrKnet == "AA")
            {
                this.HyperLink1.CssClass = "Div22";
                this.HyperLink1.Font.Bold = true;
                this.HyperLink1.ForeColor = System.Drawing.Color.MintCream;

                this.HyperLink2.CssClass = "Div11";
                this.HyperLink2.Font.Bold = false;
                this.HyperLink2.ForeColor = System.Drawing.Color.Empty;
            }
            else
            {
                if (StrKnet == "BB")
                {
                    this.HyperLink2.CssClass = "Div22";
                    this.HyperLink2.Font.Bold = true;
                    this.HyperLink2.ForeColor = System.Drawing.Color.MintCream;

                    this.HyperLink1.CssClass = "Div11";
                    this.HyperLink1.Font.Bold = false;
                    this.HyperLink1.ForeColor = System.Drawing.Color.Empty;
                }
                else
                {
                    this.HyperLink1.CssClass = "Div22";
                    this.HyperLink1.Font.Bold = true;
                    this.HyperLink1.ForeColor = System.Drawing.Color.MintCream;

                    this.HyperLink2.CssClass = "Div11";
                    this.HyperLink2.Font.Bold = false;
                    this.HyperLink2.ForeColor = System.Drawing.Color.Empty;
                }

            }

        }
    }
}

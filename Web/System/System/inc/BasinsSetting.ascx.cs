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

public partial class KNet_Web_System_inc_BasinsSetting : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            this.HyperLink1.NavigateUrl = "../BasisSetting_Units.aspx?Css1=wewte";
            if (Request["Css1"] != "" && Request["Css1"] != null)
            {
                this.HyperLink1.CssClass = "Div22";
                this.HyperLink1.ForeColor = System.Drawing.Color.MintCream;
                this.HyperLink1.Font.Bold = true;
            }

            this.HyperLink2.NavigateUrl = "../BasisSetting_CheckMethod.aspx?Css2=Div22";
            if (Request["Css2"] != "" && Request["Css2"] != null)
            {
                this.HyperLink2.CssClass = "Div22";
                this.HyperLink2.ForeColor = System.Drawing.Color.MintCream;
                this.HyperLink2.Font.Bold = true;
            }

            this.HyperLink3.NavigateUrl = "../BasisSetting_CheckNotes.aspx?Css3=Div22";
            if (Request["Css3"] != "" && Request["Css3"] != null)
            {
                this.HyperLink3.CssClass = "Div22";
                this.HyperLink3.ForeColor = System.Drawing.Color.MintCream;
                this.HyperLink3.Font.Bold = true;
            }


            this.HyperLink4.NavigateUrl = "../BasisSetting_BigClass.aspx?Css4=Div22";
            if (Request["Css4"] != "" && Request["Css4"] != null)
            {
                this.HyperLink4.CssClass = "Div22";
                this.HyperLink4.ForeColor = System.Drawing.Color.MintCream;
                this.HyperLink4.Font.Bold = true;
            }


            this.HyperLink5.NavigateUrl = "../BasisSetting_SmallClass.aspx?Css5=Div22";
            if (Request["Css5"] != "" && Request["Css5"] != null)
            {
                this.HyperLink5.CssClass = "Div22";
                this.HyperLink5.ForeColor = System.Drawing.Color.MintCream;
                this.HyperLink5.Font.Bold = true;
            }
        }

    }
}

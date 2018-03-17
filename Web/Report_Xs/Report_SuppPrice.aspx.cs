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

public partial class Web_Report_Xs_Report_CkDetails : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            DataSet ds = KNet.Common.KNet_Static_BigClass.GetBigInfo();
            string BigNo, CateName;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                BigNo = ds.Tables[0].Rows[i]["BigNo"].ToString();
                CateName = ds.Tables[0].Rows[i]["CateName"].ToString();
                this.BigClass.Items.Add(new ListItem(CateName, BigNo));
            }
            this.SmallClass.Disabled = true;
        }
    }
    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        OpenWebFormSize("List_SuppPrice.aspx?SuppName=" + this.Tbx_SuppName.Text + "&ProductsName=" + this.Tbx_ProductsName.Text + "&BigClass=" + this.BigClass.Value + "&SmallClass=" + this.SmallClass.Value, 800, 600, 100, 100);
    }
}

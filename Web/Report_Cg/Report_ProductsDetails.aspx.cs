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

            this.DataBindProductsMainCategory();
        }
    }
    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        OpenWebFormSize("List_ProductsList.aspx?ProductsName=" + this.Tbx_Name.Text + "&ProductsPattern=" + this.Tbx_Pattern.Text + "&ProductsEdition=" + this.Tbx_Edition.Text + "&ProductsMainCategory=" + this.ProductsMainCategory.SelectedValue, 800, 600, 100, 100);
    }

    /// <summary>
    /// 大分类绑定
    /// </summary>
    protected void DataBindProductsMainCategory()
    {

        KNet.BLL.KNet_Sys_BigCategories bll = new KNet.BLL.KNet_Sys_BigCategories();
        DataSet ds = bll.GetAllList();

        this.ProductsMainCategory.DataSource = ds;
        this.ProductsMainCategory.DataTextField = "CateName";
        this.ProductsMainCategory.DataValueField = "BigNo";
        this.ProductsMainCategory.DataBind();
        ListItem item = new ListItem("请选择大分类", ""); //默认值
        this.ProductsMainCategory.Items.Insert(0, item);
    }
}

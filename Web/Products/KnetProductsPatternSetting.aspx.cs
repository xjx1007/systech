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
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Data.SqlClient;

using KNet.DBUtility;
using KNet.Common;


/// <summary>
/// 型号管理管理
/// </summary>
public partial class Knet_Web_KnetProductsPatternSetting : BasePage
{
    public string s_AdvShow = "", s_ProductsClass="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Lbl_Title.Text = "型号管理列表";
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            base.Base_DropBindSearch(this.bas_searchfield, "KNet_Sys_Products");
            base.Base_DropBindSearch(this.Fields, "KNet_Sys_Products");
            this.DataShows();
        }

    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sys_Products bll = new KNet.BLL.KNet_Sys_Products();
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";

        string SqlWhere = " select distinct ProductsPattern,KSP_Mould from KNet_Sys_Products where 1=1 ";
        AdminloginMess AM = new AdminloginMess();

        if (s_WhereID != "")
        {
            SqlWhere += Base_GetBasicWhere(s_WhereID);
        }

        if ((this.bas_searchfield.SelectedValue != "") && (search_text.Text != ""))
        {
            SqlWhere += base.Base_GetBasicColumnWhere(this.bas_searchfield.SelectedValue, this.search_text.Text);
        }
        if (s_Text != "")
        {
            if (this.matchtype1.Checked == true)//and
            {
                s_Type = "0";
            }
            if (this.matchtype2.Checked == true)
            {
                s_Type = "1";
            }
            SqlWhere += base.Base_GetAdvWhere(s_Fields, s_Condition, s_Text, s_Type);
        }
        
        KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
        string s_SonID = Bll_ProductsDetails.GetSonIDs("M130703042640846");
        s_SonID = s_SonID.Replace(",", "','");
        SqlWhere += " and ProductsType in ('" + s_SonID + "') ";
        this.BeginQuery(SqlWhere);
        this.QueryForDataSet();
        DataSet ds = Dts_Result;
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }



    public void btnBasicSearch_Click(object sender, EventArgs e)
    {
        this.advSearch.Style["display"] = "none";
        this.Search_basic.Style["display"] = "block";
        this.DataShows();
    }
    public void btnAdvancedSearch_Click(object sender, EventArgs e)
    {
        this.Search_basic.Style["display"] = "none";
        this.advSearch.Style["display"] = "block";

        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string[] arr_Fields = s_Fields.Split(',');
        string[] arr_Condition = s_Condition.Split(',');
        string[] arr_Text = s_Text.Split(',');
        this.Fields.SelectedValue = arr_Fields[0];
        this.Condition.SelectedValue = arr_Condition[0];
        this.Srch_value.Text = arr_Text[0];
        s_AdvShow = Base_GetAdvShowHtml(arr_Fields, arr_Condition, arr_Text);
        this.DataShows();
    }

    public string BaseGetIC(string s_ProductsBarCode)
    {
        string s_Return="-";
        this.BeginQuery("Select top 1 * from Xs_Products_Prodocts a join KNet_Sys_Products b on a.XPP_ProductsBarCode=b.ProductsBarCode where XPP_FaterBarCode='" + s_ProductsBarCode + "' and b.ProductsMainCategory='129682169809390852' ");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            s_Return = Dtb_Result.Rows[0]["ProductsEdition"].ToString();
        }
        return s_Return;
    }
    public string GetState(string s_ProductsBarCode, int s_Del)
    {
        string s_Return = "";
        try
        {

            if (s_Del == 1)
            {
                string JSD = "KnetProductsSetting.aspx?ID=" + s_ProductsBarCode + "&Model=IsDel";
                s_Return = "<a href=\"" + JSD + "\" onclick=\"\"  ><font color=red>停用</font></a>";
            }
            else
            {
                string JSD = "KnetProductsSetting.aspx?ID=" + s_ProductsBarCode + "&Model=IsDel";
                s_Return = "<a href=\"" + JSD + "\" onclick=\"\" >启用</a>";
            }
        }
        catch
        { }
        return s_Return;
    }
    public string GetProductsType(string s_ID)
    {
        string s_Return="";
        try
        {
            KNet.BLL.PB_Basic_ProductsClass Bll = new KNet.BLL.PB_Basic_ProductsClass();
            s_Return = Bll.GetProductsName(s_ID);
        }
        catch
        { }
        return s_Return;
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }

    protected void Lbl_Spce_Click(object sender, EventArgs e)
    {
        string UploadPath = "../../UpFile/Products/型号管理型号命名规则.doc";  //上传文件
        Response.Redirect(UploadPath);
    }
}

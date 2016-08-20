using System;
using System.Data;
using System.Data.SqlClient;
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

public partial class Knet_Web_System_KnetProductsSetting_Details : BasePage
{
    public string s_MyTable_Detail = "", s_ProductsTable_Detail = "", s_ProductsTable_BomDetail = "", s_ProductsRC="";
    public string s_OrderStyle = "", s_DetailsStyle = "", s_RC_ProductsBarCode="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("查看产品") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            this.ShowDetails();
        }
    }

    /// <summary>
    /// 获取记录数据
    /// </summary>
    protected void ShowDetails()
    {
        string s_ProductsPattern = Request.QueryString["ProductsPattern"] == null ? "" : Request.QueryString["ProductsPattern"].ToString().Trim();
        string s_KSP_Mould = Request.QueryString["KSP_Mould"] == null ? "" : Request.QueryString["KSP_Mould"].ToString().Trim();
        this.ProductsPattern.Text = s_ProductsPattern;
        this.Lbl_Mould.Text = base.Base_GetProdutsName_Link(s_KSP_Mould);


        KNet.BLL.KNet_Sys_Products bll = new KNet.BLL.KNet_Sys_Products();
        string SqlWhere = " 1=1 ";
        AdminloginMess AM = new AdminloginMess();
        if (s_ProductsPattern != "")
        {
            SqlWhere += " and ProductsPattern='" + s_ProductsPattern + "'";
        }
        if (s_KSP_Mould != "")
        {
            SqlWhere += " and KSP_Mould='" + s_KSP_Mould + "'";
        }
        DataSet ds = bll.GetList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();

    }



    public string BaseGetIC(string s_ProductsBarCode)
    {
        string s_Return = "-";
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
        string s_Return = "";
        try
        {
            KNet.BLL.PB_Basic_ProductsClass Bll = new KNet.BLL.PB_Basic_ProductsClass();
            s_Return = Bll.GetProductsName(s_ID);
        }
        catch
        { }
        return s_Return;
    }
    /// <summary>
    /// 字典里是否存在产品
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetKNet_Sys_ProductsYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ProductsBarCode,ProductsName from KNet_Sys_Products where ProductsBarCode='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}

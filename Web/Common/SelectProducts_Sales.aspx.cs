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
using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 产品选择
/// </summary>
public partial class Knet_Common_SelectProducts_Sales : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "合同评审 产品选择";

        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                DataSet ds = KNet.Common.KNet_Static_BigClass.GetBigInfo();
                string BigNo, CateName;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    BigNo = ds.Tables[0].Rows[i]["BigNo"].ToString();
                    CateName = ds.Tables[0].Rows[i]["CateName"].ToString();
                    this.BigClass.Items.Add(new ListItem(CateName, BigNo));
                }
                this.BigClass.Value = "129678733470295462";
                this.SmallClass.Disabled = true;
                string s_CustomerValue=Request.QueryString["CustomerValue"].ToString()==null?"":Request.QueryString["CustomerValue"].ToString();
                this.CustomerName.Text = "客户名称：" + "<font Color='red'>" + base.Base_GetCustomerName(s_CustomerValue) + "</font>";
                if (Request.QueryString["ContractNo"] != null)
                {

               
                        ViewState["SortOrder"] = "ProductsAddTime";
                        ViewState["OrderDire"] = "Desc";
                        this.Button2.Attributes.Add("onclick", "return confirm('您确定要把所选择的记录添加到合同明细记录吗？')");

                        this.DataShows();
                        this.RowOverYN();

                        this.DataShowssdgsdg();
                }
                else
                {
                    Response.Write("<script language=javascript>alert('非法请求参数2！');window.close();</script>");
                    Response.End();
                }
            }
        }
    }
    /// <summary>
    /// 是不是有记录
    /// </summary>
    protected void RowOverYN()
    {
        if (GridView1.Rows.Count == 0) //如果没有记录
        {
            this.Button2.Enabled = false;
            this.Button3.Enabled = false;
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        string s_CustomerValue = Request.QueryString["CustomerValue"].ToString() == null ? "" : Request.QueryString["CustomerValue"].ToString();
        KNet.BLL.KNet_Sys_Products bll = new KNet.BLL.KNet_Sys_Products();
        this.BeginQuery("Select * from Xs_Customer_Products where XCP_CustomerID='" + s_CustomerValue + "' ");
        this.QueryForDataTable();
        DataTable Dtb_Table = this.Dtb_Result;
        string s_Sql = "select distinct a.ID,a.ProductsBarCode,a.ProductsName,a.ProductsPattern,a.ProductsMainCategory,a.ProductsUnits,a.ProductsCostPrice,a.ProductsSellingPrice,isnull(c.Contract_SalesUnitPrice,0) as Contract_SalesUnitPrice,a.ProductsEdition ";
        s_Sql += "from KNet_Sys_Products a left join Xs_Customer_Products b on b.XCP_ProductsID=a.ProductsBarCode";
        s_Sql += " left join KNet_Sales_ContractList_Details c on c.ProductsBarCode=a.ProductsBarCode  left join KNet_Sales_ContractList d on d.ContractNo=c.ContractNo ";

        string SqlWhere = " where KSP_Del='0' ";



        if (this.BigClass.Value != "0")
        {
            SqlWhere = SqlWhere + " and  a.ProductsMainCategory = '" + this.BigClass.Value + "' ";
        }
        if (this.SmallClass.Value != "0")
        {
            SqlWhere = SqlWhere + " and  a.ProductsSmallCategory = '" + this.SmallClass.Value + "' ";
        }

        if (this.SeachKey.Text != "")
        {
            SqlWhere = SqlWhere + " and ( a.ProductsName like '%" + this.SeachKey.Text + "%' or a.ProductsBarCode  like '%" + this.SeachKey.Text + "%' or a.ProductsPattern  like '%" + this.SeachKey.Text + "%' )";
        }
        if (Dtb_Table.Rows.Count > 0)
        {

            SqlWhere += " and XCP_CustomerID='" + s_CustomerValue + "' ";
            //and d.CustomerValue='" + s_CustomerValue + "'
        }

        this.BeginQuery(s_Sql + SqlWhere);
        this.QueryForDataSet();
        DataSet ds = this.Dts_Result;

        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();

    }

    /// <summary>
    /// 确定选择（Y）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {

        KNet.BLL.KNet_Sales_ContractList_Details BLL = new KNet.BLL.KNet_Sales_ContractList_Details();
            string cal = this.addDetails();
            if (cal == "")
            {
                AlertAndGoBack("您没有选择要操作的记录!");
            }
            else
            {
                AdminloginMess LogAM = new AdminloginMess();
                LogAM.Add_Logs("销售管理--->合同评审--->添加合同评审明细记录 操作成功！");
                base.ReflashWindows(this.GetType());//刷新父窗口
                this.DataShows();
                this.RowOverYN();
                this.DataShowssdgsdg();
            }
    }

    /// <summary>
    /// 添加到明细记录
    /// </summary>
    /// <param name="BaoPriceNo"></param>
    /// <param name="ProductsName"></param>
    /// <param name="ProductsBarCode"></param>
    /// <param name="ProductsPattern"></param>
    /// <param name="ProductsUnits"></param>
    /// <param name="BaoPriceAmount"></param>
    /// <param name="BaoPriceUnitPrice"></param>
    /// <param name="BaoPriceDiscount"></param>
    /// <param name="BaoPriceTotalNet"></param>
    /// <param name="BaoPriceRemarks"></param>
    protected string addDetails()
    {
        try
        {

            string cal = "";
            string s_ContractNo = Request.QueryString["ContractNo"].Trim();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (cb.Checked == true)
                {

                    KNet.Model.KNet_Sales_ContractList_Details model = new KNet.Model.KNet_Sales_ContractList_Details();
                    KNet.BLL.KNet_Sales_ContractList_Details BLL = new KNet.BLL.KNet_Sales_ContractList_Details();

                    int i_Number = int.Parse(((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Number")).Text == "" ? "0" : ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Number")).Text);
                    decimal d_Price = decimal.Parse(((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Price")).Text);
                    string s_Remark = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Remark")).Text;
                    string s_ProductsBarCode = GridView1.Rows[i].Cells[1].Text.ToString();
                    string s_ProductsName= GridView1.Rows[i].Cells[2].Text.ToString();
                    string s_ProductsPattern = GridView1.Rows[i].Cells[3].Text.ToString();
                    string s_ProductsUnits = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_UnitValue")).Text;
                    decimal d_CostPrice = decimal.Parse(((TextBox)GridView1.Rows[i].Cells[0].FindControl("ProductsCostPrice")).Text.Replace("¥", "").Trim() == "" ? "0" : ((TextBox)GridView1.Rows[i].Cells[0].FindControl("ProductsCostPrice")).Text.Replace("¥", "").Trim());
   
                    model.ContractNo = s_ContractNo;
                    model.ProductsName = s_ProductsName;
                    model.ProductsBarCode = s_ProductsBarCode;
                    model.ProductsPattern = s_ProductsPattern;
                    model.ProductsUnits = s_ProductsUnits;
                    model.ContractAmount = i_Number;

                    //成本区
                    model.ContractUnitPrice = d_CostPrice;
                    model.ContractDiscount = 0;
                    model.ContractTotalNet = d_CostPrice * i_Number;

                    //销售区
                    model.Contract_SalesUnitPrice = d_Price;
                    model.Contract_SalesDiscount = 0;
                    model.Contract_SalesTotalNet = d_Price * i_Number;

                    model.ContractRemarks = s_Remark;
                    model.OwnallPID = "";
                    try
                    {
                        if (BLL.Exists(s_ContractNo, s_ProductsBarCode, "") == false)
                        {
                            BLL.Add(model);
                        }
                        else
                        {
                            BLL.UpdateB(model);
                        }
                    }
                    catch { throw; }
                    cal += GridView1.DataKeys[i].Value.ToString();
                }
            }

            return cal;
        }
        catch
        {
            throw;
            return "";
        }
    }
    /// <summary>
    /// 取消所有已选中列（Y）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gr in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gr.Cells[0].FindControl("Chbk");
                chk.Checked = false;
            }
            GridView1.EditIndex = -1;
            this.DataShows();
        }
        catch { }
    }


    /// <summary>
    /// 返回大类名称（Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetBigCateNane(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,BigNo,CateName from KNet_Sys_BigCategories where BigNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["CateName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 页内 搜索 （Y）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click1(object sender, EventArgs e)
    {
        this.DataShows();
        this.RowOverYN();
    }


    /// <summary>
    /// 明细产品绑定
    /// </summary>
    protected void DataShowssdgsdg()
    {
        KNet.BLL.KNet_Sales_BaoPriceList_Details bll = new KNet.BLL.KNet_Sales_BaoPriceList_Details();
        string SqlWhere = " 1=1 ";

        if (Request.QueryString["BaoPriceNo"] != null && Request.QueryString["BaoPriceNo"] != "")
        {
            string BaoPriceNo = Request.QueryString["BaoPriceNo"].ToString().Trim();
            SqlWhere = SqlWhere + " and  BaoPriceNo = '" + BaoPriceNo + "' ";
        }
        else
        {
            SqlWhere = SqlWhere + " and 2=1 ";
        }
        using (DataSet ds = bll.GetList(SqlWhere))
        {
            GridView2.DataSource = ds;
            GridView2.DataKeyNames = new string[] { "ID" };
            GridView2.DataBind();
        }
    }

    /// <summary>
    /// 确定完成
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button4_Click(object sender, EventArgs e)
    {
        StringBuilder s = new StringBuilder();
        s.Append("<script language=javascript>" + "\n");
        s.Append("window.opener.refresh();" + "\n");
        s.Append("window.focus();" + "\n");
        s.Append("window.opener=null;" + "\n");
        s.Append("window.close();" + "\n");
        s.Append("</script>");
        Type cstype = this.GetType();
        ClientScriptManager cs = Page.ClientScript;
        string csname = "ltype";
        if (!cs.IsStartupScriptRegistered(cstype, csname))
            cs.RegisterStartupScript(cstype, csname, s.ToString());
    }
}

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
        this.Page.Title = "订单评审 产品选择";

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
                string s_CustomerValue = Request.QueryString["CustomerValue"].ToString() == null ? "" : Request.QueryString["CustomerValue"].ToString();

                this.CustomerName.Text = "客户名称：" + "<font Color='red'>" + base.Base_GetCustomerName(s_CustomerValue) + "</font>";
                this.DataShows();

            }
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
        string s_Sql = "select distinct a.ID,a.ProductsBarCode,a.ProductsName,a.ProductsPattern,a.ProductsMainCategory,a.ProductsUnits,a.ProductsCostPrice,a.ProductsSellingPrice,isnull(c.Contract_SalesUnitPrice,0) as Contract_SalesUnitPrice,a.ProductsEdition,a.KSP_SampleID,isnull(e.v_LeftNumer,0) as v_LeftNumer,KSP_Code,a.ProductsType ";
        s_Sql += "from KNet_Sys_Products a left join Xs_Customer_Products b on b.XCP_ProductsID=a.ProductsBarCode ";
        s_Sql += " left join KNet_Sales_ContractList_Details c on c.ProductsBarCode=a.ProductsBarCode  left join KNet_Sales_ContractList d on d.ContractNo=c.ContractNo ";
        s_Sql += " left join v_SalesContrac_LeftNumber e on e.V_ProductsBarCode=a.ProductsBarCode and XCP_CustomerID=V_CustomerValue ";

        string SqlWhere = " where KSP_Del='0' ";
        if (this.SeachKey.Text != "")
        {
            SqlWhere = SqlWhere + " and ( a.ProductsName like '%" + this.SeachKey.Text + "%' or a.ProductsBarCode  like '%" + this.SeachKey.Text + "%' or a.ProductsEdition  like '%" + this.SeachKey.Text + "%' )";
        }
        if (Dtb_Table.Rows.Count > 0)
        {
            SqlWhere += " and XCP_CustomerID='" + s_CustomerValue + "' ";
        }
        //电池
        string s_sql1="";
        s_sql1 += "union all Select a.ID,a.ProductsBarCode,a.ProductsName,a.ProductsPattern,a.ProductsMainCategory,a.ProductsUnits,a.ProductsCostPrice,a.ProductsSellingPrice,0,a.ProductsEdition,a.KSP_SampleID,0,KSP_Code ,a.ProductsType";
        s_sql1 += " from KNet_Sys_Products a  where ProductsType='M130704050932527' ";

        this.BeginQuery(s_Sql + SqlWhere+s_sql1);
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
        string s_Return = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                TextBox Tbx_ProductsBarCode = (TextBox)GridView1.Rows[i].Cells[0].FindControl("ProductsBarCode");
                TextBox Tbx_Price = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Price");
                TextBox Tbx_Number = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Number");
                TextBox Tbx_BNumber = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_BNumber");
                TextBox Tbx_OrderNumber = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_OrderNumber");
                TextBox Tbx_MaterNumber = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_MaterNumber");
                TextBox Tbx_Remark = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Remark");
                CheckBox Chk_IsFollow = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chk_IsFollow");
                TextBox Tbx_PlanNumber = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_PlanNumber");
                TextBox Tbx_MaterPattern = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_MaterPattern");
                
                decimal d_Money = decimal.Parse(Tbx_Number.Text == "" ? "0" : Tbx_Number.Text.ToString()) * decimal.Parse(Tbx_Price.Text == "" ? "0" : Tbx_Price.Text.ToString());
                string s_IsFollow = "";
                if (Chk_IsFollow.Checked == true)
                {
                    s_IsFollow = "是";
                }
                s_Return += Tbx_ProductsBarCode.Text + "#" + Tbx_Number.Text + "#" + Tbx_BNumber.Text + "#" + Tbx_Price.Text + "#" + d_Money.ToString() + "#" + Tbx_PlanNumber.Text + "#" + Tbx_OrderNumber.Text + "#" + Tbx_MaterNumber.Text + "#" + Tbx_MaterPattern.Text + "#" + s_IsFollow + "#" + Tbx_Remark.Text + "|";
            }
        }
        StringBuilder s = new StringBuilder();
        s.Append("<script language=javascript>\n");
        s.Append("window.returnValue='" + s_Return + "';\n");
        s.Append("window.close();" + "\n");
        s.Append("</script>");
        Type cstype = this.GetType();
        ClientScriptManager cs = Page.ClientScript;
        string csname = "ltype";
        if (!cs.IsStartupScriptRegistered(cstype, csname))
            cs.RegisterStartupScript(cstype, csname, s.ToString());
    }

    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            KNet.BLL.KNet_Sys_Products Bll = new KNet.BLL.KNet_Sys_Products();

            string s_ID = this.GridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值

            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            CheckBox Chk_IsFollow = (CheckBox)e.Row.Cells[1].FindControl("Chk_IsFollow");
            KNet.BLL.KNet_Sys_Products Bll_Pro = new KNet.BLL.KNet_Sys_Products();
            KNet.Model.KNet_Sys_Products Model_Pro = Bll.GetModel(s_ID);

            string s_Bool = "是";
            try
            {
                s_Bool = base.base_GetProductsDemoState(Model_Pro.KSP_SampleId.ToString());
            }
            catch { }
            if (s_Bool == "是")
            {
                cb.Enabled = true;
            }
            else
            {
                cb.Enabled = false;
            }
            string s_type = Model_Pro.ProductsType;
            if (s_type == "M130704050932527")//电池
            {
                Chk_IsFollow.Enabled = true;
                Chk_IsFollow.Checked = true;

            }
            else
            {
                Chk_IsFollow.Enabled = false;
            }
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
    }
}

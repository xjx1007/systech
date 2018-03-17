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
/// 仓库管理——库存流水账
/// </summary>
public partial class KNet_WareHouse_Ownall_Water_New : BasePage
{
    public string s_DivStyle = "";
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("查看售后流水帐") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {

                ViewState["SortOrder"] = "WaterDateTime";
                ViewState["OrderDire"] = "Desc";
                this.DataShows();

                base.Base_DropWareHouseBind(this.HouseNoDataList, "  HouseName like '%修%' ");
                base.Base_DropBindSearch(this.bas_searchfield, "v_Store_Details");
                base.Base_DropBindSearch(this.Fields, "v_Store_Details");
                base.Base_DropBasicCodeBind(this.WaterTypeDropDownList, "146");
            }
        }

    }

    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        AdminloginMess AM = new AdminloginMess();
        string s_Sql = "";

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_ProductsBarCode = Request["ProductsBarCode"] == null ? "" : Request["ProductsBarCode"].ToString();
        string s_HouseNo = Request["HouseNo"] == null ? "" : Request["HouseNo"].ToString();
        string s_Type = "";

        string SqlWhere = "( " + AM.MyDoSqlWith_Do + " ) ";

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
        if (s_ProductsBarCode != "")
        {
            SqlWhere = SqlWhere + " and ProductsBarCode='" + s_ProductsBarCode + "'";
        }
        if (s_HouseNo != "")
        {

            SqlWhere = SqlWhere + " and  HouseNo = '" + s_HouseNo + "' ";
        }
        if (this.HouseNoDataList.SelectedValue != "")
        {
            SqlWhere = SqlWhere + " and  HouseNo = '" + this.HouseNoDataList.SelectedValue + "' ";
        }
        if (this.StartDate.Text != "")
        {
            SqlWhere = SqlWhere + " and  DirectInDateTime >= '" + this.StartDate.Text + "' ";
        }
        if (this.EndDate.Text != "")
        {
            SqlWhere = SqlWhere + " and  DirectInDateTime <= '" + this.EndDate.Text + "' ";
        }
        if (this.SeachKey.Text != "")
        {
            string KSeachKey = this.SeachKey.Text;
            SqlWhere = SqlWhere + " and ProductsBarCode in ( select ProductsBarCode from KNet_Sys_Products where ProductsName like '%" + KSeachKey + "%' or ProductsPattern  like '%" + KSeachKey + "%' or ProductsEdition  like '%" + KSeachKey + "%' )";
        }
        if (this.WaterTypeDropDownList.SelectedValue!= "")
        {
            SqlWhere = SqlWhere + " and  type = '" + this.WaterTypeDropDownList.SelectedValue + "' ";
        }
        SqlWhere += " and HouseNo in (Select HouseNO from KNet_Sys_WareHouse where  HouseName like '%修%')  Order by DirectInDateTime desc";
        s_Sql = " Select TypeName,DirectInDateTime,Type,HouseNo,ProductsPattern,ProductsName,ProductsUnits,DirectInAmount,DirectInUnitPrice,DirectInTotalNet,ProductsBarCode from v_Store Where " + SqlWhere;
        this.BeginQuery(s_Sql);
        this.QueryForDataSet();
        DataSet ds = this.Dts_Result;
            //--End分页-----
            GridView1.DataSource = ds;
            GridView1.DataBind();
            //净值合计
            decimal OrderTotalNetAll = 0;
            //数量合计
            int OrderAmountALL = 0;
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                DataRowView mydrv = ds.Tables[0].DefaultView[i];
               // OrderTotalNetAll = OrderTotalNetAll + decimal.Parse(mydrv["DirectInTotalNet"].ToString());
                try
                {
                    OrderAmountALL = OrderAmountALL + int.Parse(mydrv["DirectInAmount"].ToString());

                }
                catch
                { }

                this.HeXinQ.Text = "流水账数量合计:<B><font color=blue>" + OrderAmountALL.ToString() + "</font></B>&nbsp;&nbsp;&nbsp;流水账净值合计:<B><font color=blue>" + OrderTotalNetAll.ToString("N") + "</font></B>";
            }
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

    /// <summary>
    /// 选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void HouseNoDataList_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }

    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button4_Click(object sender, EventArgs e)
    {
        DataShows();
    }

    /// <summary>
    /// 按流水类型分组
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }



}

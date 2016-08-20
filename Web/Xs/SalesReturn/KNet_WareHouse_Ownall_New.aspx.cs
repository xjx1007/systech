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
/// 仓库管理——总台账
/// </summary>
public partial class Knet_Web_WareHouse_KNet_WareHouse_Ownall : BasePage
{
    public string s_DivStyle = "";
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("查看售后库存总账") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                ViewState["SortOrder"] = "StorageTime";
                ViewState["OrderDire"] = "Desc";
                this.DataShows();
                base.Base_DropWareHouseBind(this.HouseNoDataList, AM.MyDoSqlWith_Do);

                base.Base_DropBindSearch(this.bas_searchfield, "v_Store");
                base.Base_DropBindSearch(this.Fields, "v_Store");

            }
        }

    }

    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {

        AdminloginMess AM = new AdminloginMess();

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";

        string SqlWhere = "( " + AM.MyDoSqlWith_Do + " )";

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
        if (this.HouseNoDataList.SelectedValue!= "")
        {
            SqlWhere = SqlWhere + " and  HouseNo = '" + this.HouseNoDataList.SelectedValue + "' ";
        }

        if (Request["BarCode"] != null && Request["BarCode"] != "")
        {
            string BarCode = Request.QueryString["BarCode"].ToString().Trim();

            SqlWhere = SqlWhere + " and  ProductsBarCode = '" + BarCode + "' ";
        }
        string s_Sql = "Select Sum(DirectInAmount) as WareHouseAmount,Sum(case when type in ('101','102','106') then DirectInAmount else 0 end) as StorageVolume,Sum(case when type in ('103','104','105') then -DirectInAmount else 0 end) as ShippedQuantity,Sum(case when type in ('107') then DirectInAmount else 0 end) PdQuantity,Sum(case when type in ('108') then DirectInAmount else 0 end) XhQuantity,Sum(case when type in ('109') then DirectInAmount else 0 end) ScQuantity,Sum(DirectInTotalNet) as WareHouseTotalNet,HouseNo,ProductsBarCode from V_Store Where  HouseNo in (Select HouseNO from KNet_Sys_WareHouse where  HouseName like '%修%') And " + SqlWhere;
        s_Sql = s_Sql + "Group by HouseNo,ProductsBarCode";
        this.BeginQuery(s_Sql);
        this.QueryForDataSet();
        DataSet ds =Dts_Result;
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

                //OrderTotalNetAll = OrderTotalNetAll + decimal.Parse(mydrv["WareHouseTotalNet"].ToString());
                try
                {
                    OrderAmountALL = OrderAmountALL + int.Parse(mydrv["WareHouseAmount"].ToString());

                }
                catch
                { }

                this.HeXinQ.Text = "总库存数量合计:<B><font color=blue>" + OrderAmountALL.ToString() + "</font></B>&nbsp;&nbsp;&nbsp;总库存净值合计:<B><font color=blue>" + OrderTotalNetAll.ToString("N") + "</font></B>";
            }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="objDatetime"></param>
    /// <returns></returns>
    protected string getintdateshu(string  objDatetime)
    {
        try
        {
            string time_Now = DateTime.Now.ToString();    //获取当前时间；  
            return (DateTime.Parse(time_Now) - DateTime.Parse(objDatetime)).TotalDays.ToString("F2") + "天"; 
        }
        catch
        {
            return "--";
        }
    }


    /// <summary>
    /// 返回库存平均价格
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetPinPrice(string WareHouseTotalNet, string WareHouseAmount)
    {
        decimal ss = 0;
        try
        {
            ss = decimal.Parse(WareHouseTotalNet == "" ? "0" : WareHouseTotalNet) / int.Parse(WareHouseAmount);
        }
        catch { ss = 0; }

        return base.FormatNumber(ss.ToString(),3);
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
    /// 开始搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }

    /// <summary>
    /// 删除产品记录为零的记录
    /// </summary>
    /// <param name="HouseNo"></param>
    protected void DelOReerData()
    {
        string dosql = "DELETE [KNet_WareHouse_Ownall] where WareHouseAmount=0 and WareHouseTotalNet=0";
        DbHelperSQL.ExecuteSql(dosql);
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

}

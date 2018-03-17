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
            if (AM.CheckLogin("查看库存总账台") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {


                BuildTree("1", null);
                this.TreeView1.CollapseAll();
                this.TreeView1.Nodes[0].Expand();
                this.TreeView1.Nodes[0].Select();
                ViewState["SortOrder"] = "StorageTime";
                ViewState["OrderDire"] = "Desc";
                this.DataShows();
                base.Base_DropWareHouseBind(this.HouseNoDataList, "   KSW_Type=0");

                base.Base_DropBindSearch(this.bas_searchfield, "v_Store");
                base.Base_DropBindSearch(this.Fields, "v_Store");
            }
        }

    }

    public void BuildTree(string s_ID, TreeNode tree)
    {
        try
        {
            KNet.BLL.PB_Basic_ProductsClass Bll = new KNet.BLL.PB_Basic_ProductsClass();
            TreeNode treeMainNode = new TreeNode();
            KNet.BLL.PB_Basic_ProductsClass bll = new KNet.BLL.PB_Basic_ProductsClass();
            if (tree == null)
            {
                KNet.Model.PB_Basic_ProductsClass Model = bll.GetModel(s_ID);
                this.TreeView1.Nodes.Clear();
                treeMainNode.Text = Model.PBP_Name;
                treeMainNode.Value = Model.PBP_ID;
                this.TreeView1.Nodes.Add(treeMainNode);
            }
            else
            {
                treeMainNode = tree;
            }
            DataSet Dts_Table = bll.GetList(" PBP_FaterID='" + s_ID + "'");

            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    TreeNode treeNode1 = new TreeNode();
                    treeNode1.Text = Dts_Table.Tables[0].Rows[i]["PBP_Name"].ToString();
                    treeNode1.Value = Dts_Table.Tables[0].Rows[i]["PBP_ID"].ToString();
                    treeMainNode.ChildNodes.Add(treeNode1);
                    BuildTree(Dts_Table.Tables[0].Rows[i]["PBP_ID"].ToString(), treeNode1);
                }
            }
        }
        catch
        { }
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.DataShows();
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

        string SqlWhere = " 1=1 ";

        bool b_Where = false;
        if (s_WhereID != "M160317024031403")
        {
            if (s_WhereID != "")
            {
                SqlWhere += Base_GetBasicWhere(s_WhereID);

            }
            b_Where = true;
        }


        if ((this.bas_searchfield.SelectedValue != "") && (search_text.Text != ""))
        {
            SqlWhere += base.Base_GetBasicColumnWhere(this.bas_searchfield.SelectedValue, this.search_text.Text);

            b_Where = true;
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

            b_Where = true;
        }
        if (this.HouseNoDataList.SelectedValue != "")
        {
            SqlWhere = SqlWhere + " and  HouseNo = '" + this.HouseNoDataList.SelectedValue + "' ";
            b_Where = true;
        }

        if (Request["BarCode"] != null && Request["BarCode"] != "")
        {
            string BarCode = Request.QueryString["BarCode"].ToString().Trim();

            SqlWhere = SqlWhere + " and  ProductsBarCode = '" + BarCode + "' ";
            b_Where = true;
        }

        if (this.TreeView1.SelectedNode.Value != "1")
        {
            KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
            string s_SonID = Bll_ProductsDetails.GetSonIDs(this.TreeView1.SelectedNode.Value);
            s_SonID = s_SonID.Replace(",", "','");
            SqlWhere += " and ProductsType in ('" + s_SonID + "') ";
            b_Where = true;
        }
        string s_Sql = "Select isnull(Sum(DirectInAmount),0) as WareHouseAmount,Sum(case when type in ('101','102','106') then DirectInAmount else 0 end) as StorageVolume,Sum(case when type in ('103','104','105') then -DirectInAmount else 0 end) as ShippedQuantity,Sum(case when type in ('107') then DirectInAmount else 0 end) PdQuantity,Sum(case when type in ('108') then DirectInAmount else 0 end) XhQuantity,Sum(case when type in ('109') then DirectInAmount else 0 end) ScQuantity,Sum(DirectInTotalNet) as WareHouseTotalNet,HouseNo,ProductsBarCode,(Select Top 1 SEM_RkTime from Sc_Expend_Manage_MaterDetails a join Sc_Expend_Manage b on a.SED_SEMID=b.SEM_ID and SED_ProductsBarCode=ProductsBarCode order by SEM_RkTime desc) LastHlTime  from V_Store Where " + SqlWhere;
        s_Sql = s_Sql + " and  HouseNo in(select HouseNo from KNet_Sys_WareHouse  where  KSW_Type=0  ) Group by HouseNo,ProductsBarCode";


        if (s_WhereID == "M160317024031403")
        {
            s_Sql += " having " + Base_GetBasicWhere(s_WhereID);
        }

        this.BeginQuery(s_Sql);
        this.QueryForDataSet();
        DataSet ds = Dts_Result;
        if (b_Where)
        {

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
                if (mydrv["WareHouseAmount"].ToString() != "0")
                {
                    try
                    {
                        OrderTotalNetAll = OrderTotalNetAll + decimal.Parse(mydrv["WareHouseTotalNet"].ToString());
                    }
                    catch { }
                    try
                    {
                        OrderAmountALL = OrderAmountALL + int.Parse(base.FormatNumber1(mydrv["WareHouseAmount"].ToString(), 0));
                    }
                    catch { }
                }

            }
            this.HeXinQ.Text = "总库存数量合计:<B><font color=blue>" + OrderAmountALL.ToString() + "</font></B>&nbsp;&nbsp;&nbsp;总库存净值合计:<B><font color=blue>" + OrderTotalNetAll.ToString("N") + "</font></B>";

        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="objDatetime"></param>
    /// <returns></returns>
    protected string getintdateshu(string objDatetime)
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

        return base.FormatNumber(ss.ToString(), 3);
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
    public string GetQlNumber(string s_HouseNo,string s_ProductsBarCode)
    {
        string s_Return = "";
        try
        {
            string s_OrderLeftNumber = base.Base_GetOrderWrkNumber(s_ProductsBarCode, s_HouseNo) == "-" ? "0" : base.Base_GetOrderWrkNumber(s_ProductsBarCode, s_HouseNo);
            string s_WareHouseNumber = base.Base_GetHouseAndNumber1(s_ProductsBarCode, s_HouseNo) == "-" ? "0" : base.Base_GetHouseAndNumber1(s_ProductsBarCode, s_HouseNo);
            string s_NeedNumber = base.Base_GetHouseAndNeedNumber1(s_ProductsBarCode, s_HouseNo) == "-" ? "0" : base.Base_GetHouseAndNeedNumber1(s_ProductsBarCode, s_HouseNo);
            string s_Number = GetLefNumber(s_WareHouseNumber, s_OrderLeftNumber, s_NeedNumber);
            s_Return = "<a href=\"/Web/Sc/Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + s_ProductsBarCode + "&HouseNo=" + s_HouseNo + "\" target=\"_blank\">" + s_Number + "</a>";
        }
        catch
        { }
        return s_Return;
    }

    public string GetLefNumber(string s_KCNumber, string s_OrderNumber, string s_NeedNumber)
    {
        string s_return = "";
        try
        {
            decimal d_Left = decimal.Parse(s_NeedNumber.Trim()) - decimal.Parse(s_OrderNumber.Trim()) - decimal.Parse(s_KCNumber.Trim() );
            if (d_Left > 0)
            {
                s_return = "<font color=red>" + d_Left.ToString() + "</font>";
            }
            else
            {
                s_return = "<font color=green>" + Math.Abs(d_Left).ToString() + "</font>";
            }
        }
        catch
        { }
        return s_return;
    }

}

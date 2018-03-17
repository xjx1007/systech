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
/// 销售管理-----退货单 管理
/// </summary>
public partial class Knet_Web_Sales_Knet_Sales_Retrun_Manage_Manage : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("销售退货列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            //退货单查看
            if (AM.YNAuthority("删除销售退货") == false)
            {
                this.Btn_Del.Enabled = false;
            }
            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！\\n\\n注意：该删除会同时删除退货单产品明细记录.')");


            ViewState["SortOrder"] = "ReturnDateTime";
            ViewState["OrderDire"] = "Desc";
           // base.Base_DropBatchBind(this.Ddl_Batch, "KNet_Sales_ReturnList", "KSR_DutyPerson");
            base.Base_DropBindSearch(this.bas_searchfield, "KNet_Sales_ReturnList");
            base.Base_DropBindSearch(this.Fields, "KNet_Sales_ReturnList");
            this.DataShows();
        }

    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sales_ReturnList bll = new KNet.BLL.KNet_Sales_ReturnList();

        string SqlWhere = " 1=1 ";

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";
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
        SqlWhere = SqlWhere + " order by ReturnDateTime desc";
        DataSet ds = bll.GetList(SqlWhere);

        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ReturnNo" };
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

    protected void Ddl_Batch_TextChanged1(object sender, EventArgs e)
    {
        this.DataShows();
    }
    /// <summary>
    /// 查看 退货单 是否已审核
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetReceivCheckYNEitxt(string ReturnNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ReturnCheckYN,ReturnNo from KNet_Sales_ReturnList where ReturnNo='" + ReturnNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["ReturnCheckYN"].ToString() == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
    /// <summary>
    /// 批量删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_Del_Click(object sender, EventArgs e)
    {

        string sql = "delete from KNet_Sales_ReturnList where"; //删除发货单
        string sql2 = "delete from KNet_Sales_ReturnList_Details where"; //发货 明细

        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " ReturnNo='" + GridView1.DataKeys[i].Value.ToString() + "' or";

                KNet.BLL.KNet_Sales_ReturnList_Details BLL = new KNet.BLL.KNet_Sales_ReturnList_Details();
                DataSet ds = BLL.GetList(" ReturnNo='" + GridView1.DataKeys[i].Value.ToString() + "' ");

                for (int j = 0; j <= ds.Tables[0].Rows.Count - 1; j++)
                {
                    DataRowView mydrv = ds.Tables[0].DefaultView[j];

                    string ID = mydrv["ID"].ToString();
                    string ProductsBarCode = mydrv["ProductsBarCode"].ToString();
                    string OutWareNo = GetOutWareNo(GridView1.DataKeys[i].Value.ToString());

                    try
                    {
                        BLL.Delete(ID, OutWareNo, ProductsBarCode);
                    }
                    catch
                    { }
                }
            }
        }
        if (cal != "")
        {
            sql += cal.Substring(0, cal.Length - 3);
            sql2 += cal.Substring(0, cal.Length - 3);
        }
        else
        {
            sql = "";       //不删除
            sql2 = "";       //不删除
            Response.Write("<script language=javascript>alert('您没有选择要删除的记录!');history.back(-1);</script>");
            Response.End();
        }

        DbHelperSQL.ExecuteSql(sql);
        DbHelperSQL.ExecuteSql(sql2);

        AdminloginMess LogAM = new AdminloginMess();
        LogAM.Add_Logs("销售管理--->销售退货管理--->退货单删除 操作成功！");

        this.DataShows();
    }
    /// <summary>
    /// 返回关联发货单唯一值
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetOutWareNo(object ReturnNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,OutWareNo,ReturnNo from KNet_Sales_ReturnList where ReturnNo='" + ReturnNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["OutWareNo"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }



    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }




    /// <summary>
    /// 返回退货状态（0新退货申请，1退货洽谈中，2已终止退货，3已退回归库）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetReturnStateYN(object ReturnNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ReturnNo,ReturnState,ReturnCheckYN from KNet_Sales_ReturnList where ReturnNo='" + ReturnNo + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                int A = int.Parse(dr["ReturnState"].ToString());
                string Str = "--";
                switch (A)
                {
                    case 0:
                        Str = "<font color=#CC9900>新退货申请</font>";
                        break;
                    case 1:
                        Str = "<font color=blue>退货已接收</font>";
                        break;
                    case 2:
                        Str = "<font color=Red>已终止退货</font>";
                        break;
                    case 3:
                        Str = "<font color=#990000>已退回归库</font>";
                        break;
                    default:
                        Str = "--";
                        break;
                }
                return Str;
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 获取单明细数目 （Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu(string ReturnNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as IDS  from KNet_Sales_ReturnList_Details where ReturnNo='" + ReturnNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return int.Parse(dr["IDS"].ToString().Trim().ToString());
            }
            else
            {
                return -1;
            }
        }
    }

    /// <summary>
    /// 添加提示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string ContractNo = GridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            if (GetReceivCheckYNEitxt(ContractNo) == true)
            {
                cb.Enabled = false;
            }
            else
            {
                cb.Enabled = true;
            }
        }
    }
    /// <summary>
    /// 返回审核情况（Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetBaoPriceCheckYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ReturnNo,ReturnCheckYN,OutWareNo,ReturnType from KNet_Sales_ReturnList where ReturnNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["ReturnCheckYN"].ToString() == "True")
                {
                    string ReturnType = dr["ReturnType"].ToString();
                    string OutWareNo = dr["OutWareNo"].ToString();
                    string s_Return = "";
                    decimal d_DirectOutAmount=0,d_ReturnAmount=0;

                    if (ReturnType == "101")
                    {

                        this.BeginQuery("Select a.DirectInNo,isnull(Sum(b.DirectInAmount),0) as Number from KNet_WareHouse_DirectInto a join KNet_WareHouse_DirectInto_Details b on a.DirectInNo=b.DirectInNo where a.KWD_Type='102' and a.KWD_ReturnNo='" + aa + "' Group by a.DirectInNo ");
                        this.QueryForDataTable();
                        if (this.Dtb_Result.Rows.Count > 0)
                        {
                            d_DirectOutAmount = Decimal.Parse(Dtb_Result.Rows[0][1].ToString());
                        }

                        this.BeginQuery("Select a.ReturnNo,isnull(Sum(b.ReturnAmount),0) as Number from KNet_Sales_ReturnList a join KNet_Sales_ReturnList_Details b on a.ReturnNo=b.ReturnNo where a.ReturnNo='" + aa + "' Group by a.ReturnNo ");
                        this.QueryForDataTable();
                        if (this.Dtb_Result.Rows.Count > 0)
                        {
                            d_ReturnAmount = Decimal.Parse(Dtb_Result.Rows[0][1].ToString());
                        }
                        if (d_ReturnAmount > d_DirectOutAmount)
                        {
                            s_Return = "<a href=\"/Web/WareHouseIn/KNet_WareHouse_DirectInto_Add.aspx?ReturnNo=" + aa + "&Type=2\"><font Color=Red>部分入库</font></a>";

                        }
                        if (d_DirectOutAmount == 0)
                        {

                            s_Return = "<a href=\"/Web/WareHouseIn/KNet_WareHouse_DirectInto_Add.aspx?ReturnNo=" + aa + "&Type=2\"><font Color=Red>未入库</font></a>";

                        }
                        if (d_ReturnAmount == d_DirectOutAmount)
                        {
                            s_Return = "已入库";
                        }

                        if (d_ReturnAmount < d_DirectOutAmount)
                        {
                            s_Return = "<font Color=Green>已多入库</font>";
                        }
                    }
                    else
                    {

                        try
                        {
                            this.BeginQuery("Select a.DirectOutNo,isnull(Sum(b.DirectOutAmount),0) as Number from KNET_WareHouse_DirectOutList a join KNet_WareHouse_DirectOutList_Details b on a.DirectOutNo=b.DirectOutNo where a.KWD_ReturnNo='" + aa + "' Group by a.DirectOutNo ");
                        this.QueryForDataTable();
                        if (this.Dtb_Result.Rows.Count > 0)
                        {
                            d_DirectOutAmount = Decimal.Parse(Dtb_Result.Rows[0][1].ToString())*-1;
                        }}
                        catch
                        { }

                        this.BeginQuery("Select a.ReturnNo,isnull(Sum(b.ReturnAmount),0) as Number from KNet_Sales_ReturnList a join KNet_Sales_ReturnList_Details b on a.ReturnNo=b.ReturnNo where a.ReturnNo='" + aa + "' Group by a.ReturnNo ");
                        this.QueryForDataTable();
                        if (this.Dtb_Result.Rows.Count > 0)
                        {
                            d_ReturnAmount = Decimal.Parse(Dtb_Result.Rows[0][1].ToString());
                        }
                        if (d_ReturnAmount > d_DirectOutAmount)
                        {
                            s_Return = "<a href=\"/Web/Xs/SalesOut/Sales_ShipWareOut_Add.aspx?ShipNo=" + OutWareNo + "&ReturnNo=" + aa + "&Type=2\"><font Color=Red>部分入库</font></a>";

                        }
                        if (d_DirectOutAmount == 0)
                        {

                            s_Return = "<a href=\"/Web/Xs/SalesOut/Sales_ShipWareOut_Add.aspx?ShipNo=" + OutWareNo + "&ReturnNo=" + aa + "&Type=2\"><font Color=Red>未入库</font></a>";

                        }
                        if (d_ReturnAmount == d_DirectOutAmount)
                        {
                            s_Return = "已入库";
                        }

                        if (d_ReturnAmount < d_DirectOutAmount)
                        {
                            s_Return = "<font Color=Green>已多入库</font>";
                        }
                    }
                    return s_Return;
                }
                else
                {
                    if (Knet_Procure_OrdersList_Details_Shu(aa.ToString()) <= 0)
                    {
                        return "<a href=\"Knet_Sales_Retrun_Manage_AddDetails.aspx?ReturnNo=" + aa + "\"><img src=\"/images/Nodata.gif\"  border=\"0\"  title=\"未完成的退货单（没有明细记录）\" /></a>";
                    }
                    else
                    {
                        string JSD = "Knet_Sales_Retrun_Manage_View.aspx?ID=" + aa.ToString() + "";
                        string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=400,height=250');\"  title=\"点击进行审核操作\">审核</a>";
                        return StrPop;
                    }
                }
            }
            else
            {
                return "--";
            }
        }
    }



}

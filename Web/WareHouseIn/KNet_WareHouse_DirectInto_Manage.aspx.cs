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
/// 库存管理-----直接入库单 管理
/// </summary>
public partial class Knet_Web_WareHouse_KNet_WareHouse_DirectInto_Manage : BasePage
{
    public string s_AdvShow = "", s_Type="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            AdminloginMess AM = new AdminloginMess();
            if (s_Type != "")
            {
            //直接入库单删除
                if (AM.YNAuthority("售后入库列表") == false)
                {
                    AM.NoAuthority("售后入库列表");
                }
            }
            else
            {
                if (AM.YNAuthority("直接入库列表") == false)
                {
                    AM.NoAuthority("直接入库列表");
                }
            }
            //直接入库单删除
            if (AM.YNAuthority("删除直接入库") == false)
            {
                this.Btn_Del.Enabled = false;
            }
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！\\n\\n注意：该删除会同时删除入库单产品明细记录.')");
            base.Base_DropBindSearch(this.bas_searchfield, "KNet_WareHouse_DirectInto");
            base.Base_DropBindSearch(this.Fields, "KNet_WareHouse_DirectInto");
            this.DataShows();
            this.RowOverYN();
        }
    }
    /// <summary>
    /// 是不是有记录
    /// </summary>
    protected void RowOverYN()
    {
        if (GridView1.Rows.Count == 0) //如果没有记录
        {
            this.Btn_Del.Enabled = false;
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.KNet_WareHouse_DirectInto bll = new KNet.BLL.KNet_WareHouse_DirectInto();
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";
        string SqlWhere = " 1=1 ";
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
        if (Request.QueryString["Type"] == "2")
        {
            SqlWhere += " and KWD_Type='102'";
        }
        else if (Request.QueryString["Type"] == "3")
        {
            SqlWhere += " and KWD_Type='3'";
        }
        else if (Request.QueryString["Type"] == "5")
        {
            SqlWhere += " and KWD_Type='105'";
        }
        else
        {
            SqlWhere += " and KWD_Type<>'102' and KWD_Type<>'3' ";
        }
        
        SqlWhere = SqlWhere + " order by SystemDatetimes desc ";
        DataSet ds = bll.GetList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "DirectInNo" };
        GridView1.DataBind();
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

            string DirectInNo = this.GridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            KNet.BLL.KNet_WareHouse_DirectInto Bll = new KNet.BLL.KNet_WareHouse_DirectInto();
            KNet.Model.KNet_WareHouse_DirectInto Model = Bll.GetModelB(DirectInNo);
            if (Model.DirectInCheckYN != 0)
            {
                cb.Enabled = false;
            }
            else
            {
                cb.Enabled = true;
            }
        }
    }



    public string GetKDSateNameByDirectInto(string s_WareNo)
    {
        string s_Rturn = "";
        KNet.BLL.KNet_WareHouse_DirectInto BLL = new KNet.BLL.KNet_WareHouse_DirectInto();
        KNet.Model.KNet_WareHouse_DirectInto Model = BLL.GetModelB(s_WareNo);
        if (Model != null)
        {
            string s_KDName = Model.KWD_KDNameCode == null ? "" : Model.KWD_KDNameCode;
            string s_Code = Model.KWD_KDCode == null ? "" : Model.KWD_KDCode;
            string s_CodeName = Model.KWD_KDName == null ? "" : Model.KWD_KDName;
            string s_State = Model.KWD_KDState == null ? "" : Model.KWD_KDState;
            if ((s_State != "<Font Color=red>已签收</Font>") && (s_Code != ""))
            {
                String url = "http://api.ickd.cn/?com=" + s_KDName + "&nu=" + s_Code + "&id=F358C662FEC3E1CAA2C8C20DD2F9A448&type=json";
                string jsonString = "";
                this.BeginQuery("Select * from PB_Basic_Wl where PBW_Name='" + s_CodeName + "'");
                this.QueryForDataTable();
                if (this.Dtb_Result.Rows.Count > 0)
                {

                    if (this.Dtb_Result.Rows[0]["PBW_URL"].ToString() != "")
                    {
                        WebPage webInfo = new WebPage(this.Dtb_Result.Rows[0]["PBW_Url"].ToString() + s_Code);
                        string s_Detiles = webInfo.M_html.Replace("请输入运单编号", "");
                        if (s_Detiles.IndexOf("签收") > 0)
                        {
                            s_State = "<Font Color=red>已签收</Font>";
                        }
                        else if (s_Detiles.IndexOf("SORRY") > 0)
                        {
                            s_State = "<Font Color=Black>查询失败<Font Color=Blue>";
                        }
                        else
                        {
                            s_State = "<Font Color=Blue>正常</Font>";
                        }
                    }
                    else
                    {
                        try
                        {
                            jsonString = getPageInfo(url);
                            KDDetails KdDetail = JsonHelper.ParseFromJson<KDDetails>(jsonString);
                            s_State = GetSateName(KdDetail.status);
                        }
                        catch (Exception ex)
                        {
                            s_State = "错误！";
                        }
                    }
                }
                if (s_State == "<Font Color=red>已签收</Font>")
                {
                    Model.KWD_KDState = s_State;
                    BLL.Update(Model);
                }
            }

            s_Rturn += "<a href=\"#\"  onclick=\"javascript:window.open('../SalesShip/Knet_Sales_Ship_Manage_Talks_Detail.aspx?com=" + s_KDName + "&Code=" + s_Code + "&Name=" + s_CodeName + "','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=580,height=250');\">";
            s_Rturn += " " + s_State + " </a>" + ",";
        }

        return s_Rturn == "" ? "" : s_Rturn.Substring(0, s_Rturn.Length - 1);
    }
    /// <summary>
    /// 查看 直接入库 单是否已审核
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetReceivCheckYNEitxt(string DirectInNo)
    {
        //using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        //{
        //    conn.Open();
        //    string Dostr = "select ID,DirectInCheckYN,DirectInNo from KNet_WareHouse_DirectInto where DirectInNo='" + DirectInNo + "'";
        //    SqlCommand cmd = new SqlCommand(Dostr, conn);
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        if (dr["DirectInCheckYN"].ToString() == "True")
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        return false;
    }

    /// <summary>
    /// 退货产品类型
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string GetDirectInProductsName(string s_Order)
    {
        string s_Return = "";
        this.BeginQuery("Select * from KNet_WareHouse_DirectInto_Details Where DirectInNo='" + s_Order + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {

                if (Dtb_Result.Rows.Count < 5)
                {
                    for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                    {
                        s_Return += base.Base_GetProdutsName(Dtb_Result.Rows[i]["ProductsBarCode"].ToString()) + "<br>";
                    }
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        s_Return += base.Base_GetProdutsName(Dtb_Result.Rows[i]["ProductsBarCode"].ToString()) + "<br>";
                    }
                    s_Return += "<font color=gray>更多...</font>" + "<br>";
                }
            s_Return = s_Return.Substring(0, s_Return.Length - 1);
        }
        return s_Return;
    }
    public string GetDirectInProductsPatten(string s_Order)
    {
        string s_Return = "";
        this.BeginQuery("Select * from KNet_WareHouse_DirectInto_Details Where DirectInNo='" + s_Order + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {

            if (Dtb_Result.Rows.Count < 5)
            {
                for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                {
                    s_Return += base.Base_GetProductsEdition_Link(Dtb_Result.Rows[i]["ProductsBarCode"].ToString()) + "<br>";
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    s_Return += base.Base_GetProductsEdition_Link(Dtb_Result.Rows[i]["ProductsBarCode"].ToString()) + "<br>";
                }
                s_Return += "<font color=gray>更多...</font>" + "<br>";
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 1);
        }
        return s_Return;
    }

    /// <summary>
    /// 退货产品总数量
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string GetDirectInNumbers(string s_Order)
    {
        string s_Return = "";
        this.BeginQuery("Select Sum(DirectInAmount) as OrderAmount from KNet_WareHouse_DirectInto_Details Where DirectInNo='" + s_Order + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return = Dtb_Result.Rows[i]["OrderAmount"].ToString();
            }
        }
        return s_Return;
    }
    public string GetDirectInTotalNets(string s_Order)
    {
        string s_Return = "";
        this.BeginQuery("Select Sum(DirectInTotalNet) as OrderAmount from KNet_WareHouse_DirectInto_Details Where DirectInNo='" + s_Order + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return = Dtb_Result.Rows[i]["OrderAmount"].ToString();
            }
        }
        return s_Return;
    }

    protected void Btn_Del_Click(object sender, EventArgs e)
    {

        string sql = "delete from KNet_WareHouse_DirectInto where"; //删除采购单
        string sql2 = "delete from KNet_WareHouse_DirectInto_Details where"; //采购单明细

        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " DirectInNo='" + GridView1.DataKeys[i].Value.ToString() + "' or";
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
        LogAM.Add_Logs("库存管理--->直接入库单批量 删除 操作成功！");

        this.DataShows();
        this.RowOverYN();
    }


    /// <summary>
    /// 获取入库单明细数目
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu(string DirectInNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as IDS  from KNet_WareHouse_DirectInto_Details where DirectInNo='" + DirectInNo + "'";
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
    /// 返回审核情况
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetOrderCheckYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,DirectInNo,DirectInCheckYN from KNet_WareHouse_DirectInto where DirectInNo='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["DirectInCheckYN"].ToString() == "1")
                {
                    return "<img src=\"../../images/gou.gif\"  border=\"0\" />";
                }
                else
                {
                    return "<font color=red>未审批</font>";
                }
            }
            else
            {
                return "--";
            }
        }
    }
    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        this.DataShows();
        this.RowOverYN();
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
    public string GetModify(object aa)
    {

        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,DirectInNo,DirectInCheckYN from KNet_WareHouse_DirectInto where DirectInNo='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["DirectInCheckYN"].ToString() == "True")
                {
                    return "<img src=\"../../images/gou.gif\"  border=\"0\" />";
                }
                else
                {
                    if (Knet_Procure_OrdersList_Details_Shu(aa.ToString()) <= 0)
                    {
                        return "<a href=\"KNet_WareHouse_DirectInto_AddDetails.aspx?DirectInNo=" + aa + "\"><img src=\"../../images/Nodata.gif\"  border=\"0\"  title=\"未完成的入库单（没有明细记录）\" /></a>";
                    }
                    else
                    {
                        string JSD = "../WareHouse/pop/KNet_WareHouse_DirectIntoCheckYN.aspx?DirectInNo=" + aa.ToString() + "";
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

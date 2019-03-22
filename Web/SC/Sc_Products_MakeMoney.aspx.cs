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
/// 库存管理-----直接出库单 管理
/// </summary>
public partial class Web_SC_Sc_Products_MakeMoney : BasePage
{
    public string s_AdvShow = "", s_Type1 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string s_Title = "直接出库";
            s_Type1 = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            this.Tbx_Type.Text = s_Type1;
            if (s_Type1 != "")
            {
                s_Title = s_Title.Replace("直接", "售后");
            }
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("" + s_Title + "列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            //直接出库单删除
            //if (AM.YNAuthority("删除" + s_Title + "") == false)
            //{
            //    this.Btn_Del.Enabled = false;
            //}
            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！\\n\\n注意：该删除会同时删除出库单产品明细记录.')");
            base.Base_DropBindSearch(this.bas_searchfield, "Sc_Products_MakeMoney");
            base.Base_DropBindSearch(this.Fields, "Sc_Products_MakeMoney");
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

        KNet.BLL.Sc_Products_MakeMoney bll = new KNet.BLL.Sc_Products_MakeMoney();
        string SqlWhere = " 1=1  ";


        //string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        //string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        //string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        //string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        //string s_Type = "";
        //if (s_WhereID != "")
        //{
        //    SqlWhere += Base_GetBasicWhere(s_WhereID);
        //}
        //if ((this.bas_searchfield.SelectedValue != "") && (search_text.Text != ""))
        //{
        //    SqlWhere += base.Base_GetBasicColumnWhere(this.bas_searchfield.SelectedValue, this.search_text.Text);
        //}
        //if (s_Text != "")
        //{
        //    if (this.matchtype1.Checked == true)//and
        //    {
        //        s_Type = "0";
        //    }
        //    if (this.matchtype2.Checked == true)
        //    {
        //        s_Type = "1";
        //    }
        //    SqlWhere += base.Base_GetAdvWhere(s_Fields, s_Condition, s_Text, s_Type);
        //}
        //if (Request.QueryString["Type"] == "2")
        //{
        //    SqlWhere += " and KWD_Type='103'";
        //}
        //else if (Request.QueryString["Type"] == "3")
        //{
        //    SqlWhere += " and KWD_Type='104'";
        //}
        //else if (Request.QueryString["Type"] == "Ly")
        //{
        //    SqlWhere += " and KWD_Type in ('105','102')  ";

        //}
        //else
        //{
        //    SqlWhere += " and KWD_Type not in('104','103','101')";

        //}
        SqlWhere = SqlWhere + " order by Stime desc ";
        DataSet ds = bll.GetList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ID" };
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
            KNet.BLL.Sc_Products_MakeMoney Bll = new KNet.BLL.Sc_Products_MakeMoney();

            string DirectInNo = GridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");

            KNet.Model.Sc_Products_MakeMoney Model = Bll.GetModel(DirectInNo);
            if (Model.ID !="")
            {
                cb.Enabled = true;
            }
            else
            {
                cb.Enabled = false;
            }
        }
    }


    /// <summary>
    /// 查看 直接出库 单是否已审核
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetReceivCheckYNEitxt(string DirectOutNo)
    {
        //using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        //{
        //    conn.Open();
        //    string Dostr = "select ID,DirectOutCheckYN,DirectOutNo from KNet_WareHouse_DirectOutList where DirectOutNo='" + DirectOutNo + "'";
        //    SqlCommand cmd = new SqlCommand(Dostr, conn);
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        if (dr["DirectOutCheckYN"].ToString() == "True")
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
    /// 返回仓库唯一值
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetHouseNo(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,DirectOutNo,HouseNo from KNet_WareHouse_DirectOutList where DirectOutNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["HouseNo"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }


    /// <summary>
    /// 获取出库单明细数目
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu(string DirectOutNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as IDS  from KNet_WareHouse_DirectOutList_Details where DirectOutNo='" + DirectOutNo + "'";
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
            string Dostr = "select ID,DirectOutNo,DirectOutCheckYN from KNet_WareHouse_DirectOutList where DirectOutNo='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["DirectOutCheckYN"].ToString() == "1")
                {
                    return "<font color=blue>部门已审</font>";
                }
                else if (dr["DirectOutCheckYN"].ToString() == "0")
                {

                    return "未审批";
                }
                else
                {
                    return "<font color=red>财务已审</font>";
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
    protected void Btn_Del_Click(object sender, EventArgs e)
    {

        //string sql = "delete from KNet_WareHouse_DirectOutList where"; //删除出库单
        //string sql2 = "delete from KNet_WareHouse_DirectOutList_Details where"; //出库单明细

        //string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                //cal += " DirectOutNo='" + GridView1.DataKeys[i].Value.ToString() + "' or";
                KNet.BLL.Sc_Products_MakeMoney BLL = new KNet.BLL.Sc_Products_MakeMoney();
               bool a= BLL.Delete(GridView1.DataKeys[i].Value.ToString());
                if (a)
                {
                    AdminloginMess LogAM = new AdminloginMess();
                    LogAM.Add_Logs("制造费用 删除 操作成功！");
                    Alert("删除成功");
                    this.DataShows();
                    this.RowOverYN();
                }
                else
                {
                    Alert("删除失败");
                }
                //KNet.BLL.Sc_Products_MakeMoney BLL = new KNet.BLL.Sc_Products_MakeMoney();
                ////DataSet ds = BLL.GetList(" DirectOutNo='" + GridView1.DataKeys[i].Value.ToString() + "' ");

                //for (int j = 0; j <= ds.Tables[0].Rows.Count - 1; j++)
                //{
                //    DataRowView mydrv = ds.Tables[0].DefaultView[j];

                //    string ID = mydrv["ID"].ToString();
                //    // string OwnallPID = mydrv["OwnallPID"].ToString();
                //    //  string ProductsBarCode = mydrv["ProductsBarCode"].ToString();
                //    //   string HouseNo = GetHouseNo(GridView1.DataKeys[i].Value.ToString());


                //    try
                //    {
                //        BLL.Delete(ID);

                //        string DosqlP = "update KNet_WareHouse_DirectOutList set DirectOutCheckYN=0 where DirectOutNo='" + GridView1.DataKeys[i].Value.ToString() + "' ";
                //        DbHelperSQL.ExecuteSql(DosqlP);
                //    }
                //    catch
                //    { }
                //}
            }
        }
        //if (cal != "")
        //{
        //    sql += cal.Substring(0, cal.Length - 3);
        //    sql2 += cal.Substring(0, cal.Length - 3);
        //}
        //else
        //{
        //    sql = "";       //不删除
        //    sql2 = "";       //不删除
        //    Response.Write("<script language=javascript>alert('您没有选择要删除的记录!');history.back(-1);</script>");
        //    Response.End();
        //}

        //DbHelperSQL.ExecuteSql(sql);
        //DbHelperSQL.ExecuteSql(sql2);

        //AdminloginMess LogAM = new AdminloginMess();
        //LogAM.Add_Logs("库存管理--->直接出库单批量 删除 操作成功！");

        //this.DataShows();
        //this.RowOverYN();
    }


    /// <summary>
    /// 退货产品类型
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string GetDirectOutProductsPatten(string s_Order)
    {
        string s_Return = "";
        this.BeginQuery("Select  distinct ProductsBarCode from KNet_WareHouse_DirectOutList_Details Where DirectOutNo='" + s_Order + "'");
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
    public string GetDirectOutNumbers(string s_Order)
    {
        string s_Return = "";
        this.BeginQuery("Select Sum(DirectOutAmount) as OrderAmount from KNet_WareHouse_DirectOutList_Details Where DirectOutNo='" + s_Order + "'");
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

    /// <summary>
    /// 退货产品总数量
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string GetDirectOutMoney(string s_Order)
    {
        string s_Return = "";
        this.BeginQuery("Select Sum(DirectOutTotalNet) as OrderAmount from KNet_WareHouse_DirectOutList_Details Where DirectOutNo='" + s_Order + "'");
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

    protected void Ddl_Batch_TextChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }
}
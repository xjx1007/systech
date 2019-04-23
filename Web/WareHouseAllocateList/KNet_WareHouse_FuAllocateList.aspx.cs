using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_WareHouseAllocateList_KNet_WareHouse_FuAllocateList : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();

            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_Type != "")
            {
                //直接入库单删除
                if (AM.YNAuthority("售后调拨列表") == false)
                {
                    AM.NoAuthority("售后调拨列表");
                }
            }
            else
            {

                if (AM.YNAuthority("库间调拨列表") == false)
                {
                    AM.NoAuthority("库间调拨列表");
                }
            }
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            if (s_Type != "")
            {
                this.Tbx_Type.Text = s_Type;
            }
            //退货单查看
            if (AM.YNAuthority("删除库间调拨") == false)
            {
                this.Btn_Del.Enabled = false;
            }
            if (s_ID != "")
            {
                KNet.BLL.KNet_WareHouse_FuAllocateList Bll = new KNet.BLL.KNet_WareHouse_FuAllocateList();
                KNet.Model.KNet_WareHouse_FuAllocateList Model = Bll.GetModelB(s_ID);
                if (AM.YNAuthority("单据财务审批"))
                {
                    if (Model.AllocateCheckYN == 3)
                    {
                        string DoSql = "update KNet_WareHouse_FuAllocateList  set AllocateCheckYN=1,AllocateCheckStaffNo='" + AM.KNet_StaffNo + "'  where  AllocateNo='" + s_ID + "' ";
                        DbHelperSQL.ExecuteSql(DoSql);
                        AM.Add_Logs("反财务审批成功" + s_ID);
                        Alert("反财务审批成功！");
                    }
                    else
                    {
                        string DoSql = "update KNet_WareHouse_FuAllocateList  set AllocateCheckYN=3,AllocateCheckStaffNo='" + AM.KNet_StaffNo + "'   where  AllocateNo='" + s_ID + "' ";
                        DbHelperSQL.ExecuteSql(DoSql);
                        AM.Add_Logs("财务审批成功" + s_ID);
                        Alert("财务审批成功！");
                    }
                }
            }
            base.Base_DropBindSearch(this.bas_searchfield, "KNet_WareHouse_FuAllocateList");
            base.Base_DropBindSearch(this.Fields, "KNet_WareHouse_FuAllocateList");
            base.Base_DropBatchBind(this.Ddl_Batch, "KNet_WareHouse_FuAllocateList", "AllocateStaffNo");

            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！\\n\\n注意：该删除会同时删除调拨单产品明细记录.')");
            this.DataShows();
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        AdminloginMess AM = new AdminloginMess();
        string SqlWhere = " 1=1 ";
        KNet.BLL.KNet_WareHouse_FuAllocateList bll = new KNet.BLL.KNet_WareHouse_FuAllocateList();

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        this.Tbx_WhereID.Text = s_WhereID;
        string s_WhereID1 = Request.QueryString["WhereID1"] == null ? "" : Request.QueryString["WhereID1"].ToString();
        this.Tbx_WhereID1.Text = s_WhereID1;

        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";

        if (this.Tbx_WhereID.Text != "")
        {
            SqlWhere += Base_GetBasicWhere(this.Tbx_WhereID.Text);
        }
        if (this.Tbx_WhereID1.Text != "")
        {
            SqlWhere += Base_GetBasicWhere(this.Tbx_WhereID1.Text);
        }
        //if (this.Ddl_Batch.SelectedValue != "")
        //{
        //    SqlWhere += Base_GetBasicWhere(this.Ddl_Batch.SelectedValue);
        //}

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
        if (Request.QueryString["Type"] != "")
        {
            SqlWhere += " and AllocateTopic='102'";
        }
        SqlWhere = SqlWhere + " order by systemDateTimes desc";
        DataSet ds = bll.GetList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "AllocateNo" };
        GridView1.DataBind();
    }

    /// <summary>
    /// 退货产品类型
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string GetDirectInProductsPatten(string s_Order)
    {
        string s_Return = "";
        this.BeginQuery("Select * from KNet_WareHouse_FuAllocateList_Details Where AllocateNo='" + s_Order + "'");
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
    /// 调拨产品总数量
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string GetDirectInNumbers(string s_Order)
    {
        string s_Return = "";
        this.BeginQuery("Select Sum(AllocateAmount) as AllocateAmount from KNet_WareHouse_FuAllocateList_Details Where AllocateNo='" + s_Order + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return = Dtb_Result.Rows[i]["AllocateAmount"].ToString();
            }
        }
        return s_Return;
    }
    /// <summary>
    /// 退货产品总数量
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string GetDirectBadNumbers(string s_Order)
    {
        string s_Return = "";
        this.BeginQuery("Select Sum(AllocateBadAmount) as AllocateAmount from KNet_WareHouse_FuAllocateList_Details Where AllocateNo='" + s_Order + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return = Dtb_Result.Rows[i]["AllocateAmount"].ToString();
            }
        }
        return s_Return;
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

            string AllocateNo = this.GridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            KNet.BLL.KNet_WareHouse_AllocateList BLL1 = new KNet.BLL.KNet_WareHouse_AllocateList();
            DataSet Model1 = BLL1.GetList("  AllocateNo=" + "'" + AllocateNo + "'");

            if (Model1.Tables[0].Rows.Count > 0)
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
    /// 查看 库间调拨 单是否已审核
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetReceivCheckYNEitxt(string AllocateNo)
    {
        //using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        //{
        //    conn.Open();
        //    string Dostr = "select ID,AllocateCheckYN,AllocateNo from KNet_WareHouse_AllocateList where AllocateNo='" + AllocateNo + "'";
        //    SqlCommand cmd = new SqlCommand(Dostr, conn);
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        if (dr["AllocateCheckYN"].ToString() == "True")
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
            string Dostr = "select ID,AllocateNo,HouseNo from KNet_WareHouse_FuAllocateList where AllocateNo='" + aa + "'";
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
    /// 获取入库单明细数目
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu(string AllocateNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as IDS  from KNet_WareHouse_FuAllocateList_Details where AllocateNo='" + AllocateNo + "'";
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
            string Dostr = "select ID,AllocateNo,AllocateCheckYN from KNet_WareHouse_FuAllocateList where AllocateNo='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["AllocateCheckYN"].ToString() == "3")
                {
                    return "<font color=red>反财务审</font>";
                }
                else if (dr["AllocateCheckYN"].ToString() == "1")
                {
                    return "部门审批";
                }
                else
                {
                    return "<font color=blue>财务审批</font>";
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
    }
    protected void Btn_Del_Click(object sender, EventArgs e)
    {

        AdminloginMess AM = new AdminloginMess();
        string sql = "delete from KNet_WareHouse_FuAllocateList where"; //删除采购单
        string sql2 = "delete from KNet_WareHouse_FuAllocateList_Details where"; //调拨单明细
        string sql3 = "delete from KNet_WareHouse_AllocateList_CPDetails where"; //调拨单明细


        string cal = "", cal1 = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " AllocateNo='" + GridView1.DataKeys[i].Value.ToString() + "' or";
                cal1 += " KWAC_AllocateNo='" + GridView1.DataKeys[i].Value.ToString() + "' or";


                KNet.BLL.KNet_WareHouse_FuAllocateList_Details BLL = new KNet.BLL.KNet_WareHouse_FuAllocateList_Details();
                DataSet ds = BLL.GetList(" a.AllocateNo='" + GridView1.DataKeys[i].Value.ToString() + "' ");

                for (int j = 0; j <= ds.Tables[0].Rows.Count - 1; j++)
                {
                    DataRowView mydrv = ds.Tables[0].DefaultView[j];

                    string ID = mydrv["ID"].ToString();
                    //string ProductsBarCode = mydrv["ProductsBarCode"].ToString();
                    //string HouseNo= GetHouseNo(GridView1.DataKeys[i].Value.ToString());
                    //string OwnallPID = mydrv["OwnallPID"].ToString();

                    try
                    {
                        BLL.Delete(ID);

                        string DosqlP = "update KNet_WareHouse_FuAllocateList set AllocateCheckYN=0 where AllocateNo='" + GridView1.DataKeys[i].Value.ToString() + "' ";
                        DbHelperSQL.ExecuteSql(DosqlP);
                        AM.Add_Logs("调拨删除：" + GridView1.DataKeys[i].Value.ToString());
                        AlertAndRedirect("删除成功！", "KNet_WareHouse_FuAllocateList.aspx");
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
            sql3 += cal1.Substring(0, cal1.Length - 3);


        }
        else
        {
            sql = "";       //不删除
            sql2 = "";       //不删除
            sql3 = "";       //不删除
            Response.Write("<script language=javascript>alert('您没有选择要删除的记录!');history.back(-1);</script>");
            Response.End();
        }

        DbHelperSQL.ExecuteSql(sql);
        DbHelperSQL.ExecuteSql(sql2);
        //DbHelperSQL.ExecuteSql(sql3);

        AdminloginMess LogAM = new AdminloginMess();
        LogAM.Add_Logs("库存管理--->库间调拨单批量 删除 操作成功！");

        this.DataShows();
    }
    public void btnBasicSearch_Click(object sender, EventArgs e)
    {
        this.advSearch.Style["display"] = "none";
        this.Search_basic.Style["display"] = "block";
        this.DataShows();
    }

    public string GetCheck(string s_AllocateNo)
    {
        string s_Return = "";
        try
        { }
        catch
        { }
        KNet.BLL.KNet_WareHouse_AllocateList BLL1 = new KNet.BLL.KNet_WareHouse_AllocateList();
        DataSet Model1 = BLL1.GetList("  AllocateNo=" + "'" + s_AllocateNo + "'");

        if (Model1.Tables[0].Rows.Count > 0)
        {

            s_Return = "<font color=red>已入库</font>";
        }
        else
        {
            s_Return = "<a href=\"#\"><font color=\"blue\">未入库</font></a>";
        }



        return s_Return;

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

    protected void BtnSave_OnClick(object sender, EventArgs e)
    {
        string sql =" select *from KNet_WareHouse_FuAllocateList where AllocateNo not in (select AllocateNo from KNet_WareHouse_FuAllocateList where AllocateNo   in (SELECT AllocateNo from KNet_WareHouse_AllocateList))";
        DataSet ds = DbHelperSQL.ExecuteDataSet(CommandType.Text, sql);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "AllocateNo" };
        GridView1.DataBind();
    }
}
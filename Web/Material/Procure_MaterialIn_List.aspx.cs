﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
using KNet.Common;

public partial class Procure_MaterialIN_List : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("原材料入库单") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"];
                base.Base_DropWareHouseBind(this.Ddl_House, " KSW_Type='0' ");

                if (s_ID != "")
                {
                    if (AM.CheckLogin("财务审核出库单") == true)
                    {
                        KNet.BLL.Knet_Procure_WareHouseList bll = new KNet.BLL.Knet_Procure_WareHouseList();
                        KNet.Model.Knet_Procure_WareHouseList Model = bll.GetModelB(s_ID);
                        string s_CheckYN = "3";
                        if (Model.WareHouseCheckYN == 1)
                        {
                            s_CheckYN = "2";
                        }
                        else
                        {
                            s_CheckYN = "1";
                        }
                        string sql = " update Knet_Procure_WareHouseList  set WareHouseCheckYN=" + s_CheckYN + ",WareHouseCheckStaffNo ='" + AM.KNet_StaffNo + "'  where  WareHouseNo='" + s_ID + "' ";
                        DbHelperSQL.ExecuteSql(sql);
                    }
                }
                this.DataBind();
            }
            //采购对账删除
            if (AM.YNAuthority("删除采购对账") == false)
            {
                this.Btn_Del.Enabled = false;
            }

            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");

            base.Base_DropBindSearch(this.bas_searchfield, "Procure_MaterialIn");
            base.Base_DropBindSearch(this.Fields, "Procure_MaterialIn");
        }
    }


    /// <summary>
    /// 开启编辑
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_Editing(object sender, GridViewEditEventArgs e)
    {

        MyGridView1.EditIndex = e.NewEditIndex;
        this.DataBind();
    }

    /// <summary>
    /// 取消编辑
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        this.DataBind();
    }

    protected void Btn_Show_Click(object sender, EventArgs e)
    {
        if (this.MyGridView1.AllowPaging)
        {
            if (MyGridView1.PageCount > 30)
            {
                Alert("超过30页不能显示全部！");
            }
            else
            {
                this.Btn_Show.Text = "收缩";
                this.MyGridView1.AllowPaging = false;
                this.DataBind();
            }

        }
        else
        {
                this.Btn_Show.Text = "显示全部";
                this.MyGridView1.AllowPaging = true;
                this.DataBind();
        }
    }
    /// <summary>
    /// 更新数据记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        KNet.BLL.Knet_Procure_WareHouseList_Details bll = new KNet.BLL.Knet_Procure_WareHouseList_Details();

        string ID = MyGridView1.DataKeys[e.RowIndex].Value.ToString().Trim();
        string Tbx_Money = KNetPage.KHtmlEncode(((TextBox)MyGridView1.Rows[e.RowIndex].FindControl("Tbx_Money")).Text.ToString().Trim());
        KNet.Model.Knet_Procure_WareHouseList_Details model = bll.GetModel(ID);
        model.ID = ID;
        model.KWP_NoTaxMoney = decimal.Parse(Tbx_Money);
        model.KWP_NoTaxLag = model.KWP_NoTaxLag == null ? 0 : model.KWP_NoTaxLag + 1;
        try
        {
            bll.UpdateTaxMoney(model);
            AdminloginMess LogAM = new AdminloginMess();
            LogAM.Add_Logs("单据--->原材料入库--->不含税金额  更新  操作成功！ID：" + ID);
        }
        catch
        {
            // throw;
            Response.Write("<script>alert('不含税金额 更新 失败！');history.back(-1);</script>");
            Response.End();
        }
        this.DataBind();
    }
    public string GetState(string s_ID)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "select * from Cg_Order_Checklist_Details where COD_DirectOutID='"+s_ID+"'";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            if (Dtb_Result.Rows.Count > 0)
            {
                s_Return = "<font color=blue>正常</font>";
            }
            else
            {
                s_Return = "<font color=red>暂估</font>";
            }
        }
        catch
        { 
        }
        return s_Return;
 
    }
    private void DataBind()
    {

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        this.Tbx_WhereID.Text = s_WhereID;
        string s_WhereID1 = Request.QueryString["WhereID1"] == null ? "" : Request.QueryString["WhereID1"].ToString();
        this.Tbx_WhereID1.Text = s_WhereID1;
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";

        string SqlWhere = "  KPO_QRState='1' ";
        AdminloginMess AM = new AdminloginMess();

        if (this.Tbx_WhereID.Text != "")
        {
            SqlWhere += Base_GetBasicWhere(this.Tbx_WhereID.Text);
        }
        if (this.Tbx_WhereID1.Text != "")
        {
            SqlWhere += Base_GetBasicWhere(this.Tbx_WhereID1.Text);
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

        if (this.Ddl_House.SelectedValue != "")
        {
            SqlWhere += " and HouseNo='" + this.Ddl_House.SelectedValue + "'";
        }
        SqlWhere += "  ";
        KNet.BLL.Knet_Procure_WareHouseList BLL = new KNet.BLL.Knet_Procure_WareHouseList();
        DataSet ds = BLL.GetListByDetails(SqlWhere + "  Order by systemDateTimes desc");
        this.MyGridView1.DataSource = ds;
        this.MyGridView1.DataKeyNames = new string[] { "DetailsID" };
        this.MyGridView1.DataBind();
        decimal d_totalNum = 0, d_totalMoney = 0, d_TotalTaxMoney = 0;
        try
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                d_totalNum += decimal.Parse(ds.Tables[0].Rows[i]["WareHouseAmount"].ToString() == "" ? "0" : ds.Tables[0].Rows[i]["WareHouseAmount"].ToString());
                d_totalMoney += decimal.Parse(ds.Tables[0].Rows[i]["WareHouseTotalNet"].ToString() == "" ? "0" : ds.Tables[0].Rows[i]["WareHouseTotalNet"].ToString());
                d_TotalTaxMoney += decimal.Parse(ds.Tables[0].Rows[i]["KWP_NoTaxMoney"].ToString()==""?"0":ds.Tables[0].Rows[i]["KWP_NoTaxMoney"].ToString());
            }
        }
        catch (Exception ex)
        {
        }
        Lbl_Total.Text = "总数量：<font color=red>" + d_totalNum.ToString() + "</font> | 总金额：<font color=red>" + d_totalMoney.ToString() + "</font> | 总不含税金额：<font color=red>" + d_TotalTaxMoney.ToString() + "</font>";

    }

    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        this.DataBind();
    }
    protected void Btn_Del_Click(object sender, EventArgs e)
    {
        StringBuilder s_Sql = new StringBuilder();
        StringBuilder s_Log = new StringBuilder();
        try
        {
            for (int i = 0; i < MyGridView1.Rows.Count; i++)
            {
                CheckBox Ckb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (Ckb.Checked)
                {
                    string s_ID = MyGridView1.DataKeys[i].Value.ToString();
                    s_Sql.Append(" Update KNet_WareHouse_DirectOutList_Details set DZNumber=DZNumber-b.COD_DzNumber from KNet_WareHouse_DirectOutList_Details a,Cg_Order_Checklist_Details b where COD_DirectOutID=ID and COD_CheckNo='" + s_ID + "'");
                    s_Sql.Append(" delete from  Cg_Order_Checklist Where COC_Code='" + s_ID + "' ");
                    s_Sql.Append(" delete from  Cg_Order_Checklist_Details Where COD_CheckNo='" + s_ID + "' ");
                    s_Log.Append(s_ID);
                }
            }
            DbHelperSQL.ExecuteSql(s_Sql.ToString());
            this.DataBind();
            AdminloginMess AM = new AdminloginMess();
            AM.Add_Logs("对账单 删除 编号：" + s_Log + "");
            Alert("删除成功！");
        }
        catch (Exception ex)
        {
            Alert("删除失败！");
            return;
        }

    }


    protected string GetOrderCheckYN(object aa)
    {
        string s_Return = "";
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,WareHouseNo,WareHouseCheckYN from Knet_Procure_WareHouseList where WareHouseNo='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["WareHouseCheckYN"].ToString() == "1")
                {
                    s_Return= "<a href=\"Procure_MaterialIn_List.aspx?ID=" + aa + "\"><font color=Green>部门已审</font></a>";
                }
                else if (dr["WareHouseCheckYN"].ToString() == "2")
                {
                    s_Return = "<a href=\"Procure_MaterialIn_List.aspx?ID=" + aa + "\"><font color=red>财务已审</font></a>";
                }
                else
                {
                    s_Return = "<font color=blue>未审核</font>";
                }
            }
            else
            {
                s_Return = "--";
            }
            /*
            try
            {
                string s_Sql = "";
                s_Sql = "Select * from Cg_Order_Checklist_Details a join Knet_Procure_WareHouseList b on a.COD_DirectOutID=b.ID";
                s_Sql += " join Cg_Order_Checklist c on  c.COC_Code =a.COD_CheckNo ";
                s_Sql += " where b.WareHouseNo='" + aa + "' and c.COC_CheckYN='1' ";
                this.BeginQuery(s_Sql);
                this.QueryForDataTable();
                if (this.Dtb_Result.Rows.Count > 0)
                {
                    s_Return += " <font color=red>已对账</font>";
                }
                else
                {
                    s_Return += " <font color=red>未对账</font>";
                }
            }
            catch
            { }*/
        }
        return s_Return;
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

    public void btnBasicSearch_Click(object sender, EventArgs e)
    {
        this.advSearch.Style["display"] = "none";
        this.Search_basic.Style["display"] = "block";
        this.DataBind();
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
        s_AdvShow = Base_GetAdvShowHtml(arr_Fields, arr_Condition, arr_Text, "Procure_MaterialIn");
        this.DataBind();
    }
    public string GetShDetails(string s_COC_Code)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.Cg_Order_Checklist Bll = new KNet.BLL.Cg_Order_Checklist();
            KNet.Model.Cg_Order_Checklist Model = Bll.GetModel(s_COC_Code);
            if (Model.COC_CheckYN == 1)
            {//已审核
                if (Model.COC_Type == "1")
                {
                    s_Return = "<a href='Procure_MaterialIn_View.aspx?ID=" + s_COC_Code + "&Type=0' target=\"_blank\">原材料入库单</a>";

                }
                else
                {
                    s_Return = "已审核";
                }
            }
            else
            {
                s_Return = "未审核";
            }
        }
        catch (Exception ex) { }
        return s_Return;
    }


    protected void Btn_SpSave(object sender, EventArgs e)
    {

        StringBuilder s_Sql = new StringBuilder();
        StringBuilder s_Log = new StringBuilder();
        AdminloginMess AM = new AdminloginMess();
        try
        {

            for (int i = 0; i < MyGridView1.Rows.Count; i++)
            {
                CheckBox Ckb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (Ckb.Checked)
                {
                    string s_ID = MyGridView1.DataKeys[i].Value.ToString();

                    if (AM.CheckLogin("财务审核出库单") == true)
                    {
                        KNet.BLL.Knet_Procure_WareHouseList_Details bll_Details = new KNet.BLL.Knet_Procure_WareHouseList_Details();
                        KNet.Model.Knet_Procure_WareHouseList_Details Model_Details = bll_Details.GetModel(s_ID);
                        KNet.BLL.Knet_Procure_WareHouseList bll = new KNet.BLL.Knet_Procure_WareHouseList();
                        KNet.Model.Knet_Procure_WareHouseList Model = bll.GetModelB(Model_Details.WareHouseNo);
                        string s_CheckYN = "0";
                        if (Model.WareHouseCheckYN == 1)
                        {
                            s_CheckYN = "2";
                        }
                        else if (Model.WareHouseCheckYN == 0)
                        {

                            s_CheckYN = "0";
                        }
                        else
                        {
                            s_CheckYN = "1";
                        }
                        if (s_CheckYN != "0")
                        {
                            string sql = " update Knet_Procure_WareHouseList  set WareHouseCheckYN=" + s_CheckYN + ",WareHouseCheckStaffNo ='" + AM.KNet_StaffNo + "'  where  WareHouseNo='" + Model_Details.WareHouseNo + "' ";
                            DbHelperSQL.ExecuteSql(sql);
                        }
                    }
                    s_Log.Append(s_ID + ",");
                }
            }
            if (s_Log.ToString() == "")
            {
                Alert("未选择入库单！");
            }
            else
            {
                this.DataBind();
                AM.Add_Logs("Knet_Procure_WareHouseList 审批 编号：" + s_Log + "");
                Alert("批量审批成功！");
            }
        }
        catch (Exception ex)
        {
            Alert("批量审批失败！");
            return;
        }
    }
    protected void Ddl_House_TextChanged(object sender, EventArgs e)
    {
        DataBind();
    }
}

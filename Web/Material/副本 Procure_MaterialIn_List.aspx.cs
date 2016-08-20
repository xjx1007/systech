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
            this.Btn_Show.Text = "收缩";
            this.MyGridView1.AllowPaging = false;
            this.DataBind();
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
        KNet.BLL.Cg_Order_Checklist_Details bll = new KNet.BLL.Cg_Order_Checklist_Details();

        string ID = MyGridView1.DataKeys[e.RowIndex].Value.ToString().Trim();
        string Tbx_Money = KNetPage.KHtmlEncode(((TextBox)MyGridView1.Rows[e.RowIndex].FindControl("Tbx_Money")).Text.ToString().Trim());
        KNet.Model.Cg_Order_Checklist_Details model = bll.GetModel(ID);
        model.COD_Code = ID;
        model.COD_NoTaxMoney = decimal.Parse(Tbx_Money);
        model.COD_NoTaxLag =model.COD_NoTaxLag==null ? 0:model.COD_NoTaxLag+1;
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
    private void DataBind()
    {

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";

        string SqlWhere = " 1=1 ";
        AdminloginMess AM = new AdminloginMess();

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
        SqlWhere += " and COC_Type='1' and COC_CheckYN='1' ";
        KNet.BLL.Cg_Order_Checklist BLL = new KNet.BLL.Cg_Order_Checklist();
        DataSet ds = BLL.GetDetailsList(SqlWhere+" Order by COC_Ctime desc");
        this.MyGridView1.DataSource = ds;
        this.MyGridView1.DataKeyNames = new string[] { "COD_Code" };
        this.MyGridView1.DataBind();
        decimal d_totalNum=0,d_totalMoney=0,d_TotalTaxMoney=0;
        try
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                d_totalNum += decimal.Parse(ds.Tables[0].Rows[i]["COD_DzNumber"].ToString());
                d_totalMoney += decimal.Parse(ds.Tables[0].Rows[i]["COD_Money"].ToString());
                d_TotalTaxMoney += decimal.Parse(ds.Tables[0].Rows[i]["COD_SMoney"].ToString());
            }
            Lbl_Total.Text = "总数量：<font color=red>" + d_totalNum.ToString() + "</font> | 总金额：<font color=red>" + d_totalMoney.ToString() + "</font> | 总不含税金额：<font color=red>" + d_TotalTaxMoney.ToString() + "</font>";

        }
        catch { }
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
        catch(Exception ex)
        {
            Alert("删除失败！");
            return;
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
        catch(Exception ex) { }
        return s_Return;
    }
}

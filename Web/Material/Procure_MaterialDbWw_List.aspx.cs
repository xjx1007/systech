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

public partial class Procure_MaterialDbWw_List : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("原材料委外单") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                this.DataShow();
            }
            base.Base_DropBindSearch(this.bas_searchfield, "Cg_Order_MaterialDbIN");
            base.Base_DropBindSearch(this.Fields, "Cg_Order_MaterialDbIN");

            this.Btn_Show.Attributes.Add("onclick", "return confirm('您确定要显示全部吗？')");
            this.BtnSave.Attributes.Add("onclick", "return confirm('您确定要计算选择的委外单价吗？')");
        }
    }


    private void DataShow()
    {
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        this.Tbx_WhereID.Text = s_WhereID;
        string s_WhereID1 = Request.QueryString["WhereID1"] == null ? "" : Request.QueryString["WhereID1"].ToString();
        this.Tbx_WhereID1.Text = s_WhereID1;
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";

        string SqlWhere = " 1=1 and a.AllocateNo not like 'FX%' and e.KSP_code not like '01%'  ";
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

        SqlWhere += " and a.AllocateDateTime>'2013-12-31' ";
        KNet.BLL.KNet_WareHouse_AllocateList BLL = new KNet.BLL.KNet_WareHouse_AllocateList();
        DataSet ds = BLL.GetDetailsList(SqlWhere + " Order by a.Systemdatetimes desc");
        this.MyGridView1.DataSource = ds;
        this.MyGridView1.DataKeyNames = new string[] { "ID" };
        this.MyGridView1.DataBind();
    }

    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        this.DataShow();
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
        this.DataShow();
    }
    public string GetKC(string s_ID,int i_Type)
    {

        string s_ProductsBarCode = "", s_BTime = "", s_ETime = "", s_HouseNo = "", s_Price = "", s_Return="", s_Number = "";
        KNet.BLL.KNet_WareHouse_AllocateList_Details Bll = new KNet.BLL.KNet_WareHouse_AllocateList_Details();
        KNet.Model.KNet_WareHouse_AllocateList_Details Model = Bll.GetModel(s_ID);
        KNet.BLL.KNet_WareHouse_AllocateList BllCheck = new KNet.BLL.KNet_WareHouse_AllocateList();
        KNet.Model.KNet_WareHouse_AllocateList ModelCheck = BllCheck.GetModelB(Model.AllocateNo);

            if (Model != null)
            {
                s_ProductsBarCode = Model.ProductsBarCode;
                s_Number = Model.AllocateAmount.ToString();
                DateTime datetime = DateTime.Parse(ModelCheck.AllocateDateTime.ToString());
                //月初
                s_BTime = datetime.AddDays(1 - datetime.Day).ToShortDateString();
                s_ETime = datetime.AddDays(1 - datetime.Day).AddMonths(1).AddDays(-1).ToShortDateString();

            }
            try
            {
                string s_Sql = "select Sum(case when DirectInDateTime<'" + s_BTime + "' then DirectInAmount else 0 end) as QCNumber,";
                s_Sql += "Sum(case when DirectInDateTime<'" + s_BTime + "' then DirectINTotalNet else 0 end) QCMoney";
                s_Sql += ",Sum(case when DirectInDateTime>='" + s_BTime + "' and DirectInDateTime<='" + s_ETime + "' and type='111' then DirectInAmount else 0 end) CGNumber";
                s_Sql += ",Sum(case when  DirectInDateTime>='" + s_BTime + "' and DirectInDateTime<='" + s_ETime + "' and type='111' then DirectINTotalNet else 0 end) CGMoney";
                s_Sql += " from v_Store ";
                s_Sql += " Where ProductsBarCode='" + s_ProductsBarCode + "' and HouseNo='130088401935635079'  ";
                this.BeginQuery(s_Sql);
                this.QueryForDataTable();
                DataTable Dtb_Table = Dtb_Result;
                if (i_Type == 4)
                {
                    try
                    {
                        decimal d_TotalMoney = decimal.Parse(Dtb_Table.Rows[0][1].ToString()) + decimal.Parse(Dtb_Table.Rows[0][3].ToString());
                        decimal d_TotalNumber = decimal.Parse(Dtb_Table.Rows[0][0].ToString()) + decimal.Parse(Dtb_Table.Rows[0][2].ToString());
                        decimal d_Price = d_TotalMoney / d_TotalNumber;
                        return base.FormatNumber1(d_Price.ToString(), 5);
                    }
                    catch
                    { }
                }
                if (Dtb_Table != null)
                {
                    return Dtb_Table.Rows[0][i_Type].ToString();
                }
            }
            catch { }
 
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
        this.DataShow();
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
                    s_Return = "<a href='Procure_MaterialIn_View.aspx?ID=" + s_COC_Code + "&Type=1' target=\"_blank\">原材料委外单</a>";

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
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        KNet.BLL.KNet_WareHouse_AllocateList_Details Bll = new KNet.BLL.KNet_WareHouse_AllocateList_Details();
        int i_Num = 0;
        for (int i = 0; i < MyGridView1.Rows.Count; i++)
        {
            CheckBox chb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
            TextBox Tbx_Number = (TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_Number");
            TextBox Tbx_Price = (TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_Price");
            string s_ID = MyGridView1.DataKeys[i].Value.ToString();
            KNet.Model.KNet_WareHouse_AllocateList_Details Model = new KNet.Model.KNet_WareHouse_AllocateList_Details();
            if (chb.Checked)
            {
                Model.ID = s_ID;
                Model.Allocate_WwPrice = decimal.Parse(Tbx_Price.Text);
                Model.Allocate_WwMoney = decimal.Parse(Tbx_Price.Text) * decimal.Parse(Tbx_Number.Text);
                try
                {
                    if (Bll.UpdateWwPrice(Model))
                    {
                        i_Num = i_Num + 1;
                    }
                    else
                    {
                    }
                }
                catch
                { }
            }
        }

        Alert("计算" + i_Num.ToString() + "条委外成功！");
        this.DataShow();
    }
    protected void Btn_Show_Click(object sender, EventArgs e)
    {
        if (this.MyGridView1.AllowPaging)
        {
            this.Btn_Show.Text = "收缩";
            this.MyGridView1.AllowPaging = false;
            this.DataShow();
        }
        else
        {
            this.Btn_Show.Text = "显示全部";
            this.MyGridView1.AllowPaging = true;
            this.DataShow();
        }
    }


    public string GetState(string s_State)
    {
        if (s_State == "1")
        {
            return "<font color=blue>部门已审</font>";
        }
        else if (s_State == "3")
        {
            return "<font color=red>财务已审</font>";
        }
        else
        {
            return "<font color=red>未审批</font>";
        }
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
                        KNet.BLL.KNet_WareHouse_AllocateList_Details bll_Details = new KNet.BLL.KNet_WareHouse_AllocateList_Details();
                        KNet.Model.KNet_WareHouse_AllocateList_Details Model_Details = bll_Details.GetModel(s_ID);
                        KNet.BLL.KNet_WareHouse_AllocateList bll = new KNet.BLL.KNet_WareHouse_AllocateList();
                        KNet.Model.KNet_WareHouse_AllocateList Model = bll.GetModelB(Model_Details.AllocateNo);
                        string s_CheckYN = "3";
                        if (s_CheckYN != "0")
                        {
                            string sql = " update KNet_WareHouse_AllocateList  set AllocateCheckYN=" + s_CheckYN + ",AllocateCheckStaffNo ='" + AM.KNet_StaffNo + "'  where  AllocateNo='" + Model_Details.AllocateNo + "' ";
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
                AM.Add_Logs("KNet_WareHouse_AllocateList 审批 编号：" + s_Log + "");
                Alert("批量审批成功！");
                this.DataShow();
            }
        }
        catch (Exception ex)
        {
            Alert("批量审批失败！");
            return;
        }
    }

    protected void Btn_SpSave1(object sender, EventArgs e)
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
                        KNet.BLL.KNet_WareHouse_AllocateList_Details bll_Details = new KNet.BLL.KNet_WareHouse_AllocateList_Details();
                        KNet.Model.KNet_WareHouse_AllocateList_Details Model_Details = bll_Details.GetModel(s_ID);
                        KNet.BLL.KNet_WareHouse_AllocateList bll = new KNet.BLL.KNet_WareHouse_AllocateList();
                        KNet.Model.KNet_WareHouse_AllocateList Model = bll.GetModelB(Model_Details.AllocateNo);
                        string s_CheckYN = "1";
                        if (s_CheckYN != "0")
                        {
                            string sql = " update KNet_WareHouse_AllocateList  set AllocateCheckYN=" + s_CheckYN + ",AllocateCheckStaffNo ='" + AM.KNet_StaffNo + "'  where  AllocateNo='" + Model_Details.AllocateNo + "' ";
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
                AM.Add_Logs("KNet_WareHouse_AllocateList 审批 编号：" + s_Log + "");
                Alert("批量审批成功！");
                this.DataShow();
            }
        }
        catch (Exception ex)
        {
            Alert("批量审批失败！");
            return;
        }
    }
    /// <summary>
    /// 更新数据记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        KNet.BLL.KNet_WareHouse_AllocateList_Details bll = new KNet.BLL.KNet_WareHouse_AllocateList_Details();

        string ID = MyGridView1.DataKeys[e.RowIndex].Value.ToString().Trim();
        string Tbx_Money = KNetPage.KHtmlEncode(((TextBox)MyGridView1.Rows[e.RowIndex].FindControl("Tbx_NewPrice")).Text.ToString().Trim());
        KNet.Model.KNet_WareHouse_AllocateList_Details model = bll.GetModel(ID);
        model.ID = ID;
        model.AllocateTotalNet = decimal.Parse(Tbx_Money) * model.AllocateAmount;
        model.AllocateUnitPrice = decimal.Parse(Tbx_Money); 
        try
        {
            bll.Update(model);
            AdminloginMess LogAM = new AdminloginMess();
            LogAM.Add_Logs("单据--->原材料调拨--->修改单价  更新  操作成功！ID：" + ID);
        }
        catch
        {
            // throw;
            Response.Write("<script>alert('原材料调拨修改单价 更新 失败！');history.back(-1);</script>");
            Response.End();
        }
        this.DataShow();
    }

    /// <summary>
    /// 取消编辑
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        this.DataShow();
    }


    /// <summary>
    /// 开启编辑
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_Editing(object sender, GridViewEditEventArgs e)
    {

        MyGridView1.EditIndex = e.NewEditIndex;
        this.DataShow();
    }

}

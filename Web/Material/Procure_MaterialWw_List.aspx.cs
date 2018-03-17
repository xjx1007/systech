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

public partial class Procure_MaterialWw_List : BasePage
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
                this.DataBind();
            }
            base.Base_DropBindSearch(this.bas_searchfield, "Cg_Order_MaterialIN");
            base.Base_DropBindSearch(this.Fields, "Cg_Order_MaterialIN");

            this.Btn_Show.Attributes.Add("onclick", "return confirm('您确定要显示全部吗？')");
            this.BtnSave.Attributes.Add("onclick", "return confirm('您确定要计算选择的委外单价吗？')");
        }
    }


    private void DataBind()
    {

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";
        string s_Sql = "select a.COD_Code,d.WareHouseDateTime,COC_Stime,b.COC_SuppNo,d.HouseNo,b.COC_Code,a.COD_ProductsBarCode,a.COD_DZNumber, ";
        s_Sql += "a.COD_Price,a.COD_Money,a.COD_WwPrice,isnull(a.COD_WwMoney,0) COD_WwMoney";
        s_Sql += " from Cg_Order_Checklist_Details a ";
        s_Sql += " join Cg_Order_Checklist b on a.COD_CheckNO=b.COC_Code";
        s_Sql += " Join Knet_Procure_WareHouseList_Details c on a.COD_DirectOutID=c.ID";
        s_Sql += " join Knet_Procure_WareHouseList d on c.WareHouseNo=d.WareHouseNo ";
        string SqlWhere = " where 1=1 ";
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
        SqlWhere += " and COC_Type='1' and COC_CheckYN='1' and d.HouseNo<>'128502353068906250' ";
        KNet.BLL.Cg_Order_Checklist BLL = new KNet.BLL.Cg_Order_Checklist();
        KNet.Model.Cg_Order_Checklist Model = new KNet.Model.Cg_Order_Checklist();
       this.BeginQuery(s_Sql+SqlWhere+" Order by COC_Ctime desc");
       this.QueryForDataSet();
       DataSet ds = Dts_Result;
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
                d_TotalTaxMoney += decimal.Parse(ds.Tables[0].Rows[i]["COD_WwMoney"].ToString());
            }
            Lbl_Total.Text = "总数量：<font color=red>" + d_totalNum.ToString() + "</font> | 总金额：<font color=red>" + d_totalMoney.ToString() + "</font> | 总不含税金额：<font color=red>" + d_TotalTaxMoney.ToString() + "</font>";

        }
        catch { }
    }

    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        this.DataBind();
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
    public string GetKC(string s_ID,int i_Type)
    {

        string s_ProductsBarCode = "", s_BTime = "", s_ETime = "", s_HouseNo = "", s_Price = "", s_Return="", s_Number = "";
        KNet.BLL.Cg_Order_Checklist_Details Bll = new KNet.BLL.Cg_Order_Checklist_Details();
        KNet.Model.Cg_Order_Checklist_Details Model = Bll.GetModel(s_ID);
        KNet.BLL.Cg_Order_Checklist BllCheck = new KNet.BLL.Cg_Order_Checklist();
        KNet.Model.Cg_Order_Checklist ModelCheck = BllCheck.GetModel(Model.COD_CheckNo);
        if (ModelCheck.COC_CheckYN == 1)
        {
            if (Model != null)
            {
                s_ProductsBarCode = Model.COD_ProductsBarCode;
                s_Number = Model.COD_DZNumber.ToString();
                DateTime datetime = DateTime.Parse(ModelCheck.COC_Stime.ToString());
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
        s_AdvShow = Base_GetAdvShowHtml(arr_Fields, arr_Condition, arr_Text, "Cg_Order_MaterialIN");
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
        KNet.BLL.Cg_Order_Checklist_Details Bll = new KNet.BLL.Cg_Order_Checklist_Details();
        int i_Num = 0;
        for (int i = 0; i < MyGridView1.Rows.Count; i++)
        {
            CheckBox chb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
            TextBox Tbx_Number = (TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_Number");
            TextBox Tbx_Price = (TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_Price");
            string s_ID = MyGridView1.DataKeys[i].Value.ToString();
            KNet.Model.Cg_Order_Checklist_Details Model = new KNet.Model.Cg_Order_Checklist_Details();
            if (chb.Checked)
            {
                Model.COD_Code = s_ID;
                Model.COD_WwPrice = decimal.Parse(Tbx_Price.Text);
                Model.COD_WwMoney = decimal.Parse(Tbx_Price.Text) * decimal.Parse(Tbx_Number.Text);
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
}

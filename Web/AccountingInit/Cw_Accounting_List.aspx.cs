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
using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

public partial class Cw_Accounting_List : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("往来帐") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                base.Base_DropDutyPerson(this.Ddl_DutyPerson);
                this.Ddl_DutyPerson.SelectedValue = "";
                DataShows();
                this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");
                base.Base_DropBindSearch(this.bas_searchfield, "Cw_Accounting_Init");
                base.Base_DropBindSearch(this.Fields, "Cw_Accounting_Init");
            }
        }
    }

    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        string s_SqlWhere = " Select * from v_Receive   where 1=1 ";
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";
        if (s_WhereID != "")
        {
            s_SqlWhere += Base_GetBasicWhere(s_WhereID);
        }
        if ((this.bas_searchfield.SelectedValue != "") && (search_text.Text != ""))
        {
            s_SqlWhere += base.Base_GetBasicColumnWhere(this.bas_searchfield.SelectedValue, this.search_text.Text);
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
            s_SqlWhere += base.Base_GetAdvWhere(s_Fields, s_Condition, s_Text, s_Type);
        }
        if (this.StartDate.Text != "")
        {
            s_SqlWhere += " and Stime>='" + this.StartDate.Text + "' ";
        }
        if (this.EndDate.Text != "")
        {
            s_SqlWhere += " and Stime<='" + this.EndDate.Text + "' ";
        }
        if (this.Ddl_DutyPerson.SelectedValue != "")
        {
            s_SqlWhere += " and DutyPerson='" + this.Ddl_DutyPerson.SelectedValue + "' ";
        }
        string s_CustomerName = base.Base_GetCustomerName(this.Tbx_CustomerValue.Text);
        if (this.Tbx_CustomerValue.Text != "")
        {
            if (s_CustomerName == "--")
            {
                string s_SuppNo = base.Base_GetSupplierName("s_CustomerName");
                Lbl_Details.Text = "供应商：" + s_SuppNo;

            }
            else
            {
                Lbl_Details.Text = "客户：" + s_CustomerName;
            }
            s_SqlWhere += " and CustomerValue='" + this.Tbx_CustomerValue.Text + "' ";

        }
        s_SqlWhere += " Order by ID desc ";
        this.BeginQuery(s_SqlWhere);
        this.QueryForDataSet();
        //KNet.BLL.Cw_Accounting_Init bll = new KNet.BLL.Cw_Accounting_Init();
        DataSet ds = this.Dts_Result;
        this.MyGridView1.DataSource = ds;
        MyGridView1.DataBind();
        decimal d_Total = 0, d_ReceTotal = 0, d_InMoney = 0, d_TotayMoney = 0, d_OutMoney = 0;
        if (this.Tbx_CustomerValue.Text != "")
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["CType"].ToString() == "1")
                {
                    d_ReceTotal += -1*decimal.Parse(ds.Tables[0].Rows[i]["YMoney"].ToString());
                }
                else
                {
                    d_Total += decimal.Parse(ds.Tables[0].Rows[i]["YMoney"].ToString());
                }
                string s_InMoney = GetKpMoney(ds.Tables[0].Rows[i]["DetailsID"].ToString(), 2, ds.Tables[0].Rows[i]["CType"].ToString());
                string s_TotayMoney = GetKpMoney(ds.Tables[0].Rows[i]["DetailsID"].ToString(), 3, ds.Tables[0].Rows[i]["CType"].ToString());
                string s_OutMoney = GetKpMoney(ds.Tables[0].Rows[i]["DetailsID"].ToString(), 4, ds.Tables[0].Rows[i]["CType"].ToString());

                d_InMoney += decimal.Parse(s_InMoney == "" ? "0" : s_InMoney);
                d_TotayMoney += decimal.Parse(s_TotayMoney == "" ? "0" : s_TotayMoney);
                d_OutMoney += decimal.Parse(s_OutMoney == "" ? "0" : s_OutMoney);
            }
            if (s_CustomerName == "--")
            {
                Lbl_Details.Text += "| 应付金额：" + d_Total.ToString();
            }
            else
            {
                Lbl_Details.Text += "| 应收金额：" + d_Total.ToString() + "| 收款金额：" + d_ReceTotal.ToString() + " | 未到期金额：" + d_InMoney.ToString() + " | 今天到期金额：" + d_TotayMoney.ToString() + "|  超期金额：" + (d_OutMoney - d_ReceTotal).ToString();
            }
        }
    }
    public string GetKpMoney(string s_DetailsID, int i_Type, string s_CType)
    {
        string s_Return = "";
        try
        {
            if (s_CType == "0")
            {
                //开票金额
                string s_Sql = "Select Sum(-v_Money),v_FID,v_OutNo,b.CAB_BillNumber,";
                s_Sql += "Sum(case when v_OutTime<'" + DateTime.Now.ToShortDateString() + "' then -v_Money  else 0 end ) as OutMoney, ";
                s_Sql += "Sum(case when v_OutTime='" + DateTime.Now.ToShortDateString() + "' then -v_Money  else 0 end ) as NowMoney, ";
                s_Sql += "Sum(case when v_OutTime>'" + DateTime.Now.ToShortDateString() + "' then -v_Money  else 0 end ) as InMoney ";
                s_Sql += "from Cw_Payment_BillDetails a join Cw_Account_Bill b on  a.V_FID=b.CAB_ID";
                s_Sql += " where V_Type='1' and v_OutNo='" + s_DetailsID + "' Group by v_FID,v_OutNo,b.CAB_BillNumber ";
                this.BeginQuery(s_Sql);
                this.QueryForDataTable();
                DataTable Dtb_Table = Dtb_Result;
                if (Dtb_Table.Rows.Count > 0)
                {
                    //先找该明细的发票总单
                    s_Sql = "Select v_OutNo  from Cw_Payment_BillDetails a join KNet_WareHouse_DirectOutList_Details b on a.v_OutNO=b.ID where V_Type='1' and v_FID='" + Dtb_Table.Rows[0][1].ToString() + "' and v_OutNO<>'" + s_DetailsID + "' ";
                    this.BeginQuery(s_Sql);
                    this.QueryForDataTable();
                    DataTable Dtb_Table1 = Dtb_Result;
                    //找
                    if (Dtb_Table1.Rows.Count > 0)
                    {
                        //如果是调整单返回总开票
                        string s_OutDetails = Dtb_Table.Rows[0][2].ToString();

                        if (i_Type == 0)
                        {
                            if (s_OutDetails.IndexOf("T") >= 0)
                            {
                                s_Return = Dtb_Table.Rows[0][0].ToString();
                            }
                        }
                        else if (i_Type == 1) //发票编号
                        {
                            //返回单号
                            if (s_OutDetails.IndexOf("T") >= 0)
                            {

                                s_Return = "<a href=\"../bill/Cw_Account_Bill_View.aspx?ID=" + Dtb_Table.Rows[0][1].ToString() + "\">" + Dtb_Table.Rows[0][3].ToString() + "</a>";
                            }
                        }
                        else if (i_Type == 2) //帐期内
                        {

                            if (s_OutDetails.IndexOf("T") >= 0)
                            {
                                s_Return = Dtb_Table.Rows[0][6].ToString();
                            }
                        }

                        else if (i_Type == 3) //今天
                        {

                            if (s_OutDetails.IndexOf("T") >= 0)
                            {
                                s_Return = Dtb_Table.Rows[0][5].ToString();
                            }
                        }

                        else if (i_Type == 4) //帐期外
                        {

                            if (s_OutDetails.IndexOf("T") >= 0)
                            {
                                s_Return = Dtb_Table.Rows[0][4].ToString();
                            }
                        }
                        else if (i_Type == 5) //超期明细
                        {
                            if (s_OutDetails.IndexOf("T") >= 0)
                            {
                                this.BeginQuery("select -v_Money as Money,* from Cw_Payment_BillDetails where V_Type='1' and v_OutNo='" + s_DetailsID + "' ");
                                this.QueryForDataTable();
                                DataTable Dtb_Table2 = this.Dtb_Result;
                                if (Dtb_Table2.Rows.Count > 0)
                                {
                                    for (int i = 0; i < Dtb_Table2.Rows.Count; i++)
                                    {
                                        s_Return += DateTime.Parse(Dtb_Table2.Rows[i]["v_OutTime"].ToString()).ToShortDateString() + "(" + Dtb_Table2.Rows[i]["Money"].ToString() + ")<br/>";
                                    }
                                    if (s_Return.Length > 0)
                                    {
                                        s_Return = s_Return.Substring(0, s_Return.Length - 5);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (i_Type == 0)
                        {
                            s_Return = Dtb_Table.Rows[0][0].ToString();
                        }
                        else if (i_Type == 1)
                        {
                            s_Return = "<a href=\"../bill/Cw_Account_Bill_View.aspx?ID=" + Dtb_Table.Rows[0][1].ToString() + "\">" + Dtb_Table.Rows[0][3].ToString() + "</a>";
                        }
                        else if (i_Type == 2) //帐期内
                        {
                            s_Return = Dtb_Table.Rows[0][6].ToString();
                        }
                        else if (i_Type == 3) //帐期内
                        {
                            s_Return = Dtb_Table.Rows[0][5].ToString();
                        }
                        else if (i_Type == 4) //帐期内
                        {
                            s_Return = Dtb_Table.Rows[0][4].ToString();
                        }
                        else if (i_Type == 5) //超期明细
                        {
                            this.BeginQuery("select -v_Money as Money,* from Cw_Payment_BillDetails where V_Type='1' and v_OutNo='" + s_DetailsID + "' ");
                            this.QueryForDataTable();
                            DataTable Dtb_Table2 = this.Dtb_Result;
                            if (Dtb_Table2.Rows.Count > 0)
                            {
                                for (int i = 0; i < Dtb_Table2.Rows.Count; i++)
                                {
                                    s_Return += DateTime.Parse(Dtb_Table2.Rows[i]["v_OutTime"].ToString()).ToShortDateString() + "(" + Dtb_Table2.Rows[i]["Money"].ToString() + ")<br/>";
                                }
                                if (s_Return.Length > 0)
                                {
                                    s_Return = s_Return.Substring(0, s_Return.Length - 5);
                                }
                            }
                        }
                    }
                }
            }
            else if (s_CType == "2")//初始化
            {
                //开票金额
                string s_Sql = "Select Sum(CAI_InitMoney),CAI_ID,";
                s_Sql += "Sum(case when CAID_OutTime<'" + DateTime.Now.ToShortDateString() + "' then CAID_Number  else 0 end ) as OutMoney, ";
                s_Sql += "Sum(case when CAID_OutTime='" + DateTime.Now.ToShortDateString() + "' then CAID_Number  else 0 end ) as NowMoney, ";
                s_Sql += "Sum(case when CAID_OutTime>'" + DateTime.Now.ToShortDateString() + "' then CAID_Number  else 0 end ) as InMoney ";
                s_Sql += "from Cw_Accounting_Init_Details a join Cw_Accounting_Init b on  a.CAID_FID=b.CAI_ID";
                s_Sql += " where  a.CAID_FID='" + s_DetailsID + "' Group by CAI_ID ";
                this.BeginQuery(s_Sql);
                this.QueryForDataTable();
                DataTable Dtb_Table = Dtb_Result;
                if (Dtb_Table.Rows.Count > 0)
                {

                    if (i_Type == 2)
                    {
                        s_Return = Dtb_Table.Rows[0][4].ToString();
                    }
                    else if (i_Type == 3)
                    {
                        s_Return = Dtb_Table.Rows[0][3].ToString();
                    }
                    else if (i_Type == 4)
                    {
                        s_Return = Dtb_Table.Rows[0][2].ToString();
                    }
                    else if (i_Type == 5)
                    {
                        s_Sql = "Select Sum(CAID_Number) as CAID_Number,CAID_OutTime ";
                        s_Sql += "from Cw_Accounting_Init_Details a join Cw_Accounting_Init b on  a.CAID_FID=b.CAI_ID";
                        s_Sql += " where  a.CAID_FID='" + s_DetailsID + "' Group by CAID_OutTime ";
                        this.BeginQuery(s_Sql);
                        this.QueryForDataTable();
                        DataTable Dtb_Table2 = this.Dtb_Result;
                        for (int i = 0; i < Dtb_Table2.Rows.Count; i++)
                        {
                            s_Return += DateTime.Parse(Dtb_Table2.Rows[i]["CAID_OutTime"].ToString()).ToShortDateString() + "(" + Dtb_Table2.Rows[i]["CAID_Number"].ToString() + ")<br/>";
                        }
                    }

                }
            }


        }
        catch { }
        return s_Return;

    }
    public string GetCode(string s_Code, string s_CType, string s_ID)
    {
        string s_Return = "";
        if (s_CType == "0")
        {
            s_Return = "<a href=\"../SalesOut/Sales_ShipWareOut_View.aspx?ID=" + s_Code + ">\">" + s_Code + "</a>";
        }
        else if (s_CType == "2")
        {
            s_Return = "<a href=\"Cw_Accounting_Init_View.aspx?ID=" + s_ID + "\">" + s_Code + "</a>";
        }
        else if (s_CType == "1")
        {
            s_Return = "<a href=\"../Rece/Cw_Accounting_Pay_View.aspx?ID=" + s_ID + "\">" + s_Code + "</a>";
        }
        return s_Return;
    }
    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        this.DataShows();
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
                    string s_ID = this.MyGridView1.DataKeys[i].Value.ToString();
                    s_Sql.Append(" delete from  Cw_Accounting_Init Where CAI_ID='" + s_ID + "' ");
                    s_Log.Append(s_ID);
                }
            }
            DbHelperSQL.ExecuteSql(s_Sql.ToString());
            this.DataShows();
            AdminloginMess AM = new AdminloginMess();
            AM.Add_Logs("Cw_Accounting_Init 删除 编号：" + s_Log + "");
            Alert("删除成功！");
        }
        catch (Exception ex)
        {
            Alert("删除失败！");
            return;
        }
    }
    public void Btn_Q_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }

}

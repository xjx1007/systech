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

public partial class Web_Sales_Pb_Products_Sample_List : BasePage
{
    public string s_DivStyle = "";
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                DataShows();
                base.Base_DropBatchBind(this.Ddl_Batch, "Pb_Products_Sample", "PPS_DutyPeson");
                base.Base_DropBindSearch(this.bas_searchfield, "Pb_Products_Sample");
                base.Base_DropBindSearch(this.Fields, "Pb_Products_Sample");
            }
        }
        
    }

    protected void Btn_Del_Click(object sender, EventArgs e)
    {
        AdminloginMess LogAM = new AdminloginMess();
        string sql = "delete from Pb_Products_Sample where"; //删除采购单
        string sql2 = "delete from Pb_Products_Sample_Images where"; //采购单明细
        string sql3 = "delete from Pb_Products_Sample_Confim where"; //采购单明细

        string cal = "", cal2 = "", cal3 = "";
        for (int i = 0; i < this.MyGridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " PPS_ID='" + MyGridView1.DataKeys[i].Value.ToString() + "' or ";
                cal2 += " PPI_SmapleID='" + MyGridView1.DataKeys[i].Value.ToString() + "' or ";
                cal3 += " PBC_SampleID='" + MyGridView1.DataKeys[i].Value.ToString() + "' or ";
            }
        }
        if (cal != "")
        {
            sql += cal.Substring(0, cal.Length - 3);
            sql2 += cal2.Substring(0, cal2.Length - 3);
            sql3 += cal3.Substring(0, cal3.Length - 3);

        }
        else
        {
            sql = "";       //不删除
            sql2 = "";       //不删除
            sql3 = "";       //不删除
            Response.Write("<script language=javascript>alert('您没有选择要删除的记录!');history.back(-1);</script>");
            Response.End();
        }

        DbHelperSQL.ExecuteSql(sql3);
        DbHelperSQL.ExecuteSql(sql2);
        DbHelperSQL.ExecuteSql(sql);

        LogAM.Add_Logs("产品--->样品申请--->样品申请删除 操作成功！");

        this.DataShows();
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
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
        if (this.Ddl_Batch.SelectedValue != "")
        {
            SqlWhere += Base_GetBasicWhere(this.Ddl_Batch.SelectedValue);

        }
        KNet.BLL.Pb_Products_Sample bll = new KNet.BLL.Pb_Products_Sample();
        DataSet ds = bll.GetList(SqlWhere);
        this.MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] { "PPS_ID" };
        MyGridView1.DataBind();
    }

    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        this.DataShows();


    }

    protected void Ddl_Batch_TextChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }
    public string getShState(string s_ID)
    {
        AdminloginMess AM=new AdminloginMess();
        string s_Return = "";
        try
        {
            KNet.BLL.Pb_Products_Sample Bll = new KNet.BLL.Pb_Products_Sample();
            KNet.Model.Pb_Products_Sample Model = Bll.GetModel(s_ID);
            if (Model.PPS_Dept == "101")
            {
                //市场销售部审批
                if ((AM.KNet_StaffDepart == "129652783822281241") && (AM.KNet_Position == "102"))
                {
                    s_Return = "<a href='Pb_Products_Sample_Approval.aspx?ID=" + s_ID + "&Type=0'>审批</a><br>等待 <font color=red>市场销售部</font> 审批";
                }
                else
                {
                    s_Return = "等待 <font color=red>市场销售部</font> 审批";
                }
            }
            if (Model.PPS_Dept == "103")
            {
                //研发中心审批
                if (AM.KNet_StaffDepart == "129652783965723459") //&& (AM.KNet_Position == "102"))
                {
                    s_Return = "<a href='Pb_Products_Sample_Approval.aspx?ID=" + s_ID + "&Type=0'>审批</a><br>等待 <font color=red>研发中心</font> 审批";
                }
                else
                {
                    s_Return = "等待 <font color=red>研发中心</font> 审批";
                }
            }
            else if ((Model.PPS_Dept == "102")||(Model.PPS_Dept == "105"))
            {

                //市场销售部审批
                if (AM.KNet_StaffNo == Model.PPS_DutyPeson)
                {
                    s_Return = "<a href='Pb_Products_Sample_Approval.aspx?ID=" + s_ID + "&Type=0' >确认</a><br>等待 <font color=red>"+AM.KNet_StaffName+"</font> 确认";
                }
                else
                {
                    s_Return = "等待 <font color=red>"+base.Base_GetUserName(Model.PPS_DutyPeson)+"</font> 确认";
                }
            }
            else if (Model.PPS_Dept == "104")//打样确认
            {
                if (AM.KNet_StaffDepart == "129652784446995911")
                {
                    s_Return = "<a href='Pb_Products_Sample_Approval.aspx?ID=" + s_ID + "&Type=0'>确认</a><br>等待 <font color=red>质量部</font> 审批";
                }
                else
                {
                    s_Return = "等待 <font color=red>质量部</font> 审批";
                }
            }
            else if (Model.PPS_Dept == "106")//样品申请
            {
                if (AM.KNet_StaffNo == Model.PPS_DutyPeson)
                {
                    s_Return = "<a href='Pb_Products_Sample_Approval.aspx?ID=" + s_ID + "&Type=0'>样品领用申请</a>";
                }
            }
        }
        catch
        {

        }
        return s_Return;
    }
    public string getDemo(string s_ID)
    {
        string s_Return = "";
        //try
        //{
        //    KNet.BLL.KNet_Sys_ProductsDemo BLL = new KNet.BLL.KNet_Sys_ProductsDemo();
        //    DataSet dts = BLL.GetList(" KSP_SampleId='" + s_ID + "'");
        //    if (dts.Tables[0].Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dts.Tables[0].Rows.Count; i++)
        //        {
        //            s_Return = "<a href=../ProductsModel/KnetProductsSetting_Details.aspx?BarCode=" + dts.Tables[0].Rows[i]["ProductsBarCode"].ToString() + " target=\"_blank\" >" + dts.Tables[0].Rows[i]["ProductsEdition"].ToString() + "</a>" + ",";
        //        }
        //        s_Return = s_Return.Substring(0, s_Return.Length - 1);
        //    }
        //    else
        //    {
        //        s_Return = "<a href=../ProductsModel/KnetProductsSetting_Add.aspx?KSP_SampleId=" + s_ID + " >添加</a>";
         
        //    }
        //}
        //catch (Exception ex)
        //{
 
        //}
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
}

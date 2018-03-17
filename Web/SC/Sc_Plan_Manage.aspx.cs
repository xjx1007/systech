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
using System.Runtime.Serialization.Json;

using KNet.DBUtility;
using KNet.Common;
using System.Net;

/// <summary>
/// 销售管理-----发货单 管理
/// </summary>
public partial class Sc_Plan_Manage : BasePage
{
    public string s_DivStyle = "";
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("生产计划列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            //删除生产计划
            if (AM.YNAuthority("删除生产计划") == false)
            {
                this.Btn_Del.Enabled = false;
            }
            
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                string s_Model = Request.QueryString["Model"] == null ? "" : Request.QueryString["Model"].ToString();
                if ((s_ID != "") && (s_Model == "IsSend"))
                {
                    string s_Sql = " Update Sc_Produce_Plan set SPP_IsSend=ABS(SPP_IsSend-1) where SPP_ID='" + s_ID + "' ";
                    DbHelperSQL.ExecuteSql(s_Sql);
                }
     
            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！\\n\\n注意：该删除会同时删除发货单产品明细记录.')");
            base.Base_DropBatchBind(this.Ddl_Batch, "Sc_Produce_Plan", "Spp_Creator");
            base.Base_DropBindSearch(this.bas_searchfield, "Sc_Produce_Plan");
            base.Base_DropBindSearch(this.Fields, "Sc_Produce_Plan");
            this.DataShows();   
        }

    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.Sc_Produce_Plan bll = new KNet.BLL.Sc_Produce_Plan();
        string SqlWhere = " SPP_Del=0 ";
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        if (s_WhereID != "")
        {
            SqlWhere += Base_GetBasicWhere(s_WhereID);
        }

        if (this.Ddl_Batch.SelectedValue != "")
        {
            SqlWhere += Base_GetBasicWhere(this.Ddl_Batch.SelectedValue);
        }
        if ((this.bas_searchfield.SelectedValue != "") && (search_text.Text != ""))
        {
            SqlWhere += base.Base_GetBasicColumnWhere(this.bas_searchfield.SelectedValue, this.search_text.Text);
        }
        if (this.Ddl_Batch.SelectedValue != "")
        {
            SqlWhere += Base_GetBasicWhere(this.Ddl_Batch.SelectedValue);
        }
        SqlWhere = SqlWhere + " order by SPP_CTime desc";

        DataSet ds = bll.GetList(SqlWhere);
       
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "SPP_ID" };
        GridView1.DataBind();
    }


    protected void Ddl_Batch_TextChanged1(object sender, EventArgs e)
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

 

    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        
        this.DataShows();
    }
    public string GetCk(string s_OutWareNo)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_WareHouse_DirectOutList Bll=new KNet.BLL.KNet_WareHouse_DirectOutList();
            DataSet Dts_Table = Bll.GetList(" KWD_ShipNo='" + s_OutWareNo + "'");
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                s_Return = DateTime.Parse(Dts_Table.Tables[0].Rows[0]["DirectOutDateTime"].ToString()).ToShortDateString();
            }
        }
        catch (Exception ex)
        {
 
        }
        return s_Return;
    }


    protected void Btn_Del_Click(object sender, ImageClickEventArgs e)
    {
        string sql = "delete from Sc_Produce_Plan where"; //删除发货单
        string sql2 = "delete from Sc_Produce_Plan_Details where"; //发货 明细

        string cal = "";
        string cal1 = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)(GridView1.Rows[i].FindControl("Chbk"));
            if (cb.Checked == true)
            {
                cal += " SPP_ID='" + GridView1.DataKeys[i].Value.ToString() + "' or";
                cal1 += " SPD_FaterID='" + GridView1.DataKeys[i].Value.ToString() + "' or";
            }
        }
        if (cal != "")
        {
            sql += cal.Substring(0, cal.Length - 3);
            sql2 += cal1.Substring(0, cal1.Length - 3);
            DbHelperSQL.ExecuteSql(sql);
            DbHelperSQL.ExecuteSql(sql2);

            AdminloginMess LogAM = new AdminloginMess();
            Alert("删除生产计划成功!");
            LogAM.Add_Logs("生产--->生成计划--->生产计划删除 操作成功！+" + cal + "");

            this.DataShows();
        }
        else
        {
            sql = "";       //不删除
            sql2 = "";       //不删除
            Response.Write("<script language=javascript>alert('您没有选择要删除的记录!');history.back(-1);</script>");
            Response.End();
        }


    }

    protected string GetPrint(string s_SPDID, int i_IsSend)
    {
        string s_Return = "";
        if (i_IsSend == 0)
        {
            string JSD = "Sc_Plan_Manage.aspx?ID=" + s_SPDID + "&Model=IsSend";
            s_Return = "<a href=\"" + JSD + "\" onclick=\"\"  ><font color=red>未发送</font></a>";
        }
        else if (i_IsSend == 1)
        {
            string JSD = "Sc_Plan_Manage.aspx?ID=" + s_SPDID + "&Model=IsSend";
            s_Return = "<a href=\"" + JSD + "\" onclick=\"\" >已发送</a>";
        }
        return s_Return;

    }

    protected string CheckView(string s_SPPID,int i_Send)
    {
        string s_Return = "", JSD = "";
        KNet.BLL.Sc_Produce_Plan BLl = new KNet.BLL.Sc_Produce_Plan();
        KNet.Model.Sc_Produce_Plan Model = BLl.GetModel(s_SPPID);

        JSD = "Sc_Plan_Print.aspx?ID=" + s_SPPID + "&M=P";
                s_Return = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=120,left=150,toolbar=yes, menubar=yes,scrollbars=yes, resizable=yes, location=yes, status=yes, width=780,height=500');\"  title=\"点击查看\"><img src=\"../images/View.gif\"  border=\"0\" /></a>";
               // s_Return += "  <a href=\"PDF/" + base.Base_GetSupplierName(Model.SPP_SuppNo) + "(" + base.DateToString(Model.SPP_STime.ToString()) + ".PDF\" class=\"webMnu\" target=\"_blank\"><img src=\"../images/pdf.gif\"  border=\"0\" /></a> ";
                s_Return += "  <a href=\"../Mail/PB_Basic_Mail_Add.aspx?ScNo=" + Model.SPP_ID + "\" class=\"webMnu\" target=\"_blank\"><img src=\"../images/email.gif\"  border=\"0\" /></a> ";

        return s_Return;

    }

    protected string CheckView1(string s_SPPID)
    {
        string s_Return = "", JSD = "";
        KNet.BLL.Sc_Produce_Plan BLl = new KNet.BLL.Sc_Produce_Plan();
        KNet.Model.Sc_Produce_Plan Model = BLl.GetModel(s_SPPID);

        JSD = "SC_Plan_Add.aspx?SuppNo=" + Model.SPP_SuppNo + "";
        s_Return = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=120,left=150,toolbar=yes, menubar=yes,scrollbars=yes, resizable=yes, location=yes, status=yes, width=780,height=500');\"  title=\"更新\">更新</a>";

        return s_Return;

    }
    
}

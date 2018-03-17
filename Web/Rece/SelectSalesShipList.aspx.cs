using System;
using System.Data;
using System.Data.SqlClient;
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

/// <summary>
/// 选择发货单
/// </summary>
public partial class Knet_Common_SelectSalesShipList : BasePage
{
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
                string s_Customer = Request.QueryString["CustomerValue"] == null ? "" : Request.QueryString["CustomerValue"].ToString();
                if (s_Customer != "")
                {
                    this.Tbx_Customer.Text = base.Base_GetCustomerName(s_Customer);
                    this.Tbx_CustomerValue.Text = s_Customer;
                }
                this.DataShows();
            }
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sales_OutWareList bll = new KNet.BLL.KNet_Sales_OutWareList();

        string Sql = " Select * ";
        Sql += " From v_OutDetails_Hx where 1=1 ";
  
        string SqlWhere = " ";//and OutWareCheckYN=1
        string s_CustomerValue = Request.QueryString["CustomerValue"] == null ? "" : Request.QueryString["CustomerValue"].ToString();
        string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
        if (this.Tbx_Customer.Text != "")
        {
            SqlWhere = SqlWhere + " and CustomerName like '%" + this.Tbx_Customer.Text + "%' ";
        }
        if (this.Tbx_CustomerValue.Text != "")
        {
            SqlWhere = SqlWhere + " and CustomerValue like '%" + this.Tbx_CustomerValue.Text + "%' ";

        }
        if (s_ID != "")
        {
            SqlWhere = SqlWhere + " and KWD_ShipNo not in ('" + s_ID.Replace(",", "','") + "') ";
        }
        if (this.FPCOde.Text != "")
        {
            SqlWhere = SqlWhere + " and CAB_BillNumber like'%" + this.FPCOde.Text + "%' ";
        }


        SqlWhere = SqlWhere + " order by KWD_CWOutTime,DirectOutNo,ProductsBarCode  ";

        this.BeginQuery(Sql + SqlWhere);
        this.QueryForDataTable();
        DataSet Dts_Table = this.Dts_Result;
        this.MyGridView1.DataSource = Dts_Table;
        MyGridView1.DataKeyNames = new string[] { "ID" };
        this.MyGridView1.DataBind();
    }

    protected string GetOutWareListfollowup(object OutWareNo, object DirectOutNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select top 1 ID,FollowNo,OutWareNo,FollowDateTime,FollowStaffNo,FollowText,FollowEnd from KNet_Sales_OutWareList_FlowList where OutWareNo='" + OutWareNo + "' order by FollowDateTime desc";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["FollowEnd"].ToString() == "True")
                {
                    return "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 500,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "</a>&nbsp;<font color=red>结束</font><a href=\"#\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "&DirectOutNo=" + DirectOutNo + "', 780, 500,false,false);\">添加</a>";//&nbsp;<font color=\"gray\">" + base.Base_GetUserName(dr["FollowStaffNo"].ToString()) + "&nbsp;(" + dr["FollowDateTime"].ToString() + ")</font>
                }
                else
                {
                    return "<img src=\"../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 500,false,false);\">" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40) + "</a>&nbsp;<img src=\"../images/45.gif\" width=\"11\" height=\"11\" border=\"0\" /><a href=\"#\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "&DirectOutNo=" + DirectOutNo + "', 780, 500,false,false);\">添加</a>";
                }
            }
            else
            {
                return "<a href=\"#\" onclick=\"lhgdialog.opendlg('发货单号:<font color=Red>" + OutWareNo + "</font> 跟踪', '../SalesOut/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "&DirectOutNo=" + DirectOutNo + "', 780, 500,false,false);\">添加</a>";
            }
        }
    }
    /// <summary>
    /// 确定选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string s_ID = "", s_CAOID = "", s_Type="";
        int KK = 0;
        for (int i = 0; i < this.MyGridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
            TextBox Tbx_CAO_ID = (TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_CAO_ID");
            TextBox Tbx_Type = (TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_Type");

            if (cb.Checked == true)
            {
                s_ID += MyGridView1.DataKeys[i].Value.ToString() + ",";
                s_CAOID += Tbx_CAO_ID.Text.ToString() + ",";
                s_Type += Tbx_Type.Text.ToString() + ",";
                
                KK = KK + 1;
            }
        }
        if (KK == 0)
        {
            Alert("您没有选择记录！");
        }
        else
        {
            StringBuilder s = new StringBuilder();
            s.Append("<script language=javascript>" + "\n");
            s.Append("window.returnValue='" + s_ID.Substring(0, s_ID.Length - 1) + "|" + s_CAOID.Substring(0, s_CAOID.Length - 1) + "|" + s_Type.Substring(0, s_Type.Length - 1) + "'\n");
            s.Append("window.close();" + "\n");
            s.Append("</script>");
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            string csname = "ltype";
            if (!cs.IsStartupScriptRegistered(cstype, csname))
                cs.RegisterStartupScript(cstype, csname, s.ToString());
        }
    }


    public string GetReceive(string s_Sate, string s_DirectOutNo)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_WareHouse_DirectOutList BLl = new KNet.BLL.KNet_WareHouse_DirectOutList();
            KNet.Model.KNet_WareHouse_DirectOutList Model = BLl.GetModelB(s_DirectOutNo);
            if ((Model.KWD_KpType == "5") || (Model.KWD_ShipType == "0"))
            {
                s_Return = "<font color=red>无需发票</font>";
            }
            else
            {
                s_Return = Base_GetBasicCodeName("212", s_Sate, "/Web/Receive/Cw_Accounting_Payment_Add.aspx?OutWareNo=" + Model.KWD_ShipNo + "");
            }
        }
        catch
        { }
        return s_Return;
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        this.DataShows();
    }

    public string FPDetails(string s_ID)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "select * from Cw_Account_Bill a join ";
            s_Sql += "Cw_Account_Bill_Details b on a.CAB_ID=b.CAD_CAAID ";
            s_Sql += "join Cw_Account_Bill_Outimes c on c.CAO_CADID=a.CAB_ID ";
            s_Sql += " where CAD_OutNo='" + s_ID + "' order by CAO_OutTime";
            this.BeginQuery(s_Sql);
            DataTable Dtb_table = this.QueryForDataTable();
            for (int i = 0; i < Dtb_table.Rows.Count; i++)
            {
                s_Return += base.DateToString(Dtb_table.Rows[i]["CAO_OutTime"].ToString()) + "|" + Dtb_table.Rows[i]["CAO_Money"].ToString();
                s_Return += "<br/>";
            }
        }
        catch
        { }
        return s_Return;
    }
    public string GetOutTime(string s_Time)
    {
        string s_Return = "";
        try
        {
            s_Return = base.DateToString(s_Time);
        }
        catch
        { }
        return s_Return;
    }

    public string GetOutTimeDays(string s_Days)
    {
        string s_Return = "";
        try
        {
            int i_Days = int.Parse(s_Days);
            if (i_Days > 0)
            {
                s_Return = "<font color=red><b>" + i_Days + "</b></font>";
            }
        }
        catch
        { }
        return s_Return;
    }
}

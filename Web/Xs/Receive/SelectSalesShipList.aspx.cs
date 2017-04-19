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
                ViewState["SortOrder"] = "OutWareDateTime";
                ViewState["OrderDire"] = "Desc";
                this.DataShows();
                string s_Customer = Request.QueryString["CustomerValue"] == null ? "" : Request.QueryString["CustomerValue"].ToString();
                if (s_Customer != "")
                {
                    this.Tbx_Customer.Text = base.Base_GetCustomerName_Link(s_Customer);
                }
            }
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sales_OutWareList bll = new KNet.BLL.KNet_Sales_OutWareList();

        string Sql = " Select a.*,b.KWD_CwCode,b.KWD_Custmoer,v_leftNumber,v_leftNumber*a.KWD_SalesUnitPrice as Money,b.KWD_ShipNo,b.DirectOutDateTime,b.DirectOutStaffBranch,b.HouseNo,b.DirectOutStaffNo ";
        Sql += " From KNet_WareHouse_DirectOutList_Details a join KNet_WareHouse_DirectOutList b on a.DirectOutNo=b.DirectOutNo";
        Sql += " join KNet_Sales_OutWareList c on c.OutWareNo=b.KWD_ShipNo ";
        Sql += " join v_Receive_Number e on e.v_DetailsID=a.ID ";
        Sql += "  Where isNull(KWD_Type,'101')='101' and DirectOutUnitPrice<>0 and e.v_State<>'2' and KWD_SystemChange='0'  ";
        string SqlWhere = " ";//and OutWareCheckYN=1
        string s_CustomerValue = Request.QueryString["CustomerValue"] == null ? "" : Request.QueryString["CustomerValue"].ToString();
        string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
        if (s_CustomerValue != "")
        {
            SqlWhere = SqlWhere + " and KWD_Custmoer='" + s_CustomerValue + "' ";
        }
        if (s_ID != "")
        {
            SqlWhere = SqlWhere + " and b.KWD_ShipNo not in ('" + s_ID.Replace(",", "','") + "') ";
        }
        SqlWhere = SqlWhere + " order by KWD_DirectOutNo desc ";
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
        string s_ID = "";
        int KK = 0;
        for (int i = 0; i < this.MyGridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                s_ID += MyGridView1.DataKeys[i].Value.ToString()+",";
                KK = KK + 1;
            }
        }
         if (KK == 0)
        {
            Alert("您没有选择记录！");
        }
        else
        {
            string s_Return = "";
            s_Return = s_ID.Substring(0, s_ID.Length - 1);
            StringBuilder s = new StringBuilder();
            s.Append("<script language=javascript>" + "\n");
            s.Append("if (window.opener != undefined)\n");
            s.Append("{\n");
            s.Append("    window.opener.returnValue = '" + s_Return + "';\n");
            s.Append("    window.opener.SetReturnValueInOpenner_SalesShip('" + s_Return + "');\n");
            s.Append("}\n");
            s.Append("else\n");
            s.Append("{\n");
            s.Append("    window.returnValue = '" + s_Return + "';\n");
            s.Append("}\n");
            s.Append("window.close();" + "\n");
            s.Append("</script>");
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            string csname = "ltype";
            if (!cs.IsStartupScriptRegistered(cstype, csname))
                cs.RegisterStartupScript(cstype, csname, s.ToString());
        }
    }
}

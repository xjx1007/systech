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

using KNet.DBUtility;
using KNet.Common;
using System.Data.SqlClient;

public partial class System_Message_List : BasePage
{

    public string s_unreadStyle = "", s_inboxStyle = "", s_sentStyle = "", s_Title = "手机短信";
    protected void Page_Load(object sender, EventArgs e)
    {
        string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("短消息列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            this.Tbx_Type.Text = s_Type;

            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");
            this.DataShows();
        }


    }
    public void DataShows()
    {
        AdminloginMess AM = new AdminloginMess();

        KNet.BLL.System_PhoneMessage_Manage bll = new KNet.BLL.System_PhoneMessage_Manage();
        string s_Sql = "SPM_Del=0 ";
        string  s_Type=this.Tbx_Type.Text;

        s_Sql += " Order by SPM_SendTime desc";
        DataSet ds = bll.GetList(s_Sql);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "SPM_ID" };
        GridView1.DataBind();
        ds.Dispose();
    }

    protected void Btn_Del_Click(object sender, EventArgs e)
    {
        string sql = "Update System_PhoneMessage_Manage set SPM_Del='1' " ; //删除
        sql +=" where";
        AdminloginMess LogAM = new AdminloginMess();
        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " SPM_ID='" + GridView1.DataKeys[i].Value.ToString() + "' or";
            }
        }
        if (cal != "")
        {
            sql += cal.Substring(0, cal.Length - 3);

        }
        else
        {
            Response.Write("<script language=javascript>alert('您没有选择要删除的记录!');history.back(-1);</script>");
            Response.End();
        }

        DbHelperSQL.ExecuteSql(sql);
        LogAM.Add_Logs("系统设置--->短消息管理--->短消息删除 操作成功！");
        this.DataShows();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {

    }
    public string  GetState(string s_State)
    {
        if (s_State == "1")
        {
            return "<img src=\"../../themes/softed/images/unread.jpg\" alt=\"未读\">";
        }
        else
        {
            return "<img src=\"../../themes/softed/images/read.jpg\" alt=\"已读\">";
 
        }

    }
    public string GetDetails(string s_Details)
    {
        return KNetPage.KHtmlDiscode(s_Details);
    }

    protected void Btn_Edit_Click(object sender, EventArgs e)
    {
        AdminloginMess LogAM = new AdminloginMess();
        string sql = "Update System_PhoneMessage_Manage set SPM_UnRead='0' and SPM_LookTime='" + DateTime.Now.ToString() + "'  where"; //删除采购单
        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " SPM_ID='" + GridView1.DataKeys[i].Value.ToString() + "' or";
            }
        }
        if (cal != "")
        {
            sql += cal.Substring(0, cal.Length - 3);

        }
        else
        {
            Response.Write("<script language=javascript>alert('您没有选择要已读的记录!');history.back(-1);</script>");
            Response.End();
        }

        DbHelperSQL.ExecuteSql(sql);
        Alert("已读成功！");
        LogAM.Add_Logs("系统设置--->短消息管理--->短消息已读 操作成功！" + cal);
        this.DataShows();
    }
    protected void Btn_DelAll_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();

        string s_Sql = "Update System_PhoneMessage_Manage set SPM_Del='1'   where    "; //删除采购单
        string s_Type = this.Tbx_Type.Text;
        if (s_Type == "unread")
        {
            s_Sql += "  SPM_UnRead='1' and SPM_ReceiveID='" + AM.KNet_StaffNo + "' ";
        }
        else if (s_Type == "inbox")
        {
            s_Sql += "   SPM_UnRead='0'  and  SPM_ReceiveID='" + AM.KNet_StaffNo + "' ";
        }
        else if (s_Type == "sent")
        {
            s_Sql = "Update System_PhoneMessage_Manage set SPM_Del='1'  where    "; //删除采购单
            s_Sql += "   SPM_UnRead='0'  and  SPM_SenderID='" + AM.KNet_StaffNo + "' ";
        }
        DbHelperSQL.ExecuteSql(s_Sql);
        Alert("一键清空成功！");
        AM.Add_Logs("系统设置--->短消息管理--->短消息一键清空 操作成功！"+AM.KNet_StaffName);
        this.DataShows();
    }
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }
    
}

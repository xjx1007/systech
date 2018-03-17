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
/// 发货 跟踪信息 添加
/// </summary>
public partial class KNet_Web_Sales_Knet_Sales_Ship_Manage_Talks_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "发货跟踪信息添加";

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

                if (Request.QueryString["OutWareNo"] != null && Request.QueryString["OutWareNo"] != "")
                {
                    this.HyperLink2.NavigateUrl = "Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + Request.QueryString["OutWareNo"].Trim() + "&Sn=" + DateTime.Now.ToFileTimeUtc().ToString() + "";
                    this.HyperLink1.NavigateUrl = "Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + Request.QueryString["OutWareNo"].Trim() + "&Sn=" + DateTime.Now.ToFileTimeUtc().ToString() + "";
                    string s_ID=Request.QueryString["OutWareNo"].ToString();
              
                }
                else
                {
                    Response.Write("<script language=javascript>alert('非法请求参数！');window.close();</script>");
                    Response.End();
                }
            }

        }
    }

    /// <summary>
    /// 确定添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (AM.CheckLogin() == false)
        {
            Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
            Response.End();
        }
        else
        {
            string OutWareNo = null;
            string FollowNo = DateTime.Now.ToFileTimeUtc().ToString();
            DateTime FollowDateTime = DateTime.Now;
            bool FollowEnd = false;

            string FollowStaffNo = AM.KNet_StaffNo;
            string FollowText = this.FollowText.Text.Trim();

        
            if (Request.QueryString["OutWareNo"] != null && Request.QueryString["OutWareNo"] != "")
            {
                OutWareNo = Request.QueryString["OutWareNo"].Trim();
            }
            else
            {
                Response.Write("<script language=javascript>alert('非法请求参数！');window.close();</script>");
                Response.End();
            }



            KNet.BLL.KNet_Sales_OutWareList_FlowList BLL = new KNet.BLL.KNet_Sales_OutWareList_FlowList();
            KNet.Model.KNet_Sales_OutWareList_FlowList model = new KNet.Model.KNet_Sales_OutWareList_FlowList();

            model.FollowNo = FollowNo;
            model.OutWareNo = OutWareNo;
            model.FollowDateTime = FollowDateTime;
            model.FollowStaffNo = FollowStaffNo;
            model.FollowText = FollowText;
            model.FollowEnd = FollowEnd;
            try
            {
                    BLL.Add(model);

                    AdminloginMess LogAM = new AdminloginMess();
                    LogAM.Add_Logs("销售管理--->跟踪添加--->跟踪添加 操作成功！发货单号：" + OutWareNo);
                    KNet.BLL.Pb_Products_Sample Bll_Sample = new KNet.BLL.Pb_Products_Sample();
                    KNet.Model.Pb_Products_Sample Model_Sample = Bll_Sample.GetModel(OutWareNo);
                    if (Model_Sample != null)
                    {
                        base.Base_SendMessage(Model_Sample.PPS_DutyPeson, KNetPage.KHtmlEncode("样品跟踪情况： <a href='web/Sales/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + Model_Sample.PPS_Name + "</a> ，敬请关注！"));

                    }

                    Response.Write("<script>alert('跟踪添加 成功！');location.href='Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "';</script>");
                    Response.End();

            }
            catch
            {
                Response.Write("<script>alert('跟踪添加 失败2！');history.back(-1);</script>");
                Response.End();
            }
        }
    }

}

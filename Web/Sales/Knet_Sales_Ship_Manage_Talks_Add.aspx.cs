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
            this.BeginQuery("Select * from PB_Basic_Wl ");
            this.QueryForDataTable();
            this.Drop_KD.DataSource = this.Dtb_Result;
            this.Drop_KD.DataTextField = "PBW_Name";
            this.Drop_KD.DataValueField = "PBW_Code";
            this.Drop_KD.DataBind();
            ListItem item = new ListItem("--请选择--", "-1"); //默认值
            Drop_KD.Items.Insert(0, item);
            base.Base_DropBasicCodeBind(this.Ddl_Type, "211");
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("发货单跟踪") == false)
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
                    if (s_ID.IndexOf("O") > 0)
                    {
                        //如果是采购单
                        Tr_time.Visible = true;
                        KNet.BLL.Knet_Procure_OrdersList  bll= new KNet.BLL.Knet_Procure_OrdersList();
                        KNet.Model.Knet_Procure_OrdersList Model = bll.GetModelB(s_ID);
                        this.Tbx_OldTime.Text = base.DateToString(Model.OrderPreToDate.ToString());
                    }
                }
                else
                {
                    Response.Write("<script language=javascript>alert('非法请求参数！');window.close();</script>");
                    Response.End();
                }
            }

        }
    }


    protected void FollowEnd_CheckedChanged(object sender, EventArgs e)
    {
        if (this.FollowEnd.Checked)
        {
            this.Pan_Details.Visible = false;
            Tr_Qr.Visible = true;
        }
        else
        {
            this.Pan_Details.Visible = true;
            Tr_Qr.Visible = false;
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
            bool FollowEnd = this.FollowEnd.Checked;

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
            model.KDCode = this.Tbx_Code.Text;
            model.KDName = this.Drop_KD.SelectedValue;
            model.KDCodeName = this.Drop_KD.SelectedItem.Text;
            model.ReturnType = this.Ddl_Type.SelectedValue;
            try
            {
                model.OldTime = DateTime.Parse(this.Tbx_OldTime.Text);
            }
            catch
            { }
            try
            {
                model.ReTime = DateTime.Parse(this.Tbx_Time.Text);
            }
            catch
            { }
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
                    if (Tr_time.Visible == true)
                    {
                        try
                        {
                            if (this.Tbx_Time.Text != "")
                            {
                                string s_Sql = "Update Knet_Procure_OrdersList set KPO_OldPreToDate=OrderPreToDate,OrderPreToDate='" + this.Tbx_Time.Text + "' where OrderNo='" + OutWareNo + "' ";
                                DbHelperSQL.ExecuteSql(s_Sql);
                                Alert("交期确认成功！");
                            }
                            else
                            {
                                Alert("添加情况成功！");
                            }
                        }
                        catch { }

                    }
                    else
                    {
                        StringBuilder s = new StringBuilder();
                        s.Append("<script language=javascript>" + "\n");
                        s.Append("var returnVal = window.confirm(\"添加数据成功!是否创建应收款计划？\",\"创建应收款计划\");" + "\n");
                        s.Append("if(!returnVal){" + "\n");
                        s.Append("window.parent.refresh()" + "\n");
                        s.Append("}else{" + "\n");
                        s.Append(" window.location.href = \"../Receive/Cw_Accounting_Payment_Add.aspx?OutWareNo=" + OutWareNo + "\";}" + "\n");
                        s.Append("</script>");
                        Type cstype = this.GetType();
                        ClientScriptManager cs = Page.ClientScript;
                        string csname = "ltype";
                        if (!cs.IsStartupScriptRegistered(cstype, csname))
                            cs.RegisterStartupScript(cstype, csname, s.ToString());
                    }

                   // Response.Write("<script>alert('跟踪添加 成功！');location.href='Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "';</script>");
                   // Response.End();

            }
            catch
            {
                Response.Write("<script>alert('跟踪添加 失败2！');history.back(-1);</script>");
                Response.End();
            }
        }
    }

}

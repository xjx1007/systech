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
public partial class Knet_Sales_Ship_Manage_Talks_Add : BasePage
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
            this.Pan_DirectOut.Visible = false;
            AdminloginMess AM = new AdminloginMess();
            this.Lbl_Dtails.Text = "动态跟踪情况：";
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
                    string s_ID = Request.QueryString["OutWareNo"].ToString();
                    if (s_ID.IndexOf("O") > 0)
                    {
                        //如果是采购单
                        Tr_time.Visible = true;
                    }
                    KNet.BLL.KNet_Sales_OutWareList BLL_OutWare = new KNet.BLL.KNet_Sales_OutWareList();
                    KNet.Model.KNet_Sales_OutWareList Model = BLL_OutWare.GetModelB(s_ID);

                    if (Model.KSO_ContentPersonName != "")
                    {
                        this.Tbx_ReceiveName.Text = Model.KSO_ContentPersonName;//收货联系人
                    }
                    else
                    {
                        this.Tbx_ReceiveName.Text = base.Base_GetLinkManValue(Model.OutWareSideContact, "XOL_Name");//收货联系人
                    }
                    this.Tbx_Phone.Text =Model.KSO_TelPhone ;
                    this.Tbx_CustomerName.Text = base.Base_GetCustomerName(Model.CustomerValue);
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
            this.Pan_DirectOut.Visible = true;

            if (Request.QueryString["OutWareNo"] != null && Request.QueryString["OutWareNo"] != "")
            {
                string s_OutWareNo = Request.QueryString["OutWareNo"].ToString();
                KNet.BLL.KNet_WareHouse_DirectOutList_Details Bll = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
                DataSet Dts_Table = Bll.GetList(" isnull(KWD_SalesCheck,0)=0 and DirectOutNo in(Select DirectOutNo from  KNet_WareHouse_DirectOutList where  KWD_ShipNo='" + s_OutWareNo + "')");
                this.MyGridView1.DataSource = Dts_Table;
                this.MyGridView1.DataBind();
            }
            Tr_Qr.Visible = true;
        }
        else
        {
            this.Pan_Details.Visible = true;
            this.Pan_DirectOut.Visible = false;
            Tr_Qr.Visible = false;
        }
        if (FollowEnd.Checked)
        {
            Chk_Check.Checked = false;
        }
        else
        {
            Chk_Check.Checked = true;
        }
    }
    protected void Chk_CheckedChanged(object sender, EventArgs e)
    {
        if (this.Chk_Check.Checked)
        {
            this.Pan_Details.Visible = false;
            this.Pan_DirectOut.Visible = true;

            if (Request.QueryString["OutWareNo"] != null && Request.QueryString["OutWareNo"] != "")
            {
                string s_OutWareNo = Request.QueryString["OutWareNo"].ToString();
                KNet.BLL.KNet_WareHouse_DirectOutList_Details Bll = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
                DataSet Dts_Table = Bll.GetList(" isnull(KWD_SalesCheck,0)=0 and DirectOutNo in(Select DirectOutNo from  KNet_WareHouse_DirectOutList where  KWD_ShipNo='" + s_OutWareNo + "')");
                this.MyGridView1.DataSource = Dts_Table;
                this.MyGridView1.DataBind();
            }
            Tr_Qr.Visible = true;
        }
        else
        {
            this.Pan_Details.Visible = true;
            this.Pan_DirectOut.Visible = false;
            Tr_Qr.Visible = false;
        }
        if (Chk_Check.Checked)
        {
            FollowEnd.Checked = false;
        }
        else
        {
            FollowEnd.Checked = true;
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
            if (this.Chk_Message.Checked == true)
            {
                model.KSO_IsMessage = 1;
            }
            else
            {
                model.KSO_IsMessage = 0;
            }
            if (this.Chk_IsReview.Checked == true)
            {
                model.KSO_Isreview = "1";
                model.FollowText = "评审确认," + model.FollowText;
            }
            else
            {
                model.KSO_Isreview = "0";
            }
            try
            {
                model.ReTime = DateTime.Parse(this.Tbx_Time.Text);
            }
            catch
            { }
            try
            {
                for (int i = 0; i < this.MyGridView1.Rows.Count; i++)
                {
                    CheckBox Chk_cb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
                    TextBox Tbx_DID = (TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_DID");
                    //初步确认
                    if ((this.FollowEnd.Checked)||(this.Chk_Check.Checked))
                    {
                        string s_Sql = " Update KNet_WareHouse_DirectOutList_Details Set KWD_SalesCheck='1' where ID='" + Tbx_DID.Text + "' ";
                        DbHelperSQL.ExecuteSql(s_Sql);
                        AM.Add_Logs(" 出库明细确认 ID：" + Tbx_DID.Text + " 人员：" + AM.KNet_StaffName);
                    }
                    if(this.Chk_Message.Checked)
                    {
                        string s_Sql = " Update KNet_WareHouse_DirectOutList_Details Set KWD_IsSend='1' where ID='" + Tbx_DID.Text + "' ";
                        DbHelperSQL.ExecuteSql(s_Sql);
                        AM.Add_Logs(" 出库短信通知 ID：" + Tbx_DID.Text + " 人员：" + AM.KNet_StaffName);
                        
                    }
                }

                BLL.Add(model);
                string s_Return = "";
                if (this.Chk_Message.Checked)
                {//发送短信
                    string[] s_Message = this.Tbx_Message.Text.Split('|');
                    string[] s_DirectOutNo = this.Tbx_DirectOutNo.Text.Split('|');
                    for (int i = 0; i < s_Message.Length; i++)
                    {

                        KNet.BLL.System_PhoneMessage_Manage BLL_PhoneMessage = new KNet.BLL.System_PhoneMessage_Manage();
                        KNet.Model.System_PhoneMessage_Manage model_PhoneMessage = new KNet.Model.System_PhoneMessage_Manage();
                        model_PhoneMessage.SPM_ID = base.GetMainID();
                        model_PhoneMessage.SPM_Del = 0;
                        model_PhoneMessage.SPM_ReceiveID = this.Tbx_ReceiveID.Text;
                        model_PhoneMessage.SPM_ReceiveName = this.Tbx_CustomerName.Text+this.Tbx_ReceiveName.Text;
                        model_PhoneMessage.SPM_ReceivePhone = this.Tbx_Phone.Text;
                        model_PhoneMessage.SPM_SenderID = AM.KNet_StaffNo;
                        model_PhoneMessage.SPM_State = 0;
                        model_PhoneMessage.SPM_Detail = s_Message[i];
                        model_PhoneMessage.SPM_SendTime = DateTime.Now;
                        model_PhoneMessage.SPM_Type = 0;
                        model_PhoneMessage.SPM_FID = s_DirectOutNo[i];
                        AM.Add_Logs("系统设置--->短消息--->短消息 发送 操作成功！名称：" + this.Tbx_ReceiveName.Text);
                        BLL_PhoneMessage.Add(model_PhoneMessage);
                        Message Message = new Message();
                        try
                        {
                            s_Return = Message.SendMessage(this.Tbx_Phone.Text, s_Message[i]);
                        }
                        catch
                        {
                            s_Return="发送短信失败！";
                        }
                    }
                }
                if (this.Chk_IsReview.Checked == true)
                {
                    string sql = " update KNet_Sales_OutWareList  set OutWareIsReview=1  where  OutWareNo='" + OutWareNo + "' ";
                    DbHelperSQL.ExecuteSql(sql);
                }
                AM.Add_Logs("销售管理--->跟踪添加--->跟踪添加 操作成功！发货单号：" + OutWareNo);
                KNet.BLL.Pb_Products_Sample Bll_Sample = new KNet.BLL.Pb_Products_Sample();
                KNet.Model.Pb_Products_Sample Model_Sample = Bll_Sample.GetModel(OutWareNo);
                if (Model_Sample != null)
                {
                    base.Base_SendMessage(Model_Sample.PPS_DutyPeson, KNetPage.KHtmlEncode("样品跟踪情况： <a href='web/Sales/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + Model_Sample.PPS_Name + "</a> ，敬请关注！"));

                }
                StringBuilder s = new StringBuilder();
                s.Append("<script language=javascript>" + "\n");
                s.Append("var returnVal = window.confirm(\"" + s_Return + "添加数据成功!是否创建应收款计划？\",\"创建应收款计划\");" + "\n");
                s.Append("if(!returnVal){" + "\n");
                s.Append("location.href='Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "';" + "\n");
                s.Append("}else{" + "\n");
                s.Append(" window.location.href = \"../Receive/Cw_Accounting_Payment_Add.aspx?OutWareNo=" + OutWareNo + "\";}" + "\n");
                s.Append("</script>");
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                string csname = "ltype";
                if (!cs.IsStartupScriptRegistered(cstype, csname))
                    cs.RegisterStartupScript(cstype, csname, s.ToString());

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

    protected void Chk_Message_CheckedChanged(object sender, EventArgs e)
    {
        if (Chk_Message.Checked)
        {
            this.Pan_DirectOut.Visible = true;
            this.Panel1.Visible = false;
            this.Pan_Details.Visible = false;
            this.Pan_Message.Visible = true;
            this.Lbl_Dtails.Text = "短消息：";
           if (Request.QueryString["OutWareNo"] != null && Request.QueryString["OutWareNo"] != "")
            {
                string s_OutWareNo = Request.QueryString["OutWareNo"].ToString();
                KNet.BLL.KNet_WareHouse_DirectOutList_Details Bll = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
                DataSet Dts_Table = Bll.GetList(" isnull(KWD_IsSend,0)=0 and DirectOutNo in(Select DirectOutNo from  KNet_WareHouse_DirectOutList where  KWD_ShipNo='" + s_OutWareNo + "')");
                this.MyGridView1.DataSource = Dts_Table;
                this.MyGridView1.DataBind();
                string s_message = "", s_DirectNo = "", s_message1 = "";
               for(int i=0;i<Dts_Table.Tables[0].Rows.Count;i++)
               {
                   string s_DirectOutNo=Dts_Table.Tables[0].Rows[i]["DirectOutNo"].ToString();
                   KNet.BLL.KNet_WareHouse_DirectOutList Bll_DirectOut = new KNet.BLL.KNet_WareHouse_DirectOutList();
                   KNet.Model.KNet_WareHouse_DirectOutList model = Bll_DirectOut.GetModelB(s_DirectOutNo);
                   DateTime D_OutTime = DateTime.Parse(model.DirectOutDateTime.ToString());
                   s_message += "尊敬的" + this.Tbx_CustomerName.Text + "-" + this.Tbx_ReceiveName.Text + ",";
                   s_message += "贵司订购的型号为" + base.Base_GetProductsPattern(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "的成品";
                   s_message += "已于" + D_OutTime.Year.ToString() + "年" + D_OutTime.Month.ToString() + "月" + D_OutTime.Day.ToString() + "日通过" + GetDirectOutListfollowup(s_DirectOutNo, "0") + "发送,单号为" + GetDirectOutListfollowup(s_DirectOutNo, "1") + ",请注意查收"+"|";
                   s_message1 += "尊敬的CustomerName-ReceiveName,";
                   s_message1 += "贵司订购的型号为" + base.Base_GetProductsPattern(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "的成品";
                   s_message1 += "已于" + D_OutTime.Year.ToString() + "年" + D_OutTime.Month.ToString() + "月" + D_OutTime.Day.ToString() + "日通过" + GetDirectOutListfollowup(s_DirectOutNo, "0") + "发送,单号为" + GetDirectOutListfollowup(s_DirectOutNo, "1") + ",请注意查收"+"|";
                  
                   s_DirectNo += s_DirectOutNo + "|";
               }
               if (s_message != "")
               {
                   this.FollowText.Text = s_message.Substring(0, s_message.Length - 1);
                   this.Tbx_Message.Text = s_message.Substring(0, s_message.Length - 1);
                   this.Tbx_OldMessage.Text = s_message1.Substring(0, s_message1.Length - 1);
                   this.Tbx_DirectOutNo.Text = s_DirectNo;
               }
            }
        }
        else
        {
            this.Lbl_Dtails.Text = "动态跟踪情况：";
            this.Panel1.Visible = true;
            this.Pan_Details.Visible = true;
            this.Pan_Message.Visible = false;
            
            this.Pan_DirectOut.Visible = false;
        }
    }
    /// <summary>
    /// 返回发货跟踪 最新一条记录（Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetDirectOutListfollowup(object DirectOutNo,string s_type)
    {
        string s_Return = "";
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select top 1 * from KNet_Sales_OutWareList_FlowList where OutWareNo='" + DirectOutNo + "' order by FollowDateTime desc";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (s_type == "0")
                {
                    s_Return = dr["KDCodeName"].ToString();
                }
                else
                {
                    s_Return = dr["KDCode"].ToString();
 
                }
            }
            return s_Return;
        }
    }
}

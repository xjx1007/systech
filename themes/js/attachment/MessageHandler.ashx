
<%@ WebHandler Language="C#" Class="MessageHandler" %>
using System.Web;
using System.Web.SessionState;
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
using KNet.DBUtility;
using KNet.Common;

public class MessageHandler : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.Clear();
        context.Response.Buffer = true;
        int i_IsMessage = 0;
        string strReceivedID = Convert.ToString(context.Session["KNet_Admin_StaffNo"]);
        //if (this.getIsMessageExists(context))
        //{
        //    i_IsMessage = 1;
        //}
        getIsMessageExists(context);
        SendMail();
        //context.Response.Write(i_IsMessage);
        //context.Response.Flush();
        //context.Response.End();
    }

    public void getIsMessageExists(HttpContext context)
    {
        KNet.DBUtility.AdminloginMess adminLogin = new KNet.DBUtility.AdminloginMess();
        KNet.BLL.System_Message_Manage Message = new KNet.BLL.System_Message_Manage();
        KNet.Model.System_Message_Manage Model = new KNet.Model.System_Message_Manage();
        StringBuilder s_Return = new StringBuilder();
        StringBuilder s_Return1 = new StringBuilder();
        StringBuilder s_Return2 = new StringBuilder();
        BasePage Page = new BasePage();
        //Model.SMM_State = 0;
        //Model.SMM_Del = 0;
        //Model.SMM_UnRead = 1;
        //Model.SMM_ReceiveID = adminLogin.KNet_StaffNo;
        //return Message.Exists(Model);
        string sql = " SMM_State=0 and SMM_Del=0 and SMM_UnRead=1 and SMM_ReceiveID='" + adminLogin.KNet_StaffNo + "' order by SMM_SendTime desc";
        DataSet Smm_Table = Message.GetList1(sql);
        if (Smm_Table.Tables[0].Rows.Count > 0)
        {
            if (context.Application.Get(adminLogin.KNet_StaffCard.ToString()) == null)
            {
                context.Application.Lock();
                context.Application.Add(adminLogin.KNet_StaffCard.ToString(), Smm_Table.Tables[0].Rows[0]["SMM_SendTime"]);
                context.Application.UnLock();

                s_Return.Append("{");
                s_Return.Append("sms_id:\"" + Smm_Table.Tables[0].Rows[0]["SMM_ID"].ToString() + "\",");
                s_Return.Append("to_id:\"" + Smm_Table.Tables[0].Rows[0]["SMM_ReceiveID"].ToString() + "\",");
                s_Return.Append("from_id:\"" + Smm_Table.Tables[0].Rows[0]["SMM_SenderID"].ToString() + "\",");
                s_Return.Append("from_name:\"" + Page.Base_GetUserName(Smm_Table.Tables[0].Rows[0]["SMM_SenderID"].ToString()) + "\",");
                s_Return.Append("type_id:\"" + Smm_Table.Tables[0].Rows[0]["SMM_Type"].ToString() + "\",");
                s_Return.Append("type_name:\"" + Page.Base_GetBasicCodeName("147", Smm_Table.Tables[0].Rows[0]["SMM_Type"].ToString()) + "\",");
                s_Return.Append("send_time:\"" + DateTime.Parse(Smm_Table.Tables[0].Rows[0]["SMM_SendTime"].ToString()).Hour + ":" + DateTime.Parse(Smm_Table.Tables[0].Rows[0]["SMM_SendTime"].ToString()).Minute + "\",");
                s_Return.Append("unread:\"" + Smm_Table.Tables[0].Rows[0]["SMM_UnRead"].ToString() + "\",");
                s_Return.Append("content:\"" + KHtmlDiscode1(KNetPage.KHtmlDiscode(Smm_Table.Tables[0].Rows[0]["SMM_Detail"].ToString())) + "\",");
                s_Return.Append("url:\"Web/Message/System_Message_List.aspx?Type=inbox\",");
                s_Return.Append("receive:\"" + Smm_Table.Tables[0].Rows[0]["SMM_Receive"].ToString() + "\"");
                s_Return.Append("},");
                s_Return1.Append(s_Return.ToString().Substring(0, s_Return.ToString().Length - 1));
                s_Return2.Append(s_Return1.ToString() + "]");
                context.Response.Write(s_Return1);
                context.Response.Flush();
                context.Response.End();
            }
            else
            {
                if (DateTime.Parse(context.Application.Get(adminLogin.KNet_StaffCard.ToString()).ToString()) < DateTime.Parse(Smm_Table.Tables[0].Rows[0]["SMM_SendTime"].ToString()))
                {
                    context.Application.Lock();
                    context.Application.Set(adminLogin.KNet_StaffCard.ToString(), Smm_Table.Tables[0].Rows[0]["SMM_SendTime"]);
                    context.Application.UnLock();
                    s_Return.Append("{");
                    s_Return.Append("sms_id:\"" + Smm_Table.Tables[0].Rows[0]["SMM_ID"].ToString() + "\",");
                    s_Return.Append("to_id:\"" + Smm_Table.Tables[0].Rows[0]["SMM_ReceiveID"].ToString() + "\",");
                    s_Return.Append("from_id:\"" + Smm_Table.Tables[0].Rows[0]["SMM_SenderID"].ToString() + "\",");
                    s_Return.Append("from_name:\"" + Page.Base_GetUserName(Smm_Table.Tables[0].Rows[0]["SMM_SenderID"].ToString()) + "\",");
                    s_Return.Append("type_id:\"" + Smm_Table.Tables[0].Rows[0]["SMM_Type"].ToString() + "\",");
                    s_Return.Append("type_name:\"" + Page.Base_GetBasicCodeName("147", Smm_Table.Tables[0].Rows[0]["SMM_Type"].ToString()) + "\",");
                    s_Return.Append("send_time:\"" + DateTime.Parse(Smm_Table.Tables[0].Rows[0]["SMM_SendTime"].ToString()).Hour + ":" + DateTime.Parse(Smm_Table.Tables[0].Rows[0]["SMM_SendTime"].ToString()).Minute + "\",");
                    s_Return.Append("unread:\"" + Smm_Table.Tables[0].Rows[0]["SMM_UnRead"].ToString() + "\",");
                    s_Return.Append("content:\"" + KHtmlDiscode1(KNetPage.KHtmlDiscode(Smm_Table.Tables[0].Rows[0]["SMM_Detail"].ToString())) + "\",");
                    s_Return.Append("url:\"Web/Message/System_Message_List.aspx?Type=inbox\",");
                    s_Return.Append("receive:\"" + Smm_Table.Tables[0].Rows[0]["SMM_Receive"].ToString() + "\"");
                    s_Return.Append("},");
                    s_Return1.Append(s_Return.ToString().Substring(0, s_Return.ToString().Length - 1));
                    s_Return2.Append(s_Return1.ToString() + "]");
                    context.Response.Write(s_Return1);
                    context.Response.Flush();
                    context.Response.End();
                }
                else
                {
                    context.Response.Write("1");
                    context.Response.Flush();
                    context.Response.End();
                }

            }
        }
        else
        {
             context.Response.Write("1");
        }

    }
    public string KHtmlDiscode1(string theString)
    {
        if (theString != null)
        {
            theString = theString.Replace("\"", "\\\"");

        }
        return theString;

    }
    //发送待发送的邮件
    public bool SendMail()
    {
        try
        {
            KNet.BLL.PB_Basic_Mail Bll = new KNet.BLL.PB_Basic_Mail();
            DataSet Dts_Table = Bll.GetList(" PBM_State=0  and PBM_Del=0 and PBM_Minute is not null ");
            if (Dts_Table != null)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    SendEmail SendEmail1 = new SendEmail();
                    string s_PBM_SendSettingID = Dts_Table.Tables[0].Rows[i]["PBM_SendSettingID"] == null ? "" : Dts_Table.Tables[0].Rows[i]["PBM_SendSettingID"].ToString();
                    string s_SendMail = Dts_Table.Tables[0].Rows[i]["PBM_SendEMail"] == null ? "" : Dts_Table.Tables[0].Rows[i]["PBM_SendEmail"].ToString();
                    string s_ReceiveMail = Dts_Table.Tables[0].Rows[i]["PBM_ReceiveEmail"] == null ? "" : Dts_Table.Tables[0].Rows[i]["PBM_ReceiveEmail"].ToString();
                    string s_Text = Dts_Table.Tables[0].Rows[i]["PBM_Text"] == null ? "" : Dts_Table.Tables[0].Rows[i]["PBM_Text"].ToString();
                    string s_File = Dts_Table.Tables[0].Rows[i]["PBM_File"] == null ? "" : Dts_Table.Tables[0].Rows[i]["PBM_File"].ToString();
                    string s_Title = Dts_Table.Tables[0].Rows[i]["PBM_Title"] == null ? "" : Dts_Table.Tables[0].Rows[i]["PBM_Title"].ToString();
                    string s_Cc = Dts_Table.Tables[0].Rows[i]["PBM_Cc"] == null ? "" : Dts_Table.Tables[0].Rows[i]["PBM_Cc"].ToString();
                    string s_Ms = Dts_Table.Tables[0].Rows[i]["PBM_Ms"] == null ? "" : Dts_Table.Tables[0].Rows[i]["PBM_Ms"].ToString();

                    string s_CTime = Dts_Table.Tables[0].Rows[i]["PBM_CTime"] == null ? "" : Dts_Table.Tables[0].Rows[i]["PBM_CTime"].ToString();
                    string s_Minute = Dts_Table.Tables[0].Rows[i]["PBM_Minute"] == null ? "0" : Dts_Table.Tables[0].Rows[i]["PBM_Minute"].ToString();
                    string s_ID = Dts_Table.Tables[0].Rows[i]["PBM_ID"] == null ? "" : Dts_Table.Tables[0].Rows[i]["PBM_ID"].ToString();

                    KNet.Model.PB_Basic_Mail model = Bll.GetModel(s_ID);
                    DateTime Dtm_CTime = DateTime.Parse(s_CTime);
                    DateTime Dtm_Now = DateTime.Now;
                    int i_Minute = 0;
                    try
                    {
                        i_Minute = decimal.ToInt32(decimal.Parse(s_Minute));
                    }
                    catch { }
                    if (Dtm_Now >= Dtm_CTime.AddSeconds(i_Minute))
                    {

                        string s_message = "";
                        //
                        //string s_Sql = "Select PBM_State from PB_Basic_Mail where  PBM_ID='"+s_ID+"'";
                        try
                        {

                            s_message = SendEmail1.Base_SendEmail(s_ReceiveMail, s_Text, s_File, s_Title, s_PBM_SendSettingID, s_Cc, s_Ms);

                        }
                        catch (Exception ex)
                        { }
                        if (s_message == "邮件发送成功")
                        {
                            model.PBM_State = 1;
                        }
                        else
                        {
                            model.PBM_State = 2;
                        }
                        try
                        {
                            if ((model.PBM_State == 1) && (model.PBM_Type == 1))
                            {
                                //订单发送
                                KNet.BLL.Knet_Procure_OrdersList Bll_OrdersList = new KNet.BLL.Knet_Procure_OrdersList();
                                KNet.Model.Knet_Procure_OrdersList Model_OrdersList = Bll_OrdersList.GetModelB(model.PBM_FID);
                                Model_OrdersList.OrderNo = Model_OrdersList.OrderNo;
                                Model_OrdersList.KPO_IsSend = 1;
                                Bll_OrdersList.UpdateIsSend(Model_OrdersList);
                            }
                        }
                        catch
                        { }
                        Bll.Update(model);
                    }
                }
            }

            return true;
        }
        catch
        {
            return false;
        }
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
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
using KNet.BLL;
using KNet.DBUtility;
using KNet.Common;
using System.Net.Mail;

public partial class Web_ProductSubmitted_Knet_Submitted_Insert_Product : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string s_OrderNo = Request.QueryString["OrderNo"] == null ? "" : Request.QueryString["OrderNo"].ToString();
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();

            this.ReceivDateTime.Text = DateTime.Now.ToShortDateString();
            base.Base_DropWareHouseBind(this.ReceivPaymentNotes, " KSW_Type='0'");
            this.BeginQuery("Select * from PB_Basic_Wl ");
            this.QueryForDataTable();

            ListItem item = new ListItem("--请选择--", "-1"); //默认值
            base.Base_DropBasicCodeBind(this.BuyRank, "1138");
            this.BuyRank.SelectedValue = "1";



            this.Lbl_Title.Text = "新增采购入库";
            this.ReceivNo.Text = s_GetCode();
            if (s_OrderNo != "")
            {
                this.OrderNo.Text = s_OrderNo;
                KNet.BLL.Knet_Procure_OrdersList Bll = new KNet.BLL.Knet_Procure_OrdersList();
                KNet.Model.Knet_Procure_OrdersList Model = Bll.GetModelB(s_OrderNo);
                if (Model.KPO_Del == 1)
                {
                    AlertAndGoBack("该单已关闭不能送检！");
                }
                if (Model.KPO_PriceState == 1)
                {
                    AlertAndGoBack("采购单价需确认不能送检！");
                }

                if (Model.ReceiveSuppNo != "")
                {
                    KNet.BLL.KNet_Sys_WareHouse Bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                    DataSet Dts_Table = Bll_WareHouse.GetList(" SuppNo='" + Model.ReceiveSuppNo + "' and KSW_Type=0  ");
                    try
                    {
                        this.ReceivPaymentNotes.SelectedValue = Dts_Table.Tables[0].Rows[0]["HouseNo"].ToString();
                    }
                    catch { }
                }
                this.SuppNoSelectValue.Text = base.Base_GetSupplierName(Model.SuppNo);
                this.Tbx_SuppNo.Text = Model.SuppNo;
                if (Model.ParentOrderNo != "")
                {
                    string s_Sql = "Select b.HouseNo from Knet_Procure_OrdersList a join KNet_Sys_WareHouse b on a.SuppNo=b.SuppNo and KSW_Type=0 where OrderNo='" + Model.ParentOrderNo + "'";
                    this.BeginQuery(s_Sql);
                    this.QueryForDataTable();
                    if (this.Dtb_Result.Rows.Count > 0)
                    {
                        this.ReceivPaymentNotes.SelectedValue = Dtb_Result.Rows[0]["HouseNo"].ToString();
                    }
                }

                KNet.BLL.Knet_Procure_OrdersList_Details BLL_Details = new KNet.BLL.Knet_Procure_OrdersList_Details();
                DataSet Dts_Details;

                Dts_Details = BLL_Details.GetList(" a.OrderNo='" + s_OrderNo + "'");

                KNet.BLL.KNet_Sys_Products kNetSysProducts = new KNet_Sys_Products();
                //DataSet ds= kNetSysProducts.GetModelB(Dts_Details.Tables[0].Rows[0]["ProductsBarCode"].ToString());

                if (Dts_Details.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                    {
                        string BigUnits = "";
                        BigUnits =
           base.Base_GetBigUnitsByProductCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString());

                        s_MyTable_Detail += "<tr>";
                        this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";

                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ID\" value='" + Dts_Details.Tables[0].Rows[i]["ID"].ToString() + "'>" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";

                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode\" value='" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";

                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Brand\" value=\"\"></td>";

                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";


                        if (BigUnits=="")
                        {
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + GetWsSubmitted(Dts_Details.Tables[0].Rows[i]["thisNowAmount"].ToString(), Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString())  + "</td>";

                            int a = Convert.ToInt32(Dts_Details.Tables[0].Rows[i]["thisNowAmount"].ToString());
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["thisNowAmount"].ToString() + "</td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\" Name=\"OldNumber\" value='" + Dts_Details.Tables[0].Rows[i]["thisNowAmount"].ToString() + "'><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number\" value='" + Dts_Details.Tables[0].Rows[i]["thisNowAmount"].ToString() + "'></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"BNumber\" value='0'></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Price\" readOnly value='" + Dts_Details.Tables[0].Rows[i]["OrderUnitPrice"].ToString() + "'></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Money\" value='" + Dts_Details.Tables[0].Rows[i]["thistotalNet"].ToString() + "'></td>";
                        }
                        else
                        {
                            string c = BigUnits.Remove(BigUnits.LastIndexOf("/"));
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + GetWsSubmitted((Convert.ToInt32(Dts_Details.Tables[0].Rows[i]["thisNowAmount"].ToString()) / Convert.ToInt32(c)).ToString(), Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";

                           
                            int a = Convert.ToInt32(Dts_Details.Tables[0].Rows[i]["thisNowAmount"].ToString());
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">" +Convert.ToInt32(Dts_Details.Tables[0].Rows[i]["thisNowAmount"].ToString())/ Convert.ToInt32(c) + "</td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\" Name=\"OldNumber\" value='" + Convert.ToInt32(Dts_Details.Tables[0].Rows[i]["thisNowAmount"].ToString())/Convert.ToInt32(c) + "'><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number\" value='" + Convert.ToInt32(Dts_Details.Tables[0].Rows[i]["thisNowAmount"].ToString()) / Convert.ToInt32(c) + "'></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"BNumber\" value='0'></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Price\" readOnly value='" +Convert.ToDecimal(Dts_Details.Tables[0].Rows[i]["OrderUnitPrice"].ToString()) + "'></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Money\" value='" +Convert.ToDecimal(Dts_Details.Tables[0].Rows[i]["thistotalNet"].ToString())/Convert.ToInt32(c)  + "'></td>";
                        }


                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Remarks\" value='" + Dts_Details.Tables[0].Rows[i]["OrderRemarks"].ToString() + "'></td>";
                        s_MyTable_Detail += "</tr>";
                    }

                }
            }
        }
        // base.Base_DropLinkManBind(this.Ddl_LinkMan, this.Tbx_CustomerValue.Value);


    }



    private bool SetValue(KNet.Model.Knet_Submitted_Product model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            model.KSP_SID = this.ReceivNo.Text;
            //model. = this.ReceivNo.Text;
            model.KSP_OrderNo = this.OrderNo.Text;
            model.KSP_HouseNo = this.ReceivPaymentNotes.SelectedValue;
            //model.ShipDetials = this.Tbx_ShipDetials.Text;
            model.KSP_Proposer = AM.KNet_StaffNo;
            model.KSP_SuppNo = this.Tbx_SuppNo.Text;

            model.KSP_Time = DateTime.Parse(this.ReceivDateTime.Text);
            model.KSP_Stime = DateTime.Now;
            model.KSP_Boss = 0;
            model.KSP_Rank = Int32.Parse(BuyRank.SelectedValue.ToString());
            model.KSP_State = 0;
            model.KSP_Prant = 10;
            model.KSP_Type = 1;
            model.KSP_UploadUrl = "";
            model.KSP_UploadName = "";
            model.KSP_Remark = ReceivRemarks.Text;
            //model.KPO_KDNameCode = this.Drop_KD.SelectedValue;
            //model.KPO_KDName = this.Drop_KD.SelectedItem.Text;
            //model.KPO_KDCode = this.Tbx_Code.Text;
            ArrayList Arr_Products = new ArrayList();
            if (Request.Form["ProductsBarCode"] != null)
            {
                string[] s_ProductsBarCode = Request.Form["ProductsBarCode"].Split(',');
                string[] s_Number = Request.Form["Number"].Split(',');
                string[] s_Brand = Request.Form["Brand"].Split(',');

                for (int i = 0; i < s_ProductsBarCode.Length; i++)
                {
                    KNet.Model.Knet_Submitted_Product_Details Model_Details = new KNet.Model.Knet_Submitted_Product_Details();
                    Model_Details.KPD_SID = this.ReceivNo.Text;
                    Model_Details.KPD_OrderNo = this.OrderNo.Text;
                    Model_Details.KPD_Code = s_ProductsBarCode[i];
                    Model_Details.KPD_YNTState = 0;
                    Model_Details.KPD_Number = int.Parse(s_Number[i]);
                    Model_Details.KPD_Brand = s_Brand[i];
                    Model_Details.KPD_PTime = DateTime.Now;
                    Arr_Products.Add(Model_Details);
                    model.Arr_Products = Arr_Products;
                }

            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_ID = this.Tbx_ID.Text;
        bool b_True = true;
        try
        {
            if ((this.Tbx_SuppNo.Text != "129682186266972172") && (this.Tbx_SuppNo.Text != "131187205665612658"))
            {
                string[] s_ProductsBarCode = Request.Form["ProductsBarCode"].Split(',');
                string[] s_Number = Request.Form["Number"].Split(',');
                string[] s_OldNumber = Request.Form["OldNumber"].Split(',');
                for (int i = 0; i < s_ProductsBarCode.Length; i++)
                {
                    if (int.Parse(s_Number[i]) > int.Parse(s_OldNumber[i]))
                    {
                        AlertAndGoBack("送检数量不能超过订单数量！");
                        b_True = false;
                        return;
                    }
                }
            }
        }
        catch
        { }
        if (b_True)
        {

            KNet.Model.Knet_Submitted_Product model = new KNet.Model.Knet_Submitted_Product();
            KNet.BLL.Knet_Submitted_Product bll = new KNet.BLL.Knet_Submitted_Product();
            if (this.SetValue(model) == false)
            {
                Alert("系统错误！");
                return;
            }

            try
            {
                bll.Add(model);
                string body = "送检单号为" + model.KSP_SID + "已经生成,请及时检验，检验后，请及时通知仓库";
                string email_list = "zxc@systech.com.cn" + "|" + "zgy@systech.com.cn";
                string File_Path = "";
                Send("IQC送检通知", body, email_list, File_Path);
                AM.Add_Logs("送检申请增加" + model.KSP_SID);
                //base.Base_SendMessage(base.Base_GetDeptPerson("供应链平台", 1), "采购入库增加： <a href='Web/OrderInWareHouse/Knet_Procure_WareHouseList_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.WareHouseNo + "</a> 需要你审批！ ");
                AlertAndRedirect("新增送检申请成功！", "Knet_Submitted_Product_List.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }

    #region 创建送检单，发送邮件
    public static void Send(string subject, string body, string email_list, string File_Path)
    {
        string MailUser = "xjx@systech.com.cn";//我测试的是qq邮箱，其他邮箱一样的道理
        string MailPwd = "systech#88888888";//邮箱密码
        string MailName = "ERP系统";
        string MailHost = "smtp.mxhichina.com";//根据自己选择的邮箱来查询smtp的地址

        MailAddress from = new MailAddress(MailUser, MailName); //邮件的发件人  
        MailMessage mail = new MailMessage();

        //设置邮件的标题  
        mail.Subject = subject;

        //设置邮件的发件人  
        //Pass:如果不想显示自己的邮箱地址，这里可以填符合mail格式的任意名称，真正发mail的用户不在这里设定，这个仅仅只做显示用  
        mail.From = from;

        //设置邮件的收件人  
        string address = "";

        //传入多个邮箱，用“|”分割开，可以自己自定义，再通过mail.To.Add（）添加到列表
        string[] email = email_list.Split('|');
        foreach (string name in email)
        {
            if (name != string.Empty)
            {
                address = name;
                mail.To.Add(new MailAddress(address));
            }
        }

        //设置邮件的抄送收件人  
        //这个就简单多了，如果不想快点下岗重要文件还是CC一份给领导比较好  
        //mail.CC.Add(new MailAddress("Manage@hotmail.com", "尊敬的领导");  

        //设置邮件的内容  
        mail.Body = body;
        //设置邮件的格式  
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        //设置邮件的发送级别  
        mail.Priority = MailPriority.Normal;

        //设置邮件的附件，将在客户端选择的附件先上传到服务器保存一个，然后加入到mail中  
        if (File_Path != "")
        {
            mail.Attachments.Add(new Attachment(File_Path));
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
        }
        SmtpClient client = new SmtpClient();
        //设置用于 SMTP 事务的主机的名称，填IP地址也可以了  
        client.Host = MailHost;
        //设置用于 SMTP 事务的端口，默认的是 25  但是阿里屏蔽了25
        client.Port = 587;
        client.UseDefaultCredentials = false;
        //这里才是真正的邮箱登陆名和密码， 我的用户名为 MailUser ，我的密码是 MailPwd  
        client.Credentials = new System.Net.NetworkCredential(MailUser, MailPwd);
        client.DeliveryMethod = SmtpDeliveryMethod.Network;

        ////如果发送失败，SMTP 服务器将发送 失败邮件告诉我  
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

        //都定义完了，正式发送了，很是简单吧！  
        client.Send(mail);

    }
    #endregion
    private string s_GetCode()
    {
        string s_Return = "";
        try
        {
            string S_Code = DateTime.Now.ToString("yyyyMMddHHmmss");
            s_Return += "S" + DateTime.Now.ToString("yyyyMMddHH") + "-" + S_Code.Substring(S_Code.Length-4);                    
        }
        catch (Exception ex)
        {
            s_Return = "-";
        }
        return s_Return;
    }
    /// <summary>
    /// 获取还未送检的数量
    /// </summary>
    /// <returns></returns>
    private string GetWsSubmitted(string ordernum,string productcode)
    {
        this.BeginQuery("select ISNULL( SUM(KPD_Number), 0) from Knet_Submitted_Product a join Knet_Submitted_Product_Details b on a.KSP_SID=b.KPD_SID where KSP_OrderNo='"+this.OrderNo.Text+"' and b.KPD_Code='"+ productcode + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows[0][0].ToString()=="0")
        {
            return ordernum;
        }
        else if(int.Parse(ordernum)==int.Parse(Dtb_Re.Rows[0][0].ToString()))
        {
            return "0";
        }
        else
        {
            return (int.Parse(ordernum) - int.Parse(Dtb_Re.Rows[0][0].ToString())).ToString();
        }
    }
}
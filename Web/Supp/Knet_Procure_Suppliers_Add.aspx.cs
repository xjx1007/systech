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
using System.Net.Mail;

public partial class Web_Sales_Knet_Procure_Suppliers_Add : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            base.Base_DropBasicCodeBind(this.Ddl_Level, "112");
            base.Base_DropBasicCodeBind(this.Tbx_Days, "300");

            base.Base_DropBasicCodeBind(this.Ddl_Nature, "1142");

            KNet_Sys_ProcureTypebind();
            base.Base_DropSheng(this.sheng);
            base.Base_DropCity(this.city, this.sheng.SelectedValue);
            this.BeginQuery("Select * from PB_Basic_Wl ");
            this.QueryForDataTable();
            this.Drop_KD.DataSource = this.Dtb_Result;
            this.Drop_KD.DataTextField = "PBW_Name";
            this.Drop_KD.DataValueField = "PBW_Code";
            this.Drop_KD.DataBind();
            ListItem item = new ListItem("--请选择--", "-1"); //默认值
            Drop_KD.Items.Insert(0, item);
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制供应商";
                }
                else
                {
                    this.Lbl_Title.Text = "修改供应商";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增供应商";
            }
            AdminloginMess AM = new AdminloginMess();
            //销售机会列表
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
        }
    }

    protected void KNet_Sys_ProcureTypebind()
    {
        KNet.BLL.KNet_Sys_ProcureType bll = new KNet.BLL.KNet_Sys_ProcureType();
        DataSet ds = bll.GetAllList();
        this.Ddl_Type.DataSource = ds;
        this.Ddl_Type.DataTextField = "ProcureTypeName";
        this.Ddl_Type.DataValueField = "ProcureTypeValue";
        this.Ddl_Type.DataBind();
    }
    /// <summary>
    /// 获取信息
    /// </summary>
    /// <param name="SuppNo"></param>
    private void ShowInfo(string SuppNo)
    {
        KNet.BLL.Knet_Procure_Suppliers bll = new KNet.BLL.Knet_Procure_Suppliers();
        KNet.Model.Knet_Procure_Suppliers model = bll.GetModel(SuppNo);

        this.SuppCode.Text = model.SuppCode;
        this.SuppNo.Text = model.SuppNo;
        this.SuppName.Text = model.SuppName;
        this.SuppPeople.Text = model.SuppPeople;
        this.SuppMobiTel.Text = model.SuppMobiTel;
        this.SuppPhone.Text = model.SuppPhone;
        //model.KPS_Business = Request["KPS_Business"] == null ? "" : Request["KPS_Business"].ToString();
        if (model.KPS_Check=="1")
        {
            this.check.Checked = true;
        }
        else
        {
            this.check.Checked = false;
        }
        this.KPS_BusinessUrl.Text = model.KPS_BusinessUrl;
        this.KPS_Business.Text = model.KPS_Business;
        this.Lbl_Details.Text= "<a href=\"" + model.KPS_BusinessUrl + "\">" +
                                   model.KPS_Business + "</a>";
        this.KPS_InvoiceUrl.Text = model.KPS_InvoiceUrl;
        this.KPS_Invoice.Text = model.KPS_Invoice;
        this.Lbl_Details1.Text= "<a href=\"" + model.KPS_InvoiceUrl + "\">" +
                                   model.KPS_Invoice + "</a>";
        this.KPS_Contract.Text = model.KPS_Contract;
        this.KPS_ContractUrl.Text = model.KPS_ContractUrl;
        this.Lbl_Details2.Text= "<a href=\"" + model.KPS_ContractUrl + "\">" +
                                   model.KPS_Contract + "</a>";

        this.KPS_FiveUrl.Text = model.KPS_FiveUrl;
        this.KPS_Five.Text = model.KPS_FiveName;
        this.Lbl_Five.Text= "<a href=\"" + model.KPS_FiveUrl + "\">" +
                                   model.KPS_FiveName + "</a>";

        this.KSP_SQEUrl.Text = model.KSP_SQEUrl;
        this.KSP_SQE.Text = model.KPS_SQEName;
        this.Lbl_SQE.Text = "<a href=\"" + model.KSP_SQEUrl + "\">" +
                                   model.KPS_SQEName + "</a>";
        //this.KPS_Production.Text = model.KPS_Production;
        //this.KPS_ProductionPho.Text = model.KPS_ProductionPho;
        this.KPS_WareHouse.Text = model.KPS_WareHouse;
        this.KPS_WareHousePho.Text = model.KPS_WareHousePho;
        //model.KPS_BusinessUrl = Request["KPS_BusinessUrl"] == null ? "" : Request["KPS_BusinessUrl"].ToString();
        //model.KPS_Invoice = Request["KPS_Invoice"] == null ? "" : Request["KPS_Invoice"].ToString();
        //model.KPS_InvoiceUrl = Request["KPS_InvoiceUrl"] == null ? "" : Request["KPS_InvoiceUrl"].ToString();
        //model.KPS_Contract = Request["KPS_Contract"] == null ? "" : Request["KPS_Contract"].ToString();
        //model.KPS_ContractUrl = Request["KPS_ContractUrl"] == null ? "" : Request["KPS_ContractUrl"].ToString();
        this.Ddl_Nature.SelectedValue = model.KPS_Nature.ToString();
        this.SuppFax.Text = model.SuppFax;
        this.SuppEmail.Text = model.SuppEmail;
        this.sheng.SelectedValue = model.SuppProvince;
        base.Base_DropCity(this.city, this.sheng.SelectedValue);
        this.city.SelectedValue = model.SuppCity;
        this.SuppWeb.Text = model.SuppWeb;
        this.SuppAddress.Text = model.SuppAddress;
        this.SuppZipCode.Text = model.SuppZipCode;
        this.SuppBankName.Text = model.SuppBankName;
        this.SuppBankAccount.Text = model.SuppBankAccount;
        this.KPS_CdBankNum.Text = model.KPS_CdBankNum;
        this.KPS_CdBankName.Text = model.KPS_CdBankName;
        this.SuppProducts.Text = KNetPage.KHtmlDiscode(model.SuppProducts);
        this.Remarks.Text = model.Remarks;
        this.Ddl_Level.SelectedValue = model.KPS_Level;
        this.Ddl_DutyPerson.SelectedValue = model.KPS_DutyPerson;
        this.Ddl_Type.SelectedValue = model.KPS_Type;
        this.Ddl_Nature.SelectedValue = model.KPS_Nature.ToString();
        this.Tbx_LinkManID.Text = model.KPS_LinkManID;
        this.Tbx_SName.Text = model.KPS_Sname;
        this.Tbx_Code.Text = model.KPS_Code;
        this.Tbx_Days.SelectedValue = model.KPS_Days.ToString();
        this.Drop_KD.SelectedValue = model.KPS_KDCode;
        this.Tbx_ScNumber.Text = model.KPS_ScNumber.ToString();
        this.Tbx_MaxRow.Text = model.KPS_MaxRow.ToString();
        this.Tbx_MaxMoney.Text = model.KPS_KPMaxMoney.ToString();
        try
        {
            this.Tbx_GiveDays.Text = model.KPS_GiveDays.ToString();
        }
        catch
        {
        }

    }
    private bool SetValue(KNet.Model.Knet_Procure_Suppliers model, KNet.Model.XS_Compy_LinkMan Model_Compy_LinkMan)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {

            string SuppCode = KNetPage.KHtmlEncode(this.SuppCode.Text.Trim());
            string SuppName = KNetPage.KHtmlEncode(this.SuppName.Text.Trim());
            string SuppPeople = KNetPage.KHtmlEncode(this.SuppPeople.Text.Trim());
            //string SuppPeople = "";
            string SuppMobiTel = KNetPage.KHtmlEncode(this.SuppMobiTel.Text.Trim());
            //string SuppMobiTel = "";
            string SuppFax = KNetPage.KHtmlEncode(this.SuppFax.Text.Trim());
            string SuppPhone = KNetPage.KHtmlEncode(this.SuppPhone.Text.Trim());
            //string SuppPhone = "";
            string SuppWeb = KNetPage.KHtmlEncode(this.SuppWeb.Text.Trim());
            string SuppEmail = KNetPage.KHtmlEncode(this.SuppEmail.Text.Trim());
            string SuppProvince = this.sheng.SelectedValue.ToString();
            string KPS_Production = "" ;
            string KPS_ProductionPho = "" ;
            string KPS_WareHouse = KNetPage.KHtmlEncode(this.KPS_WareHouse.Text.Trim());
            string KPS_WareHousePho = KNetPage.KHtmlEncode(this.KPS_WareHousePho.Text.Trim());


            string SuppAddress = KNetPage.KHtmlEncode(this.SuppAddress.Text.Trim());
            string SuppZipCode = KNetPage.KHtmlEncode(this.SuppZipCode.Text.Trim());
            string SuppBankName = KNetPage.KHtmlEncode(this.SuppBankName.Text.Trim());
            string SuppBankAccount = KNetPage.KHtmlEncode(this.SuppBankAccount.Text.Trim());
            string CdBankName= KNetPage.KHtmlEncode(this.KPS_CdBankName.Text.Trim());
            string CdBankNum= KNetPage.KHtmlEncode(this.KPS_CdBankNum.Text.Trim());
            string SuppProducts = KNetPage.KHtmlEncode(this.SuppProducts.Text.Trim());
            string Remarks = this.Remarks.Text.Trim();

            //if (KPS_Production == "" || KPS_ProductionPho == "" || KPS_WareHouse == ""|| KPS_WareHousePho==""|| SuppBankAccount==""|| SuppBankName==""|| SuppEmail==""|| SuppAddress=="")
            //{
            //    Response.Write("<script language=javascript>alert('必填项不能为空，请填写');history.back(-1);</script>");
            //    Response.End();
            //}
            if (SuppProvince == "0" || SuppProvince == null)
            {
                Response.Write("<script language=javascript>alert('请选择地区省份!');history.back(-1);</script>");
                Response.End();
            }

            string SuppCity = "0";
            if (Request["city"] != "" && Request["city"] != null)
            {
                SuppCity = Request["city"].Trim();
            }
            else
            {
                Response.Write("<script language=javascript>alert('请选择省份城市!');history.back(-1);</script>");
                Response.End();
            }

          

            if (this.Tbx_ID.Text == "")
            {
                this.SuppNo.Text = DateTime.Now.ToFileTimeUtc().ToString();
            }
            model.SuppNo = this.SuppNo.Text;
            model.SuppName = SuppName;
            model.SuppPeople = SuppPeople;
            model.SuppMobiTel = SuppMobiTel;
            model.SuppFax = SuppFax;
            model.SuppPhone = SuppPhone;
            model.SuppWeb = SuppWeb;
            model.SuppEmail = SuppEmail;
            model.SuppProvince = SuppProvince;
            model.SuppCity = SuppCity;
            model.SuppAddress = SuppAddress;
            model.SuppZipCode = SuppZipCode;
            model.SuppBankName = SuppBankName;
            model.SuppBankAccount = SuppBankAccount;
            model.KPS_CdBankNum = CdBankNum;
            model.KPS_CdBankName = CdBankName;
            model.SuppProducts = SuppProducts;
            model.Remarks = Remarks;
            model.SuppCode = SuppCode;
            model.KPS_Type = this.Ddl_Type.SelectedValue;
            model.KPS_Level = this.Ddl_Level.SelectedValue;
            model.KPS_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.KPS_Creator = AM.KNet_StaffNo;
            model.KPS_CTime = DateTime.Now;
            model.KPS_Mender = AM.KNet_StaffNo;
            model.KPS_MTime = DateTime.Now;
            model.KPS_Code = this.Tbx_Code.Text;
            model.KPS_Sname = this.Tbx_SName.Text;
            model.KPS_KDCode = this.Drop_KD.SelectedValue;
            model.KPS_Production = KPS_Production;
            model.KPS_ProductionPho = KPS_ProductionPho;
            model.KPS_WareHouse = this.KPS_WareHouse.Text;
            model.KPS_WareHousePho = this.KPS_WareHousePho.Text;
            if(this.check.Checked==true)
            {
                model.KPS_Check = "1";
            }
            else
            {
                model.KPS_Check = "0";
            }
            model.KPS_ScNumber = int.Parse(this.Tbx_ScNumber.Text == "" ? "0" : this.Tbx_ScNumber.Text);
            if (this.KPS_Business1.Text != ""&& this.KPS_BusinessUrl1.Text != "")
            {
                model.KPS_Business = this.KPS_Business1.Text;
                model.KPS_BusinessUrl = this.KPS_BusinessUrl1.Text;
            }
            else
            {
                model.KPS_BusinessUrl = this.KPS_BusinessUrl.Text;
                model.KPS_Business = this.KPS_Business.Text;
            }
            if (this.KPS_Invoice1.Text != "" && this.KPS_InvoiceUrl1.Text != "")
            {
                model.KPS_Invoice = this.KPS_Invoice1.Text;
                model.KPS_InvoiceUrl = this.KPS_InvoiceUrl1.Text;
            }
            else
            {
                model.KPS_Invoice = this.KPS_Invoice.Text;
                model.KPS_InvoiceUrl = this.KPS_InvoiceUrl.Text;
            }

            if (this.KPS_Contract1.Text != "" && this.KPS_ContractUrl1.Text != "")
            {
                model.KPS_Contract = this.KPS_Contract1.Text;
                model.KPS_ContractUrl = this.KPS_ContractUrl1.Text;
            }
            else
            {
                model.KPS_ContractUrl = this.KPS_ContractUrl.Text;
                model.KPS_Contract = this.KPS_Contract.Text;
            }
            if (this.KPS_FiveUrl1.Text != "" && this.KPS_Five1.Text != "")
            {
                model.KPS_FiveUrl = this.KPS_FiveUrl1.Text;
                model.KPS_FiveName = this.KPS_Five1.Text;
            }
            else
            {
                model.KPS_FiveUrl = this.KPS_FiveUrl.Text;
                model.KPS_FiveName = this.KPS_Five.Text;
            }
            if (this.KSP_SQEUrl1.Text != "" && this.KSP_SQE1.Text != "")
            {
                model.KSP_SQEUrl = this.KSP_SQEUrl1.Text;
                model.KPS_SQEName = this.KSP_SQE1.Text;
            }
            else
            {
                model.KSP_SQEUrl = this.KSP_SQEUrl.Text;
                model.KPS_SQEName = this.KSP_SQE.Text;
            }

            //this.KPS_BusinessUrl1.Text == "" && this.KPS_InvoiceUrl1.Text == ""&&||KPS_FiveUrl.Text==""
            if (this.KPS_BusinessUrl.Text==""||this.KPS_InvoiceUrl.Text=="")
            {
                Response.Write("<script language=javascript>alert('请上传文件!');history.back(-1);</script>");
                Response.End();
            }
          
            try
            {
                model.KPS_Days = int.Parse(this.Tbx_Days.Text);
                model.KPS_GiveDays = int.Parse(this.Tbx_GiveDays.Text);
            }
            catch
            {
                model.KPS_Days = 0;
                model.KPS_GiveDays = 0;
            }


            try
            {
                model.KPS_KPMaxMoney = int.Parse(this.Tbx_MaxMoney.Text);
            }
            catch
            {
                model.KPS_KPMaxMoney = 0;
            }
            try
            {
                model.KPS_MaxRow = int.Parse(this.Tbx_MaxRow.Text);
            }
            catch
            {
                model.KPS_MaxRow = 0;
            }
            model.KPS_Del = 1;
            Model_Compy_LinkMan.XOL_Compy = this.SuppNo.Text;
            Model_Compy_LinkMan.XOL_Name = SuppPeople;
            Model_Compy_LinkMan.XOL_Phone = SuppMobiTel;
            Model_Compy_LinkMan.XOL_Officephone = SuppPhone;
            Model_Compy_LinkMan.XOL_Fax = SuppFax;
            Model_Compy_LinkMan.XOL_Address = SuppAddress;
            Model_Compy_LinkMan.XOL_Mail = SuppEmail;
            Model_Compy_LinkMan.XOL_Mail = SuppEmail;
            Model_Compy_LinkMan.XOL_Del = 0;
            Model_Compy_LinkMan.XOL_Code = "CP" + SuppCode + KNetOddNumbers1(this.SuppNo.Text);
            Model_Compy_LinkMan.XOL_Type = "102";
            Model_Compy_LinkMan.XOL_DutyPerson = this.Ddl_DutyPerson.SelectedValue;

            return true;
        }
        catch(Exception ex)
        {
            throw ex;
            return false;
        }

    }

    /// <summary>
    /// 返回当前的  单号 （唯一性，如 2009121402）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string KNetOddNumbers1(string s_CustomerValue)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select Isnull(MAX(XOL_Code),0)  as AA  from  XS_Compy_LinkMan Where XOL_Compy='" + s_CustomerValue + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["AA"].ToString() == "0")
                {
                    return "001";
                }
                else
                {
                    return KNus(int.Parse(dr["AA"].ToString().Substring(dr["AA"].ToString().Length - 3, 3)) + 1);
                }
            }
            else
            {
                return "001";
            }
        }
    }

    protected string KNus(int ss)
    {
        if (ss.ToString().Length == 1)
        {
            return "00" + ss.ToString();
        }
        if (ss.ToString().Length == 2)
        {
            return "0" + ss.ToString();
        }
        else
        {
            return ss.ToString();
        }
    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_ID = this.Tbx_ID.Text;

        KNet.Model.Knet_Procure_Suppliers model = new KNet.Model.Knet_Procure_Suppliers();
        KNet.BLL.Knet_Procure_Suppliers bll = new KNet.BLL.Knet_Procure_Suppliers();
        KNet.Model.XS_Compy_LinkMan Model_Compy_LinkMan = new KNet.Model.XS_Compy_LinkMan();

        KNet.BLL.XS_Compy_LinkMan BLL_Compy_LinkMan = new KNet.BLL.XS_Compy_LinkMan();

        if (this.SetValue(model, Model_Compy_LinkMan) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (s_ID == "")//新增
        {
            try
            {
                Model_Compy_LinkMan.XOL_ID = base.GetNewID("Xs_Compy_LinkMan", 1);
                model.KPS_LinkManID = Model_Compy_LinkMan.XOL_ID;
                bll.Add(model);
                BLL_Compy_LinkMan.Add(Model_Compy_LinkMan);
                AM.Add_Logs("供应商增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "Knet_Procure_Suppliers_List.aspx");

                string body = AM.KNet_StaffName + "添加了"+model.SuppName+",需要您审核";
                string email_list = "xb@systech.com.cn" + "|";
                string File_Path = "";
                Send("导入供应商通知", body, email_list, File_Path);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        else
        {

            try
            {
                Model_Compy_LinkMan.XOL_ID = this.Tbx_LinkManID.Text;
                if (this.Tbx_LinkManID.Text == "")
                {
                    Model_Compy_LinkMan.XOL_ID = base.GetNewID("Xs_Compy_LinkMan", 1);
                    model.KPS_LinkManID = Model_Compy_LinkMan.XOL_ID;
                    BLL_Compy_LinkMan.Add(Model_Compy_LinkMan);
                }
                else
                {
                    model.KPS_LinkManID = this.Tbx_LinkManID.Text;
                    BLL_Compy_LinkMan.Update(Model_Compy_LinkMan);
                }
                model.ID = this.Tbx_ID.Text;
                model.KPS_Del = 1;
                bll.Update(model);
                bll.UpdateDel(model);
                AM.Add_Logs("供应商修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "Knet_Procure_Suppliers_List.aspx");


                string body = "供应商" + model.SuppName + "被"+AM.KNet_StaffName+"修改，需要您审核！！";
                string email_list = "xb@systech.com.cn" + "|";
                string File_Path = "";
                Send("供应商修改通知", body, email_list, File_Path);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    #region 添加或者修改供应商，发送邮件
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
        //设置用于 SMTP 事务的端口，默认的是 25  
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
    protected void sheng_SelectedIndexChanged(object sender, EventArgs e)
    {
        base.Base_DropCity(this.city, this.sheng.SelectedValue);
    }
    protected void button1_ServerClick1(object sender, EventArgs e)
    {
        if (!(uploadFile1.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            //string FileType = uploadFile1.PostedFile.ContentType.ToString(); //文件类型
                                                                             //GetThumbnailImage1();
            string UploadPath = "../../UpFile/SuppInfo/";  //上传路径
                                                           //if (this.CustomerValue.Value != "")
                                                           //{
                                                           //    UploadPath += this.CustomerValue.Value + "/";
                                                           //}
            string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
            string fileExt = Path.GetExtension(uploadFile1.PostedFile.FileName); //获扩展名
            string FileType = uploadFile1.PostedFile.ContentType.ToString(); //文件类型
            string FileName = Path.GetFileName(uploadFile1.PostedFile.FileName);
            string filePath = UploadPath + AutoPath + fileExt;
            if (!Directory.Exists(Server.MapPath(UploadPath)))
            {
                Directory.CreateDirectory(Server.MapPath(UploadPath));
            }
            uploadFile1.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
            this.Lbl_Details.Text = "<input Name=\"KPS_BusinessUrl\"  type=\"hidden\"  value=" + filePath + "><input Name=\"KPS_Business\"  type=\"hidden\"  value=" + FileName + "><a href=\"" + filePath + "\" >" + FileName + "</a>";
            this.KPS_BusinessUrl1.Text = filePath;
            this.KPS_Business1.Text = FileName;
        }
    }
    /// <summary>
    /// 图片上传
    /// </summary>
    //protected void GetThumbnailImage1()
    //{
    //    string UploadPath = "../../UpFile/SuppInfo/";  //上传路径
    //    //if (this.CustomerValue.Value != "")
    //    //{
    //    //    UploadPath += this.CustomerValue.Value + "/";
    //    //}
    //    string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
    //    string fileExt = Path.GetExtension(uploadFile1.PostedFile.FileName); //获扩展名
    //    string FileType = uploadFile1.PostedFile.ContentType.ToString(); //文件类型
    //    string FileName = Path.GetFileName(uploadFile1.PostedFile.FileName);
    //    string filePath = UploadPath + AutoPath + fileExt;
    //    if (!Directory.Exists(Server.MapPath(UploadPath)))
    //    {
    //        Directory.CreateDirectory(Server.MapPath(UploadPath));
    //    }
    //    uploadFile1.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
    //    this.Lbl_Details.Text = "<input Name=\"KSC_OrderURL\"  type=\"hidden\"  value=" + filePath + "><input Name=\"KSC_OrderName\"  type=\"hidden\"  value=" + FileName + "><a href=\"" + filePath + "\" >" + FileName + "</a>";
    //    //this.Lbl_ContractDetails.Text = this.Lbl_ContractDetails1.Text;
    //    //this.Lbl_FhDetails.Text = this.Lbl_FhDetails1.Text;

    //}
    protected void button2_ServerClick2(object sender, EventArgs e)
    {
        if (!(uploadFile2.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            //string FileType = uploadFile1.PostedFile.ContentType.ToString(); //文件类型
            //GetThumbnailImage1();
            string UploadPath = "../../UpFile/SuppInfo/";  //上传路径
                                                           //if (this.CustomerValue.Value != "")
                                                           //{
                                                           //    UploadPath += this.CustomerValue.Value + "/";
                                                           //}
            string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
            string fileExt = Path.GetExtension(uploadFile2.PostedFile.FileName); //获扩展名
            string FileType = uploadFile2.PostedFile.ContentType.ToString(); //文件类型
            string FileName = Path.GetFileName(uploadFile2.PostedFile.FileName);
            string filePath = UploadPath + AutoPath + fileExt;
            if (!Directory.Exists(Server.MapPath(UploadPath)))
            {
                Directory.CreateDirectory(Server.MapPath(UploadPath));
            }
            uploadFile2.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
            this.Lbl_Details1.Text = "<input Name=\"KPS_InvoiceUrl\"  type=\"hidden\"  value=" + filePath + "><input Name=\"KPS_Invoice\"  type=\"hidden\"  value=" + FileName + "><a href=\"" + filePath + "\" >" + FileName + "</a>";
            this.KPS_InvoiceUrl1.Text = filePath;
            this.KPS_Invoice1.Text = FileName;
        }
    }
    protected void button3_ServerClick3(object sender, EventArgs e)
    {
        if (!(uploadFile3.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            //string FileType = uploadFile1.PostedFile.ContentType.ToString(); //文件类型
            //GetThumbnailImage1();
            string UploadPath = "../../UpFile/SuppInfo/";  //上传路径
                                                           //if (this.CustomerValue.Value != "")
                                                           //{
                                                           //    UploadPath += this.CustomerValue.Value + "/";
                                                           //}
            string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
            string fileExt = Path.GetExtension(uploadFile3.PostedFile.FileName); //获扩展名
            string FileType = uploadFile3.PostedFile.ContentType.ToString(); //文件类型
            string FileName = Path.GetFileName(uploadFile3.PostedFile.FileName);
            string filePath = UploadPath + AutoPath + fileExt;
            if (!Directory.Exists(Server.MapPath(UploadPath)))
            {
                Directory.CreateDirectory(Server.MapPath(UploadPath));
            }
            uploadFile3.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
            this.Lbl_Details2.Text = "<input Name=\"KPS_ContractUrl\"  type=\"hidden\"  value=" + filePath + "><input Name=\"KPS_Contract\"  type=\"hidden\"  value=" + FileName + "><a href=\"" + filePath + "\" >" + FileName + "</a>";
            this.KPS_ContractUrl1.Text = filePath;
            this.KPS_Contract1.Text = FileName;
        }
    }
    /// <summary>
    /// 上传五证合一和质量保证协议
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_Five_OnServerClick(object sender, EventArgs e)
    {
        if (!(File_Five.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            //string FileType = uploadFile1.PostedFile.ContentType.ToString(); //文件类型
            //GetThumbnailImage1();
            string UploadPath = "../../UpFile/SuppInfo/";  //上传路径
                                                           //if (this.CustomerValue.Value != "")
                                                           //{
                                                           //    UploadPath += this.CustomerValue.Value + "/";
                                                           //}
            string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
            string fileExt = Path.GetExtension(File_Five.PostedFile.FileName); //获扩展名
            string FileType = File_Five.PostedFile.ContentType.ToString(); //文件类型
            string FileName = Path.GetFileName(File_Five.PostedFile.FileName);
            string filePath = UploadPath + AutoPath + fileExt;
            if (!Directory.Exists(Server.MapPath(UploadPath)))
            {
                Directory.CreateDirectory(Server.MapPath(UploadPath));
            }
            File_Five.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
            this.Lbl_Five.Text = "<input Name=\"KPS_FiveUrl\"  type=\"hidden\"  value=" + filePath + "><input Name=\"KPS_FiveName\"  type=\"hidden\"  value=" + FileName + "><a href=\"" + filePath + "\" >" + FileName + "</a>";
            this.KPS_FiveUrl1.Text = filePath;
            this.KPS_Five1.Text = FileName;
        }
    }
    /// <summary>
    /// 品质上传审厂及整改报告
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_SQE_OnServerClick(object sender, EventArgs e)
    {
        if (!(File_SQE.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            //string FileType = uploadFile1.PostedFile.ContentType.ToString(); //文件类型
            //GetThumbnailImage1();
            string UploadPath = "../../UpFile/SuppInfo/";  //上传路径
                                                           //if (this.CustomerValue.Value != "")
                                                           //{
                                                           //    UploadPath += this.CustomerValue.Value + "/";
                                                           //}
            string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
            string fileExt = Path.GetExtension(File_SQE.PostedFile.FileName); //获扩展名
            string FileType = File_SQE.PostedFile.ContentType.ToString(); //文件类型
            string FileName = Path.GetFileName(File_SQE.PostedFile.FileName);
            string filePath = UploadPath + AutoPath + fileExt;
            if (!Directory.Exists(Server.MapPath(UploadPath)))
            {
                Directory.CreateDirectory(Server.MapPath(UploadPath));
            }
            File_SQE.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
            this.Lbl_SQE.Text = "<input Name=\"KSP_SQEUrl\"  type=\"hidden\"  value=" + filePath + "><input Name=\"KPS_SQEName\"  type=\"hidden\"  value=" + FileName + "><a href=\"" + filePath + "\" >" + FileName + "</a>";
            this.KSP_SQEUrl1.Text = filePath;
            this.KSP_SQE1.Text = FileName;
        }
    }
}

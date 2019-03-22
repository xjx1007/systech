using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Products_KNet_Product_Burn_List : BasePage
{
    public string s_AdvShow = "", s_Type1 = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write(
                    "<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string KSB_State = Request.QueryString["KSB_State"] == null
                ? ""
                : Request.QueryString["KSB_State"].ToString();
            string type = Request.QueryString["type"] == null
                ? ""
                : Request.QueryString["type"].ToString();
            if (KSB_State != "")
            {
                if (AM.YNAuthority("审核烧录文件申请"))
                {
                    this.BeginQuery("select * from KNet_Resource_Staff where ProductsType like '%" + type +
                                    "%' and StaffNo='" + AM.KNet_StaffNo + "'");
                    this.QueryForDataTable();
                    DataTable Dtb_Re = Dtb_Result;
                    this.BeginQuery("select  PBP_FaterID from PB_Basic_ProductsClass  where PBP_ID in ('" + type + "')");
                    this.QueryForDataTable();
                    DataTable Dtb_Re1 = Dtb_Result;
                    string cType = "";
                    for (int i = 0; i < Dtb_Re1.Rows.Count; i++)
                    {
                        cType += Dtb_Re1.Rows[i][0].ToString() + ",";
                    }
                    cType = cType.Substring(0, cType.Length - 1);
                    this.BeginQuery("select * from KNet_Resource_Staff where ProductsType like '%" + cType +
                                    "%' and StaffNo='" + AM.KNet_StaffNo + "'");
                    this.QueryForDataTable();
                    DataTable Dtb_Re2 = Dtb_Result;
                    if (Dtb_Re.Rows.Count > 0)
                    {
                        string DoSqlOrder = " update KNet_Product_Burn set  KSB_State=" + KSB_State + ",KSB_STime='"+DateTime.Now+"',KSB_Person=" +
                                            AM.KNet_StaffNo + "  where KSB_ID='" + s_ID + "' ";
                        DbHelperSQL.ExecuteSql(DoSqlOrder);
                        string body = "编号为" + s_ID + "的烧录程序审核成功,请及时查看下载";
                        string email_list = "luoxingjun@systech.com.cn" + "|";
                        string File_Path = "";
                        //Send("烧录文件审核通过通知", body, email_list, File_Path);
                    }
                    else if (Dtb_Re2.Rows.Count > 0)
                    {
                        string DoSqlOrder = " update KNet_Product_Burn set  KSB_State=" + KSB_State + ",KSB_STime='" + DateTime.Now + "',KSB_Person=" +
                                            AM.KNet_StaffNo + "  where KSB_ID='" + s_ID + "' ";
                        DbHelperSQL.ExecuteSql(DoSqlOrder);
                        string body = "编号为" + s_ID + "的烧录程序审核成功,请及时查看下载";
                        string email_list = "luoxingjun@systech.com.cn" + "|";
                        string File_Path = "";
                        //Send("烧录文件审核通过通知", body, email_list, File_Path);
                    }
                    else
                    {
                        Response.Write(
                            "<script language=javascript>alert('此产品不是你负责，无法审核!')</script>");
                    }

                }
                else
                {
                    Response.Write(
                        "<script language=javascript>alert('您没有审核请购单的权限!')</script>");
                }
            }
            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！\\n\\n注意：该删除会同时删除出库单产品明细记录.')");
            base.Base_DropBindSearch(this.bas_searchfield, "KNet_Product_Burn");
            base.Base_DropBindSearch(this.Fields, "KNet_Product_Burn");
            Base_StaffNo(this.Ddl_StaffNo);
            this.DataShows();
            this.RowOverYN();
        }
    }

    #region 程序审核成功后，发送邮件给小罗

    public static void Send(string subject, string body, string email_list, string File_Path)
    {
        string MailUser = "xjx@systech.com.cn"; //我测试的是qq邮箱，其他邮箱一样的道理
        string MailPwd = "systech#88888888"; //邮箱密码
        string MailName = "ERP系统";
        string MailHost = "smtp.mxhichina.com"; //根据自己选择的邮箱来查询smtp的地址

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

    /// <summary>
    /// 是不是有记录
    /// </summary>
    protected void RowOverYN()
    {
        if (MyGridView1.Rows.Count == 0) //如果没有记录
        {
            this.Btn_Del.Enabled = false;
        }
    }

    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        AdminloginMess AM = new AdminloginMess();

        KNet.BLL.KNet_Product_Burn bll = new KNet.BLL.KNet_Product_Burn();
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_ProductsBarCode = Request["ProductsBarCode"] == null ? "" : Request["ProductsBarCode"].ToString();
        string s_Type = "";

        string SqlWhere = " 1=1  ";


        if (s_WhereID != "")
        {
            SqlWhere += Base_GetBasicWhere(s_WhereID);
        }

        if ((this.bas_searchfield.SelectedValue != "") && (search_text.Text != ""))
        {
            SqlWhere += base.Base_GetBasicColumnWhere(this.bas_searchfield.SelectedValue, this.search_text.Text);
        }

        if (s_Text != "")
        {
            if (this.matchtype1.Checked == true) //and
            {
                s_Type = "0";
            }
            if (this.matchtype2.Checked == true)
            {
                s_Type = "1";
            }
            SqlWhere += base.Base_GetAdvWhere(s_Fields, s_Condition, s_Text, s_Type);
        }
        string s_SalesOrderNo = Request.QueryString["SalesOrderNo"] == null
            ? ""
            : Request.QueryString["SalesOrderNo"].ToString();

        if (s_SalesOrderNo != "")
        {
            SqlWhere += " and ID like '%" + s_SalesOrderNo + "%' ";
        }



        //SqlWhere += " order by SYstemDateTimes desc";
        //string SqlWhere = " 1=1  ";
        if (this.Ddl_StaffNo.SelectedValue != "")
        {
            SqlWhere += " and KSB_Person='" + this.Ddl_StaffNo.SelectedValue + "' ";
        }
        SqlWhere = SqlWhere + " order by KSB_Time desc ";
        DataSet ds = bll.GetList(SqlWhere);
        MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] {"KSB_ID"};
        MyGridView1.DataBind();
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



    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            KNet.BLL.KNet_Product_Burn Bll = new KNet.BLL.KNet_Product_Burn();
            AdminloginMess AM = new AdminloginMess();
            string DirectInNo = MyGridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox) e.Row.Cells[1].FindControl("Chbk");
            this.BeginQuery("select count(*) from KNet_Product_Burn where KSB_ID='" + DirectInNo +
                            "' and KSB_State!='0'");
            this.QueryForDataTable();
            DataTable Dtb_Re = Dtb_Result;
            //KNet.Model.KNet_Sampling_List Model = Bll.GetModel(DirectInNo);
            if (Convert.ToInt32(Dtb_Re.Rows[0][0]) != 0)
            {
                cb.Enabled = false;
            }
            else
            {
                if (AM.KNet_StaffName == "薛建新")
                {
                    cb.Enabled = true;
                }
                else
                {
                    cb.Enabled = false;
                }
            }
        }
    }

    protected void Btn_Del_Click(object sender, EventArgs e)
    {


        for (int i = 0; i < MyGridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox) MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {

                KNet.BLL.KNet_Product_Burn BLL = new KNet.BLL.KNet_Product_Burn();
                bool a = BLL.Delete(MyGridView1.DataKeys[i].Value.ToString());
                if (a)
                {
                    AdminloginMess LogAM = new AdminloginMess();
                    LogAM.Add_Logs("烧录审核 删除 操作成功！");
                    Alert("删除成功");
                    this.DataShows();
                    this.RowOverYN();
                }
                else
                {
                    Alert("删除失败");
                }
            }
        }
    }

    public void btnBasicSearch_Click(object sender, EventArgs e)
    {
        this.advSearch.Style["display"] = "none";
        this.Search_basic.Style["display"] = "block";
        this.DataShows();
    }

    public string Base_GetProductBurn(String s_ID, string ProductCode,string fileurl)
    {
        if (fileurl.ToString() == "")
        {
            string s_Name = "";
            this.BeginQuery("select PBA_Name,PBA_URL from PB_Basic_Attachment where PBA_FID in (" + ProductCode +
                            ") and PBA_ProductsType=6");
            this.QueryForDataTable();
            DataTable Dtb_Re = Dtb_Result;
            if (Dtb_Re.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Re.Rows.Count; i++)
                {
                    s_Name += "<a href=\"\" target=\"_blank\">" + Dtb_Re.Rows[i][0].ToString() + "</a>";
                    s_Name += "<br/>";
                }

            }
            return s_Name;
        }
        else
        {
            string s_Name = "";
            this.BeginQuery("select PBA_Name,PBA_URL from PB_Basic_Attachment where PBA_ID in (" + fileurl +
                            ") and PBA_ProductsType=6");
            this.QueryForDataTable();
            DataTable Dtb_Re = Dtb_Result;
            if (Dtb_Re.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Re.Rows.Count; i++)
                {
                    s_Name += "<a href=\"\" target=\"_blank\">" + Dtb_Re.Rows[i][0].ToString() + "</a>";
                    s_Name += "<br/>";
                }
            }
            return s_Name;
        }

    }

    /// <summary>
    /// 获取产品名称
    /// </summary>
    /// <returns></returns>
    public string GetProductName(string orderno, string productcode)
    {
//base.Base_GetProdutsName_Link(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString())
        //string s_Name = "";
        String s_Name = "";
        this.BeginQuery("select ProductsBarCode from Knet_Procure_OrdersList_Details where OrderNo='" + orderno +
                        "' and ProductsBarCode in (" + productcode + ")");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Re.Rows.Count; i++)
            {
                s_Name += base.Base_GetProdutsName_Link(Dtb_Re.Rows[i][0].ToString());
                s_Name += "<br/>";
            }

        }
        return s_Name;
    }

    /// <summary>
    /// 下载文件
    /// </summary>
    /// <returns></returns>
    public string Base_GetProductUpload(string orderno, string productcode, string state,string fileurl)
    {
        AdminloginMess AM = new AdminloginMess();
        String s_Name = "";
        if (fileurl.ToString() == "")
        {
            this.BeginQuery("select PBA_Name,PBA_URL,PBA_State,PBA_Del from PB_Basic_Attachment where PBA_FID in (" + productcode +
                       ") and PBA_ProductsType=6");
            this.QueryForDataTable();
            DataTable Dtb_Re = Dtb_Result;

            if (state != "0")
            {
                if (AM.KNet_StaffName == "罗兴钧" || AM.KNet_StaffName == "邵文磊" || AM.KNet_StaffName == "薛建新")
                {
                    if (Dtb_Re.Rows.Count > 0)
                    {
                        for (int i = 0; i < Dtb_Re.Rows.Count; i++)
                        {
                            if (Dtb_Re.Rows[i]["PBA_State"].ToString() == "0" || Dtb_Re.Rows[i]["PBA_Del"].ToString() == "1")
                            {
                                s_Name+= "此文件已经更新或者未审，请重新创建烧录申请";
                                s_Name += "<br/>";
                            }
                            else
                            {
                                s_Name += "<a href=\"" + Dtb_Re.Rows[i][1].ToString() + "\" target=\"_blank\">下载</a>";
                                s_Name += "<br/>";
                            }
                           
                        }

                    }
                    return s_Name;
                }
                else
                {
                    s_Name = "没有下载的权限或者未审核";
                    return s_Name;
                }
            }
            else
            {
                s_Name = "没有下载的权限或者未审核";
                return s_Name;
            }
        }
        else
        {
            this.BeginQuery("select PBA_Name,PBA_URL,PBA_State,PBA_Del from PB_Basic_Attachment where PBA_ID in (" + fileurl +
                       ") and PBA_ProductsType=6");
            this.QueryForDataTable();
            DataTable Dtb_Re = Dtb_Result;
            if (state != "0")
            {
                if (AM.KNet_StaffName == "罗兴钧" || AM.KNet_StaffName == "邵文磊" || AM.KNet_StaffName == "薛建新")
                {
                    if (Dtb_Re.Rows.Count > 0)
                    {
                        for (int i = 0; i < Dtb_Re.Rows.Count; i++)
                        {
                            if (Dtb_Re.Rows[i]["PBA_State"].ToString()=="0"|| Dtb_Re.Rows[i]["PBA_Del"].ToString() == "1")
                            {
                                s_Name += "此文件已经更新或者未审，请重新创建烧录申请";
                                s_Name += "<br/>";
                            }
                            else
                            {
                                s_Name += "<a href=\"" + Dtb_Re.Rows[i][1].ToString() + "\" target=\"_blank\">下载</a>";
                                s_Name += "<br/>";
                            }
                           
                        }

                    }
                    return s_Name;
                }
                else
                {
                    s_Name = "没有下载的权限或者未审核";
                    return s_Name;
                }
            }
            else
            {
                s_Name = "没有下载的权限或者未审核";
                return s_Name;
            }
        }


    }

    public string Base_GetProposer(String s_ID)
    {
        String s_Name = "";
        this.BeginQuery("Select * From KNet_Resource_Staff Where StaffNo='" + s_ID + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            s_Name = Dtb_Re.Rows[0]["StaffName"].ToString();
        }
        return s_Name;

    }

    public string Base_GetBurnState(String KSB_State, String KSB_ID, string productcode)
    {
        String s_Name = "";
        string type = "";
        this.BeginQuery("select distinct ProductsType from KNet_Sys_Products where ProductsBarCode in (" + productcode +
                        ")");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        for (int i = 0; i < Dtb_Re.Rows.Count; i++)
        {
            type += Dtb_Re.Rows[i][0].ToString() + ",";

        }
        type = type.Substring(0, type.Length - 1);
        if (KSB_State == "0")
        {
            string JSD = "KNet_Product_Burn_List.aspx?KSB_State=1&&ID=" + KSB_ID + "&&type=" + type + "";
            return "<a href=\"" + JSD + "\" onclick=\"\" ><font color=red>未审核</font></a>";
        }
        else
        {
            string JSD = "KNet_Product_Burn_List.aspx?KSB_State=0&&ID=" + KSB_ID + "&&type=" + type + "";
            return "<a href=\"" + JSD + "\" onclick=\"\" ><font color=blue>已审核</font></a>";
        }

    }

    /// <summary>
    /// 获取审核时间
    /// </summary>
    public string Base_GetSTime(string OrderNo)
    {
        this.BeginQuery("select KSB_STime from KNet_Product_Burn where KSB_OrderNo='" + OrderNo + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        try
        {
            return Dtb_Re.Rows[0][0].ToString();
        }
        catch
        {
            return "";
        }
    }
    protected void Ddl_StaffNo_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DataShows();
    }
}
using KNet.DBUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_ProductSubmitted_Knet_OQCSubmitted_Update_Product : BasePage
{
    public string Sb_Details = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(Web_ProductSubmitted_Knet_OQCSubmitted_Update_Product));
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write(
                    "<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string id = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            Button4.Visible = false;
            this.Tbx_Type.Text = type;
            //if (type!="")
            //{
            //    Button5.Visible = false;
            //    Button6.Visible = false;
            //}
            if (id != "")
            {
                this.Tbx_ID.Text = id;

                //this.KSP_Prant.Enabled = false;
                //this.Tbx_HouseName.Text=
                DateShow(id);
            }

            //SelectDataBind();
        }
    }

    public void DateShow(string id)
    {
        //KNet.BLL.Knet_Submitted_Product_Details BLL = new KNet.BLL.Knet_Submitted_Product_Details();
        //KNet.Model.Knet_Submitted_Product_Details Model = BLL.GetModel(id);
       
        KNet.BLL.Knet_Submitted_Product bll = new KNet.BLL.Knet_Submitted_Product();
        string SqlWhere = " KSP_SID='" + id + "'";
        DataSet ds = bll.GetList(SqlWhere);
        base.Base_DropBasicCodeBind(this.BuyRank, "1138");
        base.Base_DropBasicCodeBind(this.KSP_Prant, "1141");
        if (ds.Tables[0].Rows[0]["KSP_State"].ToString() == "0")
        {
            Button1.Text = "审核";
        }
        else
        {
            Button1.Text = "反审核";
            Btn_Save.Visible = false;
            Button2.Visible = false;
        }
        if (ds.Tables[0].Rows[0]["KSP_Boss"].ToString() == "0")
        {
            btn_Chcek.Text = "特采审核";
        }
        else
        {
            btn_Chcek.Text = "反特采审核";
        }
        this.Tbx_SID.Text = ds.Tables[0].Rows[0]["KSP_SID"].ToString();
        this.TextBox2.Text = ds.Tables[0].Rows[0]["KSP_ID"].ToString();
        this.Tbx_Order.Text = ds.Tables[0].Rows[0]["KSP_OrderNo"].ToString();
        this.KSP_Time.Text = ds.Tables[0].Rows[0]["KSP_Stime"].ToString();

        this.KSP_Stime.Text = ds.Tables[0].Rows[0]["KSP_Time"].ToString();


        this.UploadUrl.Text = ds.Tables[0].Rows[0]["KSP_UploadUrl"].ToString();
        this.Lbl_Details1.Text = "<a href=\"" + ds.Tables[0].Rows[0]["KSP_UploadUrl"].ToString() + "\">" +
                                   ds.Tables[0].Rows[0]["KSP_UploadName"].ToString() + "</a>";
        this.Anomaly.Text = "<a href=\"" + ds.Tables[0].Rows[0]["KSP_AnomalyUrl"].ToString() + "\">" +
                                   ds.Tables[0].Rows[0]["KSP_AnomalyName"].ToString() + "</a>";
        this.Anomaly_Url.Text = ds.Tables[0].Rows[0]["KSP_AnomalyUrl"].ToString();
        this.Back.Text = "<a href=\"" + ds.Tables[0].Rows[0]["KSP_BackUrl"].ToString() + "\">" +
                                   ds.Tables[0].Rows[0]["KSP_BackName"].ToString() + "</a>";
        this.Back_Url.Text = ds.Tables[0].Rows[0]["KSP_BackUrl"].ToString();
        this.Tbx_HouseNo.Text = ds.Tables[0].Rows[0]["KSP_HouseNo"].ToString();
        this.Tbx_SuppNo.Text = ds.Tables[0].Rows[0]["KSP_SuppNo"].ToString();
        this.Remark.Text = ds.Tables[0].Rows[0]["KSP_Remark"].ToString();
        KNet.BLL.Knet_Procure_Suppliers BLL_Supp = new KNet.BLL.Knet_Procure_Suppliers();
        KNet.Model.Knet_Procure_Suppliers Model_Supp =
            BLL_Supp.GetModelB(ds.Tables[0].Rows[0]["KSP_SuppNo"].ToString());
        this.Tbx_SuppName.Text = Model_Supp.SuppName;
        KNet.BLL.KNet_Resource_Staff BLL_STaff = new KNet.BLL.KNet_Resource_Staff();
        KNet.Model.KNet_Resource_Staff Model_STaff =
            BLL_STaff.GetModelC(ds.Tables[0].Rows[0]["KSP_Proposer"].ToString());
        this.Tbx_HouseName.Text = base.Base_GeDept(Model_STaff.StaffBranch);
        this.Tbx_Persser.Text = ds.Tables[0].Rows[0]["KSP_Proposer"].ToString();
        this.BuyRank.SelectedValue = ds.Tables[0].Rows[0]["KSP_Rank"].ToString();
        this.KSP_Prant.SelectedValue = ds.Tables[0].Rows[0]["KSP_Prant"].ToString();
        this.BuyRank.Enabled = false;

        string sql = "select * from Knet_Submitted_Product_Details where KPD_SID='" + id + "'";
        this.BeginQuery(sql);
        this.QueryForDataTable();
        DataTable Dtb_Table = this.Dtb_Result;
        StringBuilder Sb_Details = new StringBuilder();
        if (Dtb_Table.Rows.Count > 0)
        {
            this.count.Text = Dtb_Table.Rows.Count.ToString();
            for (int i = 0; i < Dtb_Table.Rows.Count; i++)
            {
                Sb_Details.Append("<tr>\n");
                Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                Sb_Details.Append(Convert.ToString(i + 1));
                Sb_Details.Append("<input id=\"Chk_Check_" + i.ToString() + "\" type=\"checkbox\" name=\"Chk_Check_" +
                                  i.ToString() + "\" value=\""+ Dtb_Table.Rows[i]["KPD_Code"].ToString() + "\" />\n");
                Sb_Details.Append("</td>\n"); //序号

                Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                Sb_Details.Append("<input id=\"KPD_Codes_" + i.ToString() + "\" type=\"hidden\" name=\"KPD_Codes_" +
                                  i.ToString() + "\"  value=\"" + Dtb_Table.Rows[i]["KPD_Code"].ToString() + "\" />" +
                                  base.Base_GetProductsCode(Dtb_Table.Rows[i]["KPD_Code"].ToString()) + "\n");
                Sb_Details.Append("</td>\n"); //料号

                Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                Sb_Details.Append("<input id=\"KPD_Code_" + i.ToString() + "\" type=\"hidden\" name=\"KPD_Code_" +
                                  i.ToString() + "\"  />" +
                                  base.Base_GetProdutsName_Link(Dtb_Table.Rows[i]["KPD_Code"].ToString()) + "\n");
                Sb_Details.Append("</td>\n"); //物料名称

                Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                Sb_Details.Append("<input id=\"KPD_Brand_" + i.ToString() + "\" type=\"hidden\" name=\"KPD_Brand_" +
                                  i.ToString() + "\"  />" + Dtb_Table.Rows[i]["KPD_Brand"].ToString() + "\n");
                Sb_Details.Append("</td>\n"); //品牌

                Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                Sb_Details.Append("<input id=\"ProductsEdition_" + i.ToString() +
                                  "\" type=\"hidden\" name=\"ProductsEdition_" + i.ToString() + "\"  />" +
                                  base.Base_GetProductsEdition(Dtb_Table.Rows[i]["KPD_Code"].ToString()) + "\n");
                Sb_Details.Append("</td>\n"); //规格型号
                // base.Base_GetProdutsName_Link(Dtb_Table.Rows[i]["KPD_Code"].ToString())
                Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                Sb_Details.Append("<input id=\"KPD_Number_" + i.ToString() + "\" type=\"hidden\"  name=\"KPD_Number_" +
                                  i.ToString() + "\"  value=\"" + Dtb_Table.Rows[i]["KPD_Number"].ToString() + "\" />" +
                                  Dtb_Table.Rows[i]["KPD_Number"].ToString() + "\n");
                Sb_Details.Append("</td>\n"); //送检数量

                Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                Sb_Details.Append("<input id=\"KPD_CheckNumber_" + i.ToString() +
                                  "\" type=\"text\" style=\"width:70px;\" name=\"KPD_CheckNumber_" + i.ToString() +
                                  "\"  value=\"" + Dtb_Table.Rows[i]["KPD_CheckNumber"].ToString() + "\" />\n");
                Sb_Details.Append("</td>\n"); //抽检数量

                Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                Sb_Details.Append("<input id=\"KPD_BadNumber_" + i.ToString() +
                                  "\" type=\"text\" style=\"width:70px;\" name=\"KPD_BadNumber_" + i.ToString() +
                                  "\"  value=\"" + Dtb_Table.Rows[i]["KPD_BadNumber"].ToString() + "\" />\n");
                Sb_Details.Append("</td>\n"); //不良数量   

                Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                Sb_Details.Append("<input id=\"KPD_KDNumber_" + i.ToString() +
                                  "\" type=\"text\" style=\"width:70px;\" name=\"KPD_KDNumber_" + i.ToString() +
                                  "\"  value=\"" + Dtb_Table.Rows[i]["KPD_KDNumber"].ToString() + "\" />\n");
                Sb_Details.Append("</td>\n"); //可调数量   
                string KPD_RejectRatio = "";
                if (decimal.Parse(Dtb_Table.Rows[i]["KPD_RejectRatio"].ToString()) <= 0)
                {
                    KPD_RejectRatio = "0";
                }
                else
                {
                    KPD_RejectRatio = (decimal.Parse(Dtb_Table.Rows[i]["KPD_RejectRatio"].ToString()) * 100).ToString("f2") + "%";
                }
                Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                Sb_Details.Append("<input id=\"KPD_RejectRatio_" + i.ToString() +
                                  "\" type=\"text\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" name=\"KPD_RejectRatio_" +
                                  i.ToString() + "\"  value=\"" + KPD_RejectRatio + "\" />\n");
                Sb_Details.Append("</td>\n"); //不良率   

                Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                Sb_Details.Append("<Select id=\"KPD_YNTState_" + i.ToString() + "\" name=\"KPD_YNTState_" + i.ToString() +
                                  "\">\n");
                if (Dtb_Table.Rows[i]["KPD_YNTState"].ToString() == "0")
                {
                    Sb_Details.Append("<option value=\"0\" selected >未检</option>\n");
                    Sb_Details.Append("<option value=\"1\" >合格</option>\n");
                    Sb_Details.Append("<option value=\"2\" >不合格</option>\n");
                    Sb_Details.Append("<option value=\"3\" >特采</option>\n");
                }
                if (Dtb_Table.Rows[i]["KPD_YNTState"].ToString() == "1")
                {
                    Sb_Details.Append("<option value=\"0\" >未检</option>\n");
                    Sb_Details.Append("<option value=\"1\" selected >合格</option>\n");
                    Sb_Details.Append("<option value=\"2\" >不合格</option>\n");
                    Sb_Details.Append("<option value=\"3\" >特采</option>\n");
                }
                if (Dtb_Table.Rows[i]["KPD_YNTState"].ToString() == "2")
                {
                    Sb_Details.Append("<option value=\"0\" >未检</option>\n");
                    Sb_Details.Append("<option value=\"1\" >合格</option>\n");
                    Sb_Details.Append("<option value=\"2\" selected >不合格</option>\n");
                    Sb_Details.Append("<option value=\"3\" >特采</option>\n");
                }
                if (Dtb_Table.Rows[i]["KPD_YNTState"].ToString() == "3")
                {
                    Sb_Details.Append("<option value=\"0\" >未检</option>\n");
                    Sb_Details.Append("<option value=\"1\" >合格</option>\n");
                    Sb_Details.Append("<option value=\"2\" >不合格</option>\n");
                    Sb_Details.Append("<option value=\"3\" selected >特采</option>\n");
                }
                Sb_Details.Append("</Select>\n");
                Sb_Details.Append("</td>\n"); //检验结果

                Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                Sb_Details.Append("<input id = \"KPD_Remark_" + i.ToString() + "\" name=\"KPD_Remark_" + i.ToString() +
                                  "\" type=\"text\" style=\"width: 600px\" value=\"" +
                                  Dtb_Table.Rows[i]["KPD_Remark"].ToString() + "\" />");
                Sb_Details.Append("</td>\n"); //备注
            }
        }
        this.Lbl_SDetail.Text = Sb_Details.ToString();
    }

    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_Save_OnClick(object sender, EventArgs e)
    {
        KNet.BLL.Knet_Submitted_Product bll = new KNet.BLL.Knet_Submitted_Product();
        KNet.Model.Knet_Submitted_Product model = new KNet.Model.Knet_Submitted_Product();
        KNet.BLL.Knet_Submitted_Product_Details bll1 = new KNet.BLL.Knet_Submitted_Product_Details();
        KNet.Model.Knet_Submitted_Product_Details Model1 = new KNet.Model.Knet_Submitted_Product_Details();
        AdminloginMess AM = new AdminloginMess();
        try
        {
            model.KSP_SID = this.Tbx_ID.Text;
            model.KSP_ID = TextBox2.Text;
            model.KSP_OrderNo = this.Tbx_Order.Text;
            model.KSP_HouseNo = this.Tbx_HouseNo.Text;
            //model.KSP_Proposer = AM.KNet_StaffNo;
            model.KSP_SuppNo = this.Tbx_SuppNo.Text;
            model.KSP_Time = DateTime.Parse(this.KSP_Stime.Text);
            model.KSP_Stime = DateTime.Parse(KSP_Time.Text);
            model.KSP_Boss = 0;
            model.KSP_Rank = Int32.Parse(BuyRank.SelectedValue.ToString());
            model.KSP_State = 0;
            model.KSP_Prant = Int32.Parse(KSP_Prant.SelectedValue);
            model.KSP_UploadUrl = UploadUrl.Text;
            model.KSP_UploadName = Lbl_Details1.Text;
            model.KSP_AnomalyName = Anomaly.Text;
            model.KSP_AnomalyUrl = Anomaly_Url.Text;
            model.KSP_BackName = Back.Text;
            model.KSP_BackUrl = Back_Url.Text;
            model.KSP_Remark = Remark.Text;
            model.KSP_Type = 2;
            ArrayList Arr_Products = new ArrayList();
            if (count.Text != "")
            {

                for (int i = 0; i < int.Parse(count.Text); i++)
                {
                    KNet.Model.Knet_Submitted_Product_Details Model_Details =
                        new KNet.Model.Knet_Submitted_Product_Details();

                    string KPD_Code = Request["KPD_Codes_" + i.ToString() + ""] == null
                        ? ""
                        : Request["KPD_Codes_" + i.ToString() + ""].ToString();
                    string KPD_Number = Request["KPD_Number_" + i.ToString() + ""] == null
                        ? ""
                        : Request["KPD_Number_" + i.ToString() + ""].ToString();
                    string KPD_CheckNumber = Request["KPD_CheckNumber_" + i.ToString() + ""] == null
                        ? ""
                        : Request["KPD_CheckNumber_" + i.ToString() + ""].ToString();
                    string KPD_BadNumber = Request["KPD_BadNumber_" + i.ToString() + ""] == null
                        ? ""
                        : Request["KPD_BadNumber_" + i.ToString() + ""].ToString();
                    string KPD_YNTState = Request["KPD_YNTState_" + i.ToString() + ""] == null
                        ? ""
                        : Request["KPD_YNTState_" + i.ToString() + ""].ToString();
                    string KPD_Remark = Request["KPD_Remark_" + i.ToString() + ""] == null
                        ? ""
                        : Request["KPD_Remark_" + i.ToString() + ""].ToString();
                    string KPD_Brand = Request["KPD_Brand_" + i.ToString() + ""] == null
                        ? ""
                        : Request["KPD_Brand_" + i.ToString() + ""].ToString();
                    string KPD_RejectRatio = Request["KPD_RejectRatio_" + i.ToString() + ""] == null
                        ? "0"
                        : Request["KPD_RejectRatio_" + i.ToString() + ""].ToString();
                    string KPD_KDNumber = Request["KPD_KDNumber_" + i.ToString() + ""] == null
                       ? "0"
                       : Request["KPD_KDNumber_" + i.ToString() + ""].ToString();
                    if (KPD_RejectRatio == "0")
                    {
                        KPD_RejectRatio = "0";
                    }
                    else
                    {
                        KPD_RejectRatio = KPD_RejectRatio.Substring(0, KPD_RejectRatio.Length - 1);
                    }
                    Model_Details.KPD_Code = KPD_Code;
                    Model_Details.KPD_SID = this.Tbx_ID.Text;
                    Model_Details.KPD_OrderNo = this.Tbx_Order.Text;
                    Model_Details.KPD_Number = int.Parse(KPD_Number);
                    Model_Details.KPD_CheckNumber = int.Parse(KPD_CheckNumber);
                    Model_Details.KPD_BadNumber = int.Parse(KPD_BadNumber);
                    Model_Details.KPD_YNTState = int.Parse(KPD_YNTState);
                    Model_Details.KPD_UploadUrl = "";
                    Model_Details.KPD_Prant = 0;
                    Model_Details.KPD_Remark = KPD_Remark;
                    Model_Details.KPD_Brand = KPD_Brand;
                    Model_Details.KPD_RejectRatio = decimal.Parse(KPD_RejectRatio) / 100;
                    Model_Details.KPD_Proposer = AM.KNet_StaffNo;
                    Model_Details.KPD_KDNumber = int.Parse(KPD_KDNumber);
                    Model_Details.KPD_PTime = DateTime.Now;
                    Model_Details.KPD_PTime = DateTime.Now;
                    Arr_Products.Add(Model_Details);
                }
                model.Arr_Products = Arr_Products;
            }
            bll.Update(model);
            AM.Add_Logs("IQC--->IQC检测--->IQC检测结果  操作成功！送检单号：" + model.KSP_SID);
            AlertAndRedirect("操作成功！", "Knet_OQCSubmitted_Product_List.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    /// <summary>
    /// 取消
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_OnClick(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 特采审核
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_Chcek_OnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();

        try
        {
            if (AM.YNAuthority("特采审核"))
            {
                if (btn_Chcek.Text == "特采审核")
                {
                    string DoSqlOrder = " update Knet_Submitted_Product set  KSP_Boss=1 where KSP_SID='" + this.Tbx_ID.Text + "' ";
                    DbHelperSQL.ExecuteSql(DoSqlOrder);
                    //Button1.Text = "反审核";
                    Alert("特采审核成功");
                }
                if (btn_Chcek.Text == "反特采审核")
                {
                    string DoSqlOrder = " update Knet_Submitted_Product set  KSP_Boss=0 where KSP_SID='" + this.Tbx_ID.Text + "' ";
                    DbHelperSQL.ExecuteSql(DoSqlOrder);
                    //Button1.Text = "审核";
                    Alert("反特采审核成功");
                }

                DateShow(this.Tbx_ID.Text);
            }
            else
            {
                Alert("你没有特采审核的权限");
            }
        }
        catch (Exception)
        {

            Alert("特采审核失败");
        }
    }

    /// <summary>
    /// 上传附件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void button3_OnServerClick(object sender, EventArgs e)
    {
        if (!(uploadFile2.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            //string FileType = uploadFile1.PostedFile.ContentType.ToString(); //文件类型
            //GetThumbnailImage1();
            string UploadPath = "../../UpFile/QGInfo/"; //上传路径
            //if (this.CustomerValue.Value != "")
            //{
            //    UploadPath += this.CustomerValue.Value + "/";
            //}
            string AutoPath =
                System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
            string fileExt = Path.GetExtension(uploadFile2.PostedFile.FileName); //获扩展名
            string FileType = uploadFile2.PostedFile.ContentType.ToString(); //文件类型
            string FileName = Path.GetFileName(uploadFile2.PostedFile.FileName);
            string filePath = UploadPath + AutoPath + fileExt;
            if (!Directory.Exists(Server.MapPath(UploadPath)))
            {
                Directory.CreateDirectory(Server.MapPath(UploadPath));
            }
            uploadFile2.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
            this.Lbl_Details1.Text = "<input Name=\"KPS_InvoiceUrl\"  type=\"hidden\"  value=" + filePath +
                                     "><input Name=\"KPS_Invoice\"  type=\"hidden\"  value=" + FileName + "><a href=\"" +
                                     filePath + "\" >" + FileName + "</a>";
            this.UploadUrl.Text = filePath;
            this.Lbl_Details1.Text = FileName;
        }
    }

    /// <summary>
    /// 主管审核
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_OnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (AM.YNAuthority("OQC审核"))
            {
                if (Button1.Text == "审核")
                {
                    string DoSqlOrder = " update Knet_Submitted_Product set  KSP_State=1,KSP_Sproposer='" + AM.KNet_StaffNo + "' where KSP_SID='" + this.Tbx_ID.Text + "' ";
                    DbHelperSQL.ExecuteSql(DoSqlOrder);
                    //Button1.Text = "反审核";
                    string sql =
          "select * from  Knet_Submitted_Product_Details  where KPD_SID='" + this.Tbx_ID.Text + "' and KPD_YNTState=2";
                    this.BeginQuery(sql);
                    DataTable Dtb_Table = this.QueryForDataTable();
                    if (Dtb_Table.Rows.Count > 0)
                    {
                        string body = "送检单号为" + this.Tbx_ID.Text + ",有不良产品,请相关部门注意";//+"qcx@systech.com.cn" + "|" 
                        string email_list = "zxc@systech.com.cn" + "|"+ "xb@systech.com.cn" + "|" + "yww@systech.com.cn" + "|" + "qjy@systech.com.cn" + "|";
                        string File_Path = "";
                        Send("IQC检验不良通知", body, email_list, File_Path);
                    }
                    Alert("审核成功");
                }
                if (Button1.Text == "反审核")
                {
                    string DoSqlOrder = " update Knet_Submitted_Product set  KSP_State=0,KSP_Sproposer='" + AM.KNet_StaffNo + "' where KSP_SID='" + this.Tbx_ID.Text + "' ";
                    DbHelperSQL.ExecuteSql(DoSqlOrder);
                    //Button1.Text = "审核";
                    Alert("反审核成功");
                }

                DateShow(this.Tbx_ID.Text);
            }
            else
            {
                Alert("你没有审核的权限");
            }
            
        }
        catch (Exception)
        {

            Alert("审核失败");
        }
    }
    #region 审核成功后，如果有不合格发送邮件
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
    protected void Button4_OnClick(object sender, EventArgs e)
    {
        //Server.Transfer("KnetProductsSetting_Details.aspx");
        string CodeString = "", SubCode = "";
        if (Button1.Text == "审核")
        {
            Alert("未审核，不能调拨入库");
            return;
        }
        else if (btn_Chcek.Text == "反特采审核")
        {
            string sql =
            "select * from Knet_Submitted_Product a join Knet_Submitted_Product_Details b on a.KSP_SID=b.KPD_SID where KSP_SID='" +
            this.Tbx_ID.Text + "'";
            this.BeginQuery(sql);
            DataTable Dtb_Table = this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    if (Dtb_Table.Rows[i]["KPD_YNTState"].ToString() == "1" || Dtb_Table.Rows[i]["KPD_YNTState"].ToString() == "3")
                    {
                        CodeString += "'" + Dtb_Table.Rows[i]["KPD_Code"].ToString() + "'" + ",";
                    }
                }
            }
        }
        else
        {
            string sql =
           "select * from Knet_Submitted_Product a join Knet_Submitted_Product_Details b on a.KSP_SID=b.KPD_SID where KSP_SID='" +
           this.Tbx_ID.Text + "'";
            this.BeginQuery(sql);
            DataTable Dtb_Table = this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {

                    if (Dtb_Table.Rows[i]["KPD_YNTState"].ToString() == "1")
                    {
                        CodeString += "'" + Dtb_Table.Rows[i]["KPD_Code"].ToString() + "'" + ",";
                    }
                    if (Dtb_Table.Rows[i]["KPD_YNTState"].ToString() == "3" && GetTeCaiCount(Dtb_Table.Rows[i]["KPD_Code"].ToString()) < 3)
                    {
                        CodeString += "'" + Dtb_Table.Rows[i]["KPD_Code"].ToString() + "'" + ",";
                    }
                    if (Dtb_Table.Rows[i]["KPD_YNTState"].ToString() == "0")
                    {
                        CodeString += "'" + Dtb_Table.Rows[i]["KPD_Code"].ToString() + "'" + ",";
                    }
                }
            }
        }
        if (CodeString != "")
        {
            SubCode = CodeString.Substring(0, CodeString.Length - 1);
        }
        else
        {
            SubCode = "";
        }
        Response.Redirect(@"/Web/CG/OrderInWareHouse/Knet_Procure_WareHouseList_Add.aspx?OrderNo=" + this.Tbx_Order.Text + "&&SubCode=" + SubCode + "");
    }
    /// <summary>
    /// 获取特采的数量
    /// </summary>
    /// <returns></returns>
    public int GetTeCaiCount(string Code)
    {
        string sql =
          "select count(*) from  Knet_Submitted_Product_Details  where KPD_Code='" +
          Code + "' and KPD_YNTState=3";
        this.BeginQuery(sql);
        DataTable Dtb_Table = this.QueryForDataTable();
        if (Dtb_Table.Rows.Count > 0)
        {
            return int.Parse(Dtb_Table.Rows[0][0].ToString());
        }
        else
        {
            return 0;
        }
    }
    /// <summary>
    /// 异常上传
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_Anomaly_OnServerClick(object sender, EventArgs e)
    {
        if (!(File_Anomaly.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            //string FileType = uploadFile1.PostedFile.ContentType.ToString(); //文件类型
            //GetThumbnailImage1();
            string UploadPath = "../../UpFile/QGInfo/"; //上传路径
            //if (this.CustomerValue.Value != "")
            //{
            //    UploadPath += this.CustomerValue.Value + "/";
            //}
            string AutoPath =
                System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
            string fileExt = Path.GetExtension(File_Anomaly.PostedFile.FileName); //获扩展名
            string FileType = File_Anomaly.PostedFile.ContentType.ToString(); //文件类型
            string FileName = Path.GetFileName(File_Anomaly.PostedFile.FileName);
            string filePath = UploadPath + AutoPath + fileExt;
            if (!Directory.Exists(Server.MapPath(UploadPath)))
            {
                Directory.CreateDirectory(Server.MapPath(UploadPath));
            }
            File_Anomaly.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
            this.Anomaly.Text = "<input Name=\"KPS_Anomaly\"  type=\"hidden\"  value=" + filePath +
                                     "><input Name=\"KPS_InvoiceAnomaly\"  type=\"hidden\"  value=" + FileName + "><a href=\"" +
                                     filePath + "\" >" + FileName + "</a>";
            this.Anomaly_Url.Text = filePath;
            this.Anomaly.Text = FileName;
        }
    }
    /// <summary>
    /// 供应商回传
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_Back_OnServerClick(object sender, EventArgs e)
    {
        if (!(File_Back.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            //string FileType = uploadFile1.PostedFile.ContentType.ToString(); //文件类型
            //GetThumbnailImage1();
            string UploadPath = "../../UpFile/QGInfo/"; //上传路径
            //if (this.CustomerValue.Value != "")
            //{
            //    UploadPath += this.CustomerValue.Value + "/";
            //}
            string AutoPath =
                System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
            string fileExt = Path.GetExtension(File_Back.PostedFile.FileName); //获扩展名
            string FileType = File_Back.PostedFile.ContentType.ToString(); //文件类型
            string FileName = Path.GetFileName(File_Back.PostedFile.FileName);
            string filePath = UploadPath + AutoPath + fileExt;
            if (!Directory.Exists(Server.MapPath(UploadPath)))
            {
                Directory.CreateDirectory(Server.MapPath(UploadPath));
            }
            File_Back.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
            this.Back.Text = "<input Name=\"KPS_Back\"  type=\"hidden\"  value=" + filePath +
                                     "><input Name=\"KPS_InvoiceBack\"  type=\"hidden\"  value=" + FileName + "><a href=\"" +
                                     filePath + "\" >" + FileName + "</a>";
            this.Back_Url.Text = filePath;
            this.Back.Text = FileName;
        }
    }
    /// <summary>
    /// 入成品库
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button5_OnClick(object sender, EventArgs e)
    {
        string CodeString = "", SubCode = "";
        if (Button1.Text == "审核")
        {
            Alert("未审核，不能调拨入库");
            return;
        }
        else if (btn_Chcek.Text == "反特采审核")
        {
            string sql =
            "select * from Knet_Submitted_Product a join Knet_Submitted_Product_Details b on a.KSP_SID=b.KPD_SID where KSP_SID='" +
            this.Tbx_ID.Text + "'";
            this.BeginQuery(sql);
            DataTable Dtb_Table = this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    if (Dtb_Table.Rows[i]["KPD_YNTState"].ToString() == "1" || Dtb_Table.Rows[i]["KPD_YNTState"].ToString() == "3")
                    {
                        CodeString += "'" + Dtb_Table.Rows[i]["KPD_Code"].ToString() + "'" + ",";
                    }
                }
            }
        }
        else
        {
            string sql =
           "select * from Knet_Submitted_Product a join Knet_Submitted_Product_Details b on a.KSP_SID=b.KPD_SID where KSP_SID='" +
           this.Tbx_ID.Text + "'";
            this.BeginQuery(sql);
            DataTable Dtb_Table = this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {

                    if (Dtb_Table.Rows[i]["KPD_YNTState"].ToString() == "1")
                    {
                        CodeString += "'" + Dtb_Table.Rows[i]["KPD_Code"].ToString() + "'" + ",";
                    }
                    if (Dtb_Table.Rows[i]["KPD_YNTState"].ToString() == "3" && GetTeCaiCount(Dtb_Table.Rows[i]["KPD_Code"].ToString()) < 3)
                    {
                        CodeString += "'" + Dtb_Table.Rows[i]["KPD_Code"].ToString() + "'" + ",";
                    }
                    if (Dtb_Table.Rows[i]["KPD_KDNumber"].ToString()!="0")
                    {
                        CodeString += "'" + Dtb_Table.Rows[i]["KPD_Code"].ToString() + "'" + ",";
                    }
                }
            }
        }
        if (CodeString != "")
        {
            SubCode = CodeString.Substring(0, CodeString.Length - 1);
        }
        else
        {
            SubCode = "";
            Alert("不合格，无法入库");
            return;
        }
        //&&SubCode=" + SubCode + "
        Response.Redirect(@"/Web/WareHouseAllocateList/KNet_WareHouse_AllocateList_Add.aspx?OrderNo=" + this.Tbx_Order.Text + "&&KSP_SID=" + this.Tbx_ID.Text + "&&Type=3&&Sumb=1");
    }
    /// <summary>
    /// 加工厂退还
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button6_OnClick(object sender, EventArgs e)
    {
        string CodeString = "", SubCode = "";
        if (Button1.Text == "审核")
        {
            Alert("未审核，不能调拨入库");
            return;
        }
        //else if (btn_Chcek.Text == "反特采审核")
        //{
        //    string sql =
        //    "select * from Knet_Submitted_Product a join Knet_Submitted_Product_Details b on a.KSP_SID=b.KPD_SID where KSP_SID='" +
        //    this.Tbx_ID.Text + "'";
        //    this.BeginQuery(sql);
        //    DataTable Dtb_Table = this.QueryForDataTable();
        //    if (Dtb_Table.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < Dtb_Table.Rows.Count; i++)
        //        {
        //            if (Dtb_Table.Rows[i]["KPD_YNTState"].ToString() == "1" || Dtb_Table.Rows[i]["KPD_YNTState"].ToString() == "3")
        //            {
        //                CodeString += "'" + Dtb_Table.Rows[i]["KPD_Code"].ToString() + "'" + ",";
        //            }
        //        }
        //    }
        //}
        else
        {
            string sql =
           "select * from Knet_Submitted_Product a join Knet_Submitted_Product_Details b on a.KSP_SID=b.KPD_SID where KSP_SID='" +
           this.Tbx_ID.Text + "'";
            this.BeginQuery(sql);
            DataTable Dtb_Table = this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {

                    if (Dtb_Table.Rows[i]["KPD_BadNumber"].ToString() != "0")
                    {
                        CodeString += "'" + Dtb_Table.Rows[i]["KPD_Code"].ToString() + "'" + ",";
                    }
                    //if (Dtb_Table.Rows[i]["KPD_YNTState"].ToString() == "3" && GetTeCaiCount(Dtb_Table.Rows[i]["KPD_Code"].ToString()) < 3)
                    //{
                    //    CodeString += "'" + Dtb_Table.Rows[i]["KPD_Code"].ToString() + "'" + ",";
                    //}
                }
            }
        }
        if (CodeString != "")
        {
            SubCode = CodeString.Substring(0, CodeString.Length - 1);
        }
        else
        {
            SubCode = "";
            Alert("没有不良数量，无法退货");
            return;
        }
        //&&SubCode=" + SubCode + "
        Response.Redirect(@"/Web/WareHouseAllocateList/KNet_WareHouse_AllocateList_Add.aspx?OrderNo=" + this.Tbx_Order.Text + "&&KSP_SID=" + this.Tbx_ID.Text + "&&Type=1&&Sumb=1");
    }
}
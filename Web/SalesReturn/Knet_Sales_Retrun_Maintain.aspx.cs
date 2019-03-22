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

public partial class Web_SalesReturn_Knet_Sales_Retrun_Maintain : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string suppno = Request.QueryString["SuppNo"] == null ? "" : Request.QueryString["SuppNo"].ToString();
            string ReturnNo = Request.QueryString["ReturnNo"] == null ? "" : Request.QueryString["ReturnNo"].ToString();
            string KSM_Type = Request.QueryString["KSM_Type"] == null
                ? ""
                : Request.QueryString["KSM_Type"].ToString();
            string contractNo = Request.QueryString["ContractNo"] == null
                ? ""
                : Request.QueryString["ContractNo"].ToString();
            Suppno.Text = suppno;
            this.ReturnNo.Text = ReturnNo;
            ContractNo.Text = contractNo;
            base.Base_DropBasicCodeBind(this.Ddl_Type, "213"); //类型
            base.Base_DropBasicCodeBind(this.Ddl_HurryState, "214", false); //
            //base.Base_DropBasicCodeBind(this.Ddl_TimeState, "215"); //
            //base.Base_DropBasicCodeBind(this.Dpl_Result, "1143", false); //
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            base.Base_DropLinkManBind(this.Ddl_LinkMan, this.Tbx_CustomerValue.Value);

            this.Tbx_Stime.Text = DateTime.Now.ToShortDateString();
            this.Lbl_Title.Text = "新增客户抱怨";
            //if (productcode!="")
            //{
            //    string[] arrStr = productcode.Split(',');
            //    ProductCount.Text = arrStr.Length.ToString();
            //}


            if (s_Type != "")
            {
                Button4.Visible = false;
                this.D3.Visible = true;
                this.D2.Visible = true;
                int Kcount = 0;
                KNet.BLL.KNet_Sales_ReturnList_Details BLL_Details = new KNet.BLL.KNet_Sales_ReturnList_Details();
                DataSet Dts_Details = BLL_Details.GetList(" ReturnNo='" + ReturnNo + "'");
                StringBuilder Sb_Details = new StringBuilder();
                if (Dts_Details.Tables[0].Rows.Count > 0)
                {
                    ProductCount.Text = Dts_Details.Tables[0].Rows.Count.ToString();
                    for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                    {
              
                        Sb_Details.Append("<tr>\n");


                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id=\"KSD_ProductCode_" + i.ToString() + "\" type=\"hidden\" name=\"KSD_ProductCode_" +
                                          i.ToString() + "\"  value=\"" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "\" />" +
                                         base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "\n");
                        Sb_Details.Append("</td>\n"); //产品名称

                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id=\"KPD_Code_" + i.ToString() + "\" type=\"hidden\" name=\"KPD_Code_" +
                                          i.ToString() + "\"  />" +
                                         Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "\n");
                        Sb_Details.Append("</td>\n"); //产品编号

                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id=\"KPD_Brand_" + i.ToString() + "\" type=\"hidden\" name=\"KPD_Brand_" +
                                          i.ToString() + "\"  />" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "\n");
                        Sb_Details.Append("</td>\n"); //产品版本
                        Kcount += int.Parse(Dts_Details.Tables[0].Rows[i]["ReturnAmount"].ToString());
                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id=\"ProductsEdition_" + i.ToString() +
                                          "\" type=\"hidden\" name=\"Number_" + i.ToString() + "\" value=\"" + Dts_Details.Tables[0].Rows[i]["ReturnAmount"].ToString() + "\"  />" +
                                         Dts_Details.Tables[0].Rows[i]["ReturnAmount"].ToString() + "\n");
                        Sb_Details.Append("</td>\n"); //客退数量
                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id=\"KSD_GoodNumber_" + i.ToString() +
                                          "\" type=\"text\" style=\"width:70px;\" name=\"KSD_GoodNumber_" + i.ToString() +
                                          "\"  value=\"0\" />\n");
                        Sb_Details.Append("</td>\n"); //修好数量   
                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id=\"KSD_BadNumber_" + i.ToString() +
                                          "\" type=\"text\" style=\"width:70px;\" name=\"KSD_BadNumber_" + i.ToString() +
                                          "\"  value=\"0\" />\n");
                        Sb_Details.Append("</td>\n"); //坏的数量  

                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<Select id=\"KSD_STime_" + i.ToString() + "\" name=\"KSD_STime_" + i.ToString() +
                                          "\">\n");
                        Sb_Details.Append("<option value=\"1\" selected >一小时</option>\n");
                        Sb_Details.Append("<option value=\"2\" >二小时</option>\n");
                        Sb_Details.Append("<option value=\"3\" >半个工作日</option>\n");
                        Sb_Details.Append("<option value=\"4\" >一个工作日</option>\n");
                        Sb_Details.Append("<option value=\"5\" >二个工作日</option>\n");
                        Sb_Details.Append("<option value=\"6\" >二个工作日以上</option>\n");
                        Sb_Details.Append("</Select>\n");
                        Sb_Details.Append("</td>\n"); //花费时间 

                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id = \"KSD_Text_" + i.ToString() + "\" name=\"KSD_Text_" + i.ToString() +
                                          "\" type=\"text\" style=\"width: 600px\" value=\"\" />");
                        Sb_Details.Append("</td>\n"); //备注
                        Sb_Details.Append("</tr>\n");
                    }
                    this.Lbl_SDetail.Text = Sb_Details.ToString();
                }
                SalesOrderNo.Text = ContractNo.Text;
                Tbx_D2Number.Text = Kcount.ToString();
                Tbx_CustomerValue.Value = Suppno.Text;
                KNet.BLL.KNet_Sales_ClientList bll = new KNet.BLL.KNet_Sales_ClientList();
                KNet.Model.KNet_Sales_ClientList model = bll.GetModelB(Suppno.Text);
                Tbx_CustomerName.Text = model.CustomerName;
          
            }

            else
            {
                Button4.Visible = true;
                //this.D3.Visible = true;//维修对策
                if (KSM_Type=="3")
                {
                    this.D3.Visible = true;//维修对策
                    this.D2.Visible = true; //问题描述
                }
                else
                {
                    this.D2.Visible = true; //问题描述
                    this.D4.Visible = true; //客诉对策
                }
                
            }

            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
            else
            {
                this.Tbx_Code.Text = s_GetCode();
            }
            this.D0.Visible = true;


            //客户抱怨列表
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
        }
    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Knet_Sales_Retrun_Maintain bll = new KNet.BLL.Knet_Sales_Retrun_Maintain();
        KNet.Model.Knet_Sales_Retrun_Maintain model = bll.GetModel(s_ID);
        AdminloginMess AM = new AdminloginMess();
        try
        {
            this.Tbx_ID.Text = model.KSM_ID;
            this.Tbx_Code.Text = model.KSM_MID;
            this.SalesOrderNoSelectValue.Value = model.KSM_OrderNo;
            this.SalesOrderNo.Text = model.KSM_OrderNo;
            this.Tbx_CustomerValue.Value = model.KSM_SuppNo;
            this.Tbx_CustomerName.Text = base.Base_GetCustomerName(model.KSM_SuppNo);
            try
            {
                this.Tbx_Stime.Text = DateTime.Parse(model.KSM_Time.ToString()).ToShortDateString();
                
            }
            catch
            {
            }
            if (model.KSM_State == 0)
            {
                this.Button2.Text = "审核";
            }
            else
            {
                this.Button2.Text = "反审核";
            }
            this.Ddl_Type.SelectedValue = model.KSM_Type.ToString();
            this.Ddl_HurryState.SelectedValue = model.KSM_Urgency.ToString();
            //this.Ddl_TimeState.SelectedValue = model.KSM_SpTime.ToString();
            base.Base_DropLinkManBind(this.Ddl_LinkMan, model.KSM_LinkMan);
            this.Ddl_LinkMan.SelectedValue = model.KSM_LinkMan;
            //this.Tbx_ProductsID.Value = model.KSM_Product;
            //this.Tbx_ProductsName.Text = GetProductsEdition(model.KSM_Product);
            this.Ddl_DutyPerson.SelectedValue = model.KSM_DutyMan;
     
            try
            {
                this.Tbx_D2Time.Text = DateTime.Parse(model.KSM_FindTime.ToString()).ToShortDateString();
            }
            catch
            {
            }
            this.Tbx_D2FRemarks.Text = model.KSM_Text;
            try
            {
                this.Tbx_D2Number.Text = model.KSM_Number.ToString();
            }
            catch
            {
            }
            //维修对策
            this.Lbl_Details1.Text = "<a href=\"" + model.KSM_WUploadUrl + "\">" +
                                     model.KSM_WUploadName + "</a>";
            this.KSM_WUploadName.Text = model.KSM_WUploadName;

            this.Tbx_D3Time.Text = DateTime.Parse(model.KSM_WTime.ToString()).ToShortDateString();

            //客诉对策
            this.Label2.Text = "<a href=\"" + model.KSM_KUploadUrl + "\">" +
                               model.KSM_KUploadName + "</a>";
            this.KSM_KUploadName.Text = model.KSM_KUploadName;

            this.PTextBox1.Text = DateTime.Parse(model.KSM_KTime.ToString()).ToShortDateString();
            this.TextBox1.Text = model.KSM_KText;
            this.Label3.Text = "<a href=\"" + model.KSM_K8DUploadUrl + "\">" +
                               model.KSM_K8DUploadName + "</a>";
            this.KSM_K8DUploadName.Text = model.KSM_K8DUploadName;
            KNet.BLL.Knet_Sales_Retrun_Maintain_Details BLL_Details = new KNet.BLL.Knet_Sales_Retrun_Maintain_Details();
            DataSet Dts_Details = BLL_Details.GetList(" KSD_ID='" + this.Tbx_Code.Text + "'");
            StringBuilder Sb_Details = new StringBuilder();
            if (model.KSM_Type == 3)
            {
                if (Dts_Details.Tables[0].Rows.Count > 0)
                {
                    ProductCount.Text = Dts_Details.Tables[0].Rows.Count.ToString();
                    for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                    {

                        Sb_Details.Append("<tr>\n");


                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id=\"KSD_ProductCode_" + i.ToString() +
                                          "\" type=\"hidden\" name=\"KSD_ProductCode_" +
                                          i.ToString() + "\"  value=\"" +
                                          Dts_Details.Tables[0].Rows[i]["KSD_ProductCode"].ToString() + "\" />" +
                                          base.Base_GetProdutsName(
                                              Dts_Details.Tables[0].Rows[i]["KSD_ProductCode"].ToString()) + "\n");
                        Sb_Details.Append("</td>\n"); //产品名称

                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id=\"KPD_Code_" + i.ToString() + "\" type=\"hidden\" name=\"KPD_Code_" +
                                          i.ToString() + "\"  />" +
                                          Dts_Details.Tables[0].Rows[i]["KSD_ProductCode"].ToString() + "\n");
                        Sb_Details.Append("</td>\n"); //产品编号

                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id=\"KPD_Brand_" + i.ToString() +
                                          "\" type=\"hidden\" name=\"KPD_Brand_" +
                                          i.ToString() + "\"  />" +
                                          base.Base_GetProductsEdition(
                                              Dts_Details.Tables[0].Rows[i]["KSD_ProductCode"].ToString()) + "\n");
                        Sb_Details.Append("</td>\n"); //产品版本

                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id=\"ProductsEdition_" + i.ToString() +
                                          "\" type=\"hidden\" name=\"Number_" + i.ToString() + "\" value=\"" +
                                          Dts_Details.Tables[0].Rows[i]["KSD_Number"].ToString() + "\"  />" +
                                          Dts_Details.Tables[0].Rows[i]["KSD_Number"].ToString() + "\n");
                        Sb_Details.Append("</td>\n"); //客退数量
                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id=\"KSD_GoodNumber_" + i.ToString() +
                                          "\" type=\"text\" style=\"width:70px;\" name=\"KSD_GoodNumber_" + i.ToString() +
                                          "\"  value=\"" + Dts_Details.Tables[0].Rows[i]["KSD_GoodNumber"].ToString() +
                                          "\" />\n");
                        Sb_Details.Append("</td>\n"); //修好数量   
                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id=\"KSD_BadNumber_" + i.ToString() +
                                          "\" type=\"text\" style=\"width:70px;\" name=\"KSD_BadNumber_" + i.ToString() +
                                          "\"  value=\"" + Dts_Details.Tables[0].Rows[i]["KSD_BadNumber"].ToString() +
                                          "\" />\n");
                        Sb_Details.Append("</td>\n"); //坏的数量  

                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<Select id=\"KSD_STime_" + i.ToString() + "\" name=\"KSD_STime_" +
                                          i.ToString() +
                                          "\">\n");
                        if (Dts_Details.Tables[0].Rows[i]["KSD_STime"].ToString() == "1")
                        {
                            Sb_Details.Append("<option value=\"1\" selected >一小时</option>\n");
                            Sb_Details.Append("<option value=\"2\" >二小时</option>\n");
                            Sb_Details.Append("<option value=\"3\" >半个工作日</option>\n");
                            Sb_Details.Append("<option value=\"4\" >一个工作日</option>\n");
                            Sb_Details.Append("<option value=\"5\" >二个工作日</option>\n");
                            Sb_Details.Append("<option value=\"6\" >二个工作日以上</option>\n");
                        }
                        if (Dts_Details.Tables[0].Rows[i]["KSD_STime"].ToString() == "2")
                        {
                            Sb_Details.Append("<option value=\"1\" >一小时</option>\n");
                            Sb_Details.Append("<option value=\"2\" selected >二小时</option>\n");
                            Sb_Details.Append("<option value=\"3\" >半个工作日</option>\n");
                            Sb_Details.Append("<option value=\"4\" >一个工作日</option>\n");
                            Sb_Details.Append("<option value=\"5\" >二个工作日</option>\n");
                            Sb_Details.Append("<option value=\"6\" >二个工作日以上</option>\n");
                        }
                        if (Dts_Details.Tables[0].Rows[i]["KSD_STime"].ToString() == "3")
                        {
                            Sb_Details.Append("<option value=\"1\" >一小时</option>\n");
                            Sb_Details.Append("<option value=\"2\" >二小时</option>\n");
                            Sb_Details.Append("<option value=\"3\" selected >半个工作日</option>\n");
                            Sb_Details.Append("<option value=\"4\" >一个工作日</option>\n");
                            Sb_Details.Append("<option value=\"5\" >二个工作日</option>\n");
                            Sb_Details.Append("<option value=\"6\" >二个工作日以上</option>\n");
                        }
                        if (Dts_Details.Tables[0].Rows[i]["KSD_STime"].ToString() == "4")
                        {
                            Sb_Details.Append("<option value=\"1\" >一小时</option>\n");
                            Sb_Details.Append("<option value=\"2\" >二小时</option>\n");
                            Sb_Details.Append("<option value=\"3\" >半个工作日</option>\n");
                            Sb_Details.Append("<option value=\"4\" selected >一个工作日</option>\n");
                            Sb_Details.Append("<option value=\"5\" >二个工作日</option>\n");
                            Sb_Details.Append("<option value=\"6\" >二个工作日以上</option>\n");
                        }
                        if (Dts_Details.Tables[0].Rows[i]["KSD_STime"].ToString() == "5")
                        {
                            Sb_Details.Append("<option value=\"1\" >一小时</option>\n");
                            Sb_Details.Append("<option value=\"2\" >二小时</option>\n");
                            Sb_Details.Append("<option value=\"3\" >半个工作日</option>\n");
                            Sb_Details.Append("<option value=\"4\" >一个工作日</option>\n");
                            Sb_Details.Append("<option value=\"5\" selected >二个工作日</option>\n");
                            Sb_Details.Append("<option value=\"6\" >二个工作日以上</option>\n");
                        }
                        if (Dts_Details.Tables[0].Rows[i]["KSD_STime"].ToString() == "6")
                        {
                            Sb_Details.Append("<option value=\"1\" >一小时</option>\n");
                            Sb_Details.Append("<option value=\"2\" >二小时</option>\n");
                            Sb_Details.Append("<option value=\"3\" >半个工作日</option>\n");
                            Sb_Details.Append("<option value=\"4\" >一个工作日</option>\n");
                            Sb_Details.Append("<option value=\"5\" >二个工作日</option>\n");
                            Sb_Details.Append("<option value=\"6\" selected >二个工作日以上</option>\n");
                        }
                        Sb_Details.Append("</Select>\n");
                        Sb_Details.Append("</td>\n"); //花费时间 

                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id = \"KSD_Text_" + i.ToString() + "\" name=\"KSD_Text_" +
                                          i.ToString() +
                                          "\" type=\"text\" style=\"width: 600px\" value=\"" +
                                          Dts_Details.Tables[0].Rows[i]["KSD_Text"].ToString() + "\" />");
                        Sb_Details.Append("</td>\n"); //备注
                        Sb_Details.Append("</tr>\n");
                    }
                    this.Lbl_SDetail.Text = Sb_Details.ToString();
                }
            }
            else
            {
                if (Dts_Details.Tables[0].Rows.Count > 0)
                {
                    Tbx_Num.Text = Dts_Details.Tables[0].Rows.Count.ToString();
                    for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                    {

                        Sb_Details.Append("<tr>\n");

                        
                        //Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        //Sb_Details.Append("<A onclick=\"deleteRow2(this)\" href=\"#\"><img src=\"/themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a>\n");
                        //Sb_Details.Append("</td>\n"); //工具

                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id=\"ProdoctsBarCode_" + i.ToString() + "\" type=\"hidden\" name=\"ProdoctsBarCode_" +
                                          i.ToString() + "\"  />" +
                                          Dts_Details.Tables[0].Rows[i]["KSD_ProductCode"].ToString() + "\n");
                        Sb_Details.Append("</td>\n"); //产品编号

                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id=\"ProdoctName_" + i.ToString() +
                                          "\" type=\"hidden\" name=\"ProdoctName_" +
                                          i.ToString() + "\"  value=\"" +
                                          Dts_Details.Tables[0].Rows[i]["KSD_ProductCode"].ToString() + "\" />" +
                                          base.Base_GetProdutsName(
                                              Dts_Details.Tables[0].Rows[i]["KSD_ProductCode"].ToString()) + "\n");
                        Sb_Details.Append("</td>\n"); //产品名称

                      

                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id=\"ProdctsEdition_" + i.ToString() +
                                          "\" type=\"hidden\" name=\"ProdctsEdition_" +
                                          i.ToString() + "\"  />" +
                                          base.Base_GetProductsEdition(
                                              Dts_Details.Tables[0].Rows[i]["KSD_ProductCode"].ToString()) + "\n");
                        Sb_Details.Append("</td>\n"); //产品版本                       

                        Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                        Sb_Details.Append("<input id = \"Remark_" + i.ToString() + "\" name=\"Remark_" +
                                          i.ToString() +
                                          "\" type=\"text\" style=\"width: 600px\" value=\"" +
                                          Dts_Details.Tables[0].Rows[i]["KSD_Text"].ToString() + "\" />");
                        Sb_Details.Append("</td>\n"); //备注
                        Sb_Details.Append("</tr>\n");
                    }
                    this.Label_KReturn.Text = Sb_Details.ToString();
                }
            }

        }
        catch
        {
        }
    }

    private bool SetValue(KNet.Model.Knet_Sales_Retrun_Maintain model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {

            if (this.Tbx_Code.Text == "")
            {
                model.KSM_MID = s_GetCode();
            }
            else
            {
                model.KSM_MID = this.Tbx_Code.Text;
            }
            if (this.Tbx_ID.Text != "")
            {
                model.KSM_ID = this.Tbx_ID.Text;
            }
            model.KSM_Time = DateTime.Parse(this.Tbx_Stime.Text);
            model.KSM_Type = int.Parse(this.Ddl_Type.SelectedValue);
            model.KSM_Urgency = int.Parse(Ddl_HurryState.SelectedValue);
            try
            {
                model.KSM_OrderNo = this.SalesOrderNo.Text;
            }
            catch
            {
            }
           

            model.KSM_SuppNo = this.Tbx_CustomerValue.Value;

          
            model.KSM_LinkMan = this.Ddl_LinkMan.SelectedValue;
            
            model.KSM_DutyMan = this.Ddl_DutyPerson.SelectedValue;
            try
            {
                model.KSM_FindTime = DateTime.Parse(Tbx_D2Time.Text);
            }
            catch
            {
                model.KSM_FindTime = DateTime.Today;
                ;
            }



            try
            {
                model.KSM_Number = int.Parse(this.Tbx_D2Number.Text);
            }
            catch
            {
            }

            model.KSM_Text = this.Tbx_D2FRemarks.Text;
            if (KSM_WUploadName.Text!="")
            {
                model.KSM_WUploadName = KSM_WUploadName.Text;
            }
            else
            {
                model.KSM_WUploadName = Lbl_Details1.Text;
            }
            model.KSM_WUploadUrl = KSM_WUploadUrl.Text;
            try
            {
                model.KSM_WTime = DateTime.Parse(Tbx_D3Time.Text);
            }
            catch
            {
                model.KSM_WTime = DateTime.Today;
            }

            if (KSM_KUploadName.Text!="")
            {
                model.KSM_KUploadName = KSM_KUploadName.Text;
            }
            else
            {
                model.KSM_KUploadName = Label2.Text;
            }
            model.KSM_KUploadUrl = KSM_KUploadUrl.Text;
            if (KSM_K8DUploadName.Text!="")
            {
                model.KSM_K8DUploadName = KSM_K8DUploadName.Text;
            }
            else
            {
                model.KSM_K8DUploadName = Label3.Text;
            }
            try
            {
                model.KSM_KTime = DateTime.Parse(PTextBox1.Text);
            }
            catch
            {
                model.KSM_KTime = DateTime.Today;
            }
            model.KSM_KText = TextBox1.Text;
            model.KSM_K8DUploadUrl = KSM_K8DUploadUrl.Text;
            model.KSM_State = 0;
            model.KSM_DState = 0;
            ArrayList Arr_Products = new ArrayList();
            if (Ddl_Type.SelectedValue == "3")
            {
                if (ProductCount.Text != "")
                {
                    for (int i = 0; i < int.Parse(ProductCount.Text); i++)
                    {
                        KNet.Model.Knet_Sales_Retrun_Maintain_Details Model_Details =
                            new KNet.Model.Knet_Sales_Retrun_Maintain_Details();

                        string KSD_ProductCode = Request["KSD_ProductCode_" + i.ToString() + ""] == null
                            ? ""
                            : Request["KSD_ProductCode_" + i.ToString() + ""].ToString();
                        string Number = Request["Number_" + i.ToString() + ""] == null
                            ? ""
                            : Request["Number_" + i.ToString() + ""].ToString();
                        string KSD_GoodNumber = Request["KSD_GoodNumber_" + i.ToString() + ""] == null
                            ? ""
                            : Request["KSD_GoodNumber_" + i.ToString() + ""].ToString();
                        string KSD_BadNumber = Request["KSD_BadNumber_" + i.ToString() + ""] == null
                            ? ""
                            : Request["KSD_BadNumber_" + i.ToString() + ""].ToString();
                        string KSD_STime = Request["KSD_STime_" + i.ToString() + ""] == null
                            ? ""
                            : Request["KSD_STime_" + i.ToString() + ""].ToString();
                        string KSD_Text = Request["KSD_Text_" + i.ToString() + ""] == null
                            ? ""
                            : Request["KSD_Text_" + i.ToString() + ""].ToString();


                        Model_Details.KSD_ID = this.Tbx_Code.Text;
                        Model_Details.KSD_ProductCode = KSD_ProductCode;
                        //Model_Details.KPD_OrderNo = this.Tbx_Order.Text;
                        Model_Details.KSD_Number = int.Parse(Number);
                        Model_Details.KSD_BadNumber = int.Parse(KSD_BadNumber);
                        Model_Details.KSD_GoodNumber = int.Parse(KSD_GoodNumber);
                        Model_Details.KSD_STime = int.Parse(KSD_STime);
                        Model_Details.KSD_Result = 0;
                        Model_Details.KSD_Text = KSD_Text;
                        Arr_Products.Add(Model_Details);
                    }
                    model.Arr_Products = Arr_Products;
                }
            }
            else
            {
                if (Tbx_Num.Text != "0")
                {
                    for (int i = 0; i < int.Parse(Tbx_Num.Text); i++)
                    {
                        KNet.Model.Knet_Sales_Retrun_Maintain_Details Model_Details =
                            new KNet.Model.Knet_Sales_Retrun_Maintain_Details();

                        string KSD_ProductCode = Request["ProdoctsBarCode_" + i.ToString() + ""] == null
                            ? ""
                            : Request["ProdoctsBarCode_" + i.ToString() + ""].ToString();
                       
                        string KSD_Text = Request["Remark_" + i.ToString() + ""] == null
                            ? ""
                            : Request["Remark_" + i.ToString() + ""].ToString();
                        if (KSD_ProductCode!="")
                        {
                            Model_Details.KSD_ID = this.Tbx_Code.Text;
                            Model_Details.KSD_ProductCode = KSD_ProductCode;
                            //Model_Details.KPD_OrderNo = this.Tbx_Order.Text;
                            Model_Details.KSD_Number = 0;
                            Model_Details.KSD_BadNumber = 0;
                            Model_Details.KSD_GoodNumber = 0;
                            Model_Details.KSD_STime = 0;
                            Model_Details.KSD_Result = 0;
                            Model_Details.KSD_Text = KSD_Text;
                            Arr_Products.Add(Model_Details);
                        }
                      
                    }
                    model.Arr_Products = Arr_Products;
                }
            }
            return true;
        }
        catch
        {
            return false;
        }

    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_ID = this.Tbx_ID.Text;

        KNet.Model.Knet_Sales_Retrun_Maintain model = new KNet.Model.Knet_Sales_Retrun_Maintain();
        KNet.BLL.Knet_Sales_Retrun_Maintain bll = new KNet.BLL.Knet_Sales_Retrun_Maintain();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (s_ID == "") //新增
        {
            try
            {

               // base.GetNewID("ZL_Complain_Manage", 1);
                bll.Add(model);
                AM.Add_Logs("客户抱怨/维修增加" + this.Tbx_Code.Text);
                AlertAndRedirect("新增成功！", "ZL_Complain_Manage_List.aspx");
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
                bll.Update(model);
                AM.Add_Logs("客户抱怨修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "ZL_Complain_Manage_List.aspx");
            }
            catch
            {
            }
        }
    }

    private string s_GetCode()
    {
        string s_Return = "";
        try
        {
            KNet.BLL.Knet_Sales_Retrun_Maintain Bll = new KNet.BLL.Knet_Sales_Retrun_Maintain();
            string S_Code = Bll.GetLastCode();

            if (S_Code == "")
            {

                s_Return += "K" + DateTime.Today.ToString("yyyyMMdd") + "-" + "0001";
            }
            else
            {
                try
                {
                    S_Code = "1" + S_Code.Substring(10, 4);
                }
                catch
                {

                    S_Code = "10" + S_Code.Substring(10, 3);
                }
                decimal d_NewCode = decimal.Parse(S_Code) + 1;
                if (d_NewCode == 20000)
                {
                    d_NewCode = 20001;
                }
                s_Return += "K" + DateTime.Today.ToString("yyyyMMdd") + "-" +
                            d_NewCode.ToString().Substring(1, d_NewCode.ToString().Length - 1);
            }

        }
        catch (Exception ex)
        {
            s_Return = "-";
        }
        return s_Return;
    }

    public string GetProductsEdition(string productcodelist)
    {

        string s_Return = "";
        this.BeginQuery(
            "select ProductsBarCode,ProductsEdition,ProductsPattern,KSP_Code,ProductsName from KNet_Sys_Products where ProductsBarCode in(" +
            productcodelist + ")");
        this.QueryForDataTable();
        try
        {
            if (this.Dtb_Result.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                {
                    //s_Return += Dtb_Result.Rows[i][1].ToString();
                    s_Return += Dtb_Result.Rows[i][1].ToString();
                }
                return s_Return;
            }
            else
            {
                return "--";
            }
        }
        catch
        {
            return "--";

        }

    }

    /// <summary>
    /// 审核
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_OnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (AM.YNAuthority("客诉/客退审核"))
            {
                if (Button2.Text == "反审核")
                {
                    string DoSqlOrder = " update Knet_Sales_Retrun_Maintain set  KSM_State=0 where KSM_MID='" + this.Tbx_Code.Text + "' ";
                    DbHelperSQL.ExecuteSql(DoSqlOrder);
                    Button2.Text = "审核";
                    Alert("反审核成功");
                }
                else
                {
                    string DoSqlOrder = " update Knet_Sales_Retrun_Maintain set  KSM_State=1 where KSM_MID='" + this.Tbx_Code.Text + "' ";
                    DbHelperSQL.ExecuteSql(DoSqlOrder);
                    Button2.Text = "反审核";
                    Alert("审核成功");
                }
            }

            else
            {
                Alert("你没有审核的权限");
            }  

        }
        catch
        {
            Alert("审核失败");

        }

    }
    /// <summary>
    /// /上传维修文件
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
            this.KSM_WUploadUrl.Text = filePath;
            this.Lbl_Details1.Text = FileName;
        }
    }
    /// <summary>
    /// /上传客诉文件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void button5_OnServerClick(object sender, EventArgs e)
    {
        if (!(File2.PostedFile.ContentLength > 0))
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
            string fileExt = Path.GetExtension(File2.PostedFile.FileName); //获扩展名
            string FileType = File2.PostedFile.ContentType.ToString(); //文件类型
            string FileName = Path.GetFileName(File2.PostedFile.FileName);
            string filePath = UploadPath + AutoPath + fileExt;
            if (!Directory.Exists(Server.MapPath(UploadPath)))
            {
                Directory.CreateDirectory(Server.MapPath(UploadPath));
            }
            File2.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
            this.Label2.Text = "<input Name=\"KPS_InvoiceUrl\"  type=\"hidden\"  value=" + filePath +
                                     "><input Name=\"KPS_Invoice\"  type=\"hidden\"  value=" + FileName + "><a href=\"" +
                                     filePath + "\" >" + FileName + "</a>";
            this.KSM_KUploadUrl.Text = filePath;
            this.Label2.Text = FileName;
        }
    }

    /// <summary>
    /// 上传8D文件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void button6_OnServerClick(object sender, EventArgs e)
    {
        if (!(File3.PostedFile.ContentLength > 0))
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
            string fileExt = Path.GetExtension(File3.PostedFile.FileName); //获扩展名
            string FileType = File3.PostedFile.ContentType.ToString(); //文件类型
            string FileName = Path.GetFileName(File3.PostedFile.FileName);
            string filePath = UploadPath + AutoPath + fileExt;
            if (!Directory.Exists(Server.MapPath(UploadPath)))
            {
                Directory.CreateDirectory(Server.MapPath(UploadPath));
            }
            File3.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
            this.Label3.Text = "<input Name=\"KPS_InvoiceUrl\"  type=\"hidden\"  value=" + filePath +
                                     "><input Name=\"KPS_Invoice\"  type=\"hidden\"  value=" + FileName + "><a href=\"" +
                                     filePath + "\" >" + FileName + "</a>";
            this.KSM_K8DUploadUrl.Text = filePath;
            this.Label3.Text = FileName;
        }
    }
}
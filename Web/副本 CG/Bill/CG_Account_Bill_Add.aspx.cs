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


public partial class CG_Account_Bill_Add : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(CG_Account_Bill_Add));
        AdminloginMess AM = new AdminloginMess();
        if (!Page.IsPostBack)
        {
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_CheckNo = Request.QueryString["CheckNo"] == null ? "" : Request.QueryString["CheckNo"].ToString();
            this.Tbx_CheckNo.Text = s_CheckNo;
            this.Tbx_FID.Text = s_CheckNo;
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            base.Base_DropBasicCodeBind(this.Ddl_BillType, "203");
            this.Tbx_STime.Text = DateTime.Now.ToShortDateString();
            base.Base_DropBasicCodeBind(this.Ddl_PayMent, "300");
            base.Base_DropBasicCodeBind(this.Ddl_Type, "144");
            this.Ddl_BillType.SelectedValue = "0";
            this.Tbx_Brokerage.Text = AM.KNet_StaffName;
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Tbx_Code.Text = GetCwCode(0, "CG_Account_Bill", "CAB_Code", "CAB_Stime");
                    this.Lbl_Title.Text = "复制发票管理";
                }
                else
                {
                    this.Lbl_Title.Text = "修改发票管理";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增发票管理";
                this.Tbx_Code.Text = GetCwCode(1, "CG_Account_Bill", "CAB_Code", "CAB_Stime");
            }
            ShowCheckDetails(s_CheckNo);
        }
    }


    private void ShowDiog(bool b_True)
    {
        string s_Sql = "Select * from PB_Basic_Attachment where PBA_Type='CGFP' and PBA_FID='" + this.Tbx_Code.Text + "' order by PBA_CTime desc";
        this.BeginQuery(s_Sql);
        DataTable Dtb_Table = this.QueryForDataTable();
        if (Dtb_Table.Rows.Count > 0)
        {
            this.Lbl_Upload.Text = "<a href=\"" + Dtb_Table.Rows[0]["PBA_URL"].ToString() + "\">" + Dtb_Table.Rows[0]["PBA_Name"].ToString() + "</a><br/>";
            string s_Name = this.Tbx_Sheet.Text;
            string s_Str = " var temp = window.showModalDialog(\"CG_Account_Bill_Excel.aspx?ID=" + this.Tbx_Code.Text + "&Table=" + Server.UrlEncode(s_Name) + "\", \"\", \"dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=700px\");";
            StringBuilder s = new StringBuilder();
            s.Append("<script language=javascript>" + "\n");
            s.Append(s_Str + "\n");
            s.Append(" if (temp == \"true\")\n");
            s.Append("{\n");
            s.Append(" window.location.reload();\n");
            s.Append("} \n");
            s.Append("</script>");
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            string csname = "ltype";
            if (!cs.IsStartupScriptRegistered(cstype, csname))
                cs.RegisterStartupScript(cstype, csname, s.ToString());
        }
    }
    protected void save_Click(object sender, EventArgs e)
    {

        if (!(uploadFile.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            AdminloginMess AM = new AdminloginMess();
            KNet.Model.PB_Basic_Attachment model = new KNet.Model.PB_Basic_Attachment();
            string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
            GetThumbnailImage1(model);
            try
            {
                KNet.BLL.PB_Basic_Attachment BLL = new KNet.BLL.PB_Basic_Attachment();
                BLL.DeleteByFID(this.Tbx_Code.Text);
                BLL.Add(model);
                AM.Add_Logs("附件上传成功：编号：" + model.PBA_ID);
                this.Lbl_Upload.Text = "<a href=\"" + model.PBA_URL + "\">" + model.PBA_Name + "</a><br/>";
            }
            catch (Exception ex) { }
        }
    }



    #region 资料上传操作
    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage1(KNet.Model.PB_Basic_Attachment model)
    {
        AdminloginMess AM = new AdminloginMess();
        //类别下面的
        string UploadPath = "../../../UpFile/CGFP/";  //上传路径
        string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
        //string fileExt = Path.GetExtension(uploadFile1.PostedFile.FileName); //获扩展名
        string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
        string FileName = Path.GetFileName(uploadFile.PostedFile.FileName);
        string filePath = UploadPath + AutoPath + "_" + FileName; //大文件名
        if (!Directory.Exists(Server.MapPath(UploadPath)))
        {
            Directory.CreateDirectory(Server.MapPath(UploadPath));
        }
        uploadFile.PostedFile.SaveAs(Server.MapPath(filePath)); //上传

        model.PBA_FID = this.Tbx_Code.Text;
        model.PBA_Type = "CGFP";
        model.PBA_ID = GetMainID();
        model.PBA_Name = FileName;
        model.PBA_URL = filePath;
        model.PBA_CTime = DateTime.Now;
        model.PBA_Creator = AM.KNet_StaffNo;
        model.PBA_Remarks = "";
    }
    #endregion
    protected void Btn_Serch_Click1(object sender, EventArgs e)
    {
        ShowDiog(true);
    }
    private void ShowCheckDetails(string s_CheckNo)
    {
        AdminloginMess AM = new AdminloginMess();
        if (s_CheckNo != "")
        {
            KNet.BLL.Cg_Order_Checklist Bll = new KNet.BLL.Cg_Order_Checklist();
            KNet.Model.Cg_Order_Checklist Model = Bll.GetModel(s_CheckNo);
            string s_SuppNo = "";
            if (Model.COC_Type == "1")
            {
                s_SuppNo = Model.COC_SuppNo;
            }
            else
            {
                //遥控器对账
                KNet.BLL.KNet_Sys_WareHouse Bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                KNet.Model.KNet_Sys_WareHouse Model_WareHouse = Bll_WareHouse.GetModel(Model.COC_HouseNo);
                s_SuppNo = Model_WareHouse.SuppNo;
            }
            KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
            KNet.Model.Knet_Procure_Suppliers Model_supp = Bll_Supp.GetModelB(s_SuppNo);
            this.Tbx_SuppNo.Value = s_SuppNo;
            this.Tbx_SuppName.Text = Model_supp.SuppName;
            try
            {
                this.Ddl_PayMent.SelectedValue = Model_supp.KPS_Days.ToString();
            }
            catch { }

            string s_Sql = "Select Sum(COD_Money) from Cg_Order_Checklist_Details where COD_CheckNo='" + s_CheckNo + "' ";
            this.BeginQuery(s_Sql);
            string s_Money = this.QueryForReturn();
            this.Tbx_Money.Text = s_Money;
            string s_Sql1 = " COD_CheckNo='" + s_CheckNo + "'";
            if (this.Tbx_ID.Text != "")
            {
                //  s_Sql1 += " and COD_Code in (select CABD_CheckDetailsID from CG_Account_Bill_Details  where CABD_FID='" + this.Tbx_ID.Text + "' )";
            }
            else
            {
                s_Sql1 += " and COD_Code not in (select CABD_CheckDetailsID from CG_Account_Bill_Details a join CG_Account_Bill b on a.CABD_FID=b.CAB_ID  where CAB_SuppNo='" + this.Tbx_SuppNo.Value + "' )";
            }

            s_Sql1 += " Order by COD_ProductsBarCode ";


            s_Sql = "Select * from PB_Basic_Attachment where PBA_Type='CgFp' and PBA_FID='" + this.Tbx_Code.Text + "' order by PBA_CTime desc";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                this.Lbl_Upload.Text = "<a href=\"" + Dtb_Table.Rows[0]["PBA_URL"].ToString() + "\">" + Dtb_Table.Rows[0]["PBA_Name"].ToString() + "</a><br/>";
                this.Tbx_URL.Text = Dtb_Table.Rows[0]["PBA_URL"].ToString();
            }
            Excel excel = new Excel();
            DataTable myT = excel.ExcelToDataTable(this.Tbx_URL.Text, this.Tbx_Sheet.Text);
            this.BeginQuery("select * from Excel_In_Details where EID_FID='" + this.Tbx_Code.Text + "' ");
            DataTable Dtb_Excel = this.QueryForDataTable();
            string[] s_FName = new string[9];
            if (Dtb_Excel.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Excel.Rows.Count; i++)
                {
                    int i_Num = int.Parse(Dtb_Excel.Rows[i]["EID_YLine"].ToString()) + 1;
                    if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "OrderNo")
                    {
                        s_FName[0] = "f" + i_Num.ToString();
                    }
                    else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "WareHouseAmount")
                    {
                        s_FName[1] = "f" + i_Num.ToString();
                    }
                    else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "ProductsEdition")
                    {
                        s_FName[2] = "f" + Dtb_Excel.Rows[i]["EID_YLine"].ToString();
                    }
                    else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "wuliu")
                    {
                        s_FName[3] = "f" + i_Num.ToString();
                    }
                    else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "Price")
                    {
                        s_FName[4] = "f" + i_Num.ToString();
                    }
                    else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "FPCode")
                    {
                        s_FName[5] = "f" + i_Num.ToString();
                    }
                    if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "DirectOutNo")
                    {
                        s_FName[6] = "f" + i_Num.ToString();
                    }
                }

            }
            string s_OrderNo = "", s_DirectOutNO = "";
            KNet.BLL.Cg_Order_Checklist_Details Bll_Details = new KNet.BLL.Cg_Order_Checklist_Details();
            DataSet Dts_Table = Bll_Details.GetListJoinCGFP(s_Sql1);
            decimal d_Total = 0, d_Total1 = 0, d_Total2 = 0, d_Total3 = 0;

            decimal dd_Total = 0, dd_Total1 = 0, dd_Total2 = 0, dd_Total3 = 0, dd_Total4 = 0;
            this.Lbl_Detail.Text = " <table id=\"myTable\" width=\"98%\" border=\"0\" align=\"center\" cellpadding=\"2\" cellspacing=\"0\" class=\"ListDetails\" style=\"height: 28px\">";

            this.Lbl_Detail.Text += "<tr valign=\"top\">";
            this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
            this.Lbl_Detail.Text += "<input type=\"CheckBox\" onclick=\"selectAll(this)\"></td>";
            this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
            this.Lbl_Detail.Text += "<b>发生单号</b></td>";
            this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
            this.Lbl_Detail.Text += "<b>订单号</b></td>";
            this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
            this.Lbl_Detail.Text += "<b>发生日期</b></td>";
            this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
            this.Lbl_Detail.Text += "<b>客户/供应商</b></td>";
            this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
            this.Lbl_Detail.Text += "<b>产品</b></td>";
            this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
            this.Lbl_Detail.Text += "<b>产品编码</b></td>";
            this.Lbl_Detail.Text += "<td class=\"ListHead\" >";
            this.Lbl_Detail.Text += "<b>版本号</b></td>";
            this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
            this.Lbl_Detail.Text += "<b>数量</b></td>";
            this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
            this.Lbl_Detail.Text += "<b>对账</b></td>";
            this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
            this.Lbl_Detail.Text += "<b>备品</b></td>";
            this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
            this.Lbl_Detail.Text += "<b>单价</b></td>";
            this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
            this.Lbl_Detail.Text += "<b>加单</b></td>";
            this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
            this.Lbl_Detail.Text += "<b>总金额</b></td>";
            this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
            this.Lbl_Detail.Text += "<b>发票号</b></td>";
            this.Lbl_Detail.Text += "<td class=\"ListHead\" nowrap>";
            this.Lbl_Detail.Text += "<b>备注</b></td>";
            this.Lbl_Detail.Text += "</tr>";
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                this.Lbl_Detail.Text += "";
                string s_FPCode = "";
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    string s_Check = "";

                    this.Lbl_Detail.Text += " <tr>";

                    if (Model.COC_Type == "0")//遥控器对账
                    {
                        KNet.BLL.KNet_WareHouse_DirectOutList_Details Bll_DirectOutDetails = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
                        KNet.Model.KNet_WareHouse_DirectOutList_Details Model_DirectOutDetails = Bll_DirectOutDetails.GetModel(Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString());
                        if (Model_DirectOutDetails != null)
                        {
                            KNet.BLL.KNet_WareHouse_DirectOutList Bll_DirectOut = new KNet.BLL.KNet_WareHouse_DirectOutList();
                            KNet.Model.KNet_WareHouse_DirectOutList Model_DirectOut = Bll_DirectOut.GetModelB(Model_DirectOutDetails.DirectOutNo);
                            s_DirectOutNO = Model_DirectOut.DirectOutNo;
                            string s_SqlWhere = " 1=1 ";
                            if ((s_FName[0] != "") && (s_DirectOutNO != ""))
                            {
                                s_SqlWhere += " and " + s_FName[6] + "='" + s_DirectOutNO.Trim() + "' ";
                            }
                            if (myT != null)
                            {

                                DataRow[] arrayDR = myT.Select(s_SqlWhere);
                                foreach (DataRow dr in arrayDR)
                                {
                                    s_Check = "checked";
                                    s_FPCode = dr["" + s_FName[5] + ""].ToString();
                                }
                            }
                            else
                            {
                                s_Check = "";
                            }
                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\"><input type=\"CheckBox\" ID=\"Chk_" + i.ToString() + "\"  Name=\"Chk_" + i.ToString() + "\" onclick=\"Sum(" + i.ToString() + ")\" " + s_Check + "><input name=\"Tbx_CODID_" + i.ToString() + "\" type=\"text\" id=\"Tbx_CODID_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["COD_Code"].ToString() + " style=\"display: none\" /></td>";

                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\"><input name=\"Tbx_DirectOutID_" + i.ToString() + "\" type=\"text\" id=\"Tbx_DirectOutID_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString() + " style=\"display: none\" />" + Model_DirectOutDetails.DirectOutNo + "</td>";

                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + Model_DirectOut.KWD_ShipNo + "</td>";
                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + DateTime.Parse(Model_DirectOut.DirectOutDateTime.ToString()).ToShortDateString() + "</td>";
                        }
                    }
                    else
                    {
                        KNet.BLL.Knet_Procure_WareHouseList_Details Bll_WareHouseDetails = new KNet.BLL.Knet_Procure_WareHouseList_Details();
                        KNet.Model.Knet_Procure_WareHouseList_Details Model_WareHouseDetails = Bll_WareHouseDetails.GetModel(Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString());
                        if (Model_WareHouseDetails != null)
                        {
                            KNet.BLL.Knet_Procure_WareHouseList Bll_WareHouse = new KNet.BLL.Knet_Procure_WareHouseList();
                            KNet.Model.Knet_Procure_WareHouseList Model_WareHouse = Bll_WareHouse.GetModelB(Model_WareHouseDetails.WareHouseNo);
                            s_OrderNo = Model_WareHouse.OrderNo;
                            string s_SqlWhere = " 1=1 ";
                            if ((s_FName[0] != "") && (s_OrderNo != ""))
                            {
                                s_SqlWhere += " and " + s_FName[0] + "='" + s_OrderNo.Trim() + "' ";
                            }
                            if (myT != null)
                            {

                                DataRow[] arrayDR = myT.Select(s_SqlWhere);
                                foreach (DataRow dr in arrayDR)
                                {
                                    s_Check = "checked";
                                    s_FPCode = dr["" + s_FName[5] + ""].ToString();

                                }
                            }
                            else
                            {
                                s_Check = "";
                            }
                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\"><input type=\"CheckBox\" ID=\"Chk_" + i.ToString() + "\"  Name=\"Chk_" + i.ToString() + "\" onclick=\"Sum(" + i.ToString() + ")\" " + s_Check + "><input name=\"Tbx_CODID_" + i.ToString() + "\" type=\"text\" id=\"Tbx_CODID_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["COD_Code"].ToString() + " style=\"display: none\" /></td>";

                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\"  nowrap><a href='../OrderInWareHouse/Knet_Procure_WareHouseList_View.aspx?ID=" + Model_WareHouseDetails.WareHouseNo + "' target=\"_blank\">" + Model_WareHouseDetails.WareHouseNo + "</td>";
                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\"><input name=\"Tbx_DirectOutID_" + i.ToString() + "\" type=\"text\" id=\"Tbx_DirectOutID_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString() + " style=\"display: none\" />" + Model_WareHouse.OrderNo + "</td>";
                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + DateTime.Parse(Model_WareHouse.WareHouseDateTime.ToString()).ToShortDateString() + "</td>";
                        }
                    }
                    string s_CustomerValue = base.Base_GetHouseName(Dts_Table.Tables[0].Rows[i]["COD_CustomerValue"].ToString());
                    if (s_CustomerValue == "")
                    {
                        s_CustomerValue = base.Base_GetCustomerName_Link(Dts_Table.Tables[0].Rows[i]["COD_CustomerValue"].ToString());
                    }
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + s_CustomerValue + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProdutsName_Link(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\" nowrap><input name=\"Tbx_ProductsBarCode_" + i.ToString() + "\" type=\"text\" id=\"Tbx_ProductsBarCode_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString() + " style=\"display: none\" />" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_CkNumber"].ToString(), 0) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_DzNumber"].ToString(), 0) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString(), 0) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_Price"].ToString(), 3) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_HandPrice"].ToString(), 3) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\"><input name=\"Tbx_Money_" + i.ToString() + "\" type=\"text\" id=\"Tbx_Money_" + i.ToString() + "\" value=" + FormatNumber1(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString(), 3) + " style=\"display: none\" />" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString(), 3) + "</td>";

                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\"><input name=\"Tbx_FpCode_" + i.ToString() + "\" type=\"text\" id=\"Tbx_FpCode_" + i.ToString() + "\" value=\"" + s_FPCode + "\" class=\"detailedViewTextBox\" width=\"200px\"  /></td>";

                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["COD_Details"].ToString() + "</td>";
                    this.Lbl_Detail.Text += "</tr>";
                    try
                    {
                        d_Total += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_CkNumber"].ToString());
                        d_Total1 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_DzNumber"].ToString());
                        d_Total2 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString());
                        d_Total3 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString());
                        dd_Total += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_CkNumber"].ToString());
                        dd_Total1 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_DzNumber"].ToString());
                        dd_Total2 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString());
                        dd_Total3 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString());
                    }
                    catch
                    { }

                    if ((i > 1) && (i < Dts_Table.Tables[0].Rows.Count - 1))
                    {
                        if (Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString() != Dts_Table.Tables[0].Rows[i + 1]["COD_ProductsBarCode"].ToString())
                        {
                            this.Lbl_Detail.Text += "<tr style=\"background-color:#0ff\">";
                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"left\" colspan=6>小计：</td>";
                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";

                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total.ToString(), 0) + "</td>";
                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total1.ToString(), 0) + "</td>";
                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total2.ToString(), 0) + "</td>";
                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total3.ToString(), 2) + "</td>";
                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total4.ToString(), 2) + "</td>";
                            this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\" colspan=2>&nbsp;</td>";
                            this.Lbl_Detail.Text += "</tr>";
                            dd_Total = 0;
                            dd_Total1 = 0;
                            dd_Total2 = 0;
                            dd_Total3 = 0;
                            dd_Total4 = 0;

                        }
                    }
                    else if (i == Dts_Table.Tables[0].Rows.Count - 1)
                    {
                        this.Lbl_Detail.Text += "<tr style=\"background-color:#0ff\">";
                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"left\" colspan=6>小计：</td>";
                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";

                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total.ToString(), 0) + "</td>";
                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total1.ToString(), 0) + "</td>";
                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total2.ToString(), 0) + "</td>";
                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total3.ToString(), 2) + "</td>";
                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total4.ToString(), 2) + "</td>";
                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\" colspan=2>&nbsp;</td>";
                        this.Lbl_Detail.Text += "</tr>";
                        dd_Total = 0;
                        dd_Total1 = 0;
                        dd_Total2 = 0;
                        dd_Total3 = 0;
                        dd_Total4 = 0;
                    }
                }
                this.Lbl_Detail.Text += "<tr>";
                this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"left\" colspan=8>合计：</td>";
                this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total.ToString(), 0) + "</td>";
                this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total1.ToString(), 0) + "</td>";
                this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total2.ToString(), 0) + "</td>";
                this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
                this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
                this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total3.ToString(), 2) + "</td>";
                this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\" colspan=2>&nbsp;</td>";
                this.Lbl_Detail.Text += "</tr>";
            }
            this.Lbl_Detail.Text += "<input name=\"DetailsNum\" type=\"text\" id=\"DetailsNum\" value=" + Dts_Table.Tables[0].Rows.Count + " style=\"display: none\" />";
            this.Lbl_Detail.Text += "</table>";
        }
    }


    [Ajax.AjaxMethod]
    public string ShowCheckDetails1(string s_CheckNo, string s_InSuppNo, string s_ID)
    {
        string s_SuppNo = "";
        string s_Return = "";
        string s_Type = "";
        string s_Money = "0";
        if (s_CheckNo != "")
        {

            KNet.BLL.Cg_Order_Checklist Bll = new KNet.BLL.Cg_Order_Checklist();
            KNet.Model.Cg_Order_Checklist Model = Bll.GetModel(s_CheckNo);
            s_CheckNo = Model.COC_Type;
            if (s_CheckNo == "1")
            {
                s_SuppNo = Model.COC_SuppNo;
            }
            else
            {
                //遥控器对账
                KNet.BLL.KNet_Sys_WareHouse Bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                KNet.Model.KNet_Sys_WareHouse Model_WareHouse = Bll_WareHouse.GetModel(Model.COC_HouseNo);
                s_SuppNo = Model_WareHouse.SuppNo;
            }
        }
        else
        {
            s_SuppNo = s_InSuppNo;
        }
        KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
        KNet.Model.Knet_Procure_Suppliers Model_supp = Bll_Supp.GetModelB(s_SuppNo);
        s_Return = Model_supp.KPS_Days.ToString() + "|";

        if (s_CheckNo != "")
        {
            string s_Sql = "Select Sum(COD_Money) from Cg_Order_Checklist_Details where COD_CheckNo='" + s_CheckNo + "' ";
            this.BeginQuery(s_Sql);
            s_Money = this.QueryForReturn();
        }
        s_Return += s_Money + "|";
        string s_Sql1 = " 1=1 ";
        if (s_CheckNo != "")
        {
            s_Sql1 += " COD_CheckNo='" + s_CheckNo + "'";
        }
        else
        {
            if (s_InSuppNo != "")
            {
                //原材料和遥控器对账单
                s_Sql1 += "  and COD_CheckNO in (Select COC_Code from Cg_Order_Checklist where COC_SuppNo ='" + s_InSuppNo + "' union all Select COC_Code from Cg_Order_Checklist a join KNet_Sys_WareHouse b on a.Coc_HouseNo=b.HouseNO where b.SuppNo='" + s_InSuppNo + "')";

            }
        }

        if (s_ID == "")
        {
            s_Sql1 += " and COD_Code not in (select CABD_CheckDetailsID from CG_Account_Bill_Details a join CG_Account_Bill b on a.CABD_FID=b.CAB_ID  where CAB_SuppNo='" + s_SuppNo + "' )";
        }
        else
        {
            s_Sql1 += " and COD_Code  in (select CABD_CheckDetailsID from CG_Account_Bill_Details a join CG_Account_Bill b on a.CABD_FID=b.CAB_ID  where CAB_ID='" + s_ID + "' )";
        }

        s_Sql1 += " Order by COD_ProductsBarCode ";
          s_Sql1 = "Select * from PB_Basic_Attachment where PBA_Type='CgFp' and PBA_FID='" + this.Tbx_Code.Text + "' order by PBA_CTime desc";
        this.BeginQuery(s_Sql1);
        DataTable Dtb_Table = this.QueryForDataTable();
        if (Dtb_Table.Rows.Count > 0)
        {
            this.Lbl_Upload.Text = "<a href=\"" + Dtb_Table.Rows[0]["PBA_URL"].ToString() + "\">" + Dtb_Table.Rows[0]["PBA_Name"].ToString() + "</a><br/>";
            this.Tbx_URL.Text = Dtb_Table.Rows[0]["PBA_URL"].ToString();
        }
        Excel excel = new Excel();
        DataTable myT = excel.ExcelToDataTable(this.Tbx_URL.Text, this.Tbx_Sheet.Text);
        this.BeginQuery("select * from Excel_In_Details where EID_FID='" + this.Tbx_Code.Text + "' ");
        DataTable Dtb_Excel = this.QueryForDataTable();
        string[] s_FName = new string[9];
        if (Dtb_Excel.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Excel.Rows.Count; i++)
            {
                int i_Num = int.Parse(Dtb_Excel.Rows[i]["EID_YLine"].ToString()) + 1;
                if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "OrderNo")
                {
                    s_FName[0] = "f" + i_Num.ToString();
                }
                else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "WareHouseAmount")
                {
                    s_FName[1] = "f" + i_Num.ToString();
                }
                else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "ProductsEdition")
                {
                    s_FName[2] = "f" + Dtb_Excel.Rows[i]["EID_YLine"].ToString();
                }
                else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "wuliu")
                {
                    s_FName[3] = "f" + i_Num.ToString();
                }
                else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "Price")
                {
                    s_FName[4] = "f" + i_Num.ToString();
                }
                else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "FPCode")
                {
                    s_FName[5] = "f" + i_Num.ToString();
                }
                if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "DirectOutNo")
                {
                    s_FName[6] = "f" + i_Num.ToString();
                }
            }

        }
        string s_OrderNo = "", s_DirectOutNO = "";

        KNet.BLL.Cg_Order_Checklist_Details Bll_Details = new KNet.BLL.Cg_Order_Checklist_Details();
        DataSet Dts_Table = Bll_Details.GetListJoinCGFP(s_Sql1);
        decimal d_Total = 0, d_Total1 = 0, d_Total2 = 0, d_Total3 = 0;
        decimal dd_Total = 0, dd_Total1 = 0, dd_Total2 = 0, dd_Total3 = 0, dd_Total4 = 0;
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            s_Return += "";

            s_Return += " <table id=\"myTable\" width=\"98%\" border=\"0\" align=\"center\" cellpadding=\"2\" cellspacing=\"0\" class=\"ListDetails\" style=\"height: 28px\">";
            s_Return += "<tr valign=\"top\">";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<input type=\"CheckBox\" onclick=\"selectAll(this)\"></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>发生单号</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>订单号</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>发生日期</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>客户/供应商</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>产品</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>产品编码</b></td>";
            s_Return += "<td class=\"ListHead\" >";
            s_Return += "<b>版本号</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>数量</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>对账</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>备品</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>单价</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>加单</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>总金额</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap>";
            s_Return += "<b>备注</b></td>";
            s_Return += "</tr>";
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                string s_Check = "", s_FPCode="";
                string s_State = Dts_Table.Tables[0].Rows[i]["State"].ToString();
                s_Return += " <tr>";

                KNet.BLL.KNet_WareHouse_DirectOutList_Details Bll_DirectOutDetails = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
                KNet.Model.KNet_WareHouse_DirectOutList_Details Model_DirectOutDetails = Bll_DirectOutDetails.GetModel(Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString());
                if (Model_DirectOutDetails != null)
                {
                    KNet.BLL.KNet_WareHouse_DirectOutList Bll_DirectOut = new KNet.BLL.KNet_WareHouse_DirectOutList();
                    KNet.Model.KNet_WareHouse_DirectOutList Model_DirectOut = Bll_DirectOut.GetModelB(Model_DirectOutDetails.DirectOutNo);
                    s_DirectOutNO = Model_DirectOut.DirectOutNo;
                    string s_SqlWhere = " 1=1 ";
                    if ((s_FName[0] != "") && (s_DirectOutNO != ""))
                    {
                        s_SqlWhere += " and " + s_FName[6] + "='" + s_DirectOutNO.Trim() + "' ";
                    }
                    if (myT != null)
                    {

                        DataRow[] arrayDR = myT.Select(s_SqlWhere);
                        foreach (DataRow dr in arrayDR)
                        {
                            s_Check = "checked";
                            s_FPCode = dr["" + s_FName[5] + ""].ToString();
                        }
                    }
                    else
                    {
                        s_Check = "";
                    }
                    s_Return += "<td class=\"ListHeadDetails\" align=\"center\"><input type=\"CheckBox\" ID=\"Chk_" + i.ToString() + "\"  Name=\"Chk_" + i.ToString() + "\" onclick=\"Sum(" + i.ToString() + ")\" " + s_Check + "><input name=\"Tbx_CODID_" + i.ToString() + "\" type=\"text\" id=\"Tbx_CODID_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["COD_Code"].ToString() + " style=\"display: none\" /></td>";

                    s_Return += "<td class=\"ListHeadDetails\" align=\"center\"><input name=\"Tbx_DirectOutID_" + i.ToString() + "\" type=\"text\" id=\"Tbx_DirectOutID_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString() + " style=\"display: none\" />" + Model_DirectOutDetails.DirectOutNo + "</td>";

                    s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + Model_DirectOut.KWD_ShipNo + "</td>";
                    s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + DateTime.Parse(Model_DirectOut.DirectOutDateTime.ToString()).ToShortDateString() + "</td>";
                }
                KNet.BLL.Knet_Procure_WareHouseList_Details Bll_WareHouseDetails = new KNet.BLL.Knet_Procure_WareHouseList_Details();
                KNet.Model.Knet_Procure_WareHouseList_Details Model_WareHouseDetails = Bll_WareHouseDetails.GetModel(Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString());
                if (Model_WareHouseDetails != null)
                {
                    KNet.BLL.Knet_Procure_WareHouseList Bll_WareHouse = new KNet.BLL.Knet_Procure_WareHouseList();
                    KNet.Model.Knet_Procure_WareHouseList Model_WareHouse = Bll_WareHouse.GetModelB(Model_WareHouseDetails.WareHouseNo);
                    s_OrderNo = Model_WareHouse.OrderNo;
                    string s_SqlWhere = " 1=1 ";
                    if ((s_FName[0] != "") && (s_OrderNo != ""))
                    {
                        s_SqlWhere += " and " + s_FName[0] + "='" + s_OrderNo.Trim() + "' ";
                    }
                    if (myT != null)
                    {

                        DataRow[] arrayDR = myT.Select(s_SqlWhere);
                        foreach (DataRow dr in arrayDR)
                        {
                            s_Check = "checked";
                            s_FPCode = dr["" + s_FName[5] + ""].ToString();

                        }
                    }
                    else
                    {
                        s_Check = "";
                    }
                    s_Return += "<td class=\"ListHeadDetails\" align=\"center\"><input type=\"CheckBox\" ID=\"Chk_" + i.ToString() + "\"  Name=\"Chk_" + i.ToString() + "\" onclick=\"Sum(" + i.ToString() + ")\" " + s_Check + "><input name=\"Tbx_CODID_" + i.ToString() + "\" type=\"text\" id=\"Tbx_CODID_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["COD_Code"].ToString() + " style=\"display: none\" /></td>";
                    s_Return += "<td class=\"ListHeadDetails\" align=\"center\"  nowrap><a href='../OrderInWareHouse/Knet_Procure_WareHouseList_View.aspx?ID=" + Model_WareHouseDetails.WareHouseNo + "' target=\"_blank\">" + Model_WareHouseDetails.WareHouseNo + "</td>";
                    s_Return += "<td class=\"ListHeadDetails\" align=\"center\"><input name=\"Tbx_DirectOutID_" + i.ToString() + "\" type=\"text\" id=\"Tbx_DirectOutID_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["COD_DirectOutID"].ToString() + " style=\"display: none\" />" + Model_WareHouse.OrderNo + "</td>";
                    s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + DateTime.Parse(Model_WareHouse.WareHouseDateTime.ToString()).ToShortDateString() + "</td>";
                }
                string s_CustomerValue = base.Base_GetHouseName(Dts_Table.Tables[0].Rows[i]["COD_CustomerValue"].ToString());
                if (s_CustomerValue == "")
                {
                    s_CustomerValue = base.Base_GetCustomerName_Link(Dts_Table.Tables[0].Rows[i]["COD_CustomerValue"].ToString());
                }
                s_Return += "<td class=\"ListHeadDetails\" align=\"left\">" + s_CustomerValue + "</td>";
                s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProdutsName_Link(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";

                s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                s_Return += "<td class=\"ListHeadDetails\" align=\"center\" nowrap><input name=\"Tbx_ProductsBarCode_" + i.ToString() + "\" type=\"text\" id=\"Tbx_ProductsBarCode_" + i.ToString() + "\" value=" + Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString() + " style=\"display: none\" />" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_CkNumber"].ToString(), 0) + "</td>";
                s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_DzNumber"].ToString(), 0) + "</td>";
                s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString(), 0) + "</td>";
                s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_Price"].ToString(), 3) + "</td>";
                s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_HandPrice"].ToString(), 3) + "</td>";
                s_Return += "<td class=\"ListHeadDetails\" align=\"center\"><input name=\"Tbx_Money_" + i.ToString() + "\" type=\"text\" id=\"Tbx_Money_" + i.ToString() + "\" value=" + FormatNumber1(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString(), 3) + " style=\"display: none\" />" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString(), 3) + "</td>";
                s_Return += "<td class=\"ListHeadDetails\" align=\"center\"><input name=\"Tbx_FpCode_" + i.ToString() + "\" type=\"text\" id=\"Tbx_FpCode_" + i.ToString() + "\" value=\"" + s_FPCode + "\"   class=\"detailedViewTextBox\" width=\"200px\"/></td>";

                s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["COD_Details"].ToString() + "</td>";
                s_Return += "</tr>";
                try
                {
                    d_Total += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_CkNumber"].ToString());
                    d_Total1 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_DzNumber"].ToString());
                    d_Total2 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString());
                    d_Total3 += decimal.Parse(FormatNumber1(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString(), 2));
                    dd_Total += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_CkNumber"].ToString());
                    dd_Total1 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_DzNumber"].ToString());
                    dd_Total2 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_BNumber"].ToString());
                    dd_Total3 += decimal.Parse(FormatNumber1(Dts_Table.Tables[0].Rows[i]["COD_Money"].ToString(), 2));
                }
                catch
                { }

                if ((i > 1) && (i < Dts_Table.Tables[0].Rows.Count - 1))
                {
                    if (Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString() != Dts_Table.Tables[0].Rows[i + 1]["COD_ProductsBarCode"].ToString())
                    {
                        this.Lbl_Detail.Text += "<tr style=\"background-color:#0ff\">";
                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"left\" colspan=6>小计：</td>";
                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";

                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total.ToString(), 0) + "</td>";
                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total1.ToString(), 0) + "</td>";
                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total2.ToString(), 0) + "</td>";
                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total3.ToString(), 2) + "</td>";
                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total4.ToString(), 2) + "</td>";
                        this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\" colspan=2>&nbsp;</td>";
                        this.Lbl_Detail.Text += "</tr>";
                        dd_Total = 0;
                        dd_Total1 = 0;
                        dd_Total2 = 0;
                        dd_Total3 = 0;
                        dd_Total4 = 0;

                    }
                }
                else if (i == Dts_Table.Tables[0].Rows.Count - 1)
                {
                    this.Lbl_Detail.Text += "<tr style=\"background-color:#0ff\">";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"left\" colspan=6>小计：</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["COD_ProductsBarCode"].ToString()) + "</td>";

                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total.ToString(), 0) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total1.ToString(), 0) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total2.ToString(), 0) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total3.ToString(), 2) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber1(dd_Total4.ToString(), 2) + "</td>";
                    this.Lbl_Detail.Text += "<td class=\"ListHeadDetails\" align=\"center\" colspan=2>&nbsp;</td>";
                    this.Lbl_Detail.Text += "</tr>";
                    dd_Total = 0;
                    dd_Total1 = 0;
                    dd_Total2 = 0;
                    dd_Total3 = 0;
                    dd_Total4 = 0;

                }
            }
            s_Return += "<tr>";
            s_Return += "<td class=\"ListHeadDetails\" align=\"left\" colspan=8>合计：</td>";
            s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total.ToString(), 0) + "</td>";
            s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total1.ToString(), 0) + "</td>";
            s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total2.ToString(), 0) + "</td>";
            s_Return += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
            s_Return += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
            s_Return += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total3.ToString(), 2) + "</td>";
            s_Return += "<td class=\"ListHeadDetails\" align=\"center\" colspan=\"2\">&nbsp;</td>";
            s_Return += "</tr>";
        }
        s_Return += "<input name=\"DetailsNum\" type=\"text\" id=\"DetailsNum\" value=" + Dts_Table.Tables[0].Rows.Count + " style=\"display: none\" />";
        s_Return += "</table>";
        return s_Return + "|" + d_Total3;
    }
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.CG_Account_Bill bll = new KNet.BLL.CG_Account_Bill();
        KNet.Model.CG_Account_Bill model = bll.GetModel(s_ID);
        try
        {
            if (model.CAB_State != 0)
            {
                AlertAndGoBack("已审批不能修改！");
            }
            this.Tbx_ID.Text = s_ID;
            this.Tbx_SuppNo.Value = model.CAB_SuppNo;
            this.Tbx_Code.Text = model.CAB_Code;
            this.Tbx_SuppName.Text = base.Base_GetSupplierName(model.CAB_SuppNo);
            this.Ddl_PayMent.SelectedValue = model.CAB_PayMent;
            //this.Tbx_Day.Text = model.CAB_Day;
            //try
            //{
            //    this.Tbx_OutTime.Text = DateTime.Parse(model.CAB_OutTime.ToString()).ToShortDateString();
            //}
            //catch
            //{ }
            try
            {
                this.Tbx_STime.Text = DateTime.Parse(model.CAB_Stime.ToString()).ToShortDateString();
            }
            catch
            { }
            this.Ddl_BillType.SelectedValue = model.CAB_BillType.ToString();
            this.Tbx_Money.Text = model.CAB_Money.ToString();
            this.Tbx_Remarks.Text = model.CAB_Remarks;
            this.Tbx_CheckNo.Text = model.CAB_CheckNo;
            if (model.CAB_CheckNo != "")
            {
                ShowCheckDetails(model.CAB_CheckNo);
            }
            else
            {
                string s_Details = ShowCheckDetails1(model.CAB_CheckNo, model.CAB_SuppNo, model.CAB_ID);
                string[] ss = s_Details.Split('|');
                this.Lbl_Detail.Text = ss[2];
                this.Lbl_Detail1.Text = ss[2];
            }

        }
        catch (Exception ex)
        { }
    }
    private bool SetValue(KNet.Model.CG_Account_Bill model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.CAB_ID = GetMainID();
            }
            else
            {
                model.CAB_ID = this.Tbx_ID.Text;
            }
            model.CAB_Code = this.Tbx_Code.Text;
            model.CAB_SuppNo = this.Tbx_SuppNo.Value;
            model.CAB_BillType = this.Ddl_BillType.SelectedValue;
            if (Ddl_PayMent.SelectedValue == "")
            {
                Alert("请选择付款方式！");
            }
            model.CAB_PayMent = this.Ddl_PayMent.SelectedValue;
            model.CAB_Stime = DateTime.Parse(this.Tbx_STime.Text);
            model.CAB_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.CAB_Money = decimal.Parse(this.Tbx_Money.Text);
            model.CAB_FpCode = "";
            model.CAB_Brokerage = this.Tbx_Brokerage.Text;
            model.CAB_Remarks = this.Tbx_Remarks.Text;
            model.CAB_CTime = DateTime.Now;
            model.CAB_Creator = AM.KNet_StaffNo;
            model.CAB_MTime = DateTime.Now;
            model.CAB_Mender = AM.KNet_StaffNo;
            model.CAB_CheckNo = this.Tbx_CheckNo.Text;

            //model.CAB_Day = this.Tbx_Day.Text;
            //model.CAB_OutTime = DateTime.Parse(this.Tbx_OutTime.Text);
            ArrayList arr_Details = new ArrayList();
            string s_DetailsNum = Request["DetailsNum"] == null ? "0" : Request["DetailsNum"].ToString();
            int i_Num = int.Parse(s_DetailsNum);
            for (int i = 0; i < i_Num; i++)
            {

                string Chk_Check = Request.Form["Chk_" + i + ""];
                string s_DirectOutID = Request["Tbx_DirectOutID_" + i + ""] == null ? "" : Request["Tbx_DirectOutID_" + i + ""].ToString();
                string s_CODID = Request["Tbx_CODID_" + i + ""] == null ? "" : Request["Tbx_CODID_" + i + ""].ToString();
                string s_Money = Request["Tbx_Money_" + i + ""] == null ? "" : Request["Tbx_Money_" + i + ""].ToString();
                string s_ProductsBarCode = Request["Tbx_ProductsBarCode_" + i + ""] == null ? "" : Request["Tbx_ProductsBarCode_" + i + ""].ToString();
                string s_FpCode = Request["Tbx_FpCode_" + i + ""] == null ? "" : Request["Tbx_FpCode_" + i + ""].ToString();
                string s_FID = model.CAB_ID;
                if (Request.Form["Chk_" + i.ToString() + ""] != null)
                {
                    KNet.Model.CG_Account_Bill_Details Model_Details = new KNet.Model.CG_Account_Bill_Details();
                    Model_Details.CABD_ID = base.GetMainID(i);
                    Model_Details.CABD_FID = s_FID;
                    Model_Details.CABD_CheckDetailsID = s_CODID;
                    Model_Details.CABD_WareHouseDetailsID = s_DirectOutID;
                    Model_Details.CABD_KpMoney = decimal.Parse(s_Money == "" ? "0" : s_Money);
                    Model_Details.CABD_FPCode = s_FpCode;
                    arr_Details.Add(Model_Details);
                }
            }
            model.Arr_Detail = arr_Details;

            ArrayList arr_Details1 = new ArrayList();
            int i_Num1 = int.Parse(this.i_Num.Text);
            for (int i = 0; i < i_Num1; i++)
            {

                string s_D_Money = Request["D_Money_" + i + ""] == null ? "" : Request["D_Money_" + i + ""].ToString();
                string s_OutDays = Request["D_OutDays_" + i + ""] == null ? "" : Request["D_OutDays_" + i + ""].ToString();
                string s_OutTime = Request["D_OutTime_" + i + ""] == null ? "" : Request["D_OutTime_" + i + ""].ToString();
                string s_Remarks = Request["D_Remarks_" + i + ""] == null ? "" : Request["D_Remarks_" + i + ""].ToString();
                if (s_D_Money != "")
                {
                    KNet.Model.CG_Account_Bill_Outimes Model_Outimes = new KNet.Model.CG_Account_Bill_Outimes();

                    Model_Outimes.CABO_ID = base.GetMainID(i);
                    Model_Outimes.CABO_Money = decimal.Parse(s_D_Money);
                    Model_Outimes.CABO_OutTime = DateTime.Parse(s_OutTime);
                    Model_Outimes.CABO_Days = int.Parse(s_OutDays);
                    Model_Outimes.CABO_FID = model.CAB_ID;
                    arr_Details1.Add(Model_Outimes);
                }
            }
            model.arr_OutTimes = arr_Details1;
            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_ID = this.Tbx_ID.Text;

        KNet.Model.CG_Account_Bill model = new KNet.Model.CG_Account_Bill();
        KNet.BLL.CG_Account_Bill bll = new KNet.BLL.CG_Account_Bill();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (s_ID == "")//新增
        {
            try
            {
                bll.Add(model);
                AM.Add_Logs("发票管理增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "CG_Account_Bill_List.aspx");
            }
            catch { }
        }
        else
        {

            try
            {
                bll.Update(model);
                AM.Add_Logs("发票管理修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "CG_Account_Bill_List.aspx");
            }
            catch { }
        }
    }

    [Ajax.AjaxMethod]
    public string GetDetails(string s_TotalMoney, string s_PayMent, string STime)
    {
        string s_Return = "", s_Num = "";
        try
        {
            s_Return = "<Table id=\"myTable\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"5\" cellspacing=\"0\" class=\"crmTable\">";
            s_Return += "<tr valign=\"top\">";// "<td valign=\"top\" class=\"ListHead\" align=\"right\" nowrap><b>工具</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap> <b>金额</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap><b>超期天数</b></td>";
            s_Return += "<td class=\"ListHead\" nowrap><b>超期日期</b></td>";
            s_Return += "<td  class=\"ListHead\" nowrap><b>备注</b></td></tr>";
            if (s_TotalMoney != "")
            {
                decimal d_TotalMoney = decimal.Parse(s_TotalMoney);
                this.BeginQuery("Select * from PB_Basic_Payment where PBP_FID='" + s_PayMent + "'");
                this.QueryForDataTable();
                DataTable Dtb_Table = this.Dtb_Result;
                if (Dtb_Table.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                    {
                        decimal d_LMoney = decimal.Parse(s_TotalMoney == "" ? "0" : s_TotalMoney) * decimal.Parse(Dtb_Table.Rows[i]["PBP_Percent"].ToString());
                        int i_Days = int.Parse(Dtb_Table.Rows[i]["PBP_OutDays"].ToString());
                        DateTime D_Time = DateTime.Now;
                        if (STime != "")
                        {
                            try
                            {
                                D_Time = DateTime.Parse(STime);
                            }
                            catch
                            { }
                        }
                        D_Time = D_Time.AddDays(i_Days);
                        s_Return += "<tr valign=\"top\">"; //"<td class=\"ListHead\" nowrap><A onclick=\"deleteRow1(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" border=0></a></td>";
                        s_Return += "<td class=\"ListHeadDetails\" nowrap><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:150px;\" Name=\"D_Money_" + i.ToString() + "\" value=" + d_LMoney.ToString() + "></td>";
                        s_Return += "<td class=\"ListHeadDetails\" nowrap><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\';ChgDays()\" style=\"width:150px;\"  Name=\"D_OutDays_" + i.ToString() + "\" value=" + i_Days.ToString() + "></td>";
                        s_Return += "<td class=\"ListHeadDetails\" nowrap><input type=\"text\" class=\"Wdate\" OnFocus=\"WdatePicker()\" style=\"width:200px;\" Name=\"D_OutTime_" + i.ToString() + "\" value=" + D_Time.ToShortDateString() + " ></td>";
                        s_Return += "<td  class=\"ListHeadDetails\" nowrap><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:150px;\" Name=\"D_Remarks_" + i.ToString() + "\" ></td></tr>";
                    }
                    s_Num = Dtb_Table.Rows.Count.ToString();
                }
            }
            s_Return += " </table>";
            s_Return = s_Num + "$" + s_Return;
        }
        catch
        { }
        return s_Return;
    }
    protected void Btn_Serch_Click(object sender, EventArgs e)
    {
        if (this.Tbx_CheckNo.Text != "")
        {
            ShowCheckDetails(this.Tbx_CheckNo.Text);
        }
        else
        {
            string s_Details = ShowCheckDetails1("", this.Tbx_SuppNo.Value, "");
            string[] ss = s_Details.Split('|');
            this.Lbl_Detail.Text = ss[2];
            this.Lbl_Detail1.Text = ss[2];
        }
    }
}

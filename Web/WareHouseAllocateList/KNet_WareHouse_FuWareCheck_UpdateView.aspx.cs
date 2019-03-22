using KNet.Common;
using KNet.DBUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_WareHouseAllocateList_KNet_WareHouse_FuWareCheck_UpdateView : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string s_MyTable_Detail = "";
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            //string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();

            //string s_OrderNo = Request.QueryString["OrderNo"] == null ? "" : Request.QueryString["OrderNo"].ToString();

            //string s_SuppNo = Request.QueryString["SuppNo"] == null ? "" : Request.QueryString["SuppNo"].ToString();

            //this.Tbx_Type.Text = s_Type;
            //this.Tbx_SuppNo.Text = s_SuppNo;
            string s_Sql = " 1=1 ";
            string DoSql =
                      "select * from KNet_WareHouse_FuAllocateList  where AllocateNo='" + s_ID + "'";
            this.BeginQuery(DoSql);
            DataSet Dts = (DataSet)this.QueryForDataSet();
            this.AllocateDateTime.Text = Dts.Tables[0].Rows[0]["AllocateDateTime"].ToString();
            //this.Lbl_Title.Text = "新增调拨入库";

            base.Base_DropBasicCodeBind(this.Ddl_Type, "1132");
            base.Base_DropWareHouseBind(this.HouseNo_out, s_Sql);
            base.Base_DropWareHouseBind(this.HouseNo_int, s_Sql);

            AllocateNo.Text = s_ID;
            KPS_InvoiceUrl1.Text = Dts.Tables[0].Rows[0]["KWA_UploadUrl"].ToString();
            KPS_Invoice1.Text = Dts.Tables[0].Rows[0]["KWA_UploadName"].ToString();
            //this.Ddl_Type.SelectedValue = "1";
            this.HouseNo_out.SelectedValue = Dts.Tables[0].Rows[0]["HouseNo"].ToString();
            this.HouseNo_int.SelectedValue = Dts.Tables[0].Rows[0]["HouseNo_int"].ToString();
            this.Ddl_Type.SelectedValue = Dts.Tables[0].Rows[0]["KWA_DBType"].ToString();
            //this.Ddl_Type.Enabled = false;
            //this.HouseNo_out.Enabled = false;
            Tbx_OrderNo.Text = Dts.Tables[0].Rows[0]["KWA_OrderNo"].ToString();
            StringBuilder Sb_Details = new StringBuilder();
            Sb_Details.Append("<tr valign=\"top\">");
            Sb_Details.Append("<td valign=\"top\" class=\"ListHead\" align=\"right\" nowrap>");
            Sb_Details.Append("<b>工具</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>产品名称</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>产品编码</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>版本号</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>最小包装</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>包数</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>数量</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap>");
            Sb_Details.Append("<b>备注</b>");
            Sb_Details.Append("</td>");
            Sb_Details.Append("</tr>");

            this.Lbl_Details.Text = Sb_Details.ToString();
            if (s_ID != "")
            {
                string s_DoSql =
                    "select * from KNet_WareHouse_FuAllocateList a join KNet_WareHouse_FuAllocateList_Details b on a.AllocateNo=b.AllocateNo where a.AllocateNo='" + s_ID + "'";
                this.BeginQuery(s_DoSql);
                DataSet Dts_Details = (DataSet)this.QueryForDataSet();

                if (Dts_Details.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                    {
                        s_MyTable_Detail += "<tr>";
                        this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() +
                                                     ",";
                        s_MyTable_Detail +=
                            "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" +
                                            base.Base_GetProdutsName(
                                                Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) +
                                            "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" +
                                            base.Base_GetProductsCode(
                                                Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) +
                                            "</td>";
                        s_MyTable_Detail +=
                            "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" +
                            i.ToString() + "\" value='" +
                            Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" +
                            base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) +
                            "</td>";

                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" width=\"50px\"  >\n";

                        s_MyTable_Detail += "<input id=\"Tbx_CPBZNumber_" + i.ToString() +
                                            "\" type=\"input\" name=\"Tbx_CPBZNumber_" + i.ToString() +
                                            "\"  style=\"width:50px\" onblur=\"ChangPrice1(" + i.ToString() +
                                            ")\"    value=\"0\" />\n";

                        s_MyTable_Detail += "</td>\n";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" width=\"50px\"  >\n";
                        s_MyTable_Detail += "<input id=\"Tbx_BZNumber_" + i.ToString() +
                                            "\" type=\"input\" name=\"Tbx_BZNumber_" + i.ToString() +
                                            "\" onblur=\"ChangPrice1(" + i.ToString() +
                                            ")\"  style=\"width:50px\"  value=\"0\" />\n";

                        s_MyTable_Detail += "</td>\n";
                        s_MyTable_Detail +=
                            "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" +
                            i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["AllocateAmount"].ToString() +
                            "'></td>";

                        s_MyTable_Detail +=
                            "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Remarks_" +
                            i.ToString() + "\" ></td>";
                        s_MyTable_Detail += "</tr>";
                    }
                    this.Lbl_Details.Text += s_MyTable_Detail;
                    this.Tbx_Num.Text = Dts_Details.Tables[0].Rows.Count.ToString();
                }
            }


            if (AM.CheckLogin("新增直接入库") == false)
            {
                Response.Write(
                    "<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
        }
    }
    protected void button2_OnServerClick(object sender, EventArgs e)
    {
        if (!(uploadFile2.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            //string FileType = uploadFile1.PostedFile.ContentType.ToString(); //文件类型
            //GetThumbnailImage1();
            string UploadPath = "../../UpFile/SHUpload/";  //上传路径
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

    protected void Btn_Save_OnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.KNet_WareHouse_FuAllocateList BLL = new KNet.BLL.KNet_WareHouse_FuAllocateList();
        KNet.Model.KNet_WareHouse_FuAllocateList Model = new KNet.Model.KNet_WareHouse_FuAllocateList();

        string s_ID = this.Tbx_ID.Text;
        AdminloginMess LogAM = new AdminloginMess();
       
            if (this.FuSetValue(Model) == false)
            {
                Alert("系统错误！");
                return;
            }
      



        try
        {
           
                BLL.Update(Model);
            
            LogAM.Add_Logs("仓库--->入库通知--->调拨开单 修改 操作成功！通知单号：" + Model.AllocateNo);
            AlertAndRedirect("修改成功！", "KNet_WareHouse_FuAllocateList.aspx");
        }
       




        catch (Exception ex)
        {
            throw ex;
            Response.Write("<script>alert('调拨单添加失败！');history.back(-1);</script>");
            Response.End();
        }
    }
    private bool FuSetValue(KNet.Model.KNet_WareHouse_FuAllocateList molel)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            string AllocateNo = "";

            AllocateNo = this.AllocateNo.Text;
            this.TextBox1.Text = AllocateNo;



            string AllocateTopic = KNetPage.KHtmlEncode("");
            string AllocateCause = KNetPage.KHtmlEncode(this.AllocateCause.Text.Trim());

            DateTime AllocateDateTime = DateTime.Now;
            try
            {
                AllocateDateTime = DateTime.Parse(this.AllocateDateTime.Text.Trim());
            }
            catch
            {
            }

            string HouseNo_out = KNetPage.KHtmlEncode(this.HouseNo_out.SelectedValue);
            string HouseNo_int = KNetPage.KHtmlEncode(this.HouseNo_int.SelectedValue);

            if (HouseNo_out.ToLower() == HouseNo_int.ToLower())
            {
                Response.Write("<script>alert('错误！！\\n\\n调出仓库不能与调入仓库一样！');history.back(-1);</script>");
                Response.End();
            }
            string AllocateStaffBranch = "";
            string AllocateStaffDepart = "";
            string AllocateStaffNo = AM.KNet_StaffNo;
            string AllocateCheckStaffNo = "";
            string AllocateRemarks = KNetPage.KHtmlEncode(this.AllocateRemarks.Text.Trim());


            molel.AllocateNo = AllocateNo;
            molel.AllocateTopic = AllocateTopic;
            molel.AllocateCause = AllocateCause;
            if (this.Tbx_Type.Text == "1")
            {
                if (KPS_InvoiceUrl1.Text == "")
                {
                    Response.Write("<script language=javascript>alert('请上传送货单!');history.back(-1);</script>");
                    Response.End();
                }
            }

            molel.KWA_UploadName = KPS_Invoice1.Text;
            molel.KWA_UploadUrl = KPS_InvoiceUrl1.Text;
            molel.AllocateDateTime = AllocateDateTime;
            molel.HouseNo = HouseNo_out;
            molel.HouseNo_int = HouseNo_int;

            molel.KWA_Type = this.Tbx_Type.Text;
            molel.AllocateStaffBranch = AllocateStaffBranch;
            molel.AllocateStaffDepart = AllocateStaffDepart;

            molel.AllocateStaffNo = AllocateStaffNo;
            molel.AllocateCheckStaffNo = AllocateCheckStaffNo;
            molel.AllocateRemarks = AllocateRemarks;
            molel.AllocateCheckYN = 0;
            molel.AllocateTopic = "102"; //维修品调拨
            molel.KWA_OrderNo = this.Tbx_OrderNo.Text;
            molel.KWA_DBType = int.Parse(this.Ddl_Type.SelectedValue);

            ArrayList Arr_Products = new ArrayList();
            for (int i = 0; i < int.Parse(this.Tbx_Num.Text); i++)
            {

                if (Request["ProductsBarCode_" + i.ToString()] != null)
                {
                    string s_ProductsBarCode = Request.Form["ProductsBarCode_" + i.ToString()] == null
                        ? ""
                        : Request.Form["ProductsBarCode_" + i.ToString()].ToString();
                    string s_FaterBarCode = Request.Form["FaterBarCode_" + i.ToString()] == null
                        ? ""
                        : Request.Form["FaterBarCode_" + i.ToString()].ToString();

                    string s_Number = Request.Form["Number_" + i.ToString()] == ""
                        ? "0"
                        : Request.Form["Number_" + i.ToString()].ToString();

                    string s_Price = "0", s_Money = "0";
                    try
                    {
                        s_Price = Request.Form["Price_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["Price_" + i.ToString()].ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        s_Money = Request.Form["Money_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["Money_" + i.ToString()].ToString();

                    }
                    catch
                    {
                    }
                    if (decimal.Parse(s_Money) != 0)
                    {
                        try
                        {
                            s_Price = Convert.ToString(decimal.Parse(s_Money) / decimal.Parse(s_Number));
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        s_Money = Convert.ToString(decimal.Parse(s_Price) * decimal.Parse(s_Number));
                    }
                    string s_CPBZNumber = "0";
                    string s_BZNumber = "0";

                    try
                    {
                        s_CPBZNumber = Request.Form["Tbx_CPBZNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["Tbx_CPBZNumber_" + i.ToString()].ToString();
                        s_BZNumber = Request.Form["Tbx_BZNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["Tbx_BZNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                    }
                    string s_BadNumber = "0", s_AddBadNumber = "0", s_SDNumber = "0", s_BFNumber = "0";

                    try
                    {
                        s_BadNumber = Request.Form["BadNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["BadNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                    }

                    try
                    {
                        s_AddBadNumber = Request.Form["AddBadNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["AddBadNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                    }
                    try
                    {
                        s_SDNumber = Request.Form["SDNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["SDNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                    }
                    try
                    {
                        s_BFNumber = Request.Form["BFNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["BFNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                    }
                    string s_Remarks = Request.Form["Remarks_" + i.ToString()].ToString();
                    KNet.Model.KNet_WareHouse_FuAllocateList_Details Model_Details =
                        new KNet.Model.KNet_WareHouse_FuAllocateList_Details();
                    Model_Details.ID = GetNewID("KNet_WareHouse_FuAllocateList_Details", 1);
                    Model_Details.ProductsBarCode = s_ProductsBarCode;
                    Model_Details.AllocateNo = molel.AllocateNo;
                    Model_Details.AllocateAmount = int.Parse(s_Number);
                    try
                    {
                        Model_Details.KWAD_CPBZNumber = int.Parse(s_CPBZNumber);
                        Model_Details.KWAD_BZNumber = int.Parse(s_BZNumber);
                    }
                    catch
                    {
                        Model_Details.KWAD_CPBZNumber = 0;
                        Model_Details.KWAD_BZNumber = 0;
                    }
                    Model_Details.AllocateUnitPrice = decimal.Parse(s_Price);
                    Model_Details.AllocateTotalNet = decimal.Parse(s_Money);
                    Model_Details.AllocateRemarks = s_Remarks;
                    Model_Details.KWAD_FaterBarCode = s_FaterBarCode;
                    try
                    {
                        Model_Details.KWAD_SDNumber = int.Parse(s_SDNumber);
                    }
                    catch
                    {
                        Model_Details.KWAD_SDNumber = 0;
                    }
                    try
                    {
                        Model_Details.KWAD_BFNumber = int.Parse(s_BFNumber);
                    }
                    catch
                    {
                        Model_Details.KWAD_BFNumber = 0;
                    }

                    try
                    {
                        Model_Details.KWAD_BadNumber = int.Parse(s_BadNumber);
                    }
                    catch { Model_Details.KWAD_BadNumber = 0; }
                    try
                    {
                        Model_Details.KWAD_AddBadNumber = int.Parse(s_AddBadNumber);
                    }
                    catch { Model_Details.KWAD_AddBadNumber = 0; }
                    if (decimal.Parse(s_Number) != 0)
                    {
                        Arr_Products.Add(Model_Details);
                        molel.Arr_List = Arr_Products;
                    }

                }
            }


            ArrayList Arr_Products1 = new ArrayList();
            for (int i = 0; i < int.Parse(this.Tbx_Number1.Text); i++)
            {

                if (Request["MainProductsBarCode_" + i.ToString()] != null)
                {
                    string s_MainProductsBarCode = Request.Form["MainProductsBarCode_" + i.ToString()] == null ? "" : Request.Form["MainProductsBarCode_" + i.ToString()].ToString();

                    string s_MainNumber = Request.Form["MainNumber_" + i.ToString()] == "" ? "0" : Request.Form["MainNumber_" + i.ToString()].ToString();
                    string s_OrderID = Request.Form["OrderID_" + i.ToString()] == "" ? "" : Request.Form["OrderID_" + i.ToString()].ToString();

                    KNet.Model.KNet_WareHouse_AllocateList_CPDetails Model_Details1 = new KNet.Model.KNet_WareHouse_AllocateList_CPDetails();
                    Model_Details1.KWAC_ID = GetNewID("KNet_WareHouse_AllocateList_CPDetails", 1);
                    Model_Details1.KWAC_OrderNoID = s_OrderID;
                    Model_Details1.KWAC_AllocateNo = molel.AllocateNo;
                    try
                    {
                        Model_Details1.KWAC_Number = int.Parse(s_MainNumber);
                    }
                    catch
                    {
                        Model_Details1.KWAC_Number = 0;
                    }
                    Model_Details1.KWAC_Creator = AM.KNet_StaffNo;
                    Model_Details1.KWAC_CTime = DateTime.Now;

                    Arr_Products1.Add(Model_Details1);
                    molel.Arr_List1 = Arr_Products1;

                }
            }
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
            return false;
        }
    }
}
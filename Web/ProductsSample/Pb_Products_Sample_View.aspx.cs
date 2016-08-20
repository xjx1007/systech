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


public partial class Web_Pb_Products_Sample_View : BasePage
{
    public string s_OrderStyle = "", s_DetailsStyle = "", s_ProductsTable_BomDetail="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            this.Lbl_Title.Text = "查看样品申请";
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            if (s_ID != "")
            {
                ShowInfo(s_ID);
                ShowProductsDetails();
            }
            if (s_Type == "1")
            {
                s_OrderStyle = "class=\"dvtUnSelectedCell\"";
                s_DetailsStyle = "class=\"dvtSelectedCell\"";
                Pan_Order.Visible = false;
                Pan_Detail.Visible = true;
                Table_Btn.Visible = false;
            }
            else
            {
                s_DetailsStyle = "class=\"dvtUnSelectedCell\"";
                s_OrderStyle = "class=\"dvtSelectedCell\"";
                Pan_Order.Visible = true;
                Pan_Detail.Visible = false;
                Table_Btn.Visible = true;
            }
        }
       
    }

    private void ShowProductsDetails()
    {
        //Bom
        string s_ProductsBarCode = this.Tbx_ProductsBarCode.Text;
        string s_DemoProductsID = "";
        KNet.BLL.PB_Basic_ProductsClass BLL_Basic_ProductsClass = new KNet.BLL.PB_Basic_ProductsClass();
        KNet.BLL.Xs_Products_Prodocts_Demo BLL_DemoProducts_Products = new KNet.BLL.Xs_Products_Prodocts_Demo();

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * ");
        strSql.Append(" FROM PB_Basic_ProductsClass c ");
        strSql.Append(" left join (Select * from KNet_Sys_Products b");
        strSql.Append(" join  Xs_Products_Prodocts_Demo a on a.XPD_ProductsBarCode=b.ProductsBarCode   and XPD_FaterBarCode='" + s_ProductsBarCode + "'  ) bb on bb.ProductsType=c.PBP_ID  ");
        strSql.Append(" left join PB_Basic_Sample_ProductsDetails d on d.PBSP_ProductsType=c.PBP_ID and PBSP_FID='" + this.Tbx_ID.Text + "'  ");
        KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
        string s_SonID = Bll_ProductsDetails.GetSonIDs("M130703044937286");
        s_SonID = s_SonID.Replace("M130703044937286,", "");
        s_SonID = s_SonID.Replace(",", "','");
        string s_sql = "  PBP_ID in ('" + s_SonID + "','M130704023830654') ";
        strSql.Append(" where " + s_sql + "    Order by cast(PBP_Order as int)");
        DataSet Dts_DemoProducts = DbHelperSQL.Query(strSql.ToString());

        DataTable Dtb_DemoProducts = Dts_DemoProducts.Tables[0];
        if (Dtb_DemoProducts.Rows.Count > 0)
        {

            for (int i = 0; i < Dtb_DemoProducts.Rows.Count; i++)
            {
                s_DemoProductsID += Dtb_DemoProducts.Rows[i]["XPD_ProductsBarCode"].ToString() + ",";
                s_ProductsTable_BomDetail += "<tr>";
                s_ProductsTable_BomDetail += "<td class=\"ListHeadDetails\">" + Convert.ToString(i + 1) + "";
                s_ProductsTable_BomDetail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"   Name=\"ProductsType_" + i.ToString() + "\" value='" + Dtb_DemoProducts.Rows[i]["PBP_ID"].ToString() + "'><input type=\"input\"   Name=\"ProductsTypeName_" + i.ToString() + "\" value='" + BLL_Basic_ProductsClass.GetProductsName(Dtb_DemoProducts.Rows[i]["PBP_ID"].ToString()) + "'>";
                s_ProductsTable_BomDetail += "</td>";
                s_ProductsTable_BomDetail += "<td class='ListHeadDetails' ><input type=\"hidden\"   Name=\"SuppNo_" + i.ToString() + "\" value='" + Dtb_DemoProducts.Rows[i]["PBSP_SuppNo"].ToString() + "'><input type=\"input\"  Name=\"SuppName_" + i.ToString() + "\" value='" + Dtb_DemoProducts.Rows[i]["PBSP_SuppName"].ToString() + "'>";

                s_ProductsTable_BomDetail += "</td>";
                string s_ProductsEdition = Dtb_DemoProducts.Rows[i]["PBSP_ProductsEdition"].ToString();
                s_ProductsTable_BomDetail += "<td class='ListHeadDetails'><input type=\"input\"  size=\"40\"  Name=\"ProductsEdition_" + i.ToString() + "\" value=''></td>";
                string s_DemoNumber = Dtb_DemoProducts.Rows[i]["PBSP_Number"] == null ? "1" : Dtb_DemoProducts.Rows[i]["PBSP_Number"].ToString();
                s_ProductsTable_BomDetail += "<td class='ListHeadDetails'><input type=\"input\" class=\"detailedViewTextBox\" Name=\"DemoNumber_" + i.ToString() + "\" value='" + s_DemoNumber + "'></td>";
                string s_DemoPrice = Dtb_DemoProducts.Rows[i]["PBSP_Price"] == null ? "1" : Dtb_DemoProducts.Rows[i]["PBSP_Price"].ToString();
                s_ProductsTable_BomDetail += "<td class='ListHeadDetails'><input type=\"input\" class=\"detailedViewTextBox\"  Name=\"DemoPrice_" + i.ToString() + "\"  value='" + s_DemoPrice + "'></td>";
                string s_Remarks = Dtb_DemoProducts.Rows[i]["PBSP_Remarks"] == null ? "" : Dtb_DemoProducts.Rows[i]["PBSP_Remarks"].ToString();
                s_ProductsTable_BomDetail += "<td class='ListHeadDetails'><input type=\"input\" class=\"detailedViewTextBox\"  Name=\"DemoRemarks_" + i.ToString() + "\"  value='" + s_Remarks + "'></td>";
                s_ProductsTable_BomDetail += "</tr>";
            }
        }
        this.Products_BomID.Text = s_DemoProductsID;
        this.Products_BomNum.Text = Dtb_DemoProducts.Rows.Count.ToString();
    }
    private void ShowInfo(string s_ID)
    {
     
        KNet.BLL.Pb_Products_Sample bll = new KNet.BLL.Pb_Products_Sample();
        KNet.Model.Pb_Products_Sample model = bll.GetModel(s_ID);
        try
        {
            this.Tbx_ID.Text = s_ID;
            this.Lbl_Name.Text = model.PPS_Name;
            this.Lbl_Stime.Text = DateTime.Parse(model.PPS_Stime.ToString()).ToShortDateString();
            this.Lbl_CustomerValue.Text = base.Base_GetCustomerName_Link(model.PPS_CustomerValue);
            this.Lbl_LinkMan.Text = base.Base_GetLinMan_Link(model.PPS_LinkMan);
            
            this.Lbl_DutyPeson.Text = base.Base_GetUserName(model.PPS_DutyPeson);
            this.Lbl_Dept.Text = base.Base_GetBasicCodeName("124", model.PPS_Dept);
            this.Lbl_Requirement.Text = model.PPS_Requirement;
            this.Lbl_Remarks.Text = model.PPS_Remarks;
            this.Lbl_Shell.Text = model.PPS_Shell;
            this.Lbl_Number.Text = model.PPS_Number.ToString();
            this.Lbl_Use.Text = model.PPS_Use;

            this.CommentList1.CommentFID = model.PPS_ID;
            this.CommentList1.CommentType = 11;
            this.CommentList2.CommentFID = model.PPS_ID;
            this.CommentList2.CommentType = "ProductsSmaple";
            if (model.PPS_Appearance == "1")
            {
                this.Lbl_Appearance.Text = "喷漆";
            }
            else
            {
                this.Lbl_Appearance.Text = "不喷漆";
            }
            if (model.PPS_ResinMaterial == "1")
            {
                this.Lbl_ResinMaterial.Text = "喷油 ";
            }
            else
            {
                this.Lbl_ResinMaterial.Text = "不喷油 ";
            }
            this.Lbl_Resin.Text = model.PPS_Resin;
            this.Lbl_Chip.Text = model.PPS_Chip;
            KNet.BLL.Pb_Products_Sample_Images Bll_Images = new KNet.BLL.Pb_Products_Sample_Images();
            DataSet Dts_Table = Bll_Images.GetList(" PPI_SmapleID='" + model.PPS_ID + "' and PBI_Type='1' ");
            if (Dts_Table != null)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    Lbl_Details.Text += "<tr><td class=\"ListHeadDetails\" align=\"left\" nowrap><input type=\"hidden\"  Name=\"Tbx_PName_" + Convert.ToString(i + 1) + "\" value=" + Dts_Table.Tables[0].Rows[i]["PPI_Name"].ToString() + ">" + Dts_Table.Tables[0].Rows[i]["PPI_Name"].ToString() + "</td>";
                    Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap>";
                    Lbl_Details.Text += "<input Name=\"Image1Big_" + Convert.ToString(i + 1) + "\"  type=\"hidden\"  value=" + Dts_Table.Tables[0].Rows[i]["PPI_Url"].ToString() + "><A  target=\"_blank\" href=\"" + Dts_Table.Tables[0].Rows[i]["PPI_Url"].ToString() + "\"  >";
                    if (Dts_Table.Tables[0].Rows[i]["PPI_Url"].ToString().IndexOf(".jpg") > 0)
                    {
                        Lbl_Details.Text += "<Image ID=\"Image_" + Convert.ToString(i + 1) + "\" Src=\"" + Dts_Table.Tables[0].Rows[i]["PPI_Url"].ToString() + "\" Height=\"35px\"  border=0 />";

                    }
                    else
                    {
                        Lbl_Details.Text += Dts_Table.Tables[0].Rows[i]["PPI_Name"].ToString();
                    }
                    Lbl_Details.Text += "</a></td></tr>";
                }
                this.Tbx_num.Text = Dts_Table.Tables[0].Rows.Count.ToString();
            }
            this.BeginQuery("Select * from Pb_Products_Sample_Confim a left join Pb_Products_Sample_Images b on a.PBC_ID=b.PPI_SmapleId and PBI_Type='1' where PBC_SampleID='" + s_ID + "' ");
            this.QueryForDataTable();
            DataTable Dtb_Table = Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                string s_Details = "";
                int i_Num = 1;
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    string s_Row = GetRowCol(Dtb_Table.Rows[i]["PBC_ID"].ToString());
                    if (i > 0)
                    {
                        s_Details = Dtb_Table.Rows[i - 1]["PBC_ID"].ToString();
                    }
                    if (Dtb_Table.Rows[i]["PBC_ID"].ToString() != s_Details)
                    {
                        Lbl_QrDetails.Text += "<tr><td class=\"ListHeadDetails\" rowspan=" + s_Row + " align=\"left\" nowrap>" + i_Num.ToString() + "</td><td class=\"ListHeadDetails\" rowspan=" + s_Row + " align=\"left\" nowrap>" + base.Base_GetUserName(Dtb_Table.Rows[i]["PBC_Person"].ToString()) + "&nbsp;</td>";
                        Lbl_QrDetails.Text += "<td class=\"ListHeadDetails\" rowspan=" + s_Row + " align=\"left\" nowrap>" + Dtb_Table.Rows[i]["PBC_CTime"].ToString() + "&nbsp;</td>";
                        Lbl_QrDetails.Text += "<td class=\"ListHeadDetails\" rowspan=" + s_Row + " align=\"left\" nowrap>" + base.Base_GetBasicCodeName("124", Dtb_Table.Rows[i]["PBC_Type"].ToString()) + "&nbsp;</td>";
                        Lbl_QrDetails.Text += "<td class=\"ListHeadDetails\" rowspan=" + s_Row + " align=\"left\" nowrap>" + Dtb_Table.Rows[i]["PBC_Remarks"].ToString() + "&nbsp;</td>";
                        i_Num++;
                     }
                    else
                    {
                        Lbl_QrDetails.Text += "<tr>";
                    }
                    Lbl_QrDetails.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap>" + Dtb_Table.Rows[i]["PPI_Name"].ToString() + "</td>";
                    if (Dtb_Table.Rows[i]["PPI_URL"].ToString() != "")
                    {
                        string s_Url = Dtb_Table.Rows[i]["PPI_URL"].ToString();
                        string s_Name = Dtb_Table.Rows[i]["PPI_Name"].ToString();
                        Lbl_QrDetails.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap><a target=\"_blank\" href=\"" + Dtb_Table.Rows[i]["PPI_Url"].ToString() + "\">";
                        if (s_Url.IndexOf(".jpg") > 0)
                        {
                            Lbl_QrDetails.Text += "<Image ID=\"Image_i" + i.ToString() + "\" Src=" + Dtb_Table.Rows[i]["PPI_URL"].ToString() + " Height=\"50px\"  border=0/>";
                        }
                        else
                        {
                            Lbl_QrDetails.Text += s_Name;
                        }
                      Lbl_QrDetails.Text += "</a></td></tr>";
                    }
                    else
                    {
                        Lbl_QrDetails.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap>&nbsp;</td></tr>";
                    }
                   
                }
            }
            this.Lbl_NeedTime.Text = DateTime.Parse(model.PPS_Needtime.ToString()).ToShortDateString();
            this.Lbl_ProductsBar.Text = base.Base_GetProductsEdition_Link(model.PPS_ProductsBarCode);

            //产品
            KNet.BLL.KNet_Sys_Products Bll_Products = new KNet.BLL.KNet_Sys_Products();
            DataSet Dts_Table1 = Bll_Products.GetList(" KSP_SampleId='" + s_ID + "'");
            if (Dts_Table1.Tables[0].Rows.Count > 0)
            {
                string s_ProductsBarCode = Dts_Table1.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                Lbl_Products.Text = base.Base_GetProdutsName_Link(s_ProductsBarCode);
            }
        }
        catch(Exception ex)
        { }
    }
    private string GetRowCol(string s_ID)
    {
        string s_Return = "";
        try
        {
            this.BeginQuery("Select Count(*) From (Select * from Pb_Products_Sample_Confim a left join Pb_Products_Sample_Images b on a.PBC_ID=b.PPI_SmapleId and PBI_Type='1' where PBC_ID='" + s_ID + "') aa ");
            this.QueryForDataTable();
            DataTable Dtb_Table1 = Dtb_Result;
            if (Dtb_Table1.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table1.Rows.Count; i++)
                {
                    s_Return = Dtb_Table1.Rows[0][0].ToString();
                }
            }
        }
        catch
        { }
        return s_Return;
    }

}

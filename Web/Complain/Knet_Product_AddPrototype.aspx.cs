using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KNet.Model;
using System.Text;

public partial class Web_Complain_Knet_Product_AddPrototype : BasePage
{
    //public string s_MyTable_Detail = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            base.Base_DropBasicCodeBind(this.BClass, "1146");
            this.BClass.SelectedValue = "0";
            if (s_ID != "")
            {
                this.Tbx_ID.Text = s_ID;
                ShowInfo(s_ID);
            }
            base.Base_DropWareHouseBind(this.Ddl_HouseNo, "  KSW_Type=0 ");
            
        }
    }

    public void ShowInfo(string s_ID)
    {
        KNet.BLL.KNet_Product_Gauge bll = new KNet.BLL.KNet_Product_Gauge();
        KNet.Model.KNet_Product_Gauge modle = bll.GetModel(s_ID);
        KPG_KID.Text = modle.KPG_KID;
        KPG_Name.Text = modle.KPG_Name;
        KPG_Stime.Text = modle.KPG_Time.ToString();
        KPG_Number.Text = modle.KPG_Number.ToString();
        UploadUrl.Text = modle.KPG_UploadUrl;
        UploadUrlName.Text = modle.KPG_UploadName;
        Ddl_HouseNo.SelectedValue = modle.KPG_SuppNo;
        KPG_Text.Text = modle.KPG_Text;
        BClass.SelectedValue = modle.KPG_Type.ToString();
        this.BeginQuery("select * from KNet_Sys_Products where ProductsBarCode in(" + modle.KPG_ProductCode + ")");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        StringBuilder Sb_Details = new StringBuilder();
        try
        {
            if (Dtb_Re.Rows.Count > 0)
            {
                Tbx_Num.Text = Dtb_Re.Rows.Count.ToString();
                for (int i = 0; i < Dtb_Re.Rows.Count; i++)
                {
                    Sb_Details.Append("<tr>\n");
                    Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                    Sb_Details.Append(Convert.ToString(i + 1));
                    Sb_Details.Append("&nbsp;<A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"/themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a>\n");
                    Sb_Details.Append("</td>\n"); //序号

                    Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                    Sb_Details.Append("<input id=\"ProdoctsBarCode_" + i.ToString() + "\" type=\"hidden\" name=\"ProdoctsBarCode_" +
                                      i.ToString() + "\"  value=\"" + Dtb_Re.Rows[i]["ProductsBarCode"].ToString() + "\" />" +
                                      Dtb_Re.Rows[i]["ProductsBarCode"].ToString() + "\n");
                    Sb_Details.Append("</td>\n"); //料号

                    Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                    Sb_Details.Append("<input id=\"ProdoctName_" + i.ToString() + "\" type=\"hidden\" name=\"ProdoctName_" +
                                      i.ToString() + "\"  />" +
                                      Dtb_Re.Rows[i]["ProductsName"].ToString() + "\n");
                    Sb_Details.Append("</td>\n"); //物料名称

                    Sb_Details.Append("<td class=\"ListHeadDetails\" nowrap>\n");
                    Sb_Details.Append("<input id=\"ProdctsEdition_" + i.ToString() + "\" type=\"hidden\" name=\"ProdctsEdition_" +
                                      i.ToString() + "\"  />" + Base_GetProductsEdition_Link(Dtb_Re.Rows[i]["ProductsBarCode"].ToString()) + "\n");
                    Sb_Details.Append("</td>\n");


                }
                this.s_MyTable_Detail.Text = Sb_Details.ToString();
            }
        }
        catch 
        {

        }
       


    }

    protected void Btn_Save_OnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text!="")
            {
                this.BeginQuery("select * from KNet_Product_Gauge where KPG_KID='" + this.Tbx_ID.Text + "'");
                this.QueryForDataTable();
                DataTable Dtb_Re = Dtb_Result;
                if (Dtb_Re.Rows.Count>0)
                {
                    Alert("此治具编号已经存在，请找到这个编号编辑数量即可");
                    return;
                }
            }
            else
            {
                KNet.Model.KNet_Product_Gauge modle = new KNet_Product_Gauge();
                KNet.BLL.KNet_Product_Gauge bll = new KNet.BLL.KNet_Product_Gauge();
                modle.KPG_KID = this.KPG_KID.Text;
                modle.KPG_Name = this.KPG_Name.Text;
                modle.KPG_Number = int.Parse(this.KPG_Number.Text);
                modle.KPG_Person = AM.KNet_StaffNo;
                modle.KPG_Time = DateTime.Parse(this.KPG_Stime.Text);
                modle.KPG_Text = this.KPG_Text.Text;
                modle.KPG_SuppNo = Ddl_HouseNo.SelectedValue;
                modle.KPG_Type = int.Parse(BClass.SelectedValue);
                string ProdoctCodeList = "";
                if (this.Tbx_Num.Text != "0")
                {
                    for (int i = 0; i < int.Parse(this.Tbx_Num.Text); i++)
                    {
                        string KPG_Product = Request["ProdoctsBarCode_" + i.ToString() + ""] == null
                                ? ""
                                : Request["ProdoctsBarCode_" + i.ToString() + ""].ToString();
                        if (KPG_Product != "")
                        {
                            ProdoctCodeList += "'" + KPG_Product + "'" + ",";
                        }
                    }
                    modle.KPG_ProductCode = ProdoctCodeList.Substring(0, ProdoctCodeList.Length - 1);
                }
                else
                {
                    modle.KPG_ProductCode = "";
                }
                bll.Add(modle);
                //Alert("治具操作成功");
                AlertAndRedirect("治具操作成功 添加 ", "Knet_Product_Prototype_List.aspx");
            }
 
        }
        catch 
        {

            AlertAndRedirect("治具操作失败 添加 ", "Knet_Product_Prototype_List.aspx");
        }
       
        
    }
}
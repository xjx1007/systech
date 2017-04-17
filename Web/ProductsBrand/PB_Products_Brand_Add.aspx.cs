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

using KNet.DBUtility;
using KNet.Common;
using System.Data.SqlClient;
using System.Text;

public partial class PB_Products_Brand_Add : BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
           
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = s_ID;
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_SType = Request.QueryString["SType"] == null ? "" : Request.QueryString["SType"].ToString();
            string s_Table = Request.QueryString["Table"] == null ? "" : Request.QueryString["Table"].ToString();
 
            this.Tbx_Type.Text = s_Type;
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制产品品牌";
                }
                else
                {
                    this.Lbl_Title.Text = "修改产品品牌";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增产品品牌";
            }
        }

    }
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.PB_Products_Brand bll = new KNet.BLL.PB_Products_Brand();
        KNet.Model.PB_Products_Brand model = bll.GetModel(s_ID); 
        if (model != null)
        {
               // this.Tbx_ID.Text = model.PPB_ID.ToString();
                //this.Tbx_Code.Text = model.PPB_Code.ToString();
                this.Tbx_Name.Text = model.PPB_BrandName;
                this.Tbx_Remarks.Text = model.PPB_Remarks.ToString();

                //适用成品1
                StringBuilder Sb_Details = new StringBuilder();
                KNet.BLL.PB_Products_Brand_Details BLL_BrandDetails = new KNet.BLL.PB_Products_Brand_Details();
                DataSet Dts_BrandDetails = BLL_BrandDetails.GetList(" PPBD_FID='" + model.PPB_ID + "' ");
                DataTable Dtb_BrandDetails = Dts_BrandDetails.Tables[0];
                if (Dtb_BrandDetails.Rows.Count > 0)
                {

                    for (int i = 0; i < Dtb_BrandDetails.Rows.Count; i++)
                    {
                        Sb_Details.Append("<tr>");
                        Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dtb_BrandDetails.Rows[i]["PPBD_ProductsBarCode"].ToString()) + "</td>");
                        Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dtb_BrandDetails.Rows[i]["PPBD_ProductsBarCode"].ToString()) + "</td>");
                        Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dtb_BrandDetails.Rows[i]["PPBD_ProductsBarCode"].ToString()) + "</td>");
                        string s_DetailsID= Dtb_BrandDetails.Rows[i]["PPBD_ID"].ToString() ;
                        if (this.Tbx_Type.Text != "")
                        {
                            s_DetailsID = "";
                        }
                        Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"input\" class=\"detailedViewTextBox\" Name=\"Remarks_" + i.ToString() + "\" value='" + Dtb_BrandDetails.Rows[i]["PPBD_BrandName"].ToString() + "'><input type=\"hidden\" Name=\"ProductsBarCode_" + i.ToString() + "\"  value='" + Dtb_BrandDetails.Rows[i]["PPBD_ProductsBarCode"].ToString() + "'><input type=\"hidden\" Name=\"ID_" + i.ToString() + "\"  value='" + s_DetailsID + "'></td>");
                        Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"input\" class=\"detailedViewTextBox\" Name=\"BZNumber_" + i.ToString() + "\" value='" + Dtb_BrandDetails.Rows[i]["PPBD_BZNumber"].ToString() + "'></td>");
                        Sb_Details.Append("<td class=\"ListHeadDetails\"><A onclick=\"deleteRow2(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" border=0></a></td>");

                        Sb_Details.Append("</tr>");
                    }
                    this.Lbl_Details.Text = Sb_Details.ToString();
                    this.Products_BomNum.Text = Dtb_BrandDetails.Rows.Count.ToString();
                }
        }
    }

    private bool SetValue(KNet.Model.PB_Products_Brand model)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.PPB_ID = GetMainID();
            }
            else
            {
                model.PPB_ID = this.Tbx_ID.Text;
            }
            model.PPB_BrandName = this.Tbx_Name.Text;
            model.PPB_Remarks = this.Tbx_Remarks.Text.ToString();
            model.PPB_Del = 0;
            model.PPB_CTime = DateTime.Now;
            model.PPB_Creator = AM.KNet_StaffNo;
            model.PPB_MTime = DateTime.Now;
            model.PPB_Mender = AM.KNet_StaffNo;

            ArrayList arr_Details = new ArrayList();

            if (this.Products_BomNum.Text != "0")
            {
                for (int i = 0; i < int.Parse(this.Products_BomNum.Text) + 1; i++)
                {

                    string s_ProdoctsBarCode = Request.Form["ProductsBarCode_" + i.ToString() + ""] == null ? "" : Request.Form["ProductsBarCode_" + i.ToString() + ""].ToString();

                    string s_BzNumber = Request.Form["BzNumber_" + i.ToString() + ""] == null ? "0" : Request.Form["BzNumber_" + i.ToString() + ""].ToString();
                    string s_Remarks = Request.Form["Remarks_" + i.ToString() + ""] == null ? "" : Request.Form["Remarks_" + i.ToString() + ""].ToString();
                    string s_ID = Request.Form["ID_" + i.ToString() + ""] == null ? "" : Request.Form["ID_" + i.ToString() + ""].ToString();


                    if (s_ProdoctsBarCode != "")
                    {
                        KNet.Model.PB_Products_Brand_Details Model_BrandDetails = new KNet.Model.PB_Products_Brand_Details();
                        Model_BrandDetails.PPBD_ProductsBarCode = s_ProdoctsBarCode;
                        if (s_ID == "")
                        {
                            Model_BrandDetails.PPBD_ID = GetNewID("PB_Products_Brand_Details", 1);

                        }
                        else
                        {
                            Model_BrandDetails.PPBD_ID = s_ID;
 
                        }
                        Model_BrandDetails.PPBD_FID = model.PPB_ID;
                        try
                        {
                            Model_BrandDetails.PPBD_BZNumber = int.Parse(s_BzNumber);
                        }
                        catch
                        {
                            Model_BrandDetails.PPBD_BZNumber = 1;
                        }
                        Model_BrandDetails.PPBD_BrandName = s_Remarks;
                        arr_Details.Add(Model_BrandDetails);
                        model.Arr_Detail = arr_Details;
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
    protected void Btn_Send_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.PB_Products_Brand model = new KNet.Model.PB_Products_Brand();
        KNet.BLL.PB_Products_Brand bll = new KNet.BLL.PB_Products_Brand();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (this.Tbx_ID.Text != "")//修改
        {
            try
            {
                if (bll.Update(model))
                {
                 //   AM.Add_Logs("产品品牌修改" + this.Tbx_ID.Text);
                  //  base.Base_SendMessage(model.PBW_ID, "产品品牌： <a href='Web/Notice/PB_Products_Brand_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBW_ID + "</a> ");
                    AlertAndRedirect("修改成功！", "PB_Products_Brand_List.aspx");
                }
                else
                {
                    AM.Add_Logs("产品品牌修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "PB_Products_Brand_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            catch { }
        }
        else
        {
            try
            {
                if (bll.Exists(this.Tbx_Name.Text))
                {
                    AlertAndGoBack("不能添加相同品牌！");
                }
                else
                {

                    bll.Add(model);
                    // base.Base_SendMessage(model.PBN_ReceiveID, "产品品牌： <a href='Web/Notice/PB_Products_Brand_View.aspx?ID=" + model.PBN_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
                    AM.Add_Logs("产品品牌增加" + model.PPB_ID);
                    AlertAndRedirect("新增成功！", "PB_Products_Brand_List.aspx");
                }
            }
            catch { }
        }
    }
    private string GetCode()
    {
        AdminloginMess AM = new AdminloginMess();
        string s_Return = "";
        string s_Sql = "Select isnull(MAX(PPB_Code),'') from PB_Products_Brand  where year(PPB_Stime)=year(GetDate())";
        this.BeginQuery(s_Sql);
        string s_Code = this.QueryForReturn();
        if (s_Code == "")
        {
            s_Return = base.Base_GetCodeByTitle("产品品牌报告");
        }
        else
        {
            this.BeginQuery("Select Code from KNet_Resource_OrganizationalStructure where strucValue='" + AM.KNet_StaffDepart + "' ");
            string s_DepartCode = this.QueryForReturn();

            string s_Code1 = s_Code.Substring(0, 6);
            string s_Code2 = s_Code.Substring(8, 6);
            s_Return = s_Code1 +s_DepartCode+ Convert.ToString(int.Parse(s_Code2) + 1);
        }
        return s_Return;
    }
}

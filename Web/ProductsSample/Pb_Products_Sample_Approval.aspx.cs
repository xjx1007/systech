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



public partial class Web_ProductsSample_Pb_Products_Sample_Approval : BasePage
{
    public string s_ID = "", s_MyTable_Detail = "";
    public string s_ProductsTable_BomDetail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();

            this.Tbx_ID.Text = s_ID;
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            this.Tbx_STime.Text = DateTime.Now.ToShortDateString();
            base.Base_DropBasicCodeBind(this.Tbx_PicName, "137");
            KNet.BLL.Pb_Products_Sample Bll = new KNet.BLL.Pb_Products_Sample();
            KNet.Model.Pb_Products_Sample Model = Bll.GetModel(s_ID);
            this.Tbx_DutyPerson.Text = Model.PPS_DutyPeson;
            this.Lbl_Tiltle.Text = Model.PPS_Name;

            this.Lbl_Code.Text = Model.PPS_Code == null ? Model.PPS_ID : Model.PPS_Code;
            if (Model.PPS_Type == "1")//样品审批
            {
                if (Model.PPS_Dept == "0")
                {
                    base.Base_DropBasicCodeBindByWhere(this.Ddl_Type, "124", " and PBC_Code>0 and PBC_Code<3");
                    this.Ddl_Type.SelectedValue = "1";
                    Pan_Produts.Visible = false;
                }
                else if (Model.PPS_Dept == "1")
                {
                    base.Base_DropBasicCodeBindByWhere(this.Ddl_Type, "124", "  and PBC_Code In ('12','13')");
                    this.Ddl_Type.SelectedValue = "13";
                    Pan_Produts.Visible = false;
                }
                else if (Model.PPS_Dept == "2")
                {
                    base.Base_DropBasicCodeBindByWhere(this.Ddl_Type, "124", "  and PBC_Code In ('0')");
                    this.Ddl_Type.SelectedValue = "0";
                    Pan_Produts.Visible = false;
                }
            }
            else
            {
                try
                {
                    this.Pan_Details.Visible = true;

                    string s_Sql = " Select * from KNet_Sys_Products a  left join Pb_Products_Sample b on a.KSP_SampleId=b.PPS_ID where ProductsBarCode='" + Model.PPS_ProductsBarCode + "'";
                    this.BeginQuery(s_Sql);
                    DataTable Dts_Table = (DataTable)this.QueryForDataTable();
                    for (int i = 0; i < Dts_Table.Rows.Count; i++)
                    {
                        this.Lbl_ProductsDetails.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap>" + base.Base_GetProductsEdition_Link(Model.PPS_ProductsBarCode) + "</td>";
                        this.Lbl_ProductsDetails.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + Dts_Table.Rows[i]["PPS_Requirement"].ToString() + "</td>";
                        this.Lbl_ProductsDetails.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + Dts_Table.Rows[i]["ProductsDescription"].ToString() + "</td>";
                        this.Lbl_ProductsDetails.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + base.Base_GetHouseAndNumber(Model.PPS_ProductsBarCode) + "</td>";

                        string s_Details = "";
                        try
                        {
                            string s_Sql1 = "select v_OrderNo,wrkNumber from v_OrderRkDetailsQR where v_ProductsBarCode='" + Model.PPS_ProductsBarCode + "' and  wrkNumber>0";
                            this.BeginQuery(s_Sql1);
                            DataTable Dtb_Tabel1 = (DataTable)this.QueryForDataTable();
                            for (int j = 0; j < Dtb_Tabel1.Rows.Count; j++)
                            {
                                s_Details += "<a href=\"/Web/CG/Order/Knet_Procure_OpenBilling_View.aspx?ID=" + Dtb_Tabel1.Rows[j][0].ToString() + "\" target=\"_blank\" >" + Dtb_Tabel1.Rows[j][0].ToString() + "(" + Dtb_Tabel1.Rows[j][1].ToString() + ")<br/>";
                            }
                        }
                        catch
                        { }
                        this.Lbl_ProductsDetails.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + s_Details + "</td>";
                        this.Lbl_ProductsDetails.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + Model.PPS_DealDetails + "</td>";
                    }
                }
                catch
                { }
                if ((Model.PPS_Type == "2") && ((Model.PPS_Dept == "22") || (Model.PPS_Dept == "0")))//如果是设计修改 需要供应链平台审批
                {
                    base.Base_DropBasicCodeBindByWhere(this.Ddl_Type, "124", " and PBC_Code in ('21','22')");
                    this.Ddl_Type.SelectedValue = "21";
                    Pan_Produts.Visible = false;

                }
                else
                {
                    ShowProductsDetails();
                    if ((Model.PPS_Dept == "15"))
                    {
                        base.Base_DropBasicCodeBindByWhere(this.Ddl_Type, "124", " and PBC_Code>0 and PBC_Code<3");
                        this.Ddl_Type.SelectedValue = "1";
                        Pan_Produts.Visible = false;
                    }
                    else if ((Model.PPS_Dept == "9") || (Model.PPS_Dept == "20") || (Model.PPS_Dept == "21"))//部门审核
                    {
                        base.Base_DropBasicCodeBindByWhere(this.Ddl_Type, "124", " and PBC_Code In ('3','4','8')");
                        this.Ddl_Type.SelectedValue = "4";
                        Pan_Produts.Visible = true;
                        this.Tbx_PicName.SelectedValue = "0";
                    }
                    else if ((Model.PPS_Dept == "4"))//设计评审
                    {
                        base.Base_DropBasicCodeBindByWhere(this.Ddl_Type, "124", " and PBC_Code In ('5','7','19')");
                        this.Ddl_Type.SelectedValue = "7";
                        Pan_Produts.Visible = false;
                    }
                    else if ((Model.PPS_Dept == "12") || (Model.PPS_Dept == "18"))//样品确认
                    {
                        base.Base_DropBasicCodeBindByWhere(this.Ddl_Type, "124", " and PBC_Code In ('16','17')");
                        this.Ddl_Type.SelectedValue = "17";
                        Pan_Produts.Visible = false;
                    }
                    else if (Model.PPS_Dept == "0")
                    {
                        base.Base_DropBasicCodeBindByWhere(this.Ddl_Type, "124", " and PBC_Code In ('20','2')");
                        this.Ddl_Type.SelectedValue = "20";
                        Pan_Produts.Visible = false;
                    }
                    else if (Model.PPS_Dept == "5")//设计修改
                    {
                        base.Base_DropBasicCodeBindByWhere(this.Ddl_Type, "124", " and PBC_Code In ('3','6')");
                        this.Ddl_Type.SelectedValue = "6";
                        Pan_Produts.Visible = true;
                    }
                    else if (Model.PPS_Dept == "6")//设计修改评审
                    {
                        base.Base_DropBasicCodeBindByWhere(this.Ddl_Type, "124", " and PBC_Code In ('5','7','19')");
                        this.Ddl_Type.SelectedValue = "7";
                        Pan_Produts.Visible = false;
                    }
                    else if (Model.PPS_Dept == "16")//样品修改
                    {
                        base.Base_DropBasicCodeBindByWhere(this.Ddl_Type, "124", " and PBC_Code In ('18')");
                        this.Ddl_Type.SelectedValue = "18";
                        Pan_Produts.Visible = false;
                    }
                    else if (Model.PPS_Dept == "17")//样品修改
                    {
                        base.Base_DropBasicCodeBindByWhere(this.Ddl_Type, "124", " and PBC_Code In ('13','18')");
                        this.Ddl_Type.SelectedValue = "13";
                        Pan_Produts.Visible = false;
                    }
                    else if ((Model.PPS_Dept == "1") || (Model.PPS_Dept == "7"))//设计评审确认
                    {
                        base.Base_DropBasicCodeBindByWhere(this.Ddl_Type, "124", " and PBC_Code In ('3','6','8')");
                        this.Ddl_Type.SelectedValue = "8";
                        Pan_Produts.Visible = true;
                        this.Tbx_PicName.SelectedValue = "1";
                    }
                    else if (Model.PPS_Dept == "14")//申请审核
                    {
                        base.Base_DropBasicCodeBindByWhere(this.Ddl_Type, "124", " and PBC_Code In ('13','9')");
                        this.Ddl_Type.SelectedValue = "13";
                        Pan_Produts.Visible = true;
                    }
                    else if ((Model.PPS_Dept == "8") || (Model.PPS_Dept == "10") || (Model.PPS_Dept == "11"))//设计完成
                    {
                        base.Base_DropBasicCodeBindByWhere(this.Ddl_Type, "124", " and PBC_Code In ('9','10','11','12')");
                        if (Model.PPS_Dept == "10")
                        {
                            this.Ddl_Type.SelectedValue = "12";
                        }
                        else
                        {
                            this.Ddl_Type.SelectedValue = "10";
                        }
                        Pan_Produts.Visible = false;

                    }
                    else
                    {
                        Pan_Produts.Visible = true;
                        base.Base_DropBasicCodeBindByWhere(this.Ddl_Type, "124", " ");
                    }
                }
            }
            //if (AM.KNet_StaffDepart == "129652783965723459")//研发中心
            //{
            //    Pan_Produts.Visible = true;
            //}
            //else
            //{
            //    Pan_Produts.Visible = false;
            //}
            if (s_ID != "")
            {
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
                            Lbl_QrDetails.Text += "<td class=\"ListHeadDetails\" rowspan=" + s_Row + " align=\"left\" nowrap>" + Dtb_Table.Rows[i]["PBC_Remarks"].ToString() + "&nbsp;</td>";
                            i_Num++;
                        }
                        else
                        {
                            Lbl_QrDetails.Text += "<tr>";
                        }
                        Lbl_QrDetails.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap>" + Dtb_Table.Rows[i]["PPI_Name"].ToString() + "</td>";
                        Lbl_QrDetails.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap>" + base.Base_GetBasicCodeName("124", Dtb_Table.Rows[i]["PBC_Type"].ToString()) + "</td>";
                        if (Dtb_Table.Rows[i]["PPI_URL"].ToString() != "")
                        {
                            Lbl_QrDetails.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap><a target=\"_blank\" href=\"" + Dtb_Table.Rows[i]["PPI_Url"].ToString() + "\"><Image ID=\"Image_i" + i.ToString() + "\" Src=" + Dtb_Table.Rows[i]["PPI_URL"].ToString() + " Height=\"35px\"  border=0/></a></td></tr>";
                        }
                        else
                        {
                            Lbl_QrDetails.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap>&nbsp;</td></tr>";
                        }
                    }
                }

                //产品
                KNet.BLL.KNet_Sys_Products Bll_Products = new KNet.BLL.KNet_Sys_Products();
                DataSet Dts_Table = Bll_Products.GetList(" KSP_SampleId='" + s_ID + "'");
                if (Dts_Table.Tables[0].Rows.Count > 0)
                {
                    this.Tbx_ProductsBarCode.Text = Dts_Table.Tables[0].Rows[0]["ProductsBarCode"].ToString();
                    this.Tbx_ProductsName.Text = Dts_Table.Tables[0].Rows[0]["ProductsName"].ToString();
                    this.Tbx_ProductsEdition.Text = Dts_Table.Tables[0].Rows[0]["ProductsEdition"].ToString();
                    Lbl_Products.Text = base.Base_GetProdutsName_Link(this.Tbx_ProductsBarCode.Text);
                }

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
        strSql.Append(" left join PB_Basic_Sample_ProductsDetails d on d.PBSP_ProductsType=c.PBP_ID and PBSP_FID='"+this.Tbx_ID.Text+"'  ");
        KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
        string s_SonID = Bll_ProductsDetails.GetSonIDs("M160818111423567");
        s_SonID = s_SonID.Replace("M160818111423567,", "");
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
                s_ProductsTable_BomDetail += "<td class='ListHeadDetails' ><input type=\"hidden\"   Name=\"SuppNo_" + i.ToString() + "\" value='" + Dtb_DemoProducts.Rows[i]["PBSP_SuppNo"].ToString() + "'><input type=\"input\"  Name=\"SuppName_" + i.ToString() + "\" value='" + Dtb_DemoProducts.Rows[i]["PBSP_SuppName"].ToString() + "'><img src=\"../../themes/softed/images/select.gif\"  onclick=\"return btnGetSupp_onclick(" + i.ToString() + ")\" />";

                s_ProductsTable_BomDetail += "</td>";
                string s_ProductsEdition = Dtb_DemoProducts.Rows[i]["PBSP_ProductsEdition"].ToString();
                s_ProductsTable_BomDetail += "<td class='ListHeadDetails'><input type=\"input\"  size=\"40\"  Name=\"ProductsEdition_" + i.ToString() + "\" value=''></td>";
                string s_DemoNumber = Dtb_DemoProducts.Rows[i]["PBSP_Number"]==null?"1":Dtb_DemoProducts.Rows[i]["PBSP_Number"].ToString();
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
    private bool SetValue(KNet.Model.Pb_Products_Sample_Confim model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            model.PBC_ID = GetMainID();
            model.PBC_Type = this.Ddl_Type.SelectedValue;
            model.PBC_SampleID = this.Tbx_ID.Text;
            model.PBC_Person = this.Ddl_DutyPerson.SelectedValue;
            model.PBC_Remarks = this.Tbx_Remark.Text;
            model.PBC_Creator = AM.KNet_StaffNo;
            model.PBC_CTime = DateTime.Now;
            model.s_ProductsBarCode = this.Tbx_ProductsBarCode.Text;
            if (this.Tbx_STime.Text != "")
            {
                model.PBC_Stime = DateTime.Parse(this.Tbx_STime.Text);
            }
            ArrayList arr_Details = new ArrayList();
            if (this.Tbx_num.Text != "0")
            {
                int i_Num = int.Parse(this.Tbx_num.Text);
                for (int i = 0; i < i_Num; i++)
                {
                    KNet.Model.Pb_Products_Sample_Images Model_Details = new KNet.Model.Pb_Products_Sample_Images();
                    Model_Details.PPI_ID = base.GetMainID(i);
                    Model_Details.PPI_SmapleID = model.PBC_ID;
                    Model_Details.PPI_URL = Request["Image1Big_" + i.ToString() + ""] == null ? "" : Request["Image1Big_" + i.ToString() + ""].ToString();
                    Model_Details.PPI_Name = Request["Tbx_PName_" + i.ToString() + ""] == null ? "" : Request["Tbx_PName_" + i.ToString() + ""].ToString();
                    Model_Details.PBI_Type = "1";
                    Model_Details.PPI_CTime = DateTime.Now;
                    Model_Details.PPI_Creator = AM.KNet_StaffNo;
                    if (Model_Details.PPI_URL != "")
                    {
                        arr_Details.Add(Model_Details);
                    }
                }
            }
            model.arr_Details = arr_Details;
            model.s_Type = this.Ddl_Type.SelectedValue;
            ArrayList arr_Details1 = new ArrayList();
            if (this.Products_BomNum.Text != "0")
            {
                for (int i = 0; i < int.Parse(this.Products_BomNum.Text) + 1; i++)
                {
                    string s_ProductsType = Request.Form["ProductsType_" + i.ToString() + ""] == null ? "" : Request.Form["ProductsType_" + i.ToString() + ""].ToString();

                    string s_ProductsTypeName = Request.Form["ProductsTypeName_" + i.ToString() + ""] == null ? "" : Request.Form["ProductsTypeName_" + i.ToString() + ""].ToString();
                    string s_ProductsEdition = Request.Form["ProductsEdition_" + i.ToString() + ""] == null ? "" : Request.Form["ProductsEdition_" + i.ToString() + ""].ToString();

                    string s_DemoNumber = Request.Form["DemoNumber_" + i.ToString() + ""] == null ? "0" : Request.Form["DemoNumber_" + i.ToString() + ""].ToString();
                    string s_SuppNo = Request.Form["SuppNo_" + i.ToString() + ""] == null ? "" : Request.Form["SuppNo_" + i.ToString() + ""].ToString();
                    string s_SuppName = Request.Form["SuppName_" + i.ToString() + ""] == null ? "" : Request.Form["SuppName_" + i.ToString() + ""].ToString();
                    string s_DemoPrice = Request.Form["DemoPrice_" + i.ToString() + ""] == null ? "0" : Request.Form["DemoPrice_" + i.ToString() + ""].ToString();
                    string s_DemoRemarks = Request.Form["DemoRemarks_" + i.ToString() + ""] == null ? "" : Request.Form["DemoRemarks_" + i.ToString() + ""].ToString();

                    KNet.Model.PB_Basic_Sample_ProductsDetails Model_DemoProducts_Prodocts = new KNet.Model.PB_Basic_Sample_ProductsDetails();
                    Model_DemoProducts_Prodocts.PBSP_ID = GetNewID("PB_Basic_Sample_ProductsDetails", 1);
                    Model_DemoProducts_Prodocts.PBSP_FID = model.PBC_SampleID;
                    Model_DemoProducts_Prodocts.PBSP_ProductsType = s_ProductsType;
                    Model_DemoProducts_Prodocts.PBSP_ProductsTypeName = s_ProductsTypeName;
                    Model_DemoProducts_Prodocts.PBSP_SuppNo = s_SuppNo;
                    Model_DemoProducts_Prodocts.PBSP_SuppName = s_SuppName;
                    Model_DemoProducts_Prodocts.PBSP_ProductsEdition = s_ProductsEdition;
                    try
                    {
                        Model_DemoProducts_Prodocts.PBSP_Number = int.Parse(s_DemoNumber);
                        Model_DemoProducts_Prodocts.PBSP_Price = decimal.Parse(s_DemoPrice);
                    }
                    catch
                    {
                        Model_DemoProducts_Prodocts.PBSP_Number = 0;
                        Model_DemoProducts_Prodocts.PBSP_Price = 0;
                    }
                    Model_DemoProducts_Prodocts.PBSP_Remarks = s_DemoRemarks;
                    arr_Details1.Add(Model_DemoProducts_Prodocts);
                }
            }
            model.arr_Details1 = arr_Details1;
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

        KNet.Model.Pb_Products_Sample_Confim Model = new KNet.Model.Pb_Products_Sample_Confim();
        KNet.BLL.Pb_Products_Sample_Confim bll = new KNet.BLL.Pb_Products_Sample_Confim();

        if (this.SetValue(Model) == false)
        {
            Alert("系统错误！");
            return;
        }
        try
        {
            bll.Add(Model);
            AM.Add_Logs("审批成功" + this.Tbx_ID.Text);
            try
            {
                KNet.BLL.Pb_Products_Sample Bll_Sample = new KNet.BLL.Pb_Products_Sample();
                KNet.Model.Pb_Products_Sample Model_Sample = Bll_Sample.GetModel(Model.PBC_SampleID);
                if (Model_Sample.PPS_Type == "1")//样品审批
                {
                    if (this.Ddl_Type.SelectedValue == "1")//市场销售部通过审核
                    {
                        base.Base_SendMessage(Base_GetDeptPerson("物料部（仓库）", 0), KNetPage.KHtmlEncode("有 样品审核 <a href='Web/ProductsSample/Pb_Products_Sample_Approval.aspx?ID=" + this.Tbx_ID.Text + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + Model_Sample.PPS_Name + "</a> 通过市场销售部审核，敬请关注！"));
                    }
                    else if (this.Ddl_Type.SelectedValue == "2")//不通过审核
                    {
                        base.Base_SendMessage(this.Tbx_DutyPerson.Text, KNetPage.KHtmlEncode("不通过审核 <a href='web/ProductsSample/Pb_Products_Sample_Add.aspx?ID=" + this.Tbx_ID.Text + "&Type=M'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + Model_Sample.PPS_Name + "</a> ，敬请关注！"));
                    }

                }
                else
                {
                    if (this.Ddl_Type.SelectedValue == "1")//市场销售部通过审核
                    {
                        base.Base_SendMessage(Base_GetDeptPerson("研发中心", 1), KNetPage.KHtmlEncode("有 样品审核 <a href='Web/ProductsSample/Pb_Products_Sample_Approval.aspx?ID=" + this.Tbx_ID.Text + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + Model_Sample.PPS_Name + "</a> 通过市场销售部审核，敬请关注！"));
                    }
                    else if (this.Ddl_Type.SelectedValue == "7")//设计评审确认
                    {
                        base.Base_SendMessage(Base_GetDeptPerson("市场销售部", 1), KNetPage.KHtmlEncode("设计评审确认 <a href='Web/ProductsSample/Pb_Products_Sample_Approval.aspx?ID=" + this.Tbx_ID.Text + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + Model_Sample.PPS_Name + "</a> ，敬请关注！"));
                    }
                    else if (this.Ddl_Type.SelectedValue == "5")//设计修改
                    {
                        base.Base_SendMessage(Base_GetDeptPerson("研发中心", 1), KNetPage.KHtmlEncode("设计修改 <a href='Web/ProductsSample/Pb_Products_Sample_Approval.aspx?ID=" + this.Tbx_ID.Text + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + Model_Sample.PPS_Name + "</a> ，敬请关注！"));
                    }
                    else if (this.Ddl_Type.SelectedValue == "9")//市场销售部没通过审核
                    {
                        base.Base_SendMessage(this.Tbx_DutyPerson.Text, KNetPage.KHtmlEncode("样品 <a href='Web/ProductsSample/Pb_Products_Sample_Approval.aspx?ID=" + this.Tbx_ID.Text + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + Model_Sample.PPS_Name + "</a> 没有通过审核，敬请关注！"));
                    }
                    else if (this.Ddl_Type.SelectedValue == "15")//样品重新提交
                    {
                        base.Base_SendMessage(Base_GetDeptPerson("市场销售部", 1), KNetPage.KHtmlEncode("有 样品重新提交审核 <a href='Web/ProductsSample/Pb_Products_Sample_Approval.aspx?ID=" + this.Tbx_ID.Text + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + Model_Sample.PPS_Name + "</a> 通过市场销售部审核，敬请关注！"));
                    }
                    else if (this.Ddl_Type.SelectedValue == "4")//设计评审
                    {
                        base.Base_SendMessage(this.Tbx_DutyPerson.Text, KNetPage.KHtmlEncode("样品设计评审 <a href='Web/ProductsSample/Pb_Products_Sample_Approval.aspx?ID=" + this.Tbx_ID.Text + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + Model_Sample.PPS_Name + "</a> ，敬请关注！"));
                    }
                    else if (this.Ddl_Type.SelectedValue == "6")//设计修改评审
                    {
                        base.Base_SendMessage(this.Tbx_DutyPerson.Text, KNetPage.KHtmlEncode("设计修改评审 <a href='Web/ProductsSample/Pb_Products_Sample_Approval.aspx?ID=" + this.Tbx_ID.Text + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + Model_Sample.PPS_Name + "</a> ，敬请关注！"));
                    }
                    else if (this.Ddl_Type.SelectedValue == "14")//设计结束
                    {
                        base.Base_SendMessage(this.Tbx_DutyPerson.Text, KNetPage.KHtmlEncode("设计结束 <a href='Web/ProductsSample/Pb_Products_Sample_Approval.aspx?ID=" + this.Tbx_ID.Text + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + Model_Sample.PPS_Name + "</a> ，敬请关注！"));
                    }
                    else if (this.Ddl_Type.SelectedValue == "8")//设计完成
                    {
                        base.Base_SendMessage(Base_GetDeptPerson("质量部", 1), KNetPage.KHtmlEncode("设计完成 <a href='Web/ProductsSample/Pb_Products_Sample_Approval.aspx?ID=" + this.Tbx_ID.Text + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + Model_Sample.PPS_Name + "</a> ，敬请关注！"));
                    }
                    else if (this.Ddl_Type.SelectedValue == "2")//不通过审核
                    {
                        base.Base_SendMessage(this.Tbx_DutyPerson.Text, KNetPage.KHtmlEncode("不通过审核 <a href='web/ProductsSample/Pb_Products_Sample_Add.aspx?ID=" + this.Tbx_ID.Text + "&Type=M'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + Model_Sample.PPS_Name + "</a> ，敬请关注！"));
                    }
                    else if (this.Ddl_Type.SelectedValue == "10")//打烊中
                    {
                        base.Base_SendMessage(Base_GetDeptPerson("质量部", 1) + "," + this.Tbx_DutyPerson.Text, KNetPage.KHtmlEncode("打烊中 <a href='Web/ProductsSample/Pb_Products_Sample_View.aspx?ID=" + this.Tbx_ID.Text + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + Model_Sample.PPS_Name + "</a> ，敬请关注！"));
                    }
                    else if (this.Ddl_Type.SelectedValue == "11")//延迟打烊
                    {
                        base.Base_SendMessage(Base_GetDeptPerson("质量部", 1) + "," + this.Tbx_DutyPerson.Text, KNetPage.KHtmlEncode("延迟打烊 <a href='Web/ProductsSample/Pb_Products_Sample_View.aspx?ID=" + this.Tbx_ID.Text + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + Model_Sample.PPS_Name + "</a> ，敬请关注！"));
                    }
                    else if (this.Ddl_Type.SelectedValue == "12")//样品提交
                    {
                        base.Base_SendMessage(this.Tbx_DutyPerson.Text, KNetPage.KHtmlEncode("样品提交 <a href='Web/ProductsSample/Pb_Products_Sample_View.aspx?ID=" + this.Tbx_ID.Text + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + Model_Sample.PPS_Name + "</a> ，敬请关注！"));
                    }
                    else if (this.Ddl_Type.SelectedValue == "3")//设计结束
                    {
                        base.Base_SendMessage(this.Tbx_DutyPerson.Text, KNetPage.KHtmlEncode("设计结束 <a href='Web/ProductsSample/Pb_Products_Sample_View.aspx?ID=" + this.Tbx_ID.Text + "'  onclick=\"RemoveSms('" + base.GetNewID("System_Message_Manage", 0) + "', '', 0);\" target=\"_blank\"> " + Model_Sample.PPS_Name + "</a> ，敬请关注！"));
                    }
                }
            }
            catch
            { }

            AlertAndRedirect("审批成功！", "Pb_Products_Sample_List.aspx");


        }
        catch (Exception ex) { }
    }


    #region 图片上传操作
    /// <summary>
    /// 上传图片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void button_ServerClick(object sender, EventArgs e)
    {

        if (!(uploadFile.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
            //if (FileType == "image/gif" || FileType == "image/pjpeg")
            //{
            //}
            //else
            //{
            //    Alert("文件类型服务器不接受!");
            //}
            GetThumbnailImage();
        }
    }
    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage()
    {
        AdminloginMess AM = new AdminloginMess();
        if (this.Tbx_PicName.SelectedItem.Text == "")
        {
            Alert("请输入名称！");
        }
        else
        {
            string UploadPath = "../UpLoadPic/Sample/";  //上传路径

            string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
            string fileExt = Path.GetExtension(uploadFile.PostedFile.FileName); //获扩展名
            string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型

            string filePath = UploadPath + AM.KNet_StaffName + "/" + AutoPath + fileExt; //大文件名

            //if (FileType == "image/gif" || FileType == "image/pjpeg")
            //{
            //}
            //else
            //{
            //    Alert("文件类型服务器不接受!");
            //}
            if (!Directory.Exists(Server.MapPath(UploadPath + AM.KNet_StaffName + "/")))
            {

                Directory.CreateDirectory(Server.MapPath(UploadPath + AM.KNet_StaffName + "/"));
            }
            uploadFile.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
            Up_Loadcs UL = new Up_Loadcs();
            int i_Num = int.Parse(this.Tbx_num.Text);
            Lbl_Details.Text += "<tr><td valign=\"top\" class=\"ListHeadDetails\" align=\"left\" nowrap><a onclick=\"deleteRow(this)\" href=\"#\">";
            Lbl_Details.Text += "<img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=\"0\"></a></td>";
            Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap><input type=\"hidden\"  Name=\"Tbx_PName_" + i_Num + "\" value=" + this.Tbx_PicName.SelectedItem.Text + ">" + this.Tbx_PicName.SelectedItem.Text + "</td>";
            Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap><input Name=\"Image1Big_" + i_Num + "\"  type=\"hidden\"  value=" + filePath + "><a href=\"" + filePath + "\" target=\"_blank\"><Image ID=\"Image_" + i_Num + "\" Src=\"" + filePath + "\" Height=\"35px\"  border=\"0\" /></a></td></tr>";
            this.Tbx_PicName.Text = "";
            this.Tbx_num.Text = Convert.ToString(i_Num + 1);
            //Image1.ImageUrl = filePath;

        }
    }

    #endregion

}

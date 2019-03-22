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
using System.Runtime.Serialization.Json;

using KNet.DBUtility;
using KNet.Common;
using System.Net;

public partial class Web_Sales_Sales_ShipWareOut_Manage : BasePage
{
    //public string s_AdvShow = "",s_Tables_Details="";
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    if (!IsPostBack)
    //    {

    //        this.Tbx_ID.Text = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
    //        this.Tbx_DID.Text = Request.QueryString["DID"] == null ? "" : Request.QueryString["DID"].ToString();
    //        this.DataShow();

    //    }
    //}

    //private void DataShow()
    //{
    //    KNet.BLL.KNet_Sales_OutWareList Bll = new KNet.BLL.KNet_Sales_OutWareList();
    //    KNet.Model.KNet_Sales_OutWareList Model = Bll.GetModelB(this.Tbx_ID.Text);
    //    this.BeginQuery("Select *,DirectOutAmount+isnull(KWD_BNumber,0) as TotalNumber,c.ProductsType,c.ProductsName as CName,c.ProductsEdition From KNet_WareHouse_DirectOutList a  join KNet_WareHouse_DirectOutList_Details b on a.DirectOutNo=b.DirectOutNo join KNet_Sys_Products c on c.ProductsBarCode=b.ProductsBarCode where KWD_ShipNo='" + this.Tbx_ID.Text + "' and a.DirectOutNO='" + this.Tbx_DID.Text + "'");
    //    this.QueryForDataTable();
    //    DataTable Dtb_Table = Dtb_Result;
    //    int i_num = int.Parse(this.Tbx_Number.Text);
    //    string s_HouseNo = "", s_Code = "", s_Remarks = "";
    //    if (Dtb_Table.Rows.Count > 0)
    //    {
    //        this.Lbl_FPerson.Text = base.Base_GetUserName(Dtb_Table.Rows[i_num]["DirectOutStaffNO"].ToString());
    //        this.Lbl_CustomerName.Text = base.Base_GetCustomerName(Dtb_Table.Rows[i_num]["KWD_SCustomerValue"].ToString());
    //        this.Lbl_Customer.Text = base.Base_GetCustomerName(Dtb_Table.Rows[i_num]["KWD_Custmoer"].ToString());

    //        this.Lbl_CKTime.Text = DateTime.Parse(Dtb_Table.Rows[i_num]["DirectOutDateTime"].ToString()).ToShortDateString();
    //        s_HouseNo = Dtb_Table.Rows[i_num]["HouseNo"].ToString();
    //        for (int i = 0; i < Dtb_Table.Rows.Count; i++)
    //        {
    //            s_Tables_Details += " <tr>";
    //            s_Tables_Details += "<td align=\"center\" nowrap><b>" + (i + 1) + "</b></td>";
    //            s_Tables_Details += "<td class=\"ListHeadDetails\" align=\"center\"><b>" + Dtb_Table.Rows[i]["MaterNo"].ToString().Replace("?", "") + "</b></td>";
    //            s_Tables_Details += "<td class=\"ListHeadDetails\" align=\"center\"><b>" + Dtb_Table.Rows[i]["OrderNo"].ToString().Replace("?", "") + "</b></td>";
    //            s_Tables_Details += "<td class=\"ListHeadDetails\" align=\"center\"><b>" + Dtb_Table.Rows[i]["CustomerProductsName"].ToString().Replace("?", "") + "</b></td>";

    //            s_Tables_Details += "<td align=\"center\" nowrap><b>" + Dtb_Table.Rows[i]["CName"].ToString() + "</b></td>";
    //            s_Tables_Details += "<td class=\"ListHeadDetails\" align=\"center\"><b>" + Dtb_Table.Rows[i]["PlanNo"].ToString().Replace("?", "") + "</b></td>";
    //            s_Tables_Details += "<td class=\"ListHeadDetails\" align=\"center\"><b>" + Dtb_Table.Rows[i]["DirectOutAmount"].ToString() + "</b></td>";
    //            s_Tables_Details += "<td class=\"ListHeadDetails\" align=\"center\"><b>" + Dtb_Table.Rows[i]["KWD_BNumber"].ToString() + "</b></td>";
    //            s_Tables_Details += " </tr>";
    //            s_Remarks = Dtb_Table.Rows[i]["DirectOutRemarks"].ToString();
    //        }

    //    }
    //    KNet.BLL.KNet_Sys_WareHouse BLL_wareHouse = new KNet.BLL.KNet_Sys_WareHouse();
    //    KNet.Model.KNet_Sys_WareHouse Model_wareHouse = BLL_wareHouse.GetModel(s_HouseNo);
    //    if (Model_wareHouse != null)
    //    {
    //        KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
    //        KNet.Model.Knet_Procure_Suppliers Model_Supp = Bll_Supp.GetModelB(Model_wareHouse.SuppNo);
    //        if (Model_Supp != null)
    //        {

    //            s_Code = Model_Supp.SuppCode;
    //        }
    //    }
    //    this.Lbl_Code.Text = this.Tbx_DID.Text + "   " + s_Code + "";

    //    if (Model != null)
    //    {
    //        string s_MainCategory = "";
    //        try
    //        {
    //         s_MainCategory = base.Base_GetProdutsMainCategory(Dtb_Table.Rows[i_num]["ProductsBarCode"].ToString());
    //        }
    //        catch
    //        { }

    //        this.Lbl_Address.Text = Model.ContractToAddress;
    //        this.Lbl_LinkMan.Text = Model.KSO_ContentPersonName == "" ? base.Base_GetUserName(Model.OutWareSideContact) : Model.KSO_ContentPersonName;
    //        this.Lbl_Tel.Text = Model.KSO_TelPhone;
    //    }
    //    KNet.BLL.KNet_Sales_OutWareList_FlowList Bll_Flow = new KNet.BLL.KNet_Sales_OutWareList_FlowList();
    //    DataSet Dts_Tab = Bll_Flow.GetList(" OutWareNo='" + this.Tbx_ID.Text + "' and KDCode<>'' ");
    //    if (Dts_Tab.Tables[0].Rows.Count > 0)
    //    {

    //    }

    //}

    //protected void Btn_Next_Click(object sender, EventArgs e)
    //{
    //    this.BeginQuery("Select *,DirectOutAmount+isnull(KWD_BNumber,0) as TotalNumber From KNet_WareHouse_DirectOutList a join KNet_WareHouse_DirectOutList_Details b on a.DirectOutNo=b.DirectOutNo where KWD_ShipNo='" + this.Tbx_ID.Text + "' and a.DirectOutNO='" + this.Tbx_DID.Text + "'");
    //    this.QueryForDataTable();
    //    DataTable Dtb_Table = Dtb_Result;
    //    int i_num = int.Parse(this.Tbx_Number.Text);
    //    if ((i_num + 1) < Dtb_Table.Rows.Count)
    //    {
    //        this.Tbx_Number.Text = Convert.ToString(i_num + 1);
    //    }
    //    else if ((i_num + 1) == Dtb_Table.Rows.Count)
    //    {
    //        this.Tbx_Number.Text = "0";
    //    }
    //    else
    //    {
    //        this.Tbx_Number.Text = Convert.ToString(i_num - 1);
    //    }
    //    this.DataShow();
    //}
    public string s_MyTable_Detail = "", Tbx_ID = "", Tbx_DID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Tbx_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            Tbx_DID = Request.QueryString["DID"] == null ? "" : Request.QueryString["DID"].ToString();
            this.ShowInfo();

        }

    }



    private void ShowInfo()
    {
        try
        {
            KNet.BLL.KNet_Sales_OutWareList Bll = new KNet.BLL.KNet_Sales_OutWareList();
            KNet.Model.KNet_Sales_OutWareList Model = Bll.GetModelB(Tbx_ID);
            this.BeginQuery(
                "Select *,DirectOutAmount+isnull(KWD_BNumber,0) as TotalNumber,c.ProductsType,c.ProductsName as CName,c.ProductsEdition From KNet_WareHouse_DirectOutList a  join KNet_WareHouse_DirectOutList_Details b on a.DirectOutNo=b.DirectOutNo join KNet_Sys_Products c on c.ProductsBarCode=b.ProductsBarCode where KWD_ShipNo='" +
                Tbx_ID + "' and a.DirectOutNO='" + Tbx_DID + "'");
            this.QueryForDataTable();
            DataTable Dtb_Table = Dtb_Result;


            if (Dtb_Table.Rows.Count > 0)
            {
                string s_HouseNo = "", s_Code="";
                this.Lbl_CKTime.Text = DateTime.Parse(Dtb_Table.Rows[0]["DirectOutDateTime"].ToString()).ToShortDateString();
                s_HouseNo = Dtb_Table.Rows[0]["HouseNo"].ToString();
                KNet.BLL.KNet_Sys_WareHouse BLL_wareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                KNet.Model.KNet_Sys_WareHouse Model_wareHouse = BLL_wareHouse.GetModel(s_HouseNo);
                if (Model_wareHouse != null)
                {
                    KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
                    KNet.Model.Knet_Procure_Suppliers Model_Supp = Bll_Supp.GetModelB(Model_wareHouse.SuppNo);
                    if (Model_Supp != null)
                    {

                        s_Code = Model_Supp.SuppCode;
                    }
                }
                this.Lbl_Code.Text = Tbx_DID+ "   " + s_Code + "";
                if (Model != null)
                {


                    this.Lbl_Address.Text = Model.ContractToAddress;
                    this.Lbl_LinkMan.Text = Model.KSO_ContentPersonName == "" ? base.Base_GetUserName(Model.OutWareSideContact) : Model.KSO_ContentPersonName;
                    this.Lbl_Tel.Text = Model.KSO_TelPhone;
                }
                this.BeginQuery(
               "select ID,CustomerValue,CustomerName from KNet_Sales_ClientList where CustomerValue='"+ Dtb_Table.Rows[0]["KWD_Custmoer"].ToString() + "'");
                this.QueryForDataTable();
                DataTable Dtb_Table1 = Dtb_Result;
                this.Lbl_Customer.Text = Dtb_Table1.Rows[0]["CustomerName"].ToString();
                this.Lbl_FPerson.Text = base.Base_GetUserName(Dtb_Table.Rows[0]["DirectOutStaffNO"].ToString());
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    s_MyTable_Detail += " <tr>";
                    s_MyTable_Detail += "<td align=\"center\" nowrap><b>" + (i + 1) + "</b></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\"><b>" +
                                        Dtb_Table.Rows[i]["MaterNo"].ToString().Replace("?", "") + "</b></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\"><b>" +
                                        Dtb_Table.Rows[i]["OrderNo"].ToString().Replace("?", "") + "</b></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\"><b>" +
                                        Dtb_Table.Rows[i]["CustomerProductsName"].ToString().Replace("?", "") +
                                        "</b></td>";

                    s_MyTable_Detail += "<td align=\"center\" nowrap><b>" + Dtb_Table.Rows[i]["CName"].ToString() +
                                        "</b></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\"><b>" +
                                        Dtb_Table.Rows[i]["PlanNo"].ToString().Replace("?", "") + "</b></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\"><b>" +
                                        Dtb_Table.Rows[i]["DirectOutAmount"].ToString() + "</b></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\"><b>" +
                                        Dtb_Table.Rows[i]["KWD_BNumber"].ToString() + "</b></td>";
                    s_MyTable_Detail += " </tr>";
                    //s_Remarks = Dtb_Table.Rows[i]["DirectOutRemarks"].ToString();
                }

            }
        }
        catch 
        {
            
        }
    }

    //protected void Button1_OnClick(object sender, EventArgs e)
    //{
    //   Word.ApplicationClass wordApp=new Word.ApplicationClass();
    //    object missing = Missing.Value;
    //    object tempName = @"C:\Users\sg\Desktop\Normal.dot";
    //    object docName = @"C:\Users\sg\Desktop\test.doc";
    //    Word.Document MyDoc = wordApp.Documents.Add(ref tempName, ref missing, ref missing, ref missing);
    //    wordApp.Visible = true;
    //    MyDoc.Activate();
    //    wordApp.Selection.Font.Size = 14;
    //    wordApp.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
    //    wordApp.Selection.Font.Bold = (int) Word.WdConstants.wdToggle;
    //    wordApp.Selection.TypeText("helloword");
    //    MyDoc.SaveAs2(ref docName, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
    //    MyDoc.Close(ref missing,ref missing,ref missing);
    //    wordApp.Quit(ref missing,ref missing,ref missing);
    //    MyDoc = null;
    //    wordApp = null;

    //}
}

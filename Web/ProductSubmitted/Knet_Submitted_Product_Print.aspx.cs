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
using System.Data;
using System;

public partial class Web_ProductSubmitted_Knet_Submitted_Product_Print : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
        }

    }

    public string PCPrice(string productbarcode)
    {



        string sql = "select top 1 KPP_PCPrice from Knet_Procure_SuppliersPrice where ProductsBarCode='" + productbarcode + "' and KPP_State!=0 and  KPP_Del!=1";

        this.BeginQuery(sql);
        DataSet Dts_DemoProducts = (DataSet)this.QueryForDataSet();
        DataTable Dtb_DemoProducts = Dts_DemoProducts.Tables[0];
        string P = Dtb_DemoProducts.Rows[0][0].ToString();

        if (P == "")
        {
            P = "0";
        }
        return P;


    }
    public string GetResult(string KPD_SID,string ProductCode)
    {



        string sql = "select KPD_YNTState from Knet_Submitted_Product_Details where KPD_SID='"+ KPD_SID + "' and KPD_Code='"+ ProductCode + "'";

        this.BeginQuery(sql);
        DataSet Dts_DemoProducts = (DataSet)this.QueryForDataSet();
        DataTable Dtb_DemoProducts = Dts_DemoProducts.Tables[0];
        string P = Dtb_DemoProducts.Rows[0][0].ToString();

        if (P == "0")
        {
            P = "未检";
        }
        else if (P == "1")
        {
            P = "合格";
        }
        else if (P == "2")
        {
            P = "不良";
        }
        else if (P == "3")
        {
            P = "特采";
        }
        return P;


    }

    private void ShowInfo(string s_ID)
    {
        try
        {
            KNet.BLL.Knet_Submitted_Product BLL = new KNet.BLL.Knet_Submitted_Product();
            KNet.Model.Knet_Submitted_Product Model = BLL.GetModel(s_ID);
            this.Lbl_Code.Text = Model.KSP_SID;
            this.Lbl_Order.Text =Model.KSP_OrderNo;// DateTime.Parse(Model.KSP_Stime.ToString()).ToShortDateString()
            KNet.BLL.Knet_Procure_Suppliers BLL_Supp = new KNet.BLL.Knet_Procure_Suppliers();
            KNet.Model.Knet_Procure_Suppliers Model_Supp = BLL_Supp.GetModelB(Model.KSP_SuppNo);
            

            this.Lbl_SuppNo.Text = Model_Supp.SuppName;
           
            KNet.BLL.KNet_Resource_Staff BLL_STaff = new KNet.BLL.KNet_Resource_Staff();
            KNet.Model.KNet_Resource_Staff Model_STaff = BLL_STaff.GetModelC(Model.KSP_Proposer);
            this.Lbl_FromDetails.Text = base.Base_GeDept(Model_STaff.StaffBranch);
            this.Lbl_ToPepole.Text = Model_STaff.StaffName;
            this.Lbl_FromPepole.Text = DateTime.Parse(Model.KSP_Stime.ToString()).ToShortDateString();
           
            decimal d_All_OrderTotal = 0, d_All_HandTotal = 0, d_All_Total = 0;
           
                KNet.BLL.Knet_Submitted_Product_Details Bll_Details = new KNet.BLL.Knet_Submitted_Product_Details();
                DataSet Dts_Table = Bll_Details.GetList(" KPD_SID='" + Model.KSP_SID + "' ");

                if (Dts_Table.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                    {

                        s_MyTable_Detail += " <tr>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + (i + 1) + "</td>";
                       
                            //s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">成品</td>";

                      
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["KPD_Code"].ToString()) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" >" + base.Base_GetProdutsName_Link(Dts_Table.Tables[0].Rows[i]["KPD_Code"].ToString()) + "</td>";
                       
                            //s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" rowSpan=2>&nbsp;</td>";
                        
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" >" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["KPD_Code"].ToString()) + "</td>";

                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["KPD_Number"].ToString() + "</td>";
                       // decimal cont = 0;
                       
                            //cont = decimal.Parse(Dts_Table.Tables[0].Rows[i]["OrderAmount"].ToString());
                   
                        //s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(cont.ToString(), 0) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["KPD_CheckNumber"].ToString() + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["KPD_BadNumber"].ToString() + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + GetResult(Dts_Table.Tables[0].Rows[i]["KPD_SID"].ToString(), Dts_Table.Tables[0].Rows[i]["KPD_Code"].ToString()) + "</td>";
                       
                        //s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Amount.ToString(), 2) + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["KPD_Remark"].ToString() + "</td>";
                        s_MyTable_Detail += " </tr>";

                      

                        //this.Lbl_ProductsDetails.Text += Model_Products.ProductsDescription;
                    }
                }
           
          
        }
        catch
        { }
    }
}
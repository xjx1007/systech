using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Products_Procure_Sampling_View : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }

        }


    }

    private void ShowInfo(string s_ID)
    {
        try
        {
            string s_Sql = "";
            AdminloginMess AM=new AdminloginMess();
            KNet.BLL.Knet_Sampling_OpenBilling BLL = new KNet.BLL.Knet_Sampling_OpenBilling();
            KNet.Model.Knet_Sampling_OpenBilling Model = BLL.GetModel(s_ID);
            s_Sql = "Select *";
            s_Sql += " from Knet_Sampling_OpenBilling  ";
            s_Sql += "  Where ID in (" + s_ID.Substring(0, s_ID.Length - 1) + ") ";

            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            this.Lbl_Code.Text = DateTime.Now.ToShortDateString();
            this.Lbl_Stime.Text = AM.KNet_StaffName;
            this.Label1.Text = this.Lbl_Code.Text;
            this.Label2.Text = AM.KNet_StaffName;
            decimal d_All_OrderTotal = 0, d_All_HandTotal = 0, d_All_Total = 0;
           
           
              

                if (Dtb_Table.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                    {

                        s_MyTable_Detail += " <tr>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" >" + (i + 1) + "</td>";
                       
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dtb_Table.Rows[i]["ID"].ToString() + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" >" + Base_GetProjectGroup(Dtb_Table.Rows[i]["YID"].ToString()) + "</td>";
                       
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" >" + Base_GetSupplierName_Link(Dtb_Table.Rows[i]["Supplier"].ToString()) + "</td>";
                        
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" >" + Base_GetHouseName(Dtb_Table.Rows[i]["HouseNo"].ToString()) + "</td>";

                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dtb_Table.Rows[i]["SamplingName"].ToString() + "</td>";

                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dtb_Table.Rows[i]["Number"].ToString() + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.FormatNumber1(Dtb_Table.Rows[i]["Price"].ToString(), 3) + "</td>";
                        decimal d_Amount = decimal.Parse(Dtb_Table.Rows[i]["Price"].ToString())*
                                           decimal.Parse(Dtb_Table.Rows[i]["Number"].ToString());
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + d_Amount + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + Dtb_Table.Rows[i]["Remark"].ToString() + "</td>";

                        s_MyTable_Detail += " </tr>";

                        d_All_Total += d_Amount;

                        //this.Lbl_ProductsDetails.Text += Model_Products.ProductsDescription;
                    }
                }
            
            
                this.Lbl_AllCount.Text = "  总计：￥" + FormatNumber(d_All_Total.ToString(), 2) + "<br/>金额大写：" + base.ConvertMoney(d_All_Total);
                this.Label3.Text= "  总计：￥" + FormatNumber(d_All_Total.ToString(), 2) + "<br/>金额大写：" + base.ConvertMoney(d_All_Total);



        }
        catch
        { }
    }
    public string Base_GetProjectGroup(String s_ID)
    {

        String s_Name = "";
        this.BeginQuery("select top 1 ProjectGroup from KNet_Sampling_List where ID='" + s_ID + "'");
        this.QueryForDataTable();
        //this.BeginQuery("select * from PB_Basic_ProductsClass where PBP_ID='" + s_ID + "'");
        //this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            s_Name = base.Base_GetBasicCodeName("1137", Dtb_Re.Rows[0][0].ToString());
        }
        return s_Name;
    }
}
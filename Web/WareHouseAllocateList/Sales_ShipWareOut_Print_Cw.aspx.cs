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

public partial class Sales_ShipWareOut_Print_Cw : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("查看发货出库") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                this.Tbx_DID.Text = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"];
                this.Lbl_Code.Text = Request.QueryString["Num"] == null ? "" : Request.QueryString["Num"];
                string sql = "Update KNet_WareHouse_AllocateList set KWD_PrintNums=KWD_PrintNums+1 where AllocateNo='" + this.Tbx_DID.Text + "'";
                DbHelperSQL.ExecuteSql(sql);
                if (this.Tbx_DID.Text != "")
                {
                    KNet.BLL.KNet_WareHouse_AllocateList Bll = new KNet.BLL.KNet_WareHouse_AllocateList();
                    KNet.Model.KNet_WareHouse_AllocateList Model = Bll.GetModelB(this.Tbx_DID.Text);
                   // this.Tbx_ID.Text = Model.KWD_ShipNo;
                }
                this.DataShow();

            }
        }
    }

    private void DataShow()
    {
        AdminloginMess AM = new AdminloginMess();
        this.BeginQuery("Select * From KNet_WareHouse_AllocateList a join KNet_WareHouse_AllocateList_Details b on a.AllocateNo=b.AllocateNo where a.AllocateNO='" + this.Tbx_DID.Text + "' ");
        this.QueryForDataTable();
        DataTable Dtb_Table = Dtb_Result;
        int i_num = int.Parse(this.Tbx_Number.Text);
        if (Dtb_Table.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Table.Rows.Count; i++)
            {
                string s_Price = Dtb_Table.Rows[i]["AllocateUnitPrice"] == null ? "" : Dtb_Table.Rows[i]["AllocateUnitPrice"].ToString();
                string s_Money = Dtb_Table.Rows[i]["AllocateTotalNet"] == null ? "" : Dtb_Table.Rows[i]["AllocateTotalNet"].ToString();
                string s_Number=  Dtb_Table.Rows[i]["AllocateAmount"] == null ? "" : Dtb_Table.Rows[i]["AllocateAmount"].ToString();
                if (s_Price == "")
                {
                    s_Price = Convert.ToString(decimal.Parse(s_Money) / decimal.Parse(s_Number));
                }
                this.Lbl_Details.Text += "<tr height=\"38\">";
                this.Lbl_Details.Text += "<td class=\"style4\" nowrap>" + Convert.ToString(i + 1) + "</td>";
                this.Lbl_Details.Text += "<td class=\"style5\"  >" + base.Base_GetProdutsName(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>";

                this.Lbl_Details.Text += "<td class=\"style5\" nowrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                this.Lbl_Details.Text += "<td class=\"style10\"  >" + s_Number + "</td>";
                this.Lbl_Details.Text += "<td class=\"style5\" >" + base.FormatNumber(s_Price, 2) + "</td>";

                string s_RantTotal = base.FormatNumber(Convert.ToString(decimal.Parse(s_Number) * decimal.Parse(s_Price) * decimal.Parse("0.17")), 2);
                string s_LeftTotal = base.FormatNumber(Convert.ToString(decimal.Parse(base.FormatNumber(Convert.ToString(decimal.Parse(Dtb_Table.Rows[i]["AllocateAmount"].ToString()) * decimal.Parse(s_Price)), 2)) - decimal.Parse(s_RantTotal)), 2);
                this.Lbl_Details.Text += "<td class=\"style10\" >" + base.FormatNumber(Convert.ToString(decimal.Parse(Dtb_Table.Rows[i]["AllocateAmount"].ToString()) * decimal.Parse(s_Price)), 2) + "</td>";
                this.Lbl_Details.Text += "<td class=\"style9\" >" + s_RantTotal + "</td>";

                this.Lbl_Details.Text += "<td class=\"style9\" >" + s_LeftTotal + "</td>";
                this.Lbl_Details.Text += "<td class=\"style10\"  >&nbsp;</td>";
                this.Lbl_Details.Text += " </tr>";
            }
            this.Lbl_CkPerson.Text = AM.KNet_StaffName;
            this.Lbl_LinkMan.Text = base.Base_GetHouseName(Dtb_Table.Rows[i_num]["HouseNo_Int"].ToString());
            this.Lbl_FPerson.Text = base.Base_GetUserName(Dtb_Table.Rows[i_num]["AllocateStaffNO"].ToString());
            this.Lbl_CustomName.Text = base.Base_GetHouseName(Dtb_Table.Rows[i_num]["HouseNo"].ToString());
            // this.Lbl_ProductsName.Text = ;
            //// this.Lbl_Number.Text = Dtb_Table.Rows[i_num]["AllocateAmount"].ToString();
            // //this.Lbl_BNumber.Text = Dtb_Table.Rows[i_num]["KWD_BNumber"].ToString();
            // this.Lbl_TotalNumber.Text = Dtb_Table.Rows[i_num]["TotalNumber"].ToString();
            // this.Lbl_TotalNet.Text =;

            // this.Lbl_Price.Text = Dtb_Table.Rows[i_num]["KWD_SalesUnitPrice"].ToString();
            this.Lbl_CKTime.Text = DateTime.Parse(Dtb_Table.Rows[i_num]["AllocateDateTime"].ToString()).ToShortDateString();
            this.Lbl_Remarks.Text = Dtb_Table.Rows[i_num]["AllocateRemarks"].ToString()+"&nbsp;";


        }
        this.Lbl_Code.Text = this.Tbx_DID.Text + "  (" + this.Lbl_Code.Text + ")";


    }

    protected void Btn_Next_Click(object sender, EventArgs e)
    {
        this.BeginQuery("Select *,AllocateAmount+isnull(KWD_BNumber,0) as TotalNumber From KNet_WareHouse_AllocateList a join KNet_WareHouse_AllocateList_Details b on a.AllocateNo=b.AllocateNo where KWD_ShipNo='" + this.Tbx_ID.Text + "' and a.AllocateNO='" + this.Tbx_DID.Text + "'");
        this.QueryForDataTable();
        DataTable Dtb_Table = Dtb_Result;
        int i_num = int.Parse(this.Tbx_Number.Text);
        if ((i_num + 1) < Dtb_Table.Rows.Count)
        {
            this.Tbx_Number.Text = Convert.ToString(i_num + 1);
        }
        else if ((i_num + 1) == Dtb_Table.Rows.Count)
        {
            this.Tbx_Number.Text = "0";
        }
        else
        {
            this.Tbx_Number.Text = Convert.ToString(i_num - 1);
        }
        this.DataShow();
    }
}

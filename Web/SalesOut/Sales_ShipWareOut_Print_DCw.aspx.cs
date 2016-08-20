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

public partial class Sales_ShipWareOut_Print_DCw : BasePage
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
                string sql = "Update KNet_WareHouse_DirectOutList set KWD_DPrintNums=KWD_DPrintNums+1 where DirectOutNo='" + this.Tbx_DID.Text + "'";
                DbHelperSQL.ExecuteSql(sql);
                if (this.Tbx_DID.Text != "")
                {
                    KNet.BLL.KNet_WareHouse_DirectOutList Bll = new KNet.BLL.KNet_WareHouse_DirectOutList();
                    KNet.Model.KNet_WareHouse_DirectOutList Model = Bll.GetModelB(this.Tbx_DID.Text);
                    this.Tbx_ID.Text = Model.KWD_ShipNo;
                    this.Lbl_HoseNo.Text = base.Base_GetHouseName(Model.HouseNo);
                }
                this.DataShow();

            }
        }
    }

    private void DataShow()
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.KNet_Sales_OutWareList Bll = new KNet.BLL.KNet_Sales_OutWareList();
        KNet.Model.KNet_Sales_OutWareList Model = Bll.GetModelB(this.Tbx_ID.Text);
        this.BeginQuery("Select *,isnull(KWD_BNumber,0)+isnull(DirectOutAmount,0) as TotalNumber From KNet_WareHouse_DirectOutList a join KNet_WareHouse_DirectOutList_Details b on a.DirectOutNo=b.DirectOutNo where KWD_ShipNo='" + this.Tbx_ID.Text + "' and a.DirectOutNO='" + this.Tbx_DID.Text + "' ");
        this.QueryForDataTable();
        DataTable Dtb_Table = Dtb_Result;
        int i_num = int.Parse(this.Tbx_Number.Text);
        if (Dtb_Table.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Table.Rows.Count; i++)
            {
                string s_Price = Dtb_Table.Rows[i]["KWD_SalesUnitPrice"] == null ? "" : Dtb_Table.Rows[i]["KWD_SalesUnitPrice"].ToString();
                string s_Money=  Dtb_Table.Rows[i]["KWD_SalesTotalNet"] == null ? "" : Dtb_Table.Rows[i]["KWD_SalesTotalNet"].ToString();
                string s_Number = Dtb_Table.Rows[i]["TotalNumber"] == null ? "" : Dtb_Table.Rows[i]["TotalNumber"].ToString();
                if (s_Price == "")
                {
                    s_Price = Convert.ToString(decimal.Parse(s_Money) / decimal.Parse(s_Number));
                }
                this.Lbl_Details.Text += "<tr height=\"38\">";
                this.Lbl_Details.Text += "<td class=\"style4\" nowrap>" + Convert.ToString(i + 1) + "</td>";
                this.Lbl_Details.Text += "<td class=\"style5\"  >" + base.Base_GetProdutsName(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>";

                this.Lbl_Details.Text += "<td class=\"style5\" nowrap>" + base.Base_GetProductsEdition(Dtb_Table.Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                this.Lbl_Details.Text += "<td class=\"style10\"  >" + s_Number + "</td>";
                this.Lbl_Details.Text += "<td class=\"style10\" colspan=\"5\" >&nbsp;</td>";
                this.Lbl_Details.Text += " </tr>";
            }
            this.Lbl_CkPerson.Text = AM.KNet_StaffName;
            this.Lbl_Person.Text = base.Base_GetUserName(Model.DutyPerson);
            this.Lbl_FPerson.Text = base.Base_GetUserName(Dtb_Table.Rows[i_num]["DirectOutStaffNO"].ToString());
            this.Lbl_CustomName.Text = base.Base_GetCustomerName(Dtb_Table.Rows[i_num]["KWD_Custmoer"].ToString());
            // this.Lbl_ProductsName.Text = ;
            //// this.Lbl_Number.Text = Dtb_Table.Rows[i_num]["DirectOutAmount"].ToString();
            // //this.Lbl_BNumber.Text = Dtb_Table.Rows[i_num]["KWD_BNumber"].ToString();
            // this.Lbl_TotalNumber.Text = Dtb_Table.Rows[i_num]["TotalNumber"].ToString();
            // this.Lbl_TotalNet.Text =;
            // this.Lbl_Price.Text = Dtb_Table.Rows[i_num]["KWD_SalesUnitPrice"].ToString();
            this.Lbl_CKTime.Text = DateTime.Parse(Dtb_Table.Rows[i_num]["KWD_CWOutTime"].ToString()).ToShortDateString();
           // this.Lbl_Remarks.Text = Dtb_Table.Rows[i_num]["DirectOutRemarks"].ToString();


        }
        this.Lbl_Code.Text = this.Tbx_DID.Text + "  (" + this.Lbl_Code.Text + ")";

        if (Model != null)
        {
            string s_MainCategory = "";
            try
            {
                s_MainCategory = base.Base_GetProdutsMainCategory(Dtb_Table.Rows[i_num]["ProductsBarCode"].ToString());
            }
            catch
            { }
            string[] s_mater = Model.KSO_MaterNumber.Split(',');
            string[] s_OrderNo = Model.KSO_OrderNo.Split(',');
            this.Lbl_Address.Text = Model.ContractToAddress;
            this.Lbl_LinkMan.Text = Model.KSO_ContentPersonName == "" ? base.Base_GetUserName(Model.OutWareSideContact) : Model.KSO_ContentPersonName;

        }
    }

    protected void Btn_Next_Click(object sender, EventArgs e)
    {
        this.BeginQuery("Select *,DirectOutAmount+isnull(KWD_BNumber,0) as TotalNumber From KNet_WareHouse_DirectOutList a join KNet_WareHouse_DirectOutList_Details b on a.DirectOutNo=b.DirectOutNo where KWD_ShipNo='" + this.Tbx_ID.Text + "' and a.DirectOutNO='" + this.Tbx_DID.Text + "'");
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

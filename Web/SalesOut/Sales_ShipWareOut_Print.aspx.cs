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
    public string s_AdvShow = "",s_Tables_Details="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //AdminloginMess AM = new AdminloginMess();
            //if (AM.CheckLogin("查看发货出库") == false)
            //{

            //    Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
            //    Response.End();
            //}
            //else
            //{
                this.Tbx_ID.Text = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                this.Tbx_DID.Text = Request.QueryString["DID"] == null ? "" : Request.QueryString["DID"].ToString();
                this.DataShow();
            //}
        }
    }

    private void DataShow()
    {
        KNet.BLL.KNet_Sales_OutWareList Bll = new KNet.BLL.KNet_Sales_OutWareList();
        KNet.Model.KNet_Sales_OutWareList Model = Bll.GetModelB(this.Tbx_ID.Text);
        this.BeginQuery("Select *,DirectOutAmount+isnull(KWD_BNumber,0) as TotalNumber,c.ProductsType,c.ProductsName as CName,c.ProductsEdition From KNet_WareHouse_DirectOutList a  join KNet_WareHouse_DirectOutList_Details b on a.DirectOutNo=b.DirectOutNo join KNet_Sys_Products c on c.ProductsBarCode=b.ProductsBarCode where KWD_ShipNo='" + this.Tbx_ID.Text + "' and a.DirectOutNO='" + this.Tbx_DID.Text + "'");
        this.QueryForDataTable();
        DataTable Dtb_Table = Dtb_Result;
        int i_num = int.Parse(this.Tbx_Number.Text);
        string s_HouseNo="",s_Code="",s_Remarks ="";
        if (Dtb_Table.Rows.Count > 0)
        {
            this.Lbl_FPerson.Text = base.Base_GetUserName(Dtb_Table.Rows[i_num]["DirectOutStaffNO"].ToString());
            this.Lbl_CustomerName.Text = base.Base_GetCustomerName(Dtb_Table.Rows[i_num]["KWD_SCustomerValue"].ToString());
            this.Lbl_Customer.Text = base.Base_GetCustomerName(Dtb_Table.Rows[i_num]["KWD_Custmoer"].ToString());
            
            //this.Lbl_CustomName.Text = base.Base_GetCustomerName(Dtb_Table.Rows[i_num]["KWD_Custmoer"].ToString());
            //this.Lbl_ProductsName.Text = base.Base_GetProdutsName(Dtb_Table.Rows[i_num]["ProductsBarCode"].ToString());
            //this.Lbl_ProductsEdition.Text = base.Base_GetProductsEdition(Dtb_Table.Rows[i_num]["ProductsBarCode"].ToString());
            //this.Lbl_Number.Text = Dtb_Table.Rows[i_num]["DirectOutAmount"].ToString();
            //this.Lbl_BNumber.Text = Dtb_Table.Rows[i_num]["KWD_BNumber"].ToString();
            //this.Lbl_TotalNumber.Text = Dtb_Table.Rows[i_num]["TotalNumber"].ToString();
            this.Lbl_CKTime.Text = DateTime.Parse(Dtb_Table.Rows[i_num]["DirectOutDateTime"].ToString()).ToShortDateString();
            //this.Lbl_Remarks.Text =Dtb_Table.Rows[i_num]["DirectOutRemarks"].ToString();
            s_HouseNo =Dtb_Table.Rows[i_num]["HouseNo"].ToString();
            for (int i = 0; i < Dtb_Table.Rows.Count; i++)
            {
                s_Tables_Details += " <tr>";
                s_Tables_Details += "<td align=\"center\" nowrap><b>" + (i + 1) + "</b></td>";
                s_Tables_Details += "<td align=\"center\" nowrap><b>" + Dtb_Table.Rows[i]["CName"].ToString() + "</b></td>";
                s_Tables_Details += "<td align=\"center\" nowrap><b>" + Dtb_Table.Rows[i]["ProductsEdition"].ToString() + "</b></td>";
                s_Tables_Details += "<td class=\"ListHeadDetails\" align=\"center\"><b>" + Dtb_Table.Rows[i]["CustomerProductsName"].ToString().Replace("?", "") + "</b></td>";
                s_Tables_Details += "<td class=\"ListHeadDetails\" align=\"center\"><b>" + Dtb_Table.Rows[i]["DirectOutAmount"].ToString() + "</b></td>";
                s_Tables_Details += "<td class=\"ListHeadDetails\" align=\"center\"><b>" + Dtb_Table.Rows[i]["KWD_BNumber"].ToString() + "</b></td>";
                s_Tables_Details += "<td class=\"ListHeadDetails\" align=\"center\"><b>" + Dtb_Table.Rows[i]["TotalNumber"].ToString() + "</b></td>";
                s_Tables_Details += "<td class=\"ListHeadDetails\" align=\"center\"><b>" + Dtb_Table.Rows[i]["PlanNo"].ToString().Replace("?", "") + "</b></td>";
                s_Tables_Details += "<td class=\"ListHeadDetails\" align=\"center\"><b>" + Dtb_Table.Rows[i]["MaterNo"].ToString().Replace("?", "") + "</b></td>";
                s_Tables_Details += "<td class=\"ListHeadDetails\" align=\"center\"><b>" + Dtb_Table.Rows[i]["OrderNo"].ToString().Replace("?", "") + "</b></td>";
                s_Tables_Details += " </tr>";
                s_Remarks= Dtb_Table.Rows[i]["DirectOutRemarks"].ToString();
            }

        }
        KNet.BLL.KNet_Sys_WareHouse BLL_wareHouse=new KNet.BLL.KNet_Sys_WareHouse();
        KNet.Model.KNet_Sys_WareHouse Model_wareHouse = BLL_wareHouse.GetModel(s_HouseNo);
        if(Model_wareHouse!=null)
        {
            KNet.BLL.Knet_Procure_Suppliers Bll_Supp=new KNet.BLL.Knet_Procure_Suppliers();
            KNet.Model.Knet_Procure_Suppliers Model_Supp=Bll_Supp.GetModelB(Model_wareHouse.SuppNo);
            if(Model_Supp!=null)
            {
                
                s_Code=Model_Supp.SuppCode;
            }
        }
        this.Lbl_Code.Text =this.Tbx_DID.Text+"   "+s_Code+"";

        if (Model != null) 
        {
            string s_MainCategory="";
            try{
            s_MainCategory=base.Base_GetProdutsMainCategory(Dtb_Table.Rows[i_num]["ProductsBarCode"].ToString());
            }
            catch
            { }
            //string[] s_mater = Model.KSO_MaterNumber.Split(',');
            //string[] s_OrderNo = Model.KSO_OrderNo.Split(',');
            //if (s_MainCategory == "129678733470295462")//成品
            //{
            //    this.Lbl_MaterNumber.Text = s_mater[0];
            //    this.Lbl_OrderNo.Text = s_OrderNo[0];
            //}
            //else if (s_MainCategory == "129790301274394159")//电池
            //{
            //    this.Lbl_MaterNumber.Text = s_mater[1];
            //    this.Lbl_OrderNo.Text = s_OrderNo[1];
            //}
            //else
            //{
            //    this.Lbl_MaterNumber.Text = Model.KSO_MaterNumber.Replace(",","");
            //    this.Lbl_OrderNo.Text = Model.KSO_OrderNo.Replace(",", "");
            //}
            //this.Lbl_ShipType.Text = Model.KSO_ShipType;
            //this.Lbl_PlanNo.Text = Model.KSO_PlanNo;
            this.Lbl_Address.Text = Model.ContractToAddress;
            this.Lbl_LinkMan.Text = Model.KSO_ContentPersonName == "" ? base.Base_GetUserName(Model.OutWareSideContact) : Model.KSO_ContentPersonName;
            this.Lbl_Tel.Text = Model.KSO_TelPhone;
        }
        KNet.BLL.KNet_Sales_OutWareList_FlowList Bll_Flow=new KNet.BLL.KNet_Sales_OutWareList_FlowList();
        DataSet Dts_Tab=Bll_Flow.GetList(" OutWareNo='" + this.Tbx_ID.Text + "' and KDCode<>'' ");
        if (Dts_Tab.Tables[0].Rows.Count > 0)
        {
            this.Lbl_KDName.Text = Dts_Tab.Tables[0].Rows[0]["KDCodeName"].ToString();
            this.Lbl_KDCode.Text = Dts_Tab.Tables[0].Rows[0]["KDCode"].ToString();
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

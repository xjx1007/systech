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

using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

public partial class OrderList_View : BasePage
{
    public string s_Number = "",s_PlanDate="", s_ProductsPattern = "", s_SuppName = "", s_Type = "", s_Address = "", s_Time="", s_Company = "", s_Person = "", s_Telphone = "", s_Remarks = "";
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
            string OrderNo = Request.QueryString["OrderNo"].ToString();
            KNet.BLL.Knet_Procure_OrdersList bll = new KNet.BLL.Knet_Procure_OrdersList();
            KNet.Model.Knet_Procure_OrdersList model = bll.GetModelB(OrderNo);
            this.BeginQuery("Select * from Knet_Procure_OrdersList_Details Where OrderNo='" + OrderNo + "'");
            this.QueryForDataTable();
            if (Dtb_Result.Rows.Count > 0)
            {
                s_Number = Dtb_Result.Rows[0]["OrderAmount"].ToString();
                s_ProductsPattern = base.Base_GetProductsPattern(Dtb_Result.Rows[0]["ProductsBarCode"].ToString());
            }

            s_Remarks = model.OrderRemarks;
            s_PlanDate = DateTime.Parse(model.OrderPreToDate.ToString()).ToShortDateString();
            s_SuppName = base.Base_GetSupplierName(model.SuppNo);
            s_Type = s_ProductsPattern.Split('-')[0];
            string[] arr_s = model.ContractAddress.ToString().Split('\n');
            if (arr_s.Length > 1)
            {
                s_Address = arr_s[0].Replace(" ", "");
                s_Company=arr_s[1].Replace(" ", "");
                if (arr_s.Length > 2)
                {
                    s_Person = arr_s[2].Replace(" ", "");
                }
                if (arr_s.Length > 3)
                {
                    s_Telphone = arr_s[3].Replace(" ", "");
                }
            }
            s_Time = DateTime.Parse(model.OrderDateTime.ToString()).ToShortDateString();
            this.OrderNo.Text = model.OrderNo;
        }

    }
}   

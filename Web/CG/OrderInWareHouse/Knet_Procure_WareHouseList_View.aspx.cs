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


public partial class Web_Knet_Procure_WareHouseList_View : BasePage
{
    public string s_CustomerValue = "";
    public string s_LinkMan = "";
    public string s_OppID = "";
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            this.Lbl_Title.Text = "查看采购入库";
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (AM.YNAuthority("采购入库审批") == true)
            {
                this.btn_Chcek.Visible = true;
            }
            else
            {
                this.btn_Chcek.Visible = false;

            }
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
 
        }
       
    }

    protected void btn_Chcek_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (btn_Chcek.Text == "审批")
        {
            string DoSql = "update Knet_Procure_WareHouseList  set WareHouseCheckYN=1,WareHouseCheckStaffNo='" + AM.KNet_StaffNo + "',KPO_CheckTime='" + DateTime.Now.ToString() + "'  where  WareHouseNo='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "反审批";
        }
        else
        {
            string DoSql = "update Knet_Procure_WareHouseList  set WareHouseCheckYN=0,WareHouseCheckStaffNo ='',KPO_CheckTime=''  where  WareHouseNo='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "审批";
        }
        Alert("审批成功！");
    }
    private void ShowInfo(string s_ID)
    {
     
        try
        {
            KNet.BLL.Knet_Procure_WareHouseList bll = new KNet.BLL.Knet_Procure_WareHouseList();
            KNet.Model.Knet_Procure_WareHouseList model = bll.GetModelB(s_ID);
            this.Tbx_ID.Text = s_ID;
            this.Lbl_Code.Text = model.WareHouseNo;
            if (model.WareHouseDateTime != null)
            {
                if (model.WareHouseDateTime.ToString() == "1900-01-01")
                {
                    this.Lbl_Stime.Text = "";
                }
                else
                {
                    this.Lbl_Stime.Text = DateTime.Parse(model.WareHouseDateTime.ToString()).ToShortDateString();
                }
            }
            this.Lbl_OrderNo.Text = model.OrderNo;
            this.Lbl_SuppNo.Text = base.Base_GetSupplierName_Link(model.SuppNo);
            this.Lbl_Dept.Text = base.Base_GetHouseName(model.HouseNo);
            this.Lbl_Payment.Text = model.ShipDetials;
            this.Lbl_Remarks.Text = model.WareHouseRemarks;

            this.Lbl_CheckTime.Text = DateTime.Parse(model.KPO_CheckTime.ToString()).ToShortDateString();
            if (model.KPO_QRState == 0)
            {
                this.Lbl_QrState.Text = "<font color=red>未确认</font>";
            }
            else
            {
                this.Lbl_QrState.Text = "已确认";
                if (model.WareHouseCheckYN == 0)
                {
                    this.btn_Adjust.Visible = true;
                }
            }

            if (model.WareHouseCheckYN==1)
            {
                btn_Chcek.Text = "反审批";
            }
            else
            {
                btn_Chcek.Text = "审批";
            }
            if (model.WareHouseCheckYN == 2)
            {
                btn_Chcek.Visible = false;
            }
            else
            {
                btn_Chcek.Visible = true;
            }
            KNet.BLL.Knet_Procure_WareHouseList_Details BLL_Details = new KNet.BLL.Knet_Procure_WareHouseList_Details();
            DataSet Dts_Details = BLL_Details.GetList(" WareHouseNo='" + model.WareHouseNo + "'");
            if (Dts_Details.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    s_MyTable_Detail += "<tr>";
                    this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WareHouseAmount"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WareHouseBAmount"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WareHouseUnitPrice"].ToString() + "</td>";
                    try
                    {
                        decimal d_Money=decimal.Parse(Dts_Details.Tables[0].Rows[i]["WareHouseAmount"].ToString())*decimal.Parse(Dts_Details.Tables[0].Rows[i]["WareHouseUnitPrice"].ToString());
                        if (d_Money == 0)
                        {
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WareHouseTotalNet"].ToString() + "</td>";


                        }
                        else
                        {
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + d_Money.ToString() + "</td>";
 
                        }
                    }
                    catch
                    { }
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["WareHouseRemarks"].ToString() + "</td>";
                    s_MyTable_Detail += "</tr>";
                }
            }

        }
        catch
        {}
    }

    protected void btn_Adjust_Click(object sender, EventArgs e)
    {
        if (btn_Adjust.Text == "调账")
        {
            this.Lbl_Stime.Visible = false;
            this.txt_WareHouseDateTime.Visible = true;
            btn_Adjust.Text = "保存";
        }
        else
        {
            // Todo: 保存人库时间
            if (txt_WareHouseDateTime.Text != "")
            {
                string DoSql = "update Knet_Procure_WareHouseList  set WareHouseDateTime='" + txt_WareHouseDateTime.Text.ToString() + "'  where  WareHouseNo='" + this.Tbx_ID.Text + "' ";
                DbHelperSQL.ExecuteSql(DoSql);
                this.Lbl_Stime.Visible = true;
                this.txt_WareHouseDateTime.Visible = false;
                btn_Adjust.Text = "调账";
            }
            
        }
    }
}

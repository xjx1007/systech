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


public partial class Web_KNet_WareHouse_DirectOut_View : BasePage
{
    public string s_CustomerValue = "";
    public string s_LinkMan = "";
    public string s_OppID = "";
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看出库单";
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
            AdminloginMess AM = new AdminloginMess();
            KNet.BLL.KNet_WareHouse_DirectOutList bll = new KNet.BLL.KNet_WareHouse_DirectOutList();
            KNet.Model.KNet_WareHouse_DirectOutList model = bll.GetModelB(s_ID);
            this.Tbx_ID.Text = s_ID;
            this.Lbl_Code.Text = model.DirectOutNo;
            this.Lbl_Stime.Text = DateTime.Parse(model.DirectOutDateTime.ToString()).ToShortDateString();
            this.Lbl_House.Text = base.Base_GetHouseName(model.HouseNo);
            this.Lbl_Customer.Text = base.Base_GetCustomerName_Link(model.KWD_Custmoer);
            this.Lbl_ContentPerson.Text = base.Base_GetLinkManValue(model.KWD_ContentPerson, "XOL_Name") + "（电话：" + base.Base_GetLinkManValue(model.KWD_ContentPerson, "XOL_Phone") + "地址：" + base.Base_GetLinkManValue(model.KWD_ContentPerson, "XOL_Address") + "）";
            this.Lbl_Remarks.Text = model.DirectOutRemarks;

            this.Lbl_MailProducts.Text = base.Base_GetProductsEdition(model.KWD_MainProductsBarCode);
            this.Lbl_MailProductsNumber.Text = model.KWD_MainProductsNumber.ToString();

          this.Lbl_Project.Text= base.Base_GetBasicCodeName("779",model.KWD_Project);
          this.Lbl_LyTYpe.Text = base.Base_GetBasicCodeName("1135", model.KWD_LyType);
            this.Lbl_OEM.Text=base.Base_GetSupplierName_Link(model.KWD_SuppNo);
          if (model.KWD_IsSupp == 1)
          {

              Lbl_IsSuppNo.Text = "<font color=red>是</font>";
          }
          else
          {

              Lbl_IsSuppNo.Text = "否";
          }
            if (model.DirectOutCheckYN == 3)
            {

                btn_Chcek.Text = "反财务审批";
            }
            else
            {
                if (model.DirectOutCheckYN == 0)
                {

                    btn_Chcek.Text = "审批";
                }
                else
                {
                    btn_Chcek.Text = "反审批";

                    if (AM.YNAuthority("单据财务审批"))
                    {
                        this.btn_Chcek.Text = "财务审批";
                    }
                }

            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *,DirectOutAmount+Isnull(KWD_BNumber,0) as TotalNumber ");

            if (model.KWD_MainProductsBarCode != "")
            {
                strSql.Append(" ,isnull(b.BomOrder,'') BomOrder  ");
            }
            strSql.Append(" FROM KNet_WareHouse_DirectOutList_Details a ");

            if (model.KWD_MainProductsBarCode != "")
            {
                strSql.Append(" left join v_ProductsDemo_Details b on a.ProductsBarCode=b.XPD_ProductsBarCode and b.FaterBarCode in(select '" + model.KWD_MainProductsBarCode + "' union Select XPD_ProductsBarCode from Xs_Products_Prodocts_Demo where XPD_FaterBarCode='" + model.KWD_MainProductsBarCode + "')  ");
            }
            strSql.Append(" where DirectOutNo='" + model.DirectOutNo + "' ");

            if (model.KWD_MainProductsBarCode != "")
            {
                strSql.Append(" order by  isnull(BomOrderDesc,0) ");
            }

            this.BeginQuery(strSql.ToString());
            DataSet Dts_Details = (DataSet)this.QueryForDataSet();
            decimal d_Money = 0, d_Amount = 0,d_Money1 = 0;
            if (Dts_Details.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    s_MyTable_Detail += "<tr>";
                    this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Convert.ToString(i + 1) + "</td>";

                    if (model.KWD_MainProductsBarCode != "")
                    {
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["BomOrder"].ToString() + "</td>";
                    }
                    else
                    {
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">&nbsp;</td>";
                    }
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["DirectOutAmount"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["DirectOutUnitPrice"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["DirectOutTotalNet"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["KWD_WwPrice"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["KWD_WwMoney"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["DirectOutRemarks"].ToString() + "&nbsp;</td>";

                    s_MyTable_Detail += "</tr>";
                    d_Amount += int.Parse(Dts_Details.Tables[0].Rows[i]["DirectOutAmount"].ToString());
                    d_Money += decimal.Parse(Dts_Details.Tables[0].Rows[i]["DirectOutTotalNet"].ToString());
                    try
                    {
                        d_Money1 += decimal.Parse(Dts_Details.Tables[0].Rows[i]["KWD_WwMoney"].ToString());
                    }
                    catch
                    {
                        d_Money1 +=0;
                    }
                }
                s_MyTable_Detail += "<tr>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" colspan=5>总计：</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.FormatNumber1(d_Amount.ToString(), 0) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\">&nbsp;</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.FormatNumber1(d_Money.ToString(), 2) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\">&nbsp;</td>";

                s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.FormatNumber1(d_Money1.ToString(), 2) + "</td>";
                
                s_MyTable_Detail += "<td class=\"ListHeadDetails\">&nbsp;</td>";


                s_MyTable_Detail += "</tr>";
                this.Lbl_Details.Text = s_MyTable_Detail;
            }
        }
        catch
        { }
    }

    protected void btn_Chcek_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (btn_Chcek.Text == "财务审批")
        {
            string DoSql = "update KNet_WareHouse_DirectOutList  set DirectOutCheckYN=3,DirectOutCheckStaffNo='" + AM.KNet_StaffNo + "'  where  DirectOutNo='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "反财务审批";
            AM.Add_Logs("审批领料单号：" + this.Tbx_ID.Text);
        }

        else if (btn_Chcek.Text == "反财务审批")
        {
            string DoSql = "update KNet_WareHouse_DirectOutList  set DirectOutCheckYN=1,DirectOutCheckStaffNo='' where  DirectOutNo='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "财务审批";
            AM.Add_Logs("反审批领料单号：" + this.Tbx_ID.Text);
        }
        else if (btn_Chcek.Text == "审批")
        {
            string DoSql = "update KNet_WareHouse_DirectOutList  set DirectOutCheckYN=1,DirectOutCheckStaffNo='" + AM.KNet_StaffNo + "' where  DirectOutNo='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "反审批";
            AM.Add_Logs("反审批领料单号：" + this.Tbx_ID.Text);
        }
        else if (btn_Chcek.Text == "反审批")
        {
            string DoSql = "update KNet_WareHouse_DirectOutList  set DirectOutCheckYN=0,DirectOutCheckStaffNo='' where  DirectOutNo='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "审批";
            AM.Add_Logs("反审批领料单号：" + this.Tbx_ID.Text);
        }
        Alert("审批成功！");
    }
}

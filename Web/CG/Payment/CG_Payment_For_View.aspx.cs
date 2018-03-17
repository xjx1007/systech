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


public partial class Web_CG_Payment_For_View : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Lbl_Title.Text = "查看用款申请";
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
            this.Lbl_LinkPay.Text = "<a href=\"/Web/Pay/Cw_Accounting_Pay_Add.aspx?FID=" + s_ID + "\" class=\"webMnu\">创建付款单</a>";
        }
       
    }

    private void ShowInfo(string s_ID)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.CG_Payment_For bll = new KNet.BLL.CG_Payment_For();
        KNet.Model.CG_Payment_For model = bll.GetModel(s_ID);
        if (model != null)
        {
            this.Tbx_ID.Text = model.CPF_ID;
            this.Tbx_Used.Text = model.CPF_Used;
            try
            {
                this.Tbx_STime.Text = model.CPF_STime.ToShortDateString();
            }
            catch { }
            this.Ddl_Currency.Text = base.Base_GetBasicCodeName("401",model.CPF_Currency);
            this.Ddl_UseType.Text =base.Base_GetBasicCodeName("402",model.CPF_UseType); 
            this.Tbx_Money.Text = model.CPF_Lowercase.ToString();
            this.Tbx_ChineseMoney.Text = model.CPF_Capital;
            this.Tbx_PayeeValue.Value = model.CPF_SuppNo;
            this.Tbx_PayeeName.Text = model.CPF_SuppNoName;
            this.Lbl_ProductsType.Text = base.Base_GetProductsType(model.CPF_ProductsType);
            
            try
            {
                
                this.Tbx_YTime.Text = model.CPF_YTime.ToShortDateString();
            }
            catch { }
            
            try
            {

                this.Lbl_OutTime.Text = model.CPF_OutDateTime.ToShortDateString();
            }
            catch { }

            try
            {

                this.Lbl_Project.Text = model.CPF_ProjectName;
                this.Lbl_RepayMoney.Text = model.CPF_RepayMoney;
                this.Lbl_DdutyPerson.Text = base.Base_GetUserName(model.CPF_DDutyPerson);
            }
            catch { }
            this.Ddl_Depart.Text = base.Base_GeDept(model.CPF_DutyDepart);
            this.Ddl_DutyPerson.Text = base.Base_GetUserName(model.CPF_DutyPerson);
            this.Tbx_Remarks.Text = model.CPF_Remarks;
            this.Tbx_Details.Text = model.CPF_Details;
            this.Tbx_BankAccount.Text = model.CPF_Account;
            this.Tbx_BankName.Text = model.CPF_Bank;

            this.Tbx_Shen.Text = model.CPF_Shen;
            this.Tbx_Shi.Text = model.CPF_Shi;

            if (model.CPF_WuliuID != "")
            {
                ShowWuliuDetails(model.CPF_WuliuID);
                this.Pan_Wuliu.Visible = true;
            }
            else
            {
                this.Pan_Wuliu.Visible = false;
            }
            KNet.BLL.Cw_Accounting_Pay bll_Pay = new KNet.BLL.Cw_Accounting_Pay();
            DataSet ds = bll_Pay.GetList(" CAA_FID='" + s_ID + "'");
            this.MyGridView1.DataSource = ds;
            MyGridView1.DataKeyNames = new string[] { "CAA_ID" };
            MyGridView1.DataBind();

            if (model.CPF_Del == 0)
            {
                this.Button2.Text = "关闭";
            }
            else
            {
                this.Button2.Text = "启用";
            }
            if ((AM.KNet_StaffDepart == "129652784116845798") || (AM.KNet_StaffDepart == "129652783693249229") || (AM.KNet_StaffDepart == "130143946428906250") || (AM.KNet_StaffDepart == "129652784259578018"))//财务部
            {
                this.btn_Chcek.Visible = true;
                this.Button1.Visible = true;
                Tr_Sp.Visible = true;
            }
            else
            {
                this.btn_Chcek.Visible = false;
                this.Button1.Visible = false;
                Tr_Sp.Visible = false;
            }

            this.Image1.ImageUrl = model.CPF_Image;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            KNet.BLL.CG_Payment_For bll = new KNet.BLL.CG_Payment_For();
            KNet.Model.CG_Payment_For model = bll.GetModel(this.Tbx_ID.Text);
            if ((AM.KNet_StaffDepart == "129652784116845798") || (AM.KNet_StaffDepart == "130143946428906250") || (AM.KNet_StaffDepart == "129652784259578018"))//财务部
            {
                model.CPF_CwDateTime = DateTime.Now;
                model.CPF_CwPerson = AM.KNet_StaffNo;
                model.CPF_State = 3;
                bll.Update(model);
                AddFlow(this.Tbx_ID.Text, 1);
                base.Base_SendMessage(model.CPF_DutyPerson, "用款申请不通过： <a href='Web/CG/Payment/CG_Payment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.CPF_Used + "</a> 需要你审批！ ");

                AM.Add_Logs("用款申请审批：财务部:" + model.CPF_ID + "");
            }
            else if (AM.KNet_StaffDepart == "129652783693249229")//总经理
            {
                model.CPF_ZDateTime = DateTime.Now;
                model.CPF_ZPerson = AM.KNet_StaffNo;
                model.CPF_State = 4;
                bll.Update(model);
                AddFlow(this.Tbx_ID.Text, 2);
                base.Base_SendMessage(model.CPF_DutyPerson, "您的用款申请不通过： <a href='Web/CG/Payment/CG_Payment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.CPF_Used + "</a> 需要你审批！ ");
                AM.Add_Logs("用款申请审批：总经理:" + model.CPF_ID + "");
            }
            AlertAndClose("审批成功！");
        }
        catch { }
    }
    protected void btn_Chcek_Click(object sender, EventArgs e)
    {
        AdminloginMess AM=new AdminloginMess();
        try
        {
            KNet.BLL.CG_Payment_For bll = new KNet.BLL.CG_Payment_For();
            KNet.Model.CG_Payment_For model = bll.GetModel(this.Tbx_ID.Text);
            //130143946428906250 人事管理部
            if ((AM.KNet_StaffDepart == "129652784116845798") || (AM.KNet_StaffDepart == "130143946428906250") || (AM.KNet_StaffDepart == "129652784259578018"))//财务部
            {
                model.CPF_CwDateTime = DateTime.Now;
                model.CPF_CwPerson = AM.KNet_StaffNo;
                model.CPF_State = 1;
                bll.Update(model);
                AddFlow(this.Tbx_ID.Text, 1);

                if (AM.KNet_StaffDepart == "129652784259578018")//如果是供应链
                {
                    base.Base_SendMessage(base.Base_GetDeptPerson("财务部", 1), "用款申请审批： <a href='/Web/CG/Payment/CG_Payment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.CPF_Used + "</a> 需要你审批！ ");

                }
                else
                {
                    base.Base_SendMessage(base.Base_GetDeptPerson("总经理", 1), "用款申请审批： <a href='/Web/CG/Payment/CG_Payment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.CPF_Used + "</a> 需要你审批！ ");
                }

            }
            else if (AM.KNet_StaffDepart == "129652783693249229")//总经理
            {
                model.CPF_ZDateTime = DateTime.Now;
                model.CPF_ZPerson = AM.KNet_StaffNo;
                model.CPF_State = 2;
                AddFlow(this.Tbx_ID.Text, 2);
                bll.Update(model);
                base.Base_SendMessage(model.CPF_DutyPerson, "您的用款申请已通过： <a href='Web/CG/Payment/CG_Payment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.CPF_Used + "</a> 需要你审批！ ");
            }
            AlertAndClose("审批成功！");
        }
        catch { }
    }


    private bool AddFlow(string s_ContractNo, int i_State)
    {

        AdminloginMess AM = new AdminloginMess();
        //插入审核
        KNet.Model.KNet_Sales_Flow Model = new KNet.Model.KNet_Sales_Flow();
        KNet.BLL.KNet_Sales_Flow Bll = new KNet.BLL.KNet_Sales_Flow();
        Model.KFS_Type = 111;
        Model.KSF_ContractNo = s_ContractNo;
        Model.KSF_Date = DateTime.Now;
        Model.KSF_Detail = "";
        Model.KSF_ShPerson = AM.KNet_StaffNo;
        Model.KSF_State = i_State;
        try
        {
            if (Bll.Exists(Model) == false)
            {

                Bll.Add(Model);
                return true;
            }
            else
            {
                Alert("您已审核，请不要重复审核！");
                return false;
            }

        }
        catch
        {
            throw;
            return false;
        }
    }

    private string ShowWuliuDetails(string s_WuliuID)
    {
        decimal d_Total = 0, d_Total1 = 0, d_Total2 = 0, d_Total3 = 0, d_Total4 = 0;
        try
        {
            string s_Sql = "Select * from Xs_Sales_Freight a join KNET_WareHouse_DirectOutList b on a.XSF_FID=b.DirectOutNo ";
            s_Sql += " join Cg_Order_Checklist_Details c on a.XSF_ID=c.COD_DirectOutID ";
            s_Sql += " where COD_CheckNo='" + s_WuliuID + "'";
            this.BeginQuery(s_Sql);
            DataSet Dts_Table = (DataSet)this.QueryForDataSet();
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                s_MyTable_Detail += "";
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    s_MyTable_Detail += " <tr>";
                    string s_DirectOutNo = Dts_Table.Tables[0].Rows[i]["XSF_Code"].ToString();
                    string s_Address = Dts_Table.Tables[0].Rows[i]["KWD_Address"].ToString();

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"left\">" + s_DirectOutNo + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetHouseName(Dts_Table.Tables[0].Rows[i]["HouseNo"].ToString()) + "</td>";

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"left\">" + base.DateToString(Dts_Table.Tables[0].Rows[i]["XSF_Stime"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetShipDetailProductsPatten(Dts_Table.Tables[0].Rows[i]["XSF_FID"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetCustomerName_Link(Dts_Table.Tables[0].Rows[i]["KWD_Custmoer"].ToString()) + "</td>";

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" nowrap>" + base.Base_GetCityName(Dts_Table.Tables[0].Rows[i]["XSF_Province"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" nowrap>" + base.Base_GetShiName(Dts_Table.Tables[0].Rows[i]["XSF_City"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" nowrap>" + Dts_Table.Tables[0].Rows[i]["XSF_KDCode"].ToString() + "</td>";


                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_TotalNumber"].ToString(), 0) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_Weight"].ToString(), 0) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_WuliuPrice"].ToString(), 3) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_UpstairsCostMoney"].ToString(), 3) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_DeliveryFee"].ToString(), 3) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_WareHouseEntry150Low"].ToString(), 3) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_SignBill"].ToString(), 3) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_Insured"].ToString(), 3) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_TotalMoney"].ToString(), 3) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_FMoney"].ToString(), 3) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["XSF_Money"].ToString(), 3) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["COD_RealMoney"].ToString(), 3) + "</td>";


                    s_MyTable_Detail += "</tr>";
                    try
                    {
                        d_Total += decimal.Parse(Dts_Table.Tables[0].Rows[i]["XSF_TotalNumber"].ToString());
                        d_Total1 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["XSF_TotalMoney"].ToString());
                        d_Total2 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["XSF_FMoney"].ToString());
                        d_Total3 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["XSF_Money"].ToString());
                        d_Total4 += decimal.Parse(Dts_Table.Tables[0].Rows[i]["COD_RealMoney"].ToString());
                    }
                    catch
                    { }
                }
                s_MyTable_Detail += "<tr>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"left\" colspan=8>合计：</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total.ToString(), 0) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\" colspan=7>&nbsp;</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total1.ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total2.ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total3.ToString(), 3) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Total4.ToString(), 3) + "</td>";
                s_MyTable_Detail += "</tr>";
            }
        }
        catch
        { }
        return d_Total4.ToString();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        StringBuilder s_Sql = new StringBuilder();
        StringBuilder s_Log = new StringBuilder();
        try
        {
                    string s_ID = this.Tbx_ID.Text.ToString();
                    s_Sql.Append(" update CG_Payment_For set CPF_Del=ABS(CPF_Del-1) Where CPF_ID='" + s_ID + "' ");
                    s_Log.Append(s_ID);
            DbHelperSQL.ExecuteSql(s_Sql.ToString());
            AdminloginMess AM = new AdminloginMess();
            AM.Add_Logs("CG_Payment_For 停用 编号：" + s_Log + "");
            Alert("停用成功！");
        }
        catch (Exception ex)
        {
            Alert("停用失败！");
            return;
        }
    }
}

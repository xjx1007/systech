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


public partial class Web_Sales_CG_Payment_For_Add : BasePage
{
    public string s_MyTable_Detail = "",s_MyTable_Detail1="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("用款申请列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                string s_FID = Request.QueryString["FID"] == null ? "" : Request.QueryString["FID"].ToString();
                string s_OrderNo = Request.QueryString["OrderNo"] == null ? "" : Request.QueryString["OrderNo"].ToString();
                string s_WuliuID = Request.QueryString["WuliuID"] == null ? "" : Request.QueryString["WuliuID"].ToString();
                if (s_WuliuID != "")
                {
                    this.Tbx_WuliuID.Text = s_WuliuID;
                    this.Pan_Wuliu.Visible = true;
                    try
                    {

                        this.BeginQuery("Select * from CG_Payment_For a where a.CPF_WuliuID='" + s_WuliuID + "' ");
                        string s_wuliuID = this.QueryForReturn();
                        if (s_wuliuID != "")
                        {
                            AlertAndClose("该对账单已申请不要重复申请！");
                            return;
                        }
                        KNet.BLL.Cg_Order_Checklist Bll_Checklist = new KNet.BLL.Cg_Order_Checklist();
                        KNet.Model.Cg_Order_Checklist Model_Checklist = Bll_Checklist.GetModel(s_WuliuID);
                        KNet.BLL.KNet_Sys_WareHouse Bll_House = new KNet.BLL.KNet_Sys_WareHouse();
                        KNet.Model.KNet_Sys_WareHouse Model_House = Bll_House.GetModel(Model_Checklist.COC_HouseNo);
                        this.Tbx_Money.Text = ShowWuliuDetails(s_WuliuID);
                        this.Tbx_ChineseMoney.Text = ConvertMoney(decimal.Parse(this.Tbx_Money.Text));
                        this.Tbx_PayeeValue.Value = Model_House.SuppNo;
                        this.Tbx_PayeeName.Text = base.Base_GetSupplierName(Model_House.SuppNo);
                        KNet.BLL.Knet_Procure_Suppliers bll_Suppliers = new KNet.BLL.Knet_Procure_Suppliers();
                        KNet.Model.Knet_Procure_Suppliers Model_Suppliers = bll_Suppliers.GetModelB(Model_House.SuppNo);
                        this.Tbx_BankAccount.Text = Model_Suppliers.SuppBankAccount;
                        this.Tbx_BankName.Text = Model_Suppliers.SuppBankName;
                        this.Tbx_Shen.Text = GetSuppProvinceName(Model_Suppliers.SuppProvince);
                        this.Tbx_Shi.Text = GetSuppCityName(Model_Suppliers.SuppCity);
                        this.Tbx_Used.Text = base.Base_GetShortSupplierName(Model_Suppliers.SuppNo) + " 运费";

                    }
                    catch
                    { }
                }
                else
                {
                    this.Pan_Wuliu.Visible = false;
                }
                if(s_OrderNo!="")
                {
                    GetOrderDetails(s_OrderNo);
                }
                else
                {
                    this.Pan_OrderDetails.Visible = false;
                }
                this.Tbx_MainFID.Text = s_FID;

                this.Tbx_STime.Text = DateTime.Now.ToShortDateString();
                base.Base_DropBasicCodeBind(this.Ddl_Currency, "401");
                base.Base_DropBasicCodeBind(this.Ddl_UseType, "402");
                this.Ddl_Currency.SelectedValue = "0";
                base.Base_DropDutyPerson(this.Ddl_DutyPerson);
                base.Base_DropDutyPerson(this.DdL_DDutyPerson);
                
                base.Base_DropDepart(this.Ddl_Depart);
                this.Ddl_Depart.SelectedValue = AM.KNet_StaffDepart;
                this.Lbl_Title.Text = "新增用款申请";
                this.Image1.ImageUrl = "../../images/Nopic.jpg";
                this.Image1Big.Text = "../../images/Nopic.jpg";
                if (s_ID != "")
                {
                    if (s_Type == "1")
                    {
                        this.Tbx_ID.Text = "";
                        this.Lbl_Title.Text = "复制用款申请";
                    }
                    else
                    {
                        this.Lbl_Title.Text = "修改用款申请";
                        this.Tbx_ID.Text = s_ID;
                    }
                    this.Btn_Save.Text = "保存";
                    ShowInfo(s_ID);
                }

            }
        }
    }

    private void GetOrderDetails(string s_ID)
    {

        this.BeginQuery("Select * from CG_Payment_For a where a.CPF_FID='" + s_ID + "' ");
        string s_wuliuID = this.QueryForReturn();
        if (s_wuliuID != "")
        {
            AlertAndClose("该订单已申请不要重复申请！");
            return;
        }
        KNet.BLL.Knet_Procure_OrdersList Bll = new KNet.BLL.Knet_Procure_OrdersList();
        KNet.Model.Knet_Procure_OrdersList Model = Bll.GetModelB(s_ID);

         KNet.BLL.Knet_Procure_OrdersList_Details Bll_Details = new KNet.BLL.Knet_Procure_OrdersList_Details();
        DataSet Dts_Table = Bll_Details.GetList(" a.OrderNo='" + s_ID + "' order by isnull(e.XPD_Order,0)");

        decimal d_All_OrderTotal = 0, d_All_HandTotal = 0, d_All_Total = 0, d_All_TotalNeNum = 0, d_All_WrkTotalNeNum = 0;
        bool b_boll = false;
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                decimal d_Amount = Decimal.Parse(Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString()) + Decimal.Parse(Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString());
                d_All_OrderTotal += Decimal.Parse(Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["OrderTotalNet"].ToString());
                d_All_HandTotal += Decimal.Parse(Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["HandTotal"].ToString());
                d_All_Total += d_Amount;
                s_MyTable_Detail1 += " <tr>";
                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + Convert.ToString(i + 1) + "</td>";
                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["XPD_Order"].ToString() + "</td>";

                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProdutsName_Link(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail1 += "<td  class=\"ListHeadDetails\" align=\"center\">" + base.Base_GetProductsCode(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail1 += "<td  class=\"ListHeadDetails\" nowrap align=\"center\">" + base.Base_GetProductsEdition(Dts_Table.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["KPOD_CPBZNumber"].ToString(), 0) + "</td>";
                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["KPOD_BZNumber"].ToString(), 0) + "</td>";

                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["OrderAmount"].ToString(), 0) + "</td>";
                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["OrderUnitPrice"].ToString(), 4) + "</td>";
                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(Dts_Table.Tables[0].Rows[i]["HandPrice"].ToString(), 4) + "</td>";
                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_Amount.ToString(), 3) + "</td>";
                string s_WrkNumber= FormatNumber1(Dts_Table.Tables[0].Rows[i]["wrkNumber"].ToString() == "" ? "0" : Dts_Table.Tables[0].Rows[i]["wrkNumber"].ToString(), 0) ;
                d_All_WrkTotalNeNum += int.Parse(s_WrkNumber);
                d_All_TotalNeNum += int.Parse(Dts_Table.Tables[0].Rows[i]["OrderAmount"].ToString());
                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + s_WrkNumber + "</td>";
                s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + Dts_Table.Tables[0].Rows[i]["OrderRemarks"].ToString() + "</td>";
            
                s_MyTable_Detail1 += " </tr>";

            }

            s_MyTable_Detail1 += " <tr>";
            s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\" colspan=7>合计：</td>";
            s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_All_TotalNeNum.ToString(), 0) + "</td>";

            s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\" colspan=2>&nbsp;</td>";
            s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_All_Total.ToString(), 2) + "</td>";
            s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">" + FormatNumber(d_All_WrkTotalNeNum.ToString(), 0) + "</td>";

            s_MyTable_Detail1 += "<td class=\"ListHeadDetails\" align=\"center\">&nbsp;</td>";
            
            s_MyTable_Detail1 += " </tr>";
        }
        this.Tbx_Money.Text = d_All_Total.ToString();
        this.Tbx_Used.Text = "材料款";

        this.Tbx_ChineseMoney.Text = ConvertMoney(decimal.Parse(this.Tbx_Money.Text));
        this.Tbx_PayeeValue.Value = Model.SuppNo;
        KNet.BLL.Knet_Procure_Suppliers bll_Suppliers = new KNet.BLL.Knet_Procure_Suppliers();
        KNet.Model.Knet_Procure_Suppliers Model_Suppliers = bll_Suppliers.GetModelB(Model.SuppNo);
        this.Tbx_PayeeName.Text = Model_Suppliers.SuppName;
        this.Tbx_BankAccount.Text = Model_Suppliers.SuppBankAccount;
        this.Tbx_BankName.Text = Model_Suppliers.SuppBankName;
        this.Tbx_Shen.Text = GetSuppProvinceName(Model_Suppliers.SuppProvince);
        this.Tbx_Shi.Text = GetSuppCityName(Model_Suppliers.SuppCity);
        this.Tbx_Used.Text = base.Base_GetShortSupplierName(Model_Suppliers.SuppNo) + "材料款";
        this.Tbx_Details.Text = "订单号：" + s_ID;
        this.Tbx_FID.Text = s_ID;

    }
    /// <summary>
    /// 返回省份名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetSuppProvinceName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,code,name from KNet_Static_Province where Id='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["name"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 返回城市名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetSuppCityName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,code,name from KNet_Static_City where code='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["name"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
    private void ShowInfo(string s_ID)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.CG_Payment_For bll = new KNet.BLL.CG_Payment_For();
        KNet.Model.CG_Payment_For model = bll.GetModel(s_ID);
        if (model != null)
        {
            if ((model.CPF_State != 0) && (AM.KNet_StaffName != "项洲"))
            {
                AlertAndGoBack("已审批不能修改！");
            }
            else
            {
                this.Tbx_ID.Text = model.CPF_ID;
                this.Tbx_FID.Text = model.CPF_FID;
                this.Tbx_Used.Text = model.CPF_Used;
                try
                {
                    this.Tbx_STime.Text = model.CPF_STime.ToShortDateString();
                }
                catch { }
                this.Ddl_Currency.SelectedValue = model.CPF_Currency;
                this.Ddl_UseType.SelectedValue = model.CPF_UseType;
                this.Tbx_Money.Text = model.CPF_Lowercase.ToString();
                this.Tbx_ChineseMoney.Text = model.CPF_Capital;
                this.Tbx_PayeeValue.Value = model.CPF_SuppNo;
                this.Tbx_PayeeName.Text = model.CPF_SuppNoName;

                try
                {
                    this.Tbx_YTime.Text = model.CPF_YTime.ToShortDateString();
                }
                catch { }
                this.Ddl_Depart.SelectedValue = model.CPF_DutyDepart;
                this.Ddl_DutyPerson.SelectedValue = model.CPF_DutyPerson;
                this.Tbx_Remarks.Text = model.CPF_Remarks;
                this.Tbx_BankAccount.Text = model.CPF_Account;
                this.Tbx_BankName.Text = model.CPF_Bank;

                this.Tbx_Shen.Text = model.CPF_Shen;
                this.Tbx_Shi.Text = model.CPF_Shi;
                this.Tbx_Code.Text = model.CPF_Code;
                this.Image1.ImageUrl = model.CPF_Image;
                this.Image1Big.Text = model.CPF_BigImage;
                this.Tbx_Details.Text = model.CPF_Details;
                this.Tbx_MainFID.Text = model.CPF_MainFID;
                this.Tbx_WuliuID.Text = model.CPF_WuliuID;


                this.Tbx_ProductsTypeNo.Text = model.CPF_ProductsType;
                this.Tbx_ProductsTypeName.Text = base.Base_GetProductsType(model.CPF_ProductsType);
                this.Tbx_Project.Text = model.CPF_ProjectName;
                this.Tbx_RepayMoney.Text = model.CPF_RepayMoney;
                this.DdL_DDutyPerson.SelectedValue = model.CPF_DDutyPerson;

                if (model.CPF_WuliuID != "")
                {
                    ShowWuliuDetails(model.CPF_WuliuID);
                    this.Pan_Wuliu.Visible = true;
                }
                else
                {
                    this.Pan_Wuliu.Visible = false;
                }
                BindType();
                this.Tbx_YFOutDate.Text = model.CPF_OutDateTime.ToShortDateString();
            }

        }
    }
    private bool SetValue(KNet.Model.CG_Payment_For model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text != "")
            {
                model.CPF_ID = this.Tbx_ID.Text;
                model.CPF_Code = this.Tbx_Code.Text;
            }
            if (this.Tbx_ID.Text == "")
            {
                model.CPF_ID = GetMainID();
                model.CPF_Code = base.GetNewID("CG_Payment_For", 1);
            }

            model.CPF_STime = DateTime.Parse(this.Tbx_STime.Text);
            model.CPF_Used = this.Tbx_Used.Text.ToString();
            model.CPF_UseType = this.Ddl_UseType.Text.ToString();
            model.CPF_Currency = this.Ddl_Currency.Text.ToString();
            model.CPF_Capital = this.Tbx_ChineseMoney.Text.ToString();
            model.CPF_Lowercase = decimal.Parse(this.Tbx_Money.Text.ToString());
            model.CPF_DutyPerson = this.Ddl_DutyPerson.Text.ToString();
            model.CPF_FID = this.Tbx_FID.Text.ToString();
            model.CPF_YTime = DateTime.Parse(this.Tbx_YTime.Text.ToString());
            model.CPF_DutyDepart = this.Ddl_Depart.Text.ToString();
            model.CPF_Account = this.Tbx_BankAccount.Text.ToString();
            model.CPF_Bank = this.Tbx_BankName.Text.ToString();
            model.CPF_SuppNo = this.Tbx_PayeeValue.Value.ToString();
            model.CPF_SuppNoName = this.Tbx_PayeeName.Text.ToString();
            model.CPF_Remarks = this.Tbx_Remarks.Text.ToString();
            model.CPF_State = 0;
            model.CPF_Shen = this.Tbx_Shen.Text.ToString();
            model.CPF_Shi = this.Tbx_Shi.Text.ToString();
            model.CPF_CwDateTime = DateTime.Parse("1900-01-01");
            model.CPF_ResDateTime = DateTime.Parse("1900-01-01");
            model.CPF_Creator = AM.KNet_StaffNo;
            model.CPF_CTime = DateTime.Now;
            model.CPF_Mender = AM.KNet_StaffNo;
            model.CPF_MTime = DateTime.Now;
            model.CPF_ZDateTime = DateTime.Parse("1900-01-01");
            model.CPF_Image = this.Image1.ImageUrl;
            model.CPF_BigImage = this.Image1Big.Text;
            model.CPF_Details = this.Tbx_Details.Text;
            model.CPF_MainFID = this.Tbx_MainFID.Text;
            model.CPF_WuliuID = this.Tbx_WuliuID.Text;

            model.CPF_ProductsType = this.Tbx_ProductsTypeNo.Text;
            model.CPF_ProjectName = this.Tbx_Project.Text;
            model.CPF_RepayMoney = this.Tbx_RepayMoney.Text;
            model.CPF_DDutyPerson = this.DdL_DDutyPerson.SelectedValue;
            try
            {
                model.CPF_OutDateTime = DateTime.Parse(this.Tbx_YFOutDate.Text);
            }
            catch
            {
                model.CPF_OutDateTime = DateTime.Parse("1900-01-01");
            }
            return true;
        }
        catch
        {
            return false;
        }

    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_ID = this.Tbx_ID.Text;
        string s_FID = Request.QueryString["FID"] == null ? "" : Request.QueryString["FID"].ToString();

        KNet.Model.CG_Payment_For model = new KNet.Model.CG_Payment_For();
        KNet.BLL.CG_Payment_For bll = new KNet.BLL.CG_Payment_For();

        if (Ddl_UseType.SelectedValue == "4")
        {
            if (this.Tbx_YFOutDate.Text == "")
            {
                Alert("保证金超期日期不能为空！");
                return;
            }
        }
        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (s_ID == "")//新增
        {
            try
            {
                bll.Add(model);
                AM.Add_Logs("用款申请增加" + this.Tbx_ID.Text);
                if (s_FID != "")
                {

                    StringBuilder s = new StringBuilder();
                    s.Append("<script language=javascript>" + "\n");
                    s.Append("var returnVal = window.confirm(\"添加成功!是否继续添加？\",\"添加子项\");" + "\n");
                    s.Append("if(!returnVal){" + "\n");
                    s.Append("window.close();window.opener.location.reload();" + "\n");
                    s.Append("}else{" + "\n");
                    s.Append(" window.opener.location.reload();window.location.href = \"CG_Payment_For_Add.aspx?FID=" + this.Tbx_MainFID.Text + "\";}" + "\n");
                    s.Append("</script>");
                    Type cstype = this.GetType();
                    ClientScriptManager cs = Page.ClientScript;
                    string csname = "ltype";
                    if (!cs.IsStartupScriptRegistered(cstype, csname))
                        cs.RegisterStartupScript(cstype, csname, s.ToString());
                }
                else
                {
                    AlertAndRedirect("新增成功！", "CG_Payment_For_List.aspx");

                    try
                    {
                        KNet.BLL.KNet_Resource_Staff Bll_Staff = new KNet.BLL.KNet_Resource_Staff();
                        KNet.Model.KNet_Resource_Staff Model_Staff = Bll_Staff.GetModelC(this.Ddl_DutyPerson.SelectedValue);
                        if (Model_Staff.StaffDepart == "129652784259578018")//如果是供应链
                        {
                            base.Base_SendMessage(base.Base_GetDeptPerson("供应链平台", 1), "用款申请审批： <a href='/Web/CG/Payment/CG_Payment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.CPF_Used + "</a> 需要你审批！ ");

                        }
                        else
                        {
                            base.Base_SendMessage(base.Base_GetDeptPerson("财务部", 1), "用款申请审批： <a href='/Web/CG/Payment/CG_Payment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.CPF_Used + "</a> 需要你审批！ ");
                        }
                        //base.Base_SendMessage(base.Base_GetDeptPerson("行政人事部", 1), "用款申请付款： <a href='/Web/CG/Payment/CG_Payment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.CPF_Used + "</a> 需要你付款！ ");
                    }
                    catch
                    { }
                }

            }
            catch (Exception ex)
            {
                this.Tbx_ID.Text = "";
            }
        }
        else
        {

            try
            {
                bll.Update(model);
                try
                {
                    KNet.BLL.KNet_Resource_Staff Bll_Staff = new KNet.BLL.KNet_Resource_Staff();
                    KNet.Model.KNet_Resource_Staff Model_Staff = Bll_Staff.GetModelC(this.Ddl_DutyPerson.SelectedValue);
                    if (Model_Staff.StaffDepart == "129652784259578018")//如果是供应链
                    {
                        base.Base_SendMessage(base.Base_GetDeptPerson("供应链平台", 1), "用款申请审批： <a href='/Web/CG/Payment/CG_Payment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.CPF_Used + "</a> 需要你审批！ ");

                    }
                    else
                    {
                        base.Base_SendMessage(base.Base_GetDeptPerson("财务部", 1), "用款申请审批： <a href='/Web/CG/Payment/CG_Payment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.CPF_Used + "</a> 需要你审批！ ");
                    }
                }
                catch { }
                AM.Add_Logs("用款申请修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "CG_Payment_For_List.aspx");

            }
            catch { }
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
    #region 图片上传操作
    /// <summary>
    /// 上传图片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void button_ServerClick(object sender, EventArgs e)
    {
        if (!(uploadFile.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
            if (FileType == "image/gif" || FileType == "image/pjpeg")
            {
                GetThumbnailImage();
            }
            else
            {
                Response.Write("<script language=javascript>alert('文件类型服务器不接受！类型:" + FileType + " ');history.back(-1);</script>");
                Response.End();
            }
        }
    }

    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage()
    {
        string UploadPath = "../../../UpFile/Payment/";  //上传路径

        string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
        string fileExt = Path.GetExtension(uploadFile.PostedFile.FileName); //获扩展名
        string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型

        string filePath = UploadPath + AutoPath + fileExt; //大文件名
        string filePathsmall = UploadPath + AutoPath + "_small" + fileExt; //小文件名

        string newfile = filePath + ".jpg"; //略图文件名

        if (FileType == "image/gif" || FileType == "image/pjpeg")
        {
            if (!Directory.Exists(Server.MapPath(UploadPath)))
            {
                Directory.CreateDirectory(Server.MapPath(UploadPath));
            }
            uploadFile.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
            Up_Loadcs UL = new Up_Loadcs();

            UL.MakeZoomImage(Server.MapPath("../../../UpFile/Payment/") + AutoPath + fileExt, Server.MapPath("../../../UpFile/Payment/") + AutoPath + "_small" + fileExt, 95, 75, "HW");

            this.Image1.ImageUrl = "../../../UpFile/Payment/" + AutoPath + "_small" + fileExt;
            this.Image1Big.Text = filePath;
        }
        else
        {
            Response.Write("<script language=javascript>alert('文件类型服务器不接受！类型:" + FileType + " ');history.back(-1);</script>");
            Response.End();
        }
    }

    #endregion
    protected void Ddl_UseType_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindType();
    }

    private void BindType()
    {
        if (Ddl_UseType.SelectedValue == "4")
        {
            Pan_YFBill.Visible = true;
        }
        else
        {

            Pan_YFBill.Visible = false;
        }
    }
}

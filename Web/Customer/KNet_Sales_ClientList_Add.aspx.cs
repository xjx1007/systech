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


/// <summary>
/// 销售管理-----客户管理---客户添加
/// </summary>
public partial class Knet_Web_Sales_KNet_Sales_ClientList_Add : BasePage
{
    public string s_MyTable_Detail = "", s_Fh_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Knet_Web_Sales_KNet_Sales_ClientList_Add));
        if (!IsPostBack)
        {

            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            this.CustomerIntroduction.Text = "客户简单介绍...";

            base.Base_DropSheng(this.sheng);
            base.Base_DropCity(this.city, this.sheng.SelectedValue);

            this.city.Enabled = true;

            this.Pan_Other.Visible = false;

            this.ImageButton_down.Visible = true;
            this.ImageButton_up.Visible = false;

            base.Base_DropKClaaBind(this.CustomerClass, 1, "", "请选择渠道信息");
            base.Base_DropKClaaBind(this.CustomerTypes, 2, "", "请选择客户类型");
            base.Base_DropKClaaBind(this.CustomerTrade, 3, "", "请选择客户行业");
            base.Base_DropKClaaBind(this.CustomerSource, 4, "", "请选择客户来源");
            base.Base_DropBasicCodeBind(this.Ddl_Level, "112");
            base.Base_DropBasicCodeBind(this.Ddl_State, "113");
            base.Base_DropBasicCodeBind(this.Ddl_Type, "114");
            base.Base_DropDutyPerson(this.Ddl_DutyPerson," and issale='1' ");
            base.Base_DropDutyPerson(this.DDL_Auxiliary, " and issale='1' ");
            

            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
            {
                this.Lbl_Title.Text = "修改客户信息";
                this.ShowInfo(Request.QueryString["ID"].ToString().Trim());
                this.Tbx_ID.Text = Request.QueryString["ID"].ToString().Trim();
                this.Tbx_Type.Text = Request.QueryString["Type"]==null?"":Request.QueryString["Type"].ToString().Trim();

                
                //修改客户信息
                if (s_Type != "")
                {
                    this.Lbl_Title.Text = "复制客户信息";
                    this.Tbx_ID.Text = "";
                    this.CustomerValue.Text = "";
                }
            }
            else
            {
                this.Lbl_Title.Text = "新增客户信息";
                // 客户新增
            }

            if (AM.YNAuthority(this.Lbl_Title.Text) == false)
            {
                AM.NoAuthority(this.Lbl_Title.Text);
            }
        }

        KNet.BLL.Xs_Customer_Products BLL_Customer_Products = new KNet.BLL.Xs_Customer_Products();
        string s_ProductsID = "";
        DataSet Dts_Customer_Products = BLL_Customer_Products.GetList(" XCP_CustomerID='" + this.Tbx_ID.Text + "'");
        if (Dts_Customer_Products.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Customer_Products.Tables[0].Rows.Count; i++)
            {
                s_ProductsID += Dts_Customer_Products.Tables[0].Rows[i]["XCP_ProductsID"].ToString() + ",";
                s_MyTable_Detail += "<tr><td class='tdcss'><input type=\"hidden\" input Name=\"ProductsBarCode\" value='" + Dts_Customer_Products.Tables[0].Rows[i]["XCP_ProductsID"].ToString() + "'>" + Dts_Customer_Products.Tables[0].Rows[i]["XCP_ProductsID"].ToString() + "</td>";
                s_MyTable_Detail += "<td class='tdcss'><input type=\"hidden\" input Name=\"ProductsName\" value='" + base.Base_GetProdutsName(Dts_Customer_Products.Tables[0].Rows[i]["XCP_ProductsID"].ToString()) + "'>" + base.Base_GetProdutsName(Dts_Customer_Products.Tables[0].Rows[i]["XCP_ProductsID"].ToString()) + "</td>";
                KNet.BLL.KNet_Sys_Products BLL_Sys_Products = new KNet.BLL.KNet_Sys_Products();
                KNet.Model.KNet_Sys_Products Model_Sys_Products = BLL_Sys_Products.GetModelB(Dts_Customer_Products.Tables[0].Rows[i]["XCP_ProductsID"].ToString());
                s_MyTable_Detail += "<td class='tdcss'><input type=\"hidden\" input Name=\"ProductsPattern\" value='" + base.Base_GetProductsEdition_Link(Dts_Customer_Products.Tables[0].Rows[i]["XCP_ProductsID"].ToString()) + "'>" + base.Base_GetProductsEdition(Dts_Customer_Products.Tables[0].Rows[i]["XCP_ProductsID"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class='tdcss'><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\"  border=0></a></td></tr>";
            }

        }
        this.Xs_MaterID.Text = s_ProductsID;
        KNet.BLL.Xs_Customer_FhInfo Bll = new KNet.BLL.Xs_Customer_FhInfo();
        DataSet Dts_FhInfo = Bll.GetList("  XCF_CustomerValue='" + this.Tbx_ID.Text + "'");
        if (Dts_FhInfo.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_FhInfo.Tables[0].Rows.Count; i++)
            {
                s_Fh_Detail += "<tr><td class='dvtCellLabel'><input type=\"input\"  class=\"detailedViewTextBox\" Name=\"FhName\" value='" + Dts_FhInfo.Tables[0].Rows[i]["XCF_Name"].ToString() + "' /></td>";
                s_Fh_Detail += "<td class='dvtCellLabel'><textarea  style=\"height:50px;width:300px;\" class=\"detailedViewTextBox\"  Name=\"FhDetails\"  >" + Dts_FhInfo.Tables[0].Rows[i]["XCF_Details"].ToString() + "</textarea></td>";
                s_Fh_Detail += "<td class='dvtCellLabel'><A onclick=\"deleteRow1(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\"  border=0></a></td></tr>";
            }
        }
    }

    /// <summary>
    /// 获取信息
    /// </summary>
    protected void ShowInfo(string CustomerValue)
    {

        KNet.BLL.KNet_Sales_ClientList bll = new KNet.BLL.KNet_Sales_ClientList();
        KNet.Model.KNet_Sales_ClientList model = bll.GetModelB(CustomerValue);

        this.CustomerName.Text = model.CustomerName;
        this.CustomerValue.Text = model.CustomerCode;
        this.CustomerFax.Text = model.CustomerFax;

        base.Base_DropSheng(this.sheng);
        this.sheng.SelectedValue = model.CustomerProvinces;
        base.Base_DropCity(this.city, this.sheng.SelectedValue);
        this.city.SelectedValue = model.CustomerCity;

        try
        {
            this.CustomerClass.SelectedValue = model.CustomerClass;
            this.Tbx_SampleName.Text = model.KSC_SampleName;
        }
        catch { }
        try
        {
            this.CustomerTypes.SelectedValue = model.CustomerTypes;
        }
        catch { }
        try
        {
            this.CustomerTrade.SelectedValue = model.CustomerTrade;
        }
        catch { }
        try
        {
            this.CustomerSource.SelectedValue = model.CustomerSource;
        }
        catch { }
        try
        {
            this.CustomerSource.SelectedValue = model.CustomerSource;
        }
        catch { }


        this.CustomerContact.Text = model.CustomerContact;
        try
        {
            this.CustomerContactSex.SelectedValue = model.CustomerContactSex;
        }
        catch { }

        //
        this.FaterCode.Text = model.FaterCode;
        this.FaterCodeName.Text = base.Base_GetCustomerName(model.FaterCode);

        this.CustomerMobile.Text = model.CustomerMobile;
        this.CustomerTel.Text = model.CustomerTel;

        this.CustomerWebsite.Text = model.CustomerWebsite;
        this.CustomerEmail.Text = model.CustomerEmail;

        this.CustomerQQ.Text = model.CustomerQQ;
        this.CustomerMsn.Text = model.CustomerMsn;

        this.CustomerAddress.Text = model.CustomerAddress;
        this.CustomerZipCode.Text = model.CustomerZipCode;
        this.CustomerIntegral.Text = model.CustomerIntegral.ToString();

        this.CustomerProtect.Checked = model.CustomerProtect;

        this.CustomerIntroduction.Text = model.CustomerIntroduction;
        this.Tbx_LinkManID.Text = model.LinkManID;

        this.PlayCycleYN.Checked = model.PlayCycleYN;
        this.PlayCycleMoney.Text = model.PlayCycleMoney.ToString();
        this.PlayCycleTime.Text = model.PlayCycleTime.ToString();

        this.Tbx_OpeningBank.Text = model.OpeningBank.ToString();
        this.Tbx_RegistrationNum.Text = model.RegistrationNum.ToString();
        this.Tbx_BankAccount.Text = model.BankAccount.ToString();

        this.Ddl_Level.SelectedValue = model.KSC_Level.ToString();
        this.Ddl_State.SelectedValue = model.KSC_State.ToString();
        this.Ddl_Type.SelectedValue = model.KSC_Type.ToString();
        this.Ddl_DutyPerson.SelectedValue = model.KSC_DutyPerson.ToString();
        this.DDL_Auxiliary.SelectedValue = model.KSC_Auxiliary;

    }

    [Ajax.AjaxMethod()]
    public string GetCustomer(string s_FaterCode, string CustomerTypes, string CustomerClass, string sheng)
    {
        string s_Return = "";
        try
        {
             string s_ID = "", s_CustomerTypes = "", s_CustomerClass = "", s_Sheng = "", s_Number = "";
            int i_CustomerValue = 0;
            if (s_FaterCode != "")
            {
                string s_Sql = "Select Max(cast(Substring('1'+CustomerCode,0,7) as int)) from KNet_Sales_ClientList Where  FaterCode like '" + s_FaterCode.Substring(0, s_FaterCode.Length - 1) + "%'";
                this.BeginQuery(s_Sql);
                this.QueryForDataTable();
                if (this.Dtb_Result.Rows.Count > 0)
                {
                    i_CustomerValue = int.Parse(Dtb_Result.Rows[0][0].ToString()) + 1;
                }
            }
            //客户类型
            if (CustomerTypes != "")
            { 

                KNet.BLL.KNet_Sales_ClientAppseting bll_ClientAppseting = new KNet.BLL.KNet_Sales_ClientAppseting();
                KNet.Model.KNet_Sales_ClientAppseting Model = bll_ClientAppseting.GetModel(CustomerTypes);
                s_CustomerTypes = Model.Client_Code;
            }

            //渠道
            if (CustomerClass != "")
            {
                KNet.BLL.KNet_Sales_ClientAppseting bll = new KNet.BLL.KNet_Sales_ClientAppseting();
                DataSet ds = bll.GetList(" ClientValue ='" + CustomerClass + "' ");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s_CustomerClass = ds.Tables[0].Rows[0]["Client_Code"].ToString();
                }
            }
            //区域和省
            if (sheng != "")
            {
                this.BeginQuery("Select * from KNet_Static_Province where  ID='" + sheng + "'");
                this.QueryForDataSet();
                DataSet ds = this.Dts_Result;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    s_Sheng = ds.Tables[0].Rows[0]["Code"].ToString();
                }

            }
            s_ID = s_CustomerTypes + s_CustomerClass + s_Sheng;
            if (s_FaterCode != "")
            {
                s_ID = i_CustomerValue.ToString().Substring(1, i_CustomerValue.ToString().Length - 1) + s_ID;
            }
            else
            {
                this.BeginQuery("Select max(cast(Substring(CustomerValue,1,5) as int)) as Count From KNet_Sales_ClientList  ");
                this.QueryForDataTable();
                if (this.Dtb_Result.Rows.Count > 0)
                {
                    s_Number = Convert.ToString((int.Parse(Dtb_Result.Rows[0][0].ToString()) + 1)) + "1";
                    s_ID = s_Number.Substring(1, s_Number.Length - 1) + s_ID;
                }
                else
                {
                    s_ID += "10001";
                }

            }
            return s_ID.ToString();
        }
        catch
        {
            return s_Return;
        }
    }
    /// <summary>
    /// 添加信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        bool RegisterYN = false;
        string LoginID = "";
        string LoginPassword = "";
        ArrayList Arr_LinkMan = new ArrayList();
        AdminloginMess AM = new AdminloginMess();

        string XOL_ID = "";
        string CustomerName = KNetPage.KHtmlEncode(this.CustomerName.Text.Trim());
        string CustomerValue = Request["CustomerValue"]==null?"":Request["CustomerValue"].Trim();
        string CustomerCode ="";
        if (CustomerValue != "")
        {
            CustomerCode = "1" + CustomerValue.Substring(0, 5);
        }
        //CustomerCode,FaterCode新
        if (this.Tbx_ID.Text != "")
        {
            CustomerCode = this.Tbx_ID.Text;
        }
        string FaterCode = this.FaterCode.Text;

        string CustomerClass = this.CustomerClass.SelectedValue;
        string CustomerTypes = this.CustomerTypes.SelectedValue;

        string CustomerProvinces = this.sheng.SelectedValue.ToString();
        if (CustomerProvinces == "0" || CustomerProvinces == null)
        {
            Response.Write("<script language=javascript>alert('请选择所在省份!');history.back(-1);</script>");
            Response.End();
        }

        string CustomerCity = this.city.SelectedValue;

        string CustomerTrade = this.CustomerTrade.SelectedValue;
        string CustomerSource = this.CustomerSource.SelectedValue;

        string CustomerContact = KNetPage.KHtmlEncode(this.CustomerContact.Text.Trim());
        string CustomerContactSex = this.CustomerContactSex.SelectedValue;
        string CustomerTel = KNetPage.KHtmlEncode(this.CustomerTel.Text.Trim());
        string CustomerMobile = KNetPage.KHtmlEncode(this.CustomerMobile.Text.Trim());


        string CustomerWebsite = KNetPage.KHtmlEncode(this.CustomerWebsite.Text.Trim());
        string CustomerEmail = KNetPage.KHtmlEncode(this.CustomerEmail.Text.Trim());
        string CustomerAddress = KNetPage.KHtmlEncode(this.CustomerAddress.Text.Trim());
        string CustomerZipCode = KNetPage.KHtmlEncode(this.CustomerZipCode.Text.Trim());
        string CustomerQQ = KNetPage.KHtmlEncode(this.CustomerQQ.Text.Trim());
        string CustomerMsn = KNetPage.KHtmlEncode(this.CustomerMsn.Text.Trim());

        bool CustomerProtect = this.CustomerProtect.Checked;
        string CustomerIntroduction = this.CustomerIntroduction.Text.Trim();
        DateTime CustomerAddtime = DateTime.Now;

        int CustomerIntegral = int.Parse(this.CustomerIntegral.Text.Trim());



        decimal PlayCycleMoney = decimal.Parse(this.PlayCycleMoney.Text.Trim());
        int PlayCycleTime = int.Parse(this.PlayCycleTime.Text.Trim());
        bool PlayCycleYN = this.PlayCycleYN.Checked;

        KNet.BLL.KNet_Sales_ClientList BLL = new KNet.BLL.KNet_Sales_ClientList();
        KNet.Model.KNet_Sales_ClientList model = new KNet.Model.KNet_Sales_ClientList();
        model.KSC_Auxiliary = this.DDL_Auxiliary.SelectedValue;
        model.RegisterYN = RegisterYN;
        model.LoginID = LoginID;
        model.LoginPassword = LoginPassword;
        model.CustomerName = CustomerName;
        model.CustomerClass = CustomerClass;
        model.CustomerTypes = CustomerTypes;
        model.CustomerProvinces = CustomerProvinces;
        model.CustomerCity = CustomerCity;
        model.CustomerTrade = CustomerTrade;
        model.CustomerSource = CustomerSource;
        model.CustomerContact = CustomerContact;
        model.CustomerContactSex = CustomerContactSex;
        model.CustomerTel = CustomerTel;
        model.CustomerMobile = CustomerMobile;
        model.CustomerWebsite = CustomerWebsite;
        model.CustomerEmail = CustomerEmail;
        model.CustomerAddress = CustomerAddress;
        model.CustomerZipCode = CustomerZipCode;
        model.CustomerQQ = CustomerQQ;
        model.CustomerMsn = CustomerMsn;
        model.CustomerProtect = CustomerProtect;
        model.CustomerIntroduction = CustomerIntroduction;
        model.CustomerIntegral = CustomerIntegral;
        model.CustomerAddtime = CustomerAddtime;

        model.PlayCycleMoney = PlayCycleMoney;
        model.PlayCycleTime = PlayCycleTime;
        model.PlayCycleYN = PlayCycleYN;
        model.CustomerFax = this.CustomerFax.Text;

        model.CustomerCode = CustomerValue;
        model.FaterCode = FaterCode;
        model.CustomerValue = CustomerCode;

        model.BankAccount = this.Tbx_BankAccount.Text;
        model.OpeningBank = this.Tbx_OpeningBank.Text;
        model.RegistrationNum = this.Tbx_RegistrationNum.Text;
        model.Mender = AM.KNet_StaffNo;
        model.MTime = DateTime.Now;

        model.KSC_SampleName = this.Tbx_SampleName.Text;

        model.KSC_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
        model.KSC_Level = this.Ddl_Level.SelectedValue;
        model.KSC_State = this.Ddl_State.SelectedValue;
        model.KSC_Type = this.Ddl_Type.SelectedValue;
        model.KSC_Creator = AM.KNet_StaffNo;

        KNet.Model.XS_Compy_LinkMan Model_Compy_LinkMan = new KNet.Model.XS_Compy_LinkMan();
        Model_Compy_LinkMan.XOL_Compy = CustomerCode;
        Model_Compy_LinkMan.XOL_Name = CustomerContact;
        Model_Compy_LinkMan.XOL_Phone = CustomerMobile;
        Model_Compy_LinkMan.XOL_Sex = CustomerContactSex;
        Model_Compy_LinkMan.XOL_Mail = CustomerEmail;
        Model_Compy_LinkMan.XOL_QQ = CustomerQQ;
        Model_Compy_LinkMan.XOL_Address = CustomerAddress;
        Model_Compy_LinkMan.XOL_Del = 0;
        Model_Compy_LinkMan.XOL_Code = "CP" + CustomerCode.Substring(1, CustomerCode.Length - 1) + KNetOddNumbers1(CustomerCode);
        Model_Compy_LinkMan.XOL_Type = "101";

        ArrayList Arr_Products = new ArrayList();

        if (Request["ProductsBarCode"] != null)
        {
            string[] s_ProductsValue = Request.Form["ProductsBarCode"].Split(',');
            for (int i = 0; i < s_ProductsValue.Length; i++)
            {
                if (s_ProductsValue[i] != "")
                {
                    KNet.Model.Xs_Customer_Products Model_Customer_Products = new KNet.Model.Xs_Customer_Products();
                    Model_Customer_Products.XCP_CustomerID = CustomerCode;
                    Model_Customer_Products.XCP_ProductsID = s_ProductsValue[i];
                    Model_Customer_Products.XCP_ID = GetNewID("Xs_Customer_Products", 1);
                    Arr_Products.Add(Model_Customer_Products);
                }
            }
            model.Arr_Products = Arr_Products;
        }

        ArrayList Arr_FhDetails = new ArrayList();

        if (Request["FhDetails"] != null)
        {
            string[] s_FhName = Request.Form["FhName"].Split(',');
            string[] s_FhDetails = Request.Form["FhDetails"].Split(',');
            for (int i = 0; i < s_FhDetails.Length; i++)
            {
                KNet.Model.Xs_Customer_FhInfo Model_Customer_FhInfo = new KNet.Model.Xs_Customer_FhInfo();
                Model_Customer_FhInfo.XCF_ID = base.GetMainID(i);
                Model_Customer_FhInfo.XCF_CustomerValue = CustomerCode;
                Model_Customer_FhInfo.XCF_Name = s_FhName[i];
                Model_Customer_FhInfo.XCF_Details = s_FhDetails[i];
                Arr_FhDetails.Add(Model_Customer_FhInfo);
            }
            model.Arr_FhDetails = Arr_FhDetails;
        }
        try
        {
            if (this.Tbx_ID.Text != "")
            {

                XOL_ID = this.Tbx_LinkManID.Text;
                model.LinkManID = XOL_ID;
                Model_Compy_LinkMan.XOL_ID = XOL_ID;
                Arr_LinkMan.Add(Model_Compy_LinkMan);
                model.Arr_LinkMan = Arr_LinkMan;
                BLL.Update(model);
                AdminloginMess LogAM = new AdminloginMess();
                LogAM.Add_Logs("销售管理--->客户管理--->客户信息修改 操作成功！客户名称：" + CustomerName);
                Response.Write("<script>alert('客户修改成功！');location.href='KNet_Sales_ClientList_Manger.aspx?Css1=Div22';</script>");
                Response.End();
            }
            else
            {

                XOL_ID = base.GetNewID("Xs_Compy_LinkMan", 1);
                model.LinkManID = XOL_ID;
                Model_Compy_LinkMan.XOL_ID = XOL_ID;
                if (BLL.Exists_CustomerName(CustomerName, CustomerProvinces, CustomerCity) == false)
                {
                    Arr_LinkMan.Add(Model_Compy_LinkMan);
                    model.Arr_LinkMan = Arr_LinkMan;
                    BLL.Add(model);
                    AdminloginMess LogAM = new AdminloginMess();
                    LogAM.Add_Logs("销售管理--->客户管理--->客户 添加 操作成功！客户名称：" + CustomerName);

                    if (CustomerProtect == false)
                    {
                        Response.Write("<script>alert('普通客户 添加  成功！');location.href='KNet_Sales_ClientList_Manger.aspx?Css1=Div22';</script>");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("<script>alert('保护客户 添加  成功！');location.href='KNet_Sales_ClientList_MangerB.aspx?Css5=Div22';</script>");
                        Response.End();
                    }
                }
                else
                {
                    Response.Write("<script>alert('客户称已存在，请查证！ 添加失败1！');history.back(-1);</script>");
                    Response.End();
                }
            }
        }
        catch
        {
            Response.Write("<script>alert('客户添加失败2！');history.back(-1);</script>");
            Response.End();
        }
    }

    protected string KNus(int ss)
    {
        if (ss.ToString().Length == 1)
        {
            return "00" + ss.ToString();
        }
        if (ss.ToString().Length == 2)
        {
            return "0" + ss.ToString();
        }
        else
        {
            return ss.ToString();
        }
    }

    /// <summary>
    /// 返回当前的  单号 （唯一性，如 2009121402）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string KNetOddNumbers1(string s_CustomerValue)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select Isnull(MAX(XOL_Code),0)  as AA  from  XS_Compy_LinkMan Where XOL_Compy='" + s_CustomerValue + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["AA"].ToString() == "0")
                {
                    return "001";
                }
                else
                {
                    return KNus(int.Parse(dr["AA"].ToString().Substring(7, 3)) + 1);
                }
            }
            else
            {
                return "001";
            }
        }
    }
    protected void Ibn_LinkSave_Click(object sender, ImageClickEventArgs e)
    {

    }

    /// <summary>
    /// 向上UP起来
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageButton_up_Click(object sender, ImageClickEventArgs e)
    {
        this.Pan_Other.Visible = false;

        this.ImageButton_down.Visible = true;
        this.ImageButton_up.Visible = false;


    }

    /// <summary>
    /// 向下Down展示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageButton_down_Click(object sender, ImageClickEventArgs e)
    {
        this.Pan_Other.Visible = true;

        this.ImageButton_down.Visible = false;
        this.ImageButton_up.Visible = true;


    }
    protected void FaterCodeName_TextChanged1(object sender, EventArgs e)
    {
    }
    protected void sheng_SelectedIndexChanged(object sender, EventArgs e)
    {
        base.Base_DropCity(this.city, this.sheng.SelectedValue);
    }
}

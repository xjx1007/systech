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


public partial class Web_Sales_Knet_Procure_Suppliers_Add : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            base.Base_DropBasicCodeBind(this.Ddl_Level, "112");
            base.Base_DropBasicCodeBind(this.Tbx_Days, "300");

            KNet_Sys_ProcureTypebind();
            base.Base_DropSheng(this.sheng);
            base.Base_DropCity(this.city, this.sheng.SelectedValue);
            this.BeginQuery("Select * from PB_Basic_Wl ");
            this.QueryForDataTable();
            this.Drop_KD.DataSource = this.Dtb_Result;
            this.Drop_KD.DataTextField = "PBW_Name";
            this.Drop_KD.DataValueField = "PBW_Code";
            this.Drop_KD.DataBind();
            ListItem item = new ListItem("--请选择--", "-1"); //默认值
            Drop_KD.Items.Insert(0, item);
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制供应商";
                }
                else
                {
                    this.Lbl_Title.Text = "修改供应商";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
                Ddl_Type.Enabled = true;
            }
            else
            {
                this.Lbl_Title.Text = "新增供应商";
                Ddl_Type.Enabled = false;
            }
            AdminloginMess AM = new AdminloginMess();
            //销售机会列表
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
        }
    }

    protected void KNet_Sys_ProcureTypebind()
    {
        KNet.BLL.KNet_Sys_ProcureType bll = new KNet.BLL.KNet_Sys_ProcureType();
        DataSet ds = bll.GetAllList();
        this.Ddl_Type.DataSource = ds;
        this.Ddl_Type.DataTextField = "ProcureTypeName";
        this.Ddl_Type.DataValueField = "ProcureTypeValue";
        this.Ddl_Type.DataBind();
    }
    /// <summary>
    /// 获取信息
    /// </summary>
    /// <param name="SuppNo"></param>
    private void ShowInfo(string SuppNo)
    {
        KNet.BLL.Knet_Procure_Suppliers bll = new KNet.BLL.Knet_Procure_Suppliers();
        KNet.Model.Knet_Procure_Suppliers model = bll.GetModel(SuppNo);

        this.SuppCode.Text = model.SuppCode;
        this.SuppNo.Text = model.SuppNo;
        this.SuppName.Text = model.SuppName;
        this.SuppPeople.Text = model.SuppPeople;
        this.SuppMobiTel.Text = model.SuppMobiTel;
        this.SuppPhone.Text = model.SuppPhone;
        this.SuppFax.Text = model.SuppFax;
        this.SuppEmail.Text = model.SuppEmail;
        this.sheng.SelectedValue = model.SuppProvince;
        base.Base_DropCity(this.city, this.sheng.SelectedValue);
        this.city.SelectedValue = model.SuppCity;
        this.SuppWeb.Text = model.SuppWeb;
        this.SuppAddress.Text = model.SuppAddress;
        this.SuppZipCode.Text = model.SuppZipCode;
        this.SuppBankName.Text = model.SuppBankName;
        this.SuppBankAccount.Text = model.SuppBankAccount;
        this.SuppProducts.Text = KNetPage.KHtmlDiscode(model.SuppProducts);
        this.Remarks.Text = model.Remarks;
        this.Ddl_Level.SelectedValue = model.KPS_Level;
        this.Ddl_DutyPerson.SelectedValue = model.KPS_DutyPerson;
        this.Ddl_Type.SelectedValue = model.KPS_Type;
        this.Tbx_LinkManID.Text = model.KPS_LinkManID;
        this.Tbx_SName.Text = model.KPS_Sname;
        this.Tbx_Code.Text = model.KPS_Code;
        this.Tbx_Days.SelectedValue = model.KPS_Days.ToString();
        this.Drop_KD.SelectedValue = model.KPS_KDCode;
        this.Tbx_ScNumber.Text = model.KPS_ScNumber.ToString() ;
    }
    private bool SetValue(KNet.Model.Knet_Procure_Suppliers model,KNet.Model.XS_Compy_LinkMan Model_Compy_LinkMan)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {

            string SuppCode = KNetPage.KHtmlEncode(this.SuppCode.Text.Trim());
            string SuppName = KNetPage.KHtmlEncode(this.SuppName.Text.Trim());
            string SuppPeople = KNetPage.KHtmlEncode(this.SuppPeople.Text.Trim());
            string SuppMobiTel = KNetPage.KHtmlEncode(this.SuppMobiTel.Text.Trim());
            string SuppFax = KNetPage.KHtmlEncode(this.SuppFax.Text.Trim());
            string SuppPhone = KNetPage.KHtmlEncode(this.SuppPhone.Text.Trim());
            string SuppWeb = KNetPage.KHtmlEncode(this.SuppWeb.Text.Trim());
            string SuppEmail = KNetPage.KHtmlEncode(this.SuppEmail.Text.Trim());
            string SuppProvince = this.sheng.SelectedValue.ToString();
            if (SuppProvince == "0" || SuppProvince == null)
            {
                Response.Write("<script language=javascript>alert('请选择地区省份!');history.back(-1);</script>");
                Response.End();
            }

            string SuppCity = "0";
            if (Request["city"] != "" && Request["city"] != null)
            {
                SuppCity = Request["city"].Trim();
            }
            else
            {
                Response.Write("<script language=javascript>alert('请选择省份城市!');history.back(-1);</script>");
                Response.End();
            }

            string SuppAddress = KNetPage.KHtmlEncode(this.SuppAddress.Text.Trim());
            string SuppZipCode = KNetPage.KHtmlEncode(this.SuppZipCode.Text.Trim());
            string SuppBankName = KNetPage.KHtmlEncode(this.SuppBankName.Text.Trim());
            string SuppBankAccount = KNetPage.KHtmlEncode(this.SuppBankAccount.Text.Trim());

            string SuppProducts = KNetPage.KHtmlEncode(this.SuppProducts.Text.Trim());
            string Remarks = this.Remarks.Text.Trim();

            if (this.Tbx_ID.Text=="")
            {
                this.SuppNo.Text = DateTime.Now.ToFileTimeUtc().ToString();
            }
            model.SuppNo = this.SuppNo.Text;
            model.SuppName = SuppName;
            model.SuppPeople = SuppPeople;
            model.SuppMobiTel = SuppMobiTel;
            model.SuppFax = SuppFax;
            model.SuppPhone = SuppPhone;
            model.SuppWeb = SuppWeb;
            model.SuppEmail = SuppEmail;
            model.SuppProvince = SuppProvince;
            model.SuppCity = SuppCity;
            model.SuppAddress = SuppAddress;
            model.SuppZipCode = SuppZipCode;
            model.SuppBankName = SuppBankName;
            model.SuppBankAccount = SuppBankAccount;
            model.SuppProducts = SuppProducts;
            model.Remarks = Remarks;
            model.SuppCode = SuppCode;
            model.KPS_Type = this.Ddl_Type.SelectedValue;
            model.KPS_Level = this.Ddl_Level.SelectedValue;
            model.KPS_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.KPS_Creator = AM.KNet_StaffNo;
            model.KPS_CTime = DateTime.Now;
            model.KPS_Mender = AM.KNet_StaffNo;
            model.KPS_MTime = DateTime.Now;
            model.KPS_Code = this.Tbx_Code.Text;
            model.KPS_Sname = this.Tbx_SName.Text;
            model.KPS_KDCode = this.Drop_KD.SelectedValue;
            model.KPS_ScNumber = int.Parse(this.Tbx_ScNumber.Text == "" ? "0" : this.Tbx_ScNumber.Text);
            try
            {
                model.KPS_Days = int.Parse(this.Tbx_Days.Text);
            }
            catch {
                model.KPS_Days = 0;
            }
            Model_Compy_LinkMan.XOL_Compy = this.SuppNo.Text;
            Model_Compy_LinkMan.XOL_Name = SuppPeople;
            Model_Compy_LinkMan.XOL_Phone = SuppMobiTel;
            Model_Compy_LinkMan.XOL_Officephone = SuppPhone;
            Model_Compy_LinkMan.XOL_Fax = SuppFax;
            Model_Compy_LinkMan.XOL_Address = SuppAddress;
            Model_Compy_LinkMan.XOL_Mail = SuppEmail;
            Model_Compy_LinkMan.XOL_Mail = SuppEmail;
            Model_Compy_LinkMan.XOL_Del = 0;
            Model_Compy_LinkMan.XOL_Code = "CP" + SuppCode + KNetOddNumbers1(this.SuppNo.Text);
            Model_Compy_LinkMan.XOL_Type = "102";
            Model_Compy_LinkMan.XOL_DutyPerson = this.Ddl_DutyPerson.SelectedValue;

            return true;
        }
        catch
        {
            return false;
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
                    return KNus(int.Parse(dr["AA"].ToString().Substring(dr["AA"].ToString().Length-3, 3)) + 1);
                }
            }
            else
            {
                return "001";
            }
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

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_ID=this.Tbx_ID.Text;

        KNet.Model.Knet_Procure_Suppliers model = new KNet.Model.Knet_Procure_Suppliers();
        KNet.BLL.Knet_Procure_Suppliers bll = new KNet.BLL.Knet_Procure_Suppliers();
        KNet.Model.XS_Compy_LinkMan Model_Compy_LinkMan = new KNet.Model.XS_Compy_LinkMan();

        KNet.BLL.XS_Compy_LinkMan BLL_Compy_LinkMan = new KNet.BLL.XS_Compy_LinkMan();

        if (this.SetValue(model, Model_Compy_LinkMan) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (s_ID == "")//新增
        {
            try
            {
                Model_Compy_LinkMan.XOL_ID = base.GetNewID("Xs_Compy_LinkMan", 1);
                model.KPS_LinkManID = Model_Compy_LinkMan.XOL_ID;
                bll.Add(model);
                BLL_Compy_LinkMan.Add(Model_Compy_LinkMan);
                AM.Add_Logs("供应商增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "Knet_Procure_Suppliers_List.aspx");
            }
            catch { }
        }
        else
        {

            try
            {
                Model_Compy_LinkMan.XOL_ID = this.Tbx_LinkManID.Text;
                if (this.Tbx_LinkManID.Text == "")
                {
                    Model_Compy_LinkMan.XOL_ID = base.GetNewID("Xs_Compy_LinkMan", 1);
                    model.KPS_LinkManID = Model_Compy_LinkMan.XOL_ID;
                    BLL_Compy_LinkMan.Add(Model_Compy_LinkMan);
                }
                else
                {
                    model.KPS_LinkManID = this.Tbx_LinkManID.Text;
                    BLL_Compy_LinkMan.Update(Model_Compy_LinkMan);
                }
                model.ID = this.Tbx_ID.Text;
                bll.Update(model);
                AM.Add_Logs("供应商修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "Knet_Procure_Suppliers_List.aspx");
            }
            catch(Exception ex) {
            
            }
        }
    }

    protected void sheng_SelectedIndexChanged(object sender, EventArgs e)
    {
        base.Base_DropCity(this.city, this.sheng.SelectedValue);
    }
}

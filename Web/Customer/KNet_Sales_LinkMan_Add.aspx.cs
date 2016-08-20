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


public partial class Web_Sales_KNet_Sales_LinkMan_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Web_Sales_KNet_Sales_LinkMan_Add));
        if (!Page.IsPostBack)
        {
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_CustomerValue = Request.QueryString["CustomerValue"] == null ? "" : Request.QueryString["CustomerValue"].ToString();
            
            base.Base_DropBasicCodeBind(this.DdlXOL_Place, "752");//籍贯
            base.Base_DropBasicCodeBind(this.DdlXOL_Education, "751");//教育
            base.Base_DropBasicCodeBind(this.DdlXOL_Nation, "753");//民族
            txt_Code.Text = base.GetNewID("Xs_Compy_LinkMan",0);
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            base.Base_DropBasicCodeBind(this.Ddl_CallName, "115");
            this.Lbl_Title.Text = "新增联系人信息";

            if (s_ID!= "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制联系人信息";
                }
                else
                {
                    this.Lbl_Title.Text = "修改联系人信息";
                    this.Tbx_ID.Text = s_ID;
                    this.txt_Code.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }

            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            if (s_CustomerValue != "")
            {
                this.Tbx_CustomerValue.Value = s_CustomerValue;
                this.Tbx_CustomerName.Text = base.Base_GetCustomerName(s_CustomerValue);

                string s_Code = "CP" + s_CustomerValue.Substring(1, s_CustomerValue.Length - 1) + KNetOddNumbers1(s_CustomerValue);
                this.Tbx_Code.Text = s_Code;

                base.Base_DropLinkManBind(this.Ddl_Manager, s_CustomerValue);
            }
        }
    }

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
                    return this.KNus(int.Parse(dr["AA"].ToString().Substring(7, 3)) + 1);
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
    private void ShowInfo(string XOL_ID)
    {
        KNet.BLL.XS_Compy_LinkMan bll = new KNet.BLL.XS_Compy_LinkMan();
        KNet.Model.XS_Compy_LinkMan model = bll.GetModel(XOL_ID);
        this.Tbx_ID.Text = model.XOL_ID;
        this.Tbx_CustomerValue.Value = model.XOL_Compy;
        this.Tbx_CustomerName.Text = base.Base_GetCustomerName(model.XOL_Compy);

        base.Base_DropLinkManBind(this.Ddl_Manager, model.XOL_Compy);
        this.Ddl_Manager.SelectedValue = model.XOL_Manager;
        this.txtXOL_Name.Text = model.XOL_Name;
        this.txtXOL_Phone.Text = model.XOL_Phone;
        this.txtXOL_Mail.Text = model.XOL_Mail;
        this.DdlXOL_Sex.SelectedValue = model.XOL_Sex;
        this.txtXOL_Age.Text = model.XOL_Age;
        this.txtXOL_Birthday.Text = model.XOL_Birthday;
        this.DdlXOL_Place.SelectedValue = model.XOL_Place;
        this.DdlXOL_Nation.SelectedValue = model.XOL_Nation;
        this.DdlXOL_Marriage.SelectedValue = model.XOL_Marriage;
        this.txtXOL_Officephone.Text = model.XOL_Officephone;
        this.txtXOL_Homephone.Text = model.XOL_Homephone;
        this.txtXOL_Fax.Text = model.XOL_Fax;
        this.DdlXOL_Education.SelectedValue = model.XOL_Education;
        this.txtXOL_Experience.Text = model.XOL_Experience;
        this.txtXOL_Responsible.Text = model.XOL_Responsible;
        this.txtXOL_Hobby.Text = model.XOL_Hobby;
        this.txtXOL_Address.Text = model.XOL_Address;
        this.txtXOL_LogisticsAddress.Text = model.XOL_LogisticsAddress;
        this.txtXOL_Evaluation.Text = model.XOL_Evaluation;
        this.txtXOL_Remark.Text = model.XOL_Remark;
        this.DdlXOL_Duty.Text = model.XOL_Duty;
        this.Tbx_Code.Text = model.XOL_Code;

        this.Tbx_QQ.Text = model.XOL_QQ;
        this.Ddl_Manager.SelectedValue = model.XOL_Manager;
        this.Ddl_CallName.SelectedValue = model.XOL_CallName;
        this.Ddl_DutyPerson.SelectedValue = model.XOL_DutyPerson;
        this.tbxXOL_EnglishName.Text=model.XOL_EnglishName;
    }
    private bool SetValue(KNet.Model.XS_Compy_LinkMan model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            string XOL_ID = "";
            if (this.Tbx_ID.Text == "")
            {
                XOL_ID=base.GetNewID("Xs_Compy_LinkMan", 1);
            }
            else
            {
                XOL_ID = this.Tbx_ID.Text;
            }
            string XOL_Compy = this.Tbx_CustomerValue.Value;
            string XOL_Name = this.txtXOL_Name.Text;
            string XOL_Phone = this.txtXOL_Phone.Text;
            string XOL_Mail = this.txtXOL_Mail.Text;
            string XOL_Sex = this.DdlXOL_Sex.SelectedValue;
            string XOL_Age = this.txtXOL_Age.Text;
            string XOL_Birthday = this.txtXOL_Birthday.Text;
            string XOL_Place = this.DdlXOL_Place.SelectedValue;
            string XOL_Nation = this.DdlXOL_Nation.SelectedValue;
            string XOL_Marriage = this.DdlXOL_Marriage.SelectedValue;
            string XOL_Officephone = this.txtXOL_Officephone.Text;
            string XOL_Homephone = this.txtXOL_Homephone.Text;
            string XOL_Fax = this.txtXOL_Fax.Text;
            string XOL_Education = this.DdlXOL_Education.SelectedValue;
            string XOL_Experience = this.txtXOL_Experience.Text;
            string XOL_Responsible = this.txtXOL_Responsible.Text;
            string XOL_Hobby = this.txtXOL_Hobby.Text;
            string XOL_Address = this.txtXOL_Address.Text;
            string XOL_LogisticsAddress = this.txtXOL_LogisticsAddress.Text;
            string XOL_Evaluation = this.txtXOL_Evaluation.Text;
            string XOL_Remark = this.txtXOL_Remark.Text;
            int XOL_Del = 0;
            DateTime XOL_CDate = DateTime.Now;
            string XOL_Creator = AM.KNet_StaffNo;
            DateTime XOL_MDate = DateTime.Now;
            string XOL_Mender = AM.KNet_StaffNo;

            model.XOL_ID = XOL_ID;
            model.XOL_Compy = XOL_Compy;
            model.XOL_Name = XOL_Name;
            model.XOL_Phone = XOL_Phone;
            model.XOL_Mail = XOL_Mail;
            model.XOL_Sex = XOL_Sex;
            model.XOL_Age = XOL_Age;
            model.XOL_Birthday = XOL_Birthday;
            model.XOL_Place = XOL_Place;
            model.XOL_Nation = XOL_Nation;
            model.XOL_Marriage = XOL_Marriage;
            model.XOL_Officephone = XOL_Officephone;
            model.XOL_Homephone = XOL_Homephone;
            model.XOL_Fax = XOL_Fax;
            model.XOL_Education = XOL_Education;
            model.XOL_Experience = XOL_Experience;
            model.XOL_Responsible = XOL_Responsible;
            model.XOL_Hobby = XOL_Hobby;
            model.XOL_Address = XOL_Address;
            model.XOL_LogisticsAddress = XOL_LogisticsAddress;
            model.XOL_Evaluation = XOL_Evaluation;
            model.XOL_Remark = XOL_Remark;
            model.XOL_Del = XOL_Del;
            model.XOL_CDate = XOL_CDate;
            model.XOL_Creator = XOL_Creator;
            model.XOL_MDate = XOL_MDate;
            model.XOL_Mender = XOL_Mender;
            model.XOL_Duty = this.DdlXOL_Duty.Text;
            model.XOL_Code = this.Tbx_Code.Text;

            model.XOL_QQ = this.Tbx_QQ.Text;
            model.XOL_CallName = this.Ddl_CallName.SelectedValue;
            model.XOL_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.XOL_Manager = Request["Ddl_Manager"];
            model.XOL_EnglishName = this.tbxXOL_EnglishName.Text;
            model.XOL_Type = "101";

            return true;
        }
        catch
        {
            return false;
        }
       
    }

    [Ajax.AjaxMethod()]
    public string LinMan_Bind(string s_CustomerValue)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.XS_Compy_LinkMan bll = new KNet.BLL.XS_Compy_LinkMan();
            DataSet ds = bll.GetList(" XOL_Compy ='" + s_CustomerValue + "' ");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                s_Return += ds.Tables[0].Rows[i]["XOL_ID"].ToString() + "," + ds.Tables[0].Rows[i]["XOL_Name"].ToString() + "|";
            }
            return s_Return;
        }
        catch
        {
            return s_Return;
        }
    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_ID=this.Tbx_ID.Text;

        KNet.Model.XS_Compy_LinkMan model = new KNet.Model.XS_Compy_LinkMan();
        KNet.BLL.XS_Compy_LinkMan bll = new KNet.BLL.XS_Compy_LinkMan();

        string strErr = "";
        if (this.Tbx_CustomerValue.Value.Trim().Length == 0)
        {
            strErr += "客户名称不能为空！\\n";
        }
        if (this.txtXOL_Name.Text.Trim().Length == 0)
        {
            strErr += "名称不能为空！\\n";
        }

        if (strErr != "")
        {
            Alert(strErr);
            return;
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
                AM.Add_Logs("联系人增加" + model.XOL_ID);

                StringBuilder s = new StringBuilder();
                s.Append("<script language=javascript>" + "\n");
                s.Append("var returnVal = window.confirm(\"添加数据成功!是否继续添加？\",\"添加联系人\");" + "\n");
                s.Append("if(!returnVal){" + "\n");
                s.Append("window.location.href = \"Knet_Sales_LinkMan_List.aspx\";" + "\n");
                s.Append("}else{" + "\n");
                s.Append(" window.location.href = \"KNet_Sales_LinkMan_Add.aspx?CustomerValue=" + model.XOL_Compy + "\";}" + "\n");
                s.Append("</script>");
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                string csname = "ltype";
                if (!cs.IsStartupScriptRegistered(cstype, csname))
                    cs.RegisterStartupScript(cstype, csname, s.ToString());

            }
            catch { }
        }
        else
        {

            try
            {
                bll.Update(model);
                AM.Add_Logs("联系人修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！","Knet_Sales_LinkMan_List.aspx");
            }
            catch { }
        }
    }

}

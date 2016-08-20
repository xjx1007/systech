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

using KNet.DBUtility;
using KNet.Common;
using System.Data.SqlClient;
using System.Text;

public partial class PB_Basic_Express_Add : BasePage
{

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
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = s_ID;
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            this.Tbx_Type.Text = s_Type;

            this.BeginQuery("Select * from PB_Basic_Wl ");
            this.QueryForDataTable();
            this.Ddl_KDName.DataSource = this.Dtb_Result;
            this.Ddl_KDName.DataTextField = "PBW_Name";
            this.Ddl_KDName.DataValueField = "PBW_Code";
            this.Ddl_KDName.DataBind();
            ListItem item = new ListItem("--请选择快递--", "-1"); //默认值
            Ddl_KDName.Items.Insert(0, item);
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            base.Base_DropSheng(this.Ddl_Shen);
            base.Base_DropSheng(this.Ddl_ReShen);
            base.Base_DropCity(this.Ddl_Shi, "");
            base.Base_DropCity(this.Ddl_ReShi, "");
            base.Base_DropQu(this.Ddl_Qu, "");
            base.Base_DropQu(this.Ddl_ReQu, "");
            base.Base_DropJie(this.Ddl_Jie, "");
            base.Base_DropJie(this.Ddl_ReJie, "");
            this.Tbx_Stime.Text = DateTime.Now.ToShortDateString();
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制快递跟踪";
                }
                else
                {
                    this.Lbl_Title.Text = "修改快递跟踪";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增快递跟踪";
                this.Tbx_Code.Text = base.GetNewID("PB_Basic_Express", 0);
            }
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
        }

    }
    protected void ddlSheng_SelectedIndexChanged(object sender, EventArgs e)
    {
        base.Base_DropCity(this.Ddl_Shi, this.Ddl_Shen.SelectedValue);
    }
    protected void ddlShi_SelectedIndexChanged(object sender, EventArgs e)
    {
        base.Base_DropQu(this.Ddl_Qu, this.Ddl_Shi.SelectedItem.Text);
    }
    protected void ddlQu_SelectedIndexChanged(object sender, EventArgs e)
    {
        base.Base_DropJie(this.Ddl_Jie, this.Ddl_Qu.SelectedItem.Text);
    }

    protected void ddlReSheng_SelectedIndexChanged(object sender, EventArgs e)
    {
        base.Base_DropCity(this.Ddl_ReShi, this.Ddl_ReShen.SelectedValue);
    }
    protected void ddlReShi_SelectedIndexChanged(object sender, EventArgs e)
    {
        base.Base_DropQu(this.Ddl_ReQu, this.Ddl_ReShi.SelectedItem.Text);
    }
    protected void ddlReQu_SelectedIndexChanged(object sender, EventArgs e)
    {
        base.Base_DropJie(this.Ddl_ReJie, this.Ddl_ReQu.SelectedItem.Text);
    }
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.PB_Basic_Express bll = new KNet.BLL.PB_Basic_Express();
        KNet.Model.PB_Basic_Express model = bll.GetModel(s_ID);
        this.Tbx_ID.Text = model.PBE_ID;
        this.Tbx_Code.Text = model.PBE_Code;
        this.Tbx_Stime.Text = model.PBE_Stime.ToString();
        this.Ddl_DutyPerson.SelectedValue = model.PBE_DutyPerson;
        this.Tbx_CustomerValue.Value = model.PBE_CustomerValue;
        this.Tbx_CustomerName.Text = model.PBE_CustomerName;
        this.Tbx_LinkMan.Value = model.PBE_LinkMan;
        this.Tbx_LinkManName.Text = model.PBE_LinkManName;
        this.Ddl_Shen.SelectedValue = model.PBE_Shen;
        this.Ddl_Shi.SelectedValue = model.PBE_Shi;
        this.Ddl_Qu.SelectedValue = model.PBE_Qu;
        this.Ddl_Jie.SelectedValue = model.PBE_Jie;
        this.Tbx_Address.Text = model.PBE_Address;
        this.Tbx_Phone.Text = model.PBE_Phone;
        this.Tbx_TelPhone.Text = model.PBE_TelPhone;
        this.Tbx_ReCustomerValue.Value = model.PBE_ReCustomer;
        this.Tbx_ReCustomerName.Text = model.PBE_ReCustomerName;
        this.Tbx_ReLinkMan.Value = model.PBE_ReLinkMan;
        this.Tbx_ReLinkManName.Text = model.PBE_ReLinkManName;
        this.Ddl_ReShen.SelectedValue = model.PBE_ReShen;
        this.Ddl_ReShi.SelectedValue = model.PBE_ReShi;
        this.Ddl_ReQu.SelectedValue = model.PBE_ReQu;
        this.Ddl_ReJie.SelectedValue = model.PBE_ReJie;
        this.Tbx_ReAddress.Text = model.PBE_ReAddress;
        this.Tbx_RePhone.Text = model.PBE_RePhone;
        this.Tbx_ReTelPhone.Text = model.PBE_ReTelPhone;
        this.Tbx_Use.Text = model.PBE_Use;
        this.Ddl_KDName.SelectedValue = model.PBE_KDEnglishName;
        this.Tbx_KdCode.Text = model.PBE_KDCode;
    }

    private bool SetValue( KNet.Model.PB_Basic_Express model)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
			DateTime PBE_Stime=DateTime.Parse(this.Tbx_Stime.Text);
            string PBE_CustomerName = this.Tbx_CustomerName.Text;
            string PBE_CustomerValue = this.Tbx_CustomerValue.Value;
            string PBE_LinkMan = this.Tbx_LinkMan.Value;
            string PBE_ReCustomer = this.Tbx_ReCustomerValue.Value;
            string PBE_ReLinkMan = this.Tbx_ReLinkMan.Value;
            string PBE_LinkManName = this.Tbx_LinkManName.Text;
			string PBE_Address=this.Tbx_Address.Text;
			string PBE_Phone=this.Tbx_Phone.Text;
			string PBE_TelPhone=this.Tbx_TelPhone.Text;
			string PBE_ReCustomerName=this.Tbx_ReCustomerName.Text;
            string PBE_ReLinkManName = this.Tbx_ReLinkManName.Text;
            string PBE_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            string PBE_Shen = this.Ddl_Shen.SelectedValue;
            string PBE_Shi = this.Ddl_Shi.SelectedValue;
            string PBE_Qu = this.Ddl_Qu.SelectedValue;
            string PBE_Jie = this.Ddl_Jie.SelectedValue;
			string PBE_ReShen=this.Ddl_ReShen.SelectedValue;
			string PBE_ReShi=this.Ddl_ReShi.SelectedValue;
			string PBE_ReQu=this.Ddl_ReQu.SelectedValue;
            string PBE_ReJie = this.Ddl_ReJie.SelectedValue;
			string PBE_ReAddress=this.Tbx_ReAddress.Text;
			string PBE_RePhone=this.Tbx_RePhone.Text;
			string PBE_ReTelPhone=this.Tbx_ReTelPhone.Text;
			string PBE_Use=this.Tbx_Use.Text;
            string PBE_KDCode = this.Tbx_KdCode.Text;
            string PBE_KDName = this.Ddl_KDName.SelectedItem.Text;
            string PBE_KDEnglishName = this.Ddl_KDName.SelectedValue;
			string PBE_State="";
			DateTime PBE_ReceTime=DateTime.Parse("1900-1-1");
			DateTime PBE_CTime=DateTime.Now;
			string PBE_Creator=AM.KNet_StaffNo;
            DateTime PBE_MTime = DateTime.Now;
            string PBE_Mender = AM.KNet_StaffNo;
			int PBE_Del=0;


            
            if (this.Tbx_ID.Text == "")
            {
                model.PBE_ID = GetMainID();
                model.PBE_Code = base.GetNewID("PB_Basic_Express", 1);
            }
            else
            {
                model.PBE_ID = this.Tbx_ID.Text;
                model.PBE_Code=this.Tbx_Code.Text ;
            }
			model.PBE_Stime=PBE_Stime;
			model.PBE_DutyPerson=PBE_DutyPerson;
			model.PBE_CustomerValue=PBE_CustomerValue;
			model.PBE_CustomerName=PBE_CustomerName;
			model.PBE_LinkMan=PBE_LinkMan;
			model.PBE_LinkManName=PBE_LinkManName;
			model.PBE_Shen=PBE_Shen;
			model.PBE_Shi=PBE_Shi;
			model.PBE_Qu=PBE_Qu;
			model.PBE_Jie=PBE_Jie;
			model.PBE_Address=PBE_Address;
			model.PBE_Phone=PBE_Phone;
			model.PBE_TelPhone=PBE_TelPhone;
			model.PBE_ReCustomer=PBE_ReCustomer;
			model.PBE_ReCustomerName=PBE_ReCustomerName;
			model.PBE_ReLinkMan=PBE_ReLinkMan;
			model.PBE_ReLinkManName=PBE_ReLinkManName;
			model.PBE_ReShen=PBE_ReShen;
			model.PBE_ReShi=PBE_ReShi;
			model.PBE_ReQu=PBE_ReQu;
			model.PBE_ReJie=PBE_ReJie;
			model.PBE_ReAddress=PBE_ReAddress;
			model.PBE_RePhone=PBE_RePhone;
			model.PBE_ReTelPhone=PBE_ReTelPhone;
			model.PBE_Use=PBE_Use;
			model.PBE_KDName=PBE_KDName;
			model.PBE_KDCode=PBE_KDCode;
			model.PBE_KDEnglishName=PBE_KDEnglishName;
			model.PBE_State=PBE_State;
			model.PBE_ReceTime=PBE_ReceTime;
			model.PBE_CTime=PBE_CTime;
			model.PBE_Creator=PBE_Creator;
			model.PBE_MTime=PBE_MTime;
			model.PBE_Mender=PBE_Mender;
			model.PBE_Del=PBE_Del;

            return true;
        }
        catch
        {
            return false;
        }

    }
    protected void Btn_Send_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.PB_Basic_Express model = new KNet.Model.PB_Basic_Express();
        KNet.BLL.PB_Basic_Express bll = new KNet.BLL.PB_Basic_Express();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (this.Tbx_ID.Text != "")//修改
        {
            try
            {
                if (bll.Update(model))
                {
                    AM.Add_Logs("快递跟踪修改" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改成功！", "PB_Basic_Express_List.aspx");
                }
                else
                {
                    AM.Add_Logs("快递跟踪修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "PB_Basic_Express_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            catch { }
        }
        else
        {

            try
            {
                bll.Add(model);
                AM.Add_Logs("快递跟踪增加" + model.PBE_ID);
                AlertAndRedirect("新增成功！", "PB_Basic_Express_List.aspx");
            }
            catch { }
        }
    }
}

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

public partial class CG_ApplicationPayment_For_Add : BasePage
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
            string s_DID = Request.QueryString["DID"] == null ? "" : Request.QueryString["DID"].ToString();
            this.Tbx_ID.Text = s_ID;
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            this.Tbx_Type.Text = s_Type;
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            this.Tbx_Stime.Text = DateTime.Now.ToShortDateString();
            if (s_DID != "")
            {
                //删除子项
                KNet.BLL.CG_Payment_For Bll_Details = new KNet.BLL.CG_Payment_For();
                if (Bll_Details.Delete(s_DID))
                {
                    AM.Add_Logs("月度用款申请子项 删除 编号：" + s_DID + "");
                    Alert("删除成功！");
                }
            }
            KNet.BLL.IM_Project_Template Bll = new KNet.BLL.IM_Project_Template();
            DataSet Dts_Table_Temp = Bll.GetList(" 1=1 ");
            this.Ddl_Template.DataSource = Dts_Table_Temp;
            this.Ddl_Template.DataValueField = "IPT_ID";
            this.Ddl_Template.DataTextField = "IPT_Name";
            this.Ddl_Template.DataBind();
            this.Tbx_Code.Text = base.GetNewID("CG_ApplicationPayment_For", 0);
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制月度用款申请";
                }
                else
                {
                    this.Lbl_Title.Text = "修改月度用款申请";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增月度用款申请";
                this.Tbx_NID.Text = GetMainID();
            }
        }
        ShowDetails();
    }
    private void ShowInfo(string s_ID)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.CG_ApplicationPayment_For bll = new KNet.BLL.CG_ApplicationPayment_For();
        KNet.Model.CG_ApplicationPayment_For model = bll.GetModel(s_ID);
        if (model != null)
        {
            this.Tbx_Code.Text = model.CAF_Code;
            this.Tbx_Title.Text = model.CAF_Title;
            this.Ddl_DutyPerson.SelectedValue = model.CAF_DutyPerson;
            this.Tbx_Remarks.Text = model.CAF_Remarks;
            this.Tbx_Stime.Text = DateToString(model.CAF_STime.ToShortDateString());
            ShowDetails();

        }
    }
    private string GetDetails(string s_ID)
    {
        StringBuilder Sb_Str = new StringBuilder();
        KNet.BLL.CG_Payment_For Bll = new KNet.BLL.CG_Payment_For();
        DataSet Dts_Table = Bll.GetList("  CPF_MainFID='" + s_ID + "' order by CPF_MTime");
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {

                string s_Name = Dts_Table.Tables[0].Rows[i]["CPF_Used"].ToString();
                string s_ReceiveName = GetName(Dts_Table.Tables[0].Rows[i]["CPF_SuppNo"].ToString(), Dts_Table.Tables[0].Rows[i]["CPF_SuppNoName"].ToString());
                string s_STime = DateTime.Parse(Dts_Table.Tables[0].Rows[i]["CPF_YTime"].ToString()).ToShortDateString();
                string s_DutyPerson = base.Base_GetUserName(Dts_Table.Tables[0].Rows[i]["CPF_DutyPerson"].ToString()).ToString();
                string s_Money = Dts_Table.Tables[0].Rows[i]["CPF_LowerCase"].ToString();


                string s_DID = Dts_Table.Tables[0].Rows[i]["CPF_ID"].ToString();
                string s_FID = Dts_Table.Tables[0].Rows[i]["CPF_MainFID"].ToString();
                string s_EditImage = "<a target=\"_blank\" href=\"../Payment/CG_Payment_For_Add.aspx?ID=" + s_DID + "\"><img  border=\"0\"  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../../images/EditDetail.gif\"/></a>";

                string s_DeleteImage = "";
                s_DeleteImage = "<a  href=\"CG_ApplicationPayment_For_Add.aspx?DID=" + s_DID + "\"><img border=\"0\"  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../../images/deleteDetail.gif\"/></a>";
                Sb_Str.Append("<tr>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_Name + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_ReceiveName + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_STime + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_DutyPerson + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_Money + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_EditImage + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_DeleteImage + "</td>");

                Sb_Str.Append("<td>");
                Sb_Str.Append("<tr>\n");
                if (GetDetails(s_DID) != "")
                {
                    Sb_Str.Append(GetDetails(s_DID));
                }
            }
        }
        return Sb_Str.ToString();
    }
    public void ShowDetails()
    {

        StringBuilder Sb_Str = new StringBuilder();
        KNet.BLL.CG_Payment_For Bll = new KNet.BLL.CG_Payment_For();
        decimal d_TotalMoney = 0;
        DataSet Dts_Table = Bll.GetList("  CPF_MainFID='" + this.Tbx_Code.Text + "'  order by CPF_CTIme");
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                string s_Name = Dts_Table.Tables[0].Rows[i]["CPF_Used"].ToString();
                string s_ReceiveName = GetName(Dts_Table.Tables[0].Rows[i]["CPF_SuppNo"].ToString(), Dts_Table.Tables[0].Rows[i]["CPF_SuppNoName"].ToString());
                string s_STime = DateTime.Parse(Dts_Table.Tables[0].Rows[i]["CPF_YTime"].ToString()).ToShortDateString();
                string s_DutyPerson=base.Base_GetUserName(Dts_Table.Tables[0].Rows[i]["CPF_DutyPerson"].ToString()).ToString();
                string s_Money = Dts_Table.Tables[0].Rows[i]["CPF_LowerCase"].ToString();


                string s_DID = Dts_Table.Tables[0].Rows[i]["CPF_ID"].ToString();
                string s_FID = Dts_Table.Tables[0].Rows[i]["CPF_MainFID"].ToString();
                string s_EditImage = "<a target=\"_blank\" href=\"../Payment/CG_Payment_For_Add.aspx?ID=" + s_DID + "\"><img  border=\"0\"  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../../images/EditDetail.gif\"/></a>";

                string s_DeleteImage = "";
                s_DeleteImage = "<a  href=\"CG_ApplicationPayment_For_Add.aspx?DID=" + s_DID + "\"><img border=\"0\"  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../../images/deleteDetail.gif\"/></a>";
                Sb_Str.Append("<tr>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_Name + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_ReceiveName + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_STime + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_DutyPerson + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_Money + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_EditImage + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_DeleteImage + "</td>");
                d_TotalMoney += decimal.Parse(s_Money);

                Sb_Str.Append("<td>");
                Sb_Str.Append("<tr>\n");
                if (GetDetails(s_DID) != "")
                {
                    Sb_Str.Append(GetDetails(s_DID));
                }
            }

            Sb_Str.Append("<tr>\n");
            Sb_Str.Append("<td class=\"ListHeadDetails\" colspan=4>合计</td>");
            Sb_Str.Append("<td class=\"ListHeadDetails\">" + d_TotalMoney + "</td>");
            Sb_Str.Append("<td class=\"ListHeadDetails\" colspan=2>&nbsp;</td>");
            Sb_Str.Append("<td>");
            Sb_Str.Append("<tr>\n");
        }
        this.Tbx_Money.Text = d_TotalMoney.ToString();
        this.Lbl_Details.Text = Sb_Str.ToString();
    }

    public string GetName(string s_ID, string s_Name)
    {
        string s_Return = "";
        if (s_ID == "")
        {
            s_Return = s_Name;
        }
        else
        {
            if (base.Base_GetCustomerName(s_ID) == "--")
            {
                s_Return = base.Base_GetSupplierName_Link(s_ID);
            }
            else
            {
                s_Return = base.Base_GetCustomerName_Link(s_ID);
            }
        }
        return s_Return;
    }
    private bool SetValue(KNet.Model.CG_ApplicationPayment_For model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.CAF_ID = GetMainID();
            }
            else
            {
                model.CAF_ID = this.Tbx_ID.Text;
            }
            if (this.Tbx_ID.Text == "")
            {
                model.CAF_Code = base.GetNewID("CG_ApplicationPayment_For", 1);
            }
            else
            {
                model.CAF_Code = this.Tbx_Code.Text;
            }
            model.CAF_Title = this.Tbx_Title.Text;
            model.CAF_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            try
            {
                model.CAF_STime = DateTime.Parse(this.Tbx_Stime.Text);
            }
            catch
            {
                model.CAF_STime = DateTime.Parse("1900-01-01");
            }
            model.CAF_Remarks = this.Tbx_Remarks.Text;
            model.CAF_TotalMoney=decimal.Parse(this.Tbx_Money.Text==""?"0":this.Tbx_Money.Text);
            model.CAF_Creator = AM.KNet_StaffNo;
            model.CAF_CTime = DateTime.Now;
            model.CAF_Mender = AM.KNet_StaffNo;
            model.CAF_MTime = DateTime.Now;
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
        KNet.Model.CG_ApplicationPayment_For model = new KNet.Model.CG_ApplicationPayment_For();
        KNet.BLL.CG_ApplicationPayment_For bll = new KNet.BLL.CG_ApplicationPayment_For();

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
                    AM.Add_Logs("月度用款申请修改" + this.Tbx_ID.Text);
                    // base.Base_SendMessage(model.PPM_ID, "月度用款申请： <a href='Web/Notice/CG_ApplicationPayment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
                    AlertAndRedirect("修改成功！", "CG_ApplicationPayment_For_List.aspx");

                }
                else
                {
                    AM.Add_Logs("月度用款申请修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "CG_ApplicationPayment_For_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            catch { }
        }
        else
        {

            try
            {
                bll.Add(model);
                //base.Base_SendMessage(model.PPM_ID, "月度用款申请： <a href='Web/Notice/CG_ApplicationPayment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
                AM.Add_Logs("月度用款申请增加" + this.Tbx_ID.Text);
                base.Base_SendMessage(base.Base_GetDeptPerson("财务部", 1), "月度用款申请审批： <a href='/Web/CG/MonthPayment/CG_ApplicationPayment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.CAF_Title + "</a> 需要你审批！ ");

                AlertAndRedirect("新增成功！", "CG_ApplicationPayment_For_List.aspx");
            }
            catch(Exception ex) {
                Alert(ex.Message);
            }
        }

    }
    protected void Btn_Load_Click(object sender, EventArgs e)
    {
        //

        StringBuilder Sb_Str = new StringBuilder();
        AdminloginMess AM = new AdminloginMess();
        this.templateSeletor.Style.Value = "";
        KNet.BLL.CG_Payment_For Bll_Details = new KNet.BLL.CG_Payment_For();
        if (Bll_Details.DeleteByFID(this.Tbx_Code.Text))
        {
            //base.Base_SendMessage(model.PPM_ID, "月度用款申请： <a href='Web/Notice/CG_ApplicationPayment_For_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
            AM.Add_Logs("月度用款申请删除明细" + this.Tbx_ID.Text);
        }
    }
}

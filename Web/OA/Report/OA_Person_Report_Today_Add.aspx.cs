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

public partial class OA_Person_Report_Add : BasePage
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
            this.Tbx_STime.Text = DateTime.Now.ToShortDateString();
            base.Base_DropDutyPerson(this.Ddl_DutyPerson, true);
            this.Ddl_DutyPerson.Enabled = false;
            this.Lbl_Days.Text = "<font size='5'>" + DateTime.Now.ToShortDateString() + "  (" + base.Get_Chinese_Week(DateTime.Now) + ")  " + AM.KNet_StaffName + "</font>";
            this.Lbl_Pre.Text = "<font size='5'><</font>   ";
            this.Lbl_Next.Text = "<font size='5'>></font>   ";
            this.Button1.Attributes.Add("onclick", "return confirm('你确定提交报告?！')");
            if (s_ID != "")
            {
                this.Tbx_NID.Text = s_ID;
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制日报";
                }
                else
                {
                    this.Lbl_Title.Text = "修改日报";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Tbx_NID.Text = base.GetMainID();
                this.Lbl_Title.Text = "新增日报";

                this.CommentList2.CommentFID = this.Tbx_NID.Text;
                this.CommentList2.CommentType = "TotayReport";
                ShowInfoByDateTime(this.Tbx_STime.Text);
            }
        }

    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.OA_Person_Report bll = new KNet.BLL.OA_Person_Report();
        KNet.Model.OA_Person_Report model = bll.GetModel(s_ID);
        if (model != null)
        {
            this.Tbx_ID.Text = model.OPR_ID.ToString();
            this.Tbx_NID.Text = model.OPR_ID.ToString();
            this.CommentList2.CommentFID = this.Tbx_NID.Text;
            this.CommentList2.CommentType = "TotayReport";
            this.Tbx_STime.Text = DateTime.Parse(model.OPR_STime.ToString()).ToShortDateString();
            this.Tbx_ThisReport.Text = model.OPR_ThisReport.ToString();
            this.Tbx_NextReport.Text = model.OPR_NextReport.ToString();
            this.Tbx_Type.Text = model.OPR_Type.ToString();

            DateTime Dtm_Time = DateTime.Parse(this.Tbx_STime.Text).AddDays(-1);

            DataSet Dts_Table1 = bll.GetList(" OPR_Stime='" + Dtm_Time.ToShortDateString() + "' and  OPR_Type='1' and OPR_State='1' and  OPR_DutyPerson='" + this.Ddl_DutyPerson.SelectedValue + "'");
            if (Dts_Table1.Tables[0].Rows.Count > 0)
            {
                this.Lbl_ThisReport.Text = Dts_Table1.Tables[0].Rows[0]["OPR_NextReport"].ToString();
            }
            else
            {
                this.Lbl_ThisReport.Text = "";
            }
            ShowDetails(model.OPR_State);
        }
    }

    private void ShowDetails(int i_State)
    {
        if (i_State == 1)
        {
            this.Tbx_ThisReport.Enabled = false;
            this.Tbx_NextReport.Enabled = false;
            this.Button1.Text = "已提交";
            this.Button1.Enabled = false;
            this.Btn_Save.Enabled = false;

        }
        else
        {
            this.Tbx_ThisReport.Enabled = true;
            this.Tbx_NextReport.Enabled = true;
            this.Button1.Text = "提交";
            this.Button1.Enabled = true;
            this.Btn_Save.Enabled = true;
        }
    }
    private void ShowInfoByDateTime(string s_DataTime)
    {
        int i_State = 0;
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.OA_Person_Report bll = new KNet.BLL.OA_Person_Report();
        DataSet Dts_Table = bll.GetList(" OPR_Stime='" + s_DataTime + "'  and OPR_Type='1' and  OPR_DutyPerson='" + this.Ddl_DutyPerson.SelectedValue + "' ");
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {

            this.Tbx_ID.Text = Dts_Table.Tables[0].Rows[0]["OPR_ID"].ToString();
            this.Tbx_NID.Text = Dts_Table.Tables[0].Rows[0]["OPR_ID"].ToString();
            this.CommentList2.CommentFID = Dts_Table.Tables[0].Rows[0]["OPR_ID"].ToString();
            this.CommentList2.CommentType = "TotayReport";
            this.Tbx_STime.Text = DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_STime"].ToString()).ToShortDateString();
            this.Tbx_ThisReport.Text = Dts_Table.Tables[0].Rows[0]["OPR_ThisReport"].ToString();
            this.Tbx_NextReport.Text = Dts_Table.Tables[0].Rows[0]["OPR_NextReport"].ToString();
            this.Tbx_Type.Text = Dts_Table.Tables[0].Rows[0]["OPR_Type"].ToString();
            i_State = int.Parse(Dts_Table.Tables[0].Rows[0]["OPR_State"].ToString());
        }
        else
        {
            this.Tbx_ID.Text ="";

            this.Tbx_NID.Text = base.GetMainID();

            this.CommentList2.CommentFID = this.Tbx_NID.Text;
            this.CommentList2.CommentType = "TotayReport";
            this.Tbx_ThisReport.Text = "";
            this.Tbx_NextReport.Text = "";
            this.Tbx_Type.Text ="1";
        }

        ShowDetails(i_State);
        DateTime Dtm_Time = DateTime.Parse(s_DataTime).AddDays(-1);

        DataSet Dts_Table1 = bll.GetList(" OPR_Stime='" + Dtm_Time.ToShortDateString() + "' and  OPR_Type='1' and  OPR_DutyPerson='"+this.Ddl_DutyPerson.SelectedValue+"'");
        if (Dts_Table1.Tables[0].Rows.Count > 0)
        {
            this.Lbl_ThisReport.Text = Dts_Table1.Tables[0].Rows[0]["OPR_NextReport"].ToString();
        }
    }
    private bool SetValue(KNet.Model.OA_Person_Report model)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.OPR_ID = this.Tbx_NID.Text;
            }
            else
            {
                model.OPR_ID = this.Tbx_ID.Text;
            }
            model.OPR_Code = base.GetNewID("OA_Person_Report", 1);
            model.OPR_STime = DateTime.Parse(this.Tbx_STime.Text.ToString());
            model.OPR_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.OPR_ThisReport = this.Tbx_ThisReport.Text.ToString();
            model.OPR_NextReport = this.Tbx_NextReport.Text.ToString();
            model.OPR_SubmitTime = DateTime.Now;
            model.OPR_Type = 1;
            model.OPR_State = 0;
            model.OPR_CTime = DateTime.Now;
            model.OPR_Creator = AM.KNet_StaffNo;
            model.OPR_MTime = DateTime.Now;
            model.OPR_Mender = AM.KNet_StaffNo;
            model.OPR_Del = 0;
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
        KNet.Model.OA_Person_Report model = new KNet.Model.OA_Person_Report();
        KNet.BLL.OA_Person_Report bll = new KNet.BLL.OA_Person_Report();

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
                    AM.Add_Logs("日报修改" + this.Tbx_ID.Text);
                    //base.Base_SendMessage(model.PBM_ID, "日报：<a href='Web/Notice/OA_Person_Report_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBM_ID + "</a> ");
                    AlertAndRedirect("修改成功！", "OA_Person_Report_Today_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
                else
                {
                    AM.Add_Logs("日报修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "OA_Person_Report_Today_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            catch { }
        }
        else
        {

            try
            {
                bll.Add(model);
                //base.Base_SendMessage(model.PBN_ReceiveID, "日报：<a href='Web/Notice/OA_Person_Report_View.aspx?ID=" + model.PBN_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
                AM.Add_Logs("日报增加" );
                AlertAndRedirect("新增成功！", "OA_Person_Report_Today_Add.aspx?ID=" + this.Tbx_ID.Text + "");
            }
            catch { }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        KNet.Model.OA_Person_Report model = new KNet.Model.OA_Person_Report();
        KNet.BLL.OA_Person_Report bll = new KNet.BLL.OA_Person_Report();
        AdminloginMess AM = new AdminloginMess();
        
        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }

        try
        {
            model.OPR_State = 1;
            if (bll.Update(model))
            {
                AM.Add_Logs("日报提交" + this.Tbx_ID.Text);
                //base.Base_SendMessage(model.PBM_ID, "日报：<a href='Web/Notice/OA_Person_Report_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBM_ID + "</a> ");
                AlertAndRedirect("日报提交成功！", "OA_Person_Report_Today_Add.aspx?ID=" + this.Tbx_ID.Text + "");
            }
            else
            {
                AM.Add_Logs("日报修改失败" + this.Tbx_ID.Text);
                AlertAndRedirect("修改失败！", "OA_Person_Report_Today_Add.aspx?ID=" + this.Tbx_ID.Text + "");
            }
        }
        catch { }
    }
    protected void Lbl_Pre_Click(object sender, EventArgs e)
    {
        this.Tbx_STime.Text = DateTime.Parse(this.Tbx_STime.Text).AddDays(-1).ToShortDateString();
        DateTime date = DateTime.Parse(this.Tbx_STime.Text);
        this.Lbl_Days.Text = "<font size='5'>" + date.ToShortDateString() + "  (" + base.Get_Chinese_Week(date) + ")  " + this.Ddl_DutyPerson.SelectedItem.Text + "</font>";
        this.ShowInfoByDateTime(this.Tbx_STime.Text);
    }
    protected void Lbl_Next_Click(object sender, EventArgs e)
    {
        this.Tbx_STime.Text = DateTime.Parse(this.Tbx_STime.Text).AddDays(1).ToShortDateString();
        DateTime date = DateTime.Parse(this.Tbx_STime.Text);
        this.Lbl_Days.Text = "<font size='5'>" + date.ToShortDateString() + "  (" + base.Get_Chinese_Week(date) + ")  " + this.Ddl_DutyPerson.SelectedItem.Text + "</font>";
        this.ShowInfoByDateTime(this.Tbx_STime.Text);
    }
}

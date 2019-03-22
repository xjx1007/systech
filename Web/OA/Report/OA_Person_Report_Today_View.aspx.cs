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

public partial class OA_Person_Report_Today_View : BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write(
                    "<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = s_ID;
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            this.Tbx_Type.Text = s_Type;
            this.Tbx_STime.Text = DateTime.Now.ToShortDateString();

            //base.Base_DropDutyPersonByFid(this.Ddl_DutyPerson, AM.KNet_StaffNo);

            base.Base_DropBasicCodeBind(this.DdlPBC_Preset, "201", false);
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
                ShowInfo(s_ID);
            }
            else
            {
                this.Tbx_NID.Text = base.GetMainID();
                this.Lbl_Title.Text = "新增日报";

                //this.CommentList2.CommentFID = this.Tbx_NID.Text;
                //this.CommentList2.CommentType = "TotayReport";

                //this.CommentList1.CommentFID = this.Tbx_NID.Text;
                //this.CommentList1.CommentType = 7;
                // .cs文件加载用户控件

                //UC_ddlCategroy.Controls.Add(TemplateControl.LoadControl("UC_ddlCategroy.ascx"));

                ShowInfoByDateTime(this.Tbx_STime.Text);
                AddComment.Visible = false;
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
            //this.CommentList2.CommentFID = this.Tbx_NID.Text;
            //this.CommentList2.CommentType = "TotayReport";

            //this.CommentList1.CommentFID = this.Tbx_NID.Text;
            //this.CommentList1.CommentType = 7;
            this.Tbx_STime.Text = DateTime.Parse(model.OPR_STime.ToString()).ToShortDateString();
            this.Tbx_ThisReport.Value = model.OPR_ThisReport.ToString();
            this.Tbx_NextReport.Value = model.OPR_NextReport.ToString();
            this.Tbx_Type.Text = model.OPR_Type.ToString();
           
            //DateTime Dtm_Time = DateTime.Parse(this.Tbx_STime.Text).AddDays(-1);

            //DataSet Dts_Table1 =
            //    bll.GetList(" OPR_Stime='" + Dtm_Time.ToShortDateString() +
            //                "' and  OPR_Type='1' and OPR_State='1' and  OPR_DutyPerson='" +
            //                this.Ddl_DutyPerson.SelectedValue + "'");
            //if (Dts_Table1.Tables[0].Rows.Count > 0)
            //{
            //    this.Lbl_ThisReport.Text = Dts_Table1.Tables[0].Rows[0]["OPR_NextReport"].ToString();
            //}
            //else
            //{
            //    this.Lbl_ThisReport.Text = "";
            //}
        }
    }

    private void ShowInfoByDateTime(string s_DataTime)
    {
        try
        {
            int i_State = 0;
            AdminloginMess AM = new AdminloginMess();
            KNet.BLL.OA_Person_Report bll = new KNet.BLL.OA_Person_Report();
            string staffno = "";
            if (this.UC_ddlCategroy.SelectedValue=="")
            {
                staffno = AM.KNet_StaffNo;
            }
            else
            {
                staffno = this.UC_ddlCategroy.SelectedValue;
            }
            DataSet Dts_Table =
                bll.GetList(" OPR_Stime='" + s_DataTime + "' and OPR_DutyPerson='" + staffno +
                            "'  and OPR_Type='1' ");
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                this.Lbl_Days.Text = "<font size='4' color=Blue>" +DateTime.Parse(s_DataTime).ToShortDateString() + "  (" +
                                     base.Get_Chinese_Week(DateTime.Parse(s_DataTime)) + ")  " +
                                     GetUserName(staffno) + "  </font>";
                this.Sub_Time.Text="提交时间："+ Dts_Table.Tables[0].Rows[0]["OPR_SubmitTime"].ToString();
                if (Dts_Table.Tables[0].Rows[0]["OPR_ThisReport"].ToString()=="")
                {
                    this.M_Time.Text = "提交时间：" ;
                }
                else
                {
                    this.M_Time.Text = "提交时间：" + Dts_Table.Tables[0].Rows[0]["OPR_MTime"].ToString();
                }
                
                this.Tbx_ID.Text = Dts_Table.Tables[0].Rows[0]["OPR_ID"].ToString();
                this.Tbx_NID.Text = Dts_Table.Tables[0].Rows[0]["OPR_ID"].ToString();
                //this.CommentList2.CommentFID = Dts_Table.Tables[0].Rows[0]["OPR_ID"].ToString();
                //this.CommentList2.CommentType = "TotayReport";
                //this.CommentList1.CommentFID = Dts_Table.Tables[0].Rows[0]["OPR_ID"].ToString();
                //this.CommentList1.CommentType = 7;
                this.Tbx_STime.Text =
                    DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_STime"].ToString()).ToShortDateString();
                this.Tbx_ThisReport.Value = Dts_Table.Tables[0].Rows[0]["OPR_ThisReport"].ToString();
                this.Tbx_NextReport.Value = Dts_Table.Tables[0].Rows[0]["OPR_NextReport"].ToString();
                this.Tbx_Type.Text = Dts_Table.Tables[0].Rows[0]["OPR_Type"].ToString();
                i_State = int.Parse(Dts_Table.Tables[0].Rows[0]["OPR_State"].ToString());
                //查询附件
                KNet.BLL.PB_Basic_Attachment bllFile = new KNet.BLL.PB_Basic_Attachment();
                string SqlWhere = "";
                SqlWhere = " PBA_FID='" + this.Tbx_ID.Text + "' AND PBA_Type='DayFile' and PBA_Creator='" +
                           staffno + "' order by PBA_CTime ";
                DataSet ds_Comment = bllFile.GetList(SqlWhere);
                GridView_Comment.DataSource = ds_Comment.Tables[0];
                GridView_Comment.DataBind();

                //查询点评
                KNet.BLL.PB_Basic_Comment bllComment = new KNet.BLL.PB_Basic_Comment();
                string SqlWhere1 = "";                
                SqlWhere1 = " PBC_FID='" + this.Tbx_ID.Text + "' AND PBC_Type=24 order by PBC_CTime ";
                DataSet ds_Comment1 = bllComment.GetList(SqlWhere1);
                MyGridView1.DataSource = ds_Comment1.Tables[0];
                MyGridView1.DataBind();
                //this.Btn_Create.Enabled = true;
                
            }
            else
            {
                this.Lbl_Days.Text = "<font size='4' color=red>" + DateTime.Parse(s_DataTime).ToShortDateString() + "  (" +
                                     base.Get_Chinese_Week(DateTime.Parse(s_DataTime)) + ")  " +
                                      GetUserName(staffno) + "  未写</font>";

                this.Lbl_PersonDetails.Text = "<font ></font>";
                this.Sub_Time.Text = "提交时间：";
                this.M_Time.Text = "提交时间：";
                this.Tbx_ID.Text = "";

                this.Tbx_NID.Text = "";

                //this.CommentList2.CommentFID = this.Tbx_NID.Text;
                //this.CommentList2.CommentType = "TotayReport";
                //this.CommentList1.CommentFID = this.Tbx_NID.Text;
                //this.CommentList1.CommentType = 7;
                this.Tbx_ThisReport.Value = "";
                this.Tbx_NextReport.Value = "";
                this.Tbx_Type.Text = "1";
            }

            //DateTime Dtm_Time = DateTime.Parse(s_DataTime).AddDays(-1);

            //DataSet Dts_Table1 =
            //    bll.GetList(" OPR_Stime='" + Dtm_Time.ToShortDateString() + "' and OPR_DutyPerson='" +
            //                this.Ddl_DutyPerson.SelectedValue + "' and  OPR_Type='1' and  OPR_DutyPerson='" +
            //                this.Ddl_DutyPerson.SelectedValue + "'");
            //if (Dts_Table1.Tables[0].Rows.Count > 0)
            //{
            //    this.Lbl_ThisReport.Text = Dts_Table1.Tables[0].Rows[0]["OPR_NextReport"].ToString();
            //}
        }
        catch
        {
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
            model.OPR_DutyPerson = this.UC_ddlCategroy.SelectedValue;
            model.OPR_ThisReport = this.Tbx_ThisReport.Value.ToString();
            model.OPR_NextReport = this.Tbx_NextReport.Value.ToString();
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

    //protected void Btn_Send_Click(object sender, EventArgs e)
    //{
    //    AdminloginMess AM = new AdminloginMess();
    //    KNet.Model.OA_Person_Report model = new KNet.Model.OA_Person_Report();
    //    KNet.BLL.OA_Person_Report bll = new KNet.BLL.OA_Person_Report();

    //    if (this.SetValue(model) == false)
    //    {
    //        Alert("系统错误！");
    //        return;
    //    }
    //    if (this.Tbx_ID.Text != "")//修改
    //    {
    //        try
    //        {
    //            if (bll.Update(model))
    //            {
    //                AM.Add_Logs("日报修改" + this.Tbx_ID.Text);
    //                //base.Base_SendMessage(model.PBM_ID, "日报：<a href='Web/Notice/OA_Person_Report_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBM_ID + "</a> ");
    //                AlertAndRedirect("修改成功！", "OA_Person_Report_Today_Add.aspx?ID=" + this.Tbx_ID.Text + "");
    //            }
    //            else
    //            {
    //                AM.Add_Logs("日报修改失败" + this.Tbx_ID.Text);
    //                AlertAndRedirect("修改失败！", "OA_Person_Report_Today_Add.aspx?ID=" + this.Tbx_ID.Text + "");
    //            }
    //        }
    //        catch { }
    //    }
    //    else
    //    {

    //        try
    //        {
    //            bll.Add(model);
    //            //base.Base_SendMessage(model.PBN_ReceiveID, "日报：<a href='Web/Notice/OA_Person_Report_View.aspx?ID=" + model.PBN_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
    //            AM.Add_Logs("日报增加" );
    //            AlertAndRedirect("新增成功！", "OA_Person_Report_Today_Add.aspx?ID=" + this.Tbx_ID.Text + "");
    //        }
    //        catch { }
    //    }
    //}
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    KNet.Model.OA_Person_Report model = new KNet.Model.OA_Person_Report();
    //    KNet.BLL.OA_Person_Report bll = new KNet.BLL.OA_Person_Report();
    //    AdminloginMess AM = new AdminloginMess();

    //    if (this.SetValue(model) == false)
    //    {
    //        Alert("系统错误！");
    //        return;
    //    }

    //    try
    //    {
    //        model.OPR_State = 1;
    //        if (bll.Update(model))
    //        {
    //            AM.Add_Logs("日报提交" + this.Tbx_ID.Text);
    //            //base.Base_SendMessage(model.PBM_ID, "日报：<a href='Web/Notice/OA_Person_Report_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBM_ID + "</a> ");
    //            AlertAndRedirect("日报提交成功！", "OA_Person_Report_Today_Add.aspx?ID=" + this.Tbx_ID.Text + "");
    //        }
    //        else
    //        {
    //            AM.Add_Logs("日报修改失败" + this.Tbx_ID.Text);
    //            AlertAndRedirect("修改失败！", "OA_Person_Report_Today_Add.aspx?ID=" + this.Tbx_ID.Text + "");
    //        }
    //    }
    //    catch { }
    //}
    protected void Lbl_Pre_Click(object sender, EventArgs e)
    {
        this.Tbx_STime.Text = DateTime.Parse(this.Tbx_STime.Text).AddDays(-1).ToShortDateString();
        DateTime date = DateTime.Parse(this.Tbx_STime.Text);
        this.Lbl_Days.Text = "<font size='5'>" + date.ToShortDateString() + "  (" + base.Get_Chinese_Week(date) + ")  " +
                              GetUserName(this.UC_ddlCategroy.SelectedValue) + "</font>";
        this.ShowInfoByDateTime(this.Tbx_STime.Text);
    }

    protected void Lbl_Next_Click(object sender, EventArgs e)
    {
        this.Tbx_STime.Text = DateTime.Parse(this.Tbx_STime.Text).AddDays(1).ToShortDateString();
        DateTime date = DateTime.Parse(this.Tbx_STime.Text);
        this.Lbl_Days.Text = "<font size='5'>" + date.ToShortDateString() + "  (" + base.Get_Chinese_Week(date) + ")  " +
                             GetUserName(this.UC_ddlCategroy.SelectedValue) + "</font>";
        this.ShowInfoByDateTime(this.Tbx_STime.Text);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //清空查询附件数据
        KNet.BLL.PB_Basic_Attachment bllFile = new KNet.BLL.PB_Basic_Attachment();
        string SqlWhere = "";
        SqlWhere = "1!=1";
        DataSet ds_Comment = bllFile.GetList(SqlWhere);
        GridView_Comment.DataSource = ds_Comment.Tables[0];
        GridView_Comment.DataBind();

        //清空查询点评数据
        KNet.BLL.PB_Basic_Comment bllComment = new KNet.BLL.PB_Basic_Comment();
        string SqlWhere1 = "";
        SqlWhere1 = " 1!=1";
        DataSet ds_Comment1 = bllComment.GetList(SqlWhere1);
        MyGridView1.DataSource = ds_Comment1.Tables[0];
        MyGridView1.DataBind();
        //this.Btn_Create.Enabled = true;
        this.ShowInfoByDateTime(this.Tbx_STime.Text);
    }

    public string GetUserName(string FromPerson)
    {
        BasePage page = new BasePage();
        return page.Base_GetUserName(FromPerson);
    }

    /// <summary>
    /// 提交
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_OnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.PB_Basic_Comment BLL = new KNet.BLL.PB_Basic_Comment();
        KNet.Model.PB_Basic_Comment model = new KNet.Model.PB_Basic_Comment();
        model.PBC_FID = this.Tbx_NID.Text;
        model.PBC_Type = 24;//24代表一天，查询的是日报，168代表一周，查询的是周报，744代表的是一月，查询的是月报
        model.PBC_PresetCode = Convert.ToInt32(this.DdlPBC_Preset.SelectedValue);
        model.PBC_Description = this.txtDescription.Text;
        model.PBC_CTime = DateTime.Now;
        model.PBC_FromPerson = AM.KNet_StaffNo;
        try
        {
            BLL.Add(model);
            AM.Add_Logs("评论增加成功：编号：" + model.PBC_FID);
           
            AddComment.Visible = false;
            ShowInfoByDateTime(this.Tbx_STime.Text);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    /// <summary>
    /// 取消
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button3_OnClick(object sender, EventArgs e)
    {
        this.AddComment.Visible = false;
    }
    /// <summary>
    /// 新增评论按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_Create_OnClick(object sender, EventArgs e)
    {
        this.AddComment.Visible = true;
    }

    protected void DdlPBC_Preset_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        txtDescription.Text += DdlPBC_Preset.SelectedItem.Text;
    }
}

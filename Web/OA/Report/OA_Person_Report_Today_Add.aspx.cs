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
using System.IO;

public partial class OA_Person_Report_Add : BasePage
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
            base.Base_DropDutyPerson(this.Ddl_DutyPerson, true);
            this.Ddl_DutyPerson.Enabled = false;
            this.Lbl_Days.Text = "<font size='5'>" + DateTime.Now.ToShortDateString() + "  (" +
                                 base.Get_Chinese_Week(DateTime.Now) + ")  " + AM.KNet_StaffName + "</font>";
            this.Lbl_Pre.Text = "<font size='5'><</font>   ";
            this.Lbl_Next.Text = "<font size='5'>></font>   ";
            //this.Button1.Attributes.Add("onclick", "return confirm('你确定提交报告?！')");
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
                this.Btn_Save.Text = "提交";
                ShowInfo(s_ID);
            }
            else
            {
                this.Tbx_NID.Text = base.GetMainID();
                this.Lbl_Title.Text = "新增日报";

                //this.CommentList2.CommentFID = this.Tbx_NID.Text;
                //this.CommentList2.CommentType = "TotayReport";
                ShowInfoByDateTime(this.Tbx_STime.Text);
                AddUpload.Visible = false;
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
            this.Tbx_STime.Text = DateTime.Parse(model.OPR_STime.ToString()).ToShortDateString();
            this.Tbx_ThisReport.Text = model.OPR_ThisReport.ToString();
            this.Tbx_NextReport.Text = model.OPR_NextReport.ToString();
            this.Tbx_Type.Text = model.OPR_Type.ToString();

            //DateTime Dtm_Time = DateTime.Parse(this.Tbx_STime.Text).AddDays(-1);

            //DataSet Dts_Table1 = bll.GetList(" OPR_Stime='" + Dtm_Time.ToShortDateString() + "' and  OPR_Type='1' and OPR_State='1' and  OPR_DutyPerson='" + this.Ddl_DutyPerson.SelectedValue + "'");
            //if (Dts_Table1.Tables[0].Rows.Count > 0)
            //{
            //    //this.Lbl_ThisReport.Text = Dts_Table1.Tables[0].Rows[0]["OPR_NextReport"].ToString();
            //}
            //else
            //{
            //    //this.Lbl_ThisReport.Text = "";
            //}
            //ShowDetails(model.OPR_State);
            ShowInfoByDateTime(Tbx_STime.Text);
        }
    }

    private void ShowDetails(int i_State)
    {
        if (i_State == 0)
        {
            this.Tbx_ThisReport.Enabled = true;
            this.Tbx_NextReport.Enabled = true;
            this.Btn_Save.Text = "提交";
            this.Button1.Enabled = true;
            this.Btn_Save.Enabled = true;
            this.AddUpload.Visible = true;

        }
        if (i_State == 1)
        {
            this.Tbx_ThisReport.Enabled = true;
            this.Tbx_NextReport.Enabled = true;
            this.Btn_Save.Text = "提交";
            this.Button1.Enabled = true;
            this.Btn_Save.Enabled = true;
            this.AddUpload.Visible = true;
        }
        if (i_State == 2)
        {
            this.Tbx_ThisReport.Enabled = true;
            this.Tbx_NextReport.Enabled = false;
            this.Btn_Save.Text = "提交";
            this.Button1.Enabled = true;
            this.Btn_Save.Enabled = true;
            this.AddUpload.Visible = false;
        }
        if (i_State == 3)
        {
            this.Tbx_ThisReport.Enabled = false;
            this.Tbx_NextReport.Enabled = false;
            this.Btn_Save.Text = "提交";
            this.Button1.Enabled = false;
            this.Btn_Save.Enabled = false;
            this.AddUpload.Visible = false;
        }
        if (i_State == 4)
        {
            this.Tbx_ThisReport.Enabled = false;
            this.Tbx_NextReport.Enabled = false;
            this.Btn_Save.Text = "提交";
            this.Button1.Enabled = false;
            this.Btn_Save.Enabled = false;
            this.AddUpload.Visible = false;
        }
    }

    private void ShowInfoByDateTime(string s_DataTime)
    {
        int i_State = 0;
        KNet.BLL.PB_Basic_Attachment bllComment = new KNet.BLL.PB_Basic_Attachment();
        string SqlWhere = "";

        AdminloginMess AM = new AdminloginMess();


        KNet.BLL.OA_Person_Report bll = new KNet.BLL.OA_Person_Report();
        DataSet Dts_Table =
            bll.GetList(" OPR_Stime='" + s_DataTime + "'  and OPR_Type='1' and  OPR_DutyPerson='" +
                        this.Ddl_DutyPerson.SelectedValue + "' ");
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {

            this.Tbx_ID.Text = Dts_Table.Tables[0].Rows[0]["OPR_ID"].ToString();
            this.Tbx_NID.Text = Dts_Table.Tables[0].Rows[0]["OPR_ID"].ToString();
            //this.CommentList2.CommentFID = Dts_Table.Tables[0].Rows[0]["OPR_ID"].ToString();
            //this.CommentList2.CommentType = "TotayReport";
            this.Tbx_STime.Text =
                DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_STime"].ToString()).ToShortDateString();
            this.Tbx_ThisReport.Text = Dts_Table.Tables[0].Rows[0]["OPR_ThisReport"].ToString();
            this.Tbx_NextReport.Text = Dts_Table.Tables[0].Rows[0]["OPR_NextReport"].ToString();
            this.Tbx_Type.Text = Dts_Table.Tables[0].Rows[0]["OPR_Type"].ToString();
            i_State = int.Parse(Dts_Table.Tables[0].Rows[0]["OPR_State"].ToString());
            SqlWhere = " PBA_FID='" + this.Tbx_ID.Text + "' AND PBA_Type='DayFile' and PBA_Creator='" + AM.KNet_StaffNo +
                       "' order by PBA_CTime desc";
            DataSet ds_Comment = bllComment.GetList(SqlWhere);
            GridView_Comment.DataSource = ds_Comment.Tables[0];
            GridView_Comment.DataBind();
            //this.Btn_Create.Enabled = true;

        }
        else
        {
            this.Tbx_ID.Text = "";
            this.Tbx_NID.Text = base.GetMainID();

            this.Tbx_ThisReport.Text = "";
            this.Tbx_NextReport.Text = "";
            this.Tbx_Type.Text = "1";
            SqlWhere = "1!=1";
            DataSet ds_Comment = bllComment.GetList(SqlWhere);
            GridView_Comment.DataSource = ds_Comment.Tables[0];
            GridView_Comment.DataBind();
        }
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            //DateTime a = DateTime.Now;
            //DateTime c = DateTime.Now.Date;
            //DateTime b = DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_CTime"].ToString());
            if ((DateTime.Now - DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_CTime"].ToString())).TotalHours < 1)
            {
                ShowDetails(1); //当提交1小时之内，可以编辑今日计划
            }
            else if (DateTime.Now.Date == DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_CTime"].ToString()).Date)
            {
                ShowDetails(2); //是同一天，不可编辑今日计划
            }
            // if ((DateTime.Now - DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_CTime"].ToString())).TotalHours < 1)
            else
            {
                ShowDetails(3); //大于1小时，不可编辑今日计划
            }
        }
        else
        {
            if (DateTime.Now.Date != DateTime.Parse(s_DataTime).Date)
            {
                ShowDetails(4); //不是同一天
            }
            else
            {
                ShowDetails(0);
            }

        }
        //DateTime Dtm_Time = DateTime.Parse(s_DataTime).AddDays(-1);

        //DataSet Dts_Table1 = bll.GetList(" OPR_Stime='" + Dtm_Time.ToShortDateString() + "' and  OPR_Type='1' and  OPR_DutyPerson='"+this.Ddl_DutyPerson.SelectedValue+"'");
        //if (Dts_Table1.Tables[0].Rows.Count > 0)
        //{
        //    //this.Lbl_ThisReport.Text = Dts_Table1.Tables[0].Rows[0]["OPR_NextReport"].ToString();
        //}
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
            model.OPR_State = 1;
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

    /// <summary>
    /// 暂存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
        if (this.Tbx_ID.Text != "") //修改
        {
            DataSet Dts_Table =
                bll.GetList(" OPR_ID='" + this.Tbx_ID.Text + "'  and OPR_Type='1' and  OPR_DutyPerson='" +
                            this.Ddl_DutyPerson.SelectedValue + "' ");
            if (((DateTime.Now - DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_CTime"].ToString())).TotalHours > 1) &&
                (DateTime.Now.Date == DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_CTime"].ToString()).Date))
            {
                int a = 0, b = 0;
                try
                {
                    model.OPR_NextReport = Dts_Table.Tables[0].Rows[0]["OPR_NextReport"].ToString();
                    model.OPR_SubmitTime = DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_SubmitTime"].ToString());
                        //计划提交时间
                    //判断计划
                    if (Dts_Table.Tables[0].Rows[0]["OPR_NextReport"].ToString().Trim() == Tbx_NextReport.Text.Trim())
                    {

                    }
                    else
                    {
                        a = 1;
                        //Alert("今日计划已经超时无法更改");
                    }
                    //判断总结
                    if (Dts_Table.Tables[0].Rows[0]["OPR_ThisReport"].ToString().Trim() == Tbx_ThisReport.Text.Trim())
                    {
                        if (a == 1)
                        {
                            Alert("今日计划已经超时无法更改");
                        }
                    }
                    else
                    {

                        if (bll.Update(model))
                        {
                            if (a == 1)
                            {
                                Alert("今日计划已经超时无法更改!今日总结操作成功！");
                                AM.Add_Logs("日报修改" + this.Tbx_ID.Text);
                                return;
                            }
                            else
                            {
                                Alert("今日总结操作成功！");
                                AM.Add_Logs("日报修改" + this.Tbx_ID.Text);
                                return;
                            }


                        }
                        else
                        {
                            AM.Add_Logs("日报修改失败" + this.Tbx_ID.Text);
                            AlertAndRedirect("修改失败！", "OA_Person_Report_Today_Add.aspx?ID=" + this.Tbx_ID.Text + "");

                        }
                        //Alert("今日总结操作成功！但今日计划已经超过时限不可更改！");
                        //return;
                    }


                }
                catch
                {
                    AlertAndRedirect("系统错误！", "OA_Person_Report_Today_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }

            }
            else if (((DateTime.Now - DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_CTime"].ToString())).TotalHours < 1) &&
                     (DateTime.Now.Date == DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_CTime"].ToString()).Date))
            {
                int a = 0;
                try
                {
                    //model.OPR_NextReport = Dts_Table.Tables[0].Rows[0]["OPR_NextReport"].ToString();
                    //判断计划
                    if (Dts_Table.Tables[0].Rows[0]["OPR_NextReport"].ToString().Trim() == Tbx_NextReport.Text.Trim())
                    {
                        model.OPR_SubmitTime = DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_SubmitTime"].ToString());
                            //计划提交时间

                    }
                    else
                    {
                        model.OPR_MTime = DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_MTime"].ToString());
                        if (bll.Update(model))
                        {

                            a = 1;
                            AM.Add_Logs("日报修改" + this.Tbx_ID.Text);

                        }
                        else
                        {
                            AM.Add_Logs("日报修改失败" + this.Tbx_ID.Text);
                            AlertAndRedirect("修改失败！", "OA_Person_Report_Today_Add.aspx?ID=" + this.Tbx_ID.Text + "");

                        }
                    }
                    //判断总结
                    if (Dts_Table.Tables[0].Rows[0]["OPR_ThisReport"].ToString().Trim() == Tbx_ThisReport.Text.Trim())
                    {
                        if (a == 1)
                        {
                            Alert("今日计划操作成功！");
                            return;
                        }
                    }
                    else
                    {
                        //model.OPR_CTime = DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_CTime"].ToString());
                        //model.OPR_SubmitTime = DateTime.Parse(Dts_Table.Tables[0].Rows[0]["OPR_SubmitTime"].ToString());
                        model.OPR_MTime = DateTime.Now;
                        if (bll.Update(model))
                        {
                            if (a == 1)
                            {
                                Alert("今日计划操作成功！今日总结操作成功！");
                                AM.Add_Logs("日报修改" + this.Tbx_ID.Text);
                                return;
                            }
                            else
                            {
                                Alert("今日总结操作成功！");
                                AM.Add_Logs("日报修改" + this.Tbx_ID.Text);
                                return;
                            }

                        }
                        else
                        {
                            if (a == 1)
                            {
                                AM.Add_Logs("日报修改失败" + this.Tbx_ID.Text);
                                AlertAndRedirect("今日计划修改成功，今日总结修改失败！",
                                    "OA_Person_Report_Today_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                            }


                        }

                    }



                }
                catch
                {
                    AlertAndRedirect("系统错误！", "OA_Person_Report_Today_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }

            }
            else
            {
                Alert("已经超过时限不可再次编辑");
                return;
            }

        }
        else
        {

            try
            {
                if (this.Tbx_NextReport.Text == "")
                {
                    this.Tbx_NextReport.Text = "";
                    this.Tbx_ThisReport.Text = "";
                    Alert("今日计划没有书写，无法创建总结");


                }
                else
                {
                    bll.Add(model);
                    //base.Base_SendMessage(model.PBN_ReceiveID, "日报：<a href='Web/Notice/OA_Person_Report_View.aspx?ID=" + model.PBN_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
                    AM.Add_Logs("日报增加");
                    AlertAndRedirect("新增成功！", "OA_Person_Report_Today_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }

            }           
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
    /// <summary>
    /// 提交日志
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        //KNet.Model.OA_Person_Report model = new KNet.Model.OA_Person_Report();
        //KNet.BLL.OA_Person_Report bll = new KNet.BLL.OA_Person_Report();
        //AdminloginMess AM = new AdminloginMess();

        //if (this.SetValue(model) == false)
        //{
        //    Alert("系统错误！");
        //    return;
        //}

        //try
        //{
        //    model.OPR_State = 1;
        //    if (bll.Update(model))
        //    {
        //        AM.Add_Logs("日报提交" + this.Tbx_ID.Text);
        //        //base.Base_SendMessage(model.PBM_ID, "日报：<a href='Web/Notice/OA_Person_Report_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBM_ID + "</a> ");
        //        AlertAndRedirect("日报提交成功！", "OA_Person_Report_Today_Add.aspx?ID=" + this.Tbx_ID.Text + "");
        //    }
        //    else
        //    {
        //        AM.Add_Logs("日报修改失败" + this.Tbx_ID.Text);
        //        AlertAndRedirect("修改失败！", "OA_Person_Report_Today_Add.aspx?ID=" + this.Tbx_ID.Text + "");
        //    }
        //}
        //catch { }
        //Response.Redirect("NewDesk.aspx");
        //Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>location.href='NewDesk.aspx'</ script > ");
        Response.Write("<script language=javascript>location.href='/inc/NewDesk.aspx'</script>");
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
    public string GetUserName(string FromPerson)
    {
        BasePage page = new BasePage();
        return page.Base_GetUserName(FromPerson);
    }
    /// <summary>
    /// 新增附件按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_Create_OnClick(object sender, EventArgs e)
    {
        this.AddUpload.Visible = true;
    }
    /// <summary>
    /// 提交附件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_OnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.PB_Basic_Attachment model = new KNet.Model.PB_Basic_Attachment();
        string FileType = FileUpload1.PostedFile.ContentType.ToString(); //文件类型
        GetThumbnailImage1(model);
        try
        {
            KNet.BLL.PB_Basic_Attachment BLL = new KNet.BLL.PB_Basic_Attachment();
            BLL.Add(model);
            AM.Add_Logs("附件上传成功：编号：" + model.PBA_ID);
            AddUpload.Visible = false;
            Tbx_Name.Text = "";
            Tbx_Remarks.Text = "";
            //ShowInfoByDateTime(this.Tbx_STime.Text);
            //Tbx_Remarks.Text = "2";
            KNet.BLL.PB_Basic_Attachment bllComment = new KNet.BLL.PB_Basic_Attachment();
            string SqlWhere = " PBA_FID='" + this.Tbx_ID.Text + "' AND PBA_Type='DayFile' and PBA_Creator='" + AM.KNet_StaffNo + "' order by PBA_CTime desc";
            DataSet ds_Comment = bllComment.GetList(SqlWhere);
            GridView_Comment.DataSource = ds_Comment.Tables[0];
            GridView_Comment.DataBind();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    /// <summary>
    /// 取消
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button3_OnClick(object sender, EventArgs e)
    {
        this.AddUpload.Visible = false;
    }
    #region 资料上传操作
    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage1(KNet.Model.PB_Basic_Attachment model)
    {
        AdminloginMess AM = new AdminloginMess();
        //类别下面的
        string UploadPath = "/UpFile/" + Tbx_NID.Text + "/DayFile/";  //上传路径
        string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
        //string fileExt = Path.GetExtension(uploadFile1.PostedFile.FileName); //获扩展名
        string FileType = FileUpload1.PostedFile.ContentType.ToString(); //文件类型
        string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
        string filePath = UploadPath + AutoPath + "_" + FileName; //大文件名
        if (!Directory.Exists(Server.MapPath(UploadPath)))
        {
            Directory.CreateDirectory(Server.MapPath(UploadPath));
        }
        FileUpload1.PostedFile.SaveAs(Server.MapPath(filePath)); //上传

        model.PBA_FID = Tbx_NID.Text;
        model.PBA_Type = "DayFile";
        model.PBA_ID = GetMainID();
        model.PBA_Name = this.Tbx_Name.Text;
        model.PBA_URL = filePath;
        model.PBA_CTime = DateTime.Now;
        model.PBA_EndTime = DateTime.Now;
        model.PBA_Creator = AM.KNet_StaffNo;
        model.PBA_Remarks = this.Tbx_Remarks.Text;
    }
    #endregion
    public string GetCodeID()
    {
        string s_ID = "F";
        try
        {
            string s_Date = DateTime.Now.ToString("yyMMddhhmmss");
            Random rand = new Random();
            int RandKey = int.Parse(rand.Next(1000000, 9999999).ToString().Substring(4, 3));
            s_ID += s_Date + RandKey.ToString();
        }
        catch
        { }
        return s_ID;
    }
}

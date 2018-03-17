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

public partial class IM_Project_Manage_Add : BasePage
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
            this.Btn_Load.Attributes.Add("onclick", "return confirm('导入模板后会全部更新子项列表，原子项列表清除，是否继续？')");
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            this.Tbx_Stime.Text = DateTime.Now.ToShortDateString();
            if (s_DID != "")
            {
                //删除子项
                KNet.BLL.IM_Project_Manage_Details Bll_Details = new KNet.BLL.IM_Project_Manage_Details();
                if (Bll_Details.Delete(s_DID))
                {
                    AM.Add_Logs("项目子项 删除 编号：" + s_DID + "");
                    Alert("删除成功！");
                }
            }
            KNet.BLL.IM_Project_Template Bll = new KNet.BLL.IM_Project_Template();
            DataSet Dts_Table_Temp = Bll.GetList(" 1=1 ");
            this.Ddl_Template.DataSource = Dts_Table_Temp;
            this.Ddl_Template.DataValueField = "IPT_ID";
            this.Ddl_Template.DataTextField = "IPT_Name";
            this.Ddl_Template.DataBind();
            this.Tbx_Code.Text = base.GetNewID("IM_Project_Manage", 0);
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制项目";
                }
                else
                {
                    this.Lbl_Title.Text = "修改项目";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增项目";
                this.Tbx_NID.Text = GetMainID();
            }
        }
        ShowDetails();
    }
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.IM_Project_Manage bll = new KNet.BLL.IM_Project_Manage();
        KNet.Model.IM_Project_Manage model = bll.GetModel(s_ID);
        this.Tbx_Name.Text = model.IPM_Name;
        this.Ddl_DutyPerson.SelectedValue = model.IPM_DutyPerson;
        this.Ddl_Import.SelectedValue = model.IPM_Import;
        this.Tbx_ReceiveID.Text = model.IPM_Persons;
        this.Tbx_ReceiveName.Text = base.Base_GetUserNames(model.IPM_Persons);
        this.Ddl_Class.SelectedValue = model.IPM_Class;
        this.Ddl_Type.SelectedValue = model.IPM_Type;
        try
        {
            this.Tbx_Stime.Text = model.IPM_STime.ToShortDateString();
            this.Tbx_EndTime.Text = model.IPM_EndTime.ToShortDateString();
        }
        catch
        { }
        this.Tbx_Days.Text = model.IPM_Days.ToString();
        if (model.IPM_DaysType == "0")
        {
            this.RB_DaysType.Checked = true;
        }
        else if (model.IPM_DaysType == "1")
        {
            this.RB_DaysType1.Checked = true;
        }
        else if (model.IPM_DaysType == "2")
        {
            this.RB_DaysType2.Checked = true;
        }
        this.Ddl_State.SelectedValue = model.IPM_State;
        this.Tbx_Code.Text = model.IPM_Code;
        this.Tbx_CustomerName.Text = base.Base_GetCustomerName(model.IPM_CustomerValue);
        this.Tbx_CustomerID.Text = model.IPM_CustomerValue;
        this.Tbx_Money.Text = model.IPM_Money.ToString();
        if (model.IPM_IsDetailsMoney == 1)
        {
            this.Chk_IsDetailsMoney.Checked = true;
        }
        else
        {
            this.Chk_IsDetailsMoney.Checked = false;

        }
        this.Tbx_Remarks.Text = model.IPM_Remarks;
    }
    private string GetDetails(string s_ID)
    {
        StringBuilder Sb_Str = new StringBuilder();
        KNet.BLL.IM_Project_Manage_Details Bll = new KNet.BLL.IM_Project_Manage_Details();
        DataSet Dts_Table = Bll.GetList("  IPMD_FID='" + s_ID + "' order by IPMD_CTime");
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                string s_Name = Dts_Table.Tables[0].Rows[i]["IPMD_Name"].ToString();
                string s_Days = Dts_Table.Tables[0].Rows[i]["IPMD_Days"].ToString();
                string s_FloatDays = Dts_Table.Tables[0].Rows[i]["IPMD_FloatingDays"].ToString();
                string s_EarlyBeginTime = "暂无";
                if (Dts_Table.Tables[0].Rows[i]["IPMD_EarlyBeginTime"].ToString() != "")
                {
                    s_EarlyBeginTime = DateTime.Parse(Dts_Table.Tables[0].Rows[i]["IPMD_EarlyBeginTime"].ToString()).ToShortDateString();
                }

                string s_EarlyEndTime = "暂无";
                if (Dts_Table.Tables[0].Rows[i]["IPMD_EarlyEndTime"].ToString() != "")
                {
                    s_EarlyEndTime = DateTime.Parse(Dts_Table.Tables[0].Rows[i]["IPMD_EarlyEndTime"].ToString()).ToShortDateString();
                }

                string s_AtLatestBeginTime = "暂无";
                if (Dts_Table.Tables[0].Rows[i]["IPMD_AtLatestBeginTime"].ToString() != "")
                {
                    s_AtLatestBeginTime = DateTime.Parse(Dts_Table.Tables[0].Rows[i]["IPMD_AtLatestBeginTime"].ToString()).ToShortDateString();
                }

                string s_AtLatestEndTime = "暂无";
                if (Dts_Table.Tables[0].Rows[i]["IPMD_AtLatestEndTime"].ToString() != "")
                {
                    s_AtLatestEndTime = DateTime.Parse(Dts_Table.Tables[0].Rows[i]["IPMD_AtLatestEndTime"].ToString()).ToShortDateString();
                }

                string s_FTaskID = Dts_Table.Tables[0].Rows[i]["IPMD_FTaskID"].ToString();
                string s_FTaskName = "";
                KNet.Model.IM_Project_Manage_Details Model = Bll.GetModel(s_FTaskID);
                if (Model != null)
                {
                    s_FTaskName = Model.IPMD_Name == null ? "" : Model.IPMD_Name;
                }

                string s_Executor = Dts_Table.Tables[0].Rows[i]["IPMD_Executor"].ToString();
                string s_IPMDType = Dts_Table.Tables[0].Rows[i]["IPMD_Type"].ToString();

                string s_Image = "";
                if (s_IPMDType == "0")
                {
                    s_Image = "<img  style=\"cursor: pointer;\"  src=\"../../images/addsubNo.gif\"/>";
                }
                else
                {
                    s_Image = "<img  style=\"cursor: pointer;\" src=\"../../images/t1.gif\"/>";
                }
                string s_DID = Dts_Table.Tables[0].Rows[i]["IPMD_ID"].ToString();
                string s_FID = Dts_Table.Tables[0].Rows[i]["IPMD_IPMID"].ToString();
                string s_EditImage = "<a target=\"_blank\" href=\"Task/IM_Project_Manage_Details_Add.aspx?ID=" + s_DID + "\"><img  border=\"0\"  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../images/EditDetail.gif\"/></a>";
                string s_AddImage = "";
                if (s_IPMDType == "0")
                {
                    s_AddImage = "<a target=\"_blank\" href=\"Task/IM_Project_Manage_Details_Add.aspx?GID=" + s_DID + "&FID=" + s_FID + "\"><img border=\"0\"  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../images/addDetail.gif\"/></a>";
                }
                string s_DeleteImage = "";
                string s_Level = Dts_Table.Tables[0].Rows[i]["IPMD_Level"].ToString();
                string s_Head = "&nbsp;&nbsp;";
                if (s_Level != "")
                {
                    for (int j = 0; j < int.Parse(s_Level); j++)
                    {
                        s_Head += s_Head;
                    }
                }
                s_DeleteImage = "<a  href=\"IM_Project_Manage_Add.aspx?DID=" + s_DID + "\"><img border=\"0\"  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../images/deleteDetail.gif\"/></a>\n";
                Sb_Str.Append("<tr>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_Head + "" + s_Image + " " + s_Name + "</td>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_Days + "</td>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_FloatDays + "</td>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_EarlyBeginTime + "</td>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_EarlyEndTime + "</td>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_AtLatestBeginTime + "</td>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_AtLatestEndTime + "</td>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_FTaskName + "</td>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + base.Base_GetUserNames(s_Executor) + "</td>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_EditImage + "</td>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_AddImage + "</td>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_DeleteImage + "</td>\n");
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
        KNet.BLL.IM_Project_Manage_Details Bll = new KNet.BLL.IM_Project_Manage_Details();
        DataSet Dts_Table = Bll.GetList("  IPMD_IPMID='" + this.Tbx_Code.Text + "' and IPMD_FID='' order by IPMD_CTIme");
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                string s_Name = Dts_Table.Tables[0].Rows[i]["IPMD_Name"].ToString();
                string s_Days = Dts_Table.Tables[0].Rows[i]["IPMD_Days"].ToString();
                string s_FloatDays = Dts_Table.Tables[0].Rows[i]["IPMD_FloatingDays"].ToString();
                string s_EarlyBeginTime = "暂无";
                if (Dts_Table.Tables[0].Rows[i]["IPMD_EarlyBeginTime"].ToString() != "")
                {
                    s_EarlyBeginTime = DateTime.Parse(Dts_Table.Tables[0].Rows[i]["IPMD_EarlyBeginTime"].ToString()).ToShortDateString();
                }

                string s_EarlyEndTime = "暂无";
                if (Dts_Table.Tables[0].Rows[i]["IPMD_EarlyEndTime"].ToString() != "")
                {
                    s_EarlyEndTime = DateTime.Parse(Dts_Table.Tables[0].Rows[i]["IPMD_EarlyEndTime"].ToString()).ToShortDateString();
                }

                string s_AtLatestBeginTime = "暂无";
                if (Dts_Table.Tables[0].Rows[i]["IPMD_AtLatestBeginTime"].ToString() != "")
                {
                    s_AtLatestBeginTime = DateTime.Parse(Dts_Table.Tables[0].Rows[i]["IPMD_AtLatestBeginTime"].ToString()).ToShortDateString();
                }

                string s_AtLatestEndTime = "暂无";
                if (Dts_Table.Tables[0].Rows[i]["IPMD_AtLatestEndTime"].ToString() != "")
                {
                    s_AtLatestEndTime = DateTime.Parse(Dts_Table.Tables[0].Rows[i]["IPMD_AtLatestEndTime"].ToString()).ToShortDateString();
                }

                string s_FTaskID = Dts_Table.Tables[0].Rows[i]["IPMD_FTaskID"].ToString();
                string s_FTaskName = "";
                KNet.Model.IM_Project_Manage_Details Model = Bll.GetModel(s_FTaskID);
                if (Model != null)
                {
                    s_FTaskName = Model.IPMD_Name == null ? "" : Model.IPMD_Name;
                }

                string s_Executor = Dts_Table.Tables[0].Rows[i]["IPMD_Executor"].ToString();
                string s_IPMDType = Dts_Table.Tables[0].Rows[i]["IPMD_Type"].ToString();

                string s_Image = "";
                if (s_IPMDType == "0")
                {
                    s_Image = "<img  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../images/addsubNo.gif\"/>";
                }
                else
                {
                    s_Image = "<img  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../images/t1.gif\"/>";
                }
                string s_DID = Dts_Table.Tables[0].Rows[i]["IPMD_ID"].ToString();
                string s_FID = Dts_Table.Tables[0].Rows[i]["IPMD_IPMID"].ToString();
                string s_EditImage = "<a target=\"_blank\" href=\"Task/IM_Project_Manage_Details_Add.aspx?ID=" + s_DID + "\"><img  border=\"0\"  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../images/EditDetail.gif\"/></a>";
                string s_AddImage = "";
                if (s_IPMDType == "0")
                {
                    s_AddImage = "<a target=\"_blank\" href=\"Task/IM_Project_Manage_Details_Add.aspx?GID=" + s_DID + "&FID=" + s_FID + "\"><img border=\"0\"  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../images/addDetail.gif\"/></a>";
                }
                string s_DeleteImage = "";
                s_DeleteImage = "<a  href=\"IM_Project_Manage_Add.aspx?DID=" + s_DID + "\"><img border=\"0\"  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../images/deleteDetail.gif\"/></a>";
                Sb_Str.Append("<tr>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_Image + " " + s_Name + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_Days + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_FloatDays + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_EarlyBeginTime + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_EarlyEndTime + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_AtLatestBeginTime + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_AtLatestEndTime + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_FTaskName + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + base.Base_GetUserNames(s_Executor) + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_EditImage + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_AddImage + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_DeleteImage + "</td>");
                Sb_Str.Append("<tr>\n");
                if (GetDetails(s_DID) != "")
                {
                    Sb_Str.Append(GetDetails(s_DID));
                }
            }
        }
        this.Lbl_Details.Text = Sb_Str.ToString();
    }

    private bool SetValue(KNet.Model.IM_Project_Manage model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.IPM_ID = GetMainID();
            }
            else
            {
                model.IPM_ID = this.Tbx_ID.Text;
            }
            if (this.Tbx_ID.Text == "")
            {
                model.IPM_Code = base.GetNewID("IM_Project_Manage", 1);
            }
            else
            {
                model.IPM_Code = this.Tbx_Code.Text;
            }
            model.IPM_Name = this.Tbx_Name.Text;
            model.IPM_DutyPerson = this.Ddl_DutyPerson.SelectedValue;
            model.IPM_Import = this.Ddl_Import.SelectedValue.ToString();
            model.IPM_Persons = this.Tbx_ReceiveID.Text;
            model.IPM_Type = this.Ddl_Type.SelectedValue;
            model.IPM_Class = this.Ddl_Class.SelectedValue;
            try
            {
                model.IPM_STime = DateTime.Parse(this.Tbx_Stime.Text);
                model.IPM_EndTime = DateTime.Parse(this.Tbx_EndTime.Text);
            }
            catch
            {
                model.IPM_EndTime = DateTime.Parse("1900-01-01");
            }
            model.IPM_Days = int.Parse(this.Tbx_Days.Text);
            model.IPM_State = this.Ddl_State.SelectedValue;
            if (this.RB_DaysType.Checked)
            {
                model.IPM_DaysType = "0";
            }
            else if (this.RB_DaysType1.Checked)
            {
                model.IPM_DaysType = "1";
            }
            else if (this.RB_DaysType2.Checked)
            {
                model.IPM_DaysType = "2";
            }
            model.IPM_CustomerValue = this.Tbx_CustomerID.Text;
            model.IPM_Money = decimal.Parse(this.Tbx_Money.Text == "" ? "0" : this.Tbx_Money.Text);
            if (this.Chk_IsDetailsMoney.Checked)
            {
                model.IPM_IsDetailsMoney = 1;
            }
            else
            {
                model.IPM_IsDetailsMoney = 0;
            }
            model.IPM_Remarks = this.Tbx_Remarks.Text;
            model.IPM_Creator = AM.KNet_StaffNo;
            model.IPM_CTime = DateTime.Now;
            model.IPM_Mender = AM.KNet_StaffNo;
            model.IPM_MTime = DateTime.Now;
            return true;
        }
        catch
        {
            return false;
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
        }
        catch
        { }
        //更新所有 的计划开始和计划完成
        //先计算各个父节点的总工期
        string s_Sql = "Select * from IM_Project_Manage_Details a join IM_Project_Manage b on a.IPMD_IPMID=b.IPM_Code  where a.IPMD_Type='0' and b.IPM_ID='" + this.Tbx_ID.Text + "' order by IPMD_Level ";
        this.BeginQuery(s_Sql);
        DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
        for (int i = 0; i < Dtb_Table.Rows.Count; i++)
        {
            int i_TotalDays = GetSonsDays(Dtb_Table.Rows[i]["IPMD_ID"].ToString());
            string s_DoSql = "Update IM_Project_Manage_Details set IPMD_Days='" + i_TotalDays.ToString() + "' where IPMD_ID='" + Dtb_Table.Rows[i]["IPMD_ID"].ToString() + "'";
            DbHelperSQL.ExecuteSql(s_DoSql);
        }
        //重新填写计划开始日期和结束日期；
        GetTime("", DateTime.Parse(this.Tbx_Stime.Text), 0);
        AM.Add_Logs("更新天数：" + this.Tbx_ID.Text);
        Alert("重新计算交期和日期");
    }
    public void GetTime(string s_ID, DateTime D_STime, int i_Level)
    {
        try
        {
            DateTime D_BeginTime = DateTime.Now;
            DateTime D_EndTime = DateTime.Now;
            string s_Sql = "Select * from IM_Project_Manage_Details a join IM_Project_Manage b on a.IPMD_IPMID=b.IPM_Code  where a.IPMD_FID='" + s_ID + "'   order by IPMD_CTime ";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
            for (int i = 0; i < Dtb_Table.Rows.Count; i++)
            {
                if (i != 0)
                {
                    int i_Days = int.Parse(Dtb_Table.Rows[i]["IPMD_Days"].ToString());
                    D_BeginTime = D_EndTime;
                    D_EndTime = D_BeginTime.AddDays(i_Days - 1);
                }
                else
                {
                    D_BeginTime = D_STime;
                    int i_Days = int.Parse(Dtb_Table.Rows[i]["IPMD_Days"].ToString());
                    D_EndTime = D_BeginTime.AddDays(i_Days - 1);
                }
                //更新日期
                string s_DoSql = "Update IM_Project_Manage_Details set IPMD_EarlyBeginTime='" + D_BeginTime.ToShortDateString() + "',IPMD_EarlyEndTime='" + D_EndTime.ToShortDateString() + "' where IPMD_ID='" + Dtb_Table.Rows[i]["IPMD_ID"].ToString() + "'";
                DbHelperSQL.ExecuteSql(s_DoSql);
                GetTime(Dtb_Table.Rows[i]["IPMD_ID"].ToString(),D_BeginTime,i_Level+1);
            }
        }
        catch
        { }
    }
    public int GetSonsDays(string s_FID)
    {
        int i_Days = 0;
        //更新所有的工期
        try
        {
            string s_Sql = "select IPMD_FID,SUM(IPMD_Days) TotalDays from IM_Project_Manage_Details where IPMD_FID='" + s_FID + "' group by IPMD_FID ";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                //如果是
                i_Days = int.Parse(Dtb_Table.Rows[0]["TotalDays"].ToString());
            }
        }
        catch
        { }
        return i_Days;
    }
    protected void Btn_Send_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.IM_Project_Manage model = new KNet.Model.IM_Project_Manage();
        KNet.BLL.IM_Project_Manage bll = new KNet.BLL.IM_Project_Manage();

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
                    AM.Add_Logs("项目修改" + this.Tbx_ID.Text);
                    // base.Base_SendMessage(model.PPM_ID, "项目： <a href='Web/Notice/IM_Project_Manage_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
                    AlertAndRedirect("修改成功！", "IM_Project_Manage_List.aspx");

                }
                else
                {
                    AM.Add_Logs("项目修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "IM_Project_Manage_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            catch { }
        }
        else
        {

            try
            {
                bll.Add(model);
                //base.Base_SendMessage(model.PPM_ID, "项目： <a href='Web/Notice/IM_Project_Manage_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
                AM.Add_Logs("项目增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "IM_Project_Manage_List.aspx");
            }
            catch (Exception ex)
            {
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
        KNet.BLL.IM_Project_Manage_Details Bll_Details = new KNet.BLL.IM_Project_Manage_Details();
        if (Bll_Details.DeleteByFID(this.Tbx_Code.Text))
        {
            //base.Base_SendMessage(model.PPM_ID, "项目： <a href='Web/Notice/IM_Project_Manage_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
            AM.Add_Logs("项目删除明细" + this.Tbx_ID.Text);
        }
        if (Bll_Details.Load(this.Ddl_Template.SelectedValue, this.Tbx_Code.Text))
        {
            AM.Add_Logs("项目增加除明细" + this.Tbx_Code.Text);
            ShowDetails();
        }
    }
}

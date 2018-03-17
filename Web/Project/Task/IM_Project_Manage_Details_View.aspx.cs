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

public partial class IM_Project_Manage_Details_View : BasePage
{
    public string  s_OrderStyle = "", s_DetailsStyle = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
        this.CommentList2.CommentFID = s_ID;
        this.CommentList2.CommentType = "ProjectDetails";
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            this.Tbx_ID.Text = s_ID;
            this.Lbl_Title.Text = "查看项目";
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            try
            {
                ShowInfo(s_ID);
            }
            catch(Exception ex)
            { }
        }

    }

    private void ShowInfo(string s_ID)
    {

        KNet.BLL.IM_Project_Manage_Details bll = new KNet.BLL.IM_Project_Manage_Details();
        KNet.Model.IM_Project_Manage_Details model = bll.GetModel(s_ID);
        string s_Sql = "Select *,case when DateDiff(DAY,getdate(),IPMD_EarlyEndTime)<0 then 0 else DateDiff(DAY,getdate(),IPMD_EarlyEndTime) end   as LeftDays,DateDiff(DAY,IPMD_EarlyEndTime,getdate())  as HaveDays,case when DateDiff(DAY,getdate(),IPMD_EarlyEndTime)<0 then '+<font color=red>'+Cast(DateDiff(DAY, IPMD_EarlyEndTime, getdate()) as varchar(50))+'</font>' else  '0'  end OverDays from IM_Project_Manage_Details a join IM_Project_Manage b  on a.IPMD_IPMID=b.IPM_Code Where IPMD_Del=0 AND IPMD_Type='1' ";

        AdminloginMess AM = new AdminloginMess();
        if (s_ID != "")
        {
            s_Sql += " and IPMD_ID='" + s_ID + "' ";
        }
        s_Sql += " Order by IPMD_MTime";
        this.BeginQuery(s_Sql);
        DataSet ds = (DataSet)this.QueryForDataSet();
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "IPMD_ID" };
        GridView1.DataBind();
        ds.Dispose();
        if (model != null)
        {
            //this.Tbx_Code.Text = model;
            this.Tbx_Name.Text = model.IPMD_Name;
            this.Lbl_DutyPerson.Text = base.Base_GetUserName(model.IPMD_Executor);

            this.Lbl_Type.Text = base.Base_GetBasicCodeName("773", model.IPMD_ProjectType.ToString());
            //this.Lbl_Import.Text = base.Base_GetBasicCodeName("223", model.IPM_Import);
            //this.Lblx_ReceiveName.Text = base.Base_GetUserNames(model.IPM_Persons);
            //this.Lbl_Type.Text = base.Base_GetBasicCodeName("222", model.IPM_Type);
            try
            {
            //    this.Lbl_Stime.Text = DateTime.Parse(model.IPM_STime.ToString()).ToShortDateString();
            //    this.Lbl_EndTime.Text = DateTime.Parse(model.IPM_EndTime.ToString()).ToShortDateString();
            }
            catch
            { }
           // this.Lbl_Days.Text = model.IPM_Days.ToString();
            this.Lbl_Remarks.Text = model.IPMD_Remarks;
           // this.Lbl_Class.Text = base.Base_GetBasicCodeName("224", model.IPM_Class);
            ShowDetails();
        }
    }


    private string GetDetails(string s_ID)
    {
        StringBuilder Sb_Str = new StringBuilder();
        KNet.BLL.IM_Project_Manage_Details Bll = new KNet.BLL.IM_Project_Manage_Details();
        DataSet Dts_Table = Bll.GetList("  IPMD_FID='" + s_ID + "' order by IPMD_MTime");
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
                    s_EarlyBeginTime = DateTime.Parse(Dts_Table.Tables[0].Rows[i]["IPMD_EarlyEndTime"].ToString()).ToShortDateString();
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
                    s_Image = "<img  style=\"cursor: pointer;\"  src=\"../../../images/addsubNo.gif\"/>";
                }
                else
                {
                    s_Image = "<img  style=\"cursor: pointer;\" src=\"../../../images/t1.gif\"/>";
                }
                string s_DID = Dts_Table.Tables[0].Rows[i]["IPMD_ID"].ToString();
                string s_FID = Dts_Table.Tables[0].Rows[i]["IPMD_IPMID"].ToString();
                string s_EditImage = "<a target=\"_blank\" href=\"Details/IM_Project_Manage_Details_Add.aspx?ID=" + s_DID + "\"><img  border=\"0\"  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../../images/EditDetail.gif\"/></a>";
                string s_AddImage = "";
                if (s_IPMDType == "0")
                {
                    s_AddImage = "<a target=\"_blank\" href=\"Details/IM_Project_Manage_Details_Add.aspx?GID=" + s_DID + "&FID=" + s_FID + "\"><img border=\"0\"  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../../images/addDetail.gif\"/></a>";
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
                s_DeleteImage = "<a  href=\"IM_Project_Manage_Add.aspx?DID=" + s_DID + "\"><img border=\"0\"  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../../images/deleteDetail.gif\"/></a>\n";
                Sb_Str.Append("<tr>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_Head + "" + s_Image + " " + s_Name + "</td>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_FTaskName + "</td>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_Days + "</td>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_FloatDays + "</td>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_EarlyBeginTime + "</td>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_EarlyEndTime + "</td>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_AtLatestBeginTime + "</td>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_AtLatestEndTime + "</td>\n");
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
        DataSet Dts_Table = Bll.GetList("  IPMD_IPMID='" + this.Tbx_ID.Text + "' ");
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
                    s_Image = "<img  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../../images/addsubNo.gif\"/>";
                }
                else
                {
                    s_Image = "<img  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../../images/t1.gif\"/>";
                }
                string s_DID = Dts_Table.Tables[0].Rows[i]["IPMD_ID"].ToString();
                string s_FID = Dts_Table.Tables[0].Rows[i]["IPMD_IPMID"].ToString();
                string s_EditImage = "<a target=\"_blank\" href=\"Details/IM_Project_Manage_Details_Add.aspx?ID=" + s_DID + "\"><img  border=\"0\"  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../../images/EditDetail.gif\"/></a>";
                string s_AddImage = "";
                if (s_IPMDType == "0")
                {
                    s_AddImage = "<a target=\"_blank\" href=\"Details/IM_Project_Manage_Details_Add.aspx?GID=" + s_DID + "&FID=" + s_FID + "\"><img border=\"0\"  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../../images/addDetail.gif\"/></a>";
                }
                string s_DeleteImage = "";
                s_DeleteImage = "<a  href=\"IM_Project_Manage_Add.aspx?DID=" + s_DID + "\"><img border=\"0\"  style=\"cursor: pointer;\" onclick=\"comb(this,'p',531)\" src=\"../../../images/deleteDetail.gif\"/></a>";
                Sb_Str.Append("<tr>\n");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_Image + " " + s_Name + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_FTaskName + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_Days + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_FloatDays + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_EarlyBeginTime + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_AtLatestEndTime + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + base.Base_GetUserNames(s_Executor) + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_EditImage + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_AddImage + "</td>");
                Sb_Str.Append("<td class=\"ListHeadDetails\">" + s_DeleteImage + "</td>");

                Sb_Str.Append("<td>");
                Sb_Str.Append("<tr>\n");
                if (GetDetails(s_DID) != "")
                {
                    Sb_Str.Append(GetDetails(s_DID));
                }
            }
        }
        this.Lbl_Details.Text = Sb_Str.ToString();
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        //新增任务进度
        string s_Url = "IM_Project_Manage_Details_Add.aspx?FID=" + this.Tbx_ID.Text + "";
        Response.Write("<script language=\"javascript\">window.open('" + s_Url + "','子任务,\"toolbar=yes,location=no,directories=yes,status=yes,menubar=yes,resizable=yes,scrollbars=yes\");</script>");
    }
}

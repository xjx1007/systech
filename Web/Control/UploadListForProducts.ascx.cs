using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
using KNet.Common;
using System.Data;

public partial class UploadListForProducts : UserControl
{

    private string _CommentFID = "";
    private string _CommentType = "";

    public string CommentFID
    {
        get { return _CommentFID; }
        set { _CommentFID = value; }
    }

    public string CommentType
    {
        get { return _CommentType; }
        set { _CommentType = value; }
    }

    public string GetUserName(string FromPerson)
    {
        BasePage page = new BasePage();
        return page.Base_GetUserName(FromPerson);
    }

    public string GetBasicCode(string s_ID, string CodeName)
    {
        BasePage page = new BasePage();
        return page.Base_GetBasicCodeName(s_ID, CodeName);
    }


    protected void Page_PreRender(object sender, EventArgs e)
    {
        // 隐藏域——被新增点评按钮事件 btnGetReturnValue_onclick（） 调用
        if (CommentFID != "0")
        {

            if ((Tbx_CommentFID.Text == "0") || (Tbx_CommentFID.Text == ""))
            {
                Tbx_CommentFID.Text = CommentFID.ToString();
                Tbx_CommentType.Text = this.CommentType.ToString();
            }
            else if (Tbx_CommentFID.Text != CommentFID.ToString() && (Tbx_CommentFID.Text != "0") && (Tbx_CommentFID.Text != ""))
            {
                Tbx_CommentFID.Text = CommentFID.ToString();
                Tbx_CommentType.Text = this.CommentType.ToString();
            }

        }

        this.hidCommentFID.Value = Tbx_CommentFID.Text;
        this.hidCommentType.Value = Tbx_CommentType.Text;
        KNet.BLL.PB_Basic_Attachment bllComment = new KNet.BLL.PB_Basic_Attachment();
        AdminloginMess am = new AdminloginMess();
        string SqlWhere = "";
        if (CommentFID != "")
        {
            SqlWhere = " PBA_FID='" + this.hidCommentFID.Value + "' AND PBA_Type='" + this.hidCommentType.Value + "' and PBA_FID<>'0' ";

            if (am.KNet_StaffNo == "129785817148286974" || am.KNet_StaffName == "项洲")
            {
                if (Chk_Details.Checked == false)
                {
                    SqlWhere += " and PBA_Del=0 ";
                }
            }
            else
            {
                SqlWhere += " and PBA_Del=0 ";
            }
            SqlWhere += " order by PBA_ProductsType,PBA_CTime desc";
            DataSet ds_Comment = bllComment.GetList(SqlWhere);
            GridView_Comment.DataSource = ds_Comment.Tables[0];
            GridView_Comment.DataKeyNames = new string[] { "PBA_ID" };
            GridView_Comment.DataBind();
            this.Btn_Create.Visible = true;
        }
        else
        {
            SqlWhere = " PBA_FID='" + CommentFID + "' AND PBA_Type='" + CommentType + "' ";
            if (am.KNet_StaffNo == "129785817148286974" || am.KNet_StaffName == "项洲")
            {

                if (Chk_Details.Checked == false)
                {
                    SqlWhere += " and PBA_Del=0 ";
                }
            }
            else
            {
                SqlWhere += " and PBA_Del=0 ";
            }
            SqlWhere += " order by PBA_ProductsType,PBA_CTime desc";
            DataSet ds_Comment = bllComment.GetList(SqlWhere);
            GridView_Comment.DataSource = ds_Comment.Tables[0];
            GridView_Comment.DataKeyNames = new string[] { "PBA_ID" };
            GridView_Comment.DataBind();
            this.Btn_Create.Visible = false;
        }
    }

    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            LinkButton btnDownload = (LinkButton)e.Row.Cells[1].FindControl("btnDownload");
            string Id = this.GridView_Comment.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            KNet.BLL.PB_Basic_Attachment bllComment = new KNet.BLL.PB_Basic_Attachment();
            KNet.Model.PB_Basic_Attachment Model = bllComment.GetModel(Id);
            if ((Model.PBA_State == 0) || (Model.PBA_Del == 1) || (AM.YNAuthority("产品资料下载权限") == false))
            {
                btnDownload.Visible = false;
            }
            else
            {
                btnDownload.Visible = true;
            }
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmd = e.CommandName;
        string Id = e.CommandArgument.ToString();
        this.hidCommentFID.Value = this.hidCommentFID.Value;
        AdminloginMess am = new AdminloginMess();
        //这是调用的删除方法，根据标识列           RoomManager.DeleteRoomByRoomId(Id); 
        KNet.BLL.PB_Basic_Attachment bllComment = new KNet.BLL.PB_Basic_Attachment();
        KNet.Model.PB_Basic_Attachment Model = bllComment.GetModel(Id);
        if (cmd == "De1")
        {
            //if (am.KNet_StaffNo == Model.PBA_Creator)
            //
            if (am.KNet_StaffNo == "129785817148286974" || am.KNet_StaffName == "项洲")
            {
                bllComment.Delete(Id);
                am.Add_Logs("删除附件：" + Id);
            }
        }
        else if (cmd == "Download")
        {
            if (Model.PBA_URL != "")
            {
                string[] s_path = Model.PBA_URL.Split('.');
                if (s_path.Length > 1)
                {
                    string s_fileType = s_path[s_path.Length - 1];
                    string s_contentType = "";
                    switch (s_fileType.ToLower())
                    {
                        case "xls":
                            s_contentType = "application/vnd.ms-excel";
                            break;
                        case "xlsx":
                            s_contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            break;
                        case "csv":
                            s_contentType = "text/csv";
                            break;
                        case "doc":
                            s_contentType = "application/msword";
                            break;
                        case "docx":
                            s_contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                            break;
                        case "pdf":
                            s_contentType = "application/pdf";
                            break;
                        case "txt":
                            s_contentType = "text/plain";
                            break;
                        case "zip":
                            s_contentType = "application/x-zip-compressed";
                            break;
                        case "rar":
                            s_contentType = "application/octet-stream";
                            break;
                    }
                    Response.Clear();
                    Response.ContentType = s_contentType;

                    string filePath = "";
                    if (Model.PBA_URL.IndexOf(":") > 0)
                    {
                        filePath = Model.PBA_URL;
                    }
                    else
                    {
                        filePath = Server.MapPath(Model.PBA_URL);
                    }
                    string fileName = System.IO.Path.GetFileName(filePath);
                    am.Add_DownRecord(Id);
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
                    Response.Flush();
                    Response.WriteFile(filePath);
                }
            }
        }
        else if (cmd == "De")
        {
            //if (am.KNet_StaffNo == Model.PBA_Creator)
            //
            if (am.KNet_Position == "103" || am.KNet_StaffNo == "129785817148286974" || am.KNet_StaffName == "项洲" || (am.YNAuthority("停用产品资料")))
            {
                // bllComment.Delete(Id);
                if (Model.PBA_Del == 0)
                {
                    Model.PBA_Del = 1;
                    am.Add_Logs("停用附件：" + Id);
                }
                else
                {
                    Model.PBA_Del = 0;
                    am.Add_Logs("启用附件：" + Id);
                }
                bllComment.UpdateByDel(Model);
                Response.Flush();
            }
        }
        else if (cmd == "Sp")
        {
            //如果是审批
            if (am.KNet_StaffNo == "129785817148286974" || am.KNet_StaffName == "项洲" || am.KNet_Position == "103")
            {
                if (Model.PBA_State == 1)
                {
                    Model.PBA_State = 0;
                }
                else
                {
                    Model.PBA_State = 1;
                }
                if (bllComment.UpdateByState(Model))
                {
                    /*
                    //将停用相同的产品名称的附件
                    string s_Dosql = "update PB_Basic_Attachment set PBA_Del=1 where PBA_Name='" + Model.PBA_Name + "' and PBA_ID<>'"+Id+"' ";
                    DbHelperSQL.ExecuteSql(s_Dosql);
                    //将停用UPDateID
                     s_Dosql = "update PB_Basic_Attachment set PBA_Del=1 where  PBA_ID='" + Model.PBA_UpdateFID + "' ";
                    DbHelperSQL.ExecuteSql(s_Dosql);
                     * */
                    am.Add_Logs("审批产品文件：" + Id + "");
                    Response.Flush();

                }
            }
        }
    }

    public string GetAtt(string s_ProductsID)
    {
        BasePage base1 = new BasePage();
        return base1.Base_GetBasicCodeName("1133", s_ProductsID);
    }
}
using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Products_KNetSamplingListAdd : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(Web_Products_KNetSamplingListAdd));
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string id = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();

            string ReID = Request.QueryString["ReID"] == null ? "" : Request.QueryString["ReID"].ToString();
            string Instate = Request.QueryString["InState"] == null ? "" : Request.QueryString["InState"].ToString();
            string AuditState = Request.QueryString["AuditState"] == null ? "" : Request.QueryString["AuditState"].ToString();
            string SID = Request.QueryString["SID"] == null ? "" : Request.QueryString["SID"].ToString();
            if (ReID != "" && Instate != "")//更新入库状态
            {
                string DoSqlOrder = " update KNet_Sampling_List set  InState='" + Instate + "' where ReID='" + ReID + "' ";
                DbHelperSQL.ExecuteSql(DoSqlOrder);
                ShowInfo(SID);
                DateShow(SID);
            }
            if (ReID != "" && AuditState != "")//更新审核状态
            {
                if (AM.YNAuthority("审核请购单"))
                {
                    string DoSqlOrder = " update KNet_Sampling_List set  AuditState='" + AuditState + "' where ReID='" + ReID + "' ";
                    DbHelperSQL.ExecuteSql(DoSqlOrder);
                    ShowInfo(SID);
                    DateShow(SID);
                }
                else
                {
                    Response.Write(
                 "<script language=javascript>alert('您没有审核请购单的权限!')</script>");
                    ShowInfo(SID);
                    DateShow(SID);
                }
            }
            if (id != "")
            {
                this.Tbx_ID.Text = id;
                //this.tit.InnerText = "修改制造费用";
                //this.tit.InnerText = "修改制造费用";
                ShowInfo(id);
                DateShow(id);
            }
            if (SID != "")
            {
                this.Tbx_ID.Text = SID;
            }
            if (id == "")
            {
                this.Tbx_ID.Text = "YP" + string.Format("{0:yyyyMMddHHmm}", DateTime.Now);
            }

            SelectDataBind();
        }
    }
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.KNet_Sampling_List kNetSamplingList = new KNet.BLL.KNet_Sampling_List();

        KNet.Model.KNet_Sampling_List model = kNetSamplingList.GetModel(s_ID);
        this.Tbx_ID.Text = s_ID;
        this.EndTime.Text = model.EndTime.ToString();
        ProjectGroup.Enabled = false;
        BuyClass.Enabled = false;
        BuyRank.Enabled = false;
        BuyRank.SelectedValue = model.BuyRank;
        if (model.ProjectGroup == "")
        {
            //ProjectGroup.SelectedValue = "0";
        }
        else
        {
            ProjectGroup.SelectedValue = model.ProjectGroup;
        }

        //if (model.HouseClass!=null)
        //{
        BuyClass.SelectedValue = model.HouseClass;
        // }
        //BuyClass.SelectedValue = model.HouseClass;
        //this.Remark.Text = model.Remark.ToString();

    }

    private void SelectDataBind()
    {
        base.Base_DropBasicCodeBind(this.ProjectGroup, "1137");
        this.ProjectGroup.SelectedValue = "0";
        base.Base_DropBasicCodeBind(this.BuyRank, "1138");
        this.BuyRank.SelectedValue = "0";

        base.Base_DropBasicCodeBind(this.BuyClass, "1140");
        this.BuyClass.SelectedValue = "0";

    }

    protected void DateShow(string ID)
    {
        KNet.BLL.KNet_Sampling_List bll = new KNet.BLL.KNet_Sampling_List();
        string SqlWhere = " ID='" + ID + "'  ";
        SqlWhere = SqlWhere + " order by STime desc ";
        DataSet ds = bll.GetList1(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ReID" };
        GridView1.DataBind();
        ProjectGroup.Enabled = false;
        BuyClass.Enabled = false;
        BuyRank.Enabled = false;

    }

    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            KNet.BLL.KNet_Sampling_List Bll = new KNet.BLL.KNet_Sampling_List();

            string DirectInNo = GridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");

            KNet.Model.KNet_Sampling_List Model = Bll.GetModelByReID(DirectInNo);
            if (Model.InState != "0")
            {
                cb.Enabled = false;
            }
            else
            {
                cb.Enabled = true;
            }
        }
    }
    protected void Btn_Save_OnClick(object sender, EventArgs e)
    {
        //if (Tbx_ID.Text != "")
        //{
        //    AdminloginMess AM1 = new AdminloginMess();
        //    KNet.BLL.KNet_Sampling_List kNetSamplingList = new KNet.BLL.KNet_Sampling_List();
        //    KNet.Model.KNet_Sampling_List modelKNetSamplingList = new KNet.Model.KNet_Sampling_List();
        //    modelKNetSamplingList.ID = this.Tbx_ID.Text;
        //    modelKNetSamplingList.STime = DateTime.Now;
        //    modelKNetSamplingList.EndTime = Convert.ToDateTime(this.EndTime.Text);
        //    modelKNetSamplingList.SampleName = this.SampleName.Text;
        //    modelKNetSamplingList.Number = Convert.ToInt32(this.number.Text);
        //    modelKNetSamplingList.ProjectGroup = this.ProjectGroup.SelectedValue;
        //    modelKNetSamplingList.Packaging = this.Packaging.Text;
        //    modelKNetSamplingList.Remark = this.Remark.Text;
        //    modelKNetSamplingList.Proposer = AM1.KNet_StaffNo;
        //    //modelKNetSamplingList.UnitsElseMaterialsMoney = Convert.ToDecimal(this.Tbx_UnitsElseMaterialsMoney.Text);
        //    //modelKNetSamplingList.CountTime = Convert.ToDecimal(this.Tbx_CountTime.Text);
        //    modelKNetSamplingList.InState = "0";
        //    modelKNetSamplingList.BuyState = "0";
        //    modelKNetSamplingList.AuditState = "0";
        //    bool bl = kNetSamplingList.Update(modelKNetSamplingList);
        //    if (bl)
        //    {
        //       // AdminloginMess AM = new AdminloginMess();
        //        AM1.Add_Logs("修改样品申请成功" + modelKNetSamplingList.ID);
        //        AlertAndRedirect("修改样品申请成功！", "KNetSamplingList.aspx");
        //    }
        //}
        //else
        //{
        AdminloginMess AM1 = new AdminloginMess();
        KNet.BLL.KNet_Sampling_List kNetSamplingList = new KNet.BLL.KNet_Sampling_List();
        KNet.Model.KNet_Sampling_List modelKNetSamplingList = new KNet.Model.KNet_Sampling_List();
        if (this.ProjectGroup.SelectedValue == "" || BuyRank.SelectedValue == "" || this.BuyClass.SelectedValue == "" || this.SampleName.Text == "" || this.number.Text == "")
        {
            Response.Write("<script>alert('必选项不能为空！');history.back(-1);</script>");
            Response.End();
        }
        modelKNetSamplingList.ID = Tbx_ID.Text;
        //string sql = "select * from KNet_Sampling_List where ID='' and BuyState='1'";
        string s_Sql = "select * from KNet_Sampling_List where ID='" + Tbx_ID.Text + "' and BuyState='1'";
        this.BeginQuery(s_Sql);
        DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
        if (Dtb_Table.Rows.Count > 0)
        {
            Response.Write("<script>alert('已有部分已采购，请重新创建请购单！');history.back(-1);</script>");
            Response.End();
        }
        modelKNetSamplingList.ReID = "WPBH" + string.Format("{0:yyyyMMddHHmmss}", DateTime.Now);
        modelKNetSamplingList.UploadFile = UploadUrl.Text;
        modelKNetSamplingList.Price = 0;
        modelKNetSamplingList.BuyRank = BuyRank.SelectedValue;
        modelKNetSamplingList.STime = DateTime.Now;
        modelKNetSamplingList.EndTime = Convert.ToDateTime(this.EndTime.Text);
        modelKNetSamplingList.SampleName = this.SampleName.Text;
        modelKNetSamplingList.Number = Convert.ToInt32(this.number.Text);
        modelKNetSamplingList.ProjectGroup = this.ProjectGroup.SelectedValue;
        modelKNetSamplingList.HouseClass = this.BuyClass.SelectedValue;
        modelKNetSamplingList.Packaging = this.Packaging.Text;
        modelKNetSamplingList.Remark = this.Remark.Text;
        modelKNetSamplingList.Proposer = AM1.KNet_StaffNo;
        //modelKNetSamplingList.UnitsElseMaterialsMoney = Convert.ToDecimal(this.Tbx_UnitsElseMaterialsMoney.Text);
        //modelKNetSamplingList.CountTime = Convert.ToDecimal(this.Tbx_CountTime.Text);
        modelKNetSamplingList.InState = "0";
        modelKNetSamplingList.BuyState = "0";
        modelKNetSamplingList.AuditState = "0";
        bool bl = kNetSamplingList.Add(modelKNetSamplingList);
        if (bl)
        {
            //AdminloginMess AM = new AdminloginMess();
            AM1.Add_Logs("添加样品" + modelKNetSamplingList.ID);
            //AlertAndRedirect("新增样品申请成功！", "KNetSamplingList.aspx");
            Alert("新增请购申请成功");
            this.UploadUrl.Text = "";
            this.SampleName.Text = "";
            this.number.Text = "";
            this.Packaging.Text = "";
            this.Remark.Text = "";
            Lbl_Details1.Text = "";
            DateShow(Tbx_ID.Text);
        }

        //}

    }


    protected string GetAuditState(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select * from KNet_Sampling_List where ReID='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["AuditState"].ToString() == "0")
                {
                    //return "<font color=blue>未审核</font>";
                    string JSD = "KNetSamplingListAdd.aspx?ReID=" + aa + "&AuditState=2&SID=" + Tbx_ID.Text + "&ID=" + Tbx_ID.Text + "";
                    //return "<font color=red>审核中</font>";
                    return "<a href=\"" + JSD + "\" onclick=\"\"  ><font color=blue>未审核</font></a>";
                }

                else
                {
                    string JSD = "KNetSamplingListAdd.aspx?ReID=" + aa + "&AuditState=0&SID=" + Tbx_ID.Text + "&ID=" + Tbx_ID.Text + "";
                    return "<a href=\"" + JSD + "\" onclick=\"\"  ><font color=red>审核成功</font></a>";
                }
                //else
                //{
                //    string JSD = "KNetSamplingListAdd.aspx?ReID=" + aa + "&AuditState=0&SID=" + Tbx_ID.Text + "&ID=" + Tbx_ID.Text + "";
                //    return "<a href=\"" + JSD + "\" onclick=\"\"  ><font color=blue>未审核</font></a>";
                //    //return "<font color=red>审核失败</font>";
                //}
            }
            else
            {
                return "--";
            }
        }
    }
    protected string GetInState(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select * from KNet_Sampling_List where ReID='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["InState"].ToString() == "0")
                {
                    //string JSD = "KNetSamplingListAdd.aspx?ReID=" + aa + "&InState=1&SID=" + Tbx_ID.Text + "&ID=" + Tbx_ID.Text + "";
                    return "<a href=\"\" onclick=\"\"  ><font color=blue>未入库</font></a>";
                    //return "<font color=blue>未入库</font>";
                }
                else /*if (dr["InState"].ToString() == "1")*/
                {
                    //string JSD = "KNetSamplingListAdd.aspx?ReID=" + aa + "&InState=0&SID=" + Tbx_ID.Text + "&ID=" + Tbx_ID.Text + "";
                    return "<a href=\"\" onclick=\"\"  ><font color=red>已入库</font></a>";
                    //return "<font color=red> 已入库</font>";
                }

            }
            else
            {
                return "--";
            }
        }
    }
    protected string GetBuyStateYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select * from KNet_Sampling_List where ReID='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["BuyState"].ToString() == "0")
                {
                    return "<font color=blue>未采购</font>";
                }
                else
                {

                    return "<font color=red>已采购</font>";
                }

            }
            else
            {
                return "--";
            }
        }
    }
    protected string GetUploadFile(object aa)
    {
        //using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        //{
        //    conn.Open();
        //    string Dostr = "select UploadFile from KNet_Sampling_List where ReID='" + aa + "' ";
        //    SqlCommand cmd = new SqlCommand(Dostr, conn);
        //    SqlDataReader dr = cmd.ExecuteReader();
        KNet.BLL.KNet_Sampling_List kNetSamplingList = new KNet.BLL.KNet_Sampling_List();
        KNet.Model.KNet_Sampling_List model = kNetSamplingList.GetModelByReID(aa.ToString());
        if (model.UploadFile.ToString() != "")
        {

            return "<font color=blue>下载</font>";
        }
        else
        {
            return "";
        }
        //}
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmd = e.CommandName;
        string Id = e.CommandArgument.ToString();
        //this.hidCommentFID.Value = this.hidCommentFID.Value;
        AdminloginMess am = new AdminloginMess();
        //这是调用的删除方法，根据标识列           RoomManager.DeleteRoomByRoomId(Id); 
        KNet.BLL.KNet_Sampling_List bllComment = new KNet.BLL.KNet_Sampling_List();
        KNet.Model.KNet_Sampling_List Model = bllComment.GetModelByReID(Id);

        if (cmd == "Download")
        {
            if (Model.UploadFile != "")
            {
                string[] s_path = Model.UploadFile.Split('.');
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
                    if (Model.UploadFile.IndexOf(":") > 0)
                    {
                        filePath = Model.UploadFile;
                    }
                    else
                    {
                        filePath = Server.MapPath(Model.UploadFile);
                    }
                    string fileName = System.IO.Path.GetFileName(filePath);
                    am.Add_DownRecord(Id);
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
                    Response.Flush();
                    Response.WriteFile(filePath);
                }
            }
        }

    }

    protected void button_ServerClick2(object sender, EventArgs e)
    {
        if (!(uploadFile2.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            //string FileType = uploadFile1.PostedFile.ContentType.ToString(); //文件类型
            //GetThumbnailImage1();
            string UploadPath = "../../UpFile/QGInfo/";  //上传路径
                                                         //if (this.CustomerValue.Value != "")
                                                         //{
                                                         //    UploadPath += this.CustomerValue.Value + "/";
                                                         //}
            string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
            string fileExt = Path.GetExtension(uploadFile2.PostedFile.FileName); //获扩展名
            string FileType = uploadFile2.PostedFile.ContentType.ToString(); //文件类型
            string FileName = Path.GetFileName(uploadFile2.PostedFile.FileName);
            string filePath = UploadPath + AutoPath + fileExt;
            if (!Directory.Exists(Server.MapPath(UploadPath)))
            {
                Directory.CreateDirectory(Server.MapPath(UploadPath));
            }
            uploadFile2.PostedFile.SaveAs(Server.MapPath(filePath)); //上传
            this.Lbl_Details1.Text = "<input Name=\"KPS_InvoiceUrl\"  type=\"hidden\"  value=" + filePath + "><input Name=\"KPS_Invoice\"  type=\"hidden\"  value=" + FileName + "><a href=\"" + filePath + "\" >" + FileName + "</a>";
            this.UploadUrl.Text = filePath;
            this.Lbl_Details1.Text = FileName;
        }
    }

    protected void btn_Chcek_OnClick(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {

                KNet.BLL.KNet_Sampling_List BLL = new KNet.BLL.KNet_Sampling_List();
                bool a = BLL.Delete1(GridView1.DataKeys[i].Value.ToString());
                if (a)
                {
                    AdminloginMess LogAM = new AdminloginMess();
                    LogAM.Add_Logs("制造费用 删除 操作成功！");
                    Alert("删除成功");
                    this.DateShow(Tbx_ID.Text);
                    //this.RowOverYN();
                }
                else
                {
                    Alert("删除失败");
                }
            }
        }
    }
}
using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using KNet.BLL;
using KNet_Sampling_List = KNet.Model.KNet_Sampling_List;

public partial class Web_Products_UploadKNetSampling : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Web_Products_UploadKNetSampling));
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write(
                    "<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string id = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            Tbx_ID.Text = id;
            SelectDataBind();
            DateShow(id);
        }

    }

    protected void DateShow(string ID)
    {
        KNet.BLL.KNet_Sampling_List bll = new KNet.BLL.KNet_Sampling_List();
        KNet.Model.KNet_Sampling_List model = new KNet_Sampling_List();
        string SqlWhere = " ID='" + ID + "' and AuditState!='2'  ";
        SqlWhere = SqlWhere + " order by STime desc ";
        DataSet ds = bll.GetList1(SqlWhere);
        if (ds.Tables[0].Rows.Count>0)
        {
            EndTime.Text = ds.Tables[0].Rows[0]["EndTime"].ToString();
            BuyRank.SelectedValue = ds.Tables[0].Rows[0]["BuyRank"].ToString();
            ProjectGroup.SelectedValue = ds.Tables[0].Rows[0]["ProjectGroup"].ToString();
            BuyClass.SelectedValue = ds.Tables[0].Rows[0]["HouseClass"].ToString();
            GridView1.DataSource = ds;
            GridView1.DataKeyNames = new string[] { "ReID" };
            GridView1.DataBind();
        }
        else
        {
            AlertAndRedirect("此单已审核，不能修改", "KNetSamplingListAdd.aspx?ID=" + Tbx_ID.Text + "");
        }


    }

    private void SelectDataBind()
    {
        base.Base_DropBasicCodeBind(this.ProjectGroup, "1137");
        //this.ProjectGroup.SelectedValue = "0";
        base.Base_DropBasicCodeBind(this.BuyRank, "1138");
        //this.BuyRank.SelectedValue = "0";

        base.Base_DropBasicCodeBind(this.BuyClass, "1140");
        //this.BuyClass.SelectedValue = "0";

    }

    protected void Btn_Save_OnClick(object sender, EventArgs e)
    {

        AdminloginMess AM1 = new AdminloginMess();
        KNet.BLL.Knet_Sampling_OpenBilling Bll=new Knet_Sampling_OpenBilling();
        KNet.Model.Knet_Sampling_OpenBilling model=new KNet.Model.Knet_Sampling_OpenBilling();
        KNet.BLL.KNet_Sampling_List kNetSamplingList = new KNet.BLL.KNet_Sampling_List();
        KNet.Model.KNet_Sampling_List modelKNetSamplingList = new KNet.Model.KNet_Sampling_List();
        try
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                TextBox SampleName = (TextBox)GridView1.Rows[i].Cells[0].FindControl("SampleName1");
                TextBox Number = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Number1");
                TextBox Packaging = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Packaging1");
                TextBox Remark = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Remark1");
                TextBox ID = (TextBox)GridView1.Rows[i].Cells[0].FindControl("ID");
                TextBox ReID = (TextBox)GridView1.Rows[i].Cells[0].FindControl("ReID");
                TextBox Price1 = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Price1");
                modelKNetSamplingList.ID = ID.Text;
                ;
                modelKNetSamplingList.ReID = ReID.Text;
                modelKNetSamplingList.STime = DateTime.Now;
                modelKNetSamplingList.EndTime = Convert.ToDateTime(this.EndTime.Text);
                modelKNetSamplingList.BuyRank = BuyRank.SelectedValue;
                modelKNetSamplingList.ProjectGroup = ProjectGroup.SelectedValue;
                modelKNetSamplingList.HouseClass = BuyClass.SelectedValue;

                modelKNetSamplingList.SampleName = SampleName.Text;

                //int a= int.Parse(GridView1.Rows[i].Cells[7].Text.Trim());
                modelKNetSamplingList.Number = int.Parse(Number.Text);
                modelKNetSamplingList.ProjectGroup = this.ProjectGroup.SelectedValue;

                modelKNetSamplingList.Packaging = Packaging.Text;
                modelKNetSamplingList.Price = decimal.Parse(Price1.Text);
                modelKNetSamplingList.Remark = Remark.Text;
                modelKNetSamplingList.Proposer = AM1.KNet_StaffNo;
                //modelKNetSamplingList.UnitsElseMaterialsMoney = Convert.ToDecimal(this.Tbx_UnitsElseMaterialsMoney.Text);
                //modelKNetSamplingList.CountTime = Convert.ToDecimal(this.Tbx_CountTime.Text);
                modelKNetSamplingList.InState = "0";
                modelKNetSamplingList.BuyState = "0";
                modelKNetSamplingList.AuditState = "0";
                model.RState = "0";
                model.SamplingName = SampleName.Text;
                model.ReID = ReID.Text;
                model.Number = int.Parse(Number.Text);
                model.Price = decimal.Parse(Price1.Text);
                model.Department = this.ProjectGroup.SelectedValue;
                model.Remark = Remark.Text;
                kNetSamplingList.Update(modelKNetSamplingList);
                Bll.Update(model);
            }
            AlertAndRedirect("请购入库开单 添加  操作成功", "KNetSamplingListAdd.aspx?ID="+ Tbx_ID.Text + "");
        }
        catch(Exception ex)
        {
            //throw ex;
            //Response.Write("<script>alert('部分修改失败！');history.back(-1);</script>");
            //Response.End();

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

    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            KNet.BLL.KNet_Sampling_List Bll = new KNet.BLL.KNet_Sampling_List();

            string DirectInNo = GridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");

            //KNet.Model.KNet_Sampling_List Model = Bll.GetModelByReID(DirectInNo);
            //if (Model.BuyState != "0")
            //{
            //    cb.Enabled = false;
            //}
            //else
            //{
            //    cb.Enabled = true;
            //}
        }
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
}
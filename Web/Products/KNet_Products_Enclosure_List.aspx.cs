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
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Data.SqlClient;

using KNet.DBUtility;
using KNet.Common;


/// <summary>
/// 仓库管理
/// </summary>
public partial class KNet_Products_Enclosure_List : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            Tbx_Productstype.Text = AM.ProductsType;
            this.Lbl_Title.Text = "产品资料";
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            //产品字典删除
            if (AM.YNAuthority("删除产品资料") == false)
            {
                this.Btn_Del.Enabled = false;
            }
            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");
            BuildTree("1", null);
            this.TreeView1.CollapseAll();
            this.TreeView1.Nodes[0].Expand();
            this.TreeView1.Nodes[0].Select();

            base.Base_DropBindSearch(this.bas_searchfield, "PB_Basic_Attachment");
            base.Base_DropBindSearch(this.Fields, "PB_Basic_Attachment");
            this.DataShows();
            this.RowOverYN();
        }

    }

    public void BuildTree(string s_ID, TreeNode tree)
    {
        try
        {
            KNet.BLL.PB_Basic_ProductsClass Bll = new KNet.BLL.PB_Basic_ProductsClass();
            TreeNode treeMainNode = new TreeNode();
            KNet.BLL.PB_Basic_ProductsClass bll = new KNet.BLL.PB_Basic_ProductsClass();
            if (tree == null)
            {
                KNet.Model.PB_Basic_ProductsClass Model = bll.GetModel("1");
                this.TreeView1.Nodes.Clear();
                treeMainNode.Text = Model.PBP_Name;
                treeMainNode.Value = Model.PBP_ID;
                this.TreeView1.Nodes.Add(treeMainNode);
            }
            else
            {
                treeMainNode = tree;
            }


            DataSet Dts_Table = null;
            if (s_ID == "M160818111423567")//如果是采购类产品
            {
                Dts_Table = bll.GetList(" PBP_FaterID='" + s_ID + "'   order by PBP_Order");
            }
            else if (s_ID == "M160818111359632")//如果是销售类产品
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDs(Tbx_Productstype.Text);
                s_SonID = s_SonID.Replace(",", "','");
                string s_Sql = " PBP_FaterID='" + s_ID + "' and PBP_ID in ('" + Tbx_Productstype.Text + "','" + s_SonID + "')  order by PBP_Order";
                Dts_Table = bll.GetList(s_Sql);
            }
            else
            {

                Dts_Table = bll.GetList(" PBP_FaterID='" + s_ID + "'  order by PBP_Order");
            }





            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    TreeNode treeNode1 = new TreeNode();
                    treeNode1.Text = Dts_Table.Tables[0].Rows[i]["PBP_Name"].ToString();
                    treeNode1.Value = Dts_Table.Tables[0].Rows[i]["PBP_ID"].ToString();
                    treeMainNode.ChildNodes.Add(treeNode1);
                    BuildTree(Dts_Table.Tables[0].Rows[i]["PBP_ID"].ToString(), treeNode1);
                }
            }
        }
        catch
        { }
    }


    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }

    /// <summary>
    /// 是不是有记录
    /// </summary>
    protected void RowOverYN()
    {
        if (GridView1.Rows.Count == 0) //如果没有记录
        {
            this.Btn_Del.Enabled = false;
        }
        else
        {
            this.Btn_Del.Enabled = true;
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.PB_Basic_Attachment bll = new KNet.BLL.PB_Basic_Attachment();
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";

        string s_Sql = "select * from PB_Basic_Attachment a join KNET_Sys_Products b on a.PBA_FID=b.ProductsBarCode where PBA_Type='Products' ";
        string SqlWhere = "  ";
        AdminloginMess AM = new AdminloginMess();

        if (s_WhereID != "")
        {
            SqlWhere += Base_GetBasicWhere(s_WhereID);
        }

        if ((this.bas_searchfield.SelectedValue != "") && (search_text.Text != ""))
        {
            SqlWhere += base.Base_GetBasicColumnWhere(this.bas_searchfield.SelectedValue, this.search_text.Text);
        }
        if (s_Text != "")
        {
            if (this.matchtype1.Checked == true)//and
            {
                s_Type = "0";
            }
            if (this.matchtype2.Checked == true)
            {
                s_Type = "1";
            }
            SqlWhere += base.Base_GetAdvWhere(s_Fields, s_Condition, s_Text, s_Type);
        }

        if (this.TreeView1.SelectedNode.Value != "1")
        {
            KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
            string s_SonID = Bll_ProductsDetails.GetSonIDs(this.TreeView1.SelectedNode.Value);
            s_SonID = s_SonID.Replace(",", "','");
            SqlWhere += " and ProductsType in ('" + s_SonID + "') ";
        }
        SqlWhere += " order BY PBA_CTime desc ";

        this.BeginQuery(s_Sql + SqlWhere);
        DataSet ds = (DataSet)this.QueryForDataSet();
        // DataSet ds = bll.GetList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "PBA_ID" };
        GridView1.DataBind();
    }


    /// <summary>
    /// 返回大类名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetBigCateNane(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,BigNo,CateName from KNet_Sys_BigCategories where BigNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["CateName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }


    protected void Btn_Del_Click(object sender, EventArgs e)
    {

        AdminloginMess am = new AdminloginMess();
        if (am.KNet_StaffNo == "129785817148286974" || am.KNet_StaffName == "项洲")
        {
            string sql = "delete from PB_Basic_Attachment where";
            string cal = "";
            string s_BarCode = "";
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (cb.Checked == true)
                {
                    cal += " PBA_ID='" + GridView1.DataKeys[i].Value.ToString() + "' or";
                }
            }
            if (cal != "")
            {
                sql += cal.Substring(0, cal.Length - 3);
            }
            else
            {
                sql = "";       //不删除
                Response.Write("<script language=javascript>alert('您没有选择要删除的记录!');history.back(-1);</script>");
                Response.End();
            }
            DbHelperSQL.ExecuteSql(sql);
            AdminloginMess LogAM = new AdminloginMess();
            LogAM.Add_Logs("系统设置--->产品附件删除 操作成功！" + cal);
            Alert("删除成功！");
            this.DataShows();
            this.RowOverYN();
        }
    }
    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }
    public string BaseGetIC(string s_ProductsBarCode)
    {
        string s_Return = "-";
        this.BeginQuery("Select top 1 * from Xs_Products_Prodocts a join KNet_Sys_Products b on a.XPP_ProductsBarCode=b.ProductsBarCode where XPP_FaterBarCode='" + s_ProductsBarCode + "' and b.ProductsMainCategory='129682169809390852' ");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            s_Return = Dtb_Result.Rows[0]["ProductsEdition"].ToString();
        }
        return s_Return;
    }

    public void btnBasicSearch_Click(object sender, EventArgs e)
    {
        this.advSearch.Style["display"] = "none";
        this.Search_basic.Style["display"] = "block";
        this.DataShows();
    }
    public void btnAdvancedSearch_Click(object sender, EventArgs e)
    {
        this.Search_basic.Style["display"] = "none";
        this.advSearch.Style["display"] = "block";

        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string[] arr_Fields = s_Fields.Split(',');
        string[] arr_Condition = s_Condition.Split(',');
        string[] arr_Text = s_Text.Split(',');
        this.Fields.SelectedValue = arr_Fields[0];
        this.Condition.SelectedValue = arr_Condition[0];
        this.Srch_value.Text = arr_Text[0];
        s_AdvShow = Base_GetAdvShowHtml(arr_Fields, arr_Condition, arr_Text);
        this.DataShows();
    }


    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            LinkButton btnDownload = (LinkButton)e.Row.Cells[1].FindControl("btnDownload");
            string Id = this.GridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            KNet.BLL.PB_Basic_Attachment bllComment = new KNet.BLL.PB_Basic_Attachment();
            KNet.Model.PB_Basic_Attachment Model = bllComment.GetModel(Id);
            if ((Model.PBA_State == 0) || (Model.PBA_Del == 1))
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
        //  this.hidCommentFID.Value = this.hidCommentFID.Value;
        AdminloginMess am = new AdminloginMess();
        //这是调用的删除方法，根据标识列           RoomManager.DeleteRoomByRoomId(Id); 
        KNet.BLL.PB_Basic_Attachment bllComment = new KNet.BLL.PB_Basic_Attachment();
        KNet.Model.PB_Basic_Attachment Model = bllComment.GetModel(Id);
        if (cmd == "De")
        {
            //if (am.KNet_StaffNo == Model.PBA_Creator)
            //
            if (am.KNet_StaffNo == "129785817148286974" || am.KNet_StaffName == "项洲" || am.KNet_Position == "103" || (am.YNAuthority("停用产品资料")))
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
                AlertAndRedirect("操作成功！", "KNet_Products_Enclosure_List.aspx?Where=M160707014101612");
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
        else if (cmd == "Sp")
        {
            //如果是审批
            if (am.KNet_StaffNo == "129785817148286974" || am.KNet_StaffName == "项洲"||am.KNet_Position=="103")
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
                    AlertAndRedirect("审批成功！", "KNet_Products_Enclosure_List.aspx?Where=M160707014101612");
                }
            }
        }
    }
    public string GetName(string s_ProductsID)
    {
        KNet.BLL.PB_Basic_Attachment Bll_Attachment = new KNet.BLL.PB_Basic_Attachment();
        KNet.Model.PB_Basic_Attachment Model_Att = Bll_Attachment.GetModel(s_ProductsID);
        if (Model_Att != null)
        {
            return "<font color=red>是</font>";
        }
        else
        {
            return "<font color=blue>否</font>";
        }

    }

}

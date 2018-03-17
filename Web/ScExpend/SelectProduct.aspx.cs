using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;



public partial class Web_ScExpend_SelectProduct : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "产品选择";

        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
           
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                string s_ProductsMainCategroy = Request.QueryString["ProductsMainCategroy"] == null ? "" : Request.QueryString["ProductsMainCategroy"].ToString();
                string s_KSP_SampleId = Request.QueryString["KSP_SampleId"] == null ? "" : Request.QueryString["KSP_SampleId"].ToString();
                this.Tbx_KSP_SampleId.Text = s_KSP_SampleId;
                BuildTree("1", null);
                this.TreeView1.CollapseAll();
                this.TreeView1.Nodes[0].Expand();
                this.TreeView1.Nodes[0].Select();
                this.DataShows();
            }
        }
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sys_Products bll = new KNet.BLL.KNet_Sys_Products();
        string SqlWhere = " 1=1 and ksp_del=0 ";

        if (this.SeachKey.Text != "")
        {
            SqlWhere = SqlWhere + " and ( ProductsName like '%" + this.SeachKey.Text + "%' or ProductsBarCode  like '%" + this.SeachKey.Text + "%' or ProductsPattern  like '%" + this.SeachKey.Text + "%' or KSP_Code  like '%" + this.SeachKey.Text + "%' )";
        }
        if (this.TreeView1.SelectedNode.Value != "1")
        {
            KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
            string s_SonID = Bll_ProductsDetails.GetSonIDs(this.TreeView1.SelectedNode.Value);
            s_SonID = s_SonID.Replace(",", "','");
            SqlWhere += " and ProductsType in ('" + s_SonID + "') ";
        }

        DataSet ds = bll.GetList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();

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
                KNet.Model.PB_Basic_ProductsClass Model = bll.GetModel(s_ID);
                this.TreeView1.Nodes.Clear();
                treeMainNode.Text = Model.PBP_Name;
                treeMainNode.Value = Model.PBP_ID;
                this.TreeView1.Nodes.Add(treeMainNode);
            }
            else
            {
                treeMainNode = tree;
            }

            DataSet Dts_Table = bll.GetList(" PBP_FaterID='" + s_ID + "'");


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
    /// <summary>
    /// 确定选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        int i_Num = 0;
        string s_Return = "";
        string s_TProductsBarCode = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked)
            {
                string s_ProductsEdition = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Edition")).Text;
                string s_ProductsPattern = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Pattern")).Text;
                string s_ProductsBarCode = GridView1.Rows[i].Cells[3].Text;
                s_TProductsBarCode = GridView1.Rows[i].Cells[3].Text;
                string KSP_Code = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("TXB_KSP_COde")).Text; ;
                string ProductName= ((TextBox)GridView1.Rows[i].Cells[0].FindControl("TXB_ProductsName")).Text;
                ;
                //string ProductsBarCode = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("TXB_ProductsBarCode")).Text;
                string s_Code = "SP" + s_ProductsEdition + "V1" + "001";
                string TXB_KSP_COde_Hidden= ((TextBox)GridView1.Rows[i].Cells[0].FindControl("TXB_KSP_COde_Hidden")).Text; ;
                s_Return = s_ProductsEdition + "," + ProductName + "," + TXB_KSP_COde_Hidden + "," + s_ProductsPattern + "," + s_ProductsBarCode + ","+KSP_Code+"," + s_Code;
                i_Num++;
            }

        }
        if (i_Num == 0)
        {
            if (this.Tbx_KSP_SampleId.Text != "")
            {
                StringBuilder s = new StringBuilder();
                s.Append("<script language=javascript>" + "\n");
                if (this.Tbx_KSP_SampleId.Text != "")
                {
                    string s_DoSql = "Update KNet_Sys_Products set KSP_SampleId='' where KSP_SampleId='" + this.Tbx_KSP_SampleId.Text + "'";
                    DbHelperSQL.ExecuteSql(s_DoSql);
                    s.Append("alert('取消成功！');" + "\n");
                }
                AM.Add_Logs("样品取消成功：样品编号：" + this.Tbx_KSP_SampleId.Text);
                s.Append("window.close();" + "\n");
                s.Append("</script>");
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                string csname = "ltype";
                if (!cs.IsStartupScriptRegistered(cstype, csname))
                    cs.RegisterStartupScript(cstype, csname, s.ToString());
            }
            else
            {
                BasePage.Alert("您没有选择记录！");
            }
        }
        else
        {
            if (i_Num > 1)
            {
                BasePage.Alert("只能选择一条记录！");
            }
            else
            {
                StringBuilder s = new StringBuilder();
                s.Append("<script language=javascript>" + "\n");
                if (this.Tbx_KSP_SampleId.Text != "")
                {
                    string s_DoSql = "Update KNet_Sys_Products set KSP_SampleId='' where KSP_SampleId='" + this.Tbx_KSP_SampleId.Text + "'";
                    s_DoSql += "Update KNet_Sys_Products set KSP_SampleId='" + this.Tbx_KSP_SampleId.Text + "' where ProductsBarCode='" + s_TProductsBarCode + "' ";
                    DbHelperSQL.ExecuteSql(s_DoSql);

                    //关联最新图片信息

                    s.Append("alert('关联成功');" + "\n");
                }

                AM.Add_Logs("关联成功成功：样品编号：" + this.Tbx_KSP_SampleId.Text + "产品编号：" + s_TProductsBarCode);
                s.Append("if (window.opener != undefined)\n");
                s.Append("{\n");
                s.Append("    window.opener.returnValue = '" + s_Return + "';\n");
                s.Append("    window.opener.SetReturnValueInOpenner_Product('" + s_Return + "');\n");
                s.Append("}\n");
                s.Append("else\n");
                s.Append("{\n");
                s.Append("    window.returnValue = '" + s_Return + "';\n");
                s.Append("}\n");
                //s.Append("window.returnValue='" + s_Return + "';" + "\n");
                s.Append("window.close();" + "\n");
                s.Append("</script>");
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                string csname = "ltype";
                if (!cs.IsStartupScriptRegistered(cstype, csname))
                    cs.RegisterStartupScript(cstype, csname, s.ToString());
            }
        }
    }
    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click1(object sender, EventArgs e)
    {
        this.DataShows();
    }
}
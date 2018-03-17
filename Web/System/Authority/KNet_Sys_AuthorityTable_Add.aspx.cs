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

public partial class KNet_Sys_AuthorityTable_Add : BasePage
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
            string s_AuthorityName = Request.QueryString["AuthorityName"] == null ? "" : Request.QueryString["AuthorityName"].ToString();
            this.Tbx_ID.Text = s_ID;
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            this.Tbx_Type.Text = s_Type;
            this.Tbx_Title.Text = s_AuthorityName;
            try
            {
                BuildTree("", null);
                this.TreeView1.CollapseAll();
                this.TreeView1.Nodes[0].Expand();
                this.TreeView1.Nodes[0].Select();
            }
            catch
            { }
            BindModule();
            GetAboutPage();
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制权限注册";
                }
                else
                {
                    this.Lbl_Title.Text = "修改权限注册";
                    this.Tbx_ID.Text = s_ID;
                    Pan_OterPages.Visible = false;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增权限注册";
                Pan_OterPages.Visible = true;
            }
        }

    }
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.KNet_Sys_AuthorityTable bll = new KNet.BLL.KNet_Sys_AuthorityTable();
        KNet.Model.KNet_Sys_AuthorityTable model = bll.GetModel(int.Parse(s_ID));
        this.Ddl_Model.SelectedValue = model.AuthorityGroup.ToString();
        BindFunction(model.AuthorityGroup.ToString(), model.AuthorityFaterID);
        this.Tbx_Title.Text=model.AuthorityName;
        this.Tbx_AuthorityValue.Text = model.AuthorityValue.ToString();
        GetAboutPage();
    }

    public void BuildTree(string s_ID, TreeNode tree)
    {
        try
        {
            KNet.BLL.PB_Basic_Menu Bll = new KNet.BLL.PB_Basic_Menu();
            TreeNode treeMainNode = new TreeNode();
            KNet.BLL.PB_Basic_Menu bll = new KNet.BLL.PB_Basic_Menu();
            if (tree == null)
            {

                try
                {
                    KNet.Model.PB_Basic_Menu Model = bll.GetModel(s_ID);
                    this.TreeView1.Nodes.Clear();
                    treeMainNode.Text = Model.PBM_Name;
                    treeMainNode.Value = Model.PBM_ID;
                    this.TreeView1.Nodes.Add(treeMainNode);
                }
                catch
                {
                    treeMainNode.Text = "菜单";
                    treeMainNode.Value = "";
                    this.TreeView1.Nodes.Add(treeMainNode);
                }
            }
            else
            {
                treeMainNode = tree;
            }

            DataSet Dts_Table = bll.GetList(" PBM_FatherID='" + s_ID + "'");


            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    TreeNode treeNode1 = new TreeNode();
                    treeNode1.Text = Dts_Table.Tables[0].Rows[i]["PBM_Name"].ToString();
                    treeNode1.Value = Dts_Table.Tables[0].Rows[i]["PBM_ID"].ToString();
                    treeMainNode.ChildNodes.Add(treeNode1);
                    BuildTree(Dts_Table.Tables[0].Rows[i]["PBM_ID"].ToString(), treeNode1);
                }
            }
        }
        catch(Exception ex)
        { }
    }
    private bool SetValue(KNet.Model.KNet_Sys_AuthorityTable model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.ID = GetID();
            }
            else
            {
                model.ID = int.Parse(this.Tbx_ID.Text);
            }
            model.AuthorityName = this.Tbx_Title.Text;
            model.AuthorityGroup = int.Parse(this.Ddl_Model.SelectedValue);
            if (this.Tbx_AuthorityValue.Text != "")
            {
                model.AuthorityValue = int.Parse(this.Tbx_AuthorityValue.Text);
            }
            else
            {
                this.BeginQuery("Select isNUll(Max(AuthorityValue),0) from KNet_Sys_AuthorityTable where AuthorityValue like '" + this.Ddl_Model.SelectedValue + "%'");
                this.QueryForDataTable();
                if (this.Dtb_Result.Rows.Count > 0)
                {
                    if (Dtb_Result.Rows[0][0].ToString() == "0")
                    {
                        model.AuthorityValue = int.Parse(this.Ddl_Model.SelectedValue) * 10000 + 1;
                    }
                    else
                    {
                        model.AuthorityValue = int.Parse(Dtb_Result.Rows[0][0].ToString()) + 1;
                    }
                }
                else
                {
                    model.AuthorityValue = int.Parse(this.Ddl_Model.SelectedValue) * 10000 + 1;
                }
            }
            model.AuthorityFaterID = this.Ddl_Function.SelectedValue;
            model.AuthorityFunction = this.Ddl_Model.SelectedValue;
            

            return true;
        }
        catch
        {
            return false;
        }

    }
    public int GetID()
    {
        int i_Return=0;
        this.BeginQuery("Select Max(ID) from KNet_Sys_AuthorityTable ");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            i_Return = int.Parse(Dtb_Result.Rows[0][0].ToString()) + 1;
        }
        return i_Return;
    }
    protected void Btn_Send_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.KNet_Sys_AuthorityTable model = new KNet.Model.KNet_Sys_AuthorityTable();
        KNet.BLL.KNet_Sys_AuthorityTable bll = new KNet.BLL.KNet_Sys_AuthorityTable();

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
                    AM.Add_Logs("权限注册修改" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改成功！", "KNet_Sys_AuthorityTable_List.aspx");
                }
                else
                {
                    AM.Add_Logs("权限注册修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "KNet_Sys_AuthorityTable_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            catch { }
        }
        else
        {

            try
            {
                bll.Add(model);
                AM.Add_Logs("权限注册增加" + model.ID.ToString());
                AlertAndRedirect("新增成功！", "KNet_Sys_AuthorityTable_List.aspx");
            }
            catch { }
        }

    }
    protected void Ddl_Model_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindFunction(this.Ddl_Model.SelectedValue,"");
        GetAboutPage();
    }
    public void BindFunction(string s_Model,string s_Value)
    {
        KNet.BLL.PB_Basic_Menu Bll_Menu = new KNet.BLL.PB_Basic_Menu();
        DataSet Dts_Table1 = Bll_Menu.GetList(" PBM_FatherID='" + s_Model + "'  and PBM_ColSpan='1'  Order by PBM_ID  ");

        this.Ddl_Function.DataSource = Dts_Table1.Tables[0];
        this.Ddl_Function.DataTextField = "PBM_Name";
        this.Ddl_Function.DataValueField = "PBM_ID";
        this.Ddl_Function.DataBind();
        if (s_Value != "")
        {
            this.Ddl_Function.SelectedValue = s_Value;

        }
    }
    private void GetAboutPage()
    {
        string s_Sql="";
        try{
            s_Sql = " Select * from KNet_Sys_AuthorityTable where AuthorityName like '%" + this.Ddl_Function.SelectedItem.Text + "%' order by AuthorityName ";
        this.BeginQuery(s_Sql);
        DataTable Dtb_Table=(DataTable)this.QueryForDataTable();
        this.Chk_AboutPages.DataSource = Dtb_Table;
        this.Chk_AboutPages.DataTextField = "AuthorityName";
        this.Chk_AboutPages.DataValueField = "AuthorityValue";
        this.Chk_AboutPages.RepeatColumns = 5;
        this.Chk_AboutPages.DataBind();
        GetOtherPage();
        }
        catch
        {}
    }

    private void GetOtherPage()
    {
        string s_Sql = "";
        try
        {
            string s_Name = this.Ddl_Function.SelectedItem.Text;
            string s_Details = "";
            s_Details = "新增" + s_Name + "," + s_Name + "列表" + ",删除" + s_Name + ",查看" + s_Name + ",修改" + s_Name + ",复制" + s_Name;
            string[] ss_Details = s_Details.Split(',');
            s_Sql = "Select * from (";
            for (int i = 0; i < ss_Details.Length; i++)
            {
                s_Sql += "Select "+i.ToString()+" as AuthorityValue,'" + ss_Details[i] + "' as AuthorityName ";
                if (i != ss_Details.Length - 1)
                {
                    s_Sql += "Union all ";
                }
            }
            s_Sql += ") aa ";
            s_Sql += "Where AuthorityName not in( Select AuthorityName from KNet_Sys_AuthorityTable where AuthorityName like '%" + this.Ddl_Function.SelectedItem.Text + "%') ";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
            this.Chk_OtherPages.DataSource = Dtb_Table;
            this.Chk_OtherPages.DataTextField = "AuthorityName";
            this.Chk_OtherPages.DataValueField = "AuthorityValue";
            this.Chk_OtherPages.RepeatColumns = 5;
            this.Chk_OtherPages.DataBind();
            for (int i = 0; i < Chk_OtherPages.Items.Count; i++)
            {
                Chk_OtherPages.Items[i].Selected = true;
            }
            
        }
        catch
        { }
    }
    public void BindModule()
    {
        try{

            KNet.BLL.PB_Basic_Menu Bll_Menu = new KNet.BLL.PB_Basic_Menu();
            DataSet Dts_Table = Bll_Menu.GetList("  PBM_ColSpan='1' Order by PBM_ID ");
            this.Ddl_Model.DataSource = Dts_Table.Tables[0];
            this.Ddl_Model.DataTextField = "PBM_Name";
            this.Ddl_Model.DataValueField = "PBM_ID";
            this.Ddl_Model.DataBind();
            BindFunction();
        }
        catch{}
    }

    public void BindFunction()
    {
        try{

            KNet.BLL.PB_Basic_Menu Bll_Menu = new KNet.BLL.PB_Basic_Menu();
            DataSet Dts_Table1 = Bll_Menu.GetList(" PBM_FatherID='" + this.Ddl_Model.SelectedValue + "'  and PBM_ColSpan='1'  Order by PBM_ID  ");
            this.Ddl_Function.DataSource = Dts_Table1.Tables[0];
            this.Ddl_Function.DataTextField = "PBM_Name";
            this.Ddl_Function.DataValueField = "PBM_ID";
            this.Ddl_Function.DataBind();
        }
        catch{}
    }

    private void BindGroup()
    {
        string s_Sql = "";
        try
        {
            KNet.BLL.KNet_Sys_AuthorityUserGroup Bll = new KNet.BLL.KNet_Sys_AuthorityUserGroup();

        }
        catch
        { }
    }
    private void GetAuthorityUserGroup()
    {
        string s_Sql = "";
        try
        {
            s_Sql = " select * from KNet_Sys_AuthorityUserGroupSetup a join  ";
            s_Sql += " KNet_Sys_AuthorityUserGroup b on a.GroupValue=b.GroupValue where AuthorityValue in ( ";
            s_Sql += " Select AuthorityValue from KNet_Sys_AuthorityTable where AuthorityName like '%" + this.Ddl_Function.SelectedItem.Text + "%'  ";
            s_Sql += ")";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
            this.Chk_AboutPages.DataSource = Dtb_Table;
            this.Chk_AboutPages.DataTextField = "AuthorityName";
            this.Chk_AboutPages.DataValueField = "AuthorityValue";
            this.Chk_AboutPages.RepeatColumns = 5;
            this.Chk_AboutPages.DataBind();
        }
        catch
        { }
    }

    public string GetUser(string s_GroupValue)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "";
            s_Sql = "Select * from KNet_Sys_Authority_AuthList where GroupValue='" + s_GroupValue + "' and  StaffNo in (Select StaffNo from KNet_Resource_Staff where StaffYN=0 ) ";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    s_Return += base.Base_GetUserName(Dtb_Table.Rows[i][0].ToString()) + " [" + base.Base_GetUserDept(Dtb_Table.Rows[i][0].ToString()) + "] <br/>";
                }
                s_Return.Substring(0, s_Return.Length - 4);
            }
        }
        catch
        { }
        return s_Return;
    }
    protected void Ddl_Function_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetAboutPage();
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        try
        {
            if (this.TreeView1.SelectedNode.Value != "")
            {
                KNet.BLL.PB_Basic_Menu Bll = new KNet.BLL.PB_Basic_Menu();
                KNet.Model.PB_Basic_Menu Model = Bll.GetModel(this.TreeView1.SelectedNode.Value);
                if (Model!=null)
                {
                    this.Ddl_Model.SelectedValue = Model.PBM_FatherID;
                    BindModule();
                    this.Ddl_Function.SelectedValue = this.TreeView1.SelectedNode.Value;
                    GetAboutPage();
                }
            }
        }
        catch
        { 
        }
    }
}

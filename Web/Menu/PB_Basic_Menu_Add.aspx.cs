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

public partial class PB_Basic_Menu_Add : BasePage
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
            DropParentMenu(this.DDl_FatherID);
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = s_ID;
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            this.Tbx_Type.Text = s_Type;
            this.BeginQuery("Select * from PB_Basic_Menu ");
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制菜单";
                }
                else
                {
                    this.Lbl_Title.Text = "修改菜单";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增菜单";
            }
        }

    }
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.PB_Basic_Menu bll = new KNet.BLL.PB_Basic_Menu();
        KNet.Model.PB_Basic_Menu model = bll.GetModel(s_ID);
        this.Tbx_Code.Text = model.PBM_ID;

    }

    private bool SetValue(KNet.Model.PB_Basic_Menu model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.PBM_ID = GetMainID();
            }
            else
            {
                model.PBM_ID = this.Tbx_ID.Text;
            }
            model.PBM_FatherID = DDl_FatherID.SelectedValue;
            model.PBM_Name = PBM_Name.Text;
            model.PBM_Module = Tbx_Module.Text;
            model.PBM_Parenttab = Tbx_ParentTab.Text;
           
            model.PBM_URL = Tbx_URL.Text;
            model.PBM_Del = "0";
            model.PBM_Order =int.Parse(Tbx_Order.Text) ;
            model.PBM_ColSpan = int.Parse(Tbx_ColSpan.Text);
            model.PBM_RowSpan = int.Parse(Tbx_RowSpan.Text);
            model.PBM_Level = int.Parse(DDl_Level.SelectedValue);
            model.PBM_IsChild = 0;
            model.PBM_Icon = Tbx_Icon.Text;
            model.PBM_CTime=DateTime.Now;
            model.PBM_MTime=DateTime.Now;
            ;

            return true;
        }
        catch
        {
            return false;
        }

    }
    protected void Btn_Send_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.PB_Basic_Menu model = new KNet.Model.PB_Basic_Menu();
        KNet.BLL.PB_Basic_Menu bll = new KNet.BLL.PB_Basic_Menu();

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
                    AM.Add_Logs("菜单修改" + this.Tbx_ID.Text);
                  //  base.Base_SendMessage(model.PBM_ID, "菜单： <a href='Web/Notice/PB_Basic_Menu_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBM_ID + "</a> ");
                    AlertAndRedirect("修改成功！", "PB_Basic_Menu_List.aspx");
                }
                else
                {
                    AM.Add_Logs("菜单修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "PB_Basic_Menu_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            catch { }
        }
        else
        {

            try
            {
                bll.Add(model);
                // base.Base_SendMessage(model.PBN_ReceiveID, "菜单： <a href='Web/Notice/PB_Basic_Menu_View.aspx?ID=" + model.PBN_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
                AM.Add_Logs("菜单增加" + model.PBM_ID);
                AlertAndRedirect("新增成功！", "PB_Basic_Menu_List.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public void DropParentMenu(DropDownList DDL)
    {
        try
        {
            DDL.Items.Clear();
            KNet.BLL.PB_Basic_Menu bll = new KNet.BLL.PB_Basic_Menu();
            DataSet Dts_Table = bll.GetList(" PBM_Del<>'1' Order By PBM_Level asc, PBM_Order asc ");
            foreach (DataRow dr in Dts_Table.Tables[0].Rows)
            {
                if (dr["PBM_FatherID"] == "")
                {
                    string s_ddlTxt = dr["PBM_Name"].ToString() + " (" + dr["PBM_ID"].ToString() + ")";
                    if (dr["PBM_Level"] != DBNull.Value)
                    {
                        int i_level = Convert.ToInt32(dr["PBM_Level"]);
                        for (int i = 0; i < i_level + 1; i++)
                        {
                            s_ddlTxt = "- " + s_ddlTxt;
                        }
                    }
                    DDL.Items.Add(new ListItem(s_ddlTxt, dr["PBM_ID"].ToString()));
                    PopulateDDLParentMenu(DDL, Dts_Table, dr["PBM_ID"].ToString());
                }
            }
            ListItem item = new ListItem("请选择上级菜单", ""); //默认值
            DDL.Items.Insert(0, item);
        }
        catch (Exception ex)
        {
        }
    }

    private void PopulateDDLParentMenu(DropDownList DDL, DataSet Dts_Table, string s_ParentMenuID)
    {
        foreach (DataRow dr in Dts_Table.Tables[0].Rows)
        {
            if (dr["PBM_FatherID"].ToString() == s_ParentMenuID)
            {
                string s_ddlTxt = dr["PBM_Name"].ToString() + " (" + dr["PBM_ID"].ToString() + ")";
                if (dr["PBM_Level"] != DBNull.Value)
                {
                    int i_level = Convert.ToInt32(dr["PBM_Level"]);
                    for (int i = 0; i < i_level+1; i++)
                    {
                        s_ddlTxt = "- " + s_ddlTxt;
                    }
                }
                DDL.Items.Add(new ListItem(s_ddlTxt, dr["PBM_ID"].ToString()));
                PopulateDDLParentMenu(DDL, Dts_Table, dr["PBM_ID"].ToString());
            }
        }
    }
}

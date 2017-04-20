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

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 销售管理设置  ---渠道信息
/// </summary>
public partial class Xs_Sales_BasisSetting_Class : BasePage
{
    public string s_AdvShow = "";

    protected void Page_Load(object sender, EventArgs e)
    {   
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            Lbl_Title.Text = "采购类型设置";
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }

            string s_Code = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = s_Code;
            if (s_Code == "1")
            {
                Pan_Fater.Visible = true;
            }
            else
            {
                Pan_Fater.Visible = false;
            }
            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确定要删除所选记录吗? ！')");
            this.DataShows();
            base.Base_DropKClaaBind(this.Drop_FaterCode,1," and isnull(Client_faterNo,'')='' ","");
        }
    }
    /// <summary>
    /// 绑定数据源 分类(1渠道信息，2客户类型,3客户行业，4客户来源）
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sys_ProcureType bll = new KNet.BLL.KNet_Sys_ProcureType();
        string s_SqlWhere = " 1=1 ";
   
        using (DataSet ds = bll.GetList(s_SqlWhere))
        {
            //--End分页-----
            GridView1.DataSource = ds;
            GridView1.DataKeyNames = new string[] { "ID" };
            GridView1.DataBind();
        }
    }

    /// <summary>
    /// 批量删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {

        string sql = "delete from KNet_Sys_ProcureType where";
        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " ID='" + GridView1.DataKeys[i].Value.ToString() + "' or";
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
        LogAM.Add_Logs("采购--->采购类型设置批量删除 操作成功！");

        this.DataShows();
    }

    /// <summary>
    /// 添加提示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowState == DataControlRowState.Edit || e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
        {

            DropDownList Drop1 = e.Row.FindControl("Drop_FaterNo") as DropDownList;
            base.Base_DropKClaaBind(Drop1, 1, " and isnull(Client_faterNo,'')='' ", "");
        }
    }


    /// <summary>
    /// 开启编辑
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_Editing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        this.DataShows();
    }

    /// <summary>
    /// 取消编辑
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        this.DataShows();
    }

    /// <summary>
    /// 更新数据记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        /*
        KNet.BLL.KNet_Sys_ProcureType bll = new KNet.BLL.KNet_Sys_ProcureType();
        KNet.Model.KNet_Sys_ProcureType model = new KNet.Model.KNet_Sys_ProcureType();

        string  ID = GridView1.DataKeys[e.RowIndex].Value.ToString().Trim();
        string Client_Name = KNetPage.KHtmlEncode(((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString().Trim());

        string Client_FaterNo = KNetPage.KHtmlEncode(((DropDownList)GridView1.Rows[e.RowIndex].Cells[2].FindControl("Drop_FaterNo")).SelectedValue.ToString());
        string Client_Code = KNetPage.KHtmlEncode(((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString().Trim());
        int ClientPai = int.Parse(KNetPage.KHtmlEncode(((TextBox)GridView1.Rows[e.RowIndex].Cells[4].FindControl("UnitsPaitxt")).Text.ToString()));

        model.ID = ID;
        model.Client_Name = Client_Name;
        model.ClientPai = ClientPai;
        model.Client_FaterNo = Client_FaterNo;
        model.Client_Code = Client_Code;
        try
        {
            bll.Update(model);

            AdminloginMess LogAM = new AdminloginMess();
            LogAM.Add_Logs("销售管理--->销售管理设置--->渠道信息 更新 操作成功！名称：" + Client_Name);
        }
        catch
        {
            Response.Write("<script>alert('渠道信息 更新 失败！');history.back(-1);</script>");
            Response.End();
        }
        GridView1.EditIndex = -1;
        this.DataShows();
         * */
    }


    /// <summary>
    /// 添加单位 (1渠道信息，2客户类型,3客户行业，4客户来源）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button8_Click(object sender, EventArgs e)
    {
        string ClientValue = DateTime.Now.ToFileTimeUtc().ToString();
        string Client_Name = KNetPage.KHtmlEncode(this.txtUnitsName.Text);
        bool Clientdefault = false;
        int ClientKings = int.Parse(this.Tbx_ID.Text);
        int ClientPai = int.Parse(this.txtUnitsPai.Text);

        if (Client_Name == "" || Client_Name == null)
        {
            Response.Write("<script>alert('名称不能为空！');history.back(-1);</script>");
            Response.End();
        }

        KNet.BLL.KNet_Sys_ProcureType bll = new KNet.BLL.KNet_Sys_ProcureType();
        KNet.Model.KNet_Sys_ProcureType model = new KNet.Model.KNet_Sys_ProcureType();

        model.ProcureTypeValue = ClientValue;
        model.ProcureTypeName = Client_Name;
        model.ProcureTypePai = ClientPai;
        try
        {
            if (bll.Exists(Client_Name) == false)
            {
                bll.Add(model);

                AdminloginMess LogAM = new AdminloginMess();
                LogAM.Add_Logs("采购--->采购设置信息 添加 操作成功！分类名称：" + Client_Name);

                Response.Write("<script>alert('采购设置 添加 成功！');location.href='" + Request.Url.ToString() + "';</script>");
                Response.End();
            }   
            else
            {
                Response.Write("<script>alert('采购类型名称已存在 添加失败1！');history.back(-1);</script>");
                Response.End();
            }
        }
        catch
        {
            Response.Write("<script>alert('采购类型 添加 失败2！');history.back(-1);</script>");
            Response.End();
        }
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
        s_AdvShow = Base_GetAdvShowHtml(arr_Fields, arr_Condition, arr_Text, "KNet_Sales_ClientList");
        this.DataShows();
    }
}

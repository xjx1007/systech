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
public partial class Knet_Web_System_KnetWarehouse : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("仓库设置列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            //基础设置管理
            if (AM.YNAuthority("删除仓库设置") == false)
            {
                AM.NoAuthority("删除仓库设置");
            }


            ViewState["SortOrder"] = "HouseDate";
            ViewState["OrderDire"] = "Desc";
            base.Base_DropBindSearch(this.bas_searchfield, "KNet_Sys_WareHouse");
            base.Base_DropBindSearch(this.Fields, "KNet_Sys_WareHouse");


            this.DataShows();
        }

    }

    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sys_WareHouse bll = new KNet.BLL.KNet_Sys_WareHouse();

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";

        string SqlWhere = " 1=1 ";
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
        DataSet ds = bll.GetList(SqlWhere);
            GridView1.DataSource = ds;
            GridView1.DataKeyNames = new string[] { "HouseNo" };
            GridView1.DataBind();
       
    }


    /// <summary>
    /// 添加提示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Attributes.Add("class", "text");
            e.Row.Cells[10].Attributes.Add("onClick", "return confirm('您确定要删除所选记录吗?\\n\\n注意：删除此仓库后，该仓库中的产品将同时自动归到“默认仓库”中，千万小心操作！');");


            Image lk = (Image)e.Row.Cells[1].FindControl("Image1");
            Label LB = (Label)e.Row.Cells[1].FindControl("StateLabel");
            if (LB.Text.ToString().CompareTo("True") == 0)
            {
                lk.ImageUrl = "../../images/Au1.gif";
            }
            else
            {
                lk.ImageUrl = "../../images/Au2.gif";
            }

            //仓库设置删除
            if (AM.YNAuthority("删除仓库设置") == false)
            {
                e.Row.Cells[10].Text = "<font color=#999999>删除</font>";
                e.Row.Cells[10].Attributes.Remove("onClick");
            }

        }
    }
    /// <summary>
    /// 删除动作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_del(object sender, GridViewDeleteEventArgs e)
    {
        AdminloginMess LogAM = new AdminloginMess();
        //仓库设置删除
        if (LogAM.YNAuthority("删除仓库设置") == false)
        {
            LogAM.NoAuthority("删除仓库设置");
        }


        KNet.BLL.KNet_Sys_WareHouse bll = new KNet.BLL.KNet_Sys_WareHouse();
        string HouseNo = GridView1.DataKeys[e.RowIndex].Value.ToString().Trim();
        bll.Delete(HouseNo);

      
        LogAM.Add_Logs("系统管理--->仓库管理--->仓库  删除 操作成功！");

        this.DataShows(); 
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


  }

﻿using System;
using System.Data;
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

public partial class Web_Sales_Knet_Procure_Suppliers_List : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("供应商列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                string s_Model = Request.QueryString["Model"] == null ? "" : Request.QueryString["Model"].ToString();
                //删除销售机会
                if (AM.YNAuthority("删除供应商") == false)
                {
                    this.Btn_Del.Enabled = false;
                }
                if ((s_ID != "") && (s_Model == "IsDel"))
                {
                    if (AM.YNAuthority("供应商审核"))
                    {
                        KNet.BLL.Knet_Procure_Suppliers Bll = new KNet.BLL.Knet_Procure_Suppliers();
                        KNet.Model.Knet_Procure_Suppliers Model = Bll.GetModelB(s_ID);
                        Model.SuppNo = s_ID;
                        int i_Del = Math.Abs(Model.KPS_Del - 1);
                        Model.KPS_Del = i_Del;
                        Bll.UpdateDel(Model);
                        AM.Add_Logs("供应商--->停用供应商编码：" + s_ID);
                    }
                    else
                    {
                        Alert("你没有审核的权限，请联系品质部");
                    }
                }
                this.Btn_Del.Attributes.Add("onclick", "return confirm('您确定要把所选择的记录删除吗？')");
                DataShows();
                base.Base_DropBatchBind(this.Ddl_Batch, "Knet_Procure_Suppliers", "KPS_DutyPerson");
                base.Base_DropBindSearch(this.bas_searchfield, "Knet_Procure_Suppliers");
                base.Base_DropBindSearch(this.Fields, "Knet_Procure_Suppliers");
            }
        }
        
    }

    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        string s_SqlWhere = " 1=1 ";

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";
        if (s_WhereID != "")
        {
            s_SqlWhere += Base_GetBasicWhere(s_WhereID);
        }
        if (this.Ddl_Batch.SelectedValue != "")
        {
            s_SqlWhere += Base_GetBasicWhere(this.Ddl_Batch.SelectedValue);
        }

        if ((this.bas_searchfield.SelectedValue != "") && (search_text.Text != ""))
        {
            s_SqlWhere += base.Base_GetBasicColumnWhere(this.bas_searchfield.SelectedValue, this.search_text.Text);
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
            s_SqlWhere += base.Base_GetAdvWhere(s_Fields, s_Condition, s_Text, s_Type);
        }
        s_SqlWhere += " Order by isnull(KPS_MTime,KPS_CTime) Desc";
        KNet.BLL.Knet_Procure_Suppliers bll = new KNet.BLL.Knet_Procure_Suppliers();
        DataSet ds = bll.GetList(s_SqlWhere);
        this.GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "SuppNo" };
        GridView1.DataBind();
    }

    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        this.DataShows();


    }
    protected void Btn_Del_Click(object sender, EventArgs e)
    {
        StringBuilder s_Sql = new StringBuilder();
        StringBuilder s_Log = new StringBuilder();
        try
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox Ckb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (Ckb.Checked)
                {
                    string s_ID = GridView1.DataKeys[i].Value.ToString();
                    s_Sql.Append(" delete from  Knet_Procure_Suppliers Where SuppNo='" + s_ID + "' ");

                }
            }
            if (DbHelperSQL.ExecuteSql(s_Sql.ToString()) > 0)
            {
                this.DataShows();
                AdminloginMess AM = new AdminloginMess();
                AM.Add_Logs("供应商删除 编号：" + s_Log + "");
                Alert("删除成功！");
            }
        }
        catch (Exception ex)
        {
            Alert("删除失败！");
            return;
        }
    }

    protected void Ddl_Batch_TextChanged(object sender, EventArgs e)
    {
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
        s_AdvShow = Base_GetAdvShowHtml(arr_Fields, arr_Condition, arr_Text, "Knet_Procure_Suppliers");
        this.DataShows();
    }
    
    public string GetState(string s_ProductsBarCode, int s_Del)
    {
        string s_Return = "";
        try
        {

            if (s_Del == 1)
            {
                string JSD = "Knet_Procure_Suppliers_List.aspx?ID=" + s_ProductsBarCode + "&Model=IsDel";
                s_Return = "<a href=\"" + JSD + "\" onclick=\"\"  ><font color=red>停用</font></a>";
            }
            else
            {
                string JSD = "Knet_Procure_Suppliers_List.aspx?ID=" + s_ProductsBarCode + "&Model=IsDel";
                s_Return = "<a href=\"" + JSD + "\" onclick=\"\" >启用</a>";
            }
        }
        catch
        { }
        return s_Return;
    }
}

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
using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;
using System.Data.SqlClient;

public partial class Web_Sales_KNet_WareHouse_WareCheck_Manage : BasePage
{
    public string s_AdvShow = "", s_DType="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            s_DType = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            this.Tbx_Type.Text = s_DType;
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("盘点列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                //退货单查看
                if (AM.YNAuthority("删除盘点") == false)
                {
                    this.Btn_Del.Enabled = false;
                }
                this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！\\n\\n注意：该删除会同时删除退货单产品明细记录.')");

                DataShows();
                //base.Base_DropBatchBind(this.Ddl_Batch, "KNet_WareHouse_WareCheck", "XSQ_DutyPerson");
                base.Base_DropBindSearch(this.bas_searchfield, "KNet_WareHouse_WareCheck");
                base.Base_DropBindSearch(this.Fields, "KNet_WareHouse_WareCheck");
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

        if ((this.bas_searchfield.SelectedValue != "") && (search_text.Text != ""))
        {
            s_SqlWhere += base.Base_GetBasicColumnWhere(this.bas_searchfield.SelectedValue, this.search_text.Text);
        }
        if (this.Tbx_Type.Text != "")
        {
            s_SqlWhere += " and HouseNo in (Select HouseNo from KNet_Sys_WareHouse where KSW_Type='1' union all Select SuppNo from Knet_Procure_Suppliers) ";
        }
        s_SqlWhere += " Order by KNet_WareHouse_WareCheckList.SystemDateTimes desc";
        KNet.BLL.KNet_WareHouse_WareCheckList bll = new KNet.BLL.KNet_WareHouse_WareCheckList();
        DataSet ds = bll.GetList(s_SqlWhere);
        this.MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] { "WareCheckNo" };
        MyGridView1.DataBind();
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
            for (int i = 0; i < MyGridView1.Rows.Count; i++)
            {
                CheckBox Ckb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (Ckb.Checked)
                {
                    string s_ID = MyGridView1.DataKeys[i].Value.ToString();
                    s_Sql.Append(" delete from  KNet_WareHouse_WareCheckList Where WareCheckNo='" + s_ID + "' ");
                    s_Sql.Append(" delete from  KNet_WareHouse_WareCheckList_Details Where WareCheckNo='" + s_ID + "' ");

                }
            }
            if (DbHelperSQL.ExecuteSql(s_Sql.ToString()) > 0)
            {
                this.DataShows();
                AdminloginMess AM = new AdminloginMess();
                AM.Add_Logs("KNet_WareHouse_WareCheckList 删除 编号：" + s_Log + "");
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
        s_AdvShow = Base_GetAdvShowHtml(arr_Fields, arr_Condition, arr_Text);
        this.DataShows();
    }
    /// <summary>
    /// 返回审核情况
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetOrderCheckYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,WareCheckNo,WareCheckCheckYN from KNet_WareHouse_WareCheckList where WareCheckNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["WareCheckCheckYN"].ToString() == "True")
                {
                    return "<img src=\"../../images/gou.gif\"  border=\"0\" />";
                }
                else
                {
                    string JSD = "KNet_WareHouse_WareCheckCheckYN.aspx?WareCheckNo=" + aa.ToString() + "";
                    string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=400,height=250');\"  title=\"点击进行审核操作\">审核</a>";
                    return StrPop;
                }
            }
            else
            {
                return "--";
            }
        }
    }
}

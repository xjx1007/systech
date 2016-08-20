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

public partial class Web_Sales_KNet_Reports_Submit_List : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
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
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                if (s_ID != "")
                {
                    KNet.BLL.KNet_Reports_Submit Bll = new KNet.BLL.KNet_Reports_Submit();
                    KNet.Model.KNet_Reports_Submit Model = new KNet.Model.KNet_Reports_Submit();
                    Model.KRS_ID=s_ID;
                    Model.KRS_State = 1;
                    Bll.UpdateState(Model);
                }
                DataShows();

                base.Base_DropBindSearch(this.bas_searchfield, "KNet_Reports_Submit");
                base.Base_DropBindSearch(this.Fields, "KNet_Reports_Submit");
                base.Base_DropBatchBind(this.Ddl_Batch, "KNet_Reports_Submit", "KRS_DutyPerson");
                //this.Ddl_Batch.SelectedValue = " and KRS_DutyPerson='" + AM.KNet_StaffNo + "'";
            }
        }
        
    }

    /// <summary>
    /// 添加提示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string s_ID = this.MyGridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            KNet.BLL.KNet_Reports_Submit bll = new KNet.BLL.KNet_Reports_Submit();
            KNet.Model.KNet_Reports_Submit Model = bll.GetModel(s_ID);
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            string s_State = Model.KRS_State.ToString();
            if (s_State !="0")
            {
                cb.Enabled = false;
                e.Row.Cells[10].Text = "<Font Color=red>不可修改</Font>";
            }
            else
            {
                cb.Enabled = true;
            }
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
            AdminloginMess AM = new AdminloginMess();
        string s_SqlWhere = " KRS_Del=0";

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString(); 
        string s_Type = "";
 
        if (s_WhereID != "")
        {
            s_SqlWhere += Base_GetBasicWhere(s_WhereID);
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
        if (this.Ddl_Batch.SelectedValue != "")
        {
            s_SqlWhere += Base_GetBasicWhere(this.Ddl_Batch.SelectedValue);
        }
        if ((AM.KNet_StaffDepart == "129652783965723459") && (AM.KNet_Position == "102"))//研发中心经理
        {
            s_SqlWhere += " and KRS_DutyPerson in (Select StaffNo from KNet_Resource_Staff where StaffDepart='129652783965723459' or StaffDepart='129652784259578018' or StaffDepart='129652784446995911')";
        }
        else if ((AM.KNet_StaffDepart == "129652783693249229") && (AM.KNet_Position == "102"))
        {
            s_SqlWhere += " and 1=1 ";
        }
        else if (AM.KNet_Position == "102")
        {
            s_SqlWhere += " and KRS_DutyPerson in (Select StaffNo from KNet_Resource_Staff where StaffDepart='" + AM.KNet_StaffDepart + "') ";
        }
        else
        {
            s_SqlWhere += "  and KRS_DutyPerson='" + AM.KNet_StaffNo + "'";
        }
        s_SqlWhere += " Order by KRS_CTime desc";
        KNet.BLL.KNet_Reports_Submit bll = new KNet.BLL.KNet_Reports_Submit();
        DataSet ds = bll.GetList(s_SqlWhere);
        this.MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] { "KRS_ID" };
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
                    s_Sql.Append(" Update KNet_Reports_Submit set KRS_Del=1  Where KRS_ID='" + s_ID + "' ");
                    s_Log.Append(s_ID);
                }
            }
            DbHelperSQL.ExecuteSql(s_Sql.ToString());
            this.DataShows();
            AdminloginMess AM = new AdminloginMess();
            AM.Add_Logs("KNet_Reports_Submit 删除 编号：" + s_Log + "");
            AlertAndRedirect("删除成功！", "KNet_Reports_Submit_List.aspx");
        }
        catch (Exception ex)
        {
            Alert("删除失败！");
            return;
        }
    }

    public string GetSpce(string s_ID,int i_num)
    {
        string s_XPS_SpceName = "";
        KNet.BLL.KNet_Reports_Submit_Details Bll = new KNet.BLL.KNet_Reports_Submit_Details();
        DataSet Dts_Table = Bll.GetList(" KRD_SubmitID='" + s_ID + "'");
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            string s_Name="";
            try
            {
                s_Name=Dts_Table.Tables[0].Rows[i_num]["KRD_Name"].ToString();
            }catch {}
            s_XPS_SpceName = "<a href='/Web/UpLoadPic/Report/" + s_Name + "' >" + s_Name + "</a>";
        }
        return s_XPS_SpceName;
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
    public string GetState(string s_ID)
    {
        string s_Return="";
        KNet.BLL.KNet_Reports_Submit BLL = new KNet.BLL.KNet_Reports_Submit();
        KNet.Model.KNet_Reports_Submit Model = BLL.GetModel(s_ID);
        if (Model.KRS_State == 0)
        {
            s_Return = "<a href='KNet_Reports_Submit_List.aspx?ID=" + s_ID + "'>未提交</a>";
        }
        else if (Model.KRS_State == 1)
        {
            s_Return = "<font color=red>已提交</font>";
        }
        else if (Model.KRS_State == 3)
        {
            s_Return = "<font color=Green>已审阅</font>";
        }
        return s_Return;
    }
    public string GetLink(string s_ID)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.Pb_Basic_Notice bll_Notice = new KNet.BLL.Pb_Basic_Notice();
            KNet.Model.Pb_Basic_Notice Model_Notice = bll_Notice.GetModel(s_ID);
            if (Model_Notice != null)
            {
                s_Return = "<a href=\"../Notice/Pb_Basic_Notice_View.aspx?ID=" + s_ID + "\" target=\"_blank\">" + Model_Notice.PBN_Title + "</a>";
            }
        }
        catch
        { }
        return s_Return;
    }
}

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

public partial class Web_Sales_ZL_Complain_Manage_List : BasePage
{
    public string s_AdvShow = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            AdminloginMess AM = new AdminloginMess();
            //客户抱怨列表
            if (AM.CheckLogin("客户抱怨列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                //删除客户抱怨
                if (AM.YNAuthority("删除客户抱怨") == false)
                {
                    this.Btn_Del.Enabled = false;
                }
                base.Base_DropBasicCodeBind(this.Ddl_Type, "213"); //类型
                this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");
                base.Base_DropBindSearch(this.bas_searchfield, "Knet_Sales_Retrun_Maintain");
                base.Base_DropBindSearch(this.Fields, "Knet_Sales_Retrun_Maintain");
                //base.Base_DropBatchBindBySql(this.Ddl_Batch, "Knet_Sales_Retrun_Maintain", "ZCM_DutyPerson", "  and StaffNo in (select StaffNo from KNet_Resource_Staff where IsSale='1' and StaffYN='0')");
                //string s_Batch = Request["Batch"] == null ? "" : Request["Batch"].ToString();
                //if (s_Batch != "")
                //{
                //    this.Ddl_Batch.SelectedValue = s_Batch;
                //}
                DataShows();
            }
        }

    }

    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        string SqlWhere = "  1=1 ";
        AdminloginMess AM = new AdminloginMess();
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";
        if (s_WhereID != "")
        {
            SqlWhere += Base_GetBasicWhere(s_WhereID);
        }

        if (this.Ddl_Type.SelectedValue != "")
        {
            SqlWhere += " and KSM_Type='" + this.Ddl_Type.SelectedValue + "' ";
        }
        if ((this.bas_searchfield.SelectedValue != "") && (search_text.Text != ""))
        {
            SqlWhere += base.Base_GetBasicColumnWhere(this.bas_searchfield.SelectedValue, this.search_text.Text);
        }
        if (s_Text != "")
        {
            if (this.matchtype1.Checked == true) //and
            {
                s_Type = "0";
            }
            if (this.matchtype2.Checked == true)
            {
                s_Type = "1";
            }
            SqlWhere += base.Base_GetAdvWhere(s_Fields, s_Condition, s_Text, s_Type);
        }

        SqlWhere += " Order by KSM_Time desc";
        KNet.BLL.Knet_Sales_Retrun_Maintain bll = new KNet.BLL.Knet_Sales_Retrun_Maintain();
        DataSet ds = bll.GetList(SqlWhere);
        this.MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] {"KSM_ID"};
        MyGridView1.DataBind();
    }

    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        this.DataShows();


    }

    protected void Btn_Del_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        StringBuilder s_Sql = new StringBuilder();
        StringBuilder s_Log = new StringBuilder();
        try
        {
            for (int i = 0; i < MyGridView1.Rows.Count; i++)
            {
                CheckBox Ckb = (CheckBox) MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (Ckb.Checked)
                {
                    string s_ID = MyGridView1.DataKeys[i].Value.ToString();
                    s_Sql.Append(" delete Knet_Sales_Retrun_Maintain where KSM_ID='"+s_ID+ "' ");
                    s_Log.Append(s_ID + ",");
                }
            }
            DbHelperSQL.ExecuteSql(s_Sql.ToString());
            this.DataShows();
            AM.Add_Logs("Knet_Sales_Retrun_Maintain 删除 编号：" + s_Log + "");
            Alert("删除成功！");
        }
        catch (Exception ex)
        {
            Alert("删除失败！");
            return;
        }
    }
    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            KNet.BLL.Knet_Sales_Retrun_Maintain Bll = new KNet.BLL.Knet_Sales_Retrun_Maintain();

            string DirectInNo = MyGridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            this.BeginQuery("select KSM_State from Knet_Sales_Retrun_Maintain where KSM_ID='" + DirectInNo + "'");
            this.QueryForDataTable();
            DataTable Dtb_Re = Dtb_Result;
            //KNet.Model.KNet_Sampling_List Model = Bll.GetModel(DirectInNo);
            if (Dtb_Re.Rows[0][0].ToString()!="0" )
            {
                cb.Enabled = false;
            }
            else
            {
                cb.Enabled = true;
            }
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
        s_AdvShow = Base_GetAdvShowHtml(arr_Fields, arr_Condition, arr_Text);
        this.DataShows();
    }

    protected void Ddl_Batch_TextChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }

    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        int i_Type = 1;
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.PB_Basic_Share Bll_Share = new KNet.BLL.PB_Basic_Share();
        ArrayList Arr_Details = new ArrayList();
        string s_FromID = "";
        for (int i = 0; i < this.MyGridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox) MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                s_FromID += "" + MyGridView1.DataKeys[i].Value.ToString() + ",";
            }
        }
        if (s_FromID == "")
        {
            Alert("请选择一条记录！");
            return;
        }
        else
        {
            s_FromID = s_FromID.Substring(0, s_FromID.Length - 1);
        }
        string s_CheckBoxAll = "";
        KNet.BLL.KNet_Resource_OrganizationalStructure Bll_Organizational =
            new KNet.BLL.KNet_Resource_OrganizationalStructure();
        DataSet Dts_Table =
            Bll_Organizational.GetList(
                "  STRucPID<>'0'  and StrucValue in ('129652783822281241','129652783965723459','129652783693249229') ");
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
            {
                string s_Details = Request["DetailView_" + Dts_Table.Tables[0].Rows[i][2].ToString() + ""] == null
                    ? ""
                    : Request["DetailView_" + Dts_Table.Tables[0].Rows[i][2].ToString() + ""].ToString();
                if (s_Details != "")
                {
                    s_CheckBoxAll += s_Details + ",";
                }
            }
        }
        string[] FromID = s_FromID.Split(',');
        //先删除该用户 对该数据其他人员的共享

        for (int j = 0; j < FromID.Length; j++)
        {
            KNet.Model.PB_Basic_Share Model_Share1 = new KNet.Model.PB_Basic_Share();
            Model_Share1.PBS_FromID = FromID[j];
            Model_Share1.PBS_FromPersonID = AM.KNet_StaffNo;
            Model_Share1.PBS_Type = i_Type;
            Bll_Share.deleteOldNoToID(Model_Share1);
        }
        if (s_CheckBoxAll != "")
        {
            s_CheckBoxAll = s_CheckBoxAll.Substring(0, s_CheckBoxAll.Length - 1);
            string[] s_CheckBox = s_CheckBoxAll.Split(',');
            //添加共享
            for (int i = 0; i < s_CheckBox.Length; i++)
            {
                for (int j = 0; j < FromID.Length; j++)
                {
                    KNet.Model.PB_Basic_Share Model_Share = new KNet.Model.PB_Basic_Share();
                    Model_Share.PBS_FromID = FromID[j];
                    Model_Share.PBS_FromPersonID = AM.KNet_StaffNo;
                    Model_Share.PBS_ToPersonID = s_CheckBox[i];
                    Model_Share.PBS_Type = i_Type;
                    Model_Share.PBS_CTime = DateTime.Now;
                    Arr_Details.Add(Model_Share);
                }
            }

            if (Bll_Share.Add(Arr_Details) == true)
            {
                AlertAndRedirect("共享成功！", "ZL_Complain_Manage_List.aspx");
                base.Base_SendMessage(s_CheckBoxAll,
                    KNetPage.KHtmlEncode("有 来自" + AM.KNet_StaffName +
                                         " 共享的<a href='Web/SalesOpp/ZL_Complain_Manage_List.aspx?Batch=163'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'>销售计划</a>  ，敬请关注！"));
            }

        }

    }

    public string GetDState(string s_DPerson)
    {

        string s_URL = "";
        if (s_DPerson=="0")
        {
            s_URL = "<font color=red>未审核</font>";
        }
        else
        {
            s_URL = "<font color=blue>已审核</font>";
        }
        return s_URL;
    }

    public string GetProductsEdition(string KSD_ID,string KSD_Type,string KSD_Product)
    {

        string s_Return = "";
       
        this.BeginQuery(
            "select ProductsBarCode,ProductsEdition,ProductsPattern,KSP_Code,ProductsName from KNet_Sys_Products where ProductsBarCode in(SELECT KSD_ProductCode FROM  Knet_Sales_Retrun_Maintain_Details where KSD_ID='"+ KSD_ID + "')");
        this.QueryForDataTable();
        try
        {
            if (this.Dtb_Result.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                {
                    //s_Return += Dtb_Result.Rows[i][1].ToString();
                    s_Return += "<a href=\"/Web/Products/KnetProductsSetting_Details.aspx?BarCode=" + Dtb_Result.Rows[i][0].ToString() + "\"  target=\"_blank\">" + Dtb_Result.Rows[i][1].ToString() + "</a>" + "<br>";
                }
                return s_Return;
            }
            else
            {
                return "--";
            }
        }
        catch
        {
            return "--";

        }
       
    }
    /// <summary>
    /// 根据客户筛选
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Ddl_Supp_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DataShows();
    }
}

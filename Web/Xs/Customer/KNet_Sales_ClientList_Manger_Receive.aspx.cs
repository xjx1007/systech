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
/// 客户管理
/// </summary>
public partial class KNet_Sales_ClientList_Manger_Receive : BasePage
{
    public string s_DivStyle = "";
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Lbl_Title.Text = "客户应收款列表";
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
          //  base.Base_DropSheng(this.sheng);

           // base.Base_DropCity(this.city, this.sheng.SelectedValue);
            //客户删除
            if (AM.YNAuthority("删除客户信息") == false)
            {
                this.Btn_Del.Enabled = false;
            }

            string s_DutyPerson = "";
            try
            {
               s_DutyPerson= Request.QueryString["DutyPerson"].ToString() == null ? "" : Request.QueryString["DutyPerson"].ToString();
            }
            catch { }
            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");
            ViewState["SortOrder"] = "CustomerAddtime";
            ViewState["OrderDire"] = "Desc";
            base.Base_DropBindSearch(this.bas_searchfield, "KNet_Sales_ClientList");
            base.Base_DropBindSearch(this.Fields, "KNet_Sales_ClientList");
            base.Base_DropBatchBindBySql(this.Ddl_Batch, "KNet_Sales_ClientList", "b.KSC_DutyPerson", " and IsSale='1' ");
            base.Base_DropDutyPerson(this.Ddl_DutyPerson, " and IsSale='1'  ");
            string s_Batch = Request["Batch"] == null ? "" : Request["Batch"].ToString();
            if (s_Batch != "")
            {
                this.Ddl_Batch.SelectedValue = s_Batch;
            }
            if (s_DutyPerson != "")
            {
                this.Ddl_Batch.SelectedValue = " and b.KSC_DutyPerson='" + s_DutyPerson + "'";
            }
            this.DataShows();
        }

    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        
        KNet.BLL.KNet_Sales_ClientList bll = new KNet.BLL.KNet_Sales_ClientList();
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_KeyWords = Request.QueryString["KeyWords"] == null ? "" : Request.QueryString["KeyWords"].ToString();
        string s_Fields=Request["Fields"]==null?"":Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text= Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type="";
 
        string SqlWhere = " 1=1 ";
        AdminloginMess AM = new AdminloginMess();
        string s_StartDate = "";
        string s_EndDate = DateTime.Now.ToShortDateString();
        if (s_StartDate == "")
        {
            s_StartDate = "1900-1-1";
        }
        string s_Sql = "select b.CustomerValue,b.CustomerName,b.KSC_DutyPerson,KSC_Auxiliary,CustomerCity,CustomerProvinces,KSC_SampleName,b.ID,Sum(case when STime<'" + s_StartDate + "' then Money else 0 end) QCMoney,";
        s_Sql += "Sum(case when STime>='" + s_StartDate + "'  and  STime<='" + s_EndDate + "' and  CType in(0,2) then Money else 0 end) BqYsMoney, ";
        s_Sql += "Sum(case when STime>='" + s_StartDate + "'  and  STime<='" + s_EndDate + "' and CType=1 then -Money else 0 end) BqSkMoney,";
        s_Sql += "Sum(case when STime<='" + s_EndDate + "' then Money else 0 end) QMMoney,";
        s_Sql += "Sum(Case when CType<>0 then Money+isnull(d.CQMoney,0) else isnull(d.CQMoney,0) end) DqMoney,Sum(Case when CType=0 then d.WCQMoney else 0 end) as wDqMoney, ";
        s_Sql += "Sum(case when  CType in(0) then d.FPTotalMoney else 0 end) BQKPMoney,Sum(case when CType=2 then Money else 0 end) CSHMoney,";
        s_Sql += "Sum(case when  CType in(0) then d.FPleftMoney else 0 end) WKPMoney,";
        s_Sql += "Sum(Case when CType<>0  then Money+isnull(d.Dq30Money,0) else isnull(d.Dq30Money,0) end ) Dq30Money, ";
        s_Sql += "Sum(Case when CType<>0  then Money+isnull(d.Dq60Money,0) else isnull(d.Dq60Money,0) end  ) Dq60Money, ";
        s_Sql += "Sum(Case when CType<>0  then Money+isnull(d.Dq90Money,0) else isnull(d.Dq90Money,0) end  ) Dq90Money, ";
        s_Sql += "Sum(Case when CType<>0  then Money+isnull(d.Dq90MoreMoney,0) else isnull(d.Dq90MoreMoney,0) end ) Dq90MoreMoney ";
        s_Sql += " from v_Receive_Real a join KNET_Sales_ClientList b on a.CustomerValue=b.CustomerValue ";
        s_Sql += " join v_DirectOut_FPMoneyDetails d on d.ID=a.ID";
        s_Sql += " where 1=1 ";

        //仅查看自己
        if (AM.YNAuthority("收款单仅责任人查看") == true)
        {
            if (AM.KNet_StaffName != "项洲")
            {
                s_Sql += " and b.KSC_DutyPerson='" + AM.KNet_StaffNo + "'  ";
            }
        }
        if (s_WhereID != "")
        {
            s_Sql += Base_GetBasicWhere(s_WhereID);
        }
        if (s_KeyWords != "")
        {
            s_Sql += " and ( CustomerName like '%" + s_KeyWords + "%' or CustomerMobile like '%" + s_KeyWords + "%' or CustomerMobile like '%" + s_KeyWords + "%' or CustomerValue like '%" + s_KeyWords + "%')";
        }
        if (this.Ddl_Batch.SelectedValue != "")
        {
            s_Sql += Base_GetBasicWhere(this.Ddl_Batch.SelectedValue);
        }
        if ((this.bas_searchfield.SelectedValue != "")&&(search_text.Text!=""))
        {
            s_Sql += base.Base_GetBasicColumnWhere(this.bas_searchfield.SelectedValue, this.search_text.Text);
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
            s_Sql += base.Base_GetAdvWhere(s_Fields, s_Condition, s_Text, s_Type);
        }

        //仅查看自己
        if ((AM.YNAuthority("客户仅自己查看") == true)&&(AM.KNet_StaffName!="项洲"))
        {
            //负责人
            SqlWhere += " and (KSC_DutyPerson='" + AM.KNet_StaffNo + "'";
            //创建人
            SqlWhere += " or KSC_Creator='" + AM.KNet_StaffNo + "'";
            //共享给自己的
            SqlWhere += " or ID in (Select PBS_FromID From PB_Basic_Share where PBS_ToPersonID='" + AM.KNet_StaffNo + "'))";
        }
        s_Sql += " group by CustomerName,b.CustomerValue,KSC_Auxiliary,CustomerCity,CustomerProvinces,KSC_SampleName,b.KSC_DutyPerson,b.ID order by CustomerName";

        this.BeginQuery(s_Sql);
        DataSet ds =(DataSet)this.QueryForDataSet();
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "CustomerValue" };
        GridView1.DataBind();
    }
        

    /// <summary>
    /// 返回定义属性名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetClient_Name(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ClientValue,Client_Name from KNet_Sales_ClientAppseting where ClientValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["Client_Name"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
    public void btnBasicSearch_Click(object sender, EventArgs e)
    {
        this.advSearch.Style["display"] = "none";
        this.Search_basic.Style["display"] = "block";         
        this.DataShows();
    }

    public void Button1_Click(object sender, EventArgs e)
    {

        string sql = " Update KNet_Sales_ClientList Set KSC_DutyPerson='"+this.Ddl_DutyPerson.SelectedValue+"' Where  ";
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
            Response.Write("<script language=javascript>alert('您没有选择要修改的记录!');history.back(-1);</script>");
            Response.End();
        }
        DbHelperSQL.ExecuteSql(sql);
        AdminloginMess LogAM = new AdminloginMess();
        LogAM.Add_Logs("销售管理---> 客户管理--->客户调整责任人 "+this.Ddl_DutyPerson.SelectedValue+" 操作成功！");
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

    protected void Btn_Del_Click(object sender, EventArgs e)
    {
        Delete();
    }
    public void Delete()
    {
        string sql = "delete from KNet_Sales_ClientList where";
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
        Alert("删除成功！");
        AdminloginMess LogAM = new AdminloginMess();
        LogAM.Add_Logs("销售管理---> 客户管理--->客户批量 删除 操作成功！");
        this.DataShows();
    }


    protected void sheng_SelectedIndexChanged(object sender, EventArgs e)
    {
      //  base.Base_DropCity(this.city, this.sheng.SelectedValue);
    }

    protected void Ddl_Batch_TextChanged1(object sender, EventArgs e)
    {
        this.DataShows();
    }
    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        int i_Type=0;
        AdminloginMess AM=new AdminloginMess();
        KNet.BLL.PB_Basic_Share Bll_Share = new KNet.BLL.PB_Basic_Share();
        ArrayList Arr_Details=new ArrayList();
        string s_FromID = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                s_FromID += "" + GridView1.DataKeys[i].Value.ToString() + ",";
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
        KNet.BLL.KNet_Resource_OrganizationalStructure Bll_Organizational = new KNet.BLL.KNet_Resource_OrganizationalStructure();
         DataSet Dts_Table = Bll_Organizational.GetList("  STRucPID<>'0'  and StrucValue in ('129652783822281241','129652783965723459','129652783693249229') ");
         if (Dts_Table.Tables[0].Rows.Count > 0)
         {
             for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
             {
                 string s_Details=Request["DetailView_" + Dts_Table.Tables[0].Rows[i][2].ToString() + ""]==null?"":Request["DetailView_" + Dts_Table.Tables[0].Rows[i][2].ToString() + ""].ToString();
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
             for(int i=0;i<s_CheckBox.Length;i++)
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
                 AlertAndRedirect("共享成功！", "KNet_Sales_ClientList_Manger.aspx");

                 base.Base_SendMessage(s_CheckBoxAll, KNetPage.KHtmlEncode("有 来自" + AM.KNet_StaffName + " 共享的<a href='Web/SalesOpp/Xs_Sales_Opp_List.aspx?Batch=161'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'>客户</a>  ，敬请关注！"));
             }
             
         }
         
    }
}

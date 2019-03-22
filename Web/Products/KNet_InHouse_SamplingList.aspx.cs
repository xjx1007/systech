using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Products_KNet_InHouse_SamplingList : BasePage
{
    public string s_AdvShow = "", s_Type1 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write(
                    "<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string Instate = Request.QueryString["RState"] == null ? "" : Request.QueryString["RState"].ToString();
            this.s_ID.Text = s_ID;
            if (s_ID != "" && Instate != "")
            {
                string DoSqlOrder = " update Knet_Sampling_OpenBilling set  RState='" + Instate + "' where ID='" + s_ID + "' ";
                DbHelperSQL.ExecuteSql(DoSqlOrder);
            }


            //this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！\\n\\n注意：该删除会同时删除入库单明细记录.')");
            base.Base_DropBindSearch(this.bas_searchfield, "Knet_Sampling_OpenBilling");
            base.Base_DropBindSearch(this.Fields, "Knet_Sampling_OpenBilling");
            Base_StaffNo(this.Ddl_StaffNo);
            this.DataShows();
            //this.RowOverYN();
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
    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            KNet.BLL.Knet_Sampling_OpenBilling Bll = new KNet.BLL.Knet_Sampling_OpenBilling();

            string DirectInNo = MyGridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            //this.BeginQuery("select count(*) from Knet_Sampling_OpenBilling where ID='" + DirectInNo + "' and RState='1'");
            //this.QueryForDataTable();
            //DataTable Dtb_Re = Dtb_Result;
            ////KNet.Model.KNet_Sampling_List Model = Bll.GetModel(DirectInNo);
            //if (Convert.ToInt32(Dtb_Re.Rows[0][0]) != 0)
            //{
            //    cb.Enabled = false;
            //}
            //else
            //{
            //    cb.Enabled = true;
            //}
        }
    }
    //protected void RowOverYN()
    //{
    //    if (MyGridView1.Rows.Count == 0) //如果没有记录
    //    {
    //        this.Btn_Del.Enabled = false;
    //    }
    //}
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        AdminloginMess AM = new AdminloginMess();

        KNet.BLL.Knet_Sampling_OpenBilling bll = new KNet.BLL.Knet_Sampling_OpenBilling();
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_ProductsBarCode = Request["ProductsBarCode"] == null ? "" : Request["ProductsBarCode"].ToString();
        string s_Type = "";

        string SqlWhere = " 1=1  ";


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
        string s_SalesOrderNo = Request.QueryString["SalesOrderNo"] == null ? "" : Request.QueryString["SalesOrderNo"].ToString();

        if (s_SalesOrderNo != "")
        {
            SqlWhere += " and ID like '%" + s_SalesOrderNo + "%' ";
        }



        //SqlWhere += " order by SYstemDateTimes desc";
        //string SqlWhere = " 1=1  ";
        if (this.Ddl_StaffNo.SelectedValue != "")
        {
            SqlWhere += " and Proposer='" + this.Ddl_StaffNo.SelectedValue + "' ";
        }
        SqlWhere = SqlWhere + " order by ID desc ";
        DataSet ds = bll.GetList(SqlWhere);
        MyGridView1.DataSource = ds;
        MyGridView1.DataKeyNames = new string[] { "ID" };
        MyGridView1.DataBind();
    }
    public string Base_GetProjectGroup(String s_ID)
    {

        String s_Name = "";
        this.BeginQuery("select top 1 ProjectGroup from Knet_Sampling_OpenBilling where ID='" + s_ID + "'");
        this.QueryForDataTable();
        //this.BeginQuery("select * from PB_Basic_ProductsClass where PBP_ID='" + s_ID + "'");
        //this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            s_Name = base.Base_GetBasicCodeName("1137", Dtb_Re.Rows[0][0].ToString());
       }
        return s_Name;
    }
    public string Base_GetSuppNo(String s_ID)
    {

        String s_Name = "";
        this.BeginQuery("select top 1 Supplier from Knet_Sampling_OpenBilling where ID='" + s_ID + "'");
        this.QueryForDataTable();
        //this.BeginQuery("select * from PB_Basic_ProductsClass where PBP_ID='" + s_ID + "'");
        //this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            s_Name = Dtb_Re.Rows[0][0].ToString();
        }
        return s_Name;
    }
    public string Base_GetSamplingName(String s_ID)
    {

        String s_Name = "";
        this.BeginQuery("select  SamplingName from Knet_Sampling_OpenBilling where ID='" + s_ID + "' order by STime desc");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Re.Rows.Count; i++)
            {
                s_Name += Dtb_Re.Rows[i][0].ToString();
                s_Name += "<br/>";
            }

        }
        return s_Name;
    }
    public string Base_GetSamplingNumber(String s_ID)
    {

        String s_Name = "";
        this.BeginQuery("select  Number from Knet_Sampling_OpenBilling where ID='" + s_ID + "' order by STime desc");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Re.Rows.Count; i++)
            {
                s_Name += Dtb_Re.Rows[i][0].ToString();
                s_Name += "<br/>";
            }

        }
        return s_Name;
    }
    public string Base_GetSamplingPrice(string s_ID)
    {
        String s_Name = "";
        this.BeginQuery("select  Price from Knet_Sampling_OpenBilling where ID='" + s_ID + "' order by STime desc");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Re.Rows.Count; i++)
            {
                s_Name += Dtb_Re.Rows[i][0].ToString();
                s_Name += "<br/>";
            }

        }
        return s_Name;
    }
    public string Base_GetSamplingID(string s_ID)
    {
        String s_Name = "";
        this.BeginQuery("select TOP 1 ID from Knet_Sampling_OpenBilling where ID='" + s_ID + "' order by STime desc");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            
                s_Name += Dtb_Re.Rows[0][0].ToString();
                //s_Name += "<br/>";
           

        }
        return s_Name;
    }
    public string Base_GetSamplingTime(String s_ID)
    {

        String s_Name = "";
        this.BeginQuery("select TOP 1 STime from Knet_Sampling_OpenBilling where ID='" + s_ID + "' order by STime desc");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            s_Name += Dtb_Re.Rows[0]["STime"].ToString();
            s_Name += "<br/>";
        }
        return s_Name;
    }
    public string Base_GetProposer(String s_ID)
    {

        String s_Name = "";
        this.BeginQuery("select top 1 Proposer from Knet_Sampling_OpenBilling where ID='" + s_ID + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re1 = Dtb_Result;
        // String s_Name = "";
        this.BeginQuery("Select * From KNet_Resource_Staff Where StaffNo='" + Dtb_Re1.Rows[0][0].ToString() + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            s_Name = Dtb_Re.Rows[0]["StaffName"].ToString();
        }
        return s_Name;

    }
    protected string GetInState(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select top 1 * from Knet_Sampling_OpenBilling where ID='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["RState"].ToString() == "0")
                {
                    //string JSD = "KNetSamplingListAdd.aspx?ID=" + aa + "&RState=1";
                    return "<a href=\"\" onclick=\"\"  ><font color=blue>未打印</font></a>";
                   
                }
                else 
                {
                    //string JSD = "KNetSamplingListAdd.aspx?ID=" + aa + "&RState=0";
                    return "<a href=\"\" onclick=\"\"  ><font color=red>已打印</font></a>";
                   
                }

            }
            else
            {
                return "--";
            }
        }
    }

    protected void Btn_Del_OnClick(object sender, ImageClickEventArgs e)
    {
        string a = "";
        for (int i = 0; i < MyGridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {

                KNet.BLL.KNet_Sampling_List BLL = new KNet.BLL.KNet_Sampling_List();
                a+="'"+ MyGridView1.DataKeys[i].Value.ToString()+"'"+",";
             
               
            }
        }
        IDS.Text = a;
        string DoSqlOrder = " update Knet_Sampling_OpenBilling set  RState='1' where ID in(" + a.Substring(0, a.Length - 1) + ")";
        DbHelperSQL.ExecuteSql(DoSqlOrder);
        ClientScript.RegisterStartupScript(Page.GetType(), "", "GPrint();", true);
      // Server.Transfer("Procure_Sampling_View.aspx?ID=" + ID + "", true);
    }

    protected void Btn_Del1_OnClick(object sender, ImageClickEventArgs e)
    {
        for (int i = 0; i < MyGridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {

                KNet.BLL.Knet_Sampling_OpenBilling BLL = new KNet.BLL.Knet_Sampling_OpenBilling();
                bool a = BLL.Delete(MyGridView1.DataKeys[i].Value.ToString());
                if (a)
                {
                    AdminloginMess LogAM = new AdminloginMess();
                    LogAM.Add_Logs("制造费用 删除 操作成功！");
                    Alert("删除成功");
                    this.DataShows();
                    //this.RowOverYN();
                }
                else
                {
                    Alert("删除失败");
                }
            }
        }
    }

    protected void Ddl_StaffNo_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DataShows();
    }
}
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
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
using KNet.Common;

public partial class Web_Procure_ShipCheck_List : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("物流对账列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                this.DataShow();
            }
            //物流对账删除
            if (AM.YNAuthority("删除物流对账") == false)
            {
                this.Btn_Del.Enabled = false;
            }

            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");
            this.BtnSave.Attributes.Add("onclick", "return confirm('你确信要合并所选记录吗?！')");
            
            base.Base_DropBindSearch(this.bas_searchfield, "Cg_Order_Checklist");
            base.Base_DropBindSearch(this.Fields, "Cg_Order_Checklist");
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
            string Code = this.MyGridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            KNet.BLL.Cg_Order_Checklist Bll = new KNet.BLL.Cg_Order_Checklist();
            KNet.Model.Cg_Order_Checklist Model = Bll.GetModel(Code);

            if ((Model.COC_CheckYN == 1) || (IsFP(Code)))
            {
                cb.Enabled = false;
                e.Row.Cells[11].Text = "<font color=red>不能修改</font>";
            }
            else
            {
                cb.Enabled = true;
            }
        }
    }
    private void DataShow()
    {

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";

        string SqlWhere = " 1=1 and COC_Type='2' ";
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
        KNet.BLL.Cg_Order_Checklist BLL = new KNet.BLL.Cg_Order_Checklist();
        KNet.Model.Cg_Order_Checklist Model = new KNet.Model.Cg_Order_Checklist();
        DataSet ds = BLL.GetList(SqlWhere+" Order by COC_Ctime desc");
        this.MyGridView1.DataSource = ds;
        this.MyGridView1.DataKeyNames = new string[] { "COC_Code" };
        this.MyGridView1.DataBind();
    }

    protected void Btn_Query_Click(object sender, EventArgs e)
    {
      
        this.DataShow();
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
                    s_Sql.Append(" Update KNet_WareHouse_DirectOutList_Details set DZNumber=DZNumber-b.COD_DzNumber from KNet_WareHouse_DirectOutList_Details a,Cg_Order_Checklist_Details b where COD_DirectOutID=ID and COD_CheckNo='" + s_ID + "'");
                    s_Sql.Append(" delete from  Cg_Order_Checklist Where COC_Code='" + s_ID + "' ");
                    s_Sql.Append(" delete from  Cg_Order_Checklist_Details Where COD_CheckNo='" + s_ID + "' ");
                    s_Log.Append(s_ID);
                }
            }
            DbHelperSQL.ExecuteSql(s_Sql.ToString());
            this.DataShow();
            AdminloginMess AM = new AdminloginMess();
            AM.Add_Logs("对账单 删除 编号：" + s_Log + "");
            Alert("删除成功！");
        }
        catch(Exception ex)
        {
            Alert("删除失败！");
            return;
        }
       
    }

    /// <summary>
    /// 获取出库单明细数目
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu(string DirectOutNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as IDS  from KNet_WareHouse_DirectOutList_Details where DirectOutNo='" + DirectOutNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return int.Parse(dr["IDS"].ToString().Trim().ToString());
            }
            else
            {
                return -1;
            }
        }
    }

    public void btnBasicSearch_Click(object sender, EventArgs e)
    {
        this.advSearch.Style["display"] = "none";
        this.Search_basic.Style["display"] = "block";
        this.DataShow();
    }

    public void BtnSave_Click(object sender, EventArgs e)
    {

        StringBuilder s_Sql = new StringBuilder();
        StringBuilder s_Log = new StringBuilder();
        try
        {
            string s_SuppNo0 = "", s_SuppNo1="";
            int i_Flag=0;
            for (int i = 0; i < MyGridView1.Rows.Count; i++)
            {
                CheckBox Ckb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
                string s_FaterID = MyGridView1.DataKeys[i].Value.ToString();
                if (Ckb.Checked)
                {
                    KNet.BLL.Cg_Order_Checklist Bll = new KNet.BLL.Cg_Order_Checklist();
                    KNet.Model.Cg_Order_Checklist Model = Bll.GetModel(s_FaterID);
                    if (i == 0)
                    {
                        s_SuppNo0 = Model.COC_SuppNo;
                    }
                    else
                    {
                        if (Model.COC_SuppNo != s_SuppNo0)
                        {
                            Alert("供应商不同不能合并!");
                            i_Flag = 1;
                            return;
                        }
                    }
                }
            }
            if (i_Flag == 0)
            {
                for (int i = 0; i < MyGridView1.Rows.Count; i++)
                {
                    string s_FaterID = "";
                    
                    CheckBox Ckb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
                    if (i > 0)
                    {
                        if (Ckb.Checked)
                        {
                            string s_ID = MyGridView1.DataKeys[i].Value.ToString();
                            s_Sql.Append(" delete from  Cg_Order_Checklist Where COC_Code='" + s_ID + "' ");
                            s_Sql.Append(" Update Cg_Order_Checklist_Details set COD_CheckNo='" + s_FaterID + "' where COD_CheckNO='" + s_ID + "' ");
                            s_Log.Append(s_ID);
                        }
                    }
                    else
                    {
                        s_FaterID = MyGridView1.DataKeys[i].Value.ToString();
                    }
                }
                DbHelperSQL.ExecuteSql(s_Sql.ToString());
                this.DataShow();
                AdminloginMess AM = new AdminloginMess();
                AM.Add_Logs("物流对账单 合并 编号：" + s_Log + "");
                Alert("合并成功！");
            }
           
        }
        catch (Exception ex)
        {
            Alert("合并失败！");
            return;
        }
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
        this.DataShow();
    }
    public string GetShDetails(string s_COC_Code)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.Cg_Order_Checklist Bll = new KNet.BLL.Cg_Order_Checklist();
            KNet.Model.Cg_Order_Checklist Model = Bll.GetModel(s_COC_Code);
            if (Model.COC_CheckYN == 1)
            {//已审核
                if (Model.COC_Type == "1")
                {
                    s_Return = "<a href='Procure_MaterIn_View.aspx?ID=" + s_COC_Code + "&Type=0' target=\"_blank\">原材料入库单</a>";

                }
                else
                {
                    s_Return = "已审核";
                }
            }
            else
            {
                s_Return = "未审核";
            }
            if (IsFP(s_COC_Code))
            {
                s_Return += "<Br/><font color=red>已登记发票</font>";
            }
            if (IsYK(s_COC_Code))
            {
                s_Return += "<Br/><font color=red>已用款申请</font>";
            }
        }
        catch(Exception ex) { }
        return s_Return;
    }
    private bool IsFP(string s_COC_COde)
    {
        bool b_Return = false;
        try
        {
            this.BeginQuery("Select CABD_ID from CG_Account_Bill_Details a join Cg_Order_Checklist_Details b on a.CABD_CheckDetailsID=b.COD_Code where b.COD_CheckNo='" + s_COC_COde + "' ");
            string s_ID = this.QueryForReturn();
            if (s_ID != "")
            {
                b_Return = true;
            }
        }
        catch { }
        return b_Return;
    }
    private bool IsYK(string s_COC_COde)
    {
        bool b_Return = false;
        try
        {
            this.BeginQuery("Select * from CG_Payment_For a where a.CPF_WuliuID='" + s_COC_COde + "' ");
            string s_ID = this.QueryForReturn();
            if (s_ID != "")
            {
                b_Return = true;
            }
        }
        catch { }
        return b_Return;
    }
}

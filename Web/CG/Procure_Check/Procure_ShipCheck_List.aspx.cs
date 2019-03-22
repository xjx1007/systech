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
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;

public partial class Web_Procure_ShipCheck_List : BasePage
{
    public string s_AdvShow = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("采购对账列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                this.DataShow();
            }
            //采购对账删除
            if (AM.YNAuthority("删除采购对账") == false)
            {
                this.Btn_Del.Enabled = false;
            }

            this.Btn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");
            this.BtnSave.Attributes.Add("onclick", "return confirm('你确信要合并所选记录吗?！')");
            
            base.Base_DropBindSearch(this.bas_searchfield, "Cg_Order_Checklist");
            base.Base_DropBindSearch(this.Fields, "Cg_Order_Checklist");
        }
    }


    protected string GetPrint(string s_CheckNo)
    {

        KNet.BLL.Cg_Order_Checklist Bll = new KNet.BLL.Cg_Order_Checklist();
        KNet.Model.Cg_Order_Checklist Model = Bll.GetModel(s_CheckNo);

        string s_Return = "";
        if (Model.COC_IsSend == 0)
        {
            string JSD = "Procure_ShipCheck_List.aspx?ID=" + Model.COC_Code + "&Model=IsSend";
            s_Return = "<a href=\"" + JSD + "\" onclick=\"\"  ><font color=red>未发送</font></a>";
        }
        else if (Model.COC_IsSend == 1)
        {
            string JSD = "Procure_ShipCheck_List.aspx?ID=" + Model.COC_Code + "&Model=IsSend";
            s_Return = "<a href=\"" + JSD + "\" onclick=\"\" >已发送</a>";
        }
        else if (Model.COC_IsSend == 2)
        {
            string JSD = "Procure_ShipCheck_List.aspx?ID=" + Model.COC_Code + "&Model=IsSend";
            s_Return = "<a href=\"" + JSD + "\" onclick=\"\" ><font color=green>已确认</font></a>";
        }
        return s_Return;

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
                string s_FaterID = "";
                for (int i = 0; i < MyGridView1.Rows.Count; i++)
                {
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
                AM.Add_Logs("采购对账单 合并 编号：" + s_Log + "");
                Alert("合并成功！");
            }
           
        }
        catch (Exception ex)
        {
            Alert("合并失败！");
            return;
        }
    }

    public string CheckView(string s_COC_Code)
    {
        string s_Return = "";

        string JSD = "Procure_ShipCheck_View.aspx?ID=" + s_COC_Code + "";
        s_Return = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=120,left=150,toolbar=yes, menubar=yes,scrollbars=yes, resizable=yes, location=yes, status=yes, width=780,height=500');\"  title=\"点击查看\"><img src=\"../../images/View.gif\"  border=\"0\" /></a>";
        s_Return += "  <a href=\"PDF/" + s_COC_Code + ".PDF\" class=\"webMnu\" target=\"_blank\"><img src=\"../../images/pdf.gif\"  border=\"0\" /></a> ";
        s_Return += "  <a href=\"../../Mail/PB_Basic_Mail_Add.aspx?CheckNo=" + s_COC_Code + "\" class=\"webMnu\" target=\"_blank\"><img src=\"../../images/email.gif\"  border=\"0\" /></a> ";

        return s_Return;
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
    /// <summary>
    /// 导出未对账的生产订单
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_OnClick(object sender, EventArgs e)
    {
        string sql =
            "select a.OrderNo as '订单号',a.OrderDateTime as '下单日期',d.KSP_COde as '料号',d.ProductsName as '产品名称', c.SuppName as '供应商', b.OrderAmount as '订单数量',b.HandPrice as '单价',(b.OrderAmount*b.HandPrice) as '金额'from Knet_Procure_OrdersList a join Knet_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo join Knet_Procure_Suppliers c on a.SuppNo=c.SuppNo join KNet_Sys_Products d on b.ProductsBarCode=d.ProductsBarCode where a.OrderNo not in( select b.OrderNo from Cg_Order_Checklist_Details a join Knet_Procure_OrdersList b on a.COD_DirectOutID=b.OrderNo) and SystemDatetimes>='2018-06-01' and OrderType='128860698200781250' and KPO_Del!=1 and b.OrderNo  in (select OrderNo from Sc_Expend_Manage_RCDetails a join Knet_Procure_OrdersList_Details b on a.SER_OrderDetailID=b.ID ) order by SystemDatetimes ";
        DataTable table = DbHelperSQL.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        CreateExcel(table, "xls", "未对账的生产订单");
    }
    /// <summary>
    /// DataTable导出到Excel
    /// </summary>
    /// <param name="dt">DataTable类型的数据源</param>
    /// <param name="FileType">文件类型</param>
    /// <param name="FileName">文件名</param>
    public void CreateExcel(DataTable dt, string FileType, string FileName)
    {
        Response.Clear();
        Response.Charset = "UTF-8";
        Response.Buffer = true;
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls\"");
        Response.ContentType = FileType;
        string colHeaders = string.Empty;
        string ls_item = string.Empty;
        DataRow[] myRow = dt.Select();
        int i = 0;
        int cl = dt.Columns.Count;
        for (int j = 0; j < dt.Columns.Count; j++)
        {
            ls_item += dt.Columns[j].ColumnName + "\t"; //栏位：自动跳到下一单元格
        }
        ls_item = ls_item.Substring(0, ls_item.Length - 1) + "\n";
        foreach (DataRow row in myRow)
        {
            for (i = 0; i < cl; i++)
            {
                if (i == (cl - 1))
                {
                    ls_item += row[i].ToString() + "\n";
                }
                else
                {
                    ls_item += row[i].ToString() + "\t";
                }
            }
            Response.Output.Write(ls_item);
            ls_item = string.Empty;
        }
        Response.Output.Flush();
        Response.End();
    }

}

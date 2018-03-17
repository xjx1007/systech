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
using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 选择报价单
/// </summary>
public partial class Knet_Common_SelectBaoPriceListSelectBaoPriceListtoselects : System.Web.UI.Page
{
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

                ViewState["SortOrder"] = "BaoPriceDateTime";
                ViewState["OrderDire"] = "Desc";
                this.Button2.Attributes.Add("onclick", "return confirm('你确定要选择所选的记录吗?！')");

               
                this.DataShows();
                this.RowOverYN();
            }
        }
    }
    /// <summary>
    /// 是不是有记录
    /// </summary>
    protected void RowOverYN()
    {
        if (GridView1.Rows.Count == 0) //如果没有记录
        {
            this.Button2.Enabled = false;
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sales_BaoPriceList bll = new KNet.BLL.KNet_Sales_BaoPriceList();
        //string LogtimeA = null;
        //string LogtimeB = null;
        string KSeachKey = null;

        string SqlWhere = " 1=1 ";

        //if (Request["LogtimeA"] != null && Request["LogtimeB"] != null && Request["LogtimeA"] != "" && Request["LogtimeB"] != "")
        //{
        //    LogtimeA = Request.QueryString["LogtimeA"].ToString().Trim();
        //    if (LogtimeA == "") { LogtimeA = null; }
        //    this.StartDate.Text = LogtimeA;

        //}
        //if (Request["LogtimeB"] != null && Request["LogtimeA"] != null && Request["LogtimeB"] != "" && Request["LogtimeA"] != "")
        //{
        //    LogtimeB = Request.QueryString["LogtimeB"].ToString().Trim();
        //    if (LogtimeB == "") { LogtimeB = null; }
        //    this.EndDate.Text = LogtimeB;

        //    SqlWhere = SqlWhere + " and ( BaoPriceDateTime >= '" + LogtimeA + "' and  BaoPriceDateTime<='" + LogtimeB + "'   ) ";
        //}
        if (this.SeachKey.Text != "")
        {
            SqlWhere = SqlWhere + " and ( BaoPriceTopic like '%" + this.SeachKey.Text + "%' or BaoPriceNo  like '%" + this.SeachKey.Text + "%' or BaoPriceWarranty like '%" + this.SeachKey.Text + "%' )";
        }

        if (this.DropDownList1.SelectedValue != "")
        {
            SqlWhere = SqlWhere + " and  BaoPriceCheckYN = " + this.DropDownList1.SelectedValue + " ";
        }
        SqlWhere = SqlWhere + " order by BaoPriceDateTime desc";

        DataSet ds = bll.GetList(SqlWhere);
            GridView1.DataSource = ds;
            GridView1.DataKeyNames = new string[] { "BaoPriceNo" };
            GridView1.DataBind();

    }
    /// <summary>
    /// 确定选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string cal = "";
        string SuppNoVale = "";
        int KK = 0;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " CustomerValue='" + GridView1.DataKeys[i].Value.ToString() + "' or";
                SuppNoVale = GridView1.DataKeys[i].Value.ToString();
                KK = KK + 1;
            }
        }
        if (KK > 1)
        {
            Response.Write("<script language=javascript>alert('每次只能选择一个报价单！');window.close();</script>");
            Response.End();
        }

        if (cal == "")
        {
            Response.Write("<script language=javascript>alert('您没有选择记录！\\n\\n注意:每次只能选择一个报价单');window.close();</script>");
            Response.End();
        }
        else
        {
            if (SuppNoVale == null || SuppNoVale == "")
            {
                Response.Write("<script language=javascript>alert('您没有选择记录！\\n\n注意:每次只能选择一个报价单！');window.close();</script>");
                Response.End();
            }
            else
            {
                string s_Return = SuppNoVale + "|" + GetBaoPriceTopic(SuppNoVale);
                StringBuilder s = new StringBuilder();
                s.Append("<script language=javascript>" + "\n");
                s.Append("if (window.opener != undefined)\n");
                s.Append("{\n");
                s.Append("    window.opener.returnValue = '" + s_Return + "';\n");
                s.Append("    window.opener.SetReturnValueInOpenner_BaoPrice('" + s_Return + "');\n");
                s.Append("}\n");
                s.Append("else\n");
                s.Append("{\n");
                s.Append("    window.returnValue = '" + s_Return + "';\n");
                s.Append("}\n");
                s.Append("window.close();" + "\n");
                s.Append("</script>");
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                string csname = "ltype";
                if (!cs.IsStartupScriptRegistered(cstype, csname))
                    cs.RegisterStartupScript(cstype, csname, s.ToString());
            }
        }
    }

    /// <summary>
    /// 取消所有已选中列
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gr in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gr.Cells[0].FindControl("Chbk");
                chk.Checked = false;
            }
            GridView1.EditIndex = -1;
            this.DataShows();
        }
        catch { }
    }



    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button4_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }


    /// <summary>
    /// 返回客户名称（Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetCustomerValueName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,CustomerValue,CustomerName from KNet_Sales_ClientList where CustomerValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["CustomerName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 返回采购公司名称（Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetStrucNameNane(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StrucValue,StrucName from KNet_Resource_OrganizationalStructure where StrucValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["StrucName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 获取单明细数目 （Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu(string BaoPriceNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as IDS  from KNet_Sales_BaoPriceList_Details where BaoPriceNo='" + BaoPriceNo + "'";
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
    /// <summary>
    /// 返回审核情况（Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetBaoPriceCheckYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,BaoPriceNo,BaoPriceCheckYN from KNet_Sales_BaoPriceList where BaoPriceNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["BaoPriceCheckYN"].ToString() == "True")
                {
                    return "<img src=\"../../images/gou.gif\"  border=\"0\" />";
                }
                else
                {
                    if (Knet_Procure_OrdersList_Details_Shu(aa.ToString()) <= 0)
                    {
                        return "<img src=\"../../images/Nodata.gif\"  border=\"0\"  alt=\"未完成的报价单（没有明细记录）\" />";
                    }
                    else
                    {
                        return "未审";
                    }
                }
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 返回报价主题
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetBaoPriceTopic(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,BaoPriceNo,BaoPriceTopic from KNet_Sales_BaoPriceList where BaoPriceNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["BaoPriceTopic"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }
}

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
/// 选择销售客户
/// </summary>
public partial class Knet_Common_SelectClientList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "选择客户";

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
                DataSet ds = KNet.Common.KNet_Static_Province.GetProvinceInfo("");
                string code, name;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    code = ds.Tables[0].Rows[i]["code"].ToString();
                    name = ds.Tables[0].Rows[i]["name"].ToString();
                    this.sheng.Items.Add(new ListItem(name, code));
                }

                this.city.Disabled = true;

                this.HyperLink1.NavigateUrl = "SelectSalesClientList.aspx?Sn=" + DateTime.Now.ToFileTimeUtc().ToString() + "";
                this.HyperLink2.NavigateUrl = "SelectSalesClientListProtect.aspx?Sn=" + DateTime.Now.ToFileTimeUtc().ToString() + "";
                        
                ViewState["SortOrder"] = "CustomerAddtime";
                ViewState["OrderDire"] = "Desc";
                this.Button2.Attributes.Add("onclick", "return confirm('你确定要选择所选的记录吗?！')");

               
                this.DataShows();
            }
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sales_ClientList bll = new KNet.BLL.KNet_Sales_ClientList();
        string KSeachKey = null;
        string s_ID = Request.QueryString["sID"].ToString();
        s_ID = s_ID.Replace(",", "','");
        string SqlWhere = " CustomerProtect=0 ";
        if (s_ID!="")
        {
            SqlWhere += " and CustomerValue not in ('" + s_ID + "')";
        }

        if (Request["KSeachKey"] != null && Request["KSeachKey"] != "")
        {
            KSeachKey = Request.QueryString["KSeachKey"].ToString().Trim();
            if (KSeachKey == "") { KSeachKey = null; }
            this.SeachKey.Text = KSeachKey;

            SqlWhere = SqlWhere + " and ( CustomerName like '%" + KSeachKey + "%' or CustomerContact  like '%" + KSeachKey + "%' or CustomerTel  like '%" + KSeachKey + "%' or CustomerMobile  like '%" + KSeachKey + "%' )";
        }

        if (Request["CustomerProvinces"] != null && Request["CustomerProvinces"] != "" && Request["CustomerProvinces"] != "0")
        {
            string CustomerProvinces = Request.QueryString["CustomerProvinces"].ToString().Trim();
            this.sheng.Value = CustomerProvinces;
            SqlWhere = SqlWhere + " and   CustomerProvinces = '" + CustomerProvinces + "' ";
        }
        if (Request["CustomerCity"] != null && Request["CustomerCity"] != "" && Request["CustomerCity"] != "0")
        {
            string CustomerCity = Request.QueryString["CustomerCity"].ToString().Trim();
            SqlWhere = SqlWhere + " and   CustomerCity = '" + CustomerCity + "' ";
        }
        SqlWhere = SqlWhere + " order by CustomerAddtime desc";
        DataSet ds = bll.GetList(SqlWhere);
        
            MyGridView1.DataSource = ds;
            MyGridView1.DataKeyNames = new string[] { "CustomerValue" };
            MyGridView1.DataBind();
            ds.Dispose();
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
        for (int i = 0; i < MyGridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " CustomerValue='" + MyGridView1.DataKeys[i].Value.ToString() + "' or";
                SuppNoVale += MyGridView1.DataKeys[i].Value.ToString() + ",";
                KK = KK + 1;
            }
        }

        if (cal == "")
        {
            Response.Write("<script language=javascript>alert('您没有选择记录！');window.close();</script>");
            Response.End();
        }
        else
        {
            if (SuppNoVale == null || SuppNoVale == "")
            {
                Response.Write("<script language=javascript>alert('您没有选择记录！！');window.close();</script>");
                Response.End();
            }
            else
            {
                string s_Return = SuppNoVale.Substring(0, SuppNoVale.Length - 1) + "|" + base.Base_GetCustomerNames(SuppNoVale.Substring(0, SuppNoVale.Length - 1)) ;
                StringBuilder s = new StringBuilder();
                s.Append("<script language=javascript>" + "\n");
                //s.Append("window.returnValue='" + SuppNoVale.Substring(0, SuppNoVale.Length - 1) + "|" + base.Base_GetCustomerNames(SuppNoVale.Substring(0, SuppNoVale.Length - 1)) + "';" + "\n");
                s.Append("if (window.opener != undefined)\n");
                s.Append("{\n");
                s.Append("    window.opener.returnValue = '" + s_Return + "';\n");
                s.Append("    window.opener.SetReturnValueInOpenner_Client('" + s_Return + "');\n");
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
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click1(object sender, EventArgs e)
    {
        string Sekety = KNetPage.KHtmlEncode(this.SeachKey.Text.Trim());
        Response.Redirect("SelectSalesClientList.aspx?KSeachKey=" + Sekety + "");
        Response.End();
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
    /// <summary>
    /// 返回省份
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetClient_CustomerProvinces(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select id,code,name from KNet_Static_Province where code='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["name"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
  
    /// <summary>
    /// 返回客户地址
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetCustomerNameAdress(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,CustomerValue,CustomerName,CustomerAddress from KNet_Sales_ClientList where CustomerValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["CustomerAddress"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 按省城 筛选记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button12_Click1(object sender, EventArgs e)
    {
        string CustomerProvinces = this.sheng.Value.ToString();
        string CustomerCity = "0";
        if (Request["city"] != null && Request["city"] != "")
        {
            CustomerCity = Request["city"].Trim();
        }

        Response.Redirect("SelectSalesClientList.aspx?CustomerProvinces=" + CustomerProvinces + "&CustomerCity=" + CustomerCity + "&Css1=Div22");
        Response.End();
    }
}

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
public partial class Knet_Common_SelectSalesClientList : BasePage
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

        string SqlWhere = " CustomerProtect=0 ";

        if (this.SeachKey.Text != "")
        {
            KSeachKey = this.SeachKey.Text;
            if (KSeachKey == "") { KSeachKey = null; }
            this.SeachKey.Text = KSeachKey;

            SqlWhere = SqlWhere + " and ( CustomerName like '%" + KSeachKey + "%' or CustomerContact  like '%" + KSeachKey + "%' or CustomerTel  like '%" + KSeachKey + "%' or CustomerMobile  like '%" + KSeachKey + "%' )";
        }

        SqlWhere = SqlWhere + " order by CustomerAddtime desc";

        DataSet ds = bll.GetList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "CustomerValue" };
        GridView1.DataBind();
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        this.DataShows();
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
        string s_Code = "", s_Code1 = "";
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
        s_Code = "QUT" + SuppNoVale.Substring(1, SuppNoVale.Length - 1) + KNetOddNumbers();
        s_Code1 = "CP" + SuppNoVale.Substring(1, SuppNoVale.Length - 1) + KNetOddNumbers1(SuppNoVale);


        if (SuppNoVale == null || SuppNoVale == "")
        {
            Response.Write("<script language=javascript>alert('您没有选择记录！\\n\n注意:每次只能选择一个客户！');window.close();</script>");
            Response.End();
        }
        else
        {
            string s_PayMentType = "", s_DutyPerson = "";
            this.BeginQuery("Select top 1 * from KNET_Sales_ContractList where CustomerValue='" + SuppNoVale + "' order by ContractDateTime Desc");
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                s_PayMentType = Dtb_Result.Rows[0]["Payment"].ToString();
                s_DutyPerson = Dtb_Result.Rows[0]["DutyPerson"].ToString();
            }
            else
            {
                s_DutyPerson = base.Base_GetCustomerDutyPerson(SuppNoVale);
            }

            StringBuilder s = new StringBuilder();
            s.Append("<script language=javascript>" + "\n");
            s.Append("window.returnValue='" + SuppNoVale + "|" + base.Base_GetCustomerName(SuppNoVale) + "|" + GetCustomerNameAdress(SuppNoVale) + "|" + s_Code + "|" + s_Code1 + "|" + s_PayMentType + "|" + s_DutyPerson + "';" + "\n");
            s.Append("window.close();" + "\n");
            s.Append("</script>");
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            string csname = "ltype";
            if (!cs.IsStartupScriptRegistered(cstype, csname))
                cs.RegisterStartupScript(cstype, csname, s.ToString());
        }
    }


    /// <summary>
    /// 返回当前的  单号 （唯一性，如 2009121402）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string KNetOddNumbers1(string s_CustomerValue)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select Isnull(MAX(XOL_Code),0)  as AA  from  XS_Compy_LinkMan Where XOL_Compy='" + s_CustomerValue + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["AA"].ToString() == "0")
                {
                    return "001";
                }
                else
                {
                    return this.KNus(int.Parse(dr["AA"].ToString().Substring(7, 3)) + 1);
                }
            }
            else
            {
                return "001";
            }
        }
    }
    #region 返回单号情况



    /// <summary>
    /// 返回当前的  单号 （唯一性，如 2009121402）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string KNetOddNumbers()
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as AA  from  KNet_Sales_BaoPriceList  where (datediff(d,SystemDatetimes,GETDATE())=0)";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (int.Parse(dr["AA"].ToString()) == 0)
                {
                    return DateTime.Today.ToString("yyyyMMdd") + "01";
                }
                else
                {
                    return DateTime.Today.ToString("yyyyMMdd") + KNus003(int.Parse(dr["AA"].ToString()) + 1);
                }
            }
            else
            {
                return DateTime.Today.ToString("yyyyMMdd") + "01";
            }
        }
    }
    /// <summary>
    /// 返回当前的  单号 （唯一性，如 2009121402）
    /// </summary>
    /// <param name="ss"></param>
    /// <returns></returns>
    protected string KNus003(int ss)
    {
        if (ss.ToString().Length == 1)
        {
            return "0" + ss.ToString();
        }
        else
        {
            return ss.ToString();
        }
    }
    #endregion
    /// <summary>
    /// 返回当前的  单号 （唯一性，如 2009121402）
    /// </summary>
    /// <param name="ss"></param>
    /// <returns></returns>
    protected string KNus(int ss)
    {
        if (ss.ToString().Length == 1)
        {
            return "00" + ss.ToString();
        }
        if (ss.ToString().Length == 2)
        {
            return "0" + ss.ToString();
        }
        else
        {
            return ss.ToString();
        }
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
    public string GetLink(string s_CustomerValue)
    {
        string s_Return = "";
        try
        {

            string s_Code = "", s_Code1 = "";
            s_Code = "QUT" + s_CustomerValue.Substring(1, s_CustomerValue.Length - 1) + KNetOddNumbers();
            s_Code1 = "CP" + s_CustomerValue.Substring(1, s_CustomerValue.Length - 1) + KNetOddNumbers1(s_CustomerValue);

            string s_PayMentType = "", s_DutyPerson = "";
            this.BeginQuery("Select top 1 * from KNET_Sales_ContractList where CustomerValue='" + s_CustomerValue + "' order by ContractDateTime Desc");
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                s_PayMentType = Dtb_Result.Rows[0]["Payment"].ToString();
                s_DutyPerson = Dtb_Result.Rows[0]["DutyPerson"].ToString();
            }
            else
            {
                s_DutyPerson = base.Base_GetCustomerDutyPerson(s_CustomerValue);
            }
            //s_Code = "QUT" + SuppNoVale.Substring(1, SuppNoVale.Length - 1) + KNetOddNumbers();
            s_Return += "<a href=\"javascript:window.close();\" onclick='set_return_Customer(\"" + s_CustomerValue + "|" + base.Base_GetCustomerName(s_CustomerValue) + "|" + GetCustomerNameAdress(s_CustomerValue) + "|" + s_Code + "|" + s_Code1 + "|" + s_PayMentType + "|" + s_DutyPerson + "\");'>" + base.Base_GetCustomerName(s_CustomerValue) + "</a>";

        }
        catch
        {
            s_Return = "-";

        }
        return s_Return;
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
}

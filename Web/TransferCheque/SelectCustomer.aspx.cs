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
public partial class Knet_Common_SelectCustomer : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "选择客户";
        Ajax.Utility.RegisterTypeForAjax(typeof(Knet_Common_SelectCustomer));
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
                base.Base_DropSheng(this.sheng);
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
            SqlWhere = SqlWhere + " and ( CustomerName like '%" + KSeachKey + "%' or CustomerContact  like '%" + KSeachKey + "%' or CustomerTel  like '%" + KSeachKey + "%' or CustomerMobile  like '%" + KSeachKey + "%' )";
        }
        if (this.sheng.SelectedValue  != "" )
        {
            string CustomerProvinces = this.sheng.SelectedValue;
            SqlWhere = SqlWhere + " and   CustomerProvinces = '" + CustomerProvinces + "' ";
        }
        SqlWhere = SqlWhere + " order by CustomerAddtime desc";
        DataSet ds = bll.GetList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "CustomerValue" };
        GridView1.DataBind();
    }
   

    public string GetLink(string s_CustomerValue)
    {
        string s_Return = "";
        try
        {
            //s_Code = "QUT" + SuppNoVale.Substring(1, SuppNoVale.Length - 1) + KNetOddNumbers();
            string s_Code = "CP" + s_CustomerValue.Substring(1, s_CustomerValue.Length - 1) + KNetOddNumbers1(s_CustomerValue);
            s_Return += "<a href=\"javascript:window.close();\" onclick='set_return_Customer(\"" + s_CustomerValue + "\", \"" + base.Base_GetCustomerName(s_CustomerValue) + "\", \"" + s_Code + "\");'>" + base.Base_GetCustomerName(s_CustomerValue) + "</a>";
        }
        catch
        {
            s_Return = "-";
 
        }
        return s_Return;
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
                    return  "001";
                }
                else
                {
                    return  this.KNus(int.Parse(dr["AA"].ToString().Substring(7,3)) + 1);
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
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click1(object sender, EventArgs e)
    {
        this.DataShows();
    }

    [Ajax.AjaxMethod()]
    public string LinMan_Bind(string s_CustomerValue)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_Sales_ClientList bll = new KNet.BLL.KNet_Sales_ClientList();
            KNet.Model.KNet_Sales_ClientList Model = bll.GetModelB(s_CustomerValue);
            s_Return += Model.BankAccount + "#" + Model.OpeningBank + "#" + base.Base_GetCityName(Model.CustomerProvinces) + "#" + base.Base_GetShiName(Model.CustomerCity);
            return s_Return;
        }
        catch
        {
            return s_Return;
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
}

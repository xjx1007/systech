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
/// 选择发货单
/// </summary>
public partial class Knet_Common_SelectSalesShipList : BasePage
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        KNet.DBUtility.AdminloginMess AMLanguage = new KNet.DBUtility.AdminloginMess();
        if (AMLanguage.KNet_Soft_StaffLanguage == 2)
        {
            // 1、默认为简体转繁体，编码为utf-8
            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter);
        }
        else if (AMLanguage.KNet_Soft_StaffLanguage == 1)
        {
            // 2、繁体简体转，编码为utf-8
            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter, LU.Web.ChineseConvertor.CCDirection.T2S);
        }
        else
        { }
    }
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
                ViewState["SortOrder"] = "OutWareDateTime";
                ViewState["OrderDire"] = "Desc";
                this.Button2.Attributes.Add("onclick", "return confirm('你确定要选择所选的记录吗?！')");

                this.SeachKey.Focus();

                this.DataShows();
                
            }
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sales_OutWareList bll = new KNet.BLL.KNet_Sales_OutWareList();

        string Sql = " Select * ";
        Sql+=" From KNet_Sales_OutWareList a Where 1=1  ";
        string SqlWhere = " ";//and OutWareCheckYN=1

        if (this.StartDate.Text != "")
        {
            SqlWhere = SqlWhere + " and  OutWareDateTime >= '" + this.StartDate.Text + "'";
        }
        if (this.EndDate.Text != "")
        {
            SqlWhere = SqlWhere + " and  OutWareDateTime<='" + this.EndDate.Text + "'  ";

        }
        if (this.Ddl_isShip.SelectedValue != "")
        {
            if (this.Ddl_isShip.SelectedValue == "0")//未发货
            {
                SqlWhere = SqlWhere + " and OutWareNo not in (select KWD_ShipNo from KNet_WareHouse_DirectOutList ) ";
            }

            else if (this.Ddl_isShip.SelectedValue == "1")//部分发货
            {
                SqlWhere = SqlWhere + " and OutWareNo  in (select KWD_ShipNo from KNet_WareHouse_DirectOutList  and isship='0') ";
            }
            else if (this.Ddl_isShip.SelectedValue == "2")//未发货
            {
                SqlWhere = SqlWhere + " and OutWareNo  in (select KWD_ShipNo from KNet_WareHouse_DirectOutList ) ";
            }
        }
        if (this.SeachKey.Text != "")
        {
            SqlWhere = SqlWhere + " and ( OutWareTopic like '%" + this.SeachKey.Text + "%' or OutWareNo  like '%" + this.SeachKey.Text + "%' )";
        }
        SqlWhere = SqlWhere + " order by OutWareDateTime desc";
        this.BeginQuery(Sql + SqlWhere);
        this.QueryForDataSet();
        GridView1.DataSource = this.Dts_Result;
        GridView1.DataKeyNames = new string[] { "OutWareNo" };
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
        string OutWareNo = "";
        int KK = 0;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " OutWareNo='" + GridView1.DataKeys[i].Value.ToString() + "' or";
                OutWareNo = GridView1.DataKeys[i].Value.ToString();
                KK = KK + 1;
            }
        }
        if (KK > 1)
        {
            Alert("每次只能选择一个发货单！");
        }

        if (cal == "")
        {

            Alert("您没有选择记录！\\n\\n注意:每次只能选择一个发货单");
        }
        else
        {
            if (OutWareNo == null || OutWareNo == "")
            {


                Alert("您没有选择记录！\\n\\n注意:每次只能选择一个发货单");
            }
            else
            {
                string s_Return = OutWareNo + "|" + GetKNet_ContractTopic(OutWareNo) + "(" + OutWareNo + ")';";
                StringBuilder s = new StringBuilder();
                s.Append("<script language=javascript>" + "\n");
                //s.Append("window.returnValue='" + OutWareNo + "|" + GetKNet_ContractTopic(OutWareNo) + "(" + OutWareNo + ")';" + "\n");
                s.Append("if (window.opener != undefined)\n");
                s.Append("{\n");
                s.Append("    window.opener.returnValue = '" + s_Return + "';\n");
                s.Append("    window.opener.SetReturnValueInOpenner_SalesShip('" + s_Return + "');\n");
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
    protected void Button4_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }


    /// <summary>
    /// 返回发货单主题
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetKNet_ContractTopic(object OutWareNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,OutWareNo,OutWareTopic from KNet_Sales_OutWareList where OutWareNo='" + OutWareNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["OutWareTopic"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    public string GetState(string s_OutWareNo)
    {
        this.BeginQuery("Select isShip from KNet_WareHouse_DirectOutList Where KWD_ShipNo='" + s_OutWareNo + "' ");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            if (this.Dtb_Result.Rows[0][0].ToString() == "1")
            {
                return "已发货";
            }
            else
            {
                return "部分发货";
            }

        }
        else
        {
            return "未发货";
        }
    }
    protected void Ddl_isShip_TextChanged(object sender, EventArgs e)
    {
        if (this.Ddl_isShip.SelectedValue != "")
        {
            this.DataShows();
        }
    }
}

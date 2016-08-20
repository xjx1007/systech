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

public partial class Web_Sales_Sales_ShipWareOut_Manage : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {

                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                this.DataBind("");
                base.Base_DropWareHouseBind(this.Drop_House, AM.MyDoSqlWith_Do);
            }
        }
    }

    private void DataBind(string s_Sql)
    {
        KNet.BLL.KNet_WareHouse_DirectOutList BLL = new KNet.BLL.KNet_WareHouse_DirectOutList();
        KNet.Model.KNet_WareHouse_DirectOutList Model = new KNet.Model.KNet_WareHouse_DirectOutList();
        DataSet ds = BLL.GetList(" KWD_Del='0' and KWD_Type='101' " + s_Sql + " Order by SystemDateTimes desc");
        this.MyGridView1.DataSource = ds;
        this.MyGridView1.DataKeyNames = new string[] { "DirectOutNo" };
        this.MyGridView1.DataBind();
    }

    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        string s_Sql = "";
        if (this.Tbx_CustomerName.Text != "")
        {
            s_Sql += "and KWD_Custmoer in (Select CustomerValue From KNet_Sales_ClientList Where CustomerName like '%" + this.Tbx_CustomerName.Text + "%')";
        }
        if (this.Tbx_DirectNo.Text != "")
        {
            s_Sql += " and DirectOutNo like '%" + this.Tbx_DirectNo.Text + "%'";
        }
        if (this.Tbx_ReceiveMan.Text != "")
        {
            s_Sql += " and Kwd_contentPerson like '%" + this.Tbx_ReceiveMan.Text + "%' ";
        }
        if (this.Drop_House.SelectedValue != "")
        {
            s_Sql += " and HouseNo='" + this.Drop_House.SelectedValue + "' ";
        }
        this.DataBind(s_Sql);
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
                    string s_ID = MyGridView1.Rows[i].Cells[1].Text;
                    s_Sql.Append(" delete from  KNet_WareHouse_DirectOutList Where DirectOutNo='" + s_ID + "' ");
                    s_Sql.Append(" delete from  KNet_WareHouse_DirectOutList_Details Where DirectOutNo='" + s_ID + "' ");
                    s_Log.Append(s_ID);
                }
            }
            DbHelperSQL.ExecuteSql(s_Sql.ToString());
            this.DataBind("");
            AdminloginMess AM = new AdminloginMess();
            AM.Add_Logs("KNet_WareHouse_DirectOutList 删除 编号：" + s_Log + "");
            Alert("删除成功！");
        }
        catch(Exception ex)
        {
            Alert("删除失败！");
            return;
        }
       
    }

    /// <summary>
    /// 返回审核情况
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetOrderCheckYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,DirectOutNo,DirectOutCheckYN from KNet_WareHouse_DirectOutList where DirectOutNo='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["DirectOutCheckYN"].ToString() == "True")
                {
                    return "<img src=\"../../images/gou.gif\"  border=\"0\" />";
                }
                else
                {
                    if (Knet_Procure_OrdersList_Details_Shu(aa.ToString()) <= 0)
                    {
                        return "<a href=\"../WareHouse/KNet_WareHouse_DirectOut_AddDetails.aspx?DirectOutNo=" + aa + "&Type=101\"><img src=\"../../images/Nodata.gif\"  border=\"0\"  title=\"未完成的出库单（没有明细记录）\" /></a>";
                    }
                    else
                    {
                        string JSD = "../WareHouse/pop/KNet_WareHouse_DirectOutCheckYN.aspx?DirectOutNo=" + aa.ToString() + "";
                        string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=400,height=250');\"  title=\"点击进行审核操作\">审核</a>";
                        return StrPop;
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
}

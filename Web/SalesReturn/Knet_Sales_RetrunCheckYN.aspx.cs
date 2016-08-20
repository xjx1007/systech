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
using System.Text;

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 对退货单进行审核  -----------产生财务，运输等财务记录
/// </summary>
public partial class Knet_Web_Sales_pop_Knet_Sales_RetrunCheckYN : System.Web.UI.Page
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
            if (AM.CheckLogin("退货单审核") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }

            if (Request.QueryString["ReturnNo"] != null && Request.QueryString["ReturnNo"] != "")
            {
                this.UsersNotxt.Text = Request.QueryString["ReturnNo"].ToString().Trim();

                if (Knet_Procure_OrdersList_Details_Shu(Request.QueryString["ReturnNo"].ToString().Trim()) <= 0)
                {
                    this.MyStatStr.Visible = true;
                    this.MyStatStr.Text = "此退货单未添加有产品明细，不能进行审核操作！";
                    this.Button1.Enabled = false;
                }
            }
            else
            {
                Response.Write("<script>alert('非法参数！');window.close();</script>");
                Response.End();
            }
        }
    }


    /// <summary>
    /// 是否是自己的订单？
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetProcureOrders_onselftYN(string ProcureBM)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select * from KNet_Sales_ReturnList where ReturnNo='" + ProcureBM + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["ReturnStaffNo"].ToString();
            }
            else
            {
                return "";
            }
        }
    }
    /// <summary>
    /// 审核操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (AM.CheckLogin() == false)
        {
            Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
            Response.End();
        }
        else
        {
            int AA = int.Parse(this.DropDownList1.SelectedValue);
            string OrderNotxt = this.UsersNotxt.Text.Trim();
            string OrderCheckStaffNo = AM.KNet_StaffNo;

            //if (GetProcureOrders_onselftYN(OrderNotxt).ToLower() == AM.KNet_StaffNo.ToLower())
            //{
            //    Response.Write("<script>alert('自己开的单不能自己审核！');window.opener.location.reload();window.close();</script>");
            //    Response.End();
            //}

            if (AA != -1)
            {
                if (AA == 1) //通过审核
                {
                    string DoSql = "update KNet_Sales_ReturnList  set ReturnCheckYN=" + AA + ",ReturnCheckStaffNo ='" + OrderCheckStaffNo + "' ,ReturnState=1  where  ReturnNo='" + OrderNotxt + "' ";
                    DbHelperSQL.ExecuteSql(DoSql);

                    AM.Add_Logs("退货单审核成功.退货单：" + OrderNotxt + "");
                    string s_Return = "<script>alert('审核成功，点 确定 返回！');";
                    s_Return += "window.opener.location.reload();window.close();</script>";
                    Response.Write(s_Return);

          
                }
                else
                {
                    Response.Write("<script>alert('没通过审核，点 确定 返回！');window.opener.location.reload();window.close();</script>");
                    Response.End();
                }
            }
        }
    }



    /// <summary>
    /// 获取发货单明细数目
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu(string ReturnNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as IDS  from KNet_Sales_ReturnList_Details where ReturnNo='" + ReturnNo + "'";
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

﻿using System;
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
/// 对退货单进行审核,并生成应收款单 （采购退货收款）
/// </summary>
public partial class Knet_Web_Procure_pop_Knet_Procure_ReturnCheckYN : System.Web.UI.Page
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
            string Dostr = "select * from Knet_Procure_ReturnList where ReturnNo='" + ProcureBM + "'";
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
                    string DoSql = "update Knet_Procure_ReturnList  set  ReturnCheckYN=" + AA + ",ReturnCheckStaffNo ='" + OrderCheckStaffNo + "' where  ReturnNo='" + OrderNotxt + "' ";
                    DbHelperSQL.ExecuteSql(DoSql);

                    AM.Add_Logs("采购退货单审核成功.退货单：" + OrderNotxt + "");



                    Response.Write("<script>alert('采购退货审核成功，点 确定 返回！');window.opener.location.reload();window.close();</script>");
                    Response.End();
                }
                else
                {
                    Response.Write("<script>alert('采购退货没通过审核，点 确定 返回！');window.opener.location.reload();window.close();</script>");
                    Response.End();
                }
            }
        }
    }



    /// <summary>
    /// 获取采购单明细数目
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu(string ReturnNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as IDS  from Knet_Procure_ReturnList_Details where ReturnNo='" + ReturnNo + "'";
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

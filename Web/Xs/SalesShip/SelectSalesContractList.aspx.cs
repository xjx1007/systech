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
using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 选择合同单
/// </summary>
public partial class Knet_Common_SelectSalesContractList : BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Knet_Common_SelectSalesContractList));
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
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                string s_ContractNO = Request.QueryString["ContractNO"] == null ? "" : Request.QueryString["ContractNO"].ToString();
                string s_CustomerValue = Request.QueryString["CustomerValue"] == null ? "" : Request.QueryString["CustomerValue"].ToString();
                string s_ProductsBarCode = Request["sID"] == null ? "" : Request["sID"].ToString();
                this.Tbx_ProductsBarCode.Text = s_ProductsBarCode;
                this.Tbx_ID.Text = s_ID;
                this.Tbx_CustomerValue.Text = s_CustomerValue;
                this.Tbx_COntractNo.Text = s_ContractNO;

                ViewState["SortOrder"] = "ContractDateTime";
                ViewState["OrderDire"] = "Desc";
                if (Request.QueryString["Type"] != null)
                {
                    this.Drop_State.SelectedValue = "";
                }
                this.Tbx_Name.Focus();

                this.DataShows();
                this.RowOverYN();
                if (this.Tbx_ID.Text == "")
                {
                    this.Button2.Enabled = false;
                    this.Button1.Enabled = true;
                    this.Button3.Enabled = true;
                }
                else
                {
                    this.Button2.Enabled = true; ;
                    this.Button1.Enabled = false;
                    this.Button3.Enabled = false;
                }
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
        else
        {
            this.Button2.Enabled = true;
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sales_ContractList bll = new KNet.BLL.KNet_Sales_ContractList();

        string SqlWhere = " 1=1 ";
        
        if (this.StartDate.Text != "")
        {
            SqlWhere = SqlWhere + " and ContractDateTime >= '" + this.StartDate.Text + "' ";
        }
        if (this.EndDate.Text != "")
        {
            SqlWhere = SqlWhere + " and  ContractDateTime<='" + this.EndDate.Text + "'  ";
        }
        if (this.Tbx_Name.Text != "")
        {
            SqlWhere = SqlWhere + " and CustomerValue in (Select CustomerValue from  KNet_Sales_ClientList where CustomerName like '%" + this.Tbx_Name.Text + "%') ";
        }
        if (this.Tbx_CustomerValue.Text != "")
        {
            SqlWhere = SqlWhere + " and CustomerValue='"+this.Tbx_CustomerValue.Text+"'";
        }

        if (this.Tbx_ProductsBarCode.Text != "")
        {
            SqlWhere += " and ProductsBarCode Not in ('" + this.Tbx_ProductsBarCode.Text.Replace(",", "','") + "') ";
        }
        if (this.Drop_State.SelectedValue != "")
        {
            if (this.Drop_State.SelectedValue == "1")
            {
                SqlWhere = SqlWhere + " and ContractNo not in(select ContractNo from Knet_Procure_OrdersList) ";
            }
            else
            {
                SqlWhere = SqlWhere + " and ContractNo in(select ContractNo from Knet_Procure_OrdersList) ";
            }
        }
        if (this.DDLContractState.SelectedValue != "")
        {
            if (this.DDLContractState.SelectedValue == "0")
            {
                SqlWhere = SqlWhere + " and  ( OutWareState  in (0,1)) ";
            }
            else
            {
                SqlWhere = SqlWhere + " and  OutWareState = " + this.DDLContractState.SelectedValue + "";
            }
        }

        SqlWhere = SqlWhere + " order by ContractDateTime desc";
        //合同状态（0未执行，1执行中，2出货中，3作废，4完成）
        DataSet ds = bll.GetList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ContractNo" };
        GridView1.DataBind();
        RowOverYN();
    }
    /// <summary>
    /// 确定选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string cal = "";
        string ContractNo = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                ContractNo += GridView1.DataKeys[i].Value.ToString()+",";
            }
        }
        if (ContractNo != "")
        {
            ContractNo = ContractNo.Substring(0, ContractNo.Length - 1)+"|";
                StringBuilder s = new StringBuilder();
                s.Append("<script language=javascript>" + "\n");
                s.Append("window.returnValue='" + ContractNo +"';\n");
                s.Append("window.close();" + "\n");
                s.Append("</script>");
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                string csname = "ltype";
                if (!cs.IsStartupScriptRegistered(cstype, csname))
                    cs.RegisterStartupScript(cstype, csname, s.ToString());
        }
    }

    [Ajax.AjaxMethod()]
    public string GetContractInfo(string s_ContractNo)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_Sales_ContractList BLL = new KNet.BLL.KNet_Sales_ContractList();
            KNet.Model.KNet_Sales_ContractList Model = BLL.GetModelB(s_ContractNo);
            s_Return += Model.DutyPerson + "|" + Model.CustomerValue + "|" + base.Base_GetCustomerName(Model.CustomerValue) + "|" + base.Base_GetUserName(Model.ContractStaffNo) + "|" + Model.ContentPerson + "|" + Model.ContractToAddress + "|" + Model.ContractRemarks + "|" + Model.Telephone + "|" + Model.ContractDeliveMethods;
            return s_Return;
        }
        catch
        {
            return s_Return;
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
    /// 得到联系人地址
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string GetCustomerAddress(string s_ContractNo)
    {
        this.BeginQuery("Select CustomerAddress,CustomerName,CustomerContact,CustomerTel,CustomerMobile From KNet_Sales_ClientList Where CustomerValue in(select CustomerValue from KNet_Sales_ContractList Where ContractNo='" + s_ContractNo + "') ");
        this.QueryForDataTable();
        StringBuilder Sb_Return = new StringBuilder();
        Sb_Return.Append("地址: "+this.Dtb_Result.Rows[0][0].ToString() + "$");
        Sb_Return.Append(this.Dtb_Result.Rows[0][1].ToString() + "$");
        Sb_Return.Append("收货人:" + this.Dtb_Result.Rows[0][2].ToString() + "$");
        if (this.Dtb_Result.Rows[0][3].ToString()!="")
        {
            Sb_Return.Append("联系电话:" + this.Dtb_Result.Rows[0][3].ToString() + "$");
        }
        else
        {
            Sb_Return.Append("联系手机:" + this.Dtb_Result.Rows[0][4].ToString() + "$");
        }
        return Sb_Return.ToString();
    }

    public string GetCgState(string s_IsOrder)
    {
        try
        {
            if (s_IsOrder=="1")
            {
                return "已采购";
            }
            else
            {
                return "<font Color='red'>未采购</Font>";
            }

        }
        catch (Exception ex)
        {
            return "--";
        }
    }
    public string GetOrderCode(string s_IsOrder)
    {
        try
        {
            this.BeginQuery("Select * from Knet_Procure_OrdersList Where ContractNO='" + s_IsOrder + "'");
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count>0)
            {
                return this.Dtb_Result.Rows[0]["OrderNo"].ToString();
            }
            else
            {
                return "--";
            }
        }
        catch (Exception ex)
        {
            return "--";
        }
    }


    
    protected void Button1_Click1(object sender, EventArgs e)
    {
        try
        {
            string s_Sql = "Update KNet_Sales_ContractList set IsOrder='1' where ";
            string cal = "";
            int KK=0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {

                CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (cb.Checked == true)
                {
                    cal += " ContractNo='" + GridView1.DataKeys[i].Value.ToString() + "' or";
                    KK = KK + 1;
                }
            }
            if (KK == 0)
            {
                Alert("您没有选择要更改的记录!");
            }
            else
            {
                s_Sql += cal.Substring(0, cal.Length - 3);
            }

            DbHelperSQL.ExecuteSql(s_Sql);
            this.DataShows();

            Alert("更改成功！");
                
        }
        catch (Exception ex)
        {
 
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

    }
    protected void Button3_Click1(object sender, EventArgs e)
    {
        try
        {
            string s_Sql = "Update KNet_Sales_ContractList set IsOrder='0' where ";
            string cal = "";
            int KK = 0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {

                CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (cb.Checked == true)
                {
                    cal += " ContractNo='" + GridView1.DataKeys[i].Value.ToString() + "' or";
                    KK = KK + 1;
                }
            }
            if (KK == 0)
            {
                Alert("您没有选择要更改的记录!");
            }
            else
            {
                s_Sql += cal.Substring(0, cal.Length - 3);
            }

            DbHelperSQL.ExecuteSql(s_Sql);
            this.DataShows();
            Alert("更改成功！");
        }
        catch (Exception ex)
        {

        }

    }

    public string GetLink(string s_ContractNo)
    {
        string s_Return = "";
        try
        {
            s_Return += "<a href=\"javascript:window.close();\" onclick='set_return_value(\"" + s_ContractNo + "\");'>" + s_ContractNo + "</a>";

        }
        catch
        {
            s_Return = "-";

        }
        return s_Return;
    }

    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string s_ContractNO = GridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            if (this.Tbx_COntractNo.Text != "")
            {
                string[] s_ContractNos = this.Tbx_COntractNo.Text.Split(',');
                for (int i = 0; i < s_ContractNos.Length; i++)
                {
                    if (s_ContractNO == s_ContractNos[i].ToString())
                    {
                        CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
                        cb.Checked = true;
                    }
                }
            }
        }
    }
}

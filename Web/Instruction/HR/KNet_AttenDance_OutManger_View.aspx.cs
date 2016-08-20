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

using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
using KNet.Common;


public partial class Web_Sales_KNet_AttenDance_OutManger_View : BasePage
{
    public string s_MyTable_Detail = "", s_OrderStyle = "", s_DetailsStyle = "";
    protected void Page_Load(object sender, EventArgs e)
    {
            KNet.BLL.Knet_Procure_OrdersList bll = new KNet.BLL.Knet_Procure_OrdersList();
            this.Lbl_Title.Text = "查看采购订单";
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_Kx = Request.QueryString["Kx"] == null ? "" : Request.QueryString["Kx"].ToString();
            this.Tbx_ID.Text = s_ID;
            if (s_Kx == "1")
            {
                this.Tbx_Remarks.Visible = false;
                this.Lbl_Remarks.Visible = true;
                this.Tr_Save.Visible = false;
            }
            else
            {
                this.Tbx_Remarks.Visible = true;
                this.Lbl_Remarks.Visible = false;
                this.Tr_Save.Visible = true;
            }
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
            if (s_Type == "1")
            {
                s_OrderStyle = "class=\"dvtUnSelectedCell\"";
                s_DetailsStyle = "class=\"dvtSelectedCell\"";
                Pan_Order.Visible = false;
                Pan_Detail.Visible = true;
                Table_Btn.Visible = false;
                string SqlWhere = " ParentOrderNo='" + s_ID + "' order by SYstemDateTimes desc";
                DataSet ds = bll.GetList(SqlWhere);

            }
            else
            {
                s_DetailsStyle = "class=\"dvtUnSelectedCell\"";
                s_OrderStyle = "class=\"dvtSelectedCell\"";
                Pan_Order.Visible = true;
                Pan_Detail.Visible = false;
                Table_Btn.Visible = true;
            }
        
    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.KNet_Resource_OutManage BLL = new KNet.BLL.KNet_Resource_OutManage();

        if (Request["ID"] != null)
        {
            string MyID = Request.QueryString["ID"].ToString().Trim();
            if (MyID != "")
            {
                KNet.Model.KNet_Resource_OutManage model = BLL.GetModel(MyID);
                this.ThisState.Text = base.Base_GetBasicCodeName("150",model.ThisState.ToString());
                this.StaffName.Text = base.Base_GetUserName(model.StaffNo);
                this.StaffCard.Text = GetStaffStaffCardInfo(model.StaffNo);
                this.ThisKings.Text = base.Base_GetBasicCodeName("150",model.ThisKings.ToString());
                this.AddDatetime.Text = model.AddDatetime.ToString();
                this.StaffBranch.Text = base.Base_GeDept(model.StaffBranch);
                this.StaffDepart.Text = base.Base_GeDept(model.StaffDepart);
                this.StartDateTime.Text = model.StartDateTime.ToString();
                this.EndDatetime.Text = model.EndDatetime.ToString();
                this.ApprovalStaffNo.Text = GetStaffStaffCardInfo(model.ApprovalStaffNo);
                this.ApprovalDatetime.Text = model.ApprovalDatetime.ToString();
                this.thisExtendA.Text = model.thisExtendA;
                this.OutJustificate.Text = KNetPage.KHtmlDiscode(model.OutJustificate);
                this.Lbl_Type.Text = base.Base_GetBasicCodeName("151", model.KRO_Type);
                this.Tbx_Remarks.Text = model.KRO_Remarks;
                this.Lbl_Remarks.Text = model.KRO_Remarks;
                KNet.BLL.Xs_Customer_Products BLL_Customer_Products = new KNet.BLL.Xs_Customer_Products();
                DataSet Dts_Customer_Products = BLL_Customer_Products.GetList(" XCP_ProductsID='" + MyID + "'");
                if (Dts_Customer_Products.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < Dts_Customer_Products.Tables[0].Rows.Count; i++)
                    {
                        
                        s_MyTable_Detail += "<tr><td class='dvtCellInfo'><input type=\"hidden\" input Name=\"CustomerValue\" value='" + Dts_Customer_Products.Tables[0].Rows[i]["XCP_CustomerID"].ToString() + "'>" + Dts_Customer_Products.Tables[0].Rows[i]["XCP_CustomerID"].ToString() + "</td>";
                        if (base.Base_GetCustomerName(Dts_Customer_Products.Tables[0].Rows[i]["XCP_CustomerID"].ToString()) == "--")
                        {
                            s_MyTable_Detail += "<td class='dvtCellInfo'>" + base.Base_GetSupplierName_Link(Dts_Customer_Products.Tables[0].Rows[i]["XCP_CustomerID"].ToString()) + "</td>";
                        }
                        else
                        {
                            s_MyTable_Detail += "<td class='dvtCellInfo'><input type=\"hidden\" input Name=\"CustomerName\" value='" + base.Base_GetCustomerName(Dts_Customer_Products.Tables[0].Rows[i]["XCP_CustomerID"].ToString()) + "'>" + base.Base_GetCustomerName(Dts_Customer_Products.Tables[0].Rows[i]["XCP_CustomerID"].ToString()) + "</td>";
                        }
                        KNet.BLL.Xs_Sales_Content Bll_Content = new KNet.BLL.Xs_Sales_Content();
                        DataSet Dts_Content = Bll_Content.GetList(" XSC_CustomerValue='" + Dts_Customer_Products.Tables[0].Rows[i]["XCP_CustomerID"].ToString() + "' and XSC_STime between '" + this.StartDateTime.Text.Replace("年", "-").Replace("月", "-").Replace("日", "").Substring(0, 10) + "' and  '" + this.EndDatetime.Text.Replace("年", "-").Replace("月", "-").Replace("日", "").Substring(0, 10) + "' ");
                        if (Dts_Content.Tables[0].Rows.Count > 0)
                        {
                            string s_Content = "";
                            for (int j = 0; j < Dts_Content.Tables[0].Rows.Count; j++)
                            {
                                s_Content += "<a href=\"../CustomerContent/Xs_Sales_Content_View.aspx?ID=" + Dts_Content.Tables[0].Rows[j][0].ToString() + "\">" + Dts_Content.Tables[0].Rows[j]["XSC_Topic"].ToString() + "</a><br>";
                            }
                            s_MyTable_Detail += "<td class='dvtCellInfo'>" + s_Content + "</td>";
                        }
                        else
                        {
                            if (base.Base_GetCustomerName(Dts_Customer_Products.Tables[0].Rows[i]["XCP_CustomerID"].ToString()) == "--")
                            {
                                s_MyTable_Detail += "<td class='dvtCellInfo'><a href=\"../Cg/CgContent/Xs_Sales_Content_Add.aspx?CustomerValue=" + Dts_Customer_Products.Tables[0].Rows[i]["XCP_CustomerID"].ToString() + "\">添加联系记录</a></td>";

                            }
                            else
                            {
                                s_MyTable_Detail += "<td class='dvtCellInfo'><a href=\"../CustomerContent/Xs_Sales_Content_Add.aspx?CustomerValue=" + Dts_Customer_Products.Tables[0].Rows[i]["XCP_CustomerID"].ToString() + "\">添加联系记录</a></td>";

                            }
                        }
                        s_MyTable_Detail += "</tr>";
                    }

                }
            }
            else
            {
                Response.Write("<script language=javascript>alert('非法参数！');window.close()</script>");
                Response.End();
            }
        }
        else
        {
            Response.Write("<script language=javascript>alert('非法参数！');window.close()</script>");
            Response.End();
        }
    }

    protected void btn_Chcek_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();

 
    }
    protected string GetStaffStaffCardInfo(string StaffNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StaffNo,StaffCard,StaffName from KNet_Resource_Staff where StaffNo='" + StaffNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["StaffCard"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess AM = new AdminloginMess();
            string DoSql = "update KNet_Resource_OutManage  set KRO_Remarks='" + this.Tbx_Remarks.Text + "',KRO_IsCheck='1'  where  ID='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            AM.Add_Logs("出差报告增加" + this.Tbx_ID.Text);
            AlertAndRedirect("出差报告增加成功！", "KNet_AttenDance_OutManger_View.aspx?Kx=1&ID=" + this.Tbx_ID.Text + "");
        }
        catch
        { }
    }
}

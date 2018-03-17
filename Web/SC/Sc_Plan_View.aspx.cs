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


public partial class Web_Sc_Produce_Plan : BasePage
{
    public string s_MyTable_Detail = "", s_MyTable_Detail1 = "", s_MyTable_Detail2="";
    protected void Page_Load(object sender, EventArgs e)
    {
        string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            this.Lbl_Title.Text = "查看生产计划";
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            if (AM.YNAuthority("生产计划审批") == true)
            {
                this.btn_Chcek.Visible = true;
            }
            else
            {
                this.btn_Chcek.Visible = false;

            }

        }
        if (s_ID != "")
        {
            ShowInfo(s_ID);
        } 
       
    }

    protected void btn_Chcek_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (btn_Chcek.Text == "审批")
        {
            string DoSql = "update Sc_Produce_Plan  set SEM_CheckYN=1,SEM_CheckStaffNo='" + AM.KNet_StaffNo + "',SEM_CheckTime='" + DateTime.Now.ToString() + "'  where  SEM_ID='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "反审批";
        }
            
        else if (btn_Chcek.Text == "财务审批")
        {
            string DoSql = "update Sc_Expend_Manage  set SEM_CheckYN=2,SEM_CwCheckStaffNo='" + AM.KNet_StaffNo + "',SEM_CwCheckTime='" + DateTime.Now.ToString() + "'  where  SEM_ID='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "反财务审批";
        }
        else if (btn_Chcek.Text == "反财务审批")
        {
            string DoSql = "update Sc_Expend_Manage  set SEM_CheckYN=1,SEM_CwCheckStaffNo ='',SEM_CwCheckTime=''  where  SEM_ID='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "财务审批";
        }
        else
        {
            string DoSql = "update Sc_Expend_Manage  set SEM_CheckYN=0,SEM_CheckStaffNo ='',SEM_CheckTime=''  where  SEM_ID='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
            btn_Chcek.Text = "审批";
        }
        Alert("审批成功！");
    }
    private void ShowInfo(string s_ID)
    {
        AdminloginMess AM=new AdminloginMess();
        KNet.BLL.Sc_Produce_Plan bll = new KNet.BLL.Sc_Produce_Plan();
        KNet.Model.Sc_Produce_Plan model = bll.GetModel(s_ID);
        
                    KNet.BLL.PB_Basic_Mail bll_Mail = new KNet.BLL.PB_Basic_Mail();
                    string s_Sql = "PBM_Del=0 and PBM_FID='" + model.SPP_ID + "' and PBM_Type='3'";
                    s_Sql += " Order by PBM_CTime desc";
                    DataSet ds_Mail = bll_Mail.GetList(s_Sql);
                    MyGridView3.DataSource = ds_Mail;
                    MyGridView3.DataKeyNames = new string[] { "PBM_ID" };
                    MyGridView3.DataBind();
        KNet.BLL.Sc_Produce_Plan_Details bll_Rc = new KNet.BLL.Sc_Produce_Plan_Details();
        DataSet Dts_Rc = bll_Rc.GetList(" SPD_FaterID='" + s_ID + "' order by isnull(SPD_FEndTime,'9999-9-9'),isnull(SPD_EndTime,'9999-9-9') ");
        try
        {
            this.Tbx_ID.Text = s_ID;
            this.Lbl_SuppName.Text = base.Base_GetSupplierName_Link(model.SPP_SuppNo);
            try
            {
                this.Lbl_Stime.Text = DateTime.Parse(model.SPP_STime.ToString()).ToShortDateString();
            }
            catch { }
            this.Lbl_Remarks.Text = model.SPP_Remarks;
            if (model.SPP_CheckYN == 1)
            {
                btn_Chcek.Text = "反审批";
            }
            else
            {
                btn_Chcek.Text = "审批";
            }
            if (Dts_Rc.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Rc.Tables[0].Rows.Count; i++)
                {
                    s_MyTable_Detail += "<tr>";
                    KNet.BLL.Knet_Procure_OrdersList_Details Bll_Details = new KNet.BLL.Knet_Procure_OrdersList_Details();
                    KNet.Model.Knet_Procure_OrdersList_Details Model_Details = Bll_Details.GetModel(Dts_Rc.Tables[0].Rows[i]["SPD_OrderNo"].ToString());

                    KNet.BLL.Knet_Procure_OrdersList Bll = new KNet.BLL.Knet_Procure_OrdersList();
                    KNet.Model.Knet_Procure_OrdersList Model = Bll.GetModelB(Model_Details.OrderNo);

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><a href=\"Sc_Plan_Material.aspx?OrderNo=" + Model.OrderNo + "\"  target=\"_blank\">" + Model.OrderNo + "</a></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.DateToString(Model.OrderDateTime.ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetSupplierName_Link(Model.SuppNo) + "</td>";

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition_Link(Model_Details.ProductsBarCode) + "</td>";

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" +Model_Details.OrderAmount + "</td>";

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Rc.Tables[0].Rows[i]["SPD_Number"].ToString() + "</td>";

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.DateToString(Dts_Rc.Tables[0].Rows[i]["SPD_EndTime"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.DateToString(Dts_Rc.Tables[0].Rows[i]["SPD_FEndTime"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Rc.Tables[0].Rows[i]["SPD_Remarks"].ToString() + "</td>";
                    string s_Wl=Dts_Rc.Tables[0].Rows[i]["SPD_IsWl"] == null ? "0" : Dts_Rc.Tables[0].Rows[i]["SPD_IsWl"].ToString() ;
                    if (s_Wl == "0")
                    {
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">&nbsp;</td>";
                    }
                    else
                    {
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\">是</td>";
                    }
                    s_MyTable_Detail += "</tr>";

                }
            }
          
        }
        catch
        {}
    }
    protected void Btn_Auto_Click(object sender, EventArgs e)
    {

        //自动排产。
        //未生产订单
        string s_Sql = "Select b.ID as DID,SCP_Order,SPD_ID,a.*,b.*,c.CustomerValue,c.DutyPerson,e.wrkNumber,isnull((select top 1 OrderPreToDate from Knet_Procure_OrdersList where ParentOrderNo=a.OrderNo order by OrderPreToDate desc),'1900-01-01') as MaxOrderPreToDate from Knet_Procure_OrdersList a left join Knet_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo left join Knet_Sales_ContractList c on c.ContractNo=a.ContractNo ";
        s_Sql += " join v_OrderRK e on a.OrderNO=e.V_OrderNo ";
        s_Sql += " left join (  select a.*  ";
        s_Sql += " from Sc_Produce_Plan_Details a join SC_Produce_Plan d on a.SPD_FaterID=d.SPP_ID ";
        s_Sql += " where not exists(select 1  ";
        s_Sql += " from Sc_Produce_Plan_Details b join SC_Produce_Plan c on b.SPD_FaterID=c.SPP_ID ";
        s_Sql += "  where b.SPD_OrderNo=a.SPD_OrderNo and c.SPP_CTime>d.SPP_CTime)) aa on aa.SPD_OrderNo=b.ID ";
        s_Sql += " where OrderType='128860698200781250' and Isnull(KPO_RKState,'1')=0 and e.rkstate<>'1' and KPO_Del='0'";
        s_Sql += " order by SuppNo,isnull(SCP_Order,0),isnull(SPD_EndTime,'2900-01-01'),orderPreToDate  ";
        this.BeginQuery(s_Sql);
        DataTable Dtb_table = Dtb_Result;
        if (Dtb_table.Rows.Count > 0)
        {

            KNet.BLL.Knet_Procure_Suppliers Bll_Supp = new KNet.BLL.Knet_Procure_Suppliers();
            for (int i = 0; i < Dtb_table.Rows.Count; i++)
            {
                //循环订单
                string s_SuppNo = Dtb_table.Rows[i]["SuppNo"] == null ? "" : Dtb_table.Rows[i]["SuppNo"].ToString();
                KNet.Model.Knet_Procure_Suppliers Model = Bll_Supp.GetModelB(s_SuppNo);
                int i_MaxSuppDayNumber = Model.KPS_ScNumber == null ? 0 : Model.KPS_ScNumber;
                int i_GiveDays = Model.KPS_GiveDays == null ? 0 : Model.KPS_GiveDays;
                //根据产能和生产数量，循环插入生产表和生产明细表。
                




            }
            
        }
    }
    
    public string GetState(string s_State)
    {
        if (s_State == "2")
        {
            return "<font color=red>失败</font>";
        }
        else
        {

            return "<font color=blue>成功</font>";
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        KNet.BLL.Sc_Produce_Plan Bll = new KNet.BLL.Sc_Produce_Plan();
        KNet.Model.Sc_Produce_Plan Model = Bll.GetModel(this.Tbx_ID.Text);
        string JSD = "Sc/Sc_Plan_Print1.aspx?ID=" + Model.SPP_ID + "";
        if (base.HtmlToPdf(JSD, Server.MapPath("../Sc/PDF"), Model.SPP_ID + "(" + base.DateToString(Model.SPP_STime.ToString()).Replace("/", ".") + ")"))
        {
            Alert("生成成功！");
        }
    }
}

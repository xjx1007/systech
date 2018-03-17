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
/// 对发货单进行审核          建立出货回款账单----->建立运输费用付款账号（如果存在）
/// </summary>
public partial class Knet_Web_Sales_pop_Knet_Sales_ShipCheckYN : BasePage
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


            if (Request.QueryString["OutWareNo"] != null && Request.QueryString["OutWareNo"] != "")
            {
                this.UsersNotxt.Text = Request.QueryString["OutWareNo"].ToString().Trim();
                KNet.BLL.KNet_Sales_OutWareList BLL_Sales_OutWareList=new KNet.BLL.KNet_Sales_OutWareList();
                KNet.Model.KNet_Sales_OutWareList Model_Sales_OutWareList=BLL_Sales_OutWareList.GetModelB(this.UsersNotxt.Text);

                KNet.BLL.KNet_Resource_Staff Bll_Resource_Staff = new KNet.BLL.KNet_Resource_Staff();
                DataSet Dts_Table = Bll_Resource_Staff.GetList(" StaffNo<>'admin' Order By StaffDepart ");
                this.Ddl_Person.DataSource = Dts_Table;
                this.Ddl_Person.DataTextField = "StaffName";
                this.Ddl_Person.DataValueField = "StaffNo";
                this.Ddl_Person.DataBind();
                ListItem item = new ListItem("请选择审核人", ""); //默认值
                this.Ddl_Person.Items.Insert(0, item);
                this.Ddl_Person.Visible = false;

                if ((Model_Sales_OutWareList.KSO_SuppNoRemarks == null) || (Model_Sales_OutWareList.KSO_SuppNoRemarks == ""))
                {

                    this.Tbx_SuppRemarks.Text = Model_Sales_OutWareList.OutWareRemarks.Replace("<br/>","");
                }
                else
                {
                    this.Tbx_SuppRemarks.Text = Model_Sales_OutWareList.KSO_SuppNoRemarks;
                }

                if (Knet_Procure_OrdersList_Details_Shu(Request.QueryString["OutWareNo"].ToString().Trim()) <= 0)
                {
                    this.MyStatStr.Visible = true;
                    this.MyStatStr.Text = "此发货单未添加有产品明细，不能进行审核操作！";
                    this.Button1.Enabled = false;
                }

                KNet.BLL.KNet_Sales_Flow Bll = new KNet.BLL.KNet_Sales_Flow();
                KNet.Model.KNet_Sales_Flow Model = new KNet.Model.KNet_Sales_Flow();
                GridView1.DataSource = Bll.GetList(" KSF_ContractNo='" + this.UsersNotxt.Text + "' and KFS_Type='1'  Order  by KSF_Date desc");
                this.GridView1.DataBind();
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
            string Dostr = "select * from KNet_Sales_OutWareList where OutWareNo='" + ProcureBM + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["OutWareStaffNo"].ToString();
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



            KNet.BLL.KNet_Sales_OutWareList BLL = new KNet.BLL.KNet_Sales_OutWareList();
            KNet.Model.KNet_Sales_OutWareList modelss = BLL.GetModelB(OrderNotxt);


            string ContractOrderNumber = modelss.ContractNo;
            string InvoiceOrderNumber = OrderNotxt;
            string CustomerName = Knet_KNet_Sales_ClientListName(modelss.CustomerValue);
            string CustomerValue = modelss.CustomerValue;
            DateTime DeliveryDate = DateTime.Now;

            try
            {
                DeliveryDate =DateTime.Parse(modelss.OutWareDateTime.ToString());
            }catch {}


            DateTime ExpirationDate = DateTime.Now.AddDays(Knet_PlayCycleTime(modelss.CustomerValue));


    
            try
            {
                ExpirationDate = DateTime.Parse(modelss.OutWareDateTime.ToString()).AddDays(Knet_PlayCycleTime(modelss.CustomerValue));
            }catch {}

            int SettlementStatus = 1;

            if ((this.IsChecked.Checked == false)&&(this.Ddl_Person.SelectedValue==""))
            {
                Alert("请选定审核人！");
                return;
            }
            string ShippingWarehouse = Knet_KNet_Sales_HouseNo(modelss.CustomerValue);
            string s_DeptID = base.Base_GetNextDept(OrderNotxt, "102");//下一部门ID
            DateTime Thedateofconstruction = DateTime.Now;
            this.BeginQuery("Select Top 1 * from KNet_Sales_Flow Where KFS_Type='1' and KSF_ContractNo='" + OrderNotxt + "' Order by KSF_Date Desc ");
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                if (this.Dtb_Result.Rows[0]["KFS_NextPerson"].ToString() != "")//如果有指定
                {

                    this.AddFlow(OrderNotxt, AA);
                    string s_Text = "";
                    string s_Alert = "";
                    s_Text = "发货编号为：" + OrderNotxt + " 需要您审批,请及时登录系统审批。";
                    KNet.BLL.KNet_Resource_Staff BLL_Resource_Staff = new KNet.BLL.KNet_Resource_Staff();
                    KNet.Model.KNet_Resource_Staff Model_Resource_Staff = BLL_Resource_Staff.GetModelC(this.Dtb_Result.Rows[0]["KFS_NextPerson"].ToString());
                    if  (this.IsChecked.Checked == false)
                    {
                        s_Alert = base.Base_SendEmail(Model_Resource_Staff.StaffEmail, s_Text, "发货审核！");
                        Response.Write("<script>alert('审核成功，点 确定 返回！" + s_Alert + "');window.opener.location.reload();window.close();</script>");
                        Response.End();
                    }
                    
                }
            }
            if (s_DeptID != "")
            {
                this.AddFlow(OrderNotxt, AA);
                //下级要审核的Email
                string s_Text = "";
                string s_Alert = "", s_Receive = "";
                s_Text = "发货编号为：" + OrderNotxt + " 需要您审批,请及时登录系统审批。";
                this.BeginQuery("select * from KNet_Resource_Staff where StaffDepart='" + s_DeptID + "' and Position='102' ");
                this.QueryForDataTable();
                for (int i = 0; i < this.Dtb_Result.Rows.Count; i++)
                {
                    s_Receive += Dtb_Result.Rows[0]["StaffEmail"].ToString() + ",";
                }
                if ((this.IsChecked.Checked == false)||(AM.KNet_StaffDepart!="129652784259578018"))
                {
                    if (s_Receive != "")
                    {
                        s_Alert = base.Base_SendEmail(s_Receive.Substring(0, s_Receive.Length - 1), s_Text, "发货审核！");
                    }
                    Response.Write("<script>alert('审核成功，点 确定 返回！" + s_Alert + "');window.opener.location.reload();window.close();</script>");
                    Response.End();
                }
            }
            if (AA != -1)
            {
                if (AA == 1) //通过审核
                {
                    string DoSql = "update KNet_Sales_OutWareList  set OutWareCheckYN=" + AA + ",KSO_SuppNoRemarks='" + this.Tbx_SuppRemarks.Text + "',KSO_ShRemark='" + this.Tbx_Remark.Text + "',OutWareCheckStaffNo ='" + OrderCheckStaffNo + "'  where  OutWareNo='" + OrderNotxt + "' ";
                    DbHelperSQL.ExecuteSql(DoSql);
                
                    AM.Add_Logs("发货单审核成功.发货单：" + OrderNotxt + "");

                    

                    AddFlow(OrderNotxt, AA);
                    Response.Write("<script>alert('审核成功，点 确定 返回！');window.opener.location.reload();window.close();</script>");
                    Response.End();
                }
                else
                {
                    AddFlow(OrderNotxt, AA);
                    string DoSql = "update KNet_Sales_OutWareList  set OutWareCheckYN=" + AA + ",KSO_SuppNoRemarks='" + this.Tbx_SuppRemarks.Text + "',KSO_ShRemark='" + this.Tbx_Remark.Text + "'  where  OutWareNo='" + OrderNotxt + "' ";
                    DbHelperSQL.ExecuteSql(DoSql);
                    Response.Write("<script>alert('没通过审核，点 确定 返回！');window.opener.location.reload();window.close();</script>");
                    Response.End();
                }
            }
        }
    }


    private void AddFlow(string s_ContractNo, int i_State)
    {

        AdminloginMess AM = new AdminloginMess();
        //插入审核
        KNet.Model.KNet_Sales_Flow Model = new KNet.Model.KNet_Sales_Flow();
        KNet.BLL.KNet_Sales_Flow Bll = new KNet.BLL.KNet_Sales_Flow();
        Model.KFS_Type = 1;
        Model.KSF_ContractNo = s_ContractNo;
        Model.KSF_Date = DateTime.Now;
        Model.KSF_Detail = this.Tbx_Remark.Text;
        Model.KSF_ShPerson = AM.KNet_StaffNo;
        Model.KSF_State = i_State;
        if (this.IsChecked.Checked)
        {
            Model.KFS_IsNextPerson = "0";
        }
            
        else
        {
            Model.KFS_IsNextPerson = "1";
        }
        Model.KFS_NextPerson = this.Ddl_Person.SelectedValue;
        try
        {
            Bll.Add(Model);
        }
        catch
        { throw; }
    }


    /// <summary>
    /// 获取出货仓库
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Knet_KNet_Sales_HouseNo(string CustomerValue)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,HouseNo from KNet_Sales_ContractList where CustomerValue='" + CustomerValue + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["HouseNo"].ToString().Trim();
            }
            else
            {
                return "--"; ;
            }
        }
    }

    /// <summary>
    /// 获取客户名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Knet_KNet_Sales_ClientListName(string CustomerValue)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,CustomerValue,CustomerName from KNet_Sales_ClientList where CustomerValue='" + CustomerValue + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["CustomerName"].ToString().Trim();
            }
            else
            {
                return "--"; ;
            }
        }
    }

    /// <summary>
    /// 获取客户结账周期
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected double Knet_PlayCycleTime(string CustomerValue)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,CustomerValue,CustomerName,PlayCycleTime from KNet_Sales_ClientList where CustomerValue='" + CustomerValue + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return double.Parse(dr["PlayCycleTime"].ToString().Trim());
            }
            else
            {
                return 0; ;
            }
        }
    }

    /// <summary>
    /// 获取发货单明细数目
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu(string OutWareNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as IDS  from KNet_Sales_OutWareList_Details where OutWareNo='" + OutWareNo + "'";
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


    protected void IsChecked_CheckedChanged(object sender, EventArgs e)
    {
        if (this.IsChecked.Checked)
        {
            this.Ddl_Person.Visible = false;
        }
        else
        {
            this.Ddl_Person.Visible = true;
 
        }
    }
}

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
using System.Net.Mail;

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 对报价单进行审核
/// </summary>
public partial class Knet_Web_Sales_pop_ContractListCheckYN : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("合同评审审核") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
            {
                this.UsersNotxt.Text = Request.QueryString["ID"].ToString().Trim();

                KNet.BLL.Zl_Project_ProductsTry BLL_ProductsTry = new KNet.BLL.Zl_Project_ProductsTry();
                KNet.Model.Zl_Project_ProductsTry Model_ProductsTry = BLL_ProductsTry.GetModel(this.UsersNotxt.Text);
                if (Model_ProductsTry.ZPP_State == 0)
                {
                    base.Base_DropBasicCodeBindByWhere(this.Ddl_State, "251", "and PBC_Code in('1','2')");
                    this.Ddl_State.SelectedValue = "1";
                }
                else  if (Model_ProductsTry.ZPP_State == 1)
                {
                    base.Base_DropBasicCodeBindByWhere(this.Ddl_State, "251", "and PBC_Code in('3','4')");
                    this.Ddl_State.SelectedValue = "3";
                }
                
                KNet.BLL.KNet_Sales_Flow Bll = new KNet.BLL.KNet_Sales_Flow();
                KNet.Model.KNet_Sales_Flow Model = new KNet.Model.KNet_Sales_Flow();
                GridView1.DataSource = Bll.GetList(" KSF_ContractNo='" + this.UsersNotxt.Text + "' and KFS_Type='0'  Order  by KSF_Date desc");
                this.GridView1.DataBind();
                DataShow();
            }
            else
            {
                Response.Write("<script>alert('非法参数！');window.close();</script>");
                Response.End();
            }
        }
    }

    private void DataShow()
    {
        if (Request.QueryString["ID"] != null && Request.QueryString["ID"].ToString() != "")
        {
            KNet.BLL.Zl_Project_ProductsTry BLL_Sales_ContractList = new KNet.BLL.Zl_Project_ProductsTry();
            KNet.Model.Zl_Project_ProductsTry Model = BLL_Sales_ContractList.GetModel(Request.QueryString["ID"].ToString());

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
        string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
        if (AM.CheckLogin() == false)
        {
            Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
            Response.End();
        }
        else
        {
            int AA = int.Parse(this.Ddl_State.SelectedValue);
            string OrderNotxt = this.UsersNotxt.Text.Trim();
            string OrderCheckStaffNo = AM.KNet_StaffNo;

            KNet.BLL.Zl_Project_ProductsTry BLL = new KNet.BLL.Zl_Project_ProductsTry();
            KNet.Model.Zl_Project_ProductsTry Model = BLL.GetModel(OrderNotxt);
            string s_Alert = "";
            if (AA != -1)
            {
                if ((AA == 1)||(AA == 3))//通过审核
                {
                    string DoSql = "update Zl_Project_ProductsTry  set ZPP_State=" + AA + "  where  ZPP_ID='" + OrderNotxt + "' ";
                    DbHelperSQL.ExecuteSql(DoSql);
                    if (AddFlow(OrderNotxt, AA) == false)
                    {
                        return;
                    }

                    if (this.Chk_IsShow.Checked)
                    {
                        string s_Receive = "", s_Text = "", s_StaffNo = "";
                        //责任人

                        s_Text = "产品试制为：" + Model.ZPP_Title + " 需要您审批,请及时登录系统审批。";
                        //下级要审核的Email
                        this.BeginQuery("select * from KNet_Resource_Staff where StaffDepart='" + base.Base_GetNextDept(OrderNotxt, "108") + "' and Position='102' ");
                        this.QueryForDataTable();
                        for (int i = 0; i < this.Dtb_Result.Rows.Count; i++)
                        {
                            s_Receive += Dtb_Result.Rows[0]["StaffEmail"].ToString() + ",";
                            s_StaffNo += Dtb_Result.Rows[0]["StaffNo"].ToString() + ",";
                        }
                        if (s_Receive != "")
                        {
                            s_Alert = base.Base_SendEmail(s_Receive.Substring(0, s_Receive.Length - 1), s_Text, "合同评审审核！") + base.Base_SendMessage(s_StaffNo, KNetPage.KHtmlEncode("有 合同评审 <a href='Web/SalesContract/KNet_Sales_ContractList_View.aspx?ID=" + OrderNotxt + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + OrderNotxt + "</a> 需要您作为负责人选择审批流程，敬请关注！"));

                        }

                    }
                    AM.Add_Logs("产品试制审核成功.产品试制编号：" + OrderNotxt + "");
                    string s_Return = "<script>alert('审核成功，" + s_Alert + "，点 确定 返回！');";
                    if (s_Type == "1")
                    {
                        s_Return += "window.opener.location.href = \"../../../inc/Home.aspx?Type=1\";window.close();</script>";
                    }
                    else
                    {
                        s_Return += "window.opener.location.reload();window.close();</script>";
                    }
                    Response.Write(s_Return);
                    Response.End();
                }
                else
                {
                    string DoSql = "update Zl_Project_ProductsTry  set ZPP_State=" + AA + "  where  ZPP_ID='" + OrderNotxt + "' ";
                    DbHelperSQL.ExecuteSql(DoSql);
                    if (AddFlow(OrderNotxt, AA) == false)
                    {
                        return;
                    }
                    string s_Return = "<script>alert('没通过审核，" + s_Alert + "，点 确定 返回！');window.opener.location.reload();window.close();</script>";
                    Response.Write(s_Return);
                    Response.End();

                }

            }
        }
    }


    private bool AddFlow(string s_ContractNo, int i_State)
    {

        AdminloginMess AM = new AdminloginMess();
        //插入审核
        KNet.Model.KNet_Sales_Flow Model = new KNet.Model.KNet_Sales_Flow();
        KNet.BLL.KNet_Sales_Flow Bll = new KNet.BLL.KNet_Sales_Flow();
        Model.KFS_Type = 108;
        Model.KSF_ContractNo = s_ContractNo;
        Model.KSF_Date = DateTime.Now;
        Model.KSF_Detail = this.Tbx_Remark.Text;
        Model.KSF_ShPerson = AM.KNet_StaffNo;
        Model.KSF_State = i_State;
        try
        {
            if (Bll.Exists(Model) == false)
            {

                Bll.Add(Model);
                return true;
            }
            else
            {
                Alert("您已审核，请不要重复审核！");
                return false;
            }

        }
        catch
        {
            throw;
            return false;
        }
    }


    //流程
    public string GetFlowName(string s_Flow)
    {
        string s_FlowName = "";
        switch (s_Flow)
        {
            case "1":
                s_FlowName = "通过审核!";
                break;
            case "2":
                s_FlowName = "合同作废!";
                break;
            case "3":
                s_FlowName = "异常通过!";
                break;
            case "4":
                s_FlowName = "重新提交!";
                break;
            case "0":
                s_FlowName = "不通过审核！";
                break;
        }
        return s_FlowName;
    }

    /// <summary>
    /// 仓库明细  流出账
    /// </summary>
    /// <param name="HouseNo">仓库流水——进出仓库唯一值</param>
    /// <param name="WaterType">类型（1 采购入库，2 销售出库，3 直接入库，4 直接出库）</param>
    /// <param name="ProductsName">仓库流水——产品名称</param>
    /// <param name="ProductsBarCode">仓库流水——编码（条形码）</param>
    /// <param name="ProductsPattern">仓库流水——产品型号</param>
    /// <param name="ProductsUnits">仓库流水——单位</param>
    /// <param name="WaterHousePack">仓库流水——产品包装</param>
    /// <param name="WaterHouseAmount">仓库流水——数量</param>
    /// <param name="WaterHouseUnitPrice">仓库流水——单价(原采购单价)</param>
    /// <param name="WaterHouseDiscount">仓库流水——计价调节(原调价平均)</param>
    /// <param name="WaterHouseTotalNet">仓库流水——净值合计(原净值平均)</param>
    /// <param name="WaterSupperUnitsName">仓库流水——往来单位名称</param>
    /// <param name="WaterUnionOrderNo">仓库流水——关联单号</param>
    /// <param name="WaterDoStaffNo">操作者唯一值</param>
    protected void BluidWareHouse_Ownall_Water(string HouseNo, int WaterType, string ProductsName, string ProductsBarCode, string ProductsPattern, string ProductsUnits, string WaterHousePack, int WaterHouseAmount, decimal WaterHouseUnitPrice, decimal WaterHouseDiscount, decimal WaterHouseTotalNet, string WaterSupperUnitsName, string WaterUnionOrderNo, string WaterDoStaffNo)
    {
        KNet.BLL.KNet_WareHouse_Ownall_Water BLL = new KNet.BLL.KNet_WareHouse_Ownall_Water();
        KNet.Model.KNet_WareHouse_Ownall_Water model = new KNet.Model.KNet_WareHouse_Ownall_Water();

        model.HouseNo = HouseNo;
        model.WaterType = WaterType;
        model.WaterDateTime = DateTime.Now;
        model.ProductsName = ProductsName;
        model.ProductsBarCode = ProductsBarCode;
        model.ProductsPattern = ProductsPattern;
        model.ProductsUnits = ProductsUnits;
        model.WaterHousePack = WaterHousePack;
        model.WaterHouseAmount = WaterHouseAmount;
        model.WaterHouseUnitPrice = WaterHouseUnitPrice;
        model.WaterHouseDiscount = WaterHouseDiscount;
        model.WaterHouseTotalNet = WaterHouseTotalNet;
        model.WaterSupperUnitsName = WaterSupperUnitsName;
        model.WaterUnionOrderNo = WaterUnionOrderNo;
        model.WaterDoStaffNo = WaterDoStaffNo;

        try
        {
            BLL.Add(model);
        }
        catch { }
    }

    /// <summary>
    /// 单明细数目
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu(string ContractNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as IDS  from KNet_Sales_ContractList_Details where ContractNo='" + ContractNo + "'";
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



    /// <summary>
    /// 返回仓库名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Knet_Procure_HouseNo(string ContractNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select *  from KNet_Sales_ContractList where ContractNo='" + ContractNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["HouseNo"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 返回关联客户
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Knet_Procure_CustomerValue(string ContractNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select *  from KNet_Sales_ContractList where ContractNo='" + ContractNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["CustomerValue"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

}

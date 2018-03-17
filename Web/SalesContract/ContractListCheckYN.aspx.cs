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
            if (AM.CheckLogin("合同评审审核") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            if (Request.QueryString["ContractNo"] != null && Request.QueryString["ContractNo"] != "")
            {
                this.UsersNotxt.Text = Request.QueryString["ContractNo"].ToString().Trim();
                
                KNet.BLL.KNet_Sales_ContractList BLL_Contract = new KNet.BLL.KNet_Sales_ContractList();
                KNet.Model.KNet_Sales_ContractList Model_Contract = BLL_Contract.GetModelB(this.UsersNotxt.Text);
                this.Tbx_ReDate.Text = DateTime.Parse(Model_Contract.ContractToDeliDate.ToString()).ToShortDateString();
                this.Tbx_OldReDate.Text = DateTime.Parse(Model_Contract.ContractToDeliDate.ToString()).ToShortDateString();


                if ((AM.KNet_StaffDepart == "129652784446995911") || (AM.KNet_StaffDepart == "129652783965723459") || (AM.KNet_StaffDepart == "129652784259578018"))
                {
                    this.Tbx_ReDate.Enabled = true;
                }
                else
                {
                    this.Tbx_ReDate.Enabled = false;
                }
                this.Lbl_Date.Text = "原交货期：" + DateTime.Parse(Model_Contract.ContractToDeliDate.ToString()).ToShortDateString();

                if (Knet_Procure_OrdersList_Details_Shu(Request.QueryString["ContractNo"].ToString().Trim()) <= 0)
                {
                    this.MyStatStr.Visible = true;
                    this.MyStatStr.Text = "此合同单未添加有产品明细，不能进行审核操作！";
                    this.Button1.Enabled = false;
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

    /// <summary>
    /// 返回仓库的库存量
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    protected int GetKNet_WareHouse_Ownall(string ID)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,WareHouseAmount  from KNet_WareHouse_Ownall where ID='" + ID + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return int.Parse(dr["WareHouseAmount"].ToString().Trim().ToString());
            }
            else
            {
                return 0;
            }
        }
    }

    ///// <summary>
    ///// 出库后更新仓库总账信息
    ///// </summary>
    ///// <param name="thisWareHouseAmount">出库数量</param>
    ///// <param name="thisWareHouseTotalNet"></param>
    ///// <param name="thisWareHouseDiscount"></param>
    ///// <param name="HouseNo"></param>
    ///// <param name="ProductsBarCode"></param>
    //protected void UpdateKNet_WareHouse_Ownall(int thisWareHouseAmount, decimal thisWareHouseTotalNet, decimal thisWareHouseDiscount, string ID)
    //{
    //    try
    //    {
    //        string Dosql = null;

    //        if (thisWareHouseDiscount >= 0)
    //        {
    //            Dosql = "update KNet_WareHouse_Ownall set WareHouseAmount=WareHouseAmount-" + thisWareHouseAmount + ",ShippedQuantity=ShippedQuantity+" + thisWareHouseAmount + ",WareHouseTotalNet=WareHouseTotalNet-" + thisWareHouseTotalNet + ",WareHouseDiscount=WareHouseDiscount-" + thisWareHouseDiscount + "  where   ID='" + ID + "'";
    //        }
    //        else if (thisWareHouseDiscount < 0)
    //        {
    //            Dosql = "update KNet_WareHouse_Ownall set WareHouseAmount=WareHouseAmount-" + thisWareHouseAmount + ",ShippedQuantity=ShippedQuantity+" + thisWareHouseAmount + ",WareHouseTotalNet=WareHouseTotalNet-" + thisWareHouseTotalNet + ",WareHouseDiscount=WareHouseDiscount+" + thisWareHouseDiscount + "  where   ID='" + ID + "'";
    //        }
    //        else { }

    //        //Response.Write(Dosql);
    //        //Response.Write("<BR>");

    //        DbHelperSQL.ExecuteSql(Dosql);
    //    }
    //    catch { }
    //}


    private void DataShow()
    {
        if (Request.QueryString["ContractNo"] != null && Request.QueryString["ContractNo"].ToString() != "")
        {
            KNet.BLL.KNet_Sales_ContractList BLL_Sales_ContractList = new KNet.BLL.KNet_Sales_ContractList();
            KNet.Model.KNet_Sales_ContractList Model = BLL_Sales_ContractList.GetModelB(Request.QueryString["ContractNo"].ToString());

            this.ContractNo.Text = "<a href=\"#\"  onclick=\"javascript:window.open('KNet_Sales_ContractList_Manage_PrinterListSettingPrinterPage.aspx?ContractNo=" + Model.ContractNo + "&PrinterModel=128898695453437500','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');\">" + Model.ContractNo + "</a>";
          
            this.ContractDateTime.Text = DateTime.Parse(Model.ContractDateTime.ToString()).ToShortDateString();
            this.CustomerName.Text = base.Base_GetCustomerName(Model.CustomerValue);
            
            this.Lbl_DutyPerson.Text = base.Base_GetUserName(Model.DutyPerson);
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
            string Dostr = "select * from KNet_Sales_ContractList where ContractNo='" + ProcureBM + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["ContractStaffNo"].ToString();
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
        string s_Type=Request.QueryString["Type"]==null?"":Request.QueryString["Type"].ToString();
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

            
            KNet.BLL.KNet_Sales_ContractList BLL = new KNet.BLL.KNet_Sales_ContractList();
            KNet.Model.KNet_Sales_ContractList Model = BLL.GetModelB(OrderNotxt);
            string s_Alert = "";
            if (AA != -1)
            {
                if ((AA == 1)|| (AA == 3))//通过审核
                {

                    //KNet.BLL.KNet_Sales_ContractList_Details BLL = new KNet.BLL.KNet_Sales_ContractList_Details();

                    //using (DataSet ds = BLL.GetList("ContractNo='" + OrderNotxt + "' "))
                    //{
                    //    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    //    {
                    //        DataRowView mydrv = ds.Tables[0].DefaultView[i];

                    //        string OwnallPID = mydrv["OwnallPID"].ToString();//合同明细中的库存产品ID值
                    //        int ContractAmount = int.Parse(mydrv["ContractAmount"].ToString()); //合同明细中的库存产品数量

                    //        if (ContractAmount > GetKNet_WareHouse_Ownall(OwnallPID))
                    //        {
                    //            Response.Write("<script>alert('审核失败，系统检测到本合同明细中的产品数量库存量已不足，点 确定 返回！" + GetKNet_WareHouse_Ownall(OwnallPID).ToString() + "');window.opener.location.reload();window.close();</script>");
                    //            Response.End();
                    //        }

                    //    }
                    //}
                    //using (DataSet dss = BLL.GetList("ContractNo='" + OrderNotxt + "' "))
                    //{
                    //    //Response.Write("sgggggggggggggg");


                    //    //for (int j = 0; j <= dss.Tables[0].Rows.Count - 1; j++)
                    //    //{
                    //    //    DataRowView mydrv = dss.Tables[0].DefaultView[j];

                    //    //    string HouseNo = Knet_Procure_HouseNo(OrderNotxt);
                    //    //    int WaterType = 2;
                    //    //    string ProductsName = mydrv["ProductsName"].ToString();
                    //    //    string ProductsBarCode = mydrv["ProductsBarCode"].ToString();
                    //    //    string ProductsPattern = mydrv["ProductsPattern"].ToString();
                    //    //    string ProductsUnits = mydrv["ProductsUnits"].ToString();

                    //    //    string WaterHousePack = "";

                    //    //    int WaterHouseAmount = int.Parse(mydrv["ContractAmount"].ToString()); //合同明细中的库存产品数量
                    //    //    decimal WaterHouseUnitPrice = decimal.Parse(mydrv["ContractUnitPrice"].ToString());
                    //    //    decimal WaterHouseDiscount = decimal.Parse(mydrv["ContractDiscount"].ToString());
                    //    //    decimal WaterHouseTotalNet = decimal.Parse(mydrv["ContractTotalNet"].ToString());

                    //    //    string WaterSupperUnitsName = Knet_Procure_CustomerValue(OrderNotxt);

                    //    //    string WaterUnionOrderNo = mydrv["ContractNo"].ToString();
                    //    //    string WaterDoStaffNo = AM.KNet_StaffNo;


                    //    //    string OwnallPID = mydrv["OwnallPID"].ToString();//合同明细中的库存产品ID值
                    //    //    int ContractAmount = int.Parse(mydrv["ContractAmount"].ToString()); //合同明细中的库存产品数量
                    //    //    decimal ContractTotalNet = decimal.Parse(mydrv["ContractTotalNet"].ToString());//合同明细中的产品净值合计
                    //    //    decimal ContractDiscount = decimal.Parse(mydrv["ContractDiscount"].ToString());//合同明细中的产品成本折扣合计


                    //    //    //生成出库明细流水账 
                    //    //    this.BluidWareHouse_Ownall_Water(HouseNo, WaterType, ProductsName, ProductsBarCode, ProductsPattern, ProductsUnits, WaterHousePack, WaterHouseAmount, WaterHouseUnitPrice, WaterHouseDiscount, WaterHouseTotalNet, WaterSupperUnitsName, WaterUnionOrderNo, WaterDoStaffNo);

                    //    //    //更新仓库管理
                    //    //  //  this.UpdateKNet_WareHouse_Ownall(ContractAmount, ContractTotalNet, ContractDiscount, OwnallPID);

                    //    //}
                    //}
                    //总经理审批算通过
                    if ((AM.KNet_StaffDepart == "129652783693249229") && (AM.KNet_Position == "102"))
                    {
                        string DoSql = "update KNet_Sales_ContractList  set ContractCheckYN=" + AA + " , ContractState=1  where  ContractNo='" + OrderNotxt + "' ";
                        DbHelperSQL.ExecuteSql(DoSql);
                    }
                    if (AddFlow(OrderNotxt, AA) == false)
                    {
                        return;
                    }

                    if(this.Chk_IsShow.Checked)
                    {
                        string s_Receive="",s_Text="",s_StaffNo="";
                        //责任人
                        
                        s_Text="合同编号为："+OrderNotxt+" 需要您审批,请及时登录系统审批。";
                  
                            //下级要审核的Email
                            this.BeginQuery("select * from KNet_Resource_Staff where StaffDepart='"+base.Base_GetNextDept(OrderNotxt,"101")+"' and Position='102' ");
                            this.QueryForDataTable();
                            for(int i=0;i<this.Dtb_Result.Rows.Count;i++)
                            {
                                s_Receive +=Dtb_Result.Rows[0]["StaffEmail"].ToString()+",";
                                s_StaffNo += Dtb_Result.Rows[0]["StaffNo"].ToString() + ",";
                            }
                            if (s_Receive != "")
                            {
                                s_Alert = base.Base_SendEmail(s_Receive.Substring(0, s_Receive.Length - 1), s_Text, "合同评审审核！") + base.Base_SendMessage(s_StaffNo, KNetPage.KHtmlEncode("有 合同评审 <a href='Web/SalesContract/KNet_Sales_ContractList_View.aspx?ID=" + OrderNotxt + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + OrderNotxt + "</a> 需要您作为负责人选择审批流程，敬请关注！"));
                                
                            }
                            else
                            {
                                KNet.BLL.KNet_Resource_Staff BLL_Resource_Staff = new KNet.BLL.KNet_Resource_Staff();
                                KNet.Model.KNet_Resource_Staff Model_Resource_Staff = BLL_Resource_Staff.GetModelC(Model.ContractStaffNo);
                                if (Model_Resource_Staff.StaffEmail != "")
                                {
                                    string s_Detail = "您的合同评审已经通过审核！合同编号：" + OrderNotxt + " 审核意见为：" + Tbx_Remark.Text;
                                    s_Alert = base.Base_SendEmail(Model_Resource_Staff.StaffEmail, s_Detail, "合同评审审核！") + base.Base_SendMessage(s_StaffNo, KNetPage.KHtmlEncode("有 合同评审 <a href='Web/SalesContract/KNet_Sales_ContractList_View.aspx?ID=" + OrderNotxt + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + OrderNotxt + "</a> 需要您作为负责人选择审批流程，敬请关注！"));
                                }
                            }

                    }
                    AM.Add_Logs("合同单审核成功.合同编号：" + OrderNotxt + "");
                    string s_Return="<script>alert('审核成功，"+s_Alert+"，点 确定 返回！');";
                    if(s_Type=="1")
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
                    if (AA == 2) //合同作废
                    {
                        //总经理审批算通过
                        if ((AM.KNet_StaffDepart == "129652783693249229") && (AM.KNet_Position == "102"))
                        {
                            string DoSql = "update KNet_Sales_ContractList set ContractCheckYN=" + AA + ",ContractState=3  where  ContractNo='" + OrderNotxt + "' ";
                            DbHelperSQL.ExecuteSql(DoSql);
                        }
                        if (AddFlow(OrderNotxt, AA) == false)
                        {
                            return;
                        }
                        if (this.Chk_IsShow.Checked)
                        {
                            KNet.BLL.KNet_Resource_Staff BLL_Resource_Staff = new KNet.BLL.KNet_Resource_Staff();
                            KNet.Model.KNet_Resource_Staff Model_Resource_Staff = BLL_Resource_Staff.GetModelC(Model.ContractStaffNo);
                            if (Model_Resource_Staff.StaffEmail != "")
                            {
                                string s_Detail = "您的合同评审作废！合同编号：" + OrderNotxt + " 审核意见为：" + Tbx_Remark.Text;
                                s_Alert = base.Base_SendEmail(Model_Resource_Staff.StaffEmail, s_Detail, "合同评审审核！") + base.Base_SendMessage(Model_Resource_Staff.StaffNo, KNetPage.KHtmlEncode("有 合同评审作废 <a href='Web/SalesContract/KNet_Sales_ContractList_View.aspx?ID=" + OrderNotxt + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + OrderNotxt + "</a> ，敬请关注！"));

                            }
                        }
                        AM.Add_Logs("合同单作废成功.合同编号：" + OrderNotxt + "");
                        string s_Return = "<script>alert('合同作废成功，" + s_Alert + "，点 确定 返回！')";
                    if(s_Type=="1")
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
                    if (AddFlow(OrderNotxt, AA) == false)
                    {
                        return;
                    }
                        if (this.Chk_IsShow.Checked)
                        {
                            KNet.BLL.KNet_Resource_Staff BLL_Resource_Staff = new KNet.BLL.KNet_Resource_Staff();
                            KNet.Model.KNet_Resource_Staff Model_Resource_Staff = BLL_Resource_Staff.GetModelC(Model.ContractStaffNo);
                            if (Model_Resource_Staff.StaffEmail != "")
                            {
                                string s_Detail = "您的合同评审未通过！合同编号：" + OrderNotxt + " 审核意见为：" + Tbx_Remark.Text;
                                s_Alert = base.Base_SendEmail(Model_Resource_Staff.StaffEmail, s_Detail, "合同评审审核！") + base.Base_SendMessage(Model_Resource_Staff.StaffNo, KNetPage.KHtmlEncode("有 合同评审未通过 <a href='Web/SalesContract/KNet_Sales_ContractList_View.aspx?ID=" + OrderNotxt + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + OrderNotxt + "</a> ，敬请关注！")); ;

                            }
                        }

                        string s_Return = "<script>alert('没通过审核，" + s_Alert + "，点 确定 返回！')";
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
        Model.KFS_Type = 0;
        Model.KSF_ContractNo = s_ContractNo;
        Model.KSF_Date = DateTime.Now;
        Model.KSF_Detail = this.Tbx_Remark.Text;
        Model.KSF_ShPerson = AM.KNet_StaffNo;
        Model.KSF_State = i_State;
        if (this.Tbx_ReDate.Text != this.Tbx_OldReDate.Text)
        {
            Model.KFS_ReDate = DateTime.Parse(this.Tbx_ReDate.Text);
            KNet.BLL.KNet_Sales_ContractList BLL_Contract = new KNet.BLL.KNet_Sales_ContractList();
            KNet.Model.KNet_Sales_ContractList Model_Contract = new KNet.Model.KNet_Sales_ContractList();
            Model_Contract.ContractNo = s_ContractNo;
            Model_Contract.KFC_ReDate = DateTime.Parse(this.Tbx_ReDate.Text);
            BLL_Contract.UpdateDate(Model_Contract);
            
        }
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

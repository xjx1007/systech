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
using KNet.BLL;
using KNet.DBUtility;
using KNet.Common;
using KNet.Model;

public partial class Knet_Web_System_KnetProductsSetting_Details : BasePage
{
    public string s_MyTable_Detail = "", s_ProductsTable_Detail = "", s_ProductsTable_BomDetail = "", s_ProductsRC = "", s_ProductsTable_BomDetail1 = "";
    public string s_OrderStyle = "", s_DetailsStyle = "", s_RC_ProductsBarCode = "", s_CgDayDetail = "", s_AlternativeDetail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("查看产品") == false)
            {
       //         string sql =
       //"select *,a.ParentOrderNo,case when RKState<>1 then cast (DATEDIFF(day,getdate(),OrderpretoDate) as varchar(100)) else '' end as DiffDay FROM Knet_Procure_OrdersList a join v_OrderRKWithNoDel b on a.OrderNO = b.V_OrderNo join Knet_Procure_OrdersList_Details d on a.OrderNo = d.OrderNo  where ProductsBarCode = '" + Request.QueryString["ID"].ToString().Trim() + "' and RkState = 0 and orderType = '128860698200781250'";
       //         this.BeginQuery(sql);
       //         DataTable Dtb_table1 = (DataTable)this.QueryForDataTable();
       //         if (Dtb_table1.Rows.Count > 0)
       //         {
       //             //this.TextBox2.Text = Dtb_table1.Rows.Count.ToString();
       //             //this.Button1.Visible = false;
       //             this.butt1.Disabled = true;
       //         }

                if (AM.YNAuthority("添加工时"))
                {
                    this.Time.Visible = true;
                }
                else
                {
                    this.Time.Visible = false;
                }
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();

            }
            this.Get_Knet_Suppliers_ByID();
        }
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess AM = new AdminloginMess();
            int i_number = 0;

            i_number = int.Parse(this.Tbx_BomNumber.Text);
            for (int i = 0; i < i_number; i++)
            {

                string s_ID = Request["XPDID_" + i.ToString() + ""] == null ? "" : Request["XPDID_" + i.ToString() + ""].ToString();
                string s_Chcek = Request["Chk_IsMail_" + i.ToString() + ""] == null ? "" : Request["Chk_IsMail_" + i.ToString() + ""].ToString();
                string s_Sql = "";
                if (s_ID != "")
                {
                    if (s_Chcek == "")
                    {
                        //如果不等于空
                        s_Sql = "Update Xs_Products_Prodocts_Demo set XPD_IsMail=1 where XPD_ID='" + s_ID + "'";
                    }
                    else
                    {
                        s_Sql = "Update Xs_Products_Prodocts_Demo set XPD_IsMail=0 where XPD_ID='" + s_ID + "'";
                    }
                    DbHelperSQL.ExecuteSql(s_Sql);
                }
            }
            AlertAndRedirect("更新成功", "KnetProductsSetting_Details.aspx?BarCode=" + this.Tbx_ID.Text + "");
            AM.Add_Logs("更新采购项目：" + this.Tbx_ID.Text);
        }
        catch
        { }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_Model = Request.QueryString["Model"] == null ? "" : Request.QueryString["Model"].ToString();
        string s_ID = Request.QueryString["BarCode"] == null ? "" : Request.QueryString["BarCode"].ToString();

        //停用
        if (s_ID != "")
        {
            if (AM.YNAuthority("停用产品") == true)
            {
                KNet.BLL.KNet_Sys_Products Bll = new KNet.BLL.KNet_Sys_Products();
                KNet.Model.KNet_Sys_Products Model = Bll.GetModelB(s_ID);
                Model.ProductsBarCode = s_ID;
                int i_Del = Math.Abs(Model.KSP_Del - 1);

                Model.KSP_DelRemarks = this.Tbx_DelRemarks.Text;
                Model.KSP_Remark = ProductRemark.Text;
                Model.KSP_Del = i_Del;
                Bll.UpdateDel(Model);
                AM.Add_Logs("系统设置--->产品字典--->产品字典 添加 操作成功！停用产品编码：" + s_ID);
                AlertAndRedirect("操作成功！", "KnetProductsSetting.aspx?ProductsBarCode=" + s_ID + "");
            }
            else
            {
                AM.NoAuthority("停用产品");
            }
        }

    }


    protected void Button22_Click(object sender, EventArgs e)
    {
        string s_Sql = "";
        s_Sql = "Select * from KNET_Sys_Products where KSP_Code='' ";
        this.BeginQuery(s_Sql);
        DataTable Dtb_Table = this.QueryForDataTable();
        for (int i = 0; i < Dtb_Table.Rows.Count; i++)
        {
            string s_NewCode = base.Base_GetNewProductsCode(Dtb_Table.Rows[i]["ProductsType"].ToString());
            string s_DoSql = "Update KNET_Sys_Products Set KSP_Code='" + s_NewCode + "' where ProductsBarCode='" + Dtb_Table.Rows[i]["ProductsBarCode"].ToString() + "'";
            DbHelperSQL.ExecuteSql(s_DoSql);
        }
    }
    /// <summary>
    /// 获取记录数据
    /// </summary>
    protected void Get_Knet_Suppliers_ByID()
    {

        AdminloginMess AM = new AdminloginMess();

        KNet.BLL.KNet_Sys_Products BLL = new KNet.BLL.KNet_Sys_Products();
        string s_Model = Request.QueryString["Model"] == null ? "" : Request.QueryString["Model"].ToString();
        string s_ShowCheck=Request.QueryString["check"] == null ? "false" : Request.QueryString["check"].ToString();
        if (Request["BarCode"] != null && Request["BarCode"] != "")
        {
            if (s_ShowCheck=="false")
            {
                checkbox.Checked = false;
            }
            else
            {
                checkbox.Checked = true;
            }
            this.Lbl_ShowCheck.Text = s_ShowCheck;
            string BarCode = Request.QueryString["BarCode"].ToString().Trim();
            this.Tbx_ID.Text = BarCode;
            s_RC_ProductsBarCode = Request.QueryString["BarCode"].ToString().Trim();
            if (GetKNet_Sys_ProductsYN(BarCode) == true)
            {

                KNet.Model.KNet_Sys_Products model = BLL.GetModelB(BarCode);
                if (model.KSP_Code.IndexOf("01") == 0)
                {
                    //AdminloginMess AM1 = new AdminloginMess();
                    if (CheckYNProducts(model.ProductsType) == false)
                    {
                        AlertAndClose("您没有权限查看该类产品,如需要请联系研发经理！");
                        return;
                    }
                }
                if(model.KSP_Code.IndexOf("01") != 0)
                {
                    this.Time.Visible = false;
                }
                this.Lbl_DelRemarks.Text = model.KSP_DelRemarks;

                this.Tbx_DelRemarks.Text = model.KSP_DelRemarks;

                if (model.KSP_Del == 0)
                {
                    Button1.Text = "停用";
                    this.Tbx_DelRemarks.Visible = true;
                    this.Lbl_DelRemarks.Visible = false;
                }
                else
                {
                    Button1.Text = "启用";
                    this.Tbx_DelRemarks.Visible = false;
                    this.Lbl_DelRemarks.Visible = true;
                }

                if (model.KSP_isModiy == 1)
                { this.Btn_Sh.Text = "审批"; }
                else
                { this.Btn_Sh.Text = "已审批"; }
                //if ((AM.KNet_StaffDepart == "129652783965723459") && (AM.KNet_Position == "102"))//如果是研发部经理

                this.CommentList2.CommentFID = model.ProductsBarCode;
                this.CommentList2.CommentType = "Products";
                this.ProductsName.Text = model.ProductsName;
                this.ProductsPattern.Text = model.ProductsPattern;
                this.ProductsBarCode.Text = model.ProductsBarCode;


                this.Ddl_UseType.Text = base.Base_GetBasicCodeName("1134", model.KSP_UseType);
                this.Lbl_Loss.Text = base.Base_GetBasicCodeName("1136", model.KSP_LossType.ToString());

                this.Lbl_isModiy.Text = model.KSP_isModiy == 0 ? "是" : "<font color=red>否</font>";
                this.ProductsUnits.Text = base.Base_GetUnitsName(model.ProductsUnits);
                this.ProductsSellingPrice.Text = model.ProductsSellingPrice.ToString();
                this.ProductsCostPrice.Text = model.ProductsCostPrice.ToString();
                this.ProductsDescription.Text = KNetPage.KHtmlDiscode(model.ProductsDescription.ToString());
                this.ProductsDetailDescription.Text = KNetPage.KHtmlDiscode(model.ProductsDetailDescription.ToString());
                this.Lbl_ProductsEdition.Text = model.ProductsEdition;
                this.Lbl_GProductsEdition.Text = base.Base_GetProductsEdition_Link(model.KSP_GProductsBarCode);
                this.Lbl_KSPCode.Text = model.KSP_Code;
                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsClass = new KNet.BLL.PB_Basic_ProductsClass();
                this.Lbl_ProductsType.Text = Bll_ProductsClass.GetProductsName(model.ProductsType);
                ProductRemark.Text = model.KSP_Remark;
                if ((model.KSP_Code != "") && (model.KSP_Code != null))
                {
                    if ((model.KSP_Code.IndexOf("01") == 0) || (model.KSP_Code.IndexOf("03") == 0))
                    {
                        Pan_Bom.Visible = true;
                    }
                    else
                    {
                        Pan_Bom.Visible = false;
                    }
                }
                this.Tbx_CustomerProductsName.Text = model.KSP_CustomerProductsName;
                this.Tbx_CustomerProductsEdition.Text = model.KSP_CustomerProductsEdition;
                this.Tbx_CustomerProductsCode.Text = model.KSP_CustomerProductsCode;

                this.Lbl_Create.Text = "<a href=\"../CG/Order/Knet_Procure_Suppliers_Price_Add.aspx?ProductsBarCode=" + s_RC_ProductsBarCode + "\" class=\"webMnu\">创建报价单</a>";
                this.Lbl_Create1.Text = "<a href=\"/Web/WareHouseOut/KNet_WareHouse_DirectOut_Add.aspx?Lytype=1&FaterBarCode=" + s_RC_ProductsBarCode + "\" class=\"webMnu\">创建产品领用单</a>";
                Lbl_Bom.Text = "<a href=\"/Web/Products/BOM.aspx?BarCode=" + s_RC_ProductsBarCode + "\" class=\"webMnu\" target=\"_blank\">BOM表</a>";
                Lbl_BomWithPrice.Text = "<a href=\"/Web/Products/BOMWithPrice.aspx?BarCode=" + s_RC_ProductsBarCode + "\" class=\"webMnu\" target=\"_blank\">BOM报价表</a>";
                Lbl_Createsmpale.Text = "<a href=\"/Web/ProductsSample/Pb_Products_Sample_Add.aspx?ProductsBarCode=" + s_RC_ProductsBarCode + "&isModify=1\" class=\"webMnu\" target=\"_blank\"> 创建设计修改</a>";
                this.Lbl_ScProblem.Text = "<a href=\"/Web/Zl/Problem/Zl_Produce_Problem_Add.aspx?ProductsBarCode=" + s_RC_ProductsBarCode + "\" class=\"webMnu\" target=\"_blank\">创建生产问题</a>";
                this.Lbl_Zy.Text = "<a href=\"../Instruction/ZL_Task_Instruction_Add.aspx?ProductsBarCode=" + s_RC_ProductsBarCode + "\" class=\"webMnu\"  target=\"_blank\">创建作业指导书</a>";

                UpdateBom.Text =
                    "<a href=\"/Web/Products/UpdateBom.aspx\" class=\"webMnu\"  target=\"_blank\">修改BOM(采购专用)</a>";
                //this.Lbl_Spce.Text = "<a href=\"../Instruction/ZL_Task_Instruction_Add.aspx?ProductsBarCode=" + s_RC_ProductsBarCode + "\" class=\"webMnu\"  target=\"_blank\">创建作业指导书</a>";
                if (model.ProductsPic == true)
                {
                    this.Image1.Visible = true;
                    this.Image1.ImageUrl = model.ProductsSmallPicture;

                    this.HyperLink1.Visible = true;
                    this.HyperLink1.NavigateUrl = model.ProductsBigPicture;
                }
                else
                {
                    this.ProductsPic.Text = "否";
                    this.Image1.Visible = false;
                    this.HyperLink1.Visible = false;
                }

                KNet.BLL.Pb_Products_Sample_Images Bll_Images = new KNet.BLL.Pb_Products_Sample_Images();
                DataSet Dts_Table = Bll_Images.GetList(" PPI_SmapleID='" + model.ProductsBarCode + "' and PBI_Type='2' ");
                if (Dts_Table != null)
                {
                    for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                    {
                        Lbl_Details.Text += "<tr><td class=\"ListHeadDetails\" align=\"left\" nowrap><input type=\"hidden\"  Name=\"Tbx_PName_" + Convert.ToString(i + 1) + "\" value=" + Dts_Table.Tables[0].Rows[i]["PPI_Name"].ToString() + ">" + Dts_Table.Tables[0].Rows[i]["PPI_Name"].ToString() + "</td>";
                        if ((Dts_Table.Tables[0].Rows[i]["PPI_Url"].ToString().IndexOf("gif") > 0) || (Dts_Table.Tables[0].Rows[i]["PPI_Url"].ToString().IndexOf("jpg") > 0))
                        {
                            Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap><input Name=\"Image1Big_" + Convert.ToString(i + 1) + "\"  type=\"hidden\"  value=" + Dts_Table.Tables[0].Rows[i]["PPI_Url"].ToString() + "><A  target=\"_blank\" href=\"" + Dts_Table.Tables[0].Rows[i]["PPI_Url"].ToString() + "\"  ><Image ID=\"Image_" + Convert.ToString(i + 1) + "\" Src=\"" + Dts_Table.Tables[0].Rows[i]["PPI_Url"].ToString() + "\" Height=\"35px\"  border=0 /></a></td></tr>";
                        }
                        else
                        {
                            Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap><a href=\"" + Dts_Table.Tables[0].Rows[i]["PPI_Url"].ToString() + "\" >" + Dts_Table.Tables[0].Rows[i]["PPI_Name"].ToString() + "</a></td></tr>";
                        }
                    }
                    this.Tbx_num.Text = Dts_Table.Tables[0].Rows.Count.ToString();
                }
                KNet.BLL.Xs_Customer_Products BLL_Customer_Products = new KNet.BLL.Xs_Customer_Products();
                DataSet Dts_Customer_Products = BLL_Customer_Products.GetList(" XCP_ProductsID='" + model.ProductsBarCode + "'");
                if (Dts_Customer_Products.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < Dts_Customer_Products.Tables[0].Rows.Count; i++)
                    {
                        s_MyTable_Detail += "<tr><td class=\"ListHeadDetails\"><input type=\"hidden\" input Name=\"CustomerValue\" value='" + Dts_Customer_Products.Tables[0].Rows[i]["XCP_CustomerID"].ToString() + "'>" + Dts_Customer_Products.Tables[0].Rows[i]["XCP_CustomerID"].ToString() + "</td>";
                        s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\" input Name=\"CustomerName\" value='" + base.Base_GetCustomerName(Dts_Customer_Products.Tables[0].Rows[i]["XCP_CustomerID"].ToString()) + "'>" + base.Base_GetCustomerName_Link(Dts_Customer_Products.Tables[0].Rows[i]["XCP_CustomerID"].ToString()) + "</td>";
                        s_MyTable_Detail += "</tr>";
                    }

                }

                if (Pan_Bom.Visible == true)
                {
                    GetBomDetails(model);
                }

                //适用成品1
                KNet.BLL.Xs_Products_Prodocts_Demo BLL_RCProducts = new KNet.BLL.Xs_Products_Prodocts_Demo();
                DataSet Dts_RCProducts = BLL_RCProducts.GetList(" XPD_ProductsBarCode='" + model.ProductsBarCode + "' and b.ksp_Del=0 and c.ksp_del=0  ");
                DataTable Dtb_RCProducts = Dts_RCProducts.Tables[0];
                if (Dtb_RCProducts.Rows.Count > 0)
                {

                    for (int i = 0; i < Dtb_RCProducts.Rows.Count; i++)
                    {
                        s_ProductsRC += "<tr>";
                        s_ProductsRC += "<td class=\"ListHeadDetails\">" + Convert.ToString(i + 1) + "</td>";

                        s_ProductsRC += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName_Link(Dtb_RCProducts.Rows[i]["XPD_FaterBarCode"].ToString()) + "</td>";
                        s_ProductsRC += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dtb_RCProducts.Rows[i]["XPD_FaterBarCode"].ToString()) + "</td>";
                        s_ProductsRC += "<td class=\"ListHeadDetails\">" + base.Base_GetUnitsName(base.Base_GetProductsUnits(Dtb_RCProducts.Rows[i]["XPD_FaterBarCode"].ToString())) + "</td>";
                        string s_Price = base.FormatNumber1(Dtb_RCProducts.Rows[i]["XPD_Price"].ToString(), 3);
                        if (i > 0)
                        {
                            if (s_Price != base.FormatNumber1(Dtb_RCProducts.Rows[i - 1]["XPD_Price"].ToString(), 3))
                            {
                                s_Price = "<font color=red>" + s_Price + "</font>";
                            }
                        }
                        s_ProductsRC += "<td class=\"ListHeadDetails\">" + s_Price + "</td>";
                        s_ProductsRC += "<td class=\"ListHeadDetails\">" + base.FormatNumber1(Dtb_RCProducts.Rows[i]["XPD_Number"].ToString(), 3) + "</td>";
                        string s_order = Dtb_RCProducts.Rows[i]["XPD_IsOrder"] == null ? "否" : Dtb_RCProducts.Rows[i]["XPD_IsOrder"].ToString();
                        s_ProductsRC += "<td class=\"ListHeadDetails\">" + s_order + "</td>";

                        s_ProductsRC += "</tr>";
                    }
                }

                KNet.BLL.PB_Products_CgDays BLL_CgDays = new KNet.BLL.PB_Products_CgDays();
                DataSet Dts_CgDays = BLL_CgDays.GetList(" PPC_ProductsBarCode='" + model.ProductsBarCode + "' ");
                DataTable Dtb_CgDays = Dts_CgDays.Tables[0];
                if (Dtb_CgDays.Rows.Count > 0)
                {

                    for (int i = 0; i < Dtb_CgDays.Rows.Count; i++)
                    {
                        s_CgDayDetail += "<tr>";
                        s_CgDayDetail += "<td class=\"ListHeadDetails\">" + Dtb_CgDays.Rows[i]["PPC_Min"].ToString() + "</td>";
                        s_CgDayDetail += "<td class=\"ListHeadDetails\">" + Dtb_CgDays.Rows[i]["PPC_Max"].ToString() + "</td>";
                        s_CgDayDetail += "<td class=\"ListHeadDetails\">" + Dtb_CgDays.Rows[i]["PPC_Days"].ToString() + "</td>";
                        s_CgDayDetail += "</tr>";
                    }
                }

                this.Tbx_Volume.Text = model.KSP_Volume.ToString();
                this.Tbx_Weight.Text = model.KSP_Weight.ToString();

                this.Lbl_BzNumber.Text = model.KSP_BZNumber.ToString();

                this.ProductsAddMan.Text = base.Base_GetUserName(model.KSP_Creator);
                this.KSP_Mender.Text = base.Base_GetUserName(model.KSP_Mender);
                //this.ProductsStockAlert.Text = model.ProductsStockAlert.ToString();
                if (model.KSP_CgType == 0)
                {

                    this.CgType.Text = "<font color=red>定制</font>";
                }
                else
                {
                    this.CgType.Text = "<font color=green>分批</font>";
                }
                this.Lbl_Mould.Text = base.Base_GetProdutsName_Link(model.KSP_Mould);
                try
                {
                    this.ProductsAddTime.Text = model.KSP_CTime.ToString();
                    this.KSP_MTime.Text = model.KSP_MTime.ToString();
                }
                catch { }

                KNet.BLL.Zl_Produce_Problem bll = new KNet.BLL.Zl_Produce_Problem();
                DataSet ds = bll.GetList(" ZPP_ProdutsBarCode='" + model.ProductsBarCode + "'");
                GridView1.DataSource = ds;
                GridView1.DataKeyNames = new string[] { "ZPP_ID" };
                GridView1.DataBind();

                KNet.BLL.ZL_Task_Instruction bll_Instruction = new KNet.BLL.ZL_Task_Instruction();
                DataSet ds1 = bll_Instruction.GetList(" ZTI_ProductsBarCode='" + model.ProductsBarCode + "'");
                MyGridView1.DataSource = ds1;
                MyGridView1.DataKeyNames = new string[] { "ZTI_ID" };
                MyGridView1.DataBind();

                KNet.BLL.Knet_Procure_SuppliersPrice bll_SuppliersPrice = new KNet.BLL.Knet_Procure_SuppliersPrice();
                string SqlWhere = " ProductsBarCode='" + model.ProductsBarCode + "' and KPP_Del='0' ";
                SqlWhere += "  order by ProcureUpdateDateTime desc ";
                DataSet ds_SuppliersPrice = bll_SuppliersPrice.GetList(SqlWhere);
                MyGridView4.DataSource = ds_SuppliersPrice;
                MyGridView4.DataKeyNames = new string[] { "ID" };
                MyGridView4.DataBind();
                this.Lbl_PriceLink.Text = "<a target=\"_blank\" href=\"../Cg/Order/Knet_Procure_Suppliers_Price.aspx?WhereID=41&ProductsBarCode=" + model.ProductsBarCode + "\">查看所有价格</a>";


                //可替代物料
                KNet.BLL.Products_Replace_List BLL_Replace = new KNet.BLL.Products_Replace_List();
                DataSet Dts_Replace = BLL_Replace.GetList(" PRL_ProductsCode='" + model.ProductsBarCode + "'  ");
                DataTable Dtb_Replace = Dts_Replace.Tables[0];
                if (Dtb_Replace.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtb_Replace.Rows.Count; i++)
                    {
                        s_AlternativeDetail += "<tr><td class='ListHeadDetails'><A onclick=\"deleteAlternativeRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td><td class='ListHeadDetails'><input type=\"hidden\" input Name=\"AlternativeProdoctsBarCode_" + i.ToString() + "\" value='" + Dtb_Replace.Rows[i]["PRL_ProductsCode"].ToString() + "'>" + base.Base_GetProdutsName(Dtb_Replace.Rows[i]["PRL_ProductsCode"].ToString()) + "</td>";
                        s_AlternativeDetail += "<td class='ListHeadDetails'>" + base.Base_GetProductsEdition_Link(Dtb_Replace.Rows[i]["PRL_ReplaceProductsBarCode"].ToString()) + "</td>";
                        s_AlternativeDetail += "<td class='ListHeadDetails'>" + Dtb_Replace.Rows[i]["PRL_AlternativePriority"].ToString() + "</td>";

                        string s_Check = "";
                        if (Dtb_Replace.Rows[i]["PRL_AlternativeOlny"].ToString() == "1")
                        {
                            s_Check = "是";
                        }
                        else
                        {
                            s_Check = "否";
                        }

                        s_AlternativeDetail += "<td class='ListHeadDetails'>" + s_Check + "</td>";
                        s_AlternativeDetail += "</tr>";
                    }
                }


                //可替代物料
                Dts_Replace = BLL_Replace.GetList(" PRL_ReplaceProductsBarCode='" + model.ProductsBarCode + "'  ");
                Dtb_Replace = Dts_Replace.Tables[0];
                if (Dtb_Replace.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtb_Replace.Rows.Count; i++)
                    {

                        s_AlternativeDetail += "<tr>";
                        s_AlternativeDetail += "<td class='ListHeadDetails'><A onclick=\"deleteAlternativeRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td><td class='ListHeadDetails'><input type=\"hidden\" input Name=\"AlternativeProdoctsBarCode_" + i.ToString() + "\" value='" + Dtb_Replace.Rows[i]["PRL_ProductsCode"].ToString() + "'>" + base.Base_GetProdutsName(Dtb_Replace.Rows[i]["PRL_ProductsCode"].ToString()) + "</td>";

                        s_AlternativeDetail += "<td class='ListHeadDetails'>" + base.Base_GetProductsEdition_Link(Dtb_Replace.Rows[i]["PRL_ProductsCode"].ToString()) + "</td>";
                        s_AlternativeDetail += "<td class='ListHeadDetails'>" + Dtb_Replace.Rows[i]["PRL_AlternativePriority"].ToString() + "</td>";

                        string s_Check = "";
                        if (Dtb_Replace.Rows[i]["PRL_AlternativeOlny"].ToString() == "1")
                        {
                            s_Check = "是";
                        }
                        else
                        {
                            s_Check = "否";
                        }

                        s_AlternativeDetail += "<td class='ListHeadDetails'>" + s_Check + "</td>";
                        s_AlternativeDetail += "</tr>";
                    }
                }
                /*
                string s_Dosql = "Select top 1 * from Pb_Products_Sample_Confim a left join Pb_Products_Sample_Images b on a.PBC_ID=b.PPI_SmapleId and PBI_Type='1' ";
                s_Dosql += " left join KNET_Sys_Products c on c.KSP_SampleID=a.PBC_SampleID";
                s_Dosql += " where PPI_Name='丝印' and c.ProductsBarCode='" + model.ProductsBarCode + "' order by PPI_CTime Desc";
                this.BeginQuery(s_Dosql);
                DataTable Dtb_Table = this.QueryForDataTable();
                if (Dtb_Table.Rows.Count > 0)
                {
                    this.Lbl_Sy.Text = "<table id=\"Table1\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"5\" cellspacing=\"0\" class=\"ListDetails\" style=\"height: 28px\">";
                    Lbl_Sy.Text += "<tr><td class=\"ListHeadDetails\" align=\"left\" nowrap>" + Dtb_Table.Rows[0]["PPI_Name"].ToString() + "</td>";
                    Lbl_Sy.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap>";
                    Lbl_Sy.Text += "<A  target=\"_blank\" href=\"" + Dtb_Table.Rows[0]["PPI_Url"].ToString() + "\"  >";
                    if (Dtb_Table.Rows[0]["PPI_Url"].ToString().IndexOf(".jpg") > 0)
                    {
                        Lbl_Sy.Text += "<Image ID=\"Image_0\" Src=\"" + Dtb_Table.Rows[0]["PPI_Url"].ToString() + "\" Height=\"35px\"  border=0 />";
                    }
                    else
                    {
                        Lbl_Sy.Text += Dtb_Table.Rows[0]["PPI_Name"].ToString();
                    }
                    Lbl_Sy.Text += "</a></td></tr>";
                    this.Lbl_Sy.Text += "</table>";
                }
                 * */
                /*

                KNet.BLL.Xs_Products_Spce bll_Spce = new KNet.BLL.Xs_Products_Spce();
                DataSet ds_Spce = bll_Spce.GetList(" XPS_ProductsBarCode='" + model.ProductsBarCode + "'");
                MyGridView3.DataSource = ds_Spce;
                MyGridView3.DataKeyNames = new string[] { "XPS_ID" };
                MyGridView3.DataBind();

                s_Dosql = "Select top 1 * from Pb_Products_Sample_Confim a left join Pb_Products_Sample_Images b on a.PBC_ID=b.PPI_SmapleId and PBI_Type='1' ";
                s_Dosql += " left join KNET_Sys_Products c on c.KSP_SampleID=a.PBC_SampleID";
                s_Dosql += " where PPI_Name='码表' and c.ProductsBarCode='" + model.ProductsBarCode + "' order by PPI_CTime Desc";
                this.BeginQuery(s_Dosql);
                Dtb_Table = this.QueryForDataTable();
                if (Dtb_Table.Rows.Count > 0)
                {
                    this.Lbl_Mz.Text = "<table id=\"Table1\" width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"5\" cellspacing=\"0\" class=\"ListDetails\" style=\"height: 28px\">";
                    Lbl_Mz.Text += "<tr><td class=\"ListHeadDetails\" align=\"left\" nowrap>" + Dtb_Table.Rows[0]["PPI_Name"].ToString() + "</td>";
                    Lbl_Mz.Text += "<td class=\"ListHeadDetails\" align=\"left\" nowrap>";
                    Lbl_Mz.Text += "<A  target=\"_blank\" href=\"" + Dtb_Table.Rows[0]["PPI_Url"].ToString() + "\"  >";
                    if (Dtb_Table.Rows[0]["PPI_Url"].ToString().IndexOf(".jpg") > 0)
                    {
                        Lbl_Mz.Text += "<Image ID=\"Image_0\" Src=\"" + Dtb_Table.Rows[0]["PPI_Url"].ToString() + "\" Height=\"35px\"  border=0 />";

                    }
                    else
                    {
                        Lbl_Mz.Text += Dtb_Table.Rows[0]["PPI_Name"].ToString();
                    }
                    Lbl_Mz.Text += "</a></td></tr>";
                    this.Lbl_Mz.Text += "</table>";

                    KNet.BLL.Pb_Products_Sample bll_Sample = new KNet.BLL.Pb_Products_Sample();
                    DataSet ds_Sample = bll_Sample.GetList(" PPS_ID in (Select KSP_SampleID from KNET_Sys_Products where ProductsBarCode='" + model.ProductsBarCode + "') ");
                    this.MyGridView2.DataSource = ds_Sample;
                    MyGridView2.DataKeyNames = new string[] { "PPS_ID" };
                    MyGridView2.DataBind();

                }
                 * */
                KNet.BLL.Knet_Procure_OrdersList bll_order = new KNet.BLL.Knet_Procure_OrdersList();

                SqlWhere = " OrderNo in (Select OrderNo from Knet_Procure_OrdersList_Details where ProductsBarCode='" + model.ProductsBarCode + "') ";
                SqlWhere += " order by SYstemDateTimes desc";
                DataSet ds_Order = bll_order.GetList(SqlWhere);
                Grid_Order.DataSource = ds_Order.Tables[0];
                Grid_Order.DataKeyNames = new string[] { "OrderNo" };
                Grid_Order.DataBind();


            }
            else
            {
                Response.Write("<script language=javascript>alert('该产品在产品字典中已不存在！');window.close();</script>");
                Response.End();
            }
        }
        else
        {
            Response.Write("<script language=javascript>alert('非法参数！');window.close();</script>");
            Response.End();
        }
    }

    public string GetShState(string s_State)
    {
        string s_Return = "";
        s_Return = base.Base_GetBasicCodeName("132", s_State);
        if (s_Return == "未审核")
        {
            s_Return = "<font color=red>未审核</font>";
        }
        else if (s_Return == "不通过")
        {
            s_Return = "<font color=bule>不通过</font>";
        }
        else
        {
            s_Return = "<font color=green>已审核 </font>";
        }
        return s_Return;
    }
    private void GetBomDetails(KNet.Model.KNet_Sys_Products model)
    {
        decimal d_totalPrice = 0;

        AdminloginMess AM = new AdminloginMess();

        //导入BOM信息 lbl_BomDetails
        StringBuilder Sb_Details = new StringBuilder();
        string s_Sql1 = "Select * from BOM a  where FaterBarCode='" + model.ProductsBarCode + "' order by  物料名称";
        this.BeginQuery(s_Sql1);
        DataTable DtB_Bom = (DataTable)this.QueryForDataTable();
        if (DtB_Bom.Rows.Count > 0)
        {
            for (int i = 0; i < DtB_Bom.Rows.Count; i++)
            {
                Sb_Details.Append("<tr>");
                Sb_Details.Append("<td class=\"ListHeadDetails\">" + (i + 1).ToString() + "</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\">" + DtB_Bom.Rows[i]["物料名称"].ToString() + "</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\">" + DtB_Bom.Rows[i]["物料型号"].ToString() + "</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\">" + DtB_Bom.Rows[i]["封装"].ToString() + "</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\">" + DtB_Bom.Rows[i]["数量"].ToString() + "</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\">" + DtB_Bom.Rows[i]["备注"].ToString() + "</td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\"><a href=\"#\" onclick=\"return btnGetBomProducts_onclick('','" + i.ToString() + "','" + DtB_Bom.Rows[i]["物料型号"].ToString() + "')\" >添加</a><input type=\"hidden\" ID=\"ProdoctsBarCode_" + i.ToString() + "\"  Name=\"ProdoctsBarCode_" + i.ToString() + "\" value='" + DtB_Bom.Rows[i]["BarCode"].ToString() + "'><input type=\"input\"  readonly=\"true\"  ID=\"ProductsName_" + i.ToString() + "\" Name=\"ProductsName_" + i.ToString() + "\" value='" + base.Base_GetProdutsName(DtB_Bom.Rows[i]["BarCode"].ToString()) + "'></td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"input\"  readonly=\"true\" ID=\"ProductsEdition_" + i.ToString() + "\"  Name=\"ProductsEdition_" + i.ToString() + "\" value='" + base.Base_GetProductsEdition(DtB_Bom.Rows[i]["BarCode"].ToString()) + "'></td>");
                Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ID_" + i.ToString() + "\" value='" + DtB_Bom.Rows[i]["ID"].ToString() + "'></td>");
                Sb_Details.Append("</tr>");
            }
        }
        this.Tbx_ImportNum.Text = DtB_Bom.Rows.Count.ToString();
        this.lbl_BomDetails.Text = Sb_Details.ToString();
        KNet.BLL.Xs_Products_Prodocts BLL_Products_Products = new KNet.BLL.Xs_Products_Prodocts();
        KNet.BLL.PB_Basic_ProductsClass BLL_Basic_ProductsClass = new KNet.BLL.PB_Basic_ProductsClass();
        string s_DemoProductsID = "";
        KNet.BLL.Xs_Products_Prodocts_Demo BLL_DemoProducts_Products = new KNet.BLL.Xs_Products_Prodocts_Demo();
        string s_Where1 = " and XPD_FaterBarCode='" + model.ProductsBarCode + "' ";
        //if ((AM.KNet_StaffDepart == "129652784259578018") || (AM.KNet_StaffName == "薛建新"))//如果是
        //{
        //    s_Where1 += " and  b.KSP_Del=0 ";
        //}
        string s_Sql = "Select * from Xs_Products_Prodocts_Demo a join KNET_Sys_Products b on a.XPD_ProductsBarCode=b.ProductsBarCode";
        s_Sql += " join PB_Basic_ProductsClass c on b.ProductsType=c.PBP_ID where 1=1  ";
        this.BeginQuery(s_Sql + s_Where1 + "  order by c.PBP_Name,XPD_Place,ReplaceNum");
        DataSet Dts_DemoProducts = (DataSet)this.QueryForDataSet();
        DataTable Dtb_DemoProducts = Dts_DemoProducts.Tables[0];
        StringBuilder Sb_BomDetails = new StringBuilder();
        if (Dtb_DemoProducts.Rows.Count > 0)
        {
            //base.Base_GetBasicCodeName("1134", model.KSP_UseType)
            for (int i = 0; i < Dtb_DemoProducts.Rows.Count; i++)
            {
                s_DemoProductsID += Dtb_DemoProducts.Rows[i]["XPD_ProductsBarCode"].ToString() + ",";
                Sb_BomDetails.Append("<tr>");
                Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" + (i + 1).ToString() + "</td>");
                Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" + Dtb_DemoProducts.Rows[i]["PBP_Name"].ToString() + "</td>");
                Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" + Dtb_DemoProducts.Rows[i]["ProductsName"].ToString() + "</td>");

                Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition_Link(Dtb_DemoProducts.Rows[i]["XPD_ProductsBarCode"].ToString()) + "</td>");
                string s_ProductsCode = "";

                Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" + Dtb_DemoProducts.Rows[i]["KSP_Code"].ToString() + "</td>");
                Sb_BomDetails.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\" input Name=\"DemoNumber\" value='" + Dtb_DemoProducts.Rows[i]["XPD_Number"].ToString() + "'>" + Dtb_DemoProducts.Rows[i]["XPD_Number"].ToString() + "</td>");
                Sb_BomDetails.Append("<td class=\"ListHeadDetails\" style=\"max-width:100px;word-break: break-all;word-wrap:break-word;\">" + Dtb_DemoProducts.Rows[i]["XPD_Place"].ToString() + "</td>");
                //Sb_BomDetails.Append("<td class=\"ListHeadDetails\" style=\"max-width:100px;word-break: break-all;word-wrap:break-word;\">" + base.Base_GetBasicCodeName("1134", Dtb_DemoProducts.Rows[i]["KSP_UseType"].ToString()) + "</td>");
                if (Dtb_DemoProducts.Rows[i]["ReplaceNum"].ToString()=="0")
                {
                    Sb_BomDetails.Append("<td class=\"ListHeadDetails\" style=\"max-width:100px; word-break: break-all;word-wrap:break-word;\">主料</td>");
                }
                else
                {
                    Sb_BomDetails.Append("<td class=\"ListHeadDetails\" style=\"max-width:100px;color:red;word-break: break-all;word-wrap:break-word;\">替料" + Dtb_DemoProducts.Rows[i]["ReplaceNum"].ToString() + "</td>");
                }

                // Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition_Link(Dtb_DemoProducts.Rows[i]["XPD_ReplaceProductsBarCode"].ToString()) + "</td>");

                string s_Only = Dtb_DemoProducts.Rows[i]["XPD_Only"] == null ? "0" : Dtb_DemoProducts.Rows[i]["XPD_Only"].ToString();
                string s_Check = "";
                if (s_Only == "1")
                {
                    s_Check = "是";
                }
                else
                {
                    s_Check = "否";
                }
                Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" + s_Check + "</td>");
                string s_Del = Dtb_DemoProducts.Rows[i]["KSP_Del"].ToString();
                if (s_Del == "1")
                {
                    Sb_BomDetails.Append("<td class=\"ListHeadDetails\"><font color=red>已停用</font></td>");
                }
                else
                {
                    Sb_BomDetails.Append("<td class=\"ListHeadDetails\"><font color=green>启用</font></td>");
                }

                string s_Del1 = Dtb_DemoProducts.Rows[i]["XPD_Del"].ToString();
                if (s_Del1 == "1")
                {
                    Sb_BomDetails.Append("<td class=\"ListHeadDetails\"><font color=red>已停用</font></td>");
                }
                else
                {
                    Sb_BomDetails.Append("<td class=\"ListHeadDetails\"><font color=green>启用</font></td>");
                }
                string s_IsModify = Dtb_DemoProducts.Rows[i]["KSP_isModiy"].ToString();
                if (s_IsModify == "1")
                {
                    Sb_BomDetails.Append("<td class=\"ListHeadDetails\"><font color=red>待审</font></td>");
                }
                else
                {
                    Sb_BomDetails.Append("<td class=\"ListHeadDetails\"><font color=green>已审</font></td>");
                }

                string s_CgType = Dtb_DemoProducts.Rows[i]["KSP_CgType"].ToString();
                if (s_CgType == "0")
                {
                    Sb_BomDetails.Append("<td class=\"ListHeadDetails\"><font color=red>定制</font></td>");
                }
                else
                {
                    Sb_BomDetails.Append("<td class=\"ListHeadDetails\"><font color=green>分批</font></td>");
                }
                if (AM.YNAuthority("查看库存总账台")&& Lbl_ShowCheck.Text=="true")
                {

                    Sb_BomDetails.Append("<td class=\"ListHeadDetails\">" + base.Base_GetHouseAndNumber1(Dtb_DemoProducts.Rows[i]["XPD_ProductsBarCode"].ToString()) + "</td>");
                }
                else
                {
                    Sb_BomDetails.Append("<td class=\"ListHeadDetails\">&nbsp;</td>");
                }


                Sb_BomDetails.Append("</tr>");
            }
        }
        Lbl_BomDetails1.Text = Sb_BomDetails.ToString();

        if (AM.YNAuthority("BOOM可见权限") == false)
        {
            Lbl_BomDetails1.Text = "";
        }

        Tbx_BomNumber.Text = Dtb_DemoProducts.Rows.Count.ToString();
    }

    protected void Btn_Stop_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_ID = this.Tbx_ID.Text;
        KNet.BLL.KNet_Sys_Products Bll = new KNet.BLL.KNet_Sys_Products();
        KNet.Model.KNet_Sys_Products Model = Bll.GetModelB(s_ID);

        if ((AM.KNet_Position == "103") || (AM.KNet_StaffName == "李文立") || (AM.KNet_StaffName == "薛建新") || (AM.KNet_StaffName == "毛刚挺"))
        {
            if (AM.YNAuthority("停用产品") == true)
            {
                Model.ProductsBarCode = s_ID;
                int i_Del = Math.Abs(Model.KSP_Del - 1);
                Model.KSP_Del = i_Del;
                Bll.UpdateDel(Model);
                AM.Add_Logs("系统设置--->产品字典--->产品字典 添加 操作成功！停用产品编码：" + s_ID);
            }
            else
            {
                AM.NoAuthority("停用产品");
            }
        }
    }
    protected void Btn_Sh_Click(object sender, EventArgs e)
    {

        AdminloginMess AM = new AdminloginMess();
        string s_ID = this.Tbx_ID.Text;

        KNet.BLL.KNet_Sys_Products Bll = new KNet.BLL.KNet_Sys_Products();
        KNet.Model.KNet_Sys_Products Model = Bll.GetModelB(s_ID);

        if ((AM.KNet_Position == "103") || (AM.KNet_StaffName == "李文立") || (AM.KNet_StaffName == "薛建新") || (AM.KNet_StaffName == "毛刚挺"))
        {
            if (AM.YNAuthority("停用产品") == true)
            {
                Model.ProductsBarCode = s_ID;
                int i_Del = Math.Abs(Model.KSP_isModiy - 1);
                Model.KSP_isModiy = i_Del;
                Bll.UpdateisModiy(Model);
                AM.Add_Logs("系统设置--->产品字典--->产品字典 添加 操作成功！确认产品编码：" + s_ID);
            }
            else
            {
                AM.NoAuthority("停用产品");
            }
        }
    }
    public string GetContract(string s_ContractNos, string s_ContractNo1)
    {
        string s_Return = "";
        try
        {
            string[] s_ContractNo = s_ContractNos.Split(',');
            for (int i = 0; i < s_ContractNo.Length; i++)
            {
                s_Return += "<a href=\"/Web/Xs/SalesContract/KNet_Sales_ContractList_View.aspx?ID=" + s_ContractNo[i] + "\" target=\"_blank\" >" + s_ContractNo[i] + "</a><br>";
            }
            if (s_Return == "")
            {
                s_Return += "<a href=\"/Web/Xs/SalesContract/KNet_Sales_ContractList_View.aspx?ID=" + s_ContractNo1 + "\"  target=\"_blank\" >" + s_ContractNo1 + "</a><br>";
            }
        }
        catch
        { }
        return s_Return;
    }

    public string GetRk(string s_RKSTtate, string s_OrderNo)
    {

        if (s_RKSTtate == "0")
        {

            return "<a href=\"/Web/Cg/OrderInWareHouse/Knet_Procure_WareHouseList_Add.aspx?OrderNo=" + s_OrderNo + "\"><font color=\"red\">未入库</font></a>";
        }
        else if (s_RKSTtate == "1")
        {
            return "<a href=\"/Web/Cg/OrderInWareHouse/Knet_Procure_WareHouseList_Add.aspx?OrderNo=" + s_OrderNo + "\"><font color=\"red\">已入库</font></a>";
        }
        else
        {
            return "<a href=\"/Web/Cg/OrderInWareHouse/Knet_Procure_WareHouseList_Add.aspx?OrderNo=" + s_OrderNo + "\"><font color=\"red\">部分发货</font></a>";
        }
    }

    protected string CheckView(string s_OrderNo, string s_OrderType)
    {
        string s_Return = "", JSD = "";
        KNet.BLL.Knet_Procure_OrdersList BLl = new KNet.BLL.Knet_Procure_OrdersList();
        KNet.Model.Knet_Procure_OrdersList Model = BLl.GetModel(s_OrderNo);

        if (Model.KPO_Del == 1)
        {
            return "<font color=red>订单关闭</font>";
        }
        if (Model.OrderCheckYN == false)
        {
            s_Return = "";
        }
        else
        {
            //if (base.base_GetProcureTypeNane(s_OrderType) == "芯片")
            //{
            //    JSD = "OrderList_View.aspx?OrderNo=" + s_OrderNo + "";
            //    s_Return = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=780,height=500');\"  title=\"点击进行审核操作\"><img src=\"../../../images/View.gif\"  border=\"0\" /></a>";

            //}
            //else
            //{ }
            string s_Sql = "Select Sum(KSP_isModiy) from KNet_Sys_Products a join Knet_Procure_OrdersList_Details b on a.ProductsBarCode=b.ProductsBarCode";
            s_Sql += " where b.OrderNo='" + Model.OrderNo + "' ";
            this.BeginQuery(s_Sql);
            string s_IsModiy = this.QueryForReturn();
            if (int.Parse(s_IsModiy) > 0)
            {
                s_Return += "<font color=red>产品需确认</font>";
            }
            else
            {
                JSD = "/web/Cg/Order/Knet_Procure_OpenBilling_Print.aspx?ID=" + s_OrderNo + "";
                s_Return = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=120,left=150,toolbar=yes, menubar=yes,scrollbars=yes, resizable=yes, location=yes, status=yes, width=780,height=500');\"  title=\"点击查看\"><img src=\"/web/images/View.gif\"  border=\"0\" /></a>";
                s_Return += "  <a href=\"/web/Cg/Order/PDF/" + Model.OrderNo + ".PDF\" class=\"webMnu\" target=\"_blank\"><img src=\"/web/images/pdf.gif\"  border=\"0\" /></a> ";
                s_Return += "  <a href=\"/web/Mail/PB_Basic_Mail_Add.aspx?OrderNo=" + Model.OrderNo + "\" class=\"webMnu\" target=\"_blank\"><img src=\"/web/images/email.gif\"  border=\"0\" /></a> ";

            }
        }
        return s_Return;

    }

    protected string GetPrint(string s_OrderNo, int i_IsSend)
    {
        string s_Return = "";
        if (i_IsSend == 0)
        {
            s_Return = "<font color=red>未发送</font>";
        }
        else if (i_IsSend == 1)
        {
            s_Return = "已发送";
        }
        else if (i_IsSend == 2)
        {
            s_Return = "<font color=green>已确认</font>";
        }
        return s_Return;

    }

    public string GetSpce(string s_ID)
    {
        KNet.BLL.Xs_Products_Spce Bll = new KNet.BLL.Xs_Products_Spce();
        KNet.Model.Xs_Products_Spce Model = Bll.GetModel(s_ID);
        string s_XPS_SpceName = "../UpLoadPic/WordSpce/" + Model.XPS_SpceName;

        return s_XPS_SpceName;
    }
    /// <summary>
    /// 字典里是否存在产品
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetKNet_Sys_ProductsYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ProductsBarCode,ProductsName from KNet_Sys_Products where ProductsBarCode='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {

            if (this.Tbx_ImportNum.Text != "0")
            {
                for (int i = 0; i < int.Parse(this.Tbx_ImportNum.Text) + 1; i++)
                {
                    string s_ID = Request.Form["ID_" + i.ToString() + ""] == null ? "" : Request.Form["ID_" + i.ToString() + ""].ToString();

                    string s_ProdoctsBarCode = Request.Form["ProdoctsBarCode_" + i.ToString() + ""] == null ? "" : Request.Form["ProdoctsBarCode_" + i.ToString() + ""].ToString();

                    if ((s_ID != "") && (s_ProdoctsBarCode != ""))
                    {
                        string s_DoSql = "Update Bom Set BarCode='" + s_ProdoctsBarCode + "' where ID='" + s_ID + "'";
                        DbHelperSQL.ExecuteSql(s_DoSql);

                    }
                }
                AlertAndRedirect("更新成功!", "KnetProductsSetting_Details.aspx?BarCode=" + this.Tbx_ID.Text);
            }
        }
        catch { }
    }

    protected void SaveWorkTime_OnClick(object sender, EventArgs e)
    {
        if(this.Lbl_KSPCode.Text.IndexOf("01")!=0)
        {
            Alert("不能对物料添加工时");
            this.WorkTime.Text = "";
            return;
        }
        KNet.Model.KNet_Sys_Products modelKNetSysProducts= new KNet.Model.KNet_Sys_Products();
        KNet.BLL.KNet_Sys_Products bllKNetSysProducts=new KNet.BLL.KNet_Sys_Products();
        modelKNetSysProducts.KSP_WorkTime =Convert.ToDecimal(this.WorkTime.Text) ;
        modelKNetSysProducts.ProductsBarCode = this.ProductsBarCode.Text;
       bool bl= bllKNetSysProducts.UpdateTime(modelKNetSysProducts);
        if(bl==true)
        {
            Alert("保存成功");
        }
        if (bl == false)
        {
            Alert("保存失败");
        }

    }


    //protected void checkbox_OnServerChange(object sender, EventArgs e)
    //{
    //    if (checkbox.Checked)
    //    {
    //        Response.Redirect("/web/Products/KnetProductsSetting_Details.aspx?BarCode=" + this.Tbx_ID.Text);
    //    }
    //    else
    //    {
    //        Response.Redirect("/web/Products/KnetProductsSetting_Details.aspx?BarCode=" + this.Tbx_ID.Text);
    //    }
    //}
}

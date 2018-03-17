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
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 报价单  打印单据
/// </summary>
public partial class Knet_Sales_KNet_Sales_ContractList_Manage_PrinterListSettingPrinterPage : BasePage
{
    private string OrderAmount_Recodor = "0"; //入库记录数 合计
    private decimal OrderAmount_Sum = 0;       //入库数量 合计

    private decimal OrderDiscount_Sum = 0;     //计价调节合计
    private decimal OrderTotalNet_Sum = 0;     //净值合计


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();

            //合同单打印
            if (AM.CheckLogin("查看合同评审") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            if (Request["ContractNo"] != null && Request["ContractNo"] != "")
            {
                if (Request["PrinterModel"] != null && Request["PrinterModel"] != "")
                {
                    string ContractNo = Request["ContractNo"].Trim();
                    string Tex_ID = Request["PrinterModel"].Trim();

                    this.DataShows(ContractNo, Tex_ID); //明细记录
                    this.GridView2.Attributes.Add("BorderColor", "#000000");
                    //模板里的信息
                    this.ShowInfo(ContractNo, Tex_ID);
                }
                else
                {
                    Response.Write("<script>alert('非法请求，请选择打印模板');history.back(-1);</script>");
                    Response.End();
                }

            }
            else
            {
                Response.Write("<script>alert('非法参数，非法请求！');history.back(-1);</script>");
                Response.End();
            }
        }
    }

    /// <summary>
    /// 获得数据列表
    /// </summary>
    public DataSet Get_Knet_Procure_OpenBillingPrinter_Value(string Tex_ID)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select Tex_Value,Tex_Texte,Tex_pai,Tex_ID");
        strSql.Append(" FROM KNet_Sales_ContractList_PrinterValue where Tex_ID='" + Tex_ID + "' ");
        strSql.Append("order by Tex_pai desc");
        return DbHelperSQL.Query(strSql.ToString());
    }

    /// <summary>
    /// 报价单  明细记录
    /// </summary>
    protected void DataShows(string ContractNo, string Tex_ID)
    {
        string SqlWhere = " ContractNo ='" + ContractNo + "' ";
        //明细
        KNet.BLL.KNet_Sales_ContractList_Details bll = new KNet.BLL.KNet_Sales_ContractList_Details();
        DataTable dt = bll.GetListJoinProducts(SqlWhere).Tables[0];  //返datatable的数据集合 user包含 id,name,sex,age,tel,email,address字段


        BoundField bf1 = new BoundField();
        bf1.DataField = "ID";
        bf1.HeaderText = "序号";
        GridView2.Columns.Add(bf1);

        DataSet MyDs = Get_Knet_Procure_OpenBillingPrinter_Value(Tex_ID);

        for (int wj = 0; wj < MyDs.Tables[0].Rows.Count; wj++)
        {
            if (MyDs.Tables[0].Rows[wj]["Tex_Value"].ToString() == "Contract_SalesUnitPrice" || MyDs.Tables[0].Rows[wj]["Tex_Value"].ToString() == "Contract_SalesDiscount" || MyDs.Tables[0].Rows[wj]["Tex_Value"].ToString() == "Contract_SalesTotalNet")
            {
                BoundField bf3 = new BoundField();
                bf3.DataFormatString = "{0:C3}";
                bf3.HtmlEncode = false;
                bf3.DataField = MyDs.Tables[0].Rows[wj]["Tex_Value"].ToString();
                bf3.HeaderText = MyDs.Tables[0].Rows[wj]["Tex_Texte"].ToString();
                GridView2.Columns.Add(bf3);
            }
            else
            {
                if (MyDs.Tables[0].Rows[wj]["Tex_Value"].ToString() == "ProductsUnits")
                {
                    TemplateField TF2 = new TemplateField();
                    TF2.ItemTemplate = new GridViewTemplate(DataControlRowType.DataRow, MyDs.Tables[0].Rows[wj]["Tex_Value"].ToString());
                    TF2.HeaderTemplate = new GridViewTemplate(DataControlRowType.Header, MyDs.Tables[0].Rows[wj]["Tex_Texte"].ToString());
                    GridView2.Columns.Add(TF2);
                }
                else
                {
                    BoundField bf2 = new BoundField();
                    bf2.DataField = MyDs.Tables[0].Rows[wj]["Tex_Value"].ToString();
                    bf2.HeaderText = MyDs.Tables[0].Rows[wj]["Tex_Texte"].ToString();
                    GridView2.Columns.Add(bf2);
                }
            }
        }

        //========================
        GridView2.DataSource = dt;
        GridView2.DataBind();


        //////统计记录数
        OrderAmount_Recodor = dt.Rows.Count.ToString();

        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            DataRowView mydrv = dt.DefaultView[i];

            //计价调节合计
           // OrderDiscount_Sum = OrderDiscount_Sum + decimal.Parse(mydrv["Contract_SalesDiscount"].ToString());
            //净值合计
            OrderTotalNet_Sum = OrderTotalNet_Sum + decimal.Parse(mydrv["Contract_SalesTotalNet"].ToString());

            //数量 合计
            OrderAmount_Sum = OrderAmount_Sum + decimal.Parse(mydrv["ContractAmount"].ToString());
        }
    }


    #region 模板定义类



    /// <summary>
    /// 模板定义类
    /// </summary>
    public class GridViewTemplate : ITemplate
    {
        private DataControlRowType templateType;
        private string columnName;

        public GridViewTemplate(DataControlRowType type, string colname)
        {
            templateType = type;
            columnName = colname;
        }
        public void InstantiateIn(System.Web.UI.Control container)
        {
            switch (templateType)
            {

                case DataControlRowType.Header:
                    Literal lc = new Literal();
                    lc.Text = "<b>" + columnName + "</b>";
                    container.Controls.Add(lc);
                    break;

                case DataControlRowType.DataRow:

                    Label tb = new Label(); //定义
                    tb.ID = "WageValue";

                    if (columnName == "ProductsUnits")
                    {
                        tb.DataBinding += new EventHandler(this.Staffwages_DataBinding);
                        
                    }
                    if (columnName == "WareHousePack")
                    {
                        tb.DataBinding += new EventHandler(this.Staffwages_DataBindPack);
                        container.Controls.Add(tb);
                    }
                   // tb.Text = columnName;
                    container.Controls.Add(tb);
                    break;

                default:
                    break;
            }
        }
        /// <summary>
        /// 字段绑定（单位）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Staffwages_DataBinding(Object sender, EventArgs e)
        {
            Label l = (Label)sender;
            GridViewRow row = (GridViewRow)l.NamingContainer;
            l.Text = this.GetProductUnitBB(DataBinder.Eval(row.DataItem, "ProductsUnits").ToString());
        }

        /// <summary>
        /// 字段绑定（包装）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Staffwages_DataBindPack(Object sender, EventArgs e)
        {
            Label l = (Label)sender;
            GridViewRow row = (GridViewRow)l.NamingContainer;
            l.Text = this.GetProductPackName(DataBinder.Eval(row.DataItem, "WareHousePack").ToString());
        }
        /// <summary>
        /// 获单位名称
        /// </summary>
        /// <param name="aa"></param>
        /// <returns></returns>
        private string GetProductUnitBB(object aa)
        {
            using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
            {
                conn.Open();
                string DoSqls = "select ID,UnitsNo,UnitsName from KNet_Sys_Units where UnitsNo='" + aa + "'";
                SqlCommand cmd = new SqlCommand(DoSqls, conn);
                using (SqlDataReader DR = cmd.ExecuteReader())
                {
                    if (DR.Read())
                    {
                        return DR["UnitsName"].ToString();
                    }
                    else
                    {
                        return "--";
                    }
                }
            }
        }

        /// <summary>
        /// 获包装名称
        /// </summary>
        /// <param name="aa"></param>
        /// <returns></returns>
        private string GetProductPackName(object aa)
        {
            using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
            {
                conn.Open();
                string DoSqls = "select ID,PackValue,PackName from KNet_Sys_ProcurePack where PackValue='" + aa + "'";
                SqlCommand cmd = new SqlCommand(DoSqls, conn);
                using (SqlDataReader DR = cmd.ExecuteReader())
                {
                    if (DR.Read())
                    {
                        return DR["PackName"].ToString();
                    }
                    else
                    {
                        return "--";
                    }
                }
            }
        }
    }


    #endregion



    /// <summary>
    /// 自动编号
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
        }
    }

    /// <summary>
    /// 反回首打印选择页 （Y）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("KNet_Sales_ContractList_Manage_PrinterList.aspx?Css4=Div22");
        Response.End();
    }

    /// <summary>
    /// 载断标题
    /// </summary>
    /// <param name="sString"></param>
    /// <param name="nLeng"></param>
    /// <returns></returns>
    public string SubStr(string sString, int nLeng)
    {
        if (sString.Length <= nLeng)
        {
            return sString;
        }
        string sNewStr = sString.Substring(0, nLeng);
        sNewStr = sNewStr + "...";
        return sNewStr;
    }

    /// <summary>
    /// 获取 分公司名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string KNet_StrucName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StrucValue,StrucName from KNet_Resource_OrganizationalStructure where StrucValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["StrucName"].ToString();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 获取 客户名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string KNet_CustomerName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,CustomerValue,CustomerName from KNet_Sales_ClientList  where CustomerValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["CustomerName"].ToString();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 合同单  显内容
    /// </summary>
    /// <param name="ProcureBM"></param>
    private void ShowInfo(string ContractNo, string Tex_ID)
    {
        KNet.BLL.KNet_Sales_ContractList bll = new KNet.BLL.KNet_Sales_ContractList();
        KNet.Model.KNet_Sales_ContractList model = bll.GetModelB(ContractNo);

        KNet.BLL.KNet_Sales_ContractList_Printersetup BLL2 = new KNet.BLL.KNet_Sales_ContractList_Printersetup();
        KNet.Model.KNet_Sales_ContractList_Printersetup Model2 = BLL2.GetModelB(Tex_ID);

        KNet.BLL.KNet_Sales_ClientList bll3 = new KNet.BLL.KNet_Sales_ClientList();
        KNet.Model.KNet_Sales_ClientList model3 = bll3.GetModelB(model.CustomerValue);


        //合同单信息
        string TopComten = Model2.TopComtont.ToString();
        string BotComten = Model2.BotComtont.ToString();

        TopComten = TopComten.Replace("{$KNet_ContractNo$}", model.ContractNo);//合同编号
        TopComten = TopComten.Replace("{$KNet_CustomerName$}", base.Base_GetCustomerName(model.CustomerValue));//客户名称
        TopComten = TopComten.Replace("{$KNet_DutyPerson$}", base.Base_GetUserName(model.DutyPerson));//责任人


        
        TopComten = TopComten.Replace("{$KNet_ContractDateTime$}", model.ContractDateTime.ToString());//签订日期
        TopComten = TopComten.Replace("{$KNet_OursDelegate$}", model.ContractOursDelegate);//供方代表
        TopComten = TopComten.Replace("{$KNet_SideDelegate$}", model.ContractSideDelegate);//需方代表


        TopComten = TopComten.Replace("{$KNet_ContractToAddress$}", model.ContractToAddress);//地址
        TopComten = TopComten.Replace("{$KNet_ContentName$}", model.ContentPerson);//联系人
        TopComten = TopComten.Replace("{$KNet_Position$}", "职员");//职位
        TopComten = TopComten.Replace("{$KNet_Telphone$}", model.Telephone);//电话
        TopComten = TopComten.Replace("{$KNet_Fax$}", model3.CustomerFax);//传真
        TopComten = TopComten.Replace("{$KNet_Net$}", model3.CustomerWebsite);//网址
        TopComten = TopComten.Replace("{$KNet_Email$}", model3.CustomerEmail);//Email
        TopComten = TopComten.Replace("{$KNet_ContractClass$}", base.Base_GetKClaaName(model.ContractClass));//合同类型

        BotComten = BotComten.Replace("{$KNet_TechnicalRequire$}", model.TechnicalRequire);//技术要求
        BotComten = BotComten.Replace("{$KNet_ProductPackaging$}", model.ProductPackaging);//产品包装     
        BotComten = BotComten.Replace("{$KNet_Payment$}", base.Base_GetBasicCodeName("104", model.Payment));// 付款方式   
        BotComten = BotComten.Replace("{$KNet_ContractClass$}", base.Base_GetCheckMethod(model.ContractToPayment));// 结算方式
        BotComten = BotComten.Replace("{$KNet_Transport$}", "常规：" + base.Base_GetBasicCodeName("102", model.RoutineTransport) + "|应急：" + base.Base_GetBasicCodeName("103", model.WorryTransport) );// 结算方式

        BotComten = BotComten.Replace("{$KNet_ContractToDeliDate$}", model.ContractToDeliDate.ToString());// 交货日期
        BotComten = BotComten.Replace("{$KNet_QualityRequire$}", model.QualityRequire);// 质量要求
        BotComten = BotComten.Replace("{$KNet_WarrantyPeriod$}", model.WarrantyPeriod);// 质保期    
        BotComten = BotComten.Replace("{$KNet_DeliveryRequire$}", model.DeliveryRequire);// 备货要求
        BotComten = BotComten.Replace("{$KNet_ContractRemarks$}", model.ContractRemarks);// 其他
        BotComten = BotComten.Replace("{$KNet_ContractShip$}", model.ContractShip);// 发货要求

        TopComten = TopComten.Replace("size=35", "");
        TopComten = TopComten.Replace("size=72", "");
        TopComten = TopComten.Replace("name=a", "");

        BotComten = BotComten.Replace("size=35", "");
        BotComten = BotComten.Replace("size=72", "");
        BotComten = BotComten.Replace("name=b", "");
        




      

        this.TopPrinterDo.InnerHtml = TopComten; //上部内容
        this.BotPrinter.InnerHtml = BotComten; //上部内容


        //统计开始
        if (Model2.PrintStatShow==false)
        {
            this.SmA.Visible = false;
        }

        string CStrAll = "";
        decimal OrderTotalNet_Sumdec = decimal.Parse(OrderTotalNet_Sum.ToString());
        if (Model2.PrintAmount_Recodor == true)
        {
            CStrAll = CStrAll + "共有:<B><font color=#000000>" + OrderAmount_Recodor.ToString() + "</font></B> 笔明细记录";
        }

        if (Model2.PrintAmount_Sum==true)
        {
            CStrAll = CStrAll + "，数量合计:<B><font color=#000000>" + OrderAmount_Sum.ToString() + "</font></B> ";
        }
        if (Model2.PrintDiscount_Sum==true)
        {
            CStrAll = CStrAll + "，调价合计:<B><font color=#000000>" + OrderDiscount_Sum.ToString("N") + "</font></B>";
        }

        if (Model2.PrintTotalNet_Sum==true)
        {
            CStrAll = CStrAll + "，金额合计:<B><font color=#000000>" + OrderTotalNet_Sum.ToString("N") + "</font></B>，金额大写:<B>" + KNetPage.CmycurD(OrderTotalNet_Sumdec) + "</B>";
        }

        this.SmA.Text = CStrAll;

    }



}

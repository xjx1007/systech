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
public partial class Knet_Sales_Knet_Sales_Ship_Manage_PrinterListSettingPrinterPage : BasePage
{
    private string OrderAmount_Recodor = "0"; //入库记录数 合计
    private double OrderAmount_Sum = 0;       //入库数量 合计

    private double OrderDiscount_Sum = 0;     //计价调节合计
    private double OrderTotalNet_Sum = 0;     //净值合计


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
            if (AM.CheckLogin("发货单打印") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                if (Request["OutWareNo"] != null && Request["OutWareNo"] != "")
                {
                    if (Request["PrinterModel"] != null && Request["PrinterModel"] != "")
                    {
                        string OutWareNo = Request["OutWareNo"].Trim();
                        string Tex_ID = Request["PrinterModel"].Trim();

                        this.DataShows(OutWareNo, Tex_ID); //明细记录
                        this.GridView2.Attributes.Add("BorderColor", "#000000");

                        //模板里的信息
                        this.ShowInfo(OutWareNo, Tex_ID);
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
    }


    /// <summary>
    /// 获得数据列表
    /// </summary>
    public DataSet Get_Knet_Procure_OpenBillingPrinter_Value(string Tex_ID)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select Tex_Value,Tex_Texte,Tex_pai,Tex_ID");
        strSql.Append(" FROM KNet_Sales_OutWareList_PrinterValue where Tex_ID='" + Tex_ID + "' ");
        strSql.Append("order by Tex_pai desc");
        return DbHelperSQL.Query(strSql.ToString());
    }

    /// <summary>
    /// 报价单  明细记录
    /// </summary>
    protected void DataShows(string OutWareNo, string Tex_ID)
    {
        string SqlWhere = " OutWareNo ='" + OutWareNo + "' ";
        //明细
        KNet.BLL.KNet_Sales_OutWareList_Details bll = new KNet.BLL.KNet_Sales_OutWareList_Details();
        DataTable dt = bll.GetList(SqlWhere).Tables[0];  //返datatable的数据集合 user包含 id,name,sex,age,tel,email,address字段


        BoundField bf1 = new BoundField();
        bf1.DataField = "ID";
        bf1.HeaderText = "序号";
        GridView2.Columns.Add(bf1);


        DataSet MyDs = Get_Knet_Procure_OpenBillingPrinter_Value(Tex_ID);

        for (int wj = 0; wj < MyDs.Tables[0].Rows.Count; wj++)
        {
            if (MyDs.Tables[0].Rows[wj]["Tex_Value"].ToString() == "OutWare_SalesUnitPrice" || MyDs.Tables[0].Rows[wj]["Tex_Value"].ToString() == "OutWare_SalesDiscount" || MyDs.Tables[0].Rows[wj]["Tex_Value"].ToString() == "OutWare_SalesTotalNet")
            {
                BoundField bf3 = new BoundField();
                bf3.DataFormatString = "{0:c}";
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
       //净值合计
            OrderTotalNet_Sum = OrderTotalNet_Sum + double.Parse(mydrv["OutWare_SalesTotalNet"].ToString());

            //数量 合计
            OrderAmount_Sum = OrderAmount_Sum + double.Parse(mydrv["OutWareAmount"].ToString());
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
        Response.Redirect("Knet_Sales_Ship_Manage_PrinterList.aspx?Css4=Div22");
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
    private void ShowInfo(string OutWareNo, string Tex_ID)
    {
        KNet.BLL.KNet_Sales_OutWareList bll = new KNet.BLL.KNet_Sales_OutWareList();
        KNet.Model.KNet_Sales_OutWareList model = bll.GetModelB(OutWareNo);

        KNet.BLL.KNet_Sales_OutWareList_Printersetup BLL2 = new KNet.BLL.KNet_Sales_OutWareList_Printersetup();
        KNet.Model.KNet_Sales_OutWareList_Printersetup Model2 = BLL2.GetModelB(Tex_ID);

        //发货单 上部信息
        string TopComten = Model2.TopComtont.ToString();

        TopComten = TopComten.Replace("{$KNet_ContractNo$}", model.ContractNo);//合同编号（Y）
        TopComten = TopComten.Replace("{$KNet_OutWareNo$}", model.OutWareNo);//发货编号（Y）
        
        TopComten = TopComten.Replace("{$KNet_CustomerName$}", KNet_CustomerName(model.CustomerValue));//收货单位（Y）
        TopComten = TopComten.Replace("{$KNet_BranchName$}", KNet_StrucName(model.OutWareStaffBranch));//发货单位（Y）


        TopComten = TopComten.Replace("{$KNet_OutWareDateTime$}", model.OutWareDateTime.ToString());//发货日期（Y）
        TopComten = TopComten.Replace("{$KNet_OursContact$}", model.OutWareOursContact);//发货联系人（Y）
        if (model.KSO_ContentPersonName != "")
        {

            TopComten = TopComten.Replace("{$KNet_SideContact$}", model.KSO_ContentPersonName);//收货联系人
        }
        else
        {
            TopComten = TopComten.Replace("{$KNet_SideContact$}", base.Base_GetLinkManValue(model.OutWareSideContact, "XOL_Name"));//收货联系人
        }
        TopComten = TopComten.Replace("{$KNet_Telphone$}", model.KSO_TelPhone);//电话
        TopComten = TopComten.Replace("{$KNet_Type$}", base.Base_GetKClaaName(model.ContractDeliveMethods));//交货方式
        TopComten = TopComten.Replace("{$KNet_ToAddress$}", model.ContractToAddress);//地址
        TopComten = TopComten.Replace("{$KNet_PlanOutWareDateTime$}", model.KSO_PlanOutWareDateTime.ToString());//预计发货日期（Y）

      

        this.TopPrinterDo.InnerHtml = TopComten; //上部内容


        string BottComten = Model2.BotComtont.ToString();
        BottComten = BottComten.Replace("{$KNetB_CustomerName$}", KNet_CustomerName(model.CustomerValue));//收货单位(章):
        BottComten = BottComten.Replace("{$KNetB_BranchName$}", KNet_StrucName(model.OutWareStaffBranch));//发货单位(章):

        BottComten = BottComten.Replace("{$KNetB_SideContact$}", model.OutWareSideContact);//签收人
        BottComten = BottComten.Replace("{$KNetB_OursContact$}", model.OutWareOursContact); //发货联系
        BottComten = BottComten.Replace("{$KNetB_DateTime$}", model.OutWareDateTime.ToString());//发货日期
        if (model.OutWareRemarks.ToString().Length > 80)
        {
            BottComten = BottComten.Replace("{$KNet_Remarks$}", model.OutWareRemarks.ToString().Substring(0, 65));//发货日期
            BottComten = BottComten.Replace("{$KNet_Remarks1$}", model.OutWareRemarks.ToString().Substring(65, model.OutWareRemarks.ToString().Length -65));//发货日期
        }
        else
        {
            BottComten = BottComten.Replace("{$KNet_Remarks$}", model.OutWareRemarks.ToString());//发货日期

            BottComten = BottComten.Replace("{$KNet_Remarks1$}", "");//发货日期
        }
        BottComten = BottComten.Replace("{$KNet_SuppRemarks$}", model.KSO_SuppNoRemarks.ToString());
        

        this.BotPrinter.InnerHtml = BottComten; //下部内容


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

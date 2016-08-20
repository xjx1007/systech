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
public partial class Knet_WareHouse_KNet_WareHouse_WareCheck_Manage_PrinterListSettingPage : System.Web.UI.Page
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
            if (AM.CheckLogin("盘点单打印") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {

                if (Request["WareCheckNo"] != null && Request["WareCheckNo"] != "")
                {
                    if (Request["PrinterModel"] != null && Request["PrinterModel"] != "")
                    {
                        string WareCheckNo = Request["WareCheckNo"].Trim();
                        string Tex_ID = Request["PrinterModel"].Trim();

                        this.DataShows(WareCheckNo, Tex_ID); //明细记录
                        this.GridView2.Attributes.Add("BorderColor", "#000000");

                        //模板里的信息
                        this.ShowInfo(WareCheckNo, Tex_ID);
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
        strSql.Append(" FROM KNet_WareHouse_WareCheckList_Printer_Value where Tex_ID='" + Tex_ID + "' ");
        strSql.Append("order by Tex_pai desc");
        return DbHelperSQL.Query(strSql.ToString());
    }

    /// <summary>
    /// 报价单  明细记录
    /// </summary>
    protected void DataShows(string WareCheckNo, string Tex_ID)
    {
        string SqlWhere = " WareCheckNo ='" + WareCheckNo + "' ";
        //明细
        KNet.BLL.KNet_WareHouse_WareCheckList_Details bll = new KNet.BLL.KNet_WareHouse_WareCheckList_Details();
        DataTable dt = bll.GetList(SqlWhere).Tables[0];  //返datatable的数据集合 user包含 id,name,sex,age,tel,email,address字段


        BoundField bf1 = new BoundField();
        bf1.DataField = "ID";
        bf1.HeaderText = "序号";
        GridView2.Columns.Add(bf1);


        DataSet MyDs = Get_Knet_Procure_OpenBillingPrinter_Value(Tex_ID);

        for (int wj = 0; wj < MyDs.Tables[0].Rows.Count; wj++)
        {
            if (MyDs.Tables[0].Rows[wj]["Tex_Value"].ToString() == "WareCheckUnitPrice" || MyDs.Tables[0].Rows[wj]["Tex_Value"].ToString() == "WareCheckDiscount" || MyDs.Tables[0].Rows[wj]["Tex_Value"].ToString() == "WareCheckTotalNet")
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
                if (MyDs.Tables[0].Rows[wj]["Tex_Value"].ToString() == "ProductsUnits" || MyDs.Tables[0].Rows[wj]["Tex_Value"].ToString() == "WareCheckLossUp")
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
            OrderDiscount_Sum = OrderDiscount_Sum + double.Parse(mydrv["WareCheckDiscount"].ToString());
            //净值合计
            OrderTotalNet_Sum = OrderTotalNet_Sum + double.Parse(mydrv["WareCheckTotalNet"].ToString());

            //数量 合计
            OrderAmount_Sum = OrderAmount_Sum + double.Parse(mydrv["WareCheckAmount"].ToString());
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
                    if (columnName == "WareCheckLossUp")
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
            l.Text = this.GetProductPackName(DataBinder.Eval(row.DataItem, "WareCheckLossUp").ToString());
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
            if (aa.ToString() == "1")
            {
                return "盘正";
            }
            if (aa.ToString() == "2")
            {
                return "盘负";
            }
            else
            {
                return "--";
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
        Response.Redirect("KNet_WareHouse_WareCheck_Manage_PrinterList.aspx?Css4=Div22");
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
    /// 获取经办人
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    public string GetKNet_KNet_Resource_Staff(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string DoSqls = "select ID,StaffNo,StaffName from KNet_Resource_Staff  where StaffNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(DoSqls, conn);
            using (SqlDataReader DR = cmd.ExecuteReader())
            {
                if (DR.Read())
                {
                    return DR["StaffName"].ToString();
                }
                else
                {
                    return "--";
                }
            }
        }
    }
    /// <summary>
    /// 获取所入库仓库
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    public string GetKNet_KNet_Sys_WareHouse(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string DoSqls = "select ID,HouseNo,HouseName from KNet_Sys_WareHouse  where HouseNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(DoSqls, conn);
            using (SqlDataReader DR = cmd.ExecuteReader())
            {
                if (DR.Read())
                {
                    return DR["HouseName"].ToString();
                }
                else
                {
                    return "--";
                }
            }
        }
    }
    /// <summary>
    /// 报价单  显内容
    /// </summary>
    /// <param name="ProcureBM"></param>
    private void ShowInfo(string WareCheckNo, string Tex_ID)
    {
        KNet.BLL.KNet_WareHouse_WareCheckList bll = new KNet.BLL.KNet_WareHouse_WareCheckList();
        KNet.Model.KNet_WareHouse_WareCheckList model = bll.GetModelB(WareCheckNo);

        KNet.BLL.KNet_WareHouse_WareCheckList_Printer_Setup BLL2 = new KNet.BLL.KNet_WareHouse_WareCheckList_Printer_Setup();
        KNet.Model.KNet_WareHouse_WareCheckList_Printer_Setup Model2 = BLL2.GetModelB(Tex_ID);

        //报价单信息
        string TopComten = Model2.TopComtont.ToString();
        TopComten = TopComten.Replace("{$KNet_CheckTopic$}", GetStringsx(model.WareCheckTopic));//主题

        TopComten = TopComten.Replace("{$KNet_CheckNo$}", model.WareCheckNo.ToString());//单号

        TopComten = TopComten.Replace("{$KNet_CheckDateTime$}", GetStringsx(model.WareCheckDateTime)); //日期 ***
        TopComten = TopComten.Replace("{$KNet_StaffNo$}", GetKNet_KNet_Resource_Staff(model.WareCheckStaffNo)); //经办人 ***
        TopComten = TopComten.Replace("{$KNet_HouseNo$}", GetKNet_KNet_Sys_WareHouse(model.HouseNo)); //仓库 ***

        this.TopPrinterDo.InnerHtml = TopComten; //上部内容

        this.BotPrinter.InnerHtml = Model2.BotComtont; //下部内容


        //统计开始
        if (Model2.PrintStatShow==false)
        {
            this.SmA.Visible = false;
        }

        string CStrAll = "";
        if (Model2.PrintAmount_Recodor == true)
        {
            CStrAll = CStrAll + "共有：<B><font color=#FF0000>" + OrderAmount_Recodor.ToString() + "</font></B> 笔明细记录";
        }

        if (Model2.PrintAmount_Sum==true)
        {
            CStrAll = CStrAll + "，数量合计：<B><font color=#FF0000>" + OrderAmount_Sum.ToString() + "</font></B> ";
        }
        if (Model2.PrintDiscount_Sum==true)
        {
            CStrAll = CStrAll + "，调节金额合计：<B><font color=#000099>" + OrderDiscount_Sum.ToString("N") + "</font></B>";
        }

        if (Model2.PrintTotalNet_Sum==true)
        {
            CStrAll = CStrAll + "，金额合计：<B><font color=#0000FF>" + OrderTotalNet_Sum.ToString("N") + "</font></B>";
        }

        this.SmA.Text = CStrAll;

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetStringsx(object aa)
    {
        if (aa.ToString() == "" || aa == null)
        {
            return "--";
        }
        else
        {
            return aa.ToString();
        }
    }



}

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
using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 选择供应商采购报价
/// </summary>
public partial class Knet_Common_SelectProductsDictionary : System.Web.UI.Page
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
        this.Page.Title = "采购产品选择";

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
                DataSet ds = KNet.Common.KNet_Static_BigClass.GetBigInfo();
                string BigNo, CateName;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    BigNo = ds.Tables[0].Rows[i]["BigNo"].ToString();
                    CateName = ds.Tables[0].Rows[i]["CateName"].ToString();
                    this.BigClass.Items.Add(new ListItem(CateName, BigNo));
                }
                this.SmallClass.Disabled = true;


                if (Request.QueryString["OrderNo"] != null && Request.QueryString["OrderNo"] != "")
                {
                    if (Request.QueryString["SuppNo"] != null && Request.QueryString["SuppNo"] != "")
                    {


                        ViewState["SortOrder"] = "ProductsAddTime";
                        ViewState["OrderDire"] = "Desc";
                        this.Button2.Attributes.Add("onclick", "return confirm('您确定要把所选择的记录添加到采购明细记录吗？')");

                        this.HyperLink1.NavigateUrl = "SelectSuppliersPrice.aspx?OrderNo=" + Request.QueryString["OrderNo"].Trim() + "&SuppNo=" + Request.QueryString["SuppNo"].Trim() + "&Sn=" + DateTime.Now.ToFileTimeUtc().ToString() + "";
                        this.HyperLink2.NavigateUrl = "SelectProductsDictionary.aspx?OrderNo=" + Request.QueryString["OrderNo"].Trim() + "&SuppNo=" + Request.QueryString["SuppNo"].Trim() + "&Sn=" + DateTime.Now.ToFileTimeUtc().ToString() + "";
                        
                        
                        this.DataShows();
                        this.RowOverYN();

                        this.ssdsdDataShows();
                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('非法请求参数！');window.close();</script>");
                        Response.End();
                    }
                }
                else
                {
                    Response.Write("<script language=javascript>alert('非法请求参数！');window.close();</script>");
                    Response.End();
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
            this.Button3.Enabled = false;
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sys_Products bll = new KNet.BLL.KNet_Sys_Products();
        string SqlWhere = " 1=1 ";

        if (Request["SeachKey"] != null && Request["SeachKey"] != "")
        {
            string KSeachKey = Request.QueryString["SeachKey"].ToString().Trim();
            this.SeachKey.Text = KSeachKey;
            SqlWhere = SqlWhere + " and ( ProductsName like '%" + KSeachKey + "%' or ProductsBarCode  like '%" + KSeachKey + "%' or ProductsPattern  like '%" + KSeachKey + "%' )";
        }

        if (Request["ProductsMainCategory"] != null && Request["ProductsMainCategory"] != "" && Request["ProductsMainCategory"] != "0")
        {
            string KDBList = Request.QueryString["ProductsMainCategory"].ToString().Trim();
            this.BigClass.Value = KDBList;
            SqlWhere = SqlWhere + " and  ProductsMainCategory = '" + KDBList + "' ";
        }

        if (Request["ProductsSmallCategory"] != null && Request["ProductsSmallCategory"] != "" && Request["ProductsSmallCategory"] != "0")
        {
            string KDBListSall = Request.QueryString["ProductsSmallCategory"].ToString().Trim();
            SqlWhere = SqlWhere + " and  ProductsSmallCategory = '" + KDBListSall + "' ";
        }
       


        using (DataSet ds = bll.GetList(SqlWhere))
        {
            //正反排序------
            DataView dv = ds.Tables[0].DefaultView;
            string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            dv.Sort = sort;
            //--分页-------
            PagedDataSource pds = new PagedDataSource();
            AspNetPager1.RecordCount = dv.Count;
            pds.DataSource = dv;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;
            //--End分页-----
            GridView1.DataSource = pds;
            GridView1.DataKeyNames = new string[] { "ID" };
            GridView1.DataBind();
        }
    }
    /// <summary>
    /// 正反排序
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sPage = e.SortExpression;
        if (ViewState["SortOrder"].ToString() == sPage)
        {
            if (ViewState["OrderDire"].ToString() == "Desc")
                ViewState["OrderDire"] = "ASC";
            else
                ViewState["OrderDire"] = "Desc";
        }
        else
        {
            ViewState["SortOrder"] = e.SortExpression;
        }
        this.DataShows();
        this.RowOverYN();
    }
    /// <summary>
    /// 执行全选操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkM = (CheckBox)GridView1.HeaderRow.Cells[0].FindControl("CheckBox1");

        foreach (GridViewRow gr in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)gr.Cells[0].FindControl("Chbk");
            if (!chk.Checked)
            {
                chk.Checked = true;
                ChkM.Text = "消";
            }
            else
            {
                chk.Checked = false;
                ChkM.Text = "选";
            }
        }
    }
    /// <summary>
    /// 执行分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object src, EventArgs e)
    {
        this.DataShows();
        this.RowOverYN();
    }

    /// <summary>
    /// 添加提示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        { //自动ID号
            int id = (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }

    /// <summary>
    /// 确定选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        KNet.BLL.KNet_Sys_Products BLL = new KNet.BLL.KNet_Sys_Products();
        if (Request.QueryString["OrderNo"] != null && Request.QueryString["OrderNo"] != "")
        {
            string cal = "";
            string MyOrderNo = Request.QueryString["OrderNo"].Trim();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (cb.Checked == true)
                {
                    KNet.Model.KNet_Sys_Products model = BLL.GetModel(GridView1.DataKeys[i].Value.ToString());

                    //添加记录
                    this.AddToKnet_Procure_OrdersList_Details(MyOrderNo, model.ProductsName, model.ProductsBarCode, model.ProductsPattern, model.ProductsUnits, 1, decimal.Parse(model.ProductsCostPrice.ToString()), 0, decimal.Parse(model.ProductsCostPrice.ToString()), "",decimal.Parse(model.HandPrice.ToString()));

                    cal += GridView1.DataKeys[i].Value.ToString();
                }
            }
            if (cal == "")
            {
                Response.Write("<script language=javascript>alert('您没有选择要操作的记录!');this.window.close();</script>");
                Response.End();
            }
            else
            {
                AdminloginMess LogAM = new AdminloginMess();
                LogAM.Add_Logs("采购入库--->开采购单--->添加采购明细记录 操作成功！");

                //StringBuilder s = new StringBuilder();
                //s.Append("<script language=javascript>" + "\n");
                //s.Append("window.opener.refresh();" + "\n");
                ////s.Append("window.focus();" + "\n");
                ////s.Append("window.opener=null;" + "\n");
                //s.Append("</script>");
                //Type cstype = this.GetType();
                //ClientScriptManager cs = Page.ClientScript;
                //string csname = "ltype";
                //if (!cs.IsStartupScriptRegistered(cstype, csname))
                //    cs.RegisterStartupScript(cstype, csname, s.ToString());
                this.ssdsdDataShows();
                this.DataShows();
                this.RowOverYN();
                //StringBuilder s = new StringBuilder();
                //s.Append("<script language=javascript>" + "\n");
                //s.Append("window.opener.refresh();" + "\n");
                //s.Append("window.focus();" + "\n");
                //s.Append("window.opener=null;" + "\n");
                //s.Append("window.close();" + "\n");
                //s.Append("</script>");
                //Type cstype = this.GetType();
                //ClientScriptManager cs = Page.ClientScript;
                //string csname = "ltype";
                //if (!cs.IsStartupScriptRegistered(cstype, csname))
                //    cs.RegisterStartupScript(cstype, csname, s.ToString());
            }
        }
        else
        {
            Response.Write("<script language=javascript>alert('非法参数请求!');this.window.close();</script>");
            Response.End();
        }
    }
    /// <summary>
    ///  添加到明细记录
    /// </summary>
    /// <param name="OrderNo"></param>
    /// <param name="ProductsName"></param>
    /// <param name="ProductsBarCode"></param>
    /// <param name="ProductsPattern"></param>
    /// <param name="ProductsUnits"></param>
    /// <param name="OrderAmount"></param>
    /// <param name="OrderUnitPrice"></param>
    /// <param name="OrderDiscount"></param>
    /// <param name="OrderTotalNet"></param>
    /// <param name="OrderRemarks"></param>
    protected void AddToKnet_Procure_OrdersList_Details(string OrderNo, string ProductsName, string ProductsBarCode, string ProductsPattern, string ProductsUnits, int OrderAmount, decimal OrderUnitPrice, decimal OrderDiscount, decimal OrderTotalNet, string OrderRemarks, decimal HandPrice)
    {
        KNet.BLL.Knet_Procure_OrdersList_Details BLL = new KNet.BLL.Knet_Procure_OrdersList_Details();
        KNet.Model.Knet_Procure_OrdersList_Details model = new KNet.Model.Knet_Procure_OrdersList_Details();

        model.OrderNo = OrderNo;
        model.ProductsName = ProductsName;
        model.ProductsBarCode = ProductsBarCode;
        model.ProductsPattern = ProductsPattern;
        model.ProductsUnits = ProductsUnits;
        model.OrderAmount = OrderAmount;
        model.OrderUnitPrice = OrderUnitPrice;
        model.OrderDiscount = OrderDiscount;
        model.OrderTotalNet = OrderTotalNet;
        model.OrderRemarks = OrderRemarks;
        model.HandPrice = HandPrice;
        model.HandTotal = HandPrice;
        try
        {
            if (BLL.Exists(OrderNo, ProductsBarCode) == false)
            {
                BLL.Add(model);
            }
            else
            {
                BLL.UpdateB(model);
            }
        }
        catch { throw; }
    }
    /// <summary>
    /// 取消所有已选中列
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gr in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gr.Cells[0].FindControl("Chbk");
                chk.Checked = false;
            }
            GridView1.EditIndex = -1;
            this.DataShows();
        }
        catch { }
    }


    /// <summary>
    /// 返回大类名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetBigCateNane(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,BigNo,CateName from KNet_Sys_BigCategories where BigNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["CateName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 返回单位名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetUnitsName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,UnitsNo,UnitsName from KNet_Sys_Units where UnitsNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["UnitsName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click1(object sender, EventArgs e)
    {
        string ProductsMainCategory = this.BigClass.Value;
        string ProductsSmallCategory = this.SmallClass.Value;

        string Seackey = KNetPage.KHtmlEncode(this.SeachKey.Text.Trim());
        Response.Redirect("SelectProductsDictionary.aspx?ProductsMainCategory=" + ProductsMainCategory + "&ProductsSmallCategory=" + ProductsSmallCategory + "&SeachKey=" + Seackey + "&OrderNo=" + Request.QueryString["OrderNo"].Trim() + "&SuppNo=" + Request.QueryString["SuppNo"].Trim() + "&Sn=" + DateTime.Now.ToFileTimeUtc().ToString() + "");
        Response.End();
    }

    /// <summary>
    /// 完成选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button4_Click(object sender, EventArgs e)
    {
        StringBuilder s = new StringBuilder();
        s.Append("<script language=javascript>" + "\n");
        s.Append("window.opener.refresh();" + "\n");
        s.Append("window.focus();" + "\n");
        s.Append("window.opener=null;" + "\n");
        s.Append("window.close();" + "\n");
        s.Append("</script>");
        Type cstype = this.GetType();
        ClientScriptManager cs = Page.ClientScript;
        string csname = "ltype";
        if (!cs.IsStartupScriptRegistered(cstype, csname))
            cs.RegisterStartupScript(cstype, csname, s.ToString());
    }




    /// <summary>
    /// 明细产品绑定
    /// </summary>
    protected void ssdsdDataShows()
    {
        KNet.BLL.Knet_Procure_OrdersList_Details bll = new KNet.BLL.Knet_Procure_OrdersList_Details();
        string SqlWhere = " 1=1 ";

        if (Request.QueryString["OrderNo"] != null && Request.QueryString["OrderNo"] != "")
        {
            string KNetOrderNo = Request.QueryString["OrderNo"].ToString().Trim();
            SqlWhere = SqlWhere + " and  OrderNo = '" + KNetOrderNo + "' ";
        }
        else
        {
            SqlWhere = SqlWhere + " and 2=1 ";
        }
        using (DataSet ds = bll.GetList(SqlWhere))
        {
            //正反排序------
            //DataView dv = ds.Tables[0].DefaultView;
            //string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            //dv.Sort = sort;
            ////--分页-------
            //PagedDataSource pds = new PagedDataSource();
            //AspNetPager1.RecordCount = dv.Count;
            //pds.DataSource = dv;
            //pds.AllowPaging = true;
            //pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            //pds.PageSize = AspNetPager1.PageSize;
            //--End分页-----
            GridView2.DataSource = ds;
            GridView2.DataKeyNames = new string[] { "ID" };
            GridView2.DataBind();
        }
    }



}

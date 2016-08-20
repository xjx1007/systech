﻿using System;
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
/// 选择指定仓库产品
/// </summary>
public partial class Knet_Common_SelectKNet_WareHouse_Ownall : System.Web.UI.Page
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
        this.Page.Title = "仓库产品选择";

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
                if (Request.QueryString["HouseNo"] != null && Request.QueryString["HouseNo"] != "")
                {
                    if (Request.QueryString["DirectOutNo"] != null && Request.QueryString["DirectOutNo"] != "")
                    {


                        ViewState["SortOrder"] = "StorageTime";
                        ViewState["OrderDire"] = "Desc";
                        this.Button2.Attributes.Add("onclick", "return confirm('您确定要把所选择的记录添加到明细记录吗？')");
         
                        this.DataShows();
                        this.RowOverYN();
                        this.DataShowssgsdgd();
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
        KNet.BLL.KNet_WareHouse_Ownall bll = new KNet.BLL.KNet_WareHouse_Ownall();
        string SqlWhere = " WareHouseAmount>0 ";

        if (Request["HouseNo"] != null && Request["HouseNo"] != "" && Request["HouseNo"] != "0")
        {
            string HouseNo = Request.QueryString["HouseNo"].ToString().Trim();
            SqlWhere = SqlWhere + " and  HouseNo = '" + HouseNo + "' ";
        }
        else
        {
            SqlWhere = SqlWhere + " and 1=2 ";
        }

        if (Request["SeachKey"] != null && Request["SeachKey"] != "")
        {
            string KSeachKey = Request.QueryString["SeachKey"].ToString().Trim();
            this.KNetSeachKey.Text = KSeachKey;
            SqlWhere = SqlWhere + " and ( ProductsName like '%" + KSeachKey + "%' or ProductsBarCode  like '%" + KSeachKey + "%' or ProductsPattern  like '%" + KSeachKey + "%' )";
        }

        SqlWhere = SqlWhere + " order by StorageTime desc";


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

    ///// <summary>
    ///// 出库后更新仓库总账信息
    ///// </summary>
    ///// <param name="thisWareHouseAmount">出库数量</param>
    ///// <param name="thisWareHouseTotalNet"></param>
    ///// <param name="thisWareHouseDiscount"></param>
    ///// <param name="HouseNo"></param>
    ///// <param name="ProductsBarCode"></param>
    //protected void UpdateKNet_WareHouse_Ownall(int thisWareHouseAmount, decimal thisWareHouseTotalNet, decimal thisWareHouseDiscount,string ID)
    //{
    //    try
    //    {
    //        string Dosql = "update KNet_WareHouse_Ownall set WareHouseAmount=WareHouseAmount-" + thisWareHouseAmount + ",ShippedQuantity=ShippedQuantity+" + thisWareHouseAmount + ",WareHouseTotalNet=WareHouseTotalNet-" + thisWareHouseTotalNet + ",WareHouseDiscount=WareHouseDiscount-" + thisWareHouseDiscount + " where   ID='" + ID + "'";
    //        DbHelperSQL.ExecuteSql(Dosql);
    //    }
    //    catch { }
    //}
    /// <summary>
    /// 确定选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        KNet.BLL.KNet_WareHouse_Ownall BLL = new KNet.BLL.KNet_WareHouse_Ownall();
        if (Request.QueryString["HouseNo"] != null && Request.QueryString["HouseNo"] != "")
        {
            string cal = "";
            string MyHouseNo = Request.QueryString["HouseNo"].Trim();
            if (Request.QueryString["DirectOutNo"] != null && Request.QueryString["DirectOutNo"] != "")
            {
                string MyDirectOutNo = Request.QueryString["DirectOutNo"].Trim();

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                    TextBox obj2 = (TextBox)GridView1.Rows[i].Cells[0].FindControl("OrderAmounttxt");


                    if (cb.Checked == true)
                    {
                        KNet.Model.KNet_WareHouse_Ownall model = BLL.GetModelB(GridView1.DataKeys[i].Value.ToString());

                        int ThisWareHouseAmount = int.Parse(obj2.Text.ToString()); //本次出货数量

                        if (model != null && int.Parse(model.WareHouseAmount.ToString()) >= 1)
                        {
                            //添加到明细 记录
                            this.AddToKnet_Procure_OrdersList_Details(MyDirectOutNo, model.ProductsName, model.ProductsBarCode, model.ProductsPattern, model.ProductsUnits, ThisWareHouseAmount, decimal.Parse(model.WareHouseTotalNet.ToString()) / int.Parse(model.WareHouseAmount.ToString()), (decimal.Parse(model.WareHouseDiscount.ToString()) / int.Parse(model.WareHouseAmount.ToString())) * ThisWareHouseAmount, (decimal.Parse(model.WareHouseTotalNet.ToString()) / int.Parse(model.WareHouseAmount.ToString())) * ThisWareHouseAmount, "",model.ID);

                            //处理仓库信息
                           // this.UpdateKNet_WareHouse_Ownall(ThisWareHouseAmount, (decimal.Parse(model.WareHouseTotalNet.ToString()) / int.Parse(model.WareHouseAmount.ToString())) * ThisWareHouseAmount, (decimal.Parse(model.WareHouseDiscount.ToString()) / int.Parse(model.WareHouseAmount.ToString())) * ThisWareHouseAmount,GridView1.DataKeys[i].Value.ToString());

                            cal += GridView1.DataKeys[i].Value.ToString();
                        }
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
                    LogAM.Add_Logs("库存管理--->直接出库--->添加明细记录 操作成功！");

                    this.DataShows();
                    this.RowOverYN();
                    this.DataShowssgsdgd();
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
        }
        else
        {
            Response.Write("<script language=javascript>alert('非法参数请求!');this.window.close();</script>");
            Response.End();
        }
    }
    /// <summary>
    /// 添加到直接出库  明细记录 
    /// </summary>
    /// <param name="DirectInNo"></param>
    /// <param name="ProductsName"></param>
    /// <param name="ProductsBarCode"></param>
    /// <param name="ProductsPattern"></param>
    /// <param name="ProductsUnits"></param>
    /// <param name="DirectInAmount"></param>
    /// <param name="DirectInUnitPrice"></param>
    /// <param name="DirectInDiscount"></param>
    /// <param name="DirectInTotalNet"></param>
    /// <param name="DirectInRemarks"></param>
    protected void AddToKnet_Procure_OrdersList_Details(string DirectInNo, string ProductsName, string ProductsBarCode, string ProductsPattern, string ProductsUnits, int DirectInAmount, decimal DirectInUnitPrice, decimal DirectInDiscount, decimal DirectInTotalNet, string DirectInRemarks, string OwnallPID)
    {
        KNet.BLL.KNet_WareHouse_DirectOutList_Details BLL = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
        KNet.Model.KNet_WareHouse_DirectOutList_Details model = new KNet.Model.KNet_WareHouse_DirectOutList_Details();

        model.DirectOutNo = DirectInNo;
        model.ProductsName = ProductsName;
        model.ProductsBarCode = ProductsBarCode;
        model.ProductsPattern = ProductsPattern;
        model.ProductsUnits = ProductsUnits;

        model.DirectOutAmount = DirectInAmount;
        model.DirectOutUnitPrice = DirectInUnitPrice;
        model.DirectOutDiscount = DirectInDiscount;
        model.DirectOutTotalNet = DirectInTotalNet;
        model.DirectOutRemarks = DirectInRemarks;
        model.OwnallPID = OwnallPID;

        try
        {
            if (BLL.Exists(DirectInNo, ProductsBarCode, OwnallPID) == false)
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
    protected void Button3_Click(object sender, EventArgs e)
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
    /// 返回仓库名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetHouseName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,HouseNo,HouseName from KNet_Sys_WareHouse where HouseNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["HouseName"].ToString().Trim();
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
    protected void Button1_Click(object sender, EventArgs e)
    {

        string Seackey = KNetPage.KHtmlEncode(this.KNetSeachKey.Text.Trim());

        Response.Redirect("SelectKNet_WareHouse_Ownall.aspx?SeachKey=" + Seackey + "&HouseNo=" + Request.QueryString["HouseNo"].Trim() + "&DirectOutNo=" + Request.QueryString["DirectOutNo"].Trim() + "&Sn=" + DateTime.Now.ToFileTimeUtc().ToString() + "");
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
    /// 明细产品绑定 （Y）
    /// </summary>
    protected void DataShowssgsdgd()
    {
        KNet.BLL.KNet_WareHouse_DirectOutList_Details bll = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
        string SqlWhere = " 1=1 ";

        if (Request.QueryString["DirectOutNo"] != null && Request.QueryString["DirectOutNo"] != "")
        {
            string KNetOrderNo = Request.QueryString["DirectOutNo"].ToString().Trim();
            SqlWhere = SqlWhere + " and  DirectOutNo = '" + KNetOrderNo + "' ";
        }
        else
        {
            SqlWhere = SqlWhere + " and  2=1 ";
        }
        using (DataSet ds = bll.GetList(SqlWhere))
        {
            GridView2.DataSource = ds;
            GridView2.DataKeyNames = new string[] { "ID" };
            GridView2.DataBind();


        }
    }
}

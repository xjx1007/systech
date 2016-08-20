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
/// 选择   收货单   产品明细
/// </summary>
public partial class Knet_Common_SelectKnet_Procure_WareHouse_AddDetails : BasePage
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
            else
            {
                if (Request.QueryString["ReceivNo"] != null && Request.QueryString["ReceivNo"] != "")
                {
                    if (GetOrderNoEitxt(Request.QueryString["ReceivNo"].ToString()) == true)
                    {
                        if (Request.QueryString["WareHouseNo"] != null && Request.QueryString["WareHouseNo"] != "")
                        {
                            this.GetInfo(Request.QueryString["ReceivNo"].ToString().Trim());


                            ViewState["SortOrder"] = "ProductsBarCode";
                            ViewState["OrderDire"] = "Desc";
                            this.DataShows();

                            this.DShowA.Visible = false;
                            this.DShowB.Visible = false;
                           
                            this.DShowD.Visible = false;
                            this.DShowE.Visible = false;

                            this.ImageButton_down.Visible = true;
                            this.ImageButton_up.Visible = false;
                        }
                        else
                        {
                            Response.Write("<script>alert('非法参数，非法请求！');window.close();</script>");
                            Response.End();
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('原采购单明细记录已不存在！（采购单已删除，请查证）');window.close();</script>");
                        Response.End();
                    }
                }
                else
                {
                    Response.Write("<script>alert('非法参数，非法请求！');window.close();</script>");
                    Response.End();
                }
            }
        }
    }

    /// <summary>
    /// 查看原采购单是否存在
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetOrderNoEitxt(string OrderNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,OrderNo  from Knet_Procure_OrdersList_Details  where OrderNo='" + OrderNo + "'";
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



    /// <summary>
    /// 获取信息
    /// </summary>
    /// <param name="OrderNo"></param>
    protected void GetInfo(string OrderNo)
    {

        KNet.BLL.Knet_Procure_OrdersList BLL = new KNet.BLL.Knet_Procure_OrdersList();
        KNet.Model.Knet_Procure_OrdersList model = BLL.GetModelB(OrderNo);

        this.ReceivNo.Text = model.OrderNo;
        this.ReceivTopic.Text = model.OrderTopic;
        this.ReceivDateTime.Text = DateTime.Parse(model.OrderDateTime.ToString()).ToShortDateString();
        this.OrderNo.Text = model.OrderNo;

        this.SuppNo.Text = base.Base_GetSupplierName(model.SuppNo);
        this.ReceivPaymentNotes.Text = base.Base_GetCheckMethod(model.OrderPaymentNotes);

        this.ReceivStaffBranch.Text = base.Base_GeDept(model.OrderStaffBranch);
        this.ReceivStaffDepart.Text = base.Base_GeDept(model.OrderStaffDepart);


        this.ReceivStaffNo.Text = base.Base_GetUserName(model.OrderStaffNo);
        this.ReceivCheckStaffNo.Text = base.Base_GetUserName(model.OrderCheckStaffNo);
        this.ReceivRemarks.Text = KNetPage.KHtmlDiscode(model.OrderRemarks);
    }


    /// <summary>
    /// 向上UP起来
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageButton_up_Click(object sender, ImageClickEventArgs e)
    {
        this.DShowA.Visible = false;
        this.DShowB.Visible = false;
       
        this.DShowD.Visible = false;
        this.DShowE.Visible = false;
        

        this.ImageButton_down.Visible = true;
        this.ImageButton_up.Visible = false;


    }

     /// <summary>
     /// 向下Down展示
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
    protected void ImageButton_down_Click(object sender, ImageClickEventArgs e)
    {
        this.DShowA.Visible = true;
        this.DShowB.Visible = true;
       
        this.DShowD.Visible = true;
        this.DShowE.Visible = true;
       

        this.ImageButton_down.Visible = false;
        this.ImageButton_up.Visible = true;


    }



    /// <summary>
    /// 明细产品绑定
    /// </summary>
    protected void DataShows()
    {

        KNet.BLL.Knet_Procure_OrdersList_Details bll = new KNet.BLL.Knet_Procure_OrdersList_Details();
        string SqlWhere = " 1=1 ";
        //OrderHaveReceiving<(OrderAmount-OrderHasReturned-OrderHaveReceiving)

        string KNetWareHouseNo = null;
        string KNetReceivNo = null;
        if (Request.QueryString["WareHouseNo"] != null && Request.QueryString["WareHouseNo"] != "")
        {
            KNetWareHouseNo = Request.QueryString["WareHouseNo"].ToString().Trim();
            if (Request.QueryString["ReceivNo"] != null && Request.QueryString["ReceivNo"] != "")
            {
                KNetReceivNo = Request.QueryString["ReceivNo"].ToString().Trim();
                SqlWhere = SqlWhere + " and  OrderNo = '" + KNetReceivNo + "' ";
            }
            else
            {
                Response.Write("<script>alert('非法参数，非法请求！');window.close();</script>");
                Response.End();
            }
        }
        else
        {
            Response.Write("<script>alert('非法参数，非法请求！');window.close();</script>");
            Response.End();
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

            //计价调节 合计
            decimal OrderDiscountAll = 0;
            //净值合计
            decimal OrderTotalNetAll = 0;
            //数量合计
            int OrderAmountALL = 0;
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                DataRowView mydrv = ds.Tables[0].DefaultView[i];

                OrderDiscountAll = OrderDiscountAll + decimal.Parse(mydrv["OrderDiscount"].ToString());
                OrderTotalNetAll = OrderTotalNetAll + decimal.Parse(mydrv["OrderTotalNet"].ToString());
                OrderAmountALL = OrderAmountALL + int.Parse(mydrv["OrderAmount"].ToString());

                this.HeXinQ.Text = "采购数量合计:<B><font color=blue>" + OrderAmountALL.ToString() + "</font></B>&nbsp;&nbsp;&nbsp;净值金额合计:<B><font color=blue>" + OrderTotalNetAll.ToString("N") + "</font></B>&nbsp;&nbsp;&nbsp;调节金额合计:<B><font color=blue>" + OrderDiscountAll.ToString("N") + "</font></B>";
            }

            if (GridView1.Rows.Count == 0) //如果没有记录
            {
                this.Button2.Enabled = false;
                this.Button3.Enabled = false;
            }
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
    }

    /// <summary>
    /// 执行分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object src, EventArgs e)
    {
        this.DataShows();
    }

    /// <summary>
    /// 添加提示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //自动ID号
            int id = (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }

       
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
    /// 确定选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        KNet.BLL.Knet_Procure_OrdersList_Details BLL = new KNet.BLL.Knet_Procure_OrdersList_Details();

        string KnetReceivNo = null;
        string KnetWareHouseNo = null;

        if (Request.QueryString["ReceivNo"] != null && Request.QueryString["ReceivNo"] != "")
        {
            if (Request.QueryString["WareHouseNo"] != null && Request.QueryString["WareHouseNo"] != "")
            {
                string cal = "";
                KnetReceivNo = Request.QueryString["ReceivNo"].ToString().Trim();
                KnetWareHouseNo = Request.QueryString["WareHouseNo"].ToString().Trim();

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                    TextBox obj2 = (TextBox)GridView1.Rows[i].Cells[0].FindControl("OrderAmounttxt");
                   // DropDownList DDL = (DropDownList)GridView1.Rows[i].Cells[0].FindControl("WareHousePack");
                    if (cb.Checked == true)
                    {
                        KNet.Model.Knet_Procure_OrdersList_Details model = BLL.GetModel(GridView1.DataKeys[i].Value.ToString());

                        int RecingProductNum = int.Parse(obj2.Text.ToString()); //退货数量
                        string PackStr = ""; //包装



                        decimal ReceivDiscount = 0; //平均值
                        if (decimal.Parse(model.OrderDiscount.ToString()) != 0)
                        {
                            ReceivDiscount = decimal.Parse(model.OrderDiscount.ToString()) / int.Parse(model.OrderAmount.ToString());
                        }

                        decimal ReceivTotalNet = 0; //平均值
                        if (decimal.Parse(model.OrderTotalNet.ToString()) != 0)
                        {
                            ReceivTotalNet = decimal.Parse(model.OrderTotalNet.ToString()) / int.Parse(model.OrderAmount.ToString());
                        }

                        //添加 入库 明细 记录
                        this.AddToKnet_Procure_ReceivingList_Details(KnetWareHouseNo, model.ProductsName, model.ProductsBarCode, model.ProductsPattern, model.ProductsUnits, RecingProductNum, decimal.Parse(model.OrderUnitPrice.ToString()), ReceivDiscount * RecingProductNum, ReceivTotalNet * RecingProductNum, model.OrderRemarks, PackStr);

                        //增加已入库数
                        string DoSqls = " update Knet_Procure_OrdersList_Details set OrderHaveReceiving=OrderHaveReceiving+" + RecingProductNum + "  where ID='" + GridView1.DataKeys[i].Value.ToString() + "'";
                        DbHelperSQL.ExecuteSql(DoSqls);

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
                    LogAM.Add_Logs("采购入库--->采购入库管理--->添加入库单明细记录 操作成功！");

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
            }
            else
            {
                Response.Write("<script language=javascript>alert('非法参数请求!');this.window.close();</script>");
                Response.End();
            }
        }
    }

    /// <summary>
    ///  添加到入库单 明细记录 （默认添加一个）
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
    protected void AddToKnet_Procure_ReceivingList_Details(string WareHouseNo, string ProductsName, string ProductsBarCode, string ProductsPattern, string ProductsUnits, int WareHouseAmount, decimal WareHouseUnitPrice, decimal WareHouseDiscount, decimal WareHouseTotalNet, string WareHouseRemarks, string WareHousePack)
    {
        KNet.BLL.Knet_Procure_WareHouseList_Details BLL = new KNet.BLL.Knet_Procure_WareHouseList_Details();
        KNet.Model.Knet_Procure_WareHouseList_Details model = new KNet.Model.Knet_Procure_WareHouseList_Details();

        model.WareHouseNo = WareHouseNo;
        model.ProductsName = ProductsName;
        model.ProductsBarCode = ProductsBarCode;
        model.ProductsPattern = ProductsPattern;
        model.ProductsUnits = ProductsUnits;

        model.WareHouseAmount = WareHouseAmount;
        model.WareHouseUnitPrice = WareHouseUnitPrice;
        model.WareHouseRemarks = WareHouseRemarks;

        model.WareHouseDiscount = WareHouseDiscount;
        model.WareHouseTotalNet = WareHouseTotalNet;

        model.WareHousePack = WareHousePack;

        try
        {
            if (BLL.Exists(WareHouseNo, ProductsBarCode) == false)
            {
                BLL.Add(model);
            }
            else
            {
                string Dosql = "UPDATE Knet_Procure_WareHouseList_Details set WareHouseAmount=WareHouseAmount+" + WareHouseAmount + ",WareHouseDiscount=WareHouseDiscount+" + WareHouseDiscount + ",WareHouseTotalNet=WareHouseTotalNet+" + WareHouseTotalNet + " where ProductsBarCode='" + ProductsBarCode + "' and  WareHouseNo='" + WareHouseNo + "' ";
                DbHelperSQL.ExecuteSql(Dosql);
            }
        }
        catch { throw; }
    }

}

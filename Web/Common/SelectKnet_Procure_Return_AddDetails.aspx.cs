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
/// 选择采购单产品明细
/// </summary>
public partial class Knet_Common_SelectKnet_Procure_Return_AddDetails : System.Web.UI.Page
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
        Response.Buffer = true;
        Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
        Response.Expires = 0;
        Response.CacheControl = "no-cache";

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
                if (Request.QueryString["OrderNo"] != null && Request.QueryString["OrderNo"] != "")
                {
                    if (GetOrderNoEitxt(Request.QueryString["OrderNo"].ToString()) == true)
                    {
                        if (Request.QueryString["ReturnNo"] != null && Request.QueryString["ReturnNo"] != "")
                        {
                            this.GetInfo(Request.QueryString["OrderNo"].ToString().Trim());


                            ViewState["SortOrder"] = "ProductsBarCode";
                            ViewState["OrderDire"] = "Desc";
                            this.DataShows();

                            this.DShowA.Visible = false;
                            this.DShowB.Visible = false;
                            this.DShowC.Visible = false;
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
    /// 获取供应商名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetSupplierName(string aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,SuppNo,SuppName from Knet_Procure_Suppliers where SuppNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["SuppName"].ToString();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 获取员工名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetKNet_Resource_StaffName(string aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StaffNo,StaffName from KNet_Resource_Staff where StaffNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["StaffName"].ToString();
            }
            else
            {
                return "--";
            }
        }
    }


    /// <summary>
    /// 获取结算方式
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetKNet_KNet_Sys_CheckMethod(string aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,CheckNo,CheckName from KNet_Sys_CheckMethod where CheckNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["CheckName"].ToString();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 获取公司或部门
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetKNet_KNet_Resource_OrganizationalStructure(string aa)
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
    /// 获取采购类型
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetKNet_KNet_Sys_ProcureTypeName(string aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ProcureTypeValue,ProcureTypeName from KNet_Sys_ProcureType where ProcureTypeValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["ProcureTypeName"].ToString();
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
    /// 获取信息
    /// </summary>
    /// <param name="OrderNo"></param>
    protected void GetInfo(string OrderNo)
    {
        KNet.BLL.Knet_Procure_OrdersList BLL = new KNet.BLL.Knet_Procure_OrdersList();
        KNet.Model.Knet_Procure_OrdersList model = BLL.GetModelB(OrderNo);

        this.OrderNo1.Text = model.OrderNo;
        this.OrderTopic1.Text = model.OrderTopic;
        this.OrderDateTime1.Text = DateTime.Parse(model.OrderDateTime.ToString()).ToShortDateString();


        if (model.OrderPreToDate.ToString().Trim() != "1900-10-10 0:00:00")
        {
            this.OrderPreToDate1.Text = DateTime.Parse(model.OrderPreToDate.ToString()).ToShortDateString();
        }
        else
        {
            this.OrderPreToDate1.Text = "";
        }


        this.SuppNo1.Text = GetSupplierName(model.SuppNo);
        this.OrderPaymentNotes1.Text = GetKNet_KNet_Sys_CheckMethod(model.OrderPaymentNotes);

        this.OrderStaffBranch.Text = GetKNet_KNet_Resource_OrganizationalStructure(model.OrderStaffBranch);
        this.OrderStaffDepart.Text = GetKNet_KNet_Resource_OrganizationalStructure(model.OrderStaffDepart);
        this.OrderTransShare.Text = model.OrderTransShare.ToString();
        this.OrderType.Text = GetKNet_KNet_Sys_ProcureTypeName(model.OrderType);
        this.OrderStaffNotxt.Text = GetKNet_Resource_StaffName(model.OrderStaffNo);
        this.OrderCheckStaffNotxt.Text = GetKNet_Resource_StaffName(model.OrderCheckStaffNo);
        this.OrderRemarks.Text = KNetPage.KHtmlDiscode(model.OrderRemarks);
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
        this.DShowC.Visible = false;
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
        this.DShowC.Visible = true;
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
        string SqlWhere = " (OrderHaveReceiving+OrderHasReturned)<OrderAmount  ";

        string KNetReceivNo = null;
        string KNetOrderNo = null;
        if (Request.QueryString["ReturnNo"] != null && Request.QueryString["ReturnNo"] != "")
        {
            KNetReceivNo = Request.QueryString["ReturnNo"].ToString().Trim();
            if (Request.QueryString["OrderNo"] != null && Request.QueryString["OrderNo"] != "")
            {
                KNetOrderNo = Request.QueryString["OrderNo"].ToString().Trim();
                SqlWhere = SqlWhere + " and  OrderNo = '" + KNetOrderNo + "' ";
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
        string KnetOrderNo = null;

        if (Request.QueryString["ReturnNo"] != null && Request.QueryString["ReturnNo"] != "")
        {
            if (Request.QueryString["OrderNo"] != null && Request.QueryString["OrderNo"] != "")
            {
                string cal = "";
                KnetReceivNo = Request.QueryString["ReturnNo"].ToString().Trim();
                KnetOrderNo = Request.QueryString["OrderNo"].ToString().Trim();

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                    TextBox obj2 = (TextBox)GridView1.Rows[i].Cells[0].FindControl("OrderAmounttxt");

                    if (cb.Checked == true)
                    {
                        KNet.Model.Knet_Procure_OrdersList_Details model = BLL.GetModel(GridView1.DataKeys[i].Value.ToString());

                        int RecingProductNum = int.Parse(obj2.Text.ToString()); //退货数量

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

                        //添加收货明细 记录
                        this.AddToKnet_Procure_ReceivingList_Details(KnetReceivNo, model.ProductsName, model.ProductsBarCode, model.ProductsPattern, model.ProductsUnits, RecingProductNum, decimal.Parse(model.OrderUnitPrice.ToString()), ReceivDiscount * RecingProductNum, ReceivTotalNet * RecingProductNum, model.OrderRemarks);

                        //增加已退货数
                        string DoSqls = " update Knet_Procure_OrdersList_Details set OrderHasReturned=OrderHasReturned+" + RecingProductNum + "  where ID='" + GridView1.DataKeys[i].Value.ToString() + "'";
                        DbHelperSQL.ExecuteSql(DoSqls);

                        //更新采购单为 “退货中”
                        string DoSqlOrder = " update Knet_Procure_OrdersList set OrderState=4 where OrderNo='" + KnetOrderNo + "'";
                        DbHelperSQL.ExecuteSql(DoSqlOrder);


                        cal += GridView1.DataKeys[i].Value.ToString();
                    }
                }

                ///总订单是否完成
                if (UpdateOrderState(KnetOrderNo) == true)
                {
                    //更新采购单为 “已完成”
                    string DoSqlOrder = " update Knet_Procure_OrdersList set OrderState=5 where OrderNo='" + KnetOrderNo + "'";
                    DbHelperSQL.ExecuteSql(DoSqlOrder);
                }


                if (cal == "")
                {
                    Response.Write("<script language=javascript>alert('您没有选择要操作的记录!');this.window.close();</script>");
                    Response.End();
                }
                else
                {
                    AdminloginMess LogAM = new AdminloginMess();
                    LogAM.Add_Logs("采购入库--->采购退货管理--->添加退货单明细记录 操作成功！");

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
    /// 查采购单状态 是否完成
    /// </summary>
    /// <param name="OrderNo"></param>
    protected bool UpdateOrderState(string OrderNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dosql = " select  (Sum(OrderAmount)-Sum(OrderHaveReceiving)-Sum(OrderHasReturned)) as SSum from Knet_Procure_OrdersList_Details where OrderNo='" + OrderNo + "'";
            SqlCommand cmd = new SqlCommand(Dosql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (int.Parse(dr["SSum"].ToString().Trim()) > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
    /// <summary>
    ///  添加到明细记录 （默认添加一个）
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
    protected void AddToKnet_Procure_ReceivingList_Details(string ReceivNo, string ProductsName, string ProductsBarCode, string ProductsPattern, string ProductsUnits, int ReceivAmount, decimal ReceivUnitPrice, decimal ReceivDiscount, decimal ReceivTotalNet, string ReceivRemarks)
    {
        KNet.BLL.Knet_Procure_ReturnList_Details BLL = new KNet.BLL.Knet_Procure_ReturnList_Details();
        KNet.Model.Knet_Procure_ReturnList_Details model = new KNet.Model.Knet_Procure_ReturnList_Details();

        model.ReturnNo = ReceivNo;
        model.ProductsName = ProductsName;
        model.ProductsBarCode = ProductsBarCode;
        model.ProductsPattern = ProductsPattern;
        model.ProductsUnits = ProductsUnits;
        model.ReturnAmount = ReceivAmount;
        model.ReturnUnitPrice = ReceivUnitPrice;
        model.ReturnRemarks = ReceivRemarks;

        model.ReturnDiscount = ReceivDiscount;
        model.ReturnTotalNet = ReceivTotalNet;
       

        try
        {
            if (BLL.Exists(ReceivNo, ProductsBarCode) == false)
            {
                BLL.Add(model);
            }
            else
            {
                string Dosql = "UPDATE Knet_Procure_ReturnList_Details set ReturnAmount=ReturnAmount+" + ReceivAmount + ",ReturnDiscount=ReturnDiscount+" + ReceivDiscount + ",ReturnTotalNet=ReturnTotalNet+" + ReceivTotalNet + " where ProductsBarCode='" + ProductsBarCode + "' and  ReturnNo='" + ReceivNo + "' ";
                DbHelperSQL.ExecuteSql(Dosql);
            }
        }
        catch { throw; }
    }

}

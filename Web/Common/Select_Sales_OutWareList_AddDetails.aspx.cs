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
/// 选择发货单产品明细
/// </summary>
public partial class Knet_Common_Select_Sales_OutWareList_AddDetails : BasePage
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        AdminloginMess AMLanguage = new AdminloginMess();
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
                if (Request.QueryString["OutWareNo"] != null && Request.QueryString["OutWareNo"] != "")
                {
                    if (GetContractNoEitxt(Request.QueryString["OutWareNo"].ToString()) == true)
                    {
                        if (Request.QueryString["ReturnNo"] != null && Request.QueryString["ReturnNo"] != "")
                        {
                            this.GetInfo(Request.QueryString["OutWareNo"].ToString().Trim());


                            ViewState["SortOrder"] = "ProductsBarCode";
                            ViewState["OrderDire"] = "Desc";
                            this.DataShows();

                            this.AShow.Visible = false;
                            this.BShow.Visible = false;
                            this.CShow.Visible = false;
                            this.DShow.Visible = false;
              

                            this.HShow.Visible = false;
                            this.IShow.Visible = false;
                            this.JShow.Visible = false;

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
                        Response.Write("<script>alert('原发货单明细记录已不存在！（发货单已删除，请查证）');window.close();</script>");
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
    /// 查看原发货单是否存在
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetContractNoEitxt(string OutWareNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,OutWareNo from KNet_Sales_OutWareList  where OutWareNo='" + OutWareNo + "'";
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
    /// 返回客户名称 （Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetCustomerName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,CustomerValue,CustomerName from KNet_Sales_ClientList where CustomerValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["CustomerName"].ToString().Trim();
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
    /// 返回销售基本分类
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetClient_NameName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ClientValue,Client_Name from KNet_Sales_ClientAppseting where ClientValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["Client_Name"].ToString().Trim();
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
    protected void GetInfo(string OutWareNo)
    {
        KNet.BLL.KNet_Sales_OutWareList BLL = new KNet.BLL.KNet_Sales_OutWareList();
        KNet.Model.KNet_Sales_OutWareList model = BLL.GetModelB(OutWareNo);

        this.OutWareNo.Text = model.OutWareNo;
        this.OutWareTopic.Text = model.OutWareTopic;


        this.CustomerValue.Text = GetCustomerName(model.CustomerValue);

 
        if (model.OutWareDateTime.ToString().Trim() != "1900-10-10 0:00:00")
        {
            this.OutWareDateTime.Text = DateTime.Parse(model.OutWareDateTime.ToString()).ToShortDateString();
        }
        else
        {
            this.OutWareDateTime.Text = "";
        }

        this.ContractNo.Text = model.ContractNo;


        this.ContractTranShare.Text = model.ContractTranShare.ToString();
        this.OutWareOursContact.Text = model.OutWareOursContact;
        this.OutWareSideContact.Text = model.OutWareSideContact;
        this.ContractToAddress.Text = model.ContractToAddress;




        this.ContractDeliveMethods.Text = GetClient_NameName(model.ContractDeliveMethods);


        this.OutWareStaffBranch.Text = GetKNet_KNet_Resource_OrganizationalStructure(model.OutWareStaffBranch);
        this.OutWareStaffDepart.Text = GetKNet_KNet_Resource_OrganizationalStructure(model.OutWareStaffDepart);





        this.OutWareStaffNo.Text = GetKNet_Resource_StaffName(model.OutWareStaffNo);


        this.OutWareCheckStaffNo.Text = GetKNet_Resource_StaffName(model.OutWareCheckStaffNo);


        this.OutWareRemarks.Text = KNetPage.KHtmlDiscode(model.OutWareRemarks);
    }

   


    /// <summary>
    /// 向上UP起来
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageButton_up_Click(object sender, ImageClickEventArgs e)
    {
        this.AShow.Visible = false;
        this.BShow.Visible = false;
        this.CShow.Visible = false;
        this.DShow.Visible = false;


        this.HShow.Visible = false;
        this.IShow.Visible = false;
        this.JShow.Visible = false;


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
        this.AShow.Visible = true;
        this.BShow.Visible = true;
        this.CShow.Visible = true;
        this.DShow.Visible = true;


        this.HShow.Visible = true;
        this.IShow.Visible = true;
        this.JShow.Visible = true;

       

        this.ImageButton_down.Visible = false;
        this.ImageButton_up.Visible = true;
    }



    /// <summary>
    /// 明细产品绑定
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sales_OutWareList_Details bll = new KNet.BLL.KNet_Sales_OutWareList_Details();
        string SqlWhere = " OutWareReceiving<OutWareAmount  ";

        string OutWareNo = null;
        string ReturnNo = null;
        if (Request.QueryString["OutWareNo"] != null && Request.QueryString["OutWareNo"] != "")
        {
            OutWareNo = Request.QueryString["OutWareNo"].ToString().Trim();
            if (Request.QueryString["ReturnNo"] != null && Request.QueryString["ReturnNo"] != "")
            {
                ReturnNo = Request.QueryString["ReturnNo"].ToString().Trim();
                SqlWhere = SqlWhere + " and  OutWareNo = '" + OutWareNo + "' ";
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

                OrderDiscountAll = OrderDiscountAll + decimal.Parse(mydrv["OutWare_SalesDiscount"].ToString());
                OrderTotalNetAll = OrderTotalNetAll + decimal.Parse(mydrv["OutWare_SalesTotalNet"].ToString());
                OrderAmountALL = OrderAmountALL + int.Parse(mydrv["OutWareAmount"].ToString());


                this.HeXinQ.Text = "数量合计:<B><font color=blue>" + OrderAmountALL.ToString() + "</font></B>&nbsp;&nbsp;&nbsp;金额合计:<B><font color=blue>" + OrderTotalNetAll.ToString("N") + "</font></B>&nbsp;&nbsp;&nbsp;调价合计:<B><font color=blue>" + OrderDiscountAll.ToString("N") + "</font></B>";
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
        KNet.BLL.KNet_Sales_OutWareList_Details BLL = new KNet.BLL.KNet_Sales_OutWareList_Details();

        string OutWareNo = null;
        string ReturnNo = null;

        if (Request.QueryString["OutWareNo"] != null && Request.QueryString["OutWareNo"] != "")
        {
            if (Request.QueryString["ReturnNo"] != null && Request.QueryString["ReturnNo"] != "")
            {
                string cal = "";
                OutWareNo = Request.QueryString["OutWareNo"].ToString().Trim();
                ReturnNo = Request.QueryString["ReturnNo"].ToString().Trim();

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                    TextBox obj2 = (TextBox)GridView1.Rows[i].Cells[0].FindControl("OrderAmounttxt");

                    if (cb.Checked == true)
                    {
                        KNet.Model.KNet_Sales_OutWareList_Details model = BLL.GetModel(GridView1.DataKeys[i].Value.ToString());
                      
                        cal += GridView1.DataKeys[i].Value.ToString();

                        int ReturnAmount = int.Parse(obj2.Text.ToString()); //本次发货数量

                        string ProductsName = model.ProductsName;
                        string ProductsBarCode = model.ProductsBarCode;
                        string ProductsPattern = model.ProductsPattern;
                        string ProductsUnits = model.ProductsUnits;




                        if (GetCanUpContractState(OutWareNo, ReturnAmount, ProductsBarCode) == false)
                        {
                            decimal ReturnUnitPrice = decimal.Parse(model.OutWareUnitPrice.ToString()); //成本区----单价格
                            decimal ReturnDiscount = 0;//成本区----折扣
                            if (decimal.Parse(model.OutWareDiscount.ToString()) != 0)
                            {
                                ReturnDiscount = (decimal.Parse(model.OutWareDiscount.ToString()) / int.Parse(model.OutWareAmount.ToString())) * ReturnAmount;
                            }
                            decimal ReturnTotalNet = 0;//成本区----净值
                            if (decimal.Parse(model.OutWareTotalNet.ToString()) != 0)
                            {
                                ReturnTotalNet = (decimal.Parse(model.OutWareTotalNet.ToString()) / int.Parse(model.OutWareAmount.ToString())) * ReturnAmount;
                            }



                            decimal Return_SalesUnitPrice = decimal.Parse(model.OutWare_SalesUnitPrice.ToString()); //销售区----单价格
                            decimal Return_SalesDiscount = 0;//销售区----折扣
                            if (decimal.Parse(model.OutWare_SalesDiscount.ToString()) != 0)
                            {
                                Return_SalesDiscount = (decimal.Parse(model.OutWare_SalesDiscount.ToString()) / int.Parse(model.OutWareAmount.ToString())) * ReturnAmount;
                            }
                            decimal Return_SalesTotalNet = 0;//销售区----净值
                            if (decimal.Parse(model.OutWare_SalesTotalNet.ToString()) != 0)
                            {
                                Return_SalesTotalNet = (decimal.Parse(model.OutWare_SalesTotalNet.ToString()) / int.Parse(model.OutWareAmount.ToString())) * ReturnAmount;
                            }

                            string ReturnRemarks = "";


                            //添加退货明细 记录
                            this.AddToKNet_Sales_BaoPriceList_Details(ReturnNo, ProductsName, ProductsBarCode, ProductsPattern, ProductsUnits, ReturnAmount, ReturnUnitPrice, ReturnDiscount, ReturnTotalNet, Return_SalesUnitPrice, Return_SalesDiscount, Return_SalesTotalNet, ReturnRemarks);

                            //更新合同明细上的信息
                            // this.UpdateKNet_WareHouse_Ownall(OutWareAmount, OutWareDiscount, OutWareTotalNet, OutWare_SalesDiscount, OutWare_SalesTotalNet, ContractNo, ProductsBarCode);

                            //增加已退货数
                            string DoSqls = " update KNet_Sales_OutWareList_Details set OutWareReceiving=OutWareReceiving+" + ReturnAmount + "  where ID='" + GridView1.DataKeys[i].Value.ToString() + "'";
                            DbHelperSQL.ExecuteSql(DoSqls);


                            //更新退货状态（0新退货申请，1退货洽谈中，2已终止退货，3已退回归库）
                            string DoSqlOrder = " update KNet_Sales_ReturnList set ReturnState=1  where ReturnNo='" + ReturnNo + "'";
                            DbHelperSQL.ExecuteSql(DoSqlOrder);


                      
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
                    LogAM.Add_Logs("销售管理--->销售退货--->添加退货单明细记录 操作成功！");

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
    /// 发货数量是否大于可发数量
    /// </summary>
    /// <param name="OrderNo"></param>
    protected bool GetCanUpContractState(string OutWareNo, int ThisNum, string ProductsBarCode)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dosql = " select  (OutWareAmount-OutWareReceiving-" + ThisNum + ") as SSum  from KNet_Sales_OutWareList_Details where OutWareNo='" + OutWareNo + "' and  ProductsBarCode='" + ProductsBarCode + "'";
            SqlCommand cmd = new SqlCommand(Dosql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (int.Parse(dr["SSum"].ToString().Trim()) >= 0)
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
    /// 添加到明细记录 （Y）暂不用到
    /// </summary>
    /// <param name="ReturnNo"></param>
    /// <param name="ProductsName"></param>
    /// <param name="ProductsBarCode"></param>
    /// <param name="ProductsPattern"></param>
    /// <param name="ProductsUnits"></param>
    /// <param name="ReturnAmount"></param>
    /// <param name="ReturnUnitPrice"></param>
    /// <param name="ReturnDiscount"></param>
    /// <param name="ReturnTotalNet"></param>
    /// <param name="Return_SalesUnitPrice"></param>
    /// <param name="Return_SalesDiscount"></param>
    /// <param name="Return_SalesTotalNet"></param>
    /// <param name="ReturnRemarks"></param>
    protected void AddToKNet_Sales_BaoPriceList_Details(string ReturnNo, string ProductsName, string ProductsBarCode, string ProductsPattern, string ProductsUnits, int ReturnAmount, decimal ReturnUnitPrice, decimal ReturnDiscount, decimal ReturnTotalNet, decimal Return_SalesUnitPrice, decimal Return_SalesDiscount, decimal Return_SalesTotalNet, string ReturnRemarks)
    {
        KNet.BLL.KNet_Sales_ReturnList_Details BLL = new KNet.BLL.KNet_Sales_ReturnList_Details();
        KNet.Model.KNet_Sales_ReturnList_Details model = new KNet.Model.KNet_Sales_ReturnList_Details();

        model.ReturnNo = ReturnNo;
        model.ProductsName = ProductsName;
        model.ProductsBarCode = ProductsBarCode;
        model.ProductsPattern = ProductsPattern;
        model.ProductsUnits = ProductsUnits;

        model.ReturnAmount = ReturnAmount;

        //成本区
        model.ReturnUnitPrice = ReturnUnitPrice;
        model.ReturnDiscount = ReturnDiscount;
        model.ReturnTotalNet = ReturnTotalNet;

        //销售区
        model.Return_SalesUnitPrice = Return_SalesUnitPrice;
        model.Return_SalesDiscount = Return_SalesDiscount;
        model.Return_SalesTotalNet = Return_SalesTotalNet;

        model.ReturnRemarks = ReturnRemarks;

        try
        {
            if (BLL.Exists(ReturnNo, ProductsBarCode) == false)
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

 
}

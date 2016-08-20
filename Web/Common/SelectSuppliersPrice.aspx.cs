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
public partial class Knet_Common_SelectSuppliersPrice : BasePage
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
        this.Page.Title = "供应商报价选择";

        if (!IsPostBack)
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
                    if (Request.QueryString["SuppNo"] != null && Request.QueryString["SuppNo"] != "")
                    {

                        this.Button2.Attributes.Add("onclick", "return confirm('您确定要把所选择的记录添加到采购明细记录吗？')");

                        this.HyperLink1.NavigateUrl = "SelectSuppliersPrice.aspx?OrderNo=" + Request.QueryString["OrderNo"].Trim() + "&SuppNo=" + Request.QueryString["SuppNo"].Trim() + "&Sn=" + DateTime.Now.ToFileTimeUtc().ToString() + "";
                        this.HyperLink2.NavigateUrl = "SelectProductsDictionary.aspx?OrderNo=" + Request.QueryString["OrderNo"].Trim() + "&SuppNo=" + Request.QueryString["SuppNo"].Trim() + "&Sn=" + DateTime.Now.ToFileTimeUtc().ToString() + "";
                        
                        this.DataShows();
                        this.RowOverYN();
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
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.Knet_Procure_SuppliersPrice bll = new KNet.BLL.Knet_Procure_SuppliersPrice();

        string SqlWhere = " ProcureState=1 ";

        if (Request["SuppNo"] != null && Request["SuppNo"] != "")
        {
            string SuppNo = Request.QueryString["SuppNo"].ToString().Trim();
            SqlWhere = SqlWhere + " and  SuppNo = '" + SuppNo + "' ";
        }

        if (this.SeachKey.Text != "")
        {
            string KSeachKey = this.SeachKey.Text;
            SqlWhere = SqlWhere + " and ( ProductsName like '%" + KSeachKey + "%' or ProductsBarCode  like '%" + KSeachKey + "%' or ProductsPattern  like '%" + KSeachKey + "%' )";
        }
        if (Request["Contract"] != null && Request["Contract"] != "")
        {
            SqlWhere = SqlWhere + " and  ProductsBarCode in (Select ProductsBarCode from KNet_Sales_ContractList_Details Where ContractNo='" + Request["Contract"].ToString()+ "') ";
        }

        if (this.BigClass.Value != "0")
        {
            string KDBList = this.BigClass.Value;
            SqlWhere = SqlWhere + " and  ProductsMainCategory = '" + KDBList + "' ";
        }

        if (this.SmallClass.Value != "0")
        {
            string KDBListSall = this.SmallClass.Value;
            SqlWhere = SqlWhere + " and  ProductsSmallCategory = '" + KDBListSall + "' ";
        }
        DataSet ds = bll.GetList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();
    }
    /// <summary>
    /// 确定选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        KNet.BLL.Knet_Procure_SuppliersPrice BLL = new KNet.BLL.Knet_Procure_SuppliersPrice();
        if (Request.QueryString["OrderNo"] != null && Request.QueryString["OrderNo"] != "")
        {
            string cal = "";
            string MyOrderNo = Request.QueryString["OrderNo"].Trim();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (cb.Checked == true)
                {
                    KNet.Model.Knet_Procure_SuppliersPrice model = BLL.GetModel(GridView1.DataKeys[i].Value.ToString());
                    int s_Number = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Number")).Text == "" ? 1 : int.Parse(((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Number")).Text);
                    
                    //添加记录
                    this.AddToKnet_Procure_OrdersList_Details(MyOrderNo, model.ProductsName, model.ProductsBarCode, model.ProductsPattern, model.ProductsUnits, s_Number, decimal.Parse(model.ProcureUnitPrice.ToString()), 0, s_Number * decimal.Parse(model.ProcureUnitPrice.ToString()),"",decimal.Parse(model.HandPrice.ToString()));

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
    protected void AddToKnet_Procure_OrdersList_Details(string OrderNo, string ProductsName, string ProductsBarCode, string ProductsPattern, string ProductsUnits, int OrderAmount, decimal OrderUnitPrice, decimal OrderDiscount, decimal OrderTotalNet, string OrderRemarks ,decimal HandPrice)
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
        model.HandTotal = HandPrice * OrderAmount;

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
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click1(object sender, EventArgs e)
    {
        this.DataShows();
        this.RowOverYN();
    }
    public string GetNumber(string s_ProductsBarCode)
    {
        if (Request["Contract"] != null && Request["Contract"] != "")
        {
            this.BeginQuery("Select (ContractAmount+isnull(KSC_BNumber,0)) From KNet_Sales_ContractList_Details Where ContractNo='" + Request["Contract"] + "' and ProductsBarCode='" + s_ProductsBarCode + "'");
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                return Dtb_Result.Rows[0][0].ToString();
            }
            else
            {
                return "0";
            }
        }
        else
        {
            return "0";
        }
    }

}

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

using KNet.DBUtility;
using KNet.Common;


/// <summary>
/// 采购管理-----供应商报价管理---添加
/// </summary>
public partial class Knet_Web_Procure_Knet_Procure_Suppliers_Price_Add : BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ProductsBarCode = Request.QueryString["ProductsBarCode"] == null ? "" : Request.QueryString["ProductsBarCode"].ToString();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                if (s_ProductsBarCode != "")
                {
                    KNet.BLL.Knet_Procure_SuppliersPrice Bll_Price = new KNet.BLL.Knet_Procure_SuppliersPrice();
                    DataSet Dts_PriceTable = Bll_Price.GetTop("  ProductsBarCode='" + s_ProductsBarCode + "' ");
                    if (Dts_PriceTable.Tables[0].Rows.Count > 0)
                    {
                        this.KNetSelectValue.Value = Dts_PriceTable.Tables[0].Rows[0]["SuppNo"].ToString();
                        this.KNetSelectName.Text = base.Base_GetSupplierName(Dts_PriceTable.Tables[0].Rows[0]["SuppNo"].ToString());
                    }

                }
                ViewState["SortOrder"] = "ProductsAddTime";
                ViewState["OrderDire"] = "Desc";
                this.DataShows();


            }
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sys_Products bll = new KNet.BLL.KNet_Sys_Products();
        string SqlWhere = " 1=1 ";
        string s_ProductsBarCode = Request.QueryString["ProductsBarCode"] == null ? "" : Request.QueryString["ProductsBarCode"].ToString();

        if (s_ProductsBarCode != "")
        {
            SqlWhere = SqlWhere + " and ProductsBarCode='" + s_ProductsBarCode + "'";
        }
        if (this.Tbx_ProductsEdition.Text != "")
        {
            SqlWhere = SqlWhere + " and ProductsEdition like '%" + this.Tbx_ProductsEdition.Text + "%'";
        }

        if (this.Tbx_Code.Text != "")
        {
            SqlWhere = SqlWhere + " and KSP_Code like '%" + this.Tbx_Code.Text + "%'";
        }

        if (this.Tbx_ProductsTypeNo.Text != "")
        {
            KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
            string s_SonID = Bll_ProductsDetails.GetSonIDs(this.Tbx_ProductsTypeNo.Text);
            s_SonID = s_SonID.Replace(",", "','");
            SqlWhere += " and ProductsType in ('" + s_SonID + "') ";
        }

        DataSet ds = bll.GetList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();

    }



    /// <summary>
    /// 检查此供应商是否存在
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetSupplierYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,SuppNo,SuppName from Knet_Procure_Suppliers where SuppNo='" + aa + "'";
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
    /// 检查此产品在些供应商里是否已有报价 
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetSuppliersPriceYN(string SuppNo, string ProductsBarCode)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,SuppNo,ProductsBarCode from Knet_Procure_SuppliersPrice  where KPP_Del='0' and SuppNo='" + SuppNo + "' and ProductsBarCode='" + ProductsBarCode + "'";
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
    /// 确定设置价格
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// 

    protected void Button4_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string SuppNoStr = this.KNetSelectValue.Value;

        if (GetSupplierYN(SuppNoStr) == false)
        {
            Response.Write("<script language=javascript>alert('您没有选择供应商或是选择出错，请重新选择供应商!');history.back(-1);</script>");
            Response.End();
        }
        else
        {
            string cal = "";
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                TextBox TboxxMinShu = (TextBox)GridView1.Rows[i].Cells[7].FindControl("ProcureMinShu");
                TextBox TboxxPrice = (TextBox)GridView1.Rows[i].Cells[8].FindControl("ProcureUnitPrice");
                TextBox Salespricess = (TextBox)GridView1.Rows[i].Cells[8].FindControl("Salesprice");
                TextBox HandPrice = (TextBox)GridView1.Rows[i].Cells[9].FindControl("HandPrice");
                TextBox KPP_Remarks = (TextBox)GridView1.Rows[i].Cells[9].FindControl("Tbx_Remarks");
                CheckBox Chk_IsChangAll = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chk_IsChangAll");

                if (cb.Checked == true)
                {

                    int ProcureMinShu = int.Parse(TboxxMinShu.Text.ToString());
                    decimal ProcureUnitPrice = decimal.Parse(TboxxPrice.Text.ToString());
                    decimal Salespricess77 = decimal.Parse(Salespricess.Text.ToString());
                    decimal d_HandPrice = decimal.Parse(HandPrice.Text.ToString());
                    string s_KPP_Remarks = KPP_Remarks.Text.ToString();
                    KNet.BLL.KNet_Sys_Products BLL = new KNet.BLL.KNet_Sys_Products();
                    KNet.Model.KNet_Sys_Products model = BLL.GetModel(GridView1.DataKeys[i].Value.ToString());

                    if (GetSuppliersPriceYN(SuppNoStr, model.ProductsBarCode) == false)
                    {
                        if (this.AddToSuppliersPrice(SuppNoStr, model.ProductsName, model.ProductsBarCode, model.ProductsPattern, model.ProductsMainCategory, model.ProductsSmallCategory, model.ProductsUnits, ProcureMinShu, ProcureUnitPrice, Salespricess77, d_HandPrice, s_KPP_Remarks, Chk_IsChangAll.Checked))
                        {

                            cal += " ID='" + GridView1.DataKeys[i].Value.ToString() + "' ";

                        }
                    }
                    else
                    {
                        //先删除原先的
                        if (Chk_IsStop.Checked)
                        {
                            KNet.BLL.Knet_Procure_SuppliersPrice BLL1 = new KNet.BLL.Knet_Procure_SuppliersPrice();
                            KNet.Model.Knet_Procure_SuppliersPrice model1 = new KNet.Model.Knet_Procure_SuppliersPrice();
                            model1.ProductsBarCode = model.ProductsBarCode;
                            model1.SuppNo = SuppNoStr;
                            BLL1.DeleteBYModel(model1);
                        }
                        if (this.AddToSuppliersPrice(SuppNoStr, model.ProductsName, model.ProductsBarCode, model.ProductsPattern, model.ProductsMainCategory, model.ProductsSmallCategory, model.ProductsUnits, ProcureMinShu, ProcureUnitPrice, Salespricess77, d_HandPrice, s_KPP_Remarks, Chk_IsChangAll.Checked))
                        {
                            cal += " ID='" + GridView1.DataKeys[i].Value.ToString() + "' ";
                        }

                    }
                }
            }
            if (cal == "")
            {
                Response.Write("<script language=javascript>alert('您没有选择要设置价格的产品记录!');history.back(-1);</script>");
                Response.End();
            }
            else
            {
                AdminloginMess AMlog = new AdminloginMess();
                AMlog.Add_Logs("采购入库--->供应商管理-->供应商报价设置 成功!");

                Response.Write("<script>alert('供应商报价设置成功！点 确定 返回');location.href = 'Knet_Procure_Suppliers_Price.aspx';</script>");
                Response.End();
            }
        }
    }

    /// <summary>
    /// 添加到供应商报价表
    /// </summary>
    /// <param name="SuppNo"></param>
    /// <param name="ProductsName"></param>
    /// <param name="ProductsBarCode"></param>
    /// <param name="ProductsPattern"></param>
    /// <param name="ProductsMainCategory"></param>
    /// <param name="ProductsSmallCategory"></param>
    /// <param name="ProductsUnits"></param>
    /// <param name="ProcureMinShu"></param>
    /// <param name="ProcureUnitPrice"></param>
    protected bool AddToSuppliersPrice(string SuppNo, string ProductsName, string ProductsBarCode, string ProductsPattern, string ProductsMainCategory, string ProductsSmallCategory, string ProductsUnits, int ProcureMinShu, decimal ProcureUnitPrice, decimal Salesprice, decimal d_HandPrice, string s_KPP_Remarks, bool IsChanage)
    {
        KNet.BLL.Knet_Procure_SuppliersPrice BLL = new KNet.BLL.Knet_Procure_SuppliersPrice();
        KNet.Model.Knet_Procure_SuppliersPrice model = new KNet.Model.Knet_Procure_SuppliersPrice();

        model.SuppNo = SuppNo;
        model.ProductsName = ProductsName;
        model.ProductsBarCode = ProductsBarCode;
        model.ProductsPattern = ProductsPattern;
        model.ProductsMainCategory = ProductsMainCategory;
        model.ProductsSmallCategory = ProductsSmallCategory;
        model.ProductsUnits = ProductsUnits;
        model.ProcureMinShu = ProcureMinShu;
        model.ProcureUnitPrice = ProcureUnitPrice;
        model.ProcureState = 1;
        model.ProcureUpdateDateTime = DateTime.Now;
        model.Salesprice = Salesprice;
        model.HandPrice = d_HandPrice;
        model.KPP_Remarks = s_KPP_Remarks;
        try
        {
            if (IsChanage)// 同时修改配件
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("Update Xs_Products_Prodocts Set XPP_Price='" + ProcureUnitPrice + "' ");
                strSql.Append(" where XPP_ProductsBarCode=@XPP_ProductsBarCode and XPP_SuppNo=@XPP_SuppNo ");
                SqlParameter[] parameters = {
					new SqlParameter("@XPP_ProductsBarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@XPP_SuppNo", SqlDbType.NVarChar,50)			};
                parameters[0].Value = ProductsBarCode;
                parameters[1].Value = SuppNo;
                int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
            BLL.Add(model);
            return true;
        }
        catch
        {
            throw;
            return false;
        }
    }
    public string GetProductsPrice(string s_ProductsBarCode, int i_Type)
    {

        string s_Price = "";
        try
        {
            KNet.BLL.Knet_Procure_SuppliersPrice BLL = new KNet.BLL.Knet_Procure_SuppliersPrice();
            KNet.Model.Knet_Procure_SuppliersPrice model = BLL.GetModelByProductsBarCode(s_ProductsBarCode);
            if (i_Type == 0)//单价
            {
                s_Price = model.ProcureUnitPrice.ToString();
            }
            else if (i_Type == 1)//加工费
            {
                s_Price = model.HandPrice.ToString();

            }
            else
            {
                s_Price = model.Salesprice.ToString();
            }
        }
        catch (Exception ex)
        {
        }
        return s_Price == "" ? "0" : s_Price;
    }
}

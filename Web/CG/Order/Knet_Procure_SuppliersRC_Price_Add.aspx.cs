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
public partial class Knet_Web_Procure_Knet_Procure_SuppliersRC_Price_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Lbl_Title.Text = "新增BOM报价";
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
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


                ViewState["SortOrder"] = "ProductsAddTime";
                ViewState["OrderDire"] = "Desc";
                string s_ProductsBarCode=Request["ProductsBarCode"]==null?"":Request["ProductsBarCode"].ToString();
                string s_ID=Request["ID"]==null?"":Request["ID"].ToString();
                if (this.Tbx_ID.Text != "")
                {
                    this.Tbx_ID.Text = s_ID;
                }
                if(s_ProductsBarCode!="")
                {
                    this.Tbx_RcProductsBarCode.Text = s_ProductsBarCode;
                    this.Tbx_RcProductsName.Text = base.Base_GetProductsEdition(s_ProductsBarCode);
                }
                this.DataShows();
                

            }
        }
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
            DropDownList Ddl_SuppNo = (DropDownList)e.Row.Cells[0].FindControl("Ddl_SuppNo");
            TextBox Tbx_ProductsBarCode = (TextBox)e.Row.Cells[0].FindControl("Tbx_ProductsBarCode");
            string s_ProductsBarCode = Tbx_ProductsBarCode.Text;
            KNet.BLL.Knet_Procure_Suppliers Bll = new KNet.BLL.Knet_Procure_Suppliers();
            DataSet Dts_Table = Bll.GetList(" 1=1  order by SuppName");
            Ddl_SuppNo.DataSource = Dts_Table;
            Ddl_SuppNo.DataTextField = "SuppName";
            Ddl_SuppNo.DataValueField = "SuppNo";
            Ddl_SuppNo.DataBind();
            if (s_ProductsBarCode != "")
            {
                KNet.BLL.Xs_Products_Prodocts_Demo Bll_Products = new KNet.BLL.Xs_Products_Prodocts_Demo();
                KNet.Model.Xs_Products_Prodocts_Demo Model = Bll_Products.GetModelByProducts(s_ProductsBarCode, this.Tbx_RcProductsBarCode.Text);
                TextBox Tbx_ProcureUnitPrice = (TextBox)e.Row.Cells[0].FindControl("ProcureUnitPrice");
                TextBox Tbx_HandPrice = (TextBox)e.Row.Cells[0].FindControl("HandPrice");
                TextBox Tbx_Remarks = (TextBox)e.Row.Cells[0].FindControl("Tbx_Remarks");
                TextBox Tbx_Number = (TextBox)e.Row.Cells[0].FindControl("Tbx_Number");
                CheckBox Chb_IsOrder = (CheckBox)e.Row.Cells[0].FindControl("Chb_IsOrder");
                RadioButton Rbtn1 = (RadioButton)e.Row.Cells[0].FindControl("RadioButton1");
                RadioButton Rbtn2 = (RadioButton)e.Row.Cells[0].FindControl("RadioButton2");
                if (Model != null)
                {
                    KNet.BLL.Knet_Procure_SuppliersPrice Bll_Price = new KNet.BLL.Knet_Procure_SuppliersPrice();
                    DataSet Dts_PriceTable = Bll_Price.GetTop("  ProductsBarCode='" + s_ProductsBarCode + "' ");
                    if (Dts_PriceTable.Tables[0].Rows.Count > 0)
                    {
                        Tbx_ProcureUnitPrice.Text = Dts_PriceTable.Tables[0].Rows[0]["ProcureUnitPrice"].ToString();
                        Tbx_HandPrice.Text = Dts_PriceTable.Tables[0].Rows[0]["HandPrice"].ToString();
                        Tbx_Remarks.Text = Dts_PriceTable.Tables[0].Rows[0]["KPP_Remarks"].ToString();
                        Tbx_Number.Text = Dts_PriceTable.Tables[0].Rows[0]["KPP_Number"].ToString()=="0"?"1":Dts_PriceTable.Tables[0].Rows[0]["KPP_Number"].ToString();
                        if (Tbx_Number.Text == "0")
                        {
                            Tbx_Number.Text = "1";
                        }
                        if (Dts_PriceTable.Tables[0].Rows[0]["KPP_IsOrder"].ToString() == "是")
                        {
                            Chb_IsOrder.Checked = true;
                        }
                        else
                        {
                            Chb_IsOrder.Checked = false;
                        }
                        if (Dts_PriceTable.Tables[0].Rows[0]["KPP_Address"].ToString() == "1")
                        {
                            Rbtn2.Checked = true;
                        }
                        else
                        {
                            Rbtn1.Checked = true;
                        }
                        Ddl_SuppNo.SelectedValue = Dts_PriceTable.Tables[0].Rows[0]["SuppNo"].ToString();
                    }
                }
            }

        }
    }
    /// <summary>
    /// 添加提示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void MyGridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string s_ProductsBarCode = MyGridView1.DataKeys[e.Row.RowIndex].Value.ToString();
            DropDownList Ddl_SuppNo = (DropDownList)e.Row.Cells[0].FindControl("Ddl_SuppNo");
            TextBox Tbx_ProcureUnitPrice = (TextBox)e.Row.Cells[0].FindControl("ProcureUnitPrice");
            TextBox Tbx_HandPrice = (TextBox)e.Row.Cells[0].FindControl("HandPrice");
            TextBox Tbx_Remarks = (TextBox)e.Row.Cells[0].FindControl("Tbx_Remarks");
            
            KNet.BLL.Knet_Procure_Suppliers Bll = new KNet.BLL.Knet_Procure_Suppliers();
            DataSet Dts_Table = Bll.GetList("  KPS_Type='128860698200781250' ");
            Ddl_SuppNo.DataSource = Dts_Table;
            Ddl_SuppNo.DataTextField = "SuppName";
            Ddl_SuppNo.DataValueField = "SuppNo";
            Ddl_SuppNo.DataBind();
            KNet.BLL.Knet_Procure_SuppliersPrice Bll_Price = new KNet.BLL.Knet_Procure_SuppliersPrice();
            DataSet Dts_PriceTable = Bll_Price.GetList("  ProductsBarCode='" + s_ProductsBarCode + "' Order by ProcureUpdateDateTime desc");
            if (Dts_PriceTable.Tables[0].Rows.Count > 0)
            {
                Tbx_ProcureUnitPrice.Text = Dts_PriceTable.Tables[0].Rows[0]["ProcureUnitPrice"].ToString();
                Tbx_HandPrice.Text = Dts_PriceTable.Tables[0].Rows[0]["HandPrice"].ToString();
                Tbx_Remarks.Text = Dts_PriceTable.Tables[0].Rows[0]["KPP_Remarks"].ToString();
                Ddl_SuppNo.SelectedValue = Dts_PriceTable.Tables[0].Rows[0]["SuppNo"].ToString();
            }
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sys_Products bll = new KNet.BLL.KNet_Sys_Products();
        string SqlWhere = " KSP_Del=0 ";
        string s_Where = "";
        if (Request["SeachKey"] != null && Request["SeachKey"] != "")
        {
            string KSeachKey = Request.QueryString["SeachKey"].ToString().Trim();
            if (KSeachKey == "") { KSeachKey = null; }
            this.SeachKey.Text = KSeachKey;

            SqlWhere = SqlWhere + " and ( ProductsName like '%" + KSeachKey + "%' or ProductsBarCode  like '%" + KSeachKey + "%' or ProductsPattern  like '%" + KSeachKey + "%' )";
        }
        if (this.Tbx_RcProductsBarCode.Text != "")
        {
            s_Where = " and ProductsBarCode in ( Select XPD_ProductsBarCode From Xs_Products_Prodocts_Demo a join KNET_Sys_Products b on a.XPD_ProductsBarCode=b.ProductsBarCode Where  KSP_Del=0 and XPD_FaterBarCode='" + this.Tbx_RcProductsBarCode.Text + "')  ";
        }
        if (Request["ProductsMainCategory"] != null && Request["ProductsMainCategory"] != "" && Request["ProductsMainCategory"] != "0")
        {
            string KDBList = Request.QueryString["ProductsMainCategory"].ToString().Trim();
            this.BigClass.Value = KDBList;
            SqlWhere = SqlWhere + " and  ProductsMainCategory = '" + KDBList + "' ";
        }
        DataSet ds = bll.GetListByOrder(SqlWhere + s_Where+" Order by ProductsName ");
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ProductsBarCode" };
        GridView1.DataBind();

        if (this.Tbx_RcProductsBarCode.Text != "")
        {
            s_Where = " and ProductsBarCode='" + this.Tbx_RcProductsBarCode.Text + "'";
        }
        DataSet ds2 = bll.GetList(SqlWhere + s_Where);
        MyGridView1.DataSource = ds2;
        MyGridView1.DataKeyNames = new string[] { "ProductsBarCode" };
        MyGridView1.DataBind();

    }

    /// <summary>
    /// 产品搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button4_Click(object sender, EventArgs e)
    {
        string ProductsMainCategory = this.BigClass.Value;
        string Seackey = KNetPage.KHtmlEncode(this.SeachKey.Text.Trim());

        Response.Redirect("Knet_Procure_SuppliersRC_Price_Add.aspx?ProductsMainCategory=" + ProductsMainCategory + "&ProductsBarCode="+this.Tbx_RcProductsBarCode.Text+"&SeachKey=" + Seackey + "");
        Response.End();
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string cal = "";
            AdminloginMess AM=new AdminloginMess();
            KNet.Model.Cg_Suppliers_Price Model_Cg = new KNet.Model.Cg_Suppliers_Price();
            KNet.BLL.Cg_Suppliers_Price BLL_Cg = new KNet.BLL.Cg_Suppliers_Price();
            if (this.Tbx_ID.Text != "")
            {
                Model_Cg.CSP_ID = this.Tbx_ID.Text;
            }
            else
            {
                Model_Cg.CSP_ID = base.GetNewID("Cg_Suppliers_Price",1);
            }
            if (this.Tbx_RcProductsBarCode.Text == "")
            {
                Alert("请选择成品！");
            }
            Model_Cg.CSP_ProductsBarCode = this.Tbx_RcProductsBarCode.Text;
            Model_Cg.CSP_ProductsMainType=this.BigClass.Value;
            Model_Cg.CSP_SerchKey=this.SeachKey.Text;
            Model_Cg.CSP_Creator = AM.KNet_StaffNo;
            Model_Cg.CSP_CTime = DateTime.Now;
            Model_Cg.CSP_Mender = AM.KNet_StaffNo;
            Model_Cg.CSP_MTime = DateTime.Now;
            //成品
            for (int i = 0; i < this.MyGridView1.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
                TextBox TboxxMinShu = (TextBox)MyGridView1.Rows[i].Cells[7].FindControl("ProcureMinShu");
                TextBox TboxxPrice = (TextBox)MyGridView1.Rows[i].Cells[8].FindControl("ProcureUnitPrice");
                TextBox Salespricess = (TextBox)MyGridView1.Rows[i].Cells[8].FindControl("Salesprice");
                TextBox HandPrice = (TextBox)MyGridView1.Rows[i].Cells[9].FindControl("HandPrice");
                TextBox KPP_Remarks = (TextBox)MyGridView1.Rows[i].Cells[9].FindControl("Tbx_Remarks");



                DropDownList Ddl_SuppNo = (DropDownList)MyGridView1.Rows[i].Cells[9].FindControl("Ddl_SuppNo");
                if (cb.Checked == true)
                {
                    int ProcureMinShu = int.Parse(TboxxMinShu.Text.ToString());
                    decimal ProcureUnitPrice = decimal.Parse(TboxxPrice.Text.ToString());
                    decimal Salespricess77 = decimal.Parse(Salespricess.Text.ToString());
                    decimal d_HandPrice = decimal.Parse(HandPrice.Text.ToString());
                    string s_KPP_Remarks = KPP_Remarks.Text.ToString();
                    string s_KPP_ID = Model_Cg.CSP_ID;
                    KNet.BLL.KNet_Sys_Products BLL = new KNet.BLL.KNet_Sys_Products();
                    KNet.Model.KNet_Sys_Products model = BLL.GetModelB(MyGridView1.DataKeys[i].Value.ToString());

                    if ((ProcureUnitPrice > 0)||(d_HandPrice>0))
                    {
                        if (GetSuppliersPriceYN(Ddl_SuppNo.SelectedValue, model.ProductsBarCode) == false)
                        {
                            if (this.AddToSuppliersPrice(Ddl_SuppNo.SelectedValue, model.ProductsName, model.ProductsBarCode, model.ProductsPattern, model.ProductsMainCategory, model.ProductsSmallCategory, model.ProductsUnits, ProcureMinShu, ProcureUnitPrice, Salespricess77, d_HandPrice, s_KPP_Remarks, s_KPP_ID, "", "", 1))
                            {
                                try
                                {
                                    cal += " ID='" + GridView1.DataKeys[i].Value.ToString() + "' ";
                                }
                                catch
                                {
                                    cal += " ID='" + MyGridView1.DataKeys[i].Value.ToString() + "' ";
                                }
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
                                model1.SuppNo = Ddl_SuppNo.SelectedValue;
                                BLL1.DeleteBYModel(model1);
                            }
                            if (this.AddToSuppliersPrice(Ddl_SuppNo.SelectedValue, model.ProductsName, model.ProductsBarCode, model.ProductsPattern, model.ProductsMainCategory, model.ProductsSmallCategory, model.ProductsUnits, ProcureMinShu, ProcureUnitPrice, Salespricess77, d_HandPrice, s_KPP_Remarks, s_KPP_ID, "", "", 1))
                            {
                                try
                                {
                                    cal += " ID='" + GridView1.DataKeys[i].Value.ToString() + "' ";
                                }
                                catch
                                {
                                    cal += " ID='" + MyGridView1.DataKeys[i].Value.ToString() + "' ";
                                }

                            }
                        }
                    }
                    else
                    {
                        Alert("价格不能为0！");
                    }
                }
            }

            //删除该产品的配件
            KNet.BLL.Xs_Products_Prodocts BLL_Products_Prodocts = new KNet.BLL.Xs_Products_Prodocts();
            BLL_Products_Prodocts.Delete(this.Tbx_RcProductsBarCode.Text);

            //配件
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                TextBox TboxxMinShu = (TextBox)GridView1.Rows[i].Cells[7].FindControl("ProcureMinShu");
                TextBox TboxxPrice = (TextBox)GridView1.Rows[i].Cells[8].FindControl("ProcureUnitPrice");
                TextBox Salespricess = (TextBox)GridView1.Rows[i].Cells[8].FindControl("Salesprice");
                TextBox HandPrice = (TextBox)GridView1.Rows[i].Cells[9].FindControl("HandPrice");
                TextBox KPP_Remarks = (TextBox)GridView1.Rows[i].Cells[9].FindControl("Tbx_Remarks");
                TextBox Tbx_Number = (TextBox)GridView1.Rows[i].Cells[9].FindControl("Tbx_Number");
                DropDownList Ddl_SuppNo = (DropDownList)GridView1.Rows[i].Cells[9].FindControl("Ddl_SuppNo");

                //TextBox OldHandPrice = (TextBox)MyGridView1.Rows[i].Cells[9].FindControl("OldHandPrice");
                //TextBox OldProcureUnitPrice = (TextBox)MyGridView1.Rows[i].Cells[9].FindControl("OldProcureUnitPrice");

                CheckBox Chb_IsOrder = ((CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chb_IsOrder"));
                RadioButton Rbtn1 = ((RadioButton)GridView1.Rows[i].Cells[0].FindControl("RadioButton1"));
                RadioButton Rbtn2 = ((RadioButton)GridView1.Rows[i].Cells[0].FindControl("RadioButton2"));
                
                if (cb.Checked == true)
                {
                    int ProcureMinShu = int.Parse(TboxxMinShu.Text.ToString());
                    decimal ProcureUnitPrice = decimal.Parse(TboxxPrice.Text.ToString());
                    decimal Salespricess77 = decimal.Parse(Salespricess.Text.ToString());
                    decimal d_HandPrice = decimal.Parse(HandPrice.Text.ToString());
                    string s_KPP_Remarks = KPP_Remarks.Text.ToString();
                    string s_KPP_ID = Model_Cg.CSP_ID;
                    KNet.BLL.KNet_Sys_Products BLL = new KNet.BLL.KNet_Sys_Products();
                    KNet.Model.KNet_Sys_Products model = BLL.GetModelB(GridView1.DataKeys[i].Value.ToString());

                    KNet.Model.Xs_Products_Prodocts Model_Products_Prodocts = new KNet.Model.Xs_Products_Prodocts();
                    Model_Products_Prodocts.XPP_ID = base.GetNewID("Xs_Products_Prodocts", 1);
                    try
                    {
                        Model_Products_Prodocts.XPP_Number = int.Parse(Tbx_Number.Text);
                    }
                    catch { }
                    Model_Products_Prodocts.XPP_CgID = Model_Cg.CSP_ID;
                    Model_Products_Prodocts.XPP_ProductsBarCode = model.ProductsBarCode;
                    try
                    {
                        Model_Products_Prodocts.XPP_Price = decimal.Parse(TboxxPrice.Text);
                    }
                    catch { }
                    Model_Products_Prodocts.XPP_SuppNo = Ddl_SuppNo.SelectedValue;
                    Model_Products_Prodocts.XPP_FaterBarCode = this.Tbx_RcProductsBarCode.Text;
                    if (Chb_IsOrder.Checked)
                    {
                        Model_Products_Prodocts.XPP_IsOrder = "是";
                    }
                    else
                    {
                        Model_Products_Prodocts.XPP_IsOrder = "否";
                    }
                    if (Rbtn1.Checked)
                    {
                        Model_Products_Prodocts.XPP_Address = "0";
                    }
                    else
                    {
                        Model_Products_Prodocts.XPP_Address = "1";
                    }
                    try
                    {
                        BLL_Products_Prodocts.Add(Model_Products_Prodocts);
                    }
                    catch
                    { }
                    if (ProcureUnitPrice > 0)
                    {
                        if (GetSuppliersPriceYN(Ddl_SuppNo.SelectedValue, model.ProductsBarCode) == false)
                        {
                            if (this.AddToSuppliersPrice(Ddl_SuppNo.SelectedValue, model.ProductsName, model.ProductsBarCode, model.ProductsPattern, model.ProductsMainCategory, model.ProductsSmallCategory, model.ProductsUnits, ProcureMinShu, ProcureUnitPrice, Salespricess77, d_HandPrice, s_KPP_Remarks, s_KPP_ID, Model_Products_Prodocts.XPP_IsOrder, Model_Products_Prodocts.XPP_Address, int.Parse(Model_Products_Prodocts.XPP_Number.ToString())))
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
                                model1.SuppNo = Ddl_SuppNo.SelectedValue;
                                BLL1.DeleteBYModel(model1);
                            }
                            if (this.AddToSuppliersPrice(Ddl_SuppNo.SelectedValue, model.ProductsName, model.ProductsBarCode, model.ProductsPattern, model.ProductsMainCategory, model.ProductsSmallCategory, model.ProductsUnits, ProcureMinShu, ProcureUnitPrice, Salespricess77, d_HandPrice, s_KPP_Remarks, s_KPP_ID, Model_Products_Prodocts.XPP_IsOrder, Model_Products_Prodocts.XPP_Address, int.Parse(Model_Products_Prodocts.XPP_Number.ToString())))
                            {
                                cal += " ID='" + GridView1.DataKeys[i].Value.ToString() + "' ";

                            }
                        }
                    }
                    else
                    {
                       // Alert("价格不能为0！");
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
                    if (this.Tbx_ID.Text == "")
                    {
                        BLL_Cg.Add(Model_Cg);
                    }
                    //
                    try
                    {
                        base.Base_SendMessage(base.Base_GetDeptPerson("供应链平台", 1), KNetPage.KHtmlEncode("有 BOM报价 <a href='Web/Order/Knet_Procure_SuppliersRC_Price_View.aspx?ID=" + Model_Cg.CSP_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + Model_Cg.CSP_ID + "</a> 需要您审批，敬请关注！"));
                    }
                    catch
                    { }
                    AMlog.Add_Logs("采购入库--->供应商管理-->供应商报价设置 成功!");
                    Response.Write("<script>alert('供应商报价设置成功！点 确定 返回');location.href = 'Knet_Procure_SuppliersRC_Price.aspx';</script>");
                    Response.End();
                }
        }
        catch(Exception ex) { }
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
    protected bool AddToSuppliersPrice(string SuppNo, string ProductsName, string ProductsBarCode, string ProductsPattern, string ProductsMainCategory, string ProductsSmallCategory, string ProductsUnits, int ProcureMinShu, decimal ProcureUnitPrice, decimal Salesprice, decimal d_HandPrice, string s_KPP_Remarks, string s_KPP_ID, string s_KPP_IsOrder, string s_KPP_Address, int KPP_Number)
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
        model.KPP_CgID = s_KPP_ID;
        model.KPP_IsOrder = s_KPP_IsOrder;
        model.KPP_Address = s_KPP_Address;
        model.KPP_Number = KPP_Number;
        try
        {
            BLL.Add(model);
            return true;
        }
        catch { throw;
        return false;
        }
    }
}

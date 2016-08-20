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
/// 销售管理-----退货单 管理
/// </summary>
public partial class Knet_Web_Sales_Knet_Sales_Retrun_Manage_Add : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
                this.KNet_BaoPricePaymentNotesbind();
                this.KClaaBind(this.ReturnClass, 7, "请选择退货分类");
                base.Base_DropBasicCodeBind(this.Ddl_ReturnType, "110");
                this.ReturnNo.Text = "R" + KNetOddNumbers();
                this.ReturnDateTime.Text = DateTime.Now.ToShortDateString();

                string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                this.Lbl_Title.Text = "新增发货通知单";
                if (s_ID != "")
                {
                    if (s_Type == "1")
                    {
                        this.Tbx_ID.Text = "";
                        this.Lbl_Title.Text = "复制发货通知单";
                        this.ReturnNo.Text = "R" + KNetOddNumbers();
                    }
                    else
                    {
                        this.Lbl_Title.Text = "修改发货通知单";
                        this.Tbx_ID.Text = s_ID;
                    }
                    this.Btn_Save.Text = "保存";
                    ShowInfo(s_ID);
                
            }
                if (AM.CheckLogin(this.Lbl_Title.Text) == false)
                {
                    Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                    Response.End();
                }
        }
    }
    
    /// <summary>
    /// 获取信息
    /// </summary>
    /// <param name="OrderNo"></param>
    protected void ShowInfo(string s_ID)
    {
        AdminloginMess AM=new AdminloginMess();
        KNet.BLL.KNet_Sales_ReturnList BLL = new KNet.BLL.KNet_Sales_ReturnList();
        KNet.Model.KNet_Sales_ReturnList model = BLL.GetModelB(s_ID);
        this.ReturnNo.Text = model.ReturnNo;
        try
        {
            this.ReturnDateTime.Text = DateTime.Parse(model.ReturnDateTime.ToString()).ToShortDateString();
        }
        catch { }
        this.CustomerValue.Value = model.CustomerValue;
        this.CustomerValueName.Text = base.Base_GetCustomerName(model.CustomerValue);
        base.Base_DropLinkManBind(this.Ddl_DutyPerson,model.CustomerValue);
        this.Ddl_ReturnType.SelectedValue = model.ReturnType;
        this.Ddl_DutyPerson.SelectedValue = model.ContentPerson;
        this.ReturnPorPay.SelectedValue = model.ReturnPorPay;
        this.ReturnState.SelectedValue = model.ReturnState.ToString();
        this.ReturnClass.SelectedValue = model.ReturnClass;
        this.ReturnRemarks.Text = model.ReturnRemarks;

        KNet.BLL.KNet_Sales_ReturnList_Details BLL_Details = new KNet.BLL.KNet_Sales_ReturnList_Details();
        DataSet Dts_Details = BLL_Details.GetList(" ReturnNo='" + s_ID + "'");
        if (Dts_Details.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
            {
                s_MyTable_Detail += "<tr>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" border=0></a></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" + i + "\" value=" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input  Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" Name=\"Number_" + i + "\" value=" + Dts_Details.Tables[0].Rows[i]["ReturnAmount"].ToString() + "></td>";
                s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" Name=\"Remarks_" + i + "\" value=" + Dts_Details.Tables[0].Rows[i]["ReturnRemarks"].ToString() + "></td>";
                s_MyTable_Detail += "</tr>";
            }

        }
        this.Tbx_Num.Text = Dts_Details.Tables[0].Rows.Count.ToString();
    }
    /// <summary>
    /// 结算方式
    /// </summary> 
    protected void KNet_BaoPricePaymentNotesbind()
    {
        KNet.BLL.KNet_Sys_CheckMethod bll = new KNet.BLL.KNet_Sys_CheckMethod();
        DataSet ds = bll.GetAllList();
        this.ReturnPorPay.DataSource = ds;
        this.ReturnPorPay.DataTextField = "CheckName";
        this.ReturnPorPay.DataValueField = "CheckNo";
        this.ReturnPorPay.DataBind();
        ListItem item = new ListItem("请选择退款方式", ""); //默认值
        this.ReturnPorPay.Items.Insert(0, item);
    }
    /// <summary>
    /// 分类(1渠道信息，2客户类型,3客户行业，4客户来源,5交货方式,6合同分类）  （Y）
    /// </summary>
    /// <param name="DDL"></param>
    /// <param name="ClientKings"></param>
    protected void KClaaBind(DropDownList DDL, int ClientKings, string StrText)
    {
        KNet.BLL.KNet_Sales_ClientAppseting bll = new KNet.BLL.KNet_Sales_ClientAppseting();
        DataSet ds = bll.GetList(" ClientKings=" + ClientKings + " order by ClientPai desc ");
        DDL.DataSource = ds;
        DDL.DataTextField = "Client_Name";
        DDL.DataValueField = "ClientValue";
        DDL.DataBind();
        ListItem item = new ListItem(StrText, ""); //默认值
        DDL.Items.Insert(0, item);
    }
    /// <summary>
    /// 是否复合退货条件 
    /// </summary>
    /// <param name="OrderNo"></param>
    /// <returns></returns>
    protected bool Knet_OutWare_OrdersListYN(string OutWareNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select OutWareNo,ID,OutWareCheckYN from KNet_Sales_OutWareList where OutWareNo='" + OutWareNo + "' and OutWareCheckYN=1 ";
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
    /// 获取客户名称 （Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetCustomerName(string aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,CustomerValue,CustomerName from KNet_Sales_ClientList where CustomerValue='" + aa + "'";
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

    #region 返回单号情况

    /// <summary>
    /// 返回当前的  单号 （唯一性，如 2009121402）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string KNetOddNumbers()
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as AA  from  KNet_Sales_ReturnList  where (datediff(d,SystemDatetimes,GETDATE())=0)";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (int.Parse(dr["AA"].ToString()) == 0)
                {
                    return DateTime.Today.ToString("yyyyMMdd") + "0001";
                }
                else
                {
                    return DateTime.Today.ToString("yyyyMMdd") + KNus003(int.Parse(dr["AA"].ToString()) + 1);
                }
            }
            else
            {
                return DateTime.Today.ToString("yyyyMMdd") + "0001";
            }
        }
    }
    /// <summary>
    /// 返回当前的  单号 （唯一性，如 2009121402）
    /// </summary>
    /// <param name="ss"></param>
    /// <returns></returns>
    protected string KNus003(int ss)
    {
        if (ss.ToString().Length == 1)
        {
            return "000" + ss.ToString();
        }
        else if (ss.ToString().Length == 2)
        {
            return "00" + ss.ToString();
        }
        else if (ss.ToString().Length == 3)
        {
            return "0" + ss.ToString();
        }
        else if (ss.ToString().Length == 4)
        {
            return ss.ToString();
        }
        else
        {
            return ss.ToString();
        }
    }
    #endregion

    /// <summary>
    /// 确定开收货单
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        string ReturnNo = KNetPage.KHtmlEncode(this.ReturnNo.Text.Trim());
        string ReturnTopic = "";
        DateTime ReturnDateTime = DateTime.Now;
        try
        {
            ReturnDateTime = DateTime.Parse(this.ReturnDateTime.Text.Trim());
        }
        catch { }

        string CustomerValue = KNetPage.KHtmlEncode(this.CustomerValue.Value.Trim());

        string ReturnPorPay = KNetPage.KHtmlEncode(this.ReturnPorPay.SelectedValue);
        string ReturnDeliveMethods = "";

        int ReturnState = int.Parse(this.ReturnState.SelectedValue.ToString());
        string ReturnClass = this.ReturnClass.SelectedValue;

        


        string ReturnCheckStaffNo = "";
        string ReturnRemarks = KNetPage.KHtmlEncode(this.ReturnRemarks.Text.Trim());


        KNet.Model.KNet_Sales_ReturnList molel = new KNet.Model.KNet_Sales_ReturnList();
        molel.ReturnNo = ReturnNo;
        molel.ReturnTopic = ReturnTopic;
        molel.ReturnDateTime = ReturnDateTime;
        molel.CustomerValue = CustomerValue;
        molel.ReturnPorPay = ReturnPorPay;
        molel.ReturnClass = ReturnClass;
        molel.ReturnDeliveMethods = ReturnDeliveMethods;
        molel.ReturnState = ReturnState;
        molel.ReturnCheckStaffNo = ReturnCheckStaffNo;
        molel.ReturnRemarks = ReturnRemarks;
        molel.ContentPerson = this.Ddl_DutyPerson.SelectedValue;
        molel.ReturnType = this.Ddl_ReturnType.SelectedValue;

        KNet.BLL.KNet_Sales_ReturnList BLL = new KNet.BLL.KNet_Sales_ReturnList();

        ArrayList Arr_Details = new ArrayList();

        int i_num = int.Parse(this.Tbx_Num.Text);
        for (int i = 0; i < i_num; i++)
        {
            KNet.Model.KNet_Sales_ReturnList_Details ModelDetails = new KNet.Model.KNet_Sales_ReturnList_Details();
            if (Request["ProductsBarCode_" + i] != null)
            {
                string s_ProductsBarCode = Request["ProductsBarCode_" + i].ToString();
                string s_Number = Request["Number_" + i].ToString();
                string s_Remarks = Request["Remarks_" + i].ToString();
                ModelDetails.ProductsBarCode = s_ProductsBarCode;
                ModelDetails.ReturnAmount = int.Parse(s_Number);
                ModelDetails.Return_SalesUnitPrice = 0;
                ModelDetails.Return_SalesTotalNet = 0;
                ModelDetails.ReturnNo = ReturnNo;
                Arr_Details.Add(ModelDetails);
            }
        }
        molel.Arr_Details = Arr_Details;

        try
        {
            AdminloginMess LogAM = new AdminloginMess();
            if (this.Tbx_ID.Text != "")
            {

                BLL.Update(molel);
                LogAM.Add_Logs("销售管理--->销售退货管理--->退货开单 添加 操作成功！退货单号：" + ReturnNo);

                Response.Write("<script>alert('退货开单 更新  操作成功！！');location.href='Knet_Sales_Retrun_Manage_Manage.aspx';</script>");
                Response.End();
            }
            else
            {

                if (BLL.Exists(ReturnNo) == false)
                {
                    BLL.Add(molel);
                    LogAM.Add_Logs("销售管理--->销售退货管理--->退货开单 添加 操作成功！退货单号：" + ReturnNo);

                    Response.Write("<script>alert('退货开单 添加  操作成功！ 确定进入添加退货单产品明细！');location.href='Knet_Sales_Retrun_Manage_Manage.aspx';</script>");
                    Response.End();
                }
                else
                {
                    Response.Write("<script>alert('退货单号已存在 添加失败！');history.back(-1);</script>");
                    Response.End();
                }
            }

        }
        catch(Exception ex)
        {
            Response.Write("<script>alert('退货开单添加失败！"+ex.Message+"');history.back(-1);</script>");
            Response.End();
        }
    }
}

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
/// 库存管理-----库间调拨----添加
/// </summary>
public partial class Knet_Web_WareHouse_KNet_WareHouse_AllocateList_Add : BasePage
{
    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            this.Tbx_Type.Text = s_Type;
            string s_Sql = " 1=1 ";
            this.AllocateDateTime.Text = DateTime.Now.ToShortDateString();
            this.Lbl_Title.Text = "新增调拨入库";
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制调拨入库";
                    this.AllocateNo.Text = "FXDB" + KNetOddNumbers();
                }
                else
                {
                    this.Lbl_Title.Text = "修改调拨入库";
                    this.Tbx_ID.Text = s_ID;
                    this.AllocateNo.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
            }
            else
            {
                if (s_Type == "2")
                {
                    s_Sql = "  HouseName like '%修%' ";
                    this.AllocateNo.Text = "FXDB" + KNetOddNumbers();
                }
                else
                {
                    s_Sql = "  HouseName not like '%修%' and KSW_Type='0' ";
                    this.AllocateNo.Text = "DB" + KNetOddNumbers();
                }
            }
            base.Base_DropWareHouseBind(this.HouseNo_out, s_Sql);
            base.Base_DropWareHouseBind(this.HouseNo_int, s_Sql);
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }
            if (AM.CheckLogin("新增直接入库") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
        }
    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.KNet_WareHouse_AllocateList bll = new KNet.BLL.KNet_WareHouse_AllocateList();
        KNet.Model.KNet_WareHouse_AllocateList model = bll.GetModelB(s_ID);
        if (model.AllocateCheckYN >0)
        {
            AlertAndGoBack("已审核不能修改");
        }
        else
        {
            this.AllocateNo.Text = model.AllocateNo;
            this.AllocateDateTime.Text = model.AllocateDateTime.ToString();
            this.HouseNo_int.SelectedValue = model.HouseNo_int;
            this.HouseNo_out.SelectedValue = model.HouseNo;
            this.AllocateCause.Text = model.AllocateCause;
            this.AllocateRemarks.Text = model.AllocateRemarks;

            KNet.BLL.KNet_WareHouse_AllocateList_Details BLL_Details = new KNet.BLL.KNet_WareHouse_AllocateList_Details();
            DataSet Dts_Details = BLL_Details.GetList(" AllocateNo='" + s_ID + "'");
            if (Dts_Details.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    s_MyTable_Detail += "<tr>";
                    this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" alt=\"CRMone\" title=\"CRMone\" border=0></a></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'>" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["AllocateAmount"].ToString() + "'></td>";

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Price_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["AllocateUnitPrice"].ToString() + "'></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Money_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["AllocateTotalNet"].ToString() + "'></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Remarks_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["AllocateRemarks"].ToString() + "'></td>";
                    s_MyTable_Detail += "</tr>";
                }
                this.Tbx_Num.Text = Dts_Details.Tables[0].Rows.Count.ToString();
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
            string Dostr = "select count(*) as AA  from  KNet_WareHouse_AllocateList  where (datediff(d,SystemDatetimes,GETDATE())=0)";
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

    private bool SetValue(KNet.Model.KNet_WareHouse_AllocateList molel)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            string AllocateNo = KNetPage.KHtmlEncode(this.AllocateNo.Text.Trim());
            string AllocateTopic = KNetPage.KHtmlEncode("");
            string AllocateCause = KNetPage.KHtmlEncode(this.AllocateCause.Text.Trim());

            DateTime AllocateDateTime = DateTime.Now;
            try
            {
                AllocateDateTime = DateTime.Parse(this.AllocateDateTime.Text.Trim());
            }
            catch { }

            string HouseNo_out = KNetPage.KHtmlEncode(this.HouseNo_out.SelectedValue);
            string HouseNo_int = KNetPage.KHtmlEncode(this.HouseNo_int.SelectedValue);

            if (HouseNo_out.ToLower() == HouseNo_int.ToLower())
            {
                Response.Write("<script>alert('错误！！\\n\\n调出仓库不能与调入仓库一样！');history.back(-1);</script>");
                Response.End();
            }
            string AllocateStaffBranch = "";
            string AllocateStaffDepart = "";
            string AllocateStaffNo = AM.KNet_StaffNo;
            string AllocateCheckStaffNo = "";
            string AllocateRemarks = KNetPage.KHtmlEncode(this.AllocateRemarks.Text.Trim());


            molel.AllocateNo = AllocateNo;
            molel.AllocateTopic = AllocateTopic;
            molel.AllocateCause = AllocateCause;

            molel.AllocateDateTime = AllocateDateTime;
            molel.HouseNo = HouseNo_out;
            molel.HouseNo_int = HouseNo_int;

            molel.AllocateStaffBranch = AllocateStaffBranch;
            molel.AllocateStaffDepart = AllocateStaffDepart;

            molel.AllocateStaffNo = AllocateStaffNo;
            molel.AllocateCheckStaffNo = AllocateCheckStaffNo;
            molel.AllocateRemarks = AllocateRemarks;
            molel.AllocateCheckYN = 1;
            molel.AllocateTopic = "102";//维修品调拨

            ArrayList Arr_Products = new ArrayList();
            for (int i = 0; i < int.Parse(this.Tbx_Num.Text); i++)
            {

                if (Request["ProductsBarCode_" + i.ToString()] != null)
                {
                    string s_ProductsBarCode = Request.Form["ProductsBarCode_" + i.ToString()].ToString();
                    string s_Number = Request.Form["Number_" + i.ToString()] == "" ? "0" : Request.Form["Number_" + i.ToString()].ToString();
                    string s_Price = Request.Form["Price_" + i.ToString()] == "" ? "0" : Request.Form["Price_" + i.ToString()].ToString();
                    string s_Money = Request.Form["Money_" + i.ToString()] == "" ? "0" : Request.Form["Money_" + i.ToString()].ToString();
                    if (decimal.Parse(s_Money) != 0)
                    {
                        try
                        {
                            s_Price = Convert.ToString(decimal.Parse(s_Money) / decimal.Parse(s_Number));
                        }
                        catch { }
                    }
                    else
                    {
                        s_Money = Convert.ToString(decimal.Parse(s_Price) * decimal.Parse(s_Number));
                    }
                    string s_Remarks = Request.Form["Remarks_" + i.ToString()].ToString();
                    KNet.Model.KNet_WareHouse_AllocateList_Details Model_Details = new KNet.Model.KNet_WareHouse_AllocateList_Details();
                    Model_Details.ID = GetNewID("KNet_WareHouse_AllocateList_Details", 1);
                    Model_Details.ProductsBarCode = s_ProductsBarCode;
                    Model_Details.AllocateNo = molel.AllocateNo;
                    Model_Details.AllocateAmount = int.Parse(s_Number);
                    Model_Details.AllocateUnitPrice = decimal.Parse(s_Price);
                    Model_Details.AllocateTotalNet = decimal.Parse(s_Money);
                    Model_Details.AllocateRemarks = s_Remarks;
                    Arr_Products.Add(Model_Details);
                    molel.Arr_List = Arr_Products;
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }



    /// <summary>
    /// 确定开收货单
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {


        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.KNet_WareHouse_AllocateList BLL = new KNet.BLL.KNet_WareHouse_AllocateList();
        KNet.Model.KNet_WareHouse_AllocateList Model = new KNet.Model.KNet_WareHouse_AllocateList();

        string s_ID = this.Tbx_ID.Text;
        AdminloginMess LogAM = new AdminloginMess();
        if (this.SetValue(Model) == false)
        {
            Alert("系统错误！");
            return;
        }
        try
        {
            if (s_ID == "")//新增
            {
                if (BLL.Exists(Model.AllocateNo) == false)
                {
                    BLL.Add(Model);
                    LogAM.Add_Logs("库存管理--->库间调拨--->调拨开单 添加 操作成功！调拨单号：" + AllocateNo);

                    Response.Write("<script>alert('调拨单 添加  操作成功！');location.href='KNet_WareHouse_AllocateList_Manage.aspx?Type=" + this.Tbx_Type.Text + "';</script>");
                    Response.End();
                }
                else
                {
                    Response.Write("<script>alert('调拨单号已存在 添加失败！');history.back(-1);</script>");
                    Response.End();
                }
            }
            else
            {

                try
                {
                    BLL.Update(Model);
                    LogAM.Add_Logs("库存管理--->库间调拨--->调拨开单 添加 操作成功！调拨单号：" + AllocateNo);
                    AlertAndRedirect("修改成功！", "KNet_WareHouse_AllocateList_Manage.aspx?Type=" + this.Tbx_Type.Text + "");
                }
                catch (Exception ex) { }
            }


        }
        catch
        {
            Response.Write("<script>alert('调拨单添加失败！');history.back(-1);</script>");
            Response.End();
        }
    }
}

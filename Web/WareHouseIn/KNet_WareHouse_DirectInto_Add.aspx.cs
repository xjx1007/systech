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
/// 库存管理-----直接开入库单
/// </summary>
public partial class Knet_Web_WareHouse_KNet_WareHouse_DirectInto_Add : BasePage
{

    public string s_MyTable_Detail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();

            if (s_Type != "")
            {
                //直接入库单删除
                if (AM.YNAuthority("售后入库列表") == false)
                {
                    AM.NoAuthority("售后入库列表");
                }
            }
            else
            {
                if (AM.YNAuthority("直接入库列表") == false)
                {
                    AM.NoAuthority("直接入库列表");
                }
            }
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                this.BeginQuery("Select * from PB_Basic_Wl ");
                this.QueryForDataTable();
                this.Drop_KD.DataSource = this.Dtb_Result;
                this.Drop_KD.DataTextField = "PBW_Name";
                this.Drop_KD.DataValueField = "PBW_Code";
                this.Drop_KD.DataBind();
                ListItem item1 = new ListItem("请选择快递", ""); //默认值
                Drop_KD.Items.Insert(0, item1);
                string s_Sqlwhere = "1=1";
                string s_ReturnNo = Request.QueryString["ReturnNo"] == null ? "" : Request.QueryString["ReturnNo"].ToString();
                this.Tbx_Type.Text = s_Type;
                if (s_ID == "")
                {
                    this.DirectInNo.Text = "FXRK" + KNetOddNumbers();
                    this.DirectInDateTime.Text = DateTime.Now.ToShortDateString();
                }
                if (s_ReturnNo != "")
                {
                    this.ReturnNo.Text = s_ReturnNo;
                    KNet.BLL.KNet_Sales_ReturnList BLL = new KNet.BLL.KNet_Sales_ReturnList();
                    KNet.Model.KNet_Sales_ReturnList Model = BLL.GetModelB(s_ReturnNo);
                    if (Model.ReturnType == "101")//返修品
                    {
                        s_Sqlwhere += " and HouseName like '%修%' ";
                    }
                    else if (Model.ReturnType == "102")//成品
                    {
                        s_Sqlwhere += " and HouseName not like '%修%' ";
                    }
                }
                else
                {
                    if (s_Type == "5")
                    {
                        this.DirectInNo.Text = KNetOddNumbers();
                        this.DirectInSource.Text = "初始化";
                        this.DirectInDateTime.Text = "2013-12-31";
                        this.BeginQuery("select HouseNo,HouseName FROM KNet_Sys_WareHouse  where HouseYN=1 and KSW_Type='1' union all select SuppNo,KPS_SName from Knet_Procure_Suppliers where KPS_Type='128860698200781250' ");
                        this.QueryForDataSet();
                        this.HouseNo.DataSource = Dts_Result;
                        HouseNo.DataTextField = "HouseName";
                        HouseNo.DataValueField = "HouseNo";
                        HouseNo.DataBind();
                        ListItem item = new ListItem("请选择仓库", ""); //默认值
                        HouseNo.Items.Insert(0, item);
                    }
                    else if (s_Type != "")
                    {
                        s_Sqlwhere += " and HouseName like '%修%' ";
                    }
                    else
                    {
                        s_Sqlwhere += " and KSW_Type='0' ";
                        base.Base_DropWareHouseBind(this.HouseNo, s_Sqlwhere);
                        if (s_ID == "")
                        {
                            this.DirectInNo.Text = "D" + KNetOddNumbers();
                        }
                    }
                }
                if (s_ReturnNo != "")
                {

                    KNet.BLL.KNet_Sales_ReturnList_Details BLL_Details = new KNet.BLL.KNet_Sales_ReturnList_Details();
                    DataSet Dts_Details = BLL_Details.GetList(" ReturnNo='" + s_ReturnNo + "'");
                    if (Dts_Details.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                        {
                            s_MyTable_Detail += "<tr>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"../../themes/softed/images/delete.gif\" border=0></a></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ProductsBarCode_" + i + "\" value=" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "</td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input   Class=\"detailedViewTextBox\" Width=\"50px\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" Name=\"Number_" + i + "\" value=" + Dts_Details.Tables[0].Rows[i]["ReturnAmount"].ToString() + "></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input   Class=\"detailedViewTextBox\" Width=\"50px\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" Name=\"Price_" + i + "\" value=0></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input   Class=\"detailedViewTextBox\" Width=\"50px\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" Name=\"Money_" + i + "\" value=0></td>";
                            s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input  Class=\"detailedViewTextBox\" Width=\"50px\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" Name=\"Remarks_" + i + "\" value=" + Dts_Details.Tables[0].Rows[i]["ReturnRemarks"].ToString() + "></td>";
                            s_MyTable_Detail += "</tr>";
                        }
                    }
                    this.Tbx_Num.Text = Dts_Details.Tables[0].Rows.Count.ToString();
                }
                if (s_ID == "")
                {
                    if (s_Type != "3")
                    {
                        base.Base_DropWareHouseBind(this.HouseNo, s_Sqlwhere);
                    }
                }
                if (s_Type == "5")
                {
                    this.DirectInNo.Text = KNetOddNumbers();
                    this.BeginQuery("select HouseNo,HouseName FROM KNet_Sys_WareHouse  where HouseYN=1 and KSW_Type='1' union all select SuppNo,KPS_SName from Knet_Procure_Suppliers where KPS_Type='128860698200781250' ");
                    this.QueryForDataSet();
                    this.HouseNo.DataSource = Dts_Result;
                    HouseNo.DataTextField = "HouseName";
                    HouseNo.DataValueField = "HouseNo";
                    HouseNo.DataBind();
                    ListItem item = new ListItem("请选择仓库", ""); //默认值
                    HouseNo.Items.Insert(0, item);
                }
            }
            ShowDetails(s_ID);
        }
    }

    private void ShowDetails(string s_ID)
    {
        KNet.BLL.KNet_WareHouse_DirectInto bll = new KNet.BLL.KNet_WareHouse_DirectInto();
        KNet.Model.KNet_WareHouse_DirectInto model = bll.GetModelB(s_ID);
        if (model != null)
        {
                  if (model.DirectInCheckYN >0)
                {
                    AlertAndGoBack("已审核不能修改");
                }
                  Drop_KD.SelectedValue = model.KWD_KDNameCode;
                  this.Tbx_Code.Text= model.KWD_KDCode;
                  this.Tbx_Person.Text = model.KWD_PersonName;
                  this.Tbx_TelPhone.Text = model.KWD_Telphone;
                  this.Tbx_Phone.Text = model.KWD_Phone;
                  this.Tbx_Address.Text = model.KWD_Address;
            this.DirectInDateTime.Text = DateTime.Parse(model.DirectInDateTime.ToString()).ToShortDateString();
            this.HouseNo.SelectedValue = model.HouseNo;
            this.DirectInSource.Text = model.DirectInSource;
            this.SuppNoSelectValue.Value = model.SuppNo;
            this.SuppNo.Text = base.Base_GetSupplierName(model.SuppNo);
            this.DirectInNo.Text = model.DirectInNo;
            this.Tbx_ID.Text = s_ID;
            this.DirectInRemarks.Text = model.DirectInRemarks;
            KNet.BLL.KNet_WareHouse_DirectInto_Details BLL_Details = new KNet.BLL.KNet_WareHouse_DirectInto_Details();
            DataSet Dts_Details = BLL_Details.GetList(" DirectInNo='" + s_ID + "'");
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
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["DirectINAmount"].ToString() + "'></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Price_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["DirectINUnitPrice"].ToString() + "'></td>";
                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Money_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["DirectINTotalNet"].ToString() + "'></td>";

                    s_MyTable_Detail += "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Remarks_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["DirectINRemarks"].ToString() + "'></td>";
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
            string Dostr = "select count(*) as AA  from  KNet_WareHouse_DirectInto  where (datediff(d,SystemDatetimes,GETDATE())=0)";
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
        AdminloginMess AM = new AdminloginMess();
        string DirectInNo = KNetPage.KHtmlEncode(this.DirectInNo.Text.Trim());
        string DirectInTopic = KNetPage.KHtmlEncode("");
        string DirectInSource = KNetPage.KHtmlEncode(this.DirectInSource.Text.Trim());

        DateTime DirectInDateTime = DateTime.Now;
        try
        {
            DirectInDateTime = DateTime.Parse(this.DirectInDateTime.Text.Trim());
        }
        catch { }

        string SuppNo = KNetPage.KHtmlEncode(this.SuppNoSelectValue.Value);

        string HouseNo = KNetPage.KHtmlEncode(this.HouseNo.SelectedValue);
        string DirectInCheckStaffNo = "";
        string DirectInRemarks = KNetPage.KHtmlEncode(this.DirectInRemarks.Text.Trim());


        KNet.Model.KNet_WareHouse_DirectInto molel = new KNet.Model.KNet_WareHouse_DirectInto();

        molel.DirectInNo = DirectInNo;
        molel.DirectInTopic = DirectInTopic;
        molel.DirectInSource = DirectInSource;

        molel.DirectInDateTime = DirectInDateTime;
        molel.SuppNo = SuppNo;
        molel.HouseNo = HouseNo;
        molel.DirectInStaffBranch = "";
        molel.DirectInStaffDepart = "";
        molel.DirectInCheckStaffNo = DirectInCheckStaffNo;
        molel.DirectInRemarks = DirectInRemarks;
        molel.DirectInCheckYN = 0;


        molel.KWD_KDNameCode = Drop_KD.SelectedValue;
        molel.KWD_KDName = Drop_KD.SelectedItem.Text;
        molel.KWD_KDCode = this.Tbx_Code.Text;
        molel.KWD_PersonName = this.Tbx_Person.Text;
        molel.KWD_Telphone = this.Tbx_TelPhone.Text;
        molel.KWD_Phone = this.Tbx_Phone.Text;
        molel.KWD_Address = this.Tbx_Address.Text;

        if (this.Tbx_Type.Text == "3")
        {
            molel.KWD_Type = "3";
        }
        else if (this.Tbx_Type.Text == "2")
        {
            molel.DirectInCheckYN = 1;
            molel.KWD_Type = "102";
        }
        else if (this.Tbx_Type.Text == "5")
        {
            molel.KWD_Type = "105";
        }
        else
        {
            molel.KWD_Type = "101";

        }
        molel.KWD_ReturnNo = this.ReturnNo.Text;
        molel.DirectInStaffNo = AM.KNet_StaffNo;

        KNet.BLL.KNet_WareHouse_DirectInto BLL = new KNet.BLL.KNet_WareHouse_DirectInto();

        ArrayList Arr_Details = new ArrayList();

        int i_num = int.Parse(this.Tbx_Num.Text);
        for (int i = 0; i < i_num; i++)
        {
            KNet.Model.KNet_WareHouse_DirectInto_Details ModelDetails = new KNet.Model.KNet_WareHouse_DirectInto_Details();
            if (Request["ProductsBarCode_" + i] != null)
            {
                string s_ProductsBarCode = Request["ProductsBarCode_" + i].ToString();
                string s_Number = Request["Number_" + i].ToString();
                string s_Price = Request["Price_" + i].ToString();
                string s_Money = Request["Money_" + i].ToString();
                string s_Remarks = Request["Remarks_" + i].ToString();
                ModelDetails.ProductsBarCode = s_ProductsBarCode;
                ModelDetails.DirectInAmount = int.Parse(s_Number);
                try
                {
                    if ((s_Money != "0") && (s_Number != "0"))
                    {
                        s_Price = Convert.ToString(decimal.Parse(s_Money) / decimal.Parse(s_Number));
                    }
                }
                catch { }
                ModelDetails.DirectInUnitPrice = decimal.Parse(s_Price);
                ModelDetails.DirectInTotalNet = decimal.Parse(s_Price) * decimal.Parse(s_Number);
                ModelDetails.DirectInNo = DirectInNo;
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
                KNet.BLL.KNet_WareHouse_DirectInto_Details BllDetails = new KNet.BLL.KNet_WareHouse_DirectInto_Details();
                BllDetails.DeleteByFID(molel.DirectInNo);
                if (Arr_Details != null)
                {
                    for (int i = 0; i < Arr_Details.Count; i++)
                    {
                        KNet.Model.KNet_WareHouse_DirectInto_Details ModelDetails = (KNet.Model.KNet_WareHouse_DirectInto_Details)Arr_Details[i];
                        BllDetails.Add(ModelDetails);
                    }
                }
                LogAM.Add_Logs("库存管理--->开单 修改 操作成功！入库单号：" + DirectInNo);
                Response.Write("<script>alert('开单 修改  操作成功！');location.href='KNet_WareHouse_DirectInto_Manage.aspx?DirectInNo=" + DirectInNo + "&Type=" + this.Tbx_Type.Text + "';</script>");
                Response.End();
            }
            else
            {

                if (BLL.Exists(DirectInNo) == false)
                {
                    BLL.Add(molel);
                    KNet.BLL.KNet_WareHouse_DirectInto_Details BllDetails = new KNet.BLL.KNet_WareHouse_DirectInto_Details();
                    if (Arr_Details != null)
                    {
                        for (int i = 0; i < Arr_Details.Count; i++)
                        {
                            KNet.Model.KNet_WareHouse_DirectInto_Details ModelDetails = (KNet.Model.KNet_WareHouse_DirectInto_Details)Arr_Details[i];
                            BllDetails.Add(ModelDetails);
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('退品开单单号已存在 添加失败！');history.back(-1);</script>");
                    Response.End();
                }
                LogAM.Add_Logs("库存管理--->开单 添加 操作成功！入库单号：" + DirectInNo);
                Response.Write("<script>alert('开单 添加  操作成功！');location.href='KNet_WareHouse_DirectInto_Manage.aspx?DirectInNo=" + DirectInNo + "&Type=" + this.Tbx_Type.Text + "';</script>");
                Response.End();
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('退品开单添加失败！');history.back(-1);</script>");
            Response.End();
        }
    }
}

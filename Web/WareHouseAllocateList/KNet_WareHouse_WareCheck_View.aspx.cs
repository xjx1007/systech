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


public partial class Web_KNet_WareHouse_WareCheck_View : BasePage
{
    public string s_CustomerValue = "", s_OrderStyle = "", s_DetailsStyle = "";
    public string s_LinkMan = "";
    public string s_OppID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            if (s_Type == "1")
            {
                s_OrderStyle = "class=\"dvtUnSelectedCell\"";
                s_DetailsStyle = "class=\"dvtSelectedCell\"";
                Pan_Order.Visible = false;
                Pan_Detail.Visible = true;
                Table_Btn.Visible = false;
            }
            else
            {
                s_DetailsStyle = "class=\"dvtUnSelectedCell\"";
                s_OrderStyle = "class=\"dvtSelectedCell\"";
                Pan_Order.Visible = true;
                Pan_Detail.Visible = false;
                Table_Btn.Visible = true;
            }
            this.Lbl_Title.Text = "查看调拨";
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }


            KNet.BLL.Sc_Expend_Manage bll_Manage = new KNet.BLL.Sc_Expend_Manage();
            string SqlWhere = " SEM_Type=1 and SEM_DirectOutNO='" + s_ID + "' ";
            SqlWhere = SqlWhere + " order by SEM_MTime desc";
            DataSet ds_Manage = bll_Manage.GetList(SqlWhere);
            GridView1.DataSource = ds_Manage;
            GridView1.DataKeyNames = new string[] { "SEM_ID" };
            GridView1.DataBind();
        }

    }

    public string s_GetHouse(string s_AllocateNO)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_WareHouse_AllocateList Bll = new KNet.BLL.KNet_WareHouse_AllocateList();
            KNet.Model.KNet_WareHouse_AllocateList Model = Bll.GetModelB(s_AllocateNO);
            s_Return = base.Base_GetHouseName(Model.HouseNo);
        }
        catch { }
        return s_Return;
    }
    protected void btn_Chcek_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {

            if (btn_Chcek.Text == "审批")
            {
                string DoSql = "update KNet_WareHouse_AllocateList  set AllocateCheckYN=1  where  AllocateNo='" + this.Tbx_ID.Text + "' ";
                DbHelperSQL.ExecuteSql(DoSql);
                try
                {
                    for (int i = 0; i < int.Parse(this.Tbx_Num.Text); i++)
                    {

                        if (Request["ID_" + i.ToString()] != null)
                        {
                            string s_ID = Request.Form["ID_" + i.ToString()] == null ? "" : Request.Form["ID_" + i.ToString()].ToString();
                            string s_Number = Request.Form["Number_" + i.ToString()] == null ? "" : Request.Form["Number_" + i.ToString()].ToString();
                            string s_OldNumber = Request.Form["OldNumber_" + i.ToString()] == null ? "" : Request.Form["OldNumber_" + i.ToString()].ToString();
                            DoSql = "update KNet_WareHouse_AllocateList_Details  set KWAD_SCDBNumber='" + s_OldNumber + "'  where  ID='" + s_ID + "' and KWAD_SCDBNumber=0 ";
                            DbHelperSQL.ExecuteSql(DoSql);

                            DoSql = "update KNet_WareHouse_AllocateList_Details  set AllocateAmount='" + s_Number + "',KWAD_OldNumber='" + s_Number + "'  where  ID='" + s_ID + "' ";
                            DbHelperSQL.ExecuteSql(DoSql);
                        }
                    }
                }
                catch { }
                btn_Chcek.Text = "反审批";
                AM.Add_Logs("审批成功" + this.Tbx_ID.Text);
                AlertAndRedirect("审批成功！", "KNet_WareHouse_WareCheck_View.aspx?ID=" + this.Tbx_ID.Text + "");
            }
            else if (btn_Chcek.Text == "反审批")
            {
                string DoSql = "update KNet_WareHouse_AllocateList  set AllocateCheckYN=0  where  AllocateNo='" + this.Tbx_ID.Text + "' ";
                DbHelperSQL.ExecuteSql(DoSql);
                try
                {
                    for (int i = 0; i < int.Parse(this.Tbx_Num.Text); i++)
                    {

                        if (Request["ID_" + i.ToString()] != null)
                        {
                            string s_ID = Request.Form["ID_" + i.ToString()] == null ? "" : Request.Form["ID_" + i.ToString()].ToString();
                            //string s_Number = Request.Form["Number_" + i.ToString()] == null ? "" : Request.Form["Number_" + i.ToString()].ToString();
                           // DoSql = "update KNet_WareHouse_AllocateList_Details  set AllocateAmount=KWAD_SCDBNumber  where  ID='" + s_ID + "' ";
                          //  DbHelperSQL.ExecuteSql(DoSql);

                        }
                    }
                }
                catch { }
                btn_Chcek.Text = "审批";
                AM.Add_Logs("反审批成功" + this.Tbx_ID.Text);
                AlertAndRedirect("反审批成功！", "KNet_WareHouse_WareCheck_View.aspx?ID=" + this.Tbx_ID.Text + "");
            }
            else if (btn_Chcek.Text == "财务审批")
            {
                string DoSql = "update KNet_WareHouse_AllocateList  set AllocateCheckYN=3  where  AllocateNo='" + this.Tbx_ID.Text + "' ";
                DbHelperSQL.ExecuteSql(DoSql);
                btn_Chcek.Text = "反财务审批";
                AM.Add_Logs("财务审批成功" + this.Tbx_ID.Text);
                AlertAndRedirect("财务审批成功！", "KNet_WareHouse_WareCheck_View.aspx?ID=" + this.Tbx_ID.Text + "");
            }
            else if (btn_Chcek.Text == "反财务审批")
            {
                string DoSql = "update KNet_WareHouse_AllocateList  set AllocateCheckYN=1  where  AllocateNo='" + this.Tbx_ID.Text + "' ";
                DbHelperSQL.ExecuteSql(DoSql);
                btn_Chcek.Text = "反财务审批";
                AM.Add_Logs("反财务审批成功" + this.Tbx_ID.Text);
                AlertAndRedirect("反财务审批成功！", "KNet_WareHouse_WareCheck_View.aspx?ID=" + this.Tbx_ID.Text + "");
            }

        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }


    private bool SetValue(KNet.Model.Sc_Expend_Manage model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            model.SEM_ID = base.GetNewID("Sc_Expend_Manage", 1);

            try
            {
                model.SEM_Stime = DateTime.Parse(this.Lbl_Stime.Text);
            }
            catch { }
            model.SEM_SuppNo = this.Lbl_HouseNo.Text;
            model.SEM_CustomerName = this.Lbl_House_int0.Text;
            model.SEM_DutyPerson = AM.KNet_StaffNo;
            model.SEM_Type = 1;
            try
            {
                model.SEM_RkTime = DateTime.Parse(this.Tbx_RkTime.Text);
            }
            catch { }
            try
            {
                model.SEM_WwTime = DateTime.Parse(this.Tbx_WwTime.Text);
            }
            catch { }
            model.SEM_RkPerson = this.Ddl_RkPerson.SelectedValue;
            model.SEM_WwPerson = this.Ddl_WwPerson.SelectedValue;
            model.SEM_Remarks = "";
            model.SEM_Creator = AM.KNet_StaffNo;
            model.SEM_CTime = DateTime.Now;
            model.SEM_Mendor = AM.KNet_StaffNo;
            model.SEM_MTime = DateTime.Now;
            model.SEM_DirectOutNO = this.Tbx_ID.Text;
            //单号
            model.SEM_RCRKCode = GetIDByMonth(0, "4");
            ///成品消耗
            ArrayList arr_RcDetails = new ArrayList();
            int i_Num = 0;
            for (int i = 0; i < this.MyGridView1.Rows.Count; i++)
            {
                KNet.Model.Sc_Expend_Manage_RCDetails Mode_RkDetails = new KNet.Model.Sc_Expend_Manage_RCDetails();
                Mode_RkDetails.SER_ID = base.GetNewID("Sc_Expend_Manage_RCDetails", 1);
                TextBox Tbx_ProductsBarCode = (TextBox)this.MyGridView1.Rows[i].Cells[0].FindControl("Tbx_ProductsBarCode");
                DropDownList Ddl_House = (DropDownList)MyGridView1.Rows[i].Cells[0].FindControl("Ddl_House");
                TextBox Tbx_DID = (TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_DID");
                TextBox Tbx_Number = (TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_Number");
                TextBox Tbx_Price = (TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_Price");
                decimal d_Price = decimal.Parse(Tbx_Price.Text == "" ? "0" : Tbx_Price.Text);

                CheckBox Chk_Chbk = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (Chk_Chbk.Checked)
                {
                    Mode_RkDetails.SER_ProductsBarCode = Tbx_ProductsBarCode.Text;
                    Mode_RkDetails.SER_OrderDetailID = Tbx_DID.Text;
                    Mode_RkDetails.SER_ScNumber = int.Parse(Tbx_Number.Text);
                    Mode_RkDetails.SER_ScPrice = d_Price;
                    Mode_RkDetails.SER_ScMoney = d_Price * int.Parse(Tbx_Number.Text);
                    Mode_RkDetails.SER_SEMID = model.SEM_ID;
                    Mode_RkDetails.SER_HouseNo = Ddl_House.SelectedValue;
                    arr_RcDetails.Add(Mode_RkDetails);
                    i_Num++;
                }
            }
            model.arr_Details = arr_RcDetails;
            ///物料消耗
            ArrayList arr_MaterDetails = new ArrayList();
            for (int i = 0; i < this.MyGridView2.Rows.Count; i++)
            {
                DropDownList Ddl_RkHouse = (DropDownList)MyGridView2.Rows[i].Cells[0].FindControl("Ddl_RkHouse");
                DropDownList Ddl_House = (DropDownList)MyGridView2.Rows[i].Cells[0].FindControl("Ddl_House");
                TextBox Tbx_ProductsBarCode = (TextBox)MyGridView2.Rows[i].Cells[0].FindControl("Tbx_ProductsBarCode");
                TextBox Tbx_Remarks = (TextBox)MyGridView2.Rows[i].Cells[0].FindControl("Tbx_Remarks");
                TextBox Tbx_Number = (TextBox)MyGridView2.Rows[i].Cells[0].FindControl("Tbx_Number");
                string SED_RkPrice = MyGridView2.Rows[i].Cells[5].Text;
                KNet.Model.Sc_Expend_Manage_MaterDetails Mode_MaterDetails = new KNet.Model.Sc_Expend_Manage_MaterDetails();

                CheckBox Chk_Chbk = MyGridView2.Rows[i].FindControl("Chbk_ID") as CheckBox;
                if (Chk_Chbk.Checked)
                {
                    //委外发料
                    KNet.Model.Sc_Expend_Manage_MaterDetails Mode_MaterDetails1 = new KNet.Model.Sc_Expend_Manage_MaterDetails();
                    Mode_MaterDetails1.SED_SEMID = model.SEM_ID;
                    Mode_MaterDetails1.SED_HouseNo = this.Lbl_HouseNo.Text;
                    Mode_MaterDetails1.SED_ProductsBarCode = Tbx_ProductsBarCode.Text;
                    Mode_MaterDetails1.SED_Remarks = Tbx_Remarks.Text;
                    Mode_MaterDetails1.SED_FromHouseNo = "130088401935635079";//原材料库
                    Mode_MaterDetails1.SED_Code = GetIDByMonth(0, "4");

                    try
                    {
                        Mode_MaterDetails1.SED_RkNumber = int.Parse(Tbx_Number.Text);
                    }
                    catch { }
                    try
                    {
                        Mode_MaterDetails1.SED_RkPrice = decimal.Parse(SED_RkPrice);
                    }
                    catch { }
                    try
                    {
                        Mode_MaterDetails1.SED_RkMoney = decimal.Parse(SED_RkPrice) * int.Parse(Tbx_Number.Text);
                    }
                    catch { }
                    Mode_MaterDetails1.SED_RkPerson = this.Ddl_RkPerson.SelectedValue;
                    try
                    {
                        Mode_MaterDetails1.SED_RkTime = DateTime.Parse(this.Tbx_RkTime.Text);
                    }
                    catch { }
                    Mode_MaterDetails1.SED_Type = 4;
                    if (Mode_MaterDetails1.SED_RkNumber > 0)
                    {
                        arr_MaterDetails.Add(Mode_MaterDetails1);
                    }

                    //委外消耗
                    KNet.Model.Sc_Expend_Manage_MaterDetails Mode_MaterDetails2 = new KNet.Model.Sc_Expend_Manage_MaterDetails();
                    Mode_MaterDetails2.SED_SEMID = model.SEM_ID;
                    Mode_MaterDetails2.SED_HouseNo = this.Lbl_HouseNo.Text;
                    Mode_MaterDetails2.SED_ProductsBarCode = Tbx_ProductsBarCode.Text;
                    Mode_MaterDetails2.SED_Remarks = Tbx_Remarks.Text;
                    try
                    {
                        Mode_MaterDetails2.SED_RkNumber = int.Parse(Tbx_Number.Text);
                    }
                    catch { }
                    try
                    {
                        Mode_MaterDetails2.SED_RkPrice = decimal.Parse(SED_RkPrice);
                    }
                    catch { }
                    try
                    {
                        Mode_MaterDetails2.SED_RkMoney = decimal.Parse(SED_RkPrice) * int.Parse(Tbx_Number.Text);
                    }
                    catch { }
                    Mode_MaterDetails2.SED_RkPerson = this.Ddl_RkPerson.SelectedValue;
                    try
                    {
                        Mode_MaterDetails2.SED_RkTime = DateTime.Parse(this.Tbx_RkTime.Text);
                    }
                    catch { }
                    Mode_MaterDetails2.SED_Type = 5;
                    Mode_MaterDetails2.SED_Code = GetIDByMonth(0, "5");
                    if (Mode_MaterDetails2.SED_RkNumber > 0)
                    {
                        arr_MaterDetails.Add(Mode_MaterDetails2);
                    }
                }
            }
            model.arr_MaterDetails = arr_MaterDetails;
            return true;
        }
        catch
        {
            return false;
        }
    }


    private string GetIDByMonth(int i_num, string s_Type)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "Select isnull(Max(SED_Code),'') from Sc_Expend_Manage_MaterDetails Where Isnull(SED_Type,'0')='" + s_Type + "' and Year(SED_RkTime)='" + DateTime.Now.Year.ToString() + "' and Month(SED_RkTime)='" + DateTime.Now.Month.ToString() + "' ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            if (Dtb_Result.Rows.Count > 0)
            {
                if (Dtb_Result.Rows[0][0].ToString() == "")
                {
                    s_Return = DateTime.Today.ToString("yyyyMM") + "001";
                }
                s_Return = Convert.ToString(int.Parse(Dtb_Result.Rows[0][0].ToString()) + 1 + i_num);
            }
            else
            {
                s_Return = DateTime.Today.ToString("yyyyMM") + "001";
            }
        }
        catch { }
        return s_Return;
    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_ID = this.Tbx_ID.Text;
        KNet.Model.Sc_Expend_Manage model = new KNet.Model.Sc_Expend_Manage();
        KNet.BLL.Sc_Expend_Manage bll = new KNet.BLL.Sc_Expend_Manage();

        if (Chk_IsDetails.Checked)
        {
            if (this.SetValue(model) == false)
            {
                Alert("系统错误！");
                return;
            }
        }
        try
        {
            if (btn_Chcek.Text == "审批")
            {
                string DoSql = "update KNet_WareHouse_AllocateList  set AllocateCheckYN=2,AllocateCheckStaffNo ='" + AM.KNet_StaffNo + "'  where  AllocateNo='" + this.Tbx_ID.Text + "' ";
                DbHelperSQL.ExecuteSql(DoSql);
                btn_Chcek.Text = "反审批";
                bll.Add(model);
                if (Chk_IsDetails.Checked)
                {
                    AM.Add_Logs("原材料消耗增加" + this.Tbx_ID.Text);
                    AlertAndRedirect("原材料消耗成功！", "KNet_WareHouse_WareCheck_View.aspx?Type=1&ID=" + this.Tbx_ID.Text + "");
                }
                else
                {
                    AM.Add_Logs("审核成功" + this.Tbx_ID.Text);
                    AlertAndRedirect("审核成功！", "KNet_WareHouse_WareCheck_View.aspx?Type=1&ID=" + this.Tbx_ID.Text + "");
                }
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
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
            DropDownList Ddl_House = (DropDownList)e.Row.Cells[0].FindControl("Ddl_House");
            base.Base_DropWareHouseBindNoSelect(Ddl_House, "  SuppNo='129841337340625000' ");//杭州士腾的库存
        }
    }
    private void ShowInfo(string s_ID)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            KNet.BLL.KNet_WareHouse_AllocateList bll = new KNet.BLL.KNet_WareHouse_AllocateList();
            KNet.Model.KNet_WareHouse_AllocateList model = bll.GetModelB(s_ID);
            this.Tbx_ID.Text = s_ID;
            this.Lbl_Code.Text = model.AllocateNo;
            this.Lbl_Stime.Text = DateTime.Parse(model.AllocateDateTime.ToString()).ToShortDateString();
            this.Lbl_House_Out.Text = base.Base_GetHouseName(model.HouseNo);
            this.Lbl_House_int.Text = base.Base_GetHouseName(model.HouseNo_int);
            this.Lbl_House_int0.Text = model.HouseNo_int;
            this.Lbl_OrderNo.Text = model.KWA_OrderNo;
            this.Lbl_Remarks.Text = model.AllocateRemarks;
            this.Lbl_Case.Text = model.AllocateCause;


            this.Tbx_OrderNo.Text = "<a href=\"/Web/Cg/Order/Knet_Procure_OpenBilling_View_ForSc.aspx?ID=" + model.KWA_OrderNo + "\" target=\"_blank\">" + model.KWA_OrderNo + "</a>" ;
            this.Chk_Type.Text = base.Base_GetBasicCodeName("1132", model.KWA_DBType.ToString());
            if (model.AllocateCheckYN == 1)
            {
                btn_Chcek.Text = "反审批";
                if (AM.KNet_StaffName != "项洲")
                {
                    if (AM.YNAuthority("单据财务审批"))
                    {
                        this.btn_Chcek.Text = "财务审批";
                    }
                }
            }
            else if (model.AllocateCheckYN == 3)
            {

                this.btn_Chcek.Text = "反财务审批";
            }
            else
            {
                btn_Chcek.Text = "审批";
            }
            KNet.BLL.KNet_WareHouse_AllocateList_Details BLL_Details = new KNet.BLL.KNet_WareHouse_AllocateList_Details();
            string s_SqlWhere = " a.AllocateNo='" + model.AllocateNo + "' ";
            if (this.Lbl_OrderNo.Text != "")
            {
                s_SqlWhere += " and KWA_OrderNo='" + this.Lbl_OrderNo.Text + "' ";
                s_SqlWhere += " order by ProductsType,ProductsEdition,isnull(e.BomOrderDesc,0)";
            }

            DataSet Dts_Details = BLL_Details.GetList(s_SqlWhere);
            StringBuilder Sb_Details = new StringBuilder();
            if (Dts_Details.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    Sb_Details.Append( "<tr>");
                    Sb_Details.Append( "<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ID_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["ID"].ToString() + "'><input type=\"hidden\"  Name=\"OldNumber_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["AllocateAmount"].ToString() + "'>" + Convert.ToString(i + 1) + "</td>");
                    string s_BomOrder = "";
                    try
                    {
                        s_BomOrder = Dts_Details.Tables[0].Rows[i]["BomOrder"].ToString();
                    }
                    catch
                    { }
                    Sb_Details.Append( "<td class=\"ListHeadDetails\">" + s_BomOrder + "</td>");


                    this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                    Sb_Details.Append( "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append( "<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append( "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");


                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["KWAD_FaterBarCode"].ToString()) + "</td>");

                    string s_DBNumber = Dts_Details.Tables[0].Rows[i]["KWAD_SCDBNumber"].ToString() == "0" ? Dts_Details.Tables[0].Rows[i]["AllocateAmount"].ToString() : Dts_Details.Tables[0].Rows[i]["KWAD_SCDBNumber"].ToString();
                    string s_Number = Dts_Details.Tables[0].Rows[i]["AllocateAmount"].ToString();
                    string s_CPBZNumber = Dts_Details.Tables[0].Rows[i]["KWAD_CPBZNumber"].ToString() == "" ? "0" : Dts_Details.Tables[0].Rows[i]["KWAD_CPBZNumber"].ToString();
                    string s_BZNumber = Dts_Details.Tables[0].Rows[i]["KWAD_BZNumber"].ToString() == "" ? "0" : Dts_Details.Tables[0].Rows[i]["KWAD_BZNumber"].ToString();


                    Sb_Details.Append( "<td class=\"ListHeadDetails\">" + s_CPBZNumber + "</td>");
                    Sb_Details.Append( "<td class=\"ListHeadDetails\">" + s_BZNumber + "</td>");
                    Sb_Details.Append( "<td class=\"ListHeadDetails\">" + s_DBNumber + "</td>");

                    string s_BadNumber = Dts_Details.Tables[0].Rows[i]["KWAD_BadNumber"].ToString() == "" ? "0" : Dts_Details.Tables[0].Rows[i]["KWAD_BadNumber"].ToString();
                    string s_AddBadNumber = Dts_Details.Tables[0].Rows[i]["KWAD_AddBadNumber"].ToString() == "" ? "0" : Dts_Details.Tables[0].Rows[i]["KWAD_AddBadNumber"].ToString();

                    if ((model.AllocateCheckYN == 0) && ((AM.KNet_StaffDepart == "129757466300748845") || (AM.KNet_StaffName == "项洲")))
                    {
                        Sb_Details.Append( "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"BadNumber_" + i.ToString() + "\" value='" + s_BadNumber + "'></td>");
                        Sb_Details.Append( "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"AddBadNumber_" + i.ToString() + "\" value='" + s_AddBadNumber + "'></td>");
                        Sb_Details.Append( "<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" + i.ToString() + "\" value='" + s_Number + "'></td>");

                        string s_Sql = "Select isnull(Sum(NeedNumber),0)  from v_NeedNumberStore where ProductsBarCode='" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "' and HouseNo='" + this.Lbl_House_int0.Text + "'  ";
                        this.BeginQuery(s_Sql);
                        string s_NeedNumber = this.QueryForReturn();
                        Sb_Details.Append("<td class=\"ListHeadDetails\">");
                        Sb_Details.Append("<a href=\"/Web/Sc/Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "&HouseNo=" + this.Lbl_House_int0.Text  + "\" target=\"_blank\">" + s_NeedNumber + "</a>\n");

                        Sb_Details.Append("</td>");
                        
                        
                    }
                    else
                    {
                        Sb_Details.Append( "<td class=\"ListHeadDetails\">" + s_BadNumber + "</td>");
                        Sb_Details.Append( "<td class=\"ListHeadDetails\">" + s_AddBadNumber + "</td>");
                        Sb_Details.Append("<td class=\"ListHeadDetails\">" + s_Number + "</td>");

                        string s_Sql = "Select isnull(Sum(NeedNumber),0)  from v_NeedNumberStore where ProductsBarCode='" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "' and HouseNo='" + this.Lbl_House_int0.Text + "'  ";
                        this.BeginQuery(s_Sql);
                        string s_NeedNumber = this.QueryForReturn();
                        Sb_Details.Append("<td class=\"ListHeadDetails\">");
                        Sb_Details.Append("<a href=\"/Web/Sc/Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "&HouseNo=" + this.Lbl_House_int0.Text + "\" target=\"_blank\">" + s_NeedNumber + "</a>\n");

                        Sb_Details.Append("</td>");
                        

                    }

                    string s_CateNumber = "";
                    try {
                        s_CateNumber = Convert.ToString(int.Parse(s_DBNumber) - int.Parse(s_Number));
                    }
                    catch
                    { }
                    Sb_Details.Append( "<td class=\"ListHeadDetails\"><font color=red>" + s_CateNumber + "</font></td>");

                    Sb_Details.Append( "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["AllocateUnitPrice"].ToString() + "</td>");
                    Sb_Details.Append( "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["AllocateTotalNet"].ToString() + "</td>");
                    Sb_Details.Append( "<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["AllocateRemarks"].ToString() + "&nbsp;</td>");

                    Sb_Details.Append( "</tr>");
                }
                this.Tbx_Num.Text = Dts_Details.Tables[0].Rows.Count.ToString(); ;

            }
            Lbl_Details.Text +=Sb_Details.ToString();
        }
        catch(Exception ex)
        { }
    }

}

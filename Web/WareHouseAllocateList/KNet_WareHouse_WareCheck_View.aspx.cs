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
using KNet.BLL;
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
                // Pan_Detail.Visible = true;
                Table_Btn.Visible = false;
            }
            else
            {
                s_DetailsStyle = "class=\"dvtUnSelectedCell\"";
                s_OrderStyle = "class=\"dvtSelectedCell\"";
                Pan_Order.Visible = true;
                //  Pan_Detail.Visible = false;
                Table_Btn.Visible = true;
            }
            this.Lbl_Title.Text = "查看调拨";
            if (s_ID != "")
            {
                ShowInfo(s_ID);
            }


            /*KNet.BLL.Sc_Expend_Manage bll_Manage = new KNet.BLL.Sc_Expend_Manage();
            string SqlWhere = " SEM_Type=1 and SEM_DirectOutNO='" + s_ID + "' ";
            SqlWhere = SqlWhere + " order by SEM_MTime desc";
            DataSet ds_Manage = bll_Manage.GetList(SqlWhere);
            GridView1.DataSource = ds_Manage;
            GridView1.DataKeyNames = new string[] { "SEM_ID" };
            GridView1.DataBind();
             * */
        }

    }

    public string GetDbState(string s_ScOrderNo, int i_Type)
    {
        string s_Return = "";
        try
        {
            if (i_Type == 0)
            {
                string s_Sql = "select max(ProductsBarCode) ProductsBarCode from Knet_Procure_OrdersList_Details a left join KNet_WareHouse_AllocateList_CPDetails b ";
                s_Sql += " on a.ID=b.KWAC_OrderNoID where b.KWAC_AllocateNo='" + s_ScOrderNo + "' group by  a.id order by a.id";
                this.BeginQuery(s_Sql);
                this.QueryForDataTable();
                if (this.Dtb_Result.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                    {
                        s_Return += base.Base_GetProdutsName_Link(Dtb_Result.Rows[i]["ProductsBarCode"].ToString());

                        s_Return += "<br/>";
                    }
                }
            }
            else if (i_Type == 1)
            {
                string s_Sql = "select Sum(isnull(KWAC_Number,0)) KWAC_Number from Knet_Procure_OrdersList_Details a left join KNet_WareHouse_AllocateList_CPDetails b ";
                s_Sql += " on a.ID=b.KWAC_OrderNoID where b.KWAC_AllocateNo='" + s_ScOrderNo + "' group by  a.id order by a.id";
                this.BeginQuery(s_Sql);
                this.QueryForDataTable();
                if (this.Dtb_Result.Rows.Count > 0)
                {
                    for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                    {
                        s_Return += Dtb_Result.Rows[i]["KWAC_Number"].ToString();

                        s_Return += "<br/>";
                    }
                }
            }
        }
        catch
        { }
        return s_Return;
    }


    public string GetDirectInProductsPatten(string s_Order)
    {
        string s_Return = "";
        this.BeginQuery("Select * from KNet_WareHouse_AllocateList_Details Where AllocateNo='" + s_Order + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            if (Dtb_Result.Rows.Count < 5)
            {
                for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                {
                    s_Return += base.Base_GetProductsEdition_Link(Dtb_Result.Rows[i]["ProductsBarCode"].ToString()) + "<br>";
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    s_Return += base.Base_GetProductsEdition_Link(Dtb_Result.Rows[i]["ProductsBarCode"].ToString()) + "<br>";
                }
                s_Return += "<font color=gray>更多...</font>" + "<br>";
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 1);
        }
        return s_Return;
    }

    /// <summary>
    /// 退货产品总数量
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string GetDirectInNumbers(string s_Order)
    {
        string s_Return = "";
        this.BeginQuery("Select Sum(KWAD_AddBadNumber) as AllocateAmount from KNet_WareHouse_AllocateList_Details Where AllocateNo='" + s_Order + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return = Dtb_Result.Rows[i]["AllocateAmount"].ToString();
            }
        }
        return s_Return;
    }

    public string GetCheck(string s_AllocateNo)
    {
        string s_Return = "";
        try
        { }
        catch
        { }
        KNet.BLL.KNet_WareHouse_AllocateList Bll = new KNet.BLL.KNet_WareHouse_AllocateList();
        KNet.Model.KNet_WareHouse_AllocateList model = Bll.GetModelB(s_AllocateNo);
        if (model != null)
        {
            if (model.AllocateCheckYN == 0)
            {
                s_Return = "<a href=\"KNet_WareHouse_WareCheck_View.aspx?ID=" + s_AllocateNo + "&HouseQR=1\"><font color=\"red\">确认</font></a>";
            }
            else
            {
                s_Return = "<font color=blue>已确认</font>";
            }

            if (model.KWA_IsSave == 1)
            {

                s_Return += "<BR/><font color=blue>已暂存</font>";
            }
        }
        return s_Return;

    }

    /// <summary>
    /// 返回审核情况
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetOrderCheckYN(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,AllocateNo,AllocateCheckYN from KNet_WareHouse_AllocateList where AllocateNo='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["AllocateCheckYN"].ToString() == "3")
                {
                    return "<font color=red>反财务审</font>";
                }
                else if (dr["AllocateCheckYN"].ToString() == "1")
                {
                    return "部门审批";
                }
                else
                {
                    return "<font color=blue>财务审批</font>";
                }
            }
            else
            {
                return "--";
            }
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
                            string s_BadNumber = Request.Form["BadNumber_" + i.ToString()] == null ? "" : Request.Form["BadNumber_" + i.ToString()].ToString();
                            string s_AddBadNumber = Request.Form["AddBadNumber_" + i.ToString()] == null ? "" : Request.Form["AddBadNumber_" + i.ToString()].ToString();



                            DoSql = "update KNet_WareHouse_AllocateList_Details  set AllocateAmount='" + s_Number + "',KWAD_OldNumber='" + s_Number + "' ,KWAD_BadNumber='" + s_BadNumber + "' ,KWAD_AddBadNumber='" + s_AddBadNumber + "'  where  ID='" + s_ID + "' ";
                            DbHelperSQL.ExecuteSql(DoSql);

                        }
                    }
                    DoSql = "update KNet_WareHouse_AllocateList  set KWA_IsSave='0' where  AllocateNo='" + this.Tbx_ID.Text + "' ";
                    DbHelperSQL.ExecuteSql(DoSql);
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
                if (AM.YNAuthority("单据财务审批"))
                {
                    string DoSql = "update KNet_WareHouse_AllocateList  set AllocateCheckYN=3  where  AllocateNo='" + this.Tbx_ID.Text + "' ";
                    DbHelperSQL.ExecuteSql(DoSql);
                    btn_Chcek.Text = "反财务审批";
                    AM.Add_Logs("财务审批成功" + this.Tbx_ID.Text);
                    AlertAndRedirect("财务审批成功！", "KNet_WareHouse_WareCheck_View.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            else if (btn_Chcek.Text == "反财务审批")
            {
                if (AM.YNAuthority("单据财务审批"))
                {
                    string DoSql = "update KNet_WareHouse_AllocateList  set AllocateCheckYN=1  where  AllocateNo='" + this.Tbx_ID.Text + "' ";
                    DbHelperSQL.ExecuteSql(DoSql);
                    btn_Chcek.Text = "反财务审批";
                    AM.Add_Logs("反财务审批成功" + this.Tbx_ID.Text);
                    AlertAndRedirect("反财务审批成功！", "KNet_WareHouse_WareCheck_View.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }

        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }


    protected void btn_Chcek1_Click1(object sender, EventArgs e)
    {
        try
        {
            string DoSql = "";
            for (int i = 0; i < int.Parse(this.Tbx_Num.Text); i++)
            {
                if (Request["ID_" + i.ToString()] != null)
                {
                    string s_ID = Request.Form["ID_" + i.ToString()] == null ? "" : Request.Form["ID_" + i.ToString()].ToString();
                    string s_Number = Request.Form["Number_" + i.ToString()] == null ? "" : Request.Form["Number_" + i.ToString()].ToString();
                    string s_OldNumber = Request.Form["OldNumber_" + i.ToString()] == null ? "" : Request.Form["OldNumber_" + i.ToString()].ToString();
                    string s_BadNumber = Request.Form["BadNumber_" + i.ToString()] == null ? "" : Request.Form["BadNumber_" + i.ToString()].ToString();
                    string s_AddBadNumber = Request.Form["AddBadNumber_" + i.ToString()] == null ? "" : Request.Form["AddBadNumber_" + i.ToString()].ToString();


                    DoSql = "update KNet_WareHouse_AllocateList_Details  set KWAD_SCDBNumber='" + s_OldNumber + "' where  ID='" + s_ID + "' and KWAD_SCDBNumber=0 ";
                    DbHelperSQL.ExecuteSql(DoSql);

                    DoSql = "update KNet_WareHouse_AllocateList_Details  set AllocateAmount='" + s_Number + "',KWAD_OldNumber='" + s_Number + "' ,KWAD_BadNumber='" + s_BadNumber + "' ,KWAD_AddBadNumber='" + s_AddBadNumber + "'  where  ID='" + s_ID + "' ";
                    DbHelperSQL.ExecuteSql(DoSql);
                }
            }

            DoSql = "update KNet_WareHouse_AllocateList  set KWA_IsSave='1' where  AllocateNo='" + this.Tbx_ID.Text + "' ";
            DbHelperSQL.ExecuteSql(DoSql);
        }
        catch { }
        AlertAndRedirect("暂存成功！", "KNet_WareHouse_WareCheck_View.aspx?ID=" + this.Tbx_ID.Text + "");

    }

    /*
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
    */

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

    /*
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
     * */
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
            KNet.BLL.KNet_WareHouse_DirectOutList kwd=new KNet_WareHouse_DirectOutList();
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
            this.KWA_UploadUrl.Text = "<a href=\"" + model.KWA_UploadUrl + "\" >" + model.KWA_UploadName + "</a>"; ;
            if (model.KWA_IsEntity.ToString()=="1")
            {
                KWA_IsEntity.Checked = true;
            }
            else
            {
                KWA_IsEntity.Checked = false;
            }
            try
            {
                string SqlWhere = " AllocateNo='" + s_ID + "'";
                SqlWhere += " and KWA_DBType='0'   ";
                SqlWhere += " and  AllocateNo in( select b.AllocateNo  FROM       dbo.KNet_WareHouse_AllocateList_Details AS b INNER JOIN";
                SqlWhere += "         dbo.KNet_WareHouse_AllocateList AS a ON a.AllocateNo = b.AllocateNo  where b.KWAD_AddBadNumber<>0 ";
                SqlWhere += "  )  ";
                SqlWhere = SqlWhere + " order by systemDateTimes desc";
                DataSet ds = bll.GetList(SqlWhere);
                GridView1.DataSource = ds;
                GridView1.DataKeyNames = new string[] { "AllocateNo" };
                GridView1.DataBind();
                //string s_Sql = "select* from KNet_WareHouse_DirectOutList_Details a join KNet_WareHouse_DirectOutList b on a.DirectOutNo=b.DirectOutNo where KWD_AllocateNo='" + s_ID + "';";
                //this.BeginQuery(s_Sql);
                //this.QueryForDataTable();
                string SqlWhere1 = " KWD_AllocateNo='" + s_ID + "'";
                DataSet ds1 = kwd.GetList1(SqlWhere1);
                MyGridView1.DataSource = ds1;
                MyGridView1.DataKeyNames = new string[] { "DirectOutNo" };
                MyGridView1.DataBind();
            }
            catch
            { }

            this.Tbx_OrderNo.Text = "<a href=\"/Web/Cg/Order/Knet_Procure_OpenBilling_View_ForSc.aspx?ID=" + model.KWA_OrderNo + "\" target=\"_blank\">" + model.KWA_OrderNo + "</a>";
            this.Chk_Type.Text = base.Base_GetBasicCodeName("1132", model.KWA_DBType.ToString());
            if (model.AllocateCheckYN == 1)
            {
                btn_Chcek.Text = "反审批";
                btn_Chcek1.Visible = false;
                if (AM.KNet_StaffName != "薛建新")
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
                btn_Chcek1.Visible = false;

                if (AM.YNAuthority("单据财务审批"))
                {
                    btn_Chcek.Visible = true;
                }
                else
                {
                    btn_Chcek.Visible = false;
                }
            }
            else
            {
                btn_Chcek.Text = "审批";
                btn_Chcek1.Visible = true;
            }
            KNet.BLL.KNet_WareHouse_AllocateList_Details BLL_Details = new KNet.BLL.KNet_WareHouse_AllocateList_Details();
            string s_SqlWhere = " a.AllocateNo='" + model.AllocateNo + "' ";
            if (this.Lbl_OrderNo.Text != "")
            {
                s_SqlWhere += " and KWA_OrderNo='" + this.Lbl_OrderNo.Text + "' ";
                s_SqlWhere += " order by c.ksp_Code,c.ProductsName";
            }

            DataSet Dts_Details = BLL_Details.GetList(s_SqlWhere);
            StringBuilder Sb_Details = new StringBuilder();
            Sb_Details.Append(" <tr valign=\"top\">");
            Sb_Details.Append("  <td class=\"ListHead\" nowrap><b>序号</b></td>");
            Sb_Details.Append("  <td class=\"ListHead\" nowrap><b>BOM序号</b></td>");
            Sb_Details.Append("  <td class=\"ListHead\" nowrap><b>产品名称</b></td>");
            Sb_Details.Append(" <td class=\"ListHead\" nowrap><b>产品编码</b></td>");
            Sb_Details.Append(" <td class=\"ListHead\" nowrap><b>型号</b></td>");
            Sb_Details.Append(" <td class=\"ListHead\" nowrap><b>上级型号</b></td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap><b>最小包装</b></td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap><b>包数</b></td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap><b>调拨数量</b></td>");
            if (Chk_Type.Text != "原材料调拨")
            {

                Sb_Details.Append(" <td class=\"ListHead\" nowrap><b>士腾不良品</b></td>");
                Sb_Details.Append("<td class=\"ListHead\" nowrap><b>加工厂不良品</b></td>");
                Sb_Details.Append("<td class=\"ListHead\" nowrap><b>报废数量</b></td>");
            }
            Sb_Details.Append("<td class=\"ListHead\" nowrap><b>确认数量</b></td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap><b>缺料数量</b></td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap><b>差额数量</b></td>");
            Sb_Details.Append(" <td class=\"ListHead\" nowrap><b>单价</b></td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap><b>金额</b></td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap><b>备注</b></td>");
            Sb_Details.Append("</tr>");
            if (Dts_Details.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Details.Tables[0].Rows.Count; i++)
                {
                    Sb_Details.Append("<tr>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"hidden\"  Name=\"ID_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["ID"].ToString() + "'><input type=\"hidden\"  Name=\"OldNumber_" + i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["AllocateAmount"].ToString() + "'>" + Convert.ToString(i + 1) + "</td>");
                    string s_BomOrder = "";
                    try
                    {
                        s_BomOrder = Dts_Details.Tables[0].Rows[i]["BomOrder"].ToString();
                    }
                    catch
                    { }
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + s_BomOrder + "</td>");


                    this.Xs_ProductsCode.Text += Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + ",";
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");


                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["KWAD_FaterBarCode"].ToString()) + "</td>");

                    string s_DBNumber = Dts_Details.Tables[0].Rows[i]["KWAD_SCDBNumber"].ToString() == "0" ? Dts_Details.Tables[0].Rows[i]["AllocateAmount"].ToString() : Dts_Details.Tables[0].Rows[i]["KWAD_SCDBNumber"].ToString();
                    string s_Number = Dts_Details.Tables[0].Rows[i]["AllocateAmount"].ToString();
                    string s_CPBZNumber = Dts_Details.Tables[0].Rows[i]["KWAD_CPBZNumber"].ToString() == "" ? "0" : Dts_Details.Tables[0].Rows[i]["KWAD_CPBZNumber"].ToString();
                    string s_BZNumber = Dts_Details.Tables[0].Rows[i]["KWAD_BZNumber"].ToString() == "" ? "0" : Dts_Details.Tables[0].Rows[i]["KWAD_BZNumber"].ToString();


                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + s_CPBZNumber + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + s_BZNumber + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + s_DBNumber + "</td>");

                    string s_BadNumber = Dts_Details.Tables[0].Rows[i]["KWAD_BadNumber"].ToString() == "" ? "0" : Dts_Details.Tables[0].Rows[i]["KWAD_BadNumber"].ToString();
                    string s_AddBadNumber = Dts_Details.Tables[0].Rows[i]["KWAD_AddBadNumber"].ToString() == "" ? "0" : Dts_Details.Tables[0].Rows[i]["KWAD_AddBadNumber"].ToString();
                    string s_BFNumber = Dts_Details.Tables[0].Rows[i]["KWAD_BFNumber"].ToString() == "" ? "0" : Dts_Details.Tables[0].Rows[i]["KWAD_BFNumber"].ToString();

                    if ((model.AllocateCheckYN == 0))
                    {
                        if (Chk_Type.Text != "原材料调拨")
                        {

                            Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"BadNumber_" + i.ToString() + "\" value='" + s_BadNumber + "'></td>");
                            Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"AddBadNumber_" + i.ToString() + "\" value='" + s_AddBadNumber + "'></td>");
                            Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"BFNumber_" + i.ToString() + "\" value='" + s_BFNumber + "'></td>");
                        }
                        Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" + i.ToString() + "\" value='" + s_Number + "'></td>");

                        string s_Sql = "Select isnull(Sum(NeedNumber),0)  from v_NeedNumberStore where ProductsBarCode='" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "' and HouseNo='" + this.Lbl_House_int0.Text + "'  ";
                        this.BeginQuery(s_Sql);
                        string s_NeedNumber = this.QueryForReturn();
                        Sb_Details.Append("<td class=\"ListHeadDetails\">");
                        Sb_Details.Append("<a href=\"/Web/Sc/Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "&HouseNo=" + this.Lbl_House_int0.Text + "\" target=\"_blank\">" + s_NeedNumber + "</a>\n");

                        Sb_Details.Append("</td>");


                    }
                    else
                    {
                        if (Chk_Type.Text != "原材料调拨")
                        {

                            Sb_Details.Append("<td class=\"ListHeadDetails\">" + s_BadNumber + "</td>");
                            Sb_Details.Append("<td class=\"ListHeadDetails\">" + s_AddBadNumber + "</td>");
                        }
                        Sb_Details.Append("<td class=\"ListHeadDetails\">" + s_Number + "</td>");

                        string s_Sql = "Select isnull(Sum(NeedNumber),0)  from v_NeedNumberStore where ProductsBarCode='" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "' and HouseNo='" + this.Lbl_House_int0.Text + "'  ";
                        this.BeginQuery(s_Sql);
                        string s_NeedNumber = this.QueryForReturn();
                        Sb_Details.Append("<td class=\"ListHeadDetails\">");
                        Sb_Details.Append("<a href=\"/Web/Sc/Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "&HouseNo=" + this.Lbl_House_int0.Text + "\" target=\"_blank\">" + s_NeedNumber + "</a>\n");

                        Sb_Details.Append("</td>");


                    }

                    string s_CateNumber = "";
                    try
                    {
                        s_CateNumber = Convert.ToString(int.Parse(s_DBNumber) - int.Parse(s_Number));
                    }
                    catch
                    { }
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><font color=red>" + s_CateNumber + "</font></td>");

                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["AllocateUnitPrice"].ToString() + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["AllocateTotalNet"].ToString() + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + Dts_Details.Tables[0].Rows[i]["AllocateRemarks"].ToString() + "&nbsp;</td>");

                    Sb_Details.Append("</tr>");
                }
                this.Tbx_Num.Text = Dts_Details.Tables[0].Rows.Count.ToString(); ;

            }
            Lbl_Details.Text += Sb_Details.ToString();
        }
        catch (Exception ex)
        { }
    }

}

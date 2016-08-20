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
using System.Text;
using System.IO;
using System.Data.SqlClient;
using KNet.DBUtility;
using KNet.Common;

public partial class Procure_MaterialWw_List : BasePage
{
    public string s_AdvShow = "";
    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("原材料耗料单") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                this.DataBind();
            }

            this.Btn_Show.Attributes.Add("onclick", "return confirm('您确定要显示全部吗？')");
            this.BtnSave.Attributes.Add("onclick", "return confirm('您确定要计算选择的委外单价吗？')");
            base.Base_DropBindSearch(this.bas_searchfield, "Cg_Order_MaterialHl");
            base.Base_DropBindSearch(this.Fields, "Cg_Order_MaterialHl");
            this.ImgB.Attributes.Add("onclick", "return confirm('你确定要导出所包含的数据么？')");
        }
    }


    private void DataBind()
    {
        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        this.Tbx_WhereID.Text = s_WhereID;
        string s_WhereID1 = Request.QueryString["WhereID1"] == null ? "" : Request.QueryString["WhereID1"].ToString();
        this.Tbx_WhereID1.Text = s_WhereID1;
        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string s_Type = "";

        string s_Sql = "SELECT  ID,SED_ID, HouseNo, ProductsName, ProductsBarCode, ProductsPattern, ProductsEdition, ProductsUnits, -SED_RkNumber SED_RkNumber , ";
        s_Sql += "SED_WwPrice, SED_RkTime,SED_WwPrice,-SED_WwMoney SED_WwMoney,SED_RkPrice,SED_RkMoney SED_RkMoney,SEM_CheckYN,WwMoney,WwPrice,typeName,SED_QCNumber,SED_QCMoney,SED_CGNumber,SED_CGMoney";
        s_Sql += " from  v_Cw_Sc_Expend_Manage_MaterDetails a ";
        string SqlWhere = " where  1=1 ";
        AdminloginMess AM = new AdminloginMess();

        if (this.Tbx_WhereID.Text != "")
        {
            SqlWhere += Base_GetBasicWhere(this.Tbx_WhereID.Text);
        }
        if (this.Tbx_WhereID1.Text != "")
        {
            SqlWhere += Base_GetBasicWhere(this.Tbx_WhereID1.Text);
        }
        

        if ((this.bas_searchfield.SelectedValue != "") && (search_text.Text != ""))
        {
            SqlWhere += base.Base_GetBasicColumnWhere(this.bas_searchfield.SelectedValue, this.search_text.Text);
        }
        if (s_Text != "")
        {
            if (this.matchtype1.Checked == true)//and
            {
                s_Type = "0";
            }
            if (this.matchtype2.Checked == true)
            {
                s_Type = "1";
            }
            SqlWhere += base.Base_GetAdvWhere(s_Fields, s_Condition, s_Text, s_Type);
        }
        this.BeginQuery(s_Sql + SqlWhere + " Order by SED_RkTime desc");
        this.QueryForDataSet();
        DataSet ds = Dts_Result;
        Session["Dts_RTable"] = ds;
        this.MyGridView1.DataSource = ds;
        this.MyGridView1.DataKeyNames = new string[] { "ID" };
        this.MyGridView1.DataBind();


        decimal d_totalNum = 0, d_totalMoney = 0, d_TotalTaxMoney = 0;
        try
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                d_totalNum += decimal.Parse(ds.Tables[0].Rows[i]["SED_RkNumber"].ToString());
                d_totalMoney += decimal.Parse(ds.Tables[0].Rows[i]["SED_RkMoney"].ToString());
                d_TotalTaxMoney += decimal.Parse(ds.Tables[0].Rows[i]["SED_WwMoney"].ToString());
            }
            Lbl_Total.Text = "总数量：<font color=red>" + d_totalNum.ToString() + "</font> | 总金额：<font color=red>" + d_totalMoney.ToString() + "</font> | 总不含税金额：<font color=red>" + d_TotalTaxMoney.ToString() + "</font>";

        }
        catch { }
    }

    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        this.DataBind();
    }
    /// <summary>
    /// 获取出库单明细数目
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu(string DirectOutNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as IDS  from KNet_WareHouse_DirectOutList_Details where DirectOutNo='" + DirectOutNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return int.Parse(dr["IDS"].ToString().Trim().ToString());
            }
            else
            {
                return -1;
            }
        }
    }

    public void btnBasicSearch_Click(object sender, EventArgs e)
    {
        this.advSearch.Style["display"] = "none";
        this.Search_basic.Style["display"] = "block";
        this.DataBind();
    }


    public void btnAdvancedSearch_Click(object sender, EventArgs e)
    {
        this.Search_basic.Style["display"] = "none";
        this.advSearch.Style["display"] = "block";

        string s_Fields = Request["Fields"] == null ? "" : Request["Fields"].ToString();
        string s_Condition = Request["Condition"] == null ? "" : Request["Condition"].ToString();
        string s_Text = Request["Srch_value"] == null ? "" : Request["Srch_value"].ToString();
        string[] arr_Fields = s_Fields.Split(',');
        string[] arr_Condition = s_Condition.Split(',');
        string[] arr_Text = s_Text.Split(',');
        this.Fields.SelectedValue = arr_Fields[0];
        this.Condition.SelectedValue = arr_Condition[0];
        this.Srch_value.Text = arr_Text[0];
        s_AdvShow = Base_GetAdvShowHtml(arr_Fields, arr_Condition, arr_Text, "Cg_Order_MaterialHl");
        this.DataBind();
    }

    public string GetKC(string s_ID, int i_Type)
    {
        string s_ProductsBarCode = "", s_BTime = "", s_ETime = "", s_HouseNo = "", s_Price = "", s_Return = "", s_Number = "";
        if (this.Tbx_Num.Text == "1")
        {
            KNet.BLL.Sc_Expend_Manage_MaterDetails Bll = new KNet.BLL.Sc_Expend_Manage_MaterDetails();
            KNet.Model.Sc_Expend_Manage_MaterDetails Model = Bll.GetModel(s_ID);
            try
            {
                if (Model != null)
                {
                    KNet.BLL.Sc_Expend_Manage BllCheck = new KNet.BLL.Sc_Expend_Manage();
                    KNet.Model.Sc_Expend_Manage ModelCheck = BllCheck.GetModel(Model.SED_SEMID);
                    KNet.BLL.KNet_Sys_WareHouse Bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                    KNet.Model.KNet_Sys_WareHouse Model_WareHouse = Bll_WareHouse.GetModel(Model.SED_HouseNo);
                    if (Model_WareHouse != null)
                    {
                        s_HouseNo = Model_WareHouse.SuppNo;
                    }
                    if (Model != null)
                    {
                        s_ProductsBarCode = Model.SED_ProductsBarCode;
                        s_Number = Model.SED_RkMoney.ToString();
                        DateTime datetime = DateTime.Parse(ModelCheck.SEM_Stime.ToString());
                        //月初
                        s_BTime = datetime.AddDays(1 - datetime.Day).ToShortDateString();
                        //月末
                        s_ETime = datetime.AddDays(1 - datetime.Day).AddMonths(1).AddDays(-1).ToShortDateString();

                    }
                    try
                    {
                        string s_Sql = "select Sum(case when DirectInDateTime<'" + s_BTime + "' then DirectInAmount else 0 end) as QCNumber,";
                        s_Sql += "Sum(case when DirectInDateTime<'" + s_BTime + "' then DirectINTotalNet else 0 end) QCMoney";
                        s_Sql += ",Sum(case when DirectInDateTime>='" + s_BTime + "' and DirectInDateTime<='" + s_ETime + "' and type='119' then DirectInAmount else 0 end) CGNumber";
                        s_Sql += ",Sum(case when  DirectInDateTime>='" + s_BTime + "' and DirectInDateTime<='" + s_ETime + "' and type='119' then DirectINTotalNet else 0 end) CGMoney";
                        s_Sql += " from v_Store ";
                        s_Sql += " Where ProductsBarCode='" + s_ProductsBarCode + "' and HouseNo='" + s_HouseNo + "'  ";
                        this.BeginQuery(s_Sql);
                        this.QueryForDataTable();
                        DataTable Dtb_Table = Dtb_Result;
                        if (i_Type == 4)
                        {
                            try
                            {
                                decimal d_TotalMoney = decimal.Parse(Dtb_Table.Rows[0][1].ToString()) + decimal.Parse(Dtb_Table.Rows[0][3].ToString());
                                decimal d_TotalNumber = decimal.Parse(Dtb_Table.Rows[0][0].ToString()) + decimal.Parse(Dtb_Table.Rows[0][2].ToString());
                                decimal d_Price = d_TotalMoney / d_TotalNumber;
                                return base.FormatNumber1(d_Price.ToString(), 5);
                            }
                            catch
                            { }
                        }
                        if (Dtb_Table != null)
                        {
                            return Dtb_Table.Rows[0][i_Type].ToString();
                        }
                    }
                    catch { }
                }
                else
                {
                    //电池
                    KNet.BLL.KNet_WareHouse_DirectOutList_Details BllDirectOut_Details = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
                    KNet.Model.KNet_WareHouse_DirectOutList_Details ModelCheck_Details = BllDirectOut_Details.GetModel(s_ID);
                    KNet.BLL.KNet_WareHouse_DirectOutList BllDirectOut = new KNet.BLL.KNet_WareHouse_DirectOutList();
                    KNet.Model.KNet_WareHouse_DirectOutList ModelCheck = BllDirectOut.GetModelB(ModelCheck_Details.DirectOutNo);
                    KNet.BLL.KNet_Sys_WareHouse Bll_WareHouse = new KNet.BLL.KNet_Sys_WareHouse();
                    KNet.Model.KNet_Sys_WareHouse Model_WareHouse = Bll_WareHouse.GetModel(ModelCheck.HouseNo);

                    if (Model_WareHouse != null)
                    {
                        s_HouseNo = Model_WareHouse.SuppNo;
                    }
                    if (ModelCheck_Details != null)
                    {
                        s_ProductsBarCode = ModelCheck_Details.ProductsBarCode;
                    }
                    if (ModelCheck != null)
                    {
                        DateTime datetime = DateTime.Parse(ModelCheck.DirectOutDateTime.ToString());
                        //月初
                        s_BTime = datetime.AddDays(1 - datetime.Day).ToShortDateString();
                        s_ETime = datetime.AddDays(1 - datetime.Day).AddMonths(1).AddDays(-1).ToShortDateString();
                    }

                    try
                    {
                        string s_Sql = "select Sum(case when DirectInDateTime<'" + s_BTime + "' then DirectInAmount else 0 end) as QCNumber,";
                        s_Sql += "Sum(case when DirectInDateTime<'" + s_BTime + "' then DirectINTotalNet else 0 end) QCMoney";
                        s_Sql += ",Sum(case when DirectInDateTime>='" + s_BTime + "' and DirectInDateTime<='" + s_ETime + "' and type='119' then DirectInAmount else 0 end) CGNumber";
                        s_Sql += ",Sum(case when  DirectInDateTime>='" + s_BTime + "' and DirectInDateTime<='" + s_ETime + "' and type='119' then DirectINTotalNet else 0 end) CGMoney";
                        s_Sql += " from v_Store ";
                        s_Sql += " Where ProductsBarCode='" + s_ProductsBarCode + "' and HouseNo='" + s_HouseNo + "'  ";
                        this.BeginQuery(s_Sql);
                        this.QueryForDataTable();
                        DataTable Dtb_Table = Dtb_Result;
                        if (i_Type == 4)
                        {
                            try
                            {
                                decimal d_TotalMoney = decimal.Parse(Dtb_Table.Rows[0][1].ToString()) + decimal.Parse(Dtb_Table.Rows[0][3].ToString());
                                decimal d_TotalNumber = decimal.Parse(Dtb_Table.Rows[0][0].ToString()) + decimal.Parse(Dtb_Table.Rows[0][2].ToString());
                                decimal d_Price = d_TotalMoney / d_TotalNumber;
                                return base.FormatNumber1(d_Price.ToString(), 5);
                            }
                            catch
                            { }
                        }
                        if (Dtb_Table != null)
                        {
                            return Dtb_Table.Rows[0][i_Type].ToString();
                        }
                    }
                    catch { }
                }
            }
            catch { }
       
       
 
        }
        
        return s_Return;
    }

    public string GetShDetails(string s_COC_Code)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.Cg_Order_Checklist Bll = new KNet.BLL.Cg_Order_Checklist();
            KNet.Model.Cg_Order_Checklist Model = Bll.GetModel(s_COC_Code);
            if (Model.COC_CheckYN == 1)
            {//已审核
                if (Model.COC_Type == "1")
                {
                    s_Return = "<a href='Procure_MaterialIn_View.aspx?ID=" + s_COC_Code + "&Type=1' target=\"_blank\">原材料委外单</a>";

                }
                else
                {
                    s_Return = "已审核";
                }
            }
            else
            {
                s_Return = "未审核";
            }
        }
        catch (Exception ex) { }
        return s_Return;
    }



    protected void BtnSave_Click(object sender, EventArgs e)
    {
       /*
        this.Tbx_Num.Text = "1";
        this.DataBind();
        KNet.BLL.Sc_Expend_Manage_MaterDetails Bll = new KNet.BLL.Sc_Expend_Manage_MaterDetails();
        int i_Num = 0;
        for (int i = 0; i < MyGridView1.Rows.Count; i++)
        {
            CheckBox chb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
            TextBox Tbx_Number = (TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_Number");
            TextBox Tbx_Price = (TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_Price");
            string s_ID = MyGridView1.DataKeys[i].Value.ToString();
            if (s_ID.Length == 12)
            {

                KNet.Model.Sc_Expend_Manage_MaterDetails Model = new KNet.Model.Sc_Expend_Manage_MaterDetails();
                if (chb.Checked)
                {
                    Model.SED_ID = s_ID;
                    Model.SED_WwPrice = decimal.Parse(Tbx_Price.Text == "" ? "0" : Tbx_Price.Text);
                    Model.SED_WwMoney = Model.SED_WwPrice * decimal.Parse(Tbx_Number.Text == "" ? "0" : Tbx_Number.Text);
                    try
                    {
                        if (Bll.UpdateWwPrice(Model))
                        {
                            i_Num = i_Num + 1;
                        }
                        else
                        {
                        }
                    }
                    catch
                    { }
                }
            }
            else
            {

                KNet.Model.KNet_WareHouse_DirectOutList_Details Model = new KNet.Model.KNet_WareHouse_DirectOutList_Details();
                if (chb.Checked)
                {
                    decimal d_Price=decimal.Parse(Tbx_Price.Text == "" ? "0" : Tbx_Price.Text);
                    decimal d_Number=decimal.Parse(Tbx_Number.Text == "" ? "0" : Tbx_Number.Text);
                    string s_Sql = "Update KNet_WareHouse_DirectOutList_Details set KWD_WwPrice='"+d_Price.ToString()+"' ";
                    s_Sql+=",KWD_WwMoney='"+d_Price * d_Number+"' ";
                    s_Sql+=" where ID='"+s_ID+"'";
                    try
                    {
                        if (DbHelperSQL.ExecuteSql(s_Sql)>0)
                        {
                            i_Num = i_Num + 1;
                        }
                        else
                        {
                        }
                    }
                    catch
                    { }
                }
            }
        }
        */
        string s_Sql = " msdb.dbo.sp_start_job @job_name = 'calculationWwPrice' ";
        if (DbHelperSQL.ExecuteSql(s_Sql) > 0)
        {
            Alert("计算成功！");
            this.DataBind();
        }
        else
        {
            Alert("计算失败！");
            this.DataBind();
        }
    }
    protected void Btn_Show_Click(object sender, EventArgs e)
    {
        if (this.MyGridView1.AllowPaging)
        {
            this.Btn_Show.Text = "收缩";
            this.MyGridView1.AllowPaging = false;
            this.DataBind();
        }
        else
        {
            this.Btn_Show.Text = "显示全部";
            this.MyGridView1.AllowPaging = true;
            this.DataBind();
        }
    }





    protected void Btn_SpSave(object sender, EventArgs e)
    {
        StringBuilder s_Sql = new StringBuilder();
        StringBuilder s_Log = new StringBuilder();
        AdminloginMess AM = new AdminloginMess();
        try
        {

            for (int i = 0; i < MyGridView1.Rows.Count; i++)
            {
                CheckBox Ckb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (Ckb.Checked)
                {
                    string s_ID = MyGridView1.DataKeys[i].Value.ToString();

                    if (AM.CheckLogin("财务审核出库单") == true)
                    {
                        KNet.BLL.KNet_WareHouse_DirectOutList_Details bll_Details = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
                        KNet.Model.KNet_WareHouse_DirectOutList_Details Model_Details = bll_Details.GetModel(s_ID);
                        KNet.BLL.KNet_WareHouse_DirectOutList bll = new KNet.BLL.KNet_WareHouse_DirectOutList();
                        KNet.Model.KNet_WareHouse_DirectOutList Model = bll.GetModelB(Model_Details.DirectOutNo);
                        string s_CheckYN = "0";


                        if ((Model.DirectOutCheckYN == 2)|| (Model.DirectOutCheckYN == 1))
                        {
                            s_CheckYN = "3";
                        }
                            /*
                        else if (Model.DirectOutCheckYN == 3)
                        {
                            s_CheckYN = "1";
                        }
                        else
                        {
                            s_CheckYN = "0";
                        }*/
                        if (s_CheckYN != "0")
                        {
                            string sql = " update KNet_WareHouse_DirectOutList  set DirectOutCheckYN=" + s_CheckYN + ",DirectOutCheckStaffNo ='" + AM.KNet_StaffNo + "'  where  DirectOutNo='" + Model_Details.DirectOutNo + "' ";
                            DbHelperSQL.ExecuteSql(sql);
                        }
                    }
                    s_Log.Append(s_ID + ",");
                }
            }
            if (s_Log.ToString() == "")
            {
                Alert("未选择出库单！");
            }
            else
            {
                this.DataBind();
                AM.Add_Logs("KNet_WareHouse_DirectOutList财务批量审批 编号：" + s_Log + "");
                Alert("批量审批成功！");
            }
        }
        catch (Exception ex)
        {
            Alert("批量审批失败！");
            return;
        }
    }
    protected void ImgB_Click(object sender, ImageClickEventArgs e)
    {
        Excel export = new Excel();
        string s_FileName="原材料领料单.xls";
        if(this.Tbx_WhereID.Text!="")
        {
            this.BeginQuery("Select PBW_Name from PB_Basic_Where where PBW_ID='" + this.Tbx_WhereID.Text + "'");
            s_FileName=this.QueryForReturn()+s_FileName;
        }
        if(this.Tbx_WhereID1.Text!="")
        {
            this.BeginQuery("Select PBW_Name from PB_Basic_Where where PBW_ID='" + this.Tbx_WhereID1.Text + "'");
            s_FileName=this.QueryForReturn()+s_FileName;
        }
        //if (MyGridView1.AllowPaging == true)
        //{
        //    MyGridView1.AllowPaging = false;
        //    this.DataBind();
        //}
        DataSet Dts_RTable = (DataSet)Session["Dts_RTable"];
        export.ExcelExport(GetStringWriter(Dts_RTable.Tables[0]), s_FileName);
        //MyGridView1.AllowPaging = true;
        //this.DataBind();
    }
    public   StringWriter GetStringWriter(DataTable dt)
    {
        StringWriter sw = new StringWriter();

        //先写列的表头，这样保证如果没有数据也能输出列表头 
        sw.Write("编号  " + "\t ");
        sw.Write("编码 " + "\t ");
        sw.Write("日期 " + "\t ");
        sw.Write("领料类型 " + "\t ");
        sw.Write("仓库 " + "\t ");
        sw.Write("产品名称 " + "\t ");
        sw.Write("产品版本号 " + "\t ");
        sw.Write("领料数量 " + "\t ");
        sw.Write("单价 " + "\t ");
        sw.Write("金额 " + "\t ");
        sw.Write("期初数量 " + "\t ");
        sw.Write("期初金额 " + "\t ");
        sw.Write("采购数量 " + "\t ");
        sw.Write("采购金额 " + "\t ");
        sw.Write("单价 " + "\t ");
        sw.Write("领料单价 " + "\t ");
        sw.Write("领料金额 " + "\t ");
        sw.Write("状态 " + "\t ");
        sw.Write(sw.NewLine);

        //如果包含数据 
        if (dt != null)
        {
            //写数据 
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                sw.Write(i.ToString() + "\t");

                sw.Write("=trim("+dr["SED_ID"].ToString() + ")\t ");
                sw.Write(base.DateToString(dr["SED_RkTime"].ToString()) + "\t ");
                sw.Write(dr["typeName"].ToString() + "\t ");
                sw.Write(base.Base_GetHouseName(dr["HouseNo"].ToString()) + "\t ");
                sw.Write(dr["ProductsName"].ToString() + "\t ");
                sw.Write(dr["ProductsEdition"].ToString() + "\t ");
                sw.Write(dr["SED_RkNumber"].ToString() + "\t ");
                sw.Write(dr["SED_RkPrice"].ToString() + "\t ");
                sw.Write(dr["SED_RkMoney"].ToString() + "\t ");
                sw.Write(base.FormatNumber1(GetKC(dr["ID"].ToString(), 0), 0) + "\t ");
                sw.Write(base.FormatNumber1(GetKC(dr["ID"].ToString(), 1), 0) + "\t ");
                sw.Write(base.FormatNumber1(GetKC(dr["ID"].ToString(), 2), 0) + "\t ");
                sw.Write(base.FormatNumber1(GetKC(dr["ID"].ToString(), 3), 0) + "\t ");
                sw.Write(base.FormatNumber1(GetKC(dr["ID"].ToString(), 4), 0) + "\t ");
                sw.Write(dr["WwPrice"].ToString() + "\t ");
                sw.Write(dr["WwMoney"].ToString() + "\t ");
                if (dr["SEM_CheckYN"].ToString() == "0")
                {
                    sw.Write("未" + "\t ");
                }
                else
                {
                    sw.Write("已" + "\t ");
                }

                //换行 
                sw.Write(sw.NewLine);
                i++;
            }
        }
        sw.Close();
        return sw;
    } 
}

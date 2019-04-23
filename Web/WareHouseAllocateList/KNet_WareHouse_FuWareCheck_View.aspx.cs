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

public partial class Web_WareHouseAllocateList_KNet_WareHouse_FuWareCheck_View : BasePage
{
    public string s_CustomerValue = "", s_OrderStyle = "", s_DetailsStyle = "";
    public string s_LinkMan = "";
    public string s_OppID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.KNet_StaffName == "蔡瑞琴")
            {
                Btn_Save.Visible = false;
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            KNet.BLL.KNet_WareHouse_AllocateList BLL1 = new KNet.BLL.KNet_WareHouse_AllocateList();
            DataSet Model1 = BLL1.GetList("  AllocateNo=" + "'" + s_ID + "'");
            if (Model1.Tables[0].Rows.Count > 0)
            {
                Response.Write("<script language=javascript>alert('该入库通知已经操作过，不能重复操作')</script>");
                Response.Write("<script>window.opener=null;window.close();</script>");

                // Response.End();
            }
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
            KNet.BLL.KNet_WareHouse_FuAllocateList bll = new KNet.BLL.KNet_WareHouse_FuAllocateList();
            KNet.BLL.KNet_WareHouse_DirectOutList kwd = new KNet_WareHouse_DirectOutList();
            KNet.Model.KNet_WareHouse_FuAllocateList model = bll.GetModelB(s_ID);
            this.Tbx_ID.Text = s_ID;
            this.Lbl_Code.Text = model.AllocateNo;
            this.Lbl_Stime.Text = DateTime.Parse(model.AllocateDateTime.ToString()).ToShortDateString();
            this.Lbl_House_Out.Text = base.Base_GetHouseName(model.HouseNo);
            this.Lbl_HouseNo.Text = model.HouseNo;
            this.Lbl_House_int.Text = base.Base_GetHouseName(model.HouseNo_int);
            this.Lbl_House_int0.Text = model.HouseNo_int;
            this.Lbl_OrderNo.Text = model.KWA_OrderNo;
            this.Lbl_Remarks.Text = model.AllocateRemarks;
            this.Lbl_Case.Text = model.AllocateCause;
            this.KWA_UploadUrl1.Text = model.KWA_UploadUrl;
            this.KWA_UploadName.Text = model.KWA_UploadName;
            this.KWA_UploadUrl.Text = "<a href=\"" + model.KWA_UploadUrl + "\" >" + model.KWA_UploadName + "</a>"; ;
            this.KSP_SID.Text = model.KSP_SID.ToString();
            this.KWA_IsEntity.Text = model.KWA_IsEntity.ToString();
            if (model.KWA_IsEntity.ToString()=="1")
            {
                Label1.Text = "是";
            }
            else
            {
                Label1.Text = "否";
            }
           
            this.Tbx_OrderNo.Text = "<a href=\"/Web/Cg/Order/Knet_Procure_OpenBilling_View_ForSc.aspx?ID=" + model.KWA_OrderNo + "\" target=\"_blank\">" + model.KWA_OrderNo + "</a>";
            this.Tbx_OrderNo1.Text = model.KWA_OrderNo;
            this.Chk_Type.Text = base.Base_GetBasicCodeName("1132", model.KWA_DBType.ToString());
            this.Chk_Type1.Text = model.KWA_DBType.ToString();
          
            KNet.BLL.KNet_WareHouse_FuAllocateList_Details BLL_Details = new KNet.BLL.KNet_WareHouse_FuAllocateList_Details();
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
           
            Sb_Details.Append("<td class=\"ListHead\" nowrap><b>调拨数量</b></td>");
           
            Sb_Details.Append("<td class=\"ListHead\" nowrap><b>确认数量</b></td>");

            Sb_Details.Append("<td class=\"ListHead\" nowrap><b>退货数量</b></td>");
            Sb_Details.Append("<td class=\"ListHead\" nowrap><b>缺料数量</b></td>");
            //Sb_Details.Append("<td class=\"ListHead\" nowrap><b>差额数量</b></td>");
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

                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type =\"hidden\"  Name=\"ProductsBarCode_" +
                                         i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "'><input type =\"hidden\"  Name=\"BFNumber_" +
                                         i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["KWAD_BFNumber"].ToString() + "'>" + base.Base_GetProductsCode(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");

                    string s_DBNumber = Dts_Details.Tables[0].Rows[i]["KWAD_SCDBNumber"].ToString() == "0" || Dts_Details.Tables[0].Rows[i]["KWAD_SCDBNumber"].ToString() == "" ? Dts_Details.Tables[0].Rows[i]["AllocateAmount"].ToString() : Dts_Details.Tables[0].Rows[i]["KWAD_SCDBNumber"].ToString();
                    string s_Number = Dts_Details.Tables[0].Rows[i]["AllocateAmount"].ToString();
                    string sBadNumber= Dts_Details.Tables[0].Rows[i]["AllocateBadAmount"].ToString();

                    Sb_Details.Append("<td class=\"ListHeadDetails\">" + s_DBNumber + "</td>");



                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"Number_" + i.ToString() + "\" readonly=\"readonly\" value='" + s_Number + "'></td>");

                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style=\"width:70px;\" Name=\"AllocateBadAmount_" + i.ToString() + "\" readonly=\"readonly\" value='" + sBadNumber + "'></td>");

                    string s_Sql = "Select isnull(Sum(NeedNumber),0)  from v_NeedNumberStore where ProductsBarCode='" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "' and HouseNo='" + this.Lbl_House_int0.Text + "'  ";
                    this.BeginQuery(s_Sql);
                    string s_NeedNumber = this.QueryForReturn();
                    Sb_Details.Append("<td class=\"ListHeadDetails\">");
                    Sb_Details.Append("<a href=\"/Web/Sc/Sc_Plan_QLMaterial.aspx?ProductsBarCode=" + Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString() + "&HouseNo=" + this.Lbl_House_int0.Text + "\" target=\"_blank\">" + s_NeedNumber + "</a>\n");

                    Sb_Details.Append("</td>");





                    string s_CateNumber = "";
                    try
                    {
                        s_CateNumber = Convert.ToString(int.Parse(s_DBNumber) - int.Parse(s_Number));
                    }
                    catch
                    { }
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><font color=red>" + s_CateNumber + "</font></td>");

                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type =\"hidden\"  Name=\"AllocateUnitPrice_" +
                                          i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["AllocateUnitPrice"].ToString() + "'>" + Dts_Details.Tables[0].Rows[i]["AllocateUnitPrice"].ToString() + "</td>");
                    //Sb_Details.Append("<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dts_Details.Tables[0].Rows[i]["ProductsBarCode"].ToString()) + "</td>");Dts_Details.Tables[0].Rows[i]["AllocateTotalNet"].ToString()AllocateRemarks
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type =\"hidden\"  Name=\"AllocateTotalNet_" +
                                          i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["AllocateTotalNet"].ToString() + "'>" + Dts_Details.Tables[0].Rows[i]["AllocateTotalNet"].ToString() + "</td>");
                    Sb_Details.Append("<td class=\"ListHeadDetails\"><input type =\"hidden\"  Name=\"AllocateRemarks_" +
                                          i.ToString() + "\" value='" + Dts_Details.Tables[0].Rows[i]["AllocateRemarks"].ToString() + "'>" + Dts_Details.Tables[0].Rows[i]["AllocateRemarks"].ToString() + "&nbsp;</td>");

                    Sb_Details.Append("</tr>");
                }
                this.Tbx_Num.Text = Dts_Details.Tables[0].Rows.Count.ToString(); ;

            }
            Lbl_Details.Text += Sb_Details.ToString();
        }
        catch (Exception ex)
        { }
    }

    protected void Btn_Save_OnClick(object sender, EventArgs e)
    {
        if (this.KSP_SID.Text!="")
        {
            this.BeginQuery("select KSP_State from Knet_Submitted_Product where KSP_SID='" + this.KSP_SID.Text + "'");
            this.QueryForDataTable();
            DataTable Dtb_Re = Dtb_Result;
            if (Dtb_Re.Rows.Count<1)
            {
                
            }
            else
            {
                if (Dtb_Re.Rows[0][0].ToString() == "0")
                {
                    Alert("品质还未审核！不能入库");
                    return;
                }
            }
           
        }
       

        KNet.BLL.KNet_WareHouse_AllocateList BLL3 = new KNet.BLL.KNet_WareHouse_AllocateList();
        KNet.Model.KNet_WareHouse_AllocateList Mode3 = new KNet.Model.KNet_WareHouse_AllocateList();

        KNet.BLL.KNet_WareHouse_AllocateList BLL4 = new KNet.BLL.KNet_WareHouse_AllocateList();
        KNet.Model.KNet_WareHouse_AllocateList Mode4 = new KNet.Model.KNet_WareHouse_AllocateList();

        string s_ID = this.Tbx_ID.Text;
        AdminloginMess LogAM = new AdminloginMess();

        if (this.SetValue(Mode3) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (this.SetValue1(Mode4) == false)
        {
            Alert("系统错误！");
            return;
        }

        try
        {
            BLL3.Add(Mode3);//插入一条入成品库的调拨单
            if (Mode4.Arr_List!=null)
            {
                BLL4.Add(Mode4);
            }
            base.Base_SendMessage(base.Base_GetDeptPerson("供应链平台（物料部/仓库管理）", 0), "有新的库间调拨申请单需要您操作入库：<a href='Web/WareHouseAllocateList/KNet_WareHouse_FuWareCheck_View.aspx?ID=" + Mode3.AllocateNo + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'></a> 需要您作为负责人选择审批流程，敬请关注！ ");
            LogAM.Add_Logs("库存管理--->库间调拨申请--->调拨开单申请 添加 操作成功！调拨单号：" + Mode3.AllocateNo);

            Response.Write("<script>alert('入成品库申请 添加  操作成功！');location.href='KNet_WareHouse_AllocateList_Manage.aspx';</script>");
            Response.End();

        }
        catch (Exception ex)
        {
            //throw ex;
            Response.Write("<script>alert('调拨单添加失败！');history.back(-1);</script>");
            Response.End();
        }
    }
    private bool SetValue(KNet.Model.KNet_WareHouse_AllocateList molel)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            string AllocateNo = "";
            if (this.Tbx_ID.Text != "")
            {
                AllocateNo = this.Lbl_Code.Text;
            }

            string AllocateTopic = KNetPage.KHtmlEncode("");
            string AllocateCause = KNetPage.KHtmlEncode(this.Lbl_Case.Text.Trim());

            //DateTime AllocateDateTime = DateTime.Parse(Lbl_Stime.Text.ToString());
            DateTime AllocateDateTime = DateTime.Parse(DateTime.Now.ToShortDateString());
           

            string HouseNo_out = KNetPage.KHtmlEncode(this.Lbl_HouseNo.Text);
            string HouseNo_int = KNetPage.KHtmlEncode(this.Lbl_House_int0.Text);

            if (HouseNo_out.ToLower() == HouseNo_int.ToLower())
            {
                Response.Write("<script>alert('错误！！\\n\\n调出仓库不能与调入仓库一样！');history.back(-1);</script>");
                Response.End();
            }
            string AllocateStaffBranch = "";
            string AllocateStaffDepart = "";
            string AllocateStaffNo = AM.KNet_StaffNo;
            string AllocateCheckStaffNo = "";
            string AllocateRemarks = KNetPage.KHtmlEncode(this.Lbl_Remarks.Text.Trim());


            molel.AllocateNo = AllocateNo;
            molel.AllocateTopic = AllocateTopic;
            molel.AllocateCause = AllocateCause;
            molel.KWA_UploadName = KWA_UploadName.Text;
            molel.KWA_UploadUrl = KWA_UploadUrl1.Text;
            molel.AllocateDateTime = AllocateDateTime;
            molel.HouseNo = HouseNo_out;
            molel.HouseNo_int = HouseNo_int;

            molel.KWA_Type = "3";
            molel.AllocateStaffBranch = AllocateStaffBranch;
            molel.AllocateStaffDepart = AllocateStaffDepart;

            molel.AllocateStaffNo = AllocateStaffNo;
            molel.AllocateCheckStaffNo = AllocateCheckStaffNo;
            molel.AllocateRemarks = AllocateRemarks;
            molel.AllocateCheckYN = 0;
            molel.AllocateTopic = "102"; //维修品调拨
            molel.KWA_OrderNo = this.Tbx_OrderNo1.Text;
            molel.KWA_DBType = int.Parse(this.Chk_Type1.Text);
            molel.KWA_IsEntity = int.Parse(this.KWA_IsEntity.Text);
            ArrayList Arr_Products = new ArrayList();
            for (int i = 0; i < int.Parse(this.Tbx_Num.Text); i++)
            {

                if (Request["ProductsBarCode_" + i.ToString()] != null)
                {
                    string s_ProductsBarCode = Request.Form["ProductsBarCode_" + i.ToString()] == null
                        ? ""
                        : Request.Form["ProductsBarCode_" + i.ToString()].ToString();
                    string s_FaterBarCode = Request.Form["FaterBarCode_" + i.ToString()] == null
                        ? ""
                        : Request.Form["FaterBarCode_" + i.ToString()].ToString();

                    string s_Number = Request.Form["Number_" + i.ToString()] == ""
                        ? "0"
                        : Request.Form["Number_" + i.ToString()].ToString();

                    string s_Price = "0", s_Money = "0";
                    try
                    {
                        s_Price = Request.Form["AllocateUnitPrice_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["AllocateUnitPrice_" + i.ToString()].ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        s_Money = Request.Form["AllocateTotalNet_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["AllocateTotalNet_" + i.ToString()].ToString();

                    }
                    catch
                    {
                    }
                    if (decimal.Parse(s_Money) != 0)
                    {
                        try
                        {
                            s_Price = Convert.ToString(decimal.Parse(s_Money) / decimal.Parse(s_Number));
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        s_Money = Convert.ToString(decimal.Parse(s_Price) * decimal.Parse(s_Number));
                    }
                    string s_CPBZNumber = "0";
                    string s_BZNumber = "0";

                    try
                    {
                        s_CPBZNumber = Request.Form["Tbx_CPBZNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["Tbx_CPBZNumber_" + i.ToString()].ToString();
                        s_BZNumber = Request.Form["Tbx_BZNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["Tbx_BZNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                        s_CPBZNumber = "0";
                        s_BZNumber = "0";
                    }
                    string s_BadNumber = "0", s_AddBadNumber = "0", s_SDNumber = "0", s_BFNumber = "0";

                    try
                    {
                        s_BadNumber = Request.Form["BadNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["BadNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                        s_BadNumber = "0";
                    }

                    try
                    {
                        s_AddBadNumber = Request.Form["AddBadNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["AddBadNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                        s_AddBadNumber = "0";
                    }
                    try
                    {
                        s_SDNumber = Request.Form["SDNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["SDNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                        s_SDNumber = "0";
                    }
                    try
                    {
                        s_BFNumber = Request.Form["BFNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["BFNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                        s_BFNumber = "0";
                    }
                    string s_Remarks = Request.Form["AllocateRemarks_" + i.ToString()].ToString();
                    KNet.Model.KNet_WareHouse_AllocateList_Details Model_Details =
                        new KNet.Model.KNet_WareHouse_AllocateList_Details();
                    Model_Details.ID = GetNewID("KNet_WareHouse_FuAllocateList_Details", 1);
                    Model_Details.ProductsBarCode = s_ProductsBarCode;
                    Model_Details.AllocateNo = molel.AllocateNo;
                    Model_Details.AllocateAmount = int.Parse(s_Number);
                    try
                    {
                        Model_Details.KWAD_CPBZNumber = int.Parse(s_CPBZNumber);
                        Model_Details.KWAD_BZNumber = int.Parse(s_BZNumber);
                    }
                    catch
                    {
                        Model_Details.KWAD_CPBZNumber = 0;
                        Model_Details.KWAD_BZNumber = 0;
                    }
                    Model_Details.AllocateUnitPrice = decimal.Parse(s_Price);
                    Model_Details.AllocateTotalNet = decimal.Parse(s_Money);
                    Model_Details.AllocateRemarks = s_Remarks;
                    Model_Details.KWAD_FaterBarCode = s_FaterBarCode;
                    try
                    {
                        Model_Details.KWAD_SDNumber = int.Parse(s_Number);
                    }
                    catch
                    {
                        Model_Details.KWAD_SDNumber = 0;
                    }
                    try
                    {
                        Model_Details.KWAD_BFNumber = int.Parse(s_BFNumber);
                    }
                    catch
                    {
                        Model_Details.KWAD_BFNumber = 0;
                    }

                    try
                    {
                        Model_Details.KWAD_BadNumber = int.Parse(s_BadNumber);
                    }
                    catch { Model_Details.KWAD_BadNumber = 0; }
                    try
                    {
                        Model_Details.KWAD_AddBadNumber = int.Parse(s_AddBadNumber);
                    }
                    catch { Model_Details.KWAD_AddBadNumber = 0; }
                    //if (decimal.Parse(s_Number) != 0)
                    //{
                        Arr_Products.Add(Model_Details);
                        molel.Arr_List = Arr_Products;
                    //}

                }
            }



            return true;
        }
        catch (Exception ex)
        {
            throw ex;
            return false;
        }
    }
    private bool SetValue1(KNet.Model.KNet_WareHouse_AllocateList molel)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            string AllocateNo= "CP" + base.GetNewID("KNet_WareHouse_FuAllocateList", 1); 
            //if (this.Tbx_ID.Text != "")
            //{
            //    AllocateNo = this.Lbl_Code.Text;
            //}

            string AllocateTopic = KNetPage.KHtmlEncode("");
            string AllocateCause = KNetPage.KHtmlEncode(this.Lbl_Case.Text.Trim());

            //DateTime AllocateDateTime = DateTime.Parse(Lbl_Stime.Text.ToString());
            DateTime AllocateDateTime = DateTime.Parse(DateTime.Now.ToShortDateString());


            string HouseNo_out = KNetPage.KHtmlEncode(this.Lbl_HouseNo.Text);
            string HouseNo_int = KNetPage.KHtmlEncode(this.Lbl_House_int0.Text);

            if (HouseNo_out.ToLower() == HouseNo_int.ToLower())
            {
                Response.Write("<script>alert('错误！！\\n\\n调出仓库不能与调入仓库一样！');history.back(-1);</script>");
                Response.End();
            }
            string AllocateStaffBranch = "";
            string AllocateStaffDepart = "";
            string AllocateStaffNo = AM.KNet_StaffNo;
            string AllocateCheckStaffNo = "";
            string AllocateRemarks = KNetPage.KHtmlEncode(this.Lbl_Remarks.Text.Trim());


            molel.AllocateNo = AllocateNo;
            molel.AllocateTopic = AllocateTopic;
            molel.AllocateCause = AllocateCause;
            molel.KWA_UploadName = "";
            molel.KWA_UploadUrl = "";
            molel.AllocateDateTime = AllocateDateTime;
            molel.HouseNo = HouseNo_out;
            molel.HouseNo_int = HouseNo_int;

            molel.KWA_Type = "3";
            molel.AllocateStaffBranch = AllocateStaffBranch;
            molel.AllocateStaffDepart = AllocateStaffDepart;

            molel.AllocateStaffNo = AllocateStaffNo;
            molel.AllocateCheckStaffNo = AllocateCheckStaffNo;
            molel.AllocateRemarks = AllocateRemarks;
            molel.AllocateCheckYN = 0;
            molel.AllocateTopic = "102"; //维修品调拨
            molel.KWA_OrderNo = this.Tbx_OrderNo1.Text;
            molel.KWA_DBType = int.Parse(this.Chk_Type1.Text);
            molel.KWA_IsEntity = int.Parse(this.KWA_IsEntity.Text);
            ArrayList Arr_Products = new ArrayList();
            for (int i = 0; i < int.Parse(this.Tbx_Num.Text); i++)
            {

                if (Request["ProductsBarCode_" + i.ToString()] != null)
                {
                    string s_ProductsBarCode = Request.Form["ProductsBarCode_" + i.ToString()] == null
                        ? ""
                        : Request.Form["ProductsBarCode_" + i.ToString()].ToString();
                    string s_FaterBarCode = Request.Form["FaterBarCode_" + i.ToString()] == null
                        ? ""
                        : Request.Form["FaterBarCode_" + i.ToString()].ToString();

                    string s_Number = Request.Form["AllocateBadAmount_" + i.ToString()] == ""
                        ? "0"
                        : Request.Form["AllocateBadAmount_" + i.ToString()].ToString();

                    string s_Price = "0", s_Money = "0";
                    try
                    {
                        s_Price = Request.Form["AllocateUnitPrice_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["AllocateUnitPrice_" + i.ToString()].ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        s_Money = Request.Form["AllocateTotalNet_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["AllocateTotalNet_" + i.ToString()].ToString();

                    }
                    catch
                    {
                    }
                    if (decimal.Parse(s_Money) != 0)
                    {
                        try
                        {
                            s_Price = Convert.ToString(decimal.Parse(s_Money) / decimal.Parse(s_Number)*(-1));
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        s_Money = Convert.ToString(decimal.Parse(s_Price) * decimal.Parse(s_Number) * (-1));
                    }
                    string s_CPBZNumber = "0";
                    string s_BZNumber = "0";

                    try
                    {
                        s_CPBZNumber = Request.Form["Tbx_CPBZNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["Tbx_CPBZNumber_" + i.ToString()].ToString();
                        s_BZNumber = Request.Form["Tbx_BZNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["Tbx_BZNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                        s_CPBZNumber = "0";
                        s_BZNumber = "0";
                    }
                    string s_BadNumber = "0", s_AddBadNumber = "0", s_SDNumber = "0", s_BFNumber = "0";

                    try
                    {
                        s_BadNumber = Request.Form["BadNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["BadNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                        s_BadNumber = "0";
                    }

                    try
                    {
                        s_AddBadNumber = Request.Form["AddBadNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["AddBadNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                        s_AddBadNumber = "0";
                    }
                    try
                    {
                        s_SDNumber = Request.Form["SDNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["SDNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                        s_SDNumber = "0";
                    }
                    try
                    {
                        s_BFNumber = Request.Form["BFNumber_" + i.ToString()] == ""
                            ? "0"
                            : Request.Form["BFNumber_" + i.ToString()].ToString();

                    }
                    catch
                    {
                        s_BFNumber = "0";
                    }
                    string s_Remarks = Request.Form["AllocateRemarks_" + i.ToString()].ToString();
                    KNet.Model.KNet_WareHouse_AllocateList_Details Model_Details =
                        new KNet.Model.KNet_WareHouse_AllocateList_Details();
                    Model_Details.ID = GetNewID("KNet_WareHouse_FuAllocateList_Details", 1);
                    Model_Details.ProductsBarCode = s_ProductsBarCode;
                    Model_Details.AllocateNo = molel.AllocateNo;
                    Model_Details.AllocateAmount = int.Parse(s_Number)*(-1);
                    try
                    {
                        Model_Details.KWAD_CPBZNumber = int.Parse(s_CPBZNumber);
                        Model_Details.KWAD_BZNumber = int.Parse(s_BZNumber);
                    }
                    catch
                    {
                        Model_Details.KWAD_CPBZNumber = 0;
                        Model_Details.KWAD_BZNumber = 0;
                    }
                    Model_Details.AllocateUnitPrice = decimal.Parse(s_Price);
                    Model_Details.AllocateTotalNet = decimal.Parse(s_Money);
                    Model_Details.AllocateRemarks = s_Remarks;
                    Model_Details.KWAD_FaterBarCode = s_FaterBarCode;
                    try
                    {
                        Model_Details.KWAD_SDNumber = int.Parse(s_Number) * (-1);
                    }
                    catch
                    {
                        Model_Details.KWAD_SDNumber = 0;
                    }
                    try
                    {
                        Model_Details.KWAD_BFNumber = int.Parse(s_BFNumber);
                    }
                    catch
                    {
                        Model_Details.KWAD_BFNumber = 0;
                    }

                    try
                    {
                        Model_Details.KWAD_BadNumber = int.Parse(s_BadNumber);
                    }
                    catch { Model_Details.KWAD_BadNumber = 0; }
                    try
                    {
                        Model_Details.KWAD_AddBadNumber = int.Parse(s_AddBadNumber);
                    }
                    catch { Model_Details.KWAD_AddBadNumber = 0; }
                    if (decimal.Parse(s_Number) != 0)
                    {
                        Arr_Products.Add(Model_Details);
                        molel.Arr_List = Arr_Products;
                    }

                }
            }



            return true;
        }
        catch (Exception ex)
        {
            throw ex;
            return false;
        }
    }
}
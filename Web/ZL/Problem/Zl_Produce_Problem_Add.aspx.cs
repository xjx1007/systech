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

using KNet.DBUtility;
using KNet.Common;
using System.Data.SqlClient;
using System.Text;

public partial class Zl_Produce_Problem_Add : BasePage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();

            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = s_ID;
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            this.Tbx_Type.Text = s_Type;
            string s_SType = Request.QueryString["SType"] == null ? "" : Request.QueryString["SType"].ToString();
            string s_SampleID = Request.QueryString["SampleID"] == null ? "" : Request.QueryString["SampleID"].ToString();
            string s_ProductsBarCode = Request.QueryString["ProductsBarCode"] == null ? "" : Request.QueryString["ProductsBarCode"].ToString();
            if (s_ProductsBarCode != "")
            {
                this.Tbx_ProdutsBarCode.Text = s_ProductsBarCode;
                this.Tbx_ProductsName.Text = base.Base_GetProductsEdition(s_ProductsBarCode);
            }
            base.Base_DropBasicCodeBind(this.Ddl_ScStage, "260");
            base.Base_DropBasicCodeBind(this.Ddl_Type, "261");
            base.Base_DropBasicCodeBind(this.Ddl_FlowStep, "263");

            base.Base_DropBasicCodeBind(this.Ddl_ClosedType, "262");
            this.Ddl_ClosedType.SelectedValue = "0";
            base.Base_DropDepart(this.Ddl_DutyDepart);
            base.Base_DropDutyPerson(this.Ddl_DutyPerson);
            base.Base_DropBindFlow(this.Ddl_Flow, "109");
            this.Tbx_Code.Text = GetCode();
            if (this.Tbx_Type.Text == "处理")
            {
                this.Pan_Basic.Enabled = false;
                this.Pan_Basic1.Enabled = false;
                this.Pan_Cl.Visible = true;
                this.Pan_Done.Visible = false;
                this.Tbx_DoneTime.Text = DateTime.Now.ToShortDateString();
            }
            else if (this.Tbx_Type.Text == "结案")
            {
                this.Pan_Basic.Enabled = false;
                this.Pan_Basic1.Enabled = false;
                this.Pan_Cl.Visible = false;
                this.Pan_Done.Visible = true;
            }
            else
            {

                this.Pan_Basic.Enabled = true;
                this.Pan_Basic1.Enabled = true;
                this.Pan_Cl.Visible = false;
                this.Pan_Done.Visible = false;
            }
            this.CommentList2.CommentFID = this.Tbx_Code.Text;
            this.CommentList2.CommentType = "SCProblem";
            this.CommentList1.CommentFID = this.Tbx_Code.Text + "1";
            this.CommentList1.CommentType = "SCProblem1";
            try
            {
                string s_DSql = "Delete from PB_Basic_Attachment wehre PBA_Type='CPSZ' and PBA_FID NOT in (Select ZPP_ID from Zl_Produce_Problem ) and PBA_FID<>'" + this.Tbx_Code.Text + "'";
                DbHelperSQL.ExecuteSql(s_DSql);
            }
            catch
            { }
            this.Tbx_STime.Text = DateTime.Now.ToShortDateString();
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制生产问题";
                }
                else
                {
                    this.Lbl_Title.Text = "修改生产问题";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
                DataShows();
            }
            else
            {
                this.Lbl_Title.Text = "新增生产问题";
            }
        }

    }

    protected string GetOutWareListfollowup(object OutWareNo, string s_Title, string s_Type)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            string s_Return = "", s_Str = "";
            if (s_Type == "遥控器采购")
            {
                s_Str += "发货日期：";
                string s_Sql = "select top 1 SPD_EndTime from Sc_Produce_Plan_Details a ";
                s_Sql += "join Knet_Procure_OrdersList_Details b on a.SPD_OrderNo=b.ID  ";
                s_Sql += "where b.OrderNo='" + OutWareNo + "' ";
                s_Sql += "order by SPD_FaterID desc";
                try
                {
                    this.BeginQuery(s_Sql);
                    s_Str += base.DateToString(this.QueryForReturn());
                }
                catch
                { }
                s_Str += "<br/>";
            }
            conn.Open();
            string Dostr = "select top 1 ID,FollowNo,OutWareNo,FollowDateTime,FollowStaffNo,FollowText,FollowEnd,ReTime from KNet_Sales_OutWareList_FlowList where OutWareNo='" + OutWareNo + "' order by FollowDateTime desc";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if ((dr["ReTime"] != null) && (dr["ReTime"].ToString() != ""))
                {
                    s_Str += "交期：" + DateTime.Parse(dr["ReTime"].ToString()).ToShortDateString();
                }
                s_Str += "<br/>" + KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40);
                if (dr["FollowEnd"].ToString() == "True")
                {
                    s_Return = "<img src=\"../../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('" + s_Title + ":<font color=Red>" + OutWareNo + "</font> 跟踪', '../Order/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + s_Str + "</a>&nbsp;<font color=red>结束</font>";//&nbsp;<font color=\"gray\">" + base.Base_GetUserName(dr["FollowStaffNo"].ToString()) + "&nbsp;(" + dr["FollowDateTime"].ToString() + ")</font>
                }
                else
                {
                    s_Return = "<img src=\"../../images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('" + s_Title + ":<font color=Red>" + OutWareNo + "</font> 跟踪', '../Order/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + s_Str + "</a>&nbsp;<img src=\"../../images/45.gif\" width=\"11\" height=\"11\" border=\"0\" /><a href=\"#\" onclick=\"lhgdialog.opendlg('" + s_Title + ":<font color=Red>" + OutWareNo + "</font> 跟踪', '../Order/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">添加</a>";
                }
            }
            else
            {
                s_Return = "<a href=\"#\" onclick=\"lhgdialog.opendlg('" + s_Title + ":<font color=Red>" + OutWareNo + "</font> 跟踪', '../Order/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + s_Str + " 添加</a>";
            }
            return s_Return;
        }
    }

    public string GetRk(string s_RKSTtate, string s_OrderNo, string s_Type)
    {
        if (s_Type != "遥控器采购")
        {
            if (s_RKSTtate == "0")
            {
                return "<a href=\"/Web/Cg/OrderInWareHouse/Knet_Procure_WareHouseList_Add.aspx?OrderNo=" + s_OrderNo + "\"><font color=\"red\">未入库</font></a>";
            }
            else if (s_RKSTtate == "1")
            {
                return "<a href=\"/Web/Cg/OrderInWareHouse/Knet_Procure_WareHouseList_Add.aspx?OrderNo=" + s_OrderNo + "\"><font color=\"red\">已入库</font></a>";
            }
            else
            {
                return "<a href=\"/Web/Cg/OrderInWareHouse/Knet_Procure_WareHouseList_Add.aspx?OrderNo=" + s_OrderNo + "\"><font color=\"red\">部分发货</font></a>";
            }
        }
        else
        {

            if (s_RKSTtate == "0")
            {
                return "<a href=\"/Web/ScExpend/Sc_Expend_Add.aspx?OrderNo=" + s_OrderNo + "\"><font color=\"red\">未入库</font></a>";
            }
            else if (s_RKSTtate == "1")
            {
                return "<a href=\"/Web/ScExpend/Sc_Expend_Add.aspx?OrderNo=" + s_OrderNo + "\"><font color=\"red\">已入库</font></a>";
            }
            else
            {
                return "<a href=\"/Web/ScExpend/Sc_Expend_Add.aspx?OrderNo=" + s_OrderNo + "\"><font color=\"red\">部分发货</font></a>";
            }
        }
    }


    protected void DataShows()
    {
        if (this.Tbx_ProdutsBarCode.Text != "")
        {
            KNet.BLL.Knet_Procure_OrdersList bll = new KNet.BLL.Knet_Procure_OrdersList();

            string SqlWhere = " 1=1 ";
            AdminloginMess AM = new AdminloginMess();
            SqlWhere += " and OrderNo in (select OrderNo from Knet_Procure_OrdersList_Details where ProductsBarCode='" + this.Tbx_ProdutsBarCode.Text + "') ";
            SqlWhere += " order by SYstemDateTimes desc";
            DataSet ds = bll.GetList(SqlWhere);

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataKeyNames = new string[] { "OrderNo" };
            GridView1.DataBind();
        }

        ////查看采购单  执行完成  状态 
        //for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        //{
        //    DataRowView mydrv = ds.Tables[0].DefaultView[i];
        //    if (UpdateOrderState(mydrv["OrderNo"].ToString()) == true)
        //    {
        //        //更新采购单为 “已完成”
        //        string DoSqlOrder = " update Knet_Procure_OrdersList set OrderState=5 where OrderNo='" + mydrv["OrderNo"].ToString() + "'";
        //        DbHelperSQL.ExecuteSql(DoSqlOrder);
        //    }
        //}

    }
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Zl_Produce_Problem bll = new KNet.BLL.Zl_Produce_Problem();
        KNet.Model.Zl_Produce_Problem model = bll.GetModel(s_ID);
        if (model != null)
        {
            if ((this.Tbx_Type.Text == "处理") && (model.ZPP_State != 0))
            {
                AlertAndGoBack("不能处理！");
            }
            else if ((this.Tbx_Type.Text == "结案") && (model.ZPP_ClosedState != 0))
            {
                AlertAndGoBack("不能结案！");
            }
            else
            {
                if ((model.ZPP_ClosedState != 0) || (model.ZPP_ClosedState != 0))
                {
                    AlertAndGoBack("不能修改！");
                }
                this.Tbx_ID.Text = model.ZPP_ID.ToString();
                this.Tbx_Code.Text = model.ZPP_Code.ToString();
                this.Tbx_Title.Text = model.ZPP_Title.ToString();
                this.Tbx_STime.Text = DateTime.Parse(model.ZPP_STime.ToString()).ToShortDateString();
                this.Tbx_HopeDate.Text = base.DateToString(model.ZPP_HopeDate.ToString());
                this.Tbx_ProdutsBarCode.Text = model.ZPP_ProdutsBarCode;
                this.Tbx_ProductsName.Text = base.Base_GetProductsEdition(this.Tbx_ProdutsBarCode.Text);
                this.Ddl_ScStage.SelectedValue = model.ZPP_ScStage;
                this.Ddl_Type.SelectedValue = model.ZPP_Type;
                this.Ddl_Flow.SelectedValue = model.ZPP_Flow;
                this.Ddl_FlowStep.SelectedValue = model.ZPP_FlowStep;
                this.Ddl_DutyPerson.SelectedValue = model.ZPP_DutyPerson;
                this.Ddl_DutyDepart.SelectedValue = model.ZPP_DutyDepart;
                this.Tbx_Text.Text = model.ZPP_Text;
                this.CommentList2.CommentFID = this.Tbx_Code.Text;
                this.CommentList2.CommentType = "SCProblem";
                this.CommentList1.CommentFID = this.Tbx_Code.Text + "1";
                this.CommentList1.CommentType = "SCProblem1";

                this.Tbx_State.Text = model.ZPP_State.ToString();
                this.Tbx_Cause.Text = model.ZPP_Cause.ToString();
                this.Tbx_Temporary.Text = model.ZPP_Temporary;
                if (model.ZPP_DoneTime != DateTime.Parse("1900-01-01"))
                {
                    this.Tbx_DoneTime.Text = model.ZPP_DoneTime.ToShortDateString();
                }
                this.Tbx_ClosedState.Text = model.ZPP_ClosedState.ToString();
                this.Ddl_ClosedType.SelectedValue = model.ZPP_ClosedType.ToString();
            }
        }
    }

    private bool SetValue(KNet.Model.Zl_Produce_Problem model)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text == "")
            {
                model.ZPP_ID = GetMainID();
            }
            else
            {
                model.ZPP_ID = this.Tbx_ID.Text;
            }
            model.ZPP_Code = this.Tbx_Code.Text;
            model.ZPP_Title = this.Tbx_Title.Text.ToString();
            model.ZPP_ProdutsBarCode = this.Tbx_ProdutsBarCode.Text;
            model.ZPP_Type = this.Ddl_Type.SelectedValue;
            model.ZPP_ScStage = this.Ddl_ScStage.SelectedValue;
            try
            {
                model.ZPP_STime = DateTime.Parse(this.Tbx_STime.Text);
            }
            catch
            { }
            model.ZPP_Flow = this.Ddl_Flow.SelectedValue;
            model.ZPP_FlowStep = this.Ddl_FlowStep.SelectedValue;
            model.ZPP_DutyDepart = this.Ddl_DutyDepart.SelectedValue;
            model.ZPP_DutyPerson = this.Ddl_DutyPerson.SelectedValue;

            try
            {
                model.ZPP_HopeDate = DateTime.Parse(this.Tbx_HopeDate.Text);
            }
            catch
            { }
            model.ZPP_Text = this.Tbx_Text.Text;
            model.ZPP_Del = 0;
            model.ZPP_CTime = DateTime.Now;
            model.ZPP_Creator = AM.KNet_StaffNo;
            model.ZPP_MTime = DateTime.Now;
            model.ZPP_Mender = AM.KNet_StaffNo;

            try
            {
                model.ZPP_DoneTime = DateTime.Parse(this.Tbx_DoneTime.Text);
            }
            catch
            {
                model.ZPP_DoneTime = DateTime.Parse("1900-01-01");
            }
            if (this.Tbx_Type.Text == "处理")
            {
                model.ZPP_State = 1;
                model.ZPP_ClosedState = 0;

            }
            else if (this.Tbx_Type.Text == "结案")
            {
                model.ZPP_ClosedState = 1;
                model.ZPP_State = 1;
            }
            else
            {
                model.ZPP_State = 0;
                model.ZPP_ClosedState = 0;
            }
            model.ZPP_Cause = this.Tbx_Cause.Text;
            model.ZPP_Temporary = this.Tbx_Temporary.Text;
            model.ZPP_ClosedType = this.Ddl_ClosedType.SelectedValue;
            model.ZPP_Result = this.Tbx_Result.Text;
            ArrayList arr_Details = new ArrayList();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (cb.Checked == true)
                {
                    KNet.Model.Zl_Produce_Problem_Details Model_Details = new KNet.Model.Zl_Produce_Problem_Details();
                    Model_Details.ZPPD_ID = GetMainID(i);
                    Model_Details.ZPPD_FID = model.ZPP_ID;
                    Model_Details.ZPPD_OrderNo = GridView1.DataKeys[i].Value.ToString();
                    arr_Details.Add(Model_Details);
                }
            }
            model.Arr_Detail = arr_Details;

            return true;
        }
        catch
        {
            return false;
        }

    }

    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string s_OrderNo = GridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            if (s_OrderNo != "")
            {
                KNet.BLL.Zl_Produce_Problem_Details BLL = new KNet.BLL.Zl_Produce_Problem_Details();
                string s_Sql = " 1=1 ";
                if (this.Tbx_ID.Text != "")
                {
                    s_Sql += " ";
                }
                s_Sql += " AND ZPPD_OrderNo='" + s_OrderNo + "' ";
                DataSet Dts_Table = BLL.GetList(s_Sql);
                CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
                if (Dts_Table.Tables[0].Rows.Count > 0)
                {
                    cb.Checked = true;
                }
                else
                {
                    cb.Checked = false;
                }
            }
        }
    }
    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.Zl_Produce_Problem model = new KNet.Model.Zl_Produce_Problem();
        KNet.BLL.Zl_Produce_Problem bll = new KNet.BLL.Zl_Produce_Problem();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (this.Tbx_ID.Text != "")//修改
        {
            try
            {
                if (bll.Update(model))
                {
                    AM.Add_Logs("生产问题修改" + this.Tbx_ID.Text);
                    //  base.Base_SendMessage(model.PBW_ID, "生产问题： <a href='Web/Notice/Zl_Produce_Problem_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBW_ID + "</a> ");
                    if (this.Tbx_Type.Text == "处理")
                    {
                        AlertAndRedirect("处理成功！", "Zl_Produce_Problem_List.aspx");
                    }
                    else if (this.Tbx_Type.Text == "结案")
                    {
                        AlertAndRedirect("结案成功！", "Zl_Produce_Problem_List.aspx");
                    }
                    else
                    {
                        AlertAndRedirect("修改成功！", "Zl_Produce_Problem_List.aspx");
                    }
                }
                else
                {
                    AM.Add_Logs("生产问题修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "Zl_Produce_Problem_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            catch (Exception ex) { }
        }
        else
        {
            try
            {
                bll.Add(model);
                // base.Base_SendMessage(model.PBN_ReceiveID, "生产问题： <a href='Web/Notice/Zl_Produce_Problem_View.aspx?ID=" + model.PBN_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
                // AM.Add_Logs("生产问题增加" + model.PBW_ID);
                AlertAndRedirect("新增成功！", "Zl_Produce_Problem_List.aspx");
            }
            catch (Exception ex) { }
        }
    }
    private string GetCode()
    {
        AdminloginMess AM = new AdminloginMess();
        string s_Return = "";
        string s_Sql = "Select isnull(MAX(ZPP_Code),'') from Zl_Produce_Problem  where year(ZPP_Stime)=year(GetDate())";
        this.BeginQuery(s_Sql);
        string s_Code = this.QueryForReturn();
        if (s_Code == "")
        {
            s_Return = base.Base_GetCodeByTitle("问题一览表");
        }
        else
        {
            this.BeginQuery("Select Code from KNet_Resource_OrganizationalStructure where strucValue='" + AM.KNet_StaffDepart + "' ");
            string s_DepartCode = this.QueryForReturn();
            string s_Code1 = s_Code.Substring(0, 6);
            string s_Code2 = s_Code.Substring(8, 6);
            s_Return = s_Code1 + s_DepartCode + Convert.ToString(int.Parse(s_Code2) + 1);
        }
        return s_Return;
    }

    protected void Btn_Serch_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }
}

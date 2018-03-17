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
/// 销售管理-----报价单 管理
/// </summary>
public partial class Knet_Web_Sales_KNet_Sales_ContractList_Manage : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            if (s_Type == "1")
            {
                this.StartDate.Text = DateTime.Today.AddDays(-3).ToShortDateString();
                this.EndDate.Text = DateTime.Today.AddDays(3).ToShortDateString();
            }
            this.Btn_Save.Enabled = false;
            KNet.BLL.KNet_Resource_Staff Bll = new KNet.BLL.KNet_Resource_Staff();
            DataSet Dts_Table = Bll.GetList(" StaffNo<>'admin' Order By StaffDepart ");
            this.Ddl_DutyPerson.DataSource = Dts_Table;
            this.Ddl_DutyPerson.DataTextField = "StaffName";
            this.Ddl_DutyPerson.DataValueField = "StaffNo";
            this.Ddl_DutyPerson.DataBind();
            ListItem item = new ListItem("请选择责任人", ""); //默认值
            this.Ddl_DutyPerson.Items.Insert(0, item);




            base.Base_DropKClaaBind(this.Drop_Type, 6, "", "");
            this.DataShows();
            
           
        }

    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Sales_ContractList bll = new KNet.BLL.KNet_Sales_ContractList();
        string LogtimeA = null;
        string LogtimeB = null;
        string KSeachKey = null;

        string SqlWhere = " 1=1 ";

        if (this.StartDate.Text != "")
        {

            SqlWhere = SqlWhere + " and  ContractToDeliDate >= '" + this.StartDate.Text + "'";
        }
        if (this.EndDate.Text != "")
        {

            SqlWhere = SqlWhere + " and  ContractToDeliDate<='" + this.EndDate.Text + "'   ";
        }
        if (this.Tbx_CustomerName.Text != "")
        {
            SqlWhere = SqlWhere + " and CustomerValue in (Select CustomerValue From KNet_Sales_ClientList Where CustomerName like '%" + this.Tbx_CustomerName.Text + "%')";
        }
        if (this.Drop_Type.SelectedValue != "")
        {
            SqlWhere = SqlWhere + " and ContractClass = " + this.Drop_Type.SelectedValue + " ";

        }
        if (Ddl_DutyPerson.SelectedValue != "")
        {

            SqlWhere = SqlWhere + " and DutyPerson = " + this.Ddl_DutyPerson.SelectedValue + " ";
        }
        if (Ddl_State.SelectedValue != "")
        {
            if (Ddl_State.SelectedValue == "0")//已采购
            {
                SqlWhere += " and a.ContractNo in (Select ContractNo from Knet_Procure_OrdersList )";
            }
            if (Ddl_State.SelectedValue == "1")//未采购
            {
                SqlWhere += " and a.ContractNo not in (Select ContractNo from Knet_Procure_OrdersList )";
            }
            if (Ddl_State.SelectedValue == "2")//已发货通知
            {
                SqlWhere += " and a.ContractNo in (Select ContractNo from KNet_Sales_OutWareList )";

            }
            if (Ddl_State.SelectedValue == "3")//未发货通知
            {
                SqlWhere += " and a.ContractNo not in (Select ContractNo from KNet_Sales_OutWareList )";
            }
            if (Ddl_State.SelectedValue == "4")//已出库
            {
                SqlWhere += " and a.ContractNo in (Select ContractNo from KNet_Sales_OutWareList join KNet_WareHouse_DirectOutList on KWD_SHipNo=OutWareNo ) and b.ContractAmount<=(Select Sum(cc.DirectOutAmount) from KNet_Sales_OutWareList aa join KNet_WareHouse_DirectOutList bb on bb.KWD_SHipNo=aa.OutWareNo join KNet_WareHouse_DirectOutList_Details cc on cc.DirectOutNo=bb.DirectOutNo  where aa.ContractNo=a.ContractNo)";

            }
            if (Ddl_State.SelectedValue == "5")//未出库
            {
                SqlWhere += " and (a.ContractNo not in (Select ContractNo from KNet_Sales_OutWareList join KNet_WareHouse_DirectOutList on KWD_SHipNo=OutWareNo ) or b.ContractAmount>(Select isnull(Sum(cc.DirectOutAmount),0) from KNet_Sales_OutWareList aa join KNet_WareHouse_DirectOutList bb on bb.KWD_SHipNo=aa.OutWareNo join KNet_WareHouse_DirectOutList_Details cc on cc.DirectOutNo=bb.DirectOutNo  where aa.ContractNo=a.ContractNo))";
            }
        }
        SqlWhere = SqlWhere + " order by SystemDateTimes desc";
        DataSet ds = bll.GetDetailsList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ContractNo" };
        GridView1.DataBind();
    }

    /// <summary>
    /// 单是否已审核
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected bool GetReceivCheckYNEitxt(string ContractNo)
    {
        this.BeginQuery("select * from KNet_Sales_Flow where KSF_ContractNo='" + ContractNo + "'");
        this.QueryForDataTable();
        if(Dtb_Result.Rows.Count>0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// 批量删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {

        string sql = "delete from KNet_Sales_ContractList where"; //删除合同
        string sql2 = "delete from KNet_Sales_ContractList_Details where"; //合同 明细

        string cal = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                cal += " ContractNo='" + GridView1.DataKeys[i].Value.ToString() + "' or";

                KNet.BLL.KNet_Sales_ContractList_Details BLL = new KNet.BLL.KNet_Sales_ContractList_Details();
                DataSet ds = BLL.GetList(" ContractNo='" + GridView1.DataKeys[i].Value.ToString() + "' ");

                for (int j = 0; j <= ds.Tables[0].Rows.Count - 1; j++)
                {
                    DataRowView mydrv = ds.Tables[0].DefaultView[j];

                    string ID = mydrv["ID"].ToString();
                    string ProductsBarCode = mydrv["ProductsBarCode"].ToString();
                    string HouseNo = GetHouseNo(GridView1.DataKeys[i].Value.ToString());
                    string OwnallPID = mydrv["OwnallPID"].ToString();
                    try
                    {
                        BLL.Delete(ID);
                    }
                    catch
                    { }
                }
            }
        }
        if (cal != "")
        {
            sql += cal.Substring(0, cal.Length - 3);
            sql2 += cal.Substring(0, cal.Length - 3);
        }
        else
        {
            sql = "";       //不删除
            sql2 = "";       //不删除
            Response.Write("<script language=javascript>alert('您没有选择要删除的记录!');history.back(-1);</script>");
            Response.End();
        }

        DbHelperSQL.ExecuteSql(sql);
        DbHelperSQL.ExecuteSql(sql2);

        AdminloginMess LogAM = new AdminloginMess();
        LogAM.Add_Logs("销售管理--->销售合同管理--->合同单删除 操作成功！");

        this.DataShows();
    }
    /// <summary>
    /// 返回仓库唯一值
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetHouseNo(object ContractNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ContractNo,HouseNo from KNet_Sales_ContractList where ContractNo='" + ContractNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["HouseNo"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }



    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button4_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }



    /// <summary>
    /// 获取单明细数目 （Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu(string ContractNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as IDS  from KNet_Sales_ContractList_Details where ContractNo='" + ContractNo + "'";
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

    public string GetCgNumer(string s_ProductsBarCode,string s_ContractNo)
    {
        try
        {
            this.BeginQuery("Select SUM(OrderAmount) from Knet_Procure_OrdersList_Details Where ProductsBarCode='" + s_ProductsBarCode + "' and OrderNo in (Select OrderNo From Knet_Procure_OrdersList Where ContractNo='" + s_ContractNo + "')");
            this.QueryForDataTable();
            if (Dtb_Result.Rows.Count > 0)
            {
                return Dtb_Result.Rows[0][0].ToString();
            }
            else
            {
                return "";
            }

        }
        catch (Exception ex)
        {
            return "";
        }
    }
    public string GetRkNumber(string s_ProductsBarCode, string s_ContractNo)
    {
        this.BeginQuery("Select SUM(OrderHaveReceiving) from Knet_Procure_OrdersList_Details Where ProductsBarCode='" + s_ProductsBarCode + "' and OrderNo in (Select OrderNo From Knet_Procure_OrdersList Where ContractNo='" + s_ContractNo + "')");
        this.QueryForDataTable();
        if (Dtb_Result.Rows.Count > 0)
        {
            return Dtb_Result.Rows[0][0].ToString();
        }
        else
        {
            return "";
        }
    }
    public string GetFHNumber(string s_ProductsBarCode, string s_ContractNo)
    {
        this.BeginQuery("Select Sum(OutWareAmount) from KNet_Sales_OutWareList_Details Where ProductsBarCode='" + s_ProductsBarCode + "' and OutWareNo in (Select OutWareNo From KNet_Sales_OutWareList Where ContractNo='" + s_ContractNo + "')");
        this.QueryForDataTable();
        if (Dtb_Result.Rows.Count > 0)
        {
            return Dtb_Result.Rows[0][0].ToString();
        }
        else
        {
            return "";
        }
    }

    public string GetCkNumber(string s_ProductsBarCode, string s_ContractNo)
    {
        this.BeginQuery("Select DirectOutAmount from KNet_WareHouse_DirectOutList_Details Where ProductsBarCode='" + s_ProductsBarCode + "' and DirectOutNo in (Select DirectOutNo From KNet_WareHouse_DirectOutList Where KWD_ShipNo in (Select OutWareNo From KNet_Sales_OutWareList Where ContractNo='" + s_ContractNo + "')) ");
        this.QueryForDataTable();
        if (Dtb_Result.Rows.Count > 0)
        {
            return Dtb_Result.Rows[0][0].ToString();
        }
        else
        {
            return "";
        }
    }
    public string GetShipDate(string s_ContractNo)
    {
        string s_Return = "";
        KNet.BLL.KNet_Sales_ContractList BLL = new KNet.BLL.KNet_Sales_ContractList();
        KNet.Model.KNet_Sales_ContractList Model = BLL.GetModelB(s_ContractNo);
        if (Model.ContractToDeliDate.ToString() != "")
        {
                 s_Return = DateTime.Parse(Model.ContractToDeliDate.ToString()).ToShortDateString() ;
        }
        return s_Return;
    }

    public string GetShipDateURL(string s_ContractNo)
    {
        string s_Return = "";
        KNet.BLL.KNet_Sales_ContractList BLL = new KNet.BLL.KNet_Sales_ContractList();
        KNet.Model.KNet_Sales_ContractList Model = BLL.GetModelB(s_ContractNo);
        if (Model.ContractToDeliDate.ToString() != "")
        {
            string JSD = "../Sales/Knet_Sales_Ship_Manage_Manage.aspx?ContractNo=" + s_ContractNo + "";
            string StrPop = "<a href=\"#\" onclick=\"javascript:window.open('" + JSD + "','','top=150,left=200,toolbar=yes, menubar=yes,scrollbars=yes, resizable=yes, location=yes, status=no, width=800,height=600');\"  title=\"点击进行操作\">查看</a>&nbsp;&nbsp;";

            s_Return =  StrPop;
        }
        return s_Return;
    }
    protected void Btn_Save_Click(object sender, EventArgs e)
    {

        AdminloginMess AM = new AdminloginMess();
        int i_num = 0;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            string s_NeedDate = ((TextBox)GridView1.Rows[i].Cells[1].FindControl("Tbx_NeedDate")).Text;
            string s_OldDate = ((TextBox)GridView1.Rows[i].Cells[1].FindControl("Tbx_OldDate")).Text;
            string s_NeedReDate = ((TextBox)GridView1.Rows[i].Cells[1].FindControl("Tbx_NeedReDate")).Text;
            string s_OldReDate = ((TextBox)GridView1.Rows[i].Cells[1].FindControl("Tbx_OldReDate")).Text;
            string s_ContractNo = ((TextBox)GridView1.Rows[i].Cells[1].FindControl("Tbx_ContractNo")).Text;
            
            if(s_NeedDate!=s_OldDate)
            {
                KNet.Model.KNet_ContractDate Model = new KNet.Model.KNet_ContractDate();
                KNet.BLL.KNet_ContractDate BLL = new KNet.BLL.KNet_ContractDate();
                Model.KC_ContractNo = s_ContractNo;
                Model.KC_OldDate =DateTime.Parse(s_OldDate);
                Model.KC_Date = DateTime.Parse(s_NeedDate);
                Model.KC_Type = 0;
                Model.KC_AddDate = DateTime.Now;
                Model.KC_AddPerson = AM.KNet_StaffNo;
                if (BLL.Add(Model) != 0)
                {
                    i_num++;
                }

                KNet.Model.KNet_Sales_ContractList Model_ContractList = new KNet.Model.KNet_Sales_ContractList();
                KNet.BLL.KNet_Sales_ContractList BLL_ContractList = new KNet.BLL.KNet_Sales_ContractList();
                Model_ContractList.ContractNo = s_ContractNo;
                Model_ContractList.ContractToDeliDate = DateTime.Parse(s_NeedDate);
                BLL_ContractList.UpdateShipDate(Model_ContractList);
            }

            if (s_NeedReDate != s_OldReDate)
            {
                KNet.Model.KNet_ContractDate Model = new KNet.Model.KNet_ContractDate();
                KNet.BLL.KNet_ContractDate BLL = new KNet.BLL.KNet_ContractDate();
                Model.KC_ContractNo = s_ContractNo;
                if (s_OldReDate != "")
                {
                    Model.KC_OldDate = DateTime.Parse(s_OldReDate);
                }
                if (s_NeedReDate != "")
                {
                    Model.KC_Date = DateTime.Parse(s_NeedReDate);
                }
                Model.KC_Type = 1;
                Model.KC_AddDate = DateTime.Now;
                Model.KC_AddPerson = AM.KNet_StaffNo;
                if (BLL.Add(Model) != 0)
                {
                    i_num++;
                }

                KNet.Model.KNet_Sales_ContractList Model_ContractList = new KNet.Model.KNet_Sales_ContractList();
                KNet.BLL.KNet_Sales_ContractList BLL_ContractList = new KNet.BLL.KNet_Sales_ContractList();
                Model_ContractList.ContractNo = s_ContractNo;

                if (s_NeedReDate != "")
                {
                    Model_ContractList.KFC_ReDate = DateTime.Parse(s_NeedReDate);
                }
                BLL_ContractList.UpdateDate(Model_ContractList);
            }
        }
        AlertAndRedirect("已更新"+i_num+"条交货期","KNet_Sales_ContractList_Manage.aspx?Type=1");
    }

    protected void Btn_Modiy_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (this.Btn_Modiy.Text == "取 消")
        {

            this.Btn_Save.Enabled = false;
            this.Btn_Modiy.Text = "修 改";

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {

                if ((AM.KNet_StaffDepart == "129652784446995911") || (AM.KNet_StaffDepart == "129652783965723459") || (AM.KNet_StaffDepart == "129652784259578018"))
                {
                    TextBox Tbx_NeedReDate = (TextBox)GridView1.Rows[i].Cells[1].FindControl("Tbx_NeedReDate");
                    Label Lbl_NeedReDate = (Label)GridView1.Rows[i].Cells[1].FindControl("Lbl_NeedReDate");
                    Tbx_NeedReDate.Visible = false;
                    Lbl_NeedReDate.Visible = true;

                }
                else
                {
                    TextBox Tbx_NeedDate = (TextBox)GridView1.Rows[i].Cells[1].FindControl("Tbx_NeedDate");
                    Label Lbl_NeedDate = (Label)GridView1.Rows[i].Cells[1].FindControl("Lbl_NeedDate");
                    Tbx_NeedDate.Visible = false;
                    Lbl_NeedDate.Visible = true;
                }
            }
        }
        else
        {

            this.Btn_Save.Enabled = true;
            this.Btn_Modiy.Text = "取 消";
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if ((AM.KNet_StaffDepart == "129652784446995911") || (AM.KNet_StaffDepart == "129652783965723459") || (AM.KNet_StaffDepart == "129652784259578018"))
                {
                    TextBox Tbx_NeedReDate = (TextBox)GridView1.Rows[i].Cells[1].FindControl("Tbx_NeedReDate");
                    Label Lbl_NeedReDate = (Label)GridView1.Rows[i].Cells[1].FindControl("Lbl_NeedReDate");
                    Tbx_NeedReDate.Visible = true;
                    Lbl_NeedReDate.Visible = false;

                }
                else
                {
                    TextBox Tbx_NeedDate = (TextBox)GridView1.Rows[i].Cells[1].FindControl("Tbx_NeedDate");
                    Label Lbl_NeedDate = (Label)GridView1.Rows[i].Cells[1].FindControl("Lbl_NeedDate");
                    Tbx_NeedDate.Visible = true;
                    Lbl_NeedDate.Visible = false;
                }
            }
 
        }
    }
}

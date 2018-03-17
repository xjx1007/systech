using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 修改
/// </summary>
public partial class Knet_WareHouse_KNet_WareHouse_WareCheck_Manage_PrinterList_Update : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        KNet.DBUtility.AdminloginMess AMLanguage = new KNet.DBUtility.AdminloginMess();
        if (AMLanguage.KNet_Soft_StaffLanguage == 2)
        {
            // 1、默认为简体转繁体，编码为utf-8
            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter);
        }
        else if (AMLanguage.KNet_Soft_StaffLanguage == 1)
        {
            // 2、繁体简体转，编码为utf-8
            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter, LU.Web.ChineseConvertor.CCDirection.T2S);
        }
        else
        { }
    }
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
            else
            {


                if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
                {
                    this.ShowInfo(Request.QueryString["ID"].Trim());
                }
                else
                {
                    Response.Write("<script>alert('非法参数，非法请求！');history.back(-1);</script>");
                    Response.End();
                }
            }
        }
    }


    /// <summary>
    /// 明细绑定及选定
    /// </summary>
    protected void DBbindAuthList(CheckBoxList CLT, string Tex_ID)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string DoSqls2 = "select * from KNet_WareHouse_WareCheckList_Printer_Value where Tex_ID='" + Tex_ID + "' order by Tex_pai desc";
            using (SqlCommand cmd2 = new SqlCommand(DoSqls2, conn))
            {
                SqlDataReader DR = cmd2.ExecuteReader();
                while (DR.Read())
                {
                    for (int i = 0; i < CLT.Items.Count; i++)
                    {
                        if (CLT.Items[i].Value == DR["Tex_Value"].ToString())
                        {
                            CLT.Items[i].Selected = true;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// 总信息显示
    /// </summary>
    /// <param name="ID"></param>
    private void ShowInfo(string ID)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select * from KNet_WareHouse_WareCheckList_Printer_Setup where ID='" + ID + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.PrinterTitle.Text = dr["PrinterTitle"].ToString();

                this.txtTopComtont.Text = dr["TopComtont"].ToString();
                this.txtBotComtont.Text = dr["BotComtont"].ToString();

                this.PrinterYN.Checked = bool.Parse(dr["PrinterYN"].ToString());
                this.PrintStatShow.Checked = bool.Parse(dr["PrintStatShow"].ToString());

                this.PrintAmount_Recodor.Checked = bool.Parse(dr["PrintAmount_Recodor"].ToString());
                this.PrintAmount_Sum.Checked = bool.Parse(dr["PrintAmount_Sum"].ToString());
                this.PrintDiscount_Sum.Checked = bool.Parse(dr["PrintDiscount_Sum"].ToString());
                this.PrintTotalNet_Sum.Checked = bool.Parse(dr["PrintTotalNet_Sum"].ToString());

                this.SID.Text = dr["ID"].ToString();
                this.Tex_ID.Text = dr["Tex_ID"].ToString();


                //if (bool.Parse(dr["DefaultPrinter"].ToString()) == true)
                //{
                //    this.Button2.Enabled = false;
                //    this.Button2.Text = "默认模板不可修改";
                //}
                //else
                //{
                    this.Button2.Enabled = true;
                    this.Button2.Text = "确定库存盘点单打印模板修改";
                //}

                //明细设置
                this.DBbindAuthList(this.CheckBoxList1, dr["Tex_ID"].ToString());
            }
            else
            {
                Response.Write("<script>alert('非法参数，非法请求2！');history.back(-1);</script>");
                Response.End();
            }
        }
    }

    /// <summary>
    /// 删除一条数据
    /// </summary>
    public void Delete(string Tex_ID)
    {
        int rowsAffected;
        SqlParameter[] parameters = {
					new SqlParameter("@Tex_ID", SqlDbType.NVarChar,50)};
        parameters[0].Value = Tex_ID;

        DbHelperSQL.RunProcedure("Proc_KNet_WareHouse_WareCheckList_Printer_Value_Delete", parameters, out rowsAffected);
    }

    /// <summary>
    /// 确定设置
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click1(object sender, EventArgs e)
    {
        //总报价单设置

        string ID = this.SID.Text.Trim();
        string Tex_ID = this.Tex_ID.Text.Trim();


        string PrinterTitle = this.PrinterTitle.Text.Trim();
        bool PrinterYN = this.PrinterYN.Checked;
        DateTime PrinterDatetime = DateTime.Now;
        string TopComtont = this.txtTopComtont.Text.Trim();
        string BotComtont = this.txtBotComtont.Text.Trim();
        bool PrintStatShow = this.PrintStatShow.Checked;
        bool PrintAmount_Recodor = this.PrintAmount_Recodor.Checked;
        bool PrintAmount_Sum = this.PrintAmount_Sum.Checked;
        bool PrintDiscount_Sum = this.PrintDiscount_Sum.Checked;
        bool PrintTotalNet_Sum = this.PrintTotalNet_Sum.Checked;



        KNet.BLL.KNet_WareHouse_WareCheckList_Printer_Setup BLL = new KNet.BLL.KNet_WareHouse_WareCheckList_Printer_Setup();
        KNet.Model.KNet_WareHouse_WareCheckList_Printer_Setup model = new KNet.Model.KNet_WareHouse_WareCheckList_Printer_Setup();

        model.ID = ID;
        model.Tex_ID = Tex_ID;
        model.PrinterTitle = PrinterTitle;
        model.PrinterYN = PrinterYN;
        model.PrinterDatetime = PrinterDatetime;
        model.TopComtont = TopComtont;
        model.BotComtont = BotComtont;
        model.PrintStatShow = PrintStatShow;
        model.PrintAmount_Recodor = PrintAmount_Recodor;
        model.PrintAmount_Sum = PrintAmount_Sum;
        model.PrintDiscount_Sum = PrintDiscount_Sum;
        model.PrintTotalNet_Sum = PrintTotalNet_Sum;

        //明细设置
        try
        {
            this.Delete(Tex_ID);

            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected == true)
                {
                    this.AndOpenBillingPrinter_Value(CheckBoxList1.Items[i].Value, CheckBoxList1.Items[i].Text, CheckBoxList1.Items.Count - i, Tex_ID);
                }
            }
        }
        catch { }
       
        try
        {
            BLL.Update(model);
            //明细设置
            AdminloginMess AMlog = new AdminloginMess();
            AMlog.Add_Logs("直接出库单打印模板修改成功.");

            Response.Write("<script>alert('库存盘点单打印模板修改成功！');this.location.href = 'KNet_WareHouse_WareCheck_Manage_PrinterListSetting.aspx?Css5=Div22';</script>");
            Response.End();
        }
        catch { throw; }
    }

    /// <summary>
    /// 明细打印设置
    /// </summary>
    protected void AndOpenBillingPrinter_Value(string Tex_Value, string Tex_Texte, int Tex_pai, string Tex_ID)
    {
        string DoSql = "INSERT INTO KNet_WareHouse_WareCheckList_Printer_Value(Tex_Value,Tex_Texte,Tex_pai,Tex_ID) VALUES ('" + Tex_Value + "','" + Tex_Texte + "'," + Tex_pai + ",'" + Tex_ID + "')";
        DbHelperSQL.ExecuteSql(DoSql);
    }

    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button4_Click(object sender, EventArgs e)
    {
        string LogtimeA = StartDate.Text.ToString().Trim();
        string LogtimeB = EndDate.Text.ToString().Trim();
        string SeachKeyContent = KNetPage.KHtmlEncode(SeachKey.Text.ToString());
        if ((LogtimeA == "" && LogtimeB != "") || (LogtimeA != "" && LogtimeB == ""))
        {
            Response.Write("<script language=javascript>alert('您所选择的日期一定要有 开始日期 和 结束日期!');history.back(-1);</script>");
            Response.End();
        }
        Response.Redirect("KNet_WareHouse_WareCheck_Manage_PrinterListSetting.aspx?LogtimeA=" + LogtimeA + "&LogtimeB=" + LogtimeB + "&SeachKey=" + SeachKeyContent + "&Css5=Div22");
        Response.End();
    }



}

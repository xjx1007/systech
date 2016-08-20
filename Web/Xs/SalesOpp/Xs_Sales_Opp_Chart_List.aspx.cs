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
using System.IO;
using System.Text;
using System.Drawing;
using KNet.DBUtility;
using KNet.Common;

public partial class Web_Sales_Xs_Sales_Opp_Chart_List : BasePage
{
    public string s_AdvShow = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            base.Base_DropBatchBindBySql(this.Ddl_Batch, "Xs_Sales_Opp", "XSO_DutyPerson", " and StaffNo in (select StaffNo from KNet_Resource_Staff where IsSale='1' and StaffYN='0')");
            AdminloginMess AM = new AdminloginMess();
            //销售机会列表
            if (AM.CheckLogin("销售机会列表") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                base.Base_DropBasicCodeBind(this.Ddl_SalesType, "202");
                DataBind();
            }
        }
        
    }
    public void DataBind()
    {
        string s_Where="";
        string s_Sql = "select PBC_Name as 阶段,Count(b.XSO_ID) as 数量 from PB_Basic_Code a";
        s_Sql += " left join Xs_Sales_Opp b on b.XSO_SalesStep=a.PBC_Code  and  XSO_Del=0 ";
        if (Ddl_Batch.SelectedValue != "")
        {
            s_Where += Base_GetBasicWhere(this.Ddl_Batch.SelectedValue);
        }
        if (Ddl_SalesType.SelectedValue != "")
        {
            s_Where += " and XSO_SalesType='" + Ddl_SalesType.SelectedValue + "' ";
        }
        if (this.StartDate.Text != "")
        {
            s_Where += " and XSO_PlanDealDateTime>='" + this.StartDate.Text + "' ";
        }
        if (this.EndDate.Text != "")
        {
            s_Where += " and XSO_PlanDealDateTime<='" + this.EndDate.Text + "' ";
        }
        s_Sql+=s_Where;
        s_Sql += " where PBC_ID='118' group by PBC_Name ";
        this.BeginQuery(s_Sql);
        this.QueryForDataSet();
        /*选择外观基调*/
        Chartlet1.Width = 600;
        Chartlet1.AppearanceStyle = FanG.Chartlet.AppearanceStyles.Pie_2D_Aurora_FlatCrystal_NoGlow_NoBorder;
        Chartlet1.GroupSize = 200;
        //关闭投影效果
        Chartlet1.Shadow.Enable = false;
        Chartlet1.ColorGuider.Font = new Font("宋体", 7);
        //通过下面一句调整标题的高度
        Chartlet1.ChartTitle.Text = "各销售阶段销售机会数量";
        Chartlet1.ChartTitle.OffsetY = -30;
        Chartlet1.BindChartData(this.Dts_Result);
        KNet.BLL.Xs_Sales_Opp Bll = new KNet.BLL.Xs_Sales_Opp();
        DataSet Dts_Opp = Bll.GetList(" XSO_Del='0' "+s_Where);
        this.MyGridView1.DataSource = Dts_Opp;
        this.MyGridView1.DataBind();
        //下面一句是TrendChart必须要有的，是TrendChart中最重要的设置(StartTime,EndTime,TimeSpanType,XLabelDisplayFormat)
        //如果你使用TrendChart，但是缺少了这一句，那么系统会提示：Please Set Chartlet.Trend attribute for Trend Chart
        //详细介绍请参看Chartlet.Trend的参考手册
        string s_Sql1 = "select PBC_Name as 阶段,Count(b.XSO_ID) as 数量 from PB_Basic_Code a";
        s_Sql1 += " left join Xs_Sales_Opp b on b.XSO_SalesType=a.PBC_Code and XSO_Del=0 ";
        if (Ddl_Batch.SelectedValue != "")
        {
            s_Sql += Base_GetBasicWhere(this.Ddl_Batch.SelectedValue);
        }
        if (Ddl_SalesType.SelectedValue != "")
        {
            s_Sql += " and XSO_SalesType='" + Ddl_SalesType.SelectedValue + "' ";
        }
        if (this.StartDate.Text != "")
        {
            s_Sql += " and XSO_PlanDealDateTime>='" + this.StartDate.Text + "' ";
        }
        if (this.EndDate.Text != "")
        {
            s_Sql += " and XSO_PlanDealDateTime<='" + this.EndDate.Text + "' ";
        }
        s_Sql1+="where PBC_ID='202' group by PBC_Name ";
        this.BeginQuery(s_Sql1);
        this.QueryForDataSet();
        /*选择外观基调*/
        Chartlet2.Width = 600;
        Chartlet2.AppearanceStyle = FanG.Chartlet.AppearanceStyles.Pie_2D_Aurora_FlatCrystal_NoGlow_NoBorder;
        Chartlet2.GroupSize = 200;
        //关闭投影效果
        Chartlet2.Shadow.Enable = false;
        Chartlet2.ColorGuider.Font = new Font("宋体", 7);
        //通过下面一句调整标题的高度
        Chartlet2.ChartTitle.Text = "各销售过程销售机会数量";
        Chartlet2.ChartTitle.OffsetY = -30;
        Chartlet2.BindChartData(this.Dts_Result);
    }
    public void btnAdvancedSearch_Click(object sender, EventArgs e)
    {
        DataBind();
    }
}

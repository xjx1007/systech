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
using System.Data.SqlClient;

using KNet.DBUtility;
using KNet.Common;


public partial class Web_Report_Details : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime datetime = DateTime.Now;
            this.StartDate.Text = datetime.AddMonths(-1).AddDays(1 - datetime.Day).ToShortDateString();
            this.EndDate.Text = datetime.AddDays(1 - datetime.Day).AddDays(-1).ToShortDateString();
            base.Base_DropWareHouseBind(this.HouseNo, " KSW_Type='0' ");
            Tbx_Year.Text = datetime.Year.ToString();
            this.Tbx_Month.Text = datetime.AddMonths(-1).Month.ToString();
            this.Tbx_ProductsTypeNo.Text = "02";
            this.Tbx_ProductsTypeName.Text = "采购类产品 (02)";
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess AM = new AdminloginMess();
            string s_DoSql = "exec CalculationAllWwPrice '" + this.Tbx_Month.Text + "','" + this.Tbx_Year.Text + "'";
            if (DbHelperSQL.ExecuteSql(s_DoSql.ToString())>0)
            {
                Alert("计算成功！");
                AM.Add_Logs("计算委外价格：年：" + this.Tbx_Year.Text + " 月" + this.Tbx_Month.Text);
            }
            
        }
        catch
        { }
    }
}

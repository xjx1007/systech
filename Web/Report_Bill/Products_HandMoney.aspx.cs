using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Report_Bill_Products_HandMoney : BasePage
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
            DateTime datetime = DateTime.Now;
            //this.StartDate.Text = datetime.AddMonths(-1).AddDays(1 - datetime.Day).ToShortDateString();
            //this.EndDate.Text = datetime.AddDays(1 - datetime.Day).AddDays(-1).ToShortDateString();
            //base.Base_DropWareHouseBind(this.HouseNo, " KSW_Type='0' ");
            Tbx_Year.Text = datetime.Year.ToString();
            this.Tbx_Month.Text = datetime.AddMonths(-1).Month.ToString();
            //this.Tbx_ProductsTypeNo.Text = "M160818111423567";
            //this.Tbx_ProductsTypeName.Text = "采购类产品 (02)";
        }
    }

    protected void Button2_OnClick(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess AM = new AdminloginMess();
            //先执行库存
            this.Button2.Text = "计算中....";
            // string s_DoSql = " exec Pro_UpdateStore ";
            int i_Row1;
            //   SqlParameter[] parameters1 = { };
            // DbHelperSQL.RunProcedure("Pro_UpdateStore", parameters1, out i_Row1);


            //  s_DoSql = "exec CalculationAllWwPrice '" + this.Tbx_Month.Text + "','" + this.Tbx_Year.Text + "'";

            SqlParameter[] parameters = {
                    new SqlParameter("@Month", SqlDbType.NVarChar,20),
                    new SqlParameter("@Year", SqlDbType.NVarChar,20)};
            parameters[0].Value = this.Tbx_Month.Text;
            parameters[1].Value = this.Tbx_Year.Text;
            int i_Row;
            DbHelperSQL.RunProcedure("CalculateManMoney", parameters, out i_Row);

            if (i_Row > 0)
            {
                // DbHelperSQL.RunProcedure("Pro_UpdateStore", parameters1, out i_Row1);
                this.Button2.Text = "计算完成";
                AM.Add_Logs("计算委外价格：年：" + this.Tbx_Year.Text + " 月" + this.Tbx_Month.Text);
                Alert("计算成功！");

            }
            //this.Button2.Text = "计算";

        }
        catch (Exception ex)
        {
            this.Button2.Text = "计算";
            Alert("计算失败！");
        }
    }
}
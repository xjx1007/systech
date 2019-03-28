using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Report_Bill_Report_Tax_Rate : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.KNet_StaffName!="薛建新")
            {
                Response.Write("<script language=javascript>alert('你没有修改税率的权限')</script>");
                Response.Write("<script>history.go(-2);</script>");
            }
        }
       
    }

    protected void Button1_OnServerClick(object sender, EventArgs e)
    {
        string insert_sql = "insert into KNet_Tax_Rate (Old_TaxRate,New_TaxRate,CTime) VALUES('" + Old_TaxRate.Text + "','" + New_TaxRate.Text + "','"+ DateTime.Now +"') ";//插入一条洗的
        decimal oldTaxRate = decimal.Parse(Old_TaxRate.Text);
        decimal newTaxRate = decimal.Parse(New_TaxRate.Text);
        string update_Handprice =
            "update Knet_Procure_SuppliersPrice set KPP_PCPrice=CAST((KPP_PCPrice/"+oldTaxRate+")*"+newTaxRate+ " as decimal(18,2)),HandPrice=cast((HandPrice/" + oldTaxRate + ")*" + newTaxRate + " as decimal(18,2)),ProcureUnitPrice=cast((ProcureUnitPrice/" + oldTaxRate + ")*" + newTaxRate + " as decimal(18,4))";

        //int a = DbHelperSQL.ExecuteSql(insert_sql);
        //int b = DbHelperSQL.ExecuteSql(update_Handprice);

    }

    protected void Button2_OnServerClick(object sender, EventArgs e)
    {
        string backups_sql ="update Knet_Procure_SuppliersPrice set KPP_TPCPrice=KPP_PCPrice,KPP_THandPrice=HandPrice,KPP_TProcureUnitPrice=ProcureUnitPrice";
        int a= DbHelperSQL.ExecuteSql(backups_sql);
       
        //if (a>0)
        //{
        //    Button1.Visible = true;//显示更改税率按钮
        //    Button2.Visible = false;//隐藏备份数据按钮
        //}
        //else
        //{
        //    Response.Write("<script language=javascript>alert('备份数据失败')</script>");
        //}
        Response.Write("<script language=javascript>alert('" + DateTime.Now.ToShortDateString() + "')</script>");
    }
}
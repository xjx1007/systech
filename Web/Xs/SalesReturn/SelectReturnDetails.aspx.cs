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

using KNet.DBUtility;
using KNet.Common;


public partial class Web_Common_SelectReturnDetails : BasePage
{
    public string s_House = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            s_House = Request.QueryString["House"] == null ? "" : Request.QueryString["House"].ToString();  
                string s_Sql = "";
                s_Sql = "Select a.ReturnNo,b.ID,b.ProductsName,b.ProductsPattern,b.ProductsUnits,b.ReturnAmount,b.ProductsBarCode,a.ReturnDateTime,a.OutWareNo";
                s_Sql += " from KNet_Sales_ReturnList a join KNet_Sales_ReturnList_Details b on a.ReturnNo=b.ReturnNo";
                s_Sql += " Where a.ReturnNo='" + Request.QueryString["ReturnNo"].ToString() + "'";
                this.BeginQuery(s_Sql);
                this.QueryForDataTable();
                this.GridView1.DataSource = this.Dtb_Result;
                this.GridView1.DataKeyNames = new string[] { "ID" };
                this.GridView1.DataBind();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {


        KNet.BLL.KNet_Sales_ReturnList_Details BLL = new KNet.BLL.KNet_Sales_ReturnList_Details();
        int i_Num = 0;
        string s_Return = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            TextBox Tbx_Number = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Number");
            TextBox Tbx_ProductsBarCode = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_ProductsBarCode");
            if (cb.Checked)
            {
                KNet.Model.KNet_Sales_ReturnList_Details model = BLL.GetModel(GridView1.DataKeys[i].Value.ToString());
                string s_ProductsBarCode = GridView1.Rows[i].Cells[2].Text;
                s_Return += Tbx_ProductsBarCode.Text + "," + base.Base_GetProdutsName(Tbx_ProductsBarCode.Text) + "," + base.Base_GetProductsEdition(Tbx_ProductsBarCode.Text) + "," + Tbx_Number.Text;
                i_Num++;
                s_Return += "|";
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 1);
        }
        if (i_Num == 0)
        {
            Alert("您没有选择记录！");
        }
        else
        {
            if (i_Num > 1)
            {
                Alert("只能选择一条记录！");
            }
            else
            {
                StringBuilder s = new StringBuilder();
                s.Append("<script language=javascript>" + "\n");
                s.Append("window.returnValue='" + s_Return + "';" + "\n");
                s.Append("window.close();" + "\n");
                s.Append("</script>");
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                string csname = "ltype";
                if (!cs.IsStartupScriptRegistered(cstype, csname))
                    cs.RegisterStartupScript(cstype, csname, s.ToString());
            }
        }
    }
}

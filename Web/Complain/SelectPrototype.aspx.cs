using System;
using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Complain_SelectPrototype : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "供应商报价选择";

        if (!IsPostBack)
        {

            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }

            else
            {
              
                this.DataShows();
            }
        }
    }
    protected void DataShows()
    {
        KNet.BLL.Knet_Procure_SuppliersPrice bll = new KNet.BLL.Knet_Procure_SuppliersPrice();
        string s_Sql = "select * from KNet_Sampling_List where   AuditState='2' and ID='" + Request.QueryString["SamplingID"].ToString() + "' order by STime desc ";

        this.BeginQuery(s_Sql);
        this.QueryForDataSet();
        DataSet ds = Dts_Result;
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();
      
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string s_Return = "";
        KNet.BLL.KNet_Sampling_List BLL = new KNet.BLL.KNet_Sampling_List();

        string cal = "";
        string s_SuppNo1 = "";
        string s_String = "";
        int j = 0;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                KNet.Model.KNet_Sampling_List model = BLL.GetModel(GridView1.DataKeys[i].Value.ToString());
                string ReID = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("ReID")).Text;

                string SampleName = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("SampleName")).Text;
                string ID = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("ID")).Text;
                string Number = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Number")).Text;
                string Remark = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Remark")).Text;
                string a = "", b = "", c = "", d = "", f = "", g = "", h = "", k = "", y = "", z = "", o = "", s = "", p = "", t = "", r = "";
                s_Return += ID + "," + ReID + "," + SampleName + "," + Number + "," + Remark + "," + a + "," + b + "," + c + "," + d + ",";
                s_Return += f + "," + g + "," + h + "," + k + "," + y + "," + z + "," + o + "," + s + "," + p + "," + t + "," + r + "|";


                cal += GridView1.DataKeys[i].Value.ToString();
              
                j++;
            }
        }
        if (cal == "")
        {
            Response.Write("<script language=javascript>alert('您没有选择要操作的记录!');this.window.close();</script>");
            Response.End();
        }
        else
        {
            if (s_String != "")
            {
                AlertAndGoBack(s_String);
            }
            else
            {
                StringBuilder s = new StringBuilder();
                s.Append("<script language=javascript>" + "\n");
                s.Append("if(window.opener != undefined) {window.opener.returnValue='" + s_Return + "';window.opener.SetReturnValueInOpenner_SuppliersPrice('" + s_Return + "')} ");
                s.Append("else{window.returnValue='" + s_Return + "';}" + "\n");
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
    public string Base_GetProjectGroup(String s_ID)
    {

        String s_Name = "";
        this.BeginQuery("select * from PB_Basic_ProductsClass where PBP_ID='" + s_ID + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            s_Name = Dtb_Re.Rows[0]["PBP_Name"].ToString();
        }
        return s_Name;
    }
}
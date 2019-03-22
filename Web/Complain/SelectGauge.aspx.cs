using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Complain_SelectGauge : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.Page.Title = "供应商报价选择";

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
                string suppno= Request.QueryString["SuppNo"] == null ? "" : Request.QueryString["SuppNo"].ToString();
                if (suppno=="")
                {
                    Alert("请选择仓库");
                    return;
                }
                else
                {
                    this.DataShows(suppno);
                }
               
            }
        }
    }
    protected void DataShows(string suppno)
    {
        //KNet.BLL.KNet_Product_Gauge bll = new KNet.BLL.KNet_Product_Gauge();
        if (suppno== "131235104473261008")
        {
            string s_Sql = "select * from KNet_Product_Gauge where  KPG_SuppNo='" + suppno + "' order by KPG_Time desc ";
            this.BeginQuery(s_Sql);
            this.QueryForDataSet();
            DataSet ds = Dts_Result;
            GridView1.DataSource = ds;
            GridView1.DataKeyNames = new string[] { "KPG_ID" };
            GridView1.DataBind();
        }
        else
        {
            KNet.BLL.KNet_Product_Gauge bll = new KNet.BLL.KNet_Product_Gauge();
            string SqlWhere = " 1=1  ";
          
            SqlWhere += " and KPG_SuppNo='" + suppno + "' ";//a.KPI_UserIn

            SqlWhere = SqlWhere + " order by KPG_Time desc ";
            DataSet ds = bll.GetList(SqlWhere);
            GridView1.DataSource = ds;
            GridView1.DataKeyNames = new string[] { "KPG_ID" };
            GridView1.DataBind();
        }

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
                string ReID = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("KPG_KID")).Text;

                string SampleName = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("KPG_Name")).Text;
                string KCount = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("KCount")).Text;

                //string a = "", b = "", c = "", d = "", f = "", g = "", h = "", k = "", y = "", z = "", o = "", s = "", p = "", t = "", r = "";
                //s_Return += ReID + "," + SampleName + "," + KCount +  "|";

                string a = "", b = "", c = "", d = "", f = "", g = "", h = "", k = "", y = "", z = "", o = "", s = "", p = "", t = "", r = "";
                s_Return += ReID + "," + SampleName + "," + KCount + "," + 0 + "," + "" + "," + a + "," + b + "," + c + "," + d + ",";
                s_Return += f + "," + g + "," + h + "," + k + "," + y + "," + z + "," + o + "," + s + "," + p + "," + t + "," + r + "|";

                cal += GridView1.DataKeys[i].Value.ToString();
                //if (j > 0)
                //{
                //    s_SuppNo1 = ((TextBox)GridView1.Rows[j - 1].Cells[0].FindControl("Tbx_SuppNo")).Text;
                //    if (s_SuppNo1 != s_SuppNo)
                //    {
                //        s_String = "供应商不同，请重新选择";
                //    }
                //}
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
    public string Base_GetStoreCount(string suppno, string id)
    {
        int s_Count = 0;
        this.BeginQuery("select ISNULL( sum(KPG_Number),0) from KNet_Product_Gauge where KPG_SuppNo='" + suppno + "' and KPG_KID='" + id + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re1 = Dtb_Result;//本地库存
        this.BeginQuery("select ISNULL( sum(KPI_Number),0) from KNet_Product_Gauge_InOut where KPI_UseFrom='" + suppno + "' and KPI_InOut=0 and KPI_Code='" + id + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re2 = Dtb_Result;//借出
        this.BeginQuery("select ISNULL( sum(KPI_Number),0) from KNet_Product_Gauge_InOut where KPI_UserIn='" + suppno + "' and KPI_InOut=0 and KPI_Code='" + id + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re3 = Dtb_Result;//借出
        this.BeginQuery("select ISNULL( sum(KPI_Number),0) from KNet_Product_Gauge_InOut where KPI_UserIn='" + suppno + "' and KPI_InOut=1 and KPI_Code='" + id + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re4 = Dtb_Result;//归还
        this.BeginQuery("select ISNULL( sum(KPI_Number),0) from KNet_Product_Gauge_InOut where KPI_UseFrom='" + suppno + "' and KPI_InOut=1 and KPI_Code='" + id + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re5 = Dtb_Result;//归还
        s_Count = int.Parse(Dtb_Re1.Rows[0][0].ToString()) - int.Parse(Dtb_Re2.Rows[0][0].ToString()) +
                  int.Parse(Dtb_Re3.Rows[0][0].ToString()) + int.Parse(Dtb_Re4.Rows[0][0].ToString()) - int.Parse(Dtb_Re5.Rows[0][0].ToString());
        return s_Count.ToString();
    }
}
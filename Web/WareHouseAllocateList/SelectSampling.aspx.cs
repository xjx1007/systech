using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_WareHouseAllocateList_SelectSampling : BasePage
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
                //BuildTree("1", null);
                //this.TreeView1.CollapseAll();
                //this.TreeView1.Nodes[0].Expand();
                //this.TreeView1.Nodes[0].Select();
                this.DataShows();
            }
        }
    }

    protected void DataShows()
    {
        KNet.BLL.Knet_Procure_SuppliersPrice bll = new KNet.BLL.Knet_Procure_SuppliersPrice();
        //string isModiy = Request.QueryString["isModiy"] == null ? "" : Request.QueryString["isModiy"].ToString();
        //string s_ProductsID = Request.QueryString["sID"] == null ? "" : Request.QueryString["sID"].ToString();
        //string s_ContractNo = Request.QueryString["Contract"] == null ? "" : Request.QueryString["Contract"].ToString();
        string s_Sql =
            "select * from KNet_Sampling_List a join Knet_Procure_OrdersList_Details b  on a.ID=b.ProductsBarCode where a.InState='0' ";
        //s_Sql += "left join KNet_Sales_ContractList_Details a on a.ProductsBarCode=b.ProductsBarCode  and b.ProcureState=1 and isnull(KPP_Del,'0')='0' ";
        //string SqlWhere = " where 1=1 and b.KPP_Del=0  and b.KPP_State=1  and e.KSP_Del=0 ";

        //if (Request["SuppNo"] != null && Request["SuppNo"] != "")
        //{
        //    string SuppNo = Request.QueryString["SuppNo"].ToString().Trim();
        //    SqlWhere = SqlWhere + " and b.SuppNo = '" + SuppNo + "' ";
        //}

        //if (Request["ScNo"] != null && Request["ScNo"] != "")
        //{
        //    string SuppNo = Request.QueryString["ScNo"].ToString().Trim();
        //    SqlWhere = SqlWhere + " and b.ProductsBarCode in(select XPD_ProductsBarCode from v_Order_ProductsDemo_Details where OrderNo='" + Request["ScNo"].ToString() + "'  ) ";
        //}
        //if (this.SeachKey.Text != "")
        //{
        //    string KSeachKey = this.SeachKey.Text;
        //    SqlWhere = SqlWhere + " and ( e.ProductsName  like '%" + KSeachKey + "%' or e.ProductsPattern  like '%" + KSeachKey + "%' or e.ProductsEdition  like '%" + KSeachKey + "%' )";
        //}

        //if (this.Tbx_Code.Text != "")
        //{
        //    string BarCode = this.Tbx_Code.Text;
        //    SqlWhere = SqlWhere + " and ( KSP_Code  like '%" + BarCode + "%'  )";
        //}

        //if (isModiy == "")
        //{
        //    if (Request["Contract"] != null && Request["Contract"] != "")
        //    {
        //        string s_ContractNo1 = Request["Contract"].ToString();
        //        SqlWhere = SqlWhere + " and a.ContractNo in ('" + s_ContractNo1.Replace(",", "','") + "')";
        //    }
        //}
        ////if (this.TreeView1.SelectedNode.Value != "1")
        ////{
        ////    KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
        ////    string s_SonID = Bll_ProductsDetails.GetSonIDs(this.TreeView1.SelectedNode.Value);
        ////    s_SonID = s_SonID.Replace(",", "','");
        ////    SqlWhere += " and e.ProductsType in ('" + s_SonID + "') ";
        ////}
        //if (s_ProductsID != "")
        //{
        //    SqlWhere += " and b.ProductsBarCode not in ('" + s_ProductsID.Substring(0, s_ProductsID.Length - 1).Replace(",", "','") + "') ";
        //}
        this.BeginQuery(s_Sql);
        this.QueryForDataSet();
        DataSet ds = Dts_Result;
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] {"ID"};
        GridView1.DataBind();
        //if (ds.Tables[0].Rows.Count <= 0)
        //{
        //    if (s_ContractNo != "")
        //    {
        //        s_Sql = "select a.*,isnull(ProcureUnitPrice,0) ProcureUnitPrice,isnull(HandPrice,0) HandPrice,b.* from KNet_Sales_ContractList_Details a ";
        //        s_Sql += "left join  Knet_Procure_SuppliersPrice b on a.ProductsBarCode=b.ProductsBarCode and b.ProcureState=1 and isnull(KPP_Del,'0')='0' ";

        //        this.BeginQuery(s_Sql + SqlWhere);
        //        this.QueryForDataSet();
        //        DataSet ds1 = Dts_Result;
        //        GridView1.DataSource = ds1;
        //        GridView1.DataKeyNames = new string[] { "ID" };
        //        GridView1.DataBind();
        //    }

        //}
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
            CheckBox cb = (CheckBox) GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked == true)
            {
                KNet.Model.KNet_Sampling_List model = BLL.GetModel(GridView1.DataKeys[i].Value.ToString());
                string ID = ((TextBox) GridView1.Rows[i].Cells[0].FindControl("ID")).Text;

                string SampleName = ((TextBox) GridView1.Rows[i].Cells[0].FindControl("SampleName")).Text;

                //string Number = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Number")).Text;
                string Price = ((TextBox) GridView1.Rows[i].Cells[0].FindControl("OrderUnitPrice")).Text;
                string Number = ((TextBox) GridView1.Rows[i].Cells[0].FindControl("OrderAmount")).Text;
                string a = "",
                    b = "",
                    c = "",
                    d = "",
                    f = "",
                    g = "",
                    h = "",
                    k = "",
                    y = "",
                    z = "",
                    o = "",
                    s = "",
                    p = "",
                    t = "",
                    r = "";
                //s_Return += SampleName + "," + ID + "," + a + "," + b + "," + Number + "," + c + "," + d + ",";
                //s_Return += f + "," + g + "," + h + "," + k + "," + y + "," + z + "," + o + "," + s + "," + p + "," + t + "," + r + "|";

                //string s_ProductsBarCode = GridView1.Rows[i].Cells[1].Text;
                //string s_ProductsName = GridView1.Rows[i].Cells[2].Text;
                //string s_ProductsPattern = GridView1.Rows[i].Cells[3].Text;
                //string s_ProductsEdition = GridView1.Rows[i].Cells[4].Text;
                //string s_Price = "0";
                //string s_Number = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Number")).Text;
                //s_Price = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Price")).Text;
                //s_Price = s_Price == "" ? "0" : s_Price;
                //s_Number = s_Number == "" ? "1" : s_Number;
                //string s_Remark = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Remark")).Text;
                //decimal s_Money = decimal.Parse(s_Price) * decimal.Parse(s_Number);
                s_Return += SampleName + "," + ID + "," + a + "," + Number + "," + Price+ "," + d + "," +
                            Convert.ToDecimal(Price) * Convert.ToInt32(Number) + "|";


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
                //s.Append("if(window.opener != undefined) {window.opener.returnValue='"+s_Return+"';} else{window.returnValue='"+s_Return+"';}" + "\n");
                s.Append("if (window.opener != undefined)\n");
                s.Append("{\n");
                s.Append("    window.opener.returnValue = '" + s_Return + "';\n");
                s.Append("    window.opener.SetReturnValueInOpenner_Products('" + s_Return + "');\n");
                s.Append("}\n");
                s.Append("else\n");
                s.Append("{\n");
                s.Append("    window.returnValue = '" + s_Return + "';\n");
                s.Append("}\n");
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
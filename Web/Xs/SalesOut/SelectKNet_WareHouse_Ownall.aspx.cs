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
/// 选择指定仓库产品
/// </summary>
public partial class Knet_Common_SelectKNet_WareHouse_Ownall : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "仓库产品选择";

        if (!IsPostBack)
        {
            string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
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
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        string s_OutWareNo = Request.QueryString["OutWareNo"] == null ? "" : Request.QueryString["OutWareNo"].ToString();
        string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
        string sID = Request.QueryString["sID"] == null ? "" : Request.QueryString["sID"].ToString();

        string s_Sql = "";
        if (s_OutWareNo != "")
        {
            s_Sql = " Select a.ID,a.ProductsBarCode,a.KSO_Battery,a.KSO_Manual,a.OutWareAmount-Isnull(aa.Number,0) as OutWareAmount,b.HouseNo HouseNo,isNull(b.Number,0) as Number,isNull(b.TotalNet,0) as TotalNet,a.KSD_BNumber,RCOrderNo as OrderNo,RCMNo as MaterNo,MaterOrderNo,MaterMNo,KSO_IsFollow from KNet_Sales_OutWareList_Details a Left join v_ProdutsStore b on a.ProductsBarCode=b.ProductsBarCode and HouseType=0 ";
           
            s_Sql += " join KNet_Sales_OutWareList d on d.OutWareNo=a.OutWareNo ";
            s_Sql += " left join (Select a.ProductsBarCode,b.KWD_ShipNo,Sum(DirectOutAmount) as Number from KNet_WareHouse_DirectOutList_Details a join KNet_WareHouse_DirectOutList b on a.DirectOutNo=b.DirectOutNo group by a.ProductsBarCode,b.KWD_ShipNo) aa on aa.ProductsBarCode=a.ProductsBarCode and aa.KWD_ShipNo=a.OutWareNo ";

            s_Sql += " where 1=1";
            if (s_HouseNo != "")
            {
                s_Sql += " and b.HouseNo='" + s_HouseNo + "'  ";
            }
            else
            {

                s_Sql += " and b.HouseNo is not null ";
            }
            if (s_OutWareNo != "")
            {
                s_Sql += " and a.OutWareNo='" + s_OutWareNo + "' ";
            }
            if (this.SeachKey.Text != "")
            {
                s_Sql += " and d.ProductsEdition like '%" + this.SeachKey.Text + "%'";
            }
            if (sID != "")
            {
                s_Sql += " and a.ProductsBarCode not in ('" + sID.Substring(0, sID.Length - 1).Replace(",", "','") + "') ";
            }
        }
        else
        {
            s_Sql += " Select '0' as ID,b.ProductsBarCode as  ProductsBarCode,'' KSO_Battery,'' KSO_Manual,b.Number OutWareAmount,b.HouseNo,isNull(b.Number,0) as Number,isNull(b.TotalNet,0) as TotalNet,0 KSD_BNumber,'' OrderNo,'' MaterNo,'' MaterOrderNo,'' MaterMNo,'' KSO_IsFollow from v_ProdutsStore b  join KNet_Sys_Products d on d.ProductsBarCode=b.ProductsBarCode  ";
            s_Sql += " where 1=1 ";//全部库存
            if (s_HouseNo != "")
            {
                s_Sql += " and b.HouseNo='" + s_HouseNo + "' ";
            }
            if (this.SeachKey.Text != "")
            {
                s_Sql += " and d.ProductsEdition like '%" + this.SeachKey.Text + "%'";
            }
            if (sID != "")
            {
                s_Sql += " and b.ProductsBarCode not in ('" + sID.Substring(0, sID.Length - 1).Replace(",", "','") + "') ";
            }
        }

        this.BeginQuery(s_Sql);
        this.QueryForDataSet();
        DataSet ds = Dts_Result;

        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();

    }

    /// <summary>
    /// 页内 搜索 （Y）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click1(object sender, EventArgs e)
    {
        this.DataShows();

    }


    /// <summary>
    /// 添加提示
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
            }
            catch { }
            string DirectOutNo = GridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox)e.Row.Cells[1].FindControl("Chbk");
            TextBox Tbx_Number = (TextBox)e.Row.Cells[1].FindControl("Tbx_Number");
            string s_KcNumber = e.Row.Cells[7].Text;
            int i_Number = int.Parse(Tbx_Number.Text);
            if (int.Parse(s_KcNumber) >= i_Number)
            {
                cb.Checked = true;
            }
            else
            {
                cb.Checked = false;
            }
            KNet.BLL.KNet_WareHouse_DirectOutList Bll = new KNet.BLL.KNet_WareHouse_DirectOutList();
            KNet.Model.KNet_WareHouse_DirectOutList Model = Bll.GetModelB(DirectOutNo);

        }
    }
    /// <summary>
    /// 确定选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        string s_Return = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox Chk = (CheckBox)this.GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (Chk.Checked)
            {
                string s_ID = GridView1.DataKeys[i].Value.ToString();

                TextBox Tbx_ProductsBarCode = (TextBox)GridView1.Rows[i].Cells[0].FindControl("ProductsBarCode");
                string s_ProductsBarCode = Tbx_ProductsBarCode.Text;
                string s_ProductsName = base.Base_GetProdutsName(s_ProductsBarCode);
                string s_ProductsPattern = base.Base_GetProductsPattern(s_ProductsBarCode);
                string s_ProductsEdition = base.Base_GetProductsEdition(s_ProductsBarCode);
                string s_Number = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Number")).Text;
                TextBox Tbx_BNumber = (TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_BNumber");
                string s_HouseNo = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("HouseNo")).Text;

                string s_BNumber = Tbx_BNumber.Text;
                string s_OrderNo = GridView1.Rows[i].Cells[9].Text;
                string s_MaterNo = GridView1.Rows[i].Cells[10].Text;
                string s_CustomerProductsName = GridView1.Rows[i].Cells[11].Text;
                string s_PlanNo = GridView1.Rows[i].Cells[8].Text;
                string s_IsFollow = GridView1.Rows[i].Cells[12].Text;
                string s_ProductsCode = base.Base_GetProductsCode(s_ProductsBarCode);
                s_Number = s_Number == "" ? "1" : s_Number;
                string s_Remark = ((TextBox)GridView1.Rows[i].Cells[0].FindControl("Tbx_Remarks")).Text;
                s_Return += s_ProductsName + "," + s_ProductsBarCode + "," + s_ProductsPattern + "," + s_ProductsEdition + "," + s_Number + "," + s_Remark + "," + s_BNumber + "," + s_ID + "," + s_OrderNo.Trim() + "," + s_MaterNo.Trim() + "," + s_CustomerProductsName + "," + s_PlanNo.Trim() + "," + s_IsFollow + "," + s_ProductsCode + "," + s_HouseNo + "|";
            }
        }
        StringBuilder s = new StringBuilder();
        s.Append("<script language=javascript>" + "\n");
        // s.Append("if(window.opener != undefined) {window.opener.returnValue='" + s_Return + "';} else{window.returnValue='" + s_Return + "';}" + "\n");
        s.Append("if (window.opener != undefined)\n");
        s.Append("{\n");
        s.Append("    window.opener.returnValue = '" + s_Return + "';\n");
        s.Append("    window.opener.SetReturnValueInOpenner_WareHouse_Ownall('" + s_Return + "');\n");
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





    /// <summary>
    /// 返回仓库名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetHouseName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,HouseNo,HouseName from KNet_Sys_WareHouse where HouseNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["HouseName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }




}

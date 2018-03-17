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
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
using KNet.Common;


public partial class Web_Procure_ShipCheck_Add : BasePage
{
    private int i_TotalNum = 0, i_TotalNum_Excel = 0;
    private decimal d_TotalNet = 0, d_TotalNet_Excel = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("新增采购对账") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                base.Base_DropWareHouseBind(this.Ddl_HouseNo, " HouseNo in (select Distinct HouseNo from KNet_WareHouse_DirectOutList where KWD_Type='101') ");

                //编号生成  按月
                this.Tbx_CheckCode.Text = base.GetNewID("Cg_Order_Checklist", 0);
                this.Tbx_RkCode.Text = GetIDByMonth();
                this.Tbx_Stime.Text = DateTime.Now.ToShortDateString();
                base.Base_DropBasicCodeBind(this.Ddl_Type, "144");
                this.Ddl_Type.SelectedValue = "0";
                //KNet.BLL.Knet_Procure_Suppliers Bll = new KNet.BLL.Knet_Procure_Suppliers();
                //DataSet Dts_Table = Bll.GetList(" 1=1 order by SuppName ");
                //this.Ddl_SuppNo.DataSource = Dts_Table;
                //this.Ddl_SuppNo.DataValueField = "SuppNo";
                //this.Ddl_SuppNo.DataTextField = "KPS_SName";
                //this.Ddl_SuppNo.DataBind();
                //ListItem item = new ListItem("--请选择--", ""); //默认值
                //this.Ddl_SuppNo.Items.Insert(0, item);
                ShowTr();
                string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                if (s_ID != "")
                {
                    this.Tbx_ID.Text = s_ID;
                    this.Tbx_CheckCode.Text = s_ID;
                    ShowDiog();
                    ShowMessage(s_ID);
                }
                else
                {
                    ShowDiog();
                }

            }
        }

    }

    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string ID = this.MyGridView1.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox)e.Row.Cells[0].FindControl("Chbk1");
            TextBox Tbx_Wuliu = (TextBox)e.Row.Cells[0].FindControl("Tbx_Wuliu");
            TextBox Tbx_Number = (TextBox)e.Row.Cells[0].FindControl("Tbx_Number");
            TextBox Tbx_BNumber = (TextBox)e.Row.Cells[0].FindControl("Tbx_BNumber");

            TextBox Tbx_ProductsEdition = (TextBox)e.Row.Cells[0].FindControl("Tbx_ProductsEdition");
            TextBox Tbx_DirectOutNo = (TextBox)e.Row.Cells[0].FindControl("Tbx_DirectOutNo");
            TextBox Tbx_Price = (TextBox)e.Row.Cells[0].FindControl("Tbx_Price");
            TextBox Tbx_HandPrice = (TextBox)e.Row.Cells[0].FindControl("Tbx_HandPrice");

            string s_DirectOutNo = Tbx_DirectOutNo.Text;
            string s_ProductsEdition = Tbx_ProductsEdition.Text;
            string s_RkNumber = Tbx_Number.Text;
            string s_BNumber = Tbx_BNumber.Text;
            s_RkNumber = Convert.ToString(int.Parse(s_RkNumber) + int.Parse(s_BNumber));
            string s_Price = Tbx_Price.Text;
            string s_HandPrice = Tbx_HandPrice.Text;
            //回签单
            string s_Sql = "Select * from PB_Basic_Attachment where PBA_Type='SalesOut' and PBA_FID='" + Tbx_DirectOutNo.Text + "'";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                cb.Checked = true;
            }
            else
            {
                cb.Checked = false;
            }
            Excel excel = new Excel();
            DataTable myT = excel.ExcelFirestToDataTable(this.Tbx_URL.Text," 1=1 ");
            this.BeginQuery("select * from Excel_In_Details where EID_FID='" + this.Tbx_CheckCode.Text + "' ");
            DataTable Dtb_Excel = this.QueryForDataTable();
            string[] s_FName = new string[7];
            if (Dtb_Excel.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Excel.Rows.Count; i++)
                {
                    int i_Num = int.Parse(Dtb_Excel.Rows[i]["EID_YLine"].ToString()) + 1;
                    if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "OrderNo")
                    {
                        s_FName[0] = "f" + i_Num.ToString();
                    }
                    else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "WareHouseAmount")
                    {
                        s_FName[1] = "f" + i_Num.ToString();
                    }
                    else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "ProductsEdition")
                    {
                        s_FName[2] = "f" + Dtb_Excel.Rows[i]["EID_YLine"].ToString();
                    }
                    else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "wuliu")
                    {
                        s_FName[3] = "f" + i_Num.ToString();
                    }
                    else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "Price")
                    {
                        s_FName[4] = "f" + i_Num.ToString();
                    }
                    else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "HandPrice")
                    {
                        s_FName[5] = "f" + i_Num.ToString();
                    }
                    else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "DirectOutNo")
                    {
                        s_FName[6] = "f" + i_Num.ToString();
                    }
                }
            }
            string s_SqlWhere = " 1=1  ";
            if ((s_FName[6] != "") && (s_DirectOutNo != ""))
            {
                s_SqlWhere += " and " + s_FName[6] + "='" + s_DirectOutNo.Trim() + "' ";
            }
            if (myT != null)
            {
                int i_ExcelNum = 0;
                decimal d_ExcelPrice = 0;
                decimal d_ExcelHandPrice = 0;
                DataRow[] arrayDR = myT.Select(s_SqlWhere);
                foreach (DataRow dr in arrayDR)
                {
                    cb.Checked = true;
                    Tbx_Wuliu.Text = dr["" + s_FName[3] + ""].ToString();
                    if (dr[1].ToString() != "")
                    {
                        string s_ExcelNum = dr["" + s_FName[1] + ""] == null ? "0" : dr["" + s_FName[1] + ""].ToString();
                        string s_ExcelPrice = dr["" + s_FName[4] + ""] == null ? "0" : dr["" + s_FName[4] + ""].ToString();
                        string s_ExcelHandPrice = dr["" + s_FName[5] + ""] == null ? "0" : dr["" + s_FName[5] + ""].ToString();
                        try
                        {
                            i_ExcelNum += int.Parse(s_ExcelNum == "" ? "0" : s_ExcelNum);
                            d_ExcelPrice = decimal.Parse(s_ExcelPrice == "" ? "0" : s_ExcelPrice);
                            d_ExcelHandPrice = decimal.Parse(s_ExcelHandPrice == "" ? "0" : s_ExcelHandPrice);
                        }
                        catch { }
                    }
                }
                if (cb.Checked)
                {
                    i_TotalNum += int.Parse(s_RkNumber);
                    i_TotalNum_Excel += i_ExcelNum;
                    d_TotalNet += int.Parse(s_RkNumber) * (decimal.Parse(s_Price) + decimal.Parse(s_HandPrice));
                    d_TotalNet_Excel += i_ExcelNum * (d_ExcelPrice + d_ExcelHandPrice);

                }
                try
                {

                    if ((i_ExcelNum != int.Parse(s_RkNumber)) && (i_ExcelNum != 0))
                    {
                        e.Row.Cells[7].Text += "<br/><font color=red>" + i_ExcelNum.ToString() + "</font>";
                    }
                }
                catch
                { }
                try
                {
                    if ((d_ExcelPrice != decimal.Parse(s_Price)) && (d_ExcelPrice != 0))
                    {
                        e.Row.Cells[7].Text += "|<font color=red>" + d_ExcelPrice.ToString() + "</font>";
                    }
                    if ((d_ExcelHandPrice != decimal.Parse(s_HandPrice)) && (d_ExcelHandPrice != 0))
                    {
                        e.Row.Cells[7].Text += "|<font color=red>" + d_ExcelHandPrice.ToString() + "</font>";
                    }
                }
                catch
                { }

            }
            this.Tbx_TotalNet.Text = d_TotalNet.ToString();
            this.Tbx_TotalNetExcel.Text = d_TotalNet_Excel.ToString();
            this.Tbx_TotalNum.Text = i_TotalNum.ToString();
            this.Tbx_TotalNumExcel.Text = i_TotalNum_Excel.ToString();
            //查找这个单子是否在系统中如果是就打钩 否就加入到另外一个DataTab里面
        }
    }
    protected void GridView2_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string ID = this.MyGridView2.DataKeys[e.Row.RowIndex].Value.ToString(); //获取ID值
            CheckBox cb = (CheckBox)e.Row.Cells[0].FindControl("Chbk");
            TextBox Tbx_Wuliu = (TextBox)e.Row.Cells[0].FindControl("Tbx_Wuliu");
            TextBox Tbx_Number = (TextBox)e.Row.Cells[0].FindControl("Tbx_Number");
            TextBox Tbx_ProductsEdition = (TextBox)e.Row.Cells[0].FindControl("Tbx_ProductsEdition");
            TextBox Tbx_OrderNo = (TextBox)e.Row.Cells[0].FindControl("Tbx_OrderNo");
            TextBox Tbx_Price = (TextBox)e.Row.Cells[0].FindControl("Tbx_Price");

            string s_OrderNo = Tbx_OrderNo.Text;
            string s_ProductsEdition = Tbx_ProductsEdition.Text;
            string s_RkNumber = Tbx_Number.Text;
            string s_Price = Tbx_Price.Text;
            try
            {
                KNet.BLL.Knet_Procure_WareHouseList_Details Bll_Details = new KNet.BLL.Knet_Procure_WareHouseList_Details();
                KNet.Model.Knet_Procure_WareHouseList_Details model_Details = Bll_Details.GetModel(ID);
                KNet.BLL.Knet_Procure_WareHouseList Bll = new KNet.BLL.Knet_Procure_WareHouseList();
                KNet.Model.Knet_Procure_WareHouseList model = Bll.GetModelB(model_Details.WareHouseNo);
                if (model.KPO_QRState != 1)
                {
                    cb.Enabled = false;
                }
                else
                {
                    cb.Enabled = true;
                    cb.Checked = true;
                }
            }
            catch
            { }
            Excel excel = new Excel();
            DataTable myT = excel.ExcelFirestToDataTable(this.Tbx_URL.Text," 1=1 ");
            this.BeginQuery("select * from Excel_In_Details where EID_FID='" + this.Tbx_CheckCode.Text + "' ");
            DataTable Dtb_Excel = this.QueryForDataTable();
            string[] s_FName = new string[5];
            if (Dtb_Excel.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Excel.Rows.Count; i++)
                {
                    int i_Num = int.Parse(Dtb_Excel.Rows[i]["EID_YLine"].ToString()) + 1;
                    if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "OrderNo")
                    {
                        s_FName[0] = "f" + i_Num.ToString();
                    }
                    else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "WareHouseAmount")
                    {
                        s_FName[1] = "f" + i_Num.ToString();
                    }
                    else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "ProductsEdition")
                    {
                        s_FName[2] = "f" + Dtb_Excel.Rows[i]["EID_YLine"].ToString();
                    }
                    else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "wuliu")
                    {
                        s_FName[3] = "f" + i_Num.ToString();
                    }
                    else if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "Price")
                    {
                        s_FName[4] = "f" + i_Num.ToString();
                    }
                }

            }
            string s_SqlWhere = " 1=1 ";
            if ((s_FName[0] != "") && (s_OrderNo != ""))
            {
                s_SqlWhere += " and " + s_FName[0] + "='" + s_OrderNo.Trim() + "' ";
            }
            //if ((s_FName[1] != "") && (s_RkNumber != ""))
            // {
            //    s_SqlWhere+=" and "+s_FName[1]+"='"+s_RkNumber.Trim()+"' ";
            //}
            //if((s_FName[2]!="")&&(s_ProductsEdition!=""))
            //{
            //    s_SqlWhere+=" and "+s_FName[2]+" like '%"+s_ProductsEdition+"%' ";
            //}
            if (myT != null)
            {
                int i_ExcelNum = 0;
                decimal d_ExcelPrice = 0;
                DataRow[] arrayDR = myT.Select(s_SqlWhere);
                foreach (DataRow dr in arrayDR)
                {
                    cb.Checked = true;
                    Tbx_Wuliu.Text = dr["" + s_FName[3] + ""].ToString();
                    if (dr[1].ToString() != "")
                    {
                        string s_ExcelNum = dr["" + s_FName[1] + ""] == null ? "0" : dr["" + s_FName[1] + ""].ToString();
                        string s_ExcelPrice = dr["" + s_FName[4] + ""] == null ? "0" : dr["" + s_FName[4] + ""].ToString();
                        try
                        {
                            i_ExcelNum += int.Parse(s_ExcelNum == "" ? "0" : s_ExcelNum);
                            d_ExcelPrice = decimal.Parse(s_ExcelPrice == "" ? "0" : s_ExcelPrice);
                        }
                        catch { }
                    }
                }
                if (cb.Checked)
                {
                    i_TotalNum += int.Parse(s_RkNumber);
                    i_TotalNum_Excel += i_ExcelNum;
                    d_TotalNet += int.Parse(s_RkNumber) * decimal.Parse(s_Price);
                    d_TotalNet_Excel += i_ExcelNum * d_ExcelPrice;

                }
                try
                {

                    if ((i_ExcelNum != int.Parse(s_RkNumber)) && (i_ExcelNum != 0))
                    {
                        e.Row.Cells[7].Text += "<br/><font color=red>" + i_ExcelNum.ToString() + "</font>";
                    }
                }
                catch
                { }
                try
                {
                    if ((d_ExcelPrice != decimal.Parse(s_Price)) && (d_ExcelPrice != 0))
                    {
                        e.Row.Cells[7].Text += "|<font color=red>" + d_ExcelPrice.ToString() + "</font>";
                    }
                }
                catch
                { }

            }
            this.Tbx_TotalNet.Text = d_TotalNet.ToString();
            this.Tbx_TotalNetExcel.Text = d_TotalNet_Excel.ToString();
            this.Tbx_TotalNum.Text = i_TotalNum.ToString();
            this.Tbx_TotalNumExcel.Text = i_TotalNum_Excel.ToString();
            //查找这个单子是否在系统中如果是就打钩 否就加入到另外一个DataTab里面
        }
    }
    private void ShowMessage(string s_ID)
    {
        KNet.BLL.Cg_Order_Checklist Bll = new KNet.BLL.Cg_Order_Checklist();
        KNet.Model.Cg_Order_Checklist Model = Bll.GetModel(s_ID);
        if (Model != null)
        {
            this.Ddl_Type.SelectedValue = Model.COC_Type;
            ShowTr();
            try
            {
                this.StartDate.Text = DateTime.Parse(Model.COC_BeginDate.ToString()).ToShortDateString();
            }
            catch
            {
                this.EndDate.Text = "";
            }
            try
            {
                this.EndDate.Text = DateTime.Parse(Model.COC_EndDate.ToString()).ToShortDateString();
            }
            catch
            {
                this.EndDate.Text = "";
            }
            try
            {
                this.Tbx_Stime.Text = DateTime.Parse(Model.COC_Stime.ToString()).ToShortDateString();
            }
            catch
            {
                this.EndDate.Text = "";
            }
            if (Model.COC_Type == "1")
            {
                this.Ddl_SuppNo.Value = Model.COC_SuppNo;
                this.SuppNo.Text = base.Base_GetSupplierName(Model.COC_SuppNo);
                this.DataShows();
            }
            else
            {
                this.Ddl_HouseNo.SelectedValue = Model.COC_HouseNo;
                this.DataShows();
            }
            Tbx_DirectInRemarks.Text = Model.COC_Details;
        }
    }
    private void ShowDiog()
    {
        this.BeginQuery("select * from Excel_In_Manage where EIM_FID='" + this.Tbx_CheckCode.Text + "'");
        DataTable Dtb_Excel = this.QueryForDataTable();
        if (Dtb_Excel.Rows.Count > 0)
        {
            string s_Table = Dtb_Excel.Rows[0]["EIM_Details1"].ToString();
            string s_SuppName1 = Dtb_Excel.Rows[0]["EIM_Name"].ToString();
            this.Tbx_Sheet.Text = s_Table;
            string s_Type = Dtb_Excel.Rows[0]["EIM_Type"].ToString();
            if (s_Type == "原材料")
            {
                this.Ddl_Type.SelectedValue = "1";
                this.BeginQuery("Select SuppNo from Knet_Procure_Suppliers where suppName like '%" + s_SuppName1.Trim() + "%'");
                string s_SuppNo = this.QueryForReturn();
                if (s_SuppNo != "")
                {
                    this.Ddl_SuppNo.Value = s_SuppNo;
                    this.SuppNo.Text = base.Base_GetSupplierName(s_SuppNo);
                }
            }
            else if (s_Type == "成品")
            {
                this.Ddl_Type.SelectedValue = "0";
                string s_Sql1 = "select HouseNo from Knet_Procure_Suppliers a join KNet_Sys_WareHouse b on a.SuppNo=b.SuppNo where KSW_Type='0' and suppName like '%" + s_SuppName1.Trim() + "%' ";
                this.BeginQuery(s_Sql1);//查找HouseNo
                string s_HouseNO = this.QueryForReturn();
                if (s_HouseNO != "")
                {
                    this.Ddl_HouseNo.SelectedValue = s_HouseNO;
                }
            }
            ShowTr();

        }
        //查询
        bool b_IsDetails = false;
        this.BeginQuery("select * from Excel_In_Details where EID_FID='" + this.Tbx_CheckCode.Text + "'");
        DataTable Dtb_TableDetails = this.QueryForDataTable();
        if (Dtb_TableDetails.Rows.Count > 0)//如果有明细
        {
            b_IsDetails = true;
        }
        else
        {
            b_IsDetails = false;
        }

        string s_Sql = "Select * from PB_Basic_Attachment where PBA_Type='CgCheck' and PBA_FID='" + this.Tbx_CheckCode.Text + "' order by PBA_CTime desc";
        this.BeginQuery(s_Sql);
        DataTable Dtb_Table = this.QueryForDataTable();
        if (Dtb_Table.Rows.Count > 0)
        {
            this.Lbl_Upload.Text = "<a href=\"" + Dtb_Table.Rows[0]["PBA_URL"].ToString() + "\">" + Dtb_Table.Rows[0]["PBA_Name"].ToString() + "</a><br/>";
            this.Tbx_URL.Text = Dtb_Table.Rows[0]["PBA_URL"].ToString();
            string s_Name = this.Tbx_Sheet.Text;
            if (b_IsDetails == false)
            {
                string s_Str = " var temp = window.showModalDialog(\"Procure_ShipCheck_Excel.aspx?ID=" + this.Tbx_CheckCode.Text + "&Table=" + Server.UrlEncode(s_Name) + "\", \"\", \"dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=700px\");";
                StringBuilder s = new StringBuilder();
                s.Append("<script language=javascript>" + "\n");
                s.Append(s_Str + "\n");
                s.Append(" if (temp == \"true\")\n");
                s.Append("{\n");
                s.Append(" window.location.reload();\n");
                s.Append("} \n");
                s.Append("</script>");
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                string csname = "ltype";
                if (!cs.IsStartupScriptRegistered(cstype, csname))
                    cs.RegisterStartupScript(cstype, csname, s.ToString());
            }
        }
    }

    protected string GetPrint(string i_IsSend)
    {
        string s_Return = "";
        if (i_IsSend == "0")
        {
            s_Return = "<font color=red>未确认</font>";
        }
        else
        {
            s_Return = "已确认";
        }
        return s_Return;
    }
    private void ShowDiog(bool b_True)
    {
        string s_Sql = "Select * from PB_Basic_Attachment where PBA_Type='CgCheck' and PBA_FID='" + this.Tbx_CheckCode.Text + "' order by PBA_CTime desc";
        this.BeginQuery(s_Sql);
        DataTable Dtb_Table = this.QueryForDataTable();
        if (Dtb_Table.Rows.Count > 0)
        {
            this.Lbl_Upload.Text = "<a href=\"" + Dtb_Table.Rows[0]["PBA_URL"].ToString() + "\">" + Dtb_Table.Rows[0]["PBA_Name"].ToString() + "</a><br/>";
            string s_Name = this.Tbx_Sheet.Text;
            string s_Str = " var temp = window.showModalDialog(\"Procure_ShipCheck_Excel.aspx?ID=" + this.Tbx_CheckCode.Text + "&Table=" + Server.UrlEncode(s_Name) + "\", \"\", \"dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=700px\");";
            StringBuilder s = new StringBuilder();
            s.Append("<script language=javascript>" + "\n");
            s.Append(s_Str + "\n");
            s.Append(" if (temp == \"true\")\n");
            s.Append("{\n");
            s.Append(" window.location.reload();\n");
            s.Append("} \n");
            s.Append("</script>");
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            string csname = "ltype";
            if (!cs.IsStartupScriptRegistered(cstype, csname))
                cs.RegisterStartupScript(cstype, csname, s.ToString());
        }
    }
    private string GetIDByMonth()
    {
        string s_Return = "";
        try
        {
            string s_Sql = "Select isnull(Max(COC_RKCode),'') from Cg_Order_Checklist Where Isnull(COC_Type,'0')='" + this.Ddl_Type.SelectedValue + "' and Year(COC_Stime)='" + DateTime.Now.Year.ToString() + "' and Month(COC_Stime)='" + DateTime.Now.Month.ToString() + "' ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            if (Dtb_Result.Rows.Count > 0)
            {
                if (Dtb_Result.Rows[0][0].ToString() == "")
                {
                    s_Return = DateTime.Today.ToString("yyyyMM") + "001";
                }
                s_Return = Convert.ToString(int.Parse(Dtb_Result.Rows[0][0].ToString()) + 1);
            }
            else
            {
                s_Return = DateTime.Today.ToString("yyyyMM") + "001";
            }
        }
        catch { }
        return s_Return;
    }
    public void DataShows()
    {
        //成品对账
        if (this.Tr_HouseNo.Visible == true)
        {
            string s_Sql = "select b.DirectOutNo,b.KWD_Custmoer,b.KWD_CwOutTime DirectOutDateTime,b.KWD_ContentPerson,b.HouseNo,a.DirectOutAmount+Isnull(a.KWD_BNumber,0) as DirectOutAmount,a.ProductsBarCode,";
            if (this.Tbx_ID.Text == "")
            {
                s_Sql += "isnull(c.ProcureunitPrice,0) ProcureunitPrice,isnull(c.HandPrice,0) HandPrice,a.DirectOutAmount-isnull(e.COD_Number,0) as yDirectOutAmount,isnull(e.COD_Number+e.COD_BNumber,0) dznumber,a.DirectOutAmount-isnull(e.COD_Number,0)+Isnull(a.KWD_BNumber,0)-e.COD_BNumber as LeftNumber,(isnull(c.ProcureunitPrice,0)+isnull(c.HandPrice,0))*(a.DirectOutAmount+Isnull(a.KWD_BNumber,0)-isnull(e.COD_Number,0)) as Money,Isnull(a.KWD_BNumber,0)-isnull(e.COD_BNumber,0) KWD_BNumber,";
            }
            else
            {
                s_Sql += "isnull(f.COD_Price,0) ProcureunitPrice,isnull(f.COD_HandPrice,0) HandPrice,isnull(f.COD_DZNumber,0) as yDirectOutAmount,isnull(e.COD_Number,0)-isnull(f.COD_DZNumber,0) dznumber,a.DirectOutAmount-isnull(e.COD_Number,0)+Isnull(a.KWD_BNumber,0)-e.COD_BNumber+isnull(f.COD_DZNumber,0)+isnull(f.COD_BNumber,0) LeftNumber,(a.DirectOutAmount+Isnull(a.KWD_BNumber,0)-isnull(e.COD_Number,0)+isnull(f.COD_DZNumber,0))*(isnull(f.COD_Price,0)+isnull(f.COD_HandPrice,0)) as Money,isnull(f.COD_BNumber,0) KWD_BNumber,";
            }
            s_Sql += "a.ID ";
            s_Sql += "from KNet_WareHouse_DirectOutList_Details a join KNet_WareHouse_DirectOutList b on a.DirectOutNo=b.DirectOutNo left join (select e.HouseNo,d.ProductsBarCode,d.ProcureunitPrice,d.HandPrice from Knet_Procure_SuppliersPrice d left join KNet_Sys_WareHouse e on d.SuppNo=e.SuppNo where KPP_Del='0' ) c  ";
            s_Sql += "on c.HouseNo=b.HouseNo and c.ProductsBarCode=a.ProductsbarCode join KNet_Sys_Products g on g.ProductsBarCode=a.ProductsBarCode  left join Check_WareHouseDetails e on e.COD_DirectOutID=a.ID ";
            if (this.Tbx_ID.Text != "")
            {
                s_Sql += " left join Cg_Order_Checklist_Details f on f.COD_DirectOutID=a.ID and f.COD_CheckNO='" + this.Tbx_ID.Text + "' ";
                s_Sql += " where 1=1 and a.DirectOutAmount-isnull(e.COD_Number,0)+isnull(f.COD_DZNumber,0)+Isnull(a.KWD_BNumber,0)-e.COD_BNumber+isnull(f.COD_BNumber,0)>0  ";
            }
            else
            {
                s_Sql += " where 1=1  ";
                s_Sql += " and (isnull(e.COD_Number,0)+isnull(e.COD_BNumber,0))<>(a.DirectOutAmount+Isnull(a.KWD_BNumber,0))  ";
            }
            if (this.Ddl_HouseNo.SelectedValue != "")
            {
                s_Sql += " and b.HouseNo='" + this.Ddl_HouseNo.SelectedValue + "' ";
            }
            if (this.StartDate.Text != "")
            {
                s_Sql += " and b.KWD_CwOutTime>='" + this.StartDate.Text + "' ";
            }
            if (this.EndDate.Text != "")
            {
                s_Sql += " and b.KWD_CwOutTime<='" + this.EndDate.Text + "' ";
            }
            s_Sql += " and g.ProductsType<>'M130704050932527' and KWD_SystemChange<>'1' and KWD_Type in ('101','DB') and isnull(DirectOutTopic,'')=''   Order by b.KWD_CwOutTime ";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table2 = (DataTable)this.QueryForDataTable();
            MyGridView1.DataSource = Dtb_Table2;
            MyGridView1.DataKeyNames = new string[] { "ID" };
            MyGridView1.DataBind();
            //不在明细的成品对账单

            //查未找到的采购单号和入库明细
            string s_Sql2 = "";
            for (int i = 0; i < Dtb_Table2.Rows.Count; i++)
            {
                s_Sql2 += Dtb_Table2.Rows[i]["DirectOutNo"].ToString() + ",";
            }
            this.BeginQuery("select * from Excel_In_Details where EID_FID='" + this.Tbx_CheckCode.Text + "' ");
            DataTable Dtb_Excel = this.QueryForDataTable();
            string[] s_FName = new string[4];
            if (Dtb_Excel.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Excel.Rows.Count; i++)
                {
                    int i_Num = int.Parse(Dtb_Excel.Rows[i]["EID_YLine"].ToString()) + 1;
                    if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "DirectOutNo")
                    {
                        s_FName[0] = "f" + i_Num.ToString();
                    }
                }

            }
            Excel excel = new Excel();
            DataTable myT = excel.ExcelFirestToDataTable(this.Tbx_URL.Text," 1=1 ");

            string s_Where = " 1=1 and f2<>'' and f11<>'' and " + s_FName[0] + " like '%20%'  ";
            if (s_Sql2 != "")
            {
                s_Sql2 = s_Sql2.Substring(0, s_Sql2.Length - 1).Replace(",", "','");
                s_Where += "and " + s_FName[0] + " not in ('" + s_Sql2 + "') ";
            }
            if (myT != null)
            {

                DataRow[] arrayDR = myT.Select(s_Where);

                this.Lbl_Details.Text = "未找到的出库：<br/>";
                this.Lbl_Details.Text += "<table id=\"myTable\" width=\"98%\" border=\"0\" align=\"center\" cellpadding=\"2\" cellspacing=\"0\" class=\"ListDetails\" style=\"height: 28px\">";

                this.Lbl_Details.Text += "<tr valign=\"top\">";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F1</b></td>";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F2</b></td>";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F3</b></td>";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F4</b></td>";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F5</b></td>";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F6</b></td>";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F7</b></td>";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F8</b></td>";
                this.Lbl_Details.Text += "</tr >";
                foreach (DataRow dr in arrayDR)
                {
                    if (dr[1].ToString() != "")
                    {
                        this.Lbl_Details.Text += "<tr>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[0].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[1].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[2].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[3].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[4].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[5].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[6].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[7].ToString() + "</td>";
                        this.Lbl_Details.Text += "</tr>";
                    }
                }
                this.Lbl_Details.Text += "</table >";
            }

        }
        else if (this.Tr_SuppNo.Visible == true)
        {
            string s_Sql1 = "select b.WareHouseNo,a.OrderNo,a.SuppNo,a.HouseNo,a.WareHouseDateTime,a.WareHouseNo,b.WareHouseAmount,";
            if (this.Tbx_ID.Text == "")
            {
                s_Sql1 += "b.WareHouseAmount-isnull(c.COD_Number,0) as yWareHouseAmount,isnull(c.COD_Number,0) COD_Number,(b.WareHouseAmount-isnull(c.COD_Number,0))*b.WareHouseUnitPrice as Money";
            }
            else
            {
                s_Sql1 += "b.WareHouseAmount-isnull(c.COD_Number,0)+isnull(e.COD_DZNumber,0) as yWareHouseAmount,isnull(c.COD_Number,0)-isnull(e.COD_DZNumber,0) COD_Number,(b.WareHouseAmount-isnull(c.COD_Number,0)+isnull(e.COD_DZNumber,0))*b.WareHouseUnitPrice as Money";
            }
            s_Sql1 += ",b.ProductsBarCode,b.WareHouseUnitPrice,b.ID,b.WareHouseBAmount,KPO_QRState ";
            s_Sql1 += "from Knet_Procure_WareHouseList a join Knet_Procure_WareHouseList_Details b on a.WareHouseNo=b.WareHouseNo left join Check_WareHouseDetails c on c.COD_DirectOutID=b.ID";

            if (this.Tbx_ID.Text != "")
            {
                s_Sql1 += " left join Cg_Order_Checklist_Details e on e.COD_DirectOutID=b.ID and e.COD_CheckNO='" + this.Tbx_ID.Text + "' ";
                s_Sql1 += " where a.KPW_Del='0'  and a.WareHouseCheckYN<>'0' and (b.WareHouseAmount-isnull(c.COD_Number,0)+isnull(e.COD_DZNumber,0)>0  or b.WareHouseAmount<0) ";
            }
            else
            {
                s_Sql1 += " where a.KPW_Del='0' and a.WareHouseCheckYN<>'0' ";
                //s_Sql1 += " and a.KPO_QrState='1' ";
                s_Sql1 += " and (ABS(isnull(c.COD_Number,0))<ABS(b.WareHouseAmount))";
            }
            if (this.Ddl_SuppNo.Value != "")
            {
                s_Sql1 += " and a.SuppNo='" + this.Ddl_SuppNo.Value + "' ";
            }
            if (this.StartDate.Text != "")
            {
                s_Sql1 += " and a.WareHouseDateTime>='" + this.StartDate.Text + "' ";
            }
            if (this.EndDate.Text != "")
            {
                s_Sql1 += " and a.WareHouseDateTime<='" + this.EndDate.Text + "' ";
            }
            s_Sql1 += " Order by a.WareHouseDateTime ";
            this.BeginQuery(s_Sql1);
            DataTable Dtb_Table1 = this.QueryForDataTable();
            MyGridView2.DataSource = Dtb_Table1;
            MyGridView2.DataKeyNames = new string[] { "ID" };
            MyGridView2.DataBind();

            //查未找到的采购单号和入库明细
            string s_Sql = "";
            for (int i = 0; i < Dtb_Table1.Rows.Count; i++)
            {
                s_Sql += Dtb_Table1.Rows[i]["OrderNo"].ToString() + ",";
            }
            this.BeginQuery("select * from Excel_In_Details where EID_FID='" + this.Tbx_CheckCode.Text + "' ");
            DataTable Dtb_Excel = this.QueryForDataTable();
            string[] s_FName = new string[4];
            if (Dtb_Excel.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Excel.Rows.Count; i++)
                {
                    int i_Num = int.Parse(Dtb_Excel.Rows[i]["EID_YLine"].ToString()) + 1;
                    if (Dtb_Excel.Rows[i]["EID_ColName"].ToString() == "OrderNo")
                    {
                        s_FName[0] = "f" + i_Num.ToString();
                    }
                }

            }
            Excel excel = new Excel();
            DataTable myT = excel.ExcelFirestToDataTable(this.Tbx_URL.Text," 1=1 ");

            string s_Where = " 1=1 and f2<>'' and " + s_FName[0] + " like '%PO%'  ";
            if (s_Sql != "")
            {
                s_Sql = s_Sql.Substring(0, s_Sql.Length - 1).Replace(",", "','");
                s_Where += "and " + s_FName[0] + " not in ('" + s_Sql + "') ";
            }
            if (myT != null)
            {

                DataRow[] arrayDR = myT.Select(s_Where);

                this.Lbl_Details.Text = "未找到的采购单：<br/>";
                this.Lbl_Details.Text += "<table id=\"myTable\" width=\"98%\" border=\"0\" align=\"center\" cellpadding=\"2\" cellspacing=\"0\" class=\"ListDetails\" style=\"height: 28px\">";

                this.Lbl_Details.Text += "<tr valign=\"top\">";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F1</b></td>";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F2</b></td>";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F3</b></td>";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F4</b></td>";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F5</b></td>";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F6</b></td>";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F7</b></td>";
                this.Lbl_Details.Text += "<td class=\"ListHead\" nowrap>";
                this.Lbl_Details.Text += "<b>F8</b></td>";
                this.Lbl_Details.Text += "</tr >";
                foreach (DataRow dr in arrayDR)
                {
                    if (dr[1].ToString() != "")
                    {
                        this.Lbl_Details.Text += "<tr>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[0].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[1].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[2].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[3].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[4].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[5].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[6].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\" >" + dr[7].ToString() + "</td>";
                        this.Lbl_Details.Text += "</tr>";
                    }
                }
                this.Lbl_Details.Text += "</table >";
            }
        }
    }

    protected void Ddl_HouseNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Ddl_HouseNo.SelectedValue != "")
        {
            this.DataShows();
        }
    }
    public string GetWuliu(string s_DirectOutNo)
    {
        string s_Return = "";
        this.BeginQuery("Select top 1 * from KNet_Sales_OutWareList_FlowList  where KDCode<>'' and OutWareNo in ('" + s_DirectOutNo + "') ");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            s_Return = Dtb_Result.Rows[0]["KDCodeName"].ToString() + "(" + Dtb_Result.Rows[0]["KDCode"].ToString() + "/" + Dtb_Result.Rows[0]["KSO_Phone"].ToString() + ")";
        }
        return s_Return;
    }

    public string GetIC(string s_ProductsBarCode)
    {
        string s_Return = "";
        this.BeginQuery("select * from Xs_Products_Prodocts a  join KNet_Sys_Products b on a.XPP_ProductsBarCode=b.ProductsBarCode  where XPP_FaterBarCode='" + s_ProductsBarCode + "' and b.ProductsType='M130703044953260'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            s_Return = Dtb_Result.Rows[0]["ProductsPattern"].ToString();
            s_Return = s_Return.Substring(s_Return.IndexOf("-") + 1, s_Return.Length - s_Return.IndexOf("-") - 1);
        }
        return s_Return;
    }

    protected void Btn_Serch_Click(object sender, EventArgs e)
    {
        ShowDiog();
        this.DataShows();
    }
    protected void Btn_Serch_Click1(object sender, EventArgs e)
    {
        ShowDiog(true);
    }
    protected void Btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess AM = new AdminloginMess();
            KNet.BLL.Cg_Order_Checklist Bll_Order_Checklist = new KNet.BLL.Cg_Order_Checklist();
            KNet.BLL.Cg_Order_Checklist_Details Bll_Order_ChecklistDetails = new KNet.BLL.Cg_Order_Checklist_Details();
            KNet.Model.Cg_Order_Checklist Model_Order_Checklist = new KNet.Model.Cg_Order_Checklist();
            if (this.Tbx_ID.Text != "")
            {
                Model_Order_Checklist.COC_Code = this.Tbx_ID.Text;
            }
            else
            {
                Model_Order_Checklist.COC_Code = base.GetNewID("Cg_Order_Checklist", 1);
            }
            Model_Order_Checklist.COC_Stime = DateTime.Parse(this.Tbx_Stime.Text);
            Model_Order_Checklist.COC_HouseNo = Ddl_HouseNo.SelectedValue;
            if (this.StartDate.Text != "")
            {
                Model_Order_Checklist.COC_BeginDate = DateTime.Parse(this.StartDate.Text);
            }
            if (this.EndDate.Text != "")
            {
                Model_Order_Checklist.COC_EndDate = DateTime.Parse(this.EndDate.Text);
            }
            Model_Order_Checklist.COC_Creator = AM.KNet_StaffNo;
            Model_Order_Checklist.COC_CTime = DateTime.Now;
            Model_Order_Checklist.COC_Mender = AM.KNet_StaffNo;
            Model_Order_Checklist.COC_MTime = DateTime.Now;
            Model_Order_Checklist.COC_Type = this.Ddl_Type.SelectedValue;
            Model_Order_Checklist.COC_SuppNo = this.Ddl_SuppNo.Value;
            Model_Order_Checklist.COC_RKCode = this.Tbx_RkCode.Text;
            Model_Order_Checklist.COC_Details = this.Tbx_DirectInRemarks.Text;
            ArrayList arr_Details = new ArrayList();
            if (this.Tr_SuppNo.Visible == true)
            {
                for (int i = 0; i < MyGridView2.Rows.Count; i++)
                {

                    KNet.Model.Cg_Order_Checklist_Details Model_Order_ChecklistDetails = new KNet.Model.Cg_Order_Checklist_Details();
                    CheckBox chk = (CheckBox)MyGridView2.Rows[i].Cells[0].FindControl("Chbk");
                    if (chk.Checked)
                    {
                        string s_DirectOutID = ((TextBox)MyGridView2.Rows[i].Cells[0].FindControl("Tbx_DirectOutID")).Text;
                        string s_CustomerValue = ((TextBox)MyGridView2.Rows[i].Cells[0].FindControl("Tbx_HouseNo")).Text;
                        string s_Wuliu = ((TextBox)MyGridView2.Rows[i].Cells[0].FindControl("Tbx_Wuliu")).Text;
                        string s_ProductsBarCode = ((TextBox)MyGridView2.Rows[i].Cells[0].FindControl("Tbx_ProductsBarCode")).Text;
                        Decimal d_CkNumber = Decimal.Parse(MyGridView2.Rows[i].Cells[8].Text);
                        Decimal d_Number = decimal.Parse(((TextBox)MyGridView2.Rows[i].Cells[0].FindControl("Tbx_Number")).Text);
                        Decimal d_Price = decimal.Parse(((TextBox)MyGridView2.Rows[i].Cells[0].FindControl("Tbx_Price")).Text);
                        Decimal d_Money = decimal.Parse(((TextBox)MyGridView2.Rows[i].Cells[0].FindControl("Tbx_Money")).Text);
                        Decimal d_BNumber = decimal.Parse(((TextBox)MyGridView2.Rows[i].Cells[0].FindControl("Tbx_BNumber")).Text);
                        string s_Details = ((TextBox)MyGridView2.Rows[i].Cells[0].FindControl("Tbx_Details")).Text;
                        Model_Order_ChecklistDetails.COD_Code = base.GetNewID("Cg_Order_Checklist_Details", 1);
                        Model_Order_ChecklistDetails.COD_CheckNo = Model_Order_Checklist.COC_Code;
                        Model_Order_ChecklistDetails.COD_DirectOutID = s_DirectOutID;
                        Model_Order_ChecklistDetails.COD_CustomerValue = s_CustomerValue;
                        Model_Order_ChecklistDetails.COD_Wuliu = s_Wuliu;
                        Model_Order_ChecklistDetails.COD_ProductsBarCode = s_ProductsBarCode;
                        Model_Order_ChecklistDetails.COD_ProductsEdition = base.Base_GetProductsEdition(s_ProductsBarCode);
                        Model_Order_ChecklistDetails.COD_CkNumber = d_CkNumber;
                        Model_Order_ChecklistDetails.COD_DZNumber = d_Number;
                        Model_Order_ChecklistDetails.COD_Price = d_Price;
                        Model_Order_ChecklistDetails.COD_Details = s_Details;
                        Model_Order_ChecklistDetails.COD_Money = d_Money;
                        Model_Order_ChecklistDetails.COD_NoTaxLag = 0;
                        Model_Order_ChecklistDetails.COD_NoTaxMoney = decimal.Parse(base.FormatNumber1(Convert.ToString(d_Money / Decimal.Parse("1.17")), 2));
                        Model_Order_ChecklistDetails.COD_BNumber = d_BNumber;
                        arr_Details.Add(Model_Order_ChecklistDetails);
                    }
                }
            }
            else if (this.Tr_HouseNo.Visible == true)
            {
                for (int i = 0; i < MyGridView1.Rows.Count; i++)
                {

                    KNet.Model.Cg_Order_Checklist_Details Model_Order_ChecklistDetails = new KNet.Model.Cg_Order_Checklist_Details();
                    CheckBox chk = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk1");
                    if (chk.Checked)
                    {
                        string s_DirectOutID = ((TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_DirectOutID")).Text;
                        string s_CustomerValue = ((TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_CustomerValue")).Text;
                        string s_GetPerson = MyGridView1.Rows[i].Cells[4].Text;
                        string s_Wuliu = ((TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_Wuliu")).Text;
                        string s_ProductsBarCode = ((TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_ProductsBarCode")).Text;
                        Decimal d_CkNumber = Decimal.Parse(((TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_CkNumber")).Text);
                        Decimal d_Number = decimal.Parse(((TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_Number")).Text);
                        Decimal d_Price = decimal.Parse(((TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_Price")).Text);
                        Decimal d_HandPrice = decimal.Parse(((TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_HandPrice")).Text);
                        Decimal d_Money = decimal.Parse(((TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_Money")).Text);

                        Decimal d_BNumber = decimal.Parse(((TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_BNumber")).Text);
                        string s_IC = ((TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_IC")).Text;
                        Decimal d_ICNumber = decimal.Parse(((TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_ICNumber")).Text);
                        string s_Details = ((TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_Details")).Text;


                        Model_Order_ChecklistDetails.COD_Code = base.GetNewID("Cg_Order_Checklist_Details", 1);
                        Model_Order_ChecklistDetails.COD_CheckNo = Model_Order_Checklist.COC_Code;
                        Model_Order_ChecklistDetails.COD_DirectOutID = s_DirectOutID;
                        Model_Order_ChecklistDetails.COD_CustomerValue = s_CustomerValue;
                        Model_Order_ChecklistDetails.COD_GetPerson = s_GetPerson;
                        Model_Order_ChecklistDetails.COD_Wuliu = s_Wuliu;
                        Model_Order_ChecklistDetails.COD_ProductsBarCode = s_ProductsBarCode;
                        Model_Order_ChecklistDetails.COD_ProductsEdition = base.Base_GetProductsEdition(s_ProductsBarCode);
                        Model_Order_ChecklistDetails.COD_CkNumber = d_CkNumber;
                        Model_Order_ChecklistDetails.COD_DZNumber = d_Number;
                        Model_Order_ChecklistDetails.COD_Price = d_Price;
                        Model_Order_ChecklistDetails.COD_HandPrice = d_HandPrice;
                        Model_Order_ChecklistDetails.Cod_IC = s_IC;
                        Model_Order_ChecklistDetails.COD_ICNumber = d_ICNumber;
                        Model_Order_ChecklistDetails.COD_Details = s_Details;
                        Model_Order_ChecklistDetails.COD_Money = d_Money;
                        Model_Order_ChecklistDetails.COD_BNumber = d_BNumber;
                        arr_Details.Add(Model_Order_ChecklistDetails);
                    }
                }
            }
            Model_Order_Checklist.arr_Details = arr_Details;
            if (this.Tbx_ID.Text == "")
            {
                Bll_Order_Checklist.Add(Model_Order_Checklist);
                AM.Add_Logs("采购对账增加！" + Model_Order_Checklist.COC_Code);
                //生成pdf

                string JSD = "CG/Procure_Check/Procure_ShipCheck_View.aspx?ID=" + Model_Order_Checklist.COC_Code + "";
                try
                {
                    base.HtmlToPdf1(JSD, Server.MapPath("PDF"), Model_Order_Checklist.COC_Code);
                }
                catch
                { }
                AlertAndRedirect("采购对账成功！", "Procure_ShipCheck_List.aspx");
            }
            else
            {
                Bll_Order_Checklist.Update(Model_Order_Checklist);
                AM.Add_Logs("采购对账修改！" + Model_Order_Checklist.COC_Code);
                
                string JSD = "CG/Procure_Check/Procure_ShipCheck_View.aspx?ID=" + Model_Order_Checklist.COC_Code + "";

                try
                {
                    base.HtmlToPdf1(JSD, Server.MapPath("PDF"), this.Tbx_ID.Text);
                }
                catch
                { }
                AlertAndRedirect("采购对账修改成功！", "Procure_ShipCheck_List.aspx");
            }
        }
        catch (Exception ex)
        {
            Alert(ex.Message);
        }
    }
    private void ShowTr()
    {

        if (this.Ddl_Type.SelectedValue == "0")//成品采购
        {
            Tr_HouseNo.Visible = true;
            Tr_SuppNo.Visible = false;
            MyGridView1.Visible = true;
            MyGridView2.Visible = false;
        }
        else if (this.Ddl_Type.SelectedValue == "1")
        {
            Tr_HouseNo.Visible = false;
            Tr_SuppNo.Visible = true;
            MyGridView1.Visible = false;
            MyGridView2.Visible = true;
        }
        else
        {
            Tr_HouseNo.Visible = false;
            Tr_SuppNo.Visible = false;
            MyGridView1.Visible = false;
            MyGridView2.Visible = false;

        }
    }

    protected void Ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowTr();
    }

    protected void save_Click(object sender, EventArgs e)
    {

        if (!(uploadFile.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            AdminloginMess AM = new AdminloginMess();
            KNet.Model.PB_Basic_Attachment model = new KNet.Model.PB_Basic_Attachment();
            string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
            GetThumbnailImage1(model);
            try
            {
                KNet.BLL.PB_Basic_Attachment BLL = new KNet.BLL.PB_Basic_Attachment();
                BLL.DeleteByFID(this.Tbx_CheckCode.Text);
                BLL.Add(model);
                AM.Add_Logs("附件上传成功：编号：" + model.PBA_ID);
                this.Lbl_Upload.Text = "<a href=\"" + model.PBA_URL + "\">" + model.PBA_Name + "</a><br/>";
                ShowDiog();
            }
            catch (Exception ex) { }
        }
    }

    public string GetHQCode(string s_OutID)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "Select * from PB_Basic_Attachment where PBA_Type='SalesOut' and PBA_FID='" + s_OutID + "'";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                s_Return = "<a href=\"../" + Dtb_Table.Rows[0]["PBA_Url"] + "\" target=\"_blank\">是</a>";
            }
            else
            {
                s_Return = "<font color=red>否</font>";
            }

        }
        catch
        { }
        return s_Return;
    }

    #region 资料上传操作
    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage1(KNet.Model.PB_Basic_Attachment model)
    {
        AdminloginMess AM = new AdminloginMess();
        //类别下面的
        string UploadPath = "../../../UpFile/CGCheck/";  //上传路径
        string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
        //string fileExt = Path.GetExtension(uploadFile1.PostedFile.FileName); //获扩展名
        string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
        string FileName = Path.GetFileName(uploadFile.PostedFile.FileName);
        string filePath = UploadPath + AutoPath + "_" + FileName; //大文件名
        if (!Directory.Exists(Server.MapPath(UploadPath)))
        {
            Directory.CreateDirectory(Server.MapPath(UploadPath));
        }
        uploadFile.PostedFile.SaveAs(Server.MapPath(filePath)); //上传

        model.PBA_FID = this.Tbx_CheckCode.Text;
        model.PBA_Type = "CgCheck";
        model.PBA_ID = GetMainID();
        model.PBA_Name = FileName;
        model.PBA_URL = filePath;
        model.PBA_CTime = DateTime.Now;
        model.PBA_Creator = AM.KNet_StaffNo;
        model.PBA_Remarks = "";
    }
    #endregion

}

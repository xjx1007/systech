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

public partial class Procure_ShipCheck_Excel : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ID = Request["ID"] == null ? "" : Request["ID"].ToString();
            this.Tbx_ID.Text = s_ID;
            base.Base_DropBasicCodeBind(this.Ddl_Model, "763");
            string s_Table = Request.QueryString["Table"] == null ? "" : Server.UrlDecode(Request.QueryString["Table"].ToString());
            this.Tbx_Table.Text = s_Table;
            string s_Sql = "Select * from PB_Basic_Attachment where PBA_Type='CgFp' and PBA_Creator='"+AM.KNet_StaffNo+"' and PBA_FID='" + s_ID + "' order by PBA_CTime desc";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Att = this.QueryForDataTable();
            if (Dtb_Att.Rows.Count > 0)
            {
                this.Lbl_Details.Text = "";
                Excel excel = new Excel();
                DataTable myT = excel.ExcelToDataTable(Dtb_Att.Rows[0]["PBA_URL"].ToString(), s_Table);
                if (myT == null)
                {
                    AlertAndClose("未找到该Sheet表");
                }
                else
                {
                    for (int j = 0; j < myT.Columns.Count; j++)
                    {
                        if (myT.Rows[0][j] != null)
                        {
                            this.Lbl_Details.Text += "<tr>";
                            this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\"><select name=\"Ddl_Select_" + j + "\">";
                            this.BeginQuery("select * from PB_Basic_Code where PBC_ID='762'");
                            DataTable Dtb_Table = this.QueryForDataTable();
                            this.Lbl_Details.Text += "<option value=></option>";

                            string s_Select = "", s_Name = "";
                            KNet.BLL.Excel_In_Details BLL_Details = new KNet.BLL.Excel_In_Details();
                            DataSet Dtbs_Excel = BLL_Details.GetList("EID_FID='" + this.Tbx_ID.Text + "' and EID_Yline='" + j.ToString() + "'");
                            if (Dtbs_Excel.Tables[0].Rows.Count > 0)
                            {
                                s_Select = "selected";
                                s_Name = Dtbs_Excel.Tables[0].Rows[0]["EID_Name"].ToString();
                            }
                            else
                            {
                                s_Select = "";
                                s_Name = "";
                            }
                            for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                            {
                                if (Dtb_Table.Rows[i]["PBC_Name"].ToString() == s_Name)
                                {
                                    s_Select = "selected";
                                }
                                else
                                {
                                    s_Select = "";
                                }
                                this.Lbl_Details.Text += "<option value='" + Dtb_Table.Rows[i]["PBC_Code"].ToString() + "' " + s_Select + ">" + Dtb_Table.Rows[i]["PBC_Name"].ToString() + "</option>";
                            }
                            this.Lbl_Details.Text += "</select></td>";
                            this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + myT.Rows[0][j].ToString() + "</td>";
                            this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + myT.Rows[1][j].ToString() + "</td>";
                            this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + myT.Rows[2][j].ToString() + "</td>";
                            this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + myT.Rows[3][j].ToString() + "</td>";
                            this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + myT.Rows[4][j].ToString() + "</td>";
                            this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + myT.Rows[5][j].ToString() + "</td>";
                            this.Lbl_Details.Text += "</tr>";
                        }
                      
                        
                    }
                    if (myT.Rows[1][0].ToString().Trim() == "1.发货对账单")
                    {
                        this.Tbx_CheckType.Text = "遥控器对账";
                    }
                    else
                    {
                        this.Tbx_CheckType.Text = myT.Rows[1][10].ToString().Replace("对账类型：", "");
                    }

                    this.Tbx_SuppName.Text = myT.Rows[2][0].ToString().Replace("供应商名称：", "").Replace("供应商名称:", "");
                    if (this.Tbx_SuppName.Text == "序号")
                    {
                        this.Tbx_SuppName.Text = myT.Rows[1][0].ToString().Replace("供应商名称：", "").Replace("供应商名称:", "");
                    }
                    this.Tbx_Num.Text = myT.Columns.Count.ToString();
                }

                KNet.BLL.Excel_In_Manage Bll_Manage = new KNet.BLL.Excel_In_Manage();
                DataSet Dts_Table = Bll_Manage.GetList("EIM_FID='" + this.Tbx_ID.Text + "'");
                if (Dts_Table.Tables[0].Rows.Count > 0)
                {
                    this.Tbx_CheckType.Text = Dts_Table.Tables[0].Rows[0]["EIM_Type"].ToString();
                    this.Tbx_SuppName.Text = Dts_Table.Tables[0].Rows[0]["EIM_Name"].ToString();
                }
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            KNet.BLL.PB_Basic_Code Bll = new KNet.BLL.PB_Basic_Code();
            KNet.BLL.Excel_In_Details Bll_Details = new KNet.BLL.Excel_In_Details();
            int i_num = int.Parse(this.Tbx_Num.Text);
            Bll_Details.DeleteByFID(this.Tbx_ID.Text);
            for (int i = 0; i < i_num; i++)
            {
                string s_Ddl_Select = Request["Ddl_Select_" + i.ToString() + ""] == null ? "" : Request["Ddl_Select_" + i.ToString() + ""].ToString();
                KNet.Model.PB_Basic_Code Model1 = Bll.GetModel("762", s_Ddl_Select);
                if (Model1 != null)
                {
                    KNet.Model.Excel_In_Details Model_Details = new KNet.Model.Excel_In_Details();
                    Model_Details.EID_ID = GetMainID(i);
                    Model_Details.EID_Name = Model1.PBC_Name;
                    Model_Details.EID_YLine = i;
                    Model_Details.EID_ColName = Model1.PBC_Details;
                    Model_Details.EID_FID = this.Tbx_ID.Text;
                    Bll_Details.Add(Model_Details);
                }
            }
            KNet.BLL.Excel_In_Manage Bll_Manage = new KNet.BLL.Excel_In_Manage();
            Bll_Manage.DeleteByFID(this.Tbx_ID.Text);
            KNet.Model.Excel_In_Manage Model_Manage = new KNet.Model.Excel_In_Manage();
            Model_Manage.EIM_ID = GetMainID();
            Model_Manage.EIM_Name = this.Tbx_SuppName.Text;
            Model_Manage.EIM_Type = this.Tbx_CheckType.Text;
            Model_Manage.EIM_FID = this.Tbx_ID.Text;
            Model_Manage.EIM_Details1 = this.Tbx_Table.Text;
            Bll_Manage.Add(Model_Manage);

            StringBuilder s = new StringBuilder();
            s.Append("<script language=javascript>" + "\n");
            s.Append("window.close();" + "\n");
            s.Append("</script>");
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            string csname = "ltype";
            if (!cs.IsStartupScriptRegistered(cstype, csname))
                cs.RegisterStartupScript(cstype, csname, s.ToString());
        }
        catch
        { }
    }
    protected void Lbl_Save_Click(object sender, EventArgs e)
    {
        try
        {
            KNet.BLL.PB_Basic_Code Bll = new KNet.BLL.PB_Basic_Code();
            KNet.Model.PB_Basic_Code Model = new KNet.Model.PB_Basic_Code();
            KNet.BLL.Excel_In_Details Bll_Details = new KNet.BLL.Excel_In_Details();

            Model.PBC_ID = "763";
            Model.PBC_Code = Convert.ToString(int.Parse(Bll.GetMaxCodeByID("763")) + 1);
            Model.PBC_Name = this.Tbx_Model.Text;
            Model.PBC_Order = int.Parse(Bll.GetMaxCodeByID("763")) + 1;
            Bll.Add(Model);
            int i_num = int.Parse(this.Tbx_Num.Text);
            for (int i = 0; i < i_num; i++)
            {
                string s_Ddl_Select = Request["Ddl_Select_" + i.ToString() + ""] == null ? "" : Request["Ddl_Select_" + i.ToString() + ""].ToString();
                KNet.Model.PB_Basic_Code Model1 = Bll.GetModel("762", s_Ddl_Select);
                if (Model1 != null)
                {
                    KNet.Model.Excel_In_Details Model_Details = new KNet.Model.Excel_In_Details();
                    Model_Details.EID_ID = GetMainID(i);
                    Model_Details.EID_Name = Model1.PBC_Name;
                    Model_Details.EID_YLine = i;
                    Model_Details.EID_ColName = Model1.PBC_Details;
                    Model_Details.EID_FID = Model.PBC_Code;
                    Bll_Details.Add(Model_Details);
                }
            }
            base.Base_DropBasicCodeBind(this.Ddl_Model, "763");
            Alert("模板保存成功！");
        }
        catch
        { }
    }
    protected void Lbl_Del_Click(object sender, EventArgs e)
    {
        try
        {
            KNet.BLL.Excel_In_Details BLL_Details = new KNet.BLL.Excel_In_Details();
            KNet.BLL.PB_Basic_Code Bll = new KNet.BLL.PB_Basic_Code();
            string s_ID = this.Ddl_Model.SelectedValue;
            BLL_Details.DeleteByFID(s_ID);
            Bll.Delete("763", s_ID);
            base.Base_DropBasicCodeBind(this.Ddl_Model, "763");
            Alert("模板删除成功！");
        }
        catch
        {
        }

    }
    protected void Ddl_Model_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.Ddl_Model.SelectedValue != "")
        {

            this.Lbl_Details.Text = "";
            string s_ID = Request["ID"] == null ? "" : Request["ID"].ToString();
            string s_Table = Request.QueryString["Table"] == null ? "" : Server.UrlDecode(Request.QueryString["Table"].ToString());
            string s_Sql = "Select * from PB_Basic_Attachment where PBA_Type='CgFp' and PBA_FID='" + s_ID + "' order by PBA_CTime desc";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Att = this.QueryForDataTable();
            if (Dtb_Att.Rows.Count > 0)
            {
                Excel excel = new Excel();
                DataTable myT = excel.ExcelToDataTable(Dtb_Att.Rows[0]["PBA_URL"].ToString(), s_Table);
                if (myT == null)
                {
                    AlertAndClose("未找到该Sheet表");

                }
                else
                {
                    for (int j = 0; j < myT.Columns.Count; j++)
                    {
                        this.Lbl_Details.Text += "<tr>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\"><select name=\"Ddl_Select_" + j + "\">";
                        this.BeginQuery("select * from PB_Basic_Code where PBC_ID='762'");
                        DataTable Dtb_Table = this.QueryForDataTable();
                        this.Lbl_Details.Text += "<option value=></option>";

                        string s_Select = "",s_Name="";
                        KNet.BLL.Excel_In_Details BLL_Details = new KNet.BLL.Excel_In_Details();
                        DataSet Dtbs_Excel = BLL_Details.GetList("EID_FID='" + this.Ddl_Model.SelectedValue + "' and EID_Yline='" + j.ToString() + "'");
                        if (Dtbs_Excel.Tables[0].Rows.Count > 0)
                        {
                            s_Select = "selected";
                            s_Name=Dtbs_Excel.Tables[0].Rows[0]["EID_Name"].ToString();
                        }
                        else
                        {
                            s_Select = "";
                            s_Name="";
                        }
                        for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                        {
                            if (Dtb_Table.Rows[i]["PBC_Name"].ToString() == s_Name)
                            {
                                s_Select = "selected";
                            }
                            else
                            {
                                s_Select = "";
                            }
                            this.Lbl_Details.Text += "<option value='" + Dtb_Table.Rows[i]["PBC_Code"].ToString() + "' " + s_Select + ">" + Dtb_Table.Rows[i]["PBC_Name"].ToString() + "</option>";
                        }
                        this.Lbl_Details.Text += "</select></td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + myT.Rows[0][j].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + myT.Rows[1][j].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + myT.Rows[2][j].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + myT.Rows[3][j].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + myT.Rows[4][j].ToString() + "</td>";
                        this.Lbl_Details.Text += "<td class=\"ListHeadDetails\" align=\"left\">" + myT.Rows[5][j].ToString() + "</td>";
                        this.Lbl_Details.Text += "</tr>";

                    }
                    this.Tbx_Num.Text = myT.Columns.Count.ToString();
                }

            }
        }
    }
}

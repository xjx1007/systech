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

using KNet.DBUtility;
using KNet.Common;
using System.Data.SqlClient;
using System.Text;

public partial class PB_Basic_Where_Add : BasePage
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
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Tbx_ID.Text = s_ID;
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_SType = Request.QueryString["SType"] == null ? "" : Request.QueryString["SType"].ToString();
            string s_Table = Request.QueryString["Table"] == null ? "" : Request.QueryString["Table"].ToString();
            this.Ddl_Type.SelectedValue = s_SType;
            this.Tbx_Table.Text = s_Table;
            this.Tbx_Type.Text = s_Type;
            if (s_ID != "")
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制条件";
                }
                else
                {
                    this.Lbl_Title.Text = "修改条件";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID);
            }
            else
            {
                this.Lbl_Title.Text = "新增条件";
                this.Tbx_Order.Text = "0";
                try
                {
                    string s_Sql = "Select Max(PBW_Order) from PB_Basic_Where  where 1=1 ";
                    if (s_SType != "")
                    {
                        s_Sql += " and PBW_Type='" + s_SType + "'";
                    }
                    this.BeginQuery(s_Sql);
                    string s_Order = this.QueryForReturn();
                    this.Tbx_Order.Text = Convert.ToString(int.Parse(s_Order) + 1);
                }
                catch
                { }
            }
            GetCoumn(this.Tbx_Table.Text);
            GetUseTable(this.Tbx_Table.Text);
        }

    }
    private void GetUseTable(string s_Table)
    {
        this.BeginQuery("select * from PB_Basic_Code Where PBC_ID='762'");
        DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
        this.Lbl_Table.Text = "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"small\">\n";
        this.Lbl_Table.Text += "<tr>\n";
        this.Lbl_Table.Text += "<td class=\"ListHead\" nowrap>\n";
        this.Lbl_Table.Text += "<b>表名</b>\n";
        this.Lbl_Table.Text += "</td>\n";
        this.Lbl_Table.Text += "<td class=\"ListHead\" nowrap>\n";
        this.Lbl_Table.Text += "<b>主键</b>\n";
        this.Lbl_Table.Text += "</td>\n";
        this.Lbl_Table.Text += "<td class=\"ListHead\" nowrap>\n";
        this.Lbl_Table.Text += "<b>描述</b>\n";
        this.Lbl_Table.Text += "</td>\n";
        this.Lbl_Table.Text += "</tr>\n";
        for (int i = 0; i < Dtb_Table.Rows.Count; i++)
        {
            this.Lbl_Table.Text += "<tr>\n";
            this.Lbl_Table.Text += "<td class=\"ListHeadDetails\" nowrap>\n";
            this.Lbl_Table.Text += "<a target=\"_blank\" href=\"Table_View.aspx?ID=" + Dtb_Table.Rows[i]["PBC_Code"].ToString() + "\">" + Dtb_Table.Rows[i]["PBC_Code"].ToString() + "</a>\n";
            this.Lbl_Table.Text += "</td>\n";
            this.Lbl_Table.Text += "<td class=\"ListHeadDetails\" nowrap>\n";
            this.Lbl_Table.Text += "" + Dtb_Table.Rows[i]["PBC_Name"].ToString() + "\n";
            this.Lbl_Table.Text += "</td>\n";
            this.Lbl_Table.Text += "<td class=\"ListHeadDetails\" nowrap>\n";
            this.Lbl_Table.Text += "" + Dtb_Table.Rows[i]["PBC_CName"].ToString() + "\n";
            this.Lbl_Table.Text += "</td>\n";
            this.Lbl_Table.Text += "</tr>\n";
        }
        if (s_Table != "")
        {
            s_Table = s_Table + "_Details";
            string s_Sql1 = "select syscolumns.name as name,systypes.name as TypeName,syscolumns.length as Length,sys.extended_properties.Value as description from syscolumns  ";
            s_Sql1 += " left join sys.extended_properties on sys.extended_properties.major_id=syscolumns.ID and sys.extended_properties.minor_id=syscolumns.colorder";
            s_Sql1 += " left join systypes on systypes.xusertype=syscolumns.xusertype";
            s_Sql1 += " where syscolumns.id in (select id from sysobjects where name='" + s_Table + "') order by colid";
            this.BeginQuery(s_Sql1);
            Dtb_Table = (DataTable)this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                this.Lbl_Table.Text += "<tr>\n";
                this.Lbl_Table.Text += "<td class=\"ListHeadDetails\" nowrap>\n";
                this.Lbl_Table.Text += "<a target=\"_blank\" href=\"Table_View.aspx?ID=" + s_Table + "\">" + s_Table + "</a>\n";
                this.Lbl_Table.Text += "</td>\n";
                this.Lbl_Table.Text += "<td class=\"ListHeadDetails\" nowrap>\n";
                this.Lbl_Table.Text += "" + Dtb_Table.Rows[0]["name"].ToString() + "," + Dtb_Table.Rows[1]["name"].ToString() + "\n";
                this.Lbl_Table.Text += "</td>\n";
                this.Lbl_Table.Text += "<td class=\"ListHeadDetails\" nowrap>\n";
                this.Lbl_Table.Text += "明细表\n";
                this.Lbl_Table.Text += "</td>\n";
                this.Lbl_Table.Text += "</tr>\n";
            }
        }
        this.Lbl_Table.Text += "</table>\n";
    }
    private void ShowInfo(string s_ID)
    {
        KNet.BLL.PB_Basic_Where bll = new KNet.BLL.PB_Basic_Where();
        KNet.Model.PB_Basic_Where model = bll.GetModel(s_ID); 
        if (model != null)
        {
            this.Tbx_ID.Text = model.PBW_ID.ToString();
            this.Tbx_Name.Text = model.PBW_Name.ToString();
            this.Tbx_Table.Text = model.PBW_Table.ToString();
            this.Tbx_Sql.Text = model.PBW_Sql.ToString();
            this.Ddl_Type.SelectedValue = model.PBW_Type.ToString();
            this.Tbx_Order.Text = model.PBW_Order.ToString();
            this.Tbx_Cloumn.Text = model.PBW_Cloumn.ToString();
            this.Tbx_FromTable.Text = model.PBW_FromTable.ToString();
            this.Tbx_FromValue.Text = model.PBW_FromValue.ToString();
            this.Tbx_FromName.Text = model.PBW_FromName.ToString();
            this.Ddl_InputType.Text = model.PBW_InputType.ToString();
            this.Tbx_FromWhere.Text = model.PBW_FromWhere.ToString();
        }
    }
   private void GetCoumn(string s_Table)
   {
       try
       {
           string s_Sql1 = "select syscolumns.name as name,systypes.name as TypeName,syscolumns.length as Length,sys.extended_properties.Value as description from syscolumns  ";
           s_Sql1 += " left join sys.extended_properties on sys.extended_properties.major_id=syscolumns.ID and sys.extended_properties.minor_id=syscolumns.colorder";
           s_Sql1 += " left join systypes on systypes.xusertype=syscolumns.xusertype";
           s_Sql1 += " where syscolumns.id in (select id from sysobjects where name='" + s_Table + "') order by colid";
           this.BeginQuery(s_Sql1);
           DataTable Dtb_Table = (DataTable)this.QueryForDataTable();
           this.Lbl_Column.Text = "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"small\">\n";
           this.Lbl_Column.Text += "<tr>\n";
           this.Lbl_Column.Text += "<td class=\"ListHead\" nowrap>\n";
           this.Lbl_Column.Text += "<b>列名</b>\n";
           this.Lbl_Column.Text += "</td>\n";
           this.Lbl_Column.Text += "<td class=\"ListHead\" nowrap>\n";
           this.Lbl_Column.Text += "<b>描述</b>\n";
           this.Lbl_Column.Text += "</td>\n";
           this.Lbl_Column.Text += "</tr>\n";
           for (int i = 0; i < Dtb_Table.Rows.Count; i++)
           {
               this.Lbl_Column.Text += "<tr>\n";

               this.Lbl_Column.Text += "<td class=\"ListHeadDetails\" nowrap>\n";
               this.Lbl_Column.Text += "" + Dtb_Table.Rows[i]["name"].ToString() + "\n";
               this.Lbl_Column.Text += "</td>\n";
               this.Lbl_Column.Text += "<td class=\"ListHeadDetails\" nowrap>\n";
               this.Lbl_Column.Text += "" + Dtb_Table.Rows[i]["description"].ToString() + "&nbsp;\n";
               this.Lbl_Column.Text += "</td>\n";
               this.Lbl_Column.Text += "</tr>\n";
           }
           this.Lbl_Column.Text += "</table>\n";
       }
       catch { }

   }

    private bool SetValue(KNet.Model.PB_Basic_Where model)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
             if (this.Tbx_ID.Text == "")
            {
                model.PBW_ID = GetMainID();
            }
            else
            {
                model.PBW_ID = this.Tbx_ID.Text;
             }
            model.PBW_Name = this.Tbx_Name.Text;
            model.PBW_Table = this.Tbx_Table.Text.ToString();
            model.PBW_Sql = this.Tbx_Sql.Text.ToString();
            model.PBW_Type = this.Ddl_Type.SelectedValue.ToString();
            model.PBW_Del = 0;
            model.PBW_Order = int.Parse(this.Tbx_Order.Text.ToString());
            model.PBW_Cloumn = this.Tbx_Cloumn.Text.ToString();
            model.PBW_FromTable = this.Tbx_FromTable.Text.ToString();
            model.PBW_FromValue = this.Tbx_FromValue.Text.ToString();
            model.PBW_FromName = this.Tbx_FromName.Text.ToString();
            model.PBW_InputType = this.Ddl_InputType.SelectedValue.ToString();
            model.PBW_FromWhere = this.Tbx_FromWhere.Text.ToString();
            model.PBW_CTime = DateTime.Now;
            model.PBW_Creator = AM.KNet_StaffNo;
            model.PBW_MTime = DateTime.Now;
            model.PBW_Mender = AM.KNet_StaffNo;
            return true;
        }
        catch
        {
            return false;
        }

    }
    protected void Btn_Send_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.PB_Basic_Where model = new KNet.Model.PB_Basic_Where();
        KNet.BLL.PB_Basic_Where bll = new KNet.BLL.PB_Basic_Where();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (this.Tbx_ID.Text != "")//修改
        {
            try
            {
                if (bll.Update(model))
                {
                    AM.Add_Logs("条件修改" + this.Tbx_ID.Text);
                  //  base.Base_SendMessage(model.PBW_ID, "条件： <a href='Web/Notice/PB_Basic_Where_View.aspx?ID=" + this.Tbx_ID.Text + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBW_ID + "</a> ");
                    AlertAndRedirect("修改成功！", "PB_Basic_Where_List.aspx");
                }
                else
                {
                    AM.Add_Logs("条件修改失败" + this.Tbx_ID.Text);
                    AlertAndRedirect("修改失败！", "PB_Basic_Where_Add.aspx?ID=" + this.Tbx_ID.Text + "");
                }
            }
            catch { }
        }
        else
        {

            try
            {
                bll.Add(model);
               // base.Base_SendMessage(model.PBN_ReceiveID, "条件： <a href='Web/Notice/PB_Basic_Where_View.aspx?ID=" + model.PBN_ID + "'  target=\"_blank\" onclick='RemoveSms('#ID', '', 0);'> " + model.PBN_Title + "</a> ");
                AM.Add_Logs("条件增加" + model.PBW_ID);
                AlertAndRedirect("新增成功！", "PB_Basic_Where_List.aspx");
            }
            catch { }
        }
    }
}

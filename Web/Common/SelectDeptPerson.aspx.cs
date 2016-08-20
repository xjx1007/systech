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
using System.Text;
using KNet.DBUtility;
using KNet.Common;
using System.Data.SqlClient;

public partial class Web_Common_SelectDeptPerson : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
                KNetStaffBranchBind();
                this.DataShows();
            }
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.KNet_Resource_Staff bll = new KNet.BLL.KNet_Resource_Staff();
        try
        {
            string s_IDs = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_Sql = "select * from KNet_Resource_Staff ";
            s_Sql += " where StaffYN='0' and Staffadmin='0' ";
            if (this.KNetStaffDepart.SelectedValue != "")
            {
                s_Sql += " and StaffDepart='" + this.KNetStaffDepart.SelectedValue + "'";
            }
            if (this.SeachKey.Text != "")
            {
                s_Sql += " and StaffName like '%" + this.SeachKey.Text + "%'";
            }
            if (s_IDs != "")
            {
                s_Sql += " and StaffNo not in ('" + s_IDs.Replace(",", "','") + "')";
            }
            s_Sql += "  order by StaffDepart,StaffAddTime desc";
            this.BeginQuery(s_Sql);
            DataSet Dts_Result = (DataSet)this.QueryForDataSet();
            Lst_FName.Items.Clear();
            for (int i = 0; i < Dts_Result.Tables[0].Rows.Count; i++)
            {

                TreeNode node = new TreeNode();
                string s_Name = Dts_Result.Tables[0].Rows[i]["StaffName"].ToString();
                string s_ID = Dts_Result.Tables[0].Rows[i]["StaffNo"].ToString();
                ListItem Item = new ListItem();
                Item.Value = s_ID;
                Item.Text = s_Name;
                Lst_FName.Items.Add(Item);
            }

            string s_Sql1 = "select * from KNet_Resource_Staff ";
            s_Sql1 += " where StaffYN='0' and Staffadmin='0' ";
            s_Sql1 += " and StaffNo  in ('" + s_IDs.Replace(",", "','") + "')";
            this.BeginQuery(s_Sql1);
            DataSet Dts_Result1 = (DataSet)this.QueryForDataSet();
            //Lst_Name.Items.Clear();
            for (int i = 0; i < Dts_Result1.Tables[0].Rows.Count; i++)
            {

                TreeNode node = new TreeNode();
                string s_Name = Dts_Result1.Tables[0].Rows[i]["StaffName"].ToString();
                string s_ID = Dts_Result1.Tables[0].Rows[i]["StaffNo"].ToString();
                ListItem Item = new ListItem();
                Item.Value = s_ID;
                Item.Text = s_Name;
                Lst_Name.Items.Add(Item);
            }
        }
        catch (Exception ex)
        {
            return;
        }
    }

    /// <summary>
    /// 确定选择
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string StaffNo = "",StaffName="";
        string Phone = "";

            StringBuilder s = new StringBuilder();
            StaffNo = Request["Lst_Name"]==null?"":Request["Lst_Name"].ToString();
            this.BeginQuery("Select * from KNet_Resource_Staff where StaffNo in ('" + StaffNo.Replace(",","','") + "')");
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                {
                    Phone += Dtb_Result.Rows[i]["StaffTel"].ToString()+",";
                    StaffName += Dtb_Result.Rows[i]["StaffName"].ToString() + ",";
                }
                Phone = Phone.Substring(0, Phone.Length - 1);
                StaffName = StaffName.Substring(0, StaffName.Length - 1);
            }
            s.Append("<script language=javascript>" + "\n");
            s.Append("if(window.opener != undefined) {window.opener.returnValue='" + StaffNo + "|" + StaffName + "|" + Phone + "';} else{window.returnValue='" + StaffNo + "|" + StaffName + "|" + Phone + "';}" + "\n");
            s.Append("window.close();" + "\n");
            s.Append("</script>");
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            string csname = "ltype";
            if (!cs.IsStartupScriptRegistered(cstype, csname))
                cs.RegisterStartupScript(cstype, csname, s.ToString());
    }

    /// <summary>
    /// 分公司绑定
    /// </summary>
    protected void KNetStaffBranchBind()
    {
        KNet.BLL.KNet_Resource_OrganizationalStructure bll = new KNet.BLL.KNet_Resource_OrganizationalStructure();
        using (DataSet ds = bll.GetList(" StrucPID='0'"))
        {
            this.KNetStaffBranch.DataSource = ds;
            this.KNetStaffBranch.DataTextField = "StrucName";
            this.KNetStaffBranch.DataValueField = "StrucValue";
            this.KNetStaffBranch.DataBind();

            ListItem item2 = new ListItem("请选择部门", ""); //默认值
            this.KNetStaffDepart.Items.Insert(0, item2);

            string proID = this.KNetStaffBranch.SelectedValue.ToString().Trim();
            using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from KNet_Resource_OrganizationalStructure where StrucPID='" + proID + "' ", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                this.KNetStaffDepart.DataSource = sdr;
                this.KNetStaffDepart.DataTextField = "StrucName";
                this.KNetStaffDepart.DataValueField = "StrucValue";
                this.KNetStaffDepart.DataBind();
                ListItem item = new ListItem("请选择部门", ""); //默认值
                this.KNetStaffDepart.Items.Insert(0, item);
            }
        }
    }
    private void User_Tree_CreatPowerShareChecked(DataSet Dts_Result, TreeNodeCollection tn, string s_ParentID)
    {
        DataRow[] Dr_Row;
        if (s_ParentID.Length > 0)
        {
            Dr_Row = Dts_Result.Tables[0].Select("PBD_Upper='" + s_ParentID + "'");
        }
        else
        {
            Dr_Row = Dts_Result.Tables[0].Select("PBD_Level='1'");

            DataRow Dtr_Row1 = Dts_Result.Tables[0].NewRow();
            Dtr_Row1["PBD_Level"] = "2";
            Dtr_Row1["PBD_Upper"] = Dr_Row[0]["PBD_ID"].ToString();
            Dtr_Row1["PBD_ID"] = "9999123456781234";
            Dtr_Row1["PBD_Status"] = "1";
            Dtr_Row1["PBD_Name"] = "未设置部门人员";
            Dts_Result.Tables[0].Rows.Add(Dtr_Row1);
            Dts_Result.Tables[0].AcceptChanges();
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        this.DataShows();
    }
}

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

public partial class Web_Sales_Xs_Customer_Cares_List : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Lbl_Title.Text = "客户关怀列表";
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                //客户关怀删除
                if (AM.YNAuthority("删除客户关怀") == false)
                {
                    this.lbtn_Del.Enabled = false;
                }

                this.lbtn_Del.Attributes.Add("onclick", "return confirm('你确信要删除所选记录吗?！')");
                DataShows();
                base.Base_DropBatchBind(this.Ddl_Batch, "Xs_Customer_Cares", "XCC_DutyPerson");
            }
        }
        
    }

    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        string s_SqlWhere = " 1=1";

        string s_WhereID = Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString();
        if (s_WhereID != "")
        {
            s_SqlWhere += Base_GetBasicWhere(s_WhereID);
        }

        if (this.Ddl_Batch.SelectedValue != "")
        {
            s_SqlWhere += Base_GetBasicWhere(this.Ddl_Batch.SelectedValue);

        }
        KNet.BLL.Xs_Customer_Cares bll = new KNet.BLL.Xs_Customer_Cares();
        DataSet ds = bll.GetList(s_SqlWhere);
        this.MyGridView1.DataSource=ds;
        MyGridView1.DataBind();
    }

    protected void Btn_Query_Click(object sender, EventArgs e)
    {
        this.DataShows();


    }
    protected void Btn_Del_Click(object sender, EventArgs e)
    {
        StringBuilder s_Sql = new StringBuilder();
        StringBuilder s_Log = new StringBuilder();
        try
        {
            for (int i = 0; i < MyGridView1.Rows.Count; i++)
            {
                CheckBox Ckb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
                if (Ckb.Checked)
                {
                    string s_ID = MyGridView1.Rows[i].Cells[1].Text;
                    s_Sql.Append(" delete from  Xs_Customer_Cares Where XOL_ID='" + s_ID + "' ");
                    s_Log.Append(s_ID);
                }
            }
            DbHelperSQL.ExecuteSql(s_Sql.ToString());
            this.DataShows();
            AdminloginMess AM = new AdminloginMess();
            AM.Add_Logs("Xs_Customer_Cares 删除 编号：" + s_Log + "");
            Alert("删除成功！");
        }
        catch (Exception ex)
        {
            Alert("删除失败！");
            return;
        }
    }

    protected void Ddl_Batch_TextChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }
}

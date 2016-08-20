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


public partial class Web_Common_SelectContentPerson : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.DataShows();
            
        }
    }
    private void DataShows()
    {
        KNet.BLL.XS_Compy_LinkMan BLL_Compy_LinkMan = new KNet.BLL.XS_Compy_LinkMan();
        string s_SqlWhere=" 1=1 ";
        if (Request.QueryString["ID"].ToString() != "")
        {
            s_SqlWhere += " and XOL_Compy='" + Request.QueryString["ID"].ToString() + "'";
        }
        if(this.Tbx_Name.Text!="")
        {
           s_SqlWhere+=" and XOL_Name Like '%"+this.Tbx_Name.Text+"%' ";
        }
        DataSet Dts_LinkMan = BLL_Compy_LinkMan.GetList(s_SqlWhere);
        this.GridView1.DataSource = Dts_LinkMan;
        this.GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int i_Num = 0;
        string s_Return = "";
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("Chbk");
            if (cb.Checked)
            {
                string s_Name = GridView1.Rows[i].Cells[1].Text;
                string s_Telphone = GridView1.Rows[i].Cells[2].Text;
                if ((s_Telphone == "&nbsp;")||(s_Telphone == ""))
                {
                    s_Telphone = GridView1.Rows[i].Cells[5].Text;
                }
                string s_ID = GridView1.Rows[i].Cells[4].Text;
                string s_Address = GridView1.Rows[i].Cells[6].Text;
                s_Return = s_Name + "," + s_Telphone + "," + s_ID + "," + s_Address;
                i_Num++;
            }

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
                s.Append("<script language=javascript>\n");
                s.Append("window.returnValue='" + s_Return + "';");
                s.Append("window.close();\n");
                s.Append("</script>");
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                string csname = "ltype";
                if (!cs.IsStartupScriptRegistered(cstype, csname))
                    cs.RegisterStartupScript(cstype, csname, s.ToString());
            }
        }
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        this.DataShows();

    }

    public string GetLink(string s_ID)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.XS_Compy_LinkMan bll = new KNet.BLL.XS_Compy_LinkMan();
            KNet.Model.XS_Compy_LinkMan Model = bll.GetModel(s_ID);
            string s_Details = Model.XOL_Name + "," + Model.XOL_Phone + "," + s_ID + "," + Model.XOL_Address;

            s_Return += "<a href=\"javascript:window.close();\" onclick='set_return(\"" + s_Details + "\")'>" + Model.XOL_Name + "</a>";

        }
        catch
        {
            s_Return = "-";

        }
        return s_Return;
    }
}

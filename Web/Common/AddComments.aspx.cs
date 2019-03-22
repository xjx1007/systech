using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using KNet.DBUtility;

public partial class Web_Common_AddComments : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            base.Base_DropBasicCodeBind(this.DdlPBC_Preset, "201", false);
        }

    }
    protected void save_Click(object sender, EventArgs e)
    {
        AdminloginMess AM=new AdminloginMess();
        KNet.BLL.PB_Basic_Comment BLL = new KNet.BLL.PB_Basic_Comment();
        KNet.Model.PB_Basic_Comment model = new KNet.Model.PB_Basic_Comment();
        model.PBC_FID = Request.QueryString["PBC_FID"];
        model.PBC_Type = Convert.ToInt32(Request.QueryString["PBC_Type"]);
        model.PBC_PresetCode = Convert.ToInt32(this.DdlPBC_Preset.SelectedValue);
        model.PBC_Description = this.txtDescription.Text;
        model.PBC_CTime = DateTime.Now;
        model.PBC_FromPerson = AM.KNet_StaffNo;
        try
        {
            BLL.Add(model);
            AM.Add_Logs("评论增加成功：编号：" + model.PBC_FID);
            //StringBuilder s = new StringBuilder();
            //s.Append("<script language=javascript>" + "\n");
            //s.Append("alert('添加成功！');" + "\n");
            //s.Append("if(window.opener != undefined) {window.opener.returnValue='1';} else{window.returnValue='1';}" + "\n");
            //s.Append("window.close();" + "\n");
            //s.Append("</script>");
            //Type cstype = this.GetType();
            //ClientScriptManager cs = Page.ClientScript;
            //string csname = "ltype";
            //if (!cs.IsStartupScriptRegistered(cstype, csname))
            //    cs.RegisterStartupScript(cstype, csname, s.ToString());
            string s_Return = "1";
            StringBuilder s = new StringBuilder();
            s.Append("<script language=javascript>" + "\n");
            s.Append("alert('添加成功！');" + "\n");
            s.Append("if(window.opener != undefined)");
            s.Append("{\n");
            s.Append("    window.opener.returnValue = '" + s_Return + "';\n");
            s.Append("    window.opener.SetReturnValueInOpenner_UploadForProducts('" + s_Return + "');\n");
            s.Append("}\n");
            s.Append("else\n");
            s.Append("{\n");
            s.Append("    window.returnValue = '" + s_Return + "';\n");
            s.Append("}\n");
            //s.Append("if(window.opener != undefined) {window.opener.returnValue='1';} else{window.returnValue='1';}" + "\n");
            s.Append("window.close();" + "\n");
            s.Append("</script>");
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            string csname = "ltype";
            if (!cs.IsStartupScriptRegistered(cstype, csname))
                cs.RegisterStartupScript(cstype, csname, s.ToString());
        }
        catch { }
    }
}
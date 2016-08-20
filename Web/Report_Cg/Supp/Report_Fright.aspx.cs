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
using System.Data.SqlClient;

using KNet.DBUtility;
using KNet.Common;


public partial class Web_Report_OrderIn : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime datetime = DateTime.Now;
            KNet_Sys_ProcureTypebind();
        }
    }

    protected void KNet_Sys_ProcureTypebind()
    {
        KNet.BLL.KNet_Sys_ProcureType bll = new KNet.BLL.KNet_Sys_ProcureType();
        DataSet ds = bll.GetAllList();
        this.Ddl_Type.DataSource = ds;
        this.Ddl_Type.DataTextField = "ProcureTypeName";
        this.Ddl_Type.DataValueField = "ProcureTypeValue";
        this.Ddl_Type.DataBind();
        ListItem item = new ListItem("请选择采购类型", ""); //默认值
        this.Ddl_Type.Items.Insert(0, item);
    }
}

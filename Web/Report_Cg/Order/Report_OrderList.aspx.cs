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


public partial class Web_Report_CG_Report_OrderList : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            KNet.BLL.KNet_Sys_ProcureType bll = new KNet.BLL.KNet_Sys_ProcureType();
            DataSet ds = bll.GetAllList();
            this.OrderType.DataSource = ds;
            this.OrderType.DataTextField = "ProcureTypeName";
            this.OrderType.DataValueField = "ProcureTypeValue";
            this.OrderType.DataBind();
            ListItem item = new ListItem("请选择", ""); //默认值
            this.OrderType.Items.Insert(0, item);

            base.Base_DropDutyPerson(this.Ddl_DutyPerson, false);
            DateTime datetime = DateTime.Now;
            this.StartDate.Text = datetime.AddDays(1 - datetime.Day).ToShortDateString();
            this.EndDate.Text = datetime.ToShortDateString();
        }

    }

}

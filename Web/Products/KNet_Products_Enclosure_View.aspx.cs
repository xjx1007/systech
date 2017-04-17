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

public partial class PB_Basic_Attachment_View : BasePage
{
    public string  s_OrderStyle = "", s_DetailsStyle = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            this.Lbl_Title.Text = "查看产品附件";
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            try
            {
                ShowInfo(s_ID);
            }
            catch
            { }
        }

    }

    private void ShowInfo(string s_ID)
    {

        KNet.BLL.PB_Basic_Attachment bll = new KNet.BLL.PB_Basic_Attachment();
        KNet.Model.PB_Basic_Attachment model = bll.GetModel(s_ID);
        if (model != null)
        {
            this.Tbx_Name.Text = model.PBA_Name;
           // this.Tbx_Title.Text = model.PBA_Title;
            this.Tbx_TypeName.Text = base.Base_GetBasicCodeName("778", model.PBA_ProductsType);
            this.Lbl_Products.Text = base.Base_GetProdutsName_Link(model.PBA_FID);
            this.Lbl_FileType.Text = model.PBA_FileType;
            this.Tbx_STime.Text = model.PBA_CTime.ToString();
            this.Tbx_Person.Text = base.Base_GetUserName(model.PBA_Creator);
            this.Tbx_Remarks.Text = model.PBA_Remarks;
        KNet.Model.PB_Basic_Attachment model1 = bll.GetModel(model.PBA_UpdateFID);
            if(model1!=null)
            {
                this.Lbl_Update.Text = "<a href=\"KNet_Products_Enclosure_View.aspx?ID=" + model1 .PBA_ID+ "\">" + model1.PBA_Name+"</a>";
            }
            string s_Sql = "select * from PB_Basic_Attachment_DownRecord where PBAD_FID='" + s_ID + "' ";
            string SqlWhere = "  ";
            AdminloginMess AM = new AdminloginMess();
            SqlWhere += " order BY PBAD_Time desc ";
            this.BeginQuery(s_Sql + SqlWhere);
            DataSet ds = (DataSet)this.QueryForDataSet();
            // DataSet ds = bll.GetList(SqlWhere);
            GridView1.DataSource = ds;
            GridView1.DataKeyNames = new string[] { "PBAD_ID" };
            GridView1.DataBind();

        }
    }


    protected void Btn_SpSave(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        //批量审批
        KNet.BLL.Knet_Procure_SuppliersPrice Bll = new KNet.BLL.Knet_Procure_SuppliersPrice();
        try
        {
            string s_Logs = "";
            string s_ID = this.Tbx_ID.Text;
            KNet.Model.Knet_Procure_SuppliersPrice Model = new KNet.Model.Knet_Procure_SuppliersPrice();
            Model.ID = s_ID;
            Model.KPP_State = 1;
            Model.KPP_ShPerson = AM.KNet_StaffNo;
            Model.KPP_ShTime = DateTime.Now;
            Bll.UpdateState(Model);
            s_Logs = s_ID + ",";
            AM.Add_Logs("审批产品文件：" + s_Logs + "");
            AlertAndRedirect("审批成功！", "KNet_Products_Enclosure_List.aspx?ID=M160707014101612");
        }
        catch { }
    }


    protected void Btn_SpSave1(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        //批量审批
        KNet.BLL.Knet_Procure_SuppliersPrice Bll = new KNet.BLL.Knet_Procure_SuppliersPrice();
        try
        {
            string s_Logs = "";
            string s_ID = this.Tbx_ID.Text;
            KNet.Model.Knet_Procure_SuppliersPrice Model = new KNet.Model.Knet_Procure_SuppliersPrice();
            Model.ID = s_ID;
            Model.KPP_State = 2;
            Model.KPP_ShPerson = AM.KNet_StaffNo;
            Model.KPP_ShTime = DateTime.Now;
            Bll.UpdateState(Model);
            s_Logs = s_ID + ",";
            AM.Add_Logs("审批产品文件：" + s_Logs + "");
            AlertAndRedirect("反审批成功！", "KNet_Products_Enclosure_List.aspx?ID=M160707014101612");
        }
        catch { }
    }
}

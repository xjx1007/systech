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


public partial class PB_Basic_KnowledgeClass_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            KNet.BLL.PB_Basic_KnowledgeClass bll = new KNet.BLL.PB_Basic_KnowledgeClass();
            if (s_ID != "")
            {
                KNet.Model.PB_Basic_KnowledgeClass Model = bll.GetModel(s_ID);
                if (s_Type != "M")
                {
                    this.Tbx_FaterID.Text = s_ID;
                    this.Tbx_FaterName.Text = bll.GetKnowledgeName(s_ID);
                    this.Tbx_Code.Text = bll.GetMaxCode(s_ID);
                    this.Tbx_Order.Text = bll.GetMaxOrder(s_ID);
                }
                else
                {
                    this.Tbx_FaterID.Text = Model.PBK_FaterID;
                    this.Tbx_FaterName.Text = bll.GetKnowledgeName(Model.PBK_FaterID);
                    this.Tbx_Code.Text = Model.PBK_Code;
                    this.Tbx_Order.Text = Model.PBK_Order;
                    this.Tbx_Name.Text = Model.PBK_Name;
                    this.Tbx_ID.Text = s_ID;
                    this.Tbx_Days.Text = Model.PBK_Days.ToString();
                }
            }
        }
    }

    private void ShowInfo(string s_ID,string s_Code)
    {
        KNet.BLL.PB_Basic_KnowledgeClass bll = new KNet.BLL.PB_Basic_KnowledgeClass();

    }
    private bool SetValue(KNet.Model.PB_Basic_KnowledgeClass model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (this.Tbx_ID.Text != "")
            {
                model.PBK_ID = this.Tbx_ID.Text;
            }
            else
            {
                model.PBK_ID = GetMainID();
            }
            model.PBK_Code = this.Tbx_Code.Text;
            model.PBK_FaterID = this.Tbx_FaterID.Text;
            model.PBK_Name = this.Tbx_Name.Text;
            model.PBK_Order = this.Tbx_Order.Text;
            model.PBK_Creator = AM.KNet_StaffNo;
            model.PBK_CTime = DateTime.Now;
            model.PBK_Mender = AM.KNet_StaffNo;
            model.PBK_MTime = DateTime.Now;
            string s_Days=this.Tbx_Days.Text==""?"0":this.Tbx_Days.Text;
            model.PBK_Days = int.Parse(s_Days);
            return true;
        }
        catch
        {
            return false;
        }
       
    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.Model.PB_Basic_KnowledgeClass model = new KNet.Model.PB_Basic_KnowledgeClass();
        KNet.BLL.PB_Basic_KnowledgeClass bll = new KNet.BLL.PB_Basic_KnowledgeClass();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if (this.Tbx_ID.Text != "")//修改
        {
            try
            {
                bll.Update(model);
                AM.Add_Logs("知识类修改"+AM.KNet_StaffName+" 编号："+model.PBK_ID );
                AlertAndRedirect("修改成功！", "PB_Basic_KnowledgeClass_List.aspx");
            }
            catch { }
        }
        else
        {

            try
            {
                bll.Add(model);
                AM.Add_Logs("知识类增加:"+AM.KNet_StaffName+" 编号："+model.PBK_ID);
                AlertAndRedirect("新增成功！", "PB_Basic_KnowledgeClass_List.aspx");
            }
            catch { }
        }
    }
}

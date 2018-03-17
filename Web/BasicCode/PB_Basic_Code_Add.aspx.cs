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


public partial class PB_Basic_Code_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            string s_Code = Request.QueryString["Code"] == null ? "" : Request.QueryString["Code"].ToString();
            this.Tbx_ID1.Text = s_ID;
            this.Tbx_Code1.Text = s_Code;
            this.Lbl_Title.Text = "新增系统编码";
            if ((s_ID != "") && (s_Code != ""))
            {
                if (s_Type == "1")
                {
                    this.Tbx_ID.Text = "";
                    this.Lbl_Title.Text = "复制系统编码";
                }
                else
                {
                    this.Lbl_Title.Text = "修改系统编码";
                    this.Tbx_ID.Text = s_ID;
                }
                this.Btn_Save.Text = "保存";
                ShowInfo(s_ID, s_Code);
            }
            else
            {
                KNet.BLL.PB_Basic_Code bll = new KNet.BLL.PB_Basic_Code();
                if (s_ID != "")
                {
                    this.Tbx_ID.Text = s_ID;
                    try
                    {
                        KNet.Model.PB_Basic_Code model_Code = bll.GetModel(s_ID, bll.GetMaxCodeByID(s_ID));
                        this.Tbx_FCode.Text = model_Code.PBC_FCode;
                        this.Tbx_FID.Text = model_Code.PBC_FID;
                    }
                    catch
                    { }
                    this.Tbx_Code.Text = Convert.ToString(int.Parse(bll.GetMaxCodeByID(s_ID))+1);

                }
                else
                {
                    this.Tbx_ID.Text = Convert.ToString(int.Parse(bll.GetMaxID()) + 1);
 
                }
                this.Tbx_Order.Text = this.Tbx_Code.Text;
            }
            if (AM.CheckLogin(this.Lbl_Title.Text) == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
        }
    }

    private void ShowInfo(string s_ID,string s_Code)
    {
        KNet.BLL.PB_Basic_Code bll = new KNet.BLL.PB_Basic_Code();
        KNet.Model.PB_Basic_Code model = bll.GetModel(s_ID, s_Code);
        this.Tbx_ID.Text = model.PBC_ID;
        this.Tbx_Code.Text = model.PBC_Code;
        this.Tbx_Name.Text = model.PBC_Name;
        this.Tbx_Order.Text = model.PBC_Order.ToString();
        this.Tbx_Details.Text = model.PBC_Details;
        this.Tbx_CName.Text = model.PBC_CName;
        this.Tbx_FID.Text = model.PBC_FID;
        this.Tbx_FCode.Text = model.PBC_FCode;
        

    }
    private bool SetValue(KNet.Model.PB_Basic_Code model)
    {

        AdminloginMess AM = new AdminloginMess();
        try
        {
            model.PBC_ID = this.Tbx_ID.Text;
            model.PBC_Code = this.Tbx_Code.Text;
            model.PBC_Name = this.Tbx_Name.Text;
            model.PBC_Order = int.Parse(this.Tbx_Order.Text);
            model.PBC_Details = this.Tbx_Details.Text;
            model.PBC_CName = this.Tbx_CName.Text;
            model.PBC_FID = this.Tbx_FID.Text;
             model.PBC_FCode=this.Tbx_FCode.Text ;
            model.PBC_Del = 0;
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
        KNet.Model.PB_Basic_Code model = new KNet.Model.PB_Basic_Code();
        KNet.BLL.PB_Basic_Code bll = new KNet.BLL.PB_Basic_Code();

        if (this.SetValue(model) == false)
        {
            Alert("系统错误！");
            return;
        }
        if ((this.Tbx_ID1.Text != "")&&(this.Tbx_Code1.Text!=""))//修改
        {
            try
            {
                bll.Update(model);
                AM.Add_Logs("系统编码修改" + this.Tbx_ID.Text);
                AlertAndRedirect("修改成功！", "PB_Basic_Code_List.aspx?ID=" + this.Tbx_ID.Text + "");
            }
            catch { }
        }
        else
        {

            try
            {
                bll.Add(model);
                AM.Add_Logs("系统编码增加" + this.Tbx_ID.Text);
                AlertAndRedirect("新增成功！", "PB_Basic_Code_List.aspx?ID=" + this.Tbx_ID.Text + "");
            }
            catch(Exception ex) { }
        }
    }
}

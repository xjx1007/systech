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


/// <summary>
/// 人力资源--人员信息修改
/// </summary>
public partial class Knet_Web_HR_KNet_HR_Manage_Update : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          

            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("修改人员管理") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            else
            {
                ////企业人事修改
                //if (AM.YNAuthority(NQ.Str5005) == false)
                //{
                //    AM.NoAuthority("5005");
                //}

                if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
                {
                    this.DataBindStaffBranch();
                    this.ShowInfo(Request.QueryString["ID"].ToString().Trim());
                   
                }
                else
                {
                    Response.Write("<script>alert('非法参数！');history.back(-1);</script>");
                    Response.End();
                }


               
            }
        }
    }

 


    /// <summary>
    /// 公司绑定
    /// </summary>
    protected void DataBindStaffBranch()
    {
        KNet.BLL.KNet_Resource_OrganizationalStructure bll = new KNet.BLL.KNet_Resource_OrganizationalStructure();
        DataSet ds = bll.GetList(" StrucPID='0' ");
        this.StaffBranch1.DataSource = ds;
        this.StaffBranch1.DataTextField = "StrucName";
        this.StaffBranch1.DataValueField = "StrucValue";
        this.StaffBranch1.DataBind();

        ListItem item = new ListItem("请选择分部", ""); //默认值
        this.StaffBranch1.Items.Insert(0, item);
        


        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from KNet_Resource_OrganizationalStructure where StrucPID='" + this.StaffBranch1.SelectedValue + "' ", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                this.StaffDepart1.DataSource = sdr;
                this.StaffDepart1.DataTextField = "StrucName";
                this.StaffDepart1.DataValueField = "StrucValue";
                this.StaffDepart1.DataBind();
                ListItem item3 = new ListItem("请选择部门", ""); //默认值
                StaffDepart1.Items.Insert(0, item3);
            }
    }

    /// <summary>
    /// 选择公司后
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void StaffBranch1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string proID = this.StaffBranch1.SelectedValue.ToString().Trim();
            using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from KNet_Resource_OrganizationalStructure where StrucPID='" + proID + "' ", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                this.StaffDepart1.DataSource = sdr;
                this.StaffDepart1.DataTextField = "StrucName";
                this.StaffDepart1.DataValueField = "StrucValue";
                this.StaffDepart1.DataBind();
                ListItem item = new ListItem("请选择部门", ""); //默认值
                StaffDepart1.Items.Insert(0, item);
            }
        }
        catch { }
    }




    /// <summary>
    /// 确定修改信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string ID = this.lblID.Text;
        string StaffNo = DateTime.Now.ToFileTimeUtc().ToString();
        string StaffBranch = this.StaffBranch1.SelectedValue;
        string StaffDepart = this.StaffDepart1.SelectedValue;
        string StaffCard = KNetPage.KHtmlEncode(this.StaffCard1.Text.Trim());
        string StaffName = KNetPage.KHtmlEncode(this.StaffName1.Text.Trim());

       
        string StaffPassword =KNetPage.KHtmlEncode(this.OldPasword.Text.Trim());

        if (this.StaffPassword1.Text.Trim() != "" && this.StaffPassword1.Text.Trim() != null)
        {
            StaffPassword = KNetPage.KNetMD5(this.StaffPassword1.Text.Trim().ToUpper());
        }
        

        decimal Staffwages = 0;
        if (this.Staffwages1.Text != null || this.Staffwages1.Text != "")
        {
            Staffwages = decimal.Parse(this.Staffwages1.Text.Trim().ToString());

        }

        bool StaffSex = true;
        if (int.Parse(this.StaffSex1.SelectedValue.ToString()) == 1)
        {
            StaffSex = true;
        }
        else
        {
            StaffSex = false;
        }


        string StaffTel = KNetPage.KHtmlEncode(this.StaffTel1.Text.Trim());
        string StaffEmail = KNetPage.KHtmlEncode(this.StaffEmail1.Text.Trim());
        string StaffAddress = KNetPage.KHtmlEncode(this.StaffAddress1.Text.Trim());
        string StaffIDCard = KNetPage.KHtmlEncode(this.StaffIDCard1.Text.Trim());

        DateTime StaffAddTime = DateTime.Now;
        if (this.StaffAddTime1.Text != "" && this.StaffAddTime1.Text != null)
        {
            try
            {
                StaffAddTime = DateTime.Parse(KNetPage.KHtmlEncode(this.StaffAddTime1.Text.Trim()));
            }
            catch { }
        }


        string StaffRemarks = this.Remarks1.Text.Trim();


        KNet.BLL.KNet_Resource_Staff BLL = new KNet.BLL.KNet_Resource_Staff();
        KNet.Model.KNet_Resource_Staff model = new KNet.Model.KNet_Resource_Staff();

        model.StaffNo = StaffNo;
        model.StaffBranch = StaffBranch;
        model.StaffDepart = StaffDepart;
        model.StaffCard = StaffCard;
        model.StaffName = StaffName;
        model.StaffPassword = StaffPassword;
        model.Staffwages = Staffwages;
        model.StaffSex = StaffSex;
        model.StaffTel = StaffTel;
        model.StaffEmail = StaffEmail;
        model.StaffAddress = StaffAddress;
        model.StaffIDCard = StaffIDCard;
        model.StaffAddTime = StaffAddTime;
        model.StaffRemarks = StaffRemarks;
        model.ID = ID;
        model.Position = this.Drop_Position.SelectedValue;

        try
        {
            BLL.Update(model);
            AdminloginMess LogAM = new AdminloginMess();
            LogAM.Add_Logs("人力资源--->人事管理  员工信息修改操作成功！名称：" + StaffName + "");
            Response.Write("<script>alert('员工 添加  成功！');location.href='KNet_HR_Manage.aspx';</script>");
            Response.End();
        }
        catch
        {
            throw;
        }
    }




    /// <summary>
    /// 显示人员信息
    /// </summary>
    /// <param name="ID"></param>
    protected void ShowInfo(string ID)
    {
        KNet.BLL.KNet_Resource_Staff bll = new KNet.BLL.KNet_Resource_Staff();
        KNet.Model.KNet_Resource_Staff model = bll.GetModel(ID);

        this.lblID.Text = model.ID;
        this.OldPasword.Text = model.StaffPassword.ToString();
        base.Base_DropBasicCodeBind(this.Drop_Position, "105");
        this.Drop_Position.SelectedValue = model.Position;

        try
        {
             this.StaffBranch1.SelectedValue = model.StaffBranch;

             using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
             {
                 conn.Open();
                 SqlCommand cmd = new SqlCommand("select * from KNet_Resource_OrganizationalStructure where StrucPID='" + this.StaffBranch1.SelectedValue + "' ", conn);
                 SqlDataReader sdr = cmd.ExecuteReader();
                 this.StaffDepart1.DataSource = sdr;
                 this.StaffDepart1.DataTextField = "StrucName";
                 this.StaffDepart1.DataValueField = "StrucValue";
                 this.StaffDepart1.DataBind();
                 ListItem item3 = new ListItem("请选择部门", ""); //默认值
                 StaffDepart1.Items.Insert(0, item3);

                 this.StaffDepart1.SelectedValue = model.StaffDepart;
             }
        }
        catch { }






        this.StaffCard1.Text = model.StaffCard;
        this.StaffName1.Text = model.StaffName;
        this.Staffwages1.Text = model.Staffwages.ToString();

        Boolean StaffSex2 = model.StaffSex;
        if (StaffSex2 == true)
        {
            this.StaffSex1.Items[0].Selected = true;
        }
        else
        {
            this.StaffSex1.Items[1].Selected = true;
        }
        this.StaffTel1.Text = model.StaffTel;
        this.StaffEmail1.Text = model.StaffEmail;
        this.StaffIDCard1.Text = model.StaffIDCard;
        this.StaffAddTime1.Text = DateTime.Parse(model.StaffAddTime.ToString()).ToShortDateString();
        this.StaffAddress1.Text = model.StaffAddress;
        this.Remarks1.Text = model.StaffRemarks;
    }
}

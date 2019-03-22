using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KNet.BLL;
using KNet.DBUtility;

public partial class Web_SC_Sc_Products_MakeMoneyAdd : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Ajax.Utility.RegisterTypeForAjax(typeof(Web_SC_Sc_Products_MakeMoneyAdd));
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string id= Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
           
            if (id!="")
            {
                this.Tbx_ID.Text = id;
                this.tit.InnerText = "修改制造费用";
                this.tit.InnerText = "修改制造费用";
                ShowInfo(id);
            }
        }
    }

    private void ShowInfo(string s_ID)
    {
        KNet.BLL.Sc_Products_MakeMoney bll = new KNet.BLL.Sc_Products_MakeMoney();
        KNet.Model.Sc_Products_MakeMoney model = bll.GetModel(s_ID);
        this.Tbx_ID.Text = s_ID;
        this.Tbx_Time.ReadOnly = true;
        this.Tbx_Time.Text = model.Stime.ToString();
        //this.Tbx_MakeMoney.Text = model.WCP_SuppNo;
        //this.Tbx_SuppName.Text = base.Base_GetSupplierName(model.WCP_SuppNo);
        //this.Tbx_WuliuSuppNo.Text = model.WCP_WuliuSuppNo;
        //this.Tbx_WuliuSuppName.Text = base.Base_GetSupplierName(model.WCP_WuliuSuppNo);
        //this.Ddl_DutyPerson.SelectedValue = model.WCP_DutyPerson;
        //this.Tbx_Remarks.Text = model.WCP_Remarks;
        //this.Tbx_Stime.Text = base.DateToString(model.WCP_STime.ToString());
    }

    protected void Btn_Save_OnClick(object sender, EventArgs e)
    {
        if (Tbx_ID.Text!="")
        {
            KNet.BLL.Sc_Products_MakeMoney scProductsMakeMoney = new Sc_Products_MakeMoney();
            KNet.Model.Sc_Products_MakeMoney modMakeMoney = new KNet.Model.Sc_Products_MakeMoney();
            modMakeMoney.ID = this.Tbx_ID.Text;
            modMakeMoney.Stime = Convert.ToDateTime(this.Tbx_Time.Text);
            modMakeMoney.MakeMoney = Convert.ToDecimal(this.Tbx_MakeMoney.Text);
            modMakeMoney.PeopleMoney = Convert.ToDecimal(this.Tbx_PeopleMoney.Text);
            modMakeMoney.ElseMaterialsMoney = Convert.ToDecimal(this.Tbx_ElseMaterialsMoney.Text);
            modMakeMoney.UnitsMakeMoney = Convert.ToDecimal(this.Tbx_UnitsMakeMoney.Text);
            modMakeMoney.UnitsPeopleMoney = Convert.ToDecimal(this.Tbx_PeopleMoney.Text);
            modMakeMoney.UnitsElseMaterialsMoney = Convert.ToDecimal(this.Tbx_UnitsElseMaterialsMoney.Text);
            modMakeMoney.CountTime = Convert.ToDecimal(this.Tbx_CountTime.Text);
            bool bl = scProductsMakeMoney.Update(modMakeMoney);
            if (bl)
            {
                AdminloginMess AM = new AdminloginMess();
                AM.Add_Logs("修改制造费用成功" + modMakeMoney.ID);
                AlertAndRedirect("修改制造费用成功！", "Sc_Products_MakeMoney.aspx");
            }
        }
        else
        {
            KNet.BLL.Sc_Products_MakeMoney scProductsMakeMoney = new Sc_Products_MakeMoney();
            KNet.Model.Sc_Products_MakeMoney modMakeMoney = new KNet.Model.Sc_Products_MakeMoney();
            modMakeMoney.ID = "MP" + string.Format("{0:yyyyMMddHHmmssff}", DateTime.Now);
            modMakeMoney.Stime = Convert.ToDateTime(this.Tbx_Time.Text);
            modMakeMoney.MakeMoney = Convert.ToDecimal(this.Tbx_MakeMoney.Text);
            modMakeMoney.PeopleMoney = Convert.ToDecimal(this.Tbx_PeopleMoney.Text);
            modMakeMoney.ElseMaterialsMoney = Convert.ToDecimal(this.Tbx_ElseMaterialsMoney.Text);
            modMakeMoney.UnitsMakeMoney = Convert.ToDecimal(this.Tbx_UnitsMakeMoney.Text);
            modMakeMoney.UnitsPeopleMoney = Convert.ToDecimal(this.Tbx_PeopleMoney.Text);
            modMakeMoney.UnitsElseMaterialsMoney = Convert.ToDecimal(this.Tbx_UnitsElseMaterialsMoney.Text);
            modMakeMoney.CountTime = Convert.ToDecimal(this.Tbx_CountTime.Text);
            bool bl = scProductsMakeMoney.Add(modMakeMoney);
            if (bl)
            {
                AdminloginMess AM = new AdminloginMess();
                AM.Add_Logs("添加制造费用" + modMakeMoney.ID);
                AlertAndRedirect("新增制造费用成功！", "Sc_Products_MakeMoney.aspx");
            }

        }

    }
}
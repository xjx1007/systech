using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 对发货单进行审核          建立出货回款账单----->建立运输费用付款账号（如果存在）
/// </summary>
public partial class Knet_Sales_ShipCheckDetail : BasePage
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        KNet.DBUtility.AdminloginMess AMLanguage = new KNet.DBUtility.AdminloginMess();
        if (AMLanguage.KNet_Soft_StaffLanguage == 2)
        {
            // 1、默认为简体转繁体，编码为utf-8
            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter);
        }
        else if (AMLanguage.KNet_Soft_StaffLanguage == 1)
        {
            // 2、繁体简体转，编码为utf-8
            Response.Filter = new LU.Web.ChineseConvertor(Response.Filter, LU.Web.ChineseConvertor.CCDirection.T2S);
        }
        else
        { }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("发货单审核") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }


            if (Request.QueryString["OutWareNo"] != null && Request.QueryString["OutWareNo"] != "")
            {
                this.UsersNotxt.Text = Request.QueryString["OutWareNo"].ToString().Trim();
                KNet.BLL.KNet_Sales_OutWareList BLL_Sales_OutWareList=new KNet.BLL.KNet_Sales_OutWareList();
                KNet.Model.KNet_Sales_OutWareList Model_Sales_OutWareList=BLL_Sales_OutWareList.GetModelB(this.UsersNotxt.Text);

                if (AM.KNet_StaffNo == Model_Sales_OutWareList.OutWareStaffNo)
                {
                    this.Button1.Enabled = true;
                }
                else
                {
                    this.Button1.Enabled = false;
                }
                KNet.BLL.KNet_Sales_Flow Bll = new KNet.BLL.KNet_Sales_Flow();
                KNet.Model.KNet_Sales_Flow Model = new KNet.Model.KNet_Sales_Flow();
                GridView1.DataSource = Bll.GetList(" KSF_ContractNo='" + this.UsersNotxt.Text + "' and KFS_Type='1'  Order  by KSF_Date desc");
                this.GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('非法参数！');window.close();</script>");
                Response.End();
            }
        }
    }
    /// <summary>
    /// 获取出货仓库
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Knet_KNet_Sales_HouseNo(string CustomerValue)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,HouseNo from KNet_Sales_ContractList where CustomerValue='" + CustomerValue + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["HouseNo"].ToString().Trim();
            }
            else
            {
                return "--"; ;
            }
        }
    }

    /// <summary>
    /// 获取客户名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Knet_KNet_Sales_ClientListName(string CustomerValue)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,CustomerValue,CustomerName from KNet_Sales_ClientList where CustomerValue='" + CustomerValue + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["CustomerName"].ToString().Trim();
            }
            else
            {
                return "--"; ;
            }
        }
    }

    /// <summary>
    /// 获取客户结账周期
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected double Knet_PlayCycleTime(string CustomerValue)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,CustomerValue,CustomerName,PlayCycleTime from KNet_Sales_ClientList where CustomerValue='" + CustomerValue + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return double.Parse(dr["PlayCycleTime"].ToString().Trim());
            }
            else
            {
                return 0; ;
            }
        }
    }

    /// <summary>
    /// 获取发货单明细数目
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu(string OutWareNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as IDS  from KNet_Sales_OutWareList_Details where OutWareNo='" + OutWareNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return int.Parse(dr["IDS"].ToString().Trim().ToString());
            }
            else
            {
                return -1;
            }
        }
    }



    private void AddFlow(string s_ContractNo, int i_State)
    {

        AdminloginMess AM = new AdminloginMess();
        //插入审核
        KNet.Model.KNet_Sales_Flow Model = new KNet.Model.KNet_Sales_Flow();
        KNet.BLL.KNet_Sales_Flow Bll = new KNet.BLL.KNet_Sales_Flow();
        Model.KFS_Type = 1;
        Model.KSF_ContractNo = s_ContractNo;
        Model.KSF_Date = DateTime.Now;
        Model.KSF_Detail = "";
        Model.KSF_ShPerson = AM.KNet_StaffNo;
        Model.KSF_State = i_State;
        try
        {
            Bll.Add(Model);
        }
        catch
        { throw; }
    }

    //流程
    public string GetFlowName(string s_Flow)
    {
        string s_FlowName = "";
        switch (s_Flow)
        {
            case "1":
                s_FlowName = "通过审核!";
                break;
            case "2":
                s_FlowName = "合同作废!";
                break;
            case "3":
                s_FlowName = "<font color='Blue'>异常通过!</font>";
                break;
            case "4":
                s_FlowName = "重新提交!";
                break;
            case "0":
                s_FlowName = "<font color='red'>不通过！</font>";
                break;
        }
        return s_FlowName;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string s_ContractNo = Request.QueryString["OutWareNo"].ToString();
        string s_Sql = "Update Knet_Sales_flow Set KSF_Del='1' Where KSF_ContractNo='" + s_ContractNo + "' ";
        DbHelperSQL.ExecuteSql(s_Sql);
        AddFlow(s_ContractNo, 4);
        Alert("提交成功！");
        AdminloginMess LogAM = new AdminloginMess();
        LogAM.Add_Logs("销售管理---> 合同审批--->重新提交 操作成功！");

    }
}

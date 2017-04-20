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
using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 选择供应商
/// </summary>
public partial class Knet_Common_SelectSuppliers : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "供应商选择";
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
               Response.End();
            }
            else
            {
                string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();
                base.Base_DropSheng(this.SuppProvinceDDL);
                KNet_Sys_ProcureTypebind();
                this.Ddl_Type.SelectedValue = s_Type;
                this.DataShows();
            }
        }
    }
    /// <summary>
    /// 绑定数据源
    /// </summary>
    protected void DataShows()
    {
        KNet.BLL.Knet_Procure_Suppliers bll = new KNet.BLL.Knet_Procure_Suppliers();
        string KSeachKey = null;

        string SqlWhere = " isnull(kps_del,0)=0 ";


        if (this.SeachKey.Text != "")
        {
            KSeachKey = this.SeachKey.Text;
            SqlWhere = SqlWhere + " and ( SuppName like '%" + KSeachKey + "%' or SuppPeople  like '%" + KSeachKey + "%' or SuppPhone  like '%" + KSeachKey + "%' )";
  
        }
        if (this.SuppProvinceDDL.SelectedValue != "")
        {
            SqlWhere = SqlWhere + " and SuppProvince = '" + this.SuppProvinceDDL.SelectedValue + "' ";

        }
        if (this.Ddl_Type.SelectedValue != "")
        {
            SqlWhere = SqlWhere + " and KPS_Type = '" + this.Ddl_Type.SelectedValue + "' ";
 
        }
        DataSet ds = bll.GetList(SqlWhere);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "SuppNo" };
        GridView1.DataBind();
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
    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click1(object sender, EventArgs e)
    {
        this.DataShows();
    }

    /// <summary>
    /// 按省份筛选记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void StrucNameDList_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }


    /// <summary>
    /// 返回省份名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetSuppProvinceName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,code,name from KNet_Static_Province where Id='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["name"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 返回城市名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetSuppCityName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,code,name from KNet_Static_City where code='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["name"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 返回供应商名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetSuppName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,SuppNo,SuppName from Knet_Procure_Suppliers where SuppNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["SuppName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }


    /// <summary>
    /// 得到供应商地址
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string GetSuppNoAddress(string SuppNoVale)
    {
        StringBuilder Sb_Return = new StringBuilder();
        this.BeginQuery("Select SuppAddress,SuppName,SuppPeople,SuppMobiTel,SuppPhone From Knet_Procure_Suppliers Where SuppNo='" + SuppNoVale + "'");
        this.QueryForDataTable();
        Sb_Return.Append("地址: "+this.Dtb_Result.Rows[0][0].ToString() + "$");
        Sb_Return.Append(this.Dtb_Result.Rows[0][1].ToString() + "$");
        Sb_Return.Append("收货人: " + this.Dtb_Result.Rows[0][2].ToString() + "$");
        if (this.Dtb_Result.Rows[0][3].ToString() != "")
        {
            Sb_Return.Append("联系手机:" + this.Dtb_Result.Rows[0][3].ToString() + "$");
        }
        if (this.Dtb_Result.Rows[0][4].ToString() != "")
        {
            Sb_Return.Append("联系电话:" + this.Dtb_Result.Rows[0][4].ToString() + "$");
        }

        //this.BeginQuery("Select * from Knet_Procure_OrdersList Where receiveSuppNo='" + SuppNoVale + "' Order by OrderDateTime desc");
        //this.QueryForDataTable();
        //if (this.Dtb_Result.Rows.Count > 0)
        //{
        //    Sb_Return.Append(this.Dtb_Result.Rows[0]["ContractAddress"].ToString()).Replace("\n", "$");
        //}
        //else
        //{
        //}
        return Sb_Return.ToString();
    }
    public string GetSupp(string s_ID)
    {
        string s_Return = "";
        try
        {
            //仓库
            string s_WareHouseNo = "";
            try
            {
                KNet.BLL.KNet_Sys_WareHouse Bll = new KNet.BLL.KNet_Sys_WareHouse();
                KNet.Model.KNet_Sys_WareHouse Model = Bll.GetModelBySuppNo(s_ID);
                s_WareHouseNo = Model.HouseNo;
            }
            catch
            { }

            s_Return += "<a href=\"javascript:window.close();\" onclick='GetReturn(\"" + s_ID + "\", \"" + base.Base_GetSupplierName(s_ID) + "\", \"" + this.KNetOddNumbers(s_ID) + "\", \"" + GetSuppNoAddress(s_ID) + "\", \"" + s_WareHouseNo + "\");'>" + base.Base_GetSupplierName(s_ID) + "</a>";
        }
        catch { }
        return s_Return;
    }
    protected void Ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.DataShows();
    }
}

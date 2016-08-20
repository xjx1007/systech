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
/// 对库存盘点单  进行审核,并处理  到  （仓库总账）
/// </summary>
public partial class Knet_Web_WaareHouse_pop_KNet_WareHouse_WareCheckCheckY : System.Web.UI.Page
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
            if (AM.CheckLogin("盘点单审核") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {

                if (Request.QueryString["WareCheckNo"] != null && Request.QueryString["WareCheckNo"] != "")
                {
                    this.DirectInNotxt.Text = Request.QueryString["WareCheckNo"].ToString().Trim();

                    if (Knet_Procure_OrdersList_Details_Shu(Request.QueryString["WareCheckNo"].ToString().Trim()) <= 0)
                    {
                        this.MyStatStr.Visible = true;
                        this.MyStatStr.Text = "此盘点单未添加有产品明细，不能进行审核操作！";
                        this.Button1.Enabled = false;

                    }
                }
                else
                {
                    Response.Write("<script>alert('非法参数！');window.close();</script>");
                    Response.End();
                }
            }
        }
    }




    /// <summary>
    /// 审核操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (AM.CheckLogin() == false)
        {
            Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
            Response.End();
        }
        else
        {
            int AA = int.Parse(this.DropDownList1.SelectedValue);
            string WareCheckNo = this.DirectInNotxt.Text.Trim();
            string WareHouseCheckStaffNo = AM.KNet_StaffNo;
            

      
            if (AA != -1)
            {
                if (AA == 1) //通过审核
                {
                    ////读取盘点单信息
                    //KNet.BLL.KNet_WareHouse_WareCheckList BLL2 = new KNet.BLL.KNet_WareHouse_WareCheckList();
                    //KNet.Model.KNet_WareHouse_WareCheckList model2 = BLL2.GetModelB(WareCheckNo);


                    //string HouseNo = model2.HouseNo;
 
                    ////读取盘点单 明细
                    //KNet.BLL.KNet_WareHouse_WareCheckList_Details bll = new KNet.BLL.KNet_WareHouse_WareCheckList_Details();
                    //DataSet ds = bll.GetList(" WareCheckNo='" + WareCheckNo + "' ");

                    //for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    //{
                    //    DataRowView mydrv = ds.Tables[0].DefaultView[i];

                    //    string WareCheckNoxxx = mydrv["WareCheckNo"].ToString(); //盘点单号
                    //    int WareCheckLossUp = int.Parse(mydrv["WareCheckLossUp"].ToString()); //类型   1盘正，2盘负
                    //    int WareCheckAmount =int.Parse(mydrv["WareCheckAmount"].ToString()); //盘差数量
                    //    string ProductsBarCode = mydrv["ProductsBarCode"].ToString(); //产品条形码
                    //    string OwnallPID =mydrv["OwnallPID"].ToString(); //总仓库产品ID

                    //    string Dosql=null;

                    //    if (WareCheckLossUp == 1)
                    //    {
                    //        Dosql = "update KNet_WareHouse_Ownall set WareHouseAmount=WareHouseAmount+" + WareCheckAmount + " where HouseNo='" + HouseNo + "' and ProductsBarCode='" + ProductsBarCode + "' and [ID]='" + OwnallPID + "' ";
                    //    }
                    //    else
                    //    {
                    //        if (WareCheckLossUp == 2)
                    //        {
                    //            Dosql = "update KNet_WareHouse_Ownall set WareHouseAmount=WareHouseAmount-" + WareCheckAmount + " where HouseNo='" + HouseNo + "' and ProductsBarCode='" + ProductsBarCode + "' and [ID]='" + OwnallPID + "'";
                    //        }
                    //    }

                    //    try
                    //    {
                    //        DbHelperSQL.ExecuteSql(Dosql);
                    //    }
                    //    catch { }
                    //}


                    //更新为已审核
                    string DoSql = "update KNet_WareHouse_WareCheckList  set  WareCheckCheckYN=" + AA + ",WareCheckCheckStaffNo ='" + WareHouseCheckStaffNo + "' where  WareCheckNo='" + WareCheckNo + "' ";
                    DbHelperSQL.ExecuteSql(DoSql);

                    AM.Add_Logs(" 库存盘点单  审核成功.盘点单：" + WareCheckNo + "");
                    Response.Write("<script>alert('库存盘点单审核成功，点 确定 返回！');window.opener.location.reload();window.close();</script>");
                    Response.End();
                }
                else
                {
                    Response.Write("<script>alert('库存盘点单没通过审核，点 确定 返回！');window.opener.location.reload();window.close();</script>");
                    Response.End();
                }
            }
        }
    }



    /// <summary>
    /// 获取出库 单明细数目 （Y）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu(string WareCheckNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as IDS  from KNet_WareHouse_WareCheckList_Details where WareCheckNo='" + WareCheckNo + "'";
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


}

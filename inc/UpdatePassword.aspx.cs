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
using System.IO;
using System.Runtime.Serialization.Json;

using KNet.DBUtility;
using KNet.Common;
using System.Net;


public partial class UpdatePassword : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {   
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();

            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '../Default.aspx';</script>");
                Response.End();
            }
            else
            {
                string s_Type = Request.QueryString["Type"] == null ? "" : Request.QueryString["Type"].ToString();

                if (AM.KNet_StaffName.ToUpper() == "ADMIN")
                {
                    this.Warehouse_Name.Text = "超级管理员:全部库";
                }
                else
                {
                    this.Warehouse_Name.Text = GetKNet_Sys_WareHouseName(AM.KNet_StaffNo);
                }
                this.StaffName.Text = AM.KNet_StaffName;
            }
        }
    }




    /// <summary>
    /// 获返仓库名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetKNet_Sys_WareHouseNameByHouseNo(string HouseNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,HouseNo,HouseName from KNet_Sys_WareHouse where HouseNo='" + HouseNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    return dr["HouseName"].ToString().Trim();
                }
                else
                {
                    return "";
                }
            }
        }
    }
    /// <summary>
    /// 获取员工的仓库列表
    /// </summary>
    /// <param name="StaffNo"></param>
    /// <returns></returns>
    protected string GetKNet_Sys_WareHouseName(string StaffNo)
    {
        string ListStr = "";
        using (DataSet ds = GetList("StaffNo='" + StaffNo + "'"))
        {
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                DataRowView mydrv = ds.Tables[0].DefaultView[i];
                if (i == 0)
                {
                    ListStr = ListStr + GetKNet_Sys_WareHouseNameByHouseNo(mydrv["HouseNo"].ToString());
                }
                else
                {
                    ListStr = ListStr + "<B>|</B>" + GetKNet_Sys_WareHouseNameByHouseNo(mydrv["HouseNo"].ToString());
                }
            }
        }
        if (ListStr == "")
        {
            return "<font color=\"gray\">未受权任何仓库</font>";
        }
        else
        {
            return ListStr;
        }
    }
    /// <summary>
    /// 获得受权仓库  数据列表
    /// </summary>
    protected DataSet GetList(string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select StaffNo,HouseNo ");
        strSql.Append(" FROM KNet_Sys_WareHouse_AuthList ");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        return DbHelperSQL.Query(strSql.ToString());
    }


    /// <summary>
    /// 由员工编号获取员工姓名
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Knet_Get_StaffName(string aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StaffNo,StaffName from KNet_Resource_Staff where StaffNo='" + aa + "'  or  StaffCard='" + aa + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    return dr["StaffName"].ToString().Trim();
                }
                else
                {
                    return "未知员工";
                }
            }
        }

    }

    /// <summary>
    /// 排序
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_DataRowBinding(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int id = e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = id.ToString();
        }
    }


    //确定修改密码
    protected void Button4_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (AM.KNet_Soft_WebTest == true) //演示版
        {
            Response.Write("<script>alert('抱歉!在线演示用,不能操作此处!');history.back(-1);</script>");
            Response.End();
        }


        if (AM.CheckLogin() == false)
        {
            Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '../Default.aspx';</script>");
            Response.End();
        }
        else
        {
            try
            {
                string NewWspA = KNetPage.KNetMD5(NewWsp1.Text.Trim().ToUpper());
                string NewWspB = KNetPage.KNetMD5(NewWsp2.Text.Trim().ToUpper());

                string StaffNos = AM.KNet_StaffNo;
                string StaffNames = AM.KNet_StaffName;
                if (NewWspA.CompareTo(NewWspB) == 0)
                {


                    this.Update_Knet_Staff_UpdatePasswordSelf(StaffNos, StaffNames, NewWspB);

                    Response.Write("<script language=javascript>alert('新的密码修改成功，请重新登陆系统！');parent.location.href = '../Default.aspx';</script>");
                    Response.End();
                }
                else
                {
                    Response.Write("<script language=javascript>alert('密码改修错误,未知错误！请重新登陆系统！');parent.location.href = '../Default.aspx';</script>");
                    Response.End();
                }
            }
            catch
            {
               // throw;
               Response.Write("<script language=javascript>alert('密码改修错误,未知错误！请重新登陆系统！');parent.location.href = '../Default.aspx';</script>");
               Response.End();
            }
        }
    }
    /// <summary>
    /// 自改密码
    /// </summary>
    /// <param name="P_Str_HouseNo"></param>
    /// <param name="P_Str_HouseName"></param>
    /// <param name="P_Str_HouseWps"></param>
    public void Update_Knet_Staff_UpdatePasswordSelf(string P_Str_StaffNo, string P_Str_StaffName, string P_Str_StaffPassword)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            SqlCommand myCmd = new SqlCommand("Proc_Update_Knet_Staff_Password", conn);
            myCmd.CommandType = CommandType.StoredProcedure;
            //添加参数
            SqlParameter StaffNo = new SqlParameter("@StaffNo", SqlDbType.NVarChar, 50);
            StaffNo.Value = P_Str_StaffNo;
            myCmd.Parameters.Add(StaffNo);
            //添加参数
            SqlParameter StaffName = new SqlParameter("@StaffName", SqlDbType.NVarChar, 60);
            StaffName.Value = P_Str_StaffName;
            myCmd.Parameters.Add(StaffName);
            //添加参数
            SqlParameter StaffPassword = new SqlParameter("@StaffPassword", SqlDbType.NVarChar, 60);
            StaffPassword.Value = P_Str_StaffPassword;
            myCmd.Parameters.Add(StaffPassword);
            //执行过程
            conn.Open();
            try
            {
                myCmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                myCmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
    }

    
    
}

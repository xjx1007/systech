using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
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
using System.Runtime.Serialization.Json;
using KNet.DBUtility;
using KNet.Common;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;
using iTextSharp.text.pdf;
using System.Linq;
using System.Web.Caching;
using System.Xml;
using System.Web.Script.Serialization;
using KNet.BLL;

/// <summary>
/// BasePage 的摘要说明
/// </summary>
public class BasePage : System.Web.UI.Page
{

    public string isModiy = System.Configuration.ConfigurationManager.AppSettings["ModifyWhere"].ToString();

    /// 弹出JavaScript小窗口
    /// </summary>
    /// <param name="js">窗口信息</param>
    public static void Alert(string message)
    {
        #region
        string js = @"<Script language='JavaScript'>alert('" + message + "');</Script>";
        HttpContext.Current.Response.Write(js);

        #endregion
    }

    public bool CheckYNProducts(string s_ProductsType)
    {
        bool b_Bool = true;
        AdminloginMess AM = new AdminloginMess();
        if (AM.ProductsType != "")
        {
            try
            {
                //成品

                KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
                string s_SonID = Bll_ProductsDetails.GetSonIDss(AM.ProductsType);
                s_SonID = s_SonID.Replace(",", "','");
                string s_Sql = "select * from PB_Basic_ProductsClass where PBP_ID='" + s_ProductsType + "'  and PBP_ID in ('" + AM.ProductsType + "','" + s_SonID + "')";
                this.BeginQuery(s_Sql);
                this.QueryForDataTable();
                if (Dtb_Result.Rows.Count <= 0)
                {
                    b_Bool = false;
                }

            }
            catch
            { }
        }

        return b_Bool;
    }
    /// <summary>
    /// 弹出JavaScript小窗口,并返回上一步
    /// </summary>
    /// <param name="message">窗口信息</param>
    public static void AlertAndGoBack(string message)
    {
        string js = @"<Script language='JavaScript'>
                    alert('" + message + "');history.go(-1);</Script>";
        HttpContext.Current.Response.Write(js);
    }

    /// <summary>
    /// 运行JS代码
    /// </summary>
    /// <param name="ScriptCode">脚本代码</param>
    public static void RunJs(string ScriptCode)
    {
        #region
        string js = @"<Script language='JavaScript'>
                    " + ScriptCode + ";</Script>";
        Alert(js);
        HttpContext.Current.Response.Write(js);
        #endregion
    }

    /// <summary>
    /// 弹出消息框并且转向到新的URL
    /// </summary>
    /// <param name="message">消息内容</param>
    /// <param name="toURL">连接地址</param>
    public static void AlertAndRedirect(string message, string toURL)
    {
        #region
        string js = "<script language=javascript>alert('{0}');window.location.replace('{1}')</script>";
        HttpContext.Current.Response.Write(string.Format(js, message, toURL));
        #endregion
    }

    /// <summary>
    /// 弹出消息框并且转向到新的URL
    /// </summary>
    /// <param name="message">消息内容</param>
    /// <param name="toURL">连接地址</param>
    public static void AlertAndClose(string message)
    {
        #region
        string js = "<script language=javascript>alert('{0}');window.close();</script>";
        HttpContext.Current.Response.Write(string.Format(js, message));
        #endregion
    }
    /// <summary>
    /// 回到历史页面
    /// </summary>
    /// <param name="value">-1/1</param>
    public static void GoHistory(int value)
    {
        #region
        string js = @"<Script language='JavaScript'>
                    history.go({0});  
                  </Script>";
        HttpContext.Current.Response.Write(string.Format(js, value));
        #endregion
    }

    /// <summary>
    /// 关闭当前窗口
    /// </summary>
    public static void CloseWindow()
    {
        #region
        string js = @"<Script language='JavaScript'>
                    parent.opener=null;window.close();  
                  </Script>";
        HttpContext.Current.Response.Write(js);
        HttpContext.Current.Response.End();
        #endregion
    }

    /// <summary>
    /// 关闭当前窗口并且返回值
    /// </summary>
    public static void CloseWindowReturnValues(string value)
    {
        #region

        System.Text.StringBuilder Str = new System.Text.StringBuilder();
        Str.Append("<Script language='JavaScript'type=\"text/javascript\">");
        Str.Append("var str='" + value + "';");
        Str.Append("top.returnValue=str;");
        Str.Append("top.close();</Script>");

        HttpContext.Current.Response.Write(Str.ToString());
        HttpContext.Current.Response.End();
        #endregion
    }


    /// <summary>
    /// 刷新父窗口
    /// </summary>
    public static void RefreshParent(string url)
    {
        #region
        string js = @"<Script language='JavaScript'>
                    window.opener.location.href='" + url + "';window.close();</Script>";
        HttpContext.Current.Response.Write(js);
        #endregion
    }


    /// <summary>
    /// 刷新打开窗口
    /// </summary>
    public static void RefreshOpener()
    {
        #region
        string js = @"<Script language='JavaScript'>
                    opener.location.reload();
                  </Script>";
        HttpContext.Current.Response.Write(js);
        #endregion
    }


    /// <summary>
    /// 打开指定大小的新窗体
    /// </summary>
    /// <param name="url">地址</param>
    /// <param name="width">宽</param>
    /// <param name="heigth">高</param>
    /// <param name="top">头位置</param>
    /// <param name="left">左位置</param>
    public static void OpenWebFormSize(string url, int width, int heigth, int top, int left)
    {
        #region
        string js = @"<Script language='JavaScript'>window.open('" + url + @"','','height=" + heigth + ",width=" + width + ",top=" + top + ",left=" + left + ",location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');</Script>";

        HttpContext.Current.Response.Write(js);
        #endregion
    }


    /// <summary>
    /// 转向Url制定的页面
    /// </summary>
    /// <param name="url">连接地址</param>
    public static void JavaScriptLocationHref(string url)
    {
        #region
        string js = @"<Script language='JavaScript'>
                    window.location.replace('{0}');
                  </Script>";
        js = string.Format(js, url);
        HttpContext.Current.Response.Write(js);
        #endregion
    }

    /// <summary>
    /// 打开指定大小位置的模式对话框
    /// </summary>
    /// <param name="webFormUrl">连接地址</param>
    /// <param name="width">宽</param>
    /// <param name="height">高</param>
    /// <param name="top">距离上位置</param>
    /// <param name="left">距离左位置</param>
    public static void ShowModalDialogWindow(string webFormUrl, int width, int height, int top, int left)
    {
        #region
        string features = "dialogWidth:" + width.ToString() + "px"
            + ";dialogHeight:" + height.ToString() + "px"
            + ";dialogLeft:" + left.ToString() + "px"
            + ";dialogTop:" + top.ToString() + "px"
            + ";center:yes;help=no;resizable:no;status:no;scroll=yes";
        ShowModalDialogWindow(webFormUrl, features);
        #endregion
    }

    public static void ShowModalDialogWindow(string webFormUrl, string features)
    {
        string js = ShowModalDialogJavascript(webFormUrl, features);
        HttpContext.Current.Response.Write(js);
    }

    public static string ShowModalDialogJavascript(string webFormUrl, string features)
    {
        #region
        string js = @"<script language=javascript>							
							showModalDialog('" + webFormUrl + "','','" + features + "');</script>";
        return js;
        #endregion
    }

    #region 以下函数在页面上引用AJAX组件后,调用的启动脚本
    /// <summary>
    /// Ajax启动脚本 For 引用AJAX组件的页
    /// AjaxAlert:弹出对话框
    /// </summary>
    /// <param name="page">一般是this</param>
    /// <param name="msg">对话框提示串</param>
    public static void AjaxAlert(System.Web.UI.Page page, string msg)
    {
        page.ClientScript.RegisterStartupScript(page.GetType(), "ajaxjs", string.Format("alert('{0}！')", msg), true);
    }

    /// <summary>
    /// Ajax启动脚本 For 引用AJAX组件的页
    /// 弹出对话框并跳转到URL页
    /// </summary>
    /// <param name="page">一般是this</param>
    /// <param name="msg">对话框提示串</param>
    /// <param name="url">跳往的地址</param>
    public static void AjaxAlertAndLocationHref(System.Web.UI.Page page, string msg, string url)
    {
        page.ClientScript.RegisterStartupScript(page.GetType(), "ajaxjs", string.Format("alert('{0}！');location.href='{1}';", msg, url), true);

    }
    /// <summary>
    /// Ajax启动脚本 For 引用AJAX组件的页
    /// JS语句
    /// </summary>
    /// <param name="page">一般是this</param>
    /// <param name="js">如alert('test');</param>
    public static void AjaxRunJs(System.Web.UI.Page page, string js)
    {
        page.ClientScript.RegisterStartupScript(page.GetType(), "ajaxjs", string.Format("{0}", js), true);
    }

    /// <summary>
    /// Ajax启动脚本 For 引用AJAX组件的页
    /// JS语句
    /// </summary>
    /// <param name="page">一般是this</param>
    /// <param name="js">如alert('test');</param>
    public static void AjaxEndRunJs(System.Web.UI.Page page, string js)
    {
        page.ClientScript.RegisterClientScriptBlock(page.GetType(), "ajaxjs", string.Format("{0}", js), true);
    }


    /// <summary>
    /// Ajax启动脚本 For 引用AJAX组件的页
    /// 转向到新的URL
    /// </summary>
    /// <param name="page">一般是this</param>
    /// <param name="toURL">连接地址</param>
    public static void AjaxRedirect(System.Web.UI.Page page, string toURL)
    {
        #region
        page.ClientScript.RegisterStartupScript(page.GetType(), "ajaxjs", string.Format("window.location.replace('{0}');", toURL), true);
        #endregion
    }

    /// <summary>
    ///  Ajax启动脚本 For 引用AJAX组件的页
    /// 显示模态窗口
    /// </summary>
    /// <param name="page">一般是this</param>
    /// <param name="webFormUrl">弹出的页面地址</param>
    /// <param name="width">弹出页面的宽度</param>
    /// <param name="height">弹出页面的高度</param>
    public static void AjaxShowModalDialogWindow(System.Web.UI.Page page, string webFormUrl, int width, int height)
    {
        #region

        string CommandStr = "window.showModalDialog('{0}','tempdialog','dialogWidth:{1}px;dialogHeight:{2}px;center:yes;help=no;resizable:no;status:no;scroll=no')";
        CommandStr = string.Format(CommandStr, webFormUrl, width, height);
        page.ClientScript.RegisterStartupScript(page.GetType(), "ajaxjs", CommandStr, true);
        #endregion
    }

    #endregion


    /// <summary>
    /// 发生错误页面
    /// </summary>
    /// <param name="errStr">错误代码</param>
    public static void ToError(System.Web.UI.Page page, string errStr)
    {
        page.Response.Redirect(string.Format("Error.aspx?ErrStr={0}", errStr));
    }

    public static void BindDateCalendar(System.Web.UI.WebControls.TextBox txtDate)
    {
        txtDate.Attributes.Add("onclick", "setday(this)");
    }

    /// <summary>
    /// 设定Checkbox控制TextBox事件,
    /// </summary>
    /// <param name="ChkObj">Checkbox控件</param>
    /// <param name="HtmlObjId">控件TextBox ID,多个ID以,号分开</param>
    public static void SetChkAttrib(System.Web.UI.WebControls.CheckBox ChkObj, string HtmlObjId)
    {
        #region
        string[] StrId = HtmlObjId.Split(',');
        string JsCode = "";
        for (int i = 0; i < StrId.Length; i++)
        {
            JsCode = JsCode + string.Format("EnableCtrl(this,'{0}');", StrId[i]);
        }
        ChkObj.Attributes.Add("onclick", JsCode);
        #endregion
    }

    //刷新父窗口
    public void ReflashWindows(Type cstype)
    {
        StringBuilder s = new StringBuilder();
        s.Append("<script language=javascript>" + "\n");
        s.Append("window.opener.refresh();" + "\n");
        s.Append("window.focus();" + "\n");
        s.Append("window.opener=null;" + "\n");
        s.Append("window.close();" + "\n");
        s.Append("</script>");
        ClientScriptManager cs = Page.ClientScript;
        string csname = "ltype";
        if (!cs.IsStartupScriptRegistered(cstype, csname))
            cs.RegisterStartupScript(cstype, csname, s.ToString());
    }

    public SqlConnection GetConn()
    {
        SqlConnection conn = DBClass.GetConnection("KNetERP");
        return conn;
    }

    private string s_QuerySql1;
    public virtual string s_QuerySql
    {
        get { return s_QuerySql1; }
        set { s_QuerySql1 = value; }
    }

    private DataTable Dtb_Result1 = new DataTable();
    public virtual DataTable Dtb_Result
    {
        get { return Dtb_Result1; }
        set { Dtb_Result1 = value; }
    }

    private DataSet Dts_Result1 = new DataSet();
    public virtual DataSet Dts_Result
    {
        get { return Dts_Result1; }
        set { Dts_Result1 = value; }
    }
    public virtual void BeginQuery(String Str)
    {
        s_QuerySql1 = Str;
    }
    public virtual string GetQuerySql()
    {
        return s_QuerySql1;
    }
    public virtual DataTable QueryForDataTable()
    {
        SqlConnection conn = GetConn();
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(s_QuerySql1, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            Dts_Result1 = new DataSet();
            adapter.Fill(Dts_Result1);
            this.Dtb_Result1 = Dts_Result1.Tables[0];
        }
        catch
        {
            Dtb_Result1 = null;
        }
        finally
        {
            s_QuerySql = "";
            conn.Close();
            conn.Dispose();
        }
        return Dtb_Result1;
    }
    public virtual string QueryForReturn()
    {
        SqlConnection conn = GetConn();
        string s_Return = "";
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(s_QuerySql1, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            Dts_Result1 = new DataSet();
            adapter.Fill(Dts_Result1);
            this.Dtb_Result1 = Dts_Result1.Tables[0];
            if (this.Dtb_Result1.Rows.Count > 0)
            {
                s_Return = Dtb_Result1.Rows[0][0].ToString();
            }
        }
        catch (Exception ex)
        {
            s_Return = "";
        }
        finally
        {
            s_QuerySql = "";
            conn.Close();
            conn.Dispose();
        }
        return s_Return;
    }
    public virtual DataSet QueryForDataSet()
    {
        SqlConnection conn = GetConn();
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(s_QuerySql1, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            Dts_Result1 = new DataSet();
            adapter.Fill(Dts_Result1);
        }
        catch
        {
            Dts_Result1 = null;
        }
        finally
        {
            s_QuerySql1 = "";
            conn.Close();
            conn.Dispose();
        }
        return Dts_Result1;
    }


    #region 返回单号情况

    /// <summary>
    /// 返回当前的  单号 （唯一性，如 2009121402）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string KNetOddNumbers(string s_SuppNo)
    {
        try
        {
            using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
            {
                conn.Open();
                string s_Code = "PO";
                this.BeginQuery("select SuppCode from Knet_Procure_Suppliers Where SuppNo='" + s_SuppNo + "' ");
                DataTable Dtb_Table = this.QueryForDataTable();
                if (Dtb_Table.Rows.Count > 0)
                {
                    s_Code += Dtb_Table.Rows[0][0].ToString();
                }
                string Dostr = "select Max(OrderNo) as AA  from  Knet_Procure_OrdersList  where year(SystemDatetimes)=year(GetDate()) and OrderNo like '" + s_Code + "1%' ";
                SqlCommand cmd = new SqlCommand(Dostr, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["AA"].ToString() == "")
                    {
                        return s_Code + DateTime.Today.ToString("yyyyMMdd").Substring(2, 2) + "0001";
                    }
                    else
                    {
                        return s_Code + DateTime.Today.ToString("yyyyMMdd").Substring(2, 2) + KNus003(int.Parse(dr["AA"].ToString().Substring(s_Code.Length + 2, 4)) + 1);
                    }
                }
                else
                {
                    return s_Code + DateTime.Today.ToString("yyyyMMdd").Substring(2, 2) + "0001";
                }
            }
        }
        catch
        {
            return "";
        }

    }


    /// <summary>
    /// 返回当前的  单号 （唯一性，如 2009121402）
    /// </summary>
    /// <param name="ss"></param>
    /// <returns></returns>
    protected string KNus003(int ss)
    {
        if (ss.ToString().Length == 1)
        {
            return "000" + ss.ToString();
        }
        else if (ss.ToString().Length == 2)
        {
            return "00" + ss.ToString();
        }
        else if (ss.ToString().Length == 3)
        {
            return "0" + ss.ToString();
        }
        else if (ss.ToString().Length == 4)
        {
            return ss.ToString();
        }
        else
        {
            return ss.ToString();
        }
    }
    #endregion


    #region 得到用户名

    /// <summary>
    /// 获取员工名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    public string Base_GetUserName(String s_ID)
    {

        String s_Name = "";
        this.BeginQuery("Select * From KNet_Resource_Staff Where StaffNo='" + s_ID + "'");
        this.QueryForDataTable();
        DataTable Dtb_Re = Dtb_Result;
        if (Dtb_Re.Rows.Count > 0)
        {
            s_Name = Dtb_Re.Rows[0]["StaffName"].ToString();
        }
        return s_Name;
    }
    #endregion



    /// <summary>
    /// 获取员工部门
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    public string Base_GetUserDept(String s_ID)
    {

        String s_Name = "";
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            this.BeginQuery("Select * From KNet_Resource_Staff Where StaffNo='" + s_ID + "'");
            DataTable Dtb_Table = this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                s_Name = Base_GeDept(Dtb_Table.Rows[0]["StaffDepart"].ToString());
            }


        }
        return s_Name;
    }


    /// <summary>
    /// 获取员工职位
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    public string Base_GetUserPosition(String s_ID)
    {

        String s_Name = "";
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            this.BeginQuery("Select * From KNet_Resource_Staff Where StaffNo='" + s_ID + "'");
            DataTable Dtb_Table = this.QueryForDataTable();
            if (Dtb_Table.Rows.Count > 0)
            {
                s_Name = Base_GetBasicCodeName("105", Dtb_Table.Rows[0]["Position"].ToString());
            }


        }
        return s_Name;
    }

    /// <summary>
    /// 获取员工名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    public string Base_GetUserNames(String s_Value)
    {

        string[] s_ID = s_Value.Split(',');
        StringBuilder s_Name = new StringBuilder();
        if (s_ID.Length > 0)
        {
            for (int i = 0; i < s_ID.Length; i++)
            {
                s_Name.Append(Base_GetUserName(s_ID[i]) + ",");
            }
        }
        return s_Name.ToString().Substring(0, s_Name.Length - 1);
    }

    /// <summary>
    /// 获取供应商名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Base_GetSupplierName(string aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,SuppNo,SuppName from Knet_Procure_Suppliers where SuppNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["SuppName"].ToString();
            }
            else
            {
                return "";
            }
        }
    }

    protected string Base_GetShortSupplierName(string aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,SuppNo,isNUll(KPS_SName,'') SuppName from Knet_Procure_Suppliers where SuppNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["SuppName"].ToString();
            }
            else
            {
                return "";
            }
        }
    }

    /// <summary>
    /// 获取或者客户
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Base_GetSupplierOrCustomerName(string aa)
    {
        string s_Return = "";
        try
        {
            s_Return = Base_GetSupplierName(aa);
            if (s_Return == "")
            {
                s_Return = Base_GetCustomerName(aa);
            }

        }
        catch
        { }
        return s_Return;
    }

    /// <summary>
    /// 获取供应商：Link
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Base_GetSupplierName_Link(string aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,SuppNo,SuppName,isNUll(KPS_SName,'') KSP_SName from Knet_Procure_Suppliers where SuppNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string s_KSP_SName = dr["KSP_SName"].ToString() == "" ? dr["SuppName"].ToString() : dr["KSP_SName"].ToString();
                return "<a href=\"/Web/Supp/Knet_Procure_Suppliers_View.aspx?ID=" + dr["ID"].ToString().Trim() + "\"  target=\"_blank\">" + s_KSP_SName + "</a>";
            }
            else
            {
                return "";
            }
        }
    }

    /// <summary>
    /// 返回单位名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Base_GetUnitsName(string aa)
    {
        //if (aa!="")
        //{
            using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
            {
                conn.Open();
                string Dostr = "select ID,UnitsNo,UnitsName from KNet_Sys_Units where UnitsNo='" + aa + "'";
                SqlCommand cmd = new SqlCommand(Dostr, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return dr["UnitsName"].ToString().Trim();
                }
                else
                {
                    return "";
                }
            }
       // }
        ////else
        ////{
        //    using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        //    {
        //        conn.Open();
        //        string Dostr = "select KSP_BigUnits from KNet_Sys_Products where KSP_COde='" + bb + "'";
        //        SqlCommand cmd = new SqlCommand(Dostr, conn);
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.Read())
        //        {
        //            return dr["KSP_BigUnits"].ToString().Substring(dr["KSP_BigUnits"].ToString().LastIndexOf("/") + 1);
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //}
            
    }
    /// <summary>
    /// 获取大单位
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Base_GetBigUnitsName(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select KSP_BigUnits from KNet_Sys_Products where KSP_COde='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["KSP_BigUnits"].ToString().Substring(dr["KSP_BigUnits"].ToString().LastIndexOf("/") + 1);
            }
            else
            {
                return "";
            }
        }
    }

    /// <summary>
    /// 返回版本号
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Base_GetProductsEdition(object aa)
    {
        string s_Return = "";
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ProductsEdition,ProductsPattern from KNet_Sys_Products where ProductsBarCode='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                s_Return = dr["ProductsEdition"].ToString().Trim() == "" ? dr["ProductsPattern"].ToString().Trim() : dr["ProductsEdition"].ToString().Trim();
                return s_Return;
            }
            else
            {
                return "--";
            }
        }
    }

    public string Base_GetProductsCode(string s_ID)
    {
        string s_Return = "";
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select KSP_Code,ProductsBarCode from KNet_Sys_Products where ProductsBarCode='" + s_ID + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                s_Return = dr["KSP_Code"].ToString().Trim() == "" ? dr["ProductsBarCode"].ToString().Trim() : dr["KSP_Code"].ToString().Trim();
                return s_Return;
            }
            else
            {
                return "--";
            }
        }
    }

    public string Base_GetProductsBZNumber(string s_ID)
    {
        string s_Return = "";
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select  KSP_BZNumber from KNet_Sys_Products where ProductsBarCode='" + s_ID + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                s_Return = dr["KSP_BZNumber"].ToString();
                return s_Return;
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 根据料号查询大单位
    /// </summary>
    /// <param name="KSP_COde"></param>
    /// <returns></returns>
    public string Base_GetBigUnits(string KSP_COde)
    {
        string s_Return = "";
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select  KSP_BigUnits from KNet_Sys_Products where KSP_COde='" + KSP_COde + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                s_Return = dr["KSP_BigUnits"].ToString();
                return s_Return;
            }
            else
            {
                return "--";
            }
        }
    }
    protected string Base_GetProductsEdition_Link(object aa)
    {
        string s_Return = "", s_Details = "";
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ProductsBarCode,ProductsEdition,ProductsPattern,KSP_Code,ProductsName from KNet_Sys_Products where ProductsBarCode='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string s_ProductsBarCode = dr["ProductsBarCode"].ToString().Trim() == "" ? dr["ProductsBarCode"].ToString().Trim() : dr["ProductsBarCode"].ToString().Trim();
                string s_Code = dr["KSP_Code"].ToString().Trim() == "" ? dr["KSP_Code"].ToString().Trim() : dr["KSP_Code"].ToString().Trim();
                string s_ProductsName = dr["ProductsName"].ToString().Trim() == "" ? dr["ProductsName"].ToString().Trim() : dr["ProductsName"].ToString().Trim();

                s_Details = dr["ProductsEdition"].ToString().Trim() == "" ? dr["ProductsPattern"].ToString().Trim() : dr["ProductsEdition"].ToString().Trim();
                s_Return = "<a href=\"/Web/Products/KnetProductsSetting_Details.aspx?BarCode=" + aa + "\"  target=\"_blank\">" + s_Details + "</a>";

                /*
                s_Return = "<a href=\"/Web/Products/KnetProductsSetting_Details.aspx?BarCode=" + s_ProductsBarCode + "\"  target=\"_self\" onMouseOver=\"fnDropDown1(this,'" + s_ProductsBarCode + "_sub');\" onMouseOut=\"fnHideDrop('" + s_ProductsBarCode + "_sub');\" >" + s_Details + "</a>";
                s_Return += "<div class=\"Drop_Customer\" id=\"" + s_ProductsBarCode + "_sub\" onMouseOut=\"fnHideDrop('" + s_ProductsBarCode + "_sub')\" onMouseOver=\"fnShowDrop('" + s_ProductsBarCode + "_sub')\">\n";
                s_Return += "<table width=\"80%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">\n";

                s_Return += "<tr><td >料号：" + s_Code;
                s_Return += "</td></tr>\n";
                s_Return += "<tr><td >产品名称：" + s_ProductsName;
                s_Return += "</td></tr>\n";
                s_Return += "</table>\n</div>\n";
                 */
                return s_Return;
            }
            else
            {
                return "--";
            }
        }
    }
    public string base_GetProductsDemoState(string s_ID)
    {
        string s_Return = "";
        s_ID = s_ID == null ? "" : s_ID;
        if (s_ID == "")
        {
            s_Return = "是";
        }
        else
        {
            KNet.BLL.Pb_Products_Sample Bll = new KNet.BLL.Pb_Products_Sample();
            KNet.Model.Pb_Products_Sample Model = Bll.GetModel(s_ID);
            if (Model == null)
            {
                s_Return = "是";
            }
            else if (Model.PPS_Dept == "13")//打烊结束
            {
                s_Return = "是";
            }
            else
            {
                s_Return = Base_GetBasicCodeName("124", Model.PPS_Dept);
            }
        }

        return s_Return;
    }
    /// <summary>
    /// 返回版本号
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Base_GetProductsPattern(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ProductsPattern from KNet_Sys_Products where ProductsBarCode='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["ProductsPattern"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 返回版本号
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Base_GetProductsUnits(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ProductsUnits from KNet_Sys_Products where ProductsBarCode='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["ProductsUnits"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 获取公司或部门
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Base_GeDept(string aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,StrucValue,StrucName from KNet_Resource_OrganizationalStructure where StrucValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["StrucName"].ToString();
            }
            else
            {
                return "--";
            }
        }
    }


    /// <summary>
    /// 获取结算方式
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Base_GetCheckMethod(string aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,CheckNo,CheckName from KNet_Sys_CheckMethod where CheckNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["CheckName"].ToString();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 得到编码列表
    /// </summary>
    /// <param name="s_Code"></param>
    /// <returns></returns>
    protected DataSet Base_GetBasicCode(string s_Code)
    {
        try
        {
            this.BeginQuery("Select * From PB_Basic_Code Where PBC_Del=0 and  PBC_ID='" + s_Code + "' ");
            DataSet Dts_Table = this.QueryForDataSet();
            return Dts_Table;

        }
        catch (System.Exception ex)
        {
            return null;
        }
    }
    /// <summary>
    ///  得到基础编码：ID：101:材料类型，102:常规，103:应急，104:付款方式,105 职位
    /// </summary>
    /// <param name="s_ID"></param>
    /// <param name="s_Code"></param>
    /// <returns></returns>
    public String Base_GetBasicCodeName(string s_ID, string s_Code)
    {
        try
        {
            this.BeginQuery("Select PBC_Name From PB_Basic_Code where PBC_ID='" + s_ID + "' and PBC_Code='" + s_Code + "' ");
            this.QueryForDataTable();
            return this.Dtb_Result.Rows[0][0].ToString();
        }
        catch (System.Exception ex)
        {
            return "";
        }
    }


    /// <summary>
    ///  得到基础菜单
    /// </summary>
    /// <param name="s_ID"></param>
    /// <param name="s_Code"></param>
    /// <returns></returns>
    public String Base_GetMenuName(string s_ID)
    {
        try
        {
            this.BeginQuery("Select PBM_Name From PB_Basic_Menu where PBM_ID='" + s_ID + "' ");
            this.QueryForDataTable();
            return this.Dtb_Result.Rows[0][0].ToString();
        }
        catch (System.Exception ex)
        {
            return "";
        }
    }
    public String Base_GetBasicCodeName(string s_ID, string s_Code, string s_linkUrl)
    {
        try
        {
            this.BeginQuery("Select PBC_Name From PB_Basic_Code where PBC_ID='" + s_ID + "' and PBC_Code='" + s_Code + "' ");
            this.QueryForDataTable();
            return "<a href=\"" + s_linkUrl + "\">" + this.Dtb_Result.Rows[0][0].ToString() + "</a>";
        }
        catch (System.Exception ex)
        {
            return "";
        }
    }


    /// <summary>
    /// 绑定分类(1渠道信息，2客户类型,3客户行业，4客户来源）
    /// </summary>
    /// <param name="DDL"></param>
    /// <param name="ClientKings"></param>
    public void Base_DropKClaaBind(DropDownList DDL, int ClientKings, string s_where, string StrText)
    {
        KNet.BLL.KNet_Sales_ClientAppseting bll = new KNet.BLL.KNet_Sales_ClientAppseting();
        DataSet ds = new DataSet();
        if (ClientKings == 1)
        {
            this.BeginQuery("Select ClientValue, Space((len(Client_Code)-1)*2)+'|--'+Client_Name+'('+Client_Code+')' as Name_Code from KNet_Sales_ClientAppseting Where ClientKings=" + ClientKings + "  order by substring(Client_Code,1,1),ClientPai");
            this.QueryForDataSet();
            ds = this.Dts_Result;
        }
        else
        {
            ds = bll.GetList(" ClientKings=" + ClientKings + "  " + s_where + "  order by ClientPai ");
        }
        DDL.DataSource = ds;
        DDL.DataTextField = "Name_Code";
        DDL.DataValueField = "ClientValue";
        DDL.DataBind();
        ListItem item = new ListItem("--请选择--", ""); //默认值
        DDL.Items.Insert(0, item);
        DDL.SelectedValue = StrText;
        if (ClientKings == 1)
        {
            for (int i = 0; i < DDL.Items.Count; i++)
            {
                DDL.Items[i].Text = DDL.Items[i].Text.Replace(" ", "　");
            }
        }
    }

    public void Base_DropDutyPerson(DropDownList DDL)
    {
        try
        {
            KNet.BLL.KNet_Resource_Staff Bll = new KNet.BLL.KNet_Resource_Staff();
            DataSet Dts_Table = Bll.GetList(" StaffNo<>'admin' Order By StaffDepart ");
            DDL.DataSource = Dts_Table;
            DDL.DataTextField = "StaffName";
            DDL.DataValueField = "StaffNo";
            DDL.DataBind();
            ListItem item = new ListItem("请选择责任人", ""); //默认值
            DDL.Items.Insert(0, item);
            AdminloginMess AM = new AdminloginMess();
            DDL.SelectedValue = AM.KNet_StaffNo;
        }
        catch (Exception ex)
        {

        }
    }


    public void Base_DropSupp(DropDownList DDL)
    {
        try
        {
            KNet.BLL.Knet_Procure_Suppliers Bll_Suppliers = new KNet.BLL.Knet_Procure_Suppliers();
            DataSet Dts_Table = Bll_Suppliers.GetList(" KPS_Del=0 and KPS_Type not in ('128860697896406251','128860697896406250')  Order by KPS_Level desc,SuppName ");
            DDL.DataSource = Dts_Table;
            DDL.DataTextField = "KPS_SName";
            DDL.DataValueField = "SuppNo";
            DDL.DataBind();
            ListItem item = new ListItem("请选择供应商", ""); //默认值
            DDL.Items.Insert(0, item);
        }
        catch (Exception ex)
        {

        }
    }



    public void Base_DropSupp(DropDownList DDL, string s_Sql)
    {
        try
        {
            KNet.BLL.Knet_Procure_Suppliers Bll_Suppliers = new KNet.BLL.Knet_Procure_Suppliers();
            DataSet Dts_Table = Bll_Suppliers.GetList(" KPS_Del=0 and KPS_Type not in ('128860697896406251','128860697896406250') " + s_Sql + "  Order by KPS_Level desc,SuppName ");
            DDL.DataSource = Dts_Table;
            DDL.DataTextField = "KPS_SName";
            DDL.DataValueField = "SuppNo";
            DDL.DataBind();
            ListItem item = new ListItem("请选择供应商", ""); //默认值
            DDL.Items.Insert(0, item);
        }
        catch (Exception ex)
        {

        }
    }


    public void Base_DropDutyPersonByFid(DropDownList DDL, string s_FID)
    {
        try
        {
            KNet.BLL.KNet_Resource_Staff Bll = new KNet.BLL.KNet_Resource_Staff();

            string s_SonID = Bll.GetSonIDs(s_FID);
            s_SonID = s_SonID.Replace(",", "','");
            string SqlWhere = " and StaffNo in ('" + s_SonID + "') ";
            DataSet Dts_Table = Bll.GetList(" StaffNo<>'admin' " + SqlWhere + " Order By StaffDepart ");
            DDL.DataSource = Dts_Table;
            DDL.DataTextField = "StaffName";
            DDL.DataValueField = "StaffNo";
            DDL.DataBind();
            ListItem item = new ListItem("请选择责任人", ""); //默认值
            DDL.Items.Insert(0, item);
            AdminloginMess AM = new AdminloginMess();
            DDL.SelectedValue = AM.KNet_StaffNo;
        }
        catch (Exception ex)
        {

        }
    }
    public void Base_DropDutyPerson(DropDownList DDL, bool b_Bool)
    {
        try
        {
            KNet.BLL.KNet_Resource_Staff Bll = new KNet.BLL.KNet_Resource_Staff();
            DataSet Dts_Table = Bll.GetList(" StaffNo<>'admin' Order By StaffDepart ");
            DDL.DataSource = Dts_Table;
            DDL.DataTextField = "StaffName";
            DDL.DataValueField = "StaffNo";
            DDL.DataBind();
            ListItem item = new ListItem("请选择责任人", ""); //默认值
            DDL.Items.Insert(0, item);
            if (b_Bool)
            {
                AdminloginMess AM = new AdminloginMess();
                DDL.SelectedValue = AM.KNet_StaffNo;
            }
        }
        catch (Exception ex)
        {

        }
    }

    public void Base_GetFHDetails(DropDownList DDL, string s_Sql)
    {
        try
        {
            KNet.BLL.Xs_Customer_FhInfo Bll = new KNet.BLL.Xs_Customer_FhInfo();
            DataSet Dts_Table = Bll.GetList(s_Sql);
            DDL.DataSource = Dts_Table;
            DDL.DataTextField = "XCF_Details";
            DDL.DataValueField = "XCF_ID";
            DDL.DataBind();
            //ListItem item = new ListItem("无要求", ""); //默认值
            // DDL.Items.Insert(0, item);
        }
        catch (Exception ex)
        {

        }
    }

    public void Base_DropDutyPerson(DropDownList DDL, string s_Sql)
    {
        try
        {
            KNet.BLL.KNet_Resource_Staff Bll = new KNet.BLL.KNet_Resource_Staff();
            DataSet Dts_Table = Bll.GetList(" StaffNo<>'admin'  " + s_Sql + " Order By StaffDepart,StaffName ");
            DDL.DataSource = Dts_Table;
            DDL.DataTextField = "StaffName";
            DDL.DataValueField = "StaffNo";
            DDL.DataBind();
            ListItem item = new ListItem("请选择责任人", ""); //默认值
            DDL.Items.Insert(0, item);
            AdminloginMess AM = new AdminloginMess();
            DDL.SelectedValue = AM.KNet_StaffNo;
        }
        catch
        {

        }
    }
    /// <summary>
    /// 绑定省
    /// </summary>
    public void Base_DropSheng(DropDownList DDL)
    {

        DataSet ds = KNet.Common.KNet_Static_Province.GetProvinceInfo(" and FaterID is null");
        string code, name;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ID = ds.Tables[0].Rows[i]["ID"].ToString();
            name = ds.Tables[0].Rows[i]["name"].ToString().Replace(" ", "　");
            DDL.Items.Add(new ListItem(name, ID));
            DataSet ds_Child = KNet.Common.KNet_Static_Province.GetProvinceInfo("and FaterID=" + ID);
            for (int j = 0; j < ds_Child.Tables[0].Rows.Count; j++)
            {
                ID = ds_Child.Tables[0].Rows[j]["ID"].ToString();
                name = ds_Child.Tables[0].Rows[j]["name"].ToString().Replace(" ", "　");
                DDL.Items.Add(new ListItem(name, ID));
            }
        }
        ListItem item = new ListItem("--请选择省份--", ""); //默认值
        DDL.Items.Insert(0, item);
    }
    ///

    /// <summary>
    /// 绑定市
    /// </summary>
    public void Base_DropCity(DropDownList DDL, string s_Sheng)
    {
        try
        {
            DDL.Items.Clear();
            if (s_Sheng != "")
            {
                this.BeginQuery("Select * from KNet_Static_City where Provinceid = '" + s_Sheng + "' ");
                this.QueryForDataTable();
                DDL.DataSource = this.Dtb_Result;
                DDL.DataValueField = "Code";
                DDL.DataTextField = "Name";
                DDL.DataBind();
            }
            ListItem item = new ListItem("--请选择市--", ""); //默认值
            DDL.Items.Insert(0, item);
        }
        catch
        { }
    }

    /// <summary>
    /// 绑定区
    /// </summary>
    public void Base_DropQu(DropDownList DDL, string s_Sheng)
    {
        DDL.Items.Clear();
        if (s_Sheng != "")
        {
            this.BeginQuery("Select distinct District,District from Pb_Basic_POST where City = '" + s_Sheng + "' order by District");
            this.QueryForDataTable();
            DDL.DataSource = this.Dtb_Result;
            DDL.DataValueField = "District";
            DDL.DataTextField = "District";
            DDL.DataBind();
        }
        ListItem item = new ListItem("--请选择区--", ""); //默认值
        DDL.Items.Insert(0, item);
    }
    /// <summary>
    /// 绑定街道
    /// </summary>
    public void Base_DropJie(DropDownList DDL, string s_Sheng)
    {
        DDL.Items.Clear();
        if (s_Sheng != "")
        {
            this.BeginQuery("Select distinct Address,Address from Pb_Basic_POST where District = '" + s_Sheng + "' order by Address ");
            this.QueryForDataTable();
            DDL.DataSource = this.Dtb_Result;
            DDL.DataValueField = "Address";
            DDL.DataTextField = "Address";
            DDL.DataBind();
        }
        ListItem item = new ListItem("--请选择街道--", ""); //默认值
        DDL.Items.Insert(0, item);
    }

    /// <summary>
    /// 绑定市
    /// </summary>
    public string Base_GetCityName(string s_ID)
    {
        string s_return = "";
        if (s_ID != "")
        {
            this.BeginQuery("Select * from KNet_Static_Province where ID = '" + s_ID + "' ");
            this.QueryForDataTable();
            if (Dtb_Result.Rows.Count > 0)
            {
                s_return = Dtb_Result.Rows[0]["Name"].ToString();
            }
        }
        return s_return;
    }
    public string Base_GetShiName(string s_ID)
    {
        string s_return = "";
        if (s_ID != "")
        {
            this.BeginQuery("Select * from KNet_Static_City where Code = '" + s_ID + "' ");
            this.QueryForDataTable();
            if (Dtb_Result.Rows.Count > 0)
            {
                s_return = Dtb_Result.Rows[0]["Name"].ToString();
            }
        }
        return s_return;
    }
    /// <summary>
    /// 仓库绑定
    /// </summary> 
    protected void Base_DropWareHouseBind(DropDownList DropHouse, string HouseNoSql)
    {
        KNet.BLL.KNet_Sys_WareHouse bll = new KNet.BLL.KNet_Sys_WareHouse();
        DataSet ds = bll.GetList(" HouseYN=1 and (" + HouseNoSql + ")  ");

        DropHouse.DataSource = ds;
        DropHouse.DataTextField = "HouseName";
        DropHouse.DataValueField = "HouseNo";
        DropHouse.DataBind();
        ListItem item = new ListItem("请选择仓库", ""); //默认值
        DropHouse.Items.Insert(0, item);
    }


    /// <summary>
    /// 仓库绑定
    /// </summary> 
    protected void Base_DropWareHouseBindCw(DropDownList DropHouse)
    {

        this.BeginQuery("select HouseNo,HouseName FROM KNet_Sys_WareHouse  where HouseYN=1 and KSW_Type='1' union all select SuppNo,KPS_SName from Knet_Procure_Suppliers where KPS_Type in ('128860698200781250','129841117899375000') ");
        this.QueryForDataSet();
        DropHouse.DataSource = Dts_Result;
        DropHouse.DataTextField = "HouseName";
        DropHouse.DataValueField = "HouseNo";
        DropHouse.DataBind();
        ListItem item = new ListItem("请选择仓库", ""); //默认值
        DropHouse.Items.Insert(0, item);
    }



    /// <summary>
    /// 仓库绑定
    /// </summary> 
    protected void Base_DropWareHouseBindNoSelect(DropDownList DropHouse, string HouseNoSql)
    {
        KNet.BLL.KNet_Sys_WareHouse bll = new KNet.BLL.KNet_Sys_WareHouse();
        DataSet ds = bll.GetList(" HouseYN=1 and (" + HouseNoSql + ") ");
        DropHouse.DataSource = ds;
        DropHouse.DataTextField = "HouseName";
        DropHouse.DataValueField = "HouseNo";
        DropHouse.DataBind();
    }
    /// <summary>
    /// 带默认值的编码绑定
    /// </summary> 
    protected void Base_DropBasicCodeBind(DropDownList DropBasicCode, string Code)
    {
        Base_DropBasicCodeBind(DropBasicCode, Code, true);
    }
    /// <summary>
    /// 编码绑定
    /// </summary> 
    protected void Base_DropBasicCodeBind(DropDownList DropBasicCode, string Code, bool bDefaultValue)
    {
        this.BeginQuery("Select * From PB_Basic_Code where PBC_ID='" + Code + "' Order by PBC_Order,PBC_Code");
        this.QueryForDataSet();
        DropBasicCode.DataSource = Dts_Result;
        DropBasicCode.DataTextField = "PBC_Name";
        DropBasicCode.DataValueField = "PBC_Code";
        DropBasicCode.DataBind();
        if (bDefaultValue)
        {
            ListItem item = new ListItem("--请选择--", ""); //默认值
            DropBasicCode.Items.Insert(0, item);
        }
    }

    protected void Base_DropBasicCodeBind(DropDownList DropBasicCode, string Code, string s_FID, string s_FCode)
    {
        this.BeginQuery("Select * From PB_Basic_Code where PBC_ID='" + Code + "' and PBC_FID='" + s_FID + "' and PBC_FCode='" + s_FCode + "' Order by PBC_Order,PBC_Code");
        this.QueryForDataSet();
        DropBasicCode.DataSource = Dts_Result;
        DropBasicCode.DataTextField = "PBC_Name";
        DropBasicCode.DataValueField = "PBC_Code";
        DropBasicCode.DataBind();
        ListItem item = new ListItem("--请选择--", ""); //默认值
        DropBasicCode.Items.Insert(0, item);
    }
    /// <summary>
    /// 编码绑定
    /// </summary> 
    protected void Base_DropBasicCodeBindByWhere(DropDownList DropBasicCode, string Code, string s_Where)
    {
        this.BeginQuery("Select * From PB_Basic_Code where PBC_ID='" + Code + "' " + s_Where + " Order by PBC_Order,cast (PBC_Code as int) ");
        this.QueryForDataTable();
        DropBasicCode.DataSource = Dts_Result;
        DropBasicCode.DataTextField = "PBC_Name";
        DropBasicCode.DataValueField = "PBC_Code";
        DropBasicCode.DataBind();
        ListItem item = new ListItem("--请选择--", ""); //默认值
        DropBasicCode.Items.Insert(0, item);
    }


    /// <summary>
    /// 部门绑定
    /// </summary> 
    protected void Base_DropDepart(DropDownList DropBasicCode)
    {
        this.BeginQuery("Select * From KNet_Resource_OrganizationalStructure where StrucPID<>'0' order by StrucPai");
        this.QueryForDataSet();
        DropBasicCode.DataSource = Dts_Result;
        DropBasicCode.DataTextField = "StrucName";
        DropBasicCode.DataValueField = "StrucValue";
        DropBasicCode.DataBind();
        ListItem item = new ListItem("--请选择--", ""); //默认值
        DropBasicCode.Items.Insert(0, item);
    }


    /// <summary>
    /// 得到分类名称
    /// </summary>
    /// <param name="DDL"></param>
    /// <param name="ClientKings"></param>
    public string Base_GetKClaaName(string s_ID)
    {
        KNet.BLL.KNet_Sales_ClientAppseting bll = new KNet.BLL.KNet_Sales_ClientAppseting();
        DataSet ds = bll.GetList(" ClientValue ='" + s_ID + "' ");
        if ((ds.Tables[0].Rows.Count > 0) && (s_ID != ""))
        {
            return ds.Tables[0].Rows[0]["Client_Name"].ToString();
        }
        else
        {
            return "-";
        }
    }

    /// <summary>
    /// 仓库绑定
    /// </summary> 
    public string Base_GetHouseName(String s_ID)
    {
        KNet.BLL.KNet_Sys_WareHouse bll = new KNet.BLL.KNet_Sys_WareHouse();
        KNet.Model.KNet_Sys_WareHouse model = bll.GetModel(s_ID);
        if (model != null)
        {
            return model.HouseName;
        }
        else
        {
            string s_Return = Base_GetShortSupplierName(s_ID);
            return s_Return;
        }
    }

    /// <summary>
    /// 得到客户联系人字段
    /// </summary>
    /// <param name="DDL"></param>
    /// <param name="ClientKings"></param>
    public string Base_GetLinkManValue(string s_ID, string s_Value)
    {
        AdminloginMess AM = new AdminloginMess();
        if (AM.YNAuthority("能查看联系人"))
        {
            KNet.BLL.XS_Compy_LinkMan bll = new KNet.BLL.XS_Compy_LinkMan();
            DataSet ds = bll.GetList(" XOL_ID ='" + s_ID + "' ");
            if ((ds.Tables[0].Rows.Count > 0) && (s_ID != ""))
            {
                return ds.Tables[0].Rows[0][s_Value].ToString();
            }
            else
            {
                return s_ID;
            }
        }
        else
        {
            return "";
        }
    }
    /// <summary>
    /// 客户联系人绑定
    /// </summary> 
    protected void Base_DropLinkManBind(DropDownList DropBasicCode, string s_Customer)
    {
        try
        {
            KNet.BLL.XS_Compy_LinkMan bll = new KNet.BLL.XS_Compy_LinkMan();
            DataSet ds = bll.GetList(" XOL_Compy ='" + s_Customer + "' ");
            DropBasicCode.DataSource = ds;
            DropBasicCode.DataTextField = "XOL_Name";
            DropBasicCode.DataValueField = "XOL_ID";
            DropBasicCode.DataBind();
            ListItem item = new ListItem("--请选择--", ""); //默认值
            DropBasicCode.Items.Insert(0, item);
        }
        catch (Exception ex)
        {


        }
    }



    /// <summary>
    /// 返回客户名称s
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Base_GetCustomerNames(string s_Value)
    {
        string[] s_ID = s_Value.Split(',');
        StringBuilder s_Name = new StringBuilder();
        if (s_ID.Length > 0)
        {
            for (int i = 0; i < s_ID.Length; i++)
            {
                s_Name.Append(Base_GetCustomerName(s_ID[i]) + ",");
            }
        }
        return s_Name.ToString().Substring(0, s_Name.Length - 1);
    }
    /// <summary>
    /// 返回客户名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Base_GetCustomerName(string s_Value)
    {
        AdminloginMess AM = new AdminloginMess();
        if (AM.YNAuthority("能查看客户"))
        {
            using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
            {
                conn.Open();
                string Dostr = "select ID,CustomerValue,CustomerName from KNet_Sales_ClientList where CustomerValue='" + s_Value + "'";
                SqlCommand cmd = new SqlCommand(Dostr, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return dr["CustomerName"].ToString().Trim();
                }
                else
                {
                    return "--";
                }
            }
        }
        else
        {
            return "****";
        }
    }

    /// <summary>
    /// 返回客户简称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Base_GetShortCustomerName(string s_Value)
    {
        AdminloginMess AM = new AdminloginMess();
        if (AM.YNAuthority("能查看客户"))
        {
            string s_Return = "";
            using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
            {
                conn.Open();
                string Dostr = "select ID,CustomerValue,CustomerName,KSC_SampleName from KNet_Sales_ClientList where CustomerValue='" + s_Value + "'";
                SqlCommand cmd = new SqlCommand(Dostr, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string s_Name = dr["CustomerName"].ToString();
                    string s_SName = dr["KSC_SampleName"].ToString();
                    string s_CustomerValue = dr["CustomerValue"].ToString();
                    if (s_SName != "")
                    {
                        s_Name = s_SName;
                    }
                    else
                    {
                        if (dr["CustomerName"].ToString().Length > 5)
                        {
                            s_Name = dr["CustomerName"].ToString().Substring(0, 5);
                        }
                    }
                    s_Return = s_Name;
                }
                return s_Return;
            }
        }
        else
        {
            return "****";
        }
    }

    /// <summary>
    /// 返回客户负责人
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Base_GetCustomerDutyPerson(string s_Value)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,CustomerValue,CustomerName,KSC_DutyPerson from KNet_Sales_ClientList where CustomerValue='" + s_Value + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["KSC_DutyPerson"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 返回客户名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Base_GetCustomerName_Link(string s_Value)
    {

        AdminloginMess AM = new AdminloginMess();
        if (AM.YNAuthority("能查看客户"))
        {
            using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
            {
                conn.Open();
                string Dostr = "select ID,CustomerValue,CustomerName,KSC_SampleName from KNet_Sales_ClientList where CustomerValue='" + s_Value + "'";
                SqlCommand cmd = new SqlCommand(Dostr, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string s_Name = dr["CustomerName"].ToString();
                    string s_SName = dr["KSC_SampleName"].ToString();
                    string s_CustomerValue = dr["CustomerValue"].ToString();
                    if (s_SName != "")
                    {
                        s_Name = s_SName;
                    }
                    else
                    {
                        if (dr["CustomerName"].ToString().Length > 5)
                        {
                            s_Name = dr["CustomerName"].ToString().Substring(0, 5);
                        }
                    }
                    string s_Return = "<a href=\"/Web/Xs/Customer/KNet_Sales_ClientList_View.aspx?CustomerValue=" + s_CustomerValue + "\"  target=\"_self\" onMouseOver=\"fnDropDown1(this,'" + s_CustomerValue + "_sub');\" onMouseOut=\"fnHideDrop('" + s_CustomerValue + "_sub');\" >" + s_Name + "</a>";
                    s_Return += "<div class=\"Drop_Customer\" id=\"" + s_CustomerValue + "_sub\" onMouseOut=\"fnHideDrop('" + s_CustomerValue + "_sub')\" onMouseOver=\"fnShowDrop('" + s_CustomerValue + "_sub')\">\n";
                    s_Return += "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">\n";

                    s_Return += "<tr><td >客户：" + dr["CustomerName"].ToString();
                    s_Return += "</td></tr>\n";
                    s_Return += "</table>\n</div>\n";
                    return s_Return;

                }
                else
                {
                    return "--";
                }
            }

        }
        else
        {
            return "****";
        }
    }
    /// <summary>
    /// 返回客户名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Base_GetCustomerName_Link(string s_Value, bool b_IsShort)
    {
        AdminloginMess AM = new AdminloginMess();
        if (AM.YNAuthority("能查看客户"))
        {
            using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
            {
                conn.Open();
                string Dostr = "select ID,CustomerValue,CustomerName,KSC_SampleName from KNet_Sales_ClientList where CustomerValue='" + s_Value + "'";
                SqlCommand cmd = new SqlCommand(Dostr, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string s_Name = dr["CustomerName"].ToString();
                    string s_SName = dr["KSC_SampleName"].ToString();
                    string s_CustomerValue = dr["CustomerValue"].ToString();
                    string s_Return = "";
                    if (b_IsShort == true)
                    {

                        if (s_SName != "")
                        {
                            s_Name = s_SName;
                        }
                        else
                        {
                            if (dr["CustomerName"].ToString().Length > 5)
                            {
                                s_Name = dr["CustomerName"].ToString().Substring(0, 5);
                            }
                        }
                        s_Return = "<a href=\"/Web/Xs/Customer/KNet_Sales_ClientList_View.aspx?CustomerValue=" + s_CustomerValue + "\"  target=\"_self\" onMouseOver=\"fnDropDown1(this,'" + s_CustomerValue + "_sub');\" onMouseOut=\"fnHideDrop('" + s_CustomerValue + "_sub');\" >" + s_Name + "</a>";
                        s_Return += "<div class=\"Drop_Customer\" id=\"" + s_CustomerValue + "_sub\" onMouseOut=\"fnHideDrop('" + s_CustomerValue + "_sub')\" onMouseOver=\"fnShowDrop('" + s_CustomerValue + "_sub')\">\n";
                        s_Return += "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">\n";

                        s_Return += "<tr><td >客户：" + dr["CustomerName"].ToString();
                        s_Return += "</td></tr>\n";
                        s_Return += "</table>\n</div>\n";
                    }

                    return s_Return;
                }
                else
                {
                    return "--";
                }
            }

        }
        else
        {
            return "****";
        }
    }
    /// <summary>
    /// 联系人连接
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Base_GetLinMan_Link(string s_Value)
    {
        return "<a href=\"/Web/Xs/Customer/KNet_Sales_LinkMan_View.aspx?ID=" + s_Value + "\"  target=\"_self\">" + Base_GetLinkManValue(s_Value, "XOL_Name") + "</a>";
    }
    /// <summary>
    /// 返回客户编码
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Base_GetCustomerCode(string s_Value)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,CustomerCode from KNet_Sales_ClientList where CustomerValue='" + s_Value + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["CustomerCode"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 返回产品名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Base_GetProdutsName(string s_Value)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select * from KNet_Sys_Products where ProductsBarCode='" + s_Value + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["ProductsName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 返回产品大类
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Base_GetProdutsMainCategory(string s_Value)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select * from KNet_Sys_Products where ProductsBarCode='" + s_Value + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["ProductsMainCategory"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 获取产品名称：Link
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string Base_GetProdutsName_Link(string aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {

            conn.Open();
            string Dostr = "select * from KNet_Sys_Products where ProductsBarCode='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return "<a href=\"/Web/Products/KnetProductsSetting_Details.aspx?BarCode=" + dr["ProductsBarCode"].ToString().Trim() + "\"  target=\"_blank\">" + dr["ProductsName"].ToString() + "</a>";

            }
            else
            {
                return "--";
            }
        }
    }
    /// <summary>
    /// 返回唯一编码 Type  0:不更改增加值，1，改变增加值
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    public string GetNewID(string s_TableName, int i_Type)
    {
        string s_ID = "";
        try
        {
            KNet.BLL.PB_Code_Ident Bll_Code_Ident = new KNet.BLL.PB_Code_Ident();
            KNet.Model.PB_Code_Ident Model_Code_Ident = new KNet.Model.PB_Code_Ident();
            KNet.BLL.PB_Code_Sequence Bll_Code_Sequence = new KNet.BLL.PB_Code_Sequence();
            KNet.Model.PB_Code_Sequence Model_Code_Sequence = new KNet.Model.PB_Code_Sequence();

            Model_Code_Ident = Bll_Code_Ident.GetModel(s_TableName);
            if (Model_Code_Ident != null)
            {
                if (Model_Code_Ident.PCI_Identity != null)
                {
                    if (Model_Code_Ident.PCI_Head != null)
                    {
                        s_ID += Model_Code_Ident.PCI_Head.ToString();
                    }
                    if (DateTime.Today.ToString() != Model_Code_Ident.PCI_Date.ToString())
                    {
                        s_ID += DateTime.Today.ToString("yyyyMMdd") + Model_Code_Ident.PCI_Default.ToString().Substring(1, Model_Code_Ident.PCI_Default.ToString().Length - 1);
                    }
                    else
                    {
                        s_ID += DateTime.Today.ToString("yyyyMMdd") + Model_Code_Ident.PCI_Identity.ToString().Substring(1, Model_Code_Ident.PCI_Identity.ToString().Length - 1);

                    }

                    if (i_Type == 1)
                    {
                        if ((DateTime.Today.ToString() != Model_Code_Ident.PCI_Date.ToString()) && (Model_Code_Ident.PCI_Identity != Model_Code_Ident.PCI_Default))
                        {
                            Model_Code_Ident.PCI_Identity = Model_Code_Ident.PCI_Default + 1;
                        }
                        else
                        {
                            Model_Code_Ident.PCI_Identity = Model_Code_Ident.PCI_Identity + 1;
                        }
                        Model_Code_Ident.PCI_Date = DateTime.Today;
                        Bll_Code_Ident.Update(Model_Code_Ident);

                        Model_Code_Sequence.PCS_Table = s_TableName;
                        Model_Code_Sequence.PCS_Date = DateTime.Now;
                        Model_Code_Sequence.PCS_Default = Model_Code_Ident.PCI_Default;
                        Model_Code_Sequence.PCS_Identity = Model_Code_Ident.PCI_Identity;
                        Model_Code_Sequence.PCS_Type = Model_Code_Ident.PCI_Type;
                        Bll_Code_Sequence.Add(Model_Code_Sequence);
                    }
                }

            }
            else
            {
                KNet.Model.PB_Code_Ident Model1 = new KNet.Model.PB_Code_Ident();
                Model1.PCI_Table = s_TableName;
                Model1.PCI_Type = "101";
                Model1.PCI_Length = 16;
                Model1.PCI_Head = "";
                Model1.PCI_Fill = "0";
                Model1.PCI_Default = 1000001;
                Model1.PCI_Identity = 1000001;
                Bll_Code_Ident.Add(Model1);
                return GetNewID(s_TableName, i_Type);

            }
            return s_ID;
        }
        catch (Exception ex)
        {
            throw;
            return "";
        }
    }

    /// <summary>
    /// 得到ck库存数量
    /// </summary>
    /// <param name="s_HouseNo"></param>
    /// <param name="s_ProductsBarCode"></param>
    /// <returns></returns>
    public string Base_GetWareHouseNumber(string s_HouseNo, string s_ProductsBarCode)
    {
        try
        {
            string s_Sql = "Select isnull(Sum(DirectInAmount),0) from v_Store Where HouseNo='" + s_HouseNo + "' and ProductsBarCode='" + s_ProductsBarCode + "' ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                return Dtb_Table.Rows[0][0].ToString();
            }
            else
            {
                return "0";
            }
        }
        catch (Exception ex)
        {
            throw;
            return "0";
        }
    }

    /// <summary>
    /// 得到ck库存数量
    /// </summary>
    /// <param name="s_HouseNo"></param>
    /// <param name="s_ProductsBarCode"></param>
    /// <returns></returns>
    public string Base_GetKCNumber(string s_ProductsBarCode)
    {
        try
        {
            string s_Sql = "Select Sum(DirectInAmount) from v_Store Where ProductsBarCode='" + s_ProductsBarCode + "' ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                return Dtb_Table.Rows[0][0].ToString();
            }
            else
            {
                return "0";
            }
        }
        catch (Exception ex)
        {
            throw;
            return "0";
        }
    }

    public string GetNearPrice(string s_ProductsBarCode)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "select* from Knet_Procure_SuppliersPrice a join Knet_Procure_Suppliers b on a.SuppNo=b.SuppNo where KPP_Del=0 and KPP_State=1 and a.ProductsBarCode='" + s_ProductsBarCode + "' order by b.SuppNo ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    s_Return += Dtb_Table.Rows[i]["KPS_SName"].ToString() + "(" + Dtb_Table.Rows[i]["ProcureUnitPrice"].ToString() + ")<br/>";
                }
            }
            else
            {
                s_Return = "-<br/>";
            }
        }
        catch (Exception ex)
        {
            s_Return = "-<br/>";
            throw;
        }
        return s_Return;
    }

    public string GetLowNearPrice(string s_ProductsBarCode)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "select top 1 * from Knet_Procure_SuppliersPrice a join Knet_Procure_Suppliers b on a.SuppNo=b.SuppNo where KPP_Del=0 and KPP_State=1 and a.ProductsBarCode='" + s_ProductsBarCode + "' order by ProcureUnitPrice,b.SuppNo ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    s_Return += Dtb_Table.Rows[i]["KPS_SName"].ToString() + "(" + Dtb_Table.Rows[i]["ProcureUnitPrice"].ToString() + ")<br/>" + "$" + Dtb_Table.Rows[i]["ProcureUnitPrice"].ToString();
                }
            }
            else
            {
                s_Return = "-<br/>";
            }
        }
        catch (Exception ex)
        {
            s_Return = "-<br/>";
            throw;
        }
        return s_Return;
    }

    public string GetNearPriceAndHandPrice(string s_ProductsBarCode)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "select  KPS_SName,ProcureUnitPrice,HandPrice from Knet_Procure_SuppliersPrice a join Knet_Procure_Suppliers b on a.SuppNo=b.SuppNo where KPP_Del=0 and KPP_State=1 and a.ProductsBarCode='" + s_ProductsBarCode + "' ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    s_Return += Dtb_Table.Rows[i]["KPS_SName"].ToString() + "(" + Dtb_Table.Rows[i]["ProcureUnitPrice"].ToString() + "|" + Dtb_Table.Rows[i]["HandPrice"].ToString() + ")<br/>";
                }
            }
            else
            {
                s_Return = "-<br/>";
            }
        }
        catch (Exception ex)
        {
            s_Return = "-<br/>";
            throw;
        }
        return s_Return;
    }

    public string GetNewPriceAndHandPrice(string s_ProductsBarCode)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "select top 1 KPS_SName,isnull(ProcureUnitPrice,0) ProcureUnitPrice,isnull(HandPrice,0) HandPrice from Knet_Procure_SuppliersPrice a join Knet_Procure_Suppliers b on a.SuppNo=b.SuppNo where KPP_Del=0 and KPP_State=1 and a.ProductsBarCode='" + s_ProductsBarCode + "' order by ProcureUpdateDateTime desc ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {

                    s_Return += decimal.Parse(Dtb_Table.Rows[i]["ProcureUnitPrice"].ToString()) + decimal.Parse(Dtb_Table.Rows[i]["HandPrice"].ToString());
                    // Dtb_Table.Rows[i]["KPS_SName"].ToString() + "(" + Dtb_Table.Rows[i]["ProcureUnitPrice"].ToString() + "|" + Dtb_Table.Rows[i]["HandPrice"].ToString() + ")<br/>";
                }
            }
            else
            {
                s_Return = "0";
            }
        }
        catch (Exception ex)
        {
            s_Return = "0";
            throw;
        }
        return s_Return;
    }

    public string GetLowPriceAndHandPrice(string s_ProductsBarCode)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "select top 1 * from Knet_Procure_SuppliersPrice a join Knet_Procure_Suppliers b on a.SuppNo=b.SuppNo where KPP_Del=0 and KPP_State=1 and a.ProductsBarCode='" + s_ProductsBarCode + "' order by isnull(ProcureUnitPrice,0)+isnull(HandPrice,0) ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    s_Return += Dtb_Table.Rows[i]["KPS_SName"].ToString() + "(" + Dtb_Table.Rows[i]["ProcureUnitPrice"].ToString() + "|" + Dtb_Table.Rows[i]["HandPrice"].ToString() + ")<br/>" + "$" + Dtb_Table.Rows[i]["ProcureUnitPrice"].ToString() + "$" + Dtb_Table.Rows[i]["HandPrice"].ToString();
                }
            }
            else
            {
                s_Return = "-<br/>";
            }
        }
        catch (Exception ex)
        {
            s_Return = "-<br/>";
            throw;
        }
        return s_Return;
    }
    /// <summary>
    /// 得到ck库存数量
    /// </summary>
    /// <param name="s_HouseNo"></param>
    /// <param name="s_ProductsBarCode"></param>
    /// <returns></returns>
    public string Base_GetHouseAndNumber(string s_ProductsBarCode)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "Select Sum(DirectInAmount),a.HouseNo from v_Store a join KNet_Sys_WareHouse b on a.HouseNo=b.HouseNo  Where a.ProductsBarCode='" + s_ProductsBarCode + "' and a.HouseType='0' Group by a.HouseNo having Sum(DirectInAmount)>0 ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    if ((Dtb_Table.Rows[i][0].ToString() != "") && (Dtb_Table.Rows[i][0].ToString() != "0"))
                    {
                        s_Return += Base_GetHouseName(Dtb_Table.Rows[i][1].ToString()) + "(" + Dtb_Table.Rows[i][0].ToString() + ")<br/>";
                    }
                }
            }
            else
            {
                s_Return = "-<br/>";
            }
        }
        catch (Exception ex)
        {
            s_Return = "-<br/>";
            throw;
        }
        return s_Return;
    }


    /// <summary>
    /// 得到ck库存数量
    /// </summary>
    /// <param name="s_HouseNo"></param>
    /// <param name="s_ProductsBarCode"></param>
    /// <returns></returns>
    public string Base_GetHouseAndNumber1(string s_ProductsBarCode)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "Select Sum(DirectInAmount),a.HouseNo from v_Store a join KNet_Sys_WareHouse b on a.HouseNo=b.HouseNo  Where a.ProductsBarCode='" + s_ProductsBarCode + "' and a.HouseType='0' Group by a.HouseNo having Sum(DirectInAmount)>0 ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    if ((Dtb_Table.Rows[i][0].ToString() != "") && (Dtb_Table.Rows[i][0].ToString() != "0"))
                    {
                        s_Return += Base_GetHouseName(Dtb_Table.Rows[i][1].ToString()) + "(" + Dtb_Table.Rows[i][0].ToString() + ")|";
                    }
                }
            }
            else
            {
                s_Return = "-<br/>";
            }
        }
        catch (Exception ex)
        {
            s_Return = "-<br/>";
            throw;
        }
        return s_Return;
    }



    public string Base_GetHouseOnlyNumber(string s_ProductsBarCode)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "Select Sum(DirectInAmount),a.HouseNo from v_Store a join KNet_Sys_WareHouse b on a.HouseNo=b.HouseNo  Where a.ProductsBarCode='" + s_ProductsBarCode + "' and a.HouseType='0' Group by a.HouseNo having Sum(DirectInAmount)>0 ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    if ((Dtb_Table.Rows[i][0].ToString() != "") && (Dtb_Table.Rows[i][0].ToString() != "0"))
                    {
                        s_Return += Dtb_Table.Rows[i][0].ToString() + ",";
                    }
                }
            }
            else
            {
                s_Return = "0,";
            }
        }
        catch (Exception ex)
        {
            s_Return = "0,";
            throw;
        }
        return s_Return;
    }
    /// <summary>
    /// 得到供应商ck库存数量
    /// </summary>
    /// <param name="s_HouseNo"></param>
    /// <param name="s_ProductsBarCode"></param>
    /// <returns></returns>
    public string Base_GetHouseAndNumber(string s_ProductsBarCode, string s_HouseNo)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "Select Sum(DirectInAmount),HouseNo from v_Store Where ProductsBarCode='" + s_ProductsBarCode + "' and HouseNo='" + s_HouseNo + "' Group by HouseNo ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    s_Return += Base_GetHouseName(Dtb_Table.Rows[i][1].ToString()) + "(" + FormatNumber1(Dtb_Table.Rows[i][0].ToString(), 0) + "),";
                }
            }
            else
            {
                s_Return = "-,";
            }
        }
        catch (Exception ex)
        {
            s_Return = "-,";
            throw;
        }
        s_Return = s_Return.Substring(0, s_Return.Length - 1);
        return s_Return;
    }

    public string Base_GetHouseAndNumber1(string s_ProductsBarCode, string s_HouseNo)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "Select isnull(Sum(DirectInAmount),0) ";
            if (s_HouseNo != "")
            {
                s_Sql += ",a.HouseNo ";
            }
            s_Sql += " from v_Store  a join KNet_Sys_WareHouse b on a.HouseNo=b.HouseNo Where a.ProductsBarCode='" + s_ProductsBarCode + "' and a.HouseType='0' ";
            if (s_HouseNo != "")
            {

                s_Sql += " and a.HouseNo='" + s_HouseNo + "'";
                s_Sql += " Group by a.HouseNo ";
            }
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    s_Return += FormatNumber1(Dtb_Table.Rows[i][0].ToString(), 0) + ",";
                }
            }
            else
            {
                s_Return = "0,";
            }
        }
        catch (Exception ex)
        {
            s_Return = "0,";
            throw;
        }
        s_Return = s_Return.Substring(0, s_Return.Length - 1);
        return s_Return;
    }
    /// <summary>
    /// 得到供应商ck的缺料数量
    /// </summary>
    /// <param name="s_HouseNo"></param>
    /// <param name="s_ProductsBarCode"></param>
    /// <returns></returns>
    public string Base_GetHouseAndNeedNumber(string s_ProductsBarCode, string s_HouseNo)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "Select NeedNumber,HouseName from v_OrderNeed Where MaterProductsBarCode='" + s_ProductsBarCode + "' and HouseNo='" + s_HouseNo + "' ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    s_Return += Dtb_Table.Rows[i][1].ToString() + "(" + FormatNumber1(Dtb_Table.Rows[i][0].ToString(), 0) + "),";
                }
            }
            else
            {
                s_Return = "-,";
            }
        }
        catch (Exception ex)
        {
            s_Return = "-,";
            throw;
        }
        s_Return = s_Return.Substring(0, s_Return.Length - 1);
        return s_Return;
    }
    /// <returns></returns>
    public string Base_GetHouseAndNeedNumber1(string s_ProductsBarCode, string s_HouseNo)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "Select SUM(NeedNumber) from v_OrderNeed Where MaterProductsBarCode='" + s_ProductsBarCode + "'";
            if (s_HouseNo != "")
            {
                s_Sql += " and HouseNo='" + s_HouseNo + "' ";
            }
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    s_Return += FormatNumber1(Dtb_Table.Rows[i][0].ToString(), 0) + ",";
                }
            }
            else
            {
                s_Return = "-,";
            }
        }
        catch (Exception ex)
        {
            s_Return = "-,";
            throw;
        }
        s_Return = s_Return.Substring(0, s_Return.Length - 1);
        return s_Return;
    }

    public string Base_GetOrderWrkNumber(string s_ProductsBarCode, string s_HouseNo)
    {
        string s_Return = "";
        try
        {
            string s_SuppNo = "";
            try
            {
                KNet.BLL.KNet_Sys_WareHouse Bll = new KNet.BLL.KNet_Sys_WareHouse();
                KNet.Model.KNet_Sys_WareHouse Model = Bll.GetModel(s_HouseNo);
                s_SuppNo = Model.SuppNo;
            }
            catch
            { }
            string s_Sql = "select  isnull(Sum(number),0)  from ( select Sum(case when WrkNumber<0 then 0 else WrkNumber end) number from Knet_Procure_OrdersList_Details a join   Knet_Procure_OrdersList b on a.OrderNo=b.OrderNo";
            s_Sql += " join v_OrderRkDetailsQR c on a.OrderNO=c.V_OrderNo  and a.ProductsBarCode=c.v_ProductsBarCode join Knet_Procure_OrdersList d on d.OrderNo=b.ParentOrderNo where  1=1 ";

            if (s_SuppNo != "")
            {
                s_Sql += " and d.suppNo='" + s_SuppNo + "' ";
            }
            if (s_ProductsBarCode != "")
            {
                s_Sql += " and a.ProductsBarCode='" + s_ProductsBarCode + "'";
            }
            s_Sql += " and wrkNumber>0  union all select Sum(WrkNumber) from Knet_Procure_OrdersList_Details a join   Knet_Procure_OrdersList b on a.OrderNo=b.OrderNo";
            s_Sql += " join v_OrderRkDetailsQR c on a.OrderNO=c.V_OrderNo  where b.ParentOrderNo='' ";

            if (s_SuppNo != "")
            {
                s_Sql += "  and ContractAddress like '%" + Base_GetSupplierName(s_SuppNo) + "%'  ";
            }
            if (s_ProductsBarCode != "")
            {
                s_Sql += " and a.ProductsBarCode='" + s_ProductsBarCode + "'";
            }
            s_Sql += ") aa";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    s_Return += FormatNumber1(Dtb_Table.Rows[i][0].ToString(), 0) + ",";
                }
            }
            else
            {
                s_Return = "-,";
            }
        }
        catch (Exception ex)
        {
            s_Return = "-,";
            throw;
        }
        s_Return = s_Return.Substring(0, s_Return.Length - 1);
        return s_Return;
    }
    public string Base_GetSuppNoAndNumber(string s_ProductsBarCode, string s_SuppNo)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "Select Sum(DirectInAmount),HouseNo from v_Store Where ProductsBarCode='" + s_ProductsBarCode + "' and HouseNo in (Select HouseNo from KNet_Sys_WareHouse where SuppNo='" + s_SuppNo + "') Group by HouseNo ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    s_Return += Base_GetHouseName(Dtb_Table.Rows[i][1].ToString()) + "(" + Dtb_Table.Rows[i][0].ToString() + "),";
                }
            }
            else
            {
                s_Return = "-,";
            }
        }
        catch (Exception ex)
        {
            s_Return = "-,";
            throw;
        }
        s_Return = s_Return.Substring(0, s_Return.Length - 1);
        return s_Return;
    }
    /// <summary>
    /// 得到ck库存数量
    /// </summary>
    /// <param name="s_HouseNo"></param>
    /// <param name="s_ProductsBarCode"></param>
    /// <returns></returns>
    public string Base_GetProductsKCNumberBySql(string s_ProductsBarCode, string s_SqlWhere)
    {
        string s_Return = "";
        try
        {
            string s_Sql = "Select Sum(DirectInAmount) from v_Store Where ProductsBarCode='" + s_ProductsBarCode + "' " + s_SqlWhere + " ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                s_Return = Dtb_Table.Rows[0][0].ToString();
            }
            else
            {
                s_Return = "-,";
            }
        }
        catch (Exception ex)
        {
            throw;
            s_Return = "-";
        }
        return s_Return;
    }
    /// <summary>
    /// 返回合同状态（0未执行，1执行中，2出货中，3作废，4完成）
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    public string Base_GetOrderStateYN(object ContractNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ContractNo,ContractState,ContractCheckYN from KNet_Sales_ContractList where ContractNo='" + ContractNo + "' ";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                int A = int.Parse(dr["ContractState"].ToString());
                string Str = "--";
                switch (A)
                {
                    case 0:
                        Str = "<font color=#CC9900>未执行</font>";
                        break;
                    case 1:
                        Str = "<font color=blue>执行中</font>";
                        break;
                    case 2:
                        Str = "<font color=Red>出货中</font>";
                        break;
                    case 3:
                        Str = "<font color=#990000>已作废</font>";
                        break;
                    case 4:
                        Str = "<img src=\"/images/fin.gif\" alt=\"合同已完成\" width=\"15\" height=\"15\" border=\"0\" />";
                        break;
                    default:
                        Str = "--";
                        break;
                }
                return Str;
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 得到发货数量
    /// </summary>
    /// <param name="s_HouseNo"></param>
    /// <param name="s_ProductsBarCode"></param>
    /// <returns></returns>
    public string Base_GetShipNumber(string s_OutWareNo)
    {
        try
        {
            string s_Sql = "Select Isnull(Sum(-OutWareAmount),0) from V_Ship Where OutWareNo='" + s_OutWareNo + "' and type='102'  ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                return Dtb_Table.Rows[0][0].ToString();
            }
            else
            {
                return "0";
            }
        }
        catch (Exception ex)
        {
            throw;
            return "0";
        }
    }



    public string md5(string str, int code)
    {
        if (code == 16)
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower().Substring(8, 16);
        if (code == 32)
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
        return "00000000000000000000000000000000";
    }
    /// <summary>
    /// 销售审批流程节点
    /// </summary>
    /// <param name="s_ContractNo"></param>
    /// <returns></returns>
    public string Base_GetNextDept(string s_ContractNo, string s_Type)
    {
        string s_DeptID = "";
        try
        {
            //审批流程
            string s_Sql = "Select * from PB_Flow_Detail Where PFD_MainID='" + s_Type + "' Order by PFD_ID ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_FlowDetails = this.Dtb_Result;
            for (int i = 0; i < Dtb_FlowDetails.Rows.Count; i++)
            {
                if (Dtb_FlowDetails.Rows[i]["PFD_DeptID"].ToString() != "")//查找该部门是否已经通过审核
                {
                    if (Base_GetContractShState(Dtb_FlowDetails.Rows[i]["PFD_DeptID"].ToString(), s_ContractNo) == false)
                    {
                        s_DeptID = Dtb_FlowDetails.Rows[i]["PFD_DeptID"].ToString();
                        break;
                    }
                }
            }
            return s_DeptID;

        }
        catch (Exception ex)
        {
            return "错误";
        }
    }



    public string Base_GetNextDept(string s_ContractNo, string s_Type, string s_Dept)
    {
        string s_DeptID = "";
        try
        {
            //审批流程
            string s_Sql = "Select * from PB_Flow_Detail Where PFD_MainID='" + s_Type + "' and PFD_DeptID='" + s_Dept + "'  Order by PFD_ID ";
            //同时审批
            this.BeginQuery(s_Sql);
            s_DeptID = "其他部门";
            this.QueryForDataTable();
            DataTable Dtb_FlowDetails = this.Dtb_Result;
            for (int i = 0; i < Dtb_FlowDetails.Rows.Count; i++)
            {
                if (Dtb_FlowDetails.Rows[i]["PFD_DeptID"].ToString() != "")//查找该部门是否已经通过审核
                {
                    if (Base_GetContractShState(Dtb_FlowDetails.Rows[i]["PFD_DeptID"].ToString(), s_ContractNo) == false)
                    {
                        s_DeptID = Dtb_FlowDetails.Rows[i]["PFD_DeptID"].ToString();
                        break;
                    }
                    else
                    {
                        s_DeptID = "其他部门";

                    }
                }
            }
            return s_DeptID;

        }
        catch (Exception ex)
        {
            return "错误";
        }
    }

    public string Base_GetNextState(string s_ContractNo, string s_Type)
    {
        string s_DeptID = "";
        try
        {
            //审批流程
            string s_Sql = "Select * from PB_Flow_Detail Where PFD_MainID='" + s_Type + "' Order by PFD_ID ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_FlowDetails = this.Dtb_Result;
            for (int i = 0; i < Dtb_FlowDetails.Rows.Count; i++)
            {
                if (Dtb_FlowDetails.Rows[i]["PFD_DeptID"].ToString() != "")//查找该部门是否已经通过审核
                {
                    if (Base_GetContractShState(Dtb_FlowDetails.Rows[i]["PFD_DeptID"].ToString(), s_ContractNo) == false)
                    {
                        s_DeptID = Dtb_FlowDetails.Rows[i]["PFD_IsNext"].ToString();
                        break;
                    }
                }
            }
            return s_DeptID;

        }
        catch (Exception ex)
        {
            return "错误";
        }
    }

    public bool Base_GetContractShState(string s_DeptID, string s_ContractNo)
    {
        try
        {

            string s_Sql1 = "Select a.*,b.staffDepart From KNet_Sales_Flow a join KNet_Resource_Staff b on a.KSF_ShPerson=b.StaffNo Where KSF_ContractNo='" + s_ContractNo + "' and  b.staffDepart='" + s_DeptID + "' and (a.KSF_State='1' or a.KSF_State='3') and b.Position='102' and a.KSF_Del='0' ";
            this.BeginQuery(s_Sql1);
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        catch (Exception ex)
        {

            return false;
        }

    }


    public string Base_SendEmail(string s_Receive, string s_Text, string s_Title)
    {

        SmtpClient client = new SmtpClient();
        client.Credentials = new System.Net.NetworkCredential("System2017", "System2016");
        client.Host = "smtp.126.com";
        client.Port = 25;
        client.EnableSsl = false;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;

        MailMessage newMessage = new MailMessage();
        newMessage.From = new MailAddress("System2017@126.com");
        newMessage.Subject = s_Title;
        string[] s_ReceiveID = s_Receive.Split(',');
        for (int i = 0; i < s_ReceiveID.Length; i++)
        {
            newMessage.To.Add(s_ReceiveID[i]);
        }
        s_Text += " 局域网访问：  地址：http://192.168.0.193/signin.aspx";
        newMessage.Body = s_Text;
        try
        {
            client.Send(newMessage);
            newMessage.Dispose();
            client.Dispose();
            return "邮件发送成功";
        }
        catch (Exception exception)
        {
            return "邮件发送失败,原因:" + exception.Message;
        }
    }
    public string Base_SendEmail(string s_Receive, string s_Text, string s_File, string s_Title, string s_SettingID)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.PB_Mail_Setting Bll_Seting = new KNet.BLL.PB_Mail_Setting();
        KNet.Model.PB_Mail_Setting Model_Seting = Bll_Seting.GetModel(s_SettingID);
        SmtpClient client = new SmtpClient();
        client.Credentials = new System.Net.NetworkCredential(Model_Seting.PMS_SendPerson, Model_Seting.PMS_Password);
        client.Host = Model_Seting.PMS_Sever;
        client.Port = int.Parse(Model_Seting.PMS_Port);
        client.EnableSsl = true;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        MailMessage newMessage = new MailMessage();
        newMessage.From = new MailAddress(Model_Seting.PMS_SendEmail);
        newMessage.Subject = s_Title;

        newMessage.BodyEncoding = System.Text.Encoding.UTF8;//正文编码            
        newMessage.IsBodyHtml = true;//设置为HTML格式            
        newMessage.Priority = MailPriority.High;//优先级
        ///先检查这封邮件是否已经发送过。

        if (s_File != "")
        {

            string[] s_FileID = s_File.Split(',');
            for (int i = 0; i < s_FileID.Length; i++)
            {

                if (s_FileID[i] != "")
                {
                    string file = s_FileID[i];//附件路径
                    // AM.Add_Logs(Model_Seting.PMS_SendPerson + "," + Model_Seting.PMS_Password + "," + s_Receive + "," + file);
                    Attachment data = new Attachment(file, System.Net.Mime.MediaTypeNames.Application.Octet);
                    // Add time stamp information for the file.
                    System.Net.Mime.ContentDisposition disposition = data.ContentDisposition;
                    disposition.CreationDate = System.IO.File.GetCreationTime(file);
                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                    disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
                    // Add the file attachment to this e-mail message.
                    newMessage.Attachments.Add(data);
                }
            }
        }
        string[] s_ReceiveID = s_Receive.Split(',');
        for (int i = 0; i < s_ReceiveID.Length; i++)
        {
            newMessage.To.Add(s_ReceiveID[i]);
        }
        newMessage.Body = s_Text;
        try
        {
            client.Send(newMessage);
            newMessage.Dispose();
            client.Dispose();
            return "邮件发送成功";
        }
        catch (Exception exception)
        {
            // AM.Add_Logs(s_Receive + "," + s_Text + "," + s_Receive + "," + s_File + "," + s_SettingID);
            return "邮件发送失败,原因:" + exception.Message;
        }
    }

    /// <summary>
    /// 颜色提醒
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    public string base_GetDaysColor(string s_Days)
    {
        if (s_Days == "")
        {
            return "";
        }
        string s_Return = "剩余 " + s_Days.ToString() + " 天";
        int i_Days = 0;
        try
        {
            i_Days = int.Parse(s_Days);
        }
        catch { return ""; }
        try
        {
            if (i_Days < 0)
            {
                s_Return = "<font color=red> 超期 " + Math.Abs(i_Days).ToString() + " 天</font>";
            }

            else if (i_Days <= 1)
            {
                s_Return = "<font color=red>今日到货</font>";
            }
            else if (i_Days <= 3)
            {
                s_Return = "<font color=\"#FF00FF\"> 剩余 " + i_Days.ToString() + "  天</font>";
            }
            else if (i_Days <= 7)
            {
                s_Return = "<font color=green> 剩余 " + i_Days.ToString() + "  天</font>";
            }
        }
        catch
        {
        }
        return s_Return;

    }
    /// <summary>
    /// 返回采购类型名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    public string base_GetProcureTypeNane(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,ProcureTypeValue,ProcureTypeName from KNet_Sys_ProcureType where ProcureTypeValue='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["ProcureTypeName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }

    /// <summary>
    /// 库存类型
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string Base_GetV_StoreDetailProductsPatten(string s_StoreNo)
    {
        string s_Return = "";
        this.BeginQuery("Select * from v_Store Where Code='" + s_StoreNo + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += Base_GetProductsEdition_Link(Dtb_Result.Rows[i]["ProductsBarCode"].ToString()) + ",";
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 1);
        }
        return s_Return;
    }

    /// <summary>
    /// 库存数量
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string Base_GetV_StoreDetailNumbers(string s_StoreNo)
    {
        string s_Return = "";
        this.BeginQuery("Select Sum(DirectInAmount) as DirectInAmount from v_Store Where Code='" + s_StoreNo + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return = Dtb_Result.Rows[i]["DirectInAmount"].ToString();
            }
        }
        return s_Return;
    }



    /// <summary>
    /// 采购类型
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string Base_GetOrderDetailProductsPatten(string s_Order)
    {
        string s_Return = "";
        string s_Sql = "Select * from Knet_Procure_OrdersList_Details a ";
        s_Sql += " join Knet_Procure_OrdersList b  on a.OrderNo =b.OrderNo Where  a.OrderNo='" + s_Order + "' order by a.ID";
        this.BeginQuery(s_Sql);
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += Base_GetProductsEdition_Link(Dtb_Result.Rows[i]["ProductsBarCode"].ToString());

                s_Return += "<br/>";
            }
        }
        return s_Return;
    }

    /// <summary>
    /// 采购类型
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string Base_GetOrderDetailNumber(string s_Order)
    {
        string s_Return = "";
        string s_Sql = "Select * from Knet_Procure_OrdersList_Details a ";
        s_Sql += " join Knet_Procure_OrdersList b  on a.OrderNo =b.OrderNo Where  a.OrderNo='" + s_Order + "'  order by a.ID";
        this.BeginQuery(s_Sql);
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += Dtb_Result.Rows[i]["OrderAmount"].ToString();

                s_Return += "<br/>";
            }
        }
        return s_Return;
    }
    /// <summary>
    /// 采购订单重量
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string Base_GetOrderDetailWeight(string s_Order)
    {
        string s_Return = "";
        string s_Sql = "Select KPOD_BigUnits from Knet_Procure_OrdersList_Details Where OrderNo='" + s_Order + "' order by ID ";
        //s_Sql += " join Knet_Procure_OrdersList b  on a.OrderNo =b.OrderNo Where  a.OrderNo='" + s_Order + "'  order by a.ID";
        this.BeginQuery(s_Sql);
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += Dtb_Result.Rows[i]["KPOD_BigUnits"].ToString();

                s_Return += "<br/>";
            }
        }
        return s_Return;
    }

    /// <summary>
    /// 未入库数量
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string Base_GetOrderDetailWrkNumber(string s_Order)
    {
        string s_Return = "";
        string s_Sql = "Select * from Knet_Procure_OrdersList_Details a join v_OrderRkDetails c on c.KPO_ID=a.ID ";
        s_Sql += " join Knet_Procure_OrdersList b  on a.OrderNo =b.OrderNo Where  a.OrderNo='" + s_Order + "'";
        this.BeginQuery(s_Sql);
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += Dtb_Result.Rows[i]["WRkNumber"].ToString();

                s_Return += "<br/>";
            }
        }
        return s_Return;
    }
    /// <summary>
    /// 未入库数量
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string Base_GetOrderDetailrkNumber(string s_Order)
    {
        string s_Return = "";
        string s_Sql = "Select * from Knet_Procure_OrdersList_Details a join v_OrderRkDetails c on c.KPO_ID=a.ID ";
        s_Sql += " join Knet_Procure_OrdersList b  on a.OrderNo =b.OrderNo Where  a.OrderNo='" + s_Order + "'";
        this.BeginQuery(s_Sql);
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += Dtb_Result.Rows[i]["RkNumber"].ToString();

                s_Return += "<br/>";
            }
        }
        return s_Return;
    }
    /// <summary>
    /// 采购总数量
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string Base_GetOrderDetailNumbers(string s_Order)
    {
        string s_Return = "";
        this.BeginQuery("Select Sum(OrderAmount) as OrderAmount from Knet_Procure_OrdersList_Details Where OrderNo='" + s_Order + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return = Dtb_Result.Rows[i]["OrderAmount"].ToString();
            }
        }
        return s_Return;
    }

    /// <summary>
    /// 最新采购单价
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string base_GetCGRKPrice(string s_DirectOutID)
    {
        string s_Return = "";
        KNet.BLL.KNet_WareHouse_DirectOutList_Details BLL_Details = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
        KNet.Model.KNet_WareHouse_DirectOutList_Details Model_Details = BLL_Details.GetModel(s_DirectOutID);


        SqlConnection conn = GetConn();
        conn.Open();
        SqlCommand cmd = new SqlCommand("Select Top 1 OrderUnitPrice from Knet_Procure_OrdersList_Details a join Knet_Procure_OrdersList b on a.OrderNO=b.OrderNO Where ProductsBarCode='" + Model_Details.ProductsBarCode + "' order by OrderDateTime desc", conn);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet Dts_Table = new DataSet();
        adapter.Fill(Dts_Table);
        if (Dts_Table.Tables[0].Rows.Count > 0)
        {
            s_Return = Dts_Table.Tables[0].Rows[0]["OrderUnitPrice"].ToString();
        }
        return s_Return;
    }

    /// <summary>
    /// 采购总数量
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string Base_GetOrderWareHouseDetailNumbers(string s_Order)
    {
        string s_Return = "";
        this.BeginQuery("Select Sum(WareHouseAmount) as OrderAmount from Knet_Procure_WareHouseList_Details Where  WareHouseNo in (Select WareHouseNo from Knet_Procure_WareHouseList where OrderNo = '" + s_Order + "' and KPW_Del='0' )");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            s_Return = Dtb_Result.Rows[0]["OrderAmount"].ToString();
        }
        return s_Return;
    }




    /// <summary>
    /// 采购类型
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string Base_GetShipDetailProductsPatten(string s_DirectOutNo)
    {
        string s_Return = "";
        this.BeginQuery("Select distinct ProductsBarCode,ProductsPattern from KNet_WareHouse_DirectOutList_Details Where DirectOutNo='" + s_DirectOutNo + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += this.Base_GetProductsEdition_Link(Dtb_Result.Rows[i]["ProductsBarCode"].ToString()) + "<br>";
                if (this.Base_GetProductsEdition(Dtb_Result.Rows[i]["ProductsBarCode"].ToString()) == "")
                {
                    s_Return = s_Return.Substring(0, s_Return.Length - 1);
                    s_Return += Dtb_Result.Rows[i]["ProductsPattern"].ToString() + "<br>";
                }
            }
        }
        return s_Return;
    }
    public string Base_GetShipDetailProductsPatten(string s_DirectOutNo, bool b_Battry)
    {

        string s_Return = "";
        if (b_Battry == false)
        {

            string s_Sql = "Select * from KNet_WareHouse_DirectOutList_Details  a join KNet_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode Where DirectOutNo='" + s_DirectOutNo + "' ";
            KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
            string s_SonID = Bll_ProductsDetails.GetSonIDs("01");
            s_SonID = s_SonID.Replace(",", "','");
            s_Sql += " and b.ProductsType in ('" + s_SonID + "') ";

            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                {
                    s_Return += this.Base_GetProductsEdition_Link(Dtb_Result.Rows[i]["ProductsBarCode"].ToString()) + ",";
                    if (this.Base_GetProductsEdition(Dtb_Result.Rows[i]["ProductsBarCode"].ToString()) == "")
                    {
                        s_Return = s_Return.Substring(0, s_Return.Length - 1);
                        s_Return += Dtb_Result.Rows[i]["ProductsPattern"].ToString() + ",";
                    }
                }
                s_Return = s_Return.Substring(0, s_Return.Length - 1);
            }
        }
        return s_Return;
    }
    /// <summary>
    /// 采购总数量
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string Base_GetShipDetailNumbers(string s_DirectOutNo, bool b_Battry)
    {
        string s_Return = "";
        if (b_Battry == false)
        {
            string s_Sql = "Select Sum(DirectOutAmount+Isnull(KWD_BNumber,0)) as DirectOutAmount from KNet_WareHouse_DirectOutList_Details a join KNet_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode Where DirectOutNo='" + s_DirectOutNo + "'";
            KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
            string s_SonID = Bll_ProductsDetails.GetSonIDs("01");
            s_SonID = s_SonID.Replace(",", "','");
            s_Sql += " and b.ProductsType in ('" + s_SonID + "') ";

            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Result.Rows.Count; i++)
                {
                    s_Return = Dtb_Result.Rows[i]["DirectOutAmount"].ToString();
                }
            }
        }
        return s_Return;
    }
    public string Base_GetShipDetailNumbers(string s_DirectOutNo)
    {
        string s_Return = "";
        this.BeginQuery("Select Sum(DirectOutAmount+Isnull(KWD_BNumber,0)) as DirectOutAmount from KNet_WareHouse_DirectOutList_Details a join KNet_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode Where ProductsType<>'M130704050932527' and DirectOutNo='" + s_DirectOutNo + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return = Dtb_Result.Rows[i]["DirectOutAmount"].ToString();
            }
        }
        return s_Return;
    }



    /// <summary>
    /// 销售发货
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string Base_GetOutWareProductsPatten(string s_OutWareNo)
    {
        string s_Return = "";
        this.BeginQuery("Select distinct ProductsBarCode,ProductsPattern from KNet_Sales_OutWareList_Details Where OutWareNo='" + s_OutWareNo + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += this.Base_GetProductsEdition_Link(Dtb_Result.Rows[i]["ProductsBarCode"].ToString()) + "<br>";
                if (this.Base_GetProductsEdition(Dtb_Result.Rows[i]["ProductsBarCode"].ToString()) == "")
                {
                    s_Return = s_Return.Substring(0, s_Return.Length - 1);
                    s_Return += Dtb_Result.Rows[i]["ProductsPattern"].ToString() + "<br>";
                }
            }
        }
        return s_Return;
    }
    /// <summary>
    /// 销售发货总数量
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string Base_GetOutWareDetailNumbers(string s_OutWareNo)
    {
        string s_Return = "0";
        this.BeginQuery("Select Sum(OutWareAmount+ISNull(KSD_BNumber,0)) as OutWareAmount from KNet_Sales_OutWareList_Details Where OutWareNo='" + s_OutWareNo + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return = Dtb_Result.Rows[i]["OutWareAmount"].ToString();
            }
        }
        return s_Return;
    }
    /// <summary>
    /// 采购入库类型
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string Base_GetWareHouseDetailProductsPatten(string s_Order)
    {
        string s_Return = "";
        this.BeginQuery("Select * from Knet_Procure_WareHouseList_Details Where WareHouseNo='" + s_Order + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += Dtb_Result.Rows[i]["ProductsPattern"].ToString() + ",";
                if (Dtb_Result.Rows[i]["ProductsPattern"].ToString() == "")
                {
                    s_Return += Dtb_Result.Rows[i]["ProductsName"].ToString() + ",";
                }
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 1);
        }
        return s_Return;
    }

    /// <summary>
    /// 采购入库总数量
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string Base_GetWareHouseNumbers(string s_Order)
    {
        string s_Return = "";
        this.BeginQuery("Select Sum(WareHouseAmount) as OrderAmount from Knet_Procure_WareHouseList_Details Where WareHouseNo='" + s_Order + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return = Dtb_Result.Rows[i]["OrderAmount"].ToString();
            }
        }
        return s_Return;
    }

    /// <summary>
    /// 退货产品类型
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string Base_GetReturnProductsPatten(string s_Order)
    {
        string s_Return = "";
        this.BeginQuery("Select * from KNet_Sales_ReturnList_Details Where ReturnNo='" + s_Order + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += Base_GetProductsEdition(Dtb_Result.Rows[i]["ProductsBarCode"].ToString()) + ",";
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 1);
        }
        return s_Return;
    }

    /// <summary>
    /// 退货产品总数量
    /// </summary>
    /// <param name="s_Order"></param>
    /// <returns></returns>
    public string Base_GetReturnNumbers(string s_Order)
    {
        string s_Return = "";
        this.BeginQuery("Select Sum(ReturnAmount) as OrderAmount from KNet_Sales_ReturnList_Details Where ReturnNo='" + s_Order + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return = Dtb_Result.Rows[i]["OrderAmount"].ToString();
            }
        }
        return s_Return;
    }


    public string Base_GetContractProductsPatten(string s_Contract)
    {
        string s_Return = "";
        this.BeginQuery("Select * from KNet_Sales_ContractList_Details  Where ContractNo='" + s_Contract + "' Order by ProductsBarCode");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += this.Base_GetProductsEdition_Link(Dtb_Result.Rows[i]["ProductsBarCode"].ToString()) + "<br/>";
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 5);
        }
        return s_Return;
    }


    public string Base_GetContractProductsPattenNumber(string s_Contract)
    {
        string s_Return = "";
        this.BeginQuery("Select * from KNet_Sales_ContractList_Details  Where ContractNo='" + s_Contract + "' Order by ProductsBarCode");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += this.FormatNumber1(Dtb_Result.Rows[i]["ContractAmount"].ToString(), 0) + "<br/>";
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 5);
        }
        return s_Return;
    }

    public string Base_GetContractProductsPattenBNumber(string s_Contract)
    {
        string s_Return = "";
        this.BeginQuery("Select * from KNet_Sales_ContractList_Details  Where ContractNo='" + s_Contract + "' Order by ProductsBarCode");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return += this.FormatNumber1(Dtb_Result.Rows[i]["KSC_BNumber"].ToString(), 0) + "<br/>";
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 5);
        }
        return s_Return;
    }
    public string Base_GetContractAmount(string s_Contract)
    {
        int d_Return = 0;
        this.BeginQuery("Select * from KNet_Sales_ContractList_Details Where ContractNo='" + s_Contract + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                d_Return += int.Parse(Dtb_Result.Rows[i]["ContractAmount"].ToString());
            }
        }
        return d_Return.ToString();
    }

    public string Base_GetContractAmount(string s_Contract, string s_ProductsBarCode)
    {
        int d_Return = 0;
        this.BeginQuery("Select * from KNet_Sales_ContractList_Details Where ProductsBarCode='" + s_ProductsBarCode + "' and ContractNo='" + s_Contract + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                d_Return += int.Parse(Dtb_Result.Rows[i]["ContractAmount"].ToString());
            }
        }
        return d_Return.ToString();
    }

    public string Base_GetContractProductsEdition(string s_Contract)
    {
        string s_Return = "";
        this.BeginQuery("Select * from KNet_Sales_ContractList_Details Where ContractNo='" + s_Contract + "'");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                if (this.Base_GetProductsEdition(Dtb_Result.Rows[i]["ProductsBarCode"].ToString()) == "")
                {
                    s_Return += this.Base_GetProductsPattern(Dtb_Result.Rows[i]["ProductsBarCode"].ToString()) + ",";
                }
                else
                {

                    s_Return += this.Base_GetProductsEdition(Dtb_Result.Rows[i]["ProductsBarCode"].ToString()) + ",";
                }
            }
            s_Return = s_Return.Substring(0, s_Return.Length - 1);
        }
        return s_Return;
    }

    ///判断是否发货通知已经发货
    public string Base_ShipIsDirectOut(string s_ShipNo)
    {
        string s_Retrun = "";
        int s_Count = 0;
        int i_FH = 0;
        this.BeginQuery("Select * from KNet_Sales_OutWareList_FlowList a join Knet_WareHouse_directOutList b on a.OutWareNo=b.DirectOutNO where b.KWD_ShipNo='" + s_ShipNo + "' and a.KSO_ISFH='101' ");
        this.QueryForDataTable();
        if (Dtb_Result.Rows.Count > 0)
        {
            i_FH = 1;
        }
        string s_Sql = "Select isnull(SUM(isNull(b.DirectOutAmount,0)+isNull(b.KWD_BNumber,0)),0) as Number from KNet_WareHouse_DirectOutList a ";
        s_Sql += " join KNet_WareHouse_DirectOutList_Details b on a.DirectOutNo=b.DirectOutNo ";
        s_Sql += "   join KNet_Sys_Products e on b.ProductsBarCode=e.ProductsBarCode ";
        s_Sql += " Where a.KWD_ShipNo='" + s_ShipNo + "' ";

        KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
        string s_SonID = Bll_ProductsDetails.GetSonIDs("M130703042640846");
        s_SonID = s_SonID.Replace(",", "','");
        s_Sql += " and ProductsType in ('" + s_SonID + "') ";


        decimal d_Amount = Decimal.Parse(Base_GetOutWareDetailNumbers(s_ShipNo));
        this.BeginQuery(s_Sql);
        this.QueryForDataTable();
        DataTable Dtb_Table = this.Dtb_Result;
        if (Dtb_Table.Rows.Count > 0)
        {
            s_Count = Dtb_Table.Rows.Count;
            for (int i = 0; i < Dtb_Table.Rows.Count; i++)
            {
                decimal d_OutAmount = Decimal.Parse(Dtb_Table.Rows[i]["Number"].ToString());
                decimal d_leftAmount = d_Amount - d_OutAmount;

                if (d_OutAmount == 0)
                {

                    s_Retrun = "<font Color='red'>未发货</font>";
                }
                else if (d_leftAmount == 0)
                {
                    if (i_FH == 0)
                    {
                        s_Retrun = "<font Color='Green'>通知发货</font>";

                    }
                    else
                    {
                        s_Retrun = "<font Color='blue'>正常发货</font>";

                    }
                }
                else if (d_leftAmount > 0)
                {
                    s_Retrun = "<font Color='Blue'>部分发货</font>";
                }
                else if (d_leftAmount < 0)
                {
                    s_Retrun = "已多发货";
                }

            }
        }

        return s_Retrun;
    }

    /// <summary>
    /// 返回大类名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    public string Base_GetBigCateNane(object aa)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select ID,BigNo,CateName from KNet_Sys_BigCategories where BigNo='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["CateName"].ToString().Trim();
            }
            else
            {
                return "--";
            }
        }
    }


    /// <summary>
    /// 返回大类名称
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    public string Base_GetProductsType(object aa)
    {
        string s_Return = "";
        try
        {
            string[] s_ProductsCode = aa.ToString().Split(',');
            for (int i = 0; i < s_ProductsCode.Length; i++)
            {
                KNet.BLL.PB_Basic_ProductsClass bll = new KNet.BLL.PB_Basic_ProductsClass();
                if (i == 0)
                {
                    s_Return = bll.GetProductsName(s_ProductsCode[i]);
                }
                else
                {
                    s_Return += "," + bll.GetProductsName(s_ProductsCode[i]);
                }
            }
        }
        catch
        { }
        return s_Return;
    }
    public string FormatNumber(string s_Number, int i_Num)
    {
        string s_Return = "";
        try
        {
            if (decimal.Parse(s_Number) == 0)
            {

                s_Return = "0";
            }
            else
            {
                s_Return = String.Format("{0:N" + i_Num + "}", decimal.Round(decimal.Parse(s_Number), i_Num, MidpointRounding.AwayFromZero));
            }
        }
        catch
        {
            s_Return = "-";
        }
        return s_Return;
    }
    public string FormatNumber1(string s_Number, int i_Num)
    {
        string s_Return = "";
        try
        {
            s_Return = FormatNumber(s_Number, i_Num);
            s_Return = s_Return.Replace(",", "");
        }
        catch
        {
            s_Return = "-";
        }
        return s_Return;
    }

    public string DateToString(string s_Date)
    {
        string s_Return = "";
        try
        {
            s_Date = DateTime.Parse(s_Date).ToShortDateString();
            if ((s_Date != "1900-1-1") && (s_Date != "1900/1/1"))
            {
                s_Return = DateTime.Parse(s_Date).ToShortDateString();
            }
        }
        catch
        {
            s_Return = "-";
        }
        return s_Return;
    }

    public string GetContractState(string s_ContractNo)
    {
        return GetContractState(s_ContractNo, "");
    }


    public string GetContractCgState(string s_ContractNo)
    {
        string s_Return = "";
        string s_Sql = "";
        KNet.BLL.KNet_Sales_ContractList bll = new KNet.BLL.KNet_Sales_ContractList();
        KNet.Model.KNet_Sales_ContractList Model = bll.GetModelB(s_ContractNo);
        if (Model.ContractClass == "129687502761283822")
        {
            s_Return = "<font Color=\"red\">无需采购</font>";
        }
        else if (Model.isOrder == 2)
        {
            s_Return = "<font Color=\"red\">无需采购</font>";
        }
        else if ((Model.isOrder == 1) && (Model.ContractDateTime <= DateTime.Parse("2015-8-1")))
        {
            s_Return = "<a href=\"/Web/SalesShip/Knet_Sales_Ship_Manage_Add.aspx?ContractNo=" + s_ContractNo + "\" ><font Color=\"red\">已采购</font></a>";

        }
        else
        {
            try
            {
                s_Sql = "select Count(*) from KNet_Sales_ContractList_Details a join KNET_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode";
                s_Sql += " where ContractNo like '%" + s_ContractNo + "%' and   b.ProductsType<>'M130704050932527' and a.ProductsBarCode not in (";
                s_Sql += " Select ProductsBarCode from Knet_Procure_OrdersList a join ";
                s_Sql += " Knet_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo";
                s_Sql += " where ContractNos like '%" + s_ContractNo + "%')";
                this.BeginQuery(s_Sql);
                this.QueryForDataTable();
                if (this.Dtb_Result.Rows.Count > 0)
                {
                    string s_NCount = Dtb_Result.Rows[0][0].ToString();
                    s_Sql = "select isnull(Count(*),0) from KNet_Sales_ContractList_Details a join KNET_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode ";
                    s_Sql += " where ContractNo like '%" + s_ContractNo + "%' and b.ProductsType<>'M130704050932527' ";
                    this.BeginQuery(s_Sql);
                    string s_Count = this.QueryForReturn();
                    if (int.Parse(s_NCount) == int.Parse(s_Count))
                    {
                        s_Return = "<font Color=\"blue\">未采购</font>";
                        if (Model.isOrder == 1)
                        {
                            s_Return = "<a href=\"/Web/SalesShip/Knet_Sales_Ship_Manage_Add.aspx?ContractNo=" + s_ContractNo + "\" ><font Color=\"red\">已采购</font></a>";
                        }
                    }
                    else if (int.Parse(s_NCount) == 0)
                    {
                        s_Return = "<a href=\"/Web/SalesShip/Knet_Sales_Ship_Manage_Add.aspx?ContractNo=" + s_ContractNo + "\" ><font Color=\"red\">已采购</font></a>";
                    }
                    else
                    {
                        s_Return = "<font Color=\"green\">部分采购</font>";
                    }

                }
            }
            catch
            { }
        }
        return s_Return;
    }
    public string GetContractState(string s_ContractNo, string s_State)
    {
        string s_Return = "";

        if (s_State == "2")
        {
            s_Return = "<font Color=\"red\">已出库</font>";
        }
        else
        {
            //不管审核状态
            string s_Sql = "";

            s_Sql = "Select b.ProductsBarCode,Sum(b.DirectOutAmount) as DirectOutAmount from KNet_WareHouse_DirectOutList a";
            s_Sql += " join KNet_WareHouse_DirectOutList_Details b on a.DirectOutNo=b.DirectOutNo";
            s_Sql += " where KWD_ShipNo in (select OutWareNo from KNet_Sales_OutWareList where ContractNo='" + s_ContractNo + "') Group by b.ProductsBarCode";
            this.BeginQuery(s_Sql);
            DataTable Dtb_Details1 = (DataTable)this.QueryForDataTable();
            if (Dtb_Details1.Rows.Count > 0)
            {
                int i_Num = 0;
                for (int i = 0; i < Dtb_Details1.Rows.Count; i++)
                {
                    string s_ProductsBarCode = Dtb_Details1.Rows[i]["ProductsBarCode"].ToString();
                    int i_DirectOutNoNumber = int.Parse(Dtb_Details1.Rows[i]["DirectOutAmount"].ToString());
                    int i_ContractNumber = GetContractNumber(s_ContractNo, s_ProductsBarCode);
                    int i_LeftNumber = i_ContractNumber - i_DirectOutNoNumber;
                    if (i_LeftNumber > 0)
                    {
                        i_Num += 1;
                    }
                }
                if (i_Num > 0)//部分发货
                {
                    s_Return = "<font Color=\"green\">部分出库</font>";
                }
                if (i_Num == 0)
                {
                    s_Return = "<font Color=\"red\">已出库</font>";
                }
            }
            else
            {

                s_Sql = "Select b.ProductsBarCode,Sum(b.OutWareAmount) as OutWareAmount  from  KNet_Sales_OutWareList a join KNet_Sales_OutWareList_Details b on a.OutWareNo=b.OutWareNo where ContractNo='" + s_ContractNo + "' Group by b.ProductsBarCode";
                this.BeginQuery(s_Sql);
                DataTable Dtb_Details = (DataTable)this.QueryForDataTable();
                if (Dtb_Details.Rows.Count > 0)
                {
                    int i_Num = 0;
                    for (int i = 0; i < Dtb_Details.Rows.Count; i++)
                    {
                        string s_ProductsBarCode = Dtb_Details.Rows[i]["ProductsBarCode"].ToString();
                        int i_OutWareNumber = int.Parse(Dtb_Details.Rows[i]["OutWareAmount"].ToString());
                        int i_ContractNumber = GetContractNumber(s_ContractNo, s_ProductsBarCode);
                        int i_LeftNumber = i_ContractNumber - i_OutWareNumber;
                        if (i_LeftNumber > 0)
                        {
                            i_Num += 1;
                        }
                    }
                    if (i_Num > 0)//部分发货
                    {
                        s_Return = "<font Color=\"green\">部分发货通知</font>";
                    }
                    if (i_Num == 0)
                    {
                        s_Return = "<font Color=\"red\">已发货通知</font>";
                    }
                }
                else
                {

                    KNet.BLL.KNet_Sales_ContractList bll = new KNet.BLL.KNet_Sales_ContractList();
                    KNet.Model.KNet_Sales_ContractList Model = bll.GetModelB(s_ContractNo);
                    if (Model.ContractClass == "129687502761283822")
                    {
                        s_Return = "<font Color=\"red\">无需采购</font>";
                    }
                    else if (Model.isOrder == 2)
                    {
                        s_Return = "<font Color=\"red\">无需采购</font>";
                    }
                    else if ((Model.isOrder == 1) && (Model.ContractDateTime <= DateTime.Parse("2015-8-1")))
                    {
                        s_Return = "<a href=\"/Web/SalesShip/Knet_Sales_Ship_Manage_Add.aspx?ContractNo=" + s_ContractNo + "\" ><font Color=\"red\">已采购</font></a>";

                    }
                    else
                    {
                        try
                        {
                            s_Sql = "select Count(*) from KNet_Sales_ContractList_Details a join KNET_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode";
                            s_Sql += " where ContractNo like '%" + s_ContractNo + "%' and   b.ProductsType<>'M130704050932527' and a.ProductsBarCode not in (";
                            s_Sql += " Select ProductsBarCode from Knet_Procure_OrdersList a join ";
                            s_Sql += " Knet_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo";
                            s_Sql += " where ContractNos like '%" + s_ContractNo + "%')";
                            this.BeginQuery(s_Sql);
                            this.QueryForDataTable();
                            if (this.Dtb_Result.Rows.Count > 0)
                            {
                                string s_NCount = Dtb_Result.Rows[0][0].ToString();
                                s_Sql = "select isnull(Count(*),0) from KNet_Sales_ContractList_Details a join KNET_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode ";
                                s_Sql += " where ContractNo like '%" + s_ContractNo + "%' and b.ProductsType<>'M130704050932527' ";
                                this.BeginQuery(s_Sql);
                                string s_Count = this.QueryForReturn();
                                if (int.Parse(s_NCount) == int.Parse(s_Count))
                                {
                                    s_Return = "<font Color=\"blue\">未采购</font>";
                                    if (Model.isOrder == 1)
                                    {
                                        s_Return = "<a href=\"/Web/SalesShip/Knet_Sales_Ship_Manage_Add.aspx?ContractNo=" + s_ContractNo + "\" ><font Color=\"red\">已采购</font></a>";
                                    }
                                }
                                else if (int.Parse(s_NCount) == 0)
                                {
                                    s_Return = "<a href=\"/Web/SalesShip/Knet_Sales_Ship_Manage_Add.aspx?ContractNo=" + s_ContractNo + "\" ><font Color=\"red\">已采购</font></a>";
                                }
                                else
                                {
                                    s_Return = "<font Color=\"green\">部分采购</font>";
                                }
                            }
                        }
                        catch
                        { }
                    }

                }
            }
        }
        return s_Return;
    }

    public string GetCgState(string s_ContractNo)
    {

        //不管审核状态
        string s_Return = "";
        string s_Sql = "";
        KNet.BLL.KNet_Sales_ContractList bll = new KNet.BLL.KNet_Sales_ContractList();
        KNet.Model.KNet_Sales_ContractList Model = bll.GetModelB(s_ContractNo);
        if (Model.ContractClass == "129687502761283822")
        {
            s_Return = "<font Color=\"red\">无需采购</font>";
        }
        else if ((Model.isOrder == 1) && (Model.ContractDateTime <= DateTime.Parse("2015-8-1")))
        {
            s_Return = "<a href=\"/Web/SalesShip/Knet_Sales_Ship_Manage_Add.aspx?ContractNo=" + s_ContractNo + "\" ><font Color=\"red\">已采购</font></a>";

        }
        else
        {
            try
            {
                s_Sql = "select Count(*) from KNet_Sales_ContractList_Details";
                s_Sql += " where ContractNo like '%" + s_ContractNo + "%' and ProductsBarCode not in (";
                s_Sql += " Select ProductsBarCode from Knet_Procure_OrdersList a join ";
                s_Sql += " Knet_Procure_OrdersList_Details b on a.OrderNo=b.OrderNo";
                s_Sql += " where ContractNos like '%" + s_ContractNo + "%')";
                this.BeginQuery(s_Sql);
                this.QueryForDataTable();
                if (this.Dtb_Result.Rows.Count > 0)
                {
                    string s_NCount = Dtb_Result.Rows[0][0].ToString();
                    s_Sql = "select isnull(Count(*),0) from KNet_Sales_ContractList_Details";
                    s_Sql += " where ContractNo like '%" + s_ContractNo + "%' ";
                    this.BeginQuery(s_Sql);
                    string s_Count = this.QueryForReturn();
                    if (int.Parse(s_NCount) == int.Parse(s_Count))
                    {
                        s_Return = "0";//未采购
                        if (Model.isOrder == 1)
                        {

                            s_Return = "1";//已采购
                        }
                    }
                    else if (int.Parse(s_NCount) == 0)
                    {
                        s_Return = "1";//已采购
                    }
                    else
                    {
                        s_Return = "2";//部分采购
                    }

                }
            }
            catch
            { }
        }
        return s_Return;
    }
    public int GetContractNumber(string s_ContractNo, string s_ProductsBarCode)
    {
        this.BeginQuery("Select * from KNet_Sales_ContractList_Details Where ContractNo='" + s_ContractNo + "' and ProductsBarCode='" + s_ProductsBarCode + "' ");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            return int.Parse(Dtb_Result.Rows[0]["ContractAmount"].ToString());
        }
        else
        {
            return 0;
        }
    }
    /// <summary>
    /// 得到供应商地址
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string Base_GetSuppNoAddress(string SuppNoVale)
    {
        StringBuilder Sb_Return = new StringBuilder();
        /*  this.BeginQuery("Select * from Knet_Procure_OrdersList Where receiveSuppNo='" + SuppNoVale + "' Order by OrderDateTime desc");
          this.QueryForDataTable();
          if (this.Dtb_Result.Rows.Count > 0)
          {
              Sb_Return.Append(this.Dtb_Result.Rows[0]["ContractAddress"].ToString()).Replace("\r\n", "$");
          }
          else
          {*/
        this.BeginQuery("Select SuppAddress,SuppName,SuppPeople,SuppMobiTel,SuppPhone From Knet_Procure_Suppliers Where SuppNo='" + SuppNoVale + "'");
        this.QueryForDataTable();
        Sb_Return.Append("地址: " + this.Dtb_Result.Rows[0][0].ToString() + "$");
        Sb_Return.Append(this.Dtb_Result.Rows[0][1].ToString() + "$");
        Sb_Return.Append("收货人: " + this.Dtb_Result.Rows[0][2].ToString() + "$");
        if (this.Dtb_Result.Rows[0][3].ToString() != "")
        {
            Sb_Return.Append("联系电话:" + this.Dtb_Result.Rows[0][3].ToString() + "$");
        }
        else
        {
            Sb_Return.Append("联系手机:" + this.Dtb_Result.Rows[0][4].ToString() + "$");
        }
        /*
        }*/
        return Sb_Return.ToString();
    }

    public string Base_BindView(string s_Table, string s_Url, string s_ID)
    {
        StringBuilder Sb_Return = new StringBuilder();
        try
        {
            this.BeginQuery("Select * from PB_Basic_Where where PBW_Del=0 and PBW_Type='101' and PBW_Table='" + s_Table + "' order by PBW_Order ");
            this.QueryForDataTable();
            DataTable Dtb_Where = Dtb_Result;
            if (Dtb_Where.Rows.Count > 0)
            {
                Sb_Return.Append("<table class=\"list_table\" style=\"margin-top:2px;\" border=\"0\" cellpadding=\"3\" cellspacing=\"1\" width=\"100%\">\n");
                Sb_Return.Append("<tr><td align=\"left\">\n<img src=\"/themes/images/filter.png\" border=0 width=\"1%\">\n视图:");
                for (int i = 0; i < Dtb_Where.Rows.Count; i++)
                {
                    Sb_Return.Append("<span style=\"padding-right:5px;padding-top:5px;padding-bottom:5px;\">&nbsp;&nbsp;");
                    Sb_Return.Append("<a ");
                    if (s_ID == Dtb_Where.Rows[i]["PBW_ID"].ToString())
                    {
                        Sb_Return.Append("class=\"cus_markbai tablink\" ");
                    }
                    else
                    {
                        Sb_Return.Append("class=\"cus_markhui tablink\" ");
                    }
                    Sb_Return.Append(" href=\"" + s_Url + "?WhereID=" + Dtb_Where.Rows[i]["PBW_ID"].ToString() + "\">" + Dtb_Where.Rows[i]["PBW_Name"].ToString() + "</a>");
                    if (isModiy != "0")
                    {
                        Sb_Return.Append("<a href=\"/Web/Where/PB_Basic_Where_Add.aspx?ID=" + Dtb_Where.Rows[i]["PBW_ID"].ToString() + "\" target=\"_blank\">编辑</a>");
                    }
                    Sb_Return.Append("&nbsp;&nbsp;</span>\n");
                }

                if (isModiy != "0")
                {
                    Sb_Return.Append("   <a href=\"/Web/Where/PB_Basic_Where_Add.aspx?Table=" + s_Table + "&SType=101\" target=\"_blank\">新增</a>");
                }
                Sb_Return.Append("</td>\n</tr>\n</table>\n");
            }
            else
            {
                if (isModiy != "0")
                {
                    Sb_Return.Append("   <a href=\"/Web/Where/PB_Basic_Where_Add.aspx?Table=" + s_Table + "&SType=101\" target=\"_blank\">新增</a>");
                }
            }

            //如果是修改 显示查询条件
            if (isModiy != "0")
            {
                this.BeginQuery("Select * from PB_Basic_Where where PBW_Del=0 and PBW_Type='103' and PBW_Table='" + s_Table + "' order by PBW_Order ");
                this.QueryForDataTable();
                DataTable Dtb_WhereCloumn = Dtb_Result;
                if (Dtb_WhereCloumn.Rows.Count > 0)
                {
                    Sb_Return.Append("<table class=\"list_table\" style=\"margin-top:2px;\" border=\"0\" cellpadding=\"3\" cellspacing=\"1\" width=\"100%\">\n");
                    Sb_Return.Append("<tr><td align=\"left\">\n<img src=\"/themes/images/filter.png\" border=0 width=\"1%\">\n查询条件:");
                    for (int i = 0; i < Dtb_WhereCloumn.Rows.Count; i++)
                    {
                        Sb_Return.Append("<span style=\"padding-right:5px;padding-top:5px;padding-bottom:5px;\">&nbsp;&nbsp;");
                        Sb_Return.Append("<a ");
                        if (s_ID == Dtb_WhereCloumn.Rows[i]["PBW_ID"].ToString())
                        {
                            Sb_Return.Append("class=\"cus_markbai tablink\" ");
                        }
                        else
                        {
                            Sb_Return.Append("class=\"cus_markhui tablink\" ");
                        }
                        Sb_Return.Append(" href=\"" + s_Url + "?WhereID=" + Dtb_WhereCloumn.Rows[i]["PBW_ID"].ToString() + "\">" + Dtb_WhereCloumn.Rows[i]["PBW_Name"].ToString() + "</a>");
                        if (isModiy != "0")
                        {
                            Sb_Return.Append("<a href=\"/Web/Where/PB_Basic_Where_Add.aspx?ID=" + Dtb_WhereCloumn.Rows[i]["PBW_ID"].ToString() + "\" target=\"_blank\">编辑</a>");
                        }
                        Sb_Return.Append("&nbsp;&nbsp;</span>\n");
                    }

                    if (isModiy != "0")
                    {
                        Sb_Return.Append("   <a href=\"/Web/Where/PB_Basic_Where_Add.aspx?Table=" + s_Table + "&SType=103\" target=\"_blank\">新增</a>");
                    }
                    Sb_Return.Append("</td>\n</tr>\n</table>\n");
                }


                this.BeginQuery("Select * from PB_Basic_Where where PBW_Del=0 and PBW_Type='102' and PBW_Table='" + s_Table + "' order by PBW_Order ");
                this.QueryForDataTable();
                Dtb_WhereCloumn = Dtb_Result;
                if (Dtb_WhereCloumn.Rows.Count > 0)
                {
                    Sb_Return.Append("<table class=\"list_table\" style=\"margin-top:2px;\" border=\"0\" cellpadding=\"3\" cellspacing=\"1\" width=\"100%\">\n");
                    Sb_Return.Append("<tr><td align=\"left\">\n<img src=\"/themes/images/filter.png\" border=0 width=\"1%\">\n下拉框:");
                    for (int i = 0; i < Dtb_WhereCloumn.Rows.Count; i++)
                    {
                        Sb_Return.Append("<span style=\"padding-right:5px;padding-top:5px;padding-bottom:5px;\">&nbsp;&nbsp;");
                        Sb_Return.Append("<a ");
                        if (s_ID == Dtb_WhereCloumn.Rows[i]["PBW_ID"].ToString())
                        {
                            Sb_Return.Append("class=\"cus_markbai tablink\" ");
                        }
                        else
                        {
                            Sb_Return.Append("class=\"cus_markhui tablink\" ");
                        }
                        Sb_Return.Append(" href=\"" + s_Url + "?WhereID=" + Dtb_WhereCloumn.Rows[i]["PBW_ID"].ToString() + "\">" + Dtb_WhereCloumn.Rows[i]["PBW_Name"].ToString() + "</a>");
                        if (isModiy != "0")
                        {
                            Sb_Return.Append("<a href=\"/Web/Where/PB_Basic_Where_Add.aspx?ID=" + Dtb_WhereCloumn.Rows[i]["PBW_ID"].ToString() + "\" target=\"_blank\">编辑</a>");
                        }
                        Sb_Return.Append("&nbsp;&nbsp;</span>\n");
                    }

                    if (isModiy != "0")
                    {
                        Sb_Return.Append("   <a href=\"/Web/Where/PB_Basic_Where_Add.aspx?Table=" + s_Table + "&SType=102\" target=\"_blank\">新增</a>");
                    }
                    Sb_Return.Append("</td>\n</tr>\n</table>\n");
                }
            }
        }
        catch
        {

        }
        return Sb_Return.ToString();
    }


    public string Base_BindViewByTitle(string s_Title, string s_Table, string s_Url, string s_ID, string s_Where)
    {
        StringBuilder Sb_Return = new StringBuilder();
        try
        {
            this.BeginQuery("Select * from PB_Basic_Where where PBW_Del=0 and PBW_Type='101' and PBW_Table='" + s_Table + "' " + s_Where + " order by PBW_Order");
            this.QueryForDataTable();
            DataTable Dtb_Where = Dtb_Result;
            if (Dtb_Where.Rows.Count > 0)
            {
                Sb_Return.Append("<table class=\"list_table\" style=\"margin-top:2px;\" border=\"0\" cellpadding=\"3\" cellspacing=\"1\" width=\"100%\">\n");
                Sb_Return.Append("<tr><td align=\"left\">\n<img src=\"/themes/images/filter.png\" border=0 width=\"1%\">\n" + s_Title + ":");
                for (int i = 0; i < Dtb_Where.Rows.Count; i++)
                {
                    Sb_Return.Append("<span style=\"padding-right:5px;padding-top:5px;padding-bottom:5px;\">&nbsp;&nbsp;");
                    Sb_Return.Append("<a ");
                    if (s_ID == Dtb_Where.Rows[i]["PBW_ID"].ToString())
                    {
                        Sb_Return.Append("class=\"cus_markbai tablink\" ");
                    }
                    else
                    {
                        Sb_Return.Append("class=\"cus_markhui tablink\" ");
                    }
                    Sb_Return.Append(" href=\"" + s_Url + "?WhereID=" + Dtb_Where.Rows[i]["PBW_ID"].ToString() + "\">" + Dtb_Where.Rows[i]["PBW_Name"].ToString() + "</a>");
                    if (isModiy != "0")
                    {
                        Sb_Return.Append("<a href=\"/Web/Where/PB_Basic_Where_Add.aspx?ID=" + Dtb_Where.Rows[i]["PBW_ID"].ToString() + "\" target=\"_blank\">编辑</a>");
                    }
                    Sb_Return.Append("&nbsp;&nbsp;</span>\n");
                }

                if (isModiy != "0")
                {
                    Sb_Return.Append("   <a href=\"/Web/Where/PB_Basic_Where_Add.aspx?Table=" + s_Table + "&SType=101\" target=\"_blank\">新增</a>");
                }
                Sb_Return.Append("</td>\n</tr>\n</table>\n");
            }

            //如果是修改 显示查询条件
            if (isModiy != "0")
            {
                this.BeginQuery("Select * from PB_Basic_Where where PBW_Del=0 and PBW_Type='103' and PBW_Table='" + s_Table + "' order by PBW_Order ");
                this.QueryForDataTable();
                DataTable Dtb_WhereCloumn = Dtb_Result;
                if (Dtb_WhereCloumn.Rows.Count > 0)
                {
                    Sb_Return.Append("<table class=\"list_table\" style=\"margin-top:2px;\" border=\"0\" cellpadding=\"3\" cellspacing=\"1\" width=\"100%\">\n");
                    Sb_Return.Append("<tr><td align=\"left\">\n<img src=\"/themes/images/filter.png\" border=0 width=\"1%\">\n查询条件:");
                    for (int i = 0; i < Dtb_WhereCloumn.Rows.Count; i++)
                    {
                        Sb_Return.Append("<span style=\"padding-right:5px;padding-top:5px;padding-bottom:5px;\">&nbsp;&nbsp;");
                        Sb_Return.Append("<a ");
                        if (s_ID == Dtb_WhereCloumn.Rows[i]["PBW_ID"].ToString())
                        {
                            Sb_Return.Append("class=\"cus_markbai tablink\" ");
                        }
                        else
                        {
                            Sb_Return.Append("class=\"cus_markhui tablink\" ");
                        }
                        Sb_Return.Append(" href=\"" + s_Url + "?WhereID=" + Dtb_WhereCloumn.Rows[i]["PBW_ID"].ToString() + "\">" + Dtb_WhereCloumn.Rows[i]["PBW_Name"].ToString() + "</a>");
                        if (isModiy != "0")
                        {
                            Sb_Return.Append("<a href=\"/Web/Where/PB_Basic_Where_Add.aspx?ID=" + Dtb_WhereCloumn.Rows[i]["PBW_ID"].ToString() + "\" target=\"_blank\">编辑</a>");
                        }
                        Sb_Return.Append("&nbsp;&nbsp;</span>\n");
                    }

                    if (isModiy != "0")
                    {
                        Sb_Return.Append("   <a href=\"/Web/Where/PB_Basic_Where_Add.aspx?Table=" + s_Table + "&SType=103\" target=\"_blank\">新增</a>");
                    }
                    Sb_Return.Append("</td>\n</tr>\n</table>\n");
                }


                this.BeginQuery("Select * from PB_Basic_Where where PBW_Del=0 and PBW_Type='102' and PBW_Table='" + s_Table + "' order by PBW_Order ");
                this.QueryForDataTable();
                Dtb_WhereCloumn = Dtb_Result;
                if (Dtb_WhereCloumn.Rows.Count > 0)
                {
                    Sb_Return.Append("<table class=\"list_table\" style=\"margin-top:2px;\" border=\"0\" cellpadding=\"3\" cellspacing=\"1\" width=\"100%\">\n");
                    Sb_Return.Append("<tr><td align=\"left\">\n<img src=\"/themes/images/filter.png\" border=0 width=\"1%\">\n下拉框:");
                    for (int i = 0; i < Dtb_WhereCloumn.Rows.Count; i++)
                    {
                        Sb_Return.Append("<span style=\"padding-right:5px;padding-top:5px;padding-bottom:5px;\">&nbsp;&nbsp;");
                        Sb_Return.Append("<a ");
                        if (s_ID == Dtb_WhereCloumn.Rows[i]["PBW_ID"].ToString())
                        {
                            Sb_Return.Append("class=\"cus_markbai tablink\" ");
                        }
                        else
                        {
                            Sb_Return.Append("class=\"cus_markhui tablink\" ");
                        }
                        Sb_Return.Append(" href=\"" + s_Url + "?WhereID=" + Dtb_WhereCloumn.Rows[i]["PBW_ID"].ToString() + "\">" + Dtb_WhereCloumn.Rows[i]["PBW_Name"].ToString() + "</a>");
                        if (isModiy != "0")
                        {
                            Sb_Return.Append("<a href=\"/Web/Where/PB_Basic_Where_Add.aspx?ID=" + Dtb_WhereCloumn.Rows[i]["PBW_ID"].ToString() + "\" target=\"_blank\">编辑</a>");
                        }
                        Sb_Return.Append("&nbsp;&nbsp;</span>\n");
                    }

                    if (isModiy != "0")
                    {
                        Sb_Return.Append("   <a href=\"/Web/Where/PB_Basic_Where_Add.aspx?Table=" + s_Table + "&SType=102\" target=\"_blank\">新增</a>");
                    }
                    Sb_Return.Append("</td>\n</tr>\n</table>\n");


                }
            }
        }
        catch
        {

        }
        return Sb_Return.ToString();
    }

    public string Base_BindViewByTitle(string s_Title, string s_Table, string s_Url, string s_Where, string s_Param, string s_ID, string s_Param1)
    {
        StringBuilder Sb_Return = new StringBuilder();
        try
        {
            this.BeginQuery("Select * from PB_Basic_Where where PBW_Del=0 and PBW_Type='101' and PBW_Table='" + s_Table + "' " + s_Where + " order by PBW_Order");
            this.QueryForDataTable();
            DataTable Dtb_Where = Dtb_Result;
            if (Dtb_Where.Rows.Count > 0)
            {
                Sb_Return.Append("<table class=\"list_table\" style=\"margin-top:2px;\" border=\"0\" cellpadding=\"3\" cellspacing=\"1\" width=\"100%\">\n");
                Sb_Return.Append("<tr><td align=\"left\">\n<img src=\"/themes/images/filter.png\" border=0 width=\"1%\">\n" + s_Title + ":");
                for (int i = 0; i < Dtb_Where.Rows.Count; i++)
                {
                    Sb_Return.Append("<span style=\"padding-right:5px;padding-top:5px;padding-bottom:5px;\">&nbsp;&nbsp;");
                    Sb_Return.Append("<a ");
                    if (s_ID == Dtb_Where.Rows[i]["PBW_ID"].ToString())
                    {
                        Sb_Return.Append("class=\"cus_markbai tablink\" ");
                    }
                    else
                    {
                        Sb_Return.Append("class=\"cus_markhui tablink\" ");
                    }
                    Sb_Return.Append(" href=\"" + s_Url + "?" + s_Param + "=" + Dtb_Where.Rows[i]["PBW_ID"].ToString() + "" + s_Param1 + "\">" + Dtb_Where.Rows[i]["PBW_Name"].ToString() + "</a>");
                    if (isModiy != "0")
                    {
                        Sb_Return.Append("<a href=\"/Web/Where/PB_Basic_Where_Add.aspx?ID=" + Dtb_Where.Rows[i]["PBW_ID"].ToString() + "\" target=\"_blank\">编辑</a>");
                    }
                    Sb_Return.Append("&nbsp;&nbsp;</span>\n");
                }

                Sb_Return.Append("</td>\n</tr>\n</table>\n");
            }

            //如果是修改 显示查询条件
            if (isModiy != "0")
            {
                this.BeginQuery("Select * from PB_Basic_Where where PBW_Del=0 and PBW_Type='103' and PBW_Table='" + s_Table + "' order by PBW_Order ");
                this.QueryForDataTable();
                DataTable Dtb_WhereCloumn = Dtb_Result;
                if (Dtb_WhereCloumn.Rows.Count > 0)
                {
                    Sb_Return.Append("<table class=\"list_table\" style=\"margin-top:2px;\" border=\"0\" cellpadding=\"3\" cellspacing=\"1\" width=\"100%\">\n");
                    Sb_Return.Append("<tr><td align=\"left\">\n<img src=\"/themes/images/filter.png\" border=0 width=\"1%\">\n查询条件:");
                    for (int i = 0; i < Dtb_WhereCloumn.Rows.Count; i++)
                    {
                        Sb_Return.Append("<span style=\"padding-right:5px;padding-top:5px;padding-bottom:5px;\">&nbsp;&nbsp;");
                        Sb_Return.Append("<a ");
                        if (s_ID == Dtb_WhereCloumn.Rows[i]["PBW_ID"].ToString())
                        {
                            Sb_Return.Append("class=\"cus_markbai tablink\" ");
                        }
                        else
                        {
                            Sb_Return.Append("class=\"cus_markhui tablink\" ");
                        }
                        Sb_Return.Append(" href=\"" + s_Url + "?WhereID=" + Dtb_WhereCloumn.Rows[i]["PBW_ID"].ToString() + "\">" + Dtb_WhereCloumn.Rows[i]["PBW_Name"].ToString() + "</a>");
                        if (isModiy != "0")
                        {
                            Sb_Return.Append("<a href=\"/Web/Where/PB_Basic_Where_Add.aspx?ID=" + Dtb_WhereCloumn.Rows[i]["PBW_ID"].ToString() + "\" target=\"_blank\">编辑</a>");
                        }
                        Sb_Return.Append("&nbsp;&nbsp;</span>\n");
                    }

                    if (isModiy != "0")
                    {
                        Sb_Return.Append("   <a href=\"/Web/Where/PB_Basic_Where_Add.aspx?Table=" + s_Table + "&SType=103\" target=\"_blank\">新增</a>");
                    }
                    Sb_Return.Append("</td>\n</tr>\n</table>\n");
                }


                this.BeginQuery("Select * from PB_Basic_Where where PBW_Del=0 and PBW_Type='102' and PBW_Table='" + s_Table + "' order by PBW_Order ");
                this.QueryForDataTable();
                Dtb_WhereCloumn = Dtb_Result;
                if (Dtb_WhereCloumn.Rows.Count > 0)
                {
                    Sb_Return.Append("<table class=\"list_table\" style=\"margin-top:2px;\" border=\"0\" cellpadding=\"3\" cellspacing=\"1\" width=\"100%\">\n");
                    Sb_Return.Append("<tr><td align=\"left\">\n<img src=\"/themes/images/filter.png\" border=0 width=\"1%\">\n下拉框:");
                    for (int i = 0; i < Dtb_WhereCloumn.Rows.Count; i++)
                    {
                        Sb_Return.Append("<span style=\"padding-right:5px;padding-top:5px;padding-bottom:5px;\">&nbsp;&nbsp;");
                        Sb_Return.Append("<a ");
                        if (s_ID == Dtb_WhereCloumn.Rows[i]["PBW_ID"].ToString())
                        {
                            Sb_Return.Append("class=\"cus_markbai tablink\" ");
                        }
                        else
                        {
                            Sb_Return.Append("class=\"cus_markhui tablink\" ");
                        }
                        Sb_Return.Append(" href=\"" + s_Url + "?WhereID=" + Dtb_WhereCloumn.Rows[i]["PBW_ID"].ToString() + "\">" + Dtb_WhereCloumn.Rows[i]["PBW_Name"].ToString() + "</a>");
                        if (isModiy != "0")
                        {
                            Sb_Return.Append("<a href=\"/Web/Where/PB_Basic_Where_Add.aspx?ID=" + Dtb_WhereCloumn.Rows[i]["PBW_ID"].ToString() + "\" target=\"_blank\">编辑</a>");
                        }
                        Sb_Return.Append("&nbsp;&nbsp;</span>\n");
                    }

                    if (isModiy != "0")
                    {
                        Sb_Return.Append("   <a href=\"/Web/Where/PB_Basic_Where_Add.aspx?Table=" + s_Table + "&SType=102\" target=\"_blank\">新增</a>");
                    }
                    Sb_Return.Append("</td>\n</tr>\n</table>\n");


                }
            }
        }
        catch
        {

        }
        return Sb_Return.ToString();
    }

    public void Base_DropBindSearch(DropDownList Ddl, string s_Table)
    {
        StringBuilder Sb_Return = new StringBuilder();
        try
        {
            this.BeginQuery("Select * from PB_Basic_Where where PBW_Del=0 and PBW_Type='103' and PBW_Table='" + s_Table + "' order by PBW_Order ");
            this.QueryForDataTable();
            DataTable Dtb_Where = Dtb_Result;
            if (Dtb_Where.Rows.Count > 0)
            {
                Ddl.DataSource = Dtb_Where;
                Ddl.DataTextField = "PBW_Name";
                Ddl.DataValueField = "PBW_ID";
                Ddl.DataBind();
            }
        }
        catch
        {
        }
    }
    public string Base_GetFlowName(string s_ID)
    {
        string s_Return = "";
        try
        {
            this.BeginQuery("Select * from PB_Flow_Manage where  PFM_ID='" + s_ID + "'");
            this.QueryForDataTable();
            DataTable Dtb_Where = Dtb_Result;
            if (Dtb_Where.Rows.Count > 0)
            {
                s_Return = Dtb_Where.Rows[0]["PFM_Name"].ToString();
            }
        }
        catch
        {
        }
        return s_Return;
    }

    public string Base_GetFlowName(string s_ID, bool b_IsDetails)
    {
        string s_Return = "";
        try
        {
            this.BeginQuery("Select * from PB_Flow_Manage where  PFM_ID='" + s_ID + "'");
            this.QueryForDataTable();
            DataTable Dtb_Where = Dtb_Result;
            if (Dtb_Where.Rows.Count > 0)
            {
                s_Return = Dtb_Where.Rows[0]["PFM_Name"].ToString();
                if (b_IsDetails == true)
                {
                    s_Return += "(" + Dtb_Where.Rows[0]["PFM_Details"].ToString() + ")";
                }
            }
        }
        catch
        {
        }
        return s_Return;
    }
    public void Base_DropBindFlow(DropDownList Ddl, string s_Code)
    {
        StringBuilder Sb_Return = new StringBuilder();
        try
        {
            this.BeginQuery("Select * from PB_Flow_Manage where PFM_Del=0 and PFM_Code='" + s_Code + "'");
            this.QueryForDataTable();
            DataTable Dtb_Where = Dtb_Result;
            if (Dtb_Where.Rows.Count > 0)
            {
                Ddl.DataSource = Dtb_Where;
                Ddl.DataTextField = "PFM_Name";
                Ddl.DataValueField = "PFM_ID";
                Ddl.DataBind();
            }
        }
        catch
        {
        }
    }
    public string Base_GetBindSearch(string s_Table)
    {
        return Base_GetBindSearch(s_Table, "");
    }
    public string Base_GetBindSearch(string s_Table, string s_Value)
    {
        StringBuilder Sb_Return = new StringBuilder();
        string s_Selected = "";
        try
        {
            this.BeginQuery("Select * from PB_Basic_Where where PBW_Del=0 and PBW_Type='103' and PBW_Table='" + s_Table + "'  order by PBW_Order ");
            this.QueryForDataTable();
            DataTable Dtb_Where = Dtb_Result;
            if (Dtb_Where.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Where.Rows.Count; i++)
                {
                    if (s_Value == Dtb_Where.Rows[i]["PBW_ID"].ToString())
                    {
                        s_Selected = "selected";
                    }
                    else
                    {
                        s_Selected = "";
                    }
                    Sb_Return.Append("<option value=" + Dtb_Where.Rows[i]["PBW_ID"].ToString() + " " + s_Selected + ">" + Dtb_Where.Rows[i]["PBW_Name"].ToString() + "</option>");

                }
            }
        }
        catch
        {
        }
        return Sb_Return.ToString();
    }
    public string Base_GetBasicWhere(string s_ID)
    {
        AdminloginMess AM = new AdminloginMess();
        StringBuilder Sb_Return = new StringBuilder();
        try
        {
            if (s_ID.IndexOf("=") > 0)
            {
                Sb_Return.Append(s_ID);
            }
            else
            {
                this.BeginQuery("Select * from PB_Basic_Where where PBW_ID='" + s_ID + "'  order by PBW_Order ");
                this.QueryForDataTable();
                DataTable Dtb_Where = Dtb_Result;
                if (Dtb_Where.Rows.Count > 0)
                {
                    string s_Sql = Dtb_Where.Rows[0]["PBW_Sql"].ToString().Replace("&Person", AM.KNet_StaffNo);
                    s_Sql = Dtb_Where.Rows[0]["PBW_Sql"].ToString().Replace("&Now", "'" + DateTime.Now.ToShortDateString() + "'");
                    Sb_Return.Append(s_Sql);
                }
            }

        }
        catch
        {

        }
        return Sb_Return.ToString();
    }
    public string Base_GetBasicColumnWhere(string s_ID, string s_Text)
    {
        StringBuilder Sb_Return = new StringBuilder();
        try
        {
            this.BeginQuery("Select * from PB_Basic_Where where PBW_ID='" + s_ID + "'  order by PBW_Order ");
            this.QueryForDataTable();
            DataTable Dtb_Where = Dtb_Result;
            if (Dtb_Where.Rows.Count > 0)
            {
                string s_Cloumn = Dtb_Where.Rows[0]["PBW_Cloumn"] == null ? "" : Dtb_Where.Rows[0]["PBW_Cloumn"].ToString();
                string s_FromTable = Dtb_Where.Rows[0]["PBW_FromTable"] == null ? "" : Dtb_Where.Rows[0]["PBW_FromTable"].ToString();
                string s_FromValue = Dtb_Where.Rows[0]["PBW_FromValue"] == null ? "" : Dtb_Where.Rows[0]["PBW_FromValue"].ToString();
                string s_FromName = Dtb_Where.Rows[0]["PBW_FromName"] == null ? "" : Dtb_Where.Rows[0]["PBW_FromName"].ToString();
                string s_FromWhere = Dtb_Where.Rows[0]["PBW_FromWhere"] == null ? "" : Dtb_Where.Rows[0]["PBW_FromWhere"].ToString();
                if (s_FromTable != "")
                {
                    if (s_FromWhere != "")
                    {
                        s_FromWhere += " and ";
                    }
                    if (s_Cloumn == "SuppNo" && s_FromTable == "Knet_Procure_Suppliers")
                    {
                        s_Cloumn = "SuppNo";
                    }
                    if (s_Cloumn=="SuppNo" && s_FromTable == "v_House")
                    {
                        s_Cloumn = "HouseNo";
                    }
                    
                    Sb_Return.Append(" and " + s_Cloumn + " in (Select " + s_FromValue + " from " + s_FromTable + " where " + s_FromWhere + "" + s_FromName + " like  '%" + s_Text + "%')  ");
                }
                else
                {
                    Sb_Return.Append(" and " + s_Cloumn + " like '%" + s_Text + "%' ");

                }
            }

        }
        catch
        {

        }
        return Sb_Return.ToString();
    }


    public string Base_GetAdvWhere(string s_Fields, string s_Condition, string s_Text, string s_Type)
    {
        AdminloginMess AM = new AdminloginMess();
        StringBuilder Sb_Return = new StringBuilder();
        try
        {
            string[] arr_Fields = s_Fields.Split(',');
            string[] arr_Condition = s_Condition.Split(',');
            string[] arr_Text = s_Text.Split(',');


            for (int i = 0; i < arr_Fields.Length; i++)
            {
                this.BeginQuery("Select * from PB_Basic_Where where PBW_ID='" + arr_Fields[i] + "'  order by PBW_Order  ");
                this.QueryForDataTable();
                DataTable Dtb_Where = Dtb_Result;
                if (Dtb_Where.Rows.Count > 0)
                {
                    string s_Cloumn = Dtb_Where.Rows[0]["PBW_Cloumn"] == null ? "" : Dtb_Where.Rows[0]["PBW_Cloumn"].ToString();
                    string s_FromTable = Dtb_Where.Rows[0]["PBW_FromTable"] == null ? "" : Dtb_Where.Rows[0]["PBW_FromTable"].ToString();
                    string s_FromValue = Dtb_Where.Rows[0]["PBW_FromValue"] == null ? "" : Dtb_Where.Rows[0]["PBW_FromValue"].ToString();
                    string s_FromName = Dtb_Where.Rows[0]["PBW_FromName"] == null ? "" : Dtb_Where.Rows[0]["PBW_FromName"].ToString();
                    string s_FromWhere = Dtb_Where.Rows[0]["PBW_FromWhere"] == null ? "" : Dtb_Where.Rows[0]["PBW_FromWhere"].ToString();
                    // and (condition1 and condition2)
                    // and (condition1 or condition2)
                    if (arr_Fields.Length > 1)
                    {
                        if (i == 0)  // 第一个条件
                        {
                            Sb_Return.Append(" and (");
                        }
                        else  //非第一个条件
                        {
                            if (s_Type == "0")//全部满足
                            {
                                Sb_Return.Append(" and ");
                            }
                            else
                            {
                                Sb_Return.Append(" or ");
                            }
                        }
                    }
                    else
                    {
                        Sb_Return.Append(" and ");
                    }
                    if (s_FromTable != "")
                    {

                        if (s_FromWhere != "")
                        {
                            s_FromWhere += " and ";
                        }
                        Sb_Return.Append("  " + s_Cloumn + " in ( Select " + s_FromValue + " from " + s_FromTable + " where  " + s_FromWhere + " " + s_FromName + " " + GetRule(arr_Condition[i].ToString()));
                    }
                    else
                    {
                        Sb_Return.Append("  " + s_Cloumn + " " + GetRule(arr_Condition[i].ToString()) + " ");

                    }
                    if ((arr_Condition[i].ToString() == "cts") || (arr_Condition[i].ToString() == "dcts"))
                    {
                        Sb_Return.Append(" '%" + arr_Text[i].ToString() + "%'  ");
                    }
                    else
                    {
                        Sb_Return.Append(" '" + arr_Text[i].ToString() + "'  ");
                    }

                    if (s_FromTable != "")
                    {
                        Sb_Return.Append(")");
                    }
                    if (arr_Fields.Length > 1 && i == (arr_Fields.Length - 1)) // 多个条件中的最后一个条件
                    {
                        Sb_Return.Append(")");
                    }
                }
            }

        }
        catch (Exception ex)
        {

        }
        return Sb_Return.ToString();
    }
    public string GetRule(string s_Rule)
    {
        string s_Return = "";
        switch (s_Rule)
        {
            case "cts":
                s_Return = "like";
                break;
            case "dcts":
                s_Return = "not like";
                break;
            case "is":
                s_Return = "=";
                break;
            case "isn":
                s_Return = "<>";
                break;
            case "grt":
                s_Return = ">";
                break;
            case "lst":
                s_Return = "<";
                break;
            case "grteq":
                s_Return = ">=";
                break;
            case "lsteq":
                s_Return = "<=";
                break;
        }
        return s_Return;
    }
    public string Base_GetAdvShowHtml(string[] arr_Fields, string[] arr_Condition, string[] arr_Text)
    {
        string s_Return = "";
        try
        {
            if (arr_Fields.Length > 1)
            {
                for (int i = 1; i < arr_Fields.Length; i++)
                {
                    s_Return += "<tr><td><select id='Fields' name='Fields' onchange=\"updatefOptions(this, 'Condition')\" class='txtBox'>" + Base_GetBindSearch("KNet_Sales_ClientList", arr_Fields[i]) + "</select></td>";
                    s_Return += "<td><select id='Condition' name='Condition' class='txtBox'>";

                    s_Return += "<option value=\'cts\' " + (arr_Condition[i] == "cts" ? "selected" : "") + ">包含</option>";
                    s_Return += "<option value=\'dcts\' " + (arr_Condition[i] == "dcts" ? "selected" : "") + ">不包含</option>";
                    s_Return += "<option value=\'is\' " + (arr_Condition[i] == "is" ? "selected" : "") + ">等于</option>";
                    s_Return += "<option value=\'isn\' " + (arr_Condition[i] == "isn" ? "selected" : "") + ">不等于</option>";
                    s_Return += "<option value=\'grt\' " + (arr_Condition[i] == "grt" ? "selected" : "") + ">大于</option>";
                    s_Return += "<option value=\'lst\' " + (arr_Condition[i] == "lst" ? "selected" : "") + ">小于</option>";
                    s_Return += "<option value=\'grteq\' " + (arr_Condition[i] == "grteq" ? "selected" : "") + ">大于等于</option>";
                    s_Return += "<option value=\'lsteq\' " + (arr_Condition[i] == "lsteq" ? "selected" : "") + ">小于等于</option>";
                    s_Return += "</td>";
                    s_Return += "<td><input type='text' id='Srch_value' name='Srch_value' value=" + arr_Text[i] + " class='detailedViewTextBox'></td></tr>";

                }
            }

        }
        catch (Exception ex)
        {
            s_Return = ex.Message;
        }
        return s_Return;
    }

    public string Base_GetAdvShowHtml(string[] arr_Fields, string[] arr_Condition, string[] arr_Text, string s_Table)
    {

        string s_Return = "";
        try
        {
            if (arr_Fields.Length > 1)
            {
                for (int i = 1; i < arr_Fields.Length; i++)
                {
                    s_Return += "<tr><td><select id='Fields' name='Fields' onchange=\"updatefOptions(this, 'Condition')\" class='txtBox'>" + Base_GetBindSearch(s_Table, arr_Fields[i]) + "</select></td>";
                    s_Return += "<td><select id='Condition' name='Condition' class='txtBox'>";

                    s_Return += "<option value=\'cts\' " + (arr_Condition[i] == "cts" ? "selected" : "") + ">包含</option>";
                    s_Return += "<option value=\'dcts\' " + (arr_Condition[i] == "dcts" ? "selected" : "") + ">不包含</option>";
                    s_Return += "<option value=\'is\' " + (arr_Condition[i] == "is" ? "selected" : "") + ">等于</option>";
                    s_Return += "<option value=\'isn\' " + (arr_Condition[i] == "isn" ? "selected" : "") + ">不等于</option>";
                    s_Return += "<option value=\'grt\' " + (arr_Condition[i] == "grt" ? "selected" : "") + ">大于</option>";
                    s_Return += "<option value=\'lst\' " + (arr_Condition[i] == "lst" ? "selected" : "") + ">小于</option>";
                    s_Return += "<option value=\'grteq\' " + (arr_Condition[i] == "grteq" ? "selected" : "") + ">大于等于</option>";
                    s_Return += "<option value=\'lsteq\' " + (arr_Condition[i] == "lsteq" ? "selected" : "") + ">小于等于</option>";
                    s_Return += "</td>";
                    s_Return += "<td><input type='text' id='Srch_value' name='Srch_value' value=" + arr_Text[i] + " class='detailedViewTextBox'></td></tr>";

                }
            }

        }
        catch (Exception ex)
        {
            s_Return = ex.Message;
        }
        return s_Return;
    }

    public void Base_DropBatchBind(DropDownList DDL, string s_Table, string s_Cloumn)
    {
        try
        {
            this.BeginQuery("Select * from PB_Basic_Where where PBW_Del=0 and PBW_Type='102' and PBW_Table='" + s_Table + "' Order by PBW_Order");
            this.QueryForDataTable();
            DataTable Dtb_Where = Dtb_Result;
            DDL.DataSource = Dtb_Result;
            DDL.DataTextField = "PBW_Name";
            DDL.DataValueField = "PBW_ID";
            DDL.DataBind();
            if (s_Cloumn != "")
            {
                KNet.BLL.KNet_Resource_Staff Bll = new KNet.BLL.KNet_Resource_Staff();
                DataSet Dts = Bll.GetList(" StaffNo<>'admin' ");
                if (Dts.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < Dts.Tables[0].Rows.Count; i++)
                    {
                        ListItem item = new ListItem(Dts.Tables[0].Rows[i]["StaffName"].ToString(), " and " + s_Cloumn + "='" + Dts.Tables[0].Rows[i]["StaffNo"].ToString() + "'"); //默认值
                        DDL.Items.Insert(i + Dtb_Where.Rows.Count, item);
                    }
                }
            }
        }
        catch
        {

        }
    }
    public void Base_DropBatchBindBySql(DropDownList DDL, string s_Table, string s_Cloumn, string s_Sql)
    {
        try
        {
            this.BeginQuery("Select * from PB_Basic_Where where PBW_Del=0 and PBW_Type='102' and PBW_Table='" + s_Table + "' Order by PBW_Order");
            this.QueryForDataTable();
            DataTable Dtb_Where = Dtb_Result;
            DDL.DataSource = Dtb_Result;
            DDL.DataTextField = "PBW_Name";
            DDL.DataValueField = "PBW_ID";
            DDL.DataBind();
            if (s_Cloumn != "")
            {
                KNet.BLL.KNet_Resource_Staff Bll = new KNet.BLL.KNet_Resource_Staff();
                DataSet Dts = Bll.GetList(" StaffNo<>'admin' " + s_Sql + "  ");
                if (Dts.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < Dts.Tables[0].Rows.Count; i++)
                    {
                        ListItem item = new ListItem(Dts.Tables[0].Rows[i]["StaffName"].ToString(), " and " + s_Cloumn + "='" + Dts.Tables[0].Rows[i]["StaffNo"].ToString() + "'"); //默认值
                        DDL.Items.Insert(i + Dtb_Where.Rows.Count, item);
                    }
                }
            }
        }
        catch
        {
        }
    }
    public string Base_GetDocumentName(string s_Code)
    {
        KNet.BLL.PB_Basic_Document BLL = new KNet.BLL.PB_Basic_Document();
        return BLL.GetDocumentName(s_Code);
    }
    public string Base_GetOppName(string s_Code)
    {
        KNet.BLL.Xs_Sales_Opp BLL = new KNet.BLL.Xs_Sales_Opp();
        return BLL.GetOPPName(s_Code);
    }

    /// <summary>
    ///银行绑定
    /// </summary> 
    public void Base_DdlBankbind(DropDownList DL)
    {
        KNet.BLL.KNet_Sys_Bank bll = new KNet.BLL.KNet_Sys_Bank();
        DataSet ds = bll.GetAllList();
        DL.DataSource = ds;
        DL.DataTextField = "AA";
        DL.DataValueField = "BankNo";
        DL.DataBind();
        ListItem item = new ListItem("请选择银行（账号）", ""); //默认值
        DL.Items.Insert(0, item);
    }

    /// <summary>
    ///银行绑定
    /// </summary> 
    public void Base_EMail(DropDownList DL)
    {
        AdminloginMess AM = new AdminloginMess();
        KNet.BLL.PB_Mail_Setting bll = new KNet.BLL.PB_Mail_Setting();
        string s_Where = " PMS_Creator='" + AM.KNet_StaffNo + "' and PMS_Del='0' order by PMS_MTime ";
        DataSet ds = bll.GetList(s_Where);
        DL.DataSource = ds;
        DL.DataTextField = "PMS_SendEmail";
        DL.DataValueField = "PMS_ID";
        DL.DataBind();
    }

    /// <summary>
    ///银行绑定
    /// </summary> 
    public string Base_GetBankName(string s_ID)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_Sys_Bank bll = new KNet.BLL.KNet_Sys_Bank();
            KNet.Model.KNet_Sys_Bank Model = bll.GetModel(s_ID);
            s_Return = Model.BankName.ToString();
        }
        catch
        { }
        return s_Return;
    }

    /// <summary>
    ///仓库单价
    /// </summary> 
    public string Base_GetProductsPrice(string s_ProductsBarCode, string s_HouseNo)
    {
        string s_Return = "0";
        this.BeginQuery("Select Sum(DirectInAmount) as Number,Sum(DirectInTotalNet) from V_Store where ProductsBarCode='" + s_ProductsBarCode + "' and HouseNo='" + s_HouseNo + "'  ");
        this.QueryForDataTable();
        DataTable Dtb_Table = Dtb_Result;
        try
        {
            s_Return = FormatNumber(Convert.ToString(decimal.Parse(Dtb_Table.Rows[0][1].ToString()) / decimal.Parse(Dtb_Table.Rows[0][0].ToString())), 3);

        }
        catch
        { }
        return s_Return == "-" ? "0" : s_Return;
    }
    /// <summary>
    ///银行绑定
    /// </summary> 
    public string Base_GetProductsSampleName(string s_ID)
    {
        KNet.BLL.Pb_Products_Sample bll = new KNet.BLL.Pb_Products_Sample();
        KNet.Model.Pb_Products_Sample Model = bll.GetModel(s_ID);
        return Model.PPS_Name.ToString();
    }

    #region 人民币小写金额转大写金额
    /// <summary>
    /// 小写金额转大写金额
    /// </summary>
    /// <param name="Money">接收需要转换的小写金额</param>
    /// <returns>返回大写金额</returns>
    public string ConvertMoney(Decimal Money)
    {
        //金额转换程序
        string MoneyNum = "";//记录小写金额字符串[输入参数]
        string MoneyStr = "";//记录大写金额字符串[输出参数]
        string BNumStr = "零壹贰叁肆伍陆柒捌玖";//模
        string UnitStr = "万仟佰拾亿仟佰拾万仟佰拾圆角分";//模

        MoneyNum = ((long)(Money * 100)).ToString();
        for (int i = 0; i < MoneyNum.Length; i++)
        {
            string DVar = "";//记录生成的单个字符(大写)
            string UnitVar = "";//记录截取的单位
            for (int n = 0; n < 10; n++)
            {
                //对比后生成单个字符(大写)
                if (Convert.ToInt32(MoneyNum.Substring(i, 1)) == n)
                {
                    DVar = BNumStr.Substring(n, 1);//取出单个大写字符
                    //给生成的单个大写字符加单位
                    UnitVar = UnitStr.Substring(15 - (MoneyNum.Length)).Substring(i, 1);
                    n = 10;//退出循环
                }
            }
            //生成大写金额字符串
            MoneyStr = MoneyStr + DVar + UnitVar;
        }
        //二次处理大写金额字符串
        MoneyStr = MoneyStr + "整";
        while (MoneyStr.Contains("零分") || MoneyStr.Contains("零角") || MoneyStr.Contains("零佰") || MoneyStr.Contains("零仟")
            || MoneyStr.Contains("零万") || MoneyStr.Contains("零亿") || MoneyStr.Contains("零零") || MoneyStr.Contains("零圆")
            || MoneyStr.Contains("亿万") || MoneyStr.Contains("零整") || MoneyStr.Contains("分整"))
        {
            MoneyStr = MoneyStr.Replace("零分", "零");
            MoneyStr = MoneyStr.Replace("零角", "零");
            MoneyStr = MoneyStr.Replace("零拾", "零");
            MoneyStr = MoneyStr.Replace("零佰", "零");
            MoneyStr = MoneyStr.Replace("零仟", "零");
            MoneyStr = MoneyStr.Replace("零万", "万");
            MoneyStr = MoneyStr.Replace("零亿", "亿");
            MoneyStr = MoneyStr.Replace("亿万", "亿");
            MoneyStr = MoneyStr.Replace("零零", "零");
            MoneyStr = MoneyStr.Replace("零圆", "圆零");
            MoneyStr = MoneyStr.Replace("零整", "整");
            MoneyStr = MoneyStr.Replace("分整", "分");
        }
        if (MoneyStr == "整")
        {
            MoneyStr = "零元整";
        }
        return MoneyStr;
    }
    #endregion


    public class KDDetails
    {

        private string _status;
        private string _errCode;
        private string _message;
        private string _Data;

        public string status
        {
            set { _status = value; }
            get { return _status; }
        }
        public string errCode
        {
            set { _errCode = value; }
            get { return _errCode; }
        }
        public string message
        {
            set { _message = value; }
            get { return _message; }
        }
        public string Data
        {
            set { _Data = value; }
            get { return _Data; }
        }
    }
    public string GetKDSateName(string s_WareNo)
    {
        string s_Rturn = "";
        this.BeginQuery("Select * from KNet_Sales_OutWareList_FlowList where OutWareNo in (Select DirectOutNo from KNet_WareHouse_DirectOutList where KWD_ShipNo='" + s_WareNo + "'  )and KDCodeName<>'' and KDCode<>'' ");
        this.QueryForDataTable();
        DataTable Dtb_DataTable = this.Dtb_Result;
        if (Dtb_DataTable.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_DataTable.Rows.Count; i++)
            {
                string s_KDName = Dtb_DataTable.Rows[i]["KDName"].ToString();
                string s_Code = Dtb_DataTable.Rows[i]["KDCode"].ToString();
                string s_CodeName = Dtb_DataTable.Rows[i]["KDCodeName"].ToString();
                string s_ID = Dtb_DataTable.Rows[i]["ID"].ToString();
                string s_State = Dtb_DataTable.Rows[i]["State"] == null ? "" : Dtb_DataTable.Rows[i]["State"].ToString();
                if (s_State == "")
                {
                    s_State = GetSignedState(s_CodeName, s_Code);
                    if (s_State == "<Font Color=red>已签收</Font>")
                    {
                        KNet.BLL.KNet_Sales_OutWareList_FlowList BLL_Flow = new KNet.BLL.KNet_Sales_OutWareList_FlowList();
                        KNet.Model.KNet_Sales_OutWareList_FlowList Model_Flow = new KNet.Model.KNet_Sales_OutWareList_FlowList();
                        Model_Flow.ID = s_ID;
                        Model_Flow.State = s_State;
                        BLL_Flow.UpDataSate(Model_Flow);
                    }
                }
                if (s_State != "")
                {
                    s_Rturn += "<a href=\"#\"  onclick=\"javascript:window.open('/Web/Xs/SalesOut/Knet_Sales_Ship_Manage_Talks_Detail.aspx?com=" + s_KDName + "&Code=" + s_Code + "&Name=" + s_CodeName + "','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=850,height=600');\">";
                    s_Rturn += " " + s_State + " </a>" + "<br>";
                }
            }

        }
        return s_Rturn;
    }


    public string GetKDSateNameByWareHouse(string s_WareNo)
    {
        string s_Rturn = "";
        KNet.BLL.Knet_Procure_WareHouseList BLL = new KNet.BLL.Knet_Procure_WareHouseList();
        KNet.Model.Knet_Procure_WareHouseList Model = BLL.GetModelB(s_WareNo);
        if (Model != null)
        {
            string s_KDName = Model.KPO_KDNameCode == null ? "" : Model.KPO_KDNameCode;
            string s_Code = Model.KPO_KDCode == null ? "" : Model.KPO_KDCode.Trim();
            string s_CodeName = Model.KPO_KDName == null ? "" : Model.KPO_KDName;
            string s_State = Model.KPO_State == null ? "" : Model.KPO_State;
            if (s_Code != "")
            {
                s_Code = s_Code.Replace(" ", "");
            }

            if ((s_State != "<Font Color=red>已签收</Font>") && (s_Code != ""))
            {
                s_State = GetSignedState(s_CodeName, s_Code);
                if (s_State == "<Font Color=red>已签收</Font>")
                {
                    Model.KPO_State = s_State;
                    BLL.Update(Model);
                }
            }

            s_Rturn += "<a href=\"#\"  onclick=\"javascript:window.open('/Web/Xs/SalesOut/Knet_Sales_Ship_Manage_Talks_Detail.aspx?com=" + s_KDName + "&Code=" + s_Code + "&Name=" + s_CodeName + "','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=700,height=600');\">";
            s_Rturn += " " + s_State + " </a>" + ",";

            if (s_State == "")
            {

                if ((DateTime.Now.Hour == 8) || (DateTime.Now.Hour == 3))
                {
                    //爱查快递
                    s_State = GetKDSateReturnOlnyStateUseAicha(s_KDName, s_Code, s_CodeName, s_State);
                }
            }
        }
        return s_Rturn == "" ? "" : s_Rturn.Substring(0, s_Rturn.Length - 1);
    }


    //得到快递状态
    public string GetKDSate(string s_KDName, string s_Code, string s_CodeName, string s_State)
    {
        string s_Rturn = "";

        if ((s_State != "<Font Color=red>已签收</Font>") && (s_Code != ""))
        {
            String url = "http://api.ickd.cn/?com=" + s_KDName + "&nu=" + s_Code + "&id=F358C662FEC3E1CAA2C8C20DD2F9A448&type=json";
            string jsonString = "";
            this.BeginQuery("Select * from PB_Basic_Wl where PBW_Name='" + s_CodeName + "'");
            this.QueryForDataTable();
            if (this.Dtb_Result.Rows.Count > 0)
            {

                if (this.Dtb_Result.Rows[0]["PBW_URL"].ToString() != "")
                {
                    WebPage webInfo = new WebPage(this.Dtb_Result.Rows[0]["PBW_Url"].ToString() + s_Code);
                    string s_Detiles = webInfo.M_html.Replace("请输入运单编号", "");
                    if (s_Detiles.IndexOf("签收") > 0)
                    {
                        s_State = "<Font Color=red>已签收</Font>";
                    }
                    else if (s_Detiles.IndexOf("SORRY") > 0)
                    {
                        s_State = "<Font Color=Black>查询失败<Font Color=Blue>";
                    }
                    else
                    {
                        s_State = "<Font Color=Blue>正常</Font>";
                    }
                }
                else
                {
                    try
                    {
                        jsonString = getPageInfo(url);
                        KDDetails KdDetail = JsonHelper.ParseFromJson<KDDetails>(jsonString);
                        s_State = GetSateName(KdDetail.status);
                    }
                    catch (Exception ex)
                    {
                        s_State = "错误！";
                    }
                }
            }
        }
        s_Rturn += "<a href=\"#\"  onclick=\"javascript:window.open('/Web/Xs/SalesShip/Knet_Sales_Ship_Manage_Talks_Detail.aspx?com=" + s_KDName + "&Code=" + s_Code + "&Name=" + s_CodeName + "','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=580,height=250');\">";
        s_Rturn += " " + s_State + " </a>" + ",";
        return s_Rturn == "" ? "" : s_Rturn.Substring(0, s_Rturn.Length - 1);
    }



    //得到快递状态
    public string GetKDSateReturnOlnyState(string s_KDName, string s_Code, string s_CodeName, string s_State)
    {
        if ((s_State != "<Font Color=red>已签收</Font>") && (s_Code != ""))
        {
            //快递100
            String url = "http://api.kuaidi100.com/api?id=3619cd2e53fcf3d0&com=" + s_KDName + "&nu=" + s_Code + "&show=0&muti=1&order=asc";
            //爱查
            //String url = "http://api.ickd.cn/?com=" + s_KDName + "&nu=" + s_Code + "&id=F358C662FEC3E1CAA2C8C20DD2F9A448&type=json";
            string jsonString = "";
            try
            {
                jsonString = getPageInfo(url);
                //  KD100Details KdDetail = JsonHelper.ParseFromJson<KD100Details>(jsonString);
                // s_State = GetSateNameby100(KdDetail.status);
            }
            catch (Exception ex)
            {
                s_State = "错误！";
            }
        }
        return s_State;
    }



    //得到快递状态
    public string GetKDSateReturnOlnyStateUseAicha(string s_KDName, string s_Code, string s_CodeName, string s_State)
    {
        if ((s_State != "<Font Color=red>已签收</Font>") && (s_Code != ""))
        {
            //快递100
            //String url = "http://api.kuaidi100.com/api?id=3619cd2e53fcf3d0&com=" + s_KDName + "&nu=" + s_Code + "&show=0&muti=1&order=asc";
            //爱查
            String url = "http://api.ickd.cn/?com=" + s_KDName + "&nu=" + s_Code + "&id=F358C662FEC3E1CAA2C8C20DD2F9A448&type=json";
            string jsonString = "";
            try
            {
                jsonString = getPageInfo(url);
                KDDetails KdDetail = JsonHelper.ParseFromJson<KDDetails>(jsonString);
                s_State = GetSateName(KdDetail.status);
            }
            catch (Exception ex)
            {
                s_State = "错误！";
            }
        }
        return s_State;
    }
    public static string getPageInfo(String url)
    {
        WebResponse wr_result = null;
        StringBuilder txthtml = new StringBuilder();
        try
        {
            WebRequest wr_req = WebRequest.Create(url);
            wr_req.Timeout = 1000;
            wr_result = wr_req.GetResponse();
            Stream ReceiveStream = wr_result.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("gb2312");
            StreamReader sr = new StreamReader(ReceiveStream, encode);
            if (true)
            {
                Char[] read = new Char[256];
                int count = sr.Read(read, 0, 256);
                while (count > 0)
                {
                    String str = new String(read, 0, count);
                    str = str.Replace("\t", "");
                    txthtml.Append(str);
                    count = sr.Read(read, 0, 256);
                }
            }
        }
        catch (Exception ex)
        {
            txthtml.Append("err");
        }
        finally
        {
            if (wr_result != null)
            {
                wr_result.Close();
            }
        }
        return txthtml.ToString();
    }
    //快递100
    public string GetSateNameby100(string s_ID)
    {
        string s_Return = "";
        switch (int.Parse(s_ID))
        {
            case 0:
                s_Return = "<Font Color=Black>在途<Font Color=Blue>";
                break;
            case 1:
                s_Return = "<Font Color=Blue>揽件</Font>";
                break;
            case 2:
                s_Return = "<Font Color=Blue>疑难</Font>";
                break;
            case 3:
                s_Return = "<Font Color=red>已签收</Font>";
                break;
            case 4:
                s_Return = "<Font Color=red>退签</Font>";
                break;
            case 5:
                s_Return = "<Font Color=Blue>派件</Font>";
                break;
            case 6:
                s_Return = "<Font Color=red>退回</Font>";
                break;
            /*
            0：在途，即货物处于运输过程中；
1：揽件，货物已由快递公司揽收并且产生了第一条跟踪信息；
2：疑难，货物寄送过程出了问题；
3：签收，收件人已签收；
4：退签，即货物由于用户拒签、超区等原因退回，而且发件人已经签收；
5：派件，即快递正在进行同城派件；
6：退回，货物正处于退回发件人的途中；*/
        }
        return s_Return;

    }

    public string GetSateName(string s_ID)
    {
        //爱查
        string s_Return = "";
        //0表示查询失败，1正常，2派送中，3已签收，4退回
        switch (int.Parse(s_ID))
        {
            case 0:
                s_Return = "<Font Color=Black>单号不存在<Font Color=Blue>";
                break;
            case 1:
                s_Return = "<Font Color=Blue>正常</Font>";
                break;
            case 2:
                s_Return = "<Font Color=Green>派送中</Font>";
                break;
            case 3:
                s_Return = "<Font Color=red>已签收</Font>";
                break;
        }
        return s_Return;

    }

    //错误代码，0无错误，1单号不存在，2验证码错误，3链接查询服务器失败，4程序内部错误，5程序执行错误，6快递单号格式错误，7快递公司错误，10未知错误。
    public string GetErrorName(string s_ID)
    {
        string s_Return = "";
        //0表示查询失败，1正常，2派送中，3已签收，4退回
        switch (int.Parse(s_ID))
        {
            case 0:
                s_Return = "无错误";
                break;
            case 1:
                s_Return = "单号不存在";
                break;
            case 2:
                s_Return = "验证码错误";
                break;
            case 3:
                s_Return = "链接查询服务器失败";
                break;
            case 4:
                s_Return = "程序内部错误";
                break;
            case 5:
                s_Return = "程序执行错误";
                break;
            case 6:
                s_Return = "快递单号格式错误";
                break;
            case 7:
                s_Return = "快递公司错误";
                break;
            case 10:
                s_Return = "未知错误";
                break;
        }
        return s_Return;

    }

    protected string GetOutWareListfollowup(object OutWareNo, string s_Title)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select top 1 ID,FollowNo,OutWareNo,FollowDateTime,FollowStaffNo,FollowText,FollowEnd,ReTime from KNet_Sales_OutWareList_FlowList where OutWareNo='" + OutWareNo + "' order by FollowDateTime desc";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string s_Str = "";
                if ((dr["ReTime"] != null) && (dr["ReTime"].ToString() != ""))
                {
                    s_Str += "交期：" + DateTime.Parse(dr["ReTime"].ToString()).ToShortDateString();
                }
                s_Str += KNetPage.CutString(dr["FollowText"].ToString().Trim(), 40);
                if (dr["FollowEnd"].ToString() == "True")
                {
                    return "<img src=\"/Web/images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('" + s_Title + ":<font color=Red>" + OutWareNo + "</font> 跟踪', '/Web/Xs/Sales/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + s_Str + "</a>&nbsp;<font color=red>结束</font>";//&nbsp;<font color=\"gray\">" + base.Base_GetUserName(dr["FollowStaffNo"].ToString()) + "&nbsp;(" + dr["FollowDateTime"].ToString() + ")</font>
                }
                else
                {
                    return "<img src=\"/Web/images/takman.gif\" width=\"11\" height=\"14\" border=\"0\" /><a href=\"#\" style=\"line-height: 22px;\" onclick=\"lhgdialog.opendlg('" + s_Title + ":<font color=Red>" + OutWareNo + "</font> 跟踪', '/Web/Xs/Sales/Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">" + s_Str + "</a>&nbsp;<img src=\"/Web/images/45.gif\" width=\"11\" height=\"11\" border=\"0\" /><a href=\"#\" onclick=\"lhgdialog.opendlg('" + s_Title + ":<font color=Red>" + OutWareNo + "</font> 跟踪', '/Web/Xs/Sales/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">添加</a>";
                }
            }
            else
            {
                return "<a href=\"#\" onclick=\"lhgdialog.opendlg('" + s_Title + ":<font color=Red>" + OutWareNo + "</font> 跟踪', '/Web/Xs/Sales/Knet_Sales_Ship_Manage_Talks_Add.aspx?OutWareNo=" + OutWareNo + "', 780, 400,false,false);\">添加</a>";
            }
        }
    }


    public string Base_SendMessage(string s_ReceiveIDs, string s_Text)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            string[] s_ReceiveID = s_ReceiveIDs.Split(',');
            for (int i = 0; i < s_ReceiveID.Length; i++)
            {

                KNet.BLL.System_Message_Manage BLL = new KNet.BLL.System_Message_Manage();
                KNet.Model.System_Message_Manage Model = new KNet.Model.System_Message_Manage();
                Model.SMM_ID = GetMainID(i);
                Model.SMM_Del = 0;
                Model.SMM_ReceiveID = s_ReceiveID[i];
                Model.SMM_SenderID = "admin";
                Model.SMM_State = 0;
                Model.SMM_Detail = KNetPage.KHtmlEncode(s_Text.Replace("#ID", Model.SMM_ID));
                Model.SMM_Title = "";
                Model.SMM_SendTime = DateTime.Now;
                Model.SMM_LookTime = null;
                Model.SMM_Type = "0";
                BLL.Add(Model);
            }
        }
        catch (Exception ex)
        { }
        return "";
    }

    /// <summary>
    /// Postion 0：职员 1：经理
    /// </summary>
    /// <returns></returns>
    public string Base_GetDeptPerson(string s_Dept, int Postion)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_Resource_OrganizationalStructure BLL_Org = new KNet.BLL.KNet_Resource_OrganizationalStructure();
            DataSet Dts_OrgTable = BLL_Org.GetList(" StrucName ='" + s_Dept + "' ");
            if (Dts_OrgTable.Tables[0].Rows.Count > 0)
            {
                string s_DeptNo = Dts_OrgTable.Tables[0].Rows[0]["StrucValue"].ToString();
                KNet.BLL.KNet_Resource_Staff Bll = new KNet.BLL.KNet_Resource_Staff();
                string s_Sql = "";
                if (Postion == 1)
                {
                    s_Sql = " StaffDepart='" + s_DeptNo + "' and Position='102' ";
                }
                else
                {
                    s_Sql = " StaffDepart='" + s_DeptNo + "' and Position='101' ";

                }
                DataSet Dts_Table = Bll.GetList(s_Sql);
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    s_Return += Dts_Table.Tables[0].Rows[i]["StaffNo"].ToString() + ",";
                }

            }
        }
        catch
        { }
        return s_Return.Substring(0, s_Return.Length - 1);
    }



    /// <summary>
    /// 返回客户组织结构树
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    public string GetClient_StructureTree(object aa)
    {
        string s_StructureTree = "";
        s_StructureTree = "<ul style='list-style:none;'>";
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            // 获取所有经理为空的联系人作为第一层节点
            string Dostr = "select * from XS_Compy_LinkMan where (XOL_Manager is null or XOL_Manager='') AND XOL_Compy='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                s_StructureTree += GetClient_StructureTree_ChildList(dr["XOL_ID"].ToString());
            }
        }

        s_StructureTree += "</ul>";
        return s_StructureTree;
    }

    protected string GetClient_StructureTree_ChildList(object aa)
    {
        KNet.BLL.XS_Compy_LinkMan bll = new KNet.BLL.XS_Compy_LinkMan();
        KNet.Model.XS_Compy_LinkMan model = bll.GetModel(aa.ToString());
        string s_ChildList = "";
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            // 获取经理为 aa 的所有联系人列表
            conn.Open();
            string Dostr = "select * from XS_Compy_LinkMan where XOL_Manager='" + aa + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            s_ChildList += "<li><img src='/Web/images/user_list3/user.png'/> <a href='/Web/Xs/Customer/KNet_Sales_LinkMan_View.aspx?ID=" + aa.ToString() + "'>" + model.XOL_Name + "</a> ";
            s_ChildList += string.IsNullOrEmpty(model.XOL_Responsible) ? "" : "[" + model.XOL_Responsible + "]";
            s_ChildList += string.IsNullOrEmpty(model.XOL_Phone) ? "" : " [电话：" + model.XOL_Phone + "  E-Mail：" + model.XOL_Mail + "]";

            // 若结果非空，递归调用本方法
            while (dr.Read())
            {
                s_ChildList += "<ul style='list-style:none;'>" + GetClient_StructureTree_ChildList(dr["XOL_ID"].ToString()) + "</ul>";
            }
            s_ChildList += "</li>";
        }
        return s_ChildList;
    }
    public string Base_GetBaseShare()
    {
        StringBuilder s_Return = new StringBuilder();
        try
        {
            KNet.BLL.KNet_Resource_OrganizationalStructure Bll_Organizational = new KNet.BLL.KNet_Resource_OrganizationalStructure();
            DataSet Dts_Table = Bll_Organizational.GetList("  STRucPID<>'0'   ");
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    s_Return.Append("<table width=100%><tr class=\"lvtColDataHover\">\n");
                    s_Return.Append("<td width=\"200\" class=small>\n");
                    s_Return.Append("<img src=\"/themes/softed/images/minus.gif\" id=\"img_" + Dts_Table.Tables[0].Rows[i][2].ToString() + "\" onclick=\"showhide_dept('dept_" + Dts_Table.Tables[0].Rows[i][2].ToString() + "','img_" + Dts_Table.Tables[0].Rows[i][2].ToString() + "')\" style=\"cursor: pointer;\" align=\"absmiddle\" border=\"0\"> \n&nbsp;&nbsp;");
                    s_Return.Append("<b>" + Dts_Table.Tables[0].Rows[i][2].ToString() + "</b></td><td align=\"left\" width=\"50\">\n");
                    s_Return.Append("<input type=\"checkbox\" onclick='toggleSelect(this.checked,\"DetailView_" + Dts_Table.Tables[0].Rows[i][2].ToString() + "\")' name=\"shareselectall\" class=\"detailedViewTextBox\"></td></tr></table>\n");
                    KNet.BLL.KNet_Resource_Staff Bll_Staff = new KNet.BLL.KNet_Resource_Staff();
                    DataSet Dts_Staff = Bll_Staff.GetList(" StaffDepart='" + Dts_Table.Tables[0].Rows[i][1].ToString() + "' "); ;
                    if (Dts_Staff.Tables[0].Rows.Count > 0)
                    {
                        s_Return.Append("<table width=100% id=\"dept_" + Dts_Table.Tables[0].Rows[i][2].ToString() + "\" style=\"display:block;\">\n");

                        for (int j = 0; j < Dts_Staff.Tables[0].Rows.Count; j++)
                        {
                            s_Return.Append("<tr class=\"lvtColData\" onmouseover=\"this.className='lvtColDataHover'\" onmouseout=\"this.className='lvtColData'\" id=\"row_2\" bgcolor=\"white\">\n");
                            s_Return.Append("<td width=\"200\" class=small height=\"15\">" + Dts_Staff.Tables[0].Rows[j]["StaffName"].ToString() + "</td>\n");
                            s_Return.Append("<td width=\"50\" height=\"15\"><input type=\"checkbox\" name=\"DetailView_" + Dts_Table.Tables[0].Rows[i][2].ToString() + "\" value=\"23\" class=\"detailedViewTextBox\"></td>\n");

                            s_Return.Append(" </tr>\n");
                        }
                        s_Return.Append("</table>\n");
                    }
                }
            }
        }
        catch
        { }
        return s_Return.ToString();
    }
    public string Get_Chinese_Week(DateTime Date)
    {
        string Chinese_Week = string.Empty;
        switch (Convert.ToInt32(Date.DayOfWeek))
        {
            case 0: Chinese_Week = "星期日"; return Chinese_Week;
            case 1: Chinese_Week = "星期一"; return Chinese_Week;
            case 2: Chinese_Week = "星期二"; return Chinese_Week;
            case 3: Chinese_Week = "星期三"; return Chinese_Week;
            case 4: Chinese_Week = "星期四"; return Chinese_Week;
            case 5: Chinese_Week = "星期五"; return Chinese_Week;
            case 6: Chinese_Week = "星期六"; return Chinese_Week;
            default: return Chinese_Week;
        }
    }
    public string GetMainID()
    {
        string s_ID = "M";
        try
        {
            string s_Date = DateTime.Now.ToString("yyMMddhhmmss");
            Random rand = new Random();
            int RandKey = int.Parse(rand.Next(1000000, 9999999).ToString().Substring(4, 3));
            s_ID += s_Date + RandKey.ToString();
        }
        catch
        { }
        return s_ID;
    }
    public string GetMainID(string s_Title)
    {
        string s_ID = s_Title;
        try
        {
            string s_Date = DateTime.Now.ToString("yyMMddhhmmss");
            Random rand = new Random();
            int RandKey = int.Parse(rand.Next(1000000, 9999999).ToString().Substring(4, 3));
            s_ID += s_Date + RandKey.ToString();
        }
        catch
        { }
        return s_ID;
    }
    private static char[] constant =   
      {   
        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',   
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'   
      };
    public static string GenerateRandom(int Length)
    {
        System.Text.StringBuilder newRandom = new System.Text.StringBuilder(52);
        Random rd = new Random();
        for (int i = 0; i < Length; i++)
        {
            newRandom.Append(constant[rd.Next(52)]);
        }
        return newRandom.ToString();
    }
    public string GetMainID(int i)
    {
        string s_ID = "M";
        try
        {
            string s_Date = DateTime.Now.ToString("yyMMddhhmmss");
            Random rand = new Random();
            int RandKey = rand.Next(100, 999) + i;
            s_ID += s_Date + RandKey.ToString() + GenerateRandom(6);
        }
        catch
        { }
        return s_ID;
    }

    public string Base_GetBaseShare(string DeptSql, string s_StaffSql)
    {
        StringBuilder s_Return = new StringBuilder();
        try
        {
            KNet.BLL.KNet_Resource_OrganizationalStructure Bll_Organizational = new KNet.BLL.KNet_Resource_OrganizationalStructure();
            DataSet Dts_Table = Bll_Organizational.GetList("  STRucPID<>'0'  " + DeptSql + " ");
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {
                    s_Return.Append("<table width=100%><tr class=\"lvtColDataHover\">\n");
                    s_Return.Append("<td width=\"200\" class=small>\n");
                    s_Return.Append("<img src=\"/themes/softed/images/minus.gif\" id=\"img_" + Dts_Table.Tables[0].Rows[i][2].ToString() + "\" onclick=\"showhide_dept('dept_" + Dts_Table.Tables[0].Rows[i][2].ToString() + "','img_" + Dts_Table.Tables[0].Rows[i][2].ToString() + "')\" style=\"cursor: pointer;\" align=\"absmiddle\" border=\"0\"> \n&nbsp;&nbsp;");
                    s_Return.Append("<b>" + Dts_Table.Tables[0].Rows[i][2].ToString() + "</b></td><td align=\"left\" width=\"50\">\n");
                    s_Return.Append("<input type=\"checkbox\" onclick='toggleSelect(this.checked,\"DetailView_" + Dts_Table.Tables[0].Rows[i][2].ToString() + "\")' name=\"shareselectall\" class=\"detailedViewTextBox\"></td></tr></table>\n");
                    KNet.BLL.KNet_Resource_Staff Bll_Staff = new KNet.BLL.KNet_Resource_Staff();
                    DataSet Dts_Staff = Bll_Staff.GetList(" StaffDepart='" + Dts_Table.Tables[0].Rows[i][1].ToString() + "' " + s_StaffSql + " "); ;
                    if (Dts_Staff.Tables[0].Rows.Count > 0)
                    {
                        s_Return.Append("<table width=100% id=\"dept_" + Dts_Table.Tables[0].Rows[i][2].ToString() + "\" style=\"display:block;\">\n");
                        for (int j = 0; j < Dts_Staff.Tables[0].Rows.Count; j++)
                        {
                            s_Return.Append("<tr class=\"lvtColData\" onmouseover=\"this.className='lvtColDataHover'\" onmouseout=\"this.className='lvtColData'\" id=\"row_2\" bgcolor=\"white\">\n");
                            s_Return.Append("<td width=\"200\" class=small height=\"15\">" + Dts_Staff.Tables[0].Rows[j]["StaffName"].ToString() + "</td>\n");
                            s_Return.Append("<td width=\"50\" height=\"15\"><input type=\"checkbox\"  id=\"SelectShareCheckID\" name=\"DetailView_" + Dts_Table.Tables[0].Rows[i][2].ToString() + "\" value='" + Dts_Staff.Tables[0].Rows[j]["StaffNo"].ToString() + "' class=\"detailedViewTextBox\"></td>\n");
                            s_Return.Append(" </tr>\n");
                        }
                        s_Return.Append("</table>\n");
                    }
                }
            }
        }
        catch
        { }
        return s_Return.ToString();
    }


    public string GetCwCode(int i_Num, string s_Table, string s_CodeColumn, string s_TimeColumn)
    {
        string s_Code = "";
        try
        {
            KNet.BLL.KNet_WareHouse_DirectOutList BLL = new KNet.BLL.KNet_WareHouse_DirectOutList();
            string s_Sql = "Select isNUll(Max(" + s_CodeColumn + "),'') from " + s_Table + " Where year(" + s_TimeColumn + ")='" + DateTime.Now.Year.ToString() + "'  and Month(" + s_TimeColumn + ")='" + DateTime.Now.Month.ToString() + "'";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                if (Dtb_Table.Rows[0][0].ToString() != "")
                {
                    s_Code = Dtb_Table.Rows[0][0].ToString().Substring(0, 6) + "-" + Convert.ToString(int.Parse("1" + Dtb_Table.Rows[0][0].ToString().Substring(7, 3)) + i_Num).Substring(1, 3);
                }
                else
                {
                    s_Code = DateTime.Today.ToString("yyyyMM") + "-001";
                }
            }
            else
            {
                s_Code = DateTime.Today.ToString("yyyyMM") + "-001";
            }
        }
        catch { }
        return s_Code;
    }
    public string Base_GetCustomerPayMent(string s_CustomerValue, string s_OutWareNo)
    {
        string s_Return = "";
        try
        {

            KNet.BLL.KNet_Sales_ContractList Bll_ContractList = new KNet.BLL.KNet_Sales_ContractList();
            if (s_OutWareNo != "")
            {
                KNet.BLL.KNet_Sales_OutWareList Bll_OutWare = new KNet.BLL.KNet_Sales_OutWareList();
                KNet.Model.KNet_Sales_OutWareList Model_OutWare = Bll_OutWare.GetModelB(s_OutWareNo);
                if (Model_OutWare.ContractNo != null)
                {
                    KNet.Model.KNet_Sales_ContractList Model_ContractList = Bll_ContractList.GetModelB(Model_OutWare.ContractNo);
                    s_Return = Base_GetBasicCodeName("104", Model_ContractList.Payment);
                }
                s_CustomerValue = Model_OutWare.CustomerValue;
            }
            this.BeginQuery("select top 5 * FROM KNet_Sales_ContractList left join v_Contract_OutWare_DirectOut_State on v_ContractNO=ContractNO where  CustomerValue='" + s_CustomerValue + "'  Order by ContractDateTime desc");
            DataSet Dts_Table = (DataSet)this.QueryForDataSet();
            if (Dts_Table.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                {

                    s_Return += Dts_Table.Tables[0].Rows[i]["ContractNo"].ToString() + "(" + Base_GetBasicCodeName("104", Dts_Table.Tables[0].Rows[i]["Payment"].ToString()) + ") <Br/>";
                }
            }
            else
            {
                this.BeginQuery("select top 5 * FROM KNet_Sales_ContractList left join v_Contract_OutWare_DirectOut_State on v_ContractNO=ContractNO where  CustomerValue in (Select FaterCode from KNet_Sales_ClientList where CustomerValue='" + s_CustomerValue + "')  Order by ContractDateTime desc");
                Dts_Table = (DataSet)this.QueryForDataSet();
                if (Dts_Table.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                    {
                        s_Return += "上级客户：" + Base_GetCustomerName_Link(Dts_Table.Tables[0].Rows[i]["CustomerValue"].ToString()) + " ";
                        s_Return += Dts_Table.Tables[0].Rows[i]["ContractNo"].ToString() + "(" + Base_GetBasicCodeName("104", Dts_Table.Tables[0].Rows[i]["Payment"].ToString()) + ") <Br/>";
                    }
                }
            }
        }
        catch { }
        return s_Return;
    }
    public string Base_GetNewProductsCode(string s_ID)
    {

        string s_Code = "", s_Head = "", s_NewCode = "";
        this.BeginQuery("Select Max(KSP_Code) from KNet_Sys_Products where ProductsType='" + s_ID + "' ");
        this.QueryForDataTable();
        if (Dtb_Result.Rows.Count > 0)
        {
            s_Code = Dtb_Result.Rows[0][0].ToString();
            if (s_Code != "")
            {
                s_Head = s_Code.Substring(0, s_Code.Length - 4);
                s_Code = "1" + s_Code.Substring(s_Code.Length - 4, 4);
                s_Code = Convert.ToString(int.Parse(s_Code) + 1);
                s_NewCode = s_Head + s_Code.Substring(1, s_Code.Length - 1);
            }
            else
            {
                KNet.BLL.PB_Basic_ProductsClass Bll_Products = new KNet.BLL.PB_Basic_ProductsClass();
                KNet.Model.PB_Basic_ProductsClass Model_Products = Bll_Products.GetModel(s_ID);
                s_NewCode = Model_Products.PBP_Code + "0001";
            }
        }
        else
        {
            KNet.BLL.PB_Basic_ProductsClass Bll_Products = new KNet.BLL.PB_Basic_ProductsClass();
            KNet.Model.PB_Basic_ProductsClass Model_Products = Bll_Products.GetModel(s_ID);
            s_NewCode = Model_Products.PBP_Code + "0001";
        }
        return s_NewCode;
    }

    public bool HtmlToPdf(string url, string path, string s_ID)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            string s_Path = path + "\\";

            if (!Directory.Exists(s_Path))
            {
                Directory.CreateDirectory(s_Path);
            }
            if (s_ID != "")
            {
                s_Path += s_ID + ".PDF";
            }
            if (File.Exists(s_Path))
            {
                File.Delete(s_Path);
            }
            string s_url = System.Configuration.ConfigurationManager.AppSettings["URL"].ToString();
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(s_Path))
                return false;
            Process p = new Process();
            string str = System.Web.HttpContext.Current.Server.MapPath("../../bin/wkhtmltopdf.exe");
            if (!System.IO.File.Exists(str))
                return false;
            p.StartInfo.FileName = str;
            p.StartInfo.Arguments = " \"" + s_url + "" + url + "\" " + s_Path;
            AM.Add_Logs("测试 URL" + p.StartInfo.Arguments + " PATH;" + s_Path + " Str;" + str);
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            if (!string.IsNullOrEmpty(output))
            {
                return false;
            }
            p.WaitForExit();


            ////Response给客户端下载 
            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment; filename=" + fileNameWithOutExtention + ".pdf");//强制下载 
            //Response.ContentType = "application/octet-stream";
            //Response.BinaryWrite(file);

            System.Threading.Thread.Sleep(500);

            return true;
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex);
        }
        return false;
    }


    public bool HtmlToPdfNoWater(string url, string path, string s_ID)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            string s_Path = path + "\\";

            if (!Directory.Exists(s_Path))
            {
                Directory.CreateDirectory(s_Path);
            }
            if (s_ID != "")
            {
                s_Path += s_ID + ".PDF";
            }
            if (File.Exists(s_Path))
            {
                File.Delete(s_Path);
            }
            string s_url = System.Configuration.ConfigurationManager.AppSettings["URL"].ToString();
            //if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(s_Path))
            //  return false;
            Process p = new Process();
            //判断系统是32位还是64位
            bool type;
            type = Environment.Is64BitOperatingSystem;
            string str = "";
            if (type)
            {
                str = System.Web.HttpContext.Current.Server.MapPath("../../../bin/wkhtml/wkhtmltopdf.exe");
            }
            else
            {
                str = System.Web.HttpContext.Current.Server.MapPath("../../../bin/wkhtmltopdf.exe");
            }
            if (!System.IO.File.Exists(str))
                return false;
            p.StartInfo.FileName = str;
            p.StartInfo.Arguments = " \"" + s_url + "" + url + "\" " + s_Path;
            //AM.Add_Logs("测试 URL" + p.StartInfo.Arguments + " PATH;" + s_Path + " Str;" + str);
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            if (!string.IsNullOrEmpty(output))
            {
                return false;
            }
            p.WaitForExit();

            System.Threading.Thread.Sleep(500);
            if (p.ExitCode == 0)
            {

                return true;
            }
            else
            {
                return false;
            }


        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex);
        }
        return false;
    }


    public bool HtmlToPdf1(string url, string path, string s_ID)
    {
        AdminloginMess AM = new AdminloginMess();
        try
        {
            string s_Path = path + "\\";

            if (!Directory.Exists(s_Path))
            {
                Directory.CreateDirectory(s_Path);
            }
            if (s_ID != "")
            {
                s_Path += s_ID + "x" + ".PDF";
            }
            if (File.Exists(s_Path))
            {
                File.Delete(s_Path);
            }
            string s_url = System.Configuration.ConfigurationManager.AppSettings["URL"].ToString();
            //if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(s_Path))
            //  return false;
            Process p = new Process();
            //判断系统是32位还是64位
            bool type;
            type = Environment.Is64BitOperatingSystem;
            string str = "";
            if (type)
            {
                str = System.Web.HttpContext.Current.Server.MapPath("../../../bin/wkhtml/wkhtmltopdf.exe");
            }
            else
            {
                str = System.Web.HttpContext.Current.Server.MapPath("../../../bin/wkhtmltopdf.exe");
            }
            if (!System.IO.File.Exists(str))
                return false;
            p.StartInfo.FileName = str;
            p.StartInfo.Arguments = " \"" + s_url + "" + url + "\" " + s_Path;
            // AM.Add_Logs("wkhtmltopdf " + p.StartInfo.Arguments + " " + s_Path + " Str;" + str);
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            if (!string.IsNullOrEmpty(output))
            {
                return false;
            }
            p.WaitForExit();
            try
            {
                //添加水印功能
                var WaterFilePath = path + "\\" + s_ID + ".pdf";
                //var image = path + "Content\\images\\logo2.png";     
                var flag = setWatermark(s_Path, WaterFilePath, "士腾科技");
                var exportFile = "";
                if (flag)
                    exportFile = WaterFilePath;
                else
                    exportFile = s_Path;
                FileStream fs = new FileStream(exportFile, FileMode.Open);

                byte[] file = new byte[fs.Length];

                fs.Read(file, 0, file.Length);
                fs.Close();
                // if (flag)
                //   System.IO.File.Delete(WaterFilePath);//删除文件                            
                System.IO.File.Delete(s_Path);//删除文件
            }

            catch (Exception ee)
            {

                throw new Exception(ee.ToString());

            }

            System.Threading.Thread.Sleep(500);
            if (p.ExitCode == 0)
            {

                return true;
            }
            else
            {
                return false;
            }

            ////Response给客户端下载 
            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment; filename=" + fileNameWithOutExtention + ".pdf");//强制下载 
            //Response.ContentType = "application/octet-stream";
            //Response.BinaryWrite(file);


        }
        catch (Exception ex)
        {
            // HttpContext.Current.Response.Write(ex);
        }
        return false;
    }

    /// <summary>
    /// 添加普通偏转角度文字水印
    /// </summary>
    /// <param name="inputfilepath"></param>
    /// <param name="outputfilepath"></param>
    /// <param name="waterMarkName"></param>
    /// <param name="permission"></param>
    public static bool setWatermark(string inputfilepath, string outputfilepath, string waterMarkName)
    {
        PdfReader pdfReader = null;
        PdfStamper pdfStamper = null;
        try
        {
            pdfReader = new PdfReader(inputfilepath);
            pdfStamper = new PdfStamper(pdfReader, new FileStream(outputfilepath, FileMode.Create));
            int total = pdfReader.NumberOfPages + 1;
            iTextSharp.text.Rectangle psize = pdfReader.GetPageSize(1);
            float width = psize.Width;
            float height = psize.Height;
            PdfContentByte content;
            BaseFont font = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\SIMFANG.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            PdfGState gs = new PdfGState();
            for (int i = 1; i < total; i++)
            {
                content = pdfStamper.GetOverContent(i);//在内容上方加水印
                //content = pdfStamper.GetUnderContent(i);//在内容下方加水印
                //透明度
                gs.FillOpacity = 0.3f;
                content.SetGState(gs);
                //content.SetGrayFill(0.3f);
                //开始写入文本
                content.BeginText();
                content.SetColorFill(iTextSharp.text.Color.LIGHT_GRAY);
                content.SetFontAndSize(font, 100);
                content.SetTextMatrix(0, 0);
                content.ShowTextAligned(iTextSharp.text.Element.ALIGN_CENTER, waterMarkName, width / 2 - 50, height / 2 - 50, 55);
                //content.SetColorFill(BaseColor.BLACK);
                //content.SetFontAndSize(font, 8);
                //content.ShowTextAligned(Element.ALIGN_CENTER, waterMarkName, 0, 0, 0);
                content.EndText();
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
            throw ex;
        }
        finally
        {

            if (pdfStamper != null)
                pdfStamper.Close();

            if (pdfReader != null)
                pdfReader.Close();
        }
    }

    public string Base_GetCodeByTitle(string s_Title)
    {
        AdminloginMess AM = new AdminloginMess();
        string s_Return = "";
        try
        {
            this.BeginQuery("select SBC_Code from System_Basic_Code where SBC_Name='" + s_Title + "'");
            string s_Code = this.QueryForReturn();
            //查找部门
            this.BeginQuery("Select Code from KNet_Resource_OrganizationalStructure where strucValue='" + AM.KNet_StaffDepart + "' ");
            string s_DepartCode = this.QueryForReturn();
            string s_Year = DateTime.Now.Year.ToString().Substring(2, 2);
            s_Return = s_Code + s_DepartCode + s_Year + "0001";
        }
        catch (Exception ex)
        {
        }
        return s_Return;
    }

    public class Kuaididetail
    {
        public string Time;
        public string Context;
        public Kuaididetail()
        {
        }

        public Kuaididetail(string time, string context)
        {
            this.Time = time;
            this.Context = context;
        }
    }

    public class KuaidiInfo
    {
        public string No;   //快递单号
        public string Name;  //快递公司名称
        public string ShortName; //快递公司简称
        public string Message;   //状态信息，ok为有快递信息
        public string HtmlStatus; //html状态码 详见：http://yige.org/tags/ref_httpmessages.php
        public int State;   /*快递单当前的状态 ：　 
                                0：在途，即货物处于运输过程中；
                                1：揽件，货物已由快递公司揽收并且产生了第一条跟踪信息；
                                2：疑难，货物寄送过程出了问题；
                                3：签收，收件人已签收；
                                4：退签，即货物由于用户拒签、超区等原因退回，而且发件人已经签收；
                                5：派件，即快递正在进行同城派件；
                                6：退回，货物正处于退回发件人的途中；*/
        public string Days;   //快递在途时间
        public List<Kuaididetail> Detail; //快递详情

        public KuaidiInfo()
        {
        }
    }
    public string GetKDName(string name)
    {

        if (name == "AAE全球专递")
        {
            name = "aae";
        }
        if (name == "安捷快递")
        {
            name = "anjiekuaidi";
        }
        if (name == "安信达快递")
        {
            name = "anxindakuaixi";
        }
        if (name == "百福东方")
        {
            name = "baifudongfang";
        }
        if (name == "彪记快递")
        {
            name = "biaojikuaidi";
        }
        if (name == "BHT")
        {
            name = "bht";
        }
        if (name == "顺丰快递")
        {
            name = "shunfeng";
        }
        if (name == "BHT")
        {
            name = "bht";
        }
        if (name == "希伊艾斯快递")
        {
            name = "cces";
        }
        if (name == "中国东方")
        {
            name = "Coe";
        }
        if (name == "长宇物流")
        {
            name = "changyuwuliu";
        }
        if (name == "大田物流")
        {
            name = "datianwuliu";
        }
        if (name == "德邦物流")
        {
            name = "debangwuliu";
        }
        if (name == "DPEX")
        {
            name = "dpex";
        }
        if (name == "DHL")
        {
            name = "dhl";
        }
        if (name == "D速快递")
        {
            name = "dsukuaidi";
        }
        if (name == "fedex")
        {
            name = "fedex";
        }
        if (name == "飞康达物流")
        {
            name = "feikangda";
        }
        if (name == "凤凰快递")
        {
            name = "fenghuangkuaidi";
        }
        if (name == "港中能达物流")
        {
            name = "ganzhongnengda";
        }
        if (name == "广东邮政物流")
        {
            name = "guangdongyouzhengwuliu";
        }
        if (name == "汇通快运")
        {
            name = "huitongkuaidi";
        }
        if (name == "恒路物流")
        {
            name = "hengluwuliu";
        }
        if (name == "华夏龙物流")
        {
            name = "huaxialongwuliu";
        }
        if (name == "佳怡物流")
        {
            name = "jiayiwuliu";
        }
        if (name == "京广速递")
        {
            name = "jinguangsudikuaijian";
        }
        if (name == "急先达")
        {
            name = "jixianda";
        }
        if (name == "佳吉物流")
        {
            name = "jiajiwuliu";
        }
        if (name == "加运美")
        {
            name = "jiayunmeiwuliu";
        }
        if (name == "快捷速递")
        {
            name = "kuaijiesudi";
        }
        if (name == "联昊通物流")
        {
            name = "lianhaowuliu";
        }
        if (name == "龙邦物流")
        {
            name = "longbanwuliu";
        }
        if (name == "民航快递")
        {
            name = "minghangkuaidi";
        }
        if (name == "配思货运")
        {
            name = "peisihuoyunkuaidi";
        }
        if (name == "全晨快递")
        {
            name = "quanchenkuaidi";
        }
        if (name == "全际通物流")
        {
            name = "quanjitong";
        }
        if (name == "全日通快递")
        {
            name = "quanritongkuaidi";
        }
        if (name == "全一快递")
        {
            name = "quanyikuaidi";
        }
        if (name == "盛辉物流")
        {
            name = "shenghuiwuliu";
        }
        if (name == "速尔物流")
        {
            name = "suer";
        }
        if (name == "盛丰物流")
        {
            name = "shengfengwuliu";
        }
        if (name == "天地华宇")
        {
            name = "tiandihuayu";
        }
        if (name == "天天快递")
        {
            name = "tiantian";
        }
        if (name == "TNT")
        {
            name = "tnt";
        }
        if (name == "UPS")
        {
            name = "ups";
        }
        if (name == "万家物流")
        {
            name = "wanjiawuliu";
        }
        if (name == "文捷航空速递")
        {
            name = "wenjiesudi";
        }
        if (name == "伍圆速递")
        {
            name = "wuyuansudi";
        }
        if (name == "万象物流")
        {
            name = "wanxiangwuliu";
        }
        if (name == "新邦物流")
        {
            name = "xinbangwuliu";
        }
        if (name == "信丰物流")
        {
            name = "xinfengwuliu";
        }
        if (name == "星晨急便")
        {
            name = "xingchengjibian";
        }
        if (name == "鑫飞鸿物流")
        {
            name = "xinhongyukuaidi";
        }
        if (name == "亚风速递")
        {
            name = "yafengsudi";
        }
        if (name == "一邦速递")
        {
            name = "yibangwuliu";
        }
        if (name == "优速物流")
        {
            name = "youshuwuliu";
        }
        if (name == "远成物流")
        {
            name = "yuanchengwuliu";
        }
        if (name == "圆通速递")
        {
            name = "yuantong";
        }
        if (name == "源伟丰快递")
        {
            name = "yuanweifeng";
        }
        if (name == "元智捷诚快递")
        {
            name = "yuanzhijiecheng";
        }
        if (name == "越丰物流")
        {
            name = "yuefengwuliu";
        }
        if (name == "韵达快递")
        {
            name = "yunda";
        }
        if (name == "源安达")
        {
            name = "yuananda";
        }
        if (name == "运通快递")
        {
            name = "yuntongkuaidi";
        }
        if (name == "宅急送")
        {
            name = "zhaijisong";
        }
        if (name == "中铁快运")
        {
            name = "zhongtiewuliu";
        }
        if (name == "中通速递")
        {
            name = "zhongtong";
        }
        if (name == "中邮物流")
        {
            name = "zhongyouwuliu";
        }
        if (name == "中铁物流")
        {
            name = "ztky";
        }
        if (name == "百世物流")
        {
            name = "baishiwuliu";
        }
        if (name == "跨越快递")
        {
            name = "kuayue";
        }
        if (name == "百世汇通快递")
        {
            name = "huitongkuaidi";
        }
        if (name == "优速快递")
        {
            name = "youshuwuliu";
        }
        return name;
    }
    public KuaidiInfo GetInfo(string name, string no)
    {
        try
        {
            name = GetKDName(name);
            no = no.Replace("KYE", "");
            String apiurl = "http://api.kuaidi100.com/api?id=3619cd2e53fcf3d0&com=" + name + "&nu=" + no + "&show=0&muti=1&order=asc";
            WebDownload webClient = new WebDownload();
            byte[] result = webClient.DownloadData(apiurl);
            string wuliu = Encoding.GetEncoding("utf-8").GetString(result);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            KuaidiInfo info = jss.Deserialize<KuaidiInfo>(wuliu);
            return info;
        }
        catch
        {
            return null;
        }
    }
    //返回签收状态
    public string GetSignedState(string name, string no)
    {
        string s_State = "";
        try
        {
            KuaidiInfo info = GetInfo(name, no);
            if (info != null)
            {
                if (info.Message == "ok")
                {
                    s_State = GetSateNameby100(info.State.ToString());
                }
                else
                {

                }
            }
        }
        catch
        { }
        return s_State;
    }
    //返回HTML状态
    public string GetHTML(string name, string no)
    {
        string s_Return = "";
        String apiurl = "http://api.kuaidi100.com/api?id=3619cd2e53fcf3d0&com=" + name + "&nu=" + no + "&show=2&muti=1&order=asc";

        s_Return = getPageInfo(apiurl);
        return s_Return;

    }

    public string GetReceive(string s_Sate, string s_DirectOutNo)
    {
        string s_Return = "";
        try
        {
            KNet.BLL.KNet_WareHouse_DirectOutList BLl = new KNet.BLL.KNet_WareHouse_DirectOutList();
            KNet.Model.KNet_WareHouse_DirectOutList Model = BLl.GetModelB(s_DirectOutNo);
            if ((Model.KWD_KpType == "5") || (Model.KWD_ShipType == "0"))
            {
                s_Return = "<font color=red>无需发票</font>";
            }
            else
            {
                s_Return = Base_GetBasicCodeName("212", s_Sate, "/Web/Receive/Cw_Accounting_Payment_Add.aspx?OutWareNo=" + Model.KWD_ShipNo + "");
            }
        }
        catch
        { }
        return s_Return;
    }

    public string GetColorNumber(string s_Number)
    {
        string s_return = "";
        try
        {
            decimal d_Left = decimal.Parse(s_Number.Trim());
            if (d_Left < 0)
            {
                s_return = "<font color=red>" + d_Left.ToString() + "</font>";
            }
            else
            {
                s_return = "<font color=green>" + Math.Abs(d_Left).ToString() + "</font>";
            }
        }
        catch
        { }
        return s_return;
    }
    public void GetNewStore()
    {
        try
        {
            string s_Dosql = "  delete from KNET_Store   ";
            DbHelperSQL.ExecuteSql(s_Dosql);
            s_Dosql = " INSERT into KNET_Store  ";
            s_Dosql += " select *  from v_ProdutsStore   ";
            DbHelperSQL.ExecuteSql(s_Dosql);
            s_Dosql = " delete from KNET_NeedStore ";
            DbHelperSQL.ExecuteSql(s_Dosql);
            s_Dosql = " INSERT into KNET_NeedStore  ";
            s_Dosql += " select *  from v_NeedNumberStore   ";
            DbHelperSQL.ExecuteSql(s_Dosql);
        }
        catch
        { }
    }
    public string base_GetProductsTypeYNvisable()
    {
        AdminloginMess AM = new AdminloginMess();

        string s_ProductsType = "";
        if (AM.YNAuthority("全部附件资料可见权限") == false)
        {
            if (AM.YNAuthority("规格书可见权限"))
            {
                s_ProductsType += "1" + ",";
            }
            if (AM.YNAuthority("生产文件可见权限"))
            {
                s_ProductsType += "4" + ",";
            }
            if (AM.YNAuthority("烧录文件可见权限"))
            {
                s_ProductsType += "6" + ",";
            }
            if (AM.YNAuthority("生产注意事项可见权限"))
            {
                s_ProductsType += "5" + ",";
            }
            if (AM.YNAuthority("制板文件可见权限"))
            {
                s_ProductsType += "2" + ",";
            }

            if (AM.YNAuthority("线束制作可见权限"))
            {
                s_ProductsType += "3" + ",";
            }

            if (AM.YNAuthority("测试文件可见权限"))
            {
                s_ProductsType += "7" + ",";
            }
            if (AM.YNAuthority("散热器可见权限"))
            {
                s_ProductsType += "8" + ",";
            }
            if (AM.YNAuthority("生产SOP文件可见权限"))
            {
                s_ProductsType += "9" + ",";
            }
            if (AM.YNAuthority("测试SOP可见权限"))
            {
                s_ProductsType += "10" + ",";
            }
            if (AM.YNAuthority("IQC可见权限"))
            {
                s_ProductsType += "11" + ",";
            }
            if (AM.YNAuthority("OQC可见权限"))
            {
                s_ProductsType += "12" + ",";
            }
            if (AM.YNAuthority("代码工程可见权限"))
            {
                s_ProductsType += "13" + ",";
            }
            

            if (s_ProductsType != "")
            {
                s_ProductsType = s_ProductsType.Substring(0, s_ProductsType.Length - 1);
            }
        }
        return s_ProductsType;
    }
    public string base_GetProductsFileUpdateType()
    {
        string s_Return = "";
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (AM.YNAuthority("规格书修改权限"))
            {
                s_Return += "1,";
            }
            if (AM.YNAuthority("特殊物料增删改权限"))
            {
                s_Return += "2,3,8,";
            }
            if (AM.YNAuthority("生产文件修改权限"))
            {
                s_Return += "4,";
            }
            if (AM.YNAuthority("生产注意事项修改权限"))
            {
                s_Return += "5,";
            }
            if (AM.YNAuthority("生产SOP文件修改权限"))
            {
                s_Return += "9,";
            }
            if (AM.YNAuthority("测试SOP修改权限"))
            {
                s_Return += "10,";
            }
            if (AM.YNAuthority("烧录文件修改权限"))
            {
                s_Return += "6,";
            }

            if (AM.YNAuthority("IQC修改权限"))
            {
                s_Return += "11,";
            }
            if (AM.YNAuthority("OQC修改权限"))
            {
                s_Return += "12,";
            }

            if (AM.YNAuthority("代码工程修改权限"))
            {
                s_Return += "13,";
            }

            

            if (s_Return != "")
            {
                s_Return = s_Return.Replace(",", "','");
            }
        }
        catch
        { }
        return s_Return;
    }


    public bool base_GetProductsFileUpdateType(string s_ID)
    {
        bool s_Return = false;
        AdminloginMess AM = new AdminloginMess();
        try
        {
            if (s_ID == "1")
            {
                if (AM.YNAuthority("规格书修改权限"))
                {
                    s_Return = true;
                }
            }

            else if ((s_ID == "2") || (s_ID == "3") || (s_ID == "8"))
            {
                if (AM.YNAuthority("特殊物料增删改权限"))
                {
                    s_Return = true;
                }
            }
            else if (s_ID == "4")
            {
                if (AM.YNAuthority("生产文件修改权限"))
                {
                    s_Return = true;
                }
            }
            else if (s_ID == "5")
            {
                if (AM.YNAuthority("生产注意事项修改权限"))
                {
                    s_Return = true;
                }
            }
            else if (s_ID == "6")
            {
                if (AM.YNAuthority("烧录文件修改权限"))
                {
                    s_Return = true;
                }
            }

            else if (s_ID == "9")
            {
                if (AM.YNAuthority("生产SOP文件修改权限"))
                {
                    s_Return = true;
                }
            }

            else if (s_ID == "10")
            {
                if (AM.YNAuthority("测试SOP修改权限"))
                {
                    s_Return = true;
                }
            }
            else if (s_ID == "11")
            {
                if (AM.YNAuthority("IQC修改权限"))
                {
                    s_Return = true;
                }
            }
            else if (s_ID == "12")
            {
                if (AM.YNAuthority("OQC修改权限"))
                {
                    s_Return = true;
                }
            }
            else if (s_ID == "13")
            {
                if (AM.YNAuthority("代码工程修改权限"))
                {
                    s_Return = true;
                }
            }
            
        }
        catch
        { }
        return s_Return;
    }

    public void base_GetExpendDropDownList(DropDownList DropDownListName, string whereSql, bool IsTrue)
    {
        Sc_Expend_Manage_MaterDetails BLL=new Sc_Expend_Manage_MaterDetails();
        BLL.GetList(whereSql);
        DropDownListName.DataSource = Dts_Result;
        DropDownListName.DataTextField = "PBC_Name";
        DropDownListName.DataValueField = "PBC_Code";

    }
}

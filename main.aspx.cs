using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using KNet.DBUtility;
using KNet.Common;


public partial class Knetwork_Admin_Main : BasePage
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
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = 'Default.aspx';</script>");
                Response.End();
            }

                if (AM.KNet_Sys_OutWarning)
                {
                    if (NoTYN() == true)
                    {
                        this.MSNfunction(AM.KNet_Sys_CompanyName, "web/WareHouse/KNet_WareHouse_OwnallWarning.aspx", "存库自动报警提示:", "库存自动检测提醒您!<BR><BR>已有产品到达库存报警线!", "点击查看存库报警");
                    }
                }
 
            
            Page.Title = AM.KNet_Sys_CompanyName;
        }    
    }

    // <summary>
    // 查库存是否有报警线产品
    // </summary>
    // <param name="DoSQL"></param>
    // <returns></returns>
    protected bool NoTYN()
    {
        AdminloginMess AM = new AdminloginMess();
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Sum(DirectInAmount),ProductsBarCode ");
            strSql.Append(" FROM v_Store  ");
            strSql.Append(" where  ( " + AM.MyDoSqlWith_Do + " ) group by ProductsBarCode having Sum(DirectInAmount) <=(select KNet_Sys_Products.ProductsStockAlert FROM KNet_Sys_Products where KNet_Sys_Products.ProductsBarCode=v_Store.ProductsBarCode and KNet_Sys_Products.ProductsStockAlert>0 )");
            using (SqlCommand cmd = new SqlCommand(strSql.ToString(), conn))
            {
                SqlDataReader DR = cmd.ExecuteReader();
                if (DR.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }



  /// <summary>
  /// MSN提醒
  /// </summary>
  /// <returns></returns>
 protected  void MSNfunction(string ComName,string GetUrl,string s_Title,string s_Details,string s_UrlDetails)       
  {    
        string Src="";
        Src += "<html>\n";
        Src += "<head>\n";
        Src += "<title>"+ComName+"</title>\n";
        Src += "</head>\n";
        Src += "<body scroll=no topmargin=\"0\" leftmargin=\"0\" rightmargin=\"0\">\n";
        Src += "<script language=\"JavaScript\">\n";
        Src += "window.onload = getMsg;\n";
        Src += "window.onresize = resizeDiv;\n";
        Src += "window.onerror = function(){}\n";
        Src += "var divTop,divLeft,divWidth,divHeight,docHeight,docWidth,objTimer,i = 0;\n";
        Src += "function getMsg()\n";
        Src += "{\n";
        Src += "try{\n";
        Src += "divTop = parseInt(document.getElementById(\"eMeng\").style.top,10)\n";
        Src += "divLeft = parseInt(document.getElementById(\"eMeng\").style.left,10)\n";
        Src += "divHeight = parseInt(document.getElementById(\"eMeng\").offsetHeight,10)\n";
        Src += "divWidth = parseInt(document.getElementById(\"eMeng\").offsetWidth,10)\n";
        Src += "docWidth = document.body.clientWidth;\n";
        Src += "docHeight = document.body.clientHeight;\n";
        Src += "document.getElementById(\"eMeng\").style.top = parseInt(document.body.scrollTop,10) + docHeight + 10;\n";
        Src += "document.getElementById(\"eMeng\").style.left = parseInt(document.body.scrollLeft,10) + docWidth - divWidth\n";
        Src += "document.getElementById(\"eMeng\").style.visibility=\"visible\"\n";
        Src += "objTimer = window.setInterval(\"moveDiv()\",10)\n";
        Src += "}\n";
        Src += "catch(e){}\n";
        Src += "}\n";
        Src += "function resizeDiv()\n";
        Src += "{\n";
        Src += "i+=1\n";
        Src += "if(i>1000) closeDiv()\n";
        Src += "try{\n";
        Src += "divHeight = parseInt(document.getElementById(\"eMeng\").offsetHeight,10)\n";
        Src += "divWidth = parseInt(document.getElementById(\"eMeng\").offsetWidth,10)\n";
        Src += "docWidth = document.body.clientWidth;\n";
        Src += "docHeight = document.body.clientHeight;\n";
        Src += "document.getElementById(\"eMeng\").style.top = docHeight - divHeight + parseInt(document.body.scrollTop,10)\n";
        Src += "document.getElementById(\"eMeng\").style.left = docWidth - divWidth + parseInt(document.body.scrollLeft,10)\n";
        Src += "}\n";
        Src += "catch(e){}\n";
        Src += "}\n";
        Src += "function moveDiv()\n";
        Src += "{\n";
        Src += "try\n";
        Src += "{\n";
        Src += "if(parseInt(document.getElementById(\"eMeng\").style.top,10) <= (docHeight - divHeight + parseInt(document.body.scrollTop,10)))\n";
        Src += "{\n";
        Src += "window.clearInterval(objTimer)\n";
        Src += "objTimer = window.setInterval(\"resizeDiv()\",1)\n";
        Src += "}\n";
        Src += "divTop = parseInt(document.getElementById(\"eMeng\").style.top,10)\n";
        Src += "document.getElementById(\"eMeng\").style.top = divTop - 1\n";
        Src += "}\n";
        Src += "catch(e){}\n";
        Src += "}\n";
        Src += "function closeDiv()\n";
        Src += "{\n";
        Src += "document.getElementById(\'eMeng\').style.visibility=\'hidden\';\n";
        Src += "if(objTimer) window.clearInterval(objTimer)\n";
        Src += "}\n";
        Src += "</script>\n";
        Src += "<DIV id=eMeng style=\"BORDER-RIGHT: #455690 1px solid; BORDER-TOP: #a6b4cf 1px solid; Z-INDEX:99999; LEFT: 0px; VISIBILITY: hidden; BORDER-LEFT: #a6b4cf 1px solid; WIDTH: 180px; BORDER-BOTTOM: #455690 1px solid; POSITION: absolute; TOP: 0px; HEIGHT: 116px; BACKGROUND-COLOR: #c9d3f3\">\n";
        Src += "<TABLE style=\"BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid\" cellSpacing=0 cellPadding=0 width=\"100%\" bgColor=#cfdef4 border=0>\n";
        Src += "<TBODY>\n";
        Src += "<TR>\n";
        Src += "<TD style=\"FONT-SIZE: 12px; BACKGROUND-IMAGE: url(msgTopBg.gif); COLOR: #0f2c8c\" width=30 height=24></TD>\n";
        Src += "<TD style=\"FONT-WEIGHT: normal; FONT-SIZE: 12px; BACKGROUND-IMAGE: url(msgTopBg.gif); COLOR: #1f336b; PADDING-TOP: 4px;PADDING-left: 4px\" vAlign=center width=\"100%\">"+s_Title+"</TD>\n";
        Src += "<TD style=\"BACKGROUND-IMAGE: url(msgTopBg.gif); PADDING-TOP: 2px;PADDING-right:2px\" vAlign=center align=right width=19><span title=关闭 style=\"CURSOR: hand;color:red;font-size:12px;font-weight:bold;margin-right:4px;\" onclick=closeDiv() >×</span></TD>\n";
        Src += "</TR>\n";
        Src += "<TR>\n";
        Src += "<TD style=\"PADDING-RIGHT: 1px; BACKGROUND-IMAGE: url(1msgBottomBg.jpg); PADDING-BOTTOM: 1px\" colSpan=3 height=90>\n";
        Src += "<DIV style=\"BORDER-RIGHT: #b9c9ef 1px solid; PADDING-RIGHT: 13px; BORDER-TOP: #728eb8 1px solid; PADDING-LEFT: 13px; FONT-SIZE: 12px; PADDING-BOTTOM: 13px; BORDER-LEFT: #728eb8 1px solid; WIDTH: 100%; COLOR: #1f336b; PADDING-TOP: 18px; BORDER-BOTTOM: #b9c9ef 1px solid; HEIGHT: 100%\">"+s_Details+"<br><br>\n";
        Src += "<DIV align=center style=\"word-break:break-all\"><a href=\"" + GetUrl + "\" target=\"main\"><font color=#FF0000>" + s_UrlDetails + "</font></a></DIV>\n";
        Src += "</DIV>\n";
        Src += "</TD>\n";
        Src += "</TR>\n";
        Src += "</TBODY>\n";
        Src += "</TABLE>\n";
        Src += "</DIV>\n";
        Src += "</body>\n";
        Src += "</html>\n";
        Response.Write(Src); 
  }


}

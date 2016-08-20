<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"   CodeFile="Knet_Sales_Ship_Manage_PrinterListSettingPrinterPage.aspx.cs" Inherits="Knet_Sales_Knet_Sales_Ship_Manage_PrinterListSettingPrinterPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<script language="javascript" src="../js/CheckActivX.js"></script>
<object id="LODOP" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" width=0 height=0> 
</object> 
<title></title>
<script type="text/javascript" language="javascript">
	function prn1_preview() {	
		CreateOneFormPage();	
		LODOP.PREVIEW();	
	}
		function CreateTwoFormPage(){
		LODOP.PRINT_INIT("打印插件功能演示_Lodop功能_表单二");
		LODOP.ADD_PRINT_RECT(70,27,629,242,0,1);			
		LODOP.ADD_PRINT_TEXT(29,236,279,38,"页面内容改变布局打印");
		LODOP.SET_PRINT_TEXT_STYLE(2,"宋体",18,1,0,0,1);
		LODOP.ADD_PRINT_HTM(88,40,321,185,document.getElementById("form1").innerHTML);
		LODOP.ADD_PRINT_TEXT(319,58,500,30,"注：其中《表一》按显示大小，《表二》在程序控制宽度(285像素)内自适应调整");
		}
</script>

<style type="text/css">
<!--
body {
	background-color: #FFFFFF;
}
-->
</style>
</head>

<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>
<%--固定样式 
<table width="98%" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td height="3"></td>
  </tr>
</table>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">打印发货单</div></td>
    <td background="../../images/ktxt2.gif">
    
<table width="100%" border="0" align="center"  cellpadding="0" cellspacing="0" >
<tr>
 <td height="20" align="right">友情提示:发货项目内容双击可手动编辑文字内容&nbsp;&nbsp;&nbsp;&nbsp;<Input  Type="Button" id="Button1" class="Btt"  onclick="prn1_preview()"  value="打印输出发货单" size="10">&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Text="返回发货单列表" CausesValidation="false" CssClass="Btt" OnClick="Button2_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
  </tr>
</table>

    </td>
  </tr>
</table>
<table width="98%" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td height="3"></td>
  </tr>
</table>


<!--下面为打印表单-->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-bottom:#3399CC 0px solid;border-right:#3399CC 0px solid;border-left:#3399CC 0px solid;border-top:#3399CC 0px solid;">
  <tr>
    <td>

 
<%-- 打印开始--%>
<div id="printdiv">

<table width="822" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td height="47" align="center" valign="top"><div id="TopPrinterDo" runat="server"></div></td>
  </tr>
  <tr>
    <td height="0" align="center" valign="top">
<table width="820" border="0" align="center" bgcolor="white" cellpadding="0" cellspacing="0" style="border-right:1px solid #000000;border-left:1px solid #000000;" >
  <tr>
    <td height="0" align="center" valign="top"  >
<!--GridView-->  
        <asp:GridView ID="GridView2" runat="server" Width="100%" DataKeyNames="ID"  AutoGenerateColumns="false" OnRowDataBound="GridView2_RowDataBound"  RowStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" RowStyle-Height="25px" HeaderStyle-Height="25px" RowStyle-Font-Size="12px" HeaderStyle-Font-Size="12px" >
            <HeaderStyle  />
            <EditRowStyle  />     
       </asp:GridView>
<!--GridView-->
        <table width="100%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-bottom:1px solid #000000;border-right:1px solid #000000;border-left:1px solid #000000;">
          <tr id="chkPrintSate" runat="server">
            <td height="26" align="left"  style="border-bottom:1px solid #000000;">&nbsp;<asp:Label ID="SmA" runat="server"  Text=""  Font-Size="14px"></asp:Label></td>
          </tr>
      </table></td>
  </tr>
</table>
    </td>
  </tr>
    <tr>
    <td height="47" align="center" valign="top"><div id="BotPrinter" runat="server"></div></td>
  </tr>
</table>
<%-- 打印结束--%>


    </td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>

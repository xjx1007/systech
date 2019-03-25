<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"   CodeFile="KNet_WareHouse_WareCheck_Manage_PrinterListSettingPage.aspx.cs" Inherits="Knet_WareHouse_KNet_WareHouse_WareCheck_Manage_PrinterListSettingPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<title></title>
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
<script type="text/javascript" language="javascript">
function printPage() {
var newWin = window.open('printer','','');
var titleHTML = document.getElementById("printdiv").innerHTML;
newWin.document.write(titleHTML);
newWin.document.location.reload();
newWin.print();
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

<table width="98%" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td height="1"></td>
  </tr>
</table>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">打印盘点单</div></td>
    <td background="../../images/ktxt2.gif">
    
<table width="100%" border="0" align="center"  cellpadding="0" cellspacing="0" >
<tr>
 <td height="20" align="right">友情提示:盘点项目内容双击可手动编辑文字内容&nbsp;&nbsp;&nbsp;&nbsp;<Input  Type="Button" id="Button1" class="Btt"  onclick="printPage()"  value="打印输出盘点单" size="10">&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Text="返回盘点单列表" CausesValidation="false" CssClass="Btt" OnClick="Button2_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
  </tr>
</table>

    </td>
  </tr>
</table>
<table width="98%" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td height="1"></td>
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
</table>

<table width="822" border="0" align="center" cellpadding="0" cellspacing="0">
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
</table>

<table width="822" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td height="47" align="center" valign="top"><div id="BotPrinter" runat="server"></div></td>
  </tr>
</table>
</div>


<%-- 打印结束--%>
<table width="820" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top:0px solid #A3B2CC;">
  <tr>
    <td height="28" > &nbsp;<Input  Type="Button" id="Button1aaa" class="Btt"  onclick="printPage()"  value="打印输出盘点单" size="10">&nbsp;</td>
</tr>
</table>
<!--分页-->

    </td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>

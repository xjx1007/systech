<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KnetUserAuthoritySetA.aspx.cs" Inherits="web_SystemSettings_AuthoritySetA" %>
<%@ Register Src="inc/KnetUserAuthoritySet.ascx" TagName="ProcureBillingSetting"  TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<title>用户组操作权限设置</title>
<script>   
  function closeWindow()   
  {   
  window.opener=null;   
  window.close();   
  }   
</script> 
<script type= "text/javascript"> 
function doActionForCheckBoxListItem(sender,chkListId)   
{ 
   var chkListContainer = document.getElementById(chkListId); 
   var chkList = chkListContainer.getElementsByTagName("input");                 
   for(var i=0;i<chkList.length;i++)
        {                         
         chkList[i].checked = sender.checked; 
        }                           
} 
</script> 	
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
<div id="Div2" style="padding:1px"></div>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td background="../../images/ktxt11.gif" style="background-color:#F5F5F5; height:28px; width:260px;padding-left:20px;"><div class="TP2">用户组管理---用户组权限设置</div></td>
    <td background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;（<B>设置用户组 <font color="red"> <asp:Label ID="GroupName" runat="server" Text=""></asp:Label></font> 的操作权限，请在要分配的权限项打“√”</B>）</td>
    <td background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;"><asp:Label ID="GroupValue" runat="server"  Visible="false" ></asp:Label></td>
  </tr>
</table>
<div id="Div1" style="padding:1px"></div>

<%--莱单列表--%>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td><uc1:ProcureBillingSetting id="ProcureBillingSetting1" runat="server"></uc1:ProcureBillingSetting></td>
  </tr>
</table>



<table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" >
<tr>
<td height="100"  align="left" valign="top"  style="border-bottom:#3399CC 1px solid;border-right:#3399CC 1px solid;border-left:#3399CC 1px solid;border-top:#3399CC 1px solid;">
<%--内容页--%>


<%--采购入库权限设置--%>
<table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
<tr>
   <td  height="30" width="86%" background="/images/AuList2.gif"  style="border-bottom:#0099CC 0px solid;"><B>[<asp:Label ID="SNameValue" runat="server" Text=""></asp:Label>] </B>权限设置</td>
   <td width="14%" background="/images/AuList2.gif"  style="border-bottom:#0099CC 0px solid;"><asp:CheckBox ID="CBAuthorityA" runat="server" Text="全部选择"  Font-Bold="true" ForeColor="red" onclick= "doActionForCheckBoxListItem(this,'AuthorityA')" /></td>
</tr>
<tr>
   <td height="30" colspan="2" ><asp:CheckBoxList ID="AuthorityA" runat="server" RepeatDirection="Horizontal" RepeatColumns="5"   RepeatLayout="Table"   Width="99%"   CellPadding="2"  CellSpacing="2" ></asp:CheckBoxList></td>
</tr>
</table>
<!--底部功能栏-->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td width="60%" height="30" align="left">&nbsp;（<B>设置用户组 <font color="red"> <asp:Label ID="LBNamB" runat="server" Text=""></asp:Label></font> 的操作权限，请在要分配的权限项打“√”</B>）</td>
    <td width="40%" align="left">&nbsp;<asp:Button ID="Button1" runat="server" Text="确定权限设置"  CssClass="Btt" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />&nbsp;&nbsp;&nbsp;&nbsp;<input name="button2" type="button" value="关闭本窗口" class="Btt" onclick="closeWindow();"></td>
  </tr>
</table>
<!--底部功能栏-->
<%--内容页结束--%>
</td>
  </tr>
</table>
    </form>
</body>
</html>

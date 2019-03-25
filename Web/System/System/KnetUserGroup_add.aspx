<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"  CodeFile="KnetUserGroup_add.aspx.cs" Inherits="Knet_Web_System_KnetUserGroup_add" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../../css/knetwork.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
<title></title>

<style type="text/css">
.Div11
{
  background-image:url(../images/midbottonA2.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
.Div22
{
  background-image:url(../images/midbottonB2.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
</style>


</head>

<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
<div id="ssdd" style="padding:1px"></div>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">用户组管理</div></td>
    <td  background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;&nbsp;</td>
    <td width="216" background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="center">&nbsp;</td>
  </tr>
</table>
<div id="Div1" style="padding:1px"></div>


<table  height="22" border="0" cellpadding="0" cellspacing="0" width="99%" align="center" >
      <tr>
        <td width="90" align="center"><asp:HyperLink ID="HyperLink1" runat="server"  NavigateUrl="KnetUserGroup.aspx"  CssClass="Div11" Width="90px" Height="21px" Font-Size="14px" >用户组列表</asp:HyperLink></td>
        <td width="4" align="center"></td>
        <td width="90" align="center"><asp:HyperLink ID="HyperLink2" runat="server"  NavigateUrl="KnetUserGroup_add.aspx"  CssClass="Div22" Width="90px" Height="21px" Font-Size="14px" Font-Bold="true" ForeColor="MintCream">用户组添加</asp:HyperLink></td>
        <td width="4" align="center"></td>
        <td align="center">&nbsp;</td>
      </tr>
</table>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
<%--内容块--%>

<table width="100%"  border="0" align="center" cellpadding="0" cellspacing="0">

 <tr>
        <td width="26%" height="30" align="right" ></td>
        <td width="74%" >&nbsp;</td>
      </tr>
      
      
      <tr>
        <td width="26%" height="30" align="right" class="tdcss">用户组名称:</td>
        <td width="74%" class="tdcss">&nbsp;<asp:TextBox ID="GroupName" runat="server"  CssClass="Boxx" Width="200px"  MaxLength="40"></asp:TextBox>(<font color="red">*</font>)<asp:RequiredFieldValidator
            ID="RequiredFieldValidator1" runat="server" ErrorMessage="用户组名称不能为空！" ControlToValidate="GroupName" Display="Dynamic" ></asp:RequiredFieldValidator></td>
      </tr>
      
   
      
      <tr>
        <td height="30" align="right" class="tdcss">排序值:</td>
        <td class="tdcss">&nbsp;<asp:TextBox ID="GroupPai" Text="10" MaxLength="6" Width="100px" runat="server" CssClass="Boxx"></asp:TextBox><asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="不能为空!"  ControlToValidate="GroupPai" MaximumValue=9999  MinimumValue=1 Type="Integer" Display="Dynamic"></asp:RangeValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="正整数!" ControlToValidate="GroupPai" ValidationExpression="^(0|[1-9][0-9]*)$" Display="Dynamic"></asp:RegularExpressionValidator></td>
      </tr>

      <tr>
        <td align="right" height="50px">&nbsp;</td>
        <td>&nbsp;<asp:Button ID="Button1" runat="server" Text="添加用户组" CssClass="Btt" OnClick="Button1_Click" style="width: 55px;height: 33px;"  /></td>
      </tr>
    </table>



<%--内容块--%>
    </td>
  </tr>
</table>


    </form>
</body>
</html>

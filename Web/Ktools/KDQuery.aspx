<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KDQuery.aspx.cs" Inherits="Web_Test" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

<link rel="stylesheet" href="../css/knetwork.css" type="text/css" />
<script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="30" >快递</td><td><asp:DropDownList ID="KD" runat="server" Width="150px"></asp:DropDownList></td>
    <td height="30" >单号</td><td><asp:TextBox runat="server" ID="Code"></asp:TextBox></td>
    <td height="30" ><asp:Button runat="server" ID="Btn" OnClick="Btn_Click" Text="查询" /></td>
  </tr>
  <tr>
  <td colspan="3"><asp:Label runat="server" ID="Lbl_wl"></asp:Label></td>
  </tr>
</table>
    </form>
</body>
</html>

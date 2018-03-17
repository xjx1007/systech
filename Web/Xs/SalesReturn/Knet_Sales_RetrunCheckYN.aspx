<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Knet_Sales_RetrunCheckYN.aspx.cs" Inherits="Knet_Web_Sales_pop_Knet_Sales_RetrunCheckYN" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="/Web/css/knetwork.css" type="text/css">
<title>退货单进展操作--审核</title>
<script>   
  function closeWindow()   
  {   
  window.opener=null;   
  window.close();   
  }   
  </script>   
  
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>

<table width="100%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="/images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">退货单审核</div></td>
    <td  background="/images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;</td>
    <td width="216" background="/images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="center">&nbsp;</td>
  </tr>
</table>
<table width="98%" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td height="2"></td>
  </tr>
</table>



<%--内容开始--%>

<table width="100%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>

<asp:Label ID="UsersNotxt" runat="server" Text="" Visible="false"></asp:Label>


<table width="100%" height="102" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td width="36%" height="30" align="right" style="border-bottom:#A3B2CC 1px solid;">退货审核选择：</td>
    <td width="64%" style="border-bottom:#A3B2CC 1px solid;">&nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
       
       <asp:ListItem Value="-1">请选择审核</asp:ListItem>
       <asp:ListItem Value="1">通过审核</asp:ListItem>
       <asp:ListItem Value="0">不审核</asp:ListItem>
       </asp:DropDownList>
        

    </td>
  </tr>
        <tr>
           <td height="30" colspan="2" align="center" >&nbsp;<font color="gray"></font>
           <asp:Label ID="MyStatStr" runat="server" Text="" Visible="false" ForeColor="red" ></asp:Label>
            </td>
      </tr>
  <tr>
    <td height="30" colspan="2" align="center" >&nbsp;
    <asp:Button ID="Button1" runat="server" Text="确定审核" CssClass="Btt" OnClick="Button1_Click"  />&nbsp;<input   name="button2"   type="button"   value="关闭本窗口"  class="Btt"  onclick="closeWindow();"> </td>
  </tr>
</table>

<!--底部功能栏-->
<table width="100%" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td height="30" >&nbsp;</td>
  </tr>
</table>
<!--底部功能栏-->

    </td>
  </tr>
</table>


    </div>
    </form>
</body>
</html>

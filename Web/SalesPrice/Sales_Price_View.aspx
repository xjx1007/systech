<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sales_Price_View.aspx.cs" Inherits="Web_SalesPrice_Sales_Price_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
    <title>无标题页</title>
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
</head>
<body>
    <form id="form1" runat="server">
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td>

<%--合同开单  开始--%>

<table width="100%" border="0"   cellpadding="0" cellspacing="0" align="center" class="tablecss_add" id="TABLE1" >
 <tr>
    <td width="17%" align="right" class="tableBotcss" style="height: 25px">&nbsp; 合同评审编号:</td>
    <td width="36%" align="left" class="tableBotcss" style="height: 25px"><asp:TextBox ID="ContractNo" MaxLength="40" runat="server" CssClass="Boxx" Width="150px" ></asp:TextBox>(<font color="red">*</font>)唯一性<br />
    <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" ErrorMessage="合同编号不能为空" ControlToValidate="ContractNo" Display="Dynamic"></asp:RequiredFieldValidator></td>
  <td align="right" class="tableBotcss" style="color: #000000; height: 33px;">
        签订日期:</td>
    <td align="left" class="tableBotcss" style="height: 33px"><asp:TextBox ID="ContractDateTime" runat="server"  MaxLength="20"  CssClass="Wdate" onClick="WdatePicker()" ></asp:TextBox>(<font color="red"><span
            style="color: #ff0066">*</span></font>)<br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="签订日期非空" ControlToValidate="ContractDateTime" Display="Dynamic"></asp:RequiredFieldValidator></td>
  </tr>


</table>

<%--合同开单  结束--%>


<!--底部功能栏 -->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td style="text-align: center; height: 8px;" >&nbsp;&nbsp;<br /><asp:Button ID="Button3" runat="server" Text="确定添加合同" CssClass="Btt" OnClick="Button3_Click" /></td>
  </tr>
</table>
<!--底部功能栏-->

    </td>
  </tr>
</table>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true"  ValidateRequest="false"  CodeFile="KNet_WareHouse_WareCheck_Manage_PrinterList_Update.aspx.cs" Inherits="Knet_WareHouse_KNet_WareHouse_WareCheck_Manage_PrinterList_Update" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<title></title>
</head>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
<div id="ssdd" style="padding:1px"></div>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">盘点打印模板</div></td>
    <td width="550"  background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;日期从<asp:TextBox ID="StartDate" runat="server" CssClass="Wdate"  onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})" ></asp:TextBox>&nbsp;到<asp:TextBox ID="EndDate" runat="server"  CssClass="Wdate"   onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})" ></asp:TextBox>&nbsp;关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="Boxx" Width="120px"></asp:TextBox></td>
    <td  background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="left"><asp:Button  ID="Button4" runat="server" Text="打印模板检索"  CssClass="Btt" OnClick="Button4_Click" CausesValidation="false" /></td>
  </tr>
</table>


<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td valign="top">
<%--内容开始--%>
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td width="14%" height="28" align="right" bgcolor="#D7DDEA" class="tableBotcss">&nbsp;&nbsp;打印模板名称：</td>
	<td height="28" align="left" bgcolor="#D7DDEA" class="tableBotcss">
      <asp:TextBox ID="PrinterTitle" runat="server" Width="350px" CssClass="Boxx"></asp:TextBox>(<font color="Red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="模板名称不能为空" Display="Dynamic" ControlToValidate="PrinterTitle"></asp:RequiredFieldValidator>&nbsp;&nbsp;&nbsp;&nbsp;是否启用:<asp:CheckBox  ID="PrinterYN" runat="server" />&nbsp;(启用的请打“√”)</td>
	</tr>
</table>


<%--上部分模板设置--%>
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="28" colspan="4" align="left" bgcolor="#ECEEF4" class="tableBotcss">&nbsp;&nbsp;<B>上部模板设置</B></td>
	</tr>
	<tr>
	<td height="26" colspan="4" align="center" class="tableBotcss"><asp:TextBox ID="txtTopComtont" runat="server" style="display:none;"></asp:TextBox>
        <IFRAME src='../eWebEditor/ewebeditor.htm?id=txtTopComtont&style=coolblue' frameborder='0' scrolling='no' width='98%' height='350'></IFRAME></td>
	</tr>
</table>
<%--上部分模板设置结束--%>

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="28" colspan="4" align="left" bgcolor="#ECEEF4" class="tableBotcss">&nbsp;&nbsp;<strong>产品明细打印设置</strong></td>
	</tr>
	<tr>
	<td height="28" width="36%" align="right" class="tableBotcss"><strong>产品明细表中显示的项目</strong>:	</td>
	<td height="28" colspan="3" align="left" class="tableBotcss"> &nbsp;&nbsp;<strong>&nbsp;要显示的请打上“√”</strong></td>
	</tr>
	<tr>
	<td height="63" colspan="4" align="center" valign="top" class="tableBotcss" >
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" Width="700px" RepeatDirection="Horizontal" RepeatColumns="6" >
        <asp:ListItem Value="WareCheckNo">盘点单号</asp:ListItem>
        <asp:ListItem Value="ProductsBarCode"  >编号(条形码)</asp:ListItem>
		<asp:ListItem Value="ProductsName">产品名称</asp:ListItem>
        <asp:ListItem Value="ProductsPattern">产品型号</asp:ListItem>
         <asp:ListItem Value="WareCheckAmount">盘差数量</asp:ListItem>
        <asp:ListItem Value="ProductsUnits" >产品单位</asp:ListItem>
       
        <asp:ListItem Value="WareCheckLossUp" >盘点类型</asp:ListItem>
       
        <asp:ListItem Value="WareCheckUnitPrice"  >盘点单价</asp:ListItem>
        <asp:ListItem Value="WareCheckDiscount" >金额调节</asp:ListItem>
        <asp:ListItem Value="WareCheckTotalNet"  >金额合计</asp:ListItem>
        <asp:ListItem Value="WareCheckRemarks"  >产品备注</asp:ListItem>
        </asp:CheckBoxList>
        
      </td>
	</tr>
</table>

<asp:Label ID="SID" runat="server" Text="" Visible="false"></asp:Label>
<asp:Label ID="Tex_ID" runat="server" Text="" Visible="false"></asp:Label>

<table cellSpacing="0" cellPadding="0" width="100%" border="0" align="center">
	<tr>
	<td height="28" colspan="4" align="left" bgcolor="#ECEEF4" class="tableBotcss">&nbsp;&nbsp;<strong>产品明细统计打印设置</strong></td>
	</tr>
	<tr>
	<td height="28" width="36%" align="right" class="tableBotcss"><strong>明细表统计合计信息</strong> 是否显示:</td>
	<td height="28" colspan="3" align="left" class="tableBotcss"> <asp:CheckBox ID="PrintStatShow" Text="显示" runat="server" Checked="true" Font-Bold="true" ForeColor="blue" />&nbsp;&nbsp;<strong>&nbsp;请在要显示的项目上打“√”</strong></td>
	</tr>
	<tr>
	<td height="31" colspan="4" align="center" valign="top" class="tableBotcss" >	
	
		
<table width="70%" height="25" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td height="25" align="left">&nbsp;<asp:CheckBox ID="PrintAmount_Recodor" Text="[<B>记录数合计</B>]  是否显示" runat="server" Checked="true" /></td>
    <td height="25" align="left">&nbsp;<asp:CheckBox ID="PrintAmount_Sum" Text="[<B>数量合计</B>]  是否显示" runat="server" Checked="true" /></td>
  </tr>
  <tr>
    <td height="25" align="left">&nbsp;<asp:CheckBox ID="PrintDiscount_Sum" Text="[<B>调价合计</B>]  是否显示" runat="server"  /></td>
    <td height="25" align="left">&nbsp;<asp:CheckBox ID="PrintTotalNet_Sum" Text="[<B>金额合计</B>]  是否显示" runat="server" Checked="true" /></td>
  </tr>
</table></td>
</tr>
	<tr><td height="25" colspan="4" align="left" bgcolor="#EFEFF7" class="tableBotcss" >&nbsp;&nbsp;<strong>底部模板设置</strong></td>
  </tr>
	<tr>
	  <td height="33" colspan="4" align="center" class="tableBotcss" >
	     <asp:TextBox ID="txtBotComtont" runat="server" style="display:none;"></asp:TextBox>
        <IFRAME src='../eWebEditor/ewebeditor.htm?id=txtBotComtont&style=coolblue' frameborder='0' scrolling='no' width='98%' height='350'></IFRAME>	  </td>
  </tr>
<tr>
	<td height="28" colspan="4">&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Text="确定库存盘点单打印模板修改" CssClass="Btt" OnClick="Button2_Click1"  />    	  </td>
	</tr>
</table>


<!--内容结束-->
    </td>
  </tr>
</table>


    </form>
</body>
</html>

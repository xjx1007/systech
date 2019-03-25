<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"  CodeFile="KnetWarehouse_Update.aspx.cs" Inherits="Knet_Web_System_KnetWarehouse_Update" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
<title></title>

<style type="text/css">
.Div11
{
  background-image:url(../images/KbottonB.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
.Div22
{
  background-image:url(../images/KbottonA.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
</style>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>


</head>

<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
<div id="ssdd" style="padding:1px"></div>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">仓库设置管理</div></td>
    <td  background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;&nbsp;</td>
    <td width="216" background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="center">&nbsp;</td>
  </tr>
</table>
<div id="Div1" style="padding:1px"></div>


<table  height="22" border="0" cellpadding="0" cellspacing="0" width="99%" align="center" >
      <tr>
        <td width="78" align="center"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="KnetWarehouse.aspx"  CssClass="Div11" Width="78px" Height="21px" Font-Size="14px">仓库列表</asp:HyperLink></td>
        <td width="4" align="center"></td>
        <td width="78" align="center"><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="KnetWarehouse_add.aspx"  CssClass="Div11" Width="78px" Height="21px" Font-Size="14px">仓库添加</asp:HyperLink></td>
        <td width="4" align="center"></td>
        <td width="78" align="center"><asp:HyperLink ID="HyperLink3" runat="server"  CssClass="Div22" Width="78px" Height="21px" Font-Size="14px"  Font-Bold="true" ForeColor="MintCream">仓库修改</asp:HyperLink></td>
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
        <td width="74%" >&nbsp;<asp:Label ID="HouseNotxt" runat="server"  Visible="false"></asp:Label></td>
      </tr>
      
      
      <tr>
        <td width="26%" height="30" align="right" class="tdcss">仓库名称:</td>
        <td width="74%" class="tdcss">&nbsp;<asp:TextBox ID="HouseName1" runat="server" CssClass="Boxx" Width="200px"  MaxLength="40"></asp:TextBox>(<font color="red">*</font>)<asp:RequiredFieldValidator
            ID="RequiredFieldValidator1" runat="server" ErrorMessage="仓库名称不能为空！" ControlToValidate="HouseName1" Display="Dynamic" ></asp:RequiredFieldValidator></td>
      </tr>
      
      <tr>
        <td height="30" align="right" class="tdcss">联系电话:</td>
        <td class="tdcss">&nbsp;<asp:TextBox ID="HouseTel1" runat="server" MaxLength="20" CssClass="Boxx" Width="200px"></asp:TextBox><asp:RegularExpressionValidator
                ID="RegularExpressionValidator4" runat="server" ErrorMessage="电话号码不正确!" ControlToValidate="HouseTel1" ValidationExpression="^(\(\d{3,4}\)|\d{3,4}-)?\d{7,11}$" Display="Dynamic" ></asp:RegularExpressionValidator></td>
      </tr>

       <tr>
        <td height="30" align="right" class="tdcss">联 系 人:</td>
        <td class="tdcss">&nbsp;<asp:TextBox ID="HouseMan1" runat="server" MaxLength="30" CssClass="Boxx" Width="200px"></asp:TextBox>(<font color="red">*</font>)<asp:RequiredFieldValidator
            ID="RequiredFieldValidator2" runat="server" ErrorMessage="联系人不能为空！" ControlToValidate="HouseMan1" Display="Dynamic" ></asp:RequiredFieldValidator></td>
      </tr>
      <tr>
        <td height="30" align="right" class="tdcss">仓库地址:</td>
        <td class="tdcss">&nbsp;<asp:TextBox ID="HouseAddress1" runat="server" MaxLength="80" CssClass="Boxx" Width="200px"></asp:TextBox>(<font color="red">*</font>)<asp:RequiredFieldValidator
            ID="RequiredFieldValidator3" runat="server" ErrorMessage="仓库地址不能为空！" ControlToValidate="HouseAddress1" Display="Dynamic" ></asp:RequiredFieldValidator></td>
      </tr>
      <tr>
        <td height="30" align="right" class="tdcss">是否开库:</td>
        <td class="tdcss">&nbsp;<asp:CheckBox ID="HouseYN1" runat="server" /><font color="gray">（开库请选勾）</font></td>
      </tr>
      

      
      <tr>
        <td height="30" align="right" class="tdcss">建库时间:</td>
        <td class="tdcss">&nbsp;<asp:TextBox ID="HouseDate1"   MaxLength="30" runat="server" CssClass="Wdate"   onClick="WdatePicker()"  ></asp:TextBox></td>
      </tr>
      <tr>
        <td align="right" class="tdcss">备注:</td>
        <td class="tdcss">&nbsp;<asp:TextBox ID="Remarks1" runat="server" CssClass="Boxx" Width="250px" Height="80px" TextMode="MultiLine"></asp:TextBox></td>
      </tr>
      <tr>
        <td align="right" height="50px">&nbsp;</td>
        <td>&nbsp;<asp:Button ID="Button1" runat="server" Text="修改仓库" CssClass="Btt" OnClick="Button1_Click" style="width: 55px;height: 33px;"  /></td>
      </tr>
    </table>



<%--内容块--%>



    </td>
  </tr>
</table>


    </form>
</body>
</html>

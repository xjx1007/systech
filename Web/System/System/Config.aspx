d<%@ Page Language="C#"  ValidateRequest="false" AutoEventWireup="true" CodeFile="Config.aspx.cs" Inherits="Knet_Web_System_Config" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../../css/knetwork.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
<title></title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">


<div id="Div1" style="padding:1px"></div>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">系统参数设置</div></td>
    <td  background="../../images/ktxt2.gif" >&nbsp;</td>
    <td background="../../images/ktxt2.gif" >&nbsp;</td>
  </tr>
</table>
<div id="ssdd" style="padding:1px"></div>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td><table width="99%" border="0">
      <tr>
        <td width="20%" height="20" align="right" class="tableBotcss">公司名称:</td>
        <td width="80%" align="left" class="tableBotcss">&nbsp;<asp:TextBox ID="CompanyName1" runat="server" Width="300px" CssClass="Boxx"></asp:TextBox>(<font color="red">*</font>)<asp:RequiredFieldValidator
            ID="RequiredFieldValidator1" runat="server" ErrorMessage="公司名称必填" ControlToValidate="CompanyName1" Display="Dynamic"></asp:RequiredFieldValidator></td>
      </tr>
	  
      <tr>
        <td  height="20" align="right" class="tableBotcss">用户编号:</td>
        <td  align="left" class="tableBotcss">&nbsp;<asp:TextBox ID="Sys_UserNo" runat="server" Width="300px" CssClass="Boxx" ></asp:TextBox>&nbsp;<asp:Image  ID="ImageCodeNo" runat="server" /></td>
      </tr>
      
      	        <tr>
        <td  height="20" align="right" class="tableBotcss">注册系列号:</td>
        <td  align="left" class="tableBotcss">&nbsp;<asp:TextBox ID="RegToSystem" runat="server" Width="300px" CssClass="Boxx2" ReadOnly="true" ></asp:TextBox>&nbsp;（系统自动获取，不可更改）</td>
      </tr>
	  
	    <tr>
        <td  height="20" align="right" class="tableBotcss">受权注册码:</td>
        <td  align="left" class="tableBotcss">&nbsp;<asp:TextBox ID="CodeKey1" runat="server" Width="300px" CssClass="Boxx" ></asp:TextBox>&nbsp;<asp:Image  ID="ImageCodeKey" runat="server" /></td>
      </tr>
	  

       <tr>
        <td height="20" align="right" class="tableBotcss">是否记录员工操作日志:</td>
        <td align="left" class="tableBotcss" valign="top"><asp:RadioButtonList ID="LogsYN1" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0"  Width="100px" >
        <asp:ListItem Value=1 Selected="true">是</asp:ListItem>
        <asp:ListItem Value=0>否</asp:ListItem>
        </asp:RadioButtonList></td>
      </tr>
	  
	  
       <tr>
        <td height="20" align="right" class="tableBotcss">产品缺货是否自动提示:</td>
        <td align="left" class="tableBotcss" valign="top"><asp:RadioButtonList ID="OutYN1" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0"  Width="100px" >
        <asp:ListItem Value=1 Selected="true">是</asp:ListItem>
        <asp:ListItem Value=0>否</asp:ListItem>
        </asp:RadioButtonList></td>
      </tr>
      

      <tr>
        <td height="20" align="right" class="tableBotcss">是否打开系统公告:</td>
        <td align="left" class="tableBotcss"><asp:RadioButtonList ID="NoticeYN1" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0"  Width="100px" >
        <asp:ListItem Value=1 Selected="true">是</asp:ListItem>
        <asp:ListItem Value=0>否</asp:ListItem>
        </asp:RadioButtonList></td>
      </tr>
	        <tr>
        <td height="25" align="right" class="tableBotcss">公告内容:</td>
        <td align="left" class="tableBotcss"><asp:TextBox ID="NoticeContent1" runat="server" style="display:none;"></asp:TextBox>
        <IFRAME src='../eWebEditor/ewebeditor.htm?id=NoticeContent1&style=coolblue' frameborder='0' scrolling='no' width='620' height='350'></IFRAME></td>
      </tr>
      
       <tr>
        <td height="25" align="right" >&nbsp;</td>
        <td align="left" >&nbsp;<asp:Button ID="Button1" runat="server" Text="确认基本配置" CssClass="Btt"   UseSubmitBehavior="false"  OnClick="Button1_Click" style="width: 55px;height: 33px;"  /></td>
      </tr>
    </table></td>
  </tr>
</table>


    </form>
</body>
</html>

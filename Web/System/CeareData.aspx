<%@ Page Language="C#"  ValidateRequest="false" AutoEventWireup="true" CodeFile="CeareData.aspx.cs" Inherits="Knet_Web_System_CeareData" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<title></title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">


<div id="Div1" style="padding:1px"></div>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">系统初始化</div></td>
    <td  background="../../images/ktxt2.gif" >&nbsp;</td>
    <td background="../../images/ktxt2.gif" >&nbsp;</td>
  </tr>
</table>
<div id="ssdd" style="padding:1px"></div>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td><table width="99%" border="0">
      <tr>
        <td height="49" colspan="2" align="left" class="tableBotcss" style="line-height:20px;"><strong>系统数据库初始化声明</strong>：系统初始化就是清除原有系统的数据记录，重新开始新的数据业务，所以一担初始化，原所有数据会丢失！<br />
          在操作之前建议先进行数据库备份工作！</td>
        </tr>
	  
      <tr>
        <td width="20%"  height="30" align="right" class="tableBotcss">采购入库初始化:</td>
        <td width="80%"  align="left" class="tableBotcss">&nbsp;<asp:Button ID="Button2" runat="server" Text="确定采购入库初始化" CssClass="Btt" CausesValidation="false" OnClick="Button2_Click"/>&nbsp;<asp:Label   ID="Label2" runat="server" Text="" Font-Bold="true" Font-Size="16px" ForeColor="red"></asp:Label></td>
      </tr>
      
      	        <tr>
        <td  height="30" align="right" class="tableBotcss">库存管理初始化:</td>
        <td  align="left" class="tableBotcss">&nbsp;<asp:Button ID="Button3" runat="server" Text="确定库存管理初始化" CssClass="Btt" CausesValidation="false" OnClick="Button3_Click"/>&nbsp;<asp:Label   ID="Label3" runat="server" Text="" Font-Bold="true" Font-Size="16px" ForeColor="red"></asp:Label></td>
      </tr>
	  
	    <tr>
        <td  height="30" align="right" class="tableBotcss">销售管理初始化:</td>
        <td  align="left" class="tableBotcss">&nbsp;<asp:Button ID="Button4" runat="server" Text="确定销售管理初始化" CssClass="Btt" CausesValidation="false" OnClick="Button4_Click"/>&nbsp;<asp:Label   ID="Label4" runat="server" Text="" Font-Bold="true" Font-Size="16px" ForeColor="red"></asp:Label></td>
      </tr>
	  

       <tr>
        <td height="30" align="right" class="tableBotcss">财务管理初始化:</td>
        <td align="left" class="tableBotcss" valign="top">&nbsp;<asp:Button ID="Button5" runat="server" Text="确定财务管理初始化" CssClass="Btt" CausesValidation="false" OnClick="Button5_Click"/>&nbsp;<asp:Label   ID="Label5" runat="server" Text="" Font-Bold="true" Font-Size="16px" ForeColor="red"></asp:Label></td>
      </tr>
	  
	  
       <tr>
        <td height="30" align="right" class="tableBotcss">人力资源初始化:</td>
        <td align="left" class="tableBotcss" valign="top">&nbsp;<asp:Button ID="Button6" runat="server" Text="确定人力资源初始化" CssClass="Btt" CausesValidation="false" OnClick="Button6_Click"/>&nbsp;<asp:Label   ID="Label6" runat="server" Text="" Font-Bold="true" Font-Size="16px" ForeColor="red"></asp:Label></td>
      </tr>
      

      <tr>
        <td height="30" align="right" class="tableBotcss">系统日志初始化:</td>
        <td align="left" class="tableBotcss">&nbsp;<asp:Button ID="Button7" runat="server" Text="确定系统日志初始化" CssClass="Btt" CausesValidation="false" OnClick="Button7_Click"/>&nbsp;<asp:Label   ID="Label7" runat="server" Text="" Font-Bold="true" Font-Size="16px" ForeColor="red"></asp:Label></td>
      </tr>
	        <tr>
        <td height="30" align="right" class="tableBotcss">产品字典初始化:</td>
        <td align="left" class="tableBotcss">&nbsp;<asp:Button ID="Button8" runat="server" Text="确定产品字典初始化"  CssClass="Btt" CausesValidation="false" OnClick="Button8_Click"/>&nbsp;<asp:Label   ID="Label8" runat="server" Text="" Font-Bold="true" Font-Size="16px" ForeColor="red"></asp:Label></td>
      </tr>
      
      <tr>
        <td height="30" align="right" class="tableBotcss">供应商初始化:</td>
        <td align="left" class="tableBotcss">&nbsp;<asp:Button ID="Button1" runat="server" Text="确定供应商初始化"  CssClass="Btt" CausesValidation="false" OnClick="Button1_Click"/>&nbsp;<asp:Label   ID="Label1" runat="server" Text="" Font-Bold="true" Font-Size="16px" ForeColor="red"></asp:Label></td>
      </tr>
      
      
      
       <tr>
        <td height="25" align="right" >&nbsp;</td>
        <td align="left" >&nbsp;</td>
      </tr>
    </table></td>
  </tr>
</table>



    </form>
</body>
</html>

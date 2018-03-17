<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_Sales_ClientList_Details.aspx.cs" Inherits="Knet_Web_Sales_KNet_Sales_ClientList_Details" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<title>客户详细信息</title>
<script language=javascript>
function preview() { 
bdhtml=window.document.body.innerHTML; 
sprnstr="<!--startprint-->"; 
eprnstr="<!--endprint-->"; 
prnhtml=bdhtml.substr(bdhtml.indexOf(sprnstr)+17); 
prnhtml=prnhtml.substring(0,prnhtml.indexOf(eprnstr)); 
window.document.body.innerHTML=prnhtml; 
window.print(); 
window.document.body.innerHTML=bdhtml; 
         }
</script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>
<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="93%" height="30" align="center" style="border-bottom:#333333 1px dotted;"><img src="../../images/print.gif" width="36" height="34" border="0" style="cursor:hand;" onClick="preview();window.close()" /></td>
    <td width="7%" height="30" align="left" style="border-bottom:#333333 1px dotted;"><img src="../../images/Close.gif" width="32" height="32" border="0" style="cursor:hand;" onClick="window.close()" ></td>
  </tr>
</table>
<!--startprint-->
<table width="98%" height="261" border="0" align="center" cellpadding="0" cellspacing="0">
   <tr>
        <td height="40" colspan="4" align="center" style="border-bottom:#333333 2px solid;" ><span class="font18px">客户详细信息</span></td>
  </tr>
	  
      <tr>
        <td width="16%" height="25" align="right" style="border-bottom:#333333 1px solid;">产品名称:</td>
        <td style="border-bottom:#333333 1px solid;" align="left">&nbsp;<asp:Label ID="CustomerName" runat="server" Text=""></asp:Label></td>
        <td align="right" style="border-bottom:#333333 1px solid;">客户编号:</td>
        <td style="border-bottom:#333333 1px solid;">&nbsp;<asp:Label ID="CustomerValue" runat="server" Text=""></asp:Label></td>
      </tr>
      
      <tr>
        <td width="16%" height="25" align="right" style="border-bottom:#333333 1px solid;">渠道信息:</td>
        <td width="34%" style="border-bottom:#333333 1px solid;">&nbsp;<asp:Label ID="CustomerClass" runat="server" Text=""></asp:Label></td>
        <td width="17%" align="right" style="border-bottom:#333333 1px solid;">客户类型:</td>
        <td width="33%" style="border-bottom:#333333 1px solid;">&nbsp;<asp:Label ID="CustomerTypes" runat="server" Text=""></asp:Label></td>
      </tr>

        
      <tr>
        <td height="25" align="right" style="border-bottom:#333333 1px solid;">客户行业:</td>
        <td style="border-bottom:#333333 1px solid;">&nbsp;<asp:Label ID="CustomerTrade" runat="server" Text=""></asp:Label></td>
        <td align="right" style="border-bottom:#333333 1px solid;">客户来源:</td>
        <td style="border-bottom:#333333 1px solid;">&nbsp;<asp:Label ID="CustomerSource" runat="server" Text=""></asp:Label></td>
      </tr>


      <tr>
        <td height="25" align="right" style="border-bottom:#333333 1px solid;">所在省份:</td>
        <td style="border-bottom:#333333 1px solid;">&nbsp;<asp:Label ID="CustomerProvinces" runat="server" Text=""></asp:Label></td>
	
	
        <td align="right" style="border-bottom:#333333 1px solid;">所在城区:</td>
        <td style="border-bottom:#333333 1px solid;">&nbsp;<asp:Label ID="CustomerCity" runat="server" Text=""></asp:Label></td>
      </tr>
	  
	        <tr>
        <td height="25" align="right" style="border-bottom:#333333 1px solid;">负 责 人:</td>
        <td style="border-bottom:#333333 1px solid;">&nbsp;<asp:Label ID="CustomerContact" runat="server" Text=""></asp:Label></td>
        <td align="right" style="border-bottom:#333333 1px solid;"><b>是否保护客户:</b></td>
        <td style="border-bottom:#333333 1px solid;">&nbsp;<asp:Label ID="CustomerProtect" runat="server" Text=""></asp:Label></td>
      </tr>
	  
      <tr>
        <td height="25" align="right"  style="border-bottom:#333333 1px solid;">移动电话:</td>
        <td style="border-bottom:#333333 1px solid;">&nbsp;<asp:Label ID="CustomerMobile" runat="server" Text=""></asp:Label></td>
        <td align="right" style="border-bottom:#333333 1px solid;">固定电话:</td>
        <td style="border-bottom:#333333 1px solid;">&nbsp;<asp:Label ID="CustomerTel" runat="server" Text=""></asp:Label></td>
      </tr>
	  
	        <tr>
        <td height="25" align="right"  style="border-bottom:#333333 1px solid;">客户网址:</td>
        <td style="border-bottom:#333333 1px solid;">&nbsp;<asp:Label ID="CustomerWebsite" runat="server" Text=""></asp:Label></td>
        <td align="right" style="border-bottom:#333333 1px solid;">电子邮箱:</td>
        <td style="border-bottom:#333333 1px solid;">&nbsp;<asp:Label ID="CustomerEmail" runat="server" Text=""></asp:Label></td>
      </tr>
	  
	  <tr>
        <td height="25" align="right"  style="border-bottom:#333333 1px solid;">联系QQ号:</td>
        <td style="border-bottom:#333333 1px solid;">&nbsp;<asp:Label ID="CustomerQQ" runat="server" Text=""></asp:Label></td>
        <td align="right" style="border-bottom:#333333 1px solid;">联系Msn号:</td>
        <td style="border-bottom:#333333 1px solid;">&nbsp;<asp:Label ID="CustomerMsn" runat="server" Text=""></asp:Label></td>
      </tr>
	  <tr>
        <td height="25" align="right"  style="border-bottom:#333333 1px solid;">通信地址:</td>
        <td style="border-bottom:#333333 1px solid;">&nbsp;<asp:Label ID="CustomerAddress" runat="server" Text=""></asp:Label></td>
        <td align="right" style="border-bottom:#333333 1px solid;">邮政编码:</td>
        <td style="border-bottom:#333333 1px solid;">&nbsp;<asp:Label ID="CustomerZipCode" runat="server" Text=""></asp:Label></td>
      </tr>
	  
	  	  	  	        <tr>
        <td height="25" align="right"  style="border-bottom:#333333 1px solid;">客户积分:</td>
        <td style="border-bottom:#333333 1px solid;">&nbsp;<asp:Label ID="CustomerIntegral" runat="server" Text=""></asp:Label></td>
        <td align="right" style="border-bottom:#333333 1px solid;">加入日期:</td>
        <td style="border-bottom:#333333 1px solid;">&nbsp;<asp:Label ID="CustomerAddtime" runat="server" Text=""></asp:Label></td>
      </tr>
      
      <tr>
        <td height="41" align="right" style="border-bottom:#333333 1px solid;">客户简介:</td>
        <td colspan="3" style="border-bottom:#333333 1px solid;" ><asp:Label ID="CustomerIntroduction" runat="server" Text=""></asp:Label></td>
      </tr>
      <tr>
        <td height="30" align="right">&nbsp;</td>
        <td align="left">&nbsp;</td>
        <td colspan="2" align="left">制表人:
          <asp:Label ID="makeMan" runat="server" Text=""  Width="100px" CssClass="Boxx" ></asp:Label>          &nbsp;&nbsp;&nbsp;制表时间:
        <asp:Label ID="makeTime" runat="server" Text=""  Width="100px" CssClass="Boxx" ></asp:Label>          &nbsp;</td>
      </tr>
</table>
<!--endprint-->
    </div>
    </form>
</body>
</html>

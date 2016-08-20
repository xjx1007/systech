<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="KNet_HR_Manage_Print.aspx.cs"
    Inherits="Knet_Web_KNet_HR_Manage_Print" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetPrint.css" type="text/css">
<title>出差任务书</title>
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
    <style type="text/css">
        .style1
        {
            height: 25px;
        }
    </style>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>
<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
<asp:TextBox ID="Tbx_ID" runat="server" style="display:none"></asp:TextBox>
    <td width="93%" height="30" align="center" style="border-bottom:#333333 1px dotted;"><img src="../../images/print.gif" width="36" height="34" border="0" style="cursor:hand;" onClick="preview();window.close()" /></td>
    <td width="7%" height="30" align="left" style="border-bottom:#333333 1px dotted;"><img src="../../images/Close.gif" width="32" height="32" border="0" style="cursor:hand;" onClick="window.close()" ></td>
  </tr>
</table>
<!--startprint-->
<table width="98%" height="241" border="0" align="center" cellpadding="0" cellspacing="0">
   <tr>
        <td height="40" colspan="4" align="center" ><span class="font18px">出  差  任  务  书</span></td>
  </tr>
	  
      <tr>
        <td width="16%" height="25" align="right" style="border: 1px solid #000000;" 
            >出差人:</td>
        <td  align="left" 
              style="border-top-width: 1px; border-color: #000000; border-top-style: solid; border-bottom-style: solid; border-bottom-width: 1px; border-right-style: solid; border-right-width: 1px;">&nbsp;<asp:Label ID="Lbl_StaffNo" runat="server" Text=""></asp:Label></td>
        <td align="right" 
              style="border-color: #000000; border-top-width: 1px; border-right-width: 1px; border-bottom-width: 1px; border-top-style: solid; border-right-style: solid; border-bottom-style: solid" >出差时间:</td>
        <td style="border-top-width: 1px; border-color: #000000; border-top-style: solid; border-bottom-style: solid; border-bottom-width: 1px; border-right-style: solid; border-right-width: 1px;" >&nbsp;<asp:Label ID="Lbl_Time" runat="server" Text=""></asp:Label></td>
      </tr>
      
      <tr>
        <td width="16%" align="right" 
              style="border-color: #000000; border-bottom-style: solid; border-left-style: solid; border-bottom-width: 1px; border-left-width: 1px; border-right-style: solid; border-right-width: 1px;" 
              class="style1" >目的地:</td>
        <td width="34%" 
              style=" border-color: #000000; border-bottom-style: solid; border-bottom-width: 1px; border-right-style: solid; border-right-width: 1px;" 
              class="style1">&nbsp;<asp:Label ID="Lbl_Place" runat="server" Text=""></asp:Label></td>
        <td width="17%" 
              style=" border-bottom-style: solid; border-bottom-width: 1px; border-right-style: solid; border-right-width: 1px; border-right-color: #000000; border-bottom-color: #000000;" 
              align="right" class="style1" >交通工具:</td>
        <td width="33%" 
              style=" border-color: #000000; border-bottom-style: solid; border-bottom-width: 1px; border-right-style: solid; border-right-width: 1px;" 
              class="style1" >&nbsp;<asp:Label ID="Lbl_Tracfic" runat="server" Text=""></asp:Label></td>
      </tr>
      <tr>
        <td height="25" align="right"  style="border-color: #000000; border-bottom-style: solid; border-left-style: solid; border-bottom-width: 1px; border-left-width: 1px; border-right-style: solid; border-right-width: 1px;" >出差任务:</td>
        <td  colspan="3" 
              style="border-color: #000000; border-right-style: solid; border-right-width: 1px;">&nbsp;<asp:Label ID="Lbl_Remarks" runat="server" Text=""></asp:Label></td>
      </tr>
      <tr>
        <td height="25" align="right" style="border-color: #000000; border-bottom-style: solid; border-left-style: solid; border-bottom-width: 1px; border-left-width: 1px; border-right-style: solid; border-right-width: 1px;"  >部门经理:</td>
        <td style="border-top-width: 1px; border-color: #000000; border-top-style: solid; border-bottom-style: solid; border-bottom-width: 1px; border-right-style: solid; border-right-width: 1px;">&nbsp;<asp:Label ID="Lbl_BPerson" runat="server" Text=""></asp:Label></td>
        <td align="right" style="border-top-width: 1px; border-color: #000000; border-top-style: solid; border-bottom-style: solid; border-bottom-width: 1px; border-right-style: solid; border-right-width: 1px;" >总经理:</td>
        <td style="border-top-width: 1px; border-color: #000000; border-top-style: solid; border-bottom-style: solid; border-bottom-width: 1px; border-right-style: solid; border-right-width: 1px;">&nbsp;<asp:Label ID="Lbl_ZPerson" runat="server" Text=""></asp:Label></td>
      </tr>
</table>
<!--endprint-->
    </div>
    </form>
</body>
</html>

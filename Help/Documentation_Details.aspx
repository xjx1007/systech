<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Documentation_Details.aspx.cs" Inherits="Knet_AKNet_Documentation_Details" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetPrint.css" type="text/css">
<title>查看详细</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0"  >
    <form id="form1" runat="server">
    <div>
<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="93%" height="30" align="center" style="border-bottom:#333333 1px dotted;">&nbsp;</td>
    <td width="7%" height="30" align="left" style="border-bottom:#333333 1px dotted;"><img src="../images/Close.gif" width="32" height="32" border="0" style="cursor:hand;" onClick="window.close()" ></td>
  </tr>
</table>
<!--startprint-->
<table width="96%"  border="0" align="center" cellpadding="0" cellspacing="0" >
  <tr>
    <td height="31" colspan="2" align="left" style="border-bottom:#333333 2px solid;" ><span class="font18px"> <asp:Label ID="Titles" runat="server" Text=""></asp:Label></span></td>
  </tr>

  <tr>
    <td width="15%" height="25" align="right" style="border-bottom:#333333 1px solid;">发布时间:</td>
    <td style="border-bottom:#333333 1px solid;" >&nbsp;<asp:Label ID="Addtimes" runat="server" Text=""></asp:Label></td>
  </tr>
  
  
        <tr>
    <td height="35" colspan="2" align="left" valign="top"  class="font1Q4"  style="word-break:break-all;word-wrap:break-word;width:880px;"><asp:Label ID="coms" runat="server" Text=""></asp:Label></td>
  </tr>
</table>
    

<!--endprint-->
<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="93%" height="30" align="center" style="border-bottom:#333333 1px dotted;">&nbsp;</td>
    <td width="7%" height="30" align="left" style="border-bottom:#333333 1px dotted;"><img src="../images/Close.gif" width="32" height="32" border="0" style="cursor:hand;" onClick="window.close()" ></td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>

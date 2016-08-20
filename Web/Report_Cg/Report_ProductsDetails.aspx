<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_ProductsDetails.aspx.cs" Inherits="Web_Report_Xs_Report_CkDetails" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<script language="javascript" type="text/javascript" src="../js/Global.js"></script>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <title>产品明细</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
<div class="TitleBar">产品明细</div>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss_add">

          <tr>
                <td width="17%" height="25" align="right" class="tableBotcss">产品名称:</td>
                <td align="left" class="tableBotcss"><asp:TextBox ID="Tbx_Name" runat="Server"></asp:TextBox></td>
                <td align="right" class="tableBotcss">产品型号:</td>
                <td align="left" class="tableBotcss1"><asp:TextBox ID="Tbx_Pattern" runat="Server"></asp:TextBox></td>
            </tr>
          <tr>
                <td width="17%" height="25" align="right" class="tableBotcss">产品版本:</td>
                <td align="left" class="tableBotcss"><asp:TextBox ID="Tbx_Edition" runat="Server"></asp:TextBox></td>
                <td align="right" class="tableBotcss">产品分类:</td>
                <td align="left" class="tableBotcss1"><asp:DropDownList ID="ProductsMainCategory" runat="server" Width="150px" ></asp:DropDownList></td>
            </tr>
          <tr>
            <td class="tableBotcss" colspan="4" align="center">
            <asp:Button runat="Server" ID="Btn_Query" class="Custom_Button" Text="确定" OnClick="Btn_Query_Click" />&nbsp;
            <input type="button" class="Custom_Button" value="返回" onclick="PageGo('../Report/Xs_Report_Base.aspx')"></td>
          </tr>
    </table>
    
    </div>
    </form>
</body>
</html>


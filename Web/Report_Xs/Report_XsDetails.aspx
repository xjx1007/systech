<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_XsDetails.aspx.cs" Inherits="Web_Report_Xs_Report_XsDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<script language="javascript" type="text/javascript" src="../js/Global.js"></script>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <title>销售发货明细</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
<div class="TitleBar">销售发货明细</div>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss_add">
            <tr>
                 <td class="tableBotcss" width="15%" style="height: 30px; text-align: right">日期：</td>
                <td class="tableBotcss1" width="35%" style="height: 30px; text-align: left" colspan="3"><asp:TextBox ID="StartDate" runat="server" CssClass="Wdate"  onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})" ></asp:TextBox>&nbsp;到<asp:TextBox ID="EndDate" runat="server"  CssClass="Wdate"   onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})" ></asp:TextBox></td>
            </tr>
          <tr>
                <td width="17%" height="25" align="right" class="tableBotcss">客户名称:</td>
                <td align="left" class="tableBotcss"><asp:TextBox ID="Tbx_CustomerName" runat="Server"></asp:TextBox></td>
                <td align="right" class="tableBotcss">产品型号:</td>
                <td align="left" class="tableBotcss1"><asp:TextBox ID="Tbx_Type" runat="Server"></asp:TextBox></td>
            </tr>
          <tr>
                <td width="17%" height="25" align="right" class="tableBotcss">客户类别:</td>
                <td align="left" class="tableBotcss" colspan="3"><asp:DropDownList ID="Tbx_CustomerTypes" runat="server"  >
                </asp:DropDownList></td>
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
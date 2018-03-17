<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_SuppPrice.aspx.cs" Inherits="Web_Report_Xs_Report_CkDetails" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css" />
<script language="javascript" type="text/javascript" src="../js/Global.js"></script>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <title>供应商报价表</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
<div class="TitleBar">供应商报价表</div>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss_add">

          <tr>
                <td width="17%" height="25" align="right" class="tableBotcss">供应商名称:</td>
                <td align="left" class="tableBotcss" colspan="3"><asp:TextBox ID="Tbx_SuppName" runat="Server"></asp:TextBox></td>
            </tr>
          <tr>
                <td width="17%" height="25" align="right" class="tableBotcss">大类:</td>
                <td align="left" class="tableBotcss" >
            <select id="BigClass" style="width:140px" runat="server"  onchange="changsheng(this.value)">
            <option value="0">--请选择大类--</option></select></td>
                <td width="17%" height="25" align="right" class="tableBotcss">小类:</td>
                <td align="left" class="tableBotcss" ><select id="SmallClass" runat="server" style="width: 140px" >
	            <option value="0">--请选择小类--</option>
                </select>
                </td>
            </tr>
 

          <tr>
                <td width="17%" height="25" align="right" class="tableBotcss">产品名称:</td>
                <td align="left" class="tableBotcss" colspan="3"><asp:TextBox ID="Tbx_ProductsName" runat="Server"></asp:TextBox></td>
            </tr>
          <tr>
            <td class="tableBotcss" colspan="4" align="center">
            <asp:Button runat="Server" ID="Btn_Query" class="Custom_Button" Text="确定" OnClick="Btn_Query_Click" />&nbsp;
            <input type="button" class="Custom_Button" value="返回" onclick="PageGo('../Report/Cg_Report_Base.aspx')"></td>
          </tr>
    </table>
    
    </div>
    </form>
</body>
</html>


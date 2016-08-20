<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Xs_ShipCheck_Condition.aspx.cs" Inherits="Web_Report_Xs_Xs_ShipCheck_Condition" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css" />
    <title>发货对账单</title>
</head>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<script type="text/javascript" src="../KDialog/lhgdialog.js"></script>
<body>
    <form id="form1" runat="server">
    
     <div class="TitleBar">发货对账单</div>
    

    <table width="100%" border="0"   cellpadding="0" cellspacing="0" align="center" class="tablecss" >
 <tr>
  <td width="17%" align="right" class="tableBotcss" style="height: 25px">&nbsp;开始日期:</td>
    <td width="36%" align="left" class="tableBotcss" style="height: 25px"><asp:TextBox ID="BeginDate" runat="server"  MaxLength="20"  CssClass="Wdate" onClick="WdatePicker()" ></asp:TextBox></td>
  <td align="right" class="tableBotcss" style="color: #000000; height: 33px;">
        结束日期：</td>
    <td align="left" class="tableBotcss1" style="height: 33px"><asp:TextBox ID="EndDate" runat="server"  MaxLength="20"  CssClass="Wdate" onClick="WdatePicker()" ></asp:TextBox>
   </td>
  </tr>
   <tr>
  <td width="17%" align="right" class="tableBotcss" style="height: 25px">&nbsp;客户名称:</td>
    <td width="36%" align="left" class="tableBotcss1" style="height: 25px" colspan="3"><asp:TextBox ID="Tbx_CustomerName" runat="server" CssClass="Boxx" Width="350px" ></asp:TextBox></td>
    </tr>
   <tr><td colspan="4" align="center"><br /><asp:Button ID="Btn_Save" runat="server"  CssClass="Custom_Button" Text="保 存" OnClick="Btn_Save_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Btn_Reset" runat="server"  CssClass="Custom_Button" Text="取 消" /><br />
   </td></tr>
   
    </table>
        
    </form> 
</body>
</html>
            
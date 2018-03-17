<%@ Page Language="C#" AutoEventWireup="true"  ValidateRequest="false"  CodeFile="Knet_Sales_Ship_Manage_Talks_Add.aspx.cs" Inherits="KNet_Web_Sales_Knet_Sales_Ship_Manage_Talks_Add" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
<link rel="stylesheet" href="/Web/css/knetwork.css" type="text/css">
<script type="text/javascript">
     if(window != window.parent) 
     { var P = window.parent, D = P.loadinndlg(); }

     function searchFromSelect(str) {
         var o = document.getElementById("Drop_KD");
         if (o.tagName == "SELECT") {
             var opts = o.options;
             str = str ? str : event.srcElement.innerText;

             var tmp = '';
             var kCode = event.keyCode;

             if (str != "") {
                 if (kCode == 33 || kCode == 38 || kCode == 35)//向上翻页，方向键，end
                 {
                     o.selectedIndex = o.selectedIndex > 0 ? o.selectedIndex - 1 : 0;
                     if (kCode == 35) o.selectedIndex = opts.length - 1;
                     for (var i = o.selectedIndex; i >= 0; i--) {
                         tmp = opts(i % opts.length).text;
                         if (tmp.indexOf(str) >= 0) {
                             o.selectedIndex = i % opts.length;
                             return;
                         }
                     }
                 }
                 if (kCode == 34 || kCode == 40 || kCode == 36)//
                 {
                     o.selectedIndex++;
                     if (kCode == 36) o.selectedIndex = opts.length - 1;
                 }
                 for (var i = o.selectedIndex; i < (opts.length + o.selectedIndex); i++) {
                     tmp = opts(i % opts.length).text;
                     if (tmp.indexOf(str) >= 0) {
                         o.selectedIndex = i % opts.length;
                         return;
                     }
                 }
                 o.selectedIndex = 0;
             }
         }
     }
     function Chang() {
         var v_FollowEnd = document.getElementById("FollowEnd");

         if (v_FollowEnd.checked) {
             var v_Type = document.getElementById("Ddl_Type");
             if (v_Type.options[v_Type.selectedIndex].text != "--请选择--") {
                 document.getElementById("FollowText").value = v_Type.options[v_Type.selectedIndex].text;
             }
         }
         else {
             var myid = document.getElementById("Drop_KD");
             if (myid.options[myid.selectedIndex].text == "--请选择--") {
                 document.getElementById("FollowText").value = document.getElementById("Tbx_Code").value;
             }
             else {
                 if (document.getElementById("Tbx_Code").value != "") {
                     document.getElementById("FollowText").value = myid.options[myid.selectedIndex].text + "(" + document.getElementById("Tbx_Code").value + ")";
                 }
                 else {
                     document.getElementById("FollowText").value = myid.options[myid.selectedIndex].text;
                 }
             }
         }
           
     }

</script>

<style type="text/css">
.Div11
{
  background-image:url(../images/midbottonA2.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
.Div22
{
  background-image:url(../images/midbottonB2.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
</style>

<title>发货跟踪添加</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div id="ListGo333">
<div id="ssdd" style="padding:2px"></div>
<table  height="22" border="0" cellpadding="0" cellspacing="0" width="100%" align="center" >
      <tr>
        <td width="90" align="center"><asp:HyperLink ID="HyperLink1" runat="server" CssClass="Div11" Width="90px" Height="21px" Font-Size="14px">跟踪列表</asp:HyperLink></td>
        <td width="4" align="center"></td>
        <td width="90" align="center"><asp:HyperLink ID="HyperLink2" runat="server" CssClass="Div22" Width="90px" Height="21px" Font-Size="14px"    Font-Bold="true" ForeColor="MintCream">添加跟踪</asp:HyperLink></td>
        <td width="4" align="center"></td>
        <td align="right">&nbsp;&nbsp;</td>
      </tr>
</table>

<table width="100%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
    
<table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="25%" height="25" align="right"  class="tableBotcss">是否结束：</td>
    <td width="75%"  class="tableBotcss">&nbsp;<asp:CheckBox ID="FollowEnd" runat="server" AutoPostBack="True" 
            oncheckedchanged="FollowEnd_CheckedChanged"  />&nbsp;&nbsp;<font color=gray>(如果已完成，结束跟踪请打“√”)</font></td>
  </tr>
  <tr  id="Tr_Qr" runat="server" visible="false">
    <td height="34" align="right"  class="tableBotcss">确认方式：</td>
    <td  class="tableBotcss"><asp:DropDownList ID="Ddl_Type" runat="server" Width="150px" onchange='Chang()'></asp:DropDownList></td>
  </tr>
  <tr >
    <td height="34" align="right"  class="tableBotcss">动态跟踪情况：</td>
    <td  class="tableBotcss"><asp:TextBox ID="FollowText" runat="server" TextMode="MultiLine" Height="60px" Width="350px" CssClass="Boxx"></asp:TextBox></td>
  </tr>
  <asp:Panel ID="Pan_Details" runat="server">
  <tr >
    <td height="34" align="right"  class="tableBotcss">快递：</td>
    <td  class="tableBotcss"><asp:DropDownList ID="Drop_KD" runat="server" Width="150px" onchange='Chang()'></asp:DropDownList>
    <input type="text" id="span" onchange='Chang()' onkeyup='searchFromSelect(this.value)' onkeydown='window.event.cancelBubble = true;if(event.keyCode==13){return false;}' style="width: 60; height: 20; border: 1 solid #0000FF;overflow-y:auto"></input></td>
  </tr>
  <tr >
    <td height="34" align="right"  class="tableBotcss">单号：</td>
    <td  class="tableBotcss"><asp:TextBox ID="Tbx_Code" runat="server" Height="60px" Width="350px" CssClass="Boxx" onchange='Chang()'></asp:TextBox></td>
  </tr>
  <tr runat="server" id="Tr_time" visible="false" >
    <td height="34" align="right"  class="tableBotcss">确定交期：</td>
    <td  class="tableBotcss"><asp:TextBox ID="Tbx_Time" runat="server" CssClass="Wdate" onFocus="WdatePicker();"></asp:TextBox></td>
  </tr>
  </asp:Panel>
  <tr>
    <td align="right" style="height: 28px">&nbsp;</td>
    <td style="height: 28px">&nbsp;<asp:Button ID="Button1" runat="server" Text="确定添加跟踪" CssClass="Btt" OnClick="Button1_Click" style="width: 55px;height: 33px;"  /></td>
  </tr>
</table>
        <asp:TextBox ID="Tbx_OldTime" runat="server" CssClass="Custom_Hidden"></asp:TextBox>

    </td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>

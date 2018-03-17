<%@ Page Language="C#" AutoEventWireup="true"   CodeFile="SelectClientList.aspx.cs" Inherits="Knet_Common_SelectClientList" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link rel="stylesheet" href="../../themes/softed/style.css" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" >
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
<base target="_self" />
<script>
    function closeWindow() {
        window.opener = null;
        window.close();
    }
    function changsheng(va) {
        if (va != '0') {
            var city = document.getElementById("city");
            city.disabled = false;
            var url = "../Js/Handler.ashx?type=sheng&id=" + va;
            send_request("GET", url, null, "text", populateClass3);
        }
    }
    function populateClass3() {
        var f = document.getElementById("city");
        if (http_request.readyState == 4) {
            if (http_request.status == 200) {
                var list = http_request.responseText;
                var classList = list.split("|");
                f.options.length = 1;
                for (var i = 0; i < classList.length; i++) {
                    var tmp = classList[i].split(",");
                    f.add(new Option(tmp[1], tmp[0]));
                }
            } else {
                alert("您所请求的页面有异常。");
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
<title>选择客户</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="small" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">选择客户</div></td>
    <td width="320" align="right"  background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;客户搜索:<asp:TextBox ID="SeachKey" runat="server" Width="200px" CssClass="Boxx"></asp:TextBox></td>
    <td background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="left">&nbsp;<asp:Button ID="Button1" runat="server" Text="搜索"  CssClass="crmButton small create"  OnClick="Button1_Click1" /></td>
  </tr>
</table>
<div id="ssdd" style="padding:2px"></div>
<table  height="22" border="0" cellpadding="0" cellspacing="0" width="99%" align="center" >
      <tr>
        <td width="90" align="center"><asp:HyperLink ID="HyperLink2" runat="server" CssClass="Div11" Width="90px" Height="21px" Font-Size="14px"  >保护客户</asp:HyperLink></td>
        <td width="4" align="center"></td>
        <td width="90" align="center"><asp:HyperLink ID="HyperLink1" runat="server" CssClass="Div22" Width="90px" Height="21px" Font-Size="14px" Font-Bold="true" ForeColor="MintCream">普通客户</asp:HyperLink></td>
        <td width="4" align="center"></td>
        <td align="right">&nbsp;&nbsp;</td>
      </tr>
</table>
<!--头部-->
<%--内部开始--%>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="small">
  <tr>
    <td>
<!--GridView-->
            
                    <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True"
                        IsShowEmptyTemplate="true" EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>"
                        AutoGenerateColumns="False" PageSize="10" Width="100%" >
                        <Columns>

        
        <asp:TemplateField HeaderText="选择" HeaderStyle-Font-Size="12px" ItemStyle-Width="40px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <HeaderTemplate> 
                 <input type="CheckBox" onclick="selectAll(this)">
                 </HeaderTemplate>
                 <ItemTemplate>
                     <asp:CheckBox ID="Chbk" runat="server"  />
                 </ItemTemplate>
        </asp:TemplateField>
        
        
        <asp:BoundField  DataField="CustomerName"  HeaderText="客户名称"  SortExpression="CustomerName">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        
         <asp:TemplateField HeaderText="省份"  SortExpression="CustomerProvinces" HeaderStyle-Font-Size="12px"  ItemStyle-Width="90px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetClient_CustomerProvinces(DataBinder.Eval(Container.DataItem, "CustomerProvinces"))%>
          </ItemTemplate>
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="渠道信息"  SortExpression="CustomerClass" HeaderStyle-Font-Size="12px"  ItemStyle-Width="90px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetClient_Name(DataBinder.Eval(Container.DataItem, "CustomerClass"))%>
          </ItemTemplate>
        </asp:TemplateField>
        
         <asp:TemplateField HeaderText="客户类型"  SortExpression="CustomerTypes" HeaderStyle-Font-Size="12px"  ItemStyle-Width="90px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetClient_Name(DataBinder.Eval(Container.DataItem, "CustomerTypes"))%>
          </ItemTemplate>
        </asp:TemplateField>
        
         <asp:BoundField    HeaderText="负责人"   DataField="CustomerContact" ItemStyle-Font-Size="12px" ItemStyle-Width="70px"   HeaderStyle-Font-Size="12px"   SortExpression="CustomerContact">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField> 
        
         <asp:BoundField   HeaderText="移动电话"  DataField="CustomerMobile" ItemStyle-Font-Size="12px"   ItemStyle-Width="90px"   HeaderStyle-Font-Size="12px"   SortExpression="CustomerMobile">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField> 
        
        <asp:BoundField   HeaderText="固家电话"  DataField="CustomerTel" ItemStyle-Font-Size="12px"   ItemStyle-Width="90px"   HeaderStyle-Font-Size="12px"   SortExpression="CustomerTel">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField> 
 
        </Columns>
         
                        <HeaderStyle CssClass='colHeader' />
                        <RowStyle CssClass='listTableRow' />
                        <AlternatingRowStyle BackColor="#E3EAF2" />
                        <PagerStyle CssClass='Custom_DgPage' />
                    </cc1:MyGridView>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="30" width="54%">&nbsp;<asp:Button ID="Button2" runat="server"  CssClass="crmButton small save" Text="确定选择" OnClick="Button1_Click"   />&nbsp;&nbsp;&nbsp;&nbsp;<input   name="button2"   type="button"   value="关闭窗口"  class="crmButton small create"  onclick="closeWindow();"></td>
      <td width="39%" align="right" ><select id="sheng" style="width:90px" runat="server" onchange="changsheng(this.value)"><option value="0">选择省份</option></select>&nbsp;<select id="city" runat="server" style="width:100px" ><option value="0">--选择城区--</option></select></td>
      <td width="7%" align="left" ><asp:Button ID="Button4" runat="server" Text="筛选"  CssClass="crmButton small create"  OnClick="Button12_Click1" /></td>
  </tr>
</table>
<!--底部功能栏-->

    </td>
  </tr>
</table>
<!--内部结束-->


    </div>
    </form>
</body>
</html>

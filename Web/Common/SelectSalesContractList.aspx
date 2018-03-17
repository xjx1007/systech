<%@ Page Language="C#" AutoEventWireup="true"   CodeFile="SelectSalesContractList.aspx.cs" Inherits="Knet_Common_SelectSalesContractList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<script>   
  function closeWindow()   
  {   
  window.opener=null;   
  window.close();   
  }  
</script> 
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../js/Global.js"></script>
<title>选择合同单</title>
<base target="_self" />
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>
 <div class="TitleBar">选择合同单</div>
<!--头部-->
<%--内部开始--%>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
<!--GridView-->

        <table width="100%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss_Select">
            <tr>
                <td class="tableBotcss" width="10%" style="height: 30px; text-align: right">日期：</td>
                <td class="tableBotcss1" width="50%" style="height: 30px; text-align: left" ><asp:TextBox ID="StartDate" runat="server" CssClass="Wdate"  onFocus="var EndDate=$dp.$('EndDate');WdatePicker({maxDate:'#F{$dp.$D(\'EndDate\')}'})" ></asp:TextBox>&nbsp;到<asp:TextBox ID="EndDate" runat="server"  CssClass="Wdate"   onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})" ></asp:TextBox></td>

                <td class="tableBotcss" width="15%" style="height: 30px; text-align: right">客户名称：</td>
                <td class="tableBotcss" width="25%" style="height: 30px; text-align: left" ><asp:TextBox ID="Tbx_Name" runat="server" CssClass="Boxx" Width="100px"></asp:TextBox>  </td>
            </tr>
            <tr>
                <td class="tableBotcss" width="10%" style="height: 30px; text-align: right">采购状态：</td>
                <td class="tableBotcss1" width="50%" style="height: 30px; text-align: left" ><asp:DropDownList runat="server" ID="Drop_State"><asp:ListItem Text="-请选择-" Value=""></asp:ListItem><asp:ListItem Text="未采购" Value="1" Selected></asp:ListItem><asp:ListItem Text="已采购" Value="2"></asp:ListItem></asp:DropDownList></td>
              <td class="tableBotcss" width="10%" style="height: 30px; text-align: right">合同状态：</td>
                <td class="tableBotcss1" width="50%" style="height: 30px; text-align: left" >
              <asp:DropDownList ID="DDLContractState" runat="server" >
              <asp:ListItem Value="">请选择合同状态</asp:ListItem>
              <asp:ListItem Value="0">未执行</asp:ListItem>
              <asp:ListItem Value="1">执行中</asp:ListItem>
              <asp:ListItem Value="2">出货中</asp:ListItem>
              <asp:ListItem Value="3">已作废</asp:ListItem>
              <asp:ListItem Value="4">已完成</asp:ListItem>
              </asp:DropDownList>
                <asp:Button ID="Button4" runat="server" Text="合同单检索"  CssClass="Btt" OnClick="Button4_Click"/></td>
            </tr>
   
        </table>
        
        <cc1:MyGridView ID="GridView1" runat="server"   AllowPaging="True" AllowSorting="True"   EmptyDataText="<div align=center><font color=red><br/><br/><B>暂没有找到相关可发货的合同记录，请先确认审核合同可发货.</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px" >
        <Columns>
        
        
        <asp:TemplateField HeaderText="选择" HeaderStyle-Font-Size="12px" ItemStyle-Width="40px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <ItemTemplate>
                     <asp:CheckBox ID="Chbk" runat="server"  />
                 </ItemTemplate>
        </asp:TemplateField>
          
        <asp:TemplateField HeaderText="合同编号"  SortExpression="ContractNo" HeaderStyle-Font-Size="12px"  ItemStyle-Width="180px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <a href="#"  onclick="javascript:window.open('../SalesContract/Xs_ContractList_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ContractNo")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# DataBinder.Eval(Container.DataItem, "ContractNo").ToString()%></a>
          </ItemTemplate>
        </asp:TemplateField>
        
      <asp:TemplateField HeaderText="采购状态" HeaderStyle-Font-Size="12px"  ItemStyle-Width="55px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetOrderCode(DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField   HeaderText="签订日期"  DataField="ContractDateTime" ItemStyle-Width="75px"  SortExpression="ContractDateTime"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
         <asp:BoundField   HeaderText="交货日期"  DataField="ContractToDeliDate" ItemStyle-Width="80px"  SortExpression="ContractToDeliDate"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="客户名称"  SortExpression="CustomerValue" HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <a href="#"  onclick="javascript:window.open('../Customer/KNet_Sales_ClientList_Details.aspx?CustomerValue=<%# DataBinder.Eval(Container.DataItem, "CustomerValue")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# base.Base_GetCustomerName(DataBinder.Eval(Container.DataItem, "CustomerValue").ToString())%></a>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="执行状态"  SortExpression="ContractState" HeaderStyle-Font-Size="12px"  ItemStyle-Width="55px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetOrderStateYN(DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="采购状态" HeaderStyle-Font-Size="12px"  ItemStyle-Width="55px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetCgState(DataBinder.Eval(Container.DataItem, "isorder").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField   HeaderText="操作时间"  DataField="SystemDatetimes" SortExpression="SystemDatetimes"  HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="查看" HeaderStyle-Font-Size="12px"  ItemStyle-Width="28px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
             <a href="#"  onclick="javascript:window.open('../SalesContract/Xs_ContractList_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ContractNo")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><asp:Image ID="Image2" runat="server"  ImageUrl="../../images/View.gif" border=0  ToolTip="查看合同详细信息" /></a>
          </ItemTemplate>
        </asp:TemplateField>
 
        </Columns>
         <HeaderStyle CssClass='Custom_DgHead' />
        <RowStyle CssClass='Custom_DgItem' />
        <AlternatingRowStyle BackColor="#E3EAF2" />
        <PagerStyle CssClass='Custom_DgPage' />
        </cc1:MyGridView>
<!--GridView-->  
<!--分页-->
<!--底部功能栏-->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="30" width="58%"><asp:TextBox runat="server" ID="Tbx_ID" CssClass="Custom_Hidden"></asp:TextBox>&nbsp;<asp:Button ID="Button2" runat="server"  CssClass="Btt" Text="确定选择" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />   <input   name="button2"   type="button"   value="关闭窗口"  class="Btt"  onclick="closeWindow();"> </td>
      <td width="42%" align="right" >&nbsp;<asp:Button ID="Button1" runat="server"  CssClass="Btt" Text="更改为已采购" OnClick="Button1_Click1" /><asp:Button ID="Button3" runat="server"  CssClass="Btt" Text="更改为未采购" OnClick="Button3_Click1" /></td>
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

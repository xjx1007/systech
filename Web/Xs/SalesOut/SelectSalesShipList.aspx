<%@ Page Language="C#" AutoEventWireup="true"   CodeFile="SelectSalesShipList.aspx.cs" Inherits="Knet_Common_SelectSalesShipList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="/Web/css/knetwork.css" type="text/css">
<script>   
  function closeWindow()   
  {   
  window.opener=null;   
  window.close();   
  }  
</script> 
<script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="/Web/js/Global.js"></script>
<title>选择发货单</title>
<base target="_self" />
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="/images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">发货单选择</div></td>
    <td  background="/images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;日期从<asp:TextBox ID="StartDate" runat="server" CssClass="Wdate"  onFocus="var EndDate=$dp.$('EndDate');WdatePicker({maxDate:'#F{$dp.$D(\'EndDate\')}'})" ></asp:TextBox>&nbsp;到<asp:TextBox ID="EndDate" runat="server"  CssClass="Wdate"   onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})" ></asp:TextBox>&nbsp;关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="Boxx" Width="120px"></asp:TextBox></td>
    <td width="120" background="/images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="left"><asp:Button
        ID="Button4" runat="server" Text="发货单检索"  CssClass="Btt" OnClick="Button4_Click"/></td>
  </tr>
</table>
<div id="ssdd" style="padding:1px"></div>


<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
<!--GridView-->

        <cc1:MyGridView ID="GridView1" AllowPaging="true" runat="server"  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>暂没有找到相关可退货的发货记录单，请先确认是否已有发货.</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px">
        <Columns>
        
        <asp:TemplateField HeaderText="选择" HeaderStyle-Font-Size="12px" ItemStyle-Width="40px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <HeaderTemplate>
                    <asp:CheckBox ID="CheckBox1" onclick="selectAll(this)" runat="server"/>
                 </HeaderTemplate>
                 <ItemTemplate>
                     <asp:CheckBox ID="Chbk" runat="server"  />
                 </ItemTemplate>
        </asp:TemplateField>
        
        
         <asp:BoundField  HeaderText="发货单号"  DataField="OutWareNo"  ItemStyle-Width="115px"  SortExpression="OutWareNo" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
         <asp:BoundField   HeaderText="发货日期"  DataField="OutWareDateTime" ItemStyle-Width="80px"  SortExpression="OutWareDateTime"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>

         <asp:BoundField   HeaderText="预计到货日期"  DataField="KSO_PlanOutWareDateTime" ItemStyle-Width="80px"  SortExpression="OutWareDateTime"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
        
        <asp:TemplateField HeaderText="客户名称"  SortExpression="CustomerValue" HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <a href="#"  onclick="javascript:window.open('../Sales/KNet_Sales_ClientList_Details.aspx?CustomerValue=<%# DataBinder.Eval(Container.DataItem, "CustomerValue")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# base.Base_GetCustomerName(DataBinder.Eval(Container.DataItem, "CustomerValue").ToString())%></a>
          </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="经手人"  SortExpression="OutWareStaffNo" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "OutWareStaffNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="状态"  HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetState(DataBinder.Eval(Container.DataItem, "OutWareNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="查看"  SortExpression="CustomerValue" HeaderStyle-Font-Size="12px"  ItemStyle-Width="28px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
             <a href="#"  onclick="javascript:window.open('../Sales/Knet_Sales_Ship_Manage_PrinterListSettingPrinterPage.aspx?OutWareNo=<%# DataBinder.Eval(Container.DataItem, "OutWareNo")%>&PrinterModel=128900331899375000','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><asp:Image ID="Image2" runat="server"  ImageUrl="/images/View.gif" border=0  ToolTip="查看发货详细信息" /></a>
          </ItemTemplate>
        </asp:TemplateField>
        </Columns>
            <HeaderStyle CssClass='Custom_DgHead' />
            <RowStyle CssClass='Custom_DgItem' />
            <AlternatingRowStyle BackColor="#E3EAF2" />
            <PagerStyle CssClass='Custom_DgPage' />
        </cc1:MyGridView>

<!--分页-->

<!--底部功能栏-->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="30" width="58%">&nbsp;<asp:Button ID="Button2" runat="server"  CssClass="Btt" Text="确定选择" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />
      <input   name="button2"   type="button"   value="关闭窗口"  class="Btt"  onclick="closeWindow();"></td>
      <td width="42%" align="right" >&nbsp;</td>
      <td> <asp:DropDownList ID="Ddl_isShip" runat="server" OnTextChanged="Ddl_isShip_TextChanged" AutoPostBack="true"><asp:ListItem Text="请选择" Value=""></asp:ListItem>
      <asp:ListItem Value="0" Text="未发货" ></asp:ListItem>
      <asp:ListItem Value="1" Text="部分发货"></asp:ListItem>
      <asp:ListItem Value="2" Text="已发货" Selected></asp:ListItem>
      </asp:DropDownList></td>
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

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="Admin_hame" Title="" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<script type="text/javascript">
     //if(window != window.parent) 
     //{ var P = window.parent, D = P.loadinndlg(); }
</script>

<title></title>
<style type="text/css">
.Div11
{
  background-image:url(../images/btna.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
.Div22
{
  background-image:url(../images/btna2.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
</style>

</head>
<script type="text/javascript" src="../Web/KDialog/lhgdialog.js"></script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td height="5"></td>
  </tr>
</table>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td background="../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">欢迎登陆系统</div></td>
    <td background="../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;</td>
    <td width="173" background="../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;"></td>
  </tr>
</table>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0">
<tr>
    <td height="1"></td>
</tr>
<tr>
    <td height="24" bgcolor="#E6F0F9" style="border-bottom:#3399CC 1px solid;"> 欢迎 <font color="#FF6600"><b><asp:Label ID="StaffName" runat="server" Text="Label"></asp:Label></b></font> 登陆系统，您目前拥有管理的仓库列表:<font color="#FF6600"><b><asp:Label ID="Warehouse_Name" runat="server" Text=""></asp:Label></b></font></td>
</tr>
<tr>
    <td height="3"></td>
</tr>
</table>


<table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" >
  <tr>
    <td height="22" colspan="2" align="left" bgcolor="#E6F0F9"><table  height="22" border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td width="101" align="center"><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"  CssClass="Div11" Width="101px" Height="22px"  CausesValidation="false" Font-Size="14px">系统公告</asp:LinkButton></td>
        <td width="4" align="center">&nbsp;</td>
        <td width="101" align="center"><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"  CssClass="Div11" Width="101px" Height="22px" CausesValidation="false" Font-Size="14px">最新动态</asp:LinkButton></td>
        <td width="4" align="center">&nbsp;</td>
        <td width="101" align="center"><asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click"  CssClass="Div11" Width="101px" Height="22px"  CausesValidation="false" Font-Size="14px">修改密码</asp:LinkButton></td>
        <td width="4" align="center">&nbsp;</td>
        <td width="101" align="center"><asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click"  CssClass="Div11" Width="101px" Height="22px"  CausesValidation="false" Font-Size="14px">习惯设置</asp:LinkButton></td>
        <td align="center">&nbsp;&nbsp;</td>
      </tr>
    </table></td>
  </tr>
  <tr>  
    <td  align="left" valign="top"  style="border-bottom:#3399CC 1px solid;border-right:#3399CC 1px solid;border-left:#3399CC 1px solid;border-top:#3399CC 1px solid;">
<%--工作区A2A --%>
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" id="A2A" runat="server">
  <tr id="NoticeYNs" runat="server">
    <td height="20" align="left">
    
    <table width="100%"  border="0" cellpadding="0" cellspacing="0" style="border-bottom:#3399CC 0px solid;">
      <tr>
        <td width="4%" align="center" height="25" style="border-bottom:#0099CC 1px solid"><img src="../images/109.gif" width="22" height="22"/></td>
        <td  width="96%"  align="left" style="font-size:14px; color:#000099;border-bottom:#0099CC 1px solid">&nbsp;<strong>系统公告</strong></td>
      </tr>
    </table>
    
    
    </td>
  </tr>
  <tr>
    <td height="20" valign="top">

        <asp:Label ID="NoticeContenttxt"  runat="server" Text=""></asp:Label>
    </td>
  </tr>
</table>
<%--工作区A2A --%>

<%--工作区B2B --%>
<table width="100%" border="0" align="center" cellpadding="1" cellspacing="1" id="B2B" runat="server">
  <tr>
    <td height="20" align="left">
    
                    <table>
                        <tr>
                            <td width="20">
                                <img src="../Images/icon_2.gif" width="16" height="16"></td>
                            <td width="450">
                                <div>
                                    待办事宜</div>
                            </td>
                        </tr>
                    </table>
                    <hr>
    <table width="100%"  border="0" cellpadding="0" cellspacing="0" style="border-bottom:#3399CC 0px solid;">

    <tr>
    <td>
   <asp:LinkButton runat ="server" ID="Ltn_Contract" Text="未完成审核的合同评审信息"  Font-Size="13px" OnClick="Ltn_Contract_Click"></asp:LinkButton>
    <asp:Panel ID="Pan_Contract" runat="server" Visible="false">
    <cc1:MyGridView id="GridView2" runat="server" CssClass="Custom_DgMain" Width="100%"  PageSize="8" AutoGenerateColumns="False" IsShowEmptyTemplate="true" AllowSorting="True" AllowPaging="True">
        <Columns>
        
        <asp:TemplateField HeaderText="合同编号"  SortExpression="ContractNo" HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <a href="#"  onclick="javascript:window.open('../Web/Sales/Xs_ContractList_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ContractNo")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# DataBinder.Eval(Container.DataItem, "ContractNo").ToString()%></a>
          </ItemTemplate>
        </asp:TemplateField>
        
         <asp:BoundField   HeaderText="签订日期"  DataField="ContractDateTime" ItemStyle-Width="80px"  SortExpression="ContractDateTime"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  ></ItemStyle>
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" ></HeaderStyle>
        </asp:BoundField>
         <asp:BoundField   HeaderText="交货日期"  DataField="ContractToDeliDate" ItemStyle-Width="80px"  SortExpression="ContractToDeliDate"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  ></ItemStyle>
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" ></HeaderStyle>
        </asp:BoundField>

        
        <asp:TemplateField HeaderText="客户名称"  SortExpression="CustomerValue" HeaderStyle-Font-Size="12px"  ItemStyle-Width="180px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <a href="#"  onclick="javascript:window.open('../Web/Sales/'KNet_Sales_ClientList_Details.aspx?CustomerValue=<%# DataBinder.Eval(Container.DataItem, "CustomerValue")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# base.Base_GetCustomerName(DataBinder.Eval(Container.DataItem, "CustomerValue").ToString())%></a>
          </ItemTemplate>
        </asp:TemplateField>
        
      <asp:TemplateField HeaderText="责任人"  SortExpression="ContractStaffNo" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "DutyPerson").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="合同分类"  SortExpression="ContractClass" HeaderStyle-Font-Size="12px"  ItemStyle-Width="110px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetKClaaName(DataBinder.Eval(Container.DataItem, "ContractClass").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
      <asp:TemplateField HeaderText="经手人"  SortExpression="ContractStaffNo" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "ContractStaffNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField   HeaderText="操作日期"  DataField="SystemDateTimes" SortExpression="SystemDateTimes"  HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  ></ItemStyle>
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" ></HeaderStyle>
        </asp:BoundField>
        
        <asp:TemplateField HeaderText="查看" HeaderStyle-Font-Size="12px"  ItemStyle-Width="28px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
             <a href="#"  onclick="javascript:window.open('../Web/Sales/KNet_Sales_ContractList_Manage_PrinterListSettingPrinterPage.aspx?ContractNo=<%# DataBinder.Eval(Container.DataItem, "ContractNo")%>&PrinterModel=128898695453437500','查看详细','top=120,left=150,menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');"><asp:Image ID="Image2" runat="server"  ImageUrl="../images/View.gif"  ToolTip="查看合同详细信息" /></a>
          </ItemTemplate>
        </asp:TemplateField>
        
      <asp:TemplateField HeaderText="审核"  HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# GetBaoPriceCheckYN(DataBinder.Eval(Container.DataItem, "ContractNo"))%>
          </ItemTemplate>
        </asp:TemplateField>
 
        </Columns>
         <HeaderStyle CssClass='Custom_DgHead'  />
        <RowStyle CssClass='Custom_DgItem'  />
        <AlternatingRowStyle BackColor="#E3EAF2"  />
        <PagerStyle CssClass='Custom_DgPage'  />
        </cc1:MyGridView>
        </asp:Panel>
    </td>
    <td >
   <asp:LinkButton runat ="server" ID="Lbl_Cotracted" Text="已审核未查看合同评审"  Font-Size="13px" OnClick="Lbl_Cotracted_Click"></asp:LinkButton>
    <asp:Panel ID="Pan_Cotracted" runat="server" Visible="false">
    <cc1:MyGridView id="GridView_Cotracted" runat="server" CssClass="Custom_DgMain" Width="100%"  PageSize="8" AutoGenerateColumns="False" IsShowEmptyTemplate="true" AllowSorting="True" AllowPaging="True">
        <Columns>
        
        <asp:TemplateField HeaderText="合同编号"  SortExpression="ContractNo" HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <a href="#"  onclick="javascript:window.open('../Web/Sales/Xs_ContractList_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ContractNo")%>&Type=1','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# DataBinder.Eval(Container.DataItem, "ContractNo").ToString()%></a>
          </ItemTemplate>
        </asp:TemplateField>
        
         <asp:BoundField   HeaderText="签订日期"  DataField="ContractDateTime" ItemStyle-Width="80px"  SortExpression="ContractDateTime"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  ></ItemStyle>
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" ></HeaderStyle>
        </asp:BoundField>
         <asp:BoundField   HeaderText="交货日期"  DataField="ContractToDeliDate" ItemStyle-Width="80px"  SortExpression="ContractToDeliDate"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  ></ItemStyle>
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" ></HeaderStyle>
        </asp:BoundField>

        
        <asp:TemplateField HeaderText="客户名称"  SortExpression="CustomerValue" HeaderStyle-Font-Size="12px"  ItemStyle-Width="180px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <a href="#"  onclick="javascript:window.open('../Web/Sales/'KNet_Sales_ClientList_Details.aspx?CustomerValue=<%# DataBinder.Eval(Container.DataItem, "CustomerValue")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# base.Base_GetCustomerName(DataBinder.Eval(Container.DataItem, "CustomerValue").ToString())%></a>
          </ItemTemplate>
        </asp:TemplateField>
        
      <asp:TemplateField HeaderText="责任人"  SortExpression="ContractStaffNo" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "DutyPerson").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="合同分类"  SortExpression="ContractClass" HeaderStyle-Font-Size="12px"  ItemStyle-Width="110px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetKClaaName(DataBinder.Eval(Container.DataItem, "ContractClass").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
      <asp:TemplateField HeaderText="经手人"  SortExpression="ContractStaffNo" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "ContractStaffNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField   HeaderText="操作日期"  DataField="SystemDateTimes" SortExpression="SystemDateTimes"  HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  ></ItemStyle>
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" ></HeaderStyle>
        </asp:BoundField>
        
        <asp:TemplateField HeaderText="查看" HeaderStyle-Font-Size="12px"  ItemStyle-Width="28px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
             <a href="#"  onclick="javascript:window.open('../Web/Sales/Xs_ContractList_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ContractNo")%>&Type=1','查看详细','top=120,left=150,menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');"><asp:Image ID="Image3" runat="server"  ImageUrl="../images/View.gif"  ToolTip="查看合同详细信息" /></a>
          </ItemTemplate>
        </asp:TemplateField>
        
        </Columns>
         <HeaderStyle CssClass='Custom_DgHead'  />
        <RowStyle CssClass='Custom_DgItem'  />
        <AlternatingRowStyle BackColor="#E3EAF2"  />
        <PagerStyle CssClass='Custom_DgPage'  />
        </cc1:MyGridView>
        </asp:Panel>
    </td>
  </tr>
  <tr>
    <td >
       <asp:LinkButton runat ="server" ID="Ltn_Ship" Text="未完成出库的发货通知单"  Font-Size="13px" OnClick="Ltn_Ship_Click"></asp:LinkButton>
  
    <asp:Panel runat="server" ID="Pan_Ship" Visible="false">
        <cc1:MyGridView ID="GridView_Ship" runat="server"  AllowSorting="True"  IsShowEmptyTemplate="true"  AllowPaging="True" 
        EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px"
           >
        <Columns>
        
        
        <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <HeaderTemplate>
                    <input type="CheckBox" onclick="selectAll(this)"/>
                 </HeaderTemplate>
                 <ItemTemplate>
                     <asp:CheckBox ID="Chbk" runat="server"  />
                 </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="发货单号"  SortExpression="OutWareNo" HeaderStyle-Font-Size="12px"  ItemStyle-Width="28px"   ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
             <a href="#"  onclick="javascript:window.open('../Web/Sales/Knet_Sales_Ship_Manage_PrinterListSettingPrinterPage.aspx?OutWareNo=<%# DataBinder.Eval(Container.DataItem, "OutWareNo")%>&PrinterModel=128900331899375000','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# DataBinder.Eval(Container.DataItem, "OutWareNo").ToString()%></a>
          </ItemTemplate>
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="合同编号"  SortExpression="ContractNo" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <a href="#"  onclick="javascript:window.open('../Web/Sales/Xs_ContractList_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ContractNo")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# DataBinder.Eval(Container.DataItem, "ContractNo").ToString()%></a>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField   HeaderText="发货日期"  DataField="OutWareDateTime" ItemStyle-Width="80px"  SortExpression="OutWareDateTime"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
         <asp:BoundField   HeaderText="预计发货日期"  DataField="KSO_PlanOutWareDateTime" ItemStyle-Width="80px"  SortExpression="KSO_PlanOutWareDateTime"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
        
        <asp:TemplateField HeaderText="客户名称"  SortExpression="CustomerValue" HeaderStyle-Font-Size="12px"  ItemStyle-Width="180px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <a href="#"  onclick="javascript:window.open('../Web/Sales/KNet_Sales_ClientList_Details.aspx?CustomerValue=<%# DataBinder.Eval(Container.DataItem, "CustomerValue")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# base.Base_GetCustomerName(DataBinder.Eval(Container.DataItem, "CustomerValue").ToString())%></a>
          </ItemTemplate>
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="发货跟踪情况"  HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
           <%# GetOutWareListfollowup(DataBinder.Eval(Container.DataItem, "OutWareNo"))%>
          </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="查看"  HeaderStyle-Font-Size="12px"  ItemStyle-Width="28px"   ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
             <a href="#"  onclick="javascript:window.open('../Web/Sales/Knet_Sales_Ship_Manage_PrinterListSettingPrinterPage.aspx?OutWareNo=<%# DataBinder.Eval(Container.DataItem, "OutWareNo")%>&PrinterModel=128900331899375001','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><asp:Image ID="Image13" runat="server"  ImageUrl="../images/View.gif"  ToolTip="查看发货详细信息" /></a>
          </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="审核意见" HeaderStyle-Font-Size="12px"   ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
             <a href="#"  onclick="javascript:window.open('../Web/Sales/pop/Knet_Sales_ShipCheckDetail.aspx?OutWareNo=<%# DataBinder.Eval(Container.DataItem, "OutWareNo")%>','查看审核意见','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><asp:Image ID="Image4" runat="server"  ImageUrl="../images/View.gif"  ToolTip="查看发货详细信息" /></a>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="审核"  SortExpression="OutWareCheckYN" HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# GetShipCheckYN(DataBinder.Eval(Container.DataItem, "OutWareNo"))%>
          </ItemTemplate>
        </asp:TemplateField>
        </Columns>
            <HeaderStyle CssClass='Custom_DgHead' />
            <RowStyle CssClass='Custom_DgItem' />
            <AlternatingRowStyle BackColor="#E3EAF2" />
            <PagerStyle CssClass='Custom_DgPage' />
        </cc1:MyGridView>
  </asp:Panel>

    </td>
  <td >
   <asp:LinkButton runat ="server" ID="Ltn_Order" Text="未完成审核的采购订单"  Font-Size="13px" OnClick="Ltn_Order_Click"></asp:LinkButton>
  <asp:Panel runat="server" ID="Pan_Order" Visible="false">
        <cc1:MyGridView ID="GridView_Order" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%"  PageSize="10"  BorderColor="#4974C2"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关客户记录</B><br/><br/></font></div>" >
        <Columns>
       
          
         <asp:BoundField  HeaderText="采购单号"  DataField="OrderNo"    SortExpression="OrderNo" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
         <asp:BoundField  HeaderText="合同编号"  DataField="ContractNo"    SortExpression="ContractNo" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        
         <asp:BoundField   HeaderText="采购日期"  DataField="OrderDateTime"   SortExpression="OrderDateTime"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
        
        
         <asp:BoundField   HeaderText="预计到货日期"  DataField="OrderPreToDate"   SortExpression="OrderPreToDate"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
        
        <asp:TemplateField HeaderText="采购类型"  SortExpression="OrderType" HeaderStyle-Font-Size="12px"     ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.base_GetProcureTypeNane(DataBinder.Eval(Container.DataItem, "OrderType").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="供应商"  SortExpression="SuppNo" HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetSupplierName(DataBinder.Eval(Container.DataItem, "SuppNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="公司"  SortExpression="OrderStaffBranch" HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GeDept(DataBinder.Eval(Container.DataItem, "OrderStaffBranch").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
      <asp:TemplateField HeaderText="经手人"  SortExpression="OrderStaffNo" HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "OrderStaffNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField   HeaderText="操作时间"  DataField="SystemDateTimes"   SortExpression="SystemDateTimes"  HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
        
      <asp:TemplateField HeaderText="状态"  SortExpression="OrderState" HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# GetOrderStateYN(DataBinder.Eval(Container.DataItem, "OrderNo"))%>
          </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="查看"  SortExpression="CustomerValue" HeaderStyle-Font-Size="12px"  ItemStyle-Width="28px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
             <a href="#"  onclick="javascript:window.open('../Web/Order/Knet_Procure_OpenBilling_Print.aspx?OrderNo=<%# DataBinder.Eval(Container.DataItem, "OrderNo")%>&PrinterModel=128917825766562500','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><asp:Image ID="Image6" runat="server"  ImageUrl="../images/View.gif"  ToolTip="查看合同详细信息" /></a>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="审核"  SortExpression="OrderCheckYN" HeaderStyle-Font-Size="12px"     ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# GetOrderCheckYN(DataBinder.Eval(Container.DataItem, "OrderNo"))%>
          </ItemTemplate>
        </asp:TemplateField>
        
        </Columns>
            <HeaderStyle CssClass='Custom_DgHead' />
            <RowStyle CssClass='Custom_DgItem' />
            <AlternatingRowStyle BackColor="#E3EAF2" />
            <PagerStyle CssClass='Custom_DgPage' />
        </cc1:MyGridView>
  </asp:Panel>
  </td>
  </tr>
  
  <tr>
  
  <td >
   <asp:LinkButton runat ="server" ID="Ltn_SalesReturn" Text="退货审批"  Font-Size="13px" OnClick="Ltn_SalesReturn_Click"></asp:LinkButton>
  <asp:Panel runat="server" ID="Pan_SalesReturn" Visible="false">
         
<!--GridView-->
        <cc1:MyGridView ID="GridView_SalesReturn" runat="server" AllowPaging="true"  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px">
        <Columns>
        
         <asp:BoundField  HeaderText="退货单号"  DataField="ReturnNo"  ItemStyle-Width="115px"  SortExpression="ReturnNo" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
         <asp:BoundField   HeaderText="退货日期"  DataField="ReturnDateTime" ItemStyle-Width="80px"  SortExpression="ReturnDateTime"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>

        
        <asp:TemplateField HeaderText="客户名称"  SortExpression="CustomerValue" HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <a href="#"  onclick="javascript:window.open('../Web/Sales/KNet_Sales_ClientList_Details.aspx?CustomerValue=<%# DataBinder.Eval(Container.DataItem, "CustomerValue")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# base.Base_GetCustomerName(DataBinder.Eval(Container.DataItem, "CustomerValue").ToString())%></a>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="退货分类"   HeaderStyle-Font-Size="12px"  SortExpression="ReturnClass"     ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetKClaaName(DataBinder.Eval(Container.DataItem, "ReturnClass").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="经手人"  SortExpression="ReturnStaffNo" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "ReturnStaffNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="退货型号"   HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetReturnProductsPatten(DataBinder.Eval(Container.DataItem, "ReturnNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="总数量"   HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetReturnNumbers(DataBinder.Eval(Container.DataItem, "ReturnNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="查看" HeaderStyle-Font-Size="12px"  ItemStyle-Width="28px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
             <a href="#"  onclick="javascript:window.open('../Web/Sales/KNet_Sales_Retrun_Manage_PrinterListSettingPrinterPage.aspx?ReturnNo=<%# DataBinder.Eval(Container.DataItem, "ReturnNo")%>&PrinterModel=128902069841406250','查看详细','top=120,left=150,menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');"><asp:Image ID="Image5" runat="server"  ImageUrl="../images/View.gif"  ToolTip="查看合同详细信息" /></a>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="审核"  SortExpression="ReturnCheckYN" HeaderStyle-Font-Size="12px"     ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# GetSalesReturnCheckYN(DataBinder.Eval(Container.DataItem, "ReturnNo"))%>
          </ItemTemplate>
        </asp:TemplateField>
 
        </Columns>
         
         <HeaderStyle CssClass='Custom_DgHead' />
        <RowStyle CssClass='Custom_DgItem' />
        <AlternatingRowStyle BackColor="#E3EAF2" />
        <PagerStyle CssClass='Custom_DgPage' />
             </cc1:MyGridView>

  </asp:Panel>
  </td>
    <td >
       <asp:LinkButton runat ="server" ID="Ltn_Return" Text="退货入库审批"  Font-Size="13px" OnClick="Ltn_Return_Click"></asp:LinkButton>
  
    <asp:Panel runat="server" ID="Pan_Return" Visible="false">
    
        <cc1:MyGridView ID="GridView_Return" runat="server"  AllowSorting="True" AllowPaging="True"     EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录，或没有受权使用相关仓库</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px" >
        <Columns>
        
        
        <asp:TemplateField HeaderText="入库单号" HeaderStyle-HorizontalAlign="center" HeaderStyle-Width="30px">
            <ItemTemplate>
            <a  href="#" onclick="javascript:window.open('../Web/WareHouse/WareHouse_DirectInto_Details.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "DirectInNo")%>&Css2=Div22','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"> <%# DataBinder.Eval(Container.DataItem, "DirectInNo")%></a>
           </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="退货单号" HeaderStyle-HorizontalAlign="center" HeaderStyle-Width="30px">
            <ItemTemplate>
            <a href="#"  onclick="javascript:window.open('../Web/Sales/KNet_Sales_Retrun_Manage_PrinterListSettingPrinterPage.aspx?ReturnNo=<%# DataBinder.Eval(Container.DataItem, "KWD_ReturnNo")%>&PrinterModel=128902069841406250','查看详细','top=120,left=150,menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');"><%# DataBinder.Eval(Container.DataItem, "KWD_ReturnNo")%></a>
               </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField   HeaderText="开单日期"  DataField="DirectInDateTime" ItemStyle-Width="70px"  SortExpression="DirectInDateTime"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
        
        
        <asp:TemplateField HeaderText="入库仓库"  SortExpression="HouseNo" HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetHouseName(DataBinder.Eval(Container.DataItem, "HouseNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="供应商"  SortExpression="SuppNo" HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetSupplierName(DataBinder.Eval(Container.DataItem, "SuppNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
         <asp:BoundField   HeaderText="操作日期"  DataField="SystemDatetimes" SortExpression="SystemDatetimes"   HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
        
      <asp:TemplateField HeaderText="经手人"  SortExpression="DirectInStaffNo" HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "DirectInStaffNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="审核"  SortExpression="DirectInCheckYN" HeaderStyle-Font-Size="12px"  ItemStyle-Width="30px"   ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# GetReturnCheckYN(DataBinder.Eval(Container.DataItem, "DirectInNo"))%>
          </ItemTemplate>
        </asp:TemplateField>
        </Columns>
            <HeaderStyle CssClass='Custom_DgHead' />
            <RowStyle CssClass='Custom_DgItem' />
            <AlternatingRowStyle BackColor="#E3EAF2" />
            <PagerStyle CssClass='Custom_DgPage' />
        </cc1:MyGridView>
  </asp:Panel>

    </td>
  </tr>
  
  <tr>
  
  <td >
   <asp:LinkButton runat ="server" ID="Ltn_RkNotShip" Text="已入库未发货信息"  Font-Size="13px" OnClick="Ltn_RkNotShip_Click"></asp:LinkButton>
  <asp:Panel runat="server" ID="Pan_RkNotShip" Visible="false">
         
<!--GridView-->
    <cc1:MyGridView id="GridView_RkNotShip" runat="server" CssClass="Custom_DgMain" Width="100%"  PageSize="8" AutoGenerateColumns="False" IsShowEmptyTemplate="true" AllowSorting="True" AllowPaging="True">
        <Columns>
        
        <asp:TemplateField HeaderText="合同编号"  SortExpression="ContractNo" HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <a href="#"  onclick="javascript:window.open('../Web/Sales/Xs_ContractList_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ContractNo")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# DataBinder.Eval(Container.DataItem, "ContractNo").ToString()%></a>
          </ItemTemplate>
        </asp:TemplateField>
        
         <asp:BoundField   HeaderText="签订日期"  DataField="ContractDateTime" ItemStyle-Width="80px"  SortExpression="ContractDateTime"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  ></ItemStyle>
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" ></HeaderStyle>
        </asp:BoundField>
         <asp:BoundField   HeaderText="交货日期"  DataField="ContractToDeliDate" ItemStyle-Width="80px"  SortExpression="ContractToDeliDate"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  ></ItemStyle>
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" ></HeaderStyle>
        </asp:BoundField>

        
        <asp:TemplateField HeaderText="客户名称"  SortExpression="CustomerValue" HeaderStyle-Font-Size="12px"  ItemStyle-Width="180px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <a href="#"  onclick="javascript:window.open('../Web/Sales/'KNet_Sales_ClientList_Details.aspx?CustomerValue=<%# DataBinder.Eval(Container.DataItem, "CustomerValue")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# base.Base_GetCustomerName(DataBinder.Eval(Container.DataItem, "CustomerValue").ToString())%></a>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="责任人"  SortExpression="ContractStaffNo" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "DutyPerson").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="合同分类"  SortExpression="ContractClass" HeaderStyle-Font-Size="12px"  ItemStyle-Width="110px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetKClaaName(DataBinder.Eval(Container.DataItem, "ContractClass").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="版本号"  SortExpression="ContractStaffNo" HeaderStyle-Font-Size="12px"     ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetContractProductsEdition(DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField   HeaderText="合同数量"  DataField="ContractAmount" SortExpression="ContractAmount"  HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  ></ItemStyle>
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" ></HeaderStyle>
        </asp:BoundField>
         <asp:BoundField   HeaderText="入库数量"  DataField="WareHouseAmount" SortExpression="WareHouseAmount"  HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  ></ItemStyle>
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" ></HeaderStyle>
        </asp:BoundField>
         <asp:BoundField   HeaderText="入库时间"  DataField="WareHouseDateTime" SortExpression="WareHouseDateTime" DataFormatString="{0:yyyy-MM-dd}"   HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  ></ItemStyle>
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" ></HeaderStyle>
        </asp:BoundField>
         <asp:BoundField   HeaderText="入库说明"  DataField="WareHouseDateTime" SortExpression="WareHouseDateTime" DataFormatString="{0:yyyy-MM-dd}"   HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  ></ItemStyle>
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" ></HeaderStyle>
        </asp:BoundField>
        
        <asp:TemplateField HeaderText="发货" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
             <a href="#"  onclick="javascript:window.open('../Web/Sales/Knet_Sales_Ship_Manage_Add.aspx?ContractNo=<%# DataBinder.Eval(Container.DataItem, "ContractNo")%>&WareHouseNo=<%# DataBinder.Eval(Container.DataItem, "WareHouseNo")%>','查看详细','top=120,left=150,menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');">发货通知</a>
          </ItemTemplate>
        </asp:TemplateField>
 
        </Columns>
         <HeaderStyle CssClass='Custom_DgHead'  />
        <RowStyle CssClass='Custom_DgItem'  />
        <AlternatingRowStyle BackColor="#E3EAF2"  />
        <PagerStyle CssClass='Custom_DgPage'  />
        </cc1:MyGridView>

  </asp:Panel>
  </td>
  </tr>
    </table>
<!--系统公告--->   </td>
  </tr>
  <tr><td>
  
                    <table>
                        <tr>
                            <td width="20">
                                <img src="../Images/icon_5.gif" width="16" height="16"></td>
                            <td width="450">
                                <div>
                                    其他数据</div>
                            </td>
                        </tr>
                    </table>
<!--系统公告--><hr>
                                    <asp:Label ID="Lbl_ShTime" runat="server"></asp:Label>
                    
  </td></tr>
</table>
<%--工作区B2B --%>

<%--工作区C2C --%>
<table width="100%" border="0" align="center" cellpadding="1" cellspacing="1" id="C2C" runat="server">
  <tr>
    <td height="20" align="left">
    <table width="100%"  border="0" cellpadding="0" cellspacing="0" >
              <tr>
        <td width="4%" align="center" height="25" style="border-bottom:#0099CC 1px solid"><img src="../images/109.gif" width="22" height="22"></td>
        <td  width="96%"  align="left" style="font-size:14px; color:#000099;border-bottom:#0099CC 1px solid">&nbsp;<strong>修改密码</strong></td>
      </tr>
    <tr>
    <td height="30" valign="top" colspan="4">
    
<!--修改密码-->
<table width="98%" id="PanlC"  runat="server" border="0" align="center" cellpadding="3" cellspacing="3">
  <tr>
    <td height="29" align="right">重置新密码:</td>
    <td height="29" align="left"><asp:TextBox ID="NewWsp1" runat="server" TextMode="Password"  Width="200px" CssClass="Boxx"></asp:TextBox>
        <asp:RequiredFieldValidator  ID="Req2" runat="server" ErrorMessage="请输入新密码！" ControlToValidate="NewWsp1" ></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td height="29" align="right">确认新密码: </td>
    <td height="29" align="left"><asp:TextBox ID="NewWsp2" runat="server" TextMode="Password"  Width="200px" CssClass="Boxx"></asp:TextBox>
     <asp:CompareValidator ID="Com1" runat="server" ErrorMessage="两次输入密码不一样!" ControlToValidate="NewWsp2" ControlToCompare="NewWsp1"></asp:CompareValidator></td>
      
  </tr>
  <tr>
    <td height="30" align="right">&nbsp;</td>
    <td height="30" align="left">&nbsp;<asp:Button ID="Button4" runat="server" Text="确定修改" CssClass="Btt" OnClick="Button4_Click" /></td>
  </tr>
</table>
<!--修改密码--->    
    
    
    </td>
  </tr>
    </table></td>
  </tr>
</table>
<%--工作区C2C --%>

<%--工作区D2D --%>
<table width="100%" border="0" align="center" cellpadding="1" cellspacing="1" id="D2D" runat="server">
  <tr>
    <td height="20" align="left">
<!--内容-->
<table width="100%" border="0">
      <tr>
        <td width="15%" height="29" align="right">系统默认习惯语言:</td>
        <td width="85%" align="left"><asp:RadioButtonList ID="StaffLanguage" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0"  Width="250px" >
        <asp:ListItem Value="1" Selected="True">简体中文版</asp:ListItem>
        <asp:ListItem Value="2">繁体中文版</asp:ListItem>
        </asp:RadioButtonList></td>
      </tr>
      <tr>
        <td align="right">默认打开莱单栏:</td>
        <td align="left"><asp:DropDownList ID="StaffCatalogue" runat="server" Width="100px">
        <asp:ListItem Value="1">常用工具</asp:ListItem>
        <asp:ListItem Value="2">采购入库</asp:ListItem>
        <asp:ListItem Value="3">库存管理</asp:ListItem>
        <asp:ListItem Value="4">销售管理</asp:ListItem>
        <asp:ListItem Value="5">财务管理</asp:ListItem>
        <asp:ListItem Value="6">统计分析</asp:ListItem>
        <asp:ListItem Value="7">人力资源</asp:ListItem>
        <asp:ListItem Value="8">系统管理</asp:ListItem>
        </asp:DropDownList></td>
      </tr>
      <tr>
        <td align="right">&nbsp;</td>
        <td align="left">&nbsp;</td>
      </tr>
      <tr>
        <td align="right">&nbsp;</td>
        <td align="left">&nbsp;<asp:Button ID="Button1" runat="server" Text="确定设置个人习惯"  CssClass="Btt" OnClick="Button1_Click"/></td>
      </tr>
    </table>
<!--内容--->   </td>
  </tr>
</table>
<%--工作区D2D --%>



    </td>
  </tr>
</table>

</div>
</form>
</body>
</html>

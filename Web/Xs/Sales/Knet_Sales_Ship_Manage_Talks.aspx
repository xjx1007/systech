<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"  CodeFile="Knet_Sales_Ship_Manage_Talks.aspx.cs" Inherits="Knet_Web_Sales_Knet_Sales_Ship_Manage_Talks" %>

<%@ Register Src="inc/ShipListSetting.ascx" TagName="ProcureBillingSetting"  TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../../css/knetwork.css" type="text/css" />
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
<title></title>
</head>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<script type="text/javascript" src="../KDialog/lhgdialog.js"></script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
<div id="ssdd" style="padding:1px"></div>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">销售发货管理</div></td>
    <td width="550" background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;日期从<asp:TextBox ID="StartDate" runat="server" CssClass="Wdate"  onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})" ></asp:TextBox>&nbsp;到<asp:TextBox ID="EndDate" runat="server"  CssClass="Wdate"   onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})" ></asp:TextBox>&nbsp;关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="Boxx" Width="120px"></asp:TextBox></td>
    <td  background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="left"><asp:Button   ID="Button4" runat="server" Text="发货单检索"  CssClass="Btt" OnClick="Button4_Click"/></td>
  </tr>
</table>

<div id="Div1" style="padding:1px"></div>

<%--莱单列表--%>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td><uc1:ProcureBillingSetting id="ProcureBillingSetting1" runat="server"></uc1:ProcureBillingSetting></td>
  </tr>
</table>




<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
<!--GridView-->
        <asp:GridView ID="GridView1" RowStyle-Height="36px"  runat="server"  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px"
          OnSorting="GridView1_Sorting"  OnRowDataBound="GridView1_DataRowBinding" >
        <Columns>
        

        <asp:BoundField   HeaderText="序"  ItemStyle-Height="25px" ItemStyle-Width="25px"  HeaderStyle-Font-Size="12px"  HeaderStyle-HorizontalAlign="Left"  >
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        
        
        <asp:TemplateField  HeaderImageUrl="../../images/icon_list_over.gif"  ItemStyle-Width="20px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <ItemTemplate>
                   <a href="Knet_Sales_Ship_Manage_AddDetails.aspx?OutWareNo=<%# DataBinder.Eval(Container.DataItem, "OutWareNo") %>"><asp:Image ID="Image1" runat="server"  ImageUrl="../../images/Deitail.gif"  ToolTip="查看发货详细信息" /></a>
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

        <asp:TemplateField HeaderText="合同编号"  SortExpression="ContractNo" HeaderStyle-Font-Size="12px"  ItemStyle-Width="180px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <a href="#"  onclick="javascript:window.open('Xs_ContractList_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ContractNo")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# DataBinder.Eval(Container.DataItem, "ContractNo").ToString()%></a>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField   HeaderText="发货日期"  DataField="OutWareDateTime" ItemStyle-Width="80px"  SortExpression="OutWareDateTime"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
         <asp:BoundField   HeaderText="预计发货日期"  DataField="KSO_PlanOutWareDateTime" ItemStyle-Width="80px"  SortExpression="KSO_PlanOutWareDateTime"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="客户名称"  SortExpression="CustomerValue" HeaderStyle-Font-Size="12px"  ItemStyle-Width="180px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <a href="#"  onclick="javascript:window.open('KNet_Sales_ClientList_Details.aspx?CustomerValue=<%# DataBinder.Eval(Container.DataItem, "CustomerValue")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# base.Base_GetCustomerName(DataBinder.Eval(Container.DataItem, "CustomerValue").ToString())%></a>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="所属分部"  SortExpression="OutWareStaffBranch" HeaderStyle-Font-Size="12px"  ItemStyle-Width="110px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GeDept(DataBinder.Eval(Container.DataItem, "OutWareStaffBranch").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="发货跟踪情况"  HeaderStyle-Font-Size="12px"  ItemStyle-Width="300px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
            <%# GetOutWareListfollowup(DataBinder.Eval(Container.DataItem, "OutWareNo"))%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="审核"  SortExpression="OutWareCheckYN" HeaderStyle-Font-Size="12px"  ItemStyle-Width="30px"   ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# GetBaoPriceCheckYN(DataBinder.Eval(Container.DataItem, "OutWareNo"))%>
          </ItemTemplate>
        </asp:TemplateField>
        </Columns>
         
            <FooterStyle BackColor="LightSteelBlue" />
            <HeaderStyle BackColor="LightSteelBlue" />
            <AlternatingRowStyle BackColor="WhiteSmoke" />
             <PagerStyle HorizontalAlign="Left" />
        </asp:GridView>
<!--GridView-->  
<!--分页-->
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="28" bgcolor="#F2F4F9">
    <webdiyer:aspnetpager id="AspNetPager1" runat="server" horizontalalign="left" onpagechanged="AspNetPager1_PageChanged"
    showcustominfosection="Left" width="100%" meta:resourceKey="AspNetPager1" style="font-size:14px" PageIndexBoxStyle="width:18px;border-top:1px solid #A3B2CC;border-left:1px solid #A3B2CC;border-right:1px solid #A3B2CC;border-bottom:1px solid #A3B2CC;height:17px;"
    CustomInfoHTML="　当前页<font color='red'><b>%CurrentPageIndex%</b></font>共%PageCount%页，记录%StartRecordIndex%-%EndRecordIndex%" 
    ShowNavigationToolTip="True" CustomInfoStyle="font-size:14px;padding-top:6px;width:300px;" TextAfterPageIndexBox=" " SubmitButtonText="  转" SubmitButtonStyle="width:41px;height:21px;border: none;cursor:hand;background-image: url(../../images/go.gif)"  CustomInfoTextAlign="left"  ShowPageIndexBox="Always" AlwaysShow="True" 
    FirstPageText="【首页】" LastPageText="【尾页】" NextPageText="【下页】" PageSize="10" PrevPageText="【前页】">
    </webdiyer:aspnetpager>
    </td>
</tr>
</table>
<!--分页-->

<!--底部功能栏 -->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="30" width="80%">&nbsp;<font color="gray">提示：对已出货的发货单进行时时动态跟踪记录，方便了解货运情况....</font></td>
      <td width="20%" align="right" >&nbsp;</td>
  </tr>
</table>
<!--底部功能栏-->

    </td>
  </tr>
</table>


    </form>
</body>
</html>

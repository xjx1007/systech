<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"  CodeFile="KNet_WareHouse_WareCheck_Manage_PrinterList.aspx.cs" Inherits="Knet_Web_WareHouse_KNet_WareHouse_WareCheck_Manage_PrinterList" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<title></title>
<script language="javascript"> 
function refresh() 
{ 
this.location = this.location; 
} 
</script>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
</head>

<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
<div id="ssdd" style="padding:1px"></div>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2" >库存盘点管理</div></td>
    <td width="550" background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;日期从<asp:TextBox ID="StartDate" runat="server" CssClass="Wdate"  onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})" ></asp:TextBox>&nbsp;到<asp:TextBox ID="EndDate" runat="server"  CssClass="Wdate"   onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})" ></asp:TextBox>&nbsp;关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="Boxx" Width="120px"></asp:TextBox></td>
    <td  background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="left"><asp:Button ID="Button4" runat="server" Text="盘点单检索"  CssClass="Btt" OnClick="Button4_Click"/></td>
  </tr>
</table>



<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
<!--GridView-->
        <asp:GridView ID="GridView1" runat="server"  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录，或没有受权相关仓库</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px"
          OnSorting="GridView1_Sorting"  OnRowDataBound="GridView1_DataRowBinding"  OnRowDeleting="GridView1_RowDeleting">
        <Columns>
        

        <asp:BoundField   HeaderText="序"  ItemStyle-Height="25px" ItemStyle-Width="25px"  HeaderStyle-Font-Size="12px"  HeaderStyle-HorizontalAlign="Left"  >
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        
        
        <asp:TemplateField ItemStyle-Width="20px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <ItemTemplate>
                   <a href="KNet_WareHouse_WareCheck_AddDetails.aspx?WareCheckNo=<%# DataBinder.Eval(Container.DataItem, "WareCheckNo") %>&Css2=Div22"><asp:Image ID="Image1" runat="server"  ImageUrl="../../images/Deitail.gif"  ToolTip="查看盘点单详细信息" /></a>
                 </ItemTemplate>
        </asp:TemplateField>
        
        
        <asp:BoundField  DataField="WareCheckTopic"  HeaderText="盘点主题"  SortExpression="WareCheckTopic">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
          
         <asp:BoundField  HeaderText="盘点单"  DataField="WareCheckNo"  ItemStyle-Width="115px"  SortExpression="WareCheckNo" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
         <asp:BoundField   HeaderText="盘点日期"  DataField="WareCheckDateTime" ItemStyle-Width="70px"  SortExpression="WareCheckDateTime"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
        
       
        <asp:TemplateField HeaderText="盘点仓库"  SortExpression="HouseNo" HeaderStyle-Font-Size="12px"  ItemStyle-Width="100px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetHouseNoName(DataBinder.Eval(Container.DataItem, "HouseNo"))%>
          </ItemTemplate>
        </asp:TemplateField>
        
        
       <asp:TemplateField HeaderText="选择打印模板" HeaderStyle-Font-Size="12px"  ItemStyle-Width="150px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <asp:DropDownList ID="PrinterModel" Width="150px" runat="server"></asp:DropDownList>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="选择模板" ControlToValidate="PrinterModel" Display="Dynamic" ValidationGroup="sssddd"></asp:RequiredFieldValidator>
          </ItemTemplate>
        </asp:TemplateField>
        

      <asp:TemplateField HeaderText="审核"  SortExpression="WareCheckCheckYN" HeaderStyle-Font-Size="12px"  ItemStyle-Width="30px"   ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# GetOrderCheckYN(DataBinder.Eval(Container.DataItem, "WareCheckNo"))%>
          </ItemTemplate>
        </asp:TemplateField>


        <asp:CommandField  ShowDeleteButton="True"  HeaderStyle-HorizontalAlign="center"  HeaderText="打印"  ButtonType="Image"  DeleteImageUrl="../../images/Printer.gif"   DeleteText="打印输出" ValidationGroup="sssddd"  >
            <ItemStyle HorizontalAlign="Left" Width="4%" Font-Size="12px"/>
            <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
        </asp:CommandField>
        
        
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
    FirstPageText="【首页】" LastPageText="【尾页】" NextPageText="【下页】" PageSize="14" PrevPageText="【前页】">
    </webdiyer:aspnetpager>
    </td>
</tr>
</table>
<!--分页-->

<!--底部功能栏 -->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="20" width="58%">&nbsp;</td>
      <td width="42%" align="right" >&nbsp;</td>
  </tr>
</table>
<!--底部功能栏-->

    </td>
  </tr>
</table>


    </form>
</body>
</html>

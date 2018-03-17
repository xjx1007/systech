<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"  CodeFile="KNet_WareHouse_WareCheck_Manage_Analysis.aspx.cs" Inherits="Knet_Web_WareHouse_KNet_WareHouse_WareCheck_Manage_Analysis" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<title></title>

</head>

<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
<div id="ssdd" style="padding:1px"></div>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">库存盘点管理</div></td>
    <td  background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;</td>
    <td width="120" background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="left">&nbsp;</td>
  </tr>
</table>

<div id="Div1" style="padding:1px"></div>


<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
<!--GridView-->
        <asp:GridView ID="GridView1" runat="server"  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px"
          OnSorting="GridView1_Sorting"  OnRowDataBound="GridView1_DataRowBinding" >
        <Columns>
        

        <asp:BoundField   HeaderText="序"  ItemStyle-Height="20px" ItemStyle-Width="20px"  HeaderStyle-Font-Size="12px"  HeaderStyle-HorizontalAlign="Left"  >
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        
        
        <asp:TemplateField   HeaderImageUrl="/images/icon_list_over.gif" ItemStyle-Width="30px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                 <ItemTemplate>
                   <a href="KNet_WareHouse_WareCheck_AddDetails.aspx?WareCheckNo=<%# DataBinder.Eval(Container.DataItem, "WareCheckNo") %>&Css2=Div22"><asp:Image ID="Image1" runat="server"  ImageUrl="/images/Deitail.gif"  ToolTip="查看盘点单" /></a>
                 </ItemTemplate>
        </asp:TemplateField>
        
        
         <asp:TemplateField HeaderText="产品名称"  SortExpression="ProductsName" HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# DataBinder.Eval(Container.DataItem, "ProductsName")%>
          </ItemTemplate>
        </asp:TemplateField>
          
         <asp:TemplateField HeaderText="产品型号"  SortExpression="ProductsPattern" HeaderStyle-Font-Size="12px"  ItemStyle-Width="120px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# DataBinder.Eval(Container.DataItem, "ProductsPattern")%>
          </ItemTemplate>
        </asp:TemplateField>
        
        
         <asp:BoundField  HeaderText="盘差数量"  DataField="WareCheckAmount"  ItemStyle-Width="80px"  SortExpression="WareCheckAmount" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        

        <asp:TemplateField HeaderText="盘点类型"  SortExpression="WareCheckLossUp" HeaderStyle-Font-Size="12px"  ItemStyle-Width="90px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetOrderAmountss(DataBinder.Eval(Container.DataItem, "WareCheckLossUp")) %>
          </ItemTemplate>
        </asp:TemplateField>
        
        
      <asp:TemplateField HeaderText="盘点单价" SortExpression="WareCheckUnitPrice"  HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ControlStyle-Width="90px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <asp:Label ID="Label1B" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"WareCheckUnitPrice")%>'></asp:Label>
          </ItemTemplate>
      </asp:TemplateField>
      
      
      <asp:TemplateField HeaderText="计价调节"  SortExpression="WareCheckDiscount"  HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ControlStyle-Width="90px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <asp:Label ID="Label1C" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"WareCheckDiscount")%>'></asp:Label>
          </ItemTemplate>
      </asp:TemplateField>
        
      
       <asp:BoundField  DataField="WareCheckTotalNet" ReadOnly="true" ItemStyle-Font-Size="12px"  SortExpression="WareCheckTotalNet"  HeaderText="净值合计" ItemStyle-Width="90px"   HeaderStyle-Font-Size="12px"  DataFormatString="{0:N}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField> 
        </Columns>
         
            <FooterStyle BackColor="LightSteelBlue" />
            <HeaderStyle BackColor="LightSteelBlue" />
            <AlternatingRowStyle BackColor="WhiteSmoke" />
             <PagerStyle HorizontalAlign="Left" />
        </asp:GridView>
<!--GridView-->  
<table width="100%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
<tr>
 <td height="30" ><asp:Label ID="SmA" runat="server" ></asp:Label></td>
</tr>
</table> 

<!--分页-->
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="28" bgcolor="#F2F4F9">
    <webdiyer:aspnetpager id="AspNetPager1" runat="server" horizontalalign="left" onpagechanged="AspNetPager1_PageChanged"
    showcustominfosection="Left" width="100%" meta:resourceKey="AspNetPager1" style="font-size:14px" PageIndexBoxStyle="width:18px;border-top:1px solid #A3B2CC;border-left:1px solid #A3B2CC;border-right:1px solid #A3B2CC;border-bottom:1px solid #A3B2CC;height:17px;"
    CustomInfoHTML="　当前页<font color='red'><b>%CurrentPageIndex%</b></font>共%PageCount%页，记录%StartRecordIndex%-%EndRecordIndex%" 
    ShowNavigationToolTip="True" CustomInfoStyle="font-size:14px;padding-top:6px;width:300px;" TextAfterPageIndexBox=" " SubmitButtonText="  转" SubmitButtonStyle="width:41px;height:21px;border: none;cursor:hand;background-image: url(../images/go.gif)"  CustomInfoTextAlign="left"  ShowPageIndexBox="Always" AlwaysShow="True" 
    FirstPageText="【首页】" LastPageText="【尾页】" NextPageText="【下页】" PageSize="10" PrevPageText="【前页】">
    </webdiyer:aspnetpager>
    </td>
</tr>
</table>
<!--分页-->

<!--底部功能栏 -->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="25" width="58%">&nbsp;<font color="blue">提示：</font> 点击 <img src="../images/Deitail.gif" width="11" height="11"> 可查看详细盘点单信息.</td>
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

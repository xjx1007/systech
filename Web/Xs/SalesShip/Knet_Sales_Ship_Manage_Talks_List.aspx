<%@ Page Language="C#" AutoEventWireup="true"   CodeFile="Knet_Sales_Ship_Manage_Talks_List.aspx.cs"   Inherits="KNet_Web_Sales_Knet_Sales_Ship_Manage_Talks_List" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
<script type="text/javascript">
     if(window != window.parent) 
     { var P = window.parent, D = P.loadinndlg(); }
</script>

<style type="text/css">
.Div11
{
  background-image:url(../../../images/midbottonA2.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
.Div22
{
  background-image:url(../../../images/midbottonB2.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
</style>

<title>发货跟踪信息列表</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div id="ListGo">

<div id="ssdd" style="padding:2px"></div>

<table  height="22" border="0" cellpadding="0" cellspacing="0" width="100%" align="center" >
      <tr>
        <td width="90" align="center"><asp:HyperLink ID="HyperLink1" runat="server" CssClass="Div11" Width="90px" Height="21px" Font-Size="14px"   Font-Bold="true" ForeColor="MintCream">跟踪列表</asp:HyperLink></td>
        <td width="4" align="center"></td>
        
        <td width="90" align="center"><asp:HyperLink ID="HyperLink2" runat="server" CssClass="Div22" Width="90px" Height="21px" Font-Size="14px" >添加跟踪</asp:HyperLink></td>
        <td width="4" align="center"></td>
        <td align="right">&nbsp;&nbsp;</td>
      </tr>
</table>



<table width="100%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
<!--GridView-->
        <asp:GridView ID="GridView1" runat="server"  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关洽谈记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px"
          OnSorting="GridView1_Sorting"  OnRowDataBound="GridView1_DataRowBinding" >
        <Columns>
        

        <asp:BoundField   HeaderText="序"  ItemStyle-Height="25px" ItemStyle-Width="25px"  HeaderStyle-Font-Size="12px"  HeaderStyle-HorizontalAlign="Left"  >
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>

      <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <HeaderTemplate>
                 <asp:CheckBox ID="CheckBox1" runat="server" Text="选"  Font-Size="12px" AutoPostBack="true"   OnCheckedChanged="CheckBox1_CheckedChanged"  Height="20px" />
                 </HeaderTemplate>
                 <ItemTemplate>
                     <asp:CheckBox ID="Chbk" runat="server"  />
                 </ItemTemplate>
        </asp:TemplateField>
        
       <asp:TemplateField HeaderText="发货跟踪内容"  HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# DataBinder.Eval(Container.DataItem, "FollowText")%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="快递"  SortExpression="KDName" HeaderStyle-Font-Size="12px"  ItemStyle-Width="90px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetKDName(DataBinder.Eval(Container.DataItem, "KDCodeName").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
         <asp:TemplateField HeaderText="快递单号"  SortExpression="KDName" HeaderStyle-Font-Size="12px"  ItemStyle-Width="90px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <a href="#"  onclick="javascript:window.open('Knet_Sales_Ship_Manage_Talks_Detail.aspx?com=<%# DataBinder.Eval(Container.DataItem, "KDName")%>&Code=<%# DataBinder.Eval(Container.DataItem, "KDCode")%>&Name=<%# DataBinder.Eval(Container.DataItem, "KDCodeName")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=580,height=250');"><%# DataBinder.Eval(Container.DataItem, "KDCode").ToString()%></a>
          </ItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField HeaderText="跟踪跟进人"  SortExpression="FollowStaffNo" HeaderStyle-Font-Size="12px"  ItemStyle-Width="90px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetStaffName(DataBinder.Eval(Container.DataItem, "FollowStaffNo"))%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField   HeaderText="进跟时间"  DataField="FollowDateTime"  SortExpression="FollowDateTime" >
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  Width="120px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
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
    showcustominfosection="Left" width="100%" meta:resourceKey="AspNetPager1" style="font-size:13px" PageIndexBoxStyle="width:18px;border-top:1px solid #A3B2CC;border-left:1px solid #A3B2CC;border-right:1px solid #A3B2CC;border-bottom:1px solid #A3B2CC;height:17px;"
    CustomInfoHTML="　当前页<font color='red'><b>%CurrentPageIndex%</b></font>共%PageCount%页，记录%StartRecordIndex%-%EndRecordIndex%" 
    ShowNavigationToolTip="True" CustomInfoStyle="font-size:13px;padding-top:0px;width:250px;" TextAfterPageIndexBox=" " SubmitButtonText="  转" SubmitButtonStyle="width:41px;height:21px;border: none;cursor:hand;background-image: url(/images/go.gif)"  CustomInfoTextAlign="left"  ShowPageIndexBox="Never" AlwaysShow="True" 
    FirstPageText="【首页】" LastPageText="【尾页】" NextPageText="【下页】" PageSize="10" PrevPageText="【前页】">
    </webdiyer:aspnetpager>
    </td>
</tr>
</table>
<!--分页-->

<!--底部功能栏-->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="30" width="58%">&nbsp;<asp:Button ID="Button2" runat="server"  CssClass="crmButton small save" Text="删除所选项" OnClick="Button1_Click" Width="75px"  />
    <asp:Button  ID="Button3" runat="server" Text="取消选择" CssClass="crmButton small cancel" OnClick="Button2_Click" Width="72px" /></td>
      <td width="42%" align="right" >&nbsp;</td>
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

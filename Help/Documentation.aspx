<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"  CodeFile="Documentation.aspx.cs" Inherits="Knet_Help_Documentation" %>

<%@ Register Src="inc/HowToUser_Setting.ascx" TagName="BasinsSetting" TagPrefix="uc1" %>
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
    <td width="150" background="../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">帮助文档</div></td>
    <td width="400" background="../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;&nbsp;关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="Boxx" Width="320px"></asp:TextBox></td>
    <td  background="../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="left"><asp:Button ID="Button4" runat="server" Text="帮助文档检索"  CssClass="Btt" OnClick="Button4_Click"/></td>
  </tr>
</table>



<div id="Div1" style="padding:1px"></div>
<%--莱单列表--%>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td><uc1:BasinsSetting id="ProcureBillingSetting1" runat="server"></uc1:BasinsSetting></td>
  </tr>
</table>







<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>

        <asp:GridView ID="GridView1" runat="server"  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px"
          OnSorting="GridView1_Sorting"  OnRowDataBound="GridView1_DataRowBinding" >
        <Columns>
        

        <asp:BoundField   HeaderText="序"  ItemStyle-Height="25px" ItemStyle-Width="30px" SortExpression="ID"  HeaderStyle-Font-Size="12px"  HeaderStyle-HorizontalAlign="Left"  >
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>

        
        <asp:BoundField  DataField="Titles"  HeaderText="帮助文档主题"  SortExpression="Titles">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        


        


          <asp:TemplateField HeaderText="文档分类"  SortExpression="kings"  HeaderStyle-Font-Size="12px" ItemStyle-Width="10%" ItemStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
           <ItemTemplate><%# getkingsstring(Eval("kings"))%></ItemTemplate>
        </asp:TemplateField>
        
        <asp:BoundField  DataField="Addtimes"   HeaderText="添加时间"  SortExpression="Addtimes" ItemStyle-Width="10%" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" >
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        

        
        
         <asp:TemplateField HeaderText="查看详细"   HeaderStyle-Font-Size="12px" ItemStyle-Width="8%"  SortExpression="ID" ItemStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
             <ItemTemplate><%# Get_MangerDetail(Eval("ID"))%></ItemTemplate>
        </asp:TemplateField>    
     
     
     
        </Columns>
         
            <FooterStyle BackColor="LightSteelBlue" />
            <HeaderStyle BackColor="LightSteelBlue" />
            <AlternatingRowStyle BackColor="WhiteSmoke" />
             <PagerStyle HorizontalAlign="Left" />
        </asp:GridView>

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
<!--底部功能栏-->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="30">&nbsp;</td>
  </tr>
</table>
<!--底部功能栏-->

    </td>
  </tr>
</table>


    </form>
</body>
</html>

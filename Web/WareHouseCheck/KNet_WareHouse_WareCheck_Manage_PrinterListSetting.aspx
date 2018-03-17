<%@ Page Language="C#" AutoEventWireup="true"   CodeFile="KNet_WareHouse_WareCheck_Manage_PrinterListSetting.aspx.cs" Inherits="Knet_Web_Warehouse_KNet_WareHouse_WareCheck_Manage_PrinterListSetting" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<title></title>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
</head>

<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
<div id="ssdd" style="padding:1px"></div>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">盘点打印模板</div></td>
    <td width="550"  background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;日期从<asp:TextBox ID="StartDate" runat="server" CssClass="Wdate"  onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})" ></asp:TextBox>&nbsp;到<asp:TextBox ID="EndDate" runat="server"  CssClass="Wdate"   onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})" ></asp:TextBox>&nbsp;关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="Boxx" Width="120px"></asp:TextBox></td>
    <td  background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="left"><asp:Button  ID="Button4" runat="server" Text="打印模板检索"  CssClass="Btt" OnClick="Button4_Click"/></td>
  </tr>
</table>
<div id="Div1" style="padding:1px"></div>





<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
<!--GridView-->
        <asp:GridView ID="GridView1" runat="server"  AllowSorting="false"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px"
         OnRowDataBound="GridView1_DataRowBinding" >
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
                
        <asp:TemplateField   HeaderText="是否启用" ItemStyle-Width="80px"  HeaderStyle-Font-Size="12px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <ItemTemplate>
                 &nbsp;<asp:Image ID="Image2" runat="server" />
                 </ItemTemplate>
        </asp:TemplateField>

        
        <asp:BoundField  DataField="PrinterTitle"  HeaderText="打印模板名称">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
          
         <asp:BoundField  HeaderText="更新日期"  DataField="PrinterDatetime"  ItemStyle-Width="180px"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
 
        
         <asp:TemplateField   HeaderText="修改模板"  HeaderStyle-Font-Size="12px" ItemStyle-Width="100px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                 <ItemTemplate>
                   <a href="KNet_WareHouse_WareCheck_Manage_PrinterList_Update.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ID") %>&Css5=Div22">修改模板</a>
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
    FirstPageText="【首页】" LastPageText="【尾页】" NextPageText="【下页】" PageSize="14" PrevPageText="【前页】">
    </webdiyer:aspnetpager>
    </td>
</tr>
</table>
<!--分页-->

<!--底部功能栏 -->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="30" width="30%">&nbsp;<asp:Button ID="Button2" runat="server"  CssClass="Btt" Text="删除所选项" OnClick="Button12_Click" />
    <asp:Button  ID="Button3" runat="server" Text="取消选择" CssClass="Btt" OnClick="Button2_Click"/></td>
      <td width="70%" align="right" ><font color="gray">可跟据不同的需求定制不同的打印模板，选择之后就可以直接输出打印.</font>&nbsp;&nbsp;<asp:Button  ID="Button1" runat="server" Text="添加模板" CssClass="Btt" OnClick="Button1_Click" style="width: 55px;height: 33px;"  /></td>
  </tr>
</table>
<!--底部功能栏-->

    </td>
  </tr>
</table>
   
    </form>
</body>
</html>

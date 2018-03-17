<%@ Page Language="C#" AutoEventWireup="true" CodeFile="logs.aspx.cs" Inherits="Knet_web_System_logs" %>
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
    <div>

<div id="ssdd" style="padding:1px"></div>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">系统操作日志</div></td>
    <td width="550" background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;日期从<asp:TextBox ID="StartDate" runat="server" CssClass="Wdate"  onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})" ></asp:TextBox>&nbsp;到<asp:TextBox ID="EndDate" runat="server"  CssClass="Wdate"   onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})" ></asp:TextBox>&nbsp;关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="Boxx" Width="120px"></asp:TextBox></td>
    <td  background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="left"><asp:Button ID="Button4" runat="server" Text="日志检索"  CssClass="Btt" OnClick="Button4_Click"/></td>
  </tr>
</table>


<div id="Div1" style="padding:1px"></div>


<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
<!--GridView-->
        <asp:GridView ID="GridView1" runat="server" AllowSorting="true"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true" 
         OnSorting="GridView1_Sorting"  OnRowDataBound="GridView1_DataRowBinding" >
        <Columns>
        
        <asp:BoundField   HeaderText="序号" SortExpression="ID"  HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="30px" HeaderStyle-Font-Size="12px"  HeaderStyle-Width="30px" >
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        
        <asp:TemplateField ItemStyle-Width="48px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <HeaderTemplate >
                 <asp:CheckBox ID="CheckBox1" runat="server" Text="全选"  Font-Size="12px" AutoPostBack="true"   OnCheckedChanged="CheckBox1_CheckedChanged"  Height="20px" />
                 </HeaderTemplate>
                 <ItemTemplate>
                     <asp:CheckBox ID="Chbk" runat="server"  />
                 </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="操作员工" SortExpression="StaffNo" ItemStyle-Font-Size="12px" HeaderStyle-Font-Size="12px" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
        <ItemTemplate><%# Knet_Get_StaffName(Eval("StaffNo"))%></ItemTemplate>
        </asp:TemplateField>
        
        <asp:BoundField  DataField="Logtime"   HeaderText="日志时间" SortExpression="Logtime">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px"  Width="120px"/>
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        
        <asp:TemplateField HeaderText="IP地址" SortExpression="logIP" ItemStyle-Font-Size="12px" HeaderStyle-Font-Size="12px" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate><%# IPtoAddress(Eval("logIP").ToString()) %><br />(<%# Eval("logIP")%>)</ItemTemplate>
        </asp:TemplateField>

        <asp:BoundField  DataField="logContent"   HeaderText="日志内容"  SortExpression="logContent">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
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
    showcustominfosection="Left" width="100%" meta:resourceKey="AspNetPager1" style="font-size:14px" PageIndexBoxStyle="width:18px;border-top:1px solid #A3B2CC;border-left:1px solid #A3B2CC;border-right:1px solid #A3B2CC;border-bottom:1px solid #A3B2CC;height:17px;"
    CustomInfoHTML="　当前页<font color='red'><b>%CurrentPageIndex%</b></font>共%PageCount%页，记录%StartRecordIndex%-%EndRecordIndex%" 
    ShowNavigationToolTip="True" CustomInfoStyle="font-size:14px;padding-top:1px;width:250px;" SubmitButtonText="  转" SubmitButtonStyle="width:41px;height:21px;border: none;cursor:hand;background-image: url(../../images/go.gif)"  CustomInfoTextAlign="left"  ShowPageIndexBox="Never" AlwaysShow="True" 
    FirstPageText="【首页】" LastPageText="【尾页】" NextPageText="【下页】" PageSize="10" PrevPageText="【前页】">
    </webdiyer:aspnetpager>
    </td>
</tr>
</table>
<!--分页-->

<!--底部功能栏-->
<table width="100%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="30" >&nbsp;<asp:Button ID="Button1" runat="server"  CssClass="Btt" Text="删除所选项" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />
    <asp:Button  ID="Button2" runat="server" Text="取消选择" CssClass="Btt" OnClick="Button2_Click"/>&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button3" runat="server" Text="删三个月前" CssClass="Btt" OnClick="Button3_Click" />&nbsp;&nbsp;<asp:Button ID="Button5" runat="server" Text="删二个月前" CssClass="Btt" OnClick="Button5_Click" />&nbsp;&nbsp;<asp:Button ID="Button6" runat="server" Text="删一个月前" CssClass="Btt" OnClick="Button6_Click" />&nbsp;&nbsp;<asp:Button ID="Button7" runat="server" Text="删三天前" CssClass="Btt" OnClick="Button7_Click" /></td>
  </tr>
</table>
<!--底部功能栏-->

    </td>
  </tr>
</table>



    </div>
    </form>
</body>
</html>

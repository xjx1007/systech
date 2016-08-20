﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KnetWarehouse_ToAuth.aspx.cs" Inherits="Knet_Web_System_KnetWarehouse_ToAuth" %>
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
    <div>

<div id="Div2" style="padding:1px"></div>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">仓库受权分配</div></td>
    <td width="320" align="right"  background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;人事搜索:<asp:TextBox ID="SeachKey" runat="server" Width="200px" CssClass="Boxx"></asp:TextBox></td>
    <td background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="left">&nbsp;<asp:Button ID="Button3" runat="server" Text="搜索" CssClass="Btt" OnClick="Button1_Click1" /></td>
  </tr>
</table>


<div id="Div1" style="padding:1px"></div>


<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-bottom:#3399CC 1px solid;border-right:#3399CC 1px solid;border-left:#3399CC 1px solid;border-top:#3399CC 1px solid;">
  <tr>
    <td>
<!--GridView-->
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true" 
          OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanging="GridView1_SelectedIndexChanging"  OnRowDeleting="GridView1_RowDeleting" OnSorting="GridView1_Sorting" >
        <Columns>
        
        <asp:BoundField   HeaderText="序号"  HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="30px"  HeaderStyle-Width="30px" HeaderStyle-Font-Size="12px" >
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        
        <asp:TemplateField ItemStyle-Width="20px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <ItemTemplate>
                 <asp:Image ID="Image1" runat="server" />
                 </ItemTemplate>
        </asp:TemplateField>
        
        <asp:BoundField  DataField="StaffCard"  HeaderText="员工卡号"  SortExpression="StaffCard">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px" Width="100px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        <asp:BoundField  DataField="StaffName"   HeaderText="员工姓名"  SortExpression="StaffName">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px"  Width="80px"/>
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        

        
        <asp:TemplateField HeaderText="所属分部"  SortExpression="StaffBranch" HeaderStyle-Font-Size="12px"  ItemStyle-Width="120px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetStaffBranchName(DataBinder.Eval(Container.DataItem, "StaffBranch"))%>
          </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="所在部门"  SortExpression="StaffDepart" HeaderStyle-Font-Size="12px"  ItemStyle-Width="100px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetStaffDepartName(DataBinder.Eval(Container.DataItem, "StaffDepart"))%>
          </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="已受权仓库" SortExpression="StaffNo" ItemStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Size="12px" >
        <ItemTemplate><%# GetKNet_Sys_WareHouseName(Eval("StaffNo").ToString())%></ItemTemplate>
        </asp:TemplateField>
        
        <asp:CommandField  ShowDeleteButton="True"   HeaderText="设置受权"  DeleteText="设置受权">
            <ItemStyle HorizontalAlign="Left" Width="60px" Font-Size="12px"/>
            <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
        </asp:CommandField>
        
         <asp:CommandField  ShowSelectButton="true"  HeaderText="取消受权"  SelectText="取消受权" >
            <ItemStyle HorizontalAlign="Left" Width="60px" Font-Size="12px"/>
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
    FirstPageText="【首页】" LastPageText="【尾页】" NextPageText="【下页】" PageSize="6" PrevPageText="【前页】">
    </webdiyer:aspnetpager>
    </td>
</tr>
</table>


<!--分页-->
<!--底部功能栏-->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="30" width="58%">&nbsp;&nbsp;<img src="../../images/Au1.gif" />表示已有受权&nbsp;&nbsp;<img src="../../images/Au2.gif"  />表示没有受权&nbsp;</td>
      <td width="42%" align="right" ><asp:DropDownList ID="StrucNameDList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="StrucNameDList_SelectedIndexChanged">
      </asp:DropDownList></td>
  </tr>
</table>
<!--底部功能栏-->

    </td>
  </tr>
</table>

<Div style="margin-top:5px"></Div>

<table width="99%"  id="Apant"  runat="server"  border="0" cellspacing="1" cellpadding="1" class="tablecss" align="center" >
  <tr>
    <td width="46%" height="47" valign="top">&nbsp;
      <asp:ListBox ID="AuthWareHouse1" runat="server" Width="300px" Height="150px"  SelectionMode="Multiple"></asp:ListBox><br />
        &nbsp;<asp:Button ID="Button1" runat="server" Text="确定设置仓库受权" CssClass="Btt" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />&nbsp;&nbsp;<asp:Button
            ID="Button2" runat="server" Text="放弃受权" CssClass="Btt" OnClick="Button2_Click" /></td>
    <td width="54%" valign="top"><font color="#666666">给人员 <font color="red"><b>
      <asp:Label ID="StaffNo1" runat="server" Text=""></asp:Label></b></font> 受权可操作的仓库。<br /><br />请在左边选择仓库，按Ctrl可多选。<br />
    <br />设置仓库受权后该员工方可操作所受权仓库里的数据记录。没有受权将无法对仓库里的记录进行操作！<br />
    <br />该受权目的是限制各相关员工只能对自己所属的仓库（分部）进行操作。</font>
    <asp:HiddenField ID="HiddenFieldStaffNo1"  runat="server"  />
    </td>
  </tr>
</table>

    </div>
    </form>
</body>
</html>

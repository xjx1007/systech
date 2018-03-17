<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"  CodeFile="KnetUserGroup.aspx.cs" Inherits="Knet_Web_System_KnetUserGroup" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<title></title>

<style type="text/css">
.Div11
{
  background-image:url(../../images/midbottonA2.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
.Div22
{
  background-image:url(../../images/midbottonB2.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
</style>


</head>

<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
<div id="ssdd" style="padding:1px"></div>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">用户组管理</div></td>
    <td  background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;&nbsp;</td>
    <td width="216" background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="center">&nbsp;</td>
  </tr>
</table>
<div id="Div1" style="padding:1px"></div>


<table  height="22" border="0" cellpadding="0" cellspacing="0" width="99%" align="center" >
      <tr>
        <td width="90" align="center"><asp:HyperLink ID="HyperLink1" runat="server"  NavigateUrl="KnetUserGroup.aspx"  CssClass="Div22" Width="90px" Height="21px" Font-Size="14px" Font-Bold="true" ForeColor="MintCream">用户组列表</asp:HyperLink></td>
        <td width="4" align="center"></td>
        <td width="90" align="center"><asp:HyperLink ID="HyperLink2" runat="server"  NavigateUrl="KnetUserGroup_add.aspx"  CssClass="Div11" Width="90px" Height="21px" Font-Size="14px">用户组添加</asp:HyperLink></td>
        <td width="4" align="center"></td>
        <td align="center">&nbsp;</td>
      </tr>
</table>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
<!--GridView-->
        <asp:GridView ID="GridView1" runat="server"  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px"
        OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_Editing"  OnSorting="GridView1_Sorting"  OnRowDataBound="GridView1_DataRowBinding"  >
        <Columns>
        

        <asp:BoundField   HeaderText="序号" ItemStyle-Height="25px"  HeaderStyle-Font-Size="12px"  HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="5%"  HeaderStyle-Width="5%" >
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        
        
        <asp:TemplateField ItemStyle-Width="100px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <HeaderTemplate>
                 <asp:CheckBox ID="CheckBox1" runat="server" Text="全选"  Font-Size="12px" AutoPostBack="true"   OnCheckedChanged="CheckBox1_CheckedChanged"  Height="20px" />
                 </HeaderTemplate>
                 <ItemTemplate>
                     <asp:CheckBox ID="Chbk" runat="server"  />
                 </ItemTemplate>
        </asp:TemplateField>
        

        
        
        <asp:BoundField  DataField="GroupName"  HeaderText="用户组名称" ItemStyle-Width="200px" ControlStyle-CssClass="Boxx" ControlStyle-Width="120px" SortExpression="GroupName">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        
        
       <asp:TemplateField HeaderText="排序值" HeaderStyle-Font-Size="12px"  ItemStyle-Width="150px"   SortExpression="GroupPai" ControlStyle-Width="100px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <EditItemTemplate> 
                <asp:TextBox ID="GroupPaitxt" runat="server" CssClass="Boxx"  MaxLength="6" Width="100px" Text='<%# DataBinder.Eval(Container.DataItem,"GroupPai")%>'></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="JoinNumbera"  runat="server" ErrorMessage="正整数!" ControlToValidate="GroupPaitxt" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="JoinNumberbb" runat="server" ErrorMessage="正整数!" ControlToValidate="GroupPaitxt" ValidationExpression="^\+?[1-9][0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
          </EditItemTemplate>
          <ItemTemplate>
              <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"GroupPai")%>'></asp:Label>
          </ItemTemplate>
       </asp:TemplateField>
       
       
      <asp:TemplateField HeaderText="组权限设置" HeaderStyle-Font-Size="12px"    SortExpression="GroupValue"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
             <%# Get_MangerDetail(Eval("GroupValue").ToString())%>&nbsp;<%# GetGroupNameYNPic(Eval("GroupValue").ToString())%>
          </ItemTemplate>
       </asp:TemplateField>
       
       
        
         <asp:CommandField  ShowEditButton="true"  HeaderText="修改"  EditText="修改">
            <ItemStyle HorizontalAlign="Left" Width="100px" Font-Size="12px"/>
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
    FirstPageText="【首页】" LastPageText="【尾页】" NextPageText="【下页】" PageSize="10" PrevPageText="【前页】">
    </webdiyer:aspnetpager>
    </td>
</tr>
</table>
<!--分页-->

<!--底部功能栏-->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="30" width="40%">&nbsp;<asp:Button ID="Button2" runat="server"  CssClass="Btt" Text="删除所选项" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />
    <asp:Button  ID="Button3" runat="server" Text="取消选择" CssClass="Btt" OnClick="Button2_Click"/></td>
      <td width="60%" align="right" ><img src="../../images/Au1.gif" />表示用户组已有设置操作权限&nbsp;&nbsp;<img src="../../images/Au2.gif" />表示用户组没有设置操作权限</td>
  </tr>
</table>
<!--底部功能栏-->


    </td>
  </tr>
</table>


    </form>
</body>
</html>

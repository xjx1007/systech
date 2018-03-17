<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_OrganizationalStructure.aspx.cs" Inherits="KNet_Web_HR_OrganizationalStructure" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="inc/Structermenu.ascx" TagName="Structermenu" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<title></title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

<table width="98%" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td height="2"></td>
  </tr>
</table>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">组织架构</div></td>
    <td  background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">
	
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="80px" align="right" >&nbsp;</td>
    <td width="200px" align="left" >&nbsp;</td>
    <td width="80px"  align="center" >&nbsp;</td>
    <td align="center">&nbsp;</td>
  </tr>
</table>
	
	</td>
  </tr>
</table>

<table width="98%" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td height="2"></td>
  </tr>
</table>




<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-bottom:#3399CC 1px solid;border-right:#3399CC 1px solid;border-left:#3399CC 1px solid;border-top:#3399CC 1px solid;">
      <tr>
        <td width="31%" height="241" valign="top" bgcolor="#ffffff">
<div style="height:480px; overflow:auto; background-color:#EEF3F9; border-right:#3399CC 1px solid;">
   <asp:TreeView ID="TreeView1" runat="server" EnableClientScript="False" PopulateNodesFromClient="False"  ShowLines="true"  ExpandDepth=2   Enabled="false" ></asp:TreeView>
</div></td>
        <td width="69%" valign="top"  bgcolor="#F3F3F3" style="border-bottom:#6699CC 0px solid;">
        
        
<table width="100%" height="100" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td height="30" valign="bottom" style="border-bottom:#6699CC 1px solid;">&nbsp;
        <uc1:Structermenu ID="Structermenu1" runat="server" />
    </td>
  </tr>
  <tr>
    <td height="100" valign="top">
    
 <asp:GridView ID="GridView1" runat="server" RowStyle-Height="25px" HeaderStyle-Height="25px" AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true" 
        OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_Editing"  OnSorting="GridView1_Sorting"  OnRowDataBound="GridView1_DataRowBinding" OnRowDeleting="GridView1_del">
        <Columns>
        
        <asp:BoundField  DataField="ID"  HeaderText="序号" ReadOnly="true" SortExpression="ID">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px" Width="40px"/>
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>

        
        <asp:BoundField  DataField="StrucName"   HeaderText="分部名称" ControlStyle-CssClass="Boxx" ControlStyle-Width="150px" SortExpression="StrucName">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        

       <asp:TemplateField HeaderText="排序号" HeaderStyle-Font-Size="12px"  ItemStyle-Width="10%"    SortExpression="StrucPai" ControlStyle-Width="30px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <EditItemTemplate> 
                <asp:TextBox ID="UnitsPaitxt" runat="server" CssClass="Boxx" Width="60px" Text='<%# DataBinder.Eval(Container.DataItem,"StrucPai")%>'></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="JoinNumbera"  runat="server" ErrorMessage="正整数!" ControlToValidate="UnitsPaitxt" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="JoinNumberbb" runat="server" ErrorMessage="正整数!" ControlToValidate="UnitsPaitxt" ValidationExpression="^\+?[1-9][0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
          </EditItemTemplate>
          <ItemTemplate>
              <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"StrucPai")%>'></asp:Label>
          </ItemTemplate>
      </asp:TemplateField>

         <asp:CommandField  ShowEditButton="true"  HeaderText="修改"  EditText="修改">
            <ItemStyle HorizontalAlign="Left" Width="13%" Font-Size="12px"/>
            <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
        </asp:CommandField>
   
        <asp:CommandField  ShowDeleteButton="True"   HeaderText="删除"  DeleteText="删除" >
            <ItemStyle HorizontalAlign="Left" Width="6%" Font-Size="12px"/>
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
<table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="20" bgcolor="#F2F4F9">
    <webdiyer:aspnetpager id="AspNetPager1" runat="server" horizontalalign="left" onpagechanged="AspNetPager1_PageChanged"
    showcustominfosection="Left" width="100%" meta:resourceKey="AspNetPager1" style="font-size:12px" PageIndexBoxStyle="width:18px;border-top:1px solid #A3B2CC;border-left:1px solid #A3B2CC;border-right:1px solid #A3B2CC;border-bottom:1px solid #A3B2CC;height:17px;"
    CustomInfoHTML="　当前页<font color='red'><b>%CurrentPageIndex%</b></font>共%PageCount%页，记录%StartRecordIndex%-%EndRecordIndex%" 
    ShowNavigationToolTip="True" CustomInfoStyle="font-size:12px;padding-top:0px;width:200px;" TextAfterPageIndexBox=" " SubmitButtonText="  转" SubmitButtonStyle="width:41px;height:21px;border: none;cursor:hand;background-image: url(../../images/go.gif)"  CustomInfoTextAlign="left"  ShowPageIndexBox="Never" AlwaysShow="True" 
    FirstPageText="【首页】" LastPageText="【尾页】" NextPageText="【下页】" PageSize="8" PrevPageText="【前页】">
    </webdiyer:aspnetpager>
    </td>
</tr>
</table>


    
    </td>
  </tr>
  <tr>
    <td height="90" valign="top">
    
<table width="99%" border="0" align="center" height="25" cellpadding="0" cellspacing="0" style="border-bottom:#BAC5D9 1px solid;border-top:#BAC5D9 1px solid;border-left:#BAC5D9 1px solid;border-right:#BAC5D9 1px solid" >
  <tr >
    <td height="25" colspan="4" align="left" bgcolor="#EEF3F9" style="border-bottom:#cccccc 0px solid;">&nbsp;&nbsp;<font color="gray">分部列表，您可以添加任意的公司分部.</font></td>
    <td height="25" bgcolor="#EEF3F9" align="right">&nbsp;<asp:Button ID="Button2" runat="server" Text="添加分部" CssClass="Btt" OnClick="Button2_Click" /></td>
  </tr>
<tr id="AddNewsCompany" runat="server" visible="false">
    <td width="221" height="27" align="right">分部名称:</td>
    <td width="332" align="left"><asp:TextBox ID="txtStrucName" Width="150px" runat="server" CssClass="Boxx"></asp:TextBox>(<font color="red">*</font>)<asp:RequiredFieldValidator
            ID="RequiredFieldValidator1" runat="server" ErrorMessage="非空！" ControlToValidate="txtStrucName" Display="Dynamic" ></asp:RequiredFieldValidator></td>
    <td width="117"  align="right">排序号：</td>
    <td width="132" align="left"><asp:TextBox ID="txtStrucPai" MaxLength=5 Text="10" Width="40px" runat="server" CssClass="Boxx"></asp:TextBox>(<font color="red">*</font>)<asp:RequiredFieldValidator
            ID="RequiredFieldValidator2" runat="server" ErrorMessage="非空！" ControlToValidate="txtStrucPai" Display="Dynamic" ></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="正整数!" ControlToValidate="txtStrucPai" ValidationExpression="^(0|[1-9][0-9]*)$" Display="Dynamic"></asp:RegularExpressionValidator></td>
    <td width="171" align="left" >&nbsp;&nbsp;
      <asp:Button ID="Button1" runat="server" Text="添加"  CssClass="Btt" OnClick="Button1_Click"  />&nbsp;<asp:Button
          ID="Button3" runat="server" Text="关闭"  CssClass="Btt" OnClick="Button3_Click"  CausesValidation="false"/></td>
</tr>
</table>
    
    </td>
  </tr>
</table>
        
        
        </td>
      </tr>
    </table>
    
    </form>
</body>
</html>
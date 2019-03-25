<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="KNet_Sales_BasisSetting_Contract.aspx.cs" Inherits="KNet_Web_Sales_KNet_Sales_BasisSetting_Contract" %>

<%@ Register Src="inc/BasinsSetting.ascx" TagName="BasinsSetting" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
<title></title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>

<div id="ssdd" style="padding:1px"></div>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">销售管理设置</div></td>
    <td background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;</td>
    <td width="173" background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;"></td>
  </tr>
</table>
<div id="Div1" style="padding:1px"></div>

<table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" >
  <tr>
    <td height="22" colspan="2" align="left" bgcolor="#E6F0F9" valign="bottom" >
       <uc1:BasinsSetting ID="BasinsSetting1" runat="server" />
    </td>
  </tr>
  <tr>  
    <td height="224"  align="left" valign="top"  style="border-bottom:#3399CC 1px solid;border-right:#3399CC 1px solid;border-left:#3399CC 1px solid;border-top:#3399CC 1px solid;">
<%--工作区--%>
<table width="100%" border="0" align="center" height="30px" cellpadding="0" cellspacing="0" style="border-bottom:#3399CC 1px solid" >
  <tr >
   <td width="140" align="center"><B>[合同分类]</B></td>
    <td width="80" align="right">分类名称:</td>
    <td width="160" align="left"><asp:TextBox ID="txtUnitsName" Width="150px" runat="server" CssClass="Boxx"></asp:TextBox></td>
    <td width="77"  align="right">排序号：</td>
    <td width="65" align="left"><asp:TextBox ID="txtUnitsPai"   MaxLength="5"  Text="10" Width="60px" runat="server" CssClass="Boxx"></asp:TextBox><asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="不能为空!"  ControlToValidate="txtUnitsPai" MaximumValue=99999  MinimumValue=1 Type="Integer" Display="Dynamic"></asp:RangeValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="正整数!" ControlToValidate="txtUnitsPai" ValidationExpression="^(0|[1-9][0-9]*)$" Display="Dynamic"></asp:RegularExpressionValidator></td>
    <td align="left" >&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="确定添加合同分类"  CssClass="Btt" OnClick="Button8_Click"  /></td>
  </tr>
</table>


<!--GridView-->
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true" 
        OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_Editing"  OnSorting="GridView1_Sorting"  OnRowDataBound="GridView1_DataRowBinding" >
        <Columns>
        
        <asp:BoundField  DataField="ID"  HeaderText="序号" ReadOnly="true" SortExpression="ID">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px" Width="40px"/>
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        
        <asp:TemplateField ItemStyle-Width="7%" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <HeaderTemplate >
                 <asp:CheckBox ID="CheckBox1" runat="server" Text="全选"  Font-Size="12px" AutoPostBack="true"   OnCheckedChanged="CheckBox1_CheckedChanged"  Height="20px" />
                 </HeaderTemplate>
                 <ItemTemplate>
                     <asp:CheckBox ID="Chbk" runat="server"  />
                 </ItemTemplate>
        </asp:TemplateField>
        

        
        <asp:BoundField  DataField="Client_Name"   HeaderText="合同分类名称" ControlStyle-CssClass="Boxx"   ControlStyle-Width="250px" SortExpression="Client_Name">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        

       <asp:TemplateField HeaderText="排序号" HeaderStyle-Font-Size="12px"  ItemStyle-Width="10%"    SortExpression="ClientPai" ControlStyle-Width="60px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <EditItemTemplate> 
                <asp:TextBox ID="UnitsPaitxt" runat="server"   MaxLength="5" CssClass="Boxx" Width="60px" Text='<%# DataBinder.Eval(Container.DataItem,"ClientPai")%>'></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="JoinNumbera"  runat="server" ErrorMessage="整数!" ControlToValidate="UnitsPaitxt" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="JoinNumberbb" runat="server" ErrorMessage="整数!" ControlToValidate="UnitsPaitxt" ValidationExpression="^\+?[0-9][0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
          </EditItemTemplate>
          <ItemTemplate>
              <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ClientPai")%>'></asp:Label>
          </ItemTemplate>
      </asp:TemplateField>




         <asp:CommandField  ShowEditButton="true"  HeaderText="修改"  EditText="修改">
            <ItemStyle HorizontalAlign="Left" Width="15%" Font-Size="12px"/>
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
    <td height="30" width="58%">&nbsp;<asp:Button ID="Button2" runat="server"  CssClass="Btt" Text="删除所选项" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />
    <asp:Button  ID="Button3" runat="server" Text="取消选择" CssClass="Btt" OnClick="Button2_Click"/></td>
      <td width="42%" align="right" >&nbsp;
    </td>
  </tr>
</table>
<!--底部功能栏-->

    
<%--工作区--%>
    </td>
  </tr>
</table>

</div>
</form>
</body>
</html>

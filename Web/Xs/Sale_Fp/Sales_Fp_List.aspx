<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sales_Fp_List.aspx.cs" Inherits="Web_Sales_Sales_ShipWareOut_Manage" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
<link rel="stylesheet" href="../../css/knetwork.css" type="text/css">
<title></title>
</head>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../js/Global.js"></script>    
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
<div id="ssdd" style="padding:1px"></div>


<div id="Div2" class="TitleBar">�����������</div>
<div id="Div1" style="padding:1px"></div>


<%--�̶���ʽ --%>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td style="text-align: center">
<!--GridView-->
        <!--GridView-->
        <!--��ҳ-->
        <br />
        <table width="70%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss_Select">
            <tr>
                <td class="tableBotcss" width="15%" style="height: 30px; text-align: right">���ⵥ�ţ�</td>
                <td class="tableBotcss" width="35%" style="height: 30px; text-align: left"><asp:TextBox ID="Tbx_DirectNo" runat="server"></asp:TextBox></td>
                <td class="tableBotcss" width="15%" style="height: 30px; text-align: right">�ͻ����ƣ�</td>
                <td class="tableBotcss1" width="35%" style="height: 30px; text-align: left">
                    <asp:TextBox ID="Tbx_CustomerName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="tableBotcss" width="15%" style="text-align: right">�ջ��ˣ�</td>
                <td class="tableBotcss" width="35%" style="text-align: left"><asp:TextBox ID="Tbx_ReceiveMan" runat="server"></asp:TextBox></td>
                <td class="tableBotcss" width="15%" style="text-align: right">�����ֿ�</td>
                <td class="tableBotcss1" width="35%" style="text-align: left"><asp:DropDownList ID="Drop_House" runat="server"></asp:DropDownList></td>
            </tr>
        </table>
        <br />
        
    <div align="center">           
        <asp:Button ID="Btn_Query" runat="server" Text="�� ѯ" CssClass="Custom_Button" OnClick="Btn_Query_Click" Height="23px" Width="57px"></asp:Button>&nbsp;
        <asp:Button ID="Btn_Del" runat="server" Text="ɾ ��" CssClass="Custom_Button"  Height="23px" Width="57px" OnClick="Btn_Del_Click"></asp:Button>&nbsp;
        <input id="Btn_All" type="button" class="Custom_Button" value="ȫ ѡ" onclick="javascript:selectAllButton(this);"   style="width: 57px; height: 23px"/>&nbsp;
        <input class="Custom_Button" id="Btn_Reset" onclick="PageGo('Sales_ShipWareOut_Manage.aspx')" type="button" value="�� λ"  style="width: 57px; height: 23px" />  
    </div>
        <hr width="720">
        
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="28" bgcolor="#F2F4F9">
    <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True" IsShowEmptyTemplate="true" EmptyDataText="<div align=center><font color=red><br/><br/><B>û���ҵ���زɹ�����¼</B><br/><br/></font></div>" 
            AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="10" Width="100%"><HeaderStyle CssClass='Custom_DgHead' />
        <RowStyle CssClass='Custom_DgItem' />
        <AlternatingRowStyle BackColor="#E3EAF2" />
        <PagerStyle CssClass='Custom_DgPage' />
        <Columns>
        <asp:TemplateField>
                <HeaderTemplate> 
                 <input type="CheckBox" onclick="selectAll(this)">
                 </HeaderTemplate>
                 <ItemTemplate>
                     <asp:CheckBox ID="Chbk" runat="server" />
                 </ItemTemplate>
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle Height="25px" HorizontalAlign="Left" Width="40px" />
        </asp:TemplateField>
        
          
         <asp:BoundField  HeaderText="���ⵥ��"  DataField="DirectOutNo"  SortExpression="DirectOutNo" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        <asp:TemplateField HeaderText="�ͻ�����"  SortExpression="KWD_Custmoer">
          <ItemTemplate>
               <%# base.Base_GetCustomerName(DataBinder.Eval(Container.DataItem, "KWD_Custmoer").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField  HeaderText="�ջ���"  DataField="KWD_ContentPerson"  SortExpression="KWD_ContentPerson" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
         <asp:BoundField  HeaderText="�ջ���ַ"  DataField="KWD_Address"  SortExpression="KWD_Address" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
         <asp:BoundField  HeaderText="��������"  DataField="DirectOutDateTime" DataFormatString="{0:yyyy-MM-dd}"   SortExpression="DirectOutDateTime" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        <asp:TemplateField HeaderText="����ֿ�"  SortExpression="HouseNo">
          <ItemTemplate>
               <%# base.Base_GetHouseName(DataBinder.Eval(Container.DataItem, "HouseNo").ToString())%>
          </ItemTemplate>
          </asp:TemplateField>
        <asp:TemplateField HeaderText="��������"  SortExpression="DirectOutStaffDepart">
          <ItemTemplate>
               <%# base.Base_GeDept(DataBinder.Eval(Container.DataItem, "DirectOutStaffDepart").ToString())%>
          </ItemTemplate>
          </asp:TemplateField>
        <asp:TemplateField HeaderText="������"  SortExpression="DirectOutStaffBranch">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "DirectOutStaffNo").ToString())%>
          </ItemTemplate>
          </asp:TemplateField>
          
        <asp:TemplateField HeaderText="�޸�" HeaderStyle-HorizontalAlign="center" HeaderStyle-Width="30px">
            <ItemTemplate>
            <a href="../WareHouse/KNet_WareHouse_DirectOut_AddDetails.aspx?DirectOutNo=<%# DataBinder.Eval(Container.DataItem, "DirectOutNo") %>&Type=101&Css2=Div22"><asp:Image ID="Image1" runat="server"  ImageUrl="../../images/Edit.gif" border=0  ToolTip="�޸�" /></a>
           </ItemTemplate>
        </asp:TemplateField>
        
      <asp:TemplateField HeaderText="���"  SortExpression="DirectOutCheckYN" HeaderStyle-Font-Size="12px"  ItemStyle-Width="30px"   ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# GetOrderCheckYN(DataBinder.Eval(Container.DataItem, "DirectOutNo"))%>
          </ItemTemplate>
        </asp:TemplateField>
</Columns>
</cc1:MyGridView>
    </td>
</tr>
</table>
<!--��ҳ-->
<!--�ײ�������-->

    </td>
  </tr>
</table>


    </form>
</body>
</html>
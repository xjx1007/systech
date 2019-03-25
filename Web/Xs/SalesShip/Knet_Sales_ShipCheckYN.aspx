<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Knet_Sales_ShipCheckYN.aspx.cs" Inherits="Knet_Web_Sales_pop_Knet_Sales_ShipCheckYN" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="/css/knetwork.css" type="text/css">
<title>发货单进展操作--审核</title>
     <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
<script>   
  function closeWindow()   
  {   
  window.opener=null;   
  window.close();   
  }   
  </script>   
  
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>

<div class="TitleBar">发货单审核</div>
<table width="98%" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td height="2"></td>
  </tr>
</table>



<%--内容开始--%>

<table width="100%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>

<asp:Label ID="UsersNotxt" runat="server" Text="" Visible="false"></asp:Label>


<table width="100%" height="102" border="0" cellpadding="0" cellspacing="0">
<tr>
    <td width="36%" height="30" align="right" style="border-bottom:#A3B2CC 1px solid;">审核意见：</td>
    <td width="64%" style="border-bottom:#A3B2CC 1px solid;">
    <asp:TextBox  runat="server"  ID="Tbx_Remark" Text="" TextMode="MultiLine" Width="170px" Height="100px"></asp:TextBox>
    </td>
  </tr>
<tr>
    <td width="36%" height="30" align="right" style="border-bottom:#A3B2CC 1px solid;">供应商备注：</td>
    <td width="64%" style="border-bottom:#A3B2CC 1px solid;">
    <asp:TextBox  runat="server"  ID="Tbx_SuppRemarks" Text="" TextMode="MultiLine" Width="170px" Height="100px"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td width="36%" height="30" align="right" style="border-bottom:#A3B2CC 1px solid;">发货审核选择：</td>
    <td width="64%" style="border-bottom:#A3B2CC 1px solid;">&nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
       
       <asp:ListItem Value="-1">请选择审核</asp:ListItem>
       <asp:ListItem Value="1">通过审核</asp:ListItem>
       <asp:ListItem Value="0">不通过审核</asp:ListItem>
       </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
            runat="server" ErrorMessage="请选择审核" ControlToValidate="DropDownList1" Display="Dynamic"></asp:RequiredFieldValidator>
    </td>
  </tr>
  
  <tr>
    <td width="36%" height="30" align="right" style="border-bottom:#A3B2CC 1px solid;">是否指定：</td>
    <td width="64%" style="border-bottom:#A3B2CC 1px solid;"><asp:CheckBox runat="server" ID="IsChecked" AutoPostBack="true" Text="否"  Checked="true" OnCheckedChanged="IsChecked_CheckedChanged"/>
        <asp:DropDownList runat="Server" ID="Ddl_Person"></asp:DropDownList>
    </td>
  </tr>
        <tr>
           <td height="30" colspan="2" align="center" >&nbsp;<font color="gray"></font>
           <asp:Label ID="MyStatStr" runat="server" Text="" Visible="false" ForeColor="red" ></asp:Label>
            </td>
      </tr>
  <tr>
    <td height="30" colspan="2" align="center" >&nbsp;
    <asp:Button ID="Button1" runat="server" Text="确定审核" CssClass="Btt" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />&nbsp;<input   name="button2"   type="button"   value="关闭本窗口"  class="Btt"  onclick="closeWindow();"> </td>
  </tr>
    <tr>
           <td height="30" colspan="2" align="left" >
                  <asp:GridView ID="GridView1" runat="server"  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px" >
        <Columns>
        
        
      <asp:TemplateField HeaderText="审核人"  SortExpression="KSF_ShPerson" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "KSF_ShPerson").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="所在部门"  SortExpression="StaffDepart" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GeDept(DataBinder.Eval(Container.DataItem, "StaffDepart").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="职位"  SortExpression="Position" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetBasicCodeName("105",DataBinder.Eval(Container.DataItem, "Position").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField  HeaderText="审核时间"  DataField="KSF_Date"  ItemStyle-Width="70px"  SortExpression="KSF_Date" >
            <ItemStyle HorizontalAlign="center"   Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="center" Font-Size="12px"  />
        </asp:BoundField>
        
        
         <asp:BoundField  HeaderText="审核意见"  DataField="KSF_Detail"  ItemStyle-Width="115px"  SortExpression="KSF_Detail" >
            <ItemStyle HorizontalAlign="center"   Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="center" Font-Size="12px"  />
        </asp:BoundField>
        
        <asp:TemplateField HeaderText="指定审核人"  SortExpression="KFS_NextPerson" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "KFS_NextPerson").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
        </Columns>
         
            <FooterStyle BackColor="LightSteelBlue" />
            <HeaderStyle BackColor="LightSteelBlue" />
            <AlternatingRowStyle BackColor="WhiteSmoke" />
             <PagerStyle HorizontalAlign="Left" />
        </asp:GridView>
           </td>
      </tr>
</table>

<!--底部功能栏-->
<table width="100%" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td height="30" >&nbsp;</td>
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

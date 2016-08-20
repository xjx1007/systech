<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectCKProducts.aspx.cs" Inherits="Web_Common_SelectCKProducts" %>


<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<base target="_self" />
<script>   
  function closeWindow()   
  {   
  window.opener=null;   
  window.close();   
  }  
</script> 
<title>选择发货明细</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>
    
<div id="Div2" class="TitleBar">选择发货明细</div>

<div id="ssdd" style="padding:1px"></div>
<!--头部-->
<%--内部开始--%>


<!--底部功能栏-->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
      <td width="65%"  >
      <select id="BigClass"  runat="server"  onchange="changsheng(this.value)">
    <option value="0">--请选择大类--</option>
</select>
 <select id="SmallClass" runat="server">
	<option value="0">--请选择小类--</option>
</select>关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="Boxx" Width="100px"></asp:TextBox>&nbsp;<asp:Button  ID="Button5" runat="server" Text="产品筛选" CssClass="Btt" OnClick="Button1_Click1" /></td>
  </tr>
</table>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
<!--GridView-->
       <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%"  PageSize="10"  BorderColor="#4974C2" >
        <Columns>
        
        <asp:TemplateField HeaderText="选择" HeaderStyle-Font-Size="12px" ItemStyle-Width="40px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <ItemTemplate>
                     <asp:CheckBox ID="Chbk" runat="server"  />
                 </ItemTemplate>
        </asp:TemplateField>
        
        
        <asp:BoundField  DataField="ProductsName"  HeaderText="产品名称"  SortExpression="ProductsName">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        <asp:BoundField  DataField="ProductsPattern"  HeaderText="产品型号"  SortExpression="ProductsPattern">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
            <asp:TemplateField HeaderText="版本">    
                <ItemTemplate>
                    <%#base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                </ItemTemplate>
                </asp:TemplateField>
        <asp:TemplateField HeaderText="单位" SortExpression="ProductsUnits"   HeaderStyle-Font-Size="12px"  ItemStyle-Width="70px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
          <%#base.Base_GetUnitsName( DataBinder.Eval(Container, "DataItem.ProductsUnits").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="库存数量"   HeaderStyle-Font-Size="12px"  ItemStyle-Width="70px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
          <%#base.Base_GetKCNumber(DataBinder.Eval(Container, "DataItem.ProductsBarCode").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="单价"  HeaderStyle-Font-Size="12px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
                <pc:PTextBox ID="Tbx_Price" runat="server" ValidType="Float" Width="100px"></pc:PTextBox>
                <pc:PTextBox ID="Tbx_ProductsBarCode" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem,"ProductsBarCode") %>'></pc:PTextBox>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="数量"  HeaderStyle-Font-Size="12px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
                <pc:PTextBox ID="Tbx_Number" runat="server" ValidType="Int" Width="100px"></pc:PTextBox>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="备注"  HeaderStyle-Font-Size="12px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
                <pc:PTextBox ID="Tbx_Remarks" runat="server"  Width="100px"></pc:PTextBox>
          </ItemTemplate>
        </asp:TemplateField>
 
        </Columns>
            <HeaderStyle CssClass='Custom_DgHead' />
            <RowStyle CssClass='Custom_DgItem' />
            <AlternatingRowStyle BackColor="#E3EAF2" />
            <PagerStyle CssClass='Custom_DgPage' />
        </cc1:MyGridView>

<!--分页-->

<!--底部功能栏-->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="30" width="58%">&nbsp;<asp:Button ID="Button2" runat="server"  CssClass="Btt" Text="确定选择" OnClick="Button1_Click" style="width: 55px;height: 33px;"  /><input   name="button2"   type="button"   value="关闭窗口"  class="Btt"  onclick="closeWindow();"></td>
      <td width="42%" align="right" ></td>
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

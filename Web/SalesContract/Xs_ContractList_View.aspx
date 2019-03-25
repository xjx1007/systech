<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Xs_ContractList_View.aspx.cs" Inherits="Web_Sales_Xs_ContractList_View" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css" />
    <title>合同评审情况</title>
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
</head>
<body>
<div class="TitleBar">合同评审情况</div>

    <form id="form1" runat="server">
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss_add">
 <tr>
        <td width="17%" height="25" align="right"  class="tableBotcss">合同编号：</td>
        <td width="36%" align="left" class="tableBotcss"><asp:Label ID="ContractNo" runat="server"></asp:Label></td>
         <td align="right" class="tableBotcss">签订日期：</td>
        <td align="left" class="tableBotcss"><asp:Label ID="ContractDateTime" runat="server"></asp:Label></td>
  </tr>
      
      
 <tr >
    <td width="17%" height="25" align="right" class="tableBotcss">客户:</td>
    <td align="left" class="tableBotcss" >
    <asp:Label ID="CustomerName" runat="server"></asp:Label></td>
    <td width="17%" height="25" align="right" class="tableBotcss">责任人:</td>
    <td align="left" class="tableBotcss" >
    <asp:Label ID="Lbl_DutyPerson" runat="server"></asp:Label></td>
   </tr>


  <tr>
    <td width="17%" align="right" class="tableBotcss" style="height: 33px">
        地址:</td>
    <td width="36%" align="left" class="tableBotcss" style="height: 33px"><asp:Label ID="ContractToAddress" runat="server"></asp:Label></td>
    <td width="14%" align="right" class="tableBotcss" style="height: 33px">交货方式:</td>
    <td width="33%" align="left" class="tableBotcss" style="height: 33px"><asp:Label ID="ContractDeliveMethods" runat="server"></asp:Label></td>
 </tr>
 
  <tr>
    <td width="17%" align="right" class="tableBotcss" style="height: 33px">
        联系人:</td>
    <td width="36%" align="left" class="tableBotcss" style="height: 33px"><asp:Label ID="Tbx_ContentPerson" runat="server"></asp:Label></td>
    <td width="14%" align="right" class="tableBotcss" style="height: 33px">电话:</td>
    <td width="33%" align="left" class="tableBotcss" style="height: 33px"><asp:Label ID="Tbx_Telephone" runat="server"></asp:Label></td>
 </tr>
<tr  >
  <td width="17%" height="25" align="right" class="tableBotcss">开始日期:</td>
  <td width="36%" align="left" class="tableBotcss"><asp:Label ID="ContractStarDateTime" runat="server"></asp:Label></td>
    <td width="14%" align="right" class="tableBotcss" style="height: 33px">交货日期:</td>
    <td width="33%" align="left" class="tableBotcss" style="height: 33px"><asp:Label ID="ContractToDeliDate" runat="server"></asp:Label></td>
</tr>
 
 <tr >
    <td width="14%" align="right" class="tableBotcss">合同分类:</td>
    <td width="33%" align="left" class="tableBotcss"><asp:Label ID="ContractClass" runat="server"></asp:Label></td>
    <td width="14%" align="right" class="tableBotcss" style="color: #000000; height: 33px;">付款方式:</td>
    <td width="33%" align="left" class="tableBotcss" style="height: 33px"><asp:Label ID="Drop_Payment" runat="server"></asp:Label>&nbsp;</td>
    
 </tr>
 <tr>
   
    <td width="14%" align="right" class="tableBotcss" style="height: 33px">运输方式:</td>
    <td width="33%" align="left" class="tableBotcss" style="height: 33px" colspan="3">常规：<asp:Label ID="Drop_RoutineTransport" runat="server"></asp:Label>
    应急：<asp:Label ID="Drop_WorryTransport" runat="server"></asp:Label></td>
 </tr>
 
 
<tr >
     <td width="14%" align="right" class="tableBotcss">结算方式:</td>
    <td width="33%" align="left" class="tableBotcss" <asp:Label ID="ContractToPayment" runat="server"></asp:Label>&nbsp;</td>
     <td width="14%" align="right" class="tableBotcss">生产交货期:</td>
    <td width="33%" align="left" class="tableBotcss" <asp:Label ID="KFC_ReDate" runat="server"></asp:Label>&nbsp;</td>
 </tr>

<tr>
     <td width="14%" align="right" class="tableBotcss">发货说明:</td>
    <td width="33%" align="left" class="tableBotcss"><asp:Label runat="server" ID="Lbl_ContractShip" ></asp:Label>&nbsp;</td>

     <td width="14%" align="right" class="tableBotcss">图片:</td>
    <td width="33%" align="left" class="tableBotcss"><asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" Visible="false"><asp:Image ID="Image1" runat="server" Width="28" Height="24" Visible="false" /></asp:HyperLink>&nbsp;</td>


</tr>
<tr>
        <td align="right" class="tableBotcss" style="height: 30px">技术要求:</td>
        <td align="left" valign="top" class="tableBotcss" style="height: 30px"><asp:Label ID="Tbx_TechnicalRequire"  runat="server"  ></asp:Label>&nbsp;</td>

        <td align="right" class="tableBotcss" style="height: 30px">产品包装:</td>
        <td  align="left" valign="top" class="tableBotcss" style="height: 30px"><asp:Label ID="Tbx_ProductPackaging"  runat="server"  ></asp:Label>&nbsp;</td>
</tr>
 
<tr>
        <td height="37" align="right" class="tableBotcss">质量要求:</td>
        <td align="left" valign="top" class="tableBotcss"><asp:Label ID="Tbx_QualityRequire"  runat="server"  ></asp:Label>&nbsp;</td>

        <td align="right" class="tableBotcss" style="height: 30px">质保期:</td>
        <td  align="left" valign="top" class="tableBotcss" style="height: 30px"><asp:Label ID="Tbx_WarrantyPeriod"  runat="server"  ></asp:Label>&nbsp;</td>
</tr>
<tr >
        <td height="37" align="right" class="tableBotcss">备货要求:</td>
        <td align="left" valign="top" class="tableBotcss"><asp:Label ID="Tbx_DeliveryRequire"  runat="server"  ></asp:Label>&nbsp;</td>

        <td height="37" align="right" class="tableBotcss">备注说明:</td>
        <td  align="left" valign="top" class="tableBotcss"><asp:Label ID="ContractRemarks"  runat="server"  ></asp:Label>&nbsp;</td>
        
</tr>

<tr >
        <td height="37" align="right" class="tableBotcss">采购单号:</td>
        <td align="left" valign="top" class="tableBotcss"><asp:Label ID="OrderNo"  runat="server"  ></asp:Label>&nbsp;</td>
        <td height="37" align="right" class="tableBotcss">发货通知单号:</td>
        <td align="left" valign="top" class="tableBotcss"><asp:Label ID="ShipNo"  runat="server"  ></asp:Label>&nbsp;</td>

</tr>

<tr >
        <td height="37" align="right" class="tableBotcss">出库单号:</td>
        <td align="left" valign="top" class="tableBotcss" colspan="3"><asp:Label ID="DirectNo"  runat="server"  ></asp:Label>&nbsp;</td>

</tr>
<tr >
        <td height="37" align="right" class="tableBotcss">仓库:</td>
        <td align="left" valign="top" class="tableBotcss"><asp:Label ID="Lbl_House"  runat="server"  ></asp:Label></td>

        <td height="37" align="right" class="tableBotcss">供应商:</td>
        <td  align="left" valign="top" class="tableBotcss"><asp:Label ID="Lbl_Supplier"  runat="server"  ></asp:Label></td>
        
</tr>
</table>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss_add">
<tr>
<td >
    <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%" ButtonCssClass="" DeleteControlID="" EmptyTemplateCssClass="GridViewHeader" HeaderHorizontalalign="NotSet" HeaderVerticalalign="NotSet" IsDataBind="True" IsRecordDataSource="False" IsShowEmptyTemplate="True" IsShowPageControl="True" IsShowPageRecord="True" IsShowPageRedirect="True" KeyField="" ModifyControlID="" ModifyUrl="" NavigateMode="Self" PagePosition="1" PagerHorizontalalign="NotSet" PagerVerticalalign="NotSet" PageShowCount="5" QueryString="" RefreshControlNames="" RowHorizontalalign="NotSet" RowShowCount="10" RowVerticalalign="NotSet" SelectControlID="" SelectUrl="" TextBoxCssClass="GridViewTextBox" Title="" PageIndex="1">
        <HeaderStyle CssClass='Custom_DgHead' />
        <RowStyle CssClass='Custom_DgItem' />
        <AlternatingRowStyle BackColor="#E3EAF2" />
        <PagerStyle CssClass='Custom_DgPage' />
<Columns>
            <asp:BoundField HeaderText="产品名称" DataField="ProductsName"  />
            <asp:BoundField HeaderText="产品型号" DataField="productsPattern"  />
            <asp:TemplateField HeaderText="版本">    
                <ItemTemplate>
                    <%#base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="合同数量" DataField="ContractAmount"   />
            <asp:BoundField HeaderText="备货数量" DataField="KSC_BNumber"   />
            <asp:BoundField HeaderText="合同单价" DataField="Contract_SalesUnitPrice" />
            <asp:BoundField HeaderText="金额" DataField="Contract_SalesTotalNet" />
            <asp:TemplateField HeaderText="采购数量">    
                <ItemTemplate>
                    <%#GetCgNumer(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="入库数量">    
                <ItemTemplate>
                    <%#GetRkNumber(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="通知发货数量">    
                <ItemTemplate>
                    <%#GetFHNumber(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
</Columns>
</cc1:MyGridView>

</td>
</tr>
<tr><td> <asp:GridView ID="GridView1" Width="99%" runat="server"  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px" >
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
        
      <asp:TemplateField HeaderText="审核状态"  SortExpression="KSF_State" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetFlowName(DataBinder.Eval(Container.DataItem, "KSF_State").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
         <asp:BoundField  HeaderText="审核意见"  DataField="KSF_Detail"  ItemStyle-Width="115px"  SortExpression="KSF_Detail" >
            <ItemStyle HorizontalAlign="center"   Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="center" Font-Size="12px"  />
        </asp:BoundField>
        </Columns>
                 <HeaderStyle CssClass='Custom_DgHead' />
        <RowStyle CssClass='Custom_DgItem' />
        <AlternatingRowStyle BackColor="#E3EAF2" />
        <PagerStyle CssClass='Custom_DgPage' />
        </asp:GridView>
        </td></tr>
            
<tr><td> 


<asp:GridView ID="GridView2" Width="99%" runat="server"  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px" >
        <Columns>
        
        
      <asp:TemplateField HeaderText="查看人"  SortExpression="XCV_Person" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "XCV_Person").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField  HeaderText="查看时间"  DataField="XCV_Time"  ItemStyle-Width="70px"  SortExpression="XCV_Time" >
            <ItemStyle HorizontalAlign="center"   Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="center" Font-Size="12px"  />
        </asp:BoundField>
        
        </Columns>
                 <HeaderStyle CssClass='Custom_DgHead' />
        <RowStyle CssClass='Custom_DgItem' />
        <AlternatingRowStyle BackColor="#E3EAF2" />
        <PagerStyle CssClass='Custom_DgPage' />
        </asp:GridView>
        </td></tr>
</table>
    </form>
    
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContractListCheckDetail.aspx.cs" Inherits="Knet_Web_Sales_pop_ContractListCheckYN" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../../css/knetwork.css" type="text/css">
<title>合同进展操作--审核</title>
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

<table width="100%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">合同审核</div></td>
    <td  background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;</td>
    <td width="216" background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="center">&nbsp;</td>
  </tr>
</table>
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
           <td height="30" colspan="2" align="left" >
           
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
    <td width="33%" align="left" class="tableBotcss" colspan="3"><asp:Label ID="ContractToPayment" runat="server"></asp:Label>&nbsp;</td>
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
        <td align="left" valign="top" class="tableBotcss" colspan="3"><asp:Label ID="OrderNo"  runat="server"  ></asp:Label>&nbsp;</td>

        
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
            <asp:BoundField HeaderText="产品版本号" DataField="ProductsEdition"  />
            <asp:BoundField HeaderText="合同数量" DataField="ContractAmount"   />
            <asp:BoundField HeaderText="合同单价" DataField="Contract_SalesUnitPrice" />
            <asp:BoundField HeaderText="金额" DataField="Contract_SalesTotalNet" />
            
</Columns>
</cc1:MyGridView>

</td>
</tr>
</table>
           </td>
      </tr>
       <tr>
           <td height="30" colspan="2" align="left" >
                  <asp:GridView ID="GridView1" Width="99%" runat="server"  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px" >
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
        
         <asp:BoundField  HeaderText="交货期"  DataField="KFS_ReDate"  ItemStyle-Width="115px" DataFormatString="{0:yyyy-MM-dd}"  SortExpression="KFS_ReDate" >
            <ItemStyle HorizontalAlign="center"   Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="center" Font-Size="12px"  />
        </asp:BoundField>
        </Columns>
                 <HeaderStyle CssClass='Custom_DgHead' />
        <RowStyle CssClass='Custom_DgItem' />
        <AlternatingRowStyle BackColor="#E3EAF2" />
        <PagerStyle CssClass='Custom_DgPage' />
        </asp:GridView>
           </td>
      </tr>
</table> 


<!--底部功能栏-->
<table width="100%" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td height="30" >&nbsp;<asp:Button ID="Button1" runat="server" Text="重新提交" CssClass="Btt" OnClick="Button1_Click" style="width: 55px;height: 33px;"  /></td>
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

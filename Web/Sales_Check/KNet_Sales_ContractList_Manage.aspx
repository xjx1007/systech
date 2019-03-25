<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"  CodeFile="KNet_Sales_ContractList_Manage.aspx.cs" Inherits="Knet_Web_Sales_KNet_Sales_ContractList_Manage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
<title></title>
</head>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../js/Global.js"></script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
<div id="ssdd" style="padding:1px"></div>
 <div class="TitleBar">合同执行情况表</div>
<div id="Div1" style="padding:1px"></div>




<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
    
        <br />
        <table width="70%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss_Select">
            <tr>
                <td class="tableBotcss" width="15%" style="height: 30px; text-align: right">发货日期：</td>
                <td class="tableBotcss1" width="35%" style="height: 30px; text-align: left" colspan="3"><asp:TextBox ID="StartDate"  runat="server" CssClass="Wdate"  onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})"  ></asp:TextBox>   到   <asp:TextBox ID="EndDate" runat="server"  CssClass="Wdate"   onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})" ></asp:TextBox></td>
            
            </tr>
            <tr>
                <td class="tableBotcss" width="15%" style="height: 30px; text-align: right">客户名称：</td>
                <td class="tableBotcss" width="35%" style="height: 30px; text-align: left">
                    <asp:TextBox ID="Tbx_CustomerName" runat="server" CssClass="Boxx" Width="150px"></asp:TextBox></td>
                <td class="tableBotcss" width="15%" style="height: 30px; text-align: right">合同分类：</td>
                <td class="tableBotcss1" width="35%" style="height: 30px; text-align: left">
                    <asp:DropDownList runat="server" ID="Drop_Type"></asp:DropDownList></td>
            </tr>
            
            <tr>
                <td class="tableBotcss" width="15%" style="height: 30px; text-align: right">状态：</td>
                <td class="tableBotcss" width="35%" style="height: 30px; text-align: left">
                <asp:DropDownList ID="Ddl_State" runat="server">
                <asp:ListItem Text="未完全出库" Value="5"></asp:ListItem>
                <asp:ListItem Text="--请选择--" Value=""></asp:ListItem>
                <asp:ListItem Text="已采购" Value="0"></asp:ListItem>
                <asp:ListItem Text="未采购" Value="1"></asp:ListItem>
                <asp:ListItem Text="已发货通知" Value="2"></asp:ListItem>
                <asp:ListItem Text="未完全发货通知" Value="3"></asp:ListItem>
                <asp:ListItem Text="已出库" Value="4"></asp:ListItem>
                </asp:DropDownList></td>
    <td width="17%" align="right" class="tableBotcss" style="height: 33px">责任人:</td>
    <td align="left" class="tableBotcss" style="height: 33px">
    <asp:DropDownList runat="Server" ID="Ddl_DutyPerson"></asp:DropDownList></td>
            </tr>
        </table>
        <br />
        
    <div align="center">           
        <asp:Button ID="Btn_Query" runat="server" Text="查 询" CssClass="Custom_Button" OnClick="Button4_Click" Height="23px" Width="57px"></asp:Button>&nbsp;
         <asp:Button ID="Btn_Modiy" runat="server" Text="修 改" CssClass="Custom_Button"  Height="23px" OnClick="Btn_Modiy_Click" Width="57px"></asp:Button>&nbsp;
        
         <asp:Button ID="Btn_Save" runat="server" Text="保 存" CssClass="Custom_Button"  Height="23px" OnClick="Btn_Save_Click" Width="57px"></asp:Button>&nbsp;
          <input class="Custom_Button" id="Btn_Reset" onclick="PageGo('KNet_Sales_ContractList_Manage.aspx')" type="button" value="复 位"  style="width: 57px; height: 23px" />  
    </div>
        <hr width="720">
<!--GridView-->
          <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" IsShowEmptyTemplate="true"
            AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="10" Width="100%"  >
        <Columns>
        <asp:TemplateField HeaderText="合同编号"  SortExpression="ContractNo" HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <a href="#"  onclick="javascript:window.open('../Sales/Xs_ContractList_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ContractNo")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# DataBinder.Eval(Container.DataItem, "ContractNo").ToString()%></a>
          
          <asp:TextBox ID="Tbx_ContractNo" runat="server"  CssClass="Custom_Hidden"
           Text=<%# DataBinder.Eval(Container.DataItem, "ContractNo").ToString()%> ></asp:TextBox>

          </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="交货日期"  SortExpression="ContractToDeliDate" HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
          <asp:TextBox ID="Tbx_NeedDate" runat="server"  Width="70"  Visible=false
          onFocus="WdatePicker()"  Text=<%# GetShipDate(DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%> ></asp:TextBox>
          <asp:Label ID="Lbl_NeedDate" runat="server"  Width="70" Text=<%# GetShipDate(DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%> ></asp:Label>
          <asp:TextBox ID="Tbx_OldDate" runat="server"  CssClass="Custom_Hidden"
          onFocus="WdatePicker()"  Text=<%# GetShipDate(DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%> ></asp:TextBox>
          

          <%# GetShipDateURL(DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>

        
        <asp:TemplateField HeaderText="生产交货期"  SortExpression="KFC_ReDate" HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
          <asp:TextBox ID="Tbx_NeedReDate" runat="server"  Width="70"   Visible=false
          onFocus="WdatePicker()"  Text=<%# DataBinder.Eval(Container.DataItem, "KFC_ReDate").ToString()%> ></asp:TextBox>
           <asp:Label ID="Lbl_NeedReDate" runat="server"  Width="70" Text=<%# DataBinder.Eval(Container.DataItem, "KFC_ReDate").ToString()==""?"":DateTime.Parse(DataBinder.Eval(Container.DataItem, "KFC_ReDate").ToString()).ToShortDateString()%> ></asp:Label>
         
          <asp:TextBox ID="Tbx_OldReDate" runat="server"  CssClass="Custom_Hidden"
          onFocus="WdatePicker()"  Text=<%# DataBinder.Eval(Container.DataItem, "KFC_ReDate").ToString()%> ></asp:TextBox>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="客户名称"  SortExpression="CustomerValue" HeaderStyle-Font-Size="12px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <a href="#"  onclick="javascript:window.open('../Sales/KNet_Sales_ClientList_Details.aspx?CustomerValue=<%# DataBinder.Eval(Container.DataItem, "CustomerValue")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# base.Base_GetCustomerName(DataBinder.Eval(Container.DataItem, "CustomerValue").ToString())%></a>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="责任人"  SortExpression="ContractStaffNo" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "DutyPerson").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="合同分类"  SortExpression="ContractClass" HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetKClaaName(DataBinder.Eval(Container.DataItem, "ContractClass").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="版本号"  SortExpression="ProductsBarCode" HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="合同数量"  SortExpression="OrderStaffBranch" HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# DataBinder.Eval(Container.DataItem, "ContractAmount").ToString()%>
          </ItemTemplate>
        </asp:TemplateField>
        
          <asp:TemplateField HeaderText="采购数量">    
                <ItemTemplate>
                    <%#GetCgNumer(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString(), DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="入库数量">    
                <ItemTemplate>
                    <%#GetRkNumber(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString(), DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="发货数量">    
                <ItemTemplate>
                    <%#GetFHNumber(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString(), DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="出库数量">    
                <ItemTemplate>
                    <%#GetCkNumber(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString(), DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
        <asp:TemplateField HeaderText="查看" HeaderStyle-Font-Size="12px"  ItemStyle-Width="28px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
             <a href="#"  onclick="javascript:window.open('../Sales/KNet_Sales_ContractList_Manage_PrinterListSettingPrinterPage.aspx?ContractNo=<%# DataBinder.Eval(Container.DataItem, "ContractNo")%>&PrinterModel=128898695453437500','查看详细','top=120,left=150,menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');"><asp:Image ID="Image2" runat="server"  ImageUrl="../../images/View.gif" border=0  ToolTip="查看合同详细信息" /></a>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="状态"  SortExpression="ContractCheckYN" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.GetContractState(DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
 
        </Columns>
         <HeaderStyle CssClass='Custom_DgHead' />
        <RowStyle CssClass='Custom_DgItem' />
        <AlternatingRowStyle BackColor="#E3EAF2" />
        <PagerStyle CssClass='Custom_DgPage' />
        </cc1:MyGridView>
<!--GridView-->  
<!--分页-->

<!--底部功能栏-->

    </td>
  </tr>
</table>


    </form>
</body>
</html>

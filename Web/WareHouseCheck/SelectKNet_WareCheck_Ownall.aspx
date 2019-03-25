<%@ Page Language="C#" AutoEventWireup="true"   CodeFile="SelectKNet_WareCheck_Ownall.aspx.cs" Inherits="Knet_Common_SelectKNet_WareCheck_Ownall" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css" />
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
<script>   
  function closeWindow()   
  {   
  window.opener=null;   
  window.close();   
  }  
</script> 
<title>选择仓库产品</title>
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
<script type="text/javascript" src="../js/ajax_func.js"></script>
<script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
	<script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
	<script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
	<script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
	<script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
</head>
<base target="_self" />
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>
<!--头部-->
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                仓库 > <a class="hdrLink" href="SelectProduct.aspx">选择仓库产品</a>
            </td>
            <td width="100%" nowrap>
                <table border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="sep1" style="width: 1px;">
                        </td>
                        <td class="small">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
    </table>
<!--头部-->


<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
            <td width="14%" valign="top">
                <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                    <tr>
                        <td class="dvtTabCache" style="width: 10px" nowrap>
                            &nbsp;
                        </td>
                        <td id="catalog_tab" class="dvtSelectedCell" align="center" nowrap>
                            <a href="javascript:showProductCatalog()">产品分类</a>
                        </td>
                        <td class="dvtTabCache" style="width: 100%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" 
                                NodeIndent="15" onselectednodechanged="TreeView1_SelectedNodeChanged">
                                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" 
                                    HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                                <ParentNodeStyle Font-Bold="False" />
                                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" 
                                    HorizontalPadding="0px" VerticalPadding="0px" />
                            </asp:TreeView>
                        </td>
                    </tr>
                </table>
            </td>
    <td width="85%" align="left" valign="top" style="border-left: 2px dashed #cccccc;">
                      
<!--GridView-->
        <cc1:MyGridView ID="GridView1" runat="server"  AllowSorting="True" AllowPaging="true"  PageSize="10"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px"
           >
        <Columns>
        
        
       <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <HeaderTemplate >
             
                 <input type="CheckBox" onclick="selectAll(this)">
                    </HeaderTemplate>
                 <ItemTemplate>
                     <asp:CheckBox ID="Chbk" runat="server"  />
                 </ItemTemplate>
        </asp:TemplateField>
        
         <asp:TemplateField HeaderText="仓库名称"  SortExpression="HouseNo"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetHouseName(DataBinder.Eval(Container.DataItem, "HouseNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
        <asp:BoundField  DataField="KSP_Code"   HeaderText="料号"  SortExpression="KSP_Code">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
         <asp:TemplateField HeaderText="产品名称"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetProdutsName(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="版本号"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
         <asp:TemplateField HeaderText="单位"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetUnitsName(base.Base_GetProductsUnits(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString()))%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="现库存" HeaderStyle-Font-Size="12px" HeaderStyle-ForeColor="blue"   ControlStyle-Width="50px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
                <asp:TextBox ID="Tbx_Number" runat="server" MaxLength="9" CssClass="Boxx" Text=<%#DataBinder.Eval(Container.DataItem, "WareHouseAmount").ToString() %>></asp:TextBox>
                <asp:TextBox ID="Tbx_WareHouseAmount" runat="server" MaxLength="9" CssClass="Custom_Hidden" Width="40px" Text=<%#DataBinder.Eval(Container.DataItem, "WareHouseAmount").ToString() %>></asp:TextBox>
               </ItemTemplate>
      </asp:TemplateField>
      
         <asp:TemplateField HeaderText="库存量"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"  SortExpression="WareHouseAmount" >
          <ItemTemplate>
               <%# base.FormatNumber1(DataBinder.Eval(Container.DataItem, "WareHouseAmount").ToString(),0)%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="单价" HeaderStyle-Font-Size="12px" HeaderStyle-ForeColor="blue"   ControlStyle-Width="50px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
                <asp:TextBox ID="Tbx_Price" runat="server" MaxLength="9" CssClass="Boxx" Width="40px" Text=<%#base.Base_GetProductsPrice(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString(),DataBinder.Eval(Container.DataItem, "HouseNo").ToString()) %>></asp:TextBox>
               </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="金额" HeaderStyle-Font-Size="12px" HeaderStyle-ForeColor="blue"   ControlStyle-Width="50px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
                <asp:TextBox ID="Tbx_Money" runat="server" MaxLength="9" CssClass="Boxx" Width="40px" Text=<%#DataBinder.Eval(Container.DataItem, "Money").ToString() %>></asp:TextBox>
               </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="备注" HeaderStyle-Font-Size="12px" HeaderStyle-ForeColor="blue"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
                <asp:TextBox ID="Tbx_Remark" runat="server" MaxLength="9" CssClass="Boxx"  Width="40px"></asp:TextBox>
                <asp:TextBox ID="Tbx_ProductsBarCode" runat="server" CssClass="Custom_Hidden"  Text=<%#DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString() %>></asp:TextBox>

               </ItemTemplate>
      </asp:TemplateField>
        </Columns>
         
         <HeaderStyle CssClass='colHeader' />
         <RowStyle CssClass='listTableRow' />
            <AlternatingRowStyle BackColor="#E3EAF2" />
            <PagerStyle CssClass='Custom_DgPage' />
        </cc1:MyGridView>
<!--GridView-->  
<!--分页-->

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="25" width="40%"><asp:Button ID="Button2" runat="server"   cssclass="crmbutton small save"  Text="确定选择" OnClick="Button2_Click" /><input   name="button2"   type="button"   value="关闭窗口" class="crmbutton small cancel"  onclick="closeWindow();"></td>
      <td width="60%" align="right" ><B>库存产品搜索</B>&nbsp;&nbsp;关健词:<asp:TextBox ID="KNetSeachKey" runat="server" Width="150px" CssClass="Boxx"></asp:TextBox>&nbsp;&nbsp;<asp:Button  ID="Button1" runat="server" Text="确定搜索" CssClass="Btt" OnClick="Button1_Click" style="width: 55px;height: 33px;"  /></td></tr>
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

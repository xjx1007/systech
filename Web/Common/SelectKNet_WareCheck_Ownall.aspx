<%@ Page Language="C#" AutoEventWireup="true"   CodeFile="SelectKNet_WareCheck_Ownall.aspx.cs" Inherits="Knet_Common_SelectKNet_WareCheck_Ownall" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css" />
<script>   
  function closeWindow()   
  {   
  window.opener=null;   
  window.close();   
  }  
</script> 
<title>选择仓库产品</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>
<!--头部-->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">选择仓库产品</div></td>
    <td  align="left"  background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;&nbsp;<font color="blue">提示:</font><font color="#999999">选择产品后，点确定添加到明细中.</font></td>
    <td width="10" background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="left"></td>
  </tr>
</table>
<div id="ssdd" style="padding:3px"></div>
<!--头部-->


<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
<!--GridView-->
        <asp:GridView ID="GridView1" runat="server"  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px"
          OnSorting="GridView1_Sorting"  OnRowDataBound="GridView1_DataRowBinding" >
        <Columns>
        

        <asp:BoundField   HeaderText="序"  ItemStyle-Height="25px" ItemStyle-Width="25px"  HeaderStyle-Font-Size="12px"  HeaderStyle-HorizontalAlign="Left"  >
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        
        
       <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <HeaderTemplate >
                 <asp:CheckBox ID="CheckBox1" runat="server" Text="选"  Font-Size="12px" AutoPostBack="true"   OnCheckedChanged="CheckBox1_CheckedChanged"  Height="20px" />
                 </HeaderTemplate>
                 <ItemTemplate>
                     <asp:CheckBox ID="Chbk" runat="server"  /><a href="#"  onclick="javascript:window.open('../KnetProductsSetting_Details.aspx?BarCode=<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><asp:Image ID="Image1" runat="server"  ImageUrl="../../images/Deitail.gif"  ToolTip="查看产品详细信息" /></a>
                 </ItemTemplate>
        </asp:TemplateField>
        
         <asp:TemplateField HeaderText="仓库名称"  SortExpression="HouseNo"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetHouseName(DataBinder.Eval(Container.DataItem, "HouseNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
        <asp:BoundField  DataField="ProductsBarCode"   HeaderText="编号(条码)"  SortExpression="ProductsBarCode">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px"  Width="110px"/>
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
         <asp:TemplateField HeaderText="产品型号"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetProductsPattern(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="版本号"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
         <asp:TemplateField HeaderText="单位"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetProductsUnits(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
        
      <asp:TemplateField HeaderText="类型"  SortExpression="WareHousePack"  HeaderStyle-Font-Size="12px"  ItemStyle-Width="55px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" >
          <ItemTemplate>
              <asp:DropDownList ID="WareHousePack" CssClass="Boxx" runat="server" Width="55px">
               <asp:ListItem Value="1">盘正</asp:ListItem>
               <asp:ListItem Value="2">盘负</asp:ListItem>
               </asp:DropDownList>
          </ItemTemplate>
      </asp:TemplateField>   
      
        
      <asp:TemplateField HeaderText="差异数" SortExpression="WareHouseAmount" HeaderStyle-Font-Size="12px" HeaderStyle-ForeColor="blue"   ControlStyle-Width="50px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
                <asp:TextBox ID="OrderAmounttxt" runat="server" MaxLength="9" CssClass="Boxx" Width="40px" Text="0"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="JoinNumbera"  runat="server" ErrorMessage="非空!" ControlToValidate="OrderAmounttxt" Display="Dynamic" ValidationGroup="88"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="JoinNumberbb" runat="server" ErrorMessage="整数!" ControlToValidate="OrderAmounttxt" ValidationExpression="^\+?[0-9][0-9]*$" Display="Dynamic" ValidationGroup="88"></asp:RegularExpressionValidator>
          </ItemTemplate>
      </asp:TemplateField>
      
       <asp:BoundField  DataField="WareHouseAmount"   HeaderText="库存量"  SortExpression="WareHouseAmount" >
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px"  Width="50px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
       </asp:BoundField>

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
    showcustominfosection="Left" width="100%" meta:resourceKey="AspNetPager1" style="font-size:13px" PageIndexBoxStyle="width:18px;border-top:1px solid #A3B2CC;border-left:1px solid #A3B2CC;border-right:1px solid #A3B2CC;border-bottom:1px solid #A3B2CC;height:17px;"
    CustomInfoHTML="　当前页<font color='red'><b>%CurrentPageIndex%</b></font>共%PageCount%页，记录%StartRecordIndex%-%EndRecordIndex%" 
    ShowNavigationToolTip="True" CustomInfoStyle="font-size:13px;padding-top:0px;width:250px;" TextAfterPageIndexBox=" " SubmitButtonText="  转" SubmitButtonStyle="width:41px;height:21px;border: none;cursor:hand;background-image: url(../../images/go.gif)"  CustomInfoTextAlign="left"  ShowPageIndexBox="Never" AlwaysShow="True" 
    FirstPageText="【首页】" LastPageText="【尾页】" NextPageText="【下页】" PageSize="10" PrevPageText="【前页】">
    </webdiyer:aspnetpager>
    </td>
</tr>
</table>
<!--分页-->

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="25" width="40%"><asp:Button ID="Button2" runat="server"  CssClass="Btt" Text="确定选择" OnClick="Button2_Click" />
    <asp:Button  ID="Button3" runat="server" Text="取消选择" CssClass="Btt" OnClick="Button3_Click"/>&nbsp;<input   name="button2"   type="button"   value="关闭窗口"  class="Btt"  onclick="closeWindow();"></td>
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

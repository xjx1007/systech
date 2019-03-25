<%@ Page Language="C#" AutoEventWireup="true"   CodeFile="SelectProcureOpenBilling.aspx.cs" Inherits="Knet_Common_SelectProcureOpenBilling" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
     <link rel="alternate icon" type="image/png" href="../../images/士腾.png"/>
<script>   
  function closeWindow()   
  {   
  window.opener=null;   
  window.close();   
  }  
</script> 
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<title>选择采购单</title>
<base target="_self" />
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">采购单选择</div></td>
    <td  background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;日期从<asp:TextBox ID="StartDate" runat="server" CssClass="Wdate"  onFocus="var EndDate=$dp.$('EndDate');WdatePicker({maxDate:'#F{$dp.$D(\'EndDate\')}'})" ></asp:TextBox>&nbsp;到<asp:TextBox ID="EndDate" runat="server"  CssClass="Wdate"   onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})" ></asp:TextBox>&nbsp;关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="Boxx" Width="120px"></asp:TextBox></td>
    <td width="120" background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="left"><asp:Button
        ID="Button4" runat="server" Text="采购单检索"  CssClass="Btt" OnClick="Button4_Click"/></td>
  </tr>
</table>
<div id="ssdd" style="padding:1px"></div>
<!--头部-->
<%--内部开始--%>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
<!--GridView-->
        <asp:GridView ID="GridView1" runat="server"  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>暂没有找到相关可收货的采购记录，请先审核采购单.</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px"
          OnSorting="GridView1_Sorting"  OnRowDataBound="GridView1_DataRowBinding" >
        <Columns>
        

        <asp:BoundField   HeaderText="序"  ItemStyle-Height="25px" ItemStyle-Width="25px"  HeaderStyle-Font-Size="12px"  HeaderStyle-HorizontalAlign="Left"  >
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        
        
        <asp:TemplateField HeaderText="选择" HeaderStyle-Font-Size="12px" ItemStyle-Width="40px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <ItemTemplate>
                     <asp:CheckBox ID="Chbk" runat="server"  />
                 </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="采购单号"  SortExpression="OrderNo" HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <a href="#"  onclick="javascript:window.open('../Procure/Knet_Procure_OpenBilling_PrinterListSettingPrinterPage.aspx?OrderNo=<%# DataBinder.Eval(Container.DataItem, "OrderNo")%>&PrinterModel=128917825766562500','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# DataBinder.Eval(Container.DataItem, "OrderNo").ToString()%></a>
          </ItemTemplate>
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="合同编号"  SortExpression="ContractNo" HeaderStyle-Font-Size="12px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <a href="#"  onclick="javascript:window.open('../Sales/Xs_ContractList_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ContractNo")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# DataBinder.Eval(Container.DataItem, "ContractNo").ToString()%></a>
          </ItemTemplate>
        </asp:TemplateField>
        
        
         <asp:BoundField   HeaderText="采购日期"  DataField="OrderDateTime" ItemStyle-Width="70px"  SortExpression="OrderDateTime"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
        
        
        <asp:TemplateField HeaderText="采购类型"  SortExpression="OrderType" HeaderStyle-Font-Size="12px"  ItemStyle-Width="70px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetKNet_Sys_ProcureTypeNane(DataBinder.Eval(Container.DataItem, "OrderType"))%>
          </ItemTemplate>
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="供应商"  SortExpression="SuppNo" HeaderStyle-Font-Size="12px"  ItemStyle-Width="120px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetSuppNoName(DataBinder.Eval(Container.DataItem, "SuppNo"))%>
          </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="采购产品类型"  SortExpression="OrderStaffBranch" HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetOrderDetailProductsPatten(DataBinder.Eval(Container.DataItem, "OrderNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
        
      <asp:TemplateField HeaderText="经手人"  SortExpression="OrderStaffNo" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetStaffNameNane(DataBinder.Eval(Container.DataItem, "OrderStaffNo"))%>
          </ItemTemplate>
        </asp:TemplateField>

      <asp:TemplateField HeaderText="状态"  SortExpression="OrderState" HeaderStyle-Font-Size="12px"  ItemStyle-Width="45px"   ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# GetOrderStateYN(DataBinder.Eval(Container.DataItem, "OrderNo"))%>
          </ItemTemplate>
        </asp:TemplateField>
 
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

<!--底部功能栏-->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="30" width="58%">&nbsp;<asp:Button ID="Button2" runat="server"  CssClass="Btt" Text="确定选择" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />
    <asp:Button  ID="Button3" runat="server" Text="取消选择" CssClass="Btt" OnClick="Button2_Click"/>&nbsp;&nbsp;<input   name="button2"   type="button"   value="关闭窗口"  class="Btt"  onclick="closeWindow();"></td>
      <td width="42%" align="right" >&nbsp;</td>
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

<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"  CodeFile="Knet_Sales_Ship_Manage_Manage.aspx.cs" Inherits="Knet_Web_Sales_Knet_Sales_Ship_Manage_Manage" %>

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
<script type="text/javascript" src="../KDialog/lhgdialog.js"></script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
<div id="ssdd" style="padding:1px"></div>


 <div class="TitleBar">销售发货管理</div>
<div id="Div1" style="padding:1px"></div>




<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
<!--GridView-->


        <br />
        <table width="70%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss_Select">
            <tr>
                <td class="tableBotcss" width="15%" style="height: 30px; text-align: right">日期：</td>
                <td class="tableBotcss1" width="35%" style="height: 30px; text-align: left" colspan="3">
                <asp:TextBox ID="StartDate" runat="server" CssClass="Wdate"  onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})" ></asp:TextBox>&nbsp;到<asp:TextBox ID="EndDate" runat="server"  CssClass="Wdate"   onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})" ></asp:TextBox></td>
            </tr>
            <tr>
                 <td class="tableBotcss" width="15%" style="text-align: right">合同编号：</td>
                <td class="tableBotcss" width="35%" style="text-align: left"><asp:TextBox ID="Tbx_ContractNo" runat="server" CssClass="Boxx" Width="200px"></asp:TextBox></td>

                <td class="tableBotcss" width="15%" style="text-align: right">客户名称：</td>
                <td class="tableBotcss1" width="35%" style="text-align: left"><asp:TextBox ID="Tbx_Customer" runat="server" CssClass="Boxx" Width="200px"></asp:TextBox></td>
          </tr>
          
        </table>
        <br />
        
    <div align="center">           
        <asp:Button ID="Btn_Query" runat="server" Text="查 询" CssClass="Custom_Button" OnClick="Btn_Query_Click" Height="23px" Width="57px"></asp:Button>&nbsp;
        <asp:Button ID="Btn_Del" runat="server" Text="删 除" CssClass="Custom_Button"  Height="23px" Width="57px" OnClick="Btn_Del_Click"></asp:Button>&nbsp;
        <input id="Btn_All" type="button" class="Custom_Button" value="全 选" onclick="javascript:selectAllButton(this);"   style="width: 57px; height: 23px"/>&nbsp;
        <input class="Custom_Button" id="Btn_Reset" onclick="PageGo('Knet_Sales_Ship_Manage_Manage.aspx')" type="button" value="复 位"  style="width: 57px; height: 23px" />  
    </div>
        <hr width="720">
        <cc1:MyGridView ID="GridView1" runat="server"  AllowSorting="True"  IsShowEmptyTemplate="true"  AllowPaging="True" 
        EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px"
            OnRowDataBound="GridView1_DataRowBinding" >
        <Columns>
        
        
        <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <HeaderTemplate>
                    <input type="CheckBox" onclick="selectAll(this)"/>
                 </HeaderTemplate>
                 <ItemTemplate>
                     <asp:CheckBox ID="Chbk" runat="server"  />
                        <asp:TextBox  runat="server" id="ContractNo" cssClass="Custom_Hidden" Text=<%# DataBinder.Eval(Container.DataItem, "ContractNo")%>> </asp:TextBox>
                 </ItemTemplate>
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="发货单号"  SortExpression="OutWareNo" HeaderStyle-Font-Size="12px"  ItemStyle-Width="28px"   ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
             <a href="#"  onclick="javascript:window.open('Knet_Sales_Ship_Manage_PrinterListSettingPrinterPage.aspx?OutWareNo=<%# DataBinder.Eval(Container.DataItem, "OutWareNo")%>&PrinterModel=128900331899375000','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# DataBinder.Eval(Container.DataItem, "OutWareNo").ToString()%></a>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="合同编号"  SortExpression="ContractNo" HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <a href="#"  onclick="javascript:window.open('Xs_ContractList_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ContractNo")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# DataBinder.Eval(Container.DataItem, "ContractNo").ToString()%></a>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField   HeaderText="发货日期"  DataField="OutWareDateTime" ItemStyle-Width="80px"  SortExpression="OutWareDateTime"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
         <asp:BoundField   HeaderText="预计到货日期"  DataField="KSO_PlanOutWareDateTime" ItemStyle-Width="80px"  SortExpression="KSO_PlanOutWareDateTime"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
        
        <asp:TemplateField HeaderText="客户名称"  SortExpression="CustomerValue" HeaderStyle-Font-Size="12px"  ItemStyle-Width="180px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
                <a href="#"  onclick="javascript:window.open('KNet_Sales_ClientList_Details.aspx?CustomerValue=<%# DataBinder.Eval(Container.DataItem, "CustomerValue")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# base.Base_GetCustomerName(DataBinder.Eval(Container.DataItem, "CustomerValue").ToString())%></a>
          </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="发货跟踪情况"  HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate> 
        
           <%# GetOutWareListfollowup(DataBinder.Eval(Container.DataItem, "OutWareNo"))%>
          </ItemTemplate>
        </asp:TemplateField>
        

        <asp:TemplateField HeaderText="状态"  HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
           <%# GetKDSateName(DataBinder.Eval(Container.DataItem, "OutWareNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="查看"  HeaderStyle-Font-Size="12px"  ItemStyle-Width="28px"   ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
             <a href="#"  onclick="javascript:window.open('Knet_Sales_Ship_Manage_PrinterListSettingPrinterPage.aspx?OutWareNo=<%# DataBinder.Eval(Container.DataItem, "OutWareNo")%>&PrinterModel=128900331899375001','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><asp:Image ID="Image3" runat="server"  ImageUrl="../../images/View.gif" border=0  ToolTip="查看发货详细信息" /></a>
          </ItemTemplate>
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="修改" HeaderStyle-Font-Size="12px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                 <%# GetUpdate(DataBinder.Eval(Container.DataItem, "OutWareNo").ToString(), DataBinder.Eval(Container.DataItem, "OutWareStaffNo").ToString())%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="审核意见" HeaderStyle-Font-Size="12px"  ItemStyle-Width="28px"   ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
             <a href="#"  onclick="javascript:window.open('pop/Knet_Sales_ShipCheckDetail.aspx?OutWareNo=<%# DataBinder.Eval(Container.DataItem, "OutWareNo")%>','查看审核意见','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><asp:Image ID="Image4" runat="server"  ImageUrl="../../images/View.gif" border=0  ToolTip="查看发货详细信息" /></a>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="审核"  SortExpression="OutWareCheckYN" HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# GetBaoPriceCheckYN(DataBinder.Eval(Container.DataItem, "OutWareNo"))%>
          </ItemTemplate>
        </asp:TemplateField>
        </Columns>
            <HeaderStyle CssClass='Custom_DgHead' />
            <RowStyle CssClass='Custom_DgItem' />
            <AlternatingRowStyle BackColor="#E3EAF2" />
            <PagerStyle CssClass='Custom_DgPage' />
        </cc1:MyGridView>

    </td>
  </tr>
</table>


    </form>
</body>
</html>

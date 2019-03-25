<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectBaoPriceList.aspx.cs" Inherits="Knet_Common_SelectBaoPriceListSelectBaoPriceListtoselects" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
     <link rel="alternate icon" type="image/png" href="../../images/士腾.png"/>
    <script type="text/javascript" src="../js/ajax_func.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
<base target="_self" />
<script>   
  function closeWindow()   
  {   
  window.opener=null;   
  window.close();   
  }  
</script>

<title>选择报价</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div>
        
        <table border="0" cellspacing="0" cellpadding="0" class="small" align="center" >
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>销售 >
	<a class="hdrLink" href="SelectBaoPriceList.aspx">选择报价单</a>
                </td>
                <td width="100%" nowrap>
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="sep1" style="width: 1px;"></td>
                            <td class="small">
                                <!-- Add and Search -->
                                <table border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 2px"></td>
            </tr>
        </table>

            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="small">
                <tr>
                    <td>
                        
            关健词:<asp:TextBox ID="SeachKey" runat="server" Width="200px" CssClass="detailedViewTextBox"></asp:TextBox>
            <asp:Button ID="Button1zzz" runat="server" Text="检索" CssClass="crmButton save" OnClick="Button4_Click"  Width="81px"  Height="27px" />
            
                        </td>
                    </tr>
                <tr>
                    <td>
                        <!--GridView-->
                    <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="true" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>" GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="25px"
                             >
                            <Columns>
                                <asp:TemplateField HeaderText="选择" HeaderStyle-Font-Size="12px" ItemStyle-Width="40px"
                                    ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chbk" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="BaoPriceTopic" HeaderText="报价主题" SortExpression="BaoPriceTopic">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="报价编号" DataField="BaoPriceNo" ItemStyle-Width="115px"
                                    SortExpression="BaoPriceNo">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="报价日期" DataField="BaoPriceDateTime" ItemStyle-Width="80px"
                                    SortExpression="BaoPriceDateTime" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="客户名称" SortExpression="CustomerValue" HeaderStyle-Font-Size="12px"
                                    ItemStyle-Width="180px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                   <a href="#" onclick="javascript:window.open('/Web/Sales/KNet_Sales_ClientList_Details.aspx?CustomerValue=<%# DataBinder.Eval(Container.DataItem, "CustomerValue")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# GetCustomerValueName(DataBinder.Eval(Container.DataItem, "CustomerValue"))%></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="公司" SortExpression="BaoPriceStaffBranch" HeaderStyle-Font-Size="12px"
                                    ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# GetStrucNameNane(DataBinder.Eval(Container.DataItem, "BaoPriceStaffBranch"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态" SortExpression="BaoPriceCheckYN" HeaderStyle-Font-Size="12px"
                                    ItemStyle-Width="30px" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <%# GetBaoPriceCheckYN(DataBinder.Eval(Container.DataItem, "BaoPriceNo"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        <HeaderStyle CssClass='colHeader' />
                        <RowStyle CssClass='listTableRow' />
                        <AlternatingRowStyle BackColor="#E3EAF2" />
                        <PagerStyle CssClass='Custom_DgPage' />
                    </cc1:MyGridView>
                        <!--分页-->
                        <!--底部功能栏-->
<table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top: 1px solid #A3B2CC;">
  <tr>
   <td width="76%" height="30">&nbsp;<asp:Button ID="Button2" runat="server" CssClass="crmButton  small create" Text="确定选择" OnClick="Button1_Click" Width="81px"  Height="33px" /></td>
    <td width="24%" align="right"><asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="">请选择状态</asp:ListItem>
                                        <asp:ListItem Value="1">只显示已审核</asp:ListItem>
                                        <asp:ListItem Value="0">只显示未审核</asp:ListItem>
                                    </asp:DropDownList></td>
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

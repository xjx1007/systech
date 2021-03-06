﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectSuppliers.aspx.cs"
    Inherits="Knet_Common_SelectSuppliers" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <base target="_self" />
    <script>
        function closeWindow() {
            window.opener = null;
            window.close();
        }

        function GetReturn(Value1, Value2, Value3, Value4, Value5, Value6) {
            var response = Knet_Common_SelectSuppliers.LinMan_Bind(Value1);
            if (window.opener != undefined) {
                window.opener.returnValue = Value1 + "|" + Value2 + "|" + Value3 + "|" + Value4 + "|" + Value5 + "|" + Value6 + response.value;
            }
            else {
                window.returnValue = Value1 + "|" + Value2 + "|" + Value3 + "|" + Value4 + "|" + Value5 + "|" + Value6 + response.value;
            }

        }
    </script>
    <title>选择供应商</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>
        <!--头部-->
        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="150" background="../../images/ktxt1.gif" style="background-color: #F5F5F5;
                    height: 28px; width: 130px; padding-left: 20px;">
                    <div class="TP2">
                        供应商选择</div>
                </td>
                <td width="320" align="right" background="../../images/ktxt2.gif" style="background-color: #F5F5F5;
                    height: 28px;">
                    &nbsp;供应商搜索:<asp:TextBox ID="SeachKey" runat="server" Width="200px" CssClass="Boxx"></asp:TextBox>
                </td>
                <td background="../../images/ktxt2.gif" style="background-color: #F5F5F5; height: 28px;"
                    align="left">
                    &nbsp;<asp:Button ID="Button1" runat="server" Text="搜索" CssClass="Btt" OnClick="Button1_Click1" />
                </td>
            </tr>
        </table>
        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" >
            <tr>
                <td>
                    <!--GridView-->
                    <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%" PageSize="10"
                        BorderColor="#4974C2">
                        <Columns>
                            <asp:TemplateField HeaderText="供应商名称" SortExpression="SuppName" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <%# GetSupp(DataBinder.Eval(Container.DataItem, "SuppNo").ToString())%>
                                    <a href="#" onclick="javascript:window.open('../Supp/Knet_Procure_Suppliers_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ID")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=750,height=450');">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="../../images/Deitail.gif" ToolTip="查看供应商详细信息" /></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="所在地区" SortExpression="SuppCity" HeaderStyle-Font-Size="12px"
                                 ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%# GetSuppProvinceName(DataBinder.Eval(Container.DataItem, "SuppProvince"))%>-<%# GetSuppCityName(DataBinder.Eval(Container.DataItem, "SuppCity"))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SuppPeople" ItemStyle-Font-Size="12px" HeaderText="联系人"
                                 HeaderStyle-Font-Size="12px" SortExpression="SuppPeople">
                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SuppMobiTel" ItemStyle-Font-Size="12px" HeaderText="联系手机"
                                 HeaderStyle-Font-Size="12px" SortExpression="SuppMobiTel">
                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SuppPhone" ItemStyle-Font-Size="12px" HeaderText="联系电话"
                                HeaderStyle-Font-Size="12px" SortExpression="SuppPhone">
                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle CssClass='colHeader' />
                        <RowStyle CssClass='listTableRow' />
                        <AlternatingRowStyle BackColor="#E3EAF2" />
                        <PagerStyle CssClass='Custom_DgPage' />
                    </cc1:MyGridView>
                    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top: 1px solid #A3B2CC;">
                        <tr>
                            <td width="42%" align="right">
                                <asp:DropDownList ID="Ddl_Type" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Ddl_Type_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="SuppProvinceDDL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="StrucNameDList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
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

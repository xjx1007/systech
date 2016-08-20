<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectSuppliers.aspx.cs"
    Inherits="Knet_Common_SelectSuppliers" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css" />
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <link rel="stylesheet" href="/Web/css/ihwy-2012.css" type="text/css" media="screen" charset="utf-8" />
    <link rel="stylesheet" href="/Web/cssjquery.listnav-2.1.css" type="text/css" media="screen" charset="utf-8" />
    <script type="text/javascript" src="/Web/js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="/Web/js/jquery.cookie.js" charset="utf-8"></script>
    <script type="text/javascript" src="/Web/js/jquery.idTabs.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="/Web/js/jquery.listnav-2.1.js" charset="utf-8"></script>
    <base target="_self" />
    <script type="text/javascript" charset="utf-8">
        $(function () {
            if (top.location.href.toLowerCase() == self.location.href.toLowerCase()) $('#docLink').show();
            $("#tabNav ul").idTabs("tab2");
        });
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

        function changsheng(va) {
            if (va != "0") {
                var city = document.getElementById("city");
                city.disabled = false;
                var url = "/Web/Js/Handler.ashx?type=sheng&id=" + va;
                send_request("GET", url, null, "text", populateClass3);
            }
        }
        function populateClass3() {
            var f = document.getElementById("city");
            if (http_request.readyState == 4) {
                if (http_request.status == 200) {
                    var list = http_request.responseText;
                    var classList = list.split("|");
                    f.options.length = 1;
                    for (var i = 0; i < classList.length; i++) {
                        var tmp = classList[i].split(",");
                        f.add(new Option(tmp[1], tmp[0]));
                    }
                } else {
                    alert("您所请求的页面有异常。");
                }
            }
        }

        function set_return_Customer(Customer_id, Customer_name, LinkCode) {
            var response = Knet_Common_SelectSuppliers.GetCustomer(Customer_id);
            if (window.opener != undefined) {
                window.opener.returnValue = Customer_id + "|" + Customer_name + "|" + LinkCode + "|" + response.value;
            }
            else {
                window.returnValue = Customer_id + "|" + Customer_name + "|" + LinkCode + "|" + response.value;
            }
        }
    </script>
    <title>选择供应商/客户</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div>

            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                <tr>
                    <td style="height: 2px"></td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>采购 > <a class="hdrLink" href="SelectSuppliers.aspx">选择供应商/客户</a>
                    </td>
                    <td width="100%" nowrap>
                        <asp:Label ID="Tbx_ID" runat="server" Style="display: none"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 2px"></td>
                </tr>
            </table>


            <div class="demoWrapper">

                <div id="tabNav">
                    <ul>
                        <li><a href="#tab1">供应商</a></li>
                        <li><a href="#tab2">客户</a></li>
                    </ul>
                    <div class="clr"></div>
                </div>

                <div id="tabs">
                    <!--基本信息-->
                    <div id="tab1" class="tab">
                        <!--头部-->
                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="320" align="right" background="/images/ktxt2.gif" style="background-color: #F5F5F5; height: 28px;">&nbsp;供应商搜索:<asp:TextBox ID="SeachKey1" runat="server" Width="200px" CssClass="Boxx"></asp:TextBox>
                                </td>
                                <td background="/images/ktxt2.gif" style="background-color: #F5F5F5; height: 28px;"
                                    align="left">&nbsp;<asp:Button ID="Button1" runat="server" Text="搜索"  CssClass="crmbutton small create" OnClick="Button1_Click1" />
                                </td>
                            </tr>
                        </table>
                        
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="small">
                            <tr>
                                <td>
                                    <!--GridView-->
                        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="true" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>" GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="25px">

                                        <Columns>
                                            <asp:TemplateField HeaderText="供应商名称" SortExpression="SuppName" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-HorizontalAlign="center">
                                                <ItemTemplate>
                                                    <%# GetSupp(DataBinder.Eval(Container.DataItem, "SuppNo").ToString())%>
                                                    <a href="#" onclick="javascript:window.open('../Supp/Knet_Procure_Suppliers_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ID")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=750,height=450');">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="/images/Deitail.gif" ToolTip="查看供应商详细信息" /></a>
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
                    </div>
                    <div id="tab2" class="tab">
                        
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="small">
                <tr>
                    <td>
                        关键字：<asp:TextBox ID="SeachKey" runat="server" CssClass="detailedViewTextBox"
                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                            Width="300px"></asp:TextBox><asp:Button ID="Button2" runat="server" Text="搜索" CssClass="crmbutton small create" OnClick="Button2_Click1" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <!--GridView-->
                        <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="true" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>" GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false" pageSize="8" ShowHeader="true" HeaderStyle-Height="25px">
                            <Columns>
                                <asp:TemplateField HeaderText="客户名称" HeaderStyle-Font-Size="12px" ItemStyle-Height="25px" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                    <ItemTemplate>

                                        <%# GetLink(DataBinder.Eval(Container.DataItem, "CustomerValue").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="省份" SortExpression="CustomerProvinces" HeaderStyle-Font-Size="12px" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# base.Base_GetCityName(DataBinder.Eval(Container.DataItem, "CustomerProvinces").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="渠道信息" SortExpression="CustomerClass" HeaderStyle-Font-Size="12px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# base.Base_GetKClaaName(DataBinder.Eval(Container.DataItem, "CustomerClass").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="客户类型" SortExpression="CustomerTypes" HeaderStyle-Font-Size="12px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# base.Base_GetKClaaName(DataBinder.Eval(Container.DataItem, "CustomerTypes").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField HeaderText="负责人" DataField="CustomerContact" ItemStyle-Font-Size="12px" ItemStyle-Width="50px" HeaderStyle-Font-Size="12px" SortExpression="CustomerContact">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                                <asp:BoundField HeaderText="移动电话" DataField="CustomerMobile" ItemStyle-Font-Size="12px" ItemStyle-Width="60px" HeaderStyle-Font-Size="12px" SortExpression="CustomerMobile">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                                <asp:BoundField HeaderText="编码" DataField="CustomerCode" ItemStyle-Font-Size="12px" ItemStyle-Width="70px" HeaderStyle-Font-Size="12px" SortExpression="CustomerTel">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                            </Columns>

                            <HeaderStyle CssClass='colHeader' />
                            <RowStyle CssClass='listTableRow' />
                            <AlternatingRowStyle BackColor="#E3EAF2" />
                            <PagerStyle CssClass='Custom_DgPage' />
                        </cc1:MyGridView>
                        <!--GridView-->
                        <!--分页-->

                        <!--底部功能栏-->

                    </td>
                </tr>
            </table>
                    </div>
                </div>
            </div>

            <!--内部结束-->
        </div>
    </form>
</body>
</html>

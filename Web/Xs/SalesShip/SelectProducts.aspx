<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectProducts.aspx.cs" Inherits="Knet_Common_SelectProducts" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="/include/js/ListView.js"></script>
    <script type="text/javascript" src="/Web/KDialog/lhgdialog.js"></script>
    <base target="_self" />
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script>
        function changsheng(va) {
            if (va != '0') {
                var SmallClass = document.getElementById("SmallClass");
                SmallClass.disabled = false;
                var url = "/Web/Web/Js/ProductClassHandler.ashx?type=BigClass&BigNo=" + va;
                send_request("GET", url, null, "text", populateClass3);
            }
        }
        function populateClass3() {
            var f = document.getElementById("SmallClass");
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
                    alert("您所请求的页面有异常.");
                }
            }
        }

        function set_return_value(ProdutsBarCode, Custom, Price, Number, s_ID, s_ContractNo) {
            var response = Knet_Common_SelectProducts.GetProductsInfo(ProdutsBarCode, Custom, Price, Number,s_ID,s_ContractNo);
            if (window.opener != undefined) {
                window.opener.returnValue = ProdutsBarCode + "|" + response.value;
            }
            else {
                window.returnValue = ProdutsBarCode + "|" + response.value;
            }
        }
    </script>
    <title>选择产品</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!--头部-->
            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                <tr>
                    <td style="height: 2px"></td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>选择产品 > <a class="hdrLink" href="SelectProducts.aspx">选择产品</a>
                    </td>
                    <td width="100%" nowrap>
                        <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                        <asp:TextBox ID="Tbx_Customer" runat="server" Style="display: none"></asp:TextBox>
                        <asp:TextBox ID="Tbx_ProductsBarCode" runat="server" Style="display: none"></asp:TextBox>
                        <asp:TextBox ID="Tbx_ContractNos" runat="server" Style="display: none"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="height: 2px"></td>
                </tr>
            </table>
            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                <tr>
                    <td class="dvtCellInfo" colspan="4">
                        关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="detailedViewTextBox" Width="300px"></asp:TextBox>&nbsp;<asp:Button
                        ID="Button1" runat="server" Text="产品筛选" CssClass="crmButton small create" OnClick="Button1_Click1" />
                        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="true" AllowSorting="True"
                            EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"
                            GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"
                            ShowHeader="true" HeaderStyle-Height="25px">
                            <Columns>
                                <asp:TemplateField HeaderText="产品名称" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <%# GetLink(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString(), DataBinder.Eval(Container.DataItem, "Price").ToString(), DataBinder.Eval(Container.DataItem, "LeftNumber").ToString(),DataBinder.Eval(Container.DataItem, "ID").ToString(),DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ProductsEdition" HeaderText="版本号" SortExpression="ProductsPattern">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="大类名称" SortExpression="ProductsMainCategory" HeaderStyle-Font-Size="12px"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# base.Base_GetProductsType(DataBinder.Eval(Container.DataItem, "ProductsType").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="单位" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# base.Base_GetUnitsName(DataBinder.Eval(Container.DataItem, "ProductsUnits").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="LeftNumber" HeaderText="未执行订单数量" SortExpression="PNumber">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="库存数量" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# base.Base_GetHouseAndNumber(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Price" HeaderText="单价" SortExpression="Price">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>
                            </Columns>
                            <HeaderStyle CssClass='colHeader' />
                            <RowStyle CssClass='listTableRow' />
                            <AlternatingRowStyle BackColor="#E3EAF2" />
                            <PagerStyle CssClass='Custom_DgPage' />
                        </cc1:MyGridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

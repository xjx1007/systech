<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MakePaymentList.aspx.cs" Inherits="Web_Receive_MakePaymentList" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <title>产品开票详情</title>
    <script type="text/javascript" src="../js/ajax_func.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
    <script type="text/javascript" src="../KDialog/lhgdialog.js"></script>
    <style type="text/css">
        a.x {
            color: black;
            text-align: center;
            text-decoration: none;
            padding: 5px;
            font-weight: bold;
        }

            a.x:hover {
                color: #333333;
                text-decoration: underline;
                font-weight: bold;
            }

        ul {
            color: black;
        }

        .drag_Element {
            position: relative;
            left: 0px;
            top: 0px;
            padding-left: 5px;
            padding-right: 5px;
            border: 0px dashed #CCCCCC;
            visibility: hidden;
        }`

        #Drag_content {
            position: absolute;
            left: 0px;
            top: 0px;
            padding-left: 5px;
            padding-right: 5px;
            background-color: #000066;
            color: #FFFFFF;
            border: 1px solid #CCCCCC;
            font-weight: bold;
            display: none;
        }
    </style>
    <script>
        var hideAll = false;
        var parentId = "";
        var parentName = "";
        var childId = "NULL";
        var childName = "NULL";
        function displayCoords(event) {
            var move_Element = document.getElementById('Drag_content').style;
            if (!event) {
                move_Element.left = e.pageX + 'px';
                move_Element.top = e.pageY + 10 + 'px';
            }
            else {
                move_Element.left = event.clientX + 'px';
                move_Element.top = event.clientY + 10 + 'px';
            }
        }

        function fnRevert(e) {
            if (e.button == 2) {
                document.getElementById('Drag_content').style.display = 'none';
                hideAll = false;
                parentId = "Head";
                parentName = "DEPARTMENTS";
                childId = "NULL";
                childName = "NULL";
            }
        }
        function fnVisible(Obj) {
            document.getElementById(Obj).style.visibility = 'visible';
        }

        function fnInVisible(Obj) {
            document.getElementById(Obj).style.visibility = 'hidden';
        }
        function showhide(argg, imgId) {
            var harray = argg.split(",");
            var harrlen = harray.length;
            var i;
            var img_dir = imgId + "_dir";
            for (i = 0; i < harrlen; i++) {
                var x = document.getElementById(harray[i]).style;
                if (x.display == "none") {
                    x.display = "block";
                    document.getElementById(imgId).src = "../../themes/softed/images/minus.gif";
                    document.getElementById(img_dir).src = "../../themes/softed/images/folderopen.gif";
                }
                else {
                    x.display = "none";
                    document.getElementById(imgId).src = "../../themes/softed/images/plus.gif";
                    document.getElementById(img_dir).src = "../../themes/softed/images/folder.gif";
                }
            }
        }


    </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div id="ssdd" style="padding: 1px">
        </div>

        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">

            <tr runat="server" id="BYQM">
                <td>
                    <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                        <tr>
                            <td align="center" colspan="2">
                                <h3>杭州士腾科技有限公司<br />
                                    产品本月期末开票明细</h3>
                            </td>
                        </tr>
                        <tr>
                            <td align="left"><asp:Label runat="server" ID="Lbl_House"></asp:Label>
                            </td>
                            <td align="right"><asp:Label runat="server" ID="Lbl_ProductsBarCode" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top">
                               <cc1:MyGridView ID="MyGridView2" runat="server" AllowPaging="True" AllowSorting="True"
                                IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                                PageSize="10" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="出库单号" SortExpression="CAP_Code" ItemStyle-HorizontalAlign="center"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <a href="../SalesOut/Sales_ShipWareOut_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "DirectOutNo") %>">
                                                <%# DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString()%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="发货通知单号" SortExpression="CAP_Code" ItemStyle-HorizontalAlign="center"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <a href="../SalesShip/Knet_Sales_Ship_Manage_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "KWD_ShipNo") %>">
                                                <%# DataBinder.Eval(Container.DataItem, "KWD_ShipNo").ToString()%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="客户" SortExpression="KWD_Custmoer" ItemStyle-HorizontalAlign="center"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <%#base.Base_GetCustomerName_Link(DataBinder.Eval(Container.DataItem, "KWD_Custmoer").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                        <asp:BoundField HeaderText="出库日期" DataField="DirectOutDateTime" DataFormatString="{0:yyyy-MM-dd}"
                                            SortExpression="DirectOutDateTime">
                                            <itemstyle horizontalalign="Left" font-size="12px" />
                                            <headerstyle horizontalalign="Left" font-size="12px" />
                                        </asp:BoundField>
                                    <asp:TemplateField HeaderText="产品" SortExpression="KWD_Custmoer" ItemStyle-HorizontalAlign="left"
                                        HeaderStyle-HorizontalAlign="left">
                                        <ItemTemplate>
                                            <%#base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="发票数量" DataField="CAPD_Number" SortExpression="CAPD_Number" DataFormatString="{0:f0}"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                     <asp:BoundField HeaderText="出库数量" DataField="DirectOutAmount" SortExpression="DirectOutAmount" DataFormatString="{0:f0}"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                     <asp:BoundField HeaderText="未开票数量" DataField="QM" SortExpression="QM" DataFormatString="{0:f0}"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="单价" DataField="CAPD_Price" SortExpression="CAPD_Price"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="金额" DataField="CAPD_Money" SortExpression="CAPD_Money"  DataFormatString="{0:f2}"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                     <asp:BoundField  HeaderText="备注"  DataField="CAPD_Details"  SortExpression="CAPD_Details"  ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
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
                </td>
            </tr>
            <tr runat="server" id="QCKP">
                <td>
                    <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                        <tr>
                            <td align="center" colspan="2">
                                <h3>杭州士腾科技有限公司<br />
                                    产品期初开票明细</h3>
                            </td>
                        </tr>
                        <tr>
                            <td align="left"><asp:Label runat="server" ID="LabelQCKH"></asp:Label>
                            </td>
                            <td align="right"><asp:Label runat="server" ID="LabelQCN" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top">
                               <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                                PageSize="10" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="出库单号" SortExpression="CAP_Code" ItemStyle-HorizontalAlign="center"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <a href="../SalesOut/Sales_ShipWareOut_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "DirectOutNo") %>">
                                                <%# DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString()%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="发货通知单号" SortExpression="CAP_Code" ItemStyle-HorizontalAlign="center"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <a href="../SalesShip/Knet_Sales_Ship_Manage_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "KWD_ShipNo") %>">
                                                <%# DataBinder.Eval(Container.DataItem, "KWD_ShipNo").ToString()%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="客户" SortExpression="KWD_Custmoer" ItemStyle-HorizontalAlign="center"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <%#base.Base_GetCustomerName_Link(DataBinder.Eval(Container.DataItem, "KWD_Custmoer").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                        <asp:BoundField HeaderText="出库日期" DataField="DirectOutDateTime" DataFormatString="{0:yyyy-MM-dd}"
                                            SortExpression="DirectOutDateTime">
                                            <itemstyle horizontalalign="Left" font-size="12px" />
                                            <headerstyle horizontalalign="Left" font-size="12px" />
                                        </asp:BoundField>
                                    <asp:TemplateField HeaderText="产品" SortExpression="KWD_Custmoer" ItemStyle-HorizontalAlign="left"
                                        HeaderStyle-HorizontalAlign="left">
                                        <ItemTemplate>
                                            <%#base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="发票数量" DataField="CAPD_Number" SortExpression="CAPD_Number" DataFormatString="{0:f0}"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                     <asp:BoundField HeaderText="出库数量" DataField="DirectOutAmount" SortExpression="DirectOutAmount" DataFormatString="{0:f0}"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                     <asp:BoundField HeaderText="未开票数量" DataField="QC" SortExpression="QC" DataFormatString="{0:f0}"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="单价" DataField="CAPD_Price" SortExpression="CAPD_Price"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="金额" DataField="CAPD_Money" SortExpression="CAPD_Money"  DataFormatString="{0:f2}"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                     <asp:BoundField  HeaderText="备注"  DataField="CAPD_Details"  SortExpression="CAPD_Details"  ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
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
                </td>
            </tr>
             <tr runat="server" id="BYFH">
                <td>
                    <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                        <tr>
                            <td align="center" colspan="2">
                                <h3>杭州士腾科技有限公司<br />
                                    产品本月发货明细</h3>
                            </td>
                        </tr>
                        <tr>
                            <td align="left"><asp:Label runat="server" ID="LabelFHKH"></asp:Label>
                            </td>
                            <td align="right"><asp:Label runat="server" ID="LabelFHN" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top">
                               <cc1:MyGridView ID="MyGridView3" runat="server" AllowPaging="True" AllowSorting="True"
                                IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                                PageSize="10" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="出库单号" SortExpression="CAP_Code" ItemStyle-HorizontalAlign="center"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <a href="../SalesOut/Sales_ShipWareOut_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "DirectOutNo") %>">
                                                <%# DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString()%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="发货通知单号" SortExpression="CAP_Code" ItemStyle-HorizontalAlign="center"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <a href="../SalesShip/Knet_Sales_Ship_Manage_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "KWD_ShipNo") %>">
                                                <%# DataBinder.Eval(Container.DataItem, "KWD_ShipNo").ToString()%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="客户" SortExpression="KWD_Custmoer" ItemStyle-HorizontalAlign="center"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <%#base.Base_GetCustomerName_Link(DataBinder.Eval(Container.DataItem, "KWD_Custmoer").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                        <asp:BoundField HeaderText="出库日期" DataField="DirectOutDateTime" DataFormatString="{0:yyyy-MM-dd}"
                                            SortExpression="DirectOutDateTime">
                                            <itemstyle horizontalalign="Left" font-size="12px" />
                                            <headerstyle horizontalalign="Left" font-size="12px" />
                                        </asp:BoundField>
                                    <asp:TemplateField HeaderText="产品" SortExpression="KWD_Custmoer" ItemStyle-HorizontalAlign="left"
                                        HeaderStyle-HorizontalAlign="left">
                                        <ItemTemplate>
                                            <%#base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <%-- <asp:BoundField HeaderText="发票数量" DataField="CAPD_Number" SortExpression="CAPD_Number" DataFormatString="{0:f0}"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>--%>
                                     <asp:BoundField HeaderText="出库数量" DataField="DirectOutAmount" SortExpression="DirectOutAmount" DataFormatString="{0:f0}"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                   <%--  <asp:BoundField HeaderText="未开票数量" DataField="QC" SortExpression="QC" DataFormatString="{0:f0}"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField HeaderText="单价" DataField="CAPD_Price" SortExpression="CAPD_Price"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="金额" DataField="CAPD_Money" SortExpression="CAPD_Money"  DataFormatString="{0:f2}"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                     <asp:BoundField  HeaderText="备注"  DataField="CAPD_Details"  SortExpression="CAPD_Details"  ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
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
                </td>
            </tr>
             <tr runat="server" id="BYKP">
                <td>
                    <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                        <tr>
                            <td align="center" colspan="2">
                                <h3>杭州士腾科技有限公司<br />
                                    产品本月开票明细</h3>
                            </td>
                        </tr>
                        <tr>
                            <td align="left"><asp:Label runat="server" ID="LabelKPKH"></asp:Label>
                            </td>
                            <td align="right"><asp:Label runat="server" ID="LabelKPN" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top">
                               <cc1:MyGridView ID="MyGridView4" runat="server" AllowPaging="True" AllowSorting="True"
                                IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                                PageSize="10" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="出库单号" SortExpression="CAP_Code" ItemStyle-HorizontalAlign="center"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <a href="../SalesOut/Sales_ShipWareOut_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "DirectOutNo") %>">
                                                <%# DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString()%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="发货通知单号" SortExpression="CAP_Code" ItemStyle-HorizontalAlign="center"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <a href="../SalesShip/Knet_Sales_Ship_Manage_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "KWD_ShipNo") %>">
                                                <%# DataBinder.Eval(Container.DataItem, "KWD_ShipNo").ToString()%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="客户" SortExpression="KWD_Custmoer" ItemStyle-HorizontalAlign="center"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <%#base.Base_GetCustomerName_Link(DataBinder.Eval(Container.DataItem, "KWD_Custmoer").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                        <asp:BoundField HeaderText="出库日期" DataField="DirectOutDateTime" DataFormatString="{0:yyyy-MM-dd}"
                                            SortExpression="DirectOutDateTime">
                                            <itemstyle horizontalalign="Left" font-size="12px" />
                                            <headerstyle horizontalalign="Left" font-size="12px" />
                                        </asp:BoundField>
                                    <asp:TemplateField HeaderText="产品" SortExpression="KWD_Custmoer" ItemStyle-HorizontalAlign="left"
                                        HeaderStyle-HorizontalAlign="left">
                                        <ItemTemplate>
                                            <%#base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="发票数量" DataField="CAPD_Number" SortExpression="CAPD_Number" DataFormatString="{0:f0}"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                     <asp:BoundField HeaderText="出库数量" DataField="DirectOutAmount" SortExpression="DirectOutAmount" DataFormatString="{0:f0}"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                     <asp:BoundField HeaderText="未开票数量" DataField="QC" SortExpression="QC" DataFormatString="{0:f0}"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="单价" DataField="CAPD_Price" SortExpression="CAPD_Price"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="金额" DataField="CAPD_Money" SortExpression="CAPD_Money"  DataFormatString="{0:f2}"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                     <asp:BoundField  HeaderText="备注"  DataField="CAPD_Details"  SortExpression="CAPD_Details"  ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
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
                </td>
            </tr>
        </table>
    </form>
</body>
</html>


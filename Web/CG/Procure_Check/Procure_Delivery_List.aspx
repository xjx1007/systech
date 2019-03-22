<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Procure_Delivery_List.aspx.cs" Inherits="Web_CG_Procure_Check_Procure_Delivery_List" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <title>产品开票详情</title>
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../../Js/ajax_func.js"></script>
    <script type="text/javascript" src="../../Js/Global.js"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
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
        }

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


            <tr>
                <td align="center" colspan="2">
                    <h3>杭州士腾科技有限公司<br />
                        加工厂送货明细</h3>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label runat="server" ID="Lbl_House"></asp:Label>
                </td>
                <td align="right">
                    <asp:Label runat="server" ID="Lbl_ProductsBarCode"></asp:Label>
                    <asp:Label runat="server" ID="SuppNo" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" valign="top">
                    <cc1:MyGridView ID="MyGridView2" runat="server" AllowPaging="True" AllowSorting="True"
                        IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                        PageSize="10" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="调拨单号" SortExpression="AllocateNo" ItemStyle-HorizontalAlign="center"
                                HeaderStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <a href="KNet_WareHouse_WareCheck_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "AllocateNo") %>" target="_blank"><%# DataBinder.Eval(Container.DataItem, "AllocateNo").ToString()%></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="订单号" SortExpression="KWA_OrderNo" ItemStyle-HorizontalAlign="center"
                                HeaderStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <a href="/Web/Cg/Order/Knet_Procure_OpenBilling_View_ForSc.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "KWA_OrderNo") %>" target="_blank">
                                        <%# DataBinder.Eval(Container.DataItem, "KWA_OrderNo") %></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="加工厂" SortExpression="HouseNo" ItemStyle-HorizontalAlign="center"
                                HeaderStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <%#base.Base_GetHouseName(DataBinder.Eval(Container.DataItem, "HouseNo").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="送货日期" DataField="AllocateDateTime" DataFormatString="{0:yyyy-MM-dd}"
                                SortExpression="AllocateDateTime">
                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="产品" SortExpression="KWD_Custmoer" ItemStyle-HorizontalAlign="left"
                                HeaderStyle-HorizontalAlign="left">
                                <ItemTemplate>
                                    <%#base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="送货数量" DataField="KWAD_SDNumber" SortExpression="KWAD_SDNumber" DataFormatString="{0:f0}"
                                ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="入成品库数量" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>

                                    <asp:TextBox ID="RK_Number" runat="server" Text='<%# RK_Number(DataBinder.Eval(Container.DataItem, "KWA_OrderNo").ToString(),DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString()) %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="报废数量" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%-- <asp:TextBox ID="KWAD_BFNumber" runat="server" Text='0'></asp:TextBox>--%>
                                    <%# DataBinder.Eval(Container.DataItem, "KWAD_BFNumber").ToString()%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="报废单价" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%-- <asp:TextBox ID="KWAD_BFNumber" runat="server" Text='0'></asp:TextBox>--%>
                                    <%# base.BFPrice(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString()) %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="加工费" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%-- <asp:TextBox ID="KWAD_BFNumber" runat="server" Text='0'></asp:TextBox>--%>
                                    <asp:TextBox ID="Tbx_HandPrice" runat="server" ReadOnly="True" CssClass="detailedViewTextBox" enable="false" MaxLength="40" Text=' <%# GetHandPrice(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>' Width="65px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="应扣金额" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%-- <%# base.KK_Money(DataBinder.Eval(Container.DataItem, "KWAD_BFNumber").ToString(),DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>--%>
                                    <asp:TextBox ID="KK_Money" runat="server" ReadOnly="True" Text=' <%# base.KK_Money(DataBinder.Eval(Container.DataItem, "KWAD_BFNumber").ToString(),DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>' Width="100px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="实付金额" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%-- <%# base.KK_Money(DataBinder.Eval(Container.DataItem, "KWAD_BFNumber").ToString(),DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>--%>
                                    <asp:TextBox ID="Tbx_HandMoney" runat="server" ReadOnly="True" CssClass="detailedViewTextBox" enable="false" MaxLength="40" Text='<%# GetHandMoney(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString(),OrderNoCount(DataBinder.Eval(Container.DataItem, "KWA_OrderNo").ToString(),DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString()),DataBinder.Eval(Container.DataItem, "KWAD_BFNumber").ToString()) %>' Width="65px"></asp:TextBox>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="备注" DataField="AllocateRemarks" SortExpression="AllocateRemarks" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
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
    </form>
</body>
</html>



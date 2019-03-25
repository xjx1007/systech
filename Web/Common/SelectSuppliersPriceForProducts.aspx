<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectSuppliersPriceForProducts.aspx.cs" Inherits="Knet_Common_SelectSuppliersPriceForProducts" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <base target="_self" />
    <script>
        function closeWindow() {
            window.opener = null;
            window.close();
        }
    </script>

    <script type="text/javascript" src="../js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../js/Global.js"></script>
    <script>
        function changsheng(va) {
            if (va != '0') {
                var SmallClass = document.getElementById("SmallClass");
                SmallClass.disabled = false;
                var url = "../Js/ProductClassHandler.ashx?type=BigClass&BigNo=" + va;
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
    </script>
    <style type="text/css">
        .Div11 {
            background-image: url(../images/midbottonA2.gif);
            background-repeat: no-repeat;
            z-index: 0px;
            padding-top: 3px;
        }

        .Div22 {
            background-image: url(../images/midbottonB2.gif);
            background-repeat: no-repeat;
            z-index: 0px;
            padding-top: 3px;
        }
    </style>

    <title>选择供应商采购报价</title>
    <base target="_self" />
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div>


            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                <tr>
                    <td style="height: 2px"></td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>报价 > <a class="hdrLink" href="SelectClientProductsList.aspx">选择产品报价</a>
                    </td>
                    <td width="100%" nowrap></td>
                </tr>
                <tr>
                    <td style="height: 2px"></td>
                </tr>
            </table>

            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="small">
                <tr>
                    <td width="14%" valign="top">
                        <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                            <tr>
                                <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                </td>
                                <td id="catalog_tab" class="dvtSelectedCell" align="center" nowrap>
                                    <a href="javascript:showProductCatalog()">产品分类</a>
                                </td>
                                <td class="dvtTabCache" style="width: 100%">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer"
                                        NodeIndent="15" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
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
                        <cc1:MyGridView ID="GridView1" AllowPaging="true" runat="server" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>" GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="25px">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="CheckBox1" onclick="selectAll(this)" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chbk" runat="server" /><a href="#" onclick="javascript:window.open('../Procure/KNet_Procure_Suppliers_Details.aspx?SuppNoID=<%# DataBinder.Eval(Container.DataItem, "SuppNo")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=750,height=450');"><asp:Image ID="Image1" runat="server" ImageUrl="../../images/Deitail.gif" ToolTip="查看供应商详细信息" /></a>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="供应商名称" SortExpression="SuppNo" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# base.Base_GetSupplierName(DataBinder.Eval(Container.DataItem, "SuppNo").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:BoundField DataField="ProductsName" HeaderText="产品名称" SortExpression="ProductsName">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="版本号" SortExpression="ProductsMainCategory" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="大类名称" SortExpression="ProductsMainCategory" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# GetBigCateNane(DataBinder.Eval(Container.DataItem, "ProductsMainCategory"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="ProcureUnitPrice" ItemStyle-Font-Size="12px" ItemStyle-ForeColor="blue" HeaderText="采购单价" HeaderStyle-Font-Size="12px" SortExpression="ProcureUnitPrice" DataFormatString="{0:c}" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="采购数量" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:TextBox ID="Tbx_Number" Width="60px" runat="server" CssClass="Boxx" value="1"></asp:TextBox>
                                        <asp:TextBox ID="ProductsBarCode" Width="0px" runat="server" CssClass="Custom_Hidden" value='<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString() %>'></asp:TextBox>
                                        <asp:TextBox ID="SuppNo" Width="0px" runat="server" CssClass="Custom_Hidden" value='<%# DataBinder.Eval(Container.DataItem, "SuppNo").ToString() %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="是否采购" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chb_IsOrder" runat="server" Checked></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="地址" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:RadioButton runat="server" ID="RadioButton1" GroupName="Rbtn" Text="发供应商" Checked />
                                        <asp:RadioButton runat="server" ID="RadioButton2" GroupName="Rbtn" Text="发客户" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="KPP_Remarks" ItemStyle-Font-Size="12px" ItemStyle-ForeColor="blue" HeaderText="备注" HeaderStyle-Font-Size="12px" SortExpression="KPP_Remarks" DataFormatString="{0:c}" HtmlEncode="false">
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
                        <!--底部功能栏-->
                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top: 1px solid #A3B2CC;">
                            <tr>
                                <td width="25%">
                                    <asp:Button ID="Button2" runat="server" CssClass="crmbutton small save" Text="确定" OnClick="Button1_Click" Style="width: 55px; height: 33px;" />
                                    关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="detailedViewTextBox" Width="200px"></asp:TextBox>&nbsp;<asp:Button ID="Button1" runat="server" Text="筛选" CssClass="crmbutton small save" OnClick="Button1_Click1" Style="width: 55px; height: 33px;" /></td>
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

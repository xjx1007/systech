<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectProduct.aspx.cs" Inherits="Web_ScExpend_SelectProduct" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="../js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
    <base target="_self" />
    <script>
        function changsheng(va) {
            if (va != '0') {
                var SmallClass = document.getElementById("SmallClass");
                SmallClass.disabled = false;
                var url = "../Web/Js/ProductClassHandler.ashx?type=BigClass&BigNo=" + va;
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

    <title>选择产品</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>



            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                <tr>
                    <td style="height: 2px"></td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>产品字典 > <a class="hdrLink" href="SelectProduct.aspx">产品选择</a>
                        <asp:TextBox runat="server" ID="Tbx_KSP_SampleId" CssClass="Custom_Hidden"></asp:TextBox>
                    </td>
                    <td width="100%" nowrap>
                        <table border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="sep1" style="width: 1px;"></td>
                                <td class="small"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 2px"></td>
                </tr>
            </table>

            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">

                <tr>
                    <td>
                        <%=base.Base_BindView("KNet_WareHouse_DirectOutList", "Sales_ShipWareOut_Manage.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString())%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                            <tr>
                                <!-- Buttons -->
                                <td style="padding-right: 20px" align="left" nowrap></td>
                            </tr>
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

                                    <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                        EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"
                                        GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"
                                        ShowHeader="true" HeaderStyle-Height="25px">
                                        <Columns>

                                            <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="Chbk" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="产品名称" SortExpression="ProductsName" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TXB_ProductsName" runat="server" ReadOnly="True" Text='<%# DataBinder.Eval(Container.DataItem, "ProductsName").ToString() %>'></asp:TextBox>
                                                    <asp:TextBox ID="TXB_ProductsBarCode" runat="server" CssClass="Custom_Hidden" Width="100px"
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString() %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="大类名称" SortExpression="ProductsType" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <%# base.Base_GetProductsType(DataBinder.Eval(Container.DataItem, "ProductsType").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ProductsBarCode" HeaderText="编号(条码)" SortExpression="ProductsBarCode">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="版本号" SortExpression="ProductsEdition" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <%# base.Base_GetProductsEdition_Link(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>

                                                    <asp:TextBox ID="Tbx_Edition" runat="server" CssClass="Custom_Hidden" Width="100px"
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "ProductsEdition").ToString() %>'></asp:TextBox>
                                                    <asp:TextBox ID="Tbx_Pattern" runat="server" CssClass="Custom_Hidden" Width="100px"
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "ProductsPattern").ToString() %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="料号" SortExpression="ProductsEdition" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TXB_KSP_COde_Hidden" runat="server" CssClass="Custom_Hidden" Width="100px"
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "KSP_LossType").ToString() %>'></asp:TextBox>
                                                    <asp:TextBox ID="TXB_KSP_COde" runat="server" ReadOnly="True" Text='<%# DataBinder.Eval(Container.DataItem, "KSP_COde").ToString() %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="数量" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="Tbx_Number" Width="60px" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" value="1"></asp:TextBox>
                                                    <asp:TextBox ID="ProductsBarCode" Width="0px" runat="server" CssClass="Custom_Hidden" value='<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString() %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle CssClass='colHeader' />
                                        <RowStyle CssClass='listTableRow' />
                                        <AlternatingRowStyle BackColor="#E3EAF2" />
                                        <PagerStyle CssClass='Custom_DgPage' />
                                    </cc1:MyGridView>
                                </td>
                            </tr>
                        </table>
                        <!--分页-->
                    </td>
                </tr>
            </table>

            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top: 1px solid #A3B2CC;">
                <tr>
                    <td height="25" width="40%">
                        <asp:Button ID="Button2" runat="server" CssClass="crmbutton small save" Text="确定选择" OnClick="Button2_Click" />
                        <td width="60%" align="right">关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="100px"></asp:TextBox>&nbsp;<asp:Button ID="Button1" runat="server" Text="产品筛选" CssClass="Btt" OnClick="Button1_Click1" /></td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>

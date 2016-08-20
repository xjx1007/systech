<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectProducts.aspx.cs" Inherits="Knet_Common_SelectProducts" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <base target="_self" />
    <script>
        function closeWindow() {
            window.opener = null;
            window.close();
        }
    </script>
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script type="text/javascript" src="../Js/bodyedit.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
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

    <title>选择产品</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div>
            <br />


            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="tablecss">
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
                        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="true" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>" GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="25px">
                            <Columns>

                                <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="CheckBox1" onclick="selectAll(this)" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chbk" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="KSP_Code" HeaderText="料号" SortExpression="KSP_Code">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="ProductsName" HeaderText="产品名称" SortExpression="ProductsName">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ProductsPattern" HeaderText="产品型号" SortExpression="ProductsPattern">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="ProductsEdition" HeaderText="版本" SortExpression="ProductsEdition">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Number" HeaderText="库存" SortExpression="Number">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="数量" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <pc:PTextBox ID="Tbx_Number" runat="server" Width="70px" Text='<%# base.FormatNumber1(DataBinder.Eval(Container.DataItem, "Number").ToString(),0)%>' ValidType="int"></pc:PTextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="单价" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <pc:PTextBox ID="Tbx_Price" runat="server" Width="70px" Text='<%# base.FormatNumber1(DataBinder.Eval(Container.DataItem, "Price").ToString(),5)%>'></pc:PTextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="备注" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:TextBox ID="Tbx_Remark" runat="server" Width="70px" Text=""></asp:TextBox>
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
                <tr>
                    <td>
                        </td>
                    <td>
                        <table width="100%" class="small">
                            <tr>
                                <td height="25" width="10%">
                                    <asp:Button ID="Button2" runat="server" CssClass="crmbutton small save" Text="确 定" OnClick="Button1_Click" Style="width: 55px; height: 33px;" />

                                </td>
                                <td width="25%" align="right">料号:<asp:TextBox ID="Tbx_Code" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="100px"></asp:TextBox></td>
                                <td width="25%" align="right">版本号:<asp:TextBox ID="Tbx_ProductsEdition" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="100px"></asp:TextBox></td>
                                <td width="35%" align="right">关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="100px"></asp:TextBox>&nbsp;<asp:Button ID="Button1" runat="server" Text="产品筛选" CssClass="crmbutton small create" OnClick="Button1_Click1" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <!--内部结束-->


        </div>
    </form>
</body>
</html>

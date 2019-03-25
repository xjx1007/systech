<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectProducts_Sales.aspx.cs" Inherits="Knet_Common_SelectProducts_Sales" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../css/knetwork.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <script>
        function closeWindow() {
            window.opener = null;
            window.close();
        }
    </script>
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

    <title>选择采购报价</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div>
            <!--头部-->
            <div class="TitleBar">报价产品选择 </div>
            <div id="ssdd" style="padding: 3px"></div>
            <!--头部-->

            <asp:Label runat="server" ID="CustomerName"></asp:Label>


            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="tablecss">
                <tr>
                    <td>
                        <!--GridView-->
                        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="true" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>" GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="25px">
                            <Columns>

                                <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="CheckBox1" onclick="selectAll(this)" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chbk" runat="server" /><a href="#" onclick="javascript:window.open('../System/KnetProductsSetting_Details.aspx?BarCode=<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><asp:Image ID="Image1" runat="server" ImageUrl="../../images/Deitail.gif" ToolTip="查看产品详细信息" /></a>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="ProductsBarCode" HeaderText="编码" SortExpression="ProductsName">
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
                                <asp:TemplateField HeaderText="大类名称" SortExpression="ProductsMainCategory" HeaderStyle-Font-Size="12px" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# GetBigCateNane(DataBinder.Eval(Container.DataItem, "ProductsMainCategory"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="单位" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="Lbl_Unit" runat="server" Width="70px" Text='<%# Base_GetUnitsName(DataBinder.Eval(Container.DataItem, "ProductsUnits"))%>'></asp:Label>
                                        <asp:TextBox ID="Tbx_UnitValue" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProductsUnits")%>' Style="display: none"></asp:TextBox>
                                        <asp:TextBox ID="ProductsCostPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProductsCostPrice")%>' Style="display: none"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="Contract_SalesUnitPrice" ItemStyle-Font-Size="12px" ItemStyle-ForeColor="blue" HeaderText="历史售价" ItemStyle-Width="70px" HeaderStyle-Font-Size="12px" SortExpression="Contract_SalesUnitPrice" DataFormatString="{0:c}" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="单价" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <pc:PTextBox ID="Tbx_Price" runat="server" Width="70px" ValidType="Float" Text='<%#DataBinder.Eval(Container.DataItem, "Contract_SalesUnitPrice")%>'></pc:PTextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="数量" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <pc:PTextBox ID="Tbx_Number" runat="server" Width="70px" Text="" ValidType="int"></pc:PTextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="备注" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:TextBox ID="Tbx_Remark" runat="server" Width="70px" Text=""></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>


                            </Columns>
                            <FooterStyle BackColor="LightSteelBlue" />
                            <HeaderStyle BackColor="LightSteelBlue" />
                            <AlternatingRowStyle BackColor="WhiteSmoke" />
                            <PagerStyle HorizontalAlign="Left" />
                        </cc1:MyGridView>


                        <!--底部功能栏-->
                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top: 1px solid #A3B2CC;">
                            <tr>
                                <td height="25" width="35%">
                                    <asp:Button ID="Button2" runat="server" CssClass="Btt" Text="确定选择" OnClick="Button1_Click" Style="width: 55px; height: 33px;" />
                                    <asp:Button ID="Button3" runat="server" Text="取消选择" CssClass="Btt" OnClick="Button2_Click" />&nbsp;<asp:Button
                                        ID="Button4" runat="server" Text="完成选择" CssClass="Btt" OnClick="Button4_Click" /></td>
                                <td width="65%" align="right">
                                    <select id="BigClass" style="width: 140px" runat="server" onchange="changsheng(this.value)">
                                        <option value="0">--请选择大类--</option>
                                    </select>
                                    <select id="SmallClass" runat="server" style="width: 140px">
                                        <option value="0">--请选择小类--</option>
                                    </select>关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="Boxx" Width="100px"></asp:TextBox>&nbsp;<asp:Button ID="Button1" runat="server" Text="产品筛选" CssClass="Btt" OnClick="Button1_Click1" /></td>
                            </tr>
                        </table>
                        <!--底部功能栏-->


                        <asp:GridView ID="GridView2" runat="server" GridLines="None" Width="100%" ItemStyle-Height="25px" HorizontalAlign="center" AutoGenerateColumns="false">
                            <Columns>

                                <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <img src="../../images/Au1.gif" width="14" height="15" border="0" />
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:BoundField DataField="ProductsName" HeaderText="产品名称" SortExpression="ProductsName" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="ProductsBarCode" HeaderText="编号(条码)" SortExpression="ProductsBarCode" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="120px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="ProductsPattern" HeaderText="产品型号" SortExpression="ProductsPattern" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="单位" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# base.Base_GetUnitsName(DataBinder.Eval(Container.DataItem, "ProductsUnits"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="数量" SortExpression="BaoPriceAmount" HeaderStyle-Font-Size="12px" ItemStyle-Width="70px" HeaderStyle-ForeColor="blue" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">

                                    <ItemTemplate>
                                        <asp:Label ID="Labddfgdel1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"BaoPriceAmount")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                            </Columns>


                            <FooterStyle BackColor="LightSteelBlue" />
                            <HeaderStyle BackColor="LightSteelBlue" />
                            <AlternatingRowStyle BackColor="WhiteSmoke" />
                            <PagerStyle HorizontalAlign="Left" />



                        </asp:GridView>





                    </td>
                </tr>
            </table>
            <!--内部结束-->


        </div>
    </form>
</body>
</html>

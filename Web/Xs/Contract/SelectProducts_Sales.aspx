<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectProducts_Sales.aspx.cs"
    Inherits="Knet_Common_SelectProducts_Sales" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <script type="text/javascript" src="/Web/js/ajax_func.js"></script>
    <script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <base target="_self" />
    <script>
        function closeWindow() {
            window.opener = null;
            window.close();
        }
        //改变价格方法
        function Chang(ipt) {
            var trs = document.getElementById("GridView1");
            var pipt = ipt.parentNode.parentNode;
            var i_row = pipt.rowIndex;
            var i_rows = trs.rows.length;
            var v_OrderBNumber = trs.rows(i_row).cells(3).innerText;
            var v_NewOrderBNumber = trs.rows(i_row).cells(8).childNodes[1].value
            var v_LeftBNumber = trs.rows(i_row).cells(9).childNodes[1].value
            if (i_rows > 0) {
                trs.rows(i_row).cells(9).childNodes[1].value = parseInt(v_OrderBNumber) - parseInt(v_NewOrderBNumber);
            }
        }
    </script>
    <title>选择产品</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div>
            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                <tr>
                    <td style="height: 2px"></td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>选择产品 > <a class="hdrLink" href="SelectProducts_Sales.aspx">选择产品</a>
                    </td>
                    <td width="100%" nowrap></td>
                </tr>
                <tr>
                    <td style="height: 2px"></td>
                </tr>
            </table>

            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="small">
                <tr>
                    <td>
                        <asp:Label runat="server" ID="CustomerName"></asp:Label>
                        <!--GridView-->
                        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="true" AllowSorting="True"
                            EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"
                            GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"
                            ShowHeader="true" HeaderStyle-Height="25px" OnRowDataBound="GridView1_DataRowBinding">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-HorizontalAlign="left">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="CheckBox1" onclick="selectAll(this)" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chbk" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="名称" SortExpression="ProdutsName" ItemStyle-Width="60px"  HeaderStyle-Font-Size="12px"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%#base.Base_GetProdutsName_Link(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="版本" SortExpression="ProductsEdition" ItemStyle-Width="150px" HeaderStyle-Font-Size="12px"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%#base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Contract_SalesUnitPrice" ItemStyle-Font-Size="12px" ItemStyle-ForeColor="blue"
                                    HeaderText="历史" HeaderStyle-Font-Size="12px" SortExpression="Contract_SalesUnitPrice"  HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="单价" SortExpression="Contract_SalesUnitPrice" ItemStyle-Width="50px" HeaderStyle-Font-Size="12px"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <pc:PTextBox ID="Tbx_Price" runat="server" CssClass="detailedViewTextBox" Width="50px" OnFocus="this.className='detailedViewTextBoxOn'"
                                            OnBlur="this.className='detailedViewTextBox'" ValidType="Float"
                                            Text='<%#DataBinder.Eval(Container.DataItem, "Contract_SalesUnitPrice")%>'></pc:PTextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="数量" HeaderStyle-Font-Size="12px"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <pc:PTextBox ID="Tbx_Number" runat="server" CssClass="detailedViewTextBox"
                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                            ValidType="int" Width="70px" Text=""></pc:PTextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="备品数量" HeaderStyle-Font-Size="12px"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <pc:PTextBox ID="Tbx_BNumber" runat="server" Text="" CssClass="detailedViewTextBox"
                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                            ValidType="int" Width="70px"></pc:PTextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="计划单号" HeaderStyle-Font-Size="12px"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <pc:PTextBox ID="Tbx_PlanNumber" runat="server" CssClass="detailedViewTextBox"
                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                            Width="70px" Text=""></pc:PTextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="订单号" HeaderStyle-Font-Size="12px"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <pc:PTextBox ID="Tbx_OrderNumber" runat="server" CssClass="detailedViewTextBox"
                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                            Width="70px" Text=""></pc:PTextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="客户料号" HeaderStyle-Font-Size="12px"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <pc:PTextBox ID="Tbx_MaterNumber" runat="server" CssClass="detailedViewTextBox"
                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                            Width="70px" Text=""></pc:PTextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="客户型号" HeaderStyle-Font-Size="12px"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <pc:PTextBox ID="Tbx_MaterPattern" runat="server" CssClass="detailedViewTextBox"
                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                            Width="70px" Text=""></pc:PTextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="随货" HeaderStyle-Font-Size="12px" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="Chk_IsFollow" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="备注" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px"
                                    ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:TextBox ID="Tbx_Remark" runat="server" Width="100px" Text="" CssClass="detailedViewTextBox"
                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"></asp:TextBox>
                                        <asp:TextBox ID="Tbx_UnitValue" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProductsUnits")%>'
                                            Style="display: none"></asp:TextBox>
                                        <asp:TextBox ID="ProductsCostPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProductsCostPrice")%>'
                                            Style="display: none"></asp:TextBox>
                                        <asp:TextBox ID="ProductsBarCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode")%>'
                                            Style="display: none"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="样品" HeaderStyle-Font-Size="12px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%#base.base_GetProductsDemoState(DataBinder.Eval(Container.DataItem, "KSP_SampleID").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                            <HeaderStyle CssClass='colHeader' />
                            <RowStyle CssClass='listTableRow' />
                            <AlternatingRowStyle BackColor="#E3EAF2" />
                            <PagerStyle CssClass='Custom_DgPage' />
                        </cc1:MyGridView>
                        <!--底部功能栏-->
                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top: 1px solid #A3B2CC;">
                            <tr>
                                <td width="35%" align="left">
                                    <asp:Button ID="Button2" runat="server" Text="确定选择"
                                        CssClass="crmbutton small create" OnClick="Button1_Click" Style="width: 80px; height: 28px;" />
                                    <input name="button2" type="button" value="关闭窗口" class="crmbutton small cancel" style="width: 80px; height: 28px;" onclick="closeWindow();">
                                </td>
                                <td width="65%" align="right">&nbsp;关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="detailedViewTextBox"
                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                    Width="300px"></asp:TextBox>&nbsp;<asp:Button ID="Button1" runat="server" Text="产品筛选"
                                        CssClass="crmbutton small create" OnClick="Button1_Click1" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

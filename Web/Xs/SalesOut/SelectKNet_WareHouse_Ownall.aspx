<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectKNet_WareHouse_Ownall.aspx.cs"
    Inherits="Knet_Common_SelectKNet_WareHouse_Ownall" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="/Web/js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="/include/js/ListView.js"></script>
    <script type="text/javascript" src="/Web/KDialog/lhgdialog.js"></script>
    <script>
        function closeWindow() {
            window.opener = null;
            window.close();
        }
    </script>
    <title>选择仓库产品</title>
</head>
<base target="_self" />
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div>

            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                            <tr>
                                <td colspan="2">
                                    <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="true" PageSize="10" AllowSorting="True"
                                        EmptyDataText="<div align=center><font color=red><br/><br/><B>所选仓库 没有找到相关记录</B><br/><br/></font></div>"
                                        GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"
                                        ShowHeader="true" HeaderStyle-Height="25px" OnRowDataBound="GridView1_DataRowBinding" >
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-HorizontalAlign="left">
                                                <HeaderTemplate>
                                                    <input type="CheckBox" onclick="selectAll(this)" checked>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="Chbk" runat="server" Checked />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="90px" SortExpression="HouseNo" HeaderText="仓库名称"
                                                ItemStyle-Height="25px" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-HorizontalAlign="left">
                                                <ItemTemplate>
                                                    <%# base.Base_GetHouseName(Eval("HouseNo").ToString()) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="产品名称" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px"
                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <%# base.Base_GetProdutsName_Link(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="版本号" SortExpression="ProductsBarCode" HeaderStyle-Font-Size="12px"
                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <%# base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="备品" SortExpression="KSD_BNumber" HeaderStyle-Font-Size="12px"
                                                HeaderStyle-ForeColor="blue" ControlStyle-Width="60px" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="Tbx_BNumber" runat="server" CssClass="detailedViewTextBox" Width="40px"
                                                        Text='<%# DataBinder.Eval(Container.DataItem,"KSD_BNumber")%>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="出库数量" SortExpression="OutWareAmount" HeaderStyle-Font-Size="12px"
                                                HeaderStyle-ForeColor="blue" ControlStyle-Width="60px" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="Tbx_Number" runat="server" CssClass="detailedViewTextBox" Width="40px"
                                                        Text='<%# DataBinder.Eval(Container.DataItem,"OutWareAmount")%>'></asp:TextBox><br />
                                                    <asp:RequiredFieldValidator ID="JoinNumbera" runat="server" ErrorMessage="正整数!" ControlToValidate="Tbx_Number"
                                                        Display="Dynamic" ValidationGroup="88"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="JoinNumberbb" runat="server" ErrorMessage="正整数!"
                                                        ControlToValidate="Tbx_Number" ValidationExpression="^\+?[1-9][0-9]*$" Display="Dynamic"
                                                        ValidationGroup="88"></asp:RegularExpressionValidator>
                                                    <asp:TextBox ID="HouseNo" runat="server" CssClass="Custom_Hidden" 
                                                        Text='<%# DataBinder.Eval(Container.DataItem,"HouseNo")%>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="单价" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px"
                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <%# base.Base_GetProductsPrice(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString(), Eval("HouseNo").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Number" HeaderText="库存量" SortExpression="Number">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MaterOrderNo" HeaderText="计划单号" SortExpression="KSO_PlanNo">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OrderNo" HeaderText="订单号" SortExpression="OrderNo">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MaterNo" HeaderText="料号" SortExpression="MaterNo">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MaterMNo" HeaderText="客户型号" SortExpression="MaterMNo">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="KSO_IsFollow" HeaderText="随货" SortExpression="KSO_IsFollow">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="备注" HeaderStyle-Font-Size="12px" HeaderStyle-ForeColor="blue"
                                                ControlStyle-Width="60px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="Tbx_Remarks" runat="server" CssClass="detailedViewTextBox" Text=''></asp:TextBox><br />

                                                    <asp:TextBox ID="ProductsBarCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode")%>'
                                                        Style="display: none"></asp:TextBox>
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
                                <td height="25" width="35%">&nbsp;
                                <br />
                                    <asp:Button ID="Btn_Save" runat="server" Text="确定选择" AccessKey="S" title="确定选择 [Alt+S]"
                                        class="crmbutton small save" OnClick="Btn_SaveOnClick" />
                                    <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="closeWindow();"
                                        type="button" name="button" value="取 消" style="width: 70px;height: 30px;" >
                                </td>
                                <td width="65%" align="right">&nbsp;关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="detailedViewTextBox"
                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                    Width="300px"></asp:TextBox>&nbsp;<asp:Button ID="Button1" runat="server" Text="产品筛选"
                                        CssClass="crmbutton small create" OnClick="Button1_Click1" />
                                </td>
                            </tr>
                        </table>
                        <!--分页-->
                    </td>
                </tr>
            </table>
            </td> </tr> </table>
        <!--内部结束-->
        </div>
    </form>
</body>
</html>

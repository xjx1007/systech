<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectSalesContractList.aspx.cs"
    Inherits="Knet_Common_SelectSalesContractList" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <base target="_self" />
    <script>
        function closeWindow() {
            window.opener = null;
            window.close();
        }
        function set_return_value(ContractNo) {
            var response = Knet_Common_SelectSalesContractList.GetContractInfo(ContractNo);
            if (window.opener != undefined) {
                window.opener.returnValue = ContractNo + "|" + response.value;
                window.opener.SetReturnValueInOpenner_SalesContract(ContractNo + "|" + response.value);
            }
            else {
                window.returnValue = ContractNo + "|" + response.value;
            }
        }
    </script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="/Web/js/Global.js"></script>
    <title>选择合同单</title>
    <base target="_self" />
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px">
                </td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                    选择产品 > <a class="hdrLink" href="SelectProducts.aspx">选择产品</a>
                </td>
                <td width="100%" nowrap>
                    <asp:TextBox ID="Tbx_ProductsBarCode" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_Customer" runat="server" Style="display: none"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 2px">
                </td>
            </tr>
        </table>
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="dvtContentSpace">
            <tr>
                <td class="dvtCellInfo" colspan="4">
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="small">
                        <tr>
                            <td class="dvtCellLabel" width="10%" style="height: 30px; text-align: right">
                                日期：
                            </td>
                            <td class="dvtCellInfo" width="50%" style="height: 30px; text-align: left">
                                <asp:TextBox ID="StartDate" runat="server" CssClass="Wdate" onFocus="var EndDate=$dp.$('EndDate');WdatePicker({maxDate:'#F{$dp.$D(\'EndDate\')}'})"></asp:TextBox>&nbsp;到<asp:TextBox
                                    ID="EndDate" runat="server" CssClass="Wdate" onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})"></asp:TextBox>
                            </td>
                            <td class="dvtCellLabel" width="15%" style="height: 30px; text-align: right">
                                客户名称：
                            </td>
                            <td class="dvtCellInfo" width="25%" style="height: 30px; text-align: left">
                                <asp:TextBox ID="Tbx_Name" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                    OnBlur="this.className='detailedViewTextBox'" Width="100px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="dvtCellLabel" width="10%" style="height: 30px; text-align: right">
                                采购状态：
                            </td>
                            <td class="dvtCellInfo" width="50%" style="height: 30px; text-align: left">
                                <asp:DropDownList runat="server" ID="Drop_State">
                                    <asp:ListItem Text="-请选择-" Value=""></asp:ListItem>
                                    <asp:ListItem Text="未采购" Value="1" Selected></asp:ListItem>
                                    <asp:ListItem Text="已采购" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="dvtCellLabel" width="10%" style="height: 30px; text-align: right">
                                合同状态：
                            </td>
                            <td class="dvtCellInfo" width="50%" style="height: 30px; text-align: left">
                                <asp:DropDownList ID="DDLContractState" runat="server">
                                    <asp:ListItem Value="">请选择合同状态</asp:ListItem>
                                    <asp:ListItem Value="0">未完全发货通知</asp:ListItem>
                                    <asp:ListItem Value="2">全部发货通知</asp:ListItem>
                                    <asp:ListItem Value="3">超量发货通知</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;
                                <asp:Button ID="Button4" runat="server" Text="检索" class="crmbutton small create"
                                    OnClick="Button4_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                    EmptyDataText="<div align=center><font color=red><br/><br/><B>暂没有找到相关可发货的合同记录，请先确认审核合同可发货.</B><br/><br/></font></div>"
                                    GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"
                                    ShowHeader="true" HeaderStyle-Height="25px" OnRowDataBound="GridView1_DataRowBinding">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-HorizontalAlign="left">
                                            <HeaderTemplate>
                                                <input type="CheckBox" onclick="selectAll(this)" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Chbk" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="合同编号" SortExpression="ContractNo" HeaderStyle-Font-Size="12px"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <%# GetLink(DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="签订日期" DataField="ContractDateTime" SortExpression="ContractDateTime"
                                            DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="交货日期" DataField="ContractToDeliDate" SortExpression="ContractToDeliDate"
                                            DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="客户名称" SortExpression="CustomerValue" HeaderStyle-Font-Size="12px"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <a href="#" onclick="javascript:window.open('/Web/Xs/Sales/KNet_Sales_ClientList_Details.aspx?CustomerValue=<%# DataBinder.Eval(Container.DataItem, "CustomerValue")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');">
                                                    <%# base.Base_GetCustomerName(DataBinder.Eval(Container.DataItem, "CustomerValue").ToString())%></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="责任人" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "DutyPerson").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                    <asp:TemplateField HeaderText="产品类型" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# base.Base_GetContractProductsPatten(DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="数量" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# base.Base_GetContractAmount(DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="通知数量" DataField="v_OutWareAmount" SortExpression="v_OutWareAmount"
                                        HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="出库数量" DataField="v_DirectOutAmount" SortExpression="v_DirectOutAmount"
                                        HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                        <asp:TemplateField HeaderText="采购状态" HeaderStyle-Font-Size="12px" ItemStyle-Width="55px"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <%# base.GetContractState(DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="查看" HeaderStyle-Font-Size="12px" ItemStyle-Width="28px"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <a href="#" onclick="javascript:window.open('/Web/Xs/SalesContract/Xs_ContractList_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ContractNo")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="/images/View.gif" border="0"
                                                        ToolTip="查看合同详细信息" /></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass='Custom_DgHead' />
                                    <RowStyle CssClass='Custom_DgItem' />
                                    <AlternatingRowStyle BackColor="#E3EAF2" />
                                    <PagerStyle CssClass='Custom_DgPage' />
                                </cc1:MyGridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="tablecss">
            <tr>
                <td>
                    <!--GridView-->
                    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top: 1px solid #A3B2CC;">
                        <tr>
                            <td height="30" width="58%">
                                <asp:TextBox runat="server" ID="Tbx_CustomerValue" CssClass="Custom_Hidden"></asp:TextBox>
                                <asp:TextBox runat="server" ID="Tbx_COntractNo" CssClass="Custom_Hidden"></asp:TextBox>
                                <asp:TextBox runat="server" ID="Tbx_ID" CssClass="Custom_Hidden"></asp:TextBox>&nbsp;<asp:Button
                                    ID="Button2" runat="server" class="crmbutton small create" Text="确定选择" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />
                                <input name="button2" type="button" value="关闭窗口" class="crmbutton small edit" onclick="closeWindow();">
                            </td>
                            <td width="42%" align="right">
                                &nbsp;<asp:Button ID="Button1" runat="server" class="crmbutton small create" Text="更改为已采购"
                                    OnClick="Button1_Click1" /><asp:Button ID="Button3" runat="server" class="crmbutton small create"
                                        Text="更改为未采购" OnClick="Button3_Click1" />
                            </td>
                        </tr>
                    </table>
                    <!--底部功能栏-->
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectSalesShipList.aspx.cs" Inherits="Knet_Common_SelectSalesShipList" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../js/ajax_func.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script type="text/javascript" src="../KDialog/lhgdialog.js"></script>
    <script>
        function closeWindow() {
            window.opener = null;
            window.close();
        }
        function allMoney()
        {
            var GridView = document.getElementById("MyGridView1");
            var i_Num = 10001 + parseInt(GridView.rows.length);
            var v_TotalNet = 0;

            for (var i = 10002; i < i_Num; i++)
            {
                var v_Index = i % 10000;
                if (v_Index.toString().length == 1)
                {
                    v_Index = "0" + v_Index.toString();
                }
                var Chbk = document.getElementById("MyGridView1_ctl" + v_Index + "_Chbk");
                if (Chbk.checked)
                {
                    var Tbx_Money = document.getElementById("MyGridView1_ctl" + v_Index + "_Tbx_Money");
                    v_TotalNet += parseFloat(Tbx_Money.value);
                    document.all("Tbx_TotalNet").value = v_TotalNet.toFixed(2);
                }
            }
        }
    </script>
    <title>选择出库单</title>
    <base target="_self" />
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server" >
        <div>
            <table border="0" cellspacing="0" cellpadding="0" width="95%" class="small">
                <tr>
                    <td style="height: 2px"></td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>应付款计划 > 
                            选择出库记录</a>
                    </td>
                    <td width="100%" nowrap></td>
                </tr>
                <tr>
                    <td style="height: 2px"></td>
                </tr>
            </table>
            <hr noshade size="1"  style="width:95%">
            
            <table width="97%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="4" align="left">&nbsp;
                                    <asp:Button ID="Btn_Save" runat="server" Text="确定" AccessKey="S" title="确定 [Alt+S]"
                                        class="crmbutton small save" OnClick="Button1_Click" Style="width: 55px; height: 33px;" />
                                    <input title="关闭 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.close()"
                                        type="button" name="button" value="  关闭  " style="width: 55px; height: 33px;">
                                </td>
                            </tr>
                </table>
            
            <hr noshade size="1" style="width:95%">
            <table width="97%" border="0" align="center" cellpadding="0" cellspacing="0">

                <tr>
                    <td>
                        <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                            
                            <tr>
                                <td>

                                    <asp:TextBox runat="server" ID="Tbx_CustomerValue" CssClass="Custom_Hidden"></asp:TextBox>
                                    客户名称：
                                    <pc:PTextBox runat="server" ID="Tbx_Customer" CssClass="detailedViewTextBox"
                                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                        Width="350px"></pc:PTextBox>
                                    发票编号：
                                    <pc:PTextBox runat="server" ID="FPCOde" CssClass="detailedViewTextBox"
                                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                        Width="350px"></pc:PTextBox>
                                    <asp:Button ID="Button1" runat="server" Text="搜索" AccessKey="S" title="搜索 "
                                        class="crmbutton small save" Style="width: 55px; height: 25px;" OnClick="Button1_Click1" />
                                </td>
                            </tr>
                            <tr>
                                <td>

                                   合计金额：<asp:TextBox runat="server" ID="Tbx_TotalNet" CssClass="detailedViewTextBox"
                                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <div style="width:100%;height:400px;overflow:auto; border:1px solid #000000;">
                                    <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                        IsShowEmptyTemplate="true" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关发货记录</B><br/><br/></font></div>"
                                        AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="1000" Width="97%">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <input type="CheckBox" onclick="selectAll(this); allMoney()"  />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="Chbk" runat="server"  onclick="allMoney()"/>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle Height="25px" HorizontalAlign="Left" Width="40px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="出库单号" SortExpression="KWD_Custmoer">
                                                <ItemTemplate>
                                                    <a href="../SalesOut/Sales_ShipWareOut_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "DirectOutNo")%>"
                                                        target="_self">
                                                        <%# DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString()%></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="客户" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <%# base.Base_GetCustomerName_Link(DataBinder.Eval(Container.DataItem, "KWD_Custmoer").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="产品版本" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <%# base.Base_GetProductsEdition_Link(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="数量" DataField="DirectOutAmount"
                                                SortExpression="DirectOutAmount">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="单价" DataField="KWD_SalesUnitPrice"
                                                SortExpression="KWD_SalesUnitPrice">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="金额" DataField="KWD_SalesTotalNet"
                                                SortExpression="KWD_SalesTotalNet">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="未核销金额" DataField="Money"
                                                SortExpression="Money">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            
                                            <asp:TemplateField HeaderText="发票编号" HeaderStyle-Font-Size="12px"
                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center" SortExpression="CAB_BillNumber">
                                                <ItemTemplate>
                                                    <font color="red"><%# DataBinder.Eval(Container.DataItem, "CAB_BillNumber").ToString()%></font>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="开票日期" DataField="CAB_Stime" DataFormatString="{0:yyyy-MM-dd}"
                                                SortExpression="CAB_Stime">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            
                                            <asp:TemplateField HeaderText="超期日期" HeaderStyle-Font-Size="12px"
                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center" SortExpression="CAO_OutTime">
                                                <ItemTemplate>
                                                    <%# GetOutTime(DataBinder.Eval(Container.DataItem, "CAO_OutTime").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="超期天数" HeaderStyle-Font-Size="12px"
                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center" SortExpression="CqDays">
                                                <ItemTemplate>
                                                    <%# GetOutTimeDays(DataBinder.Eval(Container.DataItem, "CqDays").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="超期金额" DataField="CAO_Money"
                                                SortExpression="CAO_Money">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="开票" HeaderStyle-Font-Size="12px"
                                                ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                <ItemTemplate>
                                                    <%# GetReceive(DataBinder.Eval(Container.DataItem, "v_State").ToString(), DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString())%>
                                                    <asp:TextBox ID="Tbx_CAO_ID" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "CAO_ID").ToString()%>'></asp:TextBox>
                                                    <asp:TextBox ID="Tbx_Money" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "Money").ToString()%>'></asp:TextBox>
                                                    <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "Type").ToString()%>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle CssClass='colHeader' />
                                        <RowStyle CssClass='listTableRow' />
                                        <AlternatingRowStyle BackColor="#E3EAF2" />
                                        <PagerStyle CssClass='Custom_DgPage' />
                                    </cc1:MyGridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <!--分页-->
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

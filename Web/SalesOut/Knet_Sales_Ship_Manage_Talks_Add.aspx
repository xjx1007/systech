<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="Knet_Sales_Ship_Manage_Talks_Add.aspx.cs"
    Inherits="Knet_Sales_Ship_Manage_Talks_Add" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../css/knetwork.css" type="text/css">
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="../js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
    <script type="text/javascript">
        if (window != window.parent)
        { var P = window.parent, D = P.loadinndlg(); }

        function searchFromSelect(str) {
            var o = document.getElementById("Drop_KD");
            if (o.tagName == "SELECT") {
                var opts = o.options;
                str = str ? str : event.srcElement.innerText;

                var tmp = '';
                var kCode = event.keyCode;

                if (str != "") {
                    if (kCode == 33 || kCode == 38 || kCode == 35)//向上翻页，方向键，end
                    {
                        o.selectedIndex = o.selectedIndex > 0 ? o.selectedIndex - 1 : 0;
                        if (kCode == 35) o.selectedIndex = opts.length - 1;
                        for (var i = o.selectedIndex; i >= 0; i--) {
                            tmp = opts(i % opts.length).text;
                            if (tmp.indexOf(str) >= 0) {
                                o.selectedIndex = i % opts.length;
                                return;
                            }
                        }
                    }
                    if (kCode == 34 || kCode == 40 || kCode == 36)//
                    {
                        o.selectedIndex++;
                        if (kCode == 36) o.selectedIndex = opts.length - 1;
                    }
                    for (var i = o.selectedIndex; i < (opts.length + o.selectedIndex); i++) {
                        tmp = opts(i % opts.length).text;
                        if (tmp.indexOf(str) >= 0) {
                            o.selectedIndex = i % opts.length;
                            return;
                        }
                    }
                    o.selectedIndex = 0;
                }
            }
        }
        function Chang() {
            var myid = document.getElementById("Drop_KD");
            if (myid.options[myid.selectedIndex].text == "--请选择--") {
                document.getElementById("FollowText").value = document.getElementById("Tbx_Code").value
            }
            else {
                if (document.getElementById("Tbx_Code").value != "") {
                    document.getElementById("FollowText").value = myid.options[myid.selectedIndex].text + "(" + document.getElementById("Tbx_Code").value + ")";
                }
                else {
                    document.getElementById("FollowText").value = myid.options[myid.selectedIndex].text;
                }
            }
        }
    </script>
    <title>发货跟踪添加</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div id="ListGo333">
        <div id="ssdd" style="padding: 2px">
        </div>
        <table height="22" border="0" cellpadding="0" cellspacing="0" width="100%" align="center">
            <tr>
                <td width="90" align="center">
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="Div11" Width="90px" Height="21px"
                        Font-Size="14px">跟踪列表</asp:HyperLink>
                </td>
                <td width="4" align="center">
                </td>
                <td width="90" align="center">
                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="Div22" Width="90px" Height="21px"
                        Font-Size="14px" Font-Bold="true" ForeColor="MintCream">添加跟踪</asp:HyperLink>
                </td>
                <td width="4" align="center">
                </td>
                <td align="right">
                    &nbsp;&nbsp;
                </td>
            </tr>
        </table>
        
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="tablecss">
            <tr>
                <td>
                    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="34" align="right" class="dvtCellLabel">
                                完成发货：
                            </td>
                            <td class="dvtCellInfo">
                            <asp:CheckBox runat="server" ID="Chk_IsFH" Checked="true" />
                            </td>
                        </tr>
                        <tr>
                            <td height="34" align="right" class="dvtCellLabel">
                                动态跟踪情况：
                            </td>
                            <td class="dvtCellInfo">
                                <asp:TextBox ID="FollowText" runat="server" TextMode="MultiLine" Height="60px" Width="350px"
                                    CssClass="Boxx"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="34" align="right" class="dvtCellLabel">
                                快递：
                            </td>
                            <td class="dvtCellInfo">
                                <asp:DropDownList ID="Drop_KD" runat="server" Width="150px" onchange='Chang()'>
                                </asp:DropDownList>
                                <input type="text" id="span" class="detailedViewTextBox" onchange='Chang()' onkeyup='searchFromSelect(this.value)'
                                    onkeydown='window.event.cancelBubble = true;if(event.keyCode==13){return false;}'
                                    style="width: 100px" />
                            </td>
                        </tr>
                        <tr>
                            <td height="34" align="right" class="dvtCellLabel">
                                单号：
                            </td>
                            <td class="dvtCellInfo">
                                <asp:TextBox ID="Tbx_Code" runat="server" Height="60px" Width="350px" CssClass="Boxx"
                                    onchange='Chang()'></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="34" align="right" class="dvtCellLabel">
                                手机号码：
                            </td>
                            <td class="dvtCellInfo">
                                <asp:TextBox ID="Tbx_Phone" runat="server" Height="20px" Width="350px" CssClass="Boxx"></asp:TextBox><font color=red>*</font>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="联系方式不能为空"
                                                    ControlToValidate="Tbx_Phone" Display="Dynamic"></asp:RequiredFieldValidator></td>
                            
                        </tr>
                        <asp:Panel runat="server" ID="Pan_Details">
                        <tr>
                            <td colspan="4" class="detailedViewHeader">
                                <b>出库信息</b>
                            </td>
                        </tr>
                        <tr>
                            <td height="34" align="right" class="dvtCellLabel">
                                出库日期：
                            </td>
                            <td class="dvtCellInfo">
                                <asp:TextBox runat="server" ID="Tbx_CkTime" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>
                                <asp:TextBox runat="server" ID="Tbx_OldTime" CssClass="Custom_Hidden"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="34" align="right" class="dvtCellLabel">
                                账务日期：
                            </td>
                            <td class="dvtCellInfo">
                                <asp:TextBox runat="server" ID="Tbx_ZwTime" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>
                                <asp:TextBox runat="server" ID="Tbx_ZwOldTime" CssClass="Custom_Hidden"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="34" colspan="2">
                                <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                    IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                                    PageSize="10" Width="100%">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <input type="CheckBox" onclick="selectAll(this)">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Chbk" runat="server"  />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Height="25px" HorizontalAlign="Left" Width="40px" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="物料编码" DataField="ProductsBarCode" SortExpression="ProductsBarCode">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="产品名称" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <%# base.Base_GetProdutsName(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="产品版本" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <%# base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="数量" DataField="DirectOutAmount" SortExpression="DirectOutAmount">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="实际数量" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:TextBox ID="Tbx_Number" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="100px" Text='<%# DataBinder.Eval(Container.DataItem, "DirectOutAmount").ToString()%>'></asp:TextBox>
                                                <asp:TextBox ID="Tbx_DID" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "ID").ToString()%>'></asp:TextBox>
                                                <asp:TextBox ID="Tbx_DirectOutUnitPrice" runat="server" CssClass="Custom_Hidden"
                                                    Text='<%# DataBinder.Eval(Container.DataItem, "DirectOutUnitPrice").ToString()%>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="实际备货数量" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:TextBox ID="Tbx_BNumber" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="100px" Text='<%# DataBinder.Eval(Container.DataItem, "KWD_BNumber").ToString()%>'></asp:TextBox>
                                                 </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass='colHeader' />
                                    <RowStyle CssClass='listTableRow' />
                                    <AlternatingRowStyle BackColor="#E3EAF2" />
                                    <PagerStyle CssClass='Custom_DgPage' />
                                </cc1:MyGridView>
                            </td>
                        </tr></asp:Panel>
                        <tr>
                            <td align="right" style="height: 28px">
                                &nbsp;
                            </td>
                            <td style="height: 28px">
                                &nbsp;<asp:Button ID="Button1" runat="server" Text="确定添加跟踪" CssClass="Btt" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />
                            </td>
                        </tr>
                    </table>
                    <asp:TextBox ID="Tbx_DirectOutNo" runat="server" Style="display: none"></asp:TextBox>
                </td>
            </tr>
        </table>
        <!--内部结束-->
    </div>
    </form>
</body>
</html>

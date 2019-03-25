<%@ Page Language="C#" AutoEventWireup="true" CodeFile="System_PhoneMessage_List.aspx.cs"
    Inherits="System_Message_List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="../js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
    <title>短消息列表</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
    <div id="createpm_div" style="display: block; position: absolute; left: 100px; top: 100px;
        z-index: 5000;">
    </div>
    <div>
        <table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
            <tr>
                <td colspan="3">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                        <tr>
                            <td style="height: 2px">
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                                <%=s_Title%>
                                > <a class="hdrLink" href="Cw_Accounting_Payment_List.aspx">
                                    <%=s_Title%></a>
                            </td>
                            <td width="100%" nowrap>
                                <table border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="sep1" style="width: 1px;">
                                        </td>
                                        <td class="small">
                                            <!-- Add and Search -->
                                            <table border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td>
                                                        <table border="0" cellspacing="0" cellpadding="5">
                                                            <tr>
                                                                <td style="padding-right: 0px; padding-left: 10px;">
                                                                    <a href="javascript:;" onclick="PageGo('System_PhoneMessage_Manage.aspx')">
                                                                        <img src="../../themes/softed/images/btnL3Add.gif" alt="创建 <%=s_Title%>..." title="创建 <%=s_Title%>..."
                                                                            border="0"></a>
                                                                </td>
                                                                <td style="padding-right: 0px;">
                                                                    <asp:ImageButton runat="server" ID="Btn_Del" ImageUrl="../../themes/softed/images/btnL3Delete.gif"
                                                                        OnClick="Btn_Del_Click" />
                                                                </td>
                                                                <td style="padding-right: 10px">
                                                                    <a href="javascript:;" onclick="ShowDiv()">
                                                                        <img src="../../themes/softed/images/btnL3Search.gif" alt="查找 <%=s_Title%>..." title="查找 <%=s_Title%>..."
                                                                            border="0"></a>
                                                                </td>
                                                                <td style="padding-right: 0px; padding-left: 10px;">
                                                                    <img src="../../themes/softed/images/tbarImport.gif" alt="*导入 <%=s_Title%>" title="*导入 <%=s_Title%>"
                                                                        border="0">
                                                                </td>
                                                                <td style="padding-right: 10px">
                                                                    <img src="../../themes/softed/images/tbarExport.gif" alt="*导出 <%=s_Title%>" title="*导出 <%=s_Title%>"
                                                                        border="0">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 2px">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
                    <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                        <tr>
                            <td>
                                <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                    EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>"
                                    GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"
                                    ShowHeader="true" HeaderStyle-Height="25px">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="7%" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-HorizontalAlign="left">
                                            <HeaderTemplate>
                                                <input type="checkbox" onclick="javascript:selectAll(this);" />选
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Chbk" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SPM_ReceiveName" HeaderText="收信人" ControlStyle-Width="120px">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="120px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SPM_ReceivePhone" HeaderText="收信人" ControlStyle-Width="120px">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="120px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="内容" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left"
                                            ItemStyle-Width="800px">
                                            <ItemTemplate>
                                                <%# GetDetails(DataBinder.Eval(Container.DataItem, "SPM_Detail").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="发送人" ItemStyle-Width="7%" ItemStyle-Height="25px"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                            <ItemTemplate>
                                                <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "SPM_SenderID").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SPM_SendTime" HeaderText="发送时间" ControlStyle-CssClass="Boxx"
                                            ControlStyle-Width="120px" SortExpression="HouseName">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="120px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="查看" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <a href="#" onclick="javascript:window.open('System_Message_Detail.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "SPM_ID")%>','查看详细','top=120,left=150,menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=800,height=650');">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="../../images/View.gif" border="0"
                                                        ToolTip="查看详细信息" /></a>
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
    </div>
    </td>
    <td valign="top">
        &nbsp;
    </td>
    </tr> </table> </div>
    </form>
</body>
</html>

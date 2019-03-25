<%@ Page Language="C#" AutoEventWireup="true" CodeFile="System_Message_List.aspx.cs" Inherits="System_Message_List" %>

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
        <div id="createpm_div" style="display: block; position: absolute; left: 100px; top: 100px; z-index: 5000;"></div>
        <div>
            <table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
                <tr>
                    <td colspan="3">
                        <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                            <tr>
                                <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;</td>
                                <td <%=s_unreadStyle%> align="center" nowrap><a href="System_Message_List.aspx?Type=unread">未读</a></td>
                                <td style="width: 10px" class="dvtTabCache">&nbsp;</td>
                                <td <%=s_inboxStyle%> align="center" nowrap><a href="System_Message_List.aspx?Type=inbox">收件箱</a></td>
                                <td style="width: 10px" class="dvtTabCache">&nbsp;</td>
                                <td <%=s_sentStyle%> align="center" nowrap><a href="System_Message_List.aspx?Type=sent">发件箱</a></td>
                                <td style="width: 5%" class="dvtTabCache">&nbsp;</td>
                                <td style="width: 100%" class="dvtTabCache">

                                    <asp:TextBox ID="search_text" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="200px"></asp:TextBox>

                                    <asp:Button ID="Btn_Search" runat="server" Text="立即查找" AccessKey="F" title="立即查找 [Alt+F]"
                                        class="crmbutton small delete" OnClick="Btn_Search_Click" />
                                </td>

                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td valign="top">&nbsp;</td>
                    <td class="showPanelBg" valign="top" width="100%" style="padding: 10px;">
                        <form name="addToPB" method="POST" id="addToPB">
                            <div id="ListViewContents" class="small" style="width: 100%; position: relative;">

                                <input name='search_url' id="search_url" type='hidden' value='&folder=inbox'>
                                <input name='idlist' id="idlist" type='hidden' value=''>
                                <input name='folder' id="folder" type='hidden' value='inbox'>
                                <table width="100%" border="0">
                                    <tr class="small">
                                        <td>
                                            <input type="button" value="发送短消息" onclick="PageGo('System_Message_Manage.aspx')" class="crmbutton small create" />&nbsp;&nbsp;
                
                                                <asp:Button ID="Btn_Del" runat="server" Text="刪  除" AccessKey="D" title="刪  除 [Alt+D]"
                                                    class="crmbutton small delete" OnClick="Btn_Del_Click" />
                                            <asp:Button ID="Btn_Edit" runat="server" Text="已  读" AccessKey="E" title="已  读 [Alt+E]"
                                                class="crmbutton small edit" OnClick="Btn_Edit_Click" />
                                            <asp:Button ID="Btn_DelAll" runat="server" Text="一键清除" AccessKey="A" title="刪  除 [Alt+A]"
                                                class="crmbutton small delete" OnClick="Btn_DelAll_Click" />
                                            <td nowrap width="50%" align="right" valign="middle">
                                                <table border="0" cellspacing="0" cellpadding="0" class="small">
                                                    <tr></tr>
                                                </table>
                                            </td>
                                    </tr>
                                </table>
                                <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                                    <tr>
                                        <td>

                                            <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>"
                                                GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="25px">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="7%" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                                        <HeaderTemplate>
                                                            <input type="checkbox" onclick="javascript:selectAll(this);" />选
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="Chbk" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="标题" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                                        <ItemTemplate>
                                                            <%# GetState(DataBinder.Eval(Container.DataItem, "SMM_UnRead").ToString())+"  "+DataBinder.Eval(Container.DataItem, "SMM_Title").ToString()%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="内容" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left" ItemStyle-Width="800px">
                                                        <ItemTemplate>
                                                            <%# GetDetails(DataBinder.Eval(Container.DataItem, "SMM_Detail").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="发送人" ItemStyle-Width="7%" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                                        <ItemTemplate>
                                                            <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "SMM_SenderID").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="SMM_SendTime" HeaderText="发送时间" ControlStyle-CssClass="Boxx" ControlStyle-Width="120px" SortExpression="HouseName">
                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="120px" />
                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="查看" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <a href="#" onclick="javascript:window.open('System_Message_Detail.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "SMM_ID")%>','查看详细','top=120,left=150,menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=800,height=650');">
                                                                <asp:Image ID="Image2" runat="server" ImageUrl="../../images/View.gif" border="0" ToolTip="查看详细信息" /></a>
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
                        </form>
                    </td>
                    <td valign="top">&nbsp;</td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>

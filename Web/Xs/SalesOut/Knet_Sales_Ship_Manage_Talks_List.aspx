<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Knet_Sales_Ship_Manage_Talks_List.aspx.cs"
    Inherits="KNet_Web_Sales_Knet_Sales_Ship_Manage_Talks_List" %>

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
    <script type="text/javascript">
        if (window != window.parent)
        { var P = window.parent, D = P.loadinndlg(); }
    </script>
    <style type="text/css">
        .Div11
        {
            background-image: url(../../images/midbottonA2.gif);
            background-repeat: no-repeat;
            z-index: 0px;
            padding-top: 3px;
        }
        .Div22
        {
            background-image: url(../../images/midbottonB2.gif);
            background-repeat: no-repeat;
            z-index: 0px;
            padding-top: 3px;
        }
    </style>
    <title>发货跟踪信息列表</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div id="ListGo">
        <div id="ssdd" style="padding: 2px">
        </div>
        <table height="22" border="0" cellpadding="0" cellspacing="0" width="100%" align="center">
            <tr>
                <td width="90" align="center">
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="Div11" Width="90px" Height="21px"
                        Font-Size="14px" Font-Bold="true" ForeColor="MintCream">跟踪列表</asp:HyperLink>
                </td>
                <td width="4" align="center">
                </td>
                <td width="90" align="center">
                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="Div22" Width="90px" Height="21px"
                        Font-Size="14px">添加跟踪</asp:HyperLink>
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
                    <!--GridView-->
                                                <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                IsShowEmptyTemplate="true" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关的出库单</B><br/><br/></font></div>"
                                AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="10" Width="100%"  >       <Columns>

                     
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <input type="CheckBox" onclick="selectAll(this)">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Chbk" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                            <asp:TemplateField HeaderText="是否发货" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%#base.Base_GetBasicCodeName("107", DataBinder.Eval(Container.DataItem, "KSO_ISFH").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发货跟踪内容" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "FollowText")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="跟踪跟进人" SortExpression="FollowStaffNo" HeaderStyle-Font-Size="12px"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%# GetStaffName(DataBinder.Eval(Container.DataItem, "FollowStaffNo"))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="出库单号" SortExpression="OutWareNo">
                                <ItemTemplate>
                                    <a href="Sales_ShipWareOut_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "OutWareNo")%>"
                                        target="_self">
                                        <%# DataBinder.Eval(Container.DataItem, "OutWareNo").ToString()%></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="快递" SortExpression="KDName" HeaderStyle-Font-Size="12px"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%# GetKDName(DataBinder.Eval(Container.DataItem, "KDCodeName").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="快递单号" SortExpression="KDName" HeaderStyle-Font-Size="12px"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <a href="#" onclick="javascript:window.open('Knet_Sales_Ship_Manage_Talks_Detail.aspx?com=<%# DataBinder.Eval(Container.DataItem, "KDName")%>&Code=<%# DataBinder.Eval(Container.DataItem, "KDCode")%>&Name=<%# DataBinder.Eval(Container.DataItem, "KDCodeName")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=580,height=250');">
                                        <%# DataBinder.Eval(Container.DataItem, "KDCode").ToString()%></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="电话" DataField="KSO_Phone" SortExpression="KSO_Phone">
                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="快递状态" SortExpression="KDName" HeaderStyle-Font-Size="12px"
                                ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%# GetKDSateName(DataBinder.Eval(Container.DataItem, "KDName").ToString(), DataBinder.Eval(Container.DataItem, "KDCode").ToString(), DataBinder.Eval(Container.DataItem, "KDCodeName").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="进跟时间" DataField="FollowDateTime" SortExpression="FollowDateTime">
                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>
                        </Columns>
                                <HeaderStyle CssClass='colHeader' />
                                <RowStyle CssClass='listTableRow' />
                                <AlternatingRowStyle BackColor="#E3EAF2" />
                                <PagerStyle CssClass='Custom_DgPage' />
                            </cc1:MyGridView>
                    <!--GridView-->
                    <!--分页-->
                    <!--底部功能栏-->
                    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top: 1px solid #A3B2CC;">
                        <tr>
                            <td height="30" width="58%">
                                &nbsp;<asp:Button ID="Button2" runat="server" CssClass="crmButton small create" Text="删除所选项" OnClick="Button1_Click"/>
                                <asp:Button ID="Button3" runat="server" Text="取消选择"  CssClass="crmButton small save" OnClick="Button2_Click" />
                            </td>
                            <td width="42%" align="right">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <!--底部功能栏-->
                </td>
            </tr>
        </table>
        <!--内部结束-->
    </div>
    </form>
</body>
</html>

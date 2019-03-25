<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Xs_Transfer_Cheque_List.aspx.cs" Inherits="Web_Sales_Xs_Transfer_Cheque_List" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <title></title>
</head>
<script type="text/javascript" src="../js/ajax_func.js"></script>
<script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>账号支出 >
	<a class="hdrLink" href="Xs_Transfer_Cheque_List.aspx">账号支出</a>
                </td>
                <td width="100%" nowrap>
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="sep1" style="width: 1px;"></td>
                            <td class="small">
                                <!-- Add and Search -->
                                <table border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <table border="0" cellspacing="0" cellpadding="5">
                                                <tr>
                                                    <td style="padding-right: 0px; padding-left: 10px;"><a href="javascript:;" onclick="PageGo('Xs_Transfer_Cheque_Add.aspx')">
                                                        <img src="../../themes/softed/images/btnL3Add.gif" alt="创建 账号支出..." title="创建 账号支出..." border="0"></a></td>
                                                    <td style="padding-right: 0px;"><a href="javascript:;" onclick="PageGo('')">
                                                        <img src="../../themes/softed/images/btnL3Delete.gif" alt="删除 账号支出..." title="删除 账号支出..." border="0"></a></td>
                                                    <td style="padding-right: 10px"><a href="javascript:;" onclick="ShowDiv()">
                                                        <img src="../../themes/softed/images/btnL3Search.gif" alt="查找 账号支出..." title="查找 账号支出..." border="0"></a></td>
                                                    <td style="padding-right: 0px; padding-left: 10px;">
                                                        <img src="../../themes/softed/images/tbarImport.gif" alt="*导入 账号支出" title="*导入 账号支出" border="0"></td>
                                                    <td style="padding-right: 10px">
                                                        <img src="../../themes/softed/images/tbarExport.gif" alt="*导出 账号支出" title="*导出 账号支出" border="0"></td>
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
                <td style="height: 2px"></td>
            </tr>
        </table>


        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="tablecss">
            <tr>
                <td>
                    <%=base.Base_BindView("Xs_Transfer_Cheque", "Xs_Transfer_Cheque_List.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString())%>
                </td>
            </tr>
            <tr>
                <td>

                    <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                        <tr>
                            <!-- Buttons -->
                            <td style="padding-right: 20px" align="left" nowrap>查看范围:<asp:DropDownList runat="server" ID="Ddl_Batch" AutoPostBack="True" OnTextChanged="Ddl_Batch_TextChanged"></asp:DropDownList>
                                <a id="moreoperate" href="" target="main" onmouseover="BatchfnDropDown(this,'selectoperate');" onmouseout="fnHideDrop('selectoperate');" onclick="return false;">批量操作</a>
                                <img border="0" src="../../themes/images/collapse.gif">
                                <div id="selectoperate" class="drop_mnu" onmouseout="fnHideDrop('selectoperate')" onmouseover="fnShowDrop('selectoperate')">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <a href="#" class="drop_down">修改负责人</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <a href="#" class="drop_down">共享</a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>

                                <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True" IsShowEmptyTemplate="true" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关客户记录</B><br/><br/></font></div>"
                                    AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="10" Width="100%">
                                    <Columns>

                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <input type="CheckBox" onclick="selectAll(this)">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Chbk" runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Height="25px" HorizontalAlign="Left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="编号" SortExpression="XTC_ID" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <a href="Xs_Transfer_Cheque_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "XTC_ID") %>"><%# DataBinder.Eval(Container.DataItem, "XTC_ID") %></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="收款人" SortExpression="XTC_PayeeValue" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <%# GetName(DataBinder.Eval(Container.DataItem, "XTC_PayeeValue").ToString(),DataBinder.Eval(Container.DataItem, "XTC_PayeeName").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField HeaderText="用途" DataField="XTC_UseName" SortExpression="XTC_UseName" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center"></asp:BoundField>
                                        <asp:TemplateField HeaderText="支票类型" SortExpression="XTC_Type" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <%# base.Base_GetBasicCodeName("123", DataBinder.Eval(Container.DataItem, "XTC_Type").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="支出日期" DataField="XTC_Stime" SortExpression="XTC_Stime" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="出票人" SortExpression="XTC_DutyPerson" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "XTC_DutyPerson").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField HeaderText="金额" DataField="XTC_Money" SortExpression="XTC_Money">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="操作时间" DataField="XTC_MTime" SortExpression="XTC_MTime">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="打印" HeaderStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <a target="_blank" href="Xs_Transfer_Cheque_Print.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "XTC_ID") %>">
                                                    <asp:Image ID="Image4" runat="server" ImageUrl="../../images/Print1.gif" border="0" ToolTip="打印" /></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="修改" HeaderStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <a href="Xs_Transfer_Cheque_Add.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "XTC_ID") %>">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="../../images/Edit.gif" border="0" ToolTip="修改" /></a>
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

                    <table style="margin-top: 0px;" class="lvt small" border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tbody>
                            <tr>
                                <td valign="middle">
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td valign="middle">
                                                    <img border="0" src="../../themes/images/chart.png" width="30"></td>
                                                <td valign="middle"><b>本次查询统计报表</b></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr bgcolor="white">
                                <td style="line-height: 26px;" valign="top">●<a style="color: rgb(153, 102, 51);" href="javascript:;" onclick="PageGo('../Report_Cw/TransferCheque/Report_Details.aspx')">支出明细</a>
                                </td>
                            </tr>

                        </tbody>
                    </table>


                </td>
            </tr>
        </table>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="logs.aspx.cs" Inherits="Knet_web_System_logs" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="/Web/js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="/include/js/ListView.js"></script>
    <title></title>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div>


            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                <tr>
                    <td style="height: 2px"></td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>工作台 > <a class="hdrLink" href="Pb_Basic_Notice_List.aspx">
                        <asp:Label runat="server" ID="Lbl_Title"></asp:Label></a>
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
                                                        <td style="padding-right: 0px; padding-left: 10px;">
                                                            <a href="javascript:;" onclick="PageGo('Pb_Basic_Notice_Add.aspx')">
                                                                <img src="/themes/softed/images/btnL3Add.gif" alt="创建 系统操作日志..." title="创建 系统操作日志..."
                                                                    border="0"></a>
                                                        </td>
                                                        <td style="padding-right: 0px;">
                                                            <asp:ImageButton runat="server" ID="Btn_Del" ImageUrl="/themes/softed/images/btnL3Delete.gif"
                                                                OnClick="Button1_Click" />
                                                        </td>
                                                        <td style="padding-right: 10px">
                                                            <a href="javascript:;" onclick="ShowDiv();">
                                                                <img src="/themes/softed/images/btnL3Search.gif" alt="查找 系统操作日志..." title="查找 系统操作日志..."
                                                                    border="0"></a>
                                                        </td>
                                                        <td style="padding-right: 0px; padding-left: 10px;">
                                                            <img src="/themes/softed/images/tbarImport.gif" alt="*导入 系统操作日志" title="*导入 系统操作日志"
                                                                border="0">
                                                        </td>
                                                        <td style="padding-right: 10px">
                                                            <img src="/themes/softed/images/tbarExport.gif" alt="*导出 系统操作日志" title="*导出 系统操作日志"
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
                    <td style="height: 2px"></td>
                </tr>
            </table>
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="small">
                <tr>
                    <td width="550" background="../../images/ktxt2.gif" style="background-color: #F5F5F5; height: 28px;">&nbsp;日期从<asp:TextBox ID="StartDate" runat="server" CssClass="Wdate" onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})"></asp:TextBox>&nbsp;到<asp:TextBox ID="EndDate" runat="server" CssClass="Wdate" onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})"></asp:TextBox>&nbsp;关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="Boxx" Width="120px"></asp:TextBox></td>
                    <td background="../../images/ktxt2.gif" style="background-color: #F5F5F5; height: 28px;" align="left">
                        <asp:Button ID="Button4" runat="server" Text="日志检索" CssClass="crmButton small save" OnClick="Button4_Click" /></td>
                </tr>
            </table>


            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="small">

                <tr>
                    <td>
                        <%=base.Base_BindView("KNet_Static_logs", "logs.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString())%>
                    </td>
                </tr>
                <tr>
                    <td>

                        <!--GridView-->
                        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%" PageSize="10"
                            BorderColor="#4974C2"
                            EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='/themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="48px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="CheckBox1" onclick="selectAll(this)" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chbk" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="操作员工" SortExpression="StaffNo" ItemStyle-Font-Size="12px" HeaderStyle-Font-Size="12px" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate><%# Knet_Get_StaffName(Eval("StaffNo"))%></ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="Logtime" HeaderText="日志时间" SortExpression="Logtime">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="120px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="IP地址" SortExpression="logIP" ItemStyle-Font-Size="12px" HeaderStyle-Font-Size="12px" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# IPtoAddress(Eval("logIP").ToString()) %><br />
                                        (<%# Eval("logIP")%>)
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="logContent" HeaderText="日志内容" SortExpression="logContent">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>
                            </Columns>
                            <HeaderStyle CssClass='colHeader' />
                            <RowStyle CssClass='listTableRow' />
                            <AlternatingRowStyle BackColor="#E3EAF2" />
                            <PagerStyle CssClass='Custom_DgPage' />
                        </cc1:MyGridView>
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top: 1px solid #A3B2CC;">
                            <tr>
                                <td height="30">&nbsp;<asp:Button ID="Button1" runat="server" CssClass="crmButton small delete" Text="删除所选项" OnClick="Button1_Click" />
                                    <asp:Button ID="Button3" runat="server" Text="删三个月前" CssClass="crmButton small delete" OnClick="Button3_Click" />&nbsp;&nbsp;<asp:Button ID="Button5" runat="server" Text="删二个月前" CssClass="crmButton small delete" OnClick="Button5_Click" />&nbsp;&nbsp;<asp:Button ID="Button6" runat="server" Text="删一个月前" CssClass="crmButton small delete" OnClick="Button6_Click" />&nbsp;&nbsp;<asp:Button ID="Button7" runat="server" Text="删三天前" CssClass="crmButton small delete" OnClick="Button7_Click" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
